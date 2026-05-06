// JScript File
function roundNumber(rnum, rlength) {

    return rnum;
    /*
    var newnumber = Math.round(rnum*Math.pow(10,rlength))/Math.pow(10,rlength);
    newnumber = parseFloat(newnumber).toFixed(2);
    return newnumber; */
}

function GrossProfit_Value(CostPriceExMark, SubToal) {
    var GrossValue = Number(SubToal) - Number(CostPriceExMark);
    return GrossValue;
}
function GrossProfit_Percentage(SubToal, GrossValue) {
    var GrossPercentage = (Number(GrossValue) / Number(SubToal)) * 100;
    return GrossPercentage;
}

function ProfitMarginShow_SinglePadLarge(priftValue, EstimateItemID, QtyCount) {
    
    for (var j = 0; j < QtyCount; j++) {
        var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "");
        var MarkUp = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "");
        var SellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + EstimateItemID + "_" + j + "");
        var ProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + j + "");
        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "");
        var Tax = document.getElementById("span_Tax_" + EstimateItemID + "_" + j + "");
        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_0");
        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "");
        var GrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + j + "");

        var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "_" + j + "");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateItemID + "_" + j + "");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "_" + j + "");

        var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);
        var MarkUpValue = RemoveDollorAndComma(MarkUp.innerHTML);
        var SellingPriceInMarkupValue = RemoveDollorAndComma(SellingPriceInMarkup.innerHTML);
        
        var ProfitMarginValue = RemoveDollorAndComma(ProfitMargin.innerHTML);
        var TaxValue = RemoveDollorAndComma(Tax.innerHTML);
        var TotalSellingPriceValue = RemoveDollorAndComma(TotalSellingPrice.innerHTML);
        var GrossProfitValue = RemoveDollorAndComma(GrossProfit.innerHTML);

        txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPriceInMarkupValue, 0, '', false, false, false);
        

        var Profit = (Number(SellingPriceInMarkupValue) * Number(priftValue)) / 100;
        ProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Profit, 0, '', false, false, false);

        txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Profit) + Number(txtSubTotal.value), 0, '', false, false, false);
        TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(ddlTax.value))) / 100;
        Tax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, false);
        var SellingPrice = Number(TaxValue) + Number(txtSubTotal.value);
        TotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, false);

        var subTotal = txtSubTotal.value;
        var GrossValue = GrossProfit_Value(Number(CostPriceExMarkup), Number(subTotal));
        if (Number(txtSubTotal.value) == "0") {
            GrossProfit.innerHTML = "(0.00%) " + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, false);
        }
        else {
            var GrossPercentage = GrossProfit_Percentage(Number(subTotal), Number(GrossValue));
            GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, false);
            GrossProfit.innerHTML = "(" + GrossPercentage + "%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, false);
        }
        try {
            Taxsummary.innerHTML = Tax.innerHTML;
            TotalSellingPricesummary.innerHTML = TotalSellingPrice.innerHTML;
            GrossProfitsummary.innerHTML = GrossProfit.innerHTML;
        } catch (err) { }
    }

}
function SinglePadLarge_TaxOnChange(TaxPercent, EstimateItemID, QtyCount) {
    for (var j = 0; j < QtyCount; j++) {
        var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "");
        var span_ProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + j + "");
        var span_Markup = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "");        
        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "");
        var Tax = document.getElementById("span_Tax_" + EstimateItemID + "_" + j + "");
        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "");
        var GrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + j + "");

        var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "_" + j + "");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateItemID + "_" + j + "");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "_" + j + "");

        var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);
        var Profit = RemoveDollorAndComma(span_ProfitMargin.innerHTML);
        var MarkUpValue = RemoveDollorAndComma(span_Markup.innerHTML);
        var TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(TaxPercent))) / 100;

        Tax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);

        var SellingPrice = Number(txtSubTotal.value) + Number(TaxValue);
        SellingPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, true);

        TotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellingPrice;
        try {
            Taxsummary.innerHTML = Tax.innerHTML;
            TotalSellingPricesummary.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellingPrice;
        } catch (err) { }
        var subTotal = txtSubTotal.value;
        var GrossValue = GrossProfit_Value(Number(CostPriceExMarkup), Number(subTotal));
        if (SellingPrice == "0") {
            GrossProfit.innerHTML = "(0.00%)" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue;
            try {
                GrossProfitsummary.innerHTML = GrossProfit.innerHTML;
            } catch (err) { }
        }
        else {
            var GrossPercentage = GrossProfit_Percentage(Number(subTotal), Number(GrossValue));
            GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, true);
            GrossProfit.innerHTML = "(" + GrossPercentage + "%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);
            try {
                GrossProfitsummary.innerHTML = GrossProfit.innerHTML;
            } catch (err) { }
        }
    }
}
function OnBlur_SinglePadLarge_SubTotal(subTotal, EstimateItemID, i) {

    var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + i + "");
    var SpnProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + i + "");
    var SpnMarkup = document.getElementById("span_Markup_" + EstimateItemID + "_" + i + "");
    var SpnTax = document.getElementById("span_Tax_" + EstimateItemID + "_" + i + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_0");
    var ddlProfit = document.getElementById("ddlProfit_" + EstimateItemID + "_0");

    var SpnSellingPriceInTax = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + i + "");
    var SpnGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + i + "");
    var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "_" + i + "");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateItemID + "_" + i + "");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "_" + i + "");


    if (!isNaN(subTotal)) {
        var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);
        var ProfitValue = RemoveDollorAndComma(SpnProfitMargin.innerHTML);
        var MarkupValue = RemoveDollorAndComma(SpnMarkup.innerHTML);
        var GrossProfitValue = 0;
        var GrossPercentage = 0;
        var TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(subTotal) * Number(Get_Tax_Value(ddlTax.value)) / 100), 0, '', false, false, true);
        var SellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(Number(subTotal) + Number(TaxValue))), 0, '', false, false, true);
        SpnTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, false);
        SpnSellingPriceInTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInTax, 0, '', false, false, false);
        GrossProfitValue = GrossProfit_Value(Number(CostPriceExMarkup), Number(subTotal));
        //alert(subTotal);        
        document.getElementById("txtSubTotal_" + EstimateItemID + "_" + i + "").value = subTotal;
        document.getElementById("txtSummarySubTotal_" + EstimateItemID + "_" + i + "").value = subTotal;

        if (Number(subTotal) == 0) {
            GrossPercentage = "0.00";
        }
        else {
            var topvalue = GrossProfit_Percentage(Number(subTotal), Number(GrossProfitValue));
            GrossPercentage = topvalue;
        }
        SpnGrossProfit.innerHTML = "(" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, false) + "%)&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossProfitValue, 0, '', false, false, false);
        try {
            //alert(subTotal);
            TotalSellingPricesummary.innerHTML = SpnSellingPriceInTax.innerHTML;
            Taxsummary.innerHTML = SpnTax.innerHTML;
            GrossProfitsummary.innerHTML = "(" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, false) + "%)&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossProfitValue, 0, '', false, false, false);

        } catch (err) { }
    }
    else {
        document.getElementById("txtSubTotal_" + EstimateItemID + "_" + i + "").value = 0;
    }

}

//Booklet function strats from here ------------------------------------
////The Below function is used in Booklet Section (Section 1, Section 2) 
//// But the functionality is DISABLED = TRUE
function Sub_On_Blur(txtObj, EstimateItemID, EstimateBookletItemID, index) {
    var subValue = txtObj.value;
    var GrossPercentage;
    var GrossPercentage;

    var ProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");
    var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");
    var GrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");

    var Profitvalue = RemoveDollorAndComma(ProfitMargin.innerHTML);
    var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);

    if (!isNaN(subValue)) {
        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_" + EstimateBookletItemID + "");
        var span_Tax = document.getElementById("span_Tax_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");
        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");

        var TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value))) / 100;


        var span_TaxPart = document.getElementById("span_taxPart_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");
        var TotalSellingPricePart = document.getElementById("span_sellingPricePart_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");
        var spnGrrossProfitPart = document.getElementById("span_GrossProfitPart_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");


        TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);

        span_Tax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);
        TotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Number(subValue) + Number(TaxValue)), 0, '', false, false, true);
        txtObj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtObj.value, 0, '', false, false, true);
        GrossProfitValue = GrossProfit_Value(Number(CostPriceExMarkup), Number(subValue));

        span_TaxPart.innerHTML = span_Tax.innerHTML;
        TotalSellingPricePart.innerHTML = TotalSellingPrice.innerHTML;


        document.getElementById("span_Tax_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "").value = span_Tax.value;
        document.getElementById("txtSubTotal_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "").value = subValue;
        document.getElementById("txtSummarySubTotal_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "").value = subValue;
        if (Number(subValue) == 0) {
            GrossPercentage = Number(0);
            GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(GrossPercentage)), 0, '', false, false, true);
        }
        else {
            var topvalue = GrossProfit_Percentage(Number(subValue), Number(GrossProfitValue));
            GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(topvalue)), 0, '', false, false, true);
        }
    }
    else {
        var span_Tax = document.getElementById("span_Tax_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");
        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + index + "_" + EstimateBookletItemID + "");
        span_Tax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "0.00";
        TotalSellingPrice.innerHTML ="" + GetCurrencyinRequiredFormate("", true) + "0.00";
        txtObj.value = "0.00";

        GrossProfitValue = GrossProfit_Value(Number(CostPriceExMarkup), Number(subValue));
        if (Number(subValue) == 0) {
            GrossPercentage = Number(0);
            GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(GrossPercentage)), 0, '', false, false, true);
        }
    }
    subValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, subValue, 0, '', false, false, true);
    GrossProfit.innerHTML = "(" + GrossPercentage + "%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(GrossProfitValue)), 0, '', false, false, true);
    spnGrrossProfitPart.innerHTML = GrossProfit.innerHTML;
}
function TaxOnChange(TaxPercent, EstimateItemID, EstimateBookletItemID, QtyCount) {
    for (var j = 0; j < QtyCount; j++) {
        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
        var Tax = document.getElementById("span_Tax_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");

        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
        var GrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");

        var TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(TaxPercent))) / 100;
        TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);

        Tax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
        TotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtSubTotal.value) + Number(TaxValue)), 0, '', false, false, true);
        //alert("hi");
    }

}
function ProfitMarginShow_2(EstimateItemID, EstimateBookletItemID, QtyCount, priftValue) {

    for (var j = 0; j < QtyCount; j++) {
        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_" + EstimateBookletItemID + "");
        var MarkUp = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
        var SellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
        var ProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
        var Tax = document.getElementById("span_Tax_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
        var GrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");

        var MarkUpValue = RemoveDollorAndComma(MarkUp.innerHTML);
        var SellingPriceInMarkupValue = RemoveDollorAndComma(SellingPriceInMarkup.innerHTML);
        var ProfitMarginValue = RemoveDollorAndComma(ProfitMargin.innerHTML);
        var TaxValue = RemoveDollorAndComma(Tax.innerHTML);
        var TotalSellingPriceValue = RemoveDollorAndComma(TotalSellingPrice.innerHTML);
        var GrossProfitValue = RemoveDollorAndComma(GrossProfit.innerHTML);

        txtSubTotal.value = SellingPriceInMarkupValue;

        var Profit = (Number(SellingPriceInMarkupValue) * Number(priftValue)) / 100;
        Profit = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Profit, 0, '', false, false, true);
        ProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Profit;

        var subvalue = Number(Profit) + Number(SellingPriceInMarkupValue);
        subvalue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, subvalue, 0, '', false, false, true);
        txtSubTotal.value = subvalue;

        TaxValue = (Number(subvalue) * Number(Get_Tax_Value(ddlTax.value))) / 100;
        Tax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);

        TotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(TaxValue) + Number(txtSubTotal.value)), 0, '', false, false, true);
        if (txtSubTotal.value == "0.00") {
            GrossProfit.innerHTML = "(0.00%)" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(MarkUpValue) + Number(Profit)), 0, '', false, false, true);
        }
        else {
            var top1 = Number(MarkUpValue) + Number(Profit);
            var bot1 = Number(txtSubTotal.value)
            var val1 = Number(top1 / bot1) * 100;
            var GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, val1, 0, '', false, false, true);
            GrossProfit.innerHTML = "(" + GrossPercentage + "%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(MarkUpValue) + Number(Profit)), 0, '', false, false, true);
        }
    }
}

