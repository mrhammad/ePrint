
//by irfan 2.0
function AllowNumber_WithNegative(obj, val) {
    if (!isNaN(val)) {
        return true;
    }
    else {
        obj.value = '';
        obj.focus();
        return false;
    }
}

function RadWinClose() {
    document.getElementById("divrad").style.display = "none";
    document.getElementById("divBackGroundNew").style.display = "none";
}

function ShowSection_ReEng(obj, EstimateItemID, SectionNo, SectionCount) {

    obj.className = "booklet_section_active";
    if (SectionNo == 'all') {
        document.getElementById("tblBookletItem_" + EstimateItemID + "_All").style.display = "";
        document.getElementById("btnSection_" + EstimateItemID + "_All").className = "booklet_section_active";

        document.getElementById("divTotal_" + EstimateItemID + "_All").style.display = "block";  //total div --declared in item_total usercontrol
        document.getElementById("div_SubItems_" + EstimateItemID + "").style.display = "block";  // sub items div -- declared in main page

        for (var i = 0; i < SectionCount; i++) {
            document.getElementById("tblBookletItem_" + EstimateItemID + "_" + i + "").style.display = "none";
            document.getElementById("btnSection_" + EstimateItemID + "_" + i + "").className = "booklet_section_normal";

            document.getElementById("divTotal_" + EstimateItemID + "_" + i + "").style.display = "none"; //total div 
        }
    }
    else {
        document.getElementById("tblBookletItem_" + EstimateItemID + "_All").style.display = "none";
        document.getElementById("btnSection_" + EstimateItemID + "_All").className = "booklet_section_normal";

        document.getElementById("divTotal_" + EstimateItemID + "_All").style.display = "none"; //total div
        document.getElementById("div_SubItems_" + EstimateItemID + "").style.display = "none";  // sub items div  

        for (var i = 0; i < SectionCount; i++) {
            document.getElementById("tblBookletItem_" + EstimateItemID + "_" + i + "").style.display = "none";
            document.getElementById("btnSection_" + EstimateItemID + "_" + i + "").className = "booklet_section_normal";

            document.getElementById("divTotal_" + EstimateItemID + "_" + i + "").style.display = "none";  //total div
        }

        document.getElementById("tblBookletItem_" + EstimateItemID + "_" + SectionNo + "").style.display = "";
        document.getElementById("btnSection_" + EstimateItemID + "_" + SectionNo + "").className = "booklet_section_active";

        document.getElementById("divTotal_" + EstimateItemID + "_" + SectionNo + "").style.display = "block";  //total div
    }
}

function GrossProfit_Value(CostPriceExMark, SubToal) {
    var GrossValue = Number(SubToal) - Number(CostPriceExMark);
    return GrossValue;
}

function GrossProfit_Percentage(SubToal, GrossValue) {
    var GrossPercentage = 0;
    if (Number(SubToal) > 0) {
        GrossPercentage = (Number(GrossValue) / Number(SubToal)) * 100;
    }
    return GrossPercentage;
}


function ProfitMargin_OnBlur(objVal, QtyNo, ProfitType, EstimateItemID, SectNo) {
    debugger;
    var hdn_CostExMarkup = document.getElementById("hdn_CostExMarkup" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_CostInMarkup = document.getElementById("hdn_CostInMarkup" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_ProfitMarginPercentage = document.getElementById("hdn_ProfitMarginPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_ProfitMarginPrice = document.getElementById("hdn_ProfitMarginPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_SubTotal = document.getElementById("hdn_SubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_SubTotalppu = document.getElementById("hdn_SubTotal_PricePerUnit" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + SectNo + "");
    var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + SectNo + ""); //since only one tax% exists for all qty
    var hdn_TaxPrice = document.getElementById("hdn_TaxPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_SellingPrice = document.getElementById("hdn_SellingPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_GrossProfitPercentage = document.getElementById("hdn_GrossProfitPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_GrossProfitPrice = document.getElementById("hdn_GrossProfitPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_IsSubTotalLocked = document.getElementById("hdn_IsSubTotalLocked_" + EstimateItemID + "_" + SectNo + "");
    var txtProfitMarginPercentage = document.getElementById("txtProfitMarginPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var txtProfitMarginPrice = document.getElementById("txtProfitMarginPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var txtSubTotal = document.getElementById("txtSubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var qty = document.getElementById("txtQtydesc" + QtyNo + "_" + EstimateItemID).value;
    var txtSubTotalppu = document.getElementById("txtSubTotal_PricePerUnit" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_" + SectNo + "");
    var spnTaxPrice = document.getElementById("spnTaxPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnSellingPrice = document.getElementById("spnSellingPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnGrossProfitPercentage = document.getElementById("spnGrossProfitPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnGrossProfitPrice = document.getElementById("spnGrossProfitPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");

    var strTax = ddlTax.value.split('~');
    hdn_TaxID.value = strTax[0];
    hdn_TaxPercentage.value = strTax[1]; //Binding as TaxID~TaxRate as value to the Tax ddl   

    var Profit = 0.00;
    if (ProfitType == "percent") {
        Profit = (Number(hdn_CostInMarkup.value) * Number(objVal)) / 100;
        txtProfitMarginPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Profit, 0, '', false, false, false);
    }
    else {
        Profit = objVal;
        var Temp_ProfitPercent = 0;
        if (Number(hdn_CostInMarkup.value) != 0) {
            Temp_ProfitPercent = (RemoveDollorAndComma(objVal) * 100) / Number(hdn_CostInMarkup.value);
        }
        txtProfitMarginPercentage.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Temp_ProfitPercent, 0, '', false, false, false);
        txtProfitMarginPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objVal, 0, '', false, false, false);
    }

    if (hdn_IsSubTotalLocked.value.toLowerCase() == "false") {
        txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Profit) + Number(hdn_CostInMarkup.value), 0, '', false, false, false);
        hdn_SubTotal.value = Number(Profit) + Number(hdn_CostInMarkup.value);

        var TaxValue = (Number(txtSubTotal.value) * Number(hdn_TaxPercentage.value)) / 100;
        spnTaxPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, false);

        //var SellingPrice = Number(TaxValue) + Number(txtSubTotal.value);
        var SellingPrice = Number(TaxValue) + Number(hdn_SubTotal.value);
        spnSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, false);

        //var subTotal = txtSubTotal.value;
        var subTotal = hdn_SubTotal.value;
        var GrossPercentage = 0;
        var GrossValue = GrossProfit_Value(Number(hdn_CostExMarkup.value), Number(subTotal));
        if (Number(txtSubTotal.value) != "0") {
            spnGrossProfitPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, false);

            GrossPercentage = GrossProfit_Percentage(Number(subTotal), Number(GrossValue));
            GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, false);
            spnGrossProfitPercentage.innerHTML = "" + GrossPercentage + "%";
        }

        //== Reassigning the values to hidden fields ===//
        hdn_ProfitMarginPercentage.value = txtProfitMarginPercentage.value;
        hdn_ProfitMarginPrice.value = txtProfitMarginPrice.value;
        //hdn_SubTotal.value = txtSubTotal.value;
        hdn_TaxPrice.value = TaxValue;
        hdn_SellingPrice.value = SellingPrice;
        hdn_GrossProfitPercentage.value = GrossPercentage;
        hdn_GrossProfitPrice.value = GrossValue;

        txtSubTotalppu.value = parseNum(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(Profit) / Number(qty)) + (Number(hdn_CostInMarkup.value) / Number(qty)), 0, '', false, false, false));
        hdn_SubTotalppu.value = parseNum((Number(Profit) / Number(qty)) + (Number(hdn_CostInMarkup.value) / Number(qty)));

    }
    else {
        //== Reassigning the values to hidden fields ===//
        hdn_ProfitMarginPercentage.value = txtProfitMarginPercentage.value;
        hdn_ProfitMarginPrice.value = txtProfitMarginPrice.value;
    }


    var SellingPricePerSQM_ = document.getElementById("txtSellingPricePerSQM" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var sqmPerItem_ = Number(document.getElementById("spnSQM" + QtyNo + "_" + EstimateItemID).textContent);
    var quantity_ = Number(document.getElementById("spnQuantity" + QtyNo + "_" + EstimateItemID).textContent);
    

    //var jb_height = Number(document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcItemTotal_" + EstimateItemID + "_hdn_JobHeight").value);
    //var jb_width = Number(document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcItemTotal_" + EstimateItemID + "_hdn_JobWidth").value);
    //var sqmPerItem_ = ((jb_height / new decimal(1000)) * (jb_width / new decimal(1000)));

    //var new_value_sqm = (Number(hdn_CostInMarkup.value) * (Number(1 + Number(txtProfitMarginPercentage.value)))) / Number(quantity_ * sqmPerItem_);
    var new_value_sqm = parseNum((Number(hdn_CostInMarkup.value) + Number(txtProfitMarginPrice.value)) / Number(quantity_) / sqmPerItem_);
    SellingPricePerSQM_.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, new_value_sqm, 0, '', false, false, false);
}

