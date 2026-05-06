

var TempSubTotal = 0;
var QtyStartsfrom = 0;
var QtyEndsTo = 0;
var SubWebOthercost = '';
var CalculationType = '';
var CalculationTypeID = '';
var SubItemCountebOthercost = '';
var SubItemCount = '';
var IsBind = '';

function PriceList_OpenPopup(type) {
    if (type == "viewmore") {
        div_PriceListMore.style.display = "block";
        div_PriceList.style.display = "none";
    }
    else {
        div_PriceListMore.style.display = "none";
        div_PriceList.style.display = "block";
    }
    //PopupCenter(strSitepath + "common/productpopup" + FileExtension + "?ID=" + PriceCatalogueID + "&type=" + hid_matixType.value + "", '990', '430');
}

function Tocalculate_totalPrice(Qty) {

    if (Qty == "txtHeight" || Qty == "txtWidth") {
        Qty = document.getElementById("txtqty").value;
    }

    var arrQtyFrom = hid_qtyFromList.value.split('µ');
    var arrQtyTo = hid_qtyToList.value.split('µ');
    var arrCost = hid_CostExcMarkupList.value.split('µ');
    var arrPrice = hid_priceList.value.split('µ');
    var arrMarkup = hid_MarkupList.value.split('µ');
    var arrSPOV = hdnsoldPackOV.value;
    var Dimensn;
    TempSubTotal = 0;


    for (var j = 0; j < arrQtyTo.length - 1; j++) {
        if (hid_matixType.value == "P") {
            if (j == arrQtyTo.length - 2) {
                QtyEndsTo = Number(arrQtyTo[j]);
            }
        }
        if (hid_matixType.value == "G") {
            if (j == arrQtyTo.length - 2) {
                QtyEndsTo = Number(arrQtyTo[j]);
            }
        }
        if (IsCumulative == "true") {
            if (hid_matixType.value == "S") {
                if (j == arrQtyTo.length - 2) {
                    QtyEndsTo = Number(arrQtyTo[j]);
                }
            }
        }
    }

    for (var i = 0; i < arrQtyFrom.length - 1; i++) {
        if (hid_matixType.value == "P") {
            if (Qty != '' && Number(Qty)) {
                if (i == 0) {
                    QtyStartsfrom = Number(arrQtyFrom[i]);
                }

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
                hdn_orderedquantity.value = Number(Qty);

                if (Number(Qty) <= Number(arrQtyFrom[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    //hid_QuantityPrice.value = Number(Qty) * Number(arrPrice[i]);
                    hid_QuantityPrice.value = ActualPrice;
                    break;
                }
                else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    //hid_QuantityPrice.value = Number(Qty) * Number(arrPrice[i]);
                    hid_QuantityPrice.value = ActualPrice;
                    break;
                }
                else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                    hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                    hid_Markup.value = Number(arrMarkup[i]);
                    var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                    //hid_QuantityPrice.value = Number(Qty) * Number(arrPrice[i]);
                    hid_QuantityPrice.value = ActualPrice;
                    break;
                }
                else {
                    if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                        hid_QuantityPriceExcMarkup.value = Number(Qty) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice.value = Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else {
                        hid_Markup.value = "0";
                        hid_QuantityPrice.value = "0";
                        hid_QuantityPriceExcMarkup.value = "0";
                    }
                }
            }
            else {
                if (!Number(Qty)) {
                    document.getElementById("txtqty").value = "";
                }
                else {
                    hdn_orderedquantity.value = Number(Qty);
                }
                hid_Markup.value = "0";
                hid_QuantityPrice.value = "0";
                hid_QuantityPriceExcMarkup.value = "0";

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
            }
        }
        else if (hid_matixType.value == "G") {
            if (Qty != '' && Number(Qty)) {
                if (txtHeight.value == "" || Number(txtHeight.value) == 0 || txtWidth.value == "" || Number(txtWidth.value) == 0) {
                    return false;
                }
                else {
                    if (i == 0) {
                        QtyStartsfrom = Number(arrQtyFrom[i]);
                    }

                    if (MeasurementValue == 'In.') {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                    }
                    else {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                    }

                    hdn_orderedheight.value = (Number(txtHeight.value));
                    hdn_orderedwidth.value = (Number(txtWidth.value));
                    hdn_orderedquantity.value = (Number(document.getElementById("txtqty").value));

                    hdn_orderedarea.value = (Number(hdn_orderedheight.value) * Number(hdn_orderedwidth.value))

                    if (Number(Dimensn) <= Number(arrQtyFrom[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice.value = Number(Dimensn) * Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else if (Number(Dimensn) >= Number(arrQtyFrom[i]) && Number(Dimensn) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice.value = Number(Dimensn) * Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else if (Number(Dimensn) > Number(arrQtyTo[i]) && Number(Dimensn) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice.value = Number(Dimensn) * Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                            hid_Markup.value = Number(arrMarkup[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            //hid_QuantityPrice.value = Number(Dimensn) * Number(Qty) * Number(arrPrice[i]);
                            hid_QuantityPrice.value = ActualPrice;
                            break;
                        }
                        else {
                            hid_Markup.value = "0";
                            hid_QuantityPrice.value = "0";
                            hid_QuantityPriceExcMarkup.value = "0";
                        }
                    }
                }
            }
            else {
                if (!Number(Qty)) {
                    document.getElementById("txtqty").value = "";
                }
                else {
                    hdn_orderedquantity.value = Number(Qty);
                }
                hid_Markup.value = "0";
                hid_QuantityPrice.value = "0";
                hid_QuantityPriceExcMarkup.value = "0";

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
            }
        }
        else {
            if (IsCumulative == "true") {
                Qty = txt_Cumulative_PriceQty.value;
                if (Qty != '' && Number(Qty)) {

                    if (i == 0) {
                        QtyStartsfrom = Number(arrQtyFrom[i]);
                    }
                    hdn_orderedquantity.value = Number(Qty);

                    if (Number(Qty) <= Number(arrQtyFrom[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        IsCumulativeQtyForUnitPrice = Number(arrQtyFrom[i]);
                        break;
                    }
                    else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i]);
                        break;
                    }
                    else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i + 1]);
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                            hid_Markup.value = Number(arrMarkup[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
                            IsCumulativeQtyForUnitPrice = Number(arrQtyTo[i]);
                            break;
                        }
                        else {
                            hid_QuantityPrice.value = "0";
                            hid_Markup.value = "0";
                            hid_QuantityPriceExcMarkup.value = "0";
                            IsCumulativeQtyForUnitPrice = 0;
                        }
                    }
                    hdn_orderedheight.value = "0";
                    hdn_orderedwidth.value = "0";
                    hdn_orderedarea.value = "0";
                }
                else {
                    if (!Number(Qty)) {
                        txt_Cumulative_PriceQty.value = "";
                    }
                    else {
                        hdn_orderedquantity.value = Number(Qty);
                    }
                    hid_QuantityPrice.value = "0";
                    hid_QuantityPriceExcMarkup.value = "0";
                    hid_Markup.value = "0";

                    hdn_orderedheight.value = "0";
                    hdn_orderedwidth.value = "0";
                    hdn_orderedarea.value = "0";
                }
            } else {
                var sellingPrice = ddlPriceQty.options[ddlPriceQty.selectedIndex].value.split('~');
                hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                hid_QuantityPrice.value = sellingPrice[1];
                QtyStartsfrom = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                QtyEndsTo = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;

                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
                hdn_orderedquantity.value = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
            }
        }
    }

    if (hid_matixType.value == "P") {
        if (Qty != '' && Number(Qty)) {
            if (QtyStartsfrom > Number(Qty)) {
                spn_qty.style.display = 'block';
                //spn_qty.innerHTML = "Minimum Quantity is " + QtyStartsfrom + "";
                spn_qty.innerHTML = Minimum_Quantity_Is + QtyStartsfrom + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";

                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else if (QtyEndsTo < Number(Qty)) {
                spn_qty.style.display = 'block';
                //spn_qty.innerHTML = "Maximum Quantity is " + QtyEndsTo + "";
                spn_qty.innerHTML = Maximum_Quantity_is + QtyEndsTo + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else if (!(Qty % arrSPOV == 0)) {
                spn_qty.style.display = 'block';
                spn_qty.innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                return false;
            }
            else {
                spn_qty.style.display = 'none';
            }
        }
    }

    if (hid_matixType.value == "G") {
        if (Dimensn != '' && Number(Dimensn)) {
            if (QtyStartsfrom > Number(Dimensn)) {
                spn_Dimensn.style.display = 'block';
                spnDimensn.innerHTML = Minimum_Dimension_Is + QtyStartsfrom + " " + MeasurementValue_Sq + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";

                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else if (QtyEndsTo < Number(Dimensn)) {
                spn_Dimensn.style.display = 'block';
                spnDimensn.innerHTML = Maximum_Dimension_Is + QtyEndsTo + " " + MeasurementValue_Sq + "";
                document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                if (hid_MultipleLenght.value != "0") {
                    for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                        var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                        if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                            for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {
                                document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        } else {
                            document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                }
                if (hid_MatrixLenght.value != "0") {
                    for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                        document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                if (hid_QuestionLenght.value != "0") {
                    for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                        document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    }
                }
                return false;
            }
            else {
                spn_Dimensn.style.display = 'none';
            }
        }
    }

    if (hid_matixType.value == "S") {
        if (IsCumulative == "true") {
            if (Qty != '' && Number(Qty)) {
                if (QtyStartsfrom > Number(Qty)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = Minimum_Quantity_Is + QtyStartsfrom + "";
                    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    if (hid_MultipleLenght.value != "0") {
                        for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {
                                    document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                                }
                            } else {
                                document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        }
                    }
                    if (hid_MatrixLenght.value != "0") {
                        for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                            document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    if (hid_QuestionLenght.value != "0") {
                        for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                            document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    return false;
                }
                else if (QtyEndsTo < Number(Qty)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = Maximum_Quantity_is + QtyEndsTo + "";
                    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    if (hid_MultipleLenght.value != "0") {
                        for (var k = 0; k <= Number(hid_MultipleLenght.value) - 1; k++) {
                            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + k);
                            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {
                                    document.getElementById("lblMultiplePrice_" + k + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                                }
                            } else {
                                document.getElementById("lblMultiplePrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                            }
                        }
                    }
                    if (hid_MatrixLenght.value != "0") {
                        for (var l = 0; l <= Number(hid_MatrixLenght.value) - 1; l++) {
                            document.getElementById("lblMatrixPrice_" + l + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    if (hid_QuestionLenght.value != "0") {
                        for (var m = 0; m <= Number(hid_QuestionLenght.value) - 1; m++) {
                            document.getElementById("lblPrice_" + m + "").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                        }
                    }
                    return false;
                }
                else if (!(Qty % arrSPOV == 0)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
                    document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    return false;
                }
                else {
                    document.getElementById("spn_qty").style.display = 'none';
                }
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var l = 0; l <= hid_MatrixLenght.value - 1; l++) {
            var lblMatrixID = document.getElementById("lblMatrixID_" + l + "").innerHTML;
            var lblMatrixType = document.getElementById("lblMatrixType_" + l + "").innerHTML;
            MatrixCheck_value(lblMatrixID, l, lblMatrixType);
        }
    }

    if (hid_QuestionLenght.value != "0") {
        for (var q = 0; q <= hid_QuestionLenght.value - 1; q++) {
            var Formula1 = document.getElementById("lblQuestionFormula_" + q + "").innerHTML;

            var FormulaTag = Formula1;
            for (var i = 0; i <= Formula1.length; i++) {
                FormulaTag = FormulaTag.replace(' ', '').replace(' ', '').replace('</question>', '').replace('</quantity>', '').replace('</input>', '').replace('</ProductBasePrice>', '').replace('</productbaseprice>', '').replace('</SubTotal>', '').replace(' ', '');
            }

            CalculatePrice_Question_SubTotal(FormulaTag, q); //For <Subtotal> Calculation
            CalculatePrice_Question(Formula1, q, TempSubTotal);
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var c = 0; c <= hid_MultipleLenght.value - 1; c++) {
            Onchange_MultipleChoice_SubTotal(c); //For <Subtotal> Calculation
            Onchange_MultipleChoice(c, TempSubTotal);
        }
    }

    setInterval("TakeOut()", 10000);
    Final_SellingPrice_SubTotal();

    Final_SellingPrice();

}

function TakeOut() {
    var i = 0;
    for (var l = 0; l < 200; l++) {
        i++;
    }
}

function CalculatePrice_Question(Formula, ID, TempSubTotal) {
    var sellingPrice = '';
    var txtQuestion = document.getElementById("txtQuestion_" + ID + "");
    var GroupID = document.getElementById("lblQuestionGroupID_" + ID + "").innerHTML;
    var OtherCostID = document.getElementById("lblQuestionID_" + ID + "").innerHTML;
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");
    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';

    if (txtQuestion.value != '' && Number(txtQuestion.value) != 0 && Number(txtQuestion.value) && txtQuestion.getAttribute("grpvalue") == "1") {

        var IsSubTotal = false;
        if (Formula.indexOf("[$SubTotal$]") != -1 || Formula.indexOf("[$subtotal$]") != -1) {
            IsSubTotal = true;
        }

        var FormulaTag = Formula;
        for (var i = 0; i <= Formula.length; i++) {
            FormulaTag = FormulaTag.replace('<question>', txtQuestion.value).replace('<quantity>', txtQuestion.value).replace('<input>', txtQuestion.value).replace('[$ProductBasePrice$]', Number(hid_QuantityPrice.value)).replace('[$productbaseprice$]', Number(hid_QuantityPrice.value)).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace(' ', '').replace('</question>', '').replace('</productbaseprice>', '').replace('</subtotal>', '').replace('#', '%').replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
        }

        if ((!IsSubTotal) || (IsSubTotal == true && Number(TempSubTotal) != 0)) {
            var dd = eval(FormulaTag);
            if (!isNaN(dd)) {
                //ePrint.PublicStores.ePrint.PublicStores.AutoFill.CalculateFormulaCost(dd, ID, GetResult, onTimeout, onError);
                document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(dd, true);
            }
            else {
                document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            }
            Final_SellingPrice();
        }
        else {
            document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        }
        Final_SellingPrice();
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        Final_SellingPrice();
    }
}

function CalculatePrice_Question_SubTotal(Formula, ID) {
    var sellingPrice = '';
    var txtQuestion = document.getElementById("txtQuestion_" + ID + "");

    if (txtQuestion.value != '' && Number(txtQuestion.value) != 0 && Number(txtQuestion.value)) {
        var IsSubTotal = false;
        if (Formula.indexOf("[$SubTotal$]") != -1 || Formula.indexOf("[$subtotal$]") != -1) {
            IsSubTotal = true;
        }

        if (IsSubTotal) {
            document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        }
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
    }
}

function GetResult(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblPrice_" + NewResult[1] + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false), true);
        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}

function MatrixCheck_value(OthercostID, ID, MatrixType) {
    var quantity = '';
    var GroupID = document.getElementById("lblMatrixGroupID_" + ID + "").innerHTML;
    if (hid_matixType.value == "P") {
        quantity = document.getElementById("txtqty").value;
    }
    else if (hid_matixType.value == "G") {
        quantity = document.getElementById("txtqty").value;
    }
    else {
        if (IsCumulative == "true") {
            quantity = txt_Cumulative_PriceQty.value;
        } else {
            quantity = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }
    var chkbox = document.getElementById("chkMatrix_" + ID + "");

    if (quantity != "" && quantity != "0") {
        if (MatrixType != "pricebands") {
            //chkbox.checked = true;
        }
    }


    if (chkbox.checked && chkbox.getAttribute("grpvalue") == "1") {
        if (MatrixType == "pricebands") {
            if (quantity != '' && quantity != '0') {
                if (OthercostID != '0') {
                    AutoFill.GetMatrixValue(Number(OthercostID), Number(quantity), ID, GetResultMatrix, onTimeout, onError);
                    Final_SellingPrice();
                    spn_qty.style.display = "none";
                }
            }
            else {
                spn_qty.style.display = "block";
                chkbox.checked = false;
                document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false), true);
                Final_SellingPrice();
                if (IsCumulative == "true") {
                    txt_Cumulative_PriceQty.focus();
                } else {
                    document.getElementById("txtqty").focus();
                }
            }
        }
        else {
            if (quantity != '' && quantity != '0') {
                var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ddlMatrix_" + ID);
                var QtyMatched = false;
                var MatrixSellingPrice = '';
                for (var ddl = 0; ddl <= ddlMatrix.length - 1; ddl++) {
                    if (Number(quantity) <= Number(ddlMatrix[ddl].text)) {
                        ddlMatrix.selectedIndex = ddl;
                        // QtyMatched = true;
                        var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                        var ddlMatrixValue1 = ddlMatrixValue.split('~');
                        //  MatrixSellingPrice = parseFloat(parseFloat(ddlMatrixValue1[0]) + Math.round(((parseFloat(ddlMatrixValue1[0]) * parseFloat(ddlMatrixValue1[1])) / 100)), 3);
                        MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);
                        break;
                        // By 018 (Gaj instruction)
                        //MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);

                    }
                    else {

                        ddlMatrix.selectedIndex = ddl;
                        // QtyMatched = true;
                        var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                        var ddlMatrixValue1 = ddlMatrixValue.split('~');
                        //  MatrixSellingPrice = parseFloat(parseFloat(ddlMatrixValue1[0]) + Math.round(((parseFloat(ddlMatrixValue1[0]) * parseFloat(ddlMatrixValue1[1])) / 100)), 3);
                        MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);

                    }
                }

                document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, MatrixSellingPrice, 2, '', false, false, false), true);
                Final_SellingPrice();
                spn_qty.style.display = "none";
            }
            else {
                var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ddlMatrix_" + ID);
                ddlMatrix.selectedIndex = 0;
                chkbox.checked = false;
                spn_qty.style.display = "block";
                Final_SellingPrice();
                if (IsCumulative == "true") {
                    txt_Cumulative_PriceQty.focus();
                } else {
                    document.getElementById("txtqty").focus();
                }
            }
        }
    }
    else {
        document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false), true);
        Final_SellingPrice();
    }
}

function GetResultMatrix(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMatrixPrice_" + NewResult[1] + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(NewResult[0] * NewResult[5]), 2, '', false, false, false), true);
        document.getElementById("lblMatrixCostMarkup_" + NewResult[1] + "").innerHTML = NewResult[2] + "~" + NewResult[3] + "~" + NewResult[4] + "~" + NewResult[5];
        Final_SellingPrice();
    }
}

function Onchange_SimpleMatrix(ID) {
    var GroupID = document.getElementById("lblMatrixGroupID_" + ID + "").innerHTML;
    var OtherCostID = document.getElementById("lblMatrixID_" + ID + "").innerHTML;

    var chkbox = document.getElementById("chkMatrix_" + ID + "");
    var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ddlMatrix_" + ID);
    if (chkbox.checked || ddlMatrix.options[ddlMatrix.selectedIndex].value != "0") {
        if (ddlMatrix.options[ddlMatrix.selectedIndex].value != "0" && chkbox.getAttribute("grpvalue") == "1") {
            var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
            var ddlMatrixValue1 = ddlMatrixValue.split('~');
            var MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);
            chkbox.checked = true;
            document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, MatrixSellingPrice, 2, '', false, false, false), true);
            Final_SellingPrice();
        }
        else {
            chkbox.checked = false;
            document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false), true);
            Final_SellingPrice();
        }
    }
}

