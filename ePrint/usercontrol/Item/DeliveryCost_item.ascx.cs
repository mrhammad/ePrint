using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class DeliveryCost_item : UsercontrolBasePage
    {
        //protected Label label10;

        //protected TextBox txtitemtitle;

        //protected Label label6;

        //protected TextBox txtdescription;

        //protected HtmlGenericControl div_description;

        //protected HiddenField hid_QtyType;

        //protected HiddenField hid_Q1;

        //protected HiddenField hid_Q2;

        //protected HiddenField hid_Q3;

        //protected HiddenField hid_Q4;

        //protected TextBox txtQuantity;

        //protected TextBox txtQuantity_2;

        //protected TextBox txtQuantity_3;

        //protected TextBox txtQuantity_4;

        //protected Label label1;

        //protected TextBox txtcost;

        //protected TextBox txtcost1;

        //protected TextBox txtcost2;

        //protected TextBox txtcost3;

        //protected Label label2;

        //protected DropDownList ddlprofitmargin;

        //protected TextBox txtproftimarge;

        //protected TextBox txtproftimarge1;

        //protected TextBox txtproftimarge2;

        //protected TextBox txtproftimarge3;

        //protected Label label3;

        //protected TextBox txtsubtotal;

        //protected TextBox txtsubtotal1;

        //protected TextBox txtsubtotal2;

        //protected TextBox txtsubtotal3;

        //protected Label label4;

        //protected DropDownList ddltax;

        //protected TextBox lbltax;

        //protected TextBox lbltax1;

        //protected TextBox lbltax2;

        //protected TextBox lbltax3;

        //protected Label label5;

        //protected TextBox txtsellingprice;

        //protected TextBox txtsellingprice1;

        //protected TextBox txtsellingprice2;

        //protected TextBox txtsellingprice3;

        //protected Label Label7;

        //protected HtmlImage Img_ItemDescnHelp;

        //protected HtmlAnchor img_UpdateDescription;

        //protected CheckBox Chk_ItemDescn;

        //protected HtmlGenericControl Div_ItemDescn;

        //protected Label Label17;

        //protected HtmlImage Img1;

        //protected CheckBox chkPoduct1;

        //protected CheckBox chkPoduct2;

        //protected HtmlGenericControl Div_Productcatalogue;

        //protected Label lblAccountCode;

        //protected DropDownList ddlAccountCode;

        //protected HtmlGenericControl div_AccountCode;

        //protected Button btncancel;

        //protected Button btnprintemail;

        //protected HtmlGenericControl div_btnprint;

        //protected Button btnsave;

        //protected HiddenField hdntaxvalue;

        //protected HiddenField hid_quickquoteID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        public int CompanyID;

        public int UserID;

        private decimal ProfitMariginPrice;

        public long EstimateID;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public long EstimateItemID;

        public int DB_TaxID;

        public static decimal taxrate;

        private long EstimateQuickQuoteID;

        public static string QueryType;

        public static string modulename;

        public string submodulename = "estimate";

        public string str_QtyType = "single";

        private commonClass objJava = new commonClass();

        private EstimatesItem Estitem = new EstimatesItem();

        public string ClientId_PB = string.Empty;

        private notesclass objnotes = new notesclass();

        private BaseClass basec = new BaseClass();

        private Notes objN = new Notes();

        private string itemtitle = string.Empty;

        private string itemdesc = string.Empty;

        private string itemartwork = string.Empty;

        private string itemcolor = string.Empty;

        private string itemsize = string.Empty;

        private string itemmaterial = string.Empty;

        private string itemdelivery = string.Empty;

        private string itemfinishing = string.Empty;

        private string itemnotes = string.Empty;

        private string itemterms = string.Empty;

        private string itemproofs = string.Empty;

        private string itempacking = string.Empty;

        private string WareItemDesc = string.Empty;

        public string frmcopyitem = string.Empty;

        public int IsItemCompleted;

        public string MainType = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public languageClass objLanguage = new languageClass();

        public int IsProductCreated;

        public string qtystyle = string.Empty;

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

        static DeliveryCost_item()
        {
            DeliveryCost_item.taxrate = new decimal(0);
            DeliveryCost_item.QueryType = string.Empty;
            DeliveryCost_item.modulename = "estimates";
        }

        public DeliveryCost_item()
        {
        }

        public void bindprofitmargin()
        {
            decimal num = new decimal(0);
            num = (DeliveryCost_item.modulename != "invoice" ? EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID) : EstimatesBasePage.GetProfitMargin_InvoiceID(this.CompanyID, this.InvoiceID));
            num = Convert.ToDecimal(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num), 0, "", false, false, true));
            ArrayList arrayLists = new ArrayList();
            for (decimal i = new decimal(-20); i < new decimal(305); i = i + new decimal(5))
            {
                arrayLists.Add(i);
            }
            foreach (DataRow row in SettingsBasePage.settings_markup_selectall(this.CompanyID).Rows)
            {
                decimal num1 = Convert.ToDecimal(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MarkupRate"]), 0, "", false, false, true));
                if (arrayLists.Contains(num1))
                {
                    continue;
                }
                arrayLists.Add(num1);
            }
            if (!arrayLists.Contains(num))
            {
                arrayLists.Add(num);
            }
            if (!arrayLists.Contains(this.ProfitMariginPrice))
            {
                arrayLists.Add(this.ProfitMariginPrice);
            }
            arrayLists.Sort();
            for (int j = 0; j < arrayLists.Count; j++)
            {
                this.ddlprofitmargin.Items.Add(string.Concat(arrayLists[j].ToString().Replace(".00", ""), "%"));
            }
            if (0 >= this.ddlprofitmargin.Items.Count)
            {
                return;
            }
            this.ddlprofitmargin.SelectedIndex = this.ddlprofitmargin.Items.IndexOf(this.ddlprofitmargin.Items.FindByText(string.Concat(num.ToString(), "%")));
        }

        public void bindtax()
        {
            DataTable dataTable = EstimateBasePage.estimate_summary_tax_bind_2(this.CompanyID);
            this.ddltax.DataSource = dataTable;
            this.ddltax.DataTextField = "TaxName";
            this.ddltax.DataValueField = "TaxID";
            this.ddltax.DataBind();
            this.ddltax.Items.Insert(0, "0%");
            this.ddltax.Items[0].Text = "0%";
            this.ddltax.Items[0].Value = "0";
        }

        protected void btnprevious_onclick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (DeliveryCost_item.modulename.ToLower() == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, DeliveryCost_item.modulename);
            }
            else if (DeliveryCost_item.modulename.ToLower() == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, DeliveryCost_item.modulename);
            }
            if (DeliveryCost_item.QueryType != "add")
            {
                if (DeliveryCost_item.QueryType == "edit" && base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                {
                    if (DeliveryCost_item.modulename == "orders")
                    {
                        HttpResponse response = base.Response;
                        object[] estimateID = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                        response.Redirect(string.Concat(estimateID));
                        return;
                    }
                    if (empty.ToLower() == "yes")
                    {
                        HttpResponse httpResponse = base.Response;
                        object[] objArray = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID };
                        httpResponse.Redirect(string.Concat(objArray));
                        return;
                    }
                    HttpResponse response1 = base.Response;
                    object[] estimateID1 = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID };
                    response1.Redirect(string.Concat(estimateID1));
                }
                return;
            }
            if (base.Request.Params["FromAddAnItem"] == null)
            {
                if (this.submodulename.ToLower() == "estimate")
                {
                    this.submodulename = "estimates";
                }
                if (this.submodulename.ToLower() == "job")
                {
                    this.submodulename = "job";
                }
                if (this.submodulename.ToLower() == "invoice")
                {
                    this.submodulename = "invoices";
                }
                HttpResponse httpResponse1 = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=T&From=F", this.jID, this.InvID };
                httpResponse1.Redirect(string.Concat(objArray1));
                return;
            }
            if (DeliveryCost_item.modulename == "orders")
            {
                HttpResponse response2 = base.Response;
                object[] estimateID2 = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                response2.Redirect(string.Concat(estimateID2));
                return;
            }
            if (empty.ToLower() == "yes")
            {
                HttpResponse httpResponse2 = base.Response;
                object[] objArray2 = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                httpResponse2.Redirect(string.Concat(objArray2));
                return;
            }
            HttpResponse response3 = base.Response;
            object[] estimateID3 = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
            response3.Redirect(string.Concat(estimateID3));
        }

        protected void btnprintemail_OnClick(object sender, EventArgs e)
        {
            this.WareItemDesc = this.Insert_Warehouse_ItemDescription();
            this.Estitem.ItemDescription = this.basec.ReplaceSingleQuote(this.WareItemDesc);
            this.Estitem.ModuleType = DeliveryCost_item.modulename;
            if (DeliveryCost_item.QueryType == "add")
            {
                this.insertitems();
            }
            else if (DeliveryCost_item.QueryType == "edit")
            {
                this.updateitems();
            }
            EstimatesBasePage.Estimate_DeliveryCost_insert(this.Estitem, ConnectionClass.IsHandy);
            DataTable dataTable = new DataTable();
            dataTable = (DeliveryCost_item.modulename != "invoice" ? EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID) : InvoiceBasePage.InvoiceDetails_ByInvoiceID_Select(this.InvoiceID));
            foreach (DataRow row in dataTable.Rows)
            {
                this.ClientId_PB = row["customerid"].ToString();
            }
            if (DeliveryCost_item.QueryType == "add")
            {
                this.MainType = "add";
            }
            if (this.AccountingCode == "e")
            {
                EstimateBasePage.DeliveryCost_AccountingCode_Insert(this.EstimateItemID, this.CompanyID, Convert.ToInt32(this.ddlAccountCode.SelectedValue));
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            if (DeliveryCost_item.QueryType == "add")
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "T", false);
                if (string.Compare(DeliveryCost_item.modulename, "invoice", true) == 0 || string.Compare(DeliveryCost_item.modulename, "jobs", true) == 0)
                {
                    JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "T");
                }
            }
            else if (DeliveryCost_item.QueryType == "edit")
            {
                if (this.Chk_ItemDescn.Checked)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "T", false);
                }
                if (string.Compare(DeliveryCost_item.modulename, "invoice", true) == 0 || string.Compare(DeliveryCost_item.modulename, "jobs", true) == 0)
                {
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "Q");
                }
                if (this.IsProductCreated == 1)
                {
                    int num = 0;
                    if (this.chkPoduct1.Checked)
                    {
                        num = 1;
                    }
                    else if (this.chkPoduct2.Checked)
                    {
                        num = 2;
                    }
                    DataTable dataTable1 = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "T");
                    if (dataTable1.Rows.Count > 0)
                    {
                        dataTable1.Rows[0]["PricecatalogueID"].ToString();
                        EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable1.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "T", num);
                    }
                }
            }
            this.InsertTo_activity_History();
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                HttpResponse response = base.Response;
                object[] clientIdPB = new object[] { this.strSitepath, "jobs/templates_view1.aspx?sectionid=", this.ClientId_PB, "&sectionname=Job&type=Customer&page=Job&EstID=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&MainType=", this.MainType, this.jID, this.InvID };
                response.Redirect(string.Concat(clientIdPB));
                return;
            }
            if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "Invoice/templates_view1.aspx?sectionid=", this.ClientId_PB, "&sectionname=Invoice&type=Customer&page=Invoice&EstID=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&MainType=", this.MainType, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                HttpResponse response1 = base.Response;
                object[] clientIdPB1 = new object[] { this.strSitepath, "estimates/templates_view1.aspx?sectionid=", this.ClientId_PB, "&sectionname=Estimate&type=supplier&page=Estimate&EstID=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&MainType=", this.MainType, this.jID, this.InvID };
                response1.Redirect(string.Concat(clientIdPB1));
                return;
            }
            HttpResponse httpResponse1 = base.Response;
            object[] objArray1 = new object[] { this.strSitepath, "orders/templates_view1.aspx?sectionid=", this.ClientId_PB, "&sectionname=webstoreorder&type=supplier&page=Estimate&ordid=", this.EstimateID, "&EstID=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&MainType=", this.MainType, this.jID, this.InvID };
            httpResponse1.Redirect(string.Concat(objArray1));
        }

        protected void btsave_onclick(object sender, EventArgs e)
        {
            this.WareItemDesc = this.Insert_Warehouse_ItemDescription();
            this.Estitem.ItemDescription = this.basec.ReplaceSingleQuote(this.WareItemDesc);
            this.Estitem.ModuleType = DeliveryCost_item.modulename;
            if (DeliveryCost_item.QueryType == "add" || this.frmcopyitem == "yes")
            {
                this.insertitems();
            }
            else if (DeliveryCost_item.QueryType == "edit" && this.frmcopyitem != "yes")
            {
                this.updateitems();
            }
            EstimatesBasePage.Estimate_DeliveryCost_insert(this.Estitem, ConnectionClass.IsHandy);
            EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            if (DeliveryCost_item.QueryType == "add")
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "T", false);
            }
            else if (DeliveryCost_item.QueryType == "edit")
            {
                if (this.Chk_ItemDescn.Checked)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "T", false);
                }
                if (this.IsProductCreated == 1)
                {
                    int num = 0;
                    if (this.chkPoduct1.Checked)
                    {
                        num = 1;
                    }
                    else if (this.chkPoduct2.Checked)
                    {
                        num = 2;
                    }
                    DataTable dataTable = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "T");
                    if (dataTable.Rows.Count > 0)
                    {
                        dataTable.Rows[0]["PricecatalogueID"].ToString();
                        if (num == 1 || num == 2)
                        {
                            EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "T", num);
                        }
                    }
                }
            }
            this.InsertTo_activity_History();
            if (DeliveryCost_item.QueryType == "add" && (string.Compare(DeliveryCost_item.modulename, "invoice", true) == 0 || string.Compare(DeliveryCost_item.modulename, "jobs", true) == 0))
            {
                JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "T");
                string empty = string.Empty;
                foreach (DataRow row in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty = row["StatusID"].ToString();
                }
                if (string.Compare(DeliveryCost_item.modulename, "jobs", true) == 0)
                {
                    this.objJava.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty), "job", this.EstimateItemID, (long)0);
                }
            }
            if (DeliveryCost_item.QueryType == "edit" && (string.Compare(DeliveryCost_item.modulename, "invoice", true) == 0 || string.Compare(DeliveryCost_item.modulename, "jobs", true) == 0))
            {
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "T");
            }
            if (DeliveryCost_item.modulename == "jobs")
            {
                string str = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                {
                    str = dataRow["PhraseText"].ToString();
                }
                foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                {
                    empty1 = row1["PhraseText"].ToString();
                }
                EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, str, empty1);
            }
            string str1 = string.Empty;
            if (DeliveryCost_item.modulename.ToLower() == "jobs")
            {
                str1 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, DeliveryCost_item.modulename);
            }
            else if (DeliveryCost_item.modulename.ToLower() == "invoice")
            {
                str1 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, DeliveryCost_item.modulename);
            }
            if (DeliveryCost_item.modulename == "orders")
            {
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            if (str1.ToLower() == "yes")
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            HttpResponse response1 = base.Response;
            object[] estimateID1 = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
            response1.Redirect(string.Concat(estimateID1));
        }

        public string gettaxvalue(string TaxID)
        {
            string[] strArrays = this.hdntaxvalue.Value.Split(new char[] { '±' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (strArrays[i] != "")
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                    if (strArrays1[0] == TaxID)
                    {
                        return strArrays1[2];
                    }
                }
            }
            return "0";
        }

        public string Insert_Warehouse_ItemDescription()
        {
            this.SetDefault_ItemDescription();
            DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "T");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (string.Compare(row["DatabaseFieldName"].ToString(), "ItemTitle", true) == 0)
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem = this;
                    object wareItemDesc = usercontrolItemQucikquoteItem.WareItemDesc;
                    object[] str = new object[] { wareItemDesc, "ItemTitle»", row["ScreenName"].ToString(), "»", this.txtitemtitle.Text.ToString(), "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem.WareItemDesc = string.Concat(str);
                }
                if (this.div_description.Visible && string.Compare(row["DatabaseFieldName"].ToString(), "Description", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem1 = this;
                    object obj = usercontrolItemQucikquoteItem1.WareItemDesc;
                    object[] objArray = new object[] { obj, "µDescription»", row["ScreenName"].ToString(), "»", this.txtdescription.Text.ToString(), "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem1.WareItemDesc = string.Concat(objArray);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Artwork", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem2 = this;
                    object wareItemDesc1 = usercontrolItemQucikquoteItem2.WareItemDesc;
                    object[] str1 = new object[] { wareItemDesc1, "µArtwork»", row["ScreenName"].ToString(), "»", this.itemartwork, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem2.WareItemDesc = string.Concat(str1);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Colour", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem3 = this;
                    object obj1 = usercontrolItemQucikquoteItem3.WareItemDesc;
                    object[] objArray1 = new object[] { obj1, "µColour»", row["ScreenName"].ToString(), "»", this.itemcolor, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem3.WareItemDesc = string.Concat(objArray1);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Size", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem4 = this;
                    object wareItemDesc2 = usercontrolItemQucikquoteItem4.WareItemDesc;
                    object[] str2 = new object[] { wareItemDesc2, "µSize»", row["ScreenName"].ToString(), "»", this.itemsize, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem4.WareItemDesc = string.Concat(str2);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Material", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem5 = this;
                    object obj2 = usercontrolItemQucikquoteItem5.WareItemDesc;
                    object[] objArray2 = new object[] { obj2, "µMaterial»", row["ScreenName"].ToString(), "»", this.itemmaterial, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem5.WareItemDesc = string.Concat(objArray2);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Delivery", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem6 = this;
                    object wareItemDesc3 = usercontrolItemQucikquoteItem6.WareItemDesc;
                    object[] str3 = new object[] { wareItemDesc3, "µDelivery»", row["ScreenName"].ToString(), "»", this.itemdelivery, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem6.WareItemDesc = string.Concat(str3);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Finishing", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem7 = this;
                    object obj3 = usercontrolItemQucikquoteItem7.WareItemDesc;
                    object[] objArray3 = new object[] { obj3, "µFinishing»", row["ScreenName"].ToString(), "»", this.itemfinishing, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem7.WareItemDesc = string.Concat(objArray3);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Proofs", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem8 = this;
                    object wareItemDesc4 = usercontrolItemQucikquoteItem8.WareItemDesc;
                    object[] str4 = new object[] { wareItemDesc4, "µProofs»", row["ScreenName"].ToString(), "»", this.itemproofs, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem8.WareItemDesc = string.Concat(str4);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Packing", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem9 = this;
                    object obj4 = usercontrolItemQucikquoteItem9.WareItemDesc;
                    object[] objArray4 = new object[] { obj4, "µPacking»", row["ScreenName"].ToString(), "»", this.itempacking, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem9.WareItemDesc = string.Concat(objArray4);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Notes", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    DeliveryCost_item usercontrolItemQucikquoteItem10 = this;
                    object wareItemDesc5 = usercontrolItemQucikquoteItem10.WareItemDesc;
                    object[] str5 = new object[] { wareItemDesc5, "µNotes»", row["ScreenName"].ToString(), "»", this.itemnotes, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemQucikquoteItem10.WareItemDesc = string.Concat(str5);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Instructions", true) != 0 || !Convert.ToBoolean(row["IsChecked"]))
                {
                    continue;
                }
                DeliveryCost_item usercontrolItemQucikquoteItem11 = this;
                object obj5 = usercontrolItemQucikquoteItem11.WareItemDesc;
                object[] objArray5 = new object[] { obj5, "µInstructions»", row["ScreenName"].ToString(), "»", this.itemterms, "»", Convert.ToBoolean(row["IsChecked"]) };
                usercontrolItemQucikquoteItem11.WareItemDesc = string.Concat(objArray5);
            }
            return this.WareItemDesc;
        }

        public void insertitems()
        {
            long num = (long)0;
            if (this.InvoiceID <= (long)0)
            {
                EstimatesItem estitem = this.Estitem;
                long num1 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "T", true, num);
                long num2 = num1;
                this.EstimateItemID = num1;
                estitem.EstimateItemID = num2;
            }
            else
            {
                EstimatesItem estimatesItem = this.Estitem;
                long num3 = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, "T", true, num);
                long num4 = num3;
                this.EstimateItemID = num3;
                estimatesItem.EstimateItemID = num4;
            }
            EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
            if (this.jobID > (long)0)
            {
                long estimateItemID = this.EstimateItemID;
                long num5 = this.jobID;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                JobBasePage.EstimateItems_ProgressToJob(estimateItemID, num5, false, Convert.ToDateTime(_commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
            }
            if (this.InvoiceID > (long)0)
            {
                InvoiceBasePage.EstimateItems_ProgressToInvoice(this.EstimateItemID, this.InvoiceID);
            }
            this.Estitem.CompanyID = this.CompanyID;
            this.Estitem.EstimateID = this.EstimateID;
            if (this.hid_QtyType.Value.ToLower() != "s")
            {
                this.Estitem.Quantity1 = (this.txtQuantity.Text == "" ? 0 : Convert.ToInt32(this.txtQuantity.Text.Replace(" ", "").Trim()));
                this.Estitem.Subtotal1 = (this.txtsubtotal.Text.Trim() == "NaN" ? new decimal(0) : Convert.ToDecimal(this.txtsubtotal.Text.Trim()));
                this.Estitem.CostPrice1 = (this.txtcost.Text.Trim() == "NaN" ? new decimal(0) : Convert.ToDecimal(this.txtcost.Text.Trim()));
            }
            else
            {
                this.Estitem.Quantity1 = (this.txtQuantity.Text == "" ? 0 : Convert.ToInt32(this.txtQuantity.Text.Trim()));
                this.Estitem.Subtotal1 = (this.txtsubtotal.Text.Trim() == "NaN" ? new decimal(0) : Convert.ToDecimal(this.txtsubtotal.Text.Trim()));
                this.Estitem.CostPrice1 = (this.txtcost.Text.Trim() == "NaN" ? new decimal(0) : Convert.ToDecimal(this.txtcost.Text.Trim()));
            }
            this.Estitem.ItemTitle = this.txtitemtitle.Text.ToString().Trim();
            EstimatesItem estitem1 = this.Estitem;
            string text = this.ddlprofitmargin.SelectedItem.Text;
            char[] chrArray = new char[] { '%' };
            estitem1.Profitmargin = Convert.ToDecimal(text.Split(chrArray)[0]);
            this.Estitem.Tax = Convert.ToDecimal(this.gettaxvalue(this.ddltax.SelectedValue.ToString()));
            this.Estitem.TaxID = Convert.ToInt32(this.ddltax.SelectedValue);
            this.Estitem.SellingPrice = Convert.ToDecimal(this.Estitem.Subtotal1) + Convert.ToDecimal(this.Estitem.Tax);
            this.Estitem.QuickQuoteID = (long)0;
            this.Estitem.Iscompleted = 1;
            EstimatesBasePage.estimate_item_details_insert(this.CompanyID, this.EstimateID, this.EstimateItemID, "T");
        }

        public void InsertTo_activity_History()
        {
            long num = (long)0;
            if (!DeliveryCost_item.modulename.Contains("job"))
            {
                num = (!DeliveryCost_item.modulename.Contains("invoice") ? this.EstimateID : this.InvoiceID);
            }
            else
            {
                num = this.jobID;
            }
            if (string.Compare(DeliveryCost_item.QueryType, "add", true) == 0)
            {
                string str = "DC";
                string str1 = "Delivery Cost Item";
                string empty = string.Empty;
                DataTable dataTable = Notes.select_item_Title_for_Activity_History(this.CompanyID, num, this.EstimateItemID, str);
                foreach (DataRow row in dataTable.Rows)
                {
                    empty = row["itemtitle"].ToString();
                }
                string empty1 = string.Empty;
                if (base.Request.Params["FromAddAnItem"] == null)
                {
                    string empty2 = string.Empty;
                    if (DeliveryCost_item.modulename == "estimates")
                    {
                        DataTable dataTable1 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, num, "", (long)0);
                        foreach (DataRow dataRow in dataTable1.Rows)
                        {
                            empty2 = dataRow["Estimatenumber"].ToString();
                        }
                        this.objnotes.Estimate_type = "Delivery Cost";
                        this.objnotes.Estimate_number = empty2;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                    }
                    else if (DeliveryCost_item.modulename == "jobs")
                    {
                        DataTable dataTable2 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, num, "job", (long)0);
                        foreach (DataRow row1 in dataTable2.Rows)
                        {
                            empty2 = row1["jobnumber"].ToString();
                        }
                        this.objnotes.Job_type = "Delivery Cost";
                        this.objnotes.ModuleName = "job";
                        this.objnotes.Job_number = empty2;
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDirCreate);
                    }
                    else if (DeliveryCost_item.modulename == "invoice")
                    {
                        DataTable dataTable3 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, num, "invoice", (long)0);
                        foreach (DataRow dataRow1 in dataTable3.Rows)
                        {
                            empty2 = dataRow1["invoicenumber"].ToString();
                        }
                        this.objnotes.Invoice_type = "Delivery Cost";
                        this.objnotes.Invoice_number = empty2;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvDirCreate);
                    }
                    else if (DeliveryCost_item.modulename == "orders")
                    {
                        DataTable dataTable4 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, num, "", (long)0);
                        foreach (DataRow row2 in dataTable4.Rows)
                        {
                            empty2 = row2["Estimatenumber"].ToString();
                        }
                        this.objnotes.Estimate_type = "Delivery Cost";
                        this.objnotes.Estimate_number = empty2;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                    }
                }
                else if (DeliveryCost_item.modulename == "estimates")
                {
                    this.objnotes.Item_title = empty;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                    this.objnotes.Estimate_type = "Delivery Cost";
                    foreach (DataRow dataRow2 in Notes.select_item_number_for_Activity_History(num, this.EstimateItemID, DeliveryCost_item.modulename).Rows)
                    {
                        empty1 = dataRow2["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = string.Concat("Item ", empty1);
                    this.objnotes.Estimate_type = str1;
                }
                else if (DeliveryCost_item.modulename == "jobs")
                {
                    this.objnotes.Item_title = empty;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                    this.objnotes.Job_type = "Delivery Cost";
                    foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(num, this.EstimateItemID, DeliveryCost_item.modulename).Rows)
                    {
                        empty1 = row3["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = string.Concat("Item ", empty1);
                    this.objnotes.Estimate_type = str1;
                }
                else if (DeliveryCost_item.modulename == "invoice")
                {
                    this.objnotes.Item_title = empty;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                    this.objnotes.Invoice_type = "Delivery Cost";
                    foreach (DataRow dataRow3 in Notes.select_item_number_for_Activity_History(num, this.EstimateItemID, DeliveryCost_item.modulename).Rows)
                    {
                        empty1 = dataRow3["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = string.Concat("Item ", empty1);
                    this.objnotes.Estimate_type = str1;
                }
                else if (DeliveryCost_item.modulename == "orders")
                {
                    this.objnotes.Item_title = empty;
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                    this.objnotes.Estimate_type = "Delivery Cost";
                    foreach (DataRow row4 in Notes.select_item_number_for_Activity_History(num, this.EstimateItemID, DeliveryCost_item.modulename).Rows)
                    {
                        empty1 = row4["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = string.Concat("Item ", empty1);
                    this.objnotes.Estimate_type = str1;
                }
            }
            else if (string.Compare(DeliveryCost_item.QueryType, "edit", true) == 0)
            {
                string str2 = string.Empty;
                if (DeliveryCost_item.modulename == "estimates")
                {
                    foreach (DataRow dataRow4 in Notes.select_item_number_for_Activity_History(num, this.EstimateItemID, DeliveryCost_item.modulename).Rows)
                    {
                        str2 = dataRow4["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = string.Concat("Item ", str2);
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                }
                else if (DeliveryCost_item.modulename == "jobs")
                {
                    foreach (DataRow row5 in Notes.select_item_number_for_Activity_History(num, this.EstimateItemID, DeliveryCost_item.modulename).Rows)
                    {
                        str2 = row5["rownumber"].ToString();
                    }
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Item_number = string.Concat("Item ", str2);
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                }
                else if (DeliveryCost_item.modulename == "invoice")
                {
                    foreach (DataRow dataRow5 in Notes.select_item_number_for_Activity_History(num, this.EstimateItemID, DeliveryCost_item.modulename).Rows)
                    {
                        str2 = dataRow5["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = string.Concat("Item ", str2);
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                }
                else if (DeliveryCost_item.modulename == "orders")
                {
                    foreach (DataRow row6 in Notes.select_item_number_for_Activity_History(num, this.EstimateItemID, DeliveryCost_item.modulename).Rows)
                    {
                        str2 = row6["rownumber"].ToString();
                    }
                    this.objnotes.Item_number = string.Concat("Item ", str2);
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdItemRerun);
                }
            }
            this.objnotes.ModuleID = num;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.objJava;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objnotes.ItemID = this.EstimateItemID;
            this.objN.NotesAdd(this.objnotes);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.label10.Text = this.objLanguage.GetLanguageConversion("Item_Title");
            this.label6.Text = this.objLanguage.GetLanguageConversion("Item_Description");
            this.label2.Text = this.objLanguage.GetLanguageConversion("Markup");
            this.label3.Text = this.objLanguage.GetLanguageConversion("Sub_Total");
            this.label4.Text = this.objLanguage.GetLanguageConversion("Tax");
            this.label5.Text = this.objLanguage.GetLanguageConversion("Selling_Price");
            this.btncancel.Text = this.objLanguage.GetLanguageConversion("Previous");
            this.btnprintemail.Text = this.objLanguage.GetLanguageConversion("Save_Print_Email");
            this.btnsave.Text = this.objLanguage.GetLanguageConversion("Finish");
            this.img_UpdateDescription.Title = this.objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate");
            this.txtQuantity.Attributes.Add("style", "text-align:right");
            this.txtsubtotal.Attributes.Add("style", "text-align:right");
            this.txtcost.Attributes.Add("style", "text-align:right");
            this.txtproftimarge.Attributes.Add("style", "text-align:right");
            this.txtsellingprice.Attributes.Add("style", "text-align:right");
            this.lbltax.Attributes.Add("style", "text-align:right");
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                DeliveryCost_item.modulename = "jobs";
                this.submodulename = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                DeliveryCost_item.modulename = "invoice";
                this.submodulename = "invoice";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                DeliveryCost_item.modulename = "estimates";
                this.submodulename = "estimate";
            }
            else
            {
                DeliveryCost_item.modulename = "orders";
                this.submodulename = "order";
            }
            if (base.Request.Params["type"] != null)
            {
                DeliveryCost_item.QueryType = base.Request.Params["type"].ToString().ToLower();
            }
            if (base.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            }
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            if (base.Request.Params["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (base.Request.Params["EstItemID"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            }
            if (base.Request.Params["MainType"] != null)
            {
                this.MainType = base.Request.Params["MainType"].ToString();
            }
            if (DeliveryCost_item.QueryType == "add")
            {
                DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "T");
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (string.Compare(row["DatabaseFieldName"].ToString(), "Description", true) != 0 || !Convert.ToBoolean(row["IsChecked"]))
                    {
                        continue;
                    }
                    this.div_description.Visible = true;
                    break;
                }
            }
            if (DeliveryCost_item.QueryType == "edit")
            {
                DataTable dataTable = new DataTable();
                string empty = string.Empty;
                dataTable = EstimatesBasePage.DeliveryCost_Description_Select(this.CompanyID, this.EstimateID, this.EstimateItemID);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    empty = string.Concat(dataRow["ItemDescription"].ToString(), 'µ');
                }
                char[] chrArray = new char[] { 'µ' };
                string str = empty.Split(chrArray)[1];
                char[] chrArray1 = new char[] { '»' };
                if (str.Split(chrArray1)[0].ToString() != "Description")
                {
                    this.div_description.Visible = false;
                }
                else
                {
                    this.div_description.Visible = true;
                }
            }
            if (!base.IsPostBack)
            {
                this.bindprofitmargin();
                if (DeliveryCost_item.modulename != "invoice")
                {
                    this.ProfitMariginPrice = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                    this.DB_TaxID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                }
                else
                {
                    this.ProfitMariginPrice = EstimatesBasePage.GetProfitMargin_InvoiceID(this.CompanyID, this.InvoiceID);
                    this.DB_TaxID = EstimatesBasePage.GetTaxID_InvoiceID(this.CompanyID, this.InvoiceID);
                }
                this.selectprofitmargin(this.ProfitMariginPrice);
                this.bindtax();
                this.selecttaxid(this.DB_TaxID);
                if (this.AccountingCode != "e")
                {
                    this.div_AccountCode.Visible = false;
                }
                else
                {
                    this.div_AccountCode.Visible = false;
                    SettingsBasePage.Bind_AccountingCodes(this.ddlAccountCode, this.CompanyID, "--- Select ---");
                }
            }
            if (DeliveryCost_item.modulename != "invoice")
            {
                DeliveryCost_item.taxrate = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
            }
            else
            {
                DeliveryCost_item.taxrate = EstimatesBasePage.GetTaxRate_InvoiceID(this.CompanyID, this.InvoiceID);
            }
            string str1 = EstimateBasePage.estimate_summary_tax_bind_3(this.CompanyID);
            this.hdntaxvalue.Value = str1;
            if (base.Request.Params["type"] != null && DeliveryCost_item.QueryType == "edit")
            {
                if (!base.IsPostBack)
                {
                    this.SelectDeliveryCostItems(this.EstimateItemID);
                    DropDownList dropDownList = this.ddlAccountCode;
                    int num = EstimateBasePage.DeliveryCost_AccountingCode_Select(this.EstimateItemID, this.CompanyID);
                    dropDownList.SelectedValue = num.ToString();
                }
                if (!base.IsPostBack)
                {
                    this.Div_ItemDescn.Visible = true;
                    foreach (DataRow row1 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                    {
                        if (row1["UpdateItemDescription"].ToString().ToLower() != "true")
                        {
                            this.Chk_ItemDescn.Checked = false;
                        }
                        else
                        {
                            this.Chk_ItemDescn.Checked = true;
                        }
                    }
                }
            }
            if (base.Request.Params["type"] != null && DeliveryCost_item.QueryType == "add" && !base.IsPostBack)
            {
                this.SetDefault_ItemDescription();
                foreach (DataRow dataRow1 in EstimatesBasePage.CopyesttitletoitemTitle(this.CompanyID, this.EstimateID).Rows)
                {
                    this.txtitemtitle.Text = this.objBase.SpecialDecode(dataRow1["EstimateTitle"].ToString());
                }
            }
            try
            {
                if (base.Request.Params["FromAddAnItem"] != null && !base.IsPostBack)
                {
                    this.txtitemtitle.Text = "";
                }
            }
            catch
            {
            }
            foreach (DataRow row2 in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
            {
                this.IsItemCompleted = Convert.ToInt16(row2["IsItemCompleted"].ToString());
                this.IsProductCreated = Convert.ToInt16(row2["IsProductCreated"].ToString());
            }
            if (this.IsProductCreated == 1)
            {
                this.Div_Productcatalogue.Visible = true;
            }
            if (base.Request.QueryString["frmcopyitem"] != null)
            {
                this.frmcopyitem = base.Request.QueryString["frmcopyitem"].ToString();
            }
            string str2 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "printoremail", this.Page.Request.Url.ToString());
            if (str2 == "0" || str2 == "2")
            {
                this.div_btnprint.Visible = false;
            }
            else
            {
                this.div_btnprint.Visible = true;
            }
            if (DeliveryCost_item.modulename == "estimates")
            {
                this.qtystyle = "margin-left:-15px;";
                return;
            }
            this.qtystyle = "margin-left:-10px;";
        }

        public void selectprofitmargin(decimal ProfitMariginPrice)
        {
            for (int i = 0; i < this.ddlprofitmargin.Items.Count; i++)
            {
                if (this.ddlprofitmargin.Items[i].Text.Trim() == string.Concat(Convert.ToInt32(ProfitMariginPrice).ToString().Trim(), "%"))
                {
                    this.ddlprofitmargin.SelectedIndex = i;
                    return;
                }
            }
        }

        public void SelectDeliveryCostItems(long estimateitemid)
        {
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            DataTable dataTable = this.objJava.Select_itemDescriptions((long)this.CompanyID, this.EstimateItemID);
            foreach (DataRow row in dataTable.Rows)
            {
                this.txtdescription.Text = this.objBase.SpecialDecode(row["DescriptionValue"].ToString());
            }
            foreach (DataRow dataRow in EstimatesBasePage.deliverycost_item_select(this.CompanyID, estimateitemid).Rows)
            {
                if (DeliveryCost_item.modulename.ToLower() == "estimates" || DeliveryCost_item.modulename.ToLower() == "orders")
                {
                    num = Convert.ToInt32(dataRow["Quantity1"]);
                    //num1 = Convert.ToInt32(dataRow["Quantity2"]);
                    //num2 = Convert.ToInt32(dataRow["Quantity3"]);
                    //num3 = Convert.ToInt32(dataRow["Quantity4"]);
                    this.txtitemtitle.Text = this.objBase.SpecialDecode(dataRow["ItemTitle"].ToString());
                    string[] strArrays = dataRow["ItemDescription"].ToString().Split(new char[] { 'µ' });
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        if (strArrays[i].ToString() != "")
                        {
                            string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                            strArrays1[3] = (strArrays1[3].ToString() == "True" ? "True" : "False");
                            if (string.Compare(strArrays1[0], "Description", true) == 0)
                            {
                                this.div_description.Visible = true;
                            }
                        }
                    }
                    if (num != 0)
                    {
                        this.txtQuantity.Text = num.ToString();
                        this.str_QtyType = "more";
                    }
                    if (num1 != 0)
                    {
                        //this.txtQuantity_2.Text = num1.ToString();
                        this.str_QtyType = "more";
                    }
                    if (num2 != 0)
                    {
                        //this.txtQuantity_3.Text = num2.ToString();
                        this.str_QtyType = "more";
                    }
                    if (num3 != 0)
                    {
                        //this.txtQuantity_4.Text = num3.ToString();
                        this.str_QtyType = "more";
                    }
                    if (DeliveryCost_item.modulename.ToLower() == "orders")
                    {
                        this.str_QtyType = "single";
                    }
                    this.txtcost.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CostPrice1"].ToString()), 0, "", false, false, false);
                    this.selectprofitmargin(Convert.ToDecimal(dataRow["Profitmargin"].ToString()));
                    this.txtproftimarge.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtcost.Text) * Convert.ToDecimal(dataRow["Profitmargin"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.txtsubtotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Subtotal1"].ToString()), 0, "", false, false, false);
                    this.lbltax.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtsubtotal.Text) * Convert.ToDecimal(dataRow["Tax"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.selecttaxid(Convert.ToInt32(dataRow["TaxID"].ToString()));
                    this.txtsellingprice.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtsubtotal.Text) + Convert.ToDecimal(this.lbltax.Text), 0, "", false, false, false);
                    this.EstimateQuickQuoteID = Convert.ToInt64(dataRow["DeliveryCostID"].ToString());
                    this.hid_quickquoteID.Value = dataRow["DeliveryCostID"].ToString();
                }
                else
                {
                    foreach (DataRow row1 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                    {
                        num4 = Convert.ToInt16(row1["QtyNumber"].ToString());
                    }
                    foreach (DataRow dataRow1 in JobsBasePage.job_qty_select_by_qtynumber(this.CompanyID, this.EstimateItemID).Rows)
                    {
                        num = Convert.ToInt32(dataRow1["Quantity"]);
                        this.txtQuantity.Text = num.ToString();
                        this.str_QtyType = "single";
                    }
                    this.txtitemtitle.Text = this.objBase.SpecialDecode(dataRow["ItemTitle"].ToString());
                    this.selectprofitmargin(Convert.ToDecimal(dataRow["Profitmargin"].ToString()));
                    if (num4 == 1)
                    {
                        this.txtcost.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CostPrice1"].ToString()), 0, "", false, false, false);
                        this.txtproftimarge.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtcost.Text) * Convert.ToDecimal(dataRow["Profitmargin"].ToString())) / new decimal(100), 0, "", false, false, false);
                        this.txtsubtotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Subtotal1"].ToString()), 0, "", false, false, false);
                        this.lbltax.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtsubtotal.Text) * Convert.ToDecimal(dataRow["Tax"].ToString())) / new decimal(100), 0, "", false, false, false);
                        this.txtsellingprice.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtsubtotal.Text) + Convert.ToDecimal(this.lbltax.Text), 0, "", false, false, false);
                    }
                    if (num4 == 2)
                    {
                        this.txtcost.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CostPrice2"].ToString()), 0, "", false, false, false);
                        this.txtproftimarge.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtcost.Text) * Convert.ToDecimal(dataRow["Profitmargin"].ToString())) / new decimal(100), 0, "", false, false, false);
                        this.txtsubtotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Subtotal2"].ToString()), 0, "", false, false, false);
                        this.lbltax.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtsubtotal.Text) * Convert.ToDecimal(dataRow["Tax"].ToString())) / new decimal(100), 0, "", false, false, false);
                        this.txtsellingprice.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtsubtotal.Text) + Convert.ToDecimal(this.lbltax.Text), 0, "", false, false, false);
                    }
                    if (num4 == 3)
                    {
                        this.txtcost.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CostPrice3"].ToString()), 0, "", false, false, false);
                        this.txtproftimarge.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtcost.Text) * Convert.ToDecimal(dataRow["Profitmargin"].ToString())) / new decimal(100), 0, "", false, false, false);
                        this.txtsubtotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Subtotal3"].ToString()), 0, "", false, false, false);
                        this.lbltax.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtsubtotal.Text) * Convert.ToDecimal(dataRow["Tax"].ToString())) / new decimal(100), 0, "", false, false, false);
                        this.txtsellingprice.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtsubtotal.Text) + Convert.ToDecimal(this.lbltax.Text), 0, "", false, false, false);
                    }
                    if (num4 == 4)
                    {
                        this.txtcost.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CostPrice4"].ToString()), 0, "", false, false, false);
                        this.txtproftimarge.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtcost.Text) * Convert.ToDecimal(dataRow["Profitmargin"].ToString())) / new decimal(100), 0, "", false, false, false);
                        this.txtsubtotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Subtotal4"].ToString()), 0, "", false, false, false);
                        this.lbltax.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtsubtotal.Text) * Convert.ToDecimal(dataRow["Tax"].ToString())) / new decimal(100), 0, "", false, false, false);
                        this.txtsellingprice.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtsubtotal.Text) + Convert.ToDecimal(this.lbltax.Text), 0, "", false, false, false);
                    }
                    this.selecttaxid(Convert.ToInt32(dataRow["TaxID"].ToString()));
                    this.EstimateQuickQuoteID = Convert.ToInt64(dataRow["QuickQuoteID"].ToString());
                    this.hid_quickquoteID.Value = dataRow["QuickQuoteID"].ToString();
                }
            }
        }

        public void selecttaxid(int DB_TaxID)
        {
            for (int i = 0; i < this.ddltax.Items.Count; i++)
            {
                if (this.ddltax.Items[i].Value == DB_TaxID.ToString())
                {
                    this.ddltax.SelectedIndex = i;
                    return;
                }
            }
        }

        public void SetDefault_ItemDescription()
        {
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_forestimate_select(this.CompanyID, "Estimate").Rows)
            {
                string str = row["PhraseType"].ToString();
                string str1 = row["PhraseText"].ToString();
                if (string.Compare(str, "Estimate Title", true) == 0)
                {
                    this.itemtitle = str1;
                }
                if (string.Compare(str, "Estimate Description", true) == 0)
                {
                    this.itemdesc = str1;
                    if (!base.IsPostBack && DeliveryCost_item.QueryType == "add")
                    {
                        this.txtdescription.Text = this.objBase.SpecialDecode(str1);
                    }
                }
                if (string.Compare(str, "Estimate Artwork", true) == 0)
                {
                    this.itemartwork = str1;
                }
                if (string.Compare(str, "Estimate Colour", true) == 0)
                {
                    this.itemcolor = str1;
                }
                if (string.Compare(str, "Estimate Size", true) == 0)
                {
                    this.itemsize = str1;
                }
                if (string.Compare(str, "Estimate Material", true) == 0)
                {
                    this.itemmaterial = str1;
                }
                if (string.Compare(str, "Estimate Delivery", true) == 0)
                {
                    this.itemdelivery = str1;
                }
                if (string.Compare(str, "Estimate Finishing", true) == 0)
                {
                    this.itemfinishing = str1;
                }
                if (string.Compare(str, "Estimate Notes", true) == 0)
                {
                    this.itemnotes = str1;
                }
                if (string.Compare(str, "Estimate Terms", true) == 0)
                {
                    this.itemterms = str1;
                }
                if (string.Compare(str, "Estimate Proofs", true) == 0)
                {
                    this.itemproofs = str1;
                }
                if (string.Compare(str, "Estimate Packing", true) != 0)
                {
                    continue;
                }
                this.itempacking = str1;
            }
        }

        private string Split_ItemDescription_forpurchaseorder(string strData)
        {
            string empty = string.Empty;
            if (strData.Length > 0)
            {
                string[] strArrays = strData.Split(new char[] { 'µ' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (i == 1 && strArrays[i] != "")
                    {
                        empty = this.strItemDesc(strArrays[i]);
                    }
                }
                if (empty != "")
                {
                    char[] chrArray = new char[] { ':' };
                    empty = empty.Split(chrArray)[1];
                }
            }
            return empty;
        }

        private string strItemDesc(string strArray_0)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                string[] strArrays = strArray_0.Split(new char[] { '»' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (i == 2 && strArrays[2].ToString() != "" && string.Compare(strArrays[3].ToString(), "true", true) == 0 && !string.IsNullOrEmpty(strArrays[2].ToString()))
                    {
                        stringBuilder.AppendFormat("{0}: {1} \n", strArrays[1].ToString(), strArrays[2].ToString());
                    }
                }
            }
            catch
            {
            }
            return stringBuilder.ToString();
        }

        public void updateitems()
        {
            this.Estitem.CompanyID = this.CompanyID;
            this.Estitem.EstimateID = this.EstimateID;
            this.Estitem.EstimateItemID = this.EstimateItemID;
            if (this.hid_QtyType.Value.ToLower() != "s")
            {
                this.Estitem.Quantity1 = (this.txtQuantity.Text == "" ? 0 : Convert.ToInt32(this.txtQuantity.Text.Trim()));
                this.Estitem.Subtotal1 = (this.txtsubtotal.Text.Trim() == "" ? new decimal(0) : Convert.ToDecimal(this.txtsubtotal.Text.Trim()));
                this.Estitem.CostPrice1 = (this.txtcost.Text.Trim() == "" ? new decimal(0) : Convert.ToDecimal(this.txtcost.Text.Trim()));
            }
            else
            {
                this.Estitem.Quantity1 = (this.txtQuantity.Text == "" ? 0 : Convert.ToInt32(this.txtQuantity.Text.Trim()));
                this.Estitem.Subtotal1 = (this.txtsubtotal.Text.Trim() == "" ? new decimal(0) : Convert.ToDecimal(this.txtsubtotal.Text.Trim()));
                this.Estitem.CostPrice1 = (this.txtcost.Text.Trim() == "" ? new decimal(0) : Convert.ToDecimal(this.txtcost.Text.Trim()));
            }
            this.Estitem.ItemTitle = this.txtitemtitle.Text.ToString().Trim();
            EstimatesItem estitem = this.Estitem;
            string text = this.ddlprofitmargin.SelectedItem.Text;
            char[] chrArray = new char[] { '%' };
            estitem.Profitmargin = Convert.ToDecimal(text.Split(chrArray)[0]);
            this.Estitem.Tax = Convert.ToDecimal(this.gettaxvalue(this.ddltax.SelectedValue.ToString()));
            this.Estitem.TaxID = Convert.ToInt32(this.ddltax.SelectedValue);
            this.Estitem.SellingPrice = Convert.ToDecimal(this.txtsellingprice.Text.ToString().Trim());
            this.Estitem.QuickQuoteID = Convert.ToInt64(this.hid_quickquoteID.Value);
            this.Estitem.Iscompleted = 1;
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            string str = string.Empty;
            dataTable = EstimatesBasePage.DeliveryCost_Description_Select(this.CompanyID, this.EstimateID, this.EstimateItemID);
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["ItemDescription"].ToString();
            }
            string[] strArrays = empty.Split(new char[] { 'µ' });
            string empty1 = string.Empty;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (strArrays[i].ToString() != "")
                {
                    string str1 = string.Empty;
                    string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                    if (strArrays1[0].ToString().ToLower() == "itemtitle")
                    {
                        string str2 = empty1;
                        string[] strArrays2 = new string[] { str2, strArrays1[0].ToString(), "»", strArrays1[1].ToString(), "»", this.txtitemtitle.Text.ToString(), "»", strArrays1[3].ToString(), "µ" };
                        empty1 = string.Concat(strArrays2);
                    }
                    if (strArrays1[0].ToString().ToLower() == "description")
                    {
                        string str3 = empty1;
                        string[] strArrays3 = new string[] { str3, strArrays1[0].ToString(), "»", strArrays1[1].ToString(), "»", this.txtdescription.Text.ToString(), "»", strArrays1[3].ToString(), "µ" };
                        empty1 = string.Concat(strArrays3);
                    }
                    if (strArrays1[0].ToString().ToLower() != "description" && strArrays1[0].ToString().ToLower() != "itemtitle")
                    {
                        string str4 = empty1;
                        string[] strArrays4 = new string[] { str4, strArrays1[0].ToString(), "»", strArrays1[1].ToString(), "»", strArrays1[2].ToString(), "»", strArrays1[3].ToString(), "µ" };
                        empty1 = string.Concat(strArrays4);
                    }
                }
            }
            this.Estitem.ItemDescription = this.basec.ReplaceSingleQuote(empty1);
            EstimatesBasePage.estimate_item_details_insert(this.CompanyID, this.EstimateID, this.EstimateItemID, "T");
            string empty2 = string.Empty;
            DataTable dataTable1 = EstimatesBasePage.Select_AccountingCode_For_Summary(this.CompanyID, this.EstimateItemID, "T", this.EstimateID);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                Convert.ToInt32(dataRow["AccountCodeID"]);
                dataRow["Description"].ToString();
            }
            EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "T");
        }


        protected void btsave_onclick_stay(object sender, EventArgs e)
        {
            this.WareItemDesc = this.Insert_Warehouse_ItemDescription();
            this.Estitem.ItemDescription = this.basec.ReplaceSingleQuote(this.WareItemDesc);
            this.Estitem.ModuleType = DeliveryCost_item.modulename;
            if (DeliveryCost_item.QueryType == "add" || this.frmcopyitem == "yes")
            {
                this.insertitems();
            }
            else if (DeliveryCost_item.QueryType == "edit" && this.frmcopyitem != "yes")
            {
                this.updateitems();
            }
            EstimatesBasePage.Estimate_DeliveryCost_insert(this.Estitem, ConnectionClass.IsHandy);
            EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            if (DeliveryCost_item.QueryType == "add")
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "T", false);
            }
            else if (DeliveryCost_item.QueryType == "edit")
            {
                if (this.Chk_ItemDescn.Checked)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "T", false);
                }
                if (this.IsProductCreated == 1)
                {
                    int num = 0;
                    if (this.chkPoduct1.Checked)
                    {
                        num = 1;
                    }
                    else if (this.chkPoduct2.Checked)
                    {
                        num = 2;
                    }
                    DataTable dataTable = EstimatesBasePage.select_Converted_Prodect(this.CompanyID, this.EstimateItemID, "T");
                    if (dataTable.Rows.Count > 0)
                    {
                        dataTable.Rows[0]["PricecatalogueID"].ToString();
                        if (num == 1 || num == 2)
                        {
                            EstimateCommonMethods.insert_UpdatePriceCatalogueQty(Convert.ToInt64(dataTable.Rows[0]["PricecatalogueID"].ToString()), this.EstimateID, this.EstimateItemID, "Q", num);
                        }
                    }
                }
            }
            this.InsertTo_activity_History();
            if (DeliveryCost_item.QueryType == "add" && (string.Compare(DeliveryCost_item.modulename, "invoice", true) == 0 || string.Compare(DeliveryCost_item.modulename, "jobs", true) == 0))
            {
                JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "T");
                string empty = string.Empty;
                foreach (DataRow row in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty = row["StatusID"].ToString();
                }
                if (string.Compare(DeliveryCost_item.modulename, "jobs", true) == 0)
                {
                    this.objJava.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty), "job", this.EstimateItemID, (long)0);
                }
            }
            if (DeliveryCost_item.QueryType == "edit" && (string.Compare(DeliveryCost_item.modulename, "invoice", true) == 0 || string.Compare(DeliveryCost_item.modulename, "jobs", true) == 0))
            {
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "T");
            }
            if (DeliveryCost_item.modulename == "jobs")
            {
                string str = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                {
                    str = dataRow["PhraseText"].ToString();
                }
                foreach (DataRow row1 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                {
                    empty1 = row1["PhraseText"].ToString();
                }
                EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, str, empty1);
            }
            string str1 = string.Empty;
            if (DeliveryCost_item.modulename.ToLower() == "jobs")
            {
                str1 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, DeliveryCost_item.modulename);
            }
            else if (DeliveryCost_item.modulename.ToLower() == "invoice")
            {
                str1 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, DeliveryCost_item.modulename);
            }
            //if (DeliveryCost_item.modulename == "orders")
            //{
            //    HttpResponse response = base.Response;
            //    object[] estimateID = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
            //    response.Redirect(string.Concat(estimateID));
            //    return;
            //}
            //if (str1.ToLower() == "yes")
            //{
            //    HttpResponse httpResponse = base.Response;
            //    object[] objArray = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID };
            //    httpResponse.Redirect(string.Concat(objArray));
            //    return;
            //}


            HttpResponse response1 = base.Response;
            object[] estimateID1 = new object[] { this.strSitepath, DeliveryCost_item.modulename, "/", this.submodulename, "_DeliveryCost.aspx?type=add&EstID=", this.EstimateID, "&jID=", this.jobID, "&InvID=", this.InvoiceID, "&FromAddAnItem=Y&maintype=add" };
            response1.Redirect(string.Concat(estimateID1));
        }

    }
}
