

jQuery(document).ready(function () {
    jQuery(".rollover").hover(function () {
        this.src = this.src.replace("_u", "_d");
    },
        function () {
            this.src = this.src.replace("_d", "_u");
        });
});


//---------------------- B2B -----------------------------------------
function showAccount() {
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_account").style.display = "block";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_B2B_Button").style.display = "none";
    return false;
}

function LoadB2BTabNew(val, URL) {

    if (val == 1) {
        document.getElementById("ctl00_ContentPlaceHolder1_Client_div_account").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_div_B2B_Link").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_lbl_b2beStoreLink").innerHTML = WebStorePathB2B.replace('login.aspx', '') + URL;
        document.getElementById("lnk_b2beStoreLink").href = WebStorePathB2B.replace('login.aspx', '') + "404.aspx?AccountName=" + URL;
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_Client_div_account").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_div_B2B_Button").style.display = "block";
    }
}
//---------------------- B2B -----------------------------------------




//---------------------- CLIENTS -----------------------------------------

function forDelete() {

    if (AccountID != 0) {
        if (window.confirm("Are you sure you want to delete this Client? If you delete this customer record you will also delete the eStore account (B2B only) that is linked to it along with the customers order history and product catelogue.")) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if (window.confirm("Are you sure you want to delete this Client?")) {
            return true;
        }
        else {
            return false;
        }
    }
}

function forDeleteforCRM(companytype) {
    if (companytype == "supplier") {
        if (window.confirm("You are about to delete the complete company record. This will also delete the company contacts, addresses etc.")) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if (window.confirm("You are about to delete the complete company record. This will also delete the company eStore, the product catalogue, company contacts, addresses etc.")) {
            return true;
        }
        else {
            return false;
        }
    }
}

//---------------------- CONTACTS -----------------------------------------
function checkAll_new(checkAllBox) {
    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Contact') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }

    }
}

function show() {

    document.getElementById("img_actionsHide").style.display = "block";

    document.getElementById("img_actionsShow").style.display = "none";
    document.getElementById("div_chk").style.border = "inset 1px";
    document.getElementById("div_chk").style.background = "Gray";

    document.getElementById("div_popupAction").style.display = "block";

}

function hide() {

    document.getElementById("img_actionsHide").style.display = "none";
    document.getElementById("img_actionsShow").style.display = "block";

    document.getElementById("div_chk").style.border = "outset 1px";
    document.getElementById("div_chk").style.background = "";

    document.getElementById("div_popupAction").style.display = "none";

}


function addNewcontact(val, type, clientid, contactid) {
    debugger
    if (type == 'add') {
        var wnd = window.radopen(sitePath + "contact/contact_add.aspx?clientid=" + clientid + "&type=" + CompanyType + "&pg=" + pg + "&IsAddMode=yes&CustomerName=" + CompanyCusName, 'contacts', '1000', '500');
        wnd.setSize(1000, 600);
        wnd.center();
        var x = wnd.getWindowBounds().x;
        var y = wnd.getWindowBounds().y;
        if (y < 0) {
            wnd.moveTo(x, 57);
        }
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }
}

