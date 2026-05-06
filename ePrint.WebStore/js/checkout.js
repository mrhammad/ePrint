
//RegionalSettingCountry();

function trim(s) {
    var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not a whitespace, append to returnString.
    for (i = 0; i < s.length; i++) {
        // Check that current character isn't whitespace.
        var c = s.charAt(i);
        if (c != " ") returnString += c;
    }
    return returnString;
}

//if (StoreUserID != '0') {

//    div_LoginInformation.style.display = "none";
//    div_LoginInformation1.style.display = "none";
//    div_LoginInformation2.style.display = "none";
//    div_ContactDetails.style.display = "none";
//    div_ContactDetails1.style.display = "none";
//    div_ContactDetails2.style.display = "none";
//    div_lblCompanyName.style.display = "none";
//    div_lbl_email_billing.style.display = "none";
//    div_lbl_password.style.display = "none";
//    div_lbl_confirmPassword.style.display = "none";
//    div_txtCompanyName.style.display = "none";
//    div_txt_email_billing.style.display = "none";
//    div_txt_password_billing.style.display = "none";
//    div_txt_confirmPassword_billing.style.display = "none";
//    new_CheckOut.style.display = "none";

//    if (isOrderInfo == '1') {

//        Order_content.style.display = "block";
//        OrderArea.style.display = "block";
//        $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
//        $("#OrderHeader").css("background-color", "#F9F3E3"); $("#OrderHeader").css("color", "#F19900"); $("#number6").css("background-color", "#F19900");
//        $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
//        $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
//        $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");


//        //invoice
//        if (isInvoiceInfo == "1") {
//            Billing_content.style.display = "block";
//        }
//        else {
//            Billing_content.style.display = "none";
//        }
//        //deliver
//        if (isDeliveryInfo == "1")
//            Shipping_content.style.display = "block";
//        else
//            Shipping_content.style.display = "none";
//        //payment
//        if (isPaymentInfo == "1")
//            Payment_content.style.display = "block";
//        else
//            Payment_content.style.display = "none";

//    }
//    else {
//        Order_content.style.display = "none";
//        if (isInvoiceInfo == "1") {
//            Billing_content.style.display = "block";
//            BillingArea.style.display = "block";
//            $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
//            $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
//            $("#BillingHeader").css("background-color", "#F9F3E3"); $("#BillingHeader").css("color", "#F19900"); $("#number2").css("background-color", "#F19900");
//            $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
//            $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

//            //deliver
//            if (isDeliveryInfo == "1")
//                Shipping_content.style.display = "block";
//            else
//                Shipping_content.style.display = "none";
//            //payment
//            if (isPaymentInfo == "1")
//                Payment_content.style.display = "block";
//            else
//                Payment_content.style.display = "none";

//        }
//        else {

//            Billing_content.style.display = "none";

//            if (isDeliveryInfo == "1") {

//                Shipping_content.style.display = "block";
//                ShippingArea.style.display = "block";
//                $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
//                $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
//                $("#BillingHeader").css("background-color", "#F9F3E3"); $("#BillingHeader").css("color", "#F19900"); $("#number2").css("background-color", "#F19900");
//                $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
//                $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

//                //payment
//                if (isPaymentInfo == "1")
//                    Payment_content.style.display = "block";
//                else
//                    Payment_content.style.display = "none";

//            }
//            else {

//                Shipping_content.style.display = "none";

//                if (isPaymentInfo == "1") {

//                    Payment_content.style.display = "block";
//                    PaymentArea.style.display = "block";
//                    $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
//                    $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
//                    $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
//                    $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
//                    $("#PaymentHeader").css("background-color", "#F9F3E3"); $("#PaymentHeader").css("color", "#F19900"); $("#number4").css("background-color", "#F19900");

//                }
//                else { Payment_content.style.display = "none"; }

//            }

//        }

//    }


//}
//else {

//    if (isLoginInfo == '1') {

//        new_CheckOut.style.display = "block";
//        checkoutArea.style.display = "block";
//        $("#checkoutHeader").css("background-color", "#F9F3E3"); $("#checkoutHeader").css("color", "#F19900"); $("#number1").css("background-color", "#F19900");
//        $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
//        $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
//        $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
//        $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");


//        //order
//        if (isOrderInfo == "1")
//            Order_content.style.display = "block";
//        else
//            Order_content.style.display = "none";
//        //invoice
//        if (isInvoiceInfo == "1")
//            Billing_content.style.display = "block";
//        else
//            Billing_content.style.display = "none";
//        //deliver
//        if (isDeliveryInfo == "1")
//            Shipping_content.style.display = "block";
//        else
//            Shipping_content.style.display = "none";
//        //payment
//        if (isPaymentInfo == "1")
//            Payment_content.style.display = "block";
//        else
//            Payment_content.style.display = "none";
//    }
//    else {

//        new_CheckOut.style.display = "none";

//        if (isOrderInfo == "1") {
//            //            alert('hi');

//            Order_content.style.display = "block";
//            OrderArea.style.display = "block";
//            $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
//            $("#OrderHeader").css("background-color", "#F9F3E3"); $("#OrderHeader").css("color", "#F19900"); $("#number6").css("background-color", "#F19900");
//            $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
//            $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
//            $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

//            //invoice
//            if (isInvoiceInfo == "1")
//                Billing_content.style.display = "block";
//            else
//                Billing_content.style.display = "none";
//            //deliver
//            if (isDeliveryInfo == "1")
//                Shipping_content.style.display = "block";
//            else
//                Shipping_content.style.display = "none";
//            //payment
//            if (isPaymentInfo == "1")
//                Payment_content.style.display = "block";
//            else
//                Payment_content.style.display = "none";

//        }
//        else {
//            Order_content.style.display = "none";
//            if (isInvoiceInfo == "1") {

//                Billing_content.style.display = "block";
//                BillingArea.style.display = "block";
//                $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
//                $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
//                $("#BillingHeader").css("background-color", "#F9F3E3"); $("#BillingHeader").css("color", "#F19900"); $("#number2").css("background-color", "#F19900");
//                $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
//                $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

//                //deliver
//                if (isDeliveryInfo == "1")
//                    Shipping_content.style.display = "block";
//                else
//                    Shipping_content.style.display = "none";
//                //payment
//                if (isPaymentInfo == "1")
//                    Payment_content.style.display = "block";
//                else
//                    Payment_content.style.display = "none";

//            }
//            else {

//                Billing_content.style.display = "none";
//                if (isDeliveryInfo == "1") {

//                    Shipping_content.style.display = "block";
//                    ShippingArea.style.display = "block";
//                    $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
//                    $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
//                    $("#BillingHeader").css("background-color", "#F9F3E3"); $("#BillingHeader").css("color", "#F19900"); $("#number2").css("background-color", "#F19900");
//                    $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
//                    $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");


//                    //payment
//                    if (isPaymentInfo == "1")
//                        Payment_content.style.display = "block";
//                    else
//                        Payment_content.style.display = "none";

