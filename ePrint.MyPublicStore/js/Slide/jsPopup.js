
$(document).ready(function () {

    $("#btnShowModal_Bill").click(function (e) {
        ShowDialog(true);
        e.preventDefault();
    });

    $("#lnk_ChooseAddress_Bill").click(function (e) {
        ShowDialog3(true);
        e.preventDefault();
    });

    $("#lnk_ChooseAddress_Ship").click(function (e) {
        ShowDialog4(true);
        e.preventDefault();
    });


    $("#btnClose_bill").click(function (e) {
        HideDialog();
        //For Clear the Addreess textboxes when close the pop up
        document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txtaddressLabelBilling").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_telephone_billing").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_fax_billing").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing1").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing2").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing3").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing4").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing5").value = "";
        //For Clear the Addreess textboxes when close the pop up
        e.preventDefault();
    });

    $("#btnClose_bill_Choose").click(function (e) {
        HideDialog3();
        e.preventDefault();
    });

    $("#btnClose_ship_Choose").click(function (e) {
        HideDialog4();
        e.preventDefault();
    });
});

function ShowDialog(modal) {
    $("#overlay").show();
    $("#dialog").fadeIn(300);

    if (modal) {
        $("#overlay").unbind("click");
        txtaddressLabelBilling.value = "";
        txt_telephone_billing.value = "";
        txt_fax_billing.value = "";
        txt_address_billing1.value = "";
        txt_address_billing2.value = "";
        txt_city_billing.value = "";
        txt_state_billing.value = "";
        txt_zipCode_billing.value = "";
    }
    else {
        $("#overlay").click(function (e) {
            HideDialog();
        });
    }
}

function ShowDialog3(modal) {
    $("#Overlay_bill_Choose").show();
    $("#dialog_bill_Choose").fadeIn(300);

    if (modal) {
        $("#Overlay_bill_Choose").unbind("click");
    }
    else {
        $("#Overlay_bill_Choose").click(function (e) {
            HideDialog3();
        });
    }
}

function ShowDialog4(modal) {
    $("#Overlay_ship_Choose").show();
    $("#dialog_ship_Choose").fadeIn(300);

    if (modal) {
        $("#Overlay_ship_Choose").unbind("click");
    }
    else {
        $("#Overlay_ship_Choose").click(function (e) {
            HideDialog4();
        });
    }
}

function HideDialog() {

    $("#overlay").hide();
    $("#dialog").fadeOut(300);
}

function HideDialog3() {
    $("#Overlay_bill_Choose").hide();
    $("#dialog_bill_Choose").fadeOut(300);
}

function HideDialog4() {
    $("#Overlay_ship_Choose").hide();
    $("#dialog_ship_Choose").fadeOut(300);
}



//////-----------------------Same popup for both the new addresses-----------------------//////

