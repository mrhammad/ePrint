using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Order;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.orders
{
    public partial class order_cost_view : System.Web.UI.UserControl
    {
        private long EstimateID;

        private long OrderItemID;

        private int CompanyID;

        private int UserID;

        private string module = string.Empty;

        private commonClass comm = new commonClass();

        private decimal MainItemPriceExcMarkup;

        private decimal MainItemMarkupPrice;

        private BaseClass objBase = new BaseClass();

        private languageClass ObjLang = new languageClass();

        private string MeasurementValue = string.Empty;

        private BasePage objPage = new BasePage();

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

        public order_cost_view()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            }
            this.MeasurementValue = this.objPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (base.Session["UserID"] != null)
            {
                this.UserID = Convert.ToInt32(base.Session["UserID"]);
            }
            if (base.Request.Params["EstimateID"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["EstimateID"]);
            }
            if (base.Request.Params["OrderItemID"] != null)
            {
                this.OrderItemID = Convert.ToInt64(base.Request.Params["OrderItemID"]);
            }
            if (base.Request.Params["module"] != null)
            {
                this.module = base.Request.Params["module"].ToString();
            }
            if (!base.IsPostBack)
            {
                DataSet dataSet = OrderBasePage.Select_OrderItems_WithAdditionalItems(this.OrderItemID);
                DataTable item = dataSet.Tables[0];
                DataTable dataTable = dataSet.Tables[1];
                int num = 0;
                foreach (DataRow row in item.Rows)
                {
                    if (num == 0)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl("<table style='width: 98%;'><tr>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:20%;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width: 10%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Item Code</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width: 18%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Qty/Selected Options</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        if (row["MatrixType"].ToString().ToLower() == "g")
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                            ControlCollection controls = this.plhItemCostView.Controls;
                            string[] languageConversion = new string[] { " <span class='Headertext'>", this.ObjLang.GetLanguageConversion("Width"), " (", this.MeasurementValue, ")</span>" };
                            controls.Add(new LiteralControl(string.Concat(languageConversion)));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                            ControlCollection controlCollections = this.plhItemCostView.Controls;
                            string[] strArrays = new string[] { " <span class='Headertext'>", this.ObjLang.GetLanguageConversion("Height"), " (", this.MeasurementValue, ")</span>" };
                            controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:15%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>Cost Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>Mark Up (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:15%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>Selling Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</tr>"));
                        if (row["MatrixType"].ToString().ToLower() != "g")
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<tr><td colspan='5'></td></tr>"));
                        }
                        else
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<tr><td colspan='7'></td></tr>"));
                        }
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl("<tr>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:20%;'>"));
                    if (!row["ItemTitle"].ToString().Contains("<br/>"))
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'><b>", this.objBase.SpecialDecode(row["CatalogueName"].ToString()), "</b></span>")));
                    }
                    else
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'><b>", this.objBase.SpecialDecode(row["ItemTitle"].ToString()), "</b></span>")));
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%;text-align: right;'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.objBase.SpecialDecode(row["ItemCode"].ToString()), "</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:18%; text-align: right;'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Quantity"]), 0, "", true, false, true), "</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                    if (row["MatrixType"].ToString().ToLower() == "g")
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Width"]), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Height"]), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.MainItemPriceExcMarkup = Convert.ToDecimal(row["MainItemPrice"]) - Convert.ToDecimal(row["MainItemMarkupPrice"]);
                    this.MainItemMarkupPrice = Convert.ToDecimal(row["MainItemMarkupPrice"]);
                    this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:15%; text-align: right;'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.MainItemPriceExcMarkup.ToString()), 0, "", false, false, true), "</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.MainItemMarkupPrice), 0, "", false, false, true), "</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:15%; text-align: right;'>"));
                    ControlCollection controls1 = this.plhItemCostView.Controls;
                    object[] objArray = new object[] { "<span class='normaltext' id='spnSellingInMarkup_", num, "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MainItemPrice"]), 0, "", false, false, true), "</span>" };
                    controls1.Add(new LiteralControl(string.Concat(objArray)));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</tr>"));
                    if (row["MatrixType"].ToString().ToLower() != "g")
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl("<tr><td colspan='5'><br/></td></tr>"));
                    }
                    else
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl("<tr><td colspan='7'><br/></td></tr>"));
                    }
                    int num1 = 0;
                    decimal num2 = new decimal(0);
                    decimal num3 = new decimal(0);
                    decimal num4 = new decimal(0);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        num3 = Convert.ToDecimal(dataRow["TotalPrice"]) - Convert.ToDecimal(dataRow["MarkupValue"]);
                        num2 = num2 + num3;
                        num4 = num4 + Convert.ToDecimal(dataRow["MarkupValue"]);
                        if (num1 != 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<tr>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:20%;'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float: left;'><span class='normaltext'>", this.objBase.SpecialDecode(dataRow["webothercostName"].ToString()), "</span></div>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        }
                        else
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<tr>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:20%;'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='normaltext'><b>Additional Option(s)</b></span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                            if (row["MatrixType"].ToString().ToLower() != "g")
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl("<td colspan='4'></td></tr>"));
                            }
                            else
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl("<td colspan='6'></td></tr>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl("<tr>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:20%;'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float: left;'><span class='normaltext'>", this.objBase.SpecialDecode(dataRow["webothercostName"].ToString()), "</span></div>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:18%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:18%; text-align: right;'>"));
                        ControlCollection controlCollections1 = this.plhItemCostView.Controls;
                        object[] objArray1 = new object[] { " <span class='normaltext' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Quantity"]), 0, "", true, false, true), "</span><span class='normaltext'>", dataRow["SelectedValue"], " </span>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(objArray1)));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        if (row["MatrixType"].ToString().ToLower() == "g")
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:15%; text-align: right;'>"));
                        if (!(dataRow["ParentWebOtherCostID"].ToString() == "0") || !(dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num3.ToString()), 0, "", false, false, true), "</span>")));
                        }
                        else
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span style='display:none;' class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(0), 0, "", false, false, true), "</span>")));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                        if (!(dataRow["ParentWebOtherCostID"].ToString() == "0") || !(dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["MarkupValue"]), 0, "", false, false, true), "</span>")));
                        }
                        else
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span style='display:none;' class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(0), 0, "", false, false, true), "</span>")));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:15%; text-align: right;'>"));
                        if (!(dataRow["ParentWebOtherCostID"].ToString() == "0") || !(dataRow["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                        {
                            ControlCollection controls2 = this.plhItemCostView.Controls;
                            object[] objArray2 = new object[] { "<span class='normaltext' id='spnSellingInMarkup_", num, "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalPrice"]), 0, "", false, false, true), "</span>" };
                            controls2.Add(new LiteralControl(string.Concat(objArray2)));
                        }
                        else
                        {
                            ControlCollection controlCollections2 = this.plhItemCostView.Controls;
                            object[] objArray3 = new object[] { " <span style='display:none;' class='normaltext' id='spnSellingInMarkup_", num, "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(0), 0, "", false, false, true), "</span>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(objArray3)));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</tr>"));
                        num1++;
                    }
                    if (num1 != 0)
                    {
                        if (row["MatrixType"].ToString().ToLower() != "g")
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<tr><td colspan='7'><div align='left' class='SummaryItemDifferentiate'></div></td></tr>"));
                        }
                        else
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<tr><td colspan='7'><div align='left' class='SummaryItemDifferentiate'></div></td></tr>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<tr>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:20%;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float: left;'><span class='Headertext'>Total</span></div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:18%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        if (row["MatrixType"].ToString().ToLower() == "g")
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:15%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:10%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        decimal num5 = (Convert.ToDecimal(row["MainItemPrice"]) + num2) + num4;
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:15%; text-align: right;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<td style='width:15%; text-align: right;'>"));
                        ControlCollection controls3 = this.plhItemCostView.Controls;
                        object[] objArray4 = new object[] { "<span class='normaltext' style='font-weight:bold;' id='spnSellingInMarkup_", num, "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num5), 0, "", false, false, true), "</span>" };
                        controls3.Add(new LiteralControl(string.Concat(objArray4)));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</td>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</tr>"));
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl("</table>"));
                    num++;
                }
            }
        }
    }
}