function SubMultipleValueID(id) {
    SubItemCountebOthercost = id;
    Tocall_mainFunc();
}

function Onchange_MultipleChoice(ID, TempSubTotal) {
    debugger
    var GroupID = document.getElementById("lblMultipleGroupID_" + ID + "").innerHTML;
    var OthercostID = document.getElementById("lblMultipleID_" + ID + "").innerHTML;

    var quantity = '';
    if (hid_matixType.value == "P") {
        var quantity = document.getElementById("txtqty").value;
    }
    else if (hid_matixType.value == "G") {
        var quantity = document.getElementById("txtqty").value;
    }
    else {
        if (IsCumulative == "true") {
            quantity = txt_Cumulative_PriceQty.value;
        } else {
            quantity = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");
    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';

    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID);

    var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {

        if (chkMultiple.checked || ddlMultiple.options.length != 0) {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                if ('2' == '1') {
                    chkMultiple.checked = false;
                    for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {
                        document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    }
                }
                else {

                    for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {

                        var SubddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC);
                        if (SubddlMultiple.options[SubddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                            var SubddlMultipleValue = SubddlMultiple.options[SubddlMultiple.selectedIndex].value;
                            var SubMultipleValue = SubddlMultipleValue.split('~');

                            if (quantity != '') {
                                var IsSubTotal = false;
                                if (SubMultipleValue[0].indexOf("[$SubTotal$]") != -1 || SubMultipleValue[0].indexOf("[$subtotal$]") != -1) {
                                    IsSubTotal = true;
                                }

                                if ((!IsSubTotal) || (IsSubTotal == true && Number(TempSubTotal) != 0)) {
                                    var FormulaTagMul = '';
                                    FormulaTagMul = SubMultipleValue[0];


                                    for (var i = 0; i <= FormulaTagMul.length; i++) {
                                        FormulaTagMul = FormulaTagMul.replace('<quantity>', quantity).replace('[$ProductBasePrice$]', hid_QuantityPrice.value).replace('[$productbaseprice$]', hid_QuantityPrice.value).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                                    }

                                    var dd = eval(FormulaTagMul);
                                    if (!isNaN(dd)) {
                                        //AutoFill.CalculateFormulaCost_ForMultipleChoice(dd, Number(SubMultipleValue[1]), document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).id, GetResultSubMultiple, onTimeout, onError);
                                        document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate(dd, true);
                                        Final_SellingPrice();
                                    }
                                    else {
                                        document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                        Final_SellingPrice();
                                    }
                                }
                                else {
                                    document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                }
                                chkMultiple.checked = true;
                                document.getElementById("spn_qty").style.display = "none";
                            }
                        }
                        else
                        {
                            document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                            Final_SellingPrice();
                        }
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                Final_SellingPrice();
            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            Final_SellingPrice();
        }
    } else {
        if (ddlMultiple.getAttribute("grpvalue") == "1") {
            if (chkMultiple.checked || ddlMultiple.options.length != 0) {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" &&
                ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" &&
                ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                    if ('2' == '1') {
                        chkMultiple.checked = false;
                        document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    }
                    else {
                        var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                        var MultipleValue = ddlMultipleValue.split('~');

                        if (quantity != '') {
                            var IsSubTotal = false;
                            if (MultipleValue[0].indexOf("[$SubTotal$]") != -1 || MultipleValue[0].indexOf("[$subtotal$]") != -1) {
                                IsSubTotal = true;
                            }

                            if ((!IsSubTotal) || (IsSubTotal == true && Number(TempSubTotal) != 0)) {

                                var FormulaTagMul = '';
                                FormulaTagMul = MultipleValue[0];
                                for (var i = 0; i <= FormulaTagMul.length; i++) {
                                    FormulaTagMul = FormulaTagMul.replace('<quantity>', quantity).replace('[$ProductBasePrice$]', hid_QuantityPrice.value).replace('[$productbaseprice$]', hid_QuantityPrice.value).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                                }

                                var dd = eval(FormulaTagMul);
                                if (!isNaN(dd)) {
                                    AutoFill.CalculateFormulaCost_ForMultipleChoice(dd, Number(MultipleValue[1]), ID, GetResultMultiple, onTimeout, onError);
                                    //document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate(dd, true);
                                    Final_SellingPrice();
                                }
                                else {
                                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                    Final_SellingPrice();
                                }
                            }
                            else {
                                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                            }
                            chkMultiple.checked = true;
                            spn_qty.style.display = "none";
                        }
                        else {
                            ddlMultiple.selectedIndex = 0;
                            spn_qty.style.display = "block";
                            chkMultiple.checked = false;
                        }
                    }
                }
                else {
                    chkMultiple.checked = false;
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    Final_SellingPrice();
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                Final_SellingPrice();
            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            Final_SellingPrice();
        }
    }
}

function GetResultMultiple(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMultiplePrice_" + NewResult[1] + "").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false), true);
        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}

function GetResultSubMultiple(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById(NewResult[1]).innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false), true);
        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}

function Onchange_MultipleChoice_SubTotal(ID) {
    var quantity = '';
    if (hid_matixType.value == "P") {
        var quantity = document.getElementById("txtqty").value;
    }
    else if (hid_matixType.value == "G") {
        var quantity = document.getElementById("txtqty").value;
    }
    else {
        if (IsCumulative == "true") {
            quantity = txt_Cumulative_PriceQty.value;
        } else {
            quantity = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");
    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID);
    var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID);

    var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
        if (chkMultiple.checked || ddlMultiple.options.length != 0) {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                if ('2' == '1') {
                    chkMultiple.checked = false;
                    for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {
                        document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    }
                }
                else {
                    for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {

                        var SubddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC);
                        if (SubddlMultiple.options[SubddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                            var SubddlMultipleValue = SubddlMultiple.options[SubddlMultiple.selectedIndex].value;
                            var SubMultipleValue = SubddlMultipleValue.split('~');

                            if (quantity != '') {

                                var IsSubTotal = false;
                                var FormulaTagMul = SubMultipleValue[0];

                                if (FormulaTagMul.indexOf("[$SubTotal$]") != -1 || FormulaTagMul.indexOf("[$subtotal$]") != -1)//TempSubTotal != 0 &&
                                {
                                    IsSubTotal = true;
                                }
                                if (IsSubTotal) {
                                    document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                                }
                                chkMultiple.checked = true;
                                document.getElementById("spn_qty").style.display = "none";
                            }
                            else {
                                ddlMultiple.selectedIndex = 0;
                                document.getElementById("spn_qty").style.display = "block";
                                chkMultiple.checked = false;
                            }
                        }
                        else {
                            document.getElementById("lblMultiplePrice_" + ID + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                        }
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            }
        }
        else {
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        }
    } else {
        if (chkMultiple.checked || ddlMultiple.options.length != 0) {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" &&
            ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" &&
            ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                if ('2' == '1') {
                    chkMultiple.checked = false;
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                }
                else {
                    var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                    var MultipleValue = ddlMultipleValue.split('~');

                    if (quantity != '') {

                        var IsSubTotal = false;
                        var FormulaTagMul = MultipleValue[0];

                        if (FormulaTagMul.indexOf("[$SubTotal$]") != -1 || FormulaTagMul.indexOf("[$subtotal$]") != -1)//TempSubTotal != 0 &&
                        {
                            IsSubTotal = true;
                        }
                        if (IsSubTotal) {
                            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                        }
                        chkMultiple.checked = true;
                        spn_qty.style.display = "none";
                    }
                    else {
                        ddlMultiple.selectedIndex = 0;
                        spn_qty.style.display = "block";
                        chkMultiple.checked = false;
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        }
    }
}

function Final_SellingPrice() {
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var MatrixPrice = '0';
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");
    if (hid_QuestionLenght.value != "0") {
        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
            QuestionPrice = Number(QuestionPrice) + Number(document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {
                    MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                }
            } else {
                MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
            MatrixPrice = Number(MatrixPrice) + Number(document.getElementById("lblMatrixPrice_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    QuestionPrice = QuestionPrice != 'NaN' ? QuestionPrice : '0';
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    MatrixPrice = MatrixPrice != 'NaN' ? MatrixPrice : '0';

    var sellingPrice = Number(hid_QuantityPrice.value) + Number(QuestionPrice) + Number(MultiplePrice) + Number(MatrixPrice);

    lbltotal.innerHTML = '0';
    lbltotal.innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice), 2, '', false, false, false), true);

    lblunitprice.innerHTML = '0';
    lblunitprice.innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice / hdn_orderedquantity.value), 2, '', false, false, false), true);
    lblpackprice.innerHTML = '0';
    lblpackprice.innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice / (hdn_orderedquantity.value / hdnsoldPackOV.value)), 2, '', false, false, false), true);

    hdnlbltotal.value = parseFloat(sellingPrice);
    TaxOnChange();
}

