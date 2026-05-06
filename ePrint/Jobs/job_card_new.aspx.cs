using Item;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.Jobs
{
    public partial class job_card_new : BaseClass, IRequiresSessionState
    {
        //protected Button btnSaveAndPrint;

        //protected Label lblJCjobNumber;

        //protected HtmlGenericControl spnEstimateNumber;

        //protected Label lblJCEstNumber;

        //protected Label lblJCquantity;

        //protected Panel pnlFinishedQty;

        //protected Label lblJCtitle;

        //protected Label lblJCcustomer;

        //protected Label lblDeliveryAddress;

        //protected HtmlTableRow trheader;

        //protected TextBox txtReqArtwork;

        //protected TextBox txtActArtwork;

        //protected HtmlTableRow trArtworkDate;

        //protected TextBox txtReqProof;

        //protected TextBox txtActProof;

        //protected HtmlTableRow trProofDate;

        //protected TextBox txtReqApproval;

        //protected TextBox txtActApproval;

        //protected HtmlTableRow div_ApprovalNew;

        //protected TextBox txtReqProduction;

        //protected TextBox txtActProduction;

        //protected HtmlTableRow divProductionDate;

        //protected TextBox txtReqDelivery;

        //protected TextBox txtActDelivery;

        //protected HtmlTableRow div_JobcardDeliverydate;

        //protected TextBox txtEstJobTime;

        //protected TextBox txtActJobTime;

        //protected HtmlTableRow jobtime_tr;

        //protected Label lbl_prepress;

        //protected TextBox txtReqPrePress;

        //protected Label lblReqPrePress;

        //protected TextBox txtActPrePress;

        //protected HtmlTableRow tr_Pre_Press;

        //protected Label lbl_press;

        //protected TextBox txtReqPress;

        //protected Label lblReqPress;

        //protected TextBox txtActPress;

        //protected HtmlTableRow tr_Press;

        //protected Label lbl_postpress;

        //protected TextBox txtReqPostPress;

        //protected Label lblReqPostPress;

        //protected TextBox txtActPostPress;

        //protected HtmlTableRow tr_Post_Press;

        //protected Label lbl_Warehouse;

        //protected TextBox txtReqWarehouse;

        //protected Label lblReqWarehouse;

        //protected TextBox txtActwarehouse;

        //protected Panel pnlWarehouse;

        //protected Label lbl_PriceCatalogue;

        //protected TextBox txtReqPriceCatalogue;

        //protected Label lblReqPriceCatalogue;

        //protected TextBox txtActPriceCatalogue;

        //protected Panel pnlPriceCatalogue;

        //protected Label lbl_Outwork;

        //protected TextBox txtReqOutwork;

        //protected Label lblReqOutwork;

        //protected TextBox txtActOutwork;

        //protected Panel pnlOutwork;

        //protected Label Label1;

        //protected TextBox txtReqAdmin;

        //protected Label lblreqAdmin;

        //protected TextBox txtActAdmin;

        //protected Panel pnlAdmin;

        //protected Label Label2;

        //protected TextBox txtReqPaper;

        //protected Label lblreqPaper;

        //protected TextBox txtActPaper;

        //protected HtmlTableRow tr_Paper;

        //protected Panel PnlPaper;

        //protected Label Label3;

        //protected TextBox txtReqInk;

        //protected Label lblreqInk;

        //protected TextBox txtActInk;

        //protected HtmlTableRow tr_ink;

        //protected Panel PnlInk;

        //protected Label Label4;

        //protected TextBox txtReqPlates;

        //protected Label lblreqPlates;

        //protected TextBox txtActPlates;

        //protected HtmlTableRow tr_Plates;

        //protected Panel PnlPlates;

        //protected Label Label5;

        //protected TextBox txtReqGuillotine;

        //protected Label lblreqGuillotine;

        //protected TextBox txtActGuillotine;

        //protected HtmlTableRow tr_Guillotine;

        //protected Panel PnlGuillotine;

        //protected Label Label6;

        //protected TextBox txtReqWashUp;

        //protected Label lblreqWashUp;

        //protected TextBox txtActWashUp;

        //protected HtmlTableRow tr_washup;

        //protected Panel PnlWashUp;

        //protected Label Label7;

        //protected TextBox txtReqMakeReady;

        //protected Label lblreqMakeReady;

        //protected TextBox txtActMakeReady;

        //protected HtmlTableRow tr_makeready;

        //protected Panel PnlMakeReady;

        //protected Button btncancel;

        //protected Button btnSave;

        //protected Button btn1;

        //protected HiddenField hidSaveType;

        //protected HiddenField hidCompanyID;

        //protected HtmlTableRow tr_allbuttons;

        //protected Button btnOk;

        //protected HtmlTableRow tr_okbutton;

        //protected Panel pnlPrint;

        //protected Panel pnl_closePopup;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private BasePage objpage = new BasePage();

        public languageClass objLangauge = new languageClass();

        public int CompanyID;

        public int userID;

        public long EstimateID;

        public int EstimateItemID;

        private long TypeID;

        private short QtyNumber;

        public string DateFormat = string.Empty;

        private string EstimateType = string.Empty;

        private int JobcardID;

        private decimal PaperHeight;

        private decimal PaperWidth;

        private decimal SheetHeight;

        private decimal SheetWidth;

        private decimal JobHeight;

        private decimal JobWidth;

        private decimal PrintLayout;

        private decimal RunningSpoilage;

        private decimal SetUpSpoilage;

        private decimal TotalRunningSpoilage;

        private decimal TotalPaper;

        private string IsAnyWarehouseItem = string.Empty;

        private string IsAnyOutwork = string.Empty;

        private string IsAnyOtherCost = string.Empty;

        private long EstTypeID;

        private string WarehouseTypeID = string.Empty;

        private string WarehouseType = string.Empty;

        private string WarehousQuantity = string.Empty;

        private string[] aryWarehouseTypeID;

        private string[] aryWarehouseType;

        private string[] aryWarehouseQuantity;

        private string WarehouseItemName_Quantity = string.Empty;

        private string OtherCostID = string.Empty;

        private string[] aryOtherCostID;

        private string WarehouseItemID = string.Empty;

        private string MainWarehouseTypeID = string.Empty;

        private string MainWarehouseType = string.Empty;

        private string MainWarehouseQuantity = string.Empty;

        private string[] aryWarehouseID;

        private string[] aryMainWarehouseTypeID;

        private string[] aryMainWarehouseType;

        private string[] aryMainWarehouseQuantity;

        private long EstBookletItemID;

        private decimal NoOfSignatures;

        private decimal PagesPerSignature;

        private string EstItemOutworkID = string.Empty;

        private string[] aryEstItemOutworkID;

        private string MainWarehouseItemName_Quantity = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private ItemClass obj = new ItemClass();

        private commonClass comm = new commonClass();

        public string serverName = ConnectionClass.ServerName;

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private bool IsFirstTrim;

        private bool IsSecondTrim;

        private bool IsIncludeGutters;

        public string newdate = string.Empty;

        private string LayoutType = string.Empty;

        private string PressName = string.Empty;

        public int CustomerID;

        public string CompanyType = string.Empty;

        public string ordid = string.Empty;

        public long JobID;

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

        public job_card_new()
        {
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            BaseClass baseClass = new BaseClass();
            string str = "1/1/1900";
            string str1 = "1/1/1900";
            string str2 = "1/1/1900";
            string str3 = "1/1/1900";
            string str4 = "1/1/1900";
            string str5 = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtReqArtwork.Text));
            if (this.txtActArtwork.Text != "")
            {
                str = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtActArtwork.Text));
            }
            string str6 = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtReqApproval.Text));
            if (this.txtActApproval.Text != "")
            {
                str1 = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtActApproval.Text));
            }
            string str7 = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtReqProof.Text));
            if (this.txtActProof.Text != "")
            {
                str2 = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtActProof.Text));
            }
            string str8 = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtReqProduction.Text));
            if (this.txtActProduction.Text != "")
            {
                str3 = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtActProduction.Text));
            }
            string str9 = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtReqDelivery.Text));
            if (this.txtActDelivery.Text != "")
            {
                str4 = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtActDelivery.Text));
            }
            if (this.txtActJobTime.Text.Trim().Length < 1)
            {
                this.txtActJobTime.Text = "0";
            }
            JobBasePage.Jobs_Jobcard_Update(this.CompanyID, this.EstimateItemID, Convert.ToDateTime(str5), Convert.ToDateTime(str), Convert.ToDateTime(str6), Convert.ToDateTime(str1), Convert.ToDateTime(str7), Convert.ToDateTime(str2), Convert.ToDateTime(str8), Convert.ToDateTime(str3), Convert.ToDateTime(str9), Convert.ToDateTime(str4), base.ReplaceSingleQuote(this.txtReqPrePress.Text), base.ReplaceSingleQuote(this.txtActPrePress.Text), base.ReplaceSingleQuote(this.txtReqPress.Text), base.ReplaceSingleQuote(this.txtActPress.Text), base.ReplaceSingleQuote(this.txtReqPostPress.Text), base.ReplaceSingleQuote(this.txtActPostPress.Text), base.ReplaceSingleQuote(this.txtReqWarehouse.Text), base.ReplaceSingleQuote(this.txtActwarehouse.Text), base.ReplaceSingleQuote(this.txtReqOutwork.Text), base.ReplaceSingleQuote(this.txtActOutwork.Text), base.ReplaceSingleQuote(this.txtReqPriceCatalogue.Text), base.ReplaceSingleQuote(this.txtActPriceCatalogue.Text), base.ReplaceSingleQuote(this.txtReqAdmin.Text), base.ReplaceSingleQuote(this.txtActAdmin.Text), base.ReplaceSingleQuote(this.txtReqPaper.Text), base.ReplaceSingleQuote(this.txtReqInk.Text), base.ReplaceSingleQuote(this.txtReqPlates.Text), base.ReplaceSingleQuote(this.txtReqGuillotine.Text), base.ReplaceSingleQuote(this.txtReqWashUp.Text), base.ReplaceSingleQuote(this.txtReqMakeReady.Text), base.ReplaceSingleQuote(this.txtActPaper.Text), base.ReplaceSingleQuote(this.txtActInk.Text), base.ReplaceSingleQuote(this.txtActPlates.Text), base.ReplaceSingleQuote(this.txtActGuillotine.Text), base.ReplaceSingleQuote(this.txtActWashUp.Text), base.ReplaceSingleQuote(this.txtActMakeReady.Text), Convert.ToDecimal(this.txtActJobTime.Text));
            string empty = string.Empty;
            DataTable dataTable = Notes.select_item_number_for_Activity_History(this.JobID, (long)this.EstimateItemID, "job");
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["rownumber"].ToString();
            }
            this.objnotes.Item_number = string.Concat("Item ", empty);
            this.objnotes.Item_title = this.lblJCtitle.Text;
            this.objnotes.ModuleName = "job";
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobCardEdit);
            this.objnotes.ModuleID = this.JobID;
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass1 = this.comm;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.userID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.userID;
            this.objN.NotesAdd(this.objnotes);
            if (this.hidSaveType.Value != "print")
            {
                this.pnl_closePopup.Visible = true;
                return;
            }
            this.Session["TemplateHTML"] = null;
            this.Session["TemplateControlList"] = null;
            this.Session["TemplateID"] = null;
            this.pnlPrint.Visible = true;
        }

        public void CalculateBooklet()
        {
            string str = string.Concat("SELECT EstBookletItemID,IsAnyWarehouseItem,IsAnyOutwork,IsAnyotherCost from tb_EstBookletItem where EstimateItemID=", this.EstimateItemID);
            DataTable dataTable = JobBasePage.Jobs_PressDetails_select(this.CompanyID, str);
            string empty = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                this.IsAnyWarehouseItem = row["IsAnyWarehouseItem"].ToString();
                this.IsAnyOutwork = row["IsAnyOutwork"].ToString();
                this.IsAnyOtherCost = row["IsAnyotherCost"].ToString();
                this.EstBookletItemID = (long)Convert.ToInt32(row["EstBookletItemID"].ToString());
            }
            if (this.IsAnyWarehouseItem == "Y")
            {
                this.pnlWarehouse.Visible = true;
            }
            if (this.IsAnyOutwork == "Y")
            {
                this.pnlOutwork.Visible = true;
            }
        }

        public void CalculateGuillotine(int PrintSheetsRequired)
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            string str = "No";
            string str1 = "No";
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            foreach (DataRow row in JobBasePage.Jobs_GuillotineDetails_Select(this.CompanyID, (long)this.EstimateItemID).Rows)
            {
                num = Convert.ToDecimal(row["GuillotinePaperWeight1"].ToString());
                num1 = Convert.ToDecimal(row["GuillotinePaperWeight2"].ToString());
                num2 = Convert.ToDecimal(row["GuillotinePaperWeight3"].ToString());
                num3 = Convert.ToDecimal(row["GuillotineMaximumThroat1"].ToString());
                num4 = Convert.ToDecimal(row["GuillotineMaximumThroat2"].ToString());
                num5 = Convert.ToDecimal(row["GuillotineMaximumThroat3"].ToString());
                num7 = Convert.ToDecimal(row["PaperWeight"].ToString());
            }
            if (num7 <= num)
            {
                num6 = num3;
            }
            else if (num7 <= num1)
            {
                num6 = num4;
            }
            else if (num7 <= num2 || num7 > num2)
            {
                num6 = num5;
            }
            if (this.IsFirstTrim)
            {
                str = "Yes";
                num9 = EstimateBasePage.Guillotine_First_Trim_Cut(this.PaperHeight, this.PaperWidth, this.SheetHeight, this.SheetWidth, num7, this.LayoutType, Convert.ToDecimal(this.TotalPaper), num, num3, num1, num4, num2, num5, ref num10);
            }
            if (this.IsSecondTrim)
            {
                if (num6 != new decimal(0))
                {
                    num11 = Convert.ToDecimal(Math.Ceiling(PrintSheetsRequired / Convert.ToDecimal(num6)));
                }
                if (num11 == new decimal(0))
                {
                    num11 = new decimal(1);
                }
                decimal num12 = EstimateBasePage.Estimate_Summary_Guillotine_Standard_Table(this.CompanyID, this.PrintLayout, (this.IsIncludeGutters ? "yes" : "no"));
                num8 = num12 * num11;
                str1 = "Yes";
            }
            TextBox textBox = this.txtReqPostPress;
            string[] text = new string[] { this.txtReqPostPress.Text, "Print Sheet Size:= ", this.SheetHeight.ToString(), " x ", this.SheetWidth.ToString(), ";\n" };
            textBox.Text = string.Concat(text);
            TextBox textBox1 = this.txtReqPostPress;
            string[] strArrays = new string[] { this.txtReqPostPress.Text, "Job Sheet Size:=", this.JobHeight.ToString(), " x ", this.JobWidth.ToString(), ";\n" };
            textBox1.Text = string.Concat(strArrays);
            this.txtReqPostPress.Text = string.Concat(this.txtReqPostPress.Text, "First Trim:=", str);
            if (str == "Yes")
            {
                TextBox textBox2 = this.txtReqPostPress;
                object[] objArray = new object[] { this.txtReqPostPress.Text, ", ", num9, " cuts, ", num10, " bundles;" };
                textBox2.Text = string.Concat(objArray);
            }
            this.txtReqPostPress.Text = string.Concat(this.txtReqPostPress.Text, "\nSecond Trim:=", str1);
            if (str1 == "Yes")
            {
                TextBox textBox3 = this.txtReqPostPress;
                object[] text1 = new object[] { this.txtReqPostPress.Text, ", ", num8, " cuts, ", num11, " bundles" };
                textBox3.Text = string.Concat(text1);
            }
        }

        public void CalculateOtherCost()
        {
            foreach (DataRow row in JobBasePage.Jobs_OtherCostMainItems_Select(this.CompanyID, (long)this.EstimateItemID).Rows)
            {
                this.MainWarehouseType = string.Concat(this.MainWarehouseType, row["CalculationType"].ToString(), ",");
                this.MainWarehouseTypeID = string.Concat(this.MainWarehouseTypeID, row["OtherCostID"].ToString(), ",");
                this.MainWarehouseQuantity = string.Concat(this.MainWarehouseQuantity, row["HoursOrQty"].ToString(), ",");
            }
            string mainWarehouseTypeID = this.MainWarehouseTypeID;
            char[] chrArray = new char[] { ',' };
            this.aryMainWarehouseTypeID = mainWarehouseTypeID.Split(chrArray);
            string mainWarehouseType = this.MainWarehouseType;
            char[] chrArray1 = new char[] { ',' };
            this.aryMainWarehouseType = mainWarehouseType.Split(chrArray1);
            string mainWarehouseQuantity = this.MainWarehouseQuantity;
            char[] chrArray2 = new char[] { ',' };
            this.aryMainWarehouseQuantity = mainWarehouseQuantity.Split(chrArray2);
            for (int i = 0; i < (int)this.aryMainWarehouseTypeID.Length - 1; i++)
            {
                DataTable dataTable = JobBasePage.Jobs_OtherCostItemDetails_Select(this.CompanyID, Convert.ToInt64(this.aryMainWarehouseTypeID[i].ToString()));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (this.MainWarehouseType[i].ToString() != "q")
                    {
                        string[] mainWarehouseItemNameQuantity = new string[] { this.MainWarehouseItemName_Quantity, "Name=:", dataRow["OtherCostName"].ToString(), "\n Description:=", dataRow["Description"].ToString(), "\n Hours:=", this.aryMainWarehouseQuantity[i].ToString(), "\n" };
                        this.MainWarehouseItemName_Quantity = string.Concat(mainWarehouseItemNameQuantity);
                    }
                    else
                    {
                        string[] strArrays = new string[] { this.MainWarehouseItemName_Quantity, "Name=:", dataRow["OtherCostName"].ToString(), "\n Description:=", dataRow["Description"].ToString(), "\n Quantity:=", this.aryMainWarehouseQuantity[i].ToString().Substring(0, this.aryMainWarehouseQuantity[i].Length - 3), "\n" };
                        this.MainWarehouseItemName_Quantity = string.Concat(strArrays);
                    }
                }
            }
            this.txtReqPrePress.Text = this.MainWarehouseItemName_Quantity;
        }

        public void CalculateOtherCostItems(long estTypeId)
        {
        }

        public void CalculateOutwork()
        {
            foreach (DataRow row in JobBasePage.Jobs_OutworkMainItem_Select(this.CompanyID, (long)this.EstimateItemID).Rows)
            {
                TextBox textBox = this.txtReqOutwork;
                string[] str = new string[] { "Design=:", row["Design"].ToString(), "\n Color=:", row["Colour"].ToString(), "\n Size=:", row["Size"].ToString(), "\n Materials=:", row["Materials"].ToString(), "\n Finishing=:", row["Finishing"].ToString(), "\n Delivery=:", row["Delivery"].ToString(), "\n Notes=:", row["Notes"].ToString(), "\n" };
                textBox.Text = string.Concat(str);
            }
        }

        public void CalculateOutworkItems(long estTypeId, string EstType)
        {
            foreach (DataRow row in JobBasePage.Jobs_OutworkItems_Select(this.CompanyID, estTypeId, EstType).Rows)
            {
                this.EstItemOutworkID = string.Concat(this.EstItemOutworkID, row["EstItemOutworkID"].ToString(), ",");
            }
            string estItemOutworkID = this.EstItemOutworkID;
            char[] chrArray = new char[] { ',' };
            this.aryEstItemOutworkID = estItemOutworkID.Split(chrArray);
            for (int i = 0; i < (int)this.aryEstItemOutworkID.Length - 1; i++)
            {
                int num = i + 1;
                string str = string.Concat("Item", num, "\n");
                DataTable dataTable = JobBasePage.Jobs_OutworkItemDescription_Select(this.CompanyID, Convert.ToInt64(this.aryEstItemOutworkID[i].ToString()));
                this.txtReqOutwork.Text = string.Concat(this.txtReqOutwork.Text, str);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    TextBox textBox = this.txtReqOutwork;
                    string[] text = new string[] { this.txtReqOutwork.Text, dataRow["Label"].ToString(), "=:", dataRow["Description"].ToString(), " " };
                    textBox.Text = string.Concat(text);
                }
                this.txtReqOutwork.Text = string.Concat(this.txtReqOutwork.Text, "\n");
            }
        }

        public void CalculateWarehouse()
        {
            foreach (DataRow row in JobBasePage.Jobs_WarehouseMainItems_Slect(this.CompanyID, (long)this.EstimateItemID).Rows)
            {
                this.MainWarehouseType = string.Concat(this.MainWarehouseType, row["WarehouseType"].ToString(), ",");
                this.MainWarehouseTypeID = string.Concat(this.MainWarehouseTypeID, row["WarehouseTypeID"].ToString(), ",");
                this.MainWarehouseQuantity = string.Concat(this.MainWarehouseQuantity, row["Quantity"].ToString(), ",");
            }
            string mainWarehouseQuantity = this.MainWarehouseQuantity;
            char[] chrArray = new char[] { ',' };
            this.aryMainWarehouseQuantity = mainWarehouseQuantity.Split(chrArray);
            string mainWarehouseType = this.MainWarehouseType;
            char[] chrArray1 = new char[] { ',' };
            this.aryMainWarehouseType = mainWarehouseType.Split(chrArray1);
            string mainWarehouseTypeID = this.MainWarehouseTypeID;
            char[] chrArray2 = new char[] { ',' };
            this.aryMainWarehouseTypeID = mainWarehouseTypeID.Split(chrArray2);
            for (int i = 0; i < (int)this.aryMainWarehouseTypeID.Length - 1; i++)
            {
                DataTable dataTable = JobBasePage.Jobs_WarehouseItemName_Slect(this.CompanyID, Convert.ToInt64(this.aryMainWarehouseTypeID[i].ToString()), this.aryMainWarehouseType[i].ToString());
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string[] warehouseItemNameQuantity = new string[] { this.WarehouseItemName_Quantity, "Item=:", dataRow["WarehouseName"].ToString(), "\n Quantity:=", this.aryMainWarehouseQuantity[i].ToString(), "\n" };
                    this.WarehouseItemName_Quantity = string.Concat(warehouseItemNameQuantity);
                }
            }
            this.txtReqWarehouse.Text = this.WarehouseItemName_Quantity;
        }

        public void CalculateWarehouseItems(long estTypeId, string EstimateType)
        {
            foreach (DataRow row in JobBasePage.Jobs_WarehouseItems_Slect(this.companyid, estTypeId, EstimateType).Rows)
            {
                this.WarehouseType = string.Concat(this.WarehouseType, row["WarehouseType"].ToString(), ",");
                this.WarehouseTypeID = string.Concat(this.WarehouseTypeID, row["WarehouseTypeID"].ToString(), ",");
                this.WarehousQuantity = string.Concat(this.WarehousQuantity, row["Quantity"].ToString(), ",");
            }
            string warehouseTypeID = this.WarehouseTypeID;
            char[] chrArray = new char[] { ',' };
            this.aryWarehouseTypeID = warehouseTypeID.Split(chrArray);
            string warehouseType = this.WarehouseType;
            char[] chrArray1 = new char[] { ',' };
            this.aryWarehouseType = warehouseType.Split(chrArray1);
            string warehousQuantity = this.WarehousQuantity;
            char[] chrArray2 = new char[] { ',' };
            this.aryWarehouseQuantity = warehousQuantity.Split(chrArray2);
            this.WarehouseItemName_Quantity = "";
            this.txtReqWarehouse.Text = "";
            for (int i = 0; i < (int)this.aryWarehouseTypeID.Length - 1; i++)
            {
                DataTable dataTable = JobBasePage.Jobs_WarehouseItemName_Slect(this.CompanyID, Convert.ToInt64(this.aryWarehouseTypeID[i].ToString()), this.aryWarehouseType[i].ToString());
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string[] warehouseItemNameQuantity = new string[] { this.WarehouseItemName_Quantity, "Item=:", dataRow["WarehouseName"].ToString(), "\n Quantity:=", this.aryWarehouseQuantity[i].ToString(), "\n" };
                    this.WarehouseItemName_Quantity = string.Concat(warehouseItemNameQuantity);
                }
            }
            this.txtReqWarehouse.Text = string.Concat(this.txtReqWarehouse.Text, this.WarehouseItemName_Quantity);
        }

        protected new string date_Check(string DateFormat, string txtvalue)
        {
            string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
            if (txtvalue != "")
            {
                if (DateFormat == "dd/mm/yyyy")
                {
                    string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                    txtvalue = string.Concat(strArrays1);
                }
                else if (DateFormat == "mm/dd/yyyy")
                {
                    string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
                    txtvalue = string.Concat(strArrays2);
                }
            }
            return txtvalue;
        }

        protected string date_Check_new(string DateFormatt, string txtvalue)
        {
            try
            {
                string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
                if (this.DateFormat == "mm/dd/yyyy")
                {
                    if (DateFormatt == "dd/mm/yyyy")
                    {
                        string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays1);
                    }
                    else if (DateFormatt == "mm/dd/yyyy")
                    {
                        string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays2);
                    }
                }
                if (this.DateFormat == "dd/mm/yyyy")
                {
                    if (DateFormatt == "dd/mm/yyyy")
                    {
                        string[] strArrays3 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays3);
                    }
                    else if (DateFormatt == "mm/dd/yyyy")
                    {
                        string[] strArrays4 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays4);
                    }
                }
            }
            catch
            {
                txtvalue = "1/1/1900";
            }
            return txtvalue;
        }

        public DataTable ItemTitle(string EstimateType)
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
                str = "EstPriceCatalogueID";
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
                empty = "TABLE_EstimateLithoBookletItem";
                str = "EstimateLithoBookletItemID";
            }
            else if (EstimateType == "Q")
            {
                empty = "TABLE_EstimateQuickQuote";
                str = "QuickQuoteID";
            }
            else if (EstimateType.ToLower() == "x")
            {
                empty = "TABLE_OrderItems";
                str = "OrderItemID";
            }
            object[] estimateItemID = new object[] { "select ", str, " as TypeID, ItemTitle from ", empty, " where EstimateItemID=", this.EstimateItemID };
            string str1 = string.Concat(estimateItemID);
            return JobBasePage.Jobs_ItemTitle_select(this.CompanyID, str1);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("job");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.EstimateID = Convert.ToInt64(base.Request.Params["EstimateID"]);
            this.JobID = Convert.ToInt64(base.Request.Params["jID"]);
            this.EstimateItemID = Convert.ToInt32(base.Request.Params["EstItemID"]);
            this.DateFormat = this.objpage.GetRegionalSettings(this.CompanyID, "Dateformat");
            this.userID = Convert.ToInt32(this.Session["UserID"]);
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(base.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            this.btnSaveAndPrint.Text = this.objLangauge.GetLanguageConversion("Save_Print_Email");
            this.spnEstimateNumber.InnerHtml = this.objLangauge.GetLanguageConversion("Estimate_Number");
            this.btncancel.Text = this.objLangauge.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLangauge.GetLanguageConversion("Save");
            this.btn1.Text = this.objLangauge.GetLanguageConversion("Save_Print_Email");
            if (ConnectionClass.DeliveryNote == null)
            {
                this.div_JobcardDeliverydate.Visible = false;
            }
            else
            {
                this.div_JobcardDeliverydate.Visible = true;
            }
            bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
            if (ConnectionClass.Is_Non_Printing_System)
            {
                this.tr_Pre_Press.Attributes.Add("style", "display:none");
                this.tr_Press.Attributes.Add("style", "display:none");
                this.tr_Post_Press.Attributes.Add("style", "display:none");
                this.tr_Paper.Attributes.Add("style", "display:none");
                this.tr_ink.Attributes.Add("style", "display:none");
                this.tr_Plates.Attributes.Add("style", "display:none");
                this.tr_Guillotine.Attributes.Add("style", "display:none");
                this.tr_washup.Attributes.Add("style", "display:none");
                this.tr_makeready.Attributes.Add("style", "display:none");
            }
            int num = 0;
            if (ConnectionClass.Progresstojobdates != null)
            {
                num = Convert.ToInt32(ConnectionClass.Progresstojobdates);
            }
            commonClass _commonClass = this.comm;
            DateTime dateTime1 = DateTime.Now.AddDays((double)num);
            _commonClass.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.userID, true);
            DataTable dataTable = JobsBasePage.Select_jobcard_Details_forOrders(this.CompanyID, this.EstimateID, (long)this.EstimateItemID);
            foreach (DataRow row in dataTable.Rows)
            {
                this.ordid = row["OrderID"].ToString();
            }
            if (!base.IsPostBack)
            {
                this.txtReqPress.Attributes.Add("style", "display:block");
                this.lblReqPrePress.Attributes.Add("style", "display:none");
                this.lblReqPress.Attributes.Add("style", "display:none");
                this.lblReqPostPress.Attributes.Add("style", "display:none");
                this.lblReqWarehouse.Attributes.Add("style", "display:none");
                this.lblReqPriceCatalogue.Attributes.Add("style", "display:none");
                this.lblReqOutwork.Attributes.Add("style", "display:none");
                DataTable dataTable1 = JobsBasePage.Jobs_Jobcard_Jobdetails_ByJobID_select(this.CompanyID, this.JobID);
                foreach (DataRow dataRow in EstimatesBasePage.estimate_select_summary(this.CompanyID, this.EstimateID).Rows)
                {
                    this.lblDeliveryAddress.Text = base.SpecialDecode(dataRow["DeliveryAddress"].ToString());
                }
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    this.lblJCjobNumber.Text = row1["JobNumber"].ToString();
                    this.lblJCEstNumber.Text = row1["EstimateNumber"].ToString();
                    this.lblJCcustomer.Text = base.SpecialDecode(row1["CustomerName"].ToString());
                    this.CustomerID = Convert.ToInt32(row1["CustomerID"].ToString());
                    this.hidCompanyID.Value = this.CustomerID.ToString();
                    this.CompanyType = row1["CompanyType"].ToString();
                }
                this.EstimateType = JobBasePage.Jobs_EstimateType_select(this.CompanyID, this.EstimateItemID);
                if (this.EstimateType.ToLower() != "x")
                {
                    foreach (DataRow dataRow1 in this.ItemTitle(this.EstimateType).Rows)
                    {
                        this.lblJCtitle.Text = base.SpecialDecode(dataRow1["ItemTitle"].ToString());
                        this.TypeID = Convert.ToInt64(dataRow1["TypeID"].ToString());
                    }
                }
                else
                {
                    this.btn1.Visible = false;
                    DataTable dataTable2 = JobsBasePage.Select_jobcard_Details_forOrders(this.CompanyID, this.EstimateID, (long)this.EstimateItemID);
                    foreach (DataRow row2 in dataTable2.Rows)
                    {
                        this.ordid = row2["OrderID"].ToString();
                        this.spnEstimateNumber.InnerHtml = this.objLangauge.GetLanguageConversion("Order_Number");
                        this.lblJCEstNumber.Text = row2["OrderNo"].ToString();
                        this.lblJCquantity.Text = row2["Quantity"].ToString();
                        string str = row2["ItemDesc"].ToString();
                        string[] strArrays = str.Split(new char[] { 'µ' });
                        for (int i = 0; i < (int)strArrays.Length; i++)
                        {
                            if (strArrays[i] != "")
                            {
                                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                                strArrays1[3] = (strArrays1[3].ToString().ToLower() == "true" ? "True" : "False");
                                if (string.Compare(strArrays1[0].Trim(), "ItemTitle", true) == 0)
                                {
                                    this.lblJCtitle.Text = base.SpecialDecode(strArrays1[2].ToString());
                                }
                            }
                        }
                    }
                }
                foreach (DataRow dataRow2 in JobBasePage.Jobs_Jobcard_details_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    this.txtReqApproval.Text = this.comm.Eprint_return_Date_Before_View(dataRow2["ReqApprovalDate"].ToString(), this.CompanyID, this.userID, false);
                    this.txtReqArtwork.Text = this.comm.Eprint_return_Date_Before_View(dataRow2["ReqArtworkDate"].ToString(), this.CompanyID, this.userID, false);
                    this.txtReqDelivery.Text = this.comm.Eprint_return_Date_Before_View(dataRow2["ReqDeliveryDate"].ToString(), this.CompanyID, this.userID, false);
                    this.txtReqProduction.Text = this.comm.Eprint_return_Date_Before_View(dataRow2["ReqProductionDate"].ToString(), this.CompanyID, this.userID, false);
                    this.txtReqProof.Text = this.comm.Eprint_return_Date_Before_View(dataRow2["ReqProofDate"].ToString(), this.CompanyID, this.userID, false);
                    this.txtReqPriceCatalogue.Text = this.comm.Eprint_return_Date_Before_View(dataRow2["ReqPriceCatalogue"].ToString(), this.CompanyID, this.userID, false);
                    try
                    {
                        this.txtActApproval.Text = (dataRow2["ActApprovalDate"].ToString() == "01/01/1900" ? "" : this.comm.Eprint_return_Date_Before_View(dataRow2["ActApprovalDate"].ToString(), this.CompanyID, this.userID, false));
                        this.txtActArtwork.Text = (dataRow2["ActArtworkDate"].ToString() == "01/01/1900" ? "" : this.comm.Eprint_return_Date_Before_View(dataRow2["ActArtworkDate"].ToString(), this.CompanyID, this.userID, false));
                        this.txtActDelivery.Text = (dataRow2["ActDeliveryDate"].ToString() == "01/01/1900" ? "" : this.comm.Eprint_return_Date_Before_View(dataRow2["ActDeliveryDate"].ToString(), this.CompanyID, this.userID, false));
                        this.txtActProduction.Text = (dataRow2["ActProductionDate"].ToString() == "01/01/1900" ? "" : this.comm.Eprint_return_Date_Before_View(dataRow2["ActProductionDate"].ToString(), this.CompanyID, this.userID, false));
                        this.txtActProof.Text = (dataRow2["ActProofDate"].ToString() == "01/01/1900" ? "" : this.comm.Eprint_return_Date_Before_View(dataRow2["ActProofDate"].ToString(), this.CompanyID, this.userID, false));
                    }
                    catch
                    {
                    }
                    this.txtReqPrePress.Text = dataRow2["ReqPrePress"].ToString().Replace("</b>", "").Replace("<b>", "").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<u>", "").Replace("</u>", "");
                    this.txtReqPress.Text = dataRow2["ReqPress"].ToString().Replace("</b>", "").Replace("<b>", "").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<u>", "").Replace("</u>", "");
                    this.txtReqPostPress.Text = dataRow2["ReqPostPress"].ToString().Replace("</b>", "").Replace("<b>", "").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<u>", "").Replace("</u>", "");
                    this.lblReqPrePress.Text = dataRow2["ReqPrePress"].ToString();
                    this.lblReqPress.Text = dataRow2["ReqPress"].ToString();
                    this.lblReqPostPress.Text = dataRow2["ReqPostPress"].ToString();
                    this.txtReqWarehouse.Text = dataRow2["ReqWarehouse"].ToString().Replace("</b>", "").Replace("<b>", "").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<u>", "").Replace("</u>", "");
                    this.txtReqOutwork.Text = dataRow2["ReqOutwork"].ToString().Replace("</b>", "").Replace("<b>", "").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<u>", "").Replace("</u>", "");
                    this.txtReqPriceCatalogue.Text = dataRow2["ReqPriceCatalogue"].ToString().Replace("</b>", "").Replace("<b>", "").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<u>", "").Replace("</u>", "");
                    this.txtReqAdmin.Text = dataRow2["ReqAdmin"].ToString().Replace("</b>", "").Replace("<b>", "").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<u>", "").Replace("</u>", "");
                    this.lblreqAdmin.Text = dataRow2["ReqAdmin"].ToString().Replace("</b>", "").Replace("<b>", "").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<u>", "").Replace("</u>", "");
                    this.txtActAdmin.Text = dataRow2["ActAdmin"].ToString().Replace("</b>", "").Replace("<b>", "").Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<u>", "").Replace("</u>", "");
                    this.lblReqWarehouse.Text = dataRow2["ReqWarehouse"].ToString();
                    this.lblReqOutwork.Text = dataRow2["ReqOutwork"].ToString();
                    this.lblReqPriceCatalogue.Text = dataRow2["ReqPriceCatalogue"].ToString();
                    this.txtActPrePress.Text = dataRow2["ActPrePress"].ToString();
                    this.txtActPress.Text = dataRow2["ActPress"].ToString();
                    this.txtActPostPress.Text = dataRow2["ActPostPress"].ToString();
                    this.txtActwarehouse.Text = dataRow2["ActWarehouse"].ToString();
                    this.txtActPriceCatalogue.Text = dataRow2["ActPriceCatalogue"].ToString();
                    this.txtActOutwork.Text = dataRow2["ActOutwork"].ToString();
                    this.QtyNumber = Convert.ToInt16(dataRow2["QtyNumber"].ToString());
                    this.JobcardID = Convert.ToInt32(dataRow2["JobcardID"].ToString());
                    this.txtReqPaper.Text = dataRow2["ReqPaper"].ToString();
                    this.txtReqInk.Text = dataRow2["ReqInk"].ToString();
                    this.txtReqPlates.Text = dataRow2["ReqPlates"].ToString();
                    this.txtReqGuillotine.Text = dataRow2["ReqGuillotine"].ToString();
                    this.txtReqWashUp.Text = dataRow2["ReqWashUp"].ToString();
                    this.txtReqMakeReady.Text = dataRow2["ReqMakeReady"].ToString();
                    this.txtActPaper.Text = dataRow2["ActPaper"].ToString();
                    this.txtActInk.Text = dataRow2["ActInk"].ToString();
                    this.txtActPlates.Text = dataRow2["ActPlates"].ToString();
                    this.txtActGuillotine.Text = dataRow2["ActGuillotine"].ToString();
                    this.txtActWashUp.Text = dataRow2["ActWashUp"].ToString();
                    this.txtActMakeReady.Text = dataRow2["ActMakeReady"].ToString();
                    if (dataRow2["EstimateType"].ToString().ToLower() == "f" || dataRow2["EstimateType"].ToString().ToLower() == "d" || dataRow2["EstimateType"].ToString().ToLower() == "k" || dataRow2["EstimateType"].ToString().ToLower() == "n")
                    {
                        this.jobtime_tr.Visible = true;
                        this.txtEstJobTime.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow2["EstimateJobTime"]), 0, "", false, false, true).Replace(",", "");
                        this.txtActJobTime.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow2["ActualJobTime"]), 0, "", false, false, true).Replace(",", "");
                    }
                    else
                    {
                        this.jobtime_tr.Visible = false;
                    }
                }
                if (this.EstimateType != "U")
                {
                    DataTable dataTable3 = JobsBasePage.jobcard_quantity_select(this.CompanyID, this.QtyNumber, (long)this.EstimateItemID, (long)0, this.EstimateType);
                    foreach (DataRow row3 in dataTable3.Rows)
                    {
                        Label label = this.lblJCquantity;
                        int num1 = Convert.ToInt32(row3["Quantity"]);
                        label.Text = num1.ToString();
                    }
                }
                else
                {
                    this.lblJCquantity.Visible = false;
                }
                if (this.EstimateType == "S" || this.EstimateType == "P" || this.EstimateType == "L")
                {
                    DataTable dataTable4 = new DataTable();
                    if (string.Compare(this.EstimateType, "S", true) == 0)
                    {
                        dataTable4 = EstimatesBasePage.single_item_select(this.CompanyID, (long)this.EstimateItemID);
                    }
                    else if (string.Compare(this.EstimateType, "P", true) == 0)
                    {
                        dataTable4 = EstimatesBasePage.pad_item_select(this.CompanyID, (long)this.EstimateItemID);
                    }
                    else if (string.Compare(this.EstimateType, "L", true) == 0)
                    {
                        dataTable4 = EstimatesBasePage.pad_item_select(this.CompanyID, (long)this.EstimateItemID);
                    }
                    foreach (DataRow dataRow3 in dataTable4.Rows)
                    {
                        this.PressName = dataRow3["PressName"].ToString();
                        this.PaperHeight = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["Height"].ToString()), 0, "", false, false, true));
                        this.PaperWidth = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["Width"].ToString()), 0, "", false, false, true));
                        this.SheetHeight = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["SheetHeight"].ToString()), 0, "", false, false, true));
                        this.SheetWidth = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["SheetWidth"].ToString()), 0, "", false, false, true));
                        this.JobHeight = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["jobheight"].ToString()), 0, "", false, false, true));
                        this.JobWidth = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["jobwidth"].ToString()), 0, "", false, false, true));
                        this.RunningSpoilage = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["RunningSpoilage"].ToString()), 0, "", false, false, true));
                        this.SetUpSpoilage = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["SetupSpoilage"].ToString()), 0, "", false, false, true));
                        string str1 = dataRow3["PrintLayout"].ToString();
                        this.LayoutType = str1;
                        if (string.Compare(str1, "P", true) != 0)
                        {
                            this.PrintLayout = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["LandScapeValue"].ToString()), 0, "", false, false, true));
                        }
                        else
                        {
                            this.PrintLayout = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.userID, Convert.ToDecimal(dataRow3["PortraitValue"].ToString()), 0, "", true, false, true));
                        }
                        this.IsFirstTrim = Convert.ToBoolean(dataRow3["IsFirstTrim"].ToString());
                        this.IsSecondTrim = Convert.ToBoolean(dataRow3["IsSecondTrim"].ToString());
                        this.IsIncludeGutters = Convert.ToBoolean(dataRow3["IsIncludeGutters"].ToString());
                    }
                    if (this.IsAnyWarehouseItem == "Y")
                    {
                        this.pnlWarehouse.Visible = true;
                    }
                    if (this.IsAnyOtherCost == "Y")
                    {
                        this.CalculateOtherCost();
                    }
                    if (this.IsAnyOutwork == "Y")
                    {
                        this.pnlOutwork.Visible = true;
                    }
                }
                else if (this.EstimateType == "W")
                {
                    this.pnlWarehouse.Visible = true;
                }
                else if (!(this.EstimateType == "B") && !(this.EstimateType == "U"))
                {
                    if (this.EstimateType == "O")
                    {
                        this.pnlOutwork.Visible = true;
                    }
                    else if (this.EstimateType == "C")
                    {
                        this.PriceCatalogue_Data();
                        this.pnlPriceCatalogue.Visible = true;
                    }
                }
            }
            if (this.serverName.ToLower() != "maspro")
            {
                this.trArtworkDate.Visible = true;
            }
            else
            {
                this.trArtworkDate.Visible = false;
            }
            bool flag = ConnectionClass.Is_Non_Printing_System;
            if (!ConnectionClass.Is_Non_Printing_System)
            {
                this.trArtworkDate.Visible = true;
                this.trProofDate.Visible = true;
            }
            else
            {
                this.trArtworkDate.Visible = false;
                this.trProofDate.Visible = false;
            }
            this.txtReqArtwork.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtReqApproval.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtReqDelivery.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtReqProduction.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtReqProof.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtActApproval.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtActArtwork.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtActDelivery.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtActProduction.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtActProof.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            foreach (DataRow row4 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                bool flag1 = false;
                if (!Convert.ToBoolean(row4["IsDefaultArtwork"]))
                {
                    this.trArtworkDate.Attributes.Add("style", "display:none");
                }
                else
                {
                    flag1 = true;
                    this.trArtworkDate.Attributes.Add("style", "display:table-row");
                }
                if (!Convert.ToBoolean(row4["IsDefaultProof"]))
                {
                    this.trProofDate.Attributes.Add("style", "display:none");
                }
                else
                {
                    flag1 = true;
                    this.trProofDate.Attributes.Add("style", "display:table-row");
                }
                if (!Convert.ToBoolean(row4["IsDefaultApproval"]))
                {
                    this.div_ApprovalNew.Attributes.Add("style", "display:none");
                }
                else
                {
                    flag1 = true;
                    this.div_ApprovalNew.Attributes.Add("style", "display:table-row");
                }
                if (!Convert.ToBoolean(row4["IsDefaultProduction"]))
                {
                    this.divProductionDate.Attributes.Add("style", "display:none");
                }
                else
                {
                    flag1 = true;
                    this.divProductionDate.Attributes.Add("style", "display:table-row");
                }
                if (!Convert.ToBoolean(row4["IsDefaultDelivery"]))
                {
                    this.div_JobcardDeliverydate.Attributes.Add("style", "display:none");
                }
                else
                {
                    flag1 = true;
                    this.div_JobcardDeliverydate.Attributes.Add("style", "display:table-row");
                }
                if (!flag1)
                {
                    this.trheader.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.trheader.Attributes.Add("style", "display:table-row");
                }
            }
        }

        public void PressDescription(string EstType)
        {
            if (EstType != "B")
            {
                decimal num = new decimal(0);
                decimal num1 = EstimateBasePage.PrintSheets_Calculation_For_SingleItem(Convert.ToInt32(this.lblJCquantity.Text), this.PrintLayout, Convert.ToDecimal(this.SetUpSpoilage), this.RunningSpoilage, out num);
                this.TotalPaper = Convert.ToInt32(num1);
            }
            else
            {
                string str = (this.NoOfSignatures.ToString() == "" ? "0" : this.NoOfSignatures.ToString());
                this.TotalPaper = Convert.ToInt32(this.lblJCquantity.Text) * Convert.ToInt32(str);
            }
            this.TotalRunningSpoilage = this.obj.RunningSpoilage(Convert.ToInt32(this.lblJCquantity.Text), this.PrintLayout, this.RunningSpoilage);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<b><u>Press Details:</u></b>\n");
            stringBuilder.Append(string.Concat("Press Name:= ", this.PressName, "\n"));
            string[] strArrays = new string[] { "Print Sheet Size:= ", this.SheetHeight.ToString(), "mm x ", this.SheetWidth.ToString(), "mm\n" };
            stringBuilder.Append(string.Concat(strArrays));
            string[] str1 = new string[] { "Job Sheet Size:= ", this.JobHeight.ToString(), "mm x ", this.JobWidth.ToString(), "mm\n" };
            stringBuilder.Append(string.Concat(str1));
            stringBuilder.Append(string.Concat("Order Sheet Qty(inc.spoilage):= ", this.TotalPaper, " sheets\n"));
            stringBuilder.Append(string.Concat("Sheet Quantity Spoilage:= ", this.TotalRunningSpoilage, " sheets"));
            this.txtReqPress.Text = stringBuilder.ToString();
            this.lblReqPress.Text = stringBuilder.ToString().Replace("\n", "<br />");
        }

        public DataTable PressDetails(string EstimateType)
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
                empty = "tb_EstimatepadItem";
                str = "EstimatePadItemID";
            }
            else if (EstimateType == "L")
            {
                empty = "tb_EstimateLargeItem";
                str = "EstimateLargeItemID";
            }
            string str1 = string.Concat(" SELECT a.", str, " as TypeID,a.printlayout as layouttype,CASE a.printlayout WHEN 'L' THEN  ");
            str1 = string.Concat(str1, " a.landscapevalue WHEN 'P' THEN a.PortraitValue END as PrintLayout,a.SheetHeight,a.SheetWidth,a.jobheight,a.jobwidth,a.RunningSpoilage,");
            str1 = string.Concat(str1, " a.SetupSpoilage,a.IsAnyWarehouseItem,a.IsAnyOutwork,a.IsAnyotherCost,a.IsIncludeGutters,a.IsFirstTrim,a.IsSecondTrim,");
            str1 = string.Concat(str1, " b.Height,b.Width,CASE WHEN a.PressType='D' THEN (select DigitalPressName from tb_DigitalPress where DigitalPressID=a.PressID)");
            str1 = string.Concat(str1, " WHEN a.PressType='L' THEN (select PressName from tb_LargeFormatPress where PressID=a.PressID) END as PressName");
            str1 = string.Concat(str1, " FROM ", empty, " a LEFT JOIN tb_InventoryProperties b ");
            str1 = string.Concat(str1, " ON a.PaperID=b.InventoryID WHERE EstimateItemID=", this.EstimateItemID);
            return JobBasePage.Jobs_PressDetails_select(this.CompanyID, str1);
        }

        public void PriceCatalogue_Data()
        {
            int num = 0;
            DataTable dataTable = JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, (long)this.EstimateItemID);
            foreach (DataRow row in dataTable.Rows)
            {
                num = Convert.ToInt32(row["QtyNumber"].ToString());
            }
            dataTable = JobBasePage.price_catalogue_select_by_estimateitem_id_qtynumber(this.CompanyID, (long)this.EstimateItemID, num);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.lblJCquantity.Text = dataRow["Quantity"].ToString();
            }
        }
    }
}