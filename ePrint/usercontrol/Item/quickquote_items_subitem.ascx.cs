using nmsConnectionClass;
using nmsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using nmsLanguage;
using System.Data;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using System.Collections;
using Printcenter.UI.Setting;
using Printcenter.UI.Jobs;
using Printcenter.UI.Invoices;

namespace ePrint.usercontrol.Item
{
    public partial class quickquote_items_subitem : UsercontrolBasePage
    {
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
        //public quickquote_items_subitem()
        //{
        //    this.Load += Page_Load;
        //}
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
        public void bindprofitmargin()
        {
            decimal num = new decimal(0);
            num = (qucikquote_item.modulename != "invoice" ? EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID) : EstimatesBasePage.GetProfitMargin_InvoiceID(this.CompanyID, this.InvoiceID));
            num = Convert.ToDecimal(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num), 0, "", false, false, true));
            ArrayList arrayLists = new ArrayList();
            for (decimal i = new decimal(-20); i < new decimal(105); i = i + new decimal(5))
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
        protected void btnsave_OnClick(object sender, EventArgs e)
        {

        }
        public void SelectQuickQuoteItems(long estimateitemid)
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
            foreach (DataRow dataRow in EstimatesBasePage.quickquote_item_select(this.CompanyID, estimateitemid).Rows)
            {
                if (qucikquote_item.modulename.ToLower() == "estimates" || qucikquote_item.modulename.ToLower() == "orders")
                {
                    num = Convert.ToInt32(dataRow["Quantity1"]);
                    num1 = Convert.ToInt32(dataRow["Quantity2"]);
                    num2 = Convert.ToInt32(dataRow["Quantity3"]);
                    num3 = Convert.ToInt32(dataRow["Quantity4"]);
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
                        this.txtQuantity_2.Text = num1.ToString();
                        this.str_QtyType = "more";
                    }
                    if (num2 != 0)
                    {
                        this.txtQuantity_3.Text = num2.ToString();
                        this.str_QtyType = "more";
                    }
                    if (num3 != 0)
                    {
                        this.txtQuantity_4.Text = num3.ToString();
                        this.str_QtyType = "more";
                    }
                    if (qucikquote_item.modulename.ToLower() == "orders")
                    {
                        this.str_QtyType = "single";
                    }
                    this.txtcost.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CostPrice1"].ToString()), 0, "", false, false, false);
                    this.txtcost1.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CostPrice2"].ToString()), 0, "", false, false, false);
                    this.txtcost2.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CostPrice3"].ToString()), 0, "", false, false, false);
                    this.txtcost3.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["CostPrice4"].ToString()), 0, "", false, false, false);
                    this.selectprofitmargin(Convert.ToDecimal(dataRow["Profitmargin"].ToString()));
                    this.txtproftimarge.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtcost.Text) * Convert.ToDecimal(dataRow["Profitmargin"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.txtproftimarge1.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtcost1.Text) * Convert.ToDecimal(dataRow["Profitmargin"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.txtproftimarge2.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtcost2.Text) * Convert.ToDecimal(dataRow["Profitmargin"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.txtproftimarge3.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtcost3.Text) * Convert.ToDecimal(dataRow["Profitmargin"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.txtsubtotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Subtotal1"].ToString()), 0, "", false, false, false);
                    this.txtsubtotal1.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Subtotal2"].ToString()), 0, "", false, false, false);
                    this.txtsubtotal2.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Subtotal3"].ToString()), 0, "", false, false, false);
                    this.txtsubtotal3.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Subtotal4"].ToString()), 0, "", false, false, false);
                    this.lbltax.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtsubtotal.Text) * Convert.ToDecimal(dataRow["Tax"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.lbltax1.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtsubtotal1.Text) * Convert.ToDecimal(dataRow["Tax"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.lbltax2.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtsubtotal2.Text) * Convert.ToDecimal(dataRow["Tax"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.lbltax3.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, (Convert.ToDecimal(this.txtsubtotal3.Text) * Convert.ToDecimal(dataRow["Tax"].ToString())) / new decimal(100), 0, "", false, false, false);
                    this.selecttaxid(Convert.ToInt32(dataRow["TaxID"].ToString()));
                    this.txtsellingprice.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtsubtotal.Text) + Convert.ToDecimal(this.lbltax.Text), 0, "", false, false, false);
                    this.txtsellingprice1.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtsubtotal1.Text) + Convert.ToDecimal(this.lbltax1.Text), 0, "", false, false, false);
                    this.txtsellingprice2.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtsubtotal2.Text) + Convert.ToDecimal(this.lbltax2.Text), 0, "", false, false, false);
                    this.txtsellingprice3.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtsubtotal3.Text) + Convert.ToDecimal(this.lbltax3.Text), 0, "", false, false, false);
                    this.EstimateQuickQuoteID = Convert.ToInt64(dataRow["QuickQuoteID"].ToString());
                    this.hid_quickquoteID.Value = dataRow["QuickQuoteID"].ToString();
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
                    if (!base.IsPostBack && qucikquote_item.QueryType == "add")
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

        protected void btnprevious_onclick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (qucikquote_item.modulename.ToLower() == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, qucikquote_item.modulename);
            }
            else if (qucikquote_item.modulename.ToLower() == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, qucikquote_item.modulename);
            }
            if (qucikquote_item.QueryType != "add")
            {
                if (qucikquote_item.QueryType == "edit" && base.Request.Params["frm"] != null && base.Request.Params["frm"] == "sum")
                {
                    if (qucikquote_item.modulename == "orders")
                    {
                        HttpResponse response = base.Response;
                        object[] estimateID = new object[] { this.strSitepath, qucikquote_item.modulename, "/", this.submodulename, "_summary.aspx?frm=view&ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                        response.Redirect(string.Concat(estimateID));
                        return;
                    }
                    if (empty.ToLower() == "yes")
                    {
                        HttpResponse httpResponse = base.Response;
                        object[] objArray = new object[] { this.strSitepath, qucikquote_item.modulename, "/", this.submodulename, "_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID };
                        httpResponse.Redirect(string.Concat(objArray));
                        return;
                    }
                    HttpResponse response1 = base.Response;
                    object[] estimateID1 = new object[] { this.strSitepath, qucikquote_item.modulename, "/", this.submodulename, "_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID };
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
                object[] objArray1 = new object[] { this.strSitepath, qucikquote_item.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=Q&From=F", this.jID, this.InvID };
                httpResponse1.Redirect(string.Concat(objArray1));
                return;
            }
            if (qucikquote_item.modulename == "orders")
            {
                HttpResponse response2 = base.Response;
                object[] estimateID2 = new object[] { this.strSitepath, qucikquote_item.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                response2.Redirect(string.Concat(estimateID2));
                return;
            }
            if (empty.ToLower() == "yes")
            {
                HttpResponse httpResponse2 = base.Response;
                object[] objArray2 = new object[] { this.strSitepath, qucikquote_item.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                httpResponse2.Redirect(string.Concat(objArray2));
                return;
            }
            HttpResponse response3 = base.Response;
            object[] estimateID3 = new object[] { this.strSitepath, qucikquote_item.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
            response3.Redirect(string.Concat(estimateID3));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.label10.Text = this.objLanguage.GetLanguageConversion("Item_Title");
            this.label6.Text = this.objLanguage.GetLanguageConversion("Item_Description");
            this.label2.Text = this.objLanguage.GetLanguageConversion("Profit_Margin");
            this.label3.Text = this.objLanguage.GetLanguageConversion("Sub_Total");
            this.label4.Text = this.objLanguage.GetLanguageConversion("Tax");
            this.label5.Text = this.objLanguage.GetLanguageConversion("Selling_Price");
            this.btncancel.Text = this.objLanguage.GetLanguageConversion("Previous");
            this.btnprintemail.Text = this.objLanguage.GetLanguageConversion("Save_Print_Email");
            //this.btnsave.Text = this.objLanguage.GetLanguageConversion("Finish");
            this.img_UpdateDescription.Title = this.objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate");
            this.txtQuantity.Attributes.Add("style", "text-align:right");
            this.txtQuantity_2.Attributes.Add("style", "text-align:right");
            this.txtQuantity_3.Attributes.Add("style", "text-align:right");
            this.txtQuantity_4.Attributes.Add("style", "text-align:right");
            this.txtsubtotal.Attributes.Add("style", "text-align:right");
            this.txtsubtotal1.Attributes.Add("style", "text-align:right");
            this.txtsubtotal2.Attributes.Add("style", "text-align:right");
            this.txtsubtotal3.Attributes.Add("style", "text-align:right");
            this.txtcost.Attributes.Add("style", "text-align:right");
            this.txtcost1.Attributes.Add("style", "text-align:right");
            this.txtcost2.Attributes.Add("style", "text-align:right");
            this.txtcost3.Attributes.Add("style", "text-align:right");
            this.txtproftimarge.Attributes.Add("style", "text-align:right");
            this.txtproftimarge1.Attributes.Add("style", "text-align:right");
            this.txtproftimarge2.Attributes.Add("style", "text-align:right");
            this.txtproftimarge3.Attributes.Add("style", "text-align:right");
            this.txtsellingprice.Attributes.Add("style", "text-align:right");
            this.txtsellingprice1.Attributes.Add("style", "text-align:right");
            this.txtsellingprice2.Attributes.Add("style", "text-align:right");
            this.txtsellingprice3.Attributes.Add("style", "text-align:right");
            this.lbltax.Attributes.Add("style", "text-align:right");
            this.lbltax1.Attributes.Add("style", "text-align:right");
            this.lbltax2.Attributes.Add("style", "text-align:right");
            this.lbltax3.Attributes.Add("style", "text-align:right");
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                qucikquote_item.modulename = "jobs";
                this.submodulename = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                qucikquote_item.modulename = "invoice";
                this.submodulename = "invoice";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                qucikquote_item.modulename = "estimates";
                this.submodulename = "estimate";
            }
            else
            {
                qucikquote_item.modulename = "orders";
                this.submodulename = "order";
            }
            if (base.Request.Params["type"] != null)
            {
                qucikquote_item.QueryType = base.Request.Params["type"].ToString().ToLower();
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
            if (qucikquote_item.QueryType == "add")
            {
                DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "Q");
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
            if (qucikquote_item.QueryType == "edit")
            {
                DataTable dataTable = new DataTable();
                string empty = string.Empty;
                dataTable = EstimatesBasePage.QuickQuote_Description_Select(this.CompanyID, this.EstimateID, this.EstimateItemID);
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
                if (qucikquote_item.modulename != "invoice")
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
            if (qucikquote_item.modulename != "invoice")
            {
                qucikquote_item.taxrate = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
            }
            else
            {
                qucikquote_item.taxrate = EstimatesBasePage.GetTaxRate_InvoiceID(this.CompanyID, this.InvoiceID);
            }
            string str1 = EstimateBasePage.estimate_summary_tax_bind_3(this.CompanyID);
            this.hdntaxvalue.Value = str1;
            if (base.Request.Params["type"] != null && qucikquote_item.QueryType == "edit")
            {
                if (!base.IsPostBack)
                {
                    this.SelectQuickQuoteItems(this.EstimateItemID);
                    DropDownList dropDownList = this.ddlAccountCode;
                    int num = EstimateBasePage.QuickQuote_AccountingCode_Select(this.EstimateItemID, this.CompanyID);
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
            if (base.Request.Params["type"] != null && qucikquote_item.QueryType == "add" && !base.IsPostBack)
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
            string str2 = string.Empty;
            str2 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "printoremail", this.Page.Request.Url.ToString());
            if (str2 == "0" || str2 == "2")
            {
                this.div_btnprint.Visible = false;
            }
            else
            {
                this.div_btnprint.Visible = true;
            }
            if (qucikquote_item.modulename == "estimates")
            {
                this.qtystyle = "margin-left:-15px;";
                return;
            }
            this.qtystyle = "margin-left:-10px;";
        }
    }
}