function Final_SellingPrice_SubTotal() {
    TempSubTotal = 0;
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var MatrixPrice = '0';
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");

    setInterval("TakeOut()", 100000);

    if (hid_QuestionLenght.value != "0") {
        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
            QuestionPrice = Number(QuestionPrice) + Number(document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
            var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                for (var SC = 0; SC <= Number(ddlValue.split('~')[4]) - 1 ; SC++) {
                    MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "_" + ddlValue.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                }
            } else {
                MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
            MatrixPrice = Number(MatrixPrice) + Number(document.getElementById("lblMatrixPrice_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
        }
    }

    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    QuestionPrice = QuestionPrice != 'NaN' ? QuestionPrice : '0';
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    MatrixPrice = MatrixPrice != 'NaN' ? MatrixPrice : '0';

    var sellingPrice = Number(hid_QuantityPrice.value) + Number(QuestionPrice) + Number(MultiplePrice) + Number(MatrixPrice);
    TempSubTotal = sellingPrice;
    if (hid_MultipleLenght.value != "0") {
        for (var c = 0; c <= hid_MultipleLenght.value - 1; c++) {
            Onchange_MultipleChoice(c, TempSubTotal);
        }
    }

    if (hid_QuestionLenght.value != "0") {
        for (var q = 0; q <= hid_QuestionLenght.value - 1; q++) {
            var Formula1 = document.getElementById("lblQuestionFormula_" + q + "").innerHTML;
            var FormulaTag = Formula1;
            for (var i = 0; i <= Formula1.length; i++) {
                FormulaTag = FormulaTag.replace(' ', '').replace(' ', '').replace('</question>', '').replace('</quantity>', '').replace('</input>', '').replace('</ProductBasePrice>', '').replace('</productbaseprice>', '').replace('</SubTotal>', '').replace(' ', '');
            }
            CalculatePrice_Question(FormulaTag, q, TempSubTotal);
        }
    }
}

function TaxOnChange() {
    var TaxRate = document.getElementById("lblTaxRate").innerHTML;
    var lblTotalTax = document.getElementById("lblTotalTax");
    var TotalPrice = Number(hdnlbltotal.value); //lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
    var TotalTax = 0;
    if (TotalPrice != '0.00') {
        TotalTax = Number((Number(TotalPrice) * Number(TaxRate)) / 100);
        lblTotalTax.innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalTax), 2, '', false, false, false), true);
        hdnTotalTaxValue.value = parseFloat(TotalTax);
    }
    else {
        lblTotalTax.innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        hdnTotalTaxValue.value = Number(0);
    }
    var TotalSellingPrice = Number(TotalPrice) + Number(TotalTax);
    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalSellingPrice), 2, '', false, false, false), true);
    hdnTotalSellingPriceValue.value = parseFloat(TotalSellingPrice);
    if (document.getElementById("lbl_WithoutTax") != null)
        document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate(Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalPrice), 2, '', false, false, false), true);
}

