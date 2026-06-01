<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_summary_total.ascx.cs" Inherits="ePrint.usercontrol.Item.item_summary_total" %>
<table id="tblItemTotal" width="97%" cellpadding="0" cellspacing="0" border="0">
    <tr id="tr1">
        <td valign="top" width="100%" style="padding-top: 2px">
            <asp:PlaceHolder ID="plhItemTotal" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
    <tr>
        <td valign="top" width="100%">
            <div style="float: right; border: 0px solid green; margin-top: 2px;">
                <%--<asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" OnClick="OnClick_btnCancel" />--%>
                <%--As per the instruction this Save & Save stay functionality included in Save&Stay and Save btn Click of Summary page so these two btns made display none--%>
                <div style="float: right; padding-right: 10px">
                    <div id="div_btnstay" style="display: none">
                        <asp:Button ID="btnStay" CssClass="button" runat="server" Text="Save" OnClick="btnStay_Click" />
                    </div>
                    <div id="div_btnsave" style="display: none">
                        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClick="btnStay_Click" Visible="false" />
                    </div>
                    <div id="div_saveprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                    <div id="div_stayprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <asp:HiddenField runat="server" Value="" ID="hdnSaveValues" />
                <%-- Items are by Using Web Service--%>
            </div>
            <%--<div align="left" id="summaryHRLine" style="width: 100%;">
</div>--%>
            <asp:HiddenField ID="hdnProfitmarginvalue" runat="server" Value="" />
            <asp:HiddenField ID="hdnProfitMarginInPrice" runat="server" Value="" />
            <asp:HiddenField ID="hdnSutotalold" runat="server" Value="" />
            <asp:HiddenField ID="hdnTaxPrice" runat="server" Value="" />
            <asp:HiddenField ID="hdn_Description" runat="server" Value="" />
        </td>
    </tr>
</table>


