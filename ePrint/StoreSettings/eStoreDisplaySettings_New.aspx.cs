using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.StoreSettings
{
    public partial class eStoreDisplaySettings_New : BaseClass, IRequiresSessionState
    {
        public string strImagepath;

        public int CompanyID;

        public string strSitepath = global.sitePath();

        public int AccountID;

        public int UserID;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objLanguage = new languageClass();

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

        public eStoreDisplaySettings_New()
        {
        }

        public void BindGrid(int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estoredisplaySettings_Select_New");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, this.CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            this.grd_eStore_DisplaySettings.DataSource = dataTable;
            this.grd_eStore_DisplaySettings.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grd_eStore_DisplaySettings.Items.Count; i++)
            {
                CheckBox checkBox = (CheckBox)this.grd_eStore_DisplaySettings.Items[i].FindControl("chkIsMandatory");
                CheckBox checkBox1 = (CheckBox)this.grd_eStore_DisplaySettings.Items[i].FindControl("chkIsDisplay");
                Label label = (Label)this.grd_eStore_DisplaySettings.Items[i].FindControl("lblOrderTitle");
                TextBox textBox = (TextBox)this.grd_eStore_DisplaySettings.Items[i].FindControl("txtScreenName");
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstoreDisplaySettings_Update_New");
                database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, Convert.ToInt64(this.AccountID));
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, Convert.ToInt64(this.CompanyID));
                database.AddInParameter(storedProcCommand, "@FieldName", DbType.String, Convert.ToString(label.Text));
                database.AddInParameter(storedProcCommand, "@isMandatory", DbType.Boolean, checkBox.Checked);
                database.AddInParameter(storedProcCommand, "@isdisplay", DbType.Boolean, checkBox1.Checked);
                database.AddInParameter(storedProcCommand, "@ScreenName", DbType.String, Convert.ToString(textBox.Text));
                database.AddInParameter(storedProcCommand, "@is_DelAddres_Mandatory", DbType.Boolean, this.Chk_Mandotory_Del.Checked);
                database.AddInParameter(storedProcCommand, "@is_InvAddres_Mandatory", DbType.Boolean, this.chk_Mandotory_Inv.Checked);
                database.AddInParameter(storedProcCommand, "@is_Display_Delivery", DbType.Boolean, this.Chk_Display_Del.Checked);
                database.AddInParameter(storedProcCommand, "@is_Display_Invoice", DbType.Boolean, this.Chk_Display_Inv.Checked);
                database.AddInParameter(storedProcCommand, "@isCheckOrderInfoPublic", DbType.Boolean, this.chk_EnableOrder.Checked);
                database.AddInParameter(storedProcCommand, "@isCheckAddressInfo", DbType.Boolean, this.Chk_EnableAddress.Checked);
                database.AddInParameter(storedProcCommand, "@isDisplayDates", DbType.Boolean, false);
                database.ExecuteNonQuery(storedProcCommand);
            }
            this.BindGrid(this.AccountID);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessageNew);
        }

        protected void grd_eStore_Display_Address_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnIsMandatory_Address");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnIsDisplay_Address");
                CheckBox checkBox = (CheckBox)e.Item.FindControl("chkIsMandatory_Address");
                CheckBox checkBox1 = (CheckBox)e.Item.FindControl("chkIsDisplay_Address");
            }
        }

        protected void grd_eStore_DisplaySettings_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnIsMandatory");
                CheckBox checkBox = (CheckBox)e.Item.FindControl("chkIsMandatory");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnIsDisplay");
                CheckBox checkBox1 = (CheckBox)e.Item.FindControl("chkIsDisplay");
                Label languageConversion = (Label)e.Item.FindControl("lblOrdertitle");
                TextBox textBox = (TextBox)e.Item.FindControl("txtScreenName");
                if (languageConversion.Text == "Order Title")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Order_Title");
                    return;
                }
                if (languageConversion.Text == "Order Number")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Order_Number");
                    return;
                }
                if (languageConversion.Text == "Delivery Required By")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Delivery_Required_By");
                    return;
                }
                if (languageConversion.Text == "Comments")
                {
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Comments");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.strImagepath = global.imagePath();
            this.grd_eStore_DisplaySettings.DataSource = new object[0];
            if (this.Session["Email"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "error.aspx"));
            }
            base.Title = this.objLanguage.convert(global.pageTitle("eStore Display Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estore_Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Check_Out_Screens")));
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            if (!base.IsPostBack)
            {
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                foreach (DataRow row in SettingsBasePage.Select_Address_CheckBoxStatus(this.CompanyID, this.AccountID).Rows)
                {
                    num = Convert.ToInt32(row["is_DeliveryAddress_Mandatory"]);
                    num1 = Convert.ToInt32(row["is_InvoiceAddress_Mandatory"]);
                    num2 = Convert.ToInt32(row["isCheckDeliveryInfo"]);
                    num3 = Convert.ToInt32(row["isCheckInvoiceInfo"]);
                    num4 = Convert.ToInt32(row["isCheckOrderInfoPublic"]);
                    num5 = Convert.ToInt32(row["isCheckAddressInfo"]);
                }
                if (num != 1)
                {
                    this.Chk_Mandotory_Del.Checked = false;
                }
                else
                {
                    this.Chk_Mandotory_Del.Checked = true;
                }
                if (num1 != 1)
                {
                    this.chk_Mandotory_Inv.Checked = false;
                }
                else
                {
                    this.chk_Mandotory_Inv.Checked = true;
                }
                if (num2 != 1)
                {
                    this.Chk_Display_Del.Checked = false;
                }
                else
                {
                    this.Chk_Display_Del.Checked = true;
                }
                if (num3 != 1)
                {
                    this.Chk_Display_Inv.Checked = false;
                }
                else
                {
                    this.Chk_Display_Inv.Checked = true;
                }
                if (num4 != 1)
                {
                    this.chk_EnableOrder.Checked = false;
                }
                else
                {
                    this.chk_EnableOrder.Checked = true;
                }
                if (num5 != 1)
                {
                    this.Chk_EnableAddress.Checked = false;
                }
                else
                {
                    this.Chk_EnableAddress.Checked = true;
                }
                this.grd_eStore_DisplaySettings.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Field_Name");
                this.grd_eStore_DisplaySettings.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Screen_Name");
                this.grd_eStore_DisplaySettings.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Mandatory");
                this.grd_eStore_DisplaySettings.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Display");
                this.BindGrid(this.AccountID);
            }
            this.btnUpdate.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_btnUpdateprocess');");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Check_Out_Screens");
            this.lblMandatory.Visible = false;
            this.Chk_Mandotory_Del.Visible = false;
            this.chk_Mandotory_Inv.Visible = false;
            string str1 = WebstoreBasePage.SelectAccountType(this.AccountID);
            if (str1 != null && str1.ToLower() == "p")
            {
                this.OrderInformation.Visible = false;
                this.ShowAddressInformation.Visible = false;
            }
        }
    }
}