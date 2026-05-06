function onclick_address(type) {

    if (Rewritemodule.toLowerCase() == "on") {
        if (type.toLowerCase() == "billing") {
            window.location = strSitepath + 'account/addressbooknew' + KeySeparator + DefaultBillingID + KeySeparator + "acc" + FileExtension;
        }
        else if (type.toLowerCase() == "shipping") {
            window.location = strSitepath + 'account/addressbooknew' + KeySeparator + DefaultShippingID + KeySeparator + "acc" + FileExtension;
        }
    }
    else {
        if (type.toLowerCase() == "billing") {
            window.location = strSitepath + "account/addressbooknew.aspx?ID=" + DefaultBillingID + "&amp;type=acc";
        }
        else if (type.toLowerCase() == "shipping") {
            window.location = strSitepath + "account/addressbooknew.aspx?ID=" + DefaultShippingID + "&amp;type=acc";
        }
    }
}

function IfB2B_System() {

    if (IsPrivate_SystemName == "True")
        addressBook_Info_left.style.display = "none";
}

var addressbook_Content_left_contents = document.getElementById("addressbook_Content_left_contents");
var addressbook_Content_left_header = document.getElementById("addressbook_Content_left_header");
var div_InvoiceDetails = document.getElementById("div_InvoiceDetails");

function IfB2B_System() {
    if (IsPrivate_SystemName == "True") {
        addressbook_Content_left_contents.style.display = "none";
        addressbook_Content_left_header.style.display = "none";
        div_InvoiceDetails.style.margin = "0px";
    }
}


function RedirectToPage() {

    if (Rewritemodule.toLowerCase() == 'on') {
        if (RedirectTo.toLowerCase() == 'acc')
            window.location = strSitepath + "account/account" + FileExtension;
        else
            window.location = strSitepath + "account/addressbook" + FileExtension;
    }
    else {
        if (RedirectTo.toLowerCase() == 'add')
            window.location = strSitepath + "account/account.aspx";
        else
            window.location = strSitepath + "account/addressbook.aspx";
    }
}


function Validate() {
   
    var txtTel = document.getElementById("ctl00_ContentPlaceHolder1_txt_telephone");
    var ddlCountry = document.getElementById("ctl00_ContentPlaceHolder1_ddl_Country");

    var txtAdd1 = document.getElementById("ctl00_ContentPlaceHolder1_txt_address");
    var txtAdd2 = document.getElementById("ctl00_ContentPlaceHolder1_txt_address2");
    var txtAdd3 = document.getElementById("ctl00_ContentPlaceHolder1_txt_city");
    var txtAdd4 = document.getElementById("ctl00_ContentPlaceHolder1_txt_state");
    var txtAdd5 = document.getElementById("ctl00_ContentPlaceHolder1_txt_zipCode");


    var hdnIsMandAdd1 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd1");
    var hdnIsMandAdd2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd2");
    var hdnIsMandAdd3 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd3");
    var hdnIsMandAdd4 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd4");
    var hdnIsMandAdd5 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd5");


    var txtApprEmail = document.getElementById("ctl00_ContentPlaceHolder1_txtApproverEmail");
    var DivApproverEmail = document.getElementById("ctl00_ContentPlaceHolder1_DivApproverEmail");
    var hdnValidation = document.getElementById("ctl00_ContentPlaceHolder1_hdnValidation");


    if (txtTel.value == "" || txtTel.value == null) {
        document.getElementById("divTelephone").style.display = "block";
        txtTel.focus();
        return false;
    }
    if (ddl_Country.value == "" || ddl_Country.value == "0") {
        document.getElementById("div5").style.display = "block";
        ddl_Country.focus();
        return false;
    }
    if (hdnValidation.value == "True") {
        if (DivApproverEmail.style.display == "block") {
            if (txtApprEmail.value == "" || txtApprEmail.value == null) {
                document.getElementById("SpnApproverEmailan").style.display = "block";
                return false;
            }
            else if (txtApprEmail.value != "") {
                document.getElementById("SpnApproverEmailan").style.display = "none";
                re = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
                if (!re.test(txtApprEmail.value)) {
                    document.getElementById("RegularExpressionValidator1").style.display = "block";
                    return false;
                }
                else {
                    document.getElementById("RegularExpressionValidator1").style.display = "none";
                }
            }
        }
    }

    if (hdnIsMandAdd1.value == "1" && (txtAdd1.value == "" || txtAdd1.value == null)) {
        document.getElementById("divAdd1").style.display = "block";
        txtAdd1.focus();
        return false;
    }
    if (hdnIsMandAdd2.value == "1" && (txtAdd2.value == "" || txtAdd2.value == null)) {
        document.getElementById("divAdd2").style.display = "block";
        txtAdd2.focus();
        return false;
    }

    if (hdnIsMandAdd3.value == "1" && (txtAdd3.value == "" || txtAdd3.value == null)) {
        document.getElementById("divAdd3").style.display = "block";
        txtAdd3.focus();
        return false;
    }

    if (hdnIsMandAdd4.value == "1" && (txtAdd4.value == "" || txtAdd4.value == null)) {
        document.getElementById("divAdd4").style.display = "block";
        txtAdd4.focus();
        return false;
    }

    if (hdnIsMandAdd5.value == "1" && (txtAdd5.value == "" || txtAdd5.value == null)) {
        document.getElementById("divAdd5").style.display = "block";
        txtAdd5.focus();
        return false;
    }
    if (ddlCountry.options[ddlCountry.selectedIndex].value == "0") {
        ddlCountry.focus();
        return false;
    }
    loadingimg('div_btnsave', 'div_btnsaveprocess');
    return true;

}

function HideShowError(divID) {

    document.getElementById(divID).style.display = "none";
}

function Onclick_orderNo(OrdKey) { 
    window.location = strSitepath + "order.aspx?OrdKey=" + OrdKey;
}

function Onclick_ReferenceorderNo(OrderID, UserID) {

    window.location = strSitepath + "order.aspx?OrderID=" + OrderID + "&UserID=" + UserID;
}

function RedirectToProduct() {

    window.location = strSitepath + "products/product.aspx?ID=0";

}

window.setTimeout(function () {
    var label = document.getElementById('ctl00_ContentPlaceHolder1_DivregistrationMGS');

    if (label != null) {
        label.style.display = 'none';
    }
}, 5000);

window.setTimeout(function () {
    var label = document.getElementById('ctl00_ContentPlaceHolder1_DivUserApproved');

    if (label != null) {
        label.style.display = 'none';
    }
}, 5000);


function ShowAlert() {
    alert("Email address missing valid Domain name");
    return false;
}

function AutoApprove() {
    alert("Email address missing valid Domain name");
    return false;
}

        