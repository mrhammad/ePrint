using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mail;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;

namespace ePrint.common
{
    public partial class email_send_activityhistory : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private CompanyBasePage objComp = new CompanyBasePage();

        private commonClass comncls = new commonClass();

        public BasePage objpage = new BasePage();

        public languageClass objLanguage = new languageClass();

        public int companyid;

        public int UserID;

        public int sectionid;

        public int touserid;

        private string message = string.Empty;

        public string[] stremailArray;

        public string[] stremailArrayBoth;

        public string[] stremailArrayID;

        public string[] stremailArrayBothID;

        public string strImagepath = global.imagePath();

        public string sirSitePath = global.sitePath();

        public string strUKey;

        public string strSession;

        public string strUID;

        public string strCC;

        public string strBCC;

        public string strSubject;

        public string strAttachment;

        public string sectionname = "";

        public string tabcolor = "";

        public string msgText = string.Empty;

        public string DateFormat = string.Empty;

        public string strDate = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private DateTime sendDate;

        private DateTime openedDate;

        private DateTime lastViewDate;

        public string CustomerName = string.Empty;

        public string ServerName = ConnectionClass.ServerName;

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

        public email_send_activityhistory()
        {
        }

        private void BindDdl(DropDownList ddlAddExisting)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("sp_select_template_ddl", _commonClass.openConnection());
            sqlCommand.Parameters.Add("@Companyid", int.Parse(this.Session["companyid"].ToString()));
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
                sqlCommand.Parameters.Add("@templatename", base.SpecialEncode(this.txtAddNew.Text));
                sqlCommand.Parameters.Add("@templateType", base.SpecialEncode(this.ddltemplateType.SelectedItem.Text));
                sqlCommand.Parameters.Add("@Message", base.SpecialEncode(this.msgText));
                sqlCommand.Parameters.Add("@userid", int.Parse(this.Session["userID"].ToString()));
                sqlCommand.Parameters.Add("@companyid", int.Parse(this.Session["companyID"].ToString()));
                sqlCommand.Parameters.Add("@section", "campaign");
                sqlCommand.Parameters.Add("@createdbyid", int.Parse(this.Session["userID"].ToString()));
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
                sqlCommand1.Parameters.Add("@templatename", base.SpecialEncode(this.txtAddNew.Text));
                sqlCommand1.Parameters.Add("@templateType", base.SpecialEncode(this.ddltemplateType.SelectedItem.Text));
                sqlCommand1.Parameters.Add("@Message", base.SpecialEncode(this.msgText));
                sqlCommand1.Parameters.Add("@userid", int.Parse(this.Session["userID"].ToString()));
                sqlCommand1.Parameters.Add("@companyid", int.Parse(this.Session["companyID"].ToString()));
                sqlCommand1.Parameters.Add("@section", "campaign");
                sqlCommand1.Parameters.Add("@createdbyid", int.Parse(this.Session["userID"].ToString()));
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