function ShowSection(obj, EstimateItemID, para2, para3, ItemNo) {
    //Para3 is Quantity Count and para2 is showtype
    var btnID = defaultButton.replace("T1E2S3T", "");
    obj.className = "booklet_section_active";
    if (para2 == 'all') {
        document.getElementById("div_AllSection_" + EstimateItemID).style.display = "block";
        for (var i = 0; i < para3; i++) {
            document.getElementById("div_Section_" + EstimateItemID + "_" + i + "").style.display = "none";
            document.getElementById("" + btnID + EstimateItemID + "_" + i + "").className = "booklet_section_normal";
        }

        if (flag == 'Detail') {
            document.getElementById("div_alldetail_" + EstimateItemID + "").style.display = "block";
            document.getElementById("div_allsummary_" + EstimateItemID + "").style.display = "none";
            document.getElementById("divbtnSummary" + ItemNo + "").style.display = "block";
            document.getElementById("divbtnDetail" + ItemNo + "").style.display = "none";
        }
        else if (flag == 'Summary') {
            document.getElementById("div_alldetail_" + EstimateItemID + "").style.display = "none";
            document.getElementById("div_allsummary_" + EstimateItemID + "").style.display = "block";
            document.getElementById("divbtnDetail" + ItemNo + "").style.display = "block";
            document.getElementById("divbtnSummary" + ItemNo + "").style.display = "none";
        }
    }
    else {
        document.getElementById("div_AllSection_" + EstimateItemID).style.display = "none";
        for (var i = 0; i < para3; i++) {
            document.getElementById("div_Section_" + EstimateItemID + "_" + i + "").style.display = "none";
            document.getElementById("" + btnID + EstimateItemID + "_" + i + "").className = "booklet_section_normal";
        }
        document.getElementById("" + btnID + EstimateItemID + "").className = "booklet_section_normal";
        document.getElementById("div_Section_" + EstimateItemID + "_" + para2 + "").style.display = "block";

        document.getElementById("" + btnID + EstimateItemID + "_" + para2 + "").className = "booklet_section_active";
        //these 2 lines added bec details should open automatically in parts
        document.getElementById("div_detail_" + EstimateItemID + "_" + para2 + "").style.display = "block";
        document.getElementById("div_summary_" + EstimateItemID + "_" + para2 + "").style.display = "none";

        //show either detail/summary button-ayesha 11/2/11
        document.getElementById("divbtnSummary" + ItemNo + "").style.display = "block";
        document.getElementById("divbtnDetail" + ItemNo + "").style.display = "none";
    }
}

var flag;
function Summary_Detail_Section(EstBookletItemID, qtyCount, para, para1, EstimateItemID) {
    var val = "0";
    document.cookie = "TabViewCookies=" + val + "";

    if (document.getElementById("div_AllSection_" + EstimateItemID).style.display == "block") {
        for (var i = 0; i < qtyCount; i++) {
            document.getElementById("div_Section_" + EstimateItemID + "_" + i + "").style.display = "none";
        }
        if (para == 'detail') {
            flag = "Detail";
            document.getElementById("div_alldetail_" + EstimateItemID + "").style.display = "block";
            document.getElementById("div_allsummary_" + EstimateItemID + "").style.display = "none"; //prevously is block now its none
            //show either detail/summary button-ayesha 11/2/11
            document.getElementById("divbtnSummary" + para1 + "").style.display = "block";
            document.getElementById("divbtnDetail" + para1 + "").style.display = "none";
            var itemNu = Number(para1) + 1;
            document.getElementById("spnItem_" + para1 + "").innerHTML = "Item " + itemNu + " Detail";
            document.getElementById("spnItem_" + para1 + "").style.color = "#751717";
        }
        else {
            flag = "Summary";
            document.getElementById("div_alldetail_" + EstimateItemID + "").style.display = "none";
            document.getElementById("div_allsummary_" + EstimateItemID + "").style.display = "block";
            //show either detail/summary button-ayesha 11/2/11
            document.getElementById("divbtnDetail" + para1 + "").style.display = "block";
            document.getElementById("divbtnSummary" + para1 + "").style.display = "none";
            var itemNu = Number(para1) + 1;
            document.getElementById("spnItem_" + para1 + "").innerHTML = "Item " + itemNu + " Summary";
            document.getElementById("spnItem_" + para1 + "").style.color = "#000000";
        }
        var cookValue = para + "µbookletµallµ" + EstimateItemID + "µ0µ" + qtyCount + "";
        createCookie_Summary(EstimateItemID, cookValue, 1);
    }
    else {
        for (var i = 0; i < qtyCount; i++) {
            if (document.getElementById("div_Section_" + EstimateItemID + "_" + i + "").style.display == "block") {
                if (para == 'detail') {
                    document.getElementById("div_detail_" + EstimateItemID + "_" + i + "").style.display = "block";
                    document.getElementById("div_summary_" + EstimateItemID + "_" + i + "").style.display = "none";
                    //show either detail/summary button-ayesha 11/2/11
                    document.getElementById("divbtnSummary" + para1 + "").style.display = "block";
                    document.getElementById("divbtnDetail" + para1 + "").style.display = "none";
                    var itemNu = Number(para1) + 1;
                    document.getElementById("spnItem_" + para1 + "").innerHTML = "Item " + itemNu + " Detail";
                    document.getElementById("spnItem_" + para1 + "").style.color = "#751717";
                }
                else if (para == 'summary') {
                    document.getElementById("div_detail_" + EstimateItemID + "_" + i + "").style.display = "none";
                    document.getElementById("div_summary_" + EstimateItemID + "_" + i + "").style.display = "block";
                    //show either detail/summary button-ayesha 11/2/11
                    document.getElementById("divbtnDetail" + para1 + "").style.display = "block";
                    document.getElementById("divbtnSummary" + para1 + "").style.display = "none";
                    var itemNu = Number(para1) + 1;
                    document.getElementById("spnItem_" + para1 + "").innerHTML = "Item " + itemNu + " Summary";
                    document.getElementById("spnItem_" + para1 + "").style.color = "#000000";
                }
                var idFormat = EstimateItemID + "_" + i + "";
                var cookValue = para + "µbookletµsectionµ" + EstimateItemID + "µ" + i + "µ" + qtyCount + "";
                createCookie_Summary(EstimateItemID, cookValue, 1);
            }
        }
    }
}

//The Following function is for Booklet only
function Booklet_TaxandProfitMargin(Profit, EstimateItemID, QtyCount, caltype) {
    for (var i = 0; i < QtyCount; i++) {
        var SpnCostExMarkup = document.getElementById("span_CostExMarkup_" + EstimateItemID + "_" + i + "");
        var SpnMarkup = document.getElementById("span_Markup_" + EstimateItemID + "_" + i + "");
        var SpnProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + i + "");
        var txtSubTotal = document.getElementById("txt_SubTotal_" + EstimateItemID + "_" + i + "");
        var SpnTax = document.getElementById("span_Tax_" + EstimateItemID + "_" + i + "");
        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "");
        var SpnSellingPriceInTax = document.getElementById("span_SellingPriceInTax_" + EstimateItemID + "_" + i + "");
        var SpnGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + i + "");
        var SpnTaxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "_" + i + "");
        var SpnSellingPriceInTaxsummary = document.getElementById("span_SellingPriceInTax_summary_" + EstimateItemID + "_" + i + "");
        var SpnGrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "_" + i + "");

        var CostExMarkupValue = RemoveDollorAndComma(SpnCostExMarkup.innerHTML);
        var MarkupValue = RemoveDollorAndComma(SpnMarkup.innerHTML);
        var CostInMarkup = Number(CostExMarkupValue) + Number(MarkupValue);
        var TaxPercentage = Get_Tax_Value(ddlTax.value);

        var ProfitValue = 0;
        var GrossProfitValue = 0;
        var GrossPercentage = 0;
        var subTotal = 0;
        if (caltype == "profit") {
            ProfitValue = (Number(CostInMarkup) * Number(Profit)) / 100;
            ProfitValue = ProfitValue;

            subTotal = Number(CostInMarkup) + Number(ProfitValue);
            subTotal = subTotal;

            var TaxValue = (Number(subTotal) * Number(TaxPercentage)) / 100;
            TaxValue = TaxValue;

            var SellInTax = Number(subTotal) + Number(TaxValue);
            SellInTax = SellInTax;

            GrossProfitValue = Number(MarkupValue) + Number(ProfitValue);
            GrossProfitValue = GrossProfitValue;
            if (Number(subTotal) != 0) {
                GrossPercentage = (Number(MarkupValue) + Number(ProfitValue)) / Number(subTotal) * 100;
            }
            else {
                GrossPercentage = 0;
            }
            GrossPercentage = GrossPercentage;

            SpnProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitValue;
            txtSubTotal.value = subTotal;
            SpnTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
            SpnSellingPriceInTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
            //summary
            SpnTaxsummary.innerHTML = SpnTax.innerHTML;
            SpnSellingPriceInTaxsummary.innerHTML = SpnSellingPriceInTax.innerHTML;
        }
        else if (caltype == "tax") {
            var taxPercentage = Get_Tax_Value(ddlTax.value);
            subTotal = RemoveDollorAndComma(txtSubTotal.value);
            subTotal = subTotal;

            var TaxValue = (Number(subTotal) * Number(TaxPercentage)) / 100;
            TaxValue = TaxValue;

            var SellInTax = Number(subTotal) + Number(TaxValue);
            SellInTax = SellInTax;

            GrossProfitValue = Number(MarkupValue) + Number(ProfitValue);
            GrossProfitValue = GrossProfitValue;

            SpnTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
            SpnSellingPriceInTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
            //summary
            SpnTaxsummary.innerHTML = SpnTax.innerHTML;
            SpnSellingPriceInTaxsummary.innerHTML = SpnSellingPriceInTax.innerHTML;
        }
        if (Number(subTotal) == 0) {
            GrossPercentage = "0.00";
        }
        else {
            GrossPercentage = ((Number(MarkupValue) + Number(ProfitValue)) / Number(subTotal)) * 100;
            GrossPercentage = GrossPercentage;
        }
        SpnGrossProfit.innerHTML = "(" + GrossPercentage + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossProfitValue;
        //summary
        SpnGrossProfitsummary.innerHTML = SpnGrossProfit.innerHTML;
    }
}
function Booklet_SubTotal(subTotal, EstimateItemID, i) {
    var span_CostExMarkup = document.getElementById("span_CostExMarkup_" + EstimateItemID + "_" + i + "");
    var SpnProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + i + "");
    var SpnMarkup = document.getElementById("span_Markup_" + EstimateItemID + "_" + i + "");
    var SpnTax = document.getElementById("span_Tax_" + EstimateItemID + "_" + i + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "");
    var ddlProfit = document.getElementById("ddlProfit_" + EstimateItemID + "");
    var SpnSellingPriceInTax = document.getElementById("span_SellingPriceInTax_" + EstimateItemID + "_" + i + "");
    var SpnGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + i + "");
    var SpnTaxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "_" + i + "");
    var SpnSellingPriceInTaxsummary = document.getElementById("span_SellingPriceInTax_summary_" + EstimateItemID + "_" + i + "");
    var SpnGrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "_" + i + "");
    if (!isNaN(subTotal)) {
        var CostExMarkup = RemoveDollorAndComma(span_CostExMarkup.innerHTML);
        var ProfitValue = RemoveDollorAndComma(SpnProfitMargin.innerHTML);
        var MarkupValue = RemoveDollorAndComma(SpnMarkup.innerHTML);
        var GrossProfitValue = 0;
        var GrossPercentage = 0;

        var TaxValue = (Number(subTotal) * Number(Get_Tax_Value(ddlTax.value))) / 100;
        TaxValue = TaxValue;

        var SellInTax = Number(subTotal) + Number(TaxValue);
        SellInTax = SellInTax;

        SpnTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
        SpnSellingPriceInTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;

        GrossProfitValue = GrossProfit_Value(Number(CostExMarkup), Number(subTotal));
        GrossProfitValue = GrossProfitValue;

        if (Number(subTotal) == 0) {
            GrossPercentage = "0.00";
        }
        else {
            GrossPercentage = GrossProfit_Percentage(Number(subTotal), Number(GrossProfitValue));
            GrossPercentage = GrossPercentage;
        }
        SpnGrossProfit.innerHTML = "(" + GrossPercentage + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossProfitValue;
        SpnTaxsummary.innerHTML = SpnTax.innerHTML;
        SpnSellingPriceInTaxsummary.innerHTML = SpnSellingPriceInTax.innerHTML;
        SpnGrossProfitsummary.innerHTML = SpnGrossProfit.innerHTML;
    }
    else {
        document.getElementById("txt_SubTotal_" + EstimateItemID + "_" + i + "").value = 0;
    }
}

//Booklet function ends here -------------------------------------------------------------------------------------------------

function Outwork_TaxOnChange(TaxID, EstimateItemID, QtyCount) {
    for (var i = 1; i <= QtyCount; i++) {
        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + i + ""); //TextBox
        var SpanTax = document.getElementById("span_Tax_" + EstimateItemID + "_" + i + "");
        var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + i + "");
        var SpanGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + i + "");

        var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "_" + i + "");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateItemID + "_" + i + "");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "_" + i + "");

        var TaxValue = Number(Number(txtSubTotal.value) * Number(Get_Tax_Value(TaxID))) / 100;

        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtSubTotal.value) + Number(TaxValue)), 0, '', false, false, true);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(TaxValue)), 0, '', false, false, true);

        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
}

