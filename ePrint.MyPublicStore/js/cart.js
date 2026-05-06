
var IsApplyed = false;
var subtotal = 0;

function Calculate_GrandTotal() {
    debugger
    var ShoppingLength = hid_ItemsLength.value;
    var grandTotal = '0';
    var totalTax = '0';
    if (ShoppingLength != "0") {
        for (var j = 0; j <= ShoppingLength - 1; j++) {
            totalTax = Number(totalTax) + Number(document.getElementById("ctl00_ContentPlaceHolder1_lbl_tax_" + j).innerHTML.replace(',', '').replace(',', '').replace(',', ''));
            grandTotal = Number(grandTotal) + Number(document.getElementById("ctl00_ContentPlaceHolder1_lbl_subTotal_" + j).innerHTML.replace(',', '').replace(',', '').replace(',', ''));
        }
        //lbl_grandTotal.innerHTML = ' $ ' + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(totalTax + grandTotal), 2, '', false, false, false);
        lbl_grandTotal.innerHTML = formatCurrency(Number(totalTax + grandTotal));

        lbl_grandTotal.innerHTML = formatCurrency(Number(0));
    }
    Final_Cart_TotalPrice();
}
Calculate_GrandTotal();

function delete_cartitems(SessionID, ID, imageID, CartItemID) {
    if (confirm("Are you sure you want to delete this item from the cart?") == true) {
        AutoFill.Delete_CartItem(SessionID, StoreUserID, ID, CartItemID, GetResult, onTimeout, onError);
        return true;
    }
    else {
        return false;
    }
}

function EditItem(ProductName, CartID, ProductID) {


    window.location = strSitePath + "products/" + ProductName + KeySeparator + ProductID + KeySeparator + "0" + FileExtension + "?type=edit&CartID=" + CartID + "&ProductID=" + ProductID;


    //    window.location = strSitepath + "shoppingcart" + KeySeparator + "0" + KeySeparator + "0" + FileExtension;
}



// by natu,SetCartAdditionalddl(imageID),
function SetCartAdditionalddl(id) {
    if (id == "img_trash_0") {
        var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_0");
        ddlMultiple.options[ddlMultiple.selectedIndex].selectedIndex = 0;
        //alert(ddlMultiple.options[ddlMultiple.selectedIndex].selectedIndex);

        var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
        var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].innerText;

    }
}


function GetResult(result) {
    debugger;
    if (result == 1) {
        if (Rewritemodule.toLowerCase() == 'on') {
            window.location = strSitepath + "shoppingcart" + KeySeparator + "0" + KeySeparator + "0" + FileExtension;
        }
        else {
            window.location = strSitepath + "shoppingcart.aspx?ID=0&PID=0";
        }
    }
}

function onTimeout(request, context) { }
function onError(objError) { }

function Onclick_Product() {
    if (Rewritemodule.toLowerCase() == 'on') {
        window.location = strSitepath + 'products/' + CatalogueName + KeySeparator + productid_new + FileExtension;
    }
    else {
        window.location = strSitepath + "products/productdetails.aspx?ID=" + productid_new + "&type=" + CatalogueName;
    }
}

function JobNameUpdate_InLogin() {
    for (var i = 0; i < hid_ItemsLength.value; i++) {
        lbl_CatrItemId = document.getElementById("ctl00_ContentPlaceHolder1_lbl_CatrItemId_" + i + "");
        txt_jobName = document.getElementById("ctl00_ContentPlaceHolder1_txt_jobName_" + i + "");
        hid_finalSave.value = hid_finalSave.value + "CartItemID±" + lbl_CatrItemId.innerHTML + "»JobName±" + txt_jobName.value + "µ";

        hid_SaveToAdditionalItems.value = document.getElementById("ctl00_ContentPlaceHolder1_hid_SaveToAdditionalItems").value;

        AutoFill.Update_CartItems(hid_finalSave.value, hid_SaveToAdditionalItems.value, RedirctToLogin());
    }
}

function RedirctToLogin() {
    window.location = strSitepath + "login.aspx";
}

