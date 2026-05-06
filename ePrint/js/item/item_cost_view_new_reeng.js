// JScript File

var $TxtMarkUp = '';
var $lblSellingPrice = '';
var $hdnSellingPrice = '';
var $hdnMarkupPrice = '';
var $hdnCostExMarkup = '';
var $hdnCostExMarkupActual = '';
var $hdnMinimumCharge = '';
var $hdnSetUpCost = '';
var $hdnEstimateCalculationID = '';
var $lblMarkupPrice = '';
var $hdnPressType = '';
var $td_PressCostView_Totalsellingprice = '';


function roundNumber(rnum, rlength) {

    return rnum;
}
//

function MarkupOnBlur_Paper(Obj) {
    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));
    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));
    var CostExMarkup = hdn_CostExMarkup.value;
    var Markup = txt_Markup.value;
    var MarkupPrice = (Number(CostExMarkup) * Number(Markup)) / 100;
    var SellingPrice = Number(CostExMarkup) + Number(MarkupPrice);


    hdn_SellingPrice.value = SellingPrice;
    hdn_MarkupPrice.value = MarkupPrice;

    var finalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, true);
    lbl_SellingPrice.innerHTML = finalValue;
    lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupPrice, 0, '', false, false, true);
    // alert(lbl_SellingPrice.innerHTML);
}

function MarkupOnBlur_Press(Obj) {

    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));
    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var hdn_CostExMarkup_Actual = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup_Actual'));
    //Extra for press
    var hdn_MinimumCharge = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MinimumCharge'));
    var hdn_SetUpCost = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SetUpCost'));
    var hdn_EstimateCalculationID = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_EstimateCalculationID'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));

    var hdnPressType = document.getElementById(Obj.id.replace('txt_Markup', 'hdnPressType'));

    var CostExMarkup = hdn_CostExMarkup_Actual.value;
    var Markup = txt_Markup.value;
    var SetupChargeForZone = "0";
    if (hdnPressType.value == 'z' || hdnPressType.value == 'Z') {
        SetupChargeForZone = hdn_SetUpCost.value;
        hdn_SetUpCost.value = 0;
    }

    //   var SellingPrice = Eprint_GetminimumCost_ComparedtoCostwithMarkup(Number(CostExMarkup) - Number(hdn_SetUpCost.value), Number(Markup), Number(hdn_MinimumCharge.value), '', '', Number(hdn_SetUpCost.value));



    var MarkupPrice = (Number(CostExMarkup - hdn_SetUpCost.value) * Number(Markup)) / 100;




    var totalcost = 0;
    var SellingPrice = 0;
    totalcost = Number(CostExMarkup - hdn_SetUpCost.value) + MarkupPrice + Number(hdn_SetUpCost.value);



    if (Number(hdn_MinimumCharge.value) >= Number(totalcost) + Number(SetupChargeForZone)) {
        SellingPrice = Number(hdn_MinimumCharge.value);
        hdn_CostExMarkup.value = hdn_MinimumCharge.value;
        hdn_MarkupPrice.value = "0";
    }
    else {
        SellingPrice = Number(totalcost);
        hdn_CostExMarkup.value = Number(totalcost) - MarkupPrice;
        hdn_MarkupPrice.value = MarkupPrice;
    }





    hdn_CostExMarkup_Actual.value = Number(totalcost) - MarkupPrice;
    hdn_SellingPrice.value = SellingPrice;


    var finalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, true);
    lbl_SellingPrice.innerHTML = finalValue;
    lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupPrice, 0, '', false, false, true);

    //     if (hdnPressType.value == 'z' || hdnPressType.value == 'Z')
    //     {
    // var hdn_qty = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_qty'));
    //  var lbl_PricePerUnitofMeasure = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_PricePerUnitofMeasure'));
    //   lbl_PricePerUnitofMeasure.innerHTML = finalValue + ' per ' + hdn_qty.value;
    // }

    //   alert(lbl_SellingPrice.innerHTML);


    if (hdnPressType.value == 'z' || hdnPressType.value == 'Z') {
        hdn_SetUpCost.value = SetupChargeForZone;
    }


}

function MarkupOnBlur_Press_ClickChargeZoneLookUp(Obj) {
    var ToatlSellingPrice = 0;
    for (var i = 0; i < $TxtMarkUp.length; i++) {
        if (isZdoubleside == 'yes' && i == 0) {
            ToatlSellingPrice = 0;
        }
        else if (isZdoubleside == 'yes' && i == 2) {
            ToatlSellingPrice = 0;
        }
        else if (isZdoubleside == 'yes' && i == 4) {
            ToatlSellingPrice = 0;
        }
        else if (isZdoubleside == 'yes' && i == 6) {
            ToatlSellingPrice = 0;
        }
        else if (isZdoubleside == 'no') {
            ToatlSellingPrice = 0;
        }

        var txt_Markup = $($TxtMarkUp[i]).val();
        var lbl_SellingPrice = $($lblSellingPrice[i]).text();
        var hdn_SellingPrice = $($hdnSellingPrice[i]).val();
        var hdn_MarkupPrice = $($hdnMarkupPrice[i]).val();
        var hdn_CostExMarkup = $($hdnCostExMarkup[i]).val();
        var hdn_CostExMarkup_Actual = $($hdnCostExMarkupActual[i]).val();
        var hdn_MinimumCharge = $($hdnMinimumCharge[i]).val();
        var hdn_SetUpCost = $($hdnSetUpCost[i]).val();
        var hdn_EstimateCalculationID = $($hdnEstimateCalculationID[i]).val();
        var lbl_MarkupPrice = $($lblMarkupPrice[i]).text();
        var hdnPressType = $($hdnPressType[i]).val();


        var CostExMarkup = hdn_CostExMarkup_Actual;
        var Markup = txt_Markup; //txt_Markup.value;
        var SetupChargeForZone = "0";
        if (hdnPressType == 'z' || hdnPressType == 'Z') {
            SetupChargeForZone = hdn_SetUpCost;
            hdn_SetUpCost = 0;
        }

        var MarkupPrice = (Number(CostExMarkup) * Number(Markup)) / 100;
        var totalcost = 0;
        var SellingPrice = 0;

        totalcost = Number(CostExMarkup - hdn_SetUpCost) + MarkupPrice + Number(hdn_SetUpCost);

        ToatlSellingPrice = Number(ToatlSellingPrice) + Number(totalcost);

        $($hdnMarkupPrice[i]).val(MarkupPrice);
        $($hdnSellingPrice[i]).val(SellingPrice);
        var finalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, totalcost, 0, '', false, false, true);
        $($lblSellingPrice[i]).html(finalValue);
        $($lblMarkupPrice[i]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupPrice, 0, '', false, false, true));

        if (Number(hdn_MinimumCharge) >= (Number(ToatlSellingPrice) + Number(SetupChargeForZone))) {

            if (isZdoubleside == 'yes' && (i == 0 || i == 1)) {
                $($td_PressCostView_Totalsellingprice[0]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(hdn_MinimumCharge), 0, '', false, false, true));
            }
            else if (isZdoubleside == 'yes' && (i == 2 || i == 3)) {
                $($td_PressCostView_Totalsellingprice[1]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(hdn_MinimumCharge), 0, '', false, false, true));
            }
            else if (isZdoubleside == 'yes' && (i == 4 || i == 5)) {
                $($td_PressCostView_Totalsellingprice[2]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(hdn_MinimumCharge), 0, '', false, false, true));
            }
            else if (isZdoubleside == 'yes' && (i == 6 || i == 7)) {
                $($td_PressCostView_Totalsellingprice[3]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(hdn_MinimumCharge), 0, '', false, false, true));
            }
            else if (isZdoubleside == 'no') {
                $($td_PressCostView_Totalsellingprice[i]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(hdn_MinimumCharge), 0, '', false, false, true));
            }
        } else {

            if (isZdoubleside == 'yes' && (i == 0 || i == 1)) {
                $($td_PressCostView_Totalsellingprice[0]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(ToatlSellingPrice) + Number(SetupChargeForZone)), 0, '', false, false, true));
            }
            else if (isZdoubleside == 'yes' && (i == 2 || i == 3)) {
                $($td_PressCostView_Totalsellingprice[1]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(ToatlSellingPrice) + Number(SetupChargeForZone)), 0, '', false, false, true));
            }
            else if (isZdoubleside == 'yes' && (i == 4 || i == 5)) {
                $($td_PressCostView_Totalsellingprice[2]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(ToatlSellingPrice) + Number(SetupChargeForZone)), 0, '', false, false, true));
            }
            else if (isZdoubleside == 'yes' && (i == 6 || i == 7)) {
                $($td_PressCostView_Totalsellingprice[3]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(ToatlSellingPrice) + Number(SetupChargeForZone)), 0, '', false, false, true));
            }
            else if (isZdoubleside == 'no') {
                $($td_PressCostView_Totalsellingprice[i]).html(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(ToatlSellingPrice) + Number(SetupChargeForZone)), 0, '', false, false, true));
            }
        }
        if (hdnPressType == 'z' || hdnPressType == 'Z') {
            hdn_SetUpCost = SetupChargeForZone;
        }
    }
}