function ProfitMarginShow_PrintBroker(Proift, EstimateItemID, QtyCount) {
    /*
    var Arr = List.split(',');
    var EstimateItemID = Arr[0];
    var QtyCount  = Arr[1];
    */
    for (var i = 1; i <= QtyCount; i++) {
        var SpanMarkup = document.getElementById("span_Markup_" + EstimateItemID + "_" + i + "");
        var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + i + "");
        var SpanTotalPrice = document.getElementById("span_TotalPrice_" + EstimateItemID + "_" + i + ""); //Reference
        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + i + ""); //TextBox
        var SpanTax = document.getElementById("span_Tax_" + EstimateItemID + "_" + i + "");
        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "");
        var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + i + "");
        var SpanGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + i + "");

        var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "_" + i + "");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateItemID + "_" + i + "");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "_" + i + "");

        var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
        var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
        var TotalPriceValue = RemoveDollorAndComma(SpanTotalPrice.innerHTML);
        var TaxValue;

        ProfitMarginValue = (Number(TotalPriceValue) * Number(Proift)) / 100;
        ProfitMarginValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ProfitMarginValue, 0, '', false, false, true);
        SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;

        var subValue = Number(ProfitMarginValue) + Number(TotalPriceValue);
        txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, subValue, 0, '', false, false, true);

        TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(ddlTax.value))) / 100;
        TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;

        var TotalSell = Number(txtSubTotal.value) + Number(TaxValue)
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalSell, 0, '', false, false, true);

        var GrossValue = Number(Markup) + Number(ProfitMarginValue);
        GrossValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);
        if (Number(txtSubTotal.value) == 0) {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else {
            var GrossPercent = ((Number(Markup) + Number(ProfitMarginValue)) / Number(txtSubTotal.value)) * 100;
            GrossPercent = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercent, 0, '', false, false, true);
            SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
}
//SubTotal Text Box OnBlur
function Outwork_SubTotalCal(subValue, EstimateItemID, i) {
    /*var arr = para.split(',');       
    */
    var span_CostExMarkup = document.getElementById("span_CostExMarkup_" + EstimateItemID + "_" + i + "");
    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + i + "");
    var SpanMarkup = document.getElementById("span_Markup_" + EstimateItemID + "_" + i + "");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + i + "");
    var SpanTax = document.getElementById("span_Tax_" + EstimateItemID + "_" + i + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "");
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + i + "");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + i + "");

    var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "_" + i + "");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateItemID + "_" + i + "");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "_" + i + "");

    if (!isNaN(subValue)) {
        var CostExMarkup = RemoveDollorAndComma(span_CostExMarkup.innerHTML);
        var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
        var TaxValue = 0;
        var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);

        TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value))) / 100;
        TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;
        document.getElementById("txtSubTotal_" + EstimateItemID + "_" + i + "").value = subValue;
        document.getElementById("txtSummarySubTotal_" + EstimateItemID + "_" + i + "").value = subValue;


        var TotalSell = Number(subValue) + Number(TaxValue);
        TotalSell = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalSell, 0, '', false, false, true);
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TotalSell;

        var GrossValue = GrossProfit_Value(Number(CostExMarkup), Number(subValue));
        GrossValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);
        if (Number(subValue) == 0) {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else {
            var GrossPercent = GrossProfit_Percentage(Number(subValue), Number(GrossValue));
            GrossPercent = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercent, 0, '', false, false, true);
            SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
    else {
        txtSubTotal.value = 0;
    }
    txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSubTotal.value, 0, '', false, false, true);
}
//Outwork Detial and Summary
function OutWork_Summary_Detail_Show(EstimateItemID, i, type) {
    var val = "0";
    document.cookie = "TabViewCookies=" + val + "";
    var itemNu = Number(i) + 1;
    ////var arr = para.split(',');

    if (type == "summary") {
        //Show Summary       
        document.getElementById("div_summary_" + EstimateItemID + "").style.display = "block";
        document.getElementById("div_detail_" + EstimateItemID + "").style.display = "none";
        document.getElementById("divbtnDetail" + i + "").style.display = "block";
        document.getElementById("divbtnSummary" + i + "").style.display = "none";
        try {
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Summary";
            document.getElementById("spnItem_" + i + "").style.color = "#000000";

        } catch (err) {
        }
    }
    else if (type == "detail") {
        //Show detail
        document.getElementById("div_summary_" + EstimateItemID + "").style.display = "none";
        document.getElementById("div_detail_" + EstimateItemID + "").style.display = "block";
        document.getElementById("divbtnSummary" + i + "").style.display = "block";
        document.getElementById("divbtnDetail" + i + "").style.display = "none";
        try {
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Detail";
            document.getElementById("spnItem_" + i + "").style.color = "#751717";
        } catch (err) {
        }
    }
    var cookValue = type + "µPrintBrokerµ" + EstimateItemID + "µ" + i + "";
    createCookie_Summary(EstimateItemID, cookValue, 1);

}
//Other Cost Starts from here
function OtherCostProfitMargin(profit, EstimateitemID) {
    var profit = document.getElementById("ddlProfit_" + EstimateitemID + "").value;
    var SpanMarkup = document.getElementById("span_Markup_" + EstimateitemID + "");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + EstimateitemID + "");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateitemID + "");
    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateitemID + ""); //TextBox
    var SpanTax = document.getElementById("span_Tax_" + EstimateitemID + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateitemID + "");

    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateitemID + "");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_" + EstimateitemID + "");
    var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateitemID + "");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateitemID + "");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateitemID + "");

    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = 0; // SpanTax.innerHTML.replace('$','').replace(/,/,'');

    ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit)) / 100;
    ProfitMarginValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ProfitMarginValue, 0, '', false, false, true);
    SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;

    var subValue = Number(SellingPriceInMarkupValue) + Number(ProfitMarginValue);
    subValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, subValue, 0, '', false, false, true);
    txtSubTotal.value = subValue;

    TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value))) / 100;
    TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);
    SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;

    var sellInTax = Number(TaxValue) + Number(txtSubTotal.value);
    sellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, sellInTax, 0, '', false, false, true);
    SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + sellInTax;

    var GrossPercent = 0;
    var GrossValue = Number(Markup) + Number(ProfitMarginValue);
    GrossValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);

    if (subValue == "0.00") {
        SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
    }
    else {
        GrossPercent = ((Number(Markup) + Number(ProfitMarginValue)) / Number(subValue)) * 100;
        GrossPercent = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercent, 0, '', false, false, true);
        SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
    }
    Taxsummary.innerHTML = SpanTax.innerHTML;
    TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
    GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
}
function OtherCostTaxOnChange(taxID, EstimateitemID) {
    var tax = Get_Tax_Value(taxID);

    var SpanMarkup = document.getElementById("span_Markup_" + EstimateitemID + "");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + EstimateitemID + "");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateitemID + "");
    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateitemID + ""); //TextBox
    var SpanTax = document.getElementById("span_Tax_" + EstimateitemID + "");
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateitemID + "");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_" + EstimateitemID + "");

    var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateitemID + "");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateitemID + "");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateitemID + "");

    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = RemoveDollorAndComma(SpanTax.innerHTML);

    var newTaxValue = (Number(SubTotalValue) * Number(tax)) / 100;
    newTaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, newTaxValue, 0, '', false, false, true);
    SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + newTaxValue;

    var sellInTax = Number(newTaxValue) + Number(SubTotalValue);
    sellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, sellInTax, 0, '', false, false, true);
    SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + sellInTax;

    var subValue = SubTotalValue;

    var GrossPercent = 0;
    var GrossValue = Number(Markup) + Number(ProfitMarginValue);
    GrossValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);
    if (subValue == "0.00") {
        SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
    }
    else {
        GrossPercent = ((Number(Markup) + Number(ProfitMarginValue)) / Number(subValue)) * 100;
        GrossPercent = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercent, 0, '', false, false, true);
        SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true) + "";
    }
    Taxsummary.innerHTML = SpanTax.innerHTML;
    TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
    GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
}
function OtherCostSubTotalOnBlur(txtValue, EstimateitemID) {
    var span_CostExMarkup = document.getElementById("span_CostExMarkup_" + EstimateitemID + "");
    var SpanMarkup = document.getElementById("span_Markup_" + EstimateitemID + "");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + EstimateitemID + "");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateitemID + "");
    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateitemID + ""); //TextBox
    var ddlTax = document.getElementById("ddlTax_" + EstimateitemID + ""); //ddl
    var SpanTax = document.getElementById("span_Tax_" + EstimateitemID + "");
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateitemID + "");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_" + EstimateitemID + "");

    var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateitemID + "");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateitemID + "");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateitemID + "");

    var CostExMarkup = RemoveDollorAndComma(span_CostExMarkup.innerHTML);
    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = RemoveDollorAndComma(SpanTax.innerHTML);

    //document.getElementById("txtSubTotal_" + EstimateitemID + "").value = txtValue;
    document.getElementById("txtSummarySubTotal_" + EstimateitemID + "").value = txtValue;
    if (!isNaN(txtValue) && txtValue != '') {
        var TaxValue = (Number(txtValue) * Number(Get_Tax_Value(ddlTax.value))) / 100;
        TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;

        var SellInTax = Number(txtValue) + Number(TaxValue);
        SellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInTax, 0, '', false, false, true);
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;
        var subValue = SubTotalValue;


        var GrossPercent = 0;
        var GrossValue = GrossProfit_Value(Number(CostExMarkup), Number(subValue));
        GrossValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);



        if (Number(subValue) == 0) {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else {
            GrossPercent = GrossProfit_Percentage(Number(subValue), Number(GrossValue));
            GrossPercent = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercent, 0, '', false, false, true);
            SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true) + "";
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
    else {
        txtSubTotal.value = 0;
    }
    txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtValue, 0, '', false, false, true);
}

//END OF OTHER COST Js


//This function is called from .CS page
function Summary_Detail_Show(i, type, EstimateItemID) {
    /*var arr = para.split(',');*/
    var val = "0";
    document.cookie = "TabViewCookies=" + val + "";
    //    var subtotalValue = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + i + "").value;
    //    alert(subtotalValue);
    //document.getElementById("txtSubTotal_" + EstimateItemID + "_" + i + "").value = subtotalValue;



    if (type == "summary") {
        //Show Summary        
        document.getElementById("div_summary_" + i + "").style.display = "block";
        document.getElementById("div_detail_" + i + "").style.display = "none";
        document.getElementById("divbtnDetail" + i + "").style.display = "block";
        document.getElementById("divbtnSummary" + i + "").style.display = "none";
        try {
            var itemNu = Number(i) + 1;
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Summary";
            document.getElementById("spnItem_" + i + "").style.color = "#000000";
        } catch (err) {
        }
    }
    else {
        //Show Detail

        document.getElementById("div_detail_" + i + "").style.display = "block";
        document.getElementById("div_summary_" + i + "").style.display = "none";
        document.getElementById("divbtnSummary" + i + "").style.display = "block";
        document.getElementById("divbtnDetail" + i + "").style.display = "none";
        try {
            var itemNu = Number(i) + 1;
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Detail";
            document.getElementById("spnItem_" + i + "").style.color = "#751717";
        } catch (err) {
        }
    }
    var cookValue = type + "µSPLOµ" + i + "µ" + EstimateItemID + "";
    createCookie_Summary(EstimateItemID, cookValue, 1);
}


