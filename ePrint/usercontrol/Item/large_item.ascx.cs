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
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

namespace ePrint.usercontrol.Item
{
    public partial class large_item : UsercontrolBasePage
    {
        //protected usercontrol_settings_Loading ucLoading;

        //protected Label Label10;

        //protected TextBox txtItemTitle;

        //protected Label Label3;

        //protected DropDownList ddlEstimateType;

        //protected Label Label4;

        //protected DropDownList ddlProductType;

        //protected Label Label6;

        //protected Label Label7;

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

        //protected HiddenField hid_DigitalPress;

        //protected HiddenField hid_LargeFormatPress;

        //protected HiddenField hid_DefaultDigitalPress;

        //protected HiddenField hid_DefaultLargePress;

        //protected Label Label21;

        //protected Label Label28;

        //protected Label lbl_m1;

        //protected HiddenField hdn_PaperProperties;

        //protected HtmlGenericControl Divplus1;

        //protected Label lblDefaultPaper;

        //protected Label lblPaperWeight;

        //protected HiddenField hdnpaperID;

        //protected CheckBox Chk_PriceForWholePack1;

        //protected CheckBox Chk_PaperSupplied1;

        //protected Label lbl_m2;

        //protected HiddenField hdn_PaperProperties2;

        //protected HtmlGenericControl Divplus2;

        //protected Label lbl_paper2;

        //protected Label lblPaperWt2;

        //protected HiddenField hdnpaperID2;

        //protected CheckBox Chk_PriceForWholePack2;

        //protected CheckBox Chk_PaperSupplied2;

        //protected HtmlGenericControl divpaperstock2;

        //protected Label lbl_m3;

        //protected HiddenField hdn_PaperProperties3;

        //protected HtmlGenericControl Divplus3;

        //protected Label lbl_paper3;

        //protected Label lblPaperWt3;

        //protected HiddenField hdnpaperID3;

        //protected CheckBox Chk_PriceForWholePack3;

        //protected CheckBox Chk_PaperSupplied3;

        //protected HtmlGenericControl divpaperstock3;

        //protected Label lbl_m4;

        //protected HiddenField hdn_PaperProperties4;

        //protected HtmlGenericControl Divplus4;

        //protected Label lbl_paper4;

        //protected Label lblPaperWt4;

        //protected HiddenField hdnpaperID4;

        //protected CheckBox Chk_PriceForWholePack4;

        //protected CheckBox Chk_PaperSupplied4;

        //protected HtmlGenericControl divpaperstock4;

        //protected Label lbl_m5;

        //protected HiddenField hdn_PaperProperties5;

        //protected HtmlGenericControl Divplus5;

        //protected Label lbl_paper5;

        //protected Label lblPaperWt5;

        //protected HiddenField hdnpaperID5;

        //protected CheckBox Chk_PriceForWholePack5;

        //protected CheckBox Chk_PaperSupplied5;

        //protected HtmlGenericControl divpaperstock5;

        //protected HtmlGenericControl div_materials;

        //protected HtmlGenericControl divaddmorepaper;

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

        //protected DropDownList ddlNoOfSide;

        //protected Label lbldoubleside;

        //protected CheckBox chkDoubleSided;

        //protected Label Label11;

        //protected DropDownList ddlColors;

        //protected Label lblinkcovside1;

        //protected TextBox txtInkCoverageSide1;

        //protected TextBox txtWhiteInkCoverageSide1;

        //protected Label lblside2color;

        //protected DropDownList ddlColors_2;

        //protected Label lblinkcovside2;

        //protected TextBox txtInkCoverageSide2;

        //protected TextBox txtWhiteInkCoverageSide2;

        //protected Label lblPrintQualityDPI;

        //protected DropDownList ddlPrintQualityDPI;

        //protected Label Label158;

        //protected DropDownList ddlQualitySector;

        //protected Label Label18;

        //protected TextBox txtNoOfPagesInSection;

        //protected Label Label22;

        //protected DropDownList ddlPrintSheetSize;

        //protected HiddenField hid_ddlPrintSheetSize;

        //protected TextBox txtsectionwidth;

        //protected TextBox txtsectionheight;

        //protected CheckBox chkPrintSheet;

        //protected Label Label23;

        //protected DropDownList ddlJobItemSize;

        //protected TextBox txtitemwidth;

        //protected TextBox txtitemheight;

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

        //protected HiddenField hdn_PortraitValue;

        //protected TextBox txtPortLength;

        //protected Label lblPortraitLength;

        //protected CheckBox chkLandscape;

        //protected TextBox txtlandscape;

        //protected HiddenField hdn_LandscapeValue;

        //protected HiddenField hdnProtrait;

        //protected HiddenField hdnLandscale;

        //protected TextBox txtLandLength;

        //protected Label lblLandscapeLength;

        //protected Label lblLengthRequired;

        //protected Label lblItemSize;

        //protected TextBox txt_ItemSize;

        //protected Label lblSqItemSIze;

        //protected Label Label26;

        //protected Label lblGuillotine;

        //protected CheckBox chkFirstTrim;

        //protected CheckBox chkSecondTrim;

        //protected HiddenField hid_GuillotineID;

        //protected Label Label2;

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

        //protected HiddenField hid_Row;

        //protected HiddenField hid_Col;

        //protected HiddenField hid_width;

        //protected HiddenField hid_height;

        //protected HiddenField hid_IsJobCustom;

        //protected HiddenField hid_IsSheetCustom;

        //protected HiddenField hdnedit_Default;

        //protected HiddenField hdnOldPressID;

        //protected HiddenField hdnOldPaperID;

        //protected HiddenField hdnOldPaperID2;

        //protected HiddenField hdnOldPaperID3;

        //protected HiddenField hdnOldPaperID4;

        //protected HiddenField hdnOldPaperID5;

        //protected HiddenField hdnOldGuillotineID;

        //protected HiddenField hdn_InvpaperID;

        //protected HiddenField hdn_InvpaperID2;

        //protected HiddenField hdn_InvpaperID3;

        //protected HiddenField hdn_InvpaperID4;

        //protected HiddenField hdn_InvpaperID5;

        //protected HiddenField hdn_invStockBack;

        //protected HiddenField hdn_invStockReduce;

        //protected Panel pnlPadEdit;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        public BasePage ObjPage = new BasePage();

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

        public long EstimateLargeItemID;

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

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        private commonClass objcomm = new commonClass();

        private commonClass objJava = new commonClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private SummaryClass summryCls = new SummaryClass();

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public string modulename = "estimates";

        public string submodulename = "estimate";

        public string PaperMeasure = string.Empty;

        public string Metre = string.Empty;

        private Global gloobj = new Global();

        public string EstTypeFromSP = string.Empty;

        public long ParentItemID;

        public string ParentItemType = string.Empty;

        public long EstimateBookletItemID;

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public string subedit = string.Empty;

        public string MainType = string.Empty;

        public int QtyNo;

        public string frmcopyitem = string.Empty;

        public int IsItemCompleted;

        public string ProfitTaxKey = string.Empty;

        public int IsProductCreated;

        public languageClass objLanguage = new languageClass();

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public bool IsPaperUnitPriceLocked;

        public string LargeFormatCalculation = string.Empty;

        public string PaperType = string.Empty;

        private decimal[] InvSheetsForMaterials = new decimal[4];

        private decimal[] PaperLengthForMaterials = new decimal[4];

        public string PrintLayout_MSG_Sheet = string.Empty;
        public string LargeItemPrintLayout = string.Empty;
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

        public large_item()
        {
        }

