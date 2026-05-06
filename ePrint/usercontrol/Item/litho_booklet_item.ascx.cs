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
    public partial class litho_booklet_item : UsercontrolBasePage
    {
        //protected usercontrol_settings_Loading ucLoading;

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

        //protected Label Label5;

        //protected TextBox txtSectionRef;

        //protected Label Label9;

        //protected DropDownList ddlPress;

        //protected LinkButton lnk_ddlPress_OnChange;

        //protected UpdatePanel updatepresschangeid;

        //protected HiddenField hid_PressID;

        //protected HiddenField hid_PressChange;

        //protected HiddenField hid_SessionPressChange;

        //protected HiddenField hid_SectionCount;

        //protected HiddenField hid_PresntSection;

        //protected HiddenField hid_DigitalPress;

        //protected HiddenField hid_LithoPress;

        //protected HiddenField hid_LithoPress_all;

        //protected HiddenField hid_LargeFormatPress;

        //protected HiddenField hid_DefaultDigitalPress;

        //protected HiddenField hid_DefaultLargePress;

        //protected HiddenField hid_IsJobCustom;

        //protected HiddenField hid_IsSheetCustom;

        //protected HiddenField hdnedit_Default;

        //protected HiddenField hid_isPressPerfect;

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

        //protected Label Label4;

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

        //protected HiddenField hid_FinalInkSave1;

        //protected HiddenField hid_FinalInkSave2;

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

        //protected Label Label3;

        //protected HtmlImage Img_ItemDescnHelp;

        //protected HtmlAnchor img_Update_Descriptipn;

        //protected CheckBox Chk_ItemDescn;

        //protected HtmlGenericControl Div_ItemDescn;

        //protected Label Label17;

        //protected HtmlImage Img1;

        //protected CheckBox chkPoduct1;

        //protected CheckBox chkPoduct2;

        //protected HtmlGenericControl Div_Productcatalogue;

        //protected Button btnStage2_Previous;

        //protected HtmlGenericControl divprevious;

        //protected Button Button14;

        //protected LinkButton lnkNewSection;

        //protected UpdatePanel UpdatePanel1;

        //protected Button Button16;

        //protected HiddenField hid_DeletedID;

        //protected UpdatePanel UpBookletDelete;

        //protected Button btnSave;

        //protected RadWindowManager RadWindowManager1;

        //protected HiddenField hid_singleData;

        //protected HiddenField hid_booklet_save;

        //protected HiddenField hid_makeready;

        //protected HiddenField hid_washup;

        //protected HiddenField hid_value;

        //protected HiddenField hdn_InkType;

        //protected HiddenField hdnOldPressID;

        //protected HiddenField hdnOldPaperID;

        //protected HiddenField hdnOldGuillotineID;

        //protected HiddenField hdn_invStockReduce;

        //protected HiddenField hdn_IsPaperUnitPriceLocked;

        //protected HiddenField hid_bookletData;

        //protected Panel pnlBookletEdit;

        //protected Panel pnlPress;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        private commonClass commclass = new commonClass();

        private commonClass objJava = new commonClass();

        public languageClass objLanguage = new languageClass();

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

        public string EstimateCalculationIDs = string.Empty;

        private int IDCount;

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

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        private EstimatesBasePage objest = new EstimatesBasePage();

        private SummaryClass summryCls = new SummaryClass();

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public string modulename = "estimates";

        public string submodulename = "estimate";

        private string ItemDescription_0 = string.Empty;

        public string FromItemDescription = string.Empty;

        public string itemdescription = string.Empty;

        public string dpaperhw = string.Empty;

        public double subtotal1;

        public double subtotal2;

        public double subtotal3;

        public double subtotal4;

        public string PaperMeasure = string.Empty;

        public int partcount = 1;

        public string frmcopyitem = string.Empty;

        public int QtyNo;

        public string MainType = string.Empty;

        public int IsItemCompleted;

        private string EstimateLithobookletitemid_old = string.Empty;

        private string EstimateLithobookletitemid_new = string.Empty;

        public string ProfitTaxKey = string.Empty;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public int IsProductCreated;

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

        public litho_booklet_item()
        {
        }

        protected void Bind_Press(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            DataTable dataTable = EstimatesBasePage.estimate_press_select(sqlParameter1);
            ddl.DataSource = dataTable;
            ddl.DataTextField = "PressName";
            ddl.DataValueField = "PressID";
            ddl.DataBind();
            foreach (DataRow row in dataTable.Rows)
            {
                if (string.Compare(this.QueryType, "add", true) != 0 || !Convert.ToBoolean(row["IsDefaultPress"].ToString()))
                {
                    continue;
                }
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(row["PressName"].ToString()));
                break;
            }
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        protected void btn_Delete(object sender, EventArgs e)
        {
            long num = (long)0;
            try
            {
                num = Convert.ToInt64(this.hid_DeletedID.Value);
                if (num != (long)0 && base.Session["dtinks"] != null)
                {
                    DataTable dataTable = new DataTable();
                    dataTable = (DataTable)base.Session["dtinks"];
                    DataRow[] dataRowArray = dataTable.Select(string.Concat("LithoTypeID='", num, "'"));
                    if ((int)dataRowArray.Length > 0)
                    {
                        dataTable.Rows.Remove(dataRowArray[0]);
                    }
                    DataRow[] dataRowArray1 = dataTable.Select(string.Concat("LithoTypeID='", num, "'"));
                    if ((int)dataRowArray1.Length > 0)
                    {
                        dataTable.Rows.Remove(dataRowArray1[0]);
                    }
                }
                int num1 = Convert.ToInt32(this.hid_PresntSection.Value);
                int num2 = Convert.ToInt32(this.hid_SectionCount.Value) + 1;
                if (num1 <= num2 && base.Session["dtinks"] != null)
                {
                    DataTable item = new DataTable();
                    item = (DataTable)base.Session["dtinks"];
                    if (num == (long)0)
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            object[] objArray = new object[] { "SectionName='Parts", num1, "' and sidenumber='side", i, "'" };
                            DataRow[] dataRowArray2 = item.Select(string.Concat(objArray));
                            if ((int)dataRowArray2.Length > 0)
                            {
                                item.Rows.Remove(dataRowArray2[0]);
                            }
                        }
                    }
                    for (int j = num1 + 1; j <= num2; j++)
                    {
                        for (int k = 1; k <= 2; k++)
                        {
                            string empty = string.Empty;
                            string str = string.Empty;
                            string empty1 = string.Empty;
                            string str1 = string.Empty;
                            string empty2 = string.Empty;
                            string str2 = string.Empty;
                            string str3 = "0";
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
                            string empty12 = string.Empty;
                            object[] objArray1 = new object[] { "SectionName='Parts", j, "' and sidenumber='side", k, "'" };
                            DataRow[] dataRowArray3 = item.Select(string.Concat(objArray1));
                            if ((int)dataRowArray3.Length > 0)
                            {
                                DataRow[] dataRowArray4 = dataRowArray3;
                                for (int l = 0; l < (int)dataRowArray4.Length; l++)
                                {
                                    DataRow dataRow = dataRowArray4[l];
                                    empty = string.Concat("Parts", j - 1);
                                    str = dataRow["InkID"].ToString();
                                    str1 = dataRow["InkCoverage"].ToString();
                                    empty2 = dataRow["SidesPrinted"].ToString();
                                    str2 = dataRow["SideNumber"].ToString();
                                    empty1 = dataRow["InkName"].ToString();
                                    str3 = dataRow["LithoTypeID"].ToString();
                                    empty3 = dataRow["InkCostExMarkup1"].ToString();
                                    empty4 = dataRow["InkCostExMarkup2"].ToString();
                                    str4 = dataRow["InkCostExMarkup3"].ToString();
                                    empty5 = dataRow["InkCostExMarkup4"].ToString();
                                    str5 = dataRow["InkMarkup1"].ToString();
                                    empty6 = dataRow["InkMarkup2"].ToString();
                                    str6 = dataRow["InkMarkup3"].ToString();
                                    empty7 = dataRow["InkMarkup4"].ToString();
                                    str7 = dataRow["InkMarkupPrice1"].ToString();
                                    empty8 = dataRow["InkMarkupPrice2"].ToString();
                                    str8 = dataRow["InkMarkupPrice3"].ToString();
                                    empty9 = dataRow["InkMarkupPrice4"].ToString();
                                    str9 = dataRow["InkSetupCharge"].ToString();
                                    empty10 = dataRow["InkMinimumCharge"].ToString();
                                    str10 = dataRow["InkCostExMarkup_Actual1"].ToString();
                                    empty11 = dataRow["InkCostExMarkup_Actual2"].ToString();
                                    str11 = dataRow["InkCostExMarkup_Actual3"].ToString();
                                    empty12 = dataRow["InkCostExMarkup_Actual4"].ToString();
                                }
                                item.Rows.Remove(dataRowArray3[0]);
                                object[] objArray2 = new object[] { empty, str, str1, empty2, str2, empty1, str3, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11, empty12 };
                                item.Rows.Add(objArray2);
                            }
                        }
                    }
                }
            }
            catch
            {
                num = (long)0;
            }
            if (num != (long)0)
            {
                EstimatesBasePage.booklet_delete(this.CompanyID, num, "K");
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
                if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                {
                    if (empty.ToString().ToLower() != "yes")
                    {
                        HttpResponse response1 = base.Response;
                        object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID1));
                    }
                    else
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray1));
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
                HttpResponse response2 = base.Response;
                object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=K&maintype=", this.MainType, this.jID, this.InvID };
                response2.Redirect(string.Concat(estimateID2));
            }
            else
            {
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                    httpResponse2.Redirect(string.Concat(objArray2));
                }
                if (base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                {
                    HttpResponse response3 = base.Response;
                    object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, this.jID, this.InvID };
                    response3.Redirect(string.Concat(estimateID3));
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
            base.Session["dtinks"] = null;
            if (this.QueryType == "add" && EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "K") > (long)0)
            {
                foreach (DataRow row in EstimatesBasePage.lithobooklet_item_select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    this.EstBookletItemID = Convert.ToInt64(row["EstimateLithoBookletItemID"]);
                }
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", this.EstimateItemID, "&booksecid=", this.EstBookletItemID, " &parentesttype=K&maintype=edit&subitem=s", this.jID, this.InvID };
                response.Redirect(string.Concat(estimateID));
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
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (empty.ToString().ToLower() == "yes")
            {
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            HttpResponse httpResponse1 = base.Response;
            object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
            httpResponse1.Redirect(string.Concat(objArray1));
        }

        private void Click_Add()
        {
            string empty = string.Empty;
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            estimatesItem.EstimateItemID = (long)0;
            estimatesItem.EstQuantityID = (long)0;
            empty = "K";
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
                        this.PressID = Convert.ToInt64(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PressType")
                    {
                        estimatesItem.PressType = 'S';
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
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.SetupSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "RunningSpoilage")
                    {
                        estimatesItem.LithoBookletRunningSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
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
                        estimatesItem.SheetHeight = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                    }
                    else if (strArrays2[0].Trim() == "PrintSheetWidth")
                    {
                        estimatesItem.SheetWidth = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
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
                        estimatesItem.JobHeight = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                    }
                    else if (strArrays2[0].Trim() == "JobFlatSizeWidth")
                    {
                        estimatesItem.JobWidth = (strArrays2[1].Trim() == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                    }
                    else if (strArrays2[0].Trim() == "IsIncludeGutters")
                    {
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
                        estimatesItem.ManualValue = (string.IsNullOrEmpty(strArrays2[1].Trim()) ? new decimal(0) : Convert.ToDecimal(strArrays2[1].Trim()));
                    }
                    else if (strArrays2[0].Trim() == "GuilotineID")
                    {
                        stringBuilder.Append(string.Concat(strArrays2[1], ","));
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
                    else if (strArrays2[0].Trim() == "EstimateLithoBookletItemID")
                    {
                        estimatesItem.EstimateLithoBookletItemID = (long)0;
                    }
                    else if (strArrays2[0].Trim() == "BookletFormat")
                    {
                        estimatesItem.BookletFormat = strArrays2[1].Trim();
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
                        estimatesItem.NCRCheckturn = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "Checktumble")
                    {
                        estimatesItem.NCRChecktumble = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "CheckPerfecting")
                    {
                        estimatesItem.NCRCheckPerfecting = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "ChkSheetWork")
                    {
                        estimatesItem.NCRChkSheetWork = Convert.ToBoolean(strArrays2[1].Trim());
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
                        estimatesItem.NoofMakeReady = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "Washup")
                    {
                        estimatesItem.NCRWashup = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "NCRside1inkvalue")
                    {
                        this.hid_FinalInkSave1.Value = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "NCRside2inkvalue")
                    {
                        this.hid_FinalInkSave2.Value = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "QtyList")
                    {
                        estimatesItem.CreatedBy = Convert.ToInt32(base.Session["UserID"]);
                        estimatesItem.ModifiedBy = 0;
                        estimatesItem.IsDeleted = false;
                        estimatesItem.CreatedDate = DateTime.Now;
                        estimatesItem.ModifiedDate = DateTime.Now;
                        estimatesItem.ItemTitle = this.Objclss.SpecialEncode(this.txtItemTitle.Text);
                        long num6 = EstimatesBasePage.Lithobooklet_item_insert(estimatesItem);
                        this.PressID = Convert.ToInt64(estimatesItem.PressID);
                        this.Popup_inkvalue_insert(this.EstimateItemID, "", this.PressID, estimatesItem.NCRNoofsidesprinted, empty, num6, this.partcount, Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), "add");
                        estimatesItem.NCRSide1color = (estimatesItem.NCRSide1color == "" ? "0" : estimatesItem.NCRSide1color);
                        estimatesItem.NCRSide2color = (estimatesItem.NCRSide2color == "" ? "0" : estimatesItem.NCRSide2color);
                        double num7 = 0;
                        foreach (DataRow row in EstimatesBasePage.SelectPlateunitprice_eachSectin(Convert.ToInt32(estimatesItem.NCRPlateID)).Rows)
                        {
                            num7 = Convert.ToDouble(row["PlateUnitPrice"]);
                        }
                        this.Estimate_Calcukation(this.EstimateItemID, num6, estimatesItem.PaperID, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, empty, estimatesItem.NCRNoofsidesprinted, estimatesItem.NCRCheckturn, estimatesItem.NCRChecktumble, Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), num7);
                        this.Main_Quantity_Insert(estimatesItem.EstimateItemID, num6, strArrays2[1].ToString(), "qty", estimatesItem, this.partcount);
                    }
                }
                litho_booklet_item usercontrolItemLithoBookletItem = this;
                usercontrolItemLithoBookletItem.partcount = usercontrolItemLithoBookletItem.partcount + 1;
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "K", false);
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                JobBasePage.Job_Jobcard_Insert_NewItem_JOBTIME(this.CompanyID, this.EstimateItemID, 1, this.EstimateID, this.JobTimeSumAdd);
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, empty);
                string empty1 = string.Empty;
                foreach (DataRow dataRow in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty1 = dataRow["StatusID"].ToString();
                }
                if (string.Compare(this.modulename, "jobs", true) == 0)
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
        }

        protected void ddlPress_OnChange(object sender, EventArgs e)
        {
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                string str = "";
                string str1 = "";
                string str2 = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
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
                DataTable dataTable = new DataTable();
                string lower = this.ddlNoOfSide.SelectedValue.ToLower();
                Convert.ToInt32(this.ddlSide1Color.SelectedValue);
                Convert.ToInt32(this.ddlSide2Color.SelectedValue);
                this.PressID = Convert.ToInt64(this.ddlPress.SelectedValue);
                string str12 = lower;
                short num = 0;
                string[] strArrays = this.EstimateLithobookletitemid_old.Split(new char[] { '~' });
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
                    dataTable.Columns.Add("LithoTypeID", typeof(string));
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
                int num1 = Convert.ToInt16(this.hid_SectionCount.Value);
                int num2 = Convert.ToInt16(this.hid_PresntSection.Value);
                for (int i = 1; i <= num1; i++)
                {
                    if (num2 == i)
                    {
                        if (string.Compare(this.QueryType, "edit", true) != 0)
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = ((int)strArrays.Length <= 0 || !(strArrays[i - 1] != "") ? "0" : strArrays[i - 1]);
                        }
                        empty = string.Concat("Parts", i);
                        if (lower.ToLower().Trim() == "single")
                        {
                            empty1 = "side1";
                            int num3 = 0;
                            foreach (DataRow row in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                            {
                                num = Convert.ToInt16(row["DefaultColour"].ToString());
                                Convert.ToInt16(row["rownumber"].ToString());
                                if (num <= num3)
                                {
                                    continue;
                                }
                                str = string.Concat(str, row["InkID"].ToString(), "±");
                                str1 = string.Concat(str1, row["InkCoverage"].ToString(), "±");
                                str2 = string.Concat(str2, row["InkName"].ToString(), "±");
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
                                str11 = string.Concat(str11, "0±");
                                num3++;
                            }
                            string[] strArrays1 = new string[] { "SectionName='", empty, "' and sidenumber='", empty1, "'" };
                            DataRow[] dataRowArray = dataTable.Select(string.Concat(strArrays1));
                            if ((int)dataRowArray.Length > 0)
                            {
                                dataTable.Rows.Remove(dataRowArray[0]);
                            }
                            object[] objArray = new object[] { empty, str, str1, str12, empty1, str2, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                            dataTable.Rows.Add(objArray);
                            str = "";
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
                        }
                        else if (lower.ToLower().Trim() == "double")
                        {
                            int num4 = 0;
                            int num5 = 0;
                            foreach (DataRow dataRow in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                            {
                                num = Convert.ToInt16(dataRow["DefaultColour"].ToString());
                                Convert.ToInt16(dataRow["rownumber"].ToString());
                                if (num <= num4)
                                {
                                    continue;
                                }
                                str = string.Concat(str, dataRow["InkID"].ToString(), "±");
                                str1 = string.Concat(str1, dataRow["InkCoverage"].ToString(), "±");
                                str2 = string.Concat(str2, dataRow["InkName"].ToString(), "±");
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
                                str11 = string.Concat(str11, "0±");
                                num4++;
                            }
                            empty1 = "side1";
                            string[] strArrays2 = new string[] { "SectionName='", empty, "' and sidenumber='", empty1, "'" };
                            DataRow[] dataRowArray1 = dataTable.Select(string.Concat(strArrays2));
                            if ((int)dataRowArray1.Length > 0)
                            {
                                dataTable.Rows.Remove(dataRowArray1[0]);
                            }
                            object[] objArray1 = new object[] { empty, str, str1, str12, empty1, str2, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                            dataTable.Rows.Add(objArray1);
                            str = "";
                            str1 = "";
                            str2 = "";
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
                            foreach (DataRow row1 in EstimatesBasePage.settings_lithopress_InkSelect(this.CompanyID, this.PressID).Rows)
                            {
                                num = Convert.ToInt16(row1["DefaultColour"].ToString());
                                Convert.ToInt16(row1["rownumber"].ToString());
                                if (num <= num5)
                                {
                                    continue;
                                }
                                str = string.Concat(str, row1["InkID"].ToString(), "±");
                                str1 = string.Concat(str1, row1["InkCoverage"].ToString(), "±");
                                str2 = string.Concat(str2, row1["InkName"].ToString(), "±");
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
                                str11 = string.Concat(str11, "0±");
                                num5++;
                            }
                            empty1 = "side2";
                            string[] strArrays3 = new string[] { "SectionName='", empty, "' and sidenumber='", empty1, "'" };
                            DataRow[] dataRowArray2 = dataTable.Select(string.Concat(strArrays3));
                            if ((int)dataRowArray2.Length > 0)
                            {
                                dataTable.Rows.Remove(dataRowArray2[0]);
                            }
                            object[] objArray2 = new object[] { empty, str, str1, str12, empty1, str2, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                            dataTable.Rows.Add(objArray2);
                            str = "";
                            str1 = "";
                            str2 = "";
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
                        }
                    }
                }
                base.Session["dtinks"] = dataTable;
            }
        }

        private string Estimate_Calcukation(long EstimateItemID, long EstimateLithoBookletItemID, long PaperID, long PressID, char PressType, long GuillotineID, string EstimateType, string Noofsides, bool worknturn, bool workntumble, int side1color, int side2color, double PlateUnitPrice)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = EstimateBasePage.Paper_Calculation(this.CompanyID, Convert.ToInt32(PaperID)).Split(new char[] { '±' });
            string empty = string.Empty;
            decimal num = Convert.ToDecimal(EstimateBasePage.warehouse_perquantity_select(this.CompanyID, "I", PaperID));
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(1);
            double num3 = 0;
            double num4 = 0;
            stringBuilder.Append(" Insert into [tb_EstimateCalculation] ");
            stringBuilder.Append(" ( EstimateItemID, EstimateLithoBookletItemID, ");
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
            object[] estimateItemID = new object[] { " ( ", EstimateItemID, ", ", EstimateLithoBookletItemID, "," };
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
                num1 = Convert.ToInt32(row["ColourUnits"]);
                num3 = Convert.ToDouble(row["WashupUnitPrice"]);
                num4 = Convert.ToDouble(row["MakeReadyUnitPrice"]);
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
            //num2 = calculation.Return_PressPasses(this.ddlNoOfSide.SelectedValue, Convert.ToInt32(this.ddlSide1Color.SelectedItem.Value), Convert.ToInt32(this.ddlSide2Color.SelectedItem.Value), num1, this.chkPerfecting.Checked);
            num2 = calculation.Return_PressPasses(Noofsides, Convert.ToInt32(side1color), Convert.ToInt32(side2color), num1, this.chkPerfecting.Checked);
            object[] plateUnitPrice = new object[] { " ", num, ", ", num2, ",", num3, ",", num4, ",", PlateUnitPrice, ")" };
            stringBuilder.Append(string.Concat(plateUnitPrice));
            stringBuilder.Append(" declare @EstimateCalculationID bigint; ");
            stringBuilder.Append(" set @EstimateCalculationID = Ident_Current('tb_EstimateCalculation')");
            stringBuilder.Append(" select @EstimateCalculationID ");
            long num5 = EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            EstimatesBasePage.estimates_litho_markup_calculation_insert(this.CompanyID, num5);
            EstimatesBasePage.litho_speed_weight_insert(this.CompanyID, num5, PressID);
            return stringBuilder.ToString();
        }

        private void Estimate_Calcukation_Update(long EstimateItemID, long EstBookletSectionID, long PaperID, long PressID, char PressType, long GuillotineID, string EstimateType, string Noofsides, bool worknturn, bool workntumble, int side1color, int side2color, double PlateUnitPrice)
        {
            string str = "0";
            string str1 = "0";
            string str2 = "0";
            StringBuilder stringBuilder = new StringBuilder();
            decimal num = new decimal(0);
            decimal num1 = new decimal(1);
            double num2 = 0;
            double num3 = 0;
            stringBuilder.Append(" Update [tb_EstimateCalculation] ");
            stringBuilder.Append(string.Concat(" Set EstimateItemID=", EstimateItemID, ","));
            string[] strArrays = EstimateBasePage.Paper_Calculation(this.CompanyID, Convert.ToInt32(PaperID)).Split(new char[] { '±' });
            string[] strArrays1 = this.EstimateCalculationIDs.Split(new char[] { '\u00A7' });
            long estimateCalculationID = (long)0;
            try
            {
                if (strArrays1[this.IDCount].ToString().Trim() != "")
                {
                    estimateCalculationID = Convert.ToInt64(strArrays1[this.IDCount]);
                }
            }
            catch (Exception exception)
            {
            }
            if (estimateCalculationID == (long)0)
            {
                estimateCalculationID = this.EstimateCalculationID;
            }
            litho_booklet_item dCount = this;
            dCount.IDCount = dCount.IDCount + 1;
            str = strArrays[2].ToString();
            string empty = string.Empty;
            foreach (DataRow row in EstimatesBasePage.Estimate_Litho_Press_Select(this.CompanyID, PressID).Rows)
            {
                str1 = row["MarkUp"].ToString();
                string[] strArrays2 = new string[] { "PressSetupCharge=", row["SetupCharge"].ToString(), ",PressMinimumRunningCharge=", row["MinimumCharge"].ToString(), "," };
                stringBuilder.Append(string.Concat(strArrays2));
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
                    string[] str3 = new string[] { " GuillotineSetupCharge=", dataRow["SetUpCharge"].ToString(), ",GuillotineMinimumRunningCharge=", dataRow["MinCharge"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str3));
                    string[] strArrays3 = new string[] { " GuillotineCostPerCut=", dataRow["CostPerCut"].ToString(), ",GuillotinePaperWeight1=", dataRow["PaperWeight1"].ToString(), ",GuillotineMaximumThroat1=", dataRow["MaxSheets1"].ToString(), "," };
                    stringBuilder.Append(string.Concat(strArrays3));
                    string[] str4 = new string[] { " GuillotinePaperWeight2=", dataRow["PaperWeight2"].ToString(), ",GuillotineMaximumThroat2=", dataRow["MaxSheets2"].ToString(), ",GuillotinePaperWeight3=", dataRow["PaperWeight3"].ToString(), "," };
                    stringBuilder.Append(string.Concat(str4));
                    stringBuilder.Append(string.Concat(" GuillotineMaximumThroat3=", dataRow["MaxSheets3"].ToString(), ","));
                }
            }
            Calculations calculation = new Calculations();
            //num1 = calculation.Return_PressPasses(this.ddlNoOfSide.SelectedValue, Convert.ToInt32(this.ddlSide1Color.SelectedItem.Value), Convert.ToInt32(this.ddlSide2Color.SelectedItem.Value), num, this.chkPerfecting.Checked);
            num1 = calculation.Return_PressPasses(Noofsides, Convert.ToInt32(side1color), Convert.ToInt32(side2color), num, this.chkPerfecting.Checked);
            object[] plateUnitPrice = new object[] { "PressPasses=", num1, ",WashupUnitprice=", num2, ",MakeReadyUnitprice=", num3, ",PlateUnitPrice=", PlateUnitPrice };
            stringBuilder.Append(string.Concat(plateUnitPrice));
            string str5 = "0";
            string str6 = "0";
            string str7 = "0";
            bool flag = false;
            string[] strArrays4 = this.hdnOldPaperID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays4.Length - 1; i++)
            {
                string[] strArrays5 = strArrays4[i].Split(new char[] { '~' });
                if (Convert.ToInt64(strArrays5[0]) == EstBookletSectionID)
                {
                    str5 = strArrays5[1];
                }
            }
            string[] strArrays6 = this.hdnOldPressID.Value.Split(new char[] { ',' });
            for (int j = 0; j < (int)strArrays6.Length - 1; j++)
            {
                string[] strArrays7 = strArrays6[j].Split(new char[] { '~' });
                if (Convert.ToInt64(strArrays7[0]) == EstBookletSectionID)
                {
                    str6 = strArrays7[1];
                }
            }
            string[] strArrays8 = this.hdnOldGuillotineID.Value.Split(new char[] { ',' });
            for (int k = 0; k < (int)strArrays8.Length - 1; k++)
            {
                string[] strArrays9 = strArrays8[k].Split(new char[] { '~' });
                if (Convert.ToInt64(strArrays9[0]) == EstBookletSectionID)
                {
                    str7 = strArrays9[1];
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
            if (Convert.ToInt64(PaperID) != Convert.ToInt64(str5))
            {
                string[] strArrays12 = new string[] { ", PaperWeight=", strArrays[1], ",PaperPackedInQty=", strArrays[3], " " };
                stringBuilder.Append(string.Concat(strArrays12));
                string[] strArrays13 = new string[] { ", PaperMarkup=", str, ", PaperMarkup2=", str, ", PaperMarkup3=", str, ", PaperMarkup4=", str, " " };
                stringBuilder.Append(string.Concat(strArrays13));
            }
            if ((Convert.ToInt64(PaperID) != Convert.ToInt64(str5)) || (Convert.ToInt64(PaperID) == Convert.ToInt64(str5)))
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

            if (Convert.ToInt64(PressID) != Convert.ToInt64(str6))
            {
                string[] strArrays14 = new string[] { ", PressMarkup=", str1, ", PressMarkup2=", str1, ", PressMarkup3=", str1, ", PressMarkup4=", str1, " " };
                stringBuilder.Append(string.Concat(strArrays14));
            }
            if (Convert.ToInt64(GuillotineID) != Convert.ToInt64(str7))
            {
                string[] strArrays15 = new string[] { ",   GuillotineMarkUp=", str2, ", GuillotineMarkUp2=", str2, ", GuillotineMarkUp3=", str2, ", GuillotineMarkUp4=", str2, " " };
                stringBuilder.Append(string.Concat(strArrays15));
            }
            if (EstimateType == "S" || EstimateType == "P")
            {
                stringBuilder.Append(string.Concat(" Where EstimateCalculationID=", estimateCalculationID));
            }
            else
            {
                stringBuilder.Append(string.Concat(" Where EstimateCalculationID=", estimateCalculationID));
            }
            stringBuilder.Append(string.Concat(" select ", estimateCalculationID));
            EstimatesBasePage.calculation_insert_estimate(this.CompanyID, stringBuilder.ToString());
            EstimatesBasePage.litho_speed_weight_insert(this.CompanyID, estimateCalculationID, PressID);
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
                num1 = EstimatesBasePage.MarkupfromSettings_forinventoryitems(CompanyID, "inks", (long)0);
                IDataReader dataReader = SettingsBasePage.settings_lithopress_select_ink_rownum(CompanyID, PressID, 0);
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
            string str = "K";
            string str1 = "Sheet Fed Offset Booklet Item";
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
                    this.objnotes.Item_number = string.Concat("Item ", empty2);
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
            dataTable1.Columns.Add("LithoTypeID", typeof(string));
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
            int num = 1;
            string str12 = "";
            foreach (DataRow row in dataTable.Rows)
            {
                string empty12 = string.Empty;
                string empty13 = string.Empty;
                string str13 = string.Empty;
                if (dataTable.Rows.Count != 1)
                {
                    empty12 = row["SectionName"].ToString();
                    empty13 = row["sidenumber"].ToString();
                    str13 = row["SidesPrinted"].ToString();
                    if (empty.Length <= 0 || !(empty12 != empty) && !(str != empty13) && !(empty1 != str13))
                    {
                        if (num == dataTable.Rows.Count)
                        {
                            str1 = string.Concat(str1, row["InkID"].ToString(), "±");
                            str2 = string.Concat(str2, row["InkCoverage"].ToString(), "±");
                            str12 = string.Concat(str12, row["InkName"].ToString(), "±");
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
                            str = empty13;
                            empty1 = str13;
                            object[] objArray = new object[] { empty, str1, str2, empty1, str, str12, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                            dataTable1.Rows.Add(objArray);
                        }
                        str1 = string.Concat(str1, row["InkID"].ToString(), "±");
                        str2 = string.Concat(str2, row["InkCoverage"].ToString(), "±");
                        str12 = string.Concat(str12, row["InkName"].ToString(), "±");
                        str3 = row["EstimateLithobookletItemID"].ToString();
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
                        object[] objArray1 = new object[] { empty, str1, str2, empty1, str, str12, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                        dataTable1.Rows.Add(objArray1);
                        str1 = "";
                        str2 = "";
                        str12 = "";
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
                        str12 = string.Concat(row["InkName"].ToString(), "±");
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
                        str3 = row["EstimateLithobookletItemID"].ToString();
                        if (num == dataTable.Rows.Count)
                        {
                            empty = empty12;
                            str = empty13;
                            empty1 = str13;
                            object[] objArray2 = new object[] { empty, str1, str2, empty1, str, str12, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                            dataTable1.Rows.Add(objArray2);
                        }
                    }
                    empty = empty12;
                    str = empty13;
                    empty1 = str13;
                }
                else
                {
                    object[] item = new object[] { row["SectionName"], row["InkID"], row["InkCoverage"], row["SidesPrinted"], row["sidenumber"], row["InkName"], row["EstimateLithobookletItemID"], row["InkCostExMarkup1"], row["InkCostExMarkup2"], row["InkCostExMarkup3"], row["InkCostExMarkup4"], row["InkMarkup1"], row["InkMarkup2"], row["InkMarkup3"], row["InkMarkup4"], row["InkMarkupPrice1"], row["InkMarkupPrice2"], row["InkMarkupPrice3"], row["InkMarkupPrice4"], row["InkSetupCharge"], row["InkMinimumCharge"], row["InkCostExMarkup_Actual1"], row["InkCostExMarkup_Actual2"], row["InkCostExMarkup_Actual3"], row["InkCostExMarkup_Actual4"] };
                    dataTable1.Rows.Add(item);
                }
                num++;
            }
            base.Session["dtinks"] = dataTable1;
        }

        public void Main_Quantity_Insert(long EstimateItemID_TempID, long EstimateLithoBookletItemID, string strQty, string para, EstimatesItem Estitem, int partcount)
        {
            Calculations calculation = new Calculations();
            if (para == "qty")
            {
                decimal profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                decimal taxRate = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                int taxID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                EstimatesBasePage.taxprofit_update(this.CompanyID, EstimateItemID_TempID, "K", taxID, taxRate, profitMargin, EstimateLithoBookletItemID);
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
            string str = "K";
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
            decimal[] numArray15 = new decimal[4];
            decimal[] numArray16 = new decimal[4];
            decimal[] numArray17 = new decimal[4];
            decimal[] numArray18 = new decimal[4];
            decimal[] numArray19 = new decimal[4];
            decimal[] numArray20 = new decimal[4];
            decimal[] numArray21 = new decimal[4];
            decimal[] numArray22 = new decimal[4];
            decimal[] numArray23 = new decimal[4];
            decimal[] num15 = new decimal[4];
            decimal[] num16 = new decimal[4];
            decimal[] num17 = new decimal[4];
            decimal[] num18 = new decimal[4];
            decimal[] num19 = new decimal[4];
            decimal[] num20 = new decimal[4];
            decimal[] num21 = new decimal[4];
            decimal[] num22 = new decimal[4];
            decimal[] num23 = new decimal[4];
            decimal[] num24 = new decimal[4];
            decimal[] numArray24 = new decimal[4];
            decimal[] numArray30 = new decimal[4];
            decimal[] numArray31 = new decimal[4];
            
            decimal[] num25 = new decimal[4];
            for (int j = 1; j <= 4; j++)
            {
                int num26 = 0;
                if (j == 1)
                {
                    num26 = num;
                }
                else if (j == 2)
                {
                    num26 = num1;
                }
                else if (j == 3)
                {
                    num26 = num2;
                }
                else if (j == 4)
                {
                    num26 = num3;
                }
                if (num26 <= 0)
                {
                    numArray[j - 1] = 0;
                    numArray1[j - 1] = new decimal(0);
                    numArray2[j - 1] = new decimal(0);
                    numArray3[j - 1] = new decimal(0);
                    num4[j - 1] = new decimal(0);
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
                    numArray13[j - 1] = new decimal(0);
                    num14[j - 1] = new decimal(0);
                    numArray14[j - 1] = new decimal(0);
                    numArray11[j - 1] = new decimal(0);
                    num12[j - 1] = new decimal(0);
                    numArray12[j - 1] = new decimal(0);
                    num13[j - 1] = new decimal(0);
                    num15[j - 1] = new decimal(0);
                    num16[j - 1] = new decimal(0);
                    num17[j - 1] = new decimal(0);
                    num18[j - 1] = new decimal(0);
                    num19[j - 1] = new decimal(0);
                    num20[j - 1] = new decimal(0);
                    num21[j - 1] = new decimal(0);
                    num22[j - 1] = new decimal(0);
                    num23[j - 1] = new decimal(0);
                    num24[j - 1] = new decimal(0);
                    numArray24[j - 1] = new decimal(0);
                    num25[j - 1] = new decimal(0);
                }
                else
                {
                    numArray[j - 1] = num26;
                    DataTable dataTable = new DataTable();
                    dataTable = EstimatesBasePage.estimate_litho_booklet_item_select(this.CompanyID, EstimateItemID_TempID);
                    DataRow[] dataRowArray = dataTable.Select(string.Concat(" EstimateLithoBookletItemID=", EstimateLithoBookletItemID));
                    DataRow dataRow = dataRowArray[0];
                    if (this.ProfitTaxKey.ToLower() != "database")
                    {
                        numArray1[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "Paper", (long)0);
                        numArray2[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "press", Convert.ToInt64(dataRow["PressID"]));
                        if (Convert.ToInt64(dataRow["GuillotineID"]) > (long)0)
                        {
                            numArray3[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "guillotine", Convert.ToInt64(dataRow["GuillotineID"]));
                        }
                        num4[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inks", (long)0);
                        numArray4[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inventoryitems", (long)0);
                        num5[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inventoryitems", (long)0);
                        numArray5[j - 1] = EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "inventoryitems", (long)0);
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
                        num4[j - 1] = Convert.ToDecimal(dataRow["InkMarkup"]);
                        numArray4[j - 1] = Convert.ToDecimal(dataRow["PlateMarkup"]);
                        num5[j - 1] = Convert.ToDecimal(dataRow["MakeReadyMarkUp"]);
                        numArray5[j - 1] = Convert.ToDecimal(dataRow["WashUpMarkUp"]);
                    }
                    decimal num27 = new decimal(0);
                    decimal FullSheetArea = new decimal(0);
                    num7[j - 1] = calculation.PaperCalculation(this.CompanyID, str, num26, numArray1[j - 1], dataRow, ref num6[j - 1], ref numArray6[j - 1], ref numArray7[j - 1], ref num8[j - 1], ref num27,ref FullSheetArea);
                    numArray9[j - 1] = calculation.PressCalculation(this.CompanyID, str, num26, numArray2[j - 1], dataRow, num8[j - 1], ref numArray8[j - 1], ref num9[j - 1], num27, ref num15[j - 1], ref num16[j - 1], ref num17[j - 1], ref num18[j - 1], ref num19[j - 1], ref num20[j - 1], ref num21[j - 1], ref num22[j - 1], ref num23[j - 1], ref num24[j - 1], ref numArray24[j - 1], j, ref numArray30[j - 1], ref numArray31[j - 1]);

                    DataTable dt = new DataTable();
                    if (Estitem.GuillotineID > 0)
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
                        num13[j - 1] = result;
                    }

                    num10[j - 1] = calculation.GuillotineCalculation(this.CompanyID, str, num26, numArray3[j - 1], dataRow, num8[j - 1], ref numArray10[j - 1], ref num11[j - 1], ref numArray11[j - 1], ref num12[j - 1], ref numArray12[j - 1], ref num13[j - 1], num27, ref num25[j - 1], GuillotineType);
                    numArray13[j - 1] = calculation.InkCalculation(this.CompanyID, str, num26, num4[j - 1], dataRow, EstimateItemID_TempID, ref num14[j - 1], ref numArray14[j - 1], EstimateLithoBookletItemID, partcount, para, j, this.ProfitTaxKey.ToLower());
                    numArray15[j - 1] = calculation.PlateCalculation(this.CompanyID, str, num26, numArray4[j - 1], dataRow, ref numArray16[j - 1], ref numArray17[j - 1], partcount);
                    numArray18[j - 1] = calculation.MakeReadyCalculation(this.CompanyID, str, num26, num5[j - 1], dataRow, ref numArray19[j - 1], ref numArray20[j - 1], partcount);
                    numArray21[j - 1] = calculation.WashupCalculation(this.CompanyID, str, num26, numArray5[j - 1], dataRow, ref numArray22[j - 1], ref numArray23[j - 1], partcount);
                }
            }
            EstimatesBasePage.quantity_insert_offset_item(this.CompanyID, EstimateItemID_TempID, str, numArray[0], numArray7[0], num8[0], num6[0], numArray6[0], numArray8[0], num9[0], numArray11[0], num12[0], numArray12[0], num13[0], numArray10[0], num11[0], num14[0], numArray14[0], numArray16[0], numArray17[0], numArray19[0], numArray20[0], numArray22[0], numArray23[0], numArray[1], numArray7[1], num8[1], num6[1], numArray6[1], numArray8[1], num9[1], numArray11[1], num12[1], numArray12[1], num13[1], numArray10[1], num11[1], num14[1], numArray14[1], numArray16[1], numArray17[1], numArray19[1], numArray20[1], numArray22[1], numArray23[1], numArray[2], numArray7[2], num8[2], num6[2], numArray6[2], numArray8[2], num9[2], numArray11[2], num12[2], numArray12[2], num13[2], numArray10[2], num11[2], num14[2], numArray14[2], numArray16[2], numArray17[2], numArray19[2], numArray20[2], numArray22[2], numArray23[2], numArray[3], numArray7[3], num8[3], num6[3], numArray6[3], numArray8[3], num9[3], numArray11[3], num12[3], numArray12[3], num13[3], numArray10[3], num11[3], num14[3], numArray14[3], numArray16[3], numArray17[3], numArray19[3], numArray20[3], numArray22[3], numArray23[3], para, EstimateLithoBookletItemID, num15[0], num15[1], num15[2], num15[3], num16[0], num16[1], num16[2], num16[3], num17[0], num17[1], num17[2], num17[3], num18[0], num18[1], num18[2], num18[3], num19[0], num19[1], num19[2], num19[3], num20[0], num20[1], num20[2], num20[3], num21[0], num21[1], num21[2], num21[3], num22[0], num22[1], num22[2], num22[3], numArray24[0], numArray24[1], numArray24[2], numArray24[3], num25[0], num25[1], num25[2], num25[3]);
            this.JobTimeSumAdd = this.JobTimeSumAdd + num15[0];
            if (this.GetQtyNo() != 0)
            {
                int qtyNo = this.GetQtyNo() - 1;
                this.JobTimeSumEdit = this.JobTimeSumEdit + num15[qtyNo];
            }
        }

        protected void onclick_lnkNewSection(object sender, EventArgs e)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
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
            DataTable dataTable = new DataTable();
            string lower = this.ddlNoOfSide.SelectedValue.ToLower();
            Convert.ToInt32(this.ddlSide1Color.SelectedValue);
            Convert.ToInt32(this.ddlSide2Color.SelectedValue);
            this.PressID = Convert.ToInt64(this.ddlPress.SelectedValue);
            string str12 = lower;
            this.EstimateLithobookletitemid_old.Split(new char[] { '~' });
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
                dataTable.Columns.Add("LithoTypeID", typeof(string));
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
            int num = Convert.ToInt16(this.hid_SectionCount.Value);
            int num1 = Convert.ToInt16(this.hid_PresntSection.Value);
            for (int i = 1; i <= num; i++)
            {
                if (num1 == i)
                {
                    str3 = "0";
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
                        object[] objArray = new object[] { "SectionName='Parts", empty, "' and sidenumber='side", j, "'" };
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
                                str12 = dataRow["SidesPrinted"].ToString();
                                str2 = dataRow["InkName"].ToString();
                                string[] strArrays = str1.Split(new char[] { '±' });
                                for (int l = 0; l < (int)strArrays.Length - 1; l++)
                                {
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
                                    str11 = string.Concat(str11, "0±");
                                }
                            }
                            object[] objArray1 = new object[] { empty, str, str1, str12, empty1, str2, str3, empty2, empty3, empty4, str4, empty5, str5, empty6, str6, empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11 };
                            dataTable.Rows.Add(objArray1);
                        }
                        str = "";
                        str1 = "";
                        str2 = "";
                        str3 = "0";
                        empty2 = "";
                        empty3 = "";
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
                        str11 = "";
                    }
                }
            }
            base.Session["dtinks"] = dataTable;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.ProfitTaxKey != null)
            {
                this.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            if (!base.IsPostBack)
            {
                this.Label10.Text = this.objLanguage.GetLanguageConversion("Item_Title");
                this.Label5.Text = this.objLanguage.GetLanguageConversion("Section_Reference");
                this.Label9.Text = this.objLanguage.GetLanguageConversion("Assigned_Press");
                this.Label12.Text = this.objLanguage.GetLanguageConversion("Paper_Stock");
                this.ChkPriceForWholePack.Text = this.objLanguage.GetLanguageConversion("Price_For_Whole_Pack");
                this.ChkPaperSupplied.Text = this.objLanguage.GetLanguageConversion("Paper_Supplied");
                this.Label13.Text = this.objLanguage.GetLanguageConversion("SetUp_Spoilage");
                this.Label14.Text = this.objLanguage.GetLanguageConversion("Running_Spoilage");
                this.Label1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Side_1"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                this.Label2.Text = string.Concat(this.objLanguage.GetLanguageConversion("Side_2"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                this.chkTurn.Text = this.objLanguage.GetLanguageConversion("Work_Turn");
                this.chkTumble.Text = this.objLanguage.GetLanguageConversion("Work_Tumble");
                this.lblBookletType.Text = this.objLanguage.GetLanguageConversion("Booklet_Type");
                this.Label18.Text = this.objLanguage.GetLanguageConversion("No_Of_Pages_In_This_Section");
                this.Label22.Text = this.objLanguage.GetLanguageConversion("Print_Sheet_Size");
                this.chkPrintSheet.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.ChkJobFlatCustom.Text = this.objLanguage.GetLanguageConversion("Custom");
                this.Label24.Text = this.objLanguage.GetLanguageConversion("Include_Gutters");
                this.Label25.Text = this.objLanguage.GetLanguageConversion("Apply_Press_Restrictions");
                this.Label19.Text = this.objLanguage.GetLanguageConversion("Booklet_Pages_Per_Print_Sheet");
                this.Label27.Text = this.objLanguage.GetLanguageConversion("Print_Sheets_Per_Section");
                this.Label26.Text = this.objLanguage.GetLanguageConversion("Guillotine");
                this.btnStage2_Previous.Text = this.objLanguage.GetLanguageConversion("Previous");
                this.Button14.Text = this.objLanguage.GetLanguageConversion("New_Section");
                this.Button16.Text = this.objLanguage.GetLanguageConversion("Delete");
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Finish");
                this.img_Update_Descriptipn.Title = this.objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate");
                this.chkSheetWork.Text = this.objLanguage.GetLanguageConversion("Sheet_Work");
                this.chkIsSilling.Text = this.objLanguage.GetLanguageConversion("Round_up_to_use_whole_sheets");
                this.chkPortrait.Text = this.objLanguage.GetLanguageConversion("Portrait");
                this.chkLandscape.Text = this.objLanguage.GetLanguageConversion("LandScape");
            }
            base.Session["GetOldEstimateLithobookletitemID"] = null;
            if (!base.IsPostBack)
            {
                base.Session["dtinks"] = null;
            }
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
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            global.pgName = string.Empty;
            this.section = base.BaseSection;
            this.txtItemTitle.Focus();
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
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
            this.txtNoOfPlates.Attributes.Add("style", "text-align:right");
            this.txtNoOfMakeReady.Attributes.Add("style", "text-align:right");
            this.Label11.Text = this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour");
            this.ddlColors.Items[0].Text = this.Label11.Text;
            this.ddlColors.Items[1].Text = this.objLanguage.GetLanguageConversion("Black_White");
            this.ddlColors_2.Items[0].Text = this.Label11.Text;
            this.ddlColors_2.Items[1].Text = this.objLanguage.GetLanguageConversion("Black_White");
            this.ddlBookletType.Items[0].Text = this.objLanguage.GetLanguageConversion("Saddle_Stiched");
            this.ddlBookletType.Items[1].Text = this.objLanguage.GetLanguageConversion("Perfect_Bound");
            this.ddlBookletFormat.Items[0].Text = this.objLanguage.GetLanguageConversion("Portrait");
            this.ddlBookletFormat.Items[1].Text = this.objLanguage.GetLanguageConversion("Landscape");
            this.Label20.Text = this.objLanguage.GetLanguageConversion("Print_Layout");
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
            if (!base.IsPostBack)
            {
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    this.ChkPriceForWholePack.Checked = Convert.ToBoolean(row["DefaultPriceForWholePack"]);
                }
                for (int i = 0; i <= 24; i++)
                {
                    this.ddlMakeReady.Items.Add(string.Concat(i));
                    this.ddlWashUp.Items.Add(string.Concat(i));
                    if (i != 0)
                    {
                        this.ddlPlates.Items.Add(string.Concat(i));
                    }
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
                this.Bind_Press(this.ddlPress, this.CompanyID, "--- Select ---");
                DataTable dataTable = new DataTable();
                dataTable = EstimatesBasePage.estimate_select_paper_size(this.CompanyID);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    litho_booklet_item usercontrolItemLithoBookletItem = this;
                    object obj = usercontrolItemLithoBookletItem.dpaperhw;
                    object[] num = new object[] { obj, Convert.ToInt32(dataRow["PaperSizeID"].ToString()), "±", Convert.ToDecimal(dataRow["Height"].ToString()), "±", Convert.ToDecimal(dataRow["Width"].ToString()), "»" };
                    usercontrolItemLithoBookletItem.dpaperhw = string.Concat(num);
                }
                if (string.Compare(this.QueryType, "add", true) == 0)
                {
                    this.pnlPress.Visible = true;
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
                this.txtsectionheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();roundTo3or2DecimalPlaces(this,this.value);");
                this.txtsectionwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();roundTo3or2DecimalPlaces(this,this.value);");
                this.txtitemheight.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');roundTo3or2DecimalPlaces(this,this.value);");
                this.txtitemwidth.Attributes.Add("onblur", "AllowNumber(this,this.value);Calculations();ItemSize_AssignToSummary('onblur');roundTo3or2DecimalPlaces(this,this.value);");
                this.txtGutterHorizontal.Attributes.Add("onblur", "todecimal_function(this,this.value);Calculations();");
                this.txtGutterVertical.Attributes.Add("onblur", "todecimal_function(this,this.value);Calculations();");
                this.txtNoOfPlates.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                this.txtNoOfMakeReady.Attributes.Add("onblur", "AllowNumber(this,this.value)");
                if (string.Compare(this.QueryType, "add", true) == 0 || string.Compare(this.QueryType, "more", true) == 0)
                {
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
            foreach (DataRow dataRow1 in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
            {
                this.IsItemCompleted = Convert.ToInt16(dataRow1["IsItemCompleted"].ToString());
                this.IsProductCreated = Convert.ToInt16(dataRow1["IsProductCreated"].ToString());
            }
            if (this.IsProductCreated == 1)
            {
                this.Div_Productcatalogue.Visible = true;
            }
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                this.Select_Booklet_Item();
                if (!base.IsPostBack)
                {
                    this.Div_ItemDescn.Visible = true;
                    foreach (DataRow row2 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                    {
                        if (row2["UpdateItemDescription"].ToString().ToLower() != "true")
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
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
            }
            if (base.Request.QueryString["FromItem"] != null)
            {
                this.FromItemDescription = "Y";
            }
            this.txtPagesPerSignature.ReadOnly = true;
            this.txtNoOfSignatures.ReadOnly = true;
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
            string str;
            if (base.Session["dtinks"] == null)
            {
                this.Getvaluefromsettings(side, this.CompanyID, EstimateItemID_TempID, PressID, side1color, side2color, LithoTypeID, EstimateType, partcount);
            }
            else
            {
                string empty = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                DataTable item = (DataTable)base.Session["dtinks"];
                string str3 = "New";
                foreach (DataRow row in item.Rows)
                {
                    if (LithoTypeID != Convert.ToInt64(row["LithoTypeID"].ToString()))
                    {
                        continue;
                    }
                    str3 = "Old";
                }
                str = (str3 != "New" ? string.Concat("LithoTypeID='", LithoTypeID, "'") : string.Concat("SectionName='Parts", partcount, "'"));
                if (side.Trim().ToLower() != "single")
                {
                    DataRow[] dataRowArray = item.Select(string.Concat(str, " and SidesPrinted='single'  and sidenumber='side1' "));
                    if ((int)dataRowArray.Length > 0)
                    {
                        dataRowArray[0]["SidesPrinted"] = side.ToString();
                    }
                }
                else
                {
                    DataRow[] dataRowArray1 = item.Select(string.Concat(str, " and SidesPrinted='Double'  and sidenumber='side2'"));
                    if ((int)dataRowArray1.Length > 0)
                    {
                        for (int i = 0; i < (int)dataRowArray1.Length; i++)
                        {
                            item.Rows.Remove(dataRowArray1[i]);
                        }
                        DataRow[] dataRowArray2 = item.Select(string.Concat(str, " and SidesPrinted='Double'  and sidenumber='side1' "));
                        if ((int)dataRowArray2.Length > 0)
                        {
                            dataRowArray2[0]["SidesPrinted"] = side.ToString();
                        }
                    }
                }
                int num = 0;
                if ((int)item.Select(str ?? "").Length <= 0)
                {
                    this.Getvaluefromsettings(side, this.CompanyID, EstimateItemID_TempID, PressID, side1color, side2color, LithoTypeID, EstimateType, partcount);
                    return;
                }
                if (side.Trim().ToLower() == "single")
                {
                    if ((int)item.Select(string.Concat("sidenumber='side1' and ", str)).Length <= 0)
                    {
                        this.Getvaluefromsettings(side, this.CompanyID, EstimateItemID_TempID, PressID, side1color, side2color, LithoTypeID, EstimateType, partcount);
                        return;
                    }
                    num = 0;
                    DataRow[] dataRowArray3 = item.Select(string.Concat("sidenumber='side1' and ", str, " "));
                    for (int j = 0; j < (int)dataRowArray3.Length; j++)
                    {
                        DataRow dataRow = dataRowArray3[j];
                        this.getinkvalues(dataRow, num, side1color, this.CompanyID, EstimateItemID_TempID, PressID, LithoTypeID, EstimateType, partcount);
                    }
                    return;
                }
                bool flag = false;
                if ((int)item.Select(string.Concat("sidenumber='side1' and ", str)).Length <= 0)
                {
                    this.Getvaluefromsettings(side, this.CompanyID, EstimateItemID_TempID, PressID, side1color, side2color, LithoTypeID, EstimateType, partcount);
                }
                else
                {
                    flag = true;
                    num = 0;
                    DataRow[] dataRowArray4 = item.Select(string.Concat("sidenumber='side1' and ", str, " "));
                    for (int k = 0; k < (int)dataRowArray4.Length; k++)
                    {
                        DataRow dataRow1 = dataRowArray4[k];
                        this.getinkvalues(dataRow1, num, side1color, this.CompanyID, EstimateItemID_TempID, PressID, LithoTypeID, EstimateType, partcount);
                    }
                }
                if ((int)item.Select(string.Concat("sidenumber='side2' and ", str)).Length > 0)
                {
                    num = 0;
                    DataRow[] dataRowArray5 = item.Select(string.Concat("sidenumber='side2' and ", str, " "));
                    for (int l = 0; l < (int)dataRowArray5.Length; l++)
                    {
                        DataRow dataRow2 = dataRowArray5[l];
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

        private void Select_Booklet_Item()
        {
            int num = 0;
            DataTable dataTable = EstimatesBasePage.lithobooklet_item_select(this.CompanyID, this.EstimateItemID);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    long num1 = Convert.ToInt64(row["EstimateLithoBookletItemID"]);
                    litho_booklet_item usercontrolItemLithoBookletItem = this;
                    usercontrolItemLithoBookletItem.EstimateLithobookletitemid_old = string.Concat(usercontrolItemLithoBookletItem.EstimateLithobookletitemid_old, num1, "~");
                    this.EstimateCalculationID = Convert.ToInt64(row["EstimateCalculationID"]);
                    litho_booklet_item usercontrolItemLithoBookletItem1 = this;
                    usercontrolItemLithoBookletItem1.EstimateCalculationIDs = string.Concat(usercontrolItemLithoBookletItem1.EstimateCalculationIDs, row["EstimateCalculationID"].ToString(), "§");
                    this.TypeID = num1;
                    this.ItemDescription_0 = row["ItemDescription"].ToString();
                    this.hid_IsSheetCustom.Value = row["IsSheetCustom"].ToString();
                    this.hid_IsJobCustom.Value = row["IsJobCustom"].ToString();
                    if (!base.IsPostBack)
                    {
                        this.txtItemTitle.Text = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    }
                    stringBuilder.AppendFormat("Qty»{0}±", "");
                    stringBuilder.AppendFormat("Press»{0}»{1}±", row["PressID"].ToString(), "D");
                    object[] str = new object[] { row["PaperID"].ToString(), this.objBase.SpecialDecode(row["PaperName"].ToString()), row["IsPricePerPack"].ToString(), row["IsPaperSupplied"].ToString() };
                    stringBuilder.AppendFormat("Paper»{0}»{1}»{2}»{3}±", str);
                    stringBuilder.AppendFormat("SetupSpoilage»{0}±", Convert.ToDecimal(row["SetUpSpoilage"]));
                    stringBuilder.AppendFormat("RunningSpoilage»{0}±", Convert.ToDecimal(row["RunningSpoilage"]));
                    object[] objArray = new object[] { row["PrintSheetSizeID"].ToString(), row["IsSheetCustom"].ToString(), row["SheetHeight"].ToString(), row["SheetWidth"].ToString() };
                    stringBuilder.AppendFormat("SheetSize»{0}»{1}»{2}»{3}±", objArray);
                    object[] str1 = new object[] { row["JobFlatSizeID"].ToString(), row["IsJobCustom"].ToString(), row["JobHeight"].ToString(), row["JobWidth"].ToString() };
                    stringBuilder.AppendFormat("ItemSize»{0}»{1}»{2}»{3}±", str1);
                    stringBuilder.AppendFormat("Gutters»{0}»{1}»{2}±", row["IsIncludeGutters"].ToString(), row["GutterHorizontal"].ToString(), row["GutterVertical"].ToString());
                    stringBuilder.AppendFormat("PressRestrictions»{0}»{1}»{2}±", row["IsPressRestrictions"].ToString(), row["NonImageHeight"].ToString(), row["NonImageWidth"].ToString());
                    stringBuilder.AppendFormat("PrintLayout»{0}»{1}»{2}»{3}±", row["PrintLayout"].ToString(), row["PortraitValue"].ToString(), row["LandscapeValue"].ToString(), row["ManualValue"].ToString());
                    stringBuilder.AppendFormat("Guillotine»{0}»{1}±", row["GuillotineID"].ToString(), this.objBase.SpecialDecode(row["GuillotineName"].ToString()));
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
                    stringBuilder.AppendFormat("QuantityList»{0}±", row["Qty"].ToString());
                    stringBuilder.AppendFormat("IsDeleted»{0}±", row["IsDeleted"].ToString());
                    stringBuilder.AppendFormat("EstimateLithoBookletItemID»{0}±", row["EstimateLithoBookletItemID"].ToString());
                    stringBuilder.AppendFormat("Plates»{0}»{1}±", row["PlateID"].ToString(), this.objBase.SpecialDecode(row["PlateName"].ToString()));
                    stringBuilder.AppendFormat("NoofPlate»{0}±", row["Noofplates"].ToString());
                    stringBuilder.AppendFormat("Makeready»{0}±", row["NoofMakeReady"].ToString());
                    stringBuilder.AppendFormat("NoofWashup»{0}±", row["NoofWashup"].ToString());
                    stringBuilder.AppendFormat("MakeReadyPerPlateCheck»{0}±", row["MakeReadyPerPlateCheck"].ToString());
                    stringBuilder.AppendFormat("WashupChargePerColourCheck»{0}±", row["WashupChargePerColourCheck"].ToString());
                    object[] objArray1 = new object[] { row["sidesprinted"].ToString(), row["side1Color"].ToString(), row["side2Color"].ToString(), row["WorknTurn"].ToString(), row["WorknTumble"].ToString(), row["perfecting"] };
                    stringBuilder.AppendFormat("Colour»{0}»{1}»{2}»{3}»{4}»{5}±", objArray1);
                    stringBuilder.AppendFormat("InkType»{0}±", row["InkType"].ToString());
                    stringBuilder.AppendFormat("isPressPerfect»{0}±", row["isPressPerfect"].ToString());
                    stringBuilder.AppendFormat("isCeilPrintSheetPerSection»{0}±", row["isCeilPrintSheetPerSection"].ToString());
                    stringBuilder.AppendFormat("isCeilPrintSheetPerSection»{0}±", row["isCeilPrintSheetPerSection"].ToString());
                    stringBuilder.AppendFormat("PaperWeight»{0}±", row["PaprWeight"].ToString());
                    stringBuilder.Append("µ");
                    if (!base.IsPostBack)
                    {
                        HiddenField hiddenField = this.hdnOldPressID;
                        string value = hiddenField.Value;
                        string[] strArrays = new string[] { value, num1.ToString(), "~", row["PressID"].ToString(), "," };
                        hiddenField.Value = string.Concat(strArrays);
                        HiddenField hiddenField1 = this.hdnOldPaperID;
                        string value1 = hiddenField1.Value;
                        string[] strArrays1 = new string[] { value1, num1.ToString(), "~", row["PaperID"].ToString(), "," };
                        hiddenField1.Value = string.Concat(strArrays1);
                        HiddenField hiddenField2 = this.hdnOldGuillotineID;
                        string value2 = hiddenField2.Value;
                        string[] str2 = new string[] { value2, num1.ToString(), "~", row["GuillotineID"].ToString(), "," };
                        hiddenField2.Value = string.Concat(str2);
                        HiddenField hdnIsPaperUnitPriceLocked = this.hdn_IsPaperUnitPriceLocked;
                        string value3 = hdnIsPaperUnitPriceLocked.Value;
                        string[] strArrays2 = new string[] { value3, num1.ToString(), "~", row["IsPaperUnitPriceLocked"].ToString(), "," };
                        hdnIsPaperUnitPriceLocked.Value = string.Concat(strArrays2);
                    }
                    num++;
                }
                catch
                {
                }
            }
            if (!base.IsPostBack)
            {
                this.hid_SectionCount.Value = num.ToString();
            }
            this.QtyNo = this.GetQtyNo();
            this.hid_bookletData.Value = stringBuilder.ToString();
            this.pnlBookletEdit.Visible = true;
            base.Session["GetOldEstimateLithobookletitemID"] = this.EstimateLithobookletitemid_old;
        }

        private void Update_Booklet_Item()
        {
            this.EstType = "K";
            EstimatesItem estimatesItem = new EstimatesItem();
            StringBuilder stringBuilder = new StringBuilder();
            EstimatesBasePage.Ink_Delete_BasedOn_estimateitemID(this.EstimateItemID);
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
                        this.PressID = Convert.ToInt64(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "PressType")
                    {
                        estimatesItem.PressType = 'S';
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
                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                        estimatesItem.SetupSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "RunningSpoilage")
                    {
                        estimatesItem.LithoBookletRunningSpoilage = Convert.ToDecimal(strArrays2[1].Trim());
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
                        estimatesItem.IsPressRestrictions = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "NonImageHeight")
                    {
                        estimatesItem.NonImageHeight = Convert.ToDecimal(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "NonImageWidth")
                    {
                        estimatesItem.NonImageHeight = Convert.ToDecimal(strArrays2[1].Trim());
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
                    else if (strArrays2[0].Trim() == "EstimateLithoBookletItemID")
                    {
                        estimatesItem.EstimateLithoBookletItemID = Convert.ToInt64(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "BookletFormat")
                    {
                        estimatesItem.BookletFormat = strArrays2[1].Trim();
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
                        estimatesItem.NCRCheckturn = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "Checktumble")
                    {
                        estimatesItem.NCRChecktumble = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "CheckPerfecting")
                    {
                        estimatesItem.NCRCheckPerfecting = Convert.ToBoolean(strArrays2[1].Trim());
                    }
                    else if (strArrays2[0].Trim() == "Platename")
                    {
                        estimatesItem.NCRPlatename = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "ChkSheetWork")
                    {
                        estimatesItem.NCRChkSheetWork = Convert.ToBoolean(strArrays2[1].Trim());
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
                        estimatesItem.NoofMakeReady = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "Washup")
                    {
                        estimatesItem.NCRWashup = strArrays2[1].Trim();
                    }
                    else if (strArrays2[0].Trim() == "QtyList")
                    {
                        estimatesItem.EstimateItemID = this.EstimateItemID;
                        estimatesItem.ModifiedBy = Convert.ToInt32(base.Session["UserID"]);
                        estimatesItem.ModifiedDate = DateTime.Now;
                        estimatesItem.ItemTitle = this.Objclss.SpecialEncode(this.txtItemTitle.Text);
                        estimatesItem.ItemDescription = this.ItemDescription_0;
                        long num = EstimatesBasePage.Lithobooklet_item_insert(estimatesItem);
                        this.PressID = Convert.ToInt64(estimatesItem.PressID);
                        if (estimatesItem.EstimateLithoBookletItemID != (long)0)
                        {
                            this.Popup_inkvalue_insert(this.EstimateItemID, "", this.PressID, estimatesItem.NCRNoofsidesprinted, this.EstType, estimatesItem.EstimateLithoBookletItemID, this.partcount, Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), "update");
                        }
                        else
                        {
                            this.Popup_inkvalue_insert(this.EstimateItemID, "", this.PressID, estimatesItem.NCRNoofsidesprinted, this.EstType, num, this.partcount, Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), "update");
                        }
                        estimatesItem.NCRSide1color = (estimatesItem.NCRSide1color == "" ? "0" : estimatesItem.NCRSide1color);
                        estimatesItem.NCRSide2color = (estimatesItem.NCRSide2color == "" ? "0" : estimatesItem.NCRSide2color);
                        double num1 = 0;
                        foreach (DataRow row in EstimatesBasePage.SelectPlateunitprice_eachSectin(Convert.ToInt32(estimatesItem.NCRPlateID)).Rows)
                        {
                            num1 = Convert.ToDouble(row["PlateUnitPrice"]);
                        }
                        if (estimatesItem.EstimateLithoBookletItemID != (long)0)
                        {
                            this.Estimate_Calcukation_Update(this.EstimateItemID, num, estimatesItem.PaperID, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, this.EstType, estimatesItem.NCRNoofsidesprinted, estimatesItem.NCRCheckturn, estimatesItem.NCRChecktumble, Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), num1);
                        }
                        else
                        {
                            this.Estimate_Calcukation(this.EstimateItemID, num, estimatesItem.PaperID, estimatesItem.PressID, estimatesItem.PressType, estimatesItem.GuillotineID, this.EstType, estimatesItem.NCRNoofsidesprinted, estimatesItem.NCRCheckturn, estimatesItem.NCRChecktumble, Convert.ToInt32(estimatesItem.NCRSide1color), Convert.ToInt32(estimatesItem.NCRSide2color), num1);
                        }
                        if (estimatesItem.EstimateLithoBookletItemID != (long)0)
                        {
                            this.Main_Quantity_Insert(estimatesItem.EstimateItemID, num, strArrays2[1].ToString(), "updatebookqty", estimatesItem, this.partcount);
                        }
                        else
                        {
                            this.Main_Quantity_Insert(estimatesItem.EstimateItemID, num, strArrays2[1].ToString(), "qty", estimatesItem, this.partcount);
                        }
                    }
                }
                litho_booklet_item usercontrolItemLithoBookletItem = this;
                usercontrolItemLithoBookletItem.partcount = usercontrolItemLithoBookletItem.partcount + 1;
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            if (this.Chk_ItemDescn.Checked)
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "K", false);
            }
            if (this.IsProductCreated == 1)
            {
                int num2 = 0;
                if (this.chkPoduct1.Checked)
                {
                    num2 = 1;
                }
                else if (this.chkPoduct2.Checked)
                {
                    num2 = 2;
                }
                DataTable dataTable = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "K");
                if (dataTable.Rows.Count > 0)
                {
                    dataTable.Rows[0]["PricecatalogueID"].ToString();
                    if (num2 == 1 || num2 == 2)
                    {
                        EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "K", num2);
                    }
                }
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                JobBasePage.Update_EstimateJobTime(this.EstimateItemID, this.JobTimeSumEdit);
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "K");
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
            EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "K");
        }
    }
}
