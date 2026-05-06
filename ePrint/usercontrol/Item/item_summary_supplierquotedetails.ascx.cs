using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_summary_supplierquotedetails : UsercontrolBasePage
    {
        //protected UpdateProgress upProgress;

        //protected PlaceHolder plhQuoteDetails;

        //protected HiddenField hdnQuoteSave;

        //protected HiddenField hdnEstimateitemID;

        //protected HiddenField hdnQuoteSave_Est;

        //protected HiddenField hdnQuoteSave_EstOnly;

        //protected HiddenField hdnSupplierAddMore;

        //protected HiddenField hdnSupplierAddMore_EstID;

        //protected HiddenField hdn_btnProcess;

        //protected UpdatePanel UpdatePanel1;

        public languageClass objLanguage = new languageClass();

        private commonClass commclass = new commonClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        private BaseClass objBC = new BaseClass();

        public long EstimateID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string Module = string.Empty;

        private Global gloobj = new Global();

        public int roundoff = 2;

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

        public item_summary_supplierquotedetails()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Params["estid"] != null && base.Request.Params["estid"] != "")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            if (base.Request.Params["Module"] != null)
            {
                this.Module = base.Request.Params["Module"];
            }
            
            this.roundoff = GetRoundOffValue();


        }
        int GetRoundOffValue()
        {

            int roundOffValue = 0;
            try
            {
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    roundOffValue = Convert.ToInt32(row["Roundoff"].ToString());
                }
            }
            catch
            {
            }
            return roundOffValue;
        }
        public void QuoteDetails_Bind(long id, string Name, string IDs)
        {
            decimal num;
            string[] str;
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Params["estid"] != null && base.Request.Params["estid"] != "")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            if (base.Request.Params["Module"] != null)
            {
                this.Module = base.Request.Params["Module"];
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(id);
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            dataSet = EstimateBasePage.Supplier_QuoteAccepted_Details(id);
            dataTable = dataSet.Tables[0];
            string empty = string.Empty;
            string costingtype = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                empty = string.Concat(empty, row["SupplierID"].ToString(), ",");
                costingtype = row["CostingType"].ToString();
            }
            if (empty != "")
            {
                empty = empty.Remove(empty.Length - 1);
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<div align='center' style='width:100%;margin-top:5px'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<h4><a style='border-bottom-width:0px' href='#'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%' >"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td width='100%'>"));
                ControlCollection controls = this.plhQuoteDetails.Controls;
                object[] name = new object[] { "<b style='float:left;'>&nbsp;&nbsp;&nbsp;&nbsp;", Name, "</b><span style='float:left;margin-left:25px;' class='AddmoreSup' onclick=\"javascript:window.radopen('", this.strSitepath, "common/common_popup.aspx?type=supplier_addmore&EstimateItemID=", id, "&estid=", this.EstimateID, "&Module=", this.Module, "',1000,500).setSize(600, 450);window.radopen('", this.strSitepath, "common/common_popup.aspx?type=supplier_addmore&EstimateItemID=", id, "&estid=", this.EstimateID, "&Module=", this.Module, "',1000,500).moveTo(350,110).center();SetRadWindow('divrad', 'divBackGroundNew', '200');\" title='", this.objLanguage.GetLanguageConversion("Add_More_Supplier"), "'></span><span style='float:right;margin-right:10px;background-image: url(../images/refresh.gif);background-repeat: no-repeat;height: 15px;width: 15px;cursor: pointer;display: block;border: 0px;background-color: transparent;' onclick=javascript:Redirect_Q(", this.EstimateID, ",", id, "); title='", this.objLanguage.GetLanguageConversion("Refresh"), "'></span>" };
                controls.Add(new LiteralControl(string.Concat(name)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</table>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</a></h4>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<div align='center' style='padding:5px;margin:0px;'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<div align='center' style='width:99.5%'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<table align='center' style='width:100%'  cellpadding='3' cellspacing='0' border='0'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr class='Header_new_style'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:11%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; border-left: 1px solid #AAAAAA;' class='LeftCorner_rounded'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Supp_Quote"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:15%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;' >"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Supplier"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:7%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; ' >"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Quantity"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; ' >"));
                if (costingtype == "S")
                {
                    this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Cost_tax"), "</b></span>")));
                } 
                else if(costingtype == "U")
                {
                    this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Cost_Unit"), "</b></span>")));
                }
                else if (costingtype == "P")
                {
                    this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Cost_per_1000"), "</b></span>")));
                }
                else
                {
                    this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Cost"), "</b></span>")));
                }
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:9%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;' >"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Delivery_Date"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:6%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; ' >"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Delivery_Included"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; ' >"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Delivery_Cost"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td  style='width:5%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; '>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("MarkUp_Type"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td  style='width:6.5%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; '>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("MarkUp_Value"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td  style='width:7%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; '>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Total_Price"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td  style='width:14.5%; text-align:center; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; '>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Status"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:12%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; ' >"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Comments"), "</b></span>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:15%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; border-right: 1px solid #AAAAAA;' class='RightCorner_rounded'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Select_Price"), "</b></span>")));
                ControlCollection controlCollections = this.plhQuoteDetails.Controls;
                object[] objArray = new object[] { "<div class='Display_None'><input style='width:90%;text-align:right' id='SupplierCount_", id, "' type='text' value='", dataTable.Rows.Count, "' ></div>" };
                controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string str1 = base.Session["Dateformat"].ToString();
                    long num1 = Convert.ToInt64(dataRow["SupplierID"].ToString());
                    long num2 = Convert.ToInt64(dataRow["Estoutworkid"].ToString());
                    string lower = dataRow["IsRejected"].ToString().ToLower();
                    DataTable dataTable1 = EstimatesBasePage.EstimateHistory(num1, id);
                    DataTable dataTable2 = EstimatesBasePage.SentForQuoteStatus_SupQuoteDet(num1, num2, 1);
                    DataTable dataTable3 = EstimatesBasePage.SentForQuoteStatus_SupQuoteDet(num1, num2, 2);
                    DataTable dataTable4 = EstimatesBasePage.SentForQuoteStatus_SupQuoteDet(num1, num2, 3);
                    DataTable dataTable5 = EstimatesBasePage.SentForQuoteStatus_SupQuoteDet(num1, num2, 4);
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<td align='center' colspan='13'>"));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<span></span>"));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr style='width:100%;'>"));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controls1 = this.plhQuoteDetails.Controls;
                    object[] objArray1 = new object[] { "<input id='txtSupplierNum_", num1, "_", id, "' style='width:90%;text-align:right;' value='", dataRow["SupplierRefNo"].ToString(), "'></input>" };
                    controls1.Add(new LiteralControl(string.Concat(objArray1)));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controlCollections1 = this.plhQuoteDetails.Controls;
                    object[] objArray2 = new object[] { "<span><label id='lblSupplierName_", num1, "_", id, "' style='cursor: text;' value='", this.objBase.SpecialDecode(dataRow["SupplierName"].ToString()), "'>", this.objBase.SpecialDecode(dataRow["SupplierName"].ToString()), "</label></span>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(objArray2)));
                    ControlCollection controls2 = this.plhQuoteDetails.Controls;
                    object[] objArray3 = new object[] { "<input id='lblKeyCode_", num1, "_", id, "' style='display:none' value='", dataRow["KeyCode"].ToString(), "'></input>" };
                    controls2.Add(new LiteralControl(string.Concat(objArray3)));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                    this.SFQ_Details(dataTable2, dataTable3, dataTable4, dataTable5, num1, empty, id, lower);
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:12%;'>"));
                    ControlCollection controlCollections2 = this.plhQuoteDetails.Controls;
                    object[] objArray4 = new object[] { "<textarea id='txtComment_", num1, "_", id, "' style='height:80px; width:200px;'>", dataRow["Comments"].ToString(), "</textarea>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(objArray4)));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<td align='center'>"));
                    if (dataTable2.Rows.Count <= 0)
                    {
                        ControlCollection controls3 = this.plhQuoteDetails.Controls;
                        object[] objArray5 = new object[] { "<div class='Display_None'><input id='ChkSupplier_", num1, "_", id, "_1' type='checkbox' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','1','", num1, "','", id, "');></div>" };
                        controls3.Add(new LiteralControl(string.Concat(objArray5)));
                    }
                    else if (dataTable2.Rows[0]["IsSelected"].ToString().ToLower() != "true")
                    {
                        ControlCollection controlCollections3 = this.plhQuoteDetails.Controls;
                        object[] objArray6 = new object[] { "<div style='padding:2px 0px 2px 0px'><input id='ChkSupplier_", num1, "_", id, "_1' type='checkbox' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','1','", num1, "','", id, "');></div>" };
                        controlCollections3.Add(new LiteralControl(string.Concat(objArray6)));
                    }
                    else
                    {
                        ControlCollection controls4 = this.plhQuoteDetails.Controls;
                        object[] objArray7 = new object[] { "<div style='padding:2px 0px 2px 0px'><input id='ChkSupplier_", num1, "_", id, "_1' type='checkbox' checked='checked' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','1','", num1, "','", id, "');></div>" };
                        controls4.Add(new LiteralControl(string.Concat(objArray7)));
                    }
                    if (dataTable3.Rows.Count <= 0)
                    {
                        ControlCollection controlCollections4 = this.plhQuoteDetails.Controls;
                        object[] objArray8 = new object[] { "<div class='Display_None'><input id='ChkSupplier_", num1, "_", id, "_2' type='checkbox' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','2','", num1, "','", id, "');></div>" };
                        controlCollections4.Add(new LiteralControl(string.Concat(objArray8)));
                    }
                    else if (dataTable3.Rows[0]["IsSelected"].ToString().ToLower() != "true")
                    {
                        ControlCollection controls5 = this.plhQuoteDetails.Controls;
                        object[] objArray9 = new object[] { "<div style='padding:2px 0px 2px 0px'><input id='ChkSupplier_", num1, "_", id, "_2' type='checkbox' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','2','", num1, "','", id, "');></div>" };
                        controls5.Add(new LiteralControl(string.Concat(objArray9)));
                    }
                    else
                    {
                        ControlCollection controlCollections5 = this.plhQuoteDetails.Controls;
                        object[] objArray10 = new object[] { "<div style='padding:2px 0px 2px 0px'><input id='ChkSupplier_", num1, "_", id, "_2' type='checkbox' checked='checked' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','2','", num1, "','", id, "');></div>" };
                        controlCollections5.Add(new LiteralControl(string.Concat(objArray10)));
                    }
                    if (dataTable4.Rows.Count <= 0)
                    {
                        ControlCollection controls6 = this.plhQuoteDetails.Controls;
                        object[] objArray11 = new object[] { "<div class='Display_None'><input id='ChkSupplier_", num1, "_", id, "_3' type='checkbox' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','3','", num1, "','", id, "');></div>" };
                        controls6.Add(new LiteralControl(string.Concat(objArray11)));
                    }
                    else if (dataTable4.Rows[0]["IsSelected"].ToString().ToLower() != "true")
                    {
                        ControlCollection controlCollections6 = this.plhQuoteDetails.Controls;
                        object[] objArray12 = new object[] { "<div style='padding:2px 0px 2px 0px'><input id='ChkSupplier_", num1, "_", id, "_3' type='checkbox' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','3','", num1, "','", id, "');></div>" };
                        controlCollections6.Add(new LiteralControl(string.Concat(objArray12)));
                    }
                    else
                    {
                        ControlCollection controls7 = this.plhQuoteDetails.Controls;
                        object[] objArray13 = new object[] { "<div style='padding:2px 0px 2px 0px'><input id='ChkSupplier_", num1, "_", id, "_3' type='checkbox' checked='checked' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','3','", num1, "','", id, "');></div>" };
                        controls7.Add(new LiteralControl(string.Concat(objArray13)));
                    }
                    if (dataTable5.Rows.Count <= 0)
                    {
                        ControlCollection controlCollections7 = this.plhQuoteDetails.Controls;
                        object[] objArray14 = new object[] { "<div class='Display_None'><input id='ChkSupplier_", num1, "_", id, "_4' type='checkbox' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','4','", num1, "','", id, "');></div>" };
                        controlCollections7.Add(new LiteralControl(string.Concat(objArray14)));
                    }
                    else if (dataTable5.Rows[0]["IsSelected"].ToString().ToLower() != "true")
                    {
                        ControlCollection controls8 = this.plhQuoteDetails.Controls;
                        object[] objArray15 = new object[] { "<div style='padding:2px 0px 2px 0px'><input id='ChkSupplier_", num1, "_", id, "_4' type='checkbox' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','4','", num1, "','", id, "');></div>" };
                        controls8.Add(new LiteralControl(string.Concat(objArray15)));
                    }
                    else
                    {
                        ControlCollection controlCollections8 = this.plhQuoteDetails.Controls;
                        object[] objArray16 = new object[] { "<div style='padding:2px 0px 2px 0px'><input id='ChkSupplier_", num1, "_", id, "_4' type='checkbox' checked='checked' onclick=javascript:ChkSelectSupplier(this.id,'", empty, "','4','", num1, "','", id, "');></div>" };
                        controlCollections8.Add(new LiteralControl(string.Concat(objArray16)));
                    }
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                    if (dataTable1.Rows.Count <= 0)
                    {
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td align='center' colspan='13' style='border-bottom: 1px solid #8F939A;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<span></span>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                    }
                    else
                    {
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td align='center' colspan='13'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<div align='left' style='margin-top:-35px;width:90px;float:left;'>"));
                        ControlCollection controls9 = this.plhQuoteDetails.Controls;
                        object[] objArray17 = new object[] { "<label id='lblShow_", num1, "_", id, "' title='", this.objLanguage.GetLanguageConversion("View_History"), "' style='color:#1035A5;font-weight:bold;'  onclick=javascript:HistoryDetails_Show('", num1, "','", id, "');>", this.objLanguage.GetLanguageConversion("View_History"), "</label>" };
                        controls9.Add(new LiteralControl(string.Concat(objArray17)));
                        ControlCollection controlCollections9 = this.plhQuoteDetails.Controls;
                        object[] objArray18 = new object[] { "<label id='lblHide_", num1, "_", id, "' style='display:none;color:#1035A5;font-weight:bold;' title='", this.objLanguage.GetLanguageConversion("Hide_History"), "'  onclick=javascript:HistoryDetails_Hide('", num1, "','", id, "');>", this.objLanguage.GetLanguageConversion("Hide_History"), "</label>" };
                        controlCollections9.Add(new LiteralControl(string.Concat(objArray18)));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</div>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td colspan='13' style='border-bottom: 1px solid #8F939A;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<span></span>"));
                        ControlCollection controls10 = this.plhQuoteDetails.Controls;
                        object[] objArray19 = new object[] { "<div id='history_", num1, "_", id, "' style='display:none; padding-bottom:10px'>" };
                        controls10.Add(new LiteralControl(string.Concat(objArray19)));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<table align='center' width='98%' cellpadding='0' cellspacing='0' style='padding:5px; background-color:#F8F7F5;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr style='width:100%; height:25px;' class='Header_new_style'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:10%;  border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; border-left: 1px solid #AAAAAA;' class='LeftCorner_rounded'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>&nbsp;", this.objLanguage.GetLanguageConversion("Quote_Number"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:7%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Quantity"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b style='padding-left:8px;'>", this.objLanguage.GetLanguageConversion("Cost"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:9%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Delivery_Date"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Delivery_Included"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Delivery_Cost"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("MarkUp_Type"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:6.5%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("MarkUp_Value"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:7%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Total_Price"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:15%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA;'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Comments"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #AAAAAA; border-top: 1px solid #AAAAAA; border-right: 1px solid #AAAAAA;'  align='center' class='RightCorner_rounded'>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", this.objLanguage.GetLanguageConversion("Quoted_By"), "</b></span>")));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                        foreach (DataRow row1 in dataTable1.Rows)
                        {
                            string empty1 = string.Empty;
                            string empty2 = string.Empty;
                            string str2 = string.Empty;
                            string empty3 = string.Empty;
                            string str3 = string.Empty;
                            string empty4 = string.Empty;
                            string str4 = string.Empty;
                            string empty5 = string.Empty;
                            string str5 = string.Empty;
                            empty1 = row1["MarkUpType"].ToString();
                            empty2 = row1["MarkupValue1"].ToString();
                            str2 = row1["MarkupValue2"].ToString();
                            empty3 = row1["MarkupValue3"].ToString();
                            str3 = row1["MarkupValue4"].ToString();
                            empty4 = row1["TotalPrice1"].ToString();
                            str4 = row1["TotalPrice2"].ToString();
                            empty5 = row1["TotalPrice3"].ToString();
                            str5 = row1["TotalPrice4"].ToString();
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr style='width:100%;'>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:10%; border-bottom: 1px solid #8F939A;'>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<input disabled='true' style='width:90%;' value='", row1["UserEstimateNumber"].ToString(), "'></input>")));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:7%; border-bottom: 1px solid #8F939A;'>"));
                            if (row1["Quantity1"].ToString() != "0")
                            {
                                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div><input disabled='true' onkeypress='return IntergerValidation(event)' style='width:85%;text-align:right' type='text' value='", row1["Quantity1"].ToString(), "'></div>")));
                            }
                            if (row1["Quantity2"].ToString() != "0")
                            {
                                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div><input disabled='true' onkeypress='return IntergerValidation(event)' style='width:85%;text-align:right' type='text' value='", row1["Quantity2"].ToString(), "'></div>")));
                            }
                            if (row1["Quantity3"].ToString() != "0")
                            {
                                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div><input disabled='true' onkeypress='return IntergerValidation(event)' style='width:85%;text-align:right' type='text' value='", row1["Quantity3"].ToString(), "'></div>")));
                            }
                            if (row1["Quantity4"].ToString() != "0")
                            {
                                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div><input disabled='true' onkeypress='return IntergerValidation(event)' style='width:85%;text-align:right' type='text' value='", row1["Quantity4"].ToString(), "'></div>")));
                            }
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #8F939A;' align='center'>"));
                            if (row1["Quantity1"].ToString() != "0")
                            {
                                ControlCollection controlCollections10 = this.plhQuoteDetails.Controls;
                                object[] str6 = new object[] { "<div><input disabled='true' style='width:85%;text-align:right'  onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','others'); type='text' value='", null, null };
                                num = Math.Round(Convert.ToDecimal(row1["Price1"]), this.roundoff);
                                str6[5] = num.ToString();
                                str6[6] = "'></div>";
                                controlCollections10.Add(new LiteralControl(string.Concat(str6)));
                            }
                            if (row1["Quantity2"].ToString() != "0")
                            {
                                ControlCollection controls11 = this.plhQuoteDetails.Controls;
                                object[] str7 = new object[] { "<div><input disabled='true'  style='width:85%;text-align:right'  onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','others'); type='text' value='", null, null };
                                decimal num3 = Math.Round(Convert.ToDecimal(row1["Price2"]), this.roundoff);
                                str7[5] = num3.ToString();
                                str7[6] = "'></div>";
                                controls11.Add(new LiteralControl(string.Concat(str7)));
                            }
                            if (row1["Quantity3"].ToString() != "0")
                            {
                                ControlCollection controlCollections11 = this.plhQuoteDetails.Controls;
                                object[] str8 = new object[] { "<div><input disabled='true'  style='width:85%;text-align:right'  onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','others'); type='text' value='", null, null };
                                num = Math.Round(Convert.ToDecimal(row1["Price3"]), this.roundoff);
                                str8[5] = num.ToString();
                                str8[6] = "'></div>";
                                controlCollections11.Add(new LiteralControl(string.Concat(str8)));
                            }
                            if (row1["Quantity4"].ToString() != "0")
                            {
                                ControlCollection controls12 = this.plhQuoteDetails.Controls;
                                name = new object[] { "<div><input disabled='true'  style='width:85%;text-align:right'  onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','others'); type='text' value='", null, null };
                                num = Math.Round(Convert.ToDecimal(row1["Price4"]), this.roundoff);
                                name[5] = num.ToString();
                                name[6] = "'></div>";
                                controls12.Add(new LiteralControl(string.Concat(name)));
                            }
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #8F939A;'>"));
                            string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", str1, "')");
                            string str9 = this.commclass.Eprint_return_Date_Before_View(row1["DeliveryDate1"].ToString(), this.CompanyID, this.UserID, false);
                            string str10 = this.commclass.Eprint_return_Date_Before_View(row1["DeliveryDate2"].ToString(), this.CompanyID, this.UserID, false);
                            string str11 = this.commclass.Eprint_return_Date_Before_View(row1["DeliveryDate3"].ToString(), this.CompanyID, this.UserID, false);
                            string str12 = this.commclass.Eprint_return_Date_Before_View(row1["DeliveryDate4"].ToString(), this.CompanyID, this.UserID, false);
                            if (row1["Quantity1"].ToString() != "0")
                            {
                                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div><input disabled='true'  style='width:90%' readonly='readonly' type='text' value='", str9, "'></div>")));
                            }
                            if (row1["Quantity2"].ToString() != "0")
                            {
                                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div><input disabled='true'  style='width:90%' readonly='readonly' type='text' value='", str10, "'></div>")));
                            }
                            if (row1["Quantity3"].ToString() != "0")
                            {
                                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div><input disabled='true'  style='width:90%' readonly='readonly' type='text' value='", str11, "'></div>")));
                            }
                            if (row1["Quantity4"].ToString() != "0")
                            {
                                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div><input disabled='true'  style='width:90%' readonly='readonly' type='text' value='", str12, "'></div>")));
                            }
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #8F939A;'>"));
                            if (row1["Quantity1"].ToString() != "0")
                            {
                                ControlCollection controlCollections12 = this.plhQuoteDetails.Controls;
                                name = new object[] { "<div style='padding-bottom:5px; padding-top:5px;'><select  disabled='true' style='width:75%;' class='normaltext' onchange=javascript:DelIncluded(this.id,'", row1["SupplierID"].ToString(), "_", id, "','1');Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','others');>" };
                                controlCollections12.Add(new LiteralControl(string.Concat(name)));
                                if (row1["IsDeliveryIncluded1"].ToString().ToLower() != "yes")
                                {
                                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes'>Yes</option><option value='no' selected='true'>No</option></select></div>"));
                                }
                                else
                                {
                                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes' selected='true'>Yes</option><option value='no'>No</option></select></div>"));
                                }
                            }
                            if (row1["Quantity2"].ToString() != "0")
                            {
                                ControlCollection controls13 = this.plhQuoteDetails.Controls;
                                name = new object[] { "<div style='padding-bottom:5px;'><select disabled='true'  style='width:75%' class='normaltext' onchange=javascript:DelIncluded(this.id,'", row1["SupplierID"].ToString(), "_", id, "','2');Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','others');>" };
                                controls13.Add(new LiteralControl(string.Concat(name)));
                                if (row1["IsDeliveryIncluded2"].ToString().ToLower() != "yes")
                                {
                                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes'>Yes</option><option value='no' selected='true'>No</option></select></div>"));
                                }
                                else
                                {
                                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes' selected='true'>Yes</option><option value='no'>No</option></select></div>"));
                                }
                            }
                            if (row1["Quantity3"].ToString() != "0")
                            {
                                ControlCollection controlCollections13 = this.plhQuoteDetails.Controls;
                                name = new object[] { "<div style='padding-bottom:5px;'><select disabled='true'  style='width:75%' class='normaltext' onchange=javascript:DelIncluded(this.id,'", row1["SupplierID"].ToString(), "_", id, "','3');Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','others');>" };
                                controlCollections13.Add(new LiteralControl(string.Concat(name)));
                                if (row1["IsDeliveryIncluded3"].ToString().ToLower() != "yes")
                                {
                                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes'>Yes</option><option value='no' selected='true'>No</option></select></div>"));
                                }
                                else
                                {
                                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes' selected='true'>Yes</option><option value='no'>No</option></select></div>"));
                                }
                            }
                            if (row1["Quantity4"].ToString() != "0")
                            {
                                ControlCollection controls14 = this.plhQuoteDetails.Controls;
                                name = new object[] { "<div style='padding-bottom:5px;'><select disabled='true'  style='width:75%' class='normaltext' onchange=javascript:DelIncluded(this.id,'", row1["SupplierID"].ToString(), "_", id, "','4');Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','others');>" };
                                controls14.Add(new LiteralControl(string.Concat(name)));
                                if (row1["IsDeliveryIncluded4"].ToString().ToLower() != "yes")
                                {
                                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes'>Yes</option><option value='no' selected='true'>No</option></select></div>"));
                                }
                                else
                                {
                                    this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes' selected='true'>Yes</option><option value='no'>No</option></select></div>"));
                                }
                            }
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #8F939A;'>"));
                            if (row1["Quantity1"].ToString() != "0")
                            {
                                if (row1["IsDeliveryIncluded1"].ToString().ToLower() != "yes")
                                {
                                    ControlCollection controlCollections14 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(row1["DeliveryCost1"]), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections14.Add(new LiteralControl(string.Concat(name)));
                                }
                                else
                                {
                                    ControlCollection controls15 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(row1["DeliveryCost1"]), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controls15.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            if (row1["Quantity2"].ToString() != "0")
                            {
                                if (row1["IsDeliveryIncluded2"].ToString().ToLower() != "yes")
                                {
                                    ControlCollection controlCollections15 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(row1["DeliveryCost2"]), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections15.Add(new LiteralControl(string.Concat(name)));
                                }
                                else
                                {
                                    ControlCollection controls16 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(row1["DeliveryCost2"]), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controls16.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            if (row1["Quantity3"].ToString() != "0")
                            {
                                if (row1["IsDeliveryIncluded3"].ToString().ToLower() != "yes")
                                {
                                    ControlCollection controlCollections16 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(row1["DeliveryCost3"]), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections16.Add(new LiteralControl(string.Concat(name)));
                                }
                                else
                                {
                                    ControlCollection controls17 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(row1["DeliveryCost3"]), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controls17.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            if (row1["Quantity4"].ToString() != "0")
                            {
                                if (row1["IsDeliveryIncluded4"].ToString().ToLower() != "yes")
                                {
                                    ControlCollection controlCollections17 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(row1["DeliveryCost4"]), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections17.Add(new LiteralControl(string.Concat(name)));
                                }
                                else
                                {
                                    ControlCollection controls18 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(row1["DeliveryCost4"]), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controls18.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #8F939A;'>"));
                            if (empty1.ToLower() != "p")
                            {
                                if (empty1.ToLower() == "f")
                                {
                                    if (row1["Quantity1"].ToString() != "0")
                                    {
                                        ControlCollection controlCollections18 = this.plhQuoteDetails.Controls;
                                        name = new object[] { "<div style='padding-bottom:5px; padding-top:5px;'><select disabled='true'  style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", empty, "','", id, "');Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','others');>" };
                                        controlCollections18.Add(new LiteralControl(string.Concat(name)));
                                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P'>%</option><option value='F' selected='true'>$</option></select></div>"));
                                    }
                                    else if (row1["Quantity2"].ToString() != "0")
                                    {
                                        ControlCollection controls19 = this.plhQuoteDetails.Controls;
                                        name = new object[] { "<div style='padding-bottom:5px;'><select disabled='true'  style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", empty, "','", id, "');Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','others');>" };
                                        controls19.Add(new LiteralControl(string.Concat(name)));
                                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P'>%</option><option value='F' selected='true'>$</option></select></div>"));
                                    }
                                    else if (row1["Quantity3"].ToString() != "0")
                                    {
                                        ControlCollection controlCollections19 = this.plhQuoteDetails.Controls;
                                        name = new object[] { "<div style='padding-bottom:5px;'><select  disabled='true' style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", empty, "','", id, "');Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','others');>" };
                                        controlCollections19.Add(new LiteralControl(string.Concat(name)));
                                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P'>%</option><option value='F' selected='true'>$</option></select></div>"));
                                    }
                                    else if (row1["Quantity4"].ToString() != "0")
                                    {
                                        ControlCollection controls20 = this.plhQuoteDetails.Controls;
                                        name = new object[] { "<div style='padding-bottom:5px;'><select disabled='true'  style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", empty, "','", id, "');Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','others');>" };
                                        controls20.Add(new LiteralControl(string.Concat(name)));
                                        this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P'>%</option><option value='F' selected='true'>$</option></select></div>"));
                                    }
                                }
                            }
                            else if (row1["Quantity1"].ToString() != "0")
                            {
                                ControlCollection controlCollections20 = this.plhQuoteDetails.Controls;
                                name = new object[] { "<div style='padding-bottom:5px; padding-top:5px;'><select disabled='true'  style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", empty, "','", id, "');Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','others');>" };
                                controlCollections20.Add(new LiteralControl(string.Concat(name)));
                                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P' selected='true'>%</option><option value='F'>$</option></select></div>"));
                            }
                            else if (row1["Quantity2"].ToString() != "0")
                            {
                                ControlCollection controls21 = this.plhQuoteDetails.Controls;
                                name = new object[] { "<div style='padding-bottom:5px;'><select disabled='true'  style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", empty, "','", id, "');Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','others');>" };
                                controls21.Add(new LiteralControl(string.Concat(name)));
                                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P' selected='true'>%</option><option value='F'>$</option></select></div>"));
                            }
                            else if (row1["Quantity3"].ToString() != "0")
                            {
                                ControlCollection controlCollections21 = this.plhQuoteDetails.Controls;
                                name = new object[] { "<div style='padding-bottom:5px;'><select disabled='true'  style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", empty, "','", id, "');Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','others');>" };
                                controlCollections21.Add(new LiteralControl(string.Concat(name)));
                                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P' selected='true'>%</option><option value='F'>$</option></select></div>"));
                            }
                            else if (row1["Quantity4"].ToString() != "0")
                            {
                                ControlCollection controls22 = this.plhQuoteDetails.Controls;
                                name = new object[] { "<div style='padding-bottom:5px;'><select disabled='true'  style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", empty, "','", id, "');Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','others');>" };
                                controls22.Add(new LiteralControl(string.Concat(name)));
                                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P' selected='true'>%</option><option value='F'>$</option></select></div>"));
                            }
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #8F939A;'>"));
                            if (row1["Quantity1"].ToString() != "0")
                            {
                                try
                                {
                                    ControlCollection controlCollections22 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(empty2), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections22.Add(new LiteralControl(string.Concat(name)));
                                }
                                catch
                                {
                                    ControlCollection controls23 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','others'); type='text' value='0.00'></div>" };
                                    controls23.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            if (row1["Quantity2"].ToString() != "0")
                            {
                                try
                                {
                                    ControlCollection controlCollections23 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input  disabled='true' style='width:90%;text-align:right'  onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(str2), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections23.Add(new LiteralControl(string.Concat(name)));
                                }
                                catch
                                {
                                    ControlCollection controls24 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input  disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','others'); type='text' value='0.00'></div>" };
                                    controls24.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            if (row1["Quantity3"].ToString() != "0")
                            {
                                try
                                {
                                    ControlCollection controlCollections24 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input  disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(empty3), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections24.Add(new LiteralControl(string.Concat(name)));
                                }
                                catch
                                {
                                    ControlCollection controls25 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input  disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','others'); type='text' value='0.00'></div>" };
                                    controls25.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            if (row1["Quantity4"].ToString() != "0")
                            {
                                try
                                {
                                    ControlCollection controlCollections25 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input  disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','others'); type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(str3), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections25.Add(new LiteralControl(string.Concat(name)));
                                }
                                catch
                                {
                                    ControlCollection controls26 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input  disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','others'); type='text' value='0.00'></div>" };
                                    controls26.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #8F939A;'>"));
                            if (row1["Quantity1"].ToString() != "0")
                            {
                                try
                                {
                                    ControlCollection controlCollections26 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','total');  type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(empty4), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections26.Add(new LiteralControl(string.Concat(name)));
                                }
                                catch
                                {
                                    ControlCollection controls27 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','1','total');  type='text' value='0.00'></div>" };
                                    controls27.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            if (row1["Quantity2"].ToString() != "0")
                            {
                                try
                                {
                                    ControlCollection controlCollections27 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','total');  type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(str4), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections27.Add(new LiteralControl(string.Concat(name)));
                                }
                                catch
                                {
                                    ControlCollection controls28 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true'  style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','2','total');  type='text' value='0.00'></div>" };
                                    controls28.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            if (row1["Quantity3"].ToString() != "0")
                            {
                                try
                                {
                                    ControlCollection controlCollections28 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input  disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','total');  type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(empty5), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections28.Add(new LiteralControl(string.Concat(name)));
                                }
                                catch
                                {
                                    ControlCollection controls29 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','3','total');  type='text' value='0.00'></div>" };
                                    controls29.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            if (row1["Quantity4"].ToString() != "0")
                            {
                                try
                                {
                                    ControlCollection controlCollections29 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input  disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','total');  type='text' value='", null, null };
                                    num = Math.Round(Convert.ToDecimal(str5), this.roundoff);
                                    name[5] = num.ToString();
                                    name[6] = "'></div>";
                                    controlCollections29.Add(new LiteralControl(string.Concat(name)));
                                }
                                catch
                                {
                                    ControlCollection controls30 = this.plhQuoteDetails.Controls;
                                    name = new object[] { "<div><input  disabled='true' style='width:90%;text-align:right' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", row1["SupplierID"].ToString(), "_", id, "','4','total');  type='text' value='0.00'></div>" };
                                    controls30.Add(new LiteralControl(string.Concat(name)));
                                }
                            }
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:12%; border-bottom: 1px solid #8F939A;'><span></span>"));
                            if (row1["IsRejected"].ToString().ToLower() == "true")
                            {
                                if (row1["RejectedReason"].ToString() != "")
                                {
                                    ControlCollection controlCollections30 = this.plhQuoteDetails.Controls;
                                    str = new string[] { "<div style='border: 1px solid #8F939A; max-height:75px; overflow: hidden;'><span><label style='cursor: text; width:200px;' title='", row1["Comments"].ToString(), "'>", row1["RejectedReason"].ToString(), "</label></span></div>" };
                                    controlCollections30.Add(new LiteralControl(string.Concat(str)));
                                }
                            }
                            else if (row1["Comments"].ToString() != "")
                            {
                                ControlCollection controls31 = this.plhQuoteDetails.Controls;
                                str = new string[] { "<div style='border: 1px solid #8F939A; max-height:75px; overflow: hidden;'><span><label style='cursor: text; width:200px;' title='", row1["Comments"].ToString(), "'>", row1["Comments"].ToString(), "</label></span></div>" };
                                controls31.Add(new LiteralControl(string.Concat(str)));
                            }
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:8%; border-bottom: 1px solid #8F939A;' align='center'>"));
                            ControlCollection controlCollections31 = this.plhQuoteDetails.Controls;
                            str = new string[] { "<span><label style='cursor: text;' value='", row1["QuotedBy"].ToString(), "'>", row1["QuotedBy"].ToString(), "</label></span>" };
                            controlCollections31.Add(new LiteralControl(string.Concat(str)));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                            this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                        }
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</table>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</div>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                    }
                }
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr style='width:100%;'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td align='right' style='padding:10px 10px 5px 0px;' colspan='13'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<table style='float:right;'>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<tr>"));
                Button button = new Button()
                {
                    ID = string.Concat("CancelBtn_", id),
                    CssClass = "button",
                    Text = this.objLanguage.GetLanguageConversion("Cancel"),
                    Width = 60,
                    Height = 25
                };
                button.Style.Add("margin-right", "10px");
                button.Style.Add("margin-top", "3px");
                name = new object[] { "javascript:return Redirect_Cancel('", id, "','", this.EstimateID, "');" };
                button.OnClientClick = string.Concat(name);
                this.plhQuoteDetails.Controls.Add(button);
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div id='div_cancelprocess_", id, "' class='button' style='display: none; width:45px; height:15px; margin-bottom:-28px; margin-right: 210px;'>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' /></div>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
                Button button1 = new Button()
                {
                    ID = string.Concat("btnSaveNAccept_", id),
                    CssClass = "button",
                    Text = this.objLanguage.GetLanguageConversion("Save_Close"),
                    Width = 95,
                    Height = 25
                };
                name = new object[] { "javascript:return Save_QuoteDetails('", id, "','", empty, "','btnSaveNAccept');" };
                button1.OnClientClick = string.Concat(name);
                button1.Click += new EventHandler(this.SaveNAcceptBtn_Click);
                this.plhQuoteDetails.Controls.Add(button1);
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div id='div_saveprocess_", id, "' class='button' style='display: none; width:75px; height:15px; '>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' /></div>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
                Button button2 = new Button()
                {
                    ID = string.Concat("btnSaveAndStay_", id),
                    CssClass = "button",
                    Text = this.objLanguage.GetLanguageConversion("Save_Stay"),
                    Width = 90,
                    Height = 25
                };
                button2.Style.Add("margin-left", "7px");
                name = new object[] { "javascript:return Save_QuoteDetails('", id, "','", empty, "','btnSaveAndStay_');" };
                button2.OnClientClick = string.Concat(name);
                button2.Click += new EventHandler(this.SaveNAcceptBtn_Click);
                this.plhQuoteDetails.Controls.Add(button2);
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<div id='div_saveAndStay_", id, "' class='button' style='display: none; width:70px; height:15px;margin-left:8px;'>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='loadingimg' alt='loading' border='0' /></div>")));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</tr>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</table>"));
                IDs = IDs.Remove(IDs.Length - 1);
                System.Web.UI.Page page = this.Page;
                Type type = base.GetType();
                name = new object[] { "javascript:total_Bind('", empty, "','", id, "','", IDs, "');" };
                ScriptManager.RegisterStartupScript(page, type, "", string.Concat(name), true);
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</table>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</div>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</div>"));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("</div>"));
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            empty = base.Session["DateFormat"].ToString();
            this.hdnQuoteSave_EstOnly.Value = this.hdnQuoteSave_EstOnly.Value.Remove(this.hdnQuoteSave_EstOnly.Value.Length - 1);
            this.hdnQuoteSave_EstOnly.Value = this.hdnQuoteSave_EstOnly.Value.Substring(1);
            string[] strArrays = this.hdnQuoteSave_EstOnly.Value.Split(new char[] { '»' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { ';' });
                string str = string.Empty;
                str = (strArrays1[4].Trim().ToString() == "" ? "1900-01-01 00:00:00.000" : this.objBC.DateFormat_Return_As_MM_DD_YYYY(empty, strArrays1[4].Trim()));
                EstimateBasePage.SupplierDetailsInsert_OnlySave(strArrays1[0].ToString(), strArrays1[1].ToString(), strArrays1[2].ToString(), strArrays1[3].ToString(), Convert.ToDateTime(str), strArrays1[5].ToString(), strArrays1[6].ToString(), strArrays1[7].ToString(), strArrays1[8].ToString(), strArrays1[9].ToString(), strArrays1[10].ToString(), strArrays1[11].ToString(), strArrays1[12].ToString(), strArrays1[13].ToString(), "Est");
            }
            string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
            base.Response.Redirect(absoluteUri);
        }

        public void SaveNAcceptBtn_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            empty = base.Session["DateFormat"].ToString();
            this.hdnQuoteSave.Value = this.hdnQuoteSave.Value.Remove(this.hdnQuoteSave.Value.Length - 1);
            this.hdnQuoteSave.Value = this.hdnQuoteSave.Value.Substring(1);
            string[] strArrays = this.hdnQuoteSave.Value.Split(new char[] { '∑' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string[] strArrays1 = strArrays[i].Split(new char[] { ';' });
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                str = (strArrays1[4].Trim().ToString() == "" ? "1900-01-01 00:00:00.000" : this.objBC.DateFormat_Return_As_MM_DD_YYYY(empty, strArrays1[4].Trim()));
                empty1 = (strArrays1[11].Trim().ToString() == "" ? "1900-01-01 00:00:00.000" : this.objBC.DateFormat_Return_As_MM_DD_YYYY(empty, strArrays1[11].Trim()));
                str1 = (strArrays1[18].Trim().ToString() == "" ? "1900-01-01 00:00:00.000" : this.objBC.DateFormat_Return_As_MM_DD_YYYY(empty, strArrays1[18].Trim()));
                empty2 = (strArrays1[25].Trim().ToString() == "" ? "1900-01-01 00:00:00.000" : this.objBC.DateFormat_Return_As_MM_DD_YYYY(empty, strArrays1[25].Trim()));
                EstimateBasePage.SupplierDetailsInsert_HistoryTable(strArrays1[0].ToString(), strArrays1[1].ToString(), strArrays1[2].ToString(), strArrays1[3].ToString(), Convert.ToDateTime(str), strArrays1[5].ToString(), strArrays1[6].ToString(), strArrays1[7].ToString(), strArrays1[8].ToString(), strArrays1[9].ToString(), strArrays1[10].ToString(), Convert.ToDateTime(empty1), strArrays1[12].ToString(), strArrays1[13].ToString(), strArrays1[14].ToString(), strArrays1[15].ToString(), strArrays1[16].ToString(), strArrays1[17].ToString(), Convert.ToDateTime(str1), strArrays1[19].ToString(), strArrays1[20].ToString(), strArrays1[21].ToString(), strArrays1[22].ToString(), strArrays1[23].ToString(), strArrays1[24].ToString(), Convert.ToDateTime(empty2), strArrays1[26].ToString(), strArrays1[27].ToString(), strArrays1[28].ToString(), strArrays1[29].ToString(), strArrays1[30].ToString(), strArrays1[31].ToString(), strArrays1[32].ToString());
            }
            this.hdnQuoteSave_Est.Value = this.hdnQuoteSave_Est.Value.Remove(this.hdnQuoteSave_Est.Value.Length - 1);
            this.hdnQuoteSave_Est.Value = this.hdnQuoteSave_Est.Value.Substring(1);
            string[] strArrays2 = this.hdnQuoteSave_Est.Value.Split(new char[] { '»' });
            for (int j = 0; j < (int)strArrays2.Length; j++)
            {
                string[] strArrays3 = strArrays2[j].Split(new char[] { ';' });
                EstimateBasePage.EstimateQuoteDetails_Update_ByAdmin_Unselect(strArrays3[0].ToString());
            }
            for (int k = 0; k < (int)strArrays2.Length; k++)
            {
                string[] strArrays4 = strArrays2[k].Split(new char[] { ';' });
                string str2 = string.Empty;
                str2 = (strArrays4[4].Trim().ToString() == "" ? "1900-01-01 00:00:00.000" : this.objBC.DateFormat_Return_As_MM_DD_YYYY(empty, strArrays4[4].Trim()));
                EstimateBasePage.SupplierDetailsInsert_OnlySave(strArrays4[0].ToString(), strArrays4[1].ToString(), strArrays4[2].ToString(), strArrays4[3].ToString(), Convert.ToDateTime(str2), strArrays4[5].ToString(), strArrays4[6].ToString(), strArrays4[7].ToString(), strArrays4[8].ToString(), strArrays4[9].ToString(), strArrays4[10].ToString(), strArrays4[11].ToString(), strArrays4[12].ToString(), strArrays4[13].ToString(), "All");
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(Convert.ToInt64(strArrays4[0].ToString()));
            }
            string empty3 = string.Empty;
            long num = (long)0;
            if (base.Request.Params["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            if (base.Request.Params["estitemID"] != null)
            {
                num = Convert.ToInt64(base.Request.Params["estitemID"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(this.hdn_btnProcess.Value)) && this.hdn_btnProcess.Value == "saveandstay")
            {
                if (!base.Request.Url.ToString().ToLower().Contains("estimates"))
                {
                    object[] estimateID = new object[] { this.strSitepath, "orders/order_quotedetails_panel.aspx?estid=", this.EstimateID, "&estitemID=", num, "&Module=", this.Module, "&suc=up" };
                    empty3 = string.Concat(estimateID);
                }
                else
                {
                    object[] objArray = new object[] { this.strSitepath, "estimates/estimate_quotedetails_panel.aspx?estid=", this.EstimateID, "&estitemID=", num, "&Module=", this.Module, "&suc=up" };
                    empty3 = string.Concat(objArray);
                }
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("estimates"))
            {
                object[] estimateID1 = new object[] { this.strSitepath, "orders/order_summary.aspx?&ordid=", this.EstimateID, "&estid=", this.EstimateID, "&estitemID=", num };
                empty3 = string.Concat(estimateID1);
            }
            else
            {
                object[] objArray1 = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?&estid=", this.EstimateID, "&estitemID=", num };
                empty3 = string.Concat(objArray1);
            }
            base.Response.Redirect(empty3);
        }

        public void SFQ_Details(DataTable dt_QTY1, DataTable dt_QTY2, DataTable dt_QTY3, DataTable dt_QTY4, long SupplierID_SFQ, string SupplieridList, long id, string isRejected)
        {
            decimal num;
            string str = base.Session["DateFormat"].ToString();
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            string lower = string.Empty;
            string lower1 = string.Empty;
            string lower2 = string.Empty;
            string lower3 = string.Empty;
            string str6 = string.Empty;
            string empty7 = string.Empty;
            string str7 = string.Empty;
            string empty8 = string.Empty;
            string lower4 = string.Empty;
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
            string str19 = string.Empty;
            string empty20 = string.Empty;
            string str20 = string.Empty;

            this.roundoff = GetRoundOffValue();

            if (dt_QTY1.Rows.Count <= 0)
            {
                str12 = "class='Display_None'";
                empty = "";
                str2 = "0.00";
                str4 = "";
                lower = "yes";
                str6 = "0.00";
                str8 = "0.00";
                str10 = "0.00";
                str14 = "No";
            }
            else
            {
                foreach (DataRow row in dt_QTY1.Rows)
                {
                    str12 = "class='Display_Block'";
                    empty = row["Quantity"].ToString();
                    num = Math.Round(Convert.ToDecimal(row["Cost"]), this.roundoff);
                    str2 = num.ToString();
                    str4 = this.commclass.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                    lower = row["IsDeliveryIncluded"].ToString().ToLower();
                    decimal num1 = Math.Round(Convert.ToDecimal(row["DeliveryCost"]), this.roundoff);
                    str6 = num1.ToString();
                    lower4 = row["MarkUpType"].ToString().ToLower();
                    decimal num2 = Math.Round(Convert.ToDecimal(row["MarkupValue"]), this.roundoff);
                    str8 = num2.ToString();
                    decimal num3 = Math.Round(Convert.ToDecimal(row["TotalPrice"]), this.roundoff);
                    str10 = num3.ToString();
                    if (row["QuoteStatus"].ToString() == "Accepted")
                    {
                        str14 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Quote_Selected"), "</b></span>");
                    }
                    else if (row["QuoteStatus"].ToString() == "Quoted")
                    {
                        str14 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Quote_Received"), "</b></span>");
                    }
                    else if (row["QuoteStatus"].ToString() == "Sent For Quote")
                    {
                        str14 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Sent_to_Supplier"), "</b></span>");
                    }
                    if (row["IsEmailSent"].ToString().ToLower() == "false" && row["IsQuoteAccepted"].ToString().ToLower() == "false")
                    {
                        str20 = "Pending";
                    }
                    DataSet dataSet = EstimatesBasePage.SupplierID_PerQty(id, "1");
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        str16 = dataSet.Tables[0].Rows[0]["SupplierID"].ToString();
                    }
                    if (dataSet.Tables[1].Rows.Count <= 0)
                    {
                        continue;
                    }
                    str18 = dataSet.Tables[1].Rows[0]["SupplierID"].ToString();
                }
            }
            if (dt_QTY2.Rows.Count <= 0)
            {
                empty13 = "class='Display_None'";
                empty1 = "";
                empty3 = "0.00";
                empty5 = "";
                lower1 = "yes";
                empty7 = "0.00";
                empty9 = "0.00";
                empty11 = "0.00";
                empty15 = str14;
            }
            else
            {
                foreach (DataRow dataRow in dt_QTY2.Rows)
                {
                    empty13 = "class='Display_Block'";
                    empty1 = dataRow["Quantity"].ToString();
                    num = Math.Round(Convert.ToDecimal(dataRow["Cost"]), this.roundoff);
                    empty3 = num.ToString();
                    empty5 = this.commclass.Eprint_return_Date_Before_View(dataRow["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                    lower1 = dataRow["IsDeliveryIncluded"].ToString().ToLower();
                    num = Math.Round(Convert.ToDecimal(dataRow["DeliveryCost"]), this.roundoff);
                    empty7 = num.ToString();
                    lower4 = dataRow["MarkUpType"].ToString().ToLower();
                    num = Math.Round(Convert.ToDecimal(dataRow["MarkupValue"]), this.roundoff);
                    empty9 = num.ToString();
                    num = Math.Round(Convert.ToDecimal(dataRow["TotalPrice"]), this.roundoff);
                    empty11 = num.ToString();
                    if (dataRow["QuoteStatus"].ToString() == "Accepted")
                    {
                        empty15 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Quote_Selected"), "</b></span>");
                    }
                    else if (dataRow["QuoteStatus"].ToString() == "Quoted")
                    {
                        empty15 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Quote_Received"), "</b></span>");
                    }
                    else if (dataRow["QuoteStatus"].ToString() == "Sent For Quote")
                    {
                        empty15 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Sent_to_Supplier"), "</b></span>");
                    }
                    if (dataRow["IsEmailSent"].ToString().ToLower() == "false" && dataRow["IsQuoteAccepted"].ToString().ToLower() == "false")
                    {
                        str20 = "Pending";
                    }
                    DataSet dataSet1 = EstimatesBasePage.SupplierID_PerQty(id, "2");
                    if (dataSet1.Tables[0].Rows.Count > 0)
                    {
                        empty17 = dataSet1.Tables[0].Rows[0]["SupplierID"].ToString();
                    }
                    if (dataSet1.Tables[1].Rows.Count <= 0)
                    {
                        continue;
                    }
                    empty19 = dataSet1.Tables[1].Rows[0]["SupplierID"].ToString();
                }
            }
            if (dt_QTY3.Rows.Count <= 0)
            {
                str13 = "class='Display_None'";
                str1 = "";
                str3 = "0.00";
                str5 = "";
                lower2 = "yes";
                str7 = "0.00";
                str9 = "0.00";
                str11 = "0.00";
                str15 = empty15;
            }
            else
            {
                foreach (DataRow row1 in dt_QTY3.Rows)
                {
                    str13 = "class='Display_Block'";
                    str1 = row1["Quantity"].ToString();
                    num = Math.Round(Convert.ToDecimal(row1["Cost"]), this.roundoff);
                    str3 = num.ToString();
                    str5 = this.commclass.Eprint_return_Date_Before_View(row1["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                    lower2 = row1["IsDeliveryIncluded"].ToString().ToLower();
                    num = Math.Round(Convert.ToDecimal(row1["DeliveryCost"]), this.roundoff);
                    str7 = num.ToString();
                    lower4 = row1["MarkUpType"].ToString().ToLower();
                    num = Math.Round(Convert.ToDecimal(row1["MarkupValue"]), this.roundoff);
                    str9 = num.ToString();
                    num = Math.Round(Convert.ToDecimal(row1["TotalPrice"]), this.roundoff);
                    str11 = num.ToString();
                    if (row1["QuoteStatus"].ToString() == "Accepted")
                    {
                        str15 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Quote_Selected"), "</b></span>");
                    }
                    else if (row1["QuoteStatus"].ToString() == "Quoted")
                    {
                        str15 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Quote_Received"), "</b></span>");
                    }
                    else if (row1["QuoteStatus"].ToString() == "Sent For Quote")
                    {
                        str15 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Sent_to_Supplier"), "</b></span>");
                    }
                    if (row1["IsEmailSent"].ToString().ToLower() == "false" && row1["IsQuoteAccepted"].ToString().ToLower() == "false")
                    {
                        str20 = "Pending";
                    }
                    DataSet dataSet2 = EstimatesBasePage.SupplierID_PerQty(id, "3");
                    if (dataSet2.Tables[0].Rows.Count > 0)
                    {
                        str17 = dataSet2.Tables[0].Rows[0]["SupplierID"].ToString();
                    }
                    if (dataSet2.Tables[1].Rows.Count <= 0)
                    {
                        continue;
                    }
                    str19 = dataSet2.Tables[1].Rows[0]["SupplierID"].ToString();
                }
            }
            if (dt_QTY4.Rows.Count <= 0)
            {
                empty14 = "class='Display_None'";
                empty2 = "";
                empty4 = "0.00";
                empty6 = "";
                lower3 = "yes";
                empty8 = "0.00";
                empty10 = "0.00";
                empty12 = "0.00";
                empty16 = str15;
            }
            else
            {
                foreach (DataRow dataRow1 in dt_QTY4.Rows)
                {
                    empty14 = "class='Display_Block'";
                    empty2 = dataRow1["Quantity"].ToString();
                    num = Math.Round(Convert.ToDecimal(dataRow1["Cost"]), this.roundoff);
                    empty4 = num.ToString();
                    empty6 = this.commclass.Eprint_return_Date_Before_View(dataRow1["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                    lower3 = dataRow1["IsDeliveryIncluded"].ToString().ToLower();
                    num = Math.Round(Convert.ToDecimal(dataRow1["DeliveryCost"]), this.roundoff);
                    empty8 = num.ToString();
                    lower4 = dataRow1["MarkUpType"].ToString().ToLower();
                    num = Math.Round(Convert.ToDecimal(dataRow1["MarkupValue"]), this.roundoff);
                    empty10 = num.ToString();
                    num = Math.Round(Convert.ToDecimal(dataRow1["TotalPrice"]), this.roundoff);
                    empty12 = num.ToString();
                    if (dataRow1["QuoteStatus"].ToString() == "Accepted")
                    {
                        empty16 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Quote_Selected"), "</b></span>");
                    }
                    else if (dataRow1["QuoteStatus"].ToString() == "Quoted")
                    {
                        empty16 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Quote_Received"), "</b></span>");
                    }
                    else if (dataRow1["QuoteStatus"].ToString() == "Sent For Quote")
                    {
                        empty16 = string.Concat("<span style='color:#1035A5'><b>", this.objLanguage.GetLanguageConversion("Sent_to_Supplier"), "</b></span>");
                    }
                    if (dataRow1["IsEmailSent"].ToString().ToLower() == "false" && dataRow1["IsQuoteAccepted"].ToString().ToLower() == "false")
                    {
                        str20 = "Pending";
                    }
                    DataSet dataSet3 = EstimatesBasePage.SupplierID_PerQty(id, "4");
                    if (dataSet3.Tables[0].Rows.Count > 0)
                    {
                        empty18 = dataSet3.Tables[0].Rows[0]["SupplierID"].ToString();
                    }
                    if (dataSet3.Tables[1].Rows.Count <= 0)
                    {
                        continue;
                    }
                    empty20 = dataSet3.Tables[1].Rows[0]["SupplierID"].ToString();
                }
            }
            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
            ControlCollection controls = this.plhQuoteDetails.Controls;
            object[] supplierIDSFQ = new object[] { "<div ", str12, "><input style='width:90%;text-align:right' id='txtQTY_", SupplierID_SFQ, "_", id, "_1' type='text' disabled='true' value='", empty, "' ></div>" };
            controls.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty13, "><input style='width:90%;text-align:right' id='txtQTY_", SupplierID_SFQ, "_", id, "_2' type='text'  disabled='true' value='", empty1, "' ></div>" };
            controlCollections.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controls1 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str13, "><input style='width:90%;text-align:right' id='txtQTY_", SupplierID_SFQ, "_", id, "_3' type='text' disabled='true' value='", str1, "' ></div>" };
            controls1.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections1 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty14, "><input style='width:90%;text-align:right' id='txtQTY_", SupplierID_SFQ, "_", id, "_4' type='text' disabled='true' value='", empty2, "' ></div>" };
            controlCollections1.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controls2 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div class='Display_None'><input style='width:90%;text-align:right' id='QtySupID_", id, "_1' type='text' disabled='true' value='", str16, "' ></div>" };
            controls2.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections2 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div class='Display_None'><input style='width:90%;text-align:right' id='QtySupID_", id, "_2' type='text'  disabled='true' value='", empty17, "' ></div>" };
            controlCollections2.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controls3 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div class='Display_None'><input style='width:90%;text-align:right' id='QtySupID_", id, "_3' type='text' disabled='true' value='", str17, "' ></div>" };
            controls3.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections3 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div class='Display_None'><input style='width:90%;text-align:right' id='QtySupID_", id, "_4' type='text' disabled='true' value='", empty18, "' ></div>" };
            controlCollections3.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controls4 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div class='Display_None'><input style='width:90%;text-align:right' id='DelDateSupID_", id, "_1' type='text' disabled='true' value='", str18, "' ></div>" };
            controls4.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections4 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div class='Display_None'><input style='width:90%;text-align:right' id='DelDateSupID_", id, "_2' type='text'  disabled='true' value='", empty19, "' ></div>" };
            controlCollections4.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controls5 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div class='Display_None'><input style='width:90%;text-align:right' id='DelDateSupID_", id, "_3' type='text' disabled='true' value='", str19, "' ></div>" };
            controls5.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections5 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div class='Display_None'><input style='width:90%;text-align:right' id='DelDateSupID_", id, "_4' type='text' disabled='true' value='", empty20, "' ></div>" };
            controlCollections5.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
            ControlCollection controls6 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str12, "><input style='width:90%;text-align:right' id='txtPrice_", SupplierID_SFQ, "_", id, "_1' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','1','others'); type='text' value='", str2, "' ></div>" };
            controls6.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections6 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty13, "><input style='width:90%;text-align:right' id='txtPrice_", SupplierID_SFQ, "_", id, "_2' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','2','others'); type='text' value='", empty3, "' ></div>" };
            controlCollections6.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controls7 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str13, "><input style='width:90%;text-align:right' id='txtPrice_", SupplierID_SFQ, "_", id, "_3' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','3','others'); type='text' value='", str3, "' ></div>" };
            controls7.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections7 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty14, "><input style='width:90%;text-align:right' id='txtPrice_", SupplierID_SFQ, "_", id, "_4' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','4','others'); type='text' value='", empty4, "' ></div>" };
            controlCollections7.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
            string str21 = string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", str, "')");
            ControlCollection controls8 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str12, "><input readonly='readonly'  style='width:85px;text-align:left' id='txtDelDate_", SupplierID_SFQ, "_", id, "_1' onclick=", str21, " type='text' value='", str4, "' ></div>" };
            controls8.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections8 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty13, "><input readonly='readonly'  style='width:85px;text-align:left' id='txtDelDate_", SupplierID_SFQ, "_", id, "_2' onclick=", str21, " type='text' value='", empty5, "' ></div>" };
            controlCollections8.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controls9 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str13, "><input readonly='readonly'  style='width:85px;text-align:left' id='txtDelDate_", SupplierID_SFQ, "_", id, "_3' onclick=", str21, " type='text' value='", str5, "' ></div>" };
            controls9.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections9 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty14, "><input readonly='readonly'  style='width:85px;text-align:left' id='txtDelDate_", SupplierID_SFQ, "_", id, "_4' onclick=", str21, " type='text' value='", empty6, "' ></div>" };
            controlCollections9.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
            ControlCollection controls10 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str12, " style='padding-bottom:5px; padding-top:5px;'><select id='ddlDel_", SupplierID_SFQ, "_", id, "_1' style='width:95%;' class='normaltext' onchange=javascript:DelIncluded(this.id,'", SupplierID_SFQ, "_", id, "','1');Calculation('", SupplierID_SFQ, "_", id, "','1','others');>" };
            controls10.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            if (lower != "yes")
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes'>Yes</option><option value='no' selected='true'>No</option></select></div>"));
            }
            else
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes' selected='true'>Yes</option><option value='no'>No</option></select></div>"));
            }
            ControlCollection controlCollections10 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty13, " style='padding-bottom:5px;'><select id='ddlDel_", SupplierID_SFQ, "_", id, "_2' style='width:95%;' class='normaltext' onchange=javascript:DelIncluded(this.id,'", SupplierID_SFQ, "_", id, "','2');Calculation('", SupplierID_SFQ, "_", id, "','2','others');>" };
            controlCollections10.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            if (lower1 != "yes")
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes'>Yes</option><option value='no' selected='true'>No</option></select></div>"));
            }
            else
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes' selected='true'>Yes</option><option value='no'>No</option></select></div>"));
            }
            ControlCollection controls11 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str13, " style='padding-bottom:5px;'><select id='ddlDel_", SupplierID_SFQ, "_", id, "_3' style='width:95%;' class='normaltext' onchange=javascript:DelIncluded(this.id,'", SupplierID_SFQ, "_", id, "','3');Calculation('", SupplierID_SFQ, "_", id, "','3','others');>" };
            controls11.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            if (lower2 != "yes")
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes'>Yes</option><option value='no' selected='true'>No</option></select></div>"));
            }
            else
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes' selected='true'>Yes</option><option value='no'>No</option></select></div>"));
            }
            ControlCollection controlCollections11 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty14, " style='padding-bottom:5px;'><select id='ddlDel_", SupplierID_SFQ, "_", id, "_4' style='width:95%;' class='normaltext' onchange=javascript:DelIncluded(this.id,'", SupplierID_SFQ, "_", id, "','4');Calculation('", SupplierID_SFQ, "_", id, "','4','others');>" };
            controlCollections11.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            if (lower3 != "yes")
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes'>Yes</option><option value='no' selected='true'>No</option></select></div>"));
            }
            else
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='yes' selected='true'>Yes</option><option value='no'>No</option></select></div>"));
            }
            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
            if (lower != "yes")
            {
                ControlCollection controls12 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div ", str12, "><input style='width:90%;text-align:right' id='txtDelCost_", SupplierID_SFQ, "_", id, "_1' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','1','others'); type='text' value='", str6, "'></div>" };
                controls12.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            }
            else
            {
                ControlCollection controlCollections12 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div ", str12, "><input disabled='true' style='width:90%;text-align:right' id='txtDelCost_", SupplierID_SFQ, "_", id, "_1' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','1','others'); type='text' value='", str6, "'></div>" };
                controlCollections12.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            }
            if (lower1 != "yes")
            {
                ControlCollection controls13 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div ", empty13, "><input style='width:90%;text-align:right' id='txtDelCost_", SupplierID_SFQ, "_", id, "_2' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','2','others'); type='text' value='", empty7, "'></div>" };
                controls13.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            }
            else
            {
                ControlCollection controlCollections13 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div ", empty13, "><input disabled='true' style='width:90%;text-align:right' id='txtDelCost_", SupplierID_SFQ, "_", id, "_2' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','2','others'); type='text' value='", empty7, "'></div>" };
                controlCollections13.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            }
            if (lower2 != "yes")
            {
                ControlCollection controls14 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div ", str13, "><input style='width:90%;text-align:right' id='txtDelCost_", SupplierID_SFQ, "_", id, "_3' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','3','others'); type='text' value='", str7, "'></div>" };
                controls14.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            }
            else
            {
                ControlCollection controlCollections14 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div ", str13, "><input disabled='true' style='width:90%;text-align:right' id='txtDelCost_", SupplierID_SFQ, "_", id, "_3' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','3','others'); type='text' value='", str7, "'></div>" };
                controlCollections14.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            }
            if (lower3 != "yes")
            {
                ControlCollection controls15 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div ", empty14, "><input style='width:90%;text-align:right' id='txtDelCost_", SupplierID_SFQ, "_", id, "_4' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','4','others'); type='text' value='", empty8, "'></div>" };
                controls15.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            }
            else
            {
                ControlCollection controlCollections15 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div ", empty14, "><input disabled='true' style='width:90%;text-align:right' id='txtDelCost_", SupplierID_SFQ, "_", id, "_4' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','4','others'); type='text' value='", empty8, "'></div>" };
                controlCollections15.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            }
            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
            if (lower4 == "p")
            {
                ControlCollection controls16 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div class='Display_Block' style='padding-bottom:5px; padding-top:5px;'><select id='ddlMarkupType_", SupplierID_SFQ, "_", id, "_1' style='width:85%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", SupplieridList, "','", id, "');Calculation('", SupplierID_SFQ, "_", id, "','1','others');>" };
                controls16.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P' selected='true'>%</option><option value='F'>$</option></select></div>"));
                ControlCollection controlCollections16 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div class='Display_None' style='padding-bottom:5px;'><select id='ddlMarkupType_", SupplierID_SFQ, "_", id, "_2' style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", SupplieridList, "','", id, "');Calculation('", SupplierID_SFQ, "_", id, "','2','others');>" };
                controlCollections16.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P' selected='true'>%</option><option value='F'>$</option></select></div>"));
                ControlCollection controls17 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div  class='Display_None'  style='padding-bottom:5px;'><select id='ddlMarkupType_", SupplierID_SFQ, "_", id, "_3' style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", SupplieridList, "','", id, "');Calculation('", SupplierID_SFQ, "_", id, "','3','others');>" };
                controls17.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P' selected='true'>%</option><option value='F'>$</option></select></div>"));
                ControlCollection controlCollections17 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div  class='Display_None'  style='padding-bottom:5px;'><select id='ddlMarkupType_", SupplierID_SFQ, "_", id, "_4' style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", SupplieridList, "','", id, "');Calculation('", SupplierID_SFQ, "_", id, "','4','others');>" };
                controlCollections17.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P' selected='true'>%</option><option value='F'>$</option></select></div>"));
            }
            else if (lower4 == "f")
            {
                ControlCollection controls18 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div class='Display_Block' style='padding-bottom:5px; padding-top:5px;'><select id='ddlMarkupType_", SupplierID_SFQ, "_", id, "_1' style='width:85%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", SupplieridList, "','", id, "');Calculation('", SupplierID_SFQ, "_", id, "','1','others');>" };
                controls18.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P'>%</option><option value='F' selected='true'>$</option></select></div>"));
                ControlCollection controlCollections18 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div class='Display_None' style='padding-bottom:5px;'><select id='ddlMarkupType_", SupplierID_SFQ, "_", id, "_2' style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", SupplieridList, "','", id, "');Calculation('", SupplierID_SFQ, "_", id, "','2','others');>" };
                controlCollections18.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P'>%</option><option value='F' selected='true'>$</option></select></div>"));
                ControlCollection controls19 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div class='Display_None' style='padding-bottom:5px;'><select id='ddlMarkupType_", SupplierID_SFQ, "_", id, "_3' style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", SupplieridList, "','", id, "');Calculation('", SupplierID_SFQ, "_", id, "','3','others');>" };
                controls19.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P'>%</option><option value='F' selected='true'>$</option></select></div>"));
                ControlCollection controlCollections19 = this.plhQuoteDetails.Controls;
                supplierIDSFQ = new object[] { "<div class='Display_None' style='padding-bottom:5px;'><select id='ddlMarkupType_", SupplierID_SFQ, "_", id, "_4' style='width:65%;' class='normaltext' onchange=javascript:ddlMarkUpType(this.id,'", SupplieridList, "','", id, "');Calculation('", SupplierID_SFQ, "_", id, "','4','others');>" };
                controlCollections19.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
                this.plhQuoteDetails.Controls.Add(new LiteralControl("<option value='P'>%</option><option value='F' selected='true'>$</option></select></div>"));
            }
            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
            ControlCollection controls20 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str12, "><input style='width:90%;text-align:right' id='txtMarkupValue_", SupplierID_SFQ, "_", id, "_1' type='text' value='", str8, "' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','1','others'); ></div>" };
            controls20.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections20 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty13, "><input style='width:90%;text-align:right' id='txtMarkupValue_", SupplierID_SFQ, "_", id, "_2' type='text' value='", empty9, "' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','2','others'); ></div>" };
            controlCollections20.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controls21 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str13, "><input style='width:90%;text-align:right' id='txtMarkupValue_", SupplierID_SFQ, "_", id, "_3' type='text' value='", str9, "' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','3','others'); ></div>" };
            controls21.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections21 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty14, "><input style='width:90%;text-align:right' id='txtMarkupValue_", SupplierID_SFQ, "_", id, "_4' type='text' value='", empty10, "' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','4','others'); ></div>" };
            controlCollections21.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td>"));
            ControlCollection controls22 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str12, "><input style='width:90%;text-align:right' id='txtTotalPrice_", SupplierID_SFQ, "_", id, "_1' type='text' value='", str10, "' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','1','total'); ></div>" };
            controls22.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections22 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty13, "><input style='width:90%;text-align:right' id='txtTotalPrice_", SupplierID_SFQ, "_", id, "_2' type='text' value='", empty11, "' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','2','total'); ></div>" };
            controlCollections22.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controls23 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", str13, "><input style='width:90%;text-align:right' id='txtTotalPrice_", SupplierID_SFQ, "_", id, "_3' type='text' value='", str11, "' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','3','total'); ></div>" };
            controls23.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            ControlCollection controlCollections23 = this.plhQuoteDetails.Controls;
            supplierIDSFQ = new object[] { "<div ", empty14, "><input style='width:90%;text-align:right' id='txtTotalPrice_", SupplierID_SFQ, "_", id, "_4' type='text' value='", empty12, "' onblur=javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);Calculation('", SupplierID_SFQ, "_", id, "','4','total'); ></div>" };
            controlCollections23.Add(new LiteralControl(string.Concat(supplierIDSFQ)));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
            this.plhQuoteDetails.Controls.Add(new LiteralControl("<td style='width:14.5%; text-align:center;'>"));
            if (str14 == "No" && empty15 == "No")
            {
                str14 = str15;
                empty15 = str15;
            }
            else if (str14 == "No")
            {
                str14 = empty15;
            }
            if (isRejected == "true")
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b><span style='color:#1035A5'>", this.objLanguage.GetLanguageConversion("Supplier_Rejected"), "</span></b></span>")));
            }
            else if (str20.ToLower() == "pending")
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b><span style='color:#1035A5'>", this.objLanguage.GetLanguageConversion("Draft"), "</span></b></span>")));
            }
            else if (!(str14 == empty15) || !(str15 == empty16) || !(empty15 == str15))
            {
                ControlCollection controls24 = this.plhQuoteDetails.Controls;
                string[] strArrays = new string[] { "<div ", str12, " style='padding:5px 0px 5px 0px'>", str14, "</div>" };
                controls24.Add(new LiteralControl(string.Concat(strArrays)));
                ControlCollection controlCollections24 = this.plhQuoteDetails.Controls;
                strArrays = new string[] { "<div ", empty13, " style='padding:5px 0px 5px 0px'>", empty15, "</div>" };
                controlCollections24.Add(new LiteralControl(string.Concat(strArrays)));
                ControlCollection controls25 = this.plhQuoteDetails.Controls;
                strArrays = new string[] { "<div ", str13, " style='padding:5px 0px 5px 0px'>", str15, "</div>" };
                controls25.Add(new LiteralControl(string.Concat(strArrays)));
                ControlCollection controlCollections25 = this.plhQuoteDetails.Controls;
                strArrays = new string[] { "<div ", empty14, " style='padding:5px 0px 5px 0px'>", empty16, "</div>" };
                controlCollections25.Add(new LiteralControl(string.Concat(strArrays)));
            }
            else
            {
                this.plhQuoteDetails.Controls.Add(new LiteralControl(string.Concat("<span><b>", empty16, "</b></span>")));
            }
            this.plhQuoteDetails.Controls.Add(new LiteralControl("</td>"));
        }
    }
}