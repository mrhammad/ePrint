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

namespace ePrint.usercontrol.View
{
    public partial class CustomView : System.Web.UI.UserControl
    {

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public languageClass objLanguage = new languageClass();

        public BasePage objpage = new BasePage();

        public commonClass comm = new commonClass();

        private createViewClass objCreateView = new createViewClass();

        public int companyId;

        public int UserID;

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
        public string condition6 = string.Empty;

        public string condition7 = string.Empty;

        public string condition8 = string.Empty;
        public string condition9 = string.Empty;

        public string condition10 = string.Empty;


        public string operator1 = string.Empty;

        public string operator2 = string.Empty;

        public string operator3 = string.Empty;

        public string operator4 = string.Empty;

        public string operator5 = string.Empty;
        public string operator6 = string.Empty;

        public string operator7 = string.Empty;

        public string operator8 = string.Empty;
        public string operator9 = string.Empty;

        public string operator10 = string.Empty;

        public string value1 = string.Empty;

        public string value2 = string.Empty;

        public string value3 = string.Empty;

        public string value4 = string.Empty;

        public string value5 = string.Empty;

        public string value6 = string.Empty;

        public string value7 = string.Empty;

        public string value8 = string.Empty;
        public string value9 = string.Empty;

        public string value10 = string.Empty;

        public string ConditionalOperator1 = string.Empty;

        public string ConditionalOperator2 = string.Empty;

        public string ConditionalOperator3 = string.Empty;

        public string ConditionalOperator4 = string.Empty;
        public string ConditionalOperator5 = string.Empty;
        public string ConditionalOperator6 = string.Empty;
        public string ConditionalOperator7 = string.Empty;
        public string ConditionalOperator8 = string.Empty;
        public string ConditionalOperator9 = string.Empty;

        public string ddl_sortby1 = string.Empty;

        public string ddl_direction1 = string.Empty;
        public string ddl_sortby_2 = string.Empty;

        public string ddl_direction_2 = string.Empty;
        public string ddl_sortby_3 = string.Empty;

        public string ddl_direction_3 = string.Empty;
        public string ddl_sortby_4 = string.Empty;

        public string ddl_direction_4 = string.Empty;

        public int isdeleted;

        public int CreatedBy;

        public int UpdatedBy;

        public string CreatedOn = string.Empty;

        public string UpdatedOn = string.Empty;

        public string chk_concat = string.Empty;

        public int isshowallrecords;

        public int iszerothval;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public int defaultviewid;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagePath = global.imagePath();

        private commonClass objJava = new commonClass();

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

        public CustomView()
        {
        }

        protected void btncancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_view.aspx"));
        }

