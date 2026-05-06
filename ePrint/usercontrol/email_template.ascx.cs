using ePrint.ePrintUtilities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Estimates;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;

namespace ePrint.usercontrol
{
    public partial class email_template : System.Web.UI.UserControl
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string[] stremailArray;

        public string[] stremailArrayPlain;

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

        public int UserID;

        public long EstimateID;

        public Int32 ProofID;

        public string ContactEmail = string.Empty;

        public string EstimateTitle = string.Empty;

        public string EstimateNumber = string.Empty;

        public string DefaultEmailBody = string.Empty;

        public string TemplateKey = string.Empty;

        public string RecordNumber = string.Empty;

        public BasePage objpage = new BasePage();

        private BaseClass objBase = new BaseClass();

        private CompanyBasePage objComp = new CompanyBasePage();

        private Global gloobj = new Global();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private commonClass commclass = new commonClass();

        public long NewTemplateID;

        public string ordid = string.Empty;

        public string SysName = string.Empty;

        public string pg = string.Empty;

        public string Str_AttachPath = string.Empty;

        public int count;

        public long AttachmenttypeID;

        public string CompanyType = string.Empty;

        public string PageType = string.Empty;

        public int EstID;

        public string RedirectPath = string.Empty;

        public string StrDownload = string.Empty;

        public string strDeliveryIDs = string.Empty;

        public string ServerName = string.Empty;

        public string SecureDocPath = global.SecureDocPath();

        public string SecureSitePath = global.SecureSitePath();

        public string OrderHeight = string.Empty;

        public string OrderWidth = string.Empty;

        public string ProductHeight = string.Empty;

        public string ProductWidth = string.Empty;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        private string Items = string.Empty;

        private string IS_INVOICEorJOB_from_Webstore = string.Empty;

        protected Random rGen;

        protected Template objTemplates = new Template();

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

        public email_template()
        {
        }

        public void Bind_Attachment_Purchase()
        {
            int num = 0;
            DataTable dataTable = EstimateBasePage.EstimateItemID_Select(this.companyid, this.UserID, this.EstimateID);
            foreach (DataRow row in dataTable.Rows)
            {
                this.AttachmenttypeID = Convert.ToInt64(row["Estimateitemid"].ToString());
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow dataRow in EstimateBasePage.Purchase_PurchaseID_Select(this.EstimateID, this.AttachmenttypeID).Rows)
            {
                string str = dataRow["FileName"].ToString();
                string str1 = dataRow["OriginalFileName"].ToString();
                stringBuilder.Append("<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>");
                object[] objArray = new object[] { "<input type='checkbox'  id='Chk_Attach_", num, "' value='", str, "' title='", str1, "' checked='checked' style='float:left; display:block;'/>", str1 };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("</div>");
                num++;
            }
            HtmlGenericControl divAttach = this.Div_Attach;
            divAttach.InnerHtml = string.Concat(divAttach.InnerHtml, stringBuilder);
        }
        // ---Proof Section---
        public void Bind_Attachment_Proof()
        {
            int num = 0;
            DataTable dataTable = EstimateBasePage.EstimateItemID_Select(this.companyid, this.UserID, this.EstimateID);
            foreach (DataRow row in dataTable.Rows)
            {
                this.AttachmenttypeID = Convert.ToInt64(row["Estimateitemid"].ToString());
            }
            StringBuilder stringBuilder = new StringBuilder();
            //foreach (DataRow dataRow in EstimateBasePage.Get_ProofAprovedFilesDetail(this.ProofID, this.AttachmenttypeID).Rows)
            if (string.IsNullOrEmpty(this.Items))
            {

                foreach (DataRow dataRow in EstimateBasePage.Get_ProofAprovedFilesDetail(this.ProofID, this.AttachmenttypeID).Rows)
                {
                    string str = dataRow["FileName"].ToString();
                    string str1 = dataRow["OriginalFileName"].ToString();
                    stringBuilder.Append("<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>");
                    object[] objArray = new object[] { "<input type='checkbox' checked='checked'  id='Chk_Attach_", num, "' value='", str, "' title='", str1, "' style='float:left; display:block;'/>", str1 };
                    stringBuilder.Append(string.Concat(objArray));
                    stringBuilder.Append("</div>");
                    num++;
                }
            }
            else
            {
                int[] nums = Array.ConvertAll(this.Items.Split(','), int.Parse);
                for (int i = 0; i < nums.Length; i++)
                {
                    foreach (DataRow dataRow in EstimateBasePage.Get_ProofAprovedFilesDetail(this.ProofID, nums[i]).Rows)
                    {
                        string str = dataRow["FileName"].ToString();
                        string str1 = dataRow["OriginalFileName"].ToString();
                        stringBuilder.Append("<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>");
                        object[] objArray = new object[] { "<input type='checkbox'  checked='checked'  id='Chk_Attach_", num, "' value='", str, "' title='", str1, "' checked='checked' style='float:left; display:block;'/>", str1 };
                        stringBuilder.Append(string.Concat(objArray));
                        stringBuilder.Append("</div>");
                        num++;
                    }
                }
            }


            HtmlGenericControl divAttach = this.Div_Attach;
            divAttach.InnerHtml = string.Concat(divAttach.InnerHtml, stringBuilder);
        }
        // End Proof
        public void Bind_AttachmentLink_ForPurchase()
        {
            int num = 0;
            DataTable dataTable = EstimateBasePage.EstimateItemID_Select(this.companyid, this.UserID, this.EstimateID);
            foreach (DataRow row in dataTable.Rows)
            {
                this.AttachmenttypeID = Convert.ToInt64(row["Estimateitemid"].ToString());
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow dataRow in EstimateBasePage.Purchase_PurchaseID_Select(this.EstimateID, this.AttachmenttypeID).Rows)
            {
                string str = dataRow["FileName"].ToString();
                string str1 = dataRow["OriginalFileName"].ToString();
                stringBuilder.Append("<div align='left' style='float:left; cursor:default; border:0px solid red; clear: both; width:500px;'>");

                //object[] objArray = new object[] { "<a href='", this.strSitePath, "ImageHandler_Print.ashx?FileName=", str, "&cid=", this.companyid, "' target='_blank'>", str1, "</a>" };
                //stringBuilder.Append(string.Concat(objArray));

                string empty = string.Empty;
                empty = this.commclass.ReplaceSplSymbol(str);
                string[] secureSitePath = new string[] { "<a href='", this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/", empty, "' target='_blank'>", Convert.ToString(str1), "</a>" };
                stringBuilder.Append(string.Concat(secureSitePath));
                stringBuilder.Append("</div>");
                num++;
            }
            HtmlGenericControl divPOAttachLink = this.Div_POAttachLink;
            divPOAttachLink.InnerHtml = string.Concat(divPOAttachLink.InnerHtml, stringBuilder);
        }

        public void Bind_DNAttachment_forPurchase()
        {
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in EstimateBasePage.DNAttachment_forPurchase(this.EstimateID).Rows)
            {
                string str = string.Concat(row["DeliveryNumber"].ToString(), ".pdf^", row["DeliveryID"].ToString());
                string[] strArrays = str.Split(new char[] { '\u005E' });
                stringBuilder.Append("<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>");
                object[] objArray = new object[] { "<input type='checkbox'  id='Chk_Attach_", num, "' value='", str, "' title='", str, "' checked='checked' style='float:left; display:block;'/>", strArrays[0].ToString() };
                stringBuilder.Append(string.Concat(objArray));
                stringBuilder.Append("</div>");
                num++;
            }
            this.count = num;
            HtmlGenericControl divAttach = this.Div_Attach;
            divAttach.InnerHtml = string.Concat(divAttach.InnerHtml, stringBuilder);
        }

