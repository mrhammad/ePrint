using MathFunctions;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
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
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.Jobs
{
    public partial class job_Othercost : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        private Global gloobj = new Global();

        private commonClass commclass = new commonClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string DateFormat = string.Empty;

        public int CompanyID;

        public long EstimateID;

        public long EstimateItemID;

        public long EstSingleItemID;

        public long EstPadItemID;

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

        private commonClass objJava = new commonClass();

        private long ParentItemID;

        private string ParentItemType = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        public string QueryType = string.Empty;

        public string tabtype = "job";

        public string modulename = "jobs";

        public string submodulename = "job";

        public string widthsize = string.Empty;

        private string esttitle = string.Empty;

        public string EstTypeFromSP = string.Empty;

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public string req_type = string.Empty;

        public string FromSummary = string.Empty;

        public int UserID;

        private decimal MinimumCostMarkup;

        private decimal CostexMarkup_forsummary;

        public string frmcopyitem = string.Empty;

        private decimal Zonemarkup;

        public string MainType = string.Empty;

        public int IsItemCompleted;

        public bool IsOtherCostSequence = true;

        public int IsProductCreated;

        public string isfrom_eStore = string.Empty;

        private short QtyNo = 1;

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

        public job_Othercost()
        {
        }

        protected void btnCostFinish_OnClick(object sender, EventArgs e)
        {
            char[] chrArray;
            object[] estimateID;
            DateTime now;
            long num = (long)0;
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.QueryString["EstID"] != null)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.QueryString["EstID"].ToString());
                }
                if (this.isfrom_eStore.ToLower() == "yes")
                {
                    int num1 = 0;
                    int num2 = 0;
                    int num3 = 0;
                    int num4 = 0;
                    if (this.hdn_EstQtyList.Value.ToString().Trim().Length > 0)
                    {
                        string str = this.hdn_EstQtyList.Value.ToString();
                        chrArray = new char[] { '~' };
                        string[] strArrays = str.Split(chrArray);
                        if (strArrays[0].ToString().Trim().Length > 0)
                        {
                            num1 = Convert.ToInt32(strArrays[0].ToString());
                        }
                        if (strArrays[1].ToString().Trim().Length > 0)
                        {
                            num2 = Convert.ToInt32(strArrays[1].ToString());
                        }
                        if (strArrays[2].ToString().Trim().Length > 0)
                        {
                            num3 = Convert.ToInt32(strArrays[2].ToString());
                        }
                        if (strArrays[3].ToString().Trim().Length > 0)
                        {
                            num4 = Convert.ToInt32(strArrays[3].ToString());
                        }
                    }
                    if (base.Request.Params["type"].ToString().ToLower() == "edit" && this.frmcopyitem != "yes")
                    {
                        if (this.ParentEstimateItemID == (long)0)
                        {
                            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
                            EstimatesBasePage.update_OtherCostItemQty(this.EstimateItemID, "U", num1, num2, num3, num4);
                            this.Est_OtherCost_Insert(num, base.Request.Params["esttype"].ToString(), this.EstimateItemID);
                            EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "U");
                        }
                    }
                    else if (base.Request.Params["type"].ToString() == "add" || this.frmcopyitem == "yes")
                    {
                        if (this.ParentEstimateItemID != (long)0)
                        {
                            long num5 = (long)0;
                            this.EstimateItemID = this.ParentEstimateItemID;
                            num5 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "U", false, this.ParentEstimateItemID);
                            DataTable dataTable = EstimatesBasePage.Estimate_SingleItem_Subitem_By_EstimateItemID(this.CompanyID, this.ParentEstimateItemID, this.ParentEstimateType);
                            foreach (DataRow row in dataTable.Rows)
                            {
                                this.ParentItemID = Convert.ToInt64(row["EstSPBWOUCitemID"].ToString());
                            }
                            foreach (DataRow dataRow in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                            {
                                this.EstTypeFromSP = dataRow["EstimateType"].ToString();
                                this.ParentItemType = dataRow["EstimateType"].ToString();
                            }
                            if (base.Request.Params["type"].ToString() == "add")
                            {
                                EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, num5, ConnectionClass.IsHandy);
                            }
                            this.Est_OtherCost_Insert(this.ParentItemID, this.ParentEstimateType, this.EstimateItemID);
                            this.EstimateItemID = num5;
                        }
                        else
                        {
                            this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "U", true, this.ParentItemID);
                            if (base.Request.Params["type"].ToString() == "add")
                            {
                                EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
                            }
                            if (this.jobID > (long)0)
                            {
                                long estimateItemID = this.EstimateItemID;
                                long num6 = this.jobID;
                                commonClass _commonClass = this.objJava;
                                now = DateTime.Now;
                                JobBasePage.EstimateItems_ProgressToJob(estimateItemID, num6, false, Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
                            }
                            this.ParentEstimateItemID = (long)0;
                            this.ParentEstimateType = "U";
                            EstimatesBasePage.update_OtherCostItemQty(this.EstimateItemID, "U", num1, num2, num3, num4);
                            this.Est_OtherCost_Insert(this.ParentEstimateItemID, this.ParentEstimateType, this.EstimateItemID);
                        }
                        if (this.modulename == "jobs")
                        {
                            string empty = string.Empty;
                            string empty1 = string.Empty;
                            foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                            {
                                empty = row1["PhraseText"].ToString();
                            }
                            foreach (DataRow dataRow1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                            {
                                empty1 = dataRow1["PhraseText"].ToString();
                            }
                            EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty, empty1);
                        }
                    }
                    HttpResponse response = base.Response;
                    estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID };
                    response.Redirect(string.Concat(estimateID));
                }
                else if (base.Request.Params["type"].ToString().ToLower() == "edit" && this.frmcopyitem != "yes")
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        this.EstimateItemID = this.ParentEstimateItemID;
                        DataTable dataTable1 = EstimatesBasePage.Estimate_SingleItem_Subitem_By_EstimateItemID(this.CompanyID, this.ParentEstimateItemID, this.ParentEstimateType);
                        foreach (DataRow row2 in dataTable1.Rows)
                        {
                            this.ParentItemID = Convert.ToInt64(row2["EstSPBWOUCitemID"].ToString());
                        }
                        foreach (DataRow dataRow2 in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                        {
                            this.EstTypeFromSP = dataRow2["EstimateType"].ToString();
                            this.ParentItemType = dataRow2["EstimateType"].ToString();
                        }
                        this.Est_OtherCost_Insert(this.ParentItemID, this.ParentEstimateType, this.EstimateItemID);
                    }
                    else
                    {
                        this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
                        foreach (DataRow row3 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                        {
                            this.QtyNo = Convert.ToInt16(row3["QtyNumber"].ToString());
                        }
                        this.Est_OtherCost_Insert(num, base.Request.Params["esttype"].ToString(), this.EstimateItemID);
                        if (this.hdn_EstQtyList.Value.ToString().Trim().Length > 0)
                        {
                            int num7 = 0;
                            int num8 = 0;
                            int num9 = 0;
                            int num10 = 0;
                            string str1 = this.hdn_EstQtyList.Value.ToString();
                            chrArray = new char[] { '~' };
                            string[] strArrays1 = str1.Split(chrArray);
                            if (strArrays1[0].ToString().Trim().Length > 0)
                            {
                                num7 = Convert.ToInt32(strArrays1[0].ToString());
                            }
                            if (strArrays1[1].ToString().Trim().Length > 0)
                            {
                                num8 = Convert.ToInt32(strArrays1[1].ToString());
                            }
                            if (strArrays1[2].ToString().Trim().Length > 0)
                            {
                                num9 = Convert.ToInt32(strArrays1[2].ToString());
                            }
                            if (strArrays1[3].ToString().Trim().Length > 0)
                            {
                                num10 = Convert.ToInt32(strArrays1[3].ToString());
                            }
                            EstimatesBasePage.update_OtherCostItemQty(this.EstimateItemID, "U", num7, num8, num9, num10);
                        }
                        EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "U");
                    }
                    if (this.IsProductCreated == 1)
                    {
                        int num11 = 0;
                        if (this.chkPoduct1.Checked)
                        {
                            num11 = 1;
                        }
                        else if (this.chkPoduct2.Checked)
                        {
                            num11 = 2;
                        }
                        DataTable dataTable2 = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "U");
                        if (dataTable2.Rows.Count > 0)
                        {
                            dataTable2.Rows[0]["PricecatalogueID"].ToString();
                            if (num11 == 1 || num11 == 2)
                            {
                                EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable2.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "U", num11);
                            }
                        }
                    }
                    string empty2 = string.Empty;
                    if (this.modulename.ToLower() == "jobs")
                    {
                        empty2 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
                    }
                    else if (this.modulename.ToLower() == "invoice")
                    {
                        empty2 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
                    }
                    if (empty2.ToLower() != "yes")
                    {
                        HttpResponse httpResponse = base.Response;
                        object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                        httpResponse.Redirect(string.Concat(objArray));
                    }
                    else
                    {
                        HttpResponse response1 = base.Response;
                        estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID));
                    }
                }
                else if (base.Request.Params["type"].ToString() == "add" || this.frmcopyitem == "yes")
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        this.EstimateItemID = this.ParentEstimateItemID;
                        DataTable dataTable3 = EstimatesBasePage.Estimate_SingleItem_Subitem_By_EstimateItemID(this.CompanyID, this.ParentEstimateItemID, this.ParentEstimateType);
                        foreach (DataRow dataRow3 in dataTable3.Rows)
                        {
                            this.ParentItemID = Convert.ToInt64(dataRow3["EstSPBWOUCitemID"].ToString());
                        }
                        foreach (DataRow row4 in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                        {
                            this.EstTypeFromSP = row4["EstimateType"].ToString();
                            this.ParentItemType = row4["EstimateType"].ToString();
                        }
                        this.Est_OtherCost_Insert(this.ParentItemID, this.ParentEstimateType, this.EstimateItemID);
                    }
                    else
                    {
                        this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "U", true, this.ParentItemID);
                        if (base.Request.Params["type"].ToString() == "add")
                        {
                            EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
                        }
                        if (this.jobID > (long)0)
                        {
                            long estimateItemID1 = this.EstimateItemID;
                            long num12 = this.jobID;
                            commonClass _commonClass1 = this.objJava;
                            now = DateTime.Now;
                            JobBasePage.EstimateItems_ProgressToJob(estimateItemID1, num12, false, Convert.ToDateTime(_commonClass1.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
                        }
                        this.ParentEstimateItemID = (long)0;
                        this.ParentEstimateType = "U";
                        if (this.hdn_EstQtyList.Value.ToString().Trim().Length > 0)
                        {
                            int num13 = 0;
                            int num14 = 0;
                            int num15 = 0;
                            int num16 = 0;
                            string[] strArrays2 = this.hdn_EstQtyList.Value.ToString().Split(new char[] { '~' });
                            if (strArrays2[0].ToString().Trim().Length > 0)
                            {
                                num13 = Convert.ToInt32(strArrays2[0].ToString());
                            }
                            if (strArrays2[1].ToString().Trim().Length > 0)
                            {
                                num14 = Convert.ToInt32(strArrays2[1].ToString());
                            }
                            if (strArrays2[2].ToString().Trim().Length > 0)
                            {
                                num15 = Convert.ToInt32(strArrays2[2].ToString());
                            }
                            if (strArrays2[3].ToString().Trim().Length > 0)
                            {
                                num16 = Convert.ToInt32(strArrays2[3].ToString());
                            }
                            EstimatesBasePage.update_OtherCostItemQty(this.EstimateItemID, "U", num13, num14, num15, num16);
                        }
                        this.Est_OtherCost_Insert(this.ParentEstimateItemID, this.ParentEstimateType, this.EstimateItemID);
                    }
                    if (this.modulename == "jobs")
                    {
                        string str2 = string.Empty;
                        string empty3 = string.Empty;
                        foreach (DataRow dataRow4 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                        {
                            str2 = dataRow4["PhraseText"].ToString();
                        }
                        foreach (DataRow row5 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                        {
                            empty3 = row5["PhraseText"].ToString();
                        }
                        EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, str2, empty3);
                        string str3 = string.Empty;
                        foreach (DataRow dataRow5 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                        {
                            str3 = dataRow5["StatusID"].ToString();
                        }
                        if (string.Compare(this.modulename, "jobs", true) == 0 && this.ParentEstimateItemID == (long)0)
                        {
                            this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(str3), "job", this.EstimateItemID, (long)0);
                        }
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
                    if (empty4.ToLower() == "yes")
                    {
                        if (this.ParentEstimateItemID != (long)0)
                        {
                            HttpResponse httpResponse1 = base.Response;
                            estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&ordid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID };
                            httpResponse1.Redirect(string.Concat(estimateID));
                        }
                        else
                        {
                            HttpResponse response2 = base.Response;
                            estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&ordid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID };
                            response2.Redirect(string.Concat(estimateID));
                        }
                    }
                    else if (this.ParentEstimateItemID != (long)0)
                    {
                        HttpResponse httpResponse2 = base.Response;
                        estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID };
                        httpResponse2.Redirect(string.Concat(estimateID));
                    }
                    else
                    {
                        HttpResponse response3 = base.Response;
                        estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID };
                        response3.Redirect(string.Concat(estimateID));
                    }
                }
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
        }

        protected void btncostSkip_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.modulename.ToLower() == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            if (empty.ToLower() == "yes")
            {
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemid=", this.ParentEstimateItemID, this.jID, this.InvID };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            HttpResponse httpResponse = base.Response;
            object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemid=", this.ParentEstimateItemID, this.jID, this.InvID };
            httpResponse.Redirect(string.Concat(objArray));
        }

        protected void btnprevious_onclick(object sender, EventArgs e)
        {
            if (this.QueryType != "add")
            {
                if (this.QueryType == "edit")
                {
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        if (this.isfrom_eStore != "yes")
                        {
                            HttpResponse response = base.Response;
                            object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                            response.Redirect(string.Concat(estimateID));
                            return;
                        }
                        HttpResponse httpResponse = base.Response;
                        object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                        httpResponse.Redirect(string.Concat(objArray));
                        return;
                    }
                    HttpResponse response1 = base.Response;
                    object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response1.Redirect(string.Concat(estimateID1));
                }
                return;
            }
            if (base.Request.Params["FromAddAnItem"] != null)
            {
                if (this.isfrom_eStore != "yes")
                {
                    HttpResponse httpResponse1 = base.Response;
                    object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                    httpResponse1.Redirect(string.Concat(objArray1));
                }
                else
                {
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID };
                    response2.Redirect(string.Concat(estimateID2));
                }
            }
            if (this.MainType == "add")
            {
                HttpResponse httpResponse2 = base.Response;
                object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=U&From=F&MainType=", this.MainType, this.jID, this.InvID };
                httpResponse2.Redirect(string.Concat(objArray2));
            }
            if (this.ParentEstimateItemID == (long)0)
            {
                HttpResponse response3 = base.Response;
                object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=U&From=F&MainType=", this.MainType, this.jID, this.InvID };
                response3.Redirect(string.Concat(estimateID3));
                return;
            }
            if (this.isfrom_eStore != "yes")
            {
                HttpResponse httpResponse3 = base.Response;
                object[] objArray3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                httpResponse3.Redirect(string.Concat(objArray3));
                return;
            }
            HttpResponse response4 = base.Response;
            object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&ordid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
            response4.Redirect(string.Concat(estimateID4));
        }

        private void Call_Delete_Other_Variable()
        {
            EstimateBasePage.estimate_othercost_variableqty_delete(this.CompanyID, this.EstOtherCostID);
        }

        private void Est_OtherCost_Insert(long ItemID, string EstType, long EstimateItemID)
        {
            this.Session["IsOthChangedInAdd"] = null;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            empty = EstimateCommonMethods.GetCommonItemDescription_ForAllTypes(EstimateItemID);
            string value = this.hdnEditOtherCostValues.Value;
            char[] chrArray = new char[] { 'µ' };
            string[] strArrays = value.Split(chrArray);
            foreach (DataRow row in EstimatesBasePage.CopyesttitletoitemTitle(this.CompanyID, this.EstimateID).Rows)
            {
                if (this.QueryType != "add")
                {
                    if (this.QueryType != "edit")
                    {
                        continue;
                    }
                    foreach (DataRow dataRow in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, EstimateItemID, "U").Rows)
                    {
                        dataRow["itemtitle"].ToString();
                    }
                }
                else
                {
                    row["EstimateTitle"].ToString();
                }
            }
            try
            {
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    this.Session["AddAnItemtitem"].ToString();
                }
            }
            catch
            {
            }
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                long num = (long)0;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                decimal num1 = new decimal(0);
                string str2 = string.Empty;
                string empty3 = string.Empty;
                decimal num2 = new decimal(0);
                string str3 = string.Empty;
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                int num16 = 0;
                decimal num17 = new decimal(0);
                decimal num18 = new decimal(0);
                decimal num19 = new decimal(0);
                decimal num20 = new decimal(0);
                int num21 = 0;
                int num22 = 0;
                DateTime now = DateTime.Now;
                num21 = Convert.ToInt32(this.Session["UserID"].ToString());
                string empty4 = string.Empty;
                string str4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                string empty6 = string.Empty;
                decimal num23 = new decimal(0);
                decimal num24 = new decimal(0);
                decimal num25 = new decimal(0);
                decimal num26 = new decimal(0);
                decimal num27 = new decimal(0);
                decimal num28 = new decimal(0);
                int num29 = 0;
                long estOtherCostID = (long)0;
                string str6 = strArrays[i];
                chrArray = new char[] { '±' };
                string[] strArrays1 = str6.Split(chrArray);
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    string str7 = strArrays1[j];
                    chrArray = new char[] { '»' };
                    string[] strArrays2 = str7.Split(chrArray);
                    if (string.Compare(strArrays2[0], "EstOtherCostID", true) == 0)
                    {
                        if (strArrays2[0].ToString() == "0")
                        {
                            this.EstOtherCostID = (long)0;
                            num22 = 0;
                        }
                        else
                        {
                            this.EstOtherCostID = Convert.ToInt64(strArrays2[1].ToString());
                            num22 = Convert.ToInt32(this.Session["UserID"].ToString());
                        }
                    }
                    if (string.Compare(strArrays2[0], "OtherCostID", true) == 0)
                    {
                        num = Convert.ToInt64(strArrays2[1].ToString());
                    }
                    if (string.Compare(strArrays2[0], "OtherCostName", true) == 0)
                    {
                        strArrays2[1].ToString();
                    }
                    if (string.Compare(strArrays2[0], "CalculationType", true) == 0)
                    {
                        empty2 = strArrays2[1].ToString();
                    }
                    if (string.Compare(strArrays2[0], "Minimum", true) == 0)
                    {
                        num1 = Convert.ToDecimal(strArrays2[1].ToString());
                    }
                    if (string.Compare(strArrays2[0], "Description", true) == 0)
                    {
                        str2 = strArrays2[1].ToString();
                    }
                    if (empty2 == "t" || empty2 == "q")
                    {
                        if (string.Compare(strArrays2[0], "DefaultQtyType", true) == 0)
                        {
                            empty3 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FixedQty", true) == 0)
                        {
                            num2 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "VariableQty", true) == 0)
                        {
                            str3 = strArrays2[1].ToString();
                        }
                    }
                    if (empty2 == "t")
                    {
                        if (string.Compare(strArrays2[0], "HourlyRate", true) == 0)
                        {
                            num3 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SetUpTime", true) == 0)
                        {
                            num4 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Hours", true) == 0)
                        {
                            num5 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Passes", true) == 0)
                        {
                            num6 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Markup", true) == 0)
                        {
                            num7 = Convert.ToDecimal(strArrays2[1].ToString());
                            num8 = Convert.ToDecimal(strArrays2[1].ToString());
                            num9 = Convert.ToDecimal(strArrays2[1].ToString());
                            num10 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "HourlyRunSpeed", true) == 0)
                        {
                            num11 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice", true) == 0)
                        {
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost", true) == 0)
                        {
                            num17 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SectionNo", true) == 0)
                        {
                            num29 = Convert.ToInt32(strArrays2[1]);
                        }
                    }
                    else if (empty2 == "q")
                    {
                        if (string.Compare(strArrays2[0], "UnitRate", true) == 0)
                        {
                            num12 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "UnitRate1", true) == 0)
                        {
                            num26 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "UnitRate2", true) == 0)
                        {
                            num27 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "UnitRate3", true) == 0)
                        {
                            num28 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Quantity", true) == 0)
                        {
                            num5 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Quantity1", true) == 0)
                        {
                            num23 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Quantity2", true) == 0)
                        {
                            num24 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Quantity3", true) == 0)
                        {
                            num25 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Markup", true) == 0)
                        {
                            num7 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Markup1", true) == 0)
                        {
                            num8 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Markup2", true) == 0)
                        {
                            num9 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Markup3", true) == 0)
                        {
                            num10 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "SetUpTime", true) == 0)
                        {
                            num4 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "HourlyRate", true) == 0)
                        {
                            num3 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice", true) == 0 && !(strArrays2[1] == ""))
                        {
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice1", true) == 0 && !(strArrays2[1] == ""))
                        {
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice2", true) == 0 && !(strArrays2[1] == ""))
                        {
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice3", true) == 0 && !(strArrays2[1] == ""))
                        {
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost", true) == 0)
                        {
                            num17 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Cost1", true) == 0)
                        {
                            num18 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Cost2", true) == 0)
                        {
                            num19 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "Cost3", true) == 0)
                        {
                            num20 = (strArrays2[1] == "" ? new decimal(0) : Convert.ToDecimal(strArrays2[1].ToString()));
                        }
                        if (string.Compare(strArrays2[0], "SectionNo", true) == 0)
                        {
                            num29 = Convert.ToInt32(strArrays2[1]);
                        }
                    }
                    else if (empty2 == "f" || empty2 == "m")
                    {
                        if (string.Compare(strArrays2[0], "Formula", true) == 0)
                        {
                            empty4 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FormulaTag", true) == 0)
                        {
                            str4 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FormulaTag1", true) == 0)
                        {
                            empty5 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FormulaTag2", true) == 0)
                        {
                            str5 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "FormulaTag3", true) == 0)
                        {
                            empty6 = strArrays2[1].ToString();
                        }
                        if (string.Compare(strArrays2[0], "Markup", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num7 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Markup1", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num8 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Markup2", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num9 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Markup3", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num10 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice1", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice2", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SellingPrice3", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num17 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost1", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num18 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost2", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num19 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "Cost3", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num20 = Convert.ToDecimal(strArrays2[1].ToString());
                        }
                        if (string.Compare(strArrays2[0], "SectionNo", true) == 0)
                        {
                            strArrays2[1] = (strArrays2[1].ToString() == "" ? "0" : strArrays2[1].ToString());
                            num29 = Convert.ToInt32(strArrays2[1]);
                        }
                    }
                }
                DataTable dataTable = new DataTable();
                if (string.Compare(EstType, "B", true) == 0)
                {
                    dataTable = EstimateBasePage.booklet_sectionID_select(this.CompanyID, ItemID);
                    int num30 = 0;
                    foreach (DataRow row1 in dataTable.Rows)
                    {
                        if (num29 == num30)
                        {
                            Convert.ToInt64(row1["EstimateBookletitemID"]);
                        }
                        num30++;
                    }
                    this.EstBookletItemID = ItemID;
                }
                else if (string.Compare(EstType, "N", true) == 0)
                {
                    dataTable = EstimatesBasePage.lithoncr_item_select_othercostasadditional(this.CompanyID, ItemID);
                    int num31 = 0;
                    foreach (DataRow dataRow1 in dataTable.Rows)
                    {
                        if (num29 == num31)
                        {
                            Convert.ToInt64(dataRow1["EstimateLithoNcritemID"]);
                        }
                        num31++;
                    }
                    this.EstBookletItemID = ItemID;
                }
                else if (string.Compare(EstType, "K", true) == 0)
                {
                    dataTable = EstimatesBasePage.lithobooklet_item_select_othercostasadditional(this.CompanyID, ItemID);
                    int num32 = 0;
                    foreach (DataRow row2 in dataTable.Rows)
                    {
                        if (num29 == num32)
                        {
                            Convert.ToInt64(row2["EstimateLithoBookletItemID"]);
                        }
                        num32++;
                    }
                    this.EstBookletItemID = ItemID;
                }
                else if (string.Compare(EstType, "S", true) == 0)
                {
                    dataTable = EstimatesBasePage.Estimate_Single_Item_Select_By_EstimateItemID(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "P", true) == 0)
                {
                    dataTable = EstimatesBasePage.Estimate_Summary_Pad_Item_By_EstimateItem_ID(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "L", true) == 0)
                {
                    dataTable = EstimatesBasePage.Estimate_Summary_Large_Item_By_EstimateItem_ID(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "F", true) == 0)
                {
                    dataTable = EstimatesBasePage.litho_estimate_select(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "D", true) == 0)
                {
                    dataTable = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, EstimateItemID);
                }
                else if (string.Compare(EstType, "O", true) == 0)
                {
                    dataTable = EstimateBasePage.Estimate_Summary_Outwork_Select_By_EstimateItemID(this.CompanyID, EstimateItemID);
                }
                try
                {
                    if (this.QueryType == "edit")
                    {
                        DataTable dataTable1 = EstimatesBasePage.estimate_othercost_ProfitTax_select(Convert.ToInt64(HttpContext.Current.Request.QueryString["EstItemID"]), Convert.ToInt64(this.EstOtherCostID));
                        foreach (DataRow dataRow2 in dataTable1.Rows)
                        {
                            num13 = Convert.ToDecimal(dataRow2["ProfitMargin"]);
                            num15 = Convert.ToDecimal(dataRow2["Tax"]);
                            num16 = Convert.ToInt32(dataRow2["TaxID"]);
                        }
                        num13 = (this.Session["OtherCostProfit"] != null ? Convert.ToDecimal(this.Session["OtherCostProfit"]) : num13);
                        num15 = (this.Session["OtherCostTax"] != null ? Convert.ToDecimal(this.Session["OtherCostTax"]) : num15);
                        num16 = (this.Session["OtherCostTaxID"] != null ? Convert.ToInt32(this.Session["OtherCostTaxID"]) : num16);
                    }
                    long num33 = (long)0;
                    if (!(base.Request.Params["type"].ToString().ToLower() == "edit") || !(this.frmcopyitem != "yes"))
                    {
                        num33 = EstimateBasePage.estimate_othercost_insert(this.CompanyID, this.EstOtherCostID, EstType.ToUpper(), ItemID, EstimateItemID, num, empty2, num5, num3, num12, num4, num11, num6, num17, num1, num7, this.Objclss.ReplaceSingleQuote(this.hdn_ItemTitle.Value), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(str2), num13, num14, num15, num21, num22, now, empty, empty4, str4, ItemID, num29, num18, num19, num20, num8, num9, num10, empty5, str5, empty6, num26, num27, num28, num23, num24, num25, num16, estOtherCostID);
                    }
                    else if (this.ParentEstimateItemID != (long)0)
                    {
                        num33 = EstimateBasePage.estimate_othercost_insert(this.CompanyID, this.EstOtherCostID, EstType.ToUpper(), ItemID, EstimateItemID, num, empty2, num5, num3, num12, num4, num11, num6, num17, num1, num7, this.Objclss.ReplaceSingleQuote(this.hdn_ItemTitle.Value), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(str2), num13, num14, num15, num21, num22, now, empty, empty4, str4, ItemID, num29, num18, num19, num20, num8, num9, num10, empty5, str5, empty6, num26, num27, num28, num23, num24, num25, num16, estOtherCostID);
                    }
                    else if (this.EstOtherCostID != (long)0)
                    {
                        string value1 = this.hdn_EditOtherCostSelected.Value;
                        if (this.hdn_EditOtherCostNewItemSelected.Value != "true")
                        {
                            num33 = EstimateBasePage.estimate_othercost_insert(this.CompanyID, this.EstOtherCostID, EstType.ToUpper(), ItemID, EstimateItemID, num, empty2, num5, num3, num12, num4, num11, num6, num17, num1, num7, this.Objclss.ReplaceSingleQuote(this.hdn_ItemTitle.Value), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(str2), num13, num14, num15, num21, num22, now, empty, empty4, str4, ItemID, num29, num18, num19, num20, num8, num9, num10, empty5, str5, empty6, num26, num27, num28, num23, num24, num25, num16, estOtherCostID);
                        }
                        else
                        {
                            EstimateBasePage.Estimate_Summary_OtherCost_Remove(this.CompanyID, this.EstOtherCostID);
                            estOtherCostID = this.EstOtherCostID;
                        }
                    }
                    else
                    {
                        num33 = EstimateBasePage.estimate_othercost_insert(this.CompanyID, this.EstOtherCostID, EstType.ToUpper(), ItemID, EstimateItemID, num, empty2, num5, num3, num12, num4, num11, num6, num17, num1, num7, this.Objclss.ReplaceSingleQuote(this.hdn_ItemTitle.Value), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(""), this.Objclss.ReplaceSingleQuote(str2), num13, num14, num15, num21, num22, now, empty, empty4, str4, ItemID, num29, num18, num19, num20, num8, num9, num10, empty5, str5, empty6, num26, num27, num28, num23, num24, num25, num16, estOtherCostID);
                    }
                    this.Session["Othercostdescription"] = this.Objclss.ReplaceSingleQuote(str2);
                    this.Session["OtherCostProfit"] = null;
                    this.Session["OtherCostTax"] = null;
                    this.Session["OtherCostTaxID"] = null;
                    if (EstType.ToUpper() == "C")
                    {
                        EstimatesBasePage.estimate_othercost_typeid_update(this.CompanyID, EstimateItemID, EstType.ToUpper(), ItemID);
                    }
                    this.EstOtherCostID = (this.EstOtherCostID == (long)0 ? num33 : this.EstOtherCostID);
                    if (EstType.ToUpper() != "U")
                    {
                        object obj1 = str;
                        object[] objArray = new object[] { obj1, this.EstOtherCostID, "±", null, null };
                        string value2 = this.hdn_IsOthChangedInAdd.Value;
                        chrArray = new char[] { '»' };
                        objArray[3] = value2.Split(chrArray)[i].ToString();
                        objArray[4] = "µ";
                        str = string.Concat(objArray);
                    }
                    if (string.Compare(empty2, "f", true) == 0 || string.Compare(empty2, "m", true) == 0)
                    {
                        this.Insert_OtherVariableQty(EstType.ToUpper(), EstimateItemID, this.EstOtherCostID, empty2, empty3, num2, str3, num3, num4, num12, num7, num11, num6, num5, empty4, str4, dataTable, num29, ItemID, empty5, str5, empty6, num17, num18, num19, num20);
                    }
                    else
                    {
                        this.Insert_OtherVariableQty(EstType.ToUpper(), EstimateItemID, this.EstOtherCostID, empty2, empty3, num2, str3, num3, num4, num12, num7, num11, num6, num5, empty4, str4, dataTable, num29, num17, num18, num19, num20, num26, num27, num28, num8, num9, num10, num23, num24, num25);
                    }
                }
                catch (Exception exception)
                {
                }
            }
            if (EstType.ToUpper() != "U")
            {
                this.Session["IsOthChangedInAdd"] = str.ToString();
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(EstimateItemID);
            if (this.QueryType != "add")
            {
                EstimateCommonMethods.UpdateDescription(EstimateItemID, this.EstimateID, "U", false);
                if (this.ParentItemID == (long)0)
                {
                    EstimatesBasePage.itemTitleUpdate_for_eStoreOtherCost(this.CompanyID, this.EstimateID, EstimateItemID, base.SpecialEncode(this.hdn_ItemTitle.Value));
                }
            }
            else if (this.ParentItemID == (long)0)
            {
                EstimateCommonMethods.UpdateDescription(EstimateItemID, this.EstimateID, "U", false);
                EstimatesBasePage.itemTitleUpdate_for_eStoreOtherCost(this.CompanyID, this.EstimateID, EstimateItemID, base.SpecialEncode(this.hdn_ItemTitle.Value));
            }
            if (this.ParentEstimateItemID == (long)0)
            {
                JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, EstimateItemID, this.QtyNo, this.EstimateID);
            }
            EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, EstimateItemID, "U");
            this.Insert_activity_history(this.CompanyID, this.EstimateID, EstimateItemID);
        }

        [WebMethod]
        public static string GetOtherCost_List(string StrCompanyID, string StrCataID, string ParentEstimateType)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_othercost_select_by_categoryid(Convert.ToInt32(StrCompanyID), Convert.ToInt32(StrCataID), ParentEstimateType);
            return (new BaseClass()).ReplaceSingleQuote(empty);
        }

        [WebMethod]
        public static string GetOtherCost_Tab_List(string StrCompanyID, string ParentEstimateType, bool IsOtherCostSequence)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_othercost_select_category(Convert.ToInt32(StrCompanyID), ParentEstimateType, IsOtherCostSequence);
            return (new BaseClass()).ReplaceSingleQuote(empty);
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
            string str = "U";
            string str1 = "Other Costs Item";
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
                        this.objnotes.Estimate_type = str1;
                        if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != ""))
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                        }
                        else if (base.Request.Params["type"].ToLower() != "edit")
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
                        foreach (DataRow row1 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = row1["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                    }
                    this.objnotes.ModuleID = ModuleID;
                    this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
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
            string empty1 = string.Empty;
            foreach (DataRow dataRow1 in Notes.select_item_Title_for_Activity_History(CompanyID, ModuleID, EstimateItemID, str).Rows)
            {
                empty1 = dataRow1["itemtitle"].ToString();
            }
            if (base.Request.Params["FromAddAnItem"] != null || base.Request.Params["FrmAddAnItem"] == "Y")
            {
                string empty2 = string.Empty;
                foreach (DataRow row2 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                {
                    empty2 = row2["rownumber"].ToString();
                }
                if (this.modulename == "estimates")
                {
                    this.objnotes.Item_title = empty1;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                    this.objnotes.Item_number = string.Concat("Item ", empty2);
                    this.objnotes.Estimate_type = str1;
                }
                else if (this.modulename == "jobs")
                {
                    this.objnotes.Item_title = empty1;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                    this.objnotes.Item_number = string.Concat("Item ", empty2);
                    this.objnotes.Job_type = str1;
                }
                else if (this.modulename == "invoice")
                {
                    this.objnotes.Item_title = empty1;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                    this.objnotes.Item_number = string.Concat("Item ", empty2);
                    this.objnotes.Invoice_type = str1;
                }
                this.objnotes.ModuleID = ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass1 = this.objJava;
                DateTime dateTime = DateTime.Now;
                _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), CompanyID, this.UserID, true);
                this.objnotes.CompanyID = CompanyID;
                this.objnotes.ItemID = EstimateItemID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                return;
            }
            string str2 = string.Empty;
            if (this.modulename == "estimates")
            {
                foreach (DataRow dataRow2 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "", (long)0).Rows)
                {
                    str2 = dataRow2["Estimatenumber"].ToString();
                }
                this.objnotes.Estimate_type = str1;
                this.objnotes.Estimate_number = str2;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
            }
            else if (this.modulename == "jobs")
            {
                foreach (DataRow row3 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "job", (long)0).Rows)
                {
                    str2 = row3["jobnumber"].ToString();
                }
                this.objnotes.Job_type = str1;
                this.objnotes.ModuleName = "job";
                this.objnotes.Job_number = str2;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDirCreate);
            }
            else if (this.modulename == "invoice")
            {
                foreach (DataRow dataRow3 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "invoice", (long)0).Rows)
                {
                    str2 = dataRow3["invoicenumber"].ToString();
                }
                this.objnotes.Invoice_type = str1;
                this.objnotes.Invoice_number = str2;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvDirCreate);
            }
            this.objnotes.ModuleID = ModuleID;
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass2 = this.objnotes;
            commonClass _commonClass2 = this.objJava;
            DateTime now1 = DateTime.Now;
            _notesclass2.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now1.ToString(), CompanyID, this.UserID, true);
            this.objnotes.CompanyID = CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
        }

        public void Insert_OtherVariableQty(string EstType, long EstimateItemID, long EstOtherCostID, string CalculationType, string DefaultQtyType, decimal FixedQty, string VariableQty, decimal HourlyRate, decimal SetUpTime, decimal UnitRate, decimal Markup, decimal HourlyRunSpeed, decimal Passes, decimal HoursOrQuantity, string Formula, string FormulaTag, DataTable dtSec, int SectionNo, long SectionID, string FormulaTag1, string FormulaTag2, string FormulaTag3, decimal Cost, decimal Cost1, decimal Cost2, decimal Cost3)
        {
            long num = (long)0;
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string str = string.Empty;
            str = (string.Compare(EstType, "B", true) == 0 || string.Compare(EstType, "N", true) == 0 || string.Compare(EstType, "K", true) == 0 ? EstimatesBasePage.estimates_quantity_select(this.CompanyID, this.EstBookletItemID, EstType) : EstimatesBasePage.estimates_quantity_select(this.CompanyID, EstimateItemID, EstType));
            char[] chrArray = new char[] { '#' };
            string[] strArrays = str.Split(chrArray);
            ArrayList arrayLists = new ArrayList();
            ArrayList arrayLists1 = new ArrayList();
            long num1 = (long)0;
            int num2 = 0;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str1 = strArrays[i];
                chrArray = new char[] { '$' };
                string[] strArrays1 = str1.Split(chrArray);
                if ((int)strArrays1.Length > 0 && Convert.ToInt32(strArrays1[2]) > 0)
                {
                    num1 = Convert.ToInt64(strArrays1[0]);
                    num2 = Convert.ToInt32(strArrays1[2]);
                    long num3 = (long)0;
                    decimal num4 = new decimal(0);
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    decimal num9 = new decimal(0);
                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    string str2 = string.Empty;
                    decimal num10 = new decimal(0);
                    decimal num11 = new decimal(0);
                    decimal num12 = new decimal(0);
                    long num13 = (long)0;
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
                    decimal num24 = new decimal(0);
                    string empty3 = string.Empty;
                    string str3 = string.Empty;
                    decimal num25 = new decimal(0);
                    decimal num26 = new decimal(0);
                    decimal num27 = new decimal(0);
                    decimal num28 = new decimal(0);
                    decimal num29 = new decimal(0);
                    decimal num30 = new decimal(0);
                    decimal num31 = new decimal(0);
                    decimal num32 = new decimal(0);
                    decimal num33 = new decimal(0);
                    decimal num34 = new decimal(0);
                    decimal num35 = new decimal(0);
                    decimal num36 = new decimal(0);
                    decimal num37 = new decimal(0);
                    decimal count = dtSec.Rows.Count;
                    decimal num38 = new decimal(0);
                    decimal costexMarkupForsummary = new decimal(0);
                    decimal num39 = new decimal(0);
                    decimal num40 = new decimal(0);
                    decimal num41 = new decimal(0);
                    decimal num42 = new decimal(0);
                    decimal num43 = new decimal(0);
                    decimal num44 = new decimal(0);
                    decimal num45 = new decimal(0);
                    decimal num46 = new decimal(0);
                    decimal num47 = new decimal(0);
                    decimal num48 = new decimal(0);
                    decimal num49 = new decimal(0);
                    decimal num50 = new decimal(0);
                    decimal num51 = new decimal(0);
                    decimal num52 = new decimal(0);
                    decimal num53 = new decimal(0);
                    int num54 = 0;
                    bool flag = false;
                    foreach (DataRow row in dtSec.Rows)
                    {
                        if (EstType.ToLower() != "o")
                        {
                            if (string.Compare(EstType, "B", true) == 0)
                            {
                                this.EstBookletSectionID = Convert.ToInt64(row["EstimateBookletItemID"]);
                                num27 = Convert.ToDecimal(row["NoOfSignatures"]);
                                Convert.ToDecimal(row["PagesPerSignature"]);
                                num28 = Convert.ToDecimal(row["NoOfPagesInSection"]);
                                flag = (SectionID != Convert.ToInt64(row["EstimateBookletItemID"]) ? false : true);
                            }
                            else if (string.Compare(EstType, "K", true) != 0)
                            {
                                flag = true;
                            }
                            else
                            {
                                this.EstBookletSectionID = Convert.ToInt64(row["EstimateLithoBookletItemID"]);
                                num27 = Convert.ToDecimal(row["NoOfSignatures"]);
                                Convert.ToDecimal(row["PagesPerSignature"]);
                                num28 = Convert.ToDecimal(row["NoOfPagesInSection"]);
                                flag = (SectionID != Convert.ToInt64(row["EstimateLithoBookletItemID"]) ? false : true);
                            }
                            if (string.Compare(EstType, "N", true) == 0)
                            {
                                num52 = Convert.ToDecimal(row["NcrPartsPerSet"]);
                                num53 = Convert.ToDecimal(row["NcrSetsPerPad"]);
                            }
                            num25 = Convert.ToDecimal(row["Setupspoilage"]);
                            num26 = Convert.ToDecimal(row["RunningSpoilage"]);
                            str2 = row["PressType"].ToString();
                            empty1 = row["Colour"].ToString();
                            empty2 = row["SideColor"].ToString();
                            num37 = num37 + num28;
                            if (flag)
                            {
                                foreach (DataRow dataRow in EstimatesBasePage.Estimate_Summary_Calculation_Select_By_EstimateItem_ID(this.CompanyID, EstimateItemID, this.EstBookletSectionID).Rows)
                                {
                                    num3 = Convert.ToInt64(dataRow["EstimateCalculationID"]);
                                    num4 = Convert.ToDecimal(dataRow["PaperUnitPrice"]);
                                    num5 = Convert.ToDecimal(dataRow["PaperWeight"]);
                                    num6 = Convert.ToDecimal(dataRow["PaperMarkup"]);
                                    num7 = Convert.ToDecimal(dataRow["PressMarkUp"]);
                                    num8 = Convert.ToDecimal(dataRow["PressSetupCharge"]);
                                    num9 = Convert.ToDecimal(dataRow["PressMinimumRunningCharge"]);
                                    str2 = dataRow["PressType"].ToString();
                                    num10 = Convert.ToDecimal(dataRow["BlackChargeableRate"]);
                                    num11 = Convert.ToDecimal(dataRow["ColorChargeableRate"]);
                                    num12 = Convert.ToDecimal(dataRow["NoOfChargeableSheets"]);
                                    num13 = Convert.ToInt64(dataRow["SpeedWeightTableID"]);
                                    num14 = Convert.ToDecimal(dataRow["HourlyCharge"]);
                                    Convert.ToDecimal(dataRow["PrintPerHourLow"]);
                                    Convert.ToDecimal(dataRow["PrintPerHourMedium"]);
                                    Convert.ToDecimal(dataRow["PrintPerHourHigh"]);
                                    num15 = Convert.ToDecimal(dataRow["GuillotineSetupCharge"]);
                                    num16 = Convert.ToDecimal(dataRow["GuillotineMinimumRunningCharge"]);
                                    num17 = Convert.ToDecimal(dataRow["GuillotineMarkUp"]);
                                    num18 = Convert.ToDecimal(dataRow["GuillotineCostPerCut"]);
                                    num19 = Convert.ToDecimal(dataRow["GuillotinePaperWeight1"]);
                                    num20 = Convert.ToDecimal(dataRow["GuillotineMaximumThroat1"]);
                                    num21 = Convert.ToDecimal(dataRow["GuillotinePaperWeight2"]);
                                    num22 = Convert.ToDecimal(dataRow["GuillotineMaximumThroat2"]);
                                    num23 = Convert.ToDecimal(dataRow["GuillotinePaperWeight3"]);
                                    num24 = Convert.ToDecimal(dataRow["GuillotineMaximumThroat3"]);
                                    dataRow["OneSqCmInkCost"].ToString();
                                    Convert.ToDecimal(dataRow["InkMarkup"]);
                                }
                            }
                            decimal num55 = new decimal(0);
                            string str4 = "";
                            if (string.Compare(EstType, "B", true) == 0)
                            {
                                str4 = (string.Compare(row["BookletFormat"].ToString(), "Portrait", true) != 0 ? "L" : "P");
                                num29 = num27;
                                decimal num56 = new decimal(0);
                                num34 = EstimateBasePage.Booklet_Print_Sheet_Calculation(num2, num27, num25, num26, out num56);
                                num33 = num34 - num56;
                                num51 = num56;
                                num50 = num26;
                            }
                            else if (string.Compare(EstType, "K", true) == 0)
                            {
                                str4 = (string.Compare(row["BookletFormat"].ToString(), "Portrait", true) != 0 ? "L" : "P");
                                num29 = num27;
                                decimal num57 = new decimal(0);
                                num34 = EstimatesBasePage.LithoBooklet_Print_Sheet_Calculation(num2, num27, num25, num26, out num57);
                                num33 = num34 - num57;
                                num51 = num57;
                                num50 = num26;
                            }
                            else if (string.Compare(EstType, "N", true) != 0)
                            {
                                if (string.Compare(row["PrintLayout"].ToString(), "P", true) != 0)
                                {
                                    str4 = "L";
                                    num29 = Convert.ToInt32(row["LandscapeValue"]);
                                }
                                else
                                {
                                    str4 = "P";
                                    num29 = Convert.ToInt32(row["PortraitValue"]);
                                }
                                decimal num58 = new decimal(0);
                                num34 = EstimateBasePage.PrintSheets_Calculation_For_SingleItem(num2, num29, num25, num26, out num58);
                                num33 = num34 - num58;
                                num51 = num58;
                                num50 = num26;
                            }
                            else
                            {
                                if (string.Compare(row["PrintLayout"].ToString(), "P", true) != 0)
                                {
                                    str4 = "L";
                                    num29 = Convert.ToInt32(row["LandscapeValue"]);
                                }
                                else
                                {
                                    str4 = "P";
                                    num29 = Convert.ToInt32(row["PortraitValue"]);
                                }
                                decimal num59 = new decimal(0);
                                num34 = EstimateBasePage.PrintSheets_Calculation_For_SingleItemForNCR(num2, num53, num25, num26, out num59);
                                num33 = num34 - num59;
                                num51 = num59;
                                num50 = num26;
                            }
                            num35 = num35 + num33;
                            num36 = num36 + num34;
                            decimal num60 = num34;
                            if (flag)
                            {
                                num48 = num34 * num4;
                                num48 = this.ReturnExact2Decimal(num48);
                                num49 = num48 + ((num48 * num6) / new decimal(100));
                                num49 = this.ReturnExact2Decimal(num49);
                                num30 = num28;
                                num31 = num33;
                                num32 = num34;
                                if (string.Compare(str2, "C", true) == 0)
                                {
                                    num40 = EstimateBasePage.PressCostPerClick(num60, (empty1 == "color" ? num11 : num10), num12);
                                    num40 = this.ReturnExact2Decimal(num40);
                                    if (Convert.ToBoolean(row["IsDoublesided"]))
                                    {
                                        decimal num61 = EstimateBasePage.PressCostPerClick(num60, (empty2 == "color" ? num11 : num10), num12);
                                        num40 = num40 + this.ReturnExact2Decimal(num61);
                                    }
                                }
                                else if (str2 == "S")
                                {
                                    decimal num62 = new decimal(0);
                                    num40 = EstimateBasePage.SpeedWeightLookup_Cost(this.CompanyID, num60, num5, num14, num13, empty1, num8, num9, num7, ref num62);
                                    num38 = num14;
                                    if (Convert.ToBoolean(row["IsDoublesided"]))
                                    {
                                        decimal num63 = EstimateBasePage.SpeedWeightLookup_Cost(this.CompanyID, num60, num5, num14, num13, empty2, num8, num9, num7, ref num62);
                                        num40 = num40 + num63;
                                        num40 = this.ReturnExact2Decimal(num40);
                                    }
                                }
                                else if (str2 == "Z")
                                {
                                    decimal num64 = new decimal(0);
                                    int num65 = Convert.ToInt32(num34);
                                    if (!Convert.ToBoolean(row["CalculationType"]))
                                    {
                                        foreach (DataRow row1 in EstimateBasePage.estimate_zone_2nd_calculation(this.CompanyID, num3, num65, empty1).Rows)
                                        {
                                            int num66 = Convert.ToInt32(row1["ChargeableSheets"]);
                                            decimal num67 = Convert.ToDecimal(row1["ChargeableRate"]);
                                            num64 = (num67 / num66) * num65;
                                        }
                                    }
                                    else
                                    {
                                        num64 = EstimatesBasePage.Click_Charge_Zone_Cost(this.CompanyID, num3, num65, empty1, ref this.Zonemarkup, false, Convert.ToInt32(this.PressID), Convert.ToInt32(EstimateItemID), 1);
                                    }
                                    num40 = num64;
                                    if (Convert.ToBoolean(row["IsDoublesided"]))
                                    {
                                        decimal num68 = new decimal(0);
                                        if (!Convert.ToBoolean(row["CalculationType"]))
                                        {
                                            foreach (DataRow dataRow1 in EstimateBasePage.estimate_zone_2nd_calculation(this.CompanyID, num3, num65, empty2).Rows)
                                            {
                                                int num69 = Convert.ToInt32(dataRow1["ChargeableSheets"]);
                                                decimal num70 = Convert.ToDecimal(dataRow1["ChargeableRate"]);
                                                num68 = (num70 / num69) * num65;
                                            }
                                        }
                                        else
                                        {
                                            num68 = EstimatesBasePage.Click_Charge_Zone_Cost(this.CompanyID, num3, num65, empty2, ref this.Zonemarkup, true, Convert.ToInt32(this.PressID), Convert.ToInt32(EstimateItemID), 1);
                                        }
                                        num40 = num40 + num68;
                                        num40 = this.ReturnExact2Decimal(num40);
                                    }
                                }
                                num40 = num40;
                                num40 = this.ReturnExact2Decimal(num40);
                                num41 = (num40 * num7) / new decimal(100);
                                num40 = this.objJava.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num40, num41, num9, out this.CostexMarkup_forsummary, out this.MinimumCostMarkup, ref num8);
                                costexMarkupForsummary = this.CostexMarkup_forsummary + num8;
                                num39 = num40;
                                if (num5 <= num19)
                                {
                                    num55 = num20;
                                }
                                else if (num5 <= num21)
                                {
                                    num55 = num22;
                                }
                                else if (num5 <= num23 || num5 > num23)
                                {
                                    num55 = num24;
                                }
                                if (Convert.ToBoolean(row["IsFirstTrim"]))
                                {
                                    decimal num71 = Convert.ToDecimal(row["Height"]);
                                    decimal num72 = Convert.ToDecimal(row["Width"]);
                                    decimal num73 = Convert.ToDecimal(row["SheetHeight"]);
                                    decimal num74 = Convert.ToDecimal(row["SheetWidth"]);
                                    decimal num75 = Convert.ToDecimal(row["BasisWeight"]);
                                    decimal num76 = new decimal(0);
                                    num42 = EstimateBasePage.Guillotine_First_Trim_Cut(num71, num72, num73, num74, num75, str4, num60, num19, num20, num21, num22, num23, num24, ref num76);
                                    num43 = num18 * num42;
                                    num43 = this.ReturnExact2Decimal(num43);
                                }
                                if (Convert.ToBoolean(row["IsSecondTrim"]))
                                {
                                    num44 = EstimateBasePage.Guillotine_Calculation(this.CompanyID, num60, num55, num29, num15, num16, num17, num18, Convert.ToBoolean(row["IsIncludeGutters"]), num2, ref num45, ref num46);
                                    num44 = this.ReturnExact2Decimal(num44);
                                }
                                if (Convert.ToBoolean(row["IsSecondTrim"]) || Convert.ToBoolean(row["IsFirstTrim"]))
                                {
                                    decimal num77 = num43 + num44;
                                    num47 = this.ReturnExact2Decimal(this.ReturnExact2Decimal(num77));
                                }
                                decimal num78 = (num17 * num17) / new decimal(100);
                                num47 = this.objJava.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num47, num78, num16, out this.CostexMarkup_forsummary, out this.MinimumCostMarkup, ref num15);
                            }
                        }
                        num54++;
                    }
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    string str5 = string.Empty;
                    string empty6 = string.Empty;
                    string str6 = string.Empty;
                    string empty7 = string.Empty;
                    string str7 = string.Empty;
                    if (FormulaTag != "")
                    {
                        chrArray = new char[] { '\u00B6' };
                        string[] strArrays2 = FormulaTag.Split(chrArray);
                        empty5 = strArrays2[1].ToString();
                        str5 = strArrays2[1].ToString();
                        empty6 = strArrays2[0].ToString();
                        if (i == 0)
                        {
                            this.Question_Find_In_Formula(empty5, strArrays2[0], ref arrayLists, ref arrayLists1);
                        }
                    }
                    if (FormulaTag1 != "")
                    {
                        chrArray = new char[] { '\u00B6' };
                        string[] strArrays3 = FormulaTag1.Split(chrArray);
                        str6 = strArrays3[0].ToString();
                        if (i == 1)
                        {
                            this.Question_Find_In_Formula(strArrays3[1].ToString(), strArrays3[0], ref arrayLists, ref arrayLists1);
                        }
                    }
                    if (FormulaTag2 != "")
                    {
                        chrArray = new char[] { '\u00B6' };
                        string[] strArrays4 = FormulaTag2.Split(chrArray);
                        empty7 = strArrays4[0].ToString();
                        if (i == 2)
                        {
                            this.Question_Find_In_Formula(strArrays4[1].ToString(), strArrays4[0], ref arrayLists, ref arrayLists1);
                        }
                    }
                    if (FormulaTag3 != "")
                    {
                        chrArray = new char[] { '\u00B6' };
                        string[] strArrays5 = FormulaTag3.Split(chrArray);
                        str7 = strArrays5[0].ToString();
                        if (i == 3)
                        {
                            this.Question_Find_In_Formula(strArrays5[1].ToString(), strArrays5[0], ref arrayLists, ref arrayLists1);
                        }
                    }
                    for (int j = 0; j < arrayLists.Count; j++)
                    {
                        try
                        {
                            empty5 = empty5.Replace(arrayLists[j].ToString(), arrayLists1[j].ToString());
                        }
                        catch (Exception exception)
                        {
                        }
                    }
                    foreach (DataRow row2 in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                    {
                        empty4 = row2["Key"].ToString();
                        if (EstType != "B" && EstType != "K")
                        {
                            if (EstType == "P")
                            {
                                if (!(empty4.ToLower() == "number of leaves per pad") && empty4.ToLower() == "number of pads")
                                {
                                    empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num2, 0, "", false, false, false));
                                }
                            }
                            else if (EstType == "N")
                            {
                                if (empty4.ToLower() == "parts per set")
                                {
                                    empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num52, 0, "", false, false, false));
                                }
                                else if (empty4.ToLower() == "sets per pad")
                                {
                                    empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num53, 0, "", false, false, false));
                                }
                            }
                        }
                        else if (empty4.ToLower() == "booklet quantity required(section 1)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num2, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "pages in this section only")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num30, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "number of sections")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, count, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "total number of pages (all sections)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num37, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "print sheet quantity this section (excluding spoilage)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num31, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "print sheet quantity this section (including spoilage)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num32, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "print sheet quantity all sections (excluding spoilage)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num35, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "print sheet quantity all sections (including spoilage)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num36, 0, "", false, false, false));
                        }
                        if (empty4.ToLower() == "guillotine bundles")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num45, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "guillotine cost per cut")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num18, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "number of cuts in first trim")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num42, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "number of cuts in second trim")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num46, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "press hourly charge")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num38, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "total press cost price")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, costexMarkupForsummary, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "total press selling price")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num39, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "print sheet quantity (excluding spoilage)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num31, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "print sheet quantity (including spoilage)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num32, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "finished job quantity")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num2, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "paper basis weight (gsm)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num5, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "paper cost (excluding markup)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num48, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() == "paper cost (including markup)")
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num49, 0, "", false, false, false));
                        }
                        else if (empty4.ToLower() != "spoilage percentage used")
                        {
                            empty5 = (empty4.ToLower() != "spoilage sheets used" ? empty5.Replace(empty4, "0") : empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Math.Ceiling(num51), 0, "", false, false, false)));
                        }
                        else
                        {
                            empty5 = empty5.Replace(empty4, this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num50, 0, "", false, false, false));
                        }
                    }
                    string str8 = empty5;
                    empty = empty5;
                    decimal cost = new decimal(0);
                    string empty8 = string.Empty;
                    if (i == 0)
                    {
                        stringBuilder.Append(string.Concat(empty6, "±"));
                        cost = Cost;
                        empty8 = string.Concat(empty6, "¶", str5);
                    }
                    else if (i == 1)
                    {
                        stringBuilder.Append(string.Concat(str6, "±"));
                        cost = Cost1;
                        empty8 = string.Concat(str6, "¶", str5);
                    }
                    else if (i == 2)
                    {
                        stringBuilder.Append(string.Concat(empty7, "±"));
                        cost = Cost2;
                        empty8 = string.Concat(empty7, "¶", str5);
                    }
                    else if (i == 3)
                    {
                        stringBuilder.Append(string.Concat(str7, "±"));
                        cost = Cost3;
                        empty8 = string.Concat(str7, "¶", str5);
                    }
                    decimal num79 = (new MathParser()).Calculate(str8);
                    Convert.ToDecimal(num79.ToString());
                    if (i == 0)
                    {
                        this.Call_Delete_Other_Variable();
                    }
                    EstimatesBasePage.estimate_othercost_variableqty_insert(this.CompanyID, num, EstOtherCostID, num1, new decimal(0), cost, EstType, empty, num2, i, empty8);
                }
                else if (i == 0)
                {
                    this.Call_Delete_Other_Variable();
                }
                if ((int)strArrays1.Length > 0 && Convert.ToInt32(strArrays1[2]) > 0)
                {
                    EstimateBasePage.othercost_formula_value_update(this.CompanyID, EstimateItemID, stringBuilder.ToString());
                }
            }
        }

        public void Insert_OtherVariableQty(string EstType, long EstimateItemID, long EstOtherCostID, string CalculationType, string DefaultQtyType, decimal FixedQty, string VariableQty, decimal HourlyRate, decimal SetUpTime, decimal UnitRate, decimal Markup, decimal HourlyRunSpeed, decimal Passes, decimal HoursOrQuantity, string Formula, string FormulaTag, DataTable dtSec, int SectionNo, decimal Cost, decimal Cost1, decimal Cost2, decimal Cost3, decimal UnitRate1, decimal UnitRate2, decimal UnitRate3, decimal Markup1, decimal Markup2, decimal Markup3, decimal HoursOrQuantity1, decimal HoursOrQuantity2, decimal HoursOrQuantity3)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string str = string.Empty;
            long num = (long)0;
            long num1 = (long)0;
            string empty1 = string.Empty;
            empty1 = (string.Compare(EstType, "B", true) == 0 || string.Compare(EstType, "N", true) == 0 || string.Compare(EstType, "K", true) == 0 ? EstimatesBasePage.estimates_quantity_select(this.CompanyID, this.EstBookletItemID, EstType) : EstimatesBasePage.estimates_quantity_select(this.CompanyID, EstimateItemID, EstType));
            char[] chrArray = new char[] { '#' };
            string[] strArrays = empty1.Split(chrArray);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str1 = strArrays[i];
                chrArray = new char[] { '$' };
                string[] strArrays1 = str1.Split(chrArray);
                if (Convert.ToInt32((int)strArrays1.Length) > 0)
                {
                    int num2 = Convert.ToInt32(strArrays1[2]);
                    int num3 = Convert.ToInt32(strArrays1[2]);
                    if (CalculationType == "q" || CalculationType == "t")
                    {
                        if (i == 0)
                        {
                            num2 = Convert.ToInt32(HoursOrQuantity);
                        }
                        else if (i == 1)
                        {
                            num2 = (Convert.ToInt32(HoursOrQuantity1) == 0 ? Convert.ToInt32(HoursOrQuantity) : Convert.ToInt32(HoursOrQuantity1));
                        }
                        else if (i == 2)
                        {
                            num2 = (Convert.ToInt32(HoursOrQuantity2) == 0 ? Convert.ToInt32(HoursOrQuantity) : Convert.ToInt32(HoursOrQuantity2));
                        }
                        else if (i == 3)
                        {
                            num2 = (Convert.ToInt32(HoursOrQuantity3) == 0 ? Convert.ToInt32(HoursOrQuantity) : Convert.ToInt32(HoursOrQuantity3));
                        }
                    }
                    if ((int)strArrays1.Length > 0 && Convert.ToInt32(strArrays1[2]) > 0)
                    {
                        num1 = Convert.ToInt64(strArrays1[0].ToString());
                        decimal num4 = new decimal(0);
                        decimal num5 = new decimal(0);
                        decimal num6 = new decimal(0);
                        decimal num7 = new decimal(0);
                        decimal num8 = new decimal(0);
                        bool flag = false;
                        decimal num9 = new decimal(0);
                        decimal num10 = new decimal(0);
                        bool flag1 = false;
                        string empty2 = string.Empty;
                        bool flag2 = false;
                        decimal num11 = new decimal(0);
                        decimal num12 = new decimal(0);
                        decimal num13 = new decimal(0);
                        string str2 = string.Empty;
                        long num14 = (long)0;
                        decimal num15 = new decimal(0);
                        decimal num16 = new decimal(0);
                        decimal num17 = new decimal(0);
                        decimal num18 = new decimal(0);
                        decimal num19 = new decimal(0);
                        if (CalculationType == "t")
                        {
                            num14 = (base.Request.Params["booksecid"] != null ? Convert.ToInt64(base.Request.Params["booksecid"]) : (long)0);
                            DataTable dataTable = EstimatesBasePage.estimate_othercost_press_details_select((long)this.CompanyID, EstimateItemID, EstType, num14);
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (EstType == "S" || EstType == "P" || EstType == "F" || EstType == "D" || EstType == "L")
                                {
                                    flag = (row["PrintLayout"].ToString() == "P" ? true : false);
                                    num9 = Convert.ToDecimal(row["PortraitValue"].ToString());
                                    num10 = Convert.ToDecimal(row["LandscapeValue"].ToString());
                                    num4 = Convert.ToDecimal(row["SetupSpoilage"].ToString());
                                    num5 = Convert.ToDecimal(row["RunningSpoilage"].ToString());
                                    flag1 = Convert.ToBoolean(row["IsIncludeGutters"].ToString());
                                    empty2 = row["Colour"].ToString();
                                    flag2 = Convert.ToBoolean(row["IsDoublesided"].ToString());
                                }
                                if (EstType == "N")
                                {
                                    num16 = Convert.ToDecimal(row["NcrPartsPerSet"].ToString());
                                    num17 = Convert.ToDecimal(row["NcrSetsPerPad"].ToString());
                                    num4 = Convert.ToDecimal(row["SetupSpoilage"].ToString());
                                    num5 = Convert.ToDecimal(row["RunningSpoilage"].ToString());
                                    flag1 = Convert.ToBoolean(row["IsIncludeGutters"].ToString());
                                    empty2 = row["Colour"].ToString();
                                    flag2 = Convert.ToBoolean(row["IsDoublesided"].ToString());
                                }
                                if (EstType == "B" || EstType == "K")
                                {
                                    num11 = Convert.ToDecimal(row["NoOfPagesInSection"].ToString());
                                    num7 = Convert.ToDecimal(row["NoOfSections"].ToString());
                                    num13 = Convert.ToDecimal(row["NoOfSignatures"].ToString());
                                    num15 = Convert.ToDecimal(row["TotalPagesAllSections"].ToString());
                                    num4 = Convert.ToDecimal(row["SetupSpoilage"].ToString());
                                    num5 = Convert.ToDecimal(row["RunningSpoilage"].ToString());
                                    flag1 = Convert.ToBoolean(row["IsIncludeGutters"].ToString());
                                    empty2 = row["Colour"].ToString();
                                    flag2 = Convert.ToBoolean(row["IsDoublesided"].ToString());
                                }
                                if (!(EstType == "P") && !(EstType == "D"))
                                {
                                    continue;
                                }
                                num12 = Convert.ToDecimal(row["LeavesPerPad"].ToString());
                            }
                            if (EstType == "P" || EstType == "D")
                            {
                                num8 = (!flag ? Convert.ToDecimal(num10) : Convert.ToDecimal(num9));
                                decimal num20 = new decimal(0);
                                EstimatesBasePage.PrintSheets_Calculation_For_PadItem(num2, num12, num8, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num20);
                                num6 = Convert.ToDecimal(num2);
                                Convert.ToDecimal(num2 + num20);
                            }
                            else if (EstType == "B")
                            {
                                num8 = (flag ? num9 : num10);
                                decimal num21 = new decimal(0);
                                num6 = Convert.ToDecimal(num2);
                                EstimatesBasePage.Booklet_Print_Sheet_Calculation(num2, Convert.ToInt32(num13), Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num21);
                                decimal num22 = num6 + Convert.ToDecimal(num21);
                            }
                            else if (EstType == "K")
                            {
                                num8 = (flag ? num9 : num10);
                                decimal num23 = new decimal(0);
                                num6 = Convert.ToDecimal(num2);
                                EstimatesBasePage.LithoBooklet_Print_Sheet_Calculation(num2, Convert.ToInt32(num13), Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num23);
                                decimal num24 = num6 + Convert.ToDecimal(num23);
                            }
                            else if (EstType != "N")
                            {
                                num8 = (!flag ? Convert.ToDecimal(num10) : Convert.ToDecimal(num9));
                                decimal num25 = new decimal(0);
                                EstimateBasePage.PrintSheets_Calculation_For_SingleItem(num2, num8, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num25);
                                num6 = Convert.ToDecimal(num2);
                                Convert.ToDecimal(num2 + num25);
                            }
                            else
                            {
                                num8 = (flag ? num9 : num10);
                                decimal num26 = new decimal(0);
                                num6 = Convert.ToDecimal(num2);
                                EstimateBasePage.PrintSheets_Calculation_For_SingleItemForNCR(num2, Convert.ToInt32(num17), Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num26);
                                decimal num27 = num6 + Convert.ToDecimal(num26);
                            }
                            if (EstType == "P" || EstType == "D")
                            {
                                if (num8 != new decimal(0))
                                {
                                    decimal num28 = new decimal(0);
                                    num19 = Convert.ToDecimal(EstimatesBasePage.PrintSheets_Calculation_For_PadItem(num2, num12, num8, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num28));
                                    num18 = num19 - Convert.ToDecimal(num28);
                                }
                            }
                            else if (EstType == "B")
                            {
                                decimal num29 = new decimal(0);
                                num19 = Convert.ToDecimal(EstimatesBasePage.Booklet_Print_Sheet_Calculation(Convert.ToInt32(num2), num13, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num29));
                                num18 = num19 - Convert.ToDecimal(num29);
                            }
                            else if (EstType == "K")
                            {
                                decimal num30 = new decimal(0);
                                num19 = Convert.ToDecimal(EstimatesBasePage.LithoBooklet_Print_Sheet_Calculation(Convert.ToInt32(num2), num13, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num30));
                                num18 = num19 - Convert.ToDecimal(num30);
                            }
                            else if (EstType == "N")
                            {
                                decimal num31 = new decimal(0);
                                num19 = Convert.ToDecimal(EstimateBasePage.PrintSheets_Calculation_For_SingleItemForNCR(Convert.ToInt32(num2), num17, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num31));
                                num18 = num19 - Convert.ToDecimal(num31);
                            }
                            else if (num8 != new decimal(0))
                            {
                                decimal num32 = new decimal(0);
                                num19 = Convert.ToDecimal(EstimateBasePage.PrintSheets_Calculation_For_SingleItem(num2, num8, Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num32));
                                num18 = num19 - Convert.ToDecimal(num32);
                            }
                        }
                        decimal hoursOrQuantity = new decimal(0);
                        decimal unitRate = new decimal(0);
                        if (CalculationType == "q")
                        {
                            if (DefaultQtyType != "f")
                            {
                                if (DefaultQtyType == "v")
                                {
                                    if (VariableQty == "1")
                                    {
                                        hoursOrQuantity = Math.Round(Convert.ToDecimal(num2));
                                    }
                                    if (VariableQty == "2")
                                    {
                                        hoursOrQuantity = Math.Round(Convert.ToDecimal(num2));
                                    }
                                    if (VariableQty == "3")
                                    {
                                        hoursOrQuantity = Math.Round(Convert.ToDecimal(num2));
                                    }
                                    if (VariableQty == "4")
                                    {
                                        hoursOrQuantity = Math.Round(Convert.ToDecimal(num2));
                                    }
                                }
                            }
                            else if (i == 0)
                            {
                                hoursOrQuantity = HoursOrQuantity;
                            }
                            else if (i == 1)
                            {
                                hoursOrQuantity = (HoursOrQuantity1 == new decimal(0) ? HoursOrQuantity : HoursOrQuantity1);
                            }
                            else if (i == 2)
                            {
                                hoursOrQuantity = (HoursOrQuantity2 == new decimal(0) ? HoursOrQuantity : HoursOrQuantity2);
                            }
                            else if (i == 3)
                            {
                                hoursOrQuantity = (HoursOrQuantity3 == new decimal(0) ? HoursOrQuantity : HoursOrQuantity3);
                            }
                            decimal hourlyRate = new decimal(0);
                            decimal markup = new decimal(0);
                            if (i == 0)
                            {
                                hourlyRate = (HourlyRate * SetUpTime) / new decimal(60);
                                unitRate = (UnitRate * hoursOrQuantity) + hourlyRate;
                                markup = (unitRate * Markup) / new decimal(100);
                            }
                            else if (i == 1)
                            {
                                hourlyRate = (HourlyRate * SetUpTime) / new decimal(60);
                                unitRate = (UnitRate1 * hoursOrQuantity) + hourlyRate;
                                markup = (unitRate * Markup1) / new decimal(100);
                            }
                            else if (i == 2)
                            {
                                hourlyRate = (HourlyRate * SetUpTime) / new decimal(60);
                                unitRate = (UnitRate2 * hoursOrQuantity) + hourlyRate;
                                markup = (unitRate * Markup2) / new decimal(100);
                            }
                            else if (i == 3)
                            {
                                hourlyRate = (HourlyRate * SetUpTime) / new decimal(60);
                                unitRate = (UnitRate3 * hoursOrQuantity) + hourlyRate;
                                markup = (unitRate * Markup3) / new decimal(100);
                            }
                        }
                        else if (CalculationType == "t")
                        {
                            if (DefaultQtyType == "f")
                            {
                                hoursOrQuantity = HoursOrQuantity;
                            }
                            else if (DefaultQtyType == "v")
                            {
                                hoursOrQuantity = HoursOrQuantity;
                            }
                            decimal hourlyRate1 = (HourlyRate * SetUpTime) / new decimal(60);
                            decimal hourlyRate2 = HourlyRate * hoursOrQuantity;
                            unitRate = hourlyRate2 * Passes;
                            decimal markup1 = (hourlyRate2 * Markup) / new decimal(100);
                        }
                        else if (CalculationType == "f" || CalculationType == "m")
                        {
                            decimal num33 = new decimal(0);
                            DataTable dataTable1 = this.objInv.warehouse_inventoryproperties_select(this.CompanyID, Convert.ToInt64(this.hdnpaperID.Value));
                            foreach (DataRow dataRow in dataTable1.Rows)
                            {
                                num33 = Convert.ToDecimal(dataRow["BasisWeight"].ToString());
                            }
                            decimal num34 = new decimal(0);
                            decimal num35 = new decimal(0);
                            DataTable dataTable2 = SettingsBasePage.Settings_Guillotine_Select_By_ID(this.CompanyID, Convert.ToInt64(this.hid_GuillotineID.Value));
                            foreach (DataRow row1 in dataTable2.Rows)
                            {
                                num35 = Convert.ToDecimal(row1["CostPerCut"].ToString());
                                decimal num36 = Convert.ToDecimal(row1["PaperWeight1"].ToString());
                                decimal num37 = Convert.ToDecimal(row1["PaperWeight2"].ToString());
                                decimal num38 = Convert.ToDecimal(row1["PaperWeight3"].ToString());
                                decimal num39 = Convert.ToDecimal(row1["MaxSheets1"].ToString());
                                decimal num40 = Convert.ToDecimal(row1["MaxSheets2"].ToString());
                                decimal num41 = Convert.ToDecimal(row1["MaxSheets3"].ToString());
                                if (num33 <= num36)
                                {
                                    num34 = num39;
                                }
                                else if (num33 > num37)
                                {
                                    if (!(num33 <= num38) && !(num33 > num38))
                                    {
                                        continue;
                                    }
                                    num34 = num41;
                                }
                                else
                                {
                                    num34 = num40;
                                }
                            }
                            decimal num42 = num19;
                            int num43 = 0;
                            string[] strArrays2 = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
                            string[] strArrays3 = strArrays2;
                            for (int j = 0; j < (int)strArrays3.Length; j++)
                            {
                                if (num8 == Convert.ToDecimal(strArrays3[j].ToString()))
                                {
                                    num43 = Convert.ToInt32(strArrays3[j].ToString());
                                }
                            }
                            decimal num44 = Math.Ceiling(num19 / num8);
                            decimal num45 = new decimal(0);
                            if (num34 > new decimal(0))
                            {
                                num45 = Math.Ceiling(num44 / num34);
                            }
                            decimal num46 = num43 * num45;
                            if (num46 == new decimal(0))
                            {
                                num45 = new decimal(0);
                            }
                            decimal num47 = new decimal(0);
                            if (num34 != new decimal(0))
                            {
                                num47 = Math.Ceiling(num42 / num34);
                            }
                            if (num47 == new decimal(0))
                            {
                                num47 = new decimal(1);
                            }
                            string str3 = (flag1 ? "yes" : "no");
                            decimal num48 = EstimateBasePage.Estimate_Summary_Guillotine_Standard_Table(this.CompanyID, Convert.ToInt32(num8), str3);
                            decimal num49 = num48 * num47;
                            string lower = string.Empty;
                            long num50 = (long)0;
                            decimal num51 = new decimal(0);
                            decimal num52 = new decimal(0);
                            decimal num53 = new decimal(0);
                            decimal num54 = new decimal(0);
                            decimal num55 = new decimal(0);
                            decimal num56 = new decimal(0);
                            decimal num57 = new decimal(0);
                            decimal num58 = new decimal(0);
                            foreach (DataRow dataRow1 in SettingsBasePage.Settings_DigitalPress_Select_By_ID(this.CompanyID, this.PressID).Rows)
                            {
                                lower = dataRow1["MethodName"].ToString().Trim().ToLower();
                                num50 = (long)Convert.ToInt32(dataRow1["MethodID"].ToString());
                                num51 = Convert.ToDecimal(dataRow1["SetupCharge"]);
                                num52 = Convert.ToDecimal(dataRow1["MinCharge"]);
                                num53 = Convert.ToDecimal(dataRow1["MarkUp"]);
                            }
                            if (lower == "clickchargelookup")
                            {
                                foreach (DataRow row2 in SettingsBasePage.Settings_ClickChargeLookup_Select_By_ID(this.CompanyID, num50).Rows)
                                {
                                    num55 = Convert.ToDecimal(row2["BlackChargeableSheets"]);
                                    num56 = Convert.ToDecimal(row2["ColorChargeableSheets"]);
                                    num57 = Convert.ToDecimal(row2["ChargeableSheets"]);
                                }
                                num58 = this.PressCostPerClick(num19, (empty2 == "color" ? num56 : num55), num57);
                                num58 = this.ReturnExact2Decimal(num58);
                                num58 = num58;
                                num58 = this.ReturnExact2Decimal(num58);
                            }
                            else if (lower == "speedweightlookup")
                            {
                                decimal num59 = new decimal(0);
                                decimal num60 = new decimal(0);
                                decimal num61 = new decimal(0);
                                decimal num62 = new decimal(0);
                                decimal num63 = new decimal(0);
                                decimal num64 = new decimal(0);
                                decimal num65 = new decimal(0);
                                decimal num66 = new decimal(0);
                                decimal num67 = new decimal(0);
                                decimal num68 = new decimal(0);
                                decimal num69 = new decimal(0);
                                decimal num70 = new decimal(0);
                                decimal num71 = new decimal(0);
                                foreach (DataRow dataRow2 in SettingsBasePage.Settings_SpeedWeightLookup_Select_By_ID(this.CompanyID, num50).Rows)
                                {
                                    num59 = Convert.ToDecimal(dataRow2["HourlyCharge"]);
                                    num60 = Convert.ToDecimal(dataRow2["BlackGSM1"]);
                                    num61 = Convert.ToDecimal(dataRow2["BlackPagesPerMinute1"]);
                                    num62 = Convert.ToDecimal(dataRow2["BlackGSM2"]);
                                    num63 = Convert.ToDecimal(dataRow2["BlackPagesPerMinute2"]);
                                    num64 = Convert.ToDecimal(dataRow2["BlackGSM3"]);
                                    num65 = Convert.ToDecimal(dataRow2["BlackPagesPerMinute3"]);
                                    num66 = Convert.ToDecimal(dataRow2["ColorGSM1"]);
                                    num67 = Convert.ToDecimal(dataRow2["ColorPagesPerMinute1"]);
                                    num68 = Convert.ToDecimal(dataRow2["ColorGSM2"]);
                                    num69 = Convert.ToDecimal(dataRow2["ColorPagesPerMinute2"]);
                                    num70 = Convert.ToDecimal(dataRow2["ColorGSM3"]);
                                    num71 = Convert.ToDecimal(dataRow2["ColorPagesPerMinute3"]);
                                }
                                if (empty2 != "color")
                                {
                                    decimal num72 = new decimal(0);
                                    if (num33 <= num60)
                                    {
                                        num72 = num61;
                                    }
                                    else if (num33 > num60 && num33 <= num62)
                                    {
                                        decimal num73 = (num60 + num62) / new decimal(2);
                                        num72 = Convert.ToDecimal((num61 + num63) / new decimal(2));
                                    }
                                    else if (num33 > num62 && num33 <= num64)
                                    {
                                        decimal num74 = (num62 + num64) / new decimal(2);
                                        num72 = Convert.ToDecimal((num63 + num65) / new decimal(2));
                                    }
                                    else if (num33 > num64)
                                    {
                                        num72 = num65;
                                    }
                                    decimal num75 = Convert.ToDecimal(num19);
                                    decimal num76 = new decimal(0);
                                    if (num72 != new decimal(0))
                                    {
                                        num76 = num75 / num72;
                                    }
                                    num76 = Convert.ToDecimal(Math.Round(num76, 2));
                                    num58 = Convert.ToDecimal((num76 * num59) / new decimal(60));
                                    num58 = num58;
                                }
                                else
                                {
                                    decimal num77 = new decimal(0);
                                    if (num33 <= num66)
                                    {
                                        num77 = num67;
                                    }
                                    else if (num33 > num66 && num33 <= num68)
                                    {
                                        decimal num78 = (num66 + num68) / new decimal(2);
                                        num77 = Convert.ToDecimal((num67 + num69) / new decimal(2));
                                    }
                                    else if (num33 > num68 && num33 <= num70)
                                    {
                                        decimal num79 = (num68 + num70) / new decimal(2);
                                        num77 = Convert.ToDecimal((num69 + num71) / new decimal(2));
                                    }
                                    else if (num33 > num70)
                                    {
                                        num77 = num71;
                                    }
                                    decimal num80 = Convert.ToDecimal(num19);
                                    decimal num81 = new decimal(0);
                                    if (num77 != new decimal(0))
                                    {
                                        num81 = num80 / num77;
                                    }
                                    num81 = Convert.ToDecimal(Math.Round(num81, 2));
                                    num58 = Convert.ToDecimal((num81 * num59) / new decimal(60));
                                    num58 = num58;
                                }
                            }
                            else if (lower == "clickchargezonelookup")
                            {
                                decimal num82 = new decimal(0);
                                decimal num83 = Convert.ToInt32(num19);
                                foreach (DataRow row3 in SettingsBasePage.Settings_ClickChargeZoneLookup_Select_By_ID(this.CompanyID, this.PressID).Rows)
                                {
                                    decimal num84 = Convert.ToDecimal(row3["ZoneFrom"].ToString());
                                    decimal num85 = Convert.ToDecimal(row3["ZoneTo"].ToString());
                                    decimal num86 = Convert.ToDecimal(row3["ChargeableRate"].ToString());
                                    decimal num87 = Convert.ToDecimal(row3["ChargeableSheets"].ToString());
                                    decimal num88 = num85 - num84;
                                    decimal num89 = new decimal(0);
                                    if (num88 <= new decimal(0))
                                    {
                                        if (num83 <= new decimal(0))
                                        {
                                            continue;
                                        }
                                        num89 = this.PressCostPerClick(num83, Convert.ToDecimal(num86), Convert.ToDecimal(num87));
                                        num82 = num82 + num89;
                                    }
                                    else
                                    {
                                        decimal num90 = num83;
                                        num83 = num83 - num88;
                                        if (num83 <= new decimal(0))
                                        {
                                            num89 = this.PressCostPerClick(num90, Convert.ToDecimal(num86), Convert.ToDecimal(num87));
                                            num82 = num82 + num89;
                                            break;
                                        }
                                        else
                                        {
                                            num89 = this.PressCostPerClick(num88, Convert.ToDecimal(num86), Convert.ToDecimal(num87));
                                            num82 = num82 + num89;
                                        }
                                    }
                                }
                                num58 = num82;
                                num58 = num58;
                            }
                            num58 = this.ReturnExact2Decimal(num58);
                            if (flag2)
                            {
                                num58 = num58 * new decimal(2);
                            }
                            decimal num91 = (num58 * num53) / new decimal(100);
                            num91 = this.ReturnExact2Decimal(num91);
                            decimal num92 = this.objJava.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num58, num91, num52, out this.CostexMarkup_forsummary, out this.MinimumCostMarkup, ref num51);
                            num92 = this.ReturnExact2Decimal(num92);
                            string empty3 = string.Empty;
                            string empty4 = string.Empty;
                            if (FormulaTag != "")
                            {
                                chrArray = new char[] { '\u00B6' };
                                empty4 = FormulaTag.Split(chrArray)[1].ToString();
                            }
                            foreach (DataRow dataRow3 in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                            {
                                empty3 = dataRow3["Key"].ToString();
                                if (empty3.ToLower() == "booklet quantity required(section 1)")
                                {
                                    num6 = (num6 == new decimal(0) ? new decimal(0) : num6);
                                    empty4 = empty4.Replace(empty3, num6.ToString());
                                }
                                else if (empty3.ToLower() == "pages in this section only")
                                {
                                    empty4 = empty4.Replace(empty3, num11.ToString());
                                }
                                else if (empty3.ToLower() == "number of sections")
                                {
                                    num7 = (num7 == new decimal(0) ? new decimal(0) : num7);
                                    empty4 = empty4.Replace(empty3, num7.ToString());
                                }
                                else if (empty3.ToLower() == "total number of pages (all sections)")
                                {
                                    num15 = (num15 == new decimal(0) ? new decimal(0) : num15);
                                    empty4 = empty4.Replace(empty3, num15.ToString());
                                }
                                else if (empty3.ToLower() == "print sheet quantity this section (excluding spoilage)")
                                {
                                    if (string.Compare(EstType, "B", true) != 0)
                                    {
                                        continue;
                                    }
                                    decimal num93 = new decimal(0);
                                    string value = this.hid_booklet_save.Value;
                                    chrArray = new char[] { 'µ' };
                                    string[] strArrays4 = value.Split(chrArray);
                                    for (int k = 0; k < (int)strArrays4.Length; k++)
                                    {
                                        if (SectionNo == k)
                                        {
                                            string str4 = strArrays4[k];
                                            chrArray = new char[] { '±' };
                                            string[] strArrays5 = str4.Split(chrArray);
                                            decimal num94 = new decimal(0);
                                            for (int l = 0; l < (int)strArrays5.Length; l++)
                                            {
                                                string str5 = strArrays5[l];
                                                chrArray = new char[] { '»' };
                                                string[] strArrays6 = str5.Split(chrArray);
                                                if (strArrays6[0].Trim() == "NoOfSignatures" && !string.IsNullOrEmpty(strArrays6[1]))
                                                {
                                                    num94 = Convert.ToInt32(num2) * Convert.ToInt32(strArrays6[1].Trim());
                                                }
                                            }
                                            num93 = num94;
                                        }
                                    }
                                    empty4 = empty4.Replace(empty3, num93.ToString());
                                }
                                else if (empty3.ToLower() == "print sheet quantity this section (including spoilage)")
                                {
                                    decimal num95 = new decimal(0);
                                    string value1 = this.hid_booklet_save.Value;
                                    chrArray = new char[] { 'µ' };
                                    string[] strArrays7 = value1.Split(chrArray);
                                    for (int m = 0; m < (int)strArrays7.Length; m++)
                                    {
                                        if (SectionNo == m)
                                        {
                                            string str6 = strArrays7[m];
                                            chrArray = new char[] { '±' };
                                            string[] strArrays8 = str6.Split(chrArray);
                                            decimal num96 = new decimal(0);
                                            decimal num97 = new decimal(0);
                                            decimal num98 = new decimal(0);
                                            for (int n = 0; n < (int)strArrays8.Length; n++)
                                            {
                                                string str7 = strArrays8[n];
                                                chrArray = new char[] { '»' };
                                                string[] strArrays9 = str7.Split(chrArray);
                                                if (strArrays9[0].Trim() == "NoOfSignatures" && !string.IsNullOrEmpty(strArrays9[1]))
                                                {
                                                    num96 = Convert.ToInt32(num2) * Convert.ToInt32(strArrays9[1].Trim());
                                                }
                                                else if (strArrays9[0].Trim() == "SetupSpoilage")
                                                {
                                                    num97 = Convert.ToDecimal(strArrays9[1].Trim());
                                                }
                                                else if (strArrays9[0].Trim() == "RunningSpoilage")
                                                {
                                                    num98 = Convert.ToDecimal(strArrays9[1].Trim());
                                                }
                                            }
                                            num98 = (num96 * num98) / new decimal(100);
                                            num96 = (num96 + num98) + num97;
                                            num95 = num95 + num96;
                                        }
                                    }
                                    empty4 = empty4.Replace(empty3, num95.ToString());
                                }
                                else if (empty3.ToLower() == "print sheet quantity all sections (excluding spoilage)")
                                {
                                    int num99 = 0;
                                    string value2 = this.hid_booklet_save.Value;
                                    chrArray = new char[] { 'µ' };
                                    string[] strArrays10 = value2.Split(chrArray);
                                    for (int o = 0; o < (int)strArrays10.Length; o++)
                                    {
                                        string str8 = strArrays10[o];
                                        chrArray = new char[] { '±' };
                                        string[] strArrays11 = str8.Split(chrArray);
                                        for (int p = 0; p < (int)strArrays11.Length; p++)
                                        {
                                            string str9 = strArrays11[p];
                                            chrArray = new char[] { '»' };
                                            string[] strArrays12 = str9.Split(chrArray);
                                            if (strArrays12[0].Trim() == "NoOfSignatures" && !string.IsNullOrEmpty(strArrays12[1]))
                                            {
                                                num99 = num99 + Convert.ToInt32(num2) * Convert.ToInt32(strArrays12[1].Trim());
                                            }
                                        }
                                    }
                                    empty4 = empty4.Replace(empty3, num99.ToString());
                                }
                                else if (empty3.ToLower() == "print sheet quantity all sections (including spoilage)")
                                {
                                    decimal num100 = new decimal(0);
                                    string value3 = this.hid_booklet_save.Value;
                                    chrArray = new char[] { 'µ' };
                                    string[] strArrays13 = value3.Split(chrArray);
                                    for (int q = 0; q < (int)strArrays13.Length; q++)
                                    {
                                        string str10 = strArrays13[q];
                                        chrArray = new char[] { '±' };
                                        string[] strArrays14 = str10.Split(chrArray);
                                        decimal num101 = new decimal(0);
                                        decimal num102 = new decimal(0);
                                        decimal num103 = new decimal(0);
                                        for (int r = 0; r < (int)strArrays14.Length; r++)
                                        {
                                            string str11 = strArrays14[r];
                                            chrArray = new char[] { '»' };
                                            string[] strArrays15 = str11.Split(chrArray);
                                            if (strArrays15[0].Trim() == "NoOfSignatures" && !string.IsNullOrEmpty(strArrays15[1]))
                                            {
                                                num101 = Convert.ToInt32(num2) * Convert.ToInt32(strArrays15[1].Trim());
                                            }
                                            else if (strArrays15[0].Trim() == "SetupSpoilage")
                                            {
                                                num102 = Convert.ToDecimal(strArrays15[1].Trim());
                                            }
                                            else if (strArrays15[0].Trim() == "RunningSpoilage")
                                            {
                                                num103 = Convert.ToDecimal(strArrays15[1].Trim());
                                            }
                                        }
                                        num103 = (num101 * num103) / new decimal(100);
                                        num101 = (num101 + num103) + num102;
                                        num100 = num100 + num101;
                                    }
                                    empty4 = empty4.Replace(empty3, num100.ToString());
                                }
                                else if (empty3.ToLower() == "guillotine bundles")
                                {
                                    empty4 = empty4.Replace(empty3, num47.ToString());
                                }
                                else if (empty3.ToLower() == "guillotine cost per cut")
                                {
                                    empty4 = empty4.Replace(empty3, num35.ToString());
                                }
                                else if (empty3.ToLower() == "number of cuts in first trim")
                                {
                                    num46 = (num46 == new decimal(0) ? new decimal(0) : num46);
                                    empty4 = empty4.Replace(empty3, num46.ToString());
                                }
                                else if (empty3.ToLower() == "number of cuts in second trim")
                                {
                                    num49 = (num49 == new decimal(0) ? new decimal(0) : num49);
                                    empty4 = empty4.Replace(empty3, num49.ToString());
                                }
                                else if (empty3.ToLower() == "number of leaves per pad")
                                {
                                    empty4 = empty4.Replace(empty3, num12.ToString());
                                }
                                else if (empty3.ToLower() == "number of pads")
                                {
                                    num6 = (num6 == new decimal(0) ? new decimal(0) : num6);
                                    empty4 = empty4.Replace(empty3, num6.ToString());
                                }
                                else if (empty3.ToLower() == "press hourly charge")
                                {
                                    num54 = (num54 == new decimal(0) ? new decimal(0) : num54);
                                    empty4 = empty4.Replace(empty3, num54.ToString());
                                }
                                else if (empty3.ToLower() == "total press cost price")
                                {
                                    num58 = (num58 == new decimal(0) ? new decimal(0) : num58);
                                    empty4 = empty4.Replace(empty3, num58.ToString());
                                }
                                else if (empty3.ToLower() == "total press selling price")
                                {
                                    num92 = (num92 == new decimal(0) ? new decimal(0) : num92);
                                    empty4 = empty4.Replace(empty3, num92.ToString());
                                }
                                else if (empty3.ToLower() == "print sheet quantity (excluding spoilage)")
                                {
                                    num18 = (num18 == new decimal(0) ? new decimal(0) : num18);
                                    empty4 = empty4.Replace(empty3, num18.ToString());
                                }
                                else if (empty3.ToLower() == "print sheet quantity (including spoilage)")
                                {
                                    num19 = (num19 == new decimal(0) ? new decimal(0) : num19);
                                    empty4 = empty4.Replace(empty3, num19.ToString());
                                }
                                else if (empty3.ToLower() == "finished job quantity")
                                {
                                    num6 = (num6 == new decimal(0) ? new decimal(0) : num6);
                                    empty4 = empty4.Replace(empty3, num6.ToString());
                                }
                                else if (empty3.ToLower() != "parts per set")
                                {
                                    if (empty3.ToLower() != "sets per pad")
                                    {
                                        continue;
                                    }
                                    empty4 = empty4.Replace(empty3, num17.ToString());
                                }
                                else
                                {
                                    empty4 = empty4.Replace(empty3, num16.ToString());
                                }
                            }
                            string str12 = empty4;
                            empty = empty4;
                            stringBuilder.Append(string.Concat(empty4, "±"));
                            decimal num104 = (new MathParser()).Calculate(str12);
                            unitRate = Convert.ToDecimal(num104.ToString());
                        }
                        if (i == 0)
                        {
                            this.Call_Delete_Other_Variable();
                        }
                        decimal cost = new decimal(0);
                        if (i == 0)
                        {
                            cost = Cost;
                        }
                        else if (i == 1)
                        {
                            cost = Cost1;
                        }
                        else if (i == 2)
                        {
                            cost = Cost2;
                        }
                        else if (i == 3)
                        {
                            cost = Cost3;
                        }
                        if (CalculationType == "t" && DefaultQtyType == "f")
                        {
                            cost = Cost;
                        }
                        if (CalculationType == "q")
                        {
                            cost = unitRate;
                        }
                        EstimatesBasePage.estimate_othercost_variableqty_insert(this.CompanyID, num, EstOtherCostID, num1, hoursOrQuantity, cost, EstType, empty, num3, i, "");
                    }
                    else if (i == 0)
                    {
                        this.Call_Delete_Other_Variable();
                    }
                    if ((int)strArrays1.Length > 0 && Convert.ToInt32(strArrays1[2]) > 0)
                    {
                        EstimateBasePage.othercost_formula_value_update(this.CompanyID, EstimateItemID, stringBuilder.ToString());
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "job";
            global.pgName = "";
            this.gloobj.setpagename("job");
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
            }
            if (base.Request.QueryString["EstID"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["EstID"].ToString());
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
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.isfrom_eStore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs").ToLower();
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.tabtype = "job";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.tabtype = "estimate";
            }
            else
            {
                this.tabtype = "invoice";
            }
            if (base.Request.QueryString["estitemid"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["estitemid"].ToString());
            }
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                this.Div_ItemDescn.Visible = false;
                if (base.Request.Params["subitem"] != null)
                {
                    this.Div_ItemDescn.Visible = false;
                }
                if (base.Request.QueryString["esttype"] != null)
                {
                    this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
                }
            }
            try
            {
                if (base.Request.Params["parentestitemid"] != null)
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                if (!base.IsPostBack)
                {
                    string item = base.Request.QueryString["isFromOtherCostSeq"];
                }
                if (base.Request.Params["parentesttype"] != null)
                {
                    this.ParentEstimateType = base.Request.Params["parentesttype"].ToString();
                    this.btncostSkip.Visible = true;
                }
                if (base.Request.Params["frm"] != null)
                {
                    this.FromSummary = base.Request.Params["frm"].ToString();
                }
            }
            catch
            {
                this.ParentEstimateItemID = (long)0;
            }
            if (base.Request.QueryString["frm"] != null)
            {
                this.btncostSkip.Visible = false;
                this.Div_Options.Style.Add("width", "31%");
                this.IsOtherCostSequence = false;
            }
            if (base.Request.Params["type"] != null)
            {
                if (string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
                {
                    this.req_type = "add";
                    string empty = string.Empty;
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                        {
                            if (this.isfrom_eStore != "yes")
                            {
                                object[] estimateID = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                                empty = string.Concat(estimateID);
                                string[] languageConversion = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                                base.Navigation_Path(string.Concat(languageConversion), "&nbsp;Job Add: Other cost");
                            }
                            else
                            {
                                object[] objArray = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                                empty = string.Concat(objArray);
                                string[] strArrays = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                                base.Navigation_Path(string.Concat(strArrays), "&nbsp;Job Add: Other cost");
                            }
                        }
                    }
                    else if (base.Request.Params["maintype"] != "edit")
                    {
                        string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_view"), "</a> &nbsp;>&nbsp;" };
                        base.Navigation_Path(string.Concat(languageConversion1), "Job Add: Other cost");
                    }
                    else
                    {
                        object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                        empty = string.Concat(estimateID1);
                        string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(strArrays1), "&nbsp;Job Add: Other cost");
                    }
                    base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else if (string.Compare(base.Request.Params["type"].ToString(), "more", true) == 0)
                {
                    this.req_type = "more";
                }
                else if (string.Compare(base.Request.Params["type"].ToString(), "edit", true) == 0)
                {
                    foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                    {
                        this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                        this.IsProductCreated = Convert.ToInt16(row["IsProductCreated"].ToString());
                    }
                    if (this.IsProductCreated == 1)
                    {
                        this.Div_Productcatalogue.Visible = true;
                    }
                    this.req_type = "edit";
                    string str = string.Empty;
                    if (this.FromSummary == "sum")
                    {
                        if (this.isfrom_eStore != "yes")
                        {
                            object[] objArray1 = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "&nbsp;></a>" };
                            str = string.Concat(objArray1);
                        }
                        else
                        {
                            object[] estimateID2 = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "&nbsp;></a>" };
                            str = string.Concat(estimateID2);
                        }
                    }
                    if (this.IsItemCompleted != 1)
                    {
                        base.Navigation_Path(string.Concat("<a href=../jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Othercost")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    }
                    else
                    {
                        string[] languageConversion2 = new string[] { "<a href=", this.strSitepath, "jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", str };
                        base.Navigation_Path(string.Concat(languageConversion2), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Edit_Othercost")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Job Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    }
                }
            }
            if (base.Request.QueryString["frmcopyitem"] != null)
            {
                this.frmcopyitem = base.Request.QueryString["frmcopyitem"].ToString();
            }
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
            }
        }

        private decimal PressCostPerClick(decimal PrintSheets, decimal ChargeableRate, decimal ChargeableSheets)
        {
            decimal num = new decimal(0);
            num = ChargeableRate / Convert.ToDecimal(ChargeableSheets);
            return num * PrintSheets;
        }

        public void Question_Find_In_Formula(string strFormula, string formulaValue, ref ArrayList AL11, ref ArrayList AL22)
        {
            try
            {
                strFormula = strFormula.Replace("(", "").Replace(")", "");
                strFormula = strFormula.Replace("-", "µ").Replace("/", "µ");
                strFormula = strFormula.Replace("*", "µ").Replace("%", "µ");
                strFormula = strFormula.Replace("^", "µ").Replace("+", "µ");
                string[] strArrays = strFormula.Split(new char[] { 'µ' });
                formulaValue = formulaValue.Replace("(", "").Replace(")", "");
                formulaValue = formulaValue.Replace("-", "µ").Replace("/", "µ");
                formulaValue = formulaValue.Replace("*", "µ").Replace("%", "µ");
                formulaValue = formulaValue.Replace("^", "µ").Replace("+", "µ");
                string[] strArrays1 = formulaValue.Split(new char[] { 'µ' });
                int num = 0;
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].Contains("Q::"))
                    {
                        AL11.Insert(num, strArrays[i]);
                        AL22.Insert(num, strArrays1[i]);
                    }
                    if (strArrays[i].Contains("Matrix"))
                    {
                        AL11.Insert(num, strArrays[i]);
                        AL22.Insert(num, strArrays1[i]);
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }

        [WebMethod]
        public static void RemoveOtherCostItem(string CompID, string EstOtherCostID)
        {
            EstimateBasePage.Estimate_Summary_OtherCost_Remove(Convert.ToInt32(CompID), Convert.ToInt64(EstOtherCostID));
            EstimateBasePage.estimate_othercost_variableqty_delete(Convert.ToInt32(CompID), Convert.ToInt64(EstOtherCostID));
            HttpContext.Current.Session["OtherCostProfit"] = null;
            HttpContext.Current.Session["OtherCostTax"] = null;
            HttpContext.Current.Session["OtherCostTaxID"] = null;
            DataTable dataTable = EstimatesBasePage.estimate_othercost_ProfitTax_select(Convert.ToInt64(HttpContext.Current.Request.QueryString["EstItemID"]), Convert.ToInt64(EstOtherCostID));
            foreach (DataRow row in dataTable.Rows)
            {
                HttpContext.Current.Session["OtherCostProfit"] = row["ProfitMargin"].ToString();
                HttpContext.Current.Session["OtherCostTax"] = row["Tax"].ToString();
                HttpContext.Current.Session["OtherCostTaxID"] = row["TaxID"].ToString();
            }
        }

        public decimal ReturnExact2Decimal(decimal Amount)
        {
            return Amount;
        }
    }
}