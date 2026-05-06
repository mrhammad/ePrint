using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Company;
using Printcenter.UI.Deliveries;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint
{
    public partial class multiple_delivery_note_new : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private CompanyBasePage objComp = new CompanyBasePage();

        private commonClass commclass = new commonClass();

        private BasePage objPage = new BasePage();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string LabelText = string.Empty;

        public int CompanyID;

        public long EstimateID;

        public long OrderID;

        public string DateFormat = string.Empty;

        public int UserID;

        public string pg = string.Empty;

        public int ClientID;

        public int AttentionID;

        private string ShippedTo = string.Empty;

        private string Footer = string.Empty;

        private string Header = string.Empty;

        public string OrderNo = string.Empty;

        public string CustomerOrderNo = string.Empty;

        private long EstDelAddressID;

        private string EstDelAddressType = string.Empty;

        public DateTime DeliveyDate = DateTime.Now;

        public DateTime ActualDeliveryDate = DateTime.Now;

        public string Quantity = "0";

        private int Items;

        private string ItemDescription = string.Empty;

        private string[] ArryItemDescription;

        private string[] AryEsimateItemID;

        private string[] AryEstimateType;

        private string StrEsimateItemID = string.Empty;

        private string StrEstimateType = string.Empty;

        public string ConQuantity = string.Empty;

        private string ConItemDescription = string.Empty;

        private string[] ArryConItemDescription;

        private string[] AryConEsimateItemID;

        private string[] AryConEstimateType;

        private string[] AryConEstimateID;

        private string[] AryConJobID;

        private string[] ArryConItemDescription_Split;

        private string StrConEstimateID = string.Empty;

        private string StrConEsimateItemID = string.Empty;

        private string StrConEstimateType = string.Empty;

        private string StrConItemDescription = string.Empty;

        private string[] ArryItemTypeID;

        private string strItemTitle = string.Empty;

        public string JobItemTitle = string.Empty;

        public string JobItemTitle_newrow = string.Empty;

        public string JobItemTitle_conswithsplit_newrow = string.Empty;

        public static string disptype;

        private short QtyNumber;

        private string estitemid_consolidate = string.Empty;

        public static string Frmconsolidate;

        private int deliveryquantity;

        private int availablequanity;

        private string ConJobItemTitle = string.Empty;

        private int returnquantity;

        private string[] strSingleDelQty;

        public string SplitDelivery_ItemDesc = string.Empty;

        public static string querystring;

        public static string sessionaddress;

        public string DelRaise_Type = string.Empty;

        public string ConDelRaise_Type = string.Empty;

        public string CustomerName = string.Empty;

        public string AttentionName = string.Empty;

        public string MainJobNumber = string.Empty;

        public string ServerName = string.Empty;

        public string AttnName = string.Empty;

        public string JobDeliveryAddress = string.Empty;

        public bool IsDefltHeader;

        public bool IsDefltFooter;

        private DateTime TodayDate;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int CostCentreID;

        public string deliveryNoteRedirect = string.Empty;

        public string DeliveryNotePrefix = string.Empty;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public int AccountingID;

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

        static multiple_delivery_note_new()
        {
            multiple_delivery_note_new.disptype = string.Empty;
            multiple_delivery_note_new.Frmconsolidate = string.Empty;
            multiple_delivery_note_new.querystring = string.Empty;
            multiple_delivery_note_new.sessionaddress = string.Empty;
        }

        public multiple_delivery_note_new()
        {
        }

        private void BindConsolidatedDelivery()
        {
            int count = 0;
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = EstimateBasePage.JobDeliveryNote_Details_Select(this.CompanyID, this.ClientID);
            string empty = string.Empty;
            DataTable dataTable2 = new DataTable("Table1");
            dataTable2.Columns.Add("JobNumber", typeof(string));
            dataTable2.Columns.Add("EstimateItemID", typeof(string));
            dataTable2.Columns.Add("EstimateType", typeof(string));
            dataTable2.Columns.Add("EstimateID", typeof(string));
            dataTable2.Columns.Add("ItemTitle", typeof(string));
            dataTable2.Columns.Add("Quantity", typeof(string));
            dataTable2.Columns.Add("ItemDescription", typeof(string));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div align='left' style='width: 100%;height: 30px;' class='bgcustomize navigatorpanel'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left; width: 2%;padding: 0 3 0 3px;vertical-align: middle;border-right:0px solid white'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<input type='checkbox' style='display:block' onclick='checkAll_new(this);' runat='server' name='checkAll' />"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left; width: 10%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Job_Number")));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left; width: 13%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Item_Title")));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left; width: 17%;padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Item_Description")));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 8%;padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " <br /> ", this.objLanguage.GetLanguageConversion("Ordered"))));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 8%;padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " <br /> ", this.objLanguage.GetLanguageConversion("Produced"))));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 8%;padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " <br /> ", this.objLanguage.GetLanguageConversion("Delivered"))));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 8%;padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " <br /> ", this.objLanguage.GetLanguageConversion("Available"))));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float:left;width: 5px'>&nbsp;</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left; width: 10%;padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Job_Status")));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div style='float: left;margin-left:1%;width: 6%;padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Job_Card")));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            this.plhConsolidated_header.Controls.Add(new LiteralControl("</div>"));
            count = dataTable1.Rows.Count;
            double num = 20;
            num = (count > 20 ? 200 : (double)(20 * count) * 1.6);
            this.plhConsolidated.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width: 100%;height: ", num, "px;overflow-y: scroll;'>")));
            int num1 = 0;
            int num2 = 0;
            foreach (DataRow row in dataTable1.Rows)
            {
                DataRowCollection rows = dataTable2.Rows;
                object[] str = new object[] { row["jobnumber"].ToString(), row["EstimateItemId"].ToString(), row["EstimateType"].ToString(), row["EstimateID"].ToString(), row["ItemTitle"].ToString(), row["QuantityOrdered"].ToString(), row["ItemDescription"].ToString() };
                rows.Add(str);
                try
                {
                    this.plhConsolidated.Visible = true;
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    string empty2 = string.Empty;
                    this.ConJobItemTitle = base.SpecialDecode(row["ItemTitle"].ToString());
                    empty1 = (this.ConJobItemTitle.Length < 100 ? this.ConJobItemTitle : string.Concat(this.ConJobItemTitle.Substring(0, 100), "..."));
                    this.ConItemDescription = row["ItemDescription"].ToString();
                    empty2 = row["JobNumber"].ToString();
                    string str2 = string.Empty;
                    str2 = string.Concat(32, "px");
                    string str3 = "NewTableRow normalText";
                    str3 = (num2 % 2 != 0 ? "NewAlternative normalText" : "NewTableRow normalText");
                    string str4 = "17%";
                    str1 = (this.ConItemDescription.Length < 49 ? this.ConItemDescription : string.Concat(this.ConItemDescription.Substring(0, 49), "..."));
                    ControlCollection controls = this.plhConsolidated.Controls;
                    object[] objArray = new object[] { "<div id='div_Item_", num2, "' align='left' style='width: 100%;height: ", str2, ";clear: both;border: 0px solid green' class='", str3, "'>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                    this.plhConsolidated.Controls.Add(new LiteralControl("<div style='float: left; width: 2%;padding: 0 3 0 3px;vertical-align: middle;border-right:0px solid white;'>"));
                    if (empty2 != this.MainJobNumber)
                    {
                        ControlCollection controlCollections = this.plhConsolidated.Controls;
                        object[] objArray1 = new object[] { "<input type='checkbox' runat='server'  onclick='javascript:GetConQty(this,", this.CheckMinusAmount(row["QuantityAvailable"].ToString()), ",", row["EstimateItemId"].ToString(), ");'  value='", num2, "' />" };
                        controlCollections.Add(new LiteralControl(string.Concat(objArray1)));
                    }
                    else
                    {
                        ControlCollection controls1 = this.plhConsolidated.Controls;
                        object[] objArray2 = new object[] { "<input type='checkbox' runat='server'  onclick='javascript:GetConQty(this,", this.CheckMinusAmount(row["QuantityAvailable"].ToString()), ",", row["EstimateItemId"].ToString(), ");' checked='true'  value='", num2, "' />" };
                        controls1.Add(new LiteralControl(string.Concat(objArray2)));
                        Type type = base.GetType();
                        string[] strArrays = new string[] { "javascript:GetConQty('chkinitial',", this.CheckMinusAmount(row["QuantityAvailable"].ToString()), ",", row["EstimateItemId"].ToString(), ");" };
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, type, "", string.Concat(strArrays), true);
                    }
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl(string.Concat("<div title='", empty2, "' style='float: left; width: 10%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;border: 0px solid red; overflow: hidden;'>")));
                    this.plhConsolidated.Controls.Add(new LiteralControl(empty2));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl("<div style='float: left; width: 13%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;border: 0px solid red'>"));
                    ControlCollection controlCollections1 = this.plhConsolidated.Controls;
                    string[] strArrays1 = new string[] { "<span title='", base.SpecialDecode(this.ConJobItemTitle), "'>", base.SpecialDecode(empty1), "</span>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(strArrays1)));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    ControlCollection controls2 = this.plhConsolidated.Controls;
                    string[] strArrays2 = new string[] { "<div style='float: left; width: ", str4, ";max-width: ", str4, ";overflow: hidden;padding: 2 3 2 3px;vertical-align: middle;border: 0px solid red'>" };
                    controls2.Add(new LiteralControl(string.Concat(strArrays2)));
                    ControlCollection controlCollections2 = this.plhConsolidated.Controls;
                    object[] objArray3 = new object[] { "<label id='lblConDesc_", num2, "' title='", base.SpecialDecode(this.ConItemDescription), "'>", base.SpecialDecode(str1), "<label/>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(objArray3)));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl("<div style='float: left;text-align: right; width: 9%;padding: 2 3 2 3px;vertical-align: middle;border: 0px solid red'>"));
                    ControlCollection controls3 = this.plhConsolidated.Controls;
                    object[] objArray4 = new object[] { "<label id='lblConQty_", num2, "'>", row["QuantityOrdered"].ToString(), "<label/><span style='display: none' id='spnEstType_", num2, "'>", row["EstimateType"].ToString(), "</span>" };
                    controls3.Add(new LiteralControl(string.Concat(objArray4)));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 8%;padding: 2 3 2 3px;vertical-align: middle;border: 0px solid red'>"));
                    ControlCollection controlCollections3 = this.plhConsolidated.Controls;
                    object[] str5 = new object[] { "<label id='lblConQtyProduced_", num2, "'>", row["QuantityProduced"].ToString(), "<label/>" };
                    controlCollections3.Add(new LiteralControl(string.Concat(str5)));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl("<div style='float: left; text-align:right;width: 8%;padding: 2 3 2 3px;vertical-align: middle;border: 0px solid red'>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl(row["QuantityDelivered"].ToString()));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 8%;padding: 2 3 2 3px;vertical-align: middle;border: 0px solid red'>"));
                    ControlCollection controls4 = this.plhConsolidated.Controls;
                    object[] objArray5 = new object[] { "<span id='lblConAvialbleQty_", num2, "'>", this.CheckMinusAmount(row["QuantityAvailable"].ToString()), "</span><span style='display: none' id='spnEstItemIDChckall_", num2, "'>", row["EstimateItemId"].ToString(), "</span>" };
                    controls4.Add(new LiteralControl(string.Concat(objArray5)));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl(string.Concat("<div title='", row["JobStatus"].ToString(), "' style='float: left; width: 11%;text-align: center;padding: 2 3 2 3px;vertical-align: middle;border: 0px solid red; overflow: hidden;'>")));
                    ControlCollection controlCollections4 = this.plhConsolidated.Controls;
                    object[] str6 = new object[] { row["JobStatus"].ToString(), "<span style='display: none' id='spnEstID_", num2, "'>", row["EstimateID"].ToString(), "</span><span style='display: none' id='spnEstItemID_", num2, "'>", row["EstimateItemId"].ToString(), "</span>" };
                    controlCollections4.Add(new LiteralControl(string.Concat(str6)));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl("<div style='float: left; width: 7%;padding: 2 3 2 3px;vertical-align: middle;margin-left:1%;border: 0px solid red'>"));
                    ControlCollection controls5 = this.plhConsolidated.Controls;
                    string[] strArrays3 = new string[] { "<a href='#' onclick='javascript:ShowJobCard(", row["EstimateID"].ToString(), ",", row["EstimateItemId"].ToString(), ",", row["Jobid"].ToString(), ")'>Job Card</a>" };
                    controls5.Add(new LiteralControl(string.Concat(strArrays3)));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
                    num1++;
                    num2++;
                }
                catch (Exception exception)
                {
                }
            }
            this.Session["dtSendToOtherPage"] = dataTable2;
            this.plhConsolidated.Controls.Add(new LiteralControl("</div>"));
            this.hdn_contotitems.Value = num1.ToString();
        }

        public void BindSplitAddress(int CompanyID, int ClientID, int ItemNo, string Quantity)
        {
            this.plhSplitAddress.Controls.Clear();
            multiple_delivery_note_new.disptype = (ItemNo == 0 ? "block" : "none");
            ControlCollection controls = this.plhSplitAddress.Controls;
            object[] itemNo = new object[] { "<div id='div_SplitContent_", ItemNo, "' align='left' style='width: 100%; table-layout: fixed;border:1px solid #A4A4A4;display: ", multiple_delivery_note_new.disptype, "'>" };
            controls.Add(new LiteralControl(string.Concat(itemNo)));
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div align='left' style='width: 100%;height: 20px;' class='bgcustomize navigatorpanel'>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left; width: 5%;padding: 2 3 2 6px;vertical-align: middle;border-right:0px solid white;'>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Sl_No")));
            this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width: 5px;'>&nbsp;</div>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left; width: 33%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Item_Title")));
            this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width: 5px;'>&nbsp;</div>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;text-align: right; width: 10%;padding: 2 3 2 3px;border-right:0px solid white;'>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Qty")));
            this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width: 4%;'>&nbsp;</div>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='width:40%;float: left;padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Address")));
            this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
            int num = 0;
            int num1 = 0;
            this.hdn_splitEstimateID.Value = "";
            this.hdn_splitEstimateItemID.Value = "";
            this.hdn_splitEstimateType.Value = "";
            this.hdn_splitItemDesc.Value = "";
            for (int i = 0; i < Convert.ToInt32(this.hdn_TotItems.Value); i++)
            {
                long num2 = this.ItemTypeID(this.AryEstimateType[i].ToString(), Convert.ToInt64(this.AryEsimateItemID[i].ToString()));
                this.QtyNumber = JobBasePage.Job_Item_QuantityNumber_Select(CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()));
                if (this.AryEstimateType[i].ToString() == "S" || this.AryEstimateType[i].ToString() == "L" || this.AryEstimateType[i].ToString() == "P" || this.AryEstimateType[i].ToString() == "B" || this.AryEstimateType[i].ToString() == "F" || this.AryEstimateType[i].ToString() == "D" || this.AryEstimateType[i].ToString() == "N" || this.AryEstimateType[i].ToString() == "K" || this.AryEstimateType[i].ToString() == "C" || this.AryEstimateType[i].ToString() == "Q" || this.AryEstimateType[i].ToString().ToLower() == "x")
                {
                    DataTable dataTable = JobsBasePage.Job_Items_Quantity_Details_Select(CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), num2, this.AryEstimateType[i].ToString(), this.QtyNumber);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Quantity = row["quantity"].ToString();
                        Convert.ToInt32(row["quantity"].ToString());
                    }
                    DataTable dataTable1 = DeliveryBasePage.deliveryitem_select_splitdelivery(CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), this.EstimateID, this.AryEstimateType[i].ToString());
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.returnquantity = this.returnonlyquantity(dataRow["quantity"].ToString());
                        num = num + Convert.ToInt32(this.returnquantity);
                    }
                }
                else if (this.AryEstimateType[i].ToString() == "O")
                {
                    foreach (DataRow row1 in EstimateBasePage.Estimate_Outwork_Quantity_Details_Select(CompanyID, num2, this.QtyNumber).Rows)
                    {
                        Quantity = row1["Quantity"].ToString();
                        Convert.ToInt32(row1["Quantity"].ToString());
                    }
                    DataTable dataTable2 = DeliveryBasePage.deliveryitem_select_splitdelivery(CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), this.EstimateID, this.AryEstimateType[i].ToString());
                    foreach (DataRow dataRow1 in dataTable2.Rows)
                    {
                        this.returnquantity = this.returnonlyquantity(dataRow1["quantity"].ToString());
                        num = num + Convert.ToInt32(this.returnquantity);
                    }
                }
                else if (this.AryEstimateType[i].ToString() == "U" || this.AryEstimateType[i].ToString() == "W")
                {
                    DataTable dataTable3 = EstimateBasePage.Estimate_OtherCost_Qty_Details_Select(CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), this.AryEstimateType[i].ToString());
                    foreach (DataRow row2 in dataTable3.Rows)
                    {
                        string str = this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, Convert.ToDecimal(row2["Quantity"].ToString()), 0, "", true, false, true);
                        Quantity = str;
                        Quantity = str;
                        if (row2["Quantity"] == null)
                        {
                            continue;
                        }
                        Convert.ToInt32(row2["Quantity"]);
                    }
                    DataTable dataTable4 = DeliveryBasePage.deliveryitem_select_splitdelivery(CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), this.EstimateID, this.AryEstimateType[i].ToString());
                    foreach (DataRow dataRow2 in dataTable4.Rows)
                    {
                        this.returnquantity = this.returnonlyquantity(dataRow2["quantity"].ToString());
                        num = num + Convert.ToInt32(this.returnquantity);
                    }
                }
                Quantity = this.CheckMinusAmount(Quantity.ToString());
                int num3 = JobsBasePage.Job_DeliveryNote_QtyProduced_Select(CompanyID, this.EstimateID, (long)Convert.ToInt32(this.AryEsimateItemID[i].ToString()), this.AryEstimateType[i].ToString());
                num3 = (num3 == 0 ? Convert.ToInt32(Quantity) : num3);
                num1 = Convert.ToInt32(Math.Round(Convert.ToDouble(num3), 0)) - num;
                num1 = (num1 < 0 ? 0 : num1);
                string str1 = "NewTableRow normalText";
                this.plhSplitAddress.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width: 100%;height: 20px;border:0px solid;clear: both;padding-bottom: 3px' class='", str1, "'>")));
                if (i != 0)
                {
                    this.plhSplitAddress.Controls.Add(new LiteralControl("<div  style='float: left; width: 5%;padding: 2 3 2 6px;vertical-align: middle;border-right:0px solid;'>"));
                    this.plhSplitAddress.Controls.Add(new LiteralControl(""));
                    this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
                }
                else
                {
                    this.plhSplitAddress.Controls.Add(new LiteralControl("<div  style='float: left; width: 5%;padding: 2 3 2 6px;vertical-align: bottom;border-right:0px solid;'>"));
                    Label label = new Label();
                    object[] objArray = new object[] { "splitslno_", ItemNo, "_", i };
                    label.ID = string.Concat(objArray);
                    label.Text = "1";
                    this.plhSplitAddress.Controls.Add(label);
                    this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
                }
                this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width: 5px;'>&nbsp;</div>"));
                DataTable dataTable5 = this.ItemTitle(Convert.ToInt32(this.AryEsimateItemID[i].ToString()), this.AryEstimateType[i].ToString());
                foreach (DataRow row3 in dataTable5.Rows)
                {
                    this.JobItemTitle = row3["ItemTitle"].ToString();
                    multiple_delivery_note_new jobsMultipleDeliveryNoteNew = this;
                    jobsMultipleDeliveryNoteNew.JobItemTitle_newrow = string.Concat(jobsMultipleDeliveryNoteNew.JobItemTitle_newrow, row3["ItemTitle"].ToString().Replace("\n", "").Replace("\r", ""), "~");
                    multiple_delivery_note_new jobsMultipleDeliveryNoteNew1 = this;
                    jobsMultipleDeliveryNoteNew1.SplitDelivery_ItemDesc = string.Concat(jobsMultipleDeliveryNoteNew1.SplitDelivery_ItemDesc, row3["ItemDescription"].ToString(), "~");
                }
                HiddenField hdnSplitEstimateID = this.hdn_splitEstimateID;
                hdnSplitEstimateID.Value = string.Concat(hdnSplitEstimateID.Value, this.EstimateID, "~");
                HiddenField hdnSplitEstimateItemID = this.hdn_splitEstimateItemID;
                hdnSplitEstimateItemID.Value = string.Concat(hdnSplitEstimateItemID.Value, this.AryEsimateItemID[i].ToString(), "~");
                HiddenField hdnSplitEstimateType = this.hdn_splitEstimateType;
                hdnSplitEstimateType.Value = string.Concat(hdnSplitEstimateType.Value, this.AryEstimateType[i].ToString(), "~");
                this.hdn_splitItemDesc.Value = this.SplitDelivery_ItemDesc;
                string splitDeliveryItemDesc = this.SplitDelivery_ItemDesc;
                char[] chrArray = new char[] { 'µ' };
                splitDeliveryItemDesc.Split(chrArray)[0].Split(new char[] { '»' });
                this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width: 33%;white-space: nowrap;overflow:hidden;max-width: 33%;height:16px;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
                this.plhSplitAddress.Controls.Add(new LiteralControl(base.SpecialDecode(this.JobItemTitle)));
                this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
                this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width: 5px;'>&nbsp;</div>"));
                this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width: 10%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;'>"));
                TextBox textBox = new TextBox();
                object[] itemNo1 = new object[] { "txtSplitQty_", ItemNo, "_", i };
                textBox.ID = string.Concat(itemNo1);
                textBox.Width = 100;
                textBox.SkinID = "textPad";
                textBox.Style["TEXT-ALIGN"] = TextAlign.Right.ToString();
                textBox.Text = this.CheckMinusAmount(num1.ToString());
                textBox.AutoCompleteType = AutoCompleteType.Disabled;
                textBox.MaxLength = 8;
                textBox.Attributes.Add("onkeyup", "javascript:AllowNumber(this,this.value);");
                textBox.Attributes.Add("onkeypress", "javascript:AllowNumber(this,this.value);");
                AttributeCollection attributes = textBox.Attributes;
                object[] value = new object[] { "javascript:ValidateQty(this,'", this.hdn_SplitQty.Value, "','", ItemNo, "',", i, ");" };
                attributes.Add("onblur", string.Concat(value));
                textBox.Attributes.Add("onfocus", "javascript:this.select()");
                this.plhSplitAddress.Controls.Add(textBox);
                string[] strArrays = this.SplitDelivery_ItemDesc.Split(new char[] { '~' });
                ControlCollection controlCollections = this.plhSplitAddress.Controls;
                object[] objArray1 = new object[] { "<span style='display: none' id='spnEstimateItemID_split_", ItemNo, "_", i, "'>", this.AryEsimateItemID[i].ToString(), "</span><span style='display: none' id='spnEstimateType_split_", ItemNo, "_", i, "'>", this.AryEstimateType[i].ToString(), "</span><span style='display: none' id='spnEstimateID_split_", ItemNo, "_", i, "'>", this.EstimateID.ToString(), "</span><span style='display: none' id='spnItemDesc_split_", ItemNo, "_", i, "'>", strArrays[i], "</span>" };
                controlCollections.Add(new LiteralControl(string.Concat(objArray1)));
                this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
                this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width: 4%;'>&nbsp;</div>"));
                DataTable dataTable6 = CompanyBasePage.Delivery_Address_Select(CompanyID, this.EstimateID);
                if (i != 0)
                {
                    this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left; width: 40%;border: 0px solid red;; padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;overflow:hidden; max-width: 40%;height:12px'>"));
                    this.plhSplitAddress.Controls.Add(new LiteralControl(""));
                    this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
                }
                else
                {
                    Label label1 = new Label();
                    if (dataTable6.Rows.Count <= 0)
                    {
                        string str2 = "";
                        string str3 = "";
                        this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width:40%; border: 0px solid green; padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;overflow:hidden; max-width: 40%;height:15px;'>"));
                        ControlCollection controls1 = this.plhSplitAddress.Controls;
                        object[] itemNo2 = new object[] { "<img src='../images/plus.gif' title='Add address' style='vertical-align: top;padding-left: 3px;cursor:pointer;' border='0' onclick=javascript:More_Address_split('", ItemNo, "_", i, "');return false; />&nbsp;" };
                        controls1.Add(new LiteralControl(string.Concat(itemNo2)));
                        object[] objArray2 = new object[] { "txtaddress_", ItemNo, "_", i };
                        label1.ID = string.Concat(objArray2);
                        label1.Text = "";
                        this.hid_address_text.Value = "";
                        this.hid_thisaddressid.Value = "";
                        this.plhSplitAddress.Controls.Add(label1);
                        ControlCollection controlCollections1 = this.plhSplitAddress.Controls;
                        object[] itemNo3 = new object[] { "<span style='display: none' id='spnAddID_", ItemNo, "_", i, "'>", str2, "</span><span style='display: none' id='spnAddType_", ItemNo, "_", i, "'>", str3, "</span>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(itemNo3)));
                        this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
                        this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        string str4 = dataTable6.Rows[0]["AddressID"].ToString();
                        string str5 = dataTable6.Rows[0]["AddressType"].ToString();
                        this.plhSplitAddress.Controls.Add(new LiteralControl("<div style='float: left;width:40%;border: 0px solid yellow; padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;overflow:hidden; max-width: 40%;height:15px;'>"));
                        ControlCollection controls2 = this.plhSplitAddress.Controls;
                        object[] objArray3 = new object[] { "<img src='../images/plus.gif' title='Add address' style='vertical-align: top;padding-left: 3px;cursor:pointer;' border='0' onclick=javascript:More_Address_split('", ItemNo, "_", i, "');return false; />&nbsp;" };
                        controls2.Add(new LiteralControl(string.Concat(objArray3)));
                        object[] itemNo4 = new object[] { "txtaddress_", ItemNo, "_", i };
                        label1.ID = string.Concat(itemNo4);
                        label1.Text = base.SpecialDecode(dataTable6.Rows[0]["Address1"].ToString());
                        this.hid_address_text.Value = dataTable6.Rows[0]["Address1"].ToString();
                        this.hid_thisaddressid.Value = dataTable6.Rows[0]["AddressID"].ToString();
                        this.plhSplitAddress.Controls.Add(label1);
                        ControlCollection controlCollections2 = this.plhSplitAddress.Controls;
                        object[] objArray4 = new object[] { "<span style='display: none' id='spnAddID_", ItemNo, "_", i, "'>", str4, "</span><span style='display: none' id='spnAddType_", ItemNo, "_", i, "'>", str5, "</span>" };
                        controlCollections2.Add(new LiteralControl(string.Concat(objArray4)));
                        this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
                    }
                }
                this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
                num = 0;
            }
            this.plhSplitAddress.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            this.plhSplitAddress.Controls.Add(new LiteralControl("</div>"));
            this.hdn_TotSplitAddress.Value = 0.ToString();
        }

        public void BindSplitAddress_consolidatewithsplit(int CompanyID, int ClientID, int ItemNo)
        {
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div class='only10px'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div class='only10px'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div id='div_ConRaise' align='left' style='width: 100%;display: none'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div align='left' style='width: 100%;'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<span class='HeaderText' style='font-size: 12px'>Raise Delivery Notes</span>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div class='only5px'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl(string.Concat("<div id='div_SplitContent_conswithsplit_", ItemNo, "' align='left' style='width: 100%;table-layout: fixed;border: 1px solid black;'>")));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div align='left' style='width: 100%;height: 20px;' class='bgcustomize navigatorpanel'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left; width: 6%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Sl_No")));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;width: 5px'>&nbsp;</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left; width: 36%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Item_Title")));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;width: 5px'>&nbsp;</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='text-align:right;float: left; width: 10%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), "&nbsp;")));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;width: 4%'>&nbsp;</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='width:35%;float: left; padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Address")));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            double num = 0;
            double num1 = 0;
            DataTable item = (DataTable)this.Session["dtSendToOtherPage"];
            string[] strArrays = this.hid_checkboxid.Value.Split(new char[] { '~' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (strArrays[i] != row["EstimateItemID"].ToString())
                    {
                        continue;
                    }
                    string str = "NewTableRow normalText";
                    this.plhconsolidate_split.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width: 100%;height: 20px;border:0px solid;clear: both;padding-bottom: 3px' class='", str, "'>")));
                    if (i != 0)
                    {
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div  style='float: left; width: 6%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl(""));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div  style='float: left; width: 6%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid'>"));
                        Label label = new Label();
                        object[] itemNo = new object[] { "splitslno_conswithsplit_", ItemNo, "_", i };
                        label.ID = string.Concat(itemNo);
                        label.Text = "1";
                        this.plhconsolidate_split.Controls.Add(label);
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;width: 5px'>&nbsp;</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='white-space: nowrap;overflow:hidden;float: left;width: 36%;max-width: 36%padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl(string.Concat("&nbsp;", row["ItemTitle"].ToString())));
                    multiple_delivery_note_new jobsMultipleDeliveryNoteNew = this;
                    jobsMultipleDeliveryNoteNew.JobItemTitle_conswithsplit_newrow = string.Concat(jobsMultipleDeliveryNoteNew.JobItemTitle_conswithsplit_newrow, row["ItemTitle"].ToString().Replace("\n", "").Replace("\r", ""), "~");
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;width: 5px'>&nbsp;</div>"));
                    DataTable dataTable = DeliveryBasePage.deliveryitem_select_splitdelivery(CompanyID, Convert.ToInt64(row["EstimateItemID"].ToString()), Convert.ToInt64(row["EstimateID"].ToString()), row["EstimateType"].ToString());
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        this.returnquantity = this.returnonlyquantity(dataRow["quantity"].ToString());
                        num = num + (double)Convert.ToInt32(this.returnquantity);
                    }
                    string str1 = (row["Quantity"].ToString() == "" ? Convert.ToString(0) : row["Quantity"].ToString());
                    num1 = Convert.ToDouble(str1) - Convert.ToDouble(num);
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='text-align:right;float: left;width: 10%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid'>"));
                    TextBox textBox = new TextBox();
                    object[] objArray = new object[] { "txtSplitQty_conswithsplit_", ItemNo, "_", i };
                    textBox.ID = string.Concat(objArray);
                    textBox.Width = 100;
                    textBox.SkinID = "textPad";
                    textBox.Style["TEXT-ALIGN"] = TextAlign.Right.ToString();
                    textBox.Text = this.CheckMinusAmount(num1.ToString());
                    textBox.AutoCompleteType = AutoCompleteType.Disabled;
                    textBox.MaxLength = 8;
                    textBox.Attributes.Add("onkeyup", "javascript:AllowNumber(this,this.value);");
                    AttributeCollection attributes = textBox.Attributes;
                    object[] quantity = new object[] { "javascript:ValidateQty(this,'", this.Quantity, "','", ItemNo, "',", i, ");" };
                    attributes.Add("onblur", string.Concat(quantity));
                    textBox.Attributes.Add("onfocus", "javascript:this.select()");
                    this.plhconsolidate_split.Controls.Add(textBox);
                    ControlCollection controls = this.plhconsolidate_split.Controls;
                    object[] itemNo1 = new object[] { "<span style='display: none' id='spnEstimateItemID_conswithsplit_", ItemNo, "_", i, "'>", row["EstimateItemID"].ToString(), "</span><span style='display: none' id='spnEstimateType_conswithsplit_", ItemNo, "_", i, "'>", row["EstimateType"].ToString(), "</span><span style='display: none' id='spnEstimateID_conswithsplit_", ItemNo, "_", i, "'>", row["EstimateID"].ToString(), "</span><span style='display: none' id='spnItemDesc_conswithsplit_", ItemNo, "_", i, "'>", row["ItemDescription"].ToString(), "</span>" };
                    controls.Add(new LiteralControl(string.Concat(itemNo1)));
                    HiddenField hidEstimateitemid = this.hid_estimateitemid;
                    hidEstimateitemid.Value = string.Concat(hidEstimateitemid.Value, row["EstimateItemID"].ToString(), "~");
                    HiddenField hidEstimateid = this.hid_estimateid;
                    hidEstimateid.Value = string.Concat(hidEstimateid.Value, row["EstimateID"].ToString(), "~");
                    HiddenField hidEstimatetype = this.hid_estimatetype;
                    hidEstimatetype.Value = string.Concat(hidEstimatetype.Value, row["EstimateType"].ToString(), "~");
                    HiddenField hidItemdescription = this.hid_itemdescription;
                    hidItemdescription.Value = string.Concat(hidItemdescription.Value, row["ItemDescription"].ToString(), "~");
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;width: 4%'>&nbsp;</div>"));
                    DataTable dataTable1 = CompanyBasePage.Delivery_Address_Select(CompanyID, this.EstimateID);
                    if (i != 0)
                    {
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left; width: 35%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;overflow:hidden; max-width: 35%;height:12px'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl(""));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    }
                    else if (dataTable1.Rows.Count > 0)
                    {
                        string str2 = dataTable1.Rows[0]["AddressID"].ToString();
                        string str3 = dataTable1.Rows[0]["AddressType"].ToString();
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;width:35%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;overflow:hidden; max-width: 35%;height:15px'>"));
                        ControlCollection controlCollections = this.plhconsolidate_split.Controls;
                        object[] objArray1 = new object[] { "<img src='../images/plus.gif' title='Add Address' style='vertical-align: top;padding-left: 5px;cursor:pointer;' onclick=javascript:More_Address_split('", ItemNo, "_", i, "');return false; />&nbsp;" };
                        controlCollections.Add(new LiteralControl(string.Concat(objArray1)));
                        Label label1 = new Label();
                        object[] itemNo2 = new object[] { "txtaddress_conswithsplit_", ItemNo, "_", i };
                        label1.ID = string.Concat(itemNo2);
                        label1.Text = base.SpecialDecode(dataTable1.Rows[0]["Address1"].ToString());
                        this.plhconsolidate_split.Controls.Add(label1);
                        ControlCollection controls1 = this.plhconsolidate_split.Controls;
                        object[] objArray2 = new object[] { "<span style='display: none' id='spnAddID_conswithsplit_", ItemNo, "_", i, "'>", str2, "</span><span style='display: none' id='spnAddType_conswithsplit_", ItemNo, "_", i, "'>", str3, "</span>" };
                        controls1.Add(new LiteralControl(string.Concat(objArray2)));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    num = 0;
                }
            }
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
        }

        private void BindSplitDelivery()
        {
            this.plhSplitItems.Controls.Add(new LiteralControl("<div align='left' style='width: 100%;border: 1px solid #A4A4A4'>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("<div align='left' style='width: 100%;height: 20px;' class='bgcustomize navigatorpanel'>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left; width: 35%;padding: 2 3 2 7px;vertical-align: middle;border-right:0px solid white'>"));
            DataTable dataTable = EstimatesBasePage.estimate_deliverynote_onitemid_selectall(this.CompanyID, this.EstimateID, (long)Convert.ToInt32(this.AryEsimateItemID[0].ToString()), this.AryEstimateType[0].ToString());
            int count = dataTable.Rows.Count;
            this.plhSplitItems.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Item_Title")));
            this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left; width: 15%;text-align:right ;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
            this.plhSplitItems.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " ", this.objLanguage.GetLanguageConversion("Ordered"), " &nbsp;")));
            this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left;width: 15%;text-align: right; padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
            this.plhSplitItems.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " ", this.objLanguage.GetLanguageConversion("Produced"), "&nbsp;")));
            this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left;width: 14px'>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("&nbsp;"));
            this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left;width: 14%;text-align: right; padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
            this.plhSplitItems.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " ", this.objLanguage.GetLanguageConversion("Delivered"))));
            this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left;width: 14%;text-align: right; padding: 2 3 2 3px;vertical-align: middle;'>"));
            this.plhSplitItems.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " ", this.objLanguage.GetLanguageConversion("Available"))));
            this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
            int num = 0;
            for (int i = 0; i < this.Items; i++)
            {
                long num1 = this.ItemTypeID(this.AryEstimateType[i].ToString(), Convert.ToInt64(this.AryEsimateItemID[i].ToString()));
                this.QtyNumber = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()));
                if (this.AryEstimateType[i].ToString() == "S" || this.AryEstimateType[i].ToString() == "L" || this.AryEstimateType[i].ToString() == "P" || this.AryEstimateType[i].ToString() == "B" || this.AryEstimateType[i].ToString() == "F" || this.AryEstimateType[i].ToString() == "D" || this.AryEstimateType[i].ToString() == "N" || this.AryEstimateType[i].ToString() == "R" || this.AryEstimateType[i].ToString() == "K" || this.AryEstimateType[i].ToString() == "C" || this.AryEstimateType[i].ToString() == "Q" || this.AryEstimateType[i].ToString().ToLower() == "x")
                {
                    DataTable dataTable1 = JobsBasePage.Job_Items_Quantity_Details_Select(this.CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), num1, this.AryEstimateType[i].ToString(), this.QtyNumber);
                    foreach (DataRow row in dataTable1.Rows)
                    {
                        this.Quantity = row["quantity"].ToString();
                        Convert.ToInt32(row["quantity"].ToString());
                    }
                    DataTable dataTable2 = DeliveryBasePage.deliveryitem_select_splitdelivery(this.CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), this.EstimateID, this.AryEstimateType[i].ToString());
                    foreach (DataRow dataRow in dataTable2.Rows)
                    {
                        this.returnquantity = this.returnonlyquantity(dataRow["quantity"].ToString());
                        multiple_delivery_note_new jobsMultipleDeliveryNoteNew = this;
                        jobsMultipleDeliveryNoteNew.deliveryquantity = jobsMultipleDeliveryNoteNew.deliveryquantity + Convert.ToInt32(this.returnquantity);
                    }
                }
                else if (this.AryEstimateType[i].ToString() == "O")
                {
                    foreach (DataRow row1 in EstimateBasePage.Estimate_Outwork_Quantity_Details_Select(this.CompanyID, num1, this.QtyNumber).Rows)
                    {
                        this.Quantity = row1["Quantity"].ToString();
                        Convert.ToInt32(row1["Quantity"].ToString());
                    }
                    DataTable dataTable3 = DeliveryBasePage.deliveryitem_select_splitdelivery(this.CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), this.EstimateID, this.AryEstimateType[i].ToString());
                    foreach (DataRow dataRow1 in dataTable3.Rows)
                    {
                        this.returnquantity = this.returnonlyquantity(dataRow1["quantity"].ToString());
                        multiple_delivery_note_new jobsMultipleDeliveryNoteNew1 = this;
                        jobsMultipleDeliveryNoteNew1.deliveryquantity = jobsMultipleDeliveryNoteNew1.deliveryquantity + Convert.ToInt32(this.returnquantity);
                    }
                }
                else if (this.AryEstimateType[i].ToString() == "U" || this.AryEstimateType[i].ToString() == "W")
                {
                    DataTable dataTable4 = EstimateBasePage.Estimate_OtherCost_Qty_Details_Select(this.CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), this.AryEstimateType[i].ToString());
                    foreach (DataRow row2 in dataTable4.Rows)
                    {
                        this.Quantity = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["Quantity"].ToString()), 0, "", true, false, true);
                        if (row2["Quantity"] == null)
                        {
                            continue;
                        }
                        Convert.ToInt32(row2["Quantity"]);
                    }
                    DataTable dataTable5 = DeliveryBasePage.deliveryitem_select_splitdelivery(this.CompanyID, Convert.ToInt64(this.AryEsimateItemID[i].ToString()), this.EstimateID, this.AryEstimateType[i].ToString());
                    foreach (DataRow dataRow2 in dataTable5.Rows)
                    {
                        this.returnquantity = this.returnonlyquantity(dataRow2["quantity"].ToString());
                        multiple_delivery_note_new num2 = this;
                        num2.deliveryquantity = num2.deliveryquantity + Convert.ToInt32(this.returnquantity);
                    }
                }
                this.Quantity = this.CheckMinusAmount(this.Quantity.ToString());
                int num3 = JobsBasePage.Job_DeliveryNote_QtyProduced_Select(this.CompanyID, this.EstimateID, (long)Convert.ToInt32(this.AryEsimateItemID[i].ToString()), this.AryEstimateType[i].ToString());
                num3 = (num3 == 0 ? Convert.ToInt32(this.Quantity) : num3);
                this.availablequanity = Convert.ToInt32(Math.Round(Convert.ToDouble(num3), 0)) - this.deliveryquantity;
                this.availablequanity = (this.availablequanity < 0 ? 0 : this.availablequanity);
                DataTable dataTable6 = this.ItemTitle(Convert.ToInt32(this.AryEsimateItemID[i].ToString()), this.AryEstimateType[i].ToString());
                foreach (DataRow row3 in dataTable6.Rows)
                {
                    this.JobItemTitle = row3["ItemTitle"].ToString();
                    this.ItemDescription = string.Concat(this.ItemDescription, row3["ItemDescription"], "±");
                    multiple_delivery_note_new jobsMultipleDeliveryNoteNew2 = this;
                    string str = jobsMultipleDeliveryNoteNew2.strItemTitle;
                    string[] jobItemTitle = new string[] { str, this.JobItemTitle, "±", this.AryEsimateItemID[i].ToString(), "µ" };
                    jobsMultipleDeliveryNoteNew2.strItemTitle = string.Concat(jobItemTitle);
                }
                string itemDescription = this.ItemDescription;
                char[] chrArray = new char[] { 'µ' };
                itemDescription.Split(chrArray)[0].Split(new char[] { '»' });
                string str1 = "NewTableRow normalText";
                str1 = (i % 2 != 0 ? "NewAlternative normalText" : "NewTableRow normalText");
                DataTable dataTable7 = EstimatesBasePage.estimate_deliverynote_onitemid_selectall(this.CompanyID, this.EstimateID, (long)Convert.ToInt32(this.AryEsimateItemID[i].ToString()), this.AryEstimateType[i].ToString());
                ControlCollection controls = this.plhSplitItems.Controls;
                object[] objArray = new object[] { "<div id='div_Item_", i, "' align='left' style='width: 100%;height: auto;clear: both' class='", str1, "' >" };
                controls.Add(new LiteralControl(string.Concat(objArray)));
                this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left; width: 35%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid'>"));
                if (dataTable7.Rows.Count <= 0)
                {
                }
                else
                {
                    num++;
                }
                this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float:left;padding-left: 2px; word-break: break-all;'>"));
                this.plhSplitItems.Controls.Add(new LiteralControl(base.SpecialDecode(this.JobItemTitle)));
                this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
                this.plhSplitItems.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
                this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 15%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid'>"));
                ControlCollection controlCollections = this.plhSplitItems.Controls;
                object[] quantity = new object[] { "<label id='lblqtyordered_", i, "'>", this.Quantity, "</label>" };
                controlCollections.Add(new LiteralControl(string.Concat(quantity)));
                this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
                this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left;text-align: right; width: 15%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;'>"));
                TextBox textBox = new TextBox()
                {
                    ID = string.Concat("txtQtyProduced_", i),
                    Width = 103,
                    SkinID = "textPad"
                };
                textBox.Style["TEXT-ALIGN"] = TextAlign.Right.ToString();
                textBox.Text = num3.ToString();
                textBox.AutoCompleteType = AutoCompleteType.Disabled;
                textBox.MaxLength = 8;
                textBox.Attributes.Add("onkeyup", "javascript:AllowNumber(this,this.value);");
                textBox.Attributes.Add("onkeypress", "javascript:AllowNumber(this,this.value);");
                AttributeCollection attributes = textBox.Attributes;
                object[] objArray1 = new object[] { "javascript:fillQtyProduced(this,'", i, "','", this.AryEsimateItemID[i].ToString(), "', '", this.AryEstimateType[i].ToString(), "','", this.Quantity, "')" };
                attributes.Add("onblur", string.Concat(objArray1));
                textBox.Attributes.Add("onfocus", "javascript:this.select()");
                this.plhSplitItems.Controls.Add(textBox);
                this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
                this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left;padding-top: 4px'>"));
                ControlCollection controls1 = this.plhSplitItems.Controls;
                object[] text = new object[] { "<img id='imgsplit_SaveQtyProduced_", i, "' src='../images/save.gif' title='Save' height='12px' width='12px' style='vertical-align: middle;padding-left: 2px;cursor: pointer' onclick=javascript:SaveQtyProduced('", i, "','", textBox.Text, "','", this.EstimateID.ToString(), "','", this.AryEsimateItemID[i].ToString(), "','", this.AryEstimateType[i].ToString(), "','split');return false; />&nbsp;" };
                controls1.Add(new LiteralControl(string.Concat(text)));
                this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
                HiddenField hiddenField = new HiddenField()
                {
                    ID = string.Concat("hdn_Split_QtyProd_EstItemID_", i),
                    Value = this.AryEsimateItemID[i].ToString()
                };
                this.plhSplitItems.Controls.Add(hiddenField);
                HiddenField hiddenField1 = new HiddenField()
                {
                    ID = string.Concat("hdn_Split_QtyProd_EstType_", i),
                    Value = this.AryEstimateType[i].ToString()
                };
                this.plhSplitItems.Controls.Add(hiddenField1);
                this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 14%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                ControlCollection controlCollections1 = this.plhSplitItems.Controls;
                object[] objArray2 = new object[] { "<label id='lblQtyDelivered_", i, "'>", this.deliveryquantity, "</label>" };
                controlCollections1.Add(new LiteralControl(string.Concat(objArray2)));
                this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
                this.plhSplitItems.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 14%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                ControlCollection controls2 = this.plhSplitItems.Controls;
                object[] objArray3 = new object[] { "<label id='lblSplitBalance_", i, "'>", this.availablequanity, "</label>" };
                controls2.Add(new LiteralControl(string.Concat(objArray3)));
                this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
                this.plhSplitItems.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
                this.ShowRaisedDeliveryNote(dataTable7, i, "split", this.plhSplitItems);
                this.deliveryquantity = 0;
                if (i == 0)
                {
                    this.BindSplitAddress(this.CompanyID, this.ClientID, i, this.availablequanity.ToString());
                }
                HiddenField hdnSplitQty = this.hdn_SplitQty;
                hdnSplitQty.Value = string.Concat(hdnSplitQty.Value, this.availablequanity.ToString(), "~");
            }
            this.plhSplitItems.Controls.Add(new LiteralControl("</div>"));
        }

        protected void btncancel_conswithsplit_Onclick(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] estimateID = new object[] { this.strSitepath, "jobs/multiple_delivery_note_new.aspx?page=job&Estid=", this.EstimateID, "&jID=", this.jobID };
            response.Redirect(string.Concat(estimateID));
        }

        protected void btncontinue_OnClick(object sender, EventArgs e)
        {
        }

        protected void btnprint_click(object sender, EventArgs e)
        {
            this.Session["boxlableaddress"] = this.hdn_PrintLabels.Value;
            ClientScriptManager clientScript = this.Page.ClientScript;
            if (this.ddlLabeltype.SelectedValue != "8")
            {
                this.div_Main.Style.Add("display", "none");
                this.div_Print.Style.Add("display", "none");
                this.div_iframe.Style.Add("display", "block");
                AttributeCollection attributes = this.iframe_Preview.Attributes;
                object[] value = new object[] { this.strSitepath, "printlayout_delivery.aspx?LR=", this.hid_labletype_rows.Value, "&LC=", this.hid_labletype_col.Value, "&SR=", this.hid_startrow.Value, "&SC=", this.hid_startcol.Value, "&nooflableonprintview=", this.txtNoOfLabels.Text, "&nooflables=", this.hid_nooflableonprintview.Value, "&maskcheck=", this.chkNumberingMask.Checked, "&prefix=", this.txtPrefix1.Text, "&suffix=", this.txtSuffix1.Text, "&maskstartval=", this.txtStart1.Text, "&noofitemperbox=", this.txtNoOfLeaves.Text, "&maskendval=", this.txtEnd1.Text };
                attributes.Add("src", string.Concat(value));
                return;
            }
            string empty = string.Empty;
            if (this.ServerName.ToLower() == "ppw")
            {
                empty = "ispw";
            }
            else if (this.ServerName.ToLower() == "mas")
            {
                empty = "ismp";
            }
            else if (this.ServerName.ToLower() == "printmonkey" || this.ServerName.ToLower() == "inki")
            {
                empty = "isop";
            }
            else if (this.ServerName.ToLower() == "studio1")
            {
                empty = "isstud";
            }
            else if (this.ServerName.ToLower() == "centurionprint")
            {
                empty = "iscp";
            }
            this.div_Main.Style.Add("display", "none");
            this.div_Print.Style.Add("display", "none");
            this.div_iframe.Style.Add("display", "block");
            AttributeCollection attributeCollection = this.iframe_Preview.Attributes;
            object[] objArray = new object[] { this.strSitepath, "printlayout_delivery.aspx?LR=", this.hid_labletype_rows.Value, "&LC=", this.hid_labletype_col.Value, "&SR=", this.hid_startrow.Value, "&SC=", this.hid_startcol.Value, "&nooflableonprintview=", this.txtNoOfLabels.Text, "&nooflables=", this.hid_nooflableonprintview.Value, "&maskcheck=", this.chkNumberingMask.Checked, "&prefix=", this.txtPrefix1.Text, "&suffix=", this.txtSuffix1.Text, "&maskstartval=", this.txtStart1.Text, "&noofitemperbox=", this.txtNoOfLeaves.Text, "&maskendval=", this.txtEnd1.Text, "&", empty, "=yes" };
            attributeCollection.Add("src", string.Concat(objArray));
        }

        protected void btnRaiseDeliveryNote_conswithsplit_OnClick(object sender, EventArgs e)
        {
            char[] chrArray;
            object[] estimateID;
            long num = (long)0;
            long num1 = (long)0;
            long num2 = (long)0;
            int num3 = 0;
            long num4 = (long)0;
            long num5 = (long)0;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            int num6 = 0;
            string str1 = string.Empty;
            if (this.hdn_SaveData_conswithsplit.Value != "")
            {
                string empty2 = string.Empty;
                if (this.hdn_con_raised_estimateids.Value != "")
                {
                    string str2 = string.Empty;
                    string value = this.hdn_con_raised_estimateids.Value;
                    chrArray = new char[] { '~' };
                    string[] strArrays = value.Split(chrArray);
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        string str3 = strArrays[i];
                        chrArray = new char[] { 'Ç' };
                        string[] strArrays1 = str3.Split(chrArray);
                        long num7 = Convert.ToInt64(strArrays1[0]);
                        IDataReader dataReader = JobBasePage.Jobs_Job_Details_select(this.CompanyID, num7);
                        while (dataReader.Read())
                        {
                            if (str2.Contains(dataReader["JobNumber"].ToString()))
                            {
                                continue;
                            }
                            str2 = string.Concat(str2, dataReader["JobNumber"].ToString(), ", ");
                        }
                    }
                    empty2 = str2.Remove(str2.Length - 2);
                }
                string value1 = this.hdn_SaveData_conswithsplit.Value;
                chrArray = new char[] { '~' };
                string[] strArrays2 = value1.Split(chrArray);
                string empty3 = string.Empty;
                if (this.hdn_consolidate_raise_type.Value.ToString().ToLower() == "split")
                {
                    for (int j = 0; j < (int)strArrays2.Length - 1; j++)
                    {
                        string str4 = strArrays2[j];
                        chrArray = new char[] { '±' };
                        string[] strArrays3 = str4.Split(chrArray);
                        for (int k = 0; k < (int)strArrays3.Length; k++)
                        {
                            string str5 = strArrays3[k];
                            chrArray = new char[] { 'Ç' };
                            string[] strArrays4 = str5.Split(chrArray);
                            string str6 = strArrays4[0].ToString();
                            string str7 = strArrays4[1].ToString();
                            if (str6 == "ItemNo")
                            {
                                num3 = Convert.ToInt32(str7);
                            }
                            if (str6 == "Quantity")
                            {
                                empty1 = str7;
                            }
                            if (str6 == "AddressID")
                            {
                                num6 = Convert.ToInt32(str7);
                            }
                            if (str6 == "AddressType")
                            {
                                str1 = str7;
                            }
                            if (str6 == "TotalItem")
                            {
                                Convert.ToInt32(str7);
                            }
                            if (str6 == "EstimateID")
                            {
                                num4 = Convert.ToInt64(str7);
                            }
                            if (str6 == "EstimateItemID")
                            {
                                num5 = Convert.ToInt64(str7);
                            }
                            if (str6 == "EstimateType")
                            {
                                empty = str7;
                            }
                            if (str6 == "ItemDescription")
                            {
                                str = str7;
                            }
                        }
                        string empty4 = string.Empty;
                        string empty5 = string.Empty;
                        string empty6 = string.Empty;
                        int jobStatusID = 0;
                        IDataReader dataReader1 = JobBasePage.Jobs_Job_Details_select(this.CompanyID, num4);
                        while (dataReader1.Read())
                        {
                            empty4 = dataReader1["DeliveryDate"].ToString();
                        }
                        empty4 = this.commclass.Eprint_return_Date_Before_View(empty4, this.CompanyID, int.Parse(this.Session["userid"].ToString()), false);
                        empty4 = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, empty4);
                        this.DeliveyDate = Convert.ToDateTime(empty4);
                        string str8 = SettingsBasePage.eprint_numbering(this.CompanyID, "D", ConnectionClass.IsHandy);
                        long num8 = (long)0;
                        int num9 = 0;
                        int num10 = 0;
                        string empty7 = string.Empty;
                        string empty8 = string.Empty;
                        jobStatusID = SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Note");
                        if (jobStatusID == 0)
                        {
                            jobStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                        }
                        string empty9 = string.Empty;
                        foreach (DataRow row in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                        {
                            empty9 = row["Comments"].ToString();
                        }
                        if (empty3 != num3.ToString())
                        {
                            num = DeliveryBasePage.delivery_insert((long)num10, this.CompanyID, num4, num8, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), (long)num6, str1, this.Footer, base.ReplaceSingleQuote(empty9), str8, this.DeliveyDate, base.ReplaceSingleQuote(empty2), this.OrderNo, false, num9, this.UserID, jobStatusID, DateTime.Now, this.UserID, (long)0, this.Header, this.TodayDate, this.ClientID, empty7, empty8, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix);
                            DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num, Convert.ToInt32(this.AccountingID));
                            this.Insert_ActivityHistory_DeliveryNote(num4, num, base.ReplaceSingleQuote(empty2), str8, this.CompanyID, this.UserID, num8);
                            this.Insert_ActivityHistory_for_DeliveryNote(num4, num, base.ReplaceSingleQuote(empty2), str8, this.CompanyID, this.UserID, num8);
                        }
                        empty3 = num3.ToString();
                        string str9 = string.Empty;
                        string pODN = string.Empty;
                        string empty10 = string.Empty;
                        pODN = this.commclass.ItemDescriptionToPO_DN(this.CompanyID, num5, "DeliveryNote", ref str9);
                        foreach (DataRow dataRow in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, num5, "X").Rows)
                        {
                            empty10 = dataRow["ItemTitle"].ToString();
                            pODN = (empty10 == "" ? string.Concat(empty10, "\n", pODN) : string.Concat("Job Name: ", empty10, "\n", pODN));
                        }
                        if (empty.ToLower() == "c" || empty.ToLower() == "x")
                        {
                            this.QtyNumber = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num5);
                            DataSet dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num5, this.QtyNumber, empty);
                            DataTable item = dataSet.Tables[0];
                            if (item.Rows.Count <= 0)
                            {
                                DeliveryBasePage.deliveryitem_insert(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(pODN), (long)1, "", (long)0);
                            }
                            else
                            {
                                foreach (DataRow row1 in item.Rows)
                                {
                                    long num11 = Convert.ToInt64(row1["PriceCatalogueID"]);
                                    DataTable dataTable = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num11);
                                    if (dataTable.Rows.Count <= 0)
                                    {
                                        DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(pODN), num11);
                                    }
                                    else if (dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                    {
                                        DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(pODN), num11);
                                    }
                                    else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                    {
                                        DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(pODN), num11);
                                    }
                                    else if (dataTable.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                    {
                                        DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(pODN), num11);
                                    }
                                    else
                                    {
                                        foreach (DataRow dataRow1 in PurchaseBasePage.Kit_Details(num11).Rows)
                                        {
                                            int num12 = Convert.ToInt16(empty1) * Convert.ToInt16(dataRow1["Quantity"]);
                                            string str10 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(dataRow1["KitItemID"])).Replace("»", "\n");
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(num12.ToString()), base.ReplaceSingleQuote(str10), Convert.ToInt64(dataRow1["KitItemID"].ToString()));
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            DeliveryBasePage.deliveryitem_insert(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(pODN), (long)1, "", (long)0);
                        }
                        EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num5, num, "DeliveryNote");
                    }
                    if (this.hdn_conQtyProduced.Value != "")
                    {
                        string str11 = this.hdn_conQtyProduced.Value.ToString();
                        chrArray = new char[] { 'µ' };
                        string[] strArrays5 = str11.Split(chrArray);
                        for (int l = 0; l < (int)strArrays5.Length - 1; l++)
                        {
                            string str12 = strArrays5[l];
                            chrArray = new char[] { '±' };
                            string[] strArrays6 = str12.Split(chrArray);
                            int num13 = Convert.ToInt32(strArrays6[0]);
                            long num14 = Convert.ToInt64(strArrays6[1]);
                            long num15 = Convert.ToInt64(strArrays6[2]);
                            string str13 = strArrays6[3].ToString();
                            JobsBasePage.Job_DeliveryNote_QtyProduced_Update(this.CompanyID, num14, num15, str13, num13);
                        }
                    }
                }
                else if (this.hdn_consolidate_raise_type.Value.ToLower() == "single")
                {
                    string empty11 = string.Empty;
                    string empty12 = string.Empty;
                    int defaultStatusID = 0;
                    IDataReader dataReader2 = JobBasePage.Jobs_Job_Details_select(this.CompanyID, this.EstimateID);
                    while (dataReader2.Read())
                    {
                        empty11 = dataReader2["DeliveryDate"].ToString();
                    }
                    empty11 = this.commclass.Eprint_return_Date_Before_View(empty11, this.CompanyID, int.Parse(this.Session["userid"].ToString()), false);
                    empty11 = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, empty11);
                    this.DeliveyDate = Convert.ToDateTime(empty11);
                    string str14 = SettingsBasePage.eprint_numbering(this.CompanyID, "D", ConnectionClass.IsHandy);
                    long num16 = (long)0;
                    int num17 = 0;
                    int num18 = 0;
                    string empty13 = string.Empty;
                    string empty14 = string.Empty;
                    defaultStatusID = SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Note");
                    if (defaultStatusID == 0)
                    {
                        defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                    }
                    string empty15 = string.Empty;
                    foreach (DataRow row2 in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                    {
                        empty15 = row2["Comments"].ToString();
                    }
                    num6 = (this.hdn_con_single_addressid.Value == "0" ? 0 : Convert.ToInt32(this.hdn_con_single_addressid.Value));
                    str1 = (this.hdn_con_single_addresstype.Value == "" ? "" : this.hdn_con_single_addresstype.Value);
                    num = DeliveryBasePage.delivery_insert((long)num18, this.CompanyID, this.EstimateID, num16, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), (long)num6, str1, this.Footer, base.ReplaceSingleQuote(empty15), str14, this.DeliveyDate, base.ReplaceSingleQuote(empty2), this.OrderNo, false, num17, this.UserID, defaultStatusID, DateTime.Now, this.UserID, num1, this.Header, this.TodayDate, this.ClientID, empty13, empty14, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix);
                    DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num, Convert.ToInt32(this.AccountingID));
                    this.Insert_ActivityHistory_DeliveryNote(this.EstimateID, num, base.ReplaceSingleQuote(empty2), str14, this.CompanyID, this.UserID, num16);
                    this.Insert_ActivityHistory_for_DeliveryNote(this.EstimateID, num, base.ReplaceSingleQuote(empty2), str14, this.CompanyID, this.UserID, num16);
                    for (int m = 0; m < (int)strArrays2.Length - 1; m++)
                    {
                        string str15 = strArrays2[m];
                        chrArray = new char[] { '±' };
                        string[] strArrays7 = str15.Split(chrArray);
                        for (int n = 0; n < (int)strArrays7.Length; n++)
                        {
                            string str16 = strArrays7[n];
                            chrArray = new char[] { 'Ç' };
                            string[] strArrays8 = str16.Split(chrArray);
                            string str17 = strArrays8[0].ToString();
                            string str18 = strArrays8[1].ToString();
                            if (str17 == "ItemNo")
                            {
                                num3 = Convert.ToInt32(str18);
                            }
                            if (str17 == "Quantity")
                            {
                                empty1 = str18;
                            }
                            if (str17 == "TotalItem")
                            {
                                Convert.ToInt32(str18);
                            }
                            if (str17 == "EstimateID")
                            {
                                num4 = Convert.ToInt64(str18);
                            }
                            if (str17 == "EstimateItemID")
                            {
                                num5 = Convert.ToInt64(str18);
                            }
                            if (str17 == "EstimateType")
                            {
                                empty = str18;
                            }
                            if (str17 == "ItemDescription")
                            {
                                str = str18;
                            }
                        }
                        string empty16 = string.Empty;
                        string empty17 = string.Empty;
                        if (str.ToString() != "")
                        {
                            empty16 = SummaryClass.Split_ItemDescription(str);
                        }
                        foreach (DataRow dataRow2 in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, num5, "X").Rows)
                        {
                            empty17 = dataRow2["ItemTitle"].ToString();
                            empty16 = (empty17 == "" ? string.Concat(empty17, "\n", empty16) : string.Concat("Job Name: ", empty17, "\n", empty16));
                        }
                        if (empty.ToLower() == "c" || empty.ToLower() == "x")
                        {
                            this.QtyNumber = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num5);
                            DataSet dataSet1 = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num5, this.QtyNumber, empty);
                            DataTable item1 = dataSet1.Tables[0];
                            if (item1.Rows.Count <= 0)
                            {
                                DeliveryBasePage.deliveryitem_insert(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(empty16), (long)1, "", (long)0);
                            }
                            else
                            {
                                foreach (DataRow row3 in item1.Rows)
                                {
                                    long num19 = Convert.ToInt64(row3["PriceCatalogueID"]);
                                    DataTable dataTable1 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num19);
                                    if (dataTable1.Rows.Count <= 0)
                                    {
                                        DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(empty16), num19);
                                    }
                                    else if (dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                    {
                                        DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(empty16), num19);
                                    }
                                    else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                    {
                                        DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(empty16), num19);
                                    }
                                    else if (dataTable1.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                    {
                                        DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(empty16), num19);
                                    }
                                    else
                                    {
                                        foreach (DataRow dataRow3 in PurchaseBasePage.Kit_Details(num19).Rows)
                                        {
                                            int num20 = Convert.ToInt16(empty1) * Convert.ToInt16(dataRow3["Quantity"]);
                                            string str19 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(dataRow3["KitItemID"])).Replace("»", "\n");
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(num20.ToString()), base.ReplaceSingleQuote(str19), Convert.ToInt64(dataRow3["KitItemID"].ToString()));
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            DeliveryBasePage.deliveryitem_insert(this.CompanyID, num2, num, num4, num5, empty, base.ReplaceSingleQuote(empty1), base.ReplaceSingleQuote(empty16), (long)1, "", (long)0);
                        }
                        EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num5, num, "DeliveryNote");
                    }
                    if (this.hdn_conQtyProduced.Value != "")
                    {
                        string str20 = this.hdn_conQtyProduced.Value.ToString();
                        chrArray = new char[] { 'µ' };
                        string[] strArrays9 = str20.Split(chrArray);
                        for (int o = 0; o < (int)strArrays9.Length - 1; o++)
                        {
                            string str21 = strArrays9[o];
                            chrArray = new char[] { '±' };
                            string[] strArrays10 = str21.Split(chrArray);
                            int num21 = Convert.ToInt32(strArrays10[0]);
                            long num22 = Convert.ToInt64(strArrays10[1]);
                            long num23 = Convert.ToInt64(strArrays10[2]);
                            string str22 = strArrays10[3].ToString();
                            JobsBasePage.Job_DeliveryNote_QtyProduced_Update(this.CompanyID, num22, num23, str22, num21);
                        }
                    }
                }
            }
            this.Session["dtSendToOtherPage"] = null;
            string str23 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
            string empty18 = string.Empty;
            if (str23.ToLower() != "yes")
            {
                estimateID = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", this.EstimateID, "&jID=", this.jobID };
                empty18 = string.Concat(estimateID);
            }
            else
            {
                estimateID = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?ordid=", this.OrderID, "&estid=", this.EstimateID, "&jID=", this.jobID };
                empty18 = string.Concat(estimateID);
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:windowclose('", empty18, "');"), true);
        }

        protected void btnRaiseDeliveryNote_OnClick(object sender, EventArgs e)
        {
            char[] chrArray;
            object[] estimateID;
            this.hdn_DeliveryNoteType.Value = (this.hdn_DeliveryNoteType.Value.ToLower() == "single" ? "split" : this.hdn_DeliveryNoteType.Value.ToLower());
            string empty = string.Empty;
            string str = string.Empty;
            if (this.hdn_SaveData.Value != "")
            {
                if (this.hdn_DeliveryNoteType.Value.ToLower() == "single")
                {
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    int defaultStatusID = 0;
                    string jobid = base.Request.Params["jID"].ToString();
                    IDataReader dataReader = JobBasePage.Jobs_Job_Details_select(this.CompanyID, this.EstimateID);
                    while (dataReader.Read())
                    {
                        if ((dataReader["JobID"].ToString()) == jobid)
                        {
                            empty1 = dataReader["DeliveryDate"].ToString();
                            str1 = dataReader["JobNumber"].ToString();
                        }
                    }
                    defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                    empty1 = this.commclass.Eprint_return_Date_Before_View(empty1, this.CompanyID, int.Parse(this.Session["userid"].ToString()), false);
                    empty1 = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, empty1);
                    this.DeliveyDate = Convert.ToDateTime(empty1);
                    string str2 = SettingsBasePage.eprint_numbering(this.CompanyID, "D", ConnectionClass.IsHandy);
                    long num = (long)0;
                    long num1 = (long)0;
                    int num2 = 0;
                    int num3 = 0;
                    long num4 = (long)0;
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    string str3 = string.Empty;
                    foreach (DataRow row in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                    {
                        str3 = row["Comments"].ToString();
                    }
                    this.EstDelAddressID = (this.hid_thisaddressid.Value == "0" ? this.EstDelAddressID : Convert.ToInt64(this.hid_thisaddressid.Value));
                    this.EstDelAddressType = (this.hid_thisaddressid.Value == "0" ? this.EstDelAddressType : this.hid_thisaddresstype.Value);
                    num = DeliveryBasePage.delivery_insert((long)num3, this.CompanyID, this.EstimateID, num1, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), this.EstDelAddressID, this.EstDelAddressType, base.ReplaceSingleQuote(this.Footer), base.ReplaceSingleQuote(str3), str2, this.DeliveyDate, base.ReplaceSingleQuote(str1), this.OrderNo, false, num2, this.UserID, defaultStatusID, DateTime.Now, this.UserID, (long)0, base.ReplaceSingleQuote(this.Header), this.TodayDate, this.ClientID, empty2, empty3, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix);
                    DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num, Convert.ToInt32(this.AccountingID));
                    EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num1, num, "DeliveryNote");
                    this.Insert_ActivityHistory_DeliveryNote(this.EstimateID, num, base.ReplaceSingleQuote(str1), str2, this.CompanyID, this.UserID, num1);
                    this.Insert_ActivityHistory_for_DeliveryNote(this.EstimateID, num, base.ReplaceSingleQuote(str1), str2, this.CompanyID, this.UserID, num1);
                    if (this.hdn_SaveData.Value != "")
                    {
                        string value = this.hdn_SaveData.Value;
                        chrArray = new char[] { '~' };
                        this.strSingleDelQty = value.Split(chrArray);
                        for (int i = 0; i < (int)this.strSingleDelQty.Length - 1; i++)
                        {
                            long num5 = (long)0;
                            string empty4 = string.Empty;
                            int num6 = 0;
                            string str4 = string.Empty;
                            string empty5 = string.Empty;
                            string str5 = string.Empty;
                            string str6 = this.strSingleDelQty[i];
                            chrArray = new char[] { '±' };
                            string[] strArrays = str6.Split(chrArray);
                            for (int j = 0; j < (int)strArrays.Length; j++)
                            {
                                string str7 = strArrays[j];
                                chrArray = new char[] { 'Ç' };
                                string[] strArrays1 = str7.Split(chrArray);
                                string str8 = strArrays1[0].ToString();
                                string str9 = strArrays1[1].ToString();
                                if (str8 == "ItemNo")
                                {
                                    Convert.ToInt32(str9);
                                }
                                if (str8 == "Quantity")
                                {
                                    str4 = str9;
                                }
                                if (str8 == "AddressID")
                                {
                                    Convert.ToInt32(str9);
                                }
                                if (str8 == "TotalItem")
                                {
                                    Convert.ToInt32(str9);
                                }
                                if (str8 == "EstimateID")
                                {
                                    Convert.ToInt64(str9);
                                }
                                if (str8 == "EstimateItemID")
                                {
                                    num5 = Convert.ToInt64(str9);
                                }
                                if (str8 == "EstimateType")
                                {
                                    empty4 = str9;
                                }
                            }
                            string pODN = string.Empty;
                            pODN = this.commclass.ItemDescriptionToPO_DN(this.CompanyID, num5, "DeliveryNote", ref str);
                            string empty6 = string.Empty;
                            foreach (DataRow dataRow in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, num5, "X").Rows)
                            {
                                empty6 = dataRow["ItemTitle"].ToString();
                                pODN = (empty6 == "" ? string.Concat(empty6, "\n", pODN) : string.Concat("Job Name: ", empty6, "\n", pODN));
                            }
                            if (str4 != "0")
                            {
                                if (empty4.ToLower() == "c" || empty4.ToLower() == "x")
                                {
                                    num6 = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num5);
                                    DataSet dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num5, num6, empty4);
                                    DataTable item = dataSet.Tables[0];
                                    if (item.Rows.Count <= 0)
                                    {
                                        DeliveryBasePage.deliveryitem_insert(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), (long)1, "", (long)0);
                                    }
                                    else
                                    {
                                        foreach (DataRow row1 in item.Rows)
                                        {
                                            long num7 = Convert.ToInt64(row1["PriceCatalogueID"]);
                                            DataTable dataTable = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num7);
                                            if (dataTable.Rows.Count <= 0)
                                            {
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), num7);
                                            }
                                            else if (dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                            {
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), num7);
                                            }
                                            else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                            {
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), num7);
                                            }
                                            else if (dataTable.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                            {
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), num7);
                                            }
                                            else
                                            {
                                                foreach (DataRow dataRow1 in PurchaseBasePage.Kit_Details(num7).Rows)
                                                {
                                                    int num8 = Convert.ToInt16(str4) * Convert.ToInt16(dataRow1["Quantity"]);
                                                    string str10 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(dataRow1["KitItemID"])).Replace("»", "\n");
                                                    DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(num8.ToString()), base.ReplaceSingleQuote(str10), Convert.ToInt64(dataRow1["KitItemID"].ToString()));
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    DeliveryBasePage.deliveryitem_insert(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), (long)1, "", (long)0);
                                }
                            }
                        }
                        if (this.hdn_splitQtyProduced.Value != "")
                        {
                            string str11 = this.hdn_splitQtyProduced.Value.ToString();
                            chrArray = new char[] { 'µ' };
                            string[] strArrays2 = str11.Split(chrArray);
                            for (int k = 0; k < (int)strArrays2.Length - 1; k++)
                            {
                                string str12 = strArrays2[k];
                                chrArray = new char[] { '±' };
                                string[] strArrays3 = str12.Split(chrArray);
                                int num9 = Convert.ToInt32(strArrays3[0]);
                                long num10 = Convert.ToInt64(strArrays3[1]);
                                string str13 = strArrays3[2].ToString();
                                JobsBasePage.Job_DeliveryNote_QtyProduced_Update(this.CompanyID, this.EstimateID, num10, str13, num9);
                            }
                        }
                    }
                }
                else if (this.hdn_DeliveryNoteType.Value.ToLower() == "split")
                {
                    long num11 = (long)0;
                    long num12 = (long)0;
                    long num13 = (long)0;
                    int num14 = 0;
                    string empty7 = string.Empty;
                    int num15 = 0;
                    string empty8 = string.Empty;
                    long num16 = (long)0;
                    string empty9 = string.Empty;
                    string empty10 = string.Empty;
                    if (this.hdn_SaveData.Value != "")
                    {
                        string value1 = this.hdn_SaveData.Value;
                        chrArray = new char[] { '~' };
                        string[] strArrays4 = value1.Split(chrArray);
                        string empty11 = string.Empty;
                        for (int l = 0; l < (int)strArrays4.Length - 1; l++)
                        {
                            string str14 = strArrays4[l];
                            chrArray = new char[] { '±' };
                            string[] strArrays5 = str14.Split(chrArray);
                            for (int m = 0; m < (int)strArrays5.Length; m++)
                            {
                                string str15 = strArrays5[m];
                                chrArray = new char[] { 'Ç' };
                                string[] strArrays6 = str15.Split(chrArray);
                                string str16 = strArrays6[0].ToString();
                                string str17 = strArrays6[1].ToString();
                                if (str16 == "ItemNo")
                                {
                                    num14 = Convert.ToInt32(str17);
                                }
                                if (str16 == "Quantity")
                                {
                                    empty7 = str17;
                                }
                                if (str16 == "AddressID")
                                {
                                    num15 = Convert.ToInt32(str17);
                                }
                                if (str16 == "AddressType")
                                {
                                    empty8 = str17;
                                }
                                if (str16 == "TotalItem")
                                {
                                    Convert.ToInt32(str17);
                                }
                                if (str16 == "EstimateID")
                                {
                                    Convert.ToInt64(str17);
                                }
                                if (str16 == "EstimateItemID")
                                {
                                    num16 = Convert.ToInt64(str17);
                                }
                                if (str16 == "EstimateType")
                                {
                                    empty9 = str17;
                                }
                            }
                            
                            string jobid = base.Request.Params["jID"].ToString();
                            string empty12 = string.Empty;
                            string empty13 = string.Empty;
                            int jobStatusID = 0;
                            IDataReader dataReader1 = JobBasePage.Jobs_Job_Details_select(this.CompanyID, this.EstimateID);
                            while (dataReader1.Read())
                            {
                                if ((dataReader1["JobID"].ToString()) == jobid)
                                {
                                    empty12 = dataReader1["DeliveryDate"].ToString();
                                    empty13 = dataReader1["JobNumber"].ToString();
                                }

                            }
                            empty12 = this.commclass.Eprint_return_Date_Before_View(empty12, this.CompanyID, int.Parse(this.Session["userid"].ToString()), false);
                            empty12 = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, empty12);
                            this.DeliveyDate = Convert.ToDateTime(empty12);
                            string str18 = SettingsBasePage.eprint_numbering(this.CompanyID, "D", ConnectionClass.IsHandy);
                            long num17 = (long)0;
                            int num18 = 0;
                            int num19 = 0;
                            string empty14 = string.Empty;
                            string empty15 = string.Empty;
                            jobStatusID = SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Note");
                            if (jobStatusID == 0)
                            {
                                jobStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                            }
                            string empty16 = string.Empty;
                            foreach (DataRow row2 in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                            {
                                empty16 = row2["Comments"].ToString();
                            }
                            if (empty11 != num14.ToString())
                            {
                                num11 = (this.OrderID != (long)0 ? DeliveryBasePage.delivery_insert ((long)num19, this.CompanyID, this.EstimateID, num17, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), (long)num15, empty8, this.Footer, base.ReplaceSingleQuote(empty16), str18, this.DeliveyDate, base.ReplaceSingleQuote(empty13), this.CustomerOrderNo, false, num18, this.UserID, jobStatusID, DateTime.Now, this.UserID, num12, this.Header, this.TodayDate, this.ClientID, empty14, empty15, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix) : DeliveryBasePage.delivery_insert((long)num19, this.CompanyID, this.EstimateID, num17, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), (long)num15, empty8, this.Footer, base.ReplaceSingleQuote(empty16), str18, this.DeliveyDate, base.ReplaceSingleQuote(empty13), this.OrderNo, false, num18, this.UserID, jobStatusID, DateTime.Now, this.UserID, num12, this.Header, this.TodayDate, this.ClientID, empty14, empty15, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix));
                                DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num11, Convert.ToInt32(this.AccountingID));
                                foreach (DataRow dataRow2 in EstimatesBasePage.Estimate_Item_ID_Select(this.CompanyID, this.EstimateID).Rows)
                                {
                                    this.Insert_ActivityHistory_DeliveryNote(this.jobID, num11, base.ReplaceSingleQuote(empty13), str18, this.CompanyID, this.UserID, Convert.ToInt64(dataRow2["EstimateItemID"].ToString()));
                                }
                                this.Insert_ActivityHistory_for_DeliveryNote(this.jobID, num11, base.ReplaceSingleQuote(empty13), str18, this.CompanyID, this.UserID, (long)0);
                            }
                            empty11 = num14.ToString();
                            string pODN1 = string.Empty;
                            string empty17 = string.Empty;
                            pODN1 = this.commclass.ItemDescriptionToPO_DN(this.CompanyID, num16, "DeliveryNote", ref str);
                            foreach (DataRow row3 in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, num16, "X").Rows)
                            {
                                empty17 = row3["ItemTitle"].ToString();
                                pODN1 = (empty17 == "" ? string.Concat(row3["ItemTitle"], "\n", pODN1) : string.Concat("Job Name: ", empty17, "\n", pODN1));
                            }
                            if (empty9.ToLower() == "c" || empty9.ToLower() == "x")
                            {
                                this.QtyNumber = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num16);
                                DataSet dataSet1 = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num16, this.QtyNumber, empty9);
                                DataTable item1 = dataSet1.Tables[0];
                                if (item1.Rows.Count <= 0)
                                {
                                    DeliveryBasePage.deliveryitem_insert(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), (long)1, "", (long)0);
                                }
                                else
                                {
                                    foreach (DataRow dataRow3 in item1.Rows)
                                    {
                                        long num20 = Convert.ToInt64(dataRow3["PriceCatalogueID"]);
                                        DataTable dataTable1 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num20);
                                        if (dataTable1.Rows.Count <= 0)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), num20);
                                        }
                                        else if (dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), num20);
                                        }
                                        else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), num20);
                                        }
                                        else if (dataTable1.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), num20);
                                        }
                                        else
                                        {
                                            foreach (DataRow row4 in PurchaseBasePage.Kit_Details(num20).Rows)
                                            {
                                                int num21 = Convert.ToInt16(empty7) * Convert.ToInt16(row4["Quantity"]);
                                                string str19 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(row4["KitItemID"])).Replace("»", "\n");
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(num21.ToString()), base.ReplaceSingleQuote(str19), Convert.ToInt64(row4["KitItemID"].ToString()));
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DeliveryBasePage.deliveryitem_insert(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), (long)1, "", (long)0);
                            }
                            EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num16, num11, "DeliveryNote");
                        }
                        if (this.hdn_splitQtyProduced.Value != "")
                        {
                            string str20 = this.hdn_splitQtyProduced.Value.ToString();
                            chrArray = new char[] { 'µ' };
                            string[] strArrays7 = str20.Split(chrArray);
                            for (int n = 0; n < (int)strArrays7.Length - 1; n++)
                            {
                                string str21 = strArrays7[n];
                                chrArray = new char[] { '±' };
                                string[] strArrays8 = str21.Split(chrArray);
                                int num22 = Convert.ToInt32(strArrays8[0]);
                                long num23 = Convert.ToInt64(strArrays8[1]);
                                string str22 = strArrays8[2].ToString();
                                JobsBasePage.Job_DeliveryNote_QtyProduced_Update(this.CompanyID, this.EstimateID, num23, str22, num22);
                            }
                        }
                    }
                }
                else if (this.hdn_DeliveryNoteType.Value.ToLower() == "consolidate")
                {
                    long num24 = (long)0;
                    long num25 = (long)0;
                    long num26 = (long)0;
                    string empty18 = string.Empty;
                    string empty19 = string.Empty;
                    long num27 = (long)0;
                    long num28 = (long)0;
                    string empty20 = string.Empty;
                    string empty21 = string.Empty;
                    if (this.hdn_SaveData.Value != "")
                    {
                        string empty22 = string.Empty;
                        string empty23 = string.Empty;
                        int defaultStatusID1 = 0;
                        IDataReader dataReader2 = JobBasePage.Jobs_Job_Details_select(this.CompanyID, this.EstimateID);
                        while (dataReader2.Read())
                        {
                            empty22 = dataReader2["DeliveryDate"].ToString();
                            empty23 = dataReader2["JobNumber"].ToString();
                        }
                        defaultStatusID1 = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                        empty22 = this.commclass.Eprint_return_Date_Before_View(empty22, this.CompanyID, int.Parse(this.Session["userid"].ToString()), false);
                        empty22 = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, empty22);
                        this.DeliveyDate = Convert.ToDateTime(empty22);
                        string str23 = SettingsBasePage.eprint_numbering(this.CompanyID, "D", ConnectionClass.IsHandy);
                        long num29 = (long)0;
                        int num30 = 0;
                        int num31 = 0;
                        string empty24 = string.Empty;
                        string str24 = string.Empty;
                        string empty25 = string.Empty;
                        foreach (DataRow dataRow4 in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                        {
                            empty25 = dataRow4["Comments"].ToString();
                        }
                        string value2 = this.hdn_SaveData.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays9 = value2.Split(chrArray);
                        for (int o = 0; o < (int)strArrays9.Length - 1; o++)
                        {
                            string str25 = strArrays9[o];
                            chrArray = new char[] { '±' };
                            string[] strArrays10 = str25.Split(chrArray);
                            for (int p = 0; p < (int)strArrays10.Length; p++)
                            {
                                string str26 = strArrays10[p];
                                chrArray = new char[] { '»' };
                                string[] strArrays11 = str26.Split(chrArray);
                                string str27 = strArrays11[0].ToString();
                                string str28 = strArrays11[1].ToString();
                                if (str27 == "EstID")
                                {
                                    num27 = Convert.ToInt64(str28);
                                }
                                if (str27 == "EstItemID")
                                {
                                    num28 = Convert.ToInt64(str28);
                                }
                                if (str27 == "EstType")
                                {
                                    empty20 = str28;
                                }
                                if (str27 == "Description")
                                {
                                    empty21 = str28;
                                }
                                if (str27 == "Qty")
                                {
                                    empty18 = str28;
                                }
                            }
                            if (o == 0)
                            {
                                num24 = DeliveryBasePage.delivery_insert((long)num31, this.CompanyID, this.EstimateID, num29, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), this.EstDelAddressID, this.EstDelAddressType, this.Footer, base.ReplaceSingleQuote(empty25), str23, this.DeliveyDate, base.ReplaceSingleQuote(empty23), this.OrderNo, false, num30, this.UserID, defaultStatusID1, DateTime.Now, this.UserID, num25, this.Header, this.TodayDate, this.ClientID, empty24, str24, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix);
                                DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num24, Convert.ToInt32(this.AccountingID));
                                EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num29, num24, "DeliveryNote");
                                this.Insert_ActivityHistory_DeliveryNote(this.EstimateID, num24, base.ReplaceSingleQuote(empty23), str23, this.CompanyID, this.UserID, num29);
                                this.Insert_ActivityHistory_for_DeliveryNote(this.EstimateID, num24, base.ReplaceSingleQuote(empty23), str23, this.CompanyID, this.UserID, num29);
                            }
                            if (empty20.ToLower() == "c" || empty20.ToLower() == "x")
                            {
                                this.QtyNumber = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num28);
                                DataSet dataSet2 = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num28, this.QtyNumber, empty20);
                                DataTable item2 = dataSet2.Tables[0];
                                if (item2.Rows.Count <= 0)
                                {
                                    DeliveryBasePage.deliveryitem_insert(this.CompanyID, num26, num24, num27, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), (long)1, "", (long)0);
                                }
                                else
                                {
                                    foreach (DataRow row5 in item2.Rows)
                                    {
                                        long num32 = Convert.ToInt64(row5["PriceCatalogueID"]);
                                        DataTable dataTable2 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num32);
                                        if (dataTable2.Rows.Count <= 0)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, num27, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), num32);
                                        }
                                        else if (dataTable2.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, num27, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), num32);
                                        }
                                        else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, num27, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), num32);
                                        }
                                        else if (dataTable2.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, num27, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), num32);
                                        }
                                        else
                                        {
                                            foreach (DataRow dataRow5 in PurchaseBasePage.Kit_Details(num32).Rows)
                                            {
                                                int num33 = Convert.ToInt16(empty18) * Convert.ToInt16(dataRow5["Quantity"]);
                                                string str29 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(dataRow5["KitItemID"])).Replace("»", "\n");
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, num27, num28, empty20, base.ReplaceSingleQuote(num33.ToString()), base.ReplaceSingleQuote(str29), Convert.ToInt64(dataRow5["KitItemID"].ToString()));
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DeliveryBasePage.deliveryitem_insert(this.CompanyID, num26, num24, num27, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), (long)1, "", (long)0);
                            }
                            EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num28, num24, "DeliveryNote");
                        }
                    }
                }
                string str30 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
                string empty26 = string.Empty;
                if (str30.ToLower() != "yes")
                {
                    estimateID = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", this.EstimateID, "&jID=", this.jobID };
                    empty26 = string.Concat(estimateID);
                }
                else
                {
                    estimateID = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&jID=", this.jobID };
                    empty26 = string.Concat(estimateID);
                }
                this.deliveryNoteRedirect = empty26;
                this.pnlCloseWindow.Visible = true;
            }
        }

        protected void btnRaiseDeliveryNoteSaveStay_OnClick(object sender, EventArgs e)
        {
            char[] chrArray;
            this.hdn_DeliveryNoteType.Value = (this.hdn_DeliveryNoteType.Value.ToLower() == "single" ? "split" : this.hdn_DeliveryNoteType.Value.ToLower());
            string empty = string.Empty;
            string str = string.Empty;
            if (this.hdn_SaveData.Value != "")
            {
                if (this.hdn_DeliveryNoteType.Value.ToLower() == "single")
                {
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    int defaultStatusID = 0;
                    string jobid = base.Request.Params["jID"].ToString();
                    IDataReader dataReader = JobBasePage.Jobs_Job_Details_select(this.CompanyID, this.EstimateID);
                    while (dataReader.Read())
                    {
                        if ((dataReader["JobID"].ToString()) == jobid)
                        {
                            empty1 = dataReader["DeliveryDate"].ToString();
                            str1 = dataReader["JobNumber"].ToString();
                        }
                    }
                    defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                    empty1 = this.commclass.Eprint_return_Date_Before_View(empty1, this.CompanyID, int.Parse(this.Session["userid"].ToString()), false);
                    empty1 = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, empty1);
                    this.DeliveyDate = Convert.ToDateTime(empty1);
                    string str2 = SettingsBasePage.eprint_numbering(this.CompanyID, "D", ConnectionClass.IsHandy);
                    long num = (long)0;
                    long num1 = (long)0;
                    int num2 = 0;
                    int num3 = 0;
                    long num4 = (long)0;
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    string str3 = string.Empty;
                    foreach (DataRow row in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                    {
                        str3 = row["Comments"].ToString();
                    }
                    this.EstDelAddressID = (this.hid_thisaddressid.Value == "0" ? this.EstDelAddressID : Convert.ToInt64(this.hid_thisaddressid.Value));
                    this.EstDelAddressType = (this.hid_thisaddressid.Value == "0" ? this.EstDelAddressType : this.hid_thisaddresstype.Value);
                    num = DeliveryBasePage.delivery_insert((long)num3, this.CompanyID, this.EstimateID, num1, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), this.EstDelAddressID, this.EstDelAddressType, base.ReplaceSingleQuote(this.Footer), base.ReplaceSingleQuote(str3), str2, this.DeliveyDate, base.ReplaceSingleQuote(str1), this.OrderNo, false, num2, this.UserID, defaultStatusID, DateTime.Now, this.UserID, (long)0, base.ReplaceSingleQuote(this.Header), this.TodayDate, this.ClientID, empty2, empty3, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix);
                    DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num, Convert.ToInt32(this.AccountingID));
                    EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num1, num, "DeliveryNote");
                    this.Insert_ActivityHistory_DeliveryNote(this.EstimateID, num, base.ReplaceSingleQuote(str1), str2, this.CompanyID, this.UserID, num1);
                    this.Insert_ActivityHistory_for_DeliveryNote(this.EstimateID, num, base.ReplaceSingleQuote(str1), str2, this.CompanyID, this.UserID, num1);
                    if (this.hdn_SaveData.Value != "")
                    {
                        string value = this.hdn_SaveData.Value;
                        chrArray = new char[] { '~' };
                        this.strSingleDelQty = value.Split(chrArray);
                        for (int i = 0; i < (int)this.strSingleDelQty.Length - 1; i++)
                        {
                            long num5 = (long)0;
                            string empty4 = string.Empty;
                            int num6 = 0;
                            string str4 = string.Empty;
                            string empty5 = string.Empty;
                            string str5 = string.Empty;
                            string str6 = this.strSingleDelQty[i];
                            chrArray = new char[] { '±' };
                            string[] strArrays = str6.Split(chrArray);
                            for (int j = 0; j < (int)strArrays.Length; j++)
                            {
                                string str7 = strArrays[j];
                                chrArray = new char[] { 'Ç' };
                                string[] strArrays1 = str7.Split(chrArray);
                                string str8 = strArrays1[0].ToString();
                                string str9 = strArrays1[1].ToString();
                                if (str8 == "ItemNo")
                                {
                                    Convert.ToInt32(str9);
                                }
                                if (str8 == "Quantity")
                                {
                                    str4 = str9;
                                }
                                if (str8 == "AddressID")
                                {
                                    Convert.ToInt32(str9);
                                }
                                if (str8 == "TotalItem")
                                {
                                    Convert.ToInt32(str9);
                                }
                                if (str8 == "EstimateID")
                                {
                                    Convert.ToInt64(str9);
                                }
                                if (str8 == "EstimateItemID")
                                {
                                    num5 = Convert.ToInt64(str9);
                                }
                                if (str8 == "EstimateType")
                                {
                                    empty4 = str9;
                                }
                            }
                            string pODN = string.Empty;
                            pODN = this.commclass.ItemDescriptionToPO_DN(this.CompanyID, num5, "DeliveryNote", ref str);
                            string empty6 = string.Empty;
                            foreach (DataRow dataRow in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, num5, "X").Rows)
                            {
                                empty6 = dataRow["ItemTitle"].ToString();
                                pODN = (empty6 == "" ? string.Concat(empty6, "\n", pODN) : string.Concat("Job Name: ", empty6, "\n", pODN));
                            }
                            if (str4 != "0")
                            {
                                if (empty4.ToLower() == "c" || empty4.ToLower() == "x")
                                {
                                    num6 = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num5);
                                    DataSet dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num5, num6, empty4);
                                    DataTable item = dataSet.Tables[0];
                                    if (item.Rows.Count <= 0)
                                    {
                                        DeliveryBasePage.deliveryitem_insert(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), (long)1, "", (long)0);
                                    }
                                    else
                                    {
                                        foreach (DataRow row1 in item.Rows)
                                        {
                                            long num7 = Convert.ToInt64(row1["PriceCatalogueID"]);
                                            DataTable dataTable = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num7);
                                            if (dataTable.Rows.Count <= 0)
                                            {
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), num7);
                                            }
                                            else if (dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                            {
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), num7);
                                            }
                                            else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                            {
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), num7);
                                            }
                                            else if (dataTable.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                            {
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), num7);
                                            }
                                            else
                                            {
                                                foreach (DataRow dataRow1 in PurchaseBasePage.Kit_Details(num7).Rows)
                                                {
                                                    int num8 = Convert.ToInt16(str4) * Convert.ToInt16(dataRow1["Quantity"]);
                                                    string str10 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(dataRow1["KitItemID"])).Replace("»", "\n");
                                                    DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(num8.ToString()), base.ReplaceSingleQuote(str10), Convert.ToInt64(dataRow1["KitItemID"].ToString()));
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    DeliveryBasePage.deliveryitem_insert(this.CompanyID, num4, num, this.EstimateID, num5, empty4, base.ReplaceSingleQuote(str4.ToString()), base.ReplaceSingleQuote(pODN), (long)1, "", (long)0);
                                }
                            }
                        }
                        if (this.hdn_splitQtyProduced.Value != "")
                        {
                            string str11 = this.hdn_splitQtyProduced.Value.ToString();
                            chrArray = new char[] { 'µ' };
                            string[] strArrays2 = str11.Split(chrArray);
                            for (int k = 0; k < (int)strArrays2.Length - 1; k++)
                            {
                                string str12 = strArrays2[k];
                                chrArray = new char[] { '±' };
                                string[] strArrays3 = str12.Split(chrArray);
                                int num9 = Convert.ToInt32(strArrays3[0]);
                                long num10 = Convert.ToInt64(strArrays3[1]);
                                string str13 = strArrays3[2].ToString();
                                JobsBasePage.Job_DeliveryNote_QtyProduced_Update(this.CompanyID, this.EstimateID, num10, str13, num9);
                            }
                        }
                    }
                }
                else if (this.hdn_DeliveryNoteType.Value.ToLower() == "split")
                {
                    long num11 = (long)0;
                    long num12 = (long)0;
                    long num13 = (long)0;
                    int num14 = 0;
                    string empty7 = string.Empty;
                    int num15 = 0;
                    string empty8 = string.Empty;
                    long num16 = (long)0;
                    string empty9 = string.Empty;
                    string empty10 = string.Empty;
                    if (this.hdn_SaveData.Value != "")
                    {
                        string value1 = this.hdn_SaveData.Value;
                        chrArray = new char[] { '~' };
                        string[] strArrays4 = value1.Split(chrArray);
                        string empty11 = string.Empty;
                        for (int l = 0; l < (int)strArrays4.Length - 1; l++)
                        {
                            string str14 = strArrays4[l];
                            chrArray = new char[] { '±' };
                            string[] strArrays5 = str14.Split(chrArray);
                            for (int m = 0; m < (int)strArrays5.Length; m++)
                            {
                                string str15 = strArrays5[m];
                                chrArray = new char[] { 'Ç' };
                                string[] strArrays6 = str15.Split(chrArray);
                                string str16 = strArrays6[0].ToString();
                                string str17 = strArrays6[1].ToString();
                                if (str16 == "ItemNo")
                                {
                                    num14 = Convert.ToInt32(str17);
                                }
                                if (str16 == "Quantity")
                                {
                                    empty7 = str17;
                                }
                                if (str16 == "AddressID")
                                {
                                    num15 = Convert.ToInt32(str17);
                                }
                                if (str16 == "AddressType")
                                {
                                    empty8 = str17;
                                }
                                if (str16 == "TotalItem")
                                {
                                    Convert.ToInt32(str17);
                                }
                                if (str16 == "EstimateID")
                                {
                                    Convert.ToInt64(str17);
                                }
                                if (str16 == "EstimateItemID")
                                {
                                    num16 = Convert.ToInt64(str17);
                                }
                                if (str16 == "EstimateType")
                                {
                                    empty9 = str17;
                                }
                            }
                            string empty12 = string.Empty;
                            string empty13 = string.Empty;
                            int jobStatusID = 0;
                            string jobid = base.Request.Params["jID"].ToString();
                            IDataReader dataReader1 = JobBasePage.Jobs_Job_Details_select(this.CompanyID, this.EstimateID);
                            while (dataReader1.Read())
                            {
                                if ((dataReader1["JobID"].ToString()) == jobid)
                                {
                                    empty12 = dataReader1["DeliveryDate"].ToString();
                                    empty13 = dataReader1["JobNumber"].ToString();
                                }
                            }
                            empty12 = this.commclass.Eprint_return_Date_Before_View(empty12, this.CompanyID, int.Parse(this.Session["userid"].ToString()), false);
                            empty12 = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, empty12);
                            this.DeliveyDate = Convert.ToDateTime(empty12);
                            string str18 = SettingsBasePage.eprint_numbering(this.CompanyID, "D", ConnectionClass.IsHandy);
                            long num17 = (long)0;
                            int num18 = 0;
                            int num19 = 0;
                            string empty14 = string.Empty;
                            string empty15 = string.Empty;
                            jobStatusID = SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Note");
                            if (jobStatusID == 0)
                            {
                                jobStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                            }
                            string empty16 = string.Empty;
                            foreach (DataRow row2 in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                            {
                                empty16 = row2["Comments"].ToString();
                            }
                            if (empty11 != num14.ToString())
                            {
                                num11 = (this.OrderID != (long)0 ? DeliveryBasePage.delivery_insert((long)num19, this.CompanyID, this.EstimateID, num17, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), (long)num15, empty8, this.Footer, base.ReplaceSingleQuote(empty16), str18, this.DeliveyDate, base.ReplaceSingleQuote(empty13), this.CustomerOrderNo, false, num18, this.UserID, jobStatusID, DateTime.Now, this.UserID, num12, this.Header, this.TodayDate, this.ClientID, empty14, empty15, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix) : DeliveryBasePage.delivery_insert((long)num19, this.CompanyID, this.EstimateID, num17, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), (long)num15, empty8, this.Footer, base.ReplaceSingleQuote(empty16), str18, this.DeliveyDate, base.ReplaceSingleQuote(empty13), this.OrderNo, false, num18, this.UserID, jobStatusID, DateTime.Now, this.UserID, num12, this.Header, this.TodayDate, this.ClientID, empty14, empty15, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix));
                                DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num11, Convert.ToInt32(this.AccountingID));
                                this.Insert_ActivityHistory_DeliveryNote(this.EstimateID, num11, base.ReplaceSingleQuote(empty13), str18, this.CompanyID, this.UserID, num17);
                                this.Insert_ActivityHistory_for_DeliveryNote(this.EstimateID, num11, base.ReplaceSingleQuote(empty13), str18, this.CompanyID, this.UserID, num17);
                            }
                            empty11 = num14.ToString();
                            string pODN1 = string.Empty;
                            string empty17 = string.Empty;
                            pODN1 = this.commclass.ItemDescriptionToPO_DN(this.CompanyID, num16, "DeliveryNote", ref str);
                            foreach (DataRow dataRow2 in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, num16, "X").Rows)
                            {
                                empty17 = dataRow2["ItemTitle"].ToString();
                                pODN1 = (empty17 == "" ? string.Concat(dataRow2["ItemTitle"], "\n", pODN1) : string.Concat("Job Name: ", empty17, "\n", pODN1));
                            }
                            if (empty9.ToLower() == "c" || empty9.ToLower() == "x")
                            {
                                this.QtyNumber = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num16);
                                DataSet dataSet1 = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num16, this.QtyNumber, empty9);
                                DataTable item1 = dataSet1.Tables[0];
                                if (item1.Rows.Count <= 0)
                                {
                                    DeliveryBasePage.deliveryitem_insert(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), (long)1, "", (long)0);
                                }
                                else
                                {
                                    foreach (DataRow row3 in item1.Rows)
                                    {
                                        long num20 = Convert.ToInt64(row3["PriceCatalogueID"]);
                                        DataTable dataTable1 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num20);
                                        if (dataTable1.Rows.Count <= 0)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), num20);
                                        }
                                        else if (dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), num20);
                                        }
                                        else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), num20);
                                        }
                                        else if (dataTable1.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), num20);
                                        }
                                        else
                                        {
                                            foreach (DataRow dataRow3 in PurchaseBasePage.Kit_Details(num20).Rows)
                                            {
                                                int num21 = Convert.ToInt16(empty7) * Convert.ToInt16(dataRow3["Quantity"]);
                                                string str19 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(dataRow3["KitItemID"])).Replace("»", "\n");
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(num21.ToString()), base.ReplaceSingleQuote(str19), Convert.ToInt64(dataRow3["KitItemID"].ToString()));
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DeliveryBasePage.deliveryitem_insert(this.CompanyID, num13, num11, this.EstimateID, num16, empty9, base.ReplaceSingleQuote(empty7), base.ReplaceSingleQuote(pODN1), (long)1, "", (long)0);
                            }
                            EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num16, num11, "DeliveryNote");
                        }
                        if (this.hdn_splitQtyProduced.Value != "")
                        {
                            string str20 = this.hdn_splitQtyProduced.Value.ToString();
                            chrArray = new char[] { 'µ' };
                            string[] strArrays7 = str20.Split(chrArray);
                            for (int n = 0; n < (int)strArrays7.Length - 1; n++)
                            {
                                string str21 = strArrays7[n];
                                chrArray = new char[] { '±' };
                                string[] strArrays8 = str21.Split(chrArray);
                                int num22 = Convert.ToInt32(strArrays8[0]);
                                long num23 = Convert.ToInt64(strArrays8[1]);
                                string str22 = strArrays8[2].ToString();
                                JobsBasePage.Job_DeliveryNote_QtyProduced_Update(this.CompanyID, this.EstimateID, num23, str22, num22);
                            }
                        }
                    }
                }
                else if (this.hdn_DeliveryNoteType.Value.ToLower() == "consolidate")
                {
                    long num24 = (long)0;
                    long num25 = (long)0;
                    long num26 = (long)0;
                    string empty18 = string.Empty;
                    string empty19 = string.Empty;
                    long num27 = (long)0;
                    long num28 = (long)0;
                    string empty20 = string.Empty;
                    string empty21 = string.Empty;
                    if (this.hdn_SaveData.Value != "")
                    {
                        string empty22 = string.Empty;
                        string empty23 = string.Empty;
                        int defaultStatusID1 = 0;
                        IDataReader dataReader2 = JobBasePage.Jobs_Job_Details_select(this.CompanyID, this.EstimateID);
                        while (dataReader2.Read())
                        {
                            empty22 = dataReader2["DeliveryDate"].ToString();
                            empty23 = dataReader2["JobNumber"].ToString();
                        }
                        defaultStatusID1 = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                        empty22 = this.commclass.Eprint_return_Date_Before_View(empty22, this.CompanyID, int.Parse(this.Session["userid"].ToString()), false);
                        empty22 = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, empty22);
                        this.DeliveyDate = Convert.ToDateTime(empty22);
                        string str23 = SettingsBasePage.eprint_numbering(this.CompanyID, "D", ConnectionClass.IsHandy);
                        long num29 = (long)0;
                        int num30 = 0;
                        int num31 = 0;
                        string empty24 = string.Empty;
                        string str24 = string.Empty;
                        string empty25 = string.Empty;
                        foreach (DataRow row4 in OrderBasePage.Order_select(this.CompanyID, this.OrderID).Rows)
                        {
                            empty25 = row4["Comments"].ToString();
                        }
                        string value2 = this.hdn_SaveData.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays9 = value2.Split(chrArray);
                        for (int o = 0; o < (int)strArrays9.Length - 1; o++)
                        {
                            string str25 = strArrays9[o];
                            chrArray = new char[] { '±' };
                            string[] strArrays10 = str25.Split(chrArray);
                            for (int p = 0; p < (int)strArrays10.Length; p++)
                            {
                                string str26 = strArrays10[p];
                                chrArray = new char[] { '»' };
                                string[] strArrays11 = str26.Split(chrArray);
                                string str27 = strArrays11[0].ToString();
                                string str28 = strArrays11[1].ToString();
                                if (str27 == "EstID")
                                {
                                    num27 = Convert.ToInt64(str28);
                                }
                                if (str27 == "EstItemID")
                                {
                                    num28 = Convert.ToInt64(str28);
                                }
                                if (str27 == "EstType")
                                {
                                    empty20 = str28;
                                }
                                if (str27 == "Description")
                                {
                                    empty21 = str28;
                                }
                                if (str27 == "Qty")
                                {
                                    empty18 = str28;
                                }
                            }
                            if (o == 0)
                            {
                                num24 = DeliveryBasePage.delivery_insert((long)num31, this.CompanyID, this.EstimateID, num29, "E", this.ClientID, this.AttentionID, base.ReplaceSingleQuote(this.ShippedTo), this.EstDelAddressID, this.EstDelAddressType, this.Footer, base.ReplaceSingleQuote(empty25), str23, this.DeliveyDate, base.ReplaceSingleQuote(empty23), this.OrderNo, false, num30, this.UserID, defaultStatusID1, DateTime.Now, this.UserID, num25, this.Header, this.TodayDate, this.ClientID, empty24, str24, Convert.ToDateTime("1900-01-01 00:00:00.000"), (long)this.CostCentreID, this.DeliveryNotePrefix);
                                DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num24, Convert.ToInt32(this.AccountingID));
                                EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num29, num24, "DeliveryNote");
                                this.Insert_ActivityHistory_DeliveryNote(this.EstimateID, num24, base.ReplaceSingleQuote(empty23), str23, this.CompanyID, this.UserID, num29);
                                this.Insert_ActivityHistory_for_DeliveryNote(this.EstimateID, num24, base.ReplaceSingleQuote(empty23), str23, this.CompanyID, this.UserID, num29);
                            }
                            if (empty20.ToLower() == "c" || empty20.ToLower() == "x")
                            {
                                this.QtyNumber = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num28);
                                DataSet dataSet2 = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num28, this.QtyNumber, empty20);
                                DataTable item2 = dataSet2.Tables[0];
                                if (item2.Rows.Count <= 0)
                                {
                                    DeliveryBasePage.deliveryitem_insert(this.CompanyID, num26, num24, num27, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), (long)1, "", (long)0);
                                }
                                else
                                {
                                    foreach (DataRow dataRow4 in item2.Rows)
                                    {
                                        long num32 = Convert.ToInt64(dataRow4["PriceCatalogueID"]);
                                        DataTable dataTable2 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num32);
                                        if (dataTable2.Rows.Count <= 0)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, this.EstimateID, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), num32);
                                        }
                                        else if (dataTable2.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, this.EstimateID, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), num32);
                                        }
                                        else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, this.EstimateID, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), num32);
                                        }
                                        else if (dataTable2.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, this.EstimateID, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), num32);
                                        }
                                        else
                                        {
                                            foreach (DataRow row5 in PurchaseBasePage.Kit_Details(num32).Rows)
                                            {
                                                int num33 = Convert.ToInt16(empty18) * Convert.ToInt16(row5["Quantity"]);
                                                string str29 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(row5["KitItemID"])).Replace("»", "\n");
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num26, num24, this.EstimateID, num28, empty20, base.ReplaceSingleQuote(num33.ToString()), base.ReplaceSingleQuote(str29), Convert.ToInt64(row5["KitItemID"].ToString()));
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DeliveryBasePage.deliveryitem_insert(this.CompanyID, num26, num24, num27, num28, empty20, base.ReplaceSingleQuote(empty18), base.ReplaceSingleQuote(empty21), (long)1, "", (long)0);
                            }
                            EstimateBasePage.Attachments_PO_DN_Copy(this.EstimateID, num28, num24, "DeliveryNote");
                        }
                    }
                }
                this.pnlLoadDelNotes.Visible = true;
            }
        }

        public double CheckIsNumber(string Str)
        {
            double num;
            if (double.TryParse(Str, out num))
            {
                return num;
            }
            return 0;
        }

        public string CheckMinusAmount(string Amount)
        {
            if (Amount.Substring(0, 1) != "-")
            {
                return Amount;
            }
            Amount = "0";
            return Amount;
        }

        [WebMethod]
        public static string GetAddress_Delivery(string txtval)
        {
            string empty = string.Empty;
            string[] strArrays = txtval.Split(new char[] { '±' });
            string str = strArrays[0];
            string str1 = strArrays[1];
            DataTable dataTable = CompanyBasePage.company_client_alladdress_select_clientname(Convert.ToInt32(str), Convert.ToInt32(str1), "");
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["Address"].ToString();
            }
            return empty;
        }

        public void Getboxlableaddress()
        {
            DataTable dataTable = CompanyBasePage.Delivery_Address_Select(this.CompanyID, this.EstimateID);
            if (dataTable.Rows.Count > 0)
            {
                this.txtAddressLine1.Text = base.SpecialDecode(dataTable.Rows[0]["Address"].ToString());
                this.txtAddressLine2.Text = base.SpecialDecode(dataTable.Rows[0]["AddressLine2"].ToString());
                this.txtAddressLine3.Text = base.SpecialDecode(dataTable.Rows[0]["City"].ToString());
                this.txtAddressLine4.Text = base.SpecialDecode(dataTable.Rows[0]["State"].ToString());
                this.txtAddressLine5.Text = base.SpecialDecode(dataTable.Rows[0]["ZipCode"].ToString());
                this.txtCountry.Text = base.SpecialDecode(dataTable.Rows[0]["Country"].ToString());
                this.txtTelephone.Text = base.SpecialDecode(dataTable.Rows[0]["Telephone"].ToString());
                this.txtFax.Text = base.SpecialDecode(dataTable.Rows[0]["Fax"].ToString());
            }
        }

        public string gettitleandquantityfor_cosolidatewithsplit(string AryConEstimateType, int AryConEsimateItemID, int x)
        {
            long num = (long)0;
            try
            {
                num = this.ItemTypeID(AryConEstimateType, Convert.ToInt64(AryConEsimateItemID));
            }
            catch
            {
            }
            short num1 = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, Convert.ToInt64(AryConEsimateItemID));
            if (AryConEstimateType == "S" || AryConEstimateType == "L" || AryConEstimateType == "P" || AryConEstimateType == "B" || AryConEstimateType == "F" || AryConEstimateType == "D" || AryConEstimateType == "N" || AryConEstimateType == "R" || AryConEstimateType == "K" || AryConEstimateType == "C" || AryConEstimateType.ToLower() == "x" || AryConEstimateType == "Q")
            {
                DataTable dataTable = JobsBasePage.Job_Items_Quantity_Details_Select(this.CompanyID, Convert.ToInt64(AryConEsimateItemID), num, AryConEstimateType, num1);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.ConQuantity = row["quantity"].ToString();
                    Convert.ToInt32(row["quantity"].ToString());
                }
            }
            else if (AryConEstimateType == "O")
            {
                foreach (DataRow dataRow in EstimateBasePage.Estimate_Outwork_Quantity_Details_Select(this.CompanyID, num, this.QtyNumber).Rows)
                {
                    this.ConQuantity = dataRow["Quantity"].ToString();
                    Convert.ToInt32(dataRow["quantity"].ToString());
                }
            }
            else if (AryConEstimateType == "U" || AryConEstimateType == "W")
            {
                DataTable dataTable1 = EstimateBasePage.Estimate_OtherCost_Qty_Details_Select(this.CompanyID, Convert.ToInt64(AryConEsimateItemID), AryConEstimateType);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    this.ConQuantity = (row1["Quantity"].ToString() == "(Qty 1)" ? "0" : row1["Quantity"].ToString());
                }
            }
            return this.ConQuantity;
        }

        protected void GridDelivery_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label)e.Row.FindControl("lblDate");
                label.Text = this.commclass.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, true);
            }
        }

        public void Insert_ActivityHistory_DeliveryNote(long EstimateID, long DeliveryID, string Job_number, string DelNO, int CompanyID, int UserID, long EstimateItemID)
        {
            string empty = string.Empty;
            foreach (DataRow row in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, "job").Rows)
            {
                empty = row["rownumber"].ToString();
            }
            this.objnotes.ModuleName = "job";
            notesclass _notesclass = this.objnotes;
            object[] deliveryID = new object[] { "<a href='", this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", DeliveryID, "' target='_blank'>", DelNO, "</a>" };
            _notesclass.Delivery_number = string.Concat(deliveryID);
            this.objnotes.Item_number = empty;
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDelCreate);
            this.objnotes.ModuleID = this.jobID;
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass1 = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass1.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, UserID, true);
            this.objnotes.CompanyID = CompanyID;
            this.objnotes.UserID = UserID;
            this.objnotes.ItemID = EstimateItemID;
            this.objN.NotesAdd(this.objnotes);
        }

        public void Insert_ActivityHistory_for_DeliveryNote(long EstimateID, long DeliveryID, string Job_number, string DelNO, int CompanyID, int UserID, long EstimateItemID)
        {
            this.objnotes.Delivery_number = DelNO;
            this.objnotes.ModuleName = "delivery";
            this.objnotes.ModuleID = DeliveryID;
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelCreated);
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, UserID, true);
            this.objnotes.CompanyID = CompanyID;
            this.objnotes.UserID = UserID;
            this.objnotes.ItemID = (long)0;
            this.objN.NotesAdd(this.objnotes);
        }

        public DataTable ItemTitle(int EstimateItemID, string EstimateType)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            if (EstimateType == "S")
            {
                empty = "TABLE_EstimateSingleItem";
                str = "EstimateSingleItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "P")
            {
                empty = "TABLE_EstimatePadItem";
                str = "EstimatePadItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "L")
            {
                empty = "TABLE_EstimateLargeItem";
                str = "EstimateLargeItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "O")
            {
                empty = "TABLE_EstOutwork";
                str = "EstOutworkID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "B")
            {
                empty = "TABLE_EstimateBookletItem";
                str = "EstimateBookletItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "W")
            {
                empty = "TABLE_EstWarehouseItem";
                str = "EstWarehouseItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "U")
            {
                empty = "TABLE_EstOtherCost";
                str = "EstOtherCostID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "C")
            {
                empty = "TABLE_EstPriceCatalogue";
                str = "EstPriceCatalogueID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "F")
            {
                empty = "TABLE_EstimateLitho";
                str = "EstLithoItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "D")
            {
                empty = "TABLE_EstimateLithoPadItem";
                str = "EstimateLithoPadItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "N")
            {
                empty = "TABLE_EstimateLithoNCRItem";
                str = "EstimateLithoNCRItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "R")
            {
                empty = "TABLE_EstimateLithoNCRItem";
                str = "EstimateLithoNCRItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "K")
            {
                empty = "TABLE_EstimateLithoBookletItem";
                str = "EstimateLithoBookletItemID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType == "Q")
            {
                empty = "TABLE_EstimateQuickQuote";
                str = "QuickQuoteID";
                empty1 = "ItemDescription";
                empty2 = "ItemTitleValue";
            }
            else if (EstimateType.ToLower() == "x")
            {
                empty = "tb_EstimateItem";
                str = "EstimateItemID";
                empty1 = "ItemDesc";
                empty2 = "JobName";
            }
            object[] estimateItemID = new object[] { "(select ItemTitlelabel+':'+ItemTitleValue+'\n'+Descriptionlabel+':'+descriptionvalue+'\n'+ArtworkLabel+':'+ArtworkValue+'\n'+ColourLabel+':'+ColourValue+'\n'+FinishingLabel+':'+FinishingValue+'\n'+ProofsLabel+':'+ProofsValue+'\n'+PackingLabel+':'+PackingValue+'\n'+NotesLabel+':'+NotesValue+'\n'+InstructionsLabel+':'+ InstructionsValue+'\n'+CustomDescriptionLabel1+':'+CustomDescriptionValue1+'\n'+CustomDescriptionLabel2+':'+CustomDescriptionValue2+'\n'+CustomDescriptionLabel3+':'+CustomDescriptionValue3+'\n'+CustomDescriptionLabel4+':'+CustomDescriptionValue4+'\n'+CustomDescriptionLabel5+':'+CustomDescriptionValue5+'\n'+CustomDescriptionLabel6+':'+CustomDescriptionValue6+'\n'+ CustomDescriptionLabel7+':'+CustomDescriptionValue7+'\n'+CustomDescriptionLabel8+':'+CustomDescriptionValue8+'\n'+CustomDescriptionLabel9+':'+CustomDescriptionValue9+'\n'+ CustomDescriptionLabel10+':'+CustomDescriptionValue10+'\n'+CustomDescriptionLabel11+':'+CustomDescriptionValue11+'\n'+CustomDescriptionLabel12+':'+CustomDescriptionValue12+'\n'+  CustomDescriptionLabel1+':'+CustomDescriptionValue1+'\n'+CustomDescriptionLabel1+':'+CustomDescriptionValue1+'\n'+CustomDescriptionLabel1+':'+CustomDescriptionValue1+'\n'+CustomDescriptionLabel13+':'+CustomDescriptionValue13+'\n'+CustomDescriptionLabel14+':'+CustomDescriptionValue14+'\n'+CustomDescriptionLabel15+':'+CustomDescriptionValue15+'\n'+  CustomDescriptionLabel16+':'+CustomDescriptionValue16+'\n'+CustomDescriptionLabel17+':'+CustomDescriptionValue17+'\n'+CustomDescriptionLabel18+':'+CustomDescriptionValue18+'\n'+ CustomDescriptionLabel19+':'+CustomDescriptionValue19+'\n'+CustomDescriptionLabel20+':'+CustomDescriptionValue20+'\n'+CustomDescriptionLabel21+':'+CustomDescriptionValue21+'\n'+  CustomDescriptionLabel22+':'+CustomDescriptionValue22+'\n'+CustomDescriptionLabel23+':'+CustomDescriptionValue23+'\n'+CustomDescriptionLabel24+':'+CustomDescriptionValue24 +'\n'+  CustomDescriptionLabel25+':'+CustomDescriptionValue25  from tb_estitemdescription where EstimateItemID=", EstimateItemID, " and  estimatetype='", EstimateType, "')" };
            empty1 = string.Concat(estimateItemID);
            if (EstimateType.ToLower() != "x")
            {
                object[] objArray = new object[] { "select top 1 IsNull(", str, ",0) as TypeID,(select IsNull(", empty2, ",'') from tb_estitemdescription  where EstimateItemID=", EstimateItemID, " ) as ItemTitle,IsNull(", empty1, ",'') as ItemDescription from ", empty, " where EstimateItemID=", EstimateItemID, " and IsDeleted=0" };
                str1 = string.Concat(objArray);
            }
            else
            {
                object[] estimateID = new object[] { "select top 1 IsNull(EstimateItemID,0) as TypeID,(select IsNull(ItemTitleValue,'') from tb_estitemdescription where EstimateID=", this.EstimateID, " and EstimateItemID=", EstimateItemID, " ) as ItemTitle,IsNull(", empty1, ",'') as ItemDescription  from tb_EstimateItem a left join tb_Estimate o on a.EstimateID=o.EstimateID where EstimateItemID=", EstimateItemID, " and a.IsDeleted=0" };
                str1 = string.Concat(estimateID);
            }
            return JobsBasePage.Jobs_ItemTitle_select(this.CompanyID, str1);
        }

        public long ItemTypeID(string EstimateType, long EstimateItemID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (EstimateType == "S")
            {
                empty = "tb_EstimateSingleItem";
                str = "EstimateSingleItemID";
            }
            else if (EstimateType == "P")
            {
                empty = "tb_EstimatePadItem";
                str = "EstimatePadItemID";
            }
            else if (EstimateType == "L")
            {
                empty = "tb_EstimateLargeItem";
                str = "EstimateLargeItemID";
            }
            else if (EstimateType == "O")
            {
                empty = "tb_EstOutwork";
                str = "EstOutworkID";
            }
            else if (EstimateType == "B")
            {
                empty = "tb_EstimateBookletItem";
                str = "EstimateBookletItemID";
            }
            else if (EstimateType == "W")
            {
                empty = "tb_EstWarehouseItem";
                str = "EstWarehouseItemID";
            }
            else if (EstimateType == "U")
            {
                empty = "tb_EstOtherCost";
                str = "EstOtherCostID";
            }
            else if (EstimateType == "C")
            {
                empty = "tb_EstPriceCatalogue";
                str = "EstimateItemID";
            }
            else if (EstimateType == "F")
            {
                empty = "tb_EstimateLitho";
                str = "EstLithoItemID";
            }
            else if (EstimateType == "D")
            {
                empty = "tb_EstimateLithoPadItem";
                str = "EstimateLithoPadItemID";
            }
            else if (EstimateType == "N")
            {
                empty = "tb_EstimateLithoNCRItem";
                str = "EstimateLithoNCRItemID";
            }
            else if (EstimateType == "R")
            {
                empty = "tb_EstimateLithoNCRItem";
                str = "EstimateLithoNCRItemID";
            }
            else if (EstimateType == "K")
            {
                empty = "tb_EstimateLithoBookletItem";
                str = "EstimateLithoBookletItemID";
            }
            else if (EstimateType == "Q")
            {
                empty = "tb_EstimateQuickQuote";
                str = "QuickQuoteID";
            }
            else if (EstimateType.ToLower() == "x")
            {
                empty = "tb_EstPriceCatalogue";
                str = "EstimateItemID";
            }
            object[] estimateItemID = new object[] { "select IsNull(", str, ",0) as TypeID from ", empty, " where EstimateItemID=", EstimateItemID, " and IsDeleted=0" };
            string str1 = string.Concat(estimateItemID);
            return EstimateBasePage.Estimate_Items_TypeID_Select(this.CompanyID, str1);
        }

        protected void lnkRaiseDeliveryNote_OnClick(object sender, EventArgs e)
        {
            if (base.Request.QueryString["ordid"] == null)
            {
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, "jobs/multiple_delivery_note_new.aspx?page=job&Estid=", this.EstimateID, "&jID=", this.jobID, "&ItemIds=", base.Request.QueryString["ItemIds"] };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            HttpResponse httpResponse = base.Response;
            object[] objArray = new object[] { this.strSitepath, "jobs/multiple_delivery_note_new.aspx?page=job&Estid=", this.EstimateID, "&ordid=", base.Request.QueryString["ordid"], "&jID=", this.jobID };
            httpResponse.Redirect(string.Concat(objArray));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename(base.Request.Params["page"].ToString());
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.pg = base.Request.Params["page"].ToString();
            this.DateFormat = this.Session["DateFormat"].ToString();
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.EstimateID = Convert.ToInt64(base.Request.Params["Estid"].ToString());
            DataTable dataTable = new DataTable();
            dataTable = Settings.Setting_accountingCode_SelectAllRevenueCode(this.CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["isDefault"].ToString().ToLower().Trim() != "true")
                {
                    continue;
                }
                this.AccountingID = Convert.ToInt32(row["AccountCodeID"].ToString());
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            this.btnRefreshParent.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnSplitAddressChange.Text = this.objLanguage.GetLanguageConversion("Choose_Address");
            this.btnBoxLabelCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnBoxLabelNext.Text = this.objLanguage.GetLanguageConversion("Next");
            this.Button3.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.Button2.Text = this.objLanguage.GetLanguageConversion("Select_Items");
            this.btnCancel_ConDeliveryNote.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnRefreshParent_con.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnConAddressChange.Text = this.objLanguage.GetLanguageConversion("Choose_Address");
            this.btncontinue.Text = this.objLanguage.GetLanguageConversion("Select_Items");
            this.btncancel_conswithsplit.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.rdosplit.Text = this.objLanguage.GetLanguageConversion("Choose_Address");
            this.rdoconsolidate.Text = this.objLanguage.GetLanguageConversion("Consolidated");
            this.lnkaddnewmore.Text = this.objLanguage.GetLanguageConversion("Add_another_Address");
            this.btnRaiseMultiple.Text = this.objLanguage.GetLanguageConversion("Raise");
            this.btnSavestayDeliveryNote.Text = this.objLanguage.GetLanguageConversion("Raise_Stay");
            this.btnRaiseDeliveryNote.Text = this.objLanguage.GetLanguageConversion("Raise_Close");
            this.lbl_Deliveryaddr1.Text = this.commclass.GetAddressLabelByKey("address1");
            this.lbl_Deliveryaddr2.Text = this.commclass.GetAddressLabelByKey("address2");
            this.lbl_Deliveryaddr3.Text = this.commclass.GetAddressLabelByKey("address3");
            this.lbl_Deliveryaddr4.Text = this.commclass.GetAddressLabelByKey("address4");
            this.lbl_Deliveryaddr5.Text = this.commclass.GetAddressLabelByKey("address5");
            multiple_delivery_note_new jobsMultipleDeliveryNoteNew = this;
            jobsMultipleDeliveryNoteNew.LabelText = string.Concat(jobsMultipleDeliveryNoteNew.LabelText, "Bridge Motors\n");
            multiple_delivery_note_new jobsMultipleDeliveryNoteNew1 = this;
            jobsMultipleDeliveryNoteNew1.LabelText = string.Concat(jobsMultipleDeliveryNoteNew1.LabelText, "Units 3 & 4 Trinder House,Stansworth Street,\n");
            multiple_delivery_note_new jobsMultipleDeliveryNoteNew2 = this;
            jobsMultipleDeliveryNoteNew2.LabelText = string.Concat(jobsMultipleDeliveryNoteNew2.LabelText, "Southampton, Kent, United Kingdom\n");
            multiple_delivery_note_new jobsMultipleDeliveryNoteNew3 = this;
            jobsMultipleDeliveryNoteNew3.LabelText = string.Concat(jobsMultipleDeliveryNoteNew3.LabelText, "S032 1EE\n");
            multiple_delivery_note_new jobsMultipleDeliveryNoteNew4 = this;
            jobsMultipleDeliveryNoteNew4.LabelText = string.Concat(jobsMultipleDeliveryNoteNew4.LabelText, "01489 891035-02");
            this.txtLabel.Text = this.LabelText;
            this.txtLabel.Text = this.txtLabel.Text.Replace(Environment.NewLine, "<BR/>");           
            this.Items = EstimatesBasePage.Job_Items_Count_Select(this.CompanyID, this.jobID);
            this.hdn_TotItems.Value = this.Items.ToString();
            if (base.Request.QueryString["ItemIds"] != null)
            {
                string[] strTotalItems = Convert.ToString(base.Request.Params["ItemIds"]).Split(new char[] { 'µ' });
                this.Items = (int)strTotalItems.Length - 1;
                this.hdn_TotItems.Value = this.Items.ToString();
            }
            // create delivery note
            //if (base.Request.QueryString["ItemIds"] != null)
            //{
            //    string[] strTotalItems = Convert.ToString(base.Request.Params["ItemIds"]).Split(new char[] { 'µ' });
            //    this.Items = (int)strTotalItems.Length - 1;
            //    this.hdn_TotItems.Value = this.Items.ToString();
            //}
            //this.Items = EstimatesBasePage.Job_Items_Count_Select(this.CompanyID, this.jobID);
            //this.hdn_TotItems.Value = this.Items.ToString();  
          
            commonClass _commonClass = this.commclass;
            string dateFormat = this.DateFormat;
            commonClass _commonClass1 = this.commclass;
            DateTime now = DateTime.Now;
            string str = _commonClass.eprint_checkdateformat_returnonlymmddyyyy(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            this.TodayDate = Convert.ToDateTime(str);
            if (base.Request.QueryString["ordid"] == null)
            {
                this.OrderID = this.EstimateID;
            }
            else
            {
                this.OrderID = Convert.ToInt64(base.Request.QueryString["ordid"].ToString());
            }
            if (EprintConfigurationManager.AppSettings["ServerName"] != null && EprintConfigurationManager.AppSettings["ServerName"].ToString().ToLower() == "ppw")
            {
                this.ServerName = "ppw";
                if (!base.IsPostBack)
                {
                    this.ddlLabeltype.Items.Insert(7, "Custom(100mm x 149mm): 1*1-A4");
                    this.ddlLabeltype.Items[7].Value = "8";
                    this.ddlLabeltype.Items[7].Text = "Custom(100mm x 149mm): 1*1-A4";
                    this.ddlLabeltype.SelectedIndex = this.ddlLabeltype.Items.Count - 1;
                }
                this.div_editext.Visible = false;
            }
            else if (EprintConfigurationManager.AppSettings["ServerName"] != null && EprintConfigurationManager.AppSettings["ServerName"].ToString().ToLower() == "maspro")
            {
                this.ServerName = "mas";
                if (!base.IsPostBack)
                {
                    this.ddlLabeltype.Items.Insert(7, "Custom (100mm x 50mm): 1*1-A4");
                    this.ddlLabeltype.Items[7].Value = "8";
                    this.ddlLabeltype.Items[7].Text = "Custom (100mm x 50mm): 1*1-A4";
                    this.ddlLabeltype.SelectedIndex = this.ddlLabeltype.Items.Count - 1;
                }
                this.div_editext.Visible = false;
            }
            else if (EprintConfigurationManager.AppSettings["ServerName"] == null || !(EprintConfigurationManager.AppSettings["ServerName"].ToString().ToLower() == "printmonkey") && !(EprintConfigurationManager.AppSettings["ServerName"].ToString().ToLower() == "studio1") && !(EprintConfigurationManager.AppSettings["ServerName"].ToString().ToLower() == "centurionprint") && !(EprintConfigurationManager.AppSettings["ServerName"].ToString().ToLower() == "inki"))
            {
                this.div_editext.Visible = true;
            }
            else
            {
                this.ServerName = ConnectionClass.ServerName.ToString().ToLower();
                if (!base.IsPostBack)
                {
                    this.ddlLabeltype.Items.Insert(7, "100 * 36 mm");
                    this.ddlLabeltype.Items[7].Value = "8";
                    this.ddlLabeltype.Items[7].Text = "100 * 36 mm";
                    this.ddlLabeltype.SelectedIndex = this.ddlLabeltype.Items.Count - 1;
                }
                this.div_editext.Visible = false;
            }
            if (ConnectionClass.DeliveryNotePrefix != null)
            {
                this.DeliveryNotePrefix = ConnectionClass.DeliveryNotePrefix;
            }
            foreach (DataRow dataRow in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
            {
                this.ClientID = Convert.ToInt32(dataRow["CustomerID"].ToString());
                this.lblCustomerName.Text = base.SpecialDecode(dataRow["ClientName"].ToString());
                this.AttentionID = Convert.ToInt32(dataRow["AttentionID"].ToString());
                this.ShippedTo = dataRow["ClientName"].ToString();
                this.OrderNo = dataRow["OrderNumber"].ToString();
                this.CustomerOrderNo = dataRow["CustomerOrderNo"].ToString();
                this.EstDelAddressID = Convert.ToInt64(dataRow["DeliveryAddressID"].ToString());
                this.EstDelAddressType = dataRow["DeliveryAddressType"].ToString();
                this.CustomerName = dataRow["ClientName"].ToString().ToUpper();
                this.AttentionName = dataRow["ContactName"].ToString().ToUpper();
                this.MainJobNumber = dataRow["JobNumber"].ToString();
                this.CostCentreID = Convert.ToInt32(dataRow["CostCentreID"]);
                this.AttnName = dataRow["ContactName"].ToString();
                this.JobDeliveryAddress = dataRow["DeliveryAddress"].ToString();
            }
            foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Header").Rows)
            {
                this.IsDefltHeader = Convert.ToBoolean(row1["IsDefaultPhrase"].ToString());
            }
            if (!this.IsDefltHeader)
            {
                foreach (DataRow dataRow1 in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    this.Header = dataRow1["Header"].ToString();
                }
            }
            else
            {
                foreach (DataRow row2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Header").Rows)
                {
                    this.Header = row2["PhraseText"].ToString();
                }
            }
            foreach (DataRow dataRow2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Footer").Rows)
            {
                this.IsDefltFooter = Convert.ToBoolean(dataRow2["IsDefaultPhrase"].ToString());
            }
            if (!this.IsDefltFooter)
            {
                foreach (DataRow row3 in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    this.Footer = row3["Footer"].ToString();
                }
            }
            else
           {
                foreach (DataRow dataRow3 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Footer").Rows)
                {
                    this.Footer = dataRow3["PhraseText"].ToString();
                }
            }
            //foreach (DataRow row4 in EstimatesBasePage.Estimate_Items_RFQdescription_Select(this.CompanyID, this.jobID, "job").Rows)
            //{
            //    this.StrEsimateItemID = string.Concat(this.StrEsimateItemID, row4["EstimateItemID"].ToString(), "Ç");
            //    this.StrEstimateType = string.Concat(this.StrEstimateType, row4["EstimateType"].ToString(), "Ç");
            //}
            // create delivery note

            if (base.Request.QueryString["ItemIds"] != null)
            {
                if (base.Request.QueryString["ItemIds"].Contains("µ"))
                {
                    // new logic
                    string itemids = Convert.ToString(base.Request.Params["ItemIds"]);
                    string[] strCreateDelArrays = itemids.Split(new char[] { 'µ' });
                    for (int i = 0; i < (int)strCreateDelArrays.Length - 1; i++)
                    {
                        int estimateItemId = Convert.ToInt32(strCreateDelArrays[i]);
                        foreach (DataRow row4 in EstimatesBasePage.Estimate_ByEstimateItemId_Select(this.CompanyID, estimateItemId, "job").Rows)
                        {
                            this.StrEsimateItemID = string.Concat(this.StrEsimateItemID, row4["EstimateItemID"].ToString(), "Ç");
                            this.StrEstimateType = string.Concat(this.StrEstimateType, row4["EstimateType"].ToString(), "Ç");
                        }
                    }
                }
                else
                {
                    // old logic
                    foreach (DataRow row4 in EstimatesBasePage.Estimate_Items_RFQdescription_Select(this.CompanyID, this.jobID, "job").Rows)
                    {
                        this.StrEsimateItemID = string.Concat(this.StrEsimateItemID, row4["EstimateItemID"].ToString(), "Ç");
                        this.StrEstimateType = string.Concat(this.StrEstimateType, row4["EstimateType"].ToString(), "Ç");
                    }
                }
                
            }
            string strEsimateItemID = this.StrEsimateItemID;
            char[] chrArray = new char[] { 'Ç' };
            this.AryEsimateItemID = strEsimateItemID.Split(chrArray);
            string strEstimateType = this.StrEstimateType;
            char[] chrArray1 = new char[] { 'Ç' };
            this.AryEstimateType = strEstimateType.Split(chrArray1);
            if (!base.IsPostBack)
            {
                this.rdosplit.Checked = true;
                this.BindSplitDelivery();
            }
            string[] strArrays = this.strItemTitle.Split(new char[] { 'µ' });
            if (!base.IsPostBack)
            {
                this.ddlItemTitle.Items.Insert(0, "--- Select Item Title ---");
                this.ddlItemTitle.Items[0].Text = "--- Select Item Title ---";
                this.ddlItemTitle.Items[0].Value = "0";
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                    string str1 = strArrays1[0].ToString();
                    string str2 = strArrays1[1].ToString();
                    this.ddlItemTitle.Items.Insert(i + 1, base.SpecialDecode(str1));
                    this.ddlItemTitle.Items[i + 1].Text = base.SpecialDecode(str1);
                    this.ddlItemTitle.Items[i + 1].Value = str2;
                }
                if (this.ddlItemTitle.Items.Count != 2)
                {
                    this.ddlItemTitle.SelectedIndex = 0;
                }
                else
                {
                    this.ddlItemTitle.SelectedIndex = 1;
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("javascript:ShowonChange(", this.ddlItemTitle.SelectedValue, ");"), true);
                }
            }
            this.txtCompany.Text = this.lblCustomerName.Text;
            this.hid_companyid.Value = this.CompanyID.ToString();
            this.hid_clientid.Value = this.ClientID.ToString();
            if (!base.IsPostBack)
            {
                this.Getboxlableaddress();
                if (base.Request.Params["fromadd"] != null && base.Request.Params["fromadd"] == "yes")
                {
                    if (base.Request.Params["type"] == null)
                    {
                        this.DelRaise_Type = "single";
                    }
                    else
                    {
                        if (base.Request.Params["type"].ToString().ToLower() == "consolidated")
                        {
                            if (base.Request.Params["contype"] == null)
                            {
                                this.ConDelRaise_Type = "single";
                            }
                            else
                            {
                                this.ConDelRaise_Type = base.Request.Params["contype"].ToString();
                            }
                        }
                        this.DelRaise_Type = base.Request.Params["type"].ToString();
                    }
                    this.pnl_viewonlydelivery.Visible = true;
                    base.Message_Display("Delivery Note(s) Raised Successfully", "successfulMsg", this.plhMessage);
                }
            }
        }

        [WebMethod]
        public static void QtyProduced_Update(int CompanyID, long EstimateID, long QtyEstItemID, string QtyEstType, int QtyProduced)
        {
            Thread.Sleep(500);
            JobsBasePage.Job_DeliveryNote_QtyProduced_Update(CompanyID, EstimateID, QtyEstItemID, QtyEstType, QtyProduced);
        }

        protected void rdoChooseAddress_click(object sender, EventArgs e)
        {
            this.div_ConsolidatedDelivery.Style.Add("display", "none");
            this.divbuttonsup_consolidate.Style.Add("display", "none");
            this.div_btncontinue_consolidate.Style.Add("display", "none");
            this.divConsolidate_split.Style.Add("display", "none");
            this.div_SplitDelivery.Style.Add("display", "block");
            this.rdosplit.Checked = true;
            this.rdoconsolidate.Checked = false;
            this.BindSplitDelivery();
            this.hid_checkboxid.Value = "";
            this.DelRaise_Type = "";
            this.rdosplit.Enabled = false;
            this.rdoconsolidate.Enabled = true;
        }

        protected void rdoConsolidate_OnClick(object sender, EventArgs e)
        {
            this.rdosplit.Checked = false;
            this.rdoconsolidate.Checked = true;
            this.div_ConsolidatedDelivery.Style.Add("display", "block");
            this.divbuttonsup_consolidate.Style.Add("display", "block");
            this.div_btncontinue_consolidate.Style.Add("display", "block");
            this.div_SplitDelivery.Style.Add("display", "none");
            this.divConsolidate_split.Style.Add("display", "none");
            this.BindConsolidatedDelivery();
            this.DelRaise_Type = "consolidate";
            this.rdoconsolidate.Enabled = false;
            this.rdosplit.Enabled = true;
        }

        public double ReturnExact2Decimal(double Amount)
        {
            Amount = Amount * 100;
            string[] strArrays = Amount.ToString().Split(new char[] { '.' });
            Amount = Convert.ToDouble(strArrays[0]) / 100;
            return Amount;
        }

        private string ReturnFormatted_ItemDescription(string ItemDescription)
        {
            string empty = string.Empty;
            string[] strArrays = ItemDescription.ToString().Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                if (string.Compare(strArrays1[0], "ItemTitle ", true) == 0)
                {
                    string[] str = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(str);
                }
                if (string.Compare(strArrays1[0], "Description", true) == 0)
                {
                    string[] str1 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(str1);
                }
                if (string.Compare(strArrays1[0], "Artwork", true) == 0)
                {
                    string[] str2 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(str2);
                }
                if (string.Compare(strArrays1[0], "Colour", true) == 0)
                {
                    string[] strArrays2 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(strArrays2);
                }
                if (string.Compare(strArrays1[0], "Size", true) == 0)
                {
                    string[] str3 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(str3);
                }
                if (string.Compare(strArrays1[0], "Material", true) == 0)
                {
                    string[] strArrays3 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(strArrays3);
                }
                if (string.Compare(strArrays1[0], "Delivery", true) == 0)
                {
                    string[] str4 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(str4);
                }
                if (string.Compare(strArrays1[0], "Finishing", true) == 0)
                {
                    string[] strArrays4 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(strArrays4);
                }
                if (string.Compare(strArrays1[0], "Notes", true) == 0)
                {
                    string[] str5 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(str5);
                }
                if (string.Compare(strArrays1[0], "Instructions", true) == 0)
                {
                    string[] strArrays5 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(strArrays5);
                }
                if (string.Compare(strArrays1[0], "Proofs", true) == 0)
                {
                    string[] str6 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(str6);
                }
                if (string.Compare(strArrays1[0], "Packing", true) == 0)
                {
                    string[] strArrays6 = new string[] { empty, strArrays1[1], ": ", strArrays1[2].ToString(), "\n" };
                    empty = string.Concat(strArrays6);
                }
            }
            return empty;
        }

        public int returnonlyquantity(string quantity)
        {
            int num;
            string str = "0";
            try
            {
                if (quantity != "")
                {
                    if (quantity.Contains("."))
                    {
                        char[] chrArray = new char[] { '.' };
                        str = quantity.Split(chrArray)[0];
                    }
                    if (quantity.Contains("Qty") || quantity.Contains("QTY"))
                    {
                        char[] chrArray1 = new char[] { ' ' };
                        if ((int)quantity.Split(chrArray1).Length <= 1)
                        {
                            char[] chrArray2 = new char[] { ' ' };
                            if ((int)quantity.Split(chrArray2).Length > 0)
                            {
                                char[] chrArray3 = new char[] { ' ' };
                                str = quantity.Split(chrArray3)[1];
                                if (str.Contains(")"))
                                {
                                    str = str.Substring(0, Convert.ToInt32(str.Length) - 1);
                                }
                                if (str.Contains("."))
                                {
                                    char[] chrArray4 = new char[] { '.' };
                                    str = str.Split(chrArray4)[0];
                                }
                            }
                        }
                        else
                        {
                            char[] chrArray5 = new char[] { ' ' };
                            str = quantity.Split(chrArray5)[2];
                            if (str.Contains(")"))
                            {
                                str = str.Substring(0, Convert.ToInt32(str.Length) - 1);
                            }
                            if (str.Contains("."))
                            {
                                char[] chrArray6 = new char[] { '.' };
                                str = str.Split(chrArray6)[0];
                            }
                        }
                    }
                    else
                    {
                        str = quantity;
                    }
                }
                num = Convert.ToInt32(str);
            }
            catch
            {
                str = "0";
                num = Convert.ToInt32(str);
            }
            return num;
        }

        protected void Show_Consolidated_With_Multiple_address(object sender, EventArgs e)
        {
            this.div_ConsolidatedDelivery.Style.Add("display", "none");
            this.plhconsolidate_split.Controls.Clear();
            DataTable item = (DataTable)this.Session["dtSendToOtherPage"];
            int num = 0;
            double num1 = 0;
            double num2 = 0;
            string[] strArrays = this.hid_checkboxid.Value.Split(new char[] { '~' });
            this.plhconsolidate_split.Controls.Add(new LiteralControl("<div align='left' style='width: 100%;border: 1px solid black;'>"));
            int num3 = 0;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (strArrays[i] != row["EstimateItemID"].ToString())
                    {
                        continue;
                    }
                    DataTable dataTable = EstimatesBasePage.estimate_deliverynote_onitemid_selectall(this.CompanyID, Convert.ToInt64(row["EstimateID"].ToString()), Convert.ToInt64(row["EstimateItemID"].ToString()), row["EstimateType"].ToString());
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div id='divConsolidated_Items' align='left' style='width: 100%;border: 0px solid #EAEAEA;'>"));
                    if (i == 0)
                    {
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div align='left' style='width: 100%;height: 20px;' class='bgcustomize navigatorpanel'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left; width: 20%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
                        int count = dataTable.Rows.Count;
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;padding-left: 2px;'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Job_Number")));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left; width: 20%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Item_Title")));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 13%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " ", this.objLanguage.GetLanguageConversion("Ordered"))));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 15%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " ", this.objLanguage.GetLanguageConversion("Produced"))));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;width: 16px'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("&nbsp;"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 13%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl(string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Qty"), " ", this.objLanguage.GetLanguageConversion("Delivered"))));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 13%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl(string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Qty"), " ", this.objLanguage.GetLanguageConversion("Available"))));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    }
                    string str = "NewTableRow normalText";
                    str = (i % 2 != 0 ? "NewAlternative normalText" : "NewTableRow normalText");
                    string str1 = (row["Quantity"].ToString() == "" ? Convert.ToString(0) : row["Quantity"].ToString());
                    str1 = Convert.ToString(Math.Round(Convert.ToDouble(str1), 0));
                    string str2 = this.CheckMinusAmount(str1);
                    int num4 = JobsBasePage.Job_DeliveryNote_QtyProduced_Select(this.CompanyID, Convert.ToInt64(row["EstimateID"].ToString()), Convert.ToInt64(row["EstimateItemID"].ToString()), row["EstimateType"].ToString());
                    num4 = (num4 == 0 ? Convert.ToInt32(str2) : num4);
                    this.plhconsolidate_split.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width: 100%;height: 20px;border:0px solid;clear: both' class='", str, "'>")));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left; width: 20%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
                    if (dataTable.Rows.Count <= 0)
                    {
                    }
                    else
                    {
                        num3++;
                    }
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;padding-left: 2px;'>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl(row["JobNumber"].ToString()));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='overflow:hidden;white-space:nowrap;max-width:20%; float: left;width: 20%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl(row["ItemTitle"].ToString()));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 13%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
                    ControlCollection controls = this.plhconsolidate_split.Controls;
                    object[] objArray = new object[] { "<label id='lblconqtyordered_", i, "'>", row["Quantity"].ToString(), "</label>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 15%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
                    TextBox textBox = new TextBox()
                    {
                        ID = string.Concat("txtCon_QtyProduced_", i),
                        Width = 103,
                        SkinID = "textPad"
                    };
                    textBox.Style["TEXT-ALIGN"] = TextAlign.Right.ToString();
                    textBox.Text = num4.ToString();
                    textBox.AutoCompleteType = AutoCompleteType.Disabled;
                    textBox.MaxLength = 8;
                    textBox.Attributes.Add("onkeyup", "javascript:AllowNumber(this,this.value);");
                    textBox.Attributes.Add("onkeypress", "javascript:AllowNumber(this,this.value);");
                    AttributeCollection attributes = textBox.Attributes;
                    object[] objArray1 = new object[] { "javascript:fillQtyProduced(this,'", i, "','", row["EstimateItemID"].ToString(), "', '", row["EstimateType"].ToString(), "','", row["Quantity"].ToString(), "')" };
                    attributes.Add("onblur", string.Concat(objArray1));
                    textBox.Attributes.Add("onfocus", "javascript:this.select()");
                    this.plhconsolidate_split.Controls.Add(textBox);
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;'>"));
                    ControlCollection controlCollections = this.plhconsolidate_split.Controls;
                    object[] text = new object[] { "<img id='imgsplit_SaveQtyProduced_", i, "' src='../images/save.gif' title='Save' height='12px' width='12px' style='vertical-align: middle;padding-left: 2px;padding-top: 4px;cursor: pointer' onclick=javascript:SaveQtyProduced('", i, "','", textBox.Text, "','", row["EstimateID"].ToString(), "','", row["EstimateItemID"].ToString(), "','", row["EstimateType"].ToString(), "','consolidate');return false; />&nbsp;" };
                    controlCollections.Add(new LiteralControl(string.Concat(text)));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    DataTable dataTable1 = DeliveryBasePage.deliveryitem_select_splitdelivery(this.CompanyID, Convert.ToInt64(row["EstimateItemID"].ToString()), Convert.ToInt64(row["EstimateID"].ToString()), row["EstimateType"].ToString());
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.returnquantity = this.returnonlyquantity(dataRow["quantity"].ToString());
                        num1 = num1 + (double)Convert.ToInt32(this.returnquantity);
                    }
                    num2 = Convert.ToDouble(num4) - Convert.ToDouble(num1);
                    num2 = (num2 < 0 ? 0 : num2);
                    HiddenField hdnSplitQtyConswithsplit = this.hdn_SplitQty_conswithsplit;
                    hdnSplitQtyConswithsplit.Value = string.Concat(hdnSplitQtyConswithsplit.Value, num2.ToString(), "~");
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 13%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
                    ControlCollection controls1 = this.plhconsolidate_split.Controls;
                    object[] objArray2 = new object[] { "<label id='lblconQtyDelivered_", i, "'>", num1.ToString(), "</label>" };
                    controls1.Add(new LiteralControl(string.Concat(objArray2)));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 13%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"));
                    ControlCollection controlCollections1 = this.plhconsolidate_split.Controls;
                    object[] str3 = new object[] { "<label id='lblConBalance_", i, "'>", num2.ToString(), "</label>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(str3)));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
                    num++;
                    num1 = 0;
                    this.ShowRaisedDeliveryNote(dataTable, i, "consolidate", this.plhconsolidate_split);
                }
            }
            this.plhconsolidate_split.Controls.Add(new LiteralControl("</div>"));
            this.hid_totItems_con_withsplit.Value = num.ToString();
            this.BindSplitAddress_consolidatewithsplit(this.CompanyID, this.ClientID, 0);
        }

        private string ShowRaisedDeliveryNote(DataTable dtViewDel, int ItemNo, string DelType, PlaceHolder plhShow)
        {
            int itemNo = ItemNo;
            StringBuilder stringBuilder = new StringBuilder();
            if (dtViewDel.Rows.Count > 0)
            {
                string str = "2 3 2 3px";
                str = (dtViewDel.Rows.Count != 1 ? "2 0 2 1px" : "2 3 2 3px");
                string str1 = string.Concat("divSplitViewDelivery_", itemNo);
                str1 = (DelType.ToLower() != "consolidate" ? string.Concat("divSplitViewDelivery_", itemNo) : string.Concat("divConViewDelivery_", itemNo));
                plhShow.Controls.Add(new LiteralControl(string.Concat("<div id='", str1, "' align='left' style='width: 100%;display: block;padding-bottom: 3px'>")));
                plhShow.Controls.Add(new LiteralControl("<div style='float: left;width: 3%'>&nbsp;</div>"));
                plhShow.Controls.Add(new LiteralControl("<div style='float: left;width: 96%;border: 1px solid #A4A4A4;'>"));
                plhShow.Controls.Add(new LiteralControl("<div style='float: left;width: 100%;height: 27px;background-color: #f1f1f1;color: #000000' class='navigatorpanel'>"));
                plhShow.Controls.Add(new LiteralControl("<div style='float: left; width: 14%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
                plhShow.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Delivery_Note_No")));
                plhShow.Controls.Add(new LiteralControl("</div>"));
                plhShow.Controls.Add(new LiteralControl("<div align='left' style='float: left; width: 10%;padding: 2 3 2 0px;vertical-align: middle;border-right:0px solid white;'>"));
                plhShow.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Created_Date")));
                plhShow.Controls.Add(new LiteralControl("</div>"));
                plhShow.Controls.Add(new LiteralControl(string.Concat("<div style='float: left;text-align: right; width: 12%;padding: ", str, ";vertical-align: middle;border-right:0px solid white;'>")));
                plhShow.Controls.Add(new LiteralControl(string.Concat(this.objLanguage.GetLanguageConversion("Qty"), " ", this.objLanguage.GetLanguageConversion("Delivered"), "&nbsp;&nbsp;")));
                plhShow.Controls.Add(new LiteralControl("</div>"));
                plhShow.Controls.Add(new LiteralControl("<div align='left' style='float: left; width: 11%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                plhShow.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Customer_Order_Number")));
                plhShow.Controls.Add(new LiteralControl("</div>"));
                plhShow.Controls.Add(new LiteralControl("<div style='float: left; width: 12%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                plhShow.Controls.Add(new LiteralControl(string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Status"))));
                plhShow.Controls.Add(new LiteralControl("</div>"));
                plhShow.Controls.Add(new LiteralControl("<div align='left' style='float: left; width: 30%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                plhShow.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Address")));
                plhShow.Controls.Add(new LiteralControl("</div>"));
                plhShow.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                plhShow.Controls.Add(new LiteralControl("</div>"));
                double num = 29;
                num = (dtViewDel.Rows.Count > 5 ? 100 : (double)(29 * dtViewDel.Rows.Count));
                plhShow.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width: 100%;height: ", num, "px;overflow-y: scroll;'>")));
                string str2 = "NewTableRow normalText";
                int num1 = 0;
                foreach (DataRow row in dtViewDel.Rows)
                {
                    str2 = (num1 % 2 != 0 ? "NewAlternative normalText" : "NewTableRow normalText");
                    plhShow.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width: 100%;height: 25px' class='", str2, "'>")));
                    plhShow.Controls.Add(new LiteralControl("<div style='float: left;width: 100%'>"));
                    plhShow.Controls.Add(new LiteralControl("<div style='float: left; width: 14%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
                    ControlCollection controls = plhShow.Controls;
                    object[] objArray = new object[] { "<a href='", this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", row["DeliveryID"].ToString(), "&estid=", row["EstimateID"].ToString(), "&jID=", row["jobID"], "' target='_blank' onclick='javascript: window.blur();' >", row["DeliveryNumber"].ToString(), "</a>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl("<div style='float: left; width: 10%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
                    plhShow.Controls.Add(new LiteralControl(this.commclass.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, this.UserID, false)));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl("<div style='float: left;text-align:right; width: 11%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"));
                    TextBox textBox = new TextBox();
                    object[] objArray1 = new object[] { "txtDelQty_", row["ItemID"].ToString(), "_", num1 };
                    textBox.ID = string.Concat(objArray1);
                    textBox.Width = 80;
                    textBox.SkinID = "textPad";
                    textBox.Style["TEXT-ALIGN"] = TextAlign.Right.ToString();
                    textBox.Text = row["Quantity"].ToString();
                    textBox.AutoCompleteType = AutoCompleteType.Disabled;
                    textBox.MaxLength = 8;
                    textBox.Attributes.Add("onkeyup", "javascript:AllowNumber(this,this.value);");
                    textBox.Attributes.Add("onkeypress", "javascript:AllowNumber(this,this.value);");
                    textBox.Attributes.Add("onfocus", "javascript:this.select()");
                    plhShow.Controls.Add(textBox);
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl("<div style='float: left; width: 12%;padding: 2 3 2 3px;vertical-align: middle;'>"));
                    if (row["OrderNo"].ToString().Length < 13)
                    {
                        row["OrderNo"].ToString();
                    }
                    else
                    {
                        string.Concat(row["OrderNo"].ToString().Substring(0, 13), "...");
                    }
                    plhShow.Controls.Add(new LiteralControl(string.Concat("<div title='", row["OrderNo"].ToString(), "' style='float: left; width: 90%;vertical-align: middle;overflow: hidden;max-width: 90%;white-space: nowrap'>")));
                    plhShow.Controls.Add(new LiteralControl(string.Concat("&nbsp;&nbsp;", row["OrderNo"].ToString())));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl("<div style='float: left; width: 12%;padding: 2 3 2 3px;vertical-align: middle;overflow: hidden;max-width: 12%;'>"));
                    plhShow.Controls.Add(new LiteralControl(string.Concat("&nbsp;<div title='", base.SpecialDecode(row["StatusName"].ToString()), "' style='float: left; width: 90%;vertical-align: middle;overflow: hidden;max-width: 90%;white-space: nowrap'>")));
                    plhShow.Controls.Add(new LiteralControl(base.SpecialDecode(row["StatusName"].ToString())));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl(string.Concat("<div title='", row["Address"].ToString(), "' style='float: left; width: 30%;padding: 2 3 2 3px;vertical-align: middle;overflow: hidden;max-width: 30%;'>")));
                    plhShow.Controls.Add(new LiteralControl("<div style='float: left;'>"));
                    ControlCollection controlCollections = plhShow.Controls;
                    object[] objArray2 = new object[] { "&nbsp;<img id='img_SelectDelAdd_", num1, "' src='../images/plus.gif' title='Select Address' height='15px' width='15px' style='vertical-align: middle;padding-left: 2px;cursor: pointer' onclick=javascript:More_Address_DelRaised('", row["ItemID"].ToString(), "_", num1, "');return false; />&nbsp;" };
                    controlCollections.Add(new LiteralControl(string.Concat(objArray2)));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    if (row["Address"].ToString().Length < 30)
                    {
                        row["Address"].ToString();
                    }
                    else
                    {
                        string.Concat(row["Address"].ToString().Substring(0, 30), "...");
                    }
                    plhShow.Controls.Add(new LiteralControl("<div style='float: left; width: 90%;vertical-align: middle;overflow: hidden;max-width: 90%;white-space: nowrap'>"));
                    ControlCollection controls1 = plhShow.Controls;
                    object[] str3 = new object[] { "<label id='lblDelAdd_", row["ItemID"].ToString(), "_", num1, "'>", row["Address"].ToString(), "</label>" };
                    controls1.Add(new LiteralControl(string.Concat(str3)));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    ControlCollection controlCollections1 = plhShow.Controls;
                    object[] objArray3 = new object[] { "<label id='lblDelAddID_", row["ItemID"].ToString(), "_", num1, "' style='display: none'>", row["DeliveryAddressID"].ToString(), "</label>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(objArray3)));
                    ControlCollection controls2 = plhShow.Controls;
                    object[] str4 = new object[] { "<label id='lblDelAddType_", row["ItemID"].ToString(), "_", num1, "' style='display: none'>", row["DeliveryAddressType"].ToString(), "</label>" };
                    controls2.Add(new LiteralControl(string.Concat(str4)));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl("<div style='float: left; padding: 2 3 2 3px;vertical-align: middle;'>"));
                    ControlCollection controlCollections2 = plhShow.Controls;
                    object[] objArray4 = new object[] { "&nbsp;<img id='img_SaveDelQty_", num1, "' src='../images/save.gif' title='Save' height='13px' width='13px' border='0' style='vertical-align: middle;padding-left: 2px;padding-bottom: 6px;cursor: pointer' onclick=javascript:SaveQtyDelivered(this,'", num1, "','", row["DeliveryID"].ToString(), "','", row["DeliveryItemID"].ToString(), "','", row["ItemID"].ToString(), "','", row["ItemType"].ToString(), "','", row["Quantity"].ToString(), "','", dtViewDel.Rows.Count, "','", itemNo, "','", DelType, "') />&nbsp;" };
                    controlCollections2.Add(new LiteralControl(string.Concat(objArray4)));
                    ControlCollection controls3 = plhShow.Controls;
                    object[] clientID = new object[] { "&nbsp;<a href='javascript:void(0);' title='Print/Email' onclick=javascript:OpenTemplateWin('", this.strSitepath, "delivery/templates_view1.aspx?sectionid=", this.ClientID, "&sectionname=DeliveryNote&type=Customer&page=Note&EstID=", row["DeliveryID"].ToString(), "&frm=delnote');window.blur(); ><img src='", this.strImagepath, "ico-print.gif' width='15px' height='15px' border='0' /></a>" };
                    controls3.Add(new LiteralControl(string.Concat(clientID)));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    plhShow.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    plhShow.Controls.Add(new LiteralControl("</div>"));
                    num1++;
                }
                plhShow.Controls.Add(new LiteralControl("</div>"));
                plhShow.Controls.Add(new LiteralControl("</div>"));
                plhShow.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                plhShow.Controls.Add(new LiteralControl("</div>"));
            }
            return stringBuilder.ToString();
        }
    }
}