function MarkupOnBlur_Guillotine(Obj) {
    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));
    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var hdn_CostExMarkup_Actual = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup_Actual'));
    var hdn_isFirstTrim = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_isFirstTrim'));
    var hdn_isSecondTrim = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_isSecondTrim'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));
    //    alert(hdn_CostExMarkup.value);
    //    alert(txt_Markup.value);
    //    alert(hdn_isFirstTrim.value + ' ' + hdn_isSecondTrim.value);

    var hdn_MinimumCharge = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MinimumCharge'));
    var hdn_SetUpCost = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SetUpCost'));

    //    alert(hdn_MinimumCharge.value);
    //    alert(hdn_SetUpCost.value);
    var CostExMarkup = hdn_CostExMarkup_Actual.value;
    var Markup = txt_Markup.value;
    // var MarkupPrice = (Number(CostExMarkup) * Number(Markup)) / 100;
    //var SellingPrice = Number(CostExMarkup) + Number(MarkupPrice);



    //  var SellingPrice = Eprint_GetminimumCost_ComparedtoCostwithMarkup(CostExMarkup - hdn_SetUpCost.value, Markup, hdn_MinimumCharge.value, '', '', hdn_SetUpCost.value);


    var MarkupPrice = (Number(CostExMarkup - hdn_SetUpCost.value) * Number(Markup)) / 100;
    var totalcost = 0;
    var SellingPrice = 0;

    totalcost = Number(CostExMarkup - hdn_SetUpCost.value) + MarkupPrice + Number(hdn_SetUpCost.value);

    if (hdn_isFirstTrim.value == 'True' || hdn_isSecondTrim.value == 'True') {
        if (Number(hdn_MinimumCharge.value) >= Number(totalcost)) {
            SellingPrice = Number(hdn_MinimumCharge.value);
            hdn_CostExMarkup.value = hdn_MinimumCharge.value;
            hdn_MarkupPrice.value = "0";
        }
        else {
            SellingPrice = Number(totalcost);
            hdn_CostExMarkup.value = Number(totalcost) - MarkupPrice;
            hdn_MarkupPrice.value = MarkupPrice;
        }

        hdn_CostExMarkup_Actual = Number(totalcost) - MarkupPrice;
        hdn_SellingPrice.value = SellingPrice;


        var finalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, true);
        lbl_SellingPrice.innerHTML = finalValue;
        lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupPrice, 0, '', false, false, true);
    }
    // alert(lbl_SellingPrice.innerHTML);
}


function MarkupOnBlur_Ink(Obj) {
    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));

    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var hdn_CostExMarkup_Actual = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup_Actual'));

    var hdn_MinimumCharge = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MinimumCharge'));
    var hdn_SetUpCost = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SetUpCost'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));

    var CostExMarkup = '';
    var Markup = '';
    //    alert(hdn_MinimumCharge.value);


    var CostExMarkup = hdn_CostExMarkup_Actual.value;
    var Markup = txt_Markup.value;
    //var SellingPrice = Eprint_GetminimumCost_ComparedtoCostwithMarkup(CostExMarkup - hdn_SetUpCost.value, Markup, hdn_MinimumCharge.value, '', '', hdn_SetUpCost.value);

    var MarkupPrice = (Number(CostExMarkup - hdn_SetUpCost.value) * Number(Markup)) / 100;
    var totalcost = 0;
    var SellingPrice = 0;
    totalcost = Number(CostExMarkup - hdn_SetUpCost.value) + MarkupPrice + Number(hdn_SetUpCost.value);
    if (Number(hdn_MinimumCharge.value) >= Number(totalcost)) {
        SellingPrice = Number(hdn_MinimumCharge.value);
        hdn_CostExMarkup.value = hdn_MinimumCharge.value;
        hdn_MarkupPrice.value = "0";
    }
    else {
        SellingPrice = Number(totalcost);
        hdn_CostExMarkup.value = Number(totalcost) - MarkupPrice;
        hdn_MarkupPrice.value = MarkupPrice;
    }

    hdn_CostExMarkup_Actual = Number(totalcost) - MarkupPrice;
    hdn_SellingPrice.value = SellingPrice;
    var finalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellingPrice, 0, '', false, false, true);
    lbl_SellingPrice.innerHTML = finalValue;
    lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupPrice, 0, '', false, false, true);

}

function MarkupOnBlur_Plates(Obj) {
    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));
    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));

    var MarkVal = Obj.value;
    hdn_LithoMarkup.value = MarkVal;
    if (MarkVal != "" && !isNaN(MarkVal)) {



        txt_Markup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkVal, 0, '', false, false, true); ; //  roundNumber(MarkVal, 2);
        var cost = hdn_CostExMarkup.value;
        var SellPrice = Number(cost) + Number(Number(cost) * Number(MarkVal) / 100);

        hdn_MarkupPrice.value = Number(Number(cost) * Number(MarkVal) / 100);

        SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellPrice, 0, '', false, false, true);
        lbl_SellingPrice.innerHTML = SellPrice;
        lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, hdn_MarkupPrice.value, 0, '', false, false, true);
    }
    else {
        MarkVal = MarkObj.value = 0.00;
    }
    //    alert(lbl_SellingPrice.innerHTML);
    //    alert(hdn_LithoMarkup.value);
}

function MarkupOnBlur_Washup(Obj) {
    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));
    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var hdn_NoofColoursUsed = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_NoofColoursUsed'));
    var hdn_UnitPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_UnitPrice'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));
    //var hdn_LithoMarkup = document.getElementById("<%=hdn_LithoMarkup.ClientID %>");
    //alert(hdn_LithoMarkup.value);
    var CostExMarkup = hdn_CostExMarkup.value;
    var Markup = txt_Markup.value;
    var unitprice = hdn_UnitPrice.value;
    var washup = hdn_NoofColoursUsed.value;

    hdn_LithoMarkup.value = txt_Markup.value;
    if (Markup != "" && !isNaN(Markup)) {
        if (Number(hdn_CostExMarkup.value == 0.00)) {
            var cost = Number(hdn_CostExMarkup.value);
        }
        else {
            var cost = Number(unitprice) * Number(washup);
        }
        var num = Number(cost) + (Number(cost) * Number(Markup) / 100)

        hdn_MarkupPrice.value = (Number(cost) * Number(Markup) / 100);

        lbl_SellingPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, num, 0, '', false, false, true);
        lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, hdn_MarkupPrice.value, 0, '', false, false, true);
        //alert(lbl_SellingPrice.innerHTML);
    }
    else {
        Obj.value = "0.00";
    }
    Obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Obj.value, 0, '', false, false, true);
    //alert(hdn_LithoMarkup.value);
}

