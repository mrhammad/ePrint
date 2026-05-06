function Add_AddressValidation() {
    var CheckFinal = false;
   
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

    if (ddl_country_billing.selectedIndex == 0) {
        spn_country_billing.style.display = "block";
        CheckFinal = true;
        return false;
    }
    else {
        spn_country_billing.style.display = "none";
    }

    if (CheckFinal) {
        return false;
    }
    else {
        return true;
    }
}
function redirectTo() {

    window.location = strSitepath + "products/product.aspx?ID=0";

}