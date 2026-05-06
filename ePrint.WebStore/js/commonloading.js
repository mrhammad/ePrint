function loadingimg(div1, div2) {
    document.getElementById(div1).style.display = "none";
    document.getElementById(div2).style.display = "block";
}

function ValidateLoginControls() {
    var Email = document.getElementById('txtEmail');
    var Password = document.getElementById('txtPassword');
    var result = 0;
    var ReqtxtEmail = document.getElementById('ReqtxtEmail');
    var ReqtxtPassword = document.getElementById('ReqtxtPassword');
    if (Email.value == '') {
        ReqtxtEmail.style.display = 'block';
        Email.focus();
        result = 1;
    }
    if (Email.value != '') {
        result = validate(Email);
        if (result == 1) {
            Email.focus();
        }
    }
    if (Password.value == '') {
        ReqtxtPassword.style.display = 'block';
        if (Email.value != '' && result != 1) {
            Password.focus();
        }
        result = 1;
    }
    if (result == 0) {
        if (onLoginclick()) {
            //loadingimg('div_btnsave', 'div_process');
            loadingimagelogin('Button1', 'div_process');
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}

function onLoginclick() {
    var frm = document.forms[0];
    var boolAllChecked;
    boolAllChecked = true;

    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.id.indexOf('chkval') != -1) {
            if (e.checked == false) {
                boolAllChecked = false;
                break;
            }
        }
    }

    if (!boolAllChecked) {
        alert('Please tick the "Tickbox" to proceed');
        return false;
    }
    else {
        return true;
    }
}

function ValidateForgotControls() {
    var Email = document.getElementById('txtEmail');
    var result = 0;
    var ReqtxtEmail = document.getElementById('ReqtxtEmail');
    if (Email.value == '') {
        ReqtxtEmail.style.display = 'block';
        result = 1;
    }
    if (Email.value != '') {
        result = validate(Email);
    }
    if (result == 0) {
        loadingimg('div_btnsave', 'div_btnsaveprocess');
        return true;
    }
    else {
        return false;
    }
}


function validate(email) {
    var RegtxtEmail = document.getElementById('RegtxtEmail');
    var result = 0;
    var reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var address = email.value;
    if (!reg.test(address)) {
        RegtxtEmail.style.display = 'block';
        result = 1;
    }
    else {
        RegtxtEmail.style.display = 'none';
    }
    return result;
}


function ShowOrHide(Id, Value) {
    var ReqtxtEmail = document.getElementById('ReqtxtEmail');
    var ReqtxtPassword = document.getElementById('ReqtxtPassword');
    if (Id == 'txtEmail' && Value != '') {
        ReqtxtEmail.style.display = 'none';
    }
    else if (Id == 'txtPassword' && Value != '') {
        ReqtxtPassword.style.display = 'none';
    }
}

function ShowBehalfOfDiv() {
    var ddl_SelectBehalf = document.getElementById("ctl00_ContentPlaceHolder1_ddl_SelectBehalf");
    var SelValue = ddl_SelectBehalf.options[ddl_SelectBehalf.selectedIndex].value
    if (SelValue == "1") {
        document.getElementById("ctl00_ContentPlaceHolder1_divUserBehalf").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_divDeptBehalf").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_hdnUserBehalf").value = "1";
        document.getElementById("ctl00_ContentPlaceHolder1_hdnDeptBehalf").value = "0";
        document.getElementById("ctl00_ContentPlaceHolder1_divDeptUsers").style.display = "none";
        document.getElementById("divattnof").style.display = "none";
    }
    else if (SelValue == "2") {
        document.getElementById("ctl00_ContentPlaceHolder1_divDeptBehalf").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_divUserBehalf").style.display = "none";
        //document.getElementById("ctl00_ContentPlaceHolder1_ddl_BehalfDepts").value = "0";
        document.getElementById("ctl00_ContentPlaceHolder1_hdnDeptBehalf").value = "1";
        document.getElementById("ctl00_ContentPlaceHolder1_hdnUserBehalf").value = "0";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_divDeptBehalf").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_divUserBehalf").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_divDeptUsers").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_ddl_BehalfDepts").value = "0";
        document.getElementById("ctl00_ContentPlaceHolder1_ddl_BehalfUsers").value = "0";
        document.getElementById("divattnof").style.display = "none";
    }
}

function ValidatePrintReadyFile(id, divid) {
    var chkConform = document.getElementById("ctl00_ContentPlaceHolder1_chkconform");
    if (chkConform.checked) {
        document.getElementById(id).style.display = "none";
        document.getElementById(divid).style.display = "block";
        return true;
    }
    else {
        alert("Print Ready File is not confirmed by the user");
        return false;
    }

}

function LoadSelectedDeptUsers() {
    var ddl_SelectBehalf = document.getElementById("ctl00_ContentPlaceHolder1_ddl_BehalfDepts");
    var div_deptusers = document.getElementById("ctl00_ContentPlaceHolder1_divDeptUsers");
    var DeptID = ddl_SelectBehalf.options[ddl_SelectBehalf.selectedIndex].value;

    if (DeptID == Number(0)) {
        div_deptusers.style.display = "none";
        document.getElementById("divattnof").style.display = "none";
    }
    else {

        div_deptusers.style.display = "block";
        document.getElementById("divattnof").style.display = "block";
    }
    AutoFill.GetStoreUserOnDeptID(DeptID, LoadDeptContacts);

}