function MarkupOnBlur_MakeReady(Obj) {
    var txt_Markup = document.getElementById(Obj.id);
    var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_SellingPrice'));
    var hdn_SellingPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_SellingPrice'));
    var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_MarkupPrice'));
    var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_CostExMarkup'));
    var NoofPlatesUsed = document.getElementById(Obj.id.replace('txt_Markup', 'NoofPlatesUsed'));
    var hdn_UnitPrice = document.getElementById(Obj.id.replace('txt_Markup', 'hdn_UnitPrice'));
    var lbl_MarkupPrice = document.getElementById(Obj.id.replace('txt_Markup', 'lbl_MarkupPrice'));
    var CostExMarkup = hdn_CostExMarkup.value;
    var Markup = txt_Markup.value;
    var unitprice = hdn_UnitPrice.value;
    var MakeReady = NoofPlatesUsed.value;

    hdn_LithoMarkup.value = txt_Markup.value;
    if (Markup != "" && !isNaN(Markup)) {
        if (Number(hdn_CostExMarkup.value) == 0.00) {
            var cost = Number(hdn_CostExMarkup.value);
        }
        else {
            var cost = Number(unitprice) * Number(MakeReady);
        }
        var num = Number(cost) + (Number(cost) * Number(Markup) / 100)

        hdn_MarkupPrice.value = (Number(cost) * Number(Markup) / 100);

        lbl_SellingPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, num, 0, '', false, false, true); //"$" + roundNumber(num, 2);
        lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, hdn_MarkupPrice.value, 0, '', false, false, true);
        //alert(lbl_SellingPrice.innerHTML);
    }
    else {
        Obj.value = "0.00";
    }
    Obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Obj.value, 0, '', false, false, true);
    //alert(hdn_LithoMarkup.value);
}


///

function Booklet_Onblur_Paper(Obj, Markup, QtyCount) {
    if (!isNaN(Markup)) {
        var idlist = MarkupIdList.split('±');
        for (var i = 0; i < idlist.length; i++) {
            if (idlist[i] != '') {
                //alert(idlist[i]);
                var spn = "spnSellingPrice_" + idlist[i] + "";
                var mar = "txtMarkUp_" + idlist[i] + "";
                var spnSellExMark = "spnPriceExMarkup_" + idlist[i] + "";

                document.getElementById(mar).value = roundNumber(Markup, 2);
                hdn_Markup.value = Markup;

                var SellValue = document.getElementById(spnSellExMark).innerHTML;
                var MarkupValue = (Number(SellValue) * Number(Markup)) / 100;
                MarkupValue = roundNumber(MarkupValue, 2);
                var finalValue = Number(SellValue) + Number(MarkupValue);
                finalValue = roundNumber(finalValue, 2);
                document.getElementById(spn).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + finalValue;
            }
        }
    }
    else {
        Obj.value = 0;
    }
    Obj.value = roundNumber(Obj.value, 2);
}

function MarkupOnBlur(Obj, Markup, MinimumCost, FirstTrim, SecondTrim, Type, SetupCharge, MarkupCnt) {
    if (!isNaN(Markup)) {
        var idlist = MarkupIdList.split('±');
        if (MarkupCnt == 0) {
            for (var i = 0; i < idlist.length; i++) {
                if (idlist[i] != '') {
                    var spn = "spnSellingPrice_" + idlist[i] + "";
                    var mar = "txtMarkUp_" + idlist[i] + "";
                    var spnSellExMark = "spnPriceExMarkup_" + idlist[i] + "";

                    document.getElementById(mar).value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);

                    var SellValue = document.getElementById(spnSellExMark).innerHTML.replace(/,/, '');
                    var MarkupValue = (Number(SellValue) * Number(Markup)) / 100;

                    var finalValue = 0;

                    if ((Type == '1') && (FirstTrim == '1' || SecondTrim == '1')) {
                        finalValue = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellValue, Markup, MinimumCost, '', '', SetupCharge); // number(sellvalue) + number(markupvalue);                    
                    }
                    else if (Type == '0') {
                        finalValue = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellValue, Markup, MinimumCost, '', '', SetupCharge); // Number(SellValue) + Number(MarkupValue);
                    }

                    finalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalValue, 0, '', false, false, true);
                    document.getElementById(spn).innerHTML = finalValue;

                    //== Re-Eng to update MArkupPrice in tb_EstQuantity ===//
                    hdn_Markup.value = Markup;
                    hdn_Markup2.value = Markup;
                    hdn_Markup3.value = Markup;
                    hdn_Markup4.value = Markup;

                    var TempTotalCost = Number(SellValue) + ((Number(SellValue) * Number(Markup)) / 100) + Number(SetupCharge);
                    if (Number(MinimumCost) >= Number(TempTotalCost)) {
                        hdn_MarkupPrice1.value = i == 0 ? 0 : hdn_MarkupPrice1.value;
                        hdn_MarkupPrice2.value = i == 1 ? 0 : hdn_MarkupPrice2.value;
                        hdn_MarkupPrice3.value = i == 2 ? 0 : hdn_MarkupPrice3.value;
                        hdn_MarkupPrice4.value = i == 3 ? 0 : hdn_MarkupPrice4.value;

                        hdn_CostExMarkup1.value = i == 0 ? MinimumCost : hdn_CostExMarkup1.value;
                        hdn_CostExMarkup2.value = i == 1 ? MinimumCost : hdn_CostExMarkup2.value;
                        hdn_CostExMarkup3.value = i == 2 ? MinimumCost : hdn_CostExMarkup3.value;
                        hdn_CostExMarkup4.value = i == 3 ? MinimumCost : hdn_CostExMarkup4.value;
                    }
                    else {
                        hdn_MarkupPrice1.value = i == 0 ? MarkupValue : hdn_MarkupPrice1.value;
                        hdn_MarkupPrice2.value = i == 1 ? MarkupValue : hdn_MarkupPrice2.value;
                        hdn_MarkupPrice3.value = i == 2 ? MarkupValue : hdn_MarkupPrice3.value;
                        hdn_MarkupPrice4.value = i == 3 ? MarkupValue : hdn_MarkupPrice4.value;

                        hdn_CostExMarkup1.value = i == 0 ? SellValue : hdn_CostExMarkup1.value;
                        hdn_CostExMarkup2.value = i == 1 ? SellValue : hdn_CostExMarkup2.value;
                        hdn_CostExMarkup3.value = i == 2 ? SellValue : hdn_CostExMarkup3.value;
                        hdn_CostExMarkup4.value = i == 3 ? SellValue : hdn_CostExMarkup4.value;
                    }
                    //== Re-Eng to update MArkupPrice in tb_EstQuantity ===//                 
                }
            }
        }
        else {
            if (idlist[MarkupCnt] != '') {
                var spn = "spnSellingPrice_" + idlist[MarkupCnt] + "";
                var mar = "txtMarkUp_" + idlist[MarkupCnt] + "";
                var spnSellExMark = "spnPriceExMarkup_" + idlist[MarkupCnt] + "";

                document.getElementById(mar).value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);

                var SellValue = document.getElementById(spnSellExMark).innerHTML.replace(/,/, '');
                var MarkupValue = (Number(SellValue) * Number(Markup)) / 100;

                var finalValue = 0;

                if ((Type == '1') && (FirstTrim == '1' || SecondTrim == '1')) {
                    finalValue = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellValue, Markup, MinimumCost, '', '', SetupCharge); // number(sellvalue) + number(markupvalue);                    
                }
                else if (Type == '0') {
                    finalValue = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellValue, Markup, MinimumCost, '', '', SetupCharge); // Number(SellValue) + Number(MarkupValue);                    
                }

                finalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalValue, 0, '', false, false, true);
                document.getElementById(spn).innerHTML = finalValue;

                //== Re-Eng to update MArkupPrice in tb_EstQuantity ===//
                hdn_Markup.value = MarkupCnt == 0 ? Markup : hdn_Markup.value;
                hdn_Markup2.value = MarkupCnt == 1 ? Markup : hdn_Markup2.value;
                hdn_Markup3.value = MarkupCnt == 2 ? Markup : hdn_Markup3.value;
                hdn_Markup4.value = MarkupCnt == 3 ? Markup : hdn_Markup4.value;

                var TempTotalCost = Number(SellValue) + ((Number(SellValue) * Number(Markup)) / 100) + Number(SetupCharge);
                if (Number(MinimumCost) >= Number(TempTotalCost)) {
                    hdn_MarkupPrice1.value = MarkupCnt == 0 ? 0 : hdn_MarkupPrice1.value;
                    hdn_MarkupPrice2.value = MarkupCnt == 1 ? 0 : hdn_MarkupPrice2.value;
                    hdn_MarkupPrice3.value = MarkupCnt == 2 ? 0 : hdn_MarkupPrice3.value;
                    hdn_MarkupPrice4.value = MarkupCnt == 3 ? 0 : hdn_MarkupPrice4.value;

                    hdn_CostExMarkup1.value = MarkupCnt == 0 ? MinimumCost : hdn_CostExMarkup1.value;
                    hdn_CostExMarkup2.value = MarkupCnt == 1 ? MinimumCost : hdn_CostExMarkup2.value;
                    hdn_CostExMarkup3.value = MarkupCnt == 2 ? MinimumCost : hdn_CostExMarkup3.value;
                    hdn_CostExMarkup4.value = MarkupCnt == 3 ? MinimumCost : hdn_CostExMarkup4.value;
                }
                else {
                    hdn_MarkupPrice1.value = MarkupCnt == 0 ? MarkupValue : hdn_MarkupPrice1.value;
                    hdn_MarkupPrice2.value = MarkupCnt == 1 ? MarkupValue : hdn_MarkupPrice2.value;
                    hdn_MarkupPrice3.value = MarkupCnt == 2 ? MarkupValue : hdn_MarkupPrice3.value;
                    hdn_MarkupPrice4.value = MarkupCnt == 3 ? MarkupValue : hdn_MarkupPrice4.value;

                    hdn_CostExMarkup1.value = MarkupCnt == 0 ? SellValue : hdn_CostExMarkup1.value;
                    hdn_CostExMarkup2.value = MarkupCnt == 1 ? SellValue : hdn_CostExMarkup2.value;
                    hdn_CostExMarkup3.value = MarkupCnt == 2 ? SellValue : hdn_CostExMarkup3.value;
                    hdn_CostExMarkup4.value = MarkupCnt == 3 ? SellValue : hdn_CostExMarkup4.value;
                }
                //== Re-Eng to update MArkupPrice in tb_EstQuantity ===//                   
            }
        }
    }
    else {
        Obj.value = 0;
    }
    Obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Obj.value, 0, '', false, false, true); //roundNumber(Obj.value, 2);    
}


