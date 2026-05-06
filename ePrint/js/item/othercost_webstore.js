
function MatrixTypeChange_new(ddlValue) {
    debugger;
    TotalRow = document.getElementById("PriceTable").rows.length;
    if (ddlValue == "pricebands") {

        for (var i = 0; i < TotalRow; i++) {
            if (document.getElementById("txtQty_from_" + i + "") != null) {
                document.getElementById("txtQty_from_" + i + "").style.display = "block";
                document.getElementById("spn_qty_sep_" + i + "").style.display = "block";
                document.getElementById("div_txtQty_" + i + "").style.width = "50%";
                document.getElementById("txtQty_" + i + "").style.width = "80px";
            }
        }
        divMandatory.style.display = "none";
        document.getElementById("spn_cost").innerHTML = Cost_For1 + " (" + GetCurSym('', true) + ")";
        //document.getElementById("spn_header_sellingprice").innerHTML = "Selling Price For 1 (" + GetCurSym('', true) + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = Selling_Price_For1 + " (" + GetCurSym('', true) + ")";
    }
    else if (ddlValue == "simplematrix") {
        for (var i = 0; i < TotalRow; i++) {
            if (document.getElementById("txtQty_from_" + i + "") != null) {
                document.getElementById("txtQty_from_" + i + "").style.display = "none";
                document.getElementById("spn_qty_sep_" + i + "").style.display = "none";
                document.getElementById("div_txtQty_" + i + "").style.width = "90%";
                divMandatory.style.display = "block";
            }
        }
        document.getElementById("spn_cost").innerHTML = Cost_Display + " (" + GetCurSym('', true) + ")";
        //document.getElementById("spn_header_sellingprice").innerHTML = "Pack Selling Price (" + GetCurSym('', true) + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = Pack_Selling_Price + " (" + GetCurSym('', true) + ")";
    }
}

function Calculate_Markup(sellObj, index) {

    var txtCost = document.getElementById("txtCost_" + index + "");
    var txtMarkup = document.getElementById("txtMarkup_" + index + "");
    var txtSelling = document.getElementById("txtSellingPrice_" + index + "");
    if (txtSelling.value == "") {
        txtSelling.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 3, '', false, false, false);
    }
    if (Number(sellObj.value) != 0 && Number(txtCost.value) != 0) {
        var MarkupValue = Number(Number(sellObj.value) - Number(txtCost.value)) / Number(txtCost.value);
        MarkupValue = Number(MarkupValue) * 100;

        //calculating the sell Price using New Mark up:
        var New_Markup = Number(Number(txtCost.value) * Number(roundNumber(MarkupValue, 2))) / 100;
        var New_Sell = Number(txtCost.value) + Number(New_Markup);

        if (Number(New_Sell) == Number(sellObj.value)) {
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
        }
        else {
            MarkupValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
            MarkupValue = Number(MarkupValue) + 0.01;
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
        }
        txtSelling.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSelling.value, 3, '', false, false, false);
    }
    else if (Number(sellObj.value) != 0 || Number(txtCost.value) != 0) {
        txtCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, sellObj.value, 0, '', false, false, false);
    }
    //txtSelling.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSelling.value, 3, '', false, false, false);
}

//on blur of sellong price in Fixed value
function Calculate_MultipleMarkup(sellObj, index) {

    var txtCost = document.getElementById("txtfixed_or_qty_" + index + "");
    var txtMarkup = document.getElementById("txtMarkup_multiple_" + index + "");
    var txtSelling = document.getElementById("txt_sellingprice_" + index + "");


    if (Number(sellObj.value) != 0 && Number(txtCost.value) != 0 && Number(txtCost.value) && Number(sellObj.value)) {
        var MarkupValue = Number(Number(sellObj.value) - Number(txtCost.value)) / Number(txtCost.value);
        MarkupValue = Number(MarkupValue) * 100;

        //calculating the sell Price using New Mark up:
        var New_Markup = Number(Number(txtCost.value) * Number(roundNumber(MarkupValue, 2))) / 100;
        var New_Sell = Number(txtCost.value) + Number(New_Markup);

        if (Number(New_Sell) == Number(sellObj.value)) {
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
        }
        else {
            MarkupValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
            MarkupValue = Number(MarkupValue) + 0.01;
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
        }
        txtSelling.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSelling.value, 3, '', false, false, false);
    }
    else if ((Number(sellObj.value) != 0 || Number(txtCost.value) != 0) && Number(txtCost.value) && Number(sellObj.value)) {
        txtCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, sellObj.value, 3, '', false, false, false);
    }
    else {
        txtCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 3, '', false, false, false);
        txtSelling.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 3, '', false, false, false);
        txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtMarkup.value, 0, '', false, false, false);
    }
}

