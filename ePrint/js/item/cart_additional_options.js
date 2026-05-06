
function MatrixTypeChange_new(ddlValue) {
    if (ddlValue == "pricebands") {
        for (var i = 0; i < TotalRow; i++) {
            if (document.getElementById("txtQty_from_" + i + "") != null) {
                document.getElementById("txtQty_from_" + i + "").style.display = "block";
                document.getElementById("spn_qty_sep_" + i + "").style.display = "block";
                document.getElementById("div_txtQty_" + i + "").style.width = "50%";
                document.getElementById("txtQty_" + i + "").style.width = "80px";
            }
        }
        document.getElementById("spn_cost").innerHTML = "Cost For 1 (" + GetCurrencyinRequiredFormate("",true) + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = "Selling Price For 1 (" + GetCurrencyinRequiredFormate("",true) + ")";
    }
    else if (ddlValue == "simplematrix") {
        for (var i = 0; i < TotalRow; i++) {
            if (document.getElementById("txtQty_from_" + i + "") != null) {
                document.getElementById("txtQty_from_" + i + "").style.display = "none";
                document.getElementById("spn_qty_sep_" + i + "").style.display = "none";
                document.getElementById("div_txtQty_" + i + "").style.width = "90%";

            }
        }
        document.getElementById("spn_cost").innerHTML = "Cost (" + GetCurrencyinRequiredFormate("",true) + ")";
        document.getElementById("spn_header_sellingprice").innerHTML = "Pack Selling Price (" + GetCurrencyinRequiredFormate("",true) + ")";
    }
}

function Calculate_Markup(sellObj, index) {
    debugger;
    var txtCost = document.getElementById("txtCost_" + index + "");
    var txtMarkup = document.getElementById("txtMarkup_" + index + "");
    var txtSelling = document.getElementById("txtSellingPrice_" + index + "");
    if (txtSelling.value == "") {
        txtSelling.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0.00, 3, '', false, false, false);
    }
    if (Number(sellObj.value) != 0 && Number(txtCost.value) != 0) {
        var MarkupValue = Number(Number(sellObj.value) - Number(txtCost.value)) / Number(txtCost.value);
        MarkupValue = Number(MarkupValue) * 100;

        //calculating the sell Price using New Mark up:
        var New_Markup = Number(Number(txtCost.value) * Number(roundNumber(MarkupValue, 6))) / 100;
        var New_Sell = Number(txtCost.value) + Number(New_Markup);

        if (Number(New_Sell) == Number(sellObj.value)) {
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
        }
        else {
            MarkupValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
            MarkupValue = Number(MarkupValue) + 0.01;
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue,6, '', false, false, false);
        }
        txtSelling.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSelling.value, 6, '', false, false, false);
    }
    else if (Number(sellObj.value) != 0 || Number(txtCost.value) != 0)
     {
        txtCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, sellObj.value, 6, '', false, false, false);
    }
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
        var New_Markup = Number(Number(txtCost.value) * Number(roundNumber(MarkupValue, 6))) / 100;
        var New_Sell = Number(txtCost.value) + Number(New_Markup);

        if (Number(New_Sell) == Number(sellObj.value)) {
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
        }
        else {
            MarkupValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
            MarkupValue = Number(MarkupValue) + 0.01;
            txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 6, '', false, false, false);
        }
        txtSelling.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSelling.value, 6, '', false, false, false);
    }
    else if ((Number(sellObj.value) != 0 || Number(txtCost.value) != 0) && Number(txtCost.value) && Number(sellObj.value)) {
        txtCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, sellObj.value, 6, '', false, false, false);
    }
    else {
        txtCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0.000000, 6, '', false, false, false);
        txtSelling.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0.000000, 6, '', false, false, false);
        txtMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0.000000, 0, '', false, false, false);
    }
}

function SetMarkupToAll(obj, index) {
    for (var i = 0; i < TotalRow; i++) {
        if ((document.getElementById("txtMarkup_" + i + "") != null && i == 0) || (document.getElementById("txtMarkup_" + i + "") != null && parseFloat(document.getElementById("txtMarkup_" + i + "").value) == 0 && i > 0)) {
            document.getElementById("txtMarkup_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 6, '', false, false, false);

            var txtCost = document.getElementById("txtCost_" + i + "");
            var txtSellingPrice = document.getElementById("txtSellingPrice_" + i + "");
            if (!isNaN(obj.value)) {
                if (!isNaN(txtCost.value)) {
                    var MarkupValue = (obj.value * txtCost.value) / 100;
                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(txtCost.value), 6, '', false, false, false);
                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 6, '', false, false, false);
                }
                else {
                    txtSellingPrice.value = "0.00000";
                }
            }
            else {
                obj.value = "0.000000";
            }
        }
    }
}