function ShowDialog_Both(modal, type) {
    
    $("#overlay").show();
    $("#dialog").fadeIn(300);
    document.getElementById("div_btnsaveprocess12").style.display = "none";       //Added by ved for loading image 
    document.getElementById("div_btnsaveprocessUpdate").style.display = "none";   //Added by ved for loading image 
    if (type == "new") {
        document.getElementById("div_NewAddress").style.display = "block";
        document.getElementById("div_EditAddress").style.display = "none";
        if (modal == "Invoice") {
            $("#overlay").unbind("click");
            RegionalSettingCountryForAddress();
            document.getElementById("Savebtn_Invoice").style.display = "block";
            document.getElementById("Savebtn_Delivery").style.display = "none";
            document.getElementById("Updatebtn_Invoice").style.display = "none";
            document.getElementById("Updatebtn_Delivery").style.display = "none";

            if (isCheckDeliveryInfo == "true" && isCheckInvoiceInfo == "true") {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyAddress").style.display = "none"; //Copy Del to Inv
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = ""; //Copy Inv to Del

                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Invoice").style.display = ""; //Default Inv Address
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Delivery").style.display = "none"; //Default Del Address
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyAddress").style.display = "none"; //Copy Del to Inv
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = "none"; //Copy Inv to Del

                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Invoice").style.display = "none"; //Default Inv Address
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Delivery").style.display = "none"; //Default Del Address
            }
            if (ctl00_ContentPlaceHolder1_ucAddressInfo_hdnTotalAddressCount.value == "0") { //Counting Total Number of Address
                Chk_makedefaultAddres_Invoice.checked = true;
                //Chk_makedefaultAddres_Delivery.checked = true;
            }
            else {
                Chk_makedefaultAddres_Invoice.checked = false;
                //Chk_makedefaultAddres_Delivery.checked = false;
            }
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_ChkcopytoDel").checked = false;//to uncheck the copy checkbox

            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txtaddressLabelBilling").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_telephone_billing").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_fax_billing").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing1").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing2").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing3").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing4").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing5").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txtaddressLabelBilling").focus();
        }
        else if (modal == "Delivery") {
            $("#overlay").unbind("click");
            RegionalSettingCountryForAddress();
            document.getElementById("Savebtn_Invoice").style.display = "none";
            document.getElementById("Savebtn_Delivery").style.display = "block";
            document.getElementById("Updatebtn_Invoice").style.display = "none";
            document.getElementById("Updatebtn_Delivery").style.display = "none";

            if (isCheckDeliveryInfo == "true" && isCheckInvoiceInfo == "true") {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyAddress").style.display = ""; //Copy Del to Inv
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = "none"; //Copy Inv to Del

                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Invoice").style.display = "none"; //Default Inv Address
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Delivery").style.display = ""; //Default Del Address
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyAddress").style.display = "none"; //Copy Del to Inv
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = "none"; //Copy Inv to Del

                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Invoice").style.display = "none"; //Default Inv Address
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Delivery").style.display = "none"; //Default Del Address
            }
            if (ctl00_ContentPlaceHolder1_ucAddressInfo_hdnTotalAddressCount.value == "0") { //Counting Total Number of Address
                //Chk_makedefaultAddres_Invoice.checked = true;
                Chk_makedefaultAddres_Delivery.checked = true;
            }
            else {
                //Chk_makedefaultAddres_Invoice.checked = false;
                Chk_makedefaultAddres_Delivery.checked = false;
            }
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_chkCopytoInvoice").checked = false; //to uncheck the copy checkbox

            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txtaddressLabelBilling").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_telephone_billing").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_fax_billing").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing1").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing2").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing3").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing4").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing5").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txtaddressLabelBilling").focus();
        }
        else {
            $("#overlay").click(function (e) {
                HideDialog();
            });
        }
    }
    else if (type == "edit") {
        document.getElementById("div_NewAddress").style.display = "none";
        document.getElementById("div_EditAddress").style.display = "block";
        if (modal == "Invoice") {
            $("#overlay").unbind("click");
            document.getElementById("Savebtn_Invoice").style.display = "none";
            document.getElementById("Savebtn_Delivery").style.display = "none";
            document.getElementById("Updatebtn_Invoice").style.display = "block";
            document.getElementById("Updatebtn_Delivery").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyAddress").style.display = "none"; //Copy Del to Inv
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = "none"; //Copy Inv to Del
            if (isCheckDeliveryInfo == "true" && isCheckInvoiceInfo == "true") {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Invoice").style.display = ""; //Default Inv Address
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Delivery").style.display = "none"; //Default Del Address
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Invoice").style.display = "none"; //Default Inv Address
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Delivery").style.display = "none"; //Default Del Address
            }
            if (ctl00_ContentPlaceHolder1_ucAddressInfo_hdnTotalAddressCount.value == "0") { //Counting Total Number of Address
                Chk_makedefaultAddres_Invoice.checked = true;
                //Chk_makedefaultAddres_Delivery.checked = true;
            }
            else {
                Chk_makedefaultAddres_Invoice.checked = false;
                //Chk_makedefaultAddres_Delivery.checked = false;
            }
        }
        else if (modal == "Delivery") {
            $("#overlay").unbind("click");
            document.getElementById("Savebtn_Invoice").style.display = "none";
            document.getElementById("Savebtn_Delivery").style.display = "none";
            document.getElementById("Updatebtn_Invoice").style.display = "none";
            document.getElementById("Updatebtn_Delivery").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyAddress").style.display = "none"; //Copy Del to Inv
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = "none"; //Copy Inv to Del
            if (isCheckDeliveryInfo == "true" && isCheckInvoiceInfo == "true") {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Invoice").style.display = "none"; //Default Inv Address
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Delivery").style.display = ""; //Default Del Address
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Invoice").style.display = "none"; //Default Inv Address
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_MakeDefaultAddress_Delivery").style.display = "none"; //Default Del Address
            }
            if (ctl00_ContentPlaceHolder1_ucAddressInfo_hdnTotalAddressCount.value == "0") { //Counting Total Number of Address
                //Chk_makedefaultAddres_Invoice.checked = true;
                Chk_makedefaultAddres_Delivery.checked = true;
            }
            else {
                //Chk_makedefaultAddres_Invoice.checked = false;
                Chk_makedefaultAddres_Delivery.checked = false;
            }

        }
        else {
            $("#overlay").click(function (e) {
                HideDialog();
            });
        }
    }
}

function RegionalSettingCountryForAddress() {
    AutoFill.Get_RegionalSetting_Country(CompanyID, GetRegionalSettingForAddress, onTimeout, onError);
}

function GetRegionalSettingForAddress(RegionalSetting_Country) {
    var ddl_Country = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_ddlCountry");
    ddl_Country.value = RegionalSetting_Country;
}

function onTimeout(err) { }
function onError(err) { }


//////-----------------------Popup for Editing address-----------------------//////