function MarkupOnBlur_litho(Obj, Markup, presspasses, MinimumCost, PressSetupCharge, MarkupCnt) {
    if (!isNaN(Markup)) {
        var idlist = MarkupIdList.split('±');
        if (MarkupCnt == 0) {
            for (var i = 0; i < idlist.length; i++) {
                if (idlist[i] != '') {
                    var spn = "spnSellingPrice_" + idlist[i] + "";
                    var mar = "txtMarkUp_" + idlist[i] + "";
                    var spnSellExMark = "spnPriceExMarkup_" + idlist[i] + "";

                    document.getElementById(mar).value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);

                    var SellValue = document.getElementById(spnSellExMark).innerHTML.replace(/,/, '');

                    var MarkupValue = (Number(SellValue) * Number(Markup)) / 100;
                    var finalValue = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellValue, Markup, MinimumCost, '', '', PressSetupCharge); //Number(SellValue) + Number(MarkupValue);
                    finalValue = finalValue; // * presspasses;

                    document.getElementById(spn).innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalValue, 0, '', false, false, true);

                    //== Re-Eng to update MArkupPrice in tb_EstQuantity ===//
                    hdn_Markup.value = Markup;
                    hdn_Markup2.value = Markup;
                    hdn_Markup3.value = Markup;
                    hdn_Markup4.value = Markup;

                    var TempTotalCost = Number(SellValue) + ((Number(SellValue) * Number(Markup)) / 100) + Number(PressSetupCharge);
                    if (Number(MinimumCost) >= Number(TempTotalCost)) {
                        hdn_MarkupPrice1.value = i == 0 ? 0 : hdn_MarkupPrice1.value;
                        hdn_MarkupPrice2.value = i == 1 ? 0 : hdn_MarkupPrice2.value;
                        hdn_MarkupPrice3.value = i == 2 ? 0 : hdn_MarkupPrice3.value;
                        hdn_MarkupPrice4.value = i == 3 ? 0 : hdn_MarkupPrice4.value;

                        hdn_CostExMarkup1.value = i == 0 ? MinimumCost : hdn_CostExMarkup1.value;
                        hdn_CostExMarkup2.value = i == 1 ? MinimumCost : hdn_CostExMarkup2.value;
                        hdn_CostExMarkup3.value = i == 2 ? MinimumCost : hdn_CostExMarkup3.value;
                        hdn_CostExMarkup4.value = i == 3 ? MinimumCost : hdn_CostExMarkup4.value;
                    }
                    else {
                        hdn_MarkupPrice1.value = i == 0 ? MarkupValue : hdn_MarkupPrice1.value;
                        hdn_MarkupPrice2.value = i == 1 ? MarkupValue : hdn_MarkupPrice2.value;
                        hdn_MarkupPrice3.value = i == 2 ? MarkupValue : hdn_MarkupPrice3.value;
                        hdn_MarkupPrice4.value = i == 3 ? MarkupValue : hdn_MarkupPrice4.value;

                        hdn_CostExMarkup1.value = i == 0 ? SellValue : hdn_CostExMarkup1.value;
                        hdn_CostExMarkup2.value = i == 1 ? SellValue : hdn_CostExMarkup2.value;
                        hdn_CostExMarkup3.value = i == 2 ? SellValue : hdn_CostExMarkup3.value;
                        hdn_CostExMarkup4.value = i == 3 ? SellValue : hdn_CostExMarkup4.value;
                    }
                }
            }
        }
        else {
            if (idlist[MarkupCnt] != '') {
                var spn = "spnSellingPrice_" + idlist[MarkupCnt] + "";
                var mar = "txtMarkUp_" + idlist[MarkupCnt] + "";
                var spnSellExMark = "spnPriceExMarkup_" + idlist[MarkupCnt] + "";

                document.getElementById(mar).value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);

                var SellValue = document.getElementById(spnSellExMark).innerHTML.replace(/,/, '');

                var MarkupValue = (Number(SellValue) * Number(Markup)) / 100;
                var finalValue = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellValue, Markup, MinimumCost, '', '', PressSetupCharge); //Number(SellValue) + Number(MarkupValue);
                finalValue = finalValue; // * presspasses;


                document.getElementById(spn).innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalValue, 0, '', false, false, true);

                //== Re-Eng to update MArkupPrice in tb_EstQuantity ===//
                hdn_Markup.value = MarkupCnt == 0 ? Markup : hdn_Markup.value;
                hdn_Markup2.value = MarkupCnt == 1 ? Markup : hdn_Markup2.value;
                hdn_Markup3.value = MarkupCnt == 2 ? Markup : hdn_Markup3.value;
                hdn_Markup4.value = MarkupCnt == 3 ? Markup : hdn_Markup4.value;

                var TempTotalCost = Number(SellValue) + ((Number(SellValue) * Number(Markup)) / 100) + Number(PressSetupCharge);
                if (Number(MinimumCost) >= Number(TempTotalCost)) {
                    hdn_MarkupPrice1.value = MarkupCnt == 0 ? 0 : hdn_MarkupPrice1.value;
                    hdn_MarkupPrice2.value = MarkupCnt == 1 ? 0 : hdn_MarkupPrice2.value;
                    hdn_MarkupPrice3.value = MarkupCnt == 2 ? 0 : hdn_MarkupPrice3.value;
                    hdn_MarkupPrice4.value = MarkupCnt == 3 ? 0 : hdn_MarkupPrice4.value;

                    hdn_CostExMarkup1.value = MarkupCnt == 0 ? MinimumCost : hdn_CostExMarkup1.value;
                    hdn_CostExMarkup2.value = MarkupCnt == 1 ? MinimumCost : hdn_CostExMarkup2.value;
                    hdn_CostExMarkup3.value = MarkupCnt == 2 ? MinimumCost : hdn_CostExMarkup3.value;
                    hdn_CostExMarkup4.value = MarkupCnt == 3 ? MinimumCost : hdn_CostExMarkup4.value;
                }
                else {
                    hdn_MarkupPrice1.value = MarkupCnt == 0 ? MarkupValue : hdn_MarkupPrice1.value;
                    hdn_MarkupPrice2.value = MarkupCnt == 1 ? MarkupValue : hdn_MarkupPrice2.value;
                    hdn_MarkupPrice3.value = MarkupCnt == 2 ? MarkupValue : hdn_MarkupPrice3.value;
                    hdn_MarkupPrice4.value = MarkupCnt == 3 ? MarkupValue : hdn_MarkupPrice4.value;

                    hdn_CostExMarkup1.value = MarkupCnt == 0 ? SellValue : hdn_CostExMarkup1.value;
                    hdn_CostExMarkup2.value = MarkupCnt == 1 ? SellValue : hdn_CostExMarkup2.value;
                    hdn_CostExMarkup3.value = MarkupCnt == 2 ? SellValue : hdn_CostExMarkup3.value;
                    hdn_CostExMarkup4.value = MarkupCnt == 3 ? SellValue : hdn_CostExMarkup4.value;
                }
            }
        }
    }
    else {
        Obj.value = 0;
    }
    Obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Obj.value, 0, '', false, false, true); //roundNumber(Obj.value, 2);
}