function CheckOne_new(val) {
    var Counter = 0;
    var frm = document.forms[0];
    var Contact_IDs = '';

    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Contact') != -1) {
            if (!e.disabled) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                    Contact_IDs = Contact_IDs + frm[i].value + ",";
                }
            }
        }
    }

    document.getElementById("ctl00_ContentPlaceHolder1_Client_hdn_ContactIDs").value = Contact_IDs;

    if (val == 'default') {
        if (Number(Counter) == 0) {
            alert("Please check at least one row to set as default contact");
            return false;
        }
        else if (Number(Counter) > 1) {
            alert("Please check only one row to set as default contact");
            return false;
        }
        else {
            document.cookie = "RadListBoxContactsValue=set default";
            __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ContactsRadList');
        }
    }
    else if (val == 'delete') {
        if (Number(Counter) == 0) {
            alert("Please check at least one row to delete");
            return false;
        }
        else if (Number(Counter) > 0) {
            if (confirm("Are you sure you want to delete this record(s)?")) {
                document.cookie = "RadListBoxContactsValue=delete";
                __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ContactsRadList');
            }
            else {
                return false;
            }
        }
    }
    else if (val == 'loginremainder') {
        if (Number(Counter) == 0) {
            alert("Please check at least one row to send login remainder");
            return false;
        }
    }
    else if (val == 'resetpassword') {
        if (Number(Counter) == 0) {
            alert("Please check at least one row to bulk reset password");
            return false;
        }
    }
    else if (val == 'activate') {
        if (Number(Counter) == 0) {
            alert("Please check at least one row to activate");
            return false;
        }
        else {
            document.cookie = "RadListBoxContactsValue=activate";
            __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ContactsRadList');
        }
    }
    else if (val == 'deactivate') {
        if (Number(Counter) == 0) {
            alert("Please check at least one row to deactivate");
            return false;
        }
        else {
            document.cookie = "RadListBoxContactsValue=deactivate";
            __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ContactsRadList');
        }
    }
    else if (val == 'spendlimituser') {  ////Ticket Id : 13951
        if (Number(Counter) == 0) {
            alert("Please check at least one row to apply spend limit");
            return false;
        }
        else if (Number(Counter) > 0) {
            var ids = Contact_IDs.value;
            var RadWindow_Paid = window.radopen(strSitepath + "common/SpentLimit.aspx?type=user&IDs=" + Contact_IDs + "", '800', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            RadWindow_Paid.setSize(500, 300);
            RadWindow_Paid.center();
        }
    }
    else if (val == 'spendlimitdeactivate') {  ////Ticket Id : 14441
        if (Number(Counter) == 0) {
            alert("Please check at least one row to deactivate spend limit");
            return false;
        }
        else {
            document.cookie = "RadListBoxContactsValue=spendlimitdeactivate";
            __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ContactsRadList');
            document.getElementById("div_Load").style.display = "block";
        }

    }

    else if (val == 'activatestorecredit') {  ////Ticket Id : 13951. 7-26-21 Amin
        if (Number(Counter) == 0) {
            alert("Please check at least one row to apply store credit");
            return false;
        }
        else if (Number(Counter) > 0) {
            var ids = Contact_IDs.value;
            var RadWindow_Paid = window.radopen(strSitepath + "common/StoreCredit.aspx?type=user&IDs=" + Contact_IDs + "", '800', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            RadWindow_Paid.setSize(500, 300);
            RadWindow_Paid.center();
        }
    }

    else if (val == 'deactivatestorecredit') {  ////Ticket Id : 13951. 7-26-21 Amin
        if (Number(Counter) == 0) {
            alert("Please check at least one row to deactivate store credit");
            return false;
        }
        else {
            if (confirm('This will clear the remaining store credit amount from the selected user(s). Are you sure?')) {



                document.cookie = "RadListBoxContactsValue=deactivatestorecredit";
                __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ContactsRadList');
                document.getElementById("div_Load").style.display = "block";
            }
        }
    }

}

function imgbtnDelete_ClientClick(val, cnt) {

    document.getElementById("div_Load").style.display = "none";
    document.getElementById("DivBigLoadingImg").style.display = "none";


    if (val == 'address') {
        document.cookie = "CRMTabName=" + val;
        if (cnt != 0)
            return confirm("Are you sure you want to delete. This address may have been link with department AND/OR contacts. Do you want to proceed.");
        else
            return confirm("Are you sure you want to delete this record.");
    }
    else if (val == 'notes' || val == 'email' || val == 'contacts') {
        document.cookie = "CRMTabName=" + val;
        if (confirm("Are you sure you want to delete this record?")) {
            document.getElementById("div_Load").style.display = "block";
            return true;
        }
        else {
            return false;
        }
    }
}

function imgbtnDeleteNote_ClientClick(AttID, companyid, val, cnt) {
    if (val == 'notes') {
        document.cookie = "CRMTabName=" + val;
        if (confirm("Are you sure you want to delete this record?")) {
            document.getElementById("div_Load").style.display = "block";
            hdnAttachmentID.value = AttID
            __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_delete', '')
            return true;
        }
        else {
            return false;
        }
    }
    document.getElementById("div_Load").style.display = "none";
}
//---------------------- DEPARTMENT -----------------------------------------

var deptid = 0;
function imgbtnDeleteDept_ClientClick(val, id, count) {
    document.cookie = "DeleteImage=yes";
    document.cookie = "DeleteDeptID=" + id;
    document.cookie = "CRMTabName=" + val;
    deptid = id;

    document.getElementById("ctl00_ContentPlaceHolder1_Client_hdn_deptIDs").value = id + ',';

    if (count != 0) {
        if (confirm(The_department_has_a_contact_allocated_to_it)) {
            removeDept(deptid + ',');
            Show_DepartmentDelete();
            return false;
        }
        else {
            return false;
        }
    }
    else {
        if (confirm("Are you sure you want to delete this record(s)?")) {
            return true;
        }
        else {
            return false;
        }
    }
}

function setAsDefault(ID, val) {

    return true;
}

function checkAll_new_Dept(checkAllBox_Dept) {
    var frm = document.forms[0];
    var ChkState = checkAllBox_Dept.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Department') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
    }
}