function onclick_Checkout() {
    debugger;
    if (CartJobNameIsMandatory.toLowerCase() == "true") {
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'text' && e.name.indexOf('txt_jobName') != -1) {
                if (!e.disabled) {
                    if (e.value == "") {
                        alert(SpecialDecode(jobScreenNameForAlert) + " are mandatory, Please enter " + SpecialDecode(jobScreenNameForAlert));
                        e.focus();
                        return false;
                    }
                }
            }
        }
    }

    var hdnID = document.getElementById("ctl00_ContentPlaceHolder1_hdnChecked");
    hdnID.value = "";
    var IsProductsDeleted = false;
    var DeletedProductsName = '';
    var DeletedProductsCount = 0;

    for (var i = 0; i < hid_ItemsLength.value; i++) {
        lbl_CatrItemId = document.getElementById("ctl00_ContentPlaceHolder1_lbl_CatrItemId_" + i + "");
        txt_jobName = document.getElementById("ctl00_ContentPlaceHolder1_txt_jobName_" + i + "");
        hid_finalSave.value = hid_finalSave.value + "CartItemID±" + lbl_CatrItemId.innerHTML + "»JobName±" + txt_jobName.value + "µ";
        hdnID.value += lbl_CatrItemId.innerHTML + ',';

        var hdnProdDeltd = document.getElementById("ctl00_ContentPlaceHolder1_hdnProdDeltd_" + lbl_CatrItemId.innerHTML).value;
        if (hdnProdDeltd == 'true') {
            IsProductsDeleted = true;

            var hdnProdName = document.getElementById("ctl00_ContentPlaceHolder1_hdnProductName_" + lbl_CatrItemId.innerHTML).value;

            DeletedProductsName += SpecialDecode(hdnProdName) + ', ';
            DeletedProductsCount++;
        }
    }

    var frm = document.forms[0];
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.name.indexOf('ddlMultiple') != -1) {
            if (e.getAttribute("isRequired").toString().toLowerCase() == 'true' && (e.selectedIndex == 0 || e.selectedIndex == -1)) {
                alert('Please select shopping cart option');
                return false;
            }
        }
    }

    if (IsProductsDeleted) {
        DeletedProductsName = DeletedProductsName.substring(0, DeletedProductsName.length - 2);
        if (DeletedProductsCount > 1) {
            alert(Order_Deltd_Prod_Msg1 + DeletedProductsName + Order_Deltd_Prod_Msg2);
        }
        else {
            alert(Order_Deltd_Prod_Msg4 + DeletedProductsName + Order_Deltd_Prod_Msg3);
        }
        return false;
    }
    else {
        Save_Cart_AdditionalOptions();
        hid_SaveToAdditionalItems.value = document.getElementById("ctl00_ContentPlaceHolder1_hid_SaveToAdditionalItems").value;

        if (hdnID.value != "") {
            hdnID.value = hdnID.value.substring(0, hdnID.value.length - 1);
            hdnCount = hdnID.value.split(",");
        }
        if (StatusTitle.toLowerCase() == "account on hold") {
            alert(Accountsonhold);
            return false;
        }

        if (StoreUserID == "0") {
            AutoFill.Update_CartItems(hid_finalSave.value, hid_SaveToAdditionalItems.value, hdnID.value, 'No', Resultcheck, onTimeout, onError);
        }
        else {
            if (ProductStockManagement == 'true') {

                AutoFill.Update_CartItems(hid_finalSave.value, hid_SaveToAdditionalItems.value, hdnID.value, 'BackOrder_Check', ResultShopping, onTimeout, onError);
            }
            else {
                AutoFill.Update_CartItems(hid_finalSave.value, hid_SaveToAdditionalItems.value, hdnID.value, 'No', ResultShopping, onTimeout, onError);
                loadingimage('ctl00_ContentPlaceHolder1_btn_proceedCheckout', 'div_CheckOutProcess');
            }
        }
        return false;
    }
}

function Resultcheck() {

    //    if (Rewritemodule.toLowerCase() == 'on') {
    //        window.location = strSitepath + "login" + FileExtension + "?from=cart";
    //    }
    //    else {
    //        window.location = strSitepath + "login.aspx?from=cart";
    //    }

    ShowLogin()
    return false;
}

function ResultShopping(result) {
    debugger;
    var _splititemtitle = result.split('♠');
    var _isbackorder = _splititemtitle[0].toString().toLowerCase();

    if (_isbackorder == 'true') {
        loadingimage('ctl00_ContentPlaceHolder1_btn_proceedCheckout', 'div_CheckOutProcess');

        if (isCheckOrderInfoPublic == "false" && isCheckAddressInfo == "false") {
            if (Rewritemodule.toLowerCase() == 'on') {
                window.location = strSitepath + "ConfirmBeforeOrdernew" + KeySeparator + OrderKey + KeySeparator + "0" + KeySeparator + "" + KeySeparator + "0" + KeySeparator + "0" + FileExtension;
            }
            else {
                window.location = strSitepath + "ConfirmBeforeOrdernew.aspx?OrdKey=" + OrderKey + "&type=0&key=&BID=0&SID=0"
            }
        }
        else {
            if (Rewritemodule.toLowerCase() == 'on') {
                window.location = strSitepath + "checkoutnew" + FileExtension;
            }
            else {
                window.location = strSitepath + "checkoutnew.aspx";
            }
        }
    }
    else {
        var CheckCumulative = _splititemtitle[2].toString().toLowerCase();
        if (CheckCumulative == 'true') {
            if (_splititemtitle.length > 0) {
                var _productnames = _splititemtitle[1].split('♣');
                var titles = "";
                for (var i = 0; i < _productnames.length; i++) {

                    if (_productnames.length == 1) {
                        titles = _productnames[i];
                    }
                    else {

                        if (titles == "") {
                            titles = _productnames[i];
                        }
                        else {
                            titles = titles + "," + _productnames[i];
                        }
                    }
                }
            }

            alert("One or more of the products you are ordering has insufficient stock to proceed.\nPlease remove or amend the quantity for this product(s): " + titles);
        } else {
            alert("The total quantity of the item you are ordering exceeds the available quantity in stock. Please reduce the quantity and try again.");
        }
    }
}



