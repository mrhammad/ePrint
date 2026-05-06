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
namespace ePrint.usercontrol.Views
{
    public partial class CustomViewDelivery : System.Web.UI.UserControl
    {
        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public languageClass objLanguage = new languageClass();

        public BasePage objpage = new BasePage();

        public commonClass comm = new commonClass();

        private createViewClass objCreateView = new createViewClass();

        public languageClass objLangClass = new languageClass();

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

        public int isdeleted;

        public int CreatedBy;

        public int UpdatedBy;

        public string CreatedOn = string.Empty;

        public string UpdatedOn = string.Empty;

        public string chk_concat = string.Empty;

        public int isshowallrecords;

        public int iszerothval;

        public int defaultviewid;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagePath = global.imagePath();
        public string condition6 = string.Empty;

        public string condition7 = string.Empty;

        public string condition8 = string.Empty;
        public string condition9 = string.Empty;

        public string condition10 = string.Empty;
        public string operator6 = string.Empty;

        public string operator7 = string.Empty;

        public string operator8 = string.Empty;
        public string operator9 = string.Empty;

        public string operator10 = string.Empty;
        public string value6 = string.Empty;

        public string value7 = string.Empty;

        public string value8 = string.Empty;
        public string value9 = string.Empty;

        public string value10 = string.Empty;
        public string ConditionalOperator5 = string.Empty;
        public string ConditionalOperator6 = string.Empty;
        public string ConditionalOperator7 = string.Empty;
        public string ConditionalOperator8 = string.Empty;
        public string ConditionalOperator9 = string.Empty;
        public string ddl_sortby_2 = string.Empty;

        public string ddl_direction_2 = string.Empty;
        public string ddl_sortby_3 = string.Empty;

        public string ddl_direction_3 = string.Empty;
        public string ddl_sortby_4 = string.Empty;

        public string ddl_direction_4 = string.Empty;

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

        public CustomViewDelivery()
        {
        }

