using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ePrint.usercontrol.crm
{
    public partial class B2BSubSection : System.Web.UI.UserControl
    {
        //protected Button btn_b2bCreate;

        //protected HtmlGenericControl div_B2B_Button;

        //protected Label lbl_b2b_eStoreLink;

        //protected Label lbl_b2beStoreLink;

        //protected HtmlGenericControl div_B2B_Link;

        //protected Label lbl_b2c_eStoreLink;

        //protected Label lbl_b2ceStoreLink;

        //protected HtmlGenericControl div_B2C_Link;

        //protected HtmlGenericControl ifrm_accounts;

        //protected HtmlGenericControl div_account;

        //protected UpdatePanel up_b2bInfo;

        //protected HtmlGenericControl div_B2B;

        //protected Label lvl_B2BMsg;

        //protected HtmlGenericControl div_B2BMsg;

        private BaseClass objBase = new BaseClass();

        private CompanyBasePage objcomm = new CompanyBasePage();

        private DepartmentBaseClass objDept = new DepartmentBaseClass();

        public string ImgPath = global.imagePath();

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public int AccountID;

        public string web_key = string.Empty;

        public string WebStorePathB2B = string.Empty;

        public string WebStorePathB2B_Display = string.Empty;

        public string WebStorePathB2C = string.Empty;

        public string FileExtension = string.Empty;

        public string CompanyName = string.Empty;

        public string CompanyType = string.Empty;

        public string redirectFrom = string.Empty;

        public string IsFromWebStore = string.Empty;

        public string AccountName = string.Empty;

        public languageClass objLangClass = new languageClass();

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

        public B2BSubSection()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_b2bCreate.Text = this.objLangClass.GetLanguageConversion("Create_B2B_Estore");
            BaseClass baseClass = new BaseClass();
            string str = this.objBase.ReturnRoles_Privileges_ForGrid("clients", "others", this.Page.Request.Url.ToString());
            if (str == "0" || str == "2")
            {
                this.div_B2B_Button.Visible = false;
            }
            else
            {
                this.div_B2B_Button.Visible = true;
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            try
            {
                string str1 = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                ArrayList arrayLists = Encryption.querystrvalue(str1);
                this.ClientID = int.Parse(arrayLists[1].ToString());
                this.CompanyName = arrayLists[3].ToString();
                this.CompanyType = arrayLists[7].ToString();
                this.redirectFrom = arrayLists[9].ToString();
            }
            catch
            {
            }
            if (ConnectionClass.WebStore != null)
            {
                this.web_key = ConnectionClass.WebStore;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension.ToString();
            }
            foreach (DataRow row in CompanyBasePage.Get_AccountName(this.ClientID).Rows)
            {
                this.AccountName = row["accountName"].ToString();
                this.div_B2B_Button.Visible = false;
            }
            if (ConnectionClass.B2BURL != null)
            {
                this.WebStorePathB2B = ConnectionClass.B2BURL.ToString();
                this.WebStorePathB2B_Display = string.Concat(this.WebStorePathB2B, this.AccountName);
                this.WebStorePathB2B = string.Concat(this.WebStorePathB2B, "404.aspx?AccountName=", this.AccountName);
            }
            if (ConnectionClass.B2CURL != null)
            {
                this.WebStorePathB2C = ConnectionClass.B2CURL.ToString();
                this.WebStorePathB2C = string.Concat(this.WebStorePathB2C, "login", this.FileExtension);
            }
            if (this.web_key != "")
            {
                if (this.web_key.ToLower() != "yes")
                {
                    this.div_B2B.Visible = false;
                    this.div_B2BMsg.Style.Add("display", "block");
                }
                else
                {
                    this.div_B2B.Visible = true;
                }
            }
            DataTable dataTable = CompanyBasePage.company_client_select(this.CompanyID, this.ClientID, this.CompanyType);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.AccountID = Convert.ToInt32(dataRow["AccountID"].ToString());
                this.IsFromWebStore = dataRow["IsFromWebStore"].ToString();
            }
            if (this.CompanyType.ToLower() == "customer")
            {
                if (this.AccountID != 0)
                {
                    if (this.IsFromWebStore.ToLower() == "store")
                    {
                        this.div_B2C_Link.Style.Add("display", "block");
                        this.lbl_b2ceStoreLink.Text = this.objBase.SpecialDecode(this.WebStorePathB2C);
                        return;
                    }
                    this.div_B2B_Link.Style.Add("display", "block");
                    this.lbl_b2beStoreLink.Text = this.objBase.SpecialDecode(this.WebStorePathB2B_Display);
                    return;
                }
                this.div_B2B_Button.Style.Add("display", "block");
                HtmlControl htmlControl = (HtmlControl)this.FindControl("ifrm_accounts");
                htmlControl.Attributes["src"] = string.Concat("../Accounts/account_new_create_withoutTemplate.aspx?from=client&type=Customer&mode=add&clientID=", this.ClientID);
            }
        }
    }
}