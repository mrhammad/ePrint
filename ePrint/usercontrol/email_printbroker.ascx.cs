using ePrint.ePrintUtilities;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;
namespace ePrint.usercontrol
{
    public partial class email_printbroker : System.Web.UI.UserControl
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string[] stremailArray;

        public string[] stremailArrayBoth;

        public string[] stremailArrayID;

        public string[] stremailArrayBothID;

        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public string strFilepath = global.filePath();

        public languageClass objLanguage = new languageClass();

        public string strUKey;

        public string strSession;

        public string strUID;

        public string strCC;

        public string strBCC;

        public string strSubject;

        public string strAttachment;

        public string sectionname = "";

        public int sectionid;

        public int touserid;

        private string message = string.Empty;

        public string tabcolor = "";

        public int companyid;

        public long EstimateID;

        public string ContactEmail = string.Empty;

        public string EstimateTitle = string.Empty;

        public string EstimateNumber = string.Empty;

        public string DefaultEmailBody = string.Empty;

        public string TemplateKey = string.Empty;

        public string PDFAttachment = string.Empty;

        public int SupplierCount;

        public int SupplierContactID;

        public int UserID;

        public string SupplierName = string.Empty;

        public string EmailText = string.Empty;

        public string openwindow = string.Empty;

        public string SupplierID = string.Empty;

        public string RecordNumber = string.Empty;

        public string ArtWorkAttachment = string.Empty;

        public string TemplateKeynew = string.Empty;

        public BasePage objpage = new BasePage();

        private BaseClass objBase = new BaseClass();

        private CompanyBasePage objComp = new CompanyBasePage();

        private Global gloobj = new Global();

        private commonClass commclass = new commonClass();

        public string pg = string.Empty;

        public long EstimateItemID;

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string SysName = string.Empty;

        public int LastCounter;

        public string Sup_PDFPath = string.Empty;

        public int AttachCount;

        public long AttachmentTypeID;

        public string Str_AttachPath = string.Empty;

        public int UCcount;

        public int UCcount_Attach;

        public int AttachedCount;

        public int CompanyID;

        public long NewTemplateID;

        public string ordid = string.Empty;

        public static StringBuilder StrbuildAttach;

        public string SecureSitePath = global.SecureSitePath();

        public string SecureDocPath = global.SecureDocPath();

        public string SecureDocFilePath = global.SecureDocFilepath();

        public string ServerName = string.Empty;

        public static string statusidonsend = string.Empty;
        public static string statustitleonsend = string.Empty;
       

        public string SecureVirtualPath = global.SecureVirtualPath();

        protected Random rGen;

        protected string[] strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

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

        static email_printbroker()
        {
            email_printbroker.StrbuildAttach = new StringBuilder();
        }

        public email_printbroker()
        {
        }

