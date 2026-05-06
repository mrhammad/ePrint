
function HighLitedMenu1(x, url) {
    //    document.getElementById(x).style.backgroundColor = 'grey';
    window.location.href = url;
}
function tdOver(obj, id) {

    obj.className = 'VMenu-Focus';
    document.getElementById(id).className = 'normalText_Focus';
    //onmouseover="this.className='VMenu-Focus';document.getElementById('td0').className='normalText_Focus'"
    //onmouseout="this.className='VMenu';document.getElementById('td0').className='Caption2Out'"             
}
function tdOut(obj, id) {

    obj.className = 'VMenu';
    document.getElementById(id).className = 'Caption2Out';
}

function imgbtnDelete_ClientClick() {
    return confirm("Are you sure you want delete this record?");
}

function HighLitedMenu(x, url) {
    window.location.href = url;
}


function showpharse(val) {
    var img_actionsShow = document.getElementById("img_actionsShow");
    var img_actionsHide = document.getElementById("img_actionsHide");
    var div_chk = document.getElementById("div_chk");
    var div_popupAction = document.getElementById("div_popupAction");

    var img_actionsShow_Del = document.getElementById("img_actionsShow_Del");
    var img_actionsHide_Del = document.getElementById("img_actionsHide_Del");
    var div_chk_Del = document.getElementById("div_chk_Del");
    var div_popupAction_Del = document.getElementById("div_popupAction_Del");

    if (val == 'manemails') {
        img_actionsHide.style.display = "block";
        img_actionsShow.style.display = "none";
        div_chk.style.border = "inset 1px";
        div_chk.style.background = "gray";
        div_popupAction.style.display = "block";
    }
    else if (val == 'login') {
        img_actionsHide_Del.style.display = "block";
        img_actionsShow_Del.style.display = "none";
        div_chk_Del.style.border = "inset 1px";
        div_chk_Del.style.background = "gray";
        div_popupAction_Del.style.display = "block";
    }
}

function hidephrase(val) {
    var img_actionsShow = document.getElementById("img_actionsShow");
    var img_actionsHide = document.getElementById("img_actionsHide");
    var div_chk = document.getElementById("div_chk");
    var div_popupAction = document.getElementById("div_popupAction");
    if (val == 'manemails') {
        img_actionsHide.style.display = "none";
        img_actionsShow.style.display = "block";
        div_chk.style.border = "outset 1px";
        div_chk.style.background = "";
        div_popupAction.style.display = "none";
    }
    else if (val == 'login') {
        img_actionsHide_Del.style.display = "none";
        img_actionsShow_Del.style.display = "block";
        div_chk_Del.style.border = "outset 1px";
        div_chk_Del.style.background = "";
        div_popupAction_Del.style.display = "none";
    }
}

function CheckOne_new(val) {
    var Counter = 0;
    var frm = document.forms[0];
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.id.indexOf('checkBox_Email') != -1) {
            if (!e.disabled) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                }
            }
        }
    }

    hidephrase();

    if (Number(Counter) == 0) {
        if (val == "enable")
            alert("Please check at least one row to Enable");
        if (val == "disable")
            alert("Please check at least one row to Disable");
        if (val == "copyemail")
            alert("Please check at least one row to Copy Email");
        if (val == "del")
            alert("Please check at least one row to Delete");
        return false;
    }
    else {
        if (val == "enable") {
            document.getElementById("ctl00_ContentPlaceHolder1_ucPhraseBook_lblCOpy").value = "enable";
            document.getElementById("ctl00_ContentPlaceHolder1_ucPhraseBook_btnEmailCopy").click();
            return true;
        }

        if (val == "disable") {
            document.getElementById("ctl00_ContentPlaceHolder1_ucPhraseBook_lblCOpy").value = "disable";
            document.getElementById("ctl00_ContentPlaceHolder1_ucPhraseBook_btnEmailCopy").click();
            return true;
        }
        if (val == "copyemail") {
            if (true) {
                Show_EmailaccountListDiv();
                return true;
            }
            else {
                return false;
            }
        }
        if (val == "del") {
            return window.confirm('Are you sure you want to delete this record(s)?');
        }
    }
}

function checkAll_new(checkAllBox) {

    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Email') != -1) {
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


function Show_accountListDiv() {
    showDivPopupCenter('div_accountsList', '200');
    ShowPopUp();
    RadWinClose();
}

//function CallDelete() {
//    var ret = CheckOne();
//    if (ret) {
//        CheckGrid();
//        return true;
//    }
//    else {
//        return false;
//    }
//}
//function CheckOne() {
//    var Counter = 0;
//    var frm = document.forms[0];
//    for (i = 0; i < frm.length; i++) {
//        e = frm.elements[i];
//        if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
//            if (e.checked)
//                Counter = Number(Counter) + 1;
//        }
//    }
//    if (Number(Counter) == 0) {
//        alert("Please check at least one 'row' to Delete");
//        return false;
//    }
//    else {
//        return window.confirm('Are you sure you want to delete this record(s)?');
//        //  return true;
//    }
//}


//function ChkMainApprApprove() {
//    var ChkMainAppr = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMainApprove");
//    var ChkDept = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptApprove");
//    var TabDept = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_TabDept");

//    if (ChkMainAppr.checked == true) {
//        ChkDept.checked = false;
//        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divPopup").style.display = 'none';
//    }
//}

//function CheckDesignate() {
//    var ChkDept = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDesignateApp");
//    var TabDept = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_DeptApprove");

//    if (ChkDept.checked == true) {
//        TabDept.style.display = 'block';
//    }
//    else {
//        TabDept.style.display = 'none';

//    }

//}

//Check Box slide toggle using J-query-----------------

function ShowIPAddress() {
    $("#ctl00_ContentPlaceHolder1_divIPAddress").slideToggle("slow");
    document.getElementById("ctl00_ContentPlaceHolder1_divIPAddress").style.display = "block";
    var chk = document.getElementById("ctl00_ContentPlaceHolder1_chkIPAddress");
    if (chk.checked) {
        document.getElementById("ctl00_ContentPlaceHolder1_txtRestrict").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_txtRestrict").focus();
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_txtRestrict").disabled = true;
        //document.getElementById("ctl00_ContentPlaceHolder1_txtRestrict").value = "";
    }
}

function ShowDepartmentApprovers() {
    $("#ctl00_ContentPlaceHolder1_ApprovalSystem_divDeptApprovers").slideToggle("slow");
    document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divDeptApprovers").style.display = "block";

    document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkRepprovalByMainApp").checked = false;
    //Added by ved
    var CheckedBox = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptApprove");

    if (CheckedBox.checked) {
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain").checked = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain").disabled = false;
    }
    else {
        var chkRequirePWD = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkRequirePWD");
        if (chkRequirePWD.checked == false) {
            document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain").disabled = false;
        }
    }
}
function CheckMainApprover() {
    var CheckedBoxAll = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkRequirePWD");
    if (CheckedBoxAll.checked) {
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain").checked = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain").disabled = false;
    }
    else {
        var chkDeptApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptApprove");
        if (chkDeptApprove.checked == false) {
            document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain").disabled = false;
        }
    }
}

