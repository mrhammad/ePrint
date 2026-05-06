function getscreenresolution() {

    var screenwidth = screen.width;


    if (typeof centrepaneltype != 'undefined' && centrepaneltype != undefined && centrepaneltype != null && centrepaneltype == "custom") {
        // for custom category product's in home page
        if (div_customcat_repeater.offsetWidth >= 500 && div_customcat_repeater.offsetWidth < 780) {
            var paddinglefttoremove = Math.round((center_div.offsetWidth - 520) / 2); // two category tile in row )
            var actualwidth = Math.round(center_div.offsetWidth - paddinglefttoremove);
            setdivattributes(center_div, actualwidth, paddinglefttoremove);
        }
        else if (div_customcat_repeater.offsetWidth >= 780 && div_customcat_repeater.offsetWidth < 1040) {
            var paddinglefttoremove = Math.round((div_customcat_repeater.offsetWidth - 780) / 2); // three category tile in row )
            var actualwidth = Math.round(div_customcat_repeater.offsetWidth - paddinglefttoremove);
            setdivattributes(div_customcat_repeater, actualwidth, paddinglefttoremove);

        }
        else if ((div_customcat_repeater.offsetWidth >= 1040) && (div_customcat_repeater.offsetWidth < 1300)) {
            var paddinglefttoremove = Math.round((div_customcat_repeater.offsetWidth - 1040) / 2); // four category tile in row )
            var actualwidth = Math.round(div_customcat_repeater.offsetWidth - paddinglefttoremove);
            setdivattributes(div_customcat_repeater, actualwidth, paddinglefttoremove);

        }

        else if (div_customcat_repeater.offsetWidth >= 1300 && div_customcat_repeater.offsetWidth < 1560) {
            var paddinglefttoremove = Math.round((div_customcat_repeater.offsetWidth - 1300) / 2); // five category tile in row( 1 tile=lm12+w220+rm12=244 )
            var actualwidth = Math.round(div_customcat_repeater.offsetWidth - paddinglefttoremove);
            setdivattributes(div_customcat_repeater, actualwidth, paddinglefttoremove);

        }

        else if (div_customcat_repeater.offsetWidth > 1560) {
            var paddinglefttoremove = Math.round((div_customcat_repeater.offsetWidth - 1560) / 2); // six category tile in row )
            var actualwidth = Math.round(div_customcat_repeater.offsetWidth - paddinglefttoremove);
            setdivattributes(div_customcat_repeater, actualwidth, paddinglefttoremove);

        }

    }
    else if (typeof centrepaneltype != 'undefined' && centrepaneltype != undefined && centrepaneltype != null && centrepaneltype == "new") {
        // for new products in home page
        if (div_customcat_repeater.offsetWidth >= 500 && div_customcat_repeater.offsetWidth < 780) {
            var paddinglefttoremove = Math.round((center_div.offsetWidth - 520) / 2); // two category tile in row )
            var actualwidth = Math.round(center_div.offsetWidth - paddinglefttoremove);
            setdivattributes(center_div, actualwidth, paddinglefttoremove);
        }
        else if (div_newproduct.offsetWidth >= 780 && div_newproduct.offsetWidth < 1040) {
            var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 780) / 2); // three category tile in row
            var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
            setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);

        }
        else if ((div_newproduct.offsetWidth >= 1040) && (div_newproduct.offsetWidth < 1300)) {
            var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 1040) / 2); // four category tile in row )
            var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
            setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);
        }
        else if (div_newproduct.offsetWidth >= 1300 && div_newproduct.offsetWidth < 1560) {
            var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 1300) / 2); // five category tile in row
            var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
            setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);
        }
        else if (div_newproduct.offsetWidth > 1560) {
            var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 1560) / 2); // five category tile in row
            var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
            setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);

        }

    }
    else if (typeof centrepaneltype != 'undefined' && centrepaneltype != undefined && centrepaneltype != null && centrepaneltype == "featured") {
        if (div_customcat_repeater.offsetWidth >= 500 && div_customcat_repeater.offsetWidth < 780) {
            var paddinglefttoremove = Math.round((center_div.offsetWidth - 520) / 2); // two category tile in row )
            var actualwidth = Math.round(center_div.offsetWidth - paddinglefttoremove);
            setdivattributes(center_div, actualwidth, paddinglefttoremove);
        }
        else
            if (div_newproduct.offsetWidth >= 780 && div_newproduct.offsetWidth < 1040) {
                var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 780) / 2); // three category tile in row
                var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
                setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);

            }
            else if ((div_newproduct.offsetWidth >= 1040) && (div_newproduct.offsetWidth < 1300)) {
                var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 1040) / 2); // four category tile in row )
                var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
                setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);
            }
            else if (div_newproduct.offsetWidth >= 1300 && div_newproduct.offsetWidth < 1560) {
                var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 1300) / 2); // five category tile in row
                var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
                setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);
            }
            else if (div_newproduct.offsetWidth > 1560) {
                var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 1560) / 2); // five category tile in row
                var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
                setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);

            }
    }
    else if (typeof centrepaneltype != 'undefined' && centrepaneltype != undefined && centrepaneltype != null && centrepaneltype == "html") {
        if (div_newproduct.offsetWidth >= 780 && div_newproduct.offsetWidth < 1040) {
            var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 780) / 2); // three category tile in row
            var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
            setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);

        }
        else if ((div_newproduct.offsetWidth >= 1040) && (div_newproduct.offsetWidth < 1300)) {
            var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 1040) / 2); // four category tile in row )
            var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
            setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);
        }
        else if (div_newproduct.offsetWidth >= 1300 && div_newproduct.offsetWidth < 1560) {
            var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 1300) / 2); // five category tile in row
            var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
            setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);
        }
        else if (div_newproduct.offsetWidth > 1560) {
            var paddinglefttoremove = Math.round((div_newproduct.offsetWidth - 1560) / 2); // five category tile in row
            var actualwidth = Math.round(div_newproduct.offsetWidth - paddinglefttoremove);
            setdivattributes(div_newproduct, actualwidth, paddinglefttoremove);

        }
    }
}

