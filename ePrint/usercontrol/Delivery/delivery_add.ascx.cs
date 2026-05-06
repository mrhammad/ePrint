using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Company;
using Printcenter.UI.Deliveries;
using Printcenter.UI.Department;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.Delivery
{
    public partial class delivery_add : System.Web.UI.UserControl
    {


        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public long EstimateItemID;

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private BasePage objPage = new BasePage();

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objset = new SettingsBasePage();

        private commonClass objcom = new commonClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public int CompanyID;

        public int UserID;

        public int CustomerID;

        public string DateFormat = "mm/dd/yyyy";

        public string pg = string.Empty;

        public long DelNo;

        public long DeliveryID;

        public long DeliveryItemID;

        public string Type = string.Empty;

        public string newdate = string.Empty;

        public int new_delid;

        private DateTime TodayDate;

        public long TaskID;

        public string ItemType = string.Empty;

        public long ordid;

        public long EstimateID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLangClass = new languageClass();

        public long DepartmentID;

        public long CostCentreID;

        public string ServerName = string.Empty;

        public long Config_DeliveryID;

        public string Mode = "add";

        public string DeliveryNotePrefix = string.Empty;

        public string DeldeletedItemValue = string.Empty;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;
        
        public long DeliveryStatusID;
        public bool isShowDescHeadings = false;

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

        public delivery_add()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.jobID != (long)0)
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
            }
            else if (this.InvoiceID != (long)0)
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, "invoice");
            }
            if (this.ordid != (long)0 && this.EstimateID != (long)0)
            {
                if (empty.ToLower() != "yes")
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID };
                    response.Redirect(string.Concat(estimateID));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (this.EstimateID == (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "delivery/delivery_view.aspx"));
                return;
            }
            if (empty.ToLower() != "yes")
            {
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            HttpResponse httpResponse1 = base.Response;
            object[] objArray1 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID };
            httpResponse1.Redirect(string.Concat(objArray1));
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            DataTable dataTable = DeliveryBasePage.deliveryitem_select(this.CompanyID, Convert.ToInt64(base.Request.Params["id"].ToString()));
            IEnumerator enumerator = dataTable.Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    this.DeliveryItemID = Convert.ToInt64(current["DeliveryItemID"].ToString());
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            DeliveryBasePage.delivery_delete(this.CompanyID, Convert.ToInt64(base.Request.Params["id"]));
            string empty = string.Empty;
            if (this.jobID != (long)0)
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
            }
            else if (this.InvoiceID != (long)0)
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, "invoice");
            }
            long num = EstimatesBasePage.Module_IsConverted_To_NextModule(this.DeliveryItemID, "Del");
            string str = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.EstimateID, "estimate");
            if (this.EstimateID == (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "delivery/delivery_view.aspx?su=de"));
                return;
            }
            if (empty.ToLower() == "yes")
            {
                if (num > (long)0)
                {
                    HttpResponse response = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID };
                    response.Redirect(string.Concat(estimateID));
                    return;
                }
                if (str != "yes")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", this.EstimateID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (num <= (long)0)
            {
                if (str != "yes")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID));
                    return;
                }
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", this.EstimateID };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            if (this.jobID != (long)0)
            {
                if (str == "yes")
                {
                    HttpResponse httpResponse1 = base.Response;
                    object[] objArray1 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID };
                    httpResponse1.Redirect(string.Concat(objArray1));
                    return;
                }
                HttpResponse response2 = base.Response;
                object[] estimateID2 = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID };
                response2.Redirect(string.Concat(estimateID2));
                return;
            }
            if (str == "yes")
            {
                HttpResponse httpResponse2 = base.Response;
                object[] objArray2 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, "&jID=", num };
                httpResponse2.Redirect(string.Concat(objArray2));
                return;
            }
            HttpResponse response3 = base.Response;
            object[] estimateID3 = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, "&jID=", num };
            response3.Redirect(string.Concat(estimateID3));
        }

        protected void btnSave_Onclick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.jobID != (long)0)
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
            }
            else if (this.InvoiceID != (long)0)
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, "invoice");
            }
            long num = this.Save_DeliverNote();
            if (base.Request.Params["type"] == null)
            {
                if (this.hid_Mode.Value != "")
                {
                    HttpResponse response = base.Response;
                    object[] value = new object[] { this.strSitepath, "delivery/templates_view1.aspx?sectionid=", this.hid_ClientID.Value, "&sectionname=DeliveryNote&type=Customer&page=Note&EstID=", num, this.jID, this.InvID };
                    response.Redirect(string.Concat(value));
                    return;
                }
                if (this.ordid != (long)0 && this.EstimateID != (long)0)
                {
                    if (empty.ToLower() == "yes")
                    {
                        HttpResponse httpResponse = base.Response;
                        object[] estimateID = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID, this.InvID };
                        httpResponse.Redirect(string.Concat(estimateID));
                        return;
                    }
                    HttpResponse response1 = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID, this.InvID };
                    response1.Redirect(string.Concat(objArray));
                    return;
                }
                if (this.EstimateID != (long)0)
                {
                    if (empty.ToLower() == "yes")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] estimateID1 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(estimateID1));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    object[] objArray1 = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID };
                    response2.Redirect(string.Concat(objArray1));
                    return;
                }
                if (base.Session["Message"] != null && Convert.ToString(base.Session["Message"]) != String.Empty)
                {
                    string str = base.Session["Message"].ToString();
                    base.Session["Message"] = "";
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("javascript:DisplayStatusMsg('", str, "');"), true);
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "delivery/delivery_view.aspx?su=in"));
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                if (this.hid_Mode.Value != "")
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] value1 = new object[] { this.strSitepath, "delivery/templates_view1.aspx?sectionid=", this.hid_ClientID.Value, "&sectionname=DeliveryNote&type=Customer&page=Note&EstID=", num, this.jID, this.InvID };
                    httpResponse2.Redirect(string.Concat(value1));
                    return;
                }
                if (this.ordid != (long)0 && this.EstimateID != (long)0)
                {
                    if (this.jobID == (long)0)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "delivery/delivery_view.aspx?su=up"));
                        return;
                    }
                    if (empty.ToLower() == "yes")
                    {
                        HttpResponse response3 = base.Response;
                        object[] estimateID2 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID, this.InvID };
                        response3.Redirect(string.Concat(estimateID2));
                        return;
                    }
                    HttpResponse httpResponse3 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID, this.InvID };
                    httpResponse3.Redirect(string.Concat(objArray2));
                    return;
                }
                if (this.EstimateID == (long)0)
                {
                    if (base.Session["Message"] == null || Convert.ToString(base.Session["Message"]) == String.Empty)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "delivery/delivery_view.aspx?su=up"));
                        return;
                    }
                    string str1 = base.Session["Message"].ToString();
                    base.Session["Message"] = "";
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("javascript:DisplayStatusMsg('", str1, "');"), true);
                    return;
                }
                if (this.jobID == (long)0)
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "delivery/delivery_view.aspx?su=up"));
                    return;
                }
                if (empty.ToLower() == "yes")
                {
                    HttpResponse response4 = base.Response;
                    object[] estimateID3 = new object[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID };
                    response4.Redirect(string.Concat(estimateID3));
                    return;
                }
                HttpResponse httpResponse4 = base.Response;
                object[] objArray3 = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "&ordid=", this.EstimateID, this.jID, this.InvID };
                httpResponse4.Redirect(string.Concat(objArray3));
                return;
            }
        }

        protected void btnSaveandStay_Onclick(object sender, EventArgs e)
        {
            long num = this.Save_DeliverNote();
            if (this.ddlcontact.SelectedValue != "" && this.ddlcontact.SelectedValue != "0")
            {
                this.hid_ContactID.Value = this.ddlcontact.SelectedValue;
            }
            if (base.Request.Params["type"] == null)
            {
                if (this.hid_Mode.Value != "")
                {
                    HttpResponse response = base.Response;
                    object[] value = new object[] { this.strSitepath, "delivery/templates_view1.aspx?sectionid=", this.hid_ClientID.Value, "&sectionname=DeliveryNote&type=Customer&page=Note&EstID=", num, this.jID, this.InvID };
                    response.Redirect(string.Concat(value));
                    return;
                }
                if (base.Session["Message"] != null && Convert.ToString(base.Session["Message"]) != String.Empty)
                {
                    string str = base.Session["Message"].ToString();
                    base.Session["Message"] = "";
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("javascript:DisplayStatusMsg('", str, "');"), true);
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] invID = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", num, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(invID));
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                if (this.ordid != (long)0 && this.EstimateID != (long)0)
                {
                    HttpResponse response1 = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", num, "&estid=", this.EstimateID, "&ordid=", this.ordid, this.jID, this.InvID };
                    response1.Redirect(string.Concat(estimateID));
                    return;
                }
                if (this.EstimateID == (long)0)
                {
                    HttpResponse httpResponse1 = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", num, this.jID, this.InvID };
                    httpResponse1.Redirect(string.Concat(objArray));
                    return;
                }
                HttpResponse response2 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", num, "&estid=", this.EstimateID, this.jID, this.InvID };
                response2.Redirect(string.Concat(estimateID1));
                return;
            }
        }

        private void FollowUpTask(long DeliveryID)
        {
            if (this.chk_FollowupTask.Checked && !string.IsNullOrEmpty(this.hidFollowupTask.Value))
            {
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string str3 = string.Empty;
                string empty4 = string.Empty;
                string[] strArrays = this.hidFollowupTask.Value.Split(new char[] { '±' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                    if (string.Compare("assignedto", strArrays1[0], true) == 0)
                    {
                        empty = strArrays1[1];
                    }
                    else if (string.Compare("status", strArrays1[0], true) == 0)
                    {
                        str = this.objBase.SpecialEncode(strArrays1[1]);
                    }
                    else if (string.Compare("subject", strArrays1[0], true) == 0)
                    {
                        empty1 = this.objBase.SpecialEncode(strArrays1[1]);
                    }
                    else if (string.Compare("priority", strArrays1[0], true) == 0)
                    {
                        str1 = strArrays1[1];
                    }
                    else if (string.Compare("contactid", strArrays1[0], true) == 0)
                    {
                        empty2 = strArrays1[1];
                    }
                    else if (string.Compare("txtduedate", strArrays1[0], true) == 0)
                    {
                        str2 = strArrays1[1];
                    }
                    else if (string.Compare("ddlhour", strArrays1[0], true) == 0)
                    {
                        empty3 = strArrays1[1];
                    }
                    else if (string.Compare("ddlminute", strArrays1[0], true) == 0)
                    {
                        str3 = strArrays1[1];
                    }
                    else if (string.Compare("description", strArrays1[0], true) == 0)
                    {
                        empty4 = this.objBase.SpecialEncode(strArrays1[1]);
                    }
                }
                string str4 = string.Concat(empty3, ":", str3);
                int num = Convert.ToInt32(base.Session["userID"]);
                string str5 = DateTime.Now.ToString();
                int num1 = Convert.ToInt32(base.Session["userID"]);
                string str6 = DateTime.Now.ToString();
                string regionalSettings = (new BasePage()).GetRegionalSettings(this.CompanyID, "Dateformat");
                string str7 = this.objBase.DateFormat_Return_As_MM_DD_YYYY(regionalSettings, str2);
                taskClass _taskClass = new taskClass();
                if (base.Request.Params["type"] == null)
                {
                    _taskClass.task_Add("", this.CompanyID, empty1, "", str, str7, str4, Convert.ToInt32(empty2), str1, "deliverynote", (long)this.new_delid, empty4, 0, Convert.ToInt32(empty), num, 0, str5, str6, "", 0);
                }
                else if (base.Request.Params["type"].ToString().ToLower() == "edit")
                {
                    if (this.hdnItemType.Value.ToLower() == "d")
                    {
                        _taskClass.task_Edit(Convert.ToInt32(this.hdnTaskID.Value), this.CompanyID, empty1, "", str, str7, str4, Convert.ToInt32(empty2), str1, "deliverynote", (long)this.new_delid, empty4, 0, Convert.ToInt32(empty), num1, str6, "", 0);
                        return;
                    }
                    if (this.hdnItemType.Value.ToLower() == "e")
                    {
                        if (Convert.ToInt32(this.hdnTaskID.Value) == 0)
                        {
                            _taskClass.task_Add("", this.CompanyID, empty1, "", str, str7, str4, Convert.ToInt32(empty2), str1, "deliverynote", (long)this.new_delid, empty4, 0, Convert.ToInt32(empty), num, 0, str5, str6, "", 0);
                            return;
                        }
                        _taskClass.task_Edit(Convert.ToInt32(this.hdnTaskID.Value), this.CompanyID, empty1, "", str, str7, str4, Convert.ToInt32(empty2), str1, "deliverynote", (long)this.new_delid, empty4, 0, Convert.ToInt32(empty), num1, str6, "", 0);
                        return;
                    }
                }
            }
        }

        private void GetDeletedItemValue()
        {
            DataTable dataTable = DeliveryBasePage.deliveryitem_GetDeletedItemValue(this.CompanyID, this.hdnGetItemTitle.Value);
            if (dataTable.Rows.Count > 1)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    this.DeldeletedItemValue = row["ItemTitle"].ToString();
                }
            }
        }

        protected void lnktaskAdd_OnClick(object sender, EventArgs e)
        {
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/Item/estimate_task_add.ascx");
            this.plhTask.Controls.Add(userControl);
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.txtName.Focus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] chrArray;
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
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() != "edit")
                {
                    this.Mode = "add";
                }
                else
                {
                    this.Mode = "edit";
                }
            }
            if (base.Session["Message"] != null && base.Session["Message"] != null)
            {
                string str = base.Session["Message"].ToString();
                base.Session["Message"] = "";
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("javascript:DisplayStatusMsg('", str, "');"), true);
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
                if (this.ServerName.ToLower() == "dmc" || this.ServerName.ToLower() == "dmc2")
                {
                    this.spn_CourierInfo.Attributes.Add("style", "display:block");
                    this.spn_CourierInfo.Attributes.Add("style", "color:red");
                }
                else
                {
                    this.spn_CourierInfo.Attributes.Add("style", "display:none");
                }
            }
            long deliveryStatusID = ConnectionClass.DeliveryStatusID;
            this.DeliveryStatusID = ConnectionClass.DeliveryStatusID;
            this.Config_DeliveryID = ConnectionClass.DeliveryStatusID;
            if (ConnectionClass.DeliveryNotePrefix != null)
            {
                this.DeliveryNotePrefix = ConnectionClass.DeliveryNotePrefix;
            }
            string empty = string.Empty;
            if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.ImageButton8.Visible = true;
                this.DivImageButton1.Visible = true;
                this.DivimgcmdHeader.Visible = true;
                this.DivImageButton6.Visible = true;
                this.DivimgbtnSupplier.Visible = true;
                this.DivButton1.Visible = true;
                this.Divdiv_btnsave.Visible = true;
                this.DivStay.Visible = true;
            }
            else
            {
                this.ImageButton8.Visible = false;
                this.DivImageButton1.Visible = false;
                this.DivimgcmdHeader.Visible = false;
                this.DivImageButton6.Visible = false;
                this.DivimgbtnSupplier.Visible = false;
                this.DivButton1.Visible = false;
                this.Divdiv_btnsave.Visible = false;
                this.DivStay.Visible = false;
            }
            string empty1 = string.Empty;
            string strRemove = this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isremove", this.Page.Request.Url.ToString());
            if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.DivButton2.Visible = true;
                this.DivbtnDelete.Visible = true;
            }
            else
            {
                if(strRemove.Trim() == "1")
                {
                    this.DivButton2.Visible = true;
                    this.DivbtnDelete.Visible = true;
                }
                else
                {
                    this.DivButton2.Visible = false;
                    this.DivbtnDelete.Visible = false;
                }
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.pg = "deliverynote";
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.txtName.Focus();
            this.txtName.Attributes.Add("autocomplete", "off");
            this.DelNo = this.objComp.settings_lastcounter_select(this.CompanyID, "d") + (long)1;

            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                this.isShowDescHeadings= row["chkIsAddDescHeadings"] != DBNull.Value
    ? Convert.ToBoolean(row["chkIsAddDescHeadings"])
    : false;
               
            }

            commonClass _commonClass = this.objcom;
            string dateFormat = this.DateFormat;
            commonClass _commonClass1 = this.objcom;
            DateTime now = DateTime.Now;
            _commonClass.date_Check_new(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
            this.TodayDate = DateTime.Now;
            if (base.Request.Params["ordid"] != null)
            {
                this.ordid = Convert.ToInt64(base.Request.Params["ordid"]);
            }
            this.EstimateID = (long)0;
            if (base.Request.Params["type"] != null && base.Request.Params["estid"] != null)
            {
                this.EstimateID = (long)Convert.ToInt32(base.Request.Params["estid"].ToString());
            }
            if (!base.IsPostBack)
            {
                this.txtName.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
                this.txtName.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
                this.objset.Bind_Status_new(this.ddlStatus, this.CompanyID, string.Concat("--- ", this.objLangClass.GetLanguageConversion("Select"), " ---"), "delivery");
                int defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
                int num = 0;
                while (num < this.ddlStatus.Items.Count)
                {
                    if (this.ddlStatus.Items[num].Value != Convert.ToString(defaultStatusID))
                    {
                        num++;
                    }
                    else
                    {
                        this.ddlStatus.SelectedIndex = num;
                        break;
                    }
                }
            }
            // added check to add new delivery note
            if (base.Request.Params["id"] != null)
            {
                this.DeliveryID = Convert.ToInt64(base.Request.Params["id"].ToString());
            }
            if (!base.IsPostBack)
            {
                long delNo = (long)10000000 + this.DelNo;
                this.lblDeliveryNumber.Text = string.Concat(this.DeliveryNotePrefix, delNo.ToString().Substring(1, delNo.ToString().Length - 1));
                foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Footer").Rows)
                {
                    this.lblFooter.Text = row["LimitPhraseText"].ToString();
                    this.lblFooter.ToolTip = row["PhraseText"].ToString();
                    this.hid_FooterID.Value = row["PhraseBookID"].ToString();
                    this.hid_FooterText.Value = row["PhraseText"].ToString();
                }
                foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Delivery Note Header").Rows)
                {
                    this.lblHeaderText.Text = dataRow["LimitPhraseText"].ToString();
                    this.lblHeaderText.ToolTip = dataRow["PhraseText"].ToString();
                    this.hid_HeaderID.Value = dataRow["PhraseBookID"].ToString();
                    this.hid_HeaderText.Value = dataRow["PhraseText"].ToString();
                }
                TextBox textBox = this.txtDeliveryDate;
                commonClass _commonClass2 = this.objcom;
                DateTime dateTime = DateTime.Now;
                textBox.Text = _commonClass2.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                this.txtDeliveryDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox1 = this.txtActualDeliveryDate;
                commonClass _commonClass3 = this.objcom;
                DateTime now1 = DateTime.Now;
                textBox1.Text = _commonClass3.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                this.txtActualDeliveryDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                commonClass _commonClass4 = this.objcom;
                DateTime dateTime1 = DateTime.Now;
                string str1 = _commonClass4.Eprint_return_DateTime_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, true);
                chrArray = new char[] { ' ' };
                string[] strArrays = str1.Split(chrArray);
                string str2 = Convert.ToString(strArrays[1]);
                string str3 = Convert.ToString(strArrays[2]);
                string str4 = string.Concat(str2, str3);
                this.RadTimePicker.SelectedDate = new DateTime?(Convert.ToDateTime(str4));
                this.div_ActualDeliveryDate.Attributes.Add("style", "display:none");
                DataTable dataTable = new DataTable();
                dataTable = Settings.Setting_accountingCode_SelectAllRevenueCode(this.CompanyID);
                this.ddlAccount_Code.DataSource = dataTable;
                this.ddlAccount_Code.DataValueField = "AccountCodeID";
                this.ddlAccount_Code.DataTextField = "Code";
                this.ddlAccount_Code.DataBind();
                if (!base.IsPostBack)
                {
                    this.objComp.company_carrier_supplier_select(this.CompanyID, this.ddlSupplier);
                    this.ddlSupplier.Items[0].Text = string.Concat("--- ", this.objLangClass.GetLanguageConversion("Select"), " ---");
                    if (base.Request.QueryString["suplrid"] != null)
                    {
                        this.objBase.SetDDLValue(this.ddlSupplier, base.Request.QueryString["suplrid"].ToString());
                    }
                }
                if (base.Request.Params["type"] == null)
                {
                    foreach (DataRow row1 in dataTable.Rows)
                    {
                        if (row1["isDefault"].ToString().ToLower().Trim() != "true")
                        {
                            continue;
                        }
                        this.objBase.SetDDLValue(this.ddlAccount_Code, row1["AccountCodeID"].ToString());
                        break;
                    }
                    this.imgbtnSupplier.PostBackUrl = string.Concat(this.strSitepath, "client/client_add.aspx?type=Supplier&post=delivery");
                    this.ImgCustomerAdd.PostBackUrl = string.Concat(this.strSitepath, "client/client_add.aspx?type=Customer&post=delivery");
                }
                else
                {
                    this.Type = base.Request.Params["type"].ToString().ToLower();
                    if (base.Request.Params["type"].ToString().ToLower() == "edit")
                    {
                        this.divEstNo.Visible = true;
                        ImageButton imageButton = this.imgbtnSupplier;
                        string[] lower = new string[] { this.strSitepath, "client/client_add.aspx?type=Supplier&post=delivery&mode=", base.Request.Params["type"].ToString().ToLower(), "&id=", base.Request.Params["id"].ToString() };
                        imageButton.PostBackUrl = string.Concat(lower);
                        ImageButton imgCustomerAdd = this.ImgCustomerAdd;
                        string[] lower1 = new string[] { this.strSitepath, "client/client_add.aspx?type=Customer&post=delivery&mode=", base.Request.Params["type"].ToString().ToLower(), "&id=", base.Request.Params["id"].ToString() };
                        imgCustomerAdd.PostBackUrl = string.Concat(lower1);
                        this.btnDelete.Visible = true;
                        this.DeliveryID = Convert.ToInt64(base.Request.Params["id"].ToString());
                        this.hid_DeliveryID.Value = base.Request.Params["id"].ToString();
                        if (base.Request.QueryString["cntct"] == null)
                        {
                            foreach (DataRow dataRow1 in DeliveryBasePage.delivery_select(this.CompanyID, this.DeliveryID).Rows)
                            {
                                this.hid_ClientID.Value = dataRow1["CustomerID"].ToString();
                                this.CustomerID = Convert.ToInt32(dataRow1["CustomerID"].ToString());
                                if (dataRow1["AttentionID"].ToString() != "0")
                                {
                                    this.hid_ContactID.Value = dataRow1["AttentionID"].ToString();
                                }
                                this.hid_DeliveryAddressID.Value = dataRow1["DeliveryaddressID"].ToString();
                                this.hid_DelAddressType.Value = dataRow1["DeliveryAddressType"].ToString();
                                this.hdn_departmentid.Value = dataRow1["DepartmentID"].ToString();
                                this.hdn_selectedcentre.Value = dataRow1["CostCentreID"].ToString();
                                if (Convert.ToInt32(dataRow1["DeliveryToClientID"].ToString()) != 0)
                                {
                                    this.hid_DeliveryToClientID.Value = dataRow1["DeliveryToClientID"].ToString();
                                }
                                else
                                {
                                    this.hid_DeliveryToClientID.Value = dataRow1["CustomerID"].ToString();
                                }
                                string[] strArrays1 = dataRow1["ContactList"].ToString().Split(new char[] { '±' });
                                for (int i = 0; i < (int)strArrays1.Length; i++)
                                {
                                    string[] strArrays2 = strArrays1[i].Split(new char[] { '»' });
                                    ListItem listItem = new ListItem();
                                    try
                                    {
                                        listItem.Text = this.objBase.SpecialDecode(strArrays2[1]);
                                        listItem.Value = strArrays2[0];
                                        this.ddlcontact.Items.Add(listItem);
                                    }
                                    catch
                                    {
                                    }
                                }
                                this.txtName.Text = this.objBase.SpecialDecode(dataRow1["CustomerName"].ToString());
                                this.hid_Clientname.Value = dataRow1["CustomerName"].ToString();
                                if (dataRow1["AttentionID"].ToString() != "0")
                                {
                                    this.hid_ContactID.Value = dataRow1["AttentionID"].ToString();
                                }
                                this.objBase.SetDDLValue(this.ddlcontact, dataRow1["AttentionID"].ToString());
                                this.txtCompany.Text = this.objBase.SpecialDecode(dataRow1["ShippedTo"].ToString());
                                //this.lbl_CompanyName.Text = this.objBase.SpecialDecode(dataRow1["companyname"].ToString());
                                //this.lbl_CompanyName.ToolTip = this.objBase.SpecialDecode(dataRow1["companyname"].ToString());

                                this.lbl_CompanyName.Text = this.objBase.SpecialDecode(dataRow1["AddressLabel"].ToString());
                                this.lbl_CompanyName.ToolTip = this.objBase.SpecialDecode(dataRow1["AddressLabel"].ToString());

                                this.lblDeliveryAddress.Text = this.objBase.SpecialDecode(dataRow1["Deliveryaddress"].ToString());
                                this.lblDeliveryAddress.ToolTip = this.objBase.SpecialDecode(dataRow1["Deliveryaddress"].ToString());
                                this.lblFooter.Text = this.objBase.SpecialDecode(dataRow1["Footer"].ToString());
                                this.lblFooter.ToolTip = this.objBase.SpecialDecode(dataRow1["Footer"].ToString());
                                this.hid_FooterText.Value = dataRow1["Footer"].ToString();
                                this.lblHeaderText.Text = this.objBase.SpecialDecode(dataRow1["Header"].ToString());
                                this.lblHeaderText.ToolTip = this.objBase.SpecialDecode(dataRow1["Header"].ToString());
                                this.hid_HeaderText.Value = dataRow1["Header"].ToString();
                                this.txtComments.Text = this.objBase.SpecialDecode(dataRow1["Comments"].ToString());
                                this.lblDeliveryNumber.Text = this.objBase.SpecialDecode(dataRow1["DeliveryNumber"].ToString());
                                this.txtRefNo.Text = this.objBase.SpecialDecode(dataRow1["RefNo"].ToString());
                                this.txtOrderNumber.Text = this.objBase.SpecialDecode(dataRow1["OrderNo"].ToString());
                                this.objBase.SetDDLValue(this.ddlSupplier, dataRow1["CarrierID"].ToString());
                                this.objBase.SetDDLValue(this.ddlStatus, dataRow1["Status"].ToString());
                                this.objBase.SetDDLValue(this.ddlAccount_Code, dataRow1["AccountCodeID"].ToString());
                                this.txtConsignment_Note_Number.Text = this.objBase.SpecialDecode(dataRow1["ConsignmentNumber"].ToString());
                                this.txtconsigneeurl.Text = this.objBase.SpecialDecode(dataRow1["ConsigneeUrl"].ToString());
                                this.txtDeliveryDate.Text = dataRow1["DeliveryDate"].ToString();
                                string dateOnRegionalSettings = this.objPage.GetDateOnRegionalSettings(this.CompanyID, this.txtDeliveryDate.Text, "regional");
                                this.txtDeliveryDate.Text = dateOnRegionalSettings;
                                this.txtDeliveryDate.Text = (this.txtDeliveryDate.Text.ToString() == "01/01/1900" ? "" : this.objcom.Eprint_return_Date_Before_View(this.txtDeliveryDate.Text.ToString(), this.CompanyID, this.UserID, false));
                                this.chkGoodsDelivered.Checked = Convert.ToBoolean(dataRow1["GoodsDelivered"].ToString());
                                this.txtActualDeliveryDate.Text = dataRow1["ActualDeliveryDate"].ToString();
                                string dateOnRegionalSettings1 = this.objPage.GetDateOnRegionalSettings(this.CompanyID, this.txtActualDeliveryDate.Text, "regional");
                                this.txtActualDeliveryDate.Text = dateOnRegionalSettings1;
                                this.txtActualDeliveryDate.Text = (this.txtActualDeliveryDate.Text.ToString() == "01/01/1900" ? "" : this.objcom.Eprint_return_Date_Before_View(this.txtActualDeliveryDate.Text.ToString(), this.CompanyID, this.UserID, false));
                                if (!this.chkGoodsDelivered.Checked)
                                {
                                    this.chkGoodsDelivered.Enabled = true;
                                }
                                else
                                {
                                    this.chkGoodsDelivered.Enabled = false;
                                }
                                if (!this.chkGoodsDelivered.Checked)
                                {
                                    TextBox textBox2 = this.txtActualDeliveryDate;
                                    commonClass _commonClass5 = this.objcom;
                                    DateTime now2 = DateTime.Now;
                                    textBox2.Text = _commonClass5.Eprint_return_Date_Before_View(now2.ToShortDateString(), this.CompanyID, this.UserID, false);
                                }
                                else
                                {
                                    this.RadTimePicker.SelectedDate = new DateTime?(Convert.ToDateTime(dataRow1["ActualDeliveryDate"].ToString()));
                                    this.div_ActualDeliveryDate.Attributes.Add("style", "display:block");
                                }
                                this.TaskID = Convert.ToInt64(dataRow1["TaskID"]);
                                this.hdnTaskID.Value = this.TaskID.ToString();
                                if (this.TaskID > (long)0)
                                {
                                    this.chk_FollowupTask.Checked = true;
                                }
                                this.hdnItemType.Value = dataRow1["ItemType"].ToString();
                            }
                        }
                        else if (base.Request.QueryString["cntct"].ToString().ToLower() == "new")
                        {
                            this.ddlcontact.SelectedValue = "";
                        }
                        System.Type type = base.GetType();
                        object[] companyID = new object[] { "javascript:CallLoadCostCentre(", this.CompanyID, ",", this.CustomerID, ",", this.hdn_departmentid.Value, ",", 0, ");" };
                        ScriptManager.RegisterStartupScript(this, type, " ", string.Concat(companyID), true);
                        int num1 = 0;
                        DataTable dataTable1 = DeliveryBasePage.deliveryitem_select(this.CompanyID, Convert.ToInt64(base.Request.Params["id"].ToString()));
                        foreach (DataRow row2 in dataTable1.Rows)
                        {
                            this.DeliveryItemID = Convert.ToInt64(row2["DeliveryItemID"].ToString());
                            long num2 = Convert.ToInt64(row2["ItemID"].ToString());
                            string str5 = row2["ItemType"].ToString();
                            string str6 = row2["Quantity"].ToString();
                            string str7 = row2["Description"].ToString().Replace("<br/>", " - ");
                            long itemNo = Convert.ToInt64(row2["ItemNo"]);
                            this.hid_Max_Del_Item_No.Value = Convert.ToString(row2["MaxDelItemNo"]);
                            string notes = Convert.ToString(row2["Notes"]);
                            HiddenField hidDelEditValues = this.hid_Del_Edit_values;
                            object value = hidDelEditValues.Value;
                            companyID = new object[] { value, "DeliveryItemID«", this.DeliveryItemID, "‡ItemID«", num2, "‡" };
                            hidDelEditValues.Value = string.Concat(companyID);
                            HiddenField hiddenField = this.hid_Del_Edit_values;
                            string value1 = hiddenField.Value;
                            lower = new string[] { value1, "ItemType«", str5, "‡ItemQty«", str6, "‡" };
                            hiddenField.Value = string.Concat(lower);
                            HiddenField hidDelEditValues1 = this.hid_Del_Edit_values;
                            hidDelEditValues1.Value = string.Concat(hidDelEditValues1.Value, "ItemNo«", itemNo, "‡");
                            hidDelEditValues1.Value = string.Concat(hidDelEditValues1.Value, "ItemNotes«", notes, "‡");
                            hidDelEditValues1.Value = string.Concat(hidDelEditValues1.Value, "ItemDesc«", str7, "§");
                            this.hdnGetItemTitle.Value = str7;
                            this.hdnsavestay.Value = str6;
                            this.pnlLoadOnEdit.Visible = true;
                            num1++;
                        }
                        this.GetSaveCount.Value = num1.ToString();
                    }
                }
            }
            if (base.Request.QueryString["clientid"] != null)
            {
                this.objBase.SetDDLValue(this.ddlSupplier, base.Request.QueryString["clientid"].ToString());
                DataTable dataTable2 = CompanyBasePage.company_client_select(this.CompanyID, Convert.ToInt32(base.Request.QueryString["clientid"]), "customer");
                foreach (DataRow dataRow2 in dataTable2.Rows)
                {
                    this.txtName.Text = this.objBase.SpecialDecode(dataRow2["ClientName"].ToString());
                    this.hid_ClientID.Value = dataRow2["clientID"].ToString();
                    this.txtCompany.Text = this.objBase.SpecialDecode(dataRow2["ClientName"].ToString());
                }
            }
            this.txtName.Focus();
            this.ImgCustomerAdd.ToolTip = this.objLangClass.GetLanguageConversion("Add_New_Customer");
            this.Label1.Text = this.objLangClass.GetLanguageConversion("Contact");
            this.Label20.Text = this.objLangClass.GetLanguageConversion("Company");
            this.Label2.Text = this.objLangClass.GetLanguageConversion("Shipped_To");
            this.Label12.Text = this.objLangClass.GetLanguageConversion("Delivery_Address");
            this.Label5.Text = this.objLangClass.GetLanguageConversion("Comments");
            this.lblHeader.Text = this.objLangClass.GetLanguageConversion("Header");
            this.Label9.Text = this.objLangClass.GetLanguageConversion("Footer");
            this.Label14.Text = this.objLangClass.GetLanguageConversion("Delivery_Note_Number");
            this.Label13.Text = this.objLangClass.GetLanguageConversion("Ref_No");
            this.Label15.Text = this.objLangClass.GetLanguageConversion("Customer_Order_Number");
            this.Label3.Text = this.objLangClass.GetLanguageConversion("Carrier_Information");
            this.imgbtnSupplier.ToolTip = this.objLangClass.GetLanguageConversion("Add_Carrier");
            this.lblConsig_Note_Numb.Text = this.objLangClass.GetLanguageConversion("Consignment_Note_Number");
            this.lblConsingneeurl.Text = this.objLangClass.GetLanguageConversion("Consignee_url");
            this.Label16.Text = this.objLangClass.GetLanguageConversion("Delivery_Date");
            this.Label4.Text = this.objLangClass.GetLanguageConversion("Goods_Delivered");
            this.lblActualDeliveryDate.Text = this.objLangClass.GetLanguageConversion("Actual_Delivery_Date");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btn_SaveandStay.Text = this.objLangClass.GetLanguageConversion("Save_Stay");
            this.btnSave.Text = this.objLangClass.GetLanguageConversion("Save");
            this.btnDelete.Text = this.objLangClass.GetLanguageConversion("Delete");
            //this.Label21.Text = this.objLangClass.GetLanguageConversion("Quantity");
            this.Label21.Text = this.objLangClass.GetLanguageConversion("Quantity_Delivered");
            this.lblItemNotes.Text = "Delivery Item Notes";
            this.lblItemNo.Text = "Delivery Item No.";
            this.Label29.Text = this.objLangClass.GetLanguageConversion("Description");
            this.Button1.Text = this.objLangClass.GetLanguageConversion("Add");
            this.Button2.Text = this.objLangClass.GetLanguageConversion("Delete");
            if (base.Request.QueryString["contactid"] != null)
            {
                HiddenField hidContactID = this.hid_ContactID;
                int num3 = Convert.ToInt32(base.Request.QueryString["contactid"]);
                hidContactID.Value = num3.ToString();
                DataTable dataTable3 = EstimatesBasePage.Clients_New_Contact_Select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value));
                foreach (DataRow row3 in dataTable3.Rows)
                {
                    if (!string.IsNullOrEmpty(row3["ContactList"].ToString()))
                    {
                        string str8 = row3["ContactList"].ToString();
                        chrArray = new char[] { '±' };
                        string[] strArrays3 = str8.Split(chrArray);
                        for (int j = 0; j < (int)strArrays3.Length; j++)
                        {
                            string str9 = strArrays3[j];
                            chrArray = new char[] { '»' };
                            string[] strArrays4 = str9.Split(chrArray);
                            ListItem listItem1 = new ListItem()
                            {
                                Text = this.objBase.SpecialDecode(strArrays4[1]),
                                Value = strArrays4[0]
                            };
                            this.ddlcontact.Items.Add(listItem1);
                        }
                    }
                    this.txtCompany.Text = this.objBase.SpecialDecode(row3["Department"].ToString());
                    this.lblDeliveryAddress.Text = this.objBase.SpecialDecode(row3["DefaultDeliveryaddress"].ToString());
                    this.hid_DeliveryAddressID.Value = row3["DeliveryAddressID"].ToString();
                    this.lbl_CompanyName.Text = this.objBase.SpecialDecode(row3["companyname"].ToString());
                }
                if (this.ddlcontact.SelectedValue != "")
                {
                    this.hid_ContactID.Value = this.ddlcontact.SelectedValue;
                }
                this.objBase.SetDDLValue(this.ddlcontact, this.hid_ContactID.Value.ToString());
            }
            if (base.Request.QueryString["cntct"] != null)
            {
                if (base.Request.QueryString["cntct"].ToString().ToLower() == "new" && this.hid_ContactID.Value == "")
                {
                    this.ddlcontact.SelectedValue = "";
                    return;
                }
            }
            else if (base.Request.Params["type"] != null && base.Request.QueryString["type"].ToString().ToLower() == "edit" && !base.IsPostBack)
            {
                DataSet dataSet = DepartmentBaseClass.CRM_Contact_select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value));
                DataTable item = dataSet.Tables[0];
                if (item != null && item.Rows.Count > 0)
                {
                    this.ddlcontact.DataSource = item;
                    this.ddlcontact.DataTextField = "ContactName";
                    this.ddlcontact.DataValueField = "ContactID";
                    this.ddlcontact.DataBind();
                    this.ddlcontact.Items.Insert(0, new ListItem("---Select---", "0"));
                    for (int k = 0; k < this.ddlcontact.Items.Count; k++)
                    {
                        if (this.ddlcontact.Items[k].Value == this.hid_ContactID.Value.ToString())
                        {
                            this.ddlcontact.SelectedValue = this.hid_ContactID.Value.ToString();
                            this.objBase.SetDDLValue(this.ddlcontact, this.hid_ContactID.Value.ToString());
                            return;
                        }
                    }
                }
            }
        }

        public long Save_DeliverNote()
        {
            base.Session["Message"] = "";
            string empty = string.Empty;
            long num = (long)0;
            DateTime now = DateTime.Now;
            this.txtDeliveryDate.Text = this.objBase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtDeliveryDate.Text);
            long num1 = (long)0;
            if (base.Request.Params["type"] != null && base.Request.Params["estid"] != null)
            {
                num1 = (long)Convert.ToInt32(base.Request.Params["estid"].ToString());
            }
            DateTime value = this.RadTimePicker.SelectedDate.Value;
            string str = value.ToLongTimeString().ToString();
            string text = this.txtActualDeliveryDate.Text;
            char[] chrArray = new char[] { ' ' };
            string str1 = text.Split(chrArray)[0];
            this.txtActualDeliveryDate.Text = str1;
            if (!this.chkGoodsDelivered.Checked)
            {
                this.txtActualDeliveryDate.Text = "1900-01-01 00:00:00.000";
            }
            else
            {
                this.txtActualDeliveryDate.Text = string.Concat(this.objBase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtActualDeliveryDate.Text), " ", str);
            }
            int num2 = 0;
            if (this.ddlAccount_Code.Items.Count > 0)
            {
                num2 = Convert.ToInt32(this.ddlAccount_Code.SelectedValue);
            }
            if (base.Request.Params["type"] == null)
            {
                this.DeliveryID = (long)0;
                num = DeliveryBasePage.delivery_insert(this.DeliveryID, this.CompanyID, (long)0, (long)0, "D", Convert.ToInt32(this.hid_ClientID.Value), Convert.ToInt32(this.hid_ContactID.Value), this.objBase.SpecialEncode(this.txtCompany.Text), Convert.ToInt64(this.hid_DeliveryAddressID.Value), this.hid_DelAddressType.Value, this.objBase.SpecialEncode(this.hid_FooterText.Value), this.objBase.SpecialEncode(this.txtComments.Text), this.lblDeliveryNumber.Text, Convert.ToDateTime(this.txtDeliveryDate.Text), this.objBase.SpecialEncode(this.txtRefNo.Text), this.objBase.SpecialEncode(this.txtOrderNumber.Text), this.chkGoodsDelivered.Checked, Convert.ToInt32(this.ddlSupplier.SelectedValue), this.UserID, Convert.ToInt32(this.ddlStatus.SelectedValue), now, 0, this.DelNo, this.objBase.SpecialEncode(this.hid_HeaderText.Value), this.TodayDate, Convert.ToInt32(this.hid_DeliveryToClientID.Value), this.objBase.SpecialEncode(this.txtConsignment_Note_Number.Text), this.objBase.SpecialEncode(this.txtconsigneeurl.Text), Convert.ToDateTime(this.txtActualDeliveryDate.Text), Convert.ToInt64(this.hdn_costcentreid.Value), this.DeliveryNotePrefix);
                DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num, num2);
                this.objnotes.Delivery_number = this.lblDeliveryNumber.Text;
                this.objnotes.ModuleName = "delivery";
                this.objnotes.ModuleID = num;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelCreated);
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass = this.objcom;
                DateTime dateTime = DateTime.Now;
                _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                this.objcom.SendInternalMailOnModuleStatusChange(this.CompanyID, num, Convert.ToInt32(ddlStatus.SelectedValue) , this.objnotes.ModuleName);
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                if (base.Request.Params["id"] != null)
                {
                    this.DeliveryID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    foreach (DataRow row in EstimateBasePage.DeliveryNote_ItemID_Select(this.DeliveryID).Rows)
                    {
                        num1 = Convert.ToInt64(row["EstimateID"]);
                    }
                }
                num = DeliveryBasePage.delivery_insert(this.DeliveryID, this.CompanyID, num1, (long)0, "E", Convert.ToInt32(this.hid_ClientID.Value), Convert.ToInt32(this.hid_ContactID.Value), this.objBase.SpecialEncode(this.txtCompany.Text), Convert.ToInt64(this.hid_DeliveryAddressID.Value), this.hid_DelAddressType.Value, this.objBase.SpecialEncode(this.hid_FooterText.Value), this.objBase.SpecialEncode(this.txtComments.Text), this.lblDeliveryNumber.Text, Convert.ToDateTime(this.txtDeliveryDate.Text), this.objBase.SpecialEncode(this.txtRefNo.Text), this.objBase.SpecialEncode(this.txtOrderNumber.Text), this.chkGoodsDelivered.Checked, Convert.ToInt32(this.ddlSupplier.SelectedValue), this.UserID, Convert.ToInt32(this.ddlStatus.SelectedValue), now, this.UserID, this.DelNo, this.objBase.SpecialEncode(this.hid_HeaderText.Value), this.TodayDate, Convert.ToInt32(this.hid_DeliveryToClientID.Value), this.objBase.SpecialEncode(this.txtConsignment_Note_Number.Text), this.objBase.SpecialEncode(this.txtconsigneeurl.Text), Convert.ToDateTime(this.txtActualDeliveryDate.Text), Convert.ToInt64(this.hdn_costcentreid.Value), this.DeliveryNotePrefix);
                DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num, num2);
                this.objnotes.Delivery_number = this.lblDeliveryNumber.Text;
                this.objnotes.ModuleName = "delivery";
                this.objnotes.ModuleID = this.DeliveryID;
                if (this.hdnDeleteMsg.Value != "DeleteMsg")
                {
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelUpdate);
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    this.objnotes.Status_name = this.ddlStatus.SelectedItem.Text;
                    notesclass _notesclass1 = this.objnotes;
                    commonClass _commonClass1 = this.objcom;
                    DateTime now1 = DateTime.Now;
                    _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                }
                this.objcom.SendInternalMailOnModuleStatusChange(this.CompanyID, this.DeliveryID, Convert.ToInt32(ddlStatus.SelectedValue), this.objnotes.ModuleName);

            }
            if (base.Request.Params["type"] == null)
            {
                this.new_delid = Convert.ToInt32(num);
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                this.new_delid = Convert.ToInt32(base.Request.Params["id"].ToString());
            }
            this.FollowUpTask(Convert.ToInt64(this.new_delid));
            if (num <= (long)0)
            {
                return num;
            }
            long num3 = (long)0;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            long itemNo = (long)0;
            string notes = string.Empty;
            string empty3 = string.Empty;
            long num4 = (long)0;
            this.hdn_KitStockValues.Value = "";
            string[] strArrays = this.hid_ItemValues.Value.Split(new char[] { '\u00A7' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '‡' });
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    string[] strArrays2 = strArrays1[j].Split(new char[] { '«' });
                    if (strArrays2[0] == "DeliveryItemID")
                    {
                        if (strArrays2[1] != "")
                        {
                            this.DeliveryItemID = Convert.ToInt64(strArrays2[1].ToString());
                        }
                        else
                        {
                            this.DeliveryItemID = (long)0;
                        }
                    }
                    if (strArrays2[0] == "ItemID")
                    {
                        num3 = (strArrays2[1] != "" ? Convert.ToInt64(strArrays2[1].ToString()) : (long)0);
                    }
                    else if (strArrays2[0] == "ItemType")
                    {
                        empty1 = (strArrays2[1] != "" ? strArrays2[1] : "D");
                    }
                    else if (strArrays2[0] == "ItemQty")
                    {
                        empty2 = (strArrays2[1] != "" ? strArrays2[1].ToString() : "");
                    }
                    else if (strArrays2[0] == "ItemDesc")
                    {
                        str2 = (strArrays2[1] != "" ? strArrays2[1] : "Enter line detail here");
                    }
                    else if (strArrays2[0] == "ItemNo")
                    {
                        itemNo = (strArrays2[1] != "" ? Convert.ToInt64(strArrays2[1].ToString()) : (long)1);
                    }
                    else if (strArrays2[0] == "ItemNotes")
                    {
                        notes = (strArrays2[1] != "" ? strArrays2[1] : "Enter line detail here");
                    }
                    else if (strArrays2[0] == "RowNumber")
                    {
                        num4 = Convert.ToInt64(strArrays2[1].ToString());
                    }
                }
                if (this.DeliveryID != (long)0 && this.hid_DeletedItemID.Value != null)
                {
                    string[] strArrays3 = this.hid_DeletedItemID.Value.Split(new char[] { 'µ' });
                    for (int k = 0; k < (int)strArrays3.Length - 1; k++)
                    {
                        DeliveryBasePage.deliveryitem_delete(this.CompanyID, Convert.ToInt64(strArrays3[k].ToString()), Convert.ToInt64(base.Request.Params["id"].ToString()));
                    }
                }
                DeliveryBasePage.deliveryitem_insert(this.CompanyID, this.DeliveryItemID, num, num1, num3, empty1, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(str2), itemNo, this.objBase.SpecialEncode(notes), num4);
            }
            return num;
        }

        protected void lnkDeliveryCopy_OnClick(object sender, EventArgs e)
        {
            long num = (long)0;
            long num1 = (long)0;
            int defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "delivery", 0);
            foreach (DataRow dataRow1 in DeliveryBasePage.delivery_select(this.CompanyID, this.DeliveryID).Rows)
            {
                string clientID = dataRow1["CustomerID"].ToString();
                string contactID = string.Empty;
                if (dataRow1["AttentionID"].ToString() != "0")
                {
                    contactID = dataRow1["AttentionID"].ToString();
                }
                string deliveryAddressID = dataRow1["DeliveryaddressID"].ToString();
                string delAddressType = dataRow1["DeliveryAddressType"].ToString();
                string shippedTo = this.objBase.SpecialDecode(dataRow1["ShippedTo"].ToString());
                string footer = this.objBase.SpecialDecode(dataRow1["Footer"].ToString());
                string header = this.objBase.SpecialDecode(dataRow1["Header"].ToString());
                string comments = this.objBase.SpecialDecode(dataRow1["Comments"].ToString());
                string deliveryNumber = this.objBase.SpecialDecode(dataRow1["DeliveryNumber"].ToString());
                string refNo = this.objBase.SpecialDecode(dataRow1["RefNo"].ToString());
                string orderNumber = this.objBase.SpecialDecode(dataRow1["OrderNo"].ToString());
                string carrierID =dataRow1["CarrierID"].ToString();
                string status=  dataRow1["Status"].ToString();
                string AccountCodeID= dataRow1["AccountCodeID"].ToString();
                string consignment_Note_Number = this.objBase.SpecialDecode(dataRow1["ConsignmentNumber"].ToString());
                string consigneeurl = this.objBase.SpecialDecode(dataRow1["ConsigneeUrl"].ToString());
                string deliveryDate = dataRow1["DeliveryDate"].ToString();
                DateTime value = this.RadTimePicker.SelectedDate.Value;
                string str = value.ToLongTimeString().ToString();
                string text = this.txtActualDeliveryDate.Text;
                char[] chrArray = new char[] { ' ' };
                string str1 = text.Split(chrArray)[0];
                this.txtActualDeliveryDate.Text = str1;
                this.txtDeliveryDate.Text = this.objBase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtDeliveryDate.Text);
                this.txtActualDeliveryDate.Text = str1;
                if (!this.chkGoodsDelivered.Checked)
                {
                    this.txtActualDeliveryDate.Text = "1900-01-01 00:00:00.000";
                }
                else
                {
                    this.txtActualDeliveryDate.Text = string.Concat(this.objBase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtActualDeliveryDate.Text), " ", str);
                }


                bool chkGoodsDelivered = Convert.ToBoolean(dataRow1["GoodsDelivered"].ToString());
                this.TaskID = Convert.ToInt64(dataRow1["TaskID"]);
                string itemType = dataRow1["ItemType"].ToString();
                string goodsDelivered = dataRow1["GoodsDelivered"].ToString();
                if (base.Request.Params["id"] != null)
                {
                    this.DeliveryID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    foreach (DataRow row in EstimateBasePage.DeliveryNote_ItemID_Select(this.DeliveryID).Rows)
                    {
                        num1 = Convert.ToInt64(row["EstimateID"]);
                    }
                }
                DateTime now = DateTime.Now;
                this.DeliveryID = (long)0;
                int num2 = 0;
                if (this.ddlAccount_Code.Items.Count > 0)
                {
                    num2 = Convert.ToInt32(this.ddlAccount_Code.SelectedValue);
                }

                //num = DeliveryBasePage.delivery_insert(this.DeliveryID, this.CompanyID, this.EstimateID, this.DeliveryItemID, itemType, Convert.ToInt32(clientID), Convert.ToInt32(contactID), objBase.SpecialEncode(shippedTo), Convert.ToInt64(deliveryAddressID), delAddressType, objBase.SpecialEncode(footer), objBase.SpecialEncode(comments), deliveryNumber, Convert.ToDateTime(this.txtDeliveryDate.Text), objBase.SpecialEncode(refNo), orderNumber, chkGoodsDelivered, Convert.ToInt32(carrierID), this.UserID, 0, DateTime.Now, this.UserID,Convert.ToInt64(deliveryNumber), objBase.SpecialEncode(header), this.TodayDate, Convert.ToInt32(this.ClientID), consignment_Note_Number, consigneeurl, Convert.ToDateTime(this.txtActualDeliveryDate.Text), CostCentreID, this.DeliveryNotePrefix);
                num = DeliveryBasePage.delivery_copy_insert(this.DeliveryID, this.CompanyID, num1, (long)0, "E", Convert.ToInt32(this.hid_ClientID.Value), Convert.ToInt32(this.hid_ContactID.Value), this.objBase.SpecialEncode(this.txtCompany.Text), Convert.ToInt64(this.hid_DeliveryAddressID.Value), this.hid_DelAddressType.Value, this.objBase.SpecialEncode(this.hid_FooterText.Value), this.objBase.SpecialEncode(this.txtComments.Text), this.lblDeliveryNumber.Text, now , this.objBase.SpecialEncode(this.txtRefNo.Text), this.objBase.SpecialEncode(this.txtOrderNumber.Text), this.chkGoodsDelivered.Checked, 0 , this.UserID, defaultStatusID , now, this.UserID, this.DelNo, this.objBase.SpecialEncode(this.hid_HeaderText.Value), this.TodayDate, Convert.ToInt32(this.hid_DeliveryToClientID.Value), "" , "" , Convert.ToDateTime(this.txtActualDeliveryDate.Text), Convert.ToInt64(this.hdn_costcentreid.Value), this.DeliveryNotePrefix);
                DeliveryBasePage.delivery_accounting_code_insert(this.CompanyID, num, num2);

            }

            DataTable dataTable1 = DeliveryBasePage.deliveryitem_select(this.CompanyID, Convert.ToInt64(base.Request.Params["id"].ToString()));
            foreach (DataRow row2 in dataTable1.Rows)
            {
                this.DeliveryItemID = Convert.ToInt64(row2["DeliveryItemID"].ToString());
                long num2 = Convert.ToInt64(row2["ItemID"].ToString());
                string str5 = row2["ItemType"].ToString();
                string str6 = row2["Quantity"].ToString();
                string str7 = row2["Description"].ToString().Replace("<br/>", " - ");
                long itemNo = Convert.ToInt64(row2["ItemNo"]);
                this.hid_Max_Del_Item_No.Value = Convert.ToString(row2["MaxDelItemNo"]);
                string notes = Convert.ToString(row2["Notes"]);
                long RepositionRowNumber = Convert.ToInt64(row2["RepositionRowNumber"]);
                long PriceCatalogueID = Convert.ToInt64(row2["PriceCatalogueID"]);
                this.DeliveryItemID = (long)0;
                DeliveryBasePage.deliveryitem_insert(this.CompanyID, this.DeliveryItemID, num, num1, num2, str5, this.objBase.SpecialEncode(str6), this.objBase.SpecialEncode(str7), itemNo, this.objBase.SpecialEncode(notes), RepositionRowNumber, PriceCatalogueID);
                //DeliveryBasePage.deliveryitem_insert(this.CompanyID, this.DeliveryItemID, num, num1, num3, empty1, this.objBase.SpecialEncode(empty2), this.objBase.SpecialEncode(str2), itemNo, this.objBase.SpecialEncode(notes), num4);

            }

            HttpResponse httpResponse = base.Response;
            object[] objArray = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=",num };
            httpResponse.Redirect(string.Concat(objArray));

        }
    }
}