        public void BindAttach_IsSupplierREQ(long AttachmentTypeID)
        {
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in EstimateBasePage.EmailAttachment_ForSupplierRFQ_Select(this.EstimateID, AttachmentTypeID).Rows)
            {
                string str = row["FileName"].ToString();
                string str1 = row["OriginalFileName"].ToString();
                stringBuilder.Append("<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>");
                object[] objArray = new object[] { "<input type='checkbox'  id='Chk_Attach_", num, "' value='", str, "' title='", str1, "' checked='checked' style='float:left; display:block;'/>", str1 };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("</div>");
                num++;
            }
            HtmlGenericControl divAttach = this.Div_Attach;
            divAttach.InnerHtml = string.Concat(divAttach.InnerHtml, stringBuilder);
        }

        public void BindAttachLink_SupplierRFQ(long AttachmentTypeID)
        {
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in EstimateBasePage.EmailAttachment_ForSupplierRFQ_Select(this.EstimateID, AttachmentTypeID).Rows)
            {
                string str = row["FileName"].ToString();
                string str1 = row["OriginalFileName"].ToString();
                stringBuilder.Append("<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>");
                //object[] objArray = new object[] { "<a href='", this.strSitePath, "ImageHandler_Print.ashx?FileName=", str, "&cid=", this.companyid, "' target='_blank'>", str1, "</a>" };
                string empty = string.Empty;
                empty = this.commclass.ReplaceSplSymbol(str);
                object[] objArray = new object[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(str1), "</a>" };

                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("</div>");
                num++;
            }
            HtmlGenericControl divSuplrAttachLink = this.Div_SuplrAttachLink;
            divSuplrAttachLink.InnerHtml = string.Concat(divSuplrAttachLink.InnerHtml, stringBuilder);
        }

        private void BindDdl(DropDownList ddlAddExisting)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("sp_select_template_ddl", _commonClass.openConnection());
            sqlCommand.Parameters.Add("@Companyid", int.Parse(base.Session["companyid"].ToString()));
            sqlCommand.Parameters.Add("@section", "campaign");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            ddlAddExisting.DataSource = sqlDataReader;
            ddlAddExisting.DataTextField = "templateName";
            ddlAddExisting.DataValueField = "templateID";
            ddlAddExisting.DataBind();
            ddlAddExisting.Items.Insert(0, "");
            ddlAddExisting.Items[0].Text = "Please select template";
            ddlAddExisting.Items[0].Value = "0";
            sqlDataReader.Close();
            _commonClass.closeConnection();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ddlLeadMoreAction.SelectedValue == "6")
            {
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("sp_create_template", _commonClass.openConnection());
                SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@ReturnValue", SqlDbType.Int);
                sqlParameter.Direction = ParameterDirection.Output;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@templatename", this.objBase.SpecialEncode(this.txtAddNew.Text));
                sqlCommand.Parameters.Add("@templateType", this.objBase.SpecialEncode(this.ddltemplateType.SelectedItem.Text));
                sqlCommand.Parameters.Add("@Message", this.objBase.SpecialEncode(this.RadareaEditor.Content));
                sqlCommand.Parameters.Add("@userid", int.Parse(base.Session["userID"].ToString()));
                sqlCommand.Parameters.Add("@companyid", int.Parse(base.Session["companyID"].ToString()));
                sqlCommand.Parameters.Add("@section", "campaign");
                sqlCommand.Parameters.Add("@createdbyid", int.Parse(base.Session["userID"].ToString()));
                sqlCommand.Parameters.Add("@FileName", "");
                sqlCommand.Parameters.Add("@CreateType", "C");
                sqlCommand.ExecuteNonQuery();
                _commonClass.closeConnection();
                if ((int)sqlCommand.Parameters["@ReturnValue"].Value != -1)
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = this.objLanguage.convert("Template has been added");
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = this.objLanguage.convert("Template Name Already Exists");
                }
            }
            else if (this.ddlLeadMoreAction.SelectedValue == "7")
            {
                commonClass _commonClass1 = new commonClass();
                SqlCommand sqlCommand1 = new SqlCommand("sp_update_template", _commonClass1.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand1.Parameters.Add("@templatename", this.objBase.SpecialEncode(this.txtAddNew.Text));
                sqlCommand1.Parameters.Add("@templateType", this.objBase.SpecialEncode(this.ddltemplateType.SelectedItem.Text));
                sqlCommand1.Parameters.Add("@Message", this.objBase.SpecialEncode(this.RadareaEditor.Content));
                sqlCommand1.Parameters.Add("@userid", int.Parse(base.Session["userID"].ToString()));
                sqlCommand1.Parameters.Add("@companyid", int.Parse(base.Session["companyID"].ToString()));
                sqlCommand1.Parameters.Add("@section", "campaign");
                sqlCommand1.Parameters.Add("@createdbyid", int.Parse(base.Session["userID"].ToString()));
                sqlCommand1.Parameters.Add("@FileName", "");
                sqlCommand1.Parameters.Add("@CreateType", "C");
                sqlCommand1.Parameters.Add("@templateID", int.Parse(this.ddlAddExisting.SelectedValue));
                sqlCommand1.ExecuteNonQuery();
                _commonClass1.closeConnection();
                this.lblError.Visible = true;
                this.lblError.Text = this.objLanguage.convert("Template has been updated");
            }
            this.BindDdl(this.ddlAddExisting);
            this.BindDdl(this.ddlselecttemplate);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (this.sectionname == "lead")
            {
                QueryString queryString = new QueryString()
            {
                { "leadid", this.sectionid.ToString() }
            };
                string str = "lead/lead_detail.aspx";
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                str = string.Concat(str, queryString1.ToString());
                base.Response.Redirect(string.Concat(global.sitePath(), str));
                return;
            }
            if (this.sectionname == "client")
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "client/client_view.aspx"));
                return;
            }
            if (this.sectionname.ToLower() == "estimate")
            {
                base.Response.Redirect(string.Concat("../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString()));
                return;
            }
            if (this.sectionname.ToLower() == "printbroker")
            {
                base.Response.Redirect(string.Concat("../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString()));
                return;
            }
            if (this.sectionname.ToLower() == "job")
            {
                base.Response.Redirect(string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString()));
                return;
            }
            if (this.sectionname.ToLower() == "invoice")
            {
                base.Response.Redirect(string.Concat("../invoice/invoice_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString()));
                return;
            }
            if (this.sectionname.ToLower() == "purchase")
            {
                base.Response.Redirect(string.Concat("../purchase/purchase_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString()));
                return;
            }
            if (this.sectionname.ToLower() == "deliverynote")
            {
                base.Response.Redirect(string.Concat("../delivery/delivery_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString()));
                return;
            }
            if (this.sectionname.ToLower() == "jobcard")
            {
                base.Response.Redirect(string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString()));
                return;
            }
            QueryString queryString2 = new QueryString()
        {
            { "contactid", this.sectionid.ToString() }
        };
            string str1 = "contact/contact_detail.aspx";
            QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
            str1 = string.Concat(str1, queryString3.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), str1));
        }

        public void btnsend_Click(object sender, EventArgs e)
        {
        }

        protected void checkMail(string[] filestoattach)
        {
            MailMessage mailMessage = new MailMessage()
            {
                To = "vinay.ms@infomazeapps.com",
                From = "vinay.ms@infomazeapps.com",
                Body = "555555",
                BodyFormat = MailFormat.Html,
                Priority = MailPriority.High
            };
            this.Send_Email(mailMessage, filestoattach);
        }

        protected void ddlselecttemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void ddltemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.hid_body.Value = "";
            this.RadareaEditor.Content = "";
            if (this.ddlEmailTemp.SelectedIndex != 0)
            {
                this.RadareaEditor.Content = string.Empty;
                SqlCommand sqlCommand = new SqlCommand("PC_settings_EmailBodyAndFooterSignature", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", this.companyid);
                sqlCommand.Parameters.AddWithValue("@EmailID", this.ddlEmailTemp.SelectedValue);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    string str = sqlDataReader["Body"].ToString();
                    string str1 = sqlDataReader["FooterText"].ToString();
                    string str2 = sqlDataReader["Subject"].ToString();
                    statusidonsend = sqlDataReader["statusid"].ToString() == "0" ? "" : sqlDataReader["statusid"].ToString();
                    statustitleonsend = sqlDataReader["statustitle"].ToString();
                    if (str1 != null || str1 != "")
                    {
                        this.RadareaEditor.Content = string.Concat(str, this.Div_SuplrAttachLink.InnerHtml, str1);
                        this.txtsubject.Value = str2;
                        this.hid_body.Value = this.RadareaEditor.Content;
                    }
                    else
                    {
                        this.RadareaEditor.Content = str;
                        this.txtsubject.Value = str2;
                        this.hid_body.Value = this.RadareaEditor.Content;
                    }
                    Template template = new Template();
                    DataTable dataTable = template.settings_titlecode_fortemplate_select_for_printbrocker_New(this.companyid, this.EstimateID, base.Request.Params["page"].ToString(), Convert.ToInt32(this.SupplierID), this.SupplierContactID, this.AttachmentTypeID);
                    this.ReplaceAllTags(dataTable, this.TemplateKey, base.Request.Params["page"].ToString());
                    RadEditor radareaEditor = this.RadareaEditor;
                    string content = this.RadareaEditor.Content;
                    string[] supPDFPath = new string[] { "<a href=", this.Sup_PDFPath, " runat='server'>", this.Sup_PDFPath, " </a>" };
                    radareaEditor.Content = content.Replace("[$PDFPath$]", string.Concat(supPDFPath));
                }
            }
        }

        protected void ddltemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddltemplateType.SelectedValue == "1")
            {
                this.pnlScriptEditor.Visible = true;
                return;
            }
            this.pnlScriptEditor.Visible = false;
        }

        public void DownloadPDF()
        {
            string str = string.Concat(this.strFilepath, "tempattachment\\", this.txtattachment.Value);
            base.Response.Write(str);
            base.Response.ClearContent();
            base.Response.ClearHeaders();
            base.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", this.txtattachment.Value));
            base.Response.ContentType = "application/octet-stream";
            base.Response.WriteFile(str);
            base.Response.Flush();
            base.Response.Close();
        }

        public string GenPassWithCap(int i)
        {
            this.rGen = new Random();
            int num = 0;
            string str = "";
            for (int i1 = 0; i1 <= i; i1++)
            {
                num = this.rGen.Next(0, 60);
                str = string.Concat(str, this.strCharacters[num]);
            }
            return str;
        }

        protected void lnkDownloadPDF_OnClick(object sender, EventArgs e)
        {
            for (int i = 1; i <= this.SupplierCount; i++)
            {
                object[] value = new object[] { this.hid_EstimateNumber.Value, "_", i, "_", this.hid_TemplateKey.Value, ".pdf" };
                string str = string.Concat(value);
                SettingsBasePage.settings_template_emailed_insert(str, string.Concat(i, "_", this.hid_TemplateKey.Value), (long)Convert.ToInt32(base.Session["CompanyID"]));
            }
        }

        public void LoadDefaultTemplateType()
        {
            string lower = base.Request.Params["page"].ToString().ToLower();
            if (lower == "purchase")
            {
                lower = "Purchase Order";
            }
            else if (lower == "note")
            {
                lower = "Delivery Note";
            }
            else if (lower == "printbroker")
            {
                lower = "Supplier RFQ";
            }
            this.RadareaEditor.Content = string.Empty;
            SqlCommand sqlCommand = new SqlCommand("PC_settings_EmailBodyTemplatetype_Select", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.companyid);
            sqlCommand.Parameters.AddWithValue("@TemplateType", lower);
            sqlCommand.Parameters.AddWithValue("@userId", this.UserID);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["Isdefault"].ToString().ToLower() == "false")
                {
                    this.RadareaEditor.Content = "";
                }
                else
                {
                    this.objBase.SetDDLValue(this.ddlEmailTemp, sqlDataReader["EmailID"].ToString());
                    this.objBase.SetDDLValue(this.ddltemplateType, sqlDataReader["EmailID"].ToString());
                }
            }
        }

        public void LoadEmailBodyAndSignature()
        {
            this.LoadDefaultTemplateType();
            this.LoadEmailTemplateType();
            string lower = base.Request.Params["page"].ToString().ToLower();
            if (lower == "purchase")
            {
                lower = "Purchase Order";
            }
            else if (lower == "note")
            {
                lower = "Delivery Note";
            }
            else if (lower == "printbroker")
            {
                lower = "Supplier RFQ";
            }
            this.RadareaEditor.Content = string.Empty;
            SqlCommand sqlCommand = new SqlCommand("PC_select_defaultEmailAndSignature", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.companyid);
            try
            {
                sqlCommand.Parameters.AddWithValue("@EmailID", Convert.ToInt32(this.ddlEmailTemp.SelectedValue));
            }
            catch
            {
                sqlCommand.Parameters.AddWithValue("@EmailID", 0);
            }
            sqlCommand.Parameters.AddWithValue("@TemplateType", lower);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                this.hdnSupEmailBody.Value = sqlDataReader["Body"].ToString();
                this.hdn_SupEmailFooter.Value = sqlDataReader["FooterText"].ToString();
                this.RadareaEditor.Content = string.Concat(sqlDataReader["Body"].ToString(), this.Div_SuplrAttachLink.InnerHtml, " ", sqlDataReader["FooterText"].ToString());
                this.txtsubject.Value = sqlDataReader["Subject"].ToString();
                this.hid_body.Value = string.Concat(sqlDataReader["Body"].ToString(), this.Div_SuplrAttachLink.InnerHtml, " ", sqlDataReader["FooterText"].ToString());
                this.objBase.SetDDLValue(this.ddlEmailTemp, sqlDataReader["EmailID"].ToString());
                statusidonsend = sqlDataReader["statusid"].ToString() == "0" ? "" : sqlDataReader["statusid"].ToString();
                statustitleonsend = sqlDataReader["statustitle"].ToString();
            }
        }

        public void LoadEmailTemplateType()
        {
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailbody_select", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.companyid);
            sqlCommand.Parameters.AddWithValue("@Type", this.companyid);
            this.ddltemplateType.DataSource = sqlCommand.ExecuteReader();
            this.ddltemplateType.DataValueField = "EmailID";
            this.ddltemplateType.DataTextField = "TemplateType";
            this.ddltemplateType.DataBind();
            this.ddltemplateType.Items.Insert(0, "--- Select ---");
            this.ddltemplateType.SelectedIndex = 0;
        }

        public void LoadTemplateNameDDL()
        {
            string lower = base.Request.Params["page"].ToString().ToLower();
            if (lower == "purchase")
            {
                lower = "Purchase Order";
            }
            else if (lower == "note")
            {
                lower = "Delivery Note";
            }
            else if (lower == "printbroker")
            {
                lower = "Supplier RFQ";
            }
            SqlCommand sqlCommand = new SqlCommand("PC_Select_EmailTemplateName", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@userId", this.UserID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.companyid);
            sqlCommand.Parameters.AddWithValue("@TemplateType", lower);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                dataTable.Load(dataReader);
            }
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!row.Table.Columns.Contains("TemplateName"))
                    {
                        continue;
                    }
                    row["TemplateName"] = this.objBase.SpecialDecode(row["TemplateName"].ToString());
                }
            }
            this.ddlEmailTemp.DataSource = dataTable;
            this.ddlEmailTemp.DataValueField = "EmailID";
            this.ddlEmailTemp.DataTextField = "TemplateName";
            this.ddlEmailTemp.DataBind();
            this.ddlEmailTemp.Items.Insert(0, "--- Select ---");
            this.ddlEmailTemp.Items[0].Value = "0";
            this.ddlEmailTemp.SelectedIndex = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", base.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            string[] strArrays1 = strArrays;
            this.RadareaEditor.ImageManager.UploadPaths = strArrays1;
            this.RadareaEditor.ImageManager.ViewPaths = strArrays1;
            this.RadareaEditor.FlashManager.ViewPaths = strArrays1;
            this.RadareaEditor.FlashManager.UploadPaths = strArrays1;
            this.RadareaEditor.DocumentManager.ViewPaths = strArrays1;
            this.RadareaEditor.DocumentManager.UploadPaths = strArrays1;
            this.RadareaEditor.Height = Unit.Pixel(300);
            this.RadareaEditor.Width = Unit.Pixel(700);
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadareaEditor.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            this.companyid = int.Parse(base.Session["companyid"].ToString());
            this.tabcolor = this.objpage.colorCode(this.companyid, base.Request.Params["sectionname"]);
            commonClass _commonClass = new commonClass();
            this.EstimateID = Convert.ToInt64(base.Request.Params["EstID"].ToString());
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"].ToString());
            this.NewTemplateID = Convert.ToInt64(base.Request.QueryString["TemplateID"]);
            this.ordid = (base.Request.Params["ordid"] != null ? base.Request.Params["ordid"].ToString() : "0");
            this.sectionid = int.Parse(base.Request.Params["sectionid"].ToString());
            this.sectionname = base.Request.Params["sectionname"].ToString();
            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", base.Session["CompanyID"].ToString(), "/attachments/" };
            this.Str_AttachPath = string.Concat(secureDocPath);
            this.UCcount_Attach = this.UCcount;
            if (base.Request.Url.ToString().ToLower().Contains("occy.eprintsoftware.com"))
            {
                this.SysName = "occy";
            }
            if (base.Request.Url.ToString().ToLower().Contains("estimates"))
            {
                this.pg = "Estimate";
            }
            this.lblSupplierID.Text = this.SupplierID;
            this.lnk_AttachUpdate.Text = this.SupplierID;
            string str = string.Concat("../common/attachfile.aspx?pg=", this.sectionname);
            this.openwindow = string.Concat("../Common/email_Contact.aspx?sectionid=", this.lblSupplierID.Text, "&sectionname=", this.sectionname);
            this.imgselectleadcc.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", this.openwindow, "', 'MarketingEmail','width=800,height=600,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=250,top=100');SetRadWindow('divrad', 'divBackGroundNew', '200'); return false;"));
            this.imgselectleadbcc.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", this.openwindow, "', 'MarketingEmail','width=800,height=600,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=250,top=100');SetRadWindow('divrad', 'divBackGroundNew', '200'); return false;"));
            this.LinkButton1.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", str, "','730','400');SetRadWindow('divrad', 'divBackGroundNew', '200');return false;"));
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.settings_emailsetting_select(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()));
                foreach (DataRow row in dataTable.Rows)
                {
                    if (Convert.ToBoolean(row["IsSuplierRFQ_AttachAll"]))
                    {
                        this.BindAttach_IsSupplierREQ(this.AttachmentTypeID);
                    }
                    if (!Convert.ToBoolean(row["Supplier_AttachLink"]))
                    {
                        continue;
                    }
                    this.BindAttachLink_SupplierRFQ(this.AttachmentTypeID);
                }
            }
            if (!base.IsPostBack)
            {
                this.LoadTemplateNameDDL();
                this.LoadEmailBodyAndSignature();
                this.btncancel.Text = this.objLanguage.convert(this.btncancel.Text);
                this.btnsend.Text = this.objLanguage.convert(this.btnsend.Text);
                this.Label1.Text = this.objLanguage.convert(this.Label1.Text);
                this.Label2.Text = this.objLanguage.convert(this.Label2.Text);
                this.Label3.Text = this.objLanguage.convert(this.Label3.Text);
                this.Label4.Text = this.objLanguage.convert(this.Label4.Text);
                this.lblassigned.Text = this.objLanguage.convert(this.lblassigned.Text);
                this.imgselectleadmain.ImageUrl = string.Concat(global.imagePath(), "plus.gif");
                this.imgselectleadcc.ImageUrl = string.Concat(global.imagePath(), "plus.gif");
                this.imgselectleadbcc.ImageUrl = string.Concat(global.imagePath(), "plus.gif");
                this.imgselectleadmain.ToolTip = this.objLanguage.convert("Select email");
                this.imgselectleadcc.ToolTip = this.objLanguage.convert("Select email");
                this.imgselectleadbcc.ToolTip = this.objLanguage.convert("Select email");
                this.ddlLeadMoreAction.Attributes.Add("onchange", "javascript:OpenPopUp();");
                this.pnlScriptEditor.Visible = true;
            }
            this.objLanguage.Dispose();
            if (!base.IsPostBack)
            {
                this.BindDdl(this.ddlAddExisting);
                this.BindDdl(this.ddlselecttemplate);
            }
            string str1 = this.sectionname;
            string str2 = str1;
            if (str1 != null)
            {
                switch (str2)
                {
                    case "lead":
                        {
                            QueryString queryString = new QueryString()
                    {
                        { "leadid", this.sectionid.ToString() },
                        { "isnew", "2" }
                    };
                            string str3 = "../lead/lead_detail.aspx";
                            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                            str3 = string.Concat(str3, queryString1.ToString());
                            break;
                        }
                    case "contact":
                        {
                            QueryString queryString2 = new QueryString()
                    {
                        { "contactid", this.sectionid.ToString() },
                        { "isnew", "2" }
                    };
                            string str4 = "../contact/contact_detail.aspx";
                            QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                            str4 = string.Concat(str4, queryString3.ToString());
                            break;
                        }
                    case "client":
                        {
                            QueryString queryString4 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            string str5 = "../client/client_detail.aspx";
                            QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
                            str5 = string.Concat(str5, queryString5.ToString());
                            break;
                        }
                    case "Estimate":
                        {
                            QueryString queryString6 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            string str6 = string.Concat("../estimate/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString7 = Encryption.EncryptQueryString(queryString6);
                            str6 = string.Concat(str6, queryString7.ToString());
                            break;
                        }
                    case "Job":
                        {
                            QueryString queryString8 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            string str7 = string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString9 = Encryption.EncryptQueryString(queryString8);
                            str7 = string.Concat(str7, queryString9.ToString());
                            break;
                        }
                    case "Invoice":
                        {
                            QueryString queryString10 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            string str8 = string.Concat("../invoice/invoice_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString11 = Encryption.EncryptQueryString(queryString10);
                            str8 = string.Concat(str8, queryString11.ToString());
                            break;
                        }
                    case "DeliveryNote":
                        {
                            QueryString queryString12 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            string str9 = string.Concat("../delivery/delivery_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
                            QueryString queryString13 = Encryption.EncryptQueryString(queryString12);
                            str9 = string.Concat(str9, queryString13.ToString());
                            break;
                        }
                    case "Purchase":
                        {
                            QueryString queryString14 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            string str10 = string.Concat("../purchase/purchase_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
                            QueryString queryString15 = Encryption.EncryptQueryString(queryString14);
                            str10 = string.Concat(str10, queryString15.ToString());
                            break;
                        }
                    case "JobCard":
                        {
                            QueryString queryString16 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            string str11 = string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString17 = Encryption.EncryptQueryString(queryString16);
                            str11 = string.Concat(str11, queryString17.ToString());
                            break;
                        }
                    case "PrintBroker":
                        {
                            QueryString queryString18 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            this.RecordNumber = CompanyBasePage.get_module_number(this.companyid, "Estimate", Convert.ToInt32(base.Request.Params["EstID"].ToString()));
                            string str12 = string.Concat("../estimate/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString19 = Encryption.EncryptQueryString(queryString18);
                            str12 = string.Concat(str12, queryString19.ToString());
                            break;
                        }
                    default:
                        {
                            goto Label0;
                        }
                }
            }
            else
            {
                goto Label0;
            }
        Label1:
            if (!base.IsPostBack)
            {
                Template template = new Template();
                DataTable dataTable1 = template.settings_titlecode_fortemplate_select_for_printbrocker_New(this.companyid, this.EstimateID, base.Request.Params["page"].ToString(), Convert.ToInt32(this.SupplierID), this.SupplierContactID, this.AttachmentTypeID);
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    this.EstimateTitle = dataRow["Title"].ToString();
                    this.hid_subject.Value = dataRow["Title"].ToString();
                    this.EstimateNumber = dataRow["Number"].ToString();
                }
                this.hid_EstimateNumber.Value = this.EstimateNumber;
                this.lblSupplierName.Text = this.objBase.SpecialDecode(this.SupplierName);
                this.txtfirstname.Value = this.objBase.SpecialDecode(this.ContactEmail);
                if (this.sectionname.ToLower() != "printbroker")
                {
                    this.txtattachment.Value = string.Concat(this.EstimateNumber, ".pdf");
                }
                else
                {
                    this.txtattachment.Value = string.Concat(this.PDFAttachment, this.ArtWorkAttachment);
                }
                this.hid_TemplateKey.Value = this.TemplateKey;
                this.ReplaceAllTags(dataTable1, this.TemplateKey, base.Request.Params["page"].ToString());
                RadEditor radareaEditor = this.RadareaEditor;
                string content = this.RadareaEditor.Content;
                string[] supPDFPath = new string[] { "<a href=", this.Sup_PDFPath, " runat='server'>", this.Sup_PDFPath, " </a>" };
                radareaEditor.Content = content.Replace("[$PDFPath$]", string.Concat(supPDFPath));
                this.hid_EmailTemplateValue.Value = this.EmailText;
                DataTable dataTable2 = SettingsBasePage.settings_emailsetting_select(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()));
                foreach (DataRow row1 in dataTable2.Rows)
                {
                    this.hid_EmailSettingType.Value = row1["EmailSettingType"].ToString();
                    if (Convert.ToBoolean(row1["IsCheckedCC"]) && row1["cc"].ToString().Length > 0)
                    {
                        if (this.txtcc.Value.Length <= 0)
                        {
                            this.txtcc.Value = this.objBase.SpecialDecode(row1["cc"].ToString());
                        }
                        else
                        {
                            HtmlTextArea htmlTextArea = this.txtcc;
                            htmlTextArea.Value = string.Concat(htmlTextArea.Value, ",", this.objBase.SpecialDecode(row1["cc"].ToString()));
                        }
                    }
                    if (!Convert.ToBoolean(row1["IsCheckedBCC"]) || row1["bcc"].ToString().Length <= 0)
                    {
                        continue;
                    }
                    if (this.txtbcc.Value.Length <= 0)
                    {
                        this.txtbcc.Value = this.objBase.SpecialDecode(row1["bcc"].ToString());
                    }
                    else
                    {
                        HtmlTextArea htmlTextArea1 = this.txtbcc;
                        htmlTextArea1.Value = string.Concat(htmlTextArea1.Value, ",", this.objBase.SpecialDecode(row1["bcc"].ToString()));
                    }
                }
                this.pnl_ShowEmailType.Visible = true;
            }
            return;
        Label0:
            base.Response.Redirect(global.sitePath());
            goto Label1;
        }

        private void ReplaceAllTags(DataTable dt, string TemplateKey, string ModuleName)
        {
            commonClass _commonClass = new commonClass();
            string[] strArrays = null;
            string[] strArrays1 = null;
            StringBuilder stringBuilder = new StringBuilder();
            string content = this.RadareaEditor.Content;
            string value = this.txtsubject.Value;
            string str = string.Concat(base.Session["firstName"].ToString(), " ", base.Session["lastName"].ToString());
            DataRow item = dt.Rows[0];
            if (content.Contains("[$AttachmentsPath$]"))
            {
                if (item["FileName"].ToString() != "")
                {
                    strArrays = item["FileName"].ToString().Split(new char[] { ',' });
                }
                if (item["OriginalFileName"].ToString() != "")
                {
                    strArrays1 = item["OriginalFileName"].ToString().Split(new char[] { ',' });
                }
                if (strArrays != null && strArrays1 != null)
                {
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        if (stringBuilder.Length != 0)
                        {
                            string[] strArrays2 = new string[] { "<a href=", this.strSitePath, "DocManager.ashx?doctype=attachments&filename=", strArrays[i], " target='_blank'>", strArrays1[i], "</a><br />" };
                            stringBuilder.Append(string.Concat(strArrays2));
                        }
                        else
                        {
                            string[] strArrays3 = new string[] { "<br /><a href=", this.strSitePath, "DocManager.ashx?doctype=attachments&filename=", strArrays[i], " target='_blank'>", strArrays1[i], "</a><br />" };
                            stringBuilder.Append(string.Concat(strArrays3));
                        }
                    }
                }
                content = (stringBuilder.Length != 0 ? content.Replace("[$AttachmentsPath$]", stringBuilder.ToString()) : content.Replace("[$AttachmentsPath$]", ""));
            }
            content = content.Replace("[$EmailFooter$]", str);
            content = content.Replace("[$EstimateTitle$]", item["EstimateTitle"].ToString());
            content = content.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
            content = content.Replace("[$SupplierContactFirstName$]", item["SupplierContactFirstName"].ToString());
            content = content.Replace("[$SupplierContactLastName$]", item["SupplierContactLastName"].ToString());
            content = content.Replace("[$SupplierContactFullName$]", item["SupplierContactFullName"].ToString());
            content = content.Replace("[$SupplierContactEmail$]", item["SupplierContactEmail"].ToString());
            content = content.Replace("[$SupplierName$]", item["SupplierName"].ToString());
            content = content.Replace("[$EstimateDate$]", _commonClass.Eprint_return_Date_Before_View(item["EstimateDate"].ToString(), this.companyid, 0, false));
            content = content.Replace("[$EstimatedArtwork$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedArtwork"].ToString(), this.companyid, 0, false));
            content = content.Replace("[$EstimatedDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedDelivery"].ToString(), this.companyid, 0, false));
            content = content.Replace("[$ValidFor$]", item["ValidFor"].ToString());
            content = content.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
            content = content.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
            content = content.Replace("[$EstimateHeader$]", item["EstimateHeader"].ToString());
            content = content.Replace("[$EstimateFooter$]", item["EstimateFooter"].ToString());
            content = content.Replace("[$EstimateValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["EstimateValue"].ToString()), 0, "", false, false, true));
            content = content.Replace("[$RFQReturnDate]", _commonClass.Eprint_return_Date_Before_View(item["RFQReturnDate"].ToString(), this.companyid, 0, false));
            content = content.Replace("[$RFQReturnTime]", item["RFQReturntime"].ToString().Trim());

            content = Utilities.ReplaceConsigneeUrlTags(item, content);

            value = value.Replace("[$EmailFooter$]", str);
            value = value.Replace("[$EstimateTitle$]", item["EstimateTitle"].ToString());
            value = value.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
            value = value.Replace("[$SupplierContactFirstName$]", item["SupplierContactFirstName"].ToString());
            value = value.Replace("[$SupplierContactLastName$]", item["SupplierContactLastName"].ToString());
            value = value.Replace("[$SupplierContactFullName$]", item["SupplierContactFullName"].ToString());
            value = value.Replace("[$SupplierContactEmail$]", item["SupplierContactEmail"].ToString());
            value = value.Replace("[$SupplierName$]", item["SupplierName"].ToString());
            value = value.Replace("[$EstimateDate$]", _commonClass.Eprint_return_Date_Before_View(item["EstimateDate"].ToString(), this.companyid, 0, false));
            value = value.Replace("[$EstimatedArtwork$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedArtwork"].ToString(), this.companyid, 0, false));
            value = value.Replace("[$EstimatedDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedDelivery"].ToString(), this.companyid, 0, false));
            value = value.Replace("[$ValidFor$]", item["ValidFor"].ToString());
            value = value.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
            value = value.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
            value = value.Replace("[$EstimateHeader$]", item["EstimateHeader"].ToString());
            value = value.Replace("[$EstimateFooter$]", item["EstimateFooter"].ToString());
            value = value.Replace("[$EstimateValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["EstimateValue"].ToString()), 0, "", false, false, true));
            value = value.Replace("[$RFQReturnDate]", _commonClass.Eprint_return_Date_Before_View(item["RFQReturnDate"].ToString(), this.companyid, 0, false));
            value = value.Replace("[$RFQReturnTime]", item["RFQReturnTime"].ToString().Trim());

            string[] str1 = new string[] { " <a href='", this.strSitePath, "Supplier/SupplierQuote.aspx?KeyCD=", item["KeyCode"].ToString(), "'> ", this.strSitePath, "Supplier/SupplierQuote.aspx?KeyCD=", item["KeyCode"].ToString(), " </a>" };
            content = content.Replace("[$QuoteLink$]", string.Concat(str1));
            this.RadareaEditor.Content = this.objBase.SpecialDecode(content);
            this.txtsubject.Value = this.objBase.SpecialDecode(value.Replace("`", "'"));
            this.hid_body.Value = content;
        }

        protected void Send_Email(MailMessage MailMsg, string[] filestoattach)
        {
            string.IsNullOrEmpty(global.SmtpServerName());
            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            try
            {
                SmtpMail.Send(MailMsg);
            }
            catch
            {
            }
        }

        public void updateEstimateStatus(int EstimateID, int statusid)
        {


            SqlCommand sqlCommand = new SqlCommand("Update tb_estimate set StatusID=@statusid where estimateid=@EstimateID; update tb_EstimateItem set EstimateItemStatusID=@statusid where estimateid=@EstimateID", (new commonClass()).openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.Parameters.AddWithValue("@EstimateID", EstimateID);
            sqlCommand.Parameters.AddWithValue("@statusid", statusid);
            sqlCommand.ExecuteNonQuery();

        }

        public void sendemail()
        {
            string str;
            string str1 = this.objBase.SpecialEncode(this.txtcc.Value);
            string str2 = this.objBase.SpecialEncode(this.txtbcc.Value);
            string str3 = this.objBase.SpecialEncode(this.txtsubject.Value);
            string str4 = this.objBase.SpecialEncode(this.txtattachment.Value);
            this.message = this.objBase.SpecialEncode(this.RadareaEditor.Content);
            string empty = string.Empty;
            string empty1 = string.Empty;
            empty = (EprintConfigurationManager.AppSettings["FromEmailConfig"].ToString() != "1" ? HttpContext.Current.Session["email"].ToString() : EprintConfigurationManager.AppSettings["FromEmail"].ToString());
            try
            {
                SettingsBasePage.Settings_fromemail_get(Convert.ToInt32(HttpContext.Current.Session["CompanyID"].ToString()));
            }
            catch
            {
            }
            string empty2 = string.Empty;
            string str5 = this.message;
            int num = str5.IndexOf("KeyCD=");
            if (num != -1)
            {
                empty2 = str5.Substring(num, 22);
                empty2 = empty2.Remove(0, 6);
            }
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            num3 = (this.ddlLeadMoreAction.SelectedValue != "1" ? 0 : 1);
            if (this.ddlLeadMoreAction.SelectedValue != "1")
            {
                str = "";
            }
            else
            {
                str = this.objBase.ReplaceSingleQuote(this.ddlselecttemplate.SelectedItem.Text);
                int.Parse(this.ddlselecttemplate.SelectedItem.Value);
            }

            if (!String.IsNullOrEmpty(statusidonsend))
            {
                this.updateEstimateStatus(Convert.ToInt32(this.EstimateID), Convert.ToInt32(statusidonsend));
                statusidonsend = "";
            }

            int value = 0;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_insertEmail_WithKeyCode", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@pg", "Estimates");
            sqlCommand.Parameters.AddWithValue("@id", this.SupplierID);
            sqlCommand.Parameters.AddWithValue("@toUserID", 0);
            sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(base.Session["companyID"].ToString()));
            sqlCommand.Parameters.AddWithValue("@CC", this.objBase.SpecialEncode(str1));
            sqlCommand.Parameters.AddWithValue("@BCC", this.objBase.SpecialEncode(str2));
            sqlCommand.Parameters.AddWithValue("@subject", this.objBase.SpecialEncode(str3));
            sqlCommand.Parameters.AddWithValue("@attachment", this.objBase.SpecialEncode(str4));
            sqlCommand.Parameters.AddWithValue("@message", this.objBase.SpecialEncode(this.message));
            sqlCommand.Parameters.AddWithValue("@fromUserID", int.Parse(base.Session["userID"].ToString()));
            SqlParameterCollection parameters = sqlCommand.Parameters;
            DateTime now = DateTime.Now;
            parameters.AddWithValue("@dateSent", now.ToString());
            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            DateTime dateTime = DateTime.Now;
            sqlParameterCollection.AddWithValue("@dateOpened", dateTime.ToString());
            sqlCommand.Parameters.AddWithValue("@isRead", num2);
            sqlCommand.Parameters.AddWithValue("@noOfView", num1);
            SqlParameterCollection parameters1 = sqlCommand.Parameters;
            DateTime now1 = DateTime.Now;
            parameters1.AddWithValue("@lastViewDate", now1.ToString());
            sqlCommand.Parameters.AddWithValue("@istemplate", num3);
            sqlCommand.Parameters.AddWithValue("@templatename", str);
            sqlCommand.Parameters.AddWithValue("@TO", this.objBase.SpecialEncode(this.txtfirstname.Value));
            sqlCommand.Parameters.AddWithValue("@sectionnumber", this.RecordNumber.ToString());
            sqlCommand.Parameters.AddWithValue("@KeyCode", empty2);
            sqlCommand.Parameters.AddWithValue("@EmailSentBy", Convert.ToInt64(base.Session["UserID"].ToString()));
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            _commonClass.Dispose();
            value = (int)sqlCommand.Parameters["ReturnValue"].Value;
            commonClass _commonClass1 = new commonClass();
            SqlCommand sqlCommand1 = new SqlCommand("crm_select_leadsHTMLEmail", _commonClass1.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand1.Parameters.AddWithValue("@companyid", int.Parse(base.Session["companyid"].ToString()));
            SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader();
            while (sqlDataReader.Read())
            {
                empty = sqlDataReader["leadsHTMLEmail"].ToString();
            }
            sqlDataReader.Close();
            sqlDataReader.Dispose();
            _commonClass1.closeConnection();
            _commonClass1.Dispose();
            if (empty == "")
            {
                empty = base.Session["email"].ToString();
            }
            Directory.GetFiles(string.Concat(base.Server.MapPath("../"), "tempattachment\\"));
            string empty3 = string.Empty;
            if (this.txtfirstname.Value != "")
            {
                string str6 = this.objBase.ReplaceSingleQuote(this.txtfirstname.Value.ToString());
                char[] chrArray = new char[] { ',' };
                this.stremailArray = str6.Split(chrArray);
            }
            for (int i = 0; i < (int)this.stremailArray.Length; i++)
            {
                commonClass _commonClass2 = new commonClass();
                string empty4 = string.Empty;
                empty4 = this.message;
                empty3 = "Lead";
                SqlCommand sqlCommand2 = new SqlCommand("crm_campaign_selectDataTemplate", _commonClass2.openConnection());
                sqlCommand2.Parameters.Add("@sectionid", this.sectionid);
                sqlCommand2.Parameters.Add("@emailtype", empty3);
                sqlCommand2.Parameters.Add("@CompanyID", base.Session["companyID"].ToString());
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlDataReader1.Read())
                {
                    empty4 = empty4.Replace("[$leadsalutation$]", sqlDataReader1["salutation"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadfirstname$]", sqlDataReader1["firstName"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadlastname$]", sqlDataReader1["lastName"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadcompanyname$]", sqlDataReader1["companyName"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadtitle$]", sqlDataReader1["title"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadindustryname$]", sqlDataReader1["industryName"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadphone$]", sqlDataReader1["phone"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadmobile$]", sqlDataReader1["mobile"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadfax$]", sqlDataReader1["fax"].ToString().Trim());
                    empty4 = empty4.Replace("[$leademail$]", sqlDataReader1["email"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadwebsite$]", sqlDataReader1["website"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadstreet$]", sqlDataReader1["street"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadcity$]", sqlDataReader1["city"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadstate$]", sqlDataReader1["state"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadzip$]", sqlDataReader1["zip"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadcountry$]", sqlDataReader1["country"].ToString().Trim());
                    empty4 = empty4.Replace("[$leadleadalias$]", sqlDataReader1["leadalias"].ToString().Trim());
                }
                sqlDataReader1.Close();
                _commonClass2.closeConnection();
                string str7 = this.GenPassWithCap(24).ToString();
                SqlCommand sqlCommand3 = new SqlCommand("crm_campaign_insertmarketingEmail", _commonClass2.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter sqlParameter1 = sqlCommand3.Parameters.AddWithValue("ReturnMarketingIdValue", SqlDbType.Int);
                sqlParameter1.Direction = ParameterDirection.ReturnValue;
                sqlCommand3.Parameters.AddWithValue("@commonemailid", value);
                sqlCommand3.Parameters.AddWithValue("@email", this.stremailArray[i].ToString());
                sqlCommand3.Parameters.AddWithValue("@verificationnumber", str7);
                sqlCommand3.Parameters.AddWithValue("@emailtype", empty3);
                sqlCommand3.Parameters.AddWithValue("@message", empty4);
                sqlCommand3.Parameters.AddWithValue("@ToUserID", 0);
                sqlCommand3.Parameters.AddWithValue("@companyID", base.Session["companyID"].ToString());
                sqlCommand3.ExecuteNonQuery();
                _commonClass2.closeConnection();
                _commonClass2.Dispose();
                int value1 = (int)sqlCommand3.Parameters["ReturnMarketingIdValue"].Value;
                string empty5 = string.Empty;
                this.hid_FileNames.Value.Split(new char[] { 'µ' });
                string empty6 = string.Empty;
                if (this.hdnEmailAttachment_ActualName.Value.Length > 0)
                {
                    string[] strArrays = this.hdnEmailAttachment_ActualName.Value.Split(new char[] { '~' });
                    for (int j = 0; j < (int)strArrays.Length - 1; j++)
                    {
                        string str8 = empty6;
                        string[] strAttachPath = new string[] { str8, this.Str_AttachPath, "\\", strArrays[j].ToString(), "µ" };
                        empty6 = string.Concat(strAttachPath);
                    }
                }
                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "\\", this.companyid, "\\sentpdf\\", null, null, null };
                BaseClass baseClass = this.objBase;
                char[] chrArray1 = new char[] { ',' };
                secureDocPath[5] = baseClass.ReplaceSingleQuote(str4.Split(chrArray1)[0]);
                secureDocPath[6] = "µ";
                secureDocPath[7] = empty6;
                string str9 = string.Concat(secureDocPath);
                string empty7 = string.Empty;
                if (this.ArtWorkAttachment != "")
                {
                    string str10 = string.Concat(this.strFilepath, "Document\\", base.Session["CompanyID"].ToString(), "\\");
                    string[] strArrays1 = this.ArtWorkAttachment.Split(new char[] { ',' });
                    for (int k = 1; k < (int)strArrays1.Length; k++)
                    {
                        empty7 = string.Concat(empty7, str10, strArrays1[k].ToString(), "µ");
                    }
                }
                if (this.stremailArray[i].ToString() != "")
                {
                    str2 = string.Concat("emaillogs@hexicomsoftware.com,", this.txtbcc.Value);
                    BaseClass.SendMailMessage(empty, this.stremailArray[i].ToString().Trim(), this.objBase.SpecialEncode(str2), this.objBase.SpecialEncode(this.txtcc.Value), this.objBase.SpecialEncode(this.txtsubject.Value), this.objBase.SpecialEncode(this.RadareaEditor.Content), string.Concat(str9, empty7), true);
                }
               
            }
        }
    }
}