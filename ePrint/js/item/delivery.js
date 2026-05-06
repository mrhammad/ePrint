



function show_hide_subject(distype) {
    var div_subject = document.getElementById("div_SubjectTable");
    div_subject.style.display = "none";
    hdn_Subject.value = txtSubject.value;

    if (distype == "show") {
        // setPopUpDivCenter(div_subject);
        txtSubject.value = "";
        // div_subject.style.display = "block";
        showDivPopupCenter('div_SubjectTable', '200');
        txtSubject.focus();
    }
}
var isValid = true;
function validate() {

    var isValid = true;
    var spn_txtSubject = document.getElementById("spn_txtSubject");
    spn_txtSubject.style.display = "none"
    if (txtSubject.value == "") {
        spn_txtSubject.style.display = "block"
        isValid = false;
    }
    if (isValid) {
        show_hide_subject('hide')
        return true;
    }
    else {
        show_hide_subject('show')
        return false;
    }
}

function Make_DDL_Show_Hide(para) {

    var div_ddlSupplier = document.getElementById("div_ddlSupplier");
    var div_ddlStatus = document.getElementById("div_ddlStatus");
    var div_ddlAttention = document.getElementById("div_ddlAttention");

    if (para == 'show') {
        div_ddlSupplier.style.display = "block";
        div_ddlStatus.style.display = "block";
        div_ddlAttention.style.display = "block";
    }
    else {
        div_ddlSupplier.style.display = "none";
        div_ddlStatus.style.display = "none";
        div_ddlAttention.style.display = "none";
    }
}

function CloseTaskPage() {
    Make_DDL_Show_Hide('show'); //BLOCK
    if (TaskAddData == '') {
        chk_FollowupTask.checked = false;
        document.getElementById("div_Task").style.display = "none";
    }
    else {
        document.getElementById("div_Task").style.display = "none";
    }
}

function OpenTaskPage(val) {
    if (val) {
        //setTaskPopUpCenter(document.getElementById("div_task_add"));
        document.getElementById("div_Task").style.display = "block";
        //document.getElementById("div_task_add").style.display = "block";
        showDivPopupCenter('div_task_add', '250');
        Make_DDL_Show_Hide('none'); //NONE
    }
    else {
        document.getElementById("div_Task").style.display = "none";
        //document.getElementById("div_task_add").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
        Make_DDL_Show_Hide('show'); //NONE
    }
}

function OpenTaskPage_New(val) {
    if (val) {
        //setTaskPopUpCenter(document.getElementById("div_task_add"));
        document.getElementById("div_Task").style.display = "block";
        //document.getElementById("div_task_add").style.display = "block";
        showDivPopupCenter('div_task_add', '250');
    }
    else {
        document.getElementById("div_Task").style.display = "none";
        //document.getElementById("div_task_add").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
}


function hideTaskDiv() {
    document.getElementById("div_Task").style.display = "none";
    document.getElementById("divBackGroundNew").style.display = "none";
    Make_DDL_Show_Hide('show'); //NONE
}

// To Validate Task page subject
var TaskAddData = '';
function Store_Task_Data() {
    if (testdate() == false) {
        return false;
    }
    else {

        TaskAddData = '';
        var assigneto = ddlassigneto.value == "" ? "0" : ddlassigneto.value;
        TaskAddData += "assignedto»" + assigneto + "±";

        var status = ddlstatus.value == "" ? "0" : ddlstatus.options[ddlstatus.selectedIndex].text;
        TaskAddData += "status»" + status + "±";

        var subject = hdn_Subject.value == "" ? "" : hdn_Subject.value;
        TaskAddData += "subject»" + subject + "±";

        var priority = ddlpriority.value == "" ? "0" : ddlpriority.options[ddlpriority.selectedIndex].text;
        TaskAddData += "priority»" + priority + "±";

        var contactid = contactid_hidden.value == "" ? "0" : contactid_hidden.value;
        TaskAddData += "contactid»" + contactid + "±";

        TaskAddData += "txtduedate»" + txtduedate.value + "±";
        TaskAddData += "ddlhour»" + ddlhour.value + "±";
        TaskAddData += "ddlminute»" + ddlminute.value + "±";
        TaskAddData += "description»" + txtcomment.value + " ";

        hidFollowupTask.value = TaskAddData;
        //        document.getElementById("div_task_add").style.display = "none";
        //        document.getElementById("hrefEditTask").style.display = "block";
    }
    hideTaskDiv();
    return false;
}
    
    