function show_Dept() {

    document.getElementById("img_actionsHide_Dept").style.display = "block";
    document.getElementById("img_actionsShow_Dept").style.display = "none";

    document.getElementById("div_chk_Dept").style.border = "inset 1px";
    document.getElementById("div_chk_Dept").style.background = "Gray";

    document.getElementById("div_popupActionDepartment").style.display = "block";

}

function hide_Dept() {
    document.getElementById("img_actionsHide_Dept").style.display = "none";
    document.getElementById("img_actionsShow_Dept").style.display = "block";

    document.getElementById("div_chk_Dept").style.border = "outset 1px";
    document.getElementById("div_chk_Dept").style.background = "";

    document.getElementById("div_popupActionDepartment").style.display = "none";
}

var NoOFCnt = 0;
var cnt = 0;
var IDLenght = 0;
var ActionType = '';
var Counter = 0;

function CheckOne_new_Dept(val) {
    ActionType = val;
    var frm = document.forms[0];
    var IDs = '';

    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Department') != -1) {
            if (!e.disabled) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                    IDs = IDs + frm[i].value + ",";
                }
            }
        }
    }

    document.getElementById("ctl00_ContentPlaceHolder1_Client_hdn_deptIDs").value = IDs;
    if (val == 'delete_dept') {
        if (IDs != '') {
            var DeptID = IDs.split(',');
            NoOFCnt = 0;
            cnt = 0;
            IDLenght = DeptID.length - 1;
            if (window.confirm('Are you sure you want to delete?')) {
                for (var i = 0; i < DeptID.length - 1; i++) {
                    AutoFill.GetNoOFContactForDept(CompanyID, UserID, ClientID, DeptID[i], GetCounts, onTimeout, onError);
                }
                return true;
            }
            else {
                return false;
            }
        }
    }
    document.cookie = "DeptIDs=" + IDs;
    if (val == 'spendlimitdept') {     //Ticket Id : 13951
        if (IDs == "") {
            alert("Please check at least one row to apply spend limit");
            return false;
        }
        else if (Number(Counter) > 0) {
            var RadWindow_Paid = window.radopen(strSitepath + "common/SpentLimit.aspx?type=dept&IDs=" + IDs + "", '800', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            RadWindow_Paid.setSize(500, 300);
            RadWindow_Paid.center();
        }
    }
    if (val == 'spendlimitdeactivate') {     //Ticket Id : 14441
        if (IDs == "") {
            alert("Please check at least one row to deactivate spend limit");
            return false;
        }
        else {
            document.cookie = "RadListBoxDeptValue=spendlimitdeactivate";
            __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_DeptRadList');
            document.getElementById("div_Load").style.display = "block";
        }
    }
    removeDept(IDs);
}

function LoadContactPanel(Type) {
    var pw = window.parent;
    pw.SetTabs(Type, 'yes');
    return false;
}
function GetCounts(result) {
    NoOFCnt += result;
    cnt++;
    if (cnt == IDLenght) {
        if (ActionType == 'default_dept') {
            if (Number(Counter) == 0) {
                alert("Please check at least one row to set as default contact");
                return false;
            }
            else if (Number(Counter) > 1) {
                alert("Please check only one row to set as default contact");
                return false;
            }
            else {
                document.cookie = "RadListBoxDeptValue=set default";
                __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_DeptRadList');
                return false;
            }
        }
        else if (ActionType == 'delete_dept') {
            if (Number(Counter) == 0) {
                alert("Please check at least one row to delete");
                return false;
            }
            else {
                if (NoOFCnt != 0) {
                    if (cnt == IDLenght) {
                        if (confirm("The selected department have active contacts. Kindly assign the contacts to another department before deleting this department") == true) {
                            document.cookie = "RadListBoxDeptValue=delete";
                            document.cookie = "DeleteImage=no";
                            Show_DepartmentDelete();
                            return false;
                        }
                    }
                }
                else {
                    document.cookie = "RadListBoxDeptValue=delete";
                    __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_DeptRadList');
                    return false;
                }
            }
        }
    }
}

function onTimeout(request, context) { }
function onError(objError) { }

function removeDept(IDs) {
    var ddl_deptList = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddl_deptList");
    var deptID = IDs.split(',');
    for (var i = 0; i < deptID.length - 1; i++) {
        for (var j = 0; j < ddl_deptList.length; j++) {
            if (deptID[i] == ddl_deptList[j].value) {
                ddl_deptList.remove(j);
            }
        }
    }
}