//                }
//                else {

//                    Shipping_content.style.display = "none";
//                    if (isPaymentInfo == "1") {

//                        Payment_content.style.display = "block";
//                        PaymentArea.style.display = "block";
//                        $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
//                        $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
//                        $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
//                        $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
//                        $("#PaymentHeader").css("background-color", "#F9F3E3"); $("#PaymentHeader").css("color", "#F19900"); $("#number4").css("background-color", "#F19900");


//                    }
//                    else { Payment_content.style.display = "none"; }
//                }

//            }


//        }

//    }
//}

//// By Gaj


//if (isCheckDeliveryRequiredBy == "0") {
//    document.getElementById("PaymentMode_details").style.display = 'none';
//}

//if (isLoginInfo == "0") {

//    if (StoreUserID == "0") {
//        div_lbl_password.style.display = 'none';
//        invAddress.innerHTML = 'Select a Delivery  address from your address book or enter a new address.';
//        div_txt_password_billing.style.display = 'none';
//        div_shilling.style.display = 'none';
//        div_lbl_confirmPassword.style.display = 'none';
//        div_txt_confirmPassword_billing.style.display = 'none';
//        BillingHeader.style.display = "block";
//        div_shilling_details.style.display = "none";
//        right_div.style.display = "none";
//    }
//    else {
//        OrderArea_back.style.display = "none";
//    }

//    if (isOrderInfo == "0") {
//        BillingArea_back.style.visibility = 'hidden';
//    }
//    else {
//        div_backBilling.style.display = "block";
//    }
//}

//if (isDeliveryInfo == "0") {

//    Shipping_content.style.display = 'none';
//    div_shilling_details.style.display = 'none';
//    rbn_sameAddress.checked = true;
//}

////By gaj


//function display_emptyCartArea() {
//    if (cartCount == "0") {
//        document.getElementById("checkOut_contentArea").style.height = "500px";
//    }
//}
//display_emptyCartArea();

var emailValied = false;
function echeck(str) {

    var at = "@"
    var dot = "."
    var lat = str.indexOf(at)
    var lstr = str.length
    var ldot = str.indexOf(dot)
    if (str.indexOf(at) == -1) {
        return false
    }

    if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
        emailValied = true;
    }

    if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
        emailValied = true;
    }

    if (str.indexOf(at, (lat + 1)) != -1) {
        emailValied = true;
    }

    if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
        emailValied = true;
    }

    if (str.indexOf(dot, (lat + 2)) == -1) {
        emailValied = true;
    }

    if (str.indexOf(" ") != -1) {
        emailValied = true;
    }

    if (emailValied) {
        return false;
    }
    else {

        return true;
    }
}

function CheckOutValidate() {

    if (isOrderInfo == "0") {
        checkoutArea.style.display = "none";
        OrderArea.style.display = "none";
        BillingArea.style.display = "block";
        ShippingArea.style.display = "none";
        ShippingMethodArea.style.display = "none";
        PaymentArea.style.display = "none";
        $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
        $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
        $("#BillingHeader").css("background-color", "#F9F3E3"); $("#BillingHeader").css("color", "#F19900"); $("#number2").css("background-color", "#F19900");
        $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
        $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");
    }
    else {

        checkoutArea.style.display = "none";
        OrderArea.style.display = "block";
        BillingArea.style.display = "none";
        ShippingArea.style.display = "none";
        ShippingMethodArea.style.display = "none";
        PaymentArea.style.display = "none";

        $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
        $("#OrderHeader").css("background-color", "#F9F3E3"); $("#OrderHeader").css("color", "#F19900"); $("#number6").css("background-color", "#F19900");
        $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
        $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
        $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");
    }
    hdn_hasStoreUser.value = 1;
    return false;
}

var ChkEmailDuplicacy = false;
function checkEmilDuplicacynew(emailtext) {
    AutoFill.Check_EmailID_Duplicacy(StoreUserID, emailtext, AccountID, GetResult);
}

function GetResult(result) {
    if (result == -1) {
        spn_email_billing.innerHTML = "EmailID already exists.";
        spn_email_billing.style.display = "block";
        ChkEmailDuplicacy = true;
    }
    else {
        spn_email_billing.style.display = "none";
        ChkEmailDuplicacy = false;
    }
}

var rtnAddress;
function returnAddress(Address) {
    rtnAddress = "";
    var strAddress = Address.split('µ');
    for (var i = 0; i < strAddress.length; i++) {
        if (strAddress[i] != "" && strAddress[i] != "--- Select ---") {
            rtnAddress += strAddress[i] + "<br/>";
        }
    }
}

var CheckFinal = false;

