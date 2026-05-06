using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
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

namespace ePrint.usercontrol.Views
{
    public partial class CustomViewInv : System.Web.UI.UserControl
    {
        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public languageClass objLanguage = new languageClass();

        public commonClass comm = new commonClass();

        private createViewClass objCreateView = new createViewClass();

        public int companyId;

        public int userId;

        public long ViewID;

        public long delViewID;

        public long dupViewID;

        public DataTable iszero = new DataTable();

        public string pg = string.Empty;

        private BaseClass objbase = new BaseClass();

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

        public string ColorValue = string.Empty;

        public int isdeleted;

        public int CreatedBy;

        public int UpdatedBy;

        public string CreatedOn = string.Empty;

        public string UpdatedOn = string.Empty;

        public string chk_concat = string.Empty;

        public int isshowallrecords;

        public int iszerothval;

        public string InventoryManagement = string.Empty;

        public int defaultviewid;

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

        public CustomViewInv()
        {
        }

        protected void btncancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory"));
        }

        protected void btndelete_OnClick(object sender, EventArgs e)
        {
            this.delViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
            CompanyBasePage.View_Delete(this.companyId, "inventory", this.delViewID, this.userId, "inventory_view");
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str = string.Concat(this.pg, this.userId, this.pg);
                base.Session["searchInv"] = null;
                base.Session[str] = null;
                base.Session["InventoryViewID"] = null;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/customviewinv.aspx?type=del"));
        }

        protected void btnMove_OnClick(object sender, EventArgs e)
        {
            CustomViewInv.MoveRecords(this.lstClumns, this.lstSelectedCols);
        }

        protected void btnReMove_OnClick(object sender, EventArgs e)
        {
            CustomViewInv.ReMoveRecords(this.lstSelectedCols, this.lstClumns);
        }