function SetMarkupToAll(obj, index) {

    TotalRow = document.getElementById("PriceTable").rows.length;
    for (var i = 0; i < TotalRow; i++) {
        if ((document.getElementById("txtMarkup_" + i + "") != null && i == 0) || (document.getElementById("txtMarkup_" + i + "") != null && parseFloat(document.getElementById("txtMarkup_" + i + "").value) == 0 && i > 0)) {
            document.getElementById("txtMarkup_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);

            var txtCost = document.getElementById("txtCost_" + i + "");
            var txtSellingPrice = document.getElementById("txtSellingPrice_" + i + "");
            if (!isNaN(obj.value)) {
                if (!isNaN(txtCost.value)) {
                    var MarkupValue = (obj.value * txtCost.value) / 100;
                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(txtCost.value), 3, '', false, false, false);
                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 3, '', false, false, false);
                }
                else {
                    txtSellingPrice.value = "0.00";
                }
            }
            else {
                obj.value = "0.00";
            }
        }
    }
}

function CalculateMultipleSellPrice(obj, index) {
    if (ddlCalculationType.value != "quantity") {
        var txtMarkup = document.getElementById("txtMarkup_multiple_" + index + "");
        var txtSellingPrice = document.getElementById("txt_sellingprice_" + index + "");
        if (ddlCalculationType.value == "fixed") {
            if (!isNaN(obj.value)) {
                if (!isNaN(txtMarkup.value)) {
                    var MarkupValue = (txtMarkup.value * obj.value) / 100;
                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(obj.value), 3, '', false, false, false);
                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 3, '', false, false, false);
                    obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 3, '', false, false, false);
                }
            }
            else {
                obj.value = "0.00";
                txtSellingPrice.value = "0.00";
                todecimal_functionForThreeDecimalplace(obj, obj.value);
            }
        }
        else if (ddlCalculationType.value == "Groups" && obj.value==0) {
            obj.value = 0;
        }
    }
}

var chkMandatory = document.getElementById("ctl00_ContentPlaceHolder1_chkMandatory");
function Onchange_calculationType(val) {

    for (var i = 0; i < TotalRowMultiple; i++) {
        var txtfixed_or_qty = document.getElementById("txtfixed_or_qty_" + i + "");
        if (val == "quantity") {
            txtfixed_or_qty.value = "<quantity>";
            document.getElementById("txt_sellingprice_" + i + "").value = "0.000";
            document.getElementById("txtMarkup_multiple_" + i + "").value = "0.000";
            //document.getElementById("spn_FrmOrValue").innerHTML = "Formula / Cost";
            document.getElementById("spn_FrmOrValue").innerHTML = Formula_Cost;
            document.getElementById("spn_sellingprice").style.display = "none";
            document.getElementById("txt_sellingprice_" + i + "").style.display = "none";
            document.getElementById("txtfixed_or_qty_" + i + "").maxlength = "1000";
            document.getElementById("ctl00_ContentPlaceHolder1_div_MultipleFormulaTag").style.display = "block";
            document.getElementById("spn_Markup").style.display = "block";
            document.getElementById("txtMarkup_multiple_" + i + "").style.display = "block";
            //disableOptions(chkMandatory); 
        }
        else if (val == "Groups") {
            document.getElementById("spn_sellingprice").style.display = "none";
            document.getElementById("spn_FrmOrValue").innerHTML = "Groups";
            document.getElementById("spn_sellingprice").style.display = "none";
            document.getElementById("txt_sellingprice_" + i + "").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_div_MultipleFormulaTag").style.display = "none";
            document.getElementById("txtMarkup_multiple_" + i + "").style.display = "none";
            document.getElementById("spn_Markup").style.display = "none";
            txtfixed_or_qty.value = "";
            txtfixed_or_qty.setAttribute("autocomplete", "off");

        }
        else if (val == "fixed") {
            txtfixed_or_qty.value = "";
            // document.getElementById("spn_FrmOrValue").innerHTML = "Cost";
            document.getElementById("spn_FrmOrValue").innerHTML = Formula_Cost;
            document.getElementById("spn_sellingprice").style.display = "block";
            document.getElementById("txt_sellingprice_" + i + "").style.display = "block";
            txtfixed_or_qty.value = "0.000";
            document.getElementById("txt_sellingprice_" + i + "").value = "0.000";
            document.getElementById("txtMarkup_multiple_" + i + "").value = "0.000";
            document.getElementById("txtfixed_or_qty_" + i + "").maxlength = "20";
            document.getElementById("ctl00_ContentPlaceHolder1_div_MultipleFormulaTag").style.display = "none";
            document.getElementById("spn_Markup").style.display = "block";
            document.getElementById("txtMarkup_multiple_" + i + "").style.display = "block";
        }
    }
}