<script type="text/javascript">
   
    //function getcost(EstimateItemID, ItemNo) {

    //    debugger;
    //    var _cost = document.getElementById("spnCostExMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    //    var _cost1 = document.getElementById("spnCostExMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    //    var _cost2 = document.getElementById("spnCostExMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    //    var _cost3 = document.getElementById("spnCostExMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    //    var cost = _cost.value.replace(/[^\d.-]/g, '');
    //    var cost1 = _cost1.value.replace(/[^\d.-]/g, '');
    //    var cost2 = _cost2.value.replace(/[^\d.-]/g, '');
    //    var cost3 = _cost3.value.replace(/[^\d.-]/g, '');

    //    var markup1 = document.getElementById("spnMarkupPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var markup2 = document.getElementById("spnMarkupPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var markup3 = document.getElementById("spnMarkupPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var markup4 = document.getElementById("spnMarkupPrice4_" + EstimateItemID + "_" + ItemNo + "");

    //    var costInMarkup1 = document.getElementById("spnCostInMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    //    var costInMarkup2 = document.getElementById("spnCostInMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    //    var costInMarkup3 = document.getElementById("spnCostInMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    //    var costInMarkup4 = document.getElementById("spnCostInMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    //    // var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + ItemNo + "");
    //    //var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + ItemNo + ""); //since only one tax% exists for all qty

    //    //var hdn_ProfitMarginPercentage1 = document.getElementById("hdn_ProfitMarginPercentage1_" + EstimateItemID + "_" + ItemNo + "");
    //    //var hdn_ProfitMarginPercentage2 = document.getElementById("hdn_ProfitMarginPercentage2_" + EstimateItemID + "_" + ItemNo + "");
    //    //var hdn_ProfitMarginPercentage3 = document.getElementById("hdn_ProfitMarginPercentage3_" + EstimateItemID + "_" + ItemNo + "");
    //    //var hdn_ProfitMarginPercentage4 = document.getElementById("hdn_ProfitMarginPercentage4_" + EstimateItemID + "_" + ItemNo + "");

    //    var hdn_ProfitMarginPrice1 = document.getElementById("hdn_ProfitMarginPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_ProfitMarginPrice2 = document.getElementById("hdn_ProfitMarginPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_ProfitMarginPrice3 = document.getElementById("hdn_ProfitMarginPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_ProfitMarginPrice4 = document.getElementById("hdn_ProfitMarginPrice4_" + EstimateItemID + "_" + ItemNo + "");

    //    var hdn_SubTotal1 = document.getElementById("hdn_SubTotal1_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_SubTotal2 = document.getElementById("hdn_SubTotal2_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_SubTotal3 = document.getElementById("hdn_SubTotal3_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_SubTotal4 = document.getElementById("hdn_SubTotal4_" + EstimateItemID + "_" + ItemNo + "");

    //    var hdn_SellingPrice1 = document.getElementById("hdn_SellingPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_SellingPrice2 = document.getElementById("hdn_SellingPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_SellingPrice3 = document.getElementById("hdn_SellingPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_SellingPrice4 = document.getElementById("hdn_SellingPrice4_" + EstimateItemID + "_" + ItemNo + "");

    //    var hdn_GrossProfitPercentage1 = document.getElementById("hdn_GrossProfitPercentage1_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_GrossProfitPercentage2 = document.getElementById("hdn_GrossProfitPercentage2_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_GrossProfitPercentage3 = document.getElementById("hdn_GrossProfitPercentage3_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_GrossProfitPercentage4 = document.getElementById("hdn_GrossProfitPercentage4_" + EstimateItemID + "_" + ItemNo + "");

    //    var hdn_GrossProfitPrice1 = document.getElementById("hdn_GrossProfitPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_GrossProfitPrice2 = document.getElementById("hdn_GrossProfitPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_GrossProfitPrice3 = document.getElementById("hdn_GrossProfitPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_GrossProfitPrice4 = document.getElementById("hdn_GrossProfitPrice4_" + EstimateItemID + "_" + ItemNo + "");

    //    var hdn_CostExMarkup1 = document.getElementById("hdn_CostExMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_CostExMarkup2 =document.getElementById("hdn_CostExMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_CostExMarkup3 =document.getElementById("hdn_CostExMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_CostExMarkup4 = document.getElementById("hdn_CostExMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    //     var hdn_CostInMarkup1 = document.getElementById("hdn_CostInMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_CostInMarkup2 =document.getElementById("hdn_CostInMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_CostInMarkup3 =document.getElementById("hdn_CostInMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_CostInMarkup4 =document.getElementById("hdn_CostInMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    //    if (!isNaN(markup1.innerText.replace(/[^\d.-]/g, '')) && Number(markup1.innerText.replace(/[^\d.-]/g, '')) > 0) {
    //        markup1 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup1.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    //    }
    //    else {
    //        markup1 = "0.00";
    //    }

    //    if (!isNaN(markup2.innerText.replace(/[^\d.-]/g, '')) && Number(markup2.innerText.replace(/[^\d.-]/g, '')) > 0) {
    //        markup2 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup2.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    //    }
    //    else {
    //        markup2 = "0.00";
    //    }
    //    if (!isNaN(markup3.innerText.replace(/[^\d.-]/g, '')) && Number(markup3.innerText.replace(/[^\d.-]/g, '')) > 0) {
    //        markup3 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup3.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    //    }
    //    else {
    //        markup3 = "0.00";
    //    }
    //    if (!isNaN(markup4.innerText.replace(/[^\d.-]/g, '')) && Number(markup4.innerText.replace(/[^\d.-]/g, '')) > 0) {
    //        markup4 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup4.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    //    }
    //    else {
    //        markup4 = "0.00";
    //    }



    //    if (!isNaN(cost) && Number(cost) > 0) {
    //        cost = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost), 0, '', false, false, false);
    //    }
    //    else {
    //        cost = "0.00";
    //    }

    //    if (!isNaN(cost1) && Number(cost1) > 0) {
    //        cost1 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1), 0, '', false, false, false);
    //    }
    //    else {
    //        cost1 = "0.00";
    //    }
    //    if (!isNaN(cost2) && Number(cost2) > 0) {
    //        cost2 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2), 0, '', false, false, false);
    //    }
    //    else {
    //        cost2 = "0.00";
    //    }
    //    if (!isNaN(cost3) && Number(cost3) > 0) {
    //        cost3 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3), 0, '', false, false, false);
    //    }
    //    else {
    //        cost3 = "0.00";
    //    }

    //    hdn_CostExMarkup1.value = cost;
    //    hdn_CostExMarkup2.value = cost1;
    //    hdn_CostExMarkup3.value = cost2;
    //    hdn_CostExMarkup4.value = cost3;

    //    var ddlprofitmarginvalue1 = Number(document.getElementById("txtProfitMarginPercentage1_" + EstimateItemID + "_" + ItemNo + "").value);
    //    var ddlprofitmarginvalue2 = Number(document.getElementById("txtProfitMarginPercentage2_" + EstimateItemID + "_" + ItemNo + "").value);
    //    var ddlprofitmarginvalue3 = Number(document.getElementById("txtProfitMarginPercentage3_" + EstimateItemID + "_" + ItemNo + "").value);
    //    var ddlprofitmarginvalue4 = Number(document.getElementById("txtProfitMarginPercentage4_" + EstimateItemID + "_" + ItemNo + "").value);

    //    var txtproftimarge = document.getElementById("txtProfitMarginPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtproftimarge1 = document.getElementById("txtProfitMarginPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtproftimarge2 = document.getElementById("txtProfitMarginPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtproftimarge3 = document.getElementById("txtProfitMarginPrice4_" + EstimateItemID + "_" + ItemNo + "");

    //    costInMarkup1.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup1) + Number(cost), 0, '', false, false, false), true);
    //    costInMarkup2.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup2) + Number(cost1), 0, '', false, false, false), true);
    //    costInMarkup3.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup3) + Number(cost2), 0, '', false, false, false), true);
    //    costInMarkup4.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup4) + Number(cost3), 0, '', false, false, false), true);

    //    hdn_CostInMarkup1.value = costInMarkup1.innerText.replace(/[^\d.-]/g, '');
    //    hdn_CostInMarkup2.value = costInMarkup2.innerText.replace(/[^\d.-]/g, '');
    //    hdn_CostInMarkup3.value = costInMarkup3.innerText.replace(/[^\d.-]/g, '');
    //    hdn_CostInMarkup4.value = costInMarkup4.innerText.replace(/[^\d.-]/g, '');


    //    txtproftimarge.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost) * Number(ddlprofitmarginvalue1) / 100, 0, '', false, false, false);
    //    txtproftimarge1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1) * Number(ddlprofitmarginvalue2) / 100, 0, '', false, false, false);
    //    txtproftimarge2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2) * Number(ddlprofitmarginvalue3) / 100, 0, '', false, false, false);
    //    txtproftimarge3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3) * Number(ddlprofitmarginvalue4) / 100, 0, '', false, false, false);

    //    hdn_ProfitMarginPrice1.value = txtproftimarge.value;
    //    hdn_ProfitMarginPrice2.value = txtproftimarge1.value;
    //    hdn_ProfitMarginPrice3.value = txtproftimarge2.value;
    //    hdn_ProfitMarginPrice4.value = txtproftimarge3.value;



    //    var txtsubtotal = document.getElementById("txtSubTotal1_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsubtotal1 = document.getElementById("txtSubTotal2_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsubtotal2 = document.getElementById("txtSubTotal3_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsubtotal3 = document.getElementById("txtSubTotal4_" + EstimateItemID + "_" + ItemNo + "");


    //    txtsubtotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost) + Number(txtproftimarge.value), 0, '', false, false, false);
    //    txtsubtotal1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1) + Number(txtproftimarge1.value), 0, '', false, false, false);
    //    txtsubtotal2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2) + Number(txtproftimarge2.value), 0, '', false, false, false);
    //    txtsubtotal3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3) + Number(txtproftimarge3.value), 0, '', false, false, false);

    //    hdn_SubTotal1.value = txtsubtotal.value;
    //    hdn_SubTotal2.value = txtsubtotal1.value;
    //    hdn_SubTotal3.value = txtsubtotal2.value;
    //    hdn_SubTotal4.value = txtsubtotal3.value;

    //    var txtsellingprice = document.getElementById("spnSellingPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsellingprice1 = document.getElementById("spnSellingPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsellingprice2 = document.getElementById("spnSellingPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsellingprice3 = document.getElementById("spnSellingPrice4_" + EstimateItemID + "_" + ItemNo + "");

    //    var lbltax = document.getElementById("spnTaxPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var lbltax1 = document.getElementById("spnTaxPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var lbltax2 = document.getElementById("spnTaxPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var lbltax3 = document.getElementById("spnTaxPrice4_" + EstimateItemID + "_" + ItemNo + "");


    //    txtsellingprice.innerText = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost) * ddlprofitmarginvalue1) / 100 + Number(cost) + Number(lbltax.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    //    txtsellingprice1.innerText = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost1) * ddlprofitmarginvalue2) / 100 + Number(cost1) + Number(lbltax1.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    //    txtsellingprice2.innerText = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost2) * ddlprofitmarginvalue3) / 100 + Number(cost2) + Number(lbltax2.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    //    txtsellingprice3.innerText = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost3) * ddlprofitmarginvalue4) / 100 + Number(cost3) + Number(lbltax3.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);

    //    hdn_SellingPrice1.value = txtsellingprice.innerText;
    //    hdn_SellingPrice2.value = txtsellingprice1.innerText;
    //    hdn_SellingPrice3.value = txtsellingprice2.innerText;
    //    hdn_SellingPrice4.value = txtsellingprice3.innerText;


    //    var spnGrossProfitPrice1 = document.getElementById("spnGrossProfitPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var spnGrossProfitPrice2 = document.getElementById("spnGrossProfitPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var spnGrossProfitPrice3 = document.getElementById("spnGrossProfitPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var spnGrossProfitPrice4 = document.getElementById("spnGrossProfitPrice4_" + EstimateItemID + "_" + ItemNo + "");


    //    var spnGrossProfitPercentage1 =document.getElementById("spnGrossProfitPercentage1_" + EstimateItemID + "_" + ItemNo + "");
    //    var spnGrossProfitPercentage2 =document.getElementById("spnGrossProfitPercentage2_" + EstimateItemID + "_" + ItemNo + "");
    //    var spnGrossProfitPercentage3 =document.getElementById("spnGrossProfitPercentage3_" + EstimateItemID + "_" + ItemNo + "");
    //    var spnGrossProfitPercentage4 =document.getElementById("spnGrossProfitPercentage4_" + EstimateItemID + "_" + ItemNo + "");

    //    if (!isNaN(txtsubtotal.value) && Number(txtsubtotal.value) > 0) {
    //        var GrossPercentage1 = 0;
    //        var GrossValue1 = GrossProfit_Value(Number(cost), Number(txtsubtotal.value));
    //        if (Number(txtsubtotal.value) != "0") {
    //            spnGrossProfitPrice1.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue1, 0, '', false, false, false);

    //            GrossPercentage1 = GrossProfit_Percentage(Number(txtsubtotal.value), Number(GrossValue1));
    //            GrossPercentage1 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage1, 0, '', false, false, false);
    //            spnGrossProfitPercentage1.innerHTML = "" + GrossPercentage1 + "%";

    //            hdn_GrossProfitPrice1.value = spnGrossProfitPrice1.innerHTML.replace(/[^\d.-]/g, '');
    //            hdn_GrossProfitPercentage1.value = spnGrossProfitPercentage1.innerHTML.replace(/[^\d.-]/g, '');
    //        }
    //    }

    //       if (!isNaN(txtsubtotal1.value) && Number(txtsubtotal1.value) > 0) {
    //        var GrossPercentage2 = 0;
    //        var GrossValue2 = GrossProfit_Value(Number(cost1), Number(txtsubtotal1.value));
    //        if (Number(txtsubtotal1.value) != "0") {
    //            spnGrossProfitPrice2.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue2, 0, '', false, false, false);

    //            GrossPercentage2 = GrossProfit_Percentage(Number(txtsubtotal1.value), Number(GrossValue2));
    //            GrossPercentage2 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage2, 0, '', false, false, false);
    //            spnGrossProfitPercentage2.innerHTML = "" + GrossPercentage2 + "%";

    //             hdn_GrossProfitPrice2.value = spnGrossProfitPrice2.innerHTML.replace(/[^\d.-]/g, '');
    //            hdn_GrossProfitPercentage2.value = spnGrossProfitPercentage2.innerHTML.replace(/[^\d.-]/g, '');
    //        }
    //    }

    //       if (!isNaN(txtsubtotal2.value) && Number(txtsubtotal2.value) > 0) {
    //        var GrossPercentage3 = 0;
    //        var GrossValue3 = GrossProfit_Value(Number(cost2), Number(txtsubtotal2.value));
    //        if (Number(txtsubtotal2.value) != "0") {
    //            spnGrossProfitPrice3.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue3, 0, '', false, false, false);

    //            GrossPercentage3 = GrossProfit_Percentage(Number(txtsubtotal2.value), Number(GrossValue3));
    //            GrossPercentage3 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage3, 0, '', false, false, false);
    //            spnGrossProfitPercentage3.innerHTML = "" + GrossPercentage3 + "%";

    //             hdn_GrossProfitPrice3.value = spnGrossProfitPrice3.innerHTML.replace(/[^\d.-]/g, '');
    //            hdn_GrossProfitPercentage3.value = spnGrossProfitPercentage3.innerHTML.replace(/[^\d.-]/g, '');
    //        }
    //    }

    //       if (!isNaN(txtsubtotal3.value) && Number(txtsubtotal3.value) > 0) {
    //        var GrossPercentage4 = 0;
    //        var GrossValue4 = GrossProfit_Value(Number(cost3), Number(txtsubtotal3.value));
    //        if (Number(txtsubtotal3.value) != "0") {
    //            spnGrossProfitPrice4.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue4, 0, '', false, false, false);

    //            GrossPercentage4 = GrossProfit_Percentage(Number(txtsubtotal3.value), Number(GrossValue4));
    //            GrossPercentage4 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage4, 0, '', false, false, false);
    //            spnGrossProfitPercentage4.innerHTML = "" + GrossPercentage4 + "%";

    //             hdn_GrossProfitPrice4.value = spnGrossProfitPrice4.innerHTML.replace(/[^\d.-]/g, '');
    //            hdn_GrossProfitPercentage4.value = spnGrossProfitPercentage4.innerHTML.replace(/[^\d.-]/g, '');
    //        }
    //    }


    //    var ddltax = document.getElementById("ddlTax_" + EstimateItemID + "_" + ItemNo + "");
    //    //gettaxvalue(Number(ddltax.options[ddltax.selectedIndex].value));
    //    gettaxvalue(ddltax.value, EstimateItemID, ItemNo);
    //}

    //function gettaxvalue(taxValue, EstimateItemID, ItemNo) {
    //    //alert(taxValue);
    //    //var tax = GetTaxValueNew(taxValue);
    //    var tax = taxValue;
    //    if (tax != '') {
    //        tax = Number(tax.split('~')[1]);
    //        //alert(tax);
    //    }
    //    var lbltax = document.getElementById("spnTaxPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var lbltax1 = document.getElementById("spnTaxPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var lbltax2 = document.getElementById("spnTaxPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var lbltax3 = document.getElementById("spnTaxPrice4_" + EstimateItemID + "_" + ItemNo + "");
    //    var ddlprofitmarginvalue1 = Number(document.getElementById("txtProfitMarginPercentage1_" + EstimateItemID + "_" + ItemNo + "").value);
    //    var txtsellingprice = document.getElementById("spnSellingPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsellingprice1 = document.getElementById("spnSellingPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsellingprice2 = document.getElementById("spnSellingPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsellingprice3 = document.getElementById("spnSellingPrice4_" + EstimateItemID + "_" + ItemNo + "");
    //    var cost = document.getElementById("spnCostExMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    //    var cost1 = document.getElementById("spnCostExMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    //    var cost2 = document.getElementById("spnCostExMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    //    var cost3 = document.getElementById("spnCostExMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    //    var txtsubtotal = document.getElementById("txtSubTotal1_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsubtotal1 = document.getElementById("txtSubTotal2_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsubtotal2 = document.getElementById("txtSubTotal3_" + EstimateItemID + "_" + ItemNo + "");
    //    var txtsubtotal3 = document.getElementById("txtSubTotal4_" + EstimateItemID + "_" + ItemNo + "");

    //    var hdn_TaxPrice1 = document.getElementById("hdn_TaxPrice1_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_TaxPrice2 = document.getElementById("hdn_TaxPrice2_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_TaxPrice3 = document.getElementById("hdn_TaxPrice3_" + EstimateItemID + "_" + ItemNo + "");
    //    var hdn_TaxPrice4 = document.getElementById("hdn_TaxPrice4_" + EstimateItemID + "_" + ItemNo + "");

    //    //cost.value = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost.value), 0, '', false, false, false), true);
    //    //cost1.value = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1.value), 0, '', false, false, false), true);
    //    //cost2.value = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2.value), 0, '', false, false, false), true);
    //    //cost3.value = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3.value), 0, '', false, false, false), true);


    //    lbltax.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal.value) * Number(tax)) / 100, 0, '', false, false, false), true);
    //    lbltax1.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal1.value) * Number(tax)) / 100, 0, '', false, false, false), true);
    //    lbltax2.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal2.value) * Number(tax)) / 100, 0, '', false, false, false), true);
    //    lbltax3.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal3.value) * Number(tax)) / 100, 0, '', false, false, false), true);

    //    hdn_TaxPrice1.value = lbltax.innerText.replace(/[^\d.-]/g, '');
    //    hdn_TaxPrice2.value = lbltax1.innerText.replace(/[^\d.-]/g, '');
    //    hdn_TaxPrice3.value = lbltax2.innerText.replace(/[^\d.-]/g, '');
    //    hdn_TaxPrice4.value = lbltax3.innerText.replace(/[^\d.-]/g, '');


    //    var ddlprofitmarginvalue = Number(ddlprofitmarginvalue1);
    //    txtsellingprice.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost.value.replace(/[^\d.-]/g, '')) * ddlprofitmarginvalue) / 100 + Number(cost.value.replace(/[^\d.-]/g, '')) + Number(lbltax.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false), true);
    //    txtsellingprice1.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost1.value.replace(/[^\d.-]/g, '')) * ddlprofitmarginvalue) / 100 + Number(cost1.value.replace(/[^\d.-]/g, '')) + Number(lbltax1.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false), true);
    //    txtsellingprice2.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost2.value.replace(/[^\d.-]/g, '')) * ddlprofitmarginvalue) / 100 + Number(cost2.value.replace(/[^\d.-]/g, '')) + Number(lbltax2.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false), true);
    //    txtsellingprice3.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost3.value.replace(/[^\d.-]/g, '')) * ddlprofitmarginvalue) / 100 + Number(cost3.value.replace(/[^\d.-]/g, '')) + Number(lbltax3.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false), true);

    //}
</script>