function CalculateMultipleSellPrice(obj, index) {
    if (ddlCalculationType.value != "quantity") {
        var txtMarkup = document.getElementById("txtMarkup_multiple_" + index + "");
        var txtSellingPrice = document.getElementById("txt_sellingprice_" + index + "");

        if (!isNaN(obj.value)) {
            if (!isNaN(txtMarkup.value)) {
                var MarkupValue = (txtMarkup.value * obj.value) / 100;
                txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(obj.value), 6, '', false, false, false);
                txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 6, '', false, false, false);
                obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 6, '', false, false, false);
            }
        }
        else {
            obj.value = "0.000000";
            txtSellingPrice.value = "0.000000";
        }
        todecimal_function(obj, obj.value);
    }
}

function Onchange_calculationType(val) {
    //    var ddlValue = ddlCalculationType.options[ddlCalculationType.selectedIndex].value;
    //    alert(ddlValue);
    for (var i = 0; i < TotalRowMultiple; i++) {
        var txtfixed_or_qty = document.getElementById("txtfixed_or_qty_" + i + "");
        if (val == "quantity") {
            txtfixed_or_qty.value = "";
            document.getElementById("spn_FrmOrValue").innerHTML = "Formula / Cost";
            document.getElementById("spn_sellingprice").style.display = "none";
            document.getElementById("txt_sellingprice_" + i + "").style.display = "none";
            document.getElementById("txtfixed_or_qty_" + i + "").maxlength = "1000";
            document.getElementById("ctl00_ContentPlaceHolder1_div_MultipleFormulaTag").style.display = "block";            
        }
        else if (val = "fixed") {
            txtfixed_or_qty.value = "";
            document.getElementById("spn_FrmOrValue").innerHTML = "Cost";
            document.getElementById("spn_sellingprice").style.display = "block";
            document.getElementById("txt_sellingprice_" + i + "").style.display = "block";
            txtfixed_or_qty.value = "0.00";
            document.getElementById("txtMarkup_multiple_" + i + "").value = "0.00";
            document.getElementById("txt_sellingprice_" + i + "").value = "0.00";
            document.getElementById("txtfixed_or_qty_" + i + "").maxlength = "20";
            document.getElementById("ctl00_ContentPlaceHolder1_div_MultipleFormulaTag").style.display = "none";
        }
    }
}

function findduplicatenew(name) {
    if (name != '') {
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

function SaveFinal() {
    if (ddlMainCalculationID.value == "c") {
        var MultipleChoiceData = '';
        for (var i = 0; i < TotalRowMultiple; i++) {
            if (document.getElementById("txtlabel_" + i + "") != null) {
                var LblValue = document.getElementById("txtlabel_" + i + "").value;

                if (LblValue != "") {
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
                    var IsMandatoryField = document.getElementById("hdn_IsMandatoryField_" + i + "");

                    MultipleChoiceData += "CalculationType»" + ddlCalculationType.value + "±";
                    MultipleChoiceData += "Label»" + txt_Label.value + "±";
                    MultipleChoiceData += "Formula»" + txtFixed_Qty + "±";
                    MultipleChoiceData += "Markup»" + txtMarkup_multiple.value + "±";
                    MultipleChoiceData += "ChoiceID»" + ChoiceID.innerHTML + "±";
                    MultipleChoiceData += "InvID»" + InvID.innerHTML + "±";
                    MultipleChoiceData += "RowOrderNumber»" + RowOrder.value + "±";
                    MultipleChoiceData += "IsMandatoryField»" + IsMandatoryField.value + "µ";
                }
            }

            hid_MultipleChoiceValue.value = MultipleChoiceData;
        }
        hid_MultipleChoiceValue.value = MultipleChoiceData;
    }
    else if (ddlMainCalculationID.value == "m") {
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
                    MultipleChoiceData += "RowOrderNumber»" + RowOrder.value + "µ";
                }
            }
            hidQtyPrice.value = PriceData;
        }
        hidQtyPrice.value = PriceData;
    }
}

var Multiple_Choice = "";
var Simple_Single_Question="";
var MAxtrix="";

function onchange_option(ddlvalue) {
    if (ddlvalue == "c") {
        PageMethods.LanguageConversion("Multiple_choice_question", GetLCForMultiple_Choice, onError);        
        div_multiple.style.display = "block";
        div_single.style.display = "none";
        div_matrix.style.display = "none";
        //document.getElementById("spn_option").innerHTML = "Multiple choice question";        
    }
    else if (ddlvalue == "q") {
        PageMethods.LanguageConversion("Simple_single_question", GetLCForMultiple_Choice, onError);       
        div_multiple.style.display = "none";
        div_single.style.display = "block";
        div_matrix.style.display = "none";
        //document.getElementById("spn_option").innerHTML = "Simple single question";        
    }
    else if (ddlvalue == "m") {
        PageMethods.LanguageConversion("Matrix", GetLCForMultiple_Choice, onError);       
        div_multiple.style.display = "none";
        div_single.style.display = "none";
        div_matrix.style.display = "block";
        //document.getElementById("spn_option").innerHTML = "Matrix";        
    }
}
if (queryString != "edit") {
    onchange_option(ddlMainCalculationID.options[ddlMainCalculationID.selectedIndex].value);
}