function IsValidFile(filename) {
    var lastDot = filename.lastIndexOf(".");
    var pathLength = filename.length;
    var fileType = filename.substring(lastDot, pathLength);

    if ((fileType.toLowerCase() != ".exe") && (fileType.toLowerCase() != ".asp") && (fileType.toLowerCase() != ".html") && (fileType.toLowerCase() != ".php") && (fileType.toLowerCase() != ".dll") && (fileType.toLowerCase() != ".aspx") && (fileType.toLowerCase() != ".jar")) {
        return true;
    }
    else {
        return false;
    }

}

function Save_toCart(val) {

    //Added by shahbaz for validating upload file
    var fileupload = $('input[type=file');
    for (var i = 0; i < fileupload.length; i++) {
        if (fileupload[i].files.length > 0) {
            var filename = fileupload[i].files[0].name;
            if (!IsValidFile(filename)) {
                alert("Do not upload exe, asp, aspx, dll, php, html, jar types of files")
                return false;
            }
        }
    }
    //End

    var FinalCheck = false;

    var DrawStockFrom = document.getElementById("ctl00_ContentPlaceHolder1_hdnDrawStockFrom").value;
    var IsStockItem = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsStockItem").value;
    var div_ProdSelectErrorMSG = document.getElementById("ctl00_ContentPlaceHolder1_div_ProdSelectErrorMSG");

    if (document.getElementById("ctl00_ContentPlaceHolder1_div_ProductOptions").style.display != "none") {
        var ddlOtherMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlProductList");
        var selectedText = ddlOtherMultiple.options[ddlOtherMultiple.selectedIndex].text;

        if (selectedText.toLowerCase() == "--select--") {
            div_ProdSelectErrorMSG.style.display = "block";
            return false;
        }
    }

    if (hid_matixType.value == "P") {
        Qty = document.getElementById("txtqty").value;
    }
    else if (hid_matixType.value == "G") {
        Qty = document.getElementById("txtqty").value;
    }
    else {
        if (IsCumulative == "true") {
            Qty = txt_Cumulative_PriceQty.value;
        } else {
            Qty = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }


    if (Qty == '' || Qty == '0') {
        spn_qty.style.display = "block";
        FinalCheck = true;

        if (IsCumulative == "true") {
            txt_Cumulative_PriceQty.focus();
        } else {
            document.getElementById("txtqty").focus();
        }
        return false;
    }
    else if (Qty < QtyStartsfrom || Qty > QtyEndsTo) {
        if (hid_matixType.value != "G") {
            spn_qty.style.display = "block";
            FinalCheck = true;
            if (IsCumulative == "true") {
                txt_Cumulative_PriceQty.focus();
            } else {
                document.getElementById("txtqty").focus();
            }
            if (Qty < QtyStartsfrom) {
                spn_qty.innerHTML = "Minimum Quantity is " + QtyStartsfrom + "";
            }
            else if (Qty > QtyEndsTo) {
                spn_qty.innerHTML = "Maximum Quantity is " + QtyEndsTo + "";
            }
        }
        return false;
    }

    else if (!Number(Qty)) {
        if (hid_matixType == "P") {
            spn_qty.style.display = "block";
            spn_qty.innerHTML = "please Enter Only Number";
        }
        if (hid_matixType == "G") {
            spn_qty.style.display = "block";
            spn_qty.innerHTML = "please Enter Only Number";
        }
        FinalCheck = true;

        if (IsCumulative == "true") {
            txt_Cumulative_PriceQty.focus();
        } else {
            document.getElementById("txtqty").focus();
        }
        return false;
    }
    else {
        spn_qty.style.display = "none";
    }


    var arrSPOV = hdnsoldPackOV.value;
    if (DrawStockFrom.toLowerCase() == "x" && IsStockItem.toLowerCase() == "true") {
        //alert(modulename.toLowerCase());
        alert("This product can not currently be ordered. Please contact the system administrator and ask them to check the stock settings");
        return false;
    }
    else if (!(Qty % arrSPOV == 0) && hid_matixType.value != "S") {
        document.getElementById("spn_qty").style.display = 'block';
        document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
        document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("txtqty").focus();
        return false;
    }
    else if (!(Qty % arrSPOV == 0) && hid_matixType.value == "S" && IsCumulative == "true") {
        document.getElementById("spn_qty").style.display = 'block';
        document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
        document.getElementById("lbl_WithoutTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        if (IsCumulative == "true") {
            txt_Cumulative_PriceQty.focus();
        } else {
            document.getElementById("txtqty").focus();
        }
        return false;
    }
    else {
        var SaveToAdditionalItemsQuestion = '';
        var SaveToAdditionalItemsMultiple = '';
        var SaveToAdditionalItemsMatrix = '';
        var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPrice");
        var hid_QuantityPriceExcMarkup = document.getElementById("ctl00_ContentPlaceHolder1_hid_QuantityPriceExcMarkup");

        var btnAddtoCart1 = document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1");
        var btnAddtoCart = document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart");
        var img_AddtoCart1 = document.getElementById("ctl00_ContentPlaceHolder1_img_AddtoCart1");
        var img_AddtoCart = document.getElementById("ctl00_ContentPlaceHolder1_img_AddtoCart");

        //For simple single question Type - added by rk for 2853
        if (Number(hid_QuestionLenght.value) != 0) {
            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {

                var QuestionOtherCostID = document.getElementById("lblQuestionID_" + i + "").innerHTML;
                var txtQuestion = document.getElementById("txtQuestion_" + i + "");
                if (Number(txtQuestion.value) != 0 && Number(QuestionOtherCostID) != 0 && txtQuestion != null) {
                    hdnSingleQuestionValues.value += QuestionOtherCostID + "»" + txtQuestion.value + "μ";
                }
            }
        }

        if (artworkFile == "M") {
            if (hid_QuestionLenght.value != "0" || hid_MultipleLenght.value != "0" || hid_MatrixLenght.value != "0") {
                if (fp_artwork.value == "") {
                    spn_artworkFile.style.display = "block";
                    FinalCheck = true;
                }
            }
            else {
                if (fp_artwork_no_addoption1.value == "") {
                    spn_artworkFile1.style.display = "block";
                    FinalCheck = true;
                }
            }
        }

        var Dimensn;
        hid_SaveToCart.value = "CookieID~0»UserID~0»CartTotalPrice~" + Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '')) + "»CartTax~" + Number(document.getElementById("lblTotalTax").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '')) + "»CartShipping~0";
        var UnitPrice = '';
        if (IsCumulative == "true") {
            var TempQty = Qty;
            Qty = IsCumulativeQtyForUnitPrice;
            if (Qty != '' || Qty != 0) {
                UnitPrice = Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '')) / Number(Qty);
                if (hid_matixType.value == "G") {
                    if (MeasurementValue == 'In.') {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                    }
                    else {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                    }
                }
            }
            else {
                UnitPrice = "0";
            }
            Qty = TempQty;
        } else {
            if (Qty != '' || Qty != 0) {
                UnitPrice = Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '')) / Number(Qty);
                if (hid_matixType.value == "G") {
                    if (MeasurementValue == 'In.') {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                    }
                    else {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                    }
                    //UnitPrice = Number(UnitPrice) / Number(Dimensn);
                }
            }
            else {
                UnitPrice = "0";
            }
        }
        var TaxRate = document.getElementById("lblTaxRate").innerHTML;
        var TaxID = document.getElementById("lblTaxID").innerHTML;

        var Height = 0;
        var Width = 0;

        if (hid_matixType.value == "G") {
            Height = Number(txtHeight.value);
            Width = Number(txtWidth.value);

            if (Height == 0 && Width == 0) {
                spn_Dimensn.style.display = "block";
                if (!FinalCheck) {
                    txtWidth.focus();
                }
                FinalCheck = true;
                spnDimensn.innerHTML = Please_enter_dimension;
            }
            else if (Height == 0) {
                spn_Dimensn.style.display = "block";
                FinalCheck = true;
                txtHeight.focus();
                spnDimensn.innerHTML = Please_enter_height;
            }
            else if (Width == 0) {
                spn_Dimensn.style.display = "block";
                FinalCheck = true;
                txtWidth.focus();
                spnDimensn.innerHTML = Please_enter_width;
            }
            else {
                spn_Dimensn.style.display = "none";
                spnDimensn.innerHTML = '';
            }

            if (Dimensn < QtyStartsfrom || Dimensn > QtyEndsTo) {
                spn_Dimensn.style.display = "block";
                FinalCheck = true;
                if (Dimensn < QtyStartsfrom) {
                    spnDimensn.innerHTML = Minimum_Dimension_Is + QtyStartsfrom + " " + MeasurementValue_Sq + "";
                }
                else if (Dimensn > QtyEndsTo) {
                    spnDimensn.innerHTML = Maximum_Dimension_Is + QtyEndsTo + " " + MeasurementValue_Sq + "";;
                }
            }
        }

        var mainPriceExcMarkup = Number(hid_QuantityPrice.value) - Number(hid_QuantityPriceExcMarkup.value);
        hid_SaveToCartItems.value = "" + Qty + "»" + Number(UnitPrice) + "»" + Number(hid_QuantityPrice.value) + "»" + mainPriceExcMarkup + "»" + TaxRate + "»" + TaxID + "»" + Height + "»" + Width;

        if (Number(hid_QuestionLenght.value) != 0) {
            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                var QuestionQty = document.getElementById("txtQuestion_" + i + "").value;
                var SortOrderNo = document.getElementById("lblQuestionSortOrderNo_" + i + "").innerHTML;

                if (QuestionQty != '' && QuestionQty != 0) {
                    var OthercostID = document.getElementById("lblQuestionID_" + i).innerHTML;
                    var TotalPrice = document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    var FormulaTag = document.getElementById("lblQuestionFormula_" + i).innerHTML.replace('</quantity>', '').replace('</question>', '').replace('</ProductBasePrice>', '').replace('</SubTotal>', '');

                    var Formula = FormulaTag;
                    for (var f = 0; f <= FormulaTag.length; f++) {
                        Formula = Formula.replace('<question>', QuestionQty).replace('<quantity>', QuestionQty).replace('<input>', QuestionQty).replace('[$ProductBasePrice$]', Number(hid_QuantityPrice.value)).replace('[$productbaseprice$]', Number(hid_QuantityPrice.value)).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace(' ', '').replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                    }

                    var MarkUp = 0;
                    var MarkupValue = 0;
                    var SelectedValue = '';

                    SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±SortOrderNo»" + SortOrderNo + "µ";
                }
            }
        }

        if (Number(hid_MultipleLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                var Check = document.getElementById("chkMultiple_" + j);
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1' && ddlMultiple.getAttribute("IsMandatory") == "1") {
                    alert("Additional options marked with a * are mandatory");
                    return false;
                }
                if (Check.checked) {
                    var SortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "").innerHTML;
                    var OthercostID = document.getElementById("lblMultipleID_" + j).innerHTML;
                    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
                    var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

                    if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                        if (ddlMultiple.getAttribute('isgroup') == 'maingroup') {

                            var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                            var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].text;
                            ddlMultipleValue = ddlMultipleValue.split('~');

                            var FormulaTagMul = '';
                            var Formula = '';

                            var MarkUp = 0;
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = 0;

                            var MarkupValue = 0;

                            var TotalPrice = document.getElementById("lblMultiplePrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "±ParentWebOtherCostID»0±WebOtherCostType»maingroup" + "µ";
                            }

                            for (var SC = 0; SC <= Number(ddlMultipleValue[4]) - 1 ; SC++) {

                                var SubSortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "_" + ddlMultipleValue[2] + "_" + SC).innerHTML;
                                var SubOthercostID = document.getElementById("lblMultipleID_" + j + "_" + ddlMultipleValue[2] + "_" + SC).innerHTML;

                                var SubddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j + "_" + ddlMultipleValue[2] + "_" + SC);
                                if (SubddlMultiple.options[SubddlMultiple.selectedIndex].value.split('~')[6] == '1' && SubddlMultiple.getAttribute("IsMandatory") == "1") {
                                    alert("Additional options marked with a * are mandatory");
                                    return false;
                                }
                                var SubddlMultipleValue = SubddlMultiple.options[SubddlMultiple.selectedIndex].value;
                                var SubSelectedValue = SubddlMultiple.options[SubddlMultiple.selectedIndex].text;
                                var SubMultipleValue = SubddlMultipleValue.split('~');

                                if (SubSelectedValue.toLowerCase().trim() != "---select---") {
                                    var FormulaTagMul = SubMultipleValue[0];
                                    var Formula = '';

                                    for (var i = 0; i <= Formula.length; i++) {
                                        FormulaTagMul = FormulaTagMul.replace('<quantity>', Qty).replace('[$ProductBasePrice$]', hid_QuantityPrice.value).replace('[$productbaseprice$]', Number(hid_QuantityPrice.value)).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                                    }

                                    var MarkUp = SubMultipleValue[1];
                                    var SelectedID = SubMultipleValue[2];
                                    var SelectedPrice = eval(FormulaTagMul);

                                    var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);

                                    if (isNaN(MarkupValue)) {
                                        MarkupValue = 0;
                                    }
                                    Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                                    var TotalPrice = document.getElementById("lblMultiplePrice_" + j + "_" + ddlMultipleValue[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                                    if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                                        SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + SubOthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SubSelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SubSortOrderNo + "±ParentWebOtherCostID»" + OthercostID + "±WebOtherCostType»subgroup" + "µ";
                                    }
                                }
                            }
                        } else {

                            var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                            var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].text;
                            ddlMultipleValue = ddlMultipleValue.split('~');

                            var FormulaTagMul = ddlMultipleValue[0];
                            var Formula = '';

                            for (var i = 0; i <= Formula.length; i++) {
                                FormulaTagMul = FormulaTagMul.replace('<quantity>', Qty).replace('[$ProductBasePrice$]', hid_QuantityPrice.value).replace('[$productbaseprice$]', Number(hid_QuantityPrice.value)).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                            }

                            var MarkUp = ddlMultipleValue[1];
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = eval(FormulaTagMul);

                            var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);

                            if (isNaN(MarkupValue)) {
                                MarkupValue = 0;
                            }
                            Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                            var TotalPrice = document.getElementById("lblMultiplePrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "µ";

                            }
                        }
                    }
                }
            }
        }

        if (Number(hid_MatrixLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MatrixLenght.value) - 1; j++) {
                var Check = document.getElementById("chkMatrix_" + j);
                if (Check.checked) {
                    var OthercostID = document.getElementById("lblMatrixID_" + j).innerHTML;
                    var SortOrderNo = document.getElementById("lblMatrixSortOrderNo_" + j + "").innerHTML;

                    var AdditionalMatrixType = document.getElementById("lblMatrixType_" + j).innerHTML;
                    var Formula = '';
                    var MarkUp = '';
                    var SelectedID = '';
                    var SelectedValue = '';
                    var MarkupValue = '';
                    var SelectedPrice = '';
                    if (AdditionalMatrixType != "pricebands") {
                        var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ddlMatrix_" + j);

                        var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                        SelectedValue = ddlMatrix.options[ddlMatrix.selectedIndex].text;
                        ddlMatrixValue = ddlMatrixValue.split('~');

                        SelectedPrice = ddlMatrixValue[0];
                        Formula = ddlMatrixValue[0];
                        MarkUp = ddlMatrixValue[1];
                        SelectedID = ddlMatrixValue[2];
                        MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                        Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                    }
                    else {
                        var MatrixValue = document.getElementById("lblMatrixCostMarkup_" + j).innerHTML;

                        MatrixValue = MatrixValue.split('~');
                        SelectedPrice = MatrixValue[0];
                        Formula = MatrixValue[0] * MatrixValue[3];
                        MarkUp = MatrixValue[1];
                        SelectedID = MatrixValue[2];
                        SelectedValue = '';
                        MarkupValue = (Number(Formula) * Number(MarkUp) / 100);
                        if (isNaN(MarkupValue)) {
                            MarkupValue = 0;
                        }
                        Formula = Formula + "+ (((" + Formula + ")*" + MarkUp + ")/100)";
                    }
                    var TotalPrice = document.getElementById("lblMatrixPrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '');

                    SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "µ";
                }
                //                if (!Check.checked) {
                //                    var OthercostID = document.getElementById("lblMatrixID_" + j).innerHTML;
                //                    var SortOrderNo = document.getElementById("lblMatrixSortOrderNo_" + j + "").innerHTML;

                //                    var AdditionalMatrixType = document.getElementById("lblMatrixType_" + j).innerHTML;
                //                    var Formula = '';
                //                    var MarkUp = '';
                //                    var SelectedID = '';
                //                    var SelectedValue = '';
                //                    var MarkupValue = '';
                //                    var SelectedPrice = '';
                //                    var TotalPrice = '';
                //                    //-------------------just to pass false to uncheck the checkbox---------------------------//
                //                    SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "OthercostID»" + OthercostID + "±Formula»" + '45.0000000000+ (((45.0000000000)*0.0000000000)/100)' + "±MarkUp»" + '100.0000' + "±TotalPrice»" + '100.0000' + "±MarkUpValue»" + '100.0000' + "±SelectedID»" + '0' + "±SelectedValue»" + 'false' + "±SelectedPrice»" + '100.0000' + "±SortOrderNo»" + SortOrderNo + "µ";
                //                }
            }
        }
        var AllAdditionalItemsDetails = '';
        if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix != '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion + "µ" + SaveToAdditionalItemsMultiple + "µ" + SaveToAdditionalItemsMatrix;
        }
        else if (SaveToAdditionalItemsQuestion == '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix != '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsMultiple + "µ" + SaveToAdditionalItemsMatrix;
        }
        else if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple == '' && SaveToAdditionalItemsMatrix != '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion + "µ" + SaveToAdditionalItemsMatrix;
        }
        else if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix == '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion + "µ" + SaveToAdditionalItemsMultiple;
        }
        else if (SaveToAdditionalItemsQuestion == '' && SaveToAdditionalItemsMultiple == '' && SaveToAdditionalItemsMatrix != '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsMatrix;
        }
        else if (SaveToAdditionalItemsQuestion == '' && SaveToAdditionalItemsMultiple != '' && SaveToAdditionalItemsMatrix == '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsMultiple;
        }
        else if (SaveToAdditionalItemsQuestion != '' && SaveToAdditionalItemsMultiple == '' && SaveToAdditionalItemsMatrix == '') {
            AllAdditionalItemsDetails = SaveToAdditionalItemsQuestion;
        }
        hid_SaveToAdditionalItems.value = AllAdditionalItemsDetails;


        if (!FinalCheck) {
            //Commented bcoz put new loading image
            var PrintReadyFileArray = hdnPrintReadyFile.value.split(',');
            if (PrintReadyFileArray[2] == "true") {
                if (RequestType == "1") {
                    if (PrintReadyFileArray[1] == "true") {
                        if (PrintReadyFileArray[0] == "1") {
                            document.getElementById("ctl00_ContentPlaceHolder1_pnlNormalDetails").style.display = "none";
                            document.getElementById("ctl00_ContentPlaceHolder1_pnlConfirmPRFile").style.display = "block";
                            document.getElementById("ctl00_ContentPlaceHolder1_btn_ConfirmAdd1").style.display = "block";
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        else {
            return false;
        }
    }
}

function onTimeout(request, context) { }
function onError(objError) { }
//for web service

function Checkout_Onclick(page) {
    if (Rewritemodule.toLowerCase() == 'on') {
        if (page.toLowerCase() == "checkout") {
            window.location = strSitepath + 'checkoutnew' + FileExtension;
        }
        else if (page.toLowerCase() == "shopping") {
            window.location = strSitepath + "products" + KeySeparator + 0 + FileExtension;
        }
    }
    else {
        if (page.toLowerCase() == "checkout") {
            window.location = strSitepath + "checkoutnew" + FileExtension;
        }
        else if (page.toLowerCase() == "shopping") {
            window.location = strSitepath + "products/product.aspx?ID=0";
        }
    }
}

function Onclick_My_product(PriceCatalogueCategoryID) {
    if (Rewritemodule.toLowerCase() == 'on') {
        window.location = strSitepath + "products" + KeySeparator + PriceCatalogueCategoryID + FileExtension;
    }
    else {
        window.location = strSitepath + "products/product.aspx?ID=" + PriceCatalogueCategoryID;
    }
}

function Onclick_Searchproduct(searchCookie) {
    if (Rewritemodule.toLowerCase() == 'on') {
        window.location = strSitepath + "products/searchproducts" + KeySeparator + searchCookie + FileExtension;
    }
    else {
        window.location = strSitepath + "products/searchproducts.aspx?type=" + searchCookie;
    }
}

function ForAdditional_Grouping(GroupID, OtherCostID) {

    if (Number(GroupID) != 0) {
        //For Matrix Type
        if (Number(hid_MatrixLenght.value) != 0) {
            for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
                var MultipleGroupID = document.getElementById("lblMatrixGroupID_" + k + "").innerHTML;
                var MatrixOthercostID = document.getElementById("lblMatrixID_" + k).innerHTML;
                if (Number(MatrixOthercostID) == Number(OtherCostID)) {
                    var MatrixCheck = document.getElementById("chkMatrix_" + k);
                    MatrixCheck.setAttribute("grpvalue", "1");
                }
                if (Number(MultipleGroupID) == Number(GroupID) && Number(MatrixOthercostID) != Number(OtherCostID) && Number(MultipleGroupID) != 0) {
                    var MatrixCheck = document.getElementById("chkMatrix_" + k);
                    MatrixCheck.checked = false;
                    MatrixCheck.setAttribute("grpvalue", "0");
                    document.getElementById("lblMatrixPrice_" + k + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                }
            }
        }

        //For Multiple Choice Type
        if (Number(hid_MultipleLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                var MultipleGroupID = document.getElementById("lblMultipleGroupID_" + j + "").innerHTML;
                var MultipleOtherCostID = document.getElementById("lblMultipleID_" + j + "").innerHTML;
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
                if (Number(MultipleOtherCostID) == Number(OtherCostID)) {
                    var chkMultiple = document.getElementById("chkMultiple_" + j);
                    ddlMultiple.setAttribute("grpvalue", "1");
                }
                if (Number(MultipleGroupID) == Number(GroupID) && Number(MultipleOtherCostID) != Number(OtherCostID) && Number(MultipleGroupID) != 0) {
                    var chkMultiple = document.getElementById("chkMultiple_" + j);
                    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
                    chkMultiple.checked = false;
                    ddlMultiple.selectedIndex = 0;
                    ddlMultiple.setAttribute("grpvalue", "0");
                    document.getElementById("lblMultiplePrice_" + j + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                }
            }
        }

        //For Question Type
        if (Number(hid_QuestionLenght.value) != 0) {
            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                var QuestionGroupID = document.getElementById("lblQuestionGroupID_" + i + "").innerHTML;
                var QuestionOtherCostID = document.getElementById("lblQuestionID_" + i + "").innerHTML;

                var txtQuestion = document.getElementById("txtQuestion_" + i + "");
                if (Number(QuestionOtherCostID) == Number(OtherCostID)) {
                    txtQuestion.setAttribute("grpvalue", "1");
                }

                if (Number(QuestionGroupID) == Number(GroupID) && Number(QuestionOtherCostID) != Number(OtherCostID) && Number(QuestionGroupID) != 0) {
                    document.getElementById("txtQuestion_" + i + "").value = "";
                    document.getElementById("lblPrice_" + i + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    txtQuestion.setAttribute("grpvalue", "0");
                }
            }
        }
    }
}

function Tocall_mainFunc() {
    var MainQuantity = 0;
    if (hid_matixType.value == "S") {
        if (IsCumulative == "true") {
            MainQuantity = txt_Cumulative_PriceQty.value;
        } else {
            MainQuantity = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
        }
    }
    else {
        MainQuantity = document.getElementById("txtqty").value;
    }
    Tocalculate_totalPrice(MainQuantity);
}

// Check IsDecimal.
function CheckIsDecimal(value) {
    reg = /^\-?([1-9]\d*|0)(\.\d?[1-9])?$/;
    if (!reg.test(value)) {
        spn_qty.style.display = "block";
        spn_qty.innerHTML = "Please enter quantity in numbers";
        document.getElementById("txtqty").value = "";
        return false;
    }
    spn_qty.style.display = "none";
    return reg.test(value);
}

function CheckIsDecimal_Textbox(id, value) {
    reg = /^\-?([1-9]\d*|0)(\.\d?[1-9])?$/;
    if (!reg.test(value)) {
        document.getElementById("spn_qty").style.display = "block";
        document.getElementById("spn_qty").innerHTML = "Please enter quantity in numbers";
        id.value = "";
        return false;
    }
    document.getElementById("spn_qty").style.display = "none";
    return reg.test(value);
}

function GetType(result) {
    debugger;
    CalculationType = result;
}

function CheckStockAvailability(Qty) {

    var IsStockManagement = document.getElementById("ctl00_ContentPlaceHolder1_hdnStockManagement").value;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    if (IsStockManagement == "true") {
        // if (IsShowStock == "true") {
        var DrawStockFrom = document.getElementById("ctl00_ContentPlaceHolder1_hdnDrawStockFrom").value;
        var PriceCatalogueID = document.getElementById("ctl00_ContentPlaceHolder1_hdnPriceCatalogueID").value;
        var IsBackOrder = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value;
        var hdnAvailableQty = document.getElementById("ctl00_ContentPlaceHolder1_hdnAvailableQty").value;
        if (Number(hdnAvailableQty) < 0) {
            hdnAvailableQty = 0;
        }
        if (DrawStockFrom == "s") {
            if (hid_matixType.value == "P") {
                GetSelfStockManagementDetails(Qty, hdnAvailableQty);
            }
            else if (hid_matixType.value == "G") {
                GetSelfStockManagementDetails(Qty, hdnAvailableQty);
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    GetSelfStockManagementDetails(txt_Cumulative_PriceQty.value, hdnAvailableQty);
                } else {
                    GetSelfStockManagementDetails(ddlPriceQty.options[ddlPriceQty.selectedIndex].text, hdnAvailableQty);
                }
            }
        }
        else if (DrawStockFrom == "o") {
            if (hid_matixType.value == "P") {
                AutoFill.OtherProductDetails_Select(PriceCatalogueID, Qty, GetOtherStockManagementDetails, onTimeout, onError);
            }
            else if (hid_matixType.value == "G") {
                AutoFill.OtherProductDetails_Select(PriceCatalogueID, Qty, GetOtherStockManagementDetails, onTimeout, onError);
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    AutoFill.OtherProductDetails_Select(PriceCatalogueID, txt_Cumulative_PriceQty.value, GetOtherStockManagementDetails, onTimeout, onError);
                } else {
                    AutoFill.OtherProductDetails_Select(PriceCatalogueID, ddlPriceQty.options[ddlPriceQty.selectedIndex].text, GetOtherStockManagementDetails, onTimeout, onError);
                }
            }
        }
        else if (DrawStockFrom == "m") {
            if (hid_matixType.value == "P") {
                AutoFill.OtherMultipleProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, GetOtherMultipleStockManagementDetails, onTimeout, onError);
            }
            else if (hid_matixType.value == "G") {
                AutoFill.OtherMultipleProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, GetOtherMultipleStockManagementDetails, onTimeout, onError);
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    AutoFill.OtherMultipleProductDetails_Select(PriceCatalogueID, txt_Cumulative_PriceQty.value, IsBackOrder, GetOtherMultipleStockManagementDetails, onTimeout, onError);
                } else {
                    AutoFill.OtherMultipleProductDetails_Select(PriceCatalogueID, ddlPriceQty.options[ddlPriceQty.selectedIndex].text, IsBackOrder, GetOtherMultipleStockManagementDetails, onTimeout, onError);
                }
            }
        }
        else if (DrawStockFrom == "a") {

            var hdnselectedddlmultipleid = document.getElementById("ctl00_ContentPlaceHolder1_hdnselectedddlmultipleid");
            var hdnselectedwebothercostid = document.getElementById("ctl00_ContentPlaceHolder1_hdnselectedwebothercostid");
            if (hdnselectedddlmultipleid.value != "" && hdnselectedwebothercostid != "") {
                ddlLabels = document.getElementById(hdnselectedddlmultipleid.value);
                var WebOtherCostID = hdnselectedwebothercostid.value;
            }
            else {
                ddlLabels = document.getElementById("ctl00_ContentPlaceHolder1_" + document.getElementById("ctl00_ContentPlaceHolder1_hdnStockAddOption").value);
                var WebOtherCostID = document.getElementById("ctl00_ContentPlaceHolder1_hdnWebOtherCostID").value;
            }
            var ChoiceID = ddlLabels.options[ddlLabels.selectedIndex].value;
            var LabelArray = ChoiceID.split('~');
            //alert(WebOtherCostID + "---" + LabelArray[2]);

            if (hid_matixType.value == "P") {
                AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
            }
            else if (hid_matixType.value == "G") {
                AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, txt_Cumulative_PriceQty.value, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                } else {
                    AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, ddlPriceQty.options[ddlPriceQty.selectedIndex].text, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                }
            }
        }
        //alert(hid_matixType.value);
        //alert(ddlPriceQty.options[ddlPriceQty.selectedIndex].text);
        // }
    }

}

