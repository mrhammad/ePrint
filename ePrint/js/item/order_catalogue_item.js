var TempSubTotal = 0;
var QtyStartsfrom = 0;
var QtyEndsTo = 0;
var MarkupPercent = 0;

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

    debugger;

    var arrQtyFrom = hid_qtyFromList.value.split('µ');
    var arrQtyTo = hid_qtyToList.value.split('µ');
    var arrCost = hid_CostExcMarkupList.value.split('µ');
    var arrPrice = hid_priceList.value.split('µ');
    var arrMarkup = hid_MarkupList.value.split('µ');
    var arrSPOV = hdn_soldPackOV.value;
    TempSubTotal = 0;

    for (var j = 0; j < arrQtyTo.length - 1; j++) {
        if (j == arrQtyTo.length - 2) {
            QtyEndsTo = Number(arrQtyTo[j]);
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

                    var Dimensn = 0;
                    if (MeasurementValue == 'In.') {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 144);
                        hdn_orderedquantity.value = (Number(txtqty.value));
                        hdn_orderedheight.value = (Number(txtHeight.value));
                        hdn_orderedwidth.value = (Number(txtWidth.value));
                    }
                    else {
                        Dimensn = Number(Qty) * ((Number(txtHeight.value) * Number(txtWidth.value)) / 1000000);
                        hdn_orderedquantity.value = (Number(txtqty.value));
                        hdn_orderedheight.value = (Number(txtHeight.value));
                        hdn_orderedwidth.value = (Number(txtWidth.value));
                    }
                    hdn_orderedarea.value = (Number(hdn_orderedheight.value) * Number(hdn_orderedwidth.value))

                    if (Number(Dimensn) <= Number(arrQtyFrom[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice.value = Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else if (Number(Dimensn) >= Number(arrQtyFrom[i]) && Number(Dimensn) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice.value = Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else if (Number(Dimensn) > Number(arrQtyTo[i]) && Number(Dimensn) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        //hid_QuantityPrice.value = Number(Qty) * Number(arrPrice[i]);
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(Dimensn) * Number(arrCost[i]);
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
                        break;
                    }
                    else if (Number(Qty) >= Number(arrQtyFrom[i]) && Number(Qty) <= Number(arrQtyTo[i])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else if (Number(Qty) > Number(arrQtyTo[i]) && Number(Qty) < Number(arrQtyFrom[i + 1])) {
                        hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                        hid_Markup.value = Number(arrMarkup[i]);
                        var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                        hid_QuantityPrice.value = ActualPrice;
                        break;
                    }
                    else {
                        if (Number(i) == Number(arrQtyFrom.length) - Number(2)) {
                            hid_QuantityPriceExcMarkup.value = Number(arrCost[i]);
                            hid_Markup.value = Number(arrMarkup[i]);
                            var ActualPrice = Number(hid_QuantityPriceExcMarkup.value) + ((Number(hid_QuantityPriceExcMarkup.value) / 100) * Number(arrMarkup[i]));
                            hid_QuantityPrice.value = ActualPrice;
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
                    hid_Markup.value = "0";
                    hid_QuantityPrice.value = "0";
                    hid_QuantityPriceExcMarkup.value = "0";
                    hdn_orderedheight.value = "0";
                    hdn_orderedwidth.value = "0";
                    hdn_orderedarea.value = "0";
                }
            } else {
                var sellingPrice = ddlPriceQty.options[ddlPriceQty.selectedIndex].value.split('~');
                hid_QuantityPriceExcMarkup.value = sellingPrice[0];
                hid_QuantityPrice.value = sellingPrice[1];
                QtyStartsfrom = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                hdn_orderedquantity.value = ddlPriceQty.options[ddlPriceQty.selectedIndex].text;
                hid_Markup.value = arrMarkup[ddlPriceQty.selectedIndex];
                hdn_orderedheight.value = "0";
                hdn_orderedwidth.value = "0";
                hdn_orderedarea.value = "0";
            }
        }
    }

    if (hid_matixType.value == "P") {
        if (Qty != '' && Number(Qty)) {

            if (!(Qty % arrSPOV == 0)) {
                document.getElementById("spn_qty").style.display = 'block';
                document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
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

    if (hid_matixType.value == "S") {
        if (IsCumulative == "true") {
            if (Qty != '' && Number(Qty)) {

                if (!(Qty % arrSPOV == 0)) {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    return false;
                }
                else if ((Qty > Number(hid_Maxquantity.value)) && hid_matixType.value == "S" && IsCumulative == "true") {
                    document.getElementById("spn_qty").style.display = 'block';
                    document.getElementById("spn_qty").innerHTML = "Maximum quantity is " + Number(hid_Maxquantity.value) + "";
                    document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
                    txt_Cumulative_PriceQty.focus();
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
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hid_QuantityPrice");
    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';

    if (hid_matixType.value == "S") {

    }

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
                AutoFill.CalculateFormulaCost(dd, ID, GetResult, onTimeout, onError);
            }
            else {
                document.getElementById("lblPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
            }
            Final_SellingPrice();
        }
        else {
            document.getElementById("lblPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
        }
        Final_SellingPrice();
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
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
            document.getElementById("lblPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
        }
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
    }
}

function GetResult(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblPrice_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);
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
                document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
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
                var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMatrix_" + ID);
                //  var QtyMatched = false;
                var MatrixSellingPrice = '';
                for (var ddl = 0; ddl <= ddlMatrix.length - 1; ddl++) {
                    if (Number(quantity) <= Number(ddlMatrix[ddl].text)) {
                        ddlMatrix.selectedIndex = ddl;
                        //   QtyMatched = true;
                        var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                        var ddlMatrixValue1 = ddlMatrixValue.split('~');
                        MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);
                        break;
                    }
                    else {
                        ddlMatrix.selectedIndex = ddl;
                        //   QtyMatched = true;
                        var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
                        var ddlMatrixValue1 = ddlMatrixValue.split('~');
                        MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);
                    }
                }

                document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, MatrixSellingPrice, 2, '', false, false, false);
                Final_SellingPrice();
                spn_qty.style.display = "none";
            }
            else {
                var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMatrix_" + ID);
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
        document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
        Final_SellingPrice();
    }
}

function GetResultMatrix(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMatrixPrice_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(NewResult[0] * NewResult[5]), 2, '', false, false, false);
        document.getElementById("lblMatrixCostMarkup_" + NewResult[1] + "").innerHTML = NewResult[2] + "~" + NewResult[3] + "~" + NewResult[4] + "~" + NewResult[5];
        Final_SellingPrice();
    }
}

function Onchange_SimpleMatrix(ID) {
    var GroupID = document.getElementById("lblMatrixGroupID_" + ID + "").innerHTML;
    var OtherCostID = document.getElementById("lblMatrixID_" + ID + "").innerHTML;

    var chkbox = document.getElementById("chkMatrix_" + ID + "");
    var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMatrix_" + ID);
    if (chkbox.checked || ddlMatrix.options[ddlMatrix.selectedIndex].value != "0") {
        if (ddlMatrix.options[ddlMatrix.selectedIndex].value != "0" && chkbox.getAttribute("grpvalue") == "1") {
            var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;
            var ddlMatrixValue1 = ddlMatrixValue.split('~');
            var MatrixSellingPrice = Number(ddlMatrixValue1[0]) + ((Number(ddlMatrixValue1[0]) * Number(ddlMatrixValue1[1])) / 100);
            chkbox.checked = true;
            document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, MatrixSellingPrice, 2, '', false, false, false);
            Final_SellingPrice();
        }
        else {
            chkbox.checked = false;
            document.getElementById("lblMatrixPrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 2, '', false, false, false);
            Final_SellingPrice();
        }
    }
}

function Onchange_MultipleChoice(ID, TempSubTotal) {
    debugger;
    //var GroupID = document.getElementById("lblMultipleGroupID_" + ID + "").innerHTML;
    if (typeof document.getElementById("lblMultipleGroupID_" + ID + "") != 'undefined' && document.getElementById("lblMultipleGroupID_" + ID + "") != undefined && document.getElementById("lblMultipleGroupID_" + ID + "") != null) {
        var GroupID = document.getElementById("lblMultipleGroupID_" + ID + "").innerHTML;
    }
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
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hid_QuantityPrice");
    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';

    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + ID);
    var ddlValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;

    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
        if (chkMultiple.checked || (ddlMultiple.options[ddlMultiple.selectedIndex].value != "0")) {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                    chkMultiple.checked = false;
                    if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC) != null) {
                        document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    }
                }
                else {
                    if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                        for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                            var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                            if (SubGroupddlMultiple != null) {
                                if (SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                                    var ddlMultipleValue = SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].value;
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
                                                AutoFill.CalculateFormulaCost_ForSUBMultipleChoice(dd, Number(MultipleValue[1]), ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC, GetResultSubMultiple_ForOrder, onTimeout, onError);
                                            }
                                            else {
                                                if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC) != null) {
                                                    document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";

                                                }
                                                Final_SellingPrice();
                                            }
                                        }
                                        else {
                                            if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC) != null) {
                                                document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                            }
                                        }
                                        chkMultiple.checked = true;
                                        spn_qty.style.display = "none";
                                    }
                                    else {
                                        ddlMultiple.selectedIndex = 0;
                                        spn_qty.style.display = "block";
                                        chkMultiple.checked = false;
                                        if (IsCumulative == "true") {
                                            txt_Cumulative_PriceQty.focus();
                                        } else {
                                            document.getElementById("txtqty").focus();
                                        }
                                    }
                                }
                                else {
                                    if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC) != null) {
                                        document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                                    }
                                    Final_SellingPrice();
                                }
                            }
                            
                        }
                    } else {
                        if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                        }
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                }
                Final_SellingPrice();
            }
        }
        else {
            chkMultiple.checked = false;
            if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
            }
            Final_SellingPrice();
        }
    } else {
        if (ddlMultiple.getAttribute("grpvalue") == "1") {
            if (chkMultiple.checked || (ddlMultiple.options[ddlMultiple.selectedIndex].value != "0")) {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" &&
                    ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" &&
                    ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {
                    if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                        chkMultiple.checked = false;
                        if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                        }
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
                                }
                                else {
                                    if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                                        document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                                    }
                                    Final_SellingPrice();
                                }
                            }
                            else {
                                if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                                }
                            }
                            chkMultiple.checked = true;
                            spn_qty.style.display = "none";
                        }
                        else {
                            ddlMultiple.selectedIndex = 0;
                            spn_qty.style.display = "block";
                            chkMultiple.checked = false;
                            if (IsCumulative == "true") {
                                txt_Cumulative_PriceQty.focus();
                            } else {
                                document.getElementById("txtqty").focus();
                            }
                        }
                    }
                }
                else {
                    chkMultiple.checked = false;
                    if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                        document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                    }
                    Final_SellingPrice();
                }
            }
            else {
                chkMultiple.checked = false;
                if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                }
                Final_SellingPrice();
            }
        }
        else {
            chkMultiple.checked = false;
            if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
            }
            Final_SellingPrice();
        }
    }
}

