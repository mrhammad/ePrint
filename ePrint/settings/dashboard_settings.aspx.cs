using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.dashboard;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Dock;

namespace ePrint.settings
{
    public partial class dashboard_settings : BaseClass, IRequiresSessionState
    {
        public int CompanyID;

        public int UserID;

        private commonClass objJava = new commonClass();

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        private BaseClass objbase = new BaseClass();

        private SettingsBasePage objset = new SettingsBasePage();

        public string ImgPath = global.imagePath();

        private Global gloobj = new Global();

        public int j;

        public int jMini;

        public int k;

        public int kMini;

        public string DockID = string.Empty;

        public int CopyMasterID;

        public string DateFormat = string.Empty;

        private commonClass comm = new commonClass();

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

        public dashboard_settings()
        {
        }

        public void BindEstimateStatus()
        {
            DataTable dataTable = SettingsBasePage.Settings_dashbaord_AllStatus(Convert.ToInt32(this.CompanyID), "Estimates");
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        column.ReadOnly = false;
                    }
                    if (!row.Table.Columns.Contains("StatusTitle"))
                    {
                        continue;
                    }
                    row["StatusTitle"] = this.objbase.SpecialDecode(row["StatusTitle"].ToString());
                }
            }
            this.ddlStatusEstimate.DataSource = dataTable;
            this.ddlStatusEstimate.DataTextField = "StatusTitle";
            this.ddlStatusEstimate.DataValueField = "StatusID";
            this.ddlStatusEstimate.DataBind();
            RadListBoxItem radListBoxItem = new RadListBoxItem();
            this.ddlStatusEstimate.Items.Insert(0, radListBoxItem);
            this.ddlStatusEstimate.Items[0].Text = "All";
            this.ddlStatusEstimate.Items[0].Value = "-1";
        }

        public void BindInvoiceStatus()
        {
            DataTable dataTable = SettingsBasePage.Settings_dashbaord_AllStatus(Convert.ToInt32(this.CompanyID), "Invoice");
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        column.ReadOnly = false;
                    }
                    if (!row.Table.Columns.Contains("StatusTitle"))
                    {
                        continue;
                    }
                    row["StatusTitle"] = this.objbase.SpecialDecode(row["StatusTitle"].ToString());
                }
            }
            this.ddlStatusInvoice.DataSource = dataTable;
            this.ddlStatusInvoice.DataTextField = "StatusTitle";
            this.ddlStatusInvoice.DataValueField = "StatusID";
            this.ddlStatusInvoice.DataBind();
            RadListBoxItem radListBoxItem = new RadListBoxItem();
            this.ddlStatusInvoice.Items.Insert(0, radListBoxItem);
            this.ddlStatusInvoice.Items[0].Text = "All";
            this.ddlStatusInvoice.Items[0].Value = "-1";
        }

        public void BindJobStatus()
        {
            DataTable dataTable = SettingsBasePage.Settings_dashbaord_AllStatus(Convert.ToInt32(this.CompanyID), "Jobs");
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        column.ReadOnly = false;
                    }
                    if (!row.Table.Columns.Contains("StatusTitle"))
                    {
                        continue;
                    }
                    row["StatusTitle"] = this.objbase.SpecialDecode(row["StatusTitle"].ToString());
                }
            }
            this.ddlStatusJob.DataSource = dataTable;
            this.ddlStatusJob.DataTextField = "StatusTitle";
            this.ddlStatusJob.DataValueField = "StatusID";
            this.ddlStatusJob.DataBind();
            RadListBoxItem radListBoxItem = new RadListBoxItem();
            this.ddlStatusJob.Items.Insert(0, radListBoxItem);
            this.ddlStatusJob.Items[0].Text = "All";
            this.ddlStatusJob.Items[0].Value = "-1";
        }

        public void btndelete_Click(object sender, EventArgs e)
        {
            SettingsBasePage.Settings_CopyWidget_delete(Convert.ToInt32(this.hdnCopyMasterID.Value), this.CompanyID);
            this.Session["Delete"] = "Delete";
            this.GetMasterDock();
            this.GetUseDock();
            this.GetMasterDockMini();
            this.GetUseDockMini();
            if (this.Session["Delete"] != null && this.Session["Delete"].ToString() != "")
            {
                this.divmsg.Style.Add("display", "block");
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_deleted_Successfully"), "msg-success", this.plhMessage);
                this.Session["Delete"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghide();", true);
            }
            this.divLoadingImageCus.Style.Add("display", "none");
        }

        public void btndeleteMini_Click(object sender, EventArgs e)
        {
            SettingsBasePage.Settings_MiniCopyWidget_delete(Convert.ToInt32(this.hdnIDMini.Value), this.CompanyID);
            this.Session["DeleteMini"] = "Delete";
            this.GetMasterDockMini();
            this.GetUseDockMini();
            this.GetMasterDock();
            this.GetUseDock();
            if (this.Session["DeleteMini"] != null && this.Session["DeleteMini"].ToString() != "")
            {
                this.divmsgMINI.Style.Add("display", "block");
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_deleted_Successfully"), "msg-success", this.plhMessageMINI);
                this.Session["DeleteMini"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghideMini();", true);
            }
            this.divLoadingImageCus.Style.Add("display", "none");
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(this.hdnMasterID.Value);
                DataSet dataSet = SettingsBasePage.Settings_MasterWidget_Select_ByMasterID(num);
                string str = dataSet.Tables[0].Rows[0]["WidgetType"].ToString();
                int num1 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DefaultDate"]);
                Convert.ToInt32(dataSet.Tables[0].Rows[0]["ShowPrint"]);
                dataSet.Tables[0].Rows[0]["TitleName"].ToString();
                string str1 = dataSet.Tables[0].Rows[0]["DisplayType"].ToString();
                dataSet.Tables[0].Rows[0]["GraphType"].ToString();
                string str2 = dataSet.Tables[0].Rows[0]["WidgetName"].ToString();
                string str3 = dataSet.Tables[0].Rows[0]["ModuleName"].ToString();
                int num2 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["NoOfRecords"].ToString());
                string str4 = dataSet.Tables[0].Rows[0]["CustomizeColumns"].ToString();
                int num3 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CustomerID"].ToString());
                bool flag = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsSpreadOverTwoColumns"].ToString());
                string str5 = dataSet.Tables[0].Rows[0]["TaskStatus"].ToString();
                string str6 = dataSet.Tables[0].Rows[0]["CompanyType"].ToString();
                flag = (!this.chkIsSpaead.Checked ? false : true);
                bool flag1 = false;
                int num4 = 0;
                bool flag2 = false;
                flag1 = (!this.chkfullscreen.Checked ? false : true);
                num4 = (!this.chkPrintOption.Checked ? 0 : 1);
                flag2 = (!this.chkshowalloptions.Checked ? false : true);
                num2 = Convert.ToInt32(this.ddlNoofRecords.SelectedValue);
                bool flag3 = false;
                flag3 = (!this.chkArchiverecords.Checked ? false : true);
                bool flag4 = false;
                flag4 = (!this.chkIsLastYearData.Checked ? false : true);
                bool flag5 = false;
                flag5 = (!this.chkIsDailyTarget.Checked ? false : true);
                bool flag6 = false;
                flag6 = (!this.chkIsMonthlyTarget.Checked ? false : true);
                if (num == 2)
                {
                    int count = this.lstsaleperson.CheckedItems.Count;
                    string empty = string.Empty;
                    for (int i = 0; i < this.lstsaleperson.Items.Count; i++)
                    {
                        if (this.lstsaleperson.Items[i].Checked && this.lstsaleperson.Items[i].Value != "-1")
                        {
                            empty = string.Concat(empty, this.lstsaleperson.Items[i].Value, ",");
                        }
                    }
                    empty = (empty == "" ? "-1" : empty.Substring(0, empty.Length - 1));
                    string empty1 = string.Empty;
                    if (this.ddlModuleName.SelectedValue == "Estimates")
                    {
                        int count1 = this.ddlStatusEstimate.CheckedItems.Count;
                        for (int j = 0; j < this.ddlStatusEstimate.Items.Count; j++)
                        {
                            if (this.ddlStatusEstimate.Items[j].Checked && this.ddlStatusEstimate.Items[j].Value != "-1")
                            {
                                empty1 = string.Concat(empty1, this.ddlStatusEstimate.Items[j].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Invoice")
                    {
                        int count2 = this.ddlStatusInvoice.CheckedItems.Count;
                        for (int k = 0; k < this.ddlStatusInvoice.Items.Count; k++)
                        {
                            if (this.ddlStatusInvoice.Items[k].Checked && this.ddlStatusInvoice.Items[k].Value != "-1")
                            {
                                empty1 = string.Concat(empty1, this.ddlStatusInvoice.Items[k].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Jobs")
                    {
                        int count3 = this.ddlStatusJob.CheckedItems.Count;
                        for (int l = 0; l < this.ddlStatusJob.Items.Count; l++)
                        {
                            if (this.ddlStatusJob.Items[l].Checked && this.ddlStatusJob.Items[l].Value != "-1")
                            {
                                empty1 = string.Concat(empty1, this.ddlStatusJob.Items[l].Value, ",");
                            }
                        }
                    }
                    empty1 = (empty1 == "" ? "-1" : empty1.Substring(0, empty1.Length - 1));
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType2.SelectedItem.Text, this.UserID, this.ddlModuleName.SelectedValue.ToString(), num2, str4, num3, flag, str5, str6, empty, "", "", "", "", flag1, flag2, empty1, flag3);
                }
                else if (num == 3)
                {
                    string empty2 = string.Empty;
                    if (this.ddlJobsinvoicebydue.SelectedValue == "Invoice")
                    {
                        int count4 = this.ddlStatusInvoice.CheckedItems.Count;
                        for (int m = 0; m < this.ddlStatusInvoice.Items.Count; m++)
                        {
                            if (this.ddlStatusInvoice.Items[m].Checked && this.ddlStatusInvoice.Items[m].Value != "-1")
                            {
                                empty2 = string.Concat(empty2, this.ddlStatusInvoice.Items[m].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlJobsinvoicebydue.SelectedValue == "Jobs")
                    {
                        int count5 = this.ddlStatusJob.CheckedItems.Count;
                        for (int n = 0; n < this.ddlStatusJob.Items.Count; n++)
                        {
                            if (this.ddlStatusJob.Items[n].Checked && this.ddlStatusJob.Items[n].Value != "-1")
                            {
                                empty2 = string.Concat(empty2, this.ddlStatusJob.Items[n].Value, ",");
                            }
                        }
                    }
                    empty2 = (empty2 == "" ? "-1" : empty2.Substring(0, empty2.Length - 1));
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType3.SelectedItem.Text, this.UserID, this.ddlJobsinvoicebydue.SelectedValue.ToString(), num2, str4, num3, flag, str5, str6, "0", "", "", "", "", flag1, flag2, empty2, flag3);
                }
                else if (num == 4)
                {
                    int num5 = this.ddlsalesPerson.CheckedItems.Count;
                    string empty3 = string.Empty;
                    for (int o = 0; o < this.ddlsalesPerson.Items.Count; o++)
                    {
                        if (this.ddlsalesPerson.Items[o].Checked && this.ddlsalesPerson.Items[o].Value != "-1")
                        {
                            empty3 = string.Concat(empty3, this.ddlsalesPerson.Items[o].Value, ",");
                        }
                    }
                    if (empty3 != "")
                    {
                        empty3 = empty3.Substring(0, empty3.Length - 1);
                    }
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddltaskResultselecType.SelectedValue), num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddlRecordType.SelectedValue.ToString(), "", this.UserID, str3, num2, str4, Convert.ToInt32(this.ddlcompanyName1.SelectedValue), flag, str5, str6, empty3, "", "", "", "", flag1, flag2, "", false);
                }
                else if (num == 5)
                {
                    string str7 = "";
                    for (int p = 0; p < this.chkLatestcolumns.Items.Count; p++)
                    {
                        if (this.chkLatestcolumns.Items[p].Selected)
                        {
                            str7 = string.Concat(str7, this.chkLatestcolumns.Items[p].Value, ",");
                        }
                    }
                    str4 = str7.Substring(0, str7.Length - 1);
                    num3 = Convert.ToInt32(this.ddlCustomers.SelectedValue);
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, "", this.UserID, str3, num2, str4, num3, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false);
                }
                else if (num == 6)
                {
                    num1 = Convert.ToInt32(this.ddlTasksDaterange.SelectedValue);
                    str5 = this.ddlTaskStatus.SelectedValue.ToString();
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, "", this.UserID, str3, num2, str4, num3, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false);
                }
                else if (num == 7)
                {
                    str6 = this.ddlCompanyType.SelectedValue.ToString();
                    string str8 = "";
                    for (int q = 0; q < this.chkcolscustomeractivity.Items.Count; q++)
                    {
                        if (this.chkcolscustomeractivity.Items[q].Selected)
                        {
                            str8 = string.Concat(str8, this.chkcolscustomeractivity.Items[q].Value, ",");
                        }
                    }
                    str4 = str8.Substring(0, str8.Length - 1);
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, "", this.UserID, str3, num2, str4, num3, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false);
                }
                else if (num == 8)
                {
                    int count6 = this.lstsaleperson.CheckedItems.Count;
                    string empty4 = string.Empty;
                    for (int r = 0; r < this.lstsaleperson.Items.Count; r++)
                    {
                        if (this.lstsaleperson.Items[r].Checked && this.lstsaleperson.Items[r].Value != "-1")
                        {
                            empty4 = string.Concat(empty4, this.lstsaleperson.Items[r].Value, ",");
                        }
                    }
                    empty4 = (empty4 == "" ? "-1" : empty4.Substring(0, empty4.Length - 1));
                    string empty5 = string.Empty;
                    if (this.ddlModuleName.SelectedValue == "Estimates")
                    {
                        int num6 = this.ddlStatusEstimate.CheckedItems.Count;
                        for (int s = 0; s < this.ddlStatusEstimate.Items.Count; s++)
                        {
                            if (this.ddlStatusEstimate.Items[s].Checked && this.ddlStatusEstimate.Items[s].Value != "-1")
                            {
                                empty5 = string.Concat(empty5, this.ddlStatusEstimate.Items[s].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Invoice")
                    {
                        int count7 = this.ddlStatusInvoice.CheckedItems.Count;
                        for (int t = 0; t < this.ddlStatusInvoice.Items.Count; t++)
                        {
                            if (this.ddlStatusInvoice.Items[t].Checked && this.ddlStatusInvoice.Items[t].Value != "-1")
                            {
                                empty5 = string.Concat(empty5, this.ddlStatusInvoice.Items[t].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Jobs")
                    {
                        int num7 = this.ddlStatusJob.CheckedItems.Count;
                        for (int u = 0; u < this.ddlStatusJob.Items.Count; u++)
                        {
                            if (this.ddlStatusJob.Items[u].Checked && this.ddlStatusJob.Items[u].Value != "-1")
                            {
                                empty5 = string.Concat(empty5, this.ddlStatusJob.Items[u].Value, ",");
                            }
                        }
                    }
                    empty5 = (empty5 == "" ? "-1" : empty5.Substring(0, empty5.Length - 1));
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType2.SelectedItem.Text, this.UserID, this.ddlModuleName.SelectedValue.ToString(), num2, str4, num3, flag, str5, str6, empty4, "", "", "", "", flag1, flag2, empty5, flag3);
                }
                else if (num == 9)
                {
                    int count8 = this.lstsaleperson.CheckedItems.Count;
                    string empty6 = string.Empty;
                    for (int v = 0; v < this.lstsaleperson.Items.Count; v++)
                    {
                        if (this.lstsaleperson.Items[v].Checked && this.lstsaleperson.Items[v].Value != "-1")
                        {
                            empty6 = string.Concat(empty6, this.lstsaleperson.Items[v].Value, ",");
                        }
                    }
                    empty6 = (empty6 == "" ? "-1" : empty6.Substring(0, empty6.Length - 1));
                    int num8 = this.ddlStatusEstimate.CheckedItems.Count;
                    string empty7 = string.Empty;
                    for (int w = 0; w < this.ddlStatusEstimate.Items.Count; w++)
                    {
                        if (this.ddlStatusEstimate.Items[w].Checked && this.ddlStatusEstimate.Items[w].Value != "-1")
                        {
                            empty7 = string.Concat(empty7, this.ddlStatusEstimate.Items[w].Value, ",");
                        }
                    }
                    empty7 = (empty7 == "" ? "-1" : empty7.Substring(0, empty7.Length - 1));
                    if (this.ddlquarterType.SelectedValue != "DateRange")
                    {
                        SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddltargetdispplayType.SelectedItem.Text, this.ddlTargetGraphType.SelectedItem.Text, this.UserID, this.ddlRecordsTypes.SelectedValue.ToString(), num2, str4, num3, flag, str5, str6, this.ddlTargetSalesPerson.SelectedValue, this.ddlquarterType.SelectedValue, "", "", this.ddlEstimateType.SelectedValue, flag1, flag2, empty7, flag3);
                    }
                    else
                    {
                        string str9 = this.objbase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtFromdate.Text);
                        string str10 = this.objbase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtToate.Text);
                        SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddltargetdispplayType.SelectedItem.Text, this.ddlTargetGraphType.SelectedItem.Text, this.UserID, this.ddlRecordsTypes.SelectedValue.ToString(), num2, str4, num3, flag, str5, str6, this.ddlTargetSalesPerson.SelectedValue, this.ddlquarterType.SelectedValue, str9, str10, this.ddlEstimateType.SelectedValue, flag1, flag2, empty7, flag3);
                    }
                }
                else if (num == 10)
                {
                    int count9 = this.lstsaleperson.CheckedItems.Count;
                    string empty8 = string.Empty;
                    for (int x = 0; x < this.lstsaleperson.Items.Count; x++)
                    {
                        if (this.lstsaleperson.Items[x].Checked && this.lstsaleperson.Items[x].Value != "-1")
                        {
                            empty8 = string.Concat(empty8, this.lstsaleperson.Items[x].Value, ",");
                        }
                    }
                    empty8 = (empty8 == "" ? "-1" : empty8.Substring(0, empty8.Length - 1));
                    int num9 = this.ddlStatusEstimate.CheckedItems.Count;
                    string empty9 = string.Empty;
                    for (int y = 0; y < this.ddlStatusEstimate.Items.Count; y++)
                    {
                        if (this.ddlStatusEstimate.Items[y].Checked && this.ddlStatusEstimate.Items[y].Value != "-1")
                        {
                            empty9 = string.Concat(empty9, this.ddlStatusEstimate.Items[y].Value, ",");
                        }
                    }
                    empty9 = (empty9 == "" ? "-1" : empty9.Substring(0, empty9.Length - 1));
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType.SelectedItem.Text, this.UserID, str3, num2, str4, num3, flag, str5, str6, empty8, "", "", "", "", flag1, flag2, empty9, flag3);
                }
                else if (num == 11)
                {
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddltaskResultselecType.SelectedValue), num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddlRecordType.SelectedValue.ToString(), "", this.UserID, str3, num2, str4, Convert.ToInt32(this.ddlcompanyName1.SelectedValue), flag, str5, str6, this.DropDownList1.SelectedValue, "", "", "", "", flag1, flag2, "", false);
                }
                else if (num == 12)
                {
                    int count10 = this.ddlsalesPerson.CheckedItems.Count;
                    string empty10 = string.Empty;
                    for (int a = 0; a < this.ddlsalesPerson.Items.Count; a++)
                    {
                        if (this.ddlsalesPerson.Items[a].Checked && this.ddlsalesPerson.Items[a].Value != "-1")
                        {
                            empty10 = string.Concat(empty10, this.ddlsalesPerson.Items[a].Value, ",");
                        }
                    }
                    if (empty10 != "")
                    {
                        empty10 = empty10.Substring(0, empty10.Length - 1);
                    }
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlRecordDate.SelectedValue), num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddltargetdispplayType1.SelectedValue.ToString(), this.lblbar.Text, this.UserID, str3, num2, str4, Convert.ToInt32(this.ddlcompanyName1.SelectedValue), flag, str5, str6, empty10, "", "", "", "", flag1, flag2, "", false);
                }
                else if (num == 13 || num == 14)
                {
                    flag = true ;
                    SettingsBasePage.Settings_Insert_CopyWidgetsNew(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType.SelectedItem.Text, this.UserID, str3, num2, str4, num3, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false,flag4,flag5,flag6);
                }
                else if (num == 15)
                {
                    SettingsBasePage.Settings_Insert_CopyWidgetsNew(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlAccountingCodeDaterange.SelectedValue), num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, "Pie" , this.UserID, str3, num2, str4, num3, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false, flag4,flag5,flag6);
                }
                else if (num != 1)
                {
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType.SelectedItem.Text, this.UserID, str3, num2, str4, num3, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false);
                }
                else
                {
                    string empty11 = string.Empty;
                    if (this.ddlModuleName.SelectedValue == "Estimates")
                    {
                        int num10 = this.ddlStatusEstimate.CheckedItems.Count;
                        for (int b = 0; b < this.ddlStatusEstimate.Items.Count; b++)
                        {
                            if (this.ddlStatusEstimate.Items[b].Checked && this.ddlStatusEstimate.Items[b].Value != "-1")
                            {
                                empty11 = string.Concat(empty11, this.ddlStatusEstimate.Items[b].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Invoice")
                    {
                        int count11 = this.ddlStatusInvoice.CheckedItems.Count;
                        for (int c = 0; c < this.ddlStatusInvoice.Items.Count; c++)
                        {
                            if (this.ddlStatusInvoice.Items[c].Checked && this.ddlStatusInvoice.Items[c].Value != "-1")
                            {
                                empty11 = string.Concat(empty11, this.ddlStatusInvoice.Items[c].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Jobs")
                    {
                        int num11 = this.ddlStatusJob.CheckedItems.Count;
                        for (int d = 0; d < this.ddlStatusJob.Items.Count; d++)
                        {
                            if (this.ddlStatusJob.Items[d].Checked && this.ddlStatusJob.Items[d].Value != "-1")
                            {
                                empty11 = string.Concat(empty11, this.ddlStatusJob.Items[d].Value, ",");
                            }
                        }
                    }
                    empty11 = (empty11 == "" ? "-1" : empty11.Substring(0, empty11.Length - 1));
                    SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num4, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType.SelectedItem.Text, this.UserID, this.ddlModuleName.SelectedValue, num2, str4, num3, flag, str5, str6, "0", "", "", "", "", flag1, flag2, empty11, flag3);
                }
                this.GetUseDock();
                this.GetUseDockMini();
                this.Session["Save"] = "Save";
                base.Response.Redirect(base.Request.Url.ToString());
            }
            catch
            {
            }
        }

        protected void btnSaveMini_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.chkIncludeArchivedRecordMini.Checked)
            {
                flag = true;
            }
            bool flag1 = false;
            if (this.ChkDisplayWidgetMini.Checked)
            {
                flag1 = true;
            }

            string isCalendarYear = "1";
            if(this.financialYear.Checked == true)
            {
                isCalendarYear = "0";
            }

            //string[] strArrays1 = this.txtFromDateNew.Text.Split('/');
            //string frmDate = strArrays1[1] + "/" + strArrays1[0] + "/" + strArrays1[2];

            //string[] strArrays2 = this.txtToDate.Text.Split('/');
            //string toDate = strArrays2[1] + "/" + strArrays2[0] + "/" + strArrays2[2];

            string strFromDate = "01/01/1900";
            string strTodate = "12/31/2100";

            if (this.txtFromDateNew.Text.Length > 0)
            {
                strFromDate = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtFromDateNew.Text);
            }
            if (this.txtToDate.Text.Length > 0)
            {
                strTodate = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtToDate.Text);
            }
            //MonthlyTarget monthlyTarget = new MonthlyTarget();
            //monthlyTarget.MonthlyTarget1 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget1.Value) ? "0" : this.MonthlyTarget1.Value);
            //monthlyTarget.MonthlyTarget2 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget2.Value) ? "0" : this.MonthlyTarget2.Value);
            //monthlyTarget.MonthlyTarget3 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget3.Value) ? "0" : this.MonthlyTarget3.Value);
            //monthlyTarget.MonthlyTarget4 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget4.Value) ? "0" : this.MonthlyTarget4.Value);
            //monthlyTarget.MonthlyTarget5 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget5.Value) ? "0" : this.MonthlyTarget5.Value);
            //monthlyTarget.MonthlyTarget6 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget6.Value) ? "0" : this.MonthlyTarget6.Value);
            //monthlyTarget.MonthlyTarget7 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget7.Value) ? "0" : this.MonthlyTarget7.Value);
            //monthlyTarget.MonthlyTarget8 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget8.Value) ? "0" : this.MonthlyTarget8.Value);
            //monthlyTarget.MonthlyTarget9 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget9.Value) ? "0" : this.MonthlyTarget9.Value);
            //monthlyTarget.MonthlyTarget10 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget10.Value) ? "0" : this.MonthlyTarget10.Value);
            //monthlyTarget.MonthlyTarget11 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget11.Value) ? "0" : this.MonthlyTarget11.Value);
            //monthlyTarget.MonthlyTarget12 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget12.Value) ? "0" : this.MonthlyTarget12.Value);

            //DailyTarget dailyTarget = new DailyTarget();
            //dailyTarget.DailyTarget1 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget1.Value) ? "0" : this.DailyTarget1.Value);
            //dailyTarget.DailyTarget2 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget2.Value) ? "0" : this.DailyTarget2.Value);
            //dailyTarget.DailyTarget3 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget3.Value) ? "0" : this.DailyTarget3.Value);
            //dailyTarget.DailyTarget4 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget4.Value) ? "0" : this.DailyTarget4.Value);
            //dailyTarget.DailyTarget5 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget5.Value) ? "0" : this.DailyTarget5.Value);
            //dailyTarget.DailyTarget6 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget6.Value) ? "0" : this.DailyTarget6.Value);
            //dailyTarget.DailyTarget7 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget7.Value) ? "0" : this.DailyTarget7.Value);
            //dailyTarget.DailyTarget8 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget8.Value) ? "0" : this.DailyTarget8.Value);
            //dailyTarget.DailyTarget9 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget9.Value) ? "0" : this.DailyTarget9.Value);
            //dailyTarget.DailyTarget10 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget10.Value) ? "0" : this.DailyTarget10.Value);
            //dailyTarget.DailyTarget11 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget11.Value) ? "0" : this.DailyTarget11.Value);
            //dailyTarget.DailyTarget12 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget12.Value) ? "0" : this.DailyTarget12.Value);
            //dailyTarget.DailyTarget13 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget13.Value) ? "0" : this.DailyTarget13.Value);
            //dailyTarget.DailyTarget14 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget14.Value) ? "0" : this.DailyTarget14.Value);
            //dailyTarget.DailyTarget15 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget15.Value) ? "0" : this.DailyTarget15.Value);
            //dailyTarget.DailyTarget16 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget16.Value) ? "0" : this.DailyTarget16.Value);
            //dailyTarget.DailyTarget17 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget17.Value) ? "0" : this.DailyTarget17.Value);
            //dailyTarget.DailyTarget18 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget18.Value) ? "0" : this.DailyTarget18.Value);
            //dailyTarget.DailyTarget19 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget19.Value) ? "0" : this.DailyTarget19.Value);
            //dailyTarget.DailyTarget20 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget20.Value) ? "0" : this.DailyTarget20.Value);
            //dailyTarget.DailyTarget21 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget21.Value) ? "0" : this.DailyTarget21.Value);
            //dailyTarget.DailyTarget22 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget22.Value) ? "0" : this.DailyTarget22.Value);
            //dailyTarget.DailyTarget23 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget23.Value) ? "0" : this.DailyTarget23.Value);
            //dailyTarget.DailyTarget24 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget24.Value) ? "0" : this.DailyTarget24.Value);
            //dailyTarget.DailyTarget25 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget25.Value) ? "0" : this.DailyTarget25.Value);
            //dailyTarget.DailyTarget26 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget26.Value) ? "0" : this.DailyTarget26.Value);
            //dailyTarget.DailyTarget27 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget27.Value) ? "0" : this.DailyTarget27.Value);
            //dailyTarget.DailyTarget28 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget28.Value) ? "0" : this.DailyTarget28.Value);
            //dailyTarget.DailyTarget29 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget29.Value) ? "0" : this.DailyTarget29.Value);
            //dailyTarget.DailyTarget30 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget30.Value) ? "0" : this.DailyTarget30.Value);
            //dailyTarget.DailyTarget31 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget31.Value) ? "0" : this.DailyTarget31.Value);
            //if(this.hdnMasterIDMini.Value == "12")
            //{
            //    SettingsBasePage.Settings_Insert_CopyWidgets(Convert.ToInt64(this.hdnMasterIDMini.Value), Convert.ToInt64(this.CompanyID), this.UserID, this.DropDownList2.SelectedValue, Convert.ToBoolean(flag), Convert.ToBoolean(flag1), this.hdn_selectedcolorMini.Value, this.txtTitleMini.Text, Convert.ToInt64(this.UserID), isCalendarYear, strFromDate, strTodate, dailyTarget, monthlyTarget);
            //}
            //else
            //{
            //    SettingsBasePage.Settings_Insert_CopyWidgets(Convert.ToInt64(this.hdnMasterIDMini.Value), Convert.ToInt64(this.CompanyID), this.ddlUserMini.SelectedValue, this.ddlDateTypeMiniNew.SelectedValue, Convert.ToBoolean(flag), Convert.ToBoolean(flag1), this.hdn_selectedcolorMini.Value, this.txtTitleMini.Text, Convert.ToInt64(this.UserID), isCalendarYear, strFromDate, strTodate);
            //}
            SettingsBasePage.Settings_Insert_CopyWidgets(Convert.ToInt64(this.hdnMasterIDMini.Value), Convert.ToInt64(this.CompanyID), this.ddlUserMini.SelectedValue, this.ddlDateTypeMiniNew.SelectedValue, Convert.ToBoolean(flag), Convert.ToBoolean(flag1), this.hdn_selectedcolorMini.Value, this.txtTitleMini.Text, Convert.ToInt64(this.UserID), isCalendarYear, strFromDate, strTodate);

            //SettingsBasePage.Settings_Insert_CopyWidgetsNew(Convert.ToInt64(this.hdnMasterIDMini.Value), Convert.ToInt64(this.CompanyID), this.ddlUserMini.SelectedValue, this.ddlDateTypeMiniNew.SelectedValue, Convert.ToBoolean(flag), Convert.ToBoolean(flag1), this.hdn_selectedcolorMini.Value, this.txtTitleMini.Text, Convert.ToInt64(this.UserID), isCalendarYear, strFromDate, strTodate, dailyTarget, monthlyTarget);
            //if (this.hdnMasterIDMini.Value != "10")
            //{
            //    SettingsBasePage.Settings_Insert_CopyWidgets(Convert.ToInt64(this.hdnMasterIDMini.Value), Convert.ToInt64(this.CompanyID), this.ddlUserMini.SelectedValue, this.ddlDateTypeMini.SelectedValue, Convert.ToBoolean(flag), Convert.ToBoolean(flag1), this.hdn_selectedcolorMini.Value, this.txtTitleMini.Text, Convert.ToInt64(this.UserID), isCalendarYear, strFromDate, strTodate);
            //}
            //else
            //{
            //    SettingsBasePage.Settings_Insert_CopyWidgets(Convert.ToInt64(this.hdnMasterIDMini.Value), Convert.ToInt64(this.CompanyID), this.ddlUserMini.SelectedValue, this.ddlDateTypeMiniNew.SelectedValue, Convert.ToBoolean(flag), Convert.ToBoolean(flag1), this.hdn_selectedcolorMini.Value, this.txtTitleMini.Text, Convert.ToInt64(this.UserID), isCalendarYear, strFromDate, strTodate);
            //}
            this.GetUseDockMini();
            this.GetUseDock();
            this.Session["AddedMini"] = "Added";
            this.lblNoWidgetsMINI.Style.Add("display", "none");
            if (this.Session["AddedMini"] != null && this.Session["AddedMini"].ToString() != "")
            {
                this.divmsgMINI.Style.Add("display", "block");
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_added_Successfully"), "msg-success", this.plhMessageMINI);
                this.Session["AddedMini"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghideUSeMini();", true);
            }
            this.GetMasterDockMini();
            this.GetMasterDock();
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                string isCalendarYear = "1";
                if (this.financialYear2.Checked == true)
                {
                    isCalendarYear = "0";
                }

                string strFromDate = "01/01/1900";
                string strTodate = "12/31/2100";

                if (this.txtFromDateNew.Text.Length > 0)
                {
                    strFromDate = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtFromDate2.Text);
                }
                if (this.txtToDate.Text.Length > 0)
                {
                    strTodate = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtToDate2.Text);
                }



                int num = Convert.ToInt32(this.hdnCopyMasterID.Value);
                DataSet dataSet = SettingsBasePage.Settings_Select_CopyWidgets(num);
                string str = dataSet.Tables[0].Rows[0]["WidgetType"].ToString();
                int num1 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DefaultDate"]);
                Convert.ToInt32(dataSet.Tables[0].Rows[0]["ShowPrint"]);
                dataSet.Tables[0].Rows[0]["TitleName"].ToString();
                string str1 = dataSet.Tables[0].Rows[0]["DisplayType"].ToString();
                dataSet.Tables[0].Rows[0]["GraphType"].ToString();
                string str2 = dataSet.Tables[0].Rows[0]["WidgetName"].ToString();
                int num2 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["MasterID"].ToString());
                string str3 = dataSet.Tables[0].Rows[0]["ModuleName"].ToString();
                int num3 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["NoOfRecords"].ToString());
                string str4 = dataSet.Tables[0].Rows[0]["CustomizeColumns"].ToString();
                int num4 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CustomerID"].ToString());
                bool flag = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsSpreadOverTwoColumns"].ToString());
                string str5 = dataSet.Tables[0].Rows[0]["TaskStatus"].ToString();
                string str6 = dataSet.Tables[0].Rows[0]["CompanyType"].ToString();
                flag = (!this.chkIsSpaead.Checked ? false : true);
                bool flag1 = false;
                int num5 = 0;
                bool flag2 = false;
                flag1 = (!this.chkfullscreen.Checked ? false : true);
                num5 = (!this.chkPrintOption.Checked ? 0 : 1);
                flag2 = (!this.chkshowalloptions.Checked ? false : true);
                num3 = Convert.ToInt32(this.ddlNoofRecords.SelectedValue);
                if (num2 == 2)
                {
                    string empty = string.Empty;
                    if (this.ddlModuleName.SelectedValue == "Estimates")
                    {
                        int count = this.ddlStatusEstimate.CheckedItems.Count;
                        for (int i = 0; i < this.ddlStatusEstimate.Items.Count; i++)
                        {
                            if (this.ddlStatusEstimate.Items[i].Checked && this.ddlStatusEstimate.Items[i].Value != "-1")
                            {
                                empty = string.Concat(empty, this.ddlStatusEstimate.Items[i].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Invoice")
                    {
                        int count1 = this.ddlStatusInvoice.CheckedItems.Count;
                        for (int j = 0; j < this.ddlStatusInvoice.Items.Count; j++)
                        {
                            if (this.ddlStatusInvoice.Items[j].Checked && this.ddlStatusInvoice.Items[j].Value != "-1")
                            {
                                empty = string.Concat(empty, this.ddlStatusInvoice.Items[j].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Jobs")
                    {
                        int count2 = this.ddlStatusJob.CheckedItems.Count;
                        for (int k = 0; k < this.ddlStatusJob.Items.Count; k++)
                        {
                            if (this.ddlStatusJob.Items[k].Checked && this.ddlStatusJob.Items[k].Value != "-1")
                            {
                                empty = string.Concat(empty, this.ddlStatusJob.Items[k].Value, ",");
                            }
                        }
                    }
                    empty = (empty == "" ? "-1" : empty.Substring(0, empty.Length - 1));
                    bool flag3 = false;
                    flag3 = (!this.chkArchiverecords.Checked ? false : true);
                    int count3 = this.lstsaleperson.CheckedItems.Count;
                    string empty1 = string.Empty;
                    for (int l = 0; l < this.lstsaleperson.Items.Count; l++)
                    {
                        if (this.lstsaleperson.Items[l].Checked && this.lstsaleperson.Items[l].Value != "-1")
                        {
                            empty1 = string.Concat(empty1, this.lstsaleperson.Items[l].Value, ",");
                        }
                    }
                    empty1 = (empty1 == "" ? "-1" : empty1.Substring(0, empty1.Length - 1));
                    str3 = this.ddlModuleName.SelectedValue.ToString();
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType2.SelectedItem.Text, this.UserID, str3, num3, str4, num4, flag, str5, str6, empty1, "",strFromDate ,strTodate , "", flag1, flag2, empty, flag3,isCalendarYear,this.ddldate.SelectedValue);
                }
                else if (num2 == 3)
                {
                    string empty2 = string.Empty;
                    if (this.ddlJobsinvoicebydue.SelectedValue == "Invoice")
                    {
                        int count4 = this.ddlStatusInvoice.CheckedItems.Count;
                        for (int m = 0; m < this.ddlStatusInvoice.Items.Count; m++)
                        {
                            if (this.ddlStatusInvoice.Items[m].Checked && this.ddlStatusInvoice.Items[m].Value != "-1")
                            {
                                empty2 = string.Concat(empty2, this.ddlStatusInvoice.Items[m].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlJobsinvoicebydue.SelectedValue == "Jobs")
                    {
                        int count5 = this.ddlStatusJob.CheckedItems.Count;
                        for (int n = 0; n < this.ddlStatusJob.Items.Count; n++)
                        {
                            if (this.ddlStatusJob.Items[n].Checked && this.ddlStatusJob.Items[n].Value != "-1")
                            {
                                empty2 = string.Concat(empty2, this.ddlStatusJob.Items[n].Value, ",");
                            }
                        }
                    }
                    bool flag4 = false;
                    flag4 = (!this.chkArchiverecords.Checked ? false : true);
                    str3 = this.ddlJobsinvoicebydue.SelectedValue.ToString();
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType3.SelectedItem.Text, this.UserID, str3, num3, str4, num4, flag, str5, str6, "0", "", strFromDate, strTodate, "", flag1, flag2, empty2, flag4,isCalendarYear, this.ddldate.SelectedValue);
                }
                else if (num2 == 4)
                {
                    int count6 = this.ddlsalesPerson.CheckedItems.Count;
                    string empty3 = string.Empty;
                    for (int o = 0; o < this.ddlsalesPerson.Items.Count; o++)
                    {
                        if (this.ddlsalesPerson.Items[o].Checked && this.ddlsalesPerson.Items[o].Value != "-1")
                        {
                            empty3 = string.Concat(empty3, this.ddlsalesPerson.Items[o].Value, ",");
                        }
                    }
                    if (empty3 != "")
                    {
                        empty3 = empty3.Substring(0, empty3.Length - 1);
                    }
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddltaskResultselecType.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddlRecordType.SelectedValue.ToString(), "", this.UserID, str3, num3, str4, Convert.ToInt32(this.ddlcompanyName1.SelectedValue), flag, str5, str6, empty3, "", "", "", "", flag1, flag2, "", false,isCalendarYear, "");
                }
                else if (num2 == 5)
                {
                    string str7 = "";
                    for (int p = 0; p < this.chkLatestcolumns.Items.Count; p++)
                    {
                        if (this.chkLatestcolumns.Items[p].Selected)
                        {
                            str7 = string.Concat(str7, this.chkLatestcolumns.Items[p].Value, ",");
                        }
                    }
                    str4 = str7.Substring(0, str7.Length - 1);
                    num4 = Convert.ToInt32(this.ddlCustomers.SelectedValue);
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddlDisplayType.SelectedValue.ToString(), "", this.UserID, str3, num3, str4, num4, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false,isCalendarYear, "");
                }
                else if (num2 == 6)
                {
                    num1 = Convert.ToInt32(this.ddlTasksDaterange.SelectedValue);
                    str5 = this.ddlTaskStatus.SelectedValue.ToString();
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddlDisplayType.SelectedValue.ToString(), "", this.UserID, str3, num3, str4, num4, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false,isCalendarYear, "");
                }
                else if (num2 == 7)
                {
                    str6 = this.ddlCompanyType.SelectedValue.ToString();
                    string str8 = "";
                    for (int q = 0; q < this.chkcolscustomeractivity.Items.Count; q++)
                    {
                        if (this.chkcolscustomeractivity.Items[q].Selected)
                        {
                            str8 = string.Concat(str8, this.chkcolscustomeractivity.Items[q].Value, ",");
                        }
                    }
                    str4 = str8.Substring(0, str8.Length - 1);
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddlDisplayType.SelectedValue.ToString(), "", this.UserID, str3, num3, str4, num4, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false,isCalendarYear, "");
                }
                else if (num2 == 8)
                {
                    int num6 = this.lstsaleperson.CheckedItems.Count;
                    string empty4 = string.Empty;
                    for (int r = 0; r < this.lstsaleperson.Items.Count; r++)
                    {
                        if (this.lstsaleperson.Items[r].Checked && this.lstsaleperson.Items[r].Value != "-1")
                        {
                            empty4 = string.Concat(empty4, this.lstsaleperson.Items[r].Value, ",");
                        }
                    }
                    empty4 = (empty4 == "" ? "-1" : empty4.Substring(0, empty4.Length - 1));
                    str3 = this.ddlModuleName.SelectedValue.ToString();
                    string empty5 = string.Empty;
                    if (this.ddlModuleName.SelectedValue == "Estimates")
                    {
                        int count7 = this.ddlStatusEstimate.CheckedItems.Count;
                        for (int s = 0; s < this.ddlStatusEstimate.Items.Count; s++)
                        {
                            if (this.ddlStatusEstimate.Items[s].Checked && this.ddlStatusEstimate.Items[s].Value != "-1")
                            {
                                empty5 = string.Concat(empty5, this.ddlStatusEstimate.Items[s].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Invoice")
                    {
                        int num7 = this.ddlStatusInvoice.CheckedItems.Count;
                        for (int t = 0; t < this.ddlStatusInvoice.Items.Count; t++)
                        {
                            if (this.ddlStatusInvoice.Items[t].Checked && this.ddlStatusInvoice.Items[t].Value != "-1")
                            {
                                empty5 = string.Concat(empty5, this.ddlStatusInvoice.Items[t].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Jobs")
                    {
                        int count8 = this.ddlStatusJob.CheckedItems.Count;
                        for (int u = 0; u < this.ddlStatusJob.Items.Count; u++)
                        {
                            if (this.ddlStatusJob.Items[u].Checked && this.ddlStatusJob.Items[u].Value != "-1")
                            {
                                empty5 = string.Concat(empty5, this.ddlStatusJob.Items[u].Value, ",");
                            }
                        }
                    }
                    empty5 = (empty5 == "" ? "-1" : empty5.Substring(0, empty5.Length - 1));
                    bool flag5 = false;
                    flag5 = (!this.chkArchiverecords.Checked ? false : true);
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType2.SelectedItem.Text, this.UserID, str3, num3, str4, num4, flag, str5, str6, empty4, "", strFromDate, strTodate, "", flag1, flag2, empty5, flag5,isCalendarYear, this.ddldate.SelectedValue);
                }
                else if (num2 == 9)
                {
                    int num8 = this.lstsaleperson.CheckedItems.Count;
                    string empty6 = string.Empty;
                    for (int v = 0; v < this.lstsaleperson.Items.Count; v++)
                    {
                        if (this.lstsaleperson.Items[v].Checked && this.lstsaleperson.Items[v].Value != "-1")
                        {
                            empty6 = string.Concat(empty6, this.lstsaleperson.Items[v].Value, ",");
                        }
                    }
                    empty6 = (empty6 == "" ? "-1" : empty6.Substring(0, empty6.Length - 1));
                    int count9 = this.ddlStatusEstimate.CheckedItems.Count;
                    string empty7 = string.Empty;
                    for (int w = 0; w < this.ddlStatusEstimate.Items.Count; w++)
                    {
                        if (this.ddlStatusEstimate.Items[w].Checked && this.ddlStatusEstimate.Items[w].Value != "-1")
                        {
                            empty7 = string.Concat(empty7, this.ddlStatusEstimate.Items[w].Value, ",");
                        }
                    }
                    empty7 = (empty7 == "" ? "-1" : empty7.Substring(0, empty7.Length - 1));
                    bool flag6 = false;
                    flag6 = (!this.chkArchiverecords.Checked ? false : true);
                    if (this.ddlquarterType.SelectedValue != "DateRange")
                    {
                        SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddltargetdispplayType.SelectedValue, this.ddlTargetGraphType.SelectedItem.Text, this.UserID, this.ddlRecordsTypes.SelectedValue, num3, str4, num4, flag, str5, str6, this.ddlTargetSalesPerson.SelectedValue, this.ddlquarterType.SelectedValue, "", "", this.ddlEstimateType.SelectedValue, flag1, flag2, empty7, flag6,isCalendarYear, "");
                    }
                    else
                    {
                        string str9 = this.objbase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtFromdate.Text);
                        string str10 = this.objbase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtToate.Text);
                        SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddltargetdispplayType.SelectedValue, this.ddlTargetGraphType.SelectedItem.Text, this.UserID, this.ddlRecordsTypes.SelectedValue, num3, str4, num4, flag, str5, str6, this.ddlTargetSalesPerson.SelectedValue, this.ddlquarterType.SelectedValue, str9, str10, this.ddlEstimateType.SelectedValue, flag1, flag2, empty7, flag6,isCalendarYear, "");
                    }
                }
                else if (num2 == 10)
                {
                    int num9 = this.lstsaleperson.CheckedItems.Count;
                    string empty8 = string.Empty;
                    for (int x = 0; x < this.lstsaleperson.Items.Count; x++)
                    {
                        if (this.lstsaleperson.Items[x].Checked && this.lstsaleperson.Items[x].Value != "-1")
                        {
                            empty8 = string.Concat(empty8, this.lstsaleperson.Items[x].Value, ",");
                        }
                    }
                    empty8 = (empty8 == "" ? "-1" : empty8.Substring(0, empty8.Length - 1));
                    int count10 = this.ddlStatusEstimate.CheckedItems.Count;
                    string empty9 = string.Empty;
                    for (int y = 0; y < this.ddlStatusEstimate.Items.Count; y++)
                    {
                        if (this.ddlStatusEstimate.Items[y].Checked && this.ddlStatusEstimate.Items[y].Value != "-1")
                        {
                            empty9 = string.Concat(empty9, this.ddlStatusEstimate.Items[y].Value, ",");
                        }
                    }
                    empty9 = (empty9 == "" ? "-1" : empty9.Substring(0, empty9.Length - 1));
                    bool flag7 = false;
                    flag7 = (!this.chkArchiverecords.Checked ? false : true);
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType.SelectedItem.Text, this.UserID, str3, num3, str4, num4, flag, str5, str6, empty8, "", "", "", "", flag1, flag2, empty9, flag7,isCalendarYear,"");
                }
                else if (num2 == 11)
                {
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddltaskResultselecType.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddlRecordType.SelectedValue.ToString(), "", this.UserID, str3, num3, str4, Convert.ToInt32(this.ddlcompanyName1.SelectedValue), flag, str5, str6, this.DropDownList1.SelectedValue, "", "", "", "", flag1, flag2, "", false,isCalendarYear,"");
                }
                else if (num2 == 12)
                {
                    int num10 = this.ddlsalesPerson.CheckedItems.Count;
                    string empty10 = string.Empty;
                    for (int a = 0; a < this.ddlsalesPerson.Items.Count; a++)
                    {
                        if (this.ddlsalesPerson.Items[a].Checked && this.ddlsalesPerson.Items[a].Value != "-1")
                        {
                            empty10 = string.Concat(empty10, this.ddlsalesPerson.Items[a].Value, ",");
                        }
                    }
                    if (empty10 != "")
                    {
                        empty10 = empty10.Substring(0, empty10.Length - 1);
                    }
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlRecordDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, this.ddltargetdispplayType1.SelectedValue.ToString(), this.lblbar.Text, this.UserID, str3, num3, str4, Convert.ToInt32(this.ddlcompanyName1.SelectedValue), flag, str5, str6, empty10, "", "", "", "", flag1, flag2, "", false,isCalendarYear,"");
                }
                else if (num2 == 13 || num2 == 14)
                {
                    flag = true;
                    bool _isLastYearData = false;
                    bool _isDailyTarget = false;
                    bool _isMonthlyTarget = false;
                    _isLastYearData = (!this.chkIsLastYearData.Checked ? false : true);
                    _isDailyTarget = (!this.chkIsDailyTarget.Checked ? false : true);
                    _isMonthlyTarget = (!this.chkIsMonthlyTarget.Checked ? false : true);
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType.SelectedItem.Text, this.UserID, str3, num3, str4, num4, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false, isCalendarYear, "", _isLastYearData,_isDailyTarget,_isMonthlyTarget);
                }
                else if (num2 == 15)
                {
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlAccountingCodeDaterange.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, "Pie", this.UserID, str3, num3, str4, num4, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false, isCalendarYear, "");
                }
                else if (num2 != 1)
                {
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType.SelectedItem.Text, this.UserID, str3, num3, str4, num4, flag, str5, str6, "0", "", "", "", "", flag1, flag2, "", false,isCalendarYear,"");
                }
                else
                {
                    string empty11 = string.Empty;
                    if (this.ddlModuleName.SelectedValue == "Estimates")
                    {
                        int count11 = this.ddlStatusEstimate.CheckedItems.Count;
                        for (int b = 0; b < this.ddlStatusEstimate.Items.Count; b++)
                        {
                            if (this.ddlStatusEstimate.Items[b].Checked && this.ddlStatusEstimate.Items[b].Value != "-1")
                            {
                                empty11 = string.Concat(empty11, this.ddlStatusEstimate.Items[b].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Invoice")
                    {
                        int num11 = this.ddlStatusInvoice.CheckedItems.Count;
                        for (int c = 0; c < this.ddlStatusInvoice.Items.Count; c++)
                        {
                            if (this.ddlStatusInvoice.Items[c].Checked && this.ddlStatusInvoice.Items[c].Value != "-1")
                            {
                                empty11 = string.Concat(empty11, this.ddlStatusInvoice.Items[c].Value, ",");
                            }
                        }
                    }
                    else if (this.ddlModuleName.SelectedValue == "Jobs")
                    {
                        int count12 = this.ddlStatusJob.CheckedItems.Count;
                        for (int d = 0; d < this.ddlStatusJob.Items.Count; d++)
                        {
                            if (this.ddlStatusJob.Items[d].Checked && this.ddlStatusJob.Items[d].Value != "-1")
                            {
                                empty11 = string.Concat(empty11, this.ddlStatusJob.Items[d].Value, ",");
                            }
                        }
                    }
                    empty11 = (empty11 == "" ? "-1" : empty11.Substring(0, empty11.Length - 1));
                    bool flag8 = false;
                    flag8 = (!this.chkArchiverecords.Checked ? false : true);
                    SettingsBasePage.Settings_Update_CopyWidgets(num, this.CompanyID, this.UserID, str, Convert.ToInt32(this.ddlDefaultDate.SelectedValue), num5, this.ReplaceSpecialEncode(this.txtTitle.Text), str2, str1, this.ddlGraphType.SelectedItem.Text, this.UserID, this.ddlModuleName.SelectedValue, num3, str4, num4, flag, str5, str6, "0", "", strFromDate, strTodate, "", flag1, flag2, empty11, flag8,isCalendarYear,this.ddldate.SelectedValue);
                }
                this.GetUseDock();
                this.GetUseDockMini();
                this.Session["Update"] = "Update";
                base.Response.Redirect(base.Request.Url.ToString());
            }
            catch
            {
            }
        }

        public void btnUpdateDockPogitions_Click(object sender, EventArgs e)
        {
            dashboardestimate.Dashboard_Widget_Delete(Convert.ToInt32(this.Session["UserID"]));
            if (this.hdnLeftZoneIds.Value != null)
            {
                string[] strArrays = this.hdnLeftZoneIds.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '\u005E' });
                    string[] strArrays2 = strArrays1[0].Split(new char[] { '\u005F' });
                    int num = 0;
                    long num1 = (long)0;
                    if ((int)strArrays1.Length > 1 && strArrays1[1].ToString() != "")
                    {
                        num = Convert.ToInt32(strArrays1[1].ToString());
                    }
                    if ((int)strArrays2.Length > 2 && strArrays2[2].ToString() != "")
                    {
                        string str = strArrays2[4].ToString().Replace("RadDock", "");
                        num1 = (long)Convert.ToInt32(str);
                    }
                    dashboardestimate.Dashboard_Widget_Update(Convert.ToInt64(this.Session["UserID"]), strArrays[i].ToString(), num1, "", num);
                }
            }
            if (this.hdnRightZoneIds.Value != null)
            {
                string[] strArrays3 = this.hdnRightZoneIds.Value.Split(new char[] { ',' });
                for (int j = 0; j < (int)strArrays3.Length - 1; j++)
                {
                    string[] strArrays4 = strArrays3[j].Split(new char[] { '\u005E' });
                    string[] strArrays5 = strArrays4[0].Split(new char[] { '\u005F' });
                    int num2 = 0;
                    long num3 = (long)0;
                    if ((int)strArrays4.Length > 1 && strArrays4[1].ToString() != "")
                    {
                        num2 = Convert.ToInt32(strArrays4[1].ToString());
                    }
                    if ((int)strArrays5.Length > 2 && strArrays5[2].ToString() != "")
                    {
                        string str1 = strArrays5[4].ToString().Replace("RadDock", "");
                        num3 = (long)Convert.ToInt32(str1);
                    }
                    dashboardestimate.Dashboard_Widget_Update(Convert.ToInt64(this.Session["UserID"]), strArrays3[j].ToString(), num3, "", num2);
                }
            }
            this.hdnLeftZoneIds.Value = "";
            this.hdnRightZoneIds.Value = "";
            this.Session["SaveLayout"] = "Saved";
            this.GetUseDock();
            this.GetUseDockMini();
        }

        protected void btnUpdateDockPogitionsMini_Click(object sender, EventArgs e)
        {
            dashboardestimate.Dashboard_MiniWidget_Delete(Convert.ToInt32(this.Session["UserID"]));
            if (this.hdnLeftZoneIdsMini.Value != null)
            {
                string[] strArrays = this.hdnLeftZoneIdsMini.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '\u005E' });
                    string[] strArrays2 = strArrays1[0].Split(new char[] { '\u005F' });
                    int num = 0;
                    long num1 = (long)0;
                    if ((int)strArrays1.Length > 1 && strArrays1[1].ToString() != "")
                    {
                        num = Convert.ToInt32(strArrays1[1].ToString());
                    }
                    if ((int)strArrays2.Length > 2 && strArrays2[2].ToString() != "")
                    {
                        string str = strArrays2[4].ToString().Replace("RadDockUseMini", "");
                        num1 = (long)Convert.ToInt32(str);
                    }
                    dashboardestimate.Dashboard_MiniWidget_Update(Convert.ToInt64(this.Session["UserID"]), strArrays[i].ToString(), num1, "", num);
                }
            }
            if (this.hdnRightZoneIdsMini.Value != null)
            {
                string[] strArrays3 = this.hdnRightZoneIdsMini.Value.Split(new char[] { ',' });
                for (int j = 0; j < (int)strArrays3.Length - 1; j++)
                {
                    string[] strArrays4 = strArrays3[j].Split(new char[] { '\u005E' });
                    string[] strArrays5 = strArrays4[0].Split(new char[] { '\u005F' });
                    int num2 = 0;
                    long num3 = (long)0;
                    if ((int)strArrays4.Length > 1 && strArrays4[1].ToString() != "")
                    {
                        num2 = Convert.ToInt32(strArrays4[1].ToString());
                    }
                    if ((int)strArrays5.Length > 2 && strArrays5[2].ToString() != "")
                    {
                        string str1 = strArrays5[4].ToString().Replace("RadDockUseMini", "");
                        num3 = (long)Convert.ToInt32(str1);
                    }
                    dashboardestimate.Dashboard_MiniWidget_Update(Convert.ToInt64(this.Session["UserID"]), strArrays3[j].ToString(), num3, "", num2);
                }
            }
            this.hdnLeftZoneIdsMini.Value = "";
            this.hdnRightZoneIdsMini.Value = "";
            this.Session["SaveLayoutMini"] = "Saved";
            this.GetUseDockMini();
            this.GetUseDock();
        }

        protected void btnUpdateMini_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.chkIncludeArchivedRecordMini.Checked)
            {
                flag = true;
            }
            bool flag1 = false;
            if (this.ChkDisplayWidgetMini.Checked)
            {
                flag1 = true;
            }

            string isCalendarYear = "1";
            if (this.financialYear.Checked == true)
            {
                isCalendarYear = "0";
            }

            //string[] strArrays1 = this.txtFromDateNew.Text.Split('/');
            //string frmDate = strArrays1[1] + "/" + strArrays1[0] + "/" + strArrays1[2];

            //string[] strArrays2 = this.txtToDate.Text.Split('/');
            //string toDate = strArrays2[1] + "/" + strArrays2[0] + "/" + strArrays2[2];

            string strFromDate = "01/01/1900";
            string strTodate = "12/31/2100";

            if (this.txtFromDateNew.Text.Length > 0)
            {
                strFromDate = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtFromDateNew.Text);
            }
            if (this.txtToDate.Text.Length > 0)
            {
                strTodate = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtToDate.Text);
            }
            MonthlyTarget monthlyTarget = new MonthlyTarget();
            monthlyTarget.MonthlyTarget1 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget1.Value) ? "0" : this.MonthlyTarget1.Value);
            monthlyTarget.MonthlyTarget2 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget2.Value) ? "0" : this.MonthlyTarget2.Value);
            monthlyTarget.MonthlyTarget3 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget3.Value) ? "0" : this.MonthlyTarget3.Value);
            monthlyTarget.MonthlyTarget4 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget4.Value) ? "0" : this.MonthlyTarget4.Value);
            monthlyTarget.MonthlyTarget5 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget5.Value) ? "0" : this.MonthlyTarget5.Value);
            monthlyTarget.MonthlyTarget6 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget6.Value) ? "0" : this.MonthlyTarget6.Value);
            monthlyTarget.MonthlyTarget7 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget7.Value) ? "0" : this.MonthlyTarget7.Value);
            monthlyTarget.MonthlyTarget8 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget8.Value) ? "0" : this.MonthlyTarget8.Value);
            monthlyTarget.MonthlyTarget9 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget9.Value) ? "0" : this.MonthlyTarget9.Value);
            monthlyTarget.MonthlyTarget10 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget10.Value) ? "0" : this.MonthlyTarget10.Value);
            monthlyTarget.MonthlyTarget11 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget11.Value) ? "0" : this.MonthlyTarget11.Value);
            monthlyTarget.MonthlyTarget12 = Convert.ToDecimal(string.IsNullOrEmpty(this.MonthlyTarget12.Value) ? "0" : this.MonthlyTarget12.Value);

            DailyTarget dailyTarget = new DailyTarget();
            dailyTarget.DailyTarget1 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget1.Value) ? "0" : this.DailyTarget1.Value);
            dailyTarget.DailyTarget2 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget2.Value) ? "0" : this.DailyTarget2.Value);
            dailyTarget.DailyTarget3 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget3.Value) ? "0" : this.DailyTarget3.Value);
            dailyTarget.DailyTarget4 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget4.Value) ? "0" : this.DailyTarget4.Value);
            dailyTarget.DailyTarget5 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget5.Value) ? "0" : this.DailyTarget5.Value);
            dailyTarget.DailyTarget6 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget6.Value) ? "0" : this.DailyTarget6.Value);
            dailyTarget.DailyTarget7 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget7.Value) ? "0" : this.DailyTarget7.Value);
            dailyTarget.DailyTarget8 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget8.Value) ? "0" : this.DailyTarget8.Value);
            dailyTarget.DailyTarget9 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget9.Value) ? "0" : this.DailyTarget9.Value);
            dailyTarget.DailyTarget10 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget10.Value) ? "0" : this.DailyTarget10.Value);
            dailyTarget.DailyTarget11 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget11.Value) ? "0" : this.DailyTarget11.Value);
            dailyTarget.DailyTarget12 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget12.Value) ? "0" : this.DailyTarget12.Value);
            dailyTarget.DailyTarget13 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget13.Value) ? "0" : this.DailyTarget13.Value);
            dailyTarget.DailyTarget14 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget14.Value) ? "0" : this.DailyTarget14.Value);
            dailyTarget.DailyTarget15 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget15.Value) ? "0" : this.DailyTarget15.Value);
            dailyTarget.DailyTarget16 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget16.Value) ? "0" : this.DailyTarget16.Value);
            dailyTarget.DailyTarget17 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget17.Value) ? "0" : this.DailyTarget17.Value);
            dailyTarget.DailyTarget18 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget18.Value) ? "0" : this.DailyTarget18.Value);
            dailyTarget.DailyTarget19 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget19.Value) ? "0" : this.DailyTarget19.Value);
            dailyTarget.DailyTarget20 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget20.Value) ? "0" : this.DailyTarget20.Value);
            dailyTarget.DailyTarget21 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget21.Value) ? "0" : this.DailyTarget21.Value);
            dailyTarget.DailyTarget22 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget22.Value) ? "0" : this.DailyTarget22.Value);
            dailyTarget.DailyTarget23 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget23.Value) ? "0" : this.DailyTarget23.Value);
            dailyTarget.DailyTarget24 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget24.Value) ? "0" : this.DailyTarget24.Value);
            dailyTarget.DailyTarget25 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget25.Value) ? "0" : this.DailyTarget25.Value);
            dailyTarget.DailyTarget26 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget26.Value) ? "0" : this.DailyTarget26.Value);
            dailyTarget.DailyTarget27 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget27.Value) ? "0" : this.DailyTarget27.Value);
            dailyTarget.DailyTarget28 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget28.Value) ? "0" : this.DailyTarget28.Value);
            dailyTarget.DailyTarget29 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget29.Value) ? "0" : this.DailyTarget29.Value);
            dailyTarget.DailyTarget30 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget30.Value) ? "0" : this.DailyTarget30.Value);
            dailyTarget.DailyTarget31 = Convert.ToDecimal(string.IsNullOrEmpty(this.DailyTarget31.Value) ? "0" : this.DailyTarget31.Value);
            SettingsBasePage.Settings_Update_CopyWidgets(Convert.ToInt64(this.hdnIDMini.Value), Convert.ToInt64(this.hdnMasterIDMini.Value), Convert.ToInt64(this.CompanyID), this.ddlUserMini.SelectedValue, this.ddlDateTypeMiniNew.SelectedValue, Convert.ToBoolean(flag), Convert.ToBoolean(flag1), this.hdn_selectedcolorMini.Value, this.txtTitleMini.Text, isCalendarYear, strFromDate, strTodate,dailyTarget, monthlyTarget);
            //if (this.hdnMasterIDMini.Value != "10")
            //{
            //    SettingsBasePage.Settings_Update_CopyWidgets(Convert.ToInt64(this.hdnIDMini.Value), Convert.ToInt64(this.hdnMasterIDMini.Value), Convert.ToInt64(this.CompanyID), this.ddlUserMini.SelectedValue, this.ddlDateTypeMini.SelectedValue, Convert.ToBoolean(flag), Convert.ToBoolean(flag1), this.hdn_selectedcolorMini.Value, this.txtTitleMini.Text, isCalendarYear, strFromDate, strTodate);
            //}
            //else
            //{
            //    SettingsBasePage.Settings_Update_CopyWidgets(Convert.ToInt64(this.hdnIDMini.Value), Convert.ToInt64(this.hdnMasterIDMini.Value), Convert.ToInt64(this.CompanyID), this.ddlUserMini.SelectedValue, this.ddlDateTypeMiniNew.SelectedValue, Convert.ToBoolean(flag), Convert.ToBoolean(flag1), this.hdn_selectedcolorMini.Value, this.txtTitleMini.Text, isCalendarYear, strFromDate, strTodate);
            //}
            this.GetUseDockMini();
            this.GetUseDock();
            this.Session["Update"] = "Update";
            this.lblNoWidgetsMINI.Style.Add("display", "none");
            if (this.Session["Update"] != null && this.Session["Update"].ToString() != "")
            {
                this.divmsgMINI.Style.Add("display", "block");
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_Updated_Successfully"), "msg-success", this.plhMessageMINI);
                this.Session["Update"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghideUSeMini();", true);
            }
            this.GetMasterDockMini();
            this.GetMasterDock();
        }

        private RadDock CreateRadDock()
        {
            DataSet dataSet = SettingsBasePage.Settings_Select_MasterWidgets();
            int num = Convert.ToInt32(dataSet.Tables[0].Rows[this.j]["MasterID"]);
            RadDock radDock = new RadDock()
            {
                DockMode = DockMode.Docked
            };
            Guid guid = Guid.NewGuid();
            radDock.UniqueName = guid.ToString().Replace("-", "a");
            radDock.ID = string.Concat("RadDock", num);
            this.DockID = radDock.ID;
            radDock.Title = dataSet.Tables[0].Rows[this.j]["TitleName"].ToString();
            radDock.ToolTip = dataSet.Tables[0].Rows[this.j]["TitleName"].ToString();
            radDock.Skin = "Default";
            radDock.EnableRoundedCorners = true;
            radDock.Style.Add("padding-bottom", "7px");
            radDock.Style.Add("padding-top", "7px");
            radDock.DefaultCommands = DefaultCommands.None;
            radDock.OnClientInitialize = "OnClientInitialize";
            radDock.TitlebarContainer.Style.Add(HtmlTextWriterStyle.Overflow, "hidden");
            Label label = new Label();
            string str = "";
            str = (dataSet.Tables[0].Rows[this.j]["WidgetName"].ToString().Length <= 100 ? dataSet.Tables[0].Rows[this.j]["WidgetName"].ToString() : string.Concat(dataSet.Tables[0].Rows[this.j]["WidgetName"].ToString().Substring(0, 100), "..."));
            label.Text = str;
            label.ToolTip = dataSet.Tables[0].Rows[this.j]["WidgetName"].ToString();
            label.Height = Unit.Pixel(23);
            label.Style.Add("margin-top", "3px");
            label.Style.Add("float", "left");
            label.Style.Add("font-size", "11px");
            label.Style.Add("margin-bottom", "10px");
            LinkButton linkButton = new LinkButton()
            {
                Text = this.objLanguage.GetLanguageConversion("Use"),
                ToolTip = this.objLanguage.GetLanguageConversion("Use"),
                ID = string.Concat("use", num)
            };
            linkButton.Font.Underline = true;
            string d = linkButton.ID;
            linkButton.CommandArgument = dataSet.Tables[0].Rows[this.j]["MasterID"].ToString();
            linkButton.Click += new EventHandler(this.lnkuse_Click);
            linkButton.OnClientClick = string.Concat("javascript:return UseClick(", num, ");");
            linkButton.ForeColor = Color.CornflowerBlue;
            linkButton.Height = Unit.Pixel(20);
            HiddenField hiddenField = this.hdnMastervalues;
            string[] strArrays = new string[] { dataSet.Tables[0].Rows[this.j]["NoOfRecords"].ToString(), "$", dataSet.Tables[0].Rows[this.j]["CustomizeColumns"].ToString(), "$", dataSet.Tables[0].Rows[this.j]["CustomerID"].ToString(), "$", dataSet.Tables[0].Rows[this.j]["IsSpreadOverTwoColumns"].ToString(), "$", dataSet.Tables[0].Rows[this.j]["TaskStatus"].ToString(), "$", dataSet.Tables[0].Rows[this.j]["CompanyType"].ToString() };
            hiddenField.Value = string.Concat(strArrays);
            LinkButton cornflowerBlue = new LinkButton()
            {
                ID = string.Concat("lnkcustomize", num),
                Text = this.objLanguage.GetLanguageConversion("Customize"),
                ToolTip = this.objLanguage.GetLanguageConversion("Customize")
            };
            cornflowerBlue.Style.Add("padding-left", "50px");
            cornflowerBlue.Font.Underline = true;
            cornflowerBlue.CommandArgument = dataSet.Tables[0].Rows[this.j]["MasterID"].ToString();
            object[] objArray = new object[] { "javascript:OpencustomizeWindow('", num, "','", dataSet.Tables[0].Rows[this.j]["GraphType"].ToString(), "','", dataSet.Tables[0].Rows[this.j]["DefaultDate"].ToString(), "','", this.hdnMastervalues.Value, "','", dataSet.Tables[0].Rows[this.j]["WidgetName"].ToString(), "'); return false;" };
            cornflowerBlue.OnClientClick = string.Concat(objArray);
            cornflowerBlue.ForeColor = Color.CornflowerBlue;
            cornflowerBlue.Style.Add("margin-top", "20px");
            Table table = new Table()
            {
                ID = string.Concat("Table", num)
            };
            TableRow tableRow = new TableRow();
            TableCell tableCell = new TableCell();
            TableCell tableCell1 = new TableCell();
            TableRow tableRow1 = new TableRow();
            table.Controls.Add(tableRow);
            tableRow.Controls.Add(tableCell);
            tableCell.Controls.Add(label);
            table.Controls.Add(tableRow1);
            tableRow1.Controls.Add(tableCell1);
            tableCell1.Controls.Add(linkButton);
            tableCell1.Controls.Add(cornflowerBlue);
            radDock.ContentContainer.Controls.Add(table);
            return radDock;
        }

        private RadDock CreateRadDockMini()
        {
            DataSet dataSet = SettingsBasePage.Settings_Select_MiniMasterWidgets();
            int num = Convert.ToInt32(dataSet.Tables[0].Rows[this.jMini]["MasterID"]);
            RadDock radDock = new RadDock()
            {
                DockMode = DockMode.Docked
            };
            Guid guid = Guid.NewGuid();
            radDock.UniqueName = guid.ToString().Replace("-", "a");
            radDock.ID = string.Concat("RadDockMini", num);
            this.DockID = radDock.ID;
            radDock.Title = dataSet.Tables[0].Rows[this.jMini]["WidgetName"].ToString();
            radDock.ToolTip = dataSet.Tables[0].Rows[this.jMini]["WidgetName"].ToString();
            radDock.Skin = "Default";
            radDock.EnableRoundedCorners = true;
            radDock.Style.Add("padding-bottom", "7px");
            radDock.Style.Add("padding-top", "7px");
            radDock.DefaultCommands = DefaultCommands.None;
            radDock.OnClientInitialize = "OnClientInitialize";
            radDock.TitlebarContainer.Style.Add(HtmlTextWriterStyle.Overflow, "hidden");
            Label label = new Label();
            string str = "";
            str = (dataSet.Tables[0].Rows[this.jMini]["WidgetName"].ToString().Length <= 100 ? dataSet.Tables[0].Rows[this.jMini]["WidgetName"].ToString() : string.Concat(dataSet.Tables[0].Rows[this.jMini]["WidgetName"].ToString().Substring(0, 100), "..."));
            label.Text = str;
            label.ToolTip = dataSet.Tables[0].Rows[this.jMini]["WidgetName"].ToString();
            label.Height = Unit.Pixel(23);
            label.Style.Add("margin-top", "3px");
            label.Style.Add("float", "left");
            label.Style.Add("font-size", "11px");
            label.Style.Add("margin-bottom", "10px");
            LinkButton linkButton = new LinkButton()
            {
                Text = this.objLanguage.GetLanguageConversion("Use"),
                ToolTip = this.objLanguage.GetLanguageConversion("Use"),
                ID = string.Concat("use", num)
            };
            linkButton.Font.Underline = true;
            string d = linkButton.ID;
            linkButton.CommandArgument = dataSet.Tables[0].Rows[this.jMini]["MasterID"].ToString();
            linkButton.Click += new EventHandler(this.lnkuseMini_Click);
            linkButton.OnClientClick = string.Concat("javascript:return UseClickMini(", num, ");");
            linkButton.ForeColor = Color.CornflowerBlue;
            linkButton.Height = Unit.Pixel(20);
            LinkButton cornflowerBlue = new LinkButton()
            {
                ID = string.Concat("lnkcustomizeMini", num),
                Text = this.objLanguage.GetLanguageConversion("Customize"),
                ToolTip = this.objLanguage.GetLanguageConversion("Customize")
            };
            cornflowerBlue.Style.Add("padding-left", "50px");
            cornflowerBlue.Font.Underline = true;
            cornflowerBlue.CommandArgument = dataSet.Tables[0].Rows[this.jMini]["MasterID"].ToString();
            object[] objArray = new object[] { "javascript:OpencustomizeWindowMini('", num, "','", dataSet.Tables[0].Rows[this.jMini]["DateType"].ToString(), "','", dataSet.Tables[0].Rows[this.jMini]["IncludeArchiverecords"].ToString(), "','", dataSet.Tables[0].Rows[this.jMini]["IsDisplayWidget"].ToString(), "','", dataSet.Tables[0].Rows[this.jMini]["Color"].ToString(), "','", dataSet.Tables[0].Rows[this.jMini]["Title"].ToString(), "'); return false;" };
            cornflowerBlue.OnClientClick = string.Concat(objArray);
            cornflowerBlue.ForeColor = Color.CornflowerBlue;
            cornflowerBlue.Style.Add("margin-top", "20px");
            Table table = new Table()
            {
                ID = string.Concat("TableMini", num)
            };
            TableRow tableRow = new TableRow();
            TableCell tableCell = new TableCell();
            TableCell tableCell1 = new TableCell();
            TableRow tableRow1 = new TableRow();
            table.Controls.Add(tableRow);
            tableRow.Controls.Add(tableCell);
            tableCell.Controls.Add(label);
            table.Controls.Add(tableRow1);
            tableRow1.Controls.Add(tableCell1);
            tableCell1.Controls.Add(linkButton);
            tableCell1.Controls.Add(cornflowerBlue);
            radDock.ContentContainer.Controls.Add(table);
            return radDock;
        }

        protected void ddlCustomers_DataBound(object sender, EventArgs e)
        {
            foreach (ListItem item in this.ddlCustomers.Items)
            {
                item.Text = this.ReplaceSpecialDecode(item.Text);
            }
        }

        public void EstimatesTypesfromDwebconfig()
        {
            try
            {
                int num = 0;
                this.ddlEstimateType.Items.Insert(num, "All");
                this.ddlEstimateType.Items[num].Value = "All";
                num++;
                if (ConnectionClass.SheetFedDigital != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.SheetFedDigital);
                    this.ddlEstimateType.Items[num].Value = "sfd";
                    num++;
                }
                if (ConnectionClass.DigitalSingleItem != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.DigitalSingleItem);
                    this.ddlEstimateType.Items[num].Value = "S";
                    this.ddlEstimateType.Items[num].Selected = true;
                    num++;
                }
                if (ConnectionClass.DigitalBooklet != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.DigitalBooklet);
                    this.ddlEstimateType.Items[num].Value = "B";
                    num++;
                }
                if (ConnectionClass.DigitalPads != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.DigitalPads);
                    this.ddlEstimateType.Items[num].Value = "P";
                    num++;
                }
                if (ConnectionClass.SheetFedOffset != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.SheetFedOffset);
                    this.ddlEstimateType.Items[num].Value = "sfo";
                    num++;
                }
                if (ConnectionClass.OffsetSingleItem != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.OffsetSingleItem);
                    this.ddlEstimateType.Items[num].Value = "F";
                    num++;
                }
                if (ConnectionClass.OffsetPad != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.OffsetPad);
                    this.ddlEstimateType.Items[num].Value = "D";
                    num++;
                }
                if (ConnectionClass.OffsetNCR != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.OffsetNCR);
                    this.ddlEstimateType.Items[num].Value = "N";
                    num++;
                }
                if (ConnectionClass.OffsetBooklet != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.OffsetBooklet);
                    this.ddlEstimateType.Items[num].Value = "K";
                    num++;
                }
                if (ConnectionClass.LargeFormat != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.LargeFormat);
                    this.ddlEstimateType.Items[num].Value = "L";
                    num++;
                }
                if (ConnectionClass.PrintBroker != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.PrintBroker);
                    this.ddlEstimateType.Items[num].Value = "O";
                    num++;
                }
                if (ConnectionClass.Warehouse != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.Warehouse);
                    this.ddlEstimateType.Items[num].Value = "W";
                    num++;
                }
                if (ConnectionClass.OtherCosts != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.OtherCosts);
                    this.ddlEstimateType.Items[num].Value = "U";
                    num++;
                }
                if (ConnectionClass.PriceCatalogue != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.PriceCatalogue);
                    this.ddlEstimateType.Items[num].Value = "C";
                    num++;
                }
                if (ConnectionClass.QuickQuote != null)
                {
                    this.ddlEstimateType.Items.Insert(num, ConnectionClass.QuickQuote);
                    this.ddlEstimateType.Items[num].Value = "Q";
                    num++;
                }
            }
            catch
            {
            }
        }

        public void GetCustomers()
        {
            DataTable dataTable = SettingsBasePage.CRM_Customers_SelectForDashboard(Convert.ToInt64(this.Session["CompanyID"]), "latestnotesofCustomerandProspect");
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        column.ReadOnly = false;
                    }
                    row["ClientName"] = this.objbase.SpecialDecode(row["ClientName"].ToString());
                }
                this.ddlCustomers.DataSource = dataTable;
                this.ddlCustomers.DataValueField = "ClientID";
                this.ddlCustomers.DataTextField = "ClientName";
                this.ddlCustomers.DataBind();
                this.ddlcompanyName1.DataSource = dataTable;
                this.ddlcompanyName1.DataTextField = "ClientName";
                this.ddlcompanyName1.DataValueField = "ClientID";
                this.ddlcompanyName1.DataBind();
            }
        }

        public void GetMasterDock()
        {
            this.RadDockZone4.Controls.Clear();
            this.RadDockZone5.Controls.Clear();
            bool flag = false;
            DataTable dataTable = CompanyBasePage.Select_Isadmin(this.CompanyID, this.UserID);
            DataSet dataSet = new DataSet();
            foreach (DataRow row in dataTable.Rows)
            {
                flag = Convert.ToBoolean(row["IsAdmin"].ToString());
            }
            dataSet = (!flag ? SettingsBasePage.Settings_Select_MasterWidgetsForUSer() : SettingsBasePage.Settings_Select_MasterWidgets());
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                this.j = i;
                RadDock radDock = this.CreateRadDock();
                radDock.EnableDrag = false;
                if (this.j % 2 != 0)
                {
                    this.RadDockZone5.Controls.Add(radDock);
                }
                else
                {
                    this.RadDockZone4.Controls.Add(radDock);
                }
            }
        }

        public void GetMasterDockMini()
        {
            this.RadDockZone4MINI.Controls.Clear();
            this.RadDockZone5MINI.Controls.Clear();
            DataSet dataSet = new DataSet();
            dataSet = SettingsBasePage.Settings_Select_MiniMasterWidgets();
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                this.jMini = i;
                RadDock radDock = this.CreateRadDockMini();
                radDock.EnableDrag = false;
                if (this.jMini % 2 != 0)
                {
                    this.RadDockZone5MINI.Controls.Add(radDock);
                }
                else
                {
                    this.RadDockZone4MINI.Controls.Add(radDock);
                }
            }
        }

        public RadDock GetUse(DataRow dr, int k)
        {
            DataSet dataSet = SettingsBasePage.Settings_Select_Copywidget_ByUserID(this.UserID);
            RadDock radDock = new RadDock()
            {
                DockMode = DockMode.Docked
            };
            Guid guid = Guid.NewGuid();
            radDock.UniqueName = guid.ToString().Replace("-", "a");
            radDock.ID = string.Concat("RadDockUse", dr["CopyMasterID"].ToString());
            radDock.Title = this.ReplaceSpecialDecode(dr["TitleName"].ToString());
            radDock.ToolTip = this.ReplaceSpecialDecode(dr["TitleName"].ToString());
            radDock.Skin = "Default";
            radDock.EnableRoundedCorners = true;
            radDock.Style.Add("padding-bottom", "7px");
            radDock.Style.Add("padding-top", "7px");
            radDock.DefaultCommands = DefaultCommands.None;
            radDock.OnClientInitialize = "OnClientInitialize";
            radDock.TitlebarContainer.Style.Add(HtmlTextWriterStyle.Overflow, "hidden");
            radDock.OnClientDragEnd = "OnClientDragEndFirst";
            Label label = new Label();
            string str = "";
            str = (dr["TitleName"].ToString().Length <= 95 ? this.objbase.SpecialDecode(dr["TitleName"].ToString()) : string.Concat(this.objbase.SpecialDecode(dr["TitleName"].ToString()).Substring(0, 95), "..."));
            label.Text = str;
            label.ToolTip = this.objbase.SpecialDecode(dr["TitleName"].ToString());
            label.Height = Unit.Pixel(38);
            label.Style.Add("margin-top", "5px");
            label.Style.Add("float", "left");
            label.Style.Add("font-size", "11px");
            bool IsLastYearData = false;
            if(!string.IsNullOrEmpty(dataSet.Tables[0].Rows[k]["IsLastYearData"].ToString()))
            {
                if(dataSet.Tables[0].Rows[k]["IsLastYearData"].ToString().ToLower() == "false")
                {
                    IsLastYearData = false;
                }
                else
                {
                    IsLastYearData = true;
                }
            }
            bool IsDailyTarget = false;
            if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[k]["IsDailyTarget"].ToString()))
            {
                if (dataSet.Tables[0].Rows[k]["IsDailyTarget"].ToString().ToLower() == "false")
                {
                    IsDailyTarget = false;
                }
                else
                {
                    IsDailyTarget = true;
                }
            }
            bool IsMonthlyTarget = false;
            if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[k]["IsMonthlyTarget"].ToString()))
            {
                if (dataSet.Tables[0].Rows[k]["IsMonthlyTarget"].ToString().ToLower() == "false")
                {
                    IsMonthlyTarget = false;
                }
                else
                {
                    IsMonthlyTarget = true;
                }
            }
            ImageButton imageButton = new ImageButton()
            {
                ToolTip = "Edit",
                ImageUrl = "~/images/Edit.gif",
                ID = string.Concat("imgedituse", k),
                Height = Unit.Pixel(12),
                Width = Unit.Pixel(12),
                CommandArgument = dr["CopyMasterID"].ToString()
            };
            this.CopyMasterID = Convert.ToInt32(dr["CopyMasterID"]);
            try
            {
                HiddenField hiddenField = this.hdnCopyMastervalues;
                string[] strArrays = new string[] { dataSet.Tables[0].Rows[k]["NoOfRecords"].ToString(), "$", dataSet.Tables[0].Rows[k]["CustomizeColumns"].ToString(), "$", dataSet.Tables[0].Rows[k]["CustomerID"].ToString(), "$", dataSet.Tables[0].Rows[k]["IsSpreadOverTwoColumns"].ToString(), "$", dataSet.Tables[0].Rows[k]["TaskStatus"].ToString(), "$", dataSet.Tables[0].Rows[k]["CompanyType"].ToString() };
                hiddenField.Value = string.Concat(strArrays);
            }
            catch
            {
            }
            object[] copyMasterID = new object[] { "javascript:CustomizeOptionsPopup('", this.CopyMasterID, "','", dataSet.Tables[0].Rows[k]["GraphType"].ToString(), "','", dataSet.Tables[0].Rows[k]["DefaultDate"].ToString(), "','", dataSet.Tables[0].Rows[k]["TitleName"].ToString(), "','", dataSet.Tables[0].Rows[k]["MasterID"].ToString(), "','", dataSet.Tables[0].Rows[k]["ModuleName"].ToString(), "','", dataSet.Tables[0].Rows[k]["DisplayType"].ToString(), "','", this.hdnCopyMastervalues.Value, "','", dataSet.Tables[0].Rows[k]["DisplayRecordSalesOf"].ToString(), "','", dataSet.Tables[0].Rows[k]["QuarterType"].ToString(), "','", dataSet.Tables[0].Rows[k]["FromDate"].ToString(), "','", dataSet.Tables[0].Rows[k]["Todate"].ToString(), "','", dataSet.Tables[0].Rows[k]["EstimateType"].ToString(), "','", dataSet.Tables[0].Rows[k]["NoOfRecords"].ToString(), "','", dataSet.Tables[0].Rows[k]["CustomerID"].ToString(), "','", dataSet.Tables[0].Rows[k]["ShowPrint"].ToString(), "','", dataSet.Tables[0].Rows[k]["ShowFullScreen"].ToString(), "','", dataSet.Tables[0].Rows[k]["ShowAllOptions"].ToString(), "','", dataSet.Tables[0].Rows[k]["Status"].ToString(), "','", dataSet.Tables[0].Rows[k]["ShowArchivedStatus"].ToString(), "','", dataSet.Tables[0].Rows[k]["IsCalendarYear"].ToString(), "','", dataSet.Tables[0].Rows[k]["DateType"].ToString(), "','", IsLastYearData, "','", IsDailyTarget, "','", IsMonthlyTarget, "'); return false;" };
            imageButton.OnClientClick = string.Concat(copyMasterID);
            ImageButton imageButton1 = new ImageButton()
            {
                ToolTip = "Delete",
                ImageUrl = "~/images/erase.png",
                ID = string.Concat("imgcancel", k),
                Height = Unit.Pixel(12),
                Width = Unit.Pixel(12)
            };
            imageButton1.Style.Add("padding-left", "10px");
            imageButton1.Click += new ImageClickEventHandler(this.imgCancel_Click);
            imageButton1.CommandArgument = dr["CopyMasterID"].ToString();
            imageButton1.OnClientClick = string.Concat("javascript:return UseDelete(", this.CopyMasterID, ");");
            Table table = new Table()
            {
                ID = string.Concat("Table", k),
                Width = Unit.Percentage(100)
            };
            TableRow tableRow = new TableRow();
            TableCell tableCell = new TableCell();
            TableCell tableCell1 = new TableCell();
            tableCell1.Style.Add("float", "right");
            TableRow tableRow1 = new TableRow();
            table.Controls.Add(tableRow);
            tableRow.Controls.Add(tableCell);
            tableCell.Controls.Add(label);
            table.Controls.Add(tableRow1);
            tableRow1.Controls.Add(tableCell1);
            tableCell1.Controls.Add(imageButton);
            tableCell1.Controls.Add(imageButton1);
            radDock.ContentContainer.Controls.Add(table);
            return radDock;
        }

        public void GetUseDock()
        {
            DataSet dataSet = SettingsBasePage.Settings_Select_Copywidget_ByUserID(this.UserID);
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.lblNoWidgets.Style.Add("display", "block");
                this.btnUpdateDockPogitions.Visible = false;
            }
            else
            {
                this.RadDockZone2.Controls.Clear();
                this.RadDockZone3.Controls.Clear();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    RadDock use = this.GetUse(row, this.k);
                    use.ID = string.Concat("RadDock", row["CopyMasterID"].ToString());
                    if (this.j % 2 != 0)
                    {
                        this.RadDockZone3.Controls.Add(use);
                    }
                    else
                    {
                        this.RadDockZone2.Controls.Add(use);
                    }
                    dashboard_settings settingsDashboardSetting = this;
                    settingsDashboardSetting.k = settingsDashboardSetting.k + 1;
                }
            }
            if (this.Session["SaveLayout"] != null && this.Session["SaveLayout"].ToString() != "")
            {
                this.divmsg.Style.Add("display", "block");
                this.objbase.Message_Display("Current Layout Saved Successfully", "msg-success", this.plhMessage);
                this.Session["SaveLayout"] = null;
            }
        }

        public void GetUseDockMini()
        {
            DataSet dataSet = SettingsBasePage.Settings_Select_MiniCopywidget(this.UserID);
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.lblNoWidgetsMINI.Style.Add("display", "block");
                this.btnUpdateDockPogitionsMINI.Visible = false;
            }
            else
            {
                this.RadDockZone2MINI.Controls.Clear();
                this.RadDockZone3MINI.Controls.Clear();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    RadDock useMini = this.GetUseMini(row, this.kMini);
                    useMini.ID = string.Concat("RadDockUseMini", row["ID"].ToString());
                    if (this.jMini % 2 != 0)
                    {
                        this.RadDockZone3MINI.Controls.Add(useMini);
                    }
                    else
                    {
                        this.RadDockZone2MINI.Controls.Add(useMini);
                    }
                    dashboard_settings settingsDashboardSetting = this;
                    settingsDashboardSetting.kMini = settingsDashboardSetting.kMini + 1;
                    this.btnUpdateDockPogitionsMINI.Visible = true;
                }
            }
            if (this.Session["SaveLayoutMini"] != null && this.Session["SaveLayoutMini"].ToString() != "")
            {
                this.divmsgMINI.Style.Add("display", "block");
                this.objbase.Message_Display("Current Layout Saved Successfully", "msg-success", this.plhMessageMINI);
                this.Session["SaveLayoutMini"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghideMini();", true);
            }
        }

        public RadDock GetUseMini(DataRow drMini, int kMini)
        {
            DataSet dataSet = SettingsBasePage.Settings_Select_MiniCopywidget(this.UserID);
            RadDock radDock = new RadDock()
            {
                DockMode = DockMode.Docked
            };
            Guid guid = Guid.NewGuid();
            radDock.UniqueName = guid.ToString().Replace("-", "a");
            radDock.ID = string.Concat("RadDockUseMini", drMini["CopyMasterID"].ToString());
            radDock.Title = this.ReplaceSpecialDecode(drMini["Title"].ToString());
            radDock.ToolTip = this.ReplaceSpecialDecode(drMini["Title"].ToString());
            radDock.Skin = "Default";
            radDock.EnableRoundedCorners = true;
            radDock.Style.Add("padding-bottom", "7px");
            radDock.Style.Add("padding-top", "7px");
            radDock.DefaultCommands = DefaultCommands.None;
            radDock.OnClientInitialize = "OnClientInitialize";
            radDock.TitlebarContainer.Style.Add(HtmlTextWriterStyle.Overflow, "hidden");
            radDock.OnClientDragEnd = "OnClientDragEndMini";
            Label label = new Label();
            string str = "";
            str = (drMini["Title"].ToString().Length <= 95 ? this.objbase.SpecialDecode(drMini["Title"].ToString()) : string.Concat(this.objbase.SpecialDecode(drMini["Title"].ToString()).Substring(0, 95), "..."));
            label.Text = str;
            label.ToolTip = this.objbase.SpecialDecode(drMini["Title"].ToString());
            label.Height = Unit.Pixel(38);
            label.Style.Add("margin-top", "5px");
            label.Style.Add("float", "left");
            label.Style.Add("font-size", "11px");
            ImageButton imageButton = new ImageButton()
            {
                ToolTip = "Edit",
                ImageUrl = "~/images/Edit.gif",
                ID = string.Concat("imgEditMini", kMini),
                Height = Unit.Pixel(12),
                Width = Unit.Pixel(12),
                CommandArgument = drMini["CopyMasterID"].ToString()
            };
            this.CopyMasterID = Convert.ToInt32(drMini["ID"]);
            //ticket 111252 
            string[] strArrays = new string[] { "javascript:CustomizeOptionsPopupMini('", dataSet.Tables[0].Rows[kMini]["CopyMasterID"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DateType"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["IncludeArchiverecords"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["IsDisplayWidget"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["Color"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["Title"].ToString().Replace("'", "&#39;"), "','", dataSet.Tables[0].Rows[kMini]["UserID"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["ID"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["IsCalendarYear"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["FromDate"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["ToDate"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget1"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget2"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget3"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget4"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget5"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget6"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget7"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget8"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget9"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget10"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget11"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["MonthlyTarget12"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget1"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget2"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget3"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget4"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget5"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget6"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget7"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget8"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget9"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget10"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget11"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget12"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget13"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget14"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget15"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget16"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget17"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget18"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget19"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget20"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget21"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget22"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget23"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget24"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget25"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget26"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget27"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget28"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget29"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget30"].ToString(), "','", dataSet.Tables[0].Rows[kMini]["DailyTarget31"].ToString(), "'); return false;" };
            imageButton.OnClientClick = string.Concat(strArrays);
            ImageButton imageButton1 = new ImageButton()
            {
                ToolTip = "Delete",
                ImageUrl = "~/images/erase.png",
                ID = string.Concat("imgCancelMini", kMini),
                Height = Unit.Pixel(12),
                Width = Unit.Pixel(12)
            };
            imageButton1.Style.Add("padding-left", "10px");
            imageButton1.Click += new ImageClickEventHandler(this.imgCancelMini_Click);
            imageButton1.CommandArgument = drMini["CopyMasterID"].ToString();
            imageButton1.OnClientClick = string.Concat("javascript:return UseDeleteMini(", this.CopyMasterID, ");");
            Table table = new Table()
            {
                ID = string.Concat("TableMini", kMini),
                Width = Unit.Percentage(100)
            };
            TableRow tableRow = new TableRow();
            TableCell tableCell = new TableCell();
            TableCell tableCell1 = new TableCell();
            tableCell1.Style.Add("float", "right");
            TableRow tableRow1 = new TableRow();
            table.Controls.Add(tableRow);
            tableRow.Controls.Add(tableCell);
            tableCell.Controls.Add(label);
            table.Controls.Add(tableRow1);
            tableRow1.Controls.Add(tableCell1);
            tableCell1.Controls.Add(imageButton);
            tableCell1.Controls.Add(imageButton1);
            radDock.ContentContainer.Controls.Add(table);
            return radDock;
        }

        public void imgCancel_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsBasePage.Settings_CopyWidget_delete(Convert.ToInt32(this.hdnCopyMasterID.Value), this.CompanyID);
                this.Session["Delete"] = "Delete";
                this.GetMasterDock();
                this.GetUseDock();
                this.GetMasterDockMini();
                this.GetUseDockMini();
                this.divLoadingImageCus.Style.Add("display", "none");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghide();", true);
            }
            catch
            {
            }
        }

        public void imgCancelMini_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsBasePage.Settings_MiniCopyWidget_delete(Convert.ToInt32(this.hdnIDMini.Value), this.CompanyID);
                this.Session["DeleteMini"] = "Delete";
                this.GetMasterDockMini();
                this.GetUseDockMini();
                this.GetMasterDock();
                this.GetUseDock();
                this.divLoadingImageCus.Style.Add("display", "none");
                if (this.Session["DeleteMini"] != null && this.Session["DeleteMini"].ToString() != "")
                {
                    this.divmsgMINI.Style.Add("display", "block");
                    this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_deleted_Successfully"), "msg-success", this.plhMessageMINI);
                    this.Session["DeleteMini"] = null;
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghideMini();", true);
                }
            }
            catch
            {
            }
        }

        public void lnkuse_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int num = Convert.ToInt32(this.hdnMasterID.Value);
            DataSet dataSet = SettingsBasePage.Settings_MasterWidget_Select_ByMasterID(num);
            string str = dataSet.Tables[0].Rows[0]["WidgetType"].ToString();
            int num1 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DefaultDate"]);
            Convert.ToInt32(dataSet.Tables[0].Rows[0]["ShowPrint"]);
            string str1 = dataSet.Tables[0].Rows[0]["TitleName"].ToString();
            string str2 = dataSet.Tables[0].Rows[0]["DisplayType"].ToString();
            string str3 = dataSet.Tables[0].Rows[0]["GraphType"].ToString();
            string str4 = dataSet.Tables[0].Rows[0]["WidgetName"].ToString();
            string str5 = dataSet.Tables[0].Rows[0]["ModuleName"].ToString();
            int num2 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["NoOfRecords"].ToString());
            string str6 = dataSet.Tables[0].Rows[0]["CustomizeColumns"].ToString();
            int num3 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CustomerID"].ToString());
            bool flag = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsSpreadOverTwoColumns"].ToString());
            string str7 = dataSet.Tables[0].Rows[0]["TaskStatus"].ToString();
            string str8 = dataSet.Tables[0].Rows[0]["CompanyType"].ToString();
            bool flag1 = false;
            bool flag2 = false;
            if (num == 4 || num == 11)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, str6, num3, flag, str7, str8, "-1", "Q1-2014", "", "", "All", flag1, flag2, "", false);
            }
            else if (num == 9)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, this.ddlRecordsTypes.SelectedValue, num2, str6, num3, flag, str7, str8, "-1", "Q1-2014", "", "", "All", flag1, flag2, "-1", false);
            }
            else if (num == 10)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, str6, num3, flag, str7, str8, "-1", "Q1-2014", "", "", "All", flag1, flag2, "-1", false);
            }
            else if (num == 2)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, str6, num3, flag, str7, str8, "-1", "Q1-2014", "", "", "All", flag1, flag2, "-1", false);
            }
            else if (num == 8)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, str6, num3, flag, str7, str8, "-1", "Q1-2014", "", "", "All", flag1, flag2, "-1", false);
            }
            else if (num == 12)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, str6, num3, flag, str7, str8, "-1", "Q1-2014", "", "", "All", flag1, flag2, "", false);
            }
            else if (num == 1)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, str6, num3, flag, str7, str8, "0", "Q1-2014", "", "", "All", flag1, flag2, "-1", false);
            }
            else if (num == 3)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, str6, num3, flag, str7, str8, "0", "Q1-2014", "", "", "All", flag1, flag2, "-1", false);
            }
            else if (num == 7)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, str6, num3, flag, str7, str8, "0", "Q1-2014", "", "", "All", flag1, flag2, "", false);
            }
            else if (num != 5)
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, str6, num3, flag, str7, str8, "0", "Q1-2014", "", "", "All", flag1, flag2, "", false);
            }
            else
            {
                SettingsBasePage.Settings_Insert_CopyWidgets(num, this.CompanyID, this.UserID, str, num1, 1, str1, str4, str2, str3, this.UserID, str5, num2, "Customer Name,Specific to Contact,Note Title,Note Content,Created By,Created On", num3, flag, str7, str8, "0", "Q1-2014", "", "", "All", flag1, flag2, "", false);
            }
            this.GetUseDock();
            this.GetUseDockMini();
            this.Session["Added"] = "Added";
            this.lblNoWidgets.Style.Add("display", "none");
            if (this.Session["Added"] != null && this.Session["Added"].ToString() != "")
            {
                this.divmsg.Style.Add("display", "block");
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_added_Successfully"), "msg-success", this.plhMessage);
                this.Session["Added"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghideUSe();", true);
            }
        }

        public void lnkuseMini_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int num = Convert.ToInt32(this.hdnMasterIDMini.Value);
            DataSet dataSet = SettingsBasePage.Settings_MiniMasterWidget_Select_ByMasterID(num);
            SettingsBasePage.Settings_Insert_CopyWidgets(Convert.ToInt64(num), Convert.ToInt64(this.CompanyID), "-1", dataSet.Tables[0].Rows[0]["DateType"].ToString(), Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IncludeArchiverecords"]), Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsDisplayWidget"]), dataSet.Tables[0].Rows[0]["Color"].ToString(), dataSet.Tables[0].Rows[0]["Title"].ToString(), Convert.ToInt64(this.UserID), "", "", "");
            this.GetUseDockMini();
            this.GetUseDock();
            this.Session["AddedMini"] = "Added";
            this.lblNoWidgetsMINI.Style.Add("display", "none");
            if (this.Session["AddedMini"] != null && this.Session["AddedMini"].ToString() != "")
            {
                this.divmsgMINI.Style.Add("display", "block");
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_added_Successfully"), "msg-success", this.plhMessageMINI);
                this.Session["AddedMini"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghideUSeMini();", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblStatus.Text = this.objlang.GetLanguageConversion("Status");
            this.lblShowArchiverecords.Text = this.objlang.GetLanguageConversion("Show_Archived_Records");
            this.Label11.Text = this.objlang.GetLanguageConversion("Record_Date");
            this.lblsalper.Text = this.objlang.GetLanguageConversion("Sales_Person");
            this.Label1.Text = this.objlang.GetLanguageConversion("Record_Type");
            this.lblRetype.Text = this.objlang.GetLanguageConversion("Record_Type");
            this.lblSalesOf.Text = this.objlang.GetLanguageConversion("Sales_Person");
            this.lblQuarterType.Text = this.objlang.GetLanguageConversion("Select_Quarter");
            this.lblDateRange.Text = this.objlang.GetLanguageConversion("Date_Range");
            this.lblfrom.Text = this.objlang.GetLanguageConversion("From");
            this.lblto.Text = this.objlang.GetLanguageConversion("To");
            this.lblEstimateType.Text = this.objlang.GetLanguageConversion("Estimate_Type");
            this.lblNoWidgets.Text = this.objlang.GetLanguageConversion("No_Selected_Widgets_Found");
            this.lblDisplayType.Text = this.objlang.GetLanguageConversion("Display_Type");
            this.lbltargetdisplaytype.Text = this.objlang.GetLanguageConversion("Display_Type");
            this.ddlDisplayType.Items[0].Text = this.objlang.GetLanguageConversion("Tabular");
            this.lbltaskalert.Text = this.objlang.GetLanguageConversion("Graph_Type");
            this.ddlGraphType.Items[0].Text = this.objlang.GetLanguageConversion("Bar");
            this.ddlGraphType.Items[1].Text = this.objlang.GetLanguageConversion("Pie");
            this.ddlGraphType2.Items[0].Text = this.objlang.GetLanguageConversion("Bar");
            this.ddlGraphType2.Items[1].Text = this.objlang.GetLanguageConversion("StackedBar");
            this.ddlGraphType3.Items[0].Text = this.objlang.GetLanguageConversion("Bar");
            this.ddlGraphType3.Items[1].Text = this.objlang.GetLanguageConversion("Line");
            this.ddlGraphType3.Items[2].Text = this.objlang.GetLanguageConversion("Pie");
            this.lblModule.Text = this.objlang.GetLanguageConversion("Module_Name");
            this.ddlModuleName.Items[0].Text = this.objlang.GetLanguageConversion("Estimates");
            this.ddlModuleName.Items[1].Text = this.objlang.GetLanguageConversion("Invoice");
            this.ddlModuleName.Items[2].Text = this.objlang.GetLanguageConversion("Jobs");
            this.ddltargetdispplayType.Items[0].Text = this.objlang.GetLanguageConversion("Tabular");
            this.ddltargetdispplayType.Items[1].Text = this.objlang.GetLanguageConversion("Graph");
            this.ddlJobsinvoicebydue.Items[0].Text = this.objlang.GetLanguageConversion("Invoice");
            this.ddlJobsinvoicebydue.Items[1].Text = this.objlang.GetLanguageConversion("Jobs");
            this.Label2.Text = this.objlang.GetLanguageConversion("Date_Range");
            this.lblEstimate.Text = this.objlang.GetLanguageConversion("Estimate");
            this.ddlDefaultDate.Items[0].Text = this.objlang.GetLanguageConversion("Today");
            this.ddlDefaultDate.Items[1].Text = this.objlang.GetLanguageConversion("This_Week");
            this.ddlDefaultDate.Items[2].Text = this.objlang.GetLanguageConversion("This_Month");
            this.ddlTasksDaterange.Items[0].Text = this.objlang.GetLanguageConversion("Today");
            this.ddlTasksDaterange.Items[1].Text = this.objlang.GetLanguageConversion("Today_Plus_Overdue");
            this.ddlTasksDaterange.Items[2].Text = this.objlang.GetLanguageConversion("Tomorrow");
            this.ddlTasksDaterange.Items[3].Text = this.objlang.GetLanguageConversion("Next_7_Days");
            this.ddlTasksDaterange.Items[4].Text = this.objlang.GetLanguageConversion("Next_7_Days_Plus_Overdue");
            this.ddlTasksDaterange.Items[5].Text = this.objlang.GetLanguageConversion("This_Month");
            this.ddlTasksDaterange.Items[6].Text = this.objlang.GetLanguageConversion("All_Open");
            this.ddlTasksDaterange.Items[7].Text = this.objlang.GetLanguageConversion("All");
            this.ddltaskResultselecType.Items[0].Text = this.objlang.GetLanguageConversion("Today");
            this.ddltaskResultselecType.Items[1].Text = this.objlang.GetLanguageConversion("Today_Plus_Overdue");
            this.ddltaskResultselecType.Items[2].Text = this.objlang.GetLanguageConversion("Tomorrow");
            this.ddltaskResultselecType.Items[3].Text = this.objlang.GetLanguageConversion("Next_7_Days");
            this.ddltaskResultselecType.Items[4].Text = this.objlang.GetLanguageConversion("Next_7_Days_Plus_Overdue");
            this.ddltaskResultselecType.Items[5].Text = this.objlang.GetLanguageConversion("This_Month");
            this.ddltaskResultselecType.Items[6].Text = this.objlang.GetLanguageConversion("All_Open");
            this.ddltaskResultselecType.Items[7].Text = this.objlang.GetLanguageConversion("All");
            this.lblTaskstatus.Text = this.objlang.GetLanguageConversion("Tasks_Status");
            this.ddlTaskStatus.Items[0].Text = this.objlang.GetLanguageConversion("All");
            this.ddlTaskStatus.Items[1].Text = this.objlang.GetLanguageConversion("Completed");
            this.ddlTaskStatus.Items[2].Text = this.objlang.GetLanguageConversion("Deferred");
            this.ddlTaskStatus.Items[3].Text = this.objlang.GetLanguageConversion("Inprocess");
            this.ddlTaskStatus.Items[4].Text = this.objlang.GetLanguageConversion("Not_Started");
            this.ddlTaskStatus.Items[5].Text = this.objlang.GetLanguageConversion("Partially_Completed");
            this.lblCompanytype.Text = this.objlang.GetLanguageConversion("Company_Type");
            this.ddlCompanyType.Items[0].Text = this.objlang.GetLanguageConversion("Customer");
            this.ddlCompanyType.Items[1].Text = this.objlang.GetLanguageConversion("Prospect");
            this.ddlCompanyType.Items[2].Text = this.objlang.GetLanguageConversion("Both");
            this.lblColumns.Text = this.objlang.GetLanguageConversion("Columns");
            this.chkLatestcolumns.Items[0].Text = this.objlang.GetLanguageConversion("Customer_Name");
            this.chkLatestcolumns.Items[1].Text = this.objlang.GetLanguageConversion("Specific_to_Contact");
            this.chkLatestcolumns.Items[2].Text = this.objlang.GetLanguageConversion("Title");
            this.chkLatestcolumns.Items[3].Text = this.objlang.GetLanguageConversion("Content");
            this.chkLatestcolumns.Items[4].Text = this.objlang.GetLanguageConversion("Created_By");
            this.chkLatestcolumns.Items[5].Text = this.objlang.GetLanguageConversion("Created_On");
            this.chkcolscustomeractivity.Items[0].Text = this.objlang.GetLanguageConversion("Customer_Name");
            this.chkcolscustomeractivity.Items[1].Text = this.objlang.GetLanguageConversion("Main_Contact");
            this.chkcolscustomeractivity.Items[2].Text = this.objlang.GetLanguageConversion("Phone");
            this.chkcolscustomeractivity.Items[3].Text = this.objlang.GetLanguageConversion("Last_Activity_Type");
            this.chkcolscustomeractivity.Items[4].Text = this.objlang.GetLanguageConversion("Time");
            this.lblNoOfrecords.Text = this.objlang.GetLanguageConversion("No_of_records");
            this.ddlRecordType.Items[0].Text = this.objlang.GetLanguageConversion("Task");
            this.ddlRecordType.Items[1].Text = this.objlang.GetLanguageConversion("Call");
            this.ddlRecordType.Items[2].Text = this.objlang.GetLanguageConversion("Both");
            this.Label4.Text = this.objlang.GetLanguageConversion("Record_Date");
            this.lblCustomers.Text = this.objlang.GetLanguageConversion("Customers");
            this.ddlCustomers.Items[0].Text = this.objlang.GetLanguageConversion("All");
            this.Label3.Text = this.objlang.GetLanguageConversion("Title");
            this.lblspread.Text = this.objlang.GetLanguageConversion("Spread_in_two_columns");
            this.btnUpdate.Text = this.objlang.GetLanguageConversion("Update");
            this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
            this.Button1.Text = this.objlang.GetLanguageConversion("Cancel");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.convert(global.pageTitle(this.objlang.GetLanguageConversion("Dashboard_settings"), this.CompanyID, this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Dashboard_settings")));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Dashboard_settings");
            this.rwReferences.Title = this.objlang.GetLanguageConversion("Dashboard_settings");
            this.lblavilablewidgets.Text = this.objlang.GetLanguageConversion("Available_Widgets");
            this.lblcustimizewidgets.Text = this.objlang.GetLanguageConversion("Selected_Widgets");
            this.GetMasterDock();
            if (!base.IsPostBack)
            {
                this.GetUseDock();
            }
            if (this.Session["Added"] != null && this.Session["Added"].ToString() != "")
            {
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_added_Successfully"), "msg-success", this.plhMessage);
                this.Session["Added"] = null;
                this.RadPanelBar1.Items[0].Expanded = false;
                this.RadPanelBar1.Items[1].Expanded = true;
            }
            if (this.Session["Save"] != null && this.Session["Save"].ToString() != "")
            {
                this.divmsg.Style.Add("display", "block");
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Customize_setting_saved_Successfully"), "msg-success", this.plhMessage);
                this.Session["Save"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghide();", true);
                this.RadPanelBar1.Items[0].Expanded = false;
                this.RadPanelBar1.Items[1].Expanded = true;
            }
            if (this.Session["Delete"] != null && this.Session["Delete"].ToString() != "")
            {
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_deleted_Successfully"), "msg-success", this.plhMessage);
                this.Session["Delete"] = null;
                this.RadPanelBar1.Items[0].Expanded = false;
                this.RadPanelBar1.Items[1].Expanded = true;
            }
            if (this.Session["Update"] != null && this.Session["Update"].ToString() != "")
            {
                this.divmsg.Style.Add("display", "block");
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_Updated_Successfully"), "msg-success", this.plhMessage);
                this.Session["Update"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:msghide();", true);
                this.RadPanelBar1.Items[0].Expanded = false;
                this.RadPanelBar1.Items[1].Expanded = true;
            }
            this.DateFormat = this.Session["DateFormat"].ToString();
            this.txtFromdate.Attributes.Add("onfocus", "javascript:InsertSearchtext1('f');");
            this.txtFromdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
            this.txtFromdate.Attributes.Add("onblur", "javascript:InsertSearchtext1('b');");
            this.txtToate.Attributes.Add("onfocus", "javascript:InsertSearchtext1('f');");
            this.txtToate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
            this.txtToate.Attributes.Add("onblur", "javascript:InsertSearchtext1('b');");
            if (!base.IsPostBack)
            {
                this.EstimatesTypesfromDwebconfig();
                this.GetCustomers();
                forecast _forecast = new forecast();
                DataTable dataTable = new DataTable();
                dataTable = _forecast.SelectAllUsers(this.CompanyID);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        column.ReadOnly = false;
                    }
                    row["SalesPersonName"] = this.objbase.SpecialDecode(row["SalesPersonName"].ToString());
                }
                this.ddlcompanyName.DataSource = dataTable;
                this.ddlcompanyName.DataTextField = "SalesPersonName";
                this.ddlcompanyName.DataValueField = "userid";
                this.ddlcompanyName.DataBind();
                this.ddlsalesPerson.DataSource = dataTable;
                this.ddlsalesPerson.DataTextField = "SalesPersonName";
                this.ddlsalesPerson.DataValueField = "userid";
                this.ddlsalesPerson.DataBind();
                this.ddlTargetSalesPerson.DataSource = dataTable;
                this.ddlTargetSalesPerson.DataTextField = "SalesPersonName";
                this.ddlTargetSalesPerson.DataValueField = "userid";
                this.ddlTargetSalesPerson.DataBind();
                this.ddlTargetSalesPerson.Items.Insert(0, " ");
                this.ddlTargetSalesPerson.Items[0].Text = "--Select--";
                this.ddlTargetSalesPerson.Items[0].Value = "0";
                RadListBoxItem radListBoxItem = new RadListBoxItem();
                this.ddlsalesPerson.Items.Insert(0, radListBoxItem);
                this.ddlsalesPerson.Items[0].Text = "All";
                this.ddlsalesPerson.Items[0].Value = "-1";
                RadListBoxItem radListBoxItem1 = new RadListBoxItem();
                this.lstsaleperson.DataSource = dataTable;
                this.lstsaleperson.DataTextField = "SalesPersonName";
                this.lstsaleperson.DataValueField = "userid";
                this.lstsaleperson.DataBind();
                this.lstsaleperson.Items.Insert(0, radListBoxItem1);
                this.lstsaleperson.Items[0].Text = "All";
                this.lstsaleperson.Items[0].Value = "-1";
                this.RadListBoxCustomer.DataSource = dataTable;
                this.RadListBoxCustomer.DataTextField = "SalesPersonName";
                this.RadListBoxCustomer.DataValueField = "userid";
                this.RadListBoxCustomer.DataBind();
                this.DropDownList1.DataSource = dataTable;
                this.DropDownList1.DataTextField = "SalesPersonName";
                this.DropDownList1.DataValueField = "userid";
                this.DropDownList1.DataBind();
            }
            foreach (ListItem item in this.ddlEstimateType.Items)
            {
                if (item.Value == "sfd" || item.Value == "sfo")
                {
                    item.Attributes.Add("disabled", "disabled");
                }
                else if (item.Value == "S" || item.Value == "B" || item.Value == "P" || item.Value == "F" || item.Value == "D" || item.Value == "K" || item.Value == "N")
                {
                    item.Attributes.Add("style", "padding-left:10px");
                }
                else
                {
                    item.Attributes.Add("style", "padding-left:1px");
                }
            }
            if (!base.IsPostBack)
            {
                this.BindEstimateStatus();
                this.BindJobStatus();
                this.BindInvoiceStatus();
            }
            this.rwReferencesMini.Title = this.objlang.GetLanguageConversion("Mini_dashboard_settings");
            this.lblavilablewidgetsMINI.Text = this.objlang.GetLanguageConversion("Available_Widgets");
            this.lblcustimizewidgetsMINI.Text = this.objlang.GetLanguageConversion("Selected_Widgets");
            this.lblNoWidgetsMINI.Text = this.objlang.GetLanguageConversion("No_Selected_Widgets_Found");
            this.lblUserMini.Text = this.objlang.GetLanguageConversion("Sales_Person");
            this.lblDateTypeMini.Text = this.objlang.GetLanguageConversion("Date_Type");
            this.Label14.Text = this.objlang.GetLanguageConversion("Include_Archived_Record");
            this.Label2Mini.Text = this.objlang.GetLanguageConversion("Display_Widget");
            this.Label4Mini.Text = this.objlang.GetLanguageConversion("Widget_header_color");
            this.Label3Mini.Text = this.objlang.GetLanguageConversion("Title");
            this.GetMasterDockMini();
            if (!base.IsPostBack)
            {
                this.GetUseDockMini();
                this.objset.Bind_User(this.ddlUserMini, this.CompanyID, "--All--");
            }
            if (this.Session["AddedMini"] != null && this.Session["AddedMini"].ToString() != "")
            {
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_added_Successfully"), "msg-success", this.plhMessageMINI);
                this.Session["AddedMini"] = null;
                this.RadPanelBar1.Items[0].Expanded = true;
                this.RadPanelBar1.Items[1].Expanded = false;
            }
            if (this.Session["DeleteMini"] != null && this.Session["DeleteMini"].ToString() != "")
            {
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Widget_deleted_Successfully"), "msg-success", this.plhMessageMINI);
                this.Session["DeleteMini"] = null;
                this.RadPanelBar1.Items[0].Expanded = true;
                this.RadPanelBar1.Items[1].Expanded = false;
            }
            if (this.Session["SaveLayoutMini"] != null && this.Session["SaveLayoutMini"].ToString() != "")
            {
                this.objbase.Message_Display(this.objlang.GetLanguageConversion("Current Layout Saved Successfully"), "msg-success", this.plhMessageMINI);
                this.Session["SaveLayoutMini"] = null;
                this.RadPanelBar1.Items[0].Expanded = true;
                this.RadPanelBar1.Items[1].Expanded = false;
            }

            commonClass _commonClass = this.comm;
            DateTime now = DateTime.Now;
            commonClass _commonClass1 = this.comm;
            DateTime dateTime = DateTime.Now;



            if (!base.IsPostBack)
            {
                TextBox textBox = this.txtFromDateNew;
                textBox.Text = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);

                TextBox textBox1 = this.txtToDate;
                textBox1.Text = _commonClass1.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, false);

                //string dateff = "mm/dd/yyyy";
                this.txtFromDateNew.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtToDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            }

            if (!base.IsPostBack)
            {
                TextBox textBox = this.txtFromDate2;
                textBox.Text = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);

                TextBox textBox1 = this.txtToDate2;
                textBox1.Text = _commonClass1.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, false);

                //string dateff = "mm/dd/yyyy";
                this.txtFromDate2.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtToDate2.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            }
        }

        public string ReplaceSpecialDecode(string OriginalString)
        {
            OriginalString = OriginalString.Replace("%27", "'");
            OriginalString = OriginalString.Replace("%22", "\"");
            OriginalString = OriginalString.Replace("%5C", "\\");
            return OriginalString;
        }

        public string ReplaceSpecialEncode(string OriginalString)
        {
            OriginalString = OriginalString.Replace("'", "%27");
            OriginalString = OriginalString.Replace("\"", "%22");
            OriginalString = OriginalString.Replace("\\", "%5C");
            return OriginalString;
        }
    }
}