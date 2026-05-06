using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.Templates
{
    public partial class settingpage : MasterPage
    {
        private string _callbackResult;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string pg;

        public string pgDetailname;

        public string color = string.Empty;

        public string colorformat = string.Empty;

        public int height;

        public string width = string.Empty;

        public languageClass objLanguage = new languageClass();

        private BaseClass objbase = new BaseClass();

        public BasePage objpage = new BasePage();

        public string tabcolor = string.Empty;

        public string forecolor = "";

        public int companyid;

        public string roundoff = string.Empty;

        public string WebStore = string.Empty;

        public string MYOB = string.Empty;

        public string SAASU = string.Empty;

        public string SageOne = string.Empty;

        public string Sage50 = string.Empty;

        public string Sage50Business = string.Empty;

        public string ReckonHosted = string.Empty;

        public string Quickbooks_Online = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string TabSelection = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public string AccountingExport = ConnectionClass.AccountingExport;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string EditableTemplate = ConnectionClass.EditableTemplate;

        public static int ManageStockPermission;

        public bool Is_Non_Printing_System = ConnectionClass.Is_Non_Printing_System;

        public string GetAccountingCode = string.Empty;

        public string GetMYOB = string.Empty;

        public string GetSAASU = string.Empty;

        public string GetSageOne = string.Empty;

        public string GetSage50 = string.Empty;

        public string GetQuickbooks_Online = string.Empty;

        public string GetXERO = string.Empty;

        //public string GetXERO2 = string.Empty;

        private BasePage obj = new BasePage();

        public DataSet Template_Names;

        public string NavisionExport = ConnectionClass.NavisionExport;

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

        static settingpage()
        {
        }

        public settingpage()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString().ToLower().IndexOf("dmcsportonline") != -1)
            {
                bool flag = false;
                string lower = base.Request.Url.ToString().ToLower();
                if (lower.ToString().ToLower().IndexOf("https") == -1)
                {
                    lower = lower.Replace("http", "https");
                    flag = true;
                }
                if (lower.ToString().ToLower().IndexOf("https://dmcsportonline.com.au") != -1)
                {
                    lower = lower.Replace("https://dmcsportonline.com.au", "https://www.dmcsportonline.com.au");
                    flag = true;
                }
                if (flag)
                {
                    base.Response.Redirect(lower);
                }
            }
            if (base.Session["CompanyID"] != null)
            {
                string str = string.Concat(ConnectionClass.faviconpath, base.Session["CompanyID"].ToString(), "/favicon.ico");
                this.Head1.Controls.Add(new LiteralControl(string.Concat("<link rel='shortcut icon' href='", str, "'>")));
            }
            if (base.Session["companyID"] != null)
            {
                this.companyid = int.Parse(base.Session["companyID"].ToString());
            }
            else
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "error.aspx"));
            }
            if (commonClass.CheckProofPermission())
            {
                if(objbase.GetUserRolePrivilege("proofs","isdisplay") == "true")
                {
                    this.li33.Visible = true;
                }
            }
            else
            {
                this.li33.Visible = false;
            }
            if (commonClass.CheckFTPEnable())
            {
                this.li41.Visible = true;
            }
            else
            {
                this.li41.Visible = false;
            }
            DataTable dataTable = SettingsBasePage.settings_companyprofile_select(this.companyid);
            if (dataTable.Rows.Count > 0)
            {
                settingpage.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
            }
            this.lbltxt.Text = this.objLanguage.GetLanguageConversion("ePrint_MIS");
            if (settingpage.ManageStockPermission == 1)
            {
                this.li_productcatalogue.Style.Add("display", "block");
            }
            if (ConnectionClass.IsmailChimpEnabled.ToLower() == "true")
            {
                this.li_MailChimp.Style.Add("display", "block");
            }
            if (ConnectionClass.MYOB != null)
            {
                this.MYOB = ConnectionClass.MYOB.ToString();
                if (this.MYOB.ToString().ToLower() != "true")
                {
                    this.li17.Attributes.Add("style", " display:none");
                    this.GetMYOB = "false";
                }
                else
                {
                    this.li17.Attributes.Add("style", " display:block");
                    if (ConnectionClass.MYOBAPI.ToString().ToLower() != "true")
                    {
                        this.myobapi.HRef = string.Concat(this.strSitepath, "Settings/MYOBAccounting.aspx");
                    }
                    else
                    {
                        this.myobapi.HRef = string.Concat(this.strSitepath, "Settings/MYOBAccounting_Export.aspx");
                    }
                }
            }

            // test code for saasu
            if (ConnectionClass.SAASU != null)
            {
                this.SAASU = ConnectionClass.SAASU.ToString();
                if (this.SAASU.ToString().ToLower() != "true")
                {
                    this.li_saasu.Attributes.Add("style", " display:none");
                    this.GetSAASU = "false";
                }
                else
                {
                    this.li_saasu.Attributes.Add("style", " display:block");
                    if (ConnectionClass.SAASUAPI.ToString().ToLower() != "true")
                    {
                        this.SAASUAPI.HRef = string.Concat(this.strSitepath, "Settings/SAASU_Accounting.aspx");
                    }
                    else
                    {
                        this.SAASUAPI.HRef = string.Concat(this.strSitepath, "Settings/SAASU_Accounting.aspx");
                    }
                }
            }

            if (ConnectionClass.SageOne != null)
            {
                this.SageOne = ConnectionClass.SageOne.ToString();
                if (this.SageOne.ToString().ToLower() != "true")
                {
                    this.li_SageExport.Visible = false;
                    //this.li_SageExport.Attributes.Add("style", " display:none");
                    this.GetSageOne = "false";
                }
                else
                {
                    this.li_SageExport.Visible = true;
                    //this.li_SageExport.Attributes.Add("style", " display:block");

                }
            }

            if (ConnectionClass.Sage50 != null)
            {
                this.Sage50 = ConnectionClass.Sage50.ToString();
                if (this.Sage50.ToString().ToLower() != "true")
                {
                    this.li_Sage50Export.Visible = false;
                    //this.li_SageExport.Attributes.Add("style", " display:none");
                    this.Sage50 = "false";
                }
                else
                {
                    this.li_Sage50Export.Visible = true;
                    //this.li_SageExport.Attributes.Add("style", " display:block");

                }
            }


            if (ConnectionClass.Quickbooks_Online != null)
            {
                this.Quickbooks_Online = ConnectionClass.Quickbooks_Online.ToString();
                if (this.Quickbooks_Online.ToString().ToLower() != "true")
                {
                    this.li_Quickbooks_Online.Visible = false;
                    //this.li_SageExport.Attributes.Add("style", " display:none");
                    this.Quickbooks_Online = "false";
                }
                else
                {
                    this.li_Quickbooks_Online.Visible = true;
                    //this.li_SageExport.Attributes.Add("style", " display:block");

                }
            }

            if (ConnectionClass.Sage50Business != null)
            {
                this.Sage50Business = ConnectionClass.Sage50Business.ToString();
                if (this.Sage50Business.ToString().ToLower() != "true")
                {
                    this.li_Sage50BusinessExport.Visible = false;
                    //this.li_SageExport.Attributes.Add("style", " display:none");
                    this.Sage50Business = "false";
                }
                else
                {
                    this.li_Sage50BusinessExport.Visible = true;
                    //this.li_SageExport.Attributes.Add("style", " display:block");

                }
            }

            if (ConnectionClass.ReckonHosted != null)
            {
                this.ReckonHosted = ConnectionClass.ReckonHosted.ToString();
                if (this.ReckonHosted.ToString().ToLower() != "true")
                {
                    this.li_ReckonHostedExport.Visible = false;
                    this.ReckonHosted = "false";
                }
                else
                {
                    this.li_ReckonHostedExport.Visible = true;
                }
            }

            if (ConnectionClass.Is_crm_order_module != null)
            {
                if (ConnectionClass.Is_crm_order_module.ToString().ToString().ToLower() != "true")
                {
                    this.li22.Attributes.Add("style", " display:block");
                }
                else
                {
                    this.li22.Attributes.Add("style", " display:none");
                }
            }
            if (ConnectionClass.FreshBooksAPI != null)
            {
                if (ConnectionClass.FreshBooksAPI.ToString().ToLower() != "true")
                {
                    this.li19.Attributes.Add("style", " display:none");
                }
                else
                {
                    this.li19.Attributes.Add("style", " display:block");
                }
            }
            if (ConnectionClass.ServerName.ToLower() != "centurionprint")
            {
                this.li27.Attributes.Add("style", " display:none");
            }
            else
            {
                this.li27.Attributes.Add("style", " display:block");
            }
            if (ConnectionClass.DeliveryCost != null)
            {
                this.li34.Attributes.Add("style", " display:block");
            }
            else
            {
                this.li34.Attributes.Add("style", " display:none");
            }
            if (!ConnectionClass.IsQuickBooks)
            {
                this.li29.Attributes.Add("style", " display:none");
            }
            else
            {
                this.li29.Attributes.Add("style", " display:block");
                this.QuickBooks.HRef = string.Concat(this.strSitepath, "Settings/QuickbookAccounting.aspx");
            }
            this.objbase.CheckUserAccessRight("setting");
            if (this.InventoryManagement != "IM")
            {
                this.TabSelection = "False";
                this.liStockReduction.Visible = false;
            }
            else
            {
                this.TabSelection = "True";
                this.liStockReduction.Visible = true;
            }
            if (this.AccountingCode == "d")
            {
                this.li4.Visible = true;
            }
            else if (this.AccountingCode != "e")
            {
                this.li4.Visible = false;
                this.GetAccountingCode = "false";
            }
            else
            {
                this.li4.Visible = true;
            }
            if (this.AccountingExport.ToLower() != "ae")
            {
                this.li8.Visible = false;
                this.GetXERO = "false";
            }
            else
            {
                this.li8.Visible = true;
            }
            if (this.NavisionExport.ToString().ToLower() == "true")
            {
                this.li_AccountingExport.Visible = true;
            }
            if (!(this.GetAccountingCode == "false") || !(this.GetMYOB == "false") || !(this.GetXERO == "false") || !(this.NavisionExport.ToString().ToLower() != "true"))
            {
                this.li16.Attributes.Add("style", " display:block");
            }
            else
            {
                this.li16.Attributes.Add("style", " display:none");
            }
            DataTable dataTable1 = SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString()));
            foreach (DataRow row in dataTable1.Rows)
            {
                this.roundoff = row["Roundoff"].ToString();
            }
            BasePage basePage = new BasePage();
            this.colorformat = this.objbase.SpecialDecode(basePage.GetRegionalSettings(int.Parse(base.Session["companyID"].ToString()), "colour"));
            basePage.logoSetting(this.plhHeader, this.plhFooter, int.Parse(base.Session["companyID"].ToString()), "both");
            if (base.Request.Url.ToString().ToLower().Contains("http://demo.eprintsoftware.com/"))
            {
                if (base.Session["email"] == null || !(base.Session["email"].ToString().ToLower().Trim() == "info@eprintsoftware.com") && !(base.Session["email"].ToString().ToLower().Trim() == "info@infomazetech.com"))
                {
                    this.liUser.Attributes.Add("style", " display:none");
                    if (base.Request.Url.ToString().ToLower().Contains("user_manager.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "unauthorized_access.aspx"));
                    }
                }
                else
                {
                    this.liUser.Attributes.Add("style", " display:block");
                }
            }
            this.forecolor = this.objpage.Forecolor(this.companyid, base.Session["pagename"].ToString().ToLower());
            this.tabcolor = this.objpage.colorCode(this.companyid, base.Session["pagename"].ToString().ToLower());
            this.objbase.CallStyle(this.plhStyle, this.tabcolor, this.forecolor);
            if (!this.Is_Non_Printing_System)
            {
                this.liplantandpresses.Attributes.Add("style", "display:block");
                this.li7.Attributes.Add("style", "display:block");
            }
            else
            {
                this.liplantandpresses.Attributes.Add("style", "display:none");
                this.li7.Attributes.Add("style", "display:none");
            }
            if (ConnectionClass.LargeFormat != null)
            {
                this.lilarge.Attributes.Add("style", " display:block");
                this.lilargeguillotine.Attributes.Add("style", " display:block");
            }
            if (ConnectionClass.SheetFedOffset != null)
            {
                this.lisinglefedoffset.Attributes.Add("style", " display:block");
                this.liguillotine.Attributes.Add("style", " display:block");
            }
            if (ConnectionClass.SheetFedDigital != null)
            {
                this.childul.Attributes.Add("style", " display:block");
                this.liguillotine.Attributes.Add("style", " display:block");
            }
            if (ConnectionClass.LargeFormat != null || ConnectionClass.SheetFedOffset != null || ConnectionClass.SheetFedDigital != null)
            {
                this.liplantandpresses.Attributes.Add("style", " display:block");
                this.li7.Attributes.Add("style", "display:block");
            }
            if (ConnectionClass.LargeFormat == null && ConnectionClass.SheetFedOffset == null && ConnectionClass.SheetFedDigital == null)
            {
                this.liplantandpresses.Attributes.Add("style", " display:none");
            }
            if (ConnectionClass.OtherCosts != null)
            {
                this.liohtercost.Attributes.Add("style", " display:block");
            }
            if (ConnectionClass.Warehouse != null)
            {
                this.liwarehouse.Attributes.Add("style", " display:block");
            }
            if (ConnectionClass.OldData != null)
            {
                if (ConnectionClass.OldData.ToLower() != "true")
                {
                    this.liOldData.Attributes.Add("style", " display:none");
                }
                else
                {
                    this.liOldData.Attributes.Add("style", " display:block");
                }
            }
            bool flag1 = SettingsBasePage.Fetch_SupplierQuote(Convert.ToInt16(base.Session["Companyid"]));
            int manageStockPermission = settingpage.ManageStockPermission;
            string str1 = this.objbase.Return_IsEnable_CRM(Convert.ToInt32(this.companyid));
            this.licallpurpose.Visible = true;
            if (str1.Trim().ToLower() != "true")
            {
                this.lidashSetting.Visible = false;
            }
            else
            {
                this.lidashSetting.Visible = true;
            }
            if (base.Session["HeaderNavigation"] != null)
            {
                this.Template_Names = (DataSet)base.Session["HeaderNavigation"];
            }
            else
            {
                DataTable dataTable2 = new DataTable();
                string str2 = "";
                this.Template_Names = this.obj.GetHeaderimage(Convert.ToInt32(base.Session["companyID"]), Convert.ToInt32(base.Session["userID"]), "Settings", ref dataTable2, ref str2, (int)base.Session["admin"]);
                base.Session["HeaderNavigation"] = this.Template_Names;
            }
            foreach (DataRow dataRow in this.Template_Names.Tables[0].Rows)
            {
                if (dataRow["headerName"].ToString().ToLower().Contains("estimates") || dataRow["headerName"].ToString().ToLower().Contains("estimate"))
                {
                    this.liestimate11.Style.Add("display", "block");
                }
                if (dataRow["headerName"].ToString().ToLower().Contains("jobs") || dataRow["headerName"].ToString().ToLower().Contains("job"))
                {
                    this.lijobs.Style.Add("display", "block");
                    this.licradsetting.Style.Add("display", "block");
                }
                if (dataRow["headerName"].ToString().ToLower().Contains("purchase") || dataRow["headerName"].ToString().ToLower().Contains("purchases"))
                {
                    this.lipurchaseorder.Style.Add("display", "block");
                }
                if (dataRow["headerName"].ToString().ToLower().Contains("invoice") || dataRow["headerName"].ToString().ToLower().Contains("invoices"))
                {
                    this.liinvoice.Style.Add("display", "block");
                }
                if (!dataRow["headerName"].ToString().ToLower().Contains("deliverynotes") && !dataRow["headerName"].ToString().ToLower().Contains("deliverynote"))
                {
                    continue;
                }
                this.div_DeliveryNote.Style.Add("display", "block");
            }
            if (ConnectionClass.EnableNetsuite)
            {
                this.li_Netsuite.Visible = true;
                this.Netsuite_href.HRef = string.Concat(this.strSitepath, "Settings/Netsuite.aspx");
            }
            if (Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsPreflightEnable"]))
            {
                this.liPreFlightOptions.Style.Add("display", "block");
            }
            if (Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsPreflightEnable"]) && base.Session["userid"] != null && CompanyBasePage.UserCheck_forSupportTeam(Convert.ToInt32(base.Session["userid"])) == 1)
            {
                this.liPreFlightProfileUpload.Style.Add("display", "block");
            }

            int num = 0;
            DataTable dataTableStock = WebstoreBasePage.stockmanagementsettings_select(Convert.ToInt32(base.Session["companyID"]));
            if (dataTableStock.Rows.Count > 0)
            {
                foreach (DataRow row in dataTableStock.Rows)
                {
                    if ((row["SR_WhenStockReduced"] != null && row["SR_WhenStockReduced"].ToString().ToLower() == "s")|| (row["SA_WhenStockAdded"] != null && row["SA_WhenStockAdded"].ToString().ToLower() == "f"))
                    {
                        this.listStockScanning.Attributes.Add("style", "display:block");

                    }
                    else
                    {
                        this.listStockScanning.Attributes.Add("style", "display:none");
                    }
                }
            }

        }
    }
}