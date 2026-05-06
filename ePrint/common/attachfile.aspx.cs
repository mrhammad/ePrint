using nmsCommon;
using nmsDocument;
using nmsLanguage;
using Printcenter.UI.Company;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class attachfile : System.Web.UI.Page
    {
        public languageClass objLanguage = new languageClass();

        public string strImagepath;

        public int companyId;

        public string OriginalFileName = string.Empty;

        public string sectionname = string.Empty;

        private Global gloobj = new Global();

        public languageClass objLangClass = new languageClass();

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

        public attachfile()
        {
        }

        private void AddMasterDocument(string strFileName)
        {
            documentClass _documentClass = new documentClass();
            int num = 0;
            string str = "Default";
            string str1 = DateTime.Now.ToString();
            string str2 = DateTime.Now.ToString();
            int item = (int)this.Session["UserID"];
            int item1 = (int)this.Session["UserID"];
            int num1 = 0;
            string str3 = strFileName;
            string str4 = string.Concat(base.Server.MapPath("../"), "tempattachment/", str3);
            string[] strArrays = new string[] { base.Server.MapPath("../"), "Document/", this.Session["companyid"].ToString(), "/", str3 };
            File.Copy(str4, string.Concat(strArrays));
            _documentClass.document_Add(num, str, this.companyId, "", str3, str3, str1, str2, item, item1, num1);
        }

        protected void Button1_ServerClick1(object sender, EventArgs e)
        {
            if (this.FileUpload1.HasFile)
            {
                int num = 0;
                string empty = string.Empty;
                empty = this.FileUpload1.FileName;
                while (true)
                {
                    num++;
                    if (!File.Exists(string.Concat(base.Server.MapPath("../"), "tempattachment/", empty)))
                    {
                        break;
                    }
                    string[] strArrays = this.FileUpload1.FileName.Split(new char[] { '.' });
                    empty = "";
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        empty = string.Concat(empty, strArrays[i].ToString());
                    }
                    empty = string.Concat(empty, num.ToString());
                    empty = string.Concat(empty, ".", strArrays[(int)strArrays.Length - 1]);
                }
                this.FileUpload1.SaveAs(string.Concat(base.Server.MapPath("../"), "tempattachment/", empty));
                if (this.hdnRefreshData.Value != "")
                {
                    HtmlInputHidden htmlInputHidden = this.hdnRefreshData;
                    htmlInputHidden.Value = string.Concat(htmlInputHidden.Value, ", ");
                }
                HtmlInputHidden htmlInputHidden1 = this.hdnRefreshData;
                htmlInputHidden1.Value = string.Concat(htmlInputHidden1.Value, empty);
                attachfile commonAttachfile = this;
                commonAttachfile.OriginalFileName = string.Concat(commonAttachfile.OriginalFileName, empty, "µ");
                if (this.chkFile1.Checked)
                {
                    this.AddMasterDocument(empty);
                }
                CompanyBasePage.company_client_email_insert(Convert.ToInt32(this.Session["UserID"].ToString()), empty);
            }
            if (this.FileUpload2.HasFile)
            {
                int num1 = 0;
                string fileName = string.Empty;
                fileName = this.FileUpload2.FileName;
                while (true)
                {
                    num1++;
                    if (!File.Exists(string.Concat(base.Server.MapPath("../"), "tempattachment/", fileName)))
                    {
                        break;
                    }
                    string[] strArrays1 = this.FileUpload2.FileName.Split(new char[] { '.' });
                    fileName = "";
                    for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                    {
                        fileName = string.Concat(fileName, strArrays1[j].ToString());
                    }
                    fileName = string.Concat(fileName, num1.ToString());
                    fileName = string.Concat(fileName, ".", strArrays1[(int)strArrays1.Length - 1]);
                }
                this.FileUpload2.SaveAs(string.Concat(base.Server.MapPath("../"), "tempattachment/", fileName));
                if (this.hdnRefreshData.Value != "")
                {
                    HtmlInputHidden htmlInputHidden2 = this.hdnRefreshData;
                    htmlInputHidden2.Value = string.Concat(htmlInputHidden2.Value, ", ");
                }
                HtmlInputHidden htmlInputHidden3 = this.hdnRefreshData;
                htmlInputHidden3.Value = string.Concat(htmlInputHidden3.Value, fileName);
                attachfile commonAttachfile1 = this;
                commonAttachfile1.OriginalFileName = string.Concat(commonAttachfile1.OriginalFileName, fileName, "µ");
                if (this.chkFile2.Checked)
                {
                    this.AddMasterDocument(fileName);
                }
                CompanyBasePage.company_client_email_insert(Convert.ToInt32(this.Session["UserID"].ToString()), fileName);
            }
            if (this.FileUpload3.HasFile)
            {
                int num2 = 0;
                string str = string.Empty;
                str = this.FileUpload3.FileName;
                while (true)
                {
                    num2++;
                    if (!File.Exists(string.Concat(base.Server.MapPath("../"), "tempattachment/", str)))
                    {
                        break;
                    }
                    string[] strArrays2 = this.FileUpload3.FileName.Split(new char[] { '.' });
                    str = "";
                    for (int k = 0; k < (int)strArrays2.Length - 1; k++)
                    {
                        str = string.Concat(str, strArrays2[k].ToString());
                    }
                    str = string.Concat(str, num2.ToString());
                    str = string.Concat(str, ".", strArrays2[(int)strArrays2.Length - 1]);
                }
                this.FileUpload3.SaveAs(string.Concat(base.Server.MapPath("../"), "tempattachment/", str));
                if (this.hdnRefreshData.Value != "")
                {
                    HtmlInputHidden htmlInputHidden4 = this.hdnRefreshData;
                    htmlInputHidden4.Value = string.Concat(htmlInputHidden4.Value, ", ");
                }
                HtmlInputHidden htmlInputHidden5 = this.hdnRefreshData;
                htmlInputHidden5.Value = string.Concat(htmlInputHidden5.Value, str);
                attachfile commonAttachfile2 = this;
                commonAttachfile2.OriginalFileName = string.Concat(commonAttachfile2.OriginalFileName, str, "µ");
                if (this.chkFile3.Checked)
                {
                    this.AddMasterDocument(str);
                }
                CompanyBasePage.company_client_email_insert(Convert.ToInt32(this.Session["UserID"].ToString()), str);
            }
            for (int l = 0; l < this.GridViewdocument.Rows.Count; l++)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)this.GridViewdocument.Rows[l].Cells[0].FindControl("DocumentId");
                if (htmlInputCheckBox.Checked)
                {
                    string value = htmlInputCheckBox.Value;
                    string str1 = Guid.NewGuid().ToString();
                    str1 = str1.Replace("-", string.Empty);
                    str1 = str1.Substring(0, 5);
                    string[] str2 = new string[] { this.Session["userid"].ToString(), "_", str1, "_", value.Replace(" ", "_") };
                    value = string.Concat(str2);
                    string[] strArrays3 = new string[] { base.Server.MapPath("../"), "document/", this.companyId.ToString(), "/", htmlInputCheckBox.Value };
                    string str3 = string.Concat(strArrays3);
                    File.Copy(str3, string.Concat(base.Server.MapPath("../"), "tempattachment/", value));
                    if (this.hdnRefreshData.Value != "")
                    {
                        HtmlInputHidden htmlInputHidden6 = this.hdnRefreshData;
                        htmlInputHidden6.Value = string.Concat(htmlInputHidden6.Value, ", ");
                    }
                    HtmlInputHidden htmlInputHidden7 = this.hdnRefreshData;
                    htmlInputHidden7.Value = string.Concat(htmlInputHidden7.Value, value);
                    attachfile commonAttachfile3 = this;
                    commonAttachfile3.OriginalFileName = string.Concat(commonAttachfile3.OriginalFileName, value, "µ");
                }
            }
            this.plhscript.Visible = true;
        }

        protected void GridViewdocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SetProperties setProperty = new SetProperties();
            DataControlRowType rowType = e.Row.RowType;
            DataControlRowType dataControlRowType = e.Row.RowType;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            this.SqlDataSource1.ConnectionString = _commonClass.strConnection;
            if (base.Request.Params["pg"] != null)
            {
                this.sectionname = base.Request.Params["pg"].ToString().ToLower();
                this.gloobj.setpagename(this.sectionname);
            }
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Attach File", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", _commonClass.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", _commonClass.functionCheckChange());
            }
            this.strImagepath = global.imagePath();
            this.Button2.Value = this.objLanguage.convert(this.Button2.Value);
            this.SqlDataSource1.SelectParameters.Clear();
            this.SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            this.SqlDataSource1.SelectCommand = "CRM_Attach_SelectMasterDocument";
            this.companyId = int.Parse(this.Session["companyid"].ToString());
            this.SqlDataSource1.SelectParameters.Add("CompanyID", this.Session["companyid"].ToString());
            this.GridViewdocument.DataSourceID = this.SqlDataSource1.ID;
            this.GridViewdocument.PageSize = 10000;
            this.btnAttch.Text = this.objLangClass.GetLanguageConversion("Attach");
        }
    }
}