function Show_DepartmentDelete() {
    showDivPopupCenter('div_DepartmentDelete', '220');
    return false;
}


function addNewDepartment(val, type, clientid, contactid) {
    if (type == 'add') {
        var wnd = window.radopen(sitePath + "common/common_popup.aspx?type=moreDept&clientid=" + clientid + "&mode=add&pg=" + pg + "&CustomerName=" + CompanyCusName + "&companytype=" + CompanyType + "&Pgtype=" + pg + "&IsAddMode=yes", 'dept', '1000', '610');
        wnd.setSize(1000, 600);
        wnd.center();
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }
}

function editdept(val, type, id, clientid, editdept) {

    editdept = editdept.toLowerCase();
    if (editdept == 'false') {
        alert("You are not authorised to view this page");
        return false;
    }

    var wnd = window.radopen(sitePath + "common/common_popup.aspx?type=moreDept&mode=edit&DeptID=" + id + "&ClientID=" + clientid + "&CustomerName=" + CompanyCusName + "&pg=Client&" + "companytype=" + CompanyType, 'dept', '1000', '610');
    wnd.setSize(1000, 600);
    wnd.center();
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}


//---------------------- ADDRESS -----------------------------------------
function checkAll_new_Address(checkAllBox_Address) {
    var frm = document.forms[0];
    var ChkState = checkAllBox_Address.checked;

    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Address') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
    }
}

function show_Address() {

    document.getElementById("img_actionsHide_Address").style.display = "block";
    document.getElementById("img_actionsShow_Address").style.display = "none";

    document.getElementById("div_chk_Address").style.border = "inset 1px";
    document.getElementById("div_chk_Address").style.background = "Gray";

    document.getElementById("div_popupActionAddress").style.display = "block";
}

function hide_Address() {

    document.getElementById("img_actionsHide_Address").style.display = "none";
    document.getElementById("img_actionsShow_Address").style.display = "block";

    document.getElementById("div_chk_Address").style.border = "outset 1px";
    document.getElementById("div_chk_Address").style.background = "";

    document.getElementById("div_popupActionAddress").style.display = "none";

}

var NoOFCnt_Address = 0;
var cnt_Address = 0;
var IDLenght_Address = 0;
var ActionType_Address = '';
var Counter_Address = 0;


function CheckOne_new_Address(val) {

    ActionType_Address = val;
    var frm = document.forms[0];
    var IDs = '';

    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Address') != -1) {
            if (!e.disabled) {
                if (e.checked) {
                    Counter_Address = Number(Counter_Address) + 1;
                    IDs = IDs + frm[i].value + ",";
                }
            }
        }
    }

    document.getElementById("ctl00_ContentPlaceHolder1_Client_hdn_AddressIDs").value = IDs;

    if (IDs != '') {
        var AddressID = IDs.split(',');
        NoOFCnt_Address = 0; cnt_Address = 0;
        IDLenght_Address = AddressID.length - 1;
        if (window.confirm('Are you sure you want to delete?')) {
            for (var i = 0; i < AddressID.length - 1; i++) {
                AutoFill.GetNoOFCountForAddress(CompanyID, AddressID[i], UserID, Get_Counts, onTimeout, onError);
            }
            return true;
        }
        else {
            return false;
        }
    }
}

function Get_Counts(result) {
    NoOFCnt_Address += result;
    cnt_Address++;

    if (cnt_Address == IDLenght_Address) {
        if (ActionType_Address == 'delete_address') {
            if (Number(Counter_Address) == 0) {
                alert("Please check at least one row to delete");
                return false;
            }
            else {
                if (NoOFCnt_Address != 0) {
                    if (cnt_Address == IDLenght_Address) {
                        if (confirm("Are you sure you want to delete. These address may have been link with department AND/OR contacts. Do you want to proceed") == true) {
                            document.cookie = "RadListBoxAddressValue=delete";
                            __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_AddressRadList');
                        }
                        else {
                            return false;
                        }
                    }
                }
                else {
                    document.cookie = "RadListBoxAddressValue=delete";
                    __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_AddressRadList');
                }
            }
        }
        else if (ActionType_Address == 'postbox_address') {
            if (Number(Counter_Address) == 0) {
                alert("Please check at least one row to set as post box address");
                return false;
            }
            else if (Number(Counter_Address) > 1) {
                alert("Please check only one row to set as post box address");
                return false;
            }
            else {
                document.cookie = "RadListBoxAddressValue=set_postbox";
                __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_AddressRadList');
            }
        }
    }
}

