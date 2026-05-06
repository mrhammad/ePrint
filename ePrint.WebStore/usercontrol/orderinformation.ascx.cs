using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
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

namespace ePrint.WebStore.usercontrol
{
    public partial class orderinformation : UserControl
    {
        //protected Label lblDesigApprover;

        //protected Label lblApprover;

        //protected TextBox txtDesigApprover;

        //protected HtmlGenericControl divApproverEmail;

        //protected Label lblOrderInfoHeader;

        //protected HtmlTableRow tr_OrderInfoHeader;

        //protected Label lbl_orderTitle;

        //protected HtmlGenericControl OrderTitle_Mandatory;

        //protected TextBox txt_orderTitle;

        //protected Label lblOrdTitle_Helptext;

        //protected Panel Panel2;

        //protected HtmlTableRow tr_orderTitle;

        //protected Label Label31;

        //protected HtmlGenericControl OrderNumber_Mandatory;

        //protected TextBox txt_orderNumber;

        //protected Label lblOrdNo_Helptext;

        //protected Panel Panel1;

        //protected HtmlTableRow tr_OrderNumber;

        //protected Label Label1;

        //protected HtmlGenericControl DeliveryRequiredBy_Mandatory;

        //protected TextBox txtRequiredBy;

        //protected Label lblReqBy_Helptext;

        //protected Panel Panel3;

        //protected HtmlTableRow tr_DeliveryRequiredBy;

        //protected Label Label2;

        //protected HtmlGenericControl CostCenter_Mandatory;

        //protected DropDownList ddlCostCenter;

        //protected HtmlTableRow tdCostCentre;

        //protected Label Label23;

        //protected HtmlGenericControl Comments_Mandatory;

        //protected TextBox txtComments;

        //protected HtmlTableRow tr_Comments;

        //protected Button btn_orderInfo;

        //protected Label Label33;

        //protected LinkButton LinkButton1;

        //protected UpdatePanel UpdatePanel2;

        public string strImagepath = BaseClass.imagePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long StoreUserID;

        public long OriginalStoreUserID;

        private BaseClass objBase = new BaseClass();

        public languageClass objLanguage = new languageClass();

        public long AccountID;

        private commonclass comm = new commonclass();

        private long DeptID;

        private string cartitemids = string.Empty;

        private string orderbehalftype = string.Empty;

        public string IsCampaignEnabled = string.Empty;

        public long CampManageID;

        public long CompanyID;

        public long DepartmentId;

        public string IsAllowdefaultcostCentre = string.Empty;

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public orderinformation()
        {
        }

        public void BindCostCentre(long StoreUserID, long DeptID)
        {
            this.IsAllowdefaultcostCentre = ProductBasePage.AllowDefaultCostcentre(this.DepartmentId);
            DataSet dataSet = OrderBasePage.SelectDeptandCostCentre(StoreUserID, this.orderbehalftype, DeptID);
            this.ddlCostCenter.DataSource = dataSet.Tables[0];
            this.ddlCostCenter.DataTextField = "CostCentreName";
            this.ddlCostCenter.DataValueField = "CostCentreID";
            this.ddlCostCenter.DataBind();
            if (this.IsAllowdefaultcostCentre.ToString().ToLower() != "n")
            {
                this.ddlCostCenter.Items.Insert(0, "--Select--");
                this.ddlCostCenter.Items[0].Text = "--Select--";
                this.ddlCostCenter.Items[0].Value = "0";
            }
            if (dataSet.Tables.Count > 1 && dataSet.Tables[1].Rows.Count > 1)
            {
                this.setddlval(this.ddlCostCenter, Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString()));
            }
        }

