using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint
{
    public partial class single_item : UsercontrolBasePage
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

        //protected HiddenField hid_DigitalPress;

        //protected HiddenField hid_LargeFormatPress;

        //protected HiddenField hid_DefaultDigitalPress;

        //protected HiddenField hid_DefaultLargePress;

        //protected Label Label12;

        //protected HtmlImage ImgPlus;

        //protected HiddenField hdn_PaperProperties;

        //protected HtmlGenericControl Divplus;

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

        //protected Label Label1;

        //protected HtmlImage Img_ItemDescnHelp;

        //protected HtmlAnchor rerunOverwrite;

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

        //protected HiddenField hid_IsJobCustom;

        //protected HiddenField hid_IsSheetCustom;

        //protected HiddenField hdnedit_Default;

        //protected HiddenField hdnOldPressID;

        //protected HiddenField hdnOldPaperID;

        //protected HiddenField hdnOldGuillotineID;

        //protected HiddenField hdn_InvpaperID;

        //protected HiddenField hdn_invStockBack;

        //protected HiddenField hdn_invStockReduce;

        //protected Panel pnlPadEdit;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

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

        public long EstimateCalculationID;

        public long EstSingleItemID;

        public long EstimateSingleItemID;

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

        private commonClass commclass = new commonClass();

        private SummaryClass summryCls = new SummaryClass();

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public string modulename = "estimates";

        public string submodulename = "estimate";

        public string EstTypeFromSP = string.Empty;

        public string ParentItemType = string.Empty;

        public long EstimateBookletItemID;

        public string PaperMeasure = string.Empty;

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public string subedit = string.Empty;

        public double subtotal1;

        public double subtotal2;

        public double subtotal3;

        public double subtotal4;

        public string MainType = string.Empty;

        public string frmcopyitem = string.Empty;

        public int QtyNo;

        public int IsItemCompleted;

        public string ProfitTaxKey = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

        private commonClass objJava = new commonClass();

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public int IsProductCreated;

        public string SingleItemPrintLayout = string.Empty;

        public bool IsPaperUnitPriceLocked;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

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

        public single_item()
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
                        object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=S&From=F&maintype=", this.MainType, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID1));
                        return;
                    }
                    if (empty.ToString().ToLower() == "yes")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray1));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
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
                    object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
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
                            object[] objArray3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?Estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                            httpResponse3.Redirect(string.Concat(objArray3));
                            return;
                        }
                        HttpResponse response4 = base.Response;
                        object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?Estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
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
                    object[] objArray5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=S&From=S&EstItemID=", this.EstimateItemID, "&maintype=", this.MainType, this.jID, this.InvID };
                    httpResponse5.Redirect(string.Concat(objArray5));
                }
                else
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        HttpResponse response6 = base.Response;
                        object[] estimateID6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&Estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
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
                    this.Update_Single_Item();
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
                if (empty.ToString().ToLower() == "yes")
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
            if (empty.ToString().ToLower() == "yes")
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
            string empty = string.Empty;
            long num = (long)0;
            long num1 = (long)0;
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            estimatesItem.EstimateItemID = (long)0;
            estimatesItem.EstQuantityID = (long)0;
            estimatesItem.IsAnyWarehouseItem = 'N';
            estimatesItem.IsAnyOutwork = 'N';
            estimatesItem.IsAnyOtherCost = 'N';
            empty = "S";
            HttpContext.Current.Session[string.Concat("ZoneMarkupCalcDetails", num.ToString())] = null;
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
                        strArrays2[1] = (strArrays2[1] != null ? strArrays2[1].Trim() : "0");
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.SetupSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "RunningSpoilage")
                    {
                        strArrays2[1] = (strArrays2[1] != null ? strArrays2[1].Trim() : "0");
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.RunningSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "NoOfPagesInSection" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        strArrays2[1] = (strArrays2[1] != null ? strArrays2[1].Trim() : "0");
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                    }
                    else if (strArrays2[0].Trim() == "PagesPerSignature" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        strArrays2[1] = (strArrays2[1] != null ? strArrays2[1].Trim() : "0");
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                    }
                    else if (strArrays2[0].Trim() == "NoOfSignatures" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        strArrays2[1] = (strArrays2[1] != null ? strArrays2[1].Trim() : "0");
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
                        strArrays2[1] = (strArrays2[1] != null ? strArrays2[1].Trim() : "1");
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
                    else if (strArrays2[0].Trim() == "ManualValue")
                    {
                        estimatesItem.ManualValue = (string.IsNullOrEmpty(strArrays2[1].Trim()) ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                    }
                    else if (strArrays2[0].Trim() == "GuilotineID")
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
            if (empty == "S")
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
                EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, num, ConnectionClass.IsHandy);
                if (this.InvoiceID <= (long)0)
                {
                    long num2 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, empty, flag, parentEstimateItemID);
                    num = num2;
                    estimatesItem.EstimateItemID = num2;
                }
                else
                {
                    long num3 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, empty, flag, parentEstimateItemID);
                    num = num3;
                    estimatesItem.EstimateItemID = num3;
                }
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
                estimatesItem.ItemDescription = EstimateCommonMethods.GetCommonItemDescription_ForAllTypes(num);
                EstimatesBasePage.single_item_insert(estimatesItem);
                this.PressID = Convert.ToInt64(estimatesItem.PressID);
                this.Estimate_Calcukation(num, (long)0, estimatesItem.PaperID, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, empty);
                this.Main_Quantity_Insert(num, "qty", estimatesItem);
            }
            if (base.Request.Params["parentestitemid"] == null)
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(num);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, num);
            if (ParentItemID == (long)0)
            {
                EstimateCommonMethods.UpdateDescription(num, this.EstimateID, "S", false);
            }
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                if (ParentItemID == (long)0)
                {
                    JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, num, 1, this.EstimateID);
                }
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, num, "S");
                string empty1 = string.Empty;
                long parentItemID = num;
                foreach (DataRow row in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty1 = row["StatusID"].ToString();
                }
                if (string.Compare(this.modulename, "jobs", true) == 0 && this.ParentEstimateItemID == (long)0)
                {
                    this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty1), "job", num, (long)0);
                }
                if (ParentItemID != (long)0)
                {
                    parentItemID = ParentItemID;
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
                foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                {
                    empty2 = dataRow["PhraseText"].ToString();
                }
                foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                {
                    str2 = row1["PhraseText"].ToString();
                }
                EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty2, str2);
            }
            if (ParentItemID == (long)0)
            {
                if (EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "S") > (long)0)
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

        private string Estimate_Calcukation(long EstimateItemID, long EstimateBookletItemID, long PaperID, long PressID, char PressType, long GuillotineID, string EstimateType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = EstimateBasePage.Paper_Calculation(this.CompanyID, Convert.ToInt32(PaperID)).Split(new char[] { '±' });
            string empty = string.Empty;
            decimal num = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "I", PaperID));
            if (PressType != 'D')
            {
                stringBuilder.Append(" Insert into [tb_EstimateCalculation] ");
                stringBuilder.Append(" ( EstimateItemID, EstBookletSectionID, ");
                stringBuilder.Append(" PaperUnitPrice, PaperWeight, PaperMarkup,PaperMarkup,PaperMarkup2,PaperMarkup3,PaperMarkup4, ");
                stringBuilder.Append(" PressMarkUp,PressMarkUp2,PressMarkUp3,PressMarkUp4, PressSetupCharge, PressMinimumRunningCharge, PressType, ");
                stringBuilder.Append(" HourlyCharge, ");
                stringBuilder.Append(" PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, ");
                stringBuilder.Append(" GuillotineSetupCharge, GuillotineMinimumRunningCharge, GuillotineMarkUp,GuillotineMarkUp2,GuillotineMarkUp3,GuillotineMarkUp4, ");
                stringBuilder.Append(" GuillotineCostPerCut, GuillotinePaperWeight1, GuillotineMaximumThroat1, ");
                stringBuilder.Append(" GuillotinePaperWeight2, GuillotineMaximumThroat2, GuillotinePaperWeight3, ");
                stringBuilder.Append(" GuillotineMaximumThroat3,  ");
                stringBuilder.Append(" OneSqCmInkCost, InkMarkup,PaperPackedInQty )");
                stringBuilder.Append(" Values ");
                object[] estimateItemID = new object[] { " ( ", EstimateItemID, ", ", this.EstBookletSectionID, "," };
                stringBuilder.Append(string.Concat(estimateItemID));
                string[] strArrays1 = new string[] { " ", strArrays[0], ",", strArrays[1], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], ", " };
                stringBuilder.Append(string.Concat(strArrays1));
                DataTable dataTable = EstimateBasePage.Estimate_Large_Format_Press_Charge_Select(this.CompanyID, PressID);
                string str = string.Empty;
                decimal num1 = new decimal(0);
                foreach (DataRow row in dataTable.Rows)
                {
                    string[] str1 = new string[] { " ", row["MarkUp"].ToString(), ",", row["MarkUp"].ToString(), ",", row["MarkUp"].ToString(), ",", row["MarkUp"].ToString(), ",", row["SetupCharge"].ToString(), ",", row["MinimumCharge"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str1));
                    stringBuilder.Append("'L',");
                    stringBuilder.Append(string.Concat(row["PerHourCharge"].ToString(), ","));
                    string[] str2 = new string[] { " ", row["PrintPerHourLow"].ToString(), ",", row["PrintPerHourMedium"].ToString(), ",", row["PrintPerHourHigh"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str2));
                    str = row["InkValues"].ToString();
                    num1 = Convert.ToDecimal(row["InkMarkup"]);
                }
                DataTable dataTable1 = EstimateBasePage.Estimate_Guillotine_Select_By_ID(this.CompanyID, GuillotineID);
                if (dataTable1.Rows.Count <= 0)
                {
                    stringBuilder.Append(" 0,0,0,0,0,0, ");
                    stringBuilder.Append(" 0,0,0, ");
                    stringBuilder.Append(" 0,0,0, ");
                    stringBuilder.Append(" 0, ");
                }
                else
                {
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        string[] strArrays2 = new string[] { " ", dataRow["SetUpCharge"].ToString(), ",", dataRow["MinCharge"].ToString(), ",", dataRow["MarkUp"].ToString(), ",", dataRow["MarkUp"].ToString(), ",", dataRow["MarkUp"].ToString(), ",", dataRow["MarkUp"].ToString(), "," };
                        stringBuilder.Append(string.Concat(strArrays2));
                        string[] str3 = new string[] { " ", dataRow["CostPerCut"].ToString(), ",", dataRow["PaperWeight1"].ToString(), ",", dataRow["MaxSheets1"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str3));
                        string[] strArrays3 = new string[] { " ", dataRow["PaperWeight2"].ToString(), ",", dataRow["MaxSheets2"].ToString(), ",", dataRow["PaperWeight3"].ToString(), "," };
                        stringBuilder.Append(string.Concat(strArrays3));
                        stringBuilder.Append(string.Concat(" ", dataRow["MaxSheets3"].ToString(), ","));
                    }
                }
                object[] objArray = new object[] { " '", str, "', ", num1, ",", num, " )" };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append(" declare @EstimateCalculationID bigint; ");
                stringBuilder.Append(" set @EstimateCalculationID = Ident_Current('[tb_EstimateCalculation]')");
                stringBuilder.Append(" select @EstimateCalculationID ");
                EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            }
            else
            {
                stringBuilder.Append(" Insert into [tb_EstimateCalculation] ");
                stringBuilder.Append(" ( EstimateItemID, EstimateBookletItemID, ");
                stringBuilder.Append(" PaperUnitPrice, PaperWeight, PaperMarkup,PaperMarkup2,PaperMarkup3,PaperMarkup4, ");
                stringBuilder.Append(" PressMarkUp,PressMarkUp2,PressMarkUp3,PressMarkUp4, PressSetupCharge, PressMinimumRunningCharge, PressType, ");
                stringBuilder.Append(" BlackChargeableRate, ColorChargeableRate, NoOfChargeableSheets, ");
                stringBuilder.Append(" HourlyCharge, ");
                stringBuilder.Append(" PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, ");
                stringBuilder.Append(" GuillotineSetupCharge, GuillotineMinimumRunningCharge, GuillotineMarkUp,GuillotineMarkUp2,GuillotineMarkUp3,GuillotineMarkUp4, ");
                stringBuilder.Append(" GuillotineCostPerCut, GuillotinePaperWeight1, GuillotineMaximumThroat1, ");
                stringBuilder.Append(" GuillotinePaperWeight2, GuillotineMaximumThroat2, GuillotinePaperWeight3, ");
                stringBuilder.Append(" GuillotineMaximumThroat3,PaperPackedInQty ) ");
                stringBuilder.Append(" Values ");
                object[] estimateItemID1 = new object[] { " ( ", EstimateItemID, ", ", EstimateBookletItemID, "," };
                stringBuilder.Append(string.Concat(estimateItemID1));
                string[] strArrays4 = new string[] { " ", strArrays[0], ",", strArrays[1], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], ", " };
                stringBuilder.Append(string.Concat(strArrays4));
                foreach (DataRow row1 in EstimateBasePage.Estimate_Digital_Press_Select(this.CompanyID, PressID).Rows)
                {
                    string[] str4 = new string[] { " ", row1["MarkUp"].ToString(), ",", row1["MarkUp"].ToString(), ",", row1["MarkUp"].ToString(), ",", row1["MarkUp"].ToString(), ",", row1["SetupCharge"].ToString(), ",", row1["MinimumCharge"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str4));
                    if (row1["MethodName"].ToString() == "ClickChargeLookup")
                    {
                        empty = "ClickChargeLookup";
                        stringBuilder.Append("'C',");
                        string[] str5 = new string[] { " ", row1["BlackChargeableSheets"].ToString(), ",", row1["ColorChargeableSheets"].ToString(), ",", row1["ChargeableSheets"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str5));
                        stringBuilder.Append(" 0, ");
                        stringBuilder.Append(" 0,0,0, ");
                    }
                    else if (row1["MethodName"].ToString() != "SpeedWeightLookup")
                    {
                        if (row1["MethodName"].ToString() != "ClickChargeZoneLookup")
                        {
                            continue;
                        }
                        empty = "ClickChargeZoneLookup";
                        stringBuilder.Append("'Z',");
                        stringBuilder.Append("0,0,0,");
                        stringBuilder.Append(" 0, ");
                        stringBuilder.Append(" 0, 0, 0, ");
                    }
                    else
                    {
                        empty = "SpeedWeightLookup";
                        stringBuilder.Append("'S',");
                        stringBuilder.Append("0,0,0,");
                        stringBuilder.Append(string.Concat(" ", row1["HourlyCharge"].ToString(), ", "));
                        stringBuilder.Append(" 0, 0, 0, ");
                    }
                }
                DataTable dataTable2 = EstimateBasePage.Estimate_Guillotine_Select_By_ID(this.CompanyID, GuillotineID);
                if (dataTable2.Rows.Count <= 0)
                {
                    stringBuilder.Append(" 0,0,0,0,0,0, ");
                    stringBuilder.Append(" 0,0,0, ");
                    stringBuilder.Append(" 0,0,0, ");
                    stringBuilder.Append(" 0, ");
                }
                else
                {
                    foreach (DataRow dataRow1 in dataTable2.Rows)
                    {
                        string[] strArrays5 = new string[] { " ", dataRow1["SetUpCharge"].ToString(), ",", dataRow1["MinCharge"].ToString(), ",", dataRow1["MarkUp"].ToString(), ",", dataRow1["MarkUp"].ToString(), ",", dataRow1["MarkUp"].ToString(), ",", dataRow1["MarkUp"].ToString(), "," };
                        stringBuilder.Append(string.Concat(strArrays5));
                        string[] str6 = new string[] { " ", dataRow1["CostPerCut"].ToString(), ",", dataRow1["PaperWeight1"].ToString(), ",", dataRow1["MaxSheets1"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str6));
                        string[] strArrays6 = new string[] { " ", dataRow1["PaperWeight2"].ToString(), ",", dataRow1["MaxSheets2"].ToString(), ",", dataRow1["PaperWeight3"].ToString(), "," };
                        stringBuilder.Append(string.Concat(strArrays6));
                        stringBuilder.Append(string.Concat(" ", dataRow1["MaxSheets3"].ToString(), ","));
                    }
                }
                stringBuilder.Append(string.Concat(" ", num, ")"));
                stringBuilder.Append(" declare @EstimateCalculationID bigint; ");
                stringBuilder.Append(" set @EstimateCalculationID = Ident_Current('tb_EstimateCalculation')");
                stringBuilder.Append(" select @EstimateCalculationID ");
                long num2 = EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
                if (empty == "ClickChargeZoneLookup")
                {
                    EstimatesBasePage.estimate_click_charge_zone_insert(this.CompanyID, num2, PressID);
                }
                else if (string.Compare(empty, "SpeedWeightLookup", true) == 0)
                {
                    EstimatesBasePage.estimate_speed_weight_insert(this.CompanyID, num2, PressID);
                }
            }
            return stringBuilder.ToString();
        }

        private void Estimate_Calcukation_Update(long EstimateItemID, long EstBookletSectionID, long PaperID, long PressID, char PressType, long GuillotineID, string EstimateType, bool IsPaperUnitPriceLocked)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" Update [tb_EstimateCalculation] ");
            stringBuilder.Append(string.Concat(" Set EstimateItemID=", EstimateItemID, ","));
            string[] strArrays = EstimateBasePage.Paper_Calculation(this.CompanyID, Convert.ToInt32(PaperID)).Split(new char[] { '±' });
            string empty = string.Empty;
            string str = "0";
            string str1 = "0";
            string str2 = "0";
            if (PressType != 'D')
            {
                str = strArrays[2].ToString();
                DataTable dataTable = EstimateBasePage.Estimate_Large_Format_Press_Charge_Select(this.CompanyID, PressID);
                string empty1 = string.Empty;
                decimal num = new decimal(0);
                foreach (DataRow row in dataTable.Rows)
                {
                    str1 = row["MarkUp"].ToString();
                    string[] strArrays1 = new string[] { " PressMarkUp=", row["MarkUp"].ToString(), ",PressSetupCharge=", row["SetupCharge"].ToString(), ",PressMinimumRunningCharge=", row["MinimumCharge"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays1));
                    stringBuilder.Append(" PressType='L',");
                    stringBuilder.Append(string.Concat(" HourlyCharge=", row["PerHourCharge"].ToString(), ","));
                    string[] strArrays2 = new string[] { " PrintPerHourLow=", row["PrintPerHourLow"].ToString(), ",PrintPerHourMedium=", row["PrintPerHourMedium"].ToString(), ",PrintPerHourHigh=", row["PrintPerHourHigh"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays2));
                    empty1 = row["InkValues"].ToString();
                    num = Convert.ToDecimal(row["InkMarkup"]);
                }
                DataTable dataTable1 = EstimateBasePage.Estimate_Guillotine_Select_By_ID(this.CompanyID, GuillotineID);
                if (dataTable1.Rows.Count <= 0)
                {
                    stringBuilder.Append(" GuillotineSetupCharge=0,GuillotineMinimumRunningCharge=0, ");
                    stringBuilder.Append(" GuillotineCostPerCut=0,GuillotinePaperWeight1=0,GuillotineMaximumThroat1=0, ");
                    stringBuilder.Append(" GuillotinePaperWeight2=0,GuillotineMaximumThroat2=0,GuillotinePaperWeight3=0, ");
                    stringBuilder.Append(" GuillotineMaximumThroat3=0, ");
                }
                else
                {
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        str2 = dataRow["MarkUp"].ToString();
                        string[] str3 = new string[] { " GuillotineSetupCharge=", dataRow["SetUpCharge"].ToString(), ",GuillotineMinimumRunningCharge=", dataRow["MinCharge"].ToString(), ",GuillotineMarkUp=", dataRow["MarkUp"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str3));
                        string[] strArrays3 = new string[] { " GuillotineCostPerCut=", dataRow["CostPerCut"].ToString(), ",GuillotinePaperWeight1=", dataRow["PaperWeight1"].ToString(), ",GuillotineMaximumThroat1=", dataRow["MaxSheets1"].ToString(), "," };
                        stringBuilder.Append(string.Concat(strArrays3));
                        string[] str4 = new string[] { " GuillotinePaperWeight2=", dataRow["PaperWeight2"].ToString(), ",GuillotineMaximumThroat2=", dataRow["MaxSheets2"].ToString(), ",GuillotinePaperWeight3=", dataRow["PaperWeight3"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str4));
                        stringBuilder.Append(string.Concat(" GuillotineMaximumThroat3=", dataRow["MaxSheets3"].ToString(), ","));
                    }
                }
                object[] objArray = new object[] { " OneSqCmInkCost='", empty1, "', InkMarkup=", num, " " };
                stringBuilder.Append(string.Concat(objArray));
                if (Convert.ToInt64(PaperID) != Convert.ToInt64(this.hdnOldPaperID.Value))
                {
                    if (!IsPaperUnitPriceLocked)
                    {
                        string[] strArrays4 = new string[] { ", PaperUnitPrice=", strArrays[0], ",PaperWeight=", strArrays[1], ",PaperPackedInQty=", strArrays[3], " " };
                        stringBuilder.Append(string.Concat(strArrays4));
                    }
                    else
                    {
                        string[] strArrays5 = new string[] { ",PaperWeight=", strArrays[1], ",PaperPackedInQty=", strArrays[3], " " };
                        stringBuilder.Append(string.Concat(strArrays5));
                    }
                    string[] strArrays6 = new string[] { ", PaperMarkup=", str, ", PaperMarkup2=", str, ", PaperMarkup3=", str, ", PaperMarkup4=", str, " " };
                    stringBuilder.Append(string.Concat(strArrays6));
                }
                if (Convert.ToInt64(PressID) != Convert.ToInt64(this.hdnOldPressID.Value))
                {
                    string[] strArrays7 = new string[] { ", PressMarkup=", str1, ", PressMarkup2=", str1, ", PressMarkup3=", str1, ", PressMarkup4=", str1, " " };
                    stringBuilder.Append(string.Concat(strArrays7));
                }
                if (Convert.ToInt64(GuillotineID) != Convert.ToInt64(this.hdnOldGuillotineID.Value))
                {
                    string[] strArrays8 = new string[] { ",   GuillotineMarkUp=", str2, ", GuillotineMarkUp2=", str2, ", GuillotineMarkUp3=", str2, ", GuillotineMarkUp4=", str2, " " };
                    stringBuilder.Append(string.Concat(strArrays8));
                }
                stringBuilder.Append(string.Concat(" Where EstCalculationID=", this.EstimateCalculationID));
                stringBuilder.Append(string.Concat(" select ", this.EstimateCalculationID));
                EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            }
            else
            {
                str = strArrays[2].ToString();
                foreach (DataRow row1 in EstimateBasePage.Estimate_Digital_Press_Select(this.CompanyID, PressID).Rows)
                {
                    str1 = row1["MarkUp"].ToString();
                    string[] str5 = new string[] { "PressSetupCharge=", row1["SetupCharge"].ToString(), ",PressMinimumRunningCharge=", row1["MinimumCharge"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str5));
                    if (row1["MethodName"].ToString() == "ClickChargeLookup")
                    {
                        stringBuilder.Append("PressType='C',");
                        string[] str6 = new string[] { " BlackChargeableRate=", row1["BlackChargeableSheets"].ToString(), ",ColorChargeableRate=", row1["ColorChargeableSheets"].ToString(), ",NoOfChargeableSheets=", row1["ChargeableSheets"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str6));
                        stringBuilder.Append(" HourlyCharge=0, ");
                        stringBuilder.Append(" PrintPerHourLow=0,PrintPerHourMedium=0,PrintPerHourHigh=0, ");
                    }
                    else if (row1["MethodName"].ToString() != "SpeedWeightLookup")
                    {
                        if (row1["MethodName"].ToString() != "ClickChargeZoneLookup")
                        {
                            continue;
                        }
                        empty = "ClickChargeZoneLookup";
                        stringBuilder.Append(" PressType='Z',");
                        stringBuilder.Append(" BlackChargeableRate=0,ColorChargeableRate=0,NoOfChargeableSheets=0,");
                        stringBuilder.Append(" HourlyCharge=0, ");
                        stringBuilder.Append(" PrintPerHourLow=0,PrintPerHourMedium=0,PrintPerHourHigh=0, ");
                    }
                    else
                    {
                        empty = "SpeedWeightLookup";
                        stringBuilder.Append("PressType='S',");
                        stringBuilder.Append("BlackChargeableRate=0,ColorChargeableRate=0,NoOfChargeableSheets=0,");
                        stringBuilder.Append(string.Concat(" HourlyCharge=", row1["HourlyCharge"].ToString(), ", "));
                        stringBuilder.Append(" PrintPerHourLow=0, PrintPerHourMedium=0, PrintPerHourHigh=0, ");
                    }
                }
                DataTable dataTable2 = EstimateBasePage.Estimate_Guillotine_Select_By_ID(this.CompanyID, GuillotineID);
                if (dataTable2.Rows.Count <= 0)
                {
                    stringBuilder.Append(" GuillotineSetupCharge=0,GuillotineMinimumRunningCharge=0, ");
                    stringBuilder.Append(" GuillotineCostPerCut=0,GuillotinePaperWeight1=0,GuillotineMaximumThroat1=0, ");
                    stringBuilder.Append(" GuillotinePaperWeight2=0,GuillotineMaximumThroat2=0,GuillotinePaperWeight3=0, ");
                    stringBuilder.Append(" GuillotineMaximumThroat3=0 ");
                }
                else
                {
                    foreach (DataRow dataRow1 in dataTable2.Rows)
                    {
                        str2 = dataRow1["MarkUp"].ToString();
                        string[] str7 = new string[] { " GuillotineSetupCharge=", dataRow1["SetUpCharge"].ToString(), ",GuillotineMinimumRunningCharge=", dataRow1["MinCharge"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str7));
                        string[] str8 = new string[] { " GuillotineCostPerCut=", dataRow1["CostPerCut"].ToString(), ",GuillotinePaperWeight1=", dataRow1["PaperWeight1"].ToString(), ",GuillotineMaximumThroat1=", dataRow1["MaxSheets1"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str8));
                        string[] str9 = new string[] { " GuillotinePaperWeight2=", dataRow1["PaperWeight2"].ToString(), ",GuillotineMaximumThroat2=", dataRow1["MaxSheets2"].ToString(), ",GuillotinePaperWeight3=", dataRow1["PaperWeight3"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str9));
                        stringBuilder.Append(string.Concat(" GuillotineMaximumThroat3=", dataRow1["MaxSheets3"].ToString(), " "));
                    }
                }
                if (Convert.ToInt64(PaperID) != Convert.ToInt64(this.hdnOldPaperID.Value))
                {
                    string[] strArrays9 = new string[] { ",PaperWeight=", strArrays[1], ",PaperPackedInQty=", strArrays[3], " " };
                    stringBuilder.Append(string.Concat(strArrays9));
                    string[] strArrays10 = new string[] { ", PaperMarkup=", str, ", PaperMarkup2=", str, ", PaperMarkup3=", str, ", PaperMarkup4=", str, " " };
                    stringBuilder.Append(string.Concat(strArrays10));
                }
                if (Convert.ToInt64(PaperID) != Convert.ToInt64(this.hdnOldPaperID.Value) || (Convert.ToInt64(PaperID) == Convert.ToInt64(this.hdnOldPaperID.Value)))
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
                    string[] strArrays11 = new string[] { ", PressMarkup=", str1, ", PressMarkup2=", str1, ", PressMarkup3=", str1, ", PressMarkup4=", str1, " " };
                    stringBuilder.Append(string.Concat(strArrays11));
                }
                if (Convert.ToInt64(GuillotineID) != Convert.ToInt64(this.hdnOldGuillotineID.Value))
                {
                    string[] strArrays12 = new string[] { ",   GuillotineMarkUp=", str2, ", GuillotineMarkUp2=", str2, ", GuillotineMarkUp3=", str2, ", GuillotineMarkUp4=", str2, " " };
                    stringBuilder.Append(string.Concat(strArrays12));
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
                if (empty == "ClickChargeZoneLookup")
                {
                    EstimatesBasePage.estimate_click_charge_zone_insert(this.CompanyID, this.EstimateCalculationID, PressID);
                    return;
                }
                if (string.Compare(empty, "SpeedWeightLookup", true) == 0)
                {
                    EstimatesBasePage.estimate_speed_weight_insert(this.CompanyID, this.EstimateCalculationID, PressID);
                    return;
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
                string str = "S";
                string empty = string.Empty;
                string empty1 = string.Empty;
                empty = "Sheet Fed Digital Single Item";
                foreach (DataRow row in Notes.select_item_Title_for_Activity_History(CompanyID, ModuleID, EstimateItemID, str).Rows)
                {
                    empty1 = row["itemtitle"].ToString();
                }
                if (base.Request.Params["FromAddAnItem"] != null || base.Request.Params["FrmAddAnItem"] == "Y")
                {
                    string str1 = string.Empty;
                    foreach (DataRow dataRow in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                    {
                        str1 = dataRow["rownumber"].ToString();
                    }
                    if (this.modulename == "estimates")
                    {
                        this.objnotes.Item_title = empty1;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", str1);
                        this.objnotes.Estimate_type = empty;
                    }
                    else if (this.modulename == "jobs")
                    {
                        this.objnotes.Item_title = empty1;
                        this.objnotes.ModuleName = "job";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", str1);
                        this.objnotes.Job_type = empty;
                    }
                    else if (this.modulename == "invoice")
                    {
                        this.objnotes.Item_title = empty1;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", str1);
                        this.objnotes.Invoice_type = empty;
                    }
                    if (this.modulename == "orders")
                    {
                        this.objnotes.Item_title = empty1;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                        this.objnotes.Item_number = string.Concat(" ", str1);
                        this.objnotes.Estimate_type = empty;
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
                    this.objnotes.Estimate_type = empty;
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
                    this.objnotes.Job_type = empty;
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
                    this.objnotes.Invoice_type = empty;
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
                    this.objnotes.Estimate_type = empty;
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
            if (base.Request.Params["maintype"] != null && base.Request.Params["maintype"].ToString() == "edit")
            {
                string str2 = "S";
                string str3 = "Sheet Fed Digital Single Item";
                string empty3 = string.Empty;
                if (this.modulename == "estimates")
                {
                    if (str2.ToLower() != "s")
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
                    this.objnotes.Estimate_type = str3;
                    this.objnotes.Item_number = empty3;
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
                    this.objnotes.Item_number = empty3;
                    this.objnotes.Estimate_type = str3;
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
                    if (str2.ToLower() != "s")
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
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.Estimate_type = str3;
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

        public void Main_Quantity_Insert(long EstimateItemID_TempID, string para, EstimatesItem Estitem)
        {
            Calculations calculation = new Calculations();
            string str = "S";
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
            decimal[] numArray18 = new decimal[4];
            decimal[] numArray19 = new decimal[4];


            DataTable dataTable = EstimatesBasePage.estimate_single_item_select(this.CompanyID, EstimateItemID_TempID);
            DataRow item = dataTable.Rows[0];
            for (int i = 1; i <= 4; i++)
            {
                int num16 = 0;
                if (i != 1)
                {
                    TextBox textBox = (TextBox)this.FindControl(string.Concat("txtQuantity_", i));
                    num16 = (textBox.Text != "" ? Convert.ToInt32(textBox.Text) : 0);
                }
                else if (this.txtQuantity.Text != "")
                {
                    num16 = Convert.ToInt32(this.txtQuantity.Text);
                }
                if (num16 <= 0)
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
                    num8[i - 1] = new decimal(0);
                    numArray8[i - 1] = new decimal(0);
                    num9[i - 1] = new decimal(0);
                    numArray9[i - 1] = new decimal(0);
                    num10[i - 1] = new decimal(0);
                    numArray10[i - 1] = new decimal(0);
                    num11[i - 1] = new decimal(0);
                    numArray11[i - 1] = new decimal(0);
                    num12[i - 1] = new decimal(0);
                    numArray12[i - 1] = new decimal(0);
                    num13[i - 1] = new decimal(0);
                    numArray13[i - 1] = new decimal(0);
                    num14[i - 1] = new decimal(0);
                    numArray14[i - 1] = new decimal(0);
                    num15[i - 1] = new decimal(0);
                }
                else
                {
                    numArray[i - 1] = num16;
                    if (this.ProfitTaxKey.ToLower() != "database")
                    {
                        num[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
                        num1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "press", Convert.ToInt64(item["PressID"]));
                        if (Convert.ToInt64(item["GuillotineID"]) > (long)0)
                        {
                            numArray1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "guillotine", Convert.ToInt64(item["GuillotineID"]));
                        }
                    }
                    else
                    {
                        num[0] = Convert.ToDecimal(item["PaperMarkup"]);
                        num[1] = Convert.ToDecimal(item["PaperMarkup2"]);
                        num[2] = Convert.ToDecimal(item["PaperMarkup3"]);
                        num[3] = Convert.ToDecimal(item["PaperMarkup4"]);
                        num1[0] = Convert.ToDecimal(item["PressMarkUp"]);
                        num1[1] = Convert.ToDecimal(item["PressMarkUp2"]);
                        num1[2] = Convert.ToDecimal(item["PressMarkUp3"]);
                        num1[3] = Convert.ToDecimal(item["PressMarkUp4"]);
                        numArray1[0] = Convert.ToDecimal(item["GuillotineMarkUp"]);
                        numArray1[1] = Convert.ToDecimal(item["GuillotineMarkUp2"]);
                        numArray1[2] = Convert.ToDecimal(item["GuillotineMarkUp3"]);
                        numArray1[3] = Convert.ToDecimal(item["GuillotineMarkUp4"]);
                    }
                    decimal num17 = new decimal(0);
                    decimal FullSheetArea = new decimal(0);
                    num3[i - 1] = calculation.PaperCalculation(this.CompanyID, str, num16, num[i - 1], item, ref num2[i - 1], ref numArray2[i - 1], ref numArray3[i - 1], ref num4[i - 1], ref num17, ref FullSheetArea);
                    numArray5[i - 1] = calculation.PressCalculation(this.CompanyID, str, num16, num1[i - 1], item, num4[i - 1], ref numArray4[i - 1], ref num5[i - 1], num17, ref numArray9[i - 1], ref num10[i - 1], ref numArray10[i - 1], ref num11[i - 1], ref numArray11[i - 1], ref num12[i - 1], ref numArray12[i - 1], ref num13[i - 1], ref numArray13[i - 1], ref num14[i - 1], ref numArray14[i - 1], i, ref numArray18[i - 1], ref numArray19[i - 1]);

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
                        string type = Request.Form["hdntype"];


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
                        num9[i - 1] = result;
                    }

                    num6[i - 1] = calculation.GuillotineCalculation(this.CompanyID, str, num16, numArray1[i - 1], item, num4[i - 1], ref numArray6[i - 1], ref num7[i - 1], ref numArray7[i - 1], ref num8[i - 1], ref numArray8[i - 1], ref num9[i - 1], num17, ref num15[i - 1], GuillotineType);
                }
            }
           
            
            EstimatesBasePage.quantity_insert_new(this.CompanyID, EstimateItemID_TempID, numArray[0], numArray3[0], num4[0], num2[0], numArray2[0], numArray4[0], num5[0], numArray7[0], num8[0], numArray8[0], num9[0], numArray6[0], num7[0], numArray[1], numArray3[1], num4[1], num2[1], numArray2[1], numArray4[1], num5[1], numArray7[1], num8[1], numArray8[1], num9[1], numArray6[1], num7[1], numArray[2], numArray3[2], num4[2], num2[2], numArray2[2], numArray4[2], num5[2], numArray7[2], num8[2], numArray8[2], num9[2], numArray6[2], num7[2], numArray[3], numArray3[3], num4[3], num2[3], numArray2[3], numArray4[3], num5[3], numArray7[3], num8[3], numArray8[3], num9[3], numArray6[3], num7[3], para, (long)0, numArray9[0], numArray9[1], numArray9[2], numArray9[3], num10[0], num10[1], num10[2], num10[3], numArray10[0], numArray10[1], numArray10[2], numArray10[3], num11[0], num11[1], num11[2], num11[3], numArray11[0], numArray11[1], numArray11[2], numArray11[3], num12[0], num12[1], num12[2], num12[3], numArray12[0], numArray12[1], numArray12[2], numArray12[3], num13[0], num13[1], num13[2], num13[3], numArray13[0], numArray13[1], numArray13[2], numArray13[3], num14[0], num14[1], num14[2], num14[3], numArray14[0], numArray14[1], numArray14[2], numArray14[3], num15[0], num15[1], num15[2], num15[3], numArray18[0], numArray18[1], numArray18[2], numArray18[3], numArray19[0], numArray19[1], numArray19[2], numArray19[3]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            this.ChkPriceForWholePack.Text = this.objLanguage.GetLanguageConversion("Price_For_Whole_Pack");
            this.ChkPaperSupplied.Text = this.objLanguage.GetLanguageConversion("Paper_Supplied");
            this.chkDoubleSided.Text = this.objLanguage.GetLanguageConversion("Double_Sided");
            this.btnPrevious.Text = this.objLanguage.GetLanguageConversion("Previous");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Finish");
            this.chkPortrait.Text = this.objLanguage.GetLanguageConversion("Portrait");
            this.chkLandscape.Text = this.objLanguage.GetLanguageConversion("LandScape");
            this.chkPrintSheet.Text = this.objLanguage.GetLanguageConversion("Custom");
            this.ChkJobFlatCustom.Text = this.objLanguage.GetLanguageConversion("Custom");
            this.chkFirstTrim.Text = this.objLanguage.GetLanguageConversion("First_Trim");
            this.chkSecondTrim.Text = this.objLanguage.GetLanguageConversion("Second_Trim");
            this.rerunOverwrite.Title = this.objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate");
            string empty = string.Empty;
            empty = baseClass.ReturnRoles_Privileges_ForGrid("estimates", "others", this.Page.Request.Url.ToString());
            if (empty == "0" || empty == "2")
            {
                this.ImgPlus.Visible = false;
            }
            else
            {
                this.ImgPlus.Visible = true;
            }
            if (!base.IsPostBack)
            {
                this.Label1.Text = this.objLanguage.GetLanguageConversion("Update_Item_Description");
            }
            if (ConnectionClass.ProfitTaxKey != null)
            {
                this.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
            }
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
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
            global.pgName = string.Empty;
            this.section = base.BaseSection;
            this.txtItemTitle.Focus();

            foreach (DataRow dataRow in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                this.hid_3DecimalPaperSize.Value = dataRow["Decimal3ForPaperSizes"] != DBNull.Value
                                   ? dataRow["Decimal3ForPaperSizes"].ToString() : "False";
            }

            if (base.Request.Params["maintype"] != null)
            {
                this.MainType = base.Request.Params["maintype"];
            }
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.txtQuantity.Attributes.Add("style", "text-align:right");
            this.txtQuantity_2.Attributes.Add("style", "text-align:right");
            this.txtRunOnQty.Attributes.Add("style", "text-align:right");
            this.txtQuantity_3.Attributes.Add("style", "text-align:right");
            this.txtQuantity_4.Attributes.Add("style", "text-align:right");
            this.txtSetupSpoilage.Attributes.Add("style", "text-align:right");
            this.txtRunningSpoilage.Attributes.Add("style", "text-align:right");
            this.txtportrait.Attributes.Add("style", "text-align:right");
            this.txtlandscape.Attributes.Add("style", "text-align:right");
            this.Label11.Text = this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour");
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.ddlColors.Items[0].Text = this.Label11.Text;
            this.ddlColors.Items[1].Text = this.objLanguage.GetLanguageConversion("Black_White");
            this.ddlColors_2.Items[0].Text = this.Label11.Text;
            this.ddlColors_2.Items[1].Text = this.objLanguage.GetLanguageConversion("Black_White");
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
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
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
                this.txtQuantity.Attributes.Add("onblur", "AllowNumber(this,this.value);validatethis(this.value)");
                this.txtRunOnQty.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtQuantity_2.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtQuantity_3.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtQuantity_4.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtSetupSpoilage.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtRunningSpoilage.Attributes.Add("onblur", "AllowNumber(this,this.value);todecimal_function(this,this.value);");
                this.txtNoOfPagesRequired.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtPagesPerSection.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                if(this.hid_3DecimalPaperSize.Value.ToLower() == "true")
                {
                    this.txtsectionheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_functionNew(this,this.value,3);");
                    this.txtsectionwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_functionNew(this,this.value,3);");
                    this.txtitemheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');todecimal_functionNew(this,this.value,3);");
                    this.txtitemwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');todecimal_functionNew(this,this.value,3);");
                }
                else
                {
                    this.txtsectionheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                    this.txtsectionwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();todecimal_function(this,this.value);");
                    this.txtitemheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');todecimal_function(this,this.value);");
                    this.txtitemwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');todecimal_function(this,this.value);");
                }

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
                this.ddlJobItemSize.Items.Insert(0, "--- Select ---");
                this.ddlJobItemSize.Items[0].Text = string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---");
                this.ddlJobItemSize.Items[0].Value = "0";
                this.hid_ddlPrintSheetSize.Value = dataSet.Tables[1].Rows[0][0].ToString();
                this.hid_ddlPrintSheetSize.Value.Split(new char[] { 'µ' });
                this.hid_DigitalPress.Value = dataSet.Tables[2].Rows[0][0].ToString();
                this.hid_DefaultDigitalPress.Value = dataSet.Tables[3].Rows[0][0].ToString();
                if (!base.IsPostBack)
                {
                    if (string.Compare(this.QueryType, "add", true) == 0)
                    {
                        if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                        {
                            long parentEstimateItemID = this.ParentEstimateItemID;
                            if (parentEstimateItemID == (long)0)
                            {
                                parentEstimateItemID = this.EstimateItemID;
                            }
                            foreach (DataRow row in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, parentEstimateItemID).Rows)
                            {
                                this.QtyNo = Convert.ToInt16(row["QtyNumber"].ToString());
                            }
                        }
                        if (string.Compare(this.modulename, "orders", true) == 0)
                        {
                            this.QtyNo = 1;
                        }
                        foreach (DataRow dataRow in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                        {
                            this.ChkPriceForWholePack.Checked = Convert.ToBoolean(dataRow["DefaultPriceForWholePack"]);
                        }
                        foreach (DataRow row1 in EstimatesBasePage.CopyesttitletoitemTitle(this.CompanyID, this.EstimateID).Rows)
                        {
                            this.txtItemTitle.Text = this.objBase.SpecialDecode(row1["EstimateTitle"].ToString());
                        }
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
            }
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                this.Select_Pads_Item(this.ParentEstimateItemID, this.ParentEstimateType);
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
            }
            try
            {
                if (base.Request.QueryString["subedit"] != null)
                {
                    this.subedit = "S";
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

        private void Select_Pads_Item(long ParentItemID, string ParentItemType)
        {
            string str = "more";
            if (!base.IsPostBack)
            {
                DataTable dataTable = EstimatesBasePage.estimate_qty_select(this.CompanyID, this.EstimateItemID, (long)0);
                foreach (DataRow row in dataTable.Rows)
                {
                    int num = Convert.ToInt32(row["Qty1"]);
                    int num1 = Convert.ToInt32(row["Qty2"]);
                    int num2 = Convert.ToInt32(row["Qty3"]);
                    int num3 = Convert.ToInt32(row["Qty4"]);
                    this.subtotal1 = Convert.ToDouble(row["subtotal1"]);
                    this.subtotal2 = Convert.ToDouble(row["subtotal2"]);
                    this.subtotal3 = Convert.ToDouble(row["subtotal3"]);
                    this.subtotal4 = Convert.ToDouble(row["subtotal4"]);
                    if (num != 0)
                    {
                        this.txtQuantity.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num.ToString()), 0, "", true, false, false);
                    }
                    if (num1 != 0)
                    {
                        this.txtQuantity_2.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num1.ToString()), 0, "", true, false, false);
                        str = "more";
                    }
                    if (num2 != 0)
                    {
                        this.txtQuantity_3.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num2.ToString()), 0, "", true, false, false);
                        str = "more";
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    this.txtQuantity_4.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num3.ToString()), 0, "", true, false, false);
                    str = "more";
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    if (ParentItemID == (long)0)
                    {
                        ParentItemID = this.EstimateItemID;
                    }
                    foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, ParentItemID).Rows)
                    {
                        this.QtyNo = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                    }
                }
                if (string.Compare(this.modulename, "orders", true) == 0)
                {
                    this.QtyNo = 1;
                }
            }
            DataTable dataTable1 = EstimatesBasePage.single_item_select(this.CompanyID, this.EstimateItemID);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row1 in dataTable1.Rows)
            {
                this.EstimateSingleItemID = Convert.ToInt64(row1["EstimateSingleItemID"]);
                this.EstimateCalculationID = Convert.ToInt64(row1["EstimateCalculationID"]);
                this.TypeID = this.EstimateSingleItemID;
                this.hid_height.Value = row1["Height"].ToString();
                this.hid_width.Value = row1["Width"].ToString();
                this.hid_IsSheetCustom.Value = row1["IsSheetCustom"].ToString();
                this.hid_IsJobCustom.Value = row1["IsJobCustom"].ToString();
                stringBuilder.Append("EstimateType»digital±");
                stringBuilder.Append("ProductType»singleitem±");
                stringBuilder.AppendFormat("QtyType»{0}±", str);
                stringBuilder.AppendFormat("Press»{0}»{1}±", row1["PressID"].ToString(), "D");
                object[] objArray = new object[] { row1["PaperID"].ToString(), row1["PaperName"].ToString(), row1["IsPricePerPack"].ToString(), row1["IsPaperSupplied"].ToString() };
                stringBuilder.AppendFormat("Paper»{0}»{1}»{2}»{3}±", objArray);
                decimal num4 = Convert.ToDecimal(row1["SetupSpoilage"]);
                stringBuilder.AppendFormat("SetupSpoilage»{0}±", num4.ToString());
                decimal num5 = Convert.ToDecimal(row1["RunningSpoilage"]);
                stringBuilder.AppendFormat("RunningSpoilage»{0}±", num5.ToString());
                stringBuilder.AppendFormat("Colour»{0}»{1}±", row1["Colour"].ToString(), row1["IsDoubleSided"].ToString());
                object[] str1 = new object[] { row1["PrintSheetSizeID"].ToString(), row1["IsSheetCustom"].ToString(), row1["SheetHeight"].ToString(), row1["SheetWidth"].ToString() };
                stringBuilder.AppendFormat("SheetSize»{0}»{1}»{2}»{3}±", str1);
                object[] objArray1 = new object[] { row1["JobFlatSizeID"].ToString(), row1["IsJobCustom"].ToString(), row1["JobHeight"].ToString(), row1["JobWidth"].ToString() };
                stringBuilder.AppendFormat("ItemSize»{0}»{1}»{2}»{3}±", objArray1);
                stringBuilder.AppendFormat("Gutters»{0}»{1}»{2}±", row1["IsIncludeGutters"].ToString(), row1["GutterHorizontal"].ToString(), row1["GutterVertical"].ToString());
                stringBuilder.AppendFormat("PressRestrictions»{0}±", row1["IsPressRestrictions"].ToString());
                stringBuilder.AppendFormat("PrintLayout»{0}»{1}»{2}»{3}±", row1["PrintLayout"].ToString(), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["PortraitValue"].ToString()), 0, "", true, false, false), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["LandscapeValue"].ToString()), 0, "", true, false, false), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["ManualValue"].ToString()), 0, "", true, false, false));
                stringBuilder.AppendFormat("Guillotine»{0}»{1}±", row1["GuillotineID"].ToString(), row1["GuillotineName"].ToString());
                stringBuilder.AppendFormat("IsFirstTrim»{0}±", row1["IsFirstTrim"].ToString());
                stringBuilder.AppendFormat("IsSecondTrim»{0}±", row1["IsSecondTrim"].ToString());
                stringBuilder.AppendFormat("IsAnyOutwork»{0}±", row1["IsAnyOutwork"].ToString());
                stringBuilder.AppendFormat("IsAnyWarehouse»{0}±", row1["IsAnyWarehouseItem"].ToString());
                stringBuilder.AppendFormat("IsAnyOtherCost»{0}±", row1["IsAnyOtherCost"].ToString());
                stringBuilder.AppendFormat("SideColor»{0}±", row1["SideColor"].ToString());
                this.SingleItemPrintLayout = row1["PrintLayout"].ToString();
                if (!base.IsPostBack)
                {
                    this.txtItemTitle.Text = this.objBase.SpecialDecode(row1["ItemTitle"].ToString());
                    this.hdnOldPressID.Value = row1["PressID"].ToString();
                    this.hdnOldPaperID.Value = row1["PaperID"].ToString();
                    this.hdnOldGuillotineID.Value = row1["GuillotineID"].ToString();
                }
                this.hdn_InvpaperID.Value = row1["PaperID"].ToString();
                this.IsPaperUnitPriceLocked = Convert.ToBoolean(row1["IsPaperUnitPriceLocked"].ToString());
            }
            this.hid_singleData.Value = stringBuilder.ToString();
            this.pnlPadEdit.Visible = true;
        }

        private void Update_Single_Item()
        {
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            HttpContext.Current.Session[string.Concat("ZoneMarkupCalcDetails", this.EstimateItemID.ToString())] = null;
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
                        else if (strArrays2[0].Trim() == "ManualValue")
                        {
                            estimatesItem.ManualValue = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "GuilotineID")
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
            if (this.EstimateItemID != (long)0 && this.EstimateSingleItemID != (long)0)
            {
                string str = "S";
                estimatesItem.ItemTitle = this.Objclss.SpecialEncode(this.txtItemTitle.Text);
                estimatesItem.EstimateSingleItemID = this.EstimateSingleItemID;
                estimatesItem.ItemDescription = "";
                if ((string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0) && this.hdn_invStockBack.Value.ToLower() == "yes")
                {
                    this.summryCls.Call_Inventory_Adjustment("cancelled", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                }
                EstimatesBasePage.single_item_insert(estimatesItem);
                this.Estimate_Calcukation_Update(this.EstimateItemID, (long)0, estimatesItem.PaperID, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, str, this.IsPaperUnitPriceLocked);
                this.Main_Quantity_Insert(this.EstimateItemID, "updateqty", estimatesItem);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
                if (this.Chk_ItemDescn.Checked)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "S", true);
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
                    DataTable dataTable = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "S");
                    if (dataTable.Rows.Count > 0)
                    {
                        dataTable.Rows[0]["PricecatalogueID"].ToString();
                        if (num == 1 || num == 2)
                        {
                            EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "S", num);
                        }
                    }
                }
                this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "S");
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
            if (this.ParentEstimateItemID == (long)0)
            {
                EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "S");
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
                if (empty.ToString().ToLower() == "yes")
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
            if (empty.ToString().ToLower() == "yes")
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