function onclick_Checkoutshp(page) {

    //Commented bcoz put new loading image 
    //    if (page == 'checkout') {
    //        btn_proceedCheckout.style.display = "none";
    //        img_AddtoCart.style.display = "block";
    //    }

    for (var i = 0; i < hid_ItemsLength.value; i++) {
        lbl_CatrItemId = document.getElementById("ctl00_ContentPlaceHolder1_lbl_CatrItemId_" + i + "");
        txt_jobName = document.getElementById("ctl00_ContentPlaceHolder1_txt_jobName_" + i + "");
        hid_finalSave.value = hid_finalSave.value + "CartItemID±" + lbl_CatrItemId.innerHTML + "»JobName±" + txt_jobName.value + "µ";
    }
    Save_Cart_AdditionalOptions();
    hid_SaveToAdditionalItems.value = document.getElementById("ctl00_ContentPlaceHolder1_hid_SaveToAdditionalItems").value;

    if (page == "checkout") {
        AutoFill.Update_CartItemsNew(hid_finalSave.value, hid_SaveToAdditionalItems.value, Resultcheckshp, onTimeout, onError);
    }
    else {

        AutoFill.Update_CartItemsNew(hid_finalSave.value, hid_SaveToAdditionalItems.value, ResultShoppingshp, onTimeout, onError);
    }
    return false;
}

function Resultcheckshp() {

    if (Rewritemodule.toLowerCase() == 'on') {

        window.location = strSitepath + "checkoutnew" + FileExtension;
    }
    else {

        window.location = strSitepath + "checkoutnew.aspx";
    }
}

function ResultShoppingshp() {
    if (Rewritemodule.toLowerCase() == 'on') {
        window.location = strSitepath + "products" + KeySeparator + 0 + FileExtension;
    }
    else {
        window.location = strSitepath + "products/product.aspx?ID=0";
    }
}

var time_left = 10;
var cinterval;

function time_dec() {
    time_left--;
    if (time_left == 0) {
        clearInterval(cinterval);
        if (cntDown.innerHTML != "No items in cart") {
            productAdded.style.display = "none";
        }
    }
}
cinterval = setInterval('time_dec()', 1000);

function Onclick_img_plus(id) {

    $(document).ready(function () {
        $("#lbl_productDetails_div_" + id).show(200, function () { });
        //$("#lbl_productDetails_div").slideToggle("slow");
        $("#img_plus_" + id).hide();
        $("#img_minus_" + id).show();
    });
}

function Onclick_img_minus(id) {

    $(document).ready(function () {
        $("#lbl_productDetails_div_" + id).hide(200, function () { });
        $("#img_plus_" + id).show();
        $("#img_minus_" + id).hide();
    });
}

$(document).ready(function () {
    $(window).load(function () {
        $(".img_minus").hide();
        $(".lbl_productDetails_div").hide();
    });
});



function Cart_CalculatePrice_Question(Formula, ID) {
    alert("Formula=" + Formula);
    alert("ID=" + ID);
    var sellingPrice = '';
    var txtQuestion = document.getElementById("txtQuestion_" + ID + "");
    var OtherCostID = document.getElementById("lblQuestionID_" + ID + "").innerHTML;

    if (txtQuestion.value != '' && Number(txtQuestion.value) != 0 && Number(txtQuestion.value)) {

        var FormulaTag = Formula;
        for (var i = 0; i <= Formula.length; i++) {
            FormulaTag = FormulaTag.replace('[$TotalEx.GST$]', Number(hid_TotalExTax.value)).replace('[$totalex.gst$]', Number(hid_TotalExTax.value)).replace('[$TotalInc.GST$]', Number(hid_TotalIncTax.value)).replace('[$totalinc.gst$]', Number(hid_TotalIncTax.value)).replace('[$TotalQty$]', Number(hid_TotalQty.value)).replace('[$totalqty$]', Number(hid_TotalQty.value)).replace('[$TotalNo.ofCartItems$]', Number(hdnCartItemCount.value)).replace('[$totalno.ofcartitems$]', Number(hdnCartItemCount.value));
        }

        var dd = eval(FormulaTag);
        if (!isNaN(dd)) {
            AutoFill.CalculateFormulaCost(dd, ID, GetResult1, onTimeout, onError);
        }
        else {
            document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        }
        Final_Cart_TotalPrice();
    }
    else {
        if (!Number(txtQuestion.value)) {
            txtQuestion.value = "";
        }
        document.getElementById("lblPrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        Final_Cart_TotalPrice();
    }
}

function GetResult1(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        //document.getElementById("lblPrice_" + NewResult[1] + "").innerHTML = '$ ' + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);
        document.getElementById("lblPrice_" + NewResult[1] + "").innerHTML = formatCurrency(NewResult[0]);
        Final_Cart_TotalPrice();
    }
}

function Cart_Onchange_MultipleChoice(ID) {
    debugger
    var OthercostID = document.getElementById("lblMultipleID_" + ID + "").innerHTML;

    var chkMultiple = document.getElementById("chkMultiple_" + ID + "");
    var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + ID);
    //alert(ddlMultiple.options[ddlMultiple.selectedIndex].value);
    if (chkMultiple.checked || (ddlMultiple.options[ddlMultiple.selectedIndex].value != "0")) {
        if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase() != "---select---") {
            if (ddlMultiple.options[ddlMultiple.selectedIndex].value == "0") {
                chkMultiple.checked = false;
                document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            }
            else {
                var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                var MultipleValue = ddlMultipleValue.split('~');

                var FormulaTagMul = '';
                FormulaTagMul = MultipleValue[0];
                for (var i = 0; i <= FormulaTagMul.length; i++) {
                    FormulaTagMul = FormulaTagMul.replace('[$TotalEx.GST$]', Number(hid_TotalExTax.value)).replace('[$totalex.gst$]', Number(hid_TotalExTax.value)).replace('[$TotalInc.GST$]', Number(hid_TotalIncTax.value)).replace('[$totalinc.gst$]', Number(hid_TotalIncTax.value)).replace('[$TotalQty$]', Number(hid_TotalQty.value)).replace('[$totalqty$]', Number(hid_TotalQty.value)).replace('[$TotalNo.ofCartItems$]', Number(hdnCartItemCount.value)).replace('[$totalno.ofcartitems$]', Number(hdnCartItemCount.value));
                }

                var dd = eval(FormulaTagMul);
                if (!isNaN(dd)) {
                    AutoFill.CalculateFormulaCost_ForMultipleChoice(dd, Number(MultipleValue[1]), ID, GetResultMultiple, onTimeout, onError);
                }
                else {
                    document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
                    Final_Cart_TotalPrice();
                }
                chkMultiple.checked = true;

            }
        }
        else {
            chkMultiple.checked = false;
            document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
            Final_Cart_TotalPrice();
        }
    }
    else {
        chkMultiple.checked = false;
        document.getElementById("lblMultiplePrice_" + ID + "").innerHTML = GetCurrencyinRequiredFormate("0.00", true);
        Final_Cart_TotalPrice();
    }
}