function GetResultMultiple(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMultiplePrice_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);

        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}

function GetResultSubMultiple_ForOrder(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        document.getElementById("lblMultiplePrice_" + NewResult[1] + "").innerHTML = "" + GetCurrencyinRequiredFormate("", true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);
        setInterval("TakeOut()", 10000);
        Final_SellingPrice();
    }
}

function Onchange_MultipleChoice_SubTotal(ID) {
    debugger;
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
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hid_QuantityPrice");
    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';

    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + ID);

    if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
        if (chkMultiple.checked || ddlMultiple.options[ddlMultiple.selectedIndex].value != "0") {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                    chkMultiple.checked = false;
                    if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC) != null) {
                        document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                    }
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
                            if (document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC) != null) {
                                document.getElementById("lblMultiplePrice_" + ID + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML = "" + GetCurrencyinRequiredFormate("", true) + " 0.00";
                            }
                        }
                        chkMultiple.checked = true;
                        spn_qty.style.display = "none";
                    }
                    else {
                        ddlMultiple.selectedIndex = 0;
                        spn_qty.style.display = "block";
                        chkMultiple.checked = false;
                        if (IsCumulative == "true") {
                            txt_Cumulative_PriceQty.focus();
                        } else {
                            document.getElementById("txtqty").focus();
                        }
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                }
            }
        }
        else {
            chkMultiple.checked = false;
            if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
            }
        }
    } else {
        if (chkMultiple.checked || ddlMultiple.options[ddlMultiple.selectedIndex].value != "0") {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {
                if (ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                    chkMultiple.checked = false;
                    if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                        document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                    }
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
                            if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                            }
                        }
                        chkMultiple.checked = true;
                        spn_qty.style.display = "none";
                    }
                    else {
                        ddlMultiple.selectedIndex = 0;
                        spn_qty.style.display = "block";
                        chkMultiple.checked = false;
                        if (IsCumulative == "true") {
                            txt_Cumulative_PriceQty.focus();
                        } else {
                            document.getElementById("txtqty").focus();
                        }
                    }
                }
            }
            else {
                chkMultiple.checked = false;
                if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                }
            }
        }
        else {
            chkMultiple.checked = false;
            if (document.getElementById("lblMultiplePrice_" + ID + "") != null) {
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
            }
        }
    }
}