function ShowMainApprovalPanel() {

    var chkNewProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewProfileApproval");
    var chkEditProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkEditProfileApproval");
    var chkNewOrderApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewOrderApproval");

    var hdnRegReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnRegReqApproval_History");
    var hdnEditProfileReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnEditProfileReqApproval_History");
    var hdnNewOrderReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnNewOrderReqApproval_History");

    if (hdnRegReqApproval_History.value == '1' && chkNewProfileApproval.checked == false) {
        chkNewProfileApproval.checked = true;
        ShowNewProfilesReqApproval();
    }

    if (hdnEditProfileReqApproval_History.value == '1') {
        chkEditProfileApproval.checked = true;
    }

    if (hdnNewOrderReqApproval_History.value == '0' && chkNewOrderApproval.checked) {
        chkNewOrderApproval.checked = false;
        ShowNewOrdersReqApproval();
    }

    document.getElementById("tr_NewProfileApproval").style.display = "";
    document.getElementById("tr_EditProfileApproval").style.display = "";
    chkNewOrderApproval.style.display = "block";
    document.getElementById("div_New_orders_requires").style.display = "block";

}

function ShowUserDesignatedPanel() {

    var chkUserDesignateOwnApprover = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkUserDesignateOwnApprover");

    if (!chkUserDesignateOwnApprover.checked) {
        chkUserDesignateOwnApprover.checked = true;
        $("#ctl00_ContentPlaceHolder1_ApprovalSystem_divUserDesignatedApprovers").slideToggle("fast");
    }

    var chkNewProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewProfileApproval");
    var chkEditProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkEditProfileApproval");
    var chkNewOrderApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewOrderApproval");

    var hdnRegReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnRegReqApproval_History");
    var hdnEditProfileReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnEditProfileReqApproval_History");
    var hdnNewOrderReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnNewOrderReqApproval_History");

    if (hdnRegReqApproval_History.value == '1' && chkNewProfileApproval.checked == false) {
        chkNewProfileApproval.checked = true;
        ShowNewProfilesReqApproval();
    }

    if (hdnEditProfileReqApproval_History.value == '1') {
        chkEditProfileApproval.checked = true;
    }

    if (hdnNewOrderReqApproval_History.value == '0' && chkNewOrderApproval.checked) {
        chkNewOrderApproval.checked = false;
        ShowNewOrdersReqApproval();
    }

    document.getElementById("tr_NewProfileApproval").style.display = "";
    document.getElementById("tr_EditProfileApproval").style.display = "";
    chkNewOrderApproval.style.display = "block";
    document.getElementById("div_New_orders_requires").style.display = "block";
}

function ShowMarkalltheitemsasApproved() {

    document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMarkalltheitemsasApproved").checked = true;

    var chkNewOrderApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewOrderApproval");
    var chkNewProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewProfileApproval");
    var chkEditProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkEditProfileApproval");

    var hdnRegReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnRegReqApproval_History");
    var hdnEditProfileReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnEditProfileReqApproval_History");
    var hdnNewOrderReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnNewOrderReqApproval_History");

    if (hdnRegReqApproval_History.value == '1') {
        chkNewProfileApproval.checked = false;
        ShowNewProfilesReqApproval();
    }
    document.getElementById("tr_NewProfileApproval").style.display = "none";

    chkEditProfileApproval.checked = false;
    document.getElementById("tr_EditProfileApproval").style.display = "none";

    if (!chkNewOrderApproval.checked) {
        chkNewOrderApproval.checked = true;
        ShowNewOrdersReqApproval();
    }

    chkNewOrderApproval.style.display = "none";
    document.getElementById("div_New_orders_requires").style.display = "none";

}

function ShowUserDesignatedApprovers() {

    $("#ctl00_ContentPlaceHolder1_ApprovalSystem_divUserDesignatedApprovers").slideToggle("slow");
    document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divUserDesignatedApprovers").style.display = "block";

}

function ShowNewOrdersReqApproval() {

    $("#ctl00_ContentPlaceHolder1_ApprovalSystem_divNewOrdersReqApproval").slideToggle("slow");
    document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divNewOrdersReqApproval").style.display = "block";

}

function ShowNewOrdersReqApproval2() {

    var chkNewOrderApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewOrderApproval");
    var hdnNewOrderReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnNewOrderReqApproval_History");
    if (chkNewOrderApproval.checked) {
        hdnNewOrderReqApproval_History.value = '1';
    }
    else {
        hdnNewOrderReqApproval_History.value = '0';
    }
}

function ShowNewProfilesReqApproval() {

    $("#ctl00_ContentPlaceHolder1_ApprovalSystem_divNewProfilesReqApproval").slideToggle("slow");
    document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divNewProfilesReqApproval").style.display = "block";
}

function ShowNewProfilesReqApproval2() {

    var chkNewProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewProfileApproval");
    var hdnRegReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnRegReqApproval_History");
    if (chkNewProfileApproval.checked) {
        hdnRegReqApproval_History.value = '1';
    }
    else {
        hdnRegReqApproval_History.value = '0';
    }

}

function ShowEditProfilesReqApproval() {

    var chkEditProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkEditProfileApproval");
    var hdnEditProfileReqApproval_History = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnEditProfileReqApproval_History");

    if (chkEditProfileApproval.checked) {
        hdnEditProfileReqApproval_History.value = '1';
    }
    else {
        hdnEditProfileReqApproval_History.value = '0';
    }

}