function setdivattributes(divid, actualwidth, paddinglefttoremove) {
    divid.style.width = actualwidth + "px";
    divid.style.paddingLeft = paddinglefttoremove + "px";
}

getscreenresolution();

function onNodeCollapsed(sender, args) {

    $find("ctl00_ContentPlaceHolder1_RadAjaxManager1").ajaxRequest();
}

function Onclick_Product(ID, Name) {
    var btnSave = 'div_btnsave' + ID;
    var btnProcesImg = 'div_btnsaveprocess' + ID;

    loadingimg(btnSave, btnProcesImg);
    window.location = strSitePath + "products/productdetails.aspx?ID=" + ID + "&amp;type=0";

}

function Delete() {

    if (window.confirm("Are you sure you want to delete this item from the Draft?")) {
        return true;
    }
    else {
        return false;
    }
}

window.setTimeout(function () {
    var label = document.getElementById('ctl00_ContentPlaceHolder1_LblMessage');

    if (label != null) {
        label.style.display = 'none';
    }
}, 5000);

function Onclick_OrderNo() {
    window.location = strSitepath + "order.aspx?OrdKey=" + OrderKey + "";
}
function redirectTo() {
    window.location = strSitepath + "products/product.aspx?ID=0";
}


function check_terms_conditions() {
    debugger
    var ddlTest = document.getElementById('ctl00_ContentPlaceHolder1_ddlTest');
    if (ddlTest != null) {
        if (!ddlTest.disabled) {
            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlTest").value == '') {
                alert("Please select a valid delivery option");
                return false;
            }
        }
    }
    else {
        if (isCheckPaymentInfo.toLowerCase() == 'false') {
            if (IsTerms == 'true') {
                if (chk_terms_conditions.checked) {
                    btn_confirm.style.display = "none";
                    loadingimg('div_btnsave', 'div_btnsaveprocess');
                    return true;
                }
                else {
                    //alert('Please check terms and conditions');
                    alert(Please_check_terms_and_conditions);
                    return false;
                }
            }
            else {
                loadingimg('div_btnsave', 'div_btnsaveprocess');

                return true;
            }
        }
        else {
            loadingimg('div_btnsave5', 'div_btnsaveprocess5');

            return true;
        }
    }
}

function BackToCheckOut() {
    if (Rewritemodule.toLowerCase() == 'on') {
        loadingimg('div_btnsave11', 'div_btnsaveprocess');
        loadingimg('div_btnsave4', 'div_btnsaveprocess4');
        window.location = strSitepath + "checkout" + FileExtension + "?frm=ordrconfrm";

    }
    else {
        loadingimg('div_btnsave11', 'div_btnsaveprocess11');
        loadingimg('div_btnsave4', 'div_btnsaveprocess4');
        window.location = strSitepath + "checkout.aspx?" + "frm=ordrconfrm";
    }
}


function Checkout_Onclick(page) {
    if (Rewritemodule.toLowerCase() == 'on') {
        if (page.toLowerCase() == "checkout") {
            window.location = strSitepath + 'checkout' + FileExtension;
        }
        else if (page.toLowerCase() == "shopping") {
            window.location = strSitepath + "";
        }
    }
    else {
        if (page.toLowerCase() == "checkout") {
            window.location = strSitepath + "checkout" + FileExtension;
        }
        else if (page.toLowerCase() == "shopping") {
            window.location = strSitepath + "";
        }
    }
}

function Rowclick(sender, eventArgs) {
    sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
}


function CallDelete() {
    var frm = document.forms[0];
    var IDs = '';
    var i = 1;
    for (l = 0; l < frm.length; l++) {
        if (frm[l].id.indexOf('chkId') != -1) {
            if (frm[l].checked) {
                IDs = IDs + frm[l].value + ",";
            }
        }
    }
    hidGridCount.value = IDs;

    if (IDs == 0) {
        alert(Chkrow);
        return false;
    }
    else {
        return window.confirm(confirmation);
    }
}


function CheckAll(checkAllBox) {

    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('chkId') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
        if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
    }
}


function show() {

    div_chk.style.border = "inset 1px";
    div_chk.style.background = "#CBCBCB";

    div_popupAction.style.display = "block";
}

function hide() {
    div_chk.style.border = "outset 1px";
    div_chk.style.background = "";

    div_popupAction.style.display = "none";
}

function ImgButtonErase_ClientClick() {
    return window.confirm(confirmation);
}

function Message(lblmsg) {
    div_message.style.display = "block";
    lblMessage.innerHTML = lblmsg;
}


//function Checkout_Onclick(page) {
//    if (Rewritemodule.toLowerCase() == 'on') {
//        if (page.toLowerCase() == "checkout") {
//            window.location = strSitepath + 'checkout' + FileExtension;
//        }
//        else if (page.toLowerCase() == "shopping") {
//            window.location = strSitepath + "";
//        }
//    }
//    else {
//        if (page.toLowerCase() == "checkout") {
//            window.location = strSitepath + "checkout" + FileExtension;
//        }
//        else if (page.toLowerCase() == "shopping") {
//            window.location = strSitepath + "";
//        }
//    }
//}