function findduplicatenew(name) {
    if (name != '') {
        document.getElementById('spn_txtOtherCostCategoryName').style.display = "none";
        var OtherCostCategoryid = 0;
        var val = CompanyID + "&" + name + "&" + OtherCostCategoryid;
        PageMethods.FindDuplicateCategory(val, FindSuccNew1, ShowMsg_Failure1);
    }
}

function ShowMsg_Failure1(error) { }
var CheckDuplicateCategory = false;

function FindSuccNew1(result) {
    if (result == -1) {
        document.getElementById("spn_alreadyExistCategory").style.display = "block";
        CheckDuplicateCategory = true;
    }
    else {
        document.getElementById("spn_alreadyExistCategory").style.display = "none";
        CheckDuplicateCategory = false;
    }
}

function import_inventory() {

    // PopupCenter(path + "common/Common_inventory_popup.aspx?type=invselector&pg=setting&item=Paper", '950', '430');
    var oManager = window.radopen(path + "common/Common_inventory_popup.aspx?type=invselector&pg=setting&item=Paper",'import option from invetory', '1200', '500');
    oManager.center();
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}

function SaveFinal() {
    debugger;
    if (ddlMainCalculationID.value == "c") {
        var MultipleChoiceData = '';
        var RemoveChoiceData = '';
        for (var i = 0; i < TotalRowMultiple; i++) {
            if (document.getElementById("txtlabel_" + i + "") != null) {
                var hdn_finalsavetype = document.getElementById("ctl00_ContentPlaceHolder1_hdn_finalsavetype").value;
                var LblValue = document.getElementById("txtlabel_" + i + "").value;
                var txtfixed_or_qty = document.getElementById("txtfixed_or_qty_" + i + "").value;

                var txt_Label = document.getElementById("txtlabel_" + i + "");

                var txtFixed_Qty = document.getElementById("txtfixed_or_qty_" + i + "").value;
                if (txtFixed_Qty == "") {
                    txtFixed_Qty = "0.00";
                }
                var txtMarkup_multiple = document.getElementById("txtMarkup_multiple_" + i + "");
                var ddlCalculationTypeValue = ddlCalculationType.value;
                var ChoiceID = document.getElementById("spn_choiceID_" + i + "");
                var InvID = document.getElementById("spn_InventoryID_" + i + "");
                var RowOrder = document.getElementById("hdn_Multiple_Rownumber_" + i + "");
                var hdn_GroupID = document.getElementById("hdn_GroupID_" + i + "");
                var IsMandatoryField = document.getElementById("hdn_IsMandatoryField_" + i + "");
                //var hdn_finalsavetype = document.getElementById("ctl00_ContentPlaceHolder1_hdn_finalsavetype").value;

                if (hdn_finalsavetype == "add") {
                    if (LblValue != "") {
                        MultipleChoiceData += "CalculationType»" + ddlCalculationType.value + "±";
                        MultipleChoiceData += "Label»" + txt_Label.value + "±";
                        MultipleChoiceData += "Formula»" + txtFixed_Qty + "±";
                        MultipleChoiceData += "Markup»" + txtMarkup_multiple.value + "±";
                        MultipleChoiceData += "ChoiceID»" + ChoiceID.innerHTML + "±";
                        MultipleChoiceData += "InvID»" + InvID.innerHTML + "±";
                        MultipleChoiceData += "GroupID»" + hdn_GroupID.value + "±";
                        MultipleChoiceData += "RowOrderNumber»" + RowOrder.value + "±";
                        MultipleChoiceData += "IsMandatoryField»" + IsMandatoryField.value + "µ";
                    }
                }
                else {
                    if (LblValue != "") {
                        //alert('case Edit');
                        MultipleChoiceData += "CalculationType»" + ddlCalculationType.value + "±";
                        MultipleChoiceData += "Label»" + txt_Label.value + "±";
                        MultipleChoiceData += "Formula»" + txtFixed_Qty + "±";
                        MultipleChoiceData += "Markup»" + txtMarkup_multiple.value + "±";
                        MultipleChoiceData += "ChoiceID»" + ChoiceID.innerHTML + "±";
                        MultipleChoiceData += "InvID»" + InvID.innerHTML + "±";
                        MultipleChoiceData += "GroupID»" + hdn_GroupID.value + "±";
                        MultipleChoiceData += "RowOrderNumber»" + RowOrder.value + "±";
                        MultipleChoiceData += "IsMandatoryField»" + IsMandatoryField.value + "µ";
                    }
                    else if (LblValue == "" && ChoiceID.innerHTML != "") {
                        RemoveChoiceData += "ChoiceID»" + ChoiceID.innerHTML + "±";
                    }
                }
            }

            hid_MultipleChoiceValue.value = MultipleChoiceData;
            hid_RemoveChoiceValue.value = RemoveChoiceData;
        }
        hid_MultipleChoiceValue.value = MultipleChoiceData;
        hid_RemoveChoiceValue.value = RemoveChoiceData;
    }
    else if (ddlMainCalculationID.value == "m") {

        //by gaj
        TotalRow = document.getElementById("PriceTable").rows.length;
        //by gaj
        var PriceData = '';
        for (var i = 0; i < TotalRow; i++) {
            if (document.getElementById("txtQty_" + i + "") != null) {
                var QtyValue = document.getElementById("txtQty_" + i + "").value;

                if (Number(QtyValue) != 0) {
                    var txtQty_From = document.getElementById("txtQty_from_" + i + "");

                    var txtQty = document.getElementById("txtQty_" + i + "");
                    var txtCost = document.getElementById("txtCost_" + i + "");
                    var txtMarkup = document.getElementById("txtMarkup_" + i + "");
                    var txtSellingPrice = document.getElementById("txtSellingPrice_" + i + "");
                    var MatrixID = document.getElementById("spn_matrixID_" + i + "");
                    var RowOrder = document.getElementById("hdn_Matrix_Rownumber_" + i + "");

                    PriceData += "FromQty»" + txtQty_From.value + "±";
                    PriceData += "ToQty»" + txtQty.value + "±";
                    PriceData += "Cost»" + txtCost.value + "±";
                    PriceData += "Markup»" + txtMarkup.value + "±";
                    PriceData += "SellingPrice»" + txtSellingPrice.value + "±";
                    PriceData += "MatrixID»" + MatrixID.innerHTML + "±";
                    PriceData += "RowOrderNumber»" + RowOrder.value + "µ";
                }
            }
            hidQtyPrice.value = PriceData;
        }
        hidQtyPrice.value = PriceData;
    }
}

