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
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Globalization;


namespace ePrint.usercontrol.Item
{
    public partial class item_progress_to_job_from_order_view : UsercontrolBasePage
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private BaseClass objBC = new BaseClass();

        public commonClass commclass = new commonClass();

        private CompanyBasePage objCom = new CompanyBasePage();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private SummaryClass SummaryClassObj = new SummaryClass();

        private commonClass objComn = new commonClass();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long JobID;

        public string Module = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public string MainType = string.Empty;

        public bool Check_SpecialPrivilege;

        public string estimateconvertedtojob = string.Empty;

        public string customerstatustitle = string.Empty;

        private string isdirectjob = string.Empty;

        public string CompanyType = string.Empty;

        public string Ordernumbervalidtiononlyforcoralcoastsystem = string.Empty;

        public string DateFormat = string.Empty;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public int ISInventoryReduced;

        private Hashtable htInventory = new Hashtable();

        public string UserName = string.Empty;

        public string PONO = string.Empty;

        private string Jobconvertedate = string.Empty;

        private string strcreateddate = string.Empty;

        private DateTime TodayDate;

        private DateTime JobConDate;

        public long DeliveryID;

        public long DeliveryItemID;

        public int CustomerID;

        public int AttentionID;

        public string ShippedTo = string.Empty;

        public long DeliveryAddID;

        public string DelAddType = string.Empty;

        public string Footer = string.Empty;

        public long DelNO;

        public DateTime DeliveyDate = DateTime.Now;

        public DateTime ActualDeliveryDate = DateTime.Now;

        public string RefNo = string.Empty;

        public string OrderNo = string.Empty;

        public string newdate = string.Empty;

        public string StrDelNum = string.Empty;

        private long Estimateitemid_directjob;

        public static bool IsJobCopied;

        public static long NewEstID;

        public static bool IsItemCopied;

        public string Pgtype = "estimate";

        public string activityhist = string.Empty;

        public string IsProformaInvoice = string.Empty;

        public string Item_EstimateType = string.Empty;

        public long DeliveryCostCentreID;

        public bool IsDefaultPO;

        public bool chkRaisePOBasedOnEstiItemIDCommon;

        public bool PoOCRaised;

        public string DeliveryNotePrefix = string.Empty;

        public string IsStockMgmtEnabled = string.Empty;

        public string divEstItemsList_Style = string.Empty;

        public string divdates_Style = string.Empty;

        public string divIsArchive_Style = string.Empty;

        public int RemainingItemCnt;

        public string Event = string.Empty;

        public string Progress_Job = string.Empty;

        public string divIsArchivePrompt_style = string.Empty;

        public string divProgressToJob_style = string.Empty;

        public string IsArchive = string.Empty;

        public string IsFromProgreesTojob = string.Empty;

        private string PrevStrJobNum = string.Empty;

        public long OldPurchaseID;

        public int AccountingID;

        public string PaymentType = string.Empty;

        public long ordid;

        public string suppliername1 = string.Empty;

        public string suppliername2 = string.Empty;

        public string suppliername3 = string.Empty;

        public string suppliername4 = string.Empty;

        public string get_all_estimatetypes = string.Empty;

        public string get_estimateitemqty_count = "";

        public string get_estimateitemqty_count_multipleitems = "";

        public string get_all_estimateitemid = "";

        public int l;

        public int subitem_count_O;

        public int subitem_count_C;

        public int subitem_count_W;

        private string subitem_suppliername_O;

        private string subitem_suppliername_C;

        private string subitem_suppliername_W;

        private DateTime CreatedDate;

        public string getqtynumberwithitemids = string.Empty;

        public string get_remainingitemshdn = string.Empty;

        public long poNum = 0;

        public string isCombine = "no";

        public string customDatetitle1 = string.Empty;
        public string customDatetitle2 = string.Empty;
        public string customDatetitle3 = string.Empty;
        public string customDatetitle4 = string.Empty;
        public string customDatetitle5 = string.Empty;

        public string DefaultCustomDate1;
        public string DefaultCustomDate2;
        public string DefaultCustomDate3;
        public string DefaultCustomDate4;
        public string DefaultCustomDate5;

        private DateTime? CustomDate1;
        private DateTime? CustomDate2;
        private DateTime? CustomDate3;
        private DateTime? CustomDate4;
        private DateTime? CustomDate5;
        public int WorkingDaysFrom;

        public int WorkingDaysTo;

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

        static item_progress_to_job_from_order_view()
        {
        }

        public item_progress_to_job_from_order_view()
        {
        }

        private void Adjust_Inventory_On_Job_Complete(DataSet ds, string StrJobNum, int StatusID, long EstID, Hashtable htInventory, long EstimteItemID, string Jobstatus)
        {
            SummaryClass.SubItem_Inventory_Update(ds, StrJobNum, StatusID, EstID, this.UserID, this.CompanyID, Jobstatus, htInventory, EstimteItemID);
        }

        public void AttachmentUpdate_PO_DN(long EstimateID, long EstimateItemID, long TypeID, string Attachmenttype)
        {
            EstimateBasePage.Attachments_PO_DN_Copy(EstimateID, EstimateItemID, TypeID, Attachmenttype);
        }