function Final_SellingPrice() {
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var MatrixPrice = '0';
    var SubMultiplePrice = 0;
    var SubValue = 0;
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hid_QuantityPrice");
    if (hid_QuestionLenght.value != "0") {
        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
            QuestionPrice = Number(QuestionPrice) + Number(document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", ''));
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j);
            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                        if (document.getElementById("lblMultiplePrice_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC) != null) {
                            MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                        }
                    }
                } else {
                    if (document.getElementById("lblMultiplePrice_" + j + "") != null) {
                        MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                    }
                }
            } else {
                if (document.getElementById("lblMultiplePrice_" + j + "") != null) {
                    MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                }
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
            MatrixPrice = Number(MatrixPrice) + Number(document.getElementById("lblMatrixPrice_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", ''));
        }
    }

    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    QuestionPrice = QuestionPrice != 'NaN' ? QuestionPrice : '0';
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    MatrixPrice = MatrixPrice != 'NaN' ? MatrixPrice : '0';

    hdn_DecorationCost1.value = hdn_DecorationCost1.value == '' ? 0 : hdn_DecorationCost1.value
    hdn_DecorationCost2.value = hdn_DecorationCost2.value == '' ? 0 : hdn_DecorationCost2.value
    hdn_DecorationCost3.value = hdn_DecorationCost3.value == '' ? 0 : hdn_DecorationCost3.value
    hdn_DecorationCost4.value = hdn_DecorationCost4.value == '' ? 0 : hdn_DecorationCost4.value
    hdn_DecorationCost5.value = hdn_DecorationCost5.value == '' ? 0 : hdn_DecorationCost5.value
    hdn_DecorationCost6.value = hdn_DecorationCost6.value == '' ? 0 : hdn_DecorationCost6.value

    decorationCost = parseFloat(hdn_DecorationCost1.value) + parseFloat(hdn_DecorationCost2.value) + parseFloat(hdn_DecorationCost3.value) + parseFloat(hdn_DecorationCost4.value) + parseFloat(hdn_DecorationCost5.value) + parseFloat(hdn_DecorationCost6.value)

    var sellingPrice = Number(hid_QuantityPrice.value) + Number(QuestionPrice) + Number(MultiplePrice) + Number(MatrixPrice) + decorationCost;

    lbltotal.innerHTML = '0';
    lbltotal.innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(sellingPrice), 2, '', false, false, false);
    hdnlbltotal.value = parseFloat(sellingPrice);
    TaxOnChange();
}

