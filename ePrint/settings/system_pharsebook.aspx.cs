using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
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

namespace ePrint.settings
{
    public partial class system_pharsebook : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected Label lblheader;

        //protected Label lblphrase;

        //protected HiddenField hdn;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected usercontrol_settings_PhraseBookMenu PraseMenue;

        //protected RadCodeBlock RadCodeBlock1;

        //protected Panel pnlLeftSelection;

        //protected LinkButton lnkDelete;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected RadGrid RadGrid1;

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor1;

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor2;

        //protected RadWindowManager RadWindowManager1;

        //protected ObjectDataSource SessionDataSource1;

        //protected Panel pnlest;

        //protected Panel Panel1;

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

        public BasePage ObjPage = new BasePage();

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
            if (Convert.ToInt32(e.ReturnValue) == -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_already_exists"), "msg-fail", this.plhMessage);
                return;
            }
            this.GridBind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Phrase_Successfully_Inserted"), "msg-success", this.plhMessage);
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
            base.Title = this.objLanguage.convert(global.pageTitle("System Phrasebook", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Phrase_Book");
            this.RadGrid1.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Phrase_Text");
            this.RadGrid1.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Default_Phrase");
            this.RadGrid1.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.RadGrid1.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_Display");
            if (base.Request.Params["type"] == null)
            {
                this.pnlLeftSelection.Visible = true;
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
                if (str1.Split(chrArray)[0].ToLower() == "printbroker")
                {
                    int num = 1;
                    while (num <= 25)
                    {
                        string str2 = this.section;
                        char[] chrArray1 = new char[] { ' ' };
                        if (str2.Split(chrArray1)[1].ToLower() != string.Concat("customdescription", num))
                        {
                            if (string.IsNullOrEmpty(this.section) || !this.section.Contains("Colours"))
                            {
                                string str3 = this.section;
                                char[] chrArray2 = new char[] { ' ' };
                                this.label = string.Concat("Outwork ", str3.Split(chrArray2)[1]);
                            }
                            else
                            {
                                string str4 = this.section;
                                char[] chrArray3 = new char[] { ' ' };
                                this.label = string.Concat(str4.Split(chrArray3)[0], " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                            }
                            num++;
                        }
                        else
                        {
                            this.label = string.Concat("Outwork Custom Description ", num);
                            goto Label0;
                        }
                    }
                }
                else if (string.IsNullOrEmpty(this.section) || !this.section.Contains("Colours"))
                {
                    this.label = this.section;
                }
                else
                {
                    string str5 = this.section;
                    char[] chrArray4 = new char[] { ' ' };
                    this.label = string.Concat(str5.Split(chrArray4)[0], " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                }
            Label0:
                string str6 = this.section;
                char[] chrArray5 = new char[] { ' ' };
                if (str6.Split(chrArray5)[0].ToLower() == "estimate")
                {
                    int num1 = 1;
                    while (num1 <= 25)
                    {
                        string str7 = this.section;
                        char[] chrArray6 = new char[] { ' ' };
                        if (str7.Split(chrArray6)[1].ToLower() != string.Concat("customdescription", num1))
                        {
                            if (string.IsNullOrEmpty(this.section) || !this.section.Contains("Colours"))
                            {
                                string str8 = this.section;
                                char[] chrArray7 = new char[] { ' ' };
                                this.label = string.Concat("Estimate ", str8.Split(chrArray7)[1]);
                            }
                            else
                            {
                                string str9 = this.section;
                                char[] chrArray8 = new char[] { ' ' };
                                this.label = string.Concat(str9.Split(chrArray8)[0], " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                            }
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
            if (base.Request.Params["Mtype"].ToLower() == "pb")
            {
                if (this.label != "")
                {
                    string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Phrase_Book"), " > ", this.label));
                }
                else
                {
                    string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Phrase_Book")));
                }
            }
            if (base.Request.Params["Mtype"].ToLower() == "eml")
            {
                if (this.label != "")
                {
                    string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Phrase_Book"), " > ", this.label));
                }
                else
                {
                    string[] strArrays1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Phrase_Book")));
                }
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
            if (((CheckBox)e.Item.FindControl("chkedit")).Checked)
            {
                this.DefaultPhrase = true;
            }
            string str = base.SpecialEncode(textBox.Text);
            this.SessionDataSource1.InsertParameters.Clear();
            this.SessionDataSource1.InsertParameters.Add("companyID", this.Session["companyID"].ToString());
            this.SessionDataSource1.InsertParameters.Add("PhraseType", this.section.ToString());
            this.SessionDataSource1.InsertParameters.Add("PhraseText", str.ToString());
            this.SessionDataSource1.InsertParameters.Add("IsDefaultPhrase", this.DefaultPhrase.ToString());
            this.SessionDataSource1.InsertParameters.Add("EmailTemplateName", "estimate");
            this.SessionDataSource1.InsertParameters.Add("emailTemplateType", "estimate");
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
                requiredFieldValidator.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Enter_Phrase_Text");
                radButton.Text = this.objLanguage.GetLanguageConversion("Save");
                languageConversion1.Text = this.objLanguage.GetLanguageConversion("Cancel");
                textBox.Text = base.SpecialDecode(textBox.Text);
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                TextBox textBox1 = (e.Item as GridEditableItem).FindControl("txtPhraseText") as TextBox;
                textBox1.Focus();
                try
                {
                    this.type = base.Request.Params["type"].ToLower();
                    this.strLo = this.type.ToLower();
                    if (this.strLo == "eh" || this.strLo == "ef" || this.strLo == "ep" || this.strLo == "et" || this.strLo == "eo" || this.strLo == "ea" || this.strLo == "ec" || this.strLo == "es" || this.strLo == "em" || this.strLo == "ed" || this.strLo == "efinish" || this.strLo == "eproofs" || this.strLo == "epacking" || this.strLo == "en" || this.strLo == "ei" || this.strLo == "jh" || this.strLo == "jf" || this.strLo == "ih" || this.strLo == "if" || this.strLo == "ph" || this.strLo == "pf" || this.strLo == "df" || this.strLo == "pi" || this.strLo == "ot" || this.strLo == "oo" || this.strLo == "oa" || this.strLo == "oc" || this.strLo == "os" || this.strLo == "om" || this.strLo == "od" || this.strLo == "ofinish" || this.strLo == "opacking" || this.strLo == "on" || this.strLo == "oi" || this.strLo == "ohe" || this.strLo == "ofo" || this.strLo == "oo" || this.strLo == "oo" || this.strLo == "mfs" || this.strLo == "oproofs" || this.strLo == "dh" || this.strLo == "lsr" || this.strLo == "temp_ed" || this.strLo == "act_hist")
                    {
                        textBox1.Height = Unit.Pixel(100);
                        textBox1.Width = Unit.Pixel(500);
                    }
                    else
                    {
                        textBox1.Width = Unit.Pixel(500);
                        textBox1.MaxLength = 100;
                    }
                }
                catch
                {
                }
                if (e.Item is GridPagerItem)
                {
                    Label label = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                    label.Text = this.objLanguage.GetLanguageConversion("Page_size");
                    GridTableView masterTableView = this.RadGrid1.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                    GridPagerItem gridPagerItem = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    this.RadGrid1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
                }
            }
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                Image image = new Image();
                Label label1 = (Label)item.FindControl("lblIsDefaultPhrase");
                if (label1.Text.ToLower().Trim() != "yes")
                {
                    label1.Text = "";
                }
                else
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "check.gif");
                    label1.Controls.Add(image);
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem text = (GridDataItem)e.Item;
                text["PhraseText"].ToolTip = text["PhraseText"].Text;
                text["PhraseText"].Text = string.Concat("<div style='width:300px;overflow:hidden;max-height: 15px;height:15px;cursor:pointer; '>", text["PhraseText"].Text, "</div>");
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
            if (((CheckBox)e.Item.FindControl("chkedit")).Checked)
            {
                this.DefaultPhrase = true;
            }
            string str = base.SpecialEncode(textBox.Text);
            this.SessionDataSource1.UpdateParameters.Add("PhraseType", this.section.ToString());
            this.SessionDataSource1.UpdateParameters.Add("PhraseText", str.ToString());
            this.SessionDataSource1.UpdateParameters.Add("IsDefaultPhrase", this.DefaultPhrase.ToString());
            this.SessionDataSource1.UpdateParameters.Add("EmailTemplateName", "estimate");
        }

        private void SetMessage(string message)
        {
            this.gridMessage = message;
        }
    }
}