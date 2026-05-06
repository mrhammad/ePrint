using nmsCommon;
using nmsConnectionClass;
using nmsnotesclass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Purchases;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using MailChimp.Net.Models;
using Printcenter.BusinessAccessLayer.Estimates;

namespace ePrint.usercontrol.Item
{
    public partial class Item_Summary_RaisePO_From_Job : UserControl
    {
        //protected ImageButton ImageButton6;

        //protected HtmlGenericControl spnPOCreate;

        //protected HtmlGenericControl spnNoItemsTocreatePO;

        //protected PlaceHolder plhpurchase;

        //protected Panel pnlpurchase;

        //protected Button btnCreatePo;

        //protected HiddenField hidPoCount;

        //protected HiddenField hidPoEnable;

        //protected HiddenField hid_AdditionalItemIDs;

        //protected LinkButton lnkCreatePo;

        //protected HiddenField hdnPOforPaperSupplied;

        //protected Panel pnlcreatePo;

        //protected HiddenField hid_Po1Count;

        //protected HiddenField hdnProductAddItemsIDs;

        //protected HiddenField hdnProductAddItemsIDs_PO;

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private commonClass commclass = new commonClass();

        private CompanyBasePage objCom = new CompanyBasePage();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public languageClass objlang = new languageClass();

        public languageClass objLangClass = new languageClass();

        private SummaryClass SummaryClassObj = new SummaryClass();

        public commonClass objComn = new commonClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        int mainitemcount = 0;

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long EstimateItemID;

        public string Module = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public string MainType = string.Empty;

        public string DateFormat = string.Empty;

        public bool Check_SpecialPrivilege;

        public string UserName = string.Empty;

        public string PONO = string.Empty;

        public string Pgtype = "estimate";

        public static int RetPOCount;

        private DateTime TodayDate;

        public long DuplicateEstItemID;

        public int ProductPOCount;

        public static int ManageStockPermission;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string IsFromProgreesTojob = string.Empty;

        private int TotalProdAddItemsPending_forPO;

        private int RowPos;

        private DateTime CreatedDate;

        public long poNum = 0;

        public string isCombine = "no";

        DataTable dtoutworksubitems = new DataTable();
        bool isAnyMainOutworkItemChecked = false;

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

        static Item_Summary_RaisePO_From_Job()
        {
        }

        public Item_Summary_RaisePO_From_Job()
        {
        }