function Final_SellingPrice_SubTotal() {
    TempSubTotal = 0;
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var MatrixPrice = '0';
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hid_QuantityPrice");

    setInterval("TakeOut()", 100000);

    //    alert("hi");  
    if (hid_QuestionLenght.value != "0") {
        for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
            QuestionPrice = Number(QuestionPrice) + Number(document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", ''));
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j);
            if (ddlMultiple.getAttribute("isgroup") == 'maingroup') {
                if (Number(ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]) != 0) {
                    for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                        var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                        if (document.getElementById("lblMultiplePrice_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC) != null) {
                            MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", ''));
                        }
                    }
                } else {
                    if (document.getElementById("lblMultiplePrice_" + j + "") != null) {
                        MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", ''));
                    }
                }
            } else {
                if (document.getElementById("lblMultiplePrice_" + j + "") != null) {
                    MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", ''));
                }
            }
        }
    }

    if (hid_MatrixLenght.value != "0") {
        for (var k = 0; k <= Number(hid_MatrixLenght.value) - 1; k++) {
            if (document.getElementById("lblMatrixPrice_" + k + "") != null) {
                MatrixPrice = Number(MatrixPrice) + Number(document.getElementById("lblMatrixPrice_" + k + "").innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", ''));
            }
        }
    }

    hid_QuantityPrice.value = hid_QuantityPrice.value != 'NaN' ? hid_QuantityPrice.value : '0';
    QuestionPrice = QuestionPrice != 'NaN' ? QuestionPrice : '0';
    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    MatrixPrice = MatrixPrice != 'NaN' ? MatrixPrice : '0';

    hdn_DecorationCost1.value = hdn_DecorationCost1.value == '' ? 0 : hdn_DecorationCost1.value
    hdn_DecorationCost2.value = hdn_DecorationCost2.value == '' ? 0 : hdn_DecorationCost2.value
    hdn_DecorationCost3.value = hdn_DecorationCost3.value == '' ? 0 : hdn_DecorationCost3.value
    hdn_DecorationCost4.value = hdn_DecorationCost4.value == '' ? 0 : hdn_DecorationCost4.value
    hdn_DecorationCost5.value = hdn_DecorationCost5.value == '' ? 0 : hdn_DecorationCost5.value
    hdn_DecorationCost6.value = hdn_DecorationCost6.value == '' ? 0 : hdn_DecorationCost6.value

    decorationCost = parseFloat(hdn_DecorationCost1.value) + parseFloat(hdn_DecorationCost2.value) + parseFloat(hdn_DecorationCost3.value) + parseFloat(hdn_DecorationCost4.value) + parseFloat(hdn_DecorationCost5.value) + parseFloat(hdn_DecorationCost6.value)

    var sellingPrice = Number(hid_QuantityPrice.value) + Number(QuestionPrice) + Number(MultiplePrice) + Number(MatrixPrice) + decorationCost;
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
    var hdnlblTotalTax = document.getElementById("hdnlblTotalTax");
    var TotalPrice = hdnlbltotal.value;// lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", '');
    var TotalTax = 0;
    if (TotalPrice != '0.00') {
        TotalTax = Number((Number(TotalPrice) * Number(TaxRate)) / 100);
        lblTotalTax.innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "" + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalTax), 2, '', false, false, false);
        hdnlblTotalTax.value = parseFloat(TotalTax);
    }
    else {
        lblTotalTax.innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
        hdnlblTotalTax.value = parseFloat(0);
    }
    var TotalSellingPrice = Number(TotalPrice) + Number(TotalTax);
    document.getElementById("lblTotalSellingPrice").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " " + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalSellingPrice), 2, '', false, false, false);
}