function ShowUserOrderingProcess() {
    if ($("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkUserOrderingProcess").prop('checked') == true) {

        //   $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess").slideToggle("slow");
        // document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess").style.display = "block";
        // document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess").style.display = "block";
    }
    else {
        //$("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess").slideToggle("slow");
        // document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess").style.display = "none";
    }
}

function ShowDeptOrderingProcess() {
    if ($("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess").prop('checked') == true) {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess").slideToggle("slow");
        document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess").style.display = "block";
    }
    else {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess").slideToggle("slow");
    }
}


function ShowAllowOrderBehalf() {
    if ($("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllowOrder").prop('checked') == true) {

        document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divAllowOrderBehalf123").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divAllowOrderBehalf123").className = "";

        var chkUser = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkUserOrderingProcess");

        if (chkUser.checked == false) {
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").className = "DivBackColor";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").className = "";
        }

        var chkDep = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptOrderingProcess");

        if (chkDep.checked == false) {
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").className = "DivBackColor";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").className = "";
        }


        // $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divAllowOrderBehalf").slideToggle("slow");
        // document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divAllowOrderBehalf").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divAllowOrderBehalf123").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divAllowOrderBehalf123").className = "DivBackColor";

        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptOrderingProcess").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkUserOrderingProcess").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoAllUsers").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserMain").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserDept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserUser").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoUser").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptMain").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptUser").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoAll_Dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllMain_dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllDept_dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUser_dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoBelong_Dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongMain_dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongDept_dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_chkBelongUser_dept").prop('checked', false);
        // document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess").style.display = "none";
        // $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divAllowOrderBehalf").slideToggle("slow");
        // document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divAllowOrderBehalf").style.display = "none";

        var chkUser = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkUserOrderingProcess");

        if (chkUser.checked == false) {
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").className = "DivBackColor";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").className = "";
        }


        var chkDep = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptOrderingProcess");

        if (chkDep.checked == false) {
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").className = "DivBackColor";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").className = "";
        }


    }
}

function SelectChangeAddress() {
    if ($("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAddress").prop('checked') == true) {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAdrs_Main").prop('checked', true);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAdrs_Dept").prop('checked', true);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAdrs_User").prop('checked', true);
    }
    else {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAdrs_Main").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAdrs_Dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAdrs_User").prop('checked', false);
    }
}

function Default_Select(Type) {
    chkChangeAddress = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAddress");
    chkSelectAddress = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkSelectAddress");
    chkEditAddress = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkEditAddress");
    chkNewAddress = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkNewAddress");
    chkChangeAdrs_Main = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAdrs_Main");
    chkChangeAdrs_Dept = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAdrs_Dept");
    chkChangeAdrs_User = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkChangeAdrs_User");

    if (chkSelectAddress.checked || chkEditAddress.checked || chkNewAddress.checked) {
        chkChangeAddress.checked = true;
        chkChangeAdrs_Main.checked = true;
        chkChangeAdrs_Dept.checked = true;
        chkChangeAdrs_User.checked = true;

        chkChangeAddress.disabled = true;
        chkChangeAdrs_Main.disabled = true;
        chkChangeAdrs_Dept.disabled = true;
        chkChangeAdrs_User.disabled = true;

        if (Type != "PL") {
            SelectChangeAddress();
        }
    }
    else {
        chkChangeAddress.disabled = false;
        chkChangeAdrs_Main.disabled = false;
        chkChangeAdrs_Dept.disabled = false;
        chkChangeAdrs_User.disabled = false;
    }
}

function SelectAddress() {
    if ($("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkSelectAddress").prop('checked') == true) {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkSelectAdrs_Main").prop('checked', true);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkSelectAdrs_Dept").prop('checked', true);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkSelectAdrs_User").prop('checked', true);
    }
    else {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkSelectAdrs_Main").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkSelectAdrs_Dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkSelectAdrs_User").prop('checked', false);
    }
    Default_Select('');
}

function SelectEditAddress() {
    if ($("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkEditAddress").prop('checked') == true) {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkEditAdrs_Main").prop('checked', true);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkEditAdrs_Dept").prop('checked', true);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkEditAdrs_User").prop('checked', true);
    }
    else {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkEditAdrs_Main").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkEditAdrs_Dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkEditAdrs_User").prop('checked', false);
    }
    Default_Select('');
}

function SelectNewAddress() {
    if ($("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkNewAddress").prop('checked') == true) {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkNewAdrs_Main").prop('checked', true);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkNewAdrs_Dept").prop('checked', true);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkNewAdrs_User").prop('checked', true);
    }
    else {
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkNewAdrs_Main").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkNewAdrs_Dept").prop('checked', false);
        $("#ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i1_chkNewAdrs_User").prop('checked', false);
    }
    Default_Select('');
}

//---------------------------------------------------------

//function ApproveCheck() {
//    var ChkMain = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMainApprove");
//    var ChkDisApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDisapprove");
//    if (ChkMain.checked == true) {
//        ChkDisApprove.checked = false;
//    }
//}

//function DisapproveCheck() {
//    var ChkMain = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMainApprove");
//    var ChkDisApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDisapprove");
//    if (ChkDisApprove.checked == true) {
//        ChkMain.checked = false;
//    }

//}

//function MainApproveCheck() {
//    var chkUserDesignateOwnApprover = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkUserDesignateOwnApprover");
//    if (chkUserDesignateOwnApprover.checked == true) {
//        $("#ctl00_ContentPlaceHolder1_ApprovalSystem_DeptApprove").slideToggle("slow");
//    }
//    chkUserDesignateOwnApprover.checked = false;
//}

//function UserDesignateApproveCheck() {
//    var chkDeptApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptApprove");
//    if (chkDeptApprove.checked == true) {
//        $("#ctl00_ContentPlaceHolder1_ApprovalSystem_divPopup").slideToggle("slow");
//    }
//    chkDeptApprove.checked = false;
//}

