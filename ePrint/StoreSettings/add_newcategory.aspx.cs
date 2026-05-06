using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class add_newcategory : BaseClass, IRequiresSessionState
    {
        //protected RadScriptManager ScriptManager1;

        //protected ScriptManagerProxy SMproxy;

        //protected Label lblCategory;

        //protected TextBox txtCategory;

        //protected HiddenField hdnCategoryNameEdited;

        //protected Label lblParent;

        //protected RadComboBox cboNewCategory;

        //protected Button btnSave;

        //protected HtmlGenericControl divcatgorycontents;

        //protected HiddenField hdncategory_names;

        //protected LinkButton btnBack;

        //protected HtmlGenericControl divNoCategory;

        //protected HtmlForm form1;

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string savepath = string.Empty;

        private BaseClass objBase = new BaseClass();

        public string strSitePath = global.sitePath();

        public string strImagepath = global.imagePath();

        public static long CompanyID;

        public static long UserID;

        public static long CategoryID;

        public string type = "new";

        private SettingsBasePage objSet = new SettingsBasePage();

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

        static add_newcategory()
        {
        }

 

        public void BindCategory()
        {
            DataTable categories = SettingsBasePage.GetCategories(add_newcategory.CompanyID, add_newcategory.UserID);
            this.cboNewCategory.DataSource = categories;
            this.cboNewCategory.DataTextField = "MultiLevelCategory";
            this.cboNewCategory.DataValueField = "CategoryID";
            this.cboNewCategory.DataBind();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            string str = this.hdnCategoryNameEdited.Value.ToString();
            string empty = string.Empty;
            long num = (long)0;
            long num1 = (long)0;
            string empty1 = string.Empty;
            string str1 = "admin";
            num = Convert.ToInt64(this.cboNewCategory.SelectedValue.ToString());
            if (this.type != "new")
            {
                SettingsBasePage.UpdateCategory(add_newcategory.CompanyID, add_newcategory.CategoryID, str, empty, num, empty1, add_newcategory.UserID, str1);
                try
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:LaodImageCategory('", num, "');GetRadWindow().close();"), true);
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            else
            {
                if (this.cboNewCategory.SelectedItem != null)
                {
                    num1 = SettingsBasePage.InsertCategory(add_newcategory.CompanyID, str, empty, num, empty1, add_newcategory.UserID, str1);
                }
                if (num1 != (long)-1)
                {
                    try
                    {
                        System.Web.UI.Page page = this.Page;
                        Type type = base.GetType();
                        object[] companyID = new object[] { "javascript:LaodImageGallery('", add_newcategory.CompanyID, "','", num1, "');GetRadWindow().close();" };
                        System.Web.UI.ScriptManager.RegisterStartupScript(page, type, "", string.Concat(companyID), true);
                    }
                    catch (Exception exception1)
                    {
                        throw;
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"] != null)
            {
                add_newcategory.CompanyID = (long)Convert.ToInt32(this.Session["CompanyID"].ToString());
                add_newcategory.UserID = (long)Convert.ToInt32(this.Session["UserID"].ToString());
            }
            long num = Convert.ToInt64(base.Request.QueryString["ParentID"]);
            string item = base.Request.QueryString["CatName"];
            this.type = base.Request.QueryString["type"];
            add_newcategory.CategoryID = Convert.ToInt64(base.Request.QueryString["CatID"]);
            if (base.Request.QueryString["CatID"] == null)
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Create New Category", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            else
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Edit Category", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            if (add_newcategory.CategoryID != (long)0 && SettingsBasePage.IsCategoryDeleted(add_newcategory.CategoryID).ToLower() == "true")
            {
                this.divcatgorycontents.Attributes.CssStyle.Add("display", "none");
                this.divNoCategory.Attributes.CssStyle.Add("display", "block");
            }
            if (num != (long)0)
            {
                DataTable categories = SettingsBasePage.GetCategories(add_newcategory.CompanyID, add_newcategory.UserID);
                this.cboNewCategory.DataSource = categories;
                this.cboNewCategory.DataTextField = "MultiLevelCategory";
                this.cboNewCategory.DataValueField = "CategoryID";
                this.cboNewCategory.DataBind();
                int num1 = 0;
                while (num1 < categories.Rows.Count)
                {
                    if (Convert.ToInt64(categories.Rows[num1]["CategoryID"]) != num)
                    {
                        num1++;
                    }
                    else
                    {
                        this.cboNewCategory.SelectedIndex = num1;
                        break;
                    }
                }
                this.txtCategory.Text = item;
                this.lblParent.Text = "Nested In";
                this.cboNewCategory.Enabled = false;
                return;
            }
            this.lblParent.Text = this.objLanguage.GetLanguageConversion("Parent_Category");
            if (num != (long)0 || !(this.type == "new"))
            {
                this.txtCategory.Text = item;
                this.cboNewCategory.Enabled = false;
            }
            else
            {
                this.cboNewCategory.Enabled = true;
            }
            DataTable categoryNames = SettingsBasePage.GetCategoryNames(add_newcategory.CompanyID, add_newcategory.UserID);
            if (categoryNames.Rows.Count > 0)
            {
                for (int i = 0; i < categoryNames.Rows.Count; i++)
                {
                    HiddenField hdncategoryNames = this.hdncategory_names;
                    string[] value = new string[] { this.hdncategory_names.Value, categoryNames.Rows[i]["CategoryName"].ToString(), "~", categoryNames.Rows[i]["CategoryID"].ToString(), "," };
                    hdncategoryNames.Value = string.Concat(value);
                }
            }
            if (!base.IsPostBack)
            {
                this.BindCategory();
            }
        }
    }
}