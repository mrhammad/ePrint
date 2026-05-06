using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
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

namespace ePrint.usercontrol.View
{
    public partial class CustomViewCRM : System.Web.UI.UserControl
    {
        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public languageClass objLanguage = new languageClass();

        private createViewClass objCreateView = new createViewClass();

        private commonClass comm = new commonClass();

        public int companyId;

        public int userId;

        public long ViewID;

        public long delViewID;

        public long dupViewID;

        public DataTable iszero = new DataTable();

        public string pg = string.Empty;

        private BaseClass objbase = new BaseClass();

        private CompanyBasePage objcomp = new CompanyBasePage();

        private string ReqType = string.Empty;

        public int ret;

        public int isdefault;

        public int isshowall;

        public string condition1 = string.Empty;

        public string condition2 = string.Empty;

        public string condition3 = string.Empty;

        public string condition4 = string.Empty;

        public string condition5 = string.Empty;

        public string operator1 = string.Empty;

        public string operator2 = string.Empty;

        public string operator3 = string.Empty;

        public string operator4 = string.Empty;

        public string operator5 = string.Empty;

        public string value1 = string.Empty;

        public string value2 = string.Empty;

        public string value3 = string.Empty;

        public string value4 = string.Empty;

        public string value5 = string.Empty;

        public string ConditionalOperator1 = string.Empty;

        public string ConditionalOperator2 = string.Empty;

        public string ConditionalOperator3 = string.Empty;

        public string ConditionalOperator4 = string.Empty;

        public string ddl_sortby1 = string.Empty;

        public string ddl_direction1 = string.Empty;

        public int isdeleted;

        public int CreatedBy;

        public int UpdatedBy;

        public string CreatedOn = string.Empty;

        public string UpdatedOn = string.Empty;

        public string chk_concat = string.Empty;

        public int isshowallrecords;

        public int iszerothval;

        public string companytype = "customer";

        public string ViewName = "customer";

        public int defaultviewid;

        public string pgtype = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLangClass = new languageClass();

        public string strImagePath = global.imagePath();

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

        public CustomViewCRM()
        {
        }

        protected void btncancel_OnClick(object sender, EventArgs e)
        {
            if (this.companytype == "")
            {
                this.companytype = "customer";
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "client/client_view.aspx?type=", this.companytype));
        }