function GetSelfStockManagementDetails(Qty, ActualAvalQty) {

    var AvailableQty = Qty;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    //alert(document.getElementById("contents").offsetHeight);

    if ((document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value) == "false") {
        if (ActualAvalQty == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getelementbyid('ctl00_contentplaceholder1_divmask').style.height = document.getelementbyid("contents").offsetheight + "px";
            document.getelementbyid("ctl00_contentplaceholder1_divMask").style.display = "block";
            //            if (hid_matixType.value == "P") {
            //                document.getElementById("txtqty").disabled = true;
            //            }
            //            else if (hid_matixType.value == "S") {
            //                document.getElementById("ctl00_ContentPlaceHolder1_ddlPriceQty").disabled = true;
            //            }
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;

            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
        }
        else {
            if (hid_matixType.value == "P") {
                if ((ActualAvalQty == "0") || parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    //document.getElementById("txtqty").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    if (parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + AvailableQty;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
                    }

                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = ActualAvalQty;
                }
            }
            else if (hid_matixType.value == "G") {
                if ((ActualAvalQty == "0") || parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    //document.getElementById("txtqty").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    if (parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + AvailableQty;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
                    }

                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = ActualAvalQty;
                }
            }
            else if (hid_matixType.value == "S") {
                if ((ActualAvalQty == "0") || parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";

                    //document.getElementById("ctl00_ContentPlaceHolder1_ddlPriceQty").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    if (parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + AvailableQty;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
                    }

                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = ActualAvalQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                }
            }
        }
    }
    else {
        if (ActualAvalQty == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock. </br>If you proceed to Order this will be a Back Order";
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
        }
        else {
            if (parseInt(ActualAvalQty) <= 0) {
                document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else if (parseInt(AvailableQty) > parseInt(ActualAvalQty)) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            }

            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = ActualAvalQty;
        }
    }
    if (IsShowStock == 'true') {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";

    }
}