function onpage(val) {
    try {

        if (val == 'none') {

            slidedown("ctl00_ContentPlaceHolder1_ucPhraseBook_PraseMenue_divonpage");
            document.getElementById("showonpage").style.display = 'none'
            document.getElementById("onpage").style.display = 'block'
        }
        else {

            slideup("ctl00_ContentPlaceHolder1_ucPhraseBook_PraseMenue_divonpage");
            document.getElementById("showonpage").style.display = 'block'
            document.getElementById("onpage").style.display = 'none'
        }
    }
    catch (err) {

    }
    return false;
}

onpage('block');

function Show_EmailaccountListDiv() {
    hidephrase();
    showDivPopupCenter('div_EmailaccountsList', '220');
    ShowPopUpEmail();
    RadWinClose();
}

//-------------------Section for Js functions used for header starts ------------------------------------------ //

function Redirect_Approval(url) {
    window.location.href = url;

}

//function RedirectApprovalSystem(url, Redirect, IsCustomAccessRights) {
//    //alert(urlType);
//    IsCustomAccessRights = IsCustomAccessRights.toLowerCase();
//    if (IsCustomAccessRights == 'true') {
//        Redirect = Redirect.toLowerCase();
//        if (Redirect == 'false') {
//            alert("You are not authorized to view this page");
//        }
//        else {

//            window.location.href = url;

//        }
//    }
//    else {

//        window.location.href = url;

//    }
//}

function Redirect_Headerhref(url, Redirect, IsCustomAccessRights) {

    //alert(urlType);
    IsCustomAccessRights = IsCustomAccessRights.toLowerCase();
    if (IsCustomAccessRights == 'true') {

        Redirect = Redirect.toLowerCase();
        if (Redirect == 'false') {
        }
        else {

            window.location.href = url;

        }
    }
    else {

        window.location.href = url;

    }
}

function Redirect_LeftPanel() {

    alert("You are not authorized to view this page");
}

//function Redirect_LeftPanel(type, Status, url) {
//    if (type == 'bit') {
//        if (Status != 'True') {
//            alert("You are not authorized to view this page");
//        }
//        else {
//            window.location.href = url;
//        }
//    }
//    else if (type == 'char') {
//        if (Status != '1') {
//            alert("You are not authorized to view this page");
//        }
//        else {
//            window.location.href = url;
//        }
//    }
//}

function changeStyle(xobj, xStyle, xbgColor) {
    xobj.className = xStyle;
    xobj.style.backgroundColor = xbgColor;
}

function displaynone(headerforecolor) {
    document.getElementById("div_dropdown_estimate").style.display = 'none';
    document.getElementById("div_dropdown_jobs").style.display = 'none';
    document.getElementById("div_dropdown_crm").style.display = 'none';
    document.getElementById("div_dropdown_purchase").style.display = 'none';
    document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
    document.getElementById("div_dropdown_invoice").style.display = 'none';
    document.getElementById("div_dropdown_inventry").style.display = 'none';
    document.getElementById("div_dropdown_orders").style.display = 'none';
    document.getElementById("div_dropdown_reports").style.display = 'none';
    document.getElementById("div_dropdown_campaign").style.display = 'none';
    document.getElementById("div_settings").style.display = 'none';
    document.getElementById("div_ProductCatalogue").style.display = 'none';
    document.getElementById("div_SettingsMenu").style.display = 'none';
    //   document.getElementById("divForecastmodule").style.display = 'none';
    document.getElementById("div_dropdown_proofs").style.display = 'none';

    var pnlMainMenu = document.getElementById('pnlmainmenu');
    var spncount = pnlMainMenu.getElementsByTagName('span');
    if (spncount.length > 0) {
        for (var i = 0; i < spncount.length; i++) {
            if (spncount[i] != null) {
                if (spncount[i].id.indexOf('ModuleName') != -1) {
                    if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                        spncount[i].setAttribute("style", "color:black;");
                        //                        spncount[0].setAttribute("style", "text-transform:capitalize");
                        //                        //ved
                    }
                }
            }
        }
    }
}

//var myWidth = 0;
var Width = 0;
//function getWindowWidth() {
//    if (typeof (window.innerWidth) == 'number') {
//        //Non-IE
//        myWidth = window.innerWidth;
//    } else if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
//        //IE 6+ in 'standards compliant mode'
//        myWidth = document.documentElement.clientWidth;
//    } else if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
//        //IE 4 compatible
//        myWidth = document.body.clientWidth;
//    }
//    return myWidth;
//}

//getWindowWidth();


function ucfirst(str) {
    var firstLetter = str.substr(0, 1);
    var remainingstring = str.substr(1);
    // return firstLetter.toUpperCase() + remainingstring.toLowerCase();
    return str;
}

function changeBorderColor(tabcolor) {
    if (tabcolor != '' || tabcolor != 'undefined') {
        document.getElementById('pnlmainmenu').setAttribute("style", "border-top:solid 1px #D5D5D5; border-bottom:solid 0px " + tabcolor + "");
        document.getElementById('pnlserach').setAttribute("style", "border-top:solid 1px #D5D5D5; border-bottom:solid 0px " + tabcolor + "");
    }
}