function SQM_OnBlur(objVal, QtyNo, ProfitType, EstimateItemID, SectNo) {
    debugger;
    var quantity = Number(document.getElementById("spnQuantity" + QtyNo + "_" + EstimateItemID).textContent);
    var sqmPerItem = Number(document.getElementById("spnSQM" + QtyNo + "_" + EstimateItemID).textContent);
    var SellingPricePerSQM = Number(document.getElementById("txtSellingPricePerSQM" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "").value);
    var txtSubTotal = document.getElementById("txtSubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPricePerSQM * sqmPerItem * quantity, 0, '', false, false, false);
    SubTotal_OnBlur(txtSubTotal.value, QtyNo, EstimateItemID, SectNo,'');
}
function SQM_OnBlurP(objVal, QtyNo, ProfitType, EstimateItemID, SectNo) {
    debugger;
    var quantity = Number(document.getElementById("spnQuantity" + QtyNo ).textContent);
    var sqmPerItem = Number(document.getElementById("spnSQM" + QtyNo ).textContent);
    var SellingPricePerSQM = Number(document.getElementById("txtSellingPricePerSQM" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "").value);
    var txtSubTotal = document.getElementById("txtSubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    txtSubTotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPricePerSQM * sqmPerItem * quantity, 0, '', false, false, false);
    SubTotal_OnBlur(txtSubTotal.value, QtyNo, EstimateItemID, SectNo);
}

function SubTotal_OnBlur(objVal, QtyNo, EstimateItemID, SectNo,EstType) {
    debugger;
    var hdn_SectionID = document.getElementById("hdn_SectionID_" + EstimateItemID + "_" + SectNo + "");
    var hdn_CostExMarkup = document.getElementById("hdn_CostExMarkup" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_SubTotal = document.getElementById("hdn_SubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + SectNo + "");
    var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + SectNo + ""); //since only one tax% exists for all qty
    var hdn_TaxPrice = document.getElementById("hdn_TaxPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_SellingPrice = document.getElementById("hdn_SellingPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_GrossProfitPercentage = document.getElementById("hdn_GrossProfitPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_GrossProfitPrice = document.getElementById("hdn_GrossProfitPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");

    var txtSubTotal = document.getElementById("txtSubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_" + SectNo + "");
    var spnTaxPrice = document.getElementById("spnTaxPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnSellingPrice = document.getElementById("spnSellingPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnGrossProfitPercentage = document.getElementById("spnGrossProfitPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnGrossProfitPrice = document.getElementById("spnGrossProfitPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");

    var pageUrl = window.location.href;
    if (pageUrl.includes("estimates/estimate_summary_reeng.aspx")) {
        if (EstType == "L" || EstType == "C" || EstType == "Q") {
            var hdnPricePerUnit = document.getElementById("hdn_SubTotal_PricePerUnit" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
            var txtpricePerUnit = document.getElementById("txtSubTotal_PricePerUnit" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
            var spnQuantity = "";
            if (EstType == "Q" || EstType == "C") {
                spnQuantity = Number(document.getElementById("hdn_spnQuantity" + QtyNo + "_" + EstimateItemID + "").innerText);
            }
            else {
                spnQuantity = Number(document.getElementById("spnQuantity" + QtyNo + "_" + EstimateItemID + "").innerText);
            }
            var pricePerUnitValue = Number(txtSubTotal.value / spnQuantity);
            hdnPricePerUnit.value = pricePerUnitValue;
            txtpricePerUnit.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, pricePerUnitValue, 0, '', false, false, false);
        }
    }

    if (pageUrl.toLowerCase().includes("jobs/job_summary_reeng.aspx") || pageUrl.toLowerCase().includes("invoice/invoice_summary_reeng.aspx")) {
        if (EstType == "L" || EstType == "C" || EstType == "Q") {
            var hdnPricePerUnit = document.getElementById("hdn_SubTotal_PricePerUnit" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
            var txtpricePerUnit = document.getElementById("txtSubTotal_PricePerUnit" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
            var spnQuantity = "";
            if (EstType == "Q" || EstType == "C") {
                spnQuantity = Number(document.getElementById("hdn_spnQuantity" + QtyNo + "_" + EstimateItemID + "").innerText);
            }
            else {
                spnQuantity = Number(document.getElementById("spnQuantity" + QtyNo + "_" + EstimateItemID + "").innerText);
            }
            var pricePerUnitValue = Number(txtSubTotal.value / spnQuantity);
            hdnPricePerUnit.value = pricePerUnitValue;
            txtpricePerUnit.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, pricePerUnitValue, 0, '', false, false, false);
        }
       
    }

    var strTax = ddlTax.value.split('~');
    hdn_TaxID.value = strTax[0];
    hdn_TaxPercentage.value = strTax[1]; //Binding as TaxID~TaxRate as value to the Tax ddl

    var TaxValue = (Number(txtSubTotal.value) * Number(hdn_TaxPercentage.value)) / 100;
    spnTaxPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, false);

    var SellingPrice = Number(TaxValue) + Number(txtSubTotal.value);
    spnSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, false);

    var subTotal = txtSubTotal.value;
    var GrossPercentage = 0;
    var GrossValue = GrossProfit_Value(Number(hdn_CostExMarkup.value), Number(subTotal));
    if (Number(txtSubTotal.value) != "0") {
        spnGrossProfitPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, false);

        GrossPercentage = GrossProfit_Percentage(Number(subTotal), Number(GrossValue));
        GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, false);
        spnGrossProfitPercentage.innerHTML = "" + GrossPercentage + "%";
    }

    //== Reassigning the values to hidden fields ===//
    hdn_SubTotal.value = objVal;
    hdn_TaxPrice.value = TaxValue;
    hdn_SellingPrice.value = SellingPrice;
    hdn_GrossProfitPercentage.value = GrossPercentage;
    hdn_GrossProfitPrice.value = GrossValue;
}

function SubTotal_PricePerUnit_OnBlur(objVal, QtyNo, EstimateItemID, SectNo,EstType) {
    debugger;
    var hdn_SubTotal = document.getElementById("hdn_SubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var txtSubTotal = document.getElementById("txtSubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnQuantity = "";
    if (EstType == "Q" || EstType == "C") {
        spnQuantity = Number(document.getElementById("hdn_spnQuantity" + QtyNo + "_" + EstimateItemID + "").innerText);
    }
    else {
        spnQuantity = Number(document.getElementById("spnQuantity" + QtyNo + "_" + EstimateItemID + "").innerText);
    }
    var hdnPricePerUnit = document.getElementById("hdn_SubTotal_PricePerUnit" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");

    //var pricePerUnit = document.getElementById("hdn_SubTotal_PricePerUnit" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "").value;
    var subTotal = Number(spnQuantity * objVal);
    txtSubTotal.value = subTotal;
    hdnPricePerUnit.value = objVal;

    var hdn_SectionID = document.getElementById("hdn_SectionID_" + EstimateItemID + "_" + SectNo + "");
    var hdn_CostExMarkup = document.getElementById("hdn_CostExMarkup" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + SectNo + "");
    var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + SectNo + ""); //since only one tax% exists for all qty
    var hdn_TaxPrice = document.getElementById("hdn_TaxPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_SellingPrice = document.getElementById("hdn_SellingPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_GrossProfitPercentage = document.getElementById("hdn_GrossProfitPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var hdn_GrossProfitPrice = document.getElementById("hdn_GrossProfitPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");

    var txtSubTotal = document.getElementById("txtSubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_" + SectNo + "");
    var spnTaxPrice = document.getElementById("spnTaxPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnSellingPrice = document.getElementById("spnSellingPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnGrossProfitPercentage = document.getElementById("spnGrossProfitPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
    var spnGrossProfitPrice = document.getElementById("spnGrossProfitPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");

    var strTax = ddlTax.value.split('~');
    hdn_TaxID.value = strTax[0];
    hdn_TaxPercentage.value = strTax[1]; //Binding as TaxID~TaxRate as value to the Tax ddl

    var TaxValue = (Number(txtSubTotal.value) * Number(hdn_TaxPercentage.value)) / 100;
    spnTaxPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, false);

    var SellingPrice = Number(TaxValue) + Number(txtSubTotal.value);
    spnSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, false);

    var subTotal = txtSubTotal.value;
    var GrossPercentage = 0;
    var GrossValue = GrossProfit_Value(Number(hdn_CostExMarkup.value), Number(subTotal));
    if (Number(txtSubTotal.value) != "0") {
        spnGrossProfitPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, false);

        GrossPercentage = GrossProfit_Percentage(Number(subTotal), Number(GrossValue));
        GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, false);
        spnGrossProfitPercentage.innerHTML = "" + GrossPercentage + "%";
    }

    //== Reassigning the values to hidden fields ===//
    hdn_SubTotal.value = txtSubTotal.value;;
    hdn_TaxPrice.value = TaxValue;
    hdn_SellingPrice.value = SellingPrice;
    hdn_GrossProfitPercentage.value = GrossPercentage;
    hdn_GrossProfitPrice.value = GrossValue;

}
function Tax_OnChange(objVal, QtyCount, EstimateItemID, SectNo) {
    debugger;
    for (var k = 0; k < 30; k++) {
        SectNo = k;
        var ddlTax = document.getElementById("ddlTax_" + EstimateItemID + "_" + SectNo + "");
        if (ddlTax != null && ddlTax != undefined) {

            var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + SectNo + "");
            var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + SectNo + ""); //since only one tax% exists for all qty
            // ddlTax.options[ddlTax.selectedIndex].value = objVal;
            var strTax = objVal.split('~');
            hdn_TaxID.value = strTax[0];
            hdn_TaxPercentage.value = strTax[1]; //Binding as TaxID~TaxRate as value to the Tax ddl   
            for (var h = 0; h < ddlTax.length; h++) {
                var splValue = ddlTax[h].value.split('~');
                if (strTax[0] == splValue[0]) {
                    ddlTax.selectedIndex = h;
                }
            }
            for (var i = 0; i < QtyCount; i++) {
                var QtyNo = (i + 1);
                var hdn_CostExMarkup = document.getElementById("hdn_CostExMarkup" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
                var hdn_SubTotal = document.getElementById("hdn_SubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
                var hdn_TaxPrice = document.getElementById("hdn_TaxPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
                var hdn_SellingPrice = document.getElementById("hdn_SellingPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
                var hdn_GrossProfitPercentage = document.getElementById("hdn_GrossProfitPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
                var hdn_GrossProfitPrice = document.getElementById("hdn_GrossProfitPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");

                var txtSubTotal = document.getElementById("txtSubTotal" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
                var spnTaxPrice = document.getElementById("spnTaxPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
                var spnSellingPrice = document.getElementById("spnSellingPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
                var spnGrossProfitPercentage = document.getElementById("spnGrossProfitPercentage" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");
                var spnGrossProfitPrice = document.getElementById("spnGrossProfitPrice" + QtyNo + "_" + EstimateItemID + "_" + SectNo + "");

                var TaxValue = (Number(txtSubTotal.value) * Number(hdn_TaxPercentage.value)) / 100;
                spnTaxPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TaxValue, 0, '', false, false, false);

                var SellingPrice = Number(TaxValue) + Number(txtSubTotal.value);
                spnSellingPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, false);

                var subTotal = txtSubTotal.value;
                var GrossPercentage = 0;
                var GrossValue = GrossProfit_Value(Number(hdn_CostExMarkup.value), Number(subTotal));
                if (Number(txtSubTotal.value) != "0") {
                    spnGrossProfitPrice.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue, 0, '', false, false, false);

                    GrossPercentage = GrossProfit_Percentage(Number(subTotal), Number(GrossValue));
                    GrossPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage, 0, '', false, false, false);
                    spnGrossProfitPercentage.innerHTML = "(" + GrossPercentage + "%)";
                }

                //== Reassigning the values to hidden fields ===//
                hdn_SubTotal.value = subTotal;
                hdn_TaxPrice.value = TaxValue;
                hdn_SellingPrice.value = SellingPrice;
                hdn_GrossProfitPercentage.value = GrossPercentage;
                hdn_GrossProfitPrice.value = GrossValue;
            }
        }
    }



}

var btnTypeOFSave = '';
var EstimateItemIDOFSave = '';
var EstTypeToSave = '';
var EstimateSaveID = '';
function CallSave(EstimateID, EstimateItemID, EstimateType, QtyCnt, SectionCnt, btnType) {
    debugger;
    var hdnDescButton = document.getElementById("hdnDescButton_" + EstimateItemID + "").value;

    var Array1 = hdnDescButton.split('▬');

    if (Array1.length > 0) {
        UpdateItemDescription(Array1[0], Array1[1], Array1[2], Array1[3], Array1[4], Array1[5], Array1[6], Array1[7]);
    }

    // var hdnSaveValues = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcItemTotal_' + EstimateItemID + '_hdnSaveValues');
    var hdnSaveValues = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnMainSaveValues_" + EstimateItemID);
    hdnSaveValues.value = '';

    EstimateItemIDOFSave = EstimateItemID;
    var hdn_EstimateID = document.getElementById("hdn_EstimateID_" + EstimateItemID + "");
    SectionCnt = Number(SectionCnt);
    SectionCnt = SectionCnt == 0 ? 1 : SectionCnt;
    if (EstimateType == "B" || EstimateType == "K" || EstimateType == "N" || EstimateType == "R") {
        SectionCnt = SectionCnt + 1; //to save all total price details              
    }
    for (var i = 0; i < SectionCnt; i++) {

        var SectNo = i;
        var hdn_SectionID = document.getElementById("hdn_SectionID_" + EstimateItemID + "_" + SectNo + "");

        var hdn_IsSubTotalLocked = document.getElementById("hdn_IsSubTotalLocked_" + EstimateItemID + "_" + SectNo + "");


        var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + SectNo + "");
        var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + SectNo + ""); //since only one tax% exists for all qty

        var hdn_ProfitMarginPercentage1 = document.getElementById("hdn_ProfitMarginPercentage1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPercentage2 = document.getElementById("hdn_ProfitMarginPercentage2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPercentage3 = document.getElementById("hdn_ProfitMarginPercentage3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPercentage4 = document.getElementById("hdn_ProfitMarginPercentage4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_ProfitMarginPrice1 = document.getElementById("hdn_ProfitMarginPrice1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPrice2 = document.getElementById("hdn_ProfitMarginPrice2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPrice3 = document.getElementById("hdn_ProfitMarginPrice3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPrice4 = document.getElementById("hdn_ProfitMarginPrice4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_SubTotal1 = document.getElementById("hdn_SubTotal1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SubTotal2 = document.getElementById("hdn_SubTotal2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SubTotal3 = document.getElementById("hdn_SubTotal3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SubTotal4 = document.getElementById("hdn_SubTotal4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_TaxPrice1 = document.getElementById("hdn_TaxPrice1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_TaxPrice2 = document.getElementById("hdn_TaxPrice2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_TaxPrice3 = document.getElementById("hdn_TaxPrice3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_TaxPrice4 = document.getElementById("hdn_TaxPrice4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_SellingPrice1 = document.getElementById("hdn_SellingPrice1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice2 = document.getElementById("hdn_SellingPrice2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice3 = document.getElementById("hdn_SellingPrice3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice4 = document.getElementById("hdn_SellingPrice4_" + EstimateItemID + "_" + SectNo + "");

        var hdnPricePerUnit1 = document.getElementById("hdn_SubTotal_PricePerUnit1_" + EstimateItemID + "_" + SectNo + "");
        var hdnPricePerUnit2 = document.getElementById("hdn_SubTotal_PricePerUnit2_" + EstimateItemID + "_" + SectNo + "");
        var hdnPricePerUnit3 = document.getElementById("hdn_SubTotal_PricePerUnit3_" + EstimateItemID + "_" + SectNo + "");
        var hdnPricePerUnit4 = document.getElementById("hdn_SubTotal_PricePerUnit4_" + EstimateItemID + "_" + SectNo + "");


        var hdn_GrossProfitPercentage1 = document.getElementById("hdn_GrossProfitPercentage1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPercentage2 = document.getElementById("hdn_GrossProfitPercentage2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPercentage3 = document.getElementById("hdn_GrossProfitPercentage3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPercentage4 = document.getElementById("hdn_GrossProfitPercentage4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_GrossProfitPrice1 = document.getElementById("hdn_GrossProfitPrice1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPrice2 = document.getElementById("hdn_GrossProfitPrice2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPrice3 = document.getElementById("hdn_GrossProfitPrice3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPrice4 = document.getElementById("hdn_GrossProfitPrice4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_SellingPrice_PerSQM1 = document.getElementById("txtSellingPricePerSQM1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice_PerSQM2 = document.getElementById("txtSellingPricePerSQM2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice_PerSQM3 = document.getElementById("txtSellingPricePerSQM3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice_PerSQM4 = document.getElementById("txtSellingPricePerSQM4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_CostExMarkup1 = document.getElementById("hdn_CostExMarkup1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_CostExMarkup2 = document.getElementById("hdn_CostExMarkup2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_CostExMarkup3 = document.getElementById("hdn_CostExMarkup3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_CostExMarkup4 = document.getElementById("hdn_CostExMarkup4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_CostInMarkup1 = document.getElementById("hdn_CostInMarkup1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_CostInMarkup2 = document.getElementById("hdn_CostInMarkup2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_CostInMarkup3 = document.getElementById("hdn_CostInMarkup3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_CostInMarkup4 = document.getElementById("hdn_CostInMarkup4_" + EstimateItemID + "_" + SectNo + "");


        var SectionID = Number(hdn_SectionID.value);
        var TotalProfitMarginPercentage1 = Number(hdn_ProfitMarginPercentage1.value);
        var TotalProfitMarginPercentage2 = Number(hdn_ProfitMarginPercentage2.value);
        var TotalProfitMarginPercentage3 = Number(hdn_ProfitMarginPercentage3.value);
        var TotalProfitMarginPercentage4 = Number(hdn_ProfitMarginPercentage4.value);

        var TotalProfitMarginPrice1 = Number(hdn_ProfitMarginPrice1.value);
        var TotalProfitMarginPrice2 = Number(hdn_ProfitMarginPrice2.value);
        var TotalProfitMarginPrice3 = Number(hdn_ProfitMarginPrice3.value);
        var TotalProfitMarginPrice4 = Number(hdn_ProfitMarginPrice4.value);

        var TotalSubTotal1 = Number(hdn_SubTotal1.value);
        var TotalSubTotal2 = Number(hdn_SubTotal2.value);
        var TotalSubTotal3 = Number(hdn_SubTotal3.value);
        var TotalSubTotal4 = Number(hdn_SubTotal4.value);

        var TotalSubTotal1 = Number(hdn_SubTotal1.value);
        var TotalSubTotal2 = Number(hdn_SubTotal2.value);
        var TotalSubTotal3 = Number(hdn_SubTotal3.value);
        var TotalSubTotal4 = Number(hdn_SubTotal4.value);

        var TotalTaxID1 = Number(hdn_TaxID.value);
        var TotalTaxID2 = Number(hdn_TaxID.value);
        var TotalTaxID3 = Number(hdn_TaxID.value);
        var TotalTaxID4 = Number(hdn_TaxID.value);

        var TotalTaxPercentage1 = Number(hdn_TaxPercentage.value);
        var TotalTaxPercentage2 = Number(hdn_TaxPercentage.value);
        var TotalTaxPercentage3 = Number(hdn_TaxPercentage.value);
        var TotalTaxPercentage4 = Number(hdn_TaxPercentage.value);


        var TotalTaxPrice1 = Number(hdn_TaxPrice1.value);
        var TotalTaxPrice2 = Number(hdn_TaxPrice2.value);
        var TotalTaxPrice3 = Number(hdn_TaxPrice3.value);
        var TotalTaxPrice4 = Number(hdn_TaxPrice4.value);

        var TotalSellingPrice1 = Number(hdn_SellingPrice1.value);
        var TotalSellingPrice2 = Number(hdn_SellingPrice2.value);
        var TotalSellingPrice3 = Number(hdn_SellingPrice3.value);
        var TotalSellingPrice4 = Number(hdn_SellingPrice4.value);

        var TotalGrossProfitPercentage1 = Number(hdn_GrossProfitPercentage1.value);
        var TotalGrossProfitPercentage2 = Number(hdn_GrossProfitPercentage2.value);
        var TotalGrossProfitPercentage3 = Number(hdn_GrossProfitPercentage3.value);
        var TotalGrossProfitPercentage4 = Number(hdn_GrossProfitPercentage4.value);

        var TotalGrossProfitPrice1 = Number(hdn_GrossProfitPrice1.value);
        var TotalGrossProfitPrice2 = Number(hdn_GrossProfitPrice2.value);
        var TotalGrossProfitPrice3 = Number(hdn_GrossProfitPrice3.value);
        var TotalGrossProfitPrice4 = Number(hdn_GrossProfitPrice4.value);


        var TotalCostExMarkup1 = Number(hdn_CostExMarkup1.value);
        var TotalCostExMarkup2 = Number(hdn_CostExMarkup2.value);
        var TotalCostExMarkup3 = Number(hdn_CostExMarkup3.value);
        var TotalCostExMarkup4 = Number(hdn_CostExMarkup4.value);

        var TotalCostInMarkup1 = Number(hdn_CostInMarkup1.value);
        var TotalCostInMarkup2 = Number(hdn_CostInMarkup2.value);
        var TotalCostInMarkup3 = Number(hdn_CostInMarkup3.value);
        var TotalCostInMarkup4 = Number(hdn_CostInMarkup4.value);


        if (hdn_SellingPrice_PerSQM1 == null) {
            var SellingPricePerSQM1 = 0;
        } else {
            var SellingPricePerSQM1 = Number(hdn_SellingPrice_PerSQM1.value);
        }
        
        if (hdn_SellingPrice_PerSQM2 == null) {
            var SellingPricePerSQM2 = 0;
        } else {
            var SellingPricePerSQM2 = Number(hdn_SellingPrice_PerSQM2.value);
        }
        
        if (hdn_SellingPrice_PerSQM3 == null) {
            var SellingPricePerSQM3 = 0;
        } else {
            var SellingPricePerSQM3 = Number(hdn_SellingPrice_PerSQM3.value);
        }
        
        if (hdn_SellingPrice_PerSQM4 == null) {
            var SellingPricePerSQM4 = 0;
        } else {
            var SellingPricePerSQM4 = Number(hdn_SellingPrice_PerSQM4.value);
        }



        if (hdnPricePerUnit1 == null) {
            var SubTotalPricePerUnit1 = 0;
        } else {
            var SubTotalPricePerUnit1 = Number(hdnPricePerUnit1.value);
        }

        if (hdnPricePerUnit2 == null) {
            var SubTotalPricePerUnit2 = 0;
        } else {
            var SubTotalPricePerUnit2 = parseNum(Number(hdnPricePerUnit2.value));
        }

        if (hdnPricePerUnit3 == null) {
            var SubTotalPricePerUnit3 = 0;
        } else {
            var SubTotalPricePerUnit3 = parseNum(Number(hdnPricePerUnit3.value));
        }

        if (hdnPricePerUnit4 == null) {
            var SubTotalPricePerUnit4 = 0;
        } else {
            var SubTotalPricePerUnit4 = parseNum(Number(hdnPricePerUnit4.value));
        }
        

        var IsSubTotalLocked = hdn_IsSubTotalLocked.value;

        //        item_summary.SaveItemPriceDetails(EstimateID, EstimateItemID, SectionID, EstimateType,
        //            TotalProfitMarginPercentage1, TotalProfitMarginPercentage2, TotalProfitMarginPercentage3, TotalProfitMarginPercentage4,
        //            TotalProfitMarginPrice1, TotalProfitMarginPrice2, TotalProfitMarginPrice3, TotalProfitMarginPrice4,
        //            TotalSubTotal1, TotalSubTotal2, TotalSubTotal3, TotalSubTotal4,
        //            TotalTaxID1, TotalTaxID2, TotalTaxID3, TotalTaxID4,
        //            TotalTaxPercentage1, TotalTaxPercentage2, TotalTaxPercentage3, TotalTaxPercentage4,
        //            TotalTaxPrice1, TotalTaxPrice2, TotalTaxPrice3, TotalTaxPrice4,
        //            TotalSellingPrice1, TotalSellingPrice2, TotalSellingPrice3, TotalSellingPrice4,
        //            TotalGrossProfitPercentage1, TotalGrossProfitPercentage2, TotalGrossProfitPercentage3, TotalGrossProfitPercentage4,
        //            TotalGrossProfitPrice1, TotalGrossProfitPrice2, TotalGrossProfitPrice3, TotalGrossProfitPrice4,
        //            IsSubTotalLocked, NoResponseForSave);



        debugger;
        hdnSaveValues.value += EstimateID + '~' + EstimateItemID + '~' + SectionID + '~' + EstimateType + '~' +
            TotalProfitMarginPercentage1 + '~' + TotalProfitMarginPercentage2 + '~' + TotalProfitMarginPercentage3 + '~' + TotalProfitMarginPercentage4 + '~' +
            TotalProfitMarginPrice1 + '~' + TotalProfitMarginPrice2 + '~' + TotalProfitMarginPrice3 + '~' + TotalProfitMarginPrice4 + '~' +
            TotalSubTotal1 + '~' + TotalSubTotal2 + '~' + TotalSubTotal3 + '~' + TotalSubTotal4 + '~' +
            TotalTaxID1 + '~' + TotalTaxID2 + '~' + TotalTaxID3 + '~' + TotalTaxID4 + '~' +
            TotalTaxPercentage1 + '~' + TotalTaxPercentage2 + '~' + TotalTaxPercentage3 + '~' + TotalTaxPercentage4 + '~' +
            TotalTaxPrice1 + '~' + TotalTaxPrice2 + '~' + TotalTaxPrice3 + '~' + TotalTaxPrice4 + '~' +
            TotalSellingPrice1 + '~' + TotalSellingPrice2 + '~' + TotalSellingPrice3 + '~' + TotalSellingPrice4 + '~' +
            TotalGrossProfitPercentage1 + '~' + TotalGrossProfitPercentage2 + '~' + TotalGrossProfitPercentage3 + '~' + TotalGrossProfitPercentage4 + '~' +
            TotalGrossProfitPrice1 + '~' + TotalGrossProfitPrice2 + '~' + TotalGrossProfitPrice3 + '~' + TotalGrossProfitPrice4 + '~' +
            IsSubTotalLocked + '~' + SellingPricePerSQM1 + '~' + SellingPricePerSQM2 + '~' + SellingPricePerSQM3 + '~' + SellingPricePerSQM4 + '~' +
            parseNum(SubTotalPricePerUnit1) + '~' + parseNum(SubTotalPricePerUnit2) + '~' + parseNum(SubTotalPricePerUnit3) + '~' +
            parseNum(SubTotalPricePerUnit4) + '|';



    }

    //var hdnMainSaveValues = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnMainSaveValues_" + EstimateItemID);

    // hdnMainSaveValues.value = hdnSaveValues.value;

    var tblMessage = document.getElementById("tblMessage_" + EstimateItemID + "");
    var lblMessage = document.getElementById("lblMessage_" + EstimateItemID + "");


    btnTypeOFSave = btnType;
    EstimateItemIDOFSave = EstimateItemID;
    EstTypeToSave = EstimateType;
    EstimateSaveID = EstimateID;
    return true;
}
function parseNum(val) {
    val = +val || 0
    return val;
}

function CallProofSave(EstimateID, EstimateItemID, EstimateType, QtyCnt, SectionCnt, btnType,ProofItemID) {
    debugger;
    var hdnDescButton = document.getElementById("hdnDescButton_" + ProofItemID + "").value;

    var Array1 = hdnDescButton.split('▬');

    if (Array1.length > 0) {
        UpdateProofItemDescription(Array1[0], Array1[1], Array1[2], Array1[3], Array1[4], Array1[5], Array1[6], Array1[7], ProofItemID);
    }

    // var hdnSaveValues = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcItemTotal_' + EstimateItemID + '_hdnSaveValues');
    var hdnSaveValues = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_hdnMainSaveValues_" + EstimateItemID + "_" + ProofItemID);
    hdnSaveValues.value = '';

    EstimateItemIDOFSave = EstimateItemID;
    //var hdn_EstimateID = document.getElementById("hdn_EstimateID_" + EstimateItemID + "");
    //SectionCnt = Number(SectionCnt);
    //SectionCnt = SectionCnt == 0 ? 1 : SectionCnt;
    //if (EstimateType == "B" || EstimateType == "K" || EstimateType == "N") {
    //    SectionCnt = SectionCnt + 1; //to save all total price details              
    //}
    //for (var i = 0; i < SectionCnt; i++) {

    //    var SectNo = i;
    //    var hdn_SectionID = document.getElementById("hdn_SectionID_" + EstimateItemID + "_" + SectNo + "");

    //    var hdn_IsSubTotalLocked = document.getElementById("hdn_IsSubTotalLocked_" + EstimateItemID + "_" + SectNo + "");


    //    var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + SectNo + ""); //since only one tax% exists for all qty

    //    var hdn_ProfitMarginPercentage1 = document.getElementById("hdn_ProfitMarginPercentage1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_ProfitMarginPercentage2 = document.getElementById("hdn_ProfitMarginPercentage2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_ProfitMarginPercentage3 = document.getElementById("hdn_ProfitMarginPercentage3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_ProfitMarginPercentage4 = document.getElementById("hdn_ProfitMarginPercentage4_" + EstimateItemID + "_" + SectNo + "");

    //    var hdn_ProfitMarginPrice1 = document.getElementById("hdn_ProfitMarginPrice1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_ProfitMarginPrice2 = document.getElementById("hdn_ProfitMarginPrice2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_ProfitMarginPrice3 = document.getElementById("hdn_ProfitMarginPrice3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_ProfitMarginPrice4 = document.getElementById("hdn_ProfitMarginPrice4_" + EstimateItemID + "_" + SectNo + "");

    //    var hdn_SubTotal1 = document.getElementById("hdn_SubTotal1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_SubTotal2 = document.getElementById("hdn_SubTotal2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_SubTotal3 = document.getElementById("hdn_SubTotal3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_SubTotal4 = document.getElementById("hdn_SubTotal4_" + EstimateItemID + "_" + SectNo + "");

    //    var hdn_TaxPrice1 = document.getElementById("hdn_TaxPrice1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_TaxPrice2 = document.getElementById("hdn_TaxPrice2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_TaxPrice3 = document.getElementById("hdn_TaxPrice3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_TaxPrice4 = document.getElementById("hdn_TaxPrice4_" + EstimateItemID + "_" + SectNo + "");

    //    var hdn_SellingPrice1 = document.getElementById("hdn_SellingPrice1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_SellingPrice2 = document.getElementById("hdn_SellingPrice2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_SellingPrice3 = document.getElementById("hdn_SellingPrice3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_SellingPrice4 = document.getElementById("hdn_SellingPrice4_" + EstimateItemID + "_" + SectNo + "");

    //    var hdnPricePerUnit1 = document.getElementById("hdn_SubTotal_PricePerUnit1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdnPricePerUnit2 = document.getElementById("hdn_SubTotal_PricePerUnit2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdnPricePerUnit3 = document.getElementById("hdn_SubTotal_PricePerUnit3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdnPricePerUnit4 = document.getElementById("hdn_SubTotal_PricePerUnit4_" + EstimateItemID + "_" + SectNo + "");


    //    var hdn_GrossProfitPercentage1 = document.getElementById("hdn_GrossProfitPercentage1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_GrossProfitPercentage2 = document.getElementById("hdn_GrossProfitPercentage2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_GrossProfitPercentage3 = document.getElementById("hdn_GrossProfitPercentage3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_GrossProfitPercentage4 = document.getElementById("hdn_GrossProfitPercentage4_" + EstimateItemID + "_" + SectNo + "");

    //    var hdn_GrossProfitPrice1 = document.getElementById("hdn_GrossProfitPrice1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_GrossProfitPrice2 = document.getElementById("hdn_GrossProfitPrice2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_GrossProfitPrice3 = document.getElementById("hdn_GrossProfitPrice3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_GrossProfitPrice4 = document.getElementById("hdn_GrossProfitPrice4_" + EstimateItemID + "_" + SectNo + "");

    //    var hdn_SellingPrice_PerSQM1 = document.getElementById("txtSellingPricePerSQM1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_SellingPrice_PerSQM2 = document.getElementById("txtSellingPricePerSQM2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_SellingPrice_PerSQM3 = document.getElementById("txtSellingPricePerSQM3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_SellingPrice_PerSQM4 = document.getElementById("txtSellingPricePerSQM4_" + EstimateItemID + "_" + SectNo + "");

    //    var hdn_CostExMarkup1 = document.getElementById("hdn_CostExMarkup1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_CostExMarkup2 = document.getElementById("hdn_CostExMarkup2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_CostExMarkup3 = document.getElementById("hdn_CostExMarkup3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_CostExMarkup4 = document.getElementById("hdn_CostExMarkup4_" + EstimateItemID + "_" + SectNo + "");

    //    var hdn_CostInMarkup1 = document.getElementById("hdn_CostInMarkup1_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_CostInMarkup2 = document.getElementById("hdn_CostInMarkup2_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_CostInMarkup3 = document.getElementById("hdn_CostInMarkup3_" + EstimateItemID + "_" + SectNo + "");
    //    var hdn_CostInMarkup4 = document.getElementById("hdn_CostInMarkup4_" + EstimateItemID + "_" + SectNo + "");


    //    var SectionID = Number(hdn_SectionID.value);
    //    var TotalProfitMarginPercentage1 = Number(hdn_ProfitMarginPercentage1.value);
    //    var TotalProfitMarginPercentage2 = Number(hdn_ProfitMarginPercentage2.value);
    //    var TotalProfitMarginPercentage3 = Number(hdn_ProfitMarginPercentage3.value);
    //    var TotalProfitMarginPercentage4 = Number(hdn_ProfitMarginPercentage4.value);

    //    var TotalProfitMarginPrice1 = Number(hdn_ProfitMarginPrice1.value);
    //    var TotalProfitMarginPrice2 = Number(hdn_ProfitMarginPrice2.value);
    //    var TotalProfitMarginPrice3 = Number(hdn_ProfitMarginPrice3.value);
    //    var TotalProfitMarginPrice4 = Number(hdn_ProfitMarginPrice4.value);

    //    var TotalSubTotal1 = Number(hdn_SubTotal1.value);
    //    var TotalSubTotal2 = Number(hdn_SubTotal2.value);
    //    var TotalSubTotal3 = Number(hdn_SubTotal3.value);
    //    var TotalSubTotal4 = Number(hdn_SubTotal4.value);

    //    var TotalSubTotal1 = Number(hdn_SubTotal1.value);
    //    var TotalSubTotal2 = Number(hdn_SubTotal2.value);
    //    var TotalSubTotal3 = Number(hdn_SubTotal3.value);
    //    var TotalSubTotal4 = Number(hdn_SubTotal4.value);

    //    var TotalTaxID1 = Number(hdn_TaxID.value);
    //    var TotalTaxID2 = Number(hdn_TaxID.value);
    //    var TotalTaxID3 = Number(hdn_TaxID.value);
    //    var TotalTaxID4 = Number(hdn_TaxID.value);

    //    var TotalTaxPercentage1 = Number(hdn_TaxPercentage.value);
    //    var TotalTaxPercentage2 = Number(hdn_TaxPercentage.value);
    //    var TotalTaxPercentage3 = Number(hdn_TaxPercentage.value);
    //    var TotalTaxPercentage4 = Number(hdn_TaxPercentage.value);


    //    var TotalTaxPrice1 = Number(hdn_TaxPrice1.value);
    //    var TotalTaxPrice2 = Number(hdn_TaxPrice2.value);
    //    var TotalTaxPrice3 = Number(hdn_TaxPrice3.value);
    //    var TotalTaxPrice4 = Number(hdn_TaxPrice4.value);

    //    var TotalSellingPrice1 = Number(hdn_SellingPrice1.value);
    //    var TotalSellingPrice2 = Number(hdn_SellingPrice2.value);
    //    var TotalSellingPrice3 = Number(hdn_SellingPrice3.value);
    //    var TotalSellingPrice4 = Number(hdn_SellingPrice4.value);

    //    var TotalGrossProfitPercentage1 = Number(hdn_GrossProfitPercentage1.value);
    //    var TotalGrossProfitPercentage2 = Number(hdn_GrossProfitPercentage2.value);
    //    var TotalGrossProfitPercentage3 = Number(hdn_GrossProfitPercentage3.value);
    //    var TotalGrossProfitPercentage4 = Number(hdn_GrossProfitPercentage4.value);

    //    var TotalGrossProfitPrice1 = Number(hdn_GrossProfitPrice1.value);
    //    var TotalGrossProfitPrice2 = Number(hdn_GrossProfitPrice2.value);
    //    var TotalGrossProfitPrice3 = Number(hdn_GrossProfitPrice3.value);
    //    var TotalGrossProfitPrice4 = Number(hdn_GrossProfitPrice4.value);


    //    var TotalCostExMarkup1 = Number(hdn_CostExMarkup1.value);
    //    var TotalCostExMarkup2 = Number(hdn_CostExMarkup2.value);
    //    var TotalCostExMarkup3 = Number(hdn_CostExMarkup3.value);
    //    var TotalCostExMarkup4 = Number(hdn_CostExMarkup4.value);

    //    var TotalCostInMarkup1 = Number(hdn_CostInMarkup1.value);
    //    var TotalCostInMarkup2 = Number(hdn_CostInMarkup2.value);
    //    var TotalCostInMarkup3 = Number(hdn_CostInMarkup3.value);
    //    var TotalCostInMarkup4 = Number(hdn_CostInMarkup4.value);


    //    if (hdn_SellingPrice_PerSQM1 == null) {
    //        var SellingPricePerSQM1 = 0;
    //    } else {
    //        var SellingPricePerSQM1 = Number(hdn_SellingPrice_PerSQM1.value);
    //    }

    //    if (hdn_SellingPrice_PerSQM2 == null) {
    //        var SellingPricePerSQM2 = 0;
    //    } else {
    //        var SellingPricePerSQM2 = Number(hdn_SellingPrice_PerSQM2.value);
    //    }

    //    if (hdn_SellingPrice_PerSQM3 == null) {
    //        var SellingPricePerSQM3 = 0;
    //    } else {
    //        var SellingPricePerSQM3 = Number(hdn_SellingPrice_PerSQM3.value);
    //    }

    //    if (hdn_SellingPrice_PerSQM4 == null) {
    //        var SellingPricePerSQM4 = 0;
    //    } else {
    //        var SellingPricePerSQM4 = Number(hdn_SellingPrice_PerSQM4.value);
    //    }



    //    if (hdnPricePerUnit1 == null) {
    //        var SubTotalPricePerUnit1 = 0;
    //    } else {
    //        var SubTotalPricePerUnit1 = Number(hdnPricePerUnit1.value);
    //    }

    //    if (hdnPricePerUnit2 == null) {
    //        var SubTotalPricePerUnit2 = 0;
    //    } else {
    //        var SubTotalPricePerUnit2 = Number(hdnPricePerUnit2.value);
    //    }

    //    if (hdnPricePerUnit3 == null) {
    //        var SubTotalPricePerUnit3 = 0;
    //    } else {
    //        var SubTotalPricePerUnit3 = Number(hdnPricePerUnit3.value);
    //    }

    //    if (hdnPricePerUnit4 == null) {
    //        var SubTotalPricePerUnit4 = 0;
    //    } else {
    //        var SubTotalPricePerUnit4 = Number(hdnPricePerUnit4.value);
    //    }


    //    var IsSubTotalLocked = hdn_IsSubTotalLocked.value;

    //    //        item_summary.SaveItemPriceDetails(EstimateID, EstimateItemID, SectionID, EstimateType,
    //    //            TotalProfitMarginPercentage1, TotalProfitMarginPercentage2, TotalProfitMarginPercentage3, TotalProfitMarginPercentage4,
    //    //            TotalProfitMarginPrice1, TotalProfitMarginPrice2, TotalProfitMarginPrice3, TotalProfitMarginPrice4,
    //    //            TotalSubTotal1, TotalSubTotal2, TotalSubTotal3, TotalSubTotal4,
    //    //            TotalTaxID1, TotalTaxID2, TotalTaxID3, TotalTaxID4,
    //    //            TotalTaxPercentage1, TotalTaxPercentage2, TotalTaxPercentage3, TotalTaxPercentage4,
    //    //            TotalTaxPrice1, TotalTaxPrice2, TotalTaxPrice3, TotalTaxPrice4,
    //    //            TotalSellingPrice1, TotalSellingPrice2, TotalSellingPrice3, TotalSellingPrice4,
    //    //            TotalGrossProfitPercentage1, TotalGrossProfitPercentage2, TotalGrossProfitPercentage3, TotalGrossProfitPercentage4,
    //    //            TotalGrossProfitPrice1, TotalGrossProfitPrice2, TotalGrossProfitPrice3, TotalGrossProfitPrice4,
    //    //            IsSubTotalLocked, NoResponseForSave);




    //    hdnSaveValues.value += EstimateID + '~' + EstimateItemID + '~' + SectionID + '~' + EstimateType + '~' +
    //        TotalProfitMarginPercentage1 + '~' + TotalProfitMarginPercentage2 + '~' + TotalProfitMarginPercentage3 + '~' + TotalProfitMarginPercentage4 + '~' +
    //        TotalProfitMarginPrice1 + '~' + TotalProfitMarginPrice2 + '~' + TotalProfitMarginPrice3 + '~' + TotalProfitMarginPrice4 + '~' +
    //        TotalSubTotal1 + '~' + TotalSubTotal2 + '~' + TotalSubTotal3 + '~' + TotalSubTotal4 + '~' +
    //        TotalTaxID1 + '~' + TotalTaxID2 + '~' + TotalTaxID3 + '~' + TotalTaxID4 + '~' +
    //        TotalTaxPercentage1 + '~' + TotalTaxPercentage2 + '~' + TotalTaxPercentage3 + '~' + TotalTaxPercentage4 + '~' +
    //        TotalTaxPrice1 + '~' + TotalTaxPrice2 + '~' + TotalTaxPrice3 + '~' + TotalTaxPrice4 + '~' +
    //        TotalSellingPrice1 + '~' + TotalSellingPrice2 + '~' + TotalSellingPrice3 + '~' + TotalSellingPrice4 + '~' +
    //        TotalGrossProfitPercentage1 + '~' + TotalGrossProfitPercentage2 + '~' + TotalGrossProfitPercentage3 + '~' + TotalGrossProfitPercentage4 + '~' +
    //        TotalGrossProfitPrice1 + '~' + TotalGrossProfitPrice2 + '~' + TotalGrossProfitPrice3 + '~' + TotalGrossProfitPrice4 + '~' +
    //        IsSubTotalLocked + '~' + SellingPricePerSQM1 + '~' + SellingPricePerSQM2 + '~' + SellingPricePerSQM3 + '~' + SellingPricePerSQM4 + '~' +
    //        SubTotalPricePerUnit1 + '~' + SubTotalPricePerUnit2 + '~' + SubTotalPricePerUnit3 + '~' + SubTotalPricePerUnit4 + '|';



    //}

    //var hdnMainSaveValues = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnMainSaveValues_" + EstimateItemID);

    // hdnMainSaveValues.value = hdnSaveValues.value;

    //var tblMessage = document.getElementById("tblMessage_" + EstimateItemID + "");
    //var lblMessage = document.getElementById("lblMessage_" + EstimateItemID + "");


    btnTypeOFSave = btnType;
    EstimateItemIDOFSave = EstimateItemID;
    EstTypeToSave = EstimateType;
    EstimateSaveID = EstimateID;
    return true;
}

function CallSave_onLock(EstimateID, EstimateItemID, EstimateType, QtyCnt, SectionCnt, btnType) {
    var hdnSaveValues = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcItemTotal_' + EstimateItemID + '_hdnSaveValues');
    hdnSaveValues.value = '';

    EstimateItemIDOFSave = EstimateItemID;
    var hdn_EstimateID = document.getElementById("hdn_EstimateID_" + EstimateItemID + "");
    SectionCnt = Number(SectionCnt);
    SectionCnt = SectionCnt == 0 ? 1 : SectionCnt;
    if (EstimateType == "B" || EstimateType == "K" || EstimateType == "N" || EstimateType == "R") {
        SectionCnt = SectionCnt + 1; //to save all total price details              
    }

    for (var i = 0; i < SectionCnt; i++) {


        var SectNo = i;
        var hdn_SectionID = document.getElementById("hdn_SectionID_" + EstimateItemID + "_" + SectNo + "");

        var hdn_IsSubTotalLocked = document.getElementById("hdn_IsSubTotalLocked_" + EstimateItemID + "_" + SectNo + "");


        var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + SectNo + "");
        var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + SectNo + ""); //since only one tax% exists for all qty

        var hdn_ProfitMarginPercentage1 = document.getElementById("hdn_ProfitMarginPercentage1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPercentage2 = document.getElementById("hdn_ProfitMarginPercentage2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPercentage3 = document.getElementById("hdn_ProfitMarginPercentage3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPercentage4 = document.getElementById("hdn_ProfitMarginPercentage4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_ProfitMarginPrice1 = document.getElementById("hdn_ProfitMarginPrice1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPrice2 = document.getElementById("hdn_ProfitMarginPrice2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPrice3 = document.getElementById("hdn_ProfitMarginPrice3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_ProfitMarginPrice4 = document.getElementById("hdn_ProfitMarginPrice4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_SubTotal1 = document.getElementById("hdn_SubTotal1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SubTotal2 = document.getElementById("hdn_SubTotal2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SubTotal3 = document.getElementById("hdn_SubTotal3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SubTotal4 = document.getElementById("hdn_SubTotal4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_TaxPrice1 = document.getElementById("hdn_TaxPrice1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_TaxPrice2 = document.getElementById("hdn_TaxPrice2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_TaxPrice3 = document.getElementById("hdn_TaxPrice3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_TaxPrice4 = document.getElementById("hdn_TaxPrice4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_SellingPrice1 = document.getElementById("hdn_SellingPrice1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice2 = document.getElementById("hdn_SellingPrice2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice3 = document.getElementById("hdn_SellingPrice3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice4 = document.getElementById("hdn_SellingPrice4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_GrossProfitPercentage1 = document.getElementById("hdn_GrossProfitPercentage1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPercentage2 = document.getElementById("hdn_GrossProfitPercentage2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPercentage3 = document.getElementById("hdn_GrossProfitPercentage3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPercentage4 = document.getElementById("hdn_GrossProfitPercentage4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_GrossProfitPrice1 = document.getElementById("hdn_GrossProfitPrice1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPrice2 = document.getElementById("hdn_GrossProfitPrice2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPrice3 = document.getElementById("hdn_GrossProfitPrice3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_GrossProfitPrice4 = document.getElementById("hdn_GrossProfitPrice4_" + EstimateItemID + "_" + SectNo + "");

        var hdn_SellingPrice_PerSQM1 = document.getElementById("txtSellingPricePerSQM1_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice_PerSQM2 = document.getElementById("txtSellingPricePerSQM2_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice_PerSQM3 = document.getElementById("txtSellingPricePerSQM3_" + EstimateItemID + "_" + SectNo + "");
        var hdn_SellingPrice_PerSQM4 = document.getElementById("txtSellingPricePerSQM4_" + EstimateItemID + "_" + SectNo + "");

        var SectionID = Number(hdn_SectionID.value);
        var TotalProfitMarginPercentage1 = Number(hdn_ProfitMarginPercentage1.value);
        var TotalProfitMarginPercentage2 = Number(hdn_ProfitMarginPercentage2.value);
        var TotalProfitMarginPercentage3 = Number(hdn_ProfitMarginPercentage3.value);
        var TotalProfitMarginPercentage4 = Number(hdn_ProfitMarginPercentage4.value);

        var TotalProfitMarginPrice1 = Number(hdn_ProfitMarginPrice1.value);
        var TotalProfitMarginPrice2 = Number(hdn_ProfitMarginPrice2.value);
        var TotalProfitMarginPrice3 = Number(hdn_ProfitMarginPrice3.value);
        var TotalProfitMarginPrice4 = Number(hdn_ProfitMarginPrice4.value);

        var TotalSubTotal1 = Number(hdn_SubTotal1.value);
        var TotalSubTotal2 = Number(hdn_SubTotal2.value);
        var TotalSubTotal3 = Number(hdn_SubTotal3.value);
        var TotalSubTotal4 = Number(hdn_SubTotal4.value);

        var TotalSubTotal1 = Number(hdn_SubTotal1.value);
        var TotalSubTotal2 = Number(hdn_SubTotal2.value);
        var TotalSubTotal3 = Number(hdn_SubTotal3.value);
        var TotalSubTotal4 = Number(hdn_SubTotal4.value);

        var TotalTaxID1 = Number(hdn_TaxID.value);
        var TotalTaxID2 = Number(hdn_TaxID.value);
        var TotalTaxID3 = Number(hdn_TaxID.value);
        var TotalTaxID4 = Number(hdn_TaxID.value);

        var TotalTaxPercentage1 = Number(hdn_TaxPercentage.value);
        var TotalTaxPercentage2 = Number(hdn_TaxPercentage.value);
        var TotalTaxPercentage3 = Number(hdn_TaxPercentage.value);
        var TotalTaxPercentage4 = Number(hdn_TaxPercentage.value);


        var TotalTaxPrice1 = Number(hdn_TaxPrice1.value);
        var TotalTaxPrice2 = Number(hdn_TaxPrice2.value);
        var TotalTaxPrice3 = Number(hdn_TaxPrice3.value);
        var TotalTaxPrice4 = Number(hdn_TaxPrice4.value);

        var TotalSellingPrice1 = Number(hdn_SellingPrice1.value);
        var TotalSellingPrice2 = Number(hdn_SellingPrice2.value);
        var TotalSellingPrice3 = Number(hdn_SellingPrice3.value);
        var TotalSellingPrice4 = Number(hdn_SellingPrice4.value);

        var TotalGrossProfitPercentage1 = Number(hdn_GrossProfitPercentage1.value);
        var TotalGrossProfitPercentage2 = Number(hdn_GrossProfitPercentage2.value);
        var TotalGrossProfitPercentage3 = Number(hdn_GrossProfitPercentage3.value);
        var TotalGrossProfitPercentage4 = Number(hdn_GrossProfitPercentage4.value);

        var TotalGrossProfitPrice1 = Number(hdn_GrossProfitPrice1.value);
        var TotalGrossProfitPrice2 = Number(hdn_GrossProfitPrice2.value);
        var TotalGrossProfitPrice3 = Number(hdn_GrossProfitPrice3.value);
        var TotalGrossProfitPrice4 = Number(hdn_GrossProfitPrice4.value);

        if (hdn_SellingPrice_PerSQM1 == null)
            var SellingPricePerSQM1 = 0;
        else
            var SellingPricePerSQM1 = Number(hdn_SellingPrice_PerSQM1.value);
        //------
        if (hdn_SellingPrice_PerSQM2 == null)
            var SellingPricePerSQM2 = 0;
        else
            var SellingPricePerSQM2 = Number(hdn_SellingPrice_PerSQM2.value);
        //----
        if (hdn_SellingPrice_PerSQM3 == null)
            var SellingPricePerSQM3 = 0;
        else
            var SellingPricePerSQM3 = Number(hdn_SellingPrice_PerSQM3.value);
        //-------
        if (hdn_SellingPrice_PerSQM4 == null)
            var SellingPricePerSQM4 = 0;
        else
            var SellingPricePerSQM4 = Number(hdn_SellingPrice_PerSQM4.value);
        //-------
        var IsSubTotalLocked = hdn_IsSubTotalLocked.value;

        //        item_summary.SaveItemPriceDetails(EstimateID, EstimateItemID, SectionID, EstimateType,
        //            TotalProfitMarginPercentage1, TotalProfitMarginPercentage2, TotalProfitMarginPercentage3, TotalProfitMarginPercentage4,
        //            TotalProfitMarginPrice1, TotalProfitMarginPrice2, TotalProfitMarginPrice3, TotalProfitMarginPrice4,
        //            TotalSubTotal1, TotalSubTotal2, TotalSubTotal3, TotalSubTotal4,
        //            TotalTaxID1, TotalTaxID2, TotalTaxID3, TotalTaxID4,
        //            TotalTaxPercentage1, TotalTaxPercentage2, TotalTaxPercentage3, TotalTaxPercentage4,
        //            TotalTaxPrice1, TotalTaxPrice2, TotalTaxPrice3, TotalTaxPrice4,
        //            TotalSellingPrice1, TotalSellingPrice2, TotalSellingPrice3, TotalSellingPrice4,
        //            TotalGrossProfitPercentage1, TotalGrossProfitPercentage2, TotalGrossProfitPercentage3, TotalGrossProfitPercentage4,
        //            TotalGrossProfitPrice1, TotalGrossProfitPrice2, TotalGrossProfitPrice3, TotalGrossProfitPrice4,
        //            IsSubTotalLocked, NoResponseForSave);
        var hdnPricePerUnit1 = document.getElementById("hdn_SubTotal_PricePerUnit1_" + EstimateItemID + "_" + SectNo + "");
        var hdnPricePerUnit2 = document.getElementById("hdn_SubTotal_PricePerUnit2_" + EstimateItemID + "_" + SectNo + "");
        var hdnPricePerUnit3 = document.getElementById("hdn_SubTotal_PricePerUnit3_" + EstimateItemID + "_" + SectNo + "");
        var hdnPricePerUnit4 = document.getElementById("hdn_SubTotal_PricePerUnit4_" + EstimateItemID + "_" + SectNo + "");

        if (hdnPricePerUnit1 == null) {
            var SubTotalPricePerUnit1 = 0;
        } else {
            var SubTotalPricePerUnit1 = Number(hdnPricePerUnit1.value);
        }

        if (hdnPricePerUnit2 == null) {
            var SubTotalPricePerUnit2 = 0;
        } else {
            var SubTotalPricePerUnit2 = Number(hdnPricePerUnit2.value);
        }

        if (hdnPricePerUnit3 == null) {
            var SubTotalPricePerUnit3 = 0;
        } else {
            var SubTotalPricePerUnit3 = Number(hdnPricePerUnit3.value);
        }

        if (hdnPricePerUnit4 == null) {
            var SubTotalPricePerUnit4 = 0;
        } else {
            var SubTotalPricePerUnit4 = Number(hdnPricePerUnit4.value);
        }


        hdnSaveValues.value += EstimateID + '~' + EstimateItemID + '~' + SectionID + '~' + EstimateType + '~' +
            TotalProfitMarginPercentage1 + '~' + TotalProfitMarginPercentage2 + '~' + TotalProfitMarginPercentage3 + '~' + TotalProfitMarginPercentage4 + '~' +
            TotalProfitMarginPrice1 + '~' + TotalProfitMarginPrice2 + '~' + TotalProfitMarginPrice3 + '~' + TotalProfitMarginPrice4 + '~' +
            TotalSubTotal1 + '~' + TotalSubTotal2 + '~' + TotalSubTotal3 + '~' + TotalSubTotal4 + '~' +
            TotalTaxID1 + '~' + TotalTaxID2 + '~' + TotalTaxID3 + '~' + TotalTaxID4 + '~' +
            TotalTaxPercentage1 + '~' + TotalTaxPercentage2 + '~' + TotalTaxPercentage3 + '~' + TotalTaxPercentage4 + '~' +
            TotalTaxPrice1 + '~' + TotalTaxPrice2 + '~' + TotalTaxPrice3 + '~' + TotalTaxPrice4 + '~' +
            TotalSellingPrice1 + '~' + TotalSellingPrice2 + '~' + TotalSellingPrice3 + '~' + TotalSellingPrice4 + '~' +
            TotalGrossProfitPercentage1 + '~' + TotalGrossProfitPercentage2 + '~' + TotalGrossProfitPercentage3 + '~' + TotalGrossProfitPercentage4 + '~' +
            TotalGrossProfitPrice1 + '~' + TotalGrossProfitPrice2 + '~' + TotalGrossProfitPrice3 + '~' + TotalGrossProfitPrice4 + '~' +
            IsSubTotalLocked + '~' + SellingPricePerSQM1 + '~' + SellingPricePerSQM2 + '~' + SellingPricePerSQM3 + '~' + SellingPricePerSQM4 + '~' +
            parseNum(SubTotalPricePerUnit1) + '~' + parseNum(SubTotalPricePerUnit2) + '~' + parseNum(SubTotalPricePerUnit3) + '~' +
            parseNum(SubTotalPricePerUnit4) + '|';


        
    }

    var tblMessage = document.getElementById("tblMessage_" + EstimateItemID + "");
    var lblMessage = document.getElementById("lblMessage_" + EstimateItemID + "");


    btnTypeOFSave = btnType;
    EstimateItemIDOFSave = EstimateItemID;
    EstTypeToSave = EstimateType;
    EstimateSaveID = EstimateID;
    return false;
}

function NoResponseForSave() {
    var tblMessage = document.getElementById("tblMessage_" + EstimateItemIDOFSave + "");
    var lblMessage = document.getElementById("lblMessage_" + EstimateItemIDOFSave + "");

    if (btnTypeOFSave == 'stay') {
        tblMessage.style.display = "block";
        lblMessage.innerHTML = "Item details updated successfully.";
        lblMessage.className = "msg-success";
        setTimeout("TakeOut('" + EstimateItemIDOFSave + "')", 2000);
        if (EstTypeToSave == "B" || EstTypeToSave == "K" || EstTypeToSave == "N" || EstTypeToSave == "R") {
            window.location.href = RedirectPath + "_summary_reeng.aspx?estid=" + EstimateSaveID + "";
        }
    }
    else if (btnTypeOFSave == 'save') {
        if (modulename == 'jobs') {
            window.location = strSitepath + modulename + "/" + "jobs_view.aspx";
        }
        else {
            window.location = strSitepath + modulename + "/" + submodulename + "_view.aspx";
        }
    }

}



var parent_estimateitem_id = '';
function RemoveSubItems(EstimateType, EstimateItemID, ItemTypeID, estid, module, ParentEstimateItemID) {
    //alert(itemTitle);
    parent_estimateitem_id = ParentEstimateItemID;
    var firstConfirm = window.confirm('Are you sure you want to remove this Additional item?');
    if (firstConfirm) {
        debugger;
        if (EstimateType.toLowerCase() == 'c' || EstimateType.toLowerCase() == 'x') {
            if (ManageStockPermission == 1) {
                if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {
                    if (StockCancellationType.toString().toLowerCase() == "a") {
                        item_summary.WarehouseStockBackOn_itemDelete(CompanyID, estid, EstimateItemID, UserID);
                        //setTimeout(function () { item_summary.WarehouseStockBackOn_itemDelete(CompID, EstId, EstimateItemID, UserID); }, 5000);
                        sleep(3000);
                    }
                }
            }
        }
        item_summary.DeleteSubItems(EstimateType, EstimateItemID, ItemTypeID, estid, module, ParentEstimateItemID, FuncOnDelete);
    }
}
function FuncOnDelete() {

    var jID = "";
    var InvID = "";
    if (Number(jobID) != 0) {
        jID = "&jID=" + jobID;
    }
    if (Number(InvoiceID) != 0) {
        InvID = "&InvID=" + InvoiceID;
    }
    if (IsFromeStore == 'yes') {
        if (modulename == "orders") { //order module querystring added ticket 13391
            window.location.href = strSitepath + modulename + "/" + submodulename + "_summary.aspx?frm=edit&suc=SubDel&ordid=" + EstimateID + "&estid=" + EstimateID + jID + InvID + "&EstItemID=" + parent_estimateitem_id;
        }
        else { //for other module querystring estitemid added ticket 13391
            window.location.href = strSitepath + modulename + "/" + submodulename + "_order_summary.aspx?frm=edit&suc=SubDel&ordid=" + EstimateID + "&estid=" + EstimateID + jID + InvID + "&EstItemID=" + parent_estimateitem_id;
        }
    }
    else { // for other module estitemid querystring added ticket 13391
        window.location.href = strSitepath + modulename + "/" + submodulename + "_summary_reeng.aspx?frm=edit&suc=SubDel&ordid=" + EstimateID + "&estid=" + EstimateID + jID + InvID + "&EstItemID=" + parent_estimateitem_id;
    }
}

//====== Progress to Job Starts =========///
function ShowProgressToJob() {
    debugger;
    var isCombine = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdisCombinedPO").value;
    var isCC = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnIsPOPup").value;

    if (isCombine == "yes") {
        ShowConfirmationMessageNEW_PTJ();
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        document.getElementById('divBackGroundNew').style.display = 'block';
    } else {
        if (isCC == "yes") {
            $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnCombinedValue").val("yes");
        } else {
            $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnCombinedValue").val("no");
        }
        if (estimateconvertedtojob == 'True') {
            if (Module.toLowerCase() == "order") {
                alert("This Order is already progressed to Job or the Order items are still not approved/rejected, hence cannot be progressed again.");
                return false;
            }
            else {
                alert("This Estimate is already progressed to Job and hence cannot be progressed again.");
                return false;
            }
        }
        if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "order") {
            //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
            alert(AccountsOnHoldOrderProgressToJob);
            return false;
        }
        if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "estimate") {
            //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
            alert(AccountsOnHoldEstimateProgressToJob);
            return false;
        }
        else {
            div_showinprospect.style.display = "none";
            if (CompanyType == "Prospect") {
                div_showinprospect.style.display = "block";
                if (div_ProgressToJob.style.display == "none") {
                    showDivPopupCenter('div_ProgressToJob', '200');
                    var selects = document.getElementsByTagName("select");
                    for (i = 0; i != selects.length; i++) {
                        selects[i].style.display = 'none';
                    }
                }
                else {
                    div_ProgressToJob.style.display = "none";
                    divBackGroundNew.style.display = "none";
                }
            }
            else {
                if (div_ProgressToJob.style.display == "none") {
                    showDivPopupCenter('div_ProgressToJob', '200');
                    var selects = document.getElementsByTagName("select");
                }
                else {
                    div_ProgressToJob.style.display = "none";
                    divBackGroundNew.style.display = "none";
                }
            }
        }

    }


}


function ShowConfirmationMessageNEW_PTJ() {
    var id = document.getElementById('div_AlertPopup_new');
    var str = "<table id='tbl_Popup_new'  cellpadding='0' cellspacing='0' width='35%' height='82%'>";
    str += "<tr>";
    str += "<td colspan='2' class='popup-top-leftcorner'></td><td class='popup-top-middlebg'><div  align='left' id='div_invoice_Popup_new' class=Label-PopupHeading style='float: right; padding-top: 6px; padding-right: 7px;'><div class='CancelButtonDiv2'><img src='" + strImagepath + "IMAGES/deleteicon3.png' title='Cancel' OnClick='javascript:closePopup();return false;'/></div></div></td><td colspan='2' class='popup-top-rightcorner'></td></tr>";
    str += "<tr>";
    str += "<td class='popup-middle-leftcorner'></td><td style='width: 15px; background-color: #ffffff'></td>";

    str += "<td class='popup-middlebg' align='center' valign='top'><table cellpadding='2' cellspacing='2' border='0' width='100%'><tr><td valign='top'><div id='div_Popup_Invoice_new'><div id='div_rdb_Popup_Invoice_new' style='float: left; padding-bottom: 7px;'><span style='font-weight: bold;'><label id='lbltxt_Popup_new' style='width:310px;margin-left:10px;margin-top:10px' Text=''> Do you want to add this to an existing purchase order? </label></span></div><div style='clear: both'></div><div style='padding-top: 5px; float: left; padding-left: 3.2%; margin-left:80px;'><input type='button' id='btn_Yes_new' onclick=javascript:callYesNoFunction_NEW('yes'); return false; class='button' style='width:50px;' value='Yes'/></div><div style='padding-top: 5px; float: left; padding-left: 3.2%;'><input type='button' id='btn_No_new' style='width:50px;' onclick=javascript:callYesNoFunction_NEW('no'); return false; class='button' value='No'/></div></div></td></tr></table></td>";
    str += "<td style='width: 10px; background-color: #ffffff'></td><td align='right' class='popup-middle-rightcorner'></td>";
    str += "</tr>";
    str += "<tr><td colspan='2' class='popup-bottom-leftcorner'></td><td class='popup-bottom-middlebg'></td><td colspan='2' class='popup-bottom-rightcorner'></td>";
    str += "</tr>";
    str += "</table>";
    id.innerHTML = str;
    id.style.display = 'block';
}

function callYesNoFunction_NEW(value) {
    debugger;
    document.getElementById('div_AlertPopup_new').style.display = "none";
    document.getElementById('divBackGroundNew').style.display = 'none';

    if (value == "yes") {
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_divRadPO").css("display", "block");
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnCombinedValue").val("yes");
        if (estimateconvertedtojob == 'True') {
            if (Module.toLowerCase() == "order") {
                alert("This Order is already progressed to Job or the Order items are still not approved/rejected, hence cannot be progressed again.");
                return false;
            }
            else {
                alert("This Estimate is already progressed to Job and hence cannot be progressed again.");
                return false;
            }
        }
        if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "order") {
            //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
            alert(AccountsOnHoldOrderProgressToJob);
            return false;
        }
        if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "estimate") {
            //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
            alert(AccountsOnHoldEstimateProgressToJob);
            return false;
        }
        else {
            div_showinprospect.style.display = "none";
            if (CompanyType == "Prospect") {
                div_showinprospect.style.display = "block";
                if (div_ProgressToJob.style.display == "none") {
                    showDivPopupCenter('div_ProgressToJob', '200');
                    var selects = document.getElementsByTagName("select");
                    for (i = 0; i != selects.length; i++) {
                        selects[i].style.display = 'none';
                    }
                }
                else {
                    div_ProgressToJob.style.display = "none";
                    divBackGroundNew.style.display = "none";
                }
            }
            else {
                if (div_ProgressToJob.style.display == "none") {
                    showDivPopupCenter('div_ProgressToJob', '200');
                    var selects = document.getElementsByTagName("select");
                }
                else {
                    div_ProgressToJob.style.display = "none";
                    divBackGroundNew.style.display = "none";
                }
            }
        }
    } else {
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_divRadPO").css("display", "none");
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnCombinedValue").val("no");
        if (estimateconvertedtojob == 'True') {
            if (Module.toLowerCase() == "order") {
                alert("This Order is already progressed to Job or the Order items are still not approved/rejected, hence cannot be progressed again.");
                return false;
            }
            else {
                alert("This Estimate is already progressed to Job and hence cannot be progressed again.");
                return false;
            }
        }
        if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "order") {
            //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
            alert(AccountsOnHoldOrderProgressToJob);
            return false;
        }
        if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "estimate") {
            //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
            alert(AccountsOnHoldEstimateProgressToJob);
            return false;
        }
        else {
            div_showinprospect.style.display = "none";
            if (CompanyType == "Prospect") {
                div_showinprospect.style.display = "block";
                if (div_ProgressToJob.style.display == "none") {
                    showDivPopupCenter('div_ProgressToJob', '200');
                    var selects = document.getElementsByTagName("select");
                    for (i = 0; i != selects.length; i++) {
                        selects[i].style.display = 'none';
                    }
                }
                else {
                    div_ProgressToJob.style.display = "none";
                    divBackGroundNew.style.display = "none";
                }
            }
            else {
                if (div_ProgressToJob.style.display == "none") {
                    showDivPopupCenter('div_ProgressToJob', '200');
                    var selects = document.getElementsByTagName("select");
                }
                else {
                    div_ProgressToJob.style.display = "none";
                    divBackGroundNew.style.display = "none";
                }
            }
        }

    }
}



function ShowProgressToJob_Individual(id) {

    debugger;

    var hdnCheckJobCreate = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnCheckJobCreate");
    hdnCheckJobCreate.value = "true";

    var hdnIndJobCreateItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcProgressToJob_hdnIndJobCreateItemID");
    hdnIndJobCreateItemID.value = id;

    if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "order") {
        //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
        alert(AccountsOnHoldOrderProgressToJob);
    }
    if (customerstatustitle.toLowerCase() == 'account on hold' && Module.toLowerCase() == "estimate") {
        //alert("This customer account status is Account on Hold and hence estimate/job/invoice (whichever applicable) cannot be created. To create, kindly change their account status");
        alert(AccountsOnHoldEstimateProgressToJob);
    }
    else {
        div_showinprospect.style.display = "none";
        if (CompanyType == "Prospect") {
            div_showinprospect.style.display = "block";
            if (div_ProgressToJob.style.display == "none") {
                showDivPopupCenter('div_ProgressToJob', '200');
                var selects = document.getElementsByTagName("select");
                for (i = 0; i != selects.length; i++) {
                    selects[i].style.display = 'none';
                }
            }
            else {
                div_ProgressToJob.style.display = "none";
                divBackGroundNew.style.display = "none";
            }
        }
        else {
            if (div_ProgressToJob.style.display == "none") {
                showDivPopupCenter('div_ProgressToJob', '200');

                document.getElementById("divEstItemsList").style.display = "none";
                if (IsArchive == "true") {
                    document.getElementById("div_IsArchive").style.display = "block";
                    document.getElementById("divdates").style.display = "none";

                    document.getElementById("divIsArchivePrompt").style.display = "none";
                    document.getElementById("divProgressToJob").style.display = "block";
                }
                else {
                    document.getElementById("div_IsArchive").style.display = "none";
                    document.getElementById("divdates").style.display = "block";
                    EstItemListNext_Individual();
                }

                var selects = document.getElementsByTagName("select");
            }
            else {
                div_ProgressToJob.style.display = "none";
                divBackGroundNew.style.display = "none";
            }
        }
    }
}

function CloseDiv() {

    if (hdnEmailselectOrnot.value == "email") {
        document.getElementById("div_ProgressToJob").style.display = "none";
        document.getElementById("Div_Print_Email").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
        hdnEmailselectOrnot.value = "";
    }
    else {
        location.reload();
    }
}

//function ClearDates() {
//    txtartworkdate.value = '';
//    txtproofdate.value = '';
//    txtapprovaldate.value = '';
//    txtproductiondate.value = '';
//    txtcompletiondate.value = '';
//    txtdeliverydate.value = '';
//}
//====== Progress to Job Ends =========///


function ShowEstItemDetails(EstItemID, EstType) {
    var EstItemID = EstItemID;
    var EstID = EstimateID;
    window.radopen(strSitepath + "Estimates/estimateItemDetails.aspx?EstimateID=" + EstID + "&EstItemID=" + EstItemID + "&EstType=" + EstType + "", '1000', '500');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    return false;
}

function ShowJobCard(val) {
    var EstItemID = val;
    var EstID = EstimateID;
    var Job_Cart = window.radopen(strSitepath + "jobs/job_card_new.aspx?EstimateID=" + EstID + "&EstItemID=" + EstItemID + "&jID=" + jobID + "&InvID=" + InvoiceID + "");
    Job_Cart.setSize(1000, 500);
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    return false;
}

function AddAnotherItems() {
    var module = Module;
    if (module == "job") {
        window.location.href = strSitepath + "jobs/job_addanitem.aspx?type=more&estid=" + EstimateID + "";
    }
    else if (module == "invoice") {
        window.location.href = strSitepath + "invoice/invoice_addanitem.aspx?type=more&estid=" + EstimateID + "";
    }
    else {
        window.location.href = strSitepath + "estimates/estimate_addanitem.aspx?type=more&estid=" + EstimateID + "";
    }
}

//*************** By Natraj on 25.05.2012, Re-Engineering  ********************//

function OpenPhraseBook(type, txtid, estid, PhraseValue) {
    window.radopen(strSitepath + "common/phrase_book.aspx?type=" + type + "&phraseto=" + txtid + "", null, '1000', '500');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}

// **** By Natraj, Update Item Description and to Phrase Book ****//
function UpdateItemDescription(Estid, EstItemID, DescnIDs, EstType, PageType, ShowPOChkbox, ShowDNChkbox, itemTitle) {
    var ChkSuplierState = '';
    var ChkCopyPOState = '';
    var ChkCopyDNState = '';
    var UpdateItemTitle = document.getElementById("lblItemTitle_" + EstItemID + "");
    var HeaderPanelTitle = document.getElementById("lblHeaderPanelTitle_" + EstItemID + "");

    if (EstType == 'X') {
        //var HeaderPanelTitle2 = document.getElementById("lblHeaderPanelTitle2_" + EstItemID + "");
    }
    if (EstType == 'O') {
        var ChkSuplierID = document.getElementById("ChkboxCopy_Supplier_" + EstItemID + "");
        if (PageType == 'job') {
            if (ShowPOChkbox.toLowerCase() == 'true') {
                var ChkCopyToPOID = document.getElementById("ChkboxCopy_PO_" + EstItemID + "");
                if (ChkCopyToPOID.checked) {
                    ChkCopyPOState = 'true';
                }
                else {
                    ChkCopyPOState = 'false';
                }
            }
            else {
                ChkCopyPOState = 'false';
            }
            if (ShowDNChkbox.toLowerCase() == 'true') {
                var ChkCopyToDNID = document.getElementById("ChkboxCopy_DN_" + EstItemID + "");
                if (ChkCopyToDNID.checked) {
                    ChkCopyDNState = 'true';
                }
                else {
                    ChkCopyDNState = 'false';
                }
            }
            else {
                ChkCopyDNState = 'false';
            }
        }
        else {
            ChkCopyPOState = 'false';
            ChkCopyDNState = 'false';
        }
        if (ChkSuplierID.checked) {
            ChkSuplierState = 'true';
        }
        else {
            ChkSuplierState = 'false';
        }
    }
    else {

        ChkSuplierState = 'false';
        ChkCopyPOState = 'false';
        ChkCopyDNState = 'false';
    }

    var TxtItemValues = '';
    var TxtlabelValues = '';
    var ChkboxValues = ''
    var AllDescnValue = '';
    var SummaryItemTitle = '';
    var SavetoPhraseBook = '';
    var SplitDescn = DescnIDs.split('µ');
    for (var i = 0; i < SplitDescn.length - 1; i++) {
        var ChkID = SplitDescn[i].split('¶');
        var TablColumn = ChkID[0].split('£');
        TablColValue = TablColumn[0];
        ChkboxValues = document.getElementById(TablColumn[1]).checked;
        var IDValues = ChkID[1].split('$');
        var IstoPhrase = IDValues[1].split('€');
        TxtlabelValues = document.getElementById(IDValues[0]).value;
        TxtItemValues = document.getElementById(IstoPhrase[0]).value;
        SavetoPhraseBook = document.getElementById(IstoPhrase[1]).checked;
        if (i == 0) {
            SummaryItemTitle = TxtItemValues
        }
        AllDescnValue += TablColValue + '~|~' + TxtlabelValues + '~|~' + TxtItemValues + '~|~' + ChkboxValues + '~|~' + SavetoPhraseBook + 'µ';

        document.getElementById(IstoPhrase[1]).checked = false;
    }
    //    if (EstType == "O") {
    //        if (window.location.href.indexOf("summary") > -1) {
    //            EstType = 'X';
    //        }
    //    }


    var hdnItemDescription = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnItemDescription_" + EstItemID);
    hdnItemDescription.value = CompanyID + "▬" + Estid + "▬" + EstItemID + "▬" + EstType + "▬" + AllDescnValue + "▬" + ChkSuplierState + "▬" + ChkCopyPOState + "▬" + ChkCopyDNState + "▬" + itemTitle + "▬" + PageType;

    var hdn_Description = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcItemTotal_" + EstItemID + "_hdn_Description");
    hdn_Description.value = CompanyID + "▬" + Estid + "▬" + EstItemID + "▬" + EstType + "▬" + AllDescnValue + "▬" + ChkSuplierState + "▬" + ChkCopyPOState + "▬" + ChkCopyDNState + "▬" + itemTitle + "▬" + PageType;
    //item_summary.UpdateItemDescriptionInSummary(CompanyID, Estid, EstItemID, EstType, AllDescnValue, ChkSuplierState, ChkCopyPOState, ChkCopyDNState, itemTitle, PageType, NoResponse);

    //item_summary.UpdateItemDescriptionInSummary(Estid, EstItemID, EstType, AllDescnValue, ChkSuplierState, ChkCopyPOState, ChkCopyDNState, NoResponse);

    HeaderPanelTitle.innerHTML = SummaryItemTitle;
    if (EstType == 'X') {
        // HeaderPanelTitle2.innerHTML = SummaryItemTitle;
    }
    if (EstType != 'X') {
        //  UpdateItemTitle.innerHTML = SummaryItemTitle;
    }
    var tblMessage = document.getElementById("tblMessage_" + EstItemID + "");
    var lblMessage = document.getElementById("lblMessage_" + EstItemID + "");
    // tblMessage.style.display = "block";
    // lblMessage.innerHTML = "Item description updated successfully.";
    // setTimeout("TakeOut('" + EstItemID + "')", 700);
}
function UpdateProofItemDescription(Estid, EstItemID, DescnIDs, EstType, PageType, ShowPOChkbox, ShowDNChkbox, itemTitle,ProofItemID) {
    var ChkSuplierState = '';
    var ChkCopyPOState = '';
    var ChkCopyDNState = '';
    var UpdateItemTitle = document.getElementById("lblItemTitle_" + EstItemID + "");
    var HeaderPanelTitle = document.getElementById("lblHeaderPanelTitle_" + EstItemID + "");

    ChkSuplierState = 'false';
    ChkCopyPOState = 'false';
    ChkCopyDNState = 'false';

    var TxtItemValues = '';
    var TxtlabelValues = '';
    var ChkboxValues = ''
    var AllDescnValue = '';
    var SummaryItemTitle = '';
    var SavetoPhraseBook = '';
    var SplitDescn = DescnIDs.split('µ');
    for (var i = 0; i < SplitDescn.length - 1; i++) {
        var ChkID = SplitDescn[i].split('¶');
        var TablColumn = ChkID[0].split('£');
        TablColValue = TablColumn[0];
        ChkboxValues = document.getElementById(TablColumn[1]).checked;
        var IDValues = ChkID[1].split('$');
        var IstoPhrase = IDValues[1].split('€');
        TxtlabelValues = document.getElementById(IDValues[0]).value;
        TxtItemValues = document.getElementById(IstoPhrase[0]).value;
        SavetoPhraseBook = document.getElementById(IstoPhrase[1]).checked;
        if (i == 0) {
            SummaryItemTitle = TxtItemValues
        }
        AllDescnValue += TablColValue + '~|~' + TxtlabelValues + '~|~' + TxtItemValues + '~|~' + ChkboxValues + '~|~' + SavetoPhraseBook + 'µ';

        document.getElementById(IstoPhrase[1]).checked = false;
    }
    //    if (EstType == "O") {
    //        if (window.location.href.indexOf("summary") > -1) {
    //            EstType = 'X';
    //        }
    //    }


    var hdnItemDescription = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_hdnItemDescription_" + EstItemID + "_" + ProofItemID);
    hdnItemDescription.value = CompanyID + "UpdateProofItemDescription▬" + Estid + "▬" + EstItemID + "▬" + EstType + "▬" + AllDescnValue + "▬" + ChkSuplierState + "▬" + ChkCopyPOState + "▬" + ChkCopyDNState + "▬" + itemTitle + "▬" + PageType;

    var hdn_Description = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_UcItemTotal_" + ProofItemID + "_hdn_Description");
    hdn_Description.value = CompanyID + "▬" + Estid + "▬" + EstItemID + "▬" + EstType + "▬" + AllDescnValue + "▬" + ChkSuplierState + "▬" + ChkCopyPOState + "▬" + ChkCopyDNState + "▬" + itemTitle + "▬" + PageType;

    //item_summary.UpdateProofItemDescriptionInSummary(CompanyID, Estid, EstItemID, ProofItemID, EstType, AllDescnValue, ChkSuplierState, ChkCopyPOState, ChkCopyDNState, itemTitle, PageType, NoResponse);

    //item_summary.UpdateItemDescriptionInSummary(CompanyID, Estid, EstItemID, EstType, AllDescnValue, ChkSuplierState, ChkCopyPOState, ChkCopyDNState, itemTitle, PageType, NoResponse);

    //item_summary.UpdateItemDescriptionInSummary(Estid, EstItemID, EstType, AllDescnValue, ChkSuplierState, ChkCopyPOState, ChkCopyDNState, NoResponse);

    HeaderPanelTitle.innerHTML = SummaryItemTitle;
    if (EstType == 'X') {
        // HeaderPanelTitle2.innerHTML = SummaryItemTitle;
    }
    if (EstType != 'X') {
        //  UpdateItemTitle.innerHTML = SummaryItemTitle;
    }
    var tblMessage = document.getElementById("tblMessage_" + EstItemID + "");
    var lblMessage = document.getElementById("lblMessage_" + EstItemID + "");
    // tblMessage.style.display = "block";
    // lblMessage.innerHTML = "Item description updated successfully.";
    // setTimeout("TakeOut('" + EstItemID + "')", 700);
}


function TakeOut(EstItemID) {
    var tblMessage = document.getElementById("tblMessage_" + EstItemID + "");
    var lblMessage = document.getElementById("lblMessage_" + EstItemID + "");
    tblMessage.style.display = "none";
    lblMessage.style.display = "none";
}
function NoResponse() {
}


function CallPage(Esttype, ParentEstItemID, ParentEstimateType) {
    if (Esttype == "S") {
        // SFD-Single Item.
        window.location.href = RedirectPath + "_single_item.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit"
    }
    if (Esttype == "P") {
        // SFD- Pads
        window.location.href = RedirectPath + "_pad_item.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit"
    }
    if (Esttype == "F") {
        //SFO-Single Item
        window.location.href = RedirectPath + "_litho_single_item.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit"
    }
    if (Esttype == "D") {
        //SFO- Pads
        window.location.href = RedirectPath + "_litho_pad_item.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit"
    }
    if (Esttype == "L") {
        //LargeFormate Item
        window.location.href = RedirectPath + "_large_item.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit&calcType=linear"
    }
    if (Esttype == "Sq") {
        //LargeFormate Item
        window.location.href = RedirectPath + "_large_item.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit&calcType=square"
    }
    if (Esttype == "ti") {
        //LargeFormate Item
        window.location.href = RedirectPath + "_large_item.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit&calcType=tilling"
    }
    if (Esttype == "C") {
        // Price Catalogue
        window.location.href = RedirectPath + "_pricecatalog.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit"
    }
    if (Esttype == "O") {
        // OutwOrk
        window.location.href = RedirectPath + "_printbroker.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit"
    }
    if (Esttype == "U") {
        // OtherCost Item
        window.location.href = RedirectPath + "_Othercost.aspx?type=add&frm=sum&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit&subitem=s"
    }
    if (Esttype == "T") {
        // DeliveryCost Item
        window.location.href = RedirectPath + "_DeliveryCost.aspx?type=add&frm=sum&estid=" + EstimateID + "&maintype=add"
    }
    //Add inventory as a sub item
    if (Esttype == "W") {
        debugger;
        // inventory/Warehouse 
        window.location.href = RedirectPath + "_warehouse.aspx?type=add&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit"
                                //http://localhost:1111/estimates/estimate_warehouse.aspx?type=add&EstID=102972&jID=0&InvID=0&FromAddAnItem=Y&maintype=add
        //window.location.href = "http://localhost:1111/estimates/estimate_warehouse.aspx?type=edit&estid=102972&EstItemID=185283&esttype=W&frm=sum&maintype=edit";
        //window.location.href = RedirectPath + "_Othercost.aspx?type=add&frm=sum&estid=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&parentestitemid=" + ParentEstItemID + "&parentesttype=" + ParentEstimateType + "&maintype=edit&subitem=s"
    }
}


// Add An Item Call from Summary Page //
function AddAnItem_Call(Esttype) {
    debugger;
    // Sheet Fed Digital.
    if (Esttype == "S") {
        // SFD-Single Item.
        window.location.href = RedirectPath + "_single_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "B") {
        // SFD- Pads
        window.location.href = RedirectPath + "_booklet_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "P") {
        // SFD- Pads
        window.location.href = RedirectPath + "_pad_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    // Sheet Fed Offset
    if (Esttype == "F") {
        //SFO-Single Item
        window.location.href = RedirectPath + "_litho_single_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "K") {
        //SFO- Pads
        window.location.href = RedirectPath + "_litho_booklet_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "N") {
        //SFO- NCR
        window.location.href = RedirectPath + "_NCR_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "R") {
        //SFD- DNCR
        window.location.href = RedirectPath + "_DigitalNCR_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "D") {
        //SFO- Pads
        window.location.href = RedirectPath + "_litho_pad_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "L") {
        //LargeFormate Item
        window.location.href = RedirectPath + "_large_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add&calcType=linear";
    }
    if (Esttype == "Sq") {
        //LargeFormate Item
        window.location.href = RedirectPath + "_large_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add&calcType=square";
    }
    if (Esttype == "ti") {
        //LargeFormate Item
        window.location.href = RedirectPath + "_large_item.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add&calcType=tilling";
    }
    if (Esttype == "C") {
        // Price Catalogue
        var str1 = RedirectPath.toLowerCase();
        var job_ = "job";
        var estimate_ = "estimate";
        var invoice_ = "invoice";
        if (str1.indexOf(job_) != -1) {
            window.location.href = RedirectPath + "_pricecatalog.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add&fromPageType=job";
        } else if (str1.indexOf(estimate_) != -1) {
            window.location.href = RedirectPath + "_pricecatalog.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add&fromPageType=estimate";
        }
        else if (str1.indexOf(invoice_) != -1) {
            window.location.href = RedirectPath + "_pricecatalog.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add&fromPageType=invoice";
        }
        else {
            window.location.href = RedirectPath + "_pricecatalog.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add&fromPageType=others";

        }


    }
    if (Esttype == "O") {
        // OutwOrk
        window.location.href = RedirectPath + "_printbroker.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "U") {
        // OtherCost Item
        window.location.href = RedirectPath + "_Othercost.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add&eStore=" + IsFromeStore + "";
    }
    if (Esttype == "W") {
        // Warehouse
        window.location.href = RedirectPath + "_warehouse.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "Q") {
        // Qucik Quote Item
        window.location.href = RedirectPath + "_quickquote.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
    if (Esttype == "T") {
        // Delivery Cost Item
        window.location.href = RedirectPath + "_DeliveryCost.aspx?type=add&EstID=" + EstimateID + "&jID=" + jobID + "&InvID=" + InvoiceID + "&FromAddAnItem=Y&maintype=add";
    }
}


// Accounting Code...
function ShowAccountingCode(EstItemID, EstType, EstID) {
    var RadWindow_AC = window.radopen(strSitepath + "common/AccountingCode.aspx?EstimateID=" + EstID + "&estitemid=" + EstItemID + "&esttype=" + EstType + "");
    SetRadWindow_latest('divrad', 'divBackGroundNew');
    RadWindow_AC.setSize(780, 400);
    RadWindow_AC.center();
}

function SetRadWindow_latest(divMaskID, divBackgroundID) {
    var divrad = document.getElementById(divMaskID);
    var divBackGroundNew = document.getElementById(divBackgroundID);
    if (document.getElementById(divMaskID).style.display == "none") {
        if (navigator.appName != "Microsoft Internet Explorer") {
            setLoadingPositionOfDivCenter_Ver2(divrad);
        }
        showDivPopupCenter_Ver2(divMaskID);
    }
}

function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
    var divrad = document.getElementById(divMaskID);
    var divBackGroundNew = document.getElementById(divBackgroundID);
    if (document.getElementById(divMaskID).style.display == "none") {
        if (navigator.appName != "Microsoft Internet Explorer") {
            setLoadingPositionOfDivCenter_Ver2(divrad);
        }
        showDivPopupCenter_Ver2(divMaskID);
    }
}
function Send_AccountCode_Value(id, Code, Desc, EstItemID, EstType) {
    var lbl_AccountingCode = document.getElementById("lbl_AccountingCode_" + EstItemID + "");
    var lbl_AccountingCode_desc = document.getElementById("lbl_AccountingCode_desc_" + EstItemID + "");
    var lblaccounthypen = document.getElementById("lblaccounthypen_" + EstItemID + "");
    lbl_AccountingCode.innerHTML = SpecialDecode(Code);
    lbl_AccountingCode.title = SpecialDecode(Code);
    lbl_AccountingCode_desc.innerHTML = SpecialDecode(Desc);
    lbl_AccountingCode_desc.title = SpecialDecode(Desc);
    lblaccounthypen.innerHTML = "-";
}

// Attachments Call.
function ShowAttachments(EstimateID, Pgtype) {
    debugger;
    var currentPage = window.location.href;
    var Rad_Attachment = "";
    if (currentPage.includes("Proofs/Proof_summary.aspx")) {
        var url = new URL(currentPage);
        var estID = url.searchParams.get("estid");
        var proofID = url.searchParams.get("ProofID");
        Rad_Attachment = window.radopen(strSitepath + "common/common_popup.aspx?pagetype=general&type=attachments&estid=" + estID + "&pg=" + Pgtype + "&ActionPage=proof&ProofID=" + proofID + "");
    }
    else {
        Rad_Attachment = window.radopen(strSitepath + "common/common_popup.aspx?pagetype=general&type=attachments&estid=" + EstimateID + "&pg=" + Pgtype + "");
    }
    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
    Rad_Attachment.setSize(1035, 555);
    Rad_Attachment.center();
}

//Proof Attachments Call.
function ShowProofAttachments(EstimateID, Pgtype,AttachmentID,jobID,proofItemID) {
    debugger;
    var currentPage = window.location.href;
    var Rad_Attachment = "";
    if (currentPage.includes("Proofs/Proof_summary.aspx")) {
        var url = new URL(currentPage);
        var estID = url.searchParams.get("estid");
        var proofID = url.searchParams.get("ProofID");
        Rad_Attachment = window.radopen(strSitepath + "common/common_popup.aspx?pagetype=general&type=attachments&estid=" + estID + "&pg=" + Pgtype + "&ActionPage=proof&ProofID=" + proofID + "&AttachmentID=" + AttachmentID + "" + jobID + "&ProofItemID=" + proofItemID + "");
    }
    else {
        Rad_Attachment = window.radopen(strSitepath + "common/common_popup.aspx?pagetype=general&type=attachments&estid=" + EstimateID + "&pg=" + Pgtype + "");
    }
    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
    Rad_Attachment.setSize(1035, 555);
    Rad_Attachment.center();
} 
function ChangeProofStatus(estID, status, attachmentID, proofid, proofitemid, estimateitemid, customerid, hostname)
{
    debugger;
    const reject = "Rejected:\nFile set to Rejected\nPlease confirm that you are setting this file to be Manually Rejected.";
    const approve = "Approved:\nFile set to Approved\nPlease confirm that you are setting this file to be Manually Approved.";

    if (status == "Approved") {
        if (window.confirm(approve)) {
            debugger;
            item_summary.ChangeProofStatus(estID, status, attachmentID, proofid, proofitemid, estimateitemid, customerid, hostname, false, function (result) {
                if (result != "") {
                    alert(result);
                }
            },
                function (error) {
                    alert("An error occurred while updating proof status.");
                });
            window.location.href = strSitepath + "/" + "/Proofs/Proof_summary.aspx?estid=" + estID + "&EstItemID=" + estimateitemid + "&ProofID=" + proofid + "";

        }
    }
    else {
        if (window.confirm(reject)) {
            item_summary.ChangeProofStatus(estID, status, attachmentID, proofid, proofitemid, estimateitemid, customerid, hostname, false, function (result) {
                if (result != "") {
                    alert(result);
                }
            },
                function (error) {
                    alert("An error occurred while updating proof status.");
                });
            window.location.href = strSitepath + "/" + "/Proofs/Proof_summary.aspx?estid=" + estID+"&EstItemID=" + estimateitemid+"&ProofID=" + proofid+"";

        }
    }

}
// *** Copy to Same Customer *** //
function EstimateCopyto_SameCust(Module) {

    if ((hdbstatustitlesamecustomer.value.toLowerCase() == 'account on hold') && (Module == "job")) {
        //alert(AccoutnsOnHoldCopyjobToSameNewCust);
        alert(Accountsonhold);
        return false;
    }
    if ((hdbstatustitlesamecustomer.value.toLowerCase() == 'account on hold') && (Module == "estimate")) {
        //alert(AccoutnsOnHoldCopyestimateToSameNewCust);
        alert(Accountsonhold);
        return false;
    }
    if (Module == "job") {
        var RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + hdnEstimateID.value + "&type=CopyToSameCust&pg=" + Module + "&jID=" + jobID + "&InvID=" + InvoiceID + "");
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(300, 200);
        RadWindow_Paid.center();
        //alert_CopyJobInvoicetoSameConfirm(Module);
        return false;
    }
    else if (Module == "invoice") {
        var RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + hdnEstimateID.value + "&type=CopyToSameCust&pg=" + Module + "&jID=" + jobID + "&InvID=" + InvoiceID + "");
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(330, 200);
        RadWindow_Paid.center();
        //alert_CopyJobInvoicetoSameConfirm(Module);
        return false;
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_divLoadingImageCus").style.display = "block";
        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UCItemSummaryCopy$lnkEstimateCopytoSameCust', '');
        // __doPostBack('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCItemSummaryCopy_lnkEstimateCopytoSameCust', '');
        return false;
    }
}
function alert_CopyJobInvoicetoSameConfirm(Module) {

    if (document.getElementById("divcopy_job_invoice_confirm").style.display == "none") {
        //        document.getElementById("divcopy_job_invoice_confirm").style.width = 350 + "px";
        //        document.getElementById("divcopy_job_invoice_confirm").style.height = 170 + "px";
        //        showDivPopupCenter('divcopy_job_invoice_confirm', '200');
        //        document.getElementById("divlabelSamecust").style.display = "block";
        //        document.getElementById("divlabelNewcust").style.display = "none";
        if (Module == "job") {
            document.getElementById("jobconfirmcopy_alert").style.display = "block";
            document.getElementById("divcopy_job_invoice_confirm").style.display = "block";
        }
        if (Module == "invoice") {
            if (IsProformaInvoice == "True") {
                document.getElementById("div_CopyProformaInvoice").style.display = "block";
            }
            else {
                document.getElementById("invoiceconfirmcopy_alert").style.display = "block";
            }
            document.getElementById("divcopy_job_invoice_confirm").style.display = "block";
        }
        document.getElementById("div_CopySameCustomar").style.display = "block";
        document.getElementById("div_CopyNewCustomar").style.display = "none";
    }
}

//**** Copy to New Customer **** //
function EstimateCopyto_NewCust(Module) {
    //if ((hdnStatusTitle.value.toLowerCase() == 'account on hold') && (Module == "job" || Module == "estimate")) {
    //    alert(Accountsonhold);
    //    return false;
    //}

    var divCopyto_new_customer = document.getElementById("divCopyto_new_customer");
    var div_CopyInvoice = document.getElementById("div_CopyInvoice");
    var div_CopyEstimate = document.getElementById("div_CopyEstimate");
    var div_CopyJob = document.getElementById("div_CopyJob");
    if (document.getElementById("divCopyto_new_customer").style.display == "none") {
        var RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + hdnEstimateID.value + "&type=CopyToNewCust&pg=" + Module + "&jID=" + jobID + "&InvID=" + InvoiceID + "");
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(350, 240);
        RadWindow_Paid.center();

        //        document.getElementById("divCopyto_new_customer").style.width = 430 + "px";
        //        document.getElementById("divCopyto_new_customer").style.height = 180 + "px";
        //        divCopyto_new_customer.style.display = "block";
        //        showDivPopupCenter('divCopyto_new_customer', '200');

        return false;
    }
}

function EstimateCopyto_NewCust_Controls(Module) {
    if (Module == "job") {
        //document.getElementById("div_CopyEstimate").style.display = "none";
        //document.getElementById("div_CopyInvoice").style.display = "none";
        //document.getElementById("div_CopyJob").style.display = "block";
        document.getElementById("div_btnJob").style.display = "block";
        document.getElementById("divlblconfirmjob").style.display = "block";
        document.getElementById("divRadioButton").style.display = "block";
        document.getElementById("divCopyto_new_customer").style.display = "block"
    }
    else if (Module == "invoice") {
        //document.getElementById("div_CopyEstimate").style.display = "none";
        //document.getElementById("div_CopyJob").style.display = "none";
        //document.getElementById("div_CopyInvoice").style.display = "block";
        document.getElementById("div_btnInvoice").style.display = "block";
        document.getElementById("divCopyto_new_customer").style.display = "block"

        if (IsProformaInvoice == "True") {
            document.getElementById("div_lblinvoiceproforma").style.display = "block";
        }
        else {
            document.getElementById("divlblconfirminvoice").style.display = "block";
        }
        document.getElementById("divRadioButton").style.display = "block";
    }
    else {

        //document.getElementById("div_CopyJob").style.display = "none";
        //document.getElementById("div_CopyInvoice").style.display = "none";
        document.getElementById("divRadioButton").style.display = "none";
        //document.getElementById("div_CopyEstimate").style.display = "block";
        document.getElementById("div_btnEstimate").style.display = "block";
        document.getElementById("divCopyto_new_customer").style.marginTop = "-25px";
        document.getElementById("divCopyto_new_customer").style.display = "block"
    }
}
// **** To close the Div Popups **** //
function hideDiv1(val) {
    isValidate = true;
    document.getElementById("spn_txtproofdate").style.display = "none";
    document.getElementById("spn_txtcompletiondate").style.display = "none";
    document.getElementById("spn_txtdeliverydate").style.display = "none";
    document.getElementById("spn_txtartworkdate").style.display = "none";
    document.getElementById("spn_txtapprovaldate").style.display = "none";
    document.getElementById("spn_txtproductiondate").style.display = "none";
    var selects = document.getElementsByTagName("select");
    for (i = 0; i != selects.length; i++) {
        selects[i].style.display = 'block';
    }
    if (val == "validate") {
        if (txtartworkdate.value == "") {
            document.getElementById("spn_txtartworkdate").style.display = "block";
            document.getElementById("spn_txtartworkdate").innerHTML = "Please enter Artwork Date";
            isValidate = false;
        }
        if (txtproofdate.value == "") {
            document.getElementById("spn_txtproofdate").style.display = "block";
            document.getElementById("spn_txtproofdate").innerHTML = "Please enter Proof Date";
            isValidate = false;
        }
        if (txtapprovaldate.value == "") {
            document.getElementById("spn_txtapprovaldate").style.display = "block";
            document.getElementById("spn_txtapprovaldate").innerHTML = "Please enter Approval Date";
            isValidate = false;
        }
        if (txtcompletiondate.value == "") {
            document.getElementById("spn_txtcompletiondate").style.display = "block";
            document.getElementById("spn_txtcompletiondate").innerHTML = "Please enter Completion Date";
            isValidate = false;
        }
        if (txtproductiondate.value == "") {
            document.getElementById("spn_txtproductiondate").style.display = "block";
            document.getElementById("spn_txtproductiondate").innerHTML = "Please enter Production Date";
            isValidate = false;
        }
        if (txtdeliverydate.value == "") {
            document.getElementById("spn_txtdeliverydate").style.display = "block";
            document.getElementById("spn_txtdeliverydate").innerHTML = "Please enter Delivery Date";
            isValidate = false;
        }
        if (ValidateForm(txtartworkdate, 'spn_txtartworkdate', DateFormat1) == false) {
            isValidate = false;
        }
        if (ValidateForm(txtproofdate, 'spn_txtproofdate', DateFormat1) == false) {
            isValidate = false;
        }
        if (ValidateForm(txtapprovaldate, 'spn_txtapprovaldate', DateFormat1) == false) {
            isValidate = false;
        }
        if (ValidateForm(txtcompletiondate, 'spn_txtcompletiondate', DateFormat1) == false) {
            isValidate = false;
        }
        if (ValidateForm(txtproductiondate, 'spn_txtproductiondate', DateFormat1) == false) {
            isValidate = false;
        }
        if (ValidateForm(txtdeliverydate, 'spn_txtdeliverydate', DateFormat1) == false) {
            isValidate = false;
        }
        if (isValidate) {
            test(1);
        }
    }
    else {
        document.getElementById("divBackGroundNew").style.display = "none";
        //document.getElementById("div_ProgressToInvoice").style.display = "none";
        //document.getElementById("div_ProgressToJob").style.display = "none";
        document.getElementById("div_mask").style.display = "none";
        document.getElementById("divCopyto_new_customer").style.display = "none";
        document.getElementById("divCopyto_new_customer").style.display = "none";
        document.getElementById("divcopy_job_invoice_confirm").style.display = "none";

        document.getElementById("div_ProgressToInvoice_reeng").style.display = "none";
        document.getElementById("div_CreatePurchase_reeng").style.display = "none";
        //document.getElementById("div_RevertJob_reeng").style.display = "none";
        return false;
    }
}

//********** Web Service to Select Customer Detail *********//
function ClearStage1Data() {
    hid_Greeting.value = "";
    txtName.value = "";
    hid_CustName.value = "";
    hid_ClientID.value = 0;
    hid_Contact.value = "";
    hid_contactId.value = 0;
    hid_contactName.value = "";
    hdnStatusTitle.value = "";
}
// ****** Copy to New Customer, AutoComplete, from item_summary.js ************//
function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address, DepartmentName, DepartmentID, InvoiceAddressID, InvoiceAddress, ContactAddress, ContactAddressID, StatusTitle) {

    // alert("CleintID=" + ClientID + ", " + ClientName + ", " + Contacts + ", " + AccountNo + ", " + Address + ", " + DepartmentName + ", " + DepartmentID + ", " + InvoiceAddressID + "," + InvoiceAddress);
    ClearStage1Data();
    hdnStatusTitle.value = StatusTitle;
    hid_Greeting.value = "Dear";
    txtName.value = SpecialDecode(ClientName);
    hid_CustName.value = SpecialDecode(ClientName);
    hid_ClientID.value = ClientID;
    hid_AccountNo.value = AccountNo;

    var DefaultContact = '';
    var DefaultContctID = 0;
    hid_Contact.value = Contacts;
    var str_con1 = Contacts.split('^');

    for (var k = 0; k < str_con1.length; k++) {
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
    //************************************************
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
    //***************************************************
    hid_contactName.value = ContactName;
    var firstname = ContactName.split(' ');
    hid_Greeting.value = hid_Greeting.value + ' ' + firstname[0];

    if (Address != '') {
        var str_add1 = Address.split('»');

        for (var i = 0; i < str_add1.length; i++) {
            if (str_add1[i] != '') {
                var AddressID = str_add1[0];
                var Address1 = str_add1[1];
                var LimitAddress = str_add1[2];
                var IsDelivery = str_add1[3];
                var AddressType = str_add1[4];
                var Address_Limit;

                Address_Limit = Address1;

            }
        }
    }
}
// Web Service End

// Multiple DN raise from Job.
function OpenMultiDeliveryNote() {
    var jID = "";
    var InvID = "";
    if (Number(jobID) != 0) {
        jID = "&jID=" + jobID;
    }
    if (Number(InvoiceID) != 0) {
        InvID = "&InvID=" + InvoiceID;
    }
    var RadWindow_del = window.radopen("multiple_delivery_note_new.aspx?page=" + Pgtype + "&Estid=" + EstimateID + "" + jID + "" + InvID + "");
    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
    RadWindow_del.setSize(1100, 600);
    RadWindow_del.center();
}

function OpenMultiDeliveryNoteByItemId(ItemIds) {
    var jID = "";
    var InvID = "";
    if (Number(jobID) != 0) {
        jID = "&jID=" + jobID;
    }
    if (Number(InvoiceID) != 0) {
        InvID = "&InvID=" + InvoiceID;
    }
    var RadWindow_del = window.radopen("multiple_delivery_note_new.aspx?page=" + Pgtype + "&Estid=" + EstimateID + "" + jID + "" + InvID + "" + "&ItemIds=" + ItemIds);
    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
    RadWindow_del.setSize(1100, 600);
    RadWindow_del.center();
}

//Progress to Invoice Call
function ProgressJob_reeng() {
    var ret = 0;

    //    if (document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_ddlStatus").selectedIndex != 0) {
    if (document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode").selectedIndex != 0) {
        ret = 1;
    }
    else {
        // alert("Show Validation message");
        ret = 0;
    }
    // alert('akash');
    if (Ispaidenable == '1') {
        if (ret == 1) {
            //if (document.getElementById("div_ProgressToInvoice_reeng").style.display == "block") {
            if (document.getElementById("div_ProgressToInvoice").style.display == "block") {

                var div_ProgressToJob = document.getElementById("div_ProgressToInvoice");
                var DivBtnPay = document.getElementById("DivBtnPay");
                //var DivProgressJobtoInvoice = document.getElementById("DivProgressJobtoInvoice");
                //var DivInvoicePayment = document.getElementById("DivInvoicePayment_reeng");
                //var DivPaymentDetails = document.getElementById("DivPaymentDetails_reeng");
                var DivPayment_Value = document.getElementById("DivPayment_Value");
                var DivDate_Value = document.getElementById("DivDate_Value");
                var DivNotes_Value = document.getElementById("DivNotes_Value");


                //showDivPopupCenter('div_ProgressToInvoice_reeng', '230');
                //DivProgressJobtoInvoice.style.display = "block";
                hdnHeader.value = "Progress To Invoice";
                //DivInvoicePayment.style.display = "none";
                DivBtnPay.style.display = "none";
                //DivPaymentDetails.style.display = "none";
                DivPayment_Value.style.display = "none";
                DivDate_Value.style.display = "none";
                DivNotes_Value.style.display = "none";

                return false;
            }
            else {
                document.getElementById("div_ProgressToJob").style.display = "none";
                //document.getElementById("div_mask").style.display = "none";
            }
        }
        else {
            var div_ProgressToJob = document.getElementById("div_ProgressToInvoice");
            var DivBtnPay = document.getElementById("DivBtnPay");
            //var DivProgressJobtoInvoice = document.getElementById("DivProgressJobtoInvoice");
            //var DivInvoicePayment = document.getElementById("DivInvoicePayment_reeng");
            //var DivPaymentDetails = document.getElementById("DivPaymentDetails_reeng");
            var DivPayment_Value = document.getElementById("DivPayment_Value");
            var DivDate_Value = document.getElementById("DivDate_Value");
            //var DivNotes_Value = document.getElementById("DivNotes_Value");
            var IspaidQuestion = document.getElementById("IspaidQuestion");
            var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");
            var PaidYesNo = document.getElementById("PaidYesNo");
            // var DivPaddingTop = document.getElementById("DivPaddingTop");
            //alert(DivPaddingTop);
            //showDivPopupCenter('div_ProgressToInvoice_reeng', '230');
            //DivProgressJobtoInvoice.style.display = "block";
            hdnHeader.value = "Progress To Invoice";
            //DivInvoicePayment.style.display = "none";
            DivBtnPay.style.display = "none";
            //DivPaymentDetails.style.display = "none";
            DivPayment_Value.style.display = "none";
            DivDate_Value.style.display = "none";
            //DivNotes_Value.style.display = "none";
            // IspaidQuestion.style.display = "block";
            div_ProformaInvoice.style.display = "block";
            // PaidYesNo.style.display = "block";
            //DivPaddingTop.style.display = "block";
            return false;

        }
    }
    else {
        if (ret == 1) {
            return window.confirm("Are you sure you want to progress this Job to become an Invoice ?  Invoices can not be reverted back to become Jobs in the future.");
        }
        else {
            return false;
        }
    }
}


//////////////

function ProgressJob_reeng_module() {
    var ret = 0;

    //    if (document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_ddlStatus").selectedIndex != 0) {
    if (document.getElementById("ctl00_ContentPlaceHolder1_ddl_Paymentmode_module").selectedIndex != 0) {
        ret = 1;
    }
    else {
        // alert("Show Validation message");
        ret = 0;
    }
    if (Ispaidenable == '1') {
        if (ret == 1) {
            //if (document.getElementById("div_ProgressToInvoice_reeng").style.display == "block") {
            if (document.getElementById("div_ProgressToInvoice").style.display == "block") {

                var div_ProgressToJob = document.getElementById("div_ProgressToInvoice");
                var DivBtnPay = document.getElementById("DivBtnPay");
                //var DivProgressJobtoInvoice = document.getElementById("DivProgressJobtoInvoice");
                //var DivInvoicePayment = document.getElementById("DivInvoicePayment_reeng");
                //var DivPaymentDetails = document.getElementById("DivPaymentDetails_reeng");
                var DivPayment_Value = document.getElementById("DivPayment_Value_module");
                var DivDate_Value = document.getElementById("DivDate_Value_module");
                var DivNotes_Value = document.getElementById("DivNotes_Value_module");


                //showDivPopupCenter('div_ProgressToInvoice_reeng', '230');
                //DivProgressJobtoInvoice.style.display = "block";
                hdnHeader.value = "Progress To Invoice";
                //DivInvoicePayment.style.display = "none";
                DivBtnPay.style.display = "none";
                //DivPaymentDetails.style.display = "none";
                DivPayment_Value.style.display = "none";
                DivDate_Value.style.display = "none";
                DivNotes_Value.style.display = "none";

                return false;
            }
            else {
                document.getElementById("div_ProgressToJob").style.display = "none";
                //document.getElementById("div_mask").style.display = "none";
            }
        }
        else {
            var div_ProgressToJob = document.getElementById("div_ProgressToInvoice");
            var DivBtnPay = document.getElementById("DivBtnPay");
            //var DivProgressJobtoInvoice = document.getElementById("DivProgressJobtoInvoice");
            //var DivInvoicePayment = document.getElementById("DivInvoicePayment_reeng");
            //var DivPaymentDetails = document.getElementById("DivPaymentDetails_reeng");
            var DivPayment_Value = document.getElementById("DivPayment_Value_module");
            var DivDate_Value = document.getElementById("DivDate_Value_module");
            //var DivNotes_Value = document.getElementById("DivNotes_Value");
            var IspaidQuestion = document.getElementById("IspaidQuestion");
            var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");
            var PaidYesNo = document.getElementById("PaidYesNo_module");
            var DivPaddingTop = document.getElementById("DivPaddingTop");

            //showDivPopupCenter('div_ProgressToInvoice_reeng', '230');
            //DivProgressJobtoInvoice.style.display = "block";
            hdnHeader.value = "Progress To Invoice";
            //DivInvoicePayment.style.display = "none";
            DivBtnPay.style.display = "none";
            //DivPaymentDetails.style.display = "none";
            DivPayment_Value.style.display = "none";
            DivDate_Value.style.display = "none";
            //DivNotes_Value.style.display = "none";
            // IspaidQuestion.style.display = "block";
            div_ProformaInvoice.style.display = "block";
            // PaidYesNo.style.display = "block";
            DivPaddingTop.style.display = "block";
            return false;

        }
    }
    else {
        if (ret == 1) {
            return window.confirm("Are you sure you want to progress this Job to become an Invoice ?  Invoices can not be reverted back to become Jobs in the future.");
        }
        else {
            return false;
        }
    }
}


/////

// ToValidate

function ValidateCreateMultiplePo_reeng() {

    var POCheckedCount = 0;
    var AddEstimateItemIDs = '';
    var AllProductAddItems = hdnProductAddItemsIDs.value.split('±');
    var AddChkCnt = 0;

    if (hidPoCount.value != "0" && hidPoCount.value != "") {
        var MainPoCount = Number(hidPoCount.value) - 1;

        for (var i = 0; i <= Number(MainPoCount); i++) {
            var PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_" + i + "").innerHTML;
            var PoEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstItemID_" + i + "").innerHTML;

            //if (PoEstType != "U") {
            if (PoEstType == "B") {

                var PoEstDigiBookletCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstDigiBookletCount_" + i + "").innerHTML;

                if (PoEstDigiBookletCount != "" && PoEstDigiBookletCount != "0") {
                    for (var j = 0; j <= Number(PoEstDigiBookletCount) - 1; j++) {
                        var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                        var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                        var chkProductPO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkProductPO_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                        if (chkPo.checked) {// for enhancement id : 2586
                            POCheckedCount++;
                        } else if (chkProductPO != null) {
                            if (chkProductPO.checked) {
                                POCheckedCount++;
                            }
                        }
                    }
                }
            }
            else if (PoEstType == "K") {
                var PoEstLithoBookletCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstLithoBookletCount_" + i + "").innerHTML;
                if (PoEstLithoBookletCount != "" && PoEstLithoBookletCount != "0") {
                    for (var j = 0; j <= Number(PoEstLithoBookletCount) - 1; j++) {
                        var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                        var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                        var chkProductPO_ = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkProductPO_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                        if (chkPo.checked) {
                            POCheckedCount++;
                        } else if (chkProductPO != null) {
                            if (chkProductPO.checked) {
                                POCheckedCount++;
                            }
                        }
                    }
                }
            }
            else if (PoEstType == "L") {
                var MaterialCount = Number(document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoMaterialCount_" + i + "").innerHTML);
                var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "").innerHTML;
                var chkProductPO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkProductPO_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                var hasMaterials = false;
                for (var k = 0; k < MaterialCount; k++) {

                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_" + k + "_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");

                    if (chkPo.checked) {
                        hasMaterials = true;
                    }
                }
                if (hasMaterials) {
                    POCheckedCount++;
                }
                else if (chkProductPO != null) {
                    if (chkProductPO.checked) {
                        POCheckedCount++;
                    }
                }
            }
            else if (PoEstType == "N" || PoEstType == "R") {
                var PoEstLithoNcrCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstLithoNcrCount_" + i + "").innerHTML;
                if (PoEstLithoNcrCount != "" && PoEstLithoNcrCount != "0") {
                    for (var j = 0; j <= Number(PoEstLithoNcrCount) - 1; j++) {
                        var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                        var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                        var chkProductPO_ = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkProductPO_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                        if (chkPo.checked) {
                            POCheckedCount++;
                        } else if (chkProductPO != null) {
                            if (chkProductPO.checked) {
                                POCheckedCount++;
                            }
                        }
                    }
                }
            }
            else {
                var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "").innerHTML;
                var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                var chkProductPO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkProductPO_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                if (chkPo.checked) {
                    POCheckedCount++;
                } else if (chkProductPO != null) {
                    if (chkProductPO.checked) {
                        POCheckedCount++;
                    }
                }

                if ((PoEstType.toLowerCase() == "c" || PoEstType.toLowerCase() == "x") && AddChkCnt == 0) {
                    var ProductAddItemsIDs_PO = "";
                    for (var y = 0; y < AllProductAddItems.length - 1; y++) {
                        var chkRaisePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPoAdd_PrAd_0_" + AllProductAddItems[y]);
                        if (chkRaisePO.checked) {
                            ProductAddItemsIDs_PO += AllProductAddItems[y] + "↑";
                            POCheckedCount++;
                        }
                    }
                    hdnProductAddItemsIDs_PO.value += ProductAddItemsIDs_PO;
                    AddChkCnt++;
                }
            }

            //For Additional Items
            var PoAddCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoAddCount_" + PoEstItemID).innerHTML;

            if (PoAddCount != 0) {
                for (var a = 1; a <= PoAddCount; a++) {

                    var PoAddEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoAddEstItemID_" + i + "_" + a + "").innerHTML;
                    var PoAddEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoAddEstType_" + i + "_" + a + "").innerHTML;
                    var subMaterialChkd = false;

                    if (PoAddEstType == "L") {
                        var PoSubMaterialCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoSubMaterialCount_" + i + "_" + a + "").innerHTML;
                        for (var x = 0; x < PoSubMaterialCount; x++) {
                            var chkPoAdd = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPoAdd_" + x + "_" + PoAddEstItemID + "_" + i + "_" + a + "");
                            if (chkPoAdd.checked) {
                                subMaterialChkd = true;
                            }
                        }
                    }
                    var chkPoAdd = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPoAdd_0_" + PoAddEstItemID + "_" + i + "_" + a + "");
                    var chkProductPO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkProductPO_0_" + PoAddEstItemID + "_" + i + "_" + a + "");

                    if (chkPoAdd.checked || subMaterialChkd == true) {
                        POCheckedCount++;
                        AddEstimateItemIDs = AddEstimateItemIDs + PoAddEstItemID + "µ";
                    } else if (chkProductPO != null) {
                        if (chkProductPO.checked) {
                            POCheckedCount++;
                            AddEstimateItemIDs = AddEstimateItemIDs + PoAddEstItemID + "µ";
                        }
                    }

                    if ((PoAddEstType.toLowerCase() == "c" || PoAddEstType.toLowerCase() == "x") && AddChkCnt == 0) {
                        var ProductAddItemsIDs_PO = "";
                        for (var y = 0; y < AllProductAddItems.length - 1; y++) {
                            var chkRaisePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPoAdd_PrAd_0_" + AllProductAddItems[y]);
                            if (chkRaisePO.checked) {
                                ProductAddItemsIDs_PO += AllProductAddItems[y] + "↑";
                                POCheckedCount++;
                            }
                        }
                        hdnProductAddItemsIDs_PO.value += ProductAddItemsIDs_PO;
                        AddChkCnt++;
                    }
                }
            }
            //}
        }

        hid_AdditionalItemIDs.value = AddEstimateItemIDs;

        if (Number(POCheckedCount) == 0) {
            document.getElementById("spn_checkPO").style.display = "block";
            return false;
        }
        else {
            return true;
        }
    }
    else {
        return false;
    }

}

//----------------------------------------------------------------
function callYesNoFunction(value) {
    debugger;
    document.getElementById('div_AlertPopup_new').style.display = "none";
    document.getElementById('divBackGroundNew').style.display = 'none';
    //var txt;
    //var r = confirm("Do you want to add this to an existing purchase order?");
    var isCC = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_hdnIsPOPup").value;
    if (value == "yes") {
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_divRadPO").css("display", "block");
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_hdnCombinedValue").val("yes");
        var AllProductAddItems = hdnProductAddItemsIDs.value.split('±');
        var PoAddCount = 0;
        var singlePO = 0;

        if (hidPoCount.value != "0" && hidPoCount.value != "") {
            if (!(btnCreatePo.disabled)) {

                var MainPoCount = Number(hidPoCount.value) - 1;

                for (var i = 0; i <= Number(MainPoCount); i++) {
                    var PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_" + i + "").innerHTML;
                    var PoEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstItemID_" + i + "").innerHTML;

                    //To check Additional Items count
                    PoAddCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoAddCount_" + PoEstItemID).innerHTML;
                    if (PoAddCount == 0) {
                        PoAddCount = 1;
                        singlePO = 1;
                    }

                    //modification 15-6-2019
                    if (PoAddCount != 0 && singlePO != 1) {

                        for (var a = 1; a <= PoAddCount; a++) {
                            var PoAddEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoAddEstItemID_" + i + "_" + a + "").innerHTML;
                            var chkPoAdd = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPoAdd_0_" + PoAddEstItemID + "_" + i + "_" + a + "_0");

                        }
                    }

                    if (PoAddCount == 0 && hidPoCount.value == 1) {
                        if (PoEstType == "B") {

                            var PoEstDigiBookletCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstDigiBookletCount_" + i + "").innerHTML;

                            if (PoEstDigiBookletCount != "" && PoEstDigiBookletCount != "0") {
                                for (var j = 0; j <= Number(PoEstDigiBookletCount) - 1; j++) {
                                    var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                    chkPo.checked = true;
                                }
                            }
                        }
                        else if (PoEstType == "K") {
                            var PoEstLithoBookletCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstLithoBookletCount_" + i + "").innerHTML;
                            if (PoEstLithoBookletCount != "" && PoEstLithoBookletCount != "0") {
                                for (var j = 0; j <= Number(PoEstLithoBookletCount) - 1; j++) {
                                    var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                    chkPo.checked = true;
                                }
                            }
                        }
                        else if (PoEstType == "N" || PoEstType == "R") {
                            //                        alert(';');
                            var PoEstLithoNcrCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstLithoNcrCount_" + i + "").innerHTML;
                            if (PoEstLithoNcrCount != "" && PoEstLithoNcrCount != "0") {
                                for (var j = 0; j <= Number(PoEstLithoNcrCount) - 1; j++) {
                                    var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                    chkPo.checked = true;
                                }
                            }
                        }
                        else {
                            var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "").innerHTML;

                            if (!((PoEstType.toLowerCase() == 'c' || PoEstType.toLowerCase() == 'x') && AllProductAddItems.length > 1)) {

                                var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                chkPo.checked = true;
                            }
                        }
                    }
                }

                var MarerialCount = 0;
                var PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_0").innerHTML;
                if (hidPoCount.value == 1 && PoEstType == 'L') {
                    MarerialCount = Number(document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoMaterialCount_0").innerHTML);
                    if (MarerialCount == 1 && PoAddCount == 0 && ProductPOCount == 0) {
                        hid_Po1Count.value = "yes";
                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UCRaisePO$lnkCreatePo', '');
                    }
                    else {
                        hid_Po1Count.value = "no";
                        var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                        showDivPopupCenter('div_CreatePurchase_reeng', '210');
                    }
                }
                else if (PoAddCount == 0 && hidPoCount.value == 1 && ProductPOCount == 0) {
                    hid_Po1Count.value = "yes";

                    if ((PoEstType.toLowerCase() == 'c' || PoEstType.toLowerCase() == 'x') && AllProductAddItems.length > 1) {
                        hid_Po1Count.value = "no";
                        var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                        showDivPopupCenter('div_CreatePurchase_reeng', '210');
                    }
                    else {
                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UCRaisePO$lnkCreatePo', '');
                    }
                }
                else {
                    hid_Po1Count.value = "no";
                    var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                    showDivPopupCenter('div_CreatePurchase_reeng', '210');
                }
            }
            else {
                var MainPoCount = Number(hidPoCount.value) - 1;
                var PoEstType = '';
                for (var i = 0; i <= Number(MainPoCount); i++) {
                    PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_" + i + "").innerHTML;
                }
                var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                showDivPopupCenter('div_CreatePurchase_reeng', '210');
            }
        }


    } else {
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_divRadPO").css("display", "none");
        $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_hdnCombinedValue").val("no");

        var AllProductAddItems = hdnProductAddItemsIDs.value.split('±');
        var PoAddCount = 0;
        var singlePO = 0;

        if (hidPoCount.value != "0" && hidPoCount.value != "") {
            if (!(btnCreatePo.disabled)) {

                var MainPoCount = Number(hidPoCount.value) - 1;

                for (var i = 0; i <= Number(MainPoCount); i++) {
                    var PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_" + i + "").innerHTML;
                    var PoEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstItemID_" + i + "").innerHTML;

                    //To check Additional Items count
                    PoAddCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoAddCount_" + PoEstItemID).innerHTML;
                    if (PoAddCount == 0) {
                        PoAddCount = 1;
                        singlePO = 1;
                    }

                    //modification 15-6-2019
                    if (PoAddCount != 0 && singlePO != 1) {

                        for (var a = 1; a <= PoAddCount; a++) {
                            var PoAddEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoAddEstItemID_" + i + "_" + a + "").innerHTML;
                            var chkPoAdd = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPoAdd_0_" + PoAddEstItemID + "_" + i + "_" + a + "_0");

                        }
                    }

                    if (PoAddCount == 0 && hidPoCount.value == 1) {
                        if (PoEstType == "B") {

                            var PoEstDigiBookletCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstDigiBookletCount_" + i + "").innerHTML;

                            if (PoEstDigiBookletCount != "" && PoEstDigiBookletCount != "0") {
                                for (var j = 0; j <= Number(PoEstDigiBookletCount) - 1; j++) {
                                    var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                    chkPo.checked = true;
                                }
                            }
                        }
                        else if (PoEstType == "K") {
                            var PoEstLithoBookletCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstLithoBookletCount_" + i + "").innerHTML;
                            if (PoEstLithoBookletCount != "" && PoEstLithoBookletCount != "0") {
                                for (var j = 0; j <= Number(PoEstLithoBookletCount) - 1; j++) {
                                    var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                    chkPo.checked = true;
                                }
                            }
                        }
                        else if (PoEstType == "N" || PoEstType == "R") {
                            //                        alert(';');
                            var PoEstLithoNcrCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstLithoNcrCount_" + i + "").innerHTML;
                            if (PoEstLithoNcrCount != "" && PoEstLithoNcrCount != "0") {
                                for (var j = 0; j <= Number(PoEstLithoNcrCount) - 1; j++) {
                                    var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                    chkPo.checked = true;
                                }
                            }
                        }
                        else {
                            var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "").innerHTML;

                            if (!((PoEstType.toLowerCase() == 'c' || PoEstType.toLowerCase() == 'x') && AllProductAddItems.length > 1)) {

                                var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                chkPo.checked = true;
                            }
                        }
                    }
                }

                var MarerialCount = 0;
                var PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_0").innerHTML;
                if (hidPoCount.value == 1 && PoEstType == 'L') {
                    MarerialCount = Number(document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoMaterialCount_0").innerHTML);
                    if (MarerialCount == 1 && PoAddCount == 0 && ProductPOCount == 0) {
                        hid_Po1Count.value = "yes";
                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UCRaisePO$lnkCreatePo', '');
                    }
                    else {
                        hid_Po1Count.value = "no";
                        var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                        showDivPopupCenter('div_CreatePurchase_reeng', '210');
                    }
                }
                else if (PoAddCount == 0 && hidPoCount.value == 1 && ProductPOCount == 0) {
                    hid_Po1Count.value = "yes";

                    if ((PoEstType.toLowerCase() == 'c' || PoEstType.toLowerCase() == 'x') && AllProductAddItems.length > 1) {
                        hid_Po1Count.value = "no";
                        var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                        showDivPopupCenter('div_CreatePurchase_reeng', '210');
                    }
                    else {
                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UCRaisePO$lnkCreatePo', '');
                    }
                }
                else {
                    hid_Po1Count.value = "no";
                    var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                    showDivPopupCenter('div_CreatePurchase_reeng', '210');
                }
            }
            else {
                var MainPoCount = Number(hidPoCount.value) - 1;
                var PoEstType = '';
                for (var i = 0; i <= Number(MainPoCount); i++) {
                    PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_" + i + "").innerHTML;
                }
                var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                showDivPopupCenter('div_CreatePurchase_reeng', '210');
            }
        }

    }
}


function ShowConfirmationMessageNEW() {
    var id = document.getElementById('div_AlertPopup_new');
    var str = "<table id='tbl_Popup_new'  cellpadding='0' cellspacing='0' width='35%' height='82%'>";
    str += "<tr>";
    str += "<td colspan='2' class='popup-top-leftcorner'></td><td class='popup-top-middlebg'><div  align='left' id='div_invoice_Popup_new' class=Label-PopupHeading style='float: right; padding-top: 6px; padding-right: 7px;'><div class='CancelButtonDiv2'><img src='" + strImagepath + "IMAGES/deleteicon3.png' title='Cancel' OnClick='javascript:closePopup();return false;'/></div></div></td><td colspan='2' class='popup-top-rightcorner'></td></tr>";
    str += "<tr>";
    str += "<td class='popup-middle-leftcorner'></td><td style='width: 15px; background-color: #ffffff'></td>";

    str += "<td class='popup-middlebg' align='center' valign='top'><table cellpadding='2' cellspacing='2' border='0' width='100%'><tr><td valign='top'><div id='div_Popup_Invoice_new'><div id='div_rdb_Popup_Invoice_new' style='float: left; padding-bottom: 7px;'><span style='font-weight: bold;'><label id='lbltxt_Popup_new' style='width:310px;margin-left:10px;margin-top:10px' Text=''> Do you want to add this to an existing purchase order? </label></span></div><div style='clear: both'></div><div style='padding-top: 5px; float: left; padding-left: 3.2%; margin-left:80px;'><input type='button' id='btn_Yes_new' onclick=javascript:callYesNoFunction('yes'); return false; class='button' style='width:50px;' value='Yes'/></div><div style='padding-top: 5px; float: left; padding-left: 3.2%;'><input type='button' id='btn_No_new' style='width:50px;' onclick=javascript:callYesNoFunction('no'); return false; class='button' value='No'/></div></div></td></tr></table></td>";
    str += "<td style='width: 10px; background-color: #ffffff'></td><td align='right' class='popup-middle-rightcorner'></td>";
    str += "</tr>";
    str += "<tr><td colspan='2' class='popup-bottom-leftcorner'></td><td class='popup-bottom-middlebg'></td><td colspan='2' class='popup-bottom-rightcorner'></td>";
    str += "</tr>";
    str += "</table>";
    id.innerHTML = str;
    id.style.display = 'block';
}
function closePopup() {
    document.getElementById('div_AlertPopup_new').style.display = "none";
    document.getElementById('divBackGroundNew').style.display = 'none';
}




//----------------------------------------------------------------
function CreatePurchase_reeng() {
    var isCombine = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_hdisCombinedPO").value;
    var isCC = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_hdnIsPOPup").value;

    if (isCombine == "yes") {
        ShowConfirmationMessageNEW();
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        document.getElementById('divBackGroundNew').style.display = 'block';
    } else {
        if (isCC == "yes") {
            $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_hdnCombinedValue").val("yes");
        } else {
            $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_hdnCombinedValue").val("no");
        }

        var AllProductAddItems = hdnProductAddItemsIDs.value.split('±');
        var PoAddCount = 0;
        var singlePO = 0;

        if (hidPoCount.value != "0" && hidPoCount.value != "") {
            if (!(btnCreatePo.disabled)) {

                var MainPoCount = Number(hidPoCount.value) - 1;

                for (var i = 0; i <= Number(MainPoCount); i++) {
                    var PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_" + i + "").innerHTML;
                    var PoEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstItemID_" + i + "").innerHTML;

                    //To check Additional Items count
                    PoAddCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoAddCount_" + PoEstItemID).innerHTML;
                    if (PoAddCount == 0) {
                        PoAddCount = 1;
                        singlePO = 1;
                    }

                    //modification 15-6-2019
                    if (PoAddCount != 0 && singlePO != 1) {

                        for (var a = 1; a <= PoAddCount; a++) {
                            var PoAddEstItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoAddEstItemID_" + i + "_" + a + "").innerHTML;
                            var chkPoAdd = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPoAdd_0_" + PoAddEstItemID + "_" + i + "_" + a + "_0");

                        }
                    }

                    if (PoAddCount == 0 && hidPoCount.value == 1) {
                        if (PoEstType == "B") {

                            var PoEstDigiBookletCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstDigiBookletCount_" + i + "").innerHTML;

                            if (PoEstDigiBookletCount != "" && PoEstDigiBookletCount != "0") {
                                for (var j = 0; j <= Number(PoEstDigiBookletCount) - 1; j++) {
                                    var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                    chkPo.checked = true;
                                }
                            }
                        }
                        else if (PoEstType == "K") {
                            var PoEstLithoBookletCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstLithoBookletCount_" + i + "").innerHTML;
                            if (PoEstLithoBookletCount != "" && PoEstLithoBookletCount != "0") {
                                for (var j = 0; j <= Number(PoEstLithoBookletCount) - 1; j++) {
                                    var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                    chkPo.checked = true;
                                }
                            }
                        }
                        else if (PoEstType == "N" || PoEstType == "R") {
                            //                        alert(';');
                            var PoEstLithoNcrCount = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstLithoNcrCount_" + i + "").innerHTML;
                            if (PoEstLithoNcrCount != "" && PoEstLithoNcrCount != "0") {
                                for (var j = 0; j <= Number(PoEstLithoNcrCount) - 1; j++) {
                                    var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "_" + j + "").innerHTML;
                                    var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                    chkPo.checked = true;
                                }
                            }
                        }
                        else {
                            var PoEstBookletItemID = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstBookletItemID_" + i + "").innerHTML;

                            if (!((PoEstType.toLowerCase() == 'c' || PoEstType.toLowerCase() == 'x') && AllProductAddItems.length > 1)) {

                                var chkPo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_chkPo_0_" + PoEstItemID + "_" + PoEstBookletItemID + "_" + i + "");
                                chkPo.checked = true;
                            }
                        }
                    }
                }

                var MarerialCount = 0;
                var PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_0").innerHTML;
                if (hidPoCount.value == 1 && PoEstType == 'L') {
                    MarerialCount = Number(document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoMaterialCount_0").innerHTML);
                    if (MarerialCount == 1 && PoAddCount == 0 && ProductPOCount == 0) {
                        hid_Po1Count.value = "yes";
                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UCRaisePO$lnkCreatePo', '');
                    }
                    else {
                        hid_Po1Count.value = "no";
                        var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                        showDivPopupCenter('div_CreatePurchase_reeng', '210');
                    }
                }
                else if (PoAddCount == 0 && hidPoCount.value == 1 && ProductPOCount == 0) {
                    hid_Po1Count.value = "yes";

                    if ((PoEstType.toLowerCase() == 'c' || PoEstType.toLowerCase() == 'x') && AllProductAddItems.length > 1) {
                        hid_Po1Count.value = "no";
                        var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                        showDivPopupCenter('div_CreatePurchase_reeng', '210');
                    }
                    else {
                        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UCRaisePO$lnkCreatePo', '');
                    }
                }
                else {
                    hid_Po1Count.value = "no";
                    var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                    showDivPopupCenter('div_CreatePurchase_reeng', '210');
                }
            }
            else {
                var MainPoCount = Number(hidPoCount.value) - 1;
                var PoEstType = '';
                for (var i = 0; i <= Number(MainPoCount); i++) {
                    PoEstType = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UCRaisePO_PoEstType_" + i + "").innerHTML;
                }
                var div_CreatePurchase = document.getElementById("div_CreatePurchase_reeng");
                showDivPopupCenter('div_CreatePurchase_reeng', '210');
            }
        }
    }


}





//// To Raise the PO from Job.
//function CreatePurchase_reeng1() {
//    if (hidPoCount.value == '1') {
//        hid_Po1Count.value = "yes";
//        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UCRaisePO$lnkCreatePo', '');
//    }
//    else if (document.getElementById("div_CreatePurchase_reeng").style.display == "none") {
//        hid_Po1Count.value = "no";
//        var div_CreatePurchase_reeng = document.getElementById("div_CreatePurchase_reeng");
//        div_CreatePurchase_reeng.style.display = "block";
//        showDivPopupCenter('div_CreatePurchase_reeng', '210');

//    }
//    //}
//}

// To Revert Job to Estimate.
function RevertJob_reeng(moduletype) {

    var RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + hdnEstimateID.value + "&jid=" + hdnJObID.value + "&module=" + moduletype + "&type=RevertToEstimate&pg=job");
    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
    RadWindow_Paid.setSize(480, 250);
    RadWindow_Paid.center();

    //    if (ManageStockPermission = 1 && StockCancellationType.toLowerCase() == "p" && hdnIsProducttype.value == "true") {
    //        document.getElementById("divStockChk").style.display = "block";
    //    }
    //showDivPopupCenter('div_RevertJob_reeng', '200');
    return false;
}

// To Revert Job Items to Estimate.
function RevertJobItems_reeng(moduletype, EstimateItemID, EstimateID, JobID) {

    var RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + EstimateID + "&jid=" + JobID + "&module=" + moduletype + "&type=RevertToEstimate&pg=job&IsItemRevert=1&estitemid=" + EstimateItemID);
    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
    RadWindow_Paid.setSize(480, 250);
    RadWindow_Paid.center();
    return false;
}

function RevertJob_reeng_Controls() {
    //var hdnIsinventoryBack = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnIsinventoryBack");

    var Chk_InvaAjusted = document.getElementById("div_invchk");
    if (InventoryManagement.toLowerCase() == "im" && hdnIsinventoryBack.value == "true") {
        if (Module.toLowerCase() == "job") {
            if (ReduceStockTypeForCancelledVal.toLowerCase() == "p") {
                Chk_InvaAjusted.style.display = "block";
            }
        }
    }
}

function RevertJobNew_reeng() {

    // var Chk_InvaAjusted = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_Chk_InvaAjusted");
    //ctl00_ContentPlaceHolder1_ctl00_Chk_InvaAjusted
    //var Chk_StockCancel = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_Chk_StockCancel");
    //ctl00_ContentPlaceHolder1_ctl00_Chk_StockCancel
    //for inventory stock manegement process
    //    if (Chk_InvaAjusted.checked) {
    //        document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "true";
    //    }
    //    else {
    //        document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
    //    }

    //    //for warehouse stock manegement process
    //    if (Chk_StockCancel.checked) {
    //        document.getElementById("ctl00_tint_hdnStockCancelChk").value = "true";
    //    }
    //    else {
    //        document.getElementById("ctl00_tint_hdnStockCancelChk").value = "false";
    //    }

    //var Chk_DeletePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_Chk_DeletePO");
    //ctl00_ContentPlaceHolder1_ctl00_Chk_DeletePO
    //var Chk_DeleteDN = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_Chk_DeleteDN");
    //ctl00_ContentPlaceHolder1_ctl00_Chk_DeleteDN
    //    if (Chk_DeletePO.checked) {
    //        hidchkDeletepo.value = "true";
    //    }
    //    if (Chk_DeleteDN.checked) {
    //        hidchkDeleteDel.value = "true";
    //    }

    if (Chk_InvaAjusted.checked) {
        hdnReduceStockTypeForCancelledNew.value = "true";
    }
    else {
        hdnReduceStockTypeForCancelledNew.value = "false";
    }

    //for warehouse stock manegement process
    if (Chk_StockCancel.checked) {
        hdnStockCancelChk.value = "true";
    }
    else {
        hdnStockCancelChk.value = "false";
    }

    if (Chk_DeletePO.checked) {
        hidchkDeletepo.value = "true";
    }
    if (Chk_DeleteDN.checked) {
        hidchkDeleteDel.value = "true";
    }

    //__doPostBack('ctl00$tint$lnk_RevertToJob', '');
    __doPostBack('ctl00$ContentPlaceHolder1$ctl00$lnk_RevertToJob', '');
    return false;
}

//  Activity History
function ShowNotes() {
    debugger;
    //showDivPopupCenter('div_notes', '320');   

    var RadWindow_Paid = "";
    if (Module.toLowerCase() == "estimate" || Module.toLowerCase() == "order") {
        RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + hdnEstimateID.value + "&type=ActivityHistory&pg=" + Module);
    }
    if (Module.toLowerCase() == "proof") {
        RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + hdnEstimateID.value + "&type=ActivityHistory&pg=estimate");
    }
    if (Module.toLowerCase() == "job") {
        RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + jobID + "&type=ActivityHistory&pg=" + Module);
    }
    if (Module.toLowerCase() == "invoice") {
        RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + InvoiceID + "&type=ActivityHistory&pg=" + Module);
    }

    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
    RadWindow_Paid.setSize(1000, 500);
    RadWindow_Paid.center();
    //document.getElementById("div_notes").style.display = "block";
}

//  Activity History Induvidual Item
function ShowNotes_PerItem(ItemID) {
    //showDivPopupCenter('div_notes', '320');
    var RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?estid=" + hdnEstimateID.value + "&type=ActivityHistory&pg=" + Module + "&itemID=" + ItemID);
    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
    RadWindow_Paid.setSize(1000, 500);
    RadWindow_Paid.center();
    //document.getElementById("div_notes").style.display = "block";
}
function hideDiv(divid) {
    document.getElementById(divid).style.display = "none";
    selects = document.getElementsByTagName("select");

    //By Jagat On 19/July

    //  for (i = 0; i != selects.length; i++) {
    //     selects[i].style.display = "block";
    //  }


    if (divid == "div_ActivityHistory_add") {
        document.getElementById("divBackGroundNew").style.display = "block";
    }
    else {
        document.getElementById("divBackGroundNew").style.display = "none";
    }
}

// Delete the Estimate Summary Item.
function EstimateItemsDelete(CompID, EstimateItemID, EstType, EstId, Module, itemTitle, JobId) {

    var chk_invoiceitempaymentype = '';
    if (Module.toLowerCase().trim() == 'invoice'
        && document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_0_div_PaymentType').style.display != 'none') {
        chk_invoiceitempaymentype = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_0_lblPaymentType').innerHTML;
        //if (chk_invoiceitempaymentype != undefined || chk_invoiceitempaymentype != null) {
        //    if (chk_invoiceitempaymentype.indexOf("Credit Card") > -1 || chk_invoiceitempaymentype.indexOf("Braintree Credit Card") > -1) {
        //        Delete_Confirmation_Common_Msg = 'Are you sure you want to delete this item? This will delete all ' + Module.toLowerCase() + ' items where payment made by credit card.';
        //    }
        //}
    }
    if (Module.toLowerCase().trim() == 'job'
        && document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_' + EstId + '_div_PaymentType').style.display != 'none') {
        chk_invoiceitempaymentype = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_' + EstId + '_lblPaymentType').innerHTML;
        //if (chk_invoiceitempaymentype != undefined || chk_invoiceitempaymentype != null) {
        //    if (chk_invoiceitempaymentype.indexOf("Credit Card") > -1 || chk_invoiceitempaymentype.indexOf("Braintree Credit Card") > -1) {
        //        Delete_Confirmation_Common_Msg = 'Are you sure you want to delete this item? This will delete all ' + Module.toLowerCase() + ' items where payment made by credit card.';
        //    }
        //}
    }
    var hdndeleteparm = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdndeleteparm");
    var firstConfirm = false;
    var isAlreadyDeleted = false;

    if (window.confirm(Delete_Confirmation_Common_Msg)) {
        if (PgtypeNew.toLowerCase() == "estimate" || PgtypeNew.toLowerCase() == "order") {

            //if (PgtypeNew.toLowerCase() == "estimate") {
            //    firstConfirm = window.confirm(EstimateItemDeleteMsg);
            //}
            //if (PgtypeNew.toLowerCase() == "order") {
            //    firstConfirm = window.confirm(OrderItemDeleteMsg);
            //}

            //if (firstConfirm) {
            if (EstType.toLowerCase() == "s" || EstType.toLowerCase() == "b" || EstType.toLowerCase() == "p" || EstType.toLowerCase() == "f" || EstType.toLowerCase() == "k" || EstType.toLowerCase() == "n" || EstType.toLowerCase() == "r" || EstType.toLowerCase() == "d" || EstType.toLowerCase() == "l") {
                if (InventoryManagement.toString().toLowerCase() == "im") {
                    if (Module.toLowerCase() == "job" || Module.toLowerCase() == "invoice") {
                        if (ISInventoryReduced == 0 && (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p")) {

                            if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
                                item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                                isAlreadyDeleted = true;
                            }
                        }
                        else if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "a") {
                            item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                            isAlreadyDeleted = true;
                        }
                    }
                }
            }
            if (EstType.toLowerCase() == 'c' || EstType.toLowerCase() == 'x') {
                if (ManageStockPermission == 1) {
                    if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {

                        if (StockCancellationType.toString().toLowerCase() == "a") {

                            item_summary.WarehouseStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                            isAlreadyDeleted = true;
                        }
                    }
                    else if (PgtypeNew.toLowerCase() == "order" && EstType.toLowerCase() == 'x') {
                        if (StockCancellationType.toString().toLowerCase() == "a") {

                            item_summary.WarehouseStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                            isAlreadyDeleted = true;
                        }
                    }
                }
            }
            if (isAlreadyDeleted == false) {
                item_summary.Estimate_Items_Delete(CompID, EstimateItemID, EstType, EstId, Module, itemTitle, false, Redirect);
            }
            //}
        }
        else if (PgtypeNew.toLowerCase() == "job") {

            if (typeof chk_invoiceitempaymentype != 'undefined' && chk_invoiceitempaymentype != undefined &&
                chk_invoiceitempaymentype != null && chk_invoiceitempaymentype.indexOf("Paypal") == -1 && chk_invoiceitempaymentype.indexOf("Braintree") == -1 && chk_invoiceitempaymentype.indexOf("Stripe") == -1) {
                document.getElementById("div_Delete_Invoice").style.display = "none";
                document.getElementById("div_Delete_JOb").style.display = "block";
                document.getElementById("divrad").style.display = "none";
                SetRadWindow('divrad', 'divBackGroundNew', '200');
                document.getElementById("div_Note").style.display = "block";
            }
            //else
            //if (chk_invoiceitempaymentype != undefined || chk_invoiceitempaymentype != null) {
            //if (IsSplitItem.toLowerCase() == 'false' && (chk_invoiceitempaymentype.indexOf("Credit Card") > -1 || chk_invoiceitempaymentype.indexOf("Braintree Credit Card") > -1)) {
            //    document.getElementById("div_Delete_Invoice").style.display = "none";
            //    document.getElementById("div_Delete_JOb").style.display = "block";
            //    document.getElementById("divrad").style.display = "none";
            //    SetRadWindow('divrad', 'divBackGroundNew', '200');
            //    document.getElementById("div_Note").style.display = "block";
            //}
            //else {
            //        var isAlreadyDeleted = false;
            //        if (EstType.toLowerCase() == "s" || EstType.toLowerCase() == "b" || EstType.toLowerCase() == "p" || EstType.toLowerCase() == "f" || EstType.toLowerCase() == "k" || EstType.toLowerCase() == "n" || EstType.toLowerCase() == "d" || EstType.toLowerCase() == "l") {
            //            if (InventoryManagement.toString().toLowerCase() == "im") {
            //                if (Module.toLowerCase() == "job" || Module.toLowerCase() == "invoice") {
            //                    if (ISInventoryReduced == 0 && (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p")) {
            //                        if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
            //                            item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
            //                            isAlreadyDeleted = true;
            //                        }
            //                    }
            //                    else if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "a") {
            //                        item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
            //                        isAlreadyDeleted = true;
            //                    }
            //                }
            //            }
            //        }
            //        if (EstType.toLowerCase() == 'c' || EstType.toLowerCase() == 'x') {
            //            if (ManageStockPermission == 1) {
            //                if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {
            //                    if (StockCancellationType.toString().toLowerCase() == "a") {
            //                        item_summary.WarehouseStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
            //                        isAlreadyDeleted = true;
            //                    }
            //                }
            //            }
            //        }
            //        if (isAlreadyDeleted == false) {
            //            item_summary.Estimate_Items_Delete(CompID, EstimateItemID, EstType, EstId, Module, itemTitle, false, Redirect);
            //        }
            //    }
            //}
            else {
                if (EstType.toLowerCase() == "s" || EstType.toLowerCase() == "b" || EstType.toLowerCase() == "p" || EstType.toLowerCase() == "f" || EstType.toLowerCase() == "k" || EstType.toLowerCase() == "n" || EstType.toLowerCase() == "r" || EstType.toLowerCase() == "d" || EstType.toLowerCase() == "l") {
                    if (InventoryManagement.toString().toLowerCase() == "im") {
                        if (Module.toLowerCase() == "job" || Module.toLowerCase() == "invoice") {
                            if (ISInventoryReduced == 0 && (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p")) {
                                if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
                                    item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                                    isAlreadyDeleted = true;
                                }
                            }
                            else if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "a") {
                                item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                                isAlreadyDeleted = true;
                            }
                        }
                    }
                }
                if (EstType.toLowerCase() == 'c' || EstType.toLowerCase() == 'x') {
                    if (ManageStockPermission == 1) {
                        if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {
                            if (StockCancellationType.toString().toLowerCase() == "a") {
                                item_summary.WarehouseStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                                isAlreadyDeleted = true;
                            }
                        }
                    }
                }
                if (isAlreadyDeleted == false) {
                    item_summary.Estimate_Items_Delete(CompID, EstimateItemID, EstType, EstId, Module, itemTitle, false, Redirect);
                }
            }
        }
        else if (PgtypeNew.toLowerCase() == "invoice") {

            if (typeof chk_invoiceitempaymentype != 'undefined' && chk_invoiceitempaymentype != undefined &&
                chk_invoiceitempaymentype != null && chk_invoiceitempaymentype.indexOf("Paypal") == -1 && chk_invoiceitempaymentype.indexOf("Braintree") == -1 && chk_invoiceitempaymentype.indexOf("Stripe") == -1) {
                document.getElementById("div_Delete_JOb").style.display = "none";
                document.getElementById("div_Delete_Invoice").style.display = "block";
                SetRadWindow('divrad', 'divBackGroundNew', '200');
                document.getElementById("div_Note").style.display = "block";
            }
            //else if (chk_invoiceitempaymentype != undefined || chk_invoiceitempaymentype != null) {
            //    if (IsSplitItem.toLowerCase() == 'false' && (chk_invoiceitempaymentype.indexOf("Credit Card") > -1 || chk_invoiceitempaymentype.indexOf("Braintree Credit Card") > -1)) {

            //        document.getElementById("div_Delete_JOb").style.display = "none";
            //        document.getElementById("div_Delete_Invoice").style.display = "block";
            //        SetRadWindow('divrad', 'divBackGroundNew', '200');
            //        document.getElementById("div_Note").style.display = "block";
            //    }
            //    else {
            //        var isAlreadyDeleted = false;
            //        if (EstType.toLowerCase() == "s" || EstType.toLowerCase() == "b" || EstType.toLowerCase() == "p" || EstType.toLowerCase() == "f" || EstType.toLowerCase() == "k" || EstType.toLowerCase() == "n" || EstType.toLowerCase() == "d" || EstType.toLowerCase() == "l") {
            //            if (InventoryManagement.toString().toLowerCase() == "im") {
            //                if (Module.toLowerCase() == "job" || Module.toLowerCase() == "invoice") {
            //                    if (ISInventoryReduced == 0 && (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p")) {
            //                        if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
            //                            item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
            //                            isAlreadyDeleted = true;
            //                        }
            //                    }
            //                    else if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "a") {

            //                        item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
            //                        isAlreadyDeleted = true;
            //                    }
            //                }
            //            }
            //        }
            //        if (EstType.toLowerCase() == 'c' || EstType.toLowerCase() == 'x') {
            //            if (ManageStockPermission == 1) {
            //                if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {
            //                    if (StockCancellationType.toString().toLowerCase() == "a") {
            //                        item_summary.WarehouseStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
            //                        isAlreadyDeleted = true;
            //                    }
            //                }
            //            }
            //        }
            //        if (isAlreadyDeleted == false) {
            //            item_summary.Estimate_Items_Delete(CompID, EstimateItemID, EstType, EstId, Module, itemTitle, false, Redirect);
            //        }
            //    }
            //}
            else {
                if (EstType.toLowerCase() == "s" || EstType.toLowerCase() == "b" || EstType.toLowerCase() == "p" || EstType.toLowerCase() == "f" || EstType.toLowerCase() == "k" || EstType.toLowerCase() == "n" || EstType.toLowerCase() == "r" || EstType.toLowerCase() == "d" || EstType.toLowerCase() == "l") {
                    if (InventoryManagement.toString().toLowerCase() == "im") {
                        if (Module.toLowerCase() == "job" || Module.toLowerCase() == "invoice") {
                            if (ISInventoryReduced == 0 && (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p")) {
                                if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
                                    item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                                    isAlreadyDeleted = true;
                                }
                            }
                            else if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "a") {

                                item_summary.InventoryStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                                isAlreadyDeleted = true;
                            }
                        }
                    }
                }
                if (EstType.toLowerCase() == 'c' || EstType.toLowerCase() == 'x') {
                    if (ManageStockPermission == 1) {
                        if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {
                            if (StockCancellationType.toString().toLowerCase() == "a") {
                                item_summary.WarehouseStockBackOn_itemDelete_EstOrder(CompID, EstId, EstimateItemID, UserID, EstType, Module, itemTitle, false, Redirect);
                                isAlreadyDeleted = true;
                            }
                        }
                    }
                }
                if (isAlreadyDeleted == false) {
                    item_summary.Estimate_Items_Delete(CompID, EstimateItemID, EstType, EstId, Module, itemTitle, false, Redirect);
                }
            }
        }
        hdndeleteparm.value = CompID + "," + EstimateItemID + "," + EstType + "," + EstId + "," + Module + "," + itemTitle + "," + JobId;

        var hdn_EstItemIDforPODEL_Delete = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdn_EstItemIDforPODEL_Delete");
        hdn_EstItemIDforPODEL_Delete.value = EstimateItemID;
    }
}
function sleep(milliseconds) {
    var start = new Date().getTime();
    while ((new Date().getTime() - start) < milliseconds) {
        // Do nothing
    }
}

function Estimate_Job_Invoice_delete() {
    debugger
    var hdn_ImgClosebtn = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdn_ImgClosebtn').value;
    document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_divLoadingImageCus").style.display = "block";
    var hdndeleteparm = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdndeleteparm");
    var param = hdndeleteparm.value;
    var parmeter = param.split(",");
    var CompID = parmeter[0]
    var EstimateItemID = parmeter[1]
    var EstType = parmeter[2]
    var EstId = parmeter[3]
    var Module = parmeter[4]
    var itemTitle = parmeter[5]
    var JobId = parmeter[6]
    var rdb_Delete_Job = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_rdb_Delete_Job");
    var rdb_Delete_Invoice = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_rdb_Delete_Invoice");

    var hdn_EstItemIDforPODEL_Delete = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdn_EstItemIDforPODEL_Delete");
    hdn_EstItemIDforPODEL_Delete.value = EstimateItemID;
    var Chk_DeletePO = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_Chk_DeletePO");
    var Chk_DeleteDN = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_Chk_DeleteDN");
    var KeepEstimateLive = false;

    if (EstType.toLowerCase() == "s" || EstType.toLowerCase() == "b" || EstType.toLowerCase() == "p" || EstType.toLowerCase() == "f" || EstType.toLowerCase() == "k" || EstType.toLowerCase() == "n" || EstType.toLowerCase() == "r" || EstType.toLowerCase() == "d" || EstType.toLowerCase() == "l") {
        if (InventoryManagement.toString().toLowerCase() == "im") {
            if (Module.toLowerCase() == "job" || Module.toLowerCase() == "invoice") {
                if (ISInventoryReduced == 0 && (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p")) {
                    if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
                        item_summary.InventoryStockBackOn_itemDelete(CompID, EstId, EstimateItemID, UserID);
                    }
                }
                else if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "a") {

                    item_summary.InventoryStockBackOn_itemDelete(CompID, EstId, EstimateItemID, UserID);
                }
            }
        }
    }
    if (EstType.toLowerCase() == 'c' || EstType.toLowerCase() == 'x') {
        if (ManageStockPermission == 1) {
            if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {
                if (StockCancellationType.toString().toLowerCase() == "a") {
                    item_summary.WarehouseStockBackOn_itemDelete(CompID, EstId, EstimateItemID, UserID);
                    //setTimeout(function () { item_summary.WarehouseStockBackOn_itemDelete(CompID, EstId, EstimateItemID, UserID); }, 5000);
                    sleep(3000);
                }
            }
        }
    }

    if (Module.toLowerCase() == "job") {
        if (rdb_Delete_Job.checked) {
            KeepEstimateLive = true;
        }
    }
    if (Module.toLowerCase() == "invoice") {
        if (rdb_Delete_Invoice.checked) {
            KeepEstimateLive = true;
        }
    }

    //item_summary.Estimate_Items_Delete(CompID, EstimateItemID, EstType, EstId, Module, itemTitle, KeepEstimateLive, Redirect);
    if (Module.toLowerCase() == "job") {
        var chk_invoiceitempaymentype = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_' + EstId + '_lblPaymentType').innerHTML;
    }
    else if (Module.toLowerCase() == "invoice") {
        var chk_invoiceitempaymentype = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_0_lblPaymentType').innerHTML;
    }
    if (hdn_ImgClosebtn == "true") {

        if (Chk_DeletePO.checked) {
            if (chk_invoiceitempaymentype != undefined || chk_invoiceitempaymentype != null) {
                if (chk_invoiceitempaymentype.indexOf("Paypal") > -1 || chk_invoiceitempaymentype.indexOf("Braintree") > -1 || chk_invoiceitempaymentype.indexOf("Stripe") > -1) {
                    item_summary.Delete_PODeliverynote_for_RevertJob(CompID, JobId, 1, 0, 'Main') //To delete whole PO and DN 
                }
                else {
                    item_summary.Delete_PODeliverynote_for_RevertJob(CompID, EstimateItemID, 1, 0, 'Item')
                }
            }
            else {
                item_summary.Delete_PODeliverynote_for_RevertJob(CompID, EstimateItemID, 1, 0, 'Item')
            }
        }
        if (Chk_DeleteDN.checked) {
            if (chk_invoiceitempaymentype != undefined || chk_invoiceitempaymentype != null) {
                if (chk_invoiceitempaymentype.indexOf("paypal") > -1 || chk_invoiceitempaymentype.indexOf("Braintree") > -1 || chk_invoiceitempaymentype.indexOf("Stripe") > -1) {
                    item_summary.Delete_PODeliverynote_for_RevertJob(CompID, JobId, 0, 1, 'Main') //To delete whole PO and DN 
                }
                else {
                    item_summary.Delete_PODeliverynote_for_RevertJob(CompID, EstimateItemID, 0, 1, 'Item')
                }
            }
            else {
                item_summary.Delete_PODeliverynote_for_RevertJob(CompID, EstimateItemID, 0, 1, 'Item')
            }
        }
    }
    item_summary.Estimate_Items_Delete(CompID, EstimateItemID, EstType, EstId, Module, itemTitle, KeepEstimateLive, Redirect);
    sleep(1000);
}

function Redirect(response) {
    var jID = "";
    var InvID = "";
    if (Number(jobID) != 0) {
        jID = "&jID=" + jobID;
    }
    if (Number(InvoiceID) != 0) {
        InvID = "&InvID=" + InvoiceID;
    }
    if (IsFromeStore == 'yes') {
        if (modulename == "orders") {
            window.location.href = strSitepath + modulename + "/" + submodulename + "_summary.aspx?suc=Del&estid=" + EstimateID + "&ordid=" + EstimateID + jID + InvID;
        }
        else {
            window.location.href = strSitepath + modulename + "/" + submodulename + "_order_summary.aspx?suc=Del&estid=" + EstimateID + "&ordid=" + EstimateID + jID + InvID;
        }
    }
    else {
        window.location.href = strSitepath + modulename + "/" + submodulename + "_summary_reeng.aspx?suc=Del&estid=" + EstimateID + jID + InvID;
    }
}
// Copy the Estimate Sumary Item


function EstimateItemsCopy(EstID, EstItemID, EstType, pg, ddlStatus) {

    var isStock_Reduce = 0;
    if ((hdbstatustitlesamecustomer.value.toLowerCase() == 'account on hold') && (Module == "job")) {
        //alert(AccoutnsOnHoldCopyjobToSameNewCust);
        alert(Accountsonhold);
        return false;
    }
    if ((hdbstatustitlesamecustomer.value.toLowerCase() == 'account on hold') && (Module == "estimate")) {
        //alert(AccoutnsOnHoldCopyestimateToSameNewCust);
        alert(Accountsonhold);
        return false;
    }
    if (EstType != 'O' && EstType != 'Q') {
        if (InventoryManagement.toString().toLowerCase() == "im") {
            if (Module.toLowerCase() == "invoice") {
                if (ReduceStockType.toLowerCase() != 'e' || ReduceStockType.toLowerCase() != 'i') {

                    ShowConfirmationMessage(EstID, EstItemID, pg, ddlStatus, EstType);
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                    document.getElementById('divBackGroundNew').style.display = 'block';
                } else {
                    document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_divLoadingImageCus").style.display = "block";
                    item_summary.Estimate_Items_Copy(EstID, EstItemID, EstType, pg, ddlStatus, isStock_Reduce, PageRedirct);
                }
            } else {
                document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_divLoadingImageCus").style.display = "block";
                item_summary.Estimate_Items_Copy(EstID, EstItemID, EstType, pg, ddlStatus, isStock_Reduce, PageRedirct);
            }
        } else {
            document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_divLoadingImageCus").style.display = "block";
            item_summary.Estimate_Items_Copy(EstID, EstItemID, EstType, pg, ddlStatus, isStock_Reduce, PageRedirct);
        }
    } else {
        document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_divLoadingImageCus").style.display = "block";
        item_summary.Estimate_Items_Copy(EstID, EstItemID, EstType, pg, ddlStatus, isStock_Reduce, PageRedirct);
    }
}
//13902
function ShowConfirmationMessage(EstimateID, ParentEstimateItemID, Module, ddlStatus, EstType) {
    var id = document.getElementById('div_AlertPopup');
    var str = "<table id='tbl_Popup'  cellpadding='0' cellspacing='0' width='35%' height='82%'>";
    str += "<tr>";
    str += "<td colspan='2' class='popup-top-leftcorner'></td><td class='popup-top-middlebg'><div  align='left' id='div_invoice_Popup' class=Label-PopupHeading style='float: right; padding-top: 6px; padding-right: 7px;'><div class='CancelButtonDiv2'><img src='" + strImagepath + "deleteicon3.png' title='Cancel' OnClick='javascript:CloseDiv_Popup_InventoryAlert();return false;'/></div></div></td><td colspan='2' class='popup-top-rightcorner'></td></tr>";
    str += "<tr>";
    str += "<td class='popup-middle-leftcorner'></td><td style='width: 15px; background-color: #ffffff'></td>";

    str += "<td class='popup-middlebg' align='center' valign='top'><table cellpadding='2' cellspacing='2' border='0' width='100%'><tr><td valign='top'><div id='div_Popup_Invoice'><div id='div_rdb_Popup_Invoice' style='float: left; padding-bottom: 7px;'><span style='font-weight: bold;'><label id='lbltxt_Popup' style='width:310px;margin-left:10px;margin-top:10px' Text=''> Do you want to reduce inventory stock ? </label></span></div><div style='clear: both'></div><div style='padding-top: 5px; float: left; padding-left: 3.2%; margin-left:100px;'><input type='button' id='btn_Yes' onclick=javascript:ItemCopy_InventoryAlert('" + EstimateID + "','" + ParentEstimateItemID + "','" + Module + "','" + ddlStatus + "',1,'" + EstType.trim() + "'); return false; class='button' value='Yes'/></div><div style='padding-top: 5px; float: left; padding-left: 3.2%;'><input type='button' id='btn_No' onclick=javascript:ItemCopy_InventoryAlert('" + EstimateID + "','" + ParentEstimateItemID + "','" + Module + "','" + ddlStatus + "',0,'" + EstType.trim() + "'); return false; class='button' value='No'/></div></div></td></tr></table></td>";
    str += "<td style='width: 10px; background-color: #ffffff'></td><td align='right' class='popup-middle-rightcorner'></td>";
    str += "</tr>";
    str += "<tr><td colspan='2' class='popup-bottom-leftcorner'></td><td class='popup-bottom-middlebg'></td><td colspan='2' class='popup-bottom-rightcorner'></td>";
    str += "</tr>";
    str += "</table>";
    id.innerHTML = str;
    id.style.display = 'block';
}

function CloseDiv_Popup_InventoryAlert() {
    document.getElementById('div_AlertPopup').style.display = "none"
    document.getElementById('divBackGroundNew').style.display = "none";
}


function ItemCopy_InventoryAlert(EstID, EstItemID, pg, ddlStatus, isStock_Reduce, EstType) {
    document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_divLoadingImageCus").style.display = "block";
    document.getElementById('div_AlertPopup').style.display = 'none';
    item_summary.Estimate_Items_Copy(EstID, EstItemID, EstType, pg, ddlStatus, isStock_Reduce, PageRedirct);
}

function PageRedirct(EstItemID) {
    if (EstItemID == 0) {
        alert("You can't copy this item as it has no stock quantity and back orders have not been allowed for it.");
        document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_divLoadingImageCus").style.display = "none";
        document.getElementById('divBackGroundNew').style.display = "none";
    } else if (IsFromeStore == 'yes') {
        if (modulename == "orders") {
            window.location.href = strSitepath + modulename + "/" + submodulename + "_summary.aspx?suc=copitem&estid=" + EstimateID + "&ordid=" + EstimateID + "&EstItemID=" + EstItemID + "";
        }
        else {
            window.location.href = strSitepath + modulename + "/" + submodulename + "_order_summary.aspx?suc=copitem&estid=" + EstimateID + "&ordid=" + EstimateID + "&EstItemID=" + EstItemID + "&jID=" + jobID + "&InvID=" + InvoiceID + "";
        }
    }
    else {
        window.location.href = strSitepath + modulename + "/" + submodulename + "_summary_reeng.aspx?suc=copitem&estid=" + EstimateID + "&EstItemID=" + EstItemID + "&jID=" + jobID + "&InvID=" + InvoiceID + "";
    }
}

// Invoice Paid Details view //
function PaymentDetails() {
    if (document.getElementById("div_ProgressToInvoice").style.display == "block") {

        //document.getElementById("div_ProgressToInvoice").style.width = 370 + "px";
        //document.getElementById("div_ProgressToInvoice").style.height = 175 + "px";

        var div_ProgressToInvoice = document.getElementById("div_ProgressToInvoice");
        var DivPaddingTop = document.getElementById("ctl00_ContentPlaceHolder1_DivPaddingTop");
        var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");
        var DivBtnPay = document.getElementById("DivBtnPay");
        //var DivProgressJobtoInvoice = document.getElementById("DivProgressJobtoInvoice");
        //var DivInvoicePayment = document.getElementById("DivInvoicePayment");
        //var DivPaymentDetails = document.getElementById("DivPaymentDetails");
        var div_JobStatus = document.getElementById("ctl00_ContentPlaceHolder1_div_JobStatus");
        var DivPayment_Dropdown = document.getElementById("DivPayment_Dropdown");
        var DivDate_Text = document.getElementById("DivDate_Text");
        var DivNotes_Text = document.getElementById("DivNotes_Text");
        //var div_lnkNotPaid = document.getElementById("div_lnkNotPaid");

        var txtAmountpaid = document.getElementById("DivNotes_Text");


        var div_HolderName = document.getElementById("div_HolderName");
        var div_CardType = document.getElementById("div_CardType");
        var div_CardNumber = document.getElementById("div_CardNumber");
        var div_MonthYear = document.getElementById("div_MonthYear");
        var div_VarificationNumber = document.getElementById("div_VarificationNumber");
        var div_VarificationText = document.getElementById("div_VarificationText");
        var div_MonthYearValue = document.getElementById("div_MonthYearValue");
        var div_CardNumberText = document.getElementById("div_CardNumberText");
        var div_CardTypeImg = document.getElementById("div_CardTypeImg");
        var div_holderNameText = document.getElementById("div_holderNameText");

        //var hdnPaymentMode = document.getElementById("hdnPaymentMode");

        //showDivPopupCenter('div_ProgressToInvoice', '320');        

        //DivPaymentDetails.style.display = "block";
        hdnHeader.value = "Payment Details";

        txtAmountpaid.style.display = "block";
        DivPayment_Dropdown.style.display = "block";
        DivDate_Text.style.display = "block";
        DivNotes_Text.style.display = "block";

        div_ProformaInvoice.style.display = "none";
        DivBtnPay.style.display = "none";
        //DivInvoicePayment.style.display = "none";
        // DivProgressJobtoInvoice.style.display = "none";       
        DivPaddingTop.style.display = "none";

        //need to check for link
        //div_lnkNotPaid.style.display = "block";       
        DivNotes_Value.style.display = "block";
        div_JobStatus.sytle.display = "none";

        if (hdnPaymentMode.value == "Credit Card") {
            div_CreditCardDetails.style.display = "block";
            div_HolderName.style.display = "block";
            div_CardType.style.display = "block";
            div_CardNumber.style.display = "block";
            div_MonthYear.style.display = "block";
            div_VarificationNumber.style.display = "block";
            div_VarificationText.style.display = "none";
            div_MonthYearValue.style.display = "none";
            div_CardNumberText.style.display = "none";
            div_CardTypeImg.style.display = "none";
            div_holderNameText.style.display = "none";
        }
        //setLoadingPositionOfDivMove(div_ProgressToInvoice);
        return false;
    }
    else {
        document.getElementById("div_ProgressToInvoice").style.display = "none";
        //document.getElementById("div_mask").style.display = "none";
        return false;
    }
}


function OnChange() {
    if (document.getElementById("div_ProgressToInvoice").style.display == "block") {
        //        document.getElementById("div_ProgressToInvoice").style.width = 430 + "px";
        //        document.getElementById("div_ProgressToInvoice").style.height = 180 + "px";
        var div_ProgressToInvoice = document.getElementById("div_ProgressToInvoice");
        // var IspaidQuestion = document.getElementById("IspaidQuestion");
        var div_ProformaInvoice = document.getElementById("div_ProformaInvoice");
        var PaidYesNo = document.getElementById("ctl00_ContentPlaceHolder1_PaidYesNo");
        var DivPaddingTop = document.getElementById("ctl00_ContentPlaceHolder1_DivPaddingTop");
        var DivBtnPay = document.getElementById("DivBtnPay");
        var divMessage = document.getElementById("ctl00_ContentPlaceHolder1_divMessage");
        var div_JobStatus = document.getElementById("ctl00_ContentPlaceHolder1_div_JobStatus");
        var div_invopmnt = document.getElementById("ctl00_ContentPlaceHolder1_div_invopmnt");
        var divUpdateMain = document.getElementById("ctl00_ContentPlaceHolder1_divUpdateMain");
        var divrecordpayment = document.getElementById("ctl00_ContentPlaceHolder1_divrecordpayment");
        var divbtnrecord = document.getElementById("ctl00_ContentPlaceHolder1_divbtnrecord");
        //var DivInvoicePayment = document.getElementById("DivInvoicePayment");
        //var DivPaymentDetails = document.getElementById("DivPaymentDetails");
        var DivPayment_Value = document.getElementById("DivPayment_Value");
        var DivDate_Value = document.getElementById("DivDate_Value");
        //var DivNotes_Value = document.getElementById("DivNotes_Value");

        //showDivPopupCenter('div_ProgressToInvoice', '320');     
        PaidYesNo.style.display = "none";
        div_JobStatus.style.display = "none";
        div_invopmnt.style.display = "block";
        divUpdateMain.style.display = "none";
        divrecordpayment.style.display = "none";
        divbtnrecord.style.display = "none";
        DivBtnPay.style.display = "none";
        divMessage.style.display = "block";
        //DivInvoicePayment.style.display = "block";
        hdnHeader.value = "Invoice Payment";
        //DivProgressJobtoInvoice.style.display = "none";
        //IspaidQuestion.style.display = "none";
        div_ProformaInvoice.style.display = "none";
        DivPaddingTop.style.display = "none";
        //DivPaymentDetails.style.display = "none";
        DivPayment_Value.style.display = "none";
        DivDate_Value.style.display = "none";
        DivNotes_Value.style.display = "none";
        return false;
    }
    else {
        document.getElementById("div_ProgressToInvoice").style.display = "none";
        //document.getElementById("div_mask").style.display = "none";
        return false;
    }
}


// STOCK ALERT WITH STATUS CHANGES UPDATE //

//var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
//var ddlStatusID = document.getElementById("<%=ddlStatus.ClientID %>");
//var ISInventoryReduced = '<%=ISInventoryReduced %>';
//var PgtypeNew = '<%=Pgtype %>';
//var InventoryManagement = '<%=InventoryManagement %>';

var frmDel = false;


//
//function reduceStockTypeForCancelled() {
var Status_ID;
var Status_Title;
function EstJobInvStatusSave(StatusID, StatusTitle, ModuleID) {
    // Removed for the ticket --> 13916 in V4.0.1

    //if (InventoryManagement.toString().toLowerCase() == "im") {
    //    if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {
    //        if (StatusTitle.toLowerCase() == "cancelled") {
    //            if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p" && hdnIsinventoryBack.value == "true") {
    //                if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
    //                    item_summary.StockBackOn_StatusUpdate(CompanyID, EstimateID, UserID, NoResponse);
    //                }
    //            }
    //        }
    //    }
    //}
    //if (ManageStockPermission == 1) {
    //    if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {
    //        if (StatusTitle.toLowerCase() == "cancelled") {
    //            if (StockCancellationType.toString().toLowerCase() == "a" && hdnIsProducttype.value == "true") {
    //                item_summary.WarehouseStockBackOn_StatusUpdate(CompanyID, EstimateID, UserID, NoResponse);
    //            }
    //        }
    //    }
    //}
    Status_ID = StatusID;
    var title = StatusTitle.split("ยง").join(" ")
    title = SpecialDecode(title);
    //    if (title.length > 25) {
    //        Status_Title = title.substring(0, 25) + "....";
    //    }
    //    else {
    Status_Title = title;
    //    }
    item_summary.UpdateStatus(CompanyID, EstimateID, StatusID, PgtypeNew, UserID, ModuleID, GetResult, onTimeout, onError);



    var value = $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_lblLockUnlock").text();

    if (LockStatusId == StatusID && value == "Lock Job") {

        LockUnlockJob(hdnJObID.value);
    }
    else if (UnLockStatusId == StatusID && value !== "Lock Job") {
        LockUnlockJob(hdnJObID.value);
    }

    ///Amin
}
function ProofStatusSave(StatusID, StatusTitle, ModuleID) {
    Status_ID = StatusID;
    var title = StatusTitle.split("ยง").join(" ")
    title = SpecialDecode(title);
    Status_Title = title;
    PgtypeNew = "proof";
    item_summary.UpdateProofStatus(CompanyID, StatusID, PgtypeNew, UserID, ModuleID, GetProofResult, onTimeout, onError);

}
function GetResult(result) {
    if (result) {
        var lbl_StatusMsg = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_lbl_UpdateMsg");

        var lblUpdateMsg = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_lblUpdateMsg");

        var Div_UpdateMsg = document.getElementById("Div_UpdateMsg");

        var hdnItems = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnItems");
        var Items = hdnItems.value.split('@');

        var lblStatus = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_lblStatusTitle");
        lblStatus.textContent = Status_Title;

        if (PgtypeNew == 'estimate') {
            lblUpdateMsg.style.display = "block";
            lblUpdateMsg.innerHTML = Estimate_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            for (i = 0; i < Items.length - 1; i++) {
                var hdnlock_staus = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnLock_" + Items[i] + "").value;
                var hdn_imgLock = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_imgLockStatus_" + Items[i] + "").style.display;
                if (hdnlock_staus.toLowerCase() == "false" && hdn_imgLock.toLowerCase() == "none") {
             //   if (hdnlock_staus.toLowerCase() == "false") {
                    var lblItemStatus = document.getElementById("lblItemStatus_" + Items[i] + "");
                    lblItemStatus.textContent = Status_Title;
                }
            }
            setTimeout("TakeOut()", 2000);
        }
        else if (PgtypeNew == 'job') {
            lblUpdateMsg.style.display = "block";
            lblUpdateMsg.innerHTML = Job_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            for (i = 0; i < Items.length - 1; i++) {
                var hdnlock_staus = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnLock_" + Items[i] + "").value;
                var hdn_imgLock = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_imgLockStatus_" + Items[i] + "").style.display;
                if (hdnlock_staus.toLowerCase() == "false" && hdn_imgLock.toLowerCase() == "none") {
                    var lblItemStatus = document.getElementById("lblItemStatus_" + Items[i] + "");
                    lblItemStatus.textContent = Status_Title;
                }
            }
            setTimeout("TakeOut()", 2000);
        }
        else if (PgtypeNew == 'invoice') {
            lblUpdateMsg.style.display = "block";
            lblUpdateMsg.innerHTML = Invoice_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            for (i = 0; i < Items.length - 1; i++) {
                var hdnlock_staus = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnLock_" + Items[i] + "").value;
                if (hdnlock_staus.toLowerCase() == "false") {
                    var lblItemStatus = document.getElementById("lblItemStatus_" + Items[i] + "");
                    lblItemStatus.textContent = Status_Title;
                }
            }
            setTimeout("TakeOut()", 2000);
        }
        else if (PgtypeNew == 'order') {
            lblUpdateMsg.style.display = "block";
            lblUpdateMsg.innerHTML = Order_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            for (i = 0; i < Items.length - 1; i++) {
                var hdnlock_staus = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnLock_" + Items[i] + "").value;
                var hdn_ApprovalStatus = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnapprovestatus_" + Items[i] + "").value; ``
                var hdn_imgLock = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_imgLockStatus_" + Items[i] + "").style.display;
              //  if (hdnlock_staus.toLowerCase() == "false" && hdn_imgLock.toLowerCase() == "none") {
                    if (hdnlock_staus.toLowerCase() == "false" && hdn_ApprovalStatus == "1" && hdn_imgLock.toLowerCase() == "none") {
                    var lblItemStatus = document.getElementById("lblItemStatus_" + Items[i] + "");
                    lblItemStatus.textContent = Status_Title;
                }
            }
            setTimeout("TakeOut()", 2000);
        }
        else if (PgtypeNew == 'proof') {
            lblUpdateMsg.style.display = "block";
            lblUpdateMsg.innerHTML = "Proof Status Updated Successfully";
            lblUpdateMsg.className = "msg-success";
            for (i = 0; i < Items.length - 1; i++) {
                //var hdnlock_staus = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnLock_" + Items[i] + "").value;
                //if (hdnlock_staus.toLowerCase() == "false") {
                    var lblItemStatus = document.getElementById("lblItemStatus_" + Items[i] + "");
                    lblItemStatus.textContent = Status_Title;
                //}
            }
            setTimeout("TakeOut()", 2000);
        //    window.location.reload();
        }

        return false;
    }
    else {
        alert("One or more products has an allocation quantity that is greater than the quantity on hand for that location. You need to add stock to the correct location to enable the allocation to be released.");
        //alert(Status_not_changed);
    }
}
function GetProofResult(result) {
    if (result) {
        var lbl_StatusMsg = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_UcCustomerDetail_" + EstimateID + "_lbl_UpdateMsg");

        var lblUpdateMsg = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_lblUpdateMsg");

        var Div_UpdateMsg = document.getElementById("Div_UpdateMsg");

        var hdnItems = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_hdnItems");
        var Items = hdnItems.value.split('@');

        var lblStatus = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_lblStatusTitle");
        lblStatus.textContent = Status_Title;

        if (PgtypeNew == 'proof') {
            lblUpdateMsg.style.display = "block";
            lblUpdateMsg.innerHTML = "Proof Status Updated Successfully";
            lblUpdateMsg.className = "msg-success";
            for (i = 0; i < Items.length - 1; i++) {
                //var hdnlock_staus = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnLock_" + Items[i] + "").value;
                //if (hdnlock_staus.toLowerCase() == "false") {
                var lblItemStatus = document.getElementById("lblItemStatus_" + Items[i] + "");
                lblItemStatus.textContent = Status_Title;
                //}
            }
            setTimeout("TakeOut()", 2000);
        //    window.location.reload();
        }

        return false;
    }
}

function onTimeout(request, context) { }
function onError(objError) { }

function TakeOut() {
    var Div_UpdateMsg = document.getElementById("Div_UpdateMsg");
    if (Div_UpdateMsg != null) {
        lblUpdateMsg.style.display = "none";
    }
}


function reduceStockTypeForCancelledNew1() {
    if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {
        if (InventoryManagement.toString().toLowerCase() == "im") {
            if (ReduceStockTypeForCancelledVal == "p" || ReduceStockTypeForCancelledVal == "P") {
                showDivPopupCenter('div_StockAlert', '200');
                frmDel = true;
                return false;
            }
        }
    }
    __doPostBack("ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcCustomerDetail_" + EstimateID + "$lnkEstItemDelete", '');
    return false;
}

//By Naveen for Induvidual Items
var EstimateItemID_Status = 0;
var Item_Title_Status = "";
function EstJobInvIduvidualItemStatuS_Update(sId, EstimateItemID, StatusTitle) { 
    var ItemStatusID = sId;
    var EstItemId = EstimateItemID;
    var Item_Title = "";
    var title = StatusTitle.split("ยง").join(" ")
    title = SpecialDecode(title);

    if (title.length > 25) {
        Item_Title = title.substring(0, 25) + "....";
    }
    else {
        Item_Title = title;
    }
    item_summary.EstJobInvIduvidualItemStatuS_Update(CompanyID, EstimateItemID, EstimateID, sId, PgtypeNew, GetResult_Item, onTimeout, onError);
    EstimateItemID_Status = EstimateItemID;
    Item_Title_Status = Item_Title;
}


function ProofItemStatuS_Update(sId, EstimateItemID, StatusTitle, ProofID, ProofItemID) {
    debugger;
    var ItemStatusID = sId;
    var EstItemId = EstimateItemID;
    var Item_Title = "";
    var title = StatusTitle.split("ยง").join(" ")
    title = SpecialDecode(title);

    if (title.length > 25) {
        Item_Title = title.substring(0, 25) + "....";
    }
    else {
        Item_Title = title;
    }
    PgtypeNew = "proof";
    item_summary.ProofItemStatuS_Update(CompanyID, EstimateItemID, sId, PgtypeNew, ProofID, ProofItemID, GetProofResult_Item, onTimeout, onError);
    EstimateItemID_Status = EstimateItemID + "_" + ProofItemID;
    Item_Title_Status = Item_Title;
}

function GetResult_Item(result) {
    debugger;
    var strresult = result.toString();
    if (strresult.split(',')[0].toLowerCase() == 'true') {
        var lblItemStatus = document.getElementById("lblItemStatus_" + EstimateItemID_Status);
        var lblMainStatus = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_lblStatusTitle");
        var lblUpdateMsg = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_lblUpdateMsg");
        if (PgtypeNew == 'estimate') {
            lblUpdateMsg.style.display = "block";
            lblItemStatus.textContent = Item_Title_Status;
            lblUpdateMsg.innerHTML = Estimate_Item_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            setTimeout("TakeOut()", 5000);
        }
        else if (PgtypeNew == 'job') {
            lblUpdateMsg.style.display = "block";
            lblItemStatus.textContent = Item_Title_Status;
            lblUpdateMsg.innerHTML = Job_Item_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            setTimeout("TakeOut()", 5000);
        }
        else if (PgtypeNew == 'invoice') {
            lblUpdateMsg.style.display = "block";
            lblItemStatus.textContent = Item_Title_Status;
            lblUpdateMsg.innerHTML = Invoice_Item_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            setTimeout("TakeOut()", 5000);
        }
        else if (PgtypeNew == 'order') {
            lblUpdateMsg.style.display = "block";
            lblItemStatus.textContent = Item_Title_Status;
            lblUpdateMsg.innerHTML = Order_Item_Status_Updated_Successfully;
            lblUpdateMsg.className = "msg-success";
            setTimeout("TakeOut()", 5000);
        }

        else if (PgtypeNew == 'proof') {
            lblUpdateMsg.style.display = "block";
            lblItemStatus.textContent = Item_Title_Status;
            lblUpdateMsg.innerHTML = "Proof item status updated successfully";
            lblUpdateMsg.className = "msg-success";
            setTimeout("TakeOut()", 5000);
        //    window.location.reload();
        }
        
        if (typeof strresult.split(',')[1] != 'undefined' && strresult.split(',')[1] != null) {
            if (Number(strresult.split(',')[1].trim()) != 0) {
                lblUpdateMsg.style.display = "block";
                lblUpdateMsg.innerHTML = Job_Status_Updated_Successfully;
                lblUpdateMsg.className = "msg-success";
                lblMainStatus.textContent = Item_Title_Status;
                setTimeout("TakeOut()", 2000);
            }
        }
    }
    else {
        alert("One or more products has an allocation quantity that is greater than the quantity on hand for that location. You need to add stock to the correct location to enable the allocation to be released.");
        //alert(Status_not_changed);
    }
}
function GetProofResult_Item(result) {
    debugger;
    var strresult = result.toString();
    if (strresult.split(',')[0].toLowerCase() == 'true') {
        var lblItemStatus = document.getElementById("lblItemStatus_" + EstimateItemID_Status);
        var lblMainStatus = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_lblStatusTitle");
        var lblUpdateMsg = document.getElementById("ctl00_ContentPlaceHolder1_UCProofSummaryMain_lblUpdateMsg");
        if (PgtypeNew == 'proof') {
            lblUpdateMsg.style.display = "block";
            lblItemStatus.textContent = Item_Title_Status;
            lblUpdateMsg.innerHTML = "Proof item status updated successfully";
            lblUpdateMsg.className = "msg-success";
            setTimeout("TakeOut()", 5000);
        //    window.location.reload();
        }

        if (typeof strresult.split(',')[1] != 'undefined' && strresult.split(',')[1] != null) {
            if (Number(strresult.split(',')[1].trim()) != 0) {
                lblUpdateMsg.style.display = "block";
                lblUpdateMsg.innerHTML = Job_Status_Updated_Successfully;
                lblUpdateMsg.className = "msg-success";
                lblMainStatus.textContent = Item_Title_Status;
                setTimeout("TakeOut()", 2000);
            }
        }
    }
}

function Save(val) {
    if (val == 'Y') {
        hdnReduceStockTypeForCancelled.value = "true";
        ISInventoryReduced = 1;

        if (frmDel == true) {
            __doPostBack("ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcCustomerDetail_" + ParentEstimateItemID + "$lnkEstItemDelete", '');
        }
        else {
            __doPostBack("ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcCustomerDetail_" + ParentEstimateItemID + "$lnkSaveStatus", '');
        }
        return false;
    }
    else {
        hdnReduceStockTypeForCancelled.value = "false";
        if (frmDel == true) {
            __doPostBack("ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcCustomerDetail_" + ParentEstimateItemID + "$lnkEstItemDelete", '');
        }
        else {

            __doPostBack("ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcCustomerDetail_" + ParentEstimateItemID + "$lnkSaveStatus", '');
        }
        return false;
    }
}
function validate_date() {


    //    CheckFinal = false;
    //    var txtInvoicePaymentDate = trim12(txtInvoicePaymentDateID.value);
    //    if (txtInvoicePaymentDate == '') {
    //        document.getElementById("spn_InvoicePaymentDaterfq").style.display = "block";
    //        CheckFinal = true;

    //    }
    //    else {
    //        document.getElementById("spn_InvoicePaymentDaterfq").style.display = "none";

    //    }

    //    if (ValidateForm(txtInvoicePaymentDateID, 'spn_InvoicePaymentDaterfq', DateFormat_stage) == false) {
    //        CheckFinal = true;

    //    }

    //    if (CheckFinal) {
    //        return false;
    //    }
    //    else {

    //    if (InventoryManagement.toString().toLowerCase() == "im") {
    //        if (PgtypeNew.toLowerCase() == "job") {

    //            if (StockAlert()) {
    //                document.getElementById("div_Load").style.display = "block";
    //                document.getElementById("div_ProgressToInvoice").style.display = "none";
    //                return true;
    //            }
    //            else {
    //                return false;
    //            }
    //        }
    //    }
    //    else {
    //        document.getElementById("div_Load").style.display = "block";
    //        document.getElementById("div_ProgressToInvoice_reeng").style.display = "none";
    //        return true;
    //}
    //        document.getElementById("div_Load").style.display = "block";
    //        document.getElementById("div_ProgressToInvoice").style.display = "none";
    //        return true;
    //    }

}


function UpateOrderStatus() {

}

var ImgLockOrUnlockID = '';
var LockOrUnlockValue = 0;

function LockSubTotal(EstTotalID, LockOrUnlock, LockOrUnlockID, EstimateID, EstimateItemID, EstType, QtyCount, SectionCount, isStay) {
    debugger;
    ImgLockOrUnlockID = LockOrUnlockID;
    if (document.getElementById(LockOrUnlockID).src.indexOf('lockopen') != -1) {
        LockOrUnlock = 1;
        LockOrUnlockValue = 1;
    }
    else {
        LockOrUnlock = 0;
        LockOrUnlockValue = 0;
    }
    document.getElementById(ImgLockOrUnlockID).src = '../images/loading9.gif';


    if (LockOrUnlockValue == 1) {
        document.getElementById(ImgLockOrUnlockID.replace('img_', 'hdn_IsSubTotalLocked_')).value = "true";
        CallSave_onLock(EstimateID, EstimateItemID, EstType, QtyCount, SectionCount, isStay);
        CallSave(EstimateID, EstimateItemID, EstType, QtyCount, SectionCount, 'stay');
        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcItemTotal_' + EstimateItemID + '$btnStay', '');
    }
    else {
        AutoFill.SubTotal_estimate_Lock_Unlock(EstTotalID, LockOrUnlock, onLockResponse, onLockTimeout, onLockError);
    }
}


function onLockTimeout(request, context) {

}
function onLockError(objError) {

}
//for web service

function onLockResponse(response) {
    debugger;
    var SubTotal1 = document.getElementById(ImgLockOrUnlockID.replace('img_', 'txtSubTotal1_'));
    var SubTotal2 = document.getElementById(ImgLockOrUnlockID.replace('img_', 'txtSubTotal2_'));
    var SubTotal3 = document.getElementById(ImgLockOrUnlockID.replace('img_', 'txtSubTotal3_'));
    var SubTotal4 = document.getElementById(ImgLockOrUnlockID.replace('img_', 'txtSubTotal4_'));

    var SubTotalppu1 = document.getElementById(ImgLockOrUnlockID.replace('img_', 'txtSubTotal_PricePerUnit1_'));
    var SubTotalppu2 = document.getElementById(ImgLockOrUnlockID.replace('img_', 'txtSubTotal_PricePerUnit2_'));
    var SubTotalppu3 = document.getElementById(ImgLockOrUnlockID.replace('img_', 'txtSubTotal_PricePerUnit3_'));
    var SubTotalppu4 = document.getElementById(ImgLockOrUnlockID.replace('img_', 'txtSubTotal_PricePerUnit4_'));

    var IsSubTotalLocked = document.getElementById(ImgLockOrUnlockID.replace('img_', 'hdn_IsSubTotalLocked_'));



    if (LockOrUnlockValue == 0) {
        document.getElementById(ImgLockOrUnlockID).src = '../images/lockopen.png';

        IsSubTotalLocked.value = "false";

        if (SubTotal1 != null && SubTotal1 != undefined) {
            SubTotal1.disabled = '';

        }
        if (SubTotal2 != null && SubTotal2 != undefined) {
            SubTotal2.disabled = '';
        }
        if (SubTotal3 != null && SubTotal3 != undefined) {
            SubTotal3.disabled = '';
        }
        if (SubTotal4 != null && SubTotal4 != undefined) {
            SubTotal4.disabled = '';
        }

        if (SubTotalppu1 != null && SubTotalppu1 != undefined) {
            SubTotalppu1.disabled = '';
        }
        if (SubTotalppu2 != null && SubTotalppu2 != undefined) {
            SubTotalppu2.disabled = '';
        }
        if (SubTotalppu3 != null && SubTotalppu3 != undefined) {
            SubTotalppu3.disabled = '';
        }
        if (SubTotalppu4 != null && SubTotalppu4 != undefined) {
            SubTotalppu4.disabled = '';
        }


    }
    else {
        //        document.getElementById(ImgLockOrUnlockID).src = '../images/lockclosed.png';
        //        IsSubTotalLocked.value = "true";
        //        if (SubTotal1 != null && SubTotal1 != undefined) {
        //            SubTotal1.disabled = 'disabled';
        //        }
        //        if (SubTotal2 != null && SubTotal2 != undefined) {
        //            SubTotal2.disabled = 'disabled';
        //        }
        //        if (SubTotal3 != null && SubTotal3 != undefined) {
        //            SubTotal3.disabled = 'disabled';
        //        }
        //        if (SubTotal4 != null && SubTotal4 != undefined) {
        //            SubTotal4.disabled = 'disabled';
        //        }
        //        __doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcItemTotal_' + EstimateItemID + '$btnStay', '');
    }

}


function OpenPrintandEmail() {
    debugger;
    hdnEmailselectOrnot.value = "email";
    if (Div_Print_Email.style.display == "none") {
        showDivPopupCenter('Div_Print_Email', '250');
    }
}

function OpenDeliveryNoteSelectItems() {
    //hdnEmailselectOrnot.value = "email";
    if (Div_Del_Select_Items.style.display == "none") {
        showDivPopupCenter('Div_Del_Select_Items', '250');
    }
}

function OpenProofApprovedEmail() {
    debugger;
    hdnEmailselectOrnot.value = "email";
    ProofApprovedEmail.value = "ProofApproved";
    showDivPopupCenter('Div_Print_Email', '250');

}



// valdation to copy new customer form the item_summary.js copied on 26-12-2012
function validate_estCopy() {

    var IsCorrect = false;
    //var module = Module;
    if (hdnStatusTitle.value.toLowerCase() == "account on hold" && Pgtype.toLowerCase() == "estimate") {
        //alert(AccoutnsOnHoldCopyestimateToSameNewCust);
        alert(Accountsonhold);
        IsCorrect = true;
    }
    if (hdnStatusTitle.value.toLowerCase() == "account on hold" && Pgtype.toLowerCase() == "job") {
        //alert(AccoutnsOnHoldCopyjobToSameNewCust);
        alert(Accountsonhold);
        IsCorrect = true;
    }

    if (CheckStringMandatory(txtName.value, 'spn_txtName')) {
        IsCorrect = true;
        document.getElementById("spn_txtName").innerHTML = 'Please select customer';

    }
    else {
        if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
            IsCorrect = true;
            document.getElementById("spn_txtName").style.display = "block";
            document.getElementById("spn_txtName").innerHTML = 'Please select valid customer';
        }
        else if (hid_CustName.value != txtName.value) {
            IsCorrect = true;
            document.getElementById("spn_txtName").style.display = "block";
            document.getElementById("spn_txtName").innerHTML = 'Please select valid customer';
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
    }

}

function ChkforSubitemLock(EstimateItemID, EstType, Sectionno, sectioncount) {
    debugger
    if (EstType == 'B' || EstType == 'K' || EstType == 'N' || EstType == 'R') {
        var islocked = 0;
        for (var i = 0; i < sectioncount; i++) {
            var SectNo = i;
            var hdn_IsSubTotalLocked = document.getElementById("hdn_IsSubTotalLocked_" + EstimateItemID + "_" + SectNo + "");
            if ((hdn_IsSubTotalLocked.value).toLowerCase() == 'true') {
                islocked = Number(islocked) + Number(1)
            }
        }
        if (islocked > Number(0)) {
            return window.confirm(" The item you are rerunning has a locked sub total field.\nAny changes in the items calculations will not reflect in the sub total field.");
        }
        else {
            return true;
        }
    }
    else {
        var hdn_IsSubTotalLocked = document.getElementById("hdn_IsSubTotalLocked_" + EstimateItemID + "_" + 0 + "");
        if (hdn_IsSubTotalLocked.value.toLowerCase() == 'true') {
            return window.confirm(" The item you are rerunning has a locked sub total field.\nAny changes in the items calculations will not reflect in the sub total field.");
        }
        else {
            return true;

        }
    }
}

//By Naveen for Item Status Lock and Unlock
function LockItemStatus(id, Module) {
    item_summary.LockItemStatus(id, Module, OnResponse_LockImg(id));
    document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnLock_" + id + "").value = "true";

    return false;
}

function UnLockItemStatus(id, Module) {
    item_summary.UnLockItemStatus(id, Module, OnResponse_UnlockImg(id));
    document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_hdnLock_" + id + "").value = "false";
    return false;
}

function OnResponse_LockImg(id) {
    var imglockopen = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_imgLockOpenStatus_' + id);
    var imglockClosed = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_imgLockStatus_' + id);
    imglockopen.style.display = "none";
    imglockClosed.style.display = "block";
}

function OnResponse_UnlockImg(id) {
    var imglockopen = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_imgLockOpenStatus_' + id);
    var imglockClosed = document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_imgLockStatus_' + id);
    imglockopen.style.display = "block";
    imglockClosed.style.display = "none";
}

/*function OpenJobAllocationPopUp(EstimateID, JobID, ParentEstimateItemID, Quantity, PriceCatalogueID, id) {
    debugger;
    var JobNo = document.getElementById(id).title;
    var RadWindow_Paid = window.radopen(strSitepath + "common/common_popup.aspx?type=productcatalogueitemstockhistory&action=edit&Module=job&PriceCatalogueID=" + PriceCatalogueID + "&JobNo=" + JobNo + "&EstItemID=" + ParentEstimateItemID + "&EstimateID=" + EstimateID + "&JobID=" + JobID + "&Qty=" + Quantity + "&ActionType=BackOrder", 1330, 520);
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    RadWindow_Paid.setSize(1330, 520);
    RadWindow_Paid.center();
}*/
function OpenJobAllocationPopUp(EstimateID, JobID, ParentEstimateItemID, Quantity, PriceCatalogueID, id) {
    debugger;
    var JobNo = document.getElementById(id).title;
    var RadWindow_Paid = window.radopen(strSitepath + "common/common_popup.aspx?type=stockedit&action=edit&id=" + PriceCatalogueID, 1330, 520);
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    RadWindow_Paid.setSize(1330, 520);
    RadWindow_Paid.center();
}

function AllocationPopUp(id) {
    var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=stockedit&action=edit&id=" + id, '1330', '520');
    SetRadWindow_Ver2('divrad', 'divBackGroundNew', '200');
    //SetRadWindow('divrad', 'divBackGroundNew', '200');
    Rad1Customer.setSize(1330, 520);
    Rad1Customer.center();
    Rad1Customer.id = "Radwindowstock";
}
function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
    var Div_Customer = document.getElementById(divMaskID);
    var divBackGroundNew = document.getElementById(divBackgroundID);

    if (document.getElementById(divMaskID).style.display == "none") {

        if (navigator.appName != "Microsoft Internet Explorer") {
            setLoadingPositionOfDivCenter_Ver2(Div_Customer);
        }
        showDivPopupCenter_Ver2(divMaskID);
    }
    else {
        showDivPopupCenter_Ver2(divMaskID);
    }
}

//function RadWinClose() {
//document.getElementById("Div_Customer").style.display = "none";
//document.getElementById("divBackGroundNew").style.display = "none";
//}

function OpenReplenishAllocationPopUp(EstimateID, JobID, EstimateItemID, ReplenishStatusID) {
    document.getElementById('ctl00_ContentPlaceHolder1_UCItemSummaryMain_Div_StatusList').style.display = 'none';
    var RadWindow_Replenish = window.radopen(strSitepath + "common/Common_ReplenishItemAllocation.aspx?EstimateID=" + EstimateID + "&JobID=" + JobID + "&EstimateItemID=" + EstimateItemID + "&ReplenishStatusID=" + ReplenishStatusID, 1330, 520);
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    RadWindow_Replenish.setSize(1330, 520);
    RadWindow_Replenish.center();

    $(".rwCloseButton").click(function () {
        alert("You have not replenished the stock so the job status has not been changed.");
    });

}

var IsInvoicePossible = true;
var IsAllocationExist = false;
function CheckInvoicePossible_SplitOff(EstID, ItemID, Type, JobID, SR_WhenStockReduced) {
    if (ServerName.toString().toLowerCase().indexOf('dmc') > -1) {
        OpenCreateInvoice(EstID, ItemID, Type, JobID);
    } else {
        IsAllocationExist = false;
        IsInvoicePossible = true;
        asyncState = false;
        if (IsInvoicePossible) {
            //AutoFill.CheckInvoicePossible(Number(JobID), Number(0), IsInvoicePossibleSelectedFromJob);
            if (IsInvoicePossible) {
                if (!IsAllocationExist && SR_WhenStockReduced == 'j') {
                    AutoFill.CheckAllocationExist(Number(JobID), Number(0), IsInvoiceAllocationExist);
                }
                OpenCreateInvoice(EstID, ItemID, Type, JobID);
            } else if (!IsInvoicePossible) {
                return false;
            }
        } else if (!IsInvoicePossible) {
            return false;
        }
    }
}

function IsInvoicePossibleSelectedFromJob(IsInvoicePossibleFromJob) {
    debugger;
    if (!IsInvoicePossibleFromJob) {
        IsInvoicePossible = false;
        alert('One or more products has an allocation quantity that is greater than the quantity on hand for that location. You need to add stock to the correct location to enable the allocation to be released.');
        return false;
    }
}

function IsInvoiceAllocationExist(Result_IsAllocationExist) {
    debugger;
    if (Result_IsAllocationExist) {
        // var ServerName = '<%=ServerName%>';
        if (ServerName != 'dmc' || ServerName != 'dmc2') {
            IsAllocationExist = true;
            alert('You have not reduced the stock of this product by changing the job status.\nIf you create an invoice for this record that will reduce the stock of the product.');
        }
    }
}

var Return_ISInvoiceCanCopy_result = true;
function CheckisInvoiceCopyPossible(InvoiceID) {
    asyncState = false;
    AutoFill.CheckisInvoiceCopyPossible(InvoiceID, ISInvoiceCanCopy);
    return Return_ISInvoiceCanCopy_result;
}

function ISInvoiceCanCopy(ISInvoiceCanCopy_result) {
    Return_ISInvoiceCanCopy_result = ISInvoiceCanCopy_result;
    if (!Return_ISInvoiceCanCopy_result) {
        alert("You can't copy this Invoice as it has no stock quantity and back orders have not been allowed for it.");
    }
    return Return_ISInvoiceCanCopy_result;
}

var Return_ISJobCanCopy_result = 'true';
function CheckJobCopyPossible(JobID) {
    asyncState = false;
    AutoFill.ClearHashTable();
    AutoFill.CheckJobCopyPossible(JobID, ISJobCanCopy);
    return Return_ISJobCanCopy_result;
}

function ISJobCanCopy(ISJobCanCopy_result) {
    Return_ISJobCanCopy_result = ISJobCanCopy_result;
    if (Return_ISJobCanCopy_result.toLowerCase().trim().indexOf("false") != -1) {
        alert("You can't copy this Job as it has no stock quantity and back orders have not been allowed for it.");
        Return_ISJobCanCopy_result = false;
    } else {
        Return_ISJobCanCopy_result = true;
    }


}

function LockUnlockJob(jobId) {

    var Status = false;
    var value = $("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_lblLockUnlock").text();


    if (value == "Lock Job") {

        Status = true;
        //document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_div_rerun").style.display = "none";  
        //document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_div_additems").style.display = "none"; 
        //document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_div_revert").style.display = "none"; 


    }
    else {

        Status = false;
        //$("#ctl00_ContentPlaceHolder1_UCItemSummaryMain_lblLocked").text("");
        //document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_div_rerun").style.display = "block";
        //document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_div_additems").style.display = "block";
        //document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_ucMore_div_revert").style.display = "block"; 

    }

    debugger;

    item_summary.PC_update_JobLocking_Status(jobId, Status, onLockingStatusChange);


}

///////////////////////
function getcost(EstimateItemID, ItemNo) {

    debugger;
    var _cost = document.getElementById("spnCostExMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    var _cost1 = document.getElementById("spnCostExMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    var _cost2 = document.getElementById("spnCostExMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    var _cost3 = document.getElementById("spnCostExMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    var cost = _cost.value.replace(/[^\d.-]/g, '');
    var cost1 = _cost1.value.replace(/[^\d.-]/g, '');
    var cost2 = _cost2.value.replace(/[^\d.-]/g, '');
    var cost3 = _cost3.value.replace(/[^\d.-]/g, '');

    var markup1 = document.getElementById("spnMarkupPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var markup2 = document.getElementById("spnMarkupPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var markup3 = document.getElementById("spnMarkupPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var markup4 = document.getElementById("spnMarkupPrice4_" + EstimateItemID + "_" + ItemNo + "");

    var costInMarkup1 = document.getElementById("spnCostInMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    var costInMarkup2 = document.getElementById("spnCostInMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    var costInMarkup3 = document.getElementById("spnCostInMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    var costInMarkup4 = document.getElementById("spnCostInMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    // var hdn_TaxID = document.getElementById("hdn_TaxID_" + EstimateItemID + "_" + ItemNo + "");
    //var hdn_TaxPercentage = document.getElementById("hdn_TaxPercentage_" + EstimateItemID + "_" + ItemNo + ""); //since only one tax% exists for all qty

    //var hdn_ProfitMarginPercentage1 = document.getElementById("hdn_ProfitMarginPercentage1_" + EstimateItemID + "_" + ItemNo + "");
    //var hdn_ProfitMarginPercentage2 = document.getElementById("hdn_ProfitMarginPercentage2_" + EstimateItemID + "_" + ItemNo + "");
    //var hdn_ProfitMarginPercentage3 = document.getElementById("hdn_ProfitMarginPercentage3_" + EstimateItemID + "_" + ItemNo + "");
    //var hdn_ProfitMarginPercentage4 = document.getElementById("hdn_ProfitMarginPercentage4_" + EstimateItemID + "_" + ItemNo + "");

    var hdn_ProfitMarginPrice1 = document.getElementById("hdn_ProfitMarginPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_ProfitMarginPrice2 = document.getElementById("hdn_ProfitMarginPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_ProfitMarginPrice3 = document.getElementById("hdn_ProfitMarginPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_ProfitMarginPrice4 = document.getElementById("hdn_ProfitMarginPrice4_" + EstimateItemID + "_" + ItemNo + "");

    var hdn_SubTotal1 = document.getElementById("hdn_SubTotal1_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_SubTotal2 = document.getElementById("hdn_SubTotal2_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_SubTotal3 = document.getElementById("hdn_SubTotal3_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_SubTotal4 = document.getElementById("hdn_SubTotal4_" + EstimateItemID + "_" + ItemNo + "");
    
    var hdn_GrossProfitPercentage1 = document.getElementById("hdn_GrossProfitPercentage1_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_GrossProfitPercentage2 = document.getElementById("hdn_GrossProfitPercentage2_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_GrossProfitPercentage3 = document.getElementById("hdn_GrossProfitPercentage3_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_GrossProfitPercentage4 = document.getElementById("hdn_GrossProfitPercentage4_" + EstimateItemID + "_" + ItemNo + "");

    var hdn_GrossProfitPrice1 = document.getElementById("hdn_GrossProfitPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_GrossProfitPrice2 = document.getElementById("hdn_GrossProfitPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_GrossProfitPrice3 = document.getElementById("hdn_GrossProfitPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_GrossProfitPrice4 = document.getElementById("hdn_GrossProfitPrice4_" + EstimateItemID + "_" + ItemNo + "");

    var hdn_CostExMarkup1 = document.getElementById("hdn_CostExMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_CostExMarkup2 = document.getElementById("hdn_CostExMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_CostExMarkup3 = document.getElementById("hdn_CostExMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_CostExMarkup4 = document.getElementById("hdn_CostExMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    var hdn_CostInMarkup1 = document.getElementById("hdn_CostInMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_CostInMarkup2 = document.getElementById("hdn_CostInMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_CostInMarkup3 = document.getElementById("hdn_CostInMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_CostInMarkup4 = document.getElementById("hdn_CostInMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    if (!isNaN(markup1.innerText.replace(/[^\d.-]/g, '')) && Number(markup1.innerText.replace(/[^\d.-]/g, '')) > 0) {
        markup1 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup1.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    }
    else {
        markup1 = "0.00";
    }

    if (!isNaN(markup2.innerText.replace(/[^\d.-]/g, '')) && Number(markup2.innerText.replace(/[^\d.-]/g, '')) > 0) {
        markup2 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup2.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    }
    else {
        markup2 = "0.00";
    }
    if (!isNaN(markup3.innerText.replace(/[^\d.-]/g, '')) && Number(markup3.innerText.replace(/[^\d.-]/g, '')) > 0) {
        markup3 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup3.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    }
    else {
        markup3 = "0.00";
    }
    if (!isNaN(markup4.innerText.replace(/[^\d.-]/g, '')) && Number(markup4.innerText.replace(/[^\d.-]/g, '')) > 0) {
        markup4 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup4.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    }
    else {
        markup4 = "0.00";
    }



    if (!isNaN(cost) && Number(cost) > 0) {
        cost = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost), 0, '', false, false, false);
    }
    else {
        cost = "0.00";
    }

    if (!isNaN(cost1) && Number(cost1) > 0) {
        cost1 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1), 0, '', false, false, false);
    }
    else {
        cost1 = "0.00";
    }
    if (!isNaN(cost2) && Number(cost2) > 0) {
        cost2 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2), 0, '', false, false, false);
    }
    else {
        cost2 = "0.00";
    }
    if (!isNaN(cost3) && Number(cost3) > 0) {
        cost3 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3), 0, '', false, false, false);
    }
    else {
        cost3 = "0.00";
    }

    hdn_CostExMarkup1.value = cost;
    hdn_CostExMarkup2.value = cost1;
    hdn_CostExMarkup3.value = cost2;
    hdn_CostExMarkup4.value = cost3;

    var ddlprofitmarginvalue1 = Number(document.getElementById("txtProfitMarginPercentage1_" + EstimateItemID + "_" + ItemNo + "").value);
    var ddlprofitmarginvalue2 = Number(document.getElementById("txtProfitMarginPercentage2_" + EstimateItemID + "_" + ItemNo + "").value);
    var ddlprofitmarginvalue3 = Number(document.getElementById("txtProfitMarginPercentage3_" + EstimateItemID + "_" + ItemNo + "").value);
    var ddlprofitmarginvalue4 = Number(document.getElementById("txtProfitMarginPercentage4_" + EstimateItemID + "_" + ItemNo + "").value);

    var txtproftimarge = document.getElementById("txtProfitMarginPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var txtproftimarge1 = document.getElementById("txtProfitMarginPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var txtproftimarge2 = document.getElementById("txtProfitMarginPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var txtproftimarge3 = document.getElementById("txtProfitMarginPrice4_" + EstimateItemID + "_" + ItemNo + "");

    costInMarkup1.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup1) + Number(cost), 0, '', false, false, false), true);
    costInMarkup2.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup2) + Number(cost1), 0, '', false, false, false), true);
    costInMarkup3.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup3) + Number(cost2), 0, '', false, false, false), true);
    costInMarkup4.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(markup4) + Number(cost3), 0, '', false, false, false), true);

    hdn_CostInMarkup1.value = costInMarkup1.innerText.replace(/[^\d.-]/g, '');
    hdn_CostInMarkup2.value = costInMarkup2.innerText.replace(/[^\d.-]/g, '');
    hdn_CostInMarkup3.value = costInMarkup3.innerText.replace(/[^\d.-]/g, '');
    hdn_CostInMarkup4.value = costInMarkup4.innerText.replace(/[^\d.-]/g, '');


    txtproftimarge.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost) * Number(ddlprofitmarginvalue1) / 100, 0, '', false, false, false);
    txtproftimarge1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1) * Number(ddlprofitmarginvalue2) / 100, 0, '', false, false, false);
    txtproftimarge2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2) * Number(ddlprofitmarginvalue3) / 100, 0, '', false, false, false);
    txtproftimarge3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3) * Number(ddlprofitmarginvalue4) / 100, 0, '', false, false, false);

    hdn_ProfitMarginPrice1.value = txtproftimarge.value;
    hdn_ProfitMarginPrice2.value = txtproftimarge1.value;
    hdn_ProfitMarginPrice3.value = txtproftimarge2.value;
    hdn_ProfitMarginPrice4.value = txtproftimarge3.value;



    var txtsubtotal = document.getElementById("txtSubTotal1_" + EstimateItemID + "_" + ItemNo + "");
    var txtsubtotal1 = document.getElementById("txtSubTotal2_" + EstimateItemID + "_" + ItemNo + "");
    var txtsubtotal2 = document.getElementById("txtSubTotal3_" + EstimateItemID + "_" + ItemNo + "");
    var txtsubtotal3 = document.getElementById("txtSubTotal4_" + EstimateItemID + "_" + ItemNo + "");


    txtsubtotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost) + Number(txtproftimarge.value), 0, '', false, false, false);
    txtsubtotal1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1) + Number(txtproftimarge1.value), 0, '', false, false, false);
    txtsubtotal2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2) + Number(txtproftimarge2.value), 0, '', false, false, false);
    txtsubtotal3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3) + Number(txtproftimarge3.value), 0, '', false, false, false);

    hdn_SubTotal1.value = txtsubtotal.value;
    hdn_SubTotal2.value = txtsubtotal1.value;
    hdn_SubTotal3.value = txtsubtotal2.value;
    hdn_SubTotal4.value = txtsubtotal3.value;

    var txtsellingprice = document.getElementById("spnSellingPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var txtsellingprice1 = document.getElementById("spnSellingPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var txtsellingprice2 = document.getElementById("spnSellingPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var txtsellingprice3 = document.getElementById("spnSellingPrice4_" + EstimateItemID + "_" + ItemNo + "");

    var lbltax = document.getElementById("spnTaxPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var lbltax1 = document.getElementById("spnTaxPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var lbltax2 = document.getElementById("spnTaxPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var lbltax3 = document.getElementById("spnTaxPrice4_" + EstimateItemID + "_" + ItemNo + "");


    txtsellingprice.innerText = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost) * ddlprofitmarginvalue1) / 100 + Number(cost) + Number(lbltax.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    txtsellingprice1.innerText = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost1) * ddlprofitmarginvalue2) / 100 + Number(cost1) + Number(lbltax1.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    txtsellingprice2.innerText = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost2) * ddlprofitmarginvalue3) / 100 + Number(cost2) + Number(lbltax2.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    txtsellingprice3.innerText = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost3) * ddlprofitmarginvalue4) / 100 + Number(cost3) + Number(lbltax3.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false);
    
    var spnGrossProfitPrice1 = document.getElementById("spnGrossProfitPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var spnGrossProfitPrice2 = document.getElementById("spnGrossProfitPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var spnGrossProfitPrice3 = document.getElementById("spnGrossProfitPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var spnGrossProfitPrice4 = document.getElementById("spnGrossProfitPrice4_" + EstimateItemID + "_" + ItemNo + "");


    var spnGrossProfitPercentage1 = document.getElementById("spnGrossProfitPercentage1_" + EstimateItemID + "_" + ItemNo + "");
    var spnGrossProfitPercentage2 = document.getElementById("spnGrossProfitPercentage2_" + EstimateItemID + "_" + ItemNo + "");
    var spnGrossProfitPercentage3 = document.getElementById("spnGrossProfitPercentage3_" + EstimateItemID + "_" + ItemNo + "");
    var spnGrossProfitPercentage4 = document.getElementById("spnGrossProfitPercentage4_" + EstimateItemID + "_" + ItemNo + "");

    if (!isNaN(txtsubtotal.value) && Number(txtsubtotal.value) > 0) {
        var GrossPercentage1 = 0;
        var GrossValue1 = GrossProfit_Value(Number(cost), Number(txtsubtotal.value));
        if (Number(txtsubtotal.value) != "0") {
            spnGrossProfitPrice1.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue1, 0, '', false, false, false);

            GrossPercentage1 = GrossProfit_Percentage(Number(txtsubtotal.value), Number(GrossValue1));
            GrossPercentage1 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage1, 0, '', false, false, false);
            spnGrossProfitPercentage1.innerHTML = "" + GrossPercentage1 + "%";

            hdn_GrossProfitPrice1.value = spnGrossProfitPrice1.innerHTML.replace(/[^\d.-]/g, '');
            hdn_GrossProfitPercentage1.value = spnGrossProfitPercentage1.innerHTML.replace(/[^\d.-]/g, '');
        }
    }

    if (!isNaN(txtsubtotal1.value) && Number(txtsubtotal1.value) > 0) {
        var GrossPercentage2 = 0;
        var GrossValue2 = GrossProfit_Value(Number(cost1), Number(txtsubtotal1.value));
        if (Number(txtsubtotal1.value) != "0") {
            spnGrossProfitPrice2.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue2, 0, '', false, false, false);

            GrossPercentage2 = GrossProfit_Percentage(Number(txtsubtotal1.value), Number(GrossValue2));
            GrossPercentage2 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage2, 0, '', false, false, false);
            spnGrossProfitPercentage2.innerHTML = "" + GrossPercentage2 + "%";

            hdn_GrossProfitPrice2.value = spnGrossProfitPrice2.innerHTML.replace(/[^\d.-]/g, '');
            hdn_GrossProfitPercentage2.value = spnGrossProfitPercentage2.innerHTML.replace(/[^\d.-]/g, '');
        }
    }

    if (!isNaN(txtsubtotal2.value) && Number(txtsubtotal2.value) > 0) {
        var GrossPercentage3 = 0;
        var GrossValue3 = GrossProfit_Value(Number(cost2), Number(txtsubtotal2.value));
        if (Number(txtsubtotal2.value) != "0") {
            spnGrossProfitPrice3.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue3, 0, '', false, false, false);

            GrossPercentage3 = GrossProfit_Percentage(Number(txtsubtotal2.value), Number(GrossValue3));
            GrossPercentage3 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage3, 0, '', false, false, false);
            spnGrossProfitPercentage3.innerHTML = "" + GrossPercentage3 + "%";

            hdn_GrossProfitPrice3.value = spnGrossProfitPrice3.innerHTML.replace(/[^\d.-]/g, '');
            hdn_GrossProfitPercentage3.value = spnGrossProfitPercentage3.innerHTML.replace(/[^\d.-]/g, '');
        }
    }

    if (!isNaN(txtsubtotal3.value) && Number(txtsubtotal3.value) > 0) {
        var GrossPercentage4 = 0;
        var GrossValue4 = GrossProfit_Value(Number(cost3), Number(txtsubtotal3.value));
        if (Number(txtsubtotal3.value) != "0") {
            spnGrossProfitPrice4.innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossValue4, 0, '', false, false, false);

            GrossPercentage4 = GrossProfit_Percentage(Number(txtsubtotal3.value), Number(GrossValue4));
            GrossPercentage4 = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, GrossPercentage4, 0, '', false, false, false);
            spnGrossProfitPercentage4.innerHTML = "" + GrossPercentage4 + "%";

            hdn_GrossProfitPrice4.value = spnGrossProfitPrice4.innerHTML.replace(/[^\d.-]/g, '');
            hdn_GrossProfitPercentage4.value = spnGrossProfitPercentage4.innerHTML.replace(/[^\d.-]/g, '');
        }
    }


    var ddltax = document.getElementById("ddlTax_" + EstimateItemID + "_" + ItemNo + "");
    //gettaxvalue(Number(ddltax.options[ddltax.selectedIndex].value));
    gettaxvalue(ddltax.value, EstimateItemID, ItemNo);
}