function ItemMarkupOnBlur_ware(Markup, ID, MinimumCost) {

    if (ID != "" && !isNaN(Markup)) {
        var spnSellInMark = "spnSellingPrice_" + ID + "";
        var mar = "txtMarkUp_" + ID + "";
        var spnSellExMark = "spnPriceExMarkup_" + ID + "";

        var SellExMarkupValue = document.getElementById(spnSellExMark).innerHTML;
        //var SellInMarkValue = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100); 
        var SellInMarkValue = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellExMarkupValue, Markup, MinimumCost, '', '', 0);
        SellInMarkValue = SellInMarkValue;
        document.getElementById(spnSellInMark).innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInMarkValue, 0, '', false, false, true);
    }
}


function ItemMarkupOnBlur(Markup, ID, MinimumCost, Setupcost) {
    if (ID != "" && !isNaN(Markup)) {
        var spnSellInMark = "spnSellingPrice_" + ID + "";
        var mar = "txtMarkUp_" + ID + "";
        var spnSellExMark = "spnPriceExMarkup_" + ID + "";

        var SellExMarkupValue = document.getElementById(spnSellExMark).innerHTML;
        SellExMarkupValue = SellExMarkupValue.replace(',', '');
        //var SellInMarkValue = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100); 
        var SellInMarkValue = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellExMarkupValue, Markup, MinimumCost, '', '', 0);
        SellInMarkValue = SellInMarkValue;
        if (SellExMarkupValue >= MinimumCost) {
            SellInMarkValue = Number(SellInMarkValue) + Number(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Setupcost, 0, '', false, false, true));
        }
        else {
            SellInMarkValue = MinimumCost;
        }
        document.getElementById(spnSellInMark).innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInMarkValue, 0, '', false, false, true);
    }
}
/* The following function is not used because Sub Item Other Cost is changed */
//For SubItem of Other Costs
function SubItemOtherCostBlur(MarkupObj, Markup, Ids) {
    var TotalID = Ids.split(',');
    var EstOtherCostID = TotalID[0];
    var EstQtyID = TotalID[1];
    var QtyIDList = EstQtyID.split('±');
    for (var i = 0; i < QtyIDList.length - 1; i++) {
        if (QtyIDList[i] != "" && !isNaN(Markup) && Markup != '') {
            var spnSellInMark = "spnSellingPrice_" + EstOtherCostID + "_" + QtyIDList[i] + "";
            var mar = "txtMarkUp_" + EstOtherCostID + "";
            var spnSellExMark = "spnPriceExMarkup_" + EstOtherCostID + "_" + QtyIDList[i] + "";

            var SellExMarkupValue = document.getElementById(spnSellExMark).innerHTML;
            var SellInMarkValue = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
            SellInMarkValue = roundNumber(SellInMarkValue, 2);
            //SellInMarkValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInMarkValue, 0, '', false, false, true);
            document.getElementById(spnSellInMark).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + SellInMarkValue;
            //alert(hi);
        }
        else {
            MarkupObj.value = "0";
        }
    }
}
//FOR INK MARKUP
function InkMarkupOnBlur(obj, Markup, List, MinimumCost) {
    var List1 = List.split(',')
    var InkIDList = List1[0].split('±');
    var QtyCount = List1[1];
    var MinimumCost = MinimumCost.split('±');
    var TotalInkCostInMark1 = 0;
    var TotalInkCostInMark2 = 0;
    var TotalInkCostInMark3 = 0;
    var TotalInkCostInMark4 = 0;


    for (var i = 0; i < InkIDList.length; i++) {
        var InkID = InkIDList[i];
        for (var j = 0; j < QtyCount; j++) {
            if (!isNaN(Markup) && Markup != '') {

                var SellExMarkupValue = document.getElementById("spnSellingExMarkup_" + InkID + "_" + j + "").innerHTML.replace(GetCurrencyinRequiredFormate("", true), '').replace(/,/, '');
                //var InkCostInMark = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
                var InkCostInMark = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellExMarkupValue, Markup, MinimumCost[i], '', '', 0);

                InkCostInMark = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, InkCostInMark, 0, '', false, false, true);
                document.getElementById("spnSellingPrice_" + InkID + "_" + j + "").innerHTML = InkCostInMark;
                document.getElementById("txtMarkUp_" + InkID + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true); // roundNumber(Markup, 2);
                hdn_Markup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true); //Markup;                


                if (j == '0') {
                    TotalInkCostInMark1 = TotalInkCostInMark1 + Number(InkCostInMark);
                    document.getElementById("TotalSellingPrice1").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalInkCostInMark1, 0, '', false, false, true);

                }
                if (j == '1') {
                    TotalInkCostInMark2 = TotalInkCostInMark2 + Number(InkCostInMark);
                    document.getElementById("TotalSellingPrice2").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalInkCostInMark2, 0, '', false, false, true);
                }
                if (j == '2') {
                    TotalInkCostInMark3 = TotalInkCostInMark3 + Number(InkCostInMark);
                    document.getElementById("TotalSellingPrice3").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalInkCostInMark3, 0, '', false, false, true);
                }
                if (j == '3') {
                    TotalInkCostInMark4 = TotalInkCostInMark4 + Number(InkCostInMark);
                    document.getElementById("TotalSellingPrice4").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalInkCostInMark4, 0, '', false, false, true);
                }

            }
            else {
                obj.value = "0";
            }
        }
    }
}
//ONLY FOR MAIN WAREHOUSE ITEMs
function WarehouseMarkupOnBlur(obj, Markup, WareIDList) {
    var WareArr = WareIDList.split('±');
    for (var i = 0; i < WareArr.length; i++) {
        if (!isNaN(Markup) && Markup != '') {
            var SellExMarkupValue = document.getElementById("spnSellingExMarkup_" + WareArr[i] + "").innerHTML.replace(GetCurrencyinRequiredFormate("", true), '').replace(/,/, '');
            var SellInMarkup = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
            SellInMarkup = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInMarkup, 0, '', false, false, true); // roundNumber(SellInMarkup, 2);

            document.getElementById("spnSellingInMarkup_" + WareArr[i] + "").innerHTML = SellInMarkup;
            document.getElementById("txtMarkUp_" + WareArr[i] + "").value = Markup;
        }
        else {
            obj.value = "0";
        }
    }
}
function ItemOutworkMarkupOnBlur(Markup, Param) {
    var Arr1 = Param.split(',');
    var ID = Arr1[0];
    var MarkupType = Arr1[1];

    //alert(MarkupType);

    var MarkupPercentage = Markup.value;
    if (ID != "" && !isNaN(Markup)) {
        var spnSellInMark = "spnSellingPrice_" + ID + "";
        var mar = "txtMarkUp_" + ID + "";
        var spnSellExMark = "spnPriceExMarkup_" + ID + "";

        var SellExMarkupValue = document.getElementById(spnSellExMark).innerHTML;
        //alert(SellExMarkupValue);
        var SellInMarkValue = 0;
        if (MarkupType == "%") {
            SellInMarkValue = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
            //alert(SellInMarkValue);
        }
        else {
            SellInMarkValue = Number(SellExMarkupValue) + Number(Markup);
        }
        SellInMarkValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellInMarkValue, 0, '', false, false, true);
        document.getElementById(spnSellInMark).innerHTML = SellInMarkValue;
        Markup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup.value, 0, '', false, false, true);
    }

}