function GetResultMultiple(result) {
    var NewResult = result.split('~');
    if (!isNaN(NewResult[0])) {
        //document.getElementById("lblMultiplePrice_" + NewResult[1] + "").innerHTML = '$ ' + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, NewResult[0], 2, '', false, false, false);\
        document.getElementById("lblMultiplePrice_" + NewResult[1] + "").innerHTML = formatCurrency(NewResult[0]);
        Final_Cart_TotalPrice();
    }
}

//Tocalculate_totalPrice()
function Cart_Additional_Price() {

    //    if (hid_MatrixLenght.value != "0") {
    //        for (var l = 0; l <= hid_MatrixLenght.value - 1; l++) {
    //            var lblMatrixID = document.getElementById("lblMatrixID_" + l + "").innerHTML;
    //            var lblMatrixType = document.getElementById("lblMatrixType_" + l + "").innerHTML;
    //            MatrixCheck_value(lblMatrixID, l, lblMatrixType);
    //        }
    //    }

    if (hid_QuestionLenght.value != "0") {
        for (var q = 0; q <= hid_QuestionLenght.value - 1; q++) {
            var Formula1 = document.getElementById("lblQuestionFormula_" + q + "").innerHTML;

            var FormulaTag = Formula1;
            for (var i = 0; i <= Formula1.length; i++) {
                FormulaTag = FormulaTag.replace(' ', '').replace(' ', '').replace('</question>', '').replace('</quantity>', '').replace('</input>', '').replace('</ProductBasePrice>', '').replace('</productbaseprice>', '').replace('</SubTotal>', '').replace(' ', '');
            }
            Cart_CalculatePrice_Question(Formula1, q);
        }
    }

    if (hid_MultipleLenght.value != "0") {
        for (var c = 0; c <= hid_MultipleLenght.value - 1; c++) {
            Cart_Onchange_MultipleChoice(c);
        }
    }

    Final_Cart_TotalPrice();
}

Cart_Additional_Price();

function Final_Cart_TotalPrice() {
    var QuestionPrice = '0';
    var MultiplePrice = '0';
    var MatrixPrice = '0';
    var lblTotalPriceID = document.getElementById("ctl00_ContentPlaceHolder1_lblTotalPriceID");
    var lblTotaltaxID = document.getElementById("ctl00_ContentPlaceHolder1_lblTotaltaxID");

    if (hid_MultipleLenght.value != "0") {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            MultiplePrice = Number(MultiplePrice) + Number(document.getElementById("lblMultiplePrice_" + j + "").innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '').replace(',', ''));
        }
    }

    MultiplePrice = MultiplePrice != 'NaN' ? MultiplePrice : '0';
    hid_MultiplePrice.value = MultiplePrice;

    var CartTotalPrice = Number(lblTotalPriceID.innerHTML.replace(',', '')) + Number(MultiplePrice);  //Number(QuestionPrice) + Number(MatrixPrice);
    TaxOnChange(CartTotalPrice, MultiplePrice);
}


function TaxOnChange(CartTotalPrice, MultiplePrice) {

    //alert(CartTotalPrice);
    var TaxRate = document.getElementById("lblTaxRate").innerHTML;
    var lblTotalTax = document.getElementById("ctl00_ContentPlaceHolder1_lblTotaltaxID");
    var TotalPrice;
    var TotalTax = 0;
    TotalPrice = Number(subtotal) + Number(MultiplePrice);
    var TotalMultipleTax = 0;

    TotalMultipleTax = Number((Number(hid_MultiplePrice.value) * Number(TaxRate)) / 100);

    var ShoppingLength = hdnCartItemCount.value;

    TotalPrice = CartTotalPrice;
    if (TotalPrice != '0.00') {
        TotalTax = Number((Number(TotalPrice) * Number(TaxRate)) / 100);
        //lblTotalTax.innerHTML = "$ " + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalTax), 2, '', false, false, false);
        lblTotalTax.innerHTML = formatCurrency(TotalTax + TotalMultipleTax);
    }
    else {
        lblTotalTax.innerHTML = GetCurrencyinRequiredFormate("0.00", true);
    }
    var TotalSellingPrice = Number(TotalPrice) + TotalTax + TotalMultipleTax;
    //lbl_grandTotal.innerHTML = ' $ ' + Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Number(TotalSellingPrice), 2, '', false, false, false);
    lbl_grandTotal.innerHTML = formatCurrency(TotalSellingPrice);

}

