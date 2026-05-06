using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.usercontrol.Item
{
    public partial class item_usercostcentres_new : UserControl
    {
        //protected Label lbl_ItemTitle;

        //protected TextBox txt_ItemTitle;

        //protected TextBox txtQuantity1;

        //protected TextBox txtQuantity2;

        //protected TextBox txtQuantity3;

        //protected TextBox txtQuantity4;

        //protected PlaceHolder plhTab;

        //protected HiddenField hid_OtherCostValues;

        //protected HiddenField hid_OtherCostValues_Load;

        //protected Label Label135;

        //protected TextBox txtOtherCostQty;

        //protected Button Button6;

        //protected RadWindowManager RadWindowManager1;

        //protected HiddenField hid_EstimateItemID;

        //protected HiddenField hid_EstimateType;

        //protected HiddenField hid_PressID;

        //protected HiddenField hid_PaperID;

        //protected HiddenField hid_GuillotineID;

        //protected HiddenField hid_OtherCostValuesFromTB;

        //protected HiddenField hdnOtherCostValues;

        //protected HiddenField hdnEditOtherCostValues;

        //protected HiddenField hid_BookletSectionID;

        //protected HiddenField hdn_IsOthercostsavedFromPopUp;

        //protected HiddenField hdnOtherCostSequenceIDs;

        //protected Panel pnlOtherCostonEdit;

        public string strImagepath = global.strimagepath;

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public int rowcount;

        public long CatID;

        public string OtherCostValues = string.Empty;

        public string MainOrSubtype = string.Empty;

        public string WinOpenType = string.Empty;

        public long EstimateID;

        public long EstimateItemID;

        public string EstimateType = string.Empty;

        public string Type = string.Empty;

        public string pg = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        public int QtyNo = 1;

        public string isfrom_eStore = string.Empty;

        private BaseClass objpage = new BaseClass();

        public long EstimateItemIDForAdd;

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

        public item_usercostcentres_new()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = int.Parse(base.Session["CompanyID"].ToString());
            this.UserID = int.Parse(base.Session["UserID"].ToString());
            if (base.Request.QueryString["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["estid"].ToString());
                if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
                {
                    this.pg = "job";
                }
                else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
                {
                    this.pg = "invoice";
                }
                else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
                {
                    this.pg = "estimate";
                }
                else
                {
                    this.pg = "order";
                }
                if (base.Request.Params["estitemid"] != null)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["estitemid"].ToString());
                    this.EstimateType = base.Request.QueryString["esttype"].ToString();
                }
                if (base.Request.Params["parentestitemid"] != null)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["parentestitemid"].ToString());
                    this.EstimateType = base.Request.QueryString["parentesttype"].ToString();
                    this.hid_EstimateItemID.Value = base.Request.QueryString["parentestitemid"].ToString();
                    this.hid_EstimateType.Value = base.Request.QueryString["parentesttype"].ToString();
                    if ((this.EstimateType == "B" || this.EstimateType == "N" || this.EstimateType == "K") && base.Request.QueryString["booksecid"] != null)
                    {
                        this.hid_BookletSectionID.Value = base.Request.QueryString["booksecid"].ToString();
                    }
                    if (base.Request.QueryString["frm"] == null)
                    {
                        DataTable validate = EstimatesBasePage.PCR_OtherCostSequence_GetIDSToValidate(this.CompanyID, this.EstimateType);
                        this.hdnOtherCostSequenceIDs.Value = "";
                        foreach (DataRow row in validate.Rows)
                        {
                            HiddenField hiddenField = this.hdnOtherCostSequenceIDs;
                            hiddenField.Value = string.Concat(hiddenField.Value, row["OtherCostID"].ToString(), ",");
                        }
                        if (this.hdnOtherCostSequenceIDs.Value.Trim().Length > 0)
                        {
                            this.hdnOtherCostSequenceIDs.Value = this.hdnOtherCostSequenceIDs.Value.Substring(0, this.hdnOtherCostSequenceIDs.Value.Length - 1);
                        }
                    }
                }
                if (base.Request.Params["subitem"] == null)
                {
                    this.MainOrSubtype = "m";
                }
                else
                {
                    this.MainOrSubtype = "s";
                }
            }
            if (base.Request.QueryString["eStore"] != null)
            {
                this.isfrom_eStore = base.Request.QueryString["eStore"].ToString();
            }
            if (!base.IsPostBack)
            {
                this.txtQuantity1.Attributes.Add("style", "text-align:right");
                this.txtQuantity2.Attributes.Add("style", "text-align:right");
                this.txtQuantity3.Attributes.Add("style", "text-align:right");
                this.txtQuantity4.Attributes.Add("style", "text-align:right");
                this.txt_ItemTitle.Focus();
                DataTable dataTable = EstimatesBasePage.estimate_othercost_press_details_select((long)this.CompanyID, this.EstimateItemID, this.EstimateType, Convert.ToInt64(this.hid_BookletSectionID.Value));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    this.hid_PressID.Value = dataRow["PressID"].ToString();
                    this.hid_PaperID.Value = dataRow["PaperID"].ToString();
                    this.hid_GuillotineID.Value = dataRow["GuillotineID"].ToString();
                }
                if (base.Request.Params["type"] != null)
                {
                    DataTable dataTable1 = EstimatesBasePage.Select_OtherCostItemQty(this.EstimateID, this.EstimateItemID);
                    commonClass _commonClass = new commonClass();
                    foreach (DataRow row1 in dataTable1.Rows)
                    {
                        this.EstimateItemIDForAdd = Convert.ToInt64(dataTable1.Rows[0]["EstimateItemID"]);
                        if (base.Request.Params["type"] == "edit")
                        {
                            this.txt_ItemTitle.Text = this.objpage.SpecialDecode(dataTable1.Rows[0]["ItemTitle_New"].ToString());
                        }
                        int num = Convert.ToInt32(row1["Qty1"]);
                        int num1 = Convert.ToInt32(row1["Qty2"]);
                        int num2 = Convert.ToInt32(row1["Qty3"]);
                        int num3 = Convert.ToInt32(row1["Qty4"]);
                        if (num != 0)
                        {
                            this.txtQuantity1.Text = _commonClass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num.ToString()), 0, "", true, false, false);
                        }
                        if (num1 != 0)
                        {
                            this.txtQuantity2.Text = _commonClass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num1.ToString()), 0, "", true, false, false);
                        }
                        if (num2 != 0)
                        {
                            this.txtQuantity3.Text = _commonClass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num2.ToString()), 0, "", true, false, false);
                        }
                        if (num3 == 0)
                        {
                            continue;
                        }
                        this.txtQuantity4.Text = _commonClass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num3.ToString()), 0, "", true, false, false);
                    }
                    if (base.Request.Params["type"].ToString().ToLower() != "edit")
                    {
                        this.Type = "add";
                        foreach (DataRow dataRow1 in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                        {
                            if (base.Request.Params["FromAddAnItem"] != null || !(base.Request.Params["FromAddAnItem"] != "Y"))
                            {
                                continue;
                            }
                            this.txt_ItemTitle.Text = dataRow1["EstimateTitle"].ToString();
                        }
                        if (string.Compare(this.pg, "invoice", true) == 0 || string.Compare(this.pg, "job", true) == 0 || string.Compare(this.pg, "order", true) == 0)
                        {
                            int num4 = 0;
                            if (this.EstimateItemIDForAdd != (long)0)
                            {
                                foreach (DataRow row2 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemIDForAdd).Rows)
                                {
                                    num4 = Convert.ToInt16(row2["QtyNumber"].ToString());
                                }
                                if (num4 != 0)
                                {
                                    if (num4 == 1)
                                    {
                                        this.txtQuantity1.Text = this.txtQuantity1.Text;
                                        this.txtQuantity2.Text = "0";
                                        this.txtQuantity3.Text = "0";
                                        this.txtQuantity4.Text = "0";
                                        return;
                                    }
                                    if (num4 == 2)
                                    {
                                        this.txtQuantity1.Text = this.txtQuantity2.Text;
                                        this.txtQuantity2.Text = "0";
                                        this.txtQuantity3.Text = "0";
                                        this.txtQuantity4.Text = "0";
                                        return;
                                    }
                                    if (num4 == 3)
                                    {
                                        this.txtQuantity1.Text = this.txtQuantity3.Text;
                                        this.txtQuantity2.Text = "0";
                                        this.txtQuantity3.Text = "0";
                                        this.txtQuantity4.Text = "0";
                                        return;
                                    }
                                    if (num4 == 4)
                                    {
                                        this.txtQuantity1.Text = this.txtQuantity4.Text;
                                        this.txtQuantity2.Text = "0";
                                        this.txtQuantity3.Text = "0";
                                        this.txtQuantity4.Text = "0";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.Type = "edit";
                        if (string.Compare(this.pg, "invoice", true) == 0 || string.Compare(this.pg, "job", true) == 0)
                        {
                            foreach (DataRow dataRow2 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                            {
                                this.QtyNo = Convert.ToInt16(dataRow2["QtyNumber"].ToString());
                            }
                        }
                        if (string.Compare(this.pg, "order", true) == 0)
                        {
                            this.QtyNo = 1;
                        }
                        string str = EstimatesBasePage.estimate_othercost_select_new(this.CompanyID, base.Request.Params["esttype"].ToString(), this.EstimateItemID, "main");
                        if (!string.IsNullOrEmpty(str))
                        {
                            this.hdnOtherCostValues.Value = str;
                            this.pnlOtherCostonEdit.Visible = true;
                            string str1 = EstimateBasePage.estimates_othercost_selectall(this.CompanyID);
                            string[] strArrays = str1.Split(new char[] { 'µ' });
                            this.hid_OtherCostValuesFromTB.Value = strArrays[1].ToString();
                            return;
                        }
                    }
                }
            }
        }
    }
}