        public void Bind_EstoreAttachment_Purchase()
        {
            int num = 0;
            DataTable dataTable = EstimateBasePage.EstimateItemID_Select(this.companyid, this.UserID, this.EstimateID);
            foreach (DataRow row in dataTable.Rows)
            {
                this.AttachmenttypeID = Convert.ToInt64(row["Estimateitemid"].ToString());
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow dataRow in EstimateBasePage.Purchase_PurchaseID_Select(this.EstimateID, this.AttachmenttypeID).Rows)
            {
                if (Convert.ToBoolean(dataRow["IsFromStoreAttach"]))
                {
                    string str = dataRow["FileName"].ToString();
                    string str1 = dataRow["OriginalFileName"].ToString();
                    stringBuilder.Append("<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>");
                    object[] objArray = new object[] { "<input type='checkbox'  id='Chk_Attach_", num, "' value='", str, "' title='", str1, "' checked='checked' style='float:left; display:block;'/>", str1 };
                    stringBuilder.Append(string.Concat(objArray));
                    stringBuilder.Append("</div>");
                }
                num++;
            }
            HtmlGenericControl divAttach = this.Div_Attach;
            divAttach.InnerHtml = string.Concat(divAttach.InnerHtml, stringBuilder);
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
                this.RedirectPath = string.Concat(global.sitePath(), str);
            }
            else if (this.sectionname == "client")
            {
                this.RedirectPath = string.Concat(global.sitePath(), "client/client_view.aspx");
            }
            else if (this.sectionname.ToLower() == "estimate")
            {
                this.RedirectPath = string.Concat("../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "printbroker")
            {
                this.RedirectPath = string.Concat("../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "job")
            {
                if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
                {
                    this.RedirectPath = string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString(), this.jID);
                }
                else
                {
                    string[] strArrays = new string[] { "../jobs/job_order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", base.Request.Params["EstID"].ToString(), this.jID };
                    this.RedirectPath = string.Concat(strArrays);
                }
            }
            else if (this.sectionname.ToLower() == "invoice")
            {
                if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
                {
                    this.RedirectPath = string.Concat("../invoice/invoice_summary_reeng.aspx?frm=view", this.InvID);
                }
                else
                {
                    this.RedirectPath = string.Concat("../invoice/invoice_order_summary.aspx?frm=view", this.InvID);
                }
            }
            else if (this.sectionname.ToLower() == "purchase")
            {
                this.RedirectPath = string.Concat("../purchase/purchase_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "deliverynote")
            {
                this.RedirectPath = string.Concat("../delivery/delivery_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "jobcard")
            {
                if (this.ordid == "0")
                {
                    this.RedirectPath = string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                }
                else
                {
                    this.RedirectPath = string.Concat("../jobs/job_order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", base.Request.Params["EstID"].ToString());
                }
            }
            else if (this.sectionname.ToLower() != "webstoreorder")
            {
                QueryString queryString2 = new QueryString()
            {
                { "contactid", this.sectionid.ToString() }
            };
                string str1 = "contact/contact_detail.aspx";
                QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                str1 = string.Concat(str1, queryString3.ToString());
                this.RedirectPath = string.Concat(global.sitePath(), str1);
            }
            else
            {
                this.RedirectPath = string.Concat("../orders/order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", base.Request.Params["EstID"].ToString());
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), "page", string.Concat("forRedirect('", this.RedirectPath, "');"), true);
        }

        public void btnsend_Click(object sender, EventArgs e)
        {
            string str;
            string[] strAttachPath;
            char[] chrArray;
            bool flag = false;
            if (base.Request.QueryString["ProofID"] != null && this.sectionname.ToLower() == "estimate")
            {
                this.RedirectPath = string.Concat("../Proofs/Proof_summary.aspx?estid=", base.Request.Params["EstID"].ToString(), "&ProofID=", base.Request.Params["ProofID"].ToString());
            }
            else if (this.sectionname.ToLower() == "estimate")
            {
                this.RedirectPath = string.Concat("../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString(), this.jID, this.InvID);
            }
            else if (this.sectionname.ToLower() == "printbroker")
            {
                this.RedirectPath = string.Concat("../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString(), this.jID, this.InvID);
            }
            else if (this.sectionname.ToLower() == "job")
            {
                if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
                {
                    this.RedirectPath = string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString(), this.jID);
                }
                else
                {
                    strAttachPath = new string[] { "../jobs/job_order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", base.Request.Params["EstID"].ToString(), this.jID };
                    this.RedirectPath = string.Concat(strAttachPath);
                }
            }
            else if (this.sectionname.ToLower() == "invoice")
            {
                if (this.IS_INVOICEorJOB_from_Webstore.ToLower() != "yes")
                {
                    this.RedirectPath = string.Concat("../invoice/invoice_summary_reeng.aspx?frm=view", this.InvID);
                }
                else
                {
                    this.RedirectPath = string.Concat("../invoice/invoice_order_summary.aspx?frm=view", this.InvID);
                }
            }
            else if (this.sectionname.ToLower() == "purchase")
            {
                this.RedirectPath = string.Concat("../purchase/purchase_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString(), this.jID, this.InvID);
            }
            else if (this.sectionname.ToLower() == "deliverynote")
            {
                this.RedirectPath = string.Concat("../delivery/delivery_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString(), this.jID, this.InvID);
            }
            else if (this.sectionname.ToLower() == "jobcard")
            {
                if (this.ordid == "0")
                {
                    this.RedirectPath = string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString(), this.jID, this.InvID);
                }
                else
                {
                    strAttachPath = new string[] { "../jobs/job_order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", base.Request.Params["EstID"].ToString(), this.jID, this.InvID };
                    this.RedirectPath = string.Concat(strAttachPath);
                }
            }
            else if (this.sectionname.ToLower() != "webstoreorder")
            {
                QueryString queryString = new QueryString()
            {
                { "contactid", this.sectionid.ToString() }
            };
                string str1 = "contact/contact_detail.aspx";
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                str1 = string.Concat(str1, queryString1.ToString());
                this.RedirectPath = string.Concat(global.sitePath(), str1);
            }
            else
            {
                strAttachPath = new string[] { "../orders/order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", base.Request.Params["EstID"].ToString(), this.jID, this.InvID };
                this.RedirectPath = string.Concat(strAttachPath);
            }
            if (base.Request.Params["page"].ToLower().ToString() == "job")
            {
                SettingsBasePage.Update_settings_TemNameLastCounter(this.companyid, this.jobID, base.Request.Params["page"].ToString());
            }
            else if (base.Request.Params["page"].ToLower().ToString() != "invoice")
            {
                SettingsBasePage.Update_settings_TemNameLastCounter(this.companyid, this.EstimateID, base.Request.Params["page"].ToString());
            }
            else
            {
                SettingsBasePage.Update_settings_TemNameLastCounter(this.companyid, this.InvoiceID, base.Request.Params["page"].ToString());
            }
            try
            {
                string str2 = this.objBase.SpecialEncode(this.txtcc.Value);
                string value = this.objBase.SpecialEncode(this.txtbcc.Value);
                string str3 = this.objBase.SpecialEncode(this.txtsubject.Value);
                string str4 = this.objBase.SpecialEncode(this.txtattachment.Value);
                this.message = this.objBase.SpecialEncode(this.RadareaEditor.Content);
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                string empty = string.Empty;
                string empty1 = string.Empty;
                num2 = (this.ddlLeadMoreAction.SelectedValue != "1" ? 0 : 1);
                empty = (EprintConfigurationManager.AppSettings["FromEmailConfig"].ToString() != "1" ? HttpContext.Current.Session["email"].ToString() : EprintConfigurationManager.AppSettings["FromEmail"].ToString());
                try
                {
                    empty1 = SettingsBasePage.Settings_fromemail_get(Convert.ToInt32(HttpContext.Current.Session["CompanyID"].ToString()));
                }
                catch
                {
                    //empty1 = "support@eprintsoftware.com";
                    empty1 = "support@hexicomsoftware.com";
                }
                if (this.ddlLeadMoreAction.SelectedValue != "1")
                {
                    str = "";
                }
                else
                {
                    str = this.objBase.SpecialEncode(this.ddlselecttemplate.SelectedItem.Text);
                    int.Parse(this.ddlselecttemplate.SelectedItem.Value);
                }
                int value1 = 0;
                commonClass _commonClass = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_common_insertEmail", _commonClass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
                sqlParameter.Direction = ParameterDirection.ReturnValue;
                sqlCommand.Parameters.AddWithValue("@pg", this.sectionname);
                sqlCommand.Parameters.AddWithValue("@id", this.sectionid);
                sqlCommand.Parameters.AddWithValue("@toUserID", 0);
                sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(base.Session["companyID"].ToString()));
                sqlCommand.Parameters.AddWithValue("@CC", str2);
                sqlCommand.Parameters.AddWithValue("@BCC", value);
                sqlCommand.Parameters.AddWithValue("@subject", str3);
                sqlCommand.Parameters.AddWithValue("@attachment", str4);
                sqlCommand.Parameters.AddWithValue("@message", this.message);
                sqlCommand.Parameters.AddWithValue("@fromUserID", int.Parse(base.Session["userID"].ToString()));
                SqlParameterCollection parameters = sqlCommand.Parameters;
                DateTime now = DateTime.Now;
                parameters.AddWithValue("@dateSent", now.ToString());
                SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
                now = DateTime.Now;
                sqlParameterCollection.AddWithValue("@dateOpened", now.ToString());
                sqlCommand.Parameters.AddWithValue("@isRead", num1);
                sqlCommand.Parameters.AddWithValue("@noOfView", num);
                SqlParameterCollection parameters1 = sqlCommand.Parameters;
                now = DateTime.Now;
                parameters1.AddWithValue("@lastViewDate", now.ToString());
                sqlCommand.Parameters.AddWithValue("@istemplate", num2);
                sqlCommand.Parameters.AddWithValue("@templatename", str);
                sqlCommand.Parameters.AddWithValue("@TO", this.objBase.SpecialEncode(this.txtfirstname.Value));
                try
                {
                    sqlCommand.Parameters.AddWithValue("@sectionnumber", this.RecordNumber.ToString());
                }
                catch
                {
                    sqlCommand.Parameters.AddWithValue("@sectionnumber", 1);
                }
                sqlCommand.ExecuteNonQuery();
                _commonClass.closeConnection();
                _commonClass.Dispose();
                value1 = (int)sqlCommand.Parameters["ReturnValue"].Value;
                commonClass _commonClass1 = new commonClass();
                bool flag1 = false;
                string str5 = EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
                string str6 = string.Empty;
                if (!string.IsNullOrEmpty(this.hid_TemplateKey.Value))
                {
                    str6 = SettingsBasePage.settings_template_emailed_select_GUID(this.hid_TemplateKey.Value);
                }
                string str7 = string.Concat(this.strFilepath, "tempattachment\\", this.objBase.SpecialEncode(str6));
                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.companyid, "//sentpdf//" };
                if (!Directory.Exists(string.Concat(secureDocPath)))
                {
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.companyid, "//sentpdf//" };
                    Directory.CreateDirectory(string.Concat(secureDocPath));
                }
                if (File.Exists(str7))
                {
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.companyid, "//sentpdf//", this.objBase.SpecialEncode(this.txtattachment.Value) };
                    File.Copy(str7, string.Concat(secureDocPath), true);
                }
                int value2 = 0;
                if (this.sectionname.ToLower() == "purchase")
                {
                    flag1 = true;
                    value = string.Concat("emaillogs@hexicomsoftware.com,", value);
                    string str8 = EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
                    SqlConnection sqlConnection = new SqlConnection(str8);
                    sqlConnection.Open();
                    SqlCommand sqlCommand1 = new SqlCommand("PC_PDFEmails_Insert_3_3", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter1 = sqlCommand1.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
                    sqlParameter1.Direction = ParameterDirection.ReturnValue;
                    sqlCommand1.Parameters.AddWithValue("@SystemName", str5);
                    sqlCommand1.Parameters.AddWithValue("@companyID", long.Parse(base.Session["companyID"].ToString()));
                    sqlCommand1.Parameters.AddWithValue("@ModuleName", this.sectionname);
                    sqlCommand1.Parameters.AddWithValue("@ModuleID", this.EstID);
                    sqlCommand1.Parameters.AddWithValue("@SubModuleID", 0);
                    sqlCommand1.Parameters.AddWithValue("@DBID", 0);
                    sqlCommand1.Parameters.AddWithValue("@FromEmail", empty);
                    sqlCommand1.Parameters.AddWithValue("@ReplyTo", HttpContext.Current.Session["email"].ToString());
                    sqlCommand1.Parameters.AddWithValue("@ToEmails", this.objBase.SpecialEncode(this.txtfirstname.Value));
                    sqlCommand1.Parameters.AddWithValue("@CCEmails", str2);
                    sqlCommand1.Parameters.AddWithValue("@BCCEmails", value);
                    sqlCommand1.Parameters.AddWithValue("@EmailSubject", str3);
                    sqlCommand1.Parameters.AddWithValue("@EmailTemplateID", long.Parse(this.ddlEmailTemp.SelectedItem.Value.ToString()));
                    sqlCommand1.Parameters.AddWithValue("@EmailBody", this.RadareaEditor.Content.ToString());
                    sqlCommand1.Parameters.AddWithValue("@CreatedBY", long.Parse(base.Session["userID"].ToString()));
                    SqlParameterCollection sqlParameterCollection1 = sqlCommand1.Parameters;
                    now = DateTime.Now;
                    sqlParameterCollection1.AddWithValue("@CreatedOn", now.ToString());
                    sqlCommand1.Parameters.AddWithValue("@IsEmailSent", 0);
                    sqlCommand1.Parameters.AddWithValue("@EmailSentOn", "");
                    sqlCommand1.Parameters.AddWithValue("@ErrorMessage", "No Error");
                    sqlCommand1.Parameters.AddWithValue("@TemplateID", long.Parse(this.NewTemplateID.ToString()));
                    sqlCommand1.Parameters.AddWithValue("@PDFAttachmentPath", str7.ToString());
                    sqlCommand1.Parameters.AddWithValue("@IsPreviewGenerated", flag1);
                    sqlCommand1.Parameters.AddWithValue("@emailName", empty1);
                    sqlCommand1.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    value2 = (int)sqlCommand1.Parameters["ReturnValue"].Value;
                }
                commonClass _commonClass2 = new commonClass();
                SqlCommand sqlCommand2 = new SqlCommand("crm_select_leadsHTMLEmail", _commonClass2.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand2.Parameters.AddWithValue("@companyid", int.Parse(base.Session["companyid"].ToString()));
                SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    empty = sqlDataReader["leadsHTMLEmail"].ToString();
                }
                sqlDataReader.Close();
                sqlDataReader.Dispose();
                _commonClass2.closeConnection();
                _commonClass2.Dispose();
                if (empty == "")
                {
                    empty = base.Session["email"].ToString();
                }
                Directory.GetFiles(string.Concat(base.Server.MapPath("../"), "tempattachment\\"));
                string empty2 = string.Empty;
                if (this.txtfirstname.Value != "")
                {
                    string str9 = this.objBase.SpecialEncode(this.txtfirstname.Value.ToString());
                    //chrArray = new char[] { ',' };
                    //this.stremailArray = str9.Split(chrArray);
                    chrArray = new char[] { ';' };
                    this.stremailArray = str9.Split(chrArray);
                    string str10 = this.txtfirstname.Value.ToString();
                    //chrArray = new char[] { ',' };
                    //this.stremailArrayPlain = str10.Split(chrArray);
                    chrArray = new char[] { ';' };
                    this.stremailArrayPlain = str10.Split(chrArray);
                }
                bool flag2 = false;
                bool flag3 = true;
                for (int i = 0; i < (int)this.stremailArray.Length; i++)
                {
                    commonClass _commonClass3 = new commonClass();
                    string empty3 = string.Empty;
                    empty3 = this.message;
                    string str11 = this.GenPassWithCap(24).ToString();
                    SqlCommand sqlCommand3 = new SqlCommand("crm_campaign_insertmarketingEmail", _commonClass3.openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter2 = sqlCommand3.Parameters.AddWithValue("ReturnMarketingIdValue", SqlDbType.Int);
                    sqlParameter2.Direction = ParameterDirection.ReturnValue;
                    sqlCommand3.Parameters.AddWithValue("@commonemailid", value1);
                    sqlCommand3.Parameters.AddWithValue("@email", this.stremailArray[i].ToString());
                    sqlCommand3.Parameters.AddWithValue("@verificationnumber", str11);
                    sqlCommand3.Parameters.AddWithValue("@emailtype", empty2);
                    sqlCommand3.Parameters.AddWithValue("@message", empty3);
                    sqlCommand3.Parameters.AddWithValue("@ToUserID", 0);
                    sqlCommand3.Parameters.AddWithValue("@companyID", base.Session["companyID"].ToString());
                    sqlCommand3.ExecuteNonQuery();
                    _commonClass3.closeConnection();
                    _commonClass3.Dispose();
                    int value3 = (int)sqlCommand3.Parameters["ReturnMarketingIdValue"].Value;
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    bool flag4 = false;
                    string empty6 = string.Empty;
                    long num3 = (long)0;
                    string empty7 = string.Empty;
                    string empty8 = string.Empty;
                    if (this.hdnEmailAttachment_ActualName.Value.Length > 0 && flag3)
                    {
                        string value4 = this.hdnEmailAttachment_OriginalName.Value;
                        chrArray = new char[] { '~' };
                        string[] strArrays = value4.Split(chrArray);
                        string value5 = this.hdnEmailAttachment_ActualName.Value;
                        chrArray = new char[] { '~' };
                        string[] strArrays1 = value5.Split(chrArray);
                        for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                        {
                            string str12 = empty5;
                            strAttachPath = new string[] { str12, this.Str_AttachPath, "\\", strArrays1[j].ToString(), "µ" };
                            empty5 = string.Concat(strAttachPath);
                            if (this.sectionname.ToLower() == "purchase")
                            {
                                empty8 = string.Concat(this.Str_AttachPath, "\\", strArrays1[j].ToString());
                                if ((int)strArrays1.Length > 0)
                                {
                                    try
                                    {
                                        string str13 = strArrays1[j].ToString();
                                        chrArray = new char[] { '\u005E' };
                                        string[] strArrays2 = str13.Split(chrArray);
                                        string str14 = string.Concat(this.Str_AttachPath, this.objBase.SpecialEncode(strArrays2[0].ToString()));
                                        if (File.Exists(str14))
                                        {
                                            secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.companyid, "//sentpdf//", this.objBase.SpecialEncode(strArrays2[0].ToString()) };
                                            File.Copy(str14, string.Concat(secureDocPath), true);
                                        }
                                        if (!strArrays1[j].Contains(ConnectionClass.DeliveryNotePrefix))
                                        {
                                            empty6 = (string.IsNullOrEmpty(strArrays[j]) ? strArrays1[j].ToString() : Convert.ToString(strArrays[j]));
                                            num3 = (long)0;
                                        }
                                        else
                                        {
                                            string str15 = strArrays1[j];
                                            chrArray = new char[] { '\u005E' };
                                            string[] strArrays3 = str15.Split(chrArray);
                                            if ((int)strArrays3.Length <= 1)
                                            {
                                                empty6 = strArrays1[j].ToString();
                                                num3 = (long)0;
                                            }
                                            else
                                            {
                                                empty6 = strArrays3[0].ToString();
                                                num3 = (long)Convert.ToInt32(strArrays3[1].ToString());
                                                empty8 = "";
                                                empty7 = "Delivery";
                                                flag4 = true;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                this.Insert_PdfEmailAttachments((long)value2, empty6, empty8.ToString(), num3, empty7, flag4, (long)this.UserID);
                            }
                        }
                        flag3 = false;
                    }
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "\\", this.companyid, "\\sentpdf\\", this.objBase.SpecialEncode(this.txtattachment.Value), "µ", empty5 };
                    string str16 = string.Concat(secureDocPath);
                    if (this.stremailArray[i].ToString() != "")
                    {
                        value = this.txtbcc.Value;
                        if (flag2)
                        {
                            this.txtcc.Value = "";
                            value = "";
                        }
                        if (this.sectionname.ToLower() != "purchase" && this.hid_TemplateKey.Value.Trim().Length > 0)
                        {
                            int num4 = 0;
                            while (true)
                            {
                                chrArray = new char[] { 'µ' };
                                if (num4 >= (int)str16.Split(chrArray).Length)
                                {
                                    break;
                                }
                                chrArray = new char[] { 'µ' };
                                if (!File.Exists(str16.Split(chrArray)[num4].ToString()))
                                {
                                    chrArray = new char[] { 'µ' };
                                    if (!string.IsNullOrEmpty(str16.Split(chrArray)[num4].ToString()))
                                    {
                                        flag = true;
                                    }
                                }
                                num4++;
                            }
                            if (!flag)
                            {
                                BaseClass.SendMailMessage(empty, this.stremailArrayPlain[i].ToString().Trim(), value, str2, this.txtsubject.Value, this.RadareaEditor.Content, str16, true);
                            }
                        }
                        if (base.Request.QueryString["ProofID"] != null)
                        {
                            EstimateBasePage.UpdateProofUserEmail(this.ProofID, this.stremailArrayPlain[i].ToString().Trim());
                            BaseClass.SendMailMessage(empty, this.stremailArrayPlain[i].ToString().Trim(), value, str2, this.txtsubject.Value, this.RadareaEditor.Content, str16, true);
                            if (string.IsNullOrEmpty(this.Items))
                            {
                                foreach (DataRow dr in EstimateBasePage.Get_ProofAprovedFilesDetail(this.ProofID, 0).Rows)
                                {
                                    EstimateBasePage.InsertProofHistory(int.Parse(dr["AttachmentID"].ToString()), int.Parse(dr["EstimateItemId"].ToString()), this.ProofID, this.UserID, int.Parse(dr["ID"].ToString()));
                                }
                            }
                            else
                            {
                                int[] nums = Array.ConvertAll(this.Items.Split(','), int.Parse);
                                for (int j = 0; i < nums.Length; i++)
                                {
                                    foreach (DataRow dr in EstimateBasePage.Get_ProofAprovedFilesDetail(this.ProofID, nums[j]).Rows)
                                    {
                                        EstimateBasePage.InsertProofHistory(int.Parse(dr["AttachmentID"].ToString()), int.Parse(dr["EstimateItemId"].ToString()), this.ProofID, this.UserID, int.Parse(dr["ID"].ToString()));
                                    }
                                }
                            }
                        }
                        else if (this.hid_TemplateKey.Value.Trim().Length == 0)
                        {
                            //BaseClass.SendMailMessage(empty, "support@eprintsoftware.com", "", "", string.Concat("[Blank Key]:", this.objBase.SpecialEncode(this.txtsubject.Value)), this.objBase.SpecialEncode(this.RadareaEditor.Content), str16, true);
                            BaseClass.SendMailMessage(empty, "support@hexicomsoftware.com", "", "", string.Concat("[Blank Key]:", this.objBase.SpecialEncode(this.txtsubject.Value)), this.objBase.SpecialEncode(this.RadareaEditor.Content), str16, true);
                        }
                        flag2 = true;
                    }
                }
                if (!flag)
                {
                    string empty9 = string.Empty;
                    DataTable dataTable = EstimatesBasePage.select_details_for_Activity_History(this.companyid, Convert.ToInt64(this.EstimateID), "template", this.NewTemplateID);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        empty9 = row["Name"].ToString();
                    }
                    if (base.Request.Params["page"].ToLower() == "estimate")
                    {
                        this.objnotes.Template_name = empty9;
                        string empty10 = string.Empty;
                        if (!string.IsNullOrEmpty(str2))
                        {
                            empty10 = string.Concat(", ", str2.Replace(",", ", "));
                        }
                        this.objnotes.email_address = string.Concat(this.txtfirstname.Value.Replace(",", ", "), empty10, ", ", value.Replace(",", ", "));
                        this.objnotes.ModuleName = "estimate";

                        if (!String.IsNullOrEmpty(this.statusidonsend.Value))
                        {
                            this.updateEstimateStatus(Convert.ToInt32(this.EstimateID), Convert.ToInt32(this.statusidonsend.Value));
                            this.objnotes.Status_name = this.statustitleonsend.Value;
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstTemplateSentWithStatusChange);
                        }
                        else
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstTemplateSent);


                      //  this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstTemplateSent);
                        this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
                    }
                    else if (base.Request.Params["page"].ToLower() == "job")
                    {
                
                        this.objnotes.Template_name = empty9;
                        string empty11 = string.Empty;
                        if (!string.IsNullOrEmpty(str2))
                        {
                            empty11 = string.Concat(", ", str2.Replace(",", ", "));
                        }
                        this.objnotes.email_address = string.Concat(this.txtfirstname.Value.Replace(",", ", "), empty11, ", ", value.Replace(",", ", "));
                        this.objnotes.ModuleName = "job";
                        if (!String.IsNullOrEmpty(this.statusidonsend.Value))
                        {
                            this.updateJobStatus(Convert.ToInt32(this.jobID), Convert.ToInt32(this.statusidonsend.Value));
                            this.objnotes.Status_name = this.statustitleonsend.Value;
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobTemplateSentWithStatusChange);
                        }
                        else
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobTemplateSent);

                        this.objnotes.ModuleID = Convert.ToInt64(this.jobID);
                    }
                    else if (base.Request.Params["page"].ToLower() == "invoice")
                    {
                        this.objnotes.Template_name = empty9;
                        string empty12 = string.Empty;
                        if (!string.IsNullOrEmpty(str2))
                        {
                            empty12 = string.Concat(", ", str2.Replace(",", ", "));
                        }
                        this.objnotes.email_address = string.Concat(this.txtfirstname.Value.Replace(",", ", "), empty12, ", ", value.Replace(",", ", "));
                        this.objnotes.ModuleName = "invoice";

                        if (!String.IsNullOrEmpty(this.statusidonsend.Value))
                        {
                            this.updateInvStatus(Convert.ToInt32(this.InvoiceID), Convert.ToInt32(this.statusidonsend.Value));
                            this.objnotes.Status_name = this.statustitleonsend.Value;
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvTemplateSentWithStatusChange);
                        }
                        else
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvTemplateSent);


                      //  this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvTemplateSent);
                        this.objnotes.ModuleID = Convert.ToInt64(this.InvoiceID);
                    }
                    else if (base.Request.Params["page"].ToLower() == "purchase")
                    {
                        this.objnotes.Template_name = empty9;
                        string empty13 = string.Empty;
                        if (!string.IsNullOrEmpty(str2))
                        {
                            empty13 = string.Concat(", ", str2.Replace(",", ", "));
                        }
                        this.objnotes.email_address = string.Concat(this.txtfirstname.Value.Replace(",", ", "), empty13, ", ", value.Replace(",", ", "));
                        this.objnotes.ModuleName = "purchase";

                        if (!String.IsNullOrEmpty(this.statusidonsend.Value))
                        {
                            this.updatePOStatus(Convert.ToInt32(this.EstimateID), Convert.ToInt32(this.statusidonsend.Value));
                            this.objnotes.Status_name = this.statustitleonsend.Value;
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POTempSendWithStatusChange);
                        }
                        else
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POTempSend);
                       // this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POTempSend);
                        this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
                    }
                    else if (base.Request.Params["page"].ToLower() == "note")
                    {
                        this.objnotes.Template_name = empty9;
                        string empty14 = string.Empty;
                        if (!string.IsNullOrEmpty(str2))
                        {
                            empty14 = string.Concat(", ", str2.Replace(",", ", "));
                        }
                        this.objnotes.email_address = string.Concat(this.txtfirstname.Value.Replace(",", ", "), empty14, ", ", value.Replace(",", ", "));
                        this.objnotes.ModuleName = "delivery";

                        if (!String.IsNullOrEmpty(this.statusidonsend.Value))
                        {
                            this.updateDelStatus(Convert.ToInt32(this.EstimateID), Convert.ToInt32(this.statusidonsend.Value));
                            this.objnotes.Status_name = this.statustitleonsend.Value;
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelTempSendWithStatusChange);
                        }
                        else
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelTempSend);

