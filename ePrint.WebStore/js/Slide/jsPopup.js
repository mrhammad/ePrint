
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
function toggleCheckbox() {
    var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_ucAddressInfo_customCheckbox');

    if (checkbox.checked) {
        alert('Order to be Picked up Enabled!');
    } else {
        //ShowDialog_Dc('Delivery', 'new');
        alert('Order to be Picked up Disabled!');

    }
}
function executeWithDialog() {
    debugger
    return ShowDialog_Dc('Delivery', 'new', function () {
        __doPostBack('<%= btn_billingAddress.UniqueID %>', '');
    });
}

function ShowDialog_Dc(modal, type) {
    debugger
    var value1 = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_hdnshippingaddr").value;
    var value2 = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_hdnChkInvAddress").value;
    var AccID = document.getElementById('ctl00_ContentPlaceHolder1_hdnaccountid').value;
    AutoFill.Get_Zip2tax(value1, value2, AccID, onTimeout, onError);
    var checkbox = document.getElementById('ctl00_ContentPlaceHolder1_ucAddressInfo_customCheckbox');
    if (!checkbox.checked) {
        AutoFill.Get_DeliveryCost(value1, value2, AccID, GetDeliveryID, onTimeout, onError);
        document.getElementById("div_dcloading").style.display = "none";
        disableTable();
    }

    //document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_lnkEdit_Ship").style.display = "none";
    //document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_lnkChooseShipAddress").style.display = "none";
    //document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdAddAddress1").style.display = "none";
}

function GetDeliveryID(result) {
    if (result != 0) {
        //var msg = "Ship Engine Error";
        document.getElementById("div_dcloading").style.display = "none";
        enableTable();
        alert(result);
        return false;
    }
    else {
        //alert(result);
        document.getElementById("div_dcloading").style.display = "none";
        enableTable();
        return true;
    }
}

function disableTable() {
    var table = document.getElementById('tb_Address_Details');
    var overlay = document.getElementById('overlayDc');
    overlay.style.opacity = '0.5';
    overlay.style.pointerEvents = 'auto';
    table.setAttribute('disabled', 'disabled');
}

// JavaScript to enable the table
function enableTable() {
    var table = document.getElementById('tb_Address_Details');
    var overlay = document.getElementById('overlayDc');
    overlay.style.opacity = '0';
    overlay.style.pointerEvents = 'none';
    table.removeAttribute('disabled');
}


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

            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyDeltoInvAddress").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_Chk_copy_to_deladdress").checked = false;

            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txtaddressLabelBilling").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_telephone_billing").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_fax_billing").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing1").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing2").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing3").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing4").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing5").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txtaddressLabelBilling").focus();
            RegionalSettingCountryForAddress();
        }
        else if (modal == "Delivery") {
            $("#overlay").unbind("click");
            RegionalSettingCountryForAddress();
            document.getElementById("Savebtn_Invoice").style.display = "none";
            document.getElementById("Savebtn_Delivery").style.display = "block";
            document.getElementById("Updatebtn_Invoice").style.display = "none";
            document.getElementById("Updatebtn_Delivery").style.display = "none";

            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyDeltoInvAddress").style.display = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_Chk_copy_to_invaddress").checked = false;

            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txtaddressLabelBilling").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_telephone_billing").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_fax_billing").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing1").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing2").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing3").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing4").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing5").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txtaddressLabelBilling").focus();

            RegionalSettingCountryForAddress();
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

            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyDeltoInvAddress").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_Chk_copy_to_deladdress").checked = false;
        }
        else if (modal == "Delivery") {
            $("#overlay").unbind("click");
            document.getElementById("Savebtn_Invoice").style.display = "none";
            document.getElementById("Savebtn_Delivery").style.display = "none";
            document.getElementById("Updatebtn_Invoice").style.display = "none";
            document.getElementById("Updatebtn_Delivery").style.display = "block";

            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyInvtoDelAddress").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_CopyDeltoInvAddress").style.display = "";
            document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_Chk_copy_to_invaddress").checked = false;
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