        protected void btnPrevious_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.modulename.ToLower() == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            if (this.QueryType == "add")
            {
                if (this.modulename != "orders")
                {
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (empty.ToLower() != "yes")
                        {
                            HttpResponse response = base.Response;
                            object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                            response.Redirect(string.Concat(estimateID));
                        }
                        else
                        {
                            HttpResponse httpResponse = base.Response;
                            object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
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
                        object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=L&From=F&maintype=", this.MainType, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID1));
                        return;
                    }
                    if (empty.ToLower() == "yes")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray1));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                    response2.Redirect(string.Concat(estimateID2));
                    return;
                }
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                    httpResponse2.Redirect(string.Concat(objArray2));
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse response3 = base.Response;
                    object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
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
                        if (empty.ToLower() == "yes")
                        {
                            HttpResponse httpResponse3 = base.Response;
                            object[] objArray3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                            httpResponse3.Redirect(string.Concat(objArray3));
                            return;
                        }
                        HttpResponse response4 = base.Response;
                        object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                        response4.Redirect(string.Concat(estimateID4));
                        return;
                    }
                    if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                    {
                        if (empty.ToLower() == "yes")
                        {
                            HttpResponse httpResponse4 = base.Response;
                            object[] objArray4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                            httpResponse4.Redirect(string.Concat(objArray4));
                            return;
                        }
                        HttpResponse response5 = base.Response;
                        object[] estimateID5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
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
                    object[] objArray5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=L&From=S&EstItemID=", this.EstimateItemID, "&maintype=", this.MainType, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                    httpResponse5.Redirect(string.Concat(objArray5));
                }
                else
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        HttpResponse response6 = base.Response;
                        object[] estimateID6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                        response6.Redirect(string.Concat(estimateID6));
                        return;
                    }
                    if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                    {
                        HttpResponse httpResponse6 = base.Response;
                        object[] objArray6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&calcType=", this.LargeFormatCalculation, this.jID, this.InvID };
                        httpResponse6.Redirect(string.Concat(objArray6));
                        return;
                    }
                }
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            this.EstType = "L";
            if (string.Compare(this.QueryType, "add", true) != 0 && this.frmcopyitem != "yes")
            {
                if (string.Compare(this.QueryType, "edit", true) == 0 && this.frmcopyitem != "yes")
                {
                    this.Update_Large_Item();
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
            if (this.modulename.ToLower() == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
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
                if (empty.ToLower() == "yes")
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
            if (empty.ToLower() == "yes")
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

        private void Click_Add(long ParentItemID, string ParentItemType)
        {
            long num = (long)0;
            long num1 = (long)0;
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            estimatesItem.EstimateItemID = (long)0;
            estimatesItem.EstQuantityID = (long)0;
            estimatesItem.IsAnyWarehouseItem = 'N';
            estimatesItem.IsAnyOutwork = 'N';
            estimatesItem.IsAnyOtherCost = 'N';
            string[] strArrays = this.hid_booklet_save.Value.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (!string.IsNullOrEmpty(strArrays[i]))
                {
                    stringBuilder.Append(" declare @EstBookletSectionID bigint; ");
                    stringBuilder.Append(" Insert into [TABLE_EstBookletSection] ");
                    stringBuilder.Append(" ( EstBookletItemID,SectionReference,PressID,");
                    stringBuilder.Append(" PressType,PaperID,IsPricePerPack,IsPaperSupplied,");
                    stringBuilder.Append(" SetUpSpoilage,RunningSpoilage,");
                    stringBuilder.Append(" NoOfPagesInSection,PagesPerSignature,NoOfSignatures,");
                    stringBuilder.Append(" Colour,IsDoubleSided,SideColor,");
                    stringBuilder.Append(" PrintSheetSizeID,IsSheetCustom,SheetHeight,SheetWidth,");
                    stringBuilder.Append(" JobFlatSizeID,IsJobCustom,JobHeight,JobWidth,");
                    stringBuilder.Append(" IsIncludeGutters,GutterHorizontal,GutterVertical,");
                    stringBuilder.Append(" IsPressRestrictions, GuillotineID,IsFirstTrim,IsSecondTrim,BookletFormat) ");
                    stringBuilder.Append(" Values");
                    stringBuilder.Append(string.Concat("(", num1, ","));
                }
                string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                    if (strArrays2[0].Trim() == "SectionRef")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                    }
                    else if (strArrays2[0].Trim() == "PressID")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.PressID = Convert.ToInt64(strArrays2[1].Trim());
                        this.PressID = Convert.ToInt64(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PressType")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.PressType = Convert.ToChar(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PaperID")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.PaperID = Convert.ToInt64(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PriceForWhaolePack")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.IsPricePerPack = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PaperSupplied")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.IsPaperSupplied = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "SetupSpoilage")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.SetupSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "RunningSpoilage")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.RunningSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "NoOfPagesInSection" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                    }
                    else if (strArrays2[0].Trim() == "PagesPerSignature" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                    }
                    else if (strArrays2[0].Trim() == "NoOfSignatures" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                    }
                    else if (strArrays2[0].Trim() == "Colour")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.Colour = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "IsDoubleSided")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.IsDoubleSided = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "SideColor")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.SideColor = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "PrintSheetSizeID")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.PrintSheetSizeID = Convert.ToInt32(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "IsPrintCustom")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.IsSheetCustom = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PrintSheetHeight")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.SheetHeight = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PrintSheetWidth")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.SheetWidth = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "JobFlatSizeID")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.JobFlatSizeID = Convert.ToInt32(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "IsJobCustom")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.IsJobCustom = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "JobFlatSizeHeight")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.JobHeight = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "JobFlatSizeWidth")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.JobWidth = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "IsIncludeGutters")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.IsIncludeGutters = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "GutterHorizontal")
                    {
                        string str = (strArrays2[1].Trim() == "" ? "0" : strArrays2[1]);
                        stringBuilder.Append(string.Concat(str, ","));
                        estimatesItem.GutterHorizontal = Convert.ToDecimal(str);
                    }
                    else if (strArrays2[0].Trim() == "GutterVertical")
                    {
                        string str1 = (strArrays2[1].Trim() == "" ? "0" : strArrays2[1]);
                        stringBuilder.Append(string.Concat(str1, ","));
                        estimatesItem.GutterVertical = Convert.ToDecimal(str1);
                    }
                    else if (strArrays2[0].Trim() == "IsPressRestrictions")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.IsPressRestrictions = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PrintLayout")
                    {
                        estimatesItem.PrintLayout = Convert.ToChar(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PortraitValue")
                    {
                        estimatesItem.PortraitValue = (string.IsNullOrEmpty(strArrays2[1].Trim()) ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                    }
                    else if (strArrays2[0].Trim() == "LandscapeValue")
                    {
                        estimatesItem.LandscapeValue = (string.IsNullOrEmpty(strArrays2[1].Trim()) ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                    }
                    else if (strArrays2[0].Trim() == "GuilotineID" && this.LargeFormatCalculation.ToString().ToLower() != "tilling")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1], ","));
                        estimatesItem.GuillotineID = Convert.ToInt64(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "IsFirstTrim")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.IsFirstTrim = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "IsSecondTrim")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.IsSecondTrim = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "BookletFormat")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1], "'); "));
                    }
                }
            }
            estimatesItem.CreatedBy = Convert.ToInt32(base.Session["UserID"]);
            estimatesItem.ModifiedBy = 0;
            estimatesItem.CreatedDate = DateTime.Now;
            estimatesItem.ModifiedDate = DateTime.Now;
            estimatesItem.PrintQuality = this.ddlQualitySector.SelectedValue;
            estimatesItem.InkCoverageSide1 = Convert.ToDecimal(this.txtInkCoverageSide1.Text);
            estimatesItem.InkCoverageSide2 = Convert.ToDecimal(this.txtInkCoverageSide2.Text);
            estimatesItem.MaterialID2 = Convert.ToInt64(this.hdnpaperID2.Value.ToString());
            estimatesItem.MaterialID3 = Convert.ToInt64(this.hdnpaperID3.Value.ToString());
            estimatesItem.MaterialID4 = Convert.ToInt64(this.hdnpaperID4.Value.ToString());
            estimatesItem.MaterialID5 = Convert.ToInt64(this.hdnpaperID5.Value.ToString());
            estimatesItem.IsPricePerPack2 = this.Chk_PriceForWholePack2.Checked;
            estimatesItem.IsPricePerPack3 = this.Chk_PriceForWholePack3.Checked;
            estimatesItem.IsPricePerPack4 = this.Chk_PriceForWholePack4.Checked;
            estimatesItem.IsPricePerPack5 = this.Chk_PriceForWholePack5.Checked;
            estimatesItem.IsPaperSupplied2 = this.Chk_PaperSupplied2.Checked;
            estimatesItem.IsPaperSupplied3 = this.Chk_PaperSupplied3.Checked;
            estimatesItem.IsPaperSupplied4 = this.Chk_PaperSupplied4.Checked;
            estimatesItem.IsPaperSupplied5 = this.Chk_PaperSupplied5.Checked;
            estimatesItem.WhiteInkCoverageSide1 = Convert.ToDecimal(this.txtWhiteInkCoverageSide1.Text);
            estimatesItem.WhiteInkCoverageSide2 = Convert.ToDecimal(this.txtWhiteInkCoverageSide2.Text);
            estimatesItem.DPI = Convert.ToInt32(this.ddlPrintQualityDPI.SelectedValue);
            object[] paperID = new object[] { estimatesItem.PaperID, ",", estimatesItem.MaterialID2, ",", estimatesItem.MaterialID3, ",", estimatesItem.MaterialID4, ",", estimatesItem.MaterialID5 };
            string str2 = string.Concat(paperID);
            if (this.EstType == "L")
            {
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
                if (this.InvoiceID <= (long)0)
                {
                    long num2 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, this.EstType, flag, parentEstimateItemID);
                    num = num2;
                    estimatesItem.EstimateItemID = num2;
                }
                else
                {
                    long num3 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, this.EstType, flag, parentEstimateItemID);
                    num = num3;
                    estimatesItem.EstimateItemID = num3;
                }
                EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, num, ConnectionClass.IsHandy);
                if (this.jobID > (long)0)
                {
                    long num4 = this.jobID;
                    commonClass _commonClass = this.objJava;
                    DateTime now = DateTime.Now;
                    JobBasePage.EstimateItems_ProgressToJob(num, num4, false, Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
                }
                if (this.InvoiceID > (long)0)
                {
                    InvoiceBasePage.EstimateItems_ProgressToInvoice(num, this.InvoiceID);
                }
                estimatesItem.ItemTitle = this.Objclss.SpecialEncode(this.txtItemTitle.Text);
                estimatesItem.ItemDescription = string.Empty;
                if (string.Compare(ParentItemType, "B", true) == 0 || string.Compare(ParentItemType, "N", true) == 0 || string.Compare(ParentItemType, "R", true) == 0 || string.Compare(ParentItemType, "K", true) == 0)
                {
                    estimatesItem.ParentItemID = this.EstimateBookletItemID;
                    estimatesItem.ParentItemType = ParentItemType;
                }
                else
                {
                    estimatesItem.ParentItemID = ParentItemID;
                    estimatesItem.ParentItemType = ParentItemType;
                }
                estimatesItem.Row = Convert.ToInt32((this.hid_Row.Value == "" ? "0" : this.hid_Row.Value));
                estimatesItem.Col = Convert.ToInt32((this.hid_Col.Value == "" ? "0" : this.hid_Col.Value));
                estimatesItem.CalculationType = this.LargeFormatCalculation.ToString().ToLower();
                estimatesItem.isFullSheet = this.chkUSeFullSheets.Checked;

                EstimatesBasePage.large_item_insert(estimatesItem);
                this.PressID = Convert.ToInt64(estimatesItem.PressID);
                this.Estimate_Calcukation(num, (long)0, str2, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, this.EstType);
                this.Main_Quantity_Insert(num, "qty", estimatesItem);
                this.Main_Quantity_Insert_forMaterials(num, "save", str2);
                if (base.Request.Params["parentestitemid"] == null)
                {
                    EstimatesBasePage.estimate_EstTotalPriceDetails_Update(num);
                }
                else
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                    EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
                }
                EstimateCommonMethods.UpdateDescription(num, this.EstimateID, "L", false);
            }
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, num, 1, this.EstimateID);
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, num, "L");
                string empty = string.Empty;
                long parentItemID = num;
                if (ParentItemID != (long)0)
                {
                    parentItemID = ParentItemID;
                }
                foreach (DataRow row in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty = row["StatusID"].ToString();
                }
                if (string.Compare(this.modulename, "jobs", true) == 0)
                {
                    commonClass _commonClass1 = new commonClass();
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        _commonClass1.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty), "job", num, (long)0);
                    }
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
                else if (string.Compare(this.modulename, "jobs", true) == 0 && this.ReduceStockType.ToString() == empty.ToString())
                {
                    this.summryCls.Call_Inventory_Adjustment("completed-status", this.EstimateID, this.CompanyID, parentItemID, this.UserID);
                }
            }
            if (this.modulename == "jobs")
            {
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                {
                    empty1 = dataRow["PhraseText"].ToString();
                }
                foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                {
                    empty2 = row1["PhraseText"].ToString();
                }
                EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty1, empty2);
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, num);
            string empty3 = string.Empty;
            if (this.jobID != (long)0)
            {
                empty3 = string.Concat("&jID=", this.jobID);
            }
            string str3 = string.Empty;
            if (this.InvoiceID != (long)0)
            {
                str3 = string.Concat("&InvID=", this.InvoiceID);
            }
            string empty4 = string.Empty;
            if (this.modulename.ToLower() == "jobs")
            {
                empty4 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                empty4 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            if (this.ParentEstimateItemID == (long)0 && this.QueryType == "add" && EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "L") > (long)0)
            {
                foreach (DataRow dataRow1 in EstimatesBasePage.lithobooklet_item_select(this.CompanyID, num).Rows)
                {
                    num1 = Convert.ToInt64(dataRow1["EstimateLithoBookletItemID"]);
                }
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", num, "&parentesttype=L&maintype=edit&subitem=s", empty3, str3 };
                response.Redirect(string.Concat(estimateID));
            }
            if (this.modulename == "orders")
            {
                if (this.ParentEstimateItemID == (long)0)
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", num, empty3, str3 };
                    httpResponse.Redirect(string.Concat(objArray));
                    return;
                }
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, empty3, str3 };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            if (this.ParentEstimateItemID == (long)0)
            {
                if (empty4.ToLower() == "yes")
                {
                    HttpResponse httpResponse1 = base.Response;
                    object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", num, empty3, str3 };
                    httpResponse1.Redirect(string.Concat(objArray1));
                    return;
                }
                HttpResponse response2 = base.Response;
                object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", num, empty3, str3 };
                response2.Redirect(string.Concat(estimateID2));
                return;
            }
            if (empty4.ToLower() == "yes")
            {
                HttpResponse httpResponse2 = base.Response;
                object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, empty3, str3 };
                httpResponse2.Redirect(string.Concat(objArray2));
                return;
            }
            HttpResponse response3 = base.Response;
            object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, empty3, str3 };
            response3.Redirect(string.Concat(estimateID3));
        }

        private string Estimate_Calcukation(long EstimateItemID, long EstimateBookletItemID, string StrMaterialIDs, long PressID, char PressType, long GuillotineID, string EstimateType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = StrMaterialIDs.Split(new char[] { ',' });
            long num = Convert.ToInt64(strArrays[0].ToString());
            string[] strArrays1 = EstimateBasePage.Material_Calculation((long)this.CompanyID, Convert.ToInt64(num)).Split(new char[] { '±' });
            decimal num1 = new decimal(0);
            //num1 = (this.LargeFormatCalculation.ToString().ToLower() != "square" ? Convert.ToDecimal(strArrays1[4]) : Convert.ToDecimal(strArrays1[0]));
            num1 = (this.LargeFormatCalculation.ToString().ToLower() != "linear" ? Convert.ToDecimal(strArrays1[0]) : Convert.ToDecimal(strArrays1[4]));
            string empty = string.Empty;
            decimal num2 = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "I", num));
            stringBuilder.Append(" Insert into tb_EstimateCalculation ");
            stringBuilder.Append(" ( EstimateItemID, ");
            stringBuilder.Append(" PaperUnitPrice, PaperWeight, PaperMarkup, ");
            stringBuilder.Append(" PressMarkUp, PressSetupCharge, PressMinimumRunningCharge, PressType, ");
            stringBuilder.Append(" HourlyCharge, ");
            stringBuilder.Append(" PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, ");
            stringBuilder.Append(" GuillotineSetupCharge, GuillotineMinimumRunningCharge, GuillotineMarkUp, ");
            stringBuilder.Append(" GuillotineCostPerCut, GuillotinePaperWeight1, GuillotineMaximumThroat1, ");
            stringBuilder.Append(" GuillotinePaperWeight2, GuillotineMaximumThroat2, GuillotinePaperWeight3, ");
            stringBuilder.Append(" GuillotineMaximumThroat3,  ");
            //stringBuilder.Append(" OneSqCmInkCost, InkMarkup, PaperPackedInQty )");
            stringBuilder.Append(" OneSqCmInkCost, OneSqCmInkMarkup, PaperPackedInQty )");
            stringBuilder.Append(" Values ");
            stringBuilder.Append(string.Concat(" ( ", EstimateItemID, ","));
            object[] objArray = new object[] { " ", num1, ",", strArrays1[1], ",", strArrays1[2], "," };
            stringBuilder.Append(string.Concat(objArray));
            DataTable dataTable = EstimateBasePage.Estimate_Large_Format_Press_Charge_Select(this.CompanyID, PressID);




            // Start 22969
            string isCostingMatrix = "no";
            DataTable dataTable_zone = new DataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["CalculationType"].ToString() == "timecosting")
                {
                    isCostingMatrix = "yes";
                    dataTable_zone = SettingsBasePage.Settings_LargeFormatChargeZone_Select_By_IDlong(PressID);
                }
                else
                {
                    isCostingMatrix = "no";
                    dataTable_zone = SettingsBasePage.Settings_LargeFormatChargeZone_Select_By_IDlong(PressID);
                }
            }


            //decimal time1 = 0;
            //decimal time2 = 0;
            //decimal time3 = 0;
            //decimal time4 = 0;

            //if (dataTable_zone.Rows.Count > 0)
            //{

            //    //string empty123 = string.Empty;
            //    //DataSet dataSet = EstimatesBasePage.PC_EstimateLargeItem_InkCalID_Select(EstimateItemID);
            //    //if (dataSet.Tables[0].Rows.Count > 0)
            //    //{
            //    //    foreach (DataRow row in dataSet.Tables[0].Rows)
            //    //    {
            //    //        empty123 = string.Concat(empty123, row["EstimateInkCalID"].ToString(), ",");
            //    //    }
            //    //    if (empty123.Length > 0)
            //    //    {
            //    //        empty123 = empty123.Substring(0, empty123.Length - 1);
            //    //    }
            //    //}
            //    Calculations calculation = new Calculations();
            //    string str123 = "L";
            //    int[] numArray = new int[4];
            //    decimal[] num0 = new decimal[4];
            //    decimal[] num01 = new decimal[4];
            //    decimal[] numArray1 = new decimal[4];
            //    decimal[] num02 = new decimal[4];
            //    decimal[] numArray2 = new decimal[4];
            //    decimal[] num03 = new decimal[4];
            //    decimal[] numArray3 = new decimal[4];
            //    decimal[] num04 = new decimal[4];
            //    decimal[] numArray4 = new decimal[4];
            //    decimal[] num05 = new decimal[4];
            //    decimal[] numArray5 = new decimal[4];
            //    decimal[] num6 = new decimal[4];
            //    decimal[] numArray6 = new decimal[4];
            //    decimal[] num7 = new decimal[4];
            //    decimal[] numArray7 = new decimal[4];
            //    decimal[] num8 = new decimal[4];
            //    decimal[] numArray8 = new decimal[4];
            //    decimal[] num9 = new decimal[4];
            //    decimal[] numArray9 = new decimal[4];
            //    decimal[] num10 = new decimal[4];
            //    decimal[] numArray10 = new decimal[4];
            //    decimal[] num11 = new decimal[4];
            //    decimal[] numArray11 = new decimal[4];
            //    decimal[] num12 = new decimal[4];
            //    decimal[] numArray12 = new decimal[4];
            //    decimal[] num13 = new decimal[4];
            //    decimal[] numArray13 = new decimal[4];
            //    decimal[] num14 = new decimal[4];
            //    decimal[] numArray14 = new decimal[4];
            //    decimal[] num15 = new decimal[4];
            //    decimal[] numArray15 = new decimal[4];
            //    decimal[] num16 = new decimal[4];
            //    decimal[] numArray16 = new decimal[4];
            //    decimal[] num17 = new decimal[4];
            //    decimal[] numArray17 = new decimal[4];
            //    decimal[] numArray18 = new decimal[4];
            //    decimal[] numArray19 = new decimal[4];



            //    for (int i = 1; i <= 4; i++)
            //    {
            //        int num18 = 0;
            //        if (i != 1)
            //        {
            //            TextBox textBox = (TextBox)this.FindControl(string.Concat("txtQuantity_", i));
            //            num18 = (textBox.Text != "" ? Convert.ToInt32(textBox.Text) : 0);
            //        }
            //        else if (this.txtQuantity.Text != "")
            //        {
            //            num18 = Convert.ToInt32(this.txtQuantity.Text);
            //        }
            //        if (num18 <= 0)
            //        {
            //            numArray[i - 1] = 0;
            //            num0[i - 1] = new decimal(0);
            //            num01[i - 1] = new decimal(0);
            //            numArray1[i - 1] = new decimal(0);
            //            num02[i - 1] = new decimal(0);
            //            numArray2[i - 1] = new decimal(0);
            //            num03[i - 1] = new decimal(0);
            //            numArray3[i - 1] = new decimal(0);
            //            num04[i - 1] = new decimal(0);
            //            numArray4[i - 1] = new decimal(0);
            //            num05[i - 1] = new decimal(0);
            //            numArray5[i - 1] = new decimal(0);
            //            num6[i - 1] = new decimal(0);
            //            numArray6[i - 1] = new decimal(0);
            //            num7[i - 1] = new decimal(0);
            //            numArray7[i - 1] = new decimal(0);
            //            num10[i - 1] = new decimal(0);
            //            numArray10[i - 1] = new decimal(0);
            //            num11[i - 1] = new decimal(0);
            //            num8[i - 1] = new decimal(0);
            //            numArray8[i - 1] = new decimal(0);
            //            num9[i - 1] = new decimal(0);
            //            numArray9[i - 1] = new decimal(0);
            //            numArray11[i - 1] = new decimal(0);
            //            num12[i - 1] = new decimal(0);
            //            numArray12[i - 1] = new decimal(0);
            //            num13[i - 1] = new decimal(0);
            //            numArray13[i - 1] = new decimal(0);
            //            num14[i - 1] = new decimal(0);
            //            numArray14[i - 1] = new decimal(0);
            //            num15[i - 1] = new decimal(0);
            //            numArray15[i - 1] = new decimal(0);
            //            num16[i - 1] = new decimal(0);
            //            numArray16[i - 1] = new decimal(0);
            //            num17[i - 1] = new decimal(0);
            //            numArray17[i - 1] = new decimal(0);
            //            this.InvSheetsForMaterials[i - 1] = new decimal(0);
            //            this.PaperLengthForMaterials[i - 1] = new decimal(0);
            //        }
            //        else
            //        {
            //            numArray[i - 1] = num18;
            //            DataTable dataTable123 = new DataTable();
            //            dataTable123 = EstimatesBasePage.estimate_large_item_select(this.CompanyID, EstimateItemID);
            //            DataRow item = dataTable123.Rows[0];
            //            if (this.ProfitTaxKey.ToLower() != "database")
            //            {
            //                num0[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
            //                num01[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "press", Convert.ToInt64(item["PressID"]));
            //                if (Convert.ToInt64(item["GuillotineID"]) > (long)0)
            //                {
            //                    numArray1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "guillotine", Convert.ToInt64(item["GuillotineID"]));
            //                }
            //                num02[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inks", (long)0);
            //            }
            //            else
            //            {
            //                if (item["PaperMarkup"].ToString() == "")
            //                {
            //                    num0[i - 1] = Convert.ToDecimal(0);
            //                }
            //                else
            //                {
            //                    num0[i - 1] = Convert.ToDecimal(item["PaperMarkup"]);
            //                }

            //                if (item["PressMarkUp"].ToString() == "")
            //                {
            //                    num01[i - 1] = Convert.ToDecimal(0);
            //                }
            //                else
            //                {
            //                    num01[i - 1] = Convert.ToDecimal(item["PressMarkUp"]);
            //                }

            //                if (item["GuillotineMarkUp"].ToString() == "")
            //                {
            //                    numArray1[i - 1] = Convert.ToDecimal(0);
            //                }
            //                else
            //                {
            //                    numArray1[i - 1] = Convert.ToDecimal(item["GuillotineMarkUp"]);
            //                }

            //                if (item["InkMarkup"].ToString() == "")
            //                {
            //                    num02[i - 1] = Convert.ToDecimal(0);
            //                }
            //                else
            //                {
            //                    num02[i - 1] = Convert.ToDecimal(item["InkMarkup"]);
            //                }
            //                //num0[i - 1] = Convert.ToDecimal(item["PaperMarkup"]);
            //                //num01[i - 1] = Convert.ToDecimal(item["PressMarkUp"]);
            //                //numArray1[i - 1] = Convert.ToDecimal(item["GuillotineMarkUp"]);
            //                //num02[i - 1] = Convert.ToDecimal(item["InkMarkup"]);
            //            }

            //            decimal valToDivide = new decimal(0);
            //            if (this.chkPortrait.Checked)
            //            {
            //                valToDivide = Convert.ToDecimal(item["PortraitValue"]);
            //            }
            //            else
            //            {
            //                valToDivide = Convert.ToDecimal(item["LandscapeValue"]);
            //            }

            //            decimal num19 = new decimal(0);
            //            numArray3[i - 1] = calculation.PaperCalculation(this.CompanyID, str123, num18, num0[i - 1], item, ref numArray2[i - 1], ref num03[i - 1], ref num04[i - 1], ref numArray4[i - 1], ref num19, this.chkUSeFullSheets.Checked, valToDivide);
            //            numArray15[i - 1] = num19;
            //            this.InvSheetsForMaterials[i - 1] = num04[i - 1];
            //            this.PaperLengthForMaterials[i - 1] = numArray15[i - 1];
            //            num6[i - 1] = calculation.PressCalculation(this.CompanyID, str123, num18, num01[i - 1], item, numArray4[i - 1], ref num05[i - 1], ref numArray5[i - 1], num19, ref numArray11[i - 1], ref num12[i - 1], ref numArray12[i - 1], ref num13[i - 1], ref numArray13[i - 1], ref num14[i - 1], ref numArray14[i - 1], ref num15[i - 1], ref num16[i - 1], ref numArray16[i - 1], ref num17[i - 1], i, ref numArray18[i - 1], ref numArray19[i - 1]);
            //        }
            //    }



            //    foreach (var item in dataTable_zone.Rows)
            //    {
            //        if (true)
            //        {
            //            int a = 0;
            //        }
            //    }
            //}

            // End 22969   

            string str = string.Empty;
            //double num3 = 0;
            string num3 = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                string[] str1 = new string[] { " ", row["MarkUp"].ToString(), ",", row["SetupCharge"].ToString(), ",", row["MinimumCharge"].ToString(), "," };
                stringBuilder.Append(string.Concat(str1));
                stringBuilder.Append("'L',");
                stringBuilder.Append(string.Concat(row["PerHourCharge"].ToString(), ","));
                string[] str2 = new string[] { " ", row["PrintPerHourLow"].ToString(), ",", row["PrintPerHourMedium"].ToString(), ",", row["PrintPerHourHigh"].ToString(), "," };
                stringBuilder.Append(string.Concat(str2));
                str = row["InkValues"].ToString();
                //num3 = Convert.ToDouble(row["InkMarkup"]);
                num3 = row["InkMarkup"].ToString();

            }
            DataTable dataTable1 = EstimateBasePage.Estimate_Guillotine_Select_By_ID(this.CompanyID, GuillotineID);
            if (dataTable1.Rows.Count == 0)
            {
                stringBuilder.Append(" 0,0,0,");
                stringBuilder.Append(" 0,0,0,");
                stringBuilder.Append(" 0,0,0,");
                stringBuilder.Append(" 0,");
            }
            else
            {
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    string[] strArrays2 = new string[] { " ", dataRow["SetUpCharge"].ToString(), ",", dataRow["MinCharge"].ToString(), ",", dataRow["MarkUp"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays2));
                    string[] str3 = new string[] { " ", dataRow["CostPerCut"].ToString(), ",", dataRow["PaperWeight1"].ToString(), ",", dataRow["MaxSheets1"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str3));
                    string[] strArrays3 = new string[] { " ", dataRow["PaperWeight2"].ToString(), ",", dataRow["MaxSheets2"].ToString(), ",", dataRow["PaperWeight3"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays3));
                    stringBuilder.Append(string.Concat(" ", dataRow["MaxSheets3"].ToString(), ","));
                }
            }
            object[] objArray1 = new object[] { " '", str, "', '", num3, "',", num2, " )" };
            stringBuilder.Append(string.Concat(objArray1));
            stringBuilder.Append(" declare @EstimateCalculationID bigint; ");
            stringBuilder.Append(" set @EstimateCalculationID = Ident_Current('[tb_EstimateCalculation]')");
            stringBuilder.Append(" select @EstimateCalculationID ");
            long num4 = EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            //EstimatesBasePage.estimates_litho_markup_calculation_insert(this.CompanyID, num4);
            EstimatesBasePage.estimates_litho_markup_calculation_insertnew(this.CompanyID, num4,PressID);
            decimal num5 = new decimal(0);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (Convert.ToInt64(strArrays[i]) != (long)0)
                {
                    string[] strArrays4 = EstimateBasePage.Material_Calculation((long)this.CompanyID, Convert.ToInt64(strArrays[i])).Split(new char[] { '±' });
                    num5 = (this.LargeFormatCalculation.ToString().ToLower() == "linear" ? Convert.ToDecimal(strArrays4[4]) : Convert.ToDecimal(strArrays4[0]));
                    decimal num6 = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "I", (long)Convert.ToInt32(strArrays[i])));
                    EstimatesBasePage.LargeItemCalculation_insert(num4, EstimateItemID, Convert.ToInt64(strArrays[i]), num5, Convert.ToDecimal(strArrays4[1]), num6, Convert.ToDecimal(strArrays4[2]), Convert.ToDecimal(strArrays4[2]), Convert.ToDecimal(strArrays4[2]), Convert.ToDecimal(strArrays4[2]), i + 1, "save");
                }
            }
            return stringBuilder.ToString();
        }

        private void Estimate_Calcukation_Update(long EstimateItemID, long EstBookletSectionID, string StrrMaterialIDs, long PressID, char PressType, long GuillotineID, string EstimateType)
        {
            string str = "0";
            string str1 = "0";
            string str2 = "0";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" Update [tb_EstimateCalculation] ");
            stringBuilder.Append(string.Concat(" Set EstimateItemID=", EstimateItemID, ","));
            string[] strArrays = StrrMaterialIDs.Split(new char[] { ',' });
            long num = Convert.ToInt64(strArrays[0].ToString());
            string[] strArrays1 = EstimateBasePage.Material_Calculation((long)this.CompanyID, (long)Convert.ToInt32(num)).Split(new char[] { '±' });
            decimal num1 = new decimal(0);
            num1 = (this.LargeFormatCalculation.ToString().ToLower() != "square" ? Convert.ToDecimal(strArrays1[4]) : Convert.ToDecimal(strArrays1[0]));
            string empty = string.Empty;
            str = strArrays1[2].ToString();
            DataTable dataTable = EstimateBasePage.Estimate_Large_Format_Press_Charge_Select(this.CompanyID, PressID);
            string empty1 = string.Empty;
            string MarkupValues = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                str1 = row["MarkUp"].ToString();
                string[] strArrays2 = new string[] { " PressSetupCharge=", row["SetupCharge"].ToString(), ",PressMinimumRunningCharge=", row["MinimumCharge"].ToString(), "," };
                stringBuilder.Append(string.Concat(strArrays2));
                stringBuilder.Append(" PressType='L',");
                stringBuilder.Append(string.Concat(" HourlyCharge=", row["PerHourCharge"].ToString(), ","));
                string[] str3 = new string[] { " PrintPerHourLow=", row["PrintPerHourLow"].ToString(), ",PrintPerHourMedium=", row["PrintPerHourMedium"].ToString(), ",PrintPerHourHigh=", row["PrintPerHourHigh"].ToString(), "," };
                stringBuilder.Append(string.Concat(str3));
                empty1 = row["InkValues"].ToString();
                MarkupValues = row["InkMarkup"].ToString();
            }
            DataTable dataTable1 = EstimateBasePage.Estimate_Guillotine_Select_By_ID(this.CompanyID, GuillotineID);
            if (dataTable1.Rows.Count == 0)
            {
                stringBuilder.Append(" GuillotineSetupCharge=0,GuillotineMinimumRunningCharge=0,");
                stringBuilder.Append(" GuillotineCostPerCut=0,GuillotinePaperWeight1=0,GuillotineMaximumThroat1=0,");
                stringBuilder.Append(" GuillotinePaperWeight2=0,GuillotineMaximumThroat2=0,GuillotinePaperWeight3=0,");
                stringBuilder.Append(" GuillotineMaximumThroat3=0,");
            }
            else
            {
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    str2 = dataRow["MarkUp"].ToString();
                    string[] strArrays3 = new string[] { " GuillotineSetupCharge=", dataRow["SetUpCharge"].ToString(), ",GuillotineMinimumRunningCharge=", dataRow["MinCharge"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays3));
                    string[] str4 = new string[] { " GuillotineCostPerCut=", dataRow["CostPerCut"].ToString(), ",GuillotinePaperWeight1=", dataRow["PaperWeight1"].ToString(), ",GuillotineMaximumThroat1=", dataRow["MaxSheets1"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str4));
                    string[] strArrays4 = new string[] { " GuillotinePaperWeight2=", dataRow["PaperWeight2"].ToString(), ",GuillotineMaximumThroat2=", dataRow["MaxSheets2"].ToString(), ",GuillotinePaperWeight3=", dataRow["PaperWeight3"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays4));
                    stringBuilder.Append(string.Concat(" GuillotineMaximumThroat3=", dataRow["MaxSheets3"].ToString(), ","));
                }
            }
            stringBuilder.Append(string.Concat(" OneSqCmInkCost='", empty1, "' "));
            stringBuilder.Append(string.Concat(", OneSqCmInkMarkup='", MarkupValues, "' "));

            if (Convert.ToInt64(num) != Convert.ToInt64(this.hdnOldPaperID.Value))
            {
                object[] objArray = new object[] { ",PaperUnitPrice=", num1, " ,PaperWeight=", strArrays1[1], ",PaperPackedInQty=", strArrays1[3], " " };
                stringBuilder.Append(string.Concat(objArray));
                string[] strArrays5 = new string[] { ", PaperMarkup=", str, ", PaperMarkup2=", str, ", PaperMarkup3=", str, ", PaperMarkup4=", str, " " };
                stringBuilder.Append(string.Concat(strArrays5));
            }
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
            stringBuilder.Append(string.Concat(" Where EstimateCalculationID=", this.EstimateCalculationID));
            stringBuilder.Append(string.Concat(" select ", this.EstimateCalculationID));
            EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            string[] value = new string[] { this.hdnOldPaperID.Value, ",", this.hdnOldPaperID2.Value, ",", this.hdnOldPaperID3.Value, ",", this.hdnOldPaperID4.Value, ",", this.hdnOldPaperID5.Value };
            string str5 = string.Concat(value);
            string[] strArrays8 = str5.Split(new char[] { ',' });
            decimal num2 = new decimal(0);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                // Ticket #9819 paper unit price updated
                if ((Convert.ToInt64(strArrays[i]) != Convert.ToInt64(strArrays8[i])) || (Convert.ToInt64(strArrays[i]) == Convert.ToInt64(strArrays8[i])))
                {
                    string[] strArrays9 = new string[] { "0", "0", "0", "0" };
                    if (Convert.ToInt64(strArrays[i]) != (long)0)
                    {
                        strArrays9 = EstimateBasePage.Material_Calculation((long)this.CompanyID, Convert.ToInt64(strArrays[i])).Split(new char[] { '±' });
                        num2 = (this.LargeFormatCalculation.ToString().ToLower() == "linear" ? Convert.ToDecimal(strArrays9[4]) : Convert.ToDecimal(strArrays9[0]));
                    }
                    EstimatesBasePage.LargeItemCalculation_insert(this.EstimateCalculationID, EstimateItemID, Convert.ToInt64(strArrays[i]), num2, Convert.ToDecimal(strArrays9[1]), Convert.ToDecimal(strArrays9[3]), Convert.ToDecimal(strArrays9[2]), Convert.ToDecimal(strArrays9[2]), Convert.ToDecimal(strArrays9[2]), Convert.ToDecimal(strArrays9[2]), i + 1, "update");
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
                string str = "L";
                string str1 = "Large Format Item";
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
                string str2 = "L";
                string str3 = "Large Format Item";
                string empty3 = string.Empty;
                if (this.modulename == "estimates")
                {
                    if (str2.ToLower() != "l")
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
                        if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit")
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
                    this.objnotes.Estimate_type = str3;
                    this.objnotes.Item_number = empty3;
                    if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit")
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
                    if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit")
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
                    if (str2.ToLower() != "l")
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
                        this.objnotes.Estimate_type = str3;
                        this.objnotes.Item_number = empty3;
                        this.objnotes.ModuleName = "webstoreorder";
                        if (base.Request.Params["maintype"].ToString() != null && base.Request.Params["maintype"].ToString() == "edit" && base.Request.Params["type"].ToLower() == "edit")
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

        public void Main_Quantity_Insert(long EstimateItemID_TempID, string para, EstimatesItem Estitem)
        {
            string empty = string.Empty;
            DataSet dataSet = EstimatesBasePage.PC_EstimateLargeItem_InkCalID_Select(EstimateItemID_TempID);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    empty = string.Concat(empty, row["EstimateInkCalID"].ToString(), ",");
                }
                if (empty.Length > 0)
                {
                    empty = empty.Substring(0, empty.Length - 1);
                }
            }
            EstimatesBasePage.PCR_Estimate_Large_Ink_Insert(EstimateItemID_TempID, para, this.CompanyID, this.ddlColors.SelectedValue, this.ddlColors_2.SelectedValue, this.chkDoubleSided.Checked, Estitem.PressID);
            Calculations calculation = new Calculations();
            string str = "L";
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
            decimal[] num13 = new decimal[4];
            decimal[] numArray13 = new decimal[4];
            decimal[] num14 = new decimal[4];
            decimal[] numArray14 = new decimal[4];
            decimal[] num15 = new decimal[4];
            decimal[] numArray15 = new decimal[4];
            decimal[] num16 = new decimal[4];
            decimal[] numArray16 = new decimal[4];
            decimal[] num17 = new decimal[4];
            decimal[] numArray17 = new decimal[4];
            decimal[] numArray18 = new decimal[4];
            decimal[] numArray19 = new decimal[4];

            decimal time1 = 0;
            decimal time2 = 0;
            decimal time3 = 0;
            decimal time4 = 0;

            for (int i = 1; i <= 4; i++)
            {
                int num18 = 0;
                if (i != 1)
                {
                    TextBox textBox = (TextBox)this.FindControl(string.Concat("txtQuantity_", i));
                    num18 = (textBox.Text != "" ? Convert.ToInt32(textBox.Text) : 0);
                }
                else if (this.txtQuantity.Text != "")
                {
                    num18 = Convert.ToInt32(this.txtQuantity.Text);
                }
                if (num18 <= 0)
                {
                    numArray[i - 1] = 0;
                    num[i - 1] = new decimal(0);
                    num1[i - 1] = new decimal(0);
                    numArray1[i - 1] = new decimal(0);
                    num2[i - 1] = new decimal(0);
                    numArray2[i - 1] = new decimal(0);
                    num3[i - 1] = new decimal(0);
                    numArray3[i - 1] = new decimal(0);
                    num4[i - 1] = new decimal(0);
                    numArray4[i - 1] = new decimal(0);
                    num5[i - 1] = new decimal(0);
                    numArray5[i - 1] = new decimal(0);
                    num6[i - 1] = new decimal(0);
                    numArray6[i - 1] = new decimal(0);
                    num7[i - 1] = new decimal(0);
                    numArray7[i - 1] = new decimal(0);
                    num10[i - 1] = new decimal(0);
                    numArray10[i - 1] = new decimal(0);
                    num11[i - 1] = new decimal(0);
                    num8[i - 1] = new decimal(0);
                    numArray8[i - 1] = new decimal(0);
                    num9[i - 1] = new decimal(0);
                    numArray9[i - 1] = new decimal(0);
                    numArray11[i - 1] = new decimal(0);
                    num12[i - 1] = new decimal(0);
                    numArray12[i - 1] = new decimal(0);
                    num13[i - 1] = new decimal(0);
                    numArray13[i - 1] = new decimal(0);
                    num14[i - 1] = new decimal(0);
                    numArray14[i - 1] = new decimal(0);
                    num15[i - 1] = new decimal(0);
                    numArray15[i - 1] = new decimal(0);
                    num16[i - 1] = new decimal(0);
                    numArray16[i - 1] = new decimal(0);
                    num17[i - 1] = new decimal(0);
                    numArray17[i - 1] = new decimal(0);
                    this.InvSheetsForMaterials[i - 1] = new decimal(0);
                    this.PaperLengthForMaterials[i - 1] = new decimal(0);
                }
                else
                {
                    numArray[i - 1] = num18;
                    DataTable dataTable = new DataTable();
                    dataTable = EstimatesBasePage.estimate_large_item_select(this.CompanyID, EstimateItemID_TempID);
                    DataRow item = dataTable.Rows[0];

                    //start


                    DataTable dataTable_press1 = EstimateBasePage.Estimate_Large_Format_Press_Charge_Select(this.CompanyID, PressID);

                    decimal l_hourlyCharge1 = 0;
                    decimal l_hourlyCharge2 = 0;
                    decimal l_hourlyCharge3 = 0;
                    decimal l_hourlyCharge4 = 0;

                    decimal l_markup_1 = 0;
                    decimal l_markup_2 = 0;
                    decimal l_markup_3 = 0;
                    decimal l_markup_4 = 0;

                    DataTable dataTable_zone_1 = new DataTable();
                    foreach (DataRow row132 in dataTable_press1.Rows)
                    {
                        if (row132["CalculationType"].ToString() == "timecosting")
                        {
                            if (this.ProfitTaxKey.ToLower() != "database")
                            {
                                num[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
                                num1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "press", Convert.ToInt64(item["PressID"]));
                                if (Convert.ToInt64(item["GuillotineID"]) > (long)0)
                                {
                                    numArray1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "guillotine", Convert.ToInt64(item["GuillotineID"]));
                                }
                                num2[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inks", (long)0);
                            }
                            else
                            {
                                num[i - 1] = Convert.ToDecimal(item["PaperMarkup"]);
                                num1[i - 1] = Convert.ToDecimal(item["PressMarkUp"]);
                                numArray1[i - 1] = Convert.ToDecimal(item["GuillotineMarkUp"]);
                                num2[i - 1] = Convert.ToDecimal(item["InkMarkup"]);
                            }

                            decimal valToDivide1 = new decimal(0);
                            if (this.chkPortrait.Checked)
                            {
                                valToDivide1 = Convert.ToDecimal(item["PortraitValue"]);
                            }
                            else
                            {
                                valToDivide1 = Convert.ToDecimal(item["LandscapeValue"]);
                            }

                            decimal num191 = new decimal(0);
                            decimal UseFullSheetArea = new decimal(0);
                            numArray3[i - 1] = calculation.PaperCalculation(this.CompanyID, str, num18, num[i - 1], item, ref numArray2[i - 1], ref num3[i - 1], ref num4[i - 1], ref numArray4[i - 1], ref num191, ref UseFullSheetArea, this.chkUSeFullSheets.Checked, valToDivide1);
                            numArray15[i - 1] = num191;
                            if (this.chkUSeFullSheets.Checked == true && UseFullSheetArea > 0)
                                num191 = UseFullSheetArea;
                            this.InvSheetsForMaterials[i - 1] = num4[i - 1];
                            this.PaperLengthForMaterials[i - 1] = numArray15[i - 1];
                            num6[i - 1] = calculation.PressCalculation(this.CompanyID, str, num18, num1[i - 1], item, numArray4[i - 1], ref num5[i - 1], ref numArray5[i - 1], num191, ref numArray11[i - 1], ref num12[i - 1], ref numArray12[i - 1], ref num13[i - 1], ref numArray13[i - 1], ref num14[i - 1], ref numArray14[i - 1], ref num15[i - 1], ref num16[i - 1], ref numArray16[i - 1], ref num17[i - 1], i, ref numArray18[i - 1], ref numArray19[i - 1]);

                            if (i == 1)
                            {
                                time1 = Math.Round(numArray11[0]);
                            }
                            if (i == 2)
                            {
                                time2 = Math.Round(numArray11[1]);
                            }
                            if (i == 3)
                            {
                                time3 = Math.Round(numArray11[2]);
                            }
                            if (i == 4)
                            {
                                time4 = Math.Round(numArray11[3]);
                            }

                            dataTable_zone_1 = SettingsBasePage.Settings_LargeFormatChargeZone_Select_By_IDlong(PressID);
                            for (int i1l = 0; i1l < dataTable_zone_1.Rows.Count; i1l++)
                            {

                                DataRow dr1 = dataTable_zone_1.Rows[i1l];
                                decimal fromZone = Convert.ToDecimal(dr1["ZoneFrom"].ToString());
                                decimal toZone = Convert.ToDecimal(dr1["ZoneTo"].ToString());
                                decimal hourlyCost = Convert.ToDecimal(dr1["Cost"].ToString());
                                decimal hourlyMarkup = Convert.ToDecimal(dr1["Markup"].ToString());


                                if (time1 >= fromZone && time1 <= toZone)
                                {
                                    l_hourlyCharge1 = hourlyCost;
                                    l_markup_1 = hourlyMarkup;
                                }
                                if (time2 >= fromZone && time2 <= toZone)
                                {
                                    l_hourlyCharge2 = hourlyCost;
                                    l_markup_2 = hourlyMarkup;
                                }
                                if (time3 >= fromZone && time3 <= toZone)
                                {
                                    l_hourlyCharge3 = hourlyCost;
                                    l_markup_3 = hourlyMarkup;
                                }
                                if (time4 >= fromZone && time4 <= toZone)
                                {
                                    l_hourlyCharge4 = hourlyCost;
                                    l_markup_4 = hourlyMarkup;
                                }

                            }



                            if (i == 1)
                            {
                                item["hourlycharge"] = l_hourlyCharge1;
                                item["PressMarkUp"] = l_markup_1;
                            }
                            if (i == 2)
                            {
                                item["hourlycharge"] = l_hourlyCharge2;
                                item["PressMarkUp"] = l_markup_2;
                            }
                            if (i == 3)
                            {
                                item["hourlycharge"] = l_hourlyCharge3;
                                item["PressMarkUp"] = l_markup_3;
                            }
                            if (i == 4)
                            {
                                item["hourlycharge"] = l_hourlyCharge4;
                                item["PressMarkUp"] = l_markup_4;
                            }

                        }
                        else
                        {

                        }
                    }


                    //end

                    if (this.ProfitTaxKey.ToLower() != "database")
                    {
                        num[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
                        num1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "press", Convert.ToInt64(item["PressID"]));
                        if (Convert.ToInt64(item["GuillotineID"]) > (long)0)
                        {
                            numArray1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "guillotine", Convert.ToInt64(item["GuillotineID"]));
                        }
                        num2[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inks", (long)0);
                    }
                    else
                    {
                        num[i - 1] = Convert.ToDecimal(item["PaperMarkup"]);
                        num1[i - 1] = Convert.ToDecimal(item["PressMarkUp"]);
                        numArray1[i - 1] = Convert.ToDecimal(item["GuillotineMarkUp"]);
                        num2[i - 1] = Convert.ToDecimal(item["InkMarkup"]);
                    }

                    decimal valToDivide = new decimal(0);
                    if (this.chkPortrait.Checked)
                    {
                        valToDivide = Convert.ToDecimal(item["PortraitValue"]);
                    }
                    else
                    {
                        valToDivide = Convert.ToDecimal(item["LandscapeValue"]);
                    }

                    decimal num19 = new decimal(0);
                    decimal FullSheetArea = new decimal(0);
                    numArray3[i - 1] = calculation.PaperCalculation(this.CompanyID, str, num18, num[i - 1], item, ref numArray2[i - 1], ref num3[i - 1], ref num4[i - 1], ref numArray4[i - 1], ref num19, ref FullSheetArea, this.chkUSeFullSheets.Checked, valToDivide);
                    numArray15[i - 1] = num19;
                    if (this.chkUSeFullSheets.Checked == true && FullSheetArea > 0)
                        num19 = FullSheetArea;
                    this.InvSheetsForMaterials[i - 1] = num4[i - 1];
                    this.PaperLengthForMaterials[i - 1] = numArray15[i - 1];
                    num6[i - 1] = calculation.PressCalculation(this.CompanyID, str, num18, num1[i - 1], item, numArray4[i - 1], ref num5[i - 1], ref numArray5[i - 1], num19, ref numArray11[i - 1], ref num12[i - 1], ref numArray12[i - 1], ref num13[i - 1], ref numArray13[i - 1], ref num14[i - 1], ref numArray14[i - 1], ref num15[i - 1], ref num16[i - 1], ref numArray16[i - 1], ref num17[i - 1], i, ref numArray18[i - 1], ref numArray19[i - 1]);
                    if (this.LargeFormatCalculation.ToString().ToLower() != "tilling")
                    {
                        numArray6[i - 1] = calculation.GuillotineCalculation(this.CompanyID, str, num18, numArray1[i - 1], item, numArray4[i - 1], ref num7[i - 1], ref numArray7[i - 1], ref num8[i - 1], ref numArray8[i - 1], ref num9[i - 1], ref numArray9[i - 1], num19, ref numArray17[i - 1]);
                    }

                    num10[i - 1] = calculation.InkCalculationforLargeFormat(this.CompanyID, str, num18, num2[i - 1], item, EstimateItemID_TempID, ref numArray10[i - 1], ref num11[i - 1], (long)0, 0, para, i, this.ProfitTaxKey.ToLower(), empty);


                }
            }


            //start


            time1 = Math.Round(numArray11[0]);
            time2 = Math.Round(numArray11[1]);
            time3 = Math.Round(numArray11[2]);
            time4 = Math.Round(numArray11[3]);


            decimal hourlyCharge1 = 0;
            decimal hourlyCharge2 = 0;
            decimal hourlyCharge3 = 0;
            decimal hourlyCharge4 = 0;

            decimal markup_1 = 0;
            decimal markup_2 = 0;
            decimal markup_3 = 0;
            decimal markup_4 = 0;

            DataTable dataTable_press = EstimateBasePage.Estimate_Large_Format_Press_Charge_Select(this.CompanyID, PressID);

            string isCostingMatrix = "no";
            DataTable dataTable_zone = new DataTable();

            foreach (DataRow row in dataTable_press.Rows)
            {
                if (row["CalculationType"].ToString() == "timecosting")
                {
                    isCostingMatrix = "yes";
                    dataTable_zone = SettingsBasePage.Settings_LargeFormatChargeZone_Select_By_IDlong(PressID);
                }
                else
                {
                    isCostingMatrix = "no";
                    dataTable_zone = SettingsBasePage.Settings_LargeFormatChargeZone_Select_By_IDlong(PressID);
                }
            }


            if (isCostingMatrix == "yes")
            {
                for (int i1 = 0; i1 < dataTable_zone.Rows.Count; i1++)
                {

                    DataRow dr1 = dataTable_zone.Rows[i1];
                    decimal fromZone = Convert.ToDecimal(dr1["ZoneFrom"].ToString());
                    decimal toZone = Convert.ToDecimal(dr1["ZoneTo"].ToString());
                    decimal hourlyCost = Convert.ToDecimal(dr1["Cost"].ToString());
                    decimal hourlyMarkup = Convert.ToDecimal(dr1["Markup"].ToString());


                    if (time1 >= fromZone && time1 <= toZone)
                    {
                        hourlyCharge1 = hourlyCost;
                        markup_1 = hourlyMarkup;
                    }
                    if (time2 >= fromZone && time2 <= toZone)
                    {
                        hourlyCharge2 = hourlyCost;
                        markup_2 = hourlyMarkup;
                    }
                    if (time3 >= fromZone && time3 <= toZone)
                    {
                        hourlyCharge3 = hourlyCost;
                        markup_3 = hourlyMarkup;
                    }
                    if (time4 >= fromZone && time4 <= toZone)
                    {
                        hourlyCharge4 = hourlyCost;
                        markup_4 = hourlyMarkup;
                    }

                }

                Int64 ID_ = 0;
                DataTable dataTable1_new = EstimatesBasePage.large_item_select(this.CompanyID, EstimateItemID_TempID);
                foreach (DataRow row1 in dataTable1_new.Rows)
                {

                    ID_ = Convert.ToInt64(row1["EstimateCalculationID"]);
                }

                if (time1 > 0)
                {
                    string query = "UPDATE tb_EstimateCalculation SET hourlycharge = @HourlyRate ,PressMarkUp = @Markup  WHERE EstimateCalculationID=@id";
                    string constr = (new commonClass()).strConnection;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@HourlyRate", hourlyCharge1);
                            cmd.Parameters.AddWithValue("@Markup", markup_1);
                            cmd.Parameters.AddWithValue("@ID", ID_);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }


                if (time2 > 0)
                {
                    string query = "UPDATE tb_EstimateCalculation SET HourlyCharge2 = @HourlyRate ,PressMarkUp2 = @Markup  WHERE EstimateCalculationID=@id";
                    string constr = (new commonClass()).strConnection;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@HourlyRate", hourlyCharge2);
                            cmd.Parameters.AddWithValue("@Markup", markup_2);
                            cmd.Parameters.AddWithValue("@ID", ID_);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }

                if (time3 > 0)
                {
                    string query = "UPDATE tb_EstimateCalculation SET HourlyCharge3 = @HourlyRate ,PressMarkUp3 = @Markup  WHERE EstimateCalculationID=@id";
                    string constr = (new commonClass()).strConnection;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@HourlyRate", hourlyCharge3);
                            cmd.Parameters.AddWithValue("@Markup", markup_3);
                            cmd.Parameters.AddWithValue("@ID", ID_);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }

                if (time4 > 0)
                {
                    string query = "UPDATE tb_EstimateCalculation SET HourlyCharge4 = @HourlyRate ,PressMarkUp4 = @Markup  WHERE EstimateCalculationID=@id";
                    string constr = (new commonClass()).strConnection;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@HourlyRate", hourlyCharge4);
                            cmd.Parameters.AddWithValue("@Markup", markup_4);
                            cmd.Parameters.AddWithValue("@ID", ID_);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }


            }



            //end


            EstimatesBasePage.quantity_insert_large_item(this.CompanyID, EstimateItemID_TempID, numArray[0], num4[0], numArray4[0], numArray2[0], num3[0], num5[0], numArray5[0], num8[0], numArray8[0], num9[0], numArray9[0], num7[0], numArray7[0], numArray10[0], num11[0], numArray[1], num4[1], numArray4[1], numArray2[1], num3[1], num5[1], numArray5[1], num8[1], numArray8[1], num9[1], numArray9[1], num7[1], numArray7[1], numArray10[1], num11[1], numArray[2], num4[2], numArray4[2], numArray2[2], num3[2], num5[2], numArray5[2], num8[2], numArray8[2], num9[2], numArray9[2], num7[2], numArray7[2], numArray10[2], num11[2], numArray[3], num4[3], numArray4[3], numArray2[3], num3[3], num5[3], numArray5[3], num8[3], numArray8[3], num9[3], numArray9[3], num7[3], numArray7[3], numArray10[3], num11[3], para, (long)0, numArray11[0], numArray11[1], numArray11[2], numArray11[3], num12[0], num12[1], num12[2], num12[3], numArray12[0], numArray12[1], numArray12[2], numArray12[3], num13[0], num13[1], num13[2], num13[3], numArray13[0], numArray13[1], numArray13[2], numArray13[3], num14[0], num14[1], num14[2], num14[3], numArray14[0], numArray14[1], numArray14[2], numArray14[3], num15[0], num15[1], num15[2], num15[3], numArray15[0], numArray15[1], numArray15[2], numArray15[3], num17[0], num17[1], num17[2], num17[3], numArray17[0], numArray17[1], numArray17[2], numArray17[3]);
        }

        public void Main_Quantity_Insert_forMaterials(long EstimateItemID_TempID, string para, string StrrMaterialsIDs)
        {
            Calculations calculation = new Calculations();
            string[] strArrays = StrrMaterialsIDs.Split(new char[] { ',' });
            string str = "L";
            int[] numArray = new int[4];
            decimal[] num = new decimal[4];
            decimal[] num1 = new decimal[4];
            decimal[] numArray1 = new decimal[4];
            decimal[] num2 = new decimal[4];
            decimal[] numArray2 = new decimal[4];
            bool flag = false;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    int num3 = 0;
                    if (j != 1)
                    {
                        TextBox textBox = (TextBox)this.FindControl(string.Concat("txtQuantity_", j));
                        num3 = (textBox.Text != "" ? Convert.ToInt32(textBox.Text) : 0);
                    }
                    else if (this.txtQuantity.Text != "")
                    {
                        num3 = Convert.ToInt32(this.txtQuantity.Text);
                    }
                    if (num3 <= 0)
                    {
                        numArray[j - 1] = 0;
                        num[j - 1] = new decimal(0);
                        num1[j - 1] = new decimal(0);
                        numArray1[j - 1] = new decimal(0);
                        num2[j - 1] = new decimal(0);
                        this.InvSheetsForMaterials[j - 1] = new decimal(0);
                        numArray2[j - 1] = new decimal(0);
                        this.PaperLengthForMaterials[j - 1] = new decimal(0);
                    }
                    else
                    {
                        numArray[j - 1] = num3;
                        DataTable dataTable = new DataTable();
                        if (Convert.ToInt64(strArrays[i]) == (long)0)
                        {
                            num[j - 1] = new decimal(0);
                            num1[j - 1] = new decimal(0);
                            numArray1[j - 1] = new decimal(0);
                            num2[j - 1] = new decimal(0);
                            this.InvSheetsForMaterials[j - 1] = new decimal(0);
                            numArray2[j - 1] = new decimal(0);
                            this.PaperLengthForMaterials[j - 1] = new decimal(0);
                        }
                        else
                        {
                            dataTable = EstimatesBasePage.large_item_select_forMaterials((long)this.CompanyID, EstimateItemID_TempID, Convert.ToInt64(strArrays[i]), i + 1);
                            DataRow item = dataTable.Rows[0];
                            if (this.ProfitTaxKey.ToLower() != "database")
                            {
                                num[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
                            }
                            else
                            {
                                num[j - 1] = Convert.ToDecimal(item["MaterialMarkup1"]);
                            }
                            this.InvSheetsForMaterials[j - 1] = Convert.ToDecimal(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.InvSheetsForMaterials[j - 1]), 0, "", false, false, true));
                            this.PaperLengthForMaterials[j - 1] = Convert.ToDecimal(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.PaperLengthForMaterials[j - 1]), 0, "", false, false, true));
                            if (i > 0)
                            {
                                if (!flag)
                                {
                                    this.PaperLengthForMaterials[j - 1] = this.InvSheetsForMaterials[j - 1];
                                }
                                else
                                {
                                    this.InvSheetsForMaterials[j - 1] = this.PaperLengthForMaterials[j - 1];
                                }
                            }
                            num2[j - 1] = calculation.MaterrialCalculation(this.CompanyID, str, num3, i + 1, num[j - 1], item, ref num1[j - 1], ref numArray1[j - 1], this.InvSheetsForMaterials[j - 1], ref numArray2[j - 1], this.PaperLengthForMaterials[j - 1], ref flag);
                        }
                    }
                }
                EstimatesBasePage.insert_largeitem_quantity(EstimateItemID_TempID, (long)0, Convert.ToInt64(strArrays[i]), this.InvSheetsForMaterials[0], this.InvSheetsForMaterials[1], this.InvSheetsForMaterials[2], this.InvSheetsForMaterials[3], numArray2[0], numArray2[1], numArray2[2], numArray2[3], this.PaperLengthForMaterials[0], this.PaperLengthForMaterials[1], this.PaperLengthForMaterials[2], this.PaperLengthForMaterials[3], numArray1[0], num1[0], numArray1[1], num1[1], numArray1[2], num1[2], numArray1[3], num1[3], i + 1, para);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            commonClass _commonClass = new commonClass();
            string empty = string.Empty;
            empty = baseClass.ReturnRoles_Privileges_ForGrid("estimates", "others", this.Page.Request.Url.ToString());
            if (empty == "0" || empty == "2")
            {
                this.Divplus1.Style.Add("display", "none");
                this.Divplus2.Style.Add("display", "none");
                this.Divplus3.Style.Add("display", "none");
                this.Divplus4.Style.Add("display", "none");
                this.Divplus5.Style.Add("display", "none");
            }
            else
            {
                this.Divplus1.Style.Add("display", "block");
                this.Divplus2.Style.Add("display", "block");
                this.Divplus3.Style.Add("display", "block");
                this.Divplus4.Style.Add("display", "block");
                this.Divplus5.Style.Add("display", "block");
            }
            if (base.Request.QueryString["calcType"] != null)
            {
                this.LargeFormatCalculation = base.Request.QueryString["calcType"].ToString().ToLower();
            }
            if (!base.IsPostBack)
            {
                this.Label10.Text = this.objLanguage.GetLanguageConversion("Item_Title");
                this.Label6.Text = this.objLanguage.GetLanguageConversion("Finished_Qty");
                this.Label9.Text = this.objLanguage.GetLanguageConversion("Assigned_Press");
                this.Label13.Text = this.objLanguage.GetLanguageConversion("SetUp_Spoilage");
                this.Label14.Text = this.objLanguage.GetLanguageConversion("Running_Spoilage");
                this.Label21.Text = this.objLanguage.GetLanguageConversion("Price_for_Whole_Pack");
                this.Label28.Text = this.objLanguage.GetLanguageConversion("Stock_Supplied");
                this.Label22.Text = this.objLanguage.GetLanguageConversion("Print_Sheet_Size");
                this.chkPrintSheet.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.Label23.Text = this.objLanguage.GetLanguageConversion("Finished_Job_Size");
                this.ChkJobFlatCustom.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.Label24.Text = this.objLanguage.GetLanguageConversion("Include_Gutters");
                this.Label25.Text = this.objLanguage.GetLanguageConversion("Apply_Press_Restrictions");
                this.Label20.Text = this.objLanguage.GetLanguageConversion("Print_Layout");
                this.chkPortrait.Text = this.objLanguage.GetLanguageConversion("Portrait");
                this.chkLandscape.Text = this.objLanguage.GetLanguageConversion("Landscape");
                this.Label158.Text = this.objLanguage.GetLanguageConversion("Print_Speed");
                this.Label26.Text = this.objLanguage.GetLanguageConversion("Cutting_Table");
                this.btnPrevious.Text = this.objLanguage.GetLanguageConversion("Previous");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Finish");
                this.ddlBookletFormat.Items[0].Text = this.objLanguage.GetLanguageConversion("Portrait");
                this.ddlBookletFormat.Items[0].Text = this.objLanguage.GetLanguageConversion("Landscape");
                this.img_UpdateDescription.Title = this.objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate");
                this.lblPrintQualityDPI.Text = this.objLanguage.GetLanguageConversion("Print_Quality_DPI");
                this.lbl_m1.Text = this.objLanguage.GetLanguageConversion("Material1");
                this.lbl_m2.Text = this.objLanguage.GetLanguageConversion("Material2");
                this.lbl_m3.Text = this.objLanguage.GetLanguageConversion("Material3");
                this.lbl_m4.Text = this.objLanguage.GetLanguageConversion("Material4");
                this.lbl_m5.Text = this.objLanguage.GetLanguageConversion("Material5");
                this.lblinkcovside1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Ink_Coverage"), " (%)");
                this.lblinkcovside2.Text = string.Concat(this.objLanguage.GetLanguageConversion("Ink_Coverage"), " (%)");
                this.lbldoubleside.Text = this.objLanguage.GetLanguageConversion("doublesided");
            }
            if (ConnectionClass.ProfitTaxKey != null)
            {
                this.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
            }
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
            if (base.Request.QueryString["estitemid"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
            }
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
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
            global.pageName = this.submodulename;
            global.pgName = "";
            this.gloobj.setpagename(this.submodulename);
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
            }
            catch
            {
                this.ParentEstimateItemID = (long)0;
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            this.section = base.BaseSection;
            this.txtItemTitle.Focus();
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = _commonClass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = _commonClass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.PrintLayout_MSG_Sheet = this.objLanguage.GetLanguageConversion("Max_no_items");
            if (this.LargeFormatCalculation.ToString().ToLower() != "square")
            {
                if (this.PaperMeasure != "In.")
                {
                    this.Metre = this.objLanguage.GetLanguageConversion("Meters_linear");
                }
                else
                {
                    this.Metre = this.objLanguage.GetLanguageConversion("Feet");
                }
                this.lblPortraitLength.Style.Add("display", "block");
                this.lblLandscapeLength.Style.Add("display", "block");
            }
            else
            {
                this.Metre = this.objLanguage.GetLanguageConversion("Max_no_items");
                if (this.PaperMeasure != "In.")
                {
                    this.lblSqItemSIze.Text = this.objLanguage.GetLanguageConversion("sq_meters_items");
                    this.lblItemSize.Text = this.objLanguage.GetLanguageConversion("Item_Area_Sqm");
                }
                else
                {
                    this.lblSqItemSIze.Text = this.objLanguage.GetLanguageConversion("sq_feet_items");
                    this.lblItemSize.Text = this.objLanguage.GetLanguageConversion("Item_Area_feet");
                }
                this.lblPortraitLength.Style.Add("display", "block");
                this.lblLandscapeLength.Style.Add("display", "block");
            }
            this.txtQuantity.Attributes.Add("style", "text-align:right");
            this.txtQuantity_2.Attributes.Add("style", "text-align:right");
            this.txtRunOnQty.Attributes.Add("style", "text-align:right");
            this.txtQuantity_3.Attributes.Add("style", "text-align:right");
            this.txtQuantity_4.Attributes.Add("style", "text-align:right");
            this.txtSetupSpoilage.Attributes.Add("style", "text-align:right");
            this.txtRunningSpoilage.Attributes.Add("style", "text-align:right");
            this.txtsectionheight.Attributes.Add("style", "text-align:left");
            this.txtsectionwidth.Attributes.Add("style", "text-align:left");
            this.txtportrait.Attributes.Add("style", "text-align:right");
            this.txtlandscape.Attributes.Add("style", "text-align:right");
            this.txtInkCoverageSide1.Attributes.Add("style", "text-align:right");
            this.txtInkCoverageSide2.Attributes.Add("style", "text-align:right");
            this.txtWhiteInkCoverageSide1.Attributes.Add("style", "text-align:right");
            this.txtWhiteInkCoverageSide2.Attributes.Add("style", "text-align:right");
            this.Label11.Text = string.Concat(this.objLanguage.GetLanguageConversion("Side_1"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
            this.lblside2color.Text = string.Concat(this.objLanguage.GetLanguageConversion("Side_2"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
            this.ddlQualitySector.Items[0].Text = this.objLanguage.GetLanguageConversion("Low");
            this.ddlQualitySector.Items[1].Text = this.objLanguage.GetLanguageConversion("Medium");
            this.ddlQualitySector.Items[2].Text = this.objLanguage.GetLanguageConversion("High");
            this.txtportrait.Attributes.Add("onclick", "javascript:Calculations();");
            this.txtportrait.Attributes.Add("onblur", "javascript:Calculations();");
            this.txtlandscape.Attributes.Add("onclick", "javascript:Calculations();");
            this.txtlandscape.Attributes.Add("onblur", "javascript:Calculations();");
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx"))
            {
                this.tabtype = "job";
                this.gloobj.setpagename("job");
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_add.aspx"))
            {
                string str = string.Empty;
                if (string.Compare(this.QueryType, "add", true) != 0)
                {
                    string.Compare(this.QueryType, "edit", true);
                }
            }
            else
            {
                this.tabtype = "invoice";
                this.gloobj.setpagename("invoice");
            }
            DataSet dataSet = new DataSet();
            if (!base.IsPostBack)
            {
                if (!base.Request.Browser.IsBrowser("IE"))
                {
                    this.widthsize = "35%";
                }
                else
                {
                    this.widthsize = "38%";
                }
                this.txtQuantity.Attributes.Add("onblur", "AllowNumber(this,this.value);validatethis(this,this.value);");
                this.txtQuantity_2.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtQuantity_3.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtQuantity_4.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtRunOnQty.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtSetupSpoilage.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                this.txtRunningSpoilage.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                this.txtNoOfPagesRequired.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtPagesPerSection.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtsectionheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                this.txtsectionwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                this.txtitemheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');todecimal_function(this,this.value);");
                this.txtitemwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');todecimal_function(this,this.value);");
                this.txtGutterHorizontal.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                this.txtGutterVertical.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                dataSet = EstimateBasePage.estimate_for_item_add_all(this.CompanyID);
                this.ddlPrintSheetSize.DataSource = dataSet.Tables[0];
                this.ddlPrintSheetSize.DataTextField = "PaperSizeName";
                this.ddlPrintSheetSize.DataValueField = "PaperSizeID";
                this.ddlPrintSheetSize.DataBind();
                this.ddlJobItemSize.DataSource = dataSet.Tables[0];
                this.ddlJobItemSize.DataTextField = "PaperSizeName";
                this.ddlJobItemSize.DataValueField = "PaperSizeID";
                this.ddlJobItemSize.DataBind();
                this.ddlPrintSheetSize.Items.Insert(0, "--- Select ---");
                this.ddlPrintSheetSize.Items[0].Text = string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---");
                this.ddlPrintSheetSize.Items[0].Value = "0";
                this.ddlJobItemSize.Items.Insert(0, string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---"));
                this.ddlJobItemSize.Items[0].Text = string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---");
                this.ddlJobItemSize.Items[0].Value = "0";
                this.hid_ddlPrintSheetSize.Value = dataSet.Tables[1].Rows[0][0].ToString();
                this.hid_ddlPrintSheetSize.Value.Split(new char[] { 'µ' });
                this.hid_LargeFormatPress.Value = dataSet.Tables[4].Rows[0][0].ToString();
                this.hid_DefaultLargePress.Value = dataSet.Tables[5].Rows[0][0].ToString();
                if (string.Compare(this.QueryType, "add", true) == 0 || string.Compare(this.QueryType, "more", true) == 0)
                {
                    this.ddlQualitySector.SelectedIndex = 1;
                    this.txtInkCoverageSide1.Text = "";
                    this.txtInkCoverageSide2.Text = "";
                    foreach (DataRow row in EstimatesBasePage.CopyesttitletoitemTitle(this.CompanyID, this.EstimateID).Rows)
                    {
                        this.txtItemTitle.Text = this.objBase.SpecialDecode(row["EstimateTitle"].ToString());
                    }
                    this.ddlPrintQualityDPI.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:ShowHideInkCoverage1('color');", true);
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
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    long parentEstimateItemID = this.ParentEstimateItemID;
                    if (parentEstimateItemID == (long)0)
                    {
                        parentEstimateItemID = this.EstimateItemID;
                    }
                    foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, parentEstimateItemID).Rows)
                    {
                        this.QtyNo = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                    }
                }
                if (string.Compare(this.modulename, "orders", true) == 0)
                {
                    this.QtyNo = 1;
                }
            }
            else
            {
                this.Select_Large_Item(this.ParentEstimateItemID, this.ParentEstimateType);
                if (!base.IsPostBack)
                {
                    this.Div_ItemDescn.Visible = true;
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
            try
            {
                if (base.Request.QueryString["subedit"] != null)
                {
                    this.subedit = "L";
                    // this.Div_ItemDescn.Visible = false;Amin 29087
                }
            }
            catch
            {
                this.subedit = "0";
            }
            foreach (DataRow dataRow1 in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
            {
                this.IsItemCompleted = Convert.ToInt16(dataRow1["IsItemCompleted"].ToString());
                this.IsProductCreated = Convert.ToInt16(dataRow1["IsProductCreated"].ToString());
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
                foreach (DataRow row2 in quantityForItems.Rows)
                {
                    this.txtQuantity.Text = row2["Quantity1"].ToString();
                    this.txtQuantity_2.Text = row2["Quantity2"].ToString();
                    this.txtRunOnQty.Text = row2["Quantity2"].ToString();
                    this.txtQuantity_3.Text = row2["Quantity3"].ToString();
                    this.txtQuantity_4.Text = row2["Quantity4"].ToString();
                }
            }
            if (this.QueryType == "add" && !base.IsPostBack && EstimateBasePage.DefaultPageSize_Select((long)this.CompanyID) == 1)
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:DefaultLanding();", true);
            }
            this.ddlColors.Items[0].Text = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
            this.ddlColors.Items[1].Text = "Single Special";
            this.ddlColors.Items[2].Text = "Double Special";
            this.ddlColors.Items[3].Text = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"), " Plus Special");
            this.ddlColors.Items[4].Text = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"), " Plus Double Special");
            this.ddlColors_2.Items.Insert(0, new ListItem("Select", "0"));
            this.ddlColors_2.Items[1].Text = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
            this.ddlColors_2.Items[2].Text = "Single Special";
            this.ddlColors_2.Items[3].Text = "Double Special";
            this.ddlColors_2.Items[4].Text = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"), " Plus Special");
            this.ddlColors_2.Items[5].Text = string.Concat("Full ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"), " Plus Double Special");
            this.ddlColors_2.SelectedIndex = 0;
        }

        private void Select_Large_Item(long ParentItemID, string ParentItemType)
        {
            string str = "more";
            if (!base.IsPostBack)
            {
                DataTable dataTable = EstimatesBasePage.estimate_qty_select(this.CompanyID, this.EstimateItemID, (long)0);
                foreach (DataRow row in dataTable.Rows)
                {
                    int num = row["Qty1"] == DBNull.Value ? 0 : Convert.ToInt32(row["Qty1"]);
                    int num1 = row["Qty2"] == DBNull.Value ? 0 : Convert.ToInt32(row["Qty2"]);
                    int num2 = row["Qty3"] == DBNull.Value ? 0 : Convert.ToInt32(row["Qty3"]);
                    int num3 = row["Qty4"] == DBNull.Value ? 0 : Convert.ToInt32(row["Qty4"]);
                    if (num != 0)
                    {
                        this.txtQuantity.Text = num.ToString();
                    }
                    if (num1 != 0)
                    {
                        this.txtQuantity_2.Text = num1.ToString();
                        str = "more";
                    }
                    if (num2 != 0)
                    {
                        this.txtQuantity_3.Text = num2.ToString();
                        str = "more";
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    this.txtQuantity_4.Text = num3.ToString();
                    str = "more";
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0 || string.Compare(this.modulename, "orders", true) == 0)
                {
                    if (ParentItemID == (long)0)
                    {
                        ParentItemID = this.EstimateItemID;
                    }
                    foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, ParentItemID).Rows)
                    {
                        this.QtyNo = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                    }
                    if (string.Compare(this.modulename, "orders", true) == 0)
                    {
                        this.QtyNo = 1;
                    }
                    this.txtQuantity.Attributes.Add("onblur", "AllowNumber(this,this.value);validatethis(this,this.value);");
                    this.txtQuantity_2.Attributes.Add("onblur", "AllowNumber(this,this.value);validatethis(this,this.value);");
                    this.txtQuantity_3.Attributes.Add("onblur", "AllowNumber(this,this.value);validatethis(this,this.value);");
                    this.txtQuantity_4.Attributes.Add("onblur", "AllowNumber(this,this.value);validatethis(this,this.value);");
                }
            }
            DataTable dataTable1 = EstimatesBasePage.large_item_select(this.CompanyID, this.EstimateItemID);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row1 in dataTable1.Rows)
            {
                this.hid_height.Value = row1["Height"].ToString();
                this.hid_width.Value = row1["Width"].ToString();
                this.hid_IsSheetCustom.Value = row1["IsSheetCustom"].ToString();
                this.hid_IsJobCustom.Value = row1["IsJobCustom"].ToString();
                this.EstimateLargeItemID = Convert.ToInt64(row1["EstimateLargeItemID"]);
                this.EstimateCalculationID = row1["EstimateCalculationID"] == DBNull.Value ? 0L : Convert.ToInt64(row1["EstimateCalculationID"]);
                this.TypeID = this.EstimateLargeItemID;
                stringBuilder.Append("EstimateType»largeformat±");
                stringBuilder.Append("ProductType»largeformat±");
                stringBuilder.AppendFormat("QtyType»{0}±", str);
                stringBuilder.AppendFormat("Press»{0}»{1}±", row1["PressID"].ToString(), "L");
                object[] objArray = new object[] { row1["PaperID"].ToString(), row1["PaperName"].ToString(), row1["IsPricePerPack"].ToString(), row1["IsPaperSupplied"].ToString() };
                stringBuilder.AppendFormat("Paper»{0}»{1}»{2}»{3}±", objArray);
                object[] str1 = new object[] { row1["MaterialID2"].ToString(), row1["MaterialName2"].ToString(), row1["IsPricePerPack2"].ToString(), row1["IsPaperSupplied2"].ToString() };
                stringBuilder.AppendFormat("Material2»{0}»{1}»{2}»{3}±", str1);
                object[] objArray1 = new object[] { row1["MaterialID3"].ToString(), row1["MaterialName3"].ToString(), row1["IsPricePerPack3"].ToString(), row1["IsPaperSupplied3"].ToString() };
                stringBuilder.AppendFormat("Material3»{0}»{1}»{2}»{3}±", objArray1);
                object[] str2 = new object[] { row1["MaterialID4"].ToString(), row1["MaterialName4"].ToString(), row1["IsPricePerPack4"].ToString(), row1["IsPaperSupplied4"].ToString() };
                stringBuilder.AppendFormat("Material4»{0}»{1}»{2}»{3}±", str2);
                object[] objArray2 = new object[] { row1["MaterialID5"].ToString(), row1["MaterialName5"].ToString(), row1["IsPricePerPack5"].ToString(), row1["IsPaperSupplied5"].ToString() };
                stringBuilder.AppendFormat("Material5»{0}»{1}»{2}»{3}±", objArray2);
                stringBuilder.AppendFormat("SetupSpoilage»{0}±", row1["SetupSpoilage"].ToString());
                stringBuilder.AppendFormat("RunningSpoilage»{0}±", row1["RunningSpoilage"].ToString());
                stringBuilder.AppendFormat("Colour»{0}»{1}±", row1["Colour"].ToString(), row1["IsDoubleSided"].ToString());
                object[] str3 = new object[] { row1["PrintSheetSizeID"].ToString(), row1["IsSheetCustom"].ToString(), row1["SheetHeight"].ToString(), row1["SheetWidth"].ToString() };
                stringBuilder.AppendFormat("SheetSize»{0}»{1}»{2}»{3}±", str3);
                object[] objArray3 = new object[] { row1["JobFlatSizeID"].ToString(), row1["IsJobCustom"].ToString(), row1["JobHeight"].ToString(), row1["JobWidth"].ToString() };
                stringBuilder.AppendFormat("ItemSize»{0}»{1}»{2}»{3}±", objArray3);
                stringBuilder.AppendFormat("Gutters»{0}»{1}»{2}±", row1["IsIncludeGutters"].ToString(), row1["GutterHorizontal"].ToString(), row1["GutterVertical"].ToString());
                stringBuilder.AppendFormat("PressRestrictions»{0}±", row1["IsPressRestrictions"].ToString());
                stringBuilder.AppendFormat("PrintLayout»{0}»{1}»{2}±", row1["PrintLayout"].ToString(), row1["PortraitValue"].ToString(), row1["LandscapeValue"].ToString());
                stringBuilder.AppendFormat("Guillotine»{0}»{1}±", row1["GuillotineID"].ToString(), row1["GuillotineName"].ToString());
                stringBuilder.AppendFormat("IsFirstTrim»{0}±", row1["IsFirstTrim"].ToString());
                stringBuilder.AppendFormat("IsSecondTrim»{0}±", row1["IsSecondTrim"].ToString());
                stringBuilder.AppendFormat("IsAnyOutwork»{0}±", row1["IsAnyOutwork"].ToString());
                stringBuilder.AppendFormat("IsAnyWarehouse»{0}±", row1["IsAnyWarehouseItem"].ToString());
                stringBuilder.AppendFormat("IsAnyOtherCost»{0}±", row1["IsAnyOtherCost"].ToString());
                stringBuilder.AppendFormat("InventoryPaperType»{0}±", row1["InventoryPaperType"].ToString());
                stringBuilder.AppendFormat("PressPaperType»{0}±", row1["PressPaperType"].ToString());
                stringBuilder.AppendFormat("SideColor»{0}±", row1["SideColor"].ToString());
                stringBuilder.AppendFormat("Row»{0}±", row1["Row"].ToString());
                stringBuilder.AppendFormat("Col»{0}±", row1["Col"].ToString());
                stringBuilder.AppendFormat("PaperWeight»{0}±", row1["PaprWeight"].ToString());
                stringBuilder.AppendFormat("PaperWeight2»{0}±", row1["PaperWeight2"].ToString());
                stringBuilder.AppendFormat("PaperWeight3»{0}±", row1["PaperWeight3"].ToString());
                stringBuilder.AppendFormat("PaperWeight4»{0}±", row1["PaperWeight4"].ToString());
                stringBuilder.AppendFormat("PaperWeight5»{0}±", row1["PaperWeight5"].ToString());
                this.LargeItemPrintLayout = row1["PrintLayout"].ToString();
                if (!base.IsPostBack)
                {
                    this.txtItemTitle.Text = this.objBase.SpecialDecode(row1["ItemTitle"].ToString());
                    TextBox textBox = this.txtInkCoverageSide1;
                    int num4 = Convert.ToInt32(row1["InkCoverageSide1"]);
                    textBox.Text = num4.ToString();
                    TextBox textBox1 = this.txtInkCoverageSide2;
                    int num5 = Convert.ToInt32(row1["InkCoverageSide2"]);
                    textBox1.Text = num5.ToString();
                    TextBox textBox2 = this.txtWhiteInkCoverageSide1;
                    int num6 = Convert.ToInt32(row1["WhiteInkCoverageSide1"]);
                    textBox2.Text = num6.ToString();
                    TextBox textBox3 = this.txtWhiteInkCoverageSide2;
                    int num7 = Convert.ToInt32(row1["WhiteInkCoverageSide2"]);
                    textBox3.Text = num7.ToString();
                    this.ddlQualitySector.SelectedValue = row1["PrintQuality"].ToString();
                    this.ddlPrintQualityDPI.SelectedValue = row1["DPI"].ToString();
                    this.hid_Row.Value = row1["Row"].ToString();
                    this.hid_Col.Value = row1["Col"].ToString();
                    this.hdnOldPressID.Value = row1["PressID"].ToString();
                    this.hdnOldPaperID.Value = row1["PaperID"].ToString();
                    this.hdnOldGuillotineID.Value = row1["GuillotineID"].ToString();
                    this.hdn_InvpaperID.Value = row1["PaperID"].ToString();
                    this.hdnOldPaperID2.Value = row1["MaterialID2"].ToString();
                    this.hdnOldPaperID3.Value = row1["MaterialID3"].ToString();
                    this.hdnOldPaperID4.Value = row1["MaterialID4"].ToString();
                    this.hdnOldPaperID5.Value = row1["MaterialID5"].ToString();
                    this.hdn_InvpaperID2.Value = row1["MaterialID2"].ToString();
                    this.hdn_InvpaperID3.Value = row1["MaterialID3"].ToString();
                    this.hdn_InvpaperID4.Value = row1["MaterialID4"].ToString();
                    this.hdn_InvpaperID5.Value = row1["MaterialID5"].ToString();
                    this.LargeFormatCalculation = row1["calctype"].ToString();
                    if (row1["isFullSheet"].ToString().ToLower() != "false")
                    {
                        this.chkUSeFullSheets.Checked = true;
                    }
                }
                this.PaperType = row1["InventoryPaperType"].ToString();
            }
            this.hid_singleData.Value = stringBuilder.ToString();
            this.pnlPadEdit.Visible = true;
        }

        private void Update_Large_Item()
        {
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = this.hid_booklet_save.Value.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                    if (strArrays2[0].Trim() != "SectionRef")
                    {
                        if (strArrays2[0].Trim() == "PressID")
                        {
                            estimatesItem.PressID = Convert.ToInt64(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PressType")
                        {
                            estimatesItem.PressType = 'D';
                        }
                        else if (strArrays2[0].Trim() == "PaperID")
                        {
                            estimatesItem.PaperID = Convert.ToInt64(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PriceForWhaolePack")
                        {
                            estimatesItem.IsPricePerPack = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PaperSupplied")
                        {
                            estimatesItem.IsPaperSupplied = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "SetupSpoilage")
                        {
                            estimatesItem.SetupSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "RunningSpoilage")
                        {
                            estimatesItem.RunningSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Colour")
                        {
                            estimatesItem.Colour = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "IsDoubleSided")
                        {
                            estimatesItem.IsDoubleSided = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (string.Compare(strArrays2[0].Trim(), "SideColor", true) == 0)
                        {
                            estimatesItem.SideColor = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "PrintSheetSizeID")
                        {
                            estimatesItem.PrintSheetSizeID = Convert.ToInt32(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "IsPrintCustom")
                        {
                            estimatesItem.IsSheetCustom = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PrintSheetHeight")
                        {
                            estimatesItem.SheetHeight = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PrintSheetWidth")
                        {
                            estimatesItem.SheetWidth = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "JobFlatSizeID")
                        {
                            estimatesItem.JobFlatSizeID = Convert.ToInt32(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "IsJobCustom")
                        {
                            estimatesItem.IsJobCustom = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "JobFlatSizeHeight")
                        {
                            estimatesItem.JobHeight = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "JobFlatSizeWidth")
                        {
                            estimatesItem.JobWidth = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "IsIncludeGutters")
                        {
                            estimatesItem.IsIncludeGutters = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "GutterHorizontal")
                        {
                            estimatesItem.GutterHorizontal = Convert.ToDecimal((strArrays2[1].Trim() == "" ? "0" : strArrays2[1]));
                        }
                        else if (strArrays2[0].Trim() == "GutterVertical")
                        {
                            estimatesItem.GutterVertical = Convert.ToDecimal((strArrays2[1].Trim() == "" ? "0" : strArrays2[1]));
                        }
                        else if (strArrays2[0].Trim() == "IsPressRestrictions")
                        {
                            estimatesItem.IsPressRestrictions = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PrintLayout")
                        {
                            estimatesItem.PrintLayout = Convert.ToChar(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PortraitValue")
                        {
                            estimatesItem.PortraitValue = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "LandscapeValue")
                        {
                            estimatesItem.LandscapeValue = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "GuilotineID" && this.LargeFormatCalculation.ToString().ToLower() != "tilling")
                        {
                            estimatesItem.GuillotineID = Convert.ToInt64(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "IsFirstTrim")
                        {
                            estimatesItem.IsFirstTrim = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "IsSecondTrim")
                        {
                            estimatesItem.IsSecondTrim = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                    }
                }
            }
            estimatesItem.ModifiedBy = Convert.ToInt32(base.Session["UserID"]);
            estimatesItem.ModifiedDate = DateTime.Now;
            estimatesItem.IsAnyWarehouseItem = 'N';
            estimatesItem.IsAnyOutwork = 'N';
            estimatesItem.IsAnyOtherCost = 'N';
            estimatesItem.MaterialID2 = Convert.ToInt64(this.hdnpaperID2.Value.ToString());
            estimatesItem.MaterialID3 = Convert.ToInt64(this.hdnpaperID3.Value.ToString());
            estimatesItem.MaterialID4 = Convert.ToInt64(this.hdnpaperID4.Value.ToString());
            estimatesItem.MaterialID5 = Convert.ToInt64(this.hdnpaperID5.Value.ToString());
            estimatesItem.IsPricePerPack2 = this.Chk_PriceForWholePack2.Checked;
            estimatesItem.IsPricePerPack3 = this.Chk_PriceForWholePack3.Checked;
            estimatesItem.IsPricePerPack4 = this.Chk_PriceForWholePack4.Checked;
            estimatesItem.IsPricePerPack5 = this.Chk_PriceForWholePack5.Checked;
            estimatesItem.IsPaperSupplied2 = this.Chk_PaperSupplied2.Checked;
            estimatesItem.IsPaperSupplied3 = this.Chk_PaperSupplied3.Checked;
            estimatesItem.IsPaperSupplied4 = this.Chk_PaperSupplied4.Checked;
            estimatesItem.IsPaperSupplied5 = this.Chk_PaperSupplied5.Checked;
            if (this.EstimateItemID != (long)0 && this.EstimateLargeItemID != (long)0)
            {
                estimatesItem.ItemTitle = this.Objclss.SpecialEncode(this.txtItemTitle.Text);
                estimatesItem.EstimateLargeItemID = this.EstimateLargeItemID;
                estimatesItem.PrintQuality = this.ddlQualitySector.SelectedValue;
                estimatesItem.InkCoverageSide1 = Convert.ToDecimal(this.txtInkCoverageSide1.Text);
                estimatesItem.InkCoverageSide2 = Convert.ToDecimal(this.txtInkCoverageSide2.Text);
                estimatesItem.Row = Convert.ToDecimal(this.hid_Row.Value);
                estimatesItem.Col = Convert.ToDecimal(this.hid_Col.Value);
                estimatesItem.WhiteInkCoverageSide1 = Convert.ToDecimal(this.txtWhiteInkCoverageSide1.Text);
                estimatesItem.WhiteInkCoverageSide2 = Convert.ToDecimal(this.txtWhiteInkCoverageSide2.Text);
                estimatesItem.DPI = Convert.ToInt32(this.ddlPrintQualityDPI.SelectedValue);
                estimatesItem.ItemDescription = "";
                estimatesItem.isFullSheet = this.chkUSeFullSheets.Checked;
                if ((string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0) && this.hdn_invStockBack.Value.ToLower() == "yes")
                {
                    this.summryCls.Call_Inventory_Adjustment("cancelled", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                }
                object[] paperID = new object[] { estimatesItem.PaperID, ",", estimatesItem.MaterialID2, ",", estimatesItem.MaterialID3, ",", estimatesItem.MaterialID4, ",", estimatesItem.MaterialID5 };
                string str = string.Concat(paperID);
                EstimatesBasePage.large_item_insert(estimatesItem);
                this.PressID = estimatesItem.PressID;
                this.Estimate_Calcukation_Update(this.EstimateItemID, (long)0, str, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, this.EstType);
                this.Main_Quantity_Insert(this.EstimateItemID, "updateqty", estimatesItem);
                this.Main_Quantity_Insert_forMaterials(this.EstimateItemID, "update", str);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
                if (this.Chk_ItemDescn.Checked)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "L", true);
                }
                if (this.IsProductCreated == 1)
                {
                    int num = 0;
                    if (this.chkPoduct1.Checked)
                    {
                        num = 1;
                    }
                    else if (this.chkPoduct2.Checked)
                    {
                        num = 2;
                    }
                    DataTable dataTable = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "L");
                    if (dataTable.Rows.Count > 0)
                    {
                        dataTable.Rows[0]["PricecatalogueID"].ToString();
                        if (num == 1 || num == 2)
                        {
                            EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "L", num);
                        }
                    }
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "L");
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
                this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            }
            if (this.ParentEstimateItemID == (long)0)
            {
                EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "L");
            }
        }
    }
}