// Main Warehouse Js Starts
function WarehouseOnBlur(subValue, EstimateItemID) {
    if (!isNaN(subValue) && subValue != '') {
        var span_CostExMarkup = document.getElementById("span_CostExMarkup_" + EstimateItemID + "");
        var profit = document.getElementById("ddlProfit_" + EstimateItemID + "").value;
        var SpanMarkup = document.getElementById("span_Markup_" + EstimateItemID + "");
        var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + EstimateItemID + "");
        var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "");
        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + ""); //TextBox
        var SpanTax = document.getElementById("span_Tax_" + EstimateItemID + "");
        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "");
        var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "");
        var SpanGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "");

        var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateItemID + "");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "");

        var CostExMarkup = RemoveDollorAndComma(span_CostExMarkup.innerHTML);
        var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
        var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
        var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
        var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
        var TaxValue = 0; //SpanTax.innerHTML.replace('$','').replace(/,/,'');
        var SellInTax = 0;

        document.getElementById("txtSubTotal_" + EstimateItemID + "").value = subValue;
        document.getElementById("txtSummarySubTotal_" + EstimateItemID + "").value = subValue;
        ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit)) / 100;
        ProfitMarginValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ProfitMarginValue, 0, '', false, false, true);
        SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;

        subValue = RemoveDollorAndComma(subValue);

        TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value))) / 100;
        TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;

        SellInTax = Number(TaxValue) + Number(subValue);
        SellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInTax, 0, '', false, false, true);
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;

        var GrossPercent = 0;
        var GrossValue = GrossProfit_Value(Number(CostExMarkup), Number(subValue));
        GrossValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);

        if (subValue == 0) {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else {

            GrossPercent = GrossProfit_Percentage(Number(subValue), Number(GrossValue));
            GrossPercent = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercent, 0, '', false, false, true);
            SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true) + "";
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
    else {
        document.getElementById("txtSubTotal_" + EstimateItemID + "").value = "0";
    }
    //txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSubTotal.value, 0, '', false, false, true);
}
function WarehouseTaxOnChange(TaxID, EstimateItemID) {
    var tax = Get_Tax_Value(TaxID);

    var SpanMarkup = document.getElementById("span_Markup_" + EstimateItemID + "");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + EstimateItemID + "");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "");
    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + ""); //TextBox
    var SpanTax = document.getElementById("span_Tax_" + EstimateItemID + "");
    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "");

    var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateItemID + "");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "");

    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = RemoveDollorAndComma(SpanTax.innerHTML);
    var SellInTax = 0;

    var newTaxValue = (Number(SubTotalValue) * Number(tax)) / 100;
    newTaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, newTaxValue, 0, '', false, false, true);
    SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + newTaxValue;

    SellInTax = Number(newTaxValue) + Number(SubTotalValue);
    SellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInTax, 0, '', false, false, true);
    SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;

    var subValue = SubTotalValue;
    subValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, subValue, 0, '', false, false, true);

    var GrossPercent = 0;
    var GrossValue = Number(Markup) + Number(ProfitMarginValue);
    GrossValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);

    if (Number(subValue) == 0) {
        SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
    }
    else {
        GrossPercent = ((Number(Markup) + Number(ProfitMarginValue)) / Number(subValue)) * 100;
        GrossPercent = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercent, 0, '', false, false, true);

        SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true) + "";
    }
    Taxsummary.innerHTML = SpanTax.innerHTML;
    TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
    GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
}
function WarehouseProfitOnChange(profit, EstimateItemID) {
    WareForBoth(profit, EstimateItemID);
}
function WareForBoth(profit, EstimateItemID) {
    var SpanMarkup = document.getElementById("span_Markup_" + EstimateItemID + "");
    var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + EstimateItemID + "");
    var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "");
    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + ""); //TextBox
    var SpanTax = document.getElementById("span_Tax_" + EstimateItemID + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "");

    var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "");
    var SpanGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "");

    var Taxsummary = document.getElementById("span_Tax_summary_" + EstimateItemID + "");
    var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + EstimateItemID + "");
    var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + EstimateItemID + "");

    var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
    var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
    var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
    var TaxValue = 0; //SpanTax.innerHTML.replace('$','').replace(/,/,'');
    var SellInTax = 0;

    ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit)) / 100;
    ProfitMarginValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ProfitMarginValue, 0, '', false, false, true);
    SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;

    var subValue = Number(SellingPriceInMarkupValue) + Number(ProfitMarginValue);
    subValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, subValue, 0, '', false, false, true);
    txtSubTotal.value = subValue;

    TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value))) / 100;
    TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);
    SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;

    SellInTax = Number(TaxValue) + Number(subValue);
    SellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInTax, 0, '', false, false, true);
    SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;

    var GrossPercent = 0;
    var GrossValue = Number(Markup) + Number(ProfitMarginValue);
    GrossValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);
    if (Number(subValue) == 0) {
        SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
    }
    else {
        GrossPercent = (Number(Markup) + Number(ProfitMarginValue)) / Number(subValue);
        GrossPercent = GrossPercent * 100;
        GrossPercent = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercent, 0, '', false, false, true);
        SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true) + "";
    }
    Taxsummary.innerHTML = SpanTax.innerHTML;
    TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
    GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
}


function WarehouseSummaryDetails(EstimateItemID, i, type) {

    var val = "0";
    document.cookie = "TabViewCookies=" + val + "";
    /* var arr = para.split(','); */

    if (type == 'detail') {
        //div_detail_
        document.getElementById("div_Warehouse_Details_" + EstimateItemID + "").style.display = "block";
        document.getElementById("div_Warehouse_Summary_" + EstimateItemID + "").style.display = "none";
        document.getElementById("divbtnSummary" + i + "").style.display = "block";
        document.getElementById("divbtnDetail" + i + "").style.display = "none";
        try {
            var itemNu = Number(i) + 1;
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Detail";
            document.getElementById("spnItem_" + i + "").style.color = "#751717";
        } catch (err) {
        }
    }
    else if (type == 'summary') {
        //div_summary_
        document.getElementById("div_Warehouse_Details_" + EstimateItemID + "").style.display = "none";
        document.getElementById("div_Warehouse_Summary_" + EstimateItemID + "").style.display = "block";
        document.getElementById("divbtnDetail" + i + "").style.display = "block";
        document.getElementById("divbtnSummary" + i + "").style.display = "none";
        try {
            var itemNu = Number(i) + 1;
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Summary";
            document.getElementById("spnItem_" + i + "").style.color = "#000000";
        } catch (err) {
        }
    }
    var cookValue = type + "µWarehouseµ" + EstimateItemID + "µ" + i + "";
    createCookie_Summary(EstimateItemID, cookValue, 1);
}
// Main Warehouse ENDS Here

//CATALOGUE STARTS FROM HERE
function Catalogue_Summary_Details(EstimateItemID, i, type) {
    var val = "0";
    document.cookie = "TabViewCookies=" + val + "";
    /* var arr = para.split(','); */

    if (type == 'detail') {
        //div_detail_
        document.getElementById("div_Catalogue_Details_" + EstimateItemID + "").style.display = "block";
        document.getElementById("div_Catalogue_Summary_" + EstimateItemID + "").style.display = "none";
        document.getElementById("divbtnSummary" + i + "").style.display = "block";
        document.getElementById("divbtnDetail" + i + "").style.display = "none";
        try {
            var itemNu = Number(i) + 1;
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Detail";
            document.getElementById("spnItem_" + i + "").style.color = "#751717";
        } catch (err) {
        }
    }
    else if (type == 'summary') {
        //div_summary_
        document.getElementById("div_Catalogue_Details_" + EstimateItemID + "").style.display = "none";
        document.getElementById("div_Catalogue_Summary_" + EstimateItemID + "").style.display = "block";
        document.getElementById("divbtnDetail" + i + "").style.display = "block";
        document.getElementById("divbtnSummary" + i + "").style.display = "none";
        try {
            var itemNu = Number(i) + 1;
            document.getElementById("spnItem_" + i + "").innerHTML = "Item " + itemNu + " Summary";
            document.getElementById("spnItem_" + i + "").style.color = "#000000";
        } catch (err) {
        }
    }
    var cookValue = type + "µWarehouseµ" + EstimateItemID + "µ" + i + "";
    createCookie_Summary(EstimateItemID, cookValue, 1);
}
//CATALOGUE ENDS HERE

function createCookie_Summary(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie_Summary(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) {
            c.substring(nameEQ.length, c.length);
        }
    }
    return null;
}

function eraseCookie_Summary(name) {
    createCookie(name, "", -1);
}

function ShowOnCookie(name) {
    if (readCookie_Summary(name) != null) {
        var cookvalue = '';
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) {
                cookvalue = c.substring(nameEQ.length, c.length);
                if (cookvalue != '') {

                }
            }
        }
    }
}

function CallAfterLoad(Esttype) {
    try {
        var ListOfId = EstimateItemIDList.split('±');
        for (var i = 0; i < ListOfId.length - 1; i++) {
            var spnName = trim12("spnItem_" + i + "");
            var EID = ListOfId[i];
            if (document.getElementById(spnName) != null) {
                var Array1 = document.cookie.split(';');
                for (var k = 0; k < Array1.length; k++) {
                    var Array2 = Array1[k].split('=');
                    if (trim12(Array2[0]) == EID) {
                        var itemNu = Number(i) + 1;
                        var ArrayOne = Array2[1].split('µ');
                        ////para+"  µ   booklet µ   section µ   EstBookletItemID  µ " i;
                        if (ArrayOne[1] == 'booklet') {
                            var showtype = ArrayOne[0];
                            var sectionType = ArrayOne[2];
                            var EstBookletItemID = ArrayOne[3];
                            var index = ArrayOne[4];
                            var qtyCount = ArrayOne[5];
                            //para µ  booklet µ section  µ  EstBookletItemID µ i µ qtyCount
                            //para µ  booklet µ all      µ  EstBookletItemID  µ 0 µ qtyCount

                            if (sectionType == "all") {
                                document.getElementById("div_AllSection_" + EstBookletItemID).style.display = "block";
                                var btnID = defaultButton.replace("T1E2S3T", "");
                                var btnObj = document.getElementById("" + btnID + EstBookletItemID + "_" + index + "");
                                ShowSection(btnObj, EstBookletItemID, sectionType, qtyCount, i);
                            }
                            else {
                                document.getElementById("div_AllSection_" + EstBookletItemID).style.display = "none";
                                document.getElementById("div_Section_" + EstBookletItemID + "_" + index + "").style.display = "block";

                                var btnID = defaultButton.replace("T1E2S3T", "");
                                var btnObj = document.getElementById("" + btnID + EstBookletItemID + "_" + index + "");
                                ShowSection(btnObj, EstBookletItemID, index, qtyCount, i);
                            }
                            Summary_Detail_Section(EstBookletItemID, qtyCount, showtype, index);

                        }
                        else if (ArrayOne[1] == 'SPLO') {
                            //var cookValue = type µ single µ i µ EstimateItemID;
                            var showtype = ArrayOne[0];
                            if (Esttype == "Q,") {
                                Summary_Detail_Show(i, 'detail');
                            }
                            else {
                                Summary_Detail_Show(i, showtype);
                            }
                        }
                        else if (ArrayOne[1] == 'PrintBroker') {
                            //var cookValue = showtype µ PrintBroker µ  EstimateItemID µ i 
                            var showtype = ArrayOne[0];
                            var EstimateItemID = ArrayOne[2];
                            var index = ArrayOne[3];
                            OutWork_Summary_Detail_Show(EstimateItemID, index, showtype);
                        }
                        else if (ArrayOne[1] == 'Warehouse') {
                            var showtype = ArrayOne[0];
                            var EstimateItemID = ArrayOne[2];
                            var index = ArrayOne[3];
                            WarehouseSummaryDetails(EstimateItemID, index, showtype);
                        }
                    }
                }
            }
        }
    }
    catch (err) {
    }
}