// Chenaged by Gaj, From IITS system on 22.06.2012
function BillingValidate() {

    //    div_backBilling.style.display = "none";
    CheckFinal = false;

    if (hid_billingaddress.value == 'yes' || hid_address.value == "no") {

        ///111111111111111
        if (StoreUserID != 0) {
            div_spn_firstName_billing.style.display = "none";
            div_spn_lastName_billing.style.display = "none";
            div_shilling_details.style.margin = "-60px 0px 0px 0px";
        }
        else {
            div_spn_firstName_billing.style.display = "block";
            div_spn_lastName_billing.style.display = "block";
            div_shilling_details.style.margin = "0px 0px 0px 0px";
        }

        if (hdnBillAdd1.value == "1") {

            if (trim(txt_address_billing1.value) == "") {
                spn_address_billing1.style.display = "block";
                CheckFinal = true;
            }
            else {
                spn_address_billing1.style.display = "none";
            }
        }

        if (hdnBillAdd2.value == "1") {

            if (trim(txt_address_billing2.value) == "") {
                spn_address_billing2.style.display = "block";
                CheckFinal = true;
            }
            else {
                spn_address_billing2.style.display = "none";
            }
        }

        if (hdnBillAdd3.value == "1") {

            if (trim(txt_city_billing.value) == "") {
                spn_city_billing.style.display = "block";
                CheckFinal = true;
            }
            else {
                spn_city_billing.style.display = "none";
            }
        }

        if (hdnBillAdd4.value == "1") {
            if (trim(txt_state_billing.value) == "") {
                spn_state_billing.style.display = "block";
                CheckFinal = true;
            }
            else {
                spn_state_billing.style.display = "none";
            }
        }

        if (hdnBillAdd5.value == "1") {

            if (trim(txt_zipCode_billing.value) == "") {
                spn_zipCode_billing.style.display = "block";
                CheckFinal = true;
            }
            else {
                spn_zipCode_billing.style.display = "none";
            }
        }

        //        if (IsPPW_SystemName != "true") {

        if (ddl_country_billing.selectedIndex == 0) {
            spn_country_billing.style.display = "block";
            CheckFinal = true;
        }
        else {
            spn_country_billing.style.display = "none";
        }
        //        }
        //        else {
        //            lbl_telephonebilling.style.display = "none";
        //        }

        lbl_telephonebilling.style.display = "none";

        if (StoreUserID == '0') {
            if (trim(txt_firstName_billing.value) == "") {
                spn_firstName_billing.style.display = "block";
                CheckFinal = true;
            }
            else {
                spn_firstName_billing.style.display = "none";
            }

            if (trim(txt_lastName_billing.value) == "") {
                spn_lastName_billing.style.display = "block";
                CheckFinal = true;
            }
            else {
                spn_lastName_billing.style.display = "none";
            }

            if (trim(txt_email_billing.value) == "") {
                if (echeck(txt_email_billing.value) == false) {
                    txt_email_billing.value = "";
                    spn_email_billing.style.display = "block"
                    CheckFinal = true;
                }
            }
            else if (trim(txt_email_billing.value) != "") {
                if (echeck(txt_email_billing.value) == false) {
                    txt_email_billing.value = "";
                    spn_email_billing.style.display = "block"
                    CheckFinal = true;
                }
                else {
                    if (isLoginInfo == "1") {

                        checkEmilDuplicacynew(trim(txt_email_billing.value));
                    }
                    if (ChkEmailDuplicacy) {
                        CheckFinal = true;
                    }
                }
            }

            if (isLoginInfo == "1") {
                if (trim(txt_password_billing.value) == "") {
                    spn_password_billing.style.display = "block";
                    CheckFinal = true;
                }
                else {
                    spn_password_billing.style.display = "none";
                }
                if (trim(txt_confirmPassword_billing.value) == "") {
                    spn_confirmPassword_billing.style.display = "block";
                    CheckFinal = true;
                }
                else if (trim(txt_confirmPassword_billing.value) != trim(txt_password_billing.value)) {
                    spn_confirmPassword_billing.innerHTML = "Please make sure your passwords match.";
                    spn_confirmPassword_billing.style.display = "block";
                    CheckFinal = true;
                }
            }

        }
        /////////////222222222
    }


    if (!CheckFinal && !ChkEmailDuplicacy) {


        if (rbn_sameAddress.checked && hid_billingaddress.value != 'yes') {
            //            var BillingAddressID = ddlBillingAddress.options[ddlBillingAddress.selectedIndex].value;
            //            AutoFill.Get_Address(StoreUserID, BillingAddressID, GetBillingAddress, onTimeout, onError);
        }

        var Billingaddress = txtaddressLabelBilling.value + "µ" + //txt_firstName_billing.value + "µ" + txt_lastName_billing.value + "µ" +
                    txt_address_billing1.value + "µ" + txt_address_billing2.value + "µ" +
                    txt_city_billing.value + "µ" + txt_state_billing.value + "µ" + txt_zipCode_billing.value + "µ" +
            ddl_country_billing.options[ddl_country_billing.selectedIndex].text + "µ" + txt_telephone_billing.value + "µ" + txt_fax_billing.value + "µ" + txt_email_billing.value;

        returnAddress(Billingaddress);


        lbl_billingAddress.innerHTML = rtnAddress;
        if (rbn_sameAddress.checked) {
            if (hid_address.value == 'yes') {
                ddlShippingAddress.selectedIndex = ddlBillingAddress.selectedIndex;
                if (ddlBillingAddress.options[ddlBillingAddress.selectedIndex].value == 0) {
                    var ddlValue = ddlShippingAddress.options[ddlShippingAddress.selectedIndex].value;
                    if (ddlValue == 0) {
                        tr_shippingadd.style.display = "block";
                        hid_Shippingaddress.value = "yes";
                        //                        alert('ship ='+ hid_Shippingaddress.value);
                    }
                }
            }


            txt_address_shipping1.value = txt_address_billing1.value;
            txt_address_shipping2.value = txt_address_billing2.value;
            txt_city_shipping.value = txt_city_billing.value;
            txt_state_shipping.value = txt_state_billing.value;
            txt_zipCode_shipping.value = txt_zipCode_billing.value;
            ddl_country_shipping.selectedIndex = ddl_country_billing.options[ddl_country_billing.selectedIndex].value;
            txt_telephone_shipping.value = txt_telephone_billing.value;
            txt_fax_shipping.value = txt_fax_billing.value;
            txt_email_shipping.value = txt_email_billing.value;

            if (txt_fax_billing.value == "") {
                lbl_shippingAddress.innerHTML = lbl_billingAddress.innerHTML;
            }
            else {
                lbl_shippingAddress.innerHTML = lbl_billingAddress.innerHTML;
            }

            billingAddress_Header.style.backgroundColor = "#D0DCE1"
            billingAddress_Header.style.color = "#5E8AB4";
            billingAddress_Header.style.fontWeight = "bold";

            shippingAddress_Header.style.backgroundColor = "#D0DCE1"
            shippingAddress_Header.style.color = "#5E8AB4";
            shippingAddress_Header.style.fontWeight = "bold"

            btn_billingAddress.style.display = "none";
            document.getElementById("div_loadingBilling").style.display = "block";


            if (ModeOfPayments == "1") {

                checkoutArea.style.display = "none";
                BillingArea.style.display = "none";
                ShippingArea.style.display = "none";
                ShippingMethodArea.style.display = "none";
                PaymentArea.style.display = "block";

                $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
                $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
                $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
                //$("#ShippingMethodHeader").css("background-color", "#EEE"); $("#ShippingMethodHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");
                $("#PaymentHeader").css("background-color", "#F9F3E3"); $("#PaymentHeader").css("color", "#F19900"); $("#number4").css("background-color", "#F19900");

                return false;

            }

        }
        else {

            if (isDeliveryInfo == "0" && isPaymentInfo == "0" && StoreUserID != 0) {
                return true;
            }


            checkoutArea.style.display = "none";
            BillingArea.style.display = "none";
            ShippingArea.style.display = "block";
            ShippingMethodArea.style.display = "none";
            PaymentArea.style.display = "none";

            //by gaj 

            if (StoreUserID == '0') {
                if (!rbn_sameAddress.checked) {
                    div_lblfirstNameShipping.style.display = "none";
                    div_lbllastNameShipping.style.display = "none";

                    div_txtfirstNameShipping.style.display = "none";
                    div_txtlastNameShipping.style.display = "none";

                    div_spn_firstName_Shipping.style.display = "none";
                    div_spn_lastName_Shipping.style.display = "none";

                    tr_shippingadd.style.display = "block";
                    hid_Shippingaddress.value = "yes";
                    //                    alert('ship =' + hid_Shippingaddress.value);
                }
            }
            //by gaj

            $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
            $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
            $("#ShippingHeader").css("background-color", "#F9F3E3"); $("#ShippingHeader").css("color", "#F19900"); $("#number3").css("background-color", "#F19900");
            //$("#ShippingMethodHeader").css("background-color", "#EEE"); $("#ShippingMethodHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");
            $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

            billingAddress_Header.style.backgroundColor = "#D0DCE1";
            billingAddress_Header.style.color = "#5E8AB4";
            billingAddress_Header.style.fontWeight = "bold";
            return false;
        }

        if (navigator.appName.toLowerCase() != "microsoft internet explorer") {
            txt_addressLabel_shipping.focus();
        }
    }



    if (CheckFinal == true || ChkEmailDuplicacy == true) {
        return false;
    }

    return true;


}



