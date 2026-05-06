using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Company;
using Printcenter.BusinessAccessLayer.Department;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class system_pharsebook : BaseClass, IRequiresSessionState
    {

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private string section = string.Empty;

        private int CompanyID;

        public int totalrec;

        public string type = string.Empty;

        public string sectionvalue = string.Empty;

        public bool DefaultPhrase;

        public string EmailTemplateName = string.Empty;

        private commonClass objJava = new commonClass();

        public string strLo = string.Empty;

        private string label = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private CompanyBasePage objcomm = new CompanyBasePage();

        private DepartmentBaseClass objdept = new DepartmentBaseClass();

        private string gridMessage;

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

        public system_pharsebook()
        {
        }

        private void DisplayMessage(string text)
        {
            this.RadGrid1.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }

        protected bool GenerateBindString(object dataItem)
        {
            bool flag = false;
            flag = (DataBinder.Eval(dataItem, "IsDefaultPhrase").ToString() != "" ? (bool)DataBinder.Eval(dataItem, "IsDefaultPhrase") : false);
            return flag;
        }

        public void GridBind()
        {
            this.SessionDataSource1.TypeName = "Printcenter.UI.Setting.SettingsBasePage";
            this.SessionDataSource1.SelectMethod = "settings_phrasebook_select";
            this.SessionDataSource1.SelectParameters.Clear();
            this.SessionDataSource1.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            this.SessionDataSource1.SelectParameters.Add("PhraseType", this.section.ToString());
            this.SessionDataSource1.DataBind();
            this.RadGrid1.Rebind();
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_phrasebook_delete");
            database.AddInParameter(storedProcCommand, "@PhraseBookID", DbType.String, e.CommandArgument);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, this.CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, this.section.ToString());
            database.ExecuteNonQuery(storedProcCommand);
            this.RadGrid1.Rebind();
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            base.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_deleted_successfully"), "msg-success", this.plhMessage);
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid1.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid1.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.settings_phrasebook_delete(this.CompanyID, Convert.ToInt32(htmlInputCheckBox.Value.ToString()), this.section);
                }
            }
            this.GridBind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Phrases_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void ObjDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (Convert.ToInt32(e.ReturnValue) != -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_Successfully_Inserted"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_already_exists"), "msg-fail", this.plhMessage);
        }

        protected void ObjDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (Convert.ToInt32(e.ReturnValue) != -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_successfully_updated"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_already_exists"), "msg-fail", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("System_PhraseBook")));
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("System_PhraseBook"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("System_PhraseBook");
            this.RadGrid1.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Option_Title");
            this.RadGrid1.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Default_Phrase");
            this.RadGrid1.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            DataTable dataTable = new DataTable();
            dataTable = Department.DepartmentCustomFields_ScreenName_Select((long)this.CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row[0] = base.SpecialDecode(row[0].ToString());
            }
            this.lbldeptScreenName1.Text = dataTable.Rows[0][0].ToString();
            this.lbldeptScreenName2.Text = dataTable.Rows[1][0].ToString();
            this.lbldeptScreenName3.Text = dataTable.Rows[2][0].ToString();
            this.lbldeptScreenName4.Text = dataTable.Rows[3][0].ToString();
            this.lbldeptScreenName5.Text = dataTable.Rows[4][0].ToString();
            this.lbldeptScreenName6.Text = dataTable.Rows[5][0].ToString();
            this.lbldeptScreenName7.Text = dataTable.Rows[6][0].ToString();
            this.lbldeptScreenName8.Text = dataTable.Rows[7][0].ToString();
            this.lbldeptScreenName9.Text = dataTable.Rows[8][0].ToString();
            this.lbldeptScreenName10.Text = dataTable.Rows[9][0].ToString();
            this.lbldeptScreenName11.Text = dataTable.Rows[10][0].ToString();
            this.lbldeptScreenName12.Text = dataTable.Rows[11][0].ToString();
            this.lbldeptScreenName13.Text = dataTable.Rows[12][0].ToString();
            this.lbldeptScreenName14.Text = dataTable.Rows[13][0].ToString();
            this.lbldeptScreenName15.Text = dataTable.Rows[14][0].ToString();
            DataTable dataTable1 = new DataTable();
            dataTable1 = Company.ContactCustomFields_ScreenName_Select((long)this.CompanyID);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                dataRow[0] = base.SpecialDecode(dataRow[0].ToString());
            }
            this.lblconScreenName1.Text = dataTable1.Rows[0][0].ToString();
            this.lblconScreenName2.Text = dataTable1.Rows[1][0].ToString();
            this.lblconScreenName3.Text = dataTable1.Rows[2][0].ToString();
            this.lblconScreenName4.Text = dataTable1.Rows[3][0].ToString();
            this.lblconScreenName5.Text = dataTable1.Rows[4][0].ToString();
            this.lblconScreenName6.Text = dataTable1.Rows[5][0].ToString();
            this.lblconScreenName7.Text = dataTable1.Rows[6][0].ToString();
            this.lblconScreenName8.Text = dataTable1.Rows[7][0].ToString();
            this.lblconScreenName9.Text = dataTable1.Rows[8][0].ToString();
            this.lblconScreenName10.Text = dataTable1.Rows[9][0].ToString();
            this.lblconScreenName11.Text = dataTable1.Rows[10][0].ToString();
            this.lblconScreenName12.Text = dataTable1.Rows[11][0].ToString();
            this.lblconScreenName13.Text = dataTable1.Rows[12][0].ToString();
            this.lblconScreenName14.Text = dataTable1.Rows[13][0].ToString();
            this.lblconScreenName15.Text = dataTable1.Rows[14][0].ToString();
            this.RadGrid1.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_Display");
            if (base.Request.Params["type"] == null)
            {
                this.RadGrid1.Visible = false;
            }
            else
            {
                this.pnlLeftSelection.Visible = false;
                this.RadGrid1.Visible = true;
                this.lnkDelete.Visible = true;
                string lower = base.Request.Params["type"].ToLower();
                string str = lower;
                if (lower != null)
                {
                    switch (str)
                    {
                        case "eh":
                            {
                                this.lblphrase.Visible = false;
                                this.section = "Estimate Header";
                                break;
                            }
                        case "ea":
                            {
                                this.lblphrase.Visible = false;
                                this.section = "Estimate Artwork";
                                break;
                            }
                        case "ef":
                            {
                                this.section = "Estimate Footer";
                                break;
                            }
                        case "et":
                            {
                                this.section = "Estimate Title";
                                break;
                            }
                        case "eo":
                            {
                                this.section = "Estimate Description";
                                break;
                            }
                        case "ec":
                            {
                                this.section = "Estimate Colours";
                                break;
                            }
                        case "es":
                            {
                                this.section = "Estimate Size";
                                break;
                            }
                        case "em":
                            {
                                this.section = "Estimate Material";
                                break;
                            }
                        case "ed":
                            {
                                this.section = "Estimate Delivery";
                                break;
                            }
                        case "efinish":
                            {
                                this.section = "Estimate Finishing";
                                break;
                            }
                        case "eproofs":
                            {
                                this.section = "Estimate Proofs";
                                break;
                            }
                        case "epacking":
                            {
                                this.section = "Estimate Packing";
                                break;
                            }
                        case "en":
                            {
                                this.section = "Estimate Notes";
                                break;
                            }
                        case "ei":
                            {
                                this.lblphrase.Text = "Terms/Instructions";
                                this.section = "Estimate Terms";
                                break;
                            }
                        case "ec1":
                            {
                                this.section = "Estimate CustomDescription1";
                                break;
                            }
                        case "ec2":
                            {
                                this.section = "Estimate CustomDescription2";
                                break;
                            }
                        case "ec3":
                            {
                                this.section = "Estimate CustomDescription3";
                                break;
                            }
                        case "ec4":
                            {
                                this.section = "Estimate CustomDescription4";
                                break;
                            }
                        case "ec5":
                            {
                                this.section = "Estimate CustomDescription5";
                                break;
                            }
                        case "ec6":
                            {
                                this.section = "Estimate CustomDescription6";
                                break;
                            }
                        case "ec7":
                            {
                                this.section = "Estimate CustomDescription7";
                                break;
                            }
                        case "ec8":
                            {
                                this.section = "Estimate CustomDescription8";
                                break;
                            }
                        case "ec9":
                            {
                                this.section = "Estimate CustomDescription9";
                                break;
                            }
                        case "ec10":
                            {
                                this.section = "Estimate CustomDescription10";
                                break;
                            }
                        case "ec11":
                            {
                                this.section = "Estimate CustomDescription11";
                                break;
                            }
                        case "ec12":
                            {
                                this.section = "Estimate CustomDescription12";
                                break;
                            }
                        case "ec13":
                            {
                                this.section = "Estimate CustomDescription13";
                                break;
                            }
                        case "ec14":
                            {
                                this.section = "Estimate CustomDescription14";
                                break;
                            }
                        case "ec15":
                            {
                                this.section = "Estimate CustomDescription15";
                                break;
                            }
                        case "ec16":
                            {
                                this.section = "Estimate CustomDescription16";
                                break;
                            }
                        case "ec17":
                            {
                                this.section = "Estimate CustomDescription17";
                                break;
                            }
                        case "ec18":
                            {
                                this.section = "Estimate CustomDescription18";
                                break;
                            }
                        case "ec19":
                            {
                                this.section = "Estimate CustomDescription19";
                                break;
                            }
                        case "ec20":
                            {
                                this.section = "Estimate CustomDescription20";
                                break;
                            }
                        case "ec21":
                            {
                                this.section = "Estimate CustomDescription21";
                                break;
                            }
                        case "ec22":
                            {
                                this.section = "Estimate CustomDescription22";
                                break;
                            }
                        case "ec23":
                            {
                                this.section = "Estimate CustomDescription23";
                                break;
                            }
                        case "ec24":
                            {
                                this.section = "Estimate CustomDescription24";
                                break;
                            }
                        case "ec25":
                            {
                                this.section = "Estimate CustomDescription25";
                                break;
                            }
                        case "jh":
                            {
                                this.lblphrase.Text = "Job Header";
                                this.section = "Job Header";
                                break;
                            }
                        case "jf":
                            {
                                this.lblphrase.Text = "Job Footer";
                                this.section = "Job Footer";
                                break;
                            }
                        case "ih":
                            {
                                this.lblphrase.Text = "Invoice Header";
                                this.section = "Invoice Header";
                                break;
                            }
                        case "if":
                            {
                                this.lblphrase.Text = "Invoice Footer";
                                this.section = "Invoice Footer";
                                break;
                            }
                        case "ph":
                            {
                                this.lblphrase.Text = "Purchase Header";
                                this.section = "Purchase Header";
                                break;
                            }
                        case "pf":
                            {
                                this.lblphrase.Text = "Purchase Footer";
                                this.section = "Purchase Footer";
                                break;
                            }
                        case "pi":
                            {
                                this.lblphrase.Text = "Comments/Delivery Instructions";
                                this.section = "Delivery Instructions";
                                break;
                            }
                        case "dh":
                            {
                                this.lblphrase.Text = "Delivery Note Header";
                                this.section = "Delivery Note Header";
                                break;
                            }
                        case "df":
                            {
                                this.lblphrase.Text = "Delivery Note Footer";
                                this.section = "Delivery Note Footer";
                                break;
                            }
                        case "ot":
                            {
                                this.lblphrase.Text = "PrintBroker ";
                                this.section = "PrintBroker Title";
                                break;
                            }
                        case "oo":
                            {
                                this.section = "PrintBroker Description";
                                break;
                            }
                        case "oa":
                            {
                                this.section = "PrintBroker Artwork";
                                break;
                            }
                        case "oc":
                            {
                                this.section = "PrintBroker Colours";
                                break;
                            }
                        case "os":
                            {
                                this.section = "PrintBroker Size";
                                break;
                            }
                        case "om":
                            {
                                this.section = "PrintBroker Material";
                                break;
                            }
                        case "od":
                            {
                                this.section = "PrintBroker Delivery";
                                break;
                            }
                        case "ofinish":
                            {
                                this.section = "PrintBroker Finishing";
                                break;
                            }
                        case "oproofs":
                            {
                                this.section = "PrintBroker Proofs";
                                break;
                            }
                        case "opacking":
                            {
                                this.section = "PrintBroker Packing";
                                break;
                            }
                        case "on":
                            {
                                this.section = "PrintBroker Notes";
                                break;
                            }
                        case "oi":
                            {
                                this.section = "PrintBroker Terms";
                                break;
                            }
                        case "oc1":
                            {
                                this.section = "PrintBroker CustomDescription1";
                                break;
                            }
                        case "oc2":
                            {
                                this.section = "PrintBroker CustomDescription2";
                                break;
                            }
                        case "oc3":
                            {
                                this.section = "PrintBroker CustomDescription3";
                                break;
                            }
                        case "oc4":
                            {
                                this.section = "PrintBroker CustomDescription4";
                                break;
                            }
                        case "oc5":
                            {
                                this.section = "PrintBroker CustomDescription5";
                                break;
                            }
                        case "oc6":
                            {
                                this.section = "PrintBroker CustomDescription6";
                                break;
                            }
                        case "oc7":
                            {
                                this.section = "PrintBroker CustomDescription7";
                                break;
                            }
                        case "oc8":
                            {
                                this.section = "PrintBroker CustomDescription8";
                                break;
                            }
                        case "oc9":
                            {
                                this.section = "PrintBroker CustomDescription9";
                                break;
                            }
                        case "oc10":
                            {
                                this.section = "PrintBroker CustomDescription10";
                                break;
                            }
                        case "oc11":
                            {
                                this.section = "PrintBroker CustomDescription11";
                                break;
                            }
                        case "oc12":
                            {
                                this.section = "PrintBroker CustomDescription12";
                                break;
                            }
                        case "oc13":
                            {
                                this.section = "PrintBroker CustomDescription13";
                                break;
                            }
                        case "oc14":
                            {
                                this.section = "PrintBroker CustomDescription14";
                                break;
                            }
                        case "oc15":
                            {
                                this.section = "PrintBroker CustomDescription15";
                                break;
                            }
                        case "oc16":
                            {
                                this.section = "PrintBroker CustomDescription16";
                                break;
                            }
                        case "oc17":
                            {
                                this.section = "PrintBroker CustomDescription17";
                                break;
                            }
                        case "oc18":
                            {
                                this.section = "PrintBroker CustomDescription18";
                                break;
                            }
                        case "oc19":
                            {
                                this.section = "PrintBroker CustomDescription19";
                                break;
                            }
                        case "oc20":
                            {
                                this.section = "PrintBroker CustomDescription20";
                                break;
                            }
                        case "oc21":
                            {
                                this.section = "PrintBroker CustomDescription21";
                                break;
                            }
                        case "oc22":
                            {
                                this.section = "PrintBroker CustomDescription22";
                                break;
                            }
                        case "oc23":
                            {
                                this.section = "PrintBroker CustomDescription23";
                                break;
                            }
                        case "oc24":
                            {
                                this.section = "PrintBroker CustomDescription24";
                                break;
                            }
                        case "oc25":
                            {
                                this.section = "PrintBroker CustomDescription25";
                                break;
                            }
                        case "ohe":
                            {
                                this.section = "PrintBroker Header";
                                break;
                            }
                        case "ofo":
                            {
                                this.section = "PrintBroker Footer";
                                break;
                            }
                        case "mb":
                            {
                                this.section = "Email Body";
                                break;
                            }
                        case "mfs":
                            {
                                this.section = "Footer Signature";
                                break;
                            }
                        case "lsr":
                            {
                                this.section = "Low Stock Reminder Email";
                                break;
                            }
                        case "temp_ed":
                            {
                                this.section = "Editable Template";
                                break;
                            }
                        case "act_hist":
                            {
                                this.section = "Activity History Error";
                                break;
                            }
                    }
                }
            }
            this.Session["section"] = this.section.ToString();
            this.sectionvalue = this.Session["section"].ToString();
            try
            {
                string str1 = this.section;
                char[] chrArray = new char[] { ' ' };
                if (str1.Split(chrArray)[0].ToLower() != "printbroker")
                {
                    this.label = this.section;
                }
                else
                {
                    int num = 1;
                    while (num <= 25)
                    {
                        string str2 = this.section;
                        char[] chrArray1 = new char[] { ' ' };
                        if (str2.Split(chrArray1)[1].ToLower() != string.Concat("customdescription", num))
                        {
                            string str3 = this.section;
                            char[] chrArray2 = new char[] { ' ' };
                            this.label = string.Concat("Outwork ", str3.Split(chrArray2)[1]);
                            num++;
                        }
                        else
                        {
                            this.label = string.Concat("Outwork Custom Description ", num);
                            goto Label0;
                        }
                    }
                }
            Label0:
                string str4 = this.section;
                char[] chrArray3 = new char[] { ' ' };
                if (str4.Split(chrArray3)[0].ToLower() == "estimate")
                {
                    int num1 = 1;
                    while (num1 <= 25)
                    {
                        string str5 = this.section;
                        char[] chrArray4 = new char[] { ' ' };
                        if (str5.Split(chrArray4)[1].ToLower() != string.Concat("customdescription", num1))
                        {
                            string str6 = this.section;
                            char[] chrArray5 = new char[] { ' ' };
                            this.label = string.Concat("Estimate ", str6.Split(chrArray5)[1]);
                            num1++;
                        }
                        else
                        {
                            this.label = string.Concat("Estimate Custom Description ", num1);
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
            if (this.label != "")
            {
                Label label = this.lblheader;
                string[] strArrays = new string[] { this.objLanguage.GetLanguageConversion("eStore_Settings"), ": ", this.objLanguage.GetLanguageConversion("Dropdown_Options"), " - ", this.label };
                label.Text = string.Concat(strArrays);
            }
            else
            {
                this.lblheader.Text = string.Concat(this.objLanguage.GetLanguageConversion("eStore_Settings"), ": ", this.objLanguage.GetLanguageConversion("Dropdown_Options"));
            }
            if (!base.IsPostBack)
            {
                this.GridBind();
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
        }

        protected void RadGrid1_DataBound(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.gridMessage))
            {
                this.DisplayMessage(this.gridMessage);
            }
        }

        protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
        {
            this.SessionDataSource1.DeleteParameters.Add("PhraseType", this.section.ToString());
            this.SessionDataSource1.DataBind();
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            TextBox textBox = (TextBox)e.Item.FindControl("txtPhraseText");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkedit");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtTitle");
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlType");
            DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlSeperator");
            DropDownList dropDownList2 = (DropDownList)e.Item.FindControl("ddlLabelSeparator");
            HiddenField selectedValue = (HiddenField)e.Item.FindControl("hdnLabelSeperator");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnSeperator");
            hiddenField.Value = " ";
            selectedValue.Value = " ";
            if (checkBox.Checked)
            {
                this.DefaultPhrase = true;
            }
            if (dropDownList.SelectedItem.Text == "Fixed")
            {
                hiddenField.Value = dropDownList1.SelectedValue;
            }
            if (dropDownList.SelectedItem.Text == "Fixed" || dropDownList.SelectedItem.Text == "Addresses")
            {
                selectedValue.Value = dropDownList2.SelectedValue;
            }
            string str = base.SpecialEncode(textBox.Text);
            string str1 = base.SpecialEncode(textBox1.Text);
            this.SessionDataSource1.InsertParameters.Clear();
            this.SessionDataSource1.InsertParameters.Add("companyID", this.Session["companyID"].ToString());
            this.SessionDataSource1.InsertParameters.Add("PhraseType", this.section.ToString());
            this.SessionDataSource1.InsertParameters.Add("PhraseText", str.ToString());
            this.SessionDataSource1.InsertParameters.Add("IsDefaultPhrase", this.DefaultPhrase.ToString());
            this.SessionDataSource1.InsertParameters.Add("Type", dropDownList.SelectedItem.Text);
            this.SessionDataSource1.InsertParameters.Add("Title", str1.ToString());
            this.SessionDataSource1.InsertParameters.Add("EmailTemplateName", "estimate");
            this.SessionDataSource1.InsertParameters.Add("emailTemplateType", "estimate");
            this.SessionDataSource1.InsertParameters.Add("LineSeparator", hiddenField.Value);
            this.SessionDataSource1.InsertParameters.Add("LabelSeparator", selectedValue.Value);
        }

        protected void RadGrid1_ItemCreated(object source, GridItemEventArgs e)
        {
        }

        protected void radGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            GridItem[] items = this.RadGrid1.MasterTableView.GetItems(new GridItemType[] { GridItemType.CommandItem });
            for (int i = 0; i < (int)items.Length; i++)
            {
                LinkButton languageConversion = (LinkButton)((GridCommandItem)items[i]).FindControl("InitInsertButton");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Add_New_Record");
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridItem[] gridItemArray = this.RadGrid1.MasterTableView.GetItems(new GridItemType[] { GridItemType.CommandItem });
                for (int j = 0; j < (int)gridItemArray.Length; j++)
                {
                    LinkButton linkButton = (LinkButton)((GridCommandItem)gridItemArray[j]).FindControl("InitInsertButton");
                    linkButton.Text = this.objLanguage.GetLanguageConversion("Add_New_Record");
                }
                TextBox textBox = (TextBox)e.Item.FindControl("txtPhraseText");
                RadButton radButton = (RadButton)e.Item.FindControl("RadButton1");
                RadButton languageConversion1 = (RadButton)e.Item.FindControl("RadButton8");
                RequiredFieldValidator requiredFieldValidator = (RequiredFieldValidator)e.Item.FindControl("requiredfieldvalidator1");
                RequiredFieldValidator requiredFieldValidator1 = (RequiredFieldValidator)e.Item.FindControl("requiredfieldvalidator2");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtTitle");
                DropDownList text = (DropDownList)e.Item.FindControl("ddlType");
                DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlSeperator");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnType");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnSeperator");
                Label label = (Label)e.Item.FindControl("lblTagsHelpText");
                DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlLabelSeparator");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdnLabelSeperator");
                requiredFieldValidator.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Enter_Option_Text");
                requiredFieldValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Enter_Option_Title");
                radButton.Text = this.objLanguage.GetLanguageConversion("Save");
                languageConversion1.Text = this.objLanguage.GetLanguageConversion("Cancel");
                textBox.Text = base.SpecialDecode(textBox.Text);
                textBox1.Text = base.SpecialDecode(textBox1.Text);
                text.SelectedValue = text.SelectedItem.Text;
                base.SetDDLText(text, hiddenField.Value);
                base.SetDDLValue(dropDownList, hiddenField1.Value);
                base.SetDDLValue(dropDownList1, hiddenField2.Value);
                if (hiddenField.Value == "Fixed" || hiddenField.Value == "")
                {
                    dropDownList.Enabled = true;
                    label.Style.Add("visibility", "hidden");
                }
                else
                {
                    dropDownList.Enabled = false;
                }
                string value = hiddenField.Value;
                System.Web.UI.Page page = this.Page;
                Type type = base.GetType();
                string[] strArrays = new string[] { "javascript:DisplyDiv('", value, "');DisplySeparator('", hiddenField.Value, "');" };
                System.Web.UI.ScriptManager.RegisterStartupScript(page, type, "", string.Concat(strArrays), true);
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                TextBox textBox2 = item.FindControl("txtPhraseText") as TextBox;
                (item.FindControl("txtTitle") as TextBox).Focus();
                try
                {
                    this.type = base.Request.Params["type"].ToLower();
                    this.strLo = this.type.ToLower();
                    if (this.strLo == "eh" || this.strLo == "ef" || this.strLo == "ep" || this.strLo == "et" || this.strLo == "eo" || this.strLo == "ea" || this.strLo == "ec" || this.strLo == "es" || this.strLo == "em" || this.strLo == "ed" || this.strLo == "efinish" || this.strLo == "eproofs" || this.strLo == "epacking" || this.strLo == "en" || this.strLo == "ei" || this.strLo == "jh" || this.strLo == "jf" || this.strLo == "ih" || this.strLo == "if" || this.strLo == "ph" || this.strLo == "pf" || this.strLo == "df" || this.strLo == "pi" || this.strLo == "ot" || this.strLo == "oo" || this.strLo == "oa" || this.strLo == "oc" || this.strLo == "os" || this.strLo == "om" || this.strLo == "od" || this.strLo == "ofinish" || this.strLo == "opacking" || this.strLo == "on" || this.strLo == "oi" || this.strLo == "ohe" || this.strLo == "ofo" || this.strLo == "oo" || this.strLo == "oo" || this.strLo == "mfs" || this.strLo == "oproofs" || this.strLo == "dh" || this.strLo == "lsr" || this.strLo == "temp_ed" || this.strLo == "act_hist")
                    {
                        textBox2.Height = Unit.Pixel(155);
                        textBox2.Width = Unit.Pixel(350);
                    }
                    else
                    {
                        textBox2.Width = Unit.Pixel(350);
                        textBox2.MaxLength = 100;
                    }
                }
                catch
                {
                }
                if (e.Item is GridPagerItem)
                {
                    Label label1 = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                    label1.Text = this.objLanguage.GetLanguageConversion("Page_size");
                    GridTableView masterTableView = this.RadGrid1.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                    GridPagerItem gridPagerItem = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    this.RadGrid1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
                }
            }
            if (e.Item is GridDataItem)
            {
                GridDataItem gridDataItem = (GridDataItem)e.Item;
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                Image image = new Image();
                Label label2 = (Label)gridDataItem.FindControl("lblIsDefaultPhrase");
                if (label2.Text.ToLower().Trim() != "yes")
                {
                    label2.Text = "";
                }
                else
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "check.gif");
                    label2.Controls.Add(image);
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item1 = (GridDataItem)e.Item;
                item1["Title"].ToolTip = item1["Title"].Text;
                item1["Title"].Text = string.Concat("<div style='width:300px;overflow:hidden;max-height: 15px;height:15px;cursor:pointer; '>", item1["Title"].Text, "</div>");
            }
        }

        protected void RadGrid1_ItemUpdated(object source, GridUpdatedEventArgs e)
        {
            GridEditableItem item = e.Item;
            ((TextBox)e.Item.FindControl("txtPhraseText")).Focus();
        }

        protected void RadGrid1_OnItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.RadGrid1.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.RadGrid1.MasterTableView.ClearEditItems();
            }
        }

        protected void RadGrid1_PazeIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGrid1.CurrentPageIndex = e.NewPageIndex;
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_PazeSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.RadGrid1.Rebind();
        }

        protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            TextBox textBox = (TextBox)e.Item.FindControl("txtPhraseText");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtTitle");
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlType");
            DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlSeperator");
            HiddenField text = (HiddenField)e.Item.FindControl("hdnType");
            HiddenField selectedValue = (HiddenField)e.Item.FindControl("hdnSeperator");
            DropDownList dropDownList2 = (DropDownList)e.Item.FindControl("ddlLabelSeparator");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnLabelSeperator");
            text.Value = dropDownList.SelectedItem.Text;
            hiddenField.Value = " ";
            selectedValue.Value = " ";
            if (dropDownList.SelectedItem.Text == "Fixed")
            {
                selectedValue.Value = dropDownList1.SelectedValue;
            }
            if (dropDownList.SelectedItem.Text == "Fixed" || dropDownList.SelectedItem.Text == "Addresses")
            {
                hiddenField.Value = dropDownList2.SelectedValue;
            }
            if (((CheckBox)e.Item.FindControl("chkedit")).Checked)
            {
                this.DefaultPhrase = true;
            }
            string str = base.SpecialEncode(textBox.Text);
            string str1 = base.SpecialEncode(textBox1.Text);
            this.SessionDataSource1.UpdateParameters.Add("PhraseType", this.section.ToString());
            this.SessionDataSource1.UpdateParameters.Add("PhraseText", str.ToString());
            this.SessionDataSource1.UpdateParameters.Add("IsDefaultPhrase", this.DefaultPhrase.ToString());
            this.SessionDataSource1.UpdateParameters.Add("Type", text.Value);
            this.SessionDataSource1.UpdateParameters.Add("Title", str1.ToString());
            this.SessionDataSource1.UpdateParameters.Add("EmailTemplateName", "estimate");
            this.SessionDataSource1.UpdateParameters.Add("emailTemplateType", "estimate");
            this.SessionDataSource1.UpdateParameters.Add("LineSeparator", selectedValue.Value);
            this.SessionDataSource1.UpdateParameters.Add("LabelSeparator", hiddenField.Value);
        }

        private void SetMessage(string message)
        {
            this.gridMessage = message;
        }
    }
}