function LoadDeptContacts(result) {
    if (result != ' ') {
        var dd_deptusers = document.getElementById("ctl00_ContentPlaceHolder1_ddl_DeptUsers");
        dd_deptusers.length = 0;

        var strcost = result.split('^');
        if (strcost.length > Number(2)) {
            dd_deptusers.options.add(new Option('---Select User---', 0));
        }
        var defalut = strcost[0].split('±');
        var defalutcontid = defalut[0];

        for (var c = 1; c < strcost.length; c++) {
            if (strcost[c] != '') {
                var CostCentreConCat = strcost[c].split('±');
                StoreUserID = CostCentreConCat[0];
                StoreUserName = SpecialDecode(CostCentreConCat[1]);
                dd_deptusers.options.add(new Option(StoreUserName, StoreUserID));
            }
        }
        if (SelectedDeptUser != Number(0)) {
            defalutcontid = SelectedDeptUser;
        }
        if (defalutcontid != Number(0)) {
            for (i = 0; i < dd_deptusers.length; i++) {
                if (dd_deptusers.options[i].value == Number(defalutcontid)) {

                    dd_deptusers.selectedIndex = i;
                }
            }
        }
        else {
            dd_deptusers.selectedIndex = 0;
        }
    }
}

function setmargin() {

    var f = window.getComputedStyle(divSelectBehalf, null);
    var e = window.getComputedStyle(divUserBehalf, null);
    var g = window.getComputedStyle(divDeptBehalf, null);

    if (e.display == "none" && f.display == "none" && g.display == "block") {
        divDeptBehalf.style.marginTop = "-20px";
    }

    if (f.display == "none" && g.display == "none" && e.display == "block") {
        divUserBehalf.style.marginTop = "-18px";
    }
}     

function CopyEmailtoPassword(Id, Value) {
    var txtPassword = document.getElementById('txtPassword');
    txtPassword.value = Value;
}
function loadingimagelogin(divtohide, divload) {

    ; (function (a) { a.fn.extend({ actual: function (b, l) { if (!this[b]) { throw '$.actual => The jQuery method "' + b + '" you called does not exist'; } var f = { absolute: false, clone: false, includeMargin: false }; var i = a.extend(f, l); var e = this.eq(0); var h, j; if (i.clone === true) { h = function () { var m = "position: absolute !important; top: -1000 !important; "; e = e.clone().attr("style", m).appendTo("body"); }; j = function () { e.remove(); }; } else { var g = []; var d = ""; var c; h = function () { c = e.parents().andSelf().filter(":hidden"); d += "visibility: hidden !important; display: block !important; "; if (i.absolute === true) { d += "position: absolute !important; "; } c.each(function () { var m = a(this); g.push(m.attr("style")); m.attr("style", d); }); }; j = function () { c.each(function (m) { var o = a(this); var n = g[m]; if (n === undefined) { o.removeAttr("style"); } else { o.attr("style", n); } }); }; } h(); var k = /(outer)/g.test(b) ? e[b](i.includeMargin) : e[b](); j(); return k; } }); })(jQuery);

    // actual script starts here
    document.getElementById(divtohide).style.display = "none";
    var width = $('#' + divtohide).actual('width') + 'px';
    var height = $('#' + divtohide).actual('height') + 'px';
    var paddingleft = $('#' + divtohide).css("paddingLeft");
    var paddingright = $('#' + divtohide).css("paddingRight");
    var paddingtop = $('#' + divtohide).css("paddingTop");
    var paddingbottom = $('#' + divtohide).css("paddingBottom");
    var marginleft = $('#' + divtohide).css("marginLeft");
    var marginright = $('#' + divtohide).css("marginRight");
    var margintop = $('#' + divtohide).css("marginTop");
    var marginbottom = $('#' + divtohide).css("marginBottom");
    var Left = (getOffset(document.getElementById(divtohide)).left + 'px');
    var Top = (getOffset(document.getElementById(divtohide)).top + 'px');

    //set the attributes according to browser generated value
    document.getElementById(divload).setAttribute("class", "Loginbuttoscss");
    document.getElementById(divload).style.display = "block";
    document.getElementById(divload).style.width = width;
    document.getElementById(divload).style.height = height;
    document.getElementById(divload).style.left = Left;
    document.getElementById(divload).style.top = Top;
    document.getElementById(divload).style.paddingLeft = paddingleft;
    document.getElementById(divload).style.paddingRight = paddingright;
    document.getElementById(divload).style.paddingTop = paddingtop;
    document.getElementById(divload).style.paddingBottom = paddingbottom;
    document.getElementById(divload).style.marginLeft = marginleft;
    document.getElementById(divload).style.marginRight = marginright;
    document.getElementById(divload).style.marginTop = margintop;
    document.getElementById(divload).style.marginBottom = marginbottom;

}

function getOffset(el) {
    var _x = 0;
    var _y = 0;
    while (el && !isNaN(el.offsetLeft) && !isNaN(el.offsetTop)) {
        _x += el.offsetLeft;
        _y += el.offsetTop;
        el = el.offsetParent;
    }
    return { top: _y, left: _x };
}

function Pdf_ImagPopup(Images, AccountID, strSitepath, Mode) {    
    var window = GetRadWindow();
    $(".div_imagePreview").html('');
    var image = Images.toString().split(',');
    var display = '', selected = 'selected';
    var childImages = "";
    for (var i = 0 ; i < image.length - 1; i++) {
        if (i > 0) {
            display = "none";
            selected = "";
        }
        src = PDFToURLPath + AccountID + "/pdf/" + image[i];
        childImages += "<li class='" + selected + "' style='display:" + display + ";padding-top:15px;text-align:center'><img class='img' style='width:50%;background:white;' onload='imgLoaded(this);' src='" + src + "'/><input type='hidden' value='" + image[i] + "'/></li>";

    }
    $("#ctl00_ContentPlaceHolder1_ImagePopWindow_C").css("background", '#323639');
    $(".div_imagePreview").append(childImages);
    window.show();

}