function OrderValidate() {

    var flag = false;

    if (txtRequiredBy.value != "") {

        if (ValidateForm(txtRequiredBy, 'spn_txtRequiredBy', DateFormat) == false) {
            flag = true;
        }
    }
    else {

        flag = false;
    }

    if ((txt_orderTitle.value == "") || (txt_orderTitle.value.trim() == "")) {
        spn_orderTitle.style.display = "block";
        flag = true;
    }
    else {
        spn_orderTitle.style.display = "none";
    }

    if (flag) {
        txt_orderTitle.focus();
        return false;
    }
    else {

        if (isInvoiceInfo == "1") {

            BillingArea.style.display = "block";
            OrderArea.style.display = "none";
            $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
            $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
            $("#BillingHeader").css("background-color", "#F9F3E3"); $("#BillingHeader").css("color", "#F19900"); $("#number2").css("background-color", "#F19900");
            $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
            $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

        }
        else if (isDeliveryInfo == "1") {

            Shipping_content.style.display = "block";
            OrderArea.style.display = "none";
            $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
            $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
            $("#BillingHeader").css("background-color", "#F9F3E3"); $("#BillingHeader").css("color", "#F19900"); $("#number2").css("background-color", "#F19900");
            $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
            $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

        }
        else if (isPaymentInfo == "1") {

            PaymentArea.style.display = "block";
            OrderArea.style.display = "none";
            $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
            $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
            $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
            $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
            $("#PaymentHeader").css("background-color", "#F9F3E3"); $("#PaymentHeader").css("color", "#F19900"); $("#number4").css("background-color", "#F19900");

        }
        return false;
    }

}

// Declaring required variables
var digits = "0123456789";
// non-digit characters which are allowed in phone numbers
var phoneNumberDelimiters = "()- ";
// characters which are allowed in international phone numbers
var validWorldPhoneChars = phoneNumberDelimiters;
var minDigitsInIPhoneNumber = 10;
var maxDigitsInIPhoneNumber = 10;

