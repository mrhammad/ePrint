using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.orders
{
    public partial class order_rerun : UsercontrolBasePage
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string strfilepath = global.filePath();

        public int CompanyID;

        public int UserID;

        public string Pgtype = "webstoreorder";

        public string UcStageSection = string.Empty;

        public string req_type = string.Empty;

        private SettingsBasePage objSet = new SettingsBasePage();

        private commonClass comm = new commonClass();

        private BasePage objPage = new BasePage();

        public static languageClass objLanguage;

        public string Module = string.Empty;

        public static long OrderID;

        public int CostCentreID;

        public static long EstimateID;

        private BaseClass objBase = new BaseClass();

        private SummaryClass SummaryClassObj = new SummaryClass();

        public long JobID;

        public long InvoiceID;

        public string DateFormat = "mm/dd/yyyy";

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

        static order_rerun()
        {
            order_rerun.objLanguage = new languageClass();
            order_rerun.OrderID = (long)0;
            order_rerun.EstimateID = (long)0;
        }

        public order_rerun()
        {
        }

        protected void btncancel_onclick(object sender, EventArgs e)
        {
            if (this.Module == "job")
            {
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", order_rerun.EstimateID, "&estid=", order_rerun.EstimateID, "&jID=", base.Request.Params["jID"] };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            if (this.Module == "invoice")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&InvID=", base.Request.Params["InvID"]));
                return;
            }
            if (this.Module == "webstoreorder")
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", order_rerun.EstimateID, "&estid=", order_rerun.EstimateID };
                httpResponse.Redirect(string.Concat(objArray));
            }
        }

        protected void btnsave_onclick(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            DateTime now = DateTime.Now;
            num = Convert.ToInt32(this.hdn_costcentreid.Value);
            DateTime dateTime = DateTime.Now;
            if (this.ddlSalesPerson.Items.Count != 0)
            {
                num1 = Convert.ToInt32(this.ddlSalesPerson.SelectedItem.Value);
            }
            if (this.ddlinvoicecontact.Items.Count != 0)
            {
                num3 = Convert.ToInt32(this.ddlinvoicecontact.SelectedItem.Value);
            }
            if (this.ddlStatus.Items.Count != 0)
            {
                num2 = Convert.ToInt32(this.ddlStatus.SelectedItem.Value);
            }
            if (base.Request.Params["estid"] != null)
            {
                order_rerun.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            DateTime dateTime1 = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.deliverydate.Text));


            DateTime dateArtwork = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.dateArtwork.Text));
            DateTime dateProof = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.dateProof.Text));
            DateTime dateApproval = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.dateApproval.Text));
            DateTime dateCompletion = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.dateCompletion.Text));
            //DateTime dateProduction = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.dateProduction.Text));

            if (this.Module == "invoice")
            {
                now = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoiceDuedate.Text));
                dateTime = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtOrderedDate.Text));
            }

            DateTime? CustomDate1 = string.IsNullOrEmpty(this.txtCustomDate1.Text) ? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate1.Text));
            DateTime? CustomDate2 = string.IsNullOrEmpty(this.txtCustomDate2.Text) ? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate2.Text));
            DateTime? CustomDate3 = string.IsNullOrEmpty(this.txtCustomDate3.Text) ? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate3.Text));
            DateTime? CustomDate4 = string.IsNullOrEmpty(this.txtCustomDate4.Text) ? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate4.Text));
            DateTime? CustomDate5 = string.IsNullOrEmpty(this.txtCustomDate5.Text) ? (DateTime?)null : Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomDate5.Text));


            OrderBasePage.OrderEditDetails_update(this.Module, order_rerun.OrderID, order_rerun.EstimateID, (long)this.CompanyID, Convert.ToInt64(this.hid_ContactID.Value), this.txtcontactemail.Text, this.objBase.SpecialEncode(this.txtcontactphone.Text), Convert.ToInt64(this.hdn_DepartmentID.Value), num, this.objBase.SpecialEncode(this.txtGreeting.Text), Convert.ToInt64(this.hdn_ContactAddressID.Value), Convert.ToInt64(this.hid_DeliveryAddressID.Value), Convert.ToInt64(this.hdn_InvoiceAddressID.Value), this.objBase.SpecialEncode(this.hid_HeaderText.Value), this.objBase.SpecialEncode(this.hid_FooterText.Value), num1, this.objBase.SpecialEncode(this.txtEstimateTitle.Text), (long)num2, this.objBase.SpecialEncode(this.txtOrderNumber.Text), this.objBase.SpecialEncode(this.txtcomments.Text), dateTime1, now, this.JobID, this.InvoiceID, dateTime, dateArtwork, dateProof, dateApproval, dateCompletion, num3,CustomDate1,CustomDate2,CustomDate3,CustomDate4,CustomDate5);//, dateProduction);
            string str = this.objBase.Return_StockManagementSettings("Replenish_JobStatusID");
            string empty = string.Empty;
            if (num2.ToString() == str)
            {
                this.SummaryClassObj.Call_Inventory_Adjustment("completed-status", order_rerun.EstimateID, this.CompanyID, (long)0, this.UserID);
            }
            if (this.Module == "job")
            {
                HttpResponse response = base.Response;
                object[] item = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", base.Request.Params["orderid"], "&estid=", order_rerun.EstimateID, "&jID=", base.Request.Params["jID"] };
                response.Redirect(string.Concat(item));
                return;
            }
            if (this.Module == "invoice")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&InvID=", base.Request.Params["InvID"]));
                return;
            }
            if (this.Module == "webstoreorder")
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", base.Request.Params["orderid"], "&estid=", order_rerun.EstimateID };
                httpResponse.Redirect(string.Concat(objArray));
            }
        }

        public void getorderdetails()
        {
            if (this.Module.ToLower() == "invoice")
            {
                this.txtOrderedDate.Enabled = true;
                DataSet dataSet = InvoiceBasePage.Invoice_SummaryDetails_Select(this.CompanyID, this.InvoiceID);
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    this.txtOrderedDate.Text = this.comm.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
                    this.txtInvoiceDuedate.Text = this.comm.Eprint_return_Date_Before_View(row["Invoice_DueDate"].ToString(), this.CompanyID, this.UserID, false);
                    this.txtinvoicenumber.Text = row["InvoiceNumber"].ToString();
                    this.setddlval(this.ddlStatus, Convert.ToInt32(row["StatusID"]));
                    this.lblHeader.Text = this.objBase.SpecialDecode(row["InvoiceHeader"].ToString());
                    this.lblFooter.Text = this.objBase.SpecialDecode(row["InvoiceFooter"].ToString());
                    this.hid_HeaderText.Value = this.objBase.SpecialDecode(row["InvoiceHeader"].ToString());
                    this.hid_FooterText.Value = this.objBase.SpecialDecode(row["InvoiceFooter"].ToString());
                    this.txtName.Enabled = false;
                    this.txtName.Text = this.objBase.SpecialDecode(row["ClientName"].ToString());
                    this.hid_ClientID.Value = row["ClientID"].ToString();
                    this.hid_ContactID.Value = row["ContactID"].ToString();
                    this.txtGreeting.Text = this.objBase.SpecialDecode(row["Greeting"].ToString());
                    this.txtCompany.Text = this.objBase.SpecialDecode(row["DepartmentName"].ToString());
                    this.txtCompany.Enabled = false;
                    this.lblAddress.Text = this.objBase.SpecialDecode(row["ContactAddress"].ToString());
                    this.txtEstimateTitle.Text = this.objBase.SpecialDecode(row["EstimateTitle"].ToString());
                    this.txtmainordernumber.Text = this.objBase.SpecialDecode(row["SystemOrderNumber"].ToString());
                    this.txtmainordernumber.Enabled = false;
                    this.CostCentreID = Convert.ToInt32(row["CostCentreID"]);
                    this.hdn_costcentreid.Value = row["CostCentreID"].ToString();
                    this.hdn_DepartmentID.Value = row["DepartmentID"].ToString();
                    order_rerun.EstimateID = Convert.ToInt64(row["EstimateID"].ToString());
                    this.lblDeliveryAddress.Text = this.objBase.SpecialDecode(row["DeliveryAddress"].ToString());
                    this.lblInvoiceAddress.Text = this.objBase.SpecialDecode(row["InvoiceAddress"].ToString());
                    this.hid_DeliveryAddressID.Value = row["ShippingAddressID"].ToString();
                    this.hdn_InvoiceAddressID.Value = row["BillingAddressID"].ToString();
                    this.hdn_ContactAddressID.Value = row["AddressID"].ToString();
                    this.lblAccountNumber.Text = this.objBase.SpecialDecode(row["AccountNo"].ToString());
                    this.txtcontactemail.Text = this.objBase.SpecialDecode(row["Email"].ToString());
                    this.txtcontactphone.Text = this.objBase.SpecialDecode(row["HomeTelephone"].ToString());
                    this.hid_EstimateID.Value = row["EstimateID"].ToString();
                    this.txtcomments.Text = this.objBase.SpecialDecode(row["Comments"].ToString());
                    this.txtOrderNumber.Text = this.objBase.SpecialDecode(row["CustomerOrderNo"].ToString());
                    this.lblorderedby.Text = this.objBase.SpecialDecode(row["OrderedBy"].ToString());
                    if (!string.IsNullOrEmpty(row["ContactList"].ToString()))
                    {
                        string[] strArrays = row["ContactList"].ToString().Split(new char[] { '±' });
                        for (int i = 0; i < (int)strArrays.Length; i++)
                        {
                            string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                            ListItem listItem = new ListItem()
                            {
                                Text = this.objBase.SpecialDecode(strArrays1[1]),
                                Value = strArrays1[0]
                            };
                            this.ddlcontact.Items.Add(listItem);
                        }
                    }
                    if (!string.IsNullOrEmpty(row["ContactList"].ToString()))
                    {
                        string[] strArrays = row["ContactList"].ToString().Split(new char[] { '±' });
                        for (int i = 0; i < (int)strArrays.Length; i++)
                        {
                            string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                            ListItem listItem = new ListItem()
                            {
                                Text = this.objBase.SpecialDecode(strArrays1[1]),
                                Value = strArrays1[0]
                            };
                            this.ddlinvoicecontact.Items.Add(listItem);
                        }
                    }
                    this.txtOrderedDate.Text = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, this.UserID, false);
                    this.setddlval(this.ddlcontact, Convert.ToInt32(row["ContactID"]));
                    this.setddlval(this.ddlSalesPerson, Convert.ToInt32(row["SalesPerson"]));
                    this.setddlval(this.ddlinvoicecontact, Convert.ToInt32(row["InvoiceContactid"]));
                    if (this.Module == "webstoreorder")
                    {
                        this.setddlval(this.ddlStatus, Convert.ToInt32(row["StatusID"]));
                        this.lblEstimateArtwork.Text = order_rerun.objLanguage.GetLanguageConversion("Ordered_Date");
                    }
                    //this.deliverydate.Text = this.comm.Eprint_return_Date_Before_View(row["RequiredBy"].ToString(), this.CompanyID, this.UserID, false);
                    //this.txtCustomDate1.Text = this.comm.Eprint_return_Date_Before_View(row["CustomDate1"].ToString(), this.CompanyID, this.UserID, false);
                    //this.txtCustomDate2.Text = this.comm.Eprint_return_Date_Before_View(row["CustomDate2"].ToString(), this.CompanyID, this.UserID, false);
                    //this.txtCustomDate3.Text = this.comm.Eprint_return_Date_Before_View(row["CustomDate3"].ToString(), this.CompanyID, this.UserID, false);
                    //this.txtCustomDate4.Text = this.comm.Eprint_return_Date_Before_View(row["CustomDate4"].ToString(), this.CompanyID, this.UserID, false);
                    //this.txtCustomDate5.Text = this.comm.Eprint_return_Date_Before_View(row["CustomDate5"].ToString(), this.CompanyID, this.UserID, false);

                }
                Type type = base.GetType();
                object[] companyID = new object[] { "javascript:CallLoadCostCentre(", this.CompanyID, ",", this.hid_ClientID.Value, ",", this.hdn_DepartmentID.Value, ",", this.CostCentreID, ");" };
                ScriptManager.RegisterStartupScript(this, type, " ", string.Concat(companyID), true);
                this.div_headerfooter.Style.Add("display", "block");
                this.div_InvoiceNumber.Style.Add("display", "block");
                this.div_InvoiceDueDate.Style.Add("display", "block");
                this.lblstatus.Text = "Invoice Status";
                this.lbltitle.Text = "Invoice Title";
                this.lblEstimateArtwork.Text = "Invoice Date";
                this.txtinvoicenumber.Enabled = false;
                return;
            }
            int num = 0;
            DataTable dataTable = OrderBasePage.Order_select(this.CompanyID, (long)Convert.ToInt32(base.Request.Params["orderid"]));
                        

            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.txtName.Enabled = false;
                this.txtName.Text = this.objBase.SpecialDecode(dataRow["ClientName"].ToString());
                this.hid_ClientID.Value = dataRow["ClientID"].ToString();
                this.hid_ContactID.Value = dataRow["AttentionID"].ToString();
                this.hdnStatustitle.Value = dataRow["CustomerStatusTitle"].ToString();
                if (dataRow["EstimateGreeting"].ToString() == "")
                {
                    this.txtGreeting.Text = this.objBase.SpecialDecode(dataRow["Greeting"].ToString());
                }
                else
                {
                    this.txtGreeting.Text = this.objBase.SpecialDecode(dataRow["EstimateGreeting"].ToString());
                }
                this.txtCompany.Text = this.objBase.SpecialDecode(dataRow["DepartmentName"].ToString());
                this.txtCompany.Enabled = false;
                this.lblAddress.Text = this.objBase.SpecialDecode(dataRow["ContactAddress"].ToString());
                this.txtEstimateTitle.Text = this.objBase.SpecialDecode(dataRow["OrderTitle"].ToString());
                this.txtmainordernumber.Text = this.objBase.SpecialDecode(dataRow["OrderNo"].ToString());
                this.txtmainordernumber.Enabled = false;
                this.CostCentreID = Convert.ToInt32(dataRow["CostCentreID"]);
                this.hdn_costcentreid.Value = dataRow["CostCentreID"].ToString();
                this.hdn_DepartmentID.Value = dataRow["DepartmentID"].ToString();
                order_rerun.EstimateID = Convert.ToInt64(dataRow["EstimateID"].ToString());
                this.lblDeliveryAddress.Text = this.objBase.SpecialDecode(dataRow["ShippingAddress"].ToString());
                this.lblInvoiceAddress.Text = this.objBase.SpecialDecode(dataRow["BillingAddress"].ToString());
                this.hid_DeliveryAddressID.Value = dataRow["ShippingAddressID"].ToString();
                this.hdn_InvoiceAddressID.Value = dataRow["BillingAddressID"].ToString();
                this.hdn_ContactAddressID.Value = dataRow["AddressID"].ToString();
                this.lblAccountNumber.Text = this.objBase.SpecialDecode(dataRow["AccountNo"].ToString());
                this.txtcontactemail.Text = this.objBase.SpecialDecode(dataRow["email"].ToString());
                this.txtcontactphone.Text = this.objBase.SpecialDecode(dataRow["HomeTelephone"].ToString());
                this.hid_EstimateID.Value = dataRow["EstimateID"].ToString();
                this.txtcomments.Text = this.objBase.SpecialDecode(dataRow["Comments"].ToString());
                this.txtOrderNumber.Text = this.objBase.SpecialDecode(dataRow["CustomerOrderNo"].ToString());
                this.lblorderedby.Text = this.objBase.SpecialDecode(dataRow["OrderedBy"].ToString());
                if (!string.IsNullOrEmpty(dataRow["ContactList"].ToString()) && num == 0)
                {
                    string[] strArrays2 = dataRow["ContactList"].ToString().Split(new char[] { '±' });
                    for (int j = 0; j < (int)strArrays2.Length; j++)
                    {
                        string[] strArrays3 = strArrays2[j].Split(new char[] { '»' });
                        ListItem listItem1 = new ListItem()
                        {
                            Text = this.objBase.SpecialDecode(strArrays3[1]),
                            Value = strArrays3[0]
                        };
                        this.ddlcontact.Items.Add(listItem1);
                    }
                }
                if (!string.IsNullOrEmpty(dataRow["ContactList"].ToString()) && num == 0)
                {
                    string[] strArrays2 = dataRow["ContactList"].ToString().Split(new char[] { '±' });
                    for (int j = 0; j < (int)strArrays2.Length; j++)
                    {
                        string[] strArrays3 = strArrays2[j].Split(new char[] { '»' });
                        ListItem listItem1 = new ListItem()
                        {
                            Text = this.objBase.SpecialDecode(strArrays3[1]),
                            Value = strArrays3[0]
                        };
                        this.ddlinvoicecontact.Items.Add(listItem1);
                    }
                }
                num++;
                this.txtOrderedDate.Text = this.comm.Eprint_return_Date_Before_View(dataRow["OrderDate"].ToString(), this.CompanyID, this.UserID, false);
                this.ddlcontact.SelectedValue = dataRow["AttentionID"].ToString();
                this.ddlinvoicecontact.SelectedValue = dataRow["InvoiceContactid"].ToString();
                this.setddlval(this.ddlSalesPerson, Convert.ToInt32(dataRow["SalesPerson"]));
                //this.setddlval(this.ddlinvoicecontact, Convert.ToInt32(dataRow["InvoiceContactid"]));
                if (this.Module == "webstoreorder")
                {
                    this.setddlval(this.ddlStatus, Convert.ToInt32(dataRow["StatusID"]));
                    this.lblEstimateArtwork.Text = order_rerun.objLanguage.GetLanguageConversion("Ordered_Date");
                }
                this.deliverydate.Text = this.comm.Eprint_return_Date_Before_View(dataRow["RequiredBy"].ToString(), this.CompanyID, this.UserID, false);
                //this.deliverydate.Text = this.comm.Eprint_return_Date_Before_View(dataRow["OrderDate"].ToString(), this.CompanyID, this.UserID, false);

                this.txtCustomDate1.Text = this.comm.Eprint_return_Date_Before_View(dataRow["CustomDate1"].ToString(), this.CompanyID, this.UserID, false);
                this.txtCustomDate2.Text = this.comm.Eprint_return_Date_Before_View(dataRow["CustomDate2"].ToString(), this.CompanyID, this.UserID, false);
                this.txtCustomDate3.Text = this.comm.Eprint_return_Date_Before_View(dataRow["CustomDate3"].ToString(), this.CompanyID, this.UserID, false);
                this.txtCustomDate4.Text = this.comm.Eprint_return_Date_Before_View(dataRow["CustomDate4"].ToString(), this.CompanyID, this.UserID, false);
                this.txtCustomDate5.Text = this.comm.Eprint_return_Date_Before_View(dataRow["CustomDate5"].ToString(), this.CompanyID, this.UserID, false);


                if (this.Module != "job")
                {
                    continue;
                }
                this.div_headerfooter.Style.Add("display", "block");
                this.lblHeader.Text = this.objBase.SpecialDecode(dataRow["JobHeader"].ToString());
                this.lblFooter.Text = this.objBase.SpecialDecode(dataRow["JobFooter"].ToString());
                this.hid_HeaderText.Value = this.objBase.SpecialDecode(dataRow["JobHeader"].ToString());
                this.hid_FooterText.Value = this.objBase.SpecialDecode(dataRow["JobFooter"].ToString());
                this.dateArtwork.Text = this.comm.Eprint_return_Date_Before_View(dataRow["EstimatedArtwork"].ToString(), this.CompanyID, this.UserID, false);
                this.dateProof.Text = this.comm.Eprint_return_Date_Before_View(dataRow["EstProofDate"].ToString(), this.CompanyID, this.UserID, false);
                this.dateApproval.Text = this.comm.Eprint_return_Date_Before_View(dataRow["EstApprovalDate"].ToString(), this.CompanyID, this.UserID, false);
                this.dateCompletion.Text = this.comm.Eprint_return_Date_Before_View(dataRow["EstCompletionDate"].ToString(), this.CompanyID, this.UserID, false);
                //this.dateProduction.Text = this.comm.Eprint_return_Date_Before_View(dataRow["EstProductionDate"].ToString(), this.CompanyID, this.UserID, false);

            }
            Type type1 = base.GetType();
            object[] objArray = new object[] { "javascript:CallLoadCostCentre(", this.CompanyID, ",", this.hid_ClientID.Value, ",", this.hdn_DepartmentID.Value, ",", this.CostCentreID, ");" };
            ScriptManager.RegisterStartupScript(this, type1, " ", string.Concat(objArray), true);
            if (this.Module == "job")
            {
                DataTable dataTable1 = OrderBasePage.jobOrder_select(this.CompanyID, order_rerun.OrderID, order_rerun.EstimateID);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    this.div_jobnumber.Style.Add("display", "block");
                    this.txtOrderedDate.Text = this.comm.Eprint_return_Date_Before_View(row1["converteddate"].ToString(), this.CompanyID, this.UserID, false);
                    this.txtjobnumber.Text = row1["JobNumber"].ToString();
                    this.txtjobnumber.Enabled = false;
                    this.lbltitle.Text = "Job Title";
                    this.lblstatus.Text = "Job Status";
                    this.lblEstimateArtwork.Text = "Job Date";
                    this.setddlval(this.ddlStatus, Convert.ToInt32(row1["StatusID"]));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MasterPage master = this.Parent.Page.Master;
            ((HtmlControl)master.FindControl("DivLeftpanel")).Visible = false;
            HtmlControl htmlControl = (HtmlControl)master.FindControl("RightPanel");
            htmlControl.Attributes.Add("Style", "width:100%;");
            this.btnSave.Text = order_rerun.objLanguage.GetLanguageConversion("Save");
            this.btnCancel.Text = order_rerun.objLanguage.GetLanguageConversion("Cancel");
            this.txtOrderedDate.Enabled = false;
            if (base.Request.Params["type"] != "")
            {
                this.Module = base.Request.Params["type"].ToString();
            }
            if (base.Request.Params["orderid"] != "")
            {
                order_rerun.OrderID = Convert.ToInt64(base.Request.Params["orderid"]);
            }
            this.req_type = "edit";
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = this.objPage.GetRegionalSettings(this.CompanyID, "Dateformat");
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.settings_user_select_forddl(this.CompanyID);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.Table.Columns.Contains("LimitName"))
                        {
                            row.Table.Columns["LimitName"].ReadOnly = false;
                        }
                        row["LimitName"] = this.objBase.SpecialDecode(row["LimitName"].ToString());
                    }
                }
                this.ddlSalesPerson.DataSource = dataTable;
                this.ddlSalesPerson.DataTextField = "LimitName";
                this.ddlSalesPerson.DataValueField = "UserID";
                this.ddlSalesPerson.DataBind();
            }
            if (Convert.ToBoolean(SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows[0]["IsDisplayCostCentre"]))
            {
                this.div_costcentre.Style.Add("display", "block");
            }
            SettingsBasePage.Get_Estimate_DefaulSetting(this.CompanyID);
            this.UcStageSection = base.BaseSection;
            if (!base.IsPostBack)
            {
                this.txtName.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
                this.txtName.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
            }
            this.txtOrderedDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.deliverydate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtInvoiceDuedate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));

            this.txtCustomDate1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtCustomDate2.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtCustomDate3.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtCustomDate4.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtCustomDate5.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));



            this.dateArtwork.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.dateProof.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.dateApproval.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.dateCompletion.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            //this.dateProduction.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));

            if (this.Module == "invoice" && base.Request.Params["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.Module == "job" && base.Request.Params["jID"] != null)
            {
                this.JobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (!base.IsPostBack)
            {
                if (this.Module == "invoice")
                {
                    this.Pgtype = "invoice";
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "no", "invoice");
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.ddlStatus.Enabled = false;
                    }
                }
                else if (this.Module != "job")
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "no", "webstoreorder");
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.ddlStatus.Enabled = false;
                    }
                }
                else
                {
                    this.Pgtype = "job";
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "no", "job");
                    if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.ddlStatus.Enabled = false;
                    }
                }
            }

            foreach (DataRow dataRow8 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
               
                this.lblCustomDate1.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle1"].ToString()) ? "Custom Date 1" : dataRow8["DefaultCustomDateTitle1"].ToString();
                this.lblCustomDate2.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle2"].ToString()) ? "Custom Date 2" : dataRow8["DefaultCustomDateTitle2"].ToString();
                this.lblCustomDate3.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle3"].ToString()) ? "Custom Date 3" : dataRow8["DefaultCustomDateTitle3"].ToString();
                this.lblCustomDate4.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle4"].ToString()) ? "Custom Date 4" : dataRow8["DefaultCustomDateTitle4"].ToString();
                this.lblCustomDate5.Text = string.IsNullOrEmpty(dataRow8["DefaultCustomDateTitle5"].ToString()) ? "Custom Date 5" : dataRow8["DefaultCustomDateTitle5"].ToString();


                if (!Convert.ToBoolean(dataRow8["IsDefaultCustomDate1"]))
                {
                    this.divCustomDate1.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.divCustomDate1.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(dataRow8["IsDefaultCustomDate2"]))
                {
                    this.divCustomDate2.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.divCustomDate2.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(dataRow8["IsDefaultCustomDate3"]))
                {
                    this.divCustomDate3.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.divCustomDate3.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(dataRow8["IsDefaultCustomDate4"]))
                {
                    this.divCustomDate4.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.divCustomDate4.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(dataRow8["IsDefaultCustomDate5"]))
                {
                    this.divCustomDate5.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.divCustomDate5.Attributes.Add("style", "display:block");
                }

            }

            if (!base.IsPostBack)
            {
                if (!this.Module.Contains("order"))
                {
                    this.setDates();
                    this.getorderdetails();

                }
                else
                {
                    this.getorderdetails();
                    this.setDates();
                }

            }
        }

        public void setddlval(DropDownList ddl, int value)
        {
            ListItem listItem = ddl.Items.FindByValue(value.ToString());
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }

        public void setDates()
        {
            DataTable dt = SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID);
            int NoOfDaysAddedForArtWork = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedArtwork"]);
            int NoOfDaysAddedForProof = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedProof"]);
            int NoOfDaysAddedForApproval = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedApproval"]);
            int NoOfDaysAddedForProduction = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedProduction"]);
            int NoOfDaysAddedForCompletion = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedCompletion"]);
            int NoOfDaysAddedForDelivery = Convert.ToInt32(dt.Rows[0]["DefaultEstimatedDelivery"]);
            
          

            int WorkingDaysFrom = Convert.ToInt32(dt.Rows[0]["WorkingDaysFrom"]);
            int WorkingDaysTo = Convert.ToInt32(dt.Rows[0]["WorkingDaysTo"]);

            var myList = new List<KeyValuePair<string, int>>();
            myList.Add(new KeyValuePair<string, int>("Sunday", 1));
            myList.Add(new KeyValuePair<string, int>("Monday", 2));
            myList.Add(new KeyValuePair<string, int>("Tuesday", 3));
            myList.Add(new KeyValuePair<string, int>("Wednesday", 4));
            myList.Add(new KeyValuePair<string, int>("Thursday", 5));
            myList.Add(new KeyValuePair<string, int>("Friday", 6));
            myList.Add(new KeyValuePair<string, int>("Saturday", 7));

            List<string> lst = new List<string>();

            if (WorkingDaysFrom < WorkingDaysTo)
            {
                for (int i = WorkingDaysFrom; i <= WorkingDaysTo; i++)
                {
                    foreach (var val in myList)
                    {
                        if (val.Value == i)
                        {
                            if (lst.Contains(val.Key) == false)
                                lst.Add(val.Key);
                        }
                    }
                }
            }
            else if(WorkingDaysFrom > WorkingDaysTo)
            {
                foreach (var val in myList)
                {
                    if (val.Value < WorkingDaysFrom && val.Value > WorkingDaysTo)
                    {
                        
                    }
                    else
                    {
                        if (lst.Contains(val.Key) == false)
                            lst.Add(val.Key);
                    }
                }
            }
            else if (WorkingDaysFrom == WorkingDaysTo)
            {
                foreach (var val in myList)
                {
                    if (lst.Contains(val.Key) == false)
                        lst.Add(val.Key);
                }
            }

            if(Boolean.Parse(dt.Rows[0]["IsDefaultArtwork"].ToString()) == true)
            {
                this.dateArtwork.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(NoOfDaysAddedForArtWork, lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultProof"].ToString()) == true)
            {
                this.dateProof.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(NoOfDaysAddedForProof, lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultApproval"].ToString()) == true)
            {
                this.dateApproval.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(NoOfDaysAddedForApproval, lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultProduction"].ToString()) == true)
            {
                //this.dateProduction.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(NoOfDaysAddedForProduction, lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultCompletion"].ToString()) == true)
            {
                this.dateCompletion.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(NoOfDaysAddedForCompletion, lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultDelivery"].ToString()) == true)
            {
                this.deliverydate.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(NoOfDaysAddedForDelivery, lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultCustomDate1"].ToString()) == true && !string.IsNullOrEmpty(dt.Rows[0]["DefaultCustomDate1"].ToString()))
            {
                this.txtCustomDate1.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(Convert.ToInt32(dt.Rows[0]["DefaultCustomDate1"]), lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultCustomDate2"].ToString()) == true && !string.IsNullOrEmpty(dt.Rows[0]["DefaultCustomDate2"].ToString()))
            {
                this.txtCustomDate2.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(Convert.ToInt32(dt.Rows[0]["DefaultCustomDate2"]), lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultCustomDate3"].ToString()) == true && !string.IsNullOrEmpty(dt.Rows[0]["DefaultCustomDate3"].ToString()))
            {
                this.txtCustomDate3.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(Convert.ToInt32(dt.Rows[0]["DefaultCustomDate3"]), lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultCustomDate4"].ToString()) == true && !string.IsNullOrEmpty(dt.Rows[0]["DefaultCustomDate4"].ToString()))
            {
                this.txtCustomDate4.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(Convert.ToInt32(dt.Rows[0]["DefaultCustomDate4"]), lst).ToString(), this.CompanyID, this.UserID, false);
            }
            if (Boolean.Parse(dt.Rows[0]["IsDefaultCustomDate5"].ToString()) == true && !string.IsNullOrEmpty(dt.Rows[0]["DefaultCustomDate5"].ToString()))
            {
                this.txtCustomDate5.Text = this.comm.Eprint_return_Date_Before_View(addDaysToDate(Convert.ToInt32(dt.Rows[0]["DefaultCustomDate5"]), lst).ToString(), this.CompanyID, this.UserID, false);
            }

        }
        public DateTime addDaysToDate(int NoOfDaysToBeAdded, List<string> lst)
        {
            int count = 0;
            DateTime dt = new DateTime();
            if (this.txtOrderedDate.Text.ToString() != "")
            {
                dt = Convert.ToDateTime(this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtOrderedDate.Text));
                while (count < NoOfDaysToBeAdded)
                {
                    dt = dt.AddDays(1);
                    string day = dt.DayOfWeek.ToString();
                    if (lst.Contains(day))
                    {
                        count = count + 1;
                    }
                }
            }
            return dt;
        }
    }
}