//FOR PRICE CATALOGUE SUB ITEM
function ItemCatalogueMarkupOnBlur(txtobj, index, TotCnt) {
    var MarkupPercentage = txtobj.value;
    //MarkupPercentage = roundNumber(Number(MarkupPercentage), 2)
    MarkupPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupPercentage, 0, '', false, false, true);

    if (index == 0) {
        for (var i = 0; i < TotCnt; i++) {
            var spnPriceId = "spnPriceExMarkup_" + i + "";
            var txtmarkupId = "txtMarkUp_" + i + "";
            var spnSellInMarkId = "spnSellingInMarkup_" + i + "";
            if (MarkupPercentage != "" && !isNaN(MarkupPercentage)) {
                if (document.getElementById(spnPriceId) != null) {
                    document.getElementById(txtmarkupId).value = MarkupPercentage;
                    var markup = MarkupPercentage;

                    var price = document.getElementById(spnPriceId).innerHTML.replace(',', '');
                    var MarkupValue = Number((Number(price) * Number(markup)) / 100);
                    var SellPrice = Number(MarkupValue) + Number(price);
                    //SellPrice = roundNumber(SellPrice, 2);
                    SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellPrice, 0, '', false, false, true);
                    document.getElementById(spnSellInMarkId).innerHTML = SellPrice;
                }
            }
            else {
                txtobj.value = "0.00";
                return false;
            }
        }
    }
    else {
        var spnPriceId = "spnPriceExMarkup_" + index + "";
        var txtmarkupId = "txtMarkUp_" + index + "";
        var spnSellInMarkId = "spnSellingInMarkup_" + index + "";
        if (MarkupPercentage != "" && !isNaN(MarkupPercentage)) {
            if (document.getElementById(spnPriceId) != null) {
                document.getElementById(txtmarkupId).value = MarkupPercentage;
                var markup = MarkupPercentage;

                var price = document.getElementById(spnPriceId).innerHTML.replace(',', '');
                var MarkupValue = Number((Number(price) * Number(markup)) / 100);
                var SellPrice = Number(MarkupValue) + Number(price);
                //SellPrice = roundNumber(SellPrice, 2);
                SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellPrice, 0, '', false, false, true);
                document.getElementById(spnSellInMarkId).innerHTML = SellPrice;
            }
        }
        else {
            txtobj.value = "0.00";
            return false;
        }
    }
}

//FOR PRICE CATALOGUE   
function CatalogueMarkupOnBlur(txtobj, index) {

    var MarkupPercentage = txtobj.value;

    //MarkupPercentage = roundNumber(Number(MarkupPercentage), 2)
    MarkupPercentage = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupPercentage, 0, '', false, false, true);

    if (index == 0) {

        for (var i = 0; i < 4; i++) {
            var spnPriceId = "spnPriceExMarkup_" + i + "";
            var txtmarkupId = "txtMarkUp_" + i + "";
            var spnSellInMarkId = "spnSellingInMarkup_" + i + "";

            if (MarkupPercentage != "" && !isNaN(MarkupPercentage)) {
                if (document.getElementById(spnPriceId) != null) {
                    document.getElementById(txtmarkupId).value = MarkupPercentage;
                    var markup = MarkupPercentage;

                    var price = document.getElementById(spnPriceId).innerHTML;
                    var MarkupValue = (price * markup) / 100;
                    var SellPrice = Number(MarkupValue) + Number(price);
                    //SellPrice = roundNumber(SellPrice, 2);
                    SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellPrice, 0, '', false, false, true);
                    document.getElementById(spnSellInMarkId).innerHTML = SellPrice;
                }
            }
            else {
                txtobj.value = "0.00";
                return false;
            }
        }
    }
    else {
        var spnPriceId = "spnPriceExMarkup_" + index + "";
        var txtmarkupId = "txtMarkUp_" + index + "";
        var spnSellInMarkId = "spnSellingInMarkup_" + index + "";

        if (MarkupPercentage != "" && !isNaN(MarkupPercentage)) {
            if (document.getElementById(spnPriceId) != null) {
                document.getElementById(txtmarkupId).value = MarkupPercentage;
                var markup = MarkupPercentage;

                var price = document.getElementById(spnPriceId).innerHTML;
                var MarkupValue = (price * markup) / 100;
                var SellPrice = Number(MarkupValue) + Number(price);
                //SellPrice = roundNumber(SellPrice, 2);
                SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellPrice, 0, '', false, false, true);
                document.getElementById(spnSellInMarkId).innerHTML = SellPrice;
            }
        }
        else {
            txtobj.value = "0.00";
            return false;
        }
    }
}



//litho
function MarkupOnBlur_washup(obj, Markup, unitprice, washup) {
    hdn_LithoMarkup.value = Markup;
    if (Markup != "" && !isNaN(Markup)) {
        var cost = Number(unitprice) * Number(washup);
        var num = Number(cost) + (Number(cost) * Number(Markup) / 100)
        document.getElementById("txtSell").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, num, 0, '', false, false, true); //"$" + roundNumber(num, 2);
    }
    else {
        obj.value = "0.00";
    }
    obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, true);
}

function MarkupOnBlur_makeready(obj, Markup, unitprice, makeready) {
    hdn_LithoMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);

    if (Markup != "" && !isNaN(Markup)) {
        var cost = Number(unitprice) * Number(makeready);
        var num = Number(cost) + (Number(cost) * Number(Markup) / 100)
        document.getElementById("txtSell1").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, num, 0, '', false, false, true); //roundNumber(num, 2);
        //alert(num);
    }
    else {
        obj.value = "0.00";
    }
    obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, true);
}

//function MarkupOnBlur_plates(MarkObj, QtyCount) {
//    var MarkVal = MarkObj.value;
//    hdn_LithoMarkup.value = MarkVal;
//    if (MarkVal != "" && !isNaN(MarkVal)) {
//        for (var i = 1; i <= QtyCount; i++) {
//            document.getElementById("txtMarkUp_" + i + "").value = roundNumber(MarkVal, 2);
//            var cost = document.getElementById("spn_Cost_" + i + "").innerHTML;
//            cost = roundNumber(cost, 2);

//            var SellPrice = Number(cost) + Number(Number(cost) * Number(MarkVal) / 100);
//            SellPrice = roundNumber(SellPrice, 2);
//            document.getElementById("spnSellPlate_" + i + "").innerHTML = "$" + SellPrice;
//        }
//    }
//    else {
//        MarkVal = MarkObj.value = 0.00;
//        for (var i = 1; i <= QtyCount; i++) {
//            document.getElementById("txtMarkUp_" + i + "").value = roundNumber(MarkVal, 2);
//            var cost = document.getElementById("spn_Cost_" + i + "").innerHTML;
//            cost = roundNumber(cost, 2);

//            document.getElementById("spnSellPlate_" + i + "").innerHTML = "$" + cost;
//        }
//    }
//}

function MarkupOnBlur_plates(MarkObj) {
    var MarkVal = MarkObj.value;
    hdn_LithoMarkup.value = MarkVal;
    if (MarkVal != "" && !isNaN(MarkVal)) {
        document.getElementById("txtMarkUp_Plate").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkVal, 0, '', false, false, true); ; //  roundNumber(MarkVal, 2);
        var cost = document.getElementById("spn_Cost_Plate").innerHTML;
        //cost = roundNumber(cost, 2);
        var SellPrice = Number(cost) + Number(Number(cost) * Number(MarkVal) / 100);
        //SellPrice = roundNumber(SellPrice, 2);
        SellPrice = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SellPrice, 0, '', false, false, true);
        document.getElementById("spnSell_Plate").innerHTML = SellPrice;
        //alert('SellPrice = '+SellPrice);
    }
    else {
        MarkVal = MarkObj.value = 0.00;
    }
}