        public void getOrderNo_DeliveryDate(long CampManageID)
        {
            DataTable dataTable = OrderBasePage.PreFill_OrderInfo(CampManageID);
            if (dataTable.Rows.Count > 0)
            {
                this.txt_orderNumber.Text = dataTable.Rows[0]["OrderNumber"].ToString();
                this.txtRequiredBy.Text = this.comm.Eprint_return_Date_Before_View(dataTable.Rows[0]["DeliveryDate"].ToString(), Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.StoreUserID), false);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = (long)Convert.ToInt32(ConnectionClass.CompanyID);
            }
            string str = this.objBase.Return_ApprovalSystem_Settings("approvaltype");
            this.Page.Header.DataBind();
            if (base.Session["DeptID"] != null)
            {
                this.DepartmentId = Convert.ToInt64(base.Session["DeptID"]);
            }
            if (base.Session["MultipleCartID"] != null)
            {
                this.cartitemids = base.Session["MultipleCartID"].ToString();
            }
            if (base.Session["OrderBehalfType"] != null)
            {
                this.orderbehalftype = base.Session["OrderBehalfType"].ToString();
            }
            if (this.orderbehalftype.ToLower() == "d" || this.orderbehalftype.ToLower() == "u")
            {
                DataTable dataTable = OrderBasePage.Select_StoreUserID_UserDept_Behalf(this.cartitemids, this.orderbehalftype);
                if (dataTable.Rows.Count > 0)
                {
                    this.StoreUserID = Convert.ToInt64(dataTable.Rows[0]["Order_Behalf_UserID"]);
                    this.DeptID = Convert.ToInt64(dataTable.Rows[0]["Order_Behalf_DeptID"]);
                    this.OriginalStoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
                }
            }
            else if (base.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
                this.OriginalStoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
            }
            if (!base.IsPostBack)
            {
                this.BindCostCentre(this.StoreUserID, this.DeptID);
                if (base.Session["InsertOrder"] != null && base.Session["InsertOrder"] != null)
                {
                    DataTable item = (DataTable)base.Session["InsertOrder"];
                    if (item != null)
                    {
                        foreach (DataRow row in item.Rows)
                        {
                            this.ddlCostCenter.SelectedValue = row["CostCentreID"].ToString();
                        }
                    }
                }
                string str1 = this.objBase.Return_ApprovalOrderingProcess_Settings("showcostcenters");
                if (str1.Trim().ToLower() == "false" || str1.Trim().ToLower() == "")
                {
                    this.tdCostCentre.Style.Add("display", "none");
                }
                if (base.Session["ApprovalSystem"] != null && base.Session["ApprovalSystem"].ToString() == "on")
                {
                    if (str == "u")
                    {
                        this.divApproverEmail.Style.Add("display", "block");
                    }
                    DataTable dataTable1 = LoginBasePage.StoreUser_select(this.OriginalStoreUserID);
                    if (this.objBase.Return_ApprovalSystem_Settings("lastapproverdefault").ToLower() != "false" && dataTable1.Rows.Count > 0 && this.txtDesigApprover.Text == "")
                    {
                        this.txtDesigApprover.Text = dataTable1.Rows[0]["DesignatedApproverEmail"].ToString();
                    }
                }
                if (this.comm.GetDisplayValue("isCheckOrderNumber", this.AccountID) == "false")
                {
                    this.tr_OrderNumber.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("isCheckDeliveryRequiredBy", this.AccountID) == "false")
                {
                    this.tr_DeliveryRequiredBy.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("isCheckOrderTitle", this.AccountID) == "false")
                {
                    this.tr_orderTitle.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("isCheckCooments", this.AccountID) == "false")
                {
                    this.tr_Comments.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("IsCheckOrderTitleMandatory", this.AccountID) == "false")
                {
                    this.OrderTitle_Mandatory.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("IsCheckOrderNumberMandatory", this.AccountID) == "false")
                {
                    this.OrderNumber_Mandatory.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("IsCheckDeliveryRequiredByMandatory", this.AccountID) == "false")
                {
                    this.DeliveryRequiredBy_Mandatory.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("IsCheckCoomentsMandatory", this.AccountID) == "false")
                {
                    this.Comments_Mandatory.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("IsCheckCostCentreMandatory", this.AccountID) == "false")
                {
                    this.CostCenter_Mandatory.Style.Add("display", "none");
                }
                string displayValue = this.comm.GetDisplayValue("OrderTitleText", this.AccountID);
                this.lbl_orderTitle.Text = displayValue;
                string displayValue1 = this.comm.GetDisplayValue("OrderNumberText", this.AccountID);
                this.Label31.Text = displayValue1;
                string displayValue2 = this.comm.GetDisplayValue("DeliveryRequiredByText", this.AccountID);
                this.Label1.Text = displayValue2;
                string str2 = this.comm.GetDisplayValue("CommentsText", this.AccountID);
                this.Label23.Text = str2;
                string displayValue3 = this.comm.GetDisplayValue("CostCentreText", this.AccountID);
                this.Label2.Text = displayValue3;
                this.lblOrdTitle_Helptext.Text = this.comm.GetDisplayValue("ExampleNoteValue", this.AccountID);
                this.lblOrdNo_Helptext.Text = this.comm.GetDisplayValue("OrderNumber_HelpText", this.AccountID);
                this.lblReqBy_Helptext.Text = this.comm.GetDisplayValue("DelReqBy_HelpText", this.AccountID);
                this.IsCampaignEnabled = ProductBasePage.GetCampaign_Enabled(this.AccountID);
                if (this.IsCampaignEnabled.ToLower() == "true")
                {
                    if (base.Request.Params["CampID"] != null)
                    {
                        this.CampManageID = Convert.ToInt64(base.Request.Params["CampID"].ToString());
                    }
                    this.getOrderNo_DeliveryDate(this.CampManageID);
                }
            }
        }

        public void setddlval(DropDownList ddl, int value)
        {
            ListItem listItem = ddl.Items.FindByValue(value.ToString());
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }
    }
}