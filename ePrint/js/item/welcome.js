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

        var subject = ddlsubject.value == "" ? "0" : ddlsubject.options[ddlsubject.selectedIndex].text;
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
        document.getElementById("div_task_add").style.display = "none";
        document.getElementById("hrefEditTask").style.display = "block";
    }
    return false;
}