function gettaxvalue(taxValue, EstimateItemID, ItemNo) {
    //alert(taxValue);
    //var tax = GetTaxValueNew(taxValue);
    var tax = taxValue;
    if (tax != '') {
        tax = Number(tax.split('~')[1]);
        //alert(tax);
    }
    var lbltax = document.getElementById("spnTaxPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var lbltax1 = document.getElementById("spnTaxPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var lbltax2 = document.getElementById("spnTaxPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var lbltax3 = document.getElementById("spnTaxPrice4_" + EstimateItemID + "_" + ItemNo + "");
    var ddlprofitmarginvalue1 = Number(document.getElementById("txtProfitMarginPercentage1_" + EstimateItemID + "_" + ItemNo + "").value);
    var txtsellingprice = document.getElementById("spnSellingPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var txtsellingprice1 = document.getElementById("spnSellingPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var txtsellingprice2 = document.getElementById("spnSellingPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var txtsellingprice3 = document.getElementById("spnSellingPrice4_" + EstimateItemID + "_" + ItemNo + "");
    var cost = document.getElementById("spnCostExMarkup1_" + EstimateItemID + "_" + ItemNo + "");
    var cost1 = document.getElementById("spnCostExMarkup2_" + EstimateItemID + "_" + ItemNo + "");
    var cost2 = document.getElementById("spnCostExMarkup3_" + EstimateItemID + "_" + ItemNo + "");
    var cost3 = document.getElementById("spnCostExMarkup4_" + EstimateItemID + "_" + ItemNo + "");

    var txtsubtotal = document.getElementById("txtSubTotal1_" + EstimateItemID + "_" + ItemNo + "");
    var txtsubtotal1 = document.getElementById("txtSubTotal2_" + EstimateItemID + "_" + ItemNo + "");
    var txtsubtotal2 = document.getElementById("txtSubTotal3_" + EstimateItemID + "_" + ItemNo + "");
    var txtsubtotal3 = document.getElementById("txtSubTotal4_" + EstimateItemID + "_" + ItemNo + "");

    var hdn_TaxPrice1 = document.getElementById("hdn_TaxPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_TaxPrice2 = document.getElementById("hdn_TaxPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_TaxPrice3 = document.getElementById("hdn_TaxPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_TaxPrice4 = document.getElementById("hdn_TaxPrice4_" + EstimateItemID + "_" + ItemNo + "");

    var hdn_SellingPrice1 = document.getElementById("hdn_SellingPrice1_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_SellingPrice2 = document.getElementById("hdn_SellingPrice2_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_SellingPrice3 = document.getElementById("hdn_SellingPrice3_" + EstimateItemID + "_" + ItemNo + "");
    var hdn_SellingPrice4 = document.getElementById("hdn_SellingPrice4_" + EstimateItemID + "_" + ItemNo + "");

    //cost.value = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost.value), 0, '', false, false, false), true);
    //cost1.value = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1.value), 0, '', false, false, false), true);
    //cost2.value = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2.value), 0, '', false, false, false), true);
    //cost3.value = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3.value), 0, '', false, false, false), true);


    lbltax.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal.value) * Number(tax)) / 100, 0, '', false, false, false), true);
    lbltax1.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal1.value) * Number(tax)) / 100, 0, '', false, false, false), true);
    lbltax2.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal2.value) * Number(tax)) / 100, 0, '', false, false, false), true);
    lbltax3.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal3.value) * Number(tax)) / 100, 0, '', false, false, false), true);

    hdn_TaxPrice1.value = lbltax.innerText.replace(/[^\d.-]/g, '');
    hdn_TaxPrice2.value = lbltax1.innerText.replace(/[^\d.-]/g, '');
    hdn_TaxPrice3.value = lbltax2.innerText.replace(/[^\d.-]/g, '');
    hdn_TaxPrice4.value = lbltax3.innerText.replace(/[^\d.-]/g, '');


    var ddlprofitmarginvalue = Number(ddlprofitmarginvalue1);
    txtsellingprice.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost.value.replace(/[^\d.-]/g, '')) * ddlprofitmarginvalue) / 100 + Number(cost.value.replace(/[^\d.-]/g, '')) + Number(lbltax.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false), true);
    txtsellingprice1.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost1.value.replace(/[^\d.-]/g, '')) * ddlprofitmarginvalue) / 100 + Number(cost1.value.replace(/[^\d.-]/g, '')) + Number(lbltax1.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false), true);
    txtsellingprice2.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost2.value.replace(/[^\d.-]/g, '')) * ddlprofitmarginvalue) / 100 + Number(cost2.value.replace(/[^\d.-]/g, '')) + Number(lbltax2.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false), true);
    txtsellingprice3.innerText = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost3.value.replace(/[^\d.-]/g, '')) * ddlprofitmarginvalue) / 100 + Number(cost3.value.replace(/[^\d.-]/g, '')) + Number(lbltax3.innerText.replace(/[^\d.-]/g, '')), 0, '', false, false, false), true);

    hdn_SellingPrice1.value = txtsellingprice.innerText.replace(/[^\d.-]/g, '');
    hdn_SellingPrice2.value = txtsellingprice1.innerText.replace(/[^\d.-]/g, '');
    hdn_SellingPrice3.value = txtsellingprice2.innerText.replace(/[^\d.-]/g, '');
    hdn_SellingPrice4.value = txtsellingprice3.innerText.replace(/[^\d.-]/g, '');
}
//////////////////////


function onLockingStatusChange(result) {

    debugger;

    __doPostBack("ctl00$ContentPlaceHolder1$UCItemSummaryMain$UCItemSummaryMain_" + "$lblLocked", '');
}

function get_Proof_History(attachmentID) {
    item_summary.Get_Proof_History(attachmentID, proofHistoryResult, onTimeout, onError);
}
function proofHistoryResult(result) {
    if (result) {
        var strTax = result.split('ยง');


    }
}