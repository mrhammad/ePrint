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
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.usercontrol.Item
{
    public partial class NCR_item : UsercontrolBasePage
    {
        //protected Label Label10;

        //protected TextBox txtItemTitle;

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

        //protected Label Label2;

        //protected TextBox txtsetsperpad;

        //protected Label Label1;

        //protected TextBox txtpartsperset;

        //protected LinkButton lnkNewSection;

        //protected UpdatePanel UpdatePanel1;

        //protected UpdateProgress uprogress;

        //protected Label Label5;

        //protected TextBox txtSectionRef;

        //protected Label lblimage;

        //protected RadioButtonList rdoimagetype;

        //protected RadioButton rdouncommon;

        //protected RadioButton rdocommon;

        //protected DropDownList ddlcommonfrom;

        //protected Label Label9;

        //protected DropDownList ddlPress;

        //protected LinkButton lnk_ddlPress_OnChange;

        //protected UpdatePanel updatepresschangeid;

        //protected HiddenField hid_PressChange;

        //protected HiddenField hid_SessionPressChange;

        //protected HiddenField hid_LithoPress;

        //protected HiddenField hid_LithoPress_all;

        //protected HiddenField hid_DigitalPress;

        //protected HiddenField hid_LargeFormatPress;

        //protected HiddenField hid_DefaultDigitalPress;

        //protected HiddenField hid_DefaultLargePress;

        //protected HiddenField hdn_InkType;

        //protected Label Label12;

        //protected ImageButton imgbtnDefaultPaper;

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

        //protected DropDownList ddlNoOfSide;

        //protected Label Label11;

        //protected ImageButton ImageButton2;

        //protected DropDownList ddlSide1Color;

        //protected DropDownList ddlColors;

        //protected DropDownList ddlColors_2;

        //protected CheckBox chkDoubleSided;

        //protected Label Label3;

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

        //protected Label Label26;

        //protected HtmlAnchor divguillotineplusimg;

        //protected Label lblGuillotine;

        //protected CheckBox chkFirstTrim;

        //protected CheckBox chkSecondTrim;

        //protected HiddenField hid_GuillotineID;

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

        //protected Label Label158;

        //protected DropDownList ddlQualitySector;

        //protected Label Label159;

        //protected TextBox txtInkCoverageSide1;

        //protected TextBox txtInkCoverageSide2;

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

        //protected HiddenField hid_ncrdata;

        //protected HiddenField hid_previous;

        //protected HiddenField hid_previous_add;

        //protected HiddenField hid_partperset;

        //protected HiddenField hid_current;

        //protected HiddenField hid_incrementvalue;

        //protected HiddenField hid_ncreditdata;

        //protected HiddenField hid_thisvalue;

        //protected HiddenField hid_buttonvalue;

        //protected HiddenField hid_makeready;

        //protected HiddenField hid_washup;

        //protected HiddenField hidquantityvalue1;

        //protected HiddenField hidquantityvalue2;

        //protected HiddenField hidquantityvalue3;

        //protected HiddenField hidquantityvalue4;

        //protected HiddenField hidpartsperset;

        //protected HiddenField hid_FinalInkSave1;

        //protected HiddenField hid_FinalInkSave2;

        //protected HiddenField hid_calculationid;

        //protected HiddenField hid_inventoryheight;

        //protected HiddenField hid_inventorywidth;

        //protected HiddenField hid_partvalue;

        //protected HiddenField hid_checknextorload;

        //protected HiddenField hid_lithoncritemid;

        //protected HiddenField hid_value;

        //protected HiddenField hdn_PressID;

        //protected HiddenField hid_IsJobCustom;

        //protected HiddenField hid_IsSheetCustom;

        //protected HiddenField hdnedit_Default;

        //protected HiddenField hid_isPressPerfect;

        //protected HiddenField hdnOldPressID;

        //protected HiddenField hdnOldPaperID;

        //protected HiddenField hdnOldGuillotineID;

        //protected HiddenField hdn_invStockReduce;

        //protected HiddenField hdn_IsPaperUnitPriceLocked;

        //protected Panel pnlPress;

        //protected Panel pnlncredit;

        //protected Panel pnlgetbuttons;

        //protected Panel Pnleditmorequantity;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

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

        public long EstLithoNCRItemID;

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        private EstimatesBasePage objest = new EstimatesBasePage();

        private EstimatesItem Estitem = new EstimatesItem();

        private commonClass commclass = new commonClass();

        private SummaryClass summryCls = new SummaryClass();

        public languageClass objLanguage = new languageClass();

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public string dpaperhw = string.Empty;

        public string modulename = "estimates";

        public string submodulename = "estimate";

        public string str_QtyType = "more";

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public long EstimateBookletItemID;

        public string subedit = string.Empty;

        public string Sectionreference = string.Empty;

        private double setsperpad;

        public static string GetButtonNo;

        public static string querystring;

        public string ItemDescription = string.Empty;

        public static string checkmore;

        public int inkcount = 1;

        public int partcount = 1;

        private long estlithoncritemid;

        public string frmcopyitem = string.Empty;

        public static string Partsperset;

        public string PaperMeasure = string.Empty;

        public int QtyNo;

        public string MainType = string.Empty;

        private int side2color;

        public int IsItemCompleted;

        public string ProfitTaxKey = string.Empty;

        private commonClass objJava = new commonClass();

        public int IsProductCreated;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        private decimal JobTimeSumAdd;

        private decimal JobTimeSumEdit;

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

        static NCR_item()
        {
            NCR_item.GetButtonNo = string.Empty;
            NCR_item.querystring = string.Empty;
            NCR_item.checkmore = "no";
            NCR_item.Partsperset = "2";
        }

        public NCR_item()
        {
        }

        protected void Bind_Press(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            DataTable dataTable = EstimatesBasePage.estimate_press_select(sqlParameter1);
            ddl.DataSource = dataTable;
            ddl.DataTextField = "PressName";
            ddl.DataValueField = "PressID";
            ddl.DataBind();
            ddl.Items.Insert(0, "--- Select ---");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
            foreach (DataRow row in dataTable.Rows)
            {
                if (string.Compare(this.QueryType, "add", true) != 0 || !Convert.ToBoolean(row["IsDefaultPress"].ToString()))
                {
                    continue;
                }
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(row["PressName"].ToString()));
                break;
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
                        object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=N&From=F&maintype=", this.MainType, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID1));
                        return;
                    }
                    if (empty.ToString().ToLower() == "yes")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray1));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, this.jID, this.InvID };
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
                    object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, this.jID, this.InvID };
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
                            object[] objArray3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                            httpResponse3.Redirect(string.Concat(objArray3));
                            return;
                        }
                        HttpResponse response4 = base.Response;
                        object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
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
                    object[] objArray5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=N&From=S&EstItemID=", this.EstimateItemID, "&maintype=", this.MainType, this.jID, this.InvID };
                    httpResponse5.Redirect(string.Concat(objArray5));
                }
                else
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        HttpResponse response6 = base.Response;
                        object[] estimateID6 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
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
            if (this.jobID != (long)0)
            {
                empty = string.Concat("&jID=", this.jobID);
            }
            string str = string.Empty;
            if (this.InvoiceID != (long)0)
            {
                str = string.Concat("&InvID=", this.InvoiceID);
            }
            string empty1 = string.Empty;
            if (this.modulename == "invoice")
            {
                empty1 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            else if (this.modulename == "jobs")
            {
                empty1 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            if (this.ParentEstimateItemID != (long)0)
            {
                if (this.modulename == "orders")
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, empty, str };
                    response.Redirect(string.Concat(estimateID));
                    return;
                }
                if (empty1.ToString().ToLower() == "yes")
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, empty, str };
                    httpResponse.Redirect(string.Concat(objArray));
                    return;
                }
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, empty, str };
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
            empty = "N";
            int num1 = 0;
            bool flag = false;
            flag = (this.ParentEstimateItemID != (long)0 ? false : true);
            string str = string.Empty;
            bool @checked = this.chkPortrait.Checked;
            if (string.Compare(ParentItemType, "B", true) == 0)
            {
                ParentItemID = this.EstimateBookletItemID;
            }
            this.txtGutterHorizontal.Text = (this.txtGutterHorizontal.Text == "" ? "0" : this.txtGutterHorizontal.Text);
            this.txtGutterVertical.Text = (this.txtGutterVertical.Text == "" ? "0" : this.txtGutterVertical.Text);
            this.txtportrait.Text = (this.txtportrait.Text == "" ? "0" : this.txtportrait.Text);
            this.txtlandscape.Text = (this.txtlandscape.Text == "" ? "0" : this.txtlandscape.Text);
            this.txtManual.Text = (this.txtManual.Text == "" ? "0" : this.txtManual.Text);
            long num2 = (long)0;
            if (this.InvoiceID <= (long)0)
            {
                long num3 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, empty, flag, num2);
                num = num3;
                estimatesItem.EstimateItemID = num3;
            }
            else
            {
                long num4 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, empty, flag, num2);
                num = num4;
                estimatesItem.EstimateItemID = num4;
            }
            EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, num, ConnectionClass.IsHandy);
            if (this.jobID > (long)0)
            {
                long num5 = this.jobID;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                JobBasePage.EstimateItems_ProgressToJob(num, num5, false, Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
            }
            if (this.InvoiceID > (long)0)
            {
                InvoiceBasePage.EstimateItems_ProgressToInvoice(num, this.InvoiceID);
            }
            num1 = Convert.ToInt32(this.hidpartsperset.Value);
            string[] strArrays = this.hid_ncrdata.Value.Split(new char[] { 'µ' });
            int num6 = 0;
            num6 = (num1 != 1 ? (int)strArrays.Length : 1);
            for (int i = 0; i < num6; i++)
            {
                if (!string.IsNullOrEmpty(strArrays[i]))
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                        if (strArrays2[0].Trim() == "Title")
                        {
                            estimatesItem.NCRItemTitle = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Quantity1")
                        {
                            if (strArrays2[1].Trim() == "")
                            {
                                estimatesItem.NCRQuantity1 = 0;
                            }
                            else
                            {
                                estimatesItem.NCRQuantity1 = Convert.ToInt32(strArrays2[1].Trim());
                            }
                        }
                        else if (strArrays2[0].Trim() == "Quantity2")
                        {
                            if (strArrays2[1].Trim() == "")
                            {
                                estimatesItem.NCRQuantity2 = 0;
                            }
                            else
                            {
                                estimatesItem.NCRQuantity2 = Convert.ToInt32(strArrays2[1].Trim());
                            }
                        }
                        else if (strArrays2[0].Trim() == "Quantity3")
                        {
                            if (strArrays2[1].Trim() == "")
                            {
                                estimatesItem.NCRQuantity3 = 0;
                            }
                            else
                            {
                                estimatesItem.NCRQuantity3 = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                            }
                        }
                        else if (strArrays2[0].Trim() == "Quantity4")
                        {
                            if (strArrays2[1].Trim() == "")
                            {
                                estimatesItem.NCRQuantity4 = 0;
                            }
                            else
                            {
                                estimatesItem.NCRQuantity4 = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                            }
                        }
                        else if (strArrays2[0].Trim() == "Partsperset")
                        {
                            estimatesItem.NCRPartsperset = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Setsperpad")
                        {
                            if (strArrays2[1].Trim() == "")
                            {
                                estimatesItem.NCRSetsperpad = new decimal(0);
                            }
                            else
                            {
                                estimatesItem.NCRSetsperpad = Convert.ToDecimal(strArrays2[1].Trim());
                            }
                        }
                        else if (strArrays2[0].Trim() == "Sectionreference")
                        {
                            estimatesItem.NCRSectionreference = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Assignedpress")
                        {
                            estimatesItem.NCRAssignedpress = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "PaperID")
                        {
                            estimatesItem.NCRPaperID = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "PaperName")
                        {
                            estimatesItem.NCRPaperName = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "PriceForWhaolePack")
                        {
                            estimatesItem.NCRPriceForWhaolePack = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PaperSupplied")
                        {
                            estimatesItem.NCRPaperSupplied = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Setupspoilage")
                        {
                            estimatesItem.NCRSetupspoilage = (strArrays2[1].ToString() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Runningspoilage")
                        {
                            estimatesItem.NCRRunningspoilage = (strArrays2[1].ToString() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Noofsidesprinted")
                        {
                            estimatesItem.NCRNoofsidesprinted = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Side1color")
                        {
                            estimatesItem.NCRSide1color = (strArrays2[1].Trim() == "undefined" ? "" : strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Side2color")
                        {
                            estimatesItem.NCRSide2color = (strArrays2[1].Trim() == "undefined" ? "" : strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Checkturn")
                        {
                            estimatesItem.NCRCheckturn = (strArrays2[1].Trim() == "undefined" ? false : Convert.ToBoolean(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Checktumble")
                        {
                            estimatesItem.NCRChecktumble = (strArrays2[1].Trim() == "undefined" ? false : Convert.ToBoolean(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Platename")
                        {
                            estimatesItem.NCRPlatename = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "PlateID")
                        {
                            estimatesItem.NCRPlateID = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Plate")
                        {
                            estimatesItem.NCRPlate = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Makeready")
                        {
                            estimatesItem.NCRMakeready = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Washup")
                        {
                            estimatesItem.NCRWashup = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "PrintSheetSizeID")
                        {
                            estimatesItem.NCRPrintSheetSizeID = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "IsPrintCustom")
                        {
                            estimatesItem.NCRIsPrintCustom = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PrintSheetHeight")
                        {
                            estimatesItem.NCRPrintSheetHeight = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "PrintSheetWidth")
                        {
                            estimatesItem.NCRPrintSheetWidth = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "JobFlatSizeID")
                        {
                            estimatesItem.NCRJobFlatSizeID = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "IsJobCustom")
                        {
                            estimatesItem.NCRIsJobCustom = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "JobFlatSizeHeight")
                        {
                            estimatesItem.NCRJobFlatSizeHeight = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "JobFlatSizeWidth")
                        {
                            estimatesItem.NCRJobFlatSizeWidth = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "IsIncludeGutters")
                        {
                            estimatesItem.NCRIsIncludeGutters = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "GutterHorizontal")
                        {
                            estimatesItem.NCRGutterHorizontal = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "GutterVertical")
                        {
                            estimatesItem.NCRGutterVertical = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "IsPressRestrictions")
                        {
                            estimatesItem.NCRIsPressRestrictions = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "GuilotineID")
                        {
                            estimatesItem.NCRGuilotineID = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "GuilotineName")
                        {
                            estimatesItem.NCRGuilotineName = strArrays2[0].Trim();
                        }
                        else if (strArrays2[0].Trim() == "IsFirstTrim")
                        {
                            estimatesItem.NCRIsFirstTrim = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "IsSecondTrim")
                        {
                            estimatesItem.NCRIsSecondTrim = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PrintLayout")
                        {
                            estimatesItem.NCRPrintLayout = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Portraitvalue")
                        {
                            estimatesItem.NCRPortraitvalue = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Landscapevalue")
                        {
                            estimatesItem.NCRLandscapevalue = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "ManualValue")
                        {
                            estimatesItem.ManualValue = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Ncrcommonuncommon")
                        {
                            if (i != 0)
                            {
                                estimatesItem.Ncrcommonuncommon = strArrays2[1].Trim();
                            }
                            else
                            {
                                estimatesItem.Ncrcommonuncommon = "uncommon";
                            }
                        }
                        else if (strArrays2[0].Trim() == "Ncrcommonfrom")
                        {
                            estimatesItem.NCRNcommonfrom = strArrays2[1].Trim();
                        }
                        else if (!(strArrays2[0].Trim() == "NCRside1inkvalue") && !(strArrays2[0].Trim() == "NCRside2inkvalue") && strArrays2[0].Trim() == "CheckPerfecting")
                        {
                            estimatesItem.NCRCheckPerfecting = (strArrays2[1].Trim() == "undefined" ? false : Convert.ToBoolean(strArrays2[1].Trim()));
                        }
                    }
                    string empty1 = string.Empty;
                    if (chkManual.Checked)
                    {
                        empty1 = "Manual";
                    }
                    else
                    {
                        empty1 = (this.ddlBookletFormat.SelectedValue != "P" ? "Landscape" : "Portrait");
                    }
                    
                    this.estlithoncritemid = EstimatesBasePage.estimate_litho_NCR_item_insert(this.CompanyID, 0, num, Convert.ToInt64(estimatesItem.NCRAssignedpress), Convert.ToInt64(estimatesItem.NCRPaperID), estimatesItem.NCRPriceForWhaolePack, estimatesItem.NCRPaperSupplied, Convert.ToDecimal(estimatesItem.NCRSetupspoilage), Convert.ToDecimal(estimatesItem.NCRRunningspoilage), estimatesItem.NCRNoofsidesprinted, estimatesItem.NCRSide1color, estimatesItem.NCRSide2color, Convert.ToInt64(estimatesItem.NCRPlateID), estimatesItem.NCRPlate, estimatesItem.NCRMakeready, estimatesItem.NCRWashup, Convert.ToInt32(estimatesItem.NCRPrintSheetSizeID), estimatesItem.NCRIsPrintCustom, Convert.ToDecimal(estimatesItem.NCRPrintSheetHeight), Convert.ToDecimal(estimatesItem.NCRPrintSheetWidth), Convert.ToInt32(estimatesItem.NCRJobFlatSizeID), estimatesItem.NCRIsJobCustom, Convert.ToDecimal(estimatesItem.NCRJobFlatSizeHeight), Convert.ToDecimal(estimatesItem.NCRJobFlatSizeWidth), estimatesItem.NCRIsIncludeGutters, Convert.ToDecimal(estimatesItem.NCRGutterHorizontal), Convert.ToDecimal(estimatesItem.NCRGutterVertical), estimatesItem.NCRIsPressRestrictions, Convert.ToInt64(estimatesItem.NCRGuilotineID), Convert.ToInt32(base.Session["UserID"]), 0, DateTime.Now, Convert.ToBoolean(false), this.objBase.SpecialEncode(estimatesItem.NCRItemTitle), "", estimatesItem.NCRIsFirstTrim, estimatesItem.NCRIsSecondTrim, estimatesItem.NCRCheckturn, estimatesItem.NCRChecktumble, Convert.ToInt32(ParentItemID), ParentItemType, estimatesItem.NCRSectionreference, Convert.ToDecimal(estimatesItem.NCRPartsperset), Convert.ToDecimal(estimatesItem.NCRSetsperpad), estimatesItem.Ncrcommonuncommon, empty1, estimatesItem.NCRPrintLayout, Convert.ToDecimal(estimatesItem.NCRPortraitvalue), Convert.ToDecimal(estimatesItem.NCRLandscapevalue), estimatesItem.NCRNcommonfrom, estimatesItem.NCRCheckPerfecting, estimatesItem.ManualValue,this.chkSheetWork.Checked);
                    this.PressID = Convert.ToInt64(estimatesItem.NCRAssignedpress);
                    if (estimatesItem.NCRSide2color != "")
                    {
                        this.side2color = Convert.ToInt32(estimatesItem.NCRSide2color);
                    }
                    this.Popup_inkvalue_insert(num, "", this.PressID, estimatesItem.NCRNoofsidesprinted, empty, this.estlithoncritemid, this.partcount, Convert.ToInt32(estimatesItem.NCRSide1color), this.side2color, "add");
                    estimatesItem.GuillotineID = Convert.ToInt64(this.hid_GuillotineID.Value);
                    estimatesItem.PressType = 'S';
                    estimatesItem.PaperID = Convert.ToInt64(this.hdnpaperID.Value);
                    estimatesItem.NCRSide1color = (estimatesItem.NCRSide1color == "" ? "0" : estimatesItem.NCRSide1color);
                    estimatesItem.NCRSide2color = (estimatesItem.NCRSide2color == "" ? "0" : estimatesItem.NCRSide2color);
                    this.Estimate_Calcukation(num, this.estlithoncritemid, (long)estimatesItem.NCRPaperID, this.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, empty, estimatesItem.NCRNoofsidesprinted, estimatesItem.NCRCheckturn, estimatesItem.NCRChecktumble, Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), Convert.ToInt32(estimatesItem.NCRPlateID));
                    this.Main_Quantity_Insert(num, "qty", estimatesItem.NCRQuantity1, estimatesItem.NCRQuantity2, estimatesItem.NCRQuantity3, estimatesItem.NCRQuantity4, this.estlithoncritemid, estimatesItem, this.partcount);
                }
                NCR_item usercontrolItemNCRItem = this;
                usercontrolItemNCRItem.partcount = usercontrolItemNCRItem.partcount + 1;
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
            base.Session["dtinks"] = null;
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                JobBasePage.Job_Jobcard_Insert_NewItem_JOBTIME(this.CompanyID, num, 1, this.EstimateID, this.JobTimeSumAdd);
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, num, "N");
                string str1 = string.Empty;
                foreach (DataRow row in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    str1 = row["StatusID"].ToString();
                }
                if (string.Compare(this.modulename, "jobs", true) == 0 && this.ParentEstimateItemID == (long)0)
                {
                    this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(str1), "job", num, (long)0);
                }
                this.summryCls.Call_Inventory_Adjustment("progressed", this.EstimateID, this.CompanyID, num, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    this.summryCls.Call_Inventory_Adjustment("completed", this.EstimateID, this.CompanyID, num, this.UserID);
                }
                else if (string.Compare(this.modulename, "invoice", true) == 0 && this.ReduceStockType.ToLower() == "i" || this.hdn_invStockReduce.Value.ToLower() == "yes")
                {
                    this.summryCls.Call_Inventory_Adjustment("completed-invoice", this.EstimateID, this.CompanyID, num, this.UserID);
                }
                else if (string.Compare(this.modulename, "jobs", true) == 0 && this.ReduceStockType.ToString() == str1.ToString())
                {
                    this.summryCls.Call_Inventory_Adjustment("completed-status", this.EstimateID, this.CompanyID, num, this.UserID);
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
                EstimateCommonMethods.UpdateDescription(num, this.EstimateID, "N", false);
                if (EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "N") > (long)0)
                {
                    foreach (DataRow dataRow1 in EstimatesBasePage.lithoncr_item_select(this.CompanyID, num).Rows)
                    {
                        this.EstLithoNCRItemID = Convert.ToInt64(dataRow1["EstimateLithoNcrItemID"]);
                    }
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", num, "&booksecid=", this.EstLithoNCRItemID, " &parentesttype=N&maintype=edit&subitem=s", this.jID, this.InvID };
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
                string empty = string.Empty;
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string str3 = string.Empty;
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
                short num = Convert.ToInt16(this.txtpartsperset.Text);
                DataTable dataTable = new DataTable();
                string lower = this.ddlNoOfSide.SelectedValue.ToLower();
                Convert.ToInt32(this.ddlSide1Color.SelectedValue);
                Convert.ToInt32(this.ddlSide2Color.SelectedValue);
                this.PressID = Convert.ToInt64(this.ddlPress.SelectedValue);
                this.hdn_PressID.Value = this.PressID.ToString();
                string str11 = lower;
                short num1 = 0;
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
                for (int i = 1; i <= num; i++)
                {
                    empty = string.Concat("Parts", i);
                    if (lower.ToLower().Trim() == "single")
                    {
                        empty1 = "side1";
                        int num2 = 0;
                        foreach (DataRow row in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                        {
                            num1 = Convert.ToInt16(row["DefaultColour"].ToString());
                            Convert.ToInt16(row["rownumber"].ToString());
                            if (num1 <= num2)
                            {
                                continue;
                            }
                            str = string.Concat(str, row["InkID"].ToString(), "±");
                            str1 = string.Concat(str1, row["InkCoverage"].ToString(), "±");
                            str2 = string.Concat(str2, row["InkName"].ToString(), "±");
                            empty2 = string.Concat(empty2, "0±");
                            empty3 = string.Concat(empty3, "0±");
                            str3 = string.Concat(str3, "0±");
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
                        object[] objArray = new object[] { empty, str, str1, str11, empty1, str2, empty2, empty3, str3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                        dataTable.Rows.Add(objArray);
                        str = "";
                        str1 = "";
                        str2 = "";
                        empty2 = string.Empty;
                        empty3 = string.Empty;
                        str3 = string.Empty;
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
                    }
                    else if (lower.ToLower().Trim() == "double")
                    {
                        int num3 = 0;
                        int num4 = 0;
                        foreach (DataRow dataRow in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                        {
                            num1 = Convert.ToInt16(dataRow["DefaultColour"].ToString());
                            Convert.ToInt16(dataRow["rownumber"].ToString());
                            if (num1 <= num3)
                            {
                                continue;
                            }
                            str = string.Concat(str, dataRow["InkID"].ToString(), "±");
                            str1 = string.Concat(str1, dataRow["InkCoverage"].ToString(), "±");
                            str2 = string.Concat(str2, dataRow["InkName"].ToString(), "±");
                            empty2 = string.Concat(empty2, "0±");
                            empty3 = string.Concat(empty3, "0±");
                            str3 = string.Concat(str3, "0±");
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
                        empty1 = "side1";
                        object[] objArray1 = new object[] { empty, str, str1, str11, empty1, str2, empty2, empty3, str3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                        dataTable.Rows.Add(objArray1);
                        str = "";
                        str1 = "";
                        str2 = "";
                        empty2 = string.Empty;
                        empty3 = string.Empty;
                        str3 = string.Empty;
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
                        foreach (DataRow row1 in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                        {
                            num1 = Convert.ToInt16(row1["DefaultColour"].ToString());
                            Convert.ToInt16(row1["rownumber"].ToString());
                            if (num1 <= num4)
                            {
                                continue;
                            }
                            str = string.Concat(str, row1["InkID"].ToString(), "±");
                            str1 = string.Concat(str1, row1["InkCoverage"].ToString(), "±");
                            str2 = string.Concat(str2, row1["InkName"].ToString(), "±");
                            empty2 = string.Concat(empty2, "0±");
                            empty3 = string.Concat(empty3, "0±");
                            str3 = string.Concat(str3, "0±");
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
                            num4++;
                        }
                        empty1 = "side2";
                        object[] objArray2 = new object[] { empty, str, str1, str11, empty1, str2, empty2, empty3, str3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                        dataTable.Rows.Add(objArray2);
                        str = "";
                        str1 = "";
                        str2 = "";
                        empty2 = string.Empty;
                        empty3 = string.Empty;
                        str3 = string.Empty;
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
                    }
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
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
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
            short num = Convert.ToInt16(this.txtpartsperset.Text);
            DataTable dataTable = new DataTable();
            string lower = this.ddlNoOfSide.SelectedValue.ToLower();
            Convert.ToInt32(this.ddlSide1Color.SelectedValue);
            Convert.ToInt32(this.ddlSide2Color.SelectedValue);
            this.PressID = Convert.ToInt64(this.ddlPress.SelectedValue);
            this.hdn_PressID.Value = this.PressID.ToString();
            string str11 = lower;
            short num1 = 0;
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
            for (int i = 1; i <= num; i++)
            {
                empty = string.Concat("Parts", i);
                if (lower.ToLower().Trim() == "single")
                {
                    empty1 = "side1";
                    int num2 = 0;
                    foreach (DataRow row in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                    {
                        num1 = Convert.ToInt16(row["DefaultColour"].ToString());
                        Convert.ToInt16(row["rownumber"].ToString());
                        if (num1 <= num2)
                        {
                            continue;
                        }
                        str = string.Concat(str, row["InkID"].ToString(), "±");
                        str1 = string.Concat(str1, row["InkCoverage"].ToString(), "±");
                        str2 = string.Concat(str2, row["InkName"].ToString(), "±");
                        empty2 = string.Concat(empty2, "0±");
                        empty3 = string.Concat(empty3, "0±");
                        str3 = string.Concat(str3, "0±");
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
                    object[] objArray = new object[] { empty, str, str1, str11, empty1, str2, empty2, empty3, str3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                    dataTable.Rows.Add(objArray);
                    str = "";
                    str1 = "";
                    str2 = "";
                    empty2 = string.Empty;
                    empty3 = string.Empty;
                    str3 = string.Empty;
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
                }
                else if (lower.ToLower().Trim() == "double")
                {
                    int num3 = 0;
                    int num4 = 0;
                    foreach (DataRow dataRow in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                    {
                        num1 = Convert.ToInt16(dataRow["DefaultColour"].ToString());
                        Convert.ToInt16(dataRow["rownumber"].ToString());
                        if (num1 <= num3)
                        {
                            continue;
                        }
                        str = string.Concat(str, dataRow["InkID"].ToString(), "±");
                        str1 = string.Concat(str1, dataRow["InkCoverage"].ToString(), "±");
                        str2 = string.Concat(str2, dataRow["InkName"].ToString(), "±");
                        empty2 = string.Concat(empty2, "0±");
                        empty3 = string.Concat(empty3, "0±");
                        str3 = string.Concat(str3, "0±");
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
                    empty1 = "side1";
                    object[] objArray1 = new object[] { empty, str, str1, str11, empty1, str2, empty2, empty3, str3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                    dataTable.Rows.Add(objArray1);
                    str = "";
                    str1 = "";
                    str2 = "";
                    empty2 = string.Empty;
                    empty3 = string.Empty;
                    str3 = string.Empty;
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
                    foreach (DataRow row1 in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                    {
                        num1 = Convert.ToInt16(row1["DefaultColour"].ToString());
                        Convert.ToInt16(row1["rownumber"].ToString());
                        if (num1 <= num4)
                        {
                            continue;
                        }
                        str = string.Concat(str, row1["InkID"].ToString(), "±");
                        str1 = string.Concat(str1, row1["InkCoverage"].ToString(), "±");
                        str2 = string.Concat(str2, row1["InkName"].ToString(), "±");
                        empty2 = string.Concat(empty2, "0±");
                        empty3 = string.Concat(empty3, "0±");
                        str3 = string.Concat(str3, "0±");
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
                        num4++;
                    }
                    empty1 = "side2";
                    object[] objArray2 = new object[] { empty, str, str1, str11, empty1, str2, empty2, empty3, str3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                    dataTable.Rows.Add(objArray2);
                    str = "";
                    str1 = "";
                    str2 = "";
                    empty2 = string.Empty;
                    empty3 = string.Empty;
                    str3 = string.Empty;
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
                }
            }
            base.Session["dtinks"] = dataTable;
        }

        private string Estimate_Calcukation(long EstimateItemID, long EstimateLithoNCRItemID, long PaperID, long PressID, char PressType, long GuillotineID, string EstimateType, string SidesPerprinted, bool worknturn, bool workntumble, int side1color, int side2color, int PlateID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = EstimateBasePage.Paper_Calculation(this.CompanyID, Convert.ToInt32(PaperID)).Split(new char[] { '±' });
            decimal num = new decimal(0);
            decimal num1 = new decimal(1);
            string empty = string.Empty;
            decimal num2 = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "I", PaperID));
            double num3 = 0;
            double num4 = 0;
            double num5 = 0;
            stringBuilder.Append(" Insert into [tb_EstimateCalculation] ");
            stringBuilder.Append(" ( EstimateItemID, EstimateLithoNCRItemID, ");
            stringBuilder.Append(" PaperUnitPrice, PaperWeight, PaperMarkup,PaperMarkup2,PaperMarkup3,PaperMarkup4, ");
            stringBuilder.Append(" PlateMarkUp,PressMarkUp,PressMarkUp2,PressMarkUp3,PressMarkUp4, PressSetupCharge, PressMinimumRunningCharge, PressType, ");
            stringBuilder.Append(" BlackChargeableRate, ColorChargeableRate, NoOfChargeableSheets, ");
            stringBuilder.Append(" HourlyCharge, ");
            stringBuilder.Append(" PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, ");
            stringBuilder.Append(" GuillotineSetupCharge, GuillotineMinimumRunningCharge, GuillotineMarkUp,GuillotineMarkUp2,GuillotineMarkUp3,GuillotineMarkUp4, ");
            stringBuilder.Append(" GuillotineCostPerCut, GuillotinePaperWeight1, GuillotineMaximumThroat1, ");
            stringBuilder.Append(" GuillotinePaperWeight2, GuillotineMaximumThroat2, GuillotinePaperWeight3, ");
            stringBuilder.Append(" GuillotineMaximumThroat3,PaperPackedInQty,PressPasses,WashupUnitprice,MakeReadyUnitprice,PlateUnitPrice ) ");
            stringBuilder.Append(" Values ");
            object[] estimateItemID = new object[] { " ( ", EstimateItemID, ", ", EstimateLithoNCRItemID, "," };
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
                num3 = Convert.ToDouble(row["WashupUnitPrice"]);
                num4 = Convert.ToDouble(row["MakeReadyUnitPrice"]);
            }
            foreach (DataRow dataRow in EstimatesBasePage.SelectPlateunitprice_eachSectin(PlateID).Rows)
            {
                num5 = Convert.ToDouble(dataRow["PlateUnitPrice"]);
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
                foreach (DataRow row1 in dataTable.Rows)
                {
                    string[] str1 = new string[] { " ", row1["SetUpCharge"].ToString(), ",", row1["MinCharge"].ToString(), ",", row1["MarkUp"].ToString(), ",", row1["MarkUp"].ToString(), ",", row1["MarkUp"].ToString(), ",", row1["MarkUp"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str1));
                    string[] str2 = new string[] { " ", row1["CostPerCut"].ToString(), ",", row1["PaperWeight1"].ToString(), ",", row1["MaxSheets1"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str2));
                    string[] strArrays2 = new string[] { " ", row1["PaperWeight2"].ToString(), ",", row1["MaxSheets2"].ToString(), ",", row1["PaperWeight3"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays2));
                    stringBuilder.Append(string.Concat(" ", row1["MaxSheets3"].ToString(), ","));
                }
            }
            Calculations calculation = new Calculations();
            num1 = calculation.Return_PressPasses(SidesPerprinted, side1color, side2color, num, this.chkPerfecting.Checked);
            object[] objArray = new object[] { " ", num2, ", ", num1, ",", num3, ",", num4, ",", num5, ")" };
            stringBuilder.Append(string.Concat(objArray));
            stringBuilder.Append(" declare @EstimateCalculationID bigint; ");
            stringBuilder.Append(" set @EstimateCalculationID = Ident_Current('tb_EstimateCalculation')");
            stringBuilder.Append(" select @EstimateCalculationID ");
            long num6 = EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            EstimatesBasePage.estimates_litho_markup_calculation_insert(this.CompanyID, num6);
            EstimatesBasePage.litho_speed_weight_insert(this.CompanyID, num6, PressID);
            return stringBuilder.ToString();
        }

        private void Estimate_Calcukation_Update(long EstimateItemID, long EstBookletSectionID, long PaperID, long PressID, char PressType, long GuillotineID, string EstimateType, string SidesPerprinted, bool worknturn, bool workntumble, long EstimateCalculationID, int side1color, int side2color, int PlateID, int NCRSide1color, int NCRSide2Color, string NCRnoofsideprinted)
        {
            string str = "0";
            string str1 = "0";
            string str2 = "0";
            StringBuilder stringBuilder = new StringBuilder();
            decimal num = new decimal(0);
            decimal num1 = new decimal(1);
            double num2 = 0;
            double num3 = 0;
            double num4 = 0;
            stringBuilder.Append(" Update [tb_EstimateCalculation] ");
            stringBuilder.Append(string.Concat(" Set EstimateItemID=", EstimateItemID, ","));
            string[] strArrays = EstimateBasePage.Paper_Calculation(this.CompanyID, Convert.ToInt32(PaperID)).Split(new char[] { '±' });
            string empty = string.Empty;
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
            foreach (DataRow dataRow in EstimatesBasePage.SelectPlateunitprice_eachSectin(PlateID).Rows)
            {
                num4 = Convert.ToDouble(dataRow["PlateUnitPrice"]);
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
                foreach (DataRow row1 in dataTable.Rows)
                {
                    str2 = row1["MarkUp"].ToString();
                    string[] strArrays2 = new string[] { " GuillotineSetupCharge=", row1["SetUpCharge"].ToString(), ",GuillotineMinimumRunningCharge=", row1["MinCharge"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays2));
                    string[] str3 = new string[] { " GuillotineCostPerCut=", row1["CostPerCut"].ToString(), ",GuillotinePaperWeight1=", row1["PaperWeight1"].ToString(), ",GuillotineMaximumThroat1=", row1["MaxSheets1"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str3));
                    string[] strArrays3 = new string[] { " GuillotinePaperWeight2=", row1["PaperWeight2"].ToString(), ",GuillotineMaximumThroat2=", row1["MaxSheets2"].ToString(), ",GuillotinePaperWeight3=", row1["PaperWeight3"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays3));
                    stringBuilder.Append(string.Concat(" GuillotineMaximumThroat3=", row1["MaxSheets3"].ToString(), ","));
                }
            }
            Calculations calculation = new Calculations();
            num1 = calculation.Return_PressPasses(NCRnoofsideprinted, NCRSide1color, NCRSide2Color, num, this.chkPerfecting.Checked);
            object[] objArray = new object[] { "PressPasses=", num1, ",WashupUnitprice=", num2, ",MakeReadyUnitprice=", num3, ",PlateUnitPrice=", num4 };
            stringBuilder.Append(string.Concat(objArray));
            string str4 = "0";
            string str5 = "0";
            string str6 = "0";
            bool flag = false;
            string[] strArrays4 = this.hdnOldPaperID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays4.Length - 1; i++)
            {
                string[] strArrays5 = strArrays4[i].Split(new char[] { '~' });
                if (Convert.ToInt64(strArrays5[0]) == EstBookletSectionID)
                {
                    str4 = strArrays5[1];
                }
            }
            string[] strArrays6 = this.hdnOldPressID.Value.Split(new char[] { ',' });
            for (int j = 0; j < (int)strArrays6.Length - 1; j++)
            {
                string[] strArrays7 = strArrays6[j].Split(new char[] { '~' });
                if (Convert.ToInt64(strArrays7[0]) == EstBookletSectionID)
                {
                    str5 = strArrays7[1];
                }
            }
            string[] strArrays8 = this.hdnOldGuillotineID.Value.Split(new char[] { ',' });
            for (int k = 0; k < (int)strArrays8.Length - 1; k++)
            {
                string[] strArrays9 = strArrays8[k].Split(new char[] { '~' });
                if (Convert.ToInt64(strArrays9[0]) == EstBookletSectionID)
                {
                    str6 = strArrays9[1];
                }
            }
            string[] strArrays10 = this.hdn_IsPaperUnitPriceLocked.Value.Split(new char[] { ',' });
            for (int l = 0; l < (int)strArrays10.Length - 1; l++)
            {
                string[] strArrays11 = strArrays10[l].Split(new char[] { '~' });
                if (Convert.ToInt64(strArrays11[0]) == EstBookletSectionID)
                {
                    flag = Convert.ToBoolean(strArrays11[1]);
                }
            }
            if (Convert.ToInt64(PaperID) != Convert.ToInt64(str4))
            {
                string[] strArrays12 = new string[] { " , PaperWeight=", strArrays[1], ",PaperPackedInQty=", strArrays[3], " " };
                stringBuilder.Append(string.Concat(strArrays12));
                string[] strArrays13 = new string[] { ", PaperMarkup=", str, ", PaperMarkup2=", str, ", PaperMarkup3=", str, ", PaperMarkup4=", str, " " };
                stringBuilder.Append(string.Concat(strArrays13));
            }
            if ((Convert.ToInt64(PaperID) != Convert.ToInt64(str4)) || (Convert.ToInt64(PaperID) == Convert.ToInt64(str4)))
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

            if (Convert.ToInt64(PressID) != Convert.ToInt64(str5))
            {
                string[] strArrays14 = new string[] { ", PressMarkup=", str1, ", PressMarkup2=", str1, ", PressMarkup3=", str1, ", PressMarkup4=", str1, " " };
                stringBuilder.Append(string.Concat(strArrays14));
            }
            if (Convert.ToInt64(GuillotineID) != Convert.ToInt64(str6))
            {
                string[] strArrays15 = new string[] { ",   GuillotineMarkUp=", str2, ", GuillotineMarkUp2=", str2, ", GuillotineMarkUp3=", str2, ", GuillotineMarkUp4=", str2, " " };
                stringBuilder.Append(string.Concat(strArrays15));
            }
            if (EstimateType == "S" || EstimateType == "P")
            {
                stringBuilder.Append(string.Concat(" Where EstimateCalculationID=", EstimateCalculationID));
            }
            else
            {
                stringBuilder.Append(string.Concat(" Where EstimateLithoNCRItemID=", EstBookletSectionID));
            }
            stringBuilder.Append(string.Concat(" select ", EstimateCalculationID));
            EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            EstimatesBasePage.litho_speed_weight_insert(this.CompanyID, EstimateCalculationID, PressID);
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
                            EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(strArrays[i]), num, PressID, str2, LithoTypeID, EstimateType, str3, string.Concat("Parts", partcount.ToString()), Convert.ToDecimal(strArrays2[i]), Convert.ToDecimal(strArrays3[i]), Convert.ToDecimal(strArrays4[i]), Convert.ToDecimal(strArrays5[i]), Convert.ToDecimal(strArrays6[i]), Convert.ToDecimal(strArrays7[i]), Convert.ToDecimal(strArrays8[i]), Convert.ToDecimal(strArrays9[i]), Convert.ToDecimal(strArrays10[i]), Convert.ToDecimal(strArrays11[i]), Convert.ToDecimal(strArrays12[i]), Convert.ToDecimal(strArrays13[i]), Convert.ToDecimal(strArrays14[i]), Convert.ToDecimal(strArrays15[i]), Convert.ToDecimal(strArrays16[i]), Convert.ToDecimal(strArrays17[i]), Convert.ToDecimal(strArrays18[i]), Convert.ToDecimal(strArrays19[i]));
                        }
                        else
                        {
                            EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(strArrays[i]), num, PressID, str2, LithoTypeID, EstimateType, str3, string.Concat("Parts", partcount.ToString()), Convert.ToDecimal(strArrays2[i]), Convert.ToDecimal(strArrays3[i]), Convert.ToDecimal(strArrays4[i]), Convert.ToDecimal(strArrays5[i]), num1, num1, num1, num1, Convert.ToDecimal(strArrays10[i]), Convert.ToDecimal(strArrays11[i]), Convert.ToDecimal(strArrays12[i]), Convert.ToDecimal(strArrays13[i]), Convert.ToDecimal(strArrays14[i]), Convert.ToDecimal(strArrays15[i]), Convert.ToDecimal(strArrays16[i]), Convert.ToDecimal(strArrays17[i]), Convert.ToDecimal(strArrays18[i]), Convert.ToDecimal(strArrays19[i]));
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
                foreach (DataRow row in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
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
                        EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(dataReader["inkid"]), Convert.ToDecimal(dataReader["coverage"]), PressID, side, LithoTypeID, EstimateType, "side1", string.Concat("Parts", partcount.ToString()), new decimal(0), new decimal(0), new decimal(0), new decimal(0), num1, num1, num1, num1, new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0));
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
                        EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(dataReader1["inkid"]), Convert.ToDecimal(dataReader1["coverage"]), PressID, side, LithoTypeID, EstimateType, "side1", string.Concat("Parts", partcount.ToString()), new decimal(0), new decimal(0), new decimal(0), new decimal(0), num4, num4, num4, num4, new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0));
                    }
                    num2++;
                }
                IDataReader dataReader2 = SettingsBasePage.settings_lithopress_select_ink_rownum(CompanyID, PressID, 0);
                while (dataReader2.Read())
                {
                    if (side2color > num3)
                    {
                        EstimatesBasePage.estimateslitho_popup_ink_insert(CompanyID, EstimateItemID_TempID, Convert.ToInt64(dataReader2["inkid"]), Convert.ToDecimal(dataReader2["coverage"]), PressID, side, LithoTypeID, EstimateType, "side2", string.Concat("Parts", partcount.ToString()), new decimal(0), new decimal(0), new decimal(0), new decimal(0), num4, num4, num4, num4, new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0), new decimal(0));
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
            string str = "N";
            string str1 = "Sheet Fed Offset Ncr Item";
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
                    object[] item = new object[] { row["SectionName"], string.Concat(row["InkID"].ToString(), "±"), string.Concat(row["InkCoverage"].ToString(), "±"), row["SidesPrinted"], row["sidenumber"], row["InkName"], row["InkCostExMarkup1"], row["InkCostExMarkup2"], row["InkCostExMarkup3"], row["InkCostExMarkup4"], row["InkMarkup1"], row["InkMarkup2"], row["InkMarkup3"], row["InkMarkup4"], row["InkMarkupPrice1"], row["InkMarkupPrice2"], row["InkMarkupPrice3"], row["InkMarkupPrice4"], row["InkSetupCharge"], row["InkMinimumCharge"], row["InkCostExMarkup_Actual1"], row["InkCostExMarkup_Actual2"], row["InkCostExMarkup_Actual3"], row["InkCostExMarkup_Actual4"] };
                    dataTable1.Rows.Add(item);
                }
                num++;
            }
            base.Session["dtinks"] = dataTable1;
        }

        private void InsertNCRArrayValues(string strNCRSubsection)
        {
            string[] strArrays = strNCRSubsection.Split(new char[] { '±' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                if (strArrays1[0].Trim() == "Title")
                {
                    this.Estitem.NCRItemTitle = this.objBase.SpecialDecode(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Quantity1")
                {
                    if (strArrays1[1].Trim() == "")
                    {
                        this.Estitem.NCRQuantity1 = 0;
                    }
                    else
                    {
                        this.Estitem.NCRQuantity1 = Convert.ToInt32(strArrays1[1].Trim());
                    }
                }
                else if (strArrays1[0].Trim() == "Quantity2")
                {
                    if (strArrays1[1].Trim() == "")
                    {
                        this.Estitem.NCRQuantity2 = 0;
                    }
                    else
                    {
                        this.Estitem.NCRQuantity2 = Convert.ToInt32(strArrays1[1].Trim());
                    }
                }
                else if (strArrays1[0].Trim() == "Quantity3")
                {
                    if (strArrays1[1].Trim() == "")
                    {
                        this.Estitem.NCRQuantity3 = 0;
                    }
                    else
                    {
                        this.Estitem.NCRQuantity3 = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                    }
                }
                else if (strArrays1[0].Trim() == "Quantity4")
                {
                    if (strArrays1[1].Trim() == "")
                    {
                        this.Estitem.NCRQuantity4 = 0;
                    }
                    else
                    {
                        this.Estitem.NCRQuantity4 = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                    }
                }
                else if (strArrays1[0].Trim() == "Partsperset")
                {
                    this.Estitem.NCRPartsperset = Convert.ToDecimal(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Setsperpad")
                {
                    if (strArrays1[1].Trim() == "")
                    {
                        this.Estitem.NCRSetsperpad = new decimal(0);
                    }
                    else
                    {
                        this.Estitem.NCRSetsperpad = Convert.ToDecimal(strArrays1[1].Trim());
                    }
                }
                else if (strArrays1[0].Trim() == "Sectionreference")
                {
                    this.Estitem.NCRSectionreference = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "Assignedpress")
                {
                    this.Estitem.NCRAssignedpress = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "PaperID")
                {
                    this.Estitem.NCRPaperID = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "PaperName")
                {
                    this.Estitem.NCRPaperName = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "PriceForWhaolePack")
                {
                    this.Estitem.NCRPriceForWhaolePack = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "PaperSupplied")
                {
                    this.Estitem.NCRPaperSupplied = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Setupspoilage")
                {
                    this.Estitem.NCRSetupspoilage = Convert.ToDecimal(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Runningspoilage")
                {
                    this.Estitem.NCRRunningspoilage = Convert.ToDecimal(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Noofsidesprinted")
                {
                    this.Estitem.NCRNoofsidesprinted = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "Side1color")
                {
                    this.Estitem.NCRSide1color = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "Side2color")
                {
                    this.Estitem.NCRSide2color = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "Checkturn")
                {
                    this.Estitem.NCRCheckturn = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Checktumble")
                {
                    this.Estitem.NCRChecktumble = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "Platename")
                {
                    this.Estitem.NCRPlatename = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "PlateID")
                {
                    this.Estitem.NCRPlateID = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "Plate")
                {
                    this.Estitem.NCRPlate = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "Makeready")
                {
                    this.Estitem.NCRMakeready = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "Washup")
                {
                    this.Estitem.NCRWashup = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "PrintSheetSizeID")
                {
                    this.Estitem.NCRPrintSheetSizeID = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "IsPrintCustom")
                {
                    this.Estitem.NCRIsPrintCustom = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "PrintSheetHeight")
                {
                    this.Estitem.NCRPrintSheetHeight = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "PrintSheetWidth")
                {
                    this.Estitem.NCRPrintSheetWidth = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "JobFlatSizeID")
                {
                    this.Estitem.NCRJobFlatSizeID = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "IsJobCustom")
                {
                    this.Estitem.NCRIsJobCustom = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "JobFlatSizeHeight")
                {
                    this.Estitem.NCRJobFlatSizeHeight = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "JobFlatSizeWidth")
                {
                    this.Estitem.NCRJobFlatSizeWidth = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "IsIncludeGutters")
                {
                    this.Estitem.NCRIsIncludeGutters = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "GutterHorizontal")
                {
                    this.Estitem.NCRGutterHorizontal = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "GutterVertical")
                {
                    this.Estitem.NCRGutterVertical = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "IsPressRestrictions")
                {
                    this.Estitem.NCRIsPressRestrictions = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "GuilotineID")
                {
                    this.Estitem.NCRGuilotineID = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "GuilotineName")
                {
                    this.Estitem.NCRGuilotineName = strArrays1[0].Trim();
                }
                else if (strArrays1[0].Trim() == "IsFirstTrim")
                {
                    this.Estitem.NCRIsFirstTrim = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "IsSecondTrim")
                {
                    this.Estitem.NCRIsSecondTrim = Convert.ToBoolean(strArrays1[1].Trim());
                }
                else if (strArrays1[0].Trim() == "PrintLayout")
                {
                    this.Estitem.NCRPrintLayout = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "Portraitvalue")
                {
                    this.Estitem.NCRPortraitvalue = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "Landscapevalue")
                {
                    this.Estitem.NCRLandscapevalue = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "ManualValue")
                {
                    this.Estitem.ManualValue = (strArrays1[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays1[1].Trim()));
                }
                else if (strArrays1[0].Trim() == "Ncrcommonuncommon")
                {
                    this.Estitem.Ncrcommonuncommon = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "Ncrcommonfrom")
                {
                    this.Estitem.NCRNcommonfrom = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "NCRside1inkvalue")
                {
                    this.hid_FinalInkSave1.Value = strArrays1[1].Trim();
                }
                else if (strArrays1[0].Trim() == "NCRside2inkvalue")
                {
                    this.hid_FinalInkSave2.Value = strArrays1[1].Trim();
                }
            }
        }

        public void Main_Quantity_Insert(long EstimateItemID_TempID, string para, int Qty1, int Qty2, int Qty3, int Qty4, long estlithoncritemid, EstimatesItem Estitem, int partcount)
        {
            Calculations calculation = new Calculations();
            if (Qty3 == 0 && Qty4 != 0)
            {
                Qty3 = Qty4;
                Qty4 = 0;
            }
            if (Qty2 == 0 && Qty3 != 0)
            {
                Qty2 = Qty3;
                Qty3 = 0;
            }
            if (string.Compare(this.hid_QtyType.Value, "S", true) == 0)
            {
                int num = 0;
                Qty4 = num;
                Qty3 = num;
                Qty2 = num;
            }
            string str = "N";
            int[] numArray = new int[4];
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
            decimal[] numArray14 = new decimal[4];
            decimal[] numArray15 = new decimal[4];
            decimal[] numArray16 = new decimal[4];
            decimal[] numArray17 = new decimal[4];
            decimal[] numArray18 = new decimal[4];
            decimal[] numArray19 = new decimal[4];
            decimal[] numArray20 = new decimal[4];
            decimal[] numArray21 = new decimal[4];
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
            decimal[] num23 = new decimal[4];
            decimal[] numArray23 = new decimal[4];
            decimal[] numArray30 = new decimal[4];
            decimal[] numArray31 = new decimal[4];

            
            for (int i = 1; i <= 4; i++)
            {
                int qty1 = 0;
                if (i == 1)
                {
                    qty1 = Qty1;
                }
                else if (i == 2)
                {
                    qty1 = Qty2;
                }
                else if (i == 3)
                {
                    qty1 = Qty3;
                }
                else if (i == 4)
                {
                    qty1 = Qty4;
                }
                if (qty1 <= 0)
                {
                    numArray[i - 1] = 0;
                    num1[i - 1] = new decimal(0);
                    numArray1[i - 1] = new decimal(0);
                    num2[i - 1] = new decimal(0);
                    numArray2[i - 1] = new decimal(0);
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
                    num12[i - 1] = new decimal(0);
                    numArray12[i - 1] = new decimal(0);
                    num13[i - 1] = new decimal(0);
                    num10[i - 1] = new decimal(0);
                    numArray10[i - 1] = new decimal(0);
                    num11[i - 1] = new decimal(0);
                    numArray11[i - 1] = new decimal(0);
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
                    num23[i - 1] = new decimal(0);
                    numArray23[i - 1] = new decimal(0);
                }
                else
                {
                    numArray[i - 1] = qty1;
                    DataTable dataTable = new DataTable();
                    dataTable = EstimatesBasePage.estimate_litho_ncr_item_select(this.CompanyID, EstimateItemID_TempID);
                    DataRow[] dataRowArray = dataTable.Select(string.Concat(" EstimateLithoNCRItemID=", estlithoncritemid));
                    DataRow dataRow = dataRowArray[0];
                    if (this.ProfitTaxKey.ToLower() != "database")
                    {
                        num1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
                        numArray1[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "press", Convert.ToInt64(dataRow["PressID"]));
                        if (Convert.ToInt64(dataRow["GuillotineID"]) > (long)0)
                        {
                            num2[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "guillotine", Convert.ToInt64(dataRow["GuillotineID"]));
                        }
                        numArray2[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inks", (long)0);
                        num3[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inventoryitems", (long)0);
                        numArray3[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inventoryitems", (long)0);
                        num4[i - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inventoryitems", (long)0);
                    }
                    else
                    {
                        num1[0] = Convert.ToDecimal(dataRow["PaperMarkup"]);
                        numArray1[0] = Convert.ToDecimal(dataRow["PressMarkUp"]);
                        num2[0] = Convert.ToDecimal(dataRow["GuillotineMarkUp"]);
                        num1[1] = Convert.ToDecimal(dataRow["PaperMarkup2"]);
                        numArray1[1] = Convert.ToDecimal(dataRow["PressMarkUp2"]);
                        num2[1] = Convert.ToDecimal(dataRow["GuillotineMarkUp2"]);
                        num1[2] = Convert.ToDecimal(dataRow["PaperMarkup3"]);
                        numArray1[2] = Convert.ToDecimal(dataRow["PressMarkUp3"]);
                        num2[2] = Convert.ToDecimal(dataRow["GuillotineMarkUp3"]);
                        num1[3] = Convert.ToDecimal(dataRow["PaperMarkup4"]);
                        numArray1[3] = Convert.ToDecimal(dataRow["PressMarkUp4"]);
                        num2[3] = Convert.ToDecimal(dataRow["GuillotineMarkUp4"]);
                        numArray2[i - 1] = Convert.ToDecimal(dataRow["InkMarkup"]);
                        num3[i - 1] = Convert.ToDecimal(dataRow["PlateMarkup"]);
                        numArray3[i - 1] = Convert.ToDecimal(dataRow["MakeReadyMarkUp"]);
                        num4[i - 1] = Convert.ToDecimal(dataRow["WashUpMarkUp"]);
                    }
                    decimal num24 = new decimal(0);
                    decimal FullSheetArea = new decimal(0);
                    numArray5[i - 1] = calculation.PaperCalculation(this.CompanyID, str, qty1, num1[i - 1], dataRow, ref numArray4[i - 1], ref num5[i - 1], ref num6[i - 1], ref numArray6[i - 1], ref num24,ref FullSheetArea);
                    num8[i - 1] = calculation.PressCalculation(this.CompanyID, str, qty1, numArray1[i - 1], dataRow, numArray6[i - 1], ref num7[i - 1], ref numArray7[i - 1], num24, ref num14[i - 1], ref num15[i - 1], ref num16[i - 1], ref num17[i - 1], ref num18[i - 1], ref num19[i - 1], ref num20[i - 1], ref num21[i - 1], ref num22[i - 1], ref numArray22[i - 1], ref num23[i - 1], i, ref numArray30[i - 1], ref numArray31[i - 1]);

                    DataTable dt = new DataTable();
                    if(Estitem.GuillotineID > 0)
                    {
                        dt = SettingsBasePage.Settings_Guillotine_Select_By_ID(this.CompanyID, Estitem.GuillotineID);
                    }
                    else
                    {
                        dt = SettingsBasePage.Settings_Guillotine_Select_By_ID(this.CompanyID, Convert.ToInt64(dataRow["GuillotineID"]));
                    }
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
                        numArray11[i - 1] = result;
                    }

                    numArray8[i - 1] = calculation.GuillotineCalculation(this.CompanyID, str, qty1, num2[i - 1], dataRow, numArray6[i - 1], ref num9[i - 1], ref numArray9[i - 1], ref num10[i - 1], ref numArray10[i - 1], ref num11[i - 1], ref numArray11[i - 1], num24, ref numArray23[i - 1], GuillotineType);
                    num12[i - 1] = calculation.InkCalculation(this.CompanyID, str, qty1, numArray2[i - 1], dataRow, EstimateItemID_TempID, ref numArray12[i - 1], ref num13[i - 1], estlithoncritemid, partcount, para, i, this.ProfitTaxKey.ToLower());
                    numArray13[i - 1] = calculation.PlateCalculation(this.CompanyID, str, qty1, num3[i - 1], dataRow, ref numArray14[i - 1], ref numArray15[i - 1], partcount);
                    numArray16[i - 1] = calculation.MakeReadyCalculation(this.CompanyID, str, qty1, numArray3[i - 1], dataRow, ref numArray17[i - 1], ref numArray18[i - 1], partcount);
                    numArray19[i - 1] = calculation.WashupCalculation(this.CompanyID, str, qty1, num4[i - 1], dataRow, ref numArray20[i - 1], ref numArray21[i - 1], partcount);
                }
            }
            EstimatesBasePage.quantity_insert_offset_item(this.CompanyID, EstimateItemID_TempID, str, numArray[0], num6[0], numArray6[0], numArray4[0], num5[0], num7[0], numArray7[0], num10[0], numArray10[0], num11[0], numArray11[0], num9[0], numArray9[0], numArray12[0], num13[0], numArray14[0], numArray15[0], numArray17[0], numArray18[0], numArray20[0], numArray21[0], numArray[1], num6[1], numArray6[1], numArray4[1], num5[1], num7[1], numArray7[1], num10[1], numArray10[1], num11[1], numArray11[1], num9[1], numArray9[1], numArray12[1], num13[1], numArray14[1], numArray15[1], numArray17[1], numArray18[1], numArray20[1], numArray21[1], numArray[2], num6[2], numArray6[2], numArray4[2], num5[2], num7[2], numArray7[2], num10[2], numArray10[2], num11[2], numArray11[2], num9[2], numArray9[2], numArray12[2], num13[2], numArray14[2], numArray15[2], numArray17[2], numArray18[2], numArray20[2], numArray21[2], numArray[3], num6[3], numArray6[3], numArray4[3], num5[3], num7[3], numArray7[3], num10[3], numArray10[3], num11[3], numArray11[3], num9[3], numArray9[3], numArray12[3], num13[3], numArray14[3], numArray15[3], numArray17[3], numArray18[3], numArray20[3], numArray21[3], para, estlithoncritemid, num14[0], num14[1], num14[2], num14[3], num15[0], num15[1], num15[2], num15[3], num16[0], num16[1], num16[2], num16[3], num17[0], num17[1], num17[2], num17[3], num18[0], num18[1], num18[2], num18[3], num19[0], num19[1], num19[2], num19[3], num20[0], num20[1], num20[2], num20[3], num21[0], num21[1], num21[2], num21[3], num23[0], num23[1], num23[2], num23[3], numArray23[0], numArray23[1], numArray23[2], numArray23[3]);
            this.JobTimeSumAdd = this.JobTimeSumAdd + num14[0];
            if (this.GetQtyNo() != 0)
            {
                int qtyNo = this.GetQtyNo() - 1;
                this.JobTimeSumEdit = this.JobTimeSumEdit + num14[qtyNo];
            }
        }

        public void Main_Quantity_Insert_update(long EstimateItemID_TempID, string para, long estlithoncritemid, int qty1, int qty2, int qty3, int qty4)
        {
            int num = qty1;
            int num1 = qty2;
            int num2 = qty3;
            int num3 = qty4;
            if (num2 == 0 && num3 != 0)
            {
                num2 = num3;
                num3 = 0;
            }
            if (num1 == 0 && num2 != 0)
            {
                num1 = num2;
                num2 = 0;
            }
            if (string.Compare(this.hid_QtyType.Value, "S", true) == 0)
            {
                int num4 = 0;
                num3 = num4;
                num2 = num4;
                num1 = num4;
            }
            EstimatesBasePage.NCRquantity_insert(this.CompanyID, EstimateItemID_TempID, num, num1, num2, num3, 0, 0, 0, 0, 0, 0, para, estlithoncritemid);
        }

        protected void onclick_lnkNewSection(object sender, EventArgs e)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
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
            if (base.Session["dtinks"] != null)
            {
                dataTable = (DataTable)base.Session["dtinks"];
            }
            else
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
            decimal num = Convert.ToDecimal(NCR_item.Partsperset);
            int num1 = Convert.ToInt16(this.txtpartsperset.Text);
            for (int i = 1; i <= num1; i++)
            {
                if (i > Convert.ToInt32(num))
                {
                    empty = string.Concat("Parts", i);
                    int num2 = 0;
                    if (lower.ToLower().Trim() == "single")
                    {
                        num2 = 1;
                    }
                    else if (lower.ToLower().Trim() == "double")
                    {
                        num2 = 2;
                    }
                    for (int j = 1; j <= num2; j++)
                    {
                        empty1 = string.Concat("side", j);
                        object[] objArray = new object[] { "SectionName='", empty, "' and sidenumber='side", j, "'" };
                        DataRow[] dataRowArray = dataTable.Select(string.Concat(objArray));
                        if ((int)dataRowArray.Length > 0)
                        {
                            dataTable.Rows.Remove(dataRowArray[0]);
                        }
                        DataRow[] dataRowArray1 = dataTable.Select(string.Concat("SectionName='Parts1' and sidenumber='side", j, "'"));
                        if ((int)dataRowArray1.Length > 0)
                        {
                            DataRow[] dataRowArray2 = dataRowArray1;
                            for (int k = 0; k < (int)dataRowArray2.Length; k++)
                            {
                                DataRow dataRow = dataRowArray2[k];
                                str = dataRow["InkID"].ToString();
                                str1 = dataRow["InkCoverage"].ToString();
                                str11 = dataRow["SidesPrinted"].ToString();
                                str2 = dataRow["InkName"].ToString();
                                string[] strArrays = str1.Split(new char[] { '±' });
                                for (int l = 0; l < (int)strArrays.Length - 1; l++)
                                {
                                    empty2 = string.Concat(empty2, "0±");
                                    empty3 = string.Concat(empty3, "0±");
                                    str3 = string.Concat(str3, "0±");
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
                                }
                            }
                            object[] objArray1 = new object[] { empty, str, str1, str11, empty1, str2, empty2, empty3, str3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11 };
                            dataTable.Rows.Add(objArray1);
                        }
                        str = "";
                        str1 = "";
                        str2 = "";
                        empty2 = "";
                        empty3 = "";
                        str3 = "";
                        empty4 = "";
                        str4 = "";
                        empty5 = "";
                        str5 = "";
                        empty6 = "";
                        str6 = "";
                        empty7 = "";
                        str7 = "";
                        empty8 = "";
                        str8 = "";
                        empty9 = "";
                        str9 = "";
                        empty10 = "";
                        str10 = "";
                        empty11 = "";
                    }
                }
            }
            base.Session["dtinks"] = dataTable;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            if (!base.IsPostBack)
            {
                this.Label10.Text = this.objLanguage.GetLanguageConversion("Item_Title");
                this.Label2.Text = this.objLanguage.GetLanguageConversion("No_of_Sets_Per_Pad");
                this.Label1.Text = this.objLanguage.GetLanguageConversion("No_Of_Parts_Per_Set");
                this.Label5.Text = this.objLanguage.GetLanguageConversion("Part_Reference");
                this.Label9.Text = this.objLanguage.GetLanguageConversion("Assigned_Press");
                this.Label12.Text = this.objLanguage.GetLanguageConversion("Paper_Stock");
                this.ChkPriceForWholePack.Text = this.objLanguage.GetLanguageConversion("Price_For_Whole_Pack");
                this.ChkPaperSupplied.Text = this.objLanguage.GetLanguageConversion("Paper_Supplied");
                this.Label13.Text = this.objLanguage.GetLanguageConversion("SetUp_Spoilage");
                this.Label14.Text = this.objLanguage.GetLanguageConversion("Running_Spoilage");
                this.Label11.Text = string.Concat(this.objLanguage.GetLanguageConversion("Side_1"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                this.Label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Side_2"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                this.chkTumble.Text = this.objLanguage.GetLanguageConversion("Work_Tumble");
                this.chkTurn.Text = this.objLanguage.GetLanguageConversion("Work_Turn");
                this.Label22.Text = this.objLanguage.GetLanguageConversion("Print_Sheet_Size");
                this.chkPrintSheet.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.ChkJobFlatCustom.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.Label23.Text = this.objLanguage.GetLanguageConversion("Finished_Job_size");
                this.Label24.Text = this.objLanguage.GetLanguageConversion("Include_Gutters");
                this.Label25.Text = this.objLanguage.GetLanguageConversion("Apply_Press_Restrictions");
                this.Label26.Text = this.objLanguage.GetLanguageConversion("Guillotine");
                this.chkFirstTrim.Text = this.objLanguage.GetLanguageConversion("First_Trim");
                this.chkSecondTrim.Text = this.objLanguage.GetLanguageConversion("Second_Trim");
                this.btnPrevious.Text = this.objLanguage.GetLanguageConversion("Previous");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Finish");
                this.lblimage.Text = this.objLanguage.GetLanguageConversion("Image");
                this.rdoimagetype.Items[0].Text = this.objLanguage.GetLanguageConversion("UnCommon");
                this.rdoimagetype.Items[1].Text = this.objLanguage.GetLanguageConversion("Common");
                this.ddlBookletFormat.Items[0].Text = this.objLanguage.GetLanguageConversion("Portrait");
                this.ddlBookletFormat.Items[1].Text = this.objLanguage.GetLanguageConversion("Landscape");
                this.img_UpdateDescription.Title = this.objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate");
                this.chkPortrait.Text = this.objLanguage.GetLanguageConversion("Portrait");
                this.chkLandscape.Text = this.objLanguage.GetLanguageConversion("Landscape");
                this.chkManual.Text = "Manual";
            }
            if (ConnectionClass.ProfitTaxKey != null)
            {
                this.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
            }
            if (!base.IsPostBack)
            {
                base.Session["dtinks"] = null;
            }
            this.txtsetsperpad.Attributes.Add("style", "text-align:right");
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
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
                if (base.Request.QueryString["maintype"] != null)
                {
                    this.MainType = base.Request.QueryString["maintype"].ToString();
                }
            }
            catch
            {
                this.ParentEstimateItemID = (long)0;
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
            this.txtNoOfPlates.Attributes.Add("style", "text-align:right");
            this.txtNoOfMakeReady.Attributes.Add("style", "text-align:right");
            this.ddlQualitySector.Items[0].Text = this.objLanguage.GetLanguageConversion("Low");
            this.ddlQualitySector.Items[1].Text = this.objLanguage.GetLanguageConversion("Medium");
            this.ddlQualitySector.Items[2].Text = this.objLanguage.GetLanguageConversion("High");
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
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            if (!base.IsPostBack)
            {
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    this.ChkPriceForWholePack.Checked = Convert.ToBoolean(row["DefaultPriceForWholePack"]);
                }
                DataSet dataSet = EstimatesBasePage.estimate_for_litho_add_all(this.CompanyID);
                if (dataSet.Tables[0] != null && dataSet.Tables[0].Rows.Count > 0)
                {
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
                }
                if (dataSet.Tables[1] != null && dataSet.Tables[1].Rows.Count > 0)
                {
                    this.hid_LithoPress.Value = dataSet.Tables[1].Rows[0][0].ToString();
                }
                if (dataSet.Tables[2] != null && dataSet.Tables[2].Rows.Count > 0)
                {
                    this.inkcount = Convert.ToInt32(dataSet.Tables[2].Rows[0][0].ToString());
                }
                this.inkcount = (this.inkcount > 12 ? 12 : this.inkcount);
                for (int i = 0; i <= 24; i++)
                {
                    this.ddlMakeReady.Items.Add(string.Concat(i));
                    this.ddlWashUp.Items.Add(string.Concat(i));
                    this.ddlPlates.Items.Add(string.Concat(i));
                }
                this.Bind_Press(this.ddlPress, this.CompanyID, "--- Select ---");
                this.txtNoOfPlates.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtNoOfMakeReady.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                DataTable dataTable = new DataTable();
                dataTable = EstimatesBasePage.estimate_select_paper_size(this.CompanyID);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    NCR_item usercontrolItemNCRItem = this;
                    object obj1 = usercontrolItemNCRItem.dpaperhw;
                    object[] num = new object[] { obj1, Convert.ToInt32(dataRow["PaperSizeID"].ToString()), "±", Convert.ToDecimal(dataRow["Height"].ToString()), "±", Convert.ToDecimal(dataRow["Width"].ToString()), "»" };
                    usercontrolItemNCRItem.dpaperhw = string.Concat(num);
                }
                if (string.Compare(this.QueryType, "add", true) == 0)
                {
                    this.pnlPress.Visible = true;
                    foreach (DataRow row1 in EstimatesBasePage.estimate_select_summary(this.CompanyID, this.EstimateID).Rows)
                    {
                        this.txtItemTitle.Text = this.objBase.SpecialDecode(row1["EstimateTitle"].ToString());
                    }
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        this.txtItemTitle.Text = "";
                    }
                    NCR_item.querystring = "add";
                }
            }
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                this.Pnleditmorequantity.Visible = true;
                this.select_litho_item();
                if (!base.IsPostBack)
                {
                    this.Insert_Ink_To_Session_From_DataBase();
                }
                this.btnPrevious.Visible = true;
                this.pnlgetbuttons.Visible = true;
                NCR_item.querystring = "edit";
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
            else if (!base.IsPostBack)
            {
                this.txtportrait.Text = "";
                this.txtlandscape.Text = "";
                this.txtManual.Text = "";
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

        private void select_litho_item()
        {
            DataTable dataTable = EstimatesBasePage.lithoncr_item_select(this.CompanyID, this.EstimateItemID);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in dataTable.Rows)
            {
                EstimatesItem estitem = this.Estitem;
                long num = Convert.ToInt64(row["EstimateLithoNcrItemID"]);
                long num1 = num;
                estitem.EstLithoItemID = num;
                this.EstLithoNCRItemID = num1;
                if (Convert.ToInt32(row["NcrPartsPerSet"]) != 0)
                {
                    NCR_item.GetButtonNo = row["NcrPartsPerSet"].ToString();
                    NCR_item.Partsperset = row["NcrPartsPerSet"].ToString();
                }
                else
                {
                    NCR_item.GetButtonNo = "1";
                    NCR_item.Partsperset = "1";
                }
                this.Pnleditmorequantity.Visible = true;
                this.hid_IsSheetCustom.Value = row["IsSheetCustom"].ToString();
                this.hid_IsJobCustom.Value = row["IsJobCustom"].ToString();
                if (!(row["qty2"].ToString() == "0") || !(row["qty3"].ToString() == "0") || !(row["qty4"].ToString() == "0"))
                {
                    NCR_item.checkmore = "yes";
                }
                else if (this.submodulename != "estimate")
                {
                    NCR_item.checkmore = "no";
                }
                else
                {
                    NCR_item.checkmore = "yes";
                }
                this.ItemDescription = row["ItemDescription"].ToString();
                this.hid_GuillotineID.Value = row["GuillotineID"].ToString();
                stringBuilder.AppendFormat("EstimateLithoNcrItemID»{0}±", row["EstimateLithoNcrItemID"].ToString());
                stringBuilder.AppendFormat("ItemTitle»{0}±", this.objBase.SpecialDecode(row["ItemTitle"].ToString()));
                stringBuilder.AppendFormat("Qty1»{0}±", row["qty1"].ToString());
                stringBuilder.AppendFormat("Qty2»{0}±", row["qty2"].ToString());
                stringBuilder.AppendFormat("Qty3»{0}±", row["qty3"].ToString());
                stringBuilder.AppendFormat("Qty4»{0}±", row["qty4"].ToString());
                stringBuilder.AppendFormat("PartsPerSet»{0}±", NCR_item.Partsperset);
                stringBuilder.AppendFormat("Setsperpad»{0}±", row["NcrSetsPerPad"].ToString());
                stringBuilder.AppendFormat("Sectionreference»{0}±", row["Sectionreference"].ToString());
                stringBuilder.AppendFormat("Assignedpress»{0}±", row["PressID"].ToString());
                object[] str = new object[] { row["PaperID"].ToString(), this.objBase.SpecialDecode(row["PaperName"].ToString()), row["IsPricePerPack"].ToString(), row["IsPaperSupplied"].ToString() };
                stringBuilder.AppendFormat("Paper»{0}»{1}»{2}»{3}±", str);
                stringBuilder.AppendFormat("SetupSpoilage»{0}±", Convert.ToDecimal(row["SetUpSpoilage"]));
                stringBuilder.AppendFormat("RunningSpoilage»{0}±", Convert.ToDecimal(row["RunningSpoilage"]));
                stringBuilder.AppendFormat("Plates»{0}»{1}±", row["PlateID"].ToString(), this.objBase.SpecialDecode(row["PlateName"].ToString()));
                stringBuilder.AppendFormat("NoofPlate»{0}±", row["Noofplates"]);
                stringBuilder.AppendFormat("Makeready»{0}±", row["NoofMakeReady"]);
                stringBuilder.AppendFormat("NoofWashup»{0}±", row["NoofWashup"]);
                object[] objArray = new object[] { row["PrintSheetSizeID"].ToString(), row["IsSheetCustom"].ToString(), row["SheetHeight"].ToString(), row["SheetWidth"].ToString() };
                stringBuilder.AppendFormat("SheetSize»{0}»{1}»{2}»{3}±", objArray);
                object[] str1 = new object[] { row["JobFlatSizeID"].ToString(), row["IsJobCustom"].ToString(), row["JobHeight"].ToString(), row["JobWidth"].ToString() };
                stringBuilder.AppendFormat("ItemSize»{0}»{1}»{2}»{3}±", str1);
                stringBuilder.AppendFormat("Gutters»{0}»{1}»{2}±", row["IsIncludeGutters"].ToString(), row["GutterHorizontal"].ToString(), row["GutterVertical"].ToString());
                stringBuilder.AppendFormat("PressRestrictions»{0}±", row["IsPressRestrictions"].ToString());
                object[] objArray1 = new object[] { row["PrintLayout"].ToString(), row["PortraitValue"].ToString(), row["LandscapeValue"].ToString(), row["NcrPadFormat"].ToString(), row["ManualValue"].ToString() };
                stringBuilder.AppendFormat("PrintLayout»{0}»{1}»{2}»{3}»{4}±", objArray1);
                stringBuilder.AppendFormat("Guillotine»{0}»{1}±", row["GuillotineID"].ToString(), this.objBase.SpecialDecode(row["GuillotineName"].ToString()));
                stringBuilder.AppendFormat("IsFirstTrim»{0}±", row["IsFirstTrim"].ToString());
                stringBuilder.AppendFormat("IsSecondTrim»{0}±", row["IsSecondTrim"].ToString());
                stringBuilder.AppendFormat("MakeReadyPerPlateCheck»{0}±", row["MakeReadyPerPlateCheck"].ToString());
                stringBuilder.AppendFormat("WashupChargePerColourCheck»{0}±", row["WashupChargePerColourCheck"].ToString());
                stringBuilder.AppendFormat("ImageType»{0}±", row["NcrImageType"].ToString());
                stringBuilder.AppendFormat("CommonFrom»{0}±", row["NcrCommonFrom"].ToString());
                object[] str2 = new object[] { row["sidesprinted"].ToString(), row["side1Color"].ToString(), row["side2Color"].ToString(), row["WorknTurn"].ToString(), row["WorknTumble"].ToString(), row["perfecting"].ToString() };
                stringBuilder.AppendFormat("Colour»{0}»{1}»{2}»{3}»{4}»{5}±", str2);
                stringBuilder.AppendFormat("EstimateCalculationID»{0}±", row["EstimateCalculationID"].ToString());
                stringBuilder.AppendFormat("InkType»{0}±", row["InkType"].ToString());
                stringBuilder.AppendFormat("isPressPerfect»{0}±", row["isPressPerfect"].ToString());
                stringBuilder.AppendFormat("PaperWeight»{0}±", row["PaprWeight"].ToString());
                stringBuilder.Append("µ");
                if (base.IsPostBack)
                {
                    continue;
                }
                HiddenField hiddenField = this.hdnOldPressID;
                string value = hiddenField.Value;
                string[] strArrays = new string[] { value, this.EstLithoNCRItemID.ToString(), "~", row["PressID"].ToString(), "," };
                hiddenField.Value = string.Concat(strArrays);
                HiddenField hiddenField1 = this.hdnOldPaperID;
                string value1 = hiddenField1.Value;
                string[] strArrays1 = new string[] { value1, this.EstLithoNCRItemID.ToString(), "~", row["PaperID"].ToString(), "," };
                hiddenField1.Value = string.Concat(strArrays1);
                HiddenField hiddenField2 = this.hdnOldGuillotineID;
                string value2 = hiddenField2.Value;
                string[] strArrays2 = new string[] { value2, this.EstLithoNCRItemID.ToString(), "~", row["GuillotineID"].ToString(), "," };
                hiddenField2.Value = string.Concat(strArrays2);
                HiddenField hdnIsPaperUnitPriceLocked = this.hdn_IsPaperUnitPriceLocked;
                string value3 = hdnIsPaperUnitPriceLocked.Value;
                string[] str3 = new string[] { value3, this.EstLithoNCRItemID.ToString(), "~", row["IsPaperUnitPriceLocked"].ToString(), "," };
                hdnIsPaperUnitPriceLocked.Value = string.Concat(str3);
            }
            this.hid_ncreditdata.Value = stringBuilder.ToString();
            this.pnlncredit.Visible = true;
            DataTable dataTable1 = EstimatesBasePage.estimate_qty_select(this.CompanyID, this.EstimateItemID, this.EstLithoNCRItemID);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                int num2 = Convert.ToInt32(dataRow["Qty1"]);
                int num3 = Convert.ToInt32(dataRow["Qty2"]);
                int num4 = Convert.ToInt32(dataRow["Qty3"]);
                int num5 = Convert.ToInt32(dataRow["Qty4"]);
                if (num2 != 0)
                {
                    this.txtQuantity.Text = num2.ToString();
                }
                if (num3 != 0)
                {
                    this.txtQuantity_2.Text = num3.ToString();
                    this.str_QtyType = "more";
                }
                if (num4 != 0)
                {
                    this.txtQuantity_3.Text = num4.ToString();
                    this.str_QtyType = "more";
                }
                if (num5 == 0)
                {
                    continue;
                }
                this.txtQuantity_4.Text = num5.ToString();
                this.str_QtyType = "more";
            }
            this.QtyNo = this.GetQtyNo();
        }

        public string splititemdescription(string itemdescription, long EstimateItemID, int count, string Sectionreference)
        {
            string empty = string.Empty;
            string[] strArrays = itemdescription.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                if (strArrays1[0].ToLower().Trim() == "itemtitle")
                {
                    string str = empty;
                    string[] strArrays2 = new string[] { str, "ItemTitle»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays2);
                }
                if (strArrays1[0].ToLower().Trim() == "description")
                {
                    string str1 = empty;
                    string[] strArrays3 = new string[] { str1, "µDescription»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays3);
                }
                if (strArrays1[0].ToLower().Trim() == "artwork")
                {
                    string str2 = empty;
                    string[] strArrays4 = new string[] { str2, "µArtwork»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays4);
                }
                if (strArrays1[0].ToLower().Trim() == "colour")
                {
                    string str3 = empty;
                    string[] strArrays5 = new string[] { str3, "µColour»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", EstimatesBasePage.TakeLithoInkDetails("", "N", EstimateItemID, (long)0, (long)0, count, Sectionreference, this.CompanyID), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays5);
                }
                if (strArrays1[0].ToLower().Trim() == "size")
                {
                    string str4 = empty;
                    string[] strArrays6 = new string[] { str4, "µSize»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays6);
                }
                if (strArrays1[0].ToLower().Trim() == "material")
                {
                    string str5 = empty;
                    string[] strArrays7 = new string[] { str5, "µMaterial»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays7);
                }
                if (strArrays1[0].ToLower().Trim() == "delivery")
                {
                    string str6 = empty;
                    string[] strArrays8 = new string[] { str6, "µDelivery»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays8);
                }
                if (strArrays1[0].ToLower().Trim() == "finishing")
                {
                    string str7 = empty;
                    string[] strArrays9 = new string[] { str7, "µFinishing»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays9);
                }
                if (strArrays1[0].ToLower().Trim() == "notes")
                {
                    string str8 = empty;
                    string[] strArrays10 = new string[] { str8, "µNotes»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays10);
                }
                if (strArrays1[0].ToLower().Trim() == "instructions")
                {
                    string str9 = empty;
                    string[] strArrays11 = new string[] { str9, "µInstructions»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays11);
                }
                if (strArrays1[0].ToLower().Trim() == "proofs")
                {
                    string str10 = empty;
                    string[] strArrays12 = new string[] { str10, "µProofs»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays12);
                }
                if (strArrays1[0].ToLower().Trim() == "packing")
                {
                    string str11 = empty;
                    string[] strArrays13 = new string[] { str11, "µPacking»", this.objBase.ReplaceSingleQuote(strArrays1[1]), "»", this.objBase.ReplaceSingleQuote(strArrays1[2]), "»", strArrays1[3].Trim() };
                    empty = string.Concat(strArrays13);
                }
            }
            return empty;
        }

        private void Update_Single_Item()
        {
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            estimatesItem.EstimateItemID = (long)0;
            estimatesItem.EstQuantityID = (long)0;
            this.EstType = "N";
            string empty = string.Empty;
            bool @checked = this.chkPortrait.Checked;
            this.txtGutterHorizontal.Text = (this.txtGutterHorizontal.Text == "" ? "0" : this.txtGutterHorizontal.Text);
            this.txtGutterVertical.Text = (this.txtGutterVertical.Text == "" ? "0" : this.txtGutterVertical.Text);
            this.txtportrait.Text = (this.txtportrait.Text == "" ? "0" : this.txtportrait.Text);
            this.txtlandscape.Text = (this.txtlandscape.Text == "" ? "0" : this.txtlandscape.Text);
            this.txtManual.Text = (this.txtManual.Text == "" ? "0" : this.txtManual.Text);
            estimatesItem.EstimateItemID = this.EstimateItemID;
            if (Convert.ToDecimal(this.hidpartsperset.Value) < Convert.ToDecimal(NCR_item.Partsperset))
            {
                decimal num = Convert.ToDecimal(NCR_item.Partsperset) - Convert.ToDecimal(this.hidpartsperset.Value);
                EstimatesBasePage.deletencrsection(this.EstimateItemID, Convert.ToInt32(num));
            }
            if (this.txtsetsperpad.Text != "")
            {
                this.setsperpad = Convert.ToDouble(this.txtsetsperpad.Text);
            }
            EstimatesBasePage.Ink_Delete_BasedOn_estimateitemID(this.EstimateItemID);
            string[] strArrays = this.hid_ncrdata.Value.Split(new char[] { 'µ' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(strArrays[i]))
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                        if (strArrays2[0].Trim() == "Title")
                        {
                            estimatesItem.NCRItemTitle = (strArrays2[1].Trim() == "" ? "0" : strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Quantity1")
                        {
                            estimatesItem.NCRQuantity1 = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Quantity2")
                        {
                            estimatesItem.NCRQuantity2 = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Quantity3")
                        {
                            estimatesItem.NCRQuantity3 = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Quantity4")
                        {
                            estimatesItem.NCRQuantity4 = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Partsperset")
                        {
                            estimatesItem.NCRPartsperset = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Setsperpad")
                        {
                            estimatesItem.NCRSetsperpad = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Sectionreference")
                        {
                            estimatesItem.NCRSectionreference = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Assignedpress")
                        {
                            estimatesItem.NCRAssignedpress = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "PaperID")
                        {
                            estimatesItem.NCRPaperID = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "PaperName")
                        {
                            estimatesItem.NCRPaperName = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "PriceForWhaolePack")
                        {
                            estimatesItem.NCRPriceForWhaolePack = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PaperSupplied")
                        {
                            estimatesItem.NCRPaperSupplied = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Setupspoilage")
                        {
                            estimatesItem.NCRSetupspoilage = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Runningspoilage")
                        {
                            estimatesItem.NCRRunningspoilage = Convert.ToDecimal(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Noofsidesprinted")
                        {
                            estimatesItem.NCRNoofsidesprinted = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Side1color")
                        {
                            estimatesItem.NCRSide1color = (strArrays2[1].Trim() == "undefined" ? "" : strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Side2color")
                        {
                            estimatesItem.NCRSide2color = (strArrays2[1].Trim() == "undefined" ? "" : strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "Checkturn")
                        {
                            estimatesItem.NCRCheckturn = (strArrays2[1].Trim() == "undefined" ? false : Convert.ToBoolean(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Checktumble")
                        {
                            estimatesItem.NCRChecktumble = (strArrays2[1].Trim() == "undefined" ? false : Convert.ToBoolean(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Platename")
                        {
                            estimatesItem.NCRPlatename = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "PlateID")
                        {
                            estimatesItem.NCRPlateID = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Plate")
                        {
                            estimatesItem.NCRPlate = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Makeready")
                        {
                            estimatesItem.NCRMakeready = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Washup")
                        {
                            estimatesItem.NCRWashup = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "PrintSheetSizeID")
                        {
                            estimatesItem.NCRPrintSheetSizeID = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "IsPrintCustom")
                        {
                            estimatesItem.NCRIsPrintCustom = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PrintSheetHeight")
                        {
                            estimatesItem.NCRPrintSheetHeight = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "PrintSheetWidth")
                        {
                            estimatesItem.NCRPrintSheetWidth = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "JobFlatSizeID")
                        {
                            estimatesItem.NCRJobFlatSizeID = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "IsJobCustom")
                        {
                            estimatesItem.NCRIsJobCustom = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "JobFlatSizeHeight")
                        {
                            estimatesItem.NCRJobFlatSizeHeight = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "JobFlatSizeWidth")
                        {
                            estimatesItem.NCRJobFlatSizeWidth = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "IsIncludeGutters")
                        {
                            estimatesItem.NCRIsIncludeGutters = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "GutterHorizontal")
                        {
                            estimatesItem.NCRGutterHorizontal = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "GutterVertical")
                        {
                            estimatesItem.NCRGutterVertical = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "IsPressRestrictions")
                        {
                            estimatesItem.NCRIsPressRestrictions = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "GuilotineID")
                        {
                            estimatesItem.NCRGuilotineID = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "GuilotineName")
                        {
                            estimatesItem.NCRGuilotineName = strArrays2[0].Trim();
                        }
                        else if (strArrays2[0].Trim() == "IsFirstTrim")
                        {
                            estimatesItem.NCRIsFirstTrim = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "IsSecondTrim")
                        {
                            estimatesItem.NCRIsSecondTrim = Convert.ToBoolean(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "PrintLayout")
                        {
                            estimatesItem.NCRPrintLayout = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "Portraitvalue")
                        {
                            estimatesItem.NCRPortraitvalue = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Landscapevalue")
                        {
                            estimatesItem.NCRLandscapevalue = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "ManualValue")
                        {
                            estimatesItem.ManualValue = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "Ncrcommonuncommon")
                        {
                            if (i != 0)
                            {
                                estimatesItem.Ncrcommonuncommon = strArrays2[1].Trim();
                            }
                            else
                            {
                                estimatesItem.Ncrcommonuncommon = "uncommon";
                            }
                        }
                        else if (strArrays2[0].Trim() == "Ncrcommonfrom")
                        {
                            estimatesItem.NCRNcommonfrom = strArrays2[1].Trim();
                        }
                        else if (strArrays2[0].Trim() == "EstimateLithoNCRItemID")
                        {
                            estimatesItem.EstimateLithoNCRItemID = (strArrays2[1].Trim() == "" ? 0 : Convert.ToInt32(strArrays2[1].Trim()));
                        }
                        else if (strArrays2[0].Trim() == "EstimateCalculationID")
                        {
                            estimatesItem.EstimateCalculationID = Convert.ToInt32(strArrays2[1].Trim());
                        }
                        else if (strArrays2[0].Trim() == "CheckPerfecting")
                        {
                            estimatesItem.NCRCheckPerfecting = (strArrays2[1].Trim() == "undefined" ? false : Convert.ToBoolean(strArrays2[1].Trim()));
                        }
                    }
                    string str = string.Empty;
                    if (chkManual.Checked)
                    {
                        str = "Manual";
                    }
                    else
                    {
                        str = (this.ddlBookletFormat.SelectedValue != "P" ? "Landscape" : "Portrait");
                    }
                    this.estlithoncritemid = EstimatesBasePage.estimate_litho_NCR_item_insert(this.CompanyID, estimatesItem.EstimateLithoNCRItemID, this.EstimateItemID, Convert.ToInt64(estimatesItem.NCRAssignedpress), Convert.ToInt64(estimatesItem.NCRPaperID), estimatesItem.NCRPriceForWhaolePack, estimatesItem.NCRPaperSupplied, Convert.ToDecimal(estimatesItem.NCRSetupspoilage), Convert.ToDecimal(estimatesItem.NCRRunningspoilage), estimatesItem.NCRNoofsidesprinted, estimatesItem.NCRSide1color, estimatesItem.NCRSide2color, Convert.ToInt64(estimatesItem.NCRPlateID), estimatesItem.NCRPlate, estimatesItem.NCRMakeready, estimatesItem.NCRWashup, Convert.ToInt32(estimatesItem.NCRPrintSheetSizeID), estimatesItem.NCRIsPrintCustom, Convert.ToDecimal(estimatesItem.NCRPrintSheetHeight), Convert.ToDecimal(estimatesItem.NCRPrintSheetWidth), Convert.ToInt32(estimatesItem.NCRJobFlatSizeID), estimatesItem.NCRIsJobCustom, Convert.ToDecimal(estimatesItem.NCRJobFlatSizeHeight), Convert.ToDecimal(estimatesItem.NCRJobFlatSizeWidth), estimatesItem.NCRIsIncludeGutters, Convert.ToDecimal(estimatesItem.NCRGutterHorizontal), Convert.ToDecimal(estimatesItem.NCRGutterVertical), estimatesItem.NCRIsPressRestrictions, Convert.ToInt64(estimatesItem.NCRGuilotineID), Convert.ToInt32(base.Session["UserID"]), 0, DateTime.Now, Convert.ToBoolean(false), estimatesItem.NCRItemTitle, this.ItemDescription, estimatesItem.NCRIsFirstTrim, estimatesItem.NCRIsSecondTrim, estimatesItem.NCRCheckturn, estimatesItem.NCRChecktumble, 0, "N", estimatesItem.NCRSectionreference, Convert.ToDecimal(estimatesItem.NCRPartsperset), Convert.ToDecimal(estimatesItem.NCRSetsperpad), estimatesItem.Ncrcommonuncommon, str, estimatesItem.NCRPrintLayout, Convert.ToDecimal(estimatesItem.NCRPortraitvalue), Convert.ToDecimal(estimatesItem.NCRLandscapevalue), estimatesItem.NCRNcommonfrom, estimatesItem.NCRCheckPerfecting, estimatesItem.ManualValue,this.chkSheetWork.Checked);
                    string str1 = "N";
                    this.PressID = Convert.ToInt64(estimatesItem.NCRAssignedpress);
                    if (estimatesItem.NCRSide2color != "")
                    {
                        this.side2color = Convert.ToInt32(estimatesItem.NCRSide2color);
                    }
                    if (estimatesItem.EstimateLithoNCRItemID != 0)
                    {
                        this.Popup_inkvalue_insert(this.EstimateItemID, "", this.PressID, estimatesItem.NCRNoofsidesprinted, this.EstType, (long)estimatesItem.EstimateLithoNCRItemID, this.partcount, Convert.ToInt32(estimatesItem.NCRSide1color), this.side2color, "update");
                    }
                    else
                    {
                        this.Popup_inkvalue_insert(this.EstimateItemID, "", this.PressID, estimatesItem.NCRNoofsidesprinted, this.EstType, this.estlithoncritemid, this.partcount, Convert.ToInt32(estimatesItem.NCRSide1color), this.side2color, "update");
                    }
                    if (estimatesItem.EstimateLithoNCRItemID == 0)
                    {
                        estimatesItem.GuillotineID = Convert.ToInt64(this.hid_GuillotineID.Value);
                        estimatesItem.PressType = 'S';
                        estimatesItem.PaperID = Convert.ToInt64(this.hdnpaperID.Value);
                        this.PressID = Convert.ToInt64(estimatesItem.NCRAssignedpress);
                        estimatesItem.NCRSide1color = (estimatesItem.NCRSide1color == "" ? "0" : estimatesItem.NCRSide1color);
                        estimatesItem.NCRSide2color = (estimatesItem.NCRSide2color == "" ? "0" : estimatesItem.NCRSide2color);
                        this.Estimate_Calcukation(this.EstimateItemID, this.estlithoncritemid, (long)estimatesItem.NCRPaperID, this.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, this.EstType, estimatesItem.NCRNoofsidesprinted, estimatesItem.NCRCheckturn, estimatesItem.NCRChecktumble, Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), Convert.ToInt32(estimatesItem.NCRPlateID));
                    }
                    else
                    {
                        estimatesItem.NCRSide1color = (estimatesItem.NCRSide1color == "" ? "0" : estimatesItem.NCRSide1color);
                        estimatesItem.NCRSide2color = (estimatesItem.NCRSide2color == "" ? "0" : estimatesItem.NCRSide2color);
                        this.Estimate_Calcukation_Update(this.EstimateItemID, Convert.ToInt64(estimatesItem.EstimateLithoNCRItemID), Convert.ToInt64(estimatesItem.NCRPaperID), Convert.ToInt64(estimatesItem.NCRAssignedpress), 'S', Convert.ToInt64(estimatesItem.NCRGuilotineID), str1, estimatesItem.NCRNoofsidesprinted, estimatesItem.NCRCheckturn, estimatesItem.NCRChecktumble, (long)estimatesItem.EstimateCalculationID, Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), Convert.ToInt32(estimatesItem.NCRPlateID), Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), Convert.ToString(estimatesItem.NCRNoofsidesprinted));
                    }
                    if (estimatesItem.EstimateLithoNCRItemID == 0)
                    {
                        this.Main_Quantity_Insert(this.EstimateItemID, "qty", estimatesItem.NCRQuantity1, estimatesItem.NCRQuantity2, estimatesItem.NCRQuantity3, estimatesItem.NCRQuantity4, this.estlithoncritemid, estimatesItem, this.partcount);
                    }
                    else
                    {
                        this.Main_Quantity_Insert(this.EstimateItemID, "updatebookqty", estimatesItem.NCRQuantity1, estimatesItem.NCRQuantity2, estimatesItem.NCRQuantity3, estimatesItem.NCRQuantity4, (long)estimatesItem.EstimateLithoNCRItemID, estimatesItem, this.partcount);
                    }
                }
                NCR_item usercontrolItemNCRItem = this;
                usercontrolItemNCRItem.partcount = usercontrolItemNCRItem.partcount + 1;
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
            if (this.Chk_ItemDescn.Checked)
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "N", true);
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
                DataTable dataTable = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "N");
                if (dataTable.Rows.Count > 0)
                {
                    dataTable.Rows[0]["PricecatalogueID"].ToString();
                    if (num1 == 1 || num1 == 2)
                    {
                        EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "N", num1);
                    }
                }
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                JobBasePage.Update_EstimateJobTime(this.EstimateItemID, this.JobTimeSumEdit);
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "N");
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
            EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "N");
            string empty1 = string.Empty;
            if (this.modulename == "invoice")
            {
                empty1 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            else if (this.modulename == "jobs")
            {
                empty1 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
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
                if (empty1.ToString().ToLower() == "yes")
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
            if (empty1.ToString().ToLower() == "yes")
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