                        //this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelTempSend);
                        this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
                    }
                    else if (base.Request.Params["page"].ToLower() == "webstoreorder")
                    {
                        this.objnotes.Template_name = empty9;
                        string empty15 = string.Empty;
                        if (!string.IsNullOrEmpty(str2))
                        {
                            empty15 = string.Concat(", ", str2.Replace(",", ", "));
                        }
                        this.objnotes.email_address = string.Concat(this.txtfirstname.Value.Replace(",", ", "), empty15, ", ", value.Replace(",", ", "));
                        this.objnotes.ModuleName = "webstoreorder";

                        if (!String.IsNullOrEmpty(this.statusidonsend.Value))
                        {
                            this.updateOrdStatus(Convert.ToInt32(this.EstimateID), Convert.ToInt32(this.statusidonsend.Value));
                            this.objnotes.Status_name = this.statustitleonsend.Value;
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderTempSendWithStatusChange);
                        }
                        else
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderTempSend);

                      //  this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderTempSend);
                        this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
                    }
                    this.objnotes.TempAttachment = string.Concat(this.strSitePath, "pdf.aspx?key=", this.hid_TemplateKey.Value);
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass4 = this.commclass;
                    now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass4.Eprint_return_DateTime_Before_View(now.ToString(), this.companyid, this.UserID, true);
                    this.objnotes.CompanyID = this.companyid;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                }
            }
            catch
            {
            }
            if (flag)
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), "page", string.Concat("RedirectwithErrorMsg('", this.RedirectPath, "');"), true);
                return;
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), "page", string.Concat("forRedirect('", this.RedirectPath, "');"), true);
        }
        public void SaveProofStatus(Int32 EstimateItemID)
        {


            SqlCommand sqlCommand = new SqlCommand("Update tb_EstimateItem set IsProof=1 where EstimateItemID=@EstimateItemID", (new commonClass()).openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.Parameters.AddWithValue("@EstimateItemID", EstimateItemID);
            sqlCommand.ExecuteNonQuery();

        }

        public void updateInvStatus(int EstimateID, int statusid)
        {


            SqlCommand sqlCommand = new SqlCommand("Update tb_invoice set status=@statusid where invoiceid=@EstimateID; update tb_EstimateItem set InvocieItemStatusID=@statusid where Invoiceid=@EstimateID", (new commonClass()).openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.Parameters.AddWithValue("@EstimateID", EstimateID);
            sqlCommand.Parameters.AddWithValue("@statusid", statusid);
            sqlCommand.ExecuteNonQuery();

        }

        public void updatePOStatus(int EstimateID, int statusid)
        {


            SqlCommand sqlCommand = new SqlCommand("Update tb_Purchase set Status=@statusid where purchaseid=@EstimateID;", (new commonClass()).openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.Parameters.AddWithValue("@EstimateID", EstimateID);
            sqlCommand.Parameters.AddWithValue("@statusid", statusid);
            sqlCommand.ExecuteNonQuery();

        }

        public void updateDelStatus(int EstimateID, int statusid)
        {


            SqlCommand sqlCommand = new SqlCommand("Update tb_Delivery set Status=@statusid where deliveryid=@EstimateID;", (new commonClass()).openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.Parameters.AddWithValue("@EstimateID", EstimateID);
            sqlCommand.Parameters.AddWithValue("@statusid", statusid);
            sqlCommand.ExecuteNonQuery();

        }

        public void updateJobStatus(int EstimateID, int statusid)
        {


            SqlCommand sqlCommand = new SqlCommand("Update tb_job set StatusID=@statusid where jobid=@EstimateID; update tb_EstimateItem set JOBItemStatusID=@statusid where JobID=@EstimateID", (new commonClass()).openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.Parameters.AddWithValue("@EstimateID", EstimateID);
            sqlCommand.Parameters.AddWithValue("@statusid", statusid);
            sqlCommand.ExecuteNonQuery();

        }

        public void updateOrdStatus(int EstimateID, int statusid)
        {


            SqlCommand sqlCommand = new SqlCommand("Update tb_Estimate set StatusID=@statusid where estimateid=@EstimateID;update tb_EstimateItem set EstimateItemStatusID=@statusid where estimateid=@EstimateID ", (new commonClass()).openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.Parameters.AddWithValue("@EstimateID", EstimateID);
            sqlCommand.Parameters.AddWithValue("@statusid", statusid);
            sqlCommand.ExecuteNonQuery();

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

        public void ddlselecttemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_select_defaultEmailAndSignature", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.companyid);
            sqlCommand.Parameters.AddWithValue("@EmailID", this.ddlEmailTemp.SelectedValue);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                this.RadareaEditor.Content = sqlDataReader["Body"].ToString();
            }
        }

        protected void ddltemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.hdnEmailBody.Value = "";
            this.hid_body.Value = "";
            this.RadareaEditor.Content = "";
            this.txtsubject.Value = "";
            this.pnl_attachment.Visible = true;
            if (this.ddlEmailTemp.SelectedIndex != 0)
            {
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
                    this.statusidonsend .Value= sqlDataReader["statusid"].ToString() == "0" ? "" : sqlDataReader["statusid"].ToString();
                    this.statustitleonsend.Value= sqlDataReader["statustitle"].ToString();
                    if (base.Request.QueryString["ProofID"] != null)
                    {
                        this.txtbcc.Value = sqlDataReader["BCC"].ToString();
                        this.txtcc.Value = sqlDataReader["CC"].ToString();
                    }
                    if (str1 != null || str1 != "")
                    {
                        this.RadareaEditor.Content = string.Concat(str, this.Div_POAttachLink.InnerHtml, str1);
                        this.txtsubject.Value = str2;
                        this.hid_body.Value = this.RadareaEditor.Content;
                    }
                    else
                    {
                        this.RadareaEditor.Content = str;
                        this.txtsubject.Value = str2;
                        this.hid_body.Value = this.RadareaEditor.Content;
                    }
                    DataTable dataTable = new DataTable();
                    if (base.Request.Params["ProofID"] != null)
                    {
                        dataTable = SettingsBasePage.settings_proof_template_select(this.companyid, this.EstimateID, this.Items);
                    }
                    else if (base.Request.Params["page"].ToLower().ToString() == "job")
                    {
                        dataTable = SettingsBasePage.settings_titlecode_fortemplate_select(this.companyid, this.jobID, base.Request.Params["page"].ToString(), this.Items);
                    }
                    else if (base.Request.Params["page"].ToLower().ToString() != "invoice")
                    {
                        dataTable = (base.Request.Params["page"].ToLower().ToString() == "estimate" || base.Request.Params["page"].ToLower().ToString() == "webstoreorder" ? SettingsBasePage.settings_titlecode_fortemplate_select(this.companyid, this.EstimateID, base.Request.Params["page"].ToString(), this.Items) : SettingsBasePage.settings_titlecode_fortemplate_select(this.companyid, this.EstimateID, base.Request.Params["page"].ToString(), this.Items));
                    }
                    else
                    {
                        dataTable = SettingsBasePage.settings_titlecode_fortemplate_select(this.companyid, this.InvoiceID, base.Request.Params["page"].ToString(), this.Items);
                    }
                    this.ReplaceAllTags(dataTable, this.TemplateKey, base.Request.Params["page"].ToString());
                }
            }
        }

        public void ddltemplateType_SelectedIndexChanged(object sender, EventArgs e)
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

        public void Insert_PdfEmailAttachments(long PDFEmailsID, string AttachmentName, string AttachmentFullPath, long AttachmentModuleID, string AttchmentModuleName, bool isGenerateAttchment, long AddedBy)
        {
            string str = EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("PC_Insert_PDFEmailAttachments", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@PDFEmailsID", Convert.ToInt64(PDFEmailsID));
            sqlCommand.Parameters.AddWithValue("@AttachmentName", AttachmentName);
            sqlCommand.Parameters.AddWithValue("@AttachmentFullPath", AttachmentFullPath);
            sqlCommand.Parameters.AddWithValue("@AttachmentModuleID", Convert.ToInt64(AttachmentModuleID));
            sqlCommand.Parameters.AddWithValue("@AttchmentModuleName", AttchmentModuleName);
            sqlCommand.Parameters.AddWithValue("@isGenerateAttchment", Convert.ToBoolean(isGenerateAttchment));
            sqlCommand.Parameters.AddWithValue("@AddedBy", Convert.ToInt64(AddedBy));
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        protected void lnkDownloadPDF_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_template_emailed_insert(this.txtattachment.Value, this.hid_TemplateKey.Value, (long)Convert.ToInt32(base.Session["CompanyID"]));
        }

        public void LoadDefaultTemplateType()
        {
            string lower = base.Request.Params["page"].ToString().ToLower();
            if (lower.Trim().ToLower() == "purchase")
            {
                lower = "Purchase Order";
            }
            else if (lower.Trim().ToLower() == "note")
            {
                lower = "Delivery Note";
            }
            else if (lower.Trim().ToLower() == "printbroker")
            {
                lower = "Supplier RFQ";
            }
            if (base.Request.QueryString["ProofID"] != null)
            {
                lower = "Proof Approval emails";
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
                    this.txtsubject.Value = "";
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
            string lower = base.Request.Params["page"].ToString().ToLower();
            this.LoadEmailTemplateType();
            this.LoadDefaultTemplateType();
            if (lower.Trim().ToLower() == "purchase")
            {
                lower = "Purchase Order";
            }
            else if (lower.Trim().ToLower() == "note")
            {
                lower = "Delivery Note";
            }
            else if (lower.Trim().ToLower() == "printbroker")
            {
                lower = "Supplier RFQ";
            }
            if (base.Request.QueryString["ProofID"] != null)
            {
                lower = "Proof Approval emails";
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
                this.hdnEmailBody.Value = sqlDataReader["Body"].ToString();
                this.hdn_EmailFooter.Value = sqlDataReader["FooterText"].ToString();
                this.statusidonsend.Value = sqlDataReader["statusid"].ToString()=="0"?"": sqlDataReader["statusid"].ToString();
                this.statustitleonsend.Value = sqlDataReader["statustitle"].ToString();
                this.txtsubject.Value = sqlDataReader["Subject"].ToString();
                this.RadareaEditor.Content = string.Concat(sqlDataReader["Body"].ToString(), this.Div_POAttachLink.InnerHtml, " ", sqlDataReader["FooterText"].ToString());
                this.hid_body.Value = string.Concat(sqlDataReader["Body"].ToString(), this.Div_POAttachLink.InnerHtml, " ", sqlDataReader["FooterText"].ToString());
                this.objBase.SetDDLValue(this.ddlEmailTemp, sqlDataReader["EmailID"].ToString());
                if (base.Request.QueryString["ProofID"] != null)
                { 
                    this.txtbcc.Value = sqlDataReader["BCC"].ToString();
                    this.txtcc.Value = sqlDataReader["CC"].ToString();
                }
            }
        }

        public void LoadEmailTemplateType()
        {
            SqlCommand sqlCommand = new SqlCommand("PC_settings_emailbody_select", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.companyid);
            sqlCommand.Parameters.AddWithValue("@Type", this.PageType);
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
            if (base.Request.QueryString["ProofID"] != null)
            {
                lower = "Proof Approval emails";
            }
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            SqlCommand sqlCommand = new SqlCommand("PC_Select_EmailTemplateName", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@userId", this.UserID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.companyid);
            sqlCommand.Parameters.AddWithValue("@TemplateType", lower);
            using (IDataReader dataReader = database.ExecuteReader(sqlCommand))
            {
                dataTable.Load(dataReader);
            }
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["TemplateName"] = this.objBase.SpecialDecode(row["TemplateName"].ToString());
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
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (!base.IsPostBack)
            {
                this.btncancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
                this.btnsend.Text = this.objLanguage.GetLanguageConversion("Send");
                this.Button2.Text = this.objLanguage.GetLanguageConversion("Send");
                this.Button1.Text = this.objLanguage.GetLanguageConversion("Cancel");
            }
            this.companyid = int.Parse(base.Session["companyid"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Session["TemplateID"] != null)
            {
                this.NewTemplateID = Convert.ToInt64(base.Session["TemplateID"].ToString());
            }
            if (base.Session["SelectedItemForPrint"] != null)
            {
                this.Items = base.Session["SelectedItemForPrint"].ToString();
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (base.Request.QueryString["ProofID"] != null)
            {
                this.ProofID = Convert.ToInt32(base.Request.Params["ProofID"]);
                if (!base.IsPostBack)
                {
                    Bind_Attachment_Proof();
                }
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            this.ordid = (base.Request.Params["ordid"] != null ? base.Request.Params["ordid"].ToString() : "0");
            this.EstID = Convert.ToInt32(base.Request.Params["EstID"].ToString());
            this.PageType = base.Request.Params["page"].ToString();
            this.CompanyType = base.Request.Params["type"].ToString();
            this.tabcolor = this.objpage.colorCode(this.companyid, base.Request.Params["sectionname"]);
            this.btnsend.BackColor = Color.FromName(this.tabcolor);
            this.btncancel.BackColor = Color.FromName(this.tabcolor);
            this.btnAddtext.BackColor = Color.FromName(this.tabcolor);
            this.btnAddddl.BackColor = Color.FromName(this.tabcolor);
            string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/" };
            this.StrDownload = string.Concat(secureSitePath);
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.objBase.SecureVirtualPath, this.ServerName, "/", base.Session["CompanyID"].ToString(), "/" };
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
            if (base.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            if (base.Request.Url.ToString().ToLower().Contains("occy.eprintsoftware.com"))
            {
                this.SysName = "occy";
            }
            commonClass _commonClass = new commonClass();
            this.EstimateID = Convert.ToInt64(base.Request.Params["EstID"].ToString());
            this.sectionid = int.Parse(base.Request.Params["sectionid"].ToString());
            this.sectionname = base.Request.Params["sectionname"].ToString();
            this.plhHeader.Controls.Add(new LiteralControl("<table cellspacing=0 cellpadding=0 border=0 width=100%>"));
            this.plhHeader.Controls.Add(new LiteralControl("<tr>"));
            this.plhHeader.Controls.Add(new LiteralControl("<td width=5 height=5 valign=top class=bgcustomize>"));
            this.plhHeader.Controls.Add(new LiteralControl(string.Concat("<img height=5 width=5 src='", global.imagePath(), "lt_tabnotch.gif'>")));
            this.plhHeader.Controls.Add(new LiteralControl("</td>"));
            this.plhHeader.Controls.Add(new LiteralControl("<td width=100% height=23 class='bgcustomize navigatorpanel'>&nbsp;&nbsp;New Email"));
            this.plhHeader.Controls.Add(new LiteralControl("</td>"));
            this.plhHeader.Controls.Add(new LiteralControl("<td valign=top width=5 height=5 class=bgcustomize>"));
            this.plhHeader.Controls.Add(new LiteralControl(string.Concat("<img height=5 width=5 src='", global.imagePath(), "rt_tabnotch.gif'>")));
            this.plhHeader.Controls.Add(new LiteralControl("</td>"));
            this.plhHeader.Controls.Add(new LiteralControl("</tr>"));
            this.plhHeader.Controls.Add(new LiteralControl("</table>"));
            global.pageName = this.sectionname.ToLower();
            this.gloobj.setpagename(this.sectionname.ToLower());
            global.pgDetail = string.Concat(this.objLanguage.convert("Company"), " >> ", this.objLanguage.convert("New Email"));
            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", base.Session["companyid"].ToString(), "/attachments/" };
            this.Str_AttachPath = string.Concat(secureDocPath);
            if (!base.IsPostBack && this.sectionname.ToLower() == "purchase")
            {
                DataTable dataTable = SettingsBasePage.settings_emailsetting_select(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()));
                foreach (DataRow row in dataTable.Rows)
                {
                    if (Convert.ToBoolean(row["IsPurchase_AttachAll"]) || Convert.ToBoolean(row["IsPurchase_AttachAll"]) && Convert.ToBoolean(row["Is_eStoreAttachment"]))
                    {
                        this.Bind_Attachment_Purchase();
                    }
                    else if (Convert.ToBoolean(row["Is_eStoreAttachment"]))
                    {
                        this.Bind_EstoreAttachment_Purchase();
                    }
                    if (Convert.ToBoolean(row["Purchase_AttachLink"]))
                    {
                        this.Bind_AttachmentLink_ForPurchase();
                    }
                    if (!Convert.ToBoolean(row["DeliveryNote_AttachLink"]))
                    {
                        continue;
                    }
                    this.Bind_DNAttachment_forPurchase();
                }
            }
            if (!base.IsPostBack)
            {
                this.LoadTemplateNameDDL();
                this.LoadEmailBodyAndSignature();
                for (int i = 1; i < this.ddlLeadMoreAction.Items.Count; i++)
                {
                    this.ddlLeadMoreAction.Items[i].Text = string.Concat(this.objBase.Padding, this.objBase.ReplaceSingleQuote(this.ddlLeadMoreAction.Items[i].Text));
                }
            }
            string str = string.Concat("../common/attachfile.aspx?pg=", this.sectionname);
            object[] objArray = new object[] { "../Common/email_Contact.aspx?sectionid=", this.sectionid, "&sectionname=", this.sectionname };
            string str1 = string.Concat(objArray);
            this.imgselectleadcc.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", str1, "', 'MarketingEmail','width=800,height=600,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=250,top=100');SetRadWindow('divrad', 'divBackGroundNew', '200'); return false;"));
            this.imgselectleadbcc.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", str1, "', 'MarketingEmail','width=800,height=600,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=250,top=100');SetRadWindow('divrad', 'divBackGroundNew', '200'); return false;"));
            this.LinkButton1.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", str, "','730','400');SetRadWindow('divrad', 'divBackGroundNew', '200');return false;"));
            if (!base.IsPostBack)
            {
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
            string str2 = this.sectionname;
            string str3 = str2;
            if (str2 != null)
            {
                switch (str3)
                {
                    case "Estimate":
                        {
                            QueryString queryString = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            this.RecordNumber = CompanyBasePage.get_module_number(this.companyid, "Estimate", Convert.ToInt32(base.Request.Params["EstID"].ToString()));
                            string str4 = string.Concat("../estimate/estimate_summary.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                            str4 = string.Concat(str4, queryString1.ToString());
                            break;
                        }
                    case "webstoreorder":
                        {
                            QueryString queryString2 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            this.RecordNumber = CompanyBasePage.get_module_number(this.companyid, "webstoreorder", Convert.ToInt32(base.Request.Params["EstID"].ToString()));
                            string str5 = string.Concat("../orders/order_summary.aspx?frm=view&ordid=", this.ordid, "&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                            str5 = string.Concat(str5, queryString3.ToString());
                            break;
                        }
                    case "Job":
                        {
                            QueryString queryString4 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            this.RecordNumber = CompanyBasePage.get_module_number(this.companyid, "Job", Convert.ToInt32(base.Request.Params["EstID"].ToString()));
                            string str6 = string.Concat("../jobs/job_summary.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
                            str6 = string.Concat(str6, queryString5.ToString());
                            break;
                        }
                    case "Invoice":
                        {
                            QueryString queryString6 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            this.RecordNumber = CompanyBasePage.get_module_number(this.companyid, "Invoice", Convert.ToInt32(base.Request.Params["EstID"].ToString()));
                            string str7 = string.Concat("../invoice/invoice_summary.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString7 = Encryption.EncryptQueryString(queryString6);
                            str7 = string.Concat(str7, queryString7.ToString());
                            break;
                        }
                    case "DeliveryNote":
                        {
                            QueryString queryString8 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            this.RecordNumber = CompanyBasePage.get_module_number(this.companyid, "DeliveryNote", Convert.ToInt32(base.Request.Params["EstID"].ToString()));
                            string str8 = string.Concat("../delivery/delivery_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
                            QueryString queryString9 = Encryption.EncryptQueryString(queryString8);
                            str8 = string.Concat(str8, queryString9.ToString());
                            break;
                        }
                    case "Purchase":
                        {
                            QueryString queryString10 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            this.RecordNumber = CompanyBasePage.get_module_number(this.companyid, "Purchase", Convert.ToInt32(base.Request.Params["EstID"].ToString()));
                            string str9 = string.Concat("../purchase/purchase_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
                            QueryString queryString11 = Encryption.EncryptQueryString(queryString10);
                            str9 = string.Concat(str9, queryString11.ToString());
                            break;
                        }
                    case "JobCard":
                        {
                            QueryString queryString12 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            this.RecordNumber = CompanyBasePage.get_module_number(this.companyid, "JobCard", Convert.ToInt32(base.Request.Params["EstID"].ToString()));
                            string str10 = string.Concat("../jobs/job_summary.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString13 = Encryption.EncryptQueryString(queryString12);
                            str10 = string.Concat(str10, queryString13.ToString());
                            break;
                        }
                    case "PrintBroker":
                        {
                            QueryString queryString14 = new QueryString()
                    {
                        { "clientid", this.sectionid.ToString() },
                        { "isnew", "2" },
                        { "bypass", "1" },
                        { "type", base.Request.Params["type"].ToString() }
                    };
                            string str11 = string.Concat("../estimate/estimate_summary.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                            QueryString queryString15 = Encryption.EncryptQueryString(queryString14);
                            str11 = string.Concat(str11, queryString15.ToString());
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
                string empty = string.Empty;
                DataTable dataTable1 = new DataTable();
                if (base.Request.Params["ProofID"] != null)
                {
                    dataTable1 = SettingsBasePage.settings_proof_template_select(this.companyid, this.EstimateID, this.Items);
                }
                else if (base.Request.Params["page"].ToLower().ToString() == "job")
                {
                    dataTable1 = SettingsBasePage.settings_titlecode_fortemplate_select(this.companyid, this.jobID, base.Request.Params["page"].ToString(), this.Items);
                }
                else if (base.Request.Params["page"].ToLower().ToString() != "invoice")
                {
                    dataTable1 = (base.Request.Params["page"].ToLower().ToString() == "estimate" || base.Request.Params["page"].ToLower().ToString() == "webstoreorder" ? SettingsBasePage.settings_titlecode_fortemplate_select(this.companyid, this.EstimateID, base.Request.Params["page"].ToString(), this.Items) : SettingsBasePage.settings_titlecode_fortemplate_select(this.companyid, this.EstimateID, base.Request.Params["page"].ToString(), this.Items));
                }
                else
                {
                    dataTable1 = SettingsBasePage.settings_titlecode_fortemplate_select(this.companyid, this.InvoiceID, base.Request.Params["page"].ToString(), this.Items);
                }
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    this.EstimateTitle = this.objBase.SpecialDecode(dataRow["Title"].ToString());
                    if (this.sectionname.ToLower() == "purchase" && this.EstimateTitle.Length > 0)
                    {
                        string[] strArrays2 = new string[] { "\r\n" };
                        this.EstimateTitle = base.Server.HtmlDecode(this.EstimateTitle.Split(strArrays2, StringSplitOptions.None)[0].Replace("Item Title:", ""));
                    }
                    this.hid_subject.Value = this.EstimateTitle;
                    this.EstimateNumber = dataRow["Number"].ToString();
                    empty = dataRow["TemNameLastCounter"].ToString();
                    this.txtfirstname.Value = this.objBase.SpecialDecode(dataRow["email"].ToString());
                }
                if (base.Request.Params["ProofID"] == null)
                {
                    if (!base.Request.Url.ToString().ToLower().Contains("handyenvelopes.eprintsoftware.com"))
                    {
                        this.txtcc.Value = "";
                    }
                    else
                    {
                        this.txtcc.Value = "";
                    }
                }
            
                if (base.Request.Params["ProofID"] != null)
                {
                    this.hid_TemplateKey.Value = "";
                }
                else
                {
                    this.hid_TemplateKey.Value = this.TemplateKey;
                }
                string str12 = string.Empty;
                if (!string.IsNullOrEmpty(this.hid_TemplateKey.Value))
                {
                    str12 = SettingsBasePage.settings_template_emailed_select(this.hid_TemplateKey.Value);
                    if (base.Request.Params["Page"].ToString().ToLower() != "printbroker")
                    {
                        str12 = string.Concat(this.EstimateNumber, "-", empty, ".pdf");
                    }
                }
                if (base.Request.Params["ProofID"] != null)
                {
                    this.txtattachment.Style["display"] = "none";
                    this.txtattachment.Value = str12;
                    this.Div_Attach.Style["margin-top"] = "-20px";
                }
                else
                {
                    this.txtattachment.Style["display"] = "block";
                    this.txtattachment.Value = str12;
                }
                this.ReplaceAllTags(dataTable1, this.TemplateKey, base.Request.Params["page"].ToString());
                string empty1 = string.Empty;
                DataTable dataTable2 = SettingsBasePage.template_email_phrasebook_select(this.companyid, "Email Body", base.Request.Params["page"].ToString(), "all");
                foreach (DataRow row1 in dataTable2.Rows)
                {
                    string str13 = empty1;
                    string[] strArrays3 = new string[] { str13, row1["PhraseBookID"].ToString(), "±", row1["PhraseText"].ToString(), "µ" };
                    empty1 = string.Concat(strArrays3);
                }
                this.hid_EmailTemplateValue.Value = empty1;
                DataTable dataTable3 = SettingsBasePage.settings_emailsetting_select(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()));
                foreach (DataRow dataRow1 in dataTable3.Rows)
                {
                    this.hid_EmailSettingType.Value = dataRow1["EmailSettingType"].ToString();
                    if (Convert.ToBoolean(dataRow1["IsCheckedCC"]) && dataRow1["cc"].ToString().Length > 0)
                    {
                        if (this.txtcc.Value.Length <= 0)
                        {
                            this.txtcc.Value = this.objBase.SpecialDecode(dataRow1["cc"].ToString());
                        }
                        else
                        {
                            HtmlTextArea htmlTextArea = this.txtcc;
                            htmlTextArea.Value = string.Concat(htmlTextArea.Value, ",", this.objBase.SpecialDecode(dataRow1["cc"].ToString()));
                        }
                    }
                    if (!Convert.ToBoolean(dataRow1["IsCheckedBCC"]) || dataRow1["bcc"].ToString().Length <= 0)
                    {
                        continue;
                    }
                    if (this.txtbcc.Value.Length <= 0)
                    {
                        this.txtbcc.Value = this.objBase.SpecialDecode(dataRow1["bcc"].ToString());
                    }
                    else
                    {
                        HtmlTextArea htmlTextArea1 = this.txtbcc;
                        htmlTextArea1.Value = string.Concat(htmlTextArea1.Value, ",", this.objBase.SpecialDecode(dataRow1["bcc"].ToString()));
                    }
                }
                this.pnl_ShowEmailType.Visible = true;
            }
            if (this.sectionname.ToLower() == "job")
            {
                this.IS_INVOICEorJOB_from_Webstore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
                return;
            }
            if (this.sectionname.ToLower() == "invoice")
            {
                this.IS_INVOICEorJOB_from_Webstore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, "invoice");
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
            string str = string.Concat(this.strSitePath, "pdf.aspx?key=", TemplateKey);
            string str1 = string.Concat(base.Session["firstName"].ToString(), " ", base.Session["lastName"].ToString());
            if (dt.Rows.Count > 0)
            {
                DataRow item = dt.Rows[0];
                string[] strArrays2 = new string[] { "<a href='", str, "'>", str, "</a>" };
                content = content.Replace("[$PDFPath$]", string.Concat(strArrays2));
                content = content.Replace("[$EmailFooter$]", str1);
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
                                string[] strArrays3 = new string[] { "<a href=", this.StrDownload.ToString(), strArrays[i], " target='_blank'>", strArrays1[i], "</a><br />" };
                                stringBuilder.Append(string.Concat(strArrays3));
                            }
                            else
                            {
                                string[] strArrays4 = new string[] { "<br /><a href=", this.StrDownload.ToString(), strArrays[i], " target='_blank'>", strArrays1[i], "</a><br />" };
                                stringBuilder.Append(string.Concat(strArrays4));
                            }
                        }
                    }
                    content = (stringBuilder.Length != 0 ? content.Replace("[$AttachmentsPath$]", stringBuilder.ToString()) : content.Replace("[$AttachmentsPath$]", ""));
                }
                if (ModuleName.Trim().ToLower() == "estimate")
                {
                    content = content.Replace("[$EstimateTitle$]", item["EstimateTitle"].ToString());
                    content = content.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                    content = content.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    content = content.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    content = content.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    content = content.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    content = content.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    content = content.Replace("[$EstimateDate$]", _commonClass.Eprint_return_Date_Before_View(item["EstimateDate"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$EstimatedArtwork$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedArtwork"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$EstimatedDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedDelivery"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$ValidFor$]", item["ValidFor"].ToString());
                    content = content.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    content = content.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    content = content.Replace("[$EstimateHeader$]", item["EstimateHeader"].ToString());
                    content = content.Replace("[$EstimateFooter$]", item["EstimateFooter"].ToString());
                    content = content.Replace("[$EstimateValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["EstimateValue"].ToString()), 0, "", false, false, true));

                    content = Utilities.ReplaceConsigneeUrlTags(item, content);
                    value = Utilities.ReplaceConsigneeUrlTags(item, value);

                    value = value.Replace("[$EstimateTitle$]", item["EstimateTitle"].ToString());
                    value = value.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                    value = value.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    value = value.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    value = value.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    value = value.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    value = value.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    value = value.Replace("[$EstimateDate$]", _commonClass.Eprint_return_Date_Before_View(item["EstimateDate"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$EstimatedArtwork$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedArtwork"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$EstimatedDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["EstimatedDelivery"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$ValidFor$]", item["ValidFor"].ToString());
                    value = value.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    value = value.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    value = value.Replace("[$EstimateHeader$]", item["EstimateHeader"].ToString());
                    value = value.Replace("[$EstimateFooter$]", item["EstimateFooter"].ToString());

                    value = value.Replace("[$EstimateValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["EstimateValue"].ToString()), 0, "", false, false, true));
                }
                else if (ModuleName.Trim().ToLower() == "job" || ModuleName.Trim().ToLower() == "jobcard")
                {
                    content = content.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                    content = content.Replace("[$JobNumber$]", item["JobNumber"].ToString());
                    content = content.Replace("[$JobTitle$]", item["JobTitle"].ToString());
                    content = content.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    content = content.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    content = content.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    content = content.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    content = content.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    content = content.Replace("[$JobDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["JobDelivery"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$JobCompletionDate$]", _commonClass.Eprint_return_Date_Before_View(item["JobCompletionDate"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$JobOrderNumber$]", item["JobOrderNumber"].ToString());
                    content = content.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    content = content.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    content = content.Replace("[$JobHeader$]", item["JobHeader"].ToString());
                    content = content.Replace("[$JobFooter$]", item["JobFooter"].ToString());
                    content = content.Replace("[$JobValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["JobValue"].ToString()), 0, "", false, false, true));
                    content = content.Replace("[$Consignment Note Number$]", item["ConsignmentNumber"].ToString());
                    //content = content.Replace("[$ConsigneeURL$]", item["ConsigneeUrl"].ToString());
                    content = content.Replace("[$SupplierName$]", item["SupplierName"].ToString());
                    content = content.Replace("[$SupplierContactFirstName$]", item["SupplierContactFirstName"].ToString());
                    content = content.Replace("[$SupplierContactMiddleName$]", item["SupplierContactMiddleName"].ToString());
                    content = content.Replace("[$SupplierContactLastName$]", item["SupplierContactLastName"].ToString());
                    content = content.Replace("[$SupplierContactFullName$]", item["SupplierContactFullName"].ToString());
                    content = Utilities.ReplaceConsigneeUrlTags(item, content);
                    value = Utilities.ReplaceConsigneeUrlTags(item, value);

                    value = value.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                    value = value.Replace("[$JobNumber$]", item["JobNumber"].ToString());
                    value = value.Replace("[$JobTitle$]", item["JobTitle"].ToString());
                    value = value.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    value = value.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    value = value.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    value = value.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    value = value.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    value = value.Replace("[$JobDelivery$]", _commonClass.Eprint_return_Date_Before_View(item["JobDelivery"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$JobCompletionDate$]", _commonClass.Eprint_return_Date_Before_View(item["JobCompletionDate"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$JobOrderNumber$]", item["JobOrderNumber"].ToString());
                    value = value.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    value = value.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    value = value.Replace("[$JobHeader$]", item["JobHeader"].ToString());
                    value = value.Replace("[$JobFooter$]", item["JobFooter"].ToString());
                    value = value.Replace("[$JobValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["JobValue"].ToString()), 0, "", false, false, true));

                }
                else if (ModuleName.Trim().ToLower() == "invoice")
                {
                    content = content.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                    content = content.Replace("[$JobNumber$]", item["JobNumber"].ToString());
                    content = content.Replace("[$InvoiceNumber$]", item["InvoiceNumber"].ToString());

                    content = Utilities.ReplaceConsigneeUrlTags(item, content);
                    value = Utilities.ReplaceConsigneeUrlTags(item, value);

                    DataTable _dt = this.objTemplates.settings_template_FieldValue_select(this.companyid, this.InvoiceID, "invoice");
                    string InvoiceTitle = string.Empty;
                    string InvoiceNumber = string.Empty;
                    string OrderTotalPrice = string.Empty;

                    foreach (DataRow current in _dt.Rows)
                    {
                        InvoiceTitle = current["InvoiceTitle"].ToString();
                        InvoiceNumber = current["InvoiceNumber"].ToString();
                        OrderTotalPrice = _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, this.UserID, Convert.ToDecimal(current["OrderTotalPrice"].ToString()), 0, "", false, false, true);
                    }
                    string currency = "";
                    DataTable currencySymbolCurrency = _commonClass.Get_Currency_Company(this.companyid);
                    if (currencySymbolCurrency != null)
                    {
                        currency = currencySymbolCurrency.Rows[0][0].ToString().Trim();
                    }
                    string paymentUrl = "" + global.sitePath() + "/StripePaymentHandler.ashx?InvID=" + this.InvoiceID + "&EstimateID=" + _dt.Rows[0]["EstimateID"].ToString() + "&InvoiceNumber=" + InvoiceNumber + "&InvoiceTitle=" + HttpUtility.UrlEncode(InvoiceTitle) + "&OrderTotalPrice=" + OrderTotalPrice+ "&Currency=" +  (string.IsNullOrEmpty(currency) ? "AUD" : currency) + "";

                    string str5 = HttpContext.Current.Request.Url.Host.ToString();
                    if (str5.Trim().ToLower() == "localhost" || str5.Trim().ToLower() == "192.168.1.6")
                    {
                        str5 = ConfigurationManager.AppSettings["HostName"].ToString();
                    }
                    DataTable dataTable = SettingsBasePage.GetStripeDetails(Convert.ToInt32(this.companyid), str5);
                    string stripeImage = string.Empty;
                    string stripeImagePath = string.Empty;
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        stripeImage = dr["StripeImage"].ToString();
                        if (!string.IsNullOrEmpty(stripeImage))
                        {
                            string[] secureDocPath3 = new string[] { global.sitePath(), "/document/SecureDoc/", this.ServerName, "/", this.companyid.ToString(), "/Stripe/", stripeImage };
                            stripeImagePath = string.Concat(secureDocPath3);
                        }
                        else
                        {
                            stripeImagePath = global.sitePath() + "/images/stripe.jpg";
                        }
                        
                    }
                    string stripeImageLink = stripeImagePath.Replace("\\", "\\\\");
                    string imageTag = $"<img src=\"{stripeImageLink}\" alt=\"Stripe Payment\" />";
                    string linkTag = $"<a href=\"{paymentUrl}\">{imageTag}</a>";

                    content = content.Replace("[$StripePaymentLink$]", linkTag);


                    content = content.Replace("[$InvoiceTitle$]", item["InvoiceTitle"].ToString());
                    content = content.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    content = content.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    content = content.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    content = content.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    content = content.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    content = content.Replace("[$InvoiceDate$]", _commonClass.Eprint_return_Date_Before_View(item["InvoiceDate"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$InvoiceOrderNumber$]", item["InvoiceOrderNumber"].ToString());
                    content = content.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    content = content.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    content = content.Replace("[$InvoiceHeader$]", item["InvoiceHeader"].ToString());
                    content = content.Replace("[$InvoiceFooter$]", item["InvoiceFooter"].ToString());
                    content = content.Replace("[$InvoiceValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["InvoiceValue"].ToString()), 0, "", false, false, true));
                    content = content.Replace("[$InvoiceAmountPaid$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["InvoiceAmountPaid"].ToString()), 0, "", false, false, true));
                    content = content.Replace("[$InvoiceAmountOutstanding$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["InvoiceAmountOutstanding"].ToString()), 0, "", false, false, true));
                    content = content.Replace("[$InvoiceDueDate$]", _commonClass.Eprint_return_Date_Before_View(item["InvoiceDueDate"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$EstimateNumber$]", item["EstimateNumber"].ToString());
                    value = value.Replace("[$JobNumber$]", item["JobNumber"].ToString());
                    value = value.Replace("[$InvoiceNumber$]", item["InvoiceNumber"].ToString());
                    value = value.Replace("[$InvoiceTitle$]", item["InvoiceTitle"].ToString());
                    value = value.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    value = value.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    value = value.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    value = value.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    value = value.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    value = value.Replace("[$InvoiceDate$]", _commonClass.Eprint_return_Date_Before_View(item["InvoiceDate"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$InvoiceDueDate$]", _commonClass.Eprint_return_Date_Before_View(item["InvoiceDueDate"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$InvoiceOrderNumber$]", item["InvoiceOrderNumber"].ToString());
                    value = value.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    value = value.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    value = value.Replace("[$InvoiceHeader$]", item["InvoiceHeader"].ToString());
                    value = value.Replace("[$InvoiceFooter$]", item["InvoiceFooter"].ToString());
                    value = value.Replace("[$InvoiceValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["InvoiceValue"].ToString()), 0, "", false, false, true));
                    value = value.Replace("[$InvoiceAmountPaid$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["InvoiceAmountPaid"].ToString()), 0, "", false, false, true));
                    value = value.Replace("[$InvoiceAmountOutstanding$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["InvoiceAmountOutstanding"].ToString()), 0, "", false, false, true));

                    content = content.Replace("[$CarrierName$]", item["CarrierName"].ToString());
                    content = content.Replace("[$ShippedTo$]", item["ShippedTo"].ToString());
                    //content = content.Replace("[$ConsigneeURL$]", item["ConsigneeUrl"].ToString());
                    content = content.Replace("[$Consignment Note Number$]", item["ConsignmentNumber"].ToString());

                }
                else if (ModuleName.Trim().ToLower() == "purchase")
                {
                    content = content.Replace("[$PONumber$]", item["PONumber"].ToString());
                    content = content.Replace("[$RefNo$]", item["ReferenceNo"].ToString());
                    content = content.Replace("[$SupplierName$]", item["SupplierName"].ToString());
                    content = content.Replace("[$SupplierContactFirstName$]", item["SupplierContactFirstName"].ToString());
                    content = content.Replace("[$SupplierContactLastName$]", item["SupplierContactLastName"].ToString());
                    content = content.Replace("[$SupplierContactFullName$]", item["SupplierContactFullName"].ToString());
                    content = content.Replace("[$SupplierContactEmail$]", item["SupplierContactEmail"].ToString());
                    content = content.Replace("[$PurchaseHeader$]", item["PurchaseHeader"].ToString());
                    content = content.Replace("[$PurchaseFooter$]", item["PurchaseFooter"].ToString());
                    content = content.Replace("[$RequiredDate$]", _commonClass.Eprint_return_Date_Before_View(item["RequiredDate"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$RaisedBy$]", item["RaisedBy"].ToString());
                    content = content.Replace("[$PriceIncTax$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["PriceIncTax"].ToString()), 0, "", false, false, true));
                    content = content.Replace("[$PriceExTax$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["PriceExTax"].ToString()), 0, "", false, false, true));
                    content = content.Replace("[$Quantity$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["Quantity"].ToString()), 0, "", true, false, true));
                    content = content.Replace("[$POComments$]", item["POComments"].ToString());
                    content = content.Replace("[$PurchaseTitle$]", item["Title"].ToString());
                    content = content.Replace("[$JobTitle$]", item["JobTitle"].ToString());
                    content = content.Replace("[$SupplierQuoteNumber$]", item["SupplierQuoteNumber"].ToString());
                    content = content.Replace("[$JobOrderTitle$]", item["JobOrderTitle"].ToString());
                    value = value.Replace("[$PONumber$]", item["PONumber"].ToString());
                    value = value.Replace("[$RefNo$]", item["ReferenceNo"].ToString());
                    value = value.Replace("[$SupplierName$]", item["SupplierName"].ToString());
                    value = value.Replace("[$SupplierContactFirstName$]", item["SupplierContactFirstName"].ToString());
                    value = value.Replace("[$SupplierContactLastName$]", item["SupplierContactLastName"].ToString());
                    value = value.Replace("[$SupplierContactFullName$]", item["SupplierContactFullName"].ToString());
                    value = value.Replace("[$SupplierContactEmail$]", item["SupplierContactEmail"].ToString());
                    value = value.Replace("[$PurchaseHeader$]", item["PurchaseHeader"].ToString());
                    value = value.Replace("[$PurchaseFooter$]", item["PurchaseFooter"].ToString());
                    value = value.Replace("[$RequiredDate$]", _commonClass.Eprint_return_Date_Before_View(item["RequiredDate"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$RaisedBy$]", item["RaisedBy"].ToString());
                    value = value.Replace("[$PriceIncTax$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["PriceIncTax"].ToString()), 0, "", false, false, true));
                    value = value.Replace("[$PriceExTax$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["PriceExTax"].ToString()), 0, "", false, false, true));
                    value = value.Replace("[$Quantity$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["Quantity"].ToString()), 0, "", true, false, true));
                    value = value.Replace("[$POComments$]", item["POComments"].ToString());
                    value = value.Replace("[$PurchaseTitle$]", item["Title"].ToString());
                    value = value.Replace("[$JobTitle$]", item["JobTitle"].ToString());
                    value = value.Replace("[$SupplierQuoteNumber$]", item["SupplierQuoteNumber"].ToString());
                    value = value.Replace("[$JobOrderTitle$]", item["JobOrderTitle"].ToString());
                }
                else if (ModuleName.Trim().ToLower() == "note")
                {
                    content = content.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    content = content.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    content = content.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    content = content.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    content = content.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    content = content.Replace("[$DeliveryHeader$]", item["DeliveryHeader"].ToString());
                    content = content.Replace("[$DeliveryFooter$]", item["DeliveryFooter"].ToString());
                    content = content.Replace("[$DeliveryNumber$]", item["DeliveryNumber"].ToString());
                    content = content.Replace("[$RefNo$]", item["RefNo"].ToString());
                    content = content.Replace("[$OrderNumber$]", item["OrderNumber"].ToString());
                    content = content.Replace("[$CarrierName$]", item["CarrierName"].ToString());
                    content = content.Replace("[$DeliveryDate$]", _commonClass.Eprint_return_Date_Before_View(item["DeliveryDate"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$ShippedTo$]", item["ShippedTo"].ToString());
                    // ConsignmentNumber AND ConsigneeUrl
                    content = Utilities.ReplaceConsigneeUrlTags(item, content);
                    value = Utilities.ReplaceConsigneeUrlTags(item, value);
                    content = content.Replace("[$Consignment Note Number$]", item["ConsignmentNumber"].ToString());
                    content = content.Replace("[$JobTitle$]", item["JobTitle"].ToString());

                    value = value.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    value = value.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    value = value.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    value = value.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    value = value.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    value = value.Replace("[$DeliveryHeader$]", item["DeliveryHeader"].ToString());
                    value = value.Replace("[$DeliveryFooter$]", item["DeliveryFooter"].ToString());
                    value = value.Replace("[$DeliveryNumber$]", item["DeliveryNumber"].ToString());
                    value = value.Replace("[$RefNo$]", item["RefNo"].ToString());
                    value = value.Replace("[$OrderNumber$]", item["OrderNumber"].ToString());
                    value = value.Replace("[$CarrierName$]", item["CarrierName"].ToString());
                    value = value.Replace("[$DeliveryDate$]", _commonClass.Eprint_return_Date_Before_View(item["DeliveryDate"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$ShippedTo$]", item["ShippedTo"].ToString());
                    // ConsignmentNumber AND ConsigneeUrl
                    //value = value.Replace("[$ConsigneeURL$]", item["ConsigneeUrl"].ToString());
                    value = value.Replace("[$Consignment Note Number$]", item["ConsignmentNumber"].ToString());
                    value = value.Replace("[$JobTitle$]", Convert.ToString(item["JobTitle"]));

                }
                else if (ModuleName.Trim().ToLower() == "webstoreorder")
                {
                    content = content.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    content = content.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    content = content.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    content = content.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    content = content.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    content = content.Replace("[$OrderNumber$]", item["OrderNumber"].ToString());
                    content = content.Replace("[$DeliveryDate$]", _commonClass.Eprint_return_Date_Before_View(item["DeliveryDate"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$OrderDate$]", _commonClass.Eprint_return_Date_Before_View(item["OrderedDate"].ToString(), this.companyid, 0, false));
                    content = content.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    content = content.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    content = content.Replace("[$OrderValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["OrderValue"]), 0, "", false, false, true));
                    content = Utilities.ReplaceConsigneeUrlTags(item, content);
                    value = Utilities.ReplaceConsigneeUrlTags(item, value);
                    value = value.Replace("[$CustomerContactFirstName$]", item["CustomerContactFirstName"].ToString());
                    value = value.Replace("[$CustomerContactLastName$]", item["CustomerContactLastName"].ToString());
                    value = value.Replace("[$CustomerContactFullName$]", item["CustomerContactFullName"].ToString());
                    value = value.Replace("[$CustomerContactEmail$]", item["CustomerContactEmail"].ToString());
                    value = value.Replace("[$CustomerName$]", item["CustomerName"].ToString());
                    value = value.Replace("[$OrderNumber$]", item["OrderNumber"].ToString());
                    value = value.Replace("[$DeliveryDate$]", _commonClass.Eprint_return_Date_Before_View(item["DeliveryDate"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$OrderDate$]", _commonClass.Eprint_return_Date_Before_View(item["OrderedDate"].ToString(), this.companyid, 0, false));
                    value = value.Replace("[$SalesPerson$]", item["SalesPerson"].ToString());
                    value = value.Replace("[$SalesPersonEmail$]", item["SalesPersonEmail"].ToString());
                    value = value.Replace("[$OrderValue$]", _commonClass.Eprint_ReturnFinal_Formated_Amount(this.companyid, Convert.ToInt32(base.Session["UserID"].ToString()), Convert.ToDecimal(item["OrderValue"]), 0, "", false, false, true));
                }
                if (base.Request.Params["ProofID"] != null)
                {
                    if (!string.IsNullOrEmpty(content))
                    {
                        if (ModuleName.Trim().ToLower() == "estimate")
                        {
                            content = content.Replace("[$EstimateOrJobname$]", item["EstimateTitle"].ToString());
                        }
                        else
                        {
                            content = content.Replace("[$EstimateOrJobname$]", item["JobTitle"].ToString());
                        }
                        content = content.Replace("[$CustomerContactName$]", item["CustomerContactFullName"].ToString());
                        content = content.Replace("[$JobNumber$]", item["JobNumber"].ToString());
                        content = content.Replace("[$EstimatorPerson$]", item["Estimator"].ToString());
                        content = content.Replace("[$EstimatorPersonEmail$]", item["EstimatorEmail"].ToString());

                        this.txtcc.Value = txtcc.Value.Replace("[$EstimatorPersonEmail$]", item["EstimatorEmail"].ToString());
                        this.txtbcc.Value = txtbcc.Value.Replace("[$EstimatorPersonEmail$]", item["EstimatorEmail"].ToString());

                        int proofID = int.Parse(base.Request.Params["ProofID"]);
                        //int _estimateID = int.Parse(base.Request.Params["EstID"]);
                        int _estimateID = int.Parse(item["EstimateID"].ToString());
                        int _clientID = int.Parse(base.Request.Params["sectionid"]);
                        if (_clientID == 0)
                        {
                            _clientID = int.Parse(item["clientID"].ToString());
                        }
                        string proofNo = EstimateBasePage.Get_Proof_Number(proofID);
                        if (!string.IsNullOrEmpty(proofNo))
                        {
                            content = content.Replace("[$ProofNumber$]", proofNo);
                        }
                        //if (content.ToLower().Contains("https://proofingapp.eprintsoftware.com/"))
                        //{
                        //var url = "https://proofingapp.eprintsoftware.com/";
                        string companyID = base.Session["CompanyID"].ToString();
                        string UserID = base.Session["UserID"].ToString();
                        string hostname = string.Empty;

                        DataSet appSettingsAndConnectionString = EprintConfigurationManager.GetAppSettingsAndConnectionString();
                        DataTable _item = appSettingsAndConnectionString.Tables[0];
                        DateTime _date = DateTime.Now;
                        string dateTime = string.Format("{0:MM/dd/yyyyhh:mm:ss}", _date).Replace("/", "").Replace(":", "");
                        foreach (DataRow dr in _item.Rows)
                        {
                            hostname = dr["HostName"].ToString();
                        }
                        //var url = hostname + "/proofing/";
                        var url = hostname + "/proof/";
                        string[] _params;
                        _params = new string[] { "hName=", hostname, "&uID=", UserID, "&cID=", companyID, "&PID=", proofID.ToString(), "&EID=", _estimateID.ToString(), "&CLID=", _clientID.ToString() };
                        string parameters = string.Concat(_params);
                        string encryptedUrl = commonClass.Base64Encode(parameters);
                        string serverName = ConnectionClass.ServerName;
                        //string urlWithParams = url + "" + serverName + "/ProofListingItem?params=" + encryptedUrl;
                        string urlWithParams = url + "ProofListingItem?params=" + encryptedUrl;
                        string finalUrl = string.Concat(urlWithParams, dateTime);
                        content = content.Replace(url, finalUrl);

                        //}
                    }

                    if (!string.IsNullOrEmpty(value))
                    {
                        if (ModuleName.Trim().ToLower() == "estimate")
                        {
                            value = value.Replace("[$EstimateOrJobname$]", item["EstimateTitle"].ToString());
                        }
                        else
                        {
                            value = value.Replace("[$EstimateOrJobname$]", item["JobTitle"].ToString());
                        }
                        value = value.Replace("[$CustomerContactName$]", item["CustomerContactFullName"].ToString());
                        value = value.Replace("[$JobNumber$]", item["JobNumber"].ToString());

                        int proofID = int.Parse(base.Request.Params["ProofID"]);
                        int _estimateID = int.Parse(item["EstimateID"].ToString());
                        int _clientID = int.Parse(base.Request.Params["sectionid"]);
                        if (_clientID == 0)
                        {
                            _clientID = int.Parse(item["clientID"].ToString());
                        }
                        string proofNo = EstimateBasePage.Get_Proof_Number(proofID);
                        if (!string.IsNullOrEmpty(proofNo))
                        {
                            value = value.Replace("[$ProofNumber$]", proofNo);
                        }
                    }

                }

                this.RadareaEditor.Content = this.objBase.SpecialDecode(content);
                this.txtsubject.Value = this.objBase.SpecialDecode(value);
                this.hid_body.Value = (content.Length > 1500 ? string.Concat(content.Substring(0, 1500).ToString(), "<\n>", str) : content);
            }
        }
    }
}