function GetOtherMultipleStockManagementDetails(result) {
    var NewResult = result.split('~');
    var OtherMultipleID = NewResult[0];
    var KitItemID = NewResult[1];
    var TotalQty = NewResult[2];
    var AllocatedQty = NewResult[3];
    var AvailableQty = NewResult[4];
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    if ((document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value) == "false") {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
            document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
            //            if (hid_matixType.value == "P") {
            //                document.getElementById("txtqty").disabled = true;
            //            }
            //            else if (hid_matixType.value == "S") {
            //                document.getElementById("ctl00_ContentPlaceHolder1_ddlPriceQty").disabled = true;
            //            }
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
        }
        else {
            if (hid_matixType.value == "P") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    //document.getElementById("txtqty").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
                    }
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                }
            }
            else if (hid_matixType.value == "G") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    //document.getElementById("txtqty").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
                    }
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                }
            }
            else if (hid_matixType.value == "S") {
                var SelectedQty = 0;
                if (IsCumulative == "true") {
                    SelectedQty = txt_Cumulative_PriceQty.value;
                } else {
                    SelectedQty = parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text);
                }

                if ((AvailableQty == "0") || SelectedQty > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    //document.getElementById("ctl00_ContentPlaceHolder1_ddlPriceQty").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    if (parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This product is currently not available for quantity " + ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
                    }
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                }
            }
        }
    }
    else {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;

            var ChkQty;

            if (hid_matixType.value == "P" || hid_matixType.value == "G") {
                ChkQty = document.getElementById("txtqty").value;
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    ChkQty = txt_Cumulative_PriceQty.value;
                } else {
                    ChkQty = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                }
            }

            if (parseInt(AvailableQty) <= 0) {
                document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else if (parseInt(ChkQty) > parseInt(AvailableQty)) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            }
        }
    }
    if (IsShowStock == 'true') {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";

    }
}

