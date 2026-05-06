using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class edit_image_details : BaseClass, IRequiresSessionState
    {
        //protected RadScriptManager ScriptManager1;

        //protected Label lblTitle;

        //protected TextBox txtTitle;

        //protected HiddenField hdntitle;

        //protected Label lblCategory;

        //protected RadComboBox cboCategory;

        //protected HiddenField hdncategory;

        //protected Label Label1;

        //protected TextBox txtTag;

        //protected HiddenField hdntags;

        //protected Label lblDesc;

        //protected TextBox txtDesc;

        //protected HiddenField hdnDesc;

        //protected Button btnUpdate;

        //protected Button btncancel;

        //protected HtmlAnchor imgchange;

        //protected HtmlGenericControl divChangeImg;

        //protected HtmlImage imgGal;

        //protected Label lblSelectfile;

        //protected RadUpload flImageUpload;

        //protected Button btnUplaod;

        //protected HiddenField hdnNewfileName;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager1;

        //protected HtmlGenericControl divEditContents;

        //protected LinkButton btnBack;

        //protected HtmlGenericControl divNoImage;

        //protected HtmlForm form1;

        public string ServerName = string.Empty;

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string savepath = string.Empty;

        private BaseClass objBase = new BaseClass();

        public string strSitePath = global.sitePath();

        public string strImagepath = global.imagePath();

        public static long CompanyID;

        public static long UserID;

        public static long CategoryID;

        public static long ImageID;

        public string type = "new";

        public string FileName = "";

        public string ImageName = "";

        public string Description = "";

        public string MetaTags = "";

        public string _imagpath = "";

        public string OriginalFileName = "";

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

        static edit_image_details()
        {
        }

        public edit_image_details()
        {
        }

        protected void btncancel_onclick(object sender, EventArgs e)
        {
        }

        public void btnUpdate_onclick(object sender, EventArgs e)
        {
            string str = "";
            str = (this.hdnNewfileName.Value.ToString() != "" ? this.hdnNewfileName.Value.ToString() : this.ImageName);
            this.OriginalFileName = this.hdntitle.Value.ToString();
            this.Description = this.hdnDesc.Value.ToString();
            this.MetaTags = this.hdntags.Value.ToString();
            edit_image_details.CategoryID = Convert.ToInt64(this.hdncategory.Value);
            SettingsBasePage.UpdateImageDetails(edit_image_details.ImageID, edit_image_details.CompanyID, edit_image_details.CategoryID, edit_image_details.UserID, this.OriginalFileName, str, this.Description, this.MetaTags);
            try
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:GetRadWindow().close();LaodImageGallery('", edit_image_details.CategoryID, "');"), true);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.flImageUpload.UploadedFiles.Count > 0)
            {
                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "/editabletemplatebackend/", edit_image_details.CompanyID, "/images/Gallery/OriginalImages/" };
                string str = string.Concat(secureDocPath);
                object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "/editabletemplatebackend/", edit_image_details.CompanyID, "/pdf" };
                string str1 = string.Concat(objArray);
                if (!Directory.Exists(str1))
                {
                    Directory.CreateDirectory(str1);
                }
                long contentLength = this.flImageUpload.UploadedFiles[0].ContentLength;
                this.OriginalFileName = this.flImageUpload.UploadedFiles[0].FileName;
                object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "/editabletemplatebackend/", edit_image_details.CompanyID, "/images/Gallery/ThumbnailImages/" };
                string str2 = string.Concat(secureDocPath1);
                string[] strArrays = this.flImageUpload.UploadedFiles[0].FileName.ToString().Split(new char[] { '.' });
                string str3 = strArrays[(int)strArrays.Length - 1].ToString();
                Guid guid = Guid.NewGuid();
                string str4 = string.Concat(guid.ToString().Substring(0, 5), "_", this.flImageUpload.UploadedFiles[0].FileName);
                this.hdnNewfileName.Value = str4;
                System.Drawing.Image.GetThumbnailImageAbort getThumbnailImageAbort = new System.Drawing.Image.GetThumbnailImageAbort(this.ThumbnailCallback);
                if (str3.ToLower() == "pdf")
                {
                    this.flImageUpload.UploadedFiles[0].SaveAs(Path.Combine(str1, str4));
                }
                else
                {
                    this.flImageUpload.UploadedFiles[0].SaveAs(Path.Combine(str, str4));
                    using (Bitmap bitmap = new Bitmap(this.flImageUpload.UploadedFiles[0].InputStream))
                    {
                        using (System.Drawing.Image thumbnailImage = bitmap.GetThumbnailImage(100, 100, getThumbnailImageAbort, IntPtr.Zero))
                        {
                            Path.Combine(str, string.Format("{0}_thumb{1}", this.flImageUpload.UploadedFiles[0].GetNameWithoutExtension(), this.flImageUpload.UploadedFiles[0].GetExtension()));
                            thumbnailImage.Save(string.Concat(str2, "t_", str4));
                        }
                    }
                }
                object[] serverName = new object[] { this.strSitePath, "document/securedoc/", this.ServerName, "/editabletemplatebackend/", edit_image_details.CompanyID, "/Images/Gallery/OriginalImages/" };
                string str5 = string.Concat(serverName);
                if (!str3.ToLower().Contains("pdf"))
                {
                    this.imgGal.Src = string.Concat(str5, str4);
                    return;
                }
                HtmlImage htmlImage = this.imgGal;
                HtmlImage htmlImage1 = this.imgGal;
                string str6 = string.Concat(this.strImagepath, "StoreImages/t_no_image_available.png");
                string str7 = str6;
                htmlImage1.Src = str6;
                htmlImage.Src = str7;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Title = this.objLanguage.convert(global.pageTitle("Image Details", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (this.Session["CompanyID"] != null)
            {
                edit_image_details.CompanyID = (long)Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            edit_image_details.UserID = (long)Convert.ToInt32(this.Session["UserID"].ToString());
            object[] serverName = new object[] { this.strSitePath, "document/securedoc/", this.ServerName, "/editabletemplatebackend/", edit_image_details.CompanyID, "/Images/Gallery/OriginalImages/" };
            this._imagpath = string.Concat(serverName);
            edit_image_details.CategoryID = Convert.ToInt64(base.Request.QueryString["CatID"]);
            edit_image_details.ImageID = Convert.ToInt64(base.Request.QueryString["imgID"]);
            this.FileName = base.Request.QueryString["Name"].ToString();
            this.ImageName = base.Request.QueryString["FileName"].ToString();
            if (SettingsBasePage.IsImageDeleted(edit_image_details.ImageID).ToLower() == "true")
            {
                this.divEditContents.Attributes.CssStyle.Add("display", "none");
                this.divNoImage.Attributes.CssStyle.Add("display", "block");
            }
            this.Description = base.Request.QueryString["Desc"].ToString();
            this.MetaTags = base.Request.QueryString["Tags"].ToString();
            if (!base.IsPostBack)
            {
                this.txtTitle.Text = this.FileName;
                this.txtDesc.Text = this.Description;
                this.txtTag.Text = this.MetaTags;
                string[] strArrays = base.Request.QueryString["FileName"].ToString().Split(new char[] { '.' });
                if (strArrays[(int)strArrays.Length - 1].ToString().ToLower().Contains("pdf"))
                {
                    this.imgGal.Src = string.Concat(this.strImagepath, "StoreImages/t_no_image_available.png");
                }
                else
                {
                    this.imgGal.Src = string.Concat(this._imagpath, this.ImageName);
                }
                DataTable categories = SettingsBasePage.GetCategories(edit_image_details.CompanyID, edit_image_details.UserID);
                this.cboCategory.DataSource = categories;
                this.cboCategory.DataTextField = "MultiLevelCategory";
                this.cboCategory.DataValueField = "CategoryID";
                this.cboCategory.DataBind();
                for (int i = 0; i < categories.Rows.Count; i++)
                {
                    if (Convert.ToInt64(categories.Rows[i]["CategoryID"]) == edit_image_details.CategoryID)
                    {
                        this.cboCategory.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}