/* Return currency in $ 223,000.00 formate (thousands separator) */
function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3) ; i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));

    return (((sign) ? '' : '-') + GetCurrencyinRequiredFormate("", true) + num + '.' + cents);
}
/* Return currency in $ 223,000.00 formate (thousands separator) */

function Save_Cart_AdditionalOptions() {
    var SaveToAdditionalItemsMultiple = '';

    if (Number(hid_MultipleLenght.value) != 0) {
        for (var j = 0; j <= Number(hid_MultipleLenght.value) - 1; j++) {
            var Check = document.getElementById("chkMultiple_" + j);

            if (Check.checked) {

                var SortOrderNo = document.getElementById("lblMultipleSortOrderNo_" + j + "").innerHTML;
                var OthercostID = document.getElementById("lblMultipleID_" + j).innerHTML;
                var ddlMultiple = document.getElementById("ctl00_ContentPlaceHolder1_ddlMultiple_" + j);

                //if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase() != "---select---") {

                var ddlMultipleValue = ddlMultiple.options[ddlMultiple.selectedIndex].value;
                var SelectedValue = ddlMultiple.options[ddlMultiple.selectedIndex].innerText;
                ddlMultipleValue = ddlMultipleValue.split('~');

                var FormulaTagMul = ddlMultipleValue[0];
                var Formula = '';

                for (var i = 0; i <= Formula.length; i++) {
                    FormulaTagMul = FormulaTagMul.replace('[$TotalEx.GST$]', Number(hid_TotalExTax.value)).replace('[$totalex.gst$]', Number(hid_TotalExTax.value)).replace('[$TotalInc.GST$]', Number(hid_TotalIncTax.value)).replace('[$totalinc.gst$]', Number(hid_TotalIncTax.value)).replace('[$TotalQty$]', Number(hid_TotalQty.value)).replace('[$totalqty$]', Number(hid_TotalQty.value)).replace('[$TotalNo.ofCartItems$]', Number(hdnCartItemCount.value)).replace('[$totalno.ofcartitems$]', Number(hdnCartItemCount.value));
                }

                var MarkUp = ddlMultipleValue[1];
                var SelectedID = ddlMultipleValue[2];
                var SelectedPrice = eval(FormulaTagMul);

                var MarkupValue = (Number(SelectedPrice) * Number(MarkUp) / 100);

                if (isNaN(MarkupValue)) {
                    MarkupValue = 0;
                }
                Formula = FormulaTagMul + "+ (((" + FormulaTagMul + ")*" + MarkUp + ")/100)";

                var CartAdditionalTaxPercentage = document.getElementById("lblTaxRate").innerHTML;
                var CartAdditionalTaxID = document.getElementById("lblTaxID").innerHTML;
                var TotalPrice = document.getElementById("lblMultiplePrice_" + j).innerHTML.replace("" + GetCurrencyinRequiredFormate("", true) + "", '').replace(',', '').replace(',', '').replace(',', '');
                var CartAdditionalTaxValue = Number((TotalPrice * CartAdditionalTaxPercentage) / 100);

                //if (ddlMultiple.options[ddlMultiple.selectedIndex].text.toLowerCase() != "---select---") {
                SaveToAdditionalItemsMultiple = SaveToAdditionalItemsMultiple + "StoreUserID»" + StoreUserID + "±SessionID»" + NewSessionID + "±OthercostID»" + OthercostID + "±Formula»" + Formula + "±MarkUp»" + MarkUp + "±TotalPrice»" + TotalPrice + "±MarkUpValue»" + MarkupValue + "±SelectedID»" + SelectedID + "±SelectedValue»" + SelectedValue + "±SelectedPrice»" + SelectedPrice + "±SortOrderNo»" + SortOrderNo + "±CartAdditionalTaxID»" + CartAdditionalTaxID + "±CartAdditionalTaxPercentage»" + CartAdditionalTaxPercentage + "±CartAdditionalTaxValue»" + CartAdditionalTaxValue + "µ";
                //}
                //}
            }
        }
    }

    var AllAdditionalItemsDetails = '';
    if (SaveToAdditionalItemsMultiple != '') {
        hid_SaveToAdditionalItems.value = SaveToAdditionalItemsMultiple;
    }
}

function Pdf_Open(FileName, AccountID, Mode) {
    if (Mode == "pdf") {
        //window.open(StyleSheetPath + "/Pdf/" + FileName, '_blank');
        window.open(strSitepath + "imagehandler.ashx?type=pdf&aid=" + AccountID + "&cid=" + CompanyID + "&ImageName=" + FileName, '_blank');
    }
    else if (Mode == "printready") {
        //  window.open(imagePath + AccountID + "/" + FileName, '_blank');
        window.open(strSitepath + "imagehandler.ashx?type=pr&cid=" + CompanyID + "&ImageName=" + FileName, '_blank');
    }
}

function Pdf_OpenShopping(FileName, AccountID, Mode) {
    if (Mode == "pdf") {
        //window.open(StyleSheetPath + "/Pdf/" + FileName, '_blank');
        window.open(strSitepath + "imagehandler.ashx?type=pdf&aid=" + AccountID + "&cid=" + CompanyID + "&ImageName=" + FileName, '_blank');
    }
    else if (Mode == "printready") {
        //window.open(productImagePath + "PrintReady/" + FileName, '_blank');
        window.open(strSitepath + "imagehandler.ashx?type=pr&aid=" + AccountID + "&cid=" + CompanyID + "&ImageName=" + FileName, '_blank');
    }
}


