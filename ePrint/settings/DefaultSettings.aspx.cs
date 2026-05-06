using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.settings
{
    public partial class DefaultSettings : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected DropDownList ddlEstimateType;

        //protected TextBox txtValidFor;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator rfv_txtValidFor;

        //protected CheckBox chkEstimateArtwork;

        //protected TextBox txtDefaultEstimated;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator1;

        //protected HtmlGenericControl div_Default_Arkwork;

        //protected CheckBox chkEstimateProof;

        //protected TextBox txtEstimateProof;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator2;

        //protected HtmlGenericControl div_DefaultProof;

        //protected CheckBox chkEstimateApproval;

        //protected TextBox TxtEstimateApproval;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator3;

        //protected CheckBox chkEstimateProduction;

        //protected TextBox txtEstimateProduction;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator4;

        //protected CheckBox chkEstimateCompletion;

        //protected TextBox txtEstimatedCompletion;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator5;

        //protected CheckBox chkEstimateDelivery;

        //protected TextBox txtEstimateDelivery;

        //protected Sample.Web.UI.Compatibility.RequiredFieldValidator RequiredFieldValidator6;

        //protected DropDownList ddlWorkingFrom;

        //protected DropDownList ddlWorkingTo;

        //protected CheckBox chkDefaultPackPrice;

        //protected HtmlGenericControl divpriceforwholepack;

        //protected DropDownList ddlroundoff;

        //protected DropDownList ddlMarkuptype;

        //protected HtmlGenericControl divDefaultPaperSize;

        //protected DropDownList ddlPaperSize;

        //protected HtmlGenericControl divddlPaperSize;

        //protected CheckBox chkUpdateItemDescription;

        //protected HtmlGenericControl div_Digitalsingle;

        //protected CheckBox chkdigitalsingle;

        //protected CheckBox chkDigitalBooklet;

        //protected CheckBox chkDigitalPad;

        //protected HtmlGenericControl div_Digital_Booklet;

        //protected CheckBox chkOffsetSingle;

        //protected CheckBox chkOffsetBooklet;

        //protected CheckBox chkOffsetPad;

        //protected CheckBox chkOffsetNCR;

        //protected HtmlGenericControl div_Large_Format;

        //protected CheckBox chkLinear;

        //protected CheckBox chksqrmeter;

        //protected HtmlGenericControl divRoundoffnearest;

        //protected DropDownList ddlRoundoffnearest;

        //protected CheckBox chk_Highlight_selling_price;

        //protected CheckBox chkRoundLock;

        //protected HtmlGenericControl divRoundLock;

        //protected HtmlGenericControl divtdmargin;

        //protected CheckBox chk_isPORaise;

        //protected CheckBox chk_isDeliveryRaise;

        //protected CheckBox chkCombineSupplier;

        //protected HtmlGenericControl divDefaultProductCatalogue;

        //protected DropDownList ddlProductCatalogue;

        //protected HtmlGenericControl divddlProductCatalogue;

        //protected CheckBox chkProductAttachment;

        //protected CheckBox chkOrderApproval;

        //protected RadButton btnCancel;

        //protected Button btnSave;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private commonClass objJava = new commonClass();

        public BasePage objPage = new BasePage();

        public int CompanyID;

        public languageClass objlang = new languageClass();

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

        public DefaultSettings()
        {
        }

        protected void btnCancel_onClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            bool ispopup = false;
            bool issummary = false;

            if (this.rdNone.Checked)
            {
                ispopup = false;
                issummary = false;
            }
            else if (rdFromPopup.Checked)
            {
                ispopup = true;
                issummary = false;
            }
            else if (rdFromSummary.Checked)
            {
                ispopup = false;
                issummary = true;
            }

            SettingsBasePage.Price_For_Whole_Pack_Insert(this.CompanyID, this.chkDefaultPackPrice.Checked, this.ddlEstimateType.SelectedValue, Convert.ToInt32(this.ddlroundoff.SelectedItem.Value), this.ddlMarkuptype.SelectedValue, this.chk_isPORaise.Checked, this.chk_isDeliveryRaise.Checked, this.chkUpdateItemDescription.Checked, this.ddlWorkingFrom.SelectedValue, this.ddlWorkingTo.SelectedValue, this.ddlRoundoffnearest.SelectedValue, this.chkRoundLock.Checked, Convert.ToInt32(this.ddlPaperSize.SelectedValue), this.chkdigitalsingle.Checked, this.chkDigitalBooklet.Checked, this.chkDigitalPad.Checked, this.chkOffsetSingle.Checked, this.chkOffsetBooklet.Checked, this.chkOffsetPad.Checked, this.chkOffsetNCR.Checked, this.chkLinear.Checked, this.chksqrmeter.Checked, this.chkCombineSupplier.Checked, this.chk_Highlight_selling_price.Checked, Convert.ToChar(this.ddlProductCatalogue.SelectedValue.Trim()), this.chkProductAttachment.Checked, this.chkOrderApproval.Checked, issummary, this.chkCopyDescFieldsToSupplier.Checked, ispopup, this.chkSumCondensedView.Checked ,true, Convert.ToInt32(this.ddlPaymentMethod.SelectedValue), this.chkOutworkDescBoxesEnable.Checked, Convert.ToInt32(this.ddlCostingType.SelectedValue), this.chkAddDescHeadings.Checked,this.chk3DecimalPlaces.Checked, this.chkEnblePriority.Checked, this.ChkMandatoryReplenishments.Checked);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Your_Update_Was_Successful"), "msg-success", this.plhMessage);
        }

        public void EstimatesTypesfromDwebconfig()
        {
            int num = 1;
            if (ConnectionClass.SheetFedDigital != null)
            {
                this.ddlEstimateType.Items.Insert(num, ConnectionClass.SheetFedDigital);
                this.ddlEstimateType.Items[num].Value = "SheetFedDigital";
                num++;
            }
            if (ConnectionClass.LargeFormat != null)
            {
                this.ddlEstimateType.Items.Insert(num, ConnectionClass.LargeFormat);
                this.ddlEstimateType.Items[num].Value = "largeformat";
                num++;
            }
            if (ConnectionClass.PrintBroker != null)
            {
                this.ddlEstimateType.Items.Insert(num, ConnectionClass.PrintBroker);
                this.ddlEstimateType.Items[num].Value = "printbroker";
                num++;
            }
            if (ConnectionClass.Warehouse != null)
            {
                this.ddlEstimateType.Items.Insert(num, ConnectionClass.Warehouse);
                this.ddlEstimateType.Items[num].Value = "warehouse";
                num++;
            }
            if (ConnectionClass.OtherCosts != null)
            {
                this.ddlEstimateType.Items.Insert(num, ConnectionClass.OtherCosts);
                this.ddlEstimateType.Items[num].Value = "othercost";
                num++;
            }
            if (ConnectionClass.PriceCatalogue != null)
            {
                this.ddlEstimateType.Items.Insert(num, ConnectionClass.PriceCatalogue);
                this.ddlEstimateType.Items[num].Value = "pricecatalogue";
                num++;
            }
            if (ConnectionClass.SheetFedOffset != null)
            {
                this.ddlEstimateType.Items.Insert(num, ConnectionClass.SheetFedOffset);
                this.ddlEstimateType.Items[num].Value = "SheetFedOffset";
                num++;
            }
            if (ConnectionClass.QuickQuote != null)
            {
                this.ddlEstimateType.Items.Insert(num, ConnectionClass.QuickQuote);
                this.ddlEstimateType.Items[num].Value = "QuickQuote";
                num++;
            }
            if (ConnectionClass.DeliveryCost != null)
            {
                this.ddlEstimateType.Items.Insert(num, ConnectionClass.DeliveryCost);
                this.ddlEstimateType.Items[num].Value = "DeliveryCost";
                num++;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSave.Attributes.Add("onclick", "javascript:loadingimg('div_btnsave','div_btnsaveprocess');");
            this.btnCancel.Text = this.objlang.GetValueOnLang("Cancel");
            this.btnSave.Text = this.objlang.GetValueOnLang("Save");
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btnCancel','div_btnCancelprocess');");
            global.pageName = "setting";
            global.pgName = "";
            this.strImagepath = global.imagePath();
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Default_Settings")));
            base.Title = this.objLanguage.convert(global.pageTitle("Default Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Default_Settings");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.ddlEstimateType.Items[0].Text = string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---");
            this.ddlCostingType.Items[0].Text = string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---");
       
            this.ddlRoundoffnearest.Items[0].Text = this.objlang.GetLanguageConversion("None");
            this.ddlRoundoffnearest.Items[1].Text = this.objlang.GetLanguageConversion("Two_Decimal");
            this.ddlRoundoffnearest.Items[2].Text = this.objlang.GetLanguageConversion("Nearest_1");
            this.ddlRoundoffnearest.Items[3].Text = this.objlang.GetLanguageConversion("Nearest_5");
            this.ddlRoundoffnearest.Items[4].Text = this.objlang.GetLanguageConversion("Nearest_10");
            this.ddlRoundoffnearest.Items[5].Text = this.objlang.GetLanguageConversion("Nearest_50");
            this.ddlRoundoffnearest.Items[6].Text = this.objlang.GetLanguageConversion("Nearest_100");
            if (!base.IsPostBack)
            {
                this.EstimatesTypesfromDwebconfig();
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable1 = SettingsBasePage.settings_PaymentValue_select((long)this.CompanyID);
                this.ddlPaymentMethod.DataSource = dataTable1;
                this.ddlPaymentMethod.DataTextField = "PaymentModeValue";
                this.ddlPaymentMethod.DataValueField = "PaymentModeID";
                this.ddlPaymentMethod.DataBind();
                this.ddlPaymentMethod.Items.Insert(0, " ");
                this.ddlPaymentMethod.Items[0].Text = "--Select--";
                this.ddlPaymentMethod.Items[0].Value = "0";

                ListItem[] listItem = new ListItem[] { new ListItem("%", "1"), null };
                listItem[1] = new ListItem(this.objJava.GetCurrencyinRequiredFormate("", true) ?? "", "2");
                this.ddlMarkuptype.Items.AddRange(listItem);
                this.ddlMarkuptype.DataBind();
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    this.chkDefaultPackPrice.Checked = Convert.ToBoolean(row["DefaultPriceForWholePack"]);
                    this.ddlEstimateType.SelectedValue = row["DefaultEstimateType"].ToString();
                    this.ddlroundoff.SelectedValue = row["Roundoff"].ToString();
                    this.ddlMarkuptype.SelectedValue = row["OutworkMarkuptype"].ToString();
                    try
                    {
                       
                        base.SetDDLValue(this.ddlWorkingFrom, row["WorkingDaysFrom"].ToString());
                        base.SetDDLValue(this.ddlWorkingTo, row["WorkingDaysTo"].ToString());
                        base.SetDDLValue(this.ddlRoundoffnearest, row["Roundoffsubtotalvalue"].ToString());
                        base.SetDDLValue(this.ddlPaperSize, row["DefaultPaperSize"].ToString());
                        this.ddlProductCatalogue.SelectedValue = row["Productcatlg_ItemDisplay"].ToString().Trim();
                        this.ddlPaymentMethod.SelectedValue = row["InvoicePaymentMethod"].ToString();
                    }
                    catch
                    {
                    }
                    if (row["IsDefaultPORaise"].ToString() != "True")
                    {
                        this.chk_isPORaise.Checked = false;
                    }
                    else
                    {
                        this.chk_isPORaise.Checked = true;
                    }
                    if (row["IsDefaultDeliveryRaise"].ToString() != "True")
                    {
                        this.chk_isDeliveryRaise.Checked = false;
                    }
                    else
                    {
                        this.chk_isDeliveryRaise.Checked = true;
                    }
                    if (row["UpdateItemDescription"].ToString() != "True")
                    {
                        this.chkUpdateItemDescription.Checked = false;
                    }
                    else
                    {
                        this.chkUpdateItemDescription.Checked = true;
                    }
                  
                    if (!Convert.ToBoolean(row["IsRoundLock"]))
                    {
                        this.chkRoundLock.Checked = false;
                    }
                    else
                    {
                        this.chkRoundLock.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["ItemDescDigital_Single"]))
                    {
                        this.chkdigitalsingle.Checked = false;
                    }
                    else
                    {
                        this.chkdigitalsingle.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["ItemDescDigital_Booklet"]))
                    {
                        this.chkDigitalBooklet.Checked = false;
                    }
                    else
                    {
                        this.chkDigitalBooklet.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["ItemDescDigital_Pad"]))
                    {
                        this.chkDigitalPad.Checked = false;
                    }
                    else
                    {
                        this.chkDigitalPad.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["ItemDescOffset_Single"]))
                    {
                        this.chkOffsetSingle.Checked = false;
                    }
                    else
                    {
                        this.chkOffsetSingle.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["ItemDescOffset_Booklet"]))
                    {
                        this.chkOffsetBooklet.Checked = false;
                    }
                    else
                    {
                        this.chkOffsetBooklet.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["ItemDescOffset_Pad"]))
                    {
                        this.chkOffsetPad.Checked = false;
                    }
                    else
                    {
                        this.chkOffsetPad.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["ItemDescOffset_NCR"]))
                    {
                        this.chkOffsetNCR.Checked = false;
                    }
                    else
                    {
                        this.chkOffsetNCR.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["ItemDescLinear"]))
                    {
                        this.chkLinear.Checked = false;
                    }
                    else
                    {
                        this.chkLinear.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["ItemDescSquare_Meter"]))
                    {
                        this.chksqrmeter.Checked = false;
                    }
                    else
                    {
                        this.chksqrmeter.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsCombineItemfor_SameSupplier"]))
                    {
                        this.chkCombineSupplier.Checked = false;
                    }
                    else
                    {
                        this.chkCombineSupplier.Checked = true;
                    }

                  var check=  row["chkIsAddDescHeadings"] != DBNull.Value
                                     ? Convert.ToBoolean(row["chkIsAddDescHeadings"])
                                     : false;
                    if (!check)
                    {
                        this.chkAddDescHeadings.Checked = false;
                    }
                    else
                    {
                        this.chkAddDescHeadings.Checked = true;
                    }


                    var decimal3ForPaperSize = row["Decimal3ForPaperSizes"] != DBNull.Value
                                    ? Convert.ToBoolean(row["Decimal3ForPaperSizes"])
                                    : false;
                    if (decimal3ForPaperSize)
                    {
                        this.chk3DecimalPlaces.Checked = true;
                    }
                    else
                    {
                        this.chk3DecimalPlaces.Checked = false;
                    }

                    var MandatoryReplenishments = row["MandatoryReplenishments"] != DBNull.Value
                                    ? Convert.ToBoolean(row["MandatoryReplenishments"])
                                    : false;

                    if (MandatoryReplenishments)
                    {
                        this.ChkMandatoryReplenishments.Checked = true;
                    }
                    else
                    {
                        this.ChkMandatoryReplenishments.Checked = false;
                    }



                    if (!Convert.ToBoolean(row["AllowPrintReadyFile"]))
                    {
                        this.chkProductAttachment.Checked = false;
                    }
                    else
                    {
                        this.chkProductAttachment.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["AllowUnApprovedOrder"]))
                    {
                        this.chkOrderApproval.Checked = false;
                    }
                    else
                    {
                        this.chkOrderApproval.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["chkSumCondensedView"]))
                    {
                        this.chkSumCondensedView.Checked = false;
                    }
                    else
                    {
                        this.chkSumCondensedView.Checked = true;
                    }

                    if (!Convert.ToBoolean(row["chkEnblePriority"]))
                    {
                        this.chkEnblePriority.Checked = false;
                    }
                    else
                    {
                        this.chkEnblePriority.Checked = true;
                    }


                    if (!Convert.ToBoolean(row["AllowSorting"]) && !Convert.ToBoolean(row["AllowSortingPopup"]))
                    {
                        this.rdFromSummary.Checked = false;
                        this.rdFromPopup.Checked = false;
                        this.rdNone.Checked = true;
                    }
                    else if(Convert.ToBoolean(row["AllowSorting"]))
                    {
                        this.rdNone.Checked = false;
                        this.rdFromSummary.Checked = true;
                        this.rdFromPopup.Checked = false;
                    }
                    else if (Convert.ToBoolean(row["AllowSortingPopup"]))
                    {
                        this.rdNone.Checked = false;
                        this.rdFromSummary.Checked = false;
                        this.rdFromPopup.Checked = true;
                    }


                    if (!Convert.ToBoolean(row["CopyOutworkDescFieldsToSupplier"]))
                    {
                        this.chkCopyDescFieldsToSupplier.Checked = false;
                    }
                    else
                    {
                        this.chkCopyDescFieldsToSupplier.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["DontTickDescbox"]))
                    {
                        this.chkOutworkDescBoxesEnable.Checked = false;
                    }
                    else
                    {
                        this.chkOutworkDescBoxesEnable.Checked = true;
                    }
                }
                foreach (DataRow dataRow in SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows)
                {
                    this.chk_Highlight_selling_price.Checked = Convert.ToBoolean(dataRow["IsTotalHighlighted"].ToString());
                }
            }
            if (ConnectionClass.LargeFormat != null || ConnectionClass.SheetFedOffset != null || ConnectionClass.SheetFedDigital != null)
            {
                this.divpriceforwholepack.Attributes.Add("style", " display:block");
            }
            bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
            if (!ConnectionClass.Is_Non_Printing_System)
            {
                this.divpriceforwholepack.Attributes.Add("style", " display:block");
          
            }
            else
            {
                this.divpriceforwholepack.Attributes.Add("style", " display:none");
                
            }
            this.divRoundoffnearest.Attributes.Add("style", "width: 200px;");
            this.divRoundLock.Attributes.Add("style", "margin-left: -3px");
            this.divtdmargin.Attributes.Add("style", "margin-left: -3px");
            this.divDefaultPaperSize.Attributes.Add("style", "width: 200px;height: 14px");
            this.divddlPaperSize.Attributes.Add("style", "margin-top: -2px");
        }
    }
}