        protected void btncancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "Delivery/delivery_view.aspx"));
        }

        protected void btndelete_OnClick(object sender, EventArgs e)
        {
            this.delViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
            CompanyBasePage.View_Delete(this.companyId, "deliverynote", this.delViewID, this.userId, "delivery_note_view");
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str = string.Concat(this.pg, this.userId, this.pg);
                base.Session["search_del"] = null;
                base.Session[str] = null;
                base.Session["DelViewID"] = null;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "delivery/customviewdelivery.aspx?type=del"));
        }

        protected void btnMove_OnClick(object sender, EventArgs e)
        {
            CustomViewDelivery.MoveRecords(this.lstClumns, this.lstSelectedCols);
        }

        protected void btnReMove_OnClick(object sender, EventArgs e)
        {
            CustomViewDelivery.ReMoveRecords(this.lstSelectedCols, this.lstClumns);
        }

        protected void btnsave_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str = string.Concat(this.pg, this.userId, this.pg);
                base.Session["search_del"] = null;
                base.Session[str] = null;
                base.Session["DelViewID"] = null;
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
            //83

            this.condition6 = this.objbase.SpecialEncode(this.ddlsearchfield6.SelectedItem.Value.ToString());
            this.condition7 = this.objbase.SpecialEncode(this.ddlsearchfield7.SelectedItem.Value.ToString());
            this.condition8 = this.objbase.SpecialEncode(this.ddlsearchfield8.SelectedItem.Value.ToString());
            this.condition9 = this.objbase.SpecialEncode(this.ddlsearchfield9.SelectedItem.Value.ToString());
            this.condition10 = this.objbase.SpecialEncode(this.ddlsearchfield10.SelectedItem.Value.ToString());

            this.operator6 = this.objbase.SpecialEncode(this.ddlsearchcondition6.SelectedItem.Value.ToString());
            this.operator7 = this.objbase.SpecialEncode(this.ddlsearchcondition7.SelectedItem.Value.ToString());
            this.operator8 = this.objbase.SpecialEncode(this.ddlsearchcondition8.SelectedItem.Value.ToString());
            this.operator9 = this.objbase.SpecialEncode(this.ddlsearchcondition9.SelectedItem.Value.ToString());
            this.operator10 = this.objbase.SpecialEncode(this.ddlsearchcondition10.SelectedItem.Value.ToString());

            this.value6 = this.objbase.SpecialEncode(this.txtsearchcriteria6.Text);
            this.value7 = this.objbase.SpecialEncode(this.txtsearchcriteria7.Text);
            this.value8 = this.objbase.SpecialEncode(this.txtsearchcriteria8.Text);
            this.value9 = this.objbase.SpecialEncode(this.txtsearchcriteria9.Text);
            this.value10 = this.objbase.SpecialEncode(this.txtsearchcriteria10.Text);

            this.ConditionalOperator5 = this.DrpdwnSearchCritria5.SelectedItem.Value.ToString();
            this.ConditionalOperator6 = this.DrpdwnSearchCritria6.SelectedItem.Value.ToString();
            this.ConditionalOperator7 = this.DrpdwnSearchCritria7.SelectedItem.Value.ToString();
            this.ConditionalOperator8 = this.DrpdwnSearchCritria8.SelectedItem.Value.ToString();
            this.ConditionalOperator9 = this.DrpdwnSearchCritria9.SelectedItem.Value.ToString();

            this.ddl_sortby_2 = objbase.SpecialEncode(this.ddl_sortby2.SelectedItem.Value.ToString());
            this.ddl_direction_2 = this.objbase.SpecialEncode(this.ddl_direction2.SelectedItem.Value.ToString());
            this.ddl_sortby_3 = this.objbase.SpecialEncode(this.ddl_sortby3.SelectedItem.Value.ToString());
            this.ddl_direction_3 = this.objbase.SpecialEncode(this.ddl_direction3.SelectedItem.Value.ToString());
            this.ddl_sortby_4 = this.objbase.SpecialEncode(this.ddl_sortby4.SelectedItem.Value.ToString());
            this.ddl_direction_4 = this.objbase.SpecialEncode(this.ddl_direction4.SelectedItem.Value.ToString());

            //83
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
                CustomViewDelivery usercontrolViewsCustomViewDelivery = this;
                usercontrolViewsCustomViewDelivery.chk_concat = string.Concat(usercontrolViewsCustomViewDelivery.chk_concat, this.lstSelectedCols.Items[i].Value, ",");
            }
            this.chk_concat = string.Concat(this.chk_concat, "EstItemCoun,");
            string str1 = "deliverynote";
            string str2 = "";
            if (base.Request.Params["type"] == null || base.Request.Params["id"] == null)
            {
                this.ViewID = (long)0;
                this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.ReplaceSingleQuote(this.CreatedOn.ToString()), this.objbase.ReplaceSingleQuote(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Value, this.ddlDateType.SelectedItem.Value, this.ddlDateRange.SelectedItem.Value, this.condition6, this.condition7, this.condition8, this.condition9, this.condition10, this.operator6, this.operator7, this.operator8, this.operator9, this.operator10, this.value6, this.value7, this.value8, this.value9, this.value10, this.ConditionalOperator5, this.ConditionalOperator6, this.ConditionalOperator7, this.ConditionalOperator8, this.ConditionalOperator9, this.ddl_sortby_2, this.ddl_direction_2, this.ddl_sortby_3, this.ddl_direction_3, this.ddl_sortby_4, this.ddl_direction_4);
                if (this.isdefault == 1 && this.ret > 0)
                {
                    this.comm.UserSetting_Update(this.companyId, this.userId, "delivery_note_view", this.ret.ToString());
                }
            }
            else
            {
                if (base.Request.Params["type"].ToString() == "edit")
                {
                    this.ViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.ReplaceSingleQuote(this.CreatedOn.ToString()), this.objbase.ReplaceSingleQuote(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, this.iszerothval, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Value, this.ddlDateType.SelectedItem.Value, this.ddlDateRange.SelectedItem.Value, this.condition6, this.condition7, this.condition8, this.condition9, this.condition10, this.operator6, this.operator7, this.operator8, this.operator9, this.operator10, this.value6, this.value7, this.value8, this.value9, this.value10, this.ConditionalOperator5, this.ConditionalOperator6, this.ConditionalOperator7, this.ConditionalOperator8, this.ConditionalOperator9, this.ddl_sortby_2, this.ddl_direction_2, this.ddl_sortby_3, this.ddl_direction_3, this.ddl_sortby_4, this.ddl_direction_4);
                    this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_View_Save_Note"), "successfulMsg", this.plhMessage);
                }
                if (this.isdefault == 1 && this.ret > 0)
                {
                    this.comm.UserSetting_Update(this.companyId, this.userId, "delivery_note_view", this.ViewID.ToString());
                }
                else if (this.ret > 0 && this.comm.UserSetting_Selete(this.companyId, this.userId, "delivery_note_view") == this.ViewID.ToString())
                {
                    this.comm.UserSetting_Update(this.companyId, this.userId, "delivery_note_view", "0");
                }
            }
            this.objCreateView.View_Set_Default_All_zero_exist("deliverynote", this.companyId);
            if (this.ret <= 0)
            {
                this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("View_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_View_Save_Note"), "successfulMsg", this.plhMessage);
            base.Response.Redirect(string.Concat(this.strSitepath, "Delivery/delivery_view.aspx?viewid=", this.ret));
        }

        protected void btnsaveasnewview_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str = string.Concat(this.pg, this.userId, this.pg);
                base.Session["search_del"] = null;
                base.Session[str] = null;
                base.Session["DelViewID"] = null;
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


            //83

            this.condition6 = this.objbase.SpecialEncode(this.ddlsearchfield6.SelectedItem.Value.ToString());
            this.condition7 = this.objbase.SpecialEncode(this.ddlsearchfield7.SelectedItem.Value.ToString());
            this.condition8 = this.objbase.SpecialEncode(this.ddlsearchfield8.SelectedItem.Value.ToString());
            this.condition9 = this.objbase.SpecialEncode(this.ddlsearchfield9.SelectedItem.Value.ToString());
            this.condition10 = this.objbase.SpecialEncode(this.ddlsearchfield10.SelectedItem.Value.ToString());

            this.operator6 = this.objbase.SpecialEncode(this.ddlsearchcondition6.SelectedItem.Value.ToString());
            this.operator7 = this.objbase.SpecialEncode(this.ddlsearchcondition7.SelectedItem.Value.ToString());
            this.operator8 = this.objbase.SpecialEncode(this.ddlsearchcondition8.SelectedItem.Value.ToString());
            this.operator9 = this.objbase.SpecialEncode(this.ddlsearchcondition9.SelectedItem.Value.ToString());
            this.operator10 = this.objbase.SpecialEncode(this.ddlsearchcondition10.SelectedItem.Value.ToString());

            this.value6 = this.objbase.SpecialEncode(this.txtsearchcriteria6.Text);
            this.value7 = this.objbase.SpecialEncode(this.txtsearchcriteria7.Text);
            this.value8 = this.objbase.SpecialEncode(this.txtsearchcriteria8.Text);
            this.value9 = this.objbase.SpecialEncode(this.txtsearchcriteria9.Text);
            this.value10 = this.objbase.SpecialEncode(this.txtsearchcriteria10.Text);

            this.ConditionalOperator5 = this.DrpdwnSearchCritria5.SelectedItem.Value.ToString();
            this.ConditionalOperator6 = this.DrpdwnSearchCritria6.SelectedItem.Value.ToString();
            this.ConditionalOperator7 = this.DrpdwnSearchCritria7.SelectedItem.Value.ToString();
            this.ConditionalOperator8 = this.DrpdwnSearchCritria8.SelectedItem.Value.ToString();
            this.ConditionalOperator9 = this.DrpdwnSearchCritria9.SelectedItem.Value.ToString();

            this.ddl_sortby_2 = objbase.SpecialEncode(this.ddl_sortby2.SelectedItem.Value.ToString());
            this.ddl_direction_2 = this.objbase.SpecialEncode(this.ddl_direction2.SelectedItem.Value.ToString());
            this.ddl_sortby_3 = this.objbase.SpecialEncode(this.ddl_sortby3.SelectedItem.Value.ToString());
            this.ddl_direction_3 = this.objbase.SpecialEncode(this.ddl_direction3.SelectedItem.Value.ToString());
            this.ddl_sortby_4 = this.objbase.SpecialEncode(this.ddl_sortby4.SelectedItem.Value.ToString());
            this.ddl_direction_4 = this.objbase.SpecialEncode(this.ddl_direction4.SelectedItem.Value.ToString());

            //83
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
                CustomViewDelivery usercontrolViewsCustomViewDelivery = this;
                usercontrolViewsCustomViewDelivery.chk_concat = string.Concat(usercontrolViewsCustomViewDelivery.chk_concat, this.lstSelectedCols.Items[i].Value, ",");
            }
            this.chk_concat = string.Concat(this.chk_concat, "EstItemCoun,");
            string str1 = "deliverynote";
            string str2 = "";
            this.ViewID = (long)0;
            this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.ReplaceSingleQuote(this.CreatedOn.ToString()), this.objbase.ReplaceSingleQuote(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Value, this.ddlDateType.SelectedItem.Value, this.ddlDateRange.SelectedItem.Value, this.condition6, this.condition7, this.condition8, this.condition9, this.condition10, this.operator6, this.operator7, this.operator8, this.operator9, this.operator10, this.value6, this.value7, this.value8, this.value9, this.value10, this.ConditionalOperator5, this.ConditionalOperator6, this.ConditionalOperator7, this.ConditionalOperator8, this.ConditionalOperator9, this.ddl_sortby_2, this.ddl_direction_2, this.ddl_sortby_3, this.ddl_direction_3, this.ddl_sortby_4, this.ddl_direction_4);
            if (this.isdefault == 1 && this.ret > 0)
            {
                this.comm.UserSetting_Update(this.companyId, this.userId, "delivery_note_view", this.ret.ToString());
            }
            this.objCreateView.View_Set_Default_All_zero_exist("deliverynote", this.companyId);
            if (this.ret <= 0)
            {
                this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("View_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_View_Save_Note"), "successfulMsg", this.plhMessage);
            base.Response.Redirect(string.Concat(this.strSitepath, "Delivery/delivery_view.aspx?viewid=", this.ret));
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
            if (e.Item.Text.ToLower() == "delivery no.")
            {
                e.Item.Text = "PO No.";
                e.Item.Checked = false;
            }
            if (e.Item.Text.ToLower() == "customer name")
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
            empty = baseClass.ReturnRoles_Privileges_ForGrid("deliverynote", "isadd", this.Page.Request.Url.ToString());
            this.btn_saveasnewview.Text = this.objLanguage.GetLanguageConversion("Save_As_New_View");
            this.btn_Save.Text = this.objLangClass.GetLanguageConversion("Save");
            if (empty.Trim().ToLower() != "false")
            {
                this.Divdiv_btnsave.Visible = true;
            }
            else
            {
                this.Divdiv_btnsave.Visible = false;
            }
            string str = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("deliverynote", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
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
            //83
            this.lblerror6.Visible = false;
            this.lblerror7.Visible = false;
            this.lblerror8.Visible = false;
            this.lblerror9.Visible = false;
            this.lblerror10.Visible = false;
            //83
            this.btn_saveasnewview.Visible = false;
            this.companyId = int.Parse(base.Session["companyId"].ToString());
            this.userId = int.Parse(base.Session["UserID"].ToString());
            if (base.Request.Params["id"] != null)
            {
                this.dupViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
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
                this.objCreateView.BindCustomColumns(this.pg, this.lstClumns);
                for (int i = 0; i < this.lstClumns.Items.Count; i++)
                {
                    if (this.lstClumns.Items[i].Value.ToLower() == "deliverynumber")
                    {
                        this.lstClumns.Items[i].Text = "Delivery No.";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "ConsignmentNumber")
                    {
                        this.lstClumns.Items[i].Text = "Consignment Note Number";
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
                DropDownList[] dropDownListArray = new DropDownList[10];
                DropDownList[] dropDownListArray1 = new DropDownList[10];
                dropDownListArray[0] = this.ddlsearchfield1;
                dropDownListArray[1] = this.ddlsearchfield2;
                dropDownListArray[2] = this.ddlsearchfield3;
                dropDownListArray[3] = this.ddlsearchfield4;
                dropDownListArray[4] = this.ddlsearchfield5;
                dropDownListArray1[0] = this.ddlsearchcondition1;
                dropDownListArray1[1] = this.ddlsearchcondition2;
                dropDownListArray1[2] = this.ddlsearchcondition3;
                dropDownListArray1[3] = this.ddlsearchcondition4;
                dropDownListArray1[4] = this.ddlsearchcondition5;
                dropDownListArray[5] = this.ddlsearchfield6;
                dropDownListArray[6] = this.ddlsearchfield7;
                dropDownListArray[7] = this.ddlsearchfield8;
                dropDownListArray[8] = this.ddlsearchfield9;
                dropDownListArray[9] = this.ddlsearchfield10;
                dropDownListArray1[5] = this.ddlsearchcondition6;
                dropDownListArray1[6] = this.ddlsearchcondition7;
                dropDownListArray1[7] = this.ddlsearchcondition8;
                dropDownListArray1[8] = this.ddlsearchcondition9;
                dropDownListArray1[9] = this.ddlsearchcondition10;
                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby2, this.ddl_direction2);
                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby3, this.ddl_direction3);
                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby4, this.ddl_direction4);
                this.objCreateView.initialize_DropDown_ForCustomView(this.companyId, this.pg, dropDownListArray, dropDownListArray1);
                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby, this.ddl_direction);
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() == "edit" && base.Request.Params["id"] != null)
                {
                    this.btn_delete.Visible = true;
                    this.btn_saveasnewview.Visible = true;
                    this.btn_Save.Text = this.objLanguage.GetLanguageConversion("Save_and_Update");
                    if (this.objbase.ReturnRoles_Privileges_ForGrid("deliverynote", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.btn_delete.Visible = false;
                    }
                    this.ViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    this.iszero = this.objCreateView.Check_Iszeroth_View(this.companyId, this.ViewID, "deliverynote");
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
                        DataTable dataTable = EstimateBasePage.Estimates_ViewName_Select_By_ID(Convert.ToInt32(this.companyId), this.ViewID, "deliverynote");
                        foreach (DataRow dataRow in dataTable.Rows)
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
                            this.ddl_sortby.SelectedValue = dataRow["SortedBy"].ToString();
                            this.ddl_direction.SelectedValue = dataRow["SortDirection"].ToString();
                            this.ddlShowRecords.SelectedValue = dataRow["RecordsToDisplay"].ToString();
                            this.ddlsearchfield6.SelectedValue = dataRow["condition6"].ToString();
                            this.ddlsearchfield7.SelectedValue = dataRow["condition7"].ToString();
                            this.ddlsearchfield8.SelectedValue = dataRow["condition8"].ToString();
                            this.ddlsearchfield9.SelectedValue = dataRow["condition9"].ToString();
                            this.ddlsearchfield10.SelectedValue = dataRow["condition10"].ToString();
                            this.ddlsearchcondition6.SelectedValue = dataRow["operator6"].ToString();
                            this.ddlsearchcondition7.SelectedValue = dataRow["operator7"].ToString();
                            this.ddlsearchcondition8.SelectedValue = dataRow["operator8"].ToString();
                            this.ddlsearchcondition9.SelectedValue = dataRow["operator9"].ToString();
                            this.ddlsearchcondition10.SelectedValue = dataRow["operator10"].ToString();
                            this.txtsearchcriteria6.Text = dataRow["value6"].ToString();
                            this.txtsearchcriteria7.Text = dataRow["value7"].ToString();
                            this.txtsearchcriteria8.Text = dataRow["value8"].ToString();
                            this.txtsearchcriteria9.Text = dataRow["value9"].ToString();
                            this.txtsearchcriteria10.Text = dataRow["value10"].ToString();
                            this.DrpdwnSearchCritria5.SelectedValue = dataRow["CondnalOpertr5"].ToString();
                            this.DrpdwnSearchCritria6.SelectedValue = dataRow["CondnalOpertr6"].ToString();
                            this.DrpdwnSearchCritria7.SelectedValue = dataRow["CondnalOpertr7"].ToString();
                            this.DrpdwnSearchCritria8.SelectedValue = dataRow["CondnalOpertr8"].ToString();
                            this.DrpdwnSearchCritria9.SelectedValue = dataRow["CondnalOpertr9"].ToString();
                            this.ddl_sortby2.SelectedValue = dataRow["SortedBy2"].ToString();
                            this.ddl_direction2.SelectedValue = dataRow["SortDirection2"].ToString();
                            this.ddl_sortby3.SelectedValue = dataRow["SortedBy3"].ToString();
                            this.ddl_direction3.SelectedValue = dataRow["SortDirection3"].ToString();
                            this.ddl_sortby4.SelectedValue = dataRow["SortedBy4"].ToString();
                            this.ddl_direction4.SelectedValue = dataRow["SortDirection4"].ToString();

                            //83
                            //if (dataRow["isGrouping"].ToString().ToLower().Trim() == "true")
                            //{
                            //    this.chkGrouping.Checked = true;
                            //}
                            //this.ddlGroupBy.SelectedValue = dataRow["GroupByColumn"].ToString();
                            this.ddlDateType.SelectedValue = String.IsNullOrEmpty(dataRow["FilterDateType"].ToString()) ? "None" : (dataRow["FilterDateType"].ToString());
                            this.ddlDateRange.SelectedValue = String.IsNullOrEmpty(dataRow["FilterDateRange"].ToString()) ? "All" : (dataRow["FilterDateRange"].ToString());

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
                        string str2 = this.comm.UserSetting_Selete(this.companyId, this.userId, "delivery_note_view");
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
                    this.objbase.Message_Display(this.objLangClass.GetLanguageConversion("Delivery_View_Delete_Note"), "successfulMsg", this.plhMessage);
                }
            }
            this.chk_Searchby.Text = this.objLangClass.GetLanguageConversion("Search_By_The_Following_Criteria");
            this.btn_Cancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btn_delete.Text = this.objLangClass.GetLanguageConversion("Delete");
            this.lblAvailableCols.Text = this.objLangClass.GetLanguageConversion("Available_Columns");
            this.lblSelectedcols.Text = this.objLangClass.GetLanguageConversion("Selected_Columns");
            this.DrpdwnSearchCritria1.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria1.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria2.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria2.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria3.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria3.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria4.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria4.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria5.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria5.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria6.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria6.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria7.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria7.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria8.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria8.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");
            this.DrpdwnSearchCritria9.Items[0].Text = this.objLanguage.GetLanguageConversion("And");
            this.DrpdwnSearchCritria9.Items[1].Text = this.objLanguage.GetLanguageConversion("Or");

            if (this.objbase.ReturnRoles_Privileges_ForGrid("deliverynote", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                this.btn_Save.Visible = false;
            }
        }

        private static void ReMoveRecords(RadListBox lstSelected, RadListBox lstAll)
        {
            foreach (RadListBoxItem checkedItem in lstSelected.CheckedItems)
            {
                if (!(checkedItem.Text.ToLower() != "delivey no") || !(checkedItem.Text.ToLower() != "customer name"))
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
                if (this.lstClumns.Items[i].Text.ToLower() == "delivery no.")
                {
                    this.lstSelectedCols.Items.Insert(0, this.lstClumns.Items[i]);
                    this.lstSelectedCols.Items.Add(this.lstClumns.Items[i]);
                    this.lstSelectedCols.Items[i].Text = "Delivery No.";
                    this.lstSelectedCols.Items[i].Checked = false;
                    this.lstSelectedCols.Items[i].AllowDrag = true;
                    this.lstSelectedCols.Items[i].ImageUrl = string.Concat(this.strImagePath, "drag_drop.gif");
                    this.lstClumns.Items[i].Remove();
                }
                if (this.lstClumns.Items[i].Text.ToLower() == "customer name")
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