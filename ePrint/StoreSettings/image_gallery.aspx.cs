using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Configuration;
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
    public partial class image_gallery : BaseClass, IRequiresSessionState
    {
        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string savepath = string.Empty;

        private BaseClass objBase = new BaseClass();

        public string strSitePath = global.sitePath();

        private SettingsBasePage objSet = new SettingsBasePage();

        public string strImagepath = global.imagePath();

        public string ServerName = string.Empty;

        public long ScopeIdentity;

        public long CategoryID;

        public long ParentID;

        public static long CompanyID;

        public static long UserID;

        public string OriginalFileName = string.Empty;

        public string UserType = "admin";

        public string SecureDocPath = global.SecureDocPath();

        private string EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();

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

        static image_gallery()
        {
        }

        public image_gallery()
        {
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.CategoryID = Convert.ToInt64(this.hdnParentCatID.Value);
            this.GenerateImageGallery(this.CategoryID);
            this.hdnCategoryID.Value = this.CategoryID.ToString();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            this.CategoryID = Convert.ToInt64(this.hdnCategoryID.Value);
            this.GenerateImageGallery(this.CategoryID);
        }

        protected void btnDeleteImageCategory_OnClick(object sender, EventArgs e)
        {
            this.GenerateImageGallery(Convert.ToInt64(this.hdnParentCatID.Value));
        }

        protected void btnDeleteRootImage_Click(object sender, EventArgs e)
        {
            this.GenerateImageGallery(Convert.ToInt64(this.hdnParentCatID.Value));
        }

        protected void btnlnkDeleteSelected_OnClick(object sender, EventArgs e)
        {
            string value = this.hdnCategoryIDs.Value;
            string str = this.hdnImageIDs.Value;
            string[] strArrays = value.Split(new char[] { '\u00A7' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string str1 = strArrays[i];
                SettingsBasePage.DeleteMultipleImageCategory(image_gallery.CompanyID, image_gallery.UserID, str1);
            }
            if (str != "")
            {
                string[] strArrays1 = str.Split(new char[] { '~' });
                for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                {
                    string str2 = strArrays1[j];
                    SettingsBasePage.DeleteMultipleImages(image_gallery.CompanyID, image_gallery.UserID, str2);
                }
            }
            if (this.hdnCategoryID.Value != "")
            {
                this.CategoryID = Convert.ToInt64(this.hdnCategoryID.Value);
            }
            else
            {
                this.CategoryID = (long)0;
            }
            this.GenerateImageGallery(this.CategoryID);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            object[] serverName = new object[] { this.strSitePath, "document/securedoc/", this.ServerName, "/editabletemplatebackend/", image_gallery.CompanyID, "/Images/Gallery/ThumbnailImages/" };
            string str = string.Concat(serverName);
            string str1 = this.hdnSearchtext.Value.ToString();
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.GetSearchItems(image_gallery.CompanyID, this.CategoryID, image_gallery.UserID, str1);
            if (dataTable.Rows.Count == 0)
            {
                this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='padding: 10px 0px 0px 20px;'>"));
                Label label = new Label()
                {
                    ID = "lblMEssage",
                    Text = this.objLanguage.GetLanguageConversion("No_images_to_display")
                };
                this.plhGalleryDetails.Controls.Add(label);
                this.hdnParentCatID.Value = this.CategoryID.ToString();
                this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
            }
            else
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    this.plhGalleryDetails.Controls.Add(new LiteralControl("<div  style='float: left; padding: 36px 0px 0px 25px;'>"));
                    this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivRootImg", i, "' onmouseover='mouseovershowImage(this)' onmouseout='mouseouthidDivImage(this)' style='float: left; border: solid 1px; border-color:#98A6B3;  border-radius:3px; width: 120px; height: 110px;'>")));
                    this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<input id='chkSearchImgdelete_", i, "' type='checkbox' name='DeleteSelected'/>")));
                    string[] strArrays = dataTable.Rows[i]["FileName"].ToString().Split(new char[] { '.' });
                    if (strArrays[(int)strArrays.Length - 1].ToString().ToLower().Contains("pdf"))
                    {
                        this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<img alt='Image' src='", this.strSitePath, "images/StoreImages/processing_img.png' style='margin: 0px 0px 0px 10px; height:74px; width:100px; cursor:hand;' /> ")));
                    }
                    else
                    {
                        ControlCollection controls = this.plhGalleryDetails.Controls;
                        string[] strArrays1 = new string[] { "<img alt='Image' src='", str, "t_", dataTable.Rows[i]["FileName"].ToString(), "' style='margin: 0px 0px 0px 10px; height:74px; width:100px; cursor:hand;' /> " };
                        controls.Add(new LiteralControl(string.Concat(strArrays1)));
                    }
                    HiddenField hiddenField = new HiddenField()
                    {
                        ID = string.Concat("hdnSearchMultpleDel_", i),
                        Value = dataTable.Rows[i]["ImageID"].ToString()
                    };
                    this.plhGalleryDetails.Controls.Add(hiddenField);
                    this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivRootImgEdit", i, "' style='height: 15px; padding: 2px 0px 0px 10px; background-color:#797979; display:none;'>")));
                    ControlCollection controlCollections = this.plhGalleryDetails.Controls;
                    object[] item = new object[] { "<a href='#' id='edit' onclick='EditImageDetails(", dataTable.Rows[i]["ImageID"], ",\"", dataTable.Rows[i]["CategoryID"], "\",\"", dataTable.Rows[i]["OriginalFileName"], "\",\"", dataTable.Rows[i]["Description"], "\",\"", dataTable.Rows[i]["MetaTags"], "\",\"", dataTable.Rows[i]["FileName"], "\")'   title='Edit'> <span style='color:white;'>Edit</span></a>" };
                    controlCollections.Add(new LiteralControl(string.Concat(item)));
                    ControlCollection controls1 = this.plhGalleryDetails.Controls;
                    object[] objArray = new object[] { "<a href='#' id='Delete' onclick='DeleteImage(", dataTable.Rows[i]["ImageID"], ",\"", dataTable.Rows[i]["CategoryID"], "\")' title='Delete' style='margin-left: 35px;'><span style='color:white;'>Delete</span></a>" };
                    controls1.Add(new LiteralControl(string.Concat(objArray)));
                    this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='height: 20px; padding: 5px 0px 0px 10px;'>"));
                    Label label1 = new Label()
                    {
                        ID = string.Concat("lblrootimg", i),
                        Text = dataTable.Rows[i]["OriginalFileName"].ToString()
                    };
                    if (label1.Text.Length > 15)
                    {
                        string str2 = label1.Text.Remove(15);
                        label1.Text = string.Concat(str2, "...");
                        label1.ToolTip = dataTable.Rows[i]["OriginalFileName"].ToString();
                    }
                    this.plhGalleryDetails.Controls.Add(label1);
                    this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='width:10px;float: left; height: 45px;'>"));
                    this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                }
            }
            this.btnBack.Attributes.CssStyle.Add("display", "block");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            this.pnlstatus.Value = "hide";
            string[] strArrays = this.hdnImageDetails.Value.Split(new char[] { '\u00B6' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { '\u00A7' });
                SettingsBasePage.UpdateImageGallery(Convert.ToInt64(strArrays1[0]), image_gallery.CompanyID, strArrays1[1].ToString(), strArrays1[3].ToString(), strArrays1[2].ToString());
            }
            this.btnsave.Attributes.CssStyle.Add("display", "none");
            this.btncancel.Attributes.CssStyle.Add("display", "none");
            this.CategoryID = Convert.ToInt64(this.hdnCatIDafterupld.Value);
            this.hdnCategoryID.Value = this.CategoryID.ToString();
            this.GenerateImageGallery(this.CategoryID);
            this.hdnCategoryID.Value = this.CategoryID.ToString();
            this.divSearch.Attributes.CssStyle.Add("display", "block");
            this.RadPageView1.Attributes.CssStyle.Add("display", "block !important");
            this.RadPageView2.Attributes.CssStyle.Add("display", "none");
            this.RadTabStrip1.SelectedIndex = 0;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.flImageUpload.UploadedFiles.Count > 0)
            {
                this.hdnImageCount.Value = this.flImageUpload.UploadedFiles.Count.ToString();
                for (int i = 0; i < this.flImageUpload.UploadedFiles.Count; i++)
                {
                    object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "/editabletemplatebackend/", image_gallery.CompanyID, "/images/Gallery/OriginalImages/" };
                    string str = string.Concat(secureDocPath);
                    object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "/editabletemplatebackend/", image_gallery.CompanyID, "/pdf" };
                    string str1 = string.Concat(objArray);
                    if (!Directory.Exists(str1))
                    {
                        Directory.CreateDirectory(str1);
                    }
                    if (!Directory.Exists(str))
                    {
                        Directory.CreateDirectory(str);
                    }
                    bool flag = false;
                    string[] strArrays = this.flImageUpload.UploadedFiles[i].FileName.ToString().Split(new char[] { '.' });
                    string str2 = strArrays[(int)strArrays.Length - 1].ToString();
                    long contentLength = this.flImageUpload.UploadedFiles[i].ContentLength;
                    this.OriginalFileName = this.flImageUpload.UploadedFiles[i].FileName;
                    object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "/editabletemplatebackend/", image_gallery.CompanyID, "/images/Gallery/ThumbnailImages/" };
                    string str3 = string.Concat(secureDocPath1);
                    if (!Directory.Exists(str3))
                    {
                        Directory.CreateDirectory(str3);
                    }
                    Guid guid = Guid.NewGuid();
                    string str4 = string.Concat(guid.ToString().Substring(0, 5), "_", this.flImageUpload.UploadedFiles[i].FileName);
                    System.Drawing.Image.GetThumbnailImageAbort getThumbnailImageAbort = new System.Drawing.Image.GetThumbnailImageAbort(this.ThumbnailCallback);
                    if (str2.ToLower() == "pdf")
                    {
                        this.flImageUpload.UploadedFiles[i].SaveAs(Path.Combine(str1, str4));
                    }
                    else
                    {
                        this.flImageUpload.UploadedFiles[i].SaveAs(Path.Combine(str, str4));
                        using (Bitmap bitmap = new Bitmap(this.flImageUpload.UploadedFiles[i].InputStream))
                        {
                            using (System.Drawing.Image thumbnailImage = bitmap.GetThumbnailImage(100, 74, getThumbnailImageAbort, IntPtr.Zero))
                            {
                                Path.Combine(str, string.Format("{0}_thumb{1}", this.flImageUpload.UploadedFiles[i].GetNameWithoutExtension(), this.flImageUpload.UploadedFiles[i].GetExtension()));
                                thumbnailImage.Save(string.Concat(str3, "t_", str4));
                            }
                        }
                    }
                    int num = i + 1;
                    this.plhImagedetails.Controls.Add(new LiteralControl("<table style='Height:130px;'>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<tr class='NewAlternative'>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<td style='width:625px;'>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div style='float: left; padding-top: 4px; padding-left:10px;'>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl(string.Concat("<span> ", num, ".</span>")));
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div style='float: left;'>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div style='float: left; width: 100px;' class='bglabelnew'>"));
                    Label label = new Label()
                    {
                        ID = string.Concat("lblfileName_", i),
                        Text = this.objLanguage.GetLanguageConversion("File_Name")
                    };
                    this.plhImagedetails.Controls.Add(label);
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div style='float: left; width: 100px;' class='bglabelnew'>"));
                    Label label1 = new Label()
                    {
                        ID = string.Concat("lblMetaTag", i),
                        Text = this.objLanguage.GetLanguageConversion("Meta_Tags")
                    };
                    this.plhImagedetails.Controls.Add(label1);
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div style='float: left; width: 100px;' class='bglabelnew'>"));
                    Label label2 = new Label()
                    {
                        ID = string.Concat("lblDesc_", i),
                        Text = this.objLanguage.GetLanguageConversion("Description")
                    };
                    this.plhImagedetails.Controls.Add(label2);
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div style='float: left; margin-left: 10px;'>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div style='float: left;'>"));
                    TextBox textBox = new TextBox()
                    {
                        ID = string.Concat("txtFileName_", i),
                        Width = 200
                    };
                    string[] strArrays1 = this.flImageUpload.UploadedFiles[i].FileName.Split(new char[] { '.' });
                    textBox.Text = strArrays1[0].ToString();
                    this.plhImagedetails.Controls.Add(textBox);
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div>"));
                    TextBox textBox1 = new TextBox()
                    {
                        ID = string.Concat("txttagName_", i),
                        Width = 200
                    };
                    this.plhImagedetails.Controls.Add(textBox1);
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div>"));
                    TextBox textBox2 = new TextBox()
                    {
                        ID = string.Concat("txtDesc_", i),
                        Width = 200,
                        TextMode = TextBoxMode.MultiLine
                    };
                    this.plhImagedetails.Controls.Add(textBox2);
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                    object[] serverName = new object[] { this.strSitePath, "document/securedoc/", this.ServerName, "/editabletemplatebackend/", image_gallery.CompanyID, "/Images/Gallery/ThumbnailImages/" };
                    string str5 = string.Concat(serverName);
                    if (str2.ToLower().Contains("pdf"))
                    {
                        this.plhImagedetails.Controls.Add(new LiteralControl(string.Concat("<img alt='Image' src='", this.strSitePath, "images/StoreImages/processing_img.png' style='height:100px; width:100px; margin-left:170px;' /> ")));
                        flag = true;
                    }
                    else
                    {
                        ControlCollection controls = this.plhImagedetails.Controls;
                        object[] objArray1 = new object[] { "<img alt='Image' src='", str5, "t_", str4, "'  id='imguplded_", i, "' style='height:100px; width:100px; margin-left:170px;' /> " };
                        controls.Add(new LiteralControl(string.Concat(objArray1)));
                    }
                    this.plhImagedetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhImagedetails.Controls.Add(new LiteralControl("</table>"));
                    this.CategoryID = Convert.ToInt64(this.hdnCatIDafterupld.Value);
                    this.ScopeIdentity = SettingsBasePage.InsertImageGallery(image_gallery.CompanyID, this.CategoryID, image_gallery.UserID, this.UserType, this.OriginalFileName, str4, contentLength, textBox2.Text, textBox1.Text, flag, (long)0);
                    this.plhImagedetails.Controls.Add(new LiteralControl("<div style='float: left;'>"));
                    HiddenField hiddenField = new HiddenField()
                    {
                        ID = string.Concat("ImageID_", i),
                        Value = this.ScopeIdentity.ToString()
                    };
                    this.plhImagedetails.Controls.Add(hiddenField);
                    this.plhImagedetails.Controls.Add(new LiteralControl("</div>"));
                }
            }
            this.CategoryID = Convert.ToInt64(this.hdnCatIDafterupld.Value);
            this.hdnCategoryID.Value = this.CategoryID.ToString();
            this.GenerateImageGallery(this.CategoryID);
            this.btnsave.Attributes.CssStyle.Add("display", "block");
            this.btncancel.Attributes.CssStyle.Add("display", "block");
            this.panelIMg.Visible = true;
            this.pnlstatus.Value = "visible";
            this.divupld.Attributes.CssStyle.Add("display", "none");
            this.divSearch.Attributes.CssStyle.Add("display", "none");
            this.RadPageView2.Attributes.CssStyle.Add("display", "block");
            this.RadPageView1.Attributes.CssStyle.Add("display", "none !important");
        }

        public void GenerateImageGallery(long CategoryID)
        {
            DataSet imageGalleryCategories = SettingsBasePage.GetImageGalleryCategories(image_gallery.CompanyID, CategoryID);
            if (CategoryID == (long)0)
            {
                for (int i = 0; i < imageGalleryCategories.Tables.Count; i++)
                {
                    this.hdnParentCatID.Value = "0";
                    object[] serverName = new object[] { this.strSitePath, "document/securedoc/", this.ServerName, "/editabletemplatebackend/", image_gallery.CompanyID, "/Images/Gallery/ThumbnailImages/" };
                    string str = string.Concat(serverName);
                    DataTable dataTable = new DataTable();
                    DataTable item = new DataTable();
                    dataTable = imageGalleryCategories.Tables[0];
                    item = imageGalleryCategories.Tables[1];
                    if (i == 0)
                    {
                        for (int j = 0; j < dataTable.Rows.Count; j++)
                        {
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("<div  style='float: left; padding: 36px 0px 0px 25px;'>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivMain", j, "' onmouseover='mouseovershow(this)' onmouseout='mouseouthidDiv(this)' style='float: left; border: solid 1px; border-color:#98A6B3;  border-radius:3px; width: 120px; height: 110px;'>")));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<input id='chkCatMulDel_", j, "' type='checkbox' name='DeleteSelected'/>")));
                            ControlCollection controls = this.plhGalleryDetails.Controls;
                            object[] objArray = new object[] { "<img alt='Image' src='", this.strSitePath, "images/StoreImages/category-icon.png' onclick='OnCategoryClick(", dataTable.Rows[j]["CategoryID"], ")' style='margin: 0px 0px 0px 10px; cursor:hand;' /> " };
                            controls.Add(new LiteralControl(string.Concat(objArray)));
                            HiddenField hiddenField = new HiddenField()
                            {
                                ID = string.Concat("hdnCatIDMultpleDel_", j),
                                Value = dataTable.Rows[j]["CategoryID"].ToString()
                            };
                            this.plhGalleryDetails.Controls.Add(hiddenField);
                            this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivEdit", j, "' style='height: 15px; padding: 2px 0px 0px 10px;  background-color:#797979; display:none;'>")));
                            ControlCollection controlCollections = this.plhGalleryDetails.Controls;
                            object[] item1 = new object[] { "<a href='#' id='edit' onclick='EditImageCategory(", dataTable.Rows[j]["ParentID"], ",\"", dataTable.Rows[j]["CategoryName"], "\",\"", dataTable.Rows[j]["CategoryID"], "\")' title='Edit'> <span style='color:white;'>Edit</span></a>" };
                            controlCollections.Add(new LiteralControl(string.Concat(item1)));
                            ControlCollection controls1 = this.plhGalleryDetails.Controls;
                            object[] objArray1 = new object[] { "<a href='#' id='Delete' onclick='DeleteImageCategory(", dataTable.Rows[j]["CategoryID"], ",\"", dataTable.Rows[j]["ParentID"], "\")' title='Delete' style='margin-left: 35px;'><span style='color:white;'>Delete</span></a>" };
                            controls1.Add(new LiteralControl(string.Concat(objArray1)));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='height: 20px; padding: 5px 0px 0px 10px;'>"));
                            Label label = new Label()
                            {
                                ID = string.Concat("lblImageName", j),
                                Text = dataTable.Rows[j]["CategoryName"].ToString()
                            };
                            if (label.Text.Length > 15)
                            {
                                string str1 = label.Text.Remove(15);
                                label.Text = string.Concat(str1, "...");
                                label.ToolTip = dataTable.Rows[j]["CategoryName"].ToString();
                            }
                            this.plhGalleryDetails.Controls.Add(label);
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='width:10px;float: left; height: 45px;'>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    if (i == 1 && item.Rows.Count > 0)
                    {
                        for (int k = 0; k < item.Rows.Count; k++)
                        {
                            this.hdnParentCatID.Value = "0";
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("<div  style='float: left; padding: 36px 0px 0px 25px;'>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivRootImg", k, "' onmouseover='mouseovershowImage(this)' onmouseout='mouseouthidDivImage(this)' style='float: left; border: solid 1px; border-color:#98A6B3;  border-radius:3px; width: 120px; height: 110px;'>")));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<input id='chkImgMulDel_", k, "' type='checkbox' name='DeleteSelected'/>")));
                            string[] strArrays = item.Rows[k]["FileName"].ToString().Split(new char[] { '.' });
                            if (strArrays[(int)strArrays.Length - 1].ToString().ToLower().Contains("pdf"))
                            {
                                this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<img alt='Image' src='", this.strSitePath, "images/StoreImages/processing_img.png' style='margin: 0px 0px 0px 10px; height:74px; width:100px; cursor:hand;' /> ")));
                            }
                            else
                            {
                                ControlCollection controlCollections1 = this.plhGalleryDetails.Controls;
                                string[] strArrays1 = new string[] { "<img alt='Image' src='", str, "t_", item.Rows[k]["FileName"].ToString(), "' style='margin: 0px 0px 0px 10px; height:74px; width:100px; cursor:hand;' /> " };
                                controlCollections1.Add(new LiteralControl(string.Concat(strArrays1)));
                            }
                            HiddenField hiddenField1 = new HiddenField()
                            {
                                ID = string.Concat("hdnImgIDMultpleDel_", k),
                                Value = item.Rows[k]["ImageID"].ToString()
                            };
                            this.plhGalleryDetails.Controls.Add(hiddenField1);
                            this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivRootImgEdit", k, "' style='height: 15px; padding: 2px 0px 0px 10px; background-color:#797979; display:none;'>")));
                            ControlCollection controls2 = this.plhGalleryDetails.Controls;
                            object[] item2 = new object[] { "<a href='#' id='edit'onclick='EditImageDetails(", item.Rows[k]["ImageID"], ",\"", item.Rows[k]["CategoryID"], "\",\"", item.Rows[k]["OriginalFileName"], "\",\"", item.Rows[k]["Description"], "\",\"", item.Rows[k]["MetaTags"], "\",\"", item.Rows[k]["FileName"], "\")'  title='Edit'> <span style='color:white;'>Edit</span></a>" };
                            controls2.Add(new LiteralControl(string.Concat(item2)));
                            ControlCollection controlCollections2 = this.plhGalleryDetails.Controls;
                            object[] objArray2 = new object[] { "<a href='#' id='Delete' onclick='DeleteImage(", item.Rows[k]["ImageID"], ",\"", item.Rows[k]["CategoryID"], "\")' title='Delete' style='margin-left: 35px;'><span style='color:white;'>Delete</span></a>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(objArray2)));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='height: 20px; padding: 5px 0px 0px 10px;'>"));
                            Label label1 = new Label()
                            {
                                ID = string.Concat("lblrootimg", k),
                                Text = item.Rows[k]["OriginalFileName"].ToString()
                            };
                            if (label1.Text.Length > 15)
                            {
                                string str2 = label1.Text.Remove(15);
                                label1.Text = string.Concat(str2, "...");
                                label1.ToolTip = item.Rows[k]["OriginalFileName"].ToString();
                            }
                            this.plhGalleryDetails.Controls.Add(label1);
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='width:10px;float: left; height: 45px;'>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    this.btnBack.Attributes.CssStyle.Add("display", "none");
                }
                return;
            }
            for (int l = 0; l < imageGalleryCategories.Tables.Count; l++)
            {
                object[] serverName1 = new object[] { this.strSitePath, "document/securedoc/", this.ServerName, "/editabletemplatebackend/", image_gallery.CompanyID, "/Images/Gallery/ThumbnailImages/" };
                string str3 = string.Concat(serverName1);
                DataTable dataTable1 = new DataTable();
                DataTable dataTable2 = new DataTable();
                DataTable dataTable3 = new DataTable();
                dataTable1 = imageGalleryCategories.Tables[0];
                dataTable2 = imageGalleryCategories.Tables[1];
                dataTable3 = imageGalleryCategories.Tables[2];
                if (l == 0)
                {
                    for (int m = 0; m < dataTable1.Rows.Count; m++)
                    {
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("<div  style='float: left; padding: 36px 0px 0px 25px;'>"));
                        this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivMain", m, "' onmouseover='mouseovershow(this)' onmouseout='mouseouthidDiv(this)' style='float: left; border: solid 1px; border-color:#98A6B3;  border-radius:3px; width: 120px; height: 110px;'>")));
                        this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<input id='chkChildCatMulDel_", m, "' type='checkbox' name='DeleteSelected'/>")));
                        ControlCollection controls3 = this.plhGalleryDetails.Controls;
                        object[] item3 = new object[] { "<img alt='Image' src='", this.strSitePath, "images/StoreImages/category-icon.png' onclick='OnCategoryClick(", dataTable1.Rows[m]["CategoryID"], ")' style='margin: 0px 0px 0px 10px; cursor:hand;' /> " };
                        controls3.Add(new LiteralControl(string.Concat(item3)));
                        HiddenField hiddenField2 = new HiddenField()
                        {
                            ID = string.Concat("hdnChildCatIDMultpleDel_", m),
                            Value = dataTable1.Rows[m]["CategoryID"].ToString()
                        };
                        this.plhGalleryDetails.Controls.Add(hiddenField2);
                        this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivEdit", m, "' style='height: 15px; padding: 2px 0px 0px 10px; background-color:#797979; display:none;'>")));
                        ControlCollection controlCollections3 = this.plhGalleryDetails.Controls;
                        object[] objArray3 = new object[] { "<a href='#' id='edit' onclick='EditImageCategory(", dataTable1.Rows[m]["ParentID"], ",\"", dataTable1.Rows[m]["CategoryName"], "\",\"", dataTable1.Rows[m]["CategoryID"], "\")'   title='Edit'> <span style='color:white;'>Edit</span></a>" };
                        controlCollections3.Add(new LiteralControl(string.Concat(objArray3)));
                        ControlCollection controls4 = this.plhGalleryDetails.Controls;
                        object[] item4 = new object[] { "<a href='#' id='Delete' onclick='DeleteImageCategory(", dataTable1.Rows[m]["CategoryID"], ",\"", dataTable1.Rows[m]["ParentID"], "\")' title='Delete' style='margin-left: 35px;'><span style='color:white;'>Delete</span></a>" };
                        controls4.Add(new LiteralControl(string.Concat(item4)));
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='height: 20px; padding: 5px 0px 0px 10px;'>"));
                        Label label2 = new Label()
                        {
                            ID = string.Concat("lblImageName", m),
                            Text = dataTable1.Rows[m]["CategoryName"].ToString()
                        };
                        if (label2.Text.Length > 15)
                        {
                            string str4 = label2.Text.Remove(15);
                            label2.Text = string.Concat(str4, "...");
                            label2.ToolTip = dataTable1.Rows[m]["CategoryName"].ToString();
                        }
                        this.plhGalleryDetails.Controls.Add(label2);
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='width:10px;float: left; height: 45px;'>"));
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                        this.hdnParentCatID.Value = dataTable3.Rows[0]["ParentID"].ToString();
                    }
                }
                if (l == 1)
                {
                    if (dataTable2.Rows.Count == 0 && dataTable1.Rows.Count == 0 && dataTable3.Rows.Count != 0)
                    {
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='padding: 10px 0px 0px 20px;'>"));
                        Label label3 = new Label()
                        {
                            ID = "lblMEssage",
                            Text = this.objLanguage.GetLanguageConversion("There_are_No_Images_in_this_Category")
                        };
                        this.plhGalleryDetails.Controls.Add(label3);
                        this.hdnParentCatID.Value = dataTable3.Rows[0]["ParentID"].ToString();
                        this.btnBack.Attributes.CssStyle.Add("display", "block");
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                    }
                    else if (dataTable2.Rows.Count != 0 || dataTable1.Rows.Count != 0 || dataTable3.Rows.Count != 0)
                    {
                        for (int n = 0; n < dataTable2.Rows.Count; n++)
                        {
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("<div  style='float: left; padding: 36px 0px 0px 25px;'>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivRootImg", n, "' onmouseover='mouseovershowImage(this)' onmouseout='mouseouthidDivImage(this)' style='float: left; border: solid 1px; border-color:#98A6B3;  border-radius:3px; width: 120px; height: 110px;'>")));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<input id='chkChildImgMulDel_", n, "' type='checkbox' name='DeleteSelected'/>")));
                            string[] strArrays2 = dataTable2.Rows[n]["FileName"].ToString().Split(new char[] { '.' });
                            if (strArrays2[(int)strArrays2.Length - 1].ToString().ToLower().Contains("pdf"))
                            {
                                this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<img alt='Image' src='", this.strSitePath, "images/StoreImages/processing_img.png' style='margin: 0px 0px 0px 10px; height:74px; width:100px; cursor:hand;' /> ")));
                            }
                            else
                            {
                                ControlCollection controlCollections4 = this.plhGalleryDetails.Controls;
                                string[] strArrays3 = new string[] { "<img alt='Image' src='", str3, "t_", dataTable2.Rows[n]["FileName"].ToString(), "' style='margin: 0px 0px 0px 10px; height:74px; width:100px; cursor:hand;' /> " };
                                controlCollections4.Add(new LiteralControl(string.Concat(strArrays3)));
                            }
                            HiddenField hiddenField3 = new HiddenField()
                            {
                                ID = string.Concat("hdnChildIDMultpleDel_", n),
                                Value = dataTable2.Rows[n]["ImageID"].ToString()
                            };
                            this.plhGalleryDetails.Controls.Add(hiddenField3);
                            this.plhGalleryDetails.Controls.Add(new LiteralControl(string.Concat("<div id='DivRootImgEdit", n, "' style='height: 15px; padding: 2px 0px 0px 10px;background-color:#797979; display:none;'>")));
                            ControlCollection controls5 = this.plhGalleryDetails.Controls;
                            object[] objArray4 = new object[] { "<a href='#' id='edit' onclick='EditImageDetails(", dataTable2.Rows[n]["ImageID"], ",\"", dataTable2.Rows[n]["CategoryID"], "\",\"", dataTable2.Rows[n]["OriginalFileName"], "\",\"", dataTable2.Rows[n]["Description"], "\",\"", dataTable2.Rows[n]["MetaTags"], "\",\"", dataTable2.Rows[n]["FileName"], "\")'   title='Edit'> <span style='color:white;'>Edit</span></a>" };
                            controls5.Add(new LiteralControl(string.Concat(objArray4)));
                            ControlCollection controlCollections5 = this.plhGalleryDetails.Controls;
                            object[] item5 = new object[] { "<a href='#' id='Delete' onclick='DeleteImage(", dataTable2.Rows[n]["ImageID"], ",\"", dataTable2.Rows[n]["CategoryID"], "\")' title='Delete' style='margin-left: 35px;'><span style='color:white;'>Delete</span></a>" };
                            controlCollections5.Add(new LiteralControl(string.Concat(item5)));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='height: 20px; padding: 5px 0px 0px 10px;'>"));
                            Label label4 = new Label()
                            {
                                ID = string.Concat("lblrootimg", n),
                                Text = dataTable2.Rows[n]["OriginalFileName"].ToString()
                            };
                            if (label4.Text.Length > 15)
                            {
                                string str5 = label4.Text.Remove(15);
                                label4.Text = string.Concat(str5, "...");
                                label4.ToolTip = dataTable2.Rows[n]["OriginalFileName"].ToString();
                            }
                            this.plhGalleryDetails.Controls.Add(label4);
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='width:10px;float: left; height: 45px;'>"));
                            this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                        }
                        this.hdnParentCatID.Value = dataTable3.Rows[0]["ParentID"].ToString();
                    }
                    else
                    {
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("<div style='padding: 10px 0px 0px 20px;'>"));
                        Label label5 = new Label()
                        {
                            ID = "lblMEssage",
                            Text = this.objLanguage.GetLanguageConversion("This_Category_does_not_exists")
                        };
                        this.plhGalleryDetails.Controls.Add(label5);
                        this.btnBack.Attributes.CssStyle.Add("display", "block");
                        this.plhGalleryDetails.Controls.Add(new LiteralControl("</div>"));
                    }
                }
            }
            this.btnBack.Attributes.CssStyle.Add("display", "block");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Title = this.objLanguage.convert(global.pageTitle("Image Gallery", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (this.Session["CompanyID"] != null)
            {
                image_gallery.CompanyID = (long)Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            image_gallery.UserID = (long)Convert.ToInt32(this.Session["UserID"].ToString());
            DataTable categories = SettingsBasePage.GetCategories(image_gallery.CompanyID, image_gallery.UserID);
            this.cboCategory.DataSource = categories;
            this.cboCategory.DataTextField = "MultiLevelCategory";
            this.cboCategory.DataValueField = "CategoryID";
            this.cboCategory.DataBind();
            this.flImageUpload.Localization.Add = this.objLanguage.GetLanguageConversion("Add_More_Files");
            if (base.IsPostBack)
            {
                this.divSearch.Attributes.CssStyle.Add("display", "block");
                this.RadPageView2.Attributes.CssStyle.Add("display", "none");
                this.RadPageView1.Attributes.CssStyle.Add("display", "block !important");
                this.divupld.Attributes.CssStyle.Add("display", "none");
                this.btnsave.Attributes.CssStyle.Add("display", "none");
                this.btncancel.Attributes.CssStyle.Add("display", "none");
                this.pnlstatus.Value = "hide";
            }
            else
            {
                this.GenerateImageGallery(this.CategoryID);
                if (this.RadTabStrip1.SelectedIndex != 0)
                {
                    this.divSearch.Attributes.CssStyle.Add("display", "none");
                }
                else
                {
                    this.divSearch.Attributes.CssStyle.Add("display", "block");
                }
            }
            this.btnSelectAll.Text = this.objLanguage.GetLanguageConversion("Select_All");
            this.btnUnSelectAll.Text = this.objLanguage.GetLanguageConversion("UnSelect_All");
            this.btnDeleteSelected.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.btnUplaod.Text = this.objLanguage.GetLanguageConversion("Upload");
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            long num = Convert.ToInt64(e.Argument);
            DataTable categories = SettingsBasePage.GetCategories(image_gallery.CompanyID, image_gallery.UserID);
            this.cboCategory.DataSource = categories;
            this.cboCategory.DataTextField = "MultiLevelCategory";
            this.cboCategory.DataValueField = "CategoryID";
            this.cboCategory.DataBind();
            if (num == (long)0)
            {
                this.cboCategory.SelectedIndex = 0;
            }
            else
            {
                int num1 = 0;
                while (num1 < this.cboCategory.Items.Count)
                {
                    if (Convert.ToInt64(this.cboCategory.Items[num1].Value) != num)
                    {
                        num1++;
                    }
                    else
                    {
                        this.cboCategory.SelectedIndex = num1;
                        this.GenerateImageGallery(this.CategoryID);
                        return;
                    }
                }
            }
            this.GenerateImageGallery(this.CategoryID);
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}