//FINAL SAVE CLICK
function Estimate_Cal_Save() {
    //S»634»4    µ   B»635»3»258 µ   P»636»3 µ   L»637»4 µ   W»638   µ   O»639»206±   µ  U»640   µ       
    var EstValues = 0;
    var EstValueExTax = 0;
    var EstTotQty = 0;
    var AllData = '';
    var StoreComplete = '';
    var ItmArr1 = OverallList.split('µ');

    for (var i = 0; i < ItmArr1.length; i++) {
        if (ItmArr1[i] != '') {
            //S»26»3   µ   B»27»2  µ   U»28 
            //EstType»EstimateItem»QtyCount µ EstType»EstimateItem»QtyCount µ EstType»EstimateItem
            var ItmArr2 = ItmArr1[i].split('»');
            var EstimateItemID = '';
            var QtyCount = '';
            var Qty = 0;
            if (ItmArr2[0] == "U") {
                var otherData = 'U±'
                EstimateItemID = ItmArr2[1];
                var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + ""); //TextBox
                txtSubTotal.value = RemoveDollorAndComma(txtSubTotal.value)
                var ddlProfit = document.getElementById("ddlProfit_" + EstimateItemID + ""); //ddl
                var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + ""); //ddl

                var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + ""); //TextBox


                otherData += "EstimateItemID»" + EstimateItemID + "±SubTotal»" + txtSubTotal.value + "±";
                // *** Control Value Changed by Nataraj on 22.08.2011 ***//
                otherData += "ProfitMargin»" + ddlProfit.value + "±Tax»" + Get_Tax_Value(ddlTax.value) + "±TaxID»" + ddlTax.value + "±ItemTitle»" + txtItemTitle.innerHTML;

                AllData += otherData + "µ";

                //----- Estimate Values ------
                var spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + ""); //span
                var OtherSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                OtherSellPrice = Number(OtherSellPrice);

                EstValues = Number(EstValues) + Number(OtherSellPrice);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(txtSubTotal.value);
                EstValueExTax = EstValueExTax;
            }
            else if (ItmArr2[0] == "S") {

                var spanTotalSellingPrice = '';
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                QtyCount = Number(ItmArr2[2]);
                var SingleData = 'S±';
                for (var j = 0; j < QtyCount; j++) {
                    if (j == 0) {
                        //var txtSectionRef = document.getElementById("txtSectionReference_"+EstimateItemID+"");
                        var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + "");
                        var ProfitMargin = document.getElementById("ddlProfit_" + EstimateItemID + "_" + j + "");
                        var Tax = document.getElementById("ddlTax_" + EstimateItemID + "_" + j + "");


                        SingleData += "EstimateItemID»" + EstimateItemID + "±";
                        SingleData += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                        //SingleData +="SectionRef»"+ txtSectionRef.value +"±";
                        SingleData += "ProfitMargin»" + ProfitMargin.value + "±";
                        SingleData += "Tax»" + Get_Tax_Value(Tax.value) + "±";
                        SingleData += "TaxID»" + Tax.value + "±";

                        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "");
                        SubTotal = Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "").value));
                    }

                    var spanQty_qty = document.getElementById("spanQty_qty_" + EstimateItemID + "_" + j + "");
                    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "");
                    var spanQtyID = document.getElementById("spanQty_" + EstimateItemID + "_" + j + "");
                    var costExmarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "");
                    var totalmarkupprice = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "");

                    if (QtyCount - 1 == j) {
                        SingleData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        SingleData += "»" + spanQty_qty.innerHTML;
                        SingleData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        SingleData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                        AllData += SingleData + "µ";
                    }
                    else {
                        SingleData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        SingleData += "»" + spanQty_qty.innerHTML;
                        SingleData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        SingleData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML) + "§";
                    }
                }
                //----- Estimate Values ------
                var SingleSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                SingleSellPrice = SingleSellPrice;

                EstValues = Number(EstValues) + Number(SingleSellPrice);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }
            else if (ItmArr2[0] == "P") {
                var spanTotalSellingPrice = '';
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                QtyCount = Number(ItmArr2[2]);

                var PadData = 'P±';
                for (var j = 0; j < QtyCount; j++) {
                    if (j == 0) {
                        var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + "");
                        var ProfitMargin = document.getElementById("ddlProfit_" + EstimateItemID + "_" + j + "");
                        var Tax = document.getElementById("ddlTax_" + EstimateItemID + "_" + j + "");
                        PadData += "EstimateItemID»" + EstimateItemID + "±";
                        PadData += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                        PadData += "ProfitMargin»" + ProfitMargin.value + "±";
                        PadData += "Tax»" + Get_Tax_Value(Tax.value) + "±";
                        PadData += "TaxID»" + Tax.value + "±";

                        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "");
                        SubTotal = Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "").value));
                    }
                    var spanQty_qty = document.getElementById("spanQty_qty_" + EstimateItemID + "_" + j + "");
                    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "");
                    var spanQtyID = document.getElementById("spanQty_" + EstimateItemID + "_" + j + "");
                    var costExmarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "");
                    var totalmarkupprice = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "");
                    if (QtyCount - 1 == j) {
                        PadData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        PadData += "»" + spanQty_qty.innerHTML;
                        PadData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        PadData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                        AllData += PadData + "µ";
                    }
                    else {
                        PadData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        PadData += "»" + spanQty_qty.innerHTML;
                        PadData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        PadData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML) + "§";
                    }
                }
                //----- Estimate Values ------
                var PadSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                PadSellPrice = PadSellPrice;

                EstValues = Number(EstValues) + Number(PadSellPrice);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }
            else if (ItmArr2[0] == "L") {
                var spanTotalSellingPrice = '';
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                QtyCount = Number(ItmArr2[2]);

                var LargeData = 'L±';
                for (var j = 0; j < QtyCount; j++) {
                    if (j == 0) {
                        var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + "");
                        var ProfitMargin = document.getElementById("ddlProfit_" + EstimateItemID + "_" + j + "");
                        var Tax = document.getElementById("ddlTax_" + EstimateItemID + "_" + j + "");
                        LargeData += "EstimateItemID»" + EstimateItemID + "±";
                        LargeData += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                        LargeData += "ProfitMargin»" + ProfitMargin.value + "±";
                        LargeData += "Tax»" + Get_Tax_Value(Tax.value) + "±";
                        LargeData += "TaxID»" + Tax.value + "±";

                        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "");
                        SubTotal = Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "").value));
                    }
                    var spanQty_qty = document.getElementById("spanQty_qty_" + EstimateItemID + "_" + j + "");
                    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "");
                    var spanQtyID = document.getElementById("spanQty_" + EstimateItemID + "_" + j + "");
                    var costExmarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "");
                    var totalmarkupprice = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "");

                    if (QtyCount - 1 == j) {
                        LargeData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        LargeData += "»" + spanQty_qty.innerHTML;
                        LargeData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        LargeData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                        AllData += LargeData + "µ";
                    }
                    else {
                        LargeData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        LargeData += "»" + spanQty_qty.innerHTML;
                        LargeData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        LargeData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML) + "§";
                    }
                }
                //----- Estimate Values ------
                var PadSellPrice = Number(RemoveDollorAndComma(spanTotalSellingPrice.innerHTML));
                PadSellPrice = PadSellPrice;

                EstValues = Number(EstValues) + Number(PadSellPrice);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }
            else if (ItmArr2[0] == "W") {
                var WareData = 'W±';
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                var ddlProfit = document.getElementById("ddlProfit_" + EstimateItemID + ""); //ddl
                var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + ""); //TextBox
                var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + ""); //ddl

                txtSubTotal.value = RemoveDollorAndComma(txtSubTotal.value);
                SubTotal = Number(txtSubTotal.value);

                var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + ""); //TextBox
                WareData += "EstimateItemID»" + EstimateItemID + "±";
                WareData += "ProfitMargin»" + ddlProfit.value + "±";
                WareData += "SubTotal»" + txtSubTotal.value + "±";
                WareData += "Tax»" + Get_Tax_Value(ddlTax.value) + "±";
                WareData += "TaxID»" + ddlTax.value + "±";
                WareData += "ItemTitle»" + txtItemTitle.innerHTML;
                AllData += WareData + "µ";
                //----- Estimate Values ------
                var spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + ""); //span
                var WarehouseSellPrice = Number(RemoveDollorAndComma(spanTotalSellingPrice.innerHTML));
                WarehouseSellPrice = WarehouseSellPrice;

                EstValues = Number(EstValues) + Number(WarehouseSellPrice);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }
            else if (ItmArr2[0] == "O") {
                var OutData = 'O±';
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                var ArrSup = ItmArr2[2].split('±');
                var OutFirstValue;
                for (var j = 0; j < ArrSup.length; j++) {
                    if (ArrSup[j] != '') {
                        var EstOutworkSupplierID = ArrSup[j];
                        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "");
                        var ddlProfit = document.getElementById("ddlProfit_" + EstimateItemID + "");
                        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + Number(j + 1) + ""); //TextBox
                        if (j == 0) {
                            OutFirstValue = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + Number(j + 1) + "").innerHTML; //Span
                            OutFirstValue = RemoveDollorAndComma(OutFirstValue);
                            SubTotal = Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + Number(j + 1) + "").value));
                        }
                        var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + "");

                        OutData += "EstimateItemID»" + EstimateItemID + "±";
                        OutData += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                        OutData += "ProfitMargin»" + ddlProfit.value + '±';
                        OutData += "Tax»" + Get_Tax_Value(ddlTax.value) + "±";
                        OutData += "TaxID»" + ddlTax.value + "±";
                        OutData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + '±';
                        OutData += "EstOutworkSupplierID»" + EstOutworkSupplierID + "§";
                    }
                }
                AllData += OutData + "µ";
                //----- Estimate Values ------
                var OutValue = OutFirstValue;

                EstValues = Number(EstValues) + Number(OutValue);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }
            else if (ItmArr2[0] == "B" || ItmArr2[0] == "K") {

                //----Estimate Values
                var spanTotalSellingPrice = 0.0;
                var SubTotal = 0.0;
                EstimateItemID = ItmArr2[1];
                var QtyCount; //ItmArr2[2]; 
                var SectionList; // = ItmArr2[3].split('§');
                var BookData1;
                if (ItmArr2[0] == 'B') {
                    BookData1 = 'B±';
                }
                else if (ItmArr2[0] == 'K') {
                    BookData1 = 'K±';
                }
                var bookletitem_id_s = document.getElementById("spn_bookletitem_" + EstimateItemID + "").innerHTML;
                var bookletitemArray = bookletitem_id_s.split('|');
                for (var s = 0; s < bookletitemArray.length; s++) {
                    if (bookletitemArray[s] != "") {
                        var BookArray = bookletitemArray[s].split('-');
                        var EstimateBookletItemID = BookArray[0];
                        var QtyCount = BookArray[1];

                        for (var j = 0; j < QtyCount; j++) {
                            if (document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "") != null) {
                                var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + "");
                                var ProfitMargin = document.getElementById("ddlProfit_" + EstimateItemID + "_0_" + EstimateBookletItemID + "");
                                var Tax = document.getElementById("ddlTax_" + EstimateItemID + "_" + EstimateBookletItemID + "");
                                //spanTotalSellingPrice = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + ""); //span                                

                                var spanQty = document.getElementById("spanQty_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
                                var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
                                var total = RemoveDollorAndComma(txtSubTotal.value); //.replace(/,/,'').replace('$','');
                                var costExmarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
                                var totalmarkupprice = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");

                                BookData1 += "EstimateItemID»" + EstimateItemID + "±";
                                BookData1 += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                                BookData1 += "ProfitMargin»" + ProfitMargin.value + "±";
                                BookData1 += "Tax»" + Get_Tax_Value(Tax.value) + "±";
                                BookData1 += "TaxID»" + Tax.value + "±";

                                if (QtyCount == j) {
                                    BookData1 += "SubTotal»" + total + "±";
                                    BookData1 += "Quantity»" + spanQty.innerHTML + "±";
                                    BookData1 += "EstimateBookletItemID»" + EstimateBookletItemID + "±";
                                    BookData1 += "costExmarkup»" + RemoveDollorAndComma(costExmarkup.innerHTML) + "±";
                                    BookData1 += "totalmarkupprice»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                                    BookData1 += "µ";
                                }
                                else {
                                    BookData1 += "SubTotal»" + total + "±";
                                    BookData1 += "Quantity»" + spanQty.innerHTML + "±";
                                    BookData1 += "EstimateBookletItemID»" + EstimateBookletItemID + "±";
                                    BookData1 += "costExmarkup»" + RemoveDollorAndComma(costExmarkup.innerHTML) + "±";
                                    BookData1 += "totalmarkupprice»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                                    BookData1 += "§";
                                }
                                if (j == 0) {
                                    var taxvalue_All = Number(Number(txtSubTotal.value) * Get_Tax_Value(Tax.value)) / 100;
                                    spanTotalSellingPrice += Number(Number(txtSubTotal.value) + taxvalue_All);

                                    SubTotal += Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "").value));
                                }
                            }
                        }
                    }
                }

                AllData += BookData1 + "µ";
                //-------- Estimate Values -------
                var BookSellPrice = Number(spanTotalSellingPrice);
                BookSellPrice = roundNumber(BookSellPrice, 2);

                EstValues = Number(EstValues) + Number(BookSellPrice);
                EstValues = roundNumber(EstValues, 2);

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }
            else if (ItmArr2[0] == "Q") {

                var spanTotalSellingPrice = '';
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                QtyCount = Number(ItmArr2[2]);

                var SingleData = 'Q±';
                for (var j = 0; j < QtyCount; j++) {
                    if (j == 0) {
                        //var txtSectionRef = document.getElementById("txtSectionReference_"+EstimateItemID+"");
                        var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + "");
                        var ProfitMargin = document.getElementById("ddlProfit_" + EstimateItemID + "_" + j + "");
                        var Tax = document.getElementById("ddlTax_" + EstimateItemID + "_" + j + "");
                        SingleData += "EstimateItemID»" + EstimateItemID + "±";
                        SingleData += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                        //SingleData +="SectionRef»"+ txtSectionRef.value +"±";
                        SingleData += "ProfitMargin»" + ProfitMargin.value + "±";
                        SingleData += "Tax»" + Get_Tax_Value(Tax.value) + "±";
                        SingleData += "TaxID»" + Tax.value + "±";

                        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "");
                        SubTotal = Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "").value));
                    }

                    var spanQty_qty = document.getElementById("spanQty_qty_" + EstimateItemID + "_" + j + "");
                    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "");
                    var spanQtyID = document.getElementById("spanQty_" + EstimateItemID + "_" + j + "");
                    var Costpriceexmarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "");
                    var totalmarkupprice = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "");
                    if (QtyCount - 1 == j) {
                        SingleData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        SingleData += "»" + spanQty_qty.innerHTML + "»" + RemoveDollorAndComma(Costpriceexmarkup.innerHTML) + "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                        AllData += SingleData + "µ";
                    }
                    else {
                        SingleData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        SingleData += "»" + spanQty_qty.innerHTML + "»" + RemoveDollorAndComma(Costpriceexmarkup.innerHTML) + "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML) + "§";
                    }
                }

                //----- Estimate Values ------
                var SingleSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                SingleSellPrice = SingleSellPrice;

                //AllData += SingleData + "µ"; 

                EstValues = Number(EstValues) + Number(SingleSellPrice);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }
            else if (ItmArr2[0] == "N") {
                //----Estimate Values
                var spanTotalSellingPrice = 0.0;
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                var QtyCount; //ItmArr2[2]; 
                var SectionList; // = ItmArr2[3].split('§');

                var BookData1 = 'N±';
                var bookletitem_id_s = document.getElementById("spn_bookletitem_" + EstimateItemID + "").innerHTML;
                var bookletitemArray = bookletitem_id_s.split('|');
                for (var s = 0; s < bookletitemArray.length; s++) {
                    if (bookletitemArray[s] != "") {
                        var BookArray = bookletitemArray[s].split('-');
                        var EstimateBookletItemID = BookArray[0];
                        var QtyCount = BookArray[1];

                        for (var j = 0; j < QtyCount; j++) {
                            if (document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "") != null) {
                                var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + "");
                                var ProfitMargin = document.getElementById("ddlProfit_" + EstimateItemID + "_0_" + EstimateBookletItemID + "");
                                var Tax = document.getElementById("ddlTax_" + EstimateItemID + "_" + EstimateBookletItemID + "");
                                //spanTotalSellingPrice = document.getElementById("span_SellingPriceInTax_" + EstimateItemID + "_" + j + ""); //span                                

                                var spanQty = document.getElementById("spanQty_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
                                var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
                                var total = RemoveDollorAndComma(txtSubTotal.value); //.replace(/,/,'').replace('$','');
                                var costExmarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");
                                var totalmarkupprice = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "");

                                BookData1 += "EstimateItemID»" + EstimateItemID + "±";
                                BookData1 += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                                BookData1 += "ProfitMargin»" + ProfitMargin.value + "±";
                                BookData1 += "Tax»" + Get_Tax_Value(Tax.value) + "±";
                                BookData1 += "TaxID»" + Tax.value + "±";

                                if (QtyCount == j) {
                                    BookData1 += "SubTotal»" + total + "±";
                                    BookData1 += "Quantity»" + spanQty.innerHTML + "±";
                                    BookData1 += "EstimateBookletItemID»" + EstimateBookletItemID;
                                    BookData1 += "costExmarkup»" + RemoveDollorAndComma(costExmarkup.innerHTML) + "±";
                                    BookData1 += "totalmarkupprice»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                                    BookData1 += "µ";
                                }
                                else {
                                    BookData1 += "SubTotal»" + total + "±";
                                    BookData1 += "Quantity»" + spanQty.innerHTML + "±";
                                    BookData1 += "EstimateBookletItemID»" + EstimateBookletItemID + "±";
                                    BookData1 += "costExmarkup»" + RemoveDollorAndComma(costExmarkup.innerHTML) + "±";
                                    BookData1 += "totalmarkupprice»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                                    BookData1 += "§";
                                }

                                if (j == 0) {
                                    var taxvalue_All = Number(Number(txtSubTotal.value) * Get_Tax_Value(Tax.value)) / 100;
                                    spanTotalSellingPrice += Number(Number(txtSubTotal.value) + taxvalue_All);

                                    SubTotal = Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "_" + EstimateBookletItemID + "").value));
                                }
                            }
                        }
                    }
                }

                AllData += BookData1 + "µ";
                //-------- Estimate Values -------
                var BookSellPrice = Number(spanTotalSellingPrice);
                BookSellPrice = roundNumber(BookSellPrice, 2);

                EstValues = Number(EstValues) + Number(BookSellPrice);
                EstValues = roundNumber(EstValues, 2);

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }

            else if (ItmArr2[0] == "F") {
                var spanTotalSellingPrice = '';
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                QtyCount = Number(ItmArr2[2]);

                var SingleData = 'F±';
                for (var j = 0; j < QtyCount; j++) {
                    if (j == 0) {
                        //var txtSectionRef = document.getElementById("txtSectionReference_"+EstimateItemID+"");
                        var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + "");
                        var ProfitMargin = document.getElementById("ddlProfit_" + EstimateItemID + "_" + j + "");
                        var Tax = document.getElementById("ddlTax_" + EstimateItemID + "_" + j + "");
                        SingleData += "EstimateItemID»" + EstimateItemID + "±";
                        SingleData += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                        //SingleData +="SectionRef»"+ txtSectionRef.value +"±";
                        SingleData += "ProfitMargin»" + ProfitMargin.value + "±";
                        SingleData += "Tax»" + Get_Tax_Value(Tax.value) + "±";
                        SingleData += "TaxID»" + Tax.value + "±";

                        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "");
                        SubTotal = Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "").value));
                    }

                    var spanQty_qty = document.getElementById("spanQty_qty_" + EstimateItemID + "_" + j + "");
                    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "");
                    var spanQtyID = document.getElementById("spanQty_" + EstimateItemID + "_" + j + "");
                    var costExmarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "");
                    var totalmarkupprice = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "");

                    if (QtyCount - 1 == j) {
                        SingleData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        SingleData += "»" + spanQty_qty.innerHTML;
                        SingleData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        SingleData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                        AllData += SingleData + "µ";
                    }
                    else {
                        SingleData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        SingleData += "»" + spanQty_qty.innerHTML;
                        SingleData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        SingleData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML) + "§";
                    }
                }
                //----- Estimate Values ------
                var SingleSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                SingleSellPrice = SingleSellPrice;

                EstValues = Number(EstValues) + Number(SingleSellPrice);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }
            else if (ItmArr2[0] == "D") {
                var spanTotalSellingPrice = '';
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                QtyCount = Number(ItmArr2[2]);

                var PadData = 'D±';
                for (var j = 0; j < QtyCount; j++) {
                    if (j == 0) {
                        var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + "");
                        var ProfitMargin = document.getElementById("ddlProfit_" + EstimateItemID + "_" + j + "");
                        var Tax = document.getElementById("ddlTax_" + EstimateItemID + "_" + j + "");
                        PadData += "EstimateItemID»" + EstimateItemID + "±";
                        PadData += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                        PadData += "ProfitMargin»" + ProfitMargin.value + "±";
                        PadData += "Tax»" + Get_Tax_Value(Tax.value) + "±";
                        PadData += "TaxID»" + Tax.value + "±";

                        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + j + "");
                        SubTotal = RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "").value);
                    }
                    var spanQty_qty = document.getElementById("spanQty_qty_" + EstimateItemID + "_" + j + "");
                    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + j + "");
                    var spanQtyID = document.getElementById("spanQty_" + EstimateItemID + "_" + j + "");
                    var costExmarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + j + "");
                    var totalmarkupprice = document.getElementById("span_Markup_" + EstimateItemID + "_" + j + "");

                    if (QtyCount - 1 == j) {
                        PadData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        PadData += "»" + spanQty_qty.innerHTML;
                        PadData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        PadData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML);
                        AllData += PadData + "µ";
                    }
                    else {
                        PadData += "SubTotal»" + RemoveDollorAndComma(txtSubTotal.value) + "»" + spanQtyID.innerHTML;
                        PadData += "»" + spanQty_qty.innerHTML;
                        PadData += "»" + RemoveDollorAndComma(costExmarkup.innerHTML);
                        PadData += "»" + RemoveDollorAndComma(totalmarkupprice.innerHTML) + "§";
                    }
                }
                //----- Estimate Values ------
                var PadSellPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);
                PadSellPrice = PadSellPrice;

                EstValues = Number(EstValues) + Number(PadSellPrice);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }

            else if (ItmArr2[0] == "C") {
                var CatalogueData = 'C±';
                var SubTotal = 0;
                EstimateItemID = ItmArr2[1];
                var CataPrice = 0;
                for (var q = 0; q < 4; q++) {
                    var ddlProfit = document.getElementById("ddlProfit_" + EstimateItemID + ""); //ddl
                    if (document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID + "") != null) {
                        var txtSubTotal = document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID + ""); //TextBox
                        var EstPriceCatalogueID = document.getElementById("span_EstPriceCatalogueID_" + q + "_" + EstimateItemID + ""); //SPAN
                        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + ""); //ddl

                        txtSubTotal.value = RemoveDollorAndComma(txtSubTotal.value); //.replace(/,/, '');

                        var txtItemTitle = document.getElementById("txtItemTitle_" + EstimateItemID + ""); //TextBox
                        CatalogueData += "EstimateItemID»" + EstimateItemID + "±";
                        CatalogueData += "ProfitMargin»" + ddlProfit.value + "±";
                        CatalogueData += "SubTotal»" + txtSubTotal.value + "±";
                        CatalogueData += "Tax»" + Get_Tax_Value(ddlTax.value) + "±";
                        CatalogueData += "TaxID»" + ddlTax.value + "±";
                        CatalogueData += "ItemTitle»" + txtItemTitle.innerHTML + "±";
                        CatalogueData += "EstPriceCatalogueID»" + EstPriceCatalogueID.innerHTML + "§";
                        //----- Estimate Values ------
                        if (q == 0) {
                            var spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + q + "_" + EstimateItemID + ""); //span
                            CataPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML); //.replace('$', '').replace(/,/, '');
                            CataPrice = CataPrice;

                            SubTotal = Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID + "").value));
                        }
                    }
                }

                AllData += CatalogueData + "µ";
                if (txtItemTitle.innerHTML == '') {
                    alert('Item Title cannot be Empty ');
                    return false;
                }
                EstValues = Number(EstValues) + Number(CataPrice);
                EstValues = EstValues;

                EstValueExTax = Number(EstValueExTax) + Number(SubTotal);
                EstValueExTax = EstValueExTax;
            }
        }
    }

    hidOverallList.value = AllData;
    //--- Estimate Values
    hidEstimateValue.value = EstValues;
    hidEstimateSubTotal.value = EstValueExTax;
    return true;
}