        public void BindSubItems(DataSet ds, PlaceHolder plhRaiseJobPo, bool defaultcheck)
        {
            foreach (DataRow row in ds.Tables[1].Rows)
            {
                if (string.Compare(row["PoType"].ToString(), "Warehouse", true) != 0 || string.Compare(row["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                CheckBox checkBox = new CheckBox()
                {
                    ID = string.Concat("chkRaisePO_", row["estimateitemid"].ToString()),
                    Checked = defaultcheck,
                    Text = this.objBC.SpecialDecode(row["ItemTitle"].ToString())
                };
                plhRaiseJobPo.Controls.Add(checkBox);
                plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
            }
            foreach (DataRow dataRow in ds.Tables[2].Rows)
            {
                if (string.Compare(dataRow["PoType"].ToString(), "Outwork", true) != 0 || string.Compare(dataRow["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                CheckBox checkBox1 = new CheckBox()
                {
                    ID = string.Concat("chkRaisePO_", dataRow["estimateitemid"].ToString()),
                    Checked = defaultcheck,
                    Text = this.objBC.SpecialDecode(dataRow["ItemTitle"].ToString())
                };
                plhRaiseJobPo.Controls.Add(checkBox1);
                string str = "";
                str = (!(dataRow["suppliername"].ToString() != "") || dataRow["suppliername"] == null ? this.objBC.SpecialDecode(dataRow["ItemTitle"].ToString()) : string.Concat(this.objBC.SpecialDecode(dataRow["ItemTitle"].ToString()), "  (", this.objBC.SpecialDecode(dataRow["suppliername"].ToString()), ")"));
                if (str.Length <= 40)
                {
                    checkBox1.Text = str;
                }
                else
                {
                    checkBox1.Text = string.Concat(str.Substring(0, 40), "..");
                }
                checkBox1.ToolTip = str;
                plhRaiseJobPo.Controls.Add(checkBox1);
                plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
            }
            foreach (DataRow row1 in ds.Tables[3].Rows)
            {
                if (string.Compare(row1["PoType"].ToString(), "single", true) != 0 || string.Compare(row1["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                CheckBox checkBox2 = new CheckBox()
                {
                    ID = string.Concat("chkRaisePO_", row1["estimateitemid"].ToString()),
                    Checked = defaultcheck,
                    Text = this.objBC.SpecialDecode(row1["ItemTitle"].ToString())
                };
                string str1 = "";
                if (row1["SupplierName"].ToString() != "")
                {
                    str1 = string.Concat("  (", this.objBase.SpecialDecode(row1["SupplierName"].ToString()), ")");
                }
                checkBox2.Text = string.Concat(this.objBC.SpecialDecode(row1["ItemTitle"].ToString()), str1);
                checkBox2.ToolTip = string.Concat(this.objBC.SpecialDecode(row1["ItemTitle"].ToString()), str1);
                if (checkBox2.Text.Length > 42)
                {
                    checkBox2.Text = string.Concat(checkBox2.Text.Substring(0, 42), "..");
                }
                plhRaiseJobPo.Controls.Add(checkBox2);
                plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
            }
            foreach (DataRow dataRow1 in ds.Tables[4].Rows)
            {
                if (string.Compare(dataRow1["PoType"].ToString(), "pad", true) != 0 || string.Compare(dataRow1["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                CheckBox checkBox3 = new CheckBox()
                {
                    ID = string.Concat("chkRaisePO_", dataRow1["estimateitemid"].ToString()),
                    Checked = defaultcheck,
                    Text = this.objBC.SpecialDecode(dataRow1["ItemTitle"].ToString())
                };
                string str2 = "";
                if (dataRow1["SupplierName"].ToString() != "")
                {
                    str2 = string.Concat("  (", this.objBase.SpecialDecode(dataRow1["SupplierName"].ToString()), ")");
                }
                checkBox3.Text = string.Concat(this.objBC.SpecialDecode(dataRow1["ItemTitle"].ToString()), str2);
                checkBox3.ToolTip = string.Concat(this.objBC.SpecialDecode(dataRow1["ItemTitle"].ToString()), str2);
                if (checkBox3.Text.Length > 42)
                {
                    checkBox3.Text = string.Concat(checkBox3.Text.Substring(0, 42), "..");
                }
                plhRaiseJobPo.Controls.Add(checkBox3);
                plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
            }
            foreach (DataRow row2 in ds.Tables[5].Rows)
            {
                if (string.Compare(row2["PoType"].ToString(), "large", true) != 0 || string.Compare(row2["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:12%;'>"));
                plhRaiseJobPo.Controls.Add(new LiteralControl(this.objBC.SpecialDecode(row2["ItemTitle"].ToString())));
                plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
                int num = 0;
                string empty = string.Empty;
                DataTable dataTable = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(row2["estimateitemid"].ToString()));
                foreach (DataRow dataRow2 in dataTable.Rows)
                {
                    object[] item = new object[] { empty, dataRow2["MaterialID"], "_", num, "▼" };
                    empty = string.Concat(item);
                    plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                    CheckBox checkBox4 = new CheckBox();
                    object[] objArray = new object[] { "chkRaisePO_", row2["estimateitemid"].ToString(), "_", dataRow2["MaterialID"].ToString(), "_", num };
                    checkBox4.ID = string.Concat(objArray);
                    checkBox4.Checked = defaultcheck;
                    checkBox4.Text = this.objBC.SpecialDecode(dataRow2["MaterialName"].ToString());
                    string str3 = "";
                    if (row2["SupplierName"].ToString() != "")
                    {
                        str3 = string.Concat("  (", this.objBase.SpecialDecode(row2["SupplierName"].ToString()), ")");
                    }
                    checkBox4.Text = string.Concat(this.objBC.SpecialDecode(row2["ItemTitle"].ToString()), str3);
                    checkBox4.ToolTip = string.Concat(this.objBC.SpecialDecode(row2["ItemTitle"].ToString()), str3);
                    if (checkBox4.Text.Length > 42)
                    {
                        checkBox4.Text = string.Concat(checkBox4.Text.Substring(0, 42), "..");
                    }
                    plhRaiseJobPo.Controls.Add(checkBox4);
                    plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
                    num++;
                }
                ControlCollection controls = plhRaiseJobPo.Controls;
                string[] strArrays = new string[] { "<label id='lblMaterialIds_", row2["estimateitemid"].ToString(), "' style='display: none;'>", empty, "</label>" };
                controls.Add(new LiteralControl(string.Concat(strArrays)));
            }
            foreach (DataRow row3 in ds.Tables[6].Rows)
            {
                if (string.Compare(row3["PoType"].ToString(), "Lithosingle", true) != 0 || string.Compare(row3["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                CheckBox checkBox5 = new CheckBox()
                {
                    ID = string.Concat("chkRaisePO_", row3["estimateitemid"].ToString()),
                    Checked = defaultcheck,
                    Text = this.objBC.SpecialDecode(row3["ItemTitle"].ToString())
                };
                string str4 = "";
                if (row3["SupplierName"].ToString() != "")
                {
                    str4 = string.Concat("  (", this.objBase.SpecialDecode(row3["SupplierName"].ToString()), ")");
                }
                checkBox5.Text = string.Concat(this.objBC.SpecialDecode(row3["ItemTitle"].ToString()), str4);
                checkBox5.ToolTip = string.Concat(this.objBC.SpecialDecode(row3["ItemTitle"].ToString()), str4);
                if (checkBox5.Text.Length > 42)
                {
                    checkBox5.Text = string.Concat(checkBox5.Text.Substring(0, 42), "..");
                }
                plhRaiseJobPo.Controls.Add(checkBox5);
                plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
            }
            foreach (DataRow dataRow3 in ds.Tables[7].Rows)
            {
                if (string.Compare(dataRow3["PoType"].ToString(), "Lithopad", true) != 0 || string.Compare(dataRow3["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                CheckBox checkBox6 = new CheckBox()
                {
                    ID = string.Concat("chkRaisePO_", dataRow3["estimateitemid"].ToString()),
                    Checked = defaultcheck,
                    Text = this.objBC.SpecialDecode(dataRow3["ItemTitle"].ToString())
                };
                string str5 = "";
                if (dataRow3["SupplierName"].ToString() != "")
                {
                    str5 = string.Concat("  (", this.objBase.SpecialDecode(dataRow3["SupplierName"].ToString()), ")");
                }
                checkBox6.Text = string.Concat(this.objBC.SpecialDecode(dataRow3["ItemTitle"].ToString()), str5);
                checkBox6.ToolTip = string.Concat(this.objBC.SpecialDecode(dataRow3["ItemTitle"].ToString()), str5);
                if (checkBox6.Text.Length > 42)
                {
                    checkBox6.Text = string.Concat(checkBox6.Text.Substring(0, 42), "..");
                }
                plhRaiseJobPo.Controls.Add(checkBox6);
                plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
            }
            foreach (DataRow row4 in ds.Tables[8].Rows)
            {
                if (string.Compare(row4["PoType"].ToString(), "ProductCatalogue", true) != 0 || string.Compare(row4["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                CheckBox checkBox7 = new CheckBox()
                {
                    ID = string.Concat("chkRaisePO_", row4["estimateitemid"].ToString()),
                    Checked = defaultcheck,
                    Text = this.objBC.SpecialDecode(row4["ItemTitle"].ToString())
                };
                string str6 = "";
                str6 = (!(row4["suppliername"].ToString() != "") || row4["suppliername"] == null ? this.objBC.SpecialDecode(row4["ItemTitle"].ToString()) : string.Concat(this.objBC.SpecialDecode(row4["ItemTitle"].ToString()), "  (", this.objBC.SpecialDecode(row4["suppliername"].ToString()), ")"));
                if (str6.Length <= 41)
                {
                    checkBox7.Text = str6;
                }
                else
                {
                    checkBox7.Text = string.Concat(str6.Substring(0, 41), "..");
                }
                checkBox7.ToolTip = str6;
                plhRaiseJobPo.Controls.Add(checkBox7);
                plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
                DataTable dataTable1 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(row4["estimateitemid"]));
                foreach (DataRow dataRow4 in dataTable1.Rows)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div style='margin-left:15%;'>"));
                    CheckBox checkBox8 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_PrAdIt_", row4["estimateitemid"].ToString(), "_", dataRow4["EstimateAdditionalItemID"].ToString()),
                        Checked = this.IsDefaultPO,
                        Text = this.objBC.SpecialDecode(dataRow4["EstimateOtherCostName"].ToString())
                    };
                    string str7 = "";
                    if (dataRow4["AdditionalItemsSupplierName"].ToString() != "")
                    {
                        str7 = string.Concat("  (", this.objBase.SpecialDecode(dataRow4["AdditionalItemsSupplierName"].ToString()), ")");
                    }
                    string str8 = string.Concat(checkBox8.Text, str7);
                    if (str8.Length <= 36)
                    {
                        checkBox8.Text = str8;
                    }
                    else
                    {
                        checkBox8.Text = string.Concat(str8.Substring(0, 36), "..");
                    }
                    checkBox8.ToolTip = str8;
                    this.plhRaisePO.Controls.Add(checkBox8);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    HiddenField hiddenField = this.hdnProductAddItemsIDs;
                    string[] value = new string[] { this.hdnProductAddItemsIDs.Value, row4["estimateitemid"].ToString(), "_", dataRow4["EstimateAdditionalItemID"].ToString(), "±" };
                    hiddenField.Value = string.Concat(value);
                }
            }
            foreach (DataRow row5 in ds.Tables[9].Rows)
            {
                if (string.Compare(row5["PoType"].ToString().ToLower(), "othercost", true) != 0 || string.Compare(row5["IsEmpty"].ToString().ToLower(), "no", true) != 0)
                {
                    continue;
                }
                plhRaiseJobPo.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                CheckBox checkBox9 = new CheckBox()
                {
                    ID = string.Concat("chkRaisePO_", row5["estothercostid"].ToString()),
                    Checked = defaultcheck,
                    Text = this.objBC.SpecialDecode(row5["ItemDescription"].ToString())
                };
                string str9 = "";
                if (row5["SupplierName"].ToString() != "")
                {
                    str9 = string.Concat("  (", this.objBase.SpecialDecode(row5["SupplierName"].ToString()), ")");
                }
                checkBox9.Text = string.Concat(this.objBC.SpecialDecode(row5["ItemDescription"].ToString()), str9);
                checkBox9.ToolTip = string.Concat(this.objBC.SpecialDecode(row5["ItemDescription"].ToString()), str9);
                if (checkBox9.Text.Length > 42)
                {
                    checkBox9.Text = string.Concat(checkBox9.Text.Substring(0, 42), "..");
                }
                plhRaiseJobPo.Controls.Add(checkBox9);
                plhRaiseJobPo.Controls.Add(new LiteralControl("</div>"));
            }
        }

        protected void btnNext_SelectedItems(object sender, EventArgs e)
        {
            this.RaisePoPlhBind_SplitItem(this.hdnEstItemsSelected.Value);
        }

        protected void btnProgNext_OnClick(object sender, EventArgs e)
        {
            base.Session.Remove("IsProcessed");
            if (this.hdnEstItemsSelected.Value != "")
            {
                string value = this.hid_Remaining_Items.Value;
                string empty = string.Empty;
                string[] strArrays = value.Split(new char[] { '±' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString().Trim() != "")
                    {
                        string[] strArrays1 = strArrays[i].ToString().Split(new char[] { '»' });
                        empty = string.Concat(empty, strArrays1[0].ToString(), "±");
                    }
                }
                string[] strArrays2 = empty.Split(new char[] { '±' });
                string[] strArrays3 = this.hdnEstItemsSelected.Value.Split(new char[] { '±' });
                string str = string.Empty;
                for (int j = 0; j < (int)strArrays3.Length; j++)
                {
                    if (strArrays3[j].ToString().Trim() != "")
                    {
                        string str1 = strArrays3[j];
                        char[] chrArray = new char[] { '»' };
                        if (!strArrays2.Contains<string>(str1.Split(chrArray)[0]))
                        {
                            str = string.Concat(str, strArrays3[j], "±");
                        }
                    }
                }
                this.hid_Selected_Items.Value = str;
            }
            string[] strArrays4 = this.hid_Selected_Items.Value.Split(new char[] { '±' });
            if ((int)strArrays4.Length <= 1)
            {
                if (base.Session["IsProcessed"] == null && this.hdn_checkprogresstojob.Value == "yes")
                {
                    base.Session["IsProcessed"] = "Yes";
                    this.Progress_to_Job();
                    return;
                }
                if (this.JobID != (long)0)
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&jID=", this.JobID };
                    response.Redirect(string.Concat(estimateID));
                }
                return;
            }
            string[] strArrays5 = strArrays4[0].Split(new char[] { '»' });
            this.hid_Selected_Items.Value = this.hid_Selected_Items.Value.Replace(string.Concat(strArrays4[0], "±"), "");
            long num = Convert.ToInt64(strArrays5[0]);
            string str2 = strArrays5[1];
            item_progress_to_job_from_order_view usercontrolItemItemSummaryProgressToJob = this;
            usercontrolItemItemSummaryProgressToJob.get_all_estimatetypes = string.Concat(usercontrolItemItemSummaryProgressToJob.get_all_estimatetypes, str2);
            string str3 = strArrays5[2];
            this.plhProJob.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            this.plhProJob.Controls.Add(new LiteralControl("<b>Select the Quantity of this item, you want to progress to job</b>"));
            this.plhProJob.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            this.plhProJob.Controls.Add(new LiteralControl("<div align='left' style='background-color:white; word-break: break-all;'>"));
            ControlCollection controls = this.plhProJob.Controls;
            object[] objArray = new object[] { "<span id='spn_info_", num, "' style='display:none;'>", num, "»", str2, "</span>" };
            controls.Add(new LiteralControl(string.Concat(objArray)));
            this.plhProJob.Controls.Add(new LiteralControl("<div class='onlyEmpty'>"));
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            this.plhProJob.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            this.plhProJob.Controls.Add(new LiteralControl("<div class='bgLabel'><b>&nbsp;&nbsp;Item Name</b></div>"));
            this.plhProJob.Controls.Add(new LiteralControl("<div class='Qtybox'>"));
            this.plhProJob.Controls.Add(new LiteralControl(string.Concat("<b>", this.objBase.SpecialDecode(str3), "</b>")));
            this.plhProJob.Controls.Add(new LiteralControl("</div>"));
            this.plhProJob.Controls.Add(new LiteralControl("</div>"));
            if (this.hdn_getselected_supplier.Value != "" && (str2 == "C" || str2 == "O" || str2 == "W"))
            {
                Convert.ToInt32(this.hdn_getselected_supplier.Value);
            }
            DataTable dataTable = EstimatesBasePage.estimate_item_total_price_details_select(this.CompanyID, num, str2);
            foreach (DataRow row in dataTable.Rows)
            {
                if (str2 != "O")
                {
                    num1 = Convert.ToInt32(dataTable.Rows[0]["TotalQty1"]);
                    num2 = Convert.ToInt32(dataTable.Rows[0]["TotalQty2"]);
                    num3 = Convert.ToInt32(dataTable.Rows[0]["TotalQty3"]);
                    num4 = Convert.ToInt32(dataTable.Rows[0]["TotalQty4"]);
                }
                num5 = Convert.ToDecimal(row["TotalSellingPrice1"]);
                num6 = Convert.ToDecimal(row["TotalSellingPrice2"]);
                num7 = Convert.ToDecimal(row["TotalSellingPrice3"]);
                num8 = Convert.ToDecimal(row["TotalSellingPrice4"]);
                if (str2 == "S" || str2 == "B" || str2 == "P" || str2 == "F" || str2 == "K" || str2 == "D" || str2 == "N" || str2 == "L" || str2 == "U" || str2 == "C")
                {
                    this.hdn_getselected_supplier_c_o.Value = this.objBC.SpecialDecode(row["SupplierName"].ToString());
                    this.suppliername1 = this.objBC.SpecialDecode(row["SupplierName"].ToString());
                    this.suppliername2 = this.objBC.SpecialDecode(row["SupplierName"].ToString());
                    this.suppliername3 = this.objBC.SpecialDecode(row["SupplierName"].ToString());
                    this.suppliername4 = this.objBC.SpecialDecode(row["SupplierName"].ToString());
                }
                if ((string.Compare(str2, "B", true) == 0 || string.Compare(str2, "K", true) == 0 || string.Compare(str2, "N", true) == 0) && Convert.ToInt64(row["SectionID"]) == (long)-999)
                {
                    num5 = Convert.ToDecimal(row["TotalSellingPrice1"]);
                    num6 = Convert.ToDecimal(row["TotalSellingPrice2"]);
                    num7 = Convert.ToDecimal(row["TotalSellingPrice3"]);
                    num8 = Convert.ToDecimal(row["TotalSellingPrice4"]);
                }
                if (string.Compare(str2, "O", true) != 0)
                {
                    continue;
                }
                foreach (DataRow dataRow in EstimatesBasePage.summary_outwork_select(this.CompanyID, num).Rows)
                {
                    if (Convert.ToInt32(dataRow["QuantityNumber"]) == 1)
                    {
                        num1 = Convert.ToInt32(dataRow["Quantity"]);
                        this.suppliername1 = this.objBC.SpecialDecode(dataRow["SupplierName"].ToString());
                        HiddenField hdnSuppliername1 = this.hdn_suppliername1;
                        hdnSuppliername1.Value = string.Concat(hdnSuppliername1.Value, this.suppliername1, ",");
                    }
                    else if (Convert.ToInt32(dataRow["QuantityNumber"]) == 2)
                    {
                        num2 = Convert.ToInt32(dataRow["Quantity"]);
                        this.suppliername2 = this.objBC.SpecialDecode(dataRow["SupplierName"].ToString());
                        HiddenField hdnSuppliername2 = this.hdn_suppliername2;
                        hdnSuppliername2.Value = string.Concat(hdnSuppliername2.Value, this.suppliername2, ",");
                    }
                    else if (Convert.ToInt32(dataRow["QuantityNumber"]) != 3)
                    {
                        if (Convert.ToInt32(dataRow["QuantityNumber"]) != 4)
                        {
                            continue;
                        }
                        num4 = Convert.ToInt32(dataRow["Quantity"]);
                        this.suppliername4 = this.objBC.SpecialDecode(dataRow["SupplierName"].ToString());
                        HiddenField hdnSuppliername4 = this.hdn_suppliername4;
                        hdnSuppliername4.Value = string.Concat(hdnSuppliername4.Value, this.suppliername4, ",");
                    }
                    else
                    {
                        num3 = Convert.ToInt32(dataRow["Quantity"]);
                        this.suppliername3 = this.objBC.SpecialDecode(dataRow["SupplierName"].ToString());
                        HiddenField hdnSuppliername3 = this.hdn_suppliername3;
                        hdnSuppliername3.Value = string.Concat(hdnSuppliername3.Value, this.suppliername3, ",");
                    }
                }
            }
            bool flag = true;
            if (num1 != 0)
            {
                string empty1 = string.Empty;
                if (!flag)
                {
                    object[] objArray1 = new object[] { "<input id='rd_1_", num, "'  type='radio'  name='QtyRadio' />Quantity 1 (", num1, ")" };
                    empty1 = string.Concat(objArray1);
                }
                else
                {
                    object[] objArray2 = new object[] { "<input id='rd_1_", num, "' checked='checked' type='radio'  name='QtyRadio' />Quantity 1 (", num1, ")" };
                    empty1 = string.Concat(objArray2);
                }
                flag = false;
                this.plhProJob.Controls.Add(new LiteralControl("<div class='onlyEmpty'>"));
                this.plhProJob.Controls.Add(new LiteralControl("<div class='bgLabel'>"));
                this.plhProJob.Controls.Add(new LiteralControl(empty1));
                this.plhProJob.Controls.Add(new LiteralControl("</div>"));
                this.plhProJob.Controls.Add(new LiteralControl("<div class='Qtybox'>"));
                this.plhProJob.Controls.Add(new LiteralControl(this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num5, 0, "", false, false, true, false, false), true) ?? ""));
                if (this.suppliername1 != "")
                {
                    this.plhProJob.Controls.Add(new LiteralControl(string.Concat("    (", this.suppliername1, ")")));
                }
                this.plhProJob.Controls.Add(new LiteralControl("</div>"));
            }
            if (num2 != 0)
            {
                string empty2 = string.Empty;
                if (!flag)
                {
                    object[] objArray3 = new object[] { "<input id='rd_2_", num, "' type='radio'  name='QtyRadio' />Quantity 2 (", num2, ")" };
                    empty2 = string.Concat(objArray3);
                }
                else
                {
                    object[] objArray4 = new object[] { "<input id='rd_2_", num, "' type='radio' checked='checked'  name='QtyRadio' />Quantity 2 (", num2, ")" };
                    empty2 = string.Concat(objArray4);
                }
                flag = false;
                this.plhProJob.Controls.Add(new LiteralControl("<div class='onlyEmpty'>"));
                this.plhProJob.Controls.Add(new LiteralControl("<div class='bgLabel'>"));
                this.plhProJob.Controls.Add(new LiteralControl(empty2));
                this.plhProJob.Controls.Add(new LiteralControl("</div>"));
                this.plhProJob.Controls.Add(new LiteralControl("<div class='Qtybox'>"));
                this.plhProJob.Controls.Add(new LiteralControl(this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num6, 0, "", false, false, true, false, false), true) ?? ""));
                if (this.suppliername2 != "")
                {
                    this.plhProJob.Controls.Add(new LiteralControl(string.Concat("    (", this.suppliername2, ")")));
                }
                this.plhProJob.Controls.Add(new LiteralControl("</div>"));
            }
            if (num3 != 0)
            {
                string empty3 = string.Empty;
                if (!flag)
                {
                    object[] objArray5 = new object[] { "<input id='rd_3_", num, "' type='radio'  name='QtyRadio' />Quantity 3 (", num3, ")" };
                    empty3 = string.Concat(objArray5);
                }
                else
                {
                    object[] objArray6 = new object[] { "<input id='rd_3_", num, "' type='radio' checked='checked'  name='QtyRadio' />Quantity 3 (", num3, ")" };
                    empty3 = string.Concat(objArray6);
                }
                flag = false;
                this.plhProJob.Controls.Add(new LiteralControl("<div class='onlyEmpty'>"));
                this.plhProJob.Controls.Add(new LiteralControl("<div class='bgLabel'>"));
                this.plhProJob.Controls.Add(new LiteralControl(empty3));
                this.plhProJob.Controls.Add(new LiteralControl("</div>"));
                this.plhProJob.Controls.Add(new LiteralControl("<div class='Qtybox'>"));
                this.plhProJob.Controls.Add(new LiteralControl(this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num7, 0, "", false, false, true, false, false), true) ?? ""));
                if (this.suppliername3 != "")
                {
                    this.plhProJob.Controls.Add(new LiteralControl(string.Concat("    (", this.suppliername3, ")")));
                }
                this.plhProJob.Controls.Add(new LiteralControl("</div>"));
            }
            if (num4 != 0)
            {
                string empty4 = string.Empty;
                if (!flag)
                {
                    object[] objArray7 = new object[] { "<input id='rd_4_", num, "' type='radio'  name='QtyRadio'  />Quantity 4 (", num4, ")" };
                    empty4 = string.Concat(objArray7);
                }
                else
                {
                    object[] objArray8 = new object[] { "<input id='rd_4_", num, "' type='radio' checked='checked'  name='QtyRadio'  />Quantity 4 (", num4, ")" };
                    empty4 = string.Concat(objArray8);
                }
                flag = false;
                this.plhProJob.Controls.Add(new LiteralControl("<div class='onlyEmpty'>"));
                this.plhProJob.Controls.Add(new LiteralControl("<div class='bgLabel'>"));
                this.plhProJob.Controls.Add(new LiteralControl(empty4));
                this.plhProJob.Controls.Add(new LiteralControl("</div>"));
                this.plhProJob.Controls.Add(new LiteralControl("<div class='Qtybox'>"));
                this.plhProJob.Controls.Add(new LiteralControl(this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num8, 0, "", false, false, true, false, false), true) ?? ""));
                if (this.suppliername4 != "")
                {
                    this.plhProJob.Controls.Add(new LiteralControl(string.Concat("    (", this.suppliername4, ")")));
                }
                this.plhProJob.Controls.Add(new LiteralControl("</div>"));
            }
            this.plhProJob.Controls.Add(new LiteralControl("<div class='only10px'></div><div class='only5px'></div>"));
            this.plhProJob.Controls.Add(new LiteralControl("<div >"));
            this.plhProJob.Controls.Add(new LiteralControl("<div class='bgLabel' style='background-color:white;'>&nbsp;</div>"));
            this.plhProJob.Controls.Add(new LiteralControl("<div class='box'>"));
            this.plhProJob.Controls.Add(new LiteralControl(string.Concat("<input type='submit' value='Next' class='button' onclick=Ok_and_Next('", num, "');return false; >")));
            this.plhProJob.Controls.Add(new LiteralControl("</div>"));
            this.plhProJob.Controls.Add(new LiteralControl("</div>"));
            this.plhProJob.Controls.Add(new LiteralControl("</div>"));
        }

        private string Call_Inventory_Adjustment(string JobStatus, long EstimateID, string JobStatusID)
        {
            object[] estimateID;
            string empty = string.Empty;
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            dataTable = JobBasePage.Job_Card_Info_Select_By_JobID(this.JobID);
            string str = string.Empty;
            string empty1 = string.Empty;
            int num = 0;
            string str1 = string.Empty;
            if (JobStatus == "completed-i")
            {
                JobStatus = "completed";
                str1 = "invoice";
            }
            if (JobStatus == "progressed-i")
            {
                JobStatus = "progressed";
                str1 = "invoice";
            }
            if (JobStatus == "reverted-i")
            {
                str1 = "invoice";
            }
            int num1 = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["EstimateItemID"] == null)
                {
                    continue;
                }
                long num2 = Convert.ToInt64(row["EstimateItemID"]);
                int num3 = Convert.ToInt32(row["QtyNumber"]);
                string str2 = row["ItemType"].ToString();
                long num4 = (long)0;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                int num5 = 0;
                int num6 = 0;
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal printSheetCalulation = new decimal(0);
                decimal num10 = new decimal(0);
                string str3 = string.Empty;
                str = row["JobNumber"].ToString();
                num = Convert.ToInt32(row["StatusID"].ToString());
                if (row["InvoiceNumber"] != null)
                {
                    empty1 = row["InvoiceNumber"].ToString();
                }
                if (string.Compare(str2, "S", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow["PaperID"]);
                        empty2 = "I";
                        dataRow["InventoryCode"].ToString();
                        dataRow["inventoryname"].ToString();
                        num5 = Convert.ToInt32(dataRow["Quantity"]);
                        Convert.ToDecimal(dataRow["PackedIn"]);
                        Convert.ToInt64(dataRow["EstimateSingleItemID"]);
                        Convert.ToDecimal(dataRow["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow["PaperMarkup"]);
                        num10 = Convert.ToDecimal(dataRow["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "P", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row1 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row1["PaperID"]);
                        empty2 = "I";
                        row1["InventoryCode"].ToString();
                        row1["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row1["Quantity"]);
                        Convert.ToDecimal(row1["PackedIn"]);
                        Convert.ToInt64(row1["EstimatePadItemID"]);
                        Convert.ToDecimal(row1["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(row1["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(row1["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row1["RunningSpoilage"]);
                        Convert.ToDecimal(row1["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row1["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "L", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow1["PaperID"]);
                        empty2 = "I";
                        dataRow1["InventoryCode"].ToString();
                        dataRow1["inventoryname"].ToString();
                        num5 = Convert.ToInt32(dataRow1["Quantity"]);
                        Convert.ToDecimal(dataRow1["PackedIn"]);
                        Convert.ToInt64(dataRow1["EstimateLargeItemID"]);
                        Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow1["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow1["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow1["PaperMarkup"]);
                        Convert.ToDecimal(dataRow1["JobHeight"]);
                        Convert.ToDecimal(dataRow1["JobWidth"]);
                        Convert.ToDecimal(dataRow1["SheetHeight"]);
                        Convert.ToDecimal(dataRow1["SheetWidth"]);
                        Convert.ToDecimal(dataRow1["GutterHorizontal"]);
                        Convert.ToDecimal(dataRow1["GutterVertical"]);
                        Convert.ToDecimal(dataRow1["Row"]);
                        Convert.ToDecimal(dataRow1["Col"]);
                        dataRow1["PrintLayout"].ToString();
                        dataRow1["PressPaperType"].ToString();
                        num10 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["InvSheets"].ToString()), 0, "", false, false, true));
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, num10);
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, num10, JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "B", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    Hashtable hashtables = new Hashtable();
                    foreach (DataRow row2 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row2["PaperID"]);
                        empty2 = "I";
                        row2["InventoryCode"].ToString();
                        row2["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row2["Quantity"]);
                        Convert.ToDecimal(row2["PackedIn"]);
                        Convert.ToInt64(row2["EstimateBookletItemID"]);
                        Convert.ToDecimal(row2["PaperUnitPrice"]);
                        Convert.ToDecimal(row2["NoOfSignatures"]);
                        num7 = Convert.ToDecimal(row2["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row2["RunningSpoilage"]);
                        Convert.ToDecimal(row2["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row2["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        if (!hashtables.ContainsKey(num4))
                        {
                            hashtables.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            hashtables[num4] = Convert.ToInt32(hashtables[num4].ToString()) + Convert.ToInt32(num10);
                        }
                    }
                    foreach (long key in hashtables.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key), empty2, Convert.ToInt32(hashtables[key]), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "W", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    Hashtable hashtables1 = new Hashtable();
                    foreach (DataRow dataRow2 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow2["WarehouseTypeID"]);
                        empty2 = dataRow2["WarehouseType"].ToString();
                        num5 = Convert.ToInt32(dataRow2["Quantity"]);
                        if (Convert.ToInt32(dataRow2["IsDeleted"]) != 0)
                        {
                            continue;
                        }
                        if (!hashtables1.ContainsKey(num4))
                        {
                            hashtables1.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            hashtables1[num4] = Convert.ToDecimal(hashtables1[num4].ToString()) + Convert.ToDecimal(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num5);
                        }
                        num1 = num1 + this.SummaryClassObj.Select_Quantity_History_For_Inventory(num2);
                    }
                    if (hashtables1.Count > 0)
                    {
                        foreach (long key1 in hashtables1.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key1), empty2, Convert.ToInt32(hashtables1[key1]), JobStatus, num2);
                        }
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "O", true) == 0 || string.Compare(str2, "U", true) == 0) ////modification by bilal ticket # 8071
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "C", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row3 in dataSet.Tables[0].Rows)
                    {
                        long num11 = Convert.ToInt64(row3["PriceCatalogueID"]);
                        num5 = Convert.ToInt32(row3["Quantity"]);
                        decimal num12 = Convert.ToDecimal(row3["Price"]);
                        BaseClass baseClass = new BaseClass();
                        string str4 = baseClass.Return_StockManagementSettings("SA_EprintMISJobs");
                        string str5 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str6 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str7 = baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
                        if (str4 == "e")
                        {
                            foreach (DataRow dataRow3 in baseClass.ProductStockType_Select((long)this.CompanyID, num11).Rows)
                            {
                                if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty = baseClass.StockAllocationProcess((long)this.CompanyID, num11, (long)0, num5, str5, "self", Convert.ToBoolean(str6), num2, "Job", num12, (long)this.UserID);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty = baseClass.StockAllocation_Others((long)this.CompanyID, num11, num5, str5, Convert.ToBoolean(str6), num2, "Job", num12, (long)this.UserID);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    empty = baseClass.StockAllocationProcess((long)this.CompanyID, num11, (long)0, num5, str5, "multiple", Convert.ToBoolean(str6), num2, "Job", num12, (long)this.UserID);
                                }
                                else
                                {
                                    empty = baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num11, num5, str5, "additional option", Convert.ToBoolean(str6), num2, "Job", num12, (long)this.UserID);
                                }
                            }
                        }
                        if (!(str7 == "j") || !(baseClass.Return_StockManagementSettings("SR_JobStatusID") == JobStatusID.ToString()))
                        {
                            continue;
                        }
                        foreach (DataRow row4 in baseClass.ProductStockType_Select((long)this.CompanyID, num11).Rows)
                        {
                            base.Session["StockItemType"] = "C";
                            if (row4["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass.StockReductionProcess((long)this.CompanyID, num11, (long)0, "self", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else if (row4["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num11, "other", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else if (row4["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row4["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass.StockReductionProcess((long)this.CompanyID, num11, (long)0, "multiple", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else
                            {
                                empty = baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num11, "additional option", num5, num2, "Job", (long)this.UserID, num12);
                            }
                        }
                    }
                    base.Session["StockItemType"] = "C";
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "F", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.litho_estimate_select(this.CompanyID, num2);
                    foreach (DataRow dataRow4 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(dataRow4["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(dataRow4["Noofplates"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num5);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num5), JobStatus, num2);
                    }
                    foreach (DataRow row5 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row5["PaperID"]);
                        empty2 = "I";
                        row5["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row5["ItemDescription"].ToString());
                        num5 = Convert.ToInt32(row5["Quantity"]);
                        Convert.ToDecimal(row5["PackedIn"]);
                        Convert.ToInt64(row5["EstLithoItemID"]);
                        Convert.ToDecimal(row5["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(row5["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(row5["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row5["RunningSpoilage"]);
                        Convert.ToDecimal(row5["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row5["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "D", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, num2);
                    foreach (DataRow dataRow5 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(dataRow5["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(dataRow5["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num5), JobStatus, num2);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num5);
                        }
                    }
                    foreach (DataRow row6 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row6["PaperID"]);
                        empty2 = "I";
                        row6["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row6["ItemDescription"].ToString());
                        num5 = Convert.ToInt32(row6["Quantity"]);
                        Convert.ToDecimal(row6["PackedIn"]);
                        Convert.ToInt64(row6["EstimateLithoPadItemID"]);
                        Convert.ToDecimal(row6["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(row6["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(row6["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row6["RunningSpoilage"]);
                        Convert.ToDecimal(row6["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row6["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "N", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.lithoncr_item_select(this.CompanyID, num2);
                    Hashtable hashtables2 = new Hashtable();
                    foreach (DataRow dataRow6 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(dataRow6["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(dataRow6["Noofplates"]);
                        if (!hashtables2.ContainsKey(num4))
                        {
                            hashtables2.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            hashtables2[num4] = Convert.ToDecimal(hashtables2[num4].ToString()) + Convert.ToDecimal(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num5);
                        }
                    }
                    foreach (long key2 in hashtables2.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key2), empty2, Convert.ToInt32(hashtables2[key2]), JobStatus, num2);
                    }
                    hashtables2.Clear();
                    foreach (DataRow row7 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row7["PaperID"]);
                        empty2 = "I";
                        row7["InventoryCode"].ToString();
                        row7["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row7["Quantity"]);
                        Convert.ToDecimal(row7["PackedIn"]);
                        Convert.ToInt64(row7["EstimateLithoNCRItemID"]);
                        Convert.ToDecimal(row7["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(row7["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(row7["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row7["RunningSpoilage"]);
                        Convert.ToDecimal(row7["NcrPartsPerSet"].ToString());
                        Convert.ToDecimal(row7["NcrSetsPerPad"].ToString());
                        Convert.ToDecimal(row7["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row7["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToDecimal(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        if (!hashtables2.ContainsKey(num4))
                        {
                            hashtables2.Add(num4, Convert.ToDecimal(printSheetCalulation));
                        }
                        else
                        {
                            hashtables2[num4] = Convert.ToDecimal(hashtables2[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                    }
                    foreach (long key3 in hashtables2.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key3), empty2, Convert.ToInt32(hashtables2[key3]), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "K", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.lithobooklet_item_select(this.CompanyID, num2);
                    Hashtable hashtables3 = new Hashtable();
                    foreach (DataRow dataRow7 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(dataRow7["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(dataRow7["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num5), JobStatus, num2);
                        if (!hashtables3.ContainsKey(num4))
                        {
                            hashtables3.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            hashtables3[num4] = Convert.ToDecimal(hashtables3[num4].ToString()) + Convert.ToDecimal(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num5);
                        }
                    }
                    foreach (long key4 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key4), empty2, Convert.ToInt32(hashtables3[key4]), JobStatus, num2);
                    }
                    hashtables3.Clear();
                    foreach (DataRow row8 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row8["PaperID"]);
                        empty2 = "I";
                        row8["InventoryCode"].ToString();
                        row8["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row8["Quantity"]);
                        Convert.ToDecimal(row8["PackedIn"]);
                        Convert.ToInt64(row8["EstimateLithobookletItemID"]);
                        Convert.ToDecimal(row8["PaperUnitPrice"]);
                        Convert.ToInt32(row8["NoOfSignatures"]);
                        num7 = Convert.ToDecimal(row8["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row8["RunningSpoilage"]);
                        Convert.ToDecimal(row8["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row8["InvSheets"]);
                        if (!hashtables3.ContainsKey(num4))
                        {
                            hashtables3.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            hashtables3[num4] = Convert.ToInt32(hashtables3[num4].ToString()) + Convert.ToInt32(num10);
                        }
                    }
                    foreach (long key5 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key5), empty2, Convert.ToInt32(hashtables3[key5]), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "Q", true) != 0)
                {
                    if (string.Compare(str2, "X", true) != 0)
                    {
                        continue;
                    }
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow dataRow8 in dataSet.Tables[0].Rows)
                    {
                        long num13 = Convert.ToInt64(dataRow8["PriceCatalogueID"]);
                        num5 = Convert.ToInt32(dataRow8["Quantity"]);
                        decimal num14 = Convert.ToDecimal(dataRow8["Price"]);
                        BaseClass baseClass1 = new BaseClass();
                        string str8 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                        string str9 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str10 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str11 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                        long num15 = Convert.ToInt64(dataRow8["OrderItemId"]);
                        bool flag = Convert.ToBoolean(dataRow8["IsStockReplenish"]);
                        bool flag1 = Convert.ToBoolean(dataRow8["IsStockReplenished"]);
                        baseClass1.Return_StockManagementSettings("SC_IfJobCancelled");
                        bool flag2 = true;
                        if (flag.ToString().ToLower() == "true" && flag1.ToString().ToLower() != "true")
                        {
                            flag2 = false;
                        }
                        if (!(flag.ToString().ToLower() != "true") || !(flag2.ToString().ToLower() == "true"))
                        {
                            continue;
                        }
                        if (str8 == "e")
                        {
                            baseClass1.Return_StockManagementSettings("SA_EstoreJobStatusID");
                            baseClass1.Return_StockManagementSettings("SA_JobStatusID");
                            foreach (DataRow row9 in baseClass1.ProductStockType_Select((long)this.CompanyID, num13).Rows)
                            {
                                if (row9["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    empty = baseClass1.StockAllocationProcess((long)this.CompanyID, num13, (long)0, num5, str9, "self", Convert.ToBoolean(str10), num2, "Job", num14, (long)this.UserID);
                                }
                                else if (row9["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    empty = baseClass1.StockAllocation_Others((long)this.CompanyID, num13, num5, str9, Convert.ToBoolean(str10), num2, "Job", num14, (long)this.UserID);
                                }
                                else if (row9["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row9["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    foreach (DataRow dataRow9 in PurchaseBasePage.OtherMultipleProductDetails_Select(num13, num5, true).Rows)
                                    {
                                        empty = baseClass1.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow9["KitItemID"].ToString()), num13, num5, str9, "multiple", Convert.ToBoolean(str10), num2, "Job", num14, (long)this.UserID);
                                    }
                                }
                                else
                                {
                                    empty = baseClass1.StockAllocationForAdditionalOptionEstore((long)this.CompanyID, num13, num5, str9, "additional option", Convert.ToBoolean(str10), num2, "Job", num14, (long)this.UserID, EstimateID, num15);
                                }
                            }
                        }
                        if (!(str11 == "j") || !(baseClass1.Return_StockManagementSettings("SR_JobStatusID") == JobStatusID))
                        {
                            continue;
                        }
                        foreach (DataRow row10 in baseClass1.ProductStockType_Select((long)this.CompanyID, num13).Rows)
                        {
                            base.Session["StockItemType"] = "X";
                            base.Session["ALC_OrderItemId"] = num15.ToString();
                            if (row10["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass1.StockReductionProcess((long)this.CompanyID, num13, (long)0, "self", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else if (row10["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num13, "other", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else if (row10["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row10["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass1.StockReductionProcess((long)this.CompanyID, num13, (long)0, "multiple", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else
                            {
                                empty = baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num13, "additional option", num5, num2, "Job", (long)this.UserID, num14);
                            }
                        }
                    }
                    base.Session["StockItemType"] = "X";
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow dataRow10 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow10["PaperID"]);
                        empty2 = "I";
                        dataRow10["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(dataRow10["ItemDescription"].ToString());
                        num5 = Convert.ToInt32(dataRow10["Quantity"]);
                        Convert.ToDecimal(dataRow10["PackedIn"]);
                        Convert.ToInt64(dataRow10["QuickQuoteID"]);
                        Convert.ToDecimal(dataRow10["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow10["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow10["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow10["RunningSpoilage"]);
                        printSheetCalulation = EstimatesBasePage.GetPrintSheetCalulation(num5, num6, num7, num8, new decimal(0), "singleitem", new decimal(0), "", out num9);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(printSheetCalulation));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(printSheetCalulation);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(printSheetCalulation), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
            }
            this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
            if (this.htInventory.Count > 0)
            {
                foreach (long key6 in this.htInventory.Keys)
                {
                    string empty4 = string.Empty;
                    DataTable dataTable2 = InventoryBasePage.Select_Activity_History_For_Inventory(Convert.ToInt64(key6));
                    if (dataTable2.Rows.Count > 0)
                    {
                        foreach (DataRow row11 in dataTable2.Rows)
                        {
                            empty4 = row11["FinalQuantity"].ToString();
                        }
                    }
                    if (JobStatus == "reverted-i")
                    {
                        commonClass _commonClass = this.commclass;
                        long num16 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock restored due to job status not matched: <a href='", this.strSitepath, "invoice/invoice_summary.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", empty1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num16, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "a", Convert.ToDecimal(empty4) + Convert.ToDecimal(this.htInventory[key6]));
                    }
                    if (JobStatus == "completed")
                    {
                        if (empty4 == null || empty4 == "")
                        {
                            empty4 = "0";
                        }
                        if (str1 != "invoice")
                        {
                            commonClass _commonClass1 = this.commclass;
                            long num17 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", str, "</a>" };
                            _commonClass1.Insert_Activity_History_For_Inventory(num17, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "u", Convert.ToDecimal(empty4) - Convert.ToDecimal(this.htInventory[key6]));
                        }
                        else
                        {
                            commonClass _commonClass2 = this.commclass;
                            long num18 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", this.strSitepath, "/invoice/invoice_summary.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", empty1, "</a>" };
                            _commonClass2.Insert_Activity_History_For_Inventory(num18, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "u", Convert.ToDecimal(empty4) - Convert.ToDecimal(this.htInventory[key6]));
                        }
                    }
                    if (JobStatus != "cancelled")
                    {
                        if (!(JobStatus == "progressed") || !(this.ReduceStockType.ToLower() != "e") || !(this.ReduceStockType.ToLower() != num.ToString()) || !(this.ReduceStockType.ToLower() != "i") || !(str1 != "invoice"))
                        {
                            continue;
                        }
                        commonClass _commonClass3 = this.commclass;
                        long num19 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock allocated: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", str, "</a>" };
                        _commonClass3.Insert_Activity_History_For_Inventory(num19, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "h", new decimal(0));
                    }
                    else
                    {
                        if (empty4 == null || empty4 == "")
                        {
                            empty4 = "0";
                        }
                        commonClass _commonClass4 = this.commclass;
                        long num20 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock restored due to job cancellation: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", str, "</a>" };
                        _commonClass4.Insert_Activity_History_For_Inventory(num20, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "a", Convert.ToDecimal(empty4) + Convert.ToDecimal(this.htInventory[key6]));
                    }
                }
            }
            return empty;
        }

        public void Insert_ActivityHistory_Purchase(long EstimateID, long PurchaseID, string Job_number, string PONO, string CustomerName, int CompanyID, int UserID)
        {
            notesclass _notesclass = new notesclass();
            Notes note = new Notes();
            commonClass _commonClass = new commonClass();
            _notesclass.ModuleName = "purchase";
            _notesclass.Po_number = PONO;
            _notesclass.Job_number = Job_number;
            _notesclass.NotesType = Convert.ToString(Notes.NotesType.POCreatedFromJob);
            _notesclass.ModuleID = PurchaseID;
            _notesclass.CustomerName = CustomerName;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, UserID, true);
            _notesclass.CompanyID = CompanyID;
            _notesclass.UserID = UserID;
            note.NotesAdd(_notesclass);
        }

        protected void lnkProgress_OnClick(object sender, EventArgs e)
        {
            this.Progress_to_Job();
            //if (base.Session["IsProcessed"] == null || this.hdn_checkprogresstojob.Value == "yes")
            //{
            //    base.Session["IsProcessed"] = "Yes";
            //    this.Progress_to_Job();
            //    return;
            //}
            //if (this.JobID == (long)0)
            //{
            //    this.JobID = Convert.ToInt64(base.Session["JobID"]);
            //}
            //HttpResponse response = base.Response;
            //object[] estimateID = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&isprogresstojob=1&jID=", this.JobID };
            //response.Redirect(string.Concat(estimateID));
        }

        public int GetWeekNumber(string WeekDay)
        {
            int num = 0;
            string lower = WeekDay.Trim().ToLower();
            string str = lower;
            if (lower != null)
            {
                switch (str)
                {
                    case "sunday":
                        {
                            num = 1;
                            break;
                        }
                    case "monday":
                        {
                            num = 2;
                            break;
                        }
                    case "tuesday":
                        {
                            num = 3;
                            break;
                        }
                    case "wednesday":
                        {
                            num = 4;
                            break;
                        }
                    case "thursday":
                        {
                            num = 5;
                            break;
                        }
                    case "friday":
                        {
                            num = 6;
                            break;
                        }
                    case "saturday":
                        {
                            num = 7;
                            break;
                        }
                    default:
                        {
                            num = -1;
                            return num;
                        }
                }
            }
            else
            {
                num = -1;
                return num;
            }
            return num;
        }

        public DateTime ReturnWeekDate(DateTime TodaysDate, int WorkingDaysFrom, int WorkingDaysTo, int AddDays)
        {
            if (AddDays == 0)
            {
                return TodaysDate;
            }
            this.GetWeekNumber(TodaysDate.DayOfWeek.ToString());
            DateTime todaysDate = TodaysDate;
            for (int i = 1; i <= AddDays; i++)
            {
                try
                {
                    todaysDate = todaysDate.AddDays(1);
                    int weekNumber = this.GetWeekNumber(todaysDate.DayOfWeek.ToString());
                    if (WorkingDaysFrom <= WorkingDaysTo)
                    {
                        while (weekNumber < WorkingDaysFrom || weekNumber > WorkingDaysTo)
                        {
                            todaysDate = todaysDate.AddDays(1);
                            weekNumber = this.GetWeekNumber(todaysDate.DayOfWeek.ToString());
                        }
                    }
                    else
                    {
                        while (weekNumber < WorkingDaysFrom)
                        {
                            if (weekNumber > WorkingDaysTo)
                            {
                                todaysDate = todaysDate.AddDays(1);
                                weekNumber = this.GetWeekNumber(todaysDate.DayOfWeek.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            return todaysDate;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] value;
            char[] chrArray;
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.hdnCompanyID.Value = base.Session["CompanyID"].ToString();
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.UserName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            //if (base.Request.QueryString["ordid"] != null)
            //{
            //    this.ordid = Convert.ToInt64(base.Request.QueryString["ordid"].ToString());
            //}
            //else if (base.Request.QueryString["estid"] != null)
            //{
            //    this.ordid = Convert.ToInt64(base.Request.QueryString["estid"].ToString());
            //}
            //DataTable dataTable = new DataTable();
            //dataTable = Settings.Setting_accountingCode_SelectAllRevenueCode(this.CompanyID);
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    if (row["isDefault"].ToString().ToLower().Trim() != "true")
            //    {
            //        continue;
            //    }
            //    this.AccountingID = Convert.ToInt32(row["AccountCodeID"].ToString());
            //    break;
            //}
            //if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            //{
            //    this.Module = "job";
            //    this.Pgtype = "job";
            //}
            //else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            //{
            //    this.Module = "invoice";
            //    this.Pgtype = "invoice";
            //}
            //else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            //{
            //    this.Module = "estimate";
            //    this.Pgtype = "estimate";
            //    this.Event = "Prompt_User_To_Archive_Estimate";
            //}
            //else
            //{
            //    this.Module = "order";
            //    this.Pgtype = "order";
            //    this.Event = "Prompt_User_To_Archive_Order";
            //}
            //if (base.Session["ProductStockManagement"] != null)
            //{
            //    this.IsStockMgmtEnabled = base.Session["ProductStockManagement"].ToString().Trim().ToLower();
            //}
            //this.Ordernumbervalidtiononlyforcoralcoastsystem = ConnectionClass.Ordernumbervalidtiononlyforcoralcoastsystem.ToString().Trim().ToLower();
            if (ConnectionClass.DeliveryNotePrefix != null)
            {
                this.DeliveryNotePrefix = ConnectionClass.DeliveryNotePrefix;
            }
            else
            {
                this.DeliveryNotePrefix = "DEL-";
            }
            //bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
            if (!ConnectionClass.Is_Non_Printing_System)
            {
                this.div_ArtworkNew.Attributes.Add("style", "display:block");
                this.div_ProofNew.Attributes.Add("style", "display:block");
            }
            else
            {
                this.div_ArtworkNew.Attributes.Add("style", "display:none");
                this.div_ProofNew.Attributes.Add("style", "display:none");
            }
            //if (this.InventoryManagement == "IM")
            //{
            //    this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
            //    this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            //}
            //if (base.Request.QueryString["acthist"] != null)
            //{
            //    this.activityhist = base.Request.QueryString["acthist"].ToString().ToLower();
            //}
            //DataTable dataTable1 = new DataTable();
            //DataTable dataTable2 = new DataTable();
            //if (this.EstimateID != (long)0)
            //{
            //    dataTable1 = EstimatesBasePage.estimate_select_summary_new(this.CompanyID, this.EstimateID);
            //    foreach (DataRow dataRow in dataTable1.Rows)
            //    {
            //        this.IsProformaInvoice = dataRow["IsProformaInvoice"].ToString();
            //        this.CompanyType = dataRow["CompanyType"].ToString();
            //        this.isdirectjob = dataRow["isdirectjob"].ToString();
            //        this.Estimateitemid_directjob = Convert.ToInt64(dataRow["EstimateItemID"].ToString());
            //        this.TxtOrderNo.Text = dataRow["OrderNumber"].ToString();
            //        this.customerstatustitle = dataRow["CustomerStatusTitle"].ToString();
            //    }
            //    dataTable2 = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, this.EstimateID);
            //}
            //this.PaymentType = InvoiceBasePage.Check_Invoice_PaymentType(this.EstimateID);
            foreach (DataRow row1 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                this.lblcustdate1.Text = string.IsNullOrEmpty(row1["DefaultCustomDateTitle1"].ToString()) ? "Custom Date 1" : row1["DefaultCustomDateTitle1"].ToString();
                this.lblcustdate2.Text = string.IsNullOrEmpty(row1["DefaultCustomDateTitle2"].ToString()) ? "Custom Date 2" : row1["DefaultCustomDateTitle2"].ToString();
                this.lblcustdate3.Text = string.IsNullOrEmpty(row1["DefaultCustomDateTitle3"].ToString()) ? "Custom Date 3" : row1["DefaultCustomDateTitle3"].ToString();
                this.lblcustdate4.Text = string.IsNullOrEmpty(row1["DefaultCustomDateTitle4"].ToString()) ? "Custom Date 4" : row1["DefaultCustomDateTitle4"].ToString();
                this.lblcustdate5.Text = string.IsNullOrEmpty(row1["DefaultCustomDateTitle5"].ToString()) ? "Custom Date 5" : row1["DefaultCustomDateTitle5"].ToString();

                if (row1["IsDefaultPORaise"].ToString() != "True")
                {
                    this.IsDefaultPO = false;
                    this.chkCreatePOs.Checked = false;
                }
                else
                {
                    this.IsDefaultPO = true;
                    this.chkCreatePOs.Checked = true;
                }
                if (row1["IsDefaultDeliveryRaise"].ToString() != "True")
                {
                    this.chkDeliveryNote.Checked = false;       
                }
                else
                {
                    this.chkDeliveryNote.Checked = true;
                }
                if (!Convert.ToBoolean(row1["IsDefaultArtwork"]))
                {
                    this.div_ArtworkNew.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_ArtworkNew.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row1["IsDefaultProof"]))
                {
                    this.div_ProofNew.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_ProofNew.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row1["IsDefaultApproval"]))
                {
                    this.div_ApprovalNew.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_ApprovalNew.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row1["IsDefaultProduction"]))
                {
                    this.divProductionDate.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.divProductionDate.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row1["IsDefaultCompletion"]))
                {
                    this.divJobCompletionDate.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.divJobCompletionDate.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row1["IsDefaultDelivery"]))
                {
                    this.div_deliverydate.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_deliverydate.Attributes.Add("style", "display:block");
                }

                if (!Convert.ToBoolean(row1["IsDefaultCustomDate1"]))
                {
                    this.div_customdate1.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_customdate1.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row1["IsDefaultCustomDate2"]))
                {
                    this.div_customdate2.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_customdate2.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row1["IsDefaultCustomDate3"]))
                {
                    this.div_customdate3.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_customdate3.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row1["IsDefaultCustomDate4"]))
                {
                    this.div_customdate4.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_customdate4.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row1["IsDefaultCustomDate5"]))
                {
                    this.div_customdate5.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_customdate5.Attributes.Add("style", "display:block");
                }

                //if (this.Module != "order")
                //{
                //    continue;
                //}

                //if (dataTable1.Rows.Count > 0)
                //{
                //    DataTable dataTable123 = SettingsBasePage.settings_OrderingProcess_select(Convert.ToInt32(CompanyID), Convert.ToInt32(dataTable1.Rows[0]["eStoreAccountID"]));

                //    if (dataTable123.Rows[0]["isDisplayDates"].ToString().ToLower() != "true")
                //    {
                //        this.div_CON.Attributes.Add("style", "display:none");
                //        this.div_ArtworkNew.Attributes.Add("style", "display:none");
                //        this.div_ProofNew.Attributes.Add("style", "display:none");
                //        this.div_ApprovalNew.Attributes.Add("style", "display:none");
                //        this.divProductionDate.Attributes.Add("style", "display:none");
                //        this.divJobCompletionDate.Attributes.Add("style", "display:none");
                //        this.div_deliverydate.Attributes.Add("style", "display:none");
                //        this.div_ClearDates.Attributes.Add("style", "display:none");
                //    }
                //    else
                //    {
                //        this.div_CON.Attributes.Add("style", "display:block");
                //        this.div_ArtworkNew.Attributes.Add("style", "display:block");
                //        this.div_ProofNew.Attributes.Add("style", "display:block");
                //        this.div_ApprovalNew.Attributes.Add("style", "display:block");
                //        this.divProductionDate.Attributes.Add("style", "display:block");
                //        this.divJobCompletionDate.Attributes.Add("style", "display:block");
                //        this.div_deliverydate.Attributes.Add("style", "display:block");
                //        this.div_ClearDates.Attributes.Add("style", "display:block");
                //    }
                //}

                //else
                //{
                //    this.div_CON.Attributes.Add("style", "display:none");
                //    this.div_ArtworkNew.Attributes.Add("style", "display:none");
                //    this.div_ProofNew.Attributes.Add("style", "display:none");
                //    this.div_ApprovalNew.Attributes.Add("style", "display:none");
                //    this.divProductionDate.Attributes.Add("style", "display:none");
                //    this.divJobCompletionDate.Attributes.Add("style", "display:none");
                //    this.div_deliverydate.Attributes.Add("style", "display:none");
                //    this.div_ClearDates.Attributes.Add("style", "display:none");
                //}

                //this.div_CON.Attributes.Add("style", "display:block");
                this.div_ArtworkNew.Attributes.Add("style", "display:block");
                this.div_ProofNew.Attributes.Add("style", "display:block");
                this.div_ApprovalNew.Attributes.Add("style", "display:block");
                this.divProductionDate.Attributes.Add("style", "display:block");
                this.divJobCompletionDate.Attributes.Add("style", "display:block");
                this.div_deliverydate.Attributes.Add("style", "display:block");
                this.div_ClearDates.Attributes.Add("style", "display:block");

            }
            string empty = string.Empty;
            DataTable dataTable3 = EstimatesBasePage.Select_Prompt_Archive(this.CompanyID, this.Event);
            if (dataTable3.Rows.Count > 0)
            {
                this.IsArchive = dataTable3.Rows[0]["IsArchive"].ToString().ToLower();
            }
            if (!base.IsPostBack)
            {
                this.Event = "Estimate_Progress_to_job";
                DataTable dataTable4 = EstimatesBasePage.Select_Prompt_Archive(this.CompanyID, this.Event);
                if (dataTable4.Rows.Count > 0)
                {
                    if (dataTable4.Rows[0]["IsArchive"].ToString().ToLower() != "true")
                    {
                        this.rdb_Generate_Job_archive_the_Estimate.Checked = false;
                        this.rdb_Generate_Job_keep_the_Estimate_live.Checked = true;
                    }
                    else
                    {
                        this.rdb_Generate_Job_archive_the_Estimate.Checked = true;
                        this.rdb_Generate_Job_keep_the_Estimate_live.Checked = false;
                    }
                }
            }
            if (this.Module != "order")
            {
                this.rdb_Generate_Job_archive_the_Estimate.Text = this.objLanguage.GetLanguageConversion("Generate_Job_and_archive_the_Estimate");
                this.rdb_Generate_Job_keep_the_Estimate_live.Text = this.objLanguage.GetLanguageConversion("Generate_Job_and_keep_the_Estimate_live");
            }
            else
            {
                this.rdb_Generate_Job_archive_the_Estimate.Text = this.objLanguage.GetLanguageConversion("Generate_Job_and_archive_the_Order");
                this.rdb_Generate_Job_keep_the_Estimate_live.Text = this.objLanguage.GetLanguageConversion("Generate_Job_and_keep_the_Order_live");
            }
            this.divProgressToJob_style = "display:block";
            //if (dataTable2.Rows.Count != 0)
            //{
            //    this.divEstItemsList_Style = "display: none";
            //    if (this.IsArchive != "true")
            //    {
            //        this.divIsArchive_Style = "display: none";
            //        this.divIsArchivePrompt_style = "display:none";
            //        this.divdates_Style = "display:none";
            //        ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:Promt_For_Archive();", true);
            //        this.divEstItemsList_Style = "margin-left: -5px;";
            //    }
            //    else
            //    {
            //        this.divIsArchive_Style = "";
            //        this.divIsArchivePrompt_style = "";
            //        this.divdates_Style = "display: none";
            //        this.divProgressToJob_style = "";
            //    }
            //}
            //else
            //{
            if (this.Module == "order")
            {
                this.rdb_Generate_Job_archive_the_Estimate.Text = this.objLanguage.GetLanguageConversion("Generate_Job_and_archive_the_Order_Item");
                this.rdb_Generate_Job_keep_the_Estimate_live.Text = this.objLanguage.GetLanguageConversion("Generate_Job_and_keep_the_Order_Item_live");
            }
            if (this.Module == "estimate")
            {
                this.rdb_Generate_Job_archive_the_Estimate.Text = this.objLanguage.GetLanguageConversion("Generate_Job_and_archive_the_Estimate_Item");
                this.rdb_Generate_Job_keep_the_Estimate_live.Text = this.objLanguage.GetLanguageConversion("Generate_Job_and_keep_the_Estimate_Item_live");
            }
            this.divEstItemsList_Style = "margin-left: -5px;";
            this.divIsArchive_Style = "display: none";
            this.divIsArchivePrompt_style = "display: none";
            this.divdates_Style = "display: block";
            //if (this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal"))
            //{
            //    if (this.IsArchive != "true")
            //    {
            //        this.divIsArchive_Style = "display: none";
            //        this.divIsArchivePrompt_style = "display:none";
            //        this.divdates_Style = "display:none";
            //        ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:Promt_For_Archive();", true);
            //    }
            //    else
            //    {
            //        this.divIsArchive_Style = "";
            //        this.divIsArchivePrompt_style = "";
            //        this.divdates_Style = "display: none";
            //        this.divProgressToJob_style = "";
            //        this.divEstItemsList_Style = "display: none";
            //    }
            //}
            this.plhEstItemsList.Controls.Add(new LiteralControl("<div id='divEstItemsList_Inner' style='overflow-y: auto; word-break: break-all; max-height: 160px; height: auto; padding-left: 2px;'>"));
            //}
            int num = 0;
            //DataTable dataTable5 = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstimateID, this.Pgtype);
            string str = "no";
            int num1 = 0;
            //foreach (DataRow dataRow1 in dataTable5.Rows)
            //{
            //    if (dataRow1["JOBID"] != null && !(dataRow1["JOBID"].ToString() == "") && !(dataRow1["JOBID"].ToString() == "0"))
            //    {
            //        continue;
            //    }
            //    num1++;
            //    if (num1 <= 1)
            //    {
            //        continue;
            //    }
            //    str = "yes";
            //    break;
            //}
            //foreach (DataRow row2 in dataTable5.Rows)
            //{
            //    this.get_estimateitemqty_count = row2["QtyCount"].ToString();
            //    item_summary_progress_to_job usercontrolItemItemSummaryProgressToJob = this;
            //    usercontrolItemItemSummaryProgressToJob.get_estimateitemqty_count_multipleitems = string.Concat(usercontrolItemItemSummaryProgressToJob.get_estimateitemqty_count_multipleitems, row2["QtyCount"].ToString());
            //    item_summary_progress_to_job usercontrolItemItemSummaryProgressToJob1 = this;
            //    usercontrolItemItemSummaryProgressToJob1.get_all_estimateitemid = string.Concat(usercontrolItemItemSummaryProgressToJob1.get_all_estimateitemid, row2["EstimateItemID"].ToString(), ",");
            //    int num2 = Convert.ToInt32(row2["ApproveStatus"]);
            //    this.hdn_estimatetypeinv.Value = row2["EstimateType"].ToString();
            //    item_summary_progress_to_job usercontrolItemItemSummaryProgressToJob2 = this;
            //    string str1 = usercontrolItemItemSummaryProgressToJob2.getqtynumberwithitemids;
            //    string[] strArrays = new string[] { str1, row2["EstimateItemID"].ToString(), ",", row2["QtyCount"].ToString(), "»" };
            //    usercontrolItemItemSummaryProgressToJob2.getqtynumberwithitemids = string.Concat(strArrays);
            //    if (num2 != 1)
            //    {
            //        continue;
            //    }
            //    long num3 = Convert.ToInt64(row2["EstimateItemID"]);
            //    this.Item_EstimateType = row2["EstimateType"].ToString();
            //    string str2 = row2["ItemTitle"].ToString().Replace("\r\n", "<br/>").Replace("<br/>", " - ");
            //    string str3 = row2["EstimateItemNumber"].ToString();
            //    if (this.Module == "order")
            //    {
            //        str3 = row2["OrderItemNumber"].ToString();
            //    }
            //    if (Convert.ToInt32(row2["QtyCount"]) <= 1 || !(row2["JOBID"].ToString() == "0"))
            //    {
            //        HiddenField hidRemainingItems = this.hid_Remaining_Items;
            //        value = new object[] { this.hid_Remaining_Items.Value, num3, "»", this.Item_EstimateType, "»1»", str2, "±" };
            //        hidRemainingItems.Value = string.Concat(value);
            //    }
            //    else
            //    {
            //        HiddenField hidSelectedItems = this.hid_Selected_Items;
            //        value = new object[] { this.hid_Selected_Items.Value, num3, "»", this.Item_EstimateType, "»", str2, "±" };
            //        hidSelectedItems.Value = string.Concat(value);
            //        HiddenField hidSelectedItemsP2JClck = this.hid_Selected_Items_P2J_Clck;
            //        value = new object[] { this.hid_Selected_Items_P2J_Clck.Value, num3, "»", this.Item_EstimateType, "»", str2, "±" };
            //        hidSelectedItemsP2JClck.Value = string.Concat(value);
            //    }
            //    num++;
            //    item_summary_progress_to_job usercontrolItemItemSummaryProgressToJob3 = this;
            //    object getRemainingitemshdn = usercontrolItemItemSummaryProgressToJob3.get_remainingitemshdn;
            //    value = new object[] { getRemainingitemshdn, num3, "»", this.Item_EstimateType, "»1»", str2, "±" };
            //    usercontrolItemItemSummaryProgressToJob3.get_remainingitemshdn = string.Concat(value);
            //    if (!base.IsPostBack && Convert.ToInt64(row2["JOBID"]) == (long)0)
            //    {
            //        bool flag = false;
            //        foreach (DataRow dataRow2 in EstimatesBasePage.estimate_subitem_select_New(num3).Rows)
            //        {
            //            HiddenField hiddenField = this.hdnSubItemsIDs;
            //            value = new object[] { this.hdnSubItemsIDs.Value, dataRow2["EstimateItemID"].ToString(), "»", dataRow2["EstimateType"].ToString(), "»", dataRow2["QtyCount"], "▲" };
            //            hiddenField.Value = string.Concat(value);
            //            if (dataRow2["EstimateType"].ToString().ToLower() != "u")
            //            {
            //                continue;
            //            }
            //            flag = true;
            //        }
            //        HiddenField hiddenField1 = this.hdnEstItemsSelected;
            //        value = new object[] { this.hdnEstItemsSelected.Value, num3, "»", this.Item_EstimateType, "»", str2, "±" };
            //        hiddenField1.Value = string.Concat(value);
            //        HiddenField hdnEstItemsSelectedP2J = this.hdnEstItemsSelected_P2J;
            //        value = new object[] { this.hdnEstItemsSelected_P2J.Value, num3, "»", this.Item_EstimateType, "»", str2, "±" };
            //        hdnEstItemsSelectedP2J.Value = string.Concat(value);
            //        this.hdnEstItems.Value = string.Concat(this.hdnEstItems.Value, num3, "»");
            //        if (flag)
            //        {
            //            DataSet dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num3, 1, this.Item_EstimateType);
            //            if (dataSet.Tables[9].Rows.Count > 0)
            //            {
            //                foreach (DataRow row3 in dataSet.Tables[9].Rows)
            //                {
            //                    this.hdnSubItemsIDs_OtherCost.Value = string.Concat(this.hdnSubItemsIDs_OtherCost.Value, row3["estothercostid"].ToString(), "▲");
            //                }
            //            }
            //        }
            //    }
            //    if (Convert.ToInt64(row2["JOBID"]) == (long)0 && dataTable2.Rows.Count == 0 && !this.PaymentType.Contains("Braintree") && !this.PaymentType.Contains("Paypal") && str == "yes")
            //    {
            //        ControlCollection controls = this.plhEstItemsList.Controls;
            //        value = new object[] { "<div style='padding: 0px 5px 6px 0px; float: left;'><input style='cursor: pointer;' type='checkbox' id='chkEstItems_", num3, "' title='", str2, "' checked='checked' value='", num3, "' /></div>" };
            //        controls.Add(new LiteralControl(string.Concat(value)));
            //        ControlCollection controlCollections = this.plhEstItemsList.Controls;
            //        strArrays = new string[] { "<div style='padding-top: 3px;'>", str3, "&nbsp;&nbsp;", this.objBase.SpecialDecode(str2), "</div>" };
            //        controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
            //        this.plhEstItemsList.Controls.Add(new LiteralControl("<div style='clear: both;'></div>"));
            //    }
            //    if (Convert.ToInt64(row2["JOBID"]) != (long)0)
            //    {
            //        continue;
            //    }
            //    item_summary_progress_to_job remainingItemCnt = this;
            //    remainingItemCnt.RemainingItemCnt = remainingItemCnt.RemainingItemCnt + 1;
            //}
            //if (this.RemainingItemCnt > 0)
            //{
            //    this.plhEstItemsList.Controls.Add(new LiteralControl("</div>"));
            //    if (!this.PaymentType.Contains("Braintree") && !this.PaymentType.Contains("Paypal") && dataTable2.Rows.Count == 0 && this.RemainingItemCnt > 1)
            //    {
            //        this.plhEstItemsList.Controls.Add(new LiteralControl("<div style='padding-top: 5px; float: left; padding-left: 4px;'><input type='submit' id='btnEstItems_Next' value='Next' class='button' onclick='javascript:EstItemListNext();return false;'/></div>"));
            //    }
            //    if (this.RemainingItemCnt == 1)
            //    {
            //        if (this.IsArchive != "true")
            //        {
            //            this.divIsArchive_Style = "display: none";
            //            this.divIsArchivePrompt_style = "display:none";
            //            this.divdates_Style = "display:none";
            //            ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:Promt_For_Archive();", true);
            //        }
            //        else
            //        {
            //            this.divIsArchive_Style = "";
            //            this.divIsArchivePrompt_style = "";
            //            this.divdates_Style = "display: none";
            //            this.divProgressToJob_style = "";
            //        }
            //    }
            //}
            if (this.RemainingItemCnt == 0)
            {
                this.estimateconvertedtojob = "True";
            }
            foreach (DataRow row2 in SettingsBasePage.Get_Estimate_DefaulSetting(this.CompanyID).Rows)
            {
                this.WorkingDaysFrom = Convert.ToInt32(row2["WorkingDaysFrom"]);
                this.WorkingDaysTo = Convert.ToInt32(row2["WorkingDaysTo"]);
                this.DefaultCustomDate1 = String.IsNullOrEmpty(row2["DefaultCustomDate1"].ToString()) ? "" : row2["DefaultCustomDate1"].ToString();
                this.DefaultCustomDate2 = String.IsNullOrEmpty(row2["DefaultCustomDate2"].ToString()) ? "" : row2["DefaultCustomDate2"].ToString();
                this.DefaultCustomDate3 = String.IsNullOrEmpty(row2["DefaultCustomDate3"].ToString()) ? "" : row2["DefaultCustomDate3"].ToString();
                this.DefaultCustomDate4 = String.IsNullOrEmpty(row2["DefaultCustomDate4"].ToString()) ? "" : row2["DefaultCustomDate4"].ToString();
                this.DefaultCustomDate5 = String.IsNullOrEmpty(row2["DefaultCustomDate5"].ToString()) ? "" : row2["DefaultCustomDate5"].ToString();
            }

            foreach (DataRow dataRow3 in EstimateBasePage.Estimate_Select_By_EstimateID_New(this.CompanyID, this.EstimateID).Rows)
            {
                this.txtartworkdate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow3["EstimatedArtwork"].ToString(), this.CompanyID, this.UserID, false);
                this.txtproofdate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow3["EstProofDate"].ToString(), this.CompanyID, this.UserID, false);
                this.txtapprovaldate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow3["EstApprovalDate"].ToString(), this.CompanyID, this.UserID, false);
                this.txtproductiondate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow3["EstProductionDate"].ToString(), this.CompanyID, this.UserID, false);
                this.txtcompletiondate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow3["EstCompletionDate"].ToString(), this.CompanyID, this.UserID, false);
                this.txtdeliverydate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow3["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                this.txtcustdate1.Text = !String.IsNullOrEmpty(dataRow3["CustomDate1"].ToString()) ? this.commclass.Eprint_return_Date_Before_View(dataRow3["CustomDate1"].ToString(), this.CompanyID, this.UserID, false) : this.txtcustdate1.Text;
                this.txtcustdate2.Text = !String.IsNullOrEmpty(dataRow3["CustomDate2"].ToString()) ? this.commclass.Eprint_return_Date_Before_View(dataRow3["CustomDate2"].ToString(), this.CompanyID, this.UserID, false) : this.txtcustdate2.Text;
                this.txtcustdate3.Text = !String.IsNullOrEmpty(dataRow3["CustomDate3"].ToString()) ? this.commclass.Eprint_return_Date_Before_View(dataRow3["CustomDate3"].ToString(), this.CompanyID, this.UserID, false) : this.txtcustdate3.Text;
                this.txtcustdate4.Text = !String.IsNullOrEmpty(dataRow3["CustomDate4"].ToString()) ? this.commclass.Eprint_return_Date_Before_View(dataRow3["CustomDate4"].ToString(), this.CompanyID, this.UserID, false) : this.txtcustdate4.Text;
                this.txtcustdate5.Text = !String.IsNullOrEmpty(dataRow3["CustomDate5"].ToString()) ? this.commclass.Eprint_return_Date_Before_View(dataRow3["CustomDate5"].ToString(), this.CompanyID, this.UserID, false) : this.txtcustdate5.Text;

            }
            this.txtproofdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtcompletiondate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtdeliverydate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtapprovaldate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtartworkdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtproductiondate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtdemo_date.Attributes.Add("onload", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtdemo_date.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtcustdate1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtcustdate2.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtcustdate3.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtcustdate4.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtcustdate5.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));

            DateTime now = DateTime.Now;
            TextBox textBox7 = this.txtcustdate1;
            commonClass _commonClass18 = this.objComn;
            if (!string.IsNullOrEmpty(this.DefaultCustomDate1))
            {
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate1));
                textBox7.Text = _commonClass18.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            }
            else
            {
                textBox7.Text = "";
            }
            TextBox textBox8 = this.txtcustdate2;
            commonClass _commonClass19 = this.objComn;
            if (!string.IsNullOrEmpty(this.DefaultCustomDate2))
            {
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate2));
                textBox8.Text = _commonClass19.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            }
            else
            {
                textBox8.Text = "";
            }
            TextBox textBox9 = this.txtcustdate3;
            commonClass _commonClass20 = this.objComn;
            if (!string.IsNullOrEmpty(this.DefaultCustomDate3))
            {
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate3));
                textBox9.Text = _commonClass20.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            }
            else
            {
                textBox9.Text = "";
            }
            TextBox textBox10 = this.txtcustdate4;
            commonClass _commonClass21 = this.objComn;
            if (!string.IsNullOrEmpty(this.DefaultCustomDate4))
            {
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate4));
                textBox10.Text = _commonClass21.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            }
            else
            {
                textBox10.Text = "";
            }
            TextBox textBox11 = this.txtcustdate5;
            commonClass _commonClass22 = this.objComn;
            if (!string.IsNullOrEmpty(this.DefaultCustomDate5))
            {
                now = this.ReturnWeekDate(DateTime.Now, this.WorkingDaysFrom, this.WorkingDaysTo, Convert.ToInt32(this.DefaultCustomDate5));
                textBox11.Text = _commonClass22.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            }
            else
            {
                textBox11.Text = "";
            }

            TextBox txtdemoDate = this.txtdemo_date;
            commonClass _commonClass = this.commclass;
            string dateFormat = this.DateFormat;
            commonClass _commonClass1 = this.commclass;
            now = DateTime.Now;
            txtdemoDate.Text = _commonClass.date_Check_new(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false), this.CompanyID);
            commonClass _commonClass2 = this.commclass;
            string dateFormat1 = this.DateFormat;
            commonClass _commonClass3 = this.commclass;
            now = DateTime.Now;
            this.Jobconvertedate = _commonClass2.date_Check_new(dateFormat1, _commonClass3.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
            commonClass _commonClass4 = this.commclass;
            string dateFormat2 = this.DateFormat;
            commonClass _commonClass5 = this.commclass;
            now = DateTime.Now;
            this.strcreateddate = _commonClass4.date_Check_new(dateFormat2, _commonClass5.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
            now = DateTime.Now;
            this.CreatedDate = P2JClampSqlDate(this.commclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            this.TodayDate = P2JParseDate(this.strcreateddate);
            this.JobConDate = P2JParseDate(this.Jobconvertedate);




            //if (this.RemainingItemCnt == 1 && !base.IsPostBack || dataTable2.Rows.Count > 0 && !base.IsPostBack)
            //{
            //    long num4 = (long)0;
            //    DataTable dataTable6 = EstimatesBasePage.estimate_itemandsubitem_select(this.EstimateID);
            //    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //    this.plhRaisePO.Controls.Add(new LiteralControl("<div class='bgLabel'>"));
            //    this.plhRaisePO.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Raise_Purchase_Order") ?? ""));
            //    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //    this.plhRaisePO.Controls.Add(new LiteralControl("<div class='raisepoplcholder' style='word-break: break-all;'>"));
            //    foreach (DataRow row4 in dataTable6.Rows)
            //    {
            //        if (Convert.ToInt32(row4["ApproveStatus"]) != 1 || !Convert.ToBoolean(row4["isparentitem"]) || Convert.ToInt64(row4["JobID"]) != (long)0)
            //        {
            //            continue;
            //        }
            //        long num5 = Convert.ToInt64(row4["EstimateItemID"]);
            //        string str4 = row4["Estimatetype"].ToString();
            //        string str5 = this.objBC.SpecialDecode(row4["EstimateItemTitle"].ToString().Replace("<br/>", " - "));
            //        DataSet dataSet1 = new DataSet();
            //        if (string.Compare(str4, "S", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            string str6 = "";
            //            checkBox.Text = string.Concat(str5, str6);
            //            checkBox.ToolTip = string.Concat(str5, str6);
            //            if (checkBox.Text.Length > 42)
            //            {
            //                checkBox.Text = string.Concat(checkBox.Text.Substring(0, 42), "..");
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num6 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value1 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays1 = value1.Split(chrArray);
            //                for (int i = 0; i < (int)strArrays1.Length; i++)
            //                {
            //                    if (strArrays1[0].Contains(num5.ToString()))
            //                    {
            //                        string str7 = strArrays1[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays2 = str7.Split(chrArray);
            //                        num6 = Convert.ToInt32(strArrays2[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num6);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "P", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox1 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            string str8 = "";
            //            checkBox1.Text = string.Concat(str5, str8);
            //            checkBox1.ToolTip = string.Concat(str5, str8);
            //            if (checkBox1.Text.Length > 42)
            //            {
            //                checkBox1.Text = string.Concat(checkBox1.Text.Substring(0, 42), "..");
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox1);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num7 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value2 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays3 = value2.Split(chrArray);
            //                for (int j = 0; j < (int)strArrays3.Length; j++)
            //                {
            //                    if (strArrays3[0].Contains(num5.ToString()))
            //                    {
            //                        string str9 = strArrays3[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays4 = str9.Split(chrArray);
            //                        num7 = Convert.ToInt32(strArrays4[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num7);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "L", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div style='margin-left:2%;'>"));
            //            this.plhRaisePO.Controls.Add(new LiteralControl(str5));
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num8 = 0;
            //            string empty1 = string.Empty;
            //            foreach (DataRow dataRow4 in EstimatesBasePage.Materials_select_ForPOCreate(num5).Rows)
            //            {
            //                value = new object[] { empty1, dataRow4["MaterialID"], "_", num8, "▼" };
            //                empty1 = string.Concat(value);
            //                this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //                CheckBox isDefaultPO = new CheckBox();
            //                value = new object[] { "chkRaisePO_", dataRow4["EstimateItemID"], "_", dataRow4["MaterialID"], "_", num8 };
            //                isDefaultPO.ID = string.Concat(value);
            //                isDefaultPO.Checked = this.IsDefaultPO;
            //                isDefaultPO.Text = dataRow4["MaterialName"].ToString();
            //                string str10 = "";
            //                isDefaultPO.Text = string.Concat(str5, str10);
            //                isDefaultPO.ToolTip = string.Concat(str5, str10);
            //                if (isDefaultPO.Text.Length > 42)
            //                {
            //                    isDefaultPO.Text = string.Concat(isDefaultPO.Text.Substring(0, 42), "..");
            //                }
            //                this.plhRaisePO.Controls.Add(isDefaultPO);
            //                this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //                num8++;
            //            }
            //            ControlCollection controls1 = this.plhRaisePO.Controls;
            //            value = new object[] { "<label id='lblMaterialIds_", num5, "' style='display: none;'>", empty1, "</label>" };
            //            controls1.Add(new LiteralControl(string.Concat(value)));
            //            int num9 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value3 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays5 = value3.Split(chrArray);
            //                for (int k = 0; k < (int)strArrays5.Length; k++)
            //                {
            //                    if (strArrays5[0].Contains(num5.ToString()))
            //                    {
            //                        string str11 = strArrays5[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays6 = str11.Split(chrArray);
            //                        num9 = Convert.ToInt32(strArrays6[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num9);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "B", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox2 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            string str12 = "";
            //            checkBox2.Text = string.Concat(str5, str12);
            //            checkBox2.ToolTip = string.Concat(str5, str12);
            //            if (checkBox2.Text.Length > 42)
            //            {
            //                checkBox2.Text = string.Concat(checkBox2.Text.Substring(0, 42), "..");
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox2);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num10 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value4 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays7 = value4.Split(chrArray);
            //                for (int l = 0; l < (int)strArrays7.Length; l++)
            //                {
            //                    if (strArrays7[0].Contains(num5.ToString()))
            //                    {
            //                        string str13 = strArrays7[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays8 = str13.Split(chrArray);
            //                        num10 = Convert.ToInt32(strArrays8[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num10);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "O", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox3 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            Label label = new Label();
            //            string value5 = this.hdn_getselected_supplier.Value;
            //            string value6 = this.hid_Progress_Items.Value;
            //            chrArray = new char[] { '±' };
            //            string[] strArrays9 = value6.Split(chrArray);
            //            string[] strArrays10 = null;
            //            num4 = num5;
            //            int num11 = 1;
            //            while (num11 < (int)strArrays9.Length)
            //            {
            //                if (!strArrays9[num11 - 1].Contains("O") || !strArrays9[num11 - 1].Contains(num5.ToString()))
            //                {
            //                    num11++;
            //                }
            //                else
            //                {
            //                    string str14 = strArrays9[num11 - 1];
            //                    chrArray = new char[] { '»' };
            //                    strArrays10 = str14.Split(chrArray);
            //                    break;
            //                }
            //            }
            //            if (strArrays10 != null)
            //            {
            //                if (strArrays10.Contains<string>("O"))
            //                {
            //                    value5 = strArrays10[2];
            //                }
            //                item_summary_progress_to_job usercontrolItemItemSummaryProgressToJob4 = this;
            //                usercontrolItemItemSummaryProgressToJob4.l = usercontrolItemItemSummaryProgressToJob4.l + 1;
            //            }
            //            if (strArrays10 == null && !this.hid_Progress_Items.Value.Contains(num5.ToString()))
            //            {
            //                label.Text = string.Concat("  (", row4["SupplierName"].ToString(), " )");
            //            }
            //            string value7 = this.hdn_suppliername1.Value;
            //            chrArray = new char[] { ',' };
            //            string[] strArrays11 = value7.Split(chrArray);
            //            string value8 = this.hdn_suppliername2.Value;
            //            chrArray = new char[] { ',' };
            //            string[] strArrays12 = value8.Split(chrArray);
            //            string value9 = this.hdn_suppliername3.Value;
            //            chrArray = new char[] { ',' };
            //            string[] strArrays13 = value9.Split(chrArray);
            //            string value10 = this.hdn_suppliername4.Value;
            //            chrArray = new char[] { ',' };
            //            string[] strArrays14 = value10.Split(chrArray);
            //            if (value5 == "1")
            //            {
            //                label.Text = string.Concat("  (", strArrays11[this.l - 1], " )");
            //            }
            //            if (value5 == "2")
            //            {
            //                label.Text = string.Concat("  (", strArrays12[this.l - 1], " )");
            //            }
            //            if (value5 == "3")
            //            {
            //                label.Text = string.Concat("  (", strArrays13[this.l - 1], " )");
            //            }
            //            if (value5 == "4")
            //            {
            //                label.Text = string.Concat("  (", strArrays14[this.l - 1], " )");
            //            }
            //            string str15 = string.Concat(str5, label.Text);
            //            checkBox3.ToolTip = str15;
            //            checkBox3.Text = string.Concat(str5, label.Text);
            //            if (str15.Length <= 47)
            //            {
            //                checkBox3.Text = string.Concat(str5, label.Text);
            //            }
            //            else
            //            {
            //                checkBox3.Text = checkBox3.Text.Substring(0, 47);
            //            }
            //            label.Text = this.objBC.SpecialDecode(label.Text);
            //            this.plhRaisePO.Controls.Add(checkBox3);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num12 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value11 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays15 = value11.Split(chrArray);
            //                for (int m = 0; m < (int)strArrays15.Length; m++)
            //                {
            //                    if (strArrays15[0].Contains(num5.ToString()))
            //                    {
            //                        string str16 = strArrays15[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays16 = str16.Split(chrArray);
            //                        num12 = Convert.ToInt32(strArrays16[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num12);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "C", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox4 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            Label label1 = new Label();
            //            string str17 = row4["SupplierName"].ToString();
            //            if (str17 != "")
            //            {
            //                label1.Text = string.Concat("  (", str17, ")");
            //            }
            //            label1.Text = this.objBC.SpecialDecode(label1.Text);
            //            string str18 = string.Concat(str5, label1.Text);
            //            checkBox4.ToolTip = str18;
            //            if (str18.Length <= 47)
            //            {
            //                checkBox4.Text = str18;
            //            }
            //            else
            //            {
            //                checkBox4.Text = str18.Substring(0, 47);
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox4);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            foreach (DataRow row5 in EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(num5).Rows)
            //            {
            //                this.plhRaisePO.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
            //                CheckBox isDefaultPO1 = new CheckBox();
            //                value = new object[] { "chkRaisePO_PrAdIt_", num5, "_", row5["EstimateAdditionalItemID"].ToString() };
            //                isDefaultPO1.ID = string.Concat(value);
            //                isDefaultPO1.Checked = this.IsDefaultPO;
            //                isDefaultPO1.Text = this.objBC.SpecialDecode(row5["EstimateOtherCostName"].ToString());
            //                this.plhRaisePO.Controls.Add(isDefaultPO1);
            //                this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //                HiddenField hiddenField2 = this.hdnProductAddItemsIDs;
            //                value = new object[] { this.hdnProductAddItemsIDs.Value, num5, "_", row5["EstimateAdditionalItemID"].ToString(), "±" };
            //                hiddenField2.Value = string.Concat(value);
            //            }
            //            int num13 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value12 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays17 = value12.Split(chrArray);
            //                for (int n = 0; n < (int)strArrays17.Length; n++)
            //                {
            //                    if (strArrays17[0].Contains(num5.ToString()))
            //                    {
            //                        string str19 = strArrays17[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays18 = str19.Split(chrArray);
            //                        num13 = Convert.ToInt32(strArrays18[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num13);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "X", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox5 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            this.plhRaisePO.Controls.Add(checkBox5);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            foreach (DataRow dataRow5 in EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(num5).Rows)
            //            {
            //                this.plhRaisePO.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
            //                CheckBox isDefaultPO2 = new CheckBox();
            //                value = new object[] { "chkRaisePO_PrAdIt_", num5, "_", dataRow5["EstimateAdditionalItemID"].ToString() };
            //                isDefaultPO2.ID = string.Concat(value);
            //                isDefaultPO2.Checked = this.IsDefaultPO;
            //                isDefaultPO2.Text = this.objBC.SpecialDecode(dataRow5["EstimateOtherCostName"].ToString());
            //                this.plhRaisePO.Controls.Add(isDefaultPO2);
            //                this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //                HiddenField hiddenField3 = this.hdnProductAddItemsIDs;
            //                value = new object[] { this.hdnProductAddItemsIDs.Value, num5, "_", dataRow5["EstimateAdditionalItemID"].ToString(), "±" };
            //                hiddenField3.Value = string.Concat(value);
            //            }
            //            int num14 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value13 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays19 = value13.Split(chrArray);
            //                for (int o = 0; o < (int)strArrays19.Length; o++)
            //                {
            //                    if (strArrays19[0].Contains(num5.ToString()))
            //                    {
            //                        string str20 = strArrays19[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays20 = str20.Split(chrArray);
            //                        num14 = Convert.ToInt32(strArrays20[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num14);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "W", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox6 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            Label label2 = new Label();
            //            string str21 = row4["SupplierName"].ToString();
            //            string str22 = "";
            //            if (str21 != "")
            //            {
            //                label2.Text = string.Concat("  (", str21, ")");
            //            }
            //            str22 = string.Concat(str5, label2.Text);
            //            checkBox6.ToolTip = str22;
            //            label2.Text = this.objBC.SpecialDecode(label2.Text);
            //            if (str22.Length <= 47)
            //            {
            //                checkBox6.Text = str22;
            //            }
            //            else
            //            {
            //                checkBox6.Text = str22.Substring(0, 47);
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox6);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num15 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value14 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays21 = value14.Split(chrArray);
            //                for (int p = 0; p < (int)strArrays21.Length; p++)
            //                {
            //                    if (strArrays21[0].Contains(num5.ToString()))
            //                    {
            //                        string str23 = strArrays21[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays22 = str23.Split(chrArray);
            //                        num15 = Convert.ToInt32(strArrays22[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num15);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "F", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox7 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            string str24 = "";
            //            checkBox7.Text = string.Concat(str5, str24);
            //            checkBox7.ToolTip = string.Concat(str5, str24);
            //            if (checkBox7.Text.Length > 42)
            //            {
            //                checkBox7.Text = string.Concat(checkBox7.Text.Substring(0, 42), "..");
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox7);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num16 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value15 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays23 = value15.Split(chrArray);
            //                for (int q = 0; q < (int)strArrays23.Length; q++)
            //                {
            //                    if (strArrays23[0].Contains(num5.ToString()))
            //                    {
            //                        string str25 = strArrays23[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays24 = str25.Split(chrArray);
            //                        num16 = Convert.ToInt32(strArrays24[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num16);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "D", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox8 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            string str26 = "";
            //            checkBox8.Text = string.Concat(str5, str26);
            //            checkBox8.ToolTip = string.Concat(str5, str26);
            //            if (checkBox8.Text.Length > 42)
            //            {
            //                checkBox8.Text = string.Concat(checkBox8.Text.Substring(0, 42), "..");
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox8);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num17 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value16 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays25 = value16.Split(chrArray);
            //                for (int r = 0; r < (int)strArrays25.Length; r++)
            //                {
            //                    if (strArrays25[0].Contains(num5.ToString()))
            //                    {
            //                        string str27 = strArrays25[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays26 = str27.Split(chrArray);
            //                        num17 = Convert.ToInt32(strArrays26[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num17);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "N", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox9 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            string str28 = "";
            //            checkBox9.Text = string.Concat(str5, str28);
            //            checkBox9.ToolTip = string.Concat(str5, str28);
            //            if (checkBox9.Text.Length > 42)
            //            {
            //                checkBox9.Text = string.Concat(checkBox9.Text.Substring(0, 42), "..");
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox9);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num18 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value17 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays27 = value17.Split(chrArray);
            //                for (int s = 0; s < (int)strArrays27.Length; s++)
            //                {
            //                    if (strArrays27[0].Contains(num5.ToString()))
            //                    {
            //                        string str29 = strArrays27[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays28 = str29.Split(chrArray);
            //                        num18 = Convert.ToInt32(strArrays28[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num18);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "K", true) == 0)
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox10 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            string str30 = "";
            //            checkBox10.Text = string.Concat(str5, str30);
            //            checkBox10.ToolTip = string.Concat(str5, str30);
            //            if (checkBox10.Text.Length > 42)
            //            {
            //                checkBox10.Text = string.Concat(checkBox10.Text.Substring(0, 42), "..");
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox10);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num19 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value18 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays29 = value18.Split(chrArray);
            //                for (int t = 0; t < (int)strArrays29.Length; t++)
            //                {
            //                    if (strArrays29[0].Contains(num5.ToString()))
            //                    {
            //                        string str31 = strArrays29[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays30 = str31.Split(chrArray);
            //                        num19 = Convert.ToInt32(strArrays30[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num19);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else if (string.Compare(str4, "Q", true) != 0)
            //        {
            //            if (string.Compare(str4, "u", true) != 0)
            //            {
            //                continue;
            //            }
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox11 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            string str32 = "";
            //            checkBox11.Text = string.Concat(str5, str32);
            //            checkBox11.ToolTip = string.Concat(str5, str32);
            //            if (checkBox11.Text.Length > 42)
            //            {
            //                checkBox11.Text = string.Concat(checkBox11.Text.Substring(0, 42), "..");
            //            }
            //            this.plhRaisePO.Controls.Add(checkBox11);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num20 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value19 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays31 = value19.Split(chrArray);
            //                for (int u = 0; u < (int)strArrays31.Length; u++)
            //                {
            //                    if (strArrays31[0].Contains(num5.ToString()))
            //                    {
            //                        string str33 = strArrays31[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays32 = str33.Split(chrArray);
            //                        num20 = Convert.ToInt32(strArrays32[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num20);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //        else
            //        {
            //            this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
            //            CheckBox checkBox12 = new CheckBox()
            //            {
            //                ID = string.Concat("chkRaisePO_", num5),
            //                Checked = this.IsDefaultPO,
            //                Text = str5
            //            };
            //            this.plhRaisePO.Controls.Add(checkBox12);
            //            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //            int num21 = 0;
            //            if (this.hid_Progress_Items.Value != "")
            //            {
            //                string value20 = this.hid_Progress_Items.Value;
            //                chrArray = new char[] { '±' };
            //                string[] strArrays33 = value20.Split(chrArray);
            //                for (int v = 0; v < (int)strArrays33.Length; v++)
            //                {
            //                    if (strArrays33[0].Contains(num5.ToString()))
            //                    {
            //                        string str34 = strArrays33[0];
            //                        chrArray = new char[] { '»' };
            //                        string[] strArrays34 = str34.Split(chrArray);
            //                        num21 = Convert.ToInt32(strArrays34[2]);
            //                    }
            //                }
            //            }
            //            dataSet1 = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num5, str4, num21);
            //            this.BindSubItems(dataSet1, this.plhRaisePO, this.IsDefaultPO);
            //        }
            //    }
            //    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            //}
            //if (this.IsArchive.ToLower() == "false" && this.RemainingItemCnt > 1 && (this.PaymentType.Contains("Braintree") || this.PaymentType.Contains("Paypal") || dataTable2.Rows.Count > 0))
            //{
            //    this.divdates_Style = "display: block";
            //}


            //start

            if (this.EstimateID != 0 && this.CompanyID != 0)
            {
                DataSet dataTablePO = PurchaseBasePage.selectPOfromJob(0, this.CompanyID, this.EstimateID);

                if (dataTablePO.Tables[1].Rows[0]["IsCombineItemfor_SameSupplier"].ToString() == "True")
                {
                    this.isCombine = "yes";
                    this.hdisCombinedPO.Value = "yes";
                    this.hdnIsPOPup.Value = "yes";
                    //this.pnlradiopurchase.Visible = true;
                    //enqform.Style.Add("display", "none");
                    this.pnlradiopurchase.Style.Add("display", "block");
                }
                else
                {
                    this.isCombine = "no";
                    this.hdisCombinedPO.Value = "no";
                    this.hdnIsPOPup.Value = "no";
                    this.pnlradiopurchase.Style.Add("display", "none");
                    //sthis.pnlradiopurchase.Visible = false;
                    //enqform.Style.Add("display", "none");
                }


                this.radioButtonList.DataValueField = "PurchaseID";
                this.radioButtonList.DataTextField = "PONO";
                this.radioButtonList.DataSource = dataTablePO;
                this.radioButtonList.DataBind();

                if (dataTablePO.Tables[0].Rows.Count > 0)
                {
                    this.radioButtonList.SelectedValue = dataTablePO.Tables[0].Rows[0]["PurchaseID"].ToString();
                }
                else
                {
                    this.isCombine = "no";
                    this.hdisCombinedPO.Value = "no";
                    //this.hdnIsPOPup.Value = "no";
                }
            }
            else
            {
                this.isCombine = "no";
                this.hdisCombinedPO.Value = "no";
                this.pnlradiopurchase.Style.Add("display", "none");
            }


        }

        private static readonly DateTime SqlMinDate = new DateTime(1753, 1, 1);
        private static readonly DateTime SqlMaxDate = new DateTime(9999, 12, 31, 23, 59, 59);

        private DateTime P2JClampSqlDate(DateTime value)
        {
            if (value < SqlMinDate)
            {
                return new DateTime(1900, 1, 1);
            }
            if (value > SqlMaxDate)
            {
                return SqlMaxDate;
            }
            return value;
        }

        private DateTime P2JParseDate(string dateValue, string dateFormat = null)
        {
            if (string.IsNullOrWhiteSpace(dateValue))
            {
                return new DateTime(1900, 1, 1);
            }
            string fmt = string.IsNullOrWhiteSpace(dateFormat) ? this.DateFormat : dateFormat;
            string normalized = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(fmt, dateValue.Trim());
            if (string.IsNullOrWhiteSpace(normalized))
            {
                return new DateTime(1900, 1, 1);
            }
            return P2JClampSqlDate(Convert.ToDateTime(normalized, CultureInfo.InvariantCulture));
        }

        private DateTime? P2JParseDateNullable(string dateValue, string dateFormat = null)
        {
            if (string.IsNullOrWhiteSpace(dateValue))
            {
                return null;
            }
            string fmt = string.IsNullOrWhiteSpace(dateFormat) ? this.DateFormat : dateFormat;
            string normalized = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(fmt, dateValue.Trim());
            if (string.IsNullOrWhiteSpace(normalized))
            {
                return null;
            }
            DateTime parsed = Convert.ToDateTime(normalized, CultureInfo.InvariantCulture);
            if (parsed.Year == 1900 && parsed.Month == 1 && parsed.Day == 1)
            {
                return null;
            }
            return parsed;
        }

        protected string Progress_to_Job()
        {

            

            string[] strArrays_ = this.hdn_OrderProgressToJob.Value.Split(new char[] { ',' });
            long num77 = 0;
            string empty7 = string.Empty;
            List<long> list = new List<long>();
            List<long> list_del = new List<long>();

            List<long> list_POs = new List<long>();
            for (int i_ = 0; i_ < (int)strArrays_.Length - 1; i_++)
            {
                #region CREATING JOBS

                


                string strArray = strArrays_[i_];
                char[] chrArray_ = new char[] { '\u005F' };
                string[] strArrays;
                int r;
                object[] item;
                string empty = string.Empty;
                bool flag = false;
                this.IsFromProgreesTojob = "yes";
                this.TodayDate = P2JParseDate(this.strcreateddate);
                if (this.CreatedDate.Year < 1753)
                {
                    this.CreatedDate = this.TodayDate;
                }

                long estimateID = (long)Convert.ToInt32(strArray.Split(chrArray_)[0].ToString());
                long orderID = (long)Convert.ToInt32(strArray.Split(chrArray_)[1].ToString());
                long estimateItemID = (long)Convert.ToInt32(strArray.Split(chrArray_)[2].ToString());
                
                this.EstimateID = estimateID;
                string estimateType = string.Empty;
                DataTable dataTable5 = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstimateID, "order");
                foreach (DataRow row2 in dataTable5.Rows)
                {
                    this.get_estimateitemqty_count = row2["QtyCount"].ToString();
                    estimateType = row2["EstimateType"].ToString();
                }


                if (radioButtonList.Items.Count > 0)
                {
                    poNum = Convert.ToInt64(this.radioButtonList.SelectedItem.Value);
                }

                
                if (this.hdn_Job_Archive.Value == "Archive")
                {
                    flag = true;
                }
                commonClass _commonClass = new commonClass();
                BaseClass baseClass = new BaseClass();
                if (this.chkprospectYes.Checked && this.EstimateID != (long)0 && this.CompanyID != 0)
                {
                    this.commclass.update_companytype(Convert.ToInt64(this.CompanyID), Convert.ToInt64(this.EstimateID), "customer");
                }
                this.objCom.settings_lastcounter_select(this.CompanyID, "j");
                string serverName = ConnectionClass.ServerName;
                string str = SettingsBasePage.eprint_numbering(this.CompanyID, "J", ConnectionClass.IsHandy);
                if (string.IsNullOrWhiteSpace(this.Jobconvertedate) || string.IsNullOrWhiteSpace(this.strcreateddate))
                {
                    DateTime nowInit = DateTime.Now;
                    this.Jobconvertedate = this.commclass.date_Check_new(this.DateFormat, this.commclass.Eprint_return_Date_Before_View(nowInit.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
                    this.strcreateddate = this.commclass.date_Check_new(this.DateFormat, this.commclass.Eprint_return_Date_Before_View(nowInit.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
                }
                this.TodayDate = P2JParseDate(this.strcreateddate);
                if (this.CreatedDate.Year < 1753)
                {
                    this.CreatedDate = this.TodayDate;
                }
                string str1 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtcompletiondate.Text), this.CompanyID);
                string str2 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtdeliverydate.Text), this.CompanyID);
                string str3 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtartworkdate.Text), this.CompanyID);
                string str4 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtapprovaldate.Text), this.CompanyID);
                string str5 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtproofdate.Text), this.CompanyID);
                string str6 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtproductiondate.Text), this.CompanyID);
                string str61 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtcustdate1.Text), this.CompanyID);
                string str62 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtcustdate2.Text), this.CompanyID);
                string str63 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtcustdate3.Text), this.CompanyID);
                string str64 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtcustdate4.Text), this.CompanyID);
                string str65 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtcustdate5.Text), this.CompanyID);

                if (!list.Contains(estimateID))
                {
                    this.JobID = JobBasePage.jobs_insert(this.CompanyID, this.EstimateID, str, P2JParseDate(this.Jobconvertedate), P2JParseDate(this.strcreateddate), P2JParseDate(str1), P2JParseDate(str2), Convert.ToInt32(base.Session["UserID"]), this.objBC.SpecialEncode(this.hid_TxtOrderNo.Value), P2JParseDate(str3), P2JParseDate(str4), P2JParseDate(str5), P2JParseDate(str6), false, 0, ConnectionClass.IsHandy, P2JParseDateNullable(str61), P2JParseDateNullable(str62), P2JParseDateNullable(str63), P2JParseDateNullable(str64), P2JParseDateNullable(str65));
                }
                base.Session["JobID"] = this.JobID.ToString();
                //string str7 = string.Concat(this.hid_Progress_Items.Value, this.hid_Remaining_Items.Value);
                SortedDictionary<long, string> nums = new SortedDictionary<long, string>();
                char[] chrArray = new char[] { '±' };
                //string[] strArrays1 = str7.Split(chrArray);

                string selected_value = this.hdnCombinedValue.Value.ToString();
                

                string value = this.hdnEstItemsSelected_P2J.Value;
                chrArray = new char[] { '±' };
                string[] strArrays2 = value.Split(chrArray);
                string empty1 = string.Empty;
                for (int j = 0; j < (int)strArrays2.Length; j++)
                {
                    if (strArrays2[j].ToString().Trim() != "")
                    {
                        string str10 = strArrays2[j].ToString();
                        chrArray = new char[] { '»' };
                        string[] strArrays3 = str10.Split(chrArray);
                        empty1 = string.Concat(empty1, strArrays3[0].ToString(), "±");
                    }
                }
                JobBasePage.Job_Progress_Status_Insert(this.CompanyID, this.JobID);
                int num = 0;
                foreach (DataRow row in JobBasePage.Job_Select_By_JobID(this.CompanyID, this.JobID).Rows)
                {
                    num = Convert.ToInt32(row["StatusID"].ToString());
                }
                commonClass _commonClass1 = new commonClass();
                chrArray = new char[] { '±' };
                string[] strArrays4 = empty1.Split(chrArray);
                List<string> strs = new List<string>(nums.Values);
                chrArray = new char[] { '±' };


                if (estimateItemID == 0 && !list.Contains(estimateID))
                {
                    foreach (DataRow row2 in dataTable5.Rows)
                    {
                        long est_item_id = (long)Convert.ToInt32(row2["EstimateItemID"].ToString());
                        JobBasePage.EstimateItems_ProgressToJob(est_item_id, this.JobID, flag, this.CreatedDate);
                        foreach (DataRow dataRow in EstimatesBasePage.estimate_subitem_select_New(est_item_id).Rows)
                        {
                            JobBasePage.EstimateItems_ProgressToJob(Convert.ToInt64(dataRow["EstimateItemID"]), this.JobID, flag, this.CreatedDate);
                        }
                        JobBasePage.jobs_jobcard_insert(this.CompanyID, Convert.ToInt32(est_item_id), Convert.ToInt16(1), P2JParseDate(str1), P2JParseDate(str2), P2JParseDate(str3), P2JParseDate(str4), P2JParseDate(str5), P2JParseDate(str6));
                        EstimateBasePage.ProgressToJob_IsBackOrder_Check(est_item_id, 1);
                        EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, est_item_id, estimateType);
                        _commonClass1.SendMailOnJobStatusChange_Item(this.CompanyID, this.JobID, Convert.ToInt32(num), "job", est_item_id, (long)0);
                    }
                }
                else
                {
                    JobBasePage.EstimateItems_ProgressToJob(estimateItemID, this.JobID, flag, this.CreatedDate);
                    foreach (DataRow dataRow in EstimatesBasePage.estimate_subitem_select_New(estimateItemID).Rows)
                    {
                        JobBasePage.EstimateItems_ProgressToJob(Convert.ToInt64(dataRow["EstimateItemID"]), this.JobID, flag, this.CreatedDate);
                    }
                    JobBasePage.jobs_jobcard_insert(this.CompanyID, Convert.ToInt32(estimateItemID), Convert.ToInt16(1), P2JParseDate(str1), P2JParseDate(str2), P2JParseDate(str3), P2JParseDate(str4), P2JParseDate(str5), P2JParseDate(str6));
                    EstimateBasePage.ProgressToJob_IsBackOrder_Check(estimateItemID, 1);
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, estimateItemID, estimateType);
                    _commonClass1.SendMailOnJobStatusChange_Item(this.CompanyID, this.JobID, Convert.ToInt32(num), "job", estimateItemID, (long)0);
                }




                //JobBasePage.EstimateItems_ProgressToJob(estimateItemID, this.JobID, flag, this.CreatedDate);
                //foreach (DataRow dataRow in EstimatesBasePage.estimate_subitem_select_New(estimateItemID).Rows)
                //{
                //    JobBasePage.EstimateItems_ProgressToJob(Convert.ToInt64(dataRow["EstimateItemID"]), this.JobID, flag, this.CreatedDate);
                //}
                //JobBasePage.jobs_jobcard_insert(this.CompanyID, Convert.ToInt32(estimateItemID), Convert.ToInt16(1), Convert.ToDateTime(str1), Convert.ToDateTime(str2), Convert.ToDateTime(str3), Convert.ToDateTime(str4), Convert.ToDateTime(str5), Convert.ToDateTime(str6));
                //EstimateBasePage.ProgressToJob_IsBackOrder_Check(estimateItemID, 1);
                //EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, estimateItemID, estimateType);
                //_commonClass1.SendMailOnJobStatusChange_Item(this.CompanyID, this.JobID, Convert.ToInt32(num), "job", estimateItemID, (long)0);


                ////---------------------------------------------
                //--- JOB END -----------------------------------
                ////---------------------------------------------


                #endregion

                #region CREATING POs


                if (chkCreatePOs.Checked)
                {


                    //string[] strArrays;
                    //string strArray = strArrays_[i_];
                    //char[] chrArray_ = new char[] { '\u005F' };
                    //int r;
                    //object[] item;
                    //string str = SettingsBasePage.eprint_numbering(this.CompanyID, "J", ConnectionClass.IsHandy);
                    //int num = 0;
                    //string empty = string.Empty;
                    //char[] chrArray = new char[] { '±' };
                    

                    foreach (DataRow row in JobBasePage.Job_Select_By_JobID(this.CompanyID, this.JobID).Rows)
                    {
                        num = Convert.ToInt32(row["StatusID"].ToString());
                    }

                    //long estimateID = (long)Convert.ToInt32(strArray.Split(chrArray_)[0].ToString());
                    //long orderID = (long)Convert.ToInt32(strArray.Split(chrArray_)[1].ToString());
                    //long estimateItemID = (long)Convert.ToInt32(strArray.Split(chrArray_)[2].ToString());
                    //this.EstimateID = estimateID;



                    if (1 == 1)
                    {




                        //string estimateType = string.Empty;
                        DataTable dataTable5__ = EstimatesBasePage.estimate_item_select_reeng(this.CompanyID, this.EstimateID, "order");

                        string estimate_item_ids_POs = string.Empty;
                        foreach (DataRow row2 in dataTable5__.Rows)
                        {
                            estimate_item_ids_POs = estimate_item_ids_POs + row2["EstimateItemID"].ToString() + "↑";
                        }
                        this.hdnEstItemsSelected_PO.Value = estimate_item_ids_POs;


                        DataTable dataTable_subitems = EstimatesBasePage.estimate_itemandsubitem_select(this.EstimateID);
                        string estimate_sub_item_ids_POs = string.Empty;
                        foreach (DataRow row3_ in dataTable_subitems.Rows)
                        {
                            if (row3_["isparentitem"].ToString() != "True")
                            {
                                estimate_sub_item_ids_POs = estimate_sub_item_ids_POs + row3_["EstimateItemID"].ToString() + "↑";
                            }

                        }
                        this.hdnSubItemsIDs_PO.Value = estimate_sub_item_ids_POs;


                        string empty2 = string.Empty;
                        string empty3 = string.Empty;
                        foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                        {
                            empty2 = row1["PhraseText"].ToString();
                        }
                        foreach (DataRow dataRow1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                        {
                            empty3 = dataRow1["PhraseText"].ToString();
                        }
                        EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty2, empty3);
                        string empty4 = string.Empty;
                        string empty5 = string.Empty;
                        string empty6 = string.Empty;
                        // Test
                        foreach (DataRow row2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Purchase Footer").Rows)
                        {
                            empty5 = row2["PhraseText"].ToString();
                        }
                        foreach (DataRow dataRow2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Purchase Header").Rows)
                        {
                            empty4 = dataRow2["PhraseText"].ToString();
                        }
                        foreach (DataRow row3 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Instructions").Rows)
                        {
                            empty6 = row3["PhraseText"].ToString();
                        }

                        int num3 = 0;
                        commonClass _commonClass2 = this.commclass;
                        string dateFormat = this.DateFormat;
                        commonClass _commonClass3 = this.commclass;
                        DateTime now = DateTime.Now.AddDays(5);
                        string str12 = _commonClass2.date_Check_new(dateFormat, _commonClass3.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
                        commonClass _commonClass4 = this.commclass;
                        string dateFormat1 = this.DateFormat;
                        commonClass _commonClass5 = this.commclass;
                        now = DateTime.Now;
                        string str13 = _commonClass4.date_Check_new(dateFormat1, _commonClass5.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
                        DateTime dateTime = P2JParseDate(str12);
                        DateTime dateTime1 = P2JParseDate(str13);
                        int num4 = 0;
                        foreach (DataRow dataRow3 in SettingsBasePage.settings_estimatestatus_moduletype_select_new(this.CompanyID, "purchase").Rows)
                        {
                            num4 = Convert.ToInt32(dataRow3["StatusID"].ToString());
                        }
                        int taxID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                        decimal taxRate = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                        this.chkRaisePOBasedOnEstiItemIDCommon = false;

                        //-----------
                        DataTable dataTable = EstimatesBasePage.estimate_itemandsubitem_select(this.EstimateID);
                        string value1 = this.hdnEstItemsSelected_PO.Value;
                        chrArray = new char[] { '↑' };
                        string[] strArrays7 = value1.Split(chrArray);
                        string value2 = this.hdnSubItemsIDs_PO.Value;
                        chrArray = new char[] { '↑' };
                        string[] strArrays8 = value2.Split(chrArray);
                        foreach (DataRow row4 in dataTable.Rows)
                        {
                            this.PoOCRaised = false;
                            bool flag1 = false;
                            string str14 = Convert.ToString(row4["EstimateItemID"]);
                            if (string.Compare(row4["estimatetype"].ToString().ToLower(), "l", true) == 0)
                            {
                                flag1 = true;
                            }
                            else if (strArrays7.Contains<string>(str14.Trim()))
                            {
                                flag1 = true;
                            }
                            else if (strArrays8.Contains<string>(str14.Trim()))
                            {
                                flag1 = true;
                            }
                            if (flag1 || string.Compare(row4["estimatetype"].ToString(), "u", true) == 0)
                            {
                                long num5 = (long)0;
                                int num6 = 0;
                                int num7 = 0;
                                long num8 = (long)0;
                                string empty8 = string.Empty;
                                string empty9 = string.Empty;
                                long num9 = (long)0;
                                DataSet dataSet = new DataSet();
                                DataTable dataTable1 = JobBasePage.Job_Card_Full_Info_Select_By_JobID_Create_Bulk(this.JobID);
                                DataTable dataTable2 = new DataTable();
                                foreach (DataRow dataRow4 in dataTable1.Rows)
                                {
                                    long num10 = Convert.ToInt64(dataRow4["EstimateItemID"]);
                                    int num11 = Convert.ToInt32(dataRow4["QtyNumber"]);
                                    string str15 = dataRow4["ItemType"].ToString();
                                    long num12 = (long)0;
                                    string empty10 = string.Empty;
                                    string empty11 = string.Empty;
                                    int num13 = 0;
                                    int num14 = 0;
                                    decimal num15 = new decimal(0);
                                    decimal num16 = new decimal(0);
                                    decimal num17 = new decimal(0);
                                    int num18 = 0;
                                    decimal num19 = new decimal(0);
                                    decimal num20 = new decimal(0);
                                    decimal num21 = new decimal(0);
                                    decimal num22 = new decimal(0);
                                    long num23 = (long)0;
                                    string pODN = string.Empty;
                                    decimal num24 = new decimal(0);
                                    decimal num25 = new decimal(0);
                                    decimal num26 = new decimal(0);
                                    long num27 = (long)0;
                                    long num28 = (long)0;
                                    string empty12 = string.Empty;
                                    string empty13 = string.Empty;
                                    string empty14 = string.Empty;
                                    bool flag2 = false;
                                    empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, str15.ToLower());
                                    empty12 = (empty12 != "a" ? "R" : "A");
                                    if (str15.ToLower() != "u")
                                    {
                                        if ((long)Convert.ToInt32(str14) != num10 || !flag1)
                                        {
                                            continue;
                                        }
                                        if (string.Compare(str15, "S", true) == 0)
                                        {
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            if (!Convert.ToBoolean(row4["isparentitem"]))
                                            {
                                                num10 = (long)Convert.ToInt32(row4["ParentItemID"]);
                                                DataSet dataSet1 = new DataSet();
                                                dataSet1 = EstimatesBasePage.select_othercost_parentdetails(this.EstimateID, num10);
                                                foreach (DataRow row5 in dataSet1.Tables[0].Rows)
                                                {
                                                    str15 = row5["EstimateType"].ToString();
                                                }
                                                foreach (DataRow dataRow5 in dataSet1.Tables[1].Rows)
                                                {
                                                    num11 = Convert.ToInt32(dataRow5["QtyNumber"]);
                                                }
                                                empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "s");
                                                empty12 = (empty12 != "a" ? "R" : "A");
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num);
                                            }
                                            else
                                            {
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                foreach (DataRow row6 in dataSet.Tables[0].Rows)
                                                {
                                                    if (Convert.ToInt64(row6["ProductID"]) <= (long)0)
                                                    {
                                                        num12 = Convert.ToInt64(row6["PaperID"]);
                                                        empty10 = "I";
                                                        flag2 = false;
                                                    }
                                                    else
                                                    {
                                                        num12 = Convert.ToInt64(row6["ProductID"]);
                                                        empty10 = "W";
                                                        flag2 = true;
                                                    }
                                                    empty11 = row6["InventoryCode"].ToString();
                                                    pODN = row6["inventoryname"].ToString();
                                                    num13 = Convert.ToInt32(row6["Quantity"]);
                                                    num15 = Convert.ToDecimal(row6["PackedIn"]);
                                                    num23 = Convert.ToInt64(row6["EstimateSingleItemID"]);
                                                    num17 = Convert.ToDecimal(row6["PaperUnitPrice"]);
                                                    num18 = Convert.ToInt32(row6["PrintLayoutValue"]);
                                                    num19 = Convert.ToDecimal(row6["SetupSpoilage"]);
                                                    num20 = Convert.ToDecimal(row6["RunningSpoilage"]);
                                                    Convert.ToDecimal(row6["PaperMarkup"]);
                                                    num26 = Convert.ToDecimal(row6["InvSheets"]);
                                                    num28 = Convert.ToInt64(row6["DeliveryAddress"].ToString());
                                                    EstimateBasePage.PrintSheets_Calculation_For_SingleItem(num13, num18, num19, num20, out num21);
                                                    EstimatesBasePage.GetPrintSheetCalulation(num13, num18, num19, num20, new decimal(0), "singleitem", new decimal(0), "", out num21);
                                                    if (row6["ispriceperpack"].ToString().ToLower() == "true")
                                                    {
                                                        num24 = Convert.ToDecimal(row6["packedprice"]);
                                                        num16 = SummaryClass.ReturnPackedPrice(num26, num15, num24, new decimal(0), out num25);
                                                        num15 = num25;
                                                    }
                                                    else
                                                    {
                                                        num16 = num26 * num17;
                                                    }
                                                    num6 = Convert.ToInt32(row6["SupplierID"].ToString());
                                                    num7 = Convert.ToInt32(row6["ContactID"].ToString());
                                                    num8 = Convert.ToInt64(row6["AddressID"].ToString());
                                                    empty8 = row6["AddressType"].ToString();
                                                    if (row6["IsPaperSupplied"].ToString().ToLower() != "true")
                                                    {
                                                        num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                        this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                        decimal num29 = (num16 * taxRate) / new decimal(100);
                                                        num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num26), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num29, num3, "", false, num10, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                        foreach (DataRow dataRow6 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                        {
                                                            empty14 = dataRow6["PONO"].ToString();
                                                        }
                                                        if (empty7 != "")
                                                        {
                                                            empty7 = string.Concat(empty7, ", ");
                                                        }
                                                        item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                        empty7 = string.Concat(item);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num26), "progressed", num10);
                                                    if (this.ReduceStockType != "e")
                                                    {
                                                        continue;
                                                    }
                                                    if (!this.htInventory.ContainsKey(num12))
                                                    {
                                                        this.htInventory.Add(num12, Convert.ToInt32(num26));
                                                    }
                                                    else
                                                    {
                                                        this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num26);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num26), "completed", num10);
                                                }
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "P", true) == 0)
                                        {
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            if (!Convert.ToBoolean(row4["isparentitem"]))
                                            {
                                                num10 = (long)Convert.ToInt32(row4["ParentItemID"]);
                                                DataSet dataSet2 = new DataSet();
                                                dataSet2 = EstimatesBasePage.select_othercost_parentdetails(this.EstimateID, num10);
                                                foreach (DataRow row7 in dataSet2.Tables[0].Rows)
                                                {
                                                    str15 = row7["EstimateType"].ToString();
                                                }
                                                foreach (DataRow dataRow7 in dataSet2.Tables[1].Rows)
                                                {
                                                    num11 = Convert.ToInt32(dataRow7["QtyNumber"]);
                                                }
                                                empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "p");
                                                empty12 = (empty12 != "a" ? "R" : "A");
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num);
                                            }
                                            else
                                            {
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                foreach (DataRow row8 in dataSet.Tables[0].Rows)
                                                {
                                                    if (Convert.ToInt64(row8["ProductID"]) <= (long)0)
                                                    {
                                                        num12 = Convert.ToInt64(row8["PaperID"]);
                                                        empty10 = "I";
                                                        flag2 = false;
                                                    }
                                                    else
                                                    {
                                                        num12 = Convert.ToInt64(row8["ProductID"]);
                                                        empty10 = "W";
                                                        flag2 = true;
                                                    }
                                                    empty11 = row8["InventoryCode"].ToString();
                                                    pODN = row8["inventoryname"].ToString();
                                                    num13 = Convert.ToInt32(row8["Quantity"]);
                                                    num15 = Convert.ToDecimal(row8["PackedIn"]);
                                                    num23 = Convert.ToInt64(row8["EstimatePadItemID"]);
                                                    num17 = Convert.ToDecimal(row8["PaperUnitPrice"]);
                                                    num18 = Convert.ToInt32(row8["PrintLayoutValue"]);
                                                    num19 = Convert.ToDecimal(row8["SetupSpoilage"]);
                                                    num20 = Convert.ToDecimal(row8["RunningSpoilage"]);
                                                    Convert.ToDecimal(row8["PaperMarkup"]);
                                                    num26 = Convert.ToDecimal(row8["InvSheets"]);
                                                    num28 = Convert.ToInt64(row8["DeliveryAddress"].ToString());
                                                    if (row8["LeavesPerPad"] != null)
                                                    {
                                                        Convert.ToDecimal(row8["LeavesPerPad"]);
                                                    }
                                                    if (row8["ispriceperpack"].ToString().ToLower() == "true")
                                                    {
                                                        num24 = Convert.ToDecimal(row8["packedprice"]);
                                                        num16 = SummaryClass.ReturnPackedPrice(num26, num15, num24, new decimal(0), out num25);
                                                        num15 = num25;
                                                    }
                                                    else
                                                    {
                                                        num16 = num26 * num17;
                                                    }
                                                    num6 = Convert.ToInt32(row8["SupplierID"].ToString());
                                                    num7 = Convert.ToInt32(row8["ContactID"].ToString());
                                                    num8 = Convert.ToInt64(row8["AddressID"].ToString());
                                                    empty8 = row8["AddressType"].ToString();
                                                    long num30 = this.objCom.settings_lastcounter_select(this.CompanyID, "p") + (long)1;
                                                    long num31 = (long)10000000 + num30;
                                                    this.PONO = string.Concat("PO-", num31.ToString().Substring(1, num31.ToString().Length - 1));
                                                    if (row8["IsPaperSupplied"].ToString().ToLower() != "true")
                                                    {
                                                        num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                        this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                        decimal num32 = (num16 * taxRate) / new decimal(100);
                                                        num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num26), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num32, num3, "", false, num10, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                        foreach (DataRow dataRow8 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                        {
                                                            empty14 = dataRow8["PONO"].ToString();
                                                        }
                                                        if (empty7 != "")
                                                        {
                                                            empty7 = string.Concat(empty7, ", ");
                                                        }
                                                        item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                        empty7 = string.Concat(item);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num26), "progressed", num10);
                                                    if (this.ReduceStockType != "e")
                                                    {
                                                        continue;
                                                    }
                                                    if (!this.htInventory.ContainsKey(num12))
                                                    {
                                                        this.htInventory.Add(num12, Convert.ToInt32(num26));
                                                    }
                                                    else
                                                    {
                                                        this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num26);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num26), "completed", num10);
                                                }
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "L", true) == 0)
                                        {
                                            if (!Convert.ToBoolean(row4["isparentitem"]))
                                            {
                                                num10 = (long)Convert.ToInt32(row4["ParentItemID"]);
                                                DataSet dataSet3 = new DataSet();
                                                dataSet3 = EstimatesBasePage.select_othercost_parentdetails(this.EstimateID, num10);
                                                foreach (DataRow row9 in dataSet3.Tables[0].Rows)
                                                {
                                                    str15 = row9["EstimateType"].ToString();
                                                }
                                                foreach (DataRow dataRow9 in dataSet3.Tables[1].Rows)
                                                {
                                                    num11 = Convert.ToInt32(dataRow9["QtyNumber"]);
                                                }
                                                empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "l");
                                                empty12 = (empty12 != "a" ? "R" : "A");
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new_SubItem_LargFormt(this.CompanyID, num10, num11, str15, Convert.ToInt64(str14));
                                                this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num);
                                            }
                                            else
                                            {
                                                int num33 = 0;
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                foreach (DataRow row10 in dataSet.Tables[0].Rows)
                                                {
                                                    item = new object[] { num10, "_", row10["PaperID"], "_", num33 };
                                                    string str16 = string.Concat(item);
                                                    string value3 = this.hdnLFSelected_PO.Value;
                                                    chrArray = new char[] { '\u25BC' };
                                                    if (value3.Split(chrArray).Contains<string>(str16))
                                                    {
                                                        if (Convert.ToInt64(row10["ProductID"]) <= (long)0)
                                                        {
                                                            num12 = Convert.ToInt64(row10["PaperID"]);
                                                            empty10 = "I";
                                                            flag2 = false;
                                                        }
                                                        else
                                                        {
                                                            num12 = Convert.ToInt64(row10["ProductID"]);
                                                            empty10 = "W";
                                                            flag2 = true;
                                                        }
                                                        empty11 = row10["InventoryCode"].ToString();
                                                        pODN = row10["inventoryname"].ToString();
                                                        num13 = Convert.ToInt32(row10["Quantity"]);
                                                        num15 = Convert.ToDecimal(row10["PackedIn"]);
                                                        num23 = Convert.ToInt64(row10["EstimateLargeItemID"]);
                                                        num17 = Convert.ToDecimal(row10["PaperUnitPrice"]);
                                                        num18 = Convert.ToInt32(row10["PrintLayoutValue"]);
                                                        num19 = Convert.ToDecimal(row10["SetupSpoilage"]);
                                                        num20 = Convert.ToDecimal(row10["RunningSpoilage"]);
                                                        Convert.ToDecimal(row10["PaperMarkup"]);
                                                        num27 = Convert.ToInt64(row10["EstLargeItemCalculationID"]);
                                                        Convert.ToDecimal(row10["JobHeight"]);
                                                        Convert.ToDecimal(row10["JobWidth"]);
                                                        Convert.ToDecimal(row10["SheetHeight"]);
                                                        Convert.ToDecimal(row10["SheetWidth"]);
                                                        Convert.ToDecimal(row10["GutterHorizontal"]);
                                                        Convert.ToDecimal(row10["GutterVertical"]);
                                                        Convert.ToDecimal(row10["Row"]);
                                                        Convert.ToDecimal(row10["Col"]);
                                                        row10["PrintLayout"].ToString();
                                                        row10["PressPaperType"].ToString();
                                                        num26 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row10["InvSheets"].ToString()), 0, "", false, false, true));
                                                        num28 = Convert.ToInt64(row10["DeliveryAddress"].ToString());
                                                        if (row10["ispriceperpack"].ToString().ToLower() == "true")
                                                        {
                                                            num24 = Convert.ToDecimal(row10["packedprice"]);
                                                            num16 = SummaryClass.ReturnPackedPrice(num26, num15, num24, new decimal(0), out num25);
                                                            num15 = num25;
                                                        }
                                                        else
                                                        {
                                                            num16 = num26 * num17;
                                                        }
                                                        num6 = Convert.ToInt32(row10["SupplierID"].ToString());
                                                        num7 = Convert.ToInt32(row10["ContactID"].ToString());
                                                        num8 = Convert.ToInt64(row10["AddressID"].ToString());
                                                        empty8 = row10["AddressType"].ToString();
                                                        if (row10["IsPaperSupplied"].ToString().ToLower() != "true")
                                                        {
                                                            num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                            this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                            decimal num34 = (num16 * taxRate) / new decimal(100);
                                                            num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num26), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num34, num3, "", false, num10, str15, flag2, num27, this.UserID, this.CreatedDate);
                                                            foreach (DataRow dataRow10 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                            {
                                                                empty14 = dataRow10["PONO"].ToString();
                                                            }
                                                            if (empty7 != "")
                                                            {
                                                                empty7 = string.Concat(empty7, ", ");
                                                            }
                                                            item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                            empty7 = string.Concat(item);
                                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                                        }
                                                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num26), "progressed", num10);
                                                        if (this.ReduceStockType == "e")
                                                        {
                                                            if (!this.htInventory.ContainsKey(num12))
                                                            {
                                                                this.htInventory.Add(num12, Convert.ToDecimal(num26));
                                                            }
                                                            else
                                                            {
                                                                this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num26);
                                                            }
                                                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, num26, "completed", num10);
                                                        }
                                                    }
                                                    num33++;
                                                }
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "B", true) == 0)
                                        {
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                            Hashtable hashtables = new Hashtable();
                                            int num35 = 0;
                                            foreach (DataRow row11 in dataSet.Tables[0].Rows)
                                            {
                                                if (Convert.ToInt64(row11["ProductID"]) <= (long)0)
                                                {
                                                    num12 = Convert.ToInt64(row11["PaperID"]);
                                                    empty10 = "I";
                                                    flag2 = false;
                                                }
                                                else
                                                {
                                                    num12 = Convert.ToInt64(row11["ProductID"]);
                                                    empty10 = "W";
                                                    flag2 = true;
                                                }
                                                empty11 = row11["InventoryCode"].ToString();
                                                pODN = row11["inventoryname"].ToString();
                                                num13 = Convert.ToInt32(row11["Quantity"]);
                                                num15 = Convert.ToDecimal(row11["PackedIn"]);
                                                num23 = Convert.ToInt64(row11["EstimateBookletItemID"]);
                                                num17 = Convert.ToDecimal(row11["PaperUnitPrice"]);
                                                Convert.ToDecimal(row11["NoOfSignatures"]);
                                                num19 = Convert.ToDecimal(row11["SetupSpoilage"]);
                                                num20 = Convert.ToDecimal(row11["RunningSpoilage"]);
                                                Convert.ToDecimal(row11["PaperMarkup"]);
                                                num26 = Convert.ToDecimal(row11["InvSheets"]);
                                                num28 = Convert.ToInt64(row11["DeliveryAddress"].ToString());
                                                if (row11["ispriceperpack"].ToString().ToLower() == "true")
                                                {
                                                    num24 = Convert.ToDecimal(row11["packedprice"]);
                                                    num16 = SummaryClass.ReturnPackedPrice(num26, num15, num24, new decimal(0), out num25);
                                                    num15 = num25;
                                                }
                                                else
                                                {
                                                    num16 = num26 * num17;
                                                }
                                                num6 = Convert.ToInt32(row11["SupplierID"].ToString());
                                                num7 = Convert.ToInt32(row11["ContactID"].ToString());
                                                num8 = Convert.ToInt64(row11["AddressID"].ToString());
                                                empty8 = row11["AddressType"].ToString();
                                                if (row11["IsPaperSupplied"].ToString().ToLower() != "true")
                                                {
                                                    num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, num23, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                    if (num35 == 0)
                                                    {
                                                        this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                        num35++;
                                                    }
                                                    decimal num36 = (num16 * taxRate) / new decimal(100);
                                                    num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num26), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num36, num3, "", false, num23, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                    foreach (DataRow dataRow11 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                    {
                                                        empty14 = dataRow11["PONO"].ToString();
                                                    }
                                                    if (empty7 != "")
                                                    {
                                                        empty7 = string.Concat(empty7, ", ");
                                                    }
                                                    item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                    empty7 = string.Concat(item);
                                                }
                                                if (this.ReduceStockType == "e")
                                                {
                                                    if (!this.htInventory.ContainsKey(num12))
                                                    {
                                                        this.htInventory.Add(num12, Convert.ToInt32(num26));
                                                    }
                                                    else
                                                    {
                                                        this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num26);
                                                    }
                                                }
                                                if (!hashtables.ContainsKey(num12))
                                                {
                                                    hashtables.Add(num12, Convert.ToInt32(num26));
                                                }
                                                else
                                                {
                                                    hashtables[num12] = Convert.ToInt32(hashtables[num12].ToString()) + Convert.ToInt32(num26);
                                                }
                                            }
                                            foreach (long key in hashtables.Keys)
                                            {
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key, empty10, Convert.ToInt32(hashtables[key]), "progressed", num10);
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key, empty10, Convert.ToInt32(hashtables[key]), "completed", num10);
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "O", true) == 0)
                                        {

                                            //-----------------start
                                            DataSet dataSet_dd = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, num10, num11, str15);
                                            int supp_ID = 0;
                                            foreach (DataRow row_dd in dataSet_dd.Tables[0].Rows)
                                            {
                                                supp_ID = Convert.ToInt32(row_dd["SupplierID"].ToString());
                                            }


                                            //-----------------end

                                            if (!Convert.ToBoolean(row4["isparentitem"]))
                                            {
                                                num10 = (long)Convert.ToInt32(row4["ParentItemID"]);
                                                DataSet dataSet4 = new DataSet();
                                                dataSet4 = EstimatesBasePage.select_othercost_parentdetails(this.EstimateID, num10);
                                                foreach (DataRow row12 in dataSet4.Tables[0].Rows)
                                                {
                                                    str15 = row12["EstimateType"].ToString();
                                                }
                                                foreach (DataRow dataRow12 in dataSet4.Tables[1].Rows)
                                                {
                                                    num11 = Convert.ToInt32(dataRow12["QtyNumber"]);
                                                }
                                                empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "o");
                                                empty12 = (empty12 != "a" ? "R" : "A");
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);


                                                //start


                                                if (this.hdnCombinedValue.Value.ToString() == "yes")
                                                {
                                                    this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num, this.poNum, "yes");
                                                    //num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), str17, "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, "yes");
                                                }
                                                else if (!(list.Contains(supp_ID)) && this.hdnCombinedValue.Value.ToString() == "no")
                                                {
                                                    this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num, this.poNum, "no");
                                                    //num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), str17, "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, "no");
                                                    list.Add(supp_ID);
                                                }
                                                else if (list.Contains(supp_ID) && this.hdnCombinedValue.Value.ToString() == "no")
                                                {
                                                    this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num, 0, "yes");
                                                    //num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), str17, "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, 0, "yes");
                                                    //list.Add(supp_ID);
                                                }


                                                //end


                                            }
                                            else
                                            {
                                                this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                foreach (DataRow row13 in dataSet.Tables[0].Rows)
                                                {
                                                    if (Convert.ToInt64(row13["ProductID"]) > (long)0)
                                                    {
                                                        num12 = Convert.ToInt64(row13["ProductID"]);
                                                        empty10 = "W";
                                                        flag2 = true;
                                                    }
                                                    else if (Convert.ToInt64(row13["PriceCatalogueID"]) <= (long)0)
                                                    {
                                                        num12 = (long)0;
                                                        empty10 = "A";
                                                        flag2 = false;
                                                    }
                                                    else
                                                    {
                                                        num12 = Convert.ToInt64(row13["PriceCatalogueID"]);
                                                        empty10 = "W";
                                                        flag2 = false;
                                                    }
                                                    empty11 = "";
                                                    num13 = Convert.ToInt32(row13["Quantity"]);
                                                    num14 = 0;
                                                    num16 = Convert.ToDecimal(row13["Price"]);
                                                    num28 = Convert.ToInt64(row13["DeliveryAddress"].ToString());
                                                    num6 = Convert.ToInt32(row13["SupplierID"].ToString());
                                                    num7 = Convert.ToInt32(row13["SupplierContactID"].ToString());
                                                    num8 = Convert.ToInt64(row13["AddressID"].ToString());
                                                    empty8 = row13["AddressType"].ToString();
                                                    string str17 = row13["SupplierRefNo"].ToString();
                                                    string str18 = row13["ItemDescription"].ToString().Trim();
                                                    string empty15 = string.Empty;
                                                    chrArray = new char[] { 'µ' };
                                                    string[] strArrays9 = str18.Split(chrArray);
                                                    for (int l = 0; l < (int)strArrays9.Length; l++)
                                                    {
                                                        if (l == 10 && strArrays9[l] != "")
                                                        {
                                                            string str19 = strArrays9[l];
                                                            chrArray = new char[] { '»' };
                                                            string[] strArrays10 = str19.Split(chrArray);
                                                            for (int m = 0; m < (int)strArrays10.Length; m++)
                                                            {
                                                                if (m == 2 && string.Compare(strArrays10[3].ToString(), "true", true) == 0)
                                                                {
                                                                    empty15 = strArrays10[2].ToString();
                                                                }
                                                            }
                                                        }
                                                    }
                                                    pODN = SummaryClass.Split_ItemDescription(row13["ItemDescription"].ToString());

                                                    //start


                                                    if (this.hdnCombinedValue.Value.ToString() == "yes")
                                                    {
                                                        num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), str17, "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, "yes");
                                                    }
                                                    else if (!(list.Contains(supp_ID)) && this.hdnCombinedValue.Value.ToString() == "no")
                                                    {
                                                        num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), str17, "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, "no");
                                                        list.Add(supp_ID);
                                                    }
                                                    else if (list.Contains(supp_ID) && this.hdnCombinedValue.Value.ToString() == "no")
                                                    {
                                                        num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), str17, "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, 0, "yes");
                                                        //list.Add(supp_ID);
                                                    }



                                                    //end


                                                    //num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), str17, "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                    this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                    decimal num37 = (num16 * taxRate) / new decimal(100);
                                                    num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num14), Convert.ToDecimal(num16), taxID, num37, num3, empty15, false, num10, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                    foreach (DataRow dataRow13 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                    {
                                                        empty14 = dataRow13["PONO"].ToString();
                                                    }
                                                    if (empty7 != "")
                                                    {
                                                        empty7 = string.Concat(empty7, ", ");
                                                    }
                                                    item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                    empty7 = string.Concat(item);
                                                }
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "C", true) == 0)
                                        {
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            string empty16 = string.Empty;
                                            if (!Convert.ToBoolean(row4["isparentitem"]))
                                            {
                                                num10 = (long)Convert.ToInt32(row4["ParentItemID"]);
                                                DataSet dataSet5 = new DataSet();
                                                dataSet5 = EstimatesBasePage.select_othercost_parentdetails(this.EstimateID, num10);
                                                foreach (DataRow row14 in dataSet5.Tables[0].Rows)
                                                {
                                                    str15 = row14["EstimateType"].ToString();
                                                }
                                                foreach (DataRow dataRow14 in dataSet5.Tables[1].Rows)
                                                {
                                                    num11 = Convert.ToInt32(dataRow14["QtyNumber"]);
                                                }
                                                empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "c");
                                                empty12 = (empty12 != "a" ? "R" : "A");
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num);
                                            }
                                            else
                                            {
                                                num10 = (long)Convert.ToInt32(row4["EstimateItemID"]);
                                                pODN = this.objComn.ItemDescriptionToPO_DN(this.CompanyID, num10, "Purchase", ref empty16);
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                foreach (DataRow row15 in dataSet.Tables[0].Rows)
                                                {
                                                    long num38 = Convert.ToInt64(row15["PriceCatalogueID"]);
                                                    int num39 = Convert.ToInt32(row15["TotalTaxId"]);
                                                    decimal num40 = Convert.ToDecimal(row15["TotalTaxRate"]);
                                                    num12 = (long)0;
                                                    empty10 = "A";
                                                    empty11 = "";
                                                    num13 = Convert.ToInt32(row15["Quantity"]);
                                                    num14 = Convert.ToInt32(row15["Quantity"]);
                                                    num16 = Convert.ToDecimal(row15["Price"]);
                                                    num28 = Convert.ToInt64(row15["DeliveryAddress"].ToString());
                                                    num6 = Convert.ToInt32(row15["SupplierID"].ToString());
                                                    num7 = Convert.ToInt32(row15["SupplierContactID"].ToString());
                                                    num8 = Convert.ToInt64(row15["AddressID"].ToString());
                                                    empty8 = row15["AddressType"].ToString();
                                                    string str20 = row15["ItemDescription"].ToString();
                                                    string empty17 = string.Empty;
                                                    chrArray = new char[] { 'µ' };
                                                    string[] strArrays11 = str20.Split(chrArray);
                                                    for (int n = 0; n < (int)strArrays11.Length; n++)
                                                    {
                                                        if (n == 10 && strArrays11[n] != "")
                                                        {
                                                            string str21 = strArrays11[n];
                                                            chrArray = new char[] { '»' };
                                                            string[] strArrays12 = str21.Split(chrArray);
                                                            for (int o = 0; o < (int)strArrays12.Length; o++)
                                                            {
                                                                if (o == 2)
                                                                {
                                                                    strArrays12[2].ToString();
                                                                }
                                                            }
                                                        }
                                                    }
                                                    num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                    this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                    decimal num41 = (num16 * num40) / new decimal(100);
                                                    DataTable dataTable3 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num38);
                                                    if (dataTable3.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                                    {
                                                        num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num14), Convert.ToDecimal(num16), num39, num41, num3, empty16, false, num10, str15, (long)0, this.UserID, this.CreatedDate);
                                                    }
                                                    else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                                    {
                                                        num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num14), Convert.ToDecimal(num16), num39, num41, num3, empty16, false, num10, str15, (long)0, this.UserID, this.CreatedDate);
                                                    }
                                                    else if (dataTable3.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                                    {
                                                        num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num14), Convert.ToDecimal(num16), num39, num41, num3, empty16, false, num10, str15, (long)0, this.UserID, this.CreatedDate);
                                                    }
                                                    else
                                                    {
                                                        foreach (DataRow dataRow15 in PurchaseBasePage.Kit_Details(num38).Rows)
                                                        {
                                                            int num42 = num13 * Convert.ToInt16(dataRow15["Quantity"]);
                                                            DataTable dataTable4 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(dataRow15["KitItemID"]));
                                                            string str22 = dataTable4.Rows[0]["ItemCode"].ToString();
                                                            string str23 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(dataRow15["KitItemID"])).Replace("»", "\n");
                                                            num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, Convert.ToInt64(dataRow15["KitItemID"]), "W", str22, str23, Convert.ToDecimal(num42), Convert.ToDecimal(num14), Convert.ToDecimal(num16), num39, num41, num3, empty16, false, num10, str15, (long)0, this.UserID, this.CreatedDate);
                                                        }
                                                    }
                                                    foreach (DataRow row16 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                    {
                                                        empty14 = row16["PONO"].ToString();
                                                    }
                                                    if (empty7 != "")
                                                    {
                                                        empty7 = string.Concat(empty7, ", ");
                                                    }
                                                    item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                    empty7 = string.Concat(item);
                                                    BaseClass baseClass1 = new BaseClass();
                                                    foreach (DataRow dataRow16 in baseClass1.ProductStockType_Select((long)this.CompanyID, num38).Rows)
                                                    {
                                                        if (dataRow16["DrawStockFrom"].ToString().ToLower() == "o")
                                                        {
                                                            continue;
                                                        }
                                                        PurchaseBasePage.ProgressToJob_StockItem_Update(num38, num9);
                                                    }
                                                    string str24 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                                                    string str25 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                                                    string str26 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                                    string str27 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                                                    if (str24 == "e")
                                                    {
                                                        foreach (DataRow row17 in baseClass1.ProductStockType_Select((long)this.CompanyID, num38).Rows)
                                                        {
                                                            if (row17["DrawStockFrom"].ToString().ToLower() == "s")
                                                            {
                                                                empty = baseClass1.StockAllocationProcess((long)this.CompanyID, num38, (long)0, num13, str25, "self", Convert.ToBoolean(str26), num10, "Job", num16, (long)this.UserID);
                                                            }
                                                            else if (row17["DrawStockFrom"].ToString().ToLower() == "o")
                                                            {
                                                                empty = baseClass1.StockAllocation_Others((long)this.CompanyID, num38, num13, str25, Convert.ToBoolean(str26), num10, "Job", num16, (long)this.UserID);
                                                            }
                                                            else if (row17["DrawStockFrom"].ToString().ToLower() != "a")
                                                            {
                                                                if (row17["DrawStockFrom"].ToString().ToLower() != "m")
                                                                {
                                                                    continue;
                                                                }
                                                                empty = baseClass1.StockAllocationProcess((long)this.CompanyID, num38, (long)0, num13, str25, "multiple", Convert.ToBoolean(str26), num10, "Job", num16, (long)this.UserID);
                                                            }
                                                            else
                                                            {
                                                                empty = baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num38, num13, str25, "additional option", Convert.ToBoolean(str26), num10, "Job", num16, (long)this.UserID);
                                                            }
                                                        }
                                                    }
                                                    if (!(str27 == "j") || !(baseClass1.Return_StockManagementSettings("SR_JobStatusID") == num.ToString()))
                                                    {
                                                        continue;
                                                    }
                                                    foreach (DataRow dataRow17 in baseClass1.ProductStockType_Select((long)this.CompanyID, num38).Rows)
                                                    {
                                                        base.Session["StockItemType"] = "C";
                                                        if (dataRow17["DrawStockFrom"].ToString().ToLower() == "s")
                                                        {
                                                            empty = baseClass1.StockReductionProcess((long)this.CompanyID, num38, (long)0, "self", num13, num10, "Job", (long)this.UserID, num16);
                                                        }
                                                        else if (dataRow17["DrawStockFrom"].ToString().ToLower() == "o")
                                                        {
                                                            empty = baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num38, "other", num13, num10, "Job", (long)this.UserID, num16);
                                                        }
                                                        else if (dataRow17["DrawStockFrom"].ToString().ToLower() != "a")
                                                        {
                                                            if (dataRow17["DrawStockFrom"].ToString().ToLower() != "m")
                                                            {
                                                                continue;
                                                            }
                                                            empty = baseClass1.StockReductionProcess((long)this.CompanyID, num38, (long)0, "multiple", num13, num10, "Job", (long)this.UserID, num16);
                                                        }
                                                        else
                                                        {
                                                            empty = baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num38, "additional option", num13, num10, "Job", (long)this.UserID, num16);
                                                        }
                                                    }
                                                }
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "W", true) == 0)
                                        {
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            Hashtable hashtables1 = new Hashtable();
                                            string empty18 = string.Empty;
                                            dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                            int num43 = 0;
                                            foreach (DataRow row18 in dataSet.Tables[0].Rows)
                                            {
                                                if (Convert.ToInt64(row18["ProductID"]) <= (long)0)
                                                {
                                                    num12 = Convert.ToInt64(row18["WarehouseTypeID"]);
                                                    empty10 = row18["WarehouseType"].ToString();
                                                    flag2 = false;
                                                }
                                                else
                                                {
                                                    num12 = Convert.ToInt64(row18["ProductID"]);
                                                    empty10 = "W";
                                                    flag2 = true;
                                                }
                                                empty11 = row18["ItemCode"].ToString();
                                                num13 = Convert.ToInt32(row18["Quantity"]);
                                                num15 = Convert.ToDecimal(row18["PackedIn"]);
                                                num17 = Convert.ToDecimal(row18["UnitPrice"]);
                                                Convert.ToDecimal(row18["Tax"]);
                                                Convert.ToInt32(row18["TaxID"]);
                                                num43 = Convert.ToInt32(row18["IsDeleted"]);
                                                row18["inventoryname"].ToString();
                                                pODN = row18["inventoryname"].ToString();
                                                num28 = Convert.ToInt64(row18["DeliveryAddress"].ToString());
                                                num16 = num13 * num17;
                                                string str28 = row18["ItemDescription"].ToString();
                                                string empty19 = string.Empty;
                                                chrArray = new char[] { 'µ' };
                                                str28.Split(chrArray);
                                                num6 = Convert.ToInt32(row18["SupplierID"].ToString());
                                                num7 = Convert.ToInt32(row18["ContactID"].ToString());
                                                num8 = Convert.ToInt64(row18["AddressID"].ToString());
                                                empty8 = row18["AddressType"].ToString();
                                                num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                decimal num44 = (num16 * taxRate) / new decimal(100);
                                                num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num44, num3, empty19, false, num10, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                foreach (DataRow dataRow18 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                {
                                                    empty14 = dataRow18["PONO"].ToString();
                                                }
                                                if (empty7 != "")
                                                {
                                                    empty7 = string.Concat(empty7, ", ");
                                                }
                                                item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                empty7 = string.Concat(item);
                                                if (num43 != 0)
                                                {
                                                    continue;
                                                }
                                                if (!this.htInventory.ContainsKey(num12))
                                                {
                                                    this.htInventory.Add(num12, Convert.ToInt32(num13));
                                                }
                                                else
                                                {
                                                    this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num13);
                                                }
                                                if (!hashtables1.ContainsKey(num12))
                                                {
                                                    hashtables1.Add(num12, Convert.ToInt32(num13));
                                                }
                                                else
                                                {
                                                    hashtables1[num12] = Convert.ToDecimal(hashtables1[num12].ToString()) + Convert.ToDecimal(num13);
                                                }
                                            }
                                            if (hashtables1.Count > 0)
                                            {
                                                foreach (long key1 in hashtables1.Keys)
                                                {
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key1), empty10, Convert.ToInt32(hashtables1[key1]), "progressed", num10);
                                                    if (this.ReduceStockType != "e")
                                                    {
                                                        continue;
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key1), empty10, Convert.ToInt32(hashtables1[key1]), "completed", num10);
                                                }
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "F", true) == 0)
                                        {
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            if (!Convert.ToBoolean(row4["isparentitem"]))
                                            {
                                                num10 = (long)Convert.ToInt32(row4["ParentItemID"]);
                                                DataSet dataSet6 = new DataSet();
                                                dataSet6 = EstimatesBasePage.select_othercost_parentdetails(this.EstimateID, num10);
                                                foreach (DataRow row19 in dataSet6.Tables[0].Rows)
                                                {
                                                    str15 = row19["EstimateType"].ToString();
                                                }
                                                foreach (DataRow dataRow19 in dataSet6.Tables[1].Rows)
                                                {
                                                    num11 = Convert.ToInt32(dataRow19["QtyNumber"]);
                                                }
                                                empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "f");
                                                empty12 = (empty12 != "a" ? "R" : "A");
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num);
                                            }
                                            else
                                            {
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                dataTable2 = EstimatesBasePage.litho_estimate_select(this.CompanyID, num10);
                                                foreach (DataRow row20 in dataTable2.Rows)
                                                {
                                                    num12 = Convert.ToInt64(row20["PlateID"]);
                                                    empty10 = "I";
                                                    num13 = Convert.ToInt32(row20["Noofplates"]);
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num13), "progressed", num10);
                                                    if (this.ReduceStockType != "e")
                                                    {
                                                        continue;
                                                    }
                                                    if (!this.htInventory.ContainsKey(num12))
                                                    {
                                                        this.htInventory.Add(num12, Convert.ToInt32(num13));
                                                    }
                                                    else
                                                    {
                                                        this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num13);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num13), "completed", num10);
                                                }
                                                foreach (DataRow dataRow20 in dataSet.Tables[0].Rows)
                                                {
                                                    if (Convert.ToInt64(dataRow20["ProductID"]) <= (long)0)
                                                    {
                                                        num12 = Convert.ToInt64(dataRow20["PaperID"]);
                                                        empty10 = "I";
                                                        flag2 = false;
                                                    }
                                                    else
                                                    {
                                                        num12 = Convert.ToInt64(dataRow20["ProductID"]);
                                                        empty10 = "W";
                                                        flag2 = true;
                                                    }
                                                    empty11 = dataRow20["InventoryCode"].ToString();
                                                    num13 = Convert.ToInt32(dataRow20["Quantity"]);
                                                    num15 = Convert.ToDecimal(dataRow20["PackedIn"]);
                                                    num23 = Convert.ToInt64(dataRow20["EstLithoItemID"]);
                                                    num17 = Convert.ToDecimal(dataRow20["PaperUnitPrice"]);
                                                    num18 = Convert.ToInt32(dataRow20["PrintLayoutValue"]);
                                                    num19 = Convert.ToDecimal(dataRow20["SetupSpoilage"]);
                                                    num20 = Convert.ToDecimal(dataRow20["RunningSpoilage"]);
                                                    Convert.ToDecimal(dataRow20["PaperMarkup"]);
                                                    pODN = dataRow20["inventoryname"].ToString();
                                                    num26 = Convert.ToDecimal(dataRow20["InvSheets"]);
                                                    num28 = Convert.ToInt64(dataRow20["DeliveryAddress"].ToString());
                                                    if (dataRow20["ispriceperpack"].ToString().ToLower() == "true")
                                                    {
                                                        num24 = Convert.ToDecimal(dataRow20["packedprice"]);
                                                        num16 = SummaryClass.ReturnPackedPrice(num26, num15, num24, new decimal(0), out num25);
                                                        num15 = num25;
                                                    }
                                                    else
                                                    {
                                                        num16 = num26 * num17;
                                                    }
                                                    num6 = Convert.ToInt32(dataRow20["SupplierID"].ToString());
                                                    num7 = Convert.ToInt32(dataRow20["ContactID"].ToString());
                                                    num8 = Convert.ToInt64(dataRow20["AddressID"].ToString());
                                                    empty8 = dataRow20["AddressType"].ToString();
                                                    if (dataRow20["IsPaperSupplied"].ToString().ToLower() != "true")
                                                    {
                                                        num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                        this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                        decimal num45 = (num16 * taxRate) / new decimal(100);
                                                        num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num26), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num45, num3, "", false, num10, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                        foreach (DataRow row21 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                        {
                                                            empty14 = row21["PONO"].ToString();
                                                        }
                                                        if (empty7 != "")
                                                        {
                                                            empty7 = string.Concat(empty7, ", ");
                                                        }
                                                        item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                        empty7 = string.Concat(item);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num26), "progressed", num10);
                                                    if (this.ReduceStockType != "e")
                                                    {
                                                        continue;
                                                    }
                                                    if (!this.htInventory.ContainsKey(num12))
                                                    {
                                                        this.htInventory.Add(num12, Convert.ToInt32(num26));
                                                    }
                                                    else
                                                    {
                                                        this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num26);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num26), "completed", num10);
                                                }
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "D", true) == 0)
                                        {
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            if (!Convert.ToBoolean(row4["isparentitem"]))
                                            {
                                                num10 = (long)Convert.ToInt32(row4["ParentItemID"]);
                                                DataSet dataSet7 = new DataSet();
                                                dataSet7 = EstimatesBasePage.select_othercost_parentdetails(this.EstimateID, num10);
                                                foreach (DataRow dataRow21 in dataSet7.Tables[0].Rows)
                                                {
                                                    str15 = dataRow21["EstimateType"].ToString();
                                                }
                                                foreach (DataRow row22 in dataSet7.Tables[1].Rows)
                                                {
                                                    num11 = Convert.ToInt32(row22["QtyNumber"]);
                                                }
                                                empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "d");
                                                empty12 = (empty12 != "a" ? "R" : "A");
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num);
                                            }
                                            else
                                            {
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                dataTable2 = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, num10);
                                                foreach (DataRow dataRow22 in dataTable2.Rows)
                                                {
                                                    num12 = Convert.ToInt64(dataRow22["PlateID"]);
                                                    empty10 = "I";
                                                    num13 = Convert.ToInt32(dataRow22["Noofplates"]);
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num13), "progressed", num10);
                                                    if (this.ReduceStockType != "e")
                                                    {
                                                        continue;
                                                    }
                                                    if (!this.htInventory.ContainsKey(num12))
                                                    {
                                                        this.htInventory.Add(num12, Convert.ToInt32(num13));
                                                    }
                                                    else
                                                    {
                                                        this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num13);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num13), "completed", num10);
                                                }
                                                foreach (DataRow row23 in dataSet.Tables[0].Rows)
                                                {
                                                    if (Convert.ToInt64(row23["ProductID"]) <= (long)0)
                                                    {
                                                        num12 = Convert.ToInt64(row23["PaperID"]);
                                                        empty10 = "I";
                                                        flag2 = false;
                                                    }
                                                    else
                                                    {
                                                        num12 = Convert.ToInt64(row23["ProductID"]);
                                                        empty10 = "W";
                                                        flag2 = true;
                                                    }
                                                    empty11 = row23["InventoryCode"].ToString();
                                                    num13 = Convert.ToInt32(row23["Quantity"]);
                                                    num15 = Convert.ToDecimal(row23["PackedIn"]);
                                                    num23 = Convert.ToInt64(row23["EstimateLithoPadItemID"]);
                                                    num17 = Convert.ToDecimal(row23["PaperUnitPrice"]);
                                                    num18 = Convert.ToInt32(row23["PrintLayoutValue"]);
                                                    num19 = Convert.ToDecimal(row23["SetupSpoilage"]);
                                                    num20 = Convert.ToDecimal(row23["RunningSpoilage"]);
                                                    Convert.ToDecimal(row23["PaperMarkup"]);
                                                    pODN = row23["inventoryname"].ToString();
                                                    num26 = Convert.ToDecimal(row23["InvSheets"]);
                                                    num28 = Convert.ToInt64(row23["DeliveryAddress"].ToString());
                                                    if (row23["LeavesPerPad"] != null)
                                                    {
                                                        Convert.ToDecimal(row23["LeavesPerPad"]);
                                                    }
                                                    if (row23["ispriceperpack"].ToString().ToLower() == "true")
                                                    {
                                                        num24 = Convert.ToDecimal(row23["packedprice"]);
                                                        num16 = SummaryClass.ReturnPackedPrice(num26, num15, num24, new decimal(0), out num25);
                                                        num15 = num25;
                                                    }
                                                    else
                                                    {
                                                        num16 = num26 * num17;
                                                    }
                                                    num6 = Convert.ToInt32(row23["SupplierID"].ToString());
                                                    num7 = Convert.ToInt32(row23["ContactID"].ToString());
                                                    num8 = Convert.ToInt64(row23["AddressID"].ToString());
                                                    empty8 = row23["AddressType"].ToString();
                                                    long num46 = this.objCom.settings_lastcounter_select(this.CompanyID, "p") + (long)1;
                                                    long num47 = (long)10000000 + num46;
                                                    this.PONO = string.Concat("PO-", num47.ToString().Substring(1, num47.ToString().Length - 1));
                                                    if (row23["IsPaperSupplied"].ToString().ToLower() != "true")
                                                    {
                                                        num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                        this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                        decimal num48 = (num16 * taxRate) / new decimal(100);
                                                        num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num26), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num48, num3, "", false, num10, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                        foreach (DataRow dataRow23 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                        {
                                                            empty14 = dataRow23["PONO"].ToString();
                                                        }
                                                        if (empty7 != "")
                                                        {
                                                            empty7 = string.Concat(empty7, ", ");
                                                        }
                                                        item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                        empty7 = string.Concat(item);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num26), "progressed", num10);
                                                    if (this.ReduceStockType != "e")
                                                    {
                                                        continue;
                                                    }
                                                    if (!this.htInventory.ContainsKey(num12))
                                                    {
                                                        this.htInventory.Add(num12, Convert.ToInt32(num26));
                                                    }
                                                    else
                                                    {
                                                        this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num26);
                                                    }
                                                    EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num26), "completed", num10);
                                                }
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "N", true) == 0)
                                        {
                                            dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                            dataTable2 = EstimatesBasePage.lithoncr_item_select(this.CompanyID, num10);
                                            Hashtable hashtables2 = new Hashtable();
                                            int num49 = 0;
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            foreach (DataRow row24 in dataTable2.Rows)
                                            {
                                                num12 = Convert.ToInt64(row24["PlateID"]);
                                                empty10 = "I";
                                                num13 = Convert.ToInt32(row24["Noofplates"]);
                                                if (!hashtables2.ContainsKey(num12))
                                                {
                                                    hashtables2.Add(num12, Convert.ToInt32(num13));
                                                }
                                                else
                                                {
                                                    hashtables2[num12] = Convert.ToDecimal(hashtables2[num12].ToString()) + Convert.ToDecimal(num13);
                                                }
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                if (!this.htInventory.ContainsKey(num12))
                                                {
                                                    this.htInventory.Add(num12, Convert.ToInt32(num13));
                                                }
                                                else
                                                {
                                                    this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num13);
                                                }
                                            }
                                            foreach (long key2 in hashtables2.Keys)
                                            {
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key2, empty10, Convert.ToInt32(hashtables2[key2]), "progressed", num10);
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key2, empty10, Convert.ToInt32(hashtables2[key2]), "completed", num10);
                                            }
                                            hashtables2.Clear();
                                            foreach (DataRow dataRow24 in dataSet.Tables[0].Rows)
                                            {
                                                if (Convert.ToInt64(dataRow24["ProductID"]) <= (long)0)
                                                {
                                                    num12 = Convert.ToInt64(dataRow24["PaperID"]);
                                                    empty10 = "I";
                                                    flag2 = false;
                                                }
                                                else
                                                {
                                                    num12 = Convert.ToInt64(dataRow24["ProductID"]);
                                                    empty10 = "W";
                                                    flag2 = true;
                                                }
                                                empty11 = dataRow24["InventoryCode"].ToString();
                                                pODN = dataRow24["inventoryname"].ToString();
                                                num13 = Convert.ToInt32(dataRow24["Quantity"]);
                                                num15 = Convert.ToDecimal(dataRow24["PackedIn"]);
                                                num23 = Convert.ToInt64(dataRow24["EstimateLithoNCRItemID"]);
                                                num17 = Convert.ToDecimal(dataRow24["PaperUnitPrice"]);
                                                num18 = Convert.ToInt32(dataRow24["PrintLayoutValue"]);
                                                num19 = Convert.ToDecimal(dataRow24["SetupSpoilage"]);
                                                num20 = Convert.ToDecimal(dataRow24["RunningSpoilage"]);
                                                decimal num50 = Convert.ToDecimal(dataRow24["NcrPartsPerSet"].ToString());
                                                decimal num51 = Convert.ToDecimal(dataRow24["NcrSetsPerPad"].ToString());
                                                Convert.ToDecimal(dataRow24["PaperMarkup"]);
                                                num26 = Convert.ToDecimal(dataRow24["InvSheets"]);
                                                num28 = Convert.ToInt64(dataRow24["DeliveryAddress"].ToString());
                                                if (dataRow24["ispriceperpack"].ToString().ToLower() == "true")
                                                {
                                                    num24 = Convert.ToDecimal(dataRow24["packedprice"]);
                                                    num16 = SummaryClass.ReturnPackedPrice(num26, num15, num24, new decimal(0), out num25);
                                                    num15 = num25;
                                                }
                                                else
                                                {
                                                    num16 = num26 * num17;
                                                }
                                                num6 = Convert.ToInt32(dataRow24["SupplierID"].ToString());
                                                num7 = Convert.ToInt32(dataRow24["ContactID"].ToString());
                                                num8 = Convert.ToInt64(dataRow24["AddressID"].ToString());
                                                empty8 = dataRow24["AddressType"].ToString();
                                                if (dataRow24["IsPaperSupplied"].ToString().ToLower() != "true")
                                                {
                                                    num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, num23, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                    if (num49 == 0)
                                                    {
                                                        this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                        num49++;
                                                    }
                                                    decimal num52 = (num16 * taxRate) / new decimal(100);
                                                    num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num26), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num52, num3, "", false, num23, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                    foreach (DataRow row25 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                    {
                                                        empty14 = row25["PONO"].ToString();
                                                    }
                                                    if (empty7 != "")
                                                    {
                                                        empty7 = string.Concat(empty7, ", ");
                                                    }
                                                    item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                    empty7 = string.Concat(item);
                                                }
                                                if (!hashtables2.ContainsKey(num12))
                                                {
                                                    hashtables2.Add(num12, Convert.ToInt32(num26));
                                                }
                                                else
                                                {
                                                    hashtables2[num12] = Convert.ToInt32(hashtables2[num12].ToString()) + Convert.ToInt32(num26);
                                                }
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                if (!this.htInventory.ContainsKey(num12))
                                                {
                                                    this.htInventory.Add(num12, Convert.ToInt32(num26));
                                                }
                                                else
                                                {
                                                    this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num26);
                                                }
                                            }
                                            foreach (long key3 in hashtables2.Keys)
                                            {
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key3, empty10, Convert.ToInt32(hashtables2[key3]), "progressed", num10);
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key3, empty10, Convert.ToInt32(hashtables2[key3]), "completed", num10);
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "R", true) == 0)
                                        {
                                            dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                            dataTable2 = EstimatesBasePage.lithoncr_item_select(this.CompanyID, num10);
                                            Hashtable hashtables2 = new Hashtable();
                                            int num49 = 0;
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            foreach (DataRow row24 in dataTable2.Rows)
                                            {
                                                num12 = Convert.ToInt64(row24["PlateID"]);
                                                empty10 = "I";
                                                num13 = Convert.ToInt32(row24["Noofplates"]);
                                                if (!hashtables2.ContainsKey(num12))
                                                {
                                                    hashtables2.Add(num12, Convert.ToInt32(num13));
                                                }
                                                else
                                                {
                                                    hashtables2[num12] = Convert.ToDecimal(hashtables2[num12].ToString()) + Convert.ToDecimal(num13);
                                                }
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                if (!this.htInventory.ContainsKey(num12))
                                                {
                                                    this.htInventory.Add(num12, Convert.ToInt32(num13));
                                                }
                                                else
                                                {
                                                    this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num13);
                                                }
                                            }
                                            foreach (long key2 in hashtables2.Keys)
                                            {
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key2, empty10, Convert.ToInt32(hashtables2[key2]), "progressed", num10);
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key2, empty10, Convert.ToInt32(hashtables2[key2]), "completed", num10);
                                            }
                                            hashtables2.Clear();
                                            foreach (DataRow dataRow24 in dataSet.Tables[0].Rows)
                                            {
                                                if (Convert.ToInt64(dataRow24["ProductID"]) <= (long)0)
                                                {
                                                    num12 = Convert.ToInt64(dataRow24["PaperID"]);
                                                    empty10 = "I";
                                                    flag2 = false;
                                                }
                                                else
                                                {
                                                    num12 = Convert.ToInt64(dataRow24["ProductID"]);
                                                    empty10 = "W";
                                                    flag2 = true;
                                                }
                                                empty11 = dataRow24["InventoryCode"].ToString();
                                                pODN = dataRow24["inventoryname"].ToString();
                                                num13 = Convert.ToInt32(dataRow24["Quantity"]);
                                                num15 = Convert.ToDecimal(dataRow24["PackedIn"]);
                                                num23 = Convert.ToInt64(dataRow24["EstimateLithoNCRItemID"]);
                                                num17 = Convert.ToDecimal(dataRow24["PaperUnitPrice"]);
                                                num18 = Convert.ToInt32(dataRow24["PrintLayoutValue"]);
                                                num19 = Convert.ToDecimal(dataRow24["SetupSpoilage"]);
                                                num20 = Convert.ToDecimal(dataRow24["RunningSpoilage"]);
                                                decimal num50 = Convert.ToDecimal(dataRow24["NcrPartsPerSet"].ToString());
                                                decimal num51 = Convert.ToDecimal(dataRow24["NcrSetsPerPad"].ToString());
                                                Convert.ToDecimal(dataRow24["PaperMarkup"]);
                                                num26 = Convert.ToDecimal(dataRow24["InvSheets"]);
                                                num28 = Convert.ToInt64(dataRow24["DeliveryAddress"].ToString());
                                                if (dataRow24["ispriceperpack"].ToString().ToLower() == "true")
                                                {
                                                    num24 = Convert.ToDecimal(dataRow24["packedprice"]);
                                                    num16 = SummaryClass.ReturnPackedPrice(num26, num15, num24, new decimal(0), out num25);
                                                    num15 = num25;
                                                }
                                                else
                                                {
                                                    num16 = num26 * num17;
                                                }
                                                num6 = Convert.ToInt32(dataRow24["SupplierID"].ToString());
                                                num7 = Convert.ToInt32(dataRow24["ContactID"].ToString());
                                                num8 = Convert.ToInt64(dataRow24["AddressID"].ToString());
                                                empty8 = dataRow24["AddressType"].ToString();
                                                if (dataRow24["IsPaperSupplied"].ToString().ToLower() != "true")
                                                {
                                                    num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, num23, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                    if (num49 == 0)
                                                    {
                                                        this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                        num49++;
                                                    }
                                                    decimal num52 = (num16 * taxRate) / new decimal(100);
                                                    num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num26), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num52, num3, "", false, num23, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                    foreach (DataRow row25 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                    {
                                                        empty14 = row25["PONO"].ToString();
                                                    }
                                                    if (empty7 != "")
                                                    {
                                                        empty7 = string.Concat(empty7, ", ");
                                                    }
                                                    item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                    empty7 = string.Concat(item);
                                                }
                                                if (!hashtables2.ContainsKey(num12))
                                                {
                                                    hashtables2.Add(num12, Convert.ToInt32(num26));
                                                }
                                                else
                                                {
                                                    hashtables2[num12] = Convert.ToInt32(hashtables2[num12].ToString()) + Convert.ToInt32(num26);
                                                }
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                if (!this.htInventory.ContainsKey(num12))
                                                {
                                                    this.htInventory.Add(num12, Convert.ToInt32(num26));
                                                }
                                                else
                                                {
                                                    this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num26);
                                                }
                                            }
                                            foreach (long key3 in hashtables2.Keys)
                                            {
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key3, empty10, Convert.ToInt32(hashtables2[key3]), "progressed", num10);
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key3, empty10, Convert.ToInt32(hashtables2[key3]), "completed", num10);
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "K", true) == 0)
                                        {
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                            dataTable2 = EstimatesBasePage.lithobooklet_item_select(this.CompanyID, num10);
                                            Hashtable hashtables3 = new Hashtable();
                                            int num53 = 0;
                                            foreach (DataRow dataRow25 in dataTable2.Rows)
                                            {
                                                num12 = Convert.ToInt64(dataRow25["PlateID"]);
                                                empty10 = "I";
                                                num13 = Convert.ToInt32(dataRow25["Noofplates"]);
                                                if (!hashtables3.ContainsKey(num12))
                                                {
                                                    hashtables3.Add(num12, Convert.ToInt32(num13));
                                                }
                                                else
                                                {
                                                    hashtables3[num12] = Convert.ToDecimal(hashtables3[num12].ToString()) + Convert.ToDecimal(num13);
                                                }
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                if (!this.htInventory.ContainsKey(num12))
                                                {
                                                    this.htInventory.Add(num12, Convert.ToInt32(num13));
                                                }
                                                else
                                                {
                                                    this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num13);
                                                }
                                            }
                                            foreach (long key4 in hashtables3.Keys)
                                            {
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key4, empty10, Convert.ToInt32(hashtables3[key4]), "progressed", num10);
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key4, empty10, Convert.ToInt32(hashtables3[key4]), "completed", num10);
                                            }
                                            hashtables3.Clear();
                                            foreach (DataRow row26 in dataSet.Tables[0].Rows)
                                            {
                                                if (Convert.ToInt64(row26["ProductID"]) <= (long)0)
                                                {
                                                    num12 = Convert.ToInt64(row26["PaperID"]);
                                                    empty10 = "I";
                                                    flag2 = false;
                                                }
                                                else
                                                {
                                                    num12 = Convert.ToInt64(row26["ProductID"]);
                                                    empty10 = "W";
                                                    flag2 = true;
                                                }
                                                empty11 = row26["InventoryCode"].ToString();
                                                pODN = row26["inventoryname"].ToString();
                                                num13 = Convert.ToInt32(row26["Quantity"]);
                                                num15 = Convert.ToDecimal(row26["PackedIn"]);
                                                num23 = Convert.ToInt64(row26["EstimateLithobookletItemID"]);
                                                num17 = Convert.ToDecimal(row26["PaperUnitPrice"]);
                                                Convert.ToInt32(row26["NoOfSignatures"]);
                                                num19 = Convert.ToDecimal(row26["SetupSpoilage"]);
                                                num20 = Convert.ToDecimal(row26["RunningSpoilage"]);
                                                Convert.ToDecimal(row26["PaperMarkup"]);
                                                num26 = Convert.ToDecimal(row26["InvSheets"]);
                                                num28 = Convert.ToInt64(row26["DeliveryAddress"].ToString());
                                                if (row26["ispriceperpack"].ToString().ToLower() == "true")
                                                {
                                                    num24 = Convert.ToDecimal(row26["packedprice"]);
                                                    num16 = SummaryClass.ReturnPackedPrice(num26, num15, num24, new decimal(0), out num25);
                                                    num15 = num25;
                                                }
                                                else
                                                {
                                                    num16 = num26 * num17;
                                                }
                                                num6 = Convert.ToInt32(row26["SupplierID"].ToString());
                                                num7 = Convert.ToInt32(row26["ContactID"].ToString());
                                                num8 = Convert.ToInt64(row26["AddressID"].ToString());
                                                empty8 = row26["AddressType"].ToString();
                                                if (row26["IsPaperSupplied"].ToString().ToLower() != "true")
                                                {
                                                    num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, num23, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                    if (num53 == 0)
                                                    {
                                                        this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                        num53++;
                                                    }
                                                    decimal num54 = (num16 * taxRate) / new decimal(100);
                                                    num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num26), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num54, num3, "", false, num23, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                    foreach (DataRow dataRow26 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                    {
                                                        empty14 = dataRow26["PONO"].ToString();
                                                    }
                                                    if (empty7 != "")
                                                    {
                                                        empty7 = string.Concat(empty7, ", ");
                                                    }
                                                    item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                    empty7 = string.Concat(item);
                                                }
                                                if (!hashtables3.ContainsKey(num12))
                                                {
                                                    hashtables3.Add(num12, Convert.ToInt32(num26));
                                                }
                                                else
                                                {
                                                    hashtables3[num12] = Convert.ToInt32(hashtables3[num12].ToString()) + Convert.ToInt32(num26);
                                                }
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                if (!this.htInventory.ContainsKey(num12))
                                                {
                                                    this.htInventory.Add(num12, Convert.ToInt32(num26));
                                                }
                                                else
                                                {
                                                    this.htInventory[num12] = Convert.ToDecimal(this.htInventory[num12].ToString()) + Convert.ToDecimal(num26);
                                                }
                                            }
                                            foreach (long key5 in hashtables3.Keys)
                                            {
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key5, empty10, Convert.ToInt32(hashtables3[key5]), "progressed", num10);
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, key5, empty10, Convert.ToInt32(hashtables3[key5]), "completed", num10);
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else if (string.Compare(str15, "Q", true) != 0)
                                        {
                                            if (string.Compare(str15, "X", true) != 0)
                                            {
                                                continue;
                                            }
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            string empty20 = string.Empty;
                                            bool flag3 = false;
                                            if (!Convert.ToBoolean(row4["isparentitem"]))
                                            {
                                                num10 = (long)Convert.ToInt32(row4["ParentItemID"]);
                                                DataSet dataSet8 = new DataSet();
                                                dataSet8 = EstimatesBasePage.select_othercost_parentdetails(this.EstimateID, num10);
                                                foreach (DataRow row27 in dataSet8.Tables[0].Rows)
                                                {
                                                    str15 = row27["EstimateType"].ToString();
                                                }
                                                foreach (DataRow dataRow27 in dataSet8.Tables[1].Rows)
                                                {
                                                    num11 = Convert.ToInt32(dataRow27["QtyNumber"]);
                                                }
                                                empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, str15.ToLower());
                                                empty12 = (empty12 != "a" ? "R" : "A");
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str14, out empty13, empty12, (long)num);
                                            }
                                            else
                                            {
                                                num10 = (long)Convert.ToInt32(row4["EstimateItemID"]);
                                                pODN = this.objComn.ItemDescriptionToPO_DN(this.CompanyID, num10, "Purchase", ref empty20);
                                                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                foreach (DataRow row28 in dataSet.Tables[0].Rows)
                                                {
                                                    long num55 = Convert.ToInt64(row28["PriceCatalogueID"]);
                                                    num12 = (long)0;
                                                    empty10 = "A";
                                                    empty11 = "";
                                                    num13 = Convert.ToInt32(row28["Quantity"]);
                                                    num14 = Convert.ToInt32(row28["Quantity"]);
                                                    num16 = Convert.ToDecimal(row28["Price"]);
                                                    num28 = Convert.ToInt64(row28["DeliveryAddress"].ToString());
                                                    int num56 = Convert.ToInt32(row28["TotalTaxId"]);
                                                    decimal num57 = Convert.ToDecimal(row28["TotalTaxRate"]);
                                                    if (row28["SupplierID"].ToString() == "")
                                                    {
                                                        num6 = 0;
                                                    }
                                                    else
                                                    {
                                                        num6 = Convert.ToInt32(row28["SupplierID"].ToString());
                                                    }
                                                    num7 = Convert.ToInt32(row28["SupplierContactID"].ToString());
                                                    num8 = Convert.ToInt64(row28["AddressID"].ToString());
                                                    empty8 = row28["AddressType"].ToString();
                                                    string str29 = row28["ItemDescription"].ToString();
                                                    string empty21 = string.Empty;
                                                    chrArray = new char[] { 'µ' };
                                                    string[] strArrays13 = str29.Split(chrArray);
                                                    for (int p = 0; p < (int)strArrays13.Length; p++)
                                                    {
                                                        if (p == 10 && strArrays13[p] != "")
                                                        {
                                                            string str30 = strArrays13[p];
                                                            chrArray = new char[] { '»' };
                                                            string[] strArrays14 = str30.Split(chrArray);
                                                            for (int q = 0; q < (int)strArrays14.Length; q++)
                                                            {
                                                                if (q == 2)
                                                                {
                                                                    strArrays14[2].ToString();
                                                                }
                                                            }
                                                        }
                                                    }
                                                    num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                    this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                    decimal num58 = (num16 * num57) / new decimal(100);
                                                    DataTable dataTable5_ = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num55);
                                                    if (dataTable5_.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                                    {
                                                        num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num14), Convert.ToDecimal(num16), num56, num58, num3, empty20, false, num10, str15, (long)0, this.UserID, this.CreatedDate);
                                                    }
                                                    else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                                    {
                                                        num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num14), Convert.ToDecimal(num16), num56, num58, num3, empty20, false, num10, str15, (long)0, this.UserID, this.CreatedDate);
                                                    }
                                                    else if (dataTable5_.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                                    {
                                                        num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num14), Convert.ToDecimal(num16), num56, num58, num3, empty20, false, num10, str15, (long)0, this.UserID, this.CreatedDate);
                                                    }
                                                    else
                                                    {
                                                        foreach (DataRow dataRow28 in PurchaseBasePage.Kit_Details(num55).Rows)
                                                        {
                                                            int num59 = num13 * Convert.ToInt16(dataRow28["Quantity"]);
                                                            DataTable dataTable6 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(dataRow28["KitItemID"]));
                                                            string str31 = dataTable6.Rows[0]["ItemCode"].ToString();
                                                            string str32 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(dataRow28["KitItemID"])).Replace("»", "\n");
                                                            num9 = PurchaseBasePage.purchaseitem_insert(this.CompanyID, (long)0, num5, Convert.ToInt64(dataRow28["KitItemID"]), "W", str31, str32, Convert.ToDecimal(num59), Convert.ToDecimal(num14), Convert.ToDecimal(num16), num56, num58, num3, empty20, false, num10, str15, (long)0, this.UserID, this.CreatedDate);
                                                        }
                                                    }
                                                    foreach (DataRow row29 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                    {
                                                        empty14 = row29["PONO"].ToString();
                                                    }
                                                    if (empty7 != "")
                                                    {
                                                        empty7 = string.Concat(empty7, ", ");
                                                    }
                                                    item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                    empty7 = string.Concat(item);
                                                    BaseClass baseClass2 = new BaseClass();
                                                    foreach (DataRow dataRow29 in baseClass2.ProductStockType_Select((long)this.CompanyID, num55).Rows)
                                                    {
                                                        if (dataRow29["DrawStockFrom"].ToString().ToLower() == "o")
                                                        {
                                                            continue;
                                                        }
                                                        PurchaseBasePage.ProgressToJob_StockItem_Update(num55, num9);
                                                    }
                                                    string str33 = baseClass2.Return_StockManagementSettings("SA_EprintMISJobs");
                                                    string str34 = baseClass2.Return_StockManagementSettings("SR_StockReductionMethod");
                                                    string str35 = baseClass2.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                                    string str36 = baseClass2.Return_StockManagementSettings("SR_WhenStockReduced");
                                                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                                    foreach (DataRow row30 in dataSet.Tables[0].Rows)
                                                    {
                                                        flag3 = Convert.ToBoolean(row28["IsStockReplenish"]);
                                                        Convert.ToBoolean(row28["IsStockReplenished"]);
                                                    }
                                                    if (str33 == "e" && flag3.ToString().ToLower() == "false")
                                                    {
                                                        baseClass2.Return_StockManagementSettings("SA_EstoreJobStatusID");
                                                        baseClass2.Return_StockManagementSettings("SA_JobStatusID");
                                                        foreach (DataRow dataRow30 in baseClass2.ProductStockType_Select((long)this.CompanyID, num55).Rows)
                                                        {
                                                            if (dataRow30["DrawStockFrom"].ToString().ToLower() == "s")
                                                            {
                                                                empty = baseClass2.StockAllocationProcess((long)this.CompanyID, num55, (long)0, num13, str34, "self", Convert.ToBoolean(str35), num10, "Job", num16, (long)this.UserID);
                                                            }
                                                            else if (dataRow30["DrawStockFrom"].ToString().ToLower() == "o")
                                                            {
                                                                empty = baseClass2.StockAllocation_Others((long)this.CompanyID, num55, num13, str34, Convert.ToBoolean(str35), num10, "Job", num16, (long)this.UserID);
                                                            }
                                                            else if (dataRow30["DrawStockFrom"].ToString().ToLower() != "a")
                                                            {
                                                                if (dataRow30["DrawStockFrom"].ToString().ToLower() != "m")
                                                                {
                                                                    continue;
                                                                }
                                                                foreach (DataRow row31 in PurchaseBasePage.OtherMultipleProductDetails_Select(num55, num13, true).Rows)
                                                                {
                                                                    empty = baseClass2.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(row31["KitItemID"].ToString()), num55, num13, str34, "multiple", Convert.ToBoolean(str35), num10, "Job", num16, (long)this.UserID);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                empty = baseClass2.StockAllocationForAdditionalOptionEstore((long)this.CompanyID, num55, num13, str34, "additional option", Convert.ToBoolean(str35), num10, "Job", num16, (long)this.UserID, this.EstimateID, num10);
                                                            }
                                                        }
                                                    }
                                                    if (!(str36 == "j") || !(baseClass2.Return_StockManagementSettings("SR_JobStatusID") == num.ToString()))
                                                    {
                                                        continue;
                                                    }
                                                    foreach (DataRow dataRow31 in baseClass2.ProductStockType_Select((long)this.CompanyID, num55).Rows)
                                                    {
                                                        base.Session["StockItemType"] = "C";
                                                        if (dataRow31["DrawStockFrom"].ToString().ToLower() == "s")
                                                        {
                                                            empty = baseClass2.StockReductionProcess((long)this.CompanyID, num55, (long)0, "self", num13, num10, "Job", (long)this.UserID, num16);
                                                        }
                                                        else if (dataRow31["DrawStockFrom"].ToString().ToLower() == "o")
                                                        {
                                                            empty = baseClass2.StockReductionProcess((long)this.CompanyID, (long)0, num55, "other", num13, num10, "Job", (long)this.UserID, num16);
                                                        }
                                                        else if (dataRow31["DrawStockFrom"].ToString().ToLower() != "a")
                                                        {
                                                            if (dataRow31["DrawStockFrom"].ToString().ToLower() != "m")
                                                            {
                                                                continue;
                                                            }
                                                            empty = baseClass2.StockReductionProcess((long)this.CompanyID, num55, (long)0, "multiple", num13, num10, "Job", (long)this.UserID, num16);
                                                        }
                                                        else
                                                        {
                                                            empty = baseClass2.StockReductionProcessForAdditionalOption((long)this.CompanyID, num55, "additional option", num13, num10, "Job", (long)this.UserID, num16);
                                                        }
                                                    }
                                                }
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                if (!(empty7 == "") || !(empty13 != ""))
                                                {
                                                    continue;
                                                }
                                                empty7 = empty13;
                                            }
                                            else
                                            {
                                                empty7 = string.Concat(empty7, ", ", empty13);
                                            }
                                        }
                                        else
                                        {
                                            this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                            dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                            foreach (DataRow row32 in dataSet.Tables[0].Rows)
                                            {
                                                if (Convert.ToInt64(row32["ProductID"]) <= (long)0)
                                                {
                                                    num12 = Convert.ToInt64(row32["PaperID"]);
                                                    empty10 = "I";
                                                    flag2 = false;
                                                }
                                                else
                                                {
                                                    num12 = Convert.ToInt64(row32["ProductID"]);
                                                    empty10 = "W";
                                                    flag2 = true;
                                                }
                                                empty11 = row32["InventoryCode"].ToString();
                                                pODN = SummaryClass.Split_ItemDescription_forpurchaseorder(row32["ItemDescription"].ToString());
                                                num13 = Convert.ToInt32(row32["Quantity"]);
                                                num15 = Convert.ToDecimal(row32["PackedIn"]);
                                                num23 = Convert.ToInt64(row32["QuickQuoteID"]);
                                                num17 = Convert.ToDecimal(row32["PaperUnitPrice"]);
                                                num18 = Convert.ToInt32(row32["PrintLayoutValue"]);
                                                num19 = Convert.ToDecimal(row32["SetupSpoilage"]);
                                                num20 = Convert.ToDecimal(row32["RunningSpoilage"]);
                                                num28 = Convert.ToInt64(row32["DeliveryAddress"].ToString());
                                                num16 = num17;
                                                num6 = Convert.ToInt32(row32["SupplierID"].ToString());
                                                num7 = Convert.ToInt32(row32["ContactID"].ToString());
                                                num8 = Convert.ToInt64(row32["AddressID"].ToString());
                                                empty8 = row32["AddressType"].ToString();
                                                num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                decimal num60 = (num16 * taxRate) / new decimal(100);
                                                num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, num13, Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num60, num3, "", false, num10, str15, flag2, (long)0, this.UserID, this.CreatedDate);
                                                foreach (DataRow dataRow32 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                {
                                                    empty14 = dataRow32["PONO"].ToString();
                                                }
                                                if (empty7 != "")
                                                {
                                                    empty7 = string.Concat(empty7, ", ");
                                                }
                                                item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                empty7 = string.Concat(item);
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num22), "progressed", num10);
                                                if (this.ReduceStockType != "e")
                                                {
                                                    continue;
                                                }
                                                if (!this.htInventory.ContainsKey(num12))
                                                {
                                                    this.htInventory.Add(num12, Convert.ToInt32(num22));
                                                }
                                                else
                                                {
                                                    this.htInventory[num12] = Convert.ToInt32(this.htInventory[num12].ToString()) + Convert.ToInt32(num22);
                                                }
                                                EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num12, empty10, Convert.ToInt32(num22), "completed", num10);
                                            }
                                            if (!(empty7 != "") || !(empty13 != ""))
                                            {
                                                continue;
                                            }
                                            empty7 = string.Concat(empty7, ", ", empty13);
                                        }
                                    }
                                    else
                                    {
                                        if (string.Compare(str15, "u", true) != 0)
                                        {
                                            continue;
                                        }
                                        if (!Convert.ToBoolean(row4["isparentitem"]))
                                        {
                                            num10 = (long)Convert.ToInt32(row4["ParentItemID"]);
                                            DataSet dataSet9 = new DataSet();
                                            dataSet9 = EstimatesBasePage.select_othercost_parentdetails(this.EstimateID, num10);
                                            foreach (DataRow row33 in dataSet9.Tables[0].Rows)
                                            {
                                                str15 = row33["EstimateType"].ToString();
                                            }
                                            foreach (DataRow dataRow33 in dataSet9.Tables[1].Rows)
                                            {
                                                num11 = Convert.ToInt32(dataRow33["QtyNumber"]);
                                            }
                                            dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                            if (!this.PoOCRaised)
                                            {
                                                empty12 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, "u");
                                                empty12 = (empty12 != "a" ? "R" : "A");
                                                string str37 = this.hdnOtherCostSelectedValuesRaisePO.Value.ToString();
                                                chrArray = new char[] { '∅' };
                                                string[] strArrays15 = str37.Split(chrArray);
                                                string str38 = Convert.ToString(num10);
                                                if ((int)strArrays15.Length != 1)
                                                {
                                                    foreach (DataRow row34 in dataSet.Tables[9].Rows)
                                                    {
                                                        if (string.Compare(row34["PoType"].ToString().ToLower(), "othercost", true) != 0 || string.Compare(row34["IsEmpty"].ToString().ToLower(), "no", true) != 0)
                                                        {
                                                            continue;
                                                        }
                                                        strArrays = strArrays15;
                                                        for (r = 0; r < (int)strArrays.Length; r++)
                                                        {
                                                            if (strArrays[r].Contains(row34["estOtherCostID"].ToString()))
                                                            {
                                                                this.PoOCRaised = true;
                                                            }
                                                        }
                                                    }
                                                    if (!this.PoOCRaised)
                                                    {
                                                        this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str38, out empty13, empty12, (long)num);
                                                    }
                                                }
                                                else
                                                {
                                                    this.SubItem_Purchase_Order_InsertNew_Subitems(dataSet, str, num4, this.EstimateID, this.UserID, this.CompanyID, this.htInventory, num10, this.DateFormat, this.UserName, str38, out empty13, empty12, (long)num);
                                                }
                                            }
                                        }
                                        else if (Convert.ToInt64(dataRow4["EstimateItemID"]) == (long)Convert.ToInt32(row4["EstimateItemID"]))
                                        {
                                            num10 = (long)Convert.ToInt32(row4["EstimateItemID"]);
                                            dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num10, num11, str15);
                                            if (Convert.ToBoolean(row4["isparentitem"]))
                                            {
                                                foreach (DataRow dataRow34 in dataSet.Tables[0].Rows)
                                                {
                                                    long num61 = Convert.ToInt64(dataRow34["estOtherCostID"]);
                                                    string str39 = Convert.ToString(num10);
                                                    bool flag4 = false;
                                                    bool flag5 = false;
                                                    string str40 = this.hdnOtherCostSelectedValuesRaisePO.Value.ToString();
                                                    chrArray = new char[] { '∅' };
                                                    string[] strArrays16 = str40.Split(chrArray);
                                                    if ((int)strArrays16.Length > 1)
                                                    {
                                                        strArrays = strArrays16;
                                                        for (r = 0; r < (int)strArrays.Length; r++)
                                                        {
                                                            if (strArrays[r].Contains(dataRow34["estOtherCostID"].ToString()))
                                                            {
                                                                flag5 = true;
                                                            }
                                                        }
                                                    }
                                                    if (strArrays7.Contains<string>(str39.Trim()))
                                                    {
                                                        flag4 = true;
                                                        this.hdnOtherCostSelectedValuesRaisePO.Value = string.Concat(this.hdnOtherCostSelectedValuesRaisePO.Value, dataRow34["estOtherCostID"].ToString(), "∅");
                                                    }
                                                    if (!flag4 || flag5)
                                                    {
                                                        continue;
                                                    }
                                                    this.chkRaisePOBasedOnEstiItemIDCommon = true;
                                                    if (Convert.ToInt64(dataRow34["ProductID"]) <= (long)0)
                                                    {
                                                        num12 = (long)0;
                                                        empty10 = "I";
                                                        flag2 = false;
                                                    }
                                                    else
                                                    {
                                                        num12 = Convert.ToInt64(dataRow34["ProductID"]);
                                                        empty10 = "W";
                                                        flag2 = true;
                                                    }
                                                    num13 = Convert.ToInt32(dataRow34["Quantity"]);
                                                    num28 = Convert.ToInt64(dataRow34["DeliveryAddress"].ToString());
                                                    num6 = Convert.ToInt32(dataRow34["SupplierID"].ToString());
                                                    num7 = Convert.ToInt32(dataRow34["ContactID"].ToString());
                                                    num8 = Convert.ToInt64(dataRow34["AddressID"].ToString());
                                                    num16 = Convert.ToDecimal(dataRow34["cost"].ToString());
                                                    pODN = dataRow34["ItemDescription"].ToString();
                                                    num5 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num6, num7, num8, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, empty8, this.EstimateID, this.objBase.SpecialEncode(empty4), num10, this.TodayDate, num28, empty12, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                                    this.AttachmentUpdate_PO_DN(this.EstimateID, num10, num5, "Purchase");
                                                    decimal num62 = (num16 * taxRate) / new decimal(100);
                                                    num9 = PurchaseBasePage.purchaseitem_insertPOfromJob(this.CompanyID, (long)0, num5, num12, empty10, empty11, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num15), Convert.ToDecimal(num16), taxID, num62, num3, "", false, num61, "U", flag2, (long)0, this.UserID, this.CreatedDate);
                                                    foreach (DataRow row35 in PurchaseBasePage.purchase_select(this.CompanyID, num5).Rows)
                                                    {
                                                        empty14 = row35["PONO"].ToString();
                                                    }
                                                    if (empty7 != "")
                                                    {
                                                        empty7 = string.Concat(empty7, ", ");
                                                    }
                                                    item = new object[] { empty7, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num5, "' target='_blank'>", empty14, "</a>" };
                                                    empty7 = string.Concat(item);
                                                }
                                            }
                                        }
                                        if (!(empty7 != "") || !(empty13 != ""))
                                        {
                                            if (!(empty7 == "") || !(empty13 != ""))
                                            {
                                                continue;
                                            }
                                            empty7 = empty13;
                                        }
                                        else
                                        {
                                            empty7 = string.Concat(empty7, ", ", empty13);
                                        }
                                    }
                                }
                                if (this.ReduceStockType.ToLower() != num.ToString())
                                {
                                    continue;
                                }
                                this.Call_Inventory_Adjustment("completed", this.EstimateID, num.ToString());
                            }
                            else
                            {
                                this.Call_Inventory_Adjustment("progressed", this.EstimateID, num.ToString());
                                if (this.ReduceStockType.ToLower() != "e")
                                {
                                    if (this.ReduceStockType.ToLower() != num.ToString())
                                    {
                                        continue;
                                    }
                                    this.Call_Inventory_Adjustment("completed", this.EstimateID, num.ToString());
                                }
                                else
                                {
                                    this.Call_Inventory_Adjustment("completed", this.EstimateID, num.ToString());
                                }
                            }
                        }
                        string value4 = this.hdnProductAddItemsIDs_PO.Value;
                        chrArray = new char[] { '↑' };
                        string[] strArrays17 = value4.Split(chrArray);
                        if ((int)strArrays17.Length > 1)
                        {
                            string[] strArrays18 = new string[(int)strArrays17.Length - 1];
                            string[] strArrays19 = new string[(int)strArrays17.Length - 1];
                            int num63 = 0;
                            for (int s = 0; s < (int)strArrays17.Length - 1; s++)
                            {
                                string str41 = strArrays17[s];
                                chrArray = new char[] { '\u005F' };
                                string[] strArrays20 = str41.Split(chrArray);
                                if (!strArrays18.Contains<string>(strArrays20[0].ToString()))
                                {
                                    strArrays18[num63] = strArrays20[0].ToString();
                                    num63++;
                                }
                                strArrays19[s] = strArrays20[1].ToString();
                            }
                            for (int t = 0; t < (int)strArrays18.Length; t++)
                            {
                                if (strArrays18[t] != null)
                                {
                                    long num64 = Convert.ToInt64(strArrays18[t]);
                                    int num65 = 1;
                                    string str42 = "C";
                                    string empty22 = string.Empty;
                                    int num66 = 0;
                                    decimal num67 = new decimal(0);
                                    int num68 = 0;
                                    this.objComn.ItemDescriptionToPO_DN(this.CompanyID, num64, "Purchase", ref empty22);
                                    DataTable dataTable7 = EstimatesBasePage.ProductOROrder_Item_Qty_Select(num64);
                                    if (dataTable7.Rows.Count > 0)
                                    {
                                        num68 = Convert.ToInt32(dataTable7.Rows[0]["Quantity"]);
                                        num65 = Convert.ToInt32(dataTable7.Rows[0]["QtyNumber"]);
                                        str42 = dataTable7.Rows[0]["EstimateType"].ToString();
                                        num66 = Convert.ToInt32(dataTable7.Rows[0]["TaxId"]);
                                        num67 = Convert.ToDecimal(dataTable7.Rows[0]["TaxRate"]);
                                    }
                                    foreach (DataRow dataRow35 in EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(num64).Rows)
                                    {
                                        if (!strArrays19.Contains<string>(dataRow35["EstimateAdditionalItemID"].ToString()))
                                        {
                                            continue;
                                        }
                                        long num69 = Convert.ToInt64(dataRow35["EstimateAdditionalItemID"]);
                                        decimal num70 = Convert.ToDecimal(dataRow35[string.Concat("SelectedPrice", num65)]);
                                        long num71 = (long)0;
                                        string str43 = "";
                                        num71 = Convert.ToInt64(dataRow35["DeliveryAddress"].ToString());
                                        str43 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(this.CompanyID, str42.ToLower());
                                        str43 = (str43 != "a" ? "R" : "A");
                                        this.CustomerID = Convert.ToInt32(dataRow35["SupplierID"].ToString());
                                        this.AttentionID = Convert.ToInt32(dataRow35["SupplierContactID"].ToString());
                                        long num72 = Convert.ToInt64(dataRow35["AddressID"].ToString());
                                        string str44 = dataRow35["AddressType"].ToString();
                                        decimal num73 = (num70 * num67) / new decimal(100);
                                        string str45 = string.Concat("Description: ", this.objBase.SpecialDecode(dataRow35["EstimateOtherCostName"].ToString()));
                                        if (!string.IsNullOrEmpty(this.objBase.SpecialDecode(dataRow35["SelectedValue"].ToString())))
                                        {
                                            str45 = string.Concat(str45, " - ", this.objBase.SpecialDecode(dataRow35["SelectedValue"].ToString()));
                                        }
                                        long num74 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, this.CustomerID, this.AttentionID, num72, this.objBase.SpecialEncode(empty6), this.objBase.SpecialEncode(empty5), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, num4, this.UserID, this.UserID, this.CreatedDate, (long)0, str44, this.EstimateID, this.objBase.SpecialEncode(empty4), num64, this.TodayDate, num71, str43, 0, (long)0, dateTime1, this.IsFromProgreesTojob, this.poNum, this.hdnCombinedValue.Value);
                                        PurchaseBasePage.purchaseitem_insert_ProdAdditional_Item(this.CompanyID, (long)0, num74, (long)0, "A", "", str45, Convert.ToDecimal(num68), Convert.ToDecimal(num68), Convert.ToDecimal(num70), num66, num73, num3, "", false, num64, str42, (long)0, num69, this.UserID, this.CreatedDate);
                                    }
                                }
                            }
                        }

                    }

                    list_POs.Add(estimateID);
                }
                #endregion

                #region CREATING DELIVERY NOTES



                ////////////////--------------------------------- start delivery note
                ///

                if (this.chkDeliveryNote.Checked)
                {
                    //BaseClass baseClass = new BaseClass();
                    //string str2 = this.commclass.date_Check_new(this.DateFormat, baseClass.SpecialEncode(this.txtdeliverydate.Text), this.CompanyID);
                    string pODN1 = string.Empty;
                    foreach (DataRow row36 in EstimateBasePage.Estimate_Select_By_EstimateID_New(this.CompanyID, this.EstimateID).Rows)
                    {
                        this.CustomerID = Convert.ToInt32(row36["CustomerID"].ToString());
                        this.AttentionID = Convert.ToInt32(row36["AttentionID"].ToString());
                        this.ShippedTo = row36["ClientName"].ToString();
                        this.DeliveryAddID = Convert.ToInt64(row36["DeliveryAddressID"].ToString());
                        this.DelAddType = row36["DeliveryAddressType"].ToString();
                        this.RefNo = row36["JobNumber"].ToString();
                        this.DeliveryCostCentreID = (long)Convert.ToUInt32(row36["costcentreID"]);
                    }
                    string empty23 = string.Empty;
                    string empty24 = string.Empty;
                    foreach (DataRow dataRow36 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Footer").Rows)
                    {
                        empty23 = dataRow36["PhraseText"].ToString();
                    }
                    foreach (DataRow row37 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Header").Rows)
                    {
                        empty24 = row37["PhraseText"].ToString();
                    }
                    this.DelNO = this.objCom.settings_lastcounter_select(this.CompanyID, "d");
                    long delNO = (long)10000000 + this.DelNO;
                    this.StrDelNum = string.Concat(this.DeliveryNotePrefix, delNO.ToString().Substring(1, delNO.ToString().Length - 1));
                    this.DeliveyDate = P2JParseDate(str2);
                    this.OrderNo = this.hid_TxtOrderNo.Value;
                    long num75 = (long)0;
                    int num76 = 0;
                    string empty25 = string.Empty;
                    string empty26 = string.Empty;
                    int jobStatusID = SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Note");
                    if (jobStatusID == 0)
                    {
                        jobStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                    }
                    DateTime dateTime2 = Convert.ToDateTime("1900-01-01 00:00:00.000");
                    string empty27 = string.Empty;
                    foreach (DataRow dataRow37 in OrderBasePage.Order_select(this.CompanyID, this.ordid).Rows)
                    {
                        empty27 = dataRow37["Comments"].ToString();
                    }

                    if (!list.Contains(estimateID))
                    {
                        num77 = DeliveryBasePage.delivery_insert(this.DeliveryID, this.CompanyID, this.EstimateID, num75, "E", this.CustomerID, this.AttentionID, this.ShippedTo, this.DeliveryAddID, this.DelAddType, empty23, empty27, this.StrDelNum, this.DeliveyDate, this.RefNo, this.OrderNo, false, num76, this.UserID, jobStatusID, this.CreatedDate, this.UserID, this.DelNO, empty24, this.TodayDate, this.CustomerID, empty25, empty26, dateTime2, this.DeliveryCostCentreID, this.DeliveryNotePrefix);
                    }

                    DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num77, Convert.ToInt32(this.AccountingID));
                    DataTable dataTable8 = JobBasePage.Job_Card_Info_Select_By_JobID(this.JobID);
                    this.commclass.SendMailOnDeliveryStatusChange(Convert.ToInt64(this.CompanyID), num77, Convert.ToInt64(jobStatusID), "Delivery");
                    foreach (DataRow row38 in dataTable8.Rows)
                    {
                        long num78 = Convert.ToInt64(row38["EstimateItemID"]);
                        int num79 = Convert.ToInt32(row38["QtyNumber"]);
                        string str46 = row38["ItemType"].ToString();
                        string empty28 = string.Empty;
                        string empty29 = string.Empty;
                        long num80 = (long)0;
                        this.AttachmentUpdate_PO_DN(this.EstimateID, num78, num77, "DeliveryNote");
                        DataTable dataTable9 = EstimatesBasePage.estimate_delivery_quantity_details_select(this.CompanyID, this.EstimateID, num78, str46, "job");
                        foreach (DataRow dataRow38 in dataTable9.Rows)
                        {
                            empty29 = dataRow38["Quantity"].ToString();
                        }
                        pODN1 = this.commclass.ItemDescriptionToPO_DN(this.CompanyID, num78, "DeliveryNote", ref empty28);
                        string empty30 = string.Empty;
                        foreach (DataRow row39 in EstimatesBasePage.item_select_itemDescription_foralltypes(this.CompanyID, num78, "X").Rows)
                        {
                            pODN1 = (row39["ItemTitle"].ToString() == "" ? string.Concat(row39["ItemTitle"].ToString(), "\n", pODN1) : string.Concat("Job Name: ", row39["ItemTitle"].ToString(), "\n", pODN1));
                        }
                        if (str46.ToLower() == "c" || str46.ToLower() == "x")
                        {
                            num79 = JobBasePage.Job_Item_QuantityNumber_Select(this.CompanyID, num78);
                            DataSet dataSet10 = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num78, num79, str46);
                            DataTable item2 = dataSet10.Tables[0];
                            if (item2.Rows.Count <= 0)
                            {
                                DeliveryBasePage.deliveryitem_insert(this.CompanyID, num80, num77, this.EstimateID, num78, str46, empty29, pODN1, (long)1, "", (long)0);
                            }
                            else
                            {
                                foreach (DataRow dataRow39 in item2.Rows)
                                {
                                    if (!list_del.Contains(num78))
                                    {


                                        long num81 = Convert.ToInt64(dataRow39["PriceCatalogueID"]);
                                        DataTable dataTable10 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num81);
                                        if (dataTable10.Rows.Count <= 0)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num80, num77, this.EstimateID, num78, str46, empty29, pODN1, num81);
                                        }
                                        else if (dataTable10.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num80, num77, this.EstimateID, num78, str46, empty29, pODN1, num81);
                                        }
                                        else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num80, num77, this.EstimateID, num78, str46, empty29, pODN1, num81);
                                        }
                                        else if (dataTable10.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                                        {
                                            DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num80, num77, this.EstimateID, num78, str46, empty29, pODN1, num81);
                                        }
                                        else
                                        {
                                            foreach (DataRow row40 in PurchaseBasePage.Kit_Details(num81).Rows)
                                            {
                                                int num82 = Convert.ToInt16(empty29) * Convert.ToInt16(row40["Quantity"]);
                                                string str47 = PurchaseBasePage.KitItemDescription(this.CompanyID, Convert.ToInt64(row40["KitItemID"])).Replace("»", "\n");
                                                DeliveryBasePage.deliveryitem_insert_withProductID(this.CompanyID, num80, num77, this.EstimateID, num78, str46, num82.ToString(), str47, Convert.ToInt64(row40["KitItemID"].ToString()));
                                            }
                                        }

                                        list_del.Add(num78);
                                    }
                                }
                            }
                        }
                        else
                        {
                            DeliveryBasePage.deliveryitem_insert(this.CompanyID, num80, num77, this.EstimateID, num78, str46, empty29, pODN1, (long)1, "", (long)0);
                        }
                    }
                }
                string empty31 = string.Empty;
                string empty32 = string.Empty;
                long num83 = (long)0;
                foreach (DataRow dataRow40 in EstimatesBasePage.select_details_for_JobActivity_History(this.CompanyID, this.JobID).Rows)
                {
                    empty31 = dataRow40["Estimatenumber"].ToString();
                    empty32 = dataRow40["jobnumber"].ToString();
                    this.PONO = dataRow40["PONO"].ToString();
                    this.StrDelNum = dataRow40["DeliveryNumber"].ToString();
                    Convert.ToInt64(dataRow40["PurchaseID"].ToString());
                    num83 = Convert.ToInt64(dataRow40["DeliveryID"].ToString());
                }


                this.objnotes.Estimate_number = empty31;
                string str48 = empty7.ToString().Trim();
                chrArray = new char[] { ',' };
                string[] strArrays21 = str48.Split(chrArray);
                string empty33 = string.Empty;
                if ((int)strArrays21.Length > 0)
                {
                    for (int u = 0; u < (int)strArrays21.Length; u++)
                    {
                        if (!empty33.ToString().ToLower().Trim().Contains(strArrays21[u].ToString().ToLower().Trim()))
                        {
                            empty33 = (empty33 == "" ? strArrays21[u].ToString() : string.Concat(empty33, ", ", strArrays21[u].ToString()));
                        }
                    }
                }
                this.objnotes.ModuleName = "job";
                this.objnotes.Po_number = this.PONO;
                this.objnotes.Delivery_number = this.StrDelNum;
                this.objnotes.Job_number = empty32;
                if (this.chkDeliveryNote.Checked && this.chkRaisePOBasedOnEstiItemIDCommon)
                {
                    if (this.Module != "order")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstProgWithPOandDel);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdProgWithPOandDel);
                    }
                    this.objnotes.Po_Attachment = empty33;
                    this.objnotes.Delivery_Attachment = string.Concat(this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", num83);
                }
                else if (!this.chkDeliveryNote.Checked && this.chkRaisePOBasedOnEstiItemIDCommon)
                {
                    if (this.Module != "order")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstProgWithPO);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdProgWithPO);
                    }
                    this.objnotes.Po_Attachment = empty33;
                }
                else if (this.chkDeliveryNote.Checked && !this.chkRaisePOBasedOnEstiItemIDCommon)
                {
                    if (this.Module != "order")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstProgWithDel);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdProgWithDel);
                    }
                    this.objnotes.Delivery_Attachment = string.Concat(this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", num83);
                }
                else if (!this.chkDeliveryNote.Checked && !this.chkRaisePOBasedOnEstiItemIDCommon)
                {
                    if (this.Module != "order")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstProgWithOutPOandDel);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdProgWithOutPOandDel);
                    }
                }
                this.objnotes.ModuleID = this.JobID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass6 = this.commclass;
                DateTime now2 = DateTime.Now;
                _notesclass.Created_Date = _commonClass6.Eprint_return_DateTime_Before_View(now2.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                if (this.Module != "order")
                {
                    this.objnotes.ModuleName = "estimate";
                }
                else
                {
                    this.objnotes.ModuleName = "webstoreorder";
                }
                this.objnotes.ModuleID = this.EstimateID;
                this.objN.NotesAdd(this.objnotes);
                //for (int v = 0; v < (int)strArrays5.Length; v++)
                //{
                //    if (!string.IsNullOrEmpty(strArrays5[v]))
                //    {
                //        string str49 = strArrays5[v];
                //        chrArray = new char[] { '»' };
                //        string[] strArrays22 = str49.Split(chrArray);
                //        long num84 = Convert.ToInt64(strArrays22[0]);
                //        string str50 = strArrays22[1];
                //        if (strArrays4.Contains<string>(num84.ToString()))
                //        {
                //            foreach (DataRow row41 in JobBasePage.QuickLinks_ItemDetials_Select(this.CompanyID, num84).Rows)
                //            {
                //                empty31 = (this.Module != "order" ? row41["EstimateItemNumber"].ToString() : row41["OrderItemNumber"].ToString());
                //                empty32 = row41["JobItemNumber"].ToString();
                //            }
                //            this.objnotes.Item_number = empty31;
                //            this.objnotes.Job_number = empty32;
                //            this.objnotes.ModuleID = this.JobID;
                //            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                //            notesclass _notesclass1 = this.objnotes;
                //            commonClass _commonClass7 = this.commclass;
                //            DateTime now1 = DateTime.Now;
                //            _notesclass1.Created_Date = _commonClass7.Eprint_return_DateTime_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                //            this.objnotes.CompanyID = this.CompanyID;
                //            this.objnotes.UserID = this.UserID;
                //            this.objnotes.ItemID = num84;
                //            if (this.Module != "order")
                //            {
                //                this.objnotes.ModuleName = "estimate";
                //                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemProgtoJob);
                //            }
                //            else
                //            {
                //                this.objnotes.ModuleName = "webstoreorder";
                //                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderItemProgtoJob);
                //            }
                //            this.objN.NotesAdd(this.objnotes);
                //        }
                //    }
                //}
                if (this.chkDeliveryNote.Checked)
                {
                    long num85 = (long)0;
                    foreach (DataRow dataRow41 in EstimatesBasePage.select_details_for_JobActivity_History(this.CompanyID, this.JobID).Rows)
                    {
                        empty32 = dataRow41["jobnumber"].ToString();
                        this.StrDelNum = dataRow41["DeliveryNumber"].ToString();
                        num85 = Convert.ToInt64(dataRow41["DeliveryID"].ToString());
                    }
                    this.objnotes.ModuleName = "delivery";
                    this.objnotes.Delivery_number = this.StrDelNum;
                    this.objnotes.Job_number = empty32;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelCreatedFromJob);
                    this.objnotes.ModuleID = num85;
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass2 = this.objnotes;
                    commonClass _commonClass8 = this.commclass;
                    DateTime now_ = DateTime.Now;
                    _notesclass2.Created_Date = _commonClass8.Eprint_return_DateTime_Before_View(now_.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objnotes.ItemID = (long)0;
                    this.objN.NotesAdd(this.objnotes);
                }
                list.Add(estimateID);


                ////////////---------------------------------------------------
                //////////////////// end delivery note/////////////////////////
                ///////////----------------------------------------------------

                #endregion
            }

            ///---------------------------------------------

            //-----------------------------------------------------------------




            object[] item_;
            HttpResponse httpResponse = base.Response;
            item_ = new object[] { this.strSitepath, "orders/order_view.aspx" };
            httpResponse.Redirect(string.Concat(item_));
            return "";
        }

        public void RaisePoPlhBind_SplitItem(string IDsSelectedList)
        {
            object[] item;
            long num = (long)0;
            char[] chrArray = new char[] { '±' };
            string[] strArrays = IDsSelectedList.Split(chrArray);
            string empty = string.Empty;
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string str = strArrays[i].ToString();
                chrArray = new char[] { '»' };
                string[] strArrays1 = str.Split(chrArray);
                empty = string.Concat(empty, strArrays1[0].ToString(), "±");
            }
            chrArray = new char[] { '±' };
            string[] strArrays2 = empty.Split(chrArray);
            DataTable dataTable = EstimatesBasePage.estimate_itemandsubitem_select(this.EstimateID);
            if (IDsSelectedList != "")
            {
                this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                this.plhRaisePO.Controls.Add(new LiteralControl("<div class='bgLabel'>"));
                this.plhRaisePO.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Raise_Purchase_Order") ?? ""));
                this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                this.plhRaisePO.Controls.Add(new LiteralControl("<div class='raisepoplcholder' style='word-break: break-all;'>"));
            }
            foreach (DataRow row in dataTable.Rows)
            {
                string str1 = "";
                if (row["SupplierName"].ToString() != "")
                {
                    str1 = string.Concat(" (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                }
                if (!Convert.ToBoolean(row["isparentitem"]))
                {
                    continue;
                }
                long num1 = Convert.ToInt64(row["EstimateItemID"]);
                string str2 = row["Estimatetype"].ToString();
                string str3 = this.objBC.SpecialDecode(row["EstimateItemTitle"].ToString().Replace("<br/>", " - "));
                DataSet dataSet = new DataSet();
                if (!strArrays2.Contains<string>(num1.ToString()))
                {
                    continue;
                }
                if (string.Compare(str2, "S", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str4 = "";
                    if (row["SupplierName"].ToString() != "")
                    {
                        str4 = string.Concat("  (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                    }
                    checkBox.Text = string.Concat(str3, str4);
                    checkBox.ToolTip = string.Concat(str3, str4);
                    if (checkBox.Text.Length > 42)
                    {
                        checkBox.Text = string.Concat(checkBox.Text.Substring(0, 42), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num2 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays3 = value.Split(chrArray);
                        for (int j = 0; j < (int)strArrays3.Length; j++)
                        {
                            if (strArrays3[0].Contains(num1.ToString()))
                            {
                                string str5 = strArrays3[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays4 = str5.Split(chrArray);
                                num2 = Convert.ToInt32(strArrays4[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num2);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "P", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox1 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str6 = "";
                    if (row["SupplierName"].ToString() != "")
                    {
                        str6 = string.Concat("  (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                    }
                    checkBox1.Text = string.Concat(str3, str6);
                    checkBox1.ToolTip = string.Concat(str3, str6);
                    if (checkBox1.Text.Length > 42)
                    {
                        checkBox1.Text = string.Concat(checkBox1.Text.Substring(0, 42), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox1);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num3 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value1 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays5 = value1.Split(chrArray);
                        for (int k = 0; k < (int)strArrays5.Length; k++)
                        {
                            if (strArrays5[0].Contains(num1.ToString()))
                            {
                                string str7 = strArrays5[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays6 = str7.Split(chrArray);
                                num3 = Convert.ToInt32(strArrays6[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num3);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "L", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div style='margin-left:2%;'>"));
                    this.plhRaisePO.Controls.Add(new LiteralControl(str3));
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num4 = 0;
                    string empty1 = string.Empty;
                    foreach (DataRow dataRow in EstimatesBasePage.Materials_select_ForPOCreate(num1).Rows)
                    {
                        item = new object[] { empty1, dataRow["MaterialID"], "_", num4, "▼" };
                        empty1 = string.Concat(item);
                        this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                        CheckBox isDefaultPO = new CheckBox();
                        item = new object[] { "chkRaisePO_", dataRow["EstimateItemID"], "_", dataRow["MaterialID"], "_", num4 };
                        isDefaultPO.ID = string.Concat(item);
                        isDefaultPO.Checked = this.IsDefaultPO;
                        isDefaultPO.Text = dataRow["MaterialName"].ToString();
                        string str8 = "";
                        if (row["SupplierName"].ToString() != "")
                        {
                            str8 = string.Concat("  (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                        }
                        isDefaultPO.Text = string.Concat(str3, str8);
                        isDefaultPO.ToolTip = string.Concat(str3, str8);
                        if (isDefaultPO.Text.Length > 42)
                        {
                            isDefaultPO.Text = string.Concat(isDefaultPO.Text.Substring(0, 42), "..");
                        }
                        this.plhRaisePO.Controls.Add(isDefaultPO);
                        this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                        num4++;
                    }
                    ControlCollection controls = this.plhRaisePO.Controls;
                    item = new object[] { "<label id='lblMaterialIds_", num1, "' style='display: none;'>", empty1, "</label>" };
                    controls.Add(new LiteralControl(string.Concat(item)));
                    int num5 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value2 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays7 = value2.Split(chrArray);
                        for (int l = 0; l < (int)strArrays7.Length; l++)
                        {
                            if (strArrays7[0].Contains(num1.ToString()))
                            {
                                string str9 = strArrays7[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays8 = str9.Split(chrArray);
                                num5 = Convert.ToInt32(strArrays8[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num5);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "B", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox2 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str10 = "";
                    if (row["SupplierName"].ToString() != "")
                    {
                        str10 = string.Concat("  (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                    }
                    checkBox2.Text = string.Concat(str3, str10);
                    checkBox2.ToolTip = string.Concat(str3, str10);
                    if (checkBox2.Text.Length > 42)
                    {
                        checkBox2.Text = string.Concat(checkBox2.Text.Substring(0, 42), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox2);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num6 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value3 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays9 = value3.Split(chrArray);
                        for (int m = 0; m < (int)strArrays9.Length; m++)
                        {
                            if (strArrays9[0].Contains(num1.ToString()))
                            {
                                string str11 = strArrays9[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays10 = str11.Split(chrArray);
                                num6 = Convert.ToInt32(strArrays10[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num6);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "O", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox3 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    Label label = new Label();
                    string value4 = this.hdn_getselected_supplier.Value;
                    string value5 = this.hid_Progress_Items.Value;
                    chrArray = new char[] { '±' };
                    string[] strArrays11 = value5.Split(chrArray);
                    string[] strArrays12 = null;
                    num = num1;
                    int num7 = 1;
                    while (num7 < (int)strArrays11.Length)
                    {
                        if (!strArrays11[num7 - 1].Contains("O") || !strArrays11[num7 - 1].Contains(num1.ToString()))
                        {
                            num7++;
                        }
                        else
                        {
                            string str12 = strArrays11[num7 - 1];
                            chrArray = new char[] { '»' };
                            strArrays12 = str12.Split(chrArray);
                            break;
                        }
                    }
                    if (strArrays12 != null)
                    {
                        if (strArrays12.Contains<string>("O"))
                        {
                            value4 = strArrays12[2];
                        }
                        item_progress_to_job_from_order_view usercontrolItemItemSummaryProgressToJob = this;
                        usercontrolItemItemSummaryProgressToJob.l = usercontrolItemItemSummaryProgressToJob.l + 1;
                    }
                    if (strArrays12 == null && !this.hid_Progress_Items.Value.Contains(num1.ToString()))
                    {
                        label.Text = string.Concat("  (", this.objBC.SpecialDecode(row["SupplierName"].ToString()), ")");
                    }
                    string value6 = this.hdn_suppliername1.Value;
                    chrArray = new char[] { ',' };
                    string[] strArrays13 = value6.Split(chrArray);
                    string value7 = this.hdn_suppliername2.Value;
                    chrArray = new char[] { ',' };
                    string[] strArrays14 = value7.Split(chrArray);
                    string value8 = this.hdn_suppliername3.Value;
                    chrArray = new char[] { ',' };
                    string[] strArrays15 = value8.Split(chrArray);
                    string value9 = this.hdn_suppliername4.Value;
                    chrArray = new char[] { ',' };
                    string[] strArrays16 = value9.Split(chrArray);
                    if (value4 == "1")
                    {
                        label.Text = string.Concat("  (", this.objBC.SpecialDecode(strArrays13[this.l - 1]), ")");
                    }
                    if (value4 == "2")
                    {
                        label.Text = string.Concat("  (", this.objBC.SpecialDecode(strArrays14[this.l - 1]), ")");
                    }
                    if (value4 == "3")
                    {
                        if (this.l == 3)
                        {
                            label.Text = string.Concat("  (", this.objBC.SpecialDecode(strArrays15[this.l - 3]), ")");
                        }
                        else
                        {
                            label.Text = string.Concat("  (", this.objBC.SpecialDecode(strArrays15[this.l - 1]), ")");
                        }
                    }
                    if (value4 == "4")
                    {
                        label.Text = string.Concat("  (", this.objBC.SpecialDecode(strArrays16[this.l - 1]), ")");
                    }
                    string str13 = string.Concat(str3, this.objBC.SpecialDecode(label.Text));
                    checkBox3.ToolTip = str13;
                    checkBox3.Text = string.Concat(str3, label.Text);
                    if (str13.Length <= 42)
                    {
                        checkBox3.Text = string.Concat(str3, label.Text);
                    }
                    else
                    {
                        checkBox3.Text = string.Concat(checkBox3.Text.Substring(0, 42), "..");
                    }
                    label.Text = this.objBC.SpecialDecode(label.Text);
                    this.plhRaisePO.Controls.Add(checkBox3);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num8 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value10 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays17 = value10.Split(chrArray);
                        for (int n = 0; n < (int)strArrays17.Length; n++)
                        {
                            if (strArrays17[0].Contains(num1.ToString()))
                            {
                                string str14 = strArrays17[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays18 = str14.Split(chrArray);
                                num8 = Convert.ToInt32(strArrays18[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num8);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "C", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox4 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str15 = "";
                    string str16 = this.objBC.SpecialDecode(row["SupplierName"].ToString());
                    if (str16 != "")
                    {
                        str15 = string.Concat("  (", str16, ")");
                    }
                    string str17 = string.Concat(str3, str15);
                    checkBox4.ToolTip = str17;
                    if (str17.Length <= 46)
                    {
                        checkBox4.Text = str17;
                    }
                    else
                    {
                        checkBox4.Text = string.Concat(str17.Substring(0, 46), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox4);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    foreach (DataRow row1 in EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(num1).Rows)
                    {
                        this.plhRaisePO.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                        CheckBox isDefaultPO1 = new CheckBox();
                        item = new object[] { "chkRaisePO_PrAdIt_", num1, "_", row1["EstimateAdditionalItemID"].ToString() };
                        isDefaultPO1.ID = string.Concat(item);
                        isDefaultPO1.Checked = this.IsDefaultPO;
                        isDefaultPO1.Text = this.objBC.SpecialDecode(row1["EstimateOtherCostName"].ToString());
                        string str18 = "";
                        if (row1["AdditionalItemsSupplierName"].ToString() != "")
                        {
                            str18 = string.Concat("  (", this.objBase.SpecialDecode(row1["AdditionalItemsSupplierName"].ToString()), ")");
                        }
                        string str19 = string.Concat(isDefaultPO1.Text, str18);
                        if (str19.Length <= 41)
                        {
                            isDefaultPO1.Text = str19;
                        }
                        else
                        {
                            isDefaultPO1.Text = string.Concat(str19.Substring(0, 41), "..");
                        }
                        isDefaultPO1.ToolTip = str19;
                        this.plhRaisePO.Controls.Add(isDefaultPO1);
                        this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                        HiddenField hiddenField = this.hdnProductAddItemsIDs;
                        item = new object[] { this.hdnProductAddItemsIDs.Value, num1, "_", row1["EstimateAdditionalItemID"].ToString(), "±" };
                        hiddenField.Value = string.Concat(item);
                    }
                    int num9 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value11 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays19 = value11.Split(chrArray);
                        for (int o = 0; o < (int)strArrays19.Length; o++)
                        {
                            if (strArrays19[0].Contains(num1.ToString()))
                            {
                                string str20 = strArrays19[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays20 = str20.Split(chrArray);
                                num9 = Convert.ToInt32(strArrays20[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num9);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "W", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox5 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str21 = "";
                    string str22 = row["SupplierName"].ToString();
                    string str23 = "";
                    if (str22 != "")
                    {
                        str21 = string.Concat("  (", str22, ")");
                    }
                    str21 = this.objBC.SpecialDecode(str21);
                    str23 = string.Concat(str3, str21);
                    checkBox5.ToolTip = str23;
                    if (str23.Length <= 47)
                    {
                        checkBox5.Text = str23;
                    }
                    else
                    {
                        checkBox5.Text = string.Concat(str23.Substring(0, 46), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox5);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num10 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value12 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays21 = value12.Split(chrArray);
                        for (int p = 0; p < (int)strArrays21.Length; p++)
                        {
                            if (strArrays21[0].Contains(num1.ToString()))
                            {
                                string str24 = strArrays21[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays22 = str24.Split(chrArray);
                                num10 = Convert.ToInt32(strArrays22[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num10);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "F", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox6 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str25 = "";
                    if (row["SupplierName"].ToString() != "")
                    {
                        str25 = string.Concat("  (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                    }
                    checkBox6.Text = string.Concat(str3, str25);
                    checkBox6.ToolTip = string.Concat(str3, str25);
                    if (checkBox6.Text.Length > 42)
                    {
                        checkBox6.Text = string.Concat(checkBox6.Text.Substring(0, 42), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox6);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num11 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value13 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays23 = value13.Split(chrArray);
                        for (int q = 0; q < (int)strArrays23.Length; q++)
                        {
                            if (strArrays23[0].Contains(num1.ToString()))
                            {
                                string str26 = strArrays23[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays24 = str26.Split(chrArray);
                                num11 = Convert.ToInt32(strArrays24[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num11);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "D", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox7 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str27 = "";
                    if (row["SupplierName"].ToString() != "")
                    {
                        str27 = string.Concat("  (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                    }
                    checkBox7.Text = string.Concat(str3, str27);
                    checkBox7.ToolTip = string.Concat(str3, str27);
                    if (checkBox7.Text.Length > 42)
                    {
                        checkBox7.Text = string.Concat(checkBox7.Text.Substring(0, 42), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox7);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num12 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value14 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays25 = value14.Split(chrArray);
                        for (int r = 0; r < (int)strArrays25.Length; r++)
                        {
                            if (strArrays25[0].Contains(num1.ToString()))
                            {
                                string str28 = strArrays25[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays26 = str28.Split(chrArray);
                                num12 = Convert.ToInt32(strArrays26[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num12);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "N", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox8 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str29 = "";
                    if (row["SupplierName"].ToString() != "")
                    {
                        str29 = string.Concat("  (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                    }
                    checkBox8.Text = string.Concat(str3, str29);
                    checkBox8.ToolTip = string.Concat(str3, str29);
                    if (checkBox8.Text.Length > 42)
                    {
                        checkBox8.Text = string.Concat(checkBox8.Text.Substring(0, 42), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox8);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num13 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value15 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays27 = value15.Split(chrArray);
                        for (int s = 0; s < (int)strArrays27.Length; s++)
                        {
                            if (strArrays27[0].Contains(num1.ToString()))
                            {
                                string str30 = strArrays27[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays28 = str30.Split(chrArray);
                                num13 = Convert.ToInt32(strArrays28[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num13);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "K", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox9 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str31 = "";
                    if (row["SupplierName"].ToString() != "")
                    {
                        str31 = string.Concat("  (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                    }
                    checkBox9.Text = string.Concat(str3, str31);
                    checkBox9.ToolTip = string.Concat(str3, str31);
                    if (checkBox9.Text.Length > 42)
                    {
                        checkBox9.Text = string.Concat(checkBox9.Text.Substring(0, 42), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox9);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num14 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value16 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays29 = value16.Split(chrArray);
                        for (int t = 0; t < (int)strArrays29.Length; t++)
                        {
                            if (strArrays29[0].Contains(num1.ToString()))
                            {
                                string str32 = strArrays29[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays30 = str32.Split(chrArray);
                                num14 = Convert.ToInt32(strArrays30[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num14);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "Q", true) == 0)
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox10 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    this.plhRaisePO.Controls.Add(checkBox10);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, 0);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else if (string.Compare(str2, "u", true) != 0)
                {
                    if (string.Compare(str2, "X", true) != 0)
                    {
                        continue;
                    }
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox11 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    this.plhRaisePO.Controls.Add(checkBox11);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    checkBox11.Text = string.Concat(str3, str1);
                    checkBox11.ToolTip = string.Concat(str3, str1);
                    if (checkBox11.Text.Length > 45)
                    {
                        checkBox11.Text = string.Concat(checkBox11.Text.Substring(0, 45), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox11);
                    foreach (DataRow dataRow1 in EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(num1).Rows)
                    {
                        this.plhRaisePO.Controls.Add(new LiteralControl("<div style='margin-left:10%;'>"));
                        CheckBox isDefaultPO2 = new CheckBox();
                        item = new object[] { "chkRaisePO_PrAdIt_", num1, "_", dataRow1["EstimateAdditionalItemID"].ToString() };
                        isDefaultPO2.ID = string.Concat(item);
                        isDefaultPO2.Checked = this.IsDefaultPO;
                        isDefaultPO2.Text = this.objBC.SpecialDecode(dataRow1["EstimateOtherCostName"].ToString());
                        string str33 = "";
                        if (dataRow1["AdditionalItemsSupplierName"].ToString() != "")
                        {
                            str33 = string.Concat("  (", this.objBase.SpecialDecode(dataRow1["AdditionalItemsSupplierName"].ToString()), ")");
                        }
                        string str34 = string.Concat(isDefaultPO2.Text, str33);
                        if (str34.Length <= 41)
                        {
                            isDefaultPO2.Text = str34;
                        }
                        else
                        {
                            isDefaultPO2.Text = string.Concat(str34.Substring(0, 41), "..");
                        }
                        isDefaultPO2.ToolTip = str34;
                        this.plhRaisePO.Controls.Add(isDefaultPO2);
                        this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                        HiddenField hiddenField1 = this.hdnProductAddItemsIDs;
                        item = new object[] { this.hdnProductAddItemsIDs.Value, num1, "_", dataRow1["EstimateAdditionalItemID"].ToString(), "±" };
                        hiddenField1.Value = string.Concat(item);
                    }
                    int num15 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value17 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays31 = value17.Split(chrArray);
                        for (int u = 0; u < (int)strArrays31.Length; u++)
                        {
                            if (strArrays31[0].Contains(num1.ToString()))
                            {
                                string str35 = strArrays31[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays32 = str35.Split(chrArray);
                                num15 = Convert.ToInt32(strArrays32[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num15);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
                else
                {
                    this.plhRaisePO.Controls.Add(new LiteralControl("<div>"));
                    CheckBox checkBox12 = new CheckBox()
                    {
                        ID = string.Concat("chkRaisePO_", num1),
                        Checked = this.IsDefaultPO,
                        Text = str3
                    };
                    string str36 = "";
                    if (row["SupplierName"].ToString() != "")
                    {
                        str36 = string.Concat("  (", this.objBase.SpecialDecode(row["SupplierName"].ToString()), ")");
                    }
                    checkBox12.Text = string.Concat(str3, str36);
                    checkBox12.ToolTip = string.Concat(str3, str36);
                    if (str3.Length + str36.Length > 45)
                    {
                        checkBox12.Text = string.Concat(checkBox12.Text.Substring(0, 45), "..");
                    }
                    this.plhRaisePO.Controls.Add(checkBox12);
                    this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
                    int num16 = 0;
                    if (this.hid_Progress_Items.Value != "")
                    {
                        string value18 = this.hid_Progress_Items.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays33 = value18.Split(chrArray);
                        for (int v = 0; v < (int)strArrays33.Length; v++)
                        {
                            if (strArrays33[0].Contains(num1.ToString()))
                            {
                                string str37 = strArrays33[0];
                                chrArray = new char[] { '»' };
                                string[] strArrays34 = str37.Split(chrArray);
                                num16 = Convert.ToInt32(strArrays34[2]);
                            }
                        }
                    }
                    dataSet = EstimatesBasePage.estimate_itemtitle_select(this.CompanyID, num1, str2, num16);
                    this.BindSubItems(dataSet, this.plhRaisePO, this.IsDefaultPO);
                }
            }
            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
            this.plhRaisePO.Controls.Add(new LiteralControl("</div>"));
        }

        public void SubItem_Purchase_Order_InsertNew_Subitems(DataSet ds, string StrJobNum, int StatusID, long EstimateID, int UserID, int CompanyID, Hashtable htInventory, long EstimateItemID, string DateFormat, string CustomerName, string EstimateItemIDForRaisePO, out string AddPurchaseOrders, string Delivery_AddressType, long JobStatusID, long poNumber = 0, string isCombined = "no")
        {
            object[] item;
            BaseClass baseClass = new BaseClass();
            commonClass _commonClass = new commonClass();
            long num = (long)0;
            int num1 = 0;
            int num2 = 0;
            long num3 = (long)0;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            long num4 = (long)0;
            string value = this.hdnSubItemsIDs_PO.Value;
            char[] chrArray = new char[] { '↑' };
            string[] strArrays = value.Split(chrArray);
            DateTime now = DateTime.Now;
            string str1 = _commonClass.date_Check_new(DateFormat, _commonClass.Eprint_return_Date_Before_View(now.ToString(), CompanyID, UserID, true), CompanyID);
            DateTime dateTime = P2JParseDate(str1, DateFormat);
            long num5 = (long)0;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            int num6 = 0;
            int num7 = 0;
            decimal num8 = new decimal(0);
            string empty3 = string.Empty;
            string str3 = string.Empty;
            DataTable dataTable = new DataTable();
            string empty4 = string.Empty;
            string str4 = string.Empty;
            now = DateTime.Now.AddDays(5);
            string str5 = _commonClass.date_Check_new(DateFormat, _commonClass.Eprint_return_Date_Before_View(now.ToString(), CompanyID, UserID, true), CompanyID);
            now = DateTime.Now;
            string str6 = _commonClass.date_Check_new(DateFormat, _commonClass.Eprint_return_Date_Before_View(now.ToString(), CompanyID, UserID, true), CompanyID);
            DateTime dateTime1 = P2JParseDate(str5, DateFormat);
            DateTime dateTime2 = P2JParseDate(str6, DateFormat);
            str3 = _commonClass.Settings_inventoryStockReduction_Select((long)CompanyID);
            DataTable dataTable1 = SettingsBasePage.settings_companyprofile_select(CompanyID);
            int num9 = 0;
            num9 = Convert.ToInt32(dataTable1.Rows[0]["ProductStockManagement"]);
            string empty5 = string.Empty;
            empty5 = baseClass.Return_StockManagementSettings("SC_IfJobCancelled");
            int taxID = EstimatesBasePage.GetTaxID(CompanyID, EstimateID);
            decimal taxRate = EstimatesBasePage.GetTaxRate(CompanyID, EstimateID);
            string serverName = ConnectionClass.ServerName;
            long num10 = (long)0;
            bool flag = false;
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Delivery Instructions").Rows)
            {
                str = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in ds.Tables[2].Rows)
            {
                if (string.Compare(dataRow["PoType"].ToString(), "Outwork", true) != 0 || string.Compare(dataRow["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                string str7 = Convert.ToString(dataRow["EstimateItemID"]);
                bool flag1 = false;
                if (strArrays.Contains<string>(str7))
                {
                    flag1 = true;
                }
                if (!flag1 || Convert.ToInt32(EstimateItemIDForRaisePO) != Convert.ToInt32(str7))
                {
                    continue;
                }
                num5 = (long)0;
                empty2 = "A";
                str2 = "";
                num6 = Convert.ToInt32(dataRow["Quantity"]);
                num7 = 0;
                num8 = Convert.ToDecimal(dataRow["Price"]);
                EstimateItemID = (long)Convert.ToInt32(dataRow["EstimateItemID"].ToString());
                num1 = Convert.ToInt32(dataRow["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow["SupplierContactID"].ToString());
                num3 = Convert.ToInt64(dataRow["AddressID"].ToString());
                empty = dataRow["AddressType"].ToString();
                string str8 = SummaryClass.Split_ItemDescription(dataRow["Description"].ToString());
                string str9 = dataRow["Notes"].ToString();
                num10 = Convert.ToInt64(dataRow["DeliveryAddress"].ToString());
                if (Convert.ToInt64(dataRow["PriceCatalogueID"]) <= (long)0)
                {
                    num5 = (long)0;
                    empty2 = "A";
                }
                else
                {
                    num5 = Convert.ToInt64(dataRow["PriceCatalogueID"]);
                    empty2 = "W";
                }
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.SpecialEncode(str), "", "", dateTime, baseClass.SpecialEncode(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num10, Delivery_AddressType, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num11 = (num8 * taxRate) / new decimal(100);
                num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, str8, num6, num7, Convert.ToDecimal(num8), taxID, Convert.ToDecimal(num11), 0, str9, false, EstimateItemID, "O", (long)0, UserID, this.CreatedDate);
                foreach (DataRow row1 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row1["PONO"].ToString();
                }
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                item = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(item);
            }
            foreach (DataRow dataRow1 in ds.Tables[8].Rows)
            {
                if (string.Compare(dataRow1["PoType"].ToString(), "ProductCatalogue", true) != 0 || string.Compare(dataRow1["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                string str10 = Convert.ToString(dataRow1["EstimateItemID"]);
                bool flag2 = false;
                if (strArrays.Contains<string>(str10))
                {
                    flag2 = true;
                }
                if (!flag2 || Convert.ToInt32(EstimateItemIDForRaisePO) != Convert.ToInt32(str10))
                {
                    continue;
                }
                int num12 = taxID;
                decimal num13 = taxRate;
                num5 = (long)0;
                empty2 = "A";
                str2 = "";
                num6 = Convert.ToInt32(dataRow1["Quantity"]);
                num7 = Convert.ToInt32(dataRow1["Quantity"]);
                num8 = Convert.ToDecimal(dataRow1["Price"]);
                long num14 = Convert.ToInt64(dataRow1["PriceCatalogueID"]);
                foreach (DataRow row2 in ds.Tables[0].Rows)
                {
                    num12 = Convert.ToInt32(row2["TotalTaxId"]);
                    num13 = Convert.ToDecimal(row2["TotalTaxRate"]);
                }
                EstimateItemID = (long)Convert.ToInt32(dataRow1["EstimateItemID"].ToString());
                num10 = Convert.ToInt64(dataRow1["DeliveryAddress"].ToString());
                num1 = Convert.ToInt32(dataRow1["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow1["SupplierContactID"].ToString());
                num3 = Convert.ToInt64(dataRow1["AddressID"].ToString());
                empty = dataRow1["AddressType"].ToString();
                string str11 = SummaryClass.Split_ItemDescription(dataRow1["ItemDescription"].ToString());
                string empty6 = string.Empty;
                string empty7 = string.Empty;
                empty7 = dataRow1["Notes"].ToString();
                dataRow1["Material"].ToString();
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.SpecialEncode(str), "", "", dateTime, baseClass.SpecialEncode(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num10, Delivery_AddressType, 0, (long)0, dateTime2, this.IsFromProgreesTojob);
                this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num15 = (num8 * num13) / new decimal(100);
                DataTable dataTable2 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num14);
                if (dataTable2.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                {
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, str11, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num8), num12, Convert.ToDecimal(num15), 0, empty7, false, EstimateItemID, "C", (long)0, UserID, this.CreatedDate);
                }
                else if (num9 != 1)
                {
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, str11, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num8), num12, Convert.ToDecimal(num15), 0, empty7, false, EstimateItemID, "C", (long)0, UserID, this.CreatedDate);
                }
                else if (dataTable2.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                {
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, str11, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num8), num12, Convert.ToDecimal(num15), 0, empty7, false, EstimateItemID, "C", (long)0, UserID, this.CreatedDate);
                }
                else
                {
                    foreach (DataRow dataRow2 in PurchaseBasePage.Kit_Details(num14).Rows)
                    {
                        int num16 = num6 * Convert.ToInt16(dataRow2["Quantity"]);
                        DataTable dataTable3 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(dataRow2["KitItemID"]));
                        string str12 = dataTable3.Rows[0]["ItemCode"].ToString();
                        string str13 = PurchaseBasePage.KitItemDescription(CompanyID, Convert.ToInt64(dataRow2["KitItemID"])).Replace("»", "\n");
                        num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, Convert.ToInt64(dataRow2["KitItemID"]), "W", str12, str13, Convert.ToDecimal(num16), Convert.ToDecimal(num7), Convert.ToDecimal(num8), num12, Convert.ToDecimal(num15), 0, empty7, false, EstimateItemID, "C", (long)0, UserID, this.CreatedDate);
                    }
                }
                foreach (DataRow row3 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row3["PONO"].ToString();
                }
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                item = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(item);
                BaseClass baseClass1 = new BaseClass();
                string str14 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                string str15 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                string str16 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                string str17 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                if (flag)
                {
                    if (!(empty5 == "a") && !(empty5 == "p") || !flag)
                    {
                        continue;
                    }
                    foreach (DataRow dataRow3 in baseClass1.ProductStockType_Select((long)CompanyID, num14).Rows)
                    {
                        if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            baseClass1.StockCancellationProcess((long)CompanyID, num14, (long)0, "self", EstimateItemID, "Job", (long)UserID, empty5);
                        }
                        else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            baseClass1.StockCancellationProcess((long)CompanyID, (long)0, num14, "other", EstimateItemID, "Job", (long)UserID, empty5);
                        }
                        else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                        {
                            if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                continue;
                            }
                            baseClass1.StockCancellationProcess((long)CompanyID, num14, (long)0, "multiple", EstimateItemID, "Job", (long)UserID, empty5);
                        }
                        else
                        {
                            baseClass1.StockCancellationProcess((long)CompanyID, num14, (long)0, "additional option", EstimateItemID, "Job", (long)UserID, empty5);
                        }
                    }
                }
                else
                {
                    if (str14 == "e")
                    {
                        foreach (DataRow row4 in baseClass1.ProductStockType_Select((long)CompanyID, num14).Rows)
                        {
                            if (row4["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass1.StockAllocationProcess((long)CompanyID, num14, (long)0, num6, str15, "self", Convert.ToBoolean(str16), EstimateItemID, "Job", num8, (long)UserID);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num14, num4);
                            }
                            else if (row4["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass1.StockAllocation_Others((long)CompanyID, num14, num6, str15, Convert.ToBoolean(str16), EstimateItemID, "Job", num8, (long)UserID);
                            }
                            else if (row4["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row4["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)CompanyID, num14, (long)0, num6, str15, "multiple", Convert.ToBoolean(str16), EstimateItemID, "Job", num8, (long)UserID);
                            }
                            else
                            {
                                baseClass1.StockAllocationForAdditionalOption((long)CompanyID, num14, num6, str15, "additional option", Convert.ToBoolean(str16), EstimateItemID, "Job", num8, (long)UserID);
                                PurchaseBasePage.ProgressToJob_StockItem_Update(num14, num4);
                            }
                        }
                    }
                    if (!(str17 == "j") || !(baseClass1.Return_StockManagementSettings("SR_JobStatusID") == JobStatusID.ToString()))
                    {
                        continue;
                    }
                    foreach (DataRow dataRow4 in baseClass1.ProductStockType_Select((long)CompanyID, num14).Rows)
                    {
                        if (dataRow4["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            baseClass1.StockReductionProcess((long)CompanyID, num14, (long)0, "self", num6, EstimateItemID, "Job", (long)UserID, num8);
                            PurchaseBasePage.ProgressToJob_StockItem_Update(num14, num4);
                        }
                        else if (dataRow4["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            baseClass1.StockReductionProcess((long)CompanyID, (long)0, num14, "other", num6, EstimateItemID, "Job", (long)UserID, num8);
                        }
                        else if (dataRow4["DrawStockFrom"].ToString().ToLower() != "a")
                        {
                            if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                continue;
                            }
                            baseClass1.StockReductionProcess((long)CompanyID, num14, (long)0, "multiple", num6, EstimateItemID, "Job", (long)UserID, num8);
                        }
                        else
                        {
                            baseClass1.StockReductionProcessForAdditionalOption((long)CompanyID, num14, "additional option", num6, EstimateItemID, "Job", (long)UserID, num8);
                            PurchaseBasePage.ProgressToJob_StockItem_Update(num14, num4);
                        }
                    }
                }
            }
            foreach (DataRow row5 in ds.Tables[9].Rows)
            {
                if (string.Compare(row5["PoType"].ToString().ToLower(), "othercost", true) != 0 || string.Compare(row5["IsEmpty"].ToString().ToLower(), "no", true) != 0)
                {
                    continue;
                }
                string value1 = this.hdnSubItemsIDs_OtherCost_PO.Value;
                chrArray = new char[] { '↑' };
                string[] strArrays1 = value1.Split(chrArray);
                long num17 = Convert.ToInt64(row5["estOtherCostID"].ToString());
                string str18 = Convert.ToString(row5["estOtherCostID"]);
                bool flag3 = false;
                bool flag4 = false;
                string str19 = this.hdnOtherCostSelectedValuesRaisePO.Value.ToString();
                chrArray = new char[] { '∅' };
                string[] strArrays2 = str19.Split(chrArray);
                if ((int)strArrays2.Length > 1)
                {
                    string[] strArrays3 = strArrays2;
                    for (int i = 0; i < (int)strArrays3.Length; i++)
                    {
                        if (strArrays3[i].Contains(row5["estOtherCostID"].ToString()))
                        {
                            flag4 = true;
                        }
                    }
                }
                if (strArrays1.Contains<string>(str18.Trim()))
                {
                    this.hdnOtherCostSelectedValuesRaisePO.Value = string.Concat(this.hdnOtherCostSelectedValuesRaisePO.Value, str18, "∅");
                    flag3 = true;
                }
                if (!flag3 || flag4)
                {
                    continue;
                }
                this.chkRaisePOBasedOnEstiItemIDCommon = true;
                num6 = Convert.ToInt32(row5["Quantity"]);
                num10 = Convert.ToInt64(row5["DeliveryAddress"].ToString());
                Delivery_AddressType = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "u");
                if (Delivery_AddressType != "a")
                {
                    Delivery_AddressType = "R";
                }
                else
                {
                    Delivery_AddressType = "A";
                }
                num1 = Convert.ToInt32(row5["SupplierID"].ToString());
                num2 = Convert.ToInt32(row5["ContactID"].ToString());
                num3 = Convert.ToInt64(row5["AddressID"].ToString());
                num8 = Convert.ToDecimal(row5["cost"].ToString());
                empty3 = row5["ItemDescription"].ToString();
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.SpecialEncode(str), "", "", dateTime, baseClass.SpecialEncode(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num10, Delivery_AddressType, 0, (long)0, dateTime2, this.IsFromProgreesTojob);
                SummaryClass.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num18 = (num8 * taxRate) / new decimal(100);
                num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num8), taxID, Convert.ToDecimal(num18), 0, "", false, num17, "U", (long)0, UserID, this.CreatedDate);
                foreach (DataRow dataRow5 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = dataRow5["PONO"].ToString();
                }
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                item = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(item);
            }
            foreach (DataRow row6 in ds.Tables[4].Rows)
            {
                if (string.Compare(row6["PoType"].ToString(), "pad", true) != 0 || string.Compare(row6["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                string str20 = Convert.ToString(row6["EstimateItemID"]);
                bool flag5 = false;
                if (strArrays.Contains<string>(str20))
                {
                    flag5 = true;
                }
                if (!flag5 || Convert.ToInt32(EstimateItemIDForRaisePO) != Convert.ToInt32(str20))
                {
                    continue;
                }
                decimal num19 = new decimal(0);
                decimal num20 = new decimal(0);
                decimal num21 = new decimal(0);
                decimal num22 = new decimal(0);
                decimal num23 = new decimal(0);
                num5 = Convert.ToInt64(row6["PaperID"]);
                empty2 = "I";
                str2 = row6["InventoryCode"].ToString();
                empty3 = row6["Inventoryname"].ToString();
                num6 = Convert.ToInt32(row6["Quantity"]);
                num7 = Convert.ToInt32(row6["PackedIn"]);
                Convert.ToInt64(row6["EstimatePadItemID"]);
                num22 = Convert.ToDecimal(row6["PaperUnitPrice"]);
                Convert.ToInt32(row6["PrintLayoutValue"]);
                Convert.ToDecimal(row6["SetupSpoilage"]);
                Convert.ToDecimal(row6["RunningSpoilage"]);
                Convert.ToDecimal(row6["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(row6["EstimateItemID"].ToString());
                num23 = Convert.ToDecimal(row6["InvSheets"]);
                if (row6["LeavesPerPad"] != null)
                {
                    Convert.ToDecimal(row6["LeavesPerPad"]);
                }
                if (row6["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num20 = Convert.ToDecimal(row6["packedprice"]);
                    num8 = SummaryClass.ReturnPackedPrice(num23, num7, num20, new decimal(0), out num21);
                    num19 = num21;
                }
                else
                {
                    num8 = num23 * num22;
                }
                num1 = Convert.ToInt32(row6["SupplierID"].ToString());
                num2 = Convert.ToInt32(row6["ContactID"].ToString());
                num3 = Convert.ToInt64(row6["AddressID"].ToString());
                empty = row6["AddressType"].ToString();
                num10 = Convert.ToInt64(row6["DeliveryAddress"].ToString());
                if (row6["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.SpecialEncode(str), "", "", dateTime, baseClass.SpecialEncode(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num10, Delivery_AddressType, 0, (long)0, dateTime2, this.IsFromProgreesTojob);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num24 = (num8 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToInt32(num23), num19, Convert.ToDecimal(num8), taxID, num24, 0, "", false, EstimateItemID, "P", (long)0, UserID, this.CreatedDate);
                }
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num23), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num23));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num23);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num23), "completed", EstimateItemID);
                }
                foreach (DataRow dataRow6 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = dataRow6["PONO"].ToString();
                }
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                item = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(item);
            }
            foreach (DataRow row7 in ds.Tables[3].Rows)
            {
                if (string.Compare(row7["PoType"].ToString(), "single", true) != 0 || string.Compare(row7["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                string str21 = Convert.ToString(row7["EstimateItemID"]);
                bool flag6 = false;
                if (strArrays.Contains<string>(str21))
                {
                    flag6 = true;
                }
                if (!flag6 || Convert.ToInt32(EstimateItemIDForRaisePO) != Convert.ToInt32(str21))
                {
                    continue;
                }
                decimal num25 = new decimal(0);
                decimal num26 = new decimal(0);
                decimal num27 = new decimal(0);
                decimal num28 = new decimal(0);
                decimal num29 = new decimal(0);
                num5 = Convert.ToInt64(row7["PaperID"]);
                empty2 = "I";
                str2 = row7["InventoryCode"].ToString();
                empty3 = row7["Inventoryname"].ToString();
                num6 = Convert.ToInt32(row7["Quantity"]);
                num7 = Convert.ToInt32(row7["PackedIn"]);
                Convert.ToInt64(row7["EstimateSingleItemID"]);
                num29 = Convert.ToDecimal(row7["PaperUnitPrice"]);
                Convert.ToInt32(row7["PrintLayoutValue"]);
                Convert.ToDecimal(row7["SetupSpoilage"]);
                Convert.ToDecimal(row7["RunningSpoilage"]);
                Convert.ToDecimal(row7["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(row7["EstimateItemID"].ToString());
                num28 = Convert.ToDecimal(row7["InvSheets"]);
                if (row7["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num26 = Convert.ToDecimal(row7["packedprice"]);
                    num8 = SummaryClass.ReturnPackedPrice(num28, num7, num26, new decimal(0), out num27);
                    num25 = num27;
                }
                else
                {
                    num8 = num28 * num29;
                }
                num1 = Convert.ToInt32(row7["SupplierID"].ToString());
                num2 = Convert.ToInt32(row7["ContactID"].ToString());
                num3 = Convert.ToInt64(row7["AddressID"].ToString());
                empty = row7["AddressType"].ToString();
                num10 = Convert.ToInt64(row7["DeliveryAddress"].ToString());
                if (row7["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.SpecialEncode(str), "", "", dateTime, baseClass.SpecialEncode(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num10, Delivery_AddressType, 0, (long)0, dateTime2, this.IsFromProgreesTojob);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num30 = (num8 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToInt32(num28), num25, Convert.ToDecimal(num8), taxID, num30, 0, "", false, EstimateItemID, "S", (long)0, UserID, this.CreatedDate);
                }
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num28), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num28));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num28);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num28), "completed", EstimateItemID);
                }
                foreach (DataRow dataRow7 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = dataRow7["PONO"].ToString();
                }
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                item = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(item);
            }
            foreach (DataRow row8 in ds.Tables[6].Rows)
            {
                if (string.Compare(row8["PoType"].ToString(), "Lithosingle", true) != 0 || string.Compare(row8["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                string str22 = Convert.ToString(row8["EstimateItemID"]);
                bool flag7 = false;
                if (strArrays.Contains<string>(str22))
                {
                    flag7 = true;
                }
                if (!flag7 || Convert.ToInt32(EstimateItemIDForRaisePO) != Convert.ToInt32(str22))
                {
                    continue;
                }
                decimal num31 = new decimal(0);
                decimal num32 = new decimal(0);
                decimal num33 = new decimal(0);
                decimal num34 = new decimal(0);
                decimal num35 = new decimal(0);
                num5 = Convert.ToInt64(row8["PaperID"]);
                empty2 = "I";
                str2 = row8["InventoryCode"].ToString();
                empty3 = row8["Inventoryname"].ToString();
                num6 = Convert.ToInt32(row8["Quantity"]);
                num31 = Convert.ToDecimal(row8["PackedIn"]);
                Convert.ToInt64(row8["EstLithoItemID"]);
                num35 = Convert.ToDecimal(row8["PaperUnitPrice"]);
                Convert.ToInt32(row8["PrintLayoutValue"]);
                Convert.ToDecimal(row8["SetupSpoilage"]);
                Convert.ToDecimal(row8["RunningSpoilage"]);
                Convert.ToDecimal(row8["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(row8["EstimateItemID"].ToString());
                num34 = Convert.ToDecimal(row8["InvSheets"]);
                if (row8["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num32 = Convert.ToDecimal(row8["packedprice"]);
                    num8 = SummaryClass.ReturnPackedPrice(num34, num31, num32, new decimal(0), out num33);
                    num31 = num33;
                }
                else
                {
                    num8 = num34 * num35;
                }
                num1 = Convert.ToInt32(row8["SupplierID"].ToString());
                num2 = Convert.ToInt32(row8["ContactID"].ToString());
                num3 = Convert.ToInt64(row8["AddressID"].ToString());
                empty = row8["AddressType"].ToString();
                num10 = Convert.ToInt64(row8["DeliveryAddress"].ToString());
                if (row8["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.SpecialEncode(str), "", "", dateTime, baseClass.SpecialEncode(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num10, Delivery_AddressType, 0, (long)0, dateTime2, this.IsFromProgreesTojob);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num36 = (num8 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToDecimal(num34), Convert.ToDecimal(num31), Convert.ToDecimal(num8), taxID, num36, 0, "", false, EstimateItemID, "F", (long)0, UserID, this.CreatedDate);
                }
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num34), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num34));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num34);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num34), "completed", EstimateItemID);
                }
                dataTable = EstimatesBasePage.litho_estimate_select(CompanyID, EstimateItemID);
                foreach (DataRow dataRow8 in dataTable.Rows)
                {
                    num5 = Convert.ToInt64(dataRow8["PlateID"]);
                    empty2 = "I";
                    num6 = Convert.ToInt32(dataRow8["Noofplates"]);
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "progressed", EstimateItemID);
                    if (str3 != "e")
                    {
                        continue;
                    }
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num6));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num6);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "completed", EstimateItemID);
                }
                foreach (DataRow row9 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = row9["PONO"].ToString();
                }
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                item = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(item);
            }
            foreach (DataRow dataRow9 in ds.Tables[7].Rows)
            {
                if (string.Compare(dataRow9["PoType"].ToString(), "Lithopad", true) != 0 || string.Compare(dataRow9["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                string str23 = Convert.ToString(dataRow9["EstimateItemID"]);
                bool flag8 = false;
                if (strArrays.Contains<string>(str23))
                {
                    flag8 = true;
                }
                if (!flag8 || Convert.ToInt32(EstimateItemIDForRaisePO) != Convert.ToInt32(str23))
                {
                    continue;
                }
                decimal num37 = new decimal(0);
                decimal num38 = new decimal(0);
                decimal num39 = new decimal(0);
                decimal num40 = new decimal(0);
                decimal num41 = new decimal(0);
                decimal num42 = new decimal(0);
                num5 = Convert.ToInt64(dataRow9["PaperID"]);
                empty2 = "I";
                str2 = dataRow9["InventoryCode"].ToString();
                empty3 = dataRow9["Inventoryname"].ToString();
                num6 = Convert.ToInt32(dataRow9["Quantity"]);
                num37 = Convert.ToDecimal(dataRow9["PackedIn"]);
                Convert.ToInt64(dataRow9["EstimateLithoPadItemID"]);
                num41 = Convert.ToDecimal(dataRow9["PaperUnitPrice"]);
                Convert.ToInt32(dataRow9["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow9["SetupSpoilage"]);
                Convert.ToDecimal(dataRow9["RunningSpoilage"]);
                Convert.ToDecimal(dataRow9["PaperMarkup"]);
                if (dataRow9["LeavesPerPad"] != null)
                {
                    Convert.ToDecimal(dataRow9["LeavesPerPad"]);
                }
                EstimateItemID = (long)Convert.ToInt32(dataRow9["EstimateItemID"].ToString());
                num40 = Convert.ToDecimal(dataRow9["InvSheets"]);
                if (dataRow9["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num38 = Convert.ToDecimal(dataRow9["packedprice"]);
                    num8 = SummaryClass.ReturnPackedPrice(num40, num37, num38, new decimal(0), out num39);
                    num37 = num39;
                }
                else
                {
                    num8 = num40 * num41;
                }
                num1 = Convert.ToInt32(dataRow9["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow9["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow9["AddressID"].ToString());
                empty = dataRow9["AddressType"].ToString();
                num10 = Convert.ToInt64(dataRow9["DeliveryAddress"].ToString());
                if (dataRow9["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.SpecialEncode(str), "", "", dateTime, baseClass.SpecialEncode(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num10, Delivery_AddressType, 0, (long)0, dateTime2, this.IsFromProgreesTojob);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num43 = (num8 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, Convert.ToDecimal(num40), Convert.ToDecimal(num37), Convert.ToDecimal(num8), taxID, num43, 0, "", false, EstimateItemID, "D", (long)0, UserID, this.CreatedDate);
                }
                EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num42), "progressed", EstimateItemID);
                if (str3.ToLower() == "e")
                {
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num40));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num40);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num40), "completed", EstimateItemID);
                }
                dataTable = EstimatesBasePage.litho_pad_estimate_select(CompanyID, EstimateItemID);
                foreach (DataRow row10 in dataTable.Rows)
                {
                    num5 = Convert.ToInt64(row10["PlateID"]);
                    empty2 = "I";
                    num6 = Convert.ToInt32(row10["Noofplates"]);
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "progressed", EstimateItemID);
                    if (str3 != "e")
                    {
                        continue;
                    }
                    if (!htInventory.ContainsKey(num5))
                    {
                        htInventory.Add(num5, Convert.ToInt32(num6));
                    }
                    else
                    {
                        htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num6);
                    }
                    EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num6), "completed", EstimateItemID);
                }
                foreach (DataRow dataRow10 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    str4 = dataRow10["PONO"].ToString();
                }
                if (empty4 != "")
                {
                    empty4 = string.Concat(empty4, ", ");
                }
                item = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                empty4 = string.Concat(item);
            }
            int num44 = 0;
            foreach (DataRow row11 in ds.Tables[5].Rows)
            {
                if (string.Compare(row11["PoType"].ToString(), "large", true) == 0 && string.Compare(row11["IsEmpty"].ToString(), "No", true) == 0)
                {
                    item = new object[] { row11["EstimateItemID"], "_", row11["PaperID"], "_", num44 };
                    string str24 = string.Concat(item);
                    string value2 = this.hdnLFSubItemsIDs_PO.Value;
                    chrArray = new char[] { '\u25BC' };
                    if (value2.Split(chrArray).Contains<string>(str24))
                    {
                        decimal num45 = new decimal(0);
                        decimal num46 = new decimal(0);
                        decimal num47 = new decimal(0);
                        decimal num48 = new decimal(0);
                        decimal num49 = new decimal(0);
                        long num50 = (long)0;
                        num5 = Convert.ToInt64(row11["PaperID"]);
                        empty2 = "I";
                        str2 = row11["InventoryCode"].ToString();
                        empty3 = row11["Inventoryname"].ToString();
                        num6 = Convert.ToInt32(row11["Quantity"]);
                        num7 = Convert.ToInt32(row11["PackedIn"]);
                        Convert.ToInt64(row11["EstimateLargeItemID"]);
                        num49 = Convert.ToDecimal(row11["PaperUnitPrice"]);
                        Convert.ToInt32(row11["PrintLayoutValue"]);
                        Convert.ToDecimal(row11["SetupSpoilage"]);
                        Convert.ToDecimal(row11["RunningSpoilage"]);
                        row11["PressPaperType"].ToString();
                        EstimateItemID = (long)Convert.ToInt32(row11["EstimateItemID"].ToString());
                        num50 = Convert.ToInt64(row11["EstLargeItemCalculationID"]);
                        num48 = Convert.ToDecimal(_commonClass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(row11["InvSheets"].ToString()), 0, "", false, false, true));
                        if (row11["ispriceperpack"].ToString().ToLower() == "true")
                        {
                            num46 = Convert.ToDecimal(row11["packedprice"]);
                            num8 = SummaryClass.ReturnPackedPrice(num48, num45, num46, new decimal(0), out num47);
                            num45 = num47;
                        }
                        else
                        {
                            num8 = num48 * num49;
                        }
                        num1 = Convert.ToInt32(row11["SupplierID"].ToString());
                        num2 = Convert.ToInt32(row11["ContactID"].ToString());
                        num3 = Convert.ToInt64(row11["AddressID"].ToString());
                        empty = row11["AddressType"].ToString();
                        num10 = Convert.ToInt64(row11["DeliveryAddress"].ToString());
                        num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, baseClass.SpecialEncode(str), "", "", dateTime, baseClass.SpecialEncode(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num10, Delivery_AddressType, 0, (long)0, dateTime2, this.IsFromProgreesTojob);
                        this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                        this.chkRaisePOBasedOnEstiItemIDCommon = true;
                        decimal num51 = (num8 * taxRate) / new decimal(100);
                        num4 = PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num5, empty2, str2, empty3, num48, num7, Convert.ToDecimal(num8), taxID, num51, 0, "", false, EstimateItemID, "L", num50, UserID, this.CreatedDate);
                        EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, Convert.ToInt32(num48), "progressed", EstimateItemID);
                        if (str3.ToLower() == "e")
                        {
                            if (!htInventory.ContainsKey(num5))
                            {
                                htInventory.Add(num5, num48);
                            }
                            else
                            {
                                htInventory[num5] = Convert.ToDecimal(htInventory[num5].ToString()) + Convert.ToDecimal(num48);
                            }
                            EstimateBasePage.estimate_warehouseqty_update(CompanyID, num5, empty2, num48, "completed", EstimateItemID);
                        }
                        foreach (DataRow dataRow11 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                        {
                            str4 = dataRow11["PONO"].ToString();
                        }
                        if (empty4 != "")
                        {
                            empty4 = string.Concat(empty4, ", ");
                        }
                        item = new object[] { empty4, "<a href='", baseClass.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", str4, "</a>" };
                        empty4 = string.Concat(item);
                    }
                }
                num44++;
            }
            AddPurchaseOrders = empty4;
        }
    }
}