function MarkupOnBlur_ink(obj, Markup, List, MinimumCost) {
    var List1 = List.split(',')
    var InkIDList = List1[0].split('±');
    var QtyCount = List1[1];
    var TotalInkCostInMark1 = 0;
    var TotalInkCostInMark2 = 0;
    var TotalInkCostInMark3 = 0;
    var TotalInkCostInMark4 = 0;
    var MinimumCost = MinimumCost.split('±');

    for (var i = 0; i < InkIDList.length - 1; i++) {
        var InkID = InkIDList[i];
        for (var j = 0; j < QtyCount; j++) {
            if (InkIDList[i] != '') {
                if (!isNaN(Markup) && Markup != '') {
                    var SellExMarkupValue = document.getElementById("spnSellingExMarkup_" + InkID + "_" + j + "").innerHTML.replace(GetCurrencyinRequiredFormate("", true), '').replace(/,/, '');
                    var InkCostInMark = Eprint_GetminimumCost_ComparedtoCostwithMarkup(SellExMarkupValue, Markup, MinimumCost[i], '', '', 0); // Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);

                    InkCostInMark = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, InkCostInMark, 0, '', false, false, true); //roundNumber(InkCostInMark, 2);
                    document.getElementById("spnSellingPrice_" + InkID + "_" + j + "").innerHTML = InkCostInMark;

                    document.getElementById("txtMarkUp_" + InkID + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true); // roundNumber(Markup, 2);
                    hdn_Markup.value = obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true); //Markup;                
                    if (j == '0') {
                        TotalInkCostInMark1 = TotalInkCostInMark1 + Number(InkCostInMark);
                        document.getElementById("TotalSellingPrice1").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalInkCostInMark1, 0, '', false, false, true);
                        //alert(TotalInkCostInMark1);
                    }
                    if (j == '1') {
                        TotalInkCostInMark2 = TotalInkCostInMark2 + Number(InkCostInMark);
                        //document.getElementById("TotalSellingPrice2").innerHTML = "$" + parseFloat(TotalInkCostInMark2).toFixed(2);
                        document.getElementById("TotalSellingPrice2").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalInkCostInMark2, 0, '', false, false, true);
                        //alert(TotalInkCostInMark2);
                    }
                    if (j == '2') {
                        TotalInkCostInMark3 = TotalInkCostInMark3 + Number(InkCostInMark);
                        //document.getElementById("TotalSellingPrice3").innerHTML = "$" + parseFloat(TotalInkCostInMark3).toFixed(2);
                        document.getElementById("TotalSellingPrice3").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalInkCostInMark3, 0, '', false, false, true);
                        //alert(TotalInkCostInMark3);
                    }
                    if (j == '3') {
                        TotalInkCostInMark4 = TotalInkCostInMark4 + Number(InkCostInMark);
                        document.getElementById("TotalSellingPrice4").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalInkCostInMark4, 0, '', false, false, true);
                        //document.getElementById("TotalSellingPrice4").innerHTML = "$" + parseFloat(TotalInkCostInMark4).toFixed(2);
                        //alert(TotalInkCostInMark4);
                    }
                }
            }
            else {
                obj.value = "0.00";
            }
        }
    }
}








//function MarkupOnBlur_ink(obj, Markup, List)
// {
//   var List1 = List.split(',')
//    var InkIDList = List1[0].split('±');
//    var QtyCount = List1[1];
//    var TotalInkCostInMark = 0;
//    var SellPri = 0;
//    var id=1;    
//    for (var i = 0; i < InkIDList.length-1; i++)
//     {
//        var InkID = InkIDList[i];      
//        for (var j = 0; j < QtyCount; j++) 
//        {
//            if (!isNaN(Markup) && Markup != '')
//             {
//                var SellExMarkupValue = document.getElementById("spnSellingExMarkup_" + InkID + "_" + j + "").innerHTML.replace('$', '').replace(/,/, '');
//                var InkCostInMark = Number(SellExMarkupValue) + (Number(SellExMarkupValue) * Number(Markup) / 100);
//                InkCostInMark = roundNumber(InkCostInMark, 2);
//                document.getElementById("spnSellingPrice_" + InkID + "_" + j + "").innerHTML = "$" + InkCostInMark;
//                document.getElementById("txtMarkUp_" + InkID + "").value = roundNumber(Markup, 2);
//                hdn_Markup.value = Markup;                
//                            
//            }            
//            else
//            {
//                obj.value = "0.00";
//            }
//        }
//    }
//    for (var j = 0; j < QtyCount; j++) 
//    {
//       TotalInkCostInMark=0;
//       for (var i = 0; i < InkIDList.length; i++) 
//       {
//           var InkID = InkIDList[i];
//           SellPri = document.getElementById("spnSellingPrice_" + InkID + "_" + j + "").innerHTML.replace('$', '').replace(/,/, '');
//               alert(Number(SellPri));
//               TotalInkCostInMark += Number(SellPri);
//               if(id!=5)
//               document.getElementById("TotalSellingPrice" + id).innerHTML = "$" + TotalInkCostInMark;
//       }
//       id++;
//   }
//}

function MarkupOnBlur_ZonePress(Obj, Markup, MinimumCost, FirstTrim, SecondTrim, Type, SetupCharge, SideNo) {
    if (!isNaN(Markup)) {
        var idlist = MarkupIdList.split('±');
        for (var i = 0; i < idlist.length; i++) {
            if (idlist[i] != '') {
                var spn = "spnSellingPrice_" + idlist[i] + "_" + "Side1" + "_" + i + "";
                var mar = "txtMarkUp_" + idlist[i] + "_" + "Side1" + "_" + i + "";
                var spnSellExMark = "spnPriceExMarkup_" + idlist[i] + "_" + "Side1" + "_" + i + "";

                var spn2 = 0.00;
                var mar2 = 0.00;
                var spnSellExMark2 = 0.00;
                if (SideNo == "Side2") {
                    hdn_ZoneSide2Markup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);
                    spn = "spnSellingPrice_" + idlist[i] + "_" + "Side2" + "_" + i + "";
                    mar = "txtMarkUp_" + idlist[i] + "_" + "Side2" + "_" + i + "";
                    spnSellExMark = "spnPriceExMarkup_" + idlist[i] + "_" + "Side2" + "_" + i + "";
                }

                if (hdn_ZoneSideColor1.value == hdn_ZoneSideColor2.value) {
                    hdn_ZoneSide2Markup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);
                    document.getElementById(mar).value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);
                    document.getElementById("txtMarkUp_" + idlist[i] + "_" + "Side2" + "_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);
                }
                else {
                    document.getElementById(mar).value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Markup, 0, '', false, false, true);
                }

                if (SideNo == "Side1") {
                    hdn_Markup.value = Markup;
                }
                else {
                    hdn_ZoneSide2Markup.value = Markup;
                }

                var SellValue = document.getElementById(spnSellExMark).innerHTML; //.replace(/,/, '');
                var MarkupValue = (Number(SellValue) * Number(Markup)) / 100;


                var finalValue = 0;
                finalValue = Number(Number(SellValue) + Number(MarkupValue));
                finalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalValue, 0, '', false, false, true);

                document.getElementById(spn).innerHTML = finalValue;

                if (hdn_ZoneSideColor1.value == hdn_ZoneSideColor2.value) {
                    document.getElementById("spnSellingPrice_" + idlist[i] + "_" + "Side2" + "_" + i + "").innerHTML = finalValue;
                }

                var Side1Total = 0.00;
                var Side2Total = 0.00;
                Side1Total = Number(document.getElementById("spnSellingPrice_" + idlist[i] + "_" + "Side1" + "_" + i + "").innerHTML);

                if (hdn_ZoneSideColor2.value != "") {
                    Side2Total = Number(document.getElementById("spnSellingPrice_" + idlist[i] + "_" + "Side2" + "_" + i + "").innerHTML);
                }

                var TotalPrice = Number(Side1Total) + Number(Side2Total) + SetupCharge;

                if (Number(MinimumCost) >= Number(TotalPrice)) {
                    TotalPrice = Number(MinimumCost);
                }
                else {
                    TotalPrice = Number(TotalPrice);
                }

                //== Re-Eng to update MArkupPrice in tb_EstQuantity ===//              
                if (Number(MinimumCost) >= Number(TotalPrice)) {
                    hdn_MarkupPrice1.value = i == 0 ? 0 : hdn_MarkupPrice1.value;
                    hdn_MarkupPrice2.value = i == 1 ? 0 : hdn_MarkupPrice2.value;
                    hdn_MarkupPrice3.value = i == 2 ? 0 : hdn_MarkupPrice3.value;
                    hdn_MarkupPrice4.value = i == 3 ? 0 : hdn_MarkupPrice4.value;
                }
                else {
                    hdn_MarkupPrice1.value = i == 0 ? MarkupValue : hdn_MarkupPrice1.value;
                    hdn_MarkupPrice2.value = i == 1 ? MarkupValue : hdn_MarkupPrice2.value;
                    hdn_MarkupPrice3.value = i == 2 ? MarkupValue : hdn_MarkupPrice3.value;
                    hdn_MarkupPrice4.value = i == 3 ? MarkupValue : hdn_MarkupPrice4.value;
                }
                //== Re-Eng to update MArkupPrice in tb_EstQuantity ===//     

                if (i == 0) {
                    document.getElementById("spn_ZoneTotal1").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalPrice, 0, '', false, false, true);
                }
                if (i == 1) {
                    document.getElementById("spn_ZoneTotal2").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalPrice, 0, '', false, false, true);
                }
                if (i == 2) {
                    document.getElementById("spn_ZoneTotal3").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalPrice, 0, '', false, false, true);
                }
                if (i == 3) {
                    document.getElementById("spn_ZoneTotal4").innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalPrice, 0, '', false, false, true);
                }
            }
        }
    }
    else {
        Obj.value = 0;
    }
    Obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Obj.value, 0, '', false, false, true); //roundNumber(Obj.value, 2);    
}