        protected void btnsave_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str = string.Concat(this.pg, this.userId, this.pg);
                base.Session["searchInv"] = null;
                base.Session[str] = null;
                base.Session["InventoryViewID"] = null;
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
            if (this.condition1 == "IsArchived")
            {
                if (this.value1.ToString().ToLower() != "yes")
                {
                    this.value1 = "0";
                }
                else
                {
                    this.value1 = "1";
                }
            }
            else if (this.condition2 == "IsArchived")
            {
                if (this.value2.ToString().ToLower() != "yes")
                {
                    this.value2 = "0";
                }
                else
                {
                    this.value2 = "1";
                }
            }
            else if (this.condition3 == "IsArchived")
            {
                if (this.value3.ToString().ToLower() != "yes")
                {
                    this.value3 = "0";
                }
                else
                {
                    this.value3 = "1";
                }
            }
            else if (this.condition4 == "IsArchived")
            {
                if (this.value4.ToString().ToLower() != "yes")
                {
                    this.value4 = "0";
                }
                else
                {
                    this.value4 = "1";
                }
            }
            else if (this.condition5 == "IsArchived")
            {
                if (this.value5.ToString().ToLower() != "yes")
                {
                    this.value5 = "0";
                }
                else
                {
                    this.value5 = "1";
                }
            }
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
                CustomViewInv usercontrolViewsCustomViewInv = this;
                usercontrolViewsCustomViewInv.chk_concat = string.Concat(usercontrolViewsCustomViewInv.chk_concat, this.lstSelectedCols.Items[i].Value, ",");
            }
            CustomViewInv usercontrolViewsCustomViewInv1 = this;
            usercontrolViewsCustomViewInv1.chk_concat = string.Concat(usercontrolViewsCustomViewInv1.chk_concat, "Action,");
            string str1 = "inventory";
            string str2 = "";
            if (base.Request.Params["type"] == null || base.Request.Params["id"] == null)
            {
                this.ViewID = (long)0;
                this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.ReplaceSingleQuote(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.ReplaceSingleQuote(this.CreatedOn.ToString()), this.objbase.ReplaceSingleQuote(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Text);
                if (this.isdefault == 1 && this.ret > 0)
                {
                    this.comm.UserSetting_Update(this.companyId, this.userId, "inventory_view", this.ret.ToString());
                }
            }
            else
            {
                if (base.Request.Params["type"].ToString() == "edit")
                {
                    this.ViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.ReplaceSingleQuote(this.CreatedOn.ToString()), this.objbase.ReplaceSingleQuote(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, this.iszerothval, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Text);
                    this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Customizeview_Saved_Note"), "successfulMsg", this.plhMessage);
                }
                if (this.isdefault == 1 && this.ret > 0)
                {
                    this.comm.UserSetting_Update(this.companyId, this.userId, "inventory_view", this.ViewID.ToString());
                }
                else if (this.ret > 0 && this.comm.UserSetting_Selete(this.companyId, this.userId, "inventory_view") == this.ViewID.ToString())
                {
                    this.comm.UserSetting_Update(this.companyId, this.userId, "inventory_view", "0");
                }
            }
            this.objCreateView.View_Set_Default_All_zero_exist("inventory", this.companyId);
            if (this.ret <= 0)
            {
                this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("View_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Customizeview_Saved_Note"), "successfulMsg", this.plhMessage);
            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory&viewid=", this.ret));
        }

        protected void btnsaveasnewview_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str = string.Concat(this.pg, this.userId, this.pg);
                base.Session["searchInv"] = null;
                base.Session[str] = null;
                base.Session["InventoryViewID"] = null;
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
            if (this.condition1 == "IsArchived")
            {
                if (this.value1.ToString().ToLower() != "yes")
                {
                    this.value1 = "0";
                }
                else
                {
                    this.value1 = "1";
                }
            }
            else if (this.condition2 == "IsArchived")
            {
                if (this.value2.ToString().ToLower() != "yes")
                {
                    this.value2 = "0";
                }
                else
                {
                    this.value2 = "1";
                }
            }
            else if (this.condition3 == "IsArchived")
            {
                if (this.value3.ToString().ToLower() != "yes")
                {
                    this.value3 = "0";
                }
                else
                {
                    this.value3 = "1";
                }
            }
            else if (this.condition4 == "IsArchived")
            {
                if (this.value4.ToString().ToLower() != "yes")
                {
                    this.value4 = "0";
                }
                else
                {
                    this.value4 = "1";
                }
            }
            else if (this.condition5 == "IsArchived")
            {
                if (this.value5.ToString().ToLower() != "yes")
                {
                    this.value5 = "0";
                }
                else
                {
                    this.value5 = "1";
                }
            }
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
                CustomViewInv usercontrolViewsCustomViewInv = this;
                usercontrolViewsCustomViewInv.chk_concat = string.Concat(usercontrolViewsCustomViewInv.chk_concat, this.lstSelectedCols.Items[i].Value, ",");
            }
            CustomViewInv usercontrolViewsCustomViewInv1 = this;
            usercontrolViewsCustomViewInv1.chk_concat = string.Concat(usercontrolViewsCustomViewInv1.chk_concat, "Action,");
            string str1 = "inventory";
            string str2 = "";
            this.ViewID = (long)0;
            this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.ReplaceSingleQuote(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.ReplaceSingleQuote(this.CreatedOn.ToString()), this.objbase.ReplaceSingleQuote(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Text);
            if (this.isdefault == 1 && this.ret > 0)
            {
                this.comm.UserSetting_Update(this.companyId, this.userId, "inventory_view", this.ret.ToString());
            }
            this.objCreateView.View_Set_Default_All_zero_exist("inventory", this.companyId);
            if (this.ret <= 0)
            {
                this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("View_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Customizeview_Saved_Note"), "successfulMsg", this.plhMessage);
            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory&viewid=", this.ret));
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
            if (e.Item.Text.ToLower() == "inventory code")
            {
                e.Item.Text = "Inventory Code";
                e.Item.Checked = false;
            }
            if (e.Item.Text.ToLower() == "inventory name")
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
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            empty = baseClass.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString());
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(Convert.ToInt32(base.Session["CompanyID"].ToString()));
            this.ColorValue = dataTable.Rows[0]["Colour"].ToString();
            if (empty.Trim().ToLower() != "false")
            {
                this.Divdiv_btnsave.Visible = true;
            }
            else
            {
                this.Divdiv_btnsave.Visible = false;
            }
            string str = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("warehouse", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.div_btndelete1.Visible = true;
            }
            else
            {
                this.div_btndelete1.Visible = false;
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
            if (ConnectionClass.InventoryManagement != null)
            {
                this.InventoryManagement = ConnectionClass.InventoryManagement;
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["type"] != null)
                {
                    this.ReqType = base.Request.Params["type"].ToString().ToLower();
                }
                if (base.Session["email"] == null)
                {
                    base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
                }
                this.objCreateView.BindCustomColumns("inventory", this.lstClumns);
                for (int i = 0; i < this.lstClumns.Items.Count; i++)
                {
                    if (this.lstClumns.Items[i].Value.ToLower() == "inventorycode")
                    {
                        this.lstClumns.Items[i].Text = "Inventory Code";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "customheight")
                    {
                        this.lstClumns.Items[i].Text = "Weight/Size";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "customstocktype")
                    {
                        this.lstClumns.Items[i].Text = "Stock Type";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "isarchived")
                    {
                        this.lstClumns.Items[i].Text = "Archived";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "friendlyname")
                    {
                        this.lstClumns.Items[i].Text = "Friendly Name";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "colour")
                    {
                        this.lstClumns.Items[i].Text = this.ColorValue;
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "cost")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Cost (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "unitprice")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Unit Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "availablequantity" && this.InventoryManagement.ToLower() != "im")
                    {
                        this.lstClumns.Items[i].Attributes.Add("style", "display:none");
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
                DropDownList[] colorValue = new DropDownList[5];
                DropDownList[] dropDownListArray = new DropDownList[5];
                colorValue[0] = this.ddlsearchfield1;
                colorValue[1] = this.ddlsearchfield2;
                colorValue[2] = this.ddlsearchfield3;
                colorValue[3] = this.ddlsearchfield4;
                colorValue[4] = this.ddlsearchfield5;
                dropDownListArray[0] = this.ddlsearchcondition1;
                dropDownListArray[1] = this.ddlsearchcondition2;
                dropDownListArray[2] = this.ddlsearchcondition3;
                dropDownListArray[3] = this.ddlsearchcondition4;
                dropDownListArray[4] = this.ddlsearchcondition5;
                this.objCreateView.initialize_DropDown_ForCustomView(this.companyId, this.pg, colorValue, dropDownListArray);
                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby, this.ddl_direction);
                for (int j = 0; j <= 4; j++)
                {
                    for (int k = 0; k < colorValue[j].Items.Count; k++)
                    {
                        if (colorValue[j].Items[k].ToString().ToLower() == "customstock type")
                        {
                            colorValue[j].Items[k].Text = "Stock Type";
                        }
                        if (colorValue[j].Items[k].ToString().ToLower() == "customheight")
                        {
                            colorValue[j].Items.RemoveAt(k);
                        }
                        if (colorValue[j].Items[k].ToString().ToLower() == "colour")
                        {
                            colorValue[j].Items[k].Text = this.ColorValue;
                        }
                        if (colorValue[j].Items[k].ToString().ToLower() == "cost")
                        {
                            colorValue[j].Items[k].Text = string.Concat("Cost (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (colorValue[j].Items[k].ToString().ToLower() == "unit price")
                        {
                            colorValue[j].Items[k].Text = string.Concat("Unit Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (this.InventoryManagement.ToLower() == "im" && colorValue[j].Items[k].ToString().ToLower() == "availablequantity")
                        {
                            colorValue[j].Items[k].Text = "Available Quantity";
                        }
                        if (this.InventoryManagement.ToLower() != "im" && colorValue[j].Items[k].ToString().ToLower() == "availablequantity")
                        {
                            colorValue[j].Items.RemoveAt(k);
                        }
                    }
                }
                for (int l = 0; l < this.ddl_sortby.Items.Count; l++)
                {
                    if (this.ddl_sortby.Items[l].ToString().ToLower() == "customstock type")
                    {
                        this.ddl_sortby.Items[l].Text = "Stock Type";
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower() == "colour")
                    {
                        this.ddl_sortby.Items[l].Text = this.ColorValue;
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower() == "customheight")
                    {
                        this.ddl_sortby.Items.RemoveAt(l);
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower() == "cost")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Cost (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower() == "unit price")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Unit Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.InventoryManagement.ToLower() == "im" && this.ddl_sortby.Items[l].ToString().ToLower() == "availablequantity")
                    {
                        this.ddl_sortby.Items[l].Text = "Available Quantity";
                    }
                    if (this.InventoryManagement.ToLower() != "im" && this.ddl_sortby.Items[l].ToString().ToLower() == "availablequantity")
                    {
                        this.ddl_sortby.Items.RemoveAt(l);
                    }
                }
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() == "edit" && base.Request.Params["id"] != null)
                {
                    this.btn_delete.Visible = true;
                    this.btn_saveasnewview.Visible = true;
                    this.btn_Save.Text = this.objLanguage.GetLanguageConversion("Save_and_Update");
                    this.ViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    this.iszero = this.objCreateView.Check_Iszeroth_View(this.companyId, this.ViewID, "inventory");
                    foreach (DataRow row in this.iszero.Rows)
                    {
                        if (row["Iszerothview"].ToString().ToLower() != "true")
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
                    if (!base.IsPostBack)
                    {
                        DataTable dataTable1 = EstimateBasePage.Estimates_ViewName_Select_By_ID(Convert.ToInt32(this.companyId), this.ViewID, "inventory");
                        foreach (DataRow dataRow in dataTable1.Rows)
                        {
                            this.txt_ViewName.Text = this.objbase.SpecialDecode(dataRow["ViewName"].ToString());
                            this.ddlsearchfield1.SelectedValue = dataRow["condition1"].ToString();
                            this.ddlsearchfield2.SelectedValue = dataRow["condition2"].ToString();
                            this.ddlsearchfield3.SelectedValue = dataRow["condition3"].ToString();
                            this.ddlsearchfield4.SelectedValue = dataRow["condition4"].ToString();
                            this.ddlsearchfield5.SelectedValue = dataRow["condition5"].ToString();
                            this.ddlsearchcondition1.SelectedValue = dataRow["operator1"].ToString();
                            this.ddlsearchcondition2.SelectedValue = dataRow["operator2"].ToString();
                            this.ddlsearchcondition3.SelectedValue = dataRow["operator3"].ToString();
                            this.ddlsearchcondition4.SelectedValue = dataRow["operator4"].ToString();
                            this.ddlsearchcondition5.SelectedValue = dataRow["operator5"].ToString();
                            this.txtsearchcriteria1.Text = this.objbase.SpecialDecode(dataRow["value1"].ToString());
                            this.txtsearchcriteria2.Text = this.objbase.SpecialDecode(dataRow["value2"].ToString());
                            this.txtsearchcriteria3.Text = this.objbase.SpecialDecode(dataRow["value3"].ToString());
                            this.txtsearchcriteria4.Text = this.objbase.SpecialDecode(dataRow["value4"].ToString());
                            this.txtsearchcriteria5.Text = this.objbase.SpecialDecode(dataRow["value5"].ToString());
                            this.DrpdwnSearchCritria1.SelectedValue = dataRow["CondnalOpertr1"].ToString();
                            this.DrpdwnSearchCritria2.SelectedValue = dataRow["CondnalOpertr2"].ToString();
                            this.DrpdwnSearchCritria3.SelectedValue = dataRow["CondnalOpertr3"].ToString();
                            this.DrpdwnSearchCritria4.SelectedValue = dataRow["CondnalOpertr4"].ToString();
                            this.ddlShowRecords.SelectedValue = dataRow["RecordsToDisplay"].ToString();
                            if (this.ddlsearchfield1.SelectedValue == "IsArchived")
                            {
                                if (this.txtsearchcriteria1.Text.ToString().ToLower() != "1")
                                {
                                    this.txtsearchcriteria1.Text = "No";
                                }
                                else
                                {
                                    this.txtsearchcriteria1.Text = "Yes";
                                }
                            }
                            else if (this.ddlsearchfield2.SelectedValue == "IsArchived")
                            {
                                if (this.txtsearchcriteria2.Text.ToString().ToLower() != "1")
                                {
                                    this.txtsearchcriteria2.Text = "No";
                                }
                                else
                                {
                                    this.txtsearchcriteria2.Text = "Yes";
                                }
                            }
                            else if (this.ddlsearchfield3.SelectedValue == "IsArchived")
                            {
                                if (this.txtsearchcriteria3.Text.ToString().ToLower() != "1")
                                {
                                    this.txtsearchcriteria3.Text = "No";
                                }
                                else
                                {
                                    this.txtsearchcriteria3.Text = "Yes";
                                }
                            }
                            else if (this.ddlsearchfield4.SelectedValue == "IsArchived")
                            {
                                if (this.txtsearchcriteria4.Text.ToString().ToLower() != "1")
                                {
                                    this.txtsearchcriteria4.Text = "No";
                                }
                                else
                                {
                                    this.txtsearchcriteria4.Text = "Yes";
                                }
                            }
                            else if (this.ddlsearchfield5.SelectedValue == "IsArchived")
                            {
                                if (this.txtsearchcriteria5.Text.ToString().ToLower() != "1")
                                {
                                    this.txtsearchcriteria5.Text = "No";
                                }
                                else
                                {
                                    this.txtsearchcriteria5.Text = "Yes";
                                }
                            }
                            this.ddl_sortby.SelectedValue = dataRow["SortedBy"].ToString();
                            this.ddl_direction.SelectedValue = dataRow["SortDirection"].ToString();
                            string str1 = dataRow["ColumnNames"].ToString();
                            char[] chrArray = new char[] { ',' };
                            this.FetchedData(str1.Split(chrArray));
                            if (dataRow["isShowAllRecords"].ToString() == "")
                            {
                                continue;
                            }
                            if (dataRow["isShowAllRecords"].ToString().ToLower().Trim() != "true")
                            {
                                this.chk_Searchby.Checked = false;
                            }
                            else
                            {
                                this.isshowallrecords = 1;
                                this.chk_Searchby.Checked = true;
                            }
                        }
                        string str2 = this.comm.UserSetting_Selete(this.companyId, this.userId, "inventory_view");
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
                    }
                }
                if (this.ReqType == "del")
                {
                    this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Customizeview_Delete_Note"), "successfulMsg", this.plhMessage);
                }
            }
            this.chk_Searchby.Text = this.objLangClass.GetLanguageConversion("Search_By_The_Following_Criteria");
            this.btn_Cancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.chk_setdefault.Text = this.objLangClass.GetLanguageConversion("Set_This_View_As_My_Default");
            this.lblAvailableCols.Text = this.objLangClass.GetLanguageConversion("Available_Columns");
            this.lblSelectedCols.Text = this.objLangClass.GetLanguageConversion("Selected_Columns");
            this.DrpdwnSearchCritria1.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria1.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria2.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria2.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria3.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria3.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria4.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria4.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
        }

        private static void ReMoveRecords(RadListBox lstSelected, RadListBox lstAll)
        {
            foreach (RadListBoxItem checkedItem in lstSelected.CheckedItems)
            {
                if (!(checkedItem.Text.ToLower() != "inventory code") || !(checkedItem.Text.ToLower() != "inventory name"))
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
            for (int i = 0; i < this.lstClumns.Items.Count - 1; i++)
            {
                if (this.lstClumns.Items[i].Value.ToLower() == "inventorycode")
                {
                    this.lstSelectedCols.Items.Insert(0, this.lstClumns.Items[i]);
                    this.lstSelectedCols.Items.Add(this.lstClumns.Items[i]);
                    this.lstSelectedCols.Items[i].Text = "Inventory Code";
                    this.lstSelectedCols.Items[i].Checked = false;
                    this.lstSelectedCols.Items[i].AllowDrag = true;
                    this.lstSelectedCols.Items[i].ImageUrl = string.Concat(this.strImagePath, "drag_drop.gif");
                    this.lstClumns.Items[i].Remove();
                }
                if (this.lstClumns.Items[i].Text.ToLower() == "inventory name")
                {
                    this.lstSelectedCols.Items.Insert(1, this.lstClumns.Items[i]);
                    this.lstSelectedCols.Items.Add(this.lstClumns.Items[i]);
                    this.lstSelectedCols.Items[i].AllowDrag = true;
                    this.lstSelectedCols.Items[i].Checked = false;
                    this.lstSelectedCols.Items[i].ImageUrl = string.Concat(this.strImagePath, "drag_drop.gif");
                    this.lstClumns.Items[i].Remove();
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