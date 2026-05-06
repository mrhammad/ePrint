using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.Calculations;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.usercontrol.Item
{
    public partial class litho_pad_item : UsercontrolBasePage
    {
        //protected usercontrol_settings_Loading ucLoading;

        //protected Label Label10;

        //protected TextBox txtItemTitle;

        //protected Label Label3;

        //protected DropDownList ddlEstimateType;

        //protected Label Label4;

        //protected DropDownList ddlProductType;

        //protected Label Label8;

        //protected HiddenField hid_QtyType;

        //protected HiddenField hid_Q1;

        //protected HiddenField hid_Q2;

        //protected HiddenField hid_Q3;

        //protected HiddenField hid_Q4;

        //protected TextBox txtQuantity;

        //protected CheckBox chkRunOnQty;

        //protected TextBox txtQuantity_2;

        //protected TextBox txtRunOnQty;

        //protected TextBox txtQuantity_3;

        //protected TextBox txtQuantity_4;

        //protected Label Label5;

        //protected TextBox txtSectionRef;

        //protected Label Label9;

        //protected DropDownList ddlPress;

        //protected LinkButton lnk_ddlPress_OnChange;

        //protected UpdatePanel updatepresschangeid;

        //protected HiddenField hid_PressChange;

        //protected HiddenField hid_SessionPressChange;

        //protected HiddenField hid_DigitalPress;

        //protected HiddenField hid_LithoPress;

        //protected HiddenField hid_LithoPress_all;

        //protected HiddenField hid_LargeFormatPress;

        //protected HiddenField hid_DefaultDigitalPress;

        //protected HiddenField hid_DefaultLargePress;

        //protected HiddenField hid_FinalInkSave1;

        //protected HiddenField hid_FinalInkSave2;

        //protected Label Label12;

        //protected HiddenField hdn_PaperProperties;

        //protected Label lblDefaultPaper;

        //protected Label lblPaperWeight;

        //protected HiddenField hdnpaperID;

        //protected CheckBox ChkPriceForWholePack;

        //protected CheckBox ChkPaperSupplied;

        //protected Label Label13;

        //protected TextBox txtSetupSpoilage;

        //protected Label Label14;

        //protected TextBox txtRunningSpoilage;

        //protected Label Label15;

        //protected TextBox txtNoOfPagesRequired;

        //protected Label Label16;

        //protected TextBox txtPagesPerSection;

        //protected Label Label36;

        //protected TextBox txtNoOfLeavesPerPad;

        //protected Label Label11;

        //protected DropDownList ddlColors;

        //protected DropDownList ddlColors_2;

        //protected CheckBox chkDoubleSided;

        //protected DropDownList ddlNoOfSide;

        //protected Label Label1;

        //protected ImageButton ImageButton2;

        //protected DropDownList ddlSide1Color;

        //protected DropDownList DropDownList1;

        //protected DropDownList DropDownList2;

        //protected CheckBox CheckBox1;

        //protected Label Label2;

        //protected ImageButton ImageButton3;

        //protected DropDownList ddlSide2Color;

        //protected CheckBox chkSheetWork;

        //protected CheckBox chkPerfecting;

        //protected CheckBox chkTurn;

        //protected CheckBox chkTumble;

        //protected ImageButton ImageButton1;

        //protected Label lblDefaultPlates;

        //protected HiddenField hdnplateID;

        //protected DropDownList ddlPlates;

        //protected TextBox txtNoOfPlates;

        //protected DropDownList ddlMakeReady;

        //protected TextBox txtNoOfMakeReady;

        //protected DropDownList ddlWashUp;

        //protected Label Label18;

        //protected TextBox txtNoOfPagesInSection;

        //protected Label Label22;

        //protected DropDownList ddlPrintSheetSize;

        //protected HiddenField hid_ddlPrintSheetSize;

        //protected TextBox txtsectionheight;

        //protected TextBox txtsectionwidth;

        //protected CheckBox chkPrintSheet;

        //protected Label Label23;

        //protected DropDownList ddlJobItemSize;

        //protected TextBox txtitemheight;

        //protected TextBox txtitemwidth;

        //protected CheckBox ChkJobFlatCustom;

        //protected DropDownList ddlBookletFormat;

        //protected Label Label24;

        //protected TextBox txtGutterHorizontal;

        //protected TextBox txtGutterVertical;

        //protected CheckBox chkGutters;

        //protected Label Label25;

        //protected CheckBox ChkPressRestrictions;

        //protected Label Label19;

        //protected TextBox txtPagesPerSignature;

        //protected Label Label27;

        //protected TextBox txtNoOfSignatures;

        //protected Label Label20;

        //protected CheckBox chkPortrait;

        //protected TextBox txtportrait;

        //protected Label lblPortraitLength;

        //protected HiddenField hdn_PortraitValue;

        //protected CheckBox chkLandscape;

        //protected TextBox txtlandscape;

        //protected Label lblLandscapeLength;

        //protected HiddenField hdn_LandscapeValue;

        //protected HiddenField hdnProtrait;

        //protected HiddenField hdnLandscale;

        //protected Label Label26;

        //protected Label lblGuillotine;

        //protected CheckBox chkFirstTrim;

        //protected CheckBox chkSecondTrim;

        //protected HiddenField hid_GuillotineID;

        //protected Label Label6;

        //protected HtmlImage Img_ItemDescnHelp;

        //protected HtmlAnchor img_UpdateDescription;

        //protected CheckBox Chk_ItemDescn;

        //protected HtmlGenericControl Div_ItemDescn;

        //protected Label Label17;

        //protected HtmlImage Img1;

        //protected CheckBox chkPoduct1;

        //protected CheckBox chkPoduct2;

        //protected HtmlGenericControl Div_Productcatalogue;

        //protected Button btnPrevious;

        //protected Button btnSave;

        //protected RadWindowManager RadWindowManager1;

        //protected HiddenField hid_singleData;

        //protected HiddenField hid_booklet_save;

        //protected HiddenField hid_width;

        //protected HiddenField hid_height;

        //protected HiddenField hid_inventoryheight;

        //protected HiddenField hid_inventorywidth;

        //protected HiddenField hdn_InkType;

        //protected HiddenField hid_IsJobCustom;

        //protected HiddenField hid_IsSheetCustom;

        //protected HiddenField hdnedit_Default;

        //protected HiddenField hid_isPressPerfect;

        //protected HiddenField hdnOldPressID;

        //protected HiddenField hdnOldPaperID;

        //protected HiddenField hdnOldGuillotineID;

        //protected HiddenField hdn_InvpaperID;

        //protected HiddenField hdn_invStockBack;

        //protected HiddenField hdn_invStockReduce;

        //protected Panel pnlPressLoad;

        //protected Panel pnlPress;

        //protected Panel pnlEdit_MakeReady;

        //protected Panel pnlEdit_WashUp;

        //protected Panel pnlEdit_Gutter;

        //protected Panel pnlEdit_Printsheet;

        //protected Panel pnlEdit_jobsheet;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        private EstimatesBasePage objest = new EstimatesBasePage();

        private EstimatesItem Estitem = new EstimatesItem();

        private Global gloobj = new Global();

        private commonClass commclass = new commonClass();

        private commonClass objJava = new commonClass();

        public languageClass objLanguage = new languageClass();

        private SummaryClass summryCls = new SummaryClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string DateFormat = string.Empty;

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long EstimateItemID;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public long EstimateCalculationID;

        public long EstSingleItemID;

        public long EstimatePadItemID;

        public long EstLargeItemID;

        public long EstBookletItemID;

        public long EstBookletSectionID;

        private string strEstSectionIDs = string.Empty;

        public long TypeID;

        public long EstOtherCostID;

        public string OtherCostValuesFromTB = string.Empty;

        public string EstType = string.Empty;

        private long InvoiceNum;

        public long EstNo;

        private string CatalogueProfitAndTax = string.Empty;

        public long PressID;

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public string modulename = "estimates";

        public string submodulename = "estimate";

        public string str_QtyType = "more";

        public string EstTypeFromSP = string.Empty;

        public long ParentItemID;

        public string ParentItemType = string.Empty;

        public long EstimateBookletItemID;

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public string subedit = string.Empty;

        public string dpaperhw = string.Empty;

        public long EstimateLithoPadItemID;

        public int inkcount = 1;

        public string MainType = string.Empty;

        public string PaperMeasure = string.Empty;

        public string frmcopyitem = string.Empty;

        public int QtyNo;

        public int IsItemCompleted;

        public string ProfitTaxKey = string.Empty;

        public int IsProductCreated;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public bool IsPaperUnitPriceLocked;

        public decimal[] PressJobTimeSide1 = new decimal[4];

        public int DecimalPaperSize;

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

        public litho_pad_item()
        {
        }

        protected void btnPrevious_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.modulename == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            else if (this.modulename == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            if (this.QueryType == "add")
            {
                if (this.modulename != "orders")
                {
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (empty.ToString().ToLower() != "yes")
                        {
                            HttpResponse response = base.Response;
                            object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                            response.Redirect(string.Concat(estimateID));
                        }
                        else
                        {
                            HttpResponse httpResponse = base.Response;
                            object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                            httpResponse.Redirect(string.Concat(objArray));
                        }
                    }
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        if (this.submodulename.ToLower() == "estimate")
                        {
                            this.submodulename = "estimates";
                        }
                        if (this.submodulename.ToLower() == "job")
                        {
                            this.submodulename = "job";
                        }
                        if (this.submodulename.ToLower() == "invoice")
                        {
                            this.submodulename = "invoices";
                        }
                        HttpResponse response1 = base.Response;
                        object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=D&From=F&maintype=", this.MainType, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID1));
                        return;
                    }
                    if (empty.ToString().ToLower() == "yes")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray1));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response2.Redirect(string.Concat(estimateID2));
                    return;
                }
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                    httpResponse2.Redirect(string.Concat(objArray2));
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse response3 = base.Response;
                    object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response3.Redirect(string.Concat(estimateID3));
                    return;
                }
            }
            else if (this.QueryType == "edit")
            {
                if (this.modulename != "orders")
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        if (empty.ToString().ToLower() == "yes")
                        {
                            HttpResponse httpResponse3 = base.Response;
                            object[] objArray3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                            httpResponse3.Redirect(string.Concat(objArray3));
                            return;
                        }
                        HttpResponse response4 = base.Response;
                        object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        response4.Redirect(string.Concat(estimateID4));
                        return;
                    }
                    if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                    {
                        if (empty.ToString().ToLower() == "yes")
                        {
                            HttpResponse httpResponse4 = base.Response;
                            object[] objArray4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                            httpResponse4.Redirect(string.Concat(objArray4));
                            return;
                        }
                        HttpResponse response5 = base.Response;
                        object[] estimateID5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                        response5.Redirect(string.Concat(estimateID5));
                        return;
                    }
                    if (this.submodulename.ToLower() == "estimate")
                    {
                        this.submodulename = "estimates";
                    }
                    if (this.submodulename.ToLower() == "job")
                    {
                        this.submodulename = "job";
                    }
                    if (this.submodulename.ToLower() == "invoice")
                    {
                        this.submodulename = "invoices";
                    }
                    HttpResponse httpResponse5 = base.Response;
                    object[] objArray5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=P&From=S&EstItemID=", this.EstimateItemID, "&maintype=", this.MainType, this.jID, this.InvID };
                    httpResponse5.Redirect(string.Concat(objArray5));
                }
                else
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        HttpResponse response6 = base.Response;
                        object[] estimateID6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        response6.Redirect(string.Concat(estimateID6));
                        return;
                    }
                    if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                    {
                        HttpResponse httpResponse6 = base.Response;
                        object[] objArray6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                        httpResponse6.Redirect(string.Concat(objArray6));
                        return;
                    }
                }
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (string.Compare(this.QueryType, "add", true) != 0 && this.frmcopyitem != "yes")
            {
                if (string.Compare(this.QueryType, "edit", true) == 0 && this.frmcopyitem != "yes")
                {
                    this.Update_LithoPad_Item();
                }
            }
            else if (this.ParentEstimateItemID != (long)0)
            {
                this.Click_Add(this.ParentEstimateItemID, this.ParentEstimateType);
            }
            else
            {
                this.Click_Add((long)0, "");
            }
            string empty = string.Empty;
            if (this.modulename == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            else if (this.modulename == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            if (this.ParentEstimateItemID != (long)0)
            {
                if (this.modulename == "orders")
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response.Redirect(string.Concat(estimateID));
                    return;
                }
                if (empty.ToString().ToLower() == "yes")
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    httpResponse.Redirect(string.Concat(objArray));
                    return;
                }
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                response1.Redirect(string.Concat(estimateID1));
            }
        }

        private void Click_Add(long ParentItemID, string ParentItemType)
        {
            string empty = string.Empty;
            long num = (long)0;
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            estimatesItem.EstimateItemID = (long)0;
            estimatesItem.EstQuantityID = (long)0;
            empty = "D";
            long parentEstimateItemID = (long)0;
            bool flag = false;
            if (this.ParentEstimateItemID != (long)0)
            {
                flag = false;
                parentEstimateItemID = this.ParentEstimateItemID;
            }
            else
            {
                flag = true;
                parentEstimateItemID = (long)0;
            }
            string str = string.Empty;
            if (chkPortrait.Checked)
            {
                str = "P";
            }
            else if (chkLandscape.Checked)
            {
                str = "L";
            }
            else
            {
                str = "M";
            }
            //str = (!this.chkPortrait.Checked ? "L" : "P");
            if (string.Compare(ParentItemType, "B", true) == 0 || string.Compare(ParentItemType, "N", true) == 0 || string.Compare(ParentItemType, "R", true) == 0 || string.Compare(ParentItemType, "K", true) == 0)
            {
                ParentItemID = this.EstimateBookletItemID;
            }
            this.txtGutterHorizontal.Text = (this.txtGutterHorizontal.Text == "" ? "0" : this.txtGutterHorizontal.Text);
            this.txtGutterVertical.Text = (this.txtGutterVertical.Text == "" ? "0" : this.txtGutterVertical.Text);
            this.txtportrait.Text = (this.txtportrait.Text == "" ? "0" : this.txtportrait.Text);
            this.txtlandscape.Text = (this.txtlandscape.Text == "" ? "0" : this.txtlandscape.Text);
            this.txtManual.Text = (this.txtManual.Text == "" ? "0" : this.txtManual.Text);
            this.txtNoOfPlates.Text = (this.txtNoOfPlates.Text == "" ? "0" : this.txtNoOfPlates.Text);
            this.txtNoOfMakeReady.Text = (this.txtNoOfMakeReady.Text == "" ? "0" : this.txtNoOfMakeReady.Text);
            if (this.InvoiceID <= (long)0)
            {
                long num1 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, empty, flag, parentEstimateItemID);
                num = num1;
                estimatesItem.EstimateItemID = num1;
            }
            else
            {
                long num2 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, empty, flag, parentEstimateItemID);
                num = num2;
                estimatesItem.EstimateItemID = num2;
            }
            EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, num, ConnectionClass.IsHandy);
            if (this.jobID > (long)0)
            {
                long num3 = this.jobID;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                JobBasePage.EstimateItems_ProgressToJob(num, num3, false, Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
            }
            if (this.InvoiceID > (long)0)
            {
                InvoiceBasePage.EstimateItems_ProgressToInvoice(num, this.InvoiceID);
            }
            EstimatesBasePage.estimate_litho_pad_item_insert(this.CompanyID, (long)0, num, Convert.ToInt64(this.ddlPress.SelectedValue), Convert.ToInt64(this.hdnpaperID.Value), Convert.ToBoolean(this.ChkPriceForWholePack.Checked), Convert.ToBoolean(this.ChkPaperSupplied.Checked), Convert.ToDecimal(this.txtSetupSpoilage.Text), Convert.ToDecimal(this.txtRunningSpoilage.Text), Convert.ToDecimal(this.txtNoOfLeavesPerPad.Text), this.ddlNoOfSide.SelectedItem.Text, this.ddlSide1Color.SelectedItem.Text, this.ddlSide2Color.SelectedItem.Text, Convert.ToInt64(this.hdnplateID.Value), this.txtNoOfPlates.Text, this.txtNoOfMakeReady.Text, this.ddlWashUp.SelectedItem.Text, Convert.ToInt32(this.ddlPrintSheetSize.SelectedValue), Convert.ToBoolean(this.chkPrintSheet.Checked), Convert.ToDecimal(this.txtsectionheight.Text), Convert.ToDecimal(this.txtsectionwidth.Text), Convert.ToInt32(this.ddlJobItemSize.SelectedValue), Convert.ToBoolean(this.ChkJobFlatCustom.Checked), Convert.ToDecimal(this.txtitemheight.Text), Convert.ToDecimal(this.txtitemwidth.Text), Convert.ToBoolean(this.chkGutters.Checked), Convert.ToDecimal(this.txtGutterHorizontal.Text), Convert.ToDecimal(this.txtGutterVertical.Text), Convert.ToBoolean(this.ChkPressRestrictions.Checked), str, Convert.ToDecimal(this.hdn_PortraitValue.Value), Convert.ToDecimal(this.hdn_LandscapeValue.Value), Convert.ToInt64(this.hid_GuillotineID.Value), this.objBase.SpecialEncode(this.txtItemTitle.Text), Convert.ToInt32(base.Session["UserID"]), 0, DateTime.Now, Convert.ToBoolean(this.chkFirstTrim.Checked), Convert.ToBoolean(this.chkSecondTrim.Checked), Convert.ToBoolean(this.chkTurn.Checked), Convert.ToBoolean(this.chkTumble.Checked), Convert.ToInt32(ParentItemID), ParentItemType, this.chkPerfecting.Checked, Convert.ToDecimal(this.hdnManual.Value),this.chkSheetWork.Checked);
            this.PressID = Convert.ToInt64(this.ddlPress.SelectedValue);
            this.Popup_inkvalue_insert(num, "", this.PressID, this.ddlNoOfSide.SelectedItem.Text, empty, (long)0, 1, Convert.ToInt32(this.ddlSide1Color.SelectedItem.Text), Convert.ToInt32(this.ddlSide2Color.SelectedItem.Text), "add");
            estimatesItem.GuillotineID = Convert.ToInt64(this.hid_GuillotineID.Value);
            estimatesItem.PressType = 'S';
            estimatesItem.PaperID = Convert.ToInt64(this.hdnpaperID.Value);
            double num4 = 0;
            DataTable dataTable = EstimatesBasePage.SelectPlateunitprice_eachSectin(Convert.ToInt32(this.hdnplateID.Value));
            foreach (DataRow row in dataTable.Rows)
            {
                num4 = Convert.ToDouble(row["PlateUnitPrice"]);
            }
            this.Estimate_Calcukation(num, (long)0, estimatesItem.PaperID, this.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, empty, num4);
            this.Main_Quantity_Insert(num, "qty", estimatesItem);
            if (base.Request.Params["parentestitemid"] == null)
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(num);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            if (ParentItemID == (long)0)
            {
                EstimateCommonMethods.UpdateDescription(num, this.EstimateID, "D", false);
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, num);
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                JobBasePage.Job_Jobcard_Insert_NewItem_JOBTIME(this.CompanyID, num, 1, this.EstimateID, this.PressJobTimeSide1[0]);
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, num, "D");
                string empty1 = string.Empty;
                string str1 = string.Empty;
                long parentItemID = num;
                if (ParentItemID != (long)0)
                {
                    parentItemID = ParentItemID;
                }
                foreach (DataRow dataRow in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty1 = dataRow["StatusID"].ToString();
                }
                if (string.Compare(this.modulename, "jobs", true) == 0 && this.ParentEstimateItemID == (long)0)
                {
                    this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty1), "job", num, (long)0);
                }
                this.summryCls.Call_Inventory_Adjustment("progressed", this.EstimateID, this.CompanyID, parentItemID, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    this.summryCls.Call_Inventory_Adjustment("completed", this.EstimateID, this.CompanyID, parentItemID, this.UserID);
                }
                else if (string.Compare(this.modulename, "invoice", true) == 0 && this.ReduceStockType.ToLower() == "i" || this.hdn_invStockReduce.Value.ToLower() == "yes")
                {
                    this.summryCls.Call_Inventory_Adjustment("completed-invoice", this.EstimateID, this.CompanyID, parentItemID, this.UserID);
                }
                else if (string.Compare(this.modulename, "jobs", true) == 0 && this.ReduceStockType.ToString() == empty1.ToString())
                {
                    this.summryCls.Call_Inventory_Adjustment("completed-status", this.EstimateID, this.CompanyID, parentItemID, this.UserID);
                }
            }
            if (this.modulename == "jobs")
            {
                string empty2 = string.Empty;
                string str2 = string.Empty;
                foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                {
                    empty2 = row1["PhraseText"].ToString();
                }
                foreach (DataRow dataRow1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                {
                    str2 = dataRow1["PhraseText"].ToString();
                }
                EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty2, str2);
            }
            base.Session["dtinks"] = null;
            if (ParentItemID == (long)0)
            {
                if (EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, empty) > (long)0)
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", num, "&parentesttype=", empty, "&maintype=edit&subitem=s", this.jID, this.InvID };
                    response.Redirect(string.Concat(estimateID));
                }
                else if (base.Request.Params["parentestitemid"] != null)
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
            }
            string empty3 = string.Empty;
            if (this.modulename == "invoice")
            {
                empty3 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            else if (this.modulename == "jobs")
            {
                empty3 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            if (this.modulename == "orders")
            {
                if (ParentItemID != (long)0)
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", ParentItemID, this.jID, this.InvID };
                    httpResponse.Redirect(string.Concat(objArray));
                    return;
                }
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", num, this.jID, this.InvID };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            if (ParentItemID != (long)0)
            {
                if (empty3.ToString().ToLower() == "yes")
                {
                    HttpResponse httpResponse1 = base.Response;
                    object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", ParentItemID, this.jID, this.InvID };
                    httpResponse1.Redirect(string.Concat(objArray1));
                    return;
                }
                HttpResponse response2 = base.Response;
                object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", ParentItemID, this.jID, this.InvID };
                response2.Redirect(string.Concat(estimateID2));
                return;
            }
            if (empty3.ToString().ToLower() == "yes")
            {
                HttpResponse httpResponse2 = base.Response;
                object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", num, this.jID, this.InvID };
                httpResponse2.Redirect(string.Concat(objArray2));
                return;
            }
            HttpResponse response3 = base.Response;
            object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", num, this.jID, this.InvID };
            response3.Redirect(string.Concat(estimateID3));
        }

        protected void ddlPress_OnChange(object sender, EventArgs e)
        {
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                base.Session["dtinks"] = null;
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "Parts1";
                string empty = string.Empty;
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string str4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                string empty6 = string.Empty;
                string str6 = string.Empty;
                string empty7 = string.Empty;
                string str7 = string.Empty;
                string empty8 = string.Empty;
                string str8 = string.Empty;
                string empty9 = string.Empty;
                string str9 = string.Empty;
                string empty10 = string.Empty;
                string str10 = string.Empty;
                string empty11 = string.Empty;
                DataTable dataTable = new DataTable();
                string lower = this.ddlNoOfSide.SelectedValue.ToLower();
                Convert.ToInt32(this.ddlSide1Color.SelectedValue);
                Convert.ToInt32(this.ddlSide2Color.SelectedValue);
                this.PressID = Convert.ToInt64(this.ddlPress.SelectedValue);
                string str11 = lower;
                short num = 0;
                if (base.Session["dtinks"] == null)
                {
                    dataTable.Columns.Add("SectionName", typeof(string));
                    dataTable.Columns.Add("InkID", typeof(string));
                    dataTable.Columns.Add("InkCoverage", typeof(string));
                    dataTable.Columns.Add("SidesPrinted", typeof(string));
                    dataTable.Columns.Add("sidenumber", typeof(string));
                    dataTable.Columns.Add("InkName", typeof(string));
                    dataTable.Columns.Add("InkCostExMarkup1", typeof(string));
                    dataTable.Columns.Add("InkCostExMarkup2", typeof(string));
                    dataTable.Columns.Add("InkCostExMarkup3", typeof(string));
                    dataTable.Columns.Add("InkCostExMarkup4", typeof(string));
                    dataTable.Columns.Add("InkMarkup1", typeof(string));
                    dataTable.Columns.Add("InkMarkup2", typeof(string));
                    dataTable.Columns.Add("InkMarkup3", typeof(string));
                    dataTable.Columns.Add("InkMarkup4", typeof(string));
                    dataTable.Columns.Add("InkMarkupPrice1", typeof(string));
                    dataTable.Columns.Add("InkMarkupPrice2", typeof(string));
                    dataTable.Columns.Add("InkMarkupPrice3", typeof(string));
                    dataTable.Columns.Add("InkMarkupPrice4", typeof(string));
                    dataTable.Columns.Add("InkSetupCharge", typeof(string));
                    dataTable.Columns.Add("InkMinimumCharge", typeof(string));
                    dataTable.Columns.Add("InkCostExMarkup_Actual1", typeof(string));
                    dataTable.Columns.Add("InkCostExMarkup_Actual2", typeof(string));
                    dataTable.Columns.Add("InkCostExMarkup_Actual3", typeof(string));
                    dataTable.Columns.Add("InkCostExMarkup_Actual4", typeof(string));
                }
                if (lower.ToLower().Trim() == "single")
                {
                    empty = "side1";
                    int num1 = 0;
                    foreach (DataRow row in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                    {
                        num = Convert.ToInt16(row["DefaultColour"].ToString());
                        Convert.ToInt16(row["rownumber"].ToString());
                        if (num <= num1)
                        {
                            continue;
                        }
                        str = string.Concat(str, row["InkID"].ToString(), "±");
                        str1 = string.Concat(str1, row["InkCoverage"].ToString(), "±");
                        str2 = string.Concat(str2, row["InkName"].ToString(), "±");
                        empty1 = string.Concat(empty1, "0±");
                        empty2 = string.Concat(empty2, "0±");
                        empty3 = string.Concat(empty3, "0±");
                        empty4 = string.Concat(empty4, "0±");
                        str4 = string.Concat(str4, "0±");
                        empty5 = string.Concat(empty5, "0±");
                        str5 = string.Concat(str5, "0±");
                        empty6 = string.Concat(empty6, "0±");
                        str6 = string.Concat(str6, "0±");
                        empty7 = string.Concat(empty7, "0±");
                        str7 = string.Concat(str7, "0±");
                        empty8 = string.Concat(empty8, "0±");
                        str8 = string.Concat(str8, "0±");
                        empty9 = string.Concat(empty9, "0±");
                        str9 = string.Concat(str9, "0±");
                        empty10 = string.Concat(empty10, "0±");
                        str10 = string.Concat(str10, "0±");
                        empty11 = string.Concat(empty11, "0±");
                        num1++;
                    }
                    object[] objArray = new object[] { str3, str, str1, str11, empty, str2, empty1, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                    dataTable.Rows.Add(objArray);
                }
                else if (lower.ToLower().Trim() == "double")
                {
                    int num2 = 0;
                    int num3 = 0;
                    foreach (DataRow dataRow in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                    {
                        num = Convert.ToInt16(dataRow["DefaultColour"].ToString());
                        Convert.ToInt16(dataRow["rownumber"].ToString());
                        if (num <= num2)
                        {
                            continue;
                        }
                        str = string.Concat(str, dataRow["InkID"].ToString(), "±");
                        str1 = string.Concat(str1, dataRow["InkCoverage"].ToString(), "±");
                        str2 = string.Concat(str2, dataRow["InkName"].ToString(), "±");
                        empty1 = string.Concat(empty1, "0±");
                        empty2 = string.Concat(empty2, "0±");
                        empty3 = string.Concat(empty3, "0±");
                        empty4 = string.Concat(empty4, "0±");
                        str4 = string.Concat(str4, "0±");
                        empty5 = string.Concat(empty5, "0±");
                        str5 = string.Concat(str5, "0±");
                        empty6 = string.Concat(empty6, "0±");
                        str6 = string.Concat(str6, "0±");
                        empty7 = string.Concat(empty7, "0±");
                        str7 = string.Concat(str7, "0±");
                        empty8 = string.Concat(empty8, "0±");
                        str8 = string.Concat(str8, "0±");
                        empty9 = string.Concat(empty9, "0±");
                        str9 = string.Concat(str9, "0±");
                        empty10 = string.Concat(empty10, "0±");
                        str10 = string.Concat(str10, "0±");
                        empty11 = string.Concat(empty11, "0±");
                        num2++;
                    }
                    empty = "side1";
                    object[] objArray1 = new object[] { str3, str, str1, str11, empty, str2, empty1, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                    dataTable.Rows.Add(objArray1);
                    foreach (DataRow row1 in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                    {
                        num = Convert.ToInt16(row1["DefaultColour"].ToString());
                        Convert.ToInt16(row1["rownumber"].ToString());
                        if (num <= num3)
                        {
                            continue;
                        }
                        str = string.Concat(str, row1["InkID"].ToString(), "±");
                        str1 = string.Concat(str1, row1["InkCoverage"].ToString(), "±");
                        str2 = string.Concat(str2, row1["InkName"].ToString(), "±");
                        empty1 = string.Concat(empty1, "0±");
                        empty2 = string.Concat(empty2, "0±");
                        empty3 = string.Concat(empty3, "0±");
                        empty4 = string.Concat(empty4, "0±");
                        str4 = string.Concat(str4, "0±");
                        empty5 = string.Concat(empty5, "0±");
                        str5 = string.Concat(str5, "0±");
                        empty6 = string.Concat(empty6, "0±");
                        str6 = string.Concat(str6, "0±");
                        empty7 = string.Concat(empty7, "0±");
                        str7 = string.Concat(str7, "0±");
                        empty8 = string.Concat(empty8, "0±");
                        str8 = string.Concat(str8, "0±");
                        empty9 = string.Concat(empty9, "0±");
                        str9 = string.Concat(str9, "0±");
                        empty10 = string.Concat(empty10, "0±");
                        str10 = string.Concat(str10, "0±");
                        empty11 = string.Concat(empty11, "0±");
                        num3++;
                    }
                    empty = "side2";
                    object[] objArray2 = new object[] { str3, str, str1, str11, empty, str2, empty1, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                    dataTable.Rows.Add(objArray2);
                }
                base.Session["dtinks"] = dataTable;
            }
        }

        protected void ddlPress_OnSelectedIndnexChanged(object sender, EventArgs e)
        {
            base.Session["dtinks"] = null;
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "Parts1";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            string str6 = string.Empty;
            string empty7 = string.Empty;
            string str7 = string.Empty;
            string empty8 = string.Empty;
            string str8 = string.Empty;
            string empty9 = string.Empty;
            string str9 = string.Empty;
            string empty10 = string.Empty;
            string str10 = string.Empty;
            string empty11 = string.Empty;
            DataTable dataTable = new DataTable();
            string lower = this.ddlNoOfSide.SelectedValue.ToLower();
            Convert.ToInt32(this.ddlSide1Color.SelectedValue);
            Convert.ToInt32(this.ddlSide2Color.SelectedValue);
            this.PressID = Convert.ToInt64(this.ddlPress.SelectedValue);
            string str11 = lower;
            short num = 0;
            if (base.Session["dtinks"] == null)
            {
                dataTable.Columns.Add("SectionName", typeof(string));
                dataTable.Columns.Add("InkID", typeof(string));
                dataTable.Columns.Add("InkCoverage", typeof(string));
                dataTable.Columns.Add("SidesPrinted", typeof(string));
                dataTable.Columns.Add("sidenumber", typeof(string));
                dataTable.Columns.Add("InkName", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup1", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup2", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup3", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup4", typeof(string));
                dataTable.Columns.Add("InkMarkup1", typeof(string));
                dataTable.Columns.Add("InkMarkup2", typeof(string));
                dataTable.Columns.Add("InkMarkup3", typeof(string));
                dataTable.Columns.Add("InkMarkup4", typeof(string));
                dataTable.Columns.Add("InkMarkupPrice1", typeof(string));
                dataTable.Columns.Add("InkMarkupPrice2", typeof(string));
                dataTable.Columns.Add("InkMarkupPrice3", typeof(string));
                dataTable.Columns.Add("InkMarkupPrice4", typeof(string));
                dataTable.Columns.Add("InkSetupCharge", typeof(string));
                dataTable.Columns.Add("InkMinimumCharge", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup_Actual1", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup_Actual2", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup_Actual3", typeof(string));
                dataTable.Columns.Add("InkCostExMarkup_Actual4", typeof(string));
            }
            if (lower.ToLower().Trim() == "single")
            {
                empty = "side1";
                int num1 = 0;
                foreach (DataRow row in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                {
                    num = Convert.ToInt16(row["DefaultColour"].ToString());
                    Convert.ToInt16(row["rownumber"].ToString());
                    if (num <= num1)
                    {
                        continue;
                    }
                    str = string.Concat(str, row["InkID"].ToString(), "±");
                    str1 = string.Concat(str1, row["InkCoverage"].ToString(), "±");
                    str2 = string.Concat(str2, row["InkName"].ToString(), "±");
                    empty1 = string.Concat(empty1, "0±");
                    empty2 = string.Concat(empty2, "0±");
                    empty3 = string.Concat(empty3, "0±");
                    empty4 = string.Concat(empty4, "0±");
                    str4 = string.Concat(str4, "0±");
                    empty5 = string.Concat(empty5, "0±");
                    str5 = string.Concat(str5, "0±");
                    empty6 = string.Concat(empty6, "0±");
                    str6 = string.Concat(str6, "0±");
                    empty7 = string.Concat(empty7, "0±");
                    str7 = string.Concat(str7, "0±");
                    empty8 = string.Concat(empty8, "0±");
                    str8 = string.Concat(str8, "0±");
                    empty9 = string.Concat(empty9, "0±");
                    str9 = string.Concat(str9, "0±");
                    empty10 = string.Concat(empty10, "0±");
                    str10 = string.Concat(str10, "0±");
                    empty11 = string.Concat(empty11, "0±");
                    num1++;
                }
                object[] objArray = new object[] { str3, str, str1, str11, empty, str2, empty1, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                dataTable.Rows.Add(objArray);
            }
            else if (lower.ToLower().Trim() == "double")
            {
                int num2 = 0;
                int num3 = 0;
                foreach (DataRow dataRow in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                {
                    num = Convert.ToInt16(dataRow["DefaultColour"].ToString());
                    Convert.ToInt16(dataRow["rownumber"].ToString());
                    if (num <= num2)
                    {
                        continue;
                    }
                    str = string.Concat(str, dataRow["InkID"].ToString(), "±");
                    str1 = string.Concat(str1, dataRow["InkCoverage"].ToString(), "±");
                    str2 = string.Concat(str2, dataRow["InkName"].ToString(), "±");
                    empty1 = string.Concat(empty1, "0±");
                    empty2 = string.Concat(empty2, "0±");
                    empty3 = string.Concat(empty3, "0±");
                    empty4 = string.Concat(empty4, "0±");
                    str4 = string.Concat(str4, "0±");
                    empty5 = string.Concat(empty5, "0±");
                    str5 = string.Concat(str5, "0±");
                    empty6 = string.Concat(empty6, "0±");
                    str6 = string.Concat(str6, "0±");
                    empty7 = string.Concat(empty7, "0±");
                    str7 = string.Concat(str7, "0±");
                    empty8 = string.Concat(empty8, "0±");
                    str8 = string.Concat(str8, "0±");
                    empty9 = string.Concat(empty9, "0±");
                    str9 = string.Concat(str9, "0±");
                    empty10 = string.Concat(empty10, "0±");
                    str10 = string.Concat(str10, "0±");
                    empty11 = string.Concat(empty11, "0±");
                    num2++;
                }
                empty = "side1";
                object[] objArray1 = new object[] { str3, str, str1, str11, empty, str2, empty1, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                dataTable.Rows.Add(objArray1);
                foreach (DataRow row1 in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                {
                    num = Convert.ToInt16(row1["DefaultColour"].ToString());
                    Convert.ToInt16(row1["rownumber"].ToString());
                    if (num <= num3)
                    {
                        continue;
                    }
                    str = string.Concat(str, row1["InkID"].ToString(), "±");
                    str1 = string.Concat(str1, row1["InkCoverage"].ToString(), "±");
                    str2 = string.Concat(str2, row1["InkName"].ToString(), "±");
                    empty1 = string.Concat(empty1, "0±");
                    empty2 = string.Concat(empty2, "0±");
                    empty3 = string.Concat(empty3, "0±");
                    empty4 = string.Concat(empty4, "0±");
                    str4 = string.Concat(str4, "0±");
                    empty5 = string.Concat(empty5, "0±");
                    str5 = string.Concat(str5, "0±");
                    empty6 = string.Concat(empty6, "0±");
                    str6 = string.Concat(str6, "0±");
                    empty7 = string.Concat(empty7, "0±");
                    str7 = string.Concat(str7, "0±");
                    empty8 = string.Concat(empty8, "0±");
                    str8 = string.Concat(str8, "0±");
                    empty9 = string.Concat(empty9, "0±");
                    str9 = string.Concat(str9, "0±");
                    empty10 = string.Concat(empty10, "0±");
                    str10 = string.Concat(str10, "0±");
                    empty11 = string.Concat(empty11, "0±");
                    num3++;
                }
                empty = "side2";
                object[] objArray2 = new object[] { str3, str, str1, str11, empty, str2, empty1, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                dataTable.Rows.Add(objArray2);
            }
            base.Session["dtinks"] = dataTable;
        }

        private string Estimate_Calcukation(long EstimateItemID, long EstimateBookletItemID, long PaperID, long PressID, char PressType, long GuillotineID, string EstimateType, double PlateUnitPrice)
        {
            StringBuilder stringBuilder = new StringBuilder();
            decimal num = new decimal(0);
            decimal num1 = new decimal(1);
            double num2 = 0;
            double num3 = 0;
            string[] strArrays = EstimateBasePage.Paper_Calculation(this.CompanyID, Convert.ToInt32(PaperID)).Split(new char[] { '±' });
            string empty = string.Empty;
            decimal num4 = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "I", PaperID));
            stringBuilder.Append(" Insert into [tb_EstimateCalculation] ");
            stringBuilder.Append(" ( EstimateItemID, EstimateBookletItemID, ");
            stringBuilder.Append(" PaperUnitPrice, PaperWeight, PaperMarkup,PaperMarkup2,PaperMarkup3,PaperMarkup4, ");
            stringBuilder.Append(" PlateMarkUp,PressMarkUp,PressMarkUp2,PressMarkUp3,PressMarkUp4, PressSetupCharge, PressMinimumRunningCharge, PressType, ");
            stringBuilder.Append(" BlackChargeableRate, ColorChargeableRate, NoOfChargeableSheets, ");
            stringBuilder.Append(" HourlyCharge, ");
            stringBuilder.Append(" PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, ");
            stringBuilder.Append(" GuillotineSetupCharge, GuillotineMinimumRunningCharge, GuillotineMarkUp,GuillotineMarkUp2,GuillotineMarkUp3,GuillotineMarkUp4, ");
            stringBuilder.Append(" GuillotineCostPerCut, GuillotinePaperWeight1, GuillotineMaximumThroat1, ");
            stringBuilder.Append(" GuillotinePaperWeight2, GuillotineMaximumThroat2, GuillotinePaperWeight3, ");
            stringBuilder.Append(" GuillotineMaximumThroat3,PaperPackedInQty,PressPasses,WashupUnitprice,MakeReadyUnitprice,PlateUnitPrice  ) ");
            stringBuilder.Append(" Values ");
            object[] estimateItemID = new object[] { " ( ", EstimateItemID, ", ", EstimateBookletItemID, "," };
            stringBuilder.Append(string.Concat(estimateItemID));
            string[] strArrays1 = new string[] { " ", strArrays[0], ",", strArrays[1], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], "," };
            stringBuilder.Append(string.Concat(strArrays1));
            foreach (DataRow row in EstimatesBasePage.Estimate_Litho_Press_Select(this.CompanyID, PressID).Rows)
            {
                string[] str = new string[] { " ", row["PlateMarkUp"].ToString(), ",", row["MarkUp"].ToString(), ",", row["MarkUp"].ToString(), ",", row["MarkUp"].ToString(), ",", row["MarkUp"].ToString(), ",", row["SetupCharge"].ToString(), ",", row["MinimumCharge"].ToString(), "," };
                stringBuilder.Append(string.Concat(str));
                stringBuilder.Append("'S',");
                stringBuilder.Append("0,0,0,");
                stringBuilder.Append(string.Concat(" ", row["HourlyCharge"].ToString(), ", "));
                stringBuilder.Append(" 0, 0, 0, ");
                num = Convert.ToInt32(row["ColourUnits"]);
                num2 = Convert.ToDouble(row["WashupUnitPrice"]);
                num3 = Convert.ToDouble(row["MakeReadyUnitPrice"]);
            }
            DataTable dataTable = EstimateBasePage.Estimate_Guillotine_Select_By_ID(this.CompanyID, GuillotineID);
            if (dataTable.Rows.Count <= 0)
            {
                stringBuilder.Append(" 0,0,0,0,0,0, ");
                stringBuilder.Append(" 0,0,0, ");
                stringBuilder.Append(" 0,0,0, ");
                stringBuilder.Append(" 0, ");
            }
            else
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string[] str1 = new string[] { " ", dataRow["SetUpCharge"].ToString(), ",", dataRow["MinCharge"].ToString(), ",", dataRow["MarkUp"].ToString(), ",", dataRow["MarkUp"].ToString(), ",", dataRow["MarkUp"].ToString(), ",", dataRow["MarkUp"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str1));
                    string[] str2 = new string[] { " ", dataRow["CostPerCut"].ToString(), ",", dataRow["PaperWeight1"].ToString(), ",", dataRow["MaxSheets1"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str2));
                    string[] strArrays2 = new string[] { " ", dataRow["PaperWeight2"].ToString(), ",", dataRow["MaxSheets2"].ToString(), ",", dataRow["PaperWeight3"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays2));
                    stringBuilder.Append(string.Concat(" ", dataRow["MaxSheets3"].ToString(), ","));
                }
            }
            Calculations calculation = new Calculations();
            num1 = calculation.Return_PressPasses(this.ddlNoOfSide.SelectedValue, Convert.ToInt32(this.ddlSide1Color.SelectedItem.Value), Convert.ToInt32(this.ddlSide2Color.SelectedItem.Value), num, this.chkPerfecting.Checked);
            object[] plateUnitPrice = new object[] { " ", num4, ", ", num1, ",", num2, ",", num3, ",", PlateUnitPrice, ")" };
            stringBuilder.Append(string.Concat(plateUnitPrice));
            stringBuilder.Append(" declare @EstimateCalculationID bigint; ");
            stringBuilder.Append(" set @EstimateCalculationID = Ident_Current('tb_EstimateCalculation')");
            stringBuilder.Append(" select @EstimateCalculationID ");
            long num5 = EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            EstimatesBasePage.estimates_litho_markup_calculation_insert(this.CompanyID, num5);
            EstimatesBasePage.litho_speed_weight_insert(this.CompanyID, num5, PressID);
            return stringBuilder.ToString();
        }

        private void Estimate_Calcukation_Update(long EstimateItemID, long EstBookletSectionID, long PaperID, long PressID, char PressType, long GuillotineID, string EstimateType, double PlateUnitPrice, bool IsPaperUnitPriceLocked)
        {
            string str = "0";
            string str1 = "0";
            string str2 = "0";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" Update [tb_EstimateCalculation] ");
            stringBuilder.Append(string.Concat(" Set EstimateItemID=", EstimateItemID, ","));
            string[] strArrays = EstimateBasePage.Paper_Calculation(this.CompanyID, Convert.ToInt32(PaperID)).Split(new char[] { '±' });
            string empty = string.Empty;
            decimal num = new decimal(0);
            decimal num1 = new decimal(1);
            double num2 = 0;
            double num3 = 0;
            str = strArrays[2].ToString();
            foreach (DataRow row in EstimatesBasePage.Estimate_Litho_Press_Select(this.CompanyID, PressID).Rows)
            {
                str1 = row["MarkUp"].ToString();
                string[] strArrays1 = new string[] { " PressSetupCharge=", row["SetupCharge"].ToString(), ",PressMinimumRunningCharge=", row["MinimumCharge"].ToString(), "," };
                stringBuilder.Append(string.Concat(strArrays1));
                stringBuilder.Append("PressType='S',");
                stringBuilder.Append("BlackChargeableRate=0,ColorChargeableRate=0,NoOfChargeableSheets=0,");
                stringBuilder.Append(string.Concat(" HourlyCharge=", row["HourlyCharge"].ToString(), ", "));
                stringBuilder.Append(" PrintPerHourLow=0, PrintPerHourMedium=0, PrintPerHourHigh=0, ");
                num = Convert.ToInt32(row["ColourUnits"]);
                num2 = Convert.ToDouble(row["WashupUnitPrice"]);
                num3 = Convert.ToDouble(row["MakeReadyUnitPrice"]);
            }
            DataTable dataTable = EstimateBasePage.Estimate_Guillotine_Select_By_ID(this.CompanyID, GuillotineID);
            if (dataTable.Rows.Count <= 0)
            {
                stringBuilder.Append(" GuillotineSetupCharge=0,GuillotineMinimumRunningCharge=0, ");
                stringBuilder.Append(" GuillotineCostPerCut=0,GuillotinePaperWeight1=0,GuillotineMaximumThroat1=0, ");
                stringBuilder.Append(" GuillotinePaperWeight2=0,GuillotineMaximumThroat2=0,GuillotinePaperWeight3=0, ");
                stringBuilder.Append(" GuillotineMaximumThroat3=0, ");
            }
            else
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    str2 = dataRow["MarkUp"].ToString();
                    string[] strArrays2 = new string[] { " GuillotineSetupCharge=", dataRow["SetUpCharge"].ToString(), ",GuillotineMinimumRunningCharge=", dataRow["MinCharge"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays2));
                    string[] str3 = new string[] { " GuillotineCostPerCut=", dataRow["CostPerCut"].ToString(), ",GuillotinePaperWeight1=", dataRow["PaperWeight1"].ToString(), ",GuillotineMaximumThroat1=", dataRow["MaxSheets1"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str3));
                    string[] strArrays3 = new string[] { " GuillotinePaperWeight2=", dataRow["PaperWeight2"].ToString(), ",GuillotineMaximumThroat2=", dataRow["MaxSheets2"].ToString(), ",GuillotinePaperWeight3=", dataRow["PaperWeight3"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays3));
                    stringBuilder.Append(string.Concat(" GuillotineMaximumThroat3=", dataRow["MaxSheets3"].ToString(), ","));
                }
            }
            Calculations calculation = new Calculations();
            num1 = calculation.Return_PressPasses(this.ddlNoOfSide.SelectedValue, Convert.ToInt32(this.ddlSide1Color.SelectedItem.Value), Convert.ToInt32(this.ddlSide2Color.SelectedItem.Value), num, this.chkPerfecting.Checked);
            object[] plateUnitPrice = new object[] { "PressPasses=", num1, ",WashupUnitprice=", num2, ",MakeReadyUnitprice=", num3, ",PlateUnitPrice=", PlateUnitPrice };
            stringBuilder.Append(string.Concat(plateUnitPrice));
            if (Convert.ToInt64(PaperID) != Convert.ToInt64(this.hdnOldPaperID.Value))
            {
                string[] strArrays4 = new string[] { ", PaperWeight=", strArrays[1], ",PaperPackedInQty=", strArrays[3], " " };
                stringBuilder.Append(string.Concat(strArrays4));
                string[] strArrays5 = new string[] { ", PaperMarkup=", str, ", PaperMarkup2=", str, ", PaperMarkup3=", str, ", PaperMarkup4=", str, " " };
                stringBuilder.Append(string.Concat(strArrays5));
            }
            if ((Convert.ToInt64(PaperID) != Convert.ToInt64(this.hdnOldPaperID.Value)) || (Convert.ToInt64(PaperID) == Convert.ToInt64(this.hdnOldPaperID.Value)))
            {
                if (!IsPaperUnitPriceLocked)
                {
                    stringBuilder.Append(string.Concat(",PaperUnitPrice=", strArrays[0], " "));
                }
            }

            // Ticket #9819 paper unit price updated
            //if (!IsPaperUnitPriceLocked)
            //{
            //    stringBuilder.Append(string.Concat(",PaperUnitPrice=", strArrays[0], " "));
            //}

            if (Convert.ToInt64(PressID) != Convert.ToInt64(this.hdnOldPressID.Value))
            {
                string[] strArrays6 = new string[] { ", PressMarkup=", str1, ", PressMarkup2=", str1, ", PressMarkup3=", str1, ", PressMarkup4=", str1, " " };
                stringBuilder.Append(string.Concat(strArrays6));
            }
            if (Convert.ToInt64(GuillotineID) != Convert.ToInt64(this.hdnOldGuillotineID.Value))
            {
                string[] strArrays7 = new string[] { ",   GuillotineMarkUp=", str2, ", GuillotineMarkUp2=", str2, ", GuillotineMarkUp3=", str2, ", GuillotineMarkUp4=", str2, " " };
                stringBuilder.Append(string.Concat(strArrays7));
            }
            if (EstimateType == "S" || EstimateType == "P")
            {
                stringBuilder.Append(string.Concat(" Where EstimateCalculationID=", this.EstimateCalculationID));
            }
            else
            {
                stringBuilder.Append(string.Concat(" Where EstimateCalculationID=", this.EstimateCalculationID));
            }
            stringBuilder.Append(string.Concat(" select ", this.EstimateCalculationID));
            EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            EstimatesBasePage.litho_speed_weight_insert(this.CompanyID, this.EstimateCalculationID, PressID);
        }

        public void getinkvalues(DataRow drv, int Sessioncount1, int side1color, int CompanyID, long EstimateItemID_TempID, long PressID, long LithoTypeID, string EstimateType, int partcount)
        {
            string str = drv["InkCoverage"].ToString();
            string str1 = drv["InkID"].ToString();
            string str2 = drv["SidesPrinted"].ToString();
            drv["SectionName"].ToString();
            string str3 = drv["sidenumber"].ToString();
            string str4 = drv["InkCostExMarkup1"].ToString();
            string str5 = drv["InkCostExMarkup2"].ToString();
            string str6 = drv["InkCostExMarkup3"].ToString();
            string str7 = drv["InkCostExMarkup4"].ToString();
            string str8 = drv["InkMarkup1"].ToString();
            string str9 = drv["InkMarkup2"].ToString();
            string str10 = drv["InkMarkup3"].ToString();
            string str11 = drv["InkMarkup4"].ToString();
            string str12 = drv["InkMarkupPrice1"].ToString();
            string str13 = drv["InkMarkupPrice2"].ToString();
            string str14 = drv["InkMarkupPrice3"].ToString();
            string str15 = drv["InkMarkupPrice4"].ToString();
            string str16 = drv["InkSetupCharge"].ToString();
            string str17 = drv["InkMinimumCharge"].ToString();
            string str18 = drv["InkCostExMarkup_Actual1"].ToString();
            string str19 = drv["InkCostExMarkup_Actual2"].ToString();
            string str20 = drv["InkCostExMarkup_Actual3"].ToString();
            string str21 = drv["InkCostExMarkup_Actual4"].ToString();
            char[] chrArray = new char[] { '±' };
            string[] strArrays = str1.Split(chrArray);
            string[] strArrays1 = str.Split(new char[] { '±' });
            string[] strArrays2 = str4.Split(new char[] { '±' });
            string[] strArrays3 = str5.Split(new char[] { '±' });
            string[] strArrays4 = str6.Split(new char[] { '±' });
            string[] strArrays5 = str7.Split(new char[] { '±' });
            string[] strArrays6 = str8.Split(new char[] { '±' });
            string[] strArrays7 = str9.Split(new char[] { '±' });
            string[] strArrays8 = str10.Split(new char[] { '±' });
            string[] strArrays9 = str11.Split(new char[] { '±' });
            string[] strArrays10 = str12.Split(new char[] { '±' });
            string[] strArrays11 = str13.Split(new char[] { '±' });
            string[] strArrays12 = str14.Split(new char[] { '±' });
            string[] strArrays13 = str15.Split(new char[] { '±' });
            string[] strArrays14 = str16.Split(new char[] { '±' });
            string[] strArrays15 = str17.Split(new char[] { '±' });
            chrArray = new char[] { '±' };
            string[] strArrays16 = str18.Split(chrArray);
            chrArray = new char[] { '±' };
            string[] strArrays17 = str19.Split(chrArray);
            chrArray = new char[] { '±' };
            string[] strArrays18 = str20.Split(chrArray);
            chrArray = new char[] { '±' };
            string[] strArrays19 = str21.Split(chrArray);
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            if (this.QueryType == "add")
            {
                num1 = EstimatesBasePage.MarkupfromSettings_forinventoryitems(CompanyID, "inks", (long)0);
            }
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (strArrays[i] != "")
                {
                    if (strArrays1[i] != "")
                    {
                        num = Convert.ToDecimal(strArrays1[i]);
                    }
                    if (side1color > Sessioncount1)
                    {
                        if (this.QueryType != "add")
                        {
                            EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(strArrays[i]), num, PressID, str2, LithoTypeID, EstimateType, str3, "Parts1", Convert.ToDecimal(strArrays2[i]), Convert.ToDecimal(strArrays3[i]), Convert.ToDecimal(strArrays4[i]), Convert.ToDecimal(strArrays5[i]), Convert.ToDecimal(strArrays6[i]), Convert.ToDecimal(strArrays7[i]), Convert.ToDecimal(strArrays8[i]), Convert.ToDecimal(strArrays9[i]), Convert.ToDecimal(strArrays10[i]), Convert.ToDecimal(strArrays11[i]), Convert.ToDecimal(strArrays12[i]), Convert.ToDecimal(strArrays13[i]), Convert.ToDecimal(strArrays14[i]), Convert.ToDecimal(strArrays15[i]), Convert.ToDecimal(strArrays16[i]), Convert.ToDecimal(strArrays17[i]), Convert.ToDecimal(strArrays18[i]), Convert.ToDecimal(strArrays19[i]));
                        }
                        else
                        {
                            EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(strArrays[i]), num, PressID, str2, LithoTypeID, EstimateType, str3, "Parts1", Convert.ToDecimal(strArrays2[i]), Convert.ToDecimal(strArrays3[i]), Convert.ToDecimal(strArrays4[i]), Convert.ToDecimal(strArrays5[i]), num1, num1, num1, num1, Convert.ToDecimal(strArrays10[i]), Convert.ToDecimal(strArrays11[i]), Convert.ToDecimal(strArrays12[i]), Convert.ToDecimal(strArrays13[i]), Convert.ToDecimal(strArrays14[i]), Convert.ToDecimal(strArrays15[i]), Convert.ToDecimal(strArrays16[i]), Convert.ToDecimal(strArrays17[i]), Convert.ToDecimal(strArrays18[i]), Convert.ToDecimal(strArrays19[i]));
                        }
                    }
                }
                Sessioncount1++;
            }
        }

        private int GetQtyNo()
        {
            int num = 0;
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                long parentEstimateItemID = this.ParentEstimateItemID;
                if (parentEstimateItemID == (long)0)
                {
                    parentEstimateItemID = this.EstimateItemID;
                }
                foreach (DataRow row in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, parentEstimateItemID).Rows)
                {
                    num = Convert.ToInt16(row["QtyNumber"].ToString());
                }
            }
            if (string.Compare(this.modulename, "orders", true) == 0)
            {
                num = 1;
            }
            return num;
        }

        public void Getvaluefromsettings(string side, int CompanyID, long EstimateItemID_TempID, long PressID, int side1color, int side2color, long LithoTypeID, string EstimateType, int partcount)
        {
            if (side.ToLower().Trim() == "single")
            {
                int num = 0;
                decimal num1 = new decimal(0);
                IDataReader dataReader = SettingsBasePage.settings_lithopress_select_ink_rownum(CompanyID, PressID, 0);
                num1 = EstimatesBasePage.MarkupfromSettings_forinventoryitems(CompanyID, "inks", (long)0);
                while (dataReader.Read())
                {
                    if (side1color > num)
                    {
                        EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(dataReader["inkid"]), Convert.ToDecimal(dataReader["coverage"]), PressID, side, LithoTypeID, EstimateType, "side1", "Parts1", new decimal(0), new decimal(0), new decimal(0), new decimal(0), num1, num1, num1, num1, new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0));
                    }
                    num++;
                }
                return;
            }
            if (side.ToLower().Trim() == "double")
            {
                int num2 = 0;
                int num3 = 0;
                decimal num4 = new decimal(0);
                num4 = EstimatesBasePage.MarkupfromSettings_forinventoryitems(CompanyID, "inks", (long)0);
                IDataReader dataReader1 = SettingsBasePage.settings_lithopress_select_ink_rownum(CompanyID, PressID, 0);
                while (dataReader1.Read())
                {
                    if (side1color > num2)
                    {
                        EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(dataReader1["inkid"]), Convert.ToDecimal(dataReader1["coverage"]), PressID, side, LithoTypeID, EstimateType, "side1", "Parts1", new decimal(0), new decimal(0), new decimal(0), new decimal(0), num4, num4, num4, num4, new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0));
                    }
                    num2++;
                }
                IDataReader dataReader2 = SettingsBasePage.settings_lithopress_select_ink_rownum(CompanyID, PressID, 0);
                while (dataReader2.Read())
                {
                    if (side2color > num3)
                    {
                        EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(dataReader2["inkid"]), Convert.ToDecimal(dataReader2["coverage"]), PressID, side, LithoTypeID, EstimateType, "side2", "Parts1", new decimal(0), new decimal(0), new decimal(0), new decimal(0), num4, num4, num4, num4, new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0));
                    }
                    num3++;
                }
            }
        }

        public void Insert_activity_history(int CompanyID, long ModuleID, long EstimateItemID)
        {
            if (this.modulename.Contains("job"))
            {
                ModuleID = this.jobID;
            }
            else if (!this.modulename.Contains("invoice"))
            {
                ModuleID = this.EstimateID;
            }
            else
            {
                ModuleID = this.InvoiceID;
            }
            if (string.Compare(this.MainType, "add", true) == 0)
            {
                string str = "D";
                string str1 = "Sheet Fed Offset Pad Item";
                string empty = string.Empty;
                foreach (DataRow row in Notes.select_item_Title_for_Activity_History(CompanyID, ModuleID, EstimateItemID, str).Rows)
                {
                    empty = row["itemtitle"].ToString();
                }
                if (base.Request.Params["FromAddAnItem"] != null || base.Request.Params["FrmAddAnItem"] == "Y")
                {
                    string empty1 = string.Empty;
                    foreach (DataRow dataRow in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                    {
                        empty1 = dataRow["rownumber"].ToString();
                    }
                    if (this.modulename == "estimates")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", empty1);
                        this.objnotes.Estimate_type = str1;
                    }
                    else if (this.modulename == "jobs")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "job";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", empty1);
                        this.objnotes.Job_type = str1;
                    }
                    else if (this.modulename == "invoice")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", empty1);
                        this.objnotes.Invoice_type = str1;
                    }
                    else if (this.modulename == "orders")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", empty1);
                        this.objnotes.Estimate_type = str1;
                    }
                    this.objnotes.ModuleID = ModuleID;
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass = this.objJava;
                    DateTime now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objnotes.ItemID = EstimateItemID;
                    this.objN.NotesAdd(this.objnotes);
                    return;
                }
                string empty2 = string.Empty;
                if (this.modulename == "estimates")
                {
                    foreach (DataRow row1 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "", (long)0).Rows)
                    {
                        empty2 = row1["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = str1;
                    this.objnotes.Estimate_number = empty2;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
                else if (this.modulename == "jobs")
                {
                    foreach (DataRow dataRow1 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "job", (long)0).Rows)
                    {
                        empty2 = dataRow1["jobnumber"].ToString();
                    }
                    this.objnotes.Job_type = str1;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Job_number = empty2;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDirCreate);
                }
                else if (this.modulename == "invoice")
                {
                    foreach (DataRow row2 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "invoice", (long)0).Rows)
                    {
                        empty2 = row2["invoicenumber"].ToString();
                    }
                    this.objnotes.Invoice_type = str1;
                    this.objnotes.Invoice_number = empty2;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvDirCreate);
                }
                else if (this.modulename == "orders")
                {
                    foreach (DataRow dataRow2 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "", (long)0).Rows)
                    {
                        empty2 = dataRow2["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = str1;
                    this.objnotes.Estimate_number = empty2;
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
                this.objnotes.ModuleID = ModuleID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass1 = this.objJava;
                DateTime dateTime = DateTime.Now;
                _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), CompanyID, this.UserID, true);
                this.objnotes.CompanyID = CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
                return;
            }
            if (base.Request.Params["maintype"] != null && base.Request.Params["maintype"].ToString() == "edit" || base.Request.Params["subedit"].ToString().ToLower() == "y")
            {
                string str2 = "D";
                string str3 = "Sheet Fed Offset Pad Item";
                string empty3 = string.Empty;
                if (this.modulename == "estimates")
                {
                    if (str2.ToLower() != "d")
                    {
                        foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                        {
                            empty3 = row3["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty3;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                    }
                    else
                    {
                        foreach (DataRow dataRow3 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                        {
                            empty3 = (dataRow3["IsParentItem"].ToString().ToLower() != "true" ? dataRow3["ParentItemNumber"].ToString() : dataRow3["rownumber"].ToString());
                        }
                        this.objnotes.Item_number = empty3;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.Estimate_type = str3;
                        if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit" && this.ParentEstimateItemID == (long)0)
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                        }
                        else if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != "") || !(base.Request.Params["type"].ToLower() == "edit"))
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                        }
                        else
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemRerun);
                        }
                    }
                }
                else if (this.modulename == "jobs")
                {
                    foreach (DataRow row4 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                    {
                        empty3 = (row4["IsParentItem"].ToString().ToLower() != "true" ? row4["ParentItemNumber"].ToString() : row4["rownumber"].ToString());
                    }
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Item_number = empty3;
                    this.objnotes.Estimate_type = str3;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                    if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit" && this.ParentEstimateItemID == (long)0)
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                    }
                    else if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != "") || !(base.Request.Params["type"].ToLower() == "edit"))
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobSubItemRerun);
                    }
                }
                else if (this.modulename == "invoice")
                {
                    foreach (DataRow dataRow4 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                    {
                        empty3 = (dataRow4["IsParentItem"].ToString().ToLower() != "true" ? dataRow4["ParentItemNumber"].ToString() : dataRow4["rownumber"].ToString());
                    }
                    this.objnotes.Estimate_type = str3;
                    this.objnotes.Item_number = empty3;
                    this.objnotes.ModuleName = "invoice";
                    if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit" && this.ParentEstimateItemID == (long)0)
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                    }
                    else if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != "") || !(base.Request.Params["type"].ToLower() == "edit"))
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvSubItemRerun);
                    }
                }
                else if (this.modulename == "orders")
                {
                    if (str2.ToLower() != "d")
                    {
                        foreach (DataRow row5 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                        {
                            empty3 = row5["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty3;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdItemRerun);
                    }
                    else
                    {
                        foreach (DataRow dataRow5 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                        {
                            empty3 = (dataRow5["IsParentItem"].ToString().ToLower() != "true" ? dataRow5["ParentItemNumber"].ToString() : dataRow5["rownumber"].ToString());
                        }
                        this.objnotes.Item_number = empty3;
                        this.objnotes.Estimate_type = str3;
                        this.objnotes.ModuleName = "webstoreorder";
                        if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit" && this.ParentEstimateItemID == (long)0)
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdItemRerun);
                        }
                        else if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != "") || !(base.Request.Params["type"].ToLower() == "edit"))
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                        }
                        else
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderSubItemRerun);
                        }
                    }
                }
                this.objnotes.ModuleID = ModuleID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass2 = this.objnotes;
                commonClass _commonClass2 = this.objJava;
                DateTime now1 = DateTime.Now;
                _notesclass2.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now1.ToString(), CompanyID, this.UserID, true);
                this.objnotes.CompanyID = CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
            }
        }

        private void Insert_Ink_To_Session_From_DataBase()
        {
            DataTable dataTable = EstimatesBasePage.Ink_Select_BasedOn_estimateitemID(this.EstimateItemID);
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("SectionName", typeof(string));
            dataTable1.Columns.Add("InkID", typeof(string));
            dataTable1.Columns.Add("InkCoverage", typeof(string));
            dataTable1.Columns.Add("SidesPrinted", typeof(string));
            dataTable1.Columns.Add("sidenumber", typeof(string));
            dataTable1.Columns.Add("InkName", typeof(string));
            dataTable1.Columns.Add("InkCostExMarkup1", typeof(string));
            dataTable1.Columns.Add("InkCostExMarkup2", typeof(string));
            dataTable1.Columns.Add("InkCostExMarkup3", typeof(string));
            dataTable1.Columns.Add("InkCostExMarkup4", typeof(string));
            dataTable1.Columns.Add("InkMarkup1", typeof(string));
            dataTable1.Columns.Add("InkMarkup2", typeof(string));
            dataTable1.Columns.Add("InkMarkup3", typeof(string));
            dataTable1.Columns.Add("InkMarkup4", typeof(string));
            dataTable1.Columns.Add("InkMarkupPrice1", typeof(string));
            dataTable1.Columns.Add("InkMarkupPrice2", typeof(string));
            dataTable1.Columns.Add("InkMarkupPrice3", typeof(string));
            dataTable1.Columns.Add("InkMarkupPrice4", typeof(string));
            dataTable1.Columns.Add("InkSetupCharge", typeof(string));
            dataTable1.Columns.Add("InkMinimumCharge", typeof(string));
            dataTable1.Columns.Add("InkCostExMarkup_Actual1", typeof(string));
            dataTable1.Columns.Add("InkCostExMarkup_Actual2", typeof(string));
            dataTable1.Columns.Add("InkCostExMarkup_Actual3", typeof(string));
            dataTable1.Columns.Add("InkCostExMarkup_Actual4", typeof(string));
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = "";
            string str2 = "";
            int num = 1;
            string str3 = "";
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            string str6 = string.Empty;
            string empty7 = string.Empty;
            string str7 = string.Empty;
            string empty8 = string.Empty;
            string str8 = string.Empty;
            string empty9 = string.Empty;
            string str9 = string.Empty;
            string empty10 = string.Empty;
            string str10 = string.Empty;
            string empty11 = string.Empty;
            string str11 = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                string empty12 = string.Empty;
                string str12 = string.Empty;
                string empty13 = string.Empty;
                if (dataTable.Rows.Count != 1)
                {
                    empty12 = row["SectionName"].ToString();
                    str12 = row["sidenumber"].ToString();
                    empty13 = row["SidesPrinted"].ToString();
                    if (empty.Length <= 0 || !(empty12 != empty) && !(str != str12) && !(empty1 != empty13))
                    {
                        if (num == dataTable.Rows.Count)
                        {
                            str1 = string.Concat(str1, row["InkID"].ToString(), "±");
                            str2 = string.Concat(str2, row["InkCoverage"].ToString(), "±");
                            str3 = string.Concat(str3, row["InkName"].ToString(), "±");
                            empty2 = string.Concat(empty2, row["InkCostExMarkup1"].ToString(), "±");
                            empty3 = string.Concat(empty3, row["InkCostExMarkup2"].ToString(), "±");
                            empty4 = string.Concat(empty4, row["InkCostExMarkup3"].ToString(), "±");
                            str4 = string.Concat(str4, row["InkCostExMarkup4"].ToString(), "±");
                            empty5 = string.Concat(empty5, row["InkMarkup1"].ToString(), "±");
                            str5 = string.Concat(str5, row["InkMarkup2"].ToString(), "±");
                            empty6 = string.Concat(empty6, row["InkMarkup3"].ToString(), "±");
                            str6 = string.Concat(str6, row["InkMarkup4"].ToString(), "±");
                            empty7 = string.Concat(empty7, row["InkMarkupPrice1"].ToString(), "±");
                            str7 = string.Concat(str7, row["InkMarkupPrice2"].ToString(), "±");
                            empty8 = string.Concat(empty8, row["InkMarkupPrice3"].ToString(), "±");
                            str8 = string.Concat(str8, row["InkMarkupPrice4"].ToString(), "±");
                            empty9 = string.Concat(empty9, row["InkSetupCharge"].ToString(), "±");
                            str9 = string.Concat(str9, row["InkMinimumCharge"].ToString(), "±");
                            empty10 = string.Concat(empty10, row["InkCostExMarkup_Actual1"].ToString(), "±");
                            str10 = string.Concat(str10, row["InkCostExMarkup_Actual2"].ToString(), "±");
                            empty11 = string.Concat(empty11, row["InkCostExMarkup_Actual3"].ToString(), "±");
                            str11 = string.Concat(str11, row["InkCostExMarkup_Actual4"].ToString(), "±");
                            empty = empty12;
                            str = str12;
                            empty1 = empty13;
                            object[] objArray = new object[] { empty, str1, str2, empty1, str, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                            dataTable1.Rows.Add(objArray);
                        }
                        str1 = string.Concat(str1, row["InkID"].ToString(), "±");
                        str2 = string.Concat(str2, row["InkCoverage"].ToString(), "±");
                        str3 = string.Concat(str3, row["InkName"].ToString(), "±");
                        empty2 = string.Concat(empty2, row["InkCostExMarkup1"].ToString(), "±");
                        empty3 = string.Concat(empty3, row["InkCostExMarkup2"].ToString(), "±");
                        empty4 = string.Concat(empty4, row["InkCostExMarkup3"].ToString(), "±");
                        str4 = string.Concat(str4, row["InkCostExMarkup4"].ToString(), "±");
                        empty5 = string.Concat(empty5, row["InkMarkup1"].ToString(), "±");
                        str5 = string.Concat(str5, row["InkMarkup2"].ToString(), "±");
                        empty6 = string.Concat(empty6, row["InkMarkup3"].ToString(), "±");
                        str6 = string.Concat(str6, row["InkMarkup4"].ToString(), "±");
                        empty7 = string.Concat(empty7, row["InkMarkupPrice1"].ToString(), "±");
                        str7 = string.Concat(str7, row["InkMarkupPrice2"].ToString(), "±");
                        empty8 = string.Concat(empty8, row["InkMarkupPrice3"].ToString(), "±");
                        str8 = string.Concat(str8, row["InkMarkupPrice4"].ToString(), "±");
                        empty9 = string.Concat(empty9, row["InkSetupCharge"].ToString(), "±");
                        str9 = string.Concat(str9, row["InkMinimumCharge"].ToString(), "±");
                        empty10 = string.Concat(empty10, row["InkCostExMarkup_Actual1"].ToString(), "±");
                        str10 = string.Concat(str10, row["InkCostExMarkup_Actual2"].ToString(), "±");
                        empty11 = string.Concat(empty11, row["InkCostExMarkup_Actual3"].ToString(), "±");
                        str11 = string.Concat(str11, row["InkCostExMarkup_Actual4"].ToString(), "±");
                    }
                    else
                    {
                        object[] objArray1 = new object[] { empty, str1, str2, empty1, str, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                        dataTable1.Rows.Add(objArray1);
                        str1 = "";
                        str2 = "";
                        str3 = "";
                        empty2 = string.Empty;
                        empty3 = string.Empty;
                        empty4 = string.Empty;
                        str4 = string.Empty;
                        empty5 = string.Empty;
                        str5 = string.Empty;
                        empty6 = string.Empty;
                        str6 = string.Empty;
                        empty7 = string.Empty;
                        str7 = string.Empty;
                        empty8 = string.Empty;
                        str8 = string.Empty;
                        empty9 = string.Empty;
                        str9 = string.Empty;
                        empty10 = string.Empty;
                        str10 = string.Empty;
                        empty11 = string.Empty;
                        str11 = string.Empty;
                        str1 = string.Concat(row["InkID"].ToString(), "±");
                        str2 = string.Concat(row["InkCoverage"].ToString(), "±");
                        str3 = string.Concat(row["InkName"].ToString(), "±");
                        empty2 = string.Concat(row["InkCostExMarkup1"].ToString(), "±");
                        empty3 = string.Concat(row["InkCostExMarkup2"].ToString(), "±");
                        empty4 = string.Concat(row["InkCostExMarkup3"].ToString(), "±");
                        str4 = string.Concat(row["InkCostExMarkup4"].ToString(), "±");
                        empty5 = string.Concat(row["InkMarkup1"].ToString(), "±");
                        str5 = string.Concat(row["InkMarkup2"].ToString(), "±");
                        empty6 = string.Concat(row["InkMarkup3"].ToString(), "±");
                        str6 = string.Concat(row["InkMarkup4"].ToString(), "±");
                        empty7 = string.Concat(row["InkMarkupPrice1"].ToString(), "±");
                        str7 = string.Concat(row["InkMarkupPrice2"].ToString(), "±");
                        empty8 = string.Concat(row["InkMarkupPrice3"].ToString(), "±");
                        str8 = string.Concat(row["InkMarkupPrice4"].ToString(), "±");
                        empty9 = string.Concat(row["InkSetupCharge"].ToString(), "±");
                        str9 = string.Concat(row["InkMinimumCharge"].ToString(), "±");
                        empty10 = string.Concat(row["InkCostExMarkup_Actual1"].ToString(), "±");
                        str10 = string.Concat(row["InkCostExMarkup_Actual2"].ToString(), "±");
                        empty11 = string.Concat(row["InkCostExMarkup_Actual3"].ToString(), "±");
                        str11 = string.Concat(row["InkCostExMarkup_Actual4"].ToString(), "±");
                        if (num == dataTable.Rows.Count)
                        {
                            empty = empty12;
                            str = str12;
                            empty1 = empty13;
                            object[] objArray2 = new object[] { empty, str1, str2, empty1, str, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                            dataTable1.Rows.Add(objArray2);
                        }
                    }
                    empty = empty12;
                    str = str12;
                    empty1 = empty13;
                }
                else
                {
                    object[] item = new object[] { row["SectionName"], row["InkID"], row["InkCoverage"], row["SidesPrinted"], row["sidenumber"], row["InkName"], row["InkCostExMarkup1"], row["InkCostExMarkup2"], row["InkCostExMarkup3"], row["InkCostExMarkup4"], row["InkMarkup1"], row["InkMarkup2"], row["InkMarkup3"], row["InkMarkup4"], row["InkMarkupPrice1"], row["InkMarkupPrice2"], row["InkMarkupPrice3"], row["InkMarkupPrice4"], row["InkSetupCharge"], row["InkMinimumCharge"], row["InkCostExMarkup_Actual1"], row["InkCostExMarkup_Actual2"], row["InkCostExMarkup_Actual3"], row["InkCostExMarkup_Actual4"] };
                    dataTable1.Rows.Add(item);
                }
                num++;
            }
            base.Session["dtinks"] = dataTable1;
        }

        public void Main_Quantity_Insert(long EstimateItemID_TempID, string para, EstimatesItem Estitem)
        {
            Calculations calculation = new Calculations();
            string str = "D";
            int[] numArray = new int[4];
            decimal[] num = new decimal[4];
            decimal[] num1 = new decimal[4];
            decimal[] numArray1 = new decimal[4];
            decimal[] num2 = new decimal[4];
            decimal[] numArray2 = new decimal[4];
            decimal[] num3 = new decimal[4];
            decimal[] numArray3 = new decimal[4];
            decimal[] num4 = new decimal[4];
            decimal[] numArray4 = new decimal[4];
            decimal[] num5 = new decimal[4];
            decimal[] numArray5 = new decimal[4];
            decimal[] num6 = new decimal[4];
            decimal[] numArray6 = new decimal[4];
            decimal[] num7 = new decimal[4];
            decimal[] numArray7 = new decimal[4];
            decimal[] num8 = new decimal[4];
            decimal[] numArray8 = new decimal[4];
            decimal[] num9 = new decimal[4];
            decimal[] numArray9 = new decimal[4];
            decimal[] num10 = new decimal[4];
            decimal[] numArray10 = new decimal[4];
            decimal[] num11 = new decimal[4];
            decimal[] numArray11 = new decimal[4];
            decimal[] num12 = new decimal[4];
            decimal[] numArray12 = new decimal[4];
            decimal[] numArray13 = new decimal[4];
            decimal[] numArray14 = new decimal[4];
            decimal[] numArray15 = new decimal[4];
            decimal[] numArray16 = new decimal[4];
            decimal[] numArray17 = new decimal[4];
            decimal[] numArray18 = new decimal[4];
            decimal[] numArray19 = new decimal[4];
            decimal[] numArray20 = new decimal[4];
            decimal[] numArray21 = new decimal[4];
            decimal[] num13 = new decimal[4];
            decimal[] num14 = new decimal[4];
            decimal[] num15 = new decimal[4];
            decimal[] num16 = new decimal[4];
            decimal[] num17 = new decimal[4];
            decimal[] num18 = new decimal[4];
            decimal[] num19 = new decimal[4];
            decimal[] num20 = new decimal[4];
            decimal[] num21 = new decimal[4];
            decimal[] num22 = new decimal[4];
            decimal[] numArray22 = new decimal[4];
            decimal[] numArray30 = new decimal[4];
            decimal[] numArray31 = new decimal[4];
            
            for (int i = 1; i <= 4; i++)
            {
                int num23 = 0;
                if (i != 1)
                {
                    TextBox textBox = (TextBox)this.FindControl(string.Concat("txtQuantity_", i));
                    num23 = (textBox.Text != "" ? Convert.ToInt32(textBox.Text) : 0);
                }
                else if (this.txtQuantity.Text != "")
                {
                    num23 = Convert.ToInt32(this.txtQuantity.Text);
                }
                if (num23 <= 0)
                {
                    numArray[i - 1] = 0;
                    num[i - 1] = new decimal(0);
                    num1[i - 1] = new decimal(0);
                    numArray1[i - 1] = new decimal(0);
                    num2[i - 1] = new decimal(0);
                    num4[i - 1] = new decimal(0);
                    numArray4[i - 1] = new decimal(0);
                    num5[i - 1] = new decimal(0);
                    numArray5[i - 1] = new decimal(0);
                    num6[i - 1] = new decimal(0);
                    numArray6[i - 1] = new decimal(0);
                    num7[i - 1] = new decimal(0);
                    numArray7[i - 1] = new decimal(0);
                    num8[i - 1] = new decimal(0);
                    numArray8[i - 1] = new decimal(0);
                    num9[i - 1] = new decimal(0);
                    numArray11[i - 1] = new decimal(0);
                    num12[i - 1] = new decimal(0);
                    numArray12[i - 1] = new decimal(0);
                    numArray9[i - 1] = new decimal(0);
                    num10[i - 1] = new decimal(0);
                    numArray10[i - 1] = new decimal(0);
                    num11[i - 1] = new decimal(0);
                    this.PressJobTimeSide1[i - 1] = new decimal(0);
                    num13[i - 1] = new decimal(0);
                    num14[i - 1] = new decimal(0);
                    num15[i - 1] = new decimal(0);
                    num16[i - 1] = new decimal(0);
                    num17[i - 1] = new decimal(0);
                    num18[i - 1] = new decimal(0);
                    num19[i - 1] = new decimal(0);
                    num20[i - 1] = new decimal(0);
                    num21[i - 1] = new decimal(0);
                    num22[i - 1] = new decimal(0);
                    numArray22[i - 1] = new decimal(0);
                }
                else
                {
                    numArray[i - 1] = num23;
                    DataTable dataTable = new DataTable();
                    dataTable = EstimatesBasePage.estimate_litho_pad_item_select_reeng(this.CompanyID, EstimateItemID_TempID);
                    DataRow item = dataTable.Rows[0];
                    if (this.ProfitTaxKey.ToLower() != "database")
                    {
                        num[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
                        num1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "press", Convert.ToInt64(item["PressID"]));
                        if (Convert.ToInt64(item["GuillotineID"]) > (long)0)
                        {
                            numArray1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "guillotine", Convert.ToInt64(item["GuillotineID"]));
                        }
                        num2[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inks", (long)0);
                        numArray2[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inventoryitems", (long)0);
                        num3[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inventoryitems", (long)0);
                        numArray3[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inventoryitems", (long)0);
                    }
                    else
                    {
                        num[0] = Convert.ToDecimal(item["PaperMarkup"]);
                        num1[0] = Convert.ToDecimal(item["PressMarkUp"]);
                        numArray1[0] = Convert.ToDecimal(item["GuillotineMarkUp"]);
                        num[1] = Convert.ToDecimal(item["PaperMarkup2"]);
                        num1[1] = Convert.ToDecimal(item["PressMarkUp2"]);
                        numArray1[1] = Convert.ToDecimal(item["GuillotineMarkUp2"]);
                        num[2] = Convert.ToDecimal(item["PaperMarkup3"]);
                        num1[2] = Convert.ToDecimal(item["PressMarkUp3"]);
                        numArray1[2] = Convert.ToDecimal(item["GuillotineMarkUp3"]);
                        num[3] = Convert.ToDecimal(item["PaperMarkup4"]);
                        num1[3] = Convert.ToDecimal(item["PressMarkUp4"]);
                        numArray1[3] = Convert.ToDecimal(item["GuillotineMarkUp4"]);
                        num2[i - 1] = Convert.ToDecimal(item["InkMarkup"]);
                        numArray2[i - 1] = Convert.ToDecimal(item["PlateMarkup"]);
                        num3[i - 1] = Convert.ToDecimal(item["MakeReadyMarkUp"]);
                        numArray3[i - 1] = Convert.ToDecimal(item["WashUpMarkUp"]);
                    }
                    decimal num24 = new decimal(0);
                    decimal FullSheetArea = new decimal(0);
                    num5[i - 1] = calculation.PaperCalculation(this.CompanyID, str, num23, num[i - 1], item, ref num4[i - 1], ref numArray4[i - 1], ref numArray5[i - 1], ref num6[i - 1], ref num24,ref FullSheetArea);
                    numArray7[i - 1] = calculation.PressCalculation(this.CompanyID, str, num23, num1[i - 1], item, num6[i - 1], ref numArray6[i - 1], ref num7[i - 1], num24, ref this.PressJobTimeSide1[i - 1], ref num13[i - 1], ref num14[i - 1], ref num15[i - 1], ref num16[i - 1], ref num17[i - 1], ref num18[i - 1], ref num19[i - 1], ref num20[i - 1], ref num21[i - 1], ref num22[i - 1], i, ref numArray30[i - 1], ref numArray31[i - 1]);

                    DataTable dt = SettingsBasePage.Settings_Guillotine_Select_By_ID(this.CompanyID, Estitem.GuillotineID);
                    string GuillotineType = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        GuillotineType = dr["GuillotineType"].ToString();
                    }
                    if (GuillotineType == "Advanced")
                    {
                        string rowLand = Request.Form["hdnrow_land"];
                        string colLand = Request.Form["hdncol_land"];
                        string rowPort = Request.Form["hdnrow_port"];
                        string colPort = Request.Form["hdncol_port"];
                        var row = "0";
                        var col = "0";
                        decimal result = 0;
                        if (chkLandscape.Checked)
                        {
                            row = rowLand;
                            col = colLand;
                        }
                        else if (chkPortrait.Checked)
                        {
                            row = rowPort;
                            col = colPort;
                        }
                        else
                        {
                            row = rowPort;
                            col = colPort;
                        }
                        if ((chkGutters.Checked == true) && (chkManual.Checked == false))
                        {
                            result = (Convert.ToDecimal(col) * 2) + (Convert.ToDecimal(row) * 2);
                        }
                        else if ((chkGutters.Checked == false) && (chkManual.Checked == false))
                        {
                            result = (Convert.ToDecimal(col) + 1) + (Convert.ToDecimal(row) + 1);
                        }
                        else if ((chkGutters.Checked == true) && (chkManual.Checked == true))
                        {
                            result = (Convert.ToDecimal(this.txtManual.Text) + 3);
                        }
                        else
                        {
                            result = ((Convert.ToDecimal(this.txtManual.Text) * 2) + 2);
                        }
                        num11[i - 1] = result;
                    }

                    num8[i - 1] = calculation.GuillotineCalculation(this.CompanyID, str, num23, numArray1[i - 1], item, num6[i - 1], ref numArray8[i - 1], ref num9[i - 1], ref numArray9[i - 1], ref num10[i - 1], ref numArray10[i - 1], ref num11[i - 1], num24, ref numArray22[i - 1], GuillotineType);
                    numArray11[i - 1] = calculation.InkCalculation(this.CompanyID, str, num23, num2[i - 1], item, EstimateItemID_TempID, ref num12[i - 1], ref numArray12[i - 1], (long)0, 0, para, i, this.ProfitTaxKey.ToLower());
                    numArray13[i - 1] = calculation.PlateCalculation(this.CompanyID, str, num23, numArray2[i - 1], item, ref numArray14[i - 1], ref numArray15[i - 1], 0);
                    numArray16[i - 1] = calculation.MakeReadyCalculation(this.CompanyID, str, num23, num3[i - 1], item, ref numArray17[i - 1], ref numArray18[i - 1], 0);
                    numArray19[i - 1] = calculation.WashupCalculation(this.CompanyID, str, num23, numArray3[i - 1], item, ref numArray20[i - 1], ref numArray21[i - 1], 0);
                }
            }
            EstimatesBasePage.quantity_insert_offset_item(this.CompanyID, EstimateItemID_TempID, str, numArray[0], numArray5[0], num6[0], num4[0], numArray4[0], numArray6[0], num7[0], numArray9[0], num10[0], numArray10[0], num11[0], numArray8[0], num9[0], num12[0], numArray12[0], numArray14[0], numArray15[0], numArray17[0], numArray18[0], numArray20[0], numArray21[0], numArray[1], numArray5[1], num6[1], num4[1], numArray4[1], numArray6[1], num7[1], numArray9[1], num10[1], numArray10[1], num11[1], numArray8[1], num9[1], num12[1], numArray12[1], numArray14[1], numArray15[1], numArray17[1], numArray18[1], numArray20[1], numArray21[1], numArray[2], numArray5[2], num6[2], num4[2], numArray4[2], numArray6[2], num7[2], numArray9[2], num10[2], numArray10[2], num11[2], numArray8[2], num9[2], num12[2], numArray12[2], numArray14[2], numArray15[2], numArray17[2], numArray18[2], numArray20[2], numArray21[2], numArray[3], numArray5[3], num6[3], num4[3], numArray4[3], numArray6[3], num7[3], numArray9[3], num10[3], numArray10[3], num11[3], numArray8[3], num9[3], num12[3], numArray12[3], numArray14[3], numArray15[3], numArray17[3], numArray18[3], numArray20[3], numArray21[3], para, (long)0, this.PressJobTimeSide1[0], this.PressJobTimeSide1[1], this.PressJobTimeSide1[2], this.PressJobTimeSide1[3], num13[0], num13[1], num13[2], num13[3], num14[0], num14[1], num14[2], num14[3], num15[0], num15[1], num15[2], num15[3], num16[0], num16[1], num16[2], num16[3], num17[0], num17[1], num17[2], num17[3], num18[0], num18[1], num18[2], num18[3], num19[0], num19[1], num19[2], num19[3], num22[0], num22[1], num22[2], num22[3], numArray22[0], numArray22[1], numArray22[2], numArray22[3]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.ProfitTaxKey != null)
            {
                this.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
            }
            if (!base.IsPostBack)
            {
                base.Session["dtinks"] = null;
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            global.pgName = string.Empty;
            this.gloobj.setpagename("estimate");
            this.section = base.BaseSection;
            this.txtItemTitle.Focus();
            this.DateFormat = base.Session["DateFormat"].ToString();
            if (!base.IsPostBack)
            {
                this.ChkPriceForWholePack.Text = this.objLanguage.GetLanguageConversion("Price_For_Whole_Pack");
                this.ChkPaperSupplied.Text = this.objLanguage.GetLanguageConversion("Paper_Supplied");
                this.chkPrintSheet.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.ChkJobFlatCustom.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.chkPortrait.Text = this.objLanguage.GetLanguageConversion("Portrait");
                this.chkLandscape.Text = this.objLanguage.GetLanguageConversion("Landscape");
                this.chkManual.Text = "Manual";
                this.btnPrevious.Text = this.objLanguage.GetLanguageConversion("Previous");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Finish");
                this.img_UpdateDescription.Title = this.objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate");
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.modulename = "jobs";
                this.submodulename = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.modulename = "invoice";
                this.submodulename = "invoice";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                this.modulename = "estimates";
                this.submodulename = "estimate";
            }
            else
            {
                this.modulename = "orders";
                this.submodulename = "order";
            }
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.txtQuantity.Attributes.Add("style", "text-align:right");
            this.txtQuantity_2.Attributes.Add("style", "text-align:right");
            this.txtRunOnQty.Attributes.Add("style", "text-align:right");
            this.txtQuantity_3.Attributes.Add("style", "text-align:right");
            this.txtQuantity_4.Attributes.Add("style", "text-align:right");
            this.txtSetupSpoilage.Attributes.Add("style", "text-align:right");
            this.txtRunningSpoilage.Attributes.Add("style", "text-align:right");
            this.txtportrait.Attributes.Add("style", "text-align:right");
            this.txtlandscape.Attributes.Add("style", "text-align:right");
            this.txtManual.Attributes.Add("style", "text-align:right");
            this.txtNoOfPlates.Attributes.Add("style", "text-align:right");
            this.txtNoOfMakeReady.Attributes.Add("style", "text-align:right");
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
            }
            if (base.Request.QueryString["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (base.Request.QueryString["EstItemID"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            }
            try
            {
                if (base.Request.Params["parentestitemid"] != null)
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                if (base.Request.Params["parentesttype"] != null)
                {
                    this.ParentEstimateType = base.Request.Params["parentesttype"].ToString();
                }
                if (base.Request.QueryString["sectionid"] != null)
                {
                    this.EstimateBookletItemID = Convert.ToInt64(base.Request.QueryString["sectionid"]);
                }
                if (base.Request.QueryString["maintype"] != null)
                {
                    this.MainType = base.Request.QueryString["maintype"].ToString();
                }
            }
            catch
            {
                this.ParentEstimateItemID = (long)0;
            }
            this.Label1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Side_1"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
            this.Label2.Text = string.Concat(this.objLanguage.GetLanguageConversion("Side_2"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
            this.txtportrait.Attributes.Add("onclick", "javascript:Calculations();");
            this.txtportrait.Attributes.Add("onblur", "javascript:Calculations();");
            this.txtlandscape.Attributes.Add("onclick", "javascript:Calculations();");
            this.txtlandscape.Attributes.Add("onblur", "javascript:Calculations();");
            foreach (DataRow dataRow in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                this.hid_3DecimalPaperSize.Value = dataRow["Decimal3ForPaperSizes"] != DBNull.Value
                                   ? dataRow["Decimal3ForPaperSizes"].ToString() : "False";
                if (this.hid_3DecimalPaperSize.Value.ToLower() == "true")
                {
                    this.DecimalPaperSize = 3;
                }
                else
                {
                    this.DecimalPaperSize = 0;
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx"))
            {
                this.tabtype = "job";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_add.aspx"))
            {
                this.tabtype = "estimate";
            }
            else
            {
                this.tabtype = "invoice";
            }
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            DataSet dataSet = new DataSet();
            if (!base.IsPostBack)
            {
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    this.ChkPriceForWholePack.Checked = Convert.ToBoolean(row["DefaultPriceForWholePack"]);
                }
                DataSet dataSet1 = EstimatesBasePage.estimate_for_litho_add_all(this.CompanyID);
                if (dataSet1.Tables[0] != null && dataSet1.Tables[0].Rows.Count > 0)
                {
                    this.ddlPrintSheetSize.DataSource = dataSet1.Tables[0];
                    this.ddlPrintSheetSize.DataTextField = "PaperSizeName";
                    this.ddlPrintSheetSize.DataValueField = "PaperSizeID";
                    this.ddlPrintSheetSize.DataBind();
                    this.ddlJobItemSize.DataSource = dataSet1.Tables[0];
                    this.ddlJobItemSize.DataTextField = "PaperSizeName";
                    this.ddlJobItemSize.DataValueField = "PaperSizeID";
                    this.ddlJobItemSize.DataBind();
                    this.ddlPrintSheetSize.Items.Insert(0, "--- Select ---");
                    this.ddlPrintSheetSize.Items[0].Text = string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---");
                    this.ddlPrintSheetSize.Items[0].Value = "0";
                    this.ddlJobItemSize.Items.Insert(0, "--- Select ---");
                    this.ddlJobItemSize.Items[0].Text = string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---");
                    this.ddlJobItemSize.Items[0].Value = "0";
                }
                if (dataSet1.Tables[1] != null && dataSet1.Tables[1].Rows.Count > 0)
                {
                    this.hid_LithoPress.Value = dataSet1.Tables[1].Rows[0][0].ToString();
                }
                this.objest.Bind_Press(this.ddlPress, this.CompanyID, "--- Select ---");
                DataTable dataTable = new DataTable();
                dataTable = EstimatesBasePage.estimate_select_paper_size(this.CompanyID);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    litho_pad_item usercontrolItemLithoPadItem = this;
                    object obj1 = usercontrolItemLithoPadItem.dpaperhw;
                    object[] num = new object[] { obj1, Convert.ToInt32(dataRow["PaperSizeID"].ToString()), "±", Convert.ToDecimal(dataRow["Height"].ToString()), "±", Convert.ToDecimal(dataRow["Width"].ToString()), "»" };
                    usercontrolItemLithoPadItem.dpaperhw = string.Concat(num);
                }
                if (string.Compare(this.QueryType, "add", true) == 0)
                {
                    this.pnlPress.Visible = true;
                    this.pnlPressLoad.Visible = true;
                }
                if (!base.Request.Browser.IsBrowser("IE"))
                {
                    this.widthsize = "35%";
                }
                else
                {
                    this.widthsize = "38%";
                }
                this.txtQuantity.Attributes.Add("onblur", "AllowNumber(this,this.value);validatethis(this.value)");
                this.txtRunOnQty.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtQuantity_2.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtQuantity_3.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtQuantity_4.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtSetupSpoilage.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtRunningSpoilage.Attributes.Add("onblur", "AllowNumber(this,this.value);todecimal_function(this,this.value);");
                this.txtNoOfPagesRequired.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtPagesPerSection.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtNoOfLeavesPerPad.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtsectionheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();roundTo3or2DecimalPlaces(this,this.value);");
                this.txtsectionwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();roundTo3or2DecimalPlaces(this,this.value);");
                this.txtitemheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();roundTo3or2DecimalPlaces(this,this.value);");
                this.txtitemwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();roundTo3or2DecimalPlaces(this,this.value);");
                this.txtGutterHorizontal.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                this.txtGutterVertical.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                this.txtNoOfPlates.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtNoOfMakeReady.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                if (dataSet1.Tables[2] != null && dataSet1.Tables[2].Rows.Count > 0)
                {
                    this.inkcount = Convert.ToInt32(dataSet1.Tables[2].Rows[0][0].ToString());
                }
                this.inkcount = (this.inkcount > 12 ? 12 : this.inkcount);
                for (int i = 0; i <= 24; i++)
                {
                    this.ddlMakeReady.Items.Add(string.Concat(i));
                    this.ddlWashUp.Items.Add(string.Concat(i));
                    this.ddlPlates.Items.Add(string.Concat(i));
                }
                foreach (DataRow row1 in EstimatesBasePage.CopyesttitletoitemTitle(this.CompanyID, this.EstimateID).Rows)
                {
                    this.txtItemTitle.Text = this.objBase.SpecialDecode(row1["EstimateTitle"].ToString());
                }
                try
                {
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        this.txtItemTitle.Text = "";
                    }
                }
                catch
                {
                }
            }
            if (string.Compare(this.QueryType, "edit", true) != 0)
            {
                this.QtyNo = this.GetQtyNo();
            }
            else
            {
                this.Select_Litho_Pad_Item(this.ParentEstimateItemID, this.ParentEstimateType);
                this.btnPrevious.Visible = true;
                if (!base.IsPostBack)
                {
                    this.Div_ItemDescn.Visible = true;
                    foreach (DataRow dataRow1 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                    {
                        if (dataRow1["UpdateItemDescription"].ToString().ToLower() != "true")
                        {
                            this.Chk_ItemDescn.Checked = false;
                        }
                        else
                        {
                            this.Chk_ItemDescn.Checked = true;
                        }
                    }
                }
                if (!base.IsPostBack)
                {
                    this.Insert_Ink_To_Session_From_DataBase();
                }
            }
            try
            {
                if (base.Request.QueryString["subedit"] != null)
                {
                    this.subedit = "D";
                    this.Div_ItemDescn.Visible = false;
                }
            }
            catch
            {
                this.subedit = "0";
            }
            foreach (DataRow row2 in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
            {
                this.IsItemCompleted = Convert.ToInt16(row2["IsItemCompleted"].ToString());
                this.IsProductCreated = Convert.ToInt16(row2["IsProductCreated"].ToString());
            }
            if (this.IsProductCreated == 1)
            {
                this.Div_Productcatalogue.Visible = true;
            }
            if (base.Request.QueryString["frmcopyitem"] != null)
            {
                this.frmcopyitem = base.Request.QueryString["frmcopyitem"].ToString();
            }
            if (string.Compare(this.QueryType, "add", true) == 0 && this.ParentEstimateItemID > (long)0 && !base.IsPostBack)
            {
                DataTable quantityForItems = EstimatesBasePage.getQuantity_for_items(this.ParentEstimateItemID, this.ParentEstimateType, this.modulename);
                foreach (DataRow dataRow2 in quantityForItems.Rows)
                {
                    this.txtQuantity.Text = dataRow2["Quantity1"].ToString();
                    this.txtQuantity_2.Text = dataRow2["Quantity2"].ToString();
                    this.txtRunOnQty.Text = dataRow2["Quantity2"].ToString();
                    this.txtQuantity_3.Text = dataRow2["Quantity3"].ToString();
                    this.txtQuantity_4.Text = dataRow2["Quantity4"].ToString();
                }
            }
            if (this.QueryType == "add" && !base.IsPostBack && EstimateBasePage.DefaultPageSize_Select((long)this.CompanyID) == 1)
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:DefaultLanding();", true);
            }
        }

        public void Popup_inkvalue_insert(long EstimateItemID_TempID, string para, long PressID, string side, string EstimateType, long LithoTypeID, int partcount, int side1color, int side2color, string querytype)
        {
            if (base.Session["dtinks"] == null)
            {
                this.Getvaluefromsettings(side, this.CompanyID, EstimateItemID_TempID, PressID, side1color, side2color, LithoTypeID, EstimateType, partcount);
            }
            else
            {
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                DataTable item = (DataTable)base.Session["dtinks"];
                if (side.Trim().ToLower() != "single")
                {
                    DataRow[] dataRowArray = item.Select(string.Concat("SectionName='Parts", partcount, "' and SidesPrinted='single'  and sidenumber='side1'"));
                    if ((int)dataRowArray.Length > 0)
                    {
                        dataRowArray[0]["SidesPrinted"] = side.ToString();
                    }
                }
                else
                {
                    DataRow[] dataRowArray1 = item.Select(string.Concat("SectionName='Parts", partcount, "' and SidesPrinted='Double'  and sidenumber='side2'"));
                    if ((int)dataRowArray1.Length > 0)
                    {
                        for (int i = 0; i < (int)dataRowArray1.Length; i++)
                        {
                            item.Rows.Remove(dataRowArray1[i]);
                        }
                        DataRow[] str2 = item.Select(string.Concat("SectionName='Parts", partcount, "' and SidesPrinted='Double'  and sidenumber='side1'"));
                        if ((int)str2.Length > 0)
                        {
                            str2[0]["SidesPrinted"] = side.ToString();
                        }
                    }
                }
                int num = 0;
                if ((int)item.Select(string.Concat("SectionName='Parts", partcount, "'")).Length <= 0)
                {
                    this.Getvaluefromsettings(side, this.CompanyID, EstimateItemID_TempID, PressID, side1color, side2color, LithoTypeID, EstimateType, partcount);
                    return;
                }
                if (side.Trim().ToLower() == "single")
                {
                    if ((int)item.Select(string.Concat("sidenumber='side1' and SectionName='Parts", partcount, "'")).Length <= 0)
                    {
                        this.Getvaluefromsettings(side, this.CompanyID, EstimateItemID_TempID, PressID, side1color, side2color, LithoTypeID, EstimateType, partcount);
                        return;
                    }
                    num = 0;
                    DataRow[] dataRowArray2 = item.Select(string.Concat("sidenumber='side1' and SectionName='Parts", partcount, "'"));
                    for (int j = 0; j < (int)dataRowArray2.Length; j++)
                    {
                        DataRow dataRow = dataRowArray2[j];
                        this.getinkvalues(dataRow, num, side1color, this.CompanyID, EstimateItemID_TempID, PressID, LithoTypeID, EstimateType, partcount);
                    }
                    return;
                }
                bool flag = false;
                if ((int)item.Select(string.Concat("sidenumber='side1' and SectionName='Parts", partcount, "'")).Length <= 0)
                {
                    this.Getvaluefromsettings(side, this.CompanyID, EstimateItemID_TempID, PressID, side1color, side2color, LithoTypeID, EstimateType, partcount);
                }
                else
                {
                    flag = true;
                    num = 0;
                    DataRow[] dataRowArray3 = item.Select(string.Concat("sidenumber='side1' and SectionName='Parts", partcount, "'"));
                    for (int k = 0; k < (int)dataRowArray3.Length; k++)
                    {
                        DataRow dataRow1 = dataRowArray3[k];
                        this.getinkvalues(dataRow1, num, side1color, this.CompanyID, EstimateItemID_TempID, PressID, LithoTypeID, EstimateType, partcount);
                    }
                }
                if ((int)item.Select(string.Concat("sidenumber='side2' and SectionName='Parts", partcount, "'")).Length > 0)
                {
                    num = 0;
                    DataRow[] dataRowArray4 = item.Select(string.Concat("sidenumber='side2' and SectionName='Parts", partcount, "'"));
                    for (int l = 0; l < (int)dataRowArray4.Length; l++)
                    {
                        DataRow dataRow2 = dataRowArray4[l];
                        this.getinkvalues(dataRow2, num, side2color, this.CompanyID, EstimateItemID_TempID, PressID, LithoTypeID, EstimateType, partcount);
                    }
                    return;
                }
                if (!flag)
                {
                    this.Getvaluefromsettings(side, this.CompanyID, EstimateItemID_TempID, PressID, side1color, side2color, LithoTypeID, EstimateType, partcount);
                    return;
                }
            }
        }

        private void Select_Litho_Pad_Item(long ParentItemID, string ParentItemType)
        {
            bool flag = false;
            bool flag1 = false;
            if (!base.IsPostBack)
            {
                DataTable dataTable = EstimatesBasePage.estimate_qty_select(this.CompanyID, this.EstimateItemID, (long)0);
                foreach (DataRow row in dataTable.Rows)
                {
                    int num = Convert.ToInt32(row["Qty1"]);
                    int num1 = Convert.ToInt32(row["Qty2"]);
                    int num2 = Convert.ToInt32(row["Qty3"]);
                    int num3 = Convert.ToInt32(row["Qty4"]);
                    if (num != 0)
                    {
                        this.txtQuantity.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num.ToString()), 0, "", true, false, false);
                    }
                    if (num1 != 0)
                    {
                        this.txtQuantity_2.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num1.ToString()), 0, "", true, false, false);
                        this.str_QtyType = "more";
                    }
                    if (num2 != 0)
                    {
                        this.txtQuantity_3.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num2.ToString()), 0, "", true, false, false);
                        this.str_QtyType = "more";
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    this.txtQuantity_4.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num3.ToString()), 0, "", true, false, false);
                    this.str_QtyType = "more";
                }
                this.QtyNo = this.GetQtyNo();
            }
            DataTable dataTable1 = EstimatesBasePage.estimate_litho_pad_item_select(this.CompanyID, this.EstimateItemID);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                this.EstimateLithoPadItemID = Convert.ToInt64(dataRow["EstimateLithoPadItemID"]);
                this.EstimateCalculationID = Convert.ToInt64(dataRow["EstimateCalculationID"]);
                this.hid_IsSheetCustom.Value = dataRow["IsSheetCustom"].ToString();
                this.hid_IsJobCustom.Value = dataRow["IsJobCustom"].ToString();
                if (!base.IsPostBack)
                {
                    this.hid_width.Value = dataRow["Width"].ToString();
                    this.hid_height.Value = dataRow["Height"].ToString();
                    this.hdn_PaperProperties.Value = string.Concat("0µ", dataRow["Width"].ToString(), "µ", dataRow["Height"].ToString());
                    this.txtItemTitle.Text = this.objBase.SpecialDecode(dataRow["ItemTitle"].ToString());
                    this.ddlPress.SelectedValue = dataRow["PressID"].ToString();
                    this.Estitem.PressID = Convert.ToInt64(dataRow["PressID"].ToString());
                    this.lblDefaultPaper.Text = this.objBase.SpecialDecode(dataRow["PaperName"].ToString());
                    this.hdnpaperID.Value = dataRow["paperid"].ToString();
                    this.ChkPriceForWholePack.Checked = Convert.ToBoolean(dataRow["IsPricePerPack"].ToString());
                    this.ChkPaperSupplied.Checked = Convert.ToBoolean(dataRow["IsPaperSupplied"].ToString());
                    this.txtSetupSpoilage.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["SetUpSpoilage"].ToString()), 0, "", true, false, false);
                    this.txtRunningSpoilage.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["RunningSpoilage"].ToString()), 0, "", false, false, false);
                    this.txtNoOfLeavesPerPad.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["LeavesPerPad"].ToString()), 0, "", true, false, false);
                    dataRow["LeavesPerPad"].ToString();
                    this.ddlNoOfSide.SelectedValue = dataRow["SidesPrinted"].ToString();
                    this.ddlSide1Color.SelectedValue = dataRow["Side1Color"].ToString();
                    this.ddlSide2Color.SelectedValue = dataRow["Side2Color"].ToString();
                    this.lblDefaultPlates.Text = this.objBase.SpecialDecode(dataRow["PlateName"].ToString());
                    this.hdnplateID.Value = dataRow["plateid"].ToString();
                    this.ddlPlates.SelectedValue = dataRow["Noofplates"].ToString();
                    this.ddlMakeReady.SelectedValue = dataRow["NoofMakeReady"].ToString();
                    this.ddlWashUp.SelectedValue = dataRow["NoofWashup"].ToString();
                    this.lblPaperWeight.Text = dataRow["PaprWeight"].ToString();
                    this.txtNoOfPlates.Text = dataRow["Noofplates"].ToString();
                    this.txtNoOfMakeReady.Text = dataRow["NoofMakeReady"].ToString();
                    this.ddlPrintSheetSize.SelectedValue = dataRow["PrintSheetSizeID"].ToString();
                    this.txtsectionheight.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["SheetHeight"].ToString()), this.DecimalPaperSize, "", false, false, false);
                    this.txtsectionwidth.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["SheetWidth"].ToString()), this.DecimalPaperSize, "", false, false, false);
                    this.chkPrintSheet.Checked = Convert.ToBoolean(dataRow["IsSheetCustom"].ToString());
                    this.ddlJobItemSize.SelectedValue = dataRow["JobFlatSizeID"].ToString();
                    this.txtitemheight.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["JobHeight"].ToString()), this.DecimalPaperSize, "", false, false, false);
                    this.txtitemwidth.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["JobWidth"].ToString()), this.DecimalPaperSize, "", false, false, false);
                    this.ChkJobFlatCustom.Checked = Convert.ToBoolean(dataRow["IsJobCustom"].ToString());
                    this.chkGutters.Checked = Convert.ToBoolean(dataRow["IsIncludeGutters"].ToString());
                    this.txtGutterHorizontal.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["GutterHorizontal"].ToString()), 0, "", false, false, false);
                    this.txtGutterVertical.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["GutterVertical"].ToString()), 0, "", false, false, false);
                    this.ChkPressRestrictions.Checked = Convert.ToBoolean(dataRow["IsPressRestrictions"].ToString());
                    this.txtportrait.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["PortraitValue"].ToString()), 0, "", true, false, false);
                    this.txtlandscape.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["LandscapeValue"].ToString()), 0, "", true, false, false);
                    this.txtManual.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["ManualValue"].ToString()), 0, "", true, false, false);
                    this.lblGuillotine.Text = this.objBase.SpecialDecode(dataRow["GuillotineName"].ToString());
                    this.hid_GuillotineID.Value = dataRow["GuillotineID"].ToString();
                    this.chkFirstTrim.Checked = Convert.ToBoolean(dataRow["IsFirstTrim"].ToString());
                    this.chkSecondTrim.Checked = Convert.ToBoolean(dataRow["IsSecondTrim"].ToString());
                    this.chkTurn.Checked = Convert.ToBoolean(dataRow["WorknTurn"].ToString());
                    this.chkTumble.Checked = Convert.ToBoolean(dataRow["WorknTumble"].ToString());
                    this.chkPerfecting.Checked = Convert.ToBoolean(dataRow["Perfecting"].ToString());
                    this.hid_isPressPerfect.Value = dataRow["isPressPerfect"].ToString();
                    if (this.chkTumble.Checked || this.chkTurn.Checked || this.chkPerfecting.Checked)
                    {
                        this.chkSheetWork.Checked = false;
                    }
                    else
                    {
                        this.chkSheetWork.Checked = true;
                    }
                    this.txtItemTitle.Text = this.objBase.SpecialDecode(dataRow["ItemTitle"].ToString());
                    flag = Convert.ToBoolean(dataRow["MakeReadyPerPlateCheck"].ToString());
                    flag1 = Convert.ToBoolean(dataRow["WashupChargePerColourCheck"].ToString());
                    this.hdn_InkType.Value = dataRow["InkType"].ToString();
                    if (dataRow["PrintLayout"].ToString() == "L")
                    {
                        this.chkPortrait.Checked = false;
                        this.chkLandscape.Checked = true;
                        this.chkManual.Checked = false;
                    }
                    else if(dataRow["PrintLayout"].ToString() == "P")
                    {
                        this.chkPortrait.Checked = true;
                        this.chkLandscape.Checked = false;
                        this.chkManual.Checked = false;
                    }
                    else
                    {
                        this.chkPortrait.Checked = false;
                        this.chkLandscape.Checked = false;
                        this.chkManual.Checked = true;
                    }
                    if (!base.IsPostBack)
                    {
                        this.hdnOldPressID.Value = dataRow["PressID"].ToString();
                        this.hdnOldPaperID.Value = dataRow["PaperID"].ToString();
                        this.hdnOldGuillotineID.Value = dataRow["GuillotineID"].ToString();
                        this.hdn_InvpaperID.Value = dataRow["PaperID"].ToString();
                    }
                }
                this.IsPaperUnitPriceLocked = Convert.ToBoolean(dataRow["IsPaperUnitPriceLocked"].ToString());
            }
            if (flag)
            {
                this.pnlEdit_MakeReady.Visible = true;
            }
            if (flag1)
            {
                this.pnlEdit_WashUp.Visible = true;
            }
            if (this.chkGutters.Checked)
            {
                this.pnlEdit_Gutter.Visible = true;
            }
            if (this.ChkJobFlatCustom.Checked)
            {
                this.pnlEdit_jobsheet.Visible = true;
            }
            if (this.chkPrintSheet.Checked)
            {
                this.pnlEdit_Printsheet.Visible = true;
            }
        }

        private void Update_LithoPad_Item()
        {
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            estimatesItem.EstimateItemID = (long)0;
            estimatesItem.EstQuantityID = (long)0;
            this.EstType = "D";
            string empty = string.Empty;
            if (chkPortrait.Checked)
            {
                empty = "P";
            }
            else if (chkLandscape.Checked)
            {
                empty = "L";
            }
            else
            {
                empty = "M";
            }
            //empty = (!this.chkPortrait.Checked ? "L" : "P");
            EstimatesBasePage.Ink_Delete_BasedOn_estimateitemID(this.EstimateItemID);
            this.txtGutterHorizontal.Text = (this.txtGutterHorizontal.Text == "" ? "0" : this.txtGutterHorizontal.Text);
            this.txtGutterVertical.Text = (this.txtGutterVertical.Text == "" ? "0" : this.txtGutterVertical.Text);
            this.txtportrait.Text = (this.txtportrait.Text == "" ? "0" : this.txtportrait.Text);
            this.txtlandscape.Text = (this.txtlandscape.Text == "" ? "0" : this.txtlandscape.Text);
            this.txtManual.Text = (this.txtManual.Text == "" ? "0" : this.txtManual.Text);
            this.txtNoOfPlates.Text = (this.txtNoOfPlates.Text == "" ? "0" : this.txtNoOfPlates.Text);
            this.txtNoOfMakeReady.Text = (this.txtNoOfMakeReady.Text == "" ? "0" : this.txtNoOfMakeReady.Text);
            estimatesItem.EstimateItemID = this.EstimateItemID;
            if (this.EstimateItemID != (long)0 && this.EstimateLithoPadItemID != (long)0)
            {
                if ((string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0) && this.hdn_invStockBack.Value.ToLower() == "yes")
                {
                    this.summryCls.Call_Inventory_Adjustment("cancelled", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                }
                EstimatesBasePage.estimate_litho_pad_item_insert(this.CompanyID, this.EstimateLithoPadItemID, this.EstimateItemID, Convert.ToInt64(this.ddlPress.SelectedValue), Convert.ToInt64(this.hdnpaperID.Value), Convert.ToBoolean(this.ChkPriceForWholePack.Checked), Convert.ToBoolean(this.ChkPaperSupplied.Checked), Convert.ToDecimal(this.txtSetupSpoilage.Text), Convert.ToDecimal(this.txtRunningSpoilage.Text), Convert.ToDecimal(this.txtNoOfLeavesPerPad.Text), this.ddlNoOfSide.SelectedItem.Text, this.ddlSide1Color.SelectedItem.Text, this.ddlSide2Color.SelectedItem.Text, Convert.ToInt64(this.hdnplateID.Value), this.txtNoOfPlates.Text, this.txtNoOfMakeReady.Text, this.ddlWashUp.SelectedItem.Text, Convert.ToInt32(this.ddlPrintSheetSize.SelectedValue), Convert.ToBoolean(this.chkPrintSheet.Checked), Convert.ToDecimal(this.txtsectionheight.Text), Convert.ToDecimal(this.txtsectionwidth.Text), Convert.ToInt32(this.ddlJobItemSize.SelectedValue), Convert.ToBoolean(this.ChkJobFlatCustom.Checked), Convert.ToDecimal(this.txtitemheight.Text), Convert.ToDecimal(this.txtitemwidth.Text), Convert.ToBoolean(this.chkGutters.Checked), Convert.ToDecimal(this.txtGutterHorizontal.Text), Convert.ToDecimal(this.txtGutterVertical.Text), Convert.ToBoolean(this.ChkPressRestrictions.Checked), empty, Convert.ToDecimal(this.hdn_PortraitValue.Value), Convert.ToDecimal(this.hdn_LandscapeValue.Value), Convert.ToInt64(this.hid_GuillotineID.Value), this.txtItemTitle.Text, Convert.ToInt32(base.Session["UserID"]), 0, DateTime.Now, Convert.ToBoolean(this.chkFirstTrim.Checked), Convert.ToBoolean(this.chkSecondTrim.Checked), Convert.ToBoolean(this.chkTurn.Checked), Convert.ToBoolean(this.chkTumble.Checked), 0, "", this.chkPerfecting.Checked, Convert.ToDecimal(this.hdnManual.Value),this.chkSheetWork.Checked);
            }
            this.PressID = Convert.ToInt64(this.ddlPress.SelectedValue);
            this.Popup_inkvalue_insert(this.EstimateItemID, "", this.PressID, this.ddlNoOfSide.SelectedItem.Text, this.EstType, (long)0, 1, Convert.ToInt32(this.ddlSide1Color.SelectedItem.Text), Convert.ToInt32(this.ddlSide2Color.SelectedItem.Text), "update");
            estimatesItem.GuillotineID = Convert.ToInt64(this.hid_GuillotineID.Value);
            estimatesItem.PressType = 'S';
            estimatesItem.PaperID = Convert.ToInt64(this.hdnpaperID.Value);
            double num = 0;
            DataTable dataTable = EstimatesBasePage.SelectPlateunitprice_eachSectin(Convert.ToInt32(this.hdnplateID.Value));
            foreach (DataRow row in dataTable.Rows)
            {
                num = Convert.ToDouble(row["PlateUnitPrice"]);
            }
            this.Estimate_Calcukation_Update(this.EstimateItemID, (long)0, estimatesItem.PaperID, this.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, this.EstType, num, this.IsPaperUnitPriceLocked);
            if (this.EstimateItemID != (long)0 && this.EstimateLithoPadItemID != (long)0)
            {
                this.Main_Quantity_Insert(this.EstimateItemID, "updateqty", estimatesItem);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
                if (this.Chk_ItemDescn.Checked)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "D", true);
                }
                if (this.IsProductCreated == 1)
                {
                    int num1 = 0;
                    if (this.chkPoduct1.Checked)
                    {
                        num1 = 1;
                    }
                    else if (this.chkPoduct2.Checked)
                    {
                        num1 = 2;
                    }
                    DataTable dataTable1 = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "D");
                    if (dataTable1.Rows.Count > 0)
                    {
                        dataTable1.Rows[0]["PricecatalogueID"].ToString();
                        if (num1 == 1 || num1 == 2)
                        {
                            EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable1.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "D", num1);
                        }
                    }
                }
                this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    int qtyNo = this.GetQtyNo() - 1;
                    JobBasePage.Update_EstimateJobTime(this.EstimateItemID, this.PressJobTimeSide1[qtyNo]);
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "D");
                    this.summryCls.isrerun = true;
                    this.summryCls.Call_Inventory_Adjustment("progressed", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                    if (this.ReduceStockType.ToLower() == "e")
                    {
                        this.summryCls.Call_Inventory_Adjustment("completed", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                    }
                    if (string.Compare(this.modulename, "invoice", true) == 0 && this.ReduceStockType.ToLower() == "i")
                    {
                        this.summryCls.Call_Inventory_Adjustment("completed-invoice", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                    }
                }
            }
            base.Session["dtinks"] = null;
            if (this.ParentEstimateItemID == (long)0)
            {
                EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "D");
            }
            string str = string.Empty;
            if (this.modulename == "invoice")
            {
                str = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            else if (this.modulename == "jobs")
            {
                str = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            if (this.modulename == "orders")
            {
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response.Redirect(string.Concat(estimateID));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (this.ParentEstimateItemID != (long)0)
            {
                if (str.ToString().ToLower() == "yes")
                {
                    HttpResponse response1 = base.Response;
                    object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response1.Redirect(string.Concat(estimateID1));
                    return;
                }
                HttpResponse httpResponse1 = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                httpResponse1.Redirect(string.Concat(objArray1));
                return;
            }
            if (str.ToString().ToLower() == "yes")
            {
                HttpResponse response2 = base.Response;
                object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                response2.Redirect(string.Concat(estimateID2));
                return;
            }
            HttpResponse httpResponse2 = base.Response;
            object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
            httpResponse2.Redirect(string.Concat(objArray2));
        }
    }
}