function GetOtherStockManagementDetails(result) {

    var AvailableQty = result;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    if ((document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value) == "false") {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
            document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
            //            if (hid_matixType.value == "P") {
            //                document.getElementById("txtqty").disabled = true;
            //            }
            //            else if (hid_matixType.value == "S") {
            //                document.getElementById("ctl00_ContentPlaceHolder1_ddlPriceQty").disabled = true;
            //            }
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
        }
        else {
            if (hid_matixType.value == "P") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";

                    //document.getElementById("txtqty").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
                    }
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                }
            }
            else if (hid_matixType.value == "G") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";

                    //document.getElementById("txtqty").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
                    }
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                }
            }
            else if (hid_matixType.value == "S") {
                var SelectedQty = 0;
                if (IsCumulative == "true") {
                    SelectedQty = txt_Cumulative_PriceQty.value;
                } else {
                    SelectedQty = parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text);
                }

                if ((AvailableQty == "0") || SelectedQty > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";

                    //document.getElementById("ctl00_ContentPlaceHolder1_ddlPriceQty").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    if (parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is out of Stock.</br>It is not currently available for you to Order";
                    }
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                }
            }
        }
    }
    else {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;

            var ChkQty;

            if (hid_matixType.value == "P" || hid_matixType.value == "G") {
                ChkQty = document.getElementById("txtqty").value;
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    ChkQty = txt_Cumulative_PriceQty.value;
                } else {
                    ChkQty = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                }
            }

            if (parseInt(AvailableQty) <= 0) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
                document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
            }
            else if (parseInt(ChkQty) > parseInt(AvailableQty)) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            }
        }
    }
    if (IsShowStock == 'true') {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";

    }
}