//PRICE CATALOGUE
function CatalogueTaxandProfitOnChange(Percentage, EstimateItemID, type) {
    for (var q = 0; q < 4; q++) {
        var SpanMarkup = document.getElementById("span_Markup_" + q + "_" + EstimateItemID + "");
        if (SpanMarkup != null) {
            var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + q + "_" + EstimateItemID + "");
            var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + q + "_" + EstimateItemID + "");
            var txtSubTotal = document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID + ""); //TextBox
            var SpanTax = document.getElementById("span_Tax_" + q + "_" + EstimateItemID + "");
            var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "");

            var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + q + "_" + EstimateItemID + "");
            var SpanGrossProfit = document.getElementById("span_GrossProfit_" + q + "_" + EstimateItemID + "");

            var Taxsummary = document.getElementById("span_Tax_summary_" + q + "_" + EstimateItemID + "");
            var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + q + "_" + EstimateItemID + "");
            var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + q + "_" + EstimateItemID + "");

            var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
            var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
            var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
            var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
            var TaxValue = 0;
            var SellInTax = 0;
            var subValue = 0;

            if (type == "profit") {
                var profit = Percentage;
                ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit)) / 100;
                ProfitMarginValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ProfitMarginValue, 0, '', false, false, true);
                SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;

                subValue = Number(SellingPriceInMarkupValue) + Number(ProfitMarginValue);
                subValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, subValue, 0, '', false, false, true);
                txtSubTotal.value = subValue;
            }
            else {
                subValue = SubTotalValue;
            }

            TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value))) / 100;
            TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);
            SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;

            SellInTax = Number(TaxValue) + Number(subValue);
            SellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInTax, 0, '', false, false, true);
            SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;

            var GrossPercent = 0;
            var GrossValue = Number(Markup) + Number(ProfitMarginValue);
            GrossValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);

            if (Number(SellInTax) == 0) {
                SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
            }
            else {
                GrossPercent = (Number(Markup) + Number(ProfitMarginValue)) / Number(subValue);
                GrossPercent = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (GrossPercent * 100), 0, '', false, false, true);
                SpanGrossProfit.innerHTML = "(" + GrossPercent + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
            }
            Taxsummary.innerHTML = SpanTax.innerHTML;
            TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
            GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
        }
    }
}