function Update_OrderItems() {
    debugger;
    var FinalCheck = false;
    var SaveToAdditionalItemsQuestion = '';
    var SaveToAdditionalItemsMultiple = '';
    var SaveToAdditionalItemsMatrix = '';
    var hid_QuantityPrice = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hid_QuantityPrice");
    var hid_QuantityPriceExcMarkup = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hid_QuantityPriceExcMarkup");
    var hdn_GetIscamapignEnabled = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hdnEnabledCampaign");
    var ddlCamapign = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlCampaign");
    var ddlCamapignvalue = ddlCamapign.options[ddlCamapign.selectedIndex].value;
    var div_CampaignErrorMsg = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_div_CampaignErrorMsg");
    var isStockAddOptionChanged = false;

    if (ManageStockPermission == 1 && (modulename.toString().toLowerCase() == "job" || modulename.toString().toLowerCase() == "invoice")) {
        if (StockCancellationType.toString().toLowerCase() == "a" && hid_OldPriceCatalogueID.value != hid_PriceCatalogueID.value) {
            hdn_stockBackwarehoue.value = 'yes';
        }
    }

    var DrawStockFrom = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hdnDrawStockFrom").value;
    var IsStockItem = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_hdnIsStockItem").value;

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
    var arrSPOV = hdn_soldPackOV.value;

    if (Number(Qty) == '' || Number(Qty) == 0) {
        spn_qty.style.display = "block";
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

    if (DrawStockFrom.toLowerCase() == "x" && IsStockItem.toLowerCase() == "true") {
        alert("This product can not currently be ordered. Please contact the system administrator and ask them to check the stock settings");
        return false;
    }
    else if (!(Qty % arrSPOV == 0) && hid_matixType.value != "S") {
        document.getElementById("spn_qty").style.display = 'block';
        document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
        document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("txtqty").focus();
        return false;
    }
    else if (!(Qty % arrSPOV == 0) && hid_matixType.value == "S" && IsCumulative == "true") {
        document.getElementById("spn_qty").style.display = 'block';
        document.getElementById("spn_qty").innerHTML = "Please enter quantity in the multiples of " + arrSPOV + "";
        document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        txt_Cumulative_PriceQty.focus();
        return false;
    }
    else if ((Qty > Number(hid_Maxquantity.value)) && hid_matixType.value == "S" && IsCumulative == "true") {
        document.getElementById("spn_qty").style.display = 'block';
        document.getElementById("spn_qty").innerHTML = "Maximum quantity is " + Number(hid_Maxquantity.value) + "";
        document.getElementById("lblTotalTax").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lblTotalSellingPrice").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        document.getElementById("lbltotal").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        txt_Cumulative_PriceQty.focus();
        return false;
    }
    else {

        if (hdn_GetIscamapignEnabled.value == "true") {
            if (ddlCamapignvalue == "0") {
                div_CampaignErrorMsg.style.display = "block";
                FinalCheck = true;
            }
        }
        var QuestionTotalMarkupValue = 0;
        var MultipleTotalMarkupValue = 0;
        var MatrixTotalMarkupValue = 0;
        if (Number(hid_QuestionLenght.value) != 0) {
            for (var i = 0; i <= Number(hid_QuestionLenght.value) - 1; i++) {
                var QuestionQty = document.getElementById("txtQuestion_" + i + "").value;
                var SortOrderNo = document.getElementById("lblQuestionSortOrderNo_" + i + "").innerHTML;
                if (QuestionQty != '' && QuestionQty != 0) {
                    var OthercostID = document.getElementById("lblQuestionID_" + i).innerHTML;
                    var TotalPrice = document.getElementById("lblPrice_" + i + "").innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", '');

                    var FormulaTag = document.getElementById("lblQuestionFormula_" + i).innerHTML.replace('</quantity>', '').replace('</question>', '').replace('</ProductBasePrice>', '').replace('</SubTotal>', '');

                    var Formula = FormulaTag;
                    for (var f = 0; f <= FormulaTag.length; f++) {
                        Formula = Formula.replace('<question>', QuestionQty).replace('<quantity>', QuestionQty).replace('<input>', QuestionQty).replace('[$ProductBasePrice$]', Number(hid_QuantityPrice.value)).replace('[$productbaseprice$]', Number(hid_QuantityPrice.value)).replace('[$SubTotal$]', Number(TempSubTotal)).replace('[$subtotal$]', Number(TempSubTotal)).replace(' ', '').replace('[$OrderedHeight$]', Number(hdn_orderedheight.value)).replace('[$orderedheight$]', Number(hdn_orderedheight.value)).replace('[$OrderedWidth$]', Number(hdn_orderedwidth.value)).replace('[$orderedwidth$]', Number(hdn_orderedwidth.value)).replace('[$OrderedArea$]', Number(hdn_orderedarea.value)).replace('[$orderedarea$]', Number(hdn_orderedarea.value)).replace('[$OrderedQuantity$]', Number(hdn_orderedquantity.value)).replace('[$orderedquantity$]', Number(hdn_orderedquantity.value)).replace('[$MultipleOf$]', Number(1)).replace('[$multipleof$]', Number(1));
                    }

                    var MarkUp = 0;
                    var MarkupValue = 0;
                    var SelectedValue = '';
                    QuestionTotalMarkupValue = Number(QuestionTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±SortOrderNo»" + SortOrderNo + "µ";
                }
            }
        }

        if (Number(hid_QuestionTextFreeLenght.value) != 0) {
            debugger;
            for (var i = 0; i <= Number(hid_QuestionTextFreeLenght.value) - 1; i++) {
                var QuestionQty = document.getElementById("txtFreeTextQuestion_" + i + "").value;
                //var SortOrderNo = document.getElementById("lblTextQuestionSortOrderNo_" + i + "").innerHTML;
                var Calculation_Type = document.getElementById("hdn_FreeTextQuestion_CalculationType_" + i + "").value;
                if (QuestionQty != '' && QuestionQty != 0) {

                    var OthercostID = document.getElementById("lblFreeTextQuestionID_" + i).innerHTML;var TotalPrice = 0;
                    var Formula = 0;

                    var MarkUp = 0;
                    var MarkupValue = 0;
                    var SelectedValue = '';

                    SaveToAdditionalItemsQuestion = SaveToAdditionalItemsQuestion + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + 0 + "±SelectedValue»" + QuestionQty + "±SelectedPrice»" + 0 + "±CalculationType»" + Calculation_Type + "µ";
                }
            }
        }


        if (Number(hid_MultipleLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                var Check = document.getElementById("chkMultiple_" + j);
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j);
                //added by chethan to check Mandatory additional option is selected or not
                if (ddlMultiple.getAttribute("IsMandatory") == "1" && ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                    alert("Additional options marked with a * are mandatory");
                    return false;
                }

                if (Check.checked) {
                    var OthercostID = document.getElementById("lblMultipleID_" + j).innerHTML;
                    var SortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "").innerHTML;
                    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j);

                    isStockAddOptionChanged = false;
                    if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                        if (ddlMultiple.getAttribute('isgroup') == 'maingroup') {
                            var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                            var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].text;
                            ddlMultipleValue = ddlMultipleValue.split('~');

                            var FormulaTagMul = '';
                            var Formula = '';
                            var MarkUp = '0';
                            var SelectedID = ddlMultipleValue[2];
                            var SelectedPrice = '0';
                            var MarkupValue = 0;
                            Formula = '';

                            var TotalPrice = document.getElementById("lblMultiplePrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "±ParentWebOtherCostID»0±WebOtherCostType»maingroup" + "µ";
                            }

                            for (var SC = 0; SC < ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[4]; SC++) {
                                var SubGroupddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC);
                                if (SubGroupddlMultiple != null) {
                                    if (SubGroupddlMultiple.getAttribute("IsMandatory") == "1" && SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].value.split('~')[6] == '1') {
                                        alert("Additional options marked with a * are mandatory");
                                        return false;
                                    }
                                    var ddlMultipleValue = SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].value;
                                    var SelectedValue = SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text;
                                    ddlMultipleValue = ddlMultipleValue.split('~');

                                    if (SubGroupddlMultiple.options[SubGroupddlMultiple.selectedIndex].text.toLowerCase().trim() != "---select---") {

                                        var SubOthercostID = document.getElementById("lblMultipleID_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML;
                                        var SubSortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML;

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


                                        var TotalPrice = document.getElementById("lblMultiplePrice_" + j + "_" + ddlMultiple.options[ddlMultiple.selectedIndex].value.split('~')[2] + "_" + SC).innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", '');
                                        if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {

                                            MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
                                            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + SubOthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SubSortOrderNo + "±ParentWebOtherCostID»" + OthercostID + "±WebOtherCostType»subgroup" + "µ";
                                        }
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

                            var TotalPrice = document.getElementById("lblMultiplePrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", '');
                            if (ddlMultiple.options[ddlMultiple.selectedIndex].text != "---Select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---select---" && ddlMultiple.options[ddlMultiple.selectedIndex].text != "---SELECT---") {

                                MultipleTotalMarkupValue = Number(MultipleTotalMarkupValue) + Number(MarkupValue);
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
                        var ddlMatrix = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMatrix_" + j);

                        var ddlMatrixValue = ddlMatrix.options[ddlMatrix.selectedIndex].value;

                        SelectedValue = ddlMatrix.options[ddlMatrix.selectedIndex].text;
                        ddlMatrixValue = ddlMatrixValue.split('~');

                        SelectedPrice = ddlMatrixValue[0];
                        Formula = ddlMatrixValue[0];
                        SelectedPrice = ddlMatrixValue[0];
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
                    var TotalPrice = document.getElementById("lblMatrixPrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", '');

                    MatrixTotalMarkupValue = Number(MatrixTotalMarkupValue) + Number(MarkupValue);
                    SaveToAdditionalItemsMatrix = SaveToAdditionalItemsMatrix + "OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "µ";
                }
            }
        }
        //////////////////////////Decoration Added by Amin////////////////////////////////
        if (parseFloat(hdn_DecorationCost1.value) > 0) {

            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_1");

            var decoration1 = document.getElementById("lblDecoration_1").innerHTML.substring(0, document.getElementById("lblDecoration_1").innerHTML.length - 1) + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±SortOrderNo»" + 101 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        if (parseFloat(hdn_DecorationCost2.value) > 0) {
            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_2");

            var decoration2 = document.getElementById("lblDecoration_2").innerHTML.substring(0, document.getElementById("lblDecoration_2").innerHTML.length - 1) + "¶" + ddlDecoration.options[ddlDecoration.selectedIndex].value;
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost2.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration2 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost2.value) + "±SortOrderNo»" + 102 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        if (parseFloat(hdn_DecorationCost3.value) > 0) {

            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_3");
            var decoration3 = document.getElementById("lblDecoration_3").innerHTML.substring(0, document.getElementById("lblDecoration_3").innerHTML.length - 1) +"¶"+ ddlDecoration.options[ddlDecoration.selectedIndex].value;
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost3.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration3 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost3.value) + "±SortOrderNo»" + 103 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        if (parseFloat(hdn_DecorationCost4.value) > 0) {
            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_4");
            var decoration4 = document.getElementById("lblDecoration_4").innerHTML.substring(0, document.getElementById("lblDecoration_4").innerHTML.length - 1) +"¶"+ ddlDecoration.options[ddlDecoration.selectedIndex].value;
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost4.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration4 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost4.value) + "±SortOrderNo»" + 104 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        if (parseFloat(hdn_DecorationCost5.value) > 0) {
            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_5");

            var decoration5 = document.getElementById("lblDecoration_5").innerHTML.substring(0, document.getElementById("lblDecoration_5").innerHTML.length - 1) +"¶"+ ddlDecoration.options[ddlDecoration.selectedIndex].value;
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost5.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration5 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost5.value) + "±SortOrderNo»" + 105 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        if (parseFloat(hdn_DecorationCost6.value) > 0) {
            var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_6");
            var decoration6 = document.getElementById("lblDecoration_6").innerHTML.substring(0, document.getElementById("lblDecoration_6").innerHTML.length - 1) +"¶"+ ddlDecoration.options[ddlDecoration.selectedIndex].value;// 
            //SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + 0 + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost1.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + 1 + "±SelectedValue»" + decoration1 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost1.value) + "±Decoration»" + 1 + "Decoration" + "µ";
            SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "OthercostID»" + 0 + "±Formula»" + Formula + "±MarkUp»" + 0 + "±TotalPrice»" + parseFloat(hdn_DecorationCost6.value) + "±MarkUpValue»" + 0 + "±SelectedID»" + ddlDecoration.selectedIndex + "±SelectedValue»" + decoration6 + "±SelectedPrice»" + parseFloat(hdn_DecorationCost6.value) + "±SortOrderNo»" + 106 + "±ParentWebOtherCostID»0±WebOtherCostType»Decoration" + "µ";

        }
        //////////////////////////End Decoration Added by Amin////////////////////////////////
        var UnitPrice = '';
        if (Qty != '' || Qty != 0) {
            UnitPrice = Number(lbltotal.innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", '')) / Number(Qty);
        }
        else {
            UnitPrice = "0";
        }

        var TaxRate = document.getElementById("lblTaxRate").innerHTML;
        var TaxId = document.getElementById("hdnTaxId").value;
        var MainItemMarkupPrice = Number(hid_QuantityPrice.value) - Number(hid_QuantityPriceExcMarkup.value);
        var OrderItemTotalPrice = document.getElementById("lbltotal").innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", '');
        var OrderItemTax = document.getElementById("lblTotalTax").innerHTML.replace("" + GetCurrencyinRequiredFormate('', true) + "", '');
        var OrderItemShipping = 0;
        var TotalMarkupValue = 0;

        QuestionTotalMarkupValue = QuestionTotalMarkupValue != 'NaN' ? QuestionTotalMarkupValue : '0';
        MultipleTotalMarkupValue = MultipleTotalMarkupValue != 'NaN' ? MultipleTotalMarkupValue : '0';
        MatrixTotalMarkupValue = MatrixTotalMarkupValue != 'NaN' ? MatrixTotalMarkupValue : '0';

        TotalMarkupValue = Number(MainItemMarkupPrice) + Number(QuestionTotalMarkupValue) + Number(MultipleTotalMarkupValue) + Number(MatrixTotalMarkupValue);

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
        }

        debugger;

        //plz don't change the order of the values which passing, if any new value to be added plz add in the last.
        hid_UpdateToOrderItems.value = "" + Qty + "»" + Number(UnitPrice) + "»" + Number(hid_QuantityPrice.value) + "»" + MainItemMarkupPrice + "»" + TaxRate + "»" + OrderItemTotalPrice + "»" + OrderItemTax + "»" + OrderItemShipping + "»" + TotalMarkupValue + "»" + Height + "»" + Width + "»" + isStockAddOptionChanged + "»" + TaxId;

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
            return true;
        }
        else {
            return false;
        }
    }
}

