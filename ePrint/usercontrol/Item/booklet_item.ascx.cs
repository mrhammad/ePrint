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
    public partial class booklet_item : UsercontrolBasePage
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

        //protected Label lblBookletType;

        //protected DropDownList ddlBookletType;

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

        //protected Label lblbookletformat;

        //protected DropDownList ddlBookletFormat;

        //protected Label Label2;

        //protected TextBox txtFlatbookletitemsizeHeight;

        //protected TextBox txtFlatbookletitemsizeWidth;

        //protected Label Label24;

        //protected TextBox txtGutterHorizontal;

        //protected TextBox txtGutterVertical;

        //protected CheckBox chkGutters;

        //protected Label Label25;

        //protected CheckBox ChkPressRestrictions;

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

        //protected Label Label19;

        //protected TextBox txtPagesPerSignature;

        //protected Label Label27;

        //protected TextBox txtNoOfSignatures;

        //protected CheckBox chkIsSilling;

        //protected Label Label26;

        //protected Label lblGuillotine;

        //protected CheckBox chkFirstTrim;

        //protected CheckBox chkSecondTrim;

        //protected HiddenField hid_GuillotineID;

        //protected Label Label1;

        //protected HtmlImage Img_ItemDescnHelp;

        //protected HtmlAnchor img_Description;

        //protected CheckBox Chk_ItemDescn;

        //protected HtmlGenericControl Div_ItemDescn;

        //protected Label Label17;

        //protected HtmlImage Img1;

        //protected CheckBox chkPoduct1;

        //protected CheckBox chkPoduct2;

        //protected HtmlGenericControl Div_Productcatalogue;

        //protected Button btnStage2_Previous;

        //protected Button Button14;

        //protected Button Button16;

        //protected HiddenField hid_DeletedID;

        //protected UpdatePanel UpBookletDelete;

        //protected Button btnSave;

        //protected Button btnStage4_Next;

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

        //protected HiddenField hdn_invStockReduce;

        //protected HiddenField hdn_invStockBack;

        //protected HiddenField hdn_IsPaperUnitPriceLocked;

        //protected HiddenField hid_bookletData;

        //protected Panel pnlBookletEdit;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        public languageClass objLanguage = new languageClass();

        private notesclass objnotes = new notesclass();

        private commonClass commclass = new commonClass();

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

        private string strEstSectionIDs = string.Empty;

        public long TypeID;

        public long EstOtherCostID;

        public string OtherCostValuesFromTB = string.Empty;

        public string EstType = string.Empty;

        private long InvoiceNum;

        public long EstNo;

        private string CatalogueProfitAndTax = string.Empty;

        public long PressID;

        public string PaperMeasure = string.Empty;

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        private commonClass objcomm = new commonClass();

        private SummaryClass summryCls = new SummaryClass();

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public string modulename = "estimates";

        public string submodulename = "estimate";

        private string ItemDescription_0 = string.Empty;

        public string FromItemDescription = string.Empty;

        public string frmcopyitem = string.Empty;

        public int QtyNo;

        public string MainType = string.Empty;

        private string Estimatebookletitemid_old = string.Empty;

        private string Estimatebookletitemid_new = string.Empty;

        public string ProfitTaxKey = string.Empty;

        public long ParentEstimateItemID;

        public long EstimateBookletItemID;

        private commonClass objJava = new commonClass();

        public int IsItemCompleted;

        public int IsProductCreated;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string Booklet_Pages_Per_Print_Sheet_Cannot_Be_Zero = string.Empty;

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

        public booklet_item()
        {
        }

        protected void btn_Delete(object sender, EventArgs e)
        {
            long num = (long)0;
            try
            {
                num = Convert.ToInt64(this.hid_DeletedID.Value);
            }
            catch
            {
                num = (long)0;
            }
            if (num != (long)0)
            {
                EstimatesBasePage.booklet_delete(this.CompanyID, num, "B");
            }
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
                else if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                {
                    if (empty.ToString().ToLower() != "yes")
                    {
                        HttpResponse response1 = base.Response;
                        object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID1));
                    }
                    else
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray1));
                    }
                }
                else if (this.ParentEstimateItemID != (long)0)
                {
                    if (empty.ToString().ToLower() != "yes")
                    {
                        HttpResponse response2 = base.Response;
                        object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, this.jID, this.InvID };
                        response2.Redirect(string.Concat(estimateID2));
                    }
                    else
                    {
                        HttpResponse httpResponse2 = base.Response;
                        object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, this.jID, this.InvID };
                        httpResponse2.Redirect(string.Concat(objArray2));
                    }
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
                HttpResponse response3 = base.Response;
                object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=B&maintype=", this.MainType, this.jID, this.InvID };
                response3.Redirect(string.Concat(estimateID3));
            }
            else
            {
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    HttpResponse httpResponse3 = base.Response;
                    object[] objArray3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                    httpResponse3.Redirect(string.Concat(objArray3));
                    return;
                }
                if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                {
                    HttpResponse response4 = base.Response;
                    object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                    response4.Redirect(string.Concat(estimateID4));
                    return;
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse httpResponse4 = base.Response;
                    object[] objArray4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, this.jID, this.InvID };
                    httpResponse4.Redirect(string.Concat(objArray4));
                    return;
                }
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (string.Compare(this.QueryType, "add", true) == 0 || this.frmcopyitem == "yes")
            {
                this.Click_Add();
            }
            else if (string.Compare(this.QueryType, "edit", true) == 0 && this.frmcopyitem != "yes")
            {
                this.Update_Booklet_Item();
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

        private void Click_Add()
        {
            string empty = string.Empty;
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            estimatesItem.EstimateItemID = (long)0;
            estimatesItem.EstQuantityID = (long)0;
            estimatesItem.IsAnyWarehouseItem = 'N';
            estimatesItem.IsAnyOutwork = 'N';
            estimatesItem.IsAnyOtherCost = 'N';
            empty = "B";
            long num = (long)0;
            if (this.InvoiceID <= (long)0)
            {
                long num1 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, empty, true, num);
                long num2 = num1;
                this.EstimateItemID = num1;
                estimatesItem.EstimateItemID = num2;
            }
            else
            {
                long num3 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, empty, true, num);
                long num4 = num3;
                this.EstimateItemID = num3;
                estimatesItem.EstimateItemID = num4;
            }
            EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
            if (this.jobID > (long)0)
            {
                long estimateItemID = this.EstimateItemID;
                long num5 = this.jobID;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                JobBasePage.EstimateItems_ProgressToJob(estimateItemID, num5, false, Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
            }
            if (this.InvoiceID > (long)0)
            {
                InvoiceBasePage.EstimateItems_ProgressToInvoice(this.EstimateItemID, this.InvoiceID);
            }
            HttpContext.Current.Session[string.Concat("ZoneMarkupCalcDetails", this.EstimateItemID.ToString())] = null;
            string[] strArrays = this.hid_booklet_save.Value.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (!string.IsNullOrEmpty(strArrays[i]))
                {
                    stringBuilder.Append(" declare @EstimateBookletItemID bigint; ");
                    stringBuilder.Append(" Insert into tb_EstimateBookletItem ");
                    stringBuilder.Append(" (ParentID,SectionReference,PressID,");
                    stringBuilder.Append(" PressType,PaperID,IsPricePerPack,IsPaperSupplied,");
                    stringBuilder.Append(" SetUpSpoilage,RunningSpoilage,");
                    stringBuilder.Append(" BookletType,NoOfPagesInSection,PagesPerSignature,NoOfSignatures,");
                    stringBuilder.Append(" Colour,IsDoubleSided,SideColor,");
                    stringBuilder.Append(" PrintSheetSizeID,IsSheetCustom,SheetHeight,SheetWidth,");
                    stringBuilder.Append(" JobFlatSizeID,IsJobCustom,JobHeight,JobWidth,");
                    stringBuilder.Append(" IsIncludeGutters,GutterHorizontal,GutterVertical,");
                    stringBuilder.Append(" IsPressRestrictions,NonImageHeight,NonImageWidth, GuillotineID,IsFirstTrim,IsSecondTrim,BookletFormat,isCeilPrintSheetPerSection) ");
                    stringBuilder.Append(" Values");
                    stringBuilder.Append(string.Concat("(", 0, ","));
                }
                string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                    if (strArrays2[0].Trim() == "SectionRef")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.SectionRef = strArrays2[1].Trim();
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
                    else if (strArrays2[0].Trim() == "BookletType" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.BookletType = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "NoOfPagesInSection" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.NoOfPagesInSection = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PagesPerSignature" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.PagesPerSignature = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "NoOfSignatures" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.NoOfSignatures = Convert.ToDecimal(strArrays2[1].Trim());
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
                    else if (strArrays2[0].Trim() == "NonImageHeight")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.NonImageHeight = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "NonImageWidth")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.NonImageWidth = Convert.ToDecimal(strArrays2[1].Trim());
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
                    else if (strArrays2[0].Trim() == "isCeilPrintSheetPerSection")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1].Trim(), "',"));
                        estimatesItem.isCeilPrintSheetPerSection = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "EstimateBookletItemID")
                    {
                        estimatesItem.EstimateBookletItemID = Convert.ToInt64(strArrays2[1]);
                    }
                    else if (strArrays2[0].Trim() == "BookletFormat")
                    {
                        stringBuilder.Append(string.Concat("'", strArrays2[1], "'); "));
                        estimatesItem.BookletFormat = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "QtyList")
                    {
                        estimatesItem.CreatedBy = Convert.ToInt32(base.Session["UserID"]);
                        estimatesItem.ModifiedBy = 0;
                        estimatesItem.CreatedDate = DateTime.Now;
                        estimatesItem.ModifiedDate = DateTime.Now;
                        estimatesItem.ItemTitle = this.Objclss.SpecialEncode(this.txtItemTitle.Text);
                        long num6 = EstimatesBasePage.booklet_item_insert(estimatesItem);
                        this.PressID = Convert.ToInt64(estimatesItem.PressID);
                        this.Estimate_Calcukation(this.EstimateItemID, num6, estimatesItem.PaperID, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, empty);
                        this.Main_Quantity_Insert(estimatesItem.EstimateItemID, num6, strArrays2[1].ToString(), "qty", estimatesItem);
                    }
                }
            }
            if (base.Request.Params["parentestitemid"] == null)
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, empty, false);
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, empty);
                string empty1 = string.Empty;
                foreach (DataRow row in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty1 = row["StatusID"].ToString();
                }
                if (string.Compare(this.modulename, "jobs", true) == 0 && this.ParentEstimateItemID == (long)0)
                {
                    this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty1), "job", this.EstimateItemID, (long)0);
                }
                this.summryCls.Call_Inventory_Adjustment("progressed", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    this.summryCls.Call_Inventory_Adjustment("completed", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                }
                else if (string.Compare(this.modulename, "invoice", true) == 0 && this.ReduceStockType.ToLower() == "i" || this.hdn_invStockReduce.Value.ToLower() == "yes")
                {
                    this.summryCls.Call_Inventory_Adjustment("completed-invoice", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
                }
                else if (string.Compare(this.modulename, "jobs", true) == 0 && this.ReduceStockType.ToString() == empty1.ToString())
                {
                    this.summryCls.Call_Inventory_Adjustment("completed-status", this.EstimateID, this.CompanyID, this.EstimateItemID, this.UserID);
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
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            if (this.QueryType == "add")
            {
                if (EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "B") > (long)0)
                {
                    foreach (DataRow dataRow1 in EstimatesBasePage.booklet_item_select(this.CompanyID, this.EstimateItemID).Rows)
                    {
                        this.EstBookletItemID = Convert.ToInt64(dataRow1["EstimateBookletItemID"]);
                    }
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", this.EstimateItemID, "&booksecid=", this.EstBookletItemID, " &parentesttype=B&maintype=edit&subitem=s", this.jID, this.InvID };
                    response.Redirect(string.Concat(estimateID));
                    return;
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
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        HttpResponse httpResponse = base.Response;
                        object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        httpResponse.Redirect(string.Concat(objArray));
                        return;
                    }
                    HttpResponse response1 = base.Response;
                    object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                    response1.Redirect(string.Concat(estimateID1));
                    return;
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    if (empty3.ToString().ToLower() == "yes")
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
                if (empty3.ToString().ToLower() == "yes")
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                    httpResponse2.Redirect(string.Concat(objArray2));
                    return;
                }
                HttpResponse response3 = base.Response;
                object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                response3.Redirect(string.Concat(estimateID3));
            }
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
                stringBuilder.Append(" ( EstimateItemID, EstimateBookletItemID, ");
                stringBuilder.Append(" PaperUnitPrice, PaperWeight, PaperMarkup,PaperMarkup2,PaperMarkup3,PaperMarkup4, ");
                stringBuilder.Append(" PressMarkUp,PressMarkUp2,PressMarkUp3,PressMarkUp4, PressSetupCharge, PressMinimumRunningCharge, PressType, ");
                stringBuilder.Append(" HourlyCharge, ");
                stringBuilder.Append(" PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, ");
                stringBuilder.Append(" GuillotineSetupCharge, GuillotineMinimumRunningCharge, GuillotineMarkUp,GuillotineMarkUp2,GuillotineMarkUp3,GuillotineMarkUp4, ");
                stringBuilder.Append(" GuillotineCostPerCut, GuillotinePaperWeight1, GuillotineMaximumThroat1, ");
                stringBuilder.Append(" GuillotinePaperWeight2, GuillotineMaximumThroat2, GuillotinePaperWeight3, ");
                stringBuilder.Append(" GuillotineMaximumThroat3,  ");
                stringBuilder.Append(" OneSqCmInkCost, InkMarkup,PaperPackedInQty )");
                stringBuilder.Append(" Values ");
                object[] estimateItemID = new object[] { " ( ", EstimateItemID, ", ", EstimateBookletItemID, "," };
                stringBuilder.Append(string.Concat(estimateItemID));
                string[] strArrays1 = new string[] { " ", strArrays[0], ",", strArrays[1], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], "," };
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
                string[] strArrays4 = new string[] { " ", strArrays[0], ",", strArrays[1], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], ",", strArrays[2], "," };
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

        private void Estimate_Calcukation_Update(long EstimateItemID, long EstimateBookletItemID, long PaperID, long PressID, char PressType, long GuillotineID, string EstimateType)
        {
            string[] str;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" Update [tb_EstimateCalculation] ");
            object[] estimateItemID = new object[] { " Set EstimateItemID=", EstimateItemID, ",EstimateBookletItemID=", EstimateBookletItemID, "," };
            stringBuilder.Append(string.Concat(estimateItemID));
            string[] strArrays = EstimateBasePage.Paper_Calculation(this.CompanyID, Convert.ToInt32(PaperID)).Split(new char[] { '±' });
            string empty = string.Empty;
            string str1 = "0";
            string str2 = "0";
            string str3 = "0";
            if (PressType != 'D')
            {
                DataTable dataTable = EstimateBasePage.Estimate_Large_Format_Press_Charge_Select(this.CompanyID, PressID);
                string empty1 = string.Empty;
                decimal num = new decimal(0);
                foreach (DataRow row in dataTable.Rows)
                {
                    string[] strArrays1 = new string[] { " PressSetupCharge=", row["SetupCharge"].ToString(), ",PressMinimumRunningCharge=", row["MinimumCharge"].ToString(), "," };
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
                    stringBuilder.Append(" GuillotineMaximumThroat3=0 ");
                }
                else
                {
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        str = new string[] { " GuillotineSetupCharge=", dataRow["SetUpCharge"].ToString(), ",GuillotineMinimumRunningCharge=", dataRow["MinCharge"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str));
                        str = new string[] { " GuillotineCostPerCut=", dataRow["CostPerCut"].ToString(), ",GuillotinePaperWeight1=", dataRow["PaperWeight1"].ToString(), ",GuillotineMaximumThroat1=", dataRow["MaxSheets1"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str));
                        str = new string[] { " GuillotinePaperWeight2=", dataRow["PaperWeight2"].ToString(), ",GuillotineMaximumThroat2=", dataRow["MaxSheets2"].ToString(), ",GuillotinePaperWeight3=", dataRow["PaperWeight3"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str));
                        stringBuilder.Append(string.Concat(" GuillotineMaximumThroat3=", dataRow["MaxSheets3"].ToString(), ","));
                    }
                }
                estimateItemID = new object[] { " OneSqCmInkCost='", empty1, "', InkMarkup=", num, " " };
                stringBuilder.Append(string.Concat(estimateItemID));
                stringBuilder.Append(string.Concat(" Where EstCalculationID=", this.EstimateCalculationID));
                stringBuilder.Append(string.Concat(" select ", this.EstimateCalculationID));
                EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            }
            else
            {
                str1 = strArrays[2].ToString();
                foreach (DataRow row1 in EstimateBasePage.Estimate_Digital_Press_Select(this.CompanyID, PressID).Rows)
                {
                    str2 = row1["MarkUp"].ToString();
                    str = new string[] { " PressSetupCharge=", row1["SetupCharge"].ToString(), ",PressMinimumRunningCharge=", row1["MinimumCharge"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str));
                    if (row1["MethodName"].ToString() == "ClickChargeLookup")
                    {
                        empty = "ClickChargeLookup";
                        stringBuilder.Append("PressType='C',");
                        string[] strArrays3 = new string[] { " BlackChargeableRate=", row1["BlackChargeableSheets"].ToString(), ",ColorChargeableRate=", row1["ColorChargeableSheets"].ToString(), ",NoOfChargeableSheets=", row1["ChargeableSheets"].ToString(), "," };
                        stringBuilder.Append(string.Concat(strArrays3));
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
                        str3 = dataRow1["MarkUp"].ToString();
                        string[] str4 = new string[] { " GuillotineSetupCharge=", dataRow1["SetUpCharge"].ToString(), ",GuillotineMinimumRunningCharge=", dataRow1["MinCharge"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str4));
                        string[] strArrays4 = new string[] { " GuillotineCostPerCut=", dataRow1["CostPerCut"].ToString(), ",GuillotinePaperWeight1=", dataRow1["PaperWeight1"].ToString(), ",GuillotineMaximumThroat1=", dataRow1["MaxSheets1"].ToString(), "," };
                        stringBuilder.Append(string.Concat(strArrays4));
                        string[] str5 = new string[] { " GuillotinePaperWeight2=", dataRow1["PaperWeight2"].ToString(), ",GuillotineMaximumThroat2=", dataRow1["MaxSheets2"].ToString(), ",GuillotinePaperWeight3=", dataRow1["PaperWeight3"].ToString(), "," };
                        stringBuilder.Append(string.Concat(str5));
                        stringBuilder.Append(string.Concat(" GuillotineMaximumThroat3=", dataRow1["MaxSheets3"].ToString(), " "));
                    }
                }
                string str6 = "0";
                string str7 = "0";
                string str8 = "0";
                bool flag = false;
                string[] strArrays5 = this.hdnOldPaperID.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays5.Length - 1; i++)
                {
                    string[] strArrays6 = strArrays5[i].Split(new char[] { '~' });
                    if (Convert.ToInt64(strArrays6[0]) == EstimateBookletItemID)
                    {
                        str6 = strArrays6[1];
                    }
                }
                string[] strArrays7 = this.hdnOldPressID.Value.Split(new char[] { ',' });
                for (int j = 0; j < (int)strArrays7.Length - 1; j++)
                {
                    string[] strArrays8 = strArrays7[j].Split(new char[] { '~' });
                    if (Convert.ToInt64(strArrays8[0]) == EstimateBookletItemID)
                    {
                        str7 = strArrays8[1];
                    }
                }
                string[] strArrays9 = this.hdn_IsPaperUnitPriceLocked.Value.Split(new char[] { ',' });
                for (int k = 0; k < (int)strArrays9.Length - 1; k++)
                {
                    string[] strArrays10 = strArrays9[k].Split(new char[] { '~' });
                    if (Convert.ToInt64(strArrays10[0]) == EstimateBookletItemID)
                    {
                        flag = Convert.ToBoolean(strArrays10[1]);
                    }
                }
                string[] strArrays11 = this.hdnOldGuillotineID.Value.Split(new char[] { ',' });
                for (int l = 0; l < (int)strArrays11.Length - 1; l++)
                {
                    string[] strArrays12 = strArrays11[l].Split(new char[] { '~' });
                    if (Convert.ToInt64(strArrays12[0]) == EstimateBookletItemID)
                    {
                        str8 = strArrays12[1];
                    }
                }
                if (Convert.ToInt64(PaperID) != Convert.ToInt64(str6))
                {
                    string[] strArrays13 = new string[] { ", PaperWeight=", strArrays[1], ",PaperPackedInQty=", strArrays[3], " " };
                    stringBuilder.Append(string.Concat(strArrays13));
                    string[] strArrays14 = new string[] { ", PaperMarkup=", str1, ", PaperMarkup2=", str1, ", PaperMarkup3=", str1, ", PaperMarkup4=", str1, " " };
                    stringBuilder.Append(string.Concat(strArrays14));
                }
                if ((Convert.ToInt64(PaperID) != Convert.ToInt64(str6)) || (Convert.ToInt64(PaperID) == Convert.ToInt64(str6)))
                {
                    if (!flag)
                    {
                        stringBuilder.Append(string.Concat(",PaperUnitPrice=", strArrays[0], " "));
                    }
                }
                
                // Ticket #9819 paper unit price updated
                //if (!flag)
                //{
                //    stringBuilder.Append(string.Concat(",PaperUnitPrice=", strArrays[0], " "));
                //}

                if (Convert.ToInt64(PressID) != Convert.ToInt64(str7))
                {
                    string[] strArrays15 = new string[] { ", PressMarkup=", str2, ", PressMarkup2=", str2, ", PressMarkup3=", str2, ", PressMarkup4=", str2, " " };
                    stringBuilder.Append(string.Concat(strArrays15));
                }
                if (Convert.ToInt64(GuillotineID) != Convert.ToInt64(str8))
                {
                    string[] strArrays16 = new string[] { ",   GuillotineMarkUp=", str3, ", GuillotineMarkUp2=", str3, ", GuillotineMarkUp3=", str3, ", GuillotineMarkUp4=", str3, " " };
                    stringBuilder.Append(string.Concat(strArrays16));
                }
                if (EstimateType == "S" || EstimateType == "P")
                {
                    stringBuilder.Append(string.Concat(" Where EstimateBookletItemID=", EstimateBookletItemID));
                }
                else
                {
                    stringBuilder.Append(string.Concat(" Where EstimateBookletItemID=", EstimateBookletItemID));
                }
                stringBuilder.Append(" declare @EstimateCalculationID bigint; ");
                stringBuilder.Append(string.Concat(" set @EstimateCalculationID = (select EstimateCalculationID from tb_EstimateCalculation where EstimateBookletItemID=", EstimateBookletItemID, ") "));
                stringBuilder.Append(" select @EstimateCalculationID ");
                long num1 = EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
                if (empty == "ClickChargeZoneLookup")
                {
                    EstimatesBasePage.estimate_click_charge_zone_insert(this.CompanyID, num1, PressID);
                    return;
                }
                if (string.Compare(empty, "SpeedWeightLookup", true) == 0)
                {
                    EstimatesBasePage.estimate_speed_weight_insert(this.CompanyID, num1, PressID);
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
            if (string.Compare(this.MainType, "add", true) != 0)
            {
                if (base.Request.Params["maintype"] != null && base.Request.Params["maintype"].ToString() == "edit")
                {
                    string empty = string.Empty;
                    if (this.modulename == "estimates")
                    {
                        foreach (DataRow row in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = row["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                    }
                    else if (this.modulename == "jobs")
                    {
                        foreach (DataRow dataRow in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = dataRow["rownumber"].ToString();
                        }
                        this.objnotes.ModuleName = "job";
                        this.objnotes.Item_number = empty;
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                    }
                    else if (this.modulename == "invoice")
                    {
                        foreach (DataRow row1 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = row1["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                    }
                    else if (this.modulename == "orders")
                    {
                        foreach (DataRow dataRow1 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = dataRow1["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdItemRerun);
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
                }
                return;
            }
            string str = "B";
            string str1 = "Sheet Fed Digital Booklet Item";
            string empty1 = string.Empty;
            foreach (DataRow row2 in Notes.select_item_Title_for_Activity_History(CompanyID, ModuleID, EstimateItemID, str).Rows)
            {
                empty1 = row2["itemtitle"].ToString();
            }
            if (base.Request.Params["FromAddAnItem"] != null || base.Request.Params["FrmAddAnItem"] == "Y")
            {
                string empty2 = string.Empty;
                foreach (DataRow dataRow2 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                {
                    empty2 = dataRow2["rownumber"].ToString();
                }
                if (this.modulename == "estimates")
                {
                    this.objnotes.Item_title = empty1;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                    this.objnotes.Item_number = string.Concat(" ", empty2);
                    this.objnotes.Estimate_type = str1;
                }
                else if (this.modulename == "jobs")
                {
                    this.objnotes.Item_title = empty1;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                    this.objnotes.Item_number = string.Concat(" ", empty2);
                    this.objnotes.Job_type = str1;
                }
                else if (this.modulename == "invoice")
                {
                    this.objnotes.Item_title = empty1;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                    this.objnotes.Item_number = string.Concat(" ", empty2);
                    this.objnotes.Invoice_type = str1;
                }
                else if (this.modulename == "orders")
                {
                    this.objnotes.Item_title = empty1;
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                    this.objnotes.Item_number = string.Concat(" ", empty2);
                    this.objnotes.Estimate_type = str1;
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
            string str2 = string.Empty;
            if (this.modulename == "estimates")
            {
                foreach (DataRow row3 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "", (long)0).Rows)
                {
                    str2 = row3["Estimatenumber"].ToString();
                }
                this.objnotes.Estimate_type = str1;
                this.objnotes.Estimate_number = str2;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
            }
            else if (this.modulename == "jobs")
            {
                foreach (DataRow dataRow3 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "job", (long)0).Rows)
                {
                    str2 = dataRow3["jobnumber"].ToString();
                }
                this.objnotes.Job_type = str1;
                this.objnotes.ModuleName = "job";
                this.objnotes.Job_number = str2;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDirCreate);
            }
            else if (this.modulename == "invoice")
            {
                foreach (DataRow row4 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "invoice", (long)0).Rows)
                {
                    str2 = row4["invoicenumber"].ToString();
                }
                this.objnotes.Invoice_type = str1;
                this.objnotes.Invoice_number = str2;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvDirCreate);
            }
            else if (this.modulename == "orders")
            {
                foreach (DataRow dataRow4 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "", (long)0).Rows)
                {
                    str2 = dataRow4["Estimatenumber"].ToString();
                }
                this.objnotes.Estimate_type = str1;
                this.objnotes.Estimate_number = str2;
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
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

        public void Main_Quantity_Insert(long EstimateItemID_TempID, long EstimateBookletItemID, string strQty, string para, EstimatesItem Estitem)
        {
            Calculations calculation = new Calculations();
            if (para == "qty")
            {
                decimal profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                decimal taxRate = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                int taxID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                EstimatesBasePage.taxprofit_update(this.CompanyID, this.EstimateItemID, "B", taxID, taxRate, profitMargin, EstimateBookletItemID);
            }
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            string[] strArrays = strQty.Split(new char[] { '-' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (i == 0 && strArrays[0] != "")
                {
                    num = Convert.ToInt32(strArrays[0]);
                }
                else if (i == 1 && strArrays[1] != "")
                {
                    num1 = Convert.ToInt32(strArrays[1]);
                }
                else if (i == 2 && strArrays[2] != "")
                {
                    num2 = Convert.ToInt32(strArrays[2]);
                }
                else if (i == 3 && strArrays[3] != "")
                {
                    num3 = Convert.ToInt32(strArrays[3]);
                }
            }
            string str = "B";
            int[] numArray = new int[4];
            decimal[] numArray1 = new decimal[4];
            decimal[] numArray2 = new decimal[4];
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
            decimal[] numArray18 = new decimal[4];
            decimal[] numArray19 = new decimal[4];
            for (int j = 1; j <= 4; j++)
            {
                int num18 = 0;
                if (j == 1)
                {
                    num18 = num;
                }
                else if (j == 2)
                {
                    num18 = num1;
                }
                else if (j == 3)
                {
                    num18 = num2;
                }
                else if (j == 4)
                {
                    num18 = num3;
                }
                if (num18 <= 0)
                {
                    numArray[j - 1] = 0;
                    numArray1[j - 1] = new decimal(0);
                    numArray2[j - 1] = new decimal(0);
                    numArray3[j - 1] = new decimal(0);
                    num4[j - 1] = new decimal(0);
                    numArray4[j - 1] = new decimal(0);
                    num5[j - 1] = new decimal(0);
                    numArray5[j - 1] = new decimal(0);
                    num6[j - 1] = new decimal(0);
                    numArray6[j - 1] = new decimal(0);
                    num7[j - 1] = new decimal(0);
                    numArray7[j - 1] = new decimal(0);
                    num8[j - 1] = new decimal(0);
                    numArray8[j - 1] = new decimal(0);
                    num9[j - 1] = new decimal(0);
                    numArray9[j - 1] = new decimal(0);
                    num10[j - 1] = new decimal(0);
                    numArray10[j - 1] = new decimal(0);
                    num11[j - 1] = new decimal(0);
                    numArray11[j - 1] = new decimal(0);
                    num12[j - 1] = new decimal(0);
                    numArray12[j - 1] = new decimal(0);
                    num13[j - 1] = new decimal(0);
                    numArray13[j - 1] = new decimal(0);
                    num14[j - 1] = new decimal(0);
                    numArray14[j - 1] = new decimal(0);
                    num15[j - 1] = new decimal(0);
                    numArray15[j - 1] = new decimal(0);
                    num16[j - 1] = new decimal(0);
                    numArray16[j - 1] = new decimal(0);
                    num17[j - 1] = new decimal(0);
                }
                else
                {
                    numArray[j - 1] = num18;
                    DataTable dataTable = new DataTable();
                    dataTable = EstimatesBasePage.estimate_booklet_item_select(this.CompanyID, EstimateItemID_TempID);
                    object[] estimateItemIDTempID = new object[] { "EstimateItemID=", EstimateItemID_TempID, " and EstimateBookletItemID=", EstimateBookletItemID };
                    DataRow[] dataRowArray = dataTable.Select(string.Concat(estimateItemIDTempID));
                    DataRow dataRow = dataRowArray[0];
                    if (this.ProfitTaxKey.ToLower() != "database")
                    {
                        numArray1[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
                        numArray2[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "press", Convert.ToInt64(dataRow["PressID"]));
                        if (Convert.ToInt64(dataRow["GuillotineID"]) > (long)0)
                        {
                            numArray3[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "guillotine", Convert.ToInt64(dataRow["GuillotineID"]));
                        }
                    }
                    else
                    {
                        numArray1[0] = Convert.ToDecimal(dataRow["PaperMarkup"]);
                        numArray2[0] = Convert.ToDecimal(dataRow["PressMarkUp"]);
                        numArray3[0] = Convert.ToDecimal(dataRow["GuillotineMarkUp"]);
                        numArray1[1] = Convert.ToDecimal(dataRow["PaperMarkup2"]);
                        numArray2[1] = Convert.ToDecimal(dataRow["PressMarkUp2"]);
                        numArray3[1] = Convert.ToDecimal(dataRow["GuillotineMarkUp2"]);
                        numArray1[2] = Convert.ToDecimal(dataRow["PaperMarkup3"]);
                        numArray2[2] = Convert.ToDecimal(dataRow["PressMarkUp3"]);
                        numArray3[2] = Convert.ToDecimal(dataRow["GuillotineMarkUp3"]);
                        numArray1[3] = Convert.ToDecimal(dataRow["PaperMarkup4"]);
                        numArray2[3] = Convert.ToDecimal(dataRow["PressMarkUp4"]);
                        numArray3[3] = Convert.ToDecimal(dataRow["GuillotineMarkUp4"]);
                    }
                    decimal num19 = new decimal(0);
                    decimal FullSheetArea = new decimal(0);
                    num5[j - 1] = calculation.PaperCalculation(this.CompanyID, str, num18, numArray1[j - 1], dataRow, ref num4[j - 1], ref numArray4[j - 1], ref numArray5[j - 1], ref num6[j - 1], ref num19,ref FullSheetArea);
                    numArray7[j - 1] = calculation.PressCalculation(this.CompanyID, str, num18, numArray2[j - 1], dataRow, num6[j - 1], ref numArray6[j - 1], ref num7[j - 1], num19, ref numArray11[j - 1], ref num12[j - 1], ref numArray12[j - 1], ref num13[j - 1], ref numArray13[j - 1], ref num14[j - 1], ref numArray14[j - 1], ref num15[j - 1], ref numArray15[j - 1], ref num16[j - 1], ref numArray16[j - 1], j,ref numArray18[j-1], ref numArray19[j - 1]);

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
                        num11[j - 1] = result;
                    }

                    num8[j - 1] = calculation.GuillotineCalculation(this.CompanyID, str, num18, numArray3[j - 1], dataRow, num6[j - 1], ref numArray8[j - 1], ref num9[j - 1], ref numArray9[j - 1], ref num10[j - 1], ref numArray10[j - 1], ref num11[j - 1], num19, ref num17[j - 1], GuillotineType);
                }
            }
            EstimatesBasePage.quantity_insert_new(this.CompanyID, EstimateItemID_TempID, numArray[0], numArray5[0], num6[0], num4[0], numArray4[0], numArray6[0], num7[0], numArray9[0], num10[0], numArray10[0], num11[0], numArray8[0], num9[0], numArray[1], numArray5[1], num6[1], num4[1], numArray4[1], numArray6[1], num7[1], numArray9[1], num10[1], numArray10[1], num11[1], numArray8[1], num9[1], numArray[2], numArray5[2], num6[2], num4[2], numArray4[2], numArray6[2], num7[2], numArray9[2], num10[2], numArray10[2], num11[2], numArray8[2], num9[2], numArray[3], numArray5[3], num6[3], num4[3], numArray4[3], numArray6[3], num7[3], numArray9[3], num10[3], numArray10[3], num11[3], numArray8[3], num9[3], para, EstimateBookletItemID, numArray11[0], numArray11[1], numArray11[2], numArray11[3], num12[0], num12[1], num12[2], num12[3], numArray12[0], numArray12[1], numArray12[2], numArray12[3], num13[0], num13[1], num13[2], num13[3], numArray13[0], numArray13[1], numArray13[2], numArray13[3], num14[0], num14[1], num14[2], num14[3], numArray14[0], numArray14[1], numArray14[2], numArray14[3], num15[0], num15[1], num15[2], num15[3], numArray15[0], numArray15[1], numArray15[2], numArray15[3], num16[0], num16[1], num16[2], num16[3], numArray16[0], numArray16[1], numArray16[2], numArray16[3], num17[0], num17[1], num17[2], num17[3], numArray18[0], numArray18[1], numArray18[2], numArray18[3], numArray19[0], numArray19[1], numArray19[2], numArray19[3]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Session["ZoneMarkupCalcDetails"] = null;
            if (ConnectionClass.ProfitTaxKey != null)
            {
                this.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
            }
            if (!base.IsPostBack)
            {
                this.Label10.Text = this.objLanguage.GetLanguageConversion("Item_Title");
                this.Label5.Text = this.objLanguage.GetLanguageConversion("Section_Reference");
                this.Label9.Text = this.objLanguage.GetLanguageConversion("Assigned_Press");
                this.Label12.Text = this.objLanguage.GetLanguageConversion("Paper_Stock");
                this.ChkPriceForWholePack.Text = this.objLanguage.GetLanguageConversion("Price_For_Whole_Pack");
                this.ChkPaperSupplied.Text = this.objLanguage.GetLanguageConversion("Paper_Supplied");
                this.Label13.Text = this.objLanguage.GetLanguageConversion("Setup_Spoilage");
                this.Label14.Text = this.objLanguage.GetLanguageConversion("Running_Spoilage");
                this.chkDoubleSided.Text = this.objLanguage.GetLanguageConversion("Double_Sided");
                this.lblBookletType.Text = this.objLanguage.GetLanguageConversion("Booklet_Type");
                this.Label18.Text = this.objLanguage.GetLanguageConversion("No_Of_Pages_In_This_Section");
                this.Label22.Text = this.objLanguage.GetLanguageConversion("Print_Sheet_Size");
                this.ChkJobFlatCustom.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.chkPrintSheet.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.Label24.Text = this.objLanguage.GetLanguageConversion("Include_Gutters");
                this.Label25.Text = this.objLanguage.GetLanguageConversion("Apply_Press_Restrictions");
                this.Label19.Text = this.objLanguage.GetLanguageConversion("Booklet_Pages_Per_Print_Sheet");
                this.Label27.Text = this.objLanguage.GetLanguageConversion("Print_Sheets_Per_Section");
                this.Label26.Text = this.objLanguage.GetLanguageConversion("Guillotine");
                this.chkFirstTrim.Text = this.objLanguage.GetLanguageConversion("First_Trim");
                this.chkSecondTrim.Text = this.objLanguage.GetLanguageConversion("Second_Trim");
                this.btnStage2_Previous.Text = this.objLanguage.GetLanguageConversion("Previous");
                this.Button14.Text = this.objLanguage.GetLanguageConversion("New_Section");
                this.Button16.Text = this.objLanguage.GetLanguageConversion("Delete");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Finish");
                this.chkPortrait.Text = this.objLanguage.GetLanguageConversion("Portrait");
                this.chkLandscape.Text = this.objLanguage.GetLanguageConversion("LandScape");
                this.img_Description.Title = this.objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate");
            }
            this.Booklet_Pages_Per_Print_Sheet_Cannot_Be_Zero = this.objLanguage.GetLanguageConversion("Booklet_Pages_Per_Print_Sheet_Cannot_Be_Zero");
            base.Session["GetOldEstimatebookletitemID"] = null;
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            }
            if (base.Request.QueryString["EstID"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["EstID"]);
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
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            global.pgName = string.Empty;
            this.section = base.BaseSection;
            this.txtItemTitle.Focus();
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.Label11.Text = this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour");
            this.ddlColors.Items[0].Text = this.Label11.Text;
            this.ddlColors.Items[1].Text = this.objLanguage.GetLanguageConversion("Black_White");
            this.ddlColors_2.Items[0].Text = this.Label11.Text;
            this.ddlColors_2.Items[1].Text = this.objLanguage.GetLanguageConversion("Black_White");
            this.ddlBookletType.Items[0].Text = this.objLanguage.GetLanguageConversion("Saddle_Stiched");
            this.ddlBookletType.Items[1].Text = this.objLanguage.GetLanguageConversion("Perfect_Bound");
            this.ddlBookletFormat.Items[0].Text = this.objLanguage.GetLanguageConversion("Portrait");
            this.ddlBookletFormat.Items[1].Text = this.objLanguage.GetLanguageConversion("Landscape");
            this.txtQuantity.Attributes.Add("style", "text-align:right");
            this.txtQuantity_2.Attributes.Add("style", "text-align:right");
            this.txtRunOnQty.Attributes.Add("style", "text-align:right");
            this.txtQuantity_3.Attributes.Add("style", "text-align:right");
            this.txtQuantity_4.Attributes.Add("style", "text-align:right");
            this.txtSetupSpoilage.Attributes.Add("style", "text-align:right");
            this.txtRunningSpoilage.Attributes.Add("style", "text-align:right");
            this.txtNoOfPagesInSection.Attributes.Add("style", "text-align:right");
            this.txtPagesPerSignature.Attributes.Add("style", "text-align:right");
            this.txtNoOfSignatures.Attributes.Add("style", "text-align:right");

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
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
            }
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
                this.txtNoOfLeavesPerPad.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtsectionheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();roundTo3or2DecimalPlaces(this,this.value);");
                this.txtsectionwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();roundTo3or2DecimalPlaces(this,this.value);");
                this.txtitemheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');roundTo3or2DecimalPlaces(this,this.value);");
                this.txtitemwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');roundTo3or2DecimalPlaces(this,this.value);");
                this.txtGutterHorizontal.Attributes.Add("onblur", "todecimal_function(this,this.value);");
                this.txtGutterVertical.Attributes.Add("onblur", "todecimal_function(this,this.value);");
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
                    if (string.Compare(this.QueryType, "add", true) == 0 || string.Compare(this.QueryType, "more", true) == 0)
                    {
                        foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                        {
                            this.ChkPriceForWholePack.Checked = Convert.ToBoolean(row["DefaultPriceForWholePack"]);
                        }
                        foreach (DataRow dataRow in EstimatesBasePage.CopyesttitletoitemTitle(this.CompanyID, this.EstimateID).Rows)
                        {
                            this.txtItemTitle.Text = this.objBase.SpecialDecode(dataRow["EstimateTitle"].ToString());
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
                this.Select_Booklet_Item();
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
                foreach (DataRow dataRow1 in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                {
                    this.IsItemCompleted = Convert.ToInt16(dataRow1["IsItemCompleted"].ToString());
                    this.IsProductCreated = Convert.ToInt16(dataRow1["IsProductCreated"].ToString());
                }
                if (this.IsProductCreated == 1)
                {
                    this.Div_Productcatalogue.Visible = true;
                }
            }
            if (base.Request.QueryString["FromItem"] != null)
            {
                this.FromItemDescription = "Y";
            }
            if (base.Request.QueryString["frmcopyitem"] != null)
            {
                this.frmcopyitem = base.Request.QueryString["frmcopyitem"].ToString();
            }
            if (this.QueryType == "add" && !base.IsPostBack && EstimateBasePage.DefaultPageSize_Select((long)this.CompanyID) == 1)
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:DefaultLanding();", true);
            }
        }

        private void Select_Booklet_Item()
        {
            DataTable dataTable = EstimatesBasePage.booklet_item_select(this.CompanyID, this.EstimateItemID);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in dataTable.Rows)
            {
                this.EstimateBookletItemID = Convert.ToInt64(row["EstimateBookletItemID"]);
               booklet_item usercontrolItemBookletItem = this;
                usercontrolItemBookletItem.Estimatebookletitemid_old = string.Concat(usercontrolItemBookletItem.Estimatebookletitemid_old, this.EstimateBookletItemID, "~");
                this.EstimateCalculationID = Convert.ToInt64(row["EstimateCalculationID"]);
                this.TypeID = this.EstimateBookletItemID;
                this.ItemDescription_0 = row["ItemDescription"].ToString();
                this.hid_IsSheetCustom.Value = row["IsPrintSheetSizeDeleted"].ToString();
                this.hid_IsJobCustom.Value = row["IsJobFlatSizeDeleted"].ToString();
                if (!base.IsPostBack)
                {
                    this.txtItemTitle.Text = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                }
                stringBuilder.Append("EstimateType»digital±");
                stringBuilder.Append("ProductType»booklet±");
                stringBuilder.AppendFormat("Qty»{0}±", "");
                stringBuilder.AppendFormat("Press»{0}»{1}±", row["PressID"].ToString(), "D");
                object[] str = new object[] { row["PaperID"].ToString(), row["PaperName"].ToString(), row["IsPricePerPack"].ToString(), row["IsPaperSupplied"].ToString() };
                stringBuilder.AppendFormat("Paper»{0}»{1}»{2}»{3}±", str);
                stringBuilder.AppendFormat("SetupSpoilage»{0}±", Convert.ToDecimal(row["SetUpSpoilage"]));
                stringBuilder.AppendFormat("RunningSpoilage»{0}±", Convert.ToDecimal(row["RunningSpoilage"]));
                stringBuilder.AppendFormat("Colour»{0}»{1}±", row["Colour"].ToString(), row["IsDoubleSided"].ToString());
                object[] objArray = new object[] { row["PrintSheetSizeID"].ToString(), row["IsPrintSheetSizeDeleted"], row["SheetHeight"].ToString(), row["SheetWidth"].ToString() };
                stringBuilder.AppendFormat("SheetSize»{0}»{1}»{2}»{3}±", objArray);
                object[] str1 = new object[] { row["JobFlatSizeID"].ToString(), row["IsJobFlatSizeDeleted"], row["JobHeight"].ToString(), row["JobWidth"].ToString() };
                stringBuilder.AppendFormat("ItemSize»{0}»{1}»{2}»{3}±", str1);
                stringBuilder.AppendFormat("Gutters»{0}»{1}»{2}±", row["IsIncludeGutters"].ToString(), row["GutterHorizontal"].ToString(), row["GutterVertical"].ToString());
                stringBuilder.AppendFormat("PressRestrictions»{0}»{1}»{2}±", row["IsPressRestrictions"].ToString(), row["NonImageHeight"].ToString(), row["NonImageWidth"].ToString());
                stringBuilder.AppendFormat("PrintLayout»{0}»{1}»{2}»{3}±", row["PrintLayout"].ToString(), row["PortraitValue"].ToString(), row["LandscapeValue"].ToString(), row["ManualValue"].ToString());
                stringBuilder.AppendFormat("Guillotine»{0}»{1}±", row["GuillotineID"].ToString(), row["GuillotineName"].ToString());
                stringBuilder.AppendFormat("IsFirstTrim»{0}±", row["IsFirstTrim"].ToString());
                stringBuilder.AppendFormat("IsSecondTrim»{0}±", row["IsSecondTrim"].ToString());
                stringBuilder.AppendFormat("IsAnyOutwork»{0}±", row["IsAnyOutwork"].ToString());
                stringBuilder.AppendFormat("IsAnyWarehouse»{0}±", row["IsAnyWarehouseItem"].ToString());
                stringBuilder.AppendFormat("BookletType»{0}±", row["BookletType"].ToString());
                stringBuilder.AppendFormat("NoOfPagesInSection»{0}±", row["NoOfPagesInSection"].ToString());
                stringBuilder.AppendFormat("PagesPerSignature»{0}±", row["PagesPerSignature"].ToString());
                stringBuilder.AppendFormat("NoOfSignatures»{0}±", row["NoOfSignatures"].ToString());
                stringBuilder.AppendFormat("SectionReference»{0}±", row["SectionReference"].ToString());
                stringBuilder.AppendFormat("BookletFormat»{0}±", row["BookletFormat"].ToString());
                stringBuilder.AppendFormat("IsAnyOtherCost»{0}±", row["IsAnyOtherCost"].ToString());
                stringBuilder.AppendFormat("RowCount»{0}±", dataTable.Rows.Count);
                stringBuilder.AppendFormat("SideColor»{0}±", row["SideColor"].ToString());
                stringBuilder.AppendFormat("QuantityList»{0}±", row["Qty"].ToString());
                stringBuilder.AppendFormat("IsDeleted»{0}±", row["IsDeleted"].ToString());
                stringBuilder.AppendFormat("EstimateBookletItemID»{0}±", row["EstimateBookletItemID"].ToString());
                stringBuilder.AppendFormat("InvHeight»{0}±", row["Height"].ToString());
                stringBuilder.AppendFormat("Invwidth»{0}±", row["Width"].ToString());
                stringBuilder.AppendFormat("isCeilPrintSheetPerSection»{0}±", row["isCeilPrintSheetPerSection"].ToString());
                stringBuilder.AppendFormat("oldPaprID»{0}±", row["PaperID"].ToString());
                stringBuilder.AppendFormat("IsPaperUnitPriceLocked»{0}±", row["IsPaperUnitPriceLocked"].ToString());
                stringBuilder.AppendFormat("PaperWeight»{0}±", row["PaprWeight"].ToString());
                stringBuilder.Append("µ");
                if (base.IsPostBack)
                {
                    continue;
                }
                HiddenField hiddenField = this.hdnOldPressID;
                string value = hiddenField.Value;
                string[] strArrays = new string[] { value, this.EstimateBookletItemID.ToString(), "~", row["PressID"].ToString(), "," };
                hiddenField.Value = string.Concat(strArrays);
                HiddenField hiddenField1 = this.hdnOldPaperID;
                string value1 = hiddenField1.Value;
                string[] strArrays1 = new string[] { value1, this.EstimateBookletItemID.ToString(), "~", row["PaperID"].ToString(), "," };
                hiddenField1.Value = string.Concat(strArrays1);
                HiddenField hiddenField2 = this.hdnOldGuillotineID;
                string value2 = hiddenField2.Value;
                string[] str2 = new string[] { value2, this.EstimateBookletItemID.ToString(), "~", row["GuillotineID"].ToString(), "," };
                hiddenField2.Value = string.Concat(str2);
                HiddenField hdnIsPaperUnitPriceLocked = this.hdn_IsPaperUnitPriceLocked;
                string value3 = hdnIsPaperUnitPriceLocked.Value;
                string[] strArrays2 = new string[] { value3, this.EstimateBookletItemID.ToString(), "~", row["IsPaperUnitPriceLocked"].ToString(), "," };
                hdnIsPaperUnitPriceLocked.Value = string.Concat(strArrays2);
            }
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    this.QtyNo = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                }
            }
            if (string.Compare(this.modulename, "orders", true) == 0)
            {
                this.QtyNo = 1;
            }
            this.hid_bookletData.Value = stringBuilder.ToString();
            this.pnlBookletEdit.Visible = true;
            base.Session["GetOldEstimatebookletitemID"] = this.Estimatebookletitemid_old;
        }

        private void Update_Booklet_Item()
        {
            HttpContext.Current.Session[string.Concat("ZoneMarkupCalcDetails", this.EstimateItemID.ToString())] = null;
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            string value = this.hdnOldPaperID.Value;
            string[] strArrays = this.hid_booklet_save.Value.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                    if (strArrays2[0].Trim() == "SectionRef")
                    {
                        estimatesItem.SectionRef = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "PressID")
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
                    else if (strArrays2[0].Trim() == "BookletType" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        estimatesItem.BookletType = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "NoOfPagesInSection" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        estimatesItem.NoOfPagesInSection = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PagesPerSignature" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        estimatesItem.PagesPerSignature = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "NoOfSignatures" && !string.IsNullOrEmpty(strArrays2[1]))
                    {
                        estimatesItem.NoOfSignatures = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "Colour")
                    {
                        estimatesItem.Colour = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "IsDoubleSided")
                    {
                        estimatesItem.IsDoubleSided = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "SideColor")
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
                    else if (strArrays2[0].Trim() == "NonImageHeight")
                    {
                        estimatesItem.NonImageHeight = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "NonImageWidth")
                    {
                        estimatesItem.NonImageWidth = Convert.ToDecimal(strArrays2[1].Trim());
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
                    else if (strArrays2[0].Trim() == "isCeilPrintSheetPerSection")
                    {
                        estimatesItem.isCeilPrintSheetPerSection = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "BookletFormat")
                    {
                        estimatesItem.BookletFormat = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "EstimateBookletItemID")
                    {
                        estimatesItem.EstimateBookletItemID = Convert.ToInt64(strArrays2[1]);
                    }
                    else if (strArrays2[0].Trim() == "QtyList")
                    {
                        estimatesItem.EstimateItemID = this.EstimateItemID;
                        estimatesItem.ModifiedBy = Convert.ToInt32(base.Session["UserID"]);
                        estimatesItem.ModifiedDate = DateTime.Now;
                        estimatesItem.ItemTitle = this.Objclss.SpecialEncode(this.txtItemTitle.Text);
                        estimatesItem.ItemDescription = this.ItemDescription_0;
                        long num = EstimatesBasePage.booklet_item_insert(estimatesItem);
                        this.PressID = Convert.ToInt64(estimatesItem.PressID);
                        if (estimatesItem.EstimateBookletItemID != (long)0)
                        {
                            this.Estimate_Calcukation_Update(this.EstimateItemID, num, estimatesItem.PaperID, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, this.EstType);
                        }
                        else
                        {
                            this.Estimate_Calcukation(this.EstimateItemID, num, estimatesItem.PaperID, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, this.EstType);
                        }
                        if (estimatesItem.EstimateBookletItemID != (long)0)
                        {
                            this.Main_Quantity_Insert(estimatesItem.EstimateItemID, num, strArrays2[1].ToString(), "updatebookqty", estimatesItem);
                        }
                        else
                        {
                            this.Main_Quantity_Insert(estimatesItem.EstimateItemID, num, strArrays2[1].ToString(), "qty", estimatesItem);
                        }
                    }
                }
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            if (this.Chk_ItemDescn.Checked)
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "B", true);
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
                DataTable dataTable = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "B");
                if (dataTable.Rows.Count > 0)
                {
                    dataTable.Rows[0]["PricecatalogueID"].ToString();
                    if (num1 == 1 || num1 == 2)
                    {
                        EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "B", num1);
                    }
                }
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, this.EstType);
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
            EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "B");
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