function CatalogueOnBlur(subValue, EstimateItemID, q) {
    if (!isNaN(subValue) && subValue != '') {
        var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_" + q + "_" + EstimateItemID + "");
        var profit = document.getElementById("ddlProfit_" + EstimateItemID + "").value;
        var SpanMarkup = document.getElementById("span_Markup_" + q + "_" + EstimateItemID + "");
        var SpanSellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + q + "_" + EstimateItemID + "");
        var SpanProfitMargin = document.getElementById("span_ProfitMargin_" + q + "_" + EstimateItemID + "");
        var txtSubTotal = document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID + ""); //TextBox
        var SpanTax = document.getElementById("span_Tax_" + q + "_" + EstimateItemID + "");
        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "");
        var SpanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + q + "_" + EstimateItemID + "");
        var SpanGrossProfit = document.getElementById("span_GrossProfit_" + q + "_" + EstimateItemID + "");

        var Taxsummary = document.getElementById("span_Tax_summary_" + q + "_" + EstimateItemID + "");
        var TotalSellingPricesummary = document.getElementById("span_TotalSellingPrice_summary_" + q + "_" + EstimateItemID + "");
        var GrossProfitsummary = document.getElementById("span_GrossProfit_summary_" + q + "_" + EstimateItemID + "");

        var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);
        var Markup = RemoveDollorAndComma(SpanMarkup.innerHTML);
        var SellingPriceInMarkupValue = RemoveDollorAndComma(SpanSellingPriceInMarkup.innerHTML);
        var ProfitMarginValue = RemoveDollorAndComma(SpanProfitMargin.innerHTML);
        var SubTotalValue = RemoveDollorAndComma(txtSubTotal.value);
        var TaxValue = 0; //SpanTax.innerHTML.replace('$','').replace(/,/,'');
        var SellInTax = 0;

        ProfitMarginValue = (Number(SellingPriceInMarkupValue) * Number(profit)) / 100;
        ProfitMarginValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, ProfitMarginValue, 0, '', false, false, true);
        SpanProfitMargin.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + ProfitMarginValue;

        subValue = RemoveDollorAndComma(subValue);

        TaxValue = (Number(subValue) * Number(Get_Tax_Value(ddlTax.value))) / 100;
        TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);
        SpanTax.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + TaxValue;

        SellInTax = Number(TaxValue) + Number(subValue);
        SellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInTax, 0, '', false, false, true);
        SpanTotalSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInTax;

        document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID + "").value = subValue;
        document.getElementById("txtSummarySubTotal_" + q + "_" + EstimateItemID + "").value = subValue;

        var GrossPercent = 0;
        var GrossValue = GrossProfit_Value(Number(CostPriceExMarkup), Number(subValue));
        if (Number(subValue) == 0) {
            SpanGrossProfit.innerHTML = "(0.00%) " + "" + GetCurrencyinRequiredFormate("", true) + "" + GrossValue + "";
        }
        else {
            GrossPercent = GrossProfit_Percentage(Number(subValue), Number(GrossValue));
            SpanGrossProfit.innerHTML = "(" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercent, 0, '', false, false, true) + "%)&nbsp;&nbsp;" + "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true) + "";
        }
        Taxsummary.innerHTML = SpanTax.innerHTML;
        TotalSellingPricesummary.innerHTML = SpanTotalSellingPrice.innerHTML;
        GrossProfitsummary.innerHTML = SpanGrossProfit.innerHTML;
    }
    else {
        document.getElementById("txtSubTotal_" + q + "_" + EstimateItemID + "").value = "0";
    }
    //alert("hi");    
    //    document.getElementById("txtSubTotal_" + EstimateItemID + "_" + i + "").value = subValue;
    //    document.getElementById("txtSummarySubTotal_" + EstimateItemID + "_" + i + "").value = subValue;
    //txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, subValue, 0, '', false, false, true);
}


function Get_Tax_Value(TaxID) {
    var Array_0 = hid_tax_values.value.split('±');

    for (var i = 0; i < Array_0.length; i++) {
        if (Array_0[i] != '') {
            var Array_1 = Array_0[i].split('»');
            if (Array_1[0] == TaxID) {
                return Array_1[2];
            }
        }
    }
    return 0;
}

function RemoveDollorAndComma(Values_data) {
    var val1 = GetCurrencyinRequiredFormate("", true);
    var val = Values_data.replace(val1, '');
    
   
    
    val = val.replace(/,/, '').replace(/,/, '');
    val = val.replace(/,/, '').replace(/,/, '');

    return val;
}






//********** web service to autocomplete clientname *********//

function ClearStage1Data() {
    hid_Greeting.value = "";
    txtName.value = "";
    hid_CustName.value = "";
    hid_ClientID.value = 0;
    hid_Contact.value = "";
    hid_contactId.value = 0;
    hid_contactName.value = "";
}

//function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address) {
function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address, DepartmentName, DepartmentID, InvoiceAddressID, InvoiceAddress, ContactAddress, ContactAddressID) {
    //alert("ClientID=" + ClientID + "ContactAddressID=" + ContactAddressID + ",ContactAddress=" + ContactAddress + ", DepartmentID=" + DepartmentID + ",DepartmentName=" + DepartmentName + ",InvoiceAddressID=" + InvoiceAddressID + ", InvoiceAddress=" + InvoiceAddress);
    ClearStage1Data();
    hid_Greeting.value = "Dear";
    txtName.value = ClientName;
    hid_CustName.value = ClientName;
    hid_ClientID.value = ClientID;
    hid_AccountNo.value = AccountNo;

    var DefaultContact = '';
    var DefaultContctID = 0;
    hid_Contact.value = Contacts;
    var str_con1 = Contacts.split('^');

    for (var k = 0; k < str_con1.length; k++) {
        // if (k == 0) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            ContactName = trim12(ContactIDName[1]);
            DefaultContact = ContactIDName[2];
        }
        if (DefaultContact == "1") {
            hdn_Attention.value = ContactID;
        }
    }
    // }   


    //*****************************************************************
    AutoFill.GetContactAddress(CompanyID, hdn_Attention.value, GetAddress);

    function GetAddress(result) {
        var Address = '';
        var add = result.split('±');
        for (var j = 0; j < add.length; j++) {
            var str = add[j].split('»');
            if (trim12(str[0]) == "DeliveryAddressID") {
                hid_DeliveryAddressID.value = str[1];
            }
            if (trim12(str[0]) == "ContactAddressID") {
                hid_contactId.value = str[1];
            }
            if (trim12(str[0]) == "InvoiceAddressID") {
                hdn_InvAddressID.value = str[1];
            }
        }
    }
    //*****************************************************************
    //hid_contactId.value = DefaultContctID;
    hid_contactName.value = ContactName;

    var firstname = ContactName.split(' ');
    hid_Greeting.value = hid_Greeting.value + ' ' + firstname[0];

    if (Address != '') {
        var str_add1 = Address.split('»'); //Plain1^Silk^Graphic^gfdsgbfs^test^Plain

        for (var i = 0; i < str_add1.length; i++) {
            if (str_add1[i] != '') {
                var AddressID = str_add1[0];
                var Address1 = str_add1[1];
                var LimitAddress = str_add1[2];
                var IsDelivery = str_add1[3];
                var AddressType = str_add1[4];
                var Address_Limit;

                Address_Limit = Address1;

                //hdnAddressID.value = AddressID;                
                //hid_IsDelivery.value = IsDelivery;

                //hid_DeliveryAddressID.value = AddressID;  

                // alert(hid_DeliveryAddressID.value);
                //                lblDeliveryAddress.innerHTML = Address_Limit;
                //                lblDeliveryAddress.title = Address1;
                //hid_DelAddressType.value = AddressType;

            }
        }
    }
}
//********** End Of web service to autocomplete clientname *********//