        protected void btndelete_OnClick(object sender, EventArgs e)
        {
            this.delViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
            string str = "customer";
            if (base.Request.Params["pgtype"] != null && base.Request.Params["pgtype"].ToString() != "")
            {
                str = base.Request.Params["pgtype"].ToString();
            }
            if (str.ToLower() == "customer")
            {
                this.ViewName = "crm_customer_view";
            }
            else if (str.ToLower() == "supplier")
            {
                this.ViewName = "crm_supplier_view";
            }
            else if (str.ToLower() == "prospect")
            {
                this.ViewName = "crm_prospect_view";
            }
            CompanyBasePage.View_Delete(this.companyId, str, this.delViewID, this.userId, this.ViewName);
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str1 = string.Concat(str, this.userId, str);
                if (str.ToLower() == "customer")
                {
                    base.Session["searchCust"] = null;
                    base.Session[str1] = null;
                    base.Session["CustViewID"] = null;
                    this.companytype = "customer";
                }
                else if (str.ToLower() == "supplier")
                {
                    base.Session["searchSupp"] = null;
                    base.Session[str1] = null;
                    base.Session["SuppViewID"] = null;
                    this.companytype = "supplier";
                }
                else if (str.ToLower() == "prospect")
                {
                    base.Session["searchPros"] = null;
                    base.Session[str1] = null;
                    base.Session["ProsViewID"] = null;
                    this.companytype = "prospect";
                }
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "client/customviewCRM.aspx?type=del&pgtype=", str));
        }

        protected void btnMove_OnClick(object sender, EventArgs e)
        {
            CustomViewCRM.MoveRecords(this.lstClumns, this.lstSelectedCols);
        }

        protected void btnReMove_OnClick(object sender, EventArgs e)
        {
            CustomViewCRM.ReMoveRecords(this.lstSelectedCols, this.lstClumns);
        }

        protected void btnsave_OnClick(object sender, EventArgs e)
        {
            string str = "customer";
            if (base.Request.Params["pgtype"] != null && base.Request.Params["pgtype"].ToString() != "")
            {
                str = base.Request.Params["pgtype"].ToString();
            }
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str1 = string.Concat(str, this.userId, str);
                if (str.ToLower() == "customer")
                {
                    base.Session["searchCust"] = null;
                    base.Session[str1] = null;
                    base.Session["CustViewID"] = null;
                }
                else if (str.ToLower() == "supplier")
                {
                    base.Session["searchSupp"] = null;
                    base.Session[str1] = null;
                    base.Session["SuppViewID"] = null;
                }
                else if (str.ToLower() == "prospect")
                {
                    base.Session["searchPros"] = null;
                    base.Session[str1] = null;
                    base.Session["ProsViewID"] = null;
                }
            }
            this.condition1 = this.objbase.SpecialEncode(this.ddlsearchfield1.SelectedItem.Value.ToString());
            this.condition2 = this.objbase.SpecialEncode(this.ddlsearchfield2.SelectedItem.Value.ToString());
            this.condition3 = this.objbase.SpecialEncode(this.ddlsearchfield3.SelectedItem.Value.ToString());
            this.condition4 = this.objbase.SpecialEncode(this.ddlsearchfield4.SelectedItem.Value.ToString());
            this.condition5 = this.objbase.SpecialEncode(this.ddlsearchfield5.SelectedItem.Value.ToString());
            this.operator1 = this.objbase.SpecialEncode(this.ddlsearchcondition1.SelectedItem.Value.ToString());
            this.operator2 = this.objbase.SpecialEncode(this.ddlsearchcondition2.SelectedItem.Value.ToString());
            this.operator3 = this.objbase.SpecialEncode(this.ddlsearchcondition3.SelectedItem.Value.ToString());
            this.operator4 = this.objbase.SpecialEncode(this.ddlsearchcondition4.SelectedItem.Value.ToString());
            this.operator5 = this.objbase.SpecialEncode(this.ddlsearchcondition5.SelectedItem.Value.ToString());
            this.value1 = this.objbase.SpecialEncode(this.txtsearchcriteria1.Text);
            this.value2 = this.objbase.SpecialEncode(this.txtsearchcriteria2.Text);
            this.value3 = this.objbase.SpecialEncode(this.txtsearchcriteria3.Text);
            this.value4 = this.objbase.SpecialEncode(this.txtsearchcriteria4.Text);
            this.value5 = this.objbase.SpecialEncode(this.txtsearchcriteria5.Text);
            this.ConditionalOperator1 = this.DrpdwnSearchCritria1.SelectedItem.Value.ToString();
            this.ConditionalOperator2 = this.DrpdwnSearchCritria2.SelectedItem.Value.ToString();
            this.ConditionalOperator3 = this.DrpdwnSearchCritria3.SelectedItem.Value.ToString();
            this.ConditionalOperator4 = this.DrpdwnSearchCritria4.SelectedItem.Value.ToString();
            this.ddl_sortby1 = this.objbase.SpecialEncode(this.ddl_sortby.SelectedItem.Value.ToString());
            this.ddl_direction1 = this.objbase.SpecialEncode(this.ddl_direction.SelectedItem.Value.ToString());
            this.isdeleted = 0;
            this.CreatedBy = int.Parse(base.Session["UserID"].ToString());
            this.UpdatedBy = int.Parse(base.Session["UserID"].ToString());
            this.CreatedOn = DateTime.Now.ToString();
            this.UpdatedOn = DateTime.Now.ToString();
            if (this.chk_Searchby.Checked)
            {
                this.isshowall = 1;
            }
            if (this.chk_setdefault.Checked)
            {
                this.isdefault = 1;
            }
            for (int i = 0; i < this.lstSelectedCols.Items.Count; i++)
            {
                CustomViewCRM usercontrolViewsCustomViewCRM = this;
                usercontrolViewsCustomViewCRM.chk_concat = string.Concat(usercontrolViewsCustomViewCRM.chk_concat, this.lstSelectedCols.Items[i].Value, ",");
            }
            if (str.ToLower() == "customer")
            {
                this.ViewName = "crm_customer_view";
            }
            else if (str.ToLower() == "supplier")
            {
                this.ViewName = "crm_supplier_view";
            }
            else if (str.ToLower() == "prospect")
            {
                this.ViewName = "crm_prospect_view";
            }
            if (base.Request.Params["type"] == null || base.Request.Params["id"] == null)
            {
                this.ViewID = (long)0;
                this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, "", "");
                if (this.isdefault == 1 && this.ret > 0)
                {
                    this.comm.UserSetting_Update(this.companyId, this.userId, this.ViewName, this.ret.ToString());
                }
            }
            else
            {
                if (base.Request.Params["type"].ToString() == "edit")
                {
                    if (this.pgtype.ToString().ToLower() != "customer")
                    {
                        this.ViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
                        this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str, this.isshowall, this.iszerothval, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, "", "");
                    }
                    else
                    {
                        this.ViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
                        this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str, this.isshowall, this.iszerothval, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, this.ddlCustomerType.SelectedItem.Text, "");
                    }
                    this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("CRM_Customized_View_Saved_Successfully"), "successfulMsg", this.plhMessage);
                }
                if (this.isdefault == 1 && this.ret > 0)
                {
                    this.comm.UserSetting_Update(this.companyId, this.userId, this.ViewName, this.ViewID.ToString());
                }
                else if (this.ret > 0 && this.comm.UserSetting_Selete(this.companyId, this.userId, this.ViewName) == this.ViewID.ToString())
                {
                    this.comm.UserSetting_Update(this.companyId, this.userId, this.ViewName, "0");
                }
            }
            this.objCreateView.View_Set_Default_All_zero_exist(str.Trim(), this.companyId);
            if (this.ret <= 0)
            {
                this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("View_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("CRM_Customized_View_Saved_Successfully"), "successfulMsg", this.plhMessage);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "client/client_view.aspx?type=", this.companytype, "&viewid=", this.ret };
            response.Redirect(string.Concat(objArray));
        }

        protected void btnsaveasnewview_OnClick(object sender, EventArgs e)
        {
            string str = "customer";
            if (base.Request.Params["pgtype"] != null && base.Request.Params["pgtype"].ToString() != "")
            {
                str = base.Request.Params["pgtype"].ToString();
            }
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str1 = string.Concat(str, this.userId, str);
                if (str.ToLower() == "customer")
                {
                    base.Session["searchCust"] = null;
                    base.Session[str1] = null;
                    base.Session["CustViewID"] = null;
                }
                else if (str.ToLower() == "supplier")
                {
                    base.Session["searchSupp"] = null;
                    base.Session[str1] = null;
                    base.Session["SuppViewID"] = null;
                }
                else if (str.ToLower() == "prospect")
                {
                    base.Session["searchPros"] = null;
                    base.Session[str1] = null;
                    base.Session["ProsViewID"] = null;
                }
            }
            this.condition1 = this.objbase.SpecialEncode(this.ddlsearchfield1.SelectedItem.Value.ToString());
            this.condition2 = this.objbase.SpecialEncode(this.ddlsearchfield2.SelectedItem.Value.ToString());
            this.condition3 = this.objbase.SpecialEncode(this.ddlsearchfield3.SelectedItem.Value.ToString());
            this.condition4 = this.objbase.SpecialEncode(this.ddlsearchfield4.SelectedItem.Value.ToString());
            this.condition5 = this.objbase.SpecialEncode(this.ddlsearchfield5.SelectedItem.Value.ToString());
            this.operator1 = this.objbase.SpecialEncode(this.ddlsearchcondition1.SelectedItem.Value.ToString());
            this.operator2 = this.objbase.SpecialEncode(this.ddlsearchcondition2.SelectedItem.Value.ToString());
            this.operator3 = this.objbase.SpecialEncode(this.ddlsearchcondition3.SelectedItem.Value.ToString());
            this.operator4 = this.objbase.SpecialEncode(this.ddlsearchcondition4.SelectedItem.Value.ToString());
            this.operator5 = this.objbase.SpecialEncode(this.ddlsearchcondition5.SelectedItem.Value.ToString());
            this.value1 = this.objbase.SpecialEncode(this.txtsearchcriteria1.Text);
            this.value2 = this.objbase.SpecialEncode(this.txtsearchcriteria2.Text);
            this.value3 = this.objbase.SpecialEncode(this.txtsearchcriteria3.Text);
            this.value4 = this.objbase.SpecialEncode(this.txtsearchcriteria4.Text);
            this.value5 = this.objbase.SpecialEncode(this.txtsearchcriteria5.Text);
            this.ConditionalOperator1 = this.DrpdwnSearchCritria1.SelectedItem.Value.ToString();
            this.ConditionalOperator2 = this.DrpdwnSearchCritria2.SelectedItem.Value.ToString();
            this.ConditionalOperator3 = this.DrpdwnSearchCritria3.SelectedItem.Value.ToString();
            this.ConditionalOperator4 = this.DrpdwnSearchCritria4.SelectedItem.Value.ToString();
            this.ddl_sortby1 = this.objbase.SpecialEncode(this.ddl_sortby.SelectedItem.Value.ToString());
            this.ddl_direction1 = this.objbase.SpecialEncode(this.ddl_direction.SelectedItem.Value.ToString());
            this.isdeleted = 0;
            this.CreatedBy = int.Parse(base.Session["UserID"].ToString());
            this.UpdatedBy = int.Parse(base.Session["UserID"].ToString());
            this.CreatedOn = DateTime.Now.ToString();
            this.UpdatedOn = DateTime.Now.ToString();
            if (this.chk_Searchby.Checked)
            {
                this.isshowall = 1;
            }
            if (this.chk_setdefault.Checked)
            {
                this.isdefault = 1;
            }
            for (int i = 0; i < this.lstSelectedCols.Items.Count; i++)
            {
                CustomViewCRM usercontrolViewsCustomViewCRM = this;
                usercontrolViewsCustomViewCRM.chk_concat = string.Concat(usercontrolViewsCustomViewCRM.chk_concat, this.lstSelectedCols.Items[i].Value, ",");
            }
            if (str.ToLower() == "customer")
            {
                this.ViewName = "crm_customer_view";
            }
            else if (str.ToLower() == "supplier")
            {
                this.ViewName = "crm_supplier_view";
            }
            else if (str.ToLower() == "prospect")
            {
                this.ViewName = "crm_prospect_view";
            }
            this.ViewID = (long)0;
            this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, "", "");
            if (this.isdefault == 1 && this.ret > 0)
            {
                this.comm.UserSetting_Update(this.companyId, this.userId, this.ViewName, this.ret.ToString());
            }
            this.objCreateView.View_Set_Default_All_zero_exist(str.Trim(), this.companyId);
            if (this.ret <= 0)
            {
                this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("View_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("CRM_Customized_View_Saved_Successfully"), "successfulMsg", this.plhMessage);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "client/client_view.aspx?type=", this.companytype, "&viewid=", this.ret };
            response.Redirect(string.Concat(objArray));
        }

        private void FetchedData(string[] ColNames)
        {
            for (int i = 0; i < (int)ColNames.Length - 1; i++)
            {
                int num = 0;
                while (num < this.lstClumns.Items.Count)
                {
                    if (this.lstClumns.Items[num].Value.ToLower() != ColNames[i].ToString().ToLower())
                    {
                        num++;
                    }
                    else
                    {
                        this.lstSelectedCols.Items.Insert(this.lstSelectedCols.Items.Count, this.lstClumns.Items[num]);
                        break;
                    }
                }
            }
            for (int j = 0; j < this.lstSelectedCols.Items.Count; j++)
            {
                this.lstSelectedCols.Items[j].ImageUrl = string.Concat(this.strImagePath, "drag_drop.gif");
                this.lstSelectedCols.Items[j].AllowDrag = true;
                this.lstSelectedCols.Items[j].Checked = false;
            }
        }

        protected void lstClumns_OnItemDataBound(object sender, RadListBoxItemEventArgs e)
        {
            e.Item.ImageUrl = "";
            e.Item.Checked = false;
            if (e.Item.Text.ToLower() == "name")
            {
                e.Item.Checked = false;
            }
        }

        protected void lstSelectedCols_OnItemDataBound(object sender, RadListBoxItemEventArgs e)
        {
            e.Item.ImageUrl = string.Concat(this.strImagePath, "drag_drop.gif");
        }

        private static void MoveRecords(RadListBox lstAll, RadListBox lstSelected)
        {
            foreach (RadListBoxItem checkedItem in lstAll.CheckedItems)
            {
                lstSelected.Items.Add(checkedItem);
                lstSelected.DataTextField = checkedItem.Text;
                lstSelected.DataValueField = checkedItem.Value;
            }
            for (int i = 0; i < lstSelected.Items.Count; i++)
            {
                lstSelected.Items[i].Checked = false;
                lstSelected.Items[i].ImageUrl = string.Concat(global.imagePath(), "drag_drop.gif");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblStep5.Text = this.objLangClass.GetLanguageConversion("Step5_Save_This_View_For_Future_Use");
            this.DrpdwnSearchCritria1.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria1.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria2.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria2.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria3.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria3.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria4.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria4.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.ddlCustomerType.Items[0].Text = this.objLangClass.GetLanguageConversion("All");
            this.ddlCustomerType.Items[1].Text = this.objLangClass.GetLanguageConversion("eStore_Customer");
            this.ddlCustomerType.Items[2].Text = this.objLangClass.GetLanguageConversion("Non_eStore_Customer");
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            empty = baseClass.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString());
            if (empty.Trim().ToLower() == "false")
            {
                this.Divdiv_btnsave.Visible = false;
            }
            else if (empty != "0")
            {
                this.Divdiv_btnsave.Visible = true;
            }
            else
            {
                this.Divdiv_btnsave.Visible = false;
            }
            string str = string.Empty;
            str = baseClass.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString());
            if (str.Trim().ToLower() == "false")
            {
                this.Divdiv_btndelete.Visible = false;
            }
            else if (str != "0")
            {
                this.Divdiv_btndelete.Visible = true;
            }
            else
            {
                this.Divdiv_btndelete.Visible = false;
            }
            this.lblerror1.Visible = false;
            this.lblerror2.Visible = false;
            this.lblerror3.Visible = false;
            this.lblerror4.Visible = false;
            this.lblerror5.Visible = false;
            this.btn_saveasnewview.Visible = false;
            this.btn_saveasnewview.Text = this.objLanguage.GetLanguageConversion("Save_As_New_View");
            this.btn_Save.Text = this.objLangClass.GetLanguageConversion("Save");
            this.companyId = int.Parse(base.Session["companyId"].ToString());
            this.userId = int.Parse(base.Session["UserID"].ToString());
            if (base.Request.Params["id"] != null)
            {
                this.dupViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
            }
            if (base.Request.Params["type"] == null)
            {
                this.lbl_header.Text = this.objLangClass.GetLanguageConversion("CRM_Custom_View_Add");
            }
            else if (base.Request.Params["type"].ToString() == "edit")
            {
                this.lbl_header.Text = "CRM: Custom View Edit";
            }
            if (base.Request.Params["type"] != null)
            {
                this.ReqType = base.Request.Params["type"].ToString().ToLower();
            }
            if (base.Request.Params["pgtype"] != null)
            {
                this.pgtype = base.Request.Params["pgtype"].ToString().ToLower();
                base.Session["pgtype"] = this.pgtype;
            }
            if (!base.IsPostBack)
            {
                if (base.Session["email"] == null)
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
                }
                foreach (DataRow row in this.objcomp.Clientaddresslabels(this.companyId).Rows)
                {
                    if (row["addresslkey"].ToString().ToLower() == "address1")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress1.Value = this.objLangClass.GetLanguageConversion("Address1");
                        }
                        else
                        {
                            this.hdnaddress1.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() == "address2")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress2.Value = this.objLangClass.GetLanguageConversion("Address2");
                        }
                        else
                        {
                            this.hdnaddress2.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() == "address3")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress3.Value = this.objLangClass.GetLanguageConversion("Address3");
                        }
                        else
                        {
                            this.hdnaddress3.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() == "address4")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress4.Value = this.objLangClass.GetLanguageConversion("Address4");
                        }
                        else
                        {
                            this.hdnaddress4.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() != "address5")
                    {
                        continue;
                    }
                    if (row["addressvalue"].ToString() == "")
                    {
                        this.hdnaddress5.Value = this.objLangClass.GetLanguageConversion("Address5");
                    }
                    else
                    {
                        this.hdnaddress5.Value = row["addressvalue"].ToString();
                    }
                }
                this.objCreateView.BindCustomColumns(this.pg, this.lstClumns);
                for (int i = 0; i < this.lstClumns.Items.Count; i++)
                {
                    if (this.lstClumns.Items[i].Value.ToLower() == "business fax")
                    {
                        this.lstClumns.Items[i].Style.Add("Display", "none");
                    }
                    if ((this.pgtype == "supplier" || this.pgtype == "prospect") && this.lstClumns.Items[i].Text.ToLower() == "store name")
                    {
                        this.lstClumns.Items[i].Style.Add("Display", "none");
                    }
                    if ((this.pgtype == "supplier" || this.pgtype == "prospect") && this.lstClumns.Items[i].Text.ToLower() == "refered by")
                    {
                        this.lstClumns.Items[i].Style.Add("Display", "none");
                    }
                    if ((this.pgtype == "supplier" || this.pgtype == "prospect") && (this.lstClumns.Items[i].Text.ToLower() == "default contact email" || this.lstClumns.Items[i].Text.ToLower() == "default department name" || this.lstClumns.Items[i].Text.ToLower() == "default contact name" || this.lstClumns.Items[i].Text.ToLower() == "address1" || this.lstClumns.Items[i].Text.ToLower() == "address2" || this.lstClumns.Items[i].Text.ToLower() == "address3" || this.lstClumns.Items[i].Text.ToLower() == "address4" || this.lstClumns.Items[i].Text.ToLower() == "address5"))
                    {
                        this.lstClumns.Items[i].Style.Add("Display", "none");
                    }
                    if (this.pgtype.ToLower() == "customer" && this.lstClumns.Items[i].Text.ToLower() == "business telephone")
                    {
                        this.lstClumns.Items[i].Text = this.objLangClass.GetLanguageConversion("Dept_Phone");
                    }
                    if (this.pgtype.ToLower() == "customer" && this.lstClumns.Items[i].Text.ToLower() == "address1")
                    {
                        this.lstClumns.Items[i].Text = this.hdnaddress1.Value;
                    }
                    else if (this.pgtype.ToLower() == "customer" && this.lstClumns.Items[i].Text.ToLower() == "address2")
                    {
                        this.lstClumns.Items[i].Text = this.hdnaddress2.Value;
                    }
                    else if (this.pgtype.ToLower() == "customer" && this.lstClumns.Items[i].Text.ToLower() == "address3")
                    {
                        this.lstClumns.Items[i].Text = this.hdnaddress3.Value;
                    }
                    else if (this.pgtype.ToLower() == "customer" && this.lstClumns.Items[i].Text.ToLower() == "address4")
                    {
                        this.lstClumns.Items[i].Text = this.hdnaddress4.Value;
                    }
                    else if (this.pgtype.ToLower() == "customer" && this.lstClumns.Items[i].Text.ToLower() == "address5")
                    {
                        this.lstClumns.Items[i].Text = this.hdnaddress5.Value;
                    }
                }
                if (base.Request.Params["type"] == null)
                {
                    this.TransferDefaultColumns();
                }
                else if (base.Request.Params["type"].ToString().ToLower() == "del")
                {
                    this.TransferDefaultColumns();
                }
                if (this.pgtype == "supplier" || this.pgtype == "prospect")
                {
                    this.divCustomer.Attributes.Add("style", "display:none");
                    this.lblStep5.Text = this.objLangClass.GetLanguageConversion("Step4_Save_This_View_For_Future_Use");
                }
                DropDownList[] value = new DropDownList[5];
                DropDownList[] dropDownListArray = new DropDownList[5];
                value[0] = this.ddlsearchfield1;
                value[1] = this.ddlsearchfield2;
                value[2] = this.ddlsearchfield3;
                value[3] = this.ddlsearchfield4;
                value[4] = this.ddlsearchfield5;
                dropDownListArray[0] = this.ddlsearchcondition1;
                dropDownListArray[1] = this.ddlsearchcondition2;
                dropDownListArray[2] = this.ddlsearchcondition3;
                dropDownListArray[3] = this.ddlsearchcondition4;
                dropDownListArray[4] = this.ddlsearchcondition5;
                this.objCreateView.initialize_DropDown_ForCustomView(this.companyId, this.pg, value, dropDownListArray);
                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby, this.ddl_direction);
                for (int j = 0; j < (int)value.Length; j++)
                {
                    for (int k = 0; k < value[j].Items.Count; k++)
                    {
                        if (this.pgtype.ToLower() == "customer")
                        {
                            if (value[j].Items[k].Text.ToLower() == "address1")
                            {
                                value[j].Items[k].Text = this.hdnaddress1.Value;
                            }
                            if (value[j].Items[k].Text.ToLower() == "address2")
                            {
                                value[j].Items[k].Text = this.hdnaddress2.Value;
                            }
                            if (value[j].Items[k].Text.ToLower() == "address3")
                            {
                                value[j].Items[k].Text = this.hdnaddress3.Value;
                            }
                            if (value[j].Items[k].Text.ToLower() == "address4")
                            {
                                value[j].Items[k].Text = this.hdnaddress4.Value;
                            }
                            if (value[j].Items[k].Text.ToLower() == "address5")
                            {
                                value[j].Items[k].Text = this.hdnaddress5.Value;
                            }
                        }
                        else if ((this.pgtype == "supplier" || this.pgtype == "prospect") && (value[j].Items[k].Text.ToLower() == "default contact email" || value[j].Items[k].Text.ToLower() == "default department name" || value[j].Items[k].Text.ToLower() == "default contact name" || value[j].Items[k].Text.ToLower() == "address1" || value[j].Items[k].Text.ToLower() == "address2" || value[j].Items[k].Text.ToLower() == "address3" || value[j].Items[k].Text.ToLower() == "address4" || value[j].Items[k].Text.ToLower() == "address5"))
                        {
                            value[j].Items[k].Attributes.Add("style", "display:none;");
                        }
                    }
                }
                for (int l = 0; l < this.ddl_sortby.Items.Count; l++)
                {
                    if (this.pgtype.ToLower() != "customer")
                    {
                        if ((this.pgtype == "supplier" || this.pgtype == "prospect") && (this.ddl_sortby.Items[l].Text.ToLower() == "default contact email" || this.ddl_sortby.Items[l].Text.ToLower() == "default department name" || this.ddl_sortby.Items[l].Text.ToLower() == "default contact name" || this.ddl_sortby.Items[l].Text.ToLower() == "address1" || this.ddl_sortby.Items[l].Text.ToLower() == "address2" || this.ddl_sortby.Items[l].Text.ToLower() == "address3" || this.ddl_sortby.Items[l].Text.ToLower() == "address4" || this.ddl_sortby.Items[l].Text.ToLower() == "address5"))
                        {
                            this.ddl_sortby.Items[l].Attributes.Add("style", "display:none;");
                        }
                    }
                    else if (this.ddl_sortby.Items[l].Text.ToLower() == "address1")
                    {
                        this.ddl_sortby.Items[l].Text = this.hdnaddress1.Value;
                    }
                    else if (this.ddl_sortby.Items[l].Text.ToLower() == "address2")
                    {
                        this.ddl_sortby.Items[l].Text = this.hdnaddress2.Value;
                    }
                    else if (this.ddl_sortby.Items[l].Text.ToLower() == "address3")
                    {
                        this.ddl_sortby.Items[l].Text = this.hdnaddress3.Value;
                    }
                    else if (this.ddl_sortby.Items[l].Text.ToLower() == "address4")
                    {
                        this.ddl_sortby.Items[l].Text = this.hdnaddress4.Value;
                    }
                    else if (this.ddl_sortby.Items[l].Text.ToLower() == "address5")
                    {
                        this.ddl_sortby.Items[l].Text = this.hdnaddress5.Value;
                    }
                }
            }
            if (base.Request.Params["pgtype"] != null && base.Request.Params["pgtype"].ToString() != "")
            {
                this.companytype = base.Request.Params["pgtype"].ToString();
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() == "edit" && base.Request.Params["id"] != null)
                {
                    this.btn_delete.Visible = true;
                    this.btn_saveasnewview.Visible = true;
                    this.btn_Save.Text = this.objLanguage.GetLanguageConversion("Save_and_Update");
                    if (this.objbase.ReturnRoles_Privileges_ForGrid("clients", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.btn_delete.Visible = false;
                    }
                    this.ViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    this.iszero = this.objCreateView.Check_Iszeroth_View(this.companyId, this.ViewID, this.companytype);
                    foreach (DataRow dataRow in this.iszero.Rows)
                    {
                        if (dataRow["Iszerothview"].ToString().ToLower() != "true")
                        {
                            continue;
                        }
                        this.btn_delete.Visible = false;
                        this.iszerothval = 1;
                    }
                    if (this.btn_delete.Visible)
                    {
                        this.btn_Save.Style.Remove("margin-left");
                    }
                    if (base.Request.Params["cid"].ToString() != null && base.Request.Params["cid"].ToString() == "0")
                    {
                        this.companyId = 0;
                    }
                    if (!base.IsPostBack)
                    {
                        DataTable dataTable = EstimateBasePage.Estimates_ViewName_Select_By_ID(Convert.ToInt32(this.companyId), this.ViewID, this.companytype);
                        foreach (DataRow row1 in dataTable.Rows)
                        {
                            this.txt_ViewName.Text = this.objbase.SpecialDecode(row1["ViewName"].ToString());
                            this.ddlsearchfield1.SelectedValue = row1["condition1"].ToString();
                            this.ddlsearchfield2.SelectedValue = row1["condition2"].ToString();
                            this.ddlsearchfield3.SelectedValue = row1["condition3"].ToString();
                            this.ddlsearchfield4.SelectedValue = row1["condition4"].ToString();
                            this.ddlsearchfield5.SelectedValue = row1["condition5"].ToString();
                            this.ddlsearchcondition1.SelectedValue = row1["operator1"].ToString();
                            this.ddlsearchcondition2.SelectedValue = row1["operator2"].ToString();
                            this.ddlsearchcondition3.SelectedValue = row1["operator3"].ToString();
                            this.ddlsearchcondition4.SelectedValue = row1["operator4"].ToString();
                            this.ddlsearchcondition5.SelectedValue = row1["operator5"].ToString();
                            this.txtsearchcriteria1.Text = row1["value1"].ToString();
                            this.txtsearchcriteria2.Text = row1["value2"].ToString();
                            this.txtsearchcriteria3.Text = row1["value3"].ToString();
                            this.txtsearchcriteria4.Text = row1["value4"].ToString();
                            this.txtsearchcriteria5.Text = row1["value5"].ToString();
                            this.DrpdwnSearchCritria1.SelectedValue = row1["CondnalOpertr1"].ToString();
                            this.DrpdwnSearchCritria2.SelectedValue = row1["CondnalOpertr2"].ToString();
                            this.DrpdwnSearchCritria3.SelectedValue = row1["CondnalOpertr3"].ToString();
                            this.DrpdwnSearchCritria4.SelectedValue = row1["CondnalOpertr4"].ToString();
                            this.ddl_sortby.SelectedValue = row1["SortedBy"].ToString();
                            this.ddl_direction.SelectedValue = row1["SortDirection"].ToString();
                            ListItem listItem = this.ddlCustomerType.Items.FindByText(row1["CustomerType"].ToString());
                            this.ddlCustomerType.SelectedIndex = this.ddlCustomerType.Items.IndexOf(listItem);
                            string str1 = row1["ColumnNames"].ToString();
                            char[] chrArray = new char[] { ',' };
                            this.FetchedData(str1.Split(chrArray));
                            if (this.companytype.ToLower() == "customer")
                            {
                                this.ViewName = "crm_customer_view";
                            }
                            else if (this.companytype.ToLower() == "supplier")
                            {
                                this.ViewName = "crm_supplier_view";
                            }
                            else if (this.companytype.ToLower() == "prospect")
                            {
                                this.ViewName = "crm_prospect_view";
                            }
                            string str2 = this.comm.UserSetting_Selete(this.companyId, this.userId, this.ViewName);
                            if (str2 != "" && str2 != null)
                            {
                                this.defaultviewid = Convert.ToInt32(str2);
                            }
                            if ((long)this.defaultviewid != this.dupViewID)
                            {
                                this.chk_setdefault.Checked = false;
                            }
                            else
                            {
                                this.chk_setdefault.Checked = true;
                            }
                            if (row1["isShowAllRecords"].ToString() == "")
                            {
                                continue;
                            }
                            if (row1["isShowAllRecords"].ToString().ToLower().Trim() != "true")
                            {
                                this.chk_Searchby.Checked = false;
                            }
                            else
                            {
                                this.isshowallrecords = 1;
                                this.chk_Searchby.Checked = true;
                            }
                        }
                    }
                }
                if (this.ReqType == "del")
                {
                    this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("CRM_Customized_View_Deleted_Successfully"), "successfulMsg", this.plhMessage);
                }
            }
            this.chk_Searchby.Text = this.objLangClass.GetLanguageConversion("Search_By_The_Following_Criteria");
            this.btn_Cancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            if (this.objbase.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                this.btn_Save.Visible = false;
            }
        }

        private static void ReMoveRecords(RadListBox lstSelected, RadListBox lstAll)
        {
            foreach (RadListBoxItem checkedItem in lstSelected.CheckedItems)
            {
                if (checkedItem.Text.ToLower() == "name")
                {
                    continue;
                }
                checkedItem.ImageUrl = "";
                checkedItem.Checked = false;
                lstAll.Items.Add(checkedItem);
                lstAll.DataTextField = checkedItem.Text;
                lstAll.DataValueField = checkedItem.Value;
            }
            for (int i = 0; i < lstAll.Items.Count; i++)
            {
                lstAll.Items[i].Checked = false;
                lstAll.Items[i].ImageUrl = "";
            }
        }

        private void TransferDefaultColumns()
        {
            for (int i = 0; i < this.lstClumns.Items.Count; i++)
            {
                if (this.lstClumns.Items[i].Text.ToLower() == "name")
                {
                    string value = this.lstClumns.Items[0].Value;
                    this.lstSelectedCols.Items.Add(this.lstClumns.Items[i]);
                    this.lstSelectedCols.Items[0].Text = "Name";
                    this.lstSelectedCols.Items[0].Value = value;
                    this.lstSelectedCols.Items[0].Checked = false;
                    this.lstSelectedCols.Items[0].AllowDrag = true;
                    this.lstSelectedCols.Items[0].ImageUrl = string.Concat(this.strImagePath, "drag_drop.gif");
                }
            }
            for (int j = 0; j < this.lstSelectedCols.Items.Count; j++)
            {
                this.lstSelectedCols.Items[j].ImageUrl = string.Concat(this.strImagePath, "drag_drop.gif");
                this.lstSelectedCols.Items[j].Checked = false;
            }
        }
    }
}