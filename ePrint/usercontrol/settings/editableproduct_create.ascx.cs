using iTextSharp.text.pdf;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.settings
{
    public partial class editableproduct_create : System.Web.UI.UserControl
    {
        public languageClass objLanguage = new languageClass();

        private BasePage objpage = new BasePage();

        private int CompanyID;

        public string IsWebstore = string.Empty;

        public static string OrigFile_image;

        private long PriceCatalogueID;

        private long TemplateID;

        private int UserID;

        private long DbID;

        private string EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();

        private commonClass objJava = new commonClass();

        private string ConnectionString = EprintConfigurationManager.ConnectionStrings["TemplateConnectionString"].ToString();

        public string strImagepath = global.imagePath();

        private SettingsBasePage objSetting = new SettingsBasePage();

        private string IsAllowCSV = string.Empty;

        private string IsMailMerge = string.Empty;

        private string Check_Type = string.Empty;

        private bool ChkMandatory;

        private bool ChkMain;

        public bool IsStockExist_FromEditable;

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

        static editableproduct_create()
        {
            editableproduct_create.OrigFile_image = string.Empty;
        }

        public editableproduct_create()
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.FinalSave();
            if (this.btnSave_ClickEventHandler != null)
            {
                this.btnSave_ClickEventHandler(sender, e, "save");
            }
        }

        protected void btnSaveStay_Click(object sender, EventArgs e)
        {
            this.FinalSave();
            if (this.btnSave_ClickEventHandler != null)
            {
                this.btnSave_ClickEventHandler(sender, e, "savestay");
            }
        }

        public void FinalSave()
        {
            if (!Directory.Exists(string.Concat(this.EditableTemplatePath, this.CompanyID, "/pdf/")))
            {
                Directory.CreateDirectory(string.Concat(this.EditableTemplatePath, this.CompanyID, "/pdf/"));
            }
            if (!Directory.Exists(string.Concat(this.EditableTemplatePath, this.CompanyID, "/images/")))
            {
                Directory.CreateDirectory(string.Concat(this.EditableTemplatePath, this.CompanyID, "/images/"));
            }
            if (this.chkPdfAllowPreview.Checked)
            {
                this.Check_Type = "pdf";
                this.ChkMain = true;
            }
            if (this.chkPDFImageAllowPreview.Checked)
            {
                this.Check_Type = "pdfimg";
                this.ChkMain = true;
            }
            if (this.chkImageAllowPreview.Checked)
            {
                this.Check_Type = "img";
                this.ChkMain = true;
            }
            if (this.chkPdfPreviewMandatory.Checked || this.chkImagePreviewMandatory.Checked || this.chkPDFImagePreviewMandatory.Checked)
            {
                this.ChkMandatory = true;
            }
            Guid guid = Guid.NewGuid();
            string str = guid.ToString().Substring(0, 30);
            object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID, "/pdf/", str, ".pdf" };
            string str1 = string.Concat(editableTemplatePath);
            string.Concat(this.EditableTemplatePath, this.CompanyID, "/pdf/");
            object[] objArray = new object[] { this.EditableTemplatePath, this.CompanyID, "/images/", str };
            string.Concat(objArray);
            string str2 = string.Concat(str, ".pdf");
            double num = 0;
            double num1 = 0;
            try
            {
                num = Convert.ToDouble(this.txt_Width.Text);
            }
            catch
            {
            }
            try
            {
                num1 = Convert.ToDouble(this.txt_height.Text);
            }
            catch
            {
            }
            if (this.txtWaterMark.Text.Trim().ToLower() == "watermark")
            {
                this.txtWaterMark.Text = "";
            }
            string empty = string.Empty;
            DateTime.Now.ToString();
            FileUpload fileUpladPdf = this.FileUpladPdf;
            object[] editableTemplatePath1 = new object[] { this.EditableTemplatePath, this.CompanyID, "/pdf/", str, ".pdf" };
            fileUpladPdf.SaveAs(string.Concat(editableTemplatePath1));
            int numberOfPages = 1;
            if (this.FileUpladPdf.HasFile)
            {
                numberOfPages = (new PdfReader(str1)).NumberOfPages;
                this.objSetting.MasterTemplate_Insert(Convert.ToInt64(this.DbID), Convert.ToInt32(this.UserID), Convert.ToInt32(this.CompanyID), this.FileUpladPdf.FileName, str2, Convert.ToInt64(this.PriceCatalogueID), this.Chk_OverPrint.Checked, num, num1, this.ChkMain, this.ChkMandatory, this.chkAllowWaterMarks.Checked, this.txtWaterMark.Text, Convert.ToInt64(numberOfPages), this.Check_Type, "", "");
                this.objSetting.Insert_In_EtTemplate(Convert.ToInt32(this.UserID), Convert.ToInt32(this.CompanyID), str2, this.FileUpladPdf.FileName, Convert.ToInt64(this.PriceCatalogueID), this.Chk_OverPrint.Checked, num, num1, this.ChkMain, this.ChkMandatory, this.chkAllowWaterMarks.Checked, this.txtWaterMark.Text, Convert.ToInt64(numberOfPages), this.ChkAllowCSV.Checked, this.Check_Type, "", "");
                return;
            }
            commonClass _commonClass = new commonClass();
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@PriceCatalogueID", (object)this.PriceCatalogueID) };
            DataSet dataSet = SQL.ExecuteDataset(this.ConnectionString, CommandType.StoredProcedure, "et_Template_Select_By_PriceCatalogueID", sqlParameter);
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                empty1 = row["PDFName"].ToString();
                empty2 = row["Title"].ToString();
                numberOfPages = Convert.ToInt32(row["TotalPageNumber"].ToString());
                empty3 = row["PDFName"].ToString();
                str3 = row["Title"].ToString();
            }
            this.objSetting.MasterTemplate_Insert(Convert.ToInt64(this.DbID), Convert.ToInt32(this.UserID), Convert.ToInt32(this.CompanyID), empty2, empty1, Convert.ToInt64(this.PriceCatalogueID), this.Chk_OverPrint.Checked, num, num1, this.ChkMain, this.ChkMandatory, this.chkAllowWaterMarks.Checked, this.txtWaterMark.Text, Convert.ToInt64(numberOfPages), this.Check_Type, empty3, str3);
            this.objSetting.Insert_In_EtTemplate(Convert.ToInt32(this.UserID), Convert.ToInt32(this.CompanyID), empty1, empty2, Convert.ToInt64(this.PriceCatalogueID), this.Chk_OverPrint.Checked, num, num1, this.ChkMain, this.ChkMandatory, this.chkAllowWaterMarks.Checked, this.txtWaterMark.Text, Convert.ToInt64(numberOfPages), this.ChkAllowCSV.Checked, this.Check_Type, empty3, str3);
        }

        public void GetDetails(long PriceCatalogueID)
        {
            commonClass _commonClass = new commonClass();
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@PriceCatalogueID", (object)PriceCatalogueID) };
            DataSet dataSet = SQL.ExecuteDataset(this.ConnectionString, CommandType.StoredProcedure, "et_Template_Select_By_PriceCatalogueID", sqlParameter);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string str = EprintConfigurationManager.AppSettings["SecureSitePath"].ToString();
                Label label = this.lblPDF;
                object[] serverName = new object[] { "<a target='_blank' href='", str, ConnectionClass.ServerName, "/editabletemplatebackend/", this.CompanyID, "/pdf/", row["PDFName"].ToString(), "'>", row["Title"].ToString(), "</a>" };
                label.Text = string.Concat(serverName);
                this.lblPDF.Visible = true;
                this.Chk_OverPrint.Checked = Convert.ToBoolean(row["isOverPrintFileRequired"]);
                this.txt_Width.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["CropMarkWidth"].ToString()), 0, "", false, false, false);
                this.txt_height.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["CropMarkHeight"].ToString()), 0, "", false, false, false);
                this.chkAllowWaterMarks.Checked = Convert.ToBoolean(row["isAllowWaterMark"]);
                this.txtWaterMark.Text = row["WaterMarkText"].ToString();
                if (row["PreviewType"].ToString() == "img" && Convert.ToBoolean(row["isAllowPDFPreviews"].ToString()))
                {
                    this.chkImageAllowPreview.Checked = true;
                    if (Convert.ToBoolean(row["isPDFPreviewMandatory"].ToString()))
                    {
                        this.chkImagePreviewMandatory.Checked = true;
                    }
                    this.chkPdfAllowPreview.Enabled = false;
                    this.chkPdfPreviewMandatory.Enabled = false;
                    this.chkPDFImageAllowPreview.Enabled = false;
                    this.chkPDFImagePreviewMandatory.Enabled = false;
                }
                if (row["PreviewType"].ToString() == "pdf" && Convert.ToBoolean(row["isAllowPDFPreviews"].ToString()))
                {
                    this.chkPdfAllowPreview.Checked = true;
                    if (Convert.ToBoolean(row["isPDFPreviewMandatory"].ToString()))
                    {
                        this.chkPdfPreviewMandatory.Checked = true;
                    }
                    this.chkImageAllowPreview.Enabled = false;
                    this.chkImagePreviewMandatory.Enabled = false;
                    this.chkPDFImageAllowPreview.Enabled = false;
                    this.chkPDFImagePreviewMandatory.Enabled = false;
                }
                if (!(row["PreviewType"].ToString() == "pdfimg") || !Convert.ToBoolean(row["isAllowPDFPreviews"].ToString()))
                {
                    continue;
                }
                this.chkPDFImageAllowPreview.Checked = true;
                if (Convert.ToBoolean(row["isPDFPreviewMandatory"].ToString()))
                {
                    this.chkPDFImagePreviewMandatory.Checked = true;
                }
                this.chkImageAllowPreview.Enabled = false;
                this.chkImagePreviewMandatory.Enabled = false;
                this.chkPdfAllowPreview.Enabled = false;
                this.chkPdfPreviewMandatory.Enabled = false;
            }
            DataSet dataSet1 = SettingsBasePage.IsConverted_IsCorped(PriceCatalogueID, Convert.ToInt32(this.DbID));
            foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
            {
                if (!(dataRow["IsConverted"].ToString() == "0") || !(dataRow["isPdforCropMarkChanged"].ToString() == "1"))
                {
                    if (!(dataRow["IsConverted"].ToString() == "2") || !(dataRow["isPdforCropMarkChanged"].ToString() == "1"))
                    {
                        continue;
                    }
                    this.img_pdf.Title = this.objLanguage.GetLanguageConversion("There_is_some_error_while_uploading_PDF_please_contact_support_eprintsoftware_com");
                    this.lblPDF.Visible = false;
                }
                else
                {
                    this.img_pdf.Title = this.objLanguage.GetLanguageConversion("Please_note_the_background_pdf_and_rendering_is_in_process_Please_check_back_in_few_minutes");
                    this.img_pdf.Visible = true;
                    this.lblPDF.Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.chkPdfAllowPreview.Text = this.objLanguage.GetLanguageConversion("Allow_PDF_previews");
            this.chkPdfPreviewMandatory.Text = this.objLanguage.GetLanguageConversion("PDF_previews_mandatory");
            this.chkAllowWaterMarks.Text = this.objLanguage.GetLanguageConversion("Allow_watermarks_to_all_PDF_previews");
            this.Button1.Text = this.objLanguage.GetLanguageConversion("Previous");
            this.nxt.Text = this.objLanguage.GetLanguageConversion("Next");
            this.btnSaveStay.Text = this.objLanguage.GetLanguageConversion("Save_Stay");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            if (base.Request.QueryString["id"] != null)
            {
                this.PriceCatalogueID = Convert.ToInt64(base.Request.QueryString["id"]);
            }
            this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.lbl_widthmeasure.Text = "mm";
            this.lbl_heightmeasure.Text = "mm";
            if (ConnectionClass.ServerName != "")
            {
                this.DbID = SettingsBasePage.SelectDBID((long)this.CompanyID, ConnectionClass.ServerName);
            }
            if (!base.IsPostBack)
            {
                this.GetDetails(this.PriceCatalogueID);
                DataTable dataTable = new DataTable();
                dataTable = SettingsBasePage.AllowCSvEnable(this.PriceCatalogueID, (long)this.CompanyID);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.IsAllowCSV = row["IsAllowCSV"].ToString();
                    this.IsMailMerge = row["IsMailMerge"].ToString();
                }
                if (this.IsMailMerge.ToLower() != "true")
                {
                    this.Div_AllowCSV.Visible = false;
                }
                else
                {
                    this.Div_AllowCSV.Visible = true;
                }
                if (this.IsAllowCSV.ToLower() != "true")
                {
                    this.ChkAllowCSV.Checked = false;
                }
                else
                {
                    this.ChkAllowCSV.Checked = true;
                    this.div_Template1.Attributes.Add("style", "display:none");
                }
                if (WebstoreBasePage.pricecataloguestock_self_select(Convert.ToInt32(this.PriceCatalogueID)).Rows.Count > 0)
                {
                    this.IsStockExist_FromEditable = true;
                }
            }
            this.img_helptext.Title = this.objLanguage.GetLanguageConversion("Note_After_setting_the_dimensions_required_to_hide_the_crop_marks_please_allow_10_minutes_for_the_change_to_take_place");
            this.CSV_helptext.Title = this.objLanguage.GetLanguageConversion("CSV_HelpText");
            if (ConnectionClass.WebStore != null && ConnectionClass.WebStore == "no")
            {
                this.IsWebstore = "no";
            }
            this.btnSaveStay.Attributes.Add("onclick", string.Concat("javascript:var a=EditSavevalidate('", this.IsStockExist_FromEditable, "');if(a)loadingimage(this.id,'div_btnsavestayprocess');return a;"));
            this.btnSave.Attributes.Add("onclick", string.Concat("javascript:var a=EditSavevalidate('", this.IsStockExist_FromEditable, "');if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"));
        }

        public event Editproductsave btnSave_ClickEventHandler;
    }
}