        protected void btndelete_OnClick(object sender, EventArgs e)
        {
            this.delViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
            CompanyBasePage.View_Delete(this.companyId, "estimate", this.delViewID, this.UserID, "estimates_view");
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str = string.Concat(this.pg, this.UserID, this.pg);
                base.Session["search_Est"] = null;
                base.Session[str] = null;
                base.Session["EstViewID"] = null;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "estimates/customview.aspx?type=del"));
        }

        protected void btnMove_OnClick(object sender, EventArgs e)
        {
            CustomView.MoveRecords(this.lstClumns, this.lstSelectedCols);
        }

        protected void btnReMove_OnClick(object sender, EventArgs e)
        {
            CustomView.ReMoveRecords(this.lstSelectedCols, this.lstClumns);
        }

        protected void btnsave_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str = string.Concat(this.pg, this.UserID, this.pg);
                base.Session["search_Est"] = null;
                base.Session[str] = null;
                base.Session["EstViewID"] = null;
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
                CustomView usercontrolViewsCustomView = this;
                usercontrolViewsCustomView.chk_concat = string.Concat(usercontrolViewsCustomView.chk_concat, this.lstSelectedCols.Items[i].Value, ",");
            }
            this.chk_concat = string.Concat(this.chk_concat, "EstItemCoun,IsArchive,IsConvertedToJob,ISDeletedJob,");
            string str1 = "Estimate";
            string str2 = "";
            if (base.Request.Params["type"] == null || base.Request.Params["id"] == null)
            {
                this.ViewID = (long)0;
                this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Value, this.ddlDateType.SelectedItem.Value, this.ddlDateRange.SelectedItem.Value, this.condition6, this.condition7, this.condition8, this.condition9, this.condition10, this.operator6, this.operator7, this.operator8, this.operator9, this.operator10, this.value6, this.value7, this.value8, this.value9, this.value10, this.ConditionalOperator5, this.ConditionalOperator6, this.ConditionalOperator7, this.ConditionalOperator8, this.ConditionalOperator9, this.ddl_sortby_2, this.ddl_direction_2, this.ddl_sortby_3, this.ddl_direction_3, this.ddl_sortby_4, this.ddl_direction_4);

                //this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Value, this.chkGrouping.Checked, this.ddlGroupBy.SelectedItem.Value,this.ddlDateType.SelectedItem.Value,this.ddlDateRange.SelectedItem.Value);
                if (this.isdefault == 1)
                {
                    this.comm.UserSetting_Update(this.companyId, this.UserID, "estimates_view", this.ret.ToString());
                }
            }
            else
            {
                if (base.Request.Params["type"].ToString() == "edit")
                {
                    this.ViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, this.iszerothval, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Value, this.ddlDateType.SelectedItem.Value, this.ddlDateRange.SelectedItem.Value, this.condition6, this.condition7, this.condition8, this.condition9, this.condition10, this.operator6, this.operator7, this.operator8, this.operator9, this.operator10, this.value6, this.value7, this.value8, this.value9, this.value10, this.ConditionalOperator5, this.ConditionalOperator6, this.ConditionalOperator7, this.ConditionalOperator8, this.ConditionalOperator9, this.ddl_sortby_2, this.ddl_direction_2, this.ddl_sortby_3, this.ddl_direction_3, this.ddl_sortby_4, this.ddl_direction_4);

                    //this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, this.iszerothval, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Value, this.chkGrouping.Checked, this.ddlGroupBy.SelectedItem.Value, this.ddlDateType.SelectedItem.Value, this.ddlDateRange.SelectedItem.Value);
                    this.objbase.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Customized_View_Saved_Successfully"), "successfulMsg", this.plhMessage);
                }
                if (this.isdefault == 1)
                {
                    this.comm.UserSetting_Update(this.companyId, this.UserID, "estimates_view", this.ViewID.ToString());
                }
                else if (this.comm.UserSetting_Selete(this.companyId, this.UserID, "estimates_view") == this.ViewID.ToString())
                {
                    this.comm.UserSetting_Update(this.companyId, this.UserID, "estimates_view", "0");
                }
            }
            this.objCreateView.View_Set_Default_All_zero_exist("Estimate", this.companyId);
            if (this.ret <= 0)
            {
                this.objbase.Message_Display(this.objLanguage.GetLanguageConversion("View_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            this.objbase.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Customized_View_Saved_Successfully"), "successfulMsg", this.plhMessage);
            base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_view.aspx?viewid=", this.ret));
        }

        protected void btnsaveasnew_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "edit" || base.Request.Params["type"] == null && this.chk_setdefault.Checked)
            {
                string str = string.Concat(this.pg, this.UserID, this.pg);
                base.Session["search_Est"] = null;
                base.Session[str] = null;
                base.Session["EstViewID"] = null;
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
                CustomView usercontrolViewsCustomView = this;
                usercontrolViewsCustomView.chk_concat = string.Concat(usercontrolViewsCustomView.chk_concat, this.lstSelectedCols.Items[i].Value, ",");
            }
            this.chk_concat = string.Concat(this.chk_concat, "EstItemCoun,IsArchive,IsConvertedToJob,ISDeletedJob,");
            string str1 = "Estimate";
            string str2 = "";
            this.ViewID = (long)0;
            //this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.condition6, this.condition7, this.condition8, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.operator6, this.operator7, this.operator8, this.value1, this.value2, this.value3, this.value4, this.value5, this.value6, this.value7, this.value8, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, this.ConditionalOperator5, this.ConditionalOperator6, this.ConditionalOperator7, str2, this.ddlShowRecords.SelectedItem.Value, this.chkGrouping.Checked, this.ddlGroupBy.SelectedItem.Value, this.ddlDateType.SelectedItem.Value, this.ddlDateRange.SelectedItem.Value, this.ddl_sortby_2, this.ddl_direction_2, this.ddl_sortby_3, this.ddl_direction_3);
            //this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Value, this.chkGrouping.Checked, this.ddlGroupBy.SelectedItem.Value, this.ddlDateType.SelectedItem.Value, this.ddlDateRange.SelectedItem.Value);
            this.ret = this.objCreateView.CustomColumns_insert(this.companyId, this.ViewID, this.objbase.SpecialEncode(this.txt_ViewName.Text.Trim()), this.objbase.SpecialEncode(this.chk_concat.ToString()), this.condition1, this.condition2, this.condition3, this.condition4, this.condition5, this.operator1, this.operator2, this.operator3, this.operator4, this.operator5, this.value1, this.value2, this.value3, this.value4, this.value5, this.isdeleted, this.CreatedBy, this.UpdatedBy, this.objbase.SpecialEncode(this.CreatedOn.ToString()), this.objbase.SpecialEncode(this.UpdatedOn.ToString()), this.isdefault, this.ddl_sortby1, this.ddl_direction1, str1, this.isshowall, 0, this.ConditionalOperator1, this.ConditionalOperator2, this.ConditionalOperator3, this.ConditionalOperator4, str2, this.ddlShowRecords.SelectedItem.Value, this.ddlDateType.SelectedItem.Value, this.ddlDateRange.SelectedItem.Value, this.condition6, this.condition7, this.condition8, this.condition9, this.condition10, this.operator6, this.operator7, this.operator8, this.operator9, this.operator10, this.value6, this.value7, this.value8, this.value9, this.value10, this.ConditionalOperator5, this.ConditionalOperator6, this.ConditionalOperator7, this.ConditionalOperator8, this.ConditionalOperator9, this.ddl_sortby_2, this.ddl_direction_2, this.ddl_sortby_3, this.ddl_direction_3, this.ddl_sortby_4, this.ddl_direction_4);
            if (this.isdefault == 1 && this.ret > 0)
            {
                this.comm.UserSetting_Update(this.companyId, this.UserID, "estimates_view", this.ret.ToString());
            }
            this.objCreateView.View_Set_Default_All_zero_exist("Estimate", this.companyId);
            if (this.ret <= 0)
            {
                this.objbase.Message_Display(this.objLanguage.GetLanguageConversion("View_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            this.objbase.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Customized_View_Saved_Successfully"), "successfulMsg", this.plhMessage);
            base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_view.aspx?viewid=", this.ret));
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
                if (this.lstSelectedCols.Items[j].Value.ToLower() == "accountcodeid")
                {
                    this.lstSelectedCols.Items[j].Remove();
                }
            }
        }

        protected void lstClumns_OnItemDataBound(object sender, RadListBoxItemEventArgs e)
        {
            e.Item.ImageUrl = "";
            e.Item.Checked = false;
            if (e.Item.Text.ToLower() == "estimate number")
            {
                e.Item.Text = "Estimate No.";
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
            this.UserID = BaseClass.CheckIntegerNull(base.Session["UserID"].ToString());
            if (base.Request.Params["id"] != null)
            {
                this.dupViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
            }
            if (!base.IsPostBack)
            {
                this.lblAvailableColumns.Text = this.objLanguage.GetLanguageConversion("Available_columns");
                this.lblSelectedColumns.Text = this.objLanguage.GetLanguageConversion("Selected_Columns");
                this.chk_Searchby.Text = this.objLanguage.GetLanguageConversion("Search_By_The_Following_Criteria");
                this.chk_setdefault.Text = this.objLanguage.GetLanguageConversion("Set_This_View_As_My_Default");
                this.btn_Save.Text = this.objLanguage.GetLanguageConversion("Save");
                this.btn_saveasnewview.Text = this.objLanguage.GetLanguageConversion("Save_As_New_View");
                if (this.objbase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                {
                    this.btn_Save.Visible = false;
                }
                this.btn_delete.Text = this.objLanguage.GetLanguageConversion("Delete");
                this.btn_Cancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
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
                if (base.Request.Params["type"] != null)
                {
                    this.ReqType = base.Request.Params["type"].ToString().ToLower();
                }
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
                            this.hdnaddress1.Value = this.objLanguage.GetLanguageConversion("Address1");
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
                            this.hdnaddress2.Value = this.objLanguage.GetLanguageConversion("Address2");
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
                            this.hdnaddress3.Value = this.objLanguage.GetLanguageConversion("Address3");
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
                            this.hdnaddress4.Value = this.objLanguage.GetLanguageConversion("Address4");
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
                        this.hdnaddress5.Value = this.objLanguage.GetLanguageConversion("Address5");
                    }
                    else
                    {
                        this.hdnaddress5.Value = row["addressvalue"].ToString();
                    }
                }
                this.objCreateView.BindCustomColumns(this.pg, this.lstClumns);
                for (int i = 0; i < this.lstClumns.Items.Count; i++)
                {
                    if (this.lstClumns.Items[i].Value.ToLower() == "estimatenumber")
                    {
                        this.lstClumns.Items[i].Text = "Estimate No.";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "ordernumber")
                    {
                        this.lstClumns.Items[i].Text = "Order No.";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "userid")
                    {
                        this.lstClumns.Items[i].Text = "Estimator";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "company")
                    {
                        this.lstClumns.Items[i].Text = "Department";
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "accountcodeid")
                    {
                        this.lstClumns.Items[i].Style.Add("Display", "none");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "estimatevalue_excgst")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Est. Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "estimatevalue")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Est. Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemvalueexctax1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 1 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemvalueexctax2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 2 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemvalueexctax3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 3 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemvalueexctax4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 4 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemvalueintax1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 1 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemvalueintax2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 2 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemvalueintax3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 3 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemvalueintax4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 4 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemtaxvalue1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 1 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemtaxvalue2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 2 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemtaxvalue3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 3 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemtaxvalue4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 4 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemcostpriceexcmarkup1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 1 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemcostpriceexcmarkup2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 2 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemcostpriceexcmarkup3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 3 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemcostpriceexcmarkup4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 4 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemmarkupvalue1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Markup Value 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemmarkupvalue2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Markup Value 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemmarkupvalue3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Markup Value 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemmarkupvalue4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Markup Value 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemcostpriceincmarkup1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Cost Price Inc. Markup 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemcostpriceincmarkup2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Cost Price Inc. Markup 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemcostpriceincmarkup3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Cost Price Inc. Markup 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemcostpriceincmarkup4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Cost Price Inc. Markup 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemprofitmarginpercentage1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Profit Margin Percentage 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemprofitmarginpercentage2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Profit Margin Percentage 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemprofitmarginpercentage3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Profit Margin Percentage 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemprofitmarginpercentage4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Profit Margin Percentage 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemprofitmarginvalue1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Profit Margin Value 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemprofitmarginvalue2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Profit Margin Value 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemprofitmarginvalue3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Profit Margin Value 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemprofitmarginvalue4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Profit Margin Value 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemgrossprofitpercentage1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Gross Profit Percentage 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemgrossprofitpercentage2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Gross Profit Percentage 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemgrossprofitpercentage3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Gross Profit Percentage 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemgrossprofitpercentage4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Gross Profit Percentage 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemgrossprofitvalue1")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 1 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemgrossprofitvalue2")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 2 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemgrossprofitvalue3")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 3 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemgrossprofitvalue4")
                    {
                        this.lstClumns.Items[i].Text = string.Concat("Qty 4 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "costcentre" && !BaseClass.CheckBooleanNull(SettingsBasePage.settings_regionalsettings_select(this.companyId).Rows[0]["IsDisplayCostCentre"]))
                    {
                        this.lstClumns.Items[i].Style.Add("Display", "none");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "statusid")
                    {
                        this.lstClumns.Items[i].Text = this.objLanguage.GetLanguageConversion("Item_Status");
                    }
                    if (this.lstClumns.Items[i].Value.ToLower() == "itemtitle")
                    {
                        this.lstClumns.Items[i].Text = this.objLanguage.GetLanguageConversion("Item_Title");
                    }
                    if (this.pg.ToLower() == "estimate" && this.lstClumns.Items[i].Text.ToLower() == "address1")
                    {
                        this.lstClumns.Items[i].Text = this.hdnaddress1.Value;
                    }
                    else if (this.pg.ToLower() == "estimate" && this.lstClumns.Items[i].Text.ToLower() == "address2")
                    {
                        this.lstClumns.Items[i].Text = this.hdnaddress2.Value;
                    }
                    else if (this.pg.ToLower() == "estimate" && this.lstClumns.Items[i].Text.ToLower() == "address3")
                    {
                        this.lstClumns.Items[i].Text = this.hdnaddress3.Value;
                    }
                    else if (this.pg.ToLower() == "estimate" && this.lstClumns.Items[i].Text.ToLower() == "address4")
                    {
                        this.lstClumns.Items[i].Text = this.hdnaddress4.Value;
                    }
                    else if (this.pg.ToLower() == "estimate" && this.lstClumns.Items[i].Text.ToLower() == "address5")
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
                DropDownList[] dropDownListArray = new DropDownList[10];
                DropDownList[] dropDownListArray1 = new DropDownList[10];
                dropDownListArray[0] = this.ddlsearchfield1;
                dropDownListArray[1] = this.ddlsearchfield2;
                dropDownListArray[2] = this.ddlsearchfield3;
                dropDownListArray[3] = this.ddlsearchfield4;
                dropDownListArray[4] = this.ddlsearchfield5;

                dropDownListArray[5] = this.ddlsearchfield6;
                dropDownListArray[6] = this.ddlsearchfield7;
                dropDownListArray[7] = this.ddlsearchfield8;
                dropDownListArray[8] = this.ddlsearchfield9;
                dropDownListArray[9] = this.ddlsearchfield10;

                dropDownListArray1[0] = this.ddlsearchcondition1;
                dropDownListArray1[1] = this.ddlsearchcondition2;
                dropDownListArray1[2] = this.ddlsearchcondition3;
                dropDownListArray1[3] = this.ddlsearchcondition4;
                dropDownListArray1[4] = this.ddlsearchcondition5;

                dropDownListArray1[5] = this.ddlsearchcondition6;
                dropDownListArray1[6] = this.ddlsearchcondition7;
                dropDownListArray1[7] = this.ddlsearchcondition8;
                dropDownListArray1[8] = this.ddlsearchcondition9;
                dropDownListArray1[9] = this.ddlsearchcondition10;

                this.objCreateView.initialize_DropDown_ForCustomView(this.companyId, this.pg, dropDownListArray, dropDownListArray1);
                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby, this.ddl_direction);

                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby2, this.ddl_direction2);
                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby3, this.ddl_direction3);
                this.objCreateView.BindCustomColumns_sortby(this.pg, this.ddl_sortby4, this.ddl_direction4);

                for (int j = 0; j <= 4; j++)
                {
                    for (int k = 0; k < dropDownListArray[j].Items.Count; k++)
                    {
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "est. value ($)")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Est. Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 1 value ex. tax")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 1 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 2 value ex. tax")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 2 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 3 value ex. tax")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 3 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 4 value ex. tax")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 4 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 1 tax inc. total")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 1 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 2 tax inc. total")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 2 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 3 tax inc. total")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 3 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 4 tax inc. total")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 4 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 1 tax")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 1 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 2 tax")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 2 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 3 tax")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 3 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 4 tax")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 4 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 1 cost price ex. markup")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 1 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 2 cost price ex. markup")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 2 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 3 cost price ex. markup")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 3 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 4 cost price ex. markup")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 4 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 1 cost price inc. markup")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 1 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 2 cost price inc. markup")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 2 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 3 cost price inc. markup")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 3 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 4 cost price inc. markup")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 4 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "markup value 1")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Markup Value 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "markup value 2")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Markup Value 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "markup value 3")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Markup Value 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "markup value 4")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Markup Value 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "profit margin percentage 1")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Profit Margin Percentage 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "profit margin percentage 2")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Profit Margin Percentage 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "profit margin percentage 3")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Profit Margin Percentage 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "profit margin percentage 4")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Profit Margin Percentage 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "profit margin value 1")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Profit Margin Value 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "profit margin value 2")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Profit Margin Value 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "profit margin value 3")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Profit Margin Value 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "profit margin value 4")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Profit Margin Value 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "gross profit percentage 1")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Gross Profit Percentage 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "gross profit percentage 2")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Gross Profit Percentage 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "gross profit percentage 3")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Gross Profit Percentage 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "gross profit percentage 4")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Gross Profit Percentage 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 1 gross profit")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 1 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 2 gross profit")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 2 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 3 gross profit")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 3 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "qty 4 gross profit")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Qty 4 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "cost price inc. markup 1")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Cost Price Inc. Markup 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "cost price inc. markup 2")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Cost Price Inc. Markup 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "cost price inc. markup 3")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Cost Price Inc. Markup 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "cost price inc. markup 4")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Cost Price Inc. Markup 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dropDownListArray[j].Items[k].ToString().ToLower() == "est.value ex.tax ($)")
                        {
                            dropDownListArray[j].Items[k].Text = string.Concat("Est. Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        }
                    }
                }
                for (int l = 0; l < this.ddl_sortby.Items.Count; l++)
                {
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "est. value ($)")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Est. Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 1 value ex. tax")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 1 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 2 value ex. tax")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 2 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 3 value ex. tax")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 3 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 4 value ex. tax")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 4 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 1 tax inc. total")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 1 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 2 tax inc. total")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 2 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 3 tax inc. total")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 3 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 4 tax inc. total")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 4 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 1 tax")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 1 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 2 tax")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 2 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 3 tax")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 3 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 4 tax")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 4 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 1 cost price ex. markup")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 1 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 2 cost price ex. markup")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 2 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 3 cost price ex. markup")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 3 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 4 cost price ex. markup")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 4 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "profit margin percentage 1")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Profit Margin Percentage 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "profit margin percentage 2")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Profit Margin Percentage 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "profit margin percentage 3")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Profit Margin Percentage 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "profit margin percentage 4")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Profit Margin Percentage 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 1 cost price inc. markup")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 1 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 2 cost price inc. markup")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 2 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 3 cost price inc. markup")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 3 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 4 cost price inc. markup")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 4 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "markup value 1")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Markup Value 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "markup value 2")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Markup Value 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "markup value 3")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Markup Value 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "markup value 4")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Markup Value 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 1")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Cost Price Inc. Markup 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 2")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Cost Price Inc. Markup 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 3")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Cost Price Inc. Markup 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 4")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Cost Price Inc. Markup 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "profit margin value 1")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Profit Margin Value 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "profit margin value 2")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Profit Margin Value 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "profit margin value 3")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Profit Margin Value 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "profit margin value 4")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Profit Margin Value 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "gross profit percentage 1")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Gross Profit Percentage 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "gross profit percentage 2")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Gross Profit Percentage 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "gross profit percentage 3")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Gross Profit Percentage 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "gross profit percentage 4")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Gross Profit Percentage 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 1 gross profit")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 1 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 2 gross profit")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 2 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 3 gross profit")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 3 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "qty 4 gross profit")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Qty 4 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby.Items[l].ToString().ToLower().Trim() == "est.value ex.tax ($)")
                    {
                        this.ddl_sortby.Items[l].Text = string.Concat("Est. Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                }

                for (int l = 0; l < this.ddl_sortby2.Items.Count; l++)
                {
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "est. value ($)")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Est. Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 1 value ex. tax")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 1 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 2 value ex. tax")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 2 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 3 value ex. tax")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 3 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 4 value ex. tax")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 4 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 1 tax inc. total")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 1 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 2 tax inc. total")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 2 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 3 tax inc. total")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 3 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 4 tax inc. total")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 4 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 1 tax")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 1 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 2 tax")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 2 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 3 tax")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 3 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 4 tax")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 4 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 1 cost price ex. markup")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 1 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 2 cost price ex. markup")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 2 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 3 cost price ex. markup")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 3 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 4 cost price ex. markup")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 4 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "profit margin percentage 1")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Profit Margin Percentage 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "profit margin percentage 2")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Profit Margin Percentage 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "profit margin percentage 3")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Profit Margin Percentage 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "profit margin percentage 4")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Profit Margin Percentage 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 1 cost price inc. markup")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 1 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 2 cost price inc. markup")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 2 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 3 cost price inc. markup")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 3 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 4 cost price inc. markup")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 4 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "markup value 1")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Markup Value 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "markup value 2")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Markup Value 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "markup value 3")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Markup Value 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "markup value 4")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Markup Value 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 1")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Cost Price Inc. Markup 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 2")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Cost Price Inc. Markup 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 3")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Cost Price Inc. Markup 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 4")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Cost Price Inc. Markup 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "profit margin value 1")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Profit Margin Value 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "profit margin value 2")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Profit Margin Value 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "profit margin value 3")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Profit Margin Value 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "profit margin value 4")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Profit Margin Value 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "gross profit percentage 1")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Gross Profit Percentage 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "gross profit percentage 2")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Gross Profit Percentage 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "gross profit percentage 3")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Gross Profit Percentage 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "gross profit percentage 4")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Gross Profit Percentage 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 1 gross profit")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 1 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 2 gross profit")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 2 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 3 gross profit")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 3 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "qty 4 gross profit")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Qty 4 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby2.Items[l].ToString().ToLower().Trim() == "est.value ex.tax ($)")
                    {
                        this.ddl_sortby2.Items[l].Text = string.Concat("Est. Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                }

                for (int l = 0; l < this.ddl_sortby3.Items.Count; l++)
                {
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "est. value ($)")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Est. Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 1 value ex. tax")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 1 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 2 value ex. tax")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 2 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 3 value ex. tax")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 3 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 4 value ex. tax")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 4 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 1 tax inc. total")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 1 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 2 tax inc. total")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 2 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 3 tax inc. total")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 3 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 4 tax inc. total")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 4 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 1 tax")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 1 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 2 tax")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 2 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 3 tax")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 3 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 4 tax")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 4 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 1 cost price ex. markup")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 1 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 2 cost price ex. markup")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 2 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 3 cost price ex. markup")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 3 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 4 cost price ex. markup")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 4 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "profit margin percentage 1")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Profit Margin Percentage 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "profit margin percentage 2")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Profit Margin Percentage 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "profit margin percentage 3")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Profit Margin Percentage 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "profit margin percentage 4")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Profit Margin Percentage 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 1 cost price inc. markup")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 1 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 2 cost price inc. markup")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 2 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 3 cost price inc. markup")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 3 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 4 cost price inc. markup")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 4 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "markup value 1")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Markup Value 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "markup value 2")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Markup Value 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "markup value 3")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Markup Value 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "markup value 4")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Markup Value 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 1")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Cost Price Inc. Markup 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 2")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Cost Price Inc. Markup 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 3")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Cost Price Inc. Markup 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 4")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Cost Price Inc. Markup 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "profit margin value 1")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Profit Margin Value 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "profit margin value 2")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Profit Margin Value 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "profit margin value 3")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Profit Margin Value 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "profit margin value 4")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Profit Margin Value 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "gross profit percentage 1")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Gross Profit Percentage 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "gross profit percentage 2")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Gross Profit Percentage 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "gross profit percentage 3")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Gross Profit Percentage 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "gross profit percentage 4")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Gross Profit Percentage 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 1 gross profit")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 1 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 2 gross profit")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 2 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 3 gross profit")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 3 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "qty 4 gross profit")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Qty 4 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby3.Items[l].ToString().ToLower().Trim() == "est.value ex.tax ($)")
                    {
                        this.ddl_sortby3.Items[l].Text = string.Concat("Est. Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                }

                for (int l = 0; l < this.ddl_sortby4.Items.Count; l++)
                {
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "est. value ($)")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Est. Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 1 value ex. tax")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 1 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 2 value ex. tax")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 2 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 3 value ex. tax")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 3 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 4 value ex. tax")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 4 Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 1 tax inc. total")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 1 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 2 tax inc. total")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 2 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 3 tax inc. total")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 3 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 4 tax inc. total")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 4 Tax Inc. Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 1 tax")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 1 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 2 tax")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 2 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 3 tax")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 3 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 4 tax")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 4 Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 1 cost price ex. markup")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 1 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 2 cost price ex. markup")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 2 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 3 cost price ex. markup")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 3 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 4 cost price ex. markup")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 4 Cost Price Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "profit margin percentage 1")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Profit Margin Percentage 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "profit margin percentage 2")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Profit Margin Percentage 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "profit margin percentage 3")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Profit Margin Percentage 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "profit margin percentage 4")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Profit Margin Percentage 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 1 cost price inc. markup")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 1 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 2 cost price inc. markup")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 2 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 3 cost price inc. markup")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 3 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 4 cost price inc. markup")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 4 Cost Price Inc. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "markup value 1")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Markup Value 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "markup value 2")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Markup Value 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "markup value 3")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Markup Value 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "markup value 4")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Markup Value 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 1")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Cost Price Inc. Markup 1 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 2")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Cost Price Inc. Markup 2 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 3")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Cost Price Inc. Markup 3 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "cost price inc. markup 4")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Cost Price Inc. Markup 4 (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "profit margin value 1")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Profit Margin Value 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "profit margin value 2")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Profit Margin Value 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "profit margin value 3")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Profit Margin Value 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "profit margin value 4")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Profit Margin Value 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "gross profit percentage 1")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Gross Profit Percentage 1 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "gross profit percentage 2")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Gross Profit Percentage 2 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "gross profit percentage 3")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Gross Profit Percentage 3 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "gross profit percentage 4")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Gross Profit Percentage 4 (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 1 gross profit")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 1 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 2 gross profit")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 2 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 3 gross profit")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 3 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "qty 4 gross profit")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Qty 4 Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (this.ddl_sortby4.Items[l].ToString().ToLower().Trim() == "est.value ex.tax ($)")
                    {
                        this.ddl_sortby4.Items[l].Text = string.Concat("Est. Value Ex. Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
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
                    if (this.objbase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                    {
                        this.btn_delete.Visible = false;
                    }
                    this.ViewID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    this.iszero = this.objCreateView.Check_Iszeroth_View(this.companyId, this.ViewID, "estimate");
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
                    if (!base.IsPostBack)
                    {
                        DataTable dataTable = EstimateBasePage.Estimates_ViewName_Select_By_ID(BaseClass.CheckIntegerNull(this.companyId), this.ViewID, "estimate");
                        foreach (DataRow row1 in dataTable.Rows)
                        {
                            this.txt_ViewName.Text = this.objbase.SpecialDecode(row1["ViewName"].ToString());
                            this.ddlsearchfield1.SelectedValue = row1["condition1"].ToString();
                            this.ddlsearchfield2.SelectedValue = row1["condition2"].ToString();
                            this.ddlsearchfield3.SelectedValue = row1["condition3"].ToString();
                            this.ddlsearchfield4.SelectedValue = row1["condition4"].ToString();
                            this.ddlsearchfield5.SelectedValue = row1["condition5"].ToString();
                            this.ddlsearchfield6.SelectedValue = row1["condition6"].ToString();
                            this.ddlsearchfield7.SelectedValue = row1["condition7"].ToString();
                            this.ddlsearchfield8.SelectedValue = row1["condition8"].ToString();
                            this.ddlsearchfield9.SelectedValue = row1["condition9"].ToString();
                            this.ddlsearchfield10.SelectedValue = row1["condition10"].ToString();
                            this.ddlsearchcondition1.SelectedValue = row1["operator1"].ToString();
                            this.ddlsearchcondition2.SelectedValue = row1["operator2"].ToString();
                            this.ddlsearchcondition3.SelectedValue = row1["operator3"].ToString();
                            this.ddlsearchcondition4.SelectedValue = row1["operator4"].ToString();
                            this.ddlsearchcondition5.SelectedValue = row1["operator5"].ToString();
                            this.ddlsearchcondition6.SelectedValue = row1["operator6"].ToString();
                            this.ddlsearchcondition7.SelectedValue = row1["operator7"].ToString();
                            this.ddlsearchcondition8.SelectedValue = row1["operator8"].ToString();
                            this.ddlsearchcondition9.SelectedValue = row1["operator9"].ToString();
                            this.ddlsearchcondition10.SelectedValue = row1["operator10"].ToString();
                            this.txtsearchcriteria1.Text = row1["value1"].ToString();
                            this.txtsearchcriteria2.Text = row1["value2"].ToString();
                            this.txtsearchcriteria3.Text = row1["value3"].ToString();
                            this.txtsearchcriteria4.Text = row1["value4"].ToString();
                            this.txtsearchcriteria5.Text = row1["value5"].ToString();
                            this.txtsearchcriteria6.Text = row1["value6"].ToString();
                            this.txtsearchcriteria7.Text = row1["value7"].ToString();
                            this.txtsearchcriteria8.Text = row1["value8"].ToString();
                            this.txtsearchcriteria9.Text = row1["value9"].ToString();
                            this.txtsearchcriteria10.Text = row1["value10"].ToString();
                            this.DrpdwnSearchCritria1.SelectedValue = row1["CondnalOpertr1"].ToString();
                            this.DrpdwnSearchCritria2.SelectedValue = row1["CondnalOpertr2"].ToString();
                            this.DrpdwnSearchCritria3.SelectedValue = row1["CondnalOpertr3"].ToString();
                            this.DrpdwnSearchCritria4.SelectedValue = row1["CondnalOpertr4"].ToString();
                            this.DrpdwnSearchCritria5.SelectedValue = row1["CondnalOpertr5"].ToString();
                            this.DrpdwnSearchCritria6.SelectedValue = row1["CondnalOpertr6"].ToString();
                            this.DrpdwnSearchCritria7.SelectedValue = row1["CondnalOpertr7"].ToString();
                            this.DrpdwnSearchCritria8.SelectedValue = row1["CondnalOpertr8"].ToString();
                            this.DrpdwnSearchCritria9.SelectedValue = row1["CondnalOpertr9"].ToString();
                            this.ddl_sortby.SelectedValue = row1["SortedBy"].ToString();
                            this.ddl_direction.SelectedValue = row1["SortDirection"].ToString();
                            this.ddl_sortby2.SelectedValue = row1["SortedBy2"].ToString();
                            this.ddl_direction2.SelectedValue = row1["SortDirection2"].ToString();
                            this.ddl_sortby3.SelectedValue = row1["SortedBy3"].ToString();
                            this.ddl_direction3.SelectedValue = row1["SortDirection3"].ToString();
                            this.ddl_sortby4.SelectedValue = row1["SortedBy4"].ToString();
                            this.ddl_direction4.SelectedValue = row1["SortDirection4"].ToString();

                            this.ddlShowRecords.SelectedValue = row1["RecordsToDisplay"].ToString();
                         
                            //83
                            //if (row1["isGrouping"].ToString().ToLower().Trim() == "true")
                            //{
                            //    this.chkGrouping.Checked = true;
                            //}
                            //this.ddlGroupBy.SelectedValue = row1["GroupByColumn"].ToString();
                            this.ddlDateType.SelectedValue = String.IsNullOrEmpty(row1["FilterDateType"].ToString())?"None": (row1["FilterDateType"].ToString());
                            this.ddlDateRange.SelectedValue = String.IsNullOrEmpty(row1["FilterDateRange"].ToString()) ? "All" : (row1["FilterDateRange"].ToString());


                            string str = row1["ColumnNames"].ToString();
                            char[] chrArray = new char[] { ',' };
                            this.FetchedData(str.Split(chrArray));
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
                        string str1 = this.comm.UserSetting_Selete(this.companyId, this.UserID, "estimates_view");
                        if (str1 != "" && str1 != null)
                        {
                            this.defaultviewid = BaseClass.CheckIntegerNull(str1);
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
                    this.objbase.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Customized_View_Deleted_Successfully"), "successfulMsg", this.plhMessage);
                }
            }
        }

        private static void ReMoveRecords(RadListBox lstSelected, RadListBox lstAll)
        {
            foreach (RadListBoxItem checkedItem in lstSelected.CheckedItems)
            {
                if (!(checkedItem.Text.ToLower() != "estimate no.") || !(checkedItem.Text.ToLower() != "customer name"))
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
                lstAll.Items[i].ImageUrl = "";
            }
        }

        private void TransferDefaultColumns()
        {
            for (int i = 0; i < this.lstClumns.Items.Count - 1; i++)
            {
                if (this.lstClumns.Items[i].Text.ToLower() == "estimate no.")
                {
                    this.lstSelectedCols.Items.Insert(0, this.lstClumns.Items[i]);
                    this.lstSelectedCols.Items.Add(this.lstClumns.Items[i]);
                    this.lstSelectedCols.Items[i].Text = "Estimate No.";
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
                this.lstSelectedCols.Items[j].Enabled = true;
            }
        }
    }
}