// added by rk on 09-04-2013 for allowgrouprun case.

function ProductIDandQuantity() {
    var ProductID = 0;
    var CartItemID = 0;
    var TotalQuantity = 0;
    var GroupRun = false;
}

var MainArray = new Array();

function allowgrouprun_calculations() {

    var shippingCart_Table = document.getElementById('shippingCart_Table');
    var shippingCart_TableCount = shippingCart_Table.getElementsByTagName('input');
    for (var i = 0; i < shippingCart_TableCount.length; i++) {
        if (shippingCart_TableCount[i].type == 'checkbox' && shippingCart_TableCount[i].id.indexOf('chkEachLine') != -1) {
            var hdnProductID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnProductID_'));
            var hdnGroupRun = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnGroupRun_'));
            var hdnQuantity = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnQuantity_'));
            var hdnCartItemID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnCartItemID_'));
            var hdnMatrixType = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnMatrixType_'));
            var hdnDimension = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnDimension_'));
            var TotalQuantity = 0;
            var CartItemID = 0;
            var flag = 0;
            var GroupRun = false;

            if (hdnGroupRun.value.toLowerCase() == 'true') {
                for (var j = 0; j < MainArray.length; j++) {
                    if (hdnProductID.value == MainArray[j].ProductID) {
                        TotalQuantity = MainArray[j].TotalQuantity;
                        CartItemID = MainArray[j].CartItemID;
                        GroupRun = hdnGroupRun.value;
                        MainArray.splice(j, 1);
                        flag = 1;
                        break;
                    }
                    if (flag == 1) {
                        break;
                    }
                }
                var ClassObject = new ProductIDandQuantity();
                ClassObject.ProductID = hdnProductID.value;
                if (CartItemID == 0) {
                    ClassObject.CartItemID = hdnCartItemID.value;
                }
                else {
                    ClassObject.CartItemID = CartItemID + "±" + hdnCartItemID.value;
                }

                if (hdnMatrixType.value == 'G') {
                    ClassObject.TotalQuantity = parseFloat(TotalQuantity) + parseFloat(hdnDimension.value);
                }
                else {
                    ClassObject.TotalQuantity = parseInt(TotalQuantity) + parseInt(hdnQuantity.value);
                }
                ClassObject.GroupRun = hdnGroupRun.value;
                MainArray.push(ClassObject);
                TotalQuantity = 0;
            }
            else {// else is required for reorder the same products from myorder 
                var ClassObject = new ProductIDandQuantity();
                ClassObject.ProductID = hdnProductID.value;
                ClassObject.CartItemID = hdnCartItemID.value;

                if (hdnMatrixType.value == 'G') {
                    ClassObject.TotalQuantity = hdnDimension.value;
                }
                else {
                    ClassObject.TotalQuantity = hdnQuantity.value;
                }
                MainArray.push(ClassObject);
                TotalQuantity = 0;
            }
        }
    }

    for (var i = 0; i < MainArray.length; i++) {
        var ArrCartItemID = MainArray[i].CartItemID.split("±");
        if (ArrCartItemID.length > 1) {
            lblNotifyGprunDiscount.innerHTML = "Please note that by ordering the same product multiple times in your cart you are receiving a multi order discount";
        }
        for (var m = 0; m < ArrCartItemID.length; m++) {
            sleep(100);
            asyncState = false;
            if (txt_CouponCode == null || txt_CouponCode == undefined) {
                AutoFill.GetGroupRunUnitPrice(parseInt(MainArray[i].ProductID), parseFloat(MainArray[i].TotalQuantity), ArrCartItemID[m], '', GetGPrunPrice, onTimeout, onError);
            }
            else {
                AutoFill.GetGroupRunUnitPrice(parseInt(MainArray[i].ProductID), parseFloat(MainArray[i].TotalQuantity), ArrCartItemID[m], txt_CouponCode.value, GetGPrunPrice, onTimeout, onError);
            }
            AutoFill.UpdateAdditionalValues(parseInt(MainArray[i].ProductID), parseFloat(MainArray[i].TotalQuantity), ArrCartItemID[m], SetAdditionalOptions, onTimeout, onError);
        }
    }
    MainArray.splice(0, MainArray.length); // must empty the array so that new selected values will be stored on second time click of checkboxs in table grid

}

function sleep(milliseconds) {
    var start = new Date().getTime();
    while ((new Date().getTime() - start) < milliseconds) {
        // Do nothing
    }
}