var dynamicscreenName = '';
function onhovermenu(scrnname, screenname, name, tabcolor, headerforecolor) {
    var Left = (getOffset(document.getElementById(name)).left + 'px');
    var Top = (getOffset(document.getElementById(name)).top + 'px');
    var scrn = scrnname;
    dynamicscreenName = screenname;

    // edit styles dynamically
    var stylesheet = document.createElement('style');
    stylesheet.innerHTML = "nav ul li:hover {background-color: " + tabcolor + ";}";
    document.body.appendChild(stylesheet);
    // end

    var currentdiv = document.getElementById(screenname);
    if (currentdiv != null) {
        currentdiv.className = '';
    }

    if (scrn == "estimates/estimate_view.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            var val = ucfirst(screenname);
            document.getElementById("div_dropdown_estimate").style.display = 'block';
            document.getElementById("ctl00_header1_lblEstscreenname").innerHTML = SpecialDecode(val);
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            // document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_estimate');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].style.forecolor = headerforecolor;
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "Jobs/jobs_view.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            var val = ucfirst(screenname);
            document.getElementById("ctl00_header1_lblJobscreenname").innerHTML = SpecialDecode(val);
            document.getElementById("div_dropdown_jobs").style.display = 'block';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            //  document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_jobs');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "client/client_view.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            document.getElementById("div_dropdown_crm").style.display = 'block';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            // document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_crm');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "Purchase/purchase_view.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            var val = ucfirst(screenname);
            document.getElementById("ctl00_header1_lblPurchasescreenname").innerHTML = SpecialDecode(val);
            document.getElementById("div_dropdown_purchase").style.display = 'block';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            //  document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_purchase');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "Delivery/delivery_view.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            var val = ucfirst(screenname);
            document.getElementById("ctl00_header1_lblDeliveryscreenname").innerHTML = SpecialDecode(val);
            document.getElementById("div_dropdown_deliverynotes").style.display = 'block';

            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            //   document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_deliverynotes');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "Estimates/Proofs.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            var val = ucfirst(screenname);
            document.getElementById("div_dropdown_proofs").style.display = 'block';
            //document.getElementById("ctl00_header1_lblProofscreenname").innerHTML = SpecialDecode(val);
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            // document.getElementById("divForecastmodule").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_proofs');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].style.forecolor = headerforecolor;
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "Invoice/invoice_view.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            var val = ucfirst(screenname);
            document.getElementById("ctl00_header1_lblInvoicescreenname").innerHTML = SpecialDecode(val);
            document.getElementById("div_dropdown_invoice").style.display = 'block';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            //   document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_invoice');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "warehouse/warehouse.aspx?type=inventory") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            var val = ucfirst(screenname);
            document.getElementById("ctl00_header1_lblWarehousescreenname").innerHTML = SpecialDecode(val);
            document.getElementById("div_dropdown_inventry").style.display = 'block';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            // document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_inventry');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "common/report.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            document.getElementById("div_dropdown_reports").style.display = 'block';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            //  document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_reports');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "Orders/order_view.aspx" || scrn == "orders/order_view.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            var val = ucfirst(screenname);
            document.getElementById("ctl00_header1_lblOrderscreenname").innerHTML = SpecialDecode(val);
            document.getElementById("div_dropdown_orders").style.display = 'block';
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            //   document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_orders');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        // spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "campaign/campaign_view.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            var val = ucfirst(screenname);
            document.getElementById("ctl00_header1_lblCamaignscreenname").innerHTML = SpecialDecode(val);
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'block';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            // document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_dropdown_campaign');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "ProductCatalogue/PriceCatalogue.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'block';
            document.getElementById("div_SettingsMenu").style.display = 'none';
            //  document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_ProductCatalogue');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "settings/settings.aspx" || scrn == "StoreSettings/StoreSettings.aspx") {
        if (name == name) {
            var div = document.getElementById('divDrpdwn');
            div.style.left = Left;
            if (name == 'navbar') {
                div.style.top = (parseInt(Top) - 8.5) + "px";
            }
            else {
                div.style.top = (parseInt(Top) - 5.5) + "px";
            }
            document.getElementById("div_dropdown_reports").style.display = 'none';
            document.getElementById("div_dropdown_orders").style.display = 'none';
            document.getElementById("div_dropdown_inventry").style.display = 'none';
            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
            document.getElementById("div_dropdown_purchase").style.display = 'none';
            document.getElementById("div_dropdown_crm").style.display = 'none';
            document.getElementById("div_dropdown_jobs").style.display = 'none';
            document.getElementById("div_dropdown_estimate").style.display = 'none';
            document.getElementById("div_dropdown_invoice").style.display = 'none';
            document.getElementById("div_dropdown_campaign").style.display = 'none';
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            document.getElementById("div_SettingsMenu").style.display = 'block';
            //  document.getElementById("divForecastmodule").style.display = 'none';
            document.getElementById("div_dropdown_proofs").style.display = 'none';

            if (tabcolor != undefined || tabcolor != '') {
                var subdiv = document.getElementById('div_SettingsMenu');
                var liCount = subdiv.getElementsByTagName('li');
                for (var i = 0; i < liCount.length; i++) {
                    if (liCount[i] != null) {
                        liCount[i].style.backgroundColor = tabcolor;
                    }
                }
            }

            var notchagelbl = '';
            if (currentdiv != null) {
                var spancount = currentdiv.getElementsByTagName('span');
                if (spancount.length > 0) {
                    notchagelbl = spancount[0].id;
                    spancount[0].setAttribute("style", "color:" + headerforecolor);
                    //spancount[0].setAttribute("style", "color:white");
                }
            }

            var pnlMainMenu = document.getElementById('pnlmainmenu');
            var spncount = pnlMainMenu.getElementsByTagName('span');
            if (spncount.length > 0) {
                for (var i = 0; i < spncount.length; i++) {
                    if (spncount[i] != null) {
                        if (spncount[i].id.indexOf('ModuleName') != -1) {
                            if (notchagelbl != spncount[i].id) {
                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                    if (spncount[i] != undefined) {
                                        //spncount[i].setAttribute("style", "color:black;");
                                        spncount[i].style.forecolor = headerforecolor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "settings/settings.aspx" || scrn == "StoreSettings/StoreSettings.aspx") {
        if (name == name) {
            var div = document.getElementById('div_settings');
            if (name == 'navbar') {
                div.style.left = (parseInt(Left) - parseInt("246px")) + "px";
            }
            else {
                div.style.left = (parseInt(Left) - parseInt("251px")) + "px";
            }
            div.style.top = (parseInt(Top) - parseInt("4px")) + "px";
            // document.getElementById("div_settings").style.display = 'block';
            //document.getElementById("div_settings").style.position = "absolute";
            //document.getElementById("div_settings").style.marginTop = "25px";   commented by ved (new requirement)
            document.getElementById("div_ProductCatalogue").style.display = 'none';
            // document.getElementById("divForecastmodule").style.display = 'none';
        }
    }
    else if (scrn == "documents/document.aspx") {
        var notchagelbl = '';
        if (currentdiv != null) {
            var spancount = currentdiv.getElementsByTagName('span');
            if (spancount.length > 0) {
                notchagelbl = spancount[0].id;
                spancount[0].setAttribute("style", "color:" + headerforecolor);
                //spancount[0].setAttribute("style", "color:white");
            }
        }

        var pnlMainMenu = document.getElementById('pnlmainmenu');
        var spncount = pnlMainMenu.getElementsByTagName('span');
        if (spncount.length > 0) {
            for (var i = 0; i < spncount.length; i++) {
                if (spncount[i] != null) {
                    if (spncount[i].id.indexOf('ModuleName') != -1) {
                        if (notchagelbl != spncount[i].id) {
                            if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                if (spncount[i] != undefined) {
                                    //spncount[i].setAttribute("style", "color:black;");
                                    spncount[i].style.forecolor = headerforecolor;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else if (scrn == "eprintdamlink.aspx") {
        var notchagelbl = '';
        if (currentdiv != null) {
            var spancount = currentdiv.getElementsByTagName('span');
            if (spancount.length > 0) {
                notchagelbl = spancount[0].id;
                spancount[0].setAttribute("style", "color:" + headerforecolor);
                //spancount[0].setAttribute("style", "color:white");
            }
        }

        var pnlMainMenu = document.getElementById('pnlmainmenu');
        var spncount = pnlMainMenu.getElementsByTagName('span');
        if (spncount.length > 0) {
            for (var i = 0; i < spncount.length; i++) {
                if (spncount[i] != null) {
                    if (spncount[i].id.indexOf('ModuleName') != -1) {
                        if (notchagelbl != spncount[i].id) {
                            if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                if (spncount[i] != undefined) {
                                    //spncount[i].setAttribute("style", "color:black;");
                                    spncount[i].style.forecolor = headerforecolor;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    //    if (scrn == "forecast/forecast.aspx") {
    //        if (name == name) {
    //            var div = document.getElementById('divDrpdwn');
    //            div.style.left = Left;
    //            if (name == 'navbar') {
    //                div.style.top = (parseInt(Top) - 8.5) + "px";
    //            }
    //            else {
    //                div.style.top = (parseInt(Top) - 5.5) + "px";
    //            }
    //            var val = ucfirst(screenname);
    //            document.getElementById("div_dropdown_estimate").style.display = 'none';
    //            document.getElementById("ctl00_header1_lblEstscreenname").innerHTML = SpecialDecode(val);
    //            document.getElementById("div_dropdown_jobs").style.display = 'none';
    //            document.getElementById("div_dropdown_crm").style.display = 'none';
    //            document.getElementById("div_dropdown_purchase").style.display = 'none';
    //            document.getElementById("div_dropdown_deliverynotes").style.display = 'none';
    //            document.getElementById("div_dropdown_invoice").style.display = 'none';
    //            document.getElementById("div_dropdown_inventry").style.display = 'none';
    //            document.getElementById("div_dropdown_orders").style.display = 'none';
    //            document.getElementById("div_dropdown_reports").style.display = 'none';
    //            document.getElementById("div_dropdown_campaign").style.display = 'none';
    //            document.getElementById("div_ProductCatalogue").style.display = 'none';
    //            document.getElementById("div_SettingsMenu").style.display = 'none';
    //          //  document.getElementById("divForecastmodule").style.display = 'block';

    //            if (tabcolor != undefined || tabcolor != '') {
    //                var subdiv = document.getElementById('divForecastmodule');
    //                var liCount = subdiv.getElementsByTagName('li');
    //                for (var i = 0; i < liCount.length; i++) {
    //                    if (liCount[i] != null) {
    //                        liCount[i].style.backgroundColor = tabcolor;
    //                    }
    //                }
    //            }

    //            var notchagelbl = '';
    //            if (currentdiv != null) {
    //                var spancount = currentdiv.getElementsByTagName('span');
    //                if (spancount.length > 0) {
    //                    notchagelbl = spancount[0].id;
    //                    spancount[0].setAttribute("style", "color:" + headerforecolor);
    //                    //spancount[0].style.forecolor = headerforecolor;
    //                }
    //            }

    //            var pnlMainMenu = document.getElementById('pnlmainmenu');
    //            var spncount = pnlMainMenu.getElementsByTagName('span');
    //            if (spncount.length > 0) {
    //                for (var i = 0; i < spncount.length; i++) {
    //                    if (spncount[i] != null) {
    //                        if (spncount[i].id.indexOf('ModuleName') != -1) {
    //                            if (notchagelbl != spncount[i].id) {
    //                                if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
    //                                    if (spncount[i] != undefined) {
    //                                        //spncount[i].setAttribute("style", "color:black;");
    //                                        spncount[i].style.forecolor = headerforecolor;
    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    else if (screenname.toLowerCase() == "home") {
        var notchagelbl = '';
        if (currentdiv != null) {
            var spancount = currentdiv.getElementsByTagName('span');
            if (spancount.length > 0) {
                notchagelbl = spancount[0].id;
                spancount[0].setAttribute("style", "color:" + headerforecolor);
                //spancount[0].setAttribute("style", "color:white");
                //                spancount[0].setAttribute("style", "text-transform:capitalize");
                //                //ved
            }
        }

        var pnlMainMenu = document.getElementById('pnlmainmenu');
        var spncount = pnlMainMenu.getElementsByTagName('span');
        if (spncount.length > 0) {
            for (var i = 0; i < spncount.length; i++) {
                if (spncount[i] != null) {
                    if (spncount[i].id.indexOf('ModuleName') != -1) {
                        if (notchagelbl != spncount[i].id) {
                            if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                if (spncount[i] != undefined) {
                                    // spncount[i].setAttribute("style", "color:black;");
                                    spncount[i].style.forecolor = headerforecolor;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    else if (screenname.toLowerCase() == "dashboard") {
        var notchagelbl = '';
        if (currentdiv != null) {
            var spancount = currentdiv.getElementsByTagName('span');
            if (spancount.length > 0) {
                notchagelbl = spancount[0].id;
                spancount[0].setAttribute("style", "color:" + headerforecolor);
                //spancount[0].setAttribute("style", "color:white");
            }
        }

        var pnlMainMenu = document.getElementById('pnlmainmenu');
        var spncount = pnlMainMenu.getElementsByTagName('span');
        if (spncount.length > 0) {
            for (var i = 0; i < spncount.length; i++) {
                if (spncount[i] != null) {
                    if (spncount[i].id.indexOf('ModuleName') != -1) {
                        if (notchagelbl != spncount[i].id) {
                            if (spncount[i].id.indexOf('ActiveModuleName') == -1) {
                                if (spncount[i] != undefined) {
                                    // spncount[i].setAttribute("style", "color:black;");
                                    spncount[i].style.forecolor = headerforecolor;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
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

function showThisDiv(id) {
    document.getElementById(id).style.display = "block";

    var stylesheet = document.createElement('style');
    stylesheet.innerHTML = ".navwrappermouseover {background: " + tabcolor + "; }"; // color: White;
    document.body.appendChild(stylesheet);

    if (dynamicscreenName != '') {
        var maintab = document.getElementById(dynamicscreenName);
        if (maintab != null) {
            maintab.className = "navwrappermouseover";
            var spancount = maintab.getElementsByTagName('span');
            if (spancount.length > 0) {
                spancount[0].setAttribute("style", "color:" + headerforecolor);
                return;
            }
        }
    }
}

function HideThisDiv(id) {
    document.getElementById(id).style.display = "none";

    if (dynamicscreenName != '') {
        var maintab = document.getElementById(dynamicscreenName);
        if (maintab != null) {
            maintab.className = "navwrappermouseout";
            var spancount = maintab.getElementsByTagName('span');
            if (spancount.length > 0) {
                spancount[0].setAttribute("style", "color:black");
                return;
            }
        }
    }
}
//-------------------Section for Js functions used for header ends ------------------------------------------ //





/*************************** slide out javascript to right from hovemenu ************* added on 19-11-2012**********/


var ids = new Array("stmenu") //Enter id(s) of UL menus, separated by commas                
var submenuoffset = -2 //Offset of submenus from main menu. Default is -2 pixels.

function createmenu() {
    for (var i = 0; i < ids.length; i++) {
        var ultaglist = '';
        try {
            ultaglist = document.getElementById(ids[i]).getElementsByTagName("ul")
        }
        catch (err) {
        }
        for (var t = 0; t < ultaglist.length; t++) {
            ultaglist[t].parentNode.onmouseover = function () {
                this.getElementsByTagName("ul")[0].style.left = this.parentNode.offsetWidth + submenuoffset + "px";
                this.getElementsByTagName("ul")[0].style.display = "block";
            }
            ultaglist[t].parentNode.onmouseout = function () {
                this.getElementsByTagName("ul")[0].style.display = "none"
            }
        }
    }
}
if (window.addEventListener)
    window.addEventListener("load", createmenu, false)
else if (window.attachEvent)
    window.attachEvent("onload", createmenu)


function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        alert("Enter numbers only");
        return false;
    }

    return true;
}


function Commavalidation(evt) {
    var charCode = (evt.which) ? evt.which : window.event.keyCode;

    if (charCode <= 13) {
        return true;
    }
    else {
        var keyChar = String.fromCharCode(charCode);
        //var re = /[a-zA-Z0-9@#$%&*!~^_()?,.{}<>]/
        var re = /[0-9.]/
        return re.test(keyChar);
    }
}

function CheckChanged() {
    var frm = document.forms[0];
    var boolAllChecked;
    boolAllChecked = true;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id') != -1)
            if (e.checked == false && (!e.disabled)) {
                boolAllChecked = false;
                break;
            }
    }
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkAll') != -1) {
            if (boolAllChecked == false) {
                e.checked = false;
                //alert(e.name);
            }
            else
                e.checked = true;
            break;
        }
    }
}

function ChangeHidValue(ID, hdnID) {
    alert(id);
    alert(hdnID);
    var chkAppSys = document.getElementById(ID);
    var hdnPendCount = document.getElementById(hdnID);
    if (!chkAppSys.checked) {
        hdnPendCount.value = '0';
    }
}


function MultipleEmailAddressesValidation(id, spnMessage) {
    var email = document.getElementById(id).value;
    if (email.trim() != '') {
        var result = email.split(",");
        var check = true;
        for (var i = 0; i < result.length; i++) {
            if (!EmailRegularExpression(result[i])) {
                check = false;
            }
        }
        if (check) {
            document.getElementById(spnMessage).style.display = "none";
            return true;
        }
        else {
            document.getElementById(spnMessage).style.display = "block";
            return false;
        }
    }
    else {
        document.getElementById(spnMessage).style.display = "none";
        return true;
    }
}

function EmailRegularExpression(email) {
    var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var chk = regex.test(email.trim());
    return chk; //(regex.test(email)) ? true : false;
}


function showInventoryToolsDiv() {
    // var Browser = GetBrowserName();
    //    if (Browser.toLowerCase().indexOf('safari') == -1) {
    //        var stylesheet = document.createElement('style');
    //        stylesheet.innerHTML = "nav ul ul li a {background: none;}";
    //        document.body.appendChild(stylesheet);
    //    }
}

function GetBrowserName() {
    var ua = navigator.userAgent, tem,
    M = ua.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || [];
    if (/trident/i.test(M[1])) {
        tem = /\brv[ :]+(\d+)/g.exec(ua) || [];
        return 'IE ' + (tem[1] || '');
    }
    if (M[1] === 'Chrome') {
        tem = ua.match(/\bOPR\/(\d+)/)
        if (tem != null) return 'Opera ' + tem[1];
    }
    M = M[2] ? [M[1], M[2]] : [navigator.appName, navigator.appVersion, '-?'];
    if ((tem = ua.match(/version\/(\d+)/i)) != null) M.splice(1, 1, tem[1]);
    return M.join(' ');
}

function ShowSignUpDialog() {
    $('#overlay').fadeIn(300);  
    $("#ctl00_Button1233").val("Sign Up")
    $('#close').click(function () {
        document.getElementById('ctl00_Button1233').style.display = 'block';
        document.getElementById('div_loading_btnsaveSignup').style.display = 'none';
        $('#overlay').fadeOut(300);
        $('#overlay input').val('')
    });


}


function ValidateLogin() {

    var txtEmail = document.getElementById("signInemail");
    var txtPwd = document.getElementById("signIn-pass");

    if (txtEmail.value.length == 0) {
        document.getElementById("login-error").style.visibility = "visible";
        document.getElementById("login-error").innerHTML = "Please enter your email address";
        txtEmail.className = 'txtEmail';
        return false;
    }
    else if (txtEmail.value.length > 0 && echeck(txtEmail.value) == false) {
        document.getElementById("login-error").innerHTML = "Please enter a valid email";
        document.getElementById("login-error").style.visibility = "visible";
        txtEmail.className = 'txtEmail';
        return false;
    }
    else if (txtPwd.value.length == 0) {
        document.getElementById("login-error").innerHTML = " Please enter a password";
        document.getElementById("login-error").style.visibility = "visible";
        txtPwd.className = 'txtEmail';
        txtEmail.className = 'txtvalidemail';
        return false;
    }

    txtEmail.className = 'txtvalidemail';
    txtPwd.className = 'txtvalidemail';

    document.getElementById("forgot-error").style.visibility = "hidden";
    document.getElementById("login-error").style.visibility = "hidden";
    document.getElementById("signUp-error").style.visibility = "hidden";
    document.getElementById("agent-error").style.visibility = "hidden";

    CheckLogin(txtEmail.value, txtPwd.value, accid, AccountType);
    //loadinglogimg('divlogin', 'divlgimg');
    return false;
}

function validateaccount() {

    debugger;

    $(document).on({
        ajaxStart: function () {
            document.getElementById('div_loading_btnsaveSignup').style.display = 'block';
            document.getElementById('ctl00_ContentPlaceHolder1_Button1233').style.display = 'none';
        },
        ajaxStop: function () {
            document.getElementById('ctl00_ContentPlaceHolder1_Button1233').style.display = 'block';
            document.getElementById('div_loading_btnsaveSignup').style.display = 'none';
        }
    });



    var txtuname = document.getElementById("txtuname");
    var txtlname = document.getElementById("txtlname");
    var txtsignupEmail = document.getElementById("txtsignupEmail");
    var txtupass = document.getElementById("txtupass");
    var txtcpass = document.getElementById("txtcpass");
    var txtcompanyname = document.getElementById("txtcompanyname");

    txtcpass.className = 'txtvalidLCP';
    txtupass.className = 'txtvalidFLPCCN';
    txtsignupEmail.className = 'txtvalidemail';
    txtuname.className = 'txtvalidFLPCCN';
    txtlname.className = 'txtvalidLCP';

    if (txtuname.value.length == 0) {
        document.getElementById("signUp-error").style.visibility = "visible";
        document.getElementById("signUp-error").innerHTML = "Please enter your first name";
        txtuname.className = 'txtFLPCCN';
        return false;
    }
    else if (txtlname.value.length == 0) {
        document.getElementById("signUp-error").style.visibility = "visible";
        document.getElementById("signUp-error").innerHTML = "Please enter your last name";
        txtlname.className = 'txtLCP';
        return false;
    }
    else if (txtsignupEmail.value.length == 0) {
        document.getElementById("signUp-error").style.visibility = "visible";
        document.getElementById("signUp-error").innerHTML = "Please enter your email address";
        txtsignupEmail.className = 'txtEmail';
        return false;
    }
    else if (txtsignupEmail.value.length > 0 && echeck(txtsignupEmail.value) == false) {
        document.getElementById("signUp-error").style.visibility = "visible";
        document.getElementById("signUp-error").innerHTML = "Please enter a valid email";
        txtsignupEmail.className = 'txtEmail';
        return false;
    }
    else if (txtupass.value.length == 0) {
        document.getElementById("signUp-error").innerHTML = "Please enter a password";
        document.getElementById("signUp-error").style.visibility = "visible";
        txtupass.className = 'txtFLPCCN';
        return false;
    }
    else if (txtcpass.value.length == 0) {
        document.getElementById("signUp-error").innerHTML = "Please enter confirm password";
        document.getElementById("signUp-error").style.visibility = "visible";
        txtcpass.className = 'txtLCP';
        return false;
    }
    else if (txtcpass.value.length > 0 && txtupass.value.length > 0 && txtcpass.value != txtupass.value) {
        document.getElementById("signUp-error").innerHTML = "Passwords do not match";
        document.getElementById("signUp-error").style.visibility = "visible";
        txtcpass.className = 'txtLCP';
        txtupass.className = 'txtFLPCCN';
        return false;
    }

    //document.getElementById("forgot-error").style.visibility = "hidden";
    //document.getElementById("login-error").style.visibility = "hidden";
    //document.getElementById("signUp-error").style.visibility = "hidden";
    //document.getElementById("agent-error").style.visibility = "hidden";

    //var chk = document.getElementById("ctl00_chkAddEmilDmc");
    var AddEmilToDmc = true;
    //if (chk.checked) {
    //    AddEmilToDmc = 'true';
    //}
    //else {
    //    AddEmilToDmc = 'false';
    //}

    //var AG = IsValidAgentCode;
    //var LoginAgentCode = LoginOrgAgentCode;
    //var agentcode = '';
    //if (AG.toLowerCase() == 'true') {
    //    agentcode = LoginAgentCode;
    //}
    Accountcreate(AddEmilToDmc, txtcompanyname.value, txtsignupEmail.value, txtuname.value, txtlname.value, txtupass.value, 0);
    //loadinglogimg('divsu', 'divsuimg');
    return false;
}

function Accountcreate(AddEmilToDmc, txtcompanyname, txtsignupEmail, txtuname, txtlname, txtupass, agentcode) {

    var strSitePath = '';
    var aa = window.location.href.split('/');
    strSitePath = aa[0] + '//' + aa[2] + "/";

    $.ajax({
        type: "POST",
        url: strSitePath + "estimates/estimate_view.aspx/accountcreate",
        data: accountvalue(AddEmilToDmc, txtcompanyname, txtsignupEmail, txtuname, txtlname, txtupass, agentcode),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: details,
        error: ServiceFailed
    });
    return false;
}

function accountvalue(AddEmilToDmc, txtcompanyname, txtsignupEmail, txtuname, txtlname, txtupass, agentcode) {
    var FinalString = ' { "AddEmilToDmc" : "' + AddEmilToDmc + '" , "txtcompanyname" : "' + txtcompanyname + '" , "txtsignupEmail" : "' + txtsignupEmail + '" , "txtuname" : "' + txtuname + '" , "txtlname" : "' + txtlname + '" , "txtupass" : "' + txtupass + '" , "agentcode" : "' + agentcode + '"} '
    return FinalString;
}

function details(data) {
    var result = data.d;

    if (result == "OK") {
        alert("Customer Created");
        location.reload();
    } else if (result == "exists") {
        alert("Email already exists");
    } else if (true) {
        return false;
    }



}