function editAddress(val, type, id, clientid, editAddress) {
    editAddress = editAddress.toLowerCase();
    if (editAddress == 'false') {
        alert("You are not authorised to view this page");
        return false;
    }

    var RadWindow_Paid = window.radopen(sitePath + "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=" + clientid + "&CustomerName=" + CompanyCusName + "&addressid=" + id + "&pg=Client" + "&companytype=" + CompanyType, 'address', '1000', '610');
    //Code added by Amin to fix popup issue
    RadWindow_Paid.setSize(1000, 600);
    RadWindow_Paid.center();
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}

function addNewAddress(val, type, clientid, contactid) {
    if (type == 'add') {
        var RadWindow_Paid = window.radopen(sitePath + "common/common_popup.aspx?type=moreaddress&clientid=" + clientid + "&mode=add&pg=Client" + "&CustomerName=" + CompanyCusName + "&companytype=" + CompanyType + "&Pgtype=Client", 'address', '1000', '610');
        //Code added by Amin to fix popup issue
        RadWindow_Paid.setSize(1000, 600);
        RadWindow_Paid.center();
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }
}

//---------------------- NOTES + ATTACHMENTS -----------------------------
function checkAll_new_Notes(checkAllBox_Notes) {
    var frm = document.forms[0];
    var ChkState = checkAllBox_Notes.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Notes') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
    }
}

function show_Notes() {

    document.getElementById("img_actionsHide_Notes").style.display = "block";
    document.getElementById("img_actionsShow_Notes").style.display = "none";

    document.getElementById("div_chk_Notes").style.border = "inset 1px";
    document.getElementById("div_chk_Notes").style.background = "Gray";

    document.getElementById("div_popupActionNotes").style.display = "block";

}

function hide_Notes() {

    document.getElementById("img_actionsHide_Notes").style.display = "none";
    document.getElementById("img_actionsShow_Notes").style.display = "block";

    document.getElementById("div_chk_Notes").style.border = "outset 1px";
    document.getElementById("div_chk_Notes").style.background = "";

    document.getElementById("div_popupActionNotes").style.display = "none";

}

function CheckOne_new_Notes(val) {
    var Counter = 0;
    var frm = document.forms[0];
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Notes') != -1) {
            if (!e.disabled) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }

    if (val == 'delete_notes') {
        if (Number(Counter) == 0) {
            alert("Please check at least one row to delete");
            return false;
        }
        else {
            //return confirm("Are you sure you want to delete this record(s)?");IsConfirmNotes.value = 1;IsConfirmNotes.value = 0;
            if (confirm("Are you sure you want to delete this record(s)?") == true) {
                document.cookie = "RadListBoxNotesValue=delete";
                __doPostBack('ctl00$ContentPlaceHolder1$Client$NotesSubSection$lnk_NotesRadList');
            }
            else {
                return false;
            }
        }
    }
}

function displayWindowattachmentadd() {

    RadWindowManager1 = window.radopen(sitePath + "common/Notes_Add_CRM.aspx?action=add&clientid=" + ClientID, 'window16', '0', '0');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    RadWindowManager1.setSize(900, 400);
    RadWindowManager1.center();
    return false;

}

function displayWindowattachmentedit(attachid) {

    window.radopen(sitePath + "common/Notes_Add_CRM.aspx?action=edit&clientid=" + ClientID + "&AttachmentID=" + attachid, 'window15', '0', '0');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    return false;

}

function getnotesvalue(result) {
    var str_note = result.split('µ');
    lblfileupload.innerHTML = "";
    subject = str_note[0];
    filename = str_note[1];
    ctl00_ContentPlaceHolder1_Client_NotesSubSection_txt_title.value = str_note[2];
    TextBox1.value = subject;
    hdn_FileName.value = filename;
    lblfileupload.innerHTML = "<a href=" + sitePath + "Document/" + CompanyID + "/" + filename + "' target='_blank'>" + filename + "</a>";
}

var flag = 0;
function postwith(to, p, B2B, B2C) {

    debugger;
    //    alert(to);
    //    alert(p);
    //    alert(B2B);
    //    alert(B2C);
    for (var k in p) {
        if (p[k] != "") {
            flag = 1;
        }
        else {
            flag = 0;
        }
    }

    if (flag == 1) {
        var myForm = document.createElement("form");
        myForm.method = "post";
        myForm.target = "_blank";
        for (var k in p) {
            var myInput = document.createElement("input");
            myInput.setAttribute("name", k);
            myInput.setAttribute("value", p[k]);
            myForm.appendChild(myInput);
        }

        if (to.toLowerCase() == "store") {
            myForm.action = B2C;
        }
        else {
            myForm.action = B2B;
        }

        document.body.appendChild(myForm);
        myForm.submit();
        document.body.removeChild(myForm);
    }
}