function GetGPrunPrice(UnitPrice) {
    // alert(UnitPrice);
    var shippingCart_Table = document.getElementById('shippingCart_Table');
    var shippingCart_TableCount = shippingCart_Table.getElementsByTagName('input');
    var SplitUnitPrice;

    SplitUnitPrice = UnitPrice.split("»");

    for (var i = 0; i < shippingCart_TableCount.length; i++) {
        if (shippingCart_TableCount[i].type == 'checkbox' && shippingCart_TableCount[i].id.indexOf('chkEachLine') != -1) {
            var hdnProductID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnProductID_'));
            var hdnGroupRun = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnGroupRun_'));
            var hdnQuantity = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnQuantity_'));
            var hdnCartItemID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnCartItemID_'));
            var hdnlblUnitPrice = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblUnitPrice_'));
            var hdnlblsubtotalID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblsubtotalID_'));
            var hdnlblQtyID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblQtyID_'));
            var lbl_CouponCodeDiscount = document.getElementById("ctl00_ContentPlaceHolder1_lbl_CouponDiscount_" + hdnCartItemID.value);

            var lbl_subTotal_perCartID = document.getElementById(hdnlblsubtotalID.value);
            var lbl_unitPrice = document.getElementById(hdnlblUnitPrice.value);
            var QtyPerRow = document.getElementById(hdnlblQtyID.value).innerHTML;
            var subtotalPerCartItemID = 0;
            if (hdnGroupRun.value.toLowerCase() == 'true') {
                if (hdnProductID.value == SplitUnitPrice[1] && hdnCartItemID.value == SplitUnitPrice[2]) {
                    lbl_unitPrice.innerHTML = RoundupCurrency(SplitUnitPrice[0]);
                    subtotalPerCartItemID = parseFloat(SplitUnitPrice[3]);
                    subtotal =  parseFloat(SplitUnitPrice[3]);
                    lbl_subTotal_perCartID.innerHTML = RoundupCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here

                    if (SplitUnitPrice[4] == '') {
                        lbl_CouponCodeDiscount.innerHTML = '0.00';
                    }
                    else if (txt_CouponCode.value != '') {
                        lbl_CouponCodeDiscount.innerHTML = RoundupCurrency(SplitUnitPrice[4].split('~')[0]);
                        IsApplyed = true;
                    }
                }
            }
            else {
                if (hdnCartItemID.value == SplitUnitPrice[2]) {
                    lbl_unitPrice.innerHTML = RoundupCurrency(SplitUnitPrice[0]);
                    subtotalPerCartItemID = parseFloat(SplitUnitPrice[3]);
                    subtotal =  parseFloat(SplitUnitPrice[3]);
                    lbl_subTotal_perCartID.innerHTML = RoundupCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here                  

                    if (SplitUnitPrice[4] == '') {
                        lbl_CouponCodeDiscount.innerHTML = '0.00';
                    }
                    else if (txt_CouponCode.value != '') {
                        lbl_CouponCodeDiscount.innerHTML = RoundupCurrency(SplitUnitPrice[4].split('~')[0]);
                        IsApplyed = true;
                    }
                }
            }
        }
    }
    ReRuncalTotal();
    Calculate_GrandTotal();
    Cart_Additional_Price();
}

function floorFigure(figure, decimals) {
    if (!decimals) decimals = 2;
    var d = Math.pow(10, decimals);
    return (parseInt(figure * d) / d).toFixed(decimals);
}


function ReRuncalTotal() {
    var cartlength = hdnCartItemCount.value;
    var FinalTotalexcTax = 0;
    var lblTotalPriceID = document.getElementById("ctl00_ContentPlaceHolder1_lblTotalPriceID");
    for (var i = 0; i <= cartlength - 1; i++) {
        var lblsubtotalID = document.getElementById('ctl00_ContentPlaceHolder1_lbl_subTotal_' + i);
        if (lblsubtotalID.innerHTML != '') {
            var subtotal = lblsubtotalID.innerHTML;
            var clnSubtotal = subtotal.replace(",", "");
            FinalTotalexcTax = parseFloat(FinalTotalexcTax) + parseFloat(clnSubtotal);
        }
    }
    lblTotalPriceID.innerHTML = RoundupCurrency(FinalTotalexcTax);
    var TotalPrice = Number(FinalTotalexcTax);
    hid_TotalExTax.value = TotalPrice;
    var TaxRate = document.getElementById("lblTaxRate").innerHTML;
    var lblTotalTax = document.getElementById("ctl00_ContentPlaceHolder1_lblTotaltaxID");
    var TotalTax = 0;
    if (TotalPrice != '0.00') {
        TotalTax = Number((Number(TotalPrice) * Number(TaxRate)) / 100);
    }
    hid_TotalIncTax.value = parseFloat(TotalPrice) + parseFloat(TotalTax);
    TaxOnChange(TotalPrice);
    Calculate_GrandTotal();
    Cart_Additional_Price();
}

