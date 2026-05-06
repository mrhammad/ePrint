using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.EstimatesNew;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Editor.DialogControls;

namespace ePrint.settings
{
    public partial class template_output : BaseClass, IRequiresSessionState
    {

        public string strImagepath = global.imagePath();

        public string sitepath = global.sitePath();

        private Global gloobj = new Global();

        private Template objTemplates = new Template();

        public string VersionNumber = ConnectionClass.VersionNumber;

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private commonClass commclass = new commonClass();

        public int CompanyID;

        public int UserID;

        public string report_page = string.Empty;

        public string action = string.Empty;

        public string EditorText = string.Empty;

        public string ControlList = string.Empty;

        public string copy = string.Empty;

        public string CompanyLogo = string.Empty;

        public int TemplateID;

        private string PageType = string.Empty;

        public string imgHeaderPath = string.Empty;

        public string imgFooterPath = string.Empty;

        public string imgItemPath = string.Empty;

        public string imgHRPath = string.Empty;

        public string @from = string.Empty;

        private string navigateText = string.Empty;

        public languageClass objlang = new languageClass();

        public StringBuilder sbCreateControl = new StringBuilder();

        public string strCreateControl = string.Empty;

        public string CheckTagsExists = "no";

        public string strTemplatePDfValues = string.Empty;

        public string PDFImageName = string.Empty;

        public string divFields_Height = string.Empty;

        public string divFields_overflowy = string.Empty;

        public string EditorWidth = "925px";

        public string EditorHeight = "1285px";

        public int ImageWidthOnEdit = 925;

        public int ImageHeightOnEdit = 1285;

        public long NewTemplateID;

        private string TempKey = string.Empty;

        public string EstimateID = "0";

        public string SecureDocPath = global.SecureDocPath();

        public string SecureDocFilePath = global.SecureDocFilepath();

        public string SecureSitePath = global.SecureSitePath();

        public string ServerName = string.Empty;

        public string SecureVirtualPath = global.SecureVirtualPath();

        public long ModuleID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

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

        public template_output()
        {
        }

        protected void BindGroup()
        {
            this.ddlGroup.DataSource = this.objTemplates.Template_Group_View(Convert.ToInt32(base.Request.QueryString["TemplateID"]));
            this.ddlGroup.DataTextField = "GroupName";
            this.ddlGroup.DataValueField = "ID";
            this.ddlGroup.DataBind();
            this.ddlGroup.Items.Insert(0, "Groups");
            this.ddlGroup.Items[0].Text = "Groups";
            this.ddlGroup.Items[0].Value = "0";
            int count = this.ddlGroup.Items.Count;
        }

        protected void BindHGroup()
        {
            this.ddlHGroup.DataSource = this.objTemplates.Template_HGroup_View(Convert.ToInt32(base.Request.QueryString["TemplateID"]));
            this.ddlHGroup.DataTextField = "GroupName";
            this.ddlHGroup.DataValueField = "ID";
            this.ddlHGroup.DataBind();
            this.ddlHGroup.Items.Insert(0, "H Groups");
            this.ddlHGroup.Items[0].Text = "H Groups";
            this.ddlHGroup.Items[0].Value = "0";
            int count = this.ddlHGroup.Items.Count;
        }