function onTimeout(request, context) {
    //            alert(request + " request");
    //            alert(context + " context");
}

function onError(objError) {
    //            alert(objError + " objError");

}
//for web service

function Checkout_Onclick(page) {
    if (Rewritemodule == 'on') {
        if (page == "checkout") {
            window.location = strSitepath + 'checkout' + FileExtension;
        }
        else if (page == "shopping") {
            window.location = strSitepath + "";
        }
    }
    else {
        if (page == "checkout") {
            window.location = strSitepath + "checkout" + FileExtension;
        }
        else if (page == "shopping") {
            window.location = strSitepath + "";
        }
    }
}

function Onclick_My_product(PriceCatalogueCategoryID) {
    if (Rewritemodule == 'on') {
        window.location = strSitepath + 'products' + KeySeparator + PriceCatalogueCategoryID + FileExtension;
    }
    else {
        window.location = strSitepath + 'products/product' + FileExtension + "?ID=" + PriceCatalogueCategoryID;
    }
}

function Onclick_Searchproduct(searchCookie) {
    if (Rewritemodule == 'on') {
        window.location = strSitepath + 'products/searchproducts' + KeySeparator + searchCookie + FileExtension;
    }
    else {
        window.location = strSitepath + "products/searchproducts" + FileExtension + "?type=" + searchCookie;
    }
}