function LockPaperUnitPrice(Obj, isLock) {
    var unitPrice = document.getElementById(Obj.id.replace('img_LockUnlock', 'txt_UnitPrice'));
    document.getElementById(Obj.id.replace('img_LockUnlock', 'hdn_paperUnitPrice')).value = unitPrice.value;
    if (document.getElementById(Obj.id).src.indexOf('lockopen') != -1) {
        isLock = 1;
    }
    else {
        isLock = 0;
    }

    if (isLock == 0) {
        document.getElementById(Obj.id).src = '../images/lockopen.png';
        unitPrice.disabled = '';
        hdn_isLock.value = "false";
    }
    else {
        hdn_isLock.value = "true";
        document.getElementById(Obj.id).src = '../images/lockclosed.png';
        unitPrice.disabled = 'disabled';
    }
}
function calculateSellingprice_onBlur(Obj, paperType, IsPricePerPack) {
    var PaperUnitPrice = document.getElementById(Obj.id).value;
    for (var i = 0; i < 4; i++) {
        var strcnct = '';
        if (i == 0) {
            strcnct = 'ctl04_';
        }
        else if (i == 1) {
            strcnct = 'ctl06_';
        }
        else if (i == 2) {
            strcnct = 'ctl08_';
        }
        else if (i == 3) {
            strcnct = 'ctl10_';
        }
        var rowid = 'ctl00_ContentPlaceHolder1_ctl00_GridPaperCostView_ctl00_' + strcnct + 'txt_UnitPrice';
        var lbl_SellingPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_SellingPrice'));
        var txt_Markup = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'txt_Markup'));
        var hdn_CostExMarkup = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_CostExMarkup'));
        var hdn_MarkupPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_MarkupPrice'));
        var lbl_MarkupPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_MarkupPrice'));
        var lbl_PackedPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_PackedPrice'));
        var lbl_Packedin = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_packedIn'));
        var hdn_NoOfPacks = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_NoOfPacks'));
        var InvSheets = "";
        if (paperType == "roll" || paperType == "web printing" || hdn_CalcType.value == "square") {
            var hdn_paperLength = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_paperLength'));
            if (hdn_paperLength) {
                InvSheets = hdn_paperLength.value;
            }
            if (InvSheets == '' || InvSheets == '0.0000000000') {
                InvSheets = hdn_invshet.value;
            }  
        }
        else {
            //var lbl_InventorySheets = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_InventorySheets'));
            var hdn_InventorySheets = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'txtPrintSheets'));
            InvSheets = hdn_InventorySheets.value;
        }
        var hdn_paperUnitPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_paperUnitPrice'))
        if (i != 0) {
            document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_UnitPrice')).innerHTML = PaperUnitPrice;
        }
        hdn_paperUnitPrice.value = PaperUnitPrice;
        if (IsPricePerPack == "True") {
            lbl_PackedPrice.innerHTML = Number(lbl_Packedin.value) * Number(PaperUnitPrice);
            hdn_CostExMarkup.value = Number(hdn_NoOfPacks.value) * Number(lbl_PackedPrice.innerHTML);
        }
        else {
            hdn_CostExMarkup.value = Number(parseFloat(InvSheets.replace(/,/g, ''))) * Number(PaperUnitPrice);
        }
        hdn_MarkupPrice.value = (Number(hdn_CostExMarkup.value) * Number(txt_Markup.value)) / 100;
        var finalValue = Number(hdn_CostExMarkup.value) + Number(hdn_MarkupPrice.value);
        lbl_SellingPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalValue, 0, '', false, false, true);
        lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, hdn_MarkupPrice.value, 0, '', false, false, true);
    }
}


function calculateSellingprice_onBlur_TotalSheets(Obj, paperType, IsPricePerPack, rowNo) {
    debugger;

    rowNo = Number(rowNo) - 1;
    //var PaperUnitPrice = document.getElementById(Obj.id).value;
    //var PaperUnitPrice = document.getElementById(Obj.id.replace('txtPrintSheets', 'txt_UnitPrice')).value;
    //for (var i = 0; i < 4; i++) {
    var strcnct = '';
    if (rowNo == 0) {
        strcnct = 'ctl04_';
    }
    else if (rowNo == 1) {
        strcnct = 'ctl06_';
    }
    else if (rowNo == 2) {
        strcnct = 'ctl08_';
    }
    else if (rowNo == 3) {
        strcnct = 'ctl10_';
    }

    var PaperUnitPrice = document.getElementById('ctl00_ContentPlaceHolder1_ctl00_GridPaperCostView_ctl00_ctl04_txt_UnitPrice').value;

    var rowid = 'ctl00_ContentPlaceHolder1_ctl00_GridPaperCostView_ctl00_' + strcnct + 'txt_UnitPrice';
    var lbl_SellingPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_SellingPrice'));
    var txt_Markup = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'txt_Markup'));
    var hdn_CostExMarkup = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_CostExMarkup'));
    var hdn_MarkupPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_MarkupPrice'));
    var lbl_MarkupPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_MarkupPrice'));
    var lbl_PackedPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_PackedPrice'));
    var lbl_Packedin = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_packedIn'));
    var hdn_NoOfPacks = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_NoOfPacks'));
    var InvSheets = "";
    if (paperType == "roll" || paperType == "web printing" || hdn_CalcType.value == "square") {
        var hdn_paperLength = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_paperLength'));
        if (hdn_paperLength) {
            InvSheets = hdn_paperLength.value;
        }
        if (InvSheets == '' || InvSheets == '0.0000000000') {
            InvSheets = hdn_invshet.value;
        }  
    }
    else {
        //var lbl_InventorySheets = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_InventorySheets'));
        var hdn_InventorySheets = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'txtPrintSheets'));
        InvSheets = hdn_InventorySheets.value;
    }
    var hdn_paperUnitPrice = document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'hdn_paperUnitPrice'))
    if (rowNo != 0) {
        //document.getElementById(rowid.replace(strcnct + 'txt_UnitPrice', strcnct + 'lbl_UnitPrice')).innerHTML = PaperUnitPrice;
    }
    hdn_paperUnitPrice.value = PaperUnitPrice;
    if (IsPricePerPack == "True") {
        lbl_PackedPrice.innerHTML = Number(lbl_Packedin.value) * Number(PaperUnitPrice);
        hdn_CostExMarkup.value = Number(hdn_NoOfPacks.value) * Number(lbl_PackedPrice.innerHTML);
    }
    else {
        hdn_CostExMarkup.value = Number(parseFloat(InvSheets.replace(/,/g, ''))) * Number(PaperUnitPrice);
        //hdn_CostExMarkup.value = Number(InvSheets) * Number(PaperUnitPrice);
    }
    hdn_MarkupPrice.value = (Number(hdn_CostExMarkup.value) * Number(txt_Markup.value)) / 100;
    var finalValue = Number(hdn_CostExMarkup.value) + Number(hdn_MarkupPrice.value);
    lbl_SellingPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalValue, 0, '', false, false, true);
    lbl_MarkupPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, hdn_MarkupPrice.value, 0, '', false, false, true);
    //}

}