var divMandatory = document.getElementById("ctl00_ContentPlaceHolder1_divMandatory");
var divNote = document.getElementById("ctl00_ContentPlaceHolder1_divNote");
var chkSubAdditionalOption = document.getElementById("ctl00_ContentPlaceHolder1_chkSubAdditionalOption");

function onchange_option(ddlvalue) {
    debugger;
    if (ddlvalue == "c") {
        div_multiple.style.display = "block";
        div_single.style.display = "none";
        div_matrix.style.display = "none";
        div_freetext.style.display = "none";
        document.getElementById("btnImportInventory").style.display = "block";
        //document.getElementById("spn_option").innerHTML = "Multiple choice question";
        document.getElementById("spn_option").innerHTML = Multiple_Choice_Question;
        document.getElementById("ctl00_ContentPlaceHolder1_DivSubAddition").style.display = "block";
        divMandatory.style.display = "block";
        divNote.style.display = "block";
    }
    else if (ddlvalue == "q") {
        chkMandatory.checked = false;
        disableOptions(chkMandatory);
        divMandatory.style.display = "none";
        divNote.style.display = "none";
        div_freetext.style.display = "none";
        div_multiple.style.display = "none";
        div_single.style.display = "block";
        div_matrix.style.display = "none";
        document.getElementById("btnImportInventory").style.display = "none";
        //document.getElementById("spn_option").innerHTML = "Simple single question";
        document.getElementById("spn_option").innerHTML = Simple_Single_Question;
        document.getElementById("ctl00_ContentPlaceHolder1_DivSubAddition").style.display = "none";
    }
    else if (ddlvalue == "m") {
        //chkMandatory.checked = false;
        //disableOptions(chkMandatory);
        divMandatory.style.display = "block";
        divNote.style.display = "none";
        div_multiple.style.display = "none";
        div_single.style.display = "none";
        div_matrix.style.display = "block";
        div_freetext.style.display = "none";
        document.getElementById("btnImportInventory").style.display = "none";
        //document.getElementById("spn_option").innerHTML = "Matrix";
        document.getElementById("spn_option").innerHTML = Matrix;
        document.getElementById("ctl00_ContentPlaceHolder1_DivSubAddition").style.display = "none";
    }

    else if (ddlvalue == "f" || ddlvalue == "l") {
        //chkMandatory.checked = false;
        //disableOptions(chkMandatory);
        divMandatory.style.display = "block";
        divNote.style.display = "none";
        div_multiple.style.display = "none";
        div_single.style.display = "none";
        div_freetext.style.display = "block";
        div_matrix.style.display = "none";
        document.getElementById("btnImportInventory").style.display = "none";
        //document.getElementById("spn_option").innerHTML = "Simple single question";
        //var dropdown = document.getElementById("ddlMainCalculation");
        //var selectedText = dropdown.options[dropdown.selectedIndex].text;
        if (ddlvalue == "f") {
            ddlMainCalculationID.selectedIndex = 3;
            document.getElementById("spn_option").innerHTML = "Free Text Questions Short";
        }
        else {
            ddlMainCalculationID.selectedIndex = 4;
            document.getElementById("spn_option").innerHTML = "Free Text Questions Long";
        }
        document.getElementById("ctl00_ContentPlaceHolder1_DivSubAddition").style.display = "block";
    }
}