function ForAdditional_Grouping(GroupID, OtherCostID) {
    debugger;
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
                    document.getElementById("lblMatrixPrice_" + k + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
                }
            }
        }

        //For Multiple Choice Type
        if (Number(hid_MultipleLenght.value) != 0) {
            for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
                var MultipleGroupID = document.getElementById("lblMultipleGroupID_" + j + "").innerHTML;
                var MultipleOtherCostID = document.getElementById("lblMultipleID_" + j + "").innerHTML;
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j);
                if (Number(MultipleOtherCostID) == Number(OtherCostID)) {
                    var chkMultiple = document.getElementById("chkMultiple_" + j);
                    ddlMultiple.setAttribute("grpvalue", "1");
                }
                if (Number(MultipleGroupID) == Number(GroupID) && Number(MultipleOtherCostID) != Number(OtherCostID) && Number(MultipleGroupID) != 0) {
                    var chkMultiple = document.getElementById("chkMultiple_" + j);
                    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j);
                    chkMultiple.checked = false;
                    ddlMultiple.selectedIndex = 0;
                    ddlMultiple.setAttribute("grpvalue", "0");
                    document.getElementById("lblMultiplePrice_" + j + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + "0.00";
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
                    document.getElementById("lblPrice_" + i + "").innerHTML = "" + GetCurrencyinRequiredFormate('', true) + " 0.00";
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

function RemoveImage(CountNo) {
    if (Number(CountNo) == 1) {
        lblartwork1.innerHTML = "";
        lblartwork1.style.display = "none";
        fp_artwork1.style.display = "block";
    }
    else if (Number(CountNo) == 2) {
        lblartwork2.innerHTML = "";
        lblartwork2.style.display = "none";
        fp_artwork2.style.display = "block";
    }
    else if (Number(CountNo) == 3) {
        lblartwork3.innerHTML = "";
        lblartwork3.style.display = "none";
        fp_artwork3.style.display = "block";
    }
}

function CheckIsDecimal_Textbox(id, value) {
    reg = /^\-?([1-9]\d*|0)(\.\d?[1-9])?$/;
    if (!reg.test(value)) {
        document.getElementById("spn_qty").style.display = "block";
        document.getElementById("spn_qty").innerHTML = "Please enter quantity in numbers";
        //spn_qty.innerHTML = "Please enter quantity in numbers";
        id.value = "";
        return false;
    }
    document.getElementById("spn_qty").style.display = "none";
    return reg.test(value);
}
calculateDecoration(1);
Tocall_mainFunc();

function CheckStockAvailability(Qty) {
    var IsStockManagement = document.getElementById("ctl00_ContentPlaceHolder1_hdnStockManagement").value;
    var IsShowStock = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsShowStock").value;
    if (IsStockManagement == "true") {
        if (rdbstkorder.checked) {
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

                var WebOtherCostID = document.getElementById("ctl00_ContentPlaceHolder1_hdnWebOtherCostID").value;
                ddlLabels = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_0");
                var ChoiceID = ddlLabels.options[ddlLabels.selectedIndex].value;
                var LabelArray = ChoiceID.split('~');

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
        }
    }

}

function VisibleAdditionaloption_ForOrder(WebotherCostID) {
    debugger;
    if (Number(hid_MultipleLenght.value) != 0) {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlMultiple_" + j);
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

function calculateDecoration(decoration) {
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
    //if (decoration == 1) {

    var Qty = parseInt(MainQuantity);
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_1");
    var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
    if (ddlValue == 'Yes') {


        var decorationArray = hdn_Decoration1.value.split('~');
       
        var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
        var minimumCost = parseFloat(decorationArray[2])
        var total = cost > minimumCost ? cost : minimumCost
        document.getElementById("lblDecorationCost_1").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
        hdn_DecorationCost1.value = total;
    }
    else {
        document.getElementById("lblDecorationCost_1").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        hdn_DecorationCost1.value = 0;
    }
    //  document.getElementById("ctl00_ContentPlaceHolder1_lblDecoration1Cost").innerHTML == 'Hello';
    //}
    //if (decoration == 2) {

    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_2");
    var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
    if (ddlValue == 'Yes') {

        var decorationArray = hdn_Decoration2.value.split('~');
    
        var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
        var minimumCost = parseFloat(decorationArray[2])
        var total = cost > minimumCost ? cost : minimumCost
        document.getElementById("lblDecorationCost_2").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
        hdn_DecorationCost2.value = total;
    }
    else {
        document.getElementById("lblDecorationCost_2").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        hdn_DecorationCost2.value = 0;;
    }
    //}
    //if (decoration == 3) {
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_3");
    var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
    if (ddlValue == 'Yes') {
        var decorationArray = hdn_Decoration3.value.split('~');
      
        var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
        var minimumCost = parseFloat(decorationArray[2])
        var total = cost > minimumCost ? cost : minimumCost
        document.getElementById("lblDecorationCost_3").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
        hdn_DecorationCost3.value = total;
    }
    else {
        document.getElementById("lblDecorationCost_3").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        hdn_DecorationCost3.value = 0;
    }
    //}
    //if (decoration == 4) {
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_4");
    var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
    if (ddlValue == 'Yes') {
        var decorationArray = hdn_Decoration4.value.split('~');
       
        var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
        var minimumCost = parseFloat(decorationArray[2])
        var total = cost > minimumCost ? cost : minimumCost
        document.getElementById("lblDecorationCost_4").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
        hdn_DecorationCost4.value = total;
    }
    else {
        document.getElementById("lblDecorationCost_4").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        hdn_DecorationCost4.value = 0;
    }
    //}
    //if (decoration == 5) {
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_5");
    var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
    if (ddlValue == 'Yes') {
        var decorationArray = hdn_Decoration5.value.split('~');
     
        var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
        var minimumCost = parseFloat(decorationArray[2])
        var total = cost > minimumCost ? cost : minimumCost
        document.getElementById("lblDecorationCost_5").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
        hdn_DecorationCost5.value = total;
    }
    else {
        document.getElementById("lblDecorationCost_5").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        hdn_DecorationCost5.value = 0;
    }
    //}
    //if (decoration == 6) {
    var ddlDecoration = document.getElementById("ctl00_ContentPlaceHolder1_ProductCatalogue_ddlDecoration_6");
    var ddlValue = ddlDecoration.options[ddlDecoration.selectedIndex].value;
    if (ddlValue == 'Yes') {
        var decorationArray = hdn_Decoration6.value.split('~');
      
        var cost = parseFloat(decorationArray[0]) + (Qty * parseFloat(decorationArray[1]))
        var minimumCost = parseFloat(decorationArray[2])
        var total = cost > minimumCost ? cost : minimumCost
        document.getElementById("lblDecorationCost_6").innerHTML = GetCurrencyinRequiredFormate("", true) + Math.round(total).toFixed(2);
        hdn_DecorationCost6.value = total;
    }
    else {
        document.getElementById("lblDecorationCost_6").innerHTML = GetCurrencyinRequiredFormate("", true) + "0.00";
        hdn_DecorationCost6.value = 0;
    }
    //}



}