//---------------------- Email --------------------------------------------
function checkAll_new_Email(checkAllBox_Email) {
    var frm = document.forms[0];
    var ChkState = checkAllBox_Email.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Email') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
    }
}

function show_Email() {

    document.getElementById("img_actionsHide_Email").style.display = "block";
    document.getElementById("img_actionsShow_Email").style.display = "none";

    document.getElementById("img_actionsShow_Email").style.border = "inset 1px";
    document.getElementById("div_chk_Email").style.background = "Gray";

    document.getElementById("div_popupActionEmail").style.display = "block";
}

function hide_Email() {

    document.getElementById("img_actionsHide_Email").style.display = "none";
    document.getElementById("img_actionsShow_Email").style.display = "block";

    document.getElementById("img_actionsShow_Email").style.border = "outset 1px";
    document.getElementById("div_chk_Email").style.background = "";

    document.getElementById("div_popupActionEmail").style.display = "none";
}


function CheckOne_new_Email(val) {
    var Counter = 0;
    var frm = document.forms[0];
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_Email') != -1) {
            if (!e.disabled) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }

    if (val == 'delete_email') {
        if (Number(Counter) == 0) {
            alert("Please check at least one row to delete");
            return false;
        }
        else {
            //return confirm("Are you sure you want to delete this record(s)?");  IsConfirmEmail.value = 1; IsConfirmEmail.value = 0;
            if (confirm("Are you sure you want to delete this record(s)?") == true) {
                document.cookie = "RadListBoxEmailsValue=delete";
                __doPostBack('ctl00$ContentPlaceHolder1$Client$EmailsSubSection$lnk_EmailRadList');
            }
            else {
                return false;
            }
        }
    }
}

function PopupCenter_Email(val, mode, ClientID, PopupCenter_Email) {
    PopupCenter_Email = PopupCenter_Email.toLowerCase();
    if (PopupCenter_Email == 'false') {
        alert("You are not authorised to view this page");
        return false;
    }
    if (mode == 'edit') {
        window.radopen(sitePath + "common/htmlemail_detail.aspx?sl=" + val + "&CustomerName=" + CompanyCusName, 'emails', 1000, 620);
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        return false;
    }
    if (mode == 'add') {
        window.radopen(sitePath + "common/email_send_activityhistory.aspx?sectionid=" + ClientID + "&CustomerName=" + CompanyCusName + "&sectionname=client&type=Customer", 'emails', 1000, 620);
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        return false;
    }
}

function eStoreLogin(email, pwd) {

    Session("email") = email;
    Session("pwd") = pwd;
}


//---------------------- Estimates ---------------------------------------
function DisplaySummaryPopUp(EstimateID, typeval, IsFromWebStore, OrderID, DisplaySummaryPopUp, Job_Invoice_ID) {
    DisplaySummaryPopUp = DisplaySummaryPopUp.toLowerCase();

    if (DisplaySummaryPopUp == 'false') {
        alert("You are not authorised to view this page");
        return false;
    }

    if (typeval == 1) {
        var url = sitePath + "estimates/estimate_summary_reeng.aspx?estid=" + EstimateID
        window.open(url);
        return false;
    }
    else if (typeval == 2) {

        if (IsFromWebStore == "yes") {
            var url = sitePath + "jobs/job_order_summary.aspx?frm=view&estid=" + EstimateID + "&ordid=" + OrderID + "&jID=" + Job_Invoice_ID;
            window.open(url);
        }
        else {
            var url = sitePath + "jobs/job_summary_reeng.aspx?estid=" + EstimateID + "&jID=" + Job_Invoice_ID;
            window.open(url);
        }
        return false;
    }
    else if (typeval == 3) {
        if (IsFromWebStore == "yes") {
            var url = sitePath + "invoice/invoice_order_summary.aspx?frm=view&estid=" + EstimateID + "&ordid=" + OrderID + "&InvID=" + Job_Invoice_ID;
            window.open(url);
        }
        else {
            var url = sitePath + "invoice/invoice_summary_reeng.aspx?estid=" + EstimateID + "&InvID=" + Job_Invoice_ID;
            window.open(url);
        }
        return false;
    }
    else {
        var url = sitePath + "orders/order_summary.aspx?frm=view&ordid=" + OrderID + "&estid=" + EstimateID;
        window.open(url);
    }
}

