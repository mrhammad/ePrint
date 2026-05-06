using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Editor.DialogControls;
using Telerik.Web.UI.Widgets;


namespace ePrint.Templates
{
    public partial class SettingsEstore : MasterPage
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

        public string strSitePath = global.sitePath();

        public languageClass objLanguage = new languageClass();

        private BaseClass objbase = new BaseClass();

        public BasePage objpage = new BasePage();

        public string tabcolor = string.Empty;

        public string forecolor = "";

        public int companyid;

        public string roundoff = string.Empty;

        public string WebStore = string.Empty;

        public string MYOB = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string TabSelection = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public string AccountingExport = ConnectionClass.AccountingExport;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ServerName = ConnectionClass.ServerName;

        public string isEnableImportOrders = ConnectionClass.isEnableImportOrders;

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

        public SettingsEstore()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString() == string.Concat(this.strSitepath, "StoreSettings/StoreSettings.aspx"))
            {
                this.hdnGetCookiesValue.Value = "";
                this.hdngetparticularLIid.Value = "";
                if (base.Response.Cookies["MainTabSelect"] != null)
                {
                    base.Response.Cookies["MainTabSelect"].Value = "";
                }
                if (base.Response.Cookies["SubTabSelect"] != null)
                {
                    base.Response.Cookies["SubTabSelect"].Value = "";
                }
            }
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
            this.lbltxt.Text = this.objLanguage.GetLanguageConversion("estore");
            if (base.Session["companyID"] != null)
            {
                this.companyid = int.Parse(base.Session["companyID"].ToString());
            }
            else
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "error.aspx"));
            }
            if (ConnectionClass.WebStore != null)
            {
                this.WebStore = ConnectionClass.WebStore.ToString();
                if (this.WebStore.ToString().ToLower() != "yes")
                {
                    this.pnlWebstore.Visible = false;
                    this.liWebOrder.Attributes.Add("style", " display:none");
                }
                else
                {
                    this.pnlWebstore.Visible = true;
                    this.liWebOrder.Attributes.Add("style", " display:block");
                }
            }
            if (!ConnectionClass.Is_estorecampaign)
            {
                this.limanagecampign.Attributes.Add("style", " display:none");
            }
            else
            {
                this.limanagecampign.Attributes.Add("style", " display:block");
            }
            if (ConnectionClass.eDeliveryCost != null)
            {
                this.li2.Attributes.Add("style", " display:block");
                this.li3.Attributes.Add("style", " display:block");
                this.li4.Attributes.Add("style", " display:block");
            }
            else
            {
                this.li2.Attributes.Add("style", " display:none");
                this.li3.Attributes.Add("style", " display:none");
                this.li4.Attributes.Add("style", " display:none");
            }
            if (ConnectionClass.zip2tax != null)
            {
                this.lizip2tax.Attributes.Add("style", " display:block");
            }
            else
            {
                this.lizip2tax.Attributes.Add("style", " display:none");
            }
            this.objbase.CheckUserAccessRight("estore");
            DataTable dataTable = SettingsBasePage.Price_For_Whole_Pack_Select(Convert.ToInt32(base.Session["companyID"].ToString()));
            foreach (DataRow row in dataTable.Rows)
            {
                this.roundoff = row["Roundoff"].ToString();
            }
            BasePage basePage = new BasePage();
            this.colorformat = basePage.GetRegionalSettings(int.Parse(base.Session["companyID"].ToString()), "colour");
            basePage.logoSetting(this.plhHeader, this.plhFooter, int.Parse(base.Session["companyID"].ToString()), "both");
            this.forecolor = this.objpage.Forecolor(this.companyid, base.Session["pagename"].ToString().ToLower());
            this.tabcolor = this.objpage.colorCode(this.companyid, base.Session["pagename"].ToString().ToLower());
            this.objbase.CallStyle(this.plhStyle, this.tabcolor, this.forecolor);
            DataTable dataTable1 = SettingsBasePage.Check_IsApprovalFeaturesOn(Convert.ToInt32(base.Session["companyID"].ToString()));
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                if (dataRow["IsApprovalFeaturesOn"].ToString().ToLower() != "false")
                {
                    this.LiApproval_System.Visible = true;
                }
                else
                {
                    this.LiApproval_System.Visible = false;
                }
                if (dataRow["IsEnableSpendLimit"].ToString().ToLower() != "false")
                {
                    this.lispendlimit.Visible = true;
                }
                else
                {
                    this.lispendlimit.Visible = false;
                }
                if (dataRow["EnableHidePrice"].ToString().ToLower() != "false")
                {
                    this.lieStoreHidePrice.Visible = true;
                }
                else
                {
                    this.lieStoreHidePrice.Visible = false;
                }
            }
            FileManagerDialogParameters fileManagerDialogParameter = new FileManagerDialogParameters();
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { ConnectionClass.SecureVirtualPath, ConnectionClass.ServerName, "/", base.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            fileManagerDialogParameter.ViewPaths = strArrays;
            string[] strArrays1 = new string[1];
            string[] secureVirtualPath1 = new string[] { ConnectionClass.SecureVirtualPath, ConnectionClass.ServerName, "/", base.Session["CompanyID"].ToString(), "/" };
            strArrays1[0] = string.Concat(secureVirtualPath1);
            fileManagerDialogParameter.UploadPaths = strArrays1;
            fileManagerDialogParameter.MaxUploadFileSize = 5000000;
            fileManagerDialogParameter.FileBrowserContentProviderTypeName = typeof(SettingsEstore.myprovider).AssemblyQualifiedName;
            DialogDefinition dialogDefinition = new DialogDefinition(typeof(ImageManagerDialog), fileManagerDialogParameter)
            {
                ClientCallbackFunction = "ImageManagerFunction",
                Width = Unit.Pixel(690),
                Height = Unit.Pixel(440),
                Title = this.objLanguage.GetLanguageConversion("Image_Manager")
            };
            dialogDefinition.Parameters["ExternalDialogsPath"] = "~/RadEditorDialogs/Custom_imagemanager/";
            this.DialogOpener1.DialogDefinitions.Add("ImageManager", dialogDefinition);
            FileManagerDialogParameters fileManagerDialogParameter1 = new FileManagerDialogParameters();
            string[] strArrays2 = new string[1];
            string[] secureVirtualPath2 = new string[] { ConnectionClass.SecureVirtualPath, ConnectionClass.ServerName, "/", base.Session["CompanyID"].ToString(), "/" };
            strArrays2[0] = string.Concat(secureVirtualPath2);
            fileManagerDialogParameter1.ViewPaths = strArrays2;
            string[] strArrays3 = new string[1];
            string[] secureVirtualPath3 = new string[] { ConnectionClass.SecureVirtualPath, ConnectionClass.ServerName, "/", base.Session["CompanyID"].ToString(), "/" };
            strArrays3[0] = string.Concat(secureVirtualPath3);
            fileManagerDialogParameter1.UploadPaths = strArrays3;
            fileManagerDialogParameter1.MaxUploadFileSize = 5000000;
            DialogDefinition dialogDefinition1 = new DialogDefinition(typeof(ImageEditorDialog), fileManagerDialogParameter1);
            dialogDefinition1.Parameters["ExternalDialogsPath"] = "~/RadEditorDialogs/Custom_imagemanager/";
            dialogDefinition1.Width = Unit.Pixel(800);
            dialogDefinition1.Height = Unit.Pixel(440);
            this.DialogOpener1.DialogDefinitions.Add("ImageEditor", dialogDefinition1);
            //if (this.ServerName.ToLower() == "dmc2"
            //    || this.ServerName.ToLower() == "demo"
            //    || this.ServerName.ToLower() == "test1"
            //    )
            if(this.isEnableImportOrders.ToLower() == "true")
            {
                this.li_Import_Orders.Visible = true;
                return;
            }
            this.li_Import_Orders.Visible = false;
        }

        public class myprovider : FileSystemContentProvider
        {
            public myprovider(HttpContext context, string[] searchPatterns, string[] viewPaths, string[] uploadPaths, string[] deletePaths, string selectedUrl, string selectedItemTag)
                : base(context, searchPatterns, viewPaths, uploadPaths, deletePaths, selectedUrl, selectedItemTag)
            {
            }

            public override string StoreFile(UploadedFile file, string path, string name, params string[] arguments)
            {
                string str = name.Substring(name.LastIndexOf("."));
                string str1 = name.Substring(0, name.IndexOf("."));
                commonClass _commonClass = new commonClass();
                string str2 = string.Concat(_commonClass.ReplaceSplSymbol(str1), str);
                return base.StoreFile(file, path, str2, arguments);
            }
        }
    }
}