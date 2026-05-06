using nmsCommon;
using nmsConnection;
using nmsLanguage;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore.usercontrol
{
    public partial class orderinformation : UserControl
    {
        //protected Label lblOrderInfoHeader;

        //protected HtmlTableRow tr_OrderInfoHeader;

        //protected Label lbl_orderTitle;

        //protected HtmlGenericControl OrderTitle_Mandatory;

        //protected TextBox txt_orderTitle;

        //protected Label Label29;

        //protected HtmlTableRow tr_orderTitle;

        //protected Label Label31;

        //protected HtmlGenericControl OrderNumber_Mandatory;

        //protected TextBox txt_orderNumber;

        //protected HtmlTableRow tr_OrderNumber;

        //protected Label Label1;

        //protected HtmlGenericControl DeliveryRequiredBy_Mandatory;

        //protected TextBox txtRequiredBy;

        //protected HtmlTableRow tr_DeliveryRequiredBy;

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

        public languageClass objLanguage = new languageClass();

        public long AccountID;

        private commonclass comm = new commonclass();

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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Header.DataBind();
            this.btn_orderInfo.Text = this.objLanguage.GetLanguageConversion("Continue");
            if (base.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (!base.IsPostBack)
            {
                if (this.comm.GetDisplayValue("isCheckOrderNumber", this.AccountID) == "false")
                {
                    this.tr_OrderNumber.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("isCheckDeliveryRequiredBy", this.AccountID) == "false")
                {
                    this.tr_DeliveryRequiredBy.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("IsCheckOrderTitleMandatory", this.AccountID) == "false")
                {
                    this.OrderTitle_Mandatory.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("IsCheckOrderNumberMandatory", this.AccountID) == "false")
                {
                    this.OrderNumber_Mandatory.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("IsCheckDeliveryRequiredByMandatory", this.AccountID).ToLower() == "false")
                {
                    this.DeliveryRequiredBy_Mandatory.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("IsCheckCoomentsMandatory", this.AccountID).ToLower() == "false")
                {
                    this.Comments_Mandatory.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("isCheckOrderTitle", this.AccountID).ToLower() == "false")
                {
                    this.tr_orderTitle.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("isCheckCooments", this.AccountID).ToLower() == "false")
                {
                    this.tr_Comments.Style.Add("display", "none");
                }
                string displayValue = this.comm.GetDisplayValue("OrderTitleText", this.AccountID);
                this.lbl_orderTitle.Text = displayValue;
                string str = this.comm.GetDisplayValue("OrderNumberText", this.AccountID);
                this.Label31.Text = str;
                string displayValue1 = this.comm.GetDisplayValue("DeliveryRequiredByText", this.AccountID);
                this.Label1.Text = displayValue1;
                string str1 = this.comm.GetDisplayValue("CommentsText", this.AccountID);
                this.Label23.Text = str1;
            }
        }
    }
}