function GetLCForMultiple_Choice(result) {
    document.getElementById("spn_option").innerHTML = result;
    //alert('Inside ' + Supplier);
}

function onError(objError) {
    //            alert(objError + " objError");

}

function AddCategory(type) {
    var div_Obj = document.getElementById("div_OtherCost_add_item");
    var btnCategorySave = document.getElementById("<%=btnCategorySave.ClientID %>");

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
                Markup = document.getElementById("txtMarkup_multiple_" + index + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 6, '', false, false, false);
            }
            if (document.getElementById("txtfixed_or_qty_" + index + "") != null) {
                Price = document.getElementById("txtfixed_or_qty_" + index + "").value;
            }
            SellingPrice = Number(Price) + ((Number(Price) * Number(Markup)) / 100);
            document.getElementById("txt_sellingprice_" + index + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(SellingPrice), 6, '', false, false, false);
        }
    }
    else {
        obj.value = "0.000000";
        document.getElementById("txtMarkup_multiple_" + index + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 6, '', false, false, false);
    }
}

var CheckFinal = false;
function CallValidation() {
    if (validate_Account()) {
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
                document.getElementById("spn_MultipleChoice").style.display = "block";
                CheckFinal = true;
            }
            if (ddlCalculationType.value == "fixed") {
                var FixedValue = '';
                for (var k = 0; k < TotalRowMultiple; k++) {

                    FixedValue = document.getElementById("txtfixed_or_qty_" + k + "");
                    if (document.getElementById("div_row_multiple" + k + "") != null) {
                        if (FixedValue.value != '') {
                            if (!Number(FixedValue.value) && Number(FixedValue.value) != "0.00") {
                                document.getElementById("spn_MultipleChoice").innerHTML = "Please Enter Only Numbers to Fixed Value Column";
                                document.getElementById("spn_MultipleChoice").style.display = "block";
                                document.getElementById("txtfixed_or_qty_" + k + "").value = "0.00";
                                CheckFinal = true;
                            }
                            else {
                                document.getElementById("txtfixed_or_qty_" + k + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(FixedValue.value), 0, '', false, false, false);
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
    else {
        return false;

    }
}

function checkduplicateName() {
    var CheckValidationCategory = false;
    document.getElementById('spn_txtOtherCostCategoryName').style.display = "none";
    if (trim12(txtOtherCostCategoryName.value) == '') {
        document.getElementById('spn_txtOtherCostCategoryName').style.display = "block";
        CheckValidationCategory = true;
    }
    else {
        document.getElementById("div_OtherCost_add_item").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

    if (trim12(txtname) == '') {
        document.getElementById('spn_txtOtherCostCategoryName').style.display = "block";
        CheckValidationCategory = true;
    }

    if (CheckValidationCategory) {
        return false;
    }
    else {
        if (CheckDuplicateCategory) {
            return false;
        }
        else {
            Category_ID = "Yes";
            return true;
        }
    }
}

function ChkCostdisable() {

    if (chkcost.checked) {
        if (ddlCalculationType.value == "fixed") {
            document.getElementById("txtfixed_or_qty_0").disabled = true;
            document.getElementById("txtMarkup_multiple_0").disabled = true;
            document.getElementById("txt_sellingprice_0").disabled = true;
        }
        else {
            document.getElementById("txtfixed_or_qty_0").disabled = true;
            document.getElementById("txtMarkup_multiple_0").disabled = true;
        }
        document.getElementById("txtfixed_or_qty_0").value = "0.00";
        document.getElementById("txtMarkup_multiple_0").value = "0.00";
        document.getElementById("txt_sellingprice_0").value = "0.00";
        document.getElementById("hdn_IsMandatoryField_0").value = "1";
    }
    else {
        if (ddlCalculationType.value == "fixed") {
            document.getElementById("txtfixed_or_qty_0").disabled = false;
            document.getElementById("txtMarkup_multiple_0").disabled = false;
            document.getElementById("txt_sellingprice_0").disabled = false;
        }
        else {
            document.getElementById("txtfixed_or_qty_0").disabled = false;
            document.getElementById("txtMarkup_multiple_0").disabled = false;
        }
    }
}