function chkSubAdditionalOption_Check() {
    if (chkSubAdditionalOption.checked) {
        ddlCalculationType.remove(2);
        chkMandatory.checked = false;
        disableOptions(chkMandatory);
    }
    else {
        if (!chkSubAdditionalOption.checked) {
            if (ddlCalculationType.options.length <= 2) {
                var newListItem = document.createElement('OPTION');
                newListItem.text = "Additional Options Group";
                newListItem.value = "Groups";
                ddlCalculationType.add(newListItem);
            }
        }
    }
    var ddlValue = ddlCalculationType.options[ddlCalculationType.selectedIndex].value;
    Onchange_calculationType(ddlValue);
}

if (queryString != "edit") {
    onchange_option(ddlMainCalculationID.options[ddlMainCalculationID.selectedIndex].value);
}

//to get inventory values from inventory poup
function InvUpdateForChoice(valueNew) {

    ddlCalculationType.value = 'fixed';
    ddlCalculationType.SelectedIndex = 0;
    document.getElementById("spn_FrmOrValue").innerHTML = "Cost";
    document.getElementById("spn_sellingprice").style.display = "block";

    var string1 = '';
    var SellingPrice = 0;
    if (valueNew != '') {
        string1 = valueNew.split('µ');
        for (var i = 0; i < string1.length - 1; i++) {
            if (string1[i] != '') {
                var string2 = string1[i].split('±');
                for (var j = 0; j < string2.length; j++) {
                    if (i < (TotalRowMultiple)) {
                        document.getElementById("txtlabel_" + i + "").value = SpecialDecode(string2[0]);
                        document.getElementById("txtfixed_or_qty_" + i + "").value = string2[1].replace(',', '');
                        document.getElementById("txtMarkup_multiple_" + i + "").value = string2[2].replace(',', '');
                        SellingPrice = Number(string2[1].replace(',', '')) + ((Number(string2[1].replace(',', '')) * Number(string2[2].replace(',', '')) / 100));
                        document.getElementById("txt_sellingprice_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(SellingPrice), 0, '', false, false, false);
                        document.getElementById("txt_sellingprice_" + i + "").style.display = "block";
                        document.getElementById("spn_InventoryID_" + i + "").innerHTML = string2[3].replace(',', '');
                    }
                    else if (i > (TotalRowMultiple - 1)) {

                        Click_Add_More_multiple();
                        document.getElementById("txtlabel_" + (TotalRowMultiple - 1) + "").value = string2[0];
                        document.getElementById("txtfixed_or_qty_" + (TotalRowMultiple - 1) + "").value = string2[1].replace(',', '');
                        document.getElementById("txtMarkup_multiple_" + (TotalRowMultiple - 1) + "").value = string2[2].replace(',', '');
                        SellingPrice = Number(string2[1].replace(',', '')) + ((Number(string2[1].replace(',', '')) * Number(string2[2].replace(',', '')) / 100));
                        document.getElementById("txt_sellingprice_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(SellingPrice), 0, '', false, false, false);
                        document.getElementById("txt_sellingprice_" + i + "").style.display = "block";
                        document.getElementById("spn_InventoryID_" + i + "").innerHTML = string2[3].replace(',', '');
                    }
                }
            }
        }
    }
}

function AddCategory(type) {
    var div_Obj = document.getElementById("div_OtherCost_add_item");
    
    if (type == "add") {
        if (navigator.appName != "Microsoft Internet Explorer") {
            setLoadingPositionOfDivMove(div_Obj);
        }
        //  var div_OtherCost_add_item = document.getElementById("div_OtherCost_add_item");
        showDivPopupCenter('div_OtherCost_add_item', '200');
        //showDivPopupCenterWithoutBlur('div_OtherCost_add_item', '200');
        //txtOtherCostCategoryName.focus();
    }
    else if (type == "edit") {
        // var div_OtherCost_add_item = document.getElementById("div_OtherCost_add_item");
        // showDivPopupCenterWithoutBlur('div_OtherCost_add_item', '320');
    }
    else {
        document.getElementById("div_OtherCost_add_item").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
}

function CopyName_toUserFriendlyname() {
    if (Mode == "add") {
        if (txtNameID.value != '' && txtUserfriendlyID.value == '') {
            txtUserfriendlyID.value = txtNameID.value; //.replace(' ', '');
        }
    }
}

function Onbur_MultipleMarkup(obj, index) {

    if (!isNaN(obj.value)) {
        if (ddlCalculationType.value == "fixed") {
            var Price = 0;
            var Markup = 0;
            var SellingPrice = 0;
            if (document.getElementById("txtMarkup_multiple_" + index + "") != null) {
                Markup = document.getElementById("txtMarkup_multiple_" + index + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);
            }
            if (document.getElementById("txtfixed_or_qty_" + index + "") != null) {
                Price = document.getElementById("txtfixed_or_qty_" + index + "").value;
            }
            SellingPrice = Number(Price) + ((Number(Price) * Number(Markup)) / 100);
            document.getElementById("txt_sellingprice_" + index + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(SellingPrice), 3, '', false, false, false);
        }
    }
    else {
        obj.value = "0.00";
        document.getElementById("txtMarkup_multiple_" + index + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);
    }
}

function disableOptions(id) {
    if (type.toLocaleLowerCase() == 'add') {
        var calculationType = document.getElementById("ctl00_ContentPlaceHolder1_ddlCalculationType").value;
        var txtQuantity = document.getElementById("txtfixed_or_qty_0");
        var txMarkup = document.getElementById("txtMarkup_multiple_0");
        var txtSellingPrice = document.getElementById("txt_sellingprice_0");
        var txtfixed_or_qty = document.getElementById("txtfixed_or_qty_0");
        var chkSubAdditionalOption = document.getElementById("ctl00_ContentPlaceHolder1_chkSubAdditionalOption");
        var IsMandatoryField = document.getElementById("hdn_IsMandatoryField_0");
        var hdn_GroupID = document.getElementById("hdn_GroupID_0");
        if (id.checked) {
            if (ddlMainCalculationType.value == "c") {
                if (txtQuantity != null)
                    txtQuantity.setAttribute("disabled", "true");
                if (txMarkup != null)
                    txMarkup.setAttribute("disabled", "true");
                if (txtSellingPrice != null)
                    txtSellingPrice.setAttribute("disabled", "true");
                if (IsMandatoryField != 'undefined' && IsMandatoryField != undefined && IsMandatoryField != null) {
                    IsMandatoryField.value = '1';
                }
                if (hdn_GroupID != null) {
                    hdn_GroupID.value = "0";
                }
                txtQuantity.value = "0.00";
                txMarkup.value = "0.00";
                txtSellingPrice.value = "0.00";
            }
        }
        else {
            if (!chkSubAdditionalOption.checked) {
                if (ddlCalculationType.options.length <= 2) {
                    var newListItem = document.createElement('OPTION');
                    newListItem.text = "Additional Options Group";
                    newListItem.value = "Groups";
                    ddlCalculationType.add(newListItem);
                }
            }
            if (txtQuantity != null)
                txtQuantity.removeAttribute("disabled");
            if (txMarkup != null)
                txMarkup.removeAttribute("disabled");
            if (txtSellingPrice != null)
                txtSellingPrice.removeAttribute("disabled");
        }
        //var ddlValue = ddlCalculationType.options[ddlCalculationType.selectedIndex].value;
        //if (type != "edit") {
        //    Onchange_calculationType(ddlValue);
        //}
    } else {
        var tb_Multiplechoice = document.getElementById('tb_Multiplechoice').rows;
        var tb_Multiplechoice_row_lenth = document.getElementById('tb_Multiplechoice').rows.length;
        var calculationType = document.getElementById("ctl00_ContentPlaceHolder1_ddlCalculationType").value;
        var chkSubAdditionalOption = document.getElementById("ctl00_ContentPlaceHolder1_chkSubAdditionalOption");
        var hdn_GroupID = document.getElementById("hdn_GroupID_0");
        for (var len = 0; len < tb_Multiplechoice_row_lenth - 1; len++) {
            var IsMandatoryField = document.getElementById("hdn_IsMandatoryField_" + len);
            if (typeof IsMandatoryField != 'undefined' && IsMandatoryField != undefined && IsMandatoryField != null) {
                var txtQuantity = document.getElementById("txtfixed_or_qty_" + len);
                var txMarkup = document.getElementById("txtMarkup_multiple_" + len);
                var txtSellingPrice = document.getElementById("txt_sellingprice_" + len);
                var txtfixed_or_qty = document.getElementById("txtfixed_or_qty_" + len);
                if (IsMandatoryField.value == '1') {
                    break;
                }
            }
        }

        if (id.checked) {

            if (ddlMainCalculationType.value == "c") {
                if (txtQuantity != null)
                    txtQuantity.setAttribute("disabled", "true");
                if (txMarkup != null)
                    txMarkup.setAttribute("disabled", "true");
                if (txtSellingPrice != null)
                    txtSellingPrice.setAttribute("disabled", "true");
                if (typeof IsMandatoryField != 'undefined' && IsMandatoryField != undefined && IsMandatoryField != null) {
                    IsMandatoryField.value = '1';
                }
                if (hdn_GroupID != null) {
                    hdn_GroupID.value = "0";
                }
                txtQuantity.value = "0.00";
                txMarkup.value = "0.00";
                if (txtSellingPrice != null || txtSellingPrice != undefined) {
                    txtSellingPrice.value = "0.00";
                }
            }
        }
        else {
            if (!chkSubAdditionalOption.checked) {
                if (ddlCalculationType.options.length <= 2) {
                    var newListItem = document.createElement('OPTION');
                    newListItem.text = "Additional Options Group";
                    newListItem.value = "Groups";
                    ddlCalculationType.add(newListItem);
                }
            }
            if (txtQuantity != null)
                txtQuantity.removeAttribute("disabled");
            if (txMarkup != null)
                txMarkup.removeAttribute("disabled");
            if (txtSellingPrice != null)
                txtSellingPrice.removeAttribute("disabled");
        }
    }
}

function displayCheckBox() {
    if (ddlMainCalculationType.value == "c") {
        divMandatory.style.display = "block";
        divNote.style.display = "block";
    }
}

var CheckFinal = false;
function CallValidation() {
    debugger;
    CheckFinal = false;

    var txtName = trim12(txtNameID.value);
    if (txtName == '') {
        document.getElementById("spn_txtName").style.display = "block";
        CheckFinal = true;
    }

    var txtUserfriendly = trim12(txtUserfriendlyID.value);
    if (txtUserfriendly == '') {
        document.getElementById("spn_txtUserfriendly").style.display = "block";
        CheckFinal = true;
    }

    var ddlCategory = ddlCategoryID.value;
    var ddlCategory = ddlCategoryID.options[ddlCategoryID.selectedIndex].value;

    if (Category_ID == "no") {
        if (ddlCategory == '0') {
            document.getElementById("spn_ddlCategory").style.display = "block";
            CheckFinal = true;
        }
    }

    var ddlMainCalculation = ddlMainCalculationID.value;
    if (ddlMainCalculation == 'q') {
        if (txtQuestionID.value == '') {
            document.getElementById("spn_txtQuestion").style.display = "block";
            CheckFinal = true;
        }
        if (txtFormulaID.value == '') {
            document.getElementById("spn_txtFormula").style.display = "block";
            CheckFinal = true;
        }
    }
    else if (ddlMainCalculation == 'c') {
        var txtlabel = document.getElementById("txtlabel_0");
        if (txtlabel.value == '') {
            document.getElementById("spn_MultipleChoice").style.display = "block";
            CheckFinal = true;
        }
        var txtfixed = document.getElementById("txtfixed_or_qty_0");
        if (txtfixed.value == '') {
            if (!txtfixed.disabled) {
                document.getElementById("spn_MultipleChoice").style.display = "block";
                CheckFinal = true;
            }
        }
        if (ddlCalculationType.value == "fixed") {

            var FixedValue = '';
            for (var k = 0; k < TotalRowMultiple; k++) {
                FixedValue = document.getElementById("txtfixed_or_qty_" + k + "");

                if (Number(FixedValue) != 0) {
                    if (FixedValue.value != '') {
                        if (!Number(FixedValue.value) && Number(FixedValue.value) != "0.00") {
                            document.getElementById("spn_MultipleChoice").innerHTML = "Please Enter Only Numbers to Fixed Value Column";
                            document.getElementById("spn_MultipleChoice").style.display = "block";
                            document.getElementById("txtfixed_or_qty_" + k + "").value = "0.00";
                            CheckFinal = true;
                        }
                        else {
                            document.getElementById("txtfixed_or_qty_" + k + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(FixedValue.value), 3, '', false, false, false);
                        }
                    }
                }
            }
        }
    }

    if (CheckFinal) {
        return false;
    }
    else {
        if (CheckDuplicate) {
            //yes Its duplicate
            return false;
        }
            //no duplicate
        else {
            SaveFinal();
            return true;
        }
    }
}

function checkduplicateName() {

    var CheckValidationCategory = false;
    document.getElementById('spn_txtOtherCostCategoryName').style.display = "none";
    var txtOtherCostCategoryName = document.getElementById("ctl00_ContentPlaceHolder1_txtOtherCostCategoryName");
    if (txtOtherCostCategoryName.value.trim() == '') {
        document.getElementById('spn_txtOtherCostCategoryName').style.display = "block";
        document.getElementById("spn_alreadyExistCategory").style.display = "none";
        CheckValidationCategory = true;
    }

    else if (CheckDuplicateCategory) {
        CheckValidationCategory = true;
    }
    else {
        Category_ID = "Yes";
        CheckValidationCategory = false;
        document.getElementById("div_OtherCost_add_item").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
    if (CheckValidationCategory) {
        return false;
    }
    else {
        return true;
    }
}