function SetAdditionalOptions(result) {


    var AdditionalOptionValues = result.split("∅");
    var shippingCart_Table = document.getElementById('shippingCart_Table');
    var shippingCart_TableCount = shippingCart_Table.getElementsByTagName('input');

    for (var i = 0; i < shippingCart_TableCount.length; i++) {
        if (shippingCart_TableCount[i].type == 'checkbox' && shippingCart_TableCount[i].id.indexOf('chkEachLine') != -1) {
            var hdnProductID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnProductID_'));
            var hdnGroupRun = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnGroupRun_'));
            var hdnQuantity = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnQuantity_'));
            var hdnCartItemID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnCartItemID_'));
            var hdnlblUnitPrice = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblUnitPrice_'));
            var hdnlblsubtotalID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblsubtotalID_'));
            var hdnlblQtyID = document.getElementById(shippingCart_TableCount[i].id.replace('ctl00_ContentPlaceHolder1_chkEachLine', 'hdnlblQtyID_'));
            var lbl_CouponCodeDiscount = document.getElementById("ctl00_ContentPlaceHolder1_lbl_CouponDiscount_" + hdnCartItemID.value);

            var lbl_subTotal_perCartID = document.getElementById(hdnlblsubtotalID.value);
            var lbl_unitPrice = document.getElementById(hdnlblUnitPrice.value);
            var QtyPerRow = document.getElementById(hdnlblQtyID.value).innerHTML;
            var subtotalPerCartItemID = 0;
            if (hdnGroupRun.value.toLowerCase() == 'true') {
                for (var k = 0; k < AdditionalOptionValues.length; k++) {
                    if (AdditionalOptionValues[k] != '') {
                        if (hdnProductID.value == AdditionalOptionValues[k].split("»")[5] && hdnCartItemID.value == AdditionalOptionValues[k].split("»")[6]) {
                            lbl_unitPrice.innerHTML = RoundupCurrency(AdditionalOptionValues[k].split("»")[4]);
                            var subtotalPerCartItemID = parseFloat(AdditionalOptionValues[k].split("»")[7]);
                            lbl_subTotal_perCartID.innerHTML = RoundupCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here
                            if (AdditionalOptionValues[k].split("»")[9] == '') {
                                lbl_CouponCodeDiscount.innerHTML = '0.00';
                            }
                            else if (txt_CouponCode.value != '') {
                                IsApplyed = true;
                                lbl_CouponCodeDiscount.innerHTML = RoundupCurrency(AdditionalOptionValues[k].split("»")[9].split('~')[0]);
                                break;
                            }
                        }
                    }
                }
            }
            else {// else is required for reorder the same products from myorder
                for (var k = 0; k < AdditionalOptionValues.length; k++) {
                    if (AdditionalOptionValues[k] != '') {
                        if (hdnCartItemID.value == AdditionalOptionValues[k].split("»")[6]) {
                            lbl_unitPrice.innerHTML = RoundupCurrency(AdditionalOptionValues[k].split("»")[4]);
                            var subtotalPerCartItemID = parseFloat(AdditionalOptionValues[k].split("»")[7]);
                            lbl_subTotal_perCartID.innerHTML = RoundupCurrency(subtotalPerCartItemID); // give the calculated GroupRunAmount amount here
                            if (AdditionalOptionValues[k].split("»")[9] == '') {
                                lbl_CouponCodeDiscount.innerHTML = '0.00';
                            }
                            else if (txt_CouponCode.value != '') {
                                IsApplyed = true;
                                lbl_CouponCodeDiscount.innerHTML = RoundupCurrency(AdditionalOptionValues[k].split("»")[9].split('~')[0]);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
    ReRuncalTotal();
    Calculate_GrandTotal();
    Cart_Additional_Price();

    for (var i = 0; i < AdditionalOptionValues.length; i++) {
        var EachAdditionalitem = AdditionalOptionValues[i].split("»");
        if (Number(EachAdditionalitem[2]) != 0) {
            var lblPrice = document.getElementById("ctl00_ContentPlaceHolder1_lblPrice_" + EachAdditionalitem[3]);
            if (lblPrice != null) {
                lblPrice.innerHTML = formatCurrency(EachAdditionalitem[2]);
            }
            Calculate_GrandTotal();
            Cart_Additional_Price();
        }
    }
}

function RoundupCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3) ; i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));

    return num + '.' + cents;
}

function RoundupDecimal(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3) ; i++)
        num = num.substring(0, num.length - (4 * i + 3)) + num.substring(num.length - (4 * i + 3));

    return num + '.' + cents;
}

function ApplyCouponCode() {
    if (StoreUserID == "0") {
        ShowLogin()
        return false;
    } else {
        var ChkCount = 0;
        if (!txt_CouponCode.disabled) {
            var shippingCart_Table = document.getElementById('shippingCart_Table');
            var shippingCart_TableCount = shippingCart_Table.getElementsByTagName('input');

            for (var i = 0; i < shippingCart_TableCount.length; i++) {
                if (shippingCart_TableCount[i].type == 'checkbox' && shippingCart_TableCount[i].id.indexOf('chkEachLine') != -1) {
                    ChkCount++;
                }
            }
        }

        if (txt_CouponCode != null && txt_CouponCode != undefined) {
            if (txt_CouponCode.value != '') {
                if (ChkCount > 0) {
                    asyncState = false;
                    allowgrouprun_calculations();
                    if (IsApplyed) {
                        txt_CouponCode.disabled = true;
                        btn_CouponCodeApplay.style.display = 'none';
                        div_ClearCouponCode.style.display = 'block';
                        btn_CouponCodeApplay.style.cursor = 'not-allowed';
                        span_InvalidCouponCode.style.display = 'none';
                        txt_CouponCode.style.cursor = 'not-allowed';
                    } else {
                        span_InvalidCouponCode.innerHTML = "Invalid coupon code";
                        txt_CouponCode.focus();
                        span_InvalidCouponCode.style.display = 'block';
                        div_InvalidCouponCode.style.display = 'block';
                        return false;
                    }
                } else {
                    alert(Please_select_atlease_one_checkbox);
                    return false;
                }
            } else {
                span_InvalidCouponCode.innerHTML = 'Please enter coupon code';
                span_InvalidCouponCode.style.display = 'block';
                txt_CouponCode.focus();
                return false;
            }
        } else {
            return false;
        }
        return false;
    }
}

function ClearCouponCode() {
    IsApplyed = false;
    txt_CouponCode.value = '';
    allowgrouprun_calculations();
    txt_CouponCode.disabled = false;
    btn_CouponCodeApplay.style.display = 'block';
    div_ClearCouponCode.style.display = 'none';
    btn_CouponCodeApplay.style.cursor = 'pointer';
    span_InvalidCouponCode.style.display = 'none';
    txt_CouponCode.style.cursor = 'auto';
    return false;
}