function GetAdtOptionsStockManagementDetails(result) {
    var AvailableQty = result;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
    if ((document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value) == "false") {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
            document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";

            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;

            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
        }
        else {
            if (hid_matixType.value == "P") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    //document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    //document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;

                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;

                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "G") {
                if ((AvailableQty == "0") || parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";
                    //document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    //document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;

                    if (parseInt(document.getElementById("txtqty").value) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + document.getElementById("txtqty").value;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;

                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
            else if (hid_matixType.value == "S") {
                var SelectedQty = 0;
                if (IsCumulative == "true") {
                    SelectedQty = txt_Cumulative_PriceQty.value;
                } else {
                    SelectedQty = parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text);
                }

                if ((AvailableQty == "0") || SelectedQty > parseInt(AvailableQty)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_divMask').style.height = document.getElementById("contents").offsetHeight + "px";
                    document.getElementById("ctl00_ContentPlaceHolder1_divMask").style.display = "block";

                    //document.getElementById("ctl00_ContentPlaceHolder1_ddlPriceQty").disabled = true;
                    //document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    //document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = true;

                    if (parseInt(ddlPriceQty.options[ddlPriceQty.selectedIndex].text) > parseInt(AvailableQty)) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = "This Product is currently not available for quantity " + ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_no_backorder_msg;
                    }
                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
                    document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btnAddtoCart1").disabled = false;

                    if (AvailableQty <= 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
                    }
                }
            }
        }
    }
    else {
        if (result == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = "0";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus").innerHTML = "Stock Availability: ";
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = AvailableQty;

            var ChkQty;

            if (hid_matixType.value == "P" || hid_matixType.value == "G") {
                ChkQty = document.getElementById("txtqty").value;
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    ChkQty = txt_Cumulative_PriceQty.value;
                } else {
                    ChkQty = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                }
            }

            if (AvailableQty <= 0) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
                document.getElementById("ctl00_ContentPlaceHolder1_lbl_stockStatus1").innerHTML = 0;
            }
            else if (parseInt(ChkQty) > parseInt(AvailableQty)) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lblStockMessage").innerHTML = No_Stock_with_backorder_msg;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlStockMessage").style.display = "none";
            }
        }
    }
    if (IsShowStock == 'true') {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_divStockStatus").style.display = "none";

    }
}

function CheckAddOptStockAvailability(id, WebOtherCostID) {

    var IsStockManagement = document.getElementById("ctl00_ContentPlaceHolder1_hdnStockManagement").value;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    ddlLabels = document.getElementById(id);
    var ChoiceID = ddlLabels.options[ddlLabels.selectedIndex].value;
    var LabelArray = ChoiceID.split('~');
    if (IsStockManagement == "true") {
        // if (IsShowStock == "true") {
        var DrawStockFrom = document.getElementById("ctl00_ContentPlaceHolder1_hdnDrawStockFrom").value;
        var PriceCatalogueID = document.getElementById("ctl00_ContentPlaceHolder1_hdnPriceCatalogueID").value;
        var IsBackOrder = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsBackOrder").value;
        var hdnselectedddlmultipleid = document.getElementById("ctl00_ContentPlaceHolder1_hdnselectedddlmultipleid");
        var hdnselectedwebothercostid = document.getElementById("ctl00_ContentPlaceHolder1_hdnselectedwebothercostid");

        if (DrawStockFrom == "a") {

            hdnselectedddlmultipleid.value = id;
            hdnselectedwebothercostid.value = WebOtherCostID;
            //var WebOtherCostID = document.getElementById("ctl00_ContentPlaceHolder1_hdnWebOtherCostID").value;

            //alert(WebOtherCostID + "---" + LabelArray[2]);

            if (hid_matixType.value == "P") {
                var Qty = parseInt(document.getElementById("txtqty").value);
                AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
            }
            else if (hid_matixType.value == "G") {
                var Qty = parseInt(document.getElementById("txtqty").value);
                AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, Qty, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
            }
            else if (hid_matixType.value == "S") {
                if (IsCumulative == "true") {
                    AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, txt_Cumulative_PriceQty.value, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                } else {
                    AutoFill.AddOptionsProductDetails_Select(PriceCatalogueID, ddlPriceQty.options[ddlPriceQty.selectedIndex].text, IsBackOrder, WebOtherCostID, LabelArray[2], GetAdtOptionsStockManagementDetails, onTimeout, onError);
                }
            }
        }
        //}
    }
}

function VisibleAdditionaloption(WebotherCostID) {

    if (Number(hid_MultipleLenght.value) != 0) {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);
            if (ddlMultiple.getAttribute('isgroup') == 'maingroup') {
                for (var c = 0; c < ddlMultiple.options.length; c++) {
                    if (ddlMultiple.options[c].text.toLowerCase().trim() != '---select---' &&
                        ddlMultiple.options[c].value.split('~')[2] == ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] &&
                        ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[5] == WebotherCostID) {
                        document.getElementById("div_SubAdditionalsddl_" + ddlMultiple.options[c].value.split('~')[2] + "").style.display = 'block';

                        document.getElementById("lblMultiplePrice_" + j + "").style.display = 'none';

                    } else if (ddlMultiple.options[c].value.split('~')[2] != ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] &&
                        ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[5] == WebotherCostID) {
                        document.getElementById("div_SubAdditionalsddl_" + ddlMultiple.options[c].value.split('~')[2] + "").style.display = 'none';

                        document.getElementById("lblMultiplePrice_" + j + "").style.display = 'block';
                    }
                }
            }
        }
        Final_SellingPrice();
    }
}