function isInteger(s) {
    var i;
    for (i = 0; i < s.length; i++) {
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

function stripCharsInBag(s, bag) {
    var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++) {
        // Check that current character isn't whitespace.
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function PhoneNo(strPhone) {
    strPhone = trim(strPhone)
    s = stripCharsInBag(strPhone, validWorldPhoneChars);
    return (isInteger(s) && s.length >= minDigitsInIPhoneNumber && s.length <= maxDigitsInIPhoneNumber);
}

var CheckFinal1 = false;
function ShippingValidate() {

    CheckFinal1 = false;

    //start Added By Manoj
    if (hid_Shippingaddress.value == 'yes') {

        if (hdnBillAdd1.value == "1") {
            if (trim(txt_address_shipping1.value) == "") {
                spn_address_shipping1.style.display = "block";
                CheckFinal1 = true;
            }
            else {
                spn_address_shipping1.style.display = "none";
            }
        }

        if (hdnBillAdd2.value == "1") {
            if (trim(txt_address_shipping2.value) == "") {
                spn_address_shipping2.style.display = "block";
                CheckFinal1 = true;
            }
            else {
                spn_address_shipping2.style.display = "none";
            }
        }
        if (hdnBillAdd3.value == "1") {

            if (trim(txt_city_shipping.value) == "") {
                spn_city_shipping.style.display = "block";
                CheckFinal1 = true;
            }
            else {
                spn_city_shipping.style.display = "none";
            }
        }

        if (hdnBillAdd4.value == "1") {

            if (trim(txt_state_shipping.value) == "") {
                spn_state_shipping.style.display = "block";
                CheckFinal1 = true;
            }
            else {
                spn_state_shipping.style.display = "none";
            }
        }

        if (hdnBillAdd5.value == "1") {

            if (trim(txt_zipCode_shipping.value) == "") {
                spn_zipCode_shipping.style.display = "block";
                CheckFinal1 = true;
            }
            else {
                spn_zipCode_shipping.style.display = "none";
            }
        }

        if (ddl_country_shipping.selectedIndex == 0) {
            spn_country_shipping.style.display = "block";
            CheckFinal1 = true;
        }
        else {
            spn_country_shipping.style.display = "none";
        }
    }

    //end 

    if (hid_Shippingaddress.value == 'yes' || hid_address.value == "no") {

        if (StoreUserID != 0) {
            div_spn_firstName_Shipping.style.display = "none";
            div_spn_lastName_Shipping.style.display = "none";
        }
        else {
            if (txt_firstName_shipping.value == "") {
                spn_firstName_shipping.style.display = "block";
                //CheckFinal1 = true;
                // return false;
            }
            else {
                spn_firstName_shipping.style.display = "none";
            }

            if (txt_lastName_shipping.value == "") {
                spn_lastName_shipping.style.display = "block";
                //return false;
            }
            else {
                spn_lastName_shipping.style.display = "none";
            }
        }

    }

    if (!CheckFinal1) {

        var shippingaddress = txt_addressLabel_shipping.value + "µ" + //txt_firstName_shipping.value + "µ" + txt_lastName_shipping.value + "µ" + 
                    txt_address_shipping1.value + "µ" + txt_address_shipping2.value + "µ" +
                    txt_city_shipping.value + "µ" + txt_state_shipping.value + "µ" + txt_zipCode_shipping.value + "µ" +
                    ddl_country_shipping.options[ddl_country_shipping.selectedIndex].text + "µ" + txt_telephone_shipping.value + "µ" + txt_fax_shipping.value;

        returnAddress(shippingaddress);
        lbl_shippingAddress.innerHTML = rtnAddress;

        billingAddress_Header.style.backgroundColor = "#D0DCE1"
        billingAddress_Header.style.color = "#5E8AB4";
        billingAddress_Header.style.fontWeight = "bold";

        shippingAddress_Header.style.backgroundColor = "#D0DCE1"
        shippingAddress_Header.style.color = "#5E8AB4";
        shippingAddress_Header.style.fontWeight = "bold"

        btn_shippingAddress.style.display = "none";
        document.getElementById("div_loadingShipping").style.display = "block";
    }


    if (CheckFinal1) {
        return false;
    }

    if (ModeOfPayments == '1') {
        checkoutArea.style.display = "none";
        BillingArea.style.display = "none";
        ShippingArea.style.display = "none";
        ShippingMethodArea.style.display = "none";
        PaymentArea.style.display = "block";

        $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
        $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
        $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
        //$("#ShippingMethodHeader").css("background-color", "#EEE"); $("#ShippingMethodHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");
        $("#PaymentHeader").css("background-color", "#F9F3E3"); $("#PaymentHeader").css("color", "#F19900"); $("#number4").css("background-color", "#F19900");
        return false;

    }
    else {
        checkoutArea.style.display = "none";
        BillingArea.style.display = "none";
        ShippingArea.style.display = "none";
        ShippingMethodArea.style.display = "none";
        PaymentArea.style.display = "block";
        return true;
    }


    //    if (IsSessionCheckOut) {
    //        OrderArea.style.display = "none";
    //        $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
    //    }
    div_backshipping.style.display = "block";
    //__doPostBack('ctl00$ContentPlaceHolder1$lnkBtnShippingAddress', '');

    return true;
}

function ShippingMethodValidate() {

    lbl_shippingMethod.innerHTML = "Flat Rate - Fixed $5.00";

    checkoutArea.style.display = "none";
    BillingArea.style.display = "none";
    ShippingArea.style.display = "none";
    ShippingMethodArea.style.display = "none";
    PaymentArea.style.display = "block";

    $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
    $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
    $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
    $("#PaymentHeader").css("background-color", "#F9F3E3"); $("#PaymentHeader").css("color", "#F19900"); $("#number4").css("background-color", "#F19900");

    shippingAddress_Header.style.backgroundColor = "#EEE"
    shippingAddress_Header.style.color = "#BBB";
    shippingAddress_Header.style.fontWeight = "bold";

    shippingMethod_Header.style.backgroundColor = "#EEE"
    shippingMethod_Header.style.color = "#BBB";
    shippingMethod_Header.style.fontWeight = "bold";

    return false;

}

function back_OrderValidate() {

    checkoutArea.style.display = "block";
    OrderArea.style.display = "none";
    BillingArea.style.display = "none";
    ShippingArea.style.display = "none";
    ShippingMethodArea.style.display = "none";
    PaymentArea.style.display = "none";

    $("#checkoutHeader").css("background-color", "#F9F3E3"); $("#checkoutHeader").css("color", "#F19900"); $("#number1").css("background-color", "#F19900");
    $("#OrderHeader").css("background-color", "#EEE"); $("#OrderHeader").css("color", "#BBB"); $("#number6").css("background-color", "#BBB");
    $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
    $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
    $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

    return false;
}

function back_BillingValidate() {

    OrderArea.style.display = "block";
    BillingArea.style.display = "none";
    //    ShippingArea.style.display = "none";
    //    ShippingMethodArea.style.display = "none";
    //    PaymentArea.style.display = "none";

    $("#OrderHeader").css("background-color", "#F9F3E3"); $("#OrderHeader").css("color", "#F19900"); $("#number6").css("background-color", "#F19900");
    $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
    //    $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
    //    $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

    return false;
}

function back_ShippingValidate() {

    div_backBilling.style.display = "block";
    lbl_billingAddress.innerHTML = "";

    checkoutArea.style.display = "none";
    BillingArea.style.display = "block";
    ShippingArea.style.display = "none";
    ShippingMethodArea.style.display = "none";
    PaymentArea.style.display = "none";

    $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
    $("#BillingHeader").css("background-color", "#F9F3E3"); $("#BillingHeader").css("color", "#F19900"); $("#number2").css("background-color", "#F19900");
    $("#ShippingHeader").css("background-color", "#EEE"); $("#ShippingHeader").css("color", "#BBB"); $("#number3").css("background-color", "#BBB");
    $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");


    billingAddress_Header.style.backgroundColor = "#D0DCE1"
    billingAddress_Header.style.color = "#5E8AB4";
    billingAddress_Header.style.fontWeight = "bold";

    btn_billingAddress.style.display = "block";
    document.getElementById("div_loadingBilling").style.display = "none";
    return false;
}

function back_ShippingMethodValidate() {
    lbl_shippingAddress.innerHTML = "";
    checkoutArea.style.display = "none";
    BillingArea.style.display = "none";
    ShippingArea.style.display = "block";
    ShippingMethodArea.style.display = "none";
    PaymentArea.style.display = "none";

    $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
    $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
    $("#ShippingHeader").css("background-color", "#F9F3E3"); $("#ShippingHeader").css("color", "#F19900"); $("#number3").css("background-color", "#F19900");
    $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

    shippingAddress_Header.style.backgroundColor = ""
    shippingAddress_Header.style.color = "";
    shippingAddress_Header.style.fontWeight = "";

    billingAddress_Header.style.backgroundColor = "#D0DCE1"
    billingAddress_Header.style.color = "#5E8AB4";
    billingAddress_Header.style.fontWeight = "bold";

    //href_shippingAddress.style.display = "none";

    return false;
}

function back_PaymentValidate() {

    lbl_shippingMethod.innerHTML = "";
    checkoutArea.style.display = "none";
    BillingArea.style.display = "none";
    ShippingArea.style.display = "block";
    PaymentArea.style.display = "none";

    div_lblfirstNameShipping.style.display = "none";
    div_lbllastNameShipping.style.display = "none";

    div_txtfirstNameShipping.style.display = "none";
    div_txtlastNameShipping.style.display = "none";

    div_spn_firstName_Shipping.style.display = "none";
    div_spn_lastName_Shipping.style.display = "none";

    $("#checkoutHeader").css("background-color", "#EEE"); $("#checkoutHeader").css("color", "#BBB"); $("#number1").css("background-color", "#BBB");
    $("#BillingHeader").css("background-color", "#EEE"); $("#BillingHeader").css("color", "#BBB"); $("#number2").css("background-color", "#BBB");
    $("#ShippingHeader").css("background-color", "#F9F3E3"); $("#ShippingHeader").css("color", "#F19900"); $("#number3").css("background-color", "#F19900");
    $("#PaymentHeader").css("background-color", "#EEE"); $("#PaymentHeader").css("color", "#BBB"); $("#number4").css("background-color", "#BBB");

    billingAddress_Header.style.backgroundColor = "#D0DCE1"
    billingAddress_Header.style.color = "#5E8AB4";
    billingAddress_Header.style.fontWeight = "bold";

    shippingAddress_Header.style.backgroundColor = ""
    shippingAddress_Header.style.color = "";
    shippingAddress_Header.style.fontWeight = "";

    lbl_shippingAddress.innerHTML = "";
    document.getElementById("div_backshipping").style.display = "block";

    btn_shippingAddress.style.display = "block";
    document.getElementById("div_loadingShipping").style.display = "none";



    return false;
}

var type;
function show() {

    var ddl_payments = document.getElementById("ctl00_ContentPlaceHolder1_ddl_payments");
    if (typeof ddl_payments != 'undefined' && ddl_payments != null && ddl_payments != undefined && ddl_payments.selectedIndex != -1) {
        type = ddl_payments.options[ddl_payments.selectedIndex].value;
        if (type == "CC")
            document.getElementById("creditCard").style.display = "block";
        else
            document.getElementById("creditCard").style.display = "none";
    }
}

show();

function hide() {
    document.getElementById("creditCard").style.display = "none";
}

function rbnAddressType_Change(addType) {

    if (addType == 'same') {
        if (hdn_BillingAddressID.value != "") {
            hdn_ShippingAddressID.value = hdn_BillingAddressID.value;
        }
    }
    else if (addType == 'different') {
        if (hdn_ShippingAddressID.value != "0" || hdn_ShippingAddressID.value != "") {
            hdn_ShippingAddressID.value = hdn_ShippingAddressID.value;
        }
        else {
            hdn_ShippingAddressID.value = "0";
        }
    }
}

function btnOrderclick() {


    var CreditCheck = false;

    if (isPaymentInfo == "1") {
        if (ddl_payments.options[ddl_payments.selectedIndex].value == "CC") {
            if (txt_cardNumber.value == "") {
                document.getElementById("spn_cardNumber").style.display = "block";
                CreditCheck = true;
            }
            else if (!Number(txt_cardNumber.value)) {
                document.getElementById("spn_cardNumber").style.display = "block";
                document.getElementById("spn_cardNumber").innerHTML = "Please Enter Valid Number";
                CreditCheck = true;
            }

            var re = '';

            if (rbnVisaID.checked) {
                // Visa: length 16, prefix 4, dashes optional.
                re = /^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/;
                //                alert(re);
            }
            else if (rbnMasterCardID.checked) {
                // Mastercard: length 16, prefix 51-55, dashes optional.
                re = /^5[1-5]\d{2}-?\d{4}-?\d{4}-?\d{4}$/;
            }
            else if (rbnDiscoverID.checked) {
                // Discover: length 16, prefix 6011, dashes optional.
                re = /^6011-?\d{4}-?\d{4}-?\d{4}$/;
            }
            else if (rbnAmericanID.checked) {
                // American Express: length 15, prefix 34 or 37.
                re = /^3[4,7]\d{13}$/;
            }

            if (re.length == 0) {
                rbnVisaID.checked = true;
                re = /^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/;
            }

            if (!re.test(txt_cardNumber.value)) {
                //                alert('invalid');
                document.getElementById("spn_cardNumber").style.display = "block";
                document.getElementById("spn_cardNumber").innerHTML = "Please Enter Valid Number";
                CreditCheck = true;
            }
            else {
                //                alert('valid');
                document.getElementById("spn_cardNumber").style.display = "none";
            }

            // Remove all dashes for the checksum checks to eliminate negative numbers
            var ccnum = txt_cardNumber.value.split("-").join("");
            // Checksum ("Mod 10")
            // Add even digits in even length strings or odd digits in odd length strings.
            var checksum = 0;
            for (var i = (2 - (ccnum.length % 2)); i <= ccnum.length; i += 2) {
                checksum += parseInt(ccnum.charAt(i - 1));
            }

            // Analyze odd digits in even length strings or even digits in odd length strings.
            for (var i = (ccnum.length % 2) + 1; i < ccnum.length; i += 2) {
                var digit = parseInt(ccnum.charAt(i - 1)) * 2;
                if (digit < 10) { checksum += digit; } else { checksum += (digit - 9); }
            }
            if ((checksum % 10) != 0) {
                document.getElementById("spn_cardNumber").style.display = "block";
                document.getElementById("spn_cardNumber").innerHTML = "Please Enter Valid Number";
                CreditCheck = true;
            }
            else if (!CreditCheck) {
                document.getElementById("spn_cardNumber").style.display = "none";
            }



            if (txt_verification.value == "") {
                document.getElementById("spn_verification").style.display = "block";
                CreditCheck = true;
            }
            else if (!Number(txt_verification.value)) {
                //                alert('CreditCheck1  _' + CreditCheck);
                document.getElementById("spn_verification").style.display = "block";
                document.getElementById("spn_verification").innerHTML = "Please Enter Valid Number";
                CreditCheck = true;
            }
            else {
                document.getElementById("spn_verification").style.display = "none";
            }


            if (txt_HolderName.value == "") {
                document.getElementById("spn_HolderName").style.display = "block";
                CreditCheck = true;
            }
            else {
                document.getElementById("spn_HolderName").style.display = "none";
            }

            if (ddl_month.selectedIndex == 0) {
                document.getElementById("spn_ddlyear").style.display = "block";
                document.getElementById("spn_ddlyear").innerHTML = "Please select valid month.";
                CreditCheck = true;
            }
            else {
                document.getElementById("spn_ddlyear").style.display = "none";
            }

            var cardexp = false;
            if (ddl_month.selectedIndex != 0) {
                var today = new Date();
                var mm = today.getMonth() + 1;
                var ddlmn = ddl_month.options[ddl_month.selectedIndex].value;
                if (parseInt(ddlmn) < parseInt(mm)) {
                    document.getElementById("spn_ddlyear").style.display = "block";
                    document.getElementById("spn_ddlyear").innerHTML = "Invalid Month";
                    CreditCheck = true;
                }
                else {
                    document.getElementById("spn_ddlyear").style.display = "none";
                    cardexp = true;
                }
            }


            if (ddl_year.selectedIndex == 0) {
                document.getElementById("spn_ddlyear").style.display = "block";
                document.getElementById("spn_ddlyear").innerHTML = "Please select valid year.";
                CreditCheck = true;
            }
            else {
                if (cardexp == true) {
                    document.getElementById("spn_ddlyear").style.display = "none";
                }
            }

        }
    }



    if (CreditCheck) {
        div_backPayment.style.display = "block";
        return false;
    }

    return true;
}

function getSelectedValue_billing() {

    var ddlValue = ddlBillingAddress.options[ddlBillingAddress.selectedIndex].value;

    if (ddlValue == 0) {

        div_lblfirstNameBilling.style.display = "none";
        div_lbllastNameBilling.style.display = "none";
        div_lbladdressLabelBilling.style.display = "block";
        div_txtfirstNameBilling.style.display = "none";
        div_txtlastNameBilling.style.display = "none";
        div_txtaddressLabelBilling.style.display = "block";
        txtaddressLabelBilling.value = "";

        if (navigator.appName.toLowerCase() != "microsoft internet explorer") {
            div_spn_firstName_billing.style.margin = "none";
            div_spn_lastName_billing.style.margin = "none";
        }

        div_shilling_details.style.margin = "-80px 0px 0px 0px";

        tr_billingadd.style.display = "block";
        div_radiobutton.style.display = "block";
        div_shilling.style.display = "block";
        hid_billingaddress.value = "yes";

        //        alert('Billing=' + hid_billingaddress.value)

        txt_firstName_billing.value = "";
        txt_lastName_billing.value = "";
        txt_telephone_billing.value = "";
        txt_fax_billing.value = "";
        txt_email_billing.value = "";
        txt_address_billing1.value = "";
        txt_address_billing2.value = "";
        txt_city_billing.value = "";
        txt_state_billing.value = "";
        txt_zipCode_billing.value = "";

        AutoFill.Get_RegionalSetting_Country(CompanyID, GetRegionalSetting, onTimeout, onError);

        //txtaddressLabelBilling.focus();
    }
    else {
        tr_billingadd.style.display = "none";
        div_radiobutton.style.display = "block";
        div_shilling.style.display = "none";
        hid_billingaddress.value = "no";
        //        alert('Billing=' + hid_billingaddress.value)

        div_lblfirstNameBilling.style.display = "none";
        div_lbllastNameBilling.style.display = "none";
        div_txtfirstNameBilling.style.display = "none";
        div_txtlastNameBilling.style.display = "none";

        div_shilling_details.style.margin = "0px 0px 0px 0px";

        if (navigator.appName.toLowerCase() != "microsoft internet explorer") {
            spn_firstName_billing.style.margin = "none";
            spn_lastName_billing.style.margin = "none";
        }

        var BillingAddressID = ddlBillingAddress.options[ddlBillingAddress.selectedIndex].value;
        hdn_BillingAddressID.value = BillingAddressID;
        AutoFill.Get_Address(StoreUserID, BillingAddressID, GetBillingAddress, onTimeout, onError);
    }
}

function onTimeout(err) { }

function onError(err) { }

function GetRegionalSetting(RegionalSetting_Country) {
    if (isGuest != "1") {
        ddl_country_billing.selectedIndex = RegionalSetting_Country;
        ddl_country_shipping.selectedIndex = RegionalSetting_Country;
    }

}

function GetBillingAddress(Result) {
    debugger
    var strResult = Result.split('µ');
    txt_firstName_billing.value = "";
    for (var i = 0; i <= strResult.length; i++) {
        if (strResult[i] != "") {
            //            if (i == 0) {
            //                txt_firstName_billing.value = strResult[i];
            //            }
            //            if (i == 1) {
            //                txt_lastName_billing.value = strResult[i];
            //            }
            if (i == 2) {
                txt_telephone_billing.value = strResult[i];
            }
            if (i == 3) {
                txt_fax_billing.value = strResult[i];
            }
            if (i == 4) {
                txt_address_billing1.value = strResult[i];
            }
            if (i == 5) {
                txt_address_billing2.value = strResult[i];
            }
            if (i == 6) {
                txt_city_billing.value = strResult[i];
            }
            if (i == 7) {
                txt_state_billing.value = strResult[i];
            }
            if (i == 8) {
                txt_zipCode_billing.value = strResult[i];
            }
            if (i == 9) {
                ddl_country_billing.selectedIndex = strResult[i];
            }
            if (i == 10) {
                txtaddressLabelBilling.value = strResult[i];
            }
            if (i == 11) {
                hdn_BillingAddressID.Value = strResult[i];
            }
        }
        else {
            if (i == 2) {
                txt_telephone_billing.value = "";
            }
            if (i == 3) {
                txt_fax_billing.value = "";
            }
            if (i == 4) {
                txt_address_billing1.value = "";
            }
            if (i == 5) {
                txt_address_billing2.value = "";
            }
            if (i == 6) {
                txt_city_billing.value = "";
            }
            if (i == 7) {
                txt_state_billing.value = "";
            }
            if (i == 8) {
                txt_zipCode_billing.value = "";
            }
            if (i == 9) {
                ddl_country_billing.selectedIndex = 0;
            }
            if (i == 10) {
                txtaddressLabelBilling.value = strResult[i];
                txtaddressLabelBilling.value = "";
            }
        }
    }
}

function getSelectedValue_shipping() {
    var ddlValue = ddlShippingAddress.options[ddlShippingAddress.selectedIndex].value;

    if (ddlValue == 0) {

        div_lblfirstNameShipping.style.display = "none";
        div_lbllastNameShipping.style.display = "none";
        div_lbladdressLabelShipping.style.display = "block";
        div_txtfirstNameShipping.style.display = "none";
        div_txtlastNameShipping.style.display = "none";
        div_txtaddressLabelShipping.style.display = "block";

        if (navigator.appName.toLowerCase() != "microsoft internet explorer") {
            div_spn_firstName_Shipping.style.margin = "none";
            div_spn_lastName_Shipping.style.margin = "none";
            div_spn_addressLabel_Shipping.style.margin = "none";
        }


        tr_shippingadd.style.display = "block";
        hid_Shippingaddress.value = "yes";

        txt_addressLabel_shipping.value = "";
        txt_firstName_shipping.value = "";
        txt_lastName_shipping.value = "";

        txt_address_shipping1.value = "";
        txt_address_shipping2.value = "";
        txt_city_shipping.value = "";
        txt_state_shipping.value = "";
        txt_zipCode_shipping.value = "";
        txt_telephone_shipping.value = "";
        txt_fax_shipping.value = "";

        AutoFill.Get_RegionalSetting_Country(CompanyID, GetRegionalSetting, onTimeout, onError);

    }
    else {

        tr_shippingadd.style.display = "none";
        hid_Shippingaddress.value = "no";
        //        alert('ship =' + hid_Shippingaddress.value);

        var ShippingAddressID = ddlShippingAddress.options[ddlShippingAddress.selectedIndex].value;
        AutoFill.Get_Address(StoreUserID, ShippingAddressID, GetShippingAddress, onTimeout, onError);
    }
}

function GetShippingAddress(Result) {

    var strResult = Result.split('µ');
    txt_firstName_shipping.value = "";
    for (var i = 0; i <= strResult.length; i++) {
        if (strResult[i] != "") {
            //            if (i == 0) {
            //                txt_firstName_shipping.value = strResult[i];
            //            }
            //            if (i == 1) {
            //                txt_lastName_shipping.value = strResult[i];
            //            }
            if (i == 2) {
                txt_telephone_shipping.value = strResult[i];
            }
            if (i == 3) {
                txt_fax_shipping.value = strResult[i];
            }
            if (i == 4) {
                txt_address_shipping1.value = strResult[i];
            }
            if (i == 5) {
                txt_address_shipping2.value = strResult[i];
            }
            if (i == 6) {
                txt_city_shipping.value = strResult[i];
            }
            if (i == 7) {
                txt_state_shipping.value = strResult[i];
            }
            if (i == 8) {
                txt_zipCode_shipping.value = strResult[i];
            }
            if (i == 9) {
                ddl_country_shipping.selectedIndex = strResult[i];
            }
            if (i == 10) {
                txt_addressLabel_shipping.value = strResult[i];
            }
            if (i == 11) {
                hdn_ShippingAddressID.Value = strResult[i];
            }
        }
        else {
            if (i == 2) {
                txt_telephone_shipping.value = "";
            }
            if (i == 3) {
                txt_fax_shipping.value = "";
            }
            if (i == 4) {
                txt_address_shipping1.value = "";
            }
            if (i == 5) {
                txt_address_shipping2.value = "";
            }
            if (i == 6) {
                txt_city_shipping.value = "";
            }
            if (i == 7) {
                txt_state_shipping.value = "";
            }
            if (i == 8) {
                txt_zipCode_shipping.value = "";
            }
            if (i == 9) {
                ddl_country_shipping.selectedIndex = 0;
            }
            if (i == 10) {
                txt_addressLabel_shipping.value = "";
                //txt_addressLabel_shipping.style.display = "none";
            }
        }
    }
}

function isValidCreditCard(type, ccnum) {
    if (type == "Visa") {
        // Visa: length 16, prefix 4, dashes optional.
        var re = /^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/;
    } else if (type == "MC") {
        // Mastercard: length 16, prefix 51-55, dashes optional.
        var re = /^5[1-5]\d{2}-?\d{4}-?\d{4}-?\d{4}$/;
    } else if (type == "Disc") {
        // Discover: length 16, prefix 6011, dashes optional.
        var re = /^6011-?\d{4}-?\d{4}-?\d{4}$/;
    } else if (type == "AmEx") {
        // American Express: length 15, prefix 34 or 37.
        var re = /^3[4,7]\d{13}$/;
    } else if (type == "Diners") {
        // Diners: length 14, prefix 30, 36, or 38.
        var re = /^3[0,6,8]\d{12}$/;
    }
    if (!re.test(ccnum)) return false;
    // Remove all dashes for the checksum checks to eliminate negative numbers
    ccnum = ccnum.split("-").join("");
    // Checksum ("Mod 10")
    // Add even digits in even length strings or odd digits in odd length strings.
    var checksum = 0;
    for (var i = (2 - (ccnum.length % 2)); i <= ccnum.length; i += 2) {
        checksum += parseInt(ccnum.charAt(i - 1));
    }
    // Analyze odd digits in even length strings or even digits in odd length strings.
    for (var i = (ccnum.length % 2) + 1; i < ccnum.length; i += 2) {
        var digit = parseInt(ccnum.charAt(i - 1)) * 2;
        if (digit < 10) { checksum += digit; } else { checksum += (digit - 9); }
    }
    if ((checksum % 10) == 0) return true; else return false;
}

//if (hid_billingaddress.value == "no") {
//    if (ddlBillingAddress.options[ddlBillingAddress.selectedIndex] != null) {
//        var BillingAddressID = ddlBillingAddress.options[ddlBillingAddress.selectedIndex].value;
//        AutoFill.Get_Address(StoreUserID, BillingAddressID, GetBillingAddress, onTimeout, onError);
//    }
//}

//if (hid_Shippingaddress.value == "no") {
//    if (ddlShippingAddress.options[ddlShippingAddress.selectedIndex] != null) {
//        var ShippingAddressID = ddlShippingAddress.options[ddlShippingAddress.selectedIndex].value;
//        AutoFill.Get_Address(StoreUserID, ShippingAddressID, GetShippingAddress, onTimeout, onError);
//    }
//}


function capturekeys(e) {
    var evts = e ? e : window.event;
    var bt1 = BtnLogin;
    if (bt1) {
        if (evts.keyCode == 13) {
            bt1.click();
            return false;
        }
    }
}

function RegionalSettingCountry() {
    AutoFill.Get_RegionalSetting_Country(CompanyID, GetRegionalSetting, onTimeout, onError);
}

function Billing_Address() {
    AutoFill.Get_Address(StoreUserID, hdn_BillingAddressID.value, GetBillingAddress1, onTimeout, onError);
}

function Shipping_Address() {
    AutoFill.Get_Address(StoreUserID, hdn_ShippingAddressID.value, GetShippingAddress1, onTimeout, onError);
}


function GetBillingAddress1(Result) {
    debugger
    var strResult = Result.split('µ');
    txt_firstName_shipping.value = "";
    for (var i = 0; i <= strResult.length; i++) {
        if (strResult[i] != "") {
            if (i == 2) {
                txt_telephone_billing.value = strResult[i];
            }
            if (i == 3) {
                txt_fax_billing.value = strResult[i];
            }
            if (i == 4) {
                txt_address_billing1.value = strResult[i];
            }
            if (i == 5) {
                txt_address_billing2.value = strResult[i];
            }
            if (i == 6) {
                txt_city_billing.value = strResult[i];
            }
            if (i == 7) {
                txt_state_billing.value = strResult[i];
            }
            if (i == 8) {
                txt_zipCode_billing.value = strResult[i];
            }
            if (i == 9) {
                ddl_country_billing.selectedIndex = strResult[i];
            }
            if (i == 10) {
                txtaddressLabelBilling.value = strResult[i];
            }
        }
    }
    var Billingaddress = txtaddressLabelBilling.value + "µ" + txt_address_billing1.value + "µ" + txt_address_billing2.value + "µ" +
                    txt_city_billing.value + "µ" + txt_state_billing.value + "µ" + txt_zipCode_billing.value + "µ" +
        ddl_country_billing.options[ddl_country_billing.selectedIndex].text + "µ" + txt_telephone_billing.value + "µ" + txt_fax_billing.value + "µ" + txt_email_billing.value;;

    returnAddress(Billingaddress);
    lbl_billingAddress.innerHTML = rtnAddress;
}


function GetShippingAddress1(Result) {

    var strResult = Result.split('µ');
    txt_firstName_shipping.value = "";
    for (var i = 0; i <= strResult.length; i++) {
        if (strResult[i] != "") {
            if (i == 2) {
                txt_telephone_shipping.value = strResult[i];
            }
            if (i == 3) {
                txt_fax_shipping.value = strResult[i];
            }
            if (i == 4) {
                txt_address_shipping1.value = strResult[i];
            }
            if (i == 5) {
                txt_address_shipping2.value = strResult[i];
            }
            if (i == 6) {
                txt_city_shipping.value = strResult[i];
            }
            if (i == 7) {
                txt_state_shipping.value = strResult[i];
            }
            if (i == 8) {
                txt_zipCode_shipping.value = strResult[i];
            }
            if (i == 9) {
                ddl_country_shipping.selectedIndex = strResult[i];
            }
            if (i == 10) {
                txt_addressLabel_shipping.value = strResult[i];
            }
        }
    }
    var Shippingaddress = txt_addressLabel_shipping.value + "µ" + txt_address_shipping1.value + "µ" + txt_address_shipping2.value + "µ" +
                    txt_city_shipping.value + "µ" + txt_state_shipping.value + "µ" + txt_zipCode_shipping.value + "µ" +
                    ddl_country_shipping.options[ddl_country_shipping.selectedIndex].text + "µ" + txt_telephone_shipping.value + "µ" + txt_fax_shipping.value;

    returnAddress(Shippingaddress);
    lbl_shippingAddress.innerHTML = rtnAddress;

    shippingAddress_Header.style.backgroundColor = "#D0DCE1"
    shippingAddress_Header.style.color = "#5E8AB4";
    shippingAddress_Header.style.fontWeight = "bold"
}