        protected void btnsend_Click(object sender, EventArgs e)
        {
            string str;
            this.sendDate = DateTime.Now;
            this.openedDate = DateTime.Now;
            this.lastViewDate = DateTime.Now;
            string str1 = "emaillogs@hexicomsoftware.com";
            bool flag = false;
            string value = this.txtfirstname.Value;
            string str2 = base.SpecialEncode(this.txtcc.Value);
            string str3 = base.SpecialEncode(this.txtbcc.Value);
            string str4 = base.SpecialEncode(this.txtsubject.Value);
            string str5 = base.SpecialEncode(this.txtattachment.Value);
            if (this.ddltemplateType.SelectedValue != "1")
            {
                this.msgText = this.areaEditor.Text.ToString();
            }
            else
            {
                this.msgText = this.RadEditor1.Content.ToString();
            }
            this.message = base.SpecialEncode(this.msgText);
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            num2 = (this.ddlLeadMoreAction.SelectedValue != "1" ? 0 : 1);
            if (this.ddlLeadMoreAction.SelectedValue != "1")
            {
                str = "";
            }
            else
            {
                str = base.SpecialEncode(this.ddlselecttemplate.SelectedItem.Text);
                int.Parse(this.ddlselecttemplate.SelectedItem.Value);
            }
            int value1 = 0;
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_insertEmail", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            string str6 = "";
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.AddWithValue("@pg", this.sectionname);
            sqlCommand.Parameters.AddWithValue("@id", this.sectionid);
            sqlCommand.Parameters.AddWithValue("@toUserID", 0);
            sqlCommand.Parameters.AddWithValue("@companyID", int.Parse(this.Session["companyID"].ToString()));
            sqlCommand.Parameters.AddWithValue("@CC", base.SpecialEncode(str2));
            sqlCommand.Parameters.AddWithValue("@BCC", str3);
            sqlCommand.Parameters.AddWithValue("@subject", str4);
            sqlCommand.Parameters.AddWithValue("@attachment", str5);
            sqlCommand.Parameters.AddWithValue("@message", this.message);
            sqlCommand.Parameters.AddWithValue("@fromUserID", int.Parse(this.Session["userID"].ToString()));
            sqlCommand.Parameters.AddWithValue("@dateSent", this.sendDate);
            sqlCommand.Parameters.AddWithValue("@dateOpened", this.openedDate);
            sqlCommand.Parameters.AddWithValue("@isRead", num1);
            sqlCommand.Parameters.AddWithValue("@noOfView", num);
            sqlCommand.Parameters.AddWithValue("@lastViewDate", this.lastViewDate);
            sqlCommand.Parameters.AddWithValue("@istemplate", num2);
            sqlCommand.Parameters.AddWithValue("@templatename", str);
            sqlCommand.Parameters.AddWithValue("@TO", base.SpecialEncode(value));
            sqlCommand.Parameters.AddWithValue("@sectionnumber", "CRM");
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            _commonClass.Dispose();
            value1 = (int)sqlCommand.Parameters["ReturnValue"].Value;
            commonClass _commonClass1 = new commonClass();
            SqlCommand sqlCommand1 = new SqlCommand("crm_select_leadsHTMLEmail", _commonClass1.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand1.Parameters.AddWithValue("@companyid", int.Parse(this.Session["companyid"].ToString()));
            SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader();
            while (sqlDataReader.Read())
            {
                str6 = sqlDataReader["leadsHTMLEmail"].ToString();
            }
            sqlDataReader.Close();
            sqlDataReader.Dispose();
            _commonClass1.closeConnection();
            _commonClass1.Dispose();
            if (str6 == "")
            {
                str6 = this.Session["email"].ToString();
            }
            string[] files = Directory.GetFiles(string.Concat(base.Server.MapPath("../"), "tempattachment/"));
            string empty = string.Empty;
            if (this.txtfirstname.Value != "")
            {
                string str7 = base.SpecialEncode(this.txtfirstname.Value.ToString());
                char[] chrArray = new char[] { ',' };
                this.stremailArray = str7.Split(chrArray);
            }
            try
            {
                for (int i = 0; i < (int)this.stremailArray.Length; i++)
                {
                    commonClass _commonClass2 = new commonClass();
                    string empty1 = string.Empty;
                    empty1 = this.message;
                    empty = "Lead";
                    SqlCommand sqlCommand2 = new SqlCommand("crm_campaign_selectDataTemplate", _commonClass2.openConnection());
                    sqlCommand2.Parameters.Add("@sectionid", this.sectionid);
                    sqlCommand2.Parameters.Add("@emailtype", empty);
                    sqlCommand2.Parameters.Add("@CompanyID", this.Session["companyID"].ToString());
                    sqlCommand2.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader(CommandBehavior.CloseConnection);
                    while (sqlDataReader1.Read())
                    {
                        empty1 = empty1.Replace("[$leadsalutation$]", sqlDataReader1["salutation"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadfirstname$]", sqlDataReader1["firstName"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadlastname$]", sqlDataReader1["lastName"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadcompanyname$]", sqlDataReader1["companyName"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadtitle$]", sqlDataReader1["title"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadindustryname$]", sqlDataReader1["industryName"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadphone$]", sqlDataReader1["phone"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadmobile$]", sqlDataReader1["mobile"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadfax$]", sqlDataReader1["fax"].ToString().Trim());
                        empty1 = empty1.Replace("[$leademail$]", sqlDataReader1["email"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadwebsite$]", sqlDataReader1["website"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadstreet$]", sqlDataReader1["street"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadcity$]", sqlDataReader1["city"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadstate$]", sqlDataReader1["state"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadzip$]", sqlDataReader1["zip"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadcountry$]", sqlDataReader1["country"].ToString().Trim());
                        empty1 = empty1.Replace("[$leadleadalias$]", sqlDataReader1["leadalias"].ToString().Trim());
                    }
                    sqlDataReader1.Close();
                    _commonClass2.closeConnection();
                    string str8 = this.GenPassWithCap(24).ToString();
                    SqlCommand sqlCommand3 = new SqlCommand("crm_campaign_insertmarketingEmail", _commonClass2.openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter sqlParameter1 = sqlCommand3.Parameters.AddWithValue("ReturnMarketingIdValue", SqlDbType.Int);
                    sqlParameter1.Direction = ParameterDirection.ReturnValue;
                    sqlCommand3.Parameters.AddWithValue("@commonemailid", value1);
                    sqlCommand3.Parameters.AddWithValue("@email", this.stremailArray[i].ToString());
                    sqlCommand3.Parameters.AddWithValue("@verificationnumber", str8);
                    sqlCommand3.Parameters.AddWithValue("@emailtype", empty);
                    sqlCommand3.Parameters.AddWithValue("@message", empty1);
                    sqlCommand3.Parameters.AddWithValue("@ToUserID", 0);
                    sqlCommand3.Parameters.AddWithValue("@companyID", this.Session["companyID"].ToString());
                    sqlCommand3.ExecuteNonQuery();
                    _commonClass2.closeConnection();
                    _commonClass2.Dispose();
                    int value2 = (int)sqlCommand3.Parameters["ReturnMarketingIdValue"].Value;
                    MailMessage mailMessage = new MailMessage()
                    {
                        To = this.stremailArray[i].ToString().Trim(),
                        From = str6
                    };
                    if (this.txtcc.Value.Trim() != "")
                    {
                        mailMessage.Cc = this.txtcc.Value;
                    }
                    if (this.txtbcc.Value.Trim() != "")
                    {
                        mailMessage.Bcc = string.Concat(this.txtbcc.Value, ",", str1);
                    }
                    string empty2 = string.Empty;
                    DataTable dataTable = new DataTable();
                    dataTable = CompanyBasePage.company_client_email_select(Convert.ToInt32(this.Session["UserID"].ToString()));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string str9 = empty2;
                        string[] strArrays = new string[] { str9, this.strFilepath, "tempattachment\\", row["FileNames"].ToString(), "µ" };
                        empty2 = string.Concat(strArrays);
                    }
                    mailMessage.Subject = str4;
                    string[] strArrays1 = new string[] { empty1, "<img src='", global.sitePath(), "common/mailopened.aspx?verificationnumber=", str8, "' height=0 width=0>" };
                    string.Concat(strArrays1);
                    mailMessage.Body = this.msgText;
                    if (this.ddltemplateType.SelectedValue != "1")
                    {
                        mailMessage.BodyFormat = MailFormat.Text;
                        flag = false;
                    }
                    else
                    {
                        mailMessage.BodyFormat = MailFormat.Html;
                        flag = true;
                    }
                    mailMessage.Priority = MailPriority.High;
                    if (this.stremailArray[i].ToString() != "")
                    {
                        str6 = "donotreply@eprintsoftware.com";
                        this.txtbcc.Value = string.Concat("emaillogs@hexicomsoftware.com,", this.txtbcc.Value);
                        BaseClass.SendMailMessage(str6, this.stremailArray[i].ToString().Trim(), base.SpecialEncode(this.txtbcc.Value), base.SpecialEncode(this.txtcc.Value), base.SpecialEncode(this.txtsubject.Value), base.SpecialEncode(this.msgText), empty2, flag);
                    }
                }
                CompanyBasePage.company_client_email_delete(Convert.ToInt32(this.Session["UserID"].ToString()));
                files = Directory.GetFiles(string.Concat(base.Server.MapPath("../"), "tempattachment/"));
                for (int j = 0; j < (int)files.Length; j++)
                {
                    if (files[j].ToString().Contains(string.Concat(this.Session["userid"].ToString(), "_")))
                    {
                        File.Delete(files[j].ToString());
                    }
                }
                if (this.sectionname == "lead")
                {
                    QueryString queryString = new QueryString()
				{
					{ "leadid", this.sectionid.ToString() }
				};
                    string str10 = "lead/lead_detail.aspx";
                    QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                    str10 = string.Concat(str10, queryString1.ToString());
                    base.Response.Redirect(string.Concat(global.sitePath(), str10));
                }
                else if (this.sectionname != "client")
                {
                    QueryString queryString2 = new QueryString()
				{
					{ "contactid", this.sectionid.ToString() }
				};
                    string str11 = "contact/contact_detail.aspx";
                    QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                    str11 = string.Concat(str11, queryString3.ToString());
                    base.Response.Redirect(string.Concat(global.sitePath(), str11));
                }
                else
                {
                    this.pnlLoadEmailPanel.Visible = true;
                }
            }
            catch
            {
            }
        }

        protected void ddlselecttemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("sp_select_template_textarea", _commonClass.openConnection());
            sqlCommand.Parameters.Add("@templateID", this.ddlselecttemplate.SelectedValue);
            sqlCommand.Parameters.Add("@companyID", int.Parse(this.Session["companyID"].ToString()));
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                this.msgText = sqlDataReader["message"].ToString();
            }
            sqlDataReader.Close();
            _commonClass.closeConnection();
        }

        protected void ddltemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddltemplateType.SelectedValue == "1")
            {
                this.RadEditor1.Visible = true;
                this.areaEditor.Visible = false;
                return;
            }
            this.RadEditor1.Visible = false;
            this.areaEditor.Visible = true;
        }

        public new string GenPassWithCap(int i)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.companyid = int.Parse(this.Session["companyid"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.tabcolor = this.objpage.colorCode(this.companyid, base.Request.Params["sectionname"]);
            this.btnsend.BackColor = Color.FromName(this.tabcolor);
            this.btncancel.BackColor = Color.FromName(this.tabcolor);
            this.btnAddtext.BackColor = Color.FromName(this.tabcolor);
            this.btnAddddl.BackColor = Color.FromName(this.tabcolor);
            BaseClass baseClass = new BaseClass();
            this.DateFormat = this.Session["DateFormat"].ToString();
            commonClass _commonClass = this.comncls;
            string dateFormat = this.DateFormat;
            commonClass _commonClass1 = this.comncls;
            DateTime now = DateTime.Now;
            this.strDate = _commonClass.date_Check_new(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.companyid, this.UserID, true), this.companyid);
            if (base.Request.Params["CustomerName"] == null)
            {
                base.Title = this.objLanguage.convert(global.pageTitle("New Email", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            else
            {
                this.CustomerName = baseClass.SpecialDecode(base.Request.Params["CustomerName"].ToString());
                base.Title = string.Concat(this.CustomerName, ": New Email");
            }
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            this.btnsend.Text = this.objLanguage.GetLanguageConversion("Send");
            this.ddltemplateType.Items[0].Text = this.objLanguage.GetLanguageConversion("HTML");
            this.ddltemplateType.Items[1].Text = this.objLanguage.GetLanguageConversion("Text");
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            string[] strArrays1 = strArrays;
            this.RadEditor1.ImageManager.UploadPaths = strArrays1;
            this.RadEditor1.ImageManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.UploadPaths = strArrays1;
            this.RadEditor1.DocumentManager.ViewPaths = strArrays1;
            this.RadEditor1.DocumentManager.UploadPaths = strArrays1;
            this.RadEditor1.Height = Unit.Pixel(300);
            this.RadEditor1.Width = Unit.Pixel(670);
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor1.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            this.sectionid = int.Parse(base.Request.Params["sectionid"].ToString());
            this.sectionname = base.Request.Params["sectionname"].ToString();
            if (this.sectionname == "lead")
            {
                global.pageName = "lead";
                global.pgDetail = string.Concat(this.objLanguage.convert("Lead"), " >> ", this.objLanguage.convert("New Email"));
                commonClass _commonClass2 = new commonClass();
                SqlCommand sqlCommand = new SqlCommand("crm_select_AdminEmail", _commonClass2.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@companyid", int.Parse(this.Session["companyid"].ToString()));
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    this.txtcc.Value = base.SpecialDecode(sqlDataReader["email"].ToString());
                }
                sqlDataReader.Close();
                sqlDataReader.Dispose();
                _commonClass2.closeConnection();
                _commonClass2.Dispose();
            }
            else if (this.sectionname != "client")
            {
                global.pageName = "contact";
                global.pgDetail = string.Concat(this.objLanguage.convert("Contact"), " >> ", this.objLanguage.convert("New Email"));
            }
            else
            {
                this.btncancel.Visible = false;
                global.pageName = "client";
                this.gloobj.setpagename("Client");
                global.pgDetail = string.Concat(this.objLanguage.convert("Company"), " >> ", this.objLanguage.convert("New Email"));
            }
            if (!base.IsPostBack)
            {
                for (int i = 1; i < this.ddlLeadMoreAction.Items.Count; i++)
                {
                    this.ddlLeadMoreAction.Items[i].Text = string.Concat(this.Padding, base.SpecialEncode(this.ddlLeadMoreAction.Items[i].Text));
                }
            }
            string str = string.Concat("../common/attachfile.aspx?pg=", this.sectionname);
            object[] objArray = new object[] { "email_Contact.aspx?sectionid=", this.sectionid, "&sectionname=", this.sectionname };
            string str1 = string.Concat(objArray);
            this.imgselectleadmain.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", str1, "', null,'900','500'); SetRadWindow('divrad', 'divBackGroundNew', '200');return false;"));
            this.imgselectleadcc.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", str1, "', 'MarketingEmail','width=900,height=500,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=250,top=100'); SetRadWindow('divrad', 'divBackGroundNew', '200'); return false;"));
            this.imgselectleadbcc.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", str1, "', 'MarketingEmail','width=900,height=500,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=250,top=100'); SetRadWindow('divrad', 'divBackGroundNew', '200'); return false;"));
            this.LinkButton1.Attributes.Add("onclick", string.Concat("javascript:window.radopen('", str, "', null,'900','500'); SetRadWindow('divrad', 'divBackGroundNew', '200');return false;"));
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
            }
            this.objLanguage.Dispose();
            if (!base.IsPostBack)
            {
                this.BindDdl(this.ddlAddExisting);
                this.BindDdl(this.ddlselecttemplate);
                DataTable dataTable = this.objComp.company_contacts_select(this.companyid, Convert.ToInt32(this.sectionid), "yes");
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["DefaultContact"].ToString() != "True")
                    {
                        continue;
                    }
                    this.txtfirstname.Value = base.SpecialDecode(row["email"].ToString());
                }
                DataTable dataTable1 = SettingsBasePage.settings_emailsetting_select(this.companyid, Convert.ToInt32(this.Session["UserID"].ToString()));
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    if (Convert.ToBoolean(dataRow["IsCheckedCC"]) && dataRow["cc"].ToString().Length > 0)
                    {
                        if (this.txtcc.Value.Length <= 0)
                        {
                            this.txtcc.Value = base.SpecialDecode(dataRow["cc"].ToString());
                        }
                        else
                        {
                            HtmlTextArea htmlTextArea = this.txtcc;
                            htmlTextArea.Value = string.Concat(htmlTextArea.Value, ",", base.SpecialDecode(dataRow["cc"].ToString()));
                        }
                    }
                    if (!Convert.ToBoolean(dataRow["IsCheckedBCC"]) || dataRow["bcc"].ToString().Length <= 0)
                    {
                        continue;
                    }
                    if (this.txtbcc.Value.Length <= 0)
                    {
                        this.txtbcc.Value = base.SpecialDecode(dataRow["bcc"].ToString());
                    }
                    else
                    {
                        HtmlTextArea htmlTextArea1 = this.txtbcc;
                        htmlTextArea1.Value = string.Concat(htmlTextArea1.Value, ",", base.SpecialDecode(dataRow["bcc"].ToString()));
                    }
                }
            }
        }
    }
}