        public void AttachmentUpdate_PO_DN(long EstimateID, long EstimateItemID, long TypeID, string Attachmenttype)
        {
            EstimateBasePage.Attachments_PO_DN_Copy(EstimateID, EstimateItemID, TypeID, Attachmenttype);
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

        protected void Onclick_btnCreatePo(object sender, EventArgs e)
        {
            if (radioButtonList.Items.Count > 0)
            {
                poNum = Convert.ToInt64(this.radioButtonList.SelectedItem.Value);
            }
            

            object[] text;
            DateTime now;
            int num = Convert.ToInt32(this.hidPoCount.Value);
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            long num1 = (long)0;
            long num2 = (long)0;
            this.IsFromProgreesTojob = "yes";

            string selected_value = this.hdnCombinedValue.Value.ToString();
            List<int> list = new List<int>();
            try 
            { 
            for (int i = 0; i <= num - 1; i++)
            {
            Label labelo = (Label)this.plhpurchase.FindControl(string.Concat("PoEstType_", i));
            if (string.Compare(labelo.Text, "O", true) == 0)
            {

                Label label = (Label)this.plhpurchase.FindControl(string.Concat("PoEstItemID_", i));
                Label label1 = new Label();
                label1 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstBookletItemID_", i));
                PlaceHolder placeHolder9 = this.plhpurchase;
                text = new object[] { "chkPo_0_", label.Text, "_", label1.Text, "_", i };
                CheckBox checkBox6 = (CheckBox)placeHolder9.FindControl(string.Concat(text));
                if (checkBox6.Checked)
                    isAnyMainOutworkItemChecked = true;
            }
            }
            }
            catch(Exception ex)
            {
            }

            for (int i = 0; i <= num - 1; i++)
            {
                mainitemcount++;
                Label label = (Label)this.plhpurchase.FindControl(string.Concat("PoEstItemID_", i));
                Label label1 = new Label();
                Label label2 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstType_", i));
                if (label2.Text == "B")
                {
                    this.RowPos = 0;
                    Label label3 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstDigiBookletCount_", i));
                    for (int j = 0; j <= Convert.ToInt16(label3.Text) - 1; j++)
                    {
                        PlaceHolder placeHolder = this.plhpurchase;
                        text = new object[] { "PoEstBookletItemID_", i, "_", j };
                        label1 = (Label)placeHolder.FindControl(string.Concat(text));
                        PlaceHolder placeHolder1 = this.plhpurchase;
                        text = new object[] { "chkPo_0_", label.Text, "_", label1.Text, "_", i };
                        CheckBox checkBox = (CheckBox)placeHolder1.FindControl(string.Concat(text));
                        PlaceHolder placeHolder2 = this.plhpurchase;
                        text = new object[] { "chkProductPO_0_", label.Text, "_", label1.Text, "_", i };
                        CheckBox checkBox1 = (CheckBox)placeHolder2.FindControl(string.Concat(text));
                        int num3 = 0;
                        num2 = Convert.ToInt64(label.Text);
                        long num4 = Convert.ToInt64(label1.Text);
                        DataTable dataTable = JobBasePage.Jobs_Jobcard_details_select(this.CompanyID, Convert.ToInt32(num2));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            num3 = Convert.ToInt32(row["QtyNumber"]);
                            str = row["JobNumber"].ToString();
                        }
                        string text1 = label2.Text;
                        if (checkBox.Checked)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num3, text1, str, num4, "yes", j, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                            checkBox.Checked = false;
                            empty = empty1;
                            str1 = empty2;
                        }
                        else if (checkBox1.Checked)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num3, text1, str, num4, "yes", j, empty, str1, i, out empty1, out empty2, true, false, this.poNum, this.hdnCombinedValue.Value);
                            checkBox1.Checked = false;
                            empty = empty1;
                            str1 = empty2;
                        }
                        else if (Convert.ToInt32(((Label)this.plhpurchase.FindControl(string.Concat("PoAddCount_", label.Text))).Text) != 0)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num3, text1, str, num4, "no", j, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                            empty = empty1;
                            str1 = empty2;
                        }
                    }
                }
                else if (label2.Text == "K")
                {
                    this.RowPos = 0;
                    Label label4 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstLithoBookletCount_", i));
                    for (int k = 0; k <= Convert.ToInt16(label4.Text) - 1; k++)
                    {
                        PlaceHolder placeHolder3 = this.plhpurchase;
                        text = new object[] { "PoEstBookletItemID_", i, "_", k };
                        label1 = (Label)placeHolder3.FindControl(string.Concat(text));
                        PlaceHolder placeHolder4 = this.plhpurchase;
                        text = new object[] { "chkPo_0_", label.Text, "_", label1.Text, "_", i };
                        CheckBox checkBox2 = (CheckBox)placeHolder4.FindControl(string.Concat(text));
                        PlaceHolder placeHolder5 = this.plhpurchase;
                        text = new object[] { "chkProductPO_0_", label.Text, "_", label1.Text, "_", i };
                        CheckBox checkBox3 = (CheckBox)placeHolder5.FindControl(string.Concat(text));
                        int num5 = 0;
                        num2 = Convert.ToInt64(label.Text);
                        long num6 = Convert.ToInt64(label1.Text);
                        DataTable dataTable1 = JobBasePage.Jobs_Jobcard_details_select(this.CompanyID, Convert.ToInt32(num2));
                        foreach (DataRow dataRow in dataTable1.Rows)
                        {
                            num5 = Convert.ToInt32(dataRow["QtyNumber"]);
                            str = dataRow["JobNumber"].ToString();
                        }
                        string text2 = label2.Text;
                        if (checkBox2.Checked)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num5, text2, str, num6, "yes", k, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                            checkBox2.Checked = false;
                            empty = empty1;
                            str1 = empty2;
                        }
                        else if (checkBox3.Checked)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num5, text2, str, num6, "yes", k, empty, str1, i, out empty1, out empty2, true, false, this.poNum, this.hdnCombinedValue.Value);
                            checkBox3.Checked = false;
                            empty = empty1;
                            str1 = empty2;
                        }
                        else if (Convert.ToInt32(((Label)this.plhpurchase.FindControl(string.Concat("PoAddCount_", label.Text))).Text) != 0)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num5, text2, str, num6, "no", k, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                            empty = empty1;
                            str1 = empty2;
                        }
                    }
                }
                else if (label2.Text == "N")
                {
                    this.RowPos = 0;
                    Label label5 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstLithoNcrCount_", i));
                    for (int l = 0; l <= Convert.ToInt16(label5.Text) - 1; l++)
                    {
                        PlaceHolder placeHolder6 = this.plhpurchase;
                        text = new object[] { "PoEstBookletItemID_", i, "_", l };
                        label1 = (Label)placeHolder6.FindControl(string.Concat(text));
                        PlaceHolder placeHolder7 = this.plhpurchase;
                        text = new object[] { "chkPo_0_", label.Text, "_", label1.Text, "_", i };
                        CheckBox checkBox4 = (CheckBox)placeHolder7.FindControl(string.Concat(text));
                        PlaceHolder placeHolder8 = this.plhpurchase;
                        text = new object[] { "chkProductPO_0_", label.Text, "_", label1.Text, "_", i };
                        CheckBox checkBox5 = (CheckBox)placeHolder8.FindControl(string.Concat(text));
                        int num7 = 0;
                        num2 = Convert.ToInt64(label.Text);
                        long num8 = Convert.ToInt64(label1.Text);
                        DataTable dataTable2 = JobBasePage.Jobs_Jobcard_details_select(this.CompanyID, Convert.ToInt32(num2));
                        foreach (DataRow row1 in dataTable2.Rows)
                        {
                            num7 = Convert.ToInt32(row1["QtyNumber"]);
                            str = row1["JobNumber"].ToString();
                        }
                        string str2 = label2.Text;
                        if (checkBox4.Checked)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num7, str2, str, num8, "yes", l, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                            checkBox4.Checked = false;
                            empty = empty1;
                            str1 = empty2;
                        }
                        else if (checkBox5.Checked)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num7, str2, str, num8, "yes", l, empty, str1, i, out empty1, out empty2, true, false, this.poNum, this.hdnCombinedValue.Value);
                            checkBox5.Checked = false;
                            empty = empty1;
                            str1 = empty2;
                        }
                        else if (Convert.ToInt32(((Label)this.plhpurchase.FindControl(string.Concat("PoAddCount_", label.Text))).Text) != 0)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num7, str2, str, num8, "no", l, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                            empty = empty1;
                            str1 = empty2;
                        }
                    }
                }
                else if (label2.Text == "R")
                {
                    this.RowPos = 0;
                    Label label5 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstLithoNcrCount_", i));
                    for (int l = 0; l <= Convert.ToInt16(label5.Text) - 1; l++)
                    {
                        PlaceHolder placeHolder6 = this.plhpurchase;
                        text = new object[] { "PoEstBookletItemID_", i, "_", l };
                        label1 = (Label)placeHolder6.FindControl(string.Concat(text));
                        PlaceHolder placeHolder7 = this.plhpurchase;
                        text = new object[] { "chkPo_0_", label.Text, "_", label1.Text, "_", i };
                        CheckBox checkBox4 = (CheckBox)placeHolder7.FindControl(string.Concat(text));
                        PlaceHolder placeHolder8 = this.plhpurchase;
                        text = new object[] { "chkProductPO_0_", label.Text, "_", label1.Text, "_", i };
                        CheckBox checkBox5 = (CheckBox)placeHolder8.FindControl(string.Concat(text));
                        int num7 = 0;
                        num2 = Convert.ToInt64(label.Text);
                        long num8 = Convert.ToInt64(label1.Text);
                        DataTable dataTable2 = JobBasePage.Jobs_Jobcard_details_select(this.CompanyID, Convert.ToInt32(num2));
                        foreach (DataRow row1 in dataTable2.Rows)
                        {
                            num7 = Convert.ToInt32(row1["QtyNumber"]);
                            str = row1["JobNumber"].ToString();
                        }
                        string str2 = label2.Text;
                        if (checkBox4.Checked)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num7, str2, str, num8, "yes", l, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                            checkBox4.Checked = false;
                            empty = empty1;
                            str1 = empty2;
                        }
                        else if (checkBox5.Checked)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num7, str2, str, num8, "yes", l, empty, str1, i, out empty1, out empty2, true, false, this.poNum, this.hdnCombinedValue.Value);
                            checkBox5.Checked = false;
                            empty = empty1;
                            str1 = empty2;
                        }
                        else if (Convert.ToInt32(((Label)this.plhpurchase.FindControl(string.Concat("PoAddCount_", label.Text))).Text) != 0)
                        {
                            num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num7, str2, str, num8, "no", l, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                            empty = empty1;
                            str1 = empty2;
                        }
                    }
                }
                else if (label2.Text != "L")
                {
                    long num9 = (long)0;
                    label1 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstBookletItemID_", i));
                    PlaceHolder placeHolder9 = this.plhpurchase;
                    text = new object[] { "chkPo_0_", label.Text, "_", label1.Text, "_", i };
                    CheckBox checkBox6 = (CheckBox)placeHolder9.FindControl(string.Concat(text));
                    ///Modification
                    PlaceHolder placeHolder11 = this.plhpurchase;
                    text = new object[] { "chkRpt_0_", label.Text, "_", label1.Text, "_", i };
                    CheckBox checkBoxRpt = (CheckBox)placeHolder11.FindControl(string.Concat(text));
                    PlaceHolder placeHolder10 = this.plhpurchase;
                    text = new object[] { "chkProductPO_0_", label.Text, "_", label1.Text, "_", i };
                    CheckBox checkBox7 = (CheckBox)placeHolder10.FindControl(string.Concat(text));
                    int num10 = 0;
                    num2 = Convert.ToInt64(label.Text);
                    DataTable dataTable3 = JobBasePage.Jobs_Jobcard_details_select(this.CompanyID, Convert.ToInt32(num2));
                    foreach (DataRow dataRow1 in dataTable3.Rows)
                    {
                        num10 = Convert.ToInt32(dataRow1["QtyNumber"]);
                        str = dataRow1["JobNumber"].ToString();
                    }
                    string text3 = label2.Text;

                    //-----------------start
                    DataSet dataSet_dd = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, num2, num10, text3);
                    int supp_ID = 0;
                    foreach (DataRow row_dd in dataSet_dd.Tables[0].Rows)
                    {
                        supp_ID = Convert.ToInt32(row_dd["SupplierID"].ToString());
                    }

                   

                    //-----------------end




                    if (checkBox6.Checked)
                    {
                        if (checkBoxRpt != null)
                        {
                            if (checkBoxRpt.Checked) ////Modification
                            {
                                num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num10, text3, str, num9, "yes", 0, empty, str1, i, out empty1, out empty2, false, true, this.poNum, this.hdnCombinedValue.Value);
                                checkBoxRpt.Checked = false;
                                checkBox6.Checked = false;
                                empty = empty1;
                                str1 = empty2;
                            } ////
                            else
                            {
                                num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num10, text3, str, num9, "yes", 0, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                                checkBox6.Checked = false;
                                empty = empty1;
                                str1 = empty2;
                            }
                        }
                        else
                        {

                            if (this.hdnCombinedValue.Value.ToString() == "yes")
                            {
                                num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num10, text3, str, num9, "yes", 0, empty, str1, i, out empty1, out empty2, false, false, this.poNum, "yes");
                            }
                            else if (!(list.Contains(supp_ID)) && this.hdnCombinedValue.Value.ToString() == "no")
                            {
                                num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num10, text3, str, num9, "yes", 0, empty, str1, i, out empty1, out empty2, false, false, 0, "no");
                                list.Add(supp_ID);
                            }
                            else if (list.Contains(supp_ID) && this.hdnCombinedValue.Value.ToString() == "no")
                            {
                                num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num10, text3, str, num9, "yes", 0, empty, str1, i, out empty1, out empty2, false, false, 0, "yes");
                                //list.Add(supp_ID);
                            }
                            checkBox6.Checked = false;
                            empty = empty1;
                            str1 = empty2;
                        }
                    }
                    else if (checkBox7.Checked)
                    {
                        num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num10, text3, str, num9, "yes", 0, empty, str1, i, out empty1, out empty2, true, false, this.poNum, this.hdnCombinedValue.Value);
                        checkBox7.Checked = false;
                        empty = empty1;
                        str1 = empty2;
                    }
                    else if (this.hid_AdditionalItemIDs.Value != "0")
                    {
                        num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num10, text3, str, num9, "no", 0, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                        empty = empty1;
                        str1 = empty2;
                    }
                }
                else
                {
                    long num11 = (long)0;
                    label1 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstBookletItemID_", i));
                    PlaceHolder placeHolder11 = this.plhpurchase;
                    text = new object[] { "chkProductPO_0_", label.Text, "_", label1.Text, "_", i };
                    CheckBox checkBox8 = (CheckBox)placeHolder11.FindControl(string.Concat(text));
                    int num12 = 0;
                    num2 = Convert.ToInt64(label.Text);
                    DataTable dataTable4 = JobBasePage.Jobs_Jobcard_details_select(this.CompanyID, Convert.ToInt32(num2));
                    bool flag = false;
                    int num13 = 0;
                    foreach (DataRow row2 in EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(label.Text)).Rows)
                    {
                        PlaceHolder placeHolder12 = this.plhpurchase;
                        text = new object[] { "chkPo_", num13, "_", label.Text, "_", label1.Text, "_", i };
                        if (((CheckBox)placeHolder12.FindControl(string.Concat(text))).Checked)
                        {
                            flag = true;
                        }
                        num13++;
                    }
                    foreach (DataRow dataRow2 in dataTable4.Rows)
                    {
                        num12 = Convert.ToInt32(dataRow2["QtyNumber"]);
                        str = dataRow2["JobNumber"].ToString();
                    }
                    string str3 = label2.Text;
                    if (flag)
                    {
                        num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num12, str3, str, num11, "yes", 0, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                        empty = empty1;
                        str1 = empty2;
                    }
                    else if (checkBox8.Checked)
                    {
                        num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num12, str3, str, num11, "yes", 0, empty, str1, i, out empty1, out empty2, true, false, this.poNum, this.hdnCombinedValue.Value);
                        checkBox8.Checked = false;
                        empty = empty1;
                        str1 = empty2;
                    }
                    else if (this.hid_AdditionalItemIDs.Value != "0")
                    {
                        num1 = this.Purchse_OrderInsert(this.CompanyID, this.EstimateID, num2, num12, str3, str, num11, "no", 0, empty, str1, i, out empty1, out empty2, false, false, this.poNum, this.hdnCombinedValue.Value);
                        empty = empty1;
                        str1 = empty2;
                    }
                }
            }
            string value = this.hdnProductAddItemsIDs_PO.Value;
            char[] chrArray = new char[] { '↑' };
            string[] strArrays = value.Split(chrArray);
            if ((int)strArrays.Length > 1)
            {
                string[] strArrays1 = new string[(int)strArrays.Length - 1];
                string[] strArrays2 = new string[(int)strArrays.Length - 1];
                int num14 = 0;
                for (int m = 0; m < (int)strArrays.Length - 1; m++)
                {
                    string str4 = strArrays[m];
                    chrArray = new char[] { '\u005F' };
                    string[] strArrays3 = str4.Split(chrArray);
                    if (!strArrays1.Contains<string>(strArrays3[0].ToString()))
                    {
                        strArrays1[num14] = strArrays3[0].ToString();
                        num14++;
                    }
                    strArrays2[m] = strArrays3[1].ToString();
                }
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                foreach (DataRow row3 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Purchase Footer").Rows)
                {
                    empty4 = row3["PhraseText"].ToString();
                }
                foreach (DataRow dataRow3 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Purchase Header").Rows)
                {
                    empty3 = dataRow3["PhraseText"].ToString();
                }
                foreach (DataRow row4 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Instructions").Rows)
                {
                    empty5 = row4["PhraseText"].ToString();
                }
                commonClass _commonClass = this.commclass;
                string dateFormat = this.DateFormat;
                commonClass _commonClass1 = this.commclass;
                now = DateTime.Now.AddDays(5);
                string str5 = _commonClass.date_Check_new(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
                commonClass _commonClass2 = this.commclass;
                string dateFormat1 = this.DateFormat;
                commonClass _commonClass3 = this.commclass;
                now = DateTime.Now;
                string str6 = _commonClass2.date_Check_new(dateFormat1, _commonClass3.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
                DateTime dateTime = Convert.ToDateTime(str5);
                DateTime dateTime1 = Convert.ToDateTime(str6);
                int jobStatusID = 0;
                jobStatusID = SettingsBasePage.get_jobStatus_ID(this.CompanyID, "Awaiting Authorization");
                foreach (DataRow dataRow4 in SettingsBasePage.settings_estimatestatus_moduletype_select_new(this.CompanyID, "purchase").Rows)
                {
                    jobStatusID = Convert.ToInt32(dataRow4["StatusID"].ToString());
                }
                int taxID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                decimal taxRate = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                for (int n = 0; n < (int)strArrays1.Length; n++)
                {
                    if (strArrays1[n] != null)
                    {
                        long num15 = Convert.ToInt64(strArrays1[n]);
                        int num16 = 1;
                        string str7 = "C";
                        string empty6 = string.Empty;
                        int num17 = 0;
                        this.objComn.ItemDescriptionToPO_DN(this.CompanyID, num15, "Purchase", ref empty6);
                        DataTable dataTable5 = EstimatesBasePage.ProductOROrder_Item_Qty_Select(num15);
                        if (dataTable5.Rows.Count > 0)
                        {
                            num17 = Convert.ToInt32(dataTable5.Rows[0]["Quantity"]);
                            num16 = Convert.ToInt32(dataTable5.Rows[0]["QtyNumber"]);
                            str = dataTable5.Rows[0]["JobNumber"].ToString();
                            str7 = dataTable5.Rows[0]["EstimateType"].ToString();
                        }
                        foreach (DataRow row5 in EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(num15).Rows)
                        {
                            if (!strArrays2.Contains<string>(row5["EstimateAdditionalItemID"].ToString()))
                            {
                                continue;
                            }
                            long num18 = Convert.ToInt64(row5["EstimateAdditionalItemID"]);
                            decimal num19 = Convert.ToDecimal(row5[string.Concat("SelectedPrice", num16)]);
                            long num20 = (long)0;
                            string str8 = "";
                            string serverName = ConnectionClass.ServerName;
                            num20 = Convert.ToInt64(row5["DeliveryAddress"].ToString());
                            int num21 = Convert.ToInt32(row5["SupplierID"].ToString());
                            int num22 = Convert.ToInt32(row5["SupplierContactID"].ToString());
                            long num23 = Convert.ToInt64(row5["AddressID"].ToString());
                            string str9 = row5["AddressType"].ToString();
                            decimal num24 = (num19 * taxRate) / new decimal(100);
                            string empty7 = string.Empty;
                            string empty8 = string.Empty;
                            empty7 = string.Concat("Description: ", this.objBase.SpecialDecode(row5["EstimateOtherCostName"].ToString()));
                            if (!string.IsNullOrEmpty(this.objBase.SpecialDecode(row5["SelectedValue"].ToString())))
                            {
                                empty7 = string.Concat(empty7, " - ", this.objBase.SpecialDecode(row5["SelectedValue"].ToString()));
                            }
                            long num25 = PurchaseBasePage.purchase_insert((long)0, this.CompanyID, num21, num22, num23, this.objBase.SpecialEncode(empty5), this.objBase.SpecialEncode(empty4), "", this.TodayDate, this.objBase.SpecialEncode(str), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str9, this.EstimateID, this.objBase.SpecialEncode(empty3), num15, this.TodayDate, num20, str8, 0, (long)0, dateTime1, this.IsFromProgreesTojob);
                            PurchaseBasePage.purchaseitem_insert_ProdAdditional_Item(this.CompanyID, (long)0, num25, (long)0, "A", "", empty7, Convert.ToDecimal(num17), Convert.ToDecimal(num17), Convert.ToDecimal(num19), taxID, num24, 0, "", false, num15, str7, (long)0, num18, this.UserID, this.CreatedDate);
                        }
                    }
                }
            }
            string str10 = empty.ToString().Trim();
            chrArray = new char[] { ',' };
            string[] strArrays4 = str10.Split(chrArray);
            string empty9 = string.Empty;
            if ((int)strArrays4.Length > 0)
            {
                for (int o = 0; o < (int)strArrays4.Length; o++)
                {
                    if (!empty9.ToString().ToLower().Trim().Contains(strArrays4[o].ToString().ToLower().Trim()))
                    {
                        empty9 = (empty9 == "" ? strArrays4[o].ToString() : string.Concat(empty9, ", ", strArrays4[o].ToString()));
                    }
                }
            }
            if (empty9 != "")
            {
                this.objnotes.PO_Numbers = empty9;
                this.objnotes.Item_number = str1;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobPOCreate);
                this.objnotes.ModuleID = this.jobID;
                this.objnotes.CustomerName = this.UserName;
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass4 = this.commclass;
                now = DateTime.Now;
                _notesclass.Created_Date = _commonClass4.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = (long)0;
                this.objN.NotesAdd(this.objnotes);
            }
            if (this.hid_Po1Count.Value.ToLower() == "yes")
            {
                if (num1 == (long)0)
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:OnChangeForSummary();", true);
                    return;
                }
                HttpResponse response = base.Response;
                text = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=edit&pg=job&estid=", this.EstimateID, "&id=", num1, this.jID, this.InvID };
                response.Redirect(string.Concat(text));
                return;
            }
            if (InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs").ToLower() != "yes")
            {
                HttpResponse httpResponse = base.Response;
                text = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(text));
                return;
            }
            HttpResponse response1 = base.Response;
            text = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID };
            response1.Redirect(string.Concat(text));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime now;
            IEnumerator enumerator;
            IDisposable disposable;
            object[] count;
            string[] strArrays;
            if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
                this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
                this.DateFormat = base.Session["DateFormat"].ToString();
                this.UserName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                {
                    this.Module = "job";
                    this.Pgtype = "job";
                }
                else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                {
                    this.Module = "estimate";
                    this.Pgtype = "estimate";
                }
                else
                {
                    this.Module = "invoice";
                    this.Pgtype = "invoice";
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
                commonClass _commonClass = this.commclass;
                string dateFormat = this.DateFormat;
                commonClass _commonClass1 = this.commclass;
                now = DateTime.Now;
                string str = _commonClass.date_Check_new(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
                try
                {
                    this.TodayDate = Convert.ToDateTime(str);
                }
                catch
                {
                }
                string empty = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string str2 = "";
                DataTable dataTable = new DataTable();
                dataTable = (!base.Request.Url.ToString().ToLower().Contains("jobs/job") ? EstimateNew.estimate_item_select(this.CompanyID, this.EstimateID) : EstimatesBasePage.Job_item_select(this.CompanyID, this.jobID));
                foreach (DataRow row in dataTable.Rows)
                {
                    if (string.Compare(row["EstimateType"].ToString(), "S", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»S±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»S»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "P", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»P±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»P»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "L", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»L±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»L»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "B", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»B±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»B»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "W", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»W±");
                        empty = string.Concat(empty, str2);
                        str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»W»1±");
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "C", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»C±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»C»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString().ToLower(), "x", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»X±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»X»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "O", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»O±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»O»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "U", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»U±");
                        empty = string.Concat(empty, str2);
                        str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»U»1±");
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "F", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»F±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»F»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "D", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»D±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»D»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "N", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»N±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»N»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "R", true) == 0)
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»R±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»R»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else if (string.Compare(row["EstimateType"].ToString(), "K", true) != 0)
                    {
                        if (string.Compare(row["EstimateType"].ToString(), "Q", true) != 0)
                        {
                            continue;
                        }
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»Q±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»Q»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                    else
                    {
                        str2 = string.Concat(row["EstimateItemID"].ToString(), "»K±");
                        empty = string.Concat(empty, str2);
                        if (Convert.ToInt32(row["QtyCount"]) <= 1)
                        {
                            str1 = string.Concat(str1, row["EstimateItemID"].ToString(), "»K»1±");
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, str2);
                        }
                    }
                }
                int retPOCount = 0;
                if (!string.IsNullOrEmpty(empty))
                {
                    char[] chrArray = new char[] { '±' };
                    string[] strArrays1 = empty.Split(chrArray);
                    string[] strArrays2 = strArrays1;
                    strArrays2 = strArrays1;
                    for (int i = 0; i < (int)strArrays2.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(strArrays2[i].Trim()))
                        {
                            string[] strArrays3 = strArrays2[i].Split(new char[] { '»' });
                            long num = (long)0;
                            string empty2 = string.Empty;
                            string empty3 = string.Empty;
                            string str3 = string.Empty;
                            string empty4 = string.Empty;
                            DataTable dataTable1 = new DataTable();
                            if (strArrays3[1].Trim().ToUpper() == "S")
                            {
                                dataTable1 = EstimateNew.single_item_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                foreach (DataRow dataRow in dataTable1.Rows)
                                {
                                    str3 = dataRow["ItemTitle"].ToString();
                                    Convert.ToInt64(dataRow["EstimateSingleItemID"]);
                                    ((int)strArrays2.Length).ToString();
                                    dataRow["Qty"].ToString().Split(new char[] { '±' });
                                }
                            }
                            else if (strArrays3[1].Trim().ToUpper() == "P")
                            {
                                dataTable1 = EstimateNew.pad_item_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                foreach (DataRow row1 in dataTable1.Rows)
                                {
                                    str3 = row1["ItemTitle"].ToString();
                                    Convert.ToInt64(row1["EstimatePadItemID"]);
                                    ((int)strArrays2.Length).ToString();
                                }
                            }
                            else if (strArrays3[1].Trim().ToUpper() == "L")
                            {
                                dataTable1 = EstimateNew.large_item_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                foreach (DataRow dataRow1 in dataTable1.Rows)
                                {
                                    str3 = dataRow1["ItemTitle"].ToString();
                                    Convert.ToInt64(dataRow1["EstimateLargeItemID"]);
                                    string str4 = dataRow1["Qty"].ToString();
                                    chrArray = new char[] { '±' };
                                    str4.Split(chrArray);
                                }
                            }
                            else if (strArrays3[1].Trim().ToUpper() == "O")
                            {
                                string str5 = strArrays2[i];
                                chrArray = new char[] { '»' };
                                string[] strArrays4 = str5.Split(chrArray);
                                this.EstimateItemID = Convert.ToInt64(strArrays4[0]);
                                dataTable1 = EstimatesBasePage.summary_outwork_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                foreach (DataRow row2 in dataTable1.Rows)
                                {
                                    str3 = row2["ItemTitle"].ToString();
                                    Convert.ToInt64(row2["Estoutworkid"]);
                                }
                            }
                            else if (strArrays3[1].Trim().ToUpper() == "B")
                            {
                                dataTable1 = EstimatesBasePage.booklet_item_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                string empty5 = string.Empty;
                                string empty6 = string.Empty;
                                int num1 = 0;
                                string[] strArrays5 = new string[0];
                                foreach (DataRow dataRow2 in dataTable1.Rows)
                                {
                                    str3 = dataRow2["ItemTitle"].ToString();
                                    dataRow2["SectionReference"].ToString();
                                    num = Convert.ToInt64(dataRow2["EstimateBookletItemID"]);
                                    if (num1 == 0)
                                    {
                                        string str6 = dataRow2["Qty"].ToString();
                                        str6 = str6.Remove(str6.Length - 1, 1);
                                        chrArray = new char[] { '-' };
                                        strArrays5 = str6.Split(chrArray);
                                        count = new object[] { num, "±", dataTable1.Rows.Count, "±", (int)strArrays5.Length };
                                        string.Concat(count);
                                    }
                                    empty5 = string.Concat(empty5, dataRow2["EstimateBookletItemID"].ToString(), this.commclass.GetCurrencyinRequiredFormate("", true));
                                }
                            }
                            else if (strArrays3[1].Trim().ToUpper() == "W")
                            {
                                string str7 = EstimateBasePage.Estimate_Summary_Warehouse_Select_By_EstimateItem_ID(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                empty4 = str7;
                                if (empty4 != "" && empty4 != null)
                                {
                                    chrArray = new char[] { 'µ' };
                                    string[] strArrays6 = empty4.Split(chrArray);
                                    for (int j = 0; j < (int)strArrays6.Length; j++)
                                    {
                                        string str8 = strArrays6[j];
                                        chrArray = new char[] { '±' };
                                        string[] strArrays7 = str8.Split(chrArray);
                                        int num2 = 0;
                                        while (num2 < (int)strArrays7.Length)
                                        {
                                            string str9 = strArrays7[num2];
                                            chrArray = new char[] { '»' };
                                            string[] strArrays8 = str9.Split(chrArray);
                                            if (strArrays8[0] != "Name")
                                            {
                                                num2++;
                                            }
                                            else
                                            {
                                                str3 = strArrays8[1];
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else if (string.Compare(strArrays3[1].Trim(), "C", true) == 0)
                            {
                                dataTable1 = EstimatesBasePage.price_catalogue_select_by_estimateitem_id_new(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                enumerator = dataTable1.Rows.GetEnumerator();
                                try
                                {
                                    if (enumerator.MoveNext())
                                    {
                                        DataRow current = (DataRow)enumerator.Current;
                                        str3 = this.objBase.SpecialDecode(current["ItemTitle"].ToString());
                                        Convert.ToInt64(current["EstPriceCatalogueID"]);
                                    }
                                }
                                finally
                                {
                                    disposable = enumerator as IDisposable;
                                    if (disposable != null)
                                    {
                                        disposable.Dispose();
                                    }
                                }
                            }
                            else if (string.Compare(strArrays3[1].Trim(), "X", true) == 0)
                            {
                                dataTable1 = EstimatesBasePage.price_catalogue_select_by_estimateitem_id_new(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                enumerator = dataTable1.Rows.GetEnumerator();
                                try
                                {
                                    if (enumerator.MoveNext())
                                    {
                                        DataRow current1 = (DataRow)enumerator.Current;
                                        str3 = this.objBase.SpecialDecode(current1["ItemTitle"].ToString());
                                        Convert.ToInt64(current1["EstPriceCatalogueID"]);
                                    }
                                }
                                finally
                                {
                                    disposable = enumerator as IDisposable;
                                    if (disposable != null)
                                    {
                                        disposable.Dispose();
                                    }
                                }
                            }
                            else if (string.Compare(strArrays3[1].Trim(), "F", true) == 0)
                            {
                                dataTable1 = EstimatesBasePage.litho_estimate_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                foreach (DataRow row3 in dataTable1.Rows)
                                {
                                    str3 = row3["ItemTitle"].ToString();
                                    Convert.ToInt64(row3["EstLithoItemID"]);
                                }
                            }
                            else if (string.Compare(strArrays3[1].Trim(), "D", true) == 0)
                            {
                                dataTable1 = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                foreach (DataRow dataRow3 in dataTable1.Rows)
                                {
                                    str3 = dataRow3["ItemTitle"].ToString();
                                    Convert.ToInt64(dataRow3["EstimateLithoPadItemID"]);
                                }
                            }
                            else if (strArrays3[1].Trim().ToUpper() == "N")
                            {
                                dataTable1 = EstimatesBasePage.lithoncr_item_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                string empty7 = string.Empty;
                                string empty8 = string.Empty;
                                int num3 = 0;
                                strArrays = new string[] { "0" };
                                string[] strArrays9 = strArrays;
                                foreach (DataRow row4 in dataTable1.Rows)
                                {
                                    str3 = row4["ItemTitle"].ToString();
                                    row4["SectionReference"].ToString();
                                    num = Convert.ToInt64(row4["EstimateLithoNcrItemID"]);
                                    if (num3 == 0)
                                    {
                                        string str10 = row4["Qty"].ToString();
                                        if (str10.Length > 0)
                                        {
                                            str10 = str10.Remove(str10.Length - 1, 1);
                                            chrArray = new char[] { '-' };
                                            strArrays9 = str10.Split(chrArray);
                                        }
                                        count = new object[] { num, "±", dataTable1.Rows.Count, "±", (int)strArrays9.Length };
                                        string.Concat(count);
                                    }
                                    empty7 = string.Concat(empty7, row4["EstimateLithoNcrItemID"].ToString(), this.commclass.GetCurrencyinRequiredFormate("", true));
                                }
                            }
                            else if (strArrays3[1].Trim().ToUpper() == "R")
                            {
                                dataTable1 = EstimatesBasePage.digitalncr_item_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                string empty7 = string.Empty;
                                string empty8 = string.Empty;
                                int num3 = 0;
                                strArrays = new string[] { "0" };
                                string[] strArrays9 = strArrays;
                                foreach (DataRow row4 in dataTable1.Rows)
                                {
                                    str3 = row4["ItemTitle"].ToString();
                                    row4["SectionReference"].ToString();
                                    num = Convert.ToInt64(row4["EstimateLithoNcrItemID"]);
                                    if (num3 == 0)
                                    {
                                        string str10 = row4["Qty"].ToString();
                                        if (str10.Length > 0)
                                        {
                                            str10 = str10.Remove(str10.Length - 1, 1);
                                            chrArray = new char[] { '-' };
                                            strArrays9 = str10.Split(chrArray);
                                        }
                                        count = new object[] { num, "±", dataTable1.Rows.Count, "±", (int)strArrays9.Length };
                                        string.Concat(count);
                                    }
                                    empty7 = string.Concat(empty7, row4["EstimateLithoNcrItemID"].ToString(), this.commclass.GetCurrencyinRequiredFormate("", true));
                                }
                            }
                            else if (strArrays3[1].Trim().ToUpper() == "K")
                            {
                                dataTable1 = EstimatesBasePage.lithobooklet_item_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                string empty9 = string.Empty;
                                string empty10 = string.Empty;
                                int num4 = 0;
                                strArrays = new string[] { "0" };
                                string[] strArrays10 = strArrays;
                                foreach (DataRow dataRow4 in dataTable1.Rows)
                                {
                                    str3 = dataRow4["ItemTitle"].ToString();
                                    dataRow4["SectionReference"].ToString();
                                    num = Convert.ToInt64(dataRow4["EstimateLithoBookletItemID"]);
                                    if (num4 == 0)
                                    {
                                        string str11 = dataRow4["Qty"].ToString();
                                        if (str11.Length > 0)
                                        {
                                            str11 = str11.Remove(str11.Length - 1, 1);
                                            chrArray = new char[] { '-' };
                                            strArrays10 = str11.Split(chrArray);
                                        }
                                        count = new object[] { num, "±", dataTable1.Rows.Count, "±", (int)strArrays10.Length };
                                        string.Concat(count);
                                    }
                                    empty9 = string.Concat(empty9, dataRow4["EstimateLithoBookletItemID"].ToString(), this.commclass.GetCurrencyinRequiredFormate("", true));
                                }
                            }
                            else if (string.Compare(strArrays3[1].Trim(), "Q", true) == 0)
                            {
                                dataTable1 = EstimatesBasePage.quickquote_item_select(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                foreach (DataRow row5 in dataTable1.Rows)
                                {
                                    str3 = row5["ItemTitle"].ToString();
                                    Convert.ToInt64(row5["QuickQuoteID"]);
                                }
                            }
                            else if (string.Compare(strArrays3[1].Trim(), "U", true) == 0)
                            {
                                dataTable1 = EstimatesBasePage.estimate_summary_othercost_by_estimateitem_id_new(this.CompanyID, Convert.ToInt64(strArrays3[0]));
                                foreach (DataRow dataRow5 in dataTable1.Rows)
                                {
                                    str3 = this.objBase.SpecialDecode(dataRow5["ItemTitle"].ToString());
                                }
                            }
                            this.Purchse_OrderCreate_FromJobSummary(this.CompanyID, strArrays3, str3, this.EstimateID, Convert.ToInt64(strArrays3[0]), num, this.Module, retPOCount, out Item_Summary_RaisePO_From_Job.RetPOCount);
                            retPOCount = Item_Summary_RaisePO_From_Job.RetPOCount;
                        }
                        this.hidPoCount.Value = Item_Summary_RaisePO_From_Job.RetPOCount.ToString();
                    }
                }
            }
            commonClass _commonClass2 = this.commclass;
            now = DateTime.Now;
            this.CreatedDate = Convert.ToDateTime(_commonClass2.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));

            if (this.jobID != 0 && this.CompanyID != 0)
            {
                DataSet dataTablePO = PurchaseBasePage.selectPOfromJob(this.jobID, this.CompanyID, 0);

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
                    //sthis.pnlradiopurchase.Visible = false;
                    //enqform.Style.Add("display", "none");
                    this.pnlradiopurchase.Style.Add("display", "none");
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
                this.hdnIsPOPup.Value = "no";
            }


        }

        protected void Purchse_OrderCreate_FromJobSummary(int CompanyID, string[] strArr2, string StrItemTitle, long EstimateID, long EstimateItemID, long EstimateBookletItemID, string Module, int POCount, out int RetPOCount)
        {
            object[] num;
            string[] value;
            int count;
            StrItemTitle = this.objBase.SpecialDecode(StrItemTitle);
            string empty = string.Empty;
            long num1 = (long)0;
            this.ProductPOCount = 0;
            DataTable dataTable = PurchaseBasePage.PO_ProductSelect(EstimateItemID, strArr2[1]);
            foreach (DataRow row in dataTable.Rows)
            {
                empty = this.objBase.SpecialDecode(row["CatalogueName"].ToString());
                num1 = Convert.ToInt64(row["PriceCatalogueID"]);
            }
            if (num1 > (long)0 && dataTable.Rows.Count > 0)
            {   
                this.ProductPOCount = dataTable.Rows.Count;
            }
            DataTable dataTable1 = new DataTable();
            RetPOCount = 0;
            if (Module == "job")
            {
                Label label = new Label();
                Label label1 = new Label();
                label.Text = EstimateItemID.ToString();
                label.ID = string.Concat("PoEstItemID_", POCount);
                label.Style.Add("display", "none");
                label1.Text = strArr2[1];
                label1.ID = string.Concat("PoEstType_", POCount);
                label1.Style.Add("display", "none");
                if (strArr2[1].Trim().ToUpper() == "S")
                {
                    int num2 = 0;
                    string str = string.Empty;
                    CheckBox checkBox = new CheckBox();
                    CheckBox checkBox1 = new CheckBox();
                    Label str1 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    str1.Style.Add("display", "none");
                    str1.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkPo_0_", Convert.ToInt64(strArr2[0]), "_", EstimateBookletItemID, "_", POCount };
                    checkBox.ID = string.Concat(num);
                    checkBox.Text = StrItemTitle;
                    checkBox.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    num = new object[] { "chkProductPO_0_", Convert.ToInt64(strArr2[0]), "_", EstimateBookletItemID, "_", POCount };
                    checkBox1.ID = string.Concat(num);
                    checkBox1.Text = empty;
                    checkBox1.Attributes.Add("style", "margin-left:20px");
                    checkBox1.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox1.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable2 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(strArr2[0]), strArr2[1], EstimateBookletItemID);
                    foreach (DataRow dataRow in dataTable2.Rows)
                    {
                        checkBox.Enabled = false;
                        checkBox1.Enabled = false;
                        str = (str != "" ? string.Concat(str, ", ", dataRow["PONO"].ToString()) : string.Concat(str, dataRow["PONO"].ToString()));
                    }
                    this.plhpurchase.Controls.Add(checkBox);
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str.ToString(), " <br/>")));
                    this.plhpurchase.Controls.Add(checkBox1);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(str1);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    DataTable dataTable3 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, Convert.ToInt64(strArr2[0]), strArr2[1].ToString());
                    
                    foreach (DataRow row1 in dataTable3.Rows)
                    {
                        if (num2 == 0)
                        {
                            num2 = 1;
                        }
                        Label label2 = new Label();
                        Label str2 = new Label();
                        label2.Text = row1["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num2 };
                        label2.ID = string.Concat(num);
                        label2.Style.Add("display", "none");
                        str2.Text = row1["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num2 };
                        str2.ID = string.Concat(num);
                        str2.Style.Add("display", "none");
                        string empty1 = string.Empty;
                        string empty2 = string.Empty;
                        empty2 = (row1["EstimateItemType"].ToString().ToLower() != "u" ? row1["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty2.ToLower() != "l")
                        {
                            CheckBox checkBox2 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", row1["EstimateItemID"].ToString(), "_", POCount, "_", num2 };
                            checkBox2.ID = string.Concat(num);
                            checkBox2.Text = row1["ItemTitle"].ToString();
                            DataTable dataTable4 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(row1["EstimateItemID"].ToString()), empty2, EstimateBookletItemID);
                            foreach (DataRow dataRow1 in dataTable4.Rows)
                            {
                                checkBox2.Enabled = false;
                                empty1 = (empty1 != "" ? string.Concat(empty1, ", ", dataRow1["PONO"].ToString()) : string.Concat(empty1, dataRow1["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox2);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty1.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num3 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", row1["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable5 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(row1["EstimateItemID"].ToString()));
                            foreach (DataRow row2 in dataTable5.Rows)
                            {
                                CheckBox checkBox3 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num3, "_", row1["EstimateitemID"].ToString(), "_", POCount, "_", num2 };
                                checkBox3.ID = string.Concat(num);
                                checkBox3.Text = row2["MaterialName"].ToString();
                                string empty3 = string.Empty;
                                DataTable dataTable6 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(row1["EstimateItemID"].ToString()), empty2, EstimateBookletItemID, Convert.ToInt64(row2["MaterialID"]));
                                foreach (DataRow dataRow2 in dataTable6.Rows)
                                {
                                    checkBox3.Enabled = false;
                                    empty3 = (empty3 != "" ? string.Concat(empty3, ", ", dataRow2["PONO"].ToString()) : string.Concat(empty3, dataRow2["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox3);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty3.ToString(), " <br/>")));
                                num3++;
                            }
                            Label label3 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", row1["EstimateItemID"].ToString()),
                                Text = num2.ToString()
                            };
                            label3.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label3);
                            Label str3 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num2 };
                            str3.ID = string.Concat(num);
                            str3.Style.Add("display", "none");
                            str3.Text = num3.ToString();
                            this.plhpurchase.Controls.Add(str3);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(label2);
                        this.plhpurchase.Controls.Add(str2);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty2.ToLower() == "c")
                        {
                            DataTable dataTable7 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(row1["EstimateItemID"]));
                            foreach (DataRow row3 in dataTable7.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO = this;
                                totalProdAddItemsPendingForPO.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO.TotalProdAddItemsPending_forPO + 1;
                                string empty4 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox4 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(row1["EstimateItemID"]), "_", row3["EstimateAdditionalItemID"].ToString() };
                                checkBox4.ID = string.Concat(num);
                                checkBox4.Text = this.objBase.SpecialDecode(row3["EstimateOtherCostName"].ToString());
                                DataTable dataTable8 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(row1["EstimateItemID"]), Convert.ToInt64(row3["EstimateAdditionalItemID"]));
                                foreach (DataRow dataRow3 in dataTable8.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob = this;
                                    usercontrolItemItemSummaryRaisePOFromJob.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob.TotalProdAddItemsPending_forPO - 1;
                                    checkBox4.Enabled = false;
                                    empty4 = (empty4 != "" ? string.Concat(empty4, ", ", dataRow3["PONO"].ToString()) : string.Concat(empty4, dataRow3["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox4);
                                if (!string.IsNullOrEmpty(empty4))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty4, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, row1["EstimateItemID"].ToString(), "_", row3["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField.Value = string.Concat(value);
                            }
                        }
                        num2++;
                    }
                    Label label4 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable3.Rows.Count;
                    label4.Text = count.ToString();
                    label4.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label4);
                }
                else if (strArr2[1].Trim().ToUpper() == "P")
                {
                    int num4 = 0;
                    string str4 = string.Empty;
                    CheckBox strItemTitle = new CheckBox();
                    CheckBox checkBox5 = new CheckBox();
                    Label label5 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    label5.Style.Add("display", "none");
                    label5.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkPo_0_", Convert.ToInt64(strArr2[0]), "_", EstimateBookletItemID, "_", POCount };
                    strItemTitle.ID = string.Concat(num);
                    strItemTitle.Text = StrItemTitle;
                    strItemTitle.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    num = new object[] { "chkProductPO_0_", Convert.ToInt64(strArr2[0]), "_", EstimateBookletItemID, "_", POCount };
                    checkBox5.ID = string.Concat(num);
                    checkBox5.Text = empty;
                    checkBox5.Attributes.Add("style", "margin-left:20px");
                    checkBox5.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox5.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable9 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(strArr2[0]), strArr2[1], EstimateBookletItemID);
                    foreach (DataRow row4 in dataTable9.Rows)
                    {
                        strItemTitle.Enabled = false;
                        checkBox5.Enabled = false;
                        str4 = (str4 != "" ? string.Concat(str4, ", ", row4["PONO"].ToString()) : string.Concat(str4, row4["PONO"].ToString()));
                    }
                    this.plhpurchase.Controls.Add(strItemTitle);
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str4.ToString(), "<br/>")));
                    this.plhpurchase.Controls.Add(checkBox5);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(label5);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    DataTable dataTable10 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, Convert.ToInt64(strArr2[0]), strArr2[1].ToString());
                    foreach (DataRow dataRow4 in dataTable10.Rows)
                    {
                        if (num4 == 0)
                        {
                            num4 = 1;
                        }
                        Label str5 = new Label();
                        Label label6 = new Label();
                        str5.Text = dataRow4["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num4 };
                        str5.ID = string.Concat(num);
                        str5.Style.Add("display", "none");
                        label6.Text = dataRow4["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num4 };
                        label6.ID = string.Concat(num);
                        label6.Style.Add("display", "none");
                        string empty5 = string.Empty;
                        string empty6 = string.Empty;
                        empty6 = (dataRow4["EstimateItemType"].ToString().ToLower() != "u" ? dataRow4["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty6.ToLower() != "l")
                        {
                            CheckBox checkBox6 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", dataRow4["EstimateItemID"].ToString(), "_", POCount, "_", num4 };
                            checkBox6.ID = string.Concat(num);
                            checkBox6.Text = dataRow4["ItemTitle"].ToString();
                            DataTable dataTable11 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(dataRow4["EstimateItemID"].ToString()), empty6, EstimateBookletItemID);
                            foreach (DataRow row5 in dataTable11.Rows)
                            {
                                checkBox6.Enabled = false;
                                empty5 = (empty5 != "" ? string.Concat(empty5, ", ", row5["PONO"].ToString()) : string.Concat(empty5, row5["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox6);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty5.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num5 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", dataRow4["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable12 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(dataRow4["EstimateItemID"].ToString()));
                            foreach (DataRow dataRow5 in dataTable12.Rows)
                            {
                                CheckBox str6 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num5, "_", dataRow4["EstimateitemID"].ToString(), "_", POCount, "_", num4 };
                                str6.ID = string.Concat(num);
                                str6.Text = dataRow5["MaterialName"].ToString();
                                string empty7 = string.Empty;
                                DataTable dataTable13 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(dataRow4["EstimateItemID"].ToString()), empty6, EstimateBookletItemID, Convert.ToInt64(dataRow5["MaterialID"]));
                                foreach (DataRow row6 in dataTable13.Rows)
                                {
                                    str6.Enabled = false;
                                    empty7 = (empty7 != "" ? string.Concat(empty7, ", ", row6["PONO"].ToString()) : string.Concat(empty7, row6["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(str6);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty7.ToString(), " <br/>")));
                                num5++;
                            }
                            Label label7 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", dataRow4["EstimateItemID"].ToString()),
                                Text = num4.ToString()
                            };
                            label7.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label7);
                            Label str7 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num4 };
                            str7.ID = string.Concat(num);
                            str7.Style.Add("display", "none");
                            str7.Text = num5.ToString();
                            this.plhpurchase.Controls.Add(str7);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str5);
                        this.plhpurchase.Controls.Add(label6);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty6.ToLower() == "c")
                        {
                            DataTable dataTable14 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(dataRow4["EstimateItemID"]));
                            foreach (DataRow dataRow6 in dataTable14.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO1 = this;
                                totalProdAddItemsPendingForPO1.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO1.TotalProdAddItemsPending_forPO + 1;
                                string empty8 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox7 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(dataRow4["EstimateItemID"]), "_", dataRow6["EstimateAdditionalItemID"].ToString() };
                                checkBox7.ID = string.Concat(num);
                                checkBox7.Text = this.objBase.SpecialDecode(dataRow6["EstimateOtherCostName"].ToString());
                                DataTable dataTable15 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(dataRow4["EstimateItemID"]), Convert.ToInt64(dataRow6["EstimateAdditionalItemID"]));
                                foreach (DataRow row7 in dataTable15.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob1 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob1.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob1.TotalProdAddItemsPending_forPO - 1;
                                    checkBox7.Enabled = false;
                                    empty8 = (empty8 != "" ? string.Concat(empty8, ", ", row7["PONO"].ToString()) : string.Concat(empty8, row7["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox7);
                                if (!string.IsNullOrEmpty(empty8))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty8, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField1 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, dataRow4["EstimateItemID"].ToString(), "_", dataRow6["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField1.Value = string.Concat(value);
                            }
                        }
                        num4++;
                    }
                    Label label8 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable10.Rows.Count;
                    label8.Text = count.ToString();
                    label8.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label8);
                }
                else if (strArr2[1].Trim().ToUpper() == "L")
                {
                    int num6 = 0;
                    CheckBox checkBox8 = new CheckBox();
                    Label str8 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    str8.Style.Add("display", "none");
                    str8.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkProductPO_0_", Convert.ToInt64(strArr2[0]), "_", EstimateBookletItemID, "_", POCount };
                    checkBox8.ID = string.Concat(num);
                    checkBox8.Text = empty;
                    checkBox8.Attributes.Add("style", "margin-left:20px");
                    checkBox8.Attributes.Add("onclick", "javascript:selectoneForLargeItem(this.id);");
                    if (empty == "")
                    {
                        checkBox8.Attributes.Add("style", "display:none");
                    }
                    int num7 = 0;
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", StrItemTitle, "</div>")));
                    DataTable dataTable16 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(strArr2[0]));
                    
                    foreach (DataRow dataRow7 in dataTable16.Rows)
                    {
                        CheckBox checkBox9 = new CheckBox();
                        num = new object[] { "chkPo_", num7, "_", Convert.ToInt64(strArr2[0]), "_", EstimateBookletItemID, "_", POCount };
                        checkBox9.ID = string.Concat(num);
                        checkBox9.Text = dataRow7["MaterialName"].ToString();
                        checkBox9.Attributes.Add("onclick", "javascript:selectoneForLargeItem(this.id);");
                        DataTable dataTable17 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID_LargeFormat(EstimateID, Convert.ToInt64(strArr2[0]), Convert.ToInt64(dataRow7["MaterialID"]), Convert.ToInt64(dataRow7["EstLargeItemCalculationID"]));
                        string empty9 = string.Empty;
                        foreach (DataRow row8 in dataTable17.Rows)
                        {
                            checkBox9.Enabled = false;
                            checkBox8.Enabled = false;
                            empty9 = (empty9 != "" ? string.Concat(empty9, ", ", row8["PONO"].ToString()) : string.Concat(empty9, row8["PONO"].ToString()));
                        }
                        this.plhpurchase.Controls.Add(checkBox9);
                        this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty9.ToString(), "<br/>")));
                        num7++;
                    }
                    Label label9 = new Label()
                    {
                        ID = string.Concat("PoMaterialCount_", POCount)
                    };
                    label9.Style.Add("display", "none");
                    label9.Text = num7.ToString();
                    this.plhpurchase.Controls.Add(label9);
                    this.plhpurchase.Controls.Add(checkBox8);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(str8);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    DataTable dataTable18 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    
                    foreach (DataRow dataRow8 in dataTable18.Rows)
                    {
                        if (num6 == 0)
                        {
                            num6 = 1;
                        }
                        Label str9 = new Label();
                        Label label10 = new Label();
                        str9.Text = dataRow8["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num6 };
                        str9.ID = string.Concat(num);
                        str9.Style.Add("display", "none");
                        label10.Text = dataRow8["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num6 };
                        label10.ID = string.Concat(num);
                        label10.Style.Add("display", "none");
                        string empty10 = string.Empty;
                        string str10 = string.Empty;
                        str10 = (dataRow8["EstimateItemType"].ToString().ToLower() != "u" ? dataRow8["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (str10.ToLower() != "l")
                        {
                            CheckBox checkBox10 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", dataRow8["EstimateitemID"].ToString(), "_", POCount, "_", num6 };
                            checkBox10.ID = string.Concat(num);
                            checkBox10.Text = dataRow8["ItemTitle"].ToString();
                            DataTable dataTable19 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(dataRow8["EstimateItemID"].ToString()), str10, EstimateBookletItemID);
                            foreach (DataRow row9 in dataTable19.Rows)
                            {
                                checkBox10.Enabled = false;
                                empty10 = (empty10 != "" ? string.Concat(empty10, ", ", row9["PONO"].ToString()) : string.Concat(empty10, row9["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox10);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty10.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num8 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", dataRow8["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable20 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(dataRow8["EstimateItemID"].ToString()));
                            foreach (DataRow dataRow9 in dataTable20.Rows)
                            {
                                CheckBox checkBox11 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num8, "_", dataRow8["EstimateitemID"].ToString(), "_", POCount, "_", num6 };
                                checkBox11.ID = string.Concat(num);
                                checkBox11.Text = dataRow9["MaterialName"].ToString();
                                string empty11 = string.Empty;
                                DataTable dataTable21 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(dataRow8["EstimateItemID"].ToString()), str10, EstimateBookletItemID, Convert.ToInt64(dataRow9["MaterialID"]));
                                foreach (DataRow row10 in dataTable21.Rows)
                                {
                                    checkBox11.Enabled = false;
                                    empty11 = (empty11 != "" ? string.Concat(empty11, ", ", row10["PONO"].ToString()) : string.Concat(empty11, row10["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox11);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty11.ToString(), " <br/>")));
                                num8++;
                            }
                            Label label11 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", dataRow8["EstimateItemID"].ToString()),
                                Text = num6.ToString()
                            };
                            label11.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label11);
                            Label str11 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num6 };
                            str11.ID = string.Concat(num);
                            str11.Style.Add("display", "none");
                            str11.Text = num8.ToString();
                            this.plhpurchase.Controls.Add(str11);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str9);
                        this.plhpurchase.Controls.Add(label10);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (str10.ToLower() == "c")
                        {
                            DataTable dataTable22 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(dataRow8["EstimateItemID"]));
                            foreach (DataRow dataRow10 in dataTable22.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO2 = this;
                                totalProdAddItemsPendingForPO2.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO2.TotalProdAddItemsPending_forPO + 1;
                                string empty12 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox12 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(dataRow8["EstimateItemID"]), "_", dataRow10["EstimateAdditionalItemID"].ToString() };
                                checkBox12.ID = string.Concat(num);
                                checkBox12.Text = this.objBase.SpecialDecode(dataRow10["EstimateOtherCostName"].ToString());
                                DataTable dataTable23 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(dataRow8["EstimateItemID"]), Convert.ToInt64(dataRow10["EstimateAdditionalItemID"]));
                                foreach (DataRow row11 in dataTable23.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob2 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob2.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob2.TotalProdAddItemsPending_forPO - 1;
                                    checkBox12.Enabled = false;
                                    empty12 = (empty12 != "" ? string.Concat(empty12, ", ", row11["PONO"].ToString()) : string.Concat(empty12, row11["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox12);
                                if (!string.IsNullOrEmpty(empty12))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty12, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField2 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, dataRow8["EstimateItemID"].ToString(), "_", dataRow10["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField2.Value = string.Concat(value);
                            }
                        }
                        num6++;
                    }
                    Label label12 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable18.Rows.Count;
                    label12.Text = count.ToString();
                    label12.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label12);
                }
                else if (strArr2[1].Trim().ToUpper() == "O")
                {
                    int num9 = 0;
                    string str12 = string.Empty;
                    CheckBox strItemTitle1 = new CheckBox();
                    CheckBox checkBox13 = new CheckBox();
                    Label label13 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    label13.Style.Add("display", "none");
                    label13.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    strItemTitle1.ID = string.Concat(num);
                    strItemTitle1.Text = StrItemTitle;
                    strItemTitle1.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    checkBox13.ID = string.Concat(num);
                    checkBox13.Text = this.objBase.SpecialDecode(empty);
                    checkBox13.Attributes.Add("style", "margin-left:20px");
                    checkBox13.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox13.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable24 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                    foreach (DataRow dataRow11 in dataTable24.Rows)
                    {
                        strItemTitle1.Enabled = false;
                        checkBox13.Enabled = false;
                        str12 = (str12 != "" ? string.Concat(str12, ", ", dataRow11["PONO"].ToString()) : string.Concat(str12, dataRow11["PONO"].ToString()));
                    }
                    this.plhpurchase.Controls.Add(strItemTitle1);
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str12.ToString(), "<br/>")));
                    this.plhpurchase.Controls.Add(checkBox13);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(label13);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    DataTable dataTable25 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow row12 in dataTable25.Rows)
                    {
                        if (num9 == 0)
                        {
                            num9 = 1;
                        }
                        Label str13 = new Label();
                        Label label14 = new Label();
                        str13.Text = row12["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num9 };
                        str13.ID = string.Concat(num);
                        str13.Style.Add("display", "none");
                        label14.Text = row12["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num9 };
                        label14.ID = string.Concat(num);
                        label14.Style.Add("display", "none");
                        string empty13 = string.Empty;
                        string empty14 = string.Empty;
                        empty14 = (row12["EstimateItemType"].ToString().ToLower() != "u" ? row12["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty14.ToLower() != "l")
                        {
                            CheckBox checkBox14 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", row12["EstimateItemID"].ToString(), "_", POCount, "_", num9 };
                            checkBox14.ID = string.Concat(num);
                            checkBox14.Text = row12["ItemTitle"].ToString();
                            DataTable dataTable26 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(row12["EstimateItemID"].ToString()), empty14, EstimateBookletItemID);
                            foreach (DataRow dataRow12 in dataTable26.Rows)
                            {
                                checkBox14.Enabled = false;
                                empty13 = (empty13 != "" ? string.Concat(empty13, ", ", dataRow12["PONO"].ToString()) : string.Concat(empty13, dataRow12["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox14);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty13.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num10 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", row12["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable27 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(row12["EstimateItemID"].ToString()));
                            foreach (DataRow row13 in dataTable27.Rows)
                            {
                                CheckBox str14 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num10, "_", row12["EstimateitemID"].ToString(), "_", POCount, "_", num9 };
                                str14.ID = string.Concat(num);
                                str14.Text = row13["MaterialName"].ToString();
                                string empty15 = string.Empty;
                                DataTable dataTable28 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(row12["EstimateItemID"].ToString()), empty14, EstimateBookletItemID, Convert.ToInt64(row13["MaterialID"]));
                                foreach (DataRow dataRow13 in dataTable28.Rows)
                                {
                                    str14.Enabled = false;
                                    empty15 = (empty15 != "" ? string.Concat(empty15, ", ", dataRow13["PONO"].ToString()) : string.Concat(empty15, dataRow13["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(str14);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty15.ToString(), " <br/>")));
                                num10++;
                            }
                            Label label15 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", row12["EstimateItemID"].ToString()),
                                Text = num9.ToString()
                            };
                            label15.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label15);
                            Label str15 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num9 };
                            str15.ID = string.Concat(num);
                            str15.Style.Add("display", "none");
                            str15.Text = num10.ToString();
                            this.plhpurchase.Controls.Add(str15);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str13);
                        this.plhpurchase.Controls.Add(label14);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty14.ToLower() == "c")
                        {
                            DataTable dataTable29 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(row12["EstimateItemID"]));
                            foreach (DataRow row14 in dataTable29.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO3 = this;
                                totalProdAddItemsPendingForPO3.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO3.TotalProdAddItemsPending_forPO + 1;
                                string empty16 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox15 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(row12["EstimateItemID"]), "_", row14["EstimateAdditionalItemID"].ToString() };
                                checkBox15.ID = string.Concat(num);
                                checkBox15.Text = this.objBase.SpecialDecode(row14["EstimateOtherCostName"].ToString());
                                DataTable dataTable30 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(row12["EstimateItemID"]), Convert.ToInt64(row14["EstimateAdditionalItemID"]));
                                foreach (DataRow dataRow14 in dataTable30.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob3 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob3.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob3.TotalProdAddItemsPending_forPO - 1;
                                    checkBox15.Enabled = false;
                                    empty16 = (empty16 != "" ? string.Concat(empty16, ", ", dataRow14["PONO"].ToString()) : string.Concat(empty16, dataRow14["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox15);
                                if (!string.IsNullOrEmpty(empty16))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty16, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField3 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, row12["EstimateItemID"].ToString(), "_", row14["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField3.Value = string.Concat(value);
                            }
                        }
                        num9++;
                    }
                    Label label16 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable25.Rows.Count;
                    label16.Text = count.ToString();
                    label16.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label16);
                }
                else if (strArr2[1].Trim().ToUpper() == "B")
                {
                    int num11 = 0;
                    Label str16 = new Label()
                    {
                        ID = string.Concat("PoEstDigiBookletCount_", POCount)
                    };
                    str16.Style.Add("display", "none");
                    int num12 = 0;
                    dataTable1 = EstimatesBasePage.booklet_item_select(CompanyID, EstimateItemID);
                    foreach (DataRow row15 in dataTable1.Rows)
                    {
                        string empty17 = string.Empty;
                        CheckBox strItemTitle2 = new CheckBox();
                        CheckBox checkBox16 = new CheckBox();
                        EstimateBookletItemID = Convert.ToInt64(row15["EstimateBookletItemID"]);
                        Label label17 = new Label();
                        num = new object[] { "PoEstBookletItemID_", POCount, "_", num12 };
                        label17.ID = string.Concat(num);
                        label17.Style.Add("display", "none");
                        label17.Text = EstimateBookletItemID.ToString();
                        num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                        strItemTitle2.ID = string.Concat(num);
                        strItemTitle2.Attributes.Add("onclick", "javascript:selectone(this.id);");
                        num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                        checkBox16.ID = string.Concat(num);
                        checkBox16.Text = empty;
                        checkBox16.Attributes.Add("style", "margin-left:20px");
                        checkBox16.Attributes.Add("onclick", "javascript:selectone(this.id);");
                        if (empty == "")
                        {
                            checkBox16.Attributes.Add("style", "display:none");
                        }
                        if (dataTable1.Rows.Count != 1)
                        {
                            num = new object[] { StrItemTitle, " - Section(", num12 + 1, ")" };
                            strItemTitle2.Text = string.Concat(num);
                        }
                        else
                        {
                            strItemTitle2.Text = StrItemTitle;
                        }
                        DataTable dataTable31 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                        foreach (DataRow dataRow15 in dataTable31.Rows)
                        {
                            strItemTitle2.Enabled = false;
                            checkBox16.Enabled = false;
                            empty17 = (empty17 != "" ? string.Concat(empty17, ", ", dataRow15["PONO"].ToString()) : string.Concat(empty17, dataRow15["PONO"].ToString()));
                        }
                        this.plhpurchase.Controls.Add(strItemTitle2);
                        this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty17.ToString(), "<br/>")));
                        this.plhpurchase.Controls.Add(checkBox16);
                        this.plhpurchase.Controls.Add(label17);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        num12++;
                    }
                    str16.Text = num12.ToString();
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(str16);
                    DataTable dataTable32 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow row16 in dataTable32.Rows)
                    {
                        if (num11 == 0)
                        {
                            num11 = 1;
                        }
                        Label str17 = new Label();
                        Label label18 = new Label();
                        str17.Text = row16["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num11 };
                        str17.ID = string.Concat(num);
                        str17.Style.Add("display", "none");
                        label18.Text = row16["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num11 };
                        label18.ID = string.Concat(num);
                        label18.Style.Add("display", "none");
                        string empty18 = string.Empty;
                        string str18 = string.Empty;
                        str18 = (row16["EstimateItemType"].ToString().ToLower() != "u" ? row16["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (str18.ToLower() != "l")
                        {
                            CheckBox checkBox17 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", row16["EstimateItemID"].ToString(), "_", POCount, "_", num11 };
                            checkBox17.ID = string.Concat(num);
                            checkBox17.Text = row16["ItemTitle"].ToString();
                            DataTable dataTable33 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(row16["EstimateItemID"].ToString()), str18, EstimateBookletItemID);
                            foreach (DataRow dataRow16 in dataTable33.Rows)
                            {
                                checkBox17.Enabled = false;
                                empty18 = (empty18 != "" ? string.Concat(empty18, ", ", dataRow16["PONO"].ToString()) : string.Concat(empty18, dataRow16["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox17);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty18.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num13 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", row16["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable34 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(row16["EstimateItemID"].ToString()));
                            foreach (DataRow row17 in dataTable34.Rows)
                            {
                                CheckBox checkBox18 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num13, "_", row16["EstimateitemID"].ToString(), "_", POCount, "_", num11 };
                                checkBox18.ID = string.Concat(num);
                                checkBox18.Text = row17["MaterialName"].ToString();
                                string empty19 = string.Empty;
                                DataTable dataTable35 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(row16["EstimateItemID"].ToString()), str18, EstimateBookletItemID, Convert.ToInt64(row17["MaterialID"]));
                                foreach (DataRow dataRow17 in dataTable35.Rows)
                                {
                                    checkBox18.Enabled = false;
                                    empty19 = (empty19 != "" ? string.Concat(empty19, ", ", dataRow17["PONO"].ToString()) : string.Concat(empty19, dataRow17["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox18);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty19.ToString(), " <br/>")));
                                num13++;
                            }
                            Label label19 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", row16["EstimateItemID"].ToString()),
                                Text = num11.ToString()
                            };
                            label19.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label19);
                            Label str19 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num11 };
                            str19.ID = string.Concat(num);
                            str19.Style.Add("display", "none");
                            str19.Text = num13.ToString();
                            this.plhpurchase.Controls.Add(str19);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str17);
                        this.plhpurchase.Controls.Add(label18);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (str18.ToLower() == "c")
                        {
                            DataTable dataTable36 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(row16["EstimateItemID"]));
                            foreach (DataRow row18 in dataTable36.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO4 = this;
                                totalProdAddItemsPendingForPO4.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO4.TotalProdAddItemsPending_forPO + 1;
                                string empty20 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox19 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(row16["EstimateItemID"]), "_", row18["EstimateAdditionalItemID"].ToString() };
                                checkBox19.ID = string.Concat(num);
                                checkBox19.Text = this.objBase.SpecialDecode(row18["EstimateOtherCostName"].ToString());
                                DataTable dataTable37 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(row16["EstimateItemID"]), Convert.ToInt64(row18["EstimateAdditionalItemID"]));
                                foreach (DataRow dataRow18 in dataTable37.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob4 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob4.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob4.TotalProdAddItemsPending_forPO - 1;
                                    checkBox19.Enabled = false;
                                    empty20 = (empty20 != "" ? string.Concat(empty20, ", ", dataRow18["PONO"].ToString()) : string.Concat(empty20, dataRow18["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox19);
                                if (!string.IsNullOrEmpty(empty20))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty20, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField4 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, row16["EstimateItemID"].ToString(), "_", row18["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField4.Value = string.Concat(value);
                            }
                        }
                        num11++;
                    }
                    Label label20 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable32.Rows.Count;
                    label20.Text = count.ToString();
                    label20.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label20);
                }
                else if (strArr2[1].Trim().ToUpper() == "W")
                {
                    int num14 = 0;
                    string str20 = string.Empty;
                    CheckBox strItemTitle3 = new CheckBox();
                    CheckBox checkBox20 = new CheckBox();
                    Label label21 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    label21.Style.Add("display", "none");
                    label21.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    strItemTitle3.ID = string.Concat(num);
                    strItemTitle3.Text = StrItemTitle;
                    strItemTitle3.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    checkBox20.ID = string.Concat(num);
                    checkBox20.Text = empty;
                    checkBox20.Attributes.Add("style", "margin-left:20px");
                    checkBox20.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox20.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable38 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                    foreach (DataRow row19 in dataTable38.Rows)
                    {
                        strItemTitle3.Enabled = false;
                        checkBox20.Enabled = false;
                        str20 = (str20 != "" ? string.Concat(str20, ", ", row19["PONO"].ToString()) : string.Concat(str20, row19["PONO"].ToString()));
                    }
                    this.plhpurchase.Controls.Add(strItemTitle3);
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str20.ToString(), "<br/>")));
                    this.plhpurchase.Controls.Add(checkBox20);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(label21);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    DataTable dataTable39 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow dataRow19 in dataTable39.Rows)
                    {
                        if (num14 == 0)
                        {
                            num14 = 1;
                        }
                        Label str21 = new Label();
                        Label label22 = new Label();
                        str21.Text = dataRow19["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num14 };
                        str21.ID = string.Concat(num);
                        str21.Style.Add("display", "none");
                        label22.Text = dataRow19["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num14 };
                        label22.ID = string.Concat(num);
                        label22.Style.Add("display", "none");
                        string empty21 = string.Empty;
                        string empty22 = string.Empty;
                        empty22 = (dataRow19["EstimateItemType"].ToString().ToLower() != "u" ? dataRow19["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty22.ToLower() != "l")
                        {
                            CheckBox checkBox21 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", dataRow19["EstimateItemID"].ToString(), "_", POCount, "_", num14 };
                            checkBox21.ID = string.Concat(num);
                            checkBox21.Text = dataRow19["ItemTitle"].ToString();
                            DataTable dataTable40 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(dataRow19["EstimateItemID"].ToString()), empty22, EstimateBookletItemID);
                            foreach (DataRow row20 in dataTable40.Rows)
                            {
                                checkBox21.Enabled = false;
                                empty21 = (empty21 != "" ? string.Concat(empty21, ", ", row20["PONO"].ToString()) : string.Concat(empty21, row20["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox21);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty21.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num15 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", dataRow19["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable41 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(dataRow19["EstimateItemID"].ToString()));
                            foreach (DataRow dataRow20 in dataTable41.Rows)
                            {
                                CheckBox checkBox22 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num15, "_", dataRow19["EstimateitemID"].ToString(), "_", POCount, "_", num14 };
                                checkBox22.ID = string.Concat(num);
                                checkBox22.Text = dataRow20["MaterialName"].ToString();
                                string str22 = string.Empty;
                                DataTable dataTable42 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(dataRow19["EstimateItemID"].ToString()), empty22, EstimateBookletItemID, Convert.ToInt64(dataRow20["MaterialID"]));
                                foreach (DataRow row21 in dataTable42.Rows)
                                {
                                    checkBox22.Enabled = false;
                                    str22 = (str22 != "" ? string.Concat(str22, ", ", row21["PONO"].ToString()) : string.Concat(str22, row21["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox22);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str22.ToString(), " <br/>")));
                                num15++;
                            }
                            Label label23 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", dataRow19["EstimateItemID"].ToString()),
                                Text = num14.ToString()
                            };
                            label23.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label23);
                            Label str23 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num14 };
                            str23.ID = string.Concat(num);
                            str23.Style.Add("display", "none");
                            str23.Text = num15.ToString();
                            this.plhpurchase.Controls.Add(str23);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str21);
                        this.plhpurchase.Controls.Add(label22);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty22.ToLower() == "c")
                        {
                            DataTable dataTable43 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(dataRow19["EstimateItemID"]));
                            foreach (DataRow dataRow21 in dataTable43.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO5 = this;
                                totalProdAddItemsPendingForPO5.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO5.TotalProdAddItemsPending_forPO + 1;
                                string empty23 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox23 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(dataRow19["EstimateItemID"]), "_", dataRow21["EstimateAdditionalItemID"].ToString() };
                                checkBox23.ID = string.Concat(num);
                                checkBox23.Text = this.objBase.SpecialDecode(dataRow21["EstimateOtherCostName"].ToString());
                                DataTable dataTable44 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(dataRow19["EstimateItemID"]), Convert.ToInt64(dataRow21["EstimateAdditionalItemID"]));
                                foreach (DataRow row22 in dataTable44.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob5 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob5.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob5.TotalProdAddItemsPending_forPO - 1;
                                    checkBox23.Enabled = false;
                                    empty23 = (empty23 != "" ? string.Concat(empty23, ", ", row22["PONO"].ToString()) : string.Concat(empty23, row22["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox23);
                                if (!string.IsNullOrEmpty(empty23))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty23, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField5 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, dataRow19["EstimateItemID"].ToString(), "_", dataRow21["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField5.Value = string.Concat(value);
                            }
                        }
                        num14++;
                    }
                    Label label24 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable39.Rows.Count;
                    label24.Text = count.ToString();
                    label24.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label24);
                }
                else if (string.Compare(strArr2[1].Trim(), "C", true) == 0)
                {
                    int num16 = 0;
                    string empty24 = string.Empty;
                    CheckBox strItemTitle4 = new CheckBox();
                    CheckBox RptItem = new CheckBox();   //Modification
                    CheckBox checkBox24 = new CheckBox();
                    Label str24 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    str24.Style.Add("display", "none");
                    str24.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    strItemTitle4.ID = string.Concat(num);
                    strItemTitle4.Text = StrItemTitle;
                    strItemTitle4.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    //modification
                    num = new object[] { "chkRpt_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    RptItem.ID = string.Concat(num);
                    RptItem.Style.Add("display", "none");
                    //RptItem.Attributes.Add("style", "float : right;margin-right:80px");
                    //RptItem.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    ////
                    num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    checkBox24.ID = string.Concat(num);
                    checkBox24.Text = empty;
                    checkBox24.Attributes.Add("style", "margin-left:20px");
                    checkBox24.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox24.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable45 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                    foreach (DataRow dataRow22 in dataTable45.Rows)
                    {
                        strItemTitle4.Enabled = false;
                        checkBox24.Enabled = false;
                        empty24 = (empty24 != "" ? string.Concat(empty24, ", ", dataRow22["PONO"].ToString()) : string.Concat(empty24, dataRow22["PONO"].ToString()));
                    }
                    this.plhpurchase.Controls.Add(strItemTitle4);
                    this.plhpurchase.Controls.Add(RptItem); ///Modification
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty24.ToString(), "<br/>")));
                    this.plhpurchase.Controls.Add(checkBox24);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(str24);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    foreach (DataRow row23 in EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(EstimateItemID).Rows)
                    {
                        Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO6 = this;
                        totalProdAddItemsPendingForPO6.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO6.TotalProdAddItemsPending_forPO + 1;
                        string empty25 = string.Empty;
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        CheckBox checkBox25 = new CheckBox();
                        num = new object[] { "chkPoAdd_PrAd_0_", EstimateItemID, "_", row23["EstimateAdditionalItemID"].ToString() };
                        checkBox25.ID = string.Concat(num);
                        checkBox25.Text = this.objBase.SpecialDecode(row23["EstimateOtherCostName"].ToString());
                        DataTable dataTable46 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, EstimateItemID, Convert.ToInt64(row23["EstimateAdditionalItemID"]));
                        foreach (DataRow dataRow23 in dataTable46.Rows)
                        {
                            Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob6 = this;
                            usercontrolItemItemSummaryRaisePOFromJob6.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob6.TotalProdAddItemsPending_forPO - 1;
                            checkBox25.Enabled = false;
                            empty25 = (empty25 != "" ? string.Concat(empty25, ", ", dataRow23["PONO"].ToString()) : string.Concat(empty25, dataRow23["PONO"].ToString()));
                        }
                        this.plhpurchase.Controls.Add(checkBox25);
                        if (!string.IsNullOrEmpty(empty25))
                        {
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty25, " <br/>")));
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        HiddenField hiddenField6 = this.hdnProductAddItemsIDs;
                        num = new object[] { this.hdnProductAddItemsIDs.Value, EstimateItemID, "_", row23["EstimateAdditionalItemID"].ToString(), "±" };
                        hiddenField6.Value = string.Concat(num);
                    }
                    DataTable dataTable47 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow row24 in dataTable47.Rows)
                    {
                        if (num16 == 0)
                        {
                            num16 = 1;
                        }
                        Label label25 = new Label();
                        Label str25 = new Label();
                        label25.Text = row24["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num16 };
                        label25.ID = string.Concat(num);
                        label25.Style.Add("display", "none");
                        str25.Text = row24["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num16 };
                        str25.ID = string.Concat(num);
                        str25.Style.Add("display", "none");
                        string empty26 = string.Empty;
                        string str26 = string.Empty;
                        str26 = (row24["EstimateItemType"].ToString().ToLower() != "u" ? row24["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (str26.ToLower() != "l")
                        {
                            CheckBox checkBox26 = new CheckBox();
                            CheckBox RptItemAdd = new CheckBox(); ///Modification
                            num = new object[] { "chkPoAdd_0_", row24["EstimateItemID"].ToString(), "_", POCount, "_", num16 };
                            checkBox26.ID = string.Concat(num);
                            checkBox26.Text = row24["ItemTitle"].ToString();
                            //Modification
                            num = new object[] { "chkRptAdd_0_", row24["EstimateItemID"].ToString(), "_", POCount, "_", num16 };
                            num = new object[] { "chkRptAdd_0_", row24["EstimateItemID"].ToString() };
                            RptItemAdd.ID = string.Concat(num);
                            RptItemAdd.Attributes.Add("style", "margin-left:318px");
                            // ticket 110129,110331 just hide
                            RptItemAdd.Attributes.Add("style", "display:none");

                            //
                            DataTable dataTable48 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(row24["EstimateItemID"].ToString()), str26, EstimateBookletItemID);
                            foreach (DataRow dataRow24 in dataTable48.Rows)
                            {
                                checkBox26.Enabled = false;
                                empty26 = (empty26 != "" ? string.Concat(empty26, ", ", dataRow24["PONO"].ToString()) : string.Concat(empty26, dataRow24["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox26);
                            this.plhpurchase.Controls.Add(RptItemAdd);  ///Modification
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty26.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num17 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", row24["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable49 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(row24["EstimateItemID"].ToString()));
                            foreach (DataRow row25 in dataTable49.Rows)
                            {
                                CheckBox checkBox27 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num17, "_", row24["EstimateitemID"].ToString(), "_", POCount, "_", num16 };
                                checkBox27.ID = string.Concat(num);
                                checkBox27.Text = row25["MaterialName"].ToString();
                                string empty27 = string.Empty;
                                DataTable dataTable50 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(row24["EstimateItemID"].ToString()), str26, EstimateBookletItemID, Convert.ToInt64(row25["MaterialID"]));
                                foreach (DataRow dataRow25 in dataTable50.Rows)
                                {
                                    checkBox27.Enabled = false;
                                    empty27 = (empty27 != "" ? string.Concat(empty27, ", ", dataRow25["PONO"].ToString()) : string.Concat(empty27, dataRow25["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox27);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty27.ToString(), " <br/>")));
                                num17++;
                            }
                            Label label26 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", row24["EstimateItemID"].ToString()),
                                Text = num16.ToString()
                            };
                            label26.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label26);
                            Label label27 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num16 };
                            label27.ID = string.Concat(num);
                            label27.Style.Add("display", "none");
                            label27.Text = num17.ToString();
                            this.plhpurchase.Controls.Add(label27);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(label25);
                        this.plhpurchase.Controls.Add(str25);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (str26.ToLower() == "c")
                        {
                            DataTable dataTable51 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(row24["EstimateItemID"]));
                            foreach (DataRow row26 in dataTable51.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO7 = this;
                                totalProdAddItemsPendingForPO7.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO7.TotalProdAddItemsPending_forPO + 1;
                                string str27 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox28 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(row24["EstimateItemID"]), "_", row26["EstimateAdditionalItemID"].ToString() };
                                checkBox28.ID = string.Concat(num);
                                checkBox28.Text = this.objBase.SpecialDecode(row26["EstimateOtherCostName"].ToString());
                                DataTable dataTable52 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(row24["EstimateItemID"]), Convert.ToInt64(row26["EstimateAdditionalItemID"]));
                                foreach (DataRow dataRow26 in dataTable52.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob7 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob7.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob7.TotalProdAddItemsPending_forPO - 1;
                                    checkBox28.Enabled = false;
                                    str27 = (str27 != "" ? string.Concat(str27, ", ", dataRow26["PONO"].ToString()) : string.Concat(str27, dataRow26["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox28);
                                if (!string.IsNullOrEmpty(str27))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", str27, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField7 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, row24["EstimateItemID"].ToString(), "_", row26["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField7.Value = string.Concat(value);
                            }
                        }
                        num16++;
                    }
                    Label label28 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable47.Rows.Count;
                    label28.Text = count.ToString();
                    label28.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label28);
                    this.spnReplenishment.Style.Add("display", "none"); ///modification
                }
                else if (string.Compare(strArr2[1].Trim(), "X", true) == 0)
                {
                    int num18 = 0;
                    string empty28 = string.Empty;
                    CheckBox strItemTitle5 = new CheckBox();
                    CheckBox checkBox29 = new CheckBox();
                    Label str28 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    str28.Style.Add("display", "none");
                    str28.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    strItemTitle5.ID = string.Concat(num);
                    strItemTitle5.Text = StrItemTitle;
                    strItemTitle5.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    checkBox29.ID = string.Concat(num);
                    checkBox29.Text = empty;
                    checkBox29.Attributes.Add("style", "margin-left:20px");
                    checkBox29.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox29.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable53 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                    foreach (DataRow row27 in dataTable53.Rows)
                    {
                        strItemTitle5.Enabled = false;
                        checkBox29.Enabled = false;
                        empty28 = (empty28 != "" ? string.Concat(empty28, ", ", row27["PONO"].ToString()) : string.Concat(empty28, row27["PONO"].ToString()));
                    }
                    this.plhpurchase.Controls.Add(strItemTitle5);
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty28.ToString(), "<br/>")));
                    this.plhpurchase.Controls.Add(checkBox29);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(str28);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    foreach (DataRow dataRow27 in EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(EstimateItemID).Rows)
                    {
                        Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO8 = this;
                        totalProdAddItemsPendingForPO8.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO8.TotalProdAddItemsPending_forPO + 1;
                        string empty29 = string.Empty;
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        CheckBox checkBox30 = new CheckBox();
                        num = new object[] { "chkPoAdd_PrAd_0_", EstimateItemID, "_", dataRow27["EstimateAdditionalItemID"].ToString() };
                        checkBox30.ID = string.Concat(num);
                        checkBox30.Text = this.objBase.SpecialDecode(dataRow27["EstimateOtherCostName"].ToString());
                        DataTable dataTable54 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, EstimateItemID, Convert.ToInt64(dataRow27["EstimateAdditionalItemID"]));
                        foreach (DataRow row28 in dataTable54.Rows)
                        {
                            Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob8 = this;
                            usercontrolItemItemSummaryRaisePOFromJob8.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob8.TotalProdAddItemsPending_forPO - 1;
                            checkBox30.Enabled = false;
                            empty29 = (empty29 != "" ? string.Concat(empty29, ", ", row28["PONO"].ToString()) : string.Concat(empty29, row28["PONO"].ToString()));
                        }
                        this.plhpurchase.Controls.Add(checkBox30);
                        if (!string.IsNullOrEmpty(empty29))
                        {
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty29, " <br/>")));
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        HiddenField hiddenField8 = this.hdnProductAddItemsIDs;
                        num = new object[] { this.hdnProductAddItemsIDs.Value, EstimateItemID, "_", dataRow27["EstimateAdditionalItemID"].ToString(), "±" };
                        hiddenField8.Value = string.Concat(num);
                    }
                    DataTable dataTable55 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow dataRow28 in dataTable55.Rows)
                    {
                        if (num18 == 0)
                        {
                            num18 = 1;
                        }
                        Label label29 = new Label();
                        Label str29 = new Label();
                        label29.Text = dataRow28["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num18 };
                        label29.ID = string.Concat(num);
                        label29.Style.Add("display", "none");
                        str29.Text = dataRow28["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num18 };
                        str29.ID = string.Concat(num);
                        str29.Style.Add("display", "none");
                        string empty30 = string.Empty;
                        string str30 = string.Empty;
                        str30 = (dataRow28["EstimateItemType"].ToString().ToLower() != "u" ? dataRow28["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (str30.ToLower() != "l")
                        {
                            CheckBox checkBox31 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", dataRow28["EstimateItemID"].ToString(), "_", POCount, "_", num18 };
                            checkBox31.ID = string.Concat(num);
                            checkBox31.Text = dataRow28["ItemTitle"].ToString();
                            DataTable dataTable56 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(dataRow28["EstimateItemID"].ToString()), str30, EstimateBookletItemID);
                            foreach (DataRow row29 in dataTable56.Rows)
                            {
                                checkBox31.Enabled = false;
                                empty30 = (empty30 != "" ? string.Concat(empty30, ", ", row29["PONO"].ToString()) : string.Concat(empty30, row29["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox31);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty30.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num19 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", dataRow28["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable57 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(dataRow28["EstimateItemID"].ToString()));
                            foreach (DataRow dataRow29 in dataTable57.Rows)
                            {
                                CheckBox str31 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num19, "_", dataRow28["EstimateitemID"].ToString(), "_", POCount, "_", num18 };
                                str31.ID = string.Concat(num);
                                str31.Text = dataRow29["MaterialName"].ToString();
                                string empty31 = string.Empty;
                                DataTable dataTable58 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(dataRow28["EstimateItemID"].ToString()), str30, EstimateBookletItemID, Convert.ToInt64(dataRow29["MaterialID"]));
                                foreach (DataRow row30 in dataTable58.Rows)
                                {
                                    str31.Enabled = false;
                                    empty31 = (empty31 != "" ? string.Concat(empty31, ", ", row30["PONO"].ToString()) : string.Concat(empty31, row30["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(str31);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty31.ToString(), " <br/>")));
                                num19++;
                            }
                            Label label30 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", dataRow28["EstimateItemID"].ToString()),
                                Text = num18.ToString()
                            };
                            label30.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label30);
                            Label label31 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num18 };
                            label31.ID = string.Concat(num);
                            label31.Style.Add("display", "none");
                            label31.Text = num19.ToString();
                            this.plhpurchase.Controls.Add(label31);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(label29);
                        this.plhpurchase.Controls.Add(str29);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (str30.ToLower() == "c")
                        {
                            DataTable dataTable59 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(dataRow28["EstimateItemID"]));
                            foreach (DataRow dataRow30 in dataTable59.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO9 = this;
                                totalProdAddItemsPendingForPO9.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO9.TotalProdAddItemsPending_forPO + 1;
                                string empty32 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox32 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(dataRow28["EstimateItemID"]), "_", dataRow30["EstimateAdditionalItemID"].ToString() };
                                checkBox32.ID = string.Concat(num);
                                checkBox32.Text = this.objBase.SpecialDecode(dataRow30["EstimateOtherCostName"].ToString());
                                DataTable dataTable60 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(dataRow28["EstimateItemID"]), Convert.ToInt64(dataRow30["EstimateAdditionalItemID"]));
                                foreach (DataRow row31 in dataTable60.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob9 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob9.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob9.TotalProdAddItemsPending_forPO - 1;
                                    checkBox32.Enabled = false;
                                    empty32 = (empty32 != "" ? string.Concat(empty32, ", ", row31["PONO"].ToString()) : string.Concat(empty32, row31["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox32);
                                if (!string.IsNullOrEmpty(empty32))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty32, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField9 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, dataRow28["EstimateItemID"].ToString(), "_", dataRow30["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField9.Value = string.Concat(value);
                            }
                        }
                        num18++;
                    }
                    Label label32 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable55.Rows.Count;
                    label32.Text = count.ToString();
                    label32.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label32);
                }
                else if (string.Compare(strArr2[1].Trim(), "F", true) == 0)
                {
                    int num20 = 0;
                    string str32 = string.Empty;
                    CheckBox strItemTitle6 = new CheckBox();
                    CheckBox checkBox33 = new CheckBox();
                    Label label33 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    label33.Style.Add("display", "none");
                    label33.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    strItemTitle6.ID = string.Concat(num);
                    strItemTitle6.Text = StrItemTitle;
                    strItemTitle6.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    checkBox33.ID = string.Concat(num);
                    checkBox33.Text = empty;
                    checkBox33.Attributes.Add("style", "margin-left:20px");
                    checkBox33.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox33.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable61 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                    foreach (DataRow dataRow31 in dataTable61.Rows)
                    {
                        strItemTitle6.Enabled = false;
                        checkBox33.Enabled = false;
                        str32 = (str32 != "" ? string.Concat(str32, ", ", dataRow31["PONO"].ToString()) : string.Concat(str32, dataRow31["PONO"].ToString()));
                    }
                    this.plhpurchase.Controls.Add(strItemTitle6);
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str32.ToString(), "<br/>")));
                    this.plhpurchase.Controls.Add(checkBox33);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(label33);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    DataTable dataTable62 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow row32 in dataTable62.Rows)
                    {
                        if (num20 == 0)
                        {
                            num20 = 1;
                        }
                        Label str33 = new Label();
                        Label label34 = new Label();
                        str33.Text = row32["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num20 };
                        str33.ID = string.Concat(num);
                        str33.Style.Add("display", "none");
                        label34.Text = row32["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num20 };
                        label34.ID = string.Concat(num);
                        label34.Style.Add("display", "none");
                        string empty33 = string.Empty;
                        string empty34 = string.Empty;
                        empty34 = (row32["EstimateItemType"].ToString().ToLower() != "u" ? row32["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty34.ToLower() != "l")
                        {
                            CheckBox checkBox34 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", row32["EstimateItemID"].ToString(), "_", POCount, "_", num20 };
                            checkBox34.ID = string.Concat(num);
                            checkBox34.Text = row32["ItemTitle"].ToString();
                            DataTable dataTable63 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(row32["EstimateItemID"].ToString()), empty34, EstimateBookletItemID);
                            foreach (DataRow dataRow32 in dataTable63.Rows)
                            {
                                checkBox34.Enabled = false;
                                empty33 = (empty33 != "" ? string.Concat(empty33, ", ", dataRow32["PONO"].ToString()) : string.Concat(empty33, dataRow32["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox34);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty33.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num21 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", row32["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable64 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(row32["EstimateItemID"].ToString()));
                            foreach (DataRow row33 in dataTable64.Rows)
                            {
                                CheckBox str34 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num21, "_", row32["EstimateitemID"].ToString(), "_", POCount, "_", num20 };
                                str34.ID = string.Concat(num);
                                str34.Text = row33["MaterialName"].ToString();
                                string empty35 = string.Empty;
                                DataTable dataTable65 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(row32["EstimateItemID"].ToString()), empty34, EstimateBookletItemID, Convert.ToInt64(row33["MaterialID"]));
                                foreach (DataRow dataRow33 in dataTable65.Rows)
                                {
                                    str34.Enabled = false;
                                    empty35 = (empty35 != "" ? string.Concat(empty35, ", ", dataRow33["PONO"].ToString()) : string.Concat(empty35, dataRow33["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(str34);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty35.ToString(), " <br/>")));
                                num21++;
                            }
                            Label label35 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", row32["EstimateItemID"].ToString()),
                                Text = num20.ToString()
                            };
                            label35.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label35);
                            Label str35 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num20 };
                            str35.ID = string.Concat(num);
                            str35.Style.Add("display", "none");
                            str35.Text = num21.ToString();
                            this.plhpurchase.Controls.Add(str35);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str33);
                        this.plhpurchase.Controls.Add(label34);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty34.ToLower() == "c")
                        {
                            DataTable dataTable66 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(row32["EstimateItemID"]));
                            foreach (DataRow row34 in dataTable66.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO10 = this;
                                totalProdAddItemsPendingForPO10.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO10.TotalProdAddItemsPending_forPO + 1;
                                string empty36 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox35 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(row32["EstimateItemID"]), "_", row34["EstimateAdditionalItemID"].ToString() };
                                checkBox35.ID = string.Concat(num);
                                checkBox35.Text = this.objBase.SpecialDecode(row34["EstimateOtherCostName"].ToString());
                                DataTable dataTable67 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(row32["EstimateItemID"]), Convert.ToInt64(row34["EstimateAdditionalItemID"]));
                                foreach (DataRow dataRow34 in dataTable67.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob10 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob10.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob10.TotalProdAddItemsPending_forPO - 1;
                                    checkBox35.Enabled = false;
                                    empty36 = (empty36 != "" ? string.Concat(empty36, ", ", dataRow34["PONO"].ToString()) : string.Concat(empty36, dataRow34["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox35);
                                if (!string.IsNullOrEmpty(empty36))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty36, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField10 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, row32["EstimateItemID"].ToString(), "_", row34["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField10.Value = string.Concat(value);
                            }
                        }
                        num20++;
                    }
                    Label label36 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable62.Rows.Count;
                    label36.Text = count.ToString();
                    label36.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label36);
                }
                else if (string.Compare(strArr2[1].Trim(), "D", true) == 0)
                {
                    int num22 = 0;
                    string str36 = string.Empty;
                    CheckBox strItemTitle7 = new CheckBox();
                    CheckBox checkBox36 = new CheckBox();
                    Label label37 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    label37.Style.Add("display", "none");
                    label37.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    strItemTitle7.ID = string.Concat(num);
                    strItemTitle7.Text = StrItemTitle;
                    strItemTitle7.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    checkBox36.ID = string.Concat(num);
                    checkBox36.Text = empty;
                    checkBox36.Attributes.Add("style", "margin-left:20px");
                    checkBox36.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox36.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable68 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                    foreach (DataRow row35 in dataTable68.Rows)
                    {
                        strItemTitle7.Enabled = false;
                        str36 = (str36 != "" ? string.Concat(str36, ", ", row35["PONO"].ToString()) : string.Concat(str36, row35["PONO"].ToString()));
                    }
                    this.plhpurchase.Controls.Add(strItemTitle7);
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str36.ToString(), "<br/>")));
                    this.plhpurchase.Controls.Add(checkBox36);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(label37);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    DataTable dataTable69 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow dataRow35 in dataTable69.Rows)
                    {
                        if (num22 == 0)
                        {
                            num22 = 1;
                        }
                        Label str37 = new Label();
                        Label label38 = new Label();
                        str37.Text = dataRow35["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num22 };
                        str37.ID = string.Concat(num);
                        str37.Style.Add("display", "none");
                        label38.Text = dataRow35["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num22 };
                        label38.ID = string.Concat(num);
                        label38.Style.Add("display", "none");
                        string empty37 = string.Empty;
                        string empty38 = string.Empty;
                        empty38 = (dataRow35["EstimateItemType"].ToString().ToLower() != "u" ? dataRow35["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty38.ToLower() != "l")
                        {
                            CheckBox checkBox37 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", dataRow35["EstimateItemID"].ToString(), "_", POCount, "_", num22 };
                            checkBox37.ID = string.Concat(num);
                            checkBox37.Text = dataRow35["ItemTitle"].ToString();
                            DataTable dataTable70 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(dataRow35["EstimateItemID"].ToString()), empty38, EstimateBookletItemID);
                            foreach (DataRow row36 in dataTable70.Rows)
                            {
                                checkBox37.Enabled = false;
                                empty37 = (empty37 != "" ? string.Concat(empty37, ", ", row36["PONO"].ToString()) : string.Concat(empty37, row36["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox37);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty37.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num23 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", dataRow35["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable71 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(dataRow35["EstimateItemID"].ToString()));
                            foreach (DataRow dataRow36 in dataTable71.Rows)
                            {
                                CheckBox checkBox38 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num23, "_", dataRow35["EstimateitemID"].ToString(), "_", POCount, "_", num22 };
                                checkBox38.ID = string.Concat(num);
                                checkBox38.Text = dataRow36["MaterialName"].ToString();
                                string str38 = string.Empty;
                                DataTable dataTable72 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(dataRow35["EstimateItemID"].ToString()), empty38, EstimateBookletItemID, Convert.ToInt64(dataRow36["MaterialID"]));
                                foreach (DataRow row37 in dataTable72.Rows)
                                {
                                    checkBox38.Enabled = false;
                                    str38 = (str38 != "" ? string.Concat(str38, ", ", row37["PONO"].ToString()) : string.Concat(str38, row37["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox38);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str38.ToString(), " <br/>")));
                                num23++;
                            }
                            Label label39 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", dataRow35["EstimateItemID"].ToString()),
                                Text = num22.ToString()
                            };
                            label39.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label39);
                            Label str39 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num22 };
                            str39.ID = string.Concat(num);
                            str39.Style.Add("display", "none");
                            str39.Text = num23.ToString();
                            this.plhpurchase.Controls.Add(str39);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str37);
                        this.plhpurchase.Controls.Add(label38);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty38.ToLower() == "c")
                        {
                            DataTable dataTable73 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(dataRow35["EstimateItemID"]));
                            foreach (DataRow dataRow37 in dataTable73.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO11 = this;
                                totalProdAddItemsPendingForPO11.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO11.TotalProdAddItemsPending_forPO + 1;
                                string empty39 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox39 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(dataRow35["EstimateItemID"]), "_", dataRow37["EstimateAdditionalItemID"].ToString() };
                                checkBox39.ID = string.Concat(num);
                                checkBox39.Text = this.objBase.SpecialDecode(dataRow37["EstimateOtherCostName"].ToString());
                                DataTable dataTable74 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(dataRow35["EstimateItemID"]), Convert.ToInt64(dataRow37["EstimateAdditionalItemID"]));
                                foreach (DataRow row38 in dataTable74.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob11 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob11.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob11.TotalProdAddItemsPending_forPO - 1;
                                    checkBox39.Enabled = false;
                                    empty39 = (empty39 != "" ? string.Concat(empty39, ", ", row38["PONO"].ToString()) : string.Concat(empty39, row38["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox39);
                                if (!string.IsNullOrEmpty(empty39))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty39, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField11 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, dataRow35["EstimateItemID"].ToString(), "_", dataRow37["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField11.Value = string.Concat(value);
                            }
                        }
                        num22++;
                    }
                    Label label40 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable69.Rows.Count;
                    label40.Text = count.ToString();
                    label40.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label40);
                }
                else if (strArr2[1].Trim().ToUpper() == "N")
                {
                    int num24 = 0;
                    Label str40 = new Label()
                    {
                        ID = string.Concat("PoEstLithoNcrCount_", POCount)
                    };
                    str40.Style.Add("display", "none");
                    int num25 = 0;
                    dataTable1 = EstimatesBasePage.lithoncr_item_select(CompanyID, EstimateItemID);
                    foreach (DataRow dataRow38 in dataTable1.Rows)
                    {
                        string empty40 = string.Empty;
                        CheckBox strItemTitle8 = new CheckBox();
                        CheckBox checkBox40 = new CheckBox();
                        Label label41 = new Label();
                        num = new object[] { "PoEstBookletItemID_", POCount, "_", num25 };
                        label41.ID = string.Concat(num);
                        label41.Style.Add("display", "none");
                        EstimateBookletItemID = Convert.ToInt64(dataRow38["EstimateLithoNcrItemID"].ToString());
                        label41.Text = EstimateBookletItemID.ToString();
                        num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                        strItemTitle8.ID = string.Concat(num);
                        strItemTitle8.Attributes.Add("onclick", "javascript:selectone(this.id);");
                        num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                        checkBox40.ID = string.Concat(num);
                        checkBox40.Text = empty;
                        checkBox40.Attributes.Add("style", "margin-left:20px");
                        checkBox40.Attributes.Add("onclick", "javascript:selectone(this.id);");
                        if (empty == "")
                        {
                            checkBox40.Attributes.Add("style", "display:none");
                        }
                        if (dataTable1.Rows.Count != 1)
                        {
                            num = new object[] { StrItemTitle, " - Section(", num25 + 1, ")" };
                            strItemTitle8.Text = string.Concat(num);
                        }
                        else
                        {
                            strItemTitle8.Text = StrItemTitle;
                        }
                        DataTable dataTable75 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                        foreach (DataRow row39 in dataTable75.Rows)
                        {
                            strItemTitle8.Enabled = false;
                            checkBox40.Enabled = false;
                            empty40 = (empty40 != "" ? string.Concat(empty40, ", ", row39["PONO"].ToString()) : string.Concat(empty40, row39["PONO"].ToString()));
                        }
                        this.plhpurchase.Controls.Add(strItemTitle8);
                        this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty40.ToString(), "<br/>")));
                        this.plhpurchase.Controls.Add(checkBox40);
                        this.plhpurchase.Controls.Add(label41);
                        num25++;
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    }
                    str40.Text = num25.ToString();
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(str40);
                    DataTable dataTable76 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow dataRow39 in dataTable76.Rows)
                    {
                        if (num24 == 0)
                        {
                            num24 = 1;
                        }
                        Label str41 = new Label();
                        Label label42 = new Label();
                        str41.Text = dataRow39["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num24 };
                        str41.ID = string.Concat(num);
                        str41.Style.Add("display", "none");
                        label42.Text = dataRow39["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num24 };
                        label42.ID = string.Concat(num);
                        label42.Style.Add("display", "none");
                        string empty41 = string.Empty;
                        string empty42 = string.Empty;
                        empty42 = (dataRow39["EstimateItemType"].ToString().ToLower() != "u" ? dataRow39["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty42.ToLower() != "l")
                        {
                            CheckBox checkBox41 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", dataRow39["EstimateItemID"].ToString(), "_", POCount, "_", num24 };
                            checkBox41.ID = string.Concat(num);
                            checkBox41.Text = dataRow39["ItemTitle"].ToString();
                            DataTable dataTable77 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(dataRow39["EstimateItemID"].ToString()), empty42, EstimateBookletItemID);
                            foreach (DataRow row40 in dataTable77.Rows)
                            {
                                checkBox41.Enabled = false;
                                empty41 = (empty41 != "" ? string.Concat(empty41, ", ", row40["PONO"].ToString()) : string.Concat(empty41, row40["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox41);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty41.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num26 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", dataRow39["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable78 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(dataRow39["EstimateItemID"].ToString()));
                            foreach (DataRow dataRow40 in dataTable78.Rows)
                            {
                                CheckBox checkBox42 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num26, "_", dataRow39["EstimateitemID"].ToString(), "_", POCount, "_", num24 };
                                checkBox42.ID = string.Concat(num);
                                checkBox42.Text = dataRow40["MaterialName"].ToString();
                                string str42 = string.Empty;
                                DataTable dataTable79 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(dataRow39["EstimateItemID"].ToString()), empty42, EstimateBookletItemID, Convert.ToInt64(dataRow40["MaterialID"]));
                                foreach (DataRow row41 in dataTable79.Rows)
                                {
                                    checkBox42.Enabled = false;
                                    str42 = (str42 != "" ? string.Concat(str42, ", ", row41["PONO"].ToString()) : string.Concat(str42, row41["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox42);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str42.ToString(), " <br/>")));
                                num26++;
                            }
                            Label label43 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", dataRow39["EstimateItemID"].ToString()),
                                Text = num24.ToString()
                            };
                            label43.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label43);
                            Label str43 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num24 };
                            str43.ID = string.Concat(num);
                            str43.Style.Add("display", "none");
                            str43.Text = num26.ToString();
                            this.plhpurchase.Controls.Add(str43);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str41);
                        this.plhpurchase.Controls.Add(label42);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty42.ToLower() == "c")
                        {
                            DataTable dataTable80 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(dataRow39["EstimateItemID"]));
                            foreach (DataRow dataRow41 in dataTable80.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO12 = this;
                                totalProdAddItemsPendingForPO12.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO12.TotalProdAddItemsPending_forPO + 1;
                                string empty43 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox43 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(dataRow39["EstimateItemID"]), "_", dataRow41["EstimateAdditionalItemID"].ToString() };
                                checkBox43.ID = string.Concat(num);
                                checkBox43.Text = this.objBase.SpecialDecode(dataRow41["EstimateOtherCostName"].ToString());
                                DataTable dataTable81 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(dataRow39["EstimateItemID"]), Convert.ToInt64(dataRow41["EstimateAdditionalItemID"]));
                                foreach (DataRow row42 in dataTable81.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob12 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob12.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob12.TotalProdAddItemsPending_forPO - 1;
                                    checkBox43.Enabled = false;
                                    empty43 = (empty43 != "" ? string.Concat(empty43, ", ", row42["PONO"].ToString()) : string.Concat(empty43, row42["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox43);
                                if (!string.IsNullOrEmpty(empty43))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty43, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField12 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, dataRow39["EstimateItemID"].ToString(), "_", dataRow41["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField12.Value = string.Concat(value);
                            }
                        }
                        num24++;
                    }
                    Label label44 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable76.Rows.Count;
                    label44.Text = count.ToString();
                    label44.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label44);
                }
                else if (strArr2[1].Trim().ToUpper() == "R")
                {
                    int num24 = 0;
                    Label str40 = new Label()
                    {
                        ID = string.Concat("PoEstLithoNcrCount_", POCount)
                    };
                    str40.Style.Add("display", "none");
                    int num25 = 0;
                    dataTable1 = EstimatesBasePage.digitalncr_item_select(CompanyID, EstimateItemID);
                    foreach (DataRow dataRow38 in dataTable1.Rows)
                    {
                        string empty40 = string.Empty;
                        CheckBox strItemTitle8 = new CheckBox();
                        CheckBox checkBox40 = new CheckBox();
                        Label label41 = new Label();
                        num = new object[] { "PoEstBookletItemID_", POCount, "_", num25 };
                        label41.ID = string.Concat(num);
                        label41.Style.Add("display", "none");
                        EstimateBookletItemID = Convert.ToInt64(dataRow38["EstimateLithoNcrItemID"].ToString());
                        label41.Text = EstimateBookletItemID.ToString();
                        num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                        strItemTitle8.ID = string.Concat(num);
                        strItemTitle8.Attributes.Add("onclick", "javascript:selectone(this.id);");
                        num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                        checkBox40.ID = string.Concat(num);
                        checkBox40.Text = empty;
                        checkBox40.Attributes.Add("style", "margin-left:20px");
                        checkBox40.Attributes.Add("onclick", "javascript:selectone(this.id);");
                        if (empty == "")
                        {
                            checkBox40.Attributes.Add("style", "display:none");
                        }
                        if (dataTable1.Rows.Count != 1)
                        {
                            num = new object[] { StrItemTitle, " - Section(", num25 + 1, ")" };
                            strItemTitle8.Text = string.Concat(num);
                        }
                        else
                        {
                            strItemTitle8.Text = StrItemTitle;
                        }
                        DataTable dataTable75 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                        foreach (DataRow row39 in dataTable75.Rows)
                        {
                            strItemTitle8.Enabled = false;
                            checkBox40.Enabled = false;
                            empty40 = (empty40 != "" ? string.Concat(empty40, ", ", row39["PONO"].ToString()) : string.Concat(empty40, row39["PONO"].ToString()));
                        }
                        this.plhpurchase.Controls.Add(strItemTitle8);
                        this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty40.ToString(), "<br/>")));
                        this.plhpurchase.Controls.Add(checkBox40);
                        this.plhpurchase.Controls.Add(label41);
                        num25++;
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    }
                    str40.Text = num25.ToString();
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(str40);
                    DataTable dataTable76 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow dataRow39 in dataTable76.Rows)
                    {
                        if (num24 == 0)
                        {
                            num24 = 1;
                        }
                        Label str41 = new Label();
                        Label label42 = new Label();
                        str41.Text = dataRow39["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num24 };
                        str41.ID = string.Concat(num);
                        str41.Style.Add("display", "none");
                        label42.Text = dataRow39["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num24 };
                        label42.ID = string.Concat(num);
                        label42.Style.Add("display", "none");
                        string empty41 = string.Empty;
                        string empty42 = string.Empty;
                        empty42 = (dataRow39["EstimateItemType"].ToString().ToLower() != "u" ? dataRow39["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty42.ToLower() != "l")
                        {
                            CheckBox checkBox41 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", dataRow39["EstimateItemID"].ToString(), "_", POCount, "_", num24 };
                            checkBox41.ID = string.Concat(num);
                            checkBox41.Text = dataRow39["ItemTitle"].ToString();
                            DataTable dataTable77 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(dataRow39["EstimateItemID"].ToString()), empty42, EstimateBookletItemID);
                            foreach (DataRow row40 in dataTable77.Rows)
                            {
                                checkBox41.Enabled = false;
                                empty41 = (empty41 != "" ? string.Concat(empty41, ", ", row40["PONO"].ToString()) : string.Concat(empty41, row40["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox41);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty41.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num26 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", dataRow39["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable78 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(dataRow39["EstimateItemID"].ToString()));
                            foreach (DataRow dataRow40 in dataTable78.Rows)
                            {
                                CheckBox checkBox42 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num26, "_", dataRow39["EstimateitemID"].ToString(), "_", POCount, "_", num24 };
                                checkBox42.ID = string.Concat(num);
                                checkBox42.Text = dataRow40["MaterialName"].ToString();
                                string str42 = string.Empty;
                                DataTable dataTable79 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(dataRow39["EstimateItemID"].ToString()), empty42, EstimateBookletItemID, Convert.ToInt64(dataRow40["MaterialID"]));
                                foreach (DataRow row41 in dataTable79.Rows)
                                {
                                    checkBox42.Enabled = false;
                                    str42 = (str42 != "" ? string.Concat(str42, ", ", row41["PONO"].ToString()) : string.Concat(str42, row41["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox42);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str42.ToString(), " <br/>")));
                                num26++;
                            }
                            Label label43 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", dataRow39["EstimateItemID"].ToString()),
                                Text = num24.ToString()
                            };
                            label43.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label43);
                            Label str43 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num24 };
                            str43.ID = string.Concat(num);
                            str43.Style.Add("display", "none");
                            str43.Text = num26.ToString();
                            this.plhpurchase.Controls.Add(str43);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str41);
                        this.plhpurchase.Controls.Add(label42);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty42.ToLower() == "c")
                        {
                            DataTable dataTable80 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(dataRow39["EstimateItemID"]));
                            foreach (DataRow dataRow41 in dataTable80.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO12 = this;
                                totalProdAddItemsPendingForPO12.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO12.TotalProdAddItemsPending_forPO + 1;
                                string empty43 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox43 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(dataRow39["EstimateItemID"]), "_", dataRow41["EstimateAdditionalItemID"].ToString() };
                                checkBox43.ID = string.Concat(num);
                                checkBox43.Text = this.objBase.SpecialDecode(dataRow41["EstimateOtherCostName"].ToString());
                                DataTable dataTable81 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(dataRow39["EstimateItemID"]), Convert.ToInt64(dataRow41["EstimateAdditionalItemID"]));
                                foreach (DataRow row42 in dataTable81.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob12 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob12.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob12.TotalProdAddItemsPending_forPO - 1;
                                    checkBox43.Enabled = false;
                                    empty43 = (empty43 != "" ? string.Concat(empty43, ", ", row42["PONO"].ToString()) : string.Concat(empty43, row42["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox43);
                                if (!string.IsNullOrEmpty(empty43))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty43, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField12 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, dataRow39["EstimateItemID"].ToString(), "_", dataRow41["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField12.Value = string.Concat(value);
                            }
                        }
                        num24++;
                    }
                    Label label44 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable76.Rows.Count;
                    label44.Text = count.ToString();
                    label44.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label44);
                }
                else if (strArr2[1].Trim().ToUpper() == "K")
                {
                    int num27 = 0;
                    Label str44 = new Label()
                    {
                        ID = string.Concat("PoEstLithoBookletCount_", POCount)
                    };
                    str44.Style.Add("display", "none");
                    int num28 = 0;
                    dataTable1 = EstimatesBasePage.lithobooklet_item_select(CompanyID, EstimateItemID);
                    foreach (DataRow dataRow42 in dataTable1.Rows)
                    {
                        string empty44 = string.Empty;
                        EstimateBookletItemID = Convert.ToInt64(dataRow42["EstimateLithoBookletItemID"]);
                        CheckBox strItemTitle9 = new CheckBox();
                        CheckBox checkBox44 = new CheckBox();
                        Label label45 = new Label();
                        num = new object[] { "PoEstBookletItemID_", POCount, "_", num28 };
                        label45.ID = string.Concat(num);
                        label45.Style.Add("display", "none");
                        label45.Text = EstimateBookletItemID.ToString();
                        num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                        strItemTitle9.ID = string.Concat(num);
                        strItemTitle9.Attributes.Add("onclick", "javascript:selectone(this.id);");
                        num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                        checkBox44.ID = string.Concat(num);
                        checkBox44.Text = empty;
                        checkBox44.Attributes.Add("style", "margin-left:20px");
                        checkBox44.Attributes.Add("onclick", "javascript:selectone(this.id);");
                        if (empty == "")
                        {
                            checkBox44.Attributes.Add("style", "display:none");
                        }
                        if (dataTable1.Rows.Count != 1)
                        {
                            num = new object[] { StrItemTitle, " - Section(", num28 + 1, ")" };
                            strItemTitle9.Text = string.Concat(num);
                        }
                        else
                        {
                            strItemTitle9.Text = StrItemTitle;
                        }
                        DataTable dataTable82 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                        foreach (DataRow row43 in dataTable82.Rows)
                        {
                            strItemTitle9.Enabled = false;
                            checkBox44.Enabled = false;
                            empty44 = (empty44 != "" ? string.Concat(empty44, ", ", row43["PONO"].ToString()) : string.Concat(empty44, row43["PONO"].ToString()));
                        }
                        this.plhpurchase.Controls.Add(strItemTitle9);
                        this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty44.ToString(), "<br/>")));
                        this.plhpurchase.Controls.Add(checkBox44);
                        this.plhpurchase.Controls.Add(label45);
                        num28++;
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    }
                    str44.Text = num28.ToString();
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(str44);
                    DataTable dataTable83 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow dataRow43 in dataTable83.Rows)
                    {
                        if (num27 == 0)
                        {
                            num27 = 1;
                        }
                        Label str45 = new Label();
                        Label label46 = new Label();
                        str45.Text = dataRow43["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num27 };
                        str45.ID = string.Concat(num);
                        str45.Style.Add("display", "none");
                        label46.Text = dataRow43["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num27 };
                        label46.ID = string.Concat(num);
                        label46.Style.Add("display", "none");
                        string empty45 = string.Empty;
                        string empty46 = string.Empty;
                        empty46 = (dataRow43["EstimateItemType"].ToString().ToLower() != "u" ? dataRow43["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty46.ToLower() != "l")
                        {
                            CheckBox checkBox45 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", dataRow43["EstimateItemID"].ToString(), "_", POCount, "_", num27 };
                            checkBox45.ID = string.Concat(num);
                            checkBox45.Text = dataRow43["ItemTitle"].ToString();
                            DataTable dataTable84 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(dataRow43["EstimateItemID"].ToString()), empty46, EstimateBookletItemID);
                            foreach (DataRow row44 in dataTable84.Rows)
                            {
                                checkBox45.Enabled = false;
                                empty45 = (empty45 != "" ? string.Concat(empty45, ", ", row44["PONO"].ToString()) : string.Concat(empty45, row44["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox45);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty45.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num29 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", dataRow43["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable85 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(dataRow43["EstimateItemID"].ToString()));
                            foreach (DataRow dataRow44 in dataTable85.Rows)
                            {
                                CheckBox checkBox46 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num29, "_", dataRow43["EstimateitemID"].ToString(), "_", POCount, "_", num27 };
                                checkBox46.ID = string.Concat(num);
                                checkBox46.Text = dataRow44["MaterialName"].ToString();
                                string str46 = string.Empty;
                                DataTable dataTable86 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(dataRow43["EstimateItemID"].ToString()), empty46, EstimateBookletItemID, Convert.ToInt64(dataRow44["MaterialID"]));
                                foreach (DataRow row45 in dataTable86.Rows)
                                {
                                    checkBox46.Enabled = false;
                                    str46 = (str46 != "" ? string.Concat(str46, ", ", row45["PONO"].ToString()) : string.Concat(str46, row45["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox46);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str46.ToString(), " <br/>")));
                                num29++;
                            }
                            Label label47 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", dataRow43["EstimateItemID"].ToString()),
                                Text = num27.ToString()
                            };
                            label47.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label47);
                            Label str47 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num27 };
                            str47.ID = string.Concat(num);
                            str47.Style.Add("display", "none");
                            str47.Text = num29.ToString();
                            this.plhpurchase.Controls.Add(str47);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                        this.plhpurchase.Controls.Add(str45);
                        this.plhpurchase.Controls.Add(label46);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty46.ToLower() == "c")
                        {
                            DataTable dataTable87 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(dataRow43["EstimateItemID"]));
                            foreach (DataRow dataRow45 in dataTable87.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO13 = this;
                                totalProdAddItemsPendingForPO13.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO13.TotalProdAddItemsPending_forPO + 1;
                                string empty47 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox47 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(dataRow43["EstimateItemID"]), "_", dataRow45["EstimateAdditionalItemID"].ToString() };
                                checkBox47.ID = string.Concat(num);
                                checkBox47.Text = this.objBase.SpecialDecode(dataRow45["EstimateOtherCostName"].ToString());
                                DataTable dataTable88 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(dataRow43["EstimateItemID"]), Convert.ToInt64(dataRow45["EstimateAdditionalItemID"]));
                                foreach (DataRow row46 in dataTable88.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob13 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob13.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob13.TotalProdAddItemsPending_forPO - 1;
                                    checkBox47.Enabled = false;
                                    empty47 = (empty47 != "" ? string.Concat(empty47, ", ", row46["PONO"].ToString()) : string.Concat(empty47, row46["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox47);
                                if (!string.IsNullOrEmpty(empty47))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty47, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField13 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, dataRow43["EstimateItemID"].ToString(), "_", dataRow45["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField13.Value = string.Concat(value);
                            }
                        }
                        num27++;
                    }
                    Label label48 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable83.Rows.Count;
                    label48.Text = count.ToString();
                    label48.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label48);
                }
                else if (string.Compare(strArr2[1].Trim(), "Q", true) == 0)
                {
                    string empty48 = string.Empty;
                    CheckBox strItemTitle10 = new CheckBox();
                    CheckBox checkBox48 = new CheckBox();
                    Label str48 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    str48.Style.Add("display", "none");
                    str48.Text = EstimateBookletItemID.ToString();
                    num = new object[] { "chkPo_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    strItemTitle10.ID = string.Concat(num);
                    strItemTitle10.Text = StrItemTitle;
                    strItemTitle10.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    checkBox48.ID = string.Concat(num);
                    checkBox48.Text = empty;
                    checkBox48.Attributes.Add("style", "margin-left:20px");
                    checkBox48.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox48.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable89 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                    foreach (DataRow dataRow46 in dataTable89.Rows)
                    {
                        strItemTitle10.Enabled = false;
                        checkBox48.Enabled = false;
                        empty48 = (empty48 != "" ? string.Concat(empty48, ", ", dataRow46["PONO"].ToString()) : string.Concat(empty48, dataRow46["PONO"].ToString()));
                    }
                    this.plhpurchase.Controls.Add(strItemTitle10);
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty48.ToString(), "<br/>")));
                    this.plhpurchase.Controls.Add(checkBox48);
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(str48);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    Label label49 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID),
                        Text = "0"
                    };
                    label49.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(label49);
                }
                else if (string.Compare(strArr2[1].Trim(), "U", true) == 0)
                {
                    int num30 = 0;
                    string empty49 = string.Empty;
                    CheckBox strItemTitle11 = new CheckBox();
                    CheckBox checkBox49 = new CheckBox();
                    num = new object[] { "chkPo_0_", Convert.ToInt64(strArr2[0]), "_", EstimateBookletItemID, "_", POCount };
                    strItemTitle11.ID = string.Concat(num);
                    strItemTitle11.Text = StrItemTitle;
                    strItemTitle11.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    num = new object[] { "chkProductPO_0_", EstimateItemID, "_", EstimateBookletItemID, "_", POCount };
                    checkBox49.ID = string.Concat(num);
                    checkBox49.Text = empty;
                    checkBox49.Attributes.Add("style", "margin-left:20px");
                    checkBox49.Attributes.Add("onclick", "javascript:selectone(this.id);");
                    if (empty == "")
                    {
                        checkBox49.Attributes.Add("style", "display:none");
                    }
                    DataTable dataTable90 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, strArr2[1], EstimateBookletItemID);
                    foreach (DataRow row47 in dataTable90.Rows)
                    {
                        strItemTitle11.Enabled = false;
                        checkBox49.Enabled = false;
                        empty49 = (empty49 != "" ? string.Concat(empty49, ", ", row47["PONO"].ToString()) : string.Concat(empty49, row47["PONO"].ToString()));
                    }
                    Label str49 = new Label()
                    {
                        ID = string.Concat("PoEstBookletItemID_", POCount)
                    };
                    str49.Style.Add("display", "none");
                    str49.Text = EstimateBookletItemID.ToString();
                    this.plhpurchase.Controls.Add(strItemTitle11);
                    this.plhpurchase.Controls.Add(checkBox49);
                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty49.ToString(), "<br/>")));
                    this.plhpurchase.Controls.Add(label);
                    this.plhpurchase.Controls.Add(str49);
                    this.plhpurchase.Controls.Add(label1);
                    this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    DataTable dataTable91 = EstimatesBasePage.select_AdditionalItem_IDs(CompanyID, EstimateItemID, strArr2[1].ToString());
                    foreach (DataRow dataRow47 in dataTable91.Rows)
                    {
                        if (num30 == 0)
                        {
                            num30 = 1;
                        }
                        Label label50 = new Label();
                        Label str50 = new Label();
                        label50.Text = dataRow47["EstimateItemID"].ToString();
                        num = new object[] { "PoAddEstItemID_", POCount, "_", num30 };
                        label50.ID = string.Concat(num);
                        label50.Style.Add("display", "none");
                        str50.Text = dataRow47["EstimateItemType"].ToString();
                        num = new object[] { "PoAddEstType_", POCount, "_", num30 };
                        str50.ID = string.Concat(num);
                        str50.Style.Add("display", "none");
                        string empty50 = string.Empty;
                        string empty51 = string.Empty;
                        empty51 = (dataRow47["EstimateItemType"].ToString().ToLower() != "u" ? dataRow47["EstimateItemType"].ToString() : "");
                        this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:15px;'>"));
                        if (empty51.ToLower() != "l")
                        {
                            CheckBox checkBox50 = new CheckBox();
                            num = new object[] { "chkPoAdd_0_", dataRow47["EstimateItemID"].ToString(), "_", POCount, "_", num30 };
                            checkBox50.ID = string.Concat(num);
                            checkBox50.Text = dataRow47["ItemTitle"].ToString();
                            DataTable dataTable92 = PurchaseBasePage.purchase_select_by_EstimateItemID(CompanyID, EstimateID, Convert.ToInt64(dataRow47["EstimateItemID"].ToString()), empty51, EstimateBookletItemID);
                            foreach (DataRow row48 in dataTable92.Rows)
                            {
                                checkBox50.Enabled = false;
                                empty50 = (empty50 != "" ? string.Concat(empty50, ", ", row48["PONO"].ToString()) : string.Concat(empty50, row48["PONO"].ToString()));
                            }
                            this.plhpurchase.Controls.Add(checkBox50);
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", empty50.ToString(), " <br/>")));
                        }
                        else
                        {
                            int num31 = 0;
                            this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("<div style='padding-left:5px;'>", dataRow47["ItemTitle"].ToString(), "</div>")));
                            DataTable dataTable93 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(dataRow47["EstimateItemID"].ToString()));
                            foreach (DataRow dataRow48 in dataTable93.Rows)
                            {
                                CheckBox checkBox51 = new CheckBox();
                                num = new object[] { "chkPoAdd_", num31, "_", dataRow47["EstimateitemID"].ToString(), "_", POCount, "_", num30 };
                                checkBox51.ID = string.Concat(num);
                                checkBox51.Text = dataRow48["MaterialName"].ToString();
                                string str51 = string.Empty;
                                DataTable dataTable94 = PurchaseBasePage.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, Convert.ToInt64(dataRow47["EstimateItemID"].ToString()), empty51, EstimateBookletItemID, Convert.ToInt64(dataRow48["MaterialID"]));
                                foreach (DataRow row49 in dataTable94.Rows)
                                {
                                    checkBox51.Enabled = false;
                                    str51 = (str51 != "" ? string.Concat(str51, ", ", row49["PONO"].ToString()) : string.Concat(str51, row49["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox51);
                                this.plhpurchase.Controls.Add(new LiteralControl(string.Concat("  ", str51.ToString(), " <br/>")));
                                num31++;
                            }
                            Label label51 = new Label()
                            {
                                ID = string.Concat("PoAddItemCount_", dataRow47["EstimateItemID"].ToString()),
                                Text = num30.ToString()
                            };
                            label51.Style.Add("display", "none");
                            this.plhpurchase.Controls.Add(label51);
                            Label label52 = new Label();
                            num = new object[] { "PoSubMaterialCount_", POCount, "_", num30 };
                            label52.ID = string.Concat(num);
                            label52.Style.Add("display", "none");
                            label52.Text = num31.ToString();
                            this.plhpurchase.Controls.Add(label52);
                        }
                        this.plhpurchase.Controls.Add(new LiteralControl("<br/></div>"));
                        this.plhpurchase.Controls.Add(label50);
                        this.plhpurchase.Controls.Add(str50);
                        this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        if (empty51.ToLower() == "c")
                        {
                            DataTable dataTable95 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(Convert.ToInt64(dataRow47["EstimateItemID"]));
                            foreach (DataRow dataRow49 in dataTable95.Rows)
                            {
                                Item_Summary_RaisePO_From_Job totalProdAddItemsPendingForPO14 = this;
                                totalProdAddItemsPendingForPO14.TotalProdAddItemsPending_forPO = totalProdAddItemsPendingForPO14.TotalProdAddItemsPending_forPO + 1;
                                string empty52 = string.Empty;
                                this.plhpurchase.Controls.Add(new LiteralControl("<div style='padding-left:30px;'>"));
                                CheckBox checkBox52 = new CheckBox();
                                num = new object[] { "chkPoAdd_PrAd_0_", Convert.ToInt64(dataRow47["EstimateItemID"]), "_", dataRow49["EstimateAdditionalItemID"].ToString() };
                                checkBox52.ID = string.Concat(num);
                                checkBox52.Text = this.objBase.SpecialDecode(dataRow49["EstimateOtherCostName"].ToString());
                                DataTable dataTable96 = PurchaseBasePage.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, Convert.ToInt64(dataRow47["EstimateItemID"]), Convert.ToInt64(dataRow49["EstimateAdditionalItemID"]));
                                foreach (DataRow row50 in dataTable96.Rows)
                                {
                                    Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob14 = this;
                                    usercontrolItemItemSummaryRaisePOFromJob14.TotalProdAddItemsPending_forPO = usercontrolItemItemSummaryRaisePOFromJob14.TotalProdAddItemsPending_forPO - 1;
                                    checkBox52.Enabled = false;
                                    empty52 = (empty52 != "" ? string.Concat(empty52, ", ", row50["PONO"].ToString()) : string.Concat(empty52, row50["PONO"].ToString()));
                                }
                                this.plhpurchase.Controls.Add(checkBox52);
                                if (!string.IsNullOrEmpty(empty52))
                                {
                                    this.plhpurchase.Controls.Add(new LiteralControl(string.Concat(" - ", empty52, " <br/>")));
                                }
                                this.plhpurchase.Controls.Add(new LiteralControl("</div>"));
                                this.plhpurchase.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                                HiddenField hiddenField14 = this.hdnProductAddItemsIDs;
                                value = new string[] { this.hdnProductAddItemsIDs.Value, dataRow47["EstimateItemID"].ToString(), "_", dataRow49["EstimateAdditionalItemID"].ToString(), "±" };
                                hiddenField14.Value = string.Concat(value);
                            }
                        }
                        num30++;
                    }
                    Label str52 = new Label()
                    {
                        ID = string.Concat("PoAddCount_", EstimateItemID)
                    };
                    count = dataTable91.Rows.Count;
                    str52.Text = count.ToString();
                    str52.Style.Add("display", "none");
                    this.plhpurchase.Controls.Add(str52);
                }
                POCount++;
            }
            if (Module == "job" && POCount != 0)
            {
                int num32 = 0;
                int num33 = 0;
                for (int i = 0; i <= POCount - 1; i++)
                {
                    Label label53 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstItemID_", i));
                    Label label54 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstType_", i));
                    Label label55 = new Label();
                    if (label54 != null)
                    {
                        if (POCount == 1)
                        {
                            DataTable dataTable97 = EstimatesBasePage.PaperSupplied_select_ForPOCreate(Convert.ToInt64(label53.Text), label54.Text);
                            foreach (DataRow dataRow50 in dataTable97.Rows)
                            {
                                this.hdnPOforPaperSupplied.Value = dataRow50["IsPaperSupplied"].ToString().ToLower();
                            }
                        }
                        if (label54.Text == "B")
                        {
                            Label label56 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstDigiBookletCount_", i));
                            for (int j = 0; j <= Convert.ToInt16(label56.Text) - 1; j++)
                            {
                                PlaceHolder placeHolder = this.plhpurchase;
                                num = new object[] { "PoEstBookletItemID_", i, "_", j };
                                label55 = (Label)placeHolder.FindControl(string.Concat(num));
                                PlaceHolder placeHolder1 = this.plhpurchase;
                                num = new object[] { "chkPo_0_", label53.Text, "_", label55.Text, "_", i };
                                CheckBox checkBox53 = (CheckBox)placeHolder1.FindControl(string.Concat(num));
                                PlaceHolder placeHolder2 = this.plhpurchase;
                                num = new object[] { "chkProductPO_0_", label53.Text, "_", label55.Text, "_", i };
                                CheckBox checkBox54 = (CheckBox)placeHolder2.FindControl(string.Concat(num));
                                if (checkBox53.Enabled)
                                {
                                    num32++;
                                }
                                else if (checkBox54 != null && checkBox54.Enabled)
                                {
                                    num32++;
                                }
                            }
                        }
                        else if (label54.Text == "K")
                        {
                            Label label57 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstLithoBookletCount_", i));
                            for (int k = 0; k <= Convert.ToInt16(label57.Text) - 1; k++)
                            {
                                PlaceHolder placeHolder3 = this.plhpurchase;
                                num = new object[] { "PoEstBookletItemID_", i, "_", k };
                                label55 = (Label)placeHolder3.FindControl(string.Concat(num));
                                PlaceHolder placeHolder4 = this.plhpurchase;
                                num = new object[] { "chkPo_0_", label53.Text, "_", label55.Text, "_", i };
                                CheckBox checkBox55 = (CheckBox)placeHolder4.FindControl(string.Concat(num));
                                PlaceHolder placeHolder5 = this.plhpurchase;
                                num = new object[] { "chkProductPO_0_", label53.Text, "_", label55.Text, "_", i };
                                CheckBox checkBox56 = (CheckBox)placeHolder5.FindControl(string.Concat(num));
                                if (checkBox55.Enabled)
                                {
                                    num32++;
                                }
                                else if (checkBox56 != null && checkBox56.Enabled)
                                {
                                    num32++;
                                }
                            }
                        }
                        else if (label54.Text == "N")
                        {
                            Label label58 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstLithoNcrCount_", i));
                            for (int l = 0; l <= Convert.ToInt16(label58.Text) - 1; l++)
                            {
                                PlaceHolder placeHolder6 = this.plhpurchase;
                                num = new object[] { "PoEstBookletItemID_", i, "_", l };
                                label55 = (Label)placeHolder6.FindControl(string.Concat(num));
                                PlaceHolder placeHolder7 = this.plhpurchase;
                                num = new object[] { "chkPo_0_", label53.Text, "_", label55.Text, "_", i };
                                CheckBox checkBox57 = (CheckBox)placeHolder7.FindControl(string.Concat(num));
                                PlaceHolder placeHolder8 = this.plhpurchase;
                                num = new object[] { "chkProductPO_0_", label53.Text, "_", label55.Text, "_", i };
                                CheckBox checkBox58 = (CheckBox)placeHolder8.FindControl(string.Concat(num));
                                if (checkBox57.Enabled)
                                {
                                    num32++;
                                }
                                else if (checkBox58 != null && checkBox58.Enabled)
                                {
                                    num32++;
                                }
                            }
                        }
                        else if (label54.Text == "R")
                        {
                            Label label58 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstLithoNcrCount_", i));
                            for (int l = 0; l <= Convert.ToInt16(label58.Text) - 1; l++)
                            {
                                PlaceHolder placeHolder6 = this.plhpurchase;
                                num = new object[] { "PoEstBookletItemID_", i, "_", l };
                                label55 = (Label)placeHolder6.FindControl(string.Concat(num));
                                PlaceHolder placeHolder7 = this.plhpurchase;
                                num = new object[] { "chkPo_0_", label53.Text, "_", label55.Text, "_", i };
                                CheckBox checkBox57 = (CheckBox)placeHolder7.FindControl(string.Concat(num));
                                PlaceHolder placeHolder8 = this.plhpurchase;
                                num = new object[] { "chkProductPO_0_", label53.Text, "_", label55.Text, "_", i };
                                CheckBox checkBox58 = (CheckBox)placeHolder8.FindControl(string.Concat(num));
                                if (checkBox57.Enabled)
                                {
                                    num32++;
                                }
                                else if (checkBox58 != null && checkBox58.Enabled)
                                {
                                    num32++;
                                }
                            }
                        }
                        else if (label54.Text != "L")
                        {
                            label55 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstBookletItemID_", i));
                            PlaceHolder placeHolder9 = this.plhpurchase;
                            num = new object[] { "chkPo_0_", label53.Text, "_", label55.Text, "_", i };
                            CheckBox checkBox59 = (CheckBox)placeHolder9.FindControl(string.Concat(num));
                            PlaceHolder placeHolder10 = this.plhpurchase;
                            num = new object[] { "chkProductPO_0_", label53.Text, "_", label55.Text, "_", i };
                            CheckBox checkBox60 = (CheckBox)placeHolder10.FindControl(string.Concat(num));
                            if (checkBox59 != null)
                            {
                                if (checkBox59.Enabled)
                                {
                                    num32++;
                                }
                            }
                            else if (checkBox60 != null && checkBox60.Enabled)
                            {
                                num32++;
                            }
                        }
                        else
                        {
                            label55 = (Label)this.plhpurchase.FindControl(string.Concat("PoEstBookletItemID_", i));
                            DataTable dataTable98 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(label53.Text));
                            int num34 = 0;
                            bool flag = false;
                            foreach (DataRow row51 in dataTable98.Rows)
                            {
                                PlaceHolder placeHolder11 = this.plhpurchase;
                                num = new object[] { "chkPo_", num34, "_", label53.Text, "_", label55.Text, "_", i };
                                CheckBox checkBox61 = (CheckBox)placeHolder11.FindControl(string.Concat(num));
                                if (checkBox61 != null && checkBox61.Enabled)
                                {
                                    flag = true;
                                }
                                num34++;
                            }
                            if (flag)
                            {
                                num32++;
                            }
                            PlaceHolder placeHolder12 = this.plhpurchase;
                            num = new object[] { "chkProductPO_0_", label53.Text, "_", label55.Text, "_", i };
                            CheckBox checkBox62 = (CheckBox)placeHolder12.FindControl(string.Concat(num));
                            if (checkBox62 != null && checkBox62.Enabled)
                            {
                                num32++;
                            }
                        }
                        Label label59 = (Label)this.plhpurchase.FindControl(string.Concat("PoAddCount_", label53.Text));
                        if (Convert.ToInt32(label59.Text) != 0)
                        {
                            for (int m = 1; m <= Convert.ToInt32(label59.Text); m++)
                            {
                                PlaceHolder placeHolder13 = this.plhpurchase;
                                num = new object[] { "PoAddEstItemID_", i, "_", m };
                                Label label60 = (Label)placeHolder13.FindControl(string.Concat(num));
                                int num35 = 0;
                                DataTable dataTable99 = EstimatesBasePage.Materials_select_ForPOCreate(Convert.ToInt64(label60.Text));
                                if (dataTable99.Rows.Count <= 0)
                                {
                                    PlaceHolder placeHolder14 = this.plhpurchase;
                                    num = new object[] { "chkPoAdd_0_", label60.Text, "_", i, "_", m };
                                    CheckBox checkBox63 = (CheckBox)placeHolder14.FindControl(string.Concat(num));
                                    if (checkBox63 != null && checkBox63.Enabled)
                                    {
                                        num33++;
                                    }
                                }
                                else
                                {
                                    bool flag1 = false;
                                    foreach (DataRow dataRow51 in dataTable99.Rows)
                                    {
                                        PlaceHolder placeHolder15 = this.plhpurchase;
                                        num = new object[] { "chkPoAdd_", num35, "_", label60.Text, "_", i, "_", m };
                                        CheckBox checkBox64 = (CheckBox)placeHolder15.FindControl(string.Concat(num));
                                        if (checkBox64 != null && checkBox64.Enabled)
                                        {
                                            flag1 = true;
                                        }
                                        num35++;
                                    }
                                    if (flag1)
                                    {
                                        num33++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (num32 != 0 || num33 != 0 || this.TotalProdAddItemsPending_forPO != 0)
                {
                    this.btnCreatePo.Enabled = true;
                    this.spnPOCreate.Style.Add("display", "inline");
                    this.spnNoItemsTocreatePO.Style.Add("display", "none");
                    this.hidPoEnable.Value = "yes";
                }
                else
                {
                    this.btnCreatePo.Enabled = false;
                    this.spnNoItemsTocreatePO.Style.Add("display", "block");
                    this.spnPOCreate.Style.Add("display", "none");
                    this.hidPoEnable.Value = "no";
                }
            }
            RetPOCount = POCount;
            

        }

        public void FindControl(Control controls)
        {
            foreach (Control c in controls.Controls)
            {
                if (c.HasControls())
                {
                    FindControl(c);
                }
                else if (c.GetType().ToString().Equals("System.Web.UI.WebControls.RadioButton"))
                {
                    if ((c as RadioButton).Checked)
                    {
                        string id = c.ID;
                        //Response.Write(c.ID);
                        //return;
                    }
                }

            }
        }

        public long Purchse_OrderInsert(int CompanyID, long EstimateID, long EstimateItemID, int QtyNumber, string ItemType, string JobNumber, long EstimateBookletItemID, string MainItemChecked, int BookletSectionNO, string PurchaseOrders, string ItemNumbers, int PO, out string AllPurchaseOrders, out string AllItemNumbers, bool isProductPOchk, bool isStockReplenish, long poNumber = 0, string isCombined = "no")
        {
            object[] purchaseOrders;
            char[] chrArray;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Purchase Footer").Rows)
            {
                str = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Purchase Header").Rows)
            {
                empty = dataRow["PhraseText"].ToString();
            }
            foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Delivery Instructions").Rows)
            {
                empty1 = row1["PhraseText"].ToString();
            }
            string jobNumber = JobNumber;
            long num = (long)0;
            int num1 = 0;
            int num2 = 0;
            long num3 = (long)0;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            int jobStatusID = 0;
            jobStatusID = SettingsBasePage.get_jobStatus_ID(CompanyID, "Awaiting Authorization");
            foreach (DataRow dataRow1 in SettingsBasePage.settings_estimatestatus_moduletype_select_new(CompanyID, "purchase").Rows)
            {
                jobStatusID = Convert.ToInt32(dataRow1["StatusID"].ToString());
            }
            long num4 = (long)0;
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            string str2 = string.Empty;
            string empty3 = string.Empty;
            long num5 = (long)0;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            int num6 = 0;
            int num7 = 0;
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            string pODN = string.Empty;
            decimal num11 = new decimal(0);
            decimal num12 = new decimal(0);
            long num13 = (long)0;
            long num14 = (long)0;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            int taxID = EstimatesBasePage.GetTaxID(CompanyID, EstimateID);
            decimal taxRate = EstimatesBasePage.GetTaxRate(CompanyID, EstimateID);
            string serverName = ConnectionClass.ServerName;
            int num15 = 0;
            commonClass _commonClass = this.commclass;
            string dateFormat = this.DateFormat;
            commonClass _commonClass1 = this.commclass;
            DateTime now = DateTime.Now.AddDays(5);
            string str5 = _commonClass.date_Check_new(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), CompanyID, this.UserID, true), CompanyID);
            commonClass _commonClass2 = this.commclass;
            string dateFormat1 = this.DateFormat;
            commonClass _commonClass3 = this.commclass;
            now = DateTime.Now;
            string str6 = _commonClass2.date_Check_new(dateFormat1, _commonClass3.Eprint_return_Date_Before_View(now.ToString(), CompanyID, this.UserID, true), CompanyID);
            DateTime dateTime = Convert.ToDateTime(str5);
            DateTime dateTime1 = Convert.ToDateTime(str6);
            decimal num16 = new decimal(0);
            bool flag = false;
            Label label = (Label)this.plhpurchase.FindControl(string.Concat("PoAddCount_", EstimateItemID));
            str4 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, ItemType.ToLower());
            str4 = (str4 != "a" ? "R" : "A");
            if (string.Compare(ItemType, "S", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow row2 in dataSet.Tables[0].Rows)
                {
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    if (Convert.ToInt64(row2["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(row2["PaperID"]);
                        str3 = "I";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(row2["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = row2["InventoryCode"].ToString();
                    pODN = row2["inventoryname"].ToString();
                    num6 = Convert.ToInt32(row2["Quantity"]);
                    num8 = Convert.ToDecimal(row2["PackedIn"]);
                    Convert.ToInt64(row2["EstimateSingleItemID"]);
                    num10 = Convert.ToDecimal(row2["PaperUnitPrice"]);
                    Convert.ToInt32(row2["PrintLayoutValue"]);
                    Convert.ToDecimal(row2["SetupSpoilage"]);
                    Convert.ToDecimal(row2["RunningSpoilage"]);
                    Convert.ToDecimal(row2["PaperMarkup"]);
                    num16 = Convert.ToDecimal(row2["InvSheets"]);
                    num14 = Convert.ToInt64(row2["DeliveryAddress"].ToString());
                    if (row2["ispriceperpack"].ToString().ToLower() == "true")
                    {
                        num11 = Convert.ToDecimal(row2["packedprice"]);
                        num9 = SummaryClass.ReturnPackedPrice(num16, num8, num11, new decimal(0), out num12);
                        num8 = num12;
                    }
                    else
                    {
                        num9 = num16 * num10;
                    }
                    num1 = Convert.ToInt32(row2["SupplierID"].ToString());
                    num2 = Convert.ToInt32(row2["ContactID"].ToString());
                    num3 = Convert.ToInt64(row2["AddressID"].ToString());
                    str1 = row2["AddressType"].ToString();
                    if (row2["IsPaperSupplied"].ToString().ToLower() != "true")
                    {
                        num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                        this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                        decimal num17 = (num9 * taxRate) / new decimal(100);
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num16), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num17, num15, "", false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        foreach (DataRow dataRow2 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                        {
                            empty5 = dataRow2["PONO"].ToString();
                        }
                        if (PurchaseOrders != "")
                        {
                            PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                        }
                        purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                        PurchaseOrders = string.Concat(purchaseOrders);
                    }
                    string empty6 = string.Empty;
                    foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty6 = row3["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty6);
                }
                if (this.hid_AdditionalItemIDs.Value != "")
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "P", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow dataRow3 in dataSet.Tables[0].Rows)
                {
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    if (Convert.ToInt64(dataRow3["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(dataRow3["PaperID"]);
                        str3 = "I";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(dataRow3["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = dataRow3["InventoryCode"].ToString();
                    pODN = dataRow3["inventoryname"].ToString();
                    num6 = Convert.ToInt32(dataRow3["Quantity"]);
                    num8 = Convert.ToDecimal(dataRow3["PackedIn"]);
                    Convert.ToInt64(dataRow3["EstimatePadItemID"]);
                    num10 = Convert.ToDecimal(dataRow3["PaperUnitPrice"]);
                    Convert.ToInt32(dataRow3["PrintLayoutValue"]);
                    Convert.ToDecimal(dataRow3["SetupSpoilage"]);
                    Convert.ToDecimal(dataRow3["RunningSpoilage"]);
                    Convert.ToDecimal(dataRow3["PaperMarkup"]);
                    num16 = Convert.ToDecimal(dataRow3["InvSheets"]);
                    num14 = Convert.ToInt64(dataRow3["DeliveryAddress"].ToString());
                    if (dataRow3["LeavesPerPad"] != null)
                    {
                        Convert.ToDecimal(dataRow3["LeavesPerPad"]);
                    }
                    if (dataRow3["ispriceperpack"].ToString().ToLower() == "true")
                    {
                        num11 = Convert.ToDecimal(dataRow3["packedprice"]);
                        num9 = SummaryClass.ReturnPackedPrice(num16, num8, num11, new decimal(0), out num12);
                        num8 = num12;
                    }
                    else
                    {
                        num9 = num16 * num10;
                    }
                    num1 = Convert.ToInt32(dataRow3["SupplierID"].ToString());
                    num2 = Convert.ToInt32(dataRow3["ContactID"].ToString());
                    num3 = Convert.ToInt64(dataRow3["AddressID"].ToString());
                    str1 = dataRow3["AddressType"].ToString();
                    long num18 = this.objCom.settings_lastcounter_select(CompanyID, "p") + (long)1;
                    long num19 = (long)10000000 + num18;
                    this.PONO = string.Concat("PO-", num19.ToString().Substring(1, num19.ToString().Length - 1));
                    if (dataRow3["IsPaperSupplied"].ToString().ToLower() != "true")
                    {
                        num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                        this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                        decimal num20 = (num9 * taxRate) / new decimal(100);
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num16), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num20, num15, "", false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        foreach (DataRow row4 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                        {
                            empty5 = row4["PONO"].ToString();
                        }
                        if (PurchaseOrders != "")
                        {
                            PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                        }
                        purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                        PurchaseOrders = string.Concat(purchaseOrders);
                    }
                    string empty7 = string.Empty;
                    foreach (DataRow dataRow4 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty7 = dataRow4["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty7);
                }
                if (this.hid_AdditionalItemIDs.Value != "")
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "L", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                int num21 = 0;
                foreach (DataRow row5 in dataSet.Tables[0].Rows)
                {
                    PlaceHolder placeHolder = this.plhpurchase;
                    purchaseOrders = new object[] { "chkPo_", num21, "_", EstimateItemID, "_", EstimateBookletItemID, "_", PO };
                    CheckBox checkBox = (CheckBox)placeHolder.FindControl(string.Concat(purchaseOrders));
                    if (MainItemChecked.ToString().ToLower() == "yes" && (checkBox.Checked || isProductPOchk) && num21 >= 0)
                    {
                        if (Convert.ToInt64(row5["productID"]) <= (long)0 || !isProductPOchk)
                        {
                            num5 = Convert.ToInt64(row5["PaperID"]);
                            str3 = "I";
                        }
                        else
                        {
                            num5 = Convert.ToInt64(row5["productID"]);
                            str3 = "W";
                            flag = true;
                        }
                        empty4 = row5["InventoryCode"].ToString();
                        pODN = row5["inventoryname"].ToString();
                        num6 = Convert.ToInt32(row5["Quantity"]);
                        num8 = Convert.ToDecimal(row5["PackedIn"]);
                        Convert.ToInt64(row5["EstimateLargeItemID"]);
                        num10 = Convert.ToDecimal(row5["PaperUnitPrice"]);
                        Convert.ToInt32(row5["PrintLayoutValue"]);
                        Convert.ToDecimal(row5["SetupSpoilage"]);
                        Convert.ToDecimal(row5["RunningSpoilage"]);
                        Convert.ToDecimal(row5["PaperMarkup"]);
                        num13 = Convert.ToInt64(row5["EstLargeItemCalculationID"]);
                        num16 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, Convert.ToDecimal(row5["InvSheets"].ToString()), 0, "", false, false, true));
                        num14 = Convert.ToInt64(row5["DeliveryAddress"].ToString());
                        Convert.ToDecimal(row5["JobHeight"]);
                        Convert.ToDecimal(row5["JobWidth"]);
                        Convert.ToDecimal(row5["SheetHeight"]);
                        Convert.ToDecimal(row5["SheetWidth"]);
                        Convert.ToDecimal(row5["GutterHorizontal"]);
                        Convert.ToDecimal(row5["GutterVertical"]);
                        Convert.ToDecimal(row5["Row"]);
                        Convert.ToDecimal(row5["Col"]);
                        row5["PrintLayout"].ToString();
                        row5["PressPaperType"].ToString();
                        if (row5["ispriceperpack"].ToString().ToLower() == "true")
                        {
                            num11 = Convert.ToDecimal(row5["packedprice"]);
                            num9 = SummaryClass.ReturnPackedPrice(num16, num8, num11, new decimal(0), out num12);
                            num8 = num12;
                        }
                        else
                        {
                            num9 = num16 * num10;
                        }
                        num1 = Convert.ToInt32(row5["SupplierID"].ToString());
                        num2 = Convert.ToInt32(row5["ContactID"].ToString());
                        num3 = Convert.ToInt64(row5["AddressID"].ToString());
                        str1 = row5["AddressType"].ToString();
                        if (row5["IsPaperSupplied"].ToString().ToLower() != "true")
                        {
                            num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                            this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                            decimal num22 = (num9 * taxRate) / new decimal(100);
                            num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num16), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num22, num15, "", false, EstimateItemID, ItemType, flag, num13, this.UserID, this.CreatedDate);
                            foreach (DataRow dataRow5 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                            {
                                empty5 = dataRow5["PONO"].ToString();
                            }
                            if (PurchaseOrders != "")
                            {
                                PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                            }
                            purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                            PurchaseOrders = string.Concat(purchaseOrders);
                        }
                        string str7 = string.Empty;
                        foreach (DataRow row6 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                        {
                            str7 = row6["rownumber"].ToString();
                        }
                        if (ItemNumbers != "")
                        {
                            ItemNumbers = string.Concat(ItemNumbers, ", ");
                        }
                        ItemNumbers = string.Concat(ItemNumbers, "Item ", str7);
                    }
                    num21 = (!isProductPOchk ? num21 + 1 : -1);
                }
                if (this.hid_AdditionalItemIDs.Value != "")
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "B", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow dataRow6 in dataSet.Tables[0].Rows)
                {
                    if (EstimateBookletItemID != Convert.ToInt64(dataRow6["EstimateBookletItemID"]) || !(MainItemChecked.ToString().ToLower() == "yes"))
                    {
                        continue;
                    }
                    if (Convert.ToInt64(dataRow6["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(dataRow6["PaperID"]);
                        str3 = "I";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(dataRow6["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = dataRow6["InventoryCode"].ToString();
                    pODN = dataRow6["inventoryname"].ToString();
                    num6 = Convert.ToInt32(dataRow6["Quantity"]);
                    num8 = Convert.ToDecimal(dataRow6["PackedIn"]);
                    Convert.ToInt64(dataRow6["EstimateBookletItemID"]);
                    num10 = Convert.ToDecimal(dataRow6["PaperUnitPrice"]);
                    Convert.ToDecimal(dataRow6["NoOfSignatures"]);
                    Convert.ToDecimal(dataRow6["SetupSpoilage"]);
                    Convert.ToDecimal(dataRow6["RunningSpoilage"]);
                    Convert.ToDecimal(dataRow6["PaperMarkup"]);
                    num16 = Convert.ToDecimal(dataRow6["InvSheets"]);
                    num14 = Convert.ToInt64(dataRow6["DeliveryAddress"].ToString());
                    if (dataRow6["ispriceperpack"].ToString().ToLower() == "true")
                    {
                        num11 = Convert.ToDecimal(dataRow6["packedprice"]);
                        num9 = SummaryClass.ReturnPackedPrice(num16, num8, num11, new decimal(0), out num12);
                        num8 = num12;
                    }
                    else
                    {
                        num9 = num16 * num10;
                    }
                    num1 = Convert.ToInt32(dataRow6["SupplierID"].ToString());
                    num2 = Convert.ToInt32(dataRow6["ContactID"].ToString());
                    num3 = Convert.ToInt64(dataRow6["AddressID"].ToString());
                    str1 = dataRow6["AddressType"].ToString();
                    if (dataRow6["IsPaperSupplied"].ToString().ToLower() != "true")
                    {
                        num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                        if (this.RowPos == 0)
                        {
                            this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                            Item_Summary_RaisePO_From_Job rowPos = this;
                            rowPos.RowPos = rowPos.RowPos + 1;
                        }
                        decimal num23 = (num9 * taxRate) / new decimal(100);
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num16), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num23, num15, "", false, EstimateBookletItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        foreach (DataRow row7 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                        {
                            empty5 = row7["PONO"].ToString();
                        }
                        if (PurchaseOrders != "")
                        {
                            PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                        }
                        purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                        PurchaseOrders = string.Concat(purchaseOrders);
                    }
                    string empty8 = string.Empty;
                    foreach (DataRow dataRow7 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty8 = dataRow7["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty8);
                }
                if (this.hid_AdditionalItemIDs.Value != "" && BookletSectionNO == 0)
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "O", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
               
                if(this.hdnCombinedValue.Value.ToString()=="no" && mainitemcount == 1)
                {
                    dtoutworksubitems = dataSet.Tables[2];
                }
                foreach (DataRow row8 in dataSet.Tables[0].Rows)
                {
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    if (Convert.ToInt64(row8["productID"]) > (long)0 && isProductPOchk)
                    {
                        num5 = Convert.ToInt64(row8["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    else if (Convert.ToInt64(row8["PriceCatalogueID"]) <= (long)0)
                    {
                        num5 = (long)0;
                        str3 = "A";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(row8["PriceCatalogueID"]);
                        str3 = "W";
                        flag = false;
                    }
                    empty4 = "";
                    num6 = Convert.ToInt32(row8["Quantity"]);
                    num7 = 0;
                    num9 = Convert.ToDecimal(row8["Price"]);
                    num14 = Convert.ToInt64(row8["DeliveryAddress"].ToString());
                    num1 = Convert.ToInt32(row8["SupplierID"].ToString());
                    num2 = Convert.ToInt32(row8["SupplierContactID"].ToString());
                    num3 = Convert.ToInt64(row8["AddressID"].ToString());
                    str1 = row8["AddressType"].ToString();
                    string str8 = row8["SupplierRefNo"].ToString();
                    string str9 = row8["ItemDescription"].ToString();
                    string empty9 = string.Empty;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays = str9.Split(chrArray);
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        if (i == 10 && strArrays[i] != "")
                        {
                            string str10 = strArrays[i];
                            chrArray = new char[] { '»' };
                            string[] strArrays1 = str10.Split(chrArray);
                            for (int j = 0; j < (int)strArrays1.Length; j++)
                            {
                                if (j == 2 && string.Compare(strArrays1[3].ToString(), "true", true) == 0)
                                {
                                    empty9 = strArrays1[2].ToString();
                                }
                            }
                        }
                    }
                    pODN = SummaryClass.Split_ItemDescription(row8["ItemDescription"].ToString());
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), str8, "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num24 = (num9 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num9), taxID, num24, num15, empty9, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    string selected_value = this.hdnCombinedValue.Value.ToString();
                    if(selected_value == "no")
                    {
                        //DataTable dt = PurchaseBasePage.GetPurchaseItemByJobID(this.jobID,this.CompanyID, num1);
                        //foreach(DataRow dr in dt.Rows)
                        //{
                        //    if(EstimateItemID != Convert.ToInt64(dr["EstimateItemID"].ToString()))
                        //    {
                        //        int purchaseCount = PurchaseBasePage.GetPurchaseItemcount(num, ItemType, dr["Description"].ToString(), Convert.ToDecimal(dr["Qty"].ToString()), Convert.ToDecimal(dr["Price"].ToString()), Convert.ToInt32(dr["TaxID"].ToString()), Convert.ToDecimal(dr["TaxValue"].ToString()));
                        //        if(purchaseCount == 0)
                        //        {
                        //            num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, Convert.ToInt64(dr["WarehouseItemID"].ToString()), dr["WarehouseItemType"].ToString(), dr["ItemCode"].ToString(), dr["Description"].ToString(), Convert.ToDecimal(dr["Qty"].ToString()), Convert.ToDecimal(dr["PackedIn"].ToString()), Convert.ToDecimal(dr["Price"].ToString()), Convert.ToInt32(dr["TaxID"].ToString()), Convert.ToDecimal(dr["TaxValue"].ToString()), Convert.ToInt32(dr["AccountCodeID"].ToString()), dr["Note"].ToString(), Convert.ToBoolean(dr["IsGoodsReceived"].ToString()), EstimateItemID, ItemType, Convert.ToBoolean(dr["IsGoodsReceived"].ToString()), (long)0, this.UserID, this.CreatedDate);
                        //        }
                        //    }
                        //}

                        if (this.hid_AdditionalItemIDs.Value != "" )
                        {
                            foreach (DataRow row2 in dtoutworksubitems.Rows)
                            {

                                if (string.Compare(row2["PoType"].ToString(), "Outwork", true) != 0 || string.Compare(row2["IsEmpty"].ToString(), "No", true) != 0 || !this.hid_AdditionalItemIDs.Value.ToString().Contains(row2["EstimateItemID"].ToString()) || num1 != Convert.ToInt32(row2["SupplierID"].ToString()))
                                {
                                    continue;
                                }

                                if (EstimateItemID != Convert.ToInt64(row2["EstimateItemID"].ToString()))
                                {

                                    int taxIDex = EstimatesBasePage.GetTaxID(CompanyID, EstimateID);
                                    decimal taxRateex = EstimatesBasePage.GetTaxRate(CompanyID, EstimateID);
                                    decimal taxvalueex= (Convert.ToDecimal(row2["Price"]) * taxRate) / new decimal(100);

                                    int purchaseCount = PurchaseBasePage.GetPurchaseItemcount(num, ItemType, row2["Description"].ToString(), Convert.ToDecimal(row2["Quantity"].ToString()), Convert.ToDecimal(row2["Price"].ToString()), taxIDex, taxvalueex);
                                    if (purchaseCount == 0)
                                    {
                                         var num4ex = (long)0;
                                        var empty2ex = "A";
                                        var empty3ex = "";
                                        var num5ex = Convert.ToInt32(row2["Quantity"]);
                                        var num6ex = 0;
                                        var num7ex = Convert.ToDecimal(row2["Price"]);
                                        if (row2["CostingType"].ToString().ToUpper() == "U")
                                        {
                                            num7ex = num7ex * num5ex;
                                        }
                                        EstimateItemID = (long)Convert.ToInt32(row2["EstimateItemID"].ToString());
                                        //num1 = Convert.ToInt32(row2["SupplierID"].ToString());
                                        //num2 = Convert.ToInt32(row2["SupplierContactID"].ToString());
                                        //num3 = Convert.ToInt64(row2["AddressID"].ToString());
                                        //empty = row2["AddressType"].ToString();
                                        string str7ex = SummaryClass.Split_ItemDescription(row2["Description"].ToString());
                                        string str8ex = row2["Notes"].ToString();
                                        //num14 = Convert.ToInt64(row2["DeliveryAddress"].ToString());
                                        //empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "o");
                                        //empty6 = (empty6 != "a" ? "R" : "A");
                                        //num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), row2["SupplierRefNo"].ToString(), "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                                        this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                                        decimal num16ex = (num7 * taxRate) / new decimal(100);
                                        PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4ex, empty2ex, empty3ex, str7ex, num5ex, num6ex, Convert.ToDecimal(num7ex), taxID, num16ex, 0, str8ex, false, EstimateItemID, "O", (long)0, UserID, this.CreatedDate);
                                     

                                    }
                                }
                            }
                        }

                    }
                    foreach (DataRow dataRow8 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                    {
                        empty5 = dataRow8["PONO"].ToString();
                    }
                    if (PurchaseOrders != "")
                    {
                        PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                    }
                    purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                    PurchaseOrders = string.Concat(purchaseOrders);
                    string empty10 = string.Empty;
                    foreach (DataRow row9 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty10 = row9["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty10);
                }
                
                if (this.hid_AdditionalItemIDs.Value != "" && ( isAnyMainOutworkItemChecked == false ||  mainitemcount == Convert.ToInt32(this.hidPoCount.Value)))    
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "C", true) == 0)
            {
                string empty11 = string.Empty;
                pODN = this.objComn.ItemDescriptionToPO_DN(CompanyID, EstimateItemID, "Purchase", ref empty11);
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow dataRow9 in dataSet.Tables[0].Rows)
                {
                    long num25 = Convert.ToInt64(dataRow9["PriceCatalogueID"]);
                    int num26 = Convert.ToInt32(dataRow9["TotalTaxId"]);
                    decimal num27 = Convert.ToDecimal(dataRow9["TotalTaxRate"]);
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    if (isStockReplenish)
                    {
                        dataRow9["IsStockReplenish"] = true;
                        /////Modification
                        string[] strArrays;
                        string RptSelect = string.Concat("; UPDATE tb_Estimateitem  SET IsStockReplenishitem = 1 WHERE EstimateItemID=", this.EstimateItemID);
                        int companyID = this.CompanyID;
                        strArrays = new string[] { " ", RptSelect.ToString() };
                        EstimateBasePage.Stock_Replenishment_insert(companyID, string.Concat(strArrays), this.EstimateItemID);

                    }
                    num5 = (long)0;
                    str3 = "A";
                    empty4 = "";
                    num6 = Convert.ToInt32(dataRow9["Quantity"]);
                    num7 = Convert.ToInt32(dataRow9["Quantity"]);
                    num9 = Convert.ToDecimal(dataRow9["Price"]);
                    num14 = Convert.ToInt64(dataRow9["DeliveryAddress"].ToString());
                    num1 = Convert.ToInt32(dataRow9["SupplierID"].ToString());
                    num2 = Convert.ToInt32(dataRow9["SupplierContactID"].ToString());
                    num3 = Convert.ToInt64(dataRow9["AddressID"].ToString());
                    str1 = dataRow9["AddressType"].ToString();
                    string str11 = dataRow9["ItemDescription"].ToString();
                    string empty12 = string.Empty;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays2 = str11.Split(chrArray);
                    for (int k = 0; k < (int)strArrays2.Length; k++)
                    {
                        if (k == 10 && strArrays2[k] != "")
                        {
                            string str12 = strArrays2[k];
                            chrArray = new char[] { '»' };
                            string[] strArrays3 = str12.Split(chrArray);
                            for (int l = 0; l < (int)strArrays3.Length; l++)
                            {
                                if (l == 2)
                                {
                                    empty12 = strArrays3[2].ToString();
                                }
                            }
                        }
                    }
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num28 = (num9 * num27) / new decimal(100);
                    DataTable dataTable1 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num25);
                    if(dataTable1.Rows[0]["PurAccountingCode"].ToString() != "0")
                    {
                        num15 = Convert.ToInt32(dataTable1.Rows[0]["PurAccountingCode"]);
                    }
                    if (dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                    {
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num9), num26, num28, num15, empty12, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    }
                    else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                    {
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num9), num26, num28, num15, empty12, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    }
                    else if (dataTable1.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                    {
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num9), num26, num28, num15, empty12, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    }
                    else
                    {
                        foreach (DataRow row10 in PurchaseBasePage.Kit_Details(num25).Rows)
                        {
                            int num29 = num6 * Convert.ToInt16(row10["Quantity"]);
                            DataTable dataTable2 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(row10["KitItemID"]));
                            string str13 = dataTable2.Rows[0]["ItemCode"].ToString();
                            string str14 = PurchaseBasePage.KitItemDescription(CompanyID, Convert.ToInt64(row10["KitItemID"])).Replace("»", "\n");
                            num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, Convert.ToInt64(row10["KitItemID"]), "W", str13, str14, Convert.ToDecimal(num29), Convert.ToDecimal(num7), Convert.ToDecimal(num9), num26, num28, num15, empty12, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        }
                    }
                    BaseClass baseClass = new BaseClass();
                    DataTable dataTable3 = baseClass.ProductStockType_Select((long)CompanyID, Convert.ToInt64(dataRow9["PriceCatalogueID"].ToString()));
                    foreach (DataRow dataRow10 in dataTable3.Rows)
                    {
                        if (dataRow10["DrawStockFrom"].ToString().ToLower() != "s")
                        {
                            if (dataRow10["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                continue;
                            }
                            PurchaseBasePage.ProgressToJob_StockItem_Update(Convert.ToInt64(dataRow9["PriceCatalogueID"].ToString()), num4);
                        }
                        else
                        {
                            PurchaseBasePage.ProgressToJob_StockItem_Update(Convert.ToInt64(dataRow9["PriceCatalogueID"].ToString()), num4);
                        }
                    }
                    foreach (DataRow row11 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                    {
                        empty5 = row11["PONO"].ToString();
                    }
                    if (PurchaseOrders != "")
                    {
                        PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                    }
                    purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                    PurchaseOrders = string.Concat(purchaseOrders);
                    string empty13 = string.Empty;
                    foreach (DataRow dataRow11 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty13 = dataRow11["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty13);
                }
                if (this.hid_AdditionalItemIDs.Value != "")
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "X", true) == 0)
            {
                string empty14 = string.Empty;
                pODN = this.objComn.ItemDescriptionToPO_DN(CompanyID, EstimateItemID, "Purchase", ref empty14);
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow row12 in dataSet.Tables[0].Rows)
                {
                    long num30 = Convert.ToInt64(row12["PriceCatalogueID"]);
                    int num31 = Convert.ToInt32(row12["TotalTaxId"]);
                    decimal num32 = Convert.ToDecimal(row12["TotalTaxRate"]);
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    num5 = (long)0;
                    str3 = "A";
                    empty4 = "";
                    num6 = Convert.ToInt32(row12["Quantity"]);
                    num7 = Convert.ToInt32(row12["Quantity"]);
                    num9 = Convert.ToDecimal(row12["Price"]);
                    num14 = Convert.ToInt64(row12["DeliveryAddress"].ToString());
                    num1 = Convert.ToInt32(row12["SupplierID"].ToString());
                    num2 = Convert.ToInt32(row12["SupplierContactID"].ToString());
                    num3 = Convert.ToInt64(row12["AddressID"].ToString());
                    str1 = row12["AddressType"].ToString();
                    string str15 = row12["ItemDescription"].ToString();
                    string empty15 = string.Empty;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays4 = str15.Split(chrArray);
                    for (int m = 0; m < (int)strArrays4.Length; m++)
                    {
                        if (m == 10 && strArrays4[m] != "")
                        {
                            string str16 = strArrays4[m];
                            chrArray = new char[] { '»' };
                            string[] strArrays5 = str16.Split(chrArray);
                            for (int n = 0; n < (int)strArrays5.Length; n++)
                            {
                                if (n == 2)
                                {
                                    empty15 = strArrays5[2].ToString();
                                }
                            }
                        }
                    }
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num33 = (num9 * num32) / new decimal(100);
                    DataTable dataTable4 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num30);
                    if (dataTable4.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                    {
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num9), num31, num33, num15, empty15, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    }
                    else if (Convert.ToInt32(SettingsBasePage.settings_companyprofile_select(CompanyID).Rows[0]["ProductStockManagement"]) != 1)
                    {
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num9), num31, num33, num15, empty15, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    }
                    else if (dataTable4.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                    {
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num6), Convert.ToDecimal(num7), Convert.ToDecimal(num9), num31, num33, num15, empty15, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    }
                    else
                    {
                        foreach (DataRow dataRow12 in PurchaseBasePage.Kit_Details(num30).Rows)
                        {
                            int num34 = num6 * Convert.ToInt16(dataRow12["Quantity"]);
                            DataTable dataTable5 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(dataRow12["KitItemID"]));
                            string str17 = dataTable5.Rows[0]["ItemCode"].ToString();
                            string str18 = PurchaseBasePage.KitItemDescription(CompanyID, Convert.ToInt64(dataRow12["KitItemID"])).Replace("»", "\n");
                            num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, Convert.ToInt64(dataRow12["KitItemID"]), "W", str17, str18, Convert.ToDecimal(num34), Convert.ToDecimal(num7), Convert.ToDecimal(num9), num31, num33, num15, empty15, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        }
                    }
                    BaseClass baseClass1 = new BaseClass();
                    DataTable dataTable6 = baseClass1.ProductStockType_Select((long)CompanyID, Convert.ToInt64(row12["PriceCatalogueID"].ToString()));
                    foreach (DataRow row13 in dataTable6.Rows)
                    {
                        if (row13["DrawStockFrom"].ToString().ToLower() != "s")
                        {
                            if (row13["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                continue;
                            }
                            PurchaseBasePage.ProgressToJob_StockItem_Update(Convert.ToInt64(row12["PriceCatalogueID"].ToString()), num4);
                        }
                        else
                        {
                            PurchaseBasePage.ProgressToJob_StockItem_Update(Convert.ToInt64(row12["PriceCatalogueID"].ToString()), num4);
                        }
                    }
                    foreach (DataRow dataRow13 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                    {
                        empty5 = dataRow13["PONO"].ToString();
                    }
                    if (PurchaseOrders != "")
                    {
                        PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                    }
                    purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                    PurchaseOrders = string.Concat(purchaseOrders);
                    string empty16 = string.Empty;
                    foreach (DataRow row14 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty16 = row14["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty16);
                }
                if (this.hid_AdditionalItemIDs.Value != "")
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "W", true) == 0)
            {
                Hashtable hashtables = new Hashtable();
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow dataRow14 in dataSet.Tables[0].Rows)
                {
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    if (Convert.ToInt64(dataRow14["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(dataRow14["WarehouseTypeID"]);
                        str3 = dataRow14["WarehouseType"].ToString();
                    }
                    else
                    {
                        num5 = Convert.ToInt64(dataRow14["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = dataRow14["ItemCode"].ToString();
                    num6 = Convert.ToInt32(dataRow14["Quantity"]);
                    num8 = Convert.ToDecimal(dataRow14["PackedIn"]);
                    num10 = Convert.ToDecimal(dataRow14["UnitPrice"]);
                    pODN = dataRow14["inventoryname"].ToString();
                    num14 = Convert.ToInt64(dataRow14["DeliveryAddress"].ToString());
                    num9 = num6 * num10;
                    string str19 = dataRow14["ItemDescription"].ToString();
                    string empty17 = string.Empty;
                    chrArray = new char[] { 'µ' };
                    string[] strArrays6 = str19.Split(chrArray);
                    for (int o = 0; o < (int)strArrays6.Length; o++)
                    {
                        if (o == 10 && strArrays6[o] != "")
                        {
                            string str20 = strArrays6[o];
                            chrArray = new char[] { '»' };
                            string[] strArrays7 = str20.Split(chrArray);
                            for (int p = 0; p < (int)strArrays7.Length; p++)
                            {
                                if (p == 2)
                                {
                                    empty17 = strArrays7[2].ToString();
                                }
                            }
                        }
                    }
                    num1 = Convert.ToInt32(dataRow14["SupplierID"].ToString());
                    num2 = Convert.ToInt32(dataRow14["ContactID"].ToString());
                    num3 = Convert.ToInt64(dataRow14["AddressID"].ToString());
                    str1 = dataRow14["AddressType"].ToString();
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num35 = (num9 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num6), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num35, num15, empty17, false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    string selected_value = this.hdnCombinedValue.Value.ToString();
                    if(num1 > 0)
                    {
                        if (selected_value == "no")
                        {
                            DataTable dt = PurchaseBasePage.GetPurchaseItemByJobID(this.jobID, this.CompanyID, num1);
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (EstimateItemID != Convert.ToInt64(dr["EstimateItemID"].ToString()))
                                {
                                    int purchaseCount = PurchaseBasePage.GetPurchaseItemcount(num, ItemType, dr["Description"].ToString(), Convert.ToDecimal(dr["Qty"].ToString()), Convert.ToDecimal(dr["Price"].ToString()), Convert.ToInt32(dr["TaxID"].ToString()), Convert.ToDecimal(dr["TaxValue"].ToString()));
                                    if (purchaseCount == 0)
                                    {
                                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, Convert.ToInt64(dr["WarehouseItemID"].ToString()), dr["WarehouseItemType"].ToString(), dr["ItemCode"].ToString(), dr["Description"].ToString(), Convert.ToDecimal(dr["Qty"].ToString()), Convert.ToDecimal(dr["PackedIn"].ToString()), Convert.ToDecimal(dr["Price"].ToString()), Convert.ToInt32(dr["TaxID"].ToString()), Convert.ToDecimal(dr["TaxValue"].ToString()), Convert.ToInt32(dr["AccountCodeID"].ToString()), dr["Note"].ToString(), Convert.ToBoolean(dr["IsGoodsReceived"].ToString()), EstimateItemID, ItemType, Convert.ToBoolean(dr["IsGoodsReceived"].ToString()), (long)0, this.UserID, this.CreatedDate);
                                    }
                                }
                            }
                        }

                    }
                    foreach (DataRow row15 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                    {
                        empty5 = row15["PONO"].ToString();
                    }
                    if (PurchaseOrders != "")
                    {
                        PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                    }
                    purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                    PurchaseOrders = string.Concat(purchaseOrders);
                    string empty18 = string.Empty;
                    foreach (DataRow dataRow15 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty18 = dataRow15["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty18);
                }
                if (this.hid_AdditionalItemIDs.Value != "")
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "F", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow row16 in dataSet.Tables[0].Rows)
                {
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    if (Convert.ToInt64(row16["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(row16["PaperID"]);
                        str3 = "I";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(row16["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = row16["InventoryCode"].ToString();
                    num6 = Convert.ToInt32(row16["Quantity"]);
                    num8 = Convert.ToDecimal(row16["PackedIn"]);
                    Convert.ToInt64(row16["EstLithoItemID"]);
                    num10 = Convert.ToDecimal(row16["PaperUnitPrice"]);
                    Convert.ToInt32(row16["PrintLayoutValue"]);
                    Convert.ToDecimal(row16["SetupSpoilage"]);
                    Convert.ToDecimal(row16["RunningSpoilage"]);
                    Convert.ToDecimal(row16["PaperMarkup"]);
                    pODN = row16["inventoryname"].ToString();
                    num16 = Convert.ToDecimal(row16["InvSheets"]);
                    num14 = Convert.ToInt64(row16["DeliveryAddress"].ToString());
                    if (row16["ispriceperpack"].ToString().ToLower() == "true")
                    {
                        num11 = Convert.ToDecimal(row16["packedprice"]);
                        num9 = SummaryClass.ReturnPackedPrice(num16, num8, num11, new decimal(0), out num12);
                        num8 = num12;
                    }
                    else
                    {
                        num9 = num16 * num10;
                    }
                    num1 = Convert.ToInt32(row16["SupplierID"].ToString());
                    num2 = Convert.ToInt32(row16["ContactID"].ToString());
                    num3 = Convert.ToInt64(row16["AddressID"].ToString());
                    str1 = row16["AddressType"].ToString();
                    if (row16["IsPaperSupplied"].ToString().ToLower() != "true")
                    {
                        num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                        this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                        decimal num36 = (num9 * taxRate) / new decimal(100);
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num16), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num36, num15, "", false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        foreach (DataRow dataRow16 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                        {
                            empty5 = dataRow16["PONO"].ToString();
                        }
                        if (PurchaseOrders != "")
                        {
                            PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                        }
                        purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                        PurchaseOrders = string.Concat(purchaseOrders);
                    }
                    string empty19 = string.Empty;
                    foreach (DataRow row17 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty19 = row17["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty19);
                }
                if (this.hid_AdditionalItemIDs.Value != "")
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "D", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow dataRow17 in dataSet.Tables[0].Rows)
                {
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    if (Convert.ToInt64(dataRow17["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(dataRow17["PaperID"]);
                        str3 = "I";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(dataRow17["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = dataRow17["InventoryCode"].ToString();
                    num6 = Convert.ToInt32(dataRow17["Quantity"]);
                    num8 = Convert.ToDecimal(dataRow17["PackedIn"]);
                    Convert.ToInt64(dataRow17["EstimateLithoPadItemID"]);
                    num10 = Convert.ToDecimal(dataRow17["PaperUnitPrice"]);
                    Convert.ToInt32(dataRow17["PrintLayoutValue"]);
                    Convert.ToDecimal(dataRow17["SetupSpoilage"]);
                    Convert.ToDecimal(dataRow17["RunningSpoilage"]);
                    Convert.ToDecimal(dataRow17["PaperMarkup"]);
                    pODN = dataRow17["inventoryname"].ToString();
                    num16 = Convert.ToDecimal(dataRow17["InvSheets"]);
                    num14 = Convert.ToInt64(dataRow17["DeliveryAddress"].ToString());
                    if (dataRow17["LeavesPerPad"] != null)
                    {
                        Convert.ToDecimal(dataRow17["LeavesPerPad"]);
                    }
                    if (dataRow17["ispriceperpack"].ToString().ToLower() == "true")
                    {
                        num11 = Convert.ToDecimal(dataRow17["packedprice"]);
                        num9 = SummaryClass.ReturnPackedPrice(num16, num8, num11, new decimal(0), out num12);
                        num8 = num12;
                    }
                    else
                    {
                        num9 = num16 * num10;
                    }
                    num1 = Convert.ToInt32(dataRow17["SupplierID"].ToString());
                    num2 = Convert.ToInt32(dataRow17["ContactID"].ToString());
                    num3 = Convert.ToInt64(dataRow17["AddressID"].ToString());
                    str1 = dataRow17["AddressType"].ToString();
                    long num37 = this.objCom.settings_lastcounter_select(CompanyID, "p") + (long)1;
                    long num38 = (long)10000000 + num37;
                    this.PONO = string.Concat("PO-", num38.ToString().Substring(1, num38.ToString().Length - 1));
                    if (dataRow17["IsPaperSupplied"].ToString().ToLower() != "true")
                    {
                        num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                        this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                        decimal num39 = (num9 * taxRate) / new decimal(100);
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num16), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num39, num15, "", false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        foreach (DataRow row18 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                        {
                            empty5 = row18["PONO"].ToString();
                        }
                        if (PurchaseOrders != "")
                        {
                            PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                        }
                        purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                        PurchaseOrders = string.Concat(purchaseOrders);
                    }
                    string empty20 = string.Empty;
                    foreach (DataRow dataRow18 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty20 = dataRow18["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty20);
                }
                if (this.hid_AdditionalItemIDs.Value != "")
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "N", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow row19 in dataSet.Tables[0].Rows)
                {
                    if (EstimateBookletItemID != Convert.ToInt64(row19["EstimateLithoNcrItemID"]) || !(MainItemChecked.ToString().ToLower() == "yes"))
                    {
                        continue;
                    }
                    if (Convert.ToInt64(row19["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(row19["PaperID"]);
                        str3 = "I";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(row19["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = row19["InventoryCode"].ToString();
                    pODN = row19["inventoryname"].ToString();
                    num6 = Convert.ToInt32(row19["Quantity"]);
                    num8 = Convert.ToDecimal(row19["PackedIn"]);
                    Convert.ToInt64(row19["EstimateLithoNCRItemID"]);
                    num10 = Convert.ToDecimal(row19["PaperUnitPrice"]);
                    Convert.ToInt32(row19["PrintLayoutValue"]);
                    Convert.ToDecimal(row19["SetupSpoilage"]);
                    Convert.ToDecimal(row19["RunningSpoilage"]);
                    Convert.ToDecimal(row19["NcrPartsPerSet"].ToString());
                    Convert.ToDecimal(row19["NcrSetsPerPad"].ToString());
                    Convert.ToDecimal(row19["PaperMarkup"]);
                    num16 = Convert.ToDecimal(row19["InvSheets"]);
                    num14 = Convert.ToInt64(row19["DeliveryAddress"].ToString());
                    if (row19["ispriceperpack"].ToString().ToLower() == "true")
                    {
                        num11 = Convert.ToDecimal(row19["packedprice"]);
                        num9 = SummaryClass.ReturnPackedPrice(num16, num8, num11, new decimal(0), out num12);
                        num8 = num12;
                    }
                    else
                    {
                        num9 = num16 * num10;
                    }
                    num1 = Convert.ToInt32(row19["SupplierID"].ToString());
                    num2 = Convert.ToInt32(row19["ContactID"].ToString());
                    num3 = Convert.ToInt64(row19["AddressID"].ToString());
                    str1 = row19["AddressType"].ToString();
                    if (row19["IsPaperSupplied"].ToString().ToLower() != "true")
                    {
                        num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                        if (this.RowPos == 0)
                        {
                            this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                            Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob = this;
                            usercontrolItemItemSummaryRaisePOFromJob.RowPos = usercontrolItemItemSummaryRaisePOFromJob.RowPos + 1;
                        }
                        decimal num40 = (num9 * taxRate) / new decimal(100);
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num16), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num40, num15, "", false, EstimateBookletItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        foreach (DataRow dataRow19 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                        {
                            empty5 = dataRow19["PONO"].ToString();
                        }
                        if (PurchaseOrders != "")
                        {
                            PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                        }
                        purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                        PurchaseOrders = string.Concat(purchaseOrders);
                    }
                    string empty21 = string.Empty;
                    foreach (DataRow row20 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty21 = row20["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty21);
                }
                if (this.hid_AdditionalItemIDs.Value != "" && BookletSectionNO == 0)
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "R", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow row19 in dataSet.Tables[0].Rows)
                {
                    if (EstimateBookletItemID != Convert.ToInt64(row19["EstimateLithoNcrItemID"]) || !(MainItemChecked.ToString().ToLower() == "yes"))
                    {
                        continue;
                    }
                    if (Convert.ToInt64(row19["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(row19["PaperID"]);
                        str3 = "I";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(row19["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = row19["InventoryCode"].ToString();
                    pODN = row19["inventoryname"].ToString();
                    num6 = Convert.ToInt32(row19["Quantity"]);
                    num8 = Convert.ToDecimal(row19["PackedIn"]);
                    Convert.ToInt64(row19["EstimateLithoNCRItemID"]);
                    num10 = Convert.ToDecimal(row19["PaperUnitPrice"]);
                    Convert.ToInt32(row19["PrintLayoutValue"]);
                    Convert.ToDecimal(row19["SetupSpoilage"]);
                    Convert.ToDecimal(row19["RunningSpoilage"]);
                    Convert.ToDecimal(row19["NcrPartsPerSet"].ToString());
                    Convert.ToDecimal(row19["NcrSetsPerPad"].ToString());
                    Convert.ToDecimal(row19["PaperMarkup"]);
                    num16 = Convert.ToDecimal(row19["InvSheets"]);
                    num14 = Convert.ToInt64(row19["DeliveryAddress"].ToString());
                    if (row19["ispriceperpack"].ToString().ToLower() == "true")
                    {
                        num11 = Convert.ToDecimal(row19["packedprice"]);
                        num9 = SummaryClass.ReturnPackedPrice(num16, num8, num11, new decimal(0), out num12);
                        num8 = num12;
                    }
                    else
                    {
                        num9 = num16 * num10;
                    }
                    num1 = Convert.ToInt32(row19["SupplierID"].ToString());
                    num2 = Convert.ToInt32(row19["ContactID"].ToString());
                    num3 = Convert.ToInt64(row19["AddressID"].ToString());
                    str1 = row19["AddressType"].ToString();
                    if (row19["IsPaperSupplied"].ToString().ToLower() != "true")
                    {
                        num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                        if (this.RowPos == 0)
                        {
                            this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                            Item_Summary_RaisePO_From_Job usercontrolItemItemSummaryRaisePOFromJob = this;
                            usercontrolItemItemSummaryRaisePOFromJob.RowPos = usercontrolItemItemSummaryRaisePOFromJob.RowPos + 1;
                        }
                        decimal num40 = (num9 * taxRate) / new decimal(100);
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num16), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num40, num15, "", false, EstimateBookletItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        foreach (DataRow dataRow19 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                        {
                            empty5 = dataRow19["PONO"].ToString();
                        }
                        if (PurchaseOrders != "")
                        {
                            PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                        }
                        purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                        PurchaseOrders = string.Concat(purchaseOrders);
                    }
                    string empty21 = string.Empty;
                    foreach (DataRow row20 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty21 = row20["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty21);
                }
                if (this.hid_AdditionalItemIDs.Value != "" && BookletSectionNO == 0)
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "K", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow dataRow20 in dataSet.Tables[0].Rows)
                {
                    if (EstimateBookletItemID != Convert.ToInt64(dataRow20["EstimateLithoBookletItemID"]) || !(MainItemChecked.ToString().ToLower() == "yes"))
                    {
                        continue;
                    }
                    if (Convert.ToInt64(dataRow20["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(dataRow20["PaperID"]);
                        str3 = "I";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(dataRow20["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = dataRow20["InventoryCode"].ToString();
                    pODN = dataRow20["inventoryname"].ToString();
                    num6 = Convert.ToInt32(dataRow20["Quantity"]);
                    num8 = Convert.ToDecimal(dataRow20["PackedIn"]);
                    Convert.ToInt64(dataRow20["EstimateLithobookletItemID"]);
                    num10 = Convert.ToDecimal(dataRow20["PaperUnitPrice"]);
                    Convert.ToInt32(dataRow20["NoOfSignatures"]);
                    Convert.ToDecimal(dataRow20["SetupSpoilage"]);
                    Convert.ToDecimal(dataRow20["RunningSpoilage"]);
                    Convert.ToDecimal(dataRow20["PaperMarkup"]);
                    num16 = Convert.ToDecimal(dataRow20["InvSheets"]);
                    num14 = Convert.ToInt64(dataRow20["DeliveryAddress"].ToString());
                    if (dataRow20["ispriceperpack"].ToString().ToLower() == "true")
                    {
                        num11 = Convert.ToDecimal(dataRow20["packedprice"]);
                        num9 = SummaryClass.ReturnPackedPrice(num16, num8, num11, new decimal(0), out num12);
                        num8 = num12;
                    }
                    else
                    {
                        num9 = num16 * num10;
                    }
                    num1 = Convert.ToInt32(dataRow20["SupplierID"].ToString());
                    num2 = Convert.ToInt32(dataRow20["ContactID"].ToString());
                    num3 = Convert.ToInt64(dataRow20["AddressID"].ToString());
                    str1 = dataRow20["AddressType"].ToString();
                    if (dataRow20["IsPaperSupplied"].ToString().ToLower() != "true")
                    {
                        num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                        if (this.RowPos == 0)
                        {
                            this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                            Item_Summary_RaisePO_From_Job rowPos1 = this;
                            rowPos1.RowPos = rowPos1.RowPos + 1;
                        }
                        decimal num41 = (num9 * taxRate) / new decimal(100);
                        num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, Convert.ToDecimal(num16), Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num41, num15, "", false, EstimateBookletItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                        foreach (DataRow row21 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                        {
                            empty5 = row21["PONO"].ToString();
                        }
                        if (PurchaseOrders != "")
                        {
                            PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                        }
                        purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                        PurchaseOrders = string.Concat(purchaseOrders);
                    }
                    string str21 = string.Empty;
                    foreach (DataRow dataRow21 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        str21 = dataRow21["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", str21);
                }
                if (this.hid_AdditionalItemIDs.Value != "" && BookletSectionNO == 0)
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            else if (string.Compare(ItemType, "Q", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow row22 in dataSet.Tables[0].Rows)
                {
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    if (Convert.ToInt64(row22["productID"]) <= (long)0 || !isProductPOchk)
                    {
                        num5 = Convert.ToInt64(row22["PaperID"]);
                        str3 = "I";
                    }
                    else
                    {
                        num5 = Convert.ToInt64(row22["productID"]);
                        str3 = "W";
                        flag = true;
                    }
                    empty4 = row22["InventoryCode"].ToString();
                    num6 = Convert.ToInt32(row22["Quantity"]);
                    num8 = Convert.ToDecimal(row22["PackedIn"]);
                    Convert.ToInt64(row22["QuickQuoteID"]);
                    num10 = Convert.ToDecimal(row22["PaperUnitPrice"]);
                    Convert.ToInt32(row22["PrintLayoutValue"]);
                    Convert.ToDecimal(row22["SetupSpoilage"]);
                    Convert.ToDecimal(row22["RunningSpoilage"]);
                    pODN = SummaryClass.Split_ItemDescription_forpurchaseorder(row22["ItemDescription"].ToString());
                    num14 = Convert.ToInt64(row22["DeliveryAddress"].ToString());
                    num9 = num10;
                    num1 = Convert.ToInt32(row22["SupplierID"].ToString());
                    num2 = Convert.ToInt32(row22["ContactID"].ToString());
                    num3 = Convert.ToInt64(row22["AddressID"].ToString());
                    str1 = row22["AddressType"].ToString();
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.TodayDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.TodayDate, num14, str4, 0, EstimateBookletItemID, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num42 = (num9 * taxRate) / new decimal(100);
                    num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, num6, Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, num42, num15, "", false, EstimateItemID, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    foreach (DataRow dataRow22 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                    {
                        empty5 = dataRow22["PONO"].ToString();
                    }
                    if (PurchaseOrders != "")
                    {
                        PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                    }
                    purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                    PurchaseOrders = string.Concat(purchaseOrders);
                    string empty22 = string.Empty;
                    foreach (DataRow row23 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        empty22 = row23["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", empty22);
                }
            }
            else if (string.Compare(ItemType.ToString().ToLower(), "u", true) == 0)
            {
                dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
                foreach (DataRow dataRow23 in dataSet.Tables[0].Rows)
                {
                    if (MainItemChecked.ToString().ToLower() != "yes")
                    {
                        continue;
                    }
                    num6 = Convert.ToInt32(dataRow23["Quantity"]);
                    num14 = Convert.ToInt64(dataRow23["DeliveryAddress"].ToString());
                    num1 = Convert.ToInt32(dataRow23["SupplierID"].ToString());
                    num2 = Convert.ToInt32(dataRow23["ContactID"].ToString());
                    num3 = Convert.ToInt64(dataRow23["AddressID"].ToString());
                    num9 = Convert.ToDecimal(dataRow23["cost"].ToString());
                    pODN = dataRow23["ItemDescription"].ToString();
                    long num43 = Convert.ToInt64(dataRow23["estOtherCostID"].ToString());
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.SpecialEncode(empty1), this.objBase.SpecialEncode(str), "", this.CreatedDate, this.objBase.SpecialEncode(jobNumber), "", "", (long)this.UserID, dateTime, false, false, jobStatusID, this.UserID, this.UserID, this.CreatedDate, (long)0, str1, EstimateID, this.objBase.SpecialEncode(empty), EstimateItemID, this.CreatedDate, num14, str4, 0, (long)0, dateTime1, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    num4 = PurchaseBasePage.purchaseitem_insertPOfromJob(CompanyID, (long)0, num, num5, str3, empty4, pODN, num6, Convert.ToDecimal(num8), Convert.ToDecimal(num9), taxID, taxRate, num15, "", false, num43, ItemType, flag, (long)0, this.UserID, this.CreatedDate);
                    foreach (DataRow row24 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                    {
                        empty5 = row24["PONO"].ToString();
                    }
                    if (PurchaseOrders != "")
                    {
                        PurchaseOrders = string.Concat(PurchaseOrders, ", ");
                    }
                    purchaseOrders = new object[] { PurchaseOrders, "<a href='", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty5, "</a>" };
                    PurchaseOrders = string.Concat(purchaseOrders);
                    string str22 = string.Empty;
                    foreach (DataRow dataRow24 in Notes.select_item_number_for_Activity_History(this.jobID, EstimateItemID, this.modulename).Rows)
                    {
                        str22 = dataRow24["rownumber"].ToString();
                    }
                    if (ItemNumbers != "")
                    {
                        ItemNumbers = string.Concat(ItemNumbers, ", ");
                    }
                    ItemNumbers = string.Concat(ItemNumbers, "Item ", str22);
                }
                if (this.hid_AdditionalItemIDs.Value != "" && BookletSectionNO == 0)
                {
                    this.SubItem_Purchase_Order_Insert_ForAdditionalItems(dataSet, jobNumber, jobStatusID, EstimateID, this.UserID, CompanyID, EstimateItemID, this.DateFormat, this.hid_AdditionalItemIDs.Value, this.UserName, PO, out str2, out empty3, poNumber, isCombined);
                }
            }
            if (PurchaseOrders == "")
            {
                AllPurchaseOrders = string.Concat(PurchaseOrders, str2);
            }
            else
            {
                AllPurchaseOrders = string.Concat(PurchaseOrders, ", ", str2);
                if (str2.Trim() == "")
                {
                    AllPurchaseOrders = PurchaseOrders;
                }
            }
            if (ItemNumbers == "")
            {
                AllItemNumbers = string.Concat(ItemNumbers, empty3);
            }
            else
            {
                AllItemNumbers = string.Concat(ItemNumbers, ", ", empty3);
                if (empty3.Trim() == "")
                {
                    AllItemNumbers = ItemNumbers;
                }
            }
            return num;
        }

        public void SubItem_Purchase_Order_Insert_ForAdditionalItems(DataSet ds, string StrJobNum, int StatusID, long EstimateID, int UserID, int CompanyID, long EstimateItemID, string DateFormat, string additionalItemID, string CustomerName, int Po, out string AddPurchaseOrders, out string AddItemNumbers, long poNumber = 0, string isCombined = "no")
        {
            object[] str;
            long num = (long)0;
            int num1 = 0;
            int num2 = 0;
            long num3 = (long)0;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            DataTable dataTable = SettingsBasePage.settings_companyprofile_select(CompanyID);
            Item_Summary_RaisePO_From_Job.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
            commonClass _commonClass = this.commclass;
            commonClass _commonClass1 = this.commclass;
            DateTime now = DateTime.Now;
            string str2 = _commonClass.date_Check_new(DateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), CompanyID, UserID, true), CompanyID);
            DateTime dateTime = Convert.ToDateTime(str2);
            long num4 = (long)0;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            int num5 = 0;
            int num6 = 0;
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            string pODN = string.Empty;
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            string str3 = string.Empty;
            long num12 = (long)0;
            DataTable dataTable1 = new DataTable();
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            long estimateItemID = EstimateItemID;
            commonClass _commonClass2 = this.commclass;
            commonClass _commonClass3 = this.commclass;
            now = DateTime.Now.AddDays(5);
            string str5 = _commonClass2.date_Check_new(DateFormat, _commonClass3.Eprint_return_Date_Before_View(now.ToString(), CompanyID, UserID, true), CompanyID);
            commonClass _commonClass4 = this.commclass;
            commonClass _commonClass5 = this.commclass;
            now = DateTime.Now;
            string str6 = _commonClass4.date_Check_new(DateFormat, _commonClass5.Eprint_return_Date_Before_View(now.ToString(), CompanyID, UserID, true), CompanyID);
            DateTime dateTime1 = Convert.ToDateTime(str5);
            DateTime dateTime2 = Convert.ToDateTime(str6);
            decimal num13 = new decimal(0);
            this.commclass.Settings_inventoryStockReduction_Select((long)CompanyID);
            long num14 = (long)0;
            string empty6 = string.Empty;
            int taxID = EstimatesBasePage.GetTaxID(CompanyID, EstimateID);
            decimal taxRate = EstimatesBasePage.GetTaxRate(CompanyID, EstimateID);
            string serverName = ConnectionClass.ServerName;
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(CompanyID, "Delivery Instructions").Rows)
            {
                empty1 = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in ds.Tables[1].Rows)
            {
                if (string.Compare(dataRow["PoType"].ToString(), "Warehouse", true) != 0 || string.Compare(dataRow["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(dataRow["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(dataRow["WarehouseTypeID"]);
                empty2 = dataRow["WarehouseType"].ToString();
                empty3 = dataRow["ItemCode"].ToString();
                num5 = Convert.ToInt32(dataRow["Quantity"]);
                num6 = Convert.ToInt32(dataRow["PackedIn"]);
                num8 = Convert.ToDecimal(dataRow["UnitPrice"]);
                num7 = num5 * num8;
                num1 = Convert.ToInt32(dataRow["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow["AddressID"].ToString());
                empty = dataRow["AddressType"].ToString();
                EstimateItemID = (long)Convert.ToInt32(dataRow["EstimateItemID"].ToString());
                num14 = Convert.ToInt64(dataRow["DeliveryAddress"].ToString());
                empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "w");
                empty6 = (empty6 != "a" ? "R" : "A");
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, 0, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num15 = (num7 * taxRate) / new decimal(100);
                PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, "", num5, num6, Convert.ToDecimal(num7), taxID, num15, 0, "", false, EstimateItemID, "W", (long)0, UserID, this.CreatedDate);
                foreach (DataRow row1 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    empty4 = row1["PONO"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str = new object[] { str4, "<a href='", this.objBase.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty4, "</a>" };
                str4 = string.Concat(str);
                string empty7 = string.Empty;
                foreach (DataRow dataRow1 in Notes.select_item_number_for_Activity_History(this.jobID, estimateItemID, this.modulename).Rows)
                {
                    empty7 = dataRow1["rownumber"].ToString();
                }
                if (empty5 != "")
                {
                    empty5 = string.Concat(empty5, ", ");
                }
                empty5 = string.Concat(empty5, "Item ", empty7);
            }
            foreach (DataRow row2 in ds.Tables[2].Rows)
            {
                if (string.Compare(row2["PoType"].ToString(), "Outwork", true) != 0 || string.Compare(row2["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(row2["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = (long)0;
                empty2 = "A";
                empty3 = "";
                num5 = Convert.ToInt32(row2["Quantity"]);
                num6 = 0;
                num7 = Convert.ToDecimal(row2["Price"]);
                if (row2["CostingType"].ToString().ToUpper() == "U")
                {
                    num7 = num7 * num5;
                }
                EstimateItemID = (long)Convert.ToInt32(row2["EstimateItemID"].ToString());
                num1 = Convert.ToInt32(row2["SupplierID"].ToString());
                num2 = Convert.ToInt32(row2["SupplierContactID"].ToString());
                num3 = Convert.ToInt64(row2["AddressID"].ToString());
                empty = row2["AddressType"].ToString();
                string str7 = SummaryClass.Split_ItemDescription(row2["Description"].ToString());
                string str8 = row2["Notes"].ToString();
                num14 = Convert.ToInt64(row2["DeliveryAddress"].ToString());
                empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "o");
                empty6 = (empty6 != "a" ? "R" : "A");
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), row2["SupplierRefNo"].ToString(), "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num16 = (num7 * taxRate) / new decimal(100);
                PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, str7, num5, num6, Convert.ToDecimal(num7), taxID, num16, 0, str8, false, EstimateItemID, "O", (long)0, UserID, this.CreatedDate);
                foreach (DataRow dataRow2 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    empty4 = dataRow2["PONO"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str = new object[] { str4, "<a href='", this.objBase.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty4, "</a>" };
                str4 = string.Concat(str);
                string empty8 = string.Empty;
                foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(this.jobID, estimateItemID, this.modulename).Rows)
                {
                    empty8 = row3["rownumber"].ToString();
                }
                if (empty5 != "")
                {
                    empty5 = string.Concat(empty5, ", ");
                }
                empty5 = string.Concat(empty5, "Item ", empty8);
            }
            foreach (DataRow dataRow3 in ds.Tables[3].Rows)
            {
                if (string.Compare(dataRow3["PoType"].ToString(), "single", true) != 0 || string.Compare(dataRow3["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(dataRow3["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(dataRow3["PaperID"]);
                empty2 = "I";
                empty3 = dataRow3["InventoryCode"].ToString();
                pODN = dataRow3["Inventoryname"].ToString();
                num5 = Convert.ToInt32(dataRow3["Quantity"]);
                num9 = Convert.ToInt32(dataRow3["PackedIn"]);
                Convert.ToInt64(dataRow3["EstimateSingleItemID"]);
                num8 = Convert.ToDecimal(dataRow3["PaperUnitPrice"]);
                Convert.ToInt32(dataRow3["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow3["SetupSpoilage"]);
                Convert.ToDecimal(dataRow3["RunningSpoilage"]);
                Convert.ToDecimal(dataRow3["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(dataRow3["EstimateItemID"].ToString());
                num13 = Convert.ToDecimal(dataRow3["InvSheets"]);
                if (dataRow3["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num10 = Convert.ToDecimal(dataRow3["packedprice"]);
                    num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                    num9 = num11;
                }
                else
                {
                    num7 = num13 * num8;
                }
                num1 = Convert.ToInt32(dataRow3["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow3["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow3["AddressID"].ToString());
                empty = dataRow3["AddressType"].ToString();
                num14 = Convert.ToInt64(dataRow3["DeliveryAddress"].ToString());
                empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "s");
                empty6 = (empty6 != "a" ? "R" : "A");
                if (dataRow3["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num17 = (num7 * taxRate) / new decimal(100);
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, pODN, Convert.ToInt32(num13), num9, Convert.ToDecimal(num7), taxID, num17, 0, "", false, EstimateItemID, "S", (long)0, UserID, this.CreatedDate);
                }
                foreach (DataRow row4 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    empty4 = row4["PONO"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str = new object[] { str4, "<a href='", this.objBase.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty4, "</a>" };
                str4 = string.Concat(str);
                string empty9 = string.Empty;
                foreach (DataRow dataRow4 in Notes.select_item_number_for_Activity_History(this.jobID, estimateItemID, this.modulename).Rows)
                {
                    empty9 = dataRow4["rownumber"].ToString();
                }
                if (empty5 != "")
                {
                    empty5 = string.Concat(empty5, ", ");
                }
                empty5 = string.Concat(empty5, "Item ", empty9);
            }
            foreach (DataRow row5 in ds.Tables[4].Rows)
            {
                if (string.Compare(row5["PoType"].ToString(), "pad", true) != 0 || string.Compare(row5["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(row5["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(row5["PaperID"]);
                empty2 = "I";
                empty3 = row5["InventoryCode"].ToString();
                pODN = row5["Inventoryname"].ToString();
                num5 = Convert.ToInt32(row5["Quantity"]);
                num6 = Convert.ToInt32(row5["PackedIn"]);
                Convert.ToInt64(row5["EstimatePadItemID"]);
                num8 = Convert.ToDecimal(row5["PaperUnitPrice"]);
                Convert.ToInt32(row5["PrintLayoutValue"]);
                Convert.ToDecimal(row5["SetupSpoilage"]);
                Convert.ToDecimal(row5["RunningSpoilage"]);
                Convert.ToDecimal(row5["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(row5["EstimateItemID"].ToString());
                num13 = Convert.ToDecimal(row5["InvSheets"]);
                if (row5["LeavesPerPad"] != null)
                {
                    Convert.ToDecimal(row5["LeavesPerPad"]);
                }
                if (row5["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num10 = Convert.ToDecimal(row5["packedprice"]);
                    num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                    num9 = num11;
                }
                else
                {
                    num7 = num13 * num8;
                }
                num1 = Convert.ToInt32(row5["SupplierID"].ToString());
                num2 = Convert.ToInt32(row5["ContactID"].ToString());
                num3 = Convert.ToInt64(row5["AddressID"].ToString());
                empty = row5["AddressType"].ToString();
                num14 = Convert.ToInt64(row5["DeliveryAddress"].ToString());
                empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "p");
                empty6 = (empty6 != "a" ? "R" : "A");
                if (row5["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num18 = (num7 * taxRate) / new decimal(100);
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, pODN, Convert.ToInt32(num13), num6, Convert.ToDecimal(num7), taxID, num18, 0, "", false, EstimateItemID, "P", (long)0, UserID, this.CreatedDate);
                }
                foreach (DataRow dataRow5 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    empty4 = dataRow5["PONO"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str = new object[] { str4, "<a href='", this.objBase.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty4, "</a>" };
                str4 = string.Concat(str);
                string str9 = string.Empty;
                foreach (DataRow row6 in Notes.select_item_number_for_Activity_History(this.jobID, estimateItemID, this.modulename).Rows)
                {
                    str9 = row6["rownumber"].ToString();
                }
                if (empty5 != "")
                {
                    empty5 = string.Concat(empty5, ", ");
                }
                empty5 = string.Concat(empty5, "Item ", str9);
            }
            int num19 = 0;
            long num20 = (long)0;
            foreach (DataRow dataRow6 in ds.Tables[5].Rows)
            {
                if (string.Compare(dataRow6["PoType"].ToString(), "large", true) != 0 || string.Compare(dataRow6["IsEmpty"].ToString(), "No", true) != 0)
                {
                    continue;
                }
                if (num20 != Convert.ToInt64(dataRow6["EstimateitemID"]))
                {
                    num19 = 0;
                }
                Label label = (Label)this.plhpurchase.FindControl(string.Concat("PoAddItemCount_", dataRow6["EstimateitemID"].ToString()));
                PlaceHolder placeHolder = this.plhpurchase;
                str = new object[] { "chkPoAdd_", num19, "_", dataRow6["EstimateitemID"].ToString(), "_", Po, "_", label.Text };
                if (((CheckBox)placeHolder.FindControl(string.Concat(str))).Checked)
                {
                    num4 = Convert.ToInt64(dataRow6["PaperID"]);
                    empty2 = "I";
                    empty3 = dataRow6["InventoryCode"].ToString();
                    pODN = dataRow6["Inventoryname"].ToString();
                    num5 = Convert.ToInt32(dataRow6["Quantity"]);
                    num6 = Convert.ToInt32(dataRow6["PackedIn"]);
                    Convert.ToInt64(dataRow6["EstimateLargeItemID"]);
                    num8 = Convert.ToDecimal(dataRow6["PaperUnitPrice"]);
                    Convert.ToInt32(dataRow6["PrintLayoutValue"]);
                    Convert.ToDecimal(dataRow6["SetupSpoilage"]);
                    Convert.ToDecimal(dataRow6["RunningSpoilage"]);
                    dataRow6["PressPaperType"].ToString();
                    EstimateItemID = (long)Convert.ToInt32(dataRow6["EstimateItemID"].ToString());
                    num12 = Convert.ToInt64(dataRow6["EstLargeItemCalculationID"]);
                    num13 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Convert.ToDecimal(dataRow6["InvSheets"].ToString()), 0, "", false, false, true));
                    if (dataRow6["ispriceperpack"].ToString().ToLower() == "true")
                    {
                        num10 = Convert.ToDecimal(dataRow6["packedprice"]);
                        num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                        num9 = num11;
                    }
                    else
                    {
                        num7 = num13 * num8;
                    }
                    num1 = Convert.ToInt32(dataRow6["SupplierID"].ToString());
                    num2 = Convert.ToInt32(dataRow6["ContactID"].ToString());
                    num3 = Convert.ToInt64(dataRow6["AddressID"].ToString());
                    empty = dataRow6["AddressType"].ToString();
                    num14 = Convert.ToInt64(dataRow6["DeliveryAddress"].ToString());
                    empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "l");
                    empty6 = (empty6 != "a" ? "R" : "A");
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num21 = (num7 * taxRate) / new decimal(100);
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, pODN, num13, num9, Convert.ToDecimal(num7), taxID, num21, 0, "", false, EstimateItemID, "L", num12, UserID, this.CreatedDate);
                    foreach (DataRow row7 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                    {
                        empty4 = row7["PONO"].ToString();
                    }
                    if (str4 != "")
                    {
                        str4 = string.Concat(str4, ", ");
                    }
                    str = new object[] { str4, "<a href='", this.objBase.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty4, "</a>" };
                    str4 = string.Concat(str);
                    string empty10 = string.Empty;
                    foreach (DataRow dataRow7 in Notes.select_item_number_for_Activity_History(this.jobID, estimateItemID, this.modulename).Rows)
                    {
                        empty10 = dataRow7["rownumber"].ToString();
                    }
                    if (empty5 != "")
                    {
                        empty5 = string.Concat(empty5, ", ");
                    }
                    empty5 = string.Concat(empty5, "Item ", empty10);
                }
                num20 = Convert.ToInt64(dataRow6["EstimateitemID"]);
                num19++;
            }
            foreach (DataRow row8 in ds.Tables[6].Rows)
            {
                if (string.Compare(row8["PoType"].ToString(), "Lithosingle", true) != 0 || string.Compare(row8["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(row8["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(row8["PaperID"]);
                empty2 = "I";
                empty3 = row8["InventoryCode"].ToString();
                pODN = row8["Inventoryname"].ToString();
                num5 = Convert.ToInt32(row8["Quantity"]);
                num9 = Convert.ToDecimal(row8["PackedIn"]);
                Convert.ToInt64(row8["EstLithoItemID"]);
                num8 = Convert.ToDecimal(row8["PaperUnitPrice"]);
                Convert.ToInt32(row8["PrintLayoutValue"]);
                Convert.ToDecimal(row8["SetupSpoilage"]);
                Convert.ToDecimal(row8["RunningSpoilage"]);
                Convert.ToDecimal(row8["PaperMarkup"]);
                EstimateItemID = (long)Convert.ToInt32(row8["EstimateItemID"].ToString());
                num13 = Convert.ToDecimal(row8["InvSheets"]);
                if (row8["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num10 = Convert.ToDecimal(row8["packedprice"]);
                    num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                    num9 = num11;
                }
                else
                {
                    num7 = num13 * num8;
                }
                num1 = Convert.ToInt32(row8["SupplierID"].ToString());
                num2 = Convert.ToInt32(row8["ContactID"].ToString());
                num3 = Convert.ToInt64(row8["AddressID"].ToString());
                empty = row8["AddressType"].ToString();
                num14 = Convert.ToInt64(row8["DeliveryAddress"].ToString());
                empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "f");
                empty6 = (empty6 != "a" ? "R" : "A");
                if (row8["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num22 = (num7 * taxRate) / new decimal(100);
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num9), Convert.ToDecimal(num7), taxID, num22, 0, "", false, EstimateItemID, "F", (long)0, UserID, this.CreatedDate);
                }
                foreach (DataRow dataRow8 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    empty4 = dataRow8["PONO"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str = new object[] { str4, "<a href='", this.objBase.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty4, "</a>" };
                str4 = string.Concat(str);
                string str10 = string.Empty;
                foreach (DataRow row9 in Notes.select_item_number_for_Activity_History(this.jobID, estimateItemID, this.modulename).Rows)
                {
                    str10 = row9["rownumber"].ToString();
                }
                if (empty5 != "")
                {
                    empty5 = string.Concat(empty5, ", ");
                }
                empty5 = string.Concat(empty5, "Item ", str10);
            }
            foreach (DataRow dataRow9 in ds.Tables[7].Rows)
            {
                if (string.Compare(dataRow9["PoType"].ToString(), "Lithopad", true) != 0 || string.Compare(dataRow9["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(dataRow9["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = Convert.ToInt64(dataRow9["PaperID"]);
                empty2 = "I";
                empty3 = dataRow9["InventoryCode"].ToString();
                pODN = dataRow9["Inventoryname"].ToString();
                num5 = Convert.ToInt32(dataRow9["Quantity"]);
                num9 = Convert.ToDecimal(dataRow9["PackedIn"]);
                Convert.ToInt64(dataRow9["EstimateLithoPadItemID"]);
                num8 = Convert.ToDecimal(dataRow9["PaperUnitPrice"]);
                Convert.ToInt32(dataRow9["PrintLayoutValue"]);
                Convert.ToDecimal(dataRow9["SetupSpoilage"]);
                Convert.ToDecimal(dataRow9["RunningSpoilage"]);
                Convert.ToDecimal(dataRow9["PaperMarkup"]);
                if (dataRow9["LeavesPerPad"] != null)
                {
                    Convert.ToDecimal(dataRow9["LeavesPerPad"]);
                }
                EstimateItemID = (long)Convert.ToInt32(dataRow9["EstimateItemID"].ToString());
                num13 = Convert.ToDecimal(dataRow9["InvSheets"]);
                if (dataRow9["ispriceperpack"].ToString().ToLower() == "true")
                {
                    num10 = Convert.ToDecimal(dataRow9["packedprice"]);
                    num7 = SummaryClass.ReturnPackedPrice(num13, num9, num10, new decimal(0), out num11);
                    num9 = num11;
                }
                else
                {
                    num7 = num13 * num8;
                }
                num1 = Convert.ToInt32(dataRow9["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow9["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow9["AddressID"].ToString());
                empty = dataRow9["AddressType"].ToString();
                num14 = Convert.ToInt64(dataRow9["DeliveryAddress"].ToString());
                empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "d");
                empty6 = (empty6 != "a" ? "R" : "A");
                if (dataRow9["IsPaperSupplied"].ToString().ToLower() != "true")
                {
                    num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                    this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                    decimal num23 = (num7 * taxRate) / new decimal(100);
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, pODN, Convert.ToDecimal(num13), Convert.ToDecimal(num9), Convert.ToDecimal(num7), taxID, num23, 0, "", false, EstimateItemID, "D", (long)0, UserID, this.CreatedDate);
                }
                foreach (DataRow row10 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    empty4 = row10["PONO"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str = new object[] { str4, "<a href='", this.objBase.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty4, "</a>" };
                str4 = string.Concat(str);
                string empty11 = string.Empty;
                foreach (DataRow dataRow10 in Notes.select_item_number_for_Activity_History(this.jobID, estimateItemID, this.modulename).Rows)
                {
                    empty11 = dataRow10["rownumber"].ToString();
                }
                if (empty5 != "")
                {
                    empty5 = string.Concat(empty5, ", ");
                }
                empty5 = string.Concat(empty5, "Item ", empty11);
            }
            foreach (DataRow row11 in ds.Tables[8].Rows)
            {
                if (string.Compare(row11["PoType"].ToString(), "ProductCatalogue", true) != 0 || string.Compare(row11["IsEmpty"].ToString(), "No", true) != 0 || !additionalItemID.ToString().Contains(row11["EstimateItemID"].ToString()))
                {
                    continue;
                }
                num4 = (long)0;
                empty2 = "A";
                empty3 = "";
                num5 = Convert.ToInt32(row11["Quantity"]);
                num6 = Convert.ToInt32(row11["Quantity"]);
                num7 = Convert.ToDecimal(row11["Price"]);
                long num24 = Convert.ToInt64(row11["PriceCatalogueID"]);
                decimal num25 = taxRate;
                int num26 = taxID;
                foreach (DataRow dataRow11 in ds.Tables[0].Rows)
                {
                    num26 = Convert.ToInt32(dataRow11["TotalTaxId"]);
                    num25 = Convert.ToDecimal(dataRow11["TotalTaxRate"]);
                }
                num14 = Convert.ToInt64(row11["DeliveryAddress"].ToString());
                num1 = Convert.ToInt32(row11["SupplierID"].ToString());
                num2 = Convert.ToInt32(row11["SupplierContactID"].ToString());
                num3 = Convert.ToInt64(row11["AddressID"].ToString());
                empty = row11["AddressType"].ToString();
                EstimateItemID = (long)Convert.ToInt32(row11["EstimateItemID"].ToString());
                ///Modification
                object[] text;
                PlaceHolder placeHolder12 = this.plhpurchase;
                text = new object[] { "chkRptAdd_0_", EstimateItemID };
                CheckBox checkBoxRptAdd = (CheckBox)placeHolder12.FindControl(string.Concat(text));
                if (checkBoxRptAdd != null && checkBoxRptAdd.Checked)
                {
                    string[] strArrays;
                    string RptSelect = string.Concat("; UPDATE tb_Estimateitem  SET IsStockReplenishitem = 1 WHERE EstimateItemID=", EstimateItemID);
                    int companyID = this.CompanyID;
                    strArrays = new string[] { " ", RptSelect.ToString() };
                    EstimateBasePage.Stock_Replenishment_insert(companyID, string.Concat(strArrays), this.EstimateItemID);
                }
                //////

                string str11 = SummaryClass.Split_ItemDescription(row11["ItemDescription"].ToString());
                string empty12 = string.Empty;
                string str12 = string.Empty;
                string empty13 = string.Empty;
                row11["Notes"].ToString();
                row11["Material"].ToString();
                empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "c");
                empty6 = (empty6 != "a" ? "R" : "A");
                pODN = this.commclass.ItemDescriptionToPO_DN(CompanyID, EstimateItemID, "Purchase", ref empty13);
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num27 = (num7 * num25) / new decimal(100);
                DataTable dataTable2 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(num24);
                if (dataTable2.Rows[0]["DrawStockFrom"].ToString().ToLower() != "o")
                {
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, str11, Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num26, num27, 0, empty13, false, EstimateItemID, "C", (long)0, UserID, this.CreatedDate);
                }
                else if (Item_Summary_RaisePO_From_Job.ManageStockPermission != 1)
                {
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, str11, Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num26, num27, 0, empty13, false, EstimateItemID, "C", (long)0, UserID, this.CreatedDate);
                }
                else if (dataTable2.Rows[0]["IsStockItem"].ToString().ToLower() != "true")
                {
                    PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, str11, Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num26, num27, 0, empty13, false, EstimateItemID, "C", (long)0, UserID, this.CreatedDate);
                }
                else
                {
                    foreach (DataRow row12 in PurchaseBasePage.Kit_Details(num24).Rows)
                    {
                        int num28 = num5 * Convert.ToInt16(row12["Quantity"]);
                        DataTable dataTable3 = PurchaseBasePage.Select_PriceCat_ItemTitle_n_DrawStockFrom(Convert.ToInt64(row12["KitItemID"]));
                        string str13 = dataTable3.Rows[0]["ItemCode"].ToString();
                        string str14 = PurchaseBasePage.KitItemDescription(CompanyID, Convert.ToInt64(row12["KitItemID"])).Replace("»", "\n");
                        PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, Convert.ToInt64(row12["KitItemID"]), "W", str13, str14, Convert.ToDecimal(num28), Convert.ToDecimal(num6), Convert.ToDecimal(num7), num26, num27, 0, empty13, false, EstimateItemID, "C", (long)0, UserID, this.CreatedDate);
                    }
                }
                foreach (DataRow dataRow12 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    empty4 = dataRow12["PONO"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str = new object[] { str4, "<a href='", this.objBase.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty4, "</a>" };
                str4 = string.Concat(str);
                string empty14 = string.Empty;
                foreach (DataRow row13 in Notes.select_item_number_for_Activity_History(this.jobID, estimateItemID, this.modulename).Rows)
                {
                    empty14 = row13["rownumber"].ToString();
                }
                if (empty5 != "")
                {
                    empty5 = string.Concat(empty5, ", ");
                }
                empty5 = string.Concat(empty5, "Item ", empty14);
            }
            foreach (DataRow dataRow13 in ds.Tables[9].Rows)
            {
                if (string.Compare(dataRow13["PoType"].ToString().ToLower(), "othercost", true) != 0 || string.Compare(dataRow13["IsEmpty"].ToString().ToLower(), "no", true) != 0 || !additionalItemID.ToString().Contains(dataRow13["estOtherCostID"].ToString()))
                {
                    continue;
                }
                num5 = Convert.ToInt32(dataRow13["Quantity"]);
                num6 = 0;
                num14 = Convert.ToInt64(dataRow13["DeliveryAddress"].ToString());
                empty6 = SettingsBasePage.PODeliveryAddress_BasedonSettings_Select(CompanyID, "u");
                empty6 = (empty6 != "a" ? "R" : "A");
                num1 = Convert.ToInt32(dataRow13["SupplierID"].ToString());
                num2 = Convert.ToInt32(dataRow13["ContactID"].ToString());
                num3 = Convert.ToInt64(dataRow13["AddressID"].ToString());
                num7 = Convert.ToDecimal(dataRow13["cost"].ToString());
                pODN = dataRow13["ItemDescription"].ToString();
                long num29 = Convert.ToInt64(dataRow13["estOtherCostID"].ToString());
                num = PurchaseBasePage.purchase_insert((long)0, CompanyID, num1, num2, num3, this.objBase.ReplaceSingleQuote(empty1), "", "", dateTime, this.objBase.ReplaceSingleQuote(StrJobNum), "", "", (long)UserID, dateTime1, false, false, StatusID, UserID, UserID, this.CreatedDate, (long)0, empty, EstimateID, "", EstimateItemID, dateTime, num14, empty6, 0, (long)0, dateTime2, this.IsFromProgreesTojob, poNumber, isCombined);
                this.AttachmentUpdate_PO_DN(EstimateID, EstimateItemID, num, "Purchase");
                decimal num30 = (num7 * taxRate) / new decimal(100);
                PurchaseBasePage.purchaseitem_insert(CompanyID, (long)0, num, num4, empty2, empty3, pODN, Convert.ToDecimal(num5), Convert.ToDecimal(num6), Convert.ToDecimal(num7), taxID, num30, 0, "", false, num29, "U", (long)0, UserID, this.CreatedDate);
                foreach (DataRow row14 in PurchaseBasePage.purchase_select(CompanyID, num).Rows)
                {
                    empty4 = row14["PONO"].ToString();
                }
                if (str4 != "")
                {
                    str4 = string.Concat(str4, ", ");
                }
                str = new object[] { str4, "<a href='", this.objBase.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", num, "' target='_blank'>", empty4, "</a>" };
                str4 = string.Concat(str);
                string empty15 = string.Empty;
                foreach (DataRow dataRow14 in Notes.select_item_number_for_Activity_History(this.jobID, estimateItemID, this.modulename).Rows)
                {
                    empty15 = dataRow14["rownumber"].ToString();
                }
                if (empty5 != "")
                {
                    empty5 = string.Concat(empty5, ", ");
                }
                empty5 = string.Concat(empty5, "Item ", empty15);
            }
            AddPurchaseOrders = str4;
            AddItemNumbers = empty5;
        }
    }
}