//to validate date while progress to invoice
function validate_date() {

    CheckFinal = false;
    var txtInvoicePaymentDate = trim12(txtInvoicePaymentDateID.value);
    if (txtInvoicePaymentDate == '') {
        document.getElementById("spn_InvoicePaymentDaterfq").style.display = "block";
        CheckFinal = true;

    }
    else {
        document.getElementById("spn_InvoicePaymentDaterfq").style.display = "none";

    }

    if (ValidateForm(txtInvoicePaymentDateID, 'spn_InvoicePaymentDaterfq', DateFormat_stage) == false) {
        CheckFinal = true;

    }

    if (CheckFinal) {

        return false;
    }
    else {
        if (InventoryManagement.toString().toLowerCase() == "im") {
            if (PgtypeNew.toLowerCase() == "job") {

                if (StockAlert()) {
                    document.getElementById("div_Load").style.display = "block";
                    document.getElementById("div_ProgressToInvoice").style.display = "none";
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        document.getElementById("div_Load").style.display = "block";
        document.getElementById("div_ProgressToInvoice").style.display = "none";
        return true;
    }
}

//to validate customer while copy estimate to new customer

var divCopyto_new_customer = document.getElementById("divCopyto_new_customer");

function validate_estCopy() {

//    var centerWidth = (window.screen.width - 400) / 2;
//    var centerHeight = (window.screen.height - 300) / 2;

//    var objCategoryDiv = document.getElementById("divCopyto_new_customer");
//    objdivision = null;
//    objCategoryDiv.style.top = "50px";
//    objCategoryDiv.style.bottom = "50px";
//    objCategoryDiv.style.left = centerWidth + "px";
//    objCategoryDiv.style.right = centerHeight + "px";

//    objCategoryDiv.style.display = "block";
//    objCategoryDiv.style.zIndex = 102;

//    var divisionloading = document.getElementById("divCopyto_new_customer");
//    divisionloading.style.left = ((document.body.clientWidth - divisionloading.offsetWidth) / 2) + "px";
//    divisionloading.style.right = ((document.body.clientWidth - divisionloading.offsetWidth) / 2) + "px";
    
    var IsCorrect = false;
    if (CheckStringMandatory(txtName.value, 'spn_txtName')) {        
        IsCorrect = true;        
        document.getElementById("spn_txtName").innerHTML = 'Please select Customer';           
        
     }
    else {
        if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
            IsCorrect = true;
            document.getElementById("spn_txtName").style.display = "block";
            document.getElementById("spn_txtName").innerHTML = 'Please select valid Customer';
        }
        else if (hid_CustName.value != txtName.value) {
            IsCorrect = true;
            document.getElementById("spn_txtName").style.display = "block";
            document.getElementById("spn_txtName").innerHTML = 'Please select valid Customer';
        }
        else {
            document.getElementById("spn_txtName").style.display = "none";
        }
    }

    if (IsCorrect) {
        return false;
    }
    else {
        return true;
        //        if (module == "job") {
        //            alert_CopyJobInvoicetoNewConfirm();
        //            return false;
        //        }
        //        else if (module == "invoice") {
        //            alert_CopyJobInvoicetoNewConfirm();
        //            return false;
        //        }
        //        else 
        //        if (module == "estimate") {
        //            __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummary$lnkEstimateCopytoNewCustArchive', '');
        //            return false;
        //        }
    }   

}

function showDivPopupMove2(divCopyto_new_customer, windowHeight, windowWidth) {
    var centerWidth = (window.screen.width - 1000) / 2;
    var centerHeight = (window.screen.height - 500) / 4;

    var objCategoryDiv = document.getElementById(divId);
    objdivision = null;
    objCategoryDiv.style.top = "50px";
    objCategoryDiv.style.left = centerWidth + "px";

//    document.getElementById("divBackGround1").style.display = "block";

    objCategoryDiv.style.display = "";
    objCategoryDiv.style.zIndex = 102;

    var divisionloading = document.getElementById(divId);
    divisionloading.style.left = ((document.body.clientWidth - divisionloading.offsetWidth) / 2) + "px";

    var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;

    divisionloading.style.top = (top + 230) + "px";

//    var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
//    var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight
//    var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth
//    var DivBack = document.getElementById("divBackGround1");
//    if (DivBack != null) {
//        DivBack.style.left = "0px";
//        DivBack.style.width = docwidthcomplete + "px";
//        DivBack.style.height = docheightcomplete + "px";
//        DivBack.style.top = top + "px";
//    }
    return false;
}


function alert_CopyJobInvoicetoNewConfirm() {
    if (document.getElementById("divcopy_job_invoice_confirm").style.display == "none") {
        document.getElementById("divcopy_job_invoice_confirm").style.width = 300 + "px";
        document.getElementById("divcopy_job_invoice_confirm").style.height = 150 + "px";
        document.getElementById("divcopy_job_invoice_confirm").style.display = "block";
        document.getElementById("divlabelNewcust").style.display = "block";
        document.getElementById("divlabelNewcust").style.display = "block";
        document.getElementById("divlabelSamecust").style.display = "none";
        document.getElementById("divCopyto_new_customer").style.display = "none";

        if (module == "job") {
            document.getElementById("jobconfirmcopy_alert").style.display = "block";
        }
        if (module == "invoice") {
            document.getElementById("invoiceconfirmcopy_alert").style.display = "block";
        }
        document.getElementById("div_CopyNewCustomar").style.display = "block";
        document.getElementById("div_CopySameCustomar").style.display = "none";
    }
}

//to clear dates on progress to job
function ClearDates() {
    txtartworkdate.value = '';
    txtproofdate.value = '';
    txtapprovaldate.value = '';
    txtproductiondate.value = '';
    txtcompletiondate.value = '';
    txtdeliverydate.value = '';

}


//=========================  Re_ENG on 27-3-2012  (donot delete)  ==========================//
/*
function HighlightTab(objID, TabType) {
    hdn_SelectedItemTab.value = objID;
    document.getElementById(objID).style.color = "orange";

    if (TabType == "EstInfo") {
        document.getElementById("spnHeaderItem_EstInfo").style.color = "orange";
    }
    else {
        document.getElementById("spnHeaderItem_EstInfo").style.color = "black";
    }

    for (var i = 0; i <= ItemLoopCnt; i++) {
        var dd = "spnHeaderItem_" + i;
        if (dd != '') {
            if (dd != objID) {
                if (document.getElementById("spnHeaderItem_" + i) != null) {
                    document.getElementById("spnHeaderItem_" + i).style.color = "black";

                    document.getElementById("divItem_" + i + "").style.display = "none";
                }
            }
            else {
                hdn_SelectedItemNo.value = i;
                hdn_SelectedEstItemID.value = document.getElementById("spnHeaderEstItemID_" + i).innerHTML;
                hdn_SelectedEstItemType.value = document.getElementById("spnHeaderEstItemType_" + i).innerHTML;

                document.getElementById("divItem_" + i + "").style.display = "block";
            }
        }
    }

    divEstInfo.style.display = "none";
    divItemInfo.style.display = "block";
    tblMessage.style.display = "none";
    if (objID == "spnHeaderItem_EstInfo") {
        divEstInfo.style.display = "block";
    }
    else {
        divItemInfo.style.display = "block";
        document.getElementById("divItem_" + hdn_SelectedItemNo.value + "").style.display = "block";
        //        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummary$lnkShowItemDetails', '');
        //return false;
    }
}

if (hdn_SelectedItemTab.value == "") {
    HighlightTab("spnHeaderItem_EstInfo", 'EstInfo');
}
else {
    HighlightTab(hdn_SelectedItemTab.value, 'ItemInfo');
}


function ProfitMarginShow_SinglePadLarge_ReEng(priftValue, EstimateItemID, QtyCount, ItemNo, j, profittype) {
    var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var MarkUp = document.getElementById("span_Markup_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var SellingPriceInMarkup = document.getElementById("span_SellingPriceInMarkup_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var txtProfitMarginPerCent = document.getElementById("txtProfitPercentage_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var txtProfitMarginPrice = document.getElementById("txtProfitPrice_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var Tax = document.getElementById("span_Tax_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_0_0");
    var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var GrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + ItemNo + "_" + j + "");

    var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);
    var MarkUpValue = RemoveDollorAndComma(MarkUp.innerHTML);
    var SellingPriceInMarkupValue = RemoveDollorAndComma(SellingPriceInMarkup.innerHTML);
    var ProfitMarginPerCent = RemoveDollorAndComma(txtProfitMarginPerCent.value);
    var ProfitMarginValue = RemoveDollorAndComma(txtProfitMarginPrice.value);
    var TaxValue = RemoveDollorAndComma(Tax.innerHTML);
    var TotalSellingPriceValue = RemoveDollorAndComma(TotalSellingPrice.innerHTML);
    var GrossProfitValue = RemoveDollorAndComma(GrossProfit.innerHTML);

    txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPriceInMarkupValue, 0, '', false, false, false);

    var Profit = 0.00;
    if (profittype == "percent") {
        Profit = (Number(SellingPriceInMarkupValue) * Number(priftValue)) / 100;
        txtProfitMarginPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Profit, 0, '', false, false, false);
    }
    else {
        Profit = priftValue;
        var Temp_ProfitPercent = (RemoveDollorAndComma(priftValue) * 100) / RemoveDollorAndComma(SellingPriceInMarkup.innerHTML);
        txtProfitMarginPerCent.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Temp_ProfitPercent, 0, '', false, false, false);
        txtProfitMarginPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, priftValue, 0, '', false, false, false);
    }

    txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Profit) + Number(txtSubTotal.value), 0, '', false, false, false);
    TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(ddlTax.value))) / 100;
    Tax.innerHTML = "$" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, false);
    var SellingPrice = Number(TaxValue) + Number(txtSubTotal.value);
    TotalSellingPrice.innerHTML = "$" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, false);

    var subTotal = txtSubTotal.value;
    var GrossValue = GrossProfit_Value(Number(CostPriceExMarkup), Number(subTotal));
    if (Number(txtSubTotal.value) == "0") {
        GrossProfit.innerHTML = "(0.00%)&nbsp;&nbsp;$" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, false);
    }
    else {
        var GrossPercentage = GrossProfit_Percentage(Number(subTotal), Number(GrossValue));
        GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, false);
        GrossProfit.innerHTML = "(" + GrossPercentage + "%)&nbsp;&nbsp;$" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, false);
    }
}

function SinglePadLarge_TaxOnChange_ReEng(TaxPercent, EstimateItemID, QtyCount, ItemNo) {
    for (var j = 0; j < QtyCount; j++) {
        var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var span_ProfitMargin = document.getElementById("txtProfitPercentage_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var span_Markup = document.getElementById("span_Markup_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var Tax = document.getElementById("span_Tax_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var TotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var GrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + ItemNo + "_" + j + "");

        var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);
        var Profit = RemoveDollorAndComma(span_ProfitMargin.value);
        var MarkUpValue = RemoveDollorAndComma(span_Markup.innerHTML);
        var TaxValue = (Number(txtSubTotal.value) * Number(Get_Tax_Value(TaxPercent))) / 100;

        Tax.innerHTML = "$" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, true);

        var SellingPrice = Number(txtSubTotal.value) + Number(TaxValue);
        SellingPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, true);

        TotalSellingPrice.innerHTML = "$" + SellingPrice;

        var subTotal = txtSubTotal.value;
        var GrossValue = GrossProfit_Value(Number(CostPriceExMarkup), Number(subTotal));
        if (SellingPrice == "0") {
            GrossProfit.innerHTML = "(0.00%)&nbsp;&nbsp;$" + GrossValue;
        }
        else {
            var GrossPercentage = GrossProfit_Percentage(Number(subTotal), Number(GrossValue));
            GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, true);
            GrossProfit.innerHTML = "(" + GrossPercentage + "%)&nbsp;&nbsp;$" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, true);
        }
    }
}

function OnBlur_SinglePadLarge_SubTotal_ReEng(subTotal, EstimateItemID, ItemNo, j) {
    var span_CostPriceExMarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var SpnProfitMargin = document.getElementById("span_ProfitMargin_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var SpnMarkup = document.getElementById("span_Markup_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var SpnTax = document.getElementById("span_Tax_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_0_0");
    var txtProfitMarginPerCent = document.getElementById("txtProfitPercentage_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var txtProfitMarginPrice = document.getElementById("txtProfitPrice_" + EstimateItemID + "_" + ItemNo + "_" + j + "");

    var SpnSellingPriceInTax = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
    var SpnGrossProfit = document.getElementById("span_GrossProfit_" + EstimateItemID + "_" + ItemNo + "_" + j + "");

    if (!isNaN(subTotal)) {
        var CostPriceExMarkup = RemoveDollorAndComma(span_CostPriceExMarkup.innerHTML);
        var MarkupValue = RemoveDollorAndComma(SpnMarkup.innerHTML);
        var GrossProfitValue = 0;
        var GrossPercentage = 0;
        var TaxValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(subTotal) * Number(Get_Tax_Value(ddlTax.value)) / 100), 0, '', false, false, true);
        var SellInTax = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(Number(subTotal) + Number(TaxValue))), 0, '', false, false, true);
        SpnTax.innerHTML = "$" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, false);
        SpnSellingPriceInTax.innerHTML = "$" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInTax, 0, '', false, false, false);
        GrossProfitValue = GrossProfit_Value(Number(CostPriceExMarkup), Number(subTotal));
        //alert(subTotal);
        document.getElementById("txtSubTotal_" + EstimateItemID + "_" + ItemNo + "_" + j + "").value = subTotal;

        if (Number(subTotal) == 0) {
            GrossPercentage = "0.00";
        }
        else {
            var topvalue = GrossProfit_Percentage(Number(subTotal), Number(GrossProfitValue));
            GrossPercentage = topvalue;
        }
        SpnGrossProfit.innerHTML = "(" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, false) + "%)&nbsp;&nbsp;$" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossProfitValue, 0, '', false, false, false);
    }
    else {
        document.getElementById("txtSubTotal_" + EstimateItemID + "_" + ItemNo + "_" + j + "").value = 0;
    }
}


//FINAL SAVE CLICK
function Estimate_Cal_Save_ReEng(EstimateItemID, QtyCount, ItemNo, btnType) {
    var lblItemTitle = document.getElementById("lblItemTitle_" + EstimateItemID + "");
    for (var j = 0; j < QtyCount; j++) {
        var spanTotalSellingPrice = '';

        var txtProfitMarginPerCent = document.getElementById("txtProfitPercentage_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var txtProfitMarginPrice = document.getElementById("txtProfitPrice_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var Tax = document.getElementById("ddlTax_" + EstimateItemID + "_0_0");
        var spnTaxPrice = document.getElementById("span_Tax_" + EstimateItemID + "_" + ItemNo + "_" + j + "");

        spanTotalSellingPrice = document.getElementById("span_TotalSellingPrice_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        SubTotal = Number(RemoveDollorAndComma(document.getElementById("txtSubTotal_" + EstimateItemID + "_" + ItemNo + "_" + j + "").value));

        var spanQty_qty = document.getElementById("spanQty_qty_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var txtSubTotal = document.getElementById("txtSubTotal_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var spanQtyID = document.getElementById("spanQty_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var costExmarkup = document.getElementById("span_CostPriceExMarkup_" + EstimateItemID + "_" + ItemNo + "_" + j + "");
        var totalmarkupprice = document.getElementById("span_Markup_" + EstimateItemID + "_" + ItemNo + "_" + j + "");

        var Qty = spanQty_qty.innerHTML;
        var SubTotal = RemoveDollorAndComma(txtSubTotal.value);
        var TaxPercentage = Get_Tax_Value(Tax.value);
        var TaxID = Tax.options[Tax.selectedIndex].value;
        var TaxValue = RemoveDollorAndComma(spnTaxPrice.innerHTML);
        var ProfitMargin = RemoveDollorAndComma(txtProfitMarginPerCent.value);
        var ProfitMarginPrice = RemoveDollorAndComma(txtProfitMarginPrice.value);
        var EstimateBookletItemID = 0;
        var CostPriceExMarkup = RemoveDollorAndComma(costExmarkup.innerHTML);
        var MarkupPrice = RemoveDollorAndComma(totalmarkupprice.innerHTML);
        var QtyNumber = j + 1;
        var SellingPrice = RemoveDollorAndComma(spanTotalSellingPrice.innerHTML);

        item_summary.SaveItemPriceDetails(CompanyID, EstimateItemID, Qty, SubTotal, TaxPercentage, ProfitMargin,
            TaxID, 0, EstimateBookletItemID, CostPriceExMarkup, MarkupPrice, ProfitMarginPrice, QtyNumber, TaxValue, SellingPrice);
    }
    if (btnType == 'stay') {
        tblMessage.style.display = "block";
        lblMessage.innerHTML = "Item updated successfully.";
        lblMessage.className = "msg-success";
    }
    else {
        location.href = "estimate_view.aspx";
    }

    return false;
}

function ShowSection_ReEng(obj, EstimateItemID, para2, para3, ItemNo) {
    //Para3 is Quantity Count and para2 is showtype
    var btnID = defaultButton.replace("T1E2S3T", "");
    obj.className = "booklet_section_active";
    if (para2 == 'all') {
        document.getElementById("div_AllSection_" + ItemNo).style.display = "block";
        for (var i = 0; i < para3; i++) {
            document.getElementById("div_Section_" + EstimateItemID + "_" + ItemNo + "_" + i + "").style.display = "none";
            document.getElementById("" + btnID + EstimateItemID + "_" + i + "").className = "booklet_section_normal";
        }

        //if (flag == 'Detail') {
        document.getElementById("div_alldetail_" + EstimateItemID + "").style.display = "block";
        //document.getElementById("div_allsummary_" + EstimateItemID + "").style.display = "none";
        // document.getElementById("divbtnSummary" + ItemNo + "").style.display = "block";
        //document.getElementById("divbtnDetail" + ItemNo + "").style.display = "none";
        //        }
        //        else if (flag == 'Summary') {
        //            document.getElementById("div_alldetail_" + EstimateItemID + "").style.display = "none";
        //            document.getElementById("div_allsummary_" + EstimateItemID + "").style.display = "block";
        //            document.getElementById("divbtnDetail" + ItemNo + "").style.display = "block";
        //            document.getElementById("divbtnSummary" + ItemNo + "").style.display = "none";
        //        }
    }
    else {
        document.getElementById("div_AllSection_" + ItemNo).style.display = "none";
        for (var i = 0; i < para3; i++) {
            document.getElementById("div_Section_" + EstimateItemID + "_" + ItemNo + "_" + i + "").style.display = "none";
            document.getElementById("" + btnID + EstimateItemID + "_" + i + "").className = "booklet_section_normal";
        }
        document.getElementById("" + btnID + EstimateItemID + "").className = "booklet_section_normal";
        document.getElementById("div_Section_" + EstimateItemID + "_" + para2 + "").style.display = "block";

        document.getElementById("" + btnID + EstimateItemID + "_" + para2 + "").className = "booklet_section_active";
        //these 2 lines added bec details should open automatically in parts
        document.getElementById("div_detail_" + EstimateItemID + "_" + para2 + "").style.display = "block";
       // document.getElementById("div_summary_" + EstimateItemID + "_" + para2 + "").style.display = "none";

        //show either detail/summary button-ayesha 11/2/11
       // document.getElementById("divbtnSummary" + ItemNo + "").style.display = "block";
        //document.getElementById("divbtnDetail" + ItemNo + "").style.display = "none";
    }
}
*/
//=========================  Re_ENG ENDS  (donot delete)  ==========================//