function newPopup(val, newPopup) {
    debugger
    newPopup = newPopup.toLowerCase();
    //alert(newPopup);
    if (newPopup == 'false') {
        alert("You are not authorised to view this page");
        return false;
    }
    var ContactID = val;
    var RadWindow_Paid = window.radopen(sitePath + "contact/contact_add.aspx?action=edit&clientid=" + ClientID + "&contactid=" + ContactID + "&CustomerName=" + CompanyCusName + "&wintype=crm&type=" + CompanyType + "&pg=" + pg, 'contacts', '1000', '600');
    RadWindow_Paid.setSize(1000, 600);
    RadWindow_Paid.center();
    SetRadWindow('divrad', 'divBackGroundNew', '200'); return false;

}

function gettabs(value) {

    document.getElementById("DivBigLoadingImg").style.display = "none";

    document.cookie = "CRMTabName" + ClientID + "=" + value;

    if (value == 'activities') {
        //setTimeout("LoadImgStarts()", 1000);

        document.getElementById("ds00").style.display = "block";
        document.getElementById("div_Load").style.display = "block";
        //__doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ActivitiesTab', '');
        __doPostBack('ctl00$ContentPlaceHolder1$Client$ActivitiesSubSection$lnk_EstimatesTab', '');

        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Estimates.style.color = "Red";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_eStore.style.color = "black";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Jobs.style.color = "black";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Invoices.style.color = "black";

        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_EstimatesMain.style.display = "block";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_eStoreMain.style.display = "none";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_JobsMain.style.display = "none";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_InvoicesMain.style.display = "none";

    }

    else if (value == 'estore') {

        //setTimeout("LoadImgStarts()", 1000);

        document.getElementById("ds00").style.display = "block";
        document.getElementById("div_Load").style.display = "block";
        // __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ActivitiesTab', '');
        __doPostBack('ctl00$ContentPlaceHolder1$Client$ActivitiesSubSection$lnk_eStoreTab', '');

        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Estimates.style.color = "black";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_eStore.style.color = "Red";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Jobs.style.color = "black";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Invoices.style.color = "black";

        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_EstimatesMain.style.display = "none";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_eStoreMain.style.display = "block";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_JobsMain.style.display = "None";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_InvoicesMain.style.display = "none";

    }

    else if (value == 'jobs') {

        //setTimeout("LoadImgStarts()", 1000);

        document.getElementById("ds00").style.display = "block";
        document.getElementById("div_Load").style.display = "block";
        // __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ActivitiesTab', '');
        __doPostBack('ctl00$ContentPlaceHolder1$Client$ActivitiesSubSection$lnk_JobsTab', '');

        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Estimates.style.color = "black";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_eStore.style.color = "black";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Jobs.style.color = "Red";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Invoices.style.color = "black";

        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_EstimatesMain.style.display = "none";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_eStoreMain.style.display = "none";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_JobsMain.style.display = "block";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_InvoicesMain.style.display = "none";

    }
    else if (value == 'invoices') {

        //setTimeout("LoadImgStarts()", 1000);

        document.getElementById("ds00").style.display = "block";
        document.getElementById("div_Load").style.display = "block";
        //__doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_ActivitiesTab', '');
        __doPostBack('ctl00$ContentPlaceHolder1$Client$ActivitiesSubSection$lnk_InvoicesTab', '');

        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Estimates.style.color = "black";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_eStore.style.color = "black";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Jobs.style.color = "black";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_lbl_Invoices.style.color = "Red";

        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_EstimatesMain.style.display = "none";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_eStoreMain.style.display = "none";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_JobsMain.style.display = "none";
        ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_div_InvoicesMain.style.display = "block";

    }
}

//---------------------- Estimates (END)---------------------------------------






//---------------------- Product ----------------------------------------------

function addNewProduct(val, type, clientid, contactid) {
    if (type == 'add') {
        window.location = sitePath + "ProductCatalogue/ProductCatalogue_item.aspx?&from=crm&ClientID=" + clientid;
    }
}

//---------------------- Product (END)-----------------------------------------






function RadWinClose() {
    document.getElementById("divrad").style.display = "none";
    document.getElementById("divBackGroundNew").style.display = "none";
    Session("Contact") = null;
}

function LoadImgStarts() {
    document.getElementById("ds00").style.display = "block";
    document.getElementById("div_Load").style.display = "block";
}


