using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.DataAccessLayer.Settings;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class roles_add : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private string[] HeaderArray;

        private string[] HeaderArray_Name;

        private string[] ReportArray;

        private string HeaderText = "";

        private string HeaderText_Name = "";

        private string ReportText = "";

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        public int CompanyID;

        public int UserID;

        public commonClass cmnClass = new commonClass();

        private BaseClass objbase = new BaseClass();

        public string IsWebStore = string.Empty;

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

        public roles_add()
        {
        }

        public void BindCustomRolesandPrivileges()
        {
            this.btn_CancelRole.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btn_SaveRole.Text = this.objlang.GetLanguageConversion("Save");
            this.RFVCode.ErrorMessage = this.objlang.GetLanguageConversion("Please_enter_Role_Name");
            this.btn_CancelRole.Attributes.Add("onclick", "javascript:return cancelClick(path+'Settings/user_manager.aspx');");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/user_manager.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Roles_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Roles_Add")));
            base.Title = this.objLanguage.convert(global.pageTitle("Roles Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Roles_Add");
            this.txtrole.Focus();
            this.gloobj.setpagename("setting");
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand dbCommand = null;
            string str = this.objbase.Return_IsEnable_CRM(Convert.ToInt32(Convert.ToInt32(this.Session["CompanyID"].ToString())));
            dbCommand = (str.Trim().ToLower() != "true" ? database.GetStoredProcCommand("PC_settings_role_slect") : database.GetStoredProcCommand("PC_settings_role_placeholder_New"));
            database.AddInParameter(dbCommand, "@CompanyID", DbType.Int64, Convert.ToInt64(this.Session["CompanyID"].ToString()));
            dataSet = database.ExecuteDataSet(dbCommand);
            int num = 0;
            CheckBox checkBox13 = new CheckBox();
            checkBox13.ID = string.Concat("chk_ReadDashboard", num);
            checkBox13.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
            checkBox13.Checked = true;
            this.plh_RolesNew.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px;' border='0' >"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<tr class='Header'>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>&nbsp;"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Show"), "</span>")));
            this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<tr>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<span>Dashboard</span>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
            //this.plh_RolesNew.Controls.Add(global.GetTickImage("Img_tab"));
            this.plh_RolesNew.Controls.Add(checkBox13);
            this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("</table>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));
            this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));

            ////////////////////////// Dashboard Roles ///////////////////////////////
            ///

            //DataSet dataSet1 = new DataSet();
            //dbCommand = database.GetStoredProcCommand("PC_Get_DashboardRole");
            //database.AddInParameter(dbCommand, "@companyID", DbType.Int64, Convert.ToInt64(this.Session["CompanyID"].ToString()));
            //database.AddInParameter(dbCommand, "@RoleID", DbType.Int64, Convert.ToInt64(base.Request.Params["roleid"]));
            //dataSet1 = database.ExecuteDataSet(dbCommand);
            //DataTable dt = dataSet1.Tables[0];
            //int UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            //bool flag = false;
            //foreach (DataRow row in CompanyBasePage.Select_Isadmin(Convert.ToInt32(this.Session["CompanyID"].ToString()), UserID).Rows)
            //{
            //    flag = Convert.ToBoolean(row["IsAdmin"].ToString());
            //}
            //if (flag)
            //{
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px;' border='0' >"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<tr class='Header'>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:155px;'>&nbsp;"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Read"), "</span>")));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));

            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Add_Edit"), "</span>")));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            //    //if (empty.ToLower() != "administrator")
            //    //{
            //    //    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            //    //}
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
            ////foreach (DataRow row in dt.Rows)
            ////{
            //CheckBox checkBox13 = new CheckBox();
            //checkBox13.ID = string.Concat("chk_ReadDashboard", num);
            //checkBox13.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
            //checkBox13.Checked = true;

            ////if (row["isView"].ToString().ToLower() == "true")
            ////{
            ////    checkBox11.Checked = true;
            ////}
            ////if (flag)
            ////{
            ////    checkBox11.Attributes.Add("disabled", "true");
            ////}
            ////else
            ////{
            ////    checkBox11.Attributes.Add("disabled", "false");
            ////}
            //CheckBox checkBox14 = new CheckBox();
            //checkBox14.ID = string.Concat("chk_EditDashboard", num);
            //checkBox14.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
            //checkBox14.Checked = true;
            ////if (row["isEdit"].ToString().ToLower() == "true" || row["isAdd"].ToString().ToLower() == "true")
            ////{
            ////    checkBox12.Checked = true;
            ////}
            ////    if (flag)
            ////    {
            ////        checkBox12.Attributes.Add("disabled", "true");
            ////    }
            ////    else
            ////    {
            ////        checkBox12.Attributes.Add("disabled", "false");
            ////    }
            //this.plh_RolesNew.Controls.Add(new LiteralControl("<tr>"));
            //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>"));
            //this.plh_RolesNew.Controls.Add(new LiteralControl("<span>Dashboard</span>"));
            //this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
            //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:60px;'>"));
            //this.plh_RolesNew.Controls.Add(checkBox13);
            //this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
            //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:60px;'>"));
            //this.plh_RolesNew.Controls.Add(checkBox14);
            //this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
            //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
            //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
            //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
            //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            ////if (empty.ToLower() != "administrator")
            ////{
            ////    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
            ////}
            //this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
            ////}

            //this.plh_RolesNew.Controls.Add(new LiteralControl("</table>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));
            //    this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));
            ////}


            ////////////////////////////////////////////////////////

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["sectionName"].ToString() == "DOCUMENTS")
                {
                    continue;
                }
                if (row["sectionName"].ToString() == "HOME")
                {
                    continue;
                }
                if (row["sectionName"].ToString() != "SETTINGS")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px;; border: 0px solid red;' border='0' >"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<tr class='Header'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>&nbsp;"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Show"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px;' border='0' >"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<tr class='Header'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>&nbsp;"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("MIS"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                if (row["sectionName"].ToString().ToLower() != "campaign" && row["sectionName"].ToString().ToLower() != "reports" && row["sectionName"].ToString().ToLower() != "digitalasset" && row["sectionName"].ToString().ToLower() != "settings")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Read"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Add_Edit"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Delete"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else if (row["sectionName"].ToString().ToLower() != "settings")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
                    if (ConnectionClass.WebStore.ToLower() == "yes")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("eStore"), "</span>")));
                    }
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                    //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                }
                if (row["Others"].ToString() == "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
                }
                else
                {
                    string empty = string.Empty;
                    if (row["sectionName"].ToString().ToLower() == "clients")
                    {
                        empty = this.objlang.GetLanguageConversion("Create_B2B_Store");
                    }
                    else if (row["sectionName"].ToString().ToLower() == "estimates")
                    {
                        empty = this.objlang.GetLanguageConversion("Progress_To_Job");
                    }
                    else if (row["sectionName"].ToString().ToLower() == "webstoreorder")
                    {
                        empty = this.objlang.GetLanguageConversion("Progress_To_Job");
                    }
                    else if (row["sectionName"].ToString().ToLower() == "jobs")
                    {
                        empty = this.objlang.GetLanguageConversion("Progress_To_Invoice");
                    }
                    else if (row["sectionName"].ToString().ToLower() == "purchases")
                    {
                        empty = this.objlang.GetLanguageConversion("Goods_Received");
                    }
                    else if (row["sectionName"].ToString().ToLower() != "invoices")
                    {
                        empty = (row["sectionName"].ToString().ToLower() != "warehouse" ? this.objlang.GetLanguageConversion("Others") : this.objlang.GetLanguageConversion("Adjustment"));
                    }
                    else
                    {
                        empty = this.objlang.GetLanguageConversion("Mark_As_Paid");
                    }
                    //else if(row["sectionName"].ToString().ToLower() != "proofs")
                    //{
                    //    if (row["sectionName"].ToString().ToLower() != "invoices")
                    //    {
                    //        empty = (row["sectionName"].ToString().ToLower() != "warehouse" ? this.objlang.GetLanguageConversion("Others") : this.objlang.GetLanguageConversion("Adjustment"));
                    //    }
                    //    else
                    //    {
                    //        empty = this.objlang.GetLanguageConversion("Mark_As_Paid");
                    //    }
                    //}

                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:145px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", empty, "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                if (row["PrintorEmail"].ToString() == "2")
                {
                    if (row["ExportorImport"].ToString() == "2")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
                    }
                    else
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Export_Import"), "</span>")));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    }
                }
                else if (row["sectionName"].ToString().ToLower() != "clients")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Print_Email"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else if (str.Trim().ToLower() != "true")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
                }
                else if (row["IsTaskEventCall"].ToString() == "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Task_Call"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                if (row["IsRevert"].ToString() != "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Revert"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else if (row["sectionName"].ToString().ToLower() != "clients")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
                else if (str.Trim().ToLower() != "true")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
                else if (row["IsForecast"].ToString() == "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Forecast"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                if (row["IsRemove"].ToString() != "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Remove"), "</span>")));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<tr>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", row["ScreenName"].ToString(), "</span>")));
                this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:60px;'>"));
                CheckBox checkBox = new CheckBox();
                CheckBox checkBox1 = new CheckBox();
                CheckBox checkBox2 = new CheckBox();
                CheckBox checkBox3 = new CheckBox();
                CheckBox checkBox4 = new CheckBox();
                CheckBox checkBox5 = new CheckBox();
                CheckBox checkBox6 = new CheckBox();
                CheckBox checkBox7 = new CheckBox();
                CheckBox checkBox8 = new CheckBox();
                CheckBox checkBox9 = new CheckBox();
                CheckBox checkBox10 = new CheckBox();
                CheckBox checkBox11 = new CheckBox();
                checkBox.ID = string.Concat("chk_Show", num);
                checkBox1.ID = string.Concat("chk_Read", num);
                checkBox2.ID = string.Concat("chk_AddEdit", num);
                checkBox3.ID = string.Concat("chk_Delete", num);
                checkBox4.ID = string.Concat("chk_Others", num);
                checkBox5.ID = string.Concat("chk_PrintEmail", num);
                checkBox6.ID = string.Concat("chk_ExportImport", num);
                checkBox7.ID = string.Concat("chk_Revert", num);
                checkBox8.ID = string.Concat("chk_eStore", num);
                checkBox9.ID = string.Concat("chk_CallTask", num);
                checkBox10.ID = string.Concat("chk_Forecast", num);
                checkBox11.ID = string.Concat("chk_Remove", num);
                checkBox.Checked = true;
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;
                checkBox10.Checked = true;
                checkBox11.Checked = true;
                checkBox1.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                checkBox2.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                checkBox3.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                checkBox4.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                checkBox5.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                checkBox6.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                checkBox7.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                checkBox11.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                if (row["sectionName"].ToString().ToLower() == "reports")
                {
                    int count = dataSet.Tables[1].Rows.Count;
                    checkBox.Attributes.Add("onClick", string.Concat("javascript:ReportCheck(this.id,", count, ");"));
                }
                this.plh_RolesNew.Controls.Add(checkBox);
                this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                if (row["sectionName"].ToString().ToLower() != "campaign" && row["sectionName"].ToString().ToLower() != "reports" && row["sectionName"].ToString().ToLower() != "settings" && row["sectionName"].ToString().ToLower() != "digitalasset")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
                    this.plh_RolesNew.Controls.Add(checkBox1);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(checkBox2);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
                    this.plh_RolesNew.Controls.Add(checkBox3);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else if (row["sectionName"].ToString().ToLower() != "settings")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
                    if (ConnectionClass.WebStore.ToLower() == "yes")
                    {
                        this.plh_RolesNew.Controls.Add(checkBox8);
                    }
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                    //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                }
                if (row["Others"].ToString() == "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>"));
                    this.plh_RolesNew.Controls.Add(checkBox4);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                if (row["PrintorEmail"].ToString() == "2")
                {
                    if (row["ExportorImport"].ToString() == "2")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
                    }
                    else
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>"));
                        this.plh_RolesNew.Controls.Add(checkBox6);
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    }
                }
                else if (row["sectionName"].ToString().ToLower() != "clients")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>"));
                    this.plh_RolesNew.Controls.Add(checkBox5);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else if (str.Trim().ToLower() != "true")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<div style='display:none'>"));
                    this.plh_RolesNew.Controls.Add(checkBox9);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</div>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else if (row["IsTaskEventCall"].ToString() != "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>"));
                    this.plh_RolesNew.Controls.Add(checkBox9);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                if (row["IsRevert"].ToString() != "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(checkBox7);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else if (row["sectionName"].ToString().ToLower() != "clients")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
                else if (str.Trim().ToLower() != "true")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<div style='display:none'>"));
                    this.plh_RolesNew.Controls.Add(checkBox10);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</div>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else if (row["IsForecast"].ToString() == "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(checkBox10);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                if (row["IsRemove"].ToString() != "2")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(checkBox11);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
                Label label = new Label()
                {
                    ID = string.Concat("lblSelect", num),
                    Text = this.objlang.GetLanguageConversion("Select_None")
                };
                this.hdn_SelectText.Value = "Select None";
                label.Attributes.Add("style", "cursor:pointer;");
                System.Web.UI.AttributeCollection attributes = label.Attributes;
                object[] lower = new object[] { "javascript:SelectAll_None(this.id,'", row["sectionName"].ToString().ToLower(), "','", num, "');" };
                attributes.Add("onclick", string.Concat(lower));
                if (row["sectionName"].ToString().ToLower() == "reports")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
                else if (row["sectionName"].ToString().ToLower() != "settings")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                    this.plh_RolesNew.Controls.Add(label);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                else
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
                    this.plh_RolesNew.Controls.Add(label);
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                }
                this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("</table>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));
                roles_add settingsRolesAdd = this;
                settingsRolesAdd.HeaderText_Name = string.Concat(settingsRolesAdd.HeaderText_Name, ",", row["sectionName"].ToString());
                num++;
            }
            this.plh_Reports.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px;' border='0' >"));
            this.plh_Reports.Controls.Add(new LiteralControl("<tr class='Header'>"));
            this.plh_Reports.Controls.Add(new LiteralControl("<td align='left' style='width:160px;'>"));
            this.plh_Reports.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Reports"), "</span>")));
            this.plh_Reports.Controls.Add(new LiteralControl("</td>"));
            this.plh_Reports.Controls.Add(new LiteralControl("<td align='center'  style='width:70px;'>"));
            this.plh_Reports.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Show"), "</span>")));
            this.plh_Reports.Controls.Add(new LiteralControl("</td>"));
            this.plh_Reports.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
            this.plh_Reports.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Export"), "</span>")));
            this.plh_Reports.Controls.Add(new LiteralControl("</td>"));
            this.plh_Reports.Controls.Add(new LiteralControl("<td align='center' style='width:600px;'>"));
            this.plh_Reports.Controls.Add(new LiteralControl("</td>"));
            this.plh_Reports.Controls.Add(new LiteralControl("</tr>"));
            int num1 = 0;
            foreach (DataRow dataRow in dataSet.Tables[1].Rows)
            {
                CheckBox checkBox11 = new CheckBox();
                CheckBox checkBox12 = new CheckBox();
                checkBox11.ID = string.Concat("chk_ShowReport", num1);
                checkBox12.ID = string.Concat("chk_ExportReport", num1);
                checkBox11.Checked = true;
                checkBox12.Checked = true;
                this.plh_Reports.Controls.Add(new LiteralControl("<tr>"));
                this.plh_Reports.Controls.Add(new LiteralControl("<td align='left' style='width:160px;'>"));
                this.plh_Reports.Controls.Add(new LiteralControl(string.Concat("<span>", dataRow["ReportItems"].ToString(), "</span>")));
                this.plh_Reports.Controls.Add(new LiteralControl("</td>"));
                this.plh_Reports.Controls.Add(new LiteralControl("<td align='center'  style='width:70px;'>"));
                this.plh_Reports.Controls.Add(checkBox11);
                this.plh_Reports.Controls.Add(new LiteralControl("</td>"));
                this.plh_Reports.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>"));
                this.plh_Reports.Controls.Add(checkBox12);
                this.plh_Reports.Controls.Add(new LiteralControl("</td>"));
                this.plh_Reports.Controls.Add(new LiteralControl("<td align='center' style='width:600px;'>"));
                this.plh_Reports.Controls.Add(new LiteralControl("</td>"));
                this.plh_Reports.Controls.Add(new LiteralControl("</tr>"));
                roles_add settingsRolesAdd1 = this;
                string reportText = settingsRolesAdd1.ReportText;
                string[] strArrays = new string[] { reportText, ",", dataRow["ReportItems"].ToString(), "~", dataRow["ReportOrderNumber"].ToString() };
                settingsRolesAdd1.ReportText = string.Concat(strArrays);
                num1++;
            }
            this.plh_Reports.Controls.Add(new LiteralControl("</table>"));
            this.HeaderText_Name = this.HeaderText_Name.Substring(1);
            string headerTextName = this.HeaderText_Name;
            char[] chrArray = new char[] { ',' };
            this.HeaderArray_Name = headerTextName.Split(chrArray);
            this.ReportText = this.ReportText.Substring(1);
            string reportText1 = this.ReportText;
            char[] chrArray1 = new char[] { ',' };
            this.ReportArray = reportText1.Split(chrArray1);
            this.chkShowCostExMarkup.Checked = true;
            this.chkShowMarkup.Checked = true;
            this.chkShowCostIncMarkup.Checked = true;
            this.chkShowProfitMargin.Checked = true;
            this.chkShowProfitCurrency.Checked = true;
            this.chkShowSubTotal.Checked = true;
            this.chkShowTax.Checked = true;
            this.chkShowSellingPrice.Checked = true;
            this.chkShowGrossProfitMargin.Checked = true;
            this.chkShowGrossProfitCurrency.Checked = true;
            this.rdoOtherRecords.Checked = true;
        }

        public void BindDefaultRolesandPrivileges()
        {
            this.btnCancel.Text = this.objlang.GetValueOnLang("Cancel");
            this.btnSave.Text = this.objlang.GetValueOnLang("Save");
            this.RFVCode.Text = this.objlang.GetValueOnLang("Please enter Role Name");
            this.btnCancel.Attributes.Add("onclick", "javascript:return cancelClick(path+'Settings/user_manager.aspx');");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/user_manager.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Roles_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Roles_Add")));
            base.Title = this.objLanguage.convert(global.pageTitle("Roles Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.txtrole.Focus();
            this.gloobj.setpagename("setting");
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand(string.Concat("crm_select_user_role_New ", this.Session["companyID"]), _commonClass.openConnection());
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                roles_add settingsRolesAdd = this;
                settingsRolesAdd.HeaderText = string.Concat(settingsRolesAdd.HeaderText, ",", sqlDataReader["sectionName"].ToString());
            }
            _commonClass.closeConnection();
            sqlCommand.Dispose();
            sqlDataReader.Dispose();
            _commonClass.Dispose();
            this.HeaderText = this.HeaderText.Substring(1);
            string headerText = this.HeaderText;
            char[] chrArray = new char[] { ',' };
            this.HeaderArray = headerText.Split(chrArray);
            int length = (int)this.HeaderArray.Length - 1;
            this.HiddenField1.Value = length.ToString();
            this.plhaddusertype.Controls.Add(new LiteralControl("<table id=Table1 cellspacing=1 cellpadding=2 width=35% align=left border=0>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("<tr valign=top height=23><td style=width:2px></td>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("<td width=43% class='bgcustomize navigatorpanel' nowrap>"));
            this.plhaddusertype.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Sections")));
            this.plhaddusertype.Controls.Add(new LiteralControl("</td>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("<td width=10% class='bgcustomize navigatorpanel' align=center nowrap>"));
            this.plhaddusertype.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Show_Tab")));
            this.plhaddusertype.Controls.Add(new LiteralControl("</td>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("<td width=27%></td>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("</tr>"));
            int num = 0;
            for (int i = 0; i < (int)this.HeaderArray.Length; i++)
            {
                this.plhaddusertype.Controls.Add(new LiteralControl("<tr><td style=width:2px></td>"));
                this.plhaddusertype.Controls.Add(new LiteralControl("<td width=20% class=rtBody>"));
                string str = base.ReturnScreenName(this.HeaderArray[i].ToString().ToUpper(), 2, "p");
                if (str.ToLower() == "crm")
                {
                    str = "CRM";
                }
                this.plhaddusertype.Controls.Add(new LiteralControl(base.SpecialDecode(str)));
                this.plhaddusertype.Controls.Add(new LiteralControl("</td>"));
                this.plhaddusertype.Controls.Add(new LiteralControl("<td width=10% align=center class=rtBody nowrap>"));
                if (this.HeaderArray[i].ToString().ToLower() != "home")
                {
                    CheckBox checkBox = new CheckBox()
                    {
                        ID = string.Concat("chktab_", num)
                    };
                    checkBox.Attributes.Add("onclick", string.Concat("javascript:CheckFunctionalites(this,'", num, "');"));
                    checkBox.Checked = true;
                    this.plhaddusertype.Controls.Add(checkBox);
                }
                else
                {
                    this.plhaddusertype.Controls.Add(global.GetTickImage("Img_tab"));
                }
                this.plhaddusertype.Controls.Add(new LiteralControl("</td>"));
                this.plhaddusertype.Controls.Add(new LiteralControl("<td width=27%></td>"));
                this.plhaddusertype.Controls.Add(new LiteralControl("</tr>"));
                if (this.HeaderArray[i].ToString().ToLower() != "home")
                {
                    num++;
                }
            }
            this.objLanguage.Dispose();
            this.plhaddusertype.Controls.Add(new LiteralControl("</table>"));
        }

        protected void btn_SaveRole_OnClick(object sender, EventArgs e)
        {
            CheckBox checkBox;
            string str = base.SpecialEncode(this.txtrole.Text);
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("[PC_Settings_common_checkRole_New]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", this.Session["CompanyID"]);
            sqlCommand.Parameters.AddWithValue("@RoleName", str);
            if ((int)sqlCommand.ExecuteScalar() > 0)
            {
                base.Message_Display("Role Name already exists", "msg-fail", this.plhMessage);
                _commonClass.closeConnection();
                _commonClass.Dispose();
                sqlCommand.Dispose();
                return;
            }
            DbSettings dbSetting = new DbSettings();
            this.CompanyID = Convert.ToInt16(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt16(this.Session["UserID"].ToString());
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            bool flag7 = false;
            bool flag8 = false;
            bool flag9 = false;
            bool flag10 = false;
            bool flag11 = false;
            bool showSupplierName = false;
            bool showPrice = false;
            bool showCalculated = false;
            bool showSubItems = false;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string text = string.Empty;
            string empty2 = string.Empty;
            string text1 = string.Empty;
            if (this.chkShowCostExMarkup.Checked)
            {
                flag = true;
            }
            if (this.chkShowMarkup.Checked)
            {
                flag1 = true;
            }
            if (this.chkShowCostIncMarkup.Checked)
            {
                flag2 = true;
            }
            if (this.chkShowProfitMargin.Checked)
            {
                flag3 = true;
            }
            if (this.chkShowProfitCurrency.Checked)
            {
                flag4 = true;
            }
            if (this.chkShowSubTotal.Checked)
            {
                flag5 = true;
            }
            if (this.chkShowTax.Checked)
            {
                flag6 = true;
            }
            if (this.chkShowSellingPrice.Checked)
            {
                flag7 = true;
            }
            if (this.chkShowGrossProfitMargin.Checked)
            {
                flag8 = true;
            }
            if (this.chkShowGrossProfitCurrency.Checked)
            {
                flag9 = true;
            }
            if (this.chkShowSupplier.Checked)
            {
                showSupplierName = true;
            }
            if (this.chkShowPrice.Checked)
            {
                showPrice = true;
            }
            if (this.ChkShowCalculated.Checked)
            {
                showCalculated = true;
            }
            if (this.ChkShowSubItems.Checked)
            {
                showSubItems = true;
            }
            if (this.chkbxSpecialPrivileges.Checked)
            {
                flag11 = true;
            }
            if (this.rdoShowAll.Checked)
            {
                empty = "All";
            }
            else if (this.rdoShowAllocation.Checked)
            {
                empty = "Allocation";
            }
            else if (this.rdoShowType.Checked)
            {
                empty = "Type";
                if (this.lstBxType.Items.Count > 0)
                {
                    for (int i = 0; i < this.lstBxType.Items.Count - 1; i++)
                    {
                        if (this.lstBxType.Items[i].Selected)
                        {
                            str1 = string.Concat(str1, this.lstBxType.Items[i].Value.ToString(), ",");
                        }
                    }
                }
            }
            if (this.rdoHisRecords.Checked)
            {
                empty1 = "His";
            }
            else if (this.rdoOtherRecords.Checked)
            {
                empty1 = "Other";
            }
            text = this.txtRestrict.Text;
            if (this.rdoSingleIP.Checked)
            {
                empty2 = "S";
                text1 = this.txtSingleIP.Text;
            }
            else if (this.rdoMultipleIP.Checked)
            {
                empty2 = "M";
                text1 = this.txtMultipleIP.Text;
            }
            else if (this.rdoRangeIP.Checked)
            {
                empty2 = "R";
                text1 = string.Concat(this.txtFromIP.Text, ",", this.txtToIP.Text);
            }
            string str2 = base.SpecialEncode(this.txtrole.Text);
            string str3 = base.SpecialEncode(this.txtDescription.Text);
            long num = (long)0;
            CheckBox readDashboardChk;
            int isDashboardShow = 0;
            try
            {
                readDashboardChk = (CheckBox)this.plhaddusertype.FindControl("chk_ReadDashboard0");
                if (readDashboardChk.Checked)
                {
                    isDashboardShow = 1;
                }
            }
            catch
            {
            }
            num = SettingsBasePage.Roles_StaticCheckBox_Insert(str2, this.CompanyID, str3, flag, flag1, flag2, flag3, flag4, flag5, flag6, flag7, flag8, flag9, showSupplierName, showPrice, showCalculated, showSubItems, this.txtLock.Text, this.txtForce.Text, text, flag10, flag11, empty, empty1, str1, empty2, text1);
            //SettingsBasePage.Roles_AccessDetails_Insert(num, "HOME", 1, 1, 1, 1, "2", "2", "2", "2", Convert.ToInt64(this.Session["CompanyID"].ToString()), "2", "2");
            SettingsBasePage.Roles_AccessDetails_Insert(num, "HOME", 1, isDashboardShow, 1, isDashboardShow, "2", "2", "2", "2", Convert.ToInt64(this.Session["CompanyID"].ToString()), "2", "2","1");
            for (int j = 0; j < (int)this.HeaderArray_Name.Length; j++)
            {
                string str4 = this.HeaderArray_Name[j].ToString();
                DataTable dataTable = new DataTable();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_role_plhIndividual_New");
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, Convert.ToInt64(this.Session["CompanyID"].ToString()));
                database.AddInParameter(storedProcCommand, "@sectionName", DbType.String, str4);
                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                }
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                string str5 = "0";
                string str6 = "0";
                string str7 = "0";
                string str8 = "0";
                string str9 = "0";
                string str10 = "0";
                string str11 = "0";

                try
                {
                    checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Read", j));
                    if (checkBox.Checked)
                    {
                        num1 = 1;
                    }
                }
                catch
                {
                }
                try
                {
                    checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_AddEdit", j));
                    if (checkBox.Checked)
                    {
                        num2 = 1;
                    }
                }
                catch
                {
                }
                try
                {
                    checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Delete", j));
                    if (checkBox.Checked)
                    {
                        num3 = 1;
                    }
                }
                catch
                {
                }
                try
                {
                    checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Show", j));
                    if (checkBox.Checked)
                    {
                        num4 = 1;
                    }
                }
                catch
                {
                }
                if (dataTable.Rows.Count > 0)//KR
                {
                    if (dataTable.Rows[0]["Others"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Others", j));
                            if (checkBox.Checked)
                            {
                                str5 = "1";
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        str5 = "2";
                    }
                    if (dataTable.Rows[0]["PrintorEmail"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_PrintEmail", j));
                            if (checkBox.Checked)
                            {
                                str6 = "1";
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        str6 = "2";
                    }
                    if (dataTable.Rows[0]["ExportorImport"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_ExportImport", j));
                            if (checkBox.Checked)
                            {
                                str7 = "1";
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        str7 = "2";
                    }
                    if (dataTable.Rows[0]["IsRevert"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Revert", j));
                            if (checkBox.Checked)
                            {
                                str8 = "1";
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        str8 = "2";
                    }
                    if (dataTable.Rows[0]["IsRemove"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Remove", j));
                            if (checkBox.Checked)
                            {
                                str11 = "1";
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        str11 = "2";
                    }
                    if (dataTable.Rows[0]["IsTaskEventCall"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_CallTask", j));
                            if (checkBox.Checked)
                            {
                                str9 = "1";
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        str9 = "2";
                    }
                    if (dataTable.Rows[0]["IsForecast"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Forecast", j));
                            if (checkBox.Checked)
                            {
                                str10 = "1";
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        str10 = "2";
                    }
                }//KR end
                if (str4.ToLower() == "campaign" || str4.ToLower() == "digitalasset" || str4.ToLower() == "reports")
                {
                    if (num4 == 1)
                    {
                        num2 = 1;
                        num1 = 1;
                        num3 = 1;
                    }
                    SettingsBasePage.Roles_AccessDetails_Insert(num, str4, num2, num1, num3, num4, str5, str6, str7, str8, Convert.ToInt64(this.Session["CompanyID"].ToString()), "2", "2", str11);
                }
                else if (str4.ToLower() != "settings")
                {
                    SettingsBasePage.Roles_AccessDetails_Insert(num, str4, num2, num1, num3, num4, str5, str6, str7, str8, Convert.ToInt64(this.Session["CompanyID"].ToString()), str9, str10, str11);
                }
                else
                {
                    try
                    {
                        checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Show", j));
                        if (checkBox.Checked)
                        {
                            num4 = 1;
                            num2 = 1;
                            num1 = 1;
                            num3 = 1;
                        }
                    }
                    catch
                    {
                    }
                    SettingsBasePage.Roles_AccessDetails_Insert(num, "SETTINGS", num2, num1, num3, num4, str5, str6, str7, str8, Convert.ToInt64(this.Session["CompanyID"].ToString()), "2", "2", str11);
                    try
                    {
                        checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_eStore", j));
                        if (ConnectionClass.WebStore.ToLower() == "yes")
                        {
                            if (!checkBox.Checked)
                            {
                                num4 = 0;
                                num2 = 0;
                                num1 = 0;
                                num3 = 0;
                            }
                            else
                            {
                                num4 = 1;
                                num2 = 1;
                                num1 = 1;
                                num3 = 1;
                            }
                        }
                    }
                    catch
                    {
                    }
                    SettingsBasePage.Roles_AccessDetails_Insert(num, "eStore", num2, num1, num3, num4, str5, str6, str7, str8, Convert.ToInt64(this.Session["CompanyID"].ToString()), "2", "2", str11);
                }
            }
            CheckBox checkBox1 = new CheckBox();
            for (int k = 0; k < (int)this.ReportArray.Length; k++)
            {
                string[] strArrays = this.ReportArray[k].ToString().Split(new char[] { '~' });
                string str11 = strArrays[0].ToString();
                string str12 = strArrays[1].ToString();
                int num5 = 0;
                int num6 = 0;
                try
                {
                    if (((CheckBox)this.plh_Reports.FindControl(string.Concat("chk_ShowReport", k))).Checked)
                    {
                        num5 = 1;
                    }
                }
                catch
                {
                }
                try
                {
                    if (((CheckBox)this.plh_Reports.FindControl(string.Concat("chk_ExportReport", k))).Checked)
                    {
                        num6 = 1;
                    }
                }
                catch
                {
                }
                SettingsBasePage.Roles_ReportDetails_Insert(num, num5, num6, Convert.ToInt64(this.Session["CompanyID"].ToString()), str11, Convert.ToInt16(str12));
            }
            base.Response.Redirect("user_manager.aspx?Su=in");
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            string str = base.SpecialEncode(this.txtrole.Text);
            string str1 = base.SpecialEncode(this.txtDescription.Text);
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("[pc_Settings_common_checkusertype]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@companyID", this.Session["CompanyID"]);
            sqlCommand.Parameters.AddWithValue("@usertype", str);
            if ((int)sqlCommand.ExecuteScalar() > 0)
            {
                base.Message_Display("Name already exists", "msg-fail", this.plhMessage);
                _commonClass.closeConnection();
                _commonClass.Dispose();
                sqlCommand.Dispose();
                return;
            }
            int num = 0;
            for (int i = 0; i < (int)this.HeaderArray.Length; i++)
            {
                string str2 = this.HeaderArray[i].ToString();
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                string empty = string.Empty;
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                bool flag = false;
                if (str2.ToLower() == "home")
                {
                    num1 = 1;
                    num2 = 1;
                    num3 = 1;
                    num4 = 1;
                    num6 = 1;
                    empty = "2";
                    empty1 = "2";
                    empty2 = "2";
                    empty3 = "2";
                }
                else
                {
                    CheckBox checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chktab_", num));
                    if (str2.ToLower() == "clients")
                    {
                        if (!checkBox.Checked)
                        {
                            empty = "0";
                            empty1 = "0";
                            empty2 = "2";
                            empty3 = "2";
                        }
                        else
                        {
                            empty = "1";
                            empty1 = "1";
                            empty2 = "2";
                            empty3 = "2";
                        }
                    }
                    else if (str2.ToLower() == "estimates")
                    {
                        if (!checkBox.Checked)
                        {
                            empty = "0";
                            empty1 = "0";
                            empty2 = "2";
                            empty3 = "2";
                        }
                        else
                        {
                            empty = "1";
                            empty1 = "1";
                            empty2 = "2";
                            empty3 = "2";
                        }
                    }
                    else if (str2.ToLower() == "jobs")
                    {
                        if (!checkBox.Checked)
                        {
                            empty = "0";
                            empty1 = "0";
                            empty2 = "2";
                            empty3 = "0";
                        }
                        else
                        {
                            empty = "1";
                            empty1 = "1";
                            empty2 = "2";
                            empty3 = "1";
                        }
                    }
                    else if (str2.ToLower() == "campaign")
                    {
                        empty = "2";
                        empty1 = "2";
                        empty2 = "2";
                        empty3 = "2";
                    }
                    else if (str2.ToLower() == "purchases")
                    {
                        if (!checkBox.Checked)
                        {
                            empty = "0";
                            empty1 = "0";
                            empty2 = "2";
                            empty3 = "2";
                        }
                        else
                        {
                            empty = "1";
                            empty1 = "1";
                            empty2 = "2";
                            empty3 = "2";
                        }
                    }
                    else if (str2.ToLower() == "invoices")
                    {
                        if (!checkBox.Checked)
                        {
                            empty = "0";
                            empty1 = "0";
                            empty2 = "2";
                            empty3 = "2";
                        }
                        else
                        {
                            empty = "1";
                            empty1 = "1";
                            empty2 = "2";
                            empty3 = "2";
                        }
                    }
                    else if (str2.ToLower() == "warehouse")
                    {
                        if (!checkBox.Checked)
                        {
                            empty = "0";
                            empty1 = "2";
                            empty2 = "0";
                            empty3 = "2";
                        }
                        else
                        {
                            empty = "1";
                            empty1 = "2";
                            empty2 = "1";
                            empty3 = "2";
                        }
                    }
                    else if (str2.ToLower() == "documents")
                    {
                        empty = "2";
                        empty1 = "2";
                        empty2 = "2";
                        empty3 = "2";
                    }
                    else if (str2.ToLower() == "reports")
                    {
                        if (!checkBox.Checked)
                        {
                            commonClass _commonClass1 = new commonClass();
                            SqlCommand sqlCommand1 = new SqlCommand("PC_settings_role_Default_Reports", _commonClass1.openConnection())
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            sqlCommand1.Parameters.AddWithValue("@Usertype", this.txtrole.Text);
                            sqlCommand1.Parameters.AddWithValue("@companyID", this.Session["companyID"]);
                            sqlCommand1.Parameters.AddWithValue("@Type", "uncheck");
                            sqlCommand1.ExecuteNonQuery();
                            _commonClass1.closeConnection();
                        }
                        else
                        {
                            commonClass _commonClass2 = new commonClass();
                            SqlCommand sqlCommand2 = new SqlCommand("PC_settings_role_Default_Reports", _commonClass2.openConnection())
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            sqlCommand2.Parameters.AddWithValue("@Usertype", this.txtrole.Text);
                            sqlCommand2.Parameters.AddWithValue("@companyID", this.Session["companyID"]);
                            sqlCommand2.Parameters.AddWithValue("@Type", "check");
                            sqlCommand2.ExecuteNonQuery();
                            _commonClass2.closeConnection();
                        }
                        empty = "2";
                        empty1 = "2";
                        empty2 = "2";
                        empty3 = "2";
                    }
                    else if (str2.ToLower() == "deliverynote")
                    {
                        if (!checkBox.Checked)
                        {
                            empty = "2";
                            empty1 = "0";
                            empty2 = "2";
                            empty3 = "2";
                        }
                        else
                        {
                            empty = "2";
                            empty1 = "1";
                            empty2 = "2";
                            empty3 = "2";
                        }
                    }
                    else if (str2.ToLower() == "settings")
                    {
                        empty = "2";
                        empty1 = "2";
                        empty2 = "2";
                        empty3 = "2";
                        flag = true;
                    }
                    else if (str2.ToLower() != "productcatalogue")
                    {
                        empty = "2";
                        empty1 = "2";
                        empty2 = "2";
                        empty3 = "2";
                    }
                    else
                    {
                        empty = "2";
                        empty1 = "2";
                        empty2 = "2";
                        empty3 = "2";
                    }
                    if (checkBox.Checked)
                    {
                        num1 = 1;
                        num2 = 1;
                        num3 = 1;
                        num4 = 1;
                        num6 = 1;
                    }
                    num++;
                }
                SettingsBasePage.common_add_usertype_and_accessrights_new_Default(Convert.ToInt64(this.Session["companyID"]), Convert.ToInt64(this.Session["userid"]), str, str2, num1, num2, num3, num4, num6, num5, empty, empty1, empty2, empty3, str1);
                if (flag)
                {
                    SettingsBasePage.common_add_usertype_and_accessrights_new_Default(Convert.ToInt64(this.Session["companyID"]), Convert.ToInt64(this.Session["userid"]), str, "eStore", num1, num2, num3, num4, num6, num5, empty, empty1, empty2, empty3, str1);
                }
                commonClass _commonClass3 = new commonClass();
                SqlCommand sqlCommand3 = new SqlCommand("PC_Settings_UserType_SpecialPrivilege_Insert_New", _commonClass3.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand3.Parameters.AddWithValue("@companyID", this.Session["companyID"]);
                sqlCommand3.Parameters.AddWithValue("@Usertype", this.txtrole.Text);
                if (!this.chkbxSpecialPrivileges.Checked)
                {
                    sqlCommand3.Parameters.AddWithValue("@isSpecialPrivilege", false);
                }
                else
                {
                    sqlCommand3.Parameters.AddWithValue("@isSpecialPrivilege", true);
                }
                sqlCommand3.ExecuteNonQuery();
                _commonClass3.closeConnection();
                _commonClass3.Dispose();
            }
            base.Response.Redirect("user_manager.aspx?Su=in");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("setting");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.revSingleIPAddress.ErrorMessage = this.objlang.GetLanguageConversion("Please_enter_a_valid_IP_Address");
            if (!base.IsPostBack)
            {
                DataTable dataTable = new DataTable();
                dataTable = Settings.settings_CompanyType_select(Convert.ToInt16(this.Session["CompanyID"].ToString()));
                this.lstBxType.DataSource = dataTable;
                this.lstBxType.DataTextField = "companytype";
                this.lstBxType.DataValueField = "id";
                this.lstBxType.DataBind();
            }
            DataTable dataTable1 = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_role_CustomAccessRight");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, Convert.ToInt64(this.Session["CompanyID"].ToString()));
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable1.Load(dataReader);
            }
            if (dataTable1.Rows.Count > 0)
            {
                if (dataTable1.Rows[0]["IsCustomAccessRight"].ToString() != "True")
                {
                    this.BindDefaultRolesandPrivileges();
                    this.pnlDefaultRoles.Style.Add("display", "block");
                    this.pnlCustomizeRoles.Style.Add("display", "none");
                }
                else
                {
                    this.BindCustomRolesandPrivileges();
                    this.pnlDefaultRoles.Style.Add("display", "none");
                    this.pnlCustomizeRoles.Style.Add("display", "block");
                }
            }
            if (ConnectionClass.WebStore != "")
            {
                if (ConnectionClass.WebStore.ToLower() == "yes")
                {
                    this.IsWebStore = "yes";
                    return;
                }
                this.IsWebStore = "no";
            }
        }
    }
}