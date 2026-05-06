using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.DataAccessLayer.Settings;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Specialized;
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
    public partial class roles_edit : BaseClass, IRequiresSessionState
    {

        private Global gloobj = new Global();

        public int companyId;

        public int userId;

        public string strImagepath;

        public int usertypeid;

        private string[] HeaderArray;

        private string[] HeaderArray_Name;

        private string[] ReportArray;

        private string HeaderText = "";

        private string HeaderText_Name = "";

        private string ReportText = "";

        private string RoleStatus = string.Empty;

        public string IsWebStore = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        public commonClass cmnClass = new commonClass();

        private BaseClass objbase = new BaseClass();

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

        public roles_edit()
        {
        }

        public void BindCustomRolesandPrivileges()
        {
            this.btnDelete.Text = this.objlang.GetLanguageConversion("Delete");
            this.btn_UpdateRole.Text = this.objlang.GetLanguageConversion("Save");
            this.btn_CancelRole.Text = this.objlang.GetLanguageConversion("Back");
            this.strImagepath = global.imagePath();
            this.companyId = int.Parse(this.Session["companyid"].ToString());
            this.userId = int.Parse(this.Session["userid"].ToString());
            this.usertypeid = Convert.ToInt32(base.Request.Params["roleid"]);
            base.Title = this.objLanguage.convert(global.pageTitle("Edit Role", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/user_manager.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Roles_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Roles_Edit")));
            base.Title = this.objLanguage.convert(global.pageTitle("Roles Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Roles_Edit");
            if (this.RoleStatus != "RoleDeleted")
            {
                DataSet dataSet = new DataSet();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand dbCommand = null;
                string str = this.objbase.Return_IsEnable_CRM(Convert.ToInt32(Convert.ToInt32(this.Session["CompanyID"].ToString())));
                dbCommand = (str.Trim().ToLower() != "true" ? database.GetStoredProcCommand("PC_settings_role_select_Edit") : database.GetStoredProcCommand("PC_settings_role_placeholder_Edit_New"));
                database.AddInParameter(dbCommand, "@companyID", DbType.Int64, Convert.ToInt64(this.Session["CompanyID"].ToString()));
                database.AddInParameter(dbCommand, "@RoleID", DbType.Int64, Convert.ToInt64(base.Request.Params["roleid"]));
                dataSet = database.ExecuteDataSet(dbCommand);
                string empty = string.Empty;
                empty = dataSet.Tables[2].Rows[0]["Usertype"].ToString();
                int num = 0;
                CheckBox checkBox29 = new CheckBox();
                checkBox29.ID = string.Concat("chk_ReadDashboard", num);
                checkBox29.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (row["sectionName"].ToString().ToLower() == "home")
                    {
                        if (row["isDisplay"].ToString() == "True")
                        {
                            checkBox29.Checked = true;
                        }
                        else
                        {
                            checkBox29.Checked = false;
                        }
                    }
                }
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px' border='0' >"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<tr class='Header'>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>&nbsp;"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Show"), "</span>")));
                this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                if (empty.ToLower() != "administrator")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<tr>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<span>Dashboard</span>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
                //this.plh_RolesNew.Controls.Add(global.GetTickImage("Img_tab"));
                this.plh_RolesNew.Controls.Add(checkBox29);
                this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
                this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                if (empty.ToLower() != "administrator")
                {
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                }
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
                //if(flag)
                //{
                //    this.plh_RolesNew.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px' border='0' >"));
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
                //    if (empty.ToLower() != "administrator")
                //    {
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                //    }
                //    this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
                //    foreach (DataRow row in dt.Rows)
                //    {
                //        CheckBox checkBox11 = new CheckBox();
                //        checkBox11.ID = string.Concat("chk_ReadDashboard", num);
                //        checkBox11.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                //        if (row["isView"].ToString().ToLower() == "true")
                //        {
                //            checkBox11.Checked = true;
                //        }
                //        if(flag)
                //        {
                //            checkBox11.Attributes.Add("disabled", "true");
                //        }
                //        else
                //        {
                //            checkBox11.Attributes.Add("disabled", "false");
                //        }
                //        CheckBox checkBox12 = new CheckBox();
                //        checkBox12.ID = string.Concat("chk_EditDashboard", num);
                //        checkBox12.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                //        if (row["isEdit"].ToString().ToLower() == "true" || row["isAdd"].ToString().ToLower() == "true")
                //        {
                //            checkBox12.Checked = true;
                //        }
                //        if (flag)
                //        {
                //            checkBox12.Attributes.Add("disabled", "true");
                //        }
                //        else
                //        {
                //            checkBox12.Attributes.Add("disabled", "false");
                //        }
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<tr>"));
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>"));
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<span>Dashboard</span>"));
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:60px;'>"));
                //        this.plh_RolesNew.Controls.Add(checkBox11);
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:60px;'>"));
                //        this.plh_RolesNew.Controls.Add(checkBox12);
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:110px;'>&nbsp;</td>"));
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                //        if (empty.ToLower() != "administrator")
                //        {
                //            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                //        }
                //        this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
                //    }

                //    this.plh_RolesNew.Controls.Add(new LiteralControl("</table>"));
                //    this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));
                //    this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));
                //}
                

                ////////////////////////////////////////////////////////

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (row["sectionName"].ToString().ToLower() == "documents")
                    {
                        continue;
                    }
                    if (row["sectionName"].ToString().ToLower() == "home")
                    {
                        continue;
                    }
                    if (row["sectionName"].ToString().ToLower() != "settings")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px' border='0' >"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<tr class='Header'>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>&nbsp;"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Show"), "</span>")));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px' border='0' >"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<tr class='Header'>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='left' style='width:80px;'>&nbsp;"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:60px;'>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objLanguage.GetLanguageConversion("MIS"), "</span>")));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (row["sectionName"].ToString().ToLower() != "campaign" && row["sectionName"].ToString().ToLower() != "reports" && row["sectionName"].ToString().ToLower() != "settings" && row["sectionName"].ToString().ToLower() != "digitalasset")
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
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("archive"), "</span>")));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    }
                    else if (row["sectionName"].ToString().ToLower() != "settings")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
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
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                        //this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                    }
                    if (row["Others"].ToString() == "2")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:145px;'>&nbsp;</td>"));
                    }
                    else
                    {
                        string empty1 = string.Empty;
                        if (row["sectionName"].ToString().ToLower() == "clients")
                        {
                            empty1 = this.objlang.GetLanguageConversion("Create_B2B_Store");
                        }
                        else if (row["sectionName"].ToString().ToLower() == "estimates")
                        {
                            empty1 = this.objlang.GetLanguageConversion("Progress_To_Job");
                        }
                        else if (row["sectionName"].ToString().ToLower() == "webstoreorder")
                        {
                            empty1 = this.objlang.GetLanguageConversion("Progress_To_Job");
                        }
                        else if (row["sectionName"].ToString().ToLower() == "jobs")
                        {
                            empty1 = this.objlang.GetLanguageConversion("Progress_To_Invoice");
                        }
                        else if (row["sectionName"].ToString().ToLower() == "purchases")
                        {
                            empty1 = this.objlang.GetLanguageConversion("Goods_Received");
                        }
                        else if (row["sectionName"].ToString().ToLower() != "invoices")
                        {
                            empty1 = (row["sectionName"].ToString().ToLower() != "warehouse" ? this.objlang.GetLanguageConversion("Others") : this.objlang.GetLanguageConversion("Adjustment"));
                        }
                        else
                        {
                            empty1 = this.objlang.GetLanguageConversion("Mark_As_Paid");
                        }
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center'  style='width:145px;'>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", empty1, "</span>")));
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
                    if (row["IsRemove"].ToString() != "2")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl(string.Concat("<span>", this.objlang.GetLanguageConversion("Remove"), "</span>")));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    }

                    else if (row["sectionName"].ToString().ToLower() != "clients")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    }
                    else
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    }
                    if (empty.ToLower() != "administrator")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    }
                    if (row["sectionName"].ToString().ToLower() != "jobs")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    }
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
                    CheckBox chkBoxArchive = new CheckBox();
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
                    chkBoxArchive.ID = string.Concat("chk_Archive", num);
                    checkBox4.ID = string.Concat("chk_Others", num);
                    checkBox5.ID = string.Concat("chk_PrintEmail", num);
                    checkBox6.ID = string.Concat("chk_ExportImport", num);
                    checkBox7.ID = string.Concat("chk_Revert", num);
                    checkBox8.ID = string.Concat("chk_eStore", num);
                    checkBox9.ID = string.Concat("chk_CallTask", num);
                    checkBox11.ID = string.Concat("chk_Remove", num);
                    checkBox1.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                    checkBox2.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                    checkBox3.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                    chkBoxArchive.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                    checkBox4.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                    checkBox5.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                    checkBox6.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                    checkBox7.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                    checkBox11.Attributes.Add("onClick", string.Concat("javascript:Chk_Show(this.id,", num, ");"));
                    int num1 = 0;
                    if (row["eStore"].ToString() == "1")
                    {
                        checkBox8.Checked = true;
                    }
                    if (row["isDisplay"].ToString() == "True")
                    {
                        checkBox.Checked = true;
                        num1 = 1;
                    }
                    if (row["isView"].ToString() == "True")
                    {
                        checkBox1.Checked = true;
                        num1 = 1;
                    }
                    if (row["isAdd"].ToString() == "True")
                    {
                        checkBox2.Checked = true;
                        num1 = 1;
                    }
                    if (row["isDelete"].ToString() == "True")
                    {
                        checkBox3.Checked = true;
                        num1 = 1;
                    }
                    if (row["isArchive"].ToString() == "True")
                    {
                        chkBoxArchive.Checked = true;
                        num1 = 1;
                    }
                    if (row["Others"].ToString() == "1")
                    {
                        checkBox4.Checked = true;
                        num1 = 1;
                    }
                    if (row["PrintorEmail"].ToString() == "1" && row["sectionName"].ToString().ToLower() != "clients")
                    {
                        checkBox5.Checked = true;
                        num1 = 1;
                    }
                    if (row["ExportorImport"].ToString() == "1")
                    {
                        checkBox6.Checked = true;
                        num1 = 1;
                    }
                    if (row["IsRevert"].ToString() == "1")
                    {
                        checkBox7.Checked = true;
                        num1 = 1;
                    }
                    if (row["IsRemove"].ToString() == "1")
                    {
                        checkBox11.Checked = true;
                        num1 = 1;
                    }
                    if (row["sectionName"].ToString().ToLower() == "reports")
                    {
                        int count = dataSet.Tables[1].Rows.Count;
                        checkBox.Attributes.Add("onClick", string.Concat("javascript:ReportCheck(this.id,", count, ");"));
                    }
                    if (row["IsTaskEventCall"].ToString() == "1")
                    {
                        checkBox9.Checked = true;
                        num1 = 1;
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

                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                        this.plh_RolesNew.Controls.Add(chkBoxArchive);
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    }
                    else if (row["sectionName"].ToString().ToLower() != "settings")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:50px;'>&nbsp;</td>"));
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
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
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
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
                    else if (row["sectionName"].ToString().ToLower() == "clients")
                    {
                        if (str.Trim().ToLower() != "true")
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
                    }
                    if (row["IsRevert"].ToString() != "2")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                        this.plh_RolesNew.Controls.Add(checkBox7);
                        this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                    }
                    if (row["IsRemove"].ToString() != "2")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                        this.plh_RolesNew.Controls.Add(checkBox11);
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
                    else
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    }
                    if (row["sectionName"].ToString().ToLower() != "jobs")
                    {
                        this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>&nbsp;</td>"));
                    }
                    Label label = new Label()
                    {
                        ID = string.Concat("lblSelect", num)
                    };
                    if (num1 != 1)
                    {
                        label.Text = this.objlang.GetLanguageConversion("Select_All");
                    }
                    else
                    {
                        label.Text = this.objlang.GetLanguageConversion("Select_None");
                    }
                    label.Attributes.Add("style", "cursor:pointer;");
                    System.Web.UI.AttributeCollection attributes = label.Attributes;
                    object[] lower = new object[] { "javascript:SelectAll_None(this.id,'", row["sectionName"].ToString().ToLower(), "','", num, "');" };
                    attributes.Add("onclick", string.Concat(lower));
                    if (empty.ToLower() != "administrator")
                    {
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
                            this.plh_RolesNew.Controls.Add(new LiteralControl("<td align='center' style='width:70px;'>"));
                            this.plh_RolesNew.Controls.Add(label);
                            this.plh_RolesNew.Controls.Add(new LiteralControl("</td>"));
                        }
                    }
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</tr>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("</table>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));
                    this.plh_RolesNew.Controls.Add(new LiteralControl("<br/>"));
                    roles_edit settingsRoleEdit = this;
                    settingsRoleEdit.HeaderText_Name = string.Concat(settingsRoleEdit.HeaderText_Name, ",", row["sectionName"].ToString());
                    num++;
                }
                this.plh_Reports.Controls.Add(new LiteralControl("<table  cellpadding='3' cellspacing='0'style='width:1050px' border='0' >"));
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
                int num2 = 0;
                foreach (DataRow dataRow in dataSet.Tables[1].Rows)
                {
                    CheckBox checkBox11 = new CheckBox();
                    CheckBox checkBox12 = new CheckBox();
                    checkBox11.ID = string.Concat("chk_ShowReport", num2);
                    checkBox12.ID = string.Concat("chk_ExportReport", num2);
                    if (dataRow["ShowReport"].ToString() == "True")
                    {
                        checkBox11.Checked = true;
                    }
                    if (dataRow["ExportReport"].ToString() == "True")
                    {
                        checkBox12.Checked = true;
                    }
                    foreach (DataRow row1 in dataSet.Tables[0].Rows)
                    {
                        if (!(row1["sectionName"].ToString().ToLower() == "reports") || !(row1["isDisplay"].ToString().ToLower() == "false"))
                        {
                            continue;
                        }
                        checkBox11.Checked = false;
                        checkBox12.Checked = false;
                        checkBox11.Enabled = false;
                        checkBox12.Enabled = false;
                    }
                    num2++;
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
                    roles_edit settingsRoleEdit1 = this;
                    string reportText = settingsRoleEdit1.ReportText;
                    string[] strArrays = new string[] { reportText, ",", dataRow["ReportItems"].ToString(), "~", dataRow["ReportOrderNumber"].ToString() };
                    settingsRoleEdit1.ReportText = string.Concat(strArrays);
                }
                this.plh_Reports.Controls.Add(new LiteralControl("</table>"));
                this.HeaderText_Name = this.HeaderText_Name.Substring(1);
                string headerTextName = string.Concat(this.HeaderText_Name,",DASHBOARD");
                char[] chrArray = new char[] { ',' };
                this.HeaderArray_Name = headerTextName.Split(chrArray);
                this.ReportText = this.ReportText.Substring(1);
                string reportText1 = this.ReportText;
                char[] chrArray1 = new char[] { ',' };
                this.ReportArray = reportText1.Split(chrArray1);
                commonClass _commonClass = new commonClass();
                if (!base.IsPostBack)
                {
                    this.usertypeid = Convert.ToInt32(base.Request.Params["roleid"]);
                    SettingsBasePage.settings_role_select(Convert.ToInt32(this.Session["companyId"].ToString()), Convert.ToInt32(base.Request.Params["roleid"].ToString()), this.txtDescription, this.lblheader);
                    object[] item = new object[] { "crm_common_select_UserType ", this.Session["companyID"], ",", this.usertypeid };
                    SqlCommand sqlCommand = new SqlCommand(string.Concat(item), _commonClass.openConnection());
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader["usertype"].ToString().ToLower() != "administrator")
                        {
                            if (sqlDataReader["usertype"].ToString().ToLower() != "user")
                            {
                                continue;
                            }
                            this.btnDelete.Visible = false;
                            this.btnDelete.Attributes.Add("style", "cursor:not-allowed");
                        }
                        else
                        {
                            this.btnDelete.Visible = false;
                            this.lblMsg2.Visible = true;
                            this.lblMsg2.Attributes.Add("style", "color:#CCC");
                            this.lblMsg2.Text = this.objlang.GetLanguageConversion("Edit_Role_Super_Admin_Note");
                            for (int i = 0; i < num; i++)
                            {
                                CheckBox checkBox13 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_Show", i));
                                checkBox13.Checked = true;
                                checkBox13.Enabled = false;
                                try
                                {
                                    CheckBox checkBox14 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_Read", i));
                                    checkBox14.Checked = true;
                                    checkBox14.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox15 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_AddEdit", i));
                                    checkBox15.Checked = true;
                                    checkBox15.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox16 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_Delete", i));
                                    checkBox16.Checked = true;
                                    checkBox16.Enabled = false;
                                }
                                catch
                                {
                                }
                                // archive
                                try
                                {
                                    CheckBox checkBoxArchive = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_Archive", i));
                                    checkBoxArchive.Checked = true;
                                    checkBoxArchive.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox17 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_Others", i));
                                    checkBox17.Checked = true;
                                    checkBox17.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox18 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_PrintEmail", i));
                                    checkBox18.Checked = true;
                                    checkBox18.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox19 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_ExportImport", i));
                                    checkBox19.Checked = true;
                                    checkBox19.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox20 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_Revert", i));
                                    checkBox20.Checked = true;
                                    checkBox20.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox26 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_Remove", i));
                                    checkBox26.Checked = true;
                                    checkBox26.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox21 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_eStore", i));
                                    checkBox21.Checked = true;
                                    checkBox21.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox22 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_CallTask", i));
                                    checkBox22.Checked = true;
                                    checkBox22.Enabled = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CheckBox checkBox23 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_Forecast", i));
                                    checkBox23.Checked = true;
                                    checkBox23.Enabled = false;
                                }
                                catch
                                {
                                }

                                try
                                {
                                    CheckBox checkBox27 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_ReadDashboard", i));
                                    checkBox27.Checked = true;
                                    checkBox27.Enabled = false;
                                }
                                catch
                                {
                                }

                                try
                                {
                                    CheckBox checkBox28 = (CheckBox)this.plh_RolesNew.FindControl(string.Concat("chk_EditDashboard", i));
                                    checkBox28.Checked = true;
                                    checkBox28.Enabled = false;
                                }
                                catch
                                {
                                }
                            }
                            for (int j = 0; j < num2; j++)
                            {
                                CheckBox checkBox24 = (CheckBox)this.plh_Reports.FindControl(string.Concat("chk_ShowReport", j));
                                checkBox24.Checked = true;
                                checkBox24.Enabled = false;
                                CheckBox checkBox25 = (CheckBox)this.plh_Reports.FindControl(string.Concat("chk_ExportReport", j));
                                checkBox25.Checked = true;
                                checkBox25.Enabled = false;
                            }
                            this.chkShowCostExMarkup.Checked = true;
                            this.chkShowAdditional.Checked = true;
                            this.chkShowCostIncMarkup.Checked = true;
                            this.chkShowProfitMargin.Checked = true;
                            this.chkShowProfitCurrency.Checked = true;
                            this.chkShowSubTotal.Checked = true;
                            this.chkShowTax.Checked = true;
                            this.chkShowSellingPrice.Checked = true;
                            this.chkShowGrossProfitMargin.Checked = true;
                            this.chkShowGrossProfitCurrency.Checked = true;
                            this.chkShowSupplier.Checked = true;
                            this.chkShowPrice.Checked = true;
                            this.ChkShowCalculated.Checked = true;
                            this.ChkShowSubItems.Checked = true;

                            this.chkShowCostExMarkup.Enabled = false;
                            this.chkShowAdditional.Enabled = false;
                            this.chkShowCostIncMarkup.Enabled = false;
                            this.chkShowProfitMargin.Enabled = false;
                            this.chkShowProfitCurrency.Enabled = false;
                            this.chkShowSubTotal.Enabled = false;
                            this.chkShowTax.Enabled = false;
                            this.chkShowSellingPrice.Enabled = false;
                            this.chkShowGrossProfitMargin.Enabled = false;
                            this.chkShowGrossProfitCurrency.Enabled = false;
                            this.chkShowSupplier.Enabled = false;
                            this.chkShowPrice.Enabled = false;
                            this.ChkShowCalculated.Enabled = false;
                            this.ChkShowSubItems.Enabled = false;
                        }
                    }
                    sqlDataReader.Close();
                    _commonClass.closeConnection();
                }
                this.btnDelete.Attributes.Add("onclick", "javascript:var a= window.confirm('Are you sure,you want to delete this role?');if(a)loadingimg('div_btndelete','div_deleteprocess');return a;");
                string str1 = string.Empty;
                str1 = this.lblheader.Text.Replace("Edit ", "");
                this.txtrole.Text = base.SpecialDecode(str1.Replace("Role", ""));
                this.txtrole.ReadOnly = true;
                this.txtrole.Attributes.Add("style", "color:#CCC");
            }
        }

        public void BindDefaultRolesandPrivileges()
        {
            this.btnDeleteDefault.Text = this.objlang.GetValueOnLang("Delete");
            this.btnSave.Text = this.objlang.GetValueOnLang("Save");
            this.btnCancel.Text = this.objlang.GetValueOnLang("Back");
            bool isPostBack = base.IsPostBack;
            this.strImagepath = global.imagePath();
            this.companyId = int.Parse(this.Session["companyid"].ToString());
            this.userId = int.Parse(this.Session["userid"].ToString());
            this.usertypeid = Convert.ToInt32(base.Request.Params["roleid"]);
            base.Title = this.objLanguage.convert(global.pageTitle("Edit Role", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/user_manager.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Roles_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Roles_Edit")));
            base.Title = this.objLanguage.convert(global.pageTitle("Roles Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand(string.Concat("crm_select_user_role_New ", this.Session["companyID"]), _commonClass.openConnection());
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                roles_edit settingsRoleEdit = this;
                settingsRoleEdit.HeaderText = string.Concat(settingsRoleEdit.HeaderText, ",", sqlDataReader["sectionName"].ToString());
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
            this.plhaddusertype.Controls.Add(new LiteralControl("<table id=Table1 cellspacing=1 cellpadding=2 width=33% align=left border=0>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("<tr valign=top height=23><td style=width:2px></td>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("<td width=20% class='bgcustomize navigatorpanel' nowrap>"));
            this.plhaddusertype.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Sections")));
            this.plhaddusertype.Controls.Add(new LiteralControl("</td>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("<td width=10% class='bgcustomize navigatorpanel' align=center nowrap>"));
            this.plhaddusertype.Controls.Add(new LiteralControl(this.objLanguage.GetLanguageConversion("Show_Tab")));
            this.plhaddusertype.Controls.Add(new LiteralControl("</td>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("<td width=27%></td>"));
            this.plhaddusertype.Controls.Add(new LiteralControl("</tr>"));
            commonClass _commonClass1 = new commonClass();
            object[] item = new object[] { "crm_Default_RolesAndPrivileges_select ", this.Session["companyID"], ",", this.usertypeid };
            SqlCommand sqlCommand1 = new SqlCommand(string.Concat(item), _commonClass1.openConnection());
            SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            int num = 0;
            while (sqlDataReader1.Read())
            {
                int num1 = 0;
                this.plhaddusertype.Controls.Add(new LiteralControl("<tr><td style=width:2px></td>"));
                this.plhaddusertype.Controls.Add(new LiteralControl("<td width=20% class=rtBody nowrap>"));
                string str = base.ReturnScreenName(sqlDataReader1["sectionName"].ToString().ToUpper(), 2, "p");
                if (str.ToLower() == "crm")
                {
                    str = "CRM";
                }
                this.plhaddusertype.Controls.Add(new LiteralControl(base.SpecialDecode(str)));
                this.plhaddusertype.Controls.Add(new LiteralControl("</td>"));
                this.plhaddusertype.Controls.Add(new LiteralControl("<td width=10% align=center class=rtBody nowrap>"));
                if (sqlDataReader1["sectionName"].ToString().ToLower() != "home")
                {
                    CheckBox checkBox = new CheckBox();
                    if (sqlDataReader1["isdisplay"].ToString().ToLower() != "true")
                    {
                        num1++;
                    }
                    else
                    {
                        checkBox.Checked = true;
                        num1++;
                    }
                    checkBox.ID = string.Concat("chktab_", num);
                    checkBox.Attributes.Add("onclick", string.Concat("javascript:CheckFunctionalites(this,'", num, "');"));
                    this.plhaddusertype.Controls.Add(checkBox);
                }
                else
                {
                    this.plhaddusertype.Controls.Add(global.GetTickImage("ImgTab"));
                }
                this.plhaddusertype.Controls.Add(new LiteralControl("</td>"));
                this.plhaddusertype.Controls.Add(new LiteralControl("<td width=27%></td>"));
                this.plhaddusertype.Controls.Add(new LiteralControl("</tr>"));
                if (sqlDataReader1["sectionName"].ToString().ToLower() == "home")
                {
                    continue;
                }
                num++;
            }
            _commonClass1.closeConnection();
            this.plhaddusertype.Controls.Add(new LiteralControl("</table>"));
            this.gloobj.setpagename("setting");
            if (!base.IsPostBack)
            {
                SettingsBasePage.settings_role_select(Convert.ToInt32(this.Session["companyId"].ToString()), Convert.ToInt32(base.Request.Params["roleid"].ToString()), this.txtDescription, this.lblheader);
                object[] objArray = new object[] { "crm_common_select_UserType ", this.Session["companyID"], ",", this.usertypeid };
                SqlCommand sqlCommand2 = new SqlCommand(string.Concat(objArray), _commonClass1.openConnection());
                SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                while (sqlDataReader2.Read())
                {
                    if (sqlDataReader2["usertype"].ToString().ToLower() == "administrator")
                    {
                        this.btnSave.Attributes.Add("style", "cursor:not-allowed");
                        this.btnSave.Visible = false;
                        this.btnDeleteDefault.Visible = false;
                        this.div_delcan.Visible = false;
                        this.lblMsg.Visible = true;
                        this.lblMsg.Attributes.Add("style", "color:#CCC");
                        this.lblMsg.Text = "[This is the default super admin access to the system and hence cannot be changed]";
                        this.chkbxSpecialPrivileges.Enabled = false;
                        for (int i = 0; i < num; i++)
                        {
                            CheckBox checkBox1 = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chktab_", i));
                            checkBox1.Checked = true;
                            checkBox1.Enabled = false;
                        }
                    }
                    else if (sqlDataReader2["usertype"].ToString().ToLower() == "user")
                    {
                        this.btnDeleteDefault.Visible = false;
                        this.btnDeleteDefault.Attributes.Add("style", "cursor:not-allowed");
                    }
                    if (sqlDataReader2["isSpecialPrivilege"].ToString().ToLower() != "true")
                    {
                        this.chkbxSpecialPrivileges.Checked = false;
                    }
                    else
                    {
                        this.chkbxSpecialPrivileges.Checked = true;
                    }
                }
                sqlDataReader2.Close();
                _commonClass1.closeConnection();
            }
            this.btnDeleteDefault.Attributes.Add("onclick", "javascript:var a= window.confirm('Are you sure,you want to delete this role?');if(a)loadingimg('div_btndelete_default','div_deleteprocess_default');return a;");
            string empty = string.Empty;
            empty = this.lblheader.Text.Replace("Edit ", "");
            this.txtrole.Text = base.SpecialDecode(empty.Replace("Role", ""));
            this.txtrole.ReadOnly = true;
            this.txtrole.Attributes.Add("style", "color:#CCC");
        }

        protected void btn_UpdateRole_OnClick(object sender, EventArgs e)
        {
            CheckBox checkBox;
            DbSettings dbSetting = new DbSettings();
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
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string text = string.Empty;
            if (this.chkShowCostExMarkup.Checked)
            {
                flag = true;
                flag1 = true;
            }
            if (this.chkShowAdditional.Checked)
            {
                flag11 = true;
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
                flag10 = true;
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
                    for (int i = 0; i < this.lstBxType.Items.Count; i++)
                    {
                        if (this.lstBxType.Items[i].Selected)
                        {
                            empty1 = string.Concat(empty1, this.lstBxType.Items[i].Value.ToString(), ",");
                        }
                    }
                }
            }
            if (this.rdoHisRecords.Checked)
            {
                str = "His";
            }
            else if (this.rdoOtherRecords.Checked)
            {
                str = "Other";
            }
            string text1 = this.txtRestrict.Text;
            if (this.rdoSingleIP.Checked)
            {
                empty2 = "S";
                text = this.txtSingleIP.Text; 
            }
            else if (this.rdoMultipleIP.Checked)
            {
                empty2 = "M";
                text = this.txtMultipleIP.Text;
            }
            else if (this.rdoRangeIP.Checked)
            {
                empty2 = "R";
                text = string.Concat(this.txtFromIP.Text, ",", this.txtToIP.Text);
            }
            base.SpecialEncode(this.txtrole.Text);
            string str2 = base.SpecialEncode(this.txtDescription.Text);
            SettingsBasePage.Roles_StaticCheckBox_Update(Convert.ToInt64(base.Request.Params["roleid"]), Convert.ToInt16(this.Session["CompanyID"].ToString()), str2, flag, flag1, flag2, flag3, flag4, flag5, flag6, flag7, flag8, flag9, showSupplierName, showPrice, showCalculated, showSubItems, this.txtLock.Text, this.txtForce.Text, base.SpecialEncode(this.txtRestrict.Text), flag10, empty, str, empty1, empty2, text, chkLocking.Checked, chkIgnoreLocking.Checked,flag11);
            for (int j = 0; j < (int)this.HeaderArray_Name.Length; j++)
            {
                string str3 = this.HeaderArray_Name[j].ToString();
                DataTable dataTable = new DataTable();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_role_plhIndividual_Edit_New");
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, Convert.ToInt64(this.Session["CompanyID"].ToString()));
                database.AddInParameter(storedProcCommand, "@sectionName", DbType.String, str3);
                database.AddInParameter(storedProcCommand, "@RoleID", DbType.Int64, Convert.ToInt64(base.Request.Params["roleid"]));
                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                }
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int isArchive = 0;
                string str4 = "0";
                string str5 = "0";
                string str6 = "0";
                string str7 = "0";
                string str8 = "0";
                string str9 = "0";
                string str10 = "0";
                try
                {
                    checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Read", j));
                    if (checkBox.Checked)
                    {
                        num = 1;
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
                        num1 = 1;
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
                        num2 = 1;
                    }
                }
                catch
                {
                }
                try
                {
                    checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Archive", j));
                    if (checkBox.Checked)
                    {
                        isArchive = 1;
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
                        num3 = 1;
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
                                str4 = "1";
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        str4 = "2";
                    }
                    if (dataTable.Rows[0]["PrintorEmail"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_PrintEmail", j));
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
                    if (dataTable.Rows[0]["ExportorImport"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_ExportImport", j));
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
                    if (dataTable.Rows[0]["IsRevert"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Revert", j));
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
                    if (dataTable.Rows[0]["IsRemove"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Remove", j));
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
                    if (dataTable.Rows[0]["IsTaskEventCall"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_CallTask", j));
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
                    if (dataTable.Rows[0]["IsForecast"].ToString() != "2")
                    {
                        try
                        {
                            checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Forecast", j));
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
                }//KR
                commonClass _commonClass = new commonClass();
                object[] item = new object[] { "crm_common_select_UserType ", this.Session["companyID"], ",", Convert.ToInt64(base.Request.Params["roleid"]) };
                SqlCommand sqlCommand = new SqlCommand(string.Concat(item), _commonClass.openConnection());
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader["usertype"].ToString().ToLower() != "administrator")
                    {
                        continue;
                    }
                    num = 1;
                    num1 = 1;
                    num2 = 1;
                    num3 = 1;
                    isArchive = 1;
                }
                if (str3.ToLower() == "campaign" || str3.ToLower() == "digitalasset" || str3.ToLower() == "reports")
                {
                    if (num3 == 1)
                    {
                        num1 = 1;
                        num = 1;
                        num2 = 1;
                        isArchive = 1;
                    }
                    SettingsBasePage.Roles_AccessDetails_Update(Convert.ToInt64(base.Request.Params["roleid"]), str3, num1, num, num2, isArchive, num3, str4, str5, str6, str7, Convert.ToInt64(this.Session["CompanyID"].ToString()), str8, str9, str10);
                }
                else if (str3.ToLower() != "settings")
                {
                    SettingsBasePage.Roles_AccessDetails_Update(Convert.ToInt64(base.Request.Params["roleid"]), str3, num1, num, num2, isArchive, num3, str4, str5, str6, str7, Convert.ToInt64(this.Session["CompanyID"].ToString()), str8, str9, str10);
                }
                else
                {
                    checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_Show", j));
                    if (checkBox.Checked)
                    {
                        num3 = 1;
                        num1 = 1;
                        num = 1;
                        num2 = 1;
                    }
                    SettingsBasePage.Roles_AccessDetails_Update(Convert.ToInt64(base.Request.Params["roleid"]), "Settings", num1, num, num2,isArchive, num3, str4, str5, str6, str7, Convert.ToInt64(this.Session["CompanyID"].ToString()), str8, str9, str10);
                    checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chk_eStore", j));
                    if (ConnectionClass.WebStore.ToLower() == "yes")
                    {
                        if (!checkBox.Checked)
                        {
                            num3 = 0;
                            num1 = 0;
                            num = 0;
                            num2 = 0;
                        }
                        else
                        {
                            num3 = 1;
                            num1 = 1;
                            num = 1;
                            num2 = 1;
                        }
                    }
                    SettingsBasePage.Roles_AccessDetails_Update(Convert.ToInt64(base.Request.Params["roleid"]), "eStore", num1, num, num2, isArchive, num3, str4, str5, str6, str7, Convert.ToInt64(this.Session["CompanyID"].ToString()), str8, str9, str10);
                }
                if(str3.ToLower() == "dashboard")
                {
                    try
                    {
                        checkBox = (CheckBox)this.plhaddusertype.FindControl("chk_ReadDashboard0");
                        if (checkBox.Checked)
                        {
                            num = 1;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        checkBox = (CheckBox)this.plhaddusertype.FindControl("chk_EditDashboard0");
                        if (checkBox.Checked)
                        {
                            num1 = 1;
                        }
                    }
                    catch
                    {
                    }
                    SettingsBasePage.Roles_AccessDetails_Update(Convert.ToInt64(base.Request.Params["roleid"]),str3, num1, num, num2, isArchive, num3, str4, str5, str6, str7, Convert.ToInt64(this.Session["CompanyID"].ToString()), str8, str9, str10);
                }
            }
            Database database1 = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable1 = new DataTable();
            DbCommand dbCommand = database1.GetStoredProcCommand("PC_settings_UserTab_UserID");
            database1.AddInParameter(dbCommand, "@UsertypeID", DbType.Int64, Convert.ToInt64(base.Request.Params["roleid"]));
            using (IDataReader dataReader1 = database1.ExecuteReader(dbCommand))
            {
                dataTable1.Load(dataReader1);
            }
            foreach (DataRow row in dataTable1.Rows)
            {
                Database database2 = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand1 = database2.GetStoredProcCommand("PC_settings_UserTab_Update");
                database2.AddInParameter(storedProcCommand1, "@UserTypeID", DbType.Int64, Convert.ToInt64(base.Request.Params["roleid"]));
                database2.AddInParameter(storedProcCommand1, "@UserID", DbType.Int64, Convert.ToInt64(row["UserID"].ToString()));
                database2.ExecuteNonQuery(storedProcCommand1);
            }
            CheckBox checkBox1 = new CheckBox();
            for (int k = 0; k < (int)this.ReportArray.Length; k++)
            {
                string[] strArrays = this.ReportArray[k].ToString().Split(new char[] { '~' });
                string str10 = strArrays[0].ToString();
                string str11 = strArrays[1].ToString();
                int num4 = 0;
                int num5 = 0;
                if (((CheckBox)this.plh_Reports.FindControl(string.Concat("chk_ShowReport", k))).Checked)
                {
                    num4 = 1;
                }
                if (((CheckBox)this.plh_Reports.FindControl(string.Concat("chk_ExportReport", k))).Checked)
                {
                    num5 = 1;
                }
                SettingsBasePage.Roles_ReportDetails_Update(Convert.ToInt64(base.Request.Params["roleid"]), num4, num5, Convert.ToInt64(this.Session["CompanyID"].ToString()), str10, Convert.ToInt16(str11));
            }
            base.Response.Redirect("user_manager.aspx?Su=up");
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            commonClass _commonClass = new commonClass();
            object[] item = new object[] { "PC_settings_user_select_Byrole ", this.Session["companyID"], ",", this.usertypeid };
            SqlCommand sqlCommand = new SqlCommand(string.Concat(item), _commonClass.openConnection());
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                empty = string.Concat(empty, sqlDataReader["firstname"].ToString(), ",");
            }
            _commonClass.closeConnection();
            if (empty != "")
            {
                empty = empty.Substring(0, empty.Length - 1);
                base.Response.Write(string.Concat("<script>alert('Can not delete this role.Its being used for user: ", empty, "');</script>"));
                return;
            }
            commonClass _commonClass1 = new commonClass();
            object[] objArray = new object[] { "PC_settings_role_delete_New ", this.Session["companyID"], ",", this.usertypeid };
            SqlCommand sqlCommand1 = new SqlCommand(string.Concat(objArray), _commonClass1.openConnection());
            sqlCommand1.ExecuteNonQuery();
            _commonClass1.closeConnection();
            base.Response.Redirect("user_manager.aspx?Su=de");
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            object[] item = new object[] { "crm_Default_RolesAndPrivileges_select ", this.Session["companyID"], ",", this.usertypeid };
            SqlCommand sqlCommand = new SqlCommand(string.Concat(item), _commonClass.openConnection());
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string str = base.SpecialEncode(this.txtDescription.Text);
            int num = 0;
            while (sqlDataReader.Read())
            {
                string str1 = sqlDataReader["sectionname"].ToString();
                string empty = string.Empty;
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                bool flag = false;
                if (str1.ToLower() == "home")
                {
                    continue;
                }
                CheckBox checkBox = (CheckBox)this.plhaddusertype.FindControl(string.Concat("chktab_", num));
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                if (str1.ToLower() == "clients")
                {
                    if (!checkBox.Checked)
                    {
                        empty = "0";
                        empty1 = "0";
                        empty2 = "2";
                        str2 = "2";
                    }
                    else
                    {
                        empty = "1";
                        empty1 = "1";
                        empty2 = "2";
                        str2 = "2";
                    }
                }
                else if (str1.ToLower() == "estimates")
                {
                    if (!checkBox.Checked)
                    {
                        empty = "0";
                        empty1 = "0";
                        empty2 = "2";
                        str2 = "2";
                    }
                    else
                    {
                        empty = "1";
                        empty1 = "1";
                        empty2 = "2";
                        str2 = "2";
                    }
                }
                else if (str1.ToLower() == "jobs")
                {
                    if (!checkBox.Checked)
                    {
                        empty = "0";
                        empty1 = "0";
                        empty2 = "2";
                        str2 = "0";
                    }
                    else
                    {
                        empty = "1";
                        empty1 = "1";
                        empty2 = "2";
                        str2 = "1";
                    }
                }
                else if (str1.ToLower() == "campaign")
                {
                    empty = "2";
                    empty1 = "2";
                    empty2 = "2";
                    str2 = "2";
                }
                else if (str1.ToLower() == "purchases")
                {
                    if (!checkBox.Checked)
                    {
                        empty = "0";
                        empty1 = "0";
                        empty2 = "2";
                        str2 = "2";
                    }
                    else
                    {
                        empty = "1";
                        empty1 = "1";
                        empty2 = "2";
                        str2 = "2";
                    }
                }
                else if (str1.ToLower() == "invoices")
                {
                    if (!checkBox.Checked)
                    {
                        empty = "0";
                        empty1 = "0";
                        empty2 = "2";
                        str2 = "2";
                    }
                    else
                    {
                        empty = "1";
                        empty1 = "1";
                        empty2 = "2";
                        str2 = "2";
                    }
                }
                else if (str1.ToLower() == "warehouse")
                {
                    if (!checkBox.Checked)
                    {
                        empty = "0";
                        empty1 = "2";
                        empty2 = "0";
                        str2 = "2";
                    }
                    else
                    {
                        empty = "1";
                        empty1 = "2";
                        empty2 = "1";
                        str2 = "2";
                    }
                }
                else if (str1.ToLower() == "documents")
                {
                    empty = "2";
                    empty1 = "2";
                    empty2 = "2";
                    str2 = "2";
                }
                else if (str1.ToLower() == "reports")
                {
                    if (!checkBox.Checked)
                    {
                        commonClass _commonClass1 = new commonClass();
                        SqlCommand sqlCommand1 = new SqlCommand("PC_settings_role_Default_Reports_Update", _commonClass1.openConnection())
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
                        SqlCommand sqlCommand2 = new SqlCommand("PC_settings_role_Default_Reports_Update", _commonClass2.openConnection())
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
                    str2 = "2";
                }
                else if (str1.ToLower() == "deliverynote")
                {
                    if (!checkBox.Checked)
                    {
                        empty = "2";
                        empty1 = "0";
                        empty2 = "2";
                        str2 = "2";
                    }
                    else
                    {
                        empty = "2";
                        empty1 = "1";
                        empty2 = "2";
                        str2 = "2";
                    }
                }
                else if (str1.ToLower() == "proofs")
                {
                    if (!checkBox.Checked)
                    {
                        empty = "2";
                        empty1 = "0";
                        empty2 = "2";
                        str2 = "2";
                    }
                    else
                    {
                        empty = "2";
                        empty1 = "1";
                        empty2 = "2";
                        str2 = "2";
                    }
                }
                else if (str1.ToLower() == "settings")
                {
                    flag = true;
                    empty = "2";
                    empty1 = "2";
                    empty2 = "2";
                    str2 = "2";
                }
                else if (str1.ToLower() != "productcatalogue")
                {
                    empty = "2";
                    empty1 = "2";
                    empty2 = "2";
                    str2 = "2";
                }
                else
                {
                    empty = "2";
                    empty1 = "2";
                    empty2 = "2";
                    str2 = "2";
                }
                if (checkBox.Checked)
                {
                    num1 = 1;
                    num2 = 1;
                    num3 = 1;
                    num4 = 1;
                    num6 = 1;
                }
                SettingsBasePage.common_update_accessrights_New((long)this.companyId, (long)this.usertypeid, str1, num1, num2, num3, num4, num6, num5, empty, empty1, empty2, str2, str);
                if (flag)
                {
                    SettingsBasePage.common_update_accessrights_New((long)this.companyId, (long)this.usertypeid, "eStore", num1, num2, num3, num4, num6, num5, empty, empty1, empty2, str2, str);
                }
                num++;
            }
            _commonClass.closeConnection();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_UserTab_UserID");
            database.AddInParameter(storedProcCommand, "@UsertypeID", DbType.Int64, Convert.ToInt64(base.Request.Params["roleid"]));
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                Database database1 = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand dbCommand = database1.GetStoredProcCommand("PC_settings_UserTab_Update");
                database1.AddInParameter(dbCommand, "@UserTypeID", DbType.Int64, Convert.ToInt64(base.Request.Params["roleid"]));
                database1.AddInParameter(dbCommand, "@UserID", DbType.Int64, Convert.ToInt64(row["UserID"].ToString()));
                database1.ExecuteNonQuery(dbCommand);
            }
            SqlCommand sqlCommand3 = new SqlCommand("PC_Settings_UserType_SpecialPrivilege_Insert", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand3.Parameters.AddWithValue("@UsertypeID", this.usertypeid);
            sqlCommand3.Parameters.AddWithValue("@CompanyID", this.companyId);
            if (!this.chkbxSpecialPrivileges.Checked)
            {
                sqlCommand3.Parameters.AddWithValue("@isSpecialPrivilege", false);
            }
            else
            {
                sqlCommand3.Parameters.AddWithValue("@isSpecialPrivilege", true);
            }
            sqlCommand3.ExecuteNonQuery();
            _commonClass.closeConnection();
            base.Response.Redirect("user_manager.aspx?Su=up");
        }

        public void CheckBox_Edit(long RoleID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_CheckBox_Edit_New");
            database.AddInParameter(storedProcCommand, "@RoleID", DbType.Int64, RoleID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["isDelete"].ToString() != "True")
                {
                    if (row["showCostExMarkup"].ToString() == "True")
                    {
                        this.chkShowCostExMarkup.Checked = true;
                    }
                    if (row["showAdditional"].ToString() == "True")
                    {
                        this.chkShowAdditional.Checked = true;
                    }
                    if (row["showCostIncMarkup"].ToString() == "True")
                    {
                        this.chkShowCostIncMarkup.Checked = true;
                    }
                    if (row["showProfitMargin"].ToString() == "True")
                    {
                        this.chkShowProfitMargin.Checked = true;
                    }
                    if (row["showProfitInCurrency"].ToString() == "True")
                    {
                        this.chkShowProfitCurrency.Checked = true;
                    }
                    if (row["showSubTotal"].ToString() == "True")
                    {
                        this.chkShowSubTotal.Checked = true;
                    }
                    if (row["showTax"].ToString() == "True")
                    {
                        this.chkShowTax.Checked = true;
                    }
                    if (row["showSellingPrice"].ToString() == "True")
                    {
                        this.chkShowSellingPrice.Checked = true;
                    }
                    if (row["showGrossProfitMargin"].ToString() == "True")
                    {
                        this.chkShowGrossProfitMargin.Checked = true;
                    }
                    if (row["showSupplierName"].ToString() == "True")
                    {
                        this.chkShowSupplier.Checked = true;
                    }
                    if (row["showPrice"].ToString() == "True")
                    {
                        this.chkShowPrice.Checked = true;
                    }
                    if (row["showCalculated"].ToString() == "True")
                    {
                        this.ChkShowCalculated.Checked = true;
                    }
                    if (row["showSubItems"].ToString() == "True")
                    {
                        this.ChkShowSubItems.Checked = true;
                    }
                    if (row["showGrossProfit"].ToString() == "True")
                    {
                        this.chkShowGrossProfitCurrency.Checked = true;
                    }
                    if (row["ShowRecords"].ToString() == "")
                    {
                        this.rdoShowAll.Checked = true;
                        this.lstBxType.Enabled = false;
                    }
                    else if (row["ShowRecords"].ToString() == "All")
                    {
                        this.rdoShowAll.Checked = true;
                        this.lstBxType.Attributes.Add("disabled", "true");
                    }
                    else if (row["ShowRecords"].ToString() == "Allocation")
                    {
                        this.rdoShowAllocation.Checked = true;
                        this.lstBxType.Attributes.Add("disabled", "true");
                    }
                    else if (row["ShowRecords"].ToString() == "Type")
                    {
                        this.rdoShowType.Checked = true;
                        this.lstBxType.Enabled = true;
                        System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:ShowTypeList();", true);
                        if (row["CompanyType"].ToString() != null)
                        {
                            string[] strArrays = row["CompanyType"].ToString().Split(new char[] { ',' });
                            for (int i = 0; i < this.lstBxType.Items.Count; i++)
                            {
                                for (int j = 0; j < (int)strArrays.Length - 1; j++)
                                {
                                    if (this.lstBxType.Items[i].Value == strArrays[j].ToString())
                                    {
                                        this.lstBxType.Items[i].Selected = true;
                                    }
                                }
                            }
                        }
                    }
                    if (row["EditRecords"].ToString() == "")
                    {
                        this.rdoOtherRecords.Checked = true;
                    }
                    else if (row["EditRecords"].ToString() == "His")
                    {
                        this.rdoHisRecords.Checked = true;
                    }
                    else if (row["EditRecords"].ToString() == "Other")
                    {
                        this.rdoOtherRecords.Checked = true;
                    }
                    this.txtLock.Text = row["unSuccessfulLoginAttemptCount"].ToString();
                    this.txtForce.Text = row["changePWDAfterSelectedDays"].ToString();
                    this.chkLocking.Checked = Convert.ToBoolean(row["Locking"]);
                    this.chkIgnoreLocking.Checked = Convert.ToBoolean(row["IgnoreLock"]);

                    if (row["restrictSystemIPforUnauthorizedEmailAccess"].ToString() != "" || row["IPAddressType"].ToString() != "")
                    {
                        this.txtRestrict.Text = row["restrictSystemIPforUnauthorizedEmailAccess"].ToString();
                        if (row["IPAddressType"].ToString() == "")
                        {
                            continue;
                        }
                        if (row["IPAddressType"].ToString() == "S")
                        {
                            this.rdoSingleIP.Checked = true;
                            this.txtSingleIP.Enabled = true;
                            this.txtSingleIP.Text = row["IPAddressList"].ToString();
                        }
                        else if (row["IPAddressType"].ToString() != "M")
                        {
                            if (row["IPAddressType"].ToString() != "R")
                            {
                                continue;
                            }
                            this.rdoRangeIP.Checked = true;
                            string[] strArrays1 = row["IPAddressList"].ToString().Split(new char[] { ',' });
                            this.txtFromIP.Enabled = true;
                            this.txtToIP.Enabled = true;
                            this.txtFromIP.Text = strArrays1[0].ToString();
                            this.txtToIP.Text = strArrays1[1].ToString();
                        }
                        else
                        {
                            this.rdoMultipleIP.Checked = true;
                            this.txtMultipleIP.Enabled = true;
                            this.txtMultipleIP.Text = row["IPAddressList"].ToString();
                        }
                    }
                    else
                    {
                        this.txtRestrict.Text = row["restrictSystemIPforUnauthorizedEmailAccess"].ToString();
                    }
                }
                else
                {
                    this.btn_UpdateRole.Visible = false;
                    this.btnDelete.Visible = false;
                    base.Message_Display("Role has been deleted", "msg-fail", this.plhMessage);
                    this.RoleStatus = "RoleDeleted";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("setting");
            if (!base.IsPostBack)
            {
                DataTable dataTable = new DataTable();
                dataTable = Settings.settings_CompanyType_select(Convert.ToInt16(this.Session["CompanyID"].ToString()));
                this.lstBxType.DataSource = dataTable;
                this.lstBxType.DataTextField = "companytype";
                this.lstBxType.DataValueField = "id";
                this.lstBxType.DataBind();
                this.CheckBox_Edit(Convert.ToInt64(base.Request.Params["roleid"]));
            }
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Back");
            this.btnDeleteDefault.Text = this.objlang.GetLanguageConversion("Delete");
            this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
            this.revSingleIPAddress.ErrorMessage = this.objlang.GetLanguageConversion("Please_enter_a_valid_IP_Address");
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
                if (Convert.ToInt64(base.Request.Params["roleid"]) == (long)0)
                {
                    base.Response.Redirect("user_manager.aspx");
                }
                else if (dataTable1.Rows[0]["IsCustomAccessRight"].ToString() != "True")
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