function SetFiterState_Onclick(TabName, State) {

    var TabName = TabName.toLowerCase();
    var State = State.toLowerCase();

    if (TabName == "contacts") {
        if (State == "show") {
            document.cookie = "ContactFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "ContactFiterState=Hide";
        }
    }
    else if (TabName == "dept") {
        if (State == "show") {
            document.cookie = "DeptFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "DeptFiterState=Hide";
        }
    }
    else if (TabName == "address") {
        if (State == "show") {
            document.cookie = "AddressFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "AddressFiterState=Hide";
        }
    }
    else if (TabName == "products") {
        if (State == "show") {
            document.cookie = "ProductsFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "ProductsFiterState=Hide";
        }
    }
    else if (TabName == "notes") {
        if (State == "show") {
            document.cookie = "NotesFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "NotesFiterState=Hide";
        }
    }
    else if (TabName == "email") {
        if (State == "show") {
            document.cookie = "EmailFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "EmailFiterState=Hide";
        }
    }
    else if (TabName == "estimates") {
        if (State == "show") {
            document.cookie = "EstimatesFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "EstimatesFiterState=Hide";
        }
    }
    else if (TabName == "jobs") {
        if (State == "show") {
            document.cookie = "JobsFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "JobsFiterState=Hide";
        }
    }
    else if (TabName == "invoices") {
        if (State == "show") {
            document.cookie = "InvoicesFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "InvoicesFiterState=Hide";
        }
    }
    else if (TabName == "estore") {
        if (State == "show") {
            document.cookie = "eStoreFiterState=Show";
        }
        else if (State == "hide") {
            document.cookie = "eStoreFiterState=Hide";
        }
    }
}


var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(EndRequest);

function EndRequest(sender, args) {

    //    document.getElementById("ds00").style.display = "none";
    //    document.getElementById("div_Load").style.display = "none";
    //    document.getElementById("divBackGroundNew").style.display = "none";
}

//---------------------------costcentre----------

function checkAll_new_costcenter(checkAllBox_costcenter) {
    var frm = document.forms[0];
    var ChkState = checkAllBox_costcenter.checked;

    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('checkBox_costcenter') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
    }
}

function show_costcenter() {

    document.getElementById("img_actionsHide_costcenter").style.display = "block";
    document.getElementById("img_actionsShow_costcenter").style.display = "none";

    document.getElementById("div_chk_costcenter").style.border = "inset 1px";
    document.getElementById("div_chk_costcenter").style.background = "Gray";

    document.getElementById("div_popupActioncostcenter").style.display = "block";
}

function hide_costcenter() {

    document.getElementById("img_actionsHide_costcenter").style.display = "none";
    document.getElementById("img_actionsShow_costcenter").style.display = "block";

    document.getElementById("div_chk_costcenter").style.border = "outset 1px";
    document.getElementById("div_chk_costcenter").style.background = "";

    document.getElementById("div_popupActioncostcenter").style.display = "none";

}
var NoOFCnt_Address = 0;
var cnt_Address = 0;
var IDLenght_Address = 0;
var ActionType_costcenter = '';
var Counter_costcenter = 0;

function CheckOne_new_costcenter(val) {

    ActionType_costcenter = val;
    var frm = document.forms[0];
    var IDs = '';
    if (window.confirm("Are you sur you want to delete this items?") == false) {
        return false;
    }
    else {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkBox_costcenter') != -1) {
                if (!e.disabled) {
                    if (e.checked) {
                        Counter_costcenter = Number(Counter_Address) + 1;
                        IDs = IDs + frm[i].value + ",";
                    }
                }
            }
        }

        document.getElementById("ctl00_ContentPlaceHolder1_Client_hdncostcenterids").value = IDs;
    }
}

function addNewCostcenter(val, type, clientid, contactid) {
    if (type == 'add') {
        var RadWindow_Paid = window.radopen(strSitepath + "common/common_popup.aspx?type=moreCost&clientid=" + clientid + "&mode=add&pg=" + pg + "&companytype=" + CompanyType + "&Pgtype=" + pg + "&from=" + pg);
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        RadWindow_Paid.setSize(600, 300);
        RadWindow_Paid.center();

    }
}

function EditCostcenter(val, type, clientid, CostCentreID) {
    if (type == 'edit') {
        var RadWindow_Paid = window.radopen(strSitepath + "common/common_popup.aspx?type=moreCostEdit&clientid=" + clientid + "&&CostCentreID=" + CostCentreID + "&mode=edit&pg=" + pg + "&companytype=" + CompanyType + "&Pgtype=" + pg + "&from=" + pg);
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        RadWindow_Paid.setSize(600, 300);
        RadWindow_Paid.center();
    }

}


