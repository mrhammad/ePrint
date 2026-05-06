using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.CatrsNew;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.WebStore.usercontrol
{
    public partial class invoice_del_Info : UserControl
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel LoadingPanel1;

        //protected Label lblAddressInfoHeader;

        //protected HtmlTableRow tr_AddressInfoHeader;

        //protected Label lblInvoice_Address;

        //protected Label lblBillingAddress;

        //protected HtmlTableCell td_invaddr;

        //protected Label lblDeliveryAddress;

        //protected HiddenField hdnChkInvAddress;

        //protected Label lblShippingAddress;

        //protected HiddenField hdnshippingaddr;

        //protected HtmlTableCell td_Deladdr;

        //protected LinkButton lnkEdit_Bill;

        //protected HtmlTableCell tdEditAddress;

        //protected LinkButton lnkChooseBillAddress;

        //protected HtmlTableCell tdChooseAddress;

        //protected HtmlTableCell tdAddAddress;

        //protected HtmlTableCell td_Inv_Choose;

        //protected LinkButton lnkEdit_Ship;

        //protected HtmlTableCell tdEditAddress1;

        //protected LinkButton lnkChooseShipAddress;

        //protected HtmlTableCell tdChooseAddress1;

        //protected HtmlTableCell tdAddAddress1;

        //protected HtmlTableCell td_Del_Choose;

        //protected HtmlTableRow trChangeAddress;

        //protected Label lblNewAddress;

        //protected Label lblEditAddress;

        //protected Label lblAddress_Label;

        //protected TextBox txtaddressLabelBilling;

        //protected Label lnlExample_Note;

        //protected Label lblAddressBill1;

        //protected Label lblBillAdd1_UC;

        //protected TextBox txt_address_billing1;

        //protected RequiredFieldValidator Required_Address1;

        //protected Label lblAddressBill2;

        //protected Label lblBillAdd2_UC;

        //protected TextBox txt_address_billing2;

        //protected RequiredFieldValidator Required_Address2;

        //protected Label lblAddressBill3;

        //protected Label lblBillAdd3_UC;

        //protected TextBox txt_address_billing3;

        //protected RequiredFieldValidator Required_Address3;

        //protected Label lblAddressBill4;

        //protected Label lblBillAdd4_UC;

        //protected TextBox txt_address_billing4;

        //protected RequiredFieldValidator Required_Address4;

        //protected Label lblAddressBill5;

        //protected Label lblBillAdd5_UC;

        //protected TextBox txt_address_billing5;

        //protected RequiredFieldValidator Required_Address5;

        //protected Label lblCountry;

        //protected DropDownList ddlCountry;

        //protected RequiredFieldValidator Required_Country;

        //protected HtmlGenericControl sdf;

        //protected Label lblTelephone;

        //protected Label lblBillPhone_UC;

        //protected TextBox txt_telephone_billing;

        //protected RequiredFieldValidator Required_Phone;

        //protected HtmlGenericControl Span1;

        //protected Label lblFax;

        //protected TextBox txt_fax_billing;

        //protected CheckBox Chk_copy_to_invaddress;

        //protected Label lblcopyDeladdress;

        //protected HtmlTableRow CopyDeltoInvAddress;

        //protected CheckBox Chk_copy_to_deladdress;

        //protected Label lblcopyInvaddress;

        //protected HtmlTableRow CopyInvtoDelAddress;

        //protected Button btnSave_Bill;

        //protected Button btnSave_Ship;

        //protected Button btn_Update_bill;

        //protected Button btn_Update_Ship;

        //protected Label lblAddressBook;

        //protected RadTextBox grd_Search_bill;

        //protected Panel Panel2;

        //protected ImageButton imgSearch_Bill;

        //protected HtmlGenericControl spn_ListAllAdddress;

        //protected RadGrid rdGrd_bill_Choose;

        //protected Label lblAddressBook1;

        //protected RadTextBox grd_Search_ship;

        //protected Panel Panel1;

        //protected ImageButton imgSearch_Ship;

        //protected HtmlGenericControl spn_ListAllAdddress1;

        //protected RadGrid rdgrd_ship_choose;

        private OrderBasePage objOrder = new OrderBasePage();

        private BaseClass objBase = new BaseClass();

        public languageClass objLanguage = new languageClass();

        private commonclass comm = new commonclass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long BillingAddressID;

        public long ShippingAddressID;

        public long StoreUserID;

        public string strImagepath = BaseClass.imagePath();

        public long AccountID;

        private string users_change_addresses_app;

        private string users_change_addresses_dept;

        private string users_change_addresses_user;

        private string users_select_addresses_app;

        private string users_select_addresses_dept;

        private string users_select_addresses_user;

        private string users_edit_addresses_app;

        private string users_edit_addresses_dept;

        private string users_edit_addresses_user;

        private string users_add_addresses_app;

        private string users_add_addresses_dept;

        private string users_add_addresses_user;

        // save new address
        private string users_new_add_addresses_app;

        private string users_new_add_addresses_dept;

        private string users_new_add_addresses_user;


        private string MainApprover;

        private string DeptApprover;

        private string users_select_Department_address_MainApp;

        private string users_select_Department_address_DeptApp;

        private string users_select_Department_address_AllUser;

        private string users_addnew_address_notsaved_mainapp;

        private string users_addnew_address_notsaved_deptapp;

        private string users_addnew_address_notsaved_alluser;

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

        public invoice_del_Info()
        {
        }

        public void ApprovalSystem_OrderingProcess()
        {
            DataSet dataSet = OrderBasePage.Select_MainOrDepOrUser(this.StoreUserID);
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.MainApprover = "False";
            }
            else
            {
                this.MainApprover = dataSet.Tables[0].Rows[0]["MainApprover"].ToString();
            }
            if (dataSet.Tables[1].Rows.Count <= 0)
            {
                this.DeptApprover = "";
            }
            else
            {
                this.DeptApprover = dataSet.Tables[1].Rows[0]["DeptApprover"].ToString();
            }
            this.users_select_addresses_app = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_addresses_app");
            this.users_select_addresses_dept = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_addresses_dept");
            this.users_select_addresses_user = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_addresses_user");
            this.users_add_addresses_app = this.objBase.Return_ApprovalOrderingProcess_Settings("users_add_addresses_app");
            this.users_add_addresses_dept = this.objBase.Return_ApprovalOrderingProcess_Settings("users_add_addresses_dept");
            this.users_add_addresses_user = this.objBase.Return_ApprovalOrderingProcess_Settings("users_add_addresses_user");

            // save new address
            this.users_new_add_addresses_app = this.objBase.Return_ApprovalOrderingProcess_Settings("users_new_add_addresses_app");
            this.users_new_add_addresses_dept = this.objBase.Return_ApprovalOrderingProcess_Settings("users_new_add_addresses_dept");
            this.users_new_add_addresses_user = this.objBase.Return_ApprovalOrderingProcess_Settings("users_new_add_addresses_user");

            this.users_select_Department_address_MainApp = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_department_address_mainapp");
            this.users_select_Department_address_DeptApp = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_department_address_deptapp");
            this.users_select_Department_address_AllUser = this.objBase.Return_ApprovalOrderingProcess_Settings("users_select_department_address_alluser");
            this.users_addnew_address_notsaved_mainapp = this.objBase.Return_ApprovalOrderingProcess_Settings("users_addnew_address_notsaved_mainapp");
            this.users_addnew_address_notsaved_deptapp = this.objBase.Return_ApprovalOrderingProcess_Settings("users_addnew_address_notsaved_deptapp");
            this.users_addnew_address_notsaved_alluser = this.objBase.Return_ApprovalOrderingProcess_Settings("users_addnew_address_notsaved_alluser");
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_select_addresses_app.ToLower().Trim() != "y" && this.users_select_addresses_app.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() != "y" && this.users_select_addresses_dept.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_select_addresses_user.ToLower().Trim() != "y" && this.users_select_addresses_user.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_app.ToLower().Trim() != "y" && this.users_select_addresses_app.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() != "y" && this.users_select_addresses_dept.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_select_Department_address_MainApp.ToLower().Trim() != "y" && this.users_select_Department_address_MainApp.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "y" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_select_Department_address_AllUser.ToLower().Trim() != "y" && this.users_select_Department_address_AllUser.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_MainApp.ToLower().Trim() != "y" && this.users_select_Department_address_MainApp.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "y" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_select_addresses_app.ToLower().Trim() == "y" && this.users_select_addresses_app.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() == "y" && this.users_select_addresses_dept.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_select_addresses_user.ToLower().Trim() == "y" && this.users_select_addresses_user.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_app.ToLower().Trim() == "y" && this.users_select_addresses_app.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() == "y" && this.users_select_addresses_dept.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_select_Department_address_MainApp.ToLower().Trim() == "y" && this.users_select_Department_address_MainApp.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "false" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_DeptApp.ToLower().Trim() == "y" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_select_Department_address_AllUser.ToLower().Trim() == "y" && this.users_select_Department_address_AllUser.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_MainApp.ToLower().Trim() == "y" && this.users_select_Department_address_MainApp.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_Department_address_DeptApp.ToLower().Trim() == "y" && this.users_select_Department_address_DeptApp.ToLower().Trim() != "")
            {
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_add_addresses_app.ToLower().Trim() != "y" && this.users_add_addresses_app.ToLower() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_dept.ToLower().Trim() != "y" && this.users_add_addresses_dept.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_add_addresses_user.ToLower().Trim() != "y" && this.users_add_addresses_user.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_app.ToLower().Trim() != "y" && this.users_add_addresses_app.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_dept.ToLower().Trim() != "y" && this.users_add_addresses_dept.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
                this.tdEditAddress.Visible = false;
                this.tdEditAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_addnew_address_notsaved_alluser.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_alluser.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "y" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = false;
                this.tdAddAddress1.Visible = false;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_add_addresses_app.ToLower().Trim() == "y" && this.users_add_addresses_app.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_dept.ToLower().Trim() == "y" && this.users_add_addresses_dept.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_add_addresses_user.ToLower().Trim() == "y" && this.users_add_addresses_user.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_app.ToLower().Trim() == "y" && this.users_add_addresses_app.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_add_addresses_dept.ToLower().Trim() == "y" && this.users_add_addresses_dept.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdEditAddress.Visible = true;
                this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_addnew_address_notsaved_alluser.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_alluser.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_mainapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() == "y" && this.users_addnew_address_notsaved_deptapp.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
            }
            // save new address
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() == "" && this.users_new_add_addresses_user.ToLower().Trim() == "y" && this.users_new_add_addresses_user.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
                //this.tdEditAddress.Visible = true;
                //this.tdEditAddress1.Visible = true;
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() == "" && this.users_new_add_addresses_user.ToLower().Trim() == "y" && this.users_new_add_addresses_user.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;                
            }
            if (this.MainApprover.ToLower() != "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() == "y" && this.users_select_addresses_dept.ToLower().Trim() != "" && this.users_new_add_addresses_user.ToLower().Trim() == "y" && this.users_new_add_addresses_user.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;   
            }
            if (this.MainApprover.ToLower() == "true" && this.DeptApprover.ToLower() != "" && this.users_select_addresses_dept.ToLower().Trim() == "y" && this.users_select_addresses_dept.ToLower().Trim() != "" && this.users_new_add_addresses_user.ToLower().Trim() == "y" && this.users_new_add_addresses_user.ToLower().Trim() != "")
            {
                this.tdAddAddress.Visible = true;
                this.tdAddAddress1.Visible = true;
                this.tdChooseAddress.Visible = true;
                this.tdChooseAddress1.Visible = true;
            }
        }

        protected void btnSave_Bill_OnClick(object sender, EventArgs e)
        {
            this.ButtonSaveClick_Bill(sender, e);
        }

        protected void btnSave_Ship_OnClick(object sender, EventArgs e)
        {
            this.ButtonSaveClick_Ship(sender, e);
        }

        protected void btnUpdate_Bill_OnClick(object sender, EventArgs e)
        {
            this.ButtonUpdateClick_Bill(sender, e);
        }

        protected void btnUpdate_Ship_OnClick(object sender, EventArgs e)
        {
            this.ButtonUpdateClick_Ship(sender, e);
        }

        protected void grd_Search_bill_OnTextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address_Grid(Convert.ToInt64(base.Session["StoreUserID"].ToString()), "bill", (long)0, this.objBase.SpecialEncode(this.grd_Search_bill.Text));
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBase.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBase.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBase.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBase.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBase.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBase.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdGrd_bill_Choose.DataSource = dataTable;
            this.rdGrd_bill_Choose.DataBind();
        }

        protected void grd_Search_ship_OnTextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address_Grid(Convert.ToInt64(base.Session["StoreUserID"].ToString()), "bill", (long)0, this.grd_Search_ship.Text);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBase.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBase.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBase.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBase.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBase.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBase.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdgrd_ship_choose.DataSource = dataTable;
            this.rdgrd_ship_choose.DataBind();
        }

        protected void lnkChooseBillAddress_Click(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.B2B_Select_All_Address_ByStoreUserID(this.StoreUserID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBase.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBase.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBase.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBase.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBase.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBase.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdGrd_bill_Choose.DataSource = dataTable;
            this.rdGrd_bill_Choose.DataBind();
            this.grd_Search_bill.Text = string.Empty;
        }

        protected void lnkChooseShipAddress_Click(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.B2B_Select_All_Address_ByStoreUserID(this.StoreUserID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBase.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBase.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBase.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBase.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBase.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBase.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdgrd_ship_choose.DataSource = dataTable;
            this.rdgrd_ship_choose.DataBind();
            this.grd_Search_ship.Text = string.Empty;
        }

        protected void lnkEdit_Bill_Click(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["BillingAddressID"]), (long)0);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.txtaddressLabelBilling.Text = baseClass.SpecialDecode(row["AddressLabel"].ToString());
                    this.txt_address_billing1.Text = baseClass.SpecialDecode(row["AddressLine1"].ToString());
                    this.txt_address_billing2.Text = baseClass.SpecialDecode(row["AddressLine2"].ToString());
                    this.txt_address_billing3.Text = baseClass.SpecialDecode(row["Address2"].ToString());
                    this.txt_address_billing4.Text = baseClass.SpecialDecode(row["Address3"].ToString());
                    this.txt_address_billing5.Text = baseClass.SpecialDecode(row["Address4"].ToString());
                    baseClass.SetDDLText(this.ddlCountry, row["Country"].ToString());
                    this.txt_telephone_billing.Text = row["phone"].ToString();
                    this.txt_fax_billing.Text = row["Fax"].ToString();
                    this.txt_email_billing.Text = row["Email"].ToString();
                }
            }
        }

        protected void lnkEdit_Ship_Click(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["ShippingAddressID"]), (long)0);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.txtaddressLabelBilling.Text = baseClass.SpecialDecode(row["AddressLabel"].ToString());
                    this.txt_address_billing1.Text = baseClass.SpecialDecode(row["AddressLine1"].ToString());
                    this.txt_address_billing2.Text = baseClass.SpecialDecode(row["AddressLine2"].ToString());
                    this.txt_address_billing3.Text = baseClass.SpecialDecode(row["Address2"].ToString());
                    this.txt_address_billing4.Text = baseClass.SpecialDecode(row["Address3"].ToString());
                    this.txt_address_billing5.Text = baseClass.SpecialDecode(row["Address4"].ToString());
                    baseClass.SetDDLText(this.ddlCountry, row["Country"].ToString());
                    this.txt_telephone_billing.Text = row["phone"].ToString();
                    this.txt_fax_billing.Text = row["Fax"].ToString();
                    this.txt_email_billing.Text = row["Email"].ToString();
                }
            }
        }

        protected void lnkOrderDate_bill_Click(object sender, CommandEventArgs e)
        {
            this.ButtonClick_Bill(sender, e);
            this.grd_Search_bill.Text = string.Empty;
        }

        protected void lnkOrderDate_ship_Click(object sender, CommandEventArgs e)
        {
            this.ButtonClick_Ship(sender, e);
            this.grd_Search_ship.Text = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            this.Page.Header.DataBind();
            this.lblInvoice_Address.Text = this.objLanguage.GetLanguageConversion("Invoice_Address");
            this.lblDeliveryAddress.Text = this.objLanguage.GetLanguageConversion("Delivery_Address");
            this.lblNewAddress.Text = this.objLanguage.GetLanguageConversion("New_Address");
            this.lblEditAddress.Text = this.objLanguage.GetLanguageConversion("Edit_Address");
            this.lblCountry.Text = this.objLanguage.GetLanguageConversion("Country");
            this.lblTelephone.Text = this.objLanguage.GetLanguageConversion("Telephone");
            this.lblFax.Text = this.objLanguage.GetLanguageConversion("Fax");
            this.lblEmail.Text = this.objLanguage.GetLanguageConversion("Email");
            this.lblcopyDeladdress.Text = this.objLanguage.GetLanguageConversion("Copy_the_above_to_Invoice_Address");
            this.lblcopyInvaddress.Text = this.objLanguage.GetLanguageConversion("Copy_the_above_to_Delivery_Address");
            this.btnSave_Bill.Text = this.objLanguage.GetLanguageConversion("Save_And_Use_This_Address");
            this.btnSave_Ship.Text = this.objLanguage.GetLanguageConversion("Save_And_Use_This_Address");
            this.btn_Update_bill.Text = this.objLanguage.GetLanguageConversion("Update");
            this.btn_Update_Ship.Text = this.objLanguage.GetLanguageConversion("Update");
            this.lblAddressBook.Text = this.objLanguage.GetLanguageConversion("Address_book");
            this.spn_ListAllAdddress.InnerText = this.objLanguage.GetLanguageConversion("List_Of_Available_Address");
            this.lblAddressBook1.Text = this.objLanguage.GetLanguageConversion("Address_Book");
            this.spn_ListAllAdddress1.InnerText = this.objLanguage.GetLanguageConversion("List_Of_Available_Address");
            if (ConnectionClass.ServerName == null || !(ConnectionClass.ServerName.ToLower() == "smp") || this.AccountID != (long)276)
            {
                this.lblAddress_Label.Text = this.objLanguage.GetLanguageConversion("Address_Label");
                this.lnlExample_Note.Text = this.objLanguage.GetLanguageConversion("Example_Note_For_Address");
            }
            else
            {
                this.lblAddress_Label.Text = this.objLanguage.GetLanguageConversion("Address_Label_SMP");
                this.lnlExample_Note.Text = this.objLanguage.GetLanguageConversion("Example_Note_For_Address_SMP");
            }
            if (base.IsPostBack)
            {
                this.BillingAddressID = Convert.ToInt64(base.Session["BillingAddressID"]);
                this.ShippingAddressID = Convert.ToInt64(base.Session["ShippingAddressID"]);
            }
            if (base.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
            }
            if (!base.IsPostBack)
            {
                this.ApprovalSystem_OrderingProcess();
            }
            bool isChecked = this.customCheckbox.Checked;
            this.hiddenCheckboxValue.Value = isChecked ? "1" : "0";
            //this.customCheckbox.Attributes.Add("onclick", "toggleCheckbox();");
            Session["CheckboxValue"] = this.hiddenCheckboxValue.Value;
            DataTable dataTable1 = OrderBasePage.PC_select_DeliveryCost_Settings(Convert.ToInt32(ConnectionClass.CompanyID), Convert.ToInt32(this.AccountID));
            foreach (DataRow row1 in dataTable1.Rows)
            {
                if (Convert.ToInt32(row1["Allowpickup"]) != 1)
                {
                    this.tdOrderPickup1.Style.Add("display", "none");
                    this.tdChkPickup1.Style.Add("display", "none");
                }
                else
                {
                    this.tdOrderPickup1.Style.Add("display", "block");
                    this.tdChkPickup1.Style.Add("display", "block");
                }
            }
            if (this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID) == "false" && this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "true")
            {
                this.td_invaddr.Style.Add("display", "none");
                this.td_Inv_Choose.Style.Add("display", "none");
                this.td_Deladdr.Attributes.Add("colspan", "2");
                this.td_Del_Choose.Attributes.Add("colspan", "2");
                this.td_Deladdr.Style.Add("padding-left", "15px");
                this.td_Del_Choose.Style.Add("padding-left", "15px");
                return;
            }
            if (this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "false" && this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID) == "true")
            {
                this.td_Deladdr.Style.Add("display", "none");
                this.td_Del_Choose.Style.Add("display", "none");
                this.td_invaddr.Attributes.Add("colspan", "2");
                this.td_Inv_Choose.Attributes.Add("colspan", "2");
                return;
            }
            if (this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "false" && this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID) == "false")
            {
                this.td_Deladdr.Style.Add("display", "none");
                this.td_Del_Choose.Style.Add("display", "none");
                this.td_invaddr.Style.Add("display", "none");
                this.td_Inv_Choose.Style.Add("display", "none");
            }
        }

        protected void rdGrd_bill_Choose_OnItemDataBound(object source, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                radComboBox.Enabled = false;
                radComboBox.Visible = false;
            }
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            if ((e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item) && base.Session["BillingAddressID"] != null)
            {
                if (dataItem["AddressID"].ToString() == base.Session["BillingAddressID"].ToString())
                {
                    e.Item.Selected = true;
                    return;
                }
                e.Item.Selected = false;
            }
        }

        protected void rdgrd_ship_choose_OnItemDataBound(object source, GridItemEventArgs e)
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            if ((e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item) && base.Session["ShippingAddressID"] != null)
            {
                if (dataItem["AddressID"].ToString() != base.Session["ShippingAddressID"].ToString())
                {
                    e.Item.Selected = false;
                }
                else
                {
                    e.Item.Selected = true;
                }
            }
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                radComboBox.Enabled = false;
                radComboBox.Visible = false;
            }
        }
        protected void customCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // Handle the checkbox checked changed event if needed.
        }

        protected void rdgrd_ship_choose_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.rdgrd_ship_choose.DataSource = base.Session["AddressGrid"];
            this.rdGrd_bill_Choose.DataSource = base.Session["AddressGrid"];
        }

        public event EventHandler ButtonClick_Bill;

        public event EventHandler ButtonClick_Ship;

        public event EventHandler ButtonSaveClick_Bill;

        public event EventHandler ButtonSaveClick_Ship;

        public event EventHandler ButtonUpdateClick_Bill;

        public event EventHandler ButtonUpdateClick_Ship;
    }
}