        public void btnUpdate_Submit(object sender, EventArgs e)
        {
            this.Session["TemplateHTML"] = null;
            this.Session["TemplateControlList"] = null;
            long num = (long)0;
            this.Insert_TemplateField_Properties(this.NewTemplateID);
            string str = base.Request.Params["page"].ToString();
            string str1 = base.Request.Params["EstID"].ToString();
            string str2 = this.Session[string.Concat("NewTempKey", str1.ToString().Trim())].ToString();
            if (this.Session["TemplateID"] != null)
            {
                this.NewTemplateID = Convert.ToInt64(this.Session["TemplateID"].ToString());
            }
            string empty = string.Empty;
            if (base.Request.QueryString["EstItemID"] != null)
            {
                empty = base.Request.QueryString["EstItemID"].ToString();
            }
            string empty1 = string.Empty;
            if (base.Request.QueryString["From"] != null)
            {
                empty1 = base.Request.QueryString["From"].ToString();
            }
            if (this.Session["TemplateID"] != null)
            {
                this.NewTemplateID = Convert.ToInt64(this.Session["TemplateID"].ToString());
            }
            string empty2 = string.Empty;
            DataTable dataTable = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, Convert.ToInt64(str1), "template", this.NewTemplateID);
            foreach (DataRow row in dataTable.Rows)
            {
                empty2 = row["Name"].ToString();
            }
            if (base.Request.Params["page"].ToString().ToLower() == "estimate")
            {
                this.objnotes.Template_name = empty2;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstTempViewEdit);
                this.objnotes.ModuleID = Convert.ToInt64(str1);
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "job")
            {
                this.objnotes.Template_name = empty2;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobTempViewEdit);
                this.objnotes.ModuleID = Convert.ToInt64(base.Request.Params["jid"].ToString());
                this.jID = string.Concat("&jID=", Convert.ToInt64(base.Request.Params["jid"].ToString()));
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "invoice")
            {
                this.objnotes.Template_name = empty2;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvTempViewEdit);
                this.objnotes.ModuleID = Convert.ToInt64(base.Request.Params["InvID"].ToString());
                this.InvID = string.Concat("&InvID=", Convert.ToInt64(base.Request.Params["InvID"].ToString()));
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "purchase")
            {
                if (base.Request.Params["jobEstID"] == null)
                {
                    this.objnotes.Template_name = empty2;
                    this.objnotes.ModuleName = "purchase";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POTempEdit);
                    this.objnotes.ModuleID = Convert.ToInt64(str1);
                }
                else
                {
                    string empty3 = string.Empty;
                    DataTable dataTable1 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, Convert.ToInt64(str1), "all", Convert.ToInt64(str1));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        empty3 = dataRow["ReferenceNO"].ToString();
                    }
                    this.objnotes.Template_name = empty2;
                    this.objnotes.Job_number = empty3;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobPOViedInTempEdit);
                    this.objnotes.ModuleID = Convert.ToInt64(base.Request.Params["jobEstID"]);
                }
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "note")
            {
                this.objnotes.Template_name = empty2;
                this.objnotes.ModuleName = "delivery";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelTempEdit);
                this.objnotes.ModuleID = Convert.ToInt64(str1);
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "printbroker")
            {
                this.objnotes.Template_name = empty2;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstTempViewEdit);
                this.objnotes.ModuleID = Convert.ToInt64(str1);
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "webstoreorder")
            {
                this.objnotes.Template_name = empty2;
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdTempViewEdit);
                this.objnotes.ModuleID = Convert.ToInt64(str1);
            }
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            string str3 = string.Empty;
            if (base.Request.Params["Page"].ToString().ToLower() == "jobcard" || base.Request.Params["Page"].ToString().ToLower() == "printbroker")
            {
                object[] newTemplateID = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", str, "&EstID=", str1, "&EstItemID=", empty, "&From=", empty1, "&key=", str2, "&preview=y&TemplateID=", this.NewTemplateID };
                str3 = string.Concat(newTemplateID);
            }
            else
            {
                object[] objArray = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", str, "&ordid=", str1, "&EstID=", str1, "&key=", str2, "&TemplateID=", this.NewTemplateID, this.jID, this.InvID };
                str3 = string.Concat(objArray);
            }
            base.Response.Redirect(str3.ToString());
        }

        private string CreateControl(DataTable dtFields)
        {
            foreach (DataRow row in dtFields.Rows)
            {
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string str3 = string.Empty;
                string empty4 = string.Empty;
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                string str4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                string empty6 = string.Empty;
                string str6 = string.Empty;
                string empty7 = string.Empty;
                string str7 = string.Empty;
                string empty8 = string.Empty;
                string str8 = string.Empty;
                string empty9 = string.Empty;
                string lower = string.Empty;
                string str9 = string.Empty;
                string empty10 = string.Empty;
                string str10 = string.Empty;
                string empty11 = string.Empty;
                string str11 = string.Empty;
                string empty12 = string.Empty;
                string str12 = string.Empty;
                string empty13 = string.Empty;
                string str13 = string.Empty;
                string empty14 = string.Empty;
                string str14 = string.Empty;
                string empty15 = string.Empty;
                string str15 = string.Empty;
                string empty16 = string.Empty;
                string str16 = string.Empty;
                string empty17 = string.Empty;
                string str17 = string.Empty;
                string empty18 = string.Empty;
                string str18 = string.Empty;
                string lower1 = "n";
                string lower2 = "0";
                string lower3 = "0";
                string lower4 = "false";
                string empty19 = string.Empty;
                string lower5 = "false";
                string lower6 = "false";
                str = row["objType"].ToString();
                row["objID"].ToString();
                str18 = row["objTag"].ToString();
                empty2 = row["objValue"].ToString();
                str2 = row["imgsrc"].ToString();
                empty2 = (str == "3" || str == "8" || str == "9" || str == "10" || str == "11" || str == "12" || str == "13" || str == "14" ? str2 : base.SpecialEncode(row["objValue"].ToString()));
                empty1 = base.ReplaceSingleQuote(row["objName"].ToString());
                empty11 = (row["maxlength"].ToString() == "null" ? "0" : row["maxlength"].ToString());
                str6 = row["fontfamily"].ToString();
                empty7 = row["fontsize"].ToString();
                str7 = row["fontweight"].ToString();
                empty8 = row["fontstyle"].ToString();
                num1 = Convert.ToDecimal(row["left"]);
                num = Convert.ToDecimal(row["top"]);
                num2 = Convert.ToDecimal(row["width"]);
                num3 = Convert.ToDecimal(row["height"]);
                str8 = row["fontcolor"].ToString();
                empty9 = (row["textdecoration"].ToString().ToLower() == "underline" ? "1" : "0");
                lower = row["textalign"].ToString().ToLower();
                lower2 = row["GroupID"].ToString().ToLower();
                lower3 = row["HGroupID"].ToString().ToLower();
                lower1 = row["isitem"].ToString().ToLower();
                lower5 = row["isHGroupMain"].ToString().ToLower();
                empty19 = row["AssociatedLabel"].ToString();
                lower4 = row["isAutoExpand"].ToString().ToLower();
                lower6 = row["Repeat"].ToString().ToLower();
                if (string.IsNullOrEmpty(Convert.ToString(row["Repeat"])) || Convert.ToString(row["Repeat"]) == "null")
                {
                    lower6 = "false";
                }
                string str19 = "1";
                if (lower == "center")
                {
                    str19 = "2";
                }
                else if (lower == "right")
                {
                    str19 = "3";
                }
                if (str == "13")
                {
                    this.ImageWidthOnEdit = Convert.ToInt32(num2);
                    this.ImageHeightOnEdit = Convert.ToInt32(num3);
                }
                if ((this.CheckTagsExists == "no" || this.CheckTagsExists == "yes" && str18.ToString().ToLower() == "null") && str == "1" && str18.ToString().ToLower() == "null")
                {
                    string lower7 = empty1.ToString().ToLower();
                    if (lower7 == "estimate" || lower7 == "enter your text" || lower7 == "kind regards" || lower7 == "best regards" || lower7 == "job card" || lower7 == "invoice" || lower7 == "purchase order" || lower7 == "delivery note" || lower7 == "your's sincerely" || lower7 == "description of goods" || lower7 == "production information" || lower7 == "estimated" || lower7 == "actual job performance")
                    {
                        str18 = "";
                    }
                    else
                    {
                        string[] strArrays = empty1.Split(new char[] { ' ' });
                        string empty20 = string.Empty;
                        for (int i = 0; i < (int)strArrays.Length; i++)
                        {
                            empty20 = string.Concat(empty20, strArrays[i].ToString());
                        }
                        str18 = string.Concat("[", empty20, "]");
                    }
                }
                if (str2.Contains("borders.gif"))
                {
                    empty1 = empty1.Replace("borders.gif", "borders.png");
                    empty2 = empty2.Replace("borders.gif", "borders.png");
                    str2 = str2.Replace("borders.gif", "borders.png");
                }
                if (str2.Contains("borders.png"))
                {
                    num2 = new decimal(783);
                    num3 = new decimal(842);
                }
                object[] secureSitePath = new object[] { this.SecureSitePath, this.ServerName, "/", this.CompanyID, "/", this.CompanyLogo };
                string str20 = string.Concat(secureSitePath);
                string.Concat(this.strImagepath, "HorizontalLine.gif");
                empty1 = empty1.Replace("[LogoPath]", str20);
                empty2 = empty2.Replace("[LogoPath]", str20);
                str2 = str2.Replace("[LogoPath]", str20);
                if (empty2.IndexOf("\n") != -1)
                {
                    empty2 = empty2.Replace("\r\n", "<br/>");
                    empty2 = empty2.Replace("\n", "<br/>");
                }
                StringBuilder stringBuilder = this.sbCreateControl;
                object[] objArray = new object[] { "CreateCtrl('", str, "', '', '", str18, "', '", empty2, "', '", empty1, "', '", empty11, "', '', '", str6, "', '", empty7, "','", str7, "', '", empty8, "', '", Convert.ToInt32(num1), "', '", Convert.ToInt32(num), "', '", Convert.ToInt32(num2), "', '", Convert.ToInt32(num3), "', '", str8, "','", empty9, "', '0pt', '", str19, "', '0', '1', '", empty15, "' ,'0', '0', '0', '1', '1', '1', '", lower1, "','", lower2, "','", lower3, "','", empty19, "','", lower5, "','", lower4, "','", lower6, "');" };
                stringBuilder.Append(string.Concat(objArray));
            }
            this.sbCreateControl.ToString().Contains("borders.png");
            return this.sbCreateControl.ToString();
        }

        protected void imgbtnDeleteGroup_OnClick(object sender, EventArgs e)
        {
            if (this.ddlGroup.SelectedValue == "0")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Please_Select_Group_To_Remove"), "msg-alert", this.plhMessage);
                return;
            }
            this.objTemplates.Template_Group_Delete(Convert.ToInt32(this.ddlGroup.SelectedValue), Convert.ToInt32(base.Request.QueryString["ID"]));
            this.BindGroup();
            base.Message_Display(this.objlang.GetLanguageConversion("Group_Removed_Successfully"), "msg-success", this.plhMessage);
        }

        protected void imgbtnDeleteHGroup_OnClick(object sender, EventArgs e)
        {
            if (this.ddlHGroup.SelectedValue == "0")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Please_Select_HGroup_To_Remove"), "msg-alert", this.plhMessage);
                return;
            }
            this.objTemplates.Template_HGroup_Delete(Convert.ToInt32(this.ddlHGroup.SelectedValue), Convert.ToInt32(base.Request.QueryString["ID"]));
            this.BindHGroup();
            base.Message_Display(this.objlang.GetLanguageConversion("HGroup_Removed_Successfully"), "msg-success", this.plhMessage);
        }

        private void Insert_TemplateField_Properties(long retTemplateID)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TemplateID", typeof(long));
            dataTable.Columns.Add("CompanyID", typeof(int));
            dataTable.Columns.Add("objID", typeof(string));
            dataTable.Columns.Add("objType", typeof(string));
            dataTable.Columns.Add("objName", typeof(string));
            dataTable.Columns.Add("type", typeof(string));
            dataTable.Columns.Add("objValue", typeof(string));
            dataTable.Columns.Add("imgsrc", typeof(string));
            dataTable.Columns.Add("title", typeof(string));
            dataTable.Columns.Add("align", typeof(string));
            dataTable.Columns.Add("position", typeof(string));
            dataTable.Columns.Add("top", typeof(decimal));
            dataTable.Columns.Add("left", typeof(decimal));
            dataTable.Columns.Add("width", typeof(decimal));
            dataTable.Columns.Add("height", typeof(decimal));
            dataTable.Columns.Add("zindex", typeof(string));
            dataTable.Columns.Add("padding", typeof(string));
            dataTable.Columns.Add("display", typeof(string));
            dataTable.Columns.Add("overflow", typeof(string));
            dataTable.Columns.Add("fontfamily", typeof(string));
            dataTable.Columns.Add("fontsize", typeof(string));
            dataTable.Columns.Add("fontweight", typeof(string));
            dataTable.Columns.Add("fontstyle", typeof(string));
            dataTable.Columns.Add("fontcolor", typeof(string));
            dataTable.Columns.Add("textdecoration", typeof(string));
            dataTable.Columns.Add("textalign", typeof(string));
            dataTable.Columns.Add("border", typeof(string));
            dataTable.Columns.Add("backgroundcolor", typeof(string));
            dataTable.Columns.Add("visibility", typeof(string));
            dataTable.Columns.Add("maxlength", typeof(string));
            dataTable.Columns.Add("offsetwidth", typeof(string));
            dataTable.Columns.Add("offsetheight", typeof(string));
            dataTable.Columns.Add("offsettop", typeof(string));
            dataTable.Columns.Add("offsetleft", typeof(string));
            dataTable.Columns.Add("pixelwidth", typeof(string));
            dataTable.Columns.Add("pixelheight", typeof(string));
            dataTable.Columns.Add("pixeltop", typeof(string));
            dataTable.Columns.Add("lock", typeof(string));
            dataTable.Columns.Add("canmove", typeof(string));
            dataTable.Columns.Add("canchangefontcolor", typeof(string));
            dataTable.Columns.Add("canchangefontsize", typeof(string));
            dataTable.Columns.Add("canchangefont", typeof(string));
            dataTable.Columns.Add("class", typeof(string));
            dataTable.Columns.Add("onmouseoverclass", typeof(string));
            dataTable.Columns.Add("objTag", typeof(string));
            dataTable.Columns.Add("isItem", typeof(string));
            dataTable.Columns.Add("GroupID", typeof(long));
            dataTable.Columns.Add("HGroupID", typeof(long));
            dataTable.Columns.Add("isHGroupMain", typeof(string));
            dataTable.Columns.Add("AssociatedLabel", typeof(string));
            dataTable.Columns.Add("isAutoExpand", typeof(string));
            dataTable.Columns.Add("ItemNumber", typeof(string));
            dataTable.Columns.Add("Repeat", typeof(string));
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            string str6 = string.Empty;
            string empty7 = string.Empty;
            string str7 = string.Empty;
            string empty8 = string.Empty;
            string str8 = string.Empty;
            string empty9 = string.Empty;
            string str9 = string.Empty;
            string empty10 = string.Empty;
            string str10 = string.Empty;
            string empty11 = string.Empty;
            string str11 = string.Empty;
            string empty12 = string.Empty;
            string str12 = string.Empty;
            string empty13 = string.Empty;
            string str13 = string.Empty;
            string empty14 = string.Empty;
            string str14 = string.Empty;
            string empty15 = string.Empty;
            string str15 = string.Empty;
            string empty16 = string.Empty;
            string str16 = string.Empty;
            string empty17 = string.Empty;
            string str17 = string.Empty;
            string empty18 = string.Empty;
            string str18 = string.Empty;
            string empty19 = string.Empty;
            string str19 = "0";
            string str20 = "0";
            string str21 = "false";
            string empty20 = string.Empty;
            string str22 = "false";
            string str23 = "false";
            if (this.hid_FieldProperties.Value != "")
            {
                string[] strArrays = this.hid_FieldProperties.Value.Split(new char[] { 'µ' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                        string str24 = strArrays2[0].ToString();
                        string str25 = strArrays2[1].ToString();
                        if (str24 == "objID")
                        {
                            empty = str25;
                        }
                        if (str24 == "objType")
                        {
                            str = str25;
                        }
                        if (str24 == "objName")
                        {
                            empty1 = str25;
                        }
                        if (str24 == "type")
                        {
                            str1 = str25;
                        }
                        if (str24 == "objValue")
                        {
                            empty2 = str25;
                        }
                        if (str24 == "imgsrc")
                        {
                            str2 = str25;
                        }
                        if (str24 == "title")
                        {
                            empty3 = str25;
                        }
                        if (str24 == "align")
                        {
                            str3 = (str25 == "null" ? "left" : str25);
                        }
                        if (str24 == "position")
                        {
                            empty4 = str25;
                        }
                        if (str24 == "objtop")
                        {
                            num = Convert.ToDecimal(str25);
                        }
                        if (str24 == "objleft")
                        {
                            num1 = Convert.ToDecimal(str25);
                        }
                        if (str24 == "objwidth")
                        {
                            num2 = Convert.ToDecimal(str25);
                        }
                        if (str24 == "objheight")
                        {
                            num3 = Convert.ToDecimal(str25);
                        }
                        if (str24 == "zindex")
                        {
                            str4 = str25;
                        }
                        if (str24 == "padding")
                        {
                            empty5 = str25;
                        }
                        if (str24 == "display")
                        {
                            str5 = str25;
                        }
                        if (str24 == "overflow")
                        {
                            empty6 = str25;
                        }
                        if (str24 == "fontfamily")
                        {
                            str6 = str25;
                        }
                        if (str24 == "fontsize")
                        {
                            empty7 = str25;
                        }
                        if (str24 == "fontweight")
                        {
                            str7 = str25;
                        }
                        if (str24 == "fontstyle")
                        {
                            empty8 = str25;
                        }
                        if (str24 == "fontcolor")
                        {
                            str8 = str25;
                        }
                        if (str24 == "textdecoration")
                        {
                            empty9 = str25;
                        }
                        if (str24 == "textalign")
                        {
                            str9 = str25;
                        }
                        if (str24 == "border")
                        {
                            empty10 = str25;
                        }
                        if (str24 == "backgroundcolor")
                        {
                            str10 = str25;
                        }
                        if (str24 == "backgroundcolor")
                        {
                            str10 = str25;
                        }
                        if (str24 == "visibility")
                        {
                            empty11 = str25;
                        }
                        if (str24 == "maxlength")
                        {
                            str11 = (str25 == "null" ? "0" : str25);
                        }
                        if (str24 == "offsetwidth")
                        {
                            empty12 = str25;
                        }
                        if (str24 == "offsetheight")
                        {
                            str12 = str25;
                        }
                        if (str24 == "offsettop")
                        {
                            empty13 = str25;
                        }
                        if (str24 == "offsetleft")
                        {
                            str13 = str25;
                        }
                        if (str24 == "pixelwidth")
                        {
                            empty14 = (str25 == "undefined" ? "0" : str25);
                        }
                        if (str24 == "pixelheight")
                        {
                            str14 = (str25 == "undefined" ? "0" : str25);
                        }
                        if (str24 == "pixeltop")
                        {
                            empty15 = (str25 == "undefined" ? "0" : str25);
                        }
                        if (str24 == "objlock")
                        {
                            str15 = str25;
                        }
                        if (str24 == "canmove")
                        {
                            empty16 = (str25 == "null" ? "1" : str25);
                        }
                        if (str24 == "canchangefontcolor")
                        {
                            str16 = (str25 == "null" ? "1" : str25);
                        }
                        if (str24 == "canchangefontsize")
                        {
                            empty17 = (str25 == "null" ? "1" : str25);
                        }
                        if (str24 == "canchangefont")
                        {
                            str17 = (str25 == "null" ? "1" : str25);
                        }
                        if (str24 == "objclass")
                        {
                            empty18 = (str25 == "null" ? "putpointer" : str25);
                        }
                        if (str24 == "onmouseoverclass")
                        {
                            str18 = (str25 == "null" ? "this.className='putpointer'" : str25);
                        }
                        if (str24 == "objTag")
                        {
                            empty19 = str25;
                        }
                        if (str24.Trim().ToLower() == "groupid")
                        {
                            str19 = str25;
                        }
                        if (str24.Trim().ToLower() == "hgroupid")
                        {
                            str20 = str25;
                        }
                        if (str24.Trim().ToLower() == "associatedlabel")
                        {
                            empty20 = str25;
                        }
                        if (str24.Trim().ToLower() == "ishgroupmain")
                        {
                            str22 = str25;
                        }
                        if (str24.Trim().ToLower() == "isautoexpand")
                        {
                            str21 = str25;
                        }
                        if (str24.Trim().ToLower() == "repeat")
                        {
                            str23 = str25;
                        }
                    }
                    object[] objArray = new object[] { retTemplateID, this.CompanyID, empty, str, empty1, str1, empty2, str2, empty3, str3, empty4, num, num1, num2, num3, str4, empty5, str5, empty6, str6.Replace("'", "").Replace("-", " "), empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11, empty12, str12, empty13, str13, empty14, str14, empty15, str15, empty16, str16, empty17, str17, empty18, str18, empty19, "n", Convert.ToInt64(str19), Convert.ToInt64(str20), str22, empty20, str21, 0, str23 };
                    dataTable.Rows.Add(objArray);
                }
            }
            this.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())] = dataTable;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("setting");
            this.report_page = "Estimate";
            this.action = "edit";
            this.imgHeaderPath = string.Concat(this.strImagepath, "header-line.gif");
            this.imgFooterPath = string.Concat(this.strImagepath, "footer-line.gif");
            this.imgItemPath = string.Concat(this.strImagepath, "items-line.gif");
            this.imgHRPath = string.Concat(this.strImagepath, "HorizontalLine.gif");
            base.Title = "Settings: Edit Layout";
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (!base.IsPostBack)
            {
                this.Button2.Text = this.objlang.GetLanguageConversion("Save_Preview");
                this.chkSplit.Text = this.objlang.GetLanguageConversion("Split_The_Items_So_That_Each_Item_Fits_On_Single_Page");
                this.btnCancelGroup.Text = this.objlang.GetLanguageConversion("Cancel");
                this.lblGroupName.Text = this.objlang.GetLanguageConversion("Group_Name");
                this.lblAutoExpand.Text = this.objlang.GetLanguageConversion("Auto_Expand");
                this.btnSaveGroup.Text = this.objlang.GetLanguageConversion("Save");
                this.lblHGroupName.Text = this.objlang.GetLanguageConversion("HGroup_Name");
                this.Label6.Text = this.objlang.GetLanguageConversion("Remove_Label");
                this.btnUpdate.Text = this.objlang.GetLanguageConversion("Save_Preview");
            }
            if (base.Request.Params["EstID"] != null)
            {
                this.EstimateID = base.Request.Params["EstID"].ToString();
            }
            if (this.Session["TemplateID"] != null)
            {
                this.NewTemplateID = Convert.ToInt64(this.Session["TemplateID"].ToString());
            }
            if (!base.IsPostBack)
            {
                this.BindGroup();
                this.BindHGroup();
            }
            if (!base.IsPostBack)
            {
                this.objTemplates.Bind_TemplateFonts(this.ddlfonts, this.CompanyID, "--- Select ---");
                this.pnlInsertPDFOnEdit.Visible = true;
                if (this.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())] != null)
                {
                    DataTable item = (DataTable)this.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())];
                    if (item.Rows.Count <= 0)
                    {
                        this.CheckTagsExists = "no";
                    }
                    else
                    {
                        this.CheckTagsExists = "yes";
                        this.strCreateControl = this.CreateControl(item);
                    }
                    this.pnlEdit.Visible = true;
                    string str = string.Concat(this.SecureSitePath, this.ServerName, "/", this.CompanyLogo);
                    string str1 = string.Concat(this.strImagepath, "HorizontalLine.gif");
                    this.hidEditorValues_Edit.Value = this.hidEditorValues_Edit.Value.Replace("[LogoPath]", str);
                    this.hidEditorValues_Edit.Value = this.hidEditorValues_Edit.Value.Replace("[HRPath]", str1);
                }
            }
            FileManagerDialogParameters fileManagerDialogParameter = new FileManagerDialogParameters();
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            fileManagerDialogParameter.ViewPaths = strArrays;
            string[] strArrays1 = new string[1];
            string[] secureVirtualPath1 = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays1[0] = string.Concat(secureVirtualPath1);
            fileManagerDialogParameter.UploadPaths = strArrays1;
            fileManagerDialogParameter.MaxUploadFileSize = 5000000;
            DialogDefinition dialogDefinition = new DialogDefinition(typeof(ImageManagerDialog), fileManagerDialogParameter)
            {
                ClientCallbackFunction = "ImageManagerFunction",
                Width = Unit.Pixel(690),
                Height = Unit.Pixel(440),
                Title = this.objLanguage.GetLanguageConversion("Image_Manager")
            };
            dialogDefinition.Parameters["ExternalDialogsPath"] = "~/RadEditorDialogs/";
            this.DialogOpener1.DialogDefinitions.Add("ImageManager", dialogDefinition);
            FileManagerDialogParameters fileManagerDialogParameter1 = new FileManagerDialogParameters();
            string[] strArrays2 = new string[1];
            string[] secureVirtualPath2 = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays2[0] = string.Concat(secureVirtualPath2);
            fileManagerDialogParameter1.ViewPaths = strArrays2;
            string[] strArrays3 = new string[1];
            string[] secureVirtualPath3 = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays3[0] = string.Concat(secureVirtualPath3);
            fileManagerDialogParameter1.UploadPaths = strArrays3;
            fileManagerDialogParameter1.MaxUploadFileSize = 5000000;
            DialogDefinition dialogDefinition1 = new DialogDefinition(typeof(ImageEditorDialog), fileManagerDialogParameter1);
            dialogDefinition1.Parameters["ExternalDialogsPath"] = "~/RadEditorDialogs/";
            dialogDefinition1.Width = Unit.Pixel(800);
            dialogDefinition1.Height = Unit.Pixel(440);
            this.DialogOpener1.DialogDefinitions.Add("ImageEditor", dialogDefinition1);
        }
    }
}