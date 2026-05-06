
try {
    AttachmentsDataRow = dataRows;
} catch (e) {

}

//.......................................loading more Close activity.........................................................
function BindMoreContact(data) {
    var lbltopfivecontact = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbltopfivecontact");
    var dataRows = data.d;
    if (dataRows.length == 0) {
        lbltopfivecontact.innerHTML = "";
        return;
    }
    lbltopfivecontact.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        lbltopfivecontact.innerHTML = dataRows[i].AllContacts;
    }
    document.getElementById("DivHideMoreContactNew").style.display = "block";
    if (NotespageNummberIndexCon >= 9) {
        document.getElementById("DivShowMoreContact").style.display = "none";
        document.getElementById("DivShowAllContact").style.display = "block";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Load_More_Contacts(ClientID, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreContacts",
        data: GetInputLoad_Contacts(ClientID, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindMoreContact,
        error: ServiceFailed
    });
}

function GetInputLoad_Contacts(ClientID, NotespageNummber) {
    var FinalString = ' { "ClientID" : "' + ClientID + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function LoadMoreContacts(ClientID, NotespageNummber) {
    NotespageNummberIndexCon = NotespageNummberIndexCon + 4;
    CRM_Load_More_Contacts(ClientID, NotespageNummberIndexCon);
}

function BindMoreCloseActivity(data) {
    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    var dataRows = data.d;
    if (dataRows.length == 0) {
        lblcloseActivity.innerHTML = "";
        return;
    }
    lblcloseActivity.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
    }
    document.getElementById("DivHideMoreCloAct").style.display = "block";
    if (NotespageNummberIndexCL >= 9) {
        document.getElementById("DivShowMoreCA").style.display = "none";
        document.getElementById("DivShowAllCA").style.display = "block";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Load_More_CA(ClientID, CompanyId, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreCloseActivity",
        data: GetInputLoad_CA(ClientID, CompanyId, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindMoreCloseActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_CA(ClientID, CompanyId, NotespageNummber) {
    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function LoadMoreCloseActivity(ClientID, CompanyId) {
    NotespageNummberIndexCL = NotespageNummberIndexCL + 4;
    CRM_Load_More_CA(ClientID, CompanyId, NotespageNummberIndexCL);
}

function BindMoreOpenActivity(data) {
    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblOpenActivities.innerHTML = "";
        return;
    }
    lblOpenActivities.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblOpenActivities.innerHTML = dataRows[i].Alltask;
    }
    document.getElementById("DivHideMoreOA").style.display = "block";
    if (NotespageNummberIndexOA >= 9) {
        document.getElementById("DivShowMoreOA").style.display = "none";
        document.getElementById("DivShowAllOA").style.display = "block";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Load_More_OA(ClientID, CompanyId, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreOpenActivity",
        data: GetInputLoad_OA(ClientID, CompanyId, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindMoreOpenActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_OA(ClientID, CompanyId, NotespageNummber) {
    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function LoadMoreOpenActivity(ClientID, CompanyId) {
    NotespageNummberIndexOA = NotespageNummberIndexOA + 4;
    CRM_Load_More_OA(ClientID, CompanyId, NotespageNummberIndexOA);
}

function BindMoreNotes(data) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var dataRows = data.d;
    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    notestitle.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        notestitle.innerHTML = dataRows[i].AllNotes;
    }

    document.getElementById("DivHideMoreNotes").style.display = "block";
    if (NotespageNummberIndex >= 9) {
        document.getElementById("DivShowMoreNotes").style.display = "none";
        document.getElementById("DivShowAllNotes").style.display = "block";
    }
    crmtooltip();
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Load_More_Notes(companyId, sectionid, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreNotes",
        data: GetInputLoad(companyId, sectionid, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindMoreNotes,
        error: ServiceFailed
    });
}

function GetInputLoad(companyId, sectionid, NotespageNummber) {
    var FinalString = ' { "companyId" : "' + companyId + '" , "sectionid" : "' + sectionid + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function LoadMoreNotes(companyId, sectionid) {
    NotespageNummberIndex = NotespageNummberIndex + 4;
    CRM_Load_More_Notes(companyId, sectionid, NotespageNummberIndex);
}

var NoteContact;

function BindNotes(data) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var dataRows = data.d;
    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }
    notestitle.innerHTML = "";
    var selected = $("#hdnFileselected").val();
    var selected = 'yes';

    var fileInput = $('#ctl00_ContentPlaceHolder1_Client_file_upload');
    //var fileData = fileInput.prop("files")[0];   // Getting the properties of file from file field
    var fileData;
    if (fileInput.prop != null && fileInput.prop != undefined) {
        fileData = fileInput.prop("files")[0];
    }

    if (fileData != null) {
        //        $("#file_upload").fileUploadSettings('script', '../Upload.ashx?fnrename=' + document.getElementById('txtfilename').value + '&Cid="' + CompanyID + '"&Aid= "' + dataRows[0].attachmentID + '"');
        //        $('#file_upload').fileUploadStart();
        var formData = new window.FormData();                  // Creating object of FormData class
        formData.append("file", fileData); // Appending parameter named file with properties of file_field to form_data
        // formData.append("user_email", email);
        $.ajax(
        {
            url: '../Upload.ashx?' + document.getElementById('txtfilename').value + '&Cid="' + CompanyID + '"&Aid= "' + dataRows[0].attachmentID + '"',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                //var obj = $.parseJSON(data);
                //  alert(data);
                //                if (obj.StatusCode == "OK") {
                //                    alert(obj.Message);

                //                } else if (obj.StatusCode == "ERROR") {
                //                    alert(obj.Message);
                //                } 
            },
            error: function (errorData) {
                // alert('hi');
                //$('.result-message').html("there was a problem uploading the file.").show();
            }
        });


        BindAttachments(dataRows);
        document.getElementById("ShowAttachIcon").style.display = "block";
    }
    else {
        BindAttachments(dataRows);
    }

    var AddNewTaskBtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkAddTask");
    var lnkcallbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkcall");
    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");

    var ddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var ddlCallContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");
    var ddlNoteContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");
    document.getElementById('ctl00_ContentPlaceHolder1_Client_file_upload').value = "";
}

function BindAttachments(dataRows) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");
    notestitle.innerHTML = "";
    hdnprintNotes.value = "";

    for (var i = 0; i < dataRows.length; i++) {

        notestitle.innerHTML = dataRows[i].AllNotes;
        hdnprintNotes.value = dataRows[i].AllNotesPrint;
    }

    $("#hdnFileselected").val('');
    document.getElementById("AddNote").style.display = "none";
    document.getElementById("addfileDiv").style.display = "none";
    document.getElementById("DivShowNote").style.display = "block";
    document.getElementById("DivAddNotePopup").style.display = "none";

    crmtooltip();
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Insert_Notes(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID, SpecificTo) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientNotesAdd",
        data: GetInput(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID, SpecificTo),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindNotes,
        error: ServiceFailed
    });
}

function GetInput(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID, SpecificTo) {
    Subject = Subject.replace(/\"/g, "\\\"");
    Title = Title.replace(/\"/g, "\\\"");

    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "SectionName" : "' + SectionName + '", "SectionID" : "' + SectionID + '" , "FileName" : "' + FileName + '", "FileSize" : "' + FileSize + '", "CreateUserID" : "' + CreateUserID + '" , "Subject" : "' + Subject + '", "Title" : "' + Title + '" , "NotespageNummber" : "' + NotespageNummber + '" , "ContactID" : "' + ContactID + '" , "SpecificTo" : "' + SpecificTo + '" } '
    return FinalString;
}

function CallInsert_NotesMethod(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID, SpecificTo) {
    NotespageNummberIndex = 1;
    var NotesDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtNoteDesc");
    var Notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
    var UploadtextBox = document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload");
    var ddlspecific = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");
    var ddlspecificTo = ddlspecific.options[ddlspecific.selectedIndex].value;
    NoteContact = ddlspecificTo;
    CRM_Insert_Notes(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, NotesDesc.value, Notestitle.value, NotespageNummberIndex, ContactID, ddlspecificTo);
    NotesDesc.value = "";
    Notestitle.value = "";
    UploadtextBox.value = "";
    NotesDesc.focus();
}

//..............................................deleting notes from here ..............................................//

function CRM_Delete_Notes(CompanyID, SectionID, attachmentId, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientNotesDelete",
        data: Getnotes_deletedata(CompanyID, SectionID, attachmentId, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindNotes_afterdelete,
        error: ServiceFailed
    });
}

function CallDelete_NotesMethod(CompanyID, SectionID, attachmentId, NotespageNummber) {
    NotespageNummberIndex = 1;
    var NotesDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtNoteDesc");
    var Notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
    var UploadtextBox = document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload");
    CRM_Delete_Notes(CompanyID, SectionID, attachmentId, NotespageNummberIndex);
    NotesDesc.value = "";
    Notestitle.value = "";
    UploadtextBox.value = "";

}

function Getnotes_deletedata(CompanyID, SectionID, attachmentId, NotespageNummber) {
    var FinalStringofDeleteNote = ' { "CompanyID" : "' + CompanyID + '" , "SectionID" : "' + SectionID + '", "attachmentId" : "' + attachmentId + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalStringofDeleteNote;
}

function BindNotes_afterdelete(data) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var lblAllNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllNotes");
    var dataRows = data.d;
    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        lblAllNotes.innerHTML = "";
        notestitle.setAttribute("style", "font-weight:bold; font-size:12px;");
        return;
    }
    notestitle.innerHTML = "";
    lblAllNotes.innerHTML = "";
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");
    hdnprintNotes.value = "";
    for (var i = 0; i < dataRows.length; i++) {
        notestitle.innerHTML = dataRows[i].AllNotes;
        hdnprintNotes.value = dataRows[i].AllNotesPrint;
        lblAllNotes.innerHTML = dataRows[i].AllNotesPopup;
    }
    crmtooltip();
}

//..............................................Editing notes from here ..............................................//


function CRM_Edit_Notes(attachmentId) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientNotesEdit",
        data: Getnotes_Editdata(attachmentId),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindNotes_afterEdit,
        error: ServiceFailed
    });
}

function CallEdit_NotesMethod(attachmentId) {
    CRM_Edit_Notes(attachmentId);
}

function Getnotes_Editdata(attachmentId) {
    var FinalStringofEditNote = ' { "attachmentId" : "' + attachmentId + '" } '
    return FinalStringofEditNote;
}

function BindNotes_afterEdit(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var notesdesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtNoteDesc");
    var NotesTitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
    var FileUpload = document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload");
    var OldFileName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOldFile");
    var lblOldFileSize = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOldFileSize");
    var ddlspecificToEdit = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");

    document.getElementById("divNoteTitle").style.display = "block";
    document.getElementById("DivFileUpload1").style.display = "none";
    document.getElementById("DivOldFile").style.display = "block";

    for (var i = 0; i < dataRows.length; i++) {

        notesdesc.innerHTML = dataRows[i].subject;
        notesdesc.value = dataRows[i].subject;
        NotesTitle.innerHTML = dataRows[i].title;
        NotesTitle.value = dataRows[i].title;
        OldFileName.innerHTML = dataRows[i].filename;

        OldFileName.setAttribute("onclick", "javascript:ViewAttachedFiles('" + dataRows[i].attachmentID + "','" + dataRows[i].companyId + "')");
        lblOldFileSize.innerHTML = dataRows[i].filsize;
        var OldFile = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOldFile");

        if (OldFile.innerHTML == "") {
            document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkRemoveOldFile").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOldFile").innerHTML = "";
            document.getElementById('DivOldFile').style.display = "none";
            document.getElementById('addfileDiv').style.display = "block";
            document.getElementById("DivUploFile").style.display = "block";
            document.getElementById("DivCloseBrowseFile").style.display = "block";
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkRemoveOldFile").style.display = "block";
            document.getElementById("DivUploFile").style.display = "none";
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("DivCloseBrowseFile").style.display = "none";
        }
        //-----------------------------------------Note Details..........................................................//
        var lbldetNoteTitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetNoteTitle");
        var lbldetSpecifictoContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetSpecifictoContact");
        var lbldetAddedBy = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetAddedBy");
        var lbldetDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDate");
        var lbldetNoteContent = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetNoteContent");

        lbldetNoteTitle.innerHTML = dataRows[i].title;
        lbldetSpecifictoContact.innerHTML = dataRows[i].SpecificName;
        lbldetAddedBy.innerHTML = dataRows[i].username;
        lbldetDate.innerHTML = dataRows[i].createDate;
        lbldetNoteContent.innerHTML = dataRows[i].subject;
        lbldetNoteContent.title = dataRows[i].subject;
    }

    for (i = 0; i < ddlspecificToEdit.length; i++) {
        if (ddlspecificToEdit.options[i].value == dataRows[0].SpecificTo) {
            ddlspecificToEdit.selectedIndex = i;
        }
    }
}

//......................................................... updating data from here.............................................//

var EditContactID;
function BindNotes_AfterUpdate(data) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var dataRows = data.d;
    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }
    notestitle.innerHTML = "";
    var selected = $("#hdnFileselected").val();
    var selected = 'yes';
    var fileInput = $('#ctl00_ContentPlaceHolder1_Client_file_upload');
    var fileData;
    if (fileInput.prop != null && fileInput.prop != undefined) {
        fileData = fileInput.prop("files")[0];
    }

    if (fileData != null) {
        var formData = new window.FormData();
        formData.append("file", fileData);
        $.ajax(
        {
            url: '../Upload.ashx?' + document.getElementById('txtfilename').value + '&Cid="' + CompanyID + '"&Aid= "' + dataRows[0].attachmentID + '"',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
            },
            error: function (errorData) {
            }
        });

        BindUpdatedAttachments(dataRows);
        document.getElementById("ShowAttachIcon").style.display = "block";
    }
    else {
        BindUpdatedAttachments(dataRows);
    }

    var AddNewTaskBtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkAddTask");
    var lnkcallbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkcall");
    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");

    var ddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var ddlCallContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");
    var ddlNoteContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");

    document.getElementById('ctl00_ContentPlaceHolder1_Client_file_upload').value = "";
    crmtooltip();
}

function BindUpdatedAttachments(dataRows) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");
    notestitle.innerHTML = "";
    hdnprintNotes.value = "";
    for (var i = 0; i < dataRows.length; i++) {
        notestitle.innerHTML = dataRows[i].AllNotes;
        hdnprintNotes.value = dataRows[i].AllNotesPrint;
    }
}


function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Update_Notes(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, SpecifiedTo) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientNotesUpdate",
        data: GetInputUpdate(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, SpecifiedTo),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindNotes_AfterUpdate,
        error: ServiceFailed
    });
}

function GetInputUpdate(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, SpecifiedTo) {
    Subject = Subject.replace(/\"/g, "\\\"");
    Title = Title.replace(/\"/g, "\\\"");
    var FinalString = ' { "attachmentId" : "' + attachID + '" , "CompanyID" : "' + CompanyID + '" , "SectionName" : "' + SectionName + '", "SectionID" : "' + SectionID + '" , "FileName" : "' + FileName + '", "FileSize" : "' + FileSize + '", "modifyUserID" : "' + modifyUserID + '" , "Subject" : "' + Subject + '", "Title" : "' + Title + '" , "NotespageNummber" : "' + NotespageNummber + '" , "SpecifiedTo" : "' + SpecifiedTo + '" } '
    return FinalString;
}

function Call_UpdateMethod(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, SpecifiedTo) {
    NotespageNummberIndex = 1;
    var NotesDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtNoteDesc");
    var Notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
    var UploadtextBox = document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload");
    var ddlspecificUp = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");
    var ddlspecificTOUp = ddlspecificUp.options[ddlspecificUp.selectedIndex].value;
    EditContactID = ddlspecificTOUp;
    CRM_Update_Notes(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, NotesDesc.value, Notestitle.value, NotespageNummberIndex, ddlspecificTOUp);
    NotesDesc.value = "";
    Notestitle.value = "";
    UploadtextBox.value = "";
}

//......................................................... inserting task subject from here.............................................//

function BindNotes_Subject(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {

        alert("Subject already exist, choose another subject");
        document.getElementById("DivOpenSubject").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtSubject").focus();
        return;
    }
    for (var i = 0; i < dataRows.length; i++) {

        if (dataRows[i].sampleSubject != "") {
            document.getElementById("DivOpenSubject").style.display = "none";
            var opt = document.createElement("option");
            var ddlSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlsubject");
            ddlSubject.options.add(opt);
            opt.text = dataRows[i].sampleSubject;
            opt.value = dataRows[i].sampleSubject;
            ddlSubject.selectedIndex = ddlSubject.length - 1;
            var actualvalue = ddlSubject.options[ddlSubject.selectedIndex].value;
        }
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Insert_Notes_Subject(Subject, CompanyID, Language) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_subject_Insert",
        data: GetInputNotesSubject(Subject, CompanyID, Language),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindNotes_Subject,
        error: ServiceFailed
    });
}

function GetInputNotesSubject(Subject, CompanyID, Language) {
    var FinalString = ' { "Subject" : "' + Subject + '" , "CompanyID" : "' + CompanyID + '" , "Language" : "' + Language + '" } '
    return FinalString;
}

function CallInsert_NotesSubjectMethod(Subject, CompanyID, Language) {
    var NotesSub = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtSubject");
    CRM_Insert_Notes_Subject(SpecialEncode(NotesSub.value), CompanyID, Language);
    NotesSub.value = "";
}

//......................................................... inserting task from here.............................................//

function GetScreenCordinatesForNotewindow(obj) {
    var p = {};
    p.x = obj.offsetLeft;
    p.y = obj.offsetTop;
    while (obj.offsetParent) {
        p.x = p.x + obj.offsetParent.offsetLeft + 3.8;
        p.y = p.y + obj.offsetParent.offsetTop - 2.7;
        if (obj == document.getElementsByTagName("body")[0]) {
            break;
        }
        else {
            obj = obj.offsetParent;
        }
    }
    return p;
}

function GetScreenCordinatesForTaskpop(obj) {
    var p = {};
    p.x = obj.offsetLeft;
    p.y = obj.offsetTop;
    while (obj.offsetParent) {
        p.x = p.x + obj.offsetParent.offsetLeft - 30.2;
        p.y = p.y + obj.offsetParent.offsetTop - 2.7;
        if (obj == document.getElementsByTagName("body")[0]) {
            break;
        }
        else {
            obj = obj.offsetParent;
        }
    }
    return p;
}

function GetScreenCordinatesForEventpop(obj) {
    var p = {};
    p.x = obj.offsetLeft;
    p.y = obj.offsetTop;
    while (obj.offsetParent) {
        p.x = p.x + obj.offsetParent.offsetLeft - 16.4;
        p.y = p.y + obj.offsetParent.offsetTop - 2.7;
        if (obj == document.getElementsByTagName("body")[0]) {
            break;
        }
        else {
            obj = obj.offsetParent;
        }
    }
    return p;
}

function GetScreenCordinatesForCallpop(obj) {
    var p = {};
    p.x = obj.offsetLeft;
    p.y = obj.offsetTop;
    while (obj.offsetParent) {
        p.x = p.x + obj.offsetParent.offsetLeft - 30.2;
        p.y = p.y + obj.offsetParent.offsetTop - 2.7;
        if (obj == document.getElementsByTagName("body")[0]) {
            break;
        }
        else {
            obj = obj.offsetParent;
        }
    }
    return p;
}

var TaskAssignTo;
var TaskContact;

function BindTask(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var AddNewTaskBtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkAddTask");
    var lnkEventbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkEvent");
    var lnkcallbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkcall");
    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");

    document.getElementById('DivNotesPopup').style.display = "none";
    var hdnTaskFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentID");
    var hdnTaskFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentType");
    var hdnCallFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentID");
    var hdnCallFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentType");
    var ddlassigneto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlassigneto");
    var ddlowner = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlowner");
    var ddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var ddlCallAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");
    var ddlNoteContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    lblOpenActivities.innerHTML = "";

    for (var i = 0; i < dataRows.length; i++) {
        lblOpenActivities.innerHTML = dataRows[i].Alltask;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Insert_task(companyId, subject, taskTitle, taskStatus, dueDate, taskTime, contactId, priority, type, typeid, description, isSample, assignToUserId, createUserId, modifyUserId, createDate, modifiedDate, contactType, isDelete, NotespageNummber, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/CrmTaskInsert",
        data: GetInput_task(companyId, subject, taskTitle, taskStatus, dueDate, taskTime, contactId, priority, type, typeid, description, isSample, assignToUserId, createUserId, modifyUserId, createDate, modifiedDate, contactType, isDelete, NotespageNummber, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTask,
        error: ServiceFailed
    });
}

function GetInput_task(companyId, subject, taskTitle, taskStatus, dueDate, taskTime, contactId, priority, type, typeid, description, isSample, assignToUserId, createUserId, modifyUserId, createDate, modifiedDate, contactType, isDelete, NotespageNummber, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone) {

    description = description.replace(/\"/g, "\\\"");
    var FinalString = ' { "companyId" : "' + companyId + '" , "subject" : "' + subject + '" , "taskTitle" : "' + taskTitle + '" , "taskStatus" : "' + taskStatus + '" , "dueDate" : "' + dueDate + '" , "taskTime" : "' + taskTime + '" , "contactId" : "' + contactId + '" , "priority" : "' + priority + '" , "type" : "' + type + '" , "typeid" : "' + typeid + '" , "description" : "' + description + '", "isSample" : "' + isSample + '" , "assignToUserId" : "' + assignToUserId + '" , "createUserId" : "' + createUserId + '" , "modifyUserId" : "' + modifyUserId + '" , "createDate" : "' + createDate + '" , "modifiedDate" : "' + modifiedDate + '" , "contactType" : "' + contactType + '" , "isDelete" : "' + isDelete + '" , "NotespageNummber" : "' + NotespageNummber + '" , "ParentType" : "' + ParentType + '" , "ParentID" : "' + ParentID + '" , "ModuleID" : "' + ModuleID + '" , "ModuleName" : "' + ModuleName + '", "Contact_Phone" : "' + Contact_Phone + '", "Contact_Mobile" : "' + Contact_Mobile + '", "Department_Phone" : "' + Department_Phone + '"} '
    return FinalString;
}

function CallInsert_TaskMethod(companyId, subject, taskTitle, taskStatus, dueDate, taskTime, contactId, priority, type, typeid, description, isSample, assignToUserId, createUserId, modifyUserId, createDate, modifiedDate, contactType, isDelete, NotespageNummber, ParentType, ParentID) {
    NotespageNummberIndex = 1;

    var Subject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlsubject");
    Subject.options[Subject.selectedIndex].text;
    var finalSubject = Subject.options[Subject.selectedIndex].text;

    var Status = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlstatus");
    Status.options[Status.selectedIndex].text;
    var finalStatus = Status.options[Status.selectedIndex].text;

    var Duedate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtduedate");

    var Contact_Phone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactPhone").value;
    var Contact_Mobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactMobile").value;
    var Department_Phone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskDepartmentPhone").value;

    var finalhoursMinute = "";
    var HoursMinute = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker").get_dateInput();
    finalhoursMinute = HoursMinute.get_value();

    var Priority = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlpriority");
    Priority.options[Priority.selectedIndex].text;
    var finalPriority = Priority.options[Priority.selectedIndex].text;

    var desc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtNotesDesc");

    var Assignto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlassigneto");
    Assignto.options[Assignto.selectedIndex].text;
    var finalAssignto = Assignto.options[Assignto.selectedIndex].value;

    TaskAssignTo = finalAssignto;

    var ddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");

    var contactId = 0;
    if (ddlTaskContacts.options.length == 0) {
        contactId = 0;
    }
    else {
        ddlTaskContacts.options[ddlTaskContacts.selectedIndex].text;
        contactId = ddlTaskContacts.options[ddlTaskContacts.selectedIndex].value;
    }
    TaskContact = contactId;

    var hdnTaskFollowParentID = 0;
    var hdnTaskFollowParentType = "";
    hdnTaskFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentID");
    hdnTaskFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentType");

    if (hdnTaskFollowParentID.value == "") {
        hdnTaskFollowParentID.value = 0;
    }
    if (hdnTaskFollowParentType.value == "") {
        hdnTaskFollowParentType.value = "";
    }
    CRM_Insert_task(CompanyID, SpecialEncode(finalSubject), '', finalStatus, Duedate.value, finalhoursMinute, contactId, finalPriority, 'client', ClientIDTask, desc.value, 0, finalAssignto, UserIDN, UserIDN, CreateddateN, CreateddateN, '', 0, NotespageNummberIndex, hdnTaskFollowParentType.value, hdnTaskFollowParentID.value, 0, '', Contact_Phone, Contact_Mobile, Department_Phone);

    hdnTaskFollowParentID.value = "";
    hdnTaskFollowParentType.value = "";
    var hdnCallFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentID");
    var hdnCallFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentType");
    hdnCallFollowParentID.value = "";
    hdnCallFollowParentType.value = "";

    document.getElementById('DivNotesPopup').style.display = "none";
}

//......................................................... Deleting task from here.............................................//

function BindTask_Delete(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    lblOpenActivities.innerHTML = "";
    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    lblcloseActivity.innerHTML = "";
    var lblAllOA = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllOA");
    lblAllOA.innerHTML = "";


    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");

    for (var i = 0; i < dataRows.length; i++) {

        lblOpenActivities.innerHTML = dataRows[i].Alltask;
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
        lblAllOA.innerHTML = dataRows[i].AllOA;
    }
    document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities").style.display = "block";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity").style.display = "none";
    document.getElementById("DivclosedActivityTable").style.display = "none";
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Delete_OpenActivities(id, CompanyId, Clientid, SectionName, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientDeleteOpenActivities",
        data: GetInput_task_Delete(id, CompanyId, Clientid, SectionName, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTask_Delete,
        error: ServiceFailed
    });
}

function GetInput_task_Delete(id, CompanyId, Clientid, SectionName, NotespageNummber) {
    var FinalString = ' { "id" : "' + id + '" , "CompanyId" : "' + CompanyId + '" , "Clientid" : "' + Clientid + '" , "SectionName" : "' + SectionName + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function CallDelete_OpenActivitiesMethod(id, CompanyId, Clientid, SectionName, NotespageNummber) {
    NotespageNummberIndex = 1;
    CRM_Delete_OpenActivities(id, CompanyId, Clientid, SectionName, NotespageNummberIndex);
}

//......................................................... inserting event from here.............................................//

function CallInsert_taskSubjectMethod(Subject, CompanyID, Language) {

    var txtEventSubj = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEventSubject");

    CRM_Insert_task_Subject(txtEventSubj.value, CompanyID, Language);
    txtEventSubj.value = "";
}

function GetInputeventSubject(Subject, CompanyID, Language) {
    var FinalString = ' { "Subject" : "' + Subject + '" , "CompanyID" : "' + CompanyID + '" , "Language" : "' + Language + '" } '
    return FinalString;
}

function CRM_Insert_task_Subject(Subject, CompanyID, Language) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_subject_Insert",
        data: GetInputeventSubject(Subject, CompanyID, Language),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTask_Subject,
        error: ServiceFailed
    });
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function BindTask_Subject(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        alert("Subject already exist, choose another subject");
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEventSubject").focus();
        return;
    }
    for (var i = 0; i < dataRows.length; i++) {

        if (dataRows[i].sampleSubject != "") {
            var opt = document.createElement("option");
            var ddlEventsSub = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEventsSubject");

            ddlEventsSub.options.add(opt);
            opt.text = dataRows[i].sampleSubject;
            opt.value = dataRows[i].sampleSubject;
            ddlEventsSub.selectedIndex = ddlEventsSub.length - 1;
            var actualvalue = ddlEventsSub.options[ddlEventsSub.selectedIndex].value;
        }
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//......................................................... inserting task edit subject from here.............................................//

function CallInsert_taskEditSubjectMethod(Subject, CompanyID, Language) {
    var txtEditSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditSubject");
    CRM_Insert_taskEdit_Subject(SpecialEncode(txtEditSubject.value), CompanyID, Language);
    txtEditSubject.value = "";
}

function CRM_Insert_taskEdit_Subject(Subject, CompanyID, Language) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_subject_Insert",
        data: GetInputEditTaskSubject(Subject, CompanyID, Language),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindEditask_Subject,
        error: ServiceFailed
    });
}

function GetInputEditTaskSubject(Subject, CompanyID, Language) {
    var FinalString = ' { "Subject" : "' + Subject + '" , "CompanyID" : "' + CompanyID + '" , "Language" : "' + Language + '" } '
    return FinalString;
}

function BindEditask_Subject(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        alert("Subject already exist, choose another subject");
        document.getElementById("DivEditTaskSubject").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditSubject").focus();
        return;
    }
    for (var i = 0; i < dataRows.length; i++) {
        if (dataRows[i].sampleSubject != "") {
            document.getElementById("DivEditTaskSubject").style.display = "none";
            var opt = document.createElement("option");
            var ddlSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditsubject");
            ddlSubject.options.add(opt);
            opt.text = dataRows[i].sampleSubject;
            opt.value = dataRows[i].sampleSubject;
            ddlSubject.selectedIndex = ddlSubject.length - 1;
            var actualvalue = ddlSubject.options[ddlSubject.selectedIndex].value;
        }
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//......................................................... Updating task from here.............................................//

var EditTaskAssignTo;
var EditTaskContact;

function CallUpdate_TaskMethod(taskID, CompanyID, subject, taskStatus, dueDate, taskTime, contactId, contactType, priority, type, typeId, description, assignToUserId, modifyUserId, modifiedDate, NotespageNummber) {

    NotespageNummberIndex = 1;

    var ddlEditsubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditsubject");
    ddlEditsubject.options[ddlEditsubject.selectedIndex].text;
    var finalSubject = ddlEditsubject.options[ddlEditsubject.selectedIndex].text;

    var ddlEditassignto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditassignto");
    ddlEditassignto.options[ddlEditassignto.selectedIndex].text;
    var finalStatus = ddlEditassignto.options[ddlEditassignto.selectedIndex].text;

    var ddlEditStataus = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditStataus");
    ddlEditStataus.options[ddlEditStataus.selectedIndex].text;
    var finaltaskStatus = ddlEditStataus.options[ddlEditStataus.selectedIndex].text;

    var Contact_Phone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditTaskContactPhone").value;
    var Contact_Mobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EdirTaskContactMobile").value;
    var Department_Phone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditDepartmentPhone").value;

    var dueDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditDueDate");

    var finalhoursMinute = "";
    var HoursMinute = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker1").get_dateInput();
    finalhoursMinute = HoursMinute.get_value();

    var ddlEditPriority = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditPriority");
    ddlEditPriority.options[ddlEditPriority.selectedIndex].text;
    var finalPriority = ddlEditPriority.options[ddlEditPriority.selectedIndex].text;

    var TaskDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditTaskDesc");

    var ddlEditassignto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditassignto");
    ddlEditassignto.options[ddlEditassignto.selectedIndex].text;
    var finalAssignto = ddlEditassignto.options[ddlEditassignto.selectedIndex].value;
    EditTaskAssignTo = finalAssignto;
    var ddlEditContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditContact");

    contactId = 0;

    if (ddlEditContact.options.length == 0) {
        contactId = 0;
    }
    else {

        ddlEditContact.options[ddlEditContact.selectedIndex].text;
        contactId = ddlEditContact.options[ddlEditContact.selectedIndex].value;
    }
    EditTaskContact = contactId;

    CRM_Update_task(taskID, CompanyID, SpecialEncode(finalSubject), finaltaskStatus, dueDate.value, finalhoursMinute, contactId, contactType, finalPriority, type, typeId,
        TaskDesc.value, finalAssignto, modifyUserId, modifiedDate, NotespageNummberIndex, Contact_Phone, Contact_Mobile, Department_Phone);
    document.getElementById('DivtaskPopUpEdit').style.display = "none";
}

function CRM_Update_task(taskID, CompanyID, subject, taskStatus, dueDate, taskTime, contactId, contactType, priority, type, typeId, description, assignToUserId, modifyUserId, modifiedDate, NotespageNummber, Contact_Phone, Contact_Mobile, Department_Phone) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/CrmTaskUpdate",
        data: GetInput_Updatetask(taskID, CompanyID, subject, taskStatus, dueDate, taskTime, contactId, contactType, priority, type, typeId, description, assignToUserId, modifyUserId, modifiedDate, NotespageNummber, Contact_Phone, Contact_Mobile, Department_Phone),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTask_Update,
        error: ServiceFailed
    });
}

function GetInput_Updatetask(taskID, CompanyID, subject, taskStatus, dueDate, taskTime, contactId, contactType, priority, type, typeId, description, assignToUserId, modifyUserId, modifiedDate, NotespageNummber, Contact_Phone, Contact_Mobile, Department_Phone) {
    description = description.replace(/\"/g, "\\\"");
    var FinalString = ' { "taskID" : "' + taskID + '" , "CompanyID" : "' + CompanyID + '" , "subject" : "' + subject + '" , "taskStatus" : "' + taskStatus + '" , "dueDate" : "' + dueDate + '" , "taskTime" : "' + taskTime +
        '" , "contactId" : "' + contactId + '" , "contactType" : "' + contactType + '" , "priority" : "' + priority + '" , "type" : "' + type + '" , "typeId" : "' +
        typeId + '" , "description" : "' + description + '" , "assignToUserId" : "' + assignToUserId + '" , "modifyUserId" : "' + modifyUserId + '" , "modifiedDate" : "' +
        modifiedDate + '" , "NotespageNummber" : "' + NotespageNummber + '", "Contact_Phone" : "' + Contact_Phone + '", "Contact_Mobile" : "' +
        Contact_Mobile + '", "Department_Phone" : "' + Department_Phone + '" } '
    return FinalString;
}

function BindTask_Update(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var AddNewTaskBtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkAddTask");
    var lnkcallbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkcall");

    var hdnTaskFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentID");
    var hdnTaskFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentType");
    var hdnCallFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentID");
    var hdnCallFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentType");

    var EditTaskddlassigneto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlassigneto");
    var EditTaskddlowner = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlowner");
    var EditTaskddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var EditTaskddlCallAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");

    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");
    var ddlEditNoteContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    lblOpenActivities.innerHTML = "";

    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    lblcloseActivity.innerHTML = "";

    var lblAllOA = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllOA");
    lblAllOA.innerHTML = "";

    for (var i = 0; i < dataRows.length; i++) {
        lblOpenActivities.innerHTML = dataRows[i].Alltask;
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
        lblAllOA.innerHTML = dataRows[i].AllOA;
    }


    var lbldetStatus = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetStatus");
    var lblDetSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetSubject");
    var lbldetType = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetType");
    var lbldetDueDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDueDate");
    var lbldetContactName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactName");
    var lbldetContactEmail = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetContactEmail"); 

    var lbldetContactMobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactMobile");
    var lbldetContactPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactPhone");
    var lblDetDepartmentName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetDepartmentName");

    var lbldetAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetAssignTo");
    var lbldetDescription = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDescription");

    var lbldetCompanyName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetCompanyName");
    lbldetCompanyName.innerHTML = dataRows[0].clientName;


    lbldetStatus.innerHTML = dataRows[0].Status;
    lblDetSubject.innerHTML = dataRows[0].Subject;
    lbldetType.innerHTML = dataRows[0].Type;
    lbldetDueDate.innerHTML = dataRows[0].DueDate + " " + dataRows[0].taskTime;
    lbldetContactName.innerHTML = dataRows[0].ContactName;
    lbldetContactEmail.innerHTML = dataRows[0].ContactEmail;

    lbldetContactMobile.innerHTML = dataRows[0].ContactMobile;
    lbldetContactPhone.innerHTML = dataRows[0].ContactPhone;
    lblDetDepartmentName.innerHTML = dataRows[0].DepartmentName;

    lbldetAssignTo.innerHTML = dataRows[0].AssignTo;
    lbldetDescription.innerHTML = dataRows[0].Description;
    lbldetDescription.title = dataRows[0].Description;
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//..............................................Editing task from here ..............................................//

function CallEdit_TaskMethod(CompanyID, ClientIDTa, id) {
    var ID = id;
    Load_AllDropdownlist(CompanyID, ClientID);
    CRM_Edit_Task(ID);
}

function CRM_Edit_Task(id) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_Edit_Task",
        data: GetTask_Editdata(id),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTask_AfterEdit,
        error: ServiceFailed
    });
}

function GetTask_Editdata(id) {

    var FinalStringofEditNote = ' { "id" : "' + id + '" } '
    return FinalStringofEditNote;
}

function BindTask_AfterEdit(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var ddlEditsubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditsubject");
    var ddlEditassignto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditassignto");
    var ddlEditStataus = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditStataus");
    var ddlEditPriority = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditPriority");
    var ddlEditContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditContact");
    var txtEditDueDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditDueDate");
    var txtEditTaskDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditTaskDesc");
    var dateInput_text = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker1").get_dateInput();
    var ContactPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditTaskContactPhone");
    var ContactMobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EdirTaskContactMobile");
    var DepartmentPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditDepartmentPhone");

    ContactId = ddlEditContact;
    EditConatctPhone = ContactPhone;
    EditContactMobile = ContactMobile;
    EditDeptPhone = DepartmentPhone;


    for (i = 0; i < ddlEditsubject.length; i++) {
        if (ddlEditsubject.options[i].text == dataRows[0].Subject) {
            ddlEditsubject.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditassignto.length; i++) {
        if (ddlEditassignto.options[i].value == dataRows[0].AssignToUserId) {
            ddlEditassignto.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditStataus.length; i++) {
        if (ddlEditStataus.options[i].text == dataRows[0].TaskStatus) {
            ddlEditStataus.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditPriority.length; i++) {
        if (ddlEditPriority.options[i].text == dataRows[0].Priority) {
            ddlEditPriority.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditContact.length; i++) {
        if (ddlEditContact.options[i].value == dataRows[0].ContactId) {
            ddlEditContact.selectedIndex = i;
        }
    }
    if (dataRows[0].Contactphone != "") {
        ContactPhone.value = dataRows[0].Contactphone;
        ContactPhone.disabled = true;
    }
    else {
        ContactPhone.disabled = false;
    }
    if (dataRows[0].ContactMobile != "") {
        ContactMobile.value = dataRows[0].ContactMobile;
        ContactMobile.disabled = true;
    }
    else {
        ContactMobile.disabled = false;
    }
    if (dataRows[0].DepartmentPhone != "") {
        DepartmentPhone.value = dataRows[0].DepartmentPhone;
        DepartmentPhone.disabled = true;
    }
    else {
        DepartmentPhone.disabled = false;
    }
    ddlEditContact.onchange = EditSelectContact;
    txtEditDueDate.value = dataRows[0].DueDate;
    dateInput_text.set_value(dataRows[0].TaskTime);
    txtEditTaskDesc.value = dataRows[0].Description;

    //..........................For details........................

    var lbldetStatus = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetStatus");
    var lblDetSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetSubject");
    var lbldetType = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetType");
    var lbldetDueDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDueDate");
    var lbldetContactName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactName");
    var lbldetContactEmail = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetContactEmail");

    var lbldetContactMobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactMobile");
    var lbldetContactPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactPhone");
    var lblDetDepartmentName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetDepartmentName");

    var lbldetAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetAssignTo");
    var lbldetDescription = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDescription");
    var lbl_DeptPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbl_DeptPhone");

    var lbldetCompanyName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetCompanyName");
    lbldetCompanyName.innerHTML = dataRows[0].clientName;


    lbldetStatus.innerHTML = dataRows[0].TaskStatus;
    lblDetSubject.innerHTML = dataRows[0].Subject;
    lblDetSubject.title = dataRows[0].Subject;
    lbldetType.innerHTML = "Task";
    lbldetDueDate.innerHTML = dataRows[0].DueDate + " " + dataRows[0].TaskTime;
    lbldetContactName.innerHTML = dataRows[0].ContactName;
    lbldetContactEmail.innerHTML = dataRows[0].ContactEmail;

    lbldetContactMobile.innerHTML = dataRows[0].ContactMobile;
    lbldetContactPhone.innerHTML = dataRows[0].Contactphone;
    lblDetDepartmentName.innerHTML = dataRows[0].DepartmentName;

    lbldetAssignTo.innerHTML = dataRows[0].AssignTo;
    lbldetDescription.innerHTML = dataRows[0].Description;
    lbldetDescription.title = dataRows[0].Description;
    lbl_DeptPhone.innerHTML = dataRows[0].DepartmentPhone;
    lbl_DeptPhone.title = dataRows[0].DepartmentPhone;
    if (lbldetStatus.innerHTML == "Completed") {
        document.getElementById("ctl00_ContentPlaceHolder1_Client_btnmoreactionpopup").style.display = "none";
    }
    document.getElementById("div_loadingtaskcall").style.display = "none";
    document.getElementById("div_loadingtask_onedit").style.display = "none";
    document.getElementById("div_loadingcall_onedit").style.display = "none";
}

//.........................................................................Inserting edit event subject from here..........................

function CallInsert_EventSubjectMethod(Subject, CompanyID, Language) {
    var txtEventSubj = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditEventSubject");

    CRM_Insert_Event_Subject(txtEventSubj.value, CompanyID, Language);
    txtEventSubj.value = "";
}

function CRM_Insert_Event_Subject(Subject, CompanyID, Language) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_subject_Insert",
        data: GetInputEditeventSubject(Subject, CompanyID, Language),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindEditEvent_Subject,
        error: ServiceFailed
    });
}

function GetInputEditeventSubject(Subject, CompanyID, Language) {

    var FinalString = ' { "Subject" : "' + Subject + '" , "CompanyID" : "' + CompanyID + '" , "Language" : "' + Language + '" } '
    return FinalString;
}

function BindEditEvent_Subject(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {
        alert("Subject already exist, choose another subject");

        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditEventSubject").focus();
        return;
    }
    for (var i = 0; i < dataRows.length; i++) {

        if (dataRows[i].sampleSubject != "") {

            var opt = document.createElement("option");
            var ddlEventsSub = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditEventSubject");

            ddlEventsSub.options.add(opt);
            opt.text = dataRows[i].sampleSubject;
            opt.value = dataRows[i].sampleSubject;
            ddlEventsSub.selectedIndex = ddlEventsSub.length - 1;
            var actualvalue = ddlEventsSub.options[ddlEventsSub.selectedIndex].value;
        }
    }
}


function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//.................................................Inserting call from here ...........................................................

var CallAssignTo;
var CallContact;

function Insert_Call(CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, CreatedBy, NotespageNummber, CallEndDate, ParentType, ParentID) {

    NotespageNummberIndex = 1;

    var ddlCallSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubject");
    var ddlCallType = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallType");
    var ddlCallPurpose = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallPurpose");
    var ddlCallAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");
    var RdoCurrentCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoCurrentCall");
    var RdoCompletedCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoCompletedCall");
    var RdoScheduledCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoScheduledCall");
    var txtcallstartdate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallstartdate");

    var txtcallMinute = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallMinute");
    var txtcallSecond = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallSecond");
    var txtcallresult = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallresult");
    var ddlowner = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlowner");
    var txtCallDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallDesc");
    var ChkBillable = document.getElementById("ctl00_ContentPlaceHolder1_Client_ChkBillable");

    var Contact_Phone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactPhone").value;
    var Contact_Mobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactMobile").value;
    var Department_Phone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallDepartmentPhone").value;

    ddlCallType.options[ddlCallType.selectedIndex].text;
    var finalCallType = ddlCallType.options[ddlCallType.selectedIndex].text;

    ddlCallPurpose.options[ddlCallPurpose.selectedIndex].text;
    var finalCallPurpose = ddlCallPurpose.options[ddlCallPurpose.selectedIndex].value;

    var ddlCallDetailsType = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallDetailsType");
    ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].text;
    var CallDetailsType = ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].value;

    var CallDetail = "";

    if (CallDetailsType == "2") {
        CallDetail = "completed";
    }
    if (CallDetailsType == "3") {
        CallDetail = "scheduled";
    }

    var finalContactID = 0;

    if (ddlCallAssignTo.options.length == 0) {
        finalContactID = 0;
    }
    else {
        ddlCallAssignTo.options[ddlCallAssignTo.selectedIndex].text;
        finalContactID = ddlCallAssignTo.options[ddlCallAssignTo.selectedIndex].value;
    }
    CallContact = finalContactID;
    var FinalCallMinSec = "";
    var CallMinSec = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker4").get_dateInput();
    FinalCallMinSec = CallMinSec.get_value();

    ddlowner.options[ddlowner.selectedIndex].text;
    var finalowner = ddlowner.options[ddlowner.selectedIndex].value;

    CallAssignTo = finalowner;

    var billable = false;
    if (ChkBillable.checked == true) {
        billable = true;
    }
    else {
        billable = false;
    }

    ddlCallSubject.options[ddlCallSubject.selectedIndex].text;
    var finalCallSubject = ddlCallSubject.options[ddlCallSubject.selectedIndex].text;

    var hdnCallFollowParentID = 0;
    var hdnCallFollowParentType = "";
    hdnCallFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentID");
    hdnCallFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentType");


    if (hdnCallFollowParentID.value == "") {
        hdnCallFollowParentID.value = 0;
    }
    if (hdnCallFollowParentType.value == "") {
        hdnCallFollowParentType.value = "";
    }
    CRM_Insert_Call(CompanyID, ClientID, SpecialEncode(finalCallSubject), finalCallType, finalCallPurpose, CallDetail, finalContactID, txtcallstartdate.value, FinalCallMinSec,
        txtcallMinute.value, txtcallSecond.value, txtcallresult.value, finalowner, txtCallDesc.value, billable, CreatedBy, NotespageNummberIndex, CallEndDate,
        hdnCallFollowParentType.value, hdnCallFollowParentID.value, 0, '', Contact_Phone, Contact_Mobile, Department_Phone);


    var hdnTaskFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentID");
    var hdnTaskFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentType");
    hdnTaskFollowParentID.value = "";
    hdnTaskFollowParentType.value = "";
    hdnCallFollowParentID.value = "";
    hdnCallFollowParentType.value = "";

}

function CRM_Insert_Call(CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, CreatedBy, NotespageNummber, CallEndDate, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/CrmCallInsert",
        data: GetCrmCall(CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, CreatedBy, NotespageNummber, CallEndDate, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCalls,
        error: ServiceFailed
    });
}

function GetCrmCall(CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, CreatedBy, NotespageNummber, CallEndDate, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone) {
    debugger;
    Description = Description.replace(/\"/g, "\\\"");

    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "ClientID" : "' + ClientID + '" , "Subject" : "' + Subject + '" , "CallType" : "' + CallType + '" , "CallPurpose" : "' + CallPurpose + '" , "CallDetails" : "' + CallDetails + '" , "ContactID" : "' + ContactID + '" , "CallStartdate" : "' + CallStartdate + '" , "CallStartTime" : "' + CallStartTime + '" , "CallDurationMinutes" : "' + CallDurationMinutes + '" , "CallDurationSeconds" : "' + CallDurationSeconds + '" , "CallResult" : "' + CallResult + '" , "AssignedTo" : "' + AssignedTo + '" , "Description" : "' + Description + '" , "isBillabel" : "' + isBillabel + '" , "CreatedBy" : "' + CreatedBy + '" , "NotespageNummber" : "' + NotespageNummber + '" , "CallEndDate" : "' + CallEndDate + '" , "ParentType" : "' + ParentType + '" , "ParentID" : "' + ParentID + '"  , "ModuleID" : "' + ModuleID + '" , "ModuleName" : "' + ModuleName + '", "Contact_Phone" : "' + Contact_Phone + '", "Contact_Mobile" : "' + Contact_Mobile + '", "Department_Phone" : "' + Department_Phone + '" } '
    return FinalString;
}

function BindCalls(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var AddNewTaskBtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkAddTask");
    var lnkEventbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkEvent");
    var lnkcallbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkcall");

    document.getElementById("DivCallPopup").style.display = "none";
    var hdnTaskFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentID");
    var hdnTaskFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentType");
    var hdnCallFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentID");
    var hdnCallFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentType");

    var ddlassigneto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlassigneto");
    var ddlowner = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlowner");
    var ddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var ddlCallAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");

    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");
    var ddlCallAssignTo1 = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    lblOpenActivities.innerHTML = "";

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");

    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    lblcloseActivity.innerHTML = "";

    for (var i = 0; i < dataRows.length; i++) {
        lblOpenActivities.innerHTML = dataRows[i].AllCalls;
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}
//...........................................................................Editing call from here .......................................................


function Edit_CallMethod(CompanyID, ClientID, id) {
    var ID = id;
    Load_AllDropdownlist(CompanyID, ClientID);
    CRM_Edit_CallMet(ID);
}

function CRM_Edit_CallMet(id) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_Edit_Call",
        data: GetCall_Editdatas(id),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCall_Edit,
        error: ServiceFailed
    });
}

function GetCall_Editdatas(id) {
    var FinalStringofEditNote = ' { "id" : "' + id + '" } '
    return FinalStringofEditNote;
}

function BindCall_Edit(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        alert('no more data to load');
        return;
    }

    var ddlCallSubjectEdit = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubjectEdit");

    var ddlEditCallType = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallType");
    var ddleditCallPurpose = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddleditCallPurpose");
    var ddlEditCallContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallContact");
    var ddlEditCallDetails = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallDetails");
    var txtEditCallStartdate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallStartdate");
    var txtEditCallMin = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallMin");
    var txtEditCallSec = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallSec");
    var txtEditcallressult = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditcallressult");
    var ddlEditowner = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditowner");
    var txtEditCallDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallDesc");
    var ChkEditBillable = document.getElementById("ctl00_ContentPlaceHolder1_Client_ChkEditBillable");

    var ContactPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditCallContactPhone");
    var ContactMobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditCallContactMobile");
    var DepartmentPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditCallDepartmentPhone");

    ContactId = ddlEditCallContact;
    EditConatctPhone = ContactPhone;
    EditContactMobile = ContactMobile;
    EditDeptPhone = DepartmentPhone;

    for (i = 0; i < ddlCallSubjectEdit.length; i++) {
        if (ddlCallSubjectEdit.options[i].text == dataRows[0].Subject) {
            ddlCallSubjectEdit.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditCallType.length; i++) {
        if (ddlEditCallType.options[i].text == dataRows[0].CallType) {
            ddlEditCallType.selectedIndex = i;
        }
    }

    for (i = 0; i < ddleditCallPurpose.length; i++) {
        if (ddleditCallPurpose.options[i].value == dataRows[0].CallPurpose) {
            ddleditCallPurpose.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditCallContact.length; i++) {
        if (ddlEditCallContact.options[i].value == dataRows[0].ContactID) {
            ddlEditCallContact.selectedIndex = i;
        }
    }

    if (dataRows[0].CallDetails == "Completed") {
        ddlEditCallDetails.value = 2;
        document.getElementById("EditDurationStar").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_btnmoreactionpopup").style.display = "none";
    }
    if (dataRows[0].CallDetails == "Scheduled") {
        ddlEditCallDetails.value = 3;
        document.getElementById("EditDurationStar").style.display = "none";
    }

    txtEditCallStartdate.value = dataRows[0].CallStartdate;

    var EditCallHoMin = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker5").get_dateInput();

    EditCallHoMin.set_value(dataRows[0].CallStartTime);

    if (dataRows[0].CallDurationMinutes == 0) {
        txtEditCallMin.value = "";
        txtEditCallSec.value = "";
    }
    else {
        txtEditCallMin.value = dataRows[0].CallDurationMinutes;
        txtEditCallSec.value = dataRows[0].CallDurationSeconds;
    }

    txtEditcallressult.value = dataRows[0].CallResult;

    for (i = 0; i < ddlEditowner.length; i++) {
        if (ddlEditowner.options[i].value == dataRows[0].AssignedTo) {
            ddlEditowner.selectedIndex = i;
        }
    }

    txtEditCallDesc.value = dataRows[0].Description;
    ddlEditCallContact.onchange = EditSelectContact;

    if (dataRows[0].isBillabel == "True") {
        ChkEditBillable.checked = true;
    }
    else {
        ChkEditBillable.checked = false;
    }

    if (dataRows[0].ContactPhone != "") {
        ContactPhone.value = dataRows[0].Contactphone;
        ContactPhone.disabled = true;
    }
    else {
        ContactPhone.disabled = false;
    }
    if (dataRows[0].ContactMobile != "") {
        ContactMobile.value = dataRows[0].ContactMobile;
        ContactMobile.disabled = true;
    }
    else {
        ContactMobile.disabled = false;
    }
    if (dataRows[0].DepartmentPhone != "") {
        DepartmentPhone.value = dataRows[0].DepartmentPhone;
        DepartmentPhone.disabled = true;
    }
    else {
        DepartmentPhone.disabled = false;
    }
    //..........................For details........................

    var lbldetStatus = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetStatus");
    var lblDetSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetSubject");
    var lbldetType = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetType");
    var lbldetDueDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDueDate");
    
    var lbldetContactName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactName");
    var lbldetContactEmail = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetContactEmail");

    var lbldetContactMobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactMobile");
    var lbldetContactPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactPhone");
    var lblDetDepartmentName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetDepartmentName");

    var lbldetAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetAssignTo");
    var lbldetDescription = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDescription");
    var lbl_DeptPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbl_DeptPhone");

    var lbldetCompanyName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetCompanyName");
    lbldetCompanyName.innerHTML = dataRows[0].clientName;

    lbldetStatus.innerHTML = dataRows[0].CallDetails;
    lblDetSubject.innerHTML = dataRows[0].Subject;
    lblDetSubject.title = dataRows[0].Subject;
    lbldetType.innerHTML = "Call";
    lbldetDueDate.innerHTML = dataRows[0].CallStartdate + " " + dataRows[0].CallStartTime;
    
    lbldetContactName.innerHTML = dataRows[0].ContactName;
    lbldetContactEmail.innerHTML = dataRows[0].ContactEmail;

    lbldetContactMobile.innerHTML = dataRows[0].ContactMobile;
    lbldetContactPhone.innerHTML = dataRows[0].Contactphone;
    lblDetDepartmentName.innerHTML = dataRows[0].DepartmentName;

    lbldetAssignTo.innerHTML = dataRows[0].AssignTo;
    lbldetDescription.innerHTML = dataRows[0].Description;
    lbldetDescription.title = dataRows[0].Description;
    lbl_DeptPhone.innerHTML = dataRows[0].DepartmentPhone;
    lbl_DeptPhone.title = dataRows[0].DepartmentPhone;
    document.getElementById("div_loadingtaskcall").style.display = "none";
    document.getElementById("div_loadingtask_onedit").style.display = "none";
    document.getElementById("div_loadingcall_onedit").style.display = "none";
}

//.........................................................................Updating call .................................................
var EditCallAssignTo;
var EditCallContact;

function Update_Call(CallID, CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, LastUpdatedBy, NotespageNummber, CallEnddate) {

    NotespageNummberIndex = 1;

    var ddlCallSubjectEdit = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubjectEdit");

    var ddlEditCallType = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallType");
    var ddleditCallPurpose = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddleditCallPurpose");
    var ddlEditCallContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallContact");
    var ddlEditCallDetails = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallDetails");
    var txtEditCallStartdate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallStartdate");
    var ddlEditCallTime = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallTime");
    var txtEditCallMin = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallMin");
    var txtEditCallSec = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallSec");
    var txtEditcallressult = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditcallressult");
    var ddlEditowner = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditowner");
    var txtEditCallDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallDesc");
    var ChkEditBillable = document.getElementById("ctl00_ContentPlaceHolder1_Client_ChkEditBillable");

    var Contact_Phone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditCallContactPhone").value;
    var Contact_Mobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditCallContactMobile").value;
    var Department_Phone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_EditCallDepartmentPhone").value;

    ddlCallSubjectEdit.options[ddlCallSubjectEdit.selectedIndex].text;
    var finalddlCallSubjectEdit = ddlCallSubjectEdit.options[ddlCallSubjectEdit.selectedIndex].text;

    ddlEditCallType.options[ddlEditCallType.selectedIndex].text;
    var finalddlEditCallType = ddlEditCallType.options[ddlEditCallType.selectedIndex].text;

    ddleditCallPurpose.options[ddleditCallPurpose.selectedIndex].text;
    var finaleditCallPurpose = ddleditCallPurpose.options[ddleditCallPurpose.selectedIndex].value;

    ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].text;
    var CallEditDetailsType = ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].value;

    var EditCallDetail = "";

    if (CallEditDetailsType == "2") {
        EditCallDetail = "completed";
    }
    if (CallEditDetailsType == "3") {
        EditCallDetail = "scheduled";
    }

    var finalEditContactID = 0;
    if (ddlEditCallContact.options.length == 0) {
        finalEditContactID = 0;
    }
    else {
        ddlEditCallContact.options[ddlEditCallContact.selectedIndex].text;
        finalEditContactID = ddlEditCallContact.options[ddlEditCallContact.selectedIndex].value;
    }
    EditCallContact = finalEditContactID;

    var ddleditCallHours = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddleditCallHours");
    var ddleditCallSecond = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddleditCallSecond");

    var EditFinalCallMinSec = "";
    var EditCallHoMin = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker5").get_dateInput();
    EditFinalCallMinSec = EditCallHoMin.get_value();

    ddlEditowner.options[ddlEditowner.selectedIndex].text;
    var finalEditowner = ddlEditowner.options[ddlEditowner.selectedIndex].value;
    EditCallAssignTo = finalEditowner;

    var Editbillable = false;
    if (ChkEditBillable.checked == true) {
        Editbillable = true;
    }
    else {
        Editbillable = false;
    }

    CRM_Update_Call(CallID, CompanyID, ClientID, SpecialEncode(finalddlCallSubjectEdit), finalddlEditCallType, finaleditCallPurpose, EditCallDetail, finalEditContactID,
        txtEditCallStartdate.value, EditFinalCallMinSec, txtEditCallMin.value, txtEditCallSec.value, txtEditcallressult.value, finalEditowner, txtEditCallDesc.value,
        Editbillable, LastUpdatedBy, NotespageNummberIndex, CallEnddate, Contact_Phone, Contact_Mobile, Department_Phone);
}

function CRM_Update_Call(CallID, CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes,
    CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, LastUpdatedBy, NotespageNummber, CallEnddate, Contact_Phone, Contact_Mobile, Department_Phone) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/CrmCallUpdate",
        data: GetCrmCallUpdate(CallID, CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes,
            CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, LastUpdatedBy, NotespageNummber, CallEnddate, Contact_Phone, Contact_Mobile, Department_Phone),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCallsUpdated,
        error: ServiceFailed
    });
}

function GetCrmCallUpdate(CallID, CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes,
    CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, LastUpdatedBy, NotespageNummber, CallEnddate, Contact_Phone, Contact_Mobile, Department_Phone) {
    Description = Description.replace(/\"/g, "\\\"");
    var FinalString = ' { "CallID" : "' + CallID + '" , "CompanyID" : "' + CompanyID + '" , "ClientID" : "' + ClientID + '" , "Subject" : "' + Subject + '" , "CallType" : "' +
        CallType + '" , "CallPurpose" : "' + CallPurpose + '" , "CallDetails" : "' + CallDetails + '" , "ContactID" : "' + ContactID + '" , "CallStartdate" : "' + CallStartdate +
        '" , "CallStartTime" : "' + CallStartTime + '" , "CallDurationMinutes" : "' + CallDurationMinutes + '" , "CallDurationSeconds" : "' + CallDurationSeconds +
        '" , "CallResult" : "' + CallResult + '" , "AssignedTo" : "' + AssignedTo + '" , "Description" : "' + Description + '" , "isBillabel" : "' + isBillabel +
        '" , "LastUpdatedBy" : "' + LastUpdatedBy + '" , "NotespageNummber" : "' + NotespageNummber + '" , "CallEnddate" : "' + CallEnddate +
        '" , "Contact_Phone" : "' + Contact_Phone + '", "Contact_Mobile" : "' + Contact_Mobile + '" , "Department_Phone" : "' + Department_Phone + '"  } '
    return FinalString;
}

function BindCallsUpdated(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var AddNewTaskBtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkAddTask");
    var lnkcallbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkcall");

    var hdnTaskFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentID");
    var hdnTaskFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentType");
    var hdnCallFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentID");
    var hdnCallFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentType");

    var Editddlassigneto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlassigneto");
    var Editddlowner = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlowner");
    var EditddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var EditddlCallAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");

    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");
    var ddlEditCallContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");

    document.getElementById("DivEditCallPopup").style.display = "none";
    document.getElementById("DivEditCallTimer").style.display = "none";

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    lblOpenActivities.innerHTML = "";
    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    lblcloseActivity.innerHTML = "";

    var lblAllOA = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllOA");
    lblAllOA.innerHTML = "";

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");
    notestitle.innerHTML = "";
    hdnprintNotes.value = "";

    for (var i = 0; i < dataRows.length; i++) {

        lblOpenActivities.innerHTML = dataRows[i].AllCalls;
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
        lblAllOA.innerHTML = dataRows[i].AllOA;

        notestitle.innerHTML = dataRows[i].AllNotes;
        hdnprintNotes.value = dataRows[i].AllNotes;


        //..........................For details........................

        var lbldetStatus = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetStatus");
        var lblDetSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetSubject");
        var lbldetType = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetType");
        var lbldetDueDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDueDate");
        var lbldetContactName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactName");
        var lbldetContactEmail = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetContactEmail");

        var lbldetContactMobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactMobile");
        var lbldetContactPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetContactPhone");
        var lblDetDepartmentName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblDetDepartmentName");

        var lbldetAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetAssignTo");
        var lbldetDescription = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDescription");

        var lbldetCompanyName = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetCompanyName");
        lbldetCompanyName.innerHTML = dataRows[0].clientName;


        lbldetStatus.innerHTML = dataRows[0].Status;
        lblDetSubject.innerHTML = dataRows[0].Subject;
        lbldetType.innerHTML = dataRows[0].Type;
        lbldetDueDate.innerHTML = dataRows[0].DueDate + " " + dataRows[0].taskTime;
        lbldetContactName.innerHTML = dataRows[0].ContactName;
        lbldetContactEmail.innerHTML = dataRows[0].ContactEmail;
        lbldetContactMobile.innerHTML = dataRows[0].ContacMobile;
        lbldetContactPhone.innerHTML = dataRows[0].ContactPhone;
        lblDetDepartmentName.innerHTML = dataRows[0].DepartmentName;

        lbldetAssignTo.innerHTML = dataRows[0].AssignTo;
        lbldetDescription.innerHTML = dataRows[0].Description;
        lbldetDescription.title = dataRows[0].Description;
    }

    crmtooltip();
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//...........................................................................Updating contact.............................................

function CallUpdate_Contact(CompanyID, clientID, ContactID, NotespageNummber) {
    NotespageNummberIndex = 1;

    CRM_Update_Contact(CompanyID, clientID, ContactID, NotespageNummberIndex);

    var lblContactMessage = document.getElementById('ctl00_ContentPlaceHolder1_Client_lblContactMessage');
    document.getElementById('DivCOntactMessage').style.display = "block";
    document.getElementById('imgcontactMsg').style.display = "none";
    lblContactMessage.innerHTML = "Contact updating...";

}

function CRM_Update_Contact(CompanyID, clientID, ContactID, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/CrmContactUpdate",
        data: GetCrmContact_Updated(CompanyID, clientID, ContactID, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindUpdatedContact,
        error: ServiceFailed
    });
}

function GetCrmContact_Updated(CompanyID, clientID, ContactID, NotespageNummber) {
    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "clientID" : "' + clientID + '" , "ContactID" : "' + ContactID + '" , "NotespageNummber" : "' + NotespageNummber + '"} '
    return FinalString;
}

function BindUpdatedContact(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var lbltopfivecontact = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbltopfivecontact");
    lbltopfivecontact.innerHTML = "";

    var ChangeContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblContactname");
    ChangeContact.innerHTML = "";

    var lblPhoneNumber = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblPhoneNumber");
    lblPhoneNumber.innerHTML = "";

    var lblBusinessEmail = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblBusinessEmail");
    lblBusinessEmail.innerHTML = "";

    for (var i = 0; i < dataRows.length; i++) {

        lbltopfivecontact.innerHTML = dataRows[i].AllContacts;
        ChangeContact.innerHTML = dataRows[i].ContactName;
        lblPhoneNumber.innerHTML = dataRows[i].Mobile;
        lblBusinessEmail.innerHTML = dataRows[i].Email;
    }

    var lblContactMessage = document.getElementById('ctl00_ContentPlaceHolder1_Client_lblContactMessage');
    document.getElementById('DivCOntactMessage').style.display = "block";
    document.getElementById('imgcontactMsg').style.display = "block";
    lblContactMessage.innerHTML = "Default Contact set Successfully";
    HideContactMessage();
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//..............................................................deleting closed activity...............................


function BindCloseActivity(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    lblcloseActivity.innerHTML = "";

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");
    notestitle.innerHTML = "";
    hdnprintNotes.value = "";

    var lblAllCl = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllCl");
    lblAllCl.innerHTML = "";

    for (var i = 0; i < dataRows.length; i++) {
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
        notestitle.innerHTML = dataRows[i].AllNotes;
        hdnprintNotes.value = dataRows[i].AllNotes;
        lblAllCl.innerHTML = dataRows[i].AllCL;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Delete_CloseActivities(id, CompanyId, Clientid, SectionName, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientDeleteCloseActivities",
        data: GetInput_CloseActivity(id, CompanyId, Clientid, SectionName, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCloseActivity,
        error: ServiceFailed
    });
}

function GetInput_CloseActivity(id, CompanyId, Clientid, SectionName, NotespageNummber) {

    var FinalString = ' { "id" : "' + id + '" , "CompanyId" : "' + CompanyId + '" , "Clientid" : "' + Clientid + '" , "SectionName" : "' + SectionName + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function CallDelete_CloseActivitiesMethod(id, CompanyId, Clientid, SectionName, NotespageNummber) {

    NotespageNummberIndex = 1;
    CRM_Delete_CloseActivities(id, CompanyId, Clientid, SectionName, NotespageNummberIndex);
}

///........................................................................inserting notes from contact.................................

function BindNotesForContact(data) {

    var lblNotes = document.getElementById("lblNotes");
    var dataRows = data.d;
    if (dataRows.length == 0) {
        lblNotes.innerHTML = "";
        return;
    }
    lblNotes.innerHTML = "";
    var selected = $("#hdnFileselected").val();
    var selected = 'yes';

    var fileInput = $('#ctl00_ContentPlaceHolder1_Client_file_upload');
    var fileData;
    if (fileInput.prop != null && fileInput.prop != undefined) {
        fileData = fileInput.prop("files")[0];
    }

    if (fileData != null) {

        var formData = new window.FormData();
        formData.append("file", fileData);
        $.ajax(
        {
            url: '../Upload.ashx?' + document.getElementById('txtfilename').value + '&Cid="' + CompanyID + '"&Aid= "' + dataRows[0].attachmentID + '"',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {

            },
            error: function (errorData) {
            }
        });
        BindAttachmentsForContact(dataRows);
    }
    else {
        BindAttachmentsForContact(dataRows);
    }
}

function BindAttachmentsForContact(dataRows) {


    var lblNotes = document.getElementById("lblNotes");
    var hdnprintNotes = document.getElementById("hdnprintNotesValue");
    lblNotes.innerHTML = "";
    hdnprintNotes.value = "";

    for (var i = 0; i < dataRows.length; i++) {
        lblNotes.innerHTML = dataRows[i].AllNotes;
        hdnprintNotes.value = dataRows[i].AllNotes;
    }

    $("#hdnFileselectedContact").val('');
    document.getElementById("file_uploadQueue").style.display = "none";
    document.getElementById('DivPrint').style.display = "block";
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}


function GetInputForContact(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID) {

    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "SectionName" : "' + SectionName + '", "SectionID" : "' + SectionID + '" , "FileName" : "' + FileName + '", "FileSize" : "' + FileSize + '", "CreateUserID" : "' + CreateUserID + '" , "Subject" : "' + Subject + '", "Title" : "' + Title + '" , "NotespageNummber" : "' + NotespageNummber + '" , "ContactID" : "' + ContactID + '" } '
    return FinalString;
}

function CallInsert_NotesMethodForContact(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID) {

    NotespageNummberIndex = 1;
    var NotesDesc = document.getElementById("txtNoteDesc");
    var Notestitle = document.getElementById("txtNoteTitle");
    CRM_Insert_NotesForContact(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, NotesDesc.value, Notestitle.value, NotespageNummberIndex, ContactID);

    NotesDesc.value = "";
    Notestitle.value = "";
}

function CRM_Insert_NotesForContact(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ContactNotesAdd",
        data: GetInputForContact(CompanyID, SectionName, SectionID, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindNotesForContact,
        error: ServiceFailed
    });
}

function SlideDivRight() {
    var duration = 650;
    $('#DivAddNote').hide('slide', { direction: 'right' }, duration, function () {
        $('#DivViewNote').show('slide', { direction: 'left' }, duration, function () {
            $('#DivViewNote').show(duration);
        });
    });
}

function CRM_Delete_ContactNotes(CompanyID, SectionID, attachmentId, NotespageNummber, ContactID) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientContactNotesDelete",
        data: GetContactnotes_deletedata(CompanyID, SectionID, attachmentId, NotespageNummber, ContactID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindContactNotes_afterdelete,
        error: ServiceFailed
    });
}

function CallDelete_ContactNotesMethod(CompanyID, SectionID, attachmentId, NotespageNummber, ContactID) {
    NotespageNummberIndex = 1;
    var NotesDesc = document.getElementById("txtNoteDesc");
    var Notestitle = document.getElementById("txtNoteTitle");

    CRM_Delete_ContactNotes(CompanyID, SectionID, attachmentId, NotespageNummberIndex, ContactID);
    NotesDesc.value = "";
    Notestitle.value = "";
}

function GetContactnotes_deletedata(CompanyID, SectionID, attachmentId, NotespageNummber, ContactID) {

    var FinalStringofDeleteNote = ' { "CompanyID" : "' + CompanyID + '" , "SectionID" : "' + SectionID + '", "attachmentId" : "' + attachmentId + '" , "NotespageNummber" : "' + NotespageNummber + '" , "ContactID" : "' + ContactID + '" } '
    return FinalStringofDeleteNote;
}

function BindContactNotes_afterdelete(data) {

    var notestitle = document.getElementById("lblNotes");
    var dataRows = data.d;
    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }
    notestitle.innerHTML = "";

    var hdnprintNotes = document.getElementById("hdnprintNotesValue");
    hdnprintNotes.value = "";

    for (var i = 0; i < dataRows.length; i++) {
        notestitle.innerHTML = dataRows[i].AllNotes;
        hdnprintNotes.value = dataRows[i].AllNotes;

        if (dataRows[i].AllNotes == "<div style='float:left;'><span style='font-weight:bold; margin-left:10px;'>No Notes Found!</span></div>") {
            document.getElementById('DivPrint').style.display = "none";
        }
    }
}

function CRM_ContactEdit_Notes(attachmentId) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientNotesEdit",
        data: GetContactnotes_Editdata(attachmentId),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindContactNotes_afterEdit,
        error: ServiceFailed
    });
}

function CallEdit_ContactNotesMethod(attachmentId) {

    CRM_ContactEdit_Notes(attachmentId);
}

function GetContactnotes_Editdata(attachmentId) {

    var FinalStringofEditNote = ' { "attachmentId" : "' + attachmentId + '" } '
    return FinalStringofEditNote;
}

function BindContactNotes_afterEdit(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var notesdesc = document.getElementById("txtNoteDesc");
    var NotesTitle = document.getElementById("txtNoteTitle");
    var OldFileName = document.getElementById("lblOldFile");
    var lblOldFileSize = document.getElementById("lblOldFileSize");
    document.getElementById("DivOldFile").style.display = "block";

    for (var i = 0; i < dataRows.length; i++) {

        notesdesc.innerHTML = dataRows[i].subject;
        notesdesc.value = dataRows[i].subject;
        NotesTitle.innerHTML = dataRows[i].title;
        NotesTitle.value = dataRows[i].title;

        OldFileName.innerHTML = dataRows[i].filename;
        OldFileName.setAttribute("onclick", "javascript:ViewAttachedFilesNew('" + dataRows[i].attachmentID + "','" + dataRows[i].companyId + "')");
        lblOldFileSize.innerHTML = dataRows[i].filsize;
        var OldFile = document.getElementById("lblOldFile");

        if (OldFile.innerHTML == "") {
            document.getElementById("lnkRemoveOldFile").style.display = "none";
        }
        else {
            document.getElementById("lnkRemoveOldFile").style.display = "block";
            document.getElementById("addfileDiv").style.display = "none";
        }
    }
}

function BindContactNotes_AfterUpdate(data) {

    var notestitle = document.getElementById("lblNotes");

    var dataRows = data.d;
    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }

    var selected = $("#hdnFileselectedContact").val();
    if (selected == 'yes') {

        $("#file_upload").fileUploadSettings('script', '../Upload.ashx?fnrename=' + document.getElementById('txtfilename').value + '&Cid="' + CompanyID + '"&Aid= "' + dataRows[0].attachmentID + '"');
        $('#file_upload').fileUploadStart();

        BindAttachmentsContactNot(dataRows);
        document.getElementById("DivUserNameNew").style.marginLeft = "1px";
    }
    else {
        BindAttachmentsContactNot(dataRows);
    }

    function BindAttachmentsContactNot(dataRows) {

        var notestitle = document.getElementById("lblNotes");
        var hdnprintNotes = document.getElementById("hdnprintNotesValue");
        notestitle.innerHTML = "";
        hdnprintNotes.value = "";

        for (var i = 0; i < dataRows.length; i++) {
            notestitle.innerHTML = dataRows[i].AllNotes;
            hdnprintNotes.value = dataRows[i].AllNotes;
        }
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function CRM_Update_ContactNotes(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, ContactID) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientContactNotesUpdate",
        data: GetInputUpdateCOntactNotes(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, ContactID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindContactNotes_AfterUpdate,
        error: ServiceFailed
    });
}

function GetInputUpdateCOntactNotes(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, ContactID) {

    var FinalString = ' { "attachmentId" : "' + attachID + '" , "CompanyID" : "' + CompanyID + '" , "SectionName" : "' + SectionName + '", "SectionID" : "' + SectionID + '" , "FileName" : "' + FileName + '", "FileSize" : "' + FileSize + '", "modifyUserID" : "' + modifyUserID + '" , "Subject" : "' + Subject + '", "Title" : "' + Title + '" , "NotespageNummber" : "' + NotespageNummber + '" , "ContactID" : "' + ContactID + '" } '
    return FinalString;
}

function Call_UpdateContactNotes(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, ContactID) {

    NotespageNummberIndex = 1;
    var NotesDesc = document.getElementById("txtNoteDesc");
    var Notestitle = document.getElementById("txtNoteTitle");
    var lblOldFile = document.getElementById("lblOldFile");


    CRM_Update_ContactNotes(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, NotesDesc.value, Notestitle.value, NotespageNummberIndex, ContactID);

    NotesDesc.value = "";
    Notestitle.value = "";
    lblOldFile.innerHTML = "";
    lnkRemoveOldFile = document.getElementById("lnkRemoveOldFile").style.display = "none";
}

//.........................................................................Other java......................................................

function Gototop() {
    $('html,body').scrollTop(0);
}

function Close_Edit_OpenActivities() {

    document.getElementById("DivtaskPopUpEdit").style.display = "none";
    document.getElementById("DivtaskEdit").style.display = "none";
    document.getElementById("divallnotesbckfade").style.display = "none";
}

function Close_Edit_CallPopup() {

    document.getElementById("DivEditCallPopup").style.display = "none";
    document.getElementById("DivEditCallTimer").style.display = "none";
    document.getElementById("divallnotesbckfade").style.display = "none";
}

function OpenEditSubjectDiv() {
    document.getElementById("DivEditTaskSubject").style.display = "block";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditSubject").value = '';
    document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditSubject").focus();
}


function CloseEditTaskPopupAddSubject() {

    document.getElementById("DivEditTaskSubject").style.display = "none";
    document.getElementById("DivEditSubjectAddValidations").style.display = "none";

}

function SlideLeftDivEditTask(id) {
    var duration = 400;

    $('#DivtaskEdit').hide('slide', { direction: 'left' }, duration, function () {
        $('#DivtaskEditSecond').show(duration);
    });
}

function SlideEditRightDivTask(id) {
    var duration = 400;
    $('#DivtaskEditSecond').hide('slide', { direction: 'right' }, duration, function () {

        $('#DivtaskEdit').show('slide', { direction: 'left' }, duration, function () {
            $('#DivtaskEdit').show(duration);
        });
    });
}

function validateNumberOnly(evt) {
    var charCode = (evt.which) ? evt.which : window.event.keyCode;

    if (charCode <= 13) {
        return true;
    }
    else {
        var keyChar = String.fromCharCode(charCode);
        var re = /[0-9]/
        return re.test(keyChar);
    }
}

function clearTaskValue() {

    document.getElementById('ctl00_ContentPlaceHolder1_Client_ddlsubject').selectedIndex = 0;
    document.getElementById('ctl00_ContentPlaceHolder1_Client_ddlstatus').selectedIndex = 4;
    document.getElementById('ctl00_ContentPlaceHolder1_Client_ddlpriority').selectedIndex = 3;
    document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNotesDesc').value = '';
    $find('ctl00_ContentPlaceHolder1_Client_RadTimePicker').get_dateInput().set_value("");
    document.getElementById('DivTaskMain').style.display = "block";

}

function clearNoteValue() {
    document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').value = "";
    document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNoteDesc').value = "";
    document.getElementById('addfileDiv').style.display = "none";
    document.getElementById('lftarrow').style.display = "none";
}

function ClerCallValue() {
    ddlCallType = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallType").selectedIndex = 1;
    ddlCallPurpose = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallPurpose").selectedIndex = 0;
    RdoCurrentCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoCurrentCall").checked = true;
    RdoCompletedCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoCompletedCall").checked = false;
    RdoScheduledCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoScheduledCall").checked = false;
    $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker4").get_dateInput().set_value("10:00 AM");
    txtcallMinute = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallMinute").value = '';
    txtcallSecond = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallSecond").value = '';
    txtcallresult = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallresult").value = '';
    txtCallDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallDesc").value = '';
    ChkBillable = document.getElementById("ctl00_ContentPlaceHolder1_Client_ChkBillable").checked = false;
}

function SlideLeftEditCallDiv(id) {
    var duration = 400;

    $('#DivEditCallTimer').hide('slide', { direction: 'left' }, duration, function () {
        $('#DivEditCallTimerSecond').show(duration);
    });
}

function SlideRightEditCallDiv(id) {
    var duration = 400;
    $('#DivEditCallTimerSecond').hide('slide', { direction: 'right' }, duration, function () {

        $('#DivEditCallTimer').show('slide', { direction: 'left' }, duration, function () {
            $('#DivEditCallTimer').show(duration);
        });
    });
}

function Closepopups() {
    document.getElementById("DivOpenSubject").style.display = "none";
    document.getElementById("DivNotesPopup").style.display = "none";
    document.getElementById("DivOpenContact").style.display = "none";
    document.getElementById("DivCallPopup").style.display = "none";
    document.getElementById("DivEditCallPopup").style.display = "none";
    document.getElementById("DivtaskPopUpEdit").style.display = "none";
    document.getElementById("DivEditTaskSubject").style.display = "none";
}

function CallRightDivSlideToLeft() {
    var duration = 400;
    $('#MainDivCallTimerSecond').hide('slide', { direction: 'right' }, duration, function () {

        $('#MainDivCallTimer').show('slide', { direction: 'left' }, duration, function () {
            $('#MainDivCallTimer').show(duration);
        });
    });
}


function DisplayNoneAllContant() {
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_ActivitiesMain").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_ClientMain").style.display = "block";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_DepartmentMain").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_CostcentreMain").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_ContactMain").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_AddressMain").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_b2bMain").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_ProductsMain").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_div_EmailMain").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_DivAnotherDesign").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnEdit").style.display = "block";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnDelete").style.display = "block";
}

function HideNotesMessage() {
    window.setTimeout(function () {
        var DivNotesMessage = document.getElementById('DivNotesMessage');

        if (DivNotesMessage != null) {
            DivNotesMessage.style.display = 'none';
        }
    }, 9000);
}


function HideOpenActivityMessage() {
    window.setTimeout(function () {
        var label = document.getElementById('DivlblSuccMesg');

        if (label != null) {
            label.style.display = 'none';
        }
    }, 9000);
}

function HideAllClMessage() {
    window.setTimeout(function () {
        var label = document.getElementById('DivAllClMsg');

        if (label != null) {
            label.style.display = 'none';
        }
    }, 9000);
}

function HideContactMessage() {
    window.setTimeout(function () {
        var label = document.getElementById('DivCOntactMessage');

        if (label != null) {
            label.style.display = 'none';
        }
    }, 9000);
}

function HideAllOAMessage() {
    window.setTimeout(function () {
        var label = document.getElementById('DivdeleteAllOA');

        if (label != null) {
            label.style.display = 'none';
        }
    }, 9000);
}
function HideSearchMSG() {
    window.setTimeout(function () {
        var label = document.getElementById('DivlblSuccMesg');

        if (label != null) {
            label.style.display = 'none';
        }
    }, 9000);
}

function AddContactNotes(contactid, ClientID) {
    var RadWindow_Paid = window.radopen(sitePath + "contact/contact_note_add.aspx?contactid=" + contactid + "&ClientID=" + ClientID, '400', '100');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    RadWindow_Paid.setSize(800, 450);
    RadWindow_Paid.center();
}

//.......................................................Delete task..................................................

function delete_TaskMethod(id, CompanyId, Clientid, SectionName, NotespageNummber) {
    NotespageNummberIndex = 1;
    CRM_Delete_Task(id, CompanyId, Clientid, SectionName, NotespageNummberIndex);
}

function CRM_Delete_Task(id, CompanyId, Clientid, SectionName, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientDeleteTask",
        data: GetInput_Task(id, CompanyId, Clientid, SectionName, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTaskActivity,
        error: ServiceFailed
    });
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function GetInput_Task(id, CompanyId, Clientid, SectionName, NotespageNummber) {
    var FinalString = ' { "id" : "' + id + '" , "CompanyId" : "' + CompanyId + '" , "Clientid" : "' + Clientid + '" , "SectionName" : "' + SectionName + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindTaskActivity(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    lblOpenActivities.innerHTML = "";
    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    lblcloseActivity.innerHTML = "";
    var lblAllOA = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllOA");
    lblAllOA.innerHTML = "";

    var lblAllCl = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllCl");
    lblAllCl.innerHTML = "";

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");
    var ddlEditStataus = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditStataus");
    for (var i = 0; i < dataRows.length; i++) {

        lblOpenActivities.innerHTML = dataRows[i].Alltask;
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
        lblAllOA.innerHTML = dataRows[i].AllOA;
        lblAllCl.innerHTML = dataRows[i].AllCL;
    }
}


//................................................Completed call

function CallComplete_Method(id, CompanyId, Clientid, SectionName, NotespageNummber) {
    NotespageNummberIndex = 1;

    CRM_Complete_Call(id, CompanyId, Clientid, SectionName, NotespageNummberIndex);
}

function CRM_Complete_Call(id, CompanyId, Clientid, SectionName, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientCallCompleted",
        data: GetInput_Complete_Call(id, CompanyId, Clientid, SectionName, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCompletedCall,
        error: ServiceFailed
    });
}


function GetInput_Complete_Call(id, CompanyId, Clientid, SectionName, NotespageNummber) {

    var FinalString = ' { "id" : "' + id + '" , "CompanyId" : "' + CompanyId + '" , "Clientid" : "' + Clientid + '" , "SectionName" : "' + SectionName + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindCompletedCall(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    lblOpenActivities.innerHTML = "";
    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    lblcloseActivity.innerHTML = "";

    var lblAllOA = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllOA");
    lblAllOA.innerHTML = "";

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");

    for (var i = 0; i < dataRows.length; i++) {

        lblOpenActivities.innerHTML = dataRows[i].Alltask;
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
        lblAllOA.innerHTML = dataRows[i].AllOA;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function HideMoreNotesByJs(companyId, sectionid) {

    NotespageNummberIndex = NotespageNummberIndex - 4;
    CRM_Load_Hide_Notes(companyId, sectionid, NotespageNummberIndex);
}

function CRM_Load_Hide_Notes(companyId, sectionid, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadHideMoreNotes",
        data: GetInputLoad_Hide(companyId, sectionid, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindHideNotes,
        error: ServiceFailed
    });
}

function GetInputLoad_Hide(companyId, sectionid, NotespageNummber) {

    var FinalString = ' { "companyId" : "' + companyId + '" , "sectionid" : "' + sectionid + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindHideNotes(data) {

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    notestitle.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        notestitle.innerHTML = dataRows[i].AllNotes;
    }
    document.getElementById("DivHideMoreNotes").style.display = "block";
    if (NotespageNummberIndex == 1) {
        document.getElementById("DivHideMoreNotes").style.display = "none";
    }
    crmtooltip();
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}


function HideMoreOAByJs(ClientID, CompanyId) {

    NotespageNummberIndexOA = NotespageNummberIndexOA - 4;
    CRM_Load_Hide_OA(ClientID, CompanyId, NotespageNummberIndexOA);
}

function CRM_Load_Hide_OA(ClientID, CompanyId, NotespageNummber) {


    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadHideOpenActivity",
        data: GetInputLoad_OA_Hide(ClientID, CompanyId, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindHideOpenActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_OA_Hide(ClientID, CompanyId, NotespageNummber) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindHideOpenActivity(data) {

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblOpenActivities.innerHTML = "";
        return;
    }

    lblOpenActivities.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        lblOpenActivities.innerHTML = dataRows[i].Alltask;
    }
    document.getElementById("DivHideMoreOA").style.display = "block";
    if (NotespageNummberIndexOA == 1) {
        document.getElementById("DivHideMoreOA").style.display = "none";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function LoadHideCloseActivity(ClientID, CompanyId) {

    NotespageNummberIndexCL = NotespageNummberIndexCL - 4;
    CRM_Hide_More_CA(ClientID, CompanyId, NotespageNummberIndexCL);
}

function CRM_Hide_More_CA(ClientID, CompanyId, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadHideCloseActivity",
        data: GetInputLoad_Hide_CA(ClientID, CompanyId, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindHideCloseActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_Hide_CA(ClientID, CompanyId, NotespageNummber) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindHideCloseActivity(data) {

    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblcloseActivity.innerHTML = "";
        return;
    }

    lblcloseActivity.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
    }

    document.getElementById("DivHideMoreCloAct").style.display = "block";
    if (NotespageNummberIndexCL == 1) {
        document.getElementById("DivHideMoreCloAct").style.display = "none";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}


function LoadHideContacts(ClientID, NotespageNummber) {

    NotespageNummberIndexCon = NotespageNummberIndexCon - 4;
    CRM_Load_Hide_Contacts(ClientID, NotespageNummberIndex);
}

function CRM_Load_Hide_Contacts(ClientID, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadHideContacts",
        data: GetInputHide_Contacts(ClientID, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindHideContact,
        error: ServiceFailed

    });
}

function GetInputHide_Contacts(ClientID, NotespageNummber) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindHideContact(data) {

    var lbltopfivecontact = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbltopfivecontact");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lbltopfivecontact.innerHTML = "";
        return;
    }

    lbltopfivecontact.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lbltopfivecontact.innerHTML = dataRows[i].AllContacts;
    }

    document.getElementById("DivHideMoreContactNew").style.display = "block";
    if (NotespageNummberIndexCon == 1) {
        document.getElementById("DivHideMoreContactNew").style.display = "none";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//...........................................Insert call subject ................................................//

function CallInsert_CallSubjectMethod(CompanyID, CallSubject, Default, UserID) {

    var CallSub = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallSubjects");
    CRM_Insert_Call_Subject(CompanyID, SpecialEncode(CallSub.value), 'False', UserID);
    CallSub.value = "";
}

function CRM_Insert_Call_Subject(CompanyID, CallSubject, Default, UserID) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_Callsubjec_Insert",
        data: GetInputCallSubject(CompanyID, CallSubject, Default, UserID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCall_Subject,
        error: ServiceFailed
    });
}

function GetInputCallSubject(CompanyID, CallSubject, Default, UserID) {

    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "CallSubject" : "' + CallSubject + '" , "Default" : "' + Default + '" , "UserID" : "' + UserID + '" } '
    return FinalString;
}


function BindCall_Subject(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {

        alert("Subject already exist, choose another subject");
        document.getElementById("DivCallSubjects").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallSubjects").focus();
        return;
    }
    for (var i = 0; i < dataRows.length; i++) {

        if (dataRows[i].StatusTitle != "") {

            document.getElementById("DivCallSubjects").style.display = "none";

            var opt = document.createElement("option");
            var ddlCallSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubject");
            ddlCallSubject.options.add(opt);

            opt.text = dataRows[i].StatusTitle;
            opt.value = dataRows[i].StatusTitle;
            ddlCallSubject.selectedIndex = ddlCallSubject.length - 1;
            var actualvalue = ddlCallSubject.options[ddlCallSubject.selectedIndex].value;


            var opt = document.createElement("option");
            var ddlCallSubjectEdit = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubjectEdit");
            ddlCallSubjectEdit.options.add(opt);

            opt.text = dataRows[i].StatusTitle;
            opt.value = dataRows[i].StatusTitle;
            ddlCallSubjectEdit.selectedIndex = ddlCallSubjectEdit.length - 1;
            var actualvalue = ddlCallSubjectEdit.options[ddlCallSubjectEdit.selectedIndex].value;
        }
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//.........................................Details.............................


function Callmethid_SelectDetailsOA(CompanyID, CallSubject, Default, UserID) {

    var CallSub = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallSubjects");
    CRM_Insert_Call_Subject(CompanyID, CallSub.value, 'False', UserID);
    CallSub.value = "";
}


function CRM_Insert_Call_Subject(CompanyID, CallSubject, Default, UserID) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_Callsubjec_Insert",
        data: GetInputCallSubject(CompanyID, CallSubject, Default, UserID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCall_Subject,
        error: ServiceFailed
    });
}

function GetInputCallSubject(CompanyID, CallSubject, Default, UserID) {

    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "CallSubject" : "' + CallSubject + '" , "Default" : "' + Default + '" , "UserID" : "' + UserID + '" } '
    return FinalString;
}

function BindCall_Subject(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {

        alert("Subject already exist, choose another subject");
        document.getElementById("DivCallSubjects").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallSubjects").focus();
        return;
    }
    for (var i = 0; i < dataRows.length; i++) {

        if (dataRows[i].StatusTitle != "") {

            document.getElementById("DivCallSubjects").style.display = "none";

            var opt = document.createElement("option");
            var ddlCallSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubject");
            ddlCallSubject.options.add(opt);

            opt.text = dataRows[i].StatusTitle;
            opt.value = dataRows[i].StatusTitle;
            ddlCallSubject.selectedIndex = ddlCallSubject.length - 1;
            var actualvalue = ddlCallSubject.options[ddlCallSubject.selectedIndex].value;


            var opt = document.createElement("option");
            var ddlCallSubjectEdit = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubjectEdit");
            ddlCallSubjectEdit.options.add(opt);

            opt.text = dataRows[i].StatusTitle;
            opt.value = dataRows[i].StatusTitle;
            ddlCallSubjectEdit.selectedIndex = ddlCallSubjectEdit.length - 1;
            var actualvalue = ddlCallSubjectEdit.options[ddlCallSubjectEdit.selectedIndex].value;
        }
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//.......................................Search panel..................................................................


function OpenSearchPanel() {

    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnSearch").style.display = "none";
    document.getElementById("SearchPanel").style.display = "block";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant").value = "";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant").focus();
    document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate").value = "";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate").value = "";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Call").checked = true;
    document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Task").checked = true;
    document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Note").checked = true;
}

function CloseSearchPanel() {
    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnSearch").style.display = "block";
    document.getElementById("SearchPanel").style.display = "none";
}

function Call_SearchMethod(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber) {
    NotespageNummberIndex = 1;

    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    CRM_SearchMethod(CompanyID, ClientID, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value, NotespageNummberIndex);
}

function CRM_SearchMethod(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/SearchOpenActivities",
        data: GetInput_Search(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindSearchData,
        error: ServiceFailed
    });
}

function GetInput_Search(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber) {
    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "ClientID" : "' + ClientID + '" , "MultipalSearchText" : "' + MultipalSearchText + '" , "StartDate" : "' + StartDate + '" , "Enddate" : "' + Enddate + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindSearchData(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    lblOpenActivities.innerHTML = "";
    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    lblcloseActivity.innerHTML = "";
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");
    notestitle.innerHTML = "";

    for (var i = 0; i < dataRows.length; i++) {
        lblOpenActivities.innerHTML = dataRows[i].AllOpenActivities;
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
        notestitle.innerHTML = dataRows[i].AllNotes;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function Call_NotesSearchMethod(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber) {

    NotespageNummberIndex = 1;
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    CRM_NotesSearchMethod(CompanyID, ClientID, SpecialEncode(TxtMultipalSearch.value), TxtStartDate.value, TxtEndDate.value, NotespageNummberIndex);
}

function CRM_NotesSearchMethod(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/SearchNotes",
        data: GetInput_NotesSearch(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindNotesSearchData,
        error: ServiceFailed
    });
}

function GetInput_NotesSearch(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber) {
    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "ClientID" : "' + ClientID + '" , "MultipalSearchText" : "' + MultipalSearchText + '" , "StartDate" : "' + StartDate + '" , "Enddate" : "' + Enddate + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindNotesSearchData(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    notestitle.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        notestitle.innerHTML = dataRows[i].Alltask;
    }
    document.getElementById("div_btnsaveprocess").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnFinalSearch").style.display = "block";
    crmtooltip();
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function Call_OASearchMethod(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    NotespageNummberIndex = 1;
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    var Chk_Call = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Call");
    var Chk_Task = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Task");
    var Type = "";
    if (Chk_Call.checked && Chk_Task.checked) {
        Type = "TasknCall";
    }
    else if (Chk_Call.checked) {
        Type = "Call";
    }
    else if (Chk_Task.checked) {
        Type = "Task";
    }
    CRM_OASearchMethod(CompanyID, ClientID, SpecialEncode(TxtMultipalSearch.value), TxtStartDate.value, TxtEndDate.value, NotespageNummberIndex, Type);
}

function CRM_OASearchMethod(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/SearchOA",
        data: GetInput_OASearch(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindOASearchData,
        error: ServiceFailed
    });
}

function GetInput_OASearch(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "ClientID" : "' + ClientID + '" , "MultipalSearchText" : "' + MultipalSearchText + '" , "StartDate" : "' + StartDate + '" , "Enddate" : "' + Enddate + '" , "NotespageNummber" : "' + NotespageNummber + '", "Type" : "' + Type + '" } '
    return FinalString;
}

function BindOASearchData(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    lblOpenActivities.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        lblOpenActivities.innerHTML = dataRows[i].AllCalls;
    }
    document.getElementById("div_btnsaveprocess").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnFinalSearch").style.display = "block";
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//.... CA search

function Call_CASearchMethod(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    NotespageNummberIndex = 1;
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    var Chk_Call = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Call");
    var Chk_Task = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Task");
    var Type = "";
    if (Chk_Call.checked && Chk_Task.checked) {
        Type = "TasknCall";
    }
    else if (Chk_Call.checked) {
        Type = "Call";
    }
    else if (Chk_Task.checked) {
        Type = "Task";
    }
    CRM_CASearchMethod(CompanyID, ClientID, SpecialEncode(TxtMultipalSearch.value), TxtStartDate.value, TxtEndDate.value, NotespageNummberIndex, Type);
}

function CRM_CASearchMethod(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/SearchCA",
        data: GetInput_CASearch(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCASearchData,
        error: ServiceFailed
    });
}

function GetInput_CASearch(CompanyID, ClientID, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    var FinalString = ' { "CompanyID" : "' + CompanyID + '" , "ClientID" : "' + ClientID + '" , "MultipalSearchText" : "' + MultipalSearchText + '" , "StartDate" : "' + StartDate + '" , "Enddate" : "' + Enddate + '" , "NotespageNummber" : "' + NotespageNummber + '", "Type" : "' + Type + '" } '
    return FinalString;
}

function BindCASearchData(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    lblcloseActivity.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
    }
    document.getElementById("div_btnsaveprocess").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnFinalSearch").style.display = "block";
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//...................................Show All Notes...........................................

function LoadAllNotes(companyId, sectionid) {
    CRM_Load_All_Notes(companyId, sectionid);
}

function CRM_Load_All_Notes(companyId, sectionid) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadAllNotes",
        data: GetInputAllNotes(companyId, sectionid),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindAllNotes,
        error: ServiceFailed
    });
}

function GetInputAllNotes(companyId, sectionid) {
    var FinalString = ' { "companyId" : "' + companyId + '" , "sectionid" : "' + sectionid + '" } '
    return FinalString;
}

function BindAllNotes(data) {
    var lblAllNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllNotes");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblAllNotes.innerHTML = "";
        return;
    }

    lblAllNotes.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        lblAllNotes.innerHTML = dataRows[i].AllNotes;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//.................................delete All note...................................................

function CRM_AllDelete_Notes(CompanyID, SectionID, attachmentId, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientNotesDelete",
        data: GetAllnotes_deleteddata(CompanyID, SectionID, attachmentId, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindAllNotes_afterdelete,
        error: ServiceFailed
    });
}

function CallAllDelete_NotesMethod(CompanyID, SectionID, attachmentId, NotespageNummber) {
    NotespageNummberIndex = 1;
    var NotesDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtNoteDesc");

    var Notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
    var UploadtextBox = document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload");

    CRM_AllDelete_Notes(CompanyID, SectionID, attachmentId, NotespageNummberIndex);
    NotesDesc.value = "";
    Notestitle.value = "";
    UploadtextBox.value = "";
}

function GetAllnotes_deleteddata(CompanyID, SectionID, attachmentId, NotespageNummber) {
    var FinalStringofDeleteNote = ' { "CompanyID" : "' + CompanyID + '" , "SectionID" : "' + SectionID + '", "attachmentId" : "' + attachmentId + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalStringofDeleteNote;
}

function BindAllNotes_afterdelete(data) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var lblAllNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllNotes");
    var dataRows = data.d;
    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        lblAllNotes.innerHTML = "";
        notestitle.setAttribute("style", "font-weight:bold; font-size:12px;");
        return;
    }
    notestitle.innerHTML = "";
    lblAllNotes.innerHTML = "";

    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");
    hdnprintNotes.value = "";

    for (var i = 0; i < dataRows.length; i++) {
        notestitle.innerHTML = dataRows[i].AllNotes;
        hdnprintNotes.value = dataRows[i].AllNotes;
        lblAllNotes.innerHTML = dataRows[i].AllNotesPopup;

    }
}

function HideAllNotesMessage() {
    window.setTimeout(function () {
        var DivNotesMessage = document.getElementById('DivAllNotesMessage');

        if (DivNotesMessage != null) {
            DivNotesMessage.style.display = 'none';
        }
    }, 9000);
}


//.............................Update All notes...................................

function Call_UpdateAllNoteMethod(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, SpecifiedTo) {
    NotespageNummberIndex = 1;
    var NotesDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtNoteDesc");
    var Notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
    var UploadtextBox = document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload");
    var ddlspecificUp = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");
    var ddlspecificTOUp = ddlspecificUp.options[ddlspecificUp.selectedIndex].value;
    CRM_Update_AllNotes(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, NotesDesc.value, Notestitle.value, NotespageNummberIndex, ddlspecificTOUp);

    NotesDesc.value = "";
    Notestitle.value = "";
    UploadtextBox.value = "";
}

function CRM_Update_AllNotes(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, SpecifiedTo) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientNotesUpdate",
        data: GetInputAllUpdateNote(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, SpecifiedTo),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindAllNotes_AfterUpdate,
        error: ServiceFailed
    });
}

function GetInputAllUpdateNote(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, modifyUserID, Subject, Title, NotespageNummber, SpecifiedTo) {
    Subject = Subject.replace(/\"/g, "\\\"");
    Title = Title.replace(/\"/g, "\\\"");
    var FinalString = ' { "attachmentId" : "' + attachID + '" , "CompanyID" : "' + CompanyID + '" , "SectionName" : "' + SectionName + '", "SectionID" : "' + SectionID + '" , "FileName" : "' + FileName + '", "FileSize" : "' + FileSize + '", "modifyUserID" : "' + modifyUserID + '" , "Subject" : "' + Subject + '", "Title" : "' + Title + '" , "NotespageNummber" : "' + NotespageNummber + '" , "SpecifiedTo" : "' + SpecifiedTo + '" } '
    return FinalString;
}


function BindAllNotes_AfterUpdate(data) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var lblAllNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllNotes");

    var dataRows = data.d;
    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        lblAllNotes.innerHTML = "";
        return;
    }
    notestitle.innerHTML = "";
    var selected = $("#hdnFileselected").val();
    var selected = 'yes';

    var fileInput = $('#ctl00_ContentPlaceHolder1_Client_file_upload');
    var fileData;
    if (fileInput.prop != null && fileInput.prop != undefined) {
        fileData = fileInput.prop("files")[0];
    }
    if (fileData != null) {
        var formData = new window.FormData();
        formData.append("file", fileData);
        $.ajax(
        {
            url: '../Upload.ashx?' + document.getElementById('txtfilename').value + '&Cid="' + CompanyID + '"&Aid= "' + dataRows[0].attachmentID + '"',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
            },
            error: function (errorData) {

            }
        });
        document.getElementById("DivAddNotePopup").style.display = "none";
        BindAllAttachments(dataRows);
        document.getElementById("ShowAttachIcon").style.display = "block";
    }
    else {
        document.getElementById("DivAddNotePopup").style.display = "none";
        BindAllAttachments(dataRows);
    }
}
function BindAllAttachments(dataRows) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var lblAllNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllNotes");
    notestitle.innerHTML = "";
    lblAllNotes.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        notestitle.innerHTML = dataRows[i].AllNotes;
        lblAllNotes.innerHTML = dataRows[i].AllNotesPopup;

        //-----------------------------------------Note Details..........................................................//
        var lbldetNoteTitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetNoteTitle");
        var lbldetSpecifictoContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetSpecifictoContact");
        var lbldetAddedBy = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetAddedBy");
        var lbldetDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetDate");
        var lbldetNoteContent = document.getElementById("ctl00_ContentPlaceHolder1_Client_lbldetNoteContent");

        lbldetNoteTitle.innerHTML = dataRows[i].NoteTitle;
        lbldetSpecifictoContact.innerHTML = dataRows[i].SpecificToName;
        lbldetAddedBy.innerHTML = dataRows[i].AddedBy;
        lbldetDate.innerHTML = dataRows[i].Date;
        lbldetNoteContent.innerHTML = dataRows[i].NoteContent;
    }
    crmtooltip();
}


function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//........................................Show All Open Activities ........................................//

function LoadAllOpenActivity(ClientID, CompanyId) {

    CRM_Load_All_OA(ClientID, CompanyId);
}

function CRM_Load_All_OA(ClientID, CompanyId) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadAllOpenActivity",
        data: GetInputLoad_AllOA(ClientID, CompanyId),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindAllOpenActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_AllOA(ClientID, CompanyId) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '" } '
    return FinalString;
}

function BindAllOpenActivity(data) {

    var lblAllOA = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllOA");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblAllOA.innerHTML = "";
        return;
    }

    lblAllOA.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblAllOA.innerHTML = dataRows[i].Alltask;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//......................................All Cl............................
function LoadAllClosedActivity(ClientID, CompanyId) {

    CRM_Load_All_CA(ClientID, CompanyId);
}

function CRM_Load_All_CA(ClientID, CompanyId) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadAllCloseActivity",
        data: GetInputLoadAll_CA(ClientID, CompanyId),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindAllCloseActivity,
        error: ServiceFailed
    });
}

function GetInputLoadAll_CA(ClientID, CompanyId) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '" } '
    return FinalString;
}

function BindAllCloseActivity(data) {

    var lblAllCl = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllCl");

    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblAllCl.innerHTML = "";
        return;
    }
    lblAllCl.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblAllCl.innerHTML = dataRows[i].AllCloseActivity;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}


//...................Load more Searched Notes........................//

function LoadMoreSearchedNotes(companyId, sectionid, MultipalSearchText, StartDate, Enddate, NotespageNummber) {

    SearchNotespageNummberIndex = SearchNotespageNummberIndex + 4;
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    LoadMore_SearchedNotes(companyId, sectionid, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value, SearchNotespageNummberIndex);
}

function LoadMore_SearchedNotes(companyId, sectionid, MultipalSearchText, StartDate, Enddate, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreSearchedNotes",
        data: GetInputLoadSearcheNote(companyId, sectionid, MultipalSearchText, StartDate, Enddate, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindMoreSearchedNotes,
        error: ServiceFailed
    });
}

function GetInputLoadSearcheNote(companyId, sectionid, MultipalSearchText, StartDate, Enddate, NotespageNummber) {
    var FinalString = ' { "companyId" : "' + companyId + '" , "sectionid" : "' + sectionid + '", "MultipalSearchText" : "' + MultipalSearchText + '", "StartDate" : "' + StartDate + '", "Enddate" : "' + Enddate + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindMoreSearchedNotes(data) {

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    notestitle.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        notestitle.innerHTML = dataRows[i].AllNotes;
    }

    document.getElementById("DivHideMoreNotes").style.display = "block";
    if (SearchNotespageNummberIndex >= 9) {

        document.getElementById("DivShowMoreNotes").style.display = "none";
        document.getElementById("DivShowAllNotes").style.display = "block";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//................................Hide searchNote..........................................//

function HideMoreSearchNotesByJs(companyId, sectionid, MultipalSearchText, StartDate, Enddate, NotespageNummber) {

    SearchNotespageNummberIndex = SearchNotespageNummberIndex - 4;
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    CRM_Load_Hide_SearchNotes(companyId, sectionid, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value, SearchNotespageNummberIndex);
}

function CRM_Load_Hide_SearchNotes(companyId, sectionid, MultipalSearchText, StartDate, Enddate, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreSearchedNotes",
        data: GetInputLoad_HideSearchNote(companyId, sectionid, MultipalSearchText, StartDate, Enddate, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindHideSearchNotes,
        error: ServiceFailed
    });
}

function GetInputLoad_HideSearchNote(companyId, sectionid, MultipalSearchText, StartDate, Enddate, NotespageNummber) {

    var FinalString = ' { "companyId" : "' + companyId + '" , "sectionid" : "' + sectionid + '", "MultipalSearchText" : "' + MultipalSearchText + '", "StartDate" : "' + StartDate + '", "Enddate" : "' + Enddate + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindHideSearchNotes(data) {

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    notestitle.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        notestitle.innerHTML = dataRows[i].AllNotes;
    }
    document.getElementById("DivHideMoreNotes").style.display = "block";
    if (SearchNotespageNummberIndex == 1) {
        document.getElementById("DivHideMoreNotes").style.display = "none";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//.....................................Load All searched Notes.......................

function LoadAll_SearchedNotes(companyId, sectionid, MultipalSearchText, StartDate, Enddate) {
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    CRM_Load_All_SearchedNotes(companyId, sectionid, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value);
}

function CRM_Load_All_SearchedNotes(companyId, sectionid, MultipalSearchText, StartDate, Enddate) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadAllSearchedNotes",
        data: GetInputAll_SearchedNotes(companyId, sectionid, MultipalSearchText, StartDate, Enddate),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindAllSearched_Notes,
        error: ServiceFailed
    });
}

function GetInputAll_SearchedNotes(companyId, sectionid, MultipalSearchText, StartDate, Enddate) {

    var FinalString = ' { "companyId" : "' + companyId + '" , "sectionid" : "' + sectionid + '", "MultipalSearchText" : "' + MultipalSearchText + '", "StartDate" : "' + StartDate + '", "Enddate" : "' + Enddate + '" } '
    return FinalString;
}

function BindAllSearched_Notes(data) {

    var lblAllNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllNotes");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblAllNotes.innerHTML = "";
        return;
    }

    lblAllNotes.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblAllNotes.innerHTML = dataRows[i].AllNotes;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

// ....................................................Load more Searched OA..........................................//

function LoadMoreSearched_OpenActivityByJson(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    SearchOApageNummberIndex = SearchOApageNummberIndex + 4;
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");

    var Chk_Call = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Call");
    var Chk_Task = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Task");
    var Type = "";
    if (Chk_Call.checked && Chk_Task.checked) {
        Type = "TasknCall";
    }
    else if (Chk_Call.checked) {
        Type = "Call";
    }
    else if (Chk_Task.checked) {
        Type = "Task";
    }
    CRM_Load_More_SearchedOA(ClientID, CompanyId, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value, SearchOApageNummberIndex, Type);
}

function CRM_Load_More_SearchedOA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {


    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreSearchedOpenActivity",
        data: GetInputLoad_SearchedOA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindMoreSearchedOpenActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_SearchedOA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "MultipalSearchText" : "' + MultipalSearchText + '", "StartDate" : "' + StartDate + '", "Enddate" : "' + Enddate + '", "NotespageNummber" : "' + NotespageNummber + '", "Type" : "' + Type + '" } '
    return FinalString;
}

function BindMoreSearchedOpenActivity(data) {

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblOpenActivities.innerHTML = "";
        return;
    }

    lblOpenActivities.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblOpenActivities.innerHTML = dataRows[i].SearcedCall;
    }
    document.getElementById("DivHideMoreOA").style.display = "block";
    if (SearchOApageNummberIndex >= 9) {
        document.getElementById("DivShowMoreOA").style.display = "none";
        document.getElementById("DivShowAllOA").style.display = "block";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//..................................Hode searched OA.....................................

function HideMoreSearched_OAByJson(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {

    SearchOApageNummberIndex = SearchOApageNummberIndex - 4;
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    CRM_Load_Hide_SearchedOA(ClientID, CompanyId, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value, SearchOApageNummberIndex, Type);
}

function CRM_Load_Hide_SearchedOA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreSearchedOpenActivity",
        data: GetInputLoad_SearchedOA_Hide(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindHideSearchedOpenActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_SearchedOA_Hide(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "MultipalSearchText" : "' + MultipalSearchText + '", "StartDate" : "' + StartDate + '", "Enddate" : "' + Enddate + '", "NotespageNummber" : "' + NotespageNummber + '", "Type" : "' + Type + '" } '
    return FinalString;
}

function BindHideSearchedOpenActivity(data) {

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblOpenActivities.innerHTML = "";
        return;
    }

    lblOpenActivities.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        lblOpenActivities.innerHTML = dataRows[i].SearcedCall;
    }
    document.getElementById("DivHideMoreOA").style.display = "block";
    if (SearchOApageNummberIndex == 1) {
        document.getElementById("DivHideMoreOA").style.display = "none";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}


// ..............................Load All Searched OA..............................................


function LoadAllSearched_OAByJsn(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, Type) {
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    var Chk_Call = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Call");
    var Chk_Task = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Task");
    var Type = "";
    if (Chk_Call.checked && Chk_Task.checked) {
        Type = "TasknCall";
    }
    else if (Chk_Call.checked) {
        Type = "Call";
    }
    else if (Chk_Task.checked) {
        Type = "Task";
    }

    CRM_Load_All_SearchedOA(ClientID, CompanyId, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value, Type);
}

function CRM_Load_All_SearchedOA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, Type) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadAllSearchedOpenActivity",
        data: GetInputLoad_SearchedAllOA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, Type),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindAllSearchedOpenActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_SearchedAllOA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "MultipalSearchText" : "' + MultipalSearchText + '", "StartDate" : "' + StartDate + '", "Enddate" : "' + Enddate + '", "Type" : "' + Type + '" } '
    return FinalString;
}

function BindAllSearchedOpenActivity(data) {

    var lblAllOA = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllOA");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblAllOA.innerHTML = "";
        return;
    }

    lblAllOA.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        lblAllOA.innerHTML = dataRows[i].SearcedCall;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//...................................Load More Closed Activity Searched.........................

function LoadMoreSearched_CloseActivityByJson(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    SearchCLpageNummberIndex = SearchCLpageNummberIndex + 4;
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    var Chk_Call = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Call");
    var Chk_Task = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Task");
    var Type = "";
    if (Chk_Call.checked && Chk_Task.checked) {
        Type = "TasknCall";
    }
    else if (Chk_Call.checked) {
        Type = "Call";
    }
    else if (Chk_Task.checked) {
        Type = "Task";
    }

    CRM_Load_More_SearchedCA(ClientID, CompanyId, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value, SearchCLpageNummberIndex, Type);
}

function CRM_Load_More_SearchedCA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreSearchedCloseActivity",
        data: GetInputLoad_SearchedCA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindMoreSearchedCloseActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_SearchedCA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "MultipalSearchText" : "' + MultipalSearchText + '", "StartDate" : "' + StartDate + '", "Enddate" : "' + Enddate + '", "NotespageNummber" : "' + NotespageNummber + '", "Type" : "' + Type + '" } '
    return FinalString;
}


function BindMoreSearchedCloseActivity(data) {

    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblcloseActivity.innerHTML = "";
        return;
    }

    lblcloseActivity.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
    }

    document.getElementById("DivHideMoreCloAct").style.display = "block";

    if (SearchCLpageNummberIndex >= 9) {
        document.getElementById("DivShowMoreCA").style.display = "none";
        document.getElementById("DivShowAllCA").style.display = "block";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//...........................Load Hide Cl Searched.............................................

function LoadHideSearched_CloseActivityByJson(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {

    SearchCLpageNummberIndex = SearchCLpageNummberIndex - 4;
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    var Chk_Call = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Call");
    var Chk_Task = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Task");
    var Type = "";
    if (Chk_Call.checked && Chk_Task.checked) {
        Type = "TasknCall";
    }
    else if (Chk_Call.checked) {
        Type = "Call";
    }
    else if (Chk_Task.checked) {
        Type = "Task";
    }

    CRM_Hide_More_SearchedCA(ClientID, CompanyId, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value, SearchCLpageNummberIndex, Type);
}

function CRM_Hide_More_SearchedCA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreSearchedCloseActivity",
        data: GetInputLoad_Hide_SearchedCA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindHideSearchedCloseActivity,
        error: ServiceFailed
    });
}

function GetInputLoad_Hide_SearchedCA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, NotespageNummber, Type) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "MultipalSearchText" : "' + MultipalSearchText + '", "StartDate" : "' + StartDate + '", "Enddate" : "' + Enddate + '", "NotespageNummber" : "' + NotespageNummber + '", "Type" : "' + Type + '" } '
    return FinalString;
}

function BindHideSearchedCloseActivity(data) {

    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblcloseActivity.innerHTML = "";
        return;
    }

    lblcloseActivity.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {
        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
    }

    document.getElementById("DivHideMoreCloAct").style.display = "block";
    if (SearchCLpageNummberIndex == 1) {
        document.getElementById("DivHideMoreCloAct").style.display = "none";
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//.....................................Load All Searched Cl By json...................................//

function LoadMoreClSearched_byJson(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, Type) {
    var TxtMultipalSearch = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant");
    var TxtStartDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate");
    var TxtEndDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate");
    var Chk_Call = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Call");
    var Chk_Task = document.getElementById("ctl00_ContentPlaceHolder1_Client_Chk_Task");
    var Type = "";
    if (Chk_Call.checked && Chk_Task.checked) {
        Type = "TasknCall";
    }
    else if (Chk_Call.checked) {
        Type = "Call";
    }
    else if (Chk_Task.checked) {
        Type = "Task";
    }


    CRM_Load_All_SearchedCl(ClientID, CompanyId, TxtMultipalSearch.value, TxtStartDate.value, TxtEndDate.value, Type);
}

function CRM_Load_All_SearchedCl(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, Type) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadAllSearchedCloseActivity",
        data: GetInputLoadAll_SearchedCA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, Type),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindAllSearchedCloseActivity,
        error: ServiceFailed
    });
}

function GetInputLoadAll_SearchedCA(ClientID, CompanyId, MultipalSearchText, StartDate, Enddate, Type) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "MultipalSearchText" : "' + MultipalSearchText + '", "StartDate" : "' + StartDate + '", "Enddate" : "' + Enddate + '", "Type" : "' + Type + '" } '
    return FinalString;
}

function BindAllSearchedCloseActivity(data) {

    var lblAllCl = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAllCl");

    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblAllCl.innerHTML = "";
        return;
    }
    lblAllCl.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblAllCl.innerHTML = dataRows[i].AllCloseActivity;
    }
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

//.....................................Clear search Filter................................................

function LoadClearNotesFilter(companyId, sectionid) {
    NotespageNummberIndex == 0;
    LoadCler_NotesFilter(companyId, sectionid, NotespageNummberIndex);
}

function LoadCler_NotesFilter(companyId, sectionid, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreNotes",
        data: GetInputClearNote(companyId, sectionid, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindClearNotesFilter,
        error: ServiceFailed
    });
}

function GetInputClearNote(companyId, sectionid, NotespageNummber) {

    var FinalString = ' { "companyId" : "' + companyId + '" , "sectionid" : "' + sectionid + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindClearNotesFilter(data) {

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    notestitle.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        notestitle.innerHTML = dataRows[i].AllNotes;
    }
    crmtooltip();
    document.getElementById("div_btnClearprocess").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnClear").style.display = "block";
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function LoadClearpenActivityFilter(ClientID, CompanyId) {

    NotespageNummberIndexOA == 0;
    LoadClearpen_ActivityFilter(ClientID, CompanyId, NotespageNummberIndexOA);
}

function LoadClearpen_ActivityFilter(ClientID, CompanyId, NotespageNummber) {


    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreOpenActivity",
        data: GetInputLoad_OAClearFilter(ClientID, CompanyId, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindMoreOpenActivityClearFilter,
        error: ServiceFailed
    });
}

function GetInputLoad_OAClearFilter(ClientID, CompanyId, NotespageNummber) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}
function BindMoreOpenActivityClearFilter(data) {

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblOpenActivities.innerHTML = "";
        return;
    }

    lblOpenActivities.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblOpenActivities.innerHTML = dataRows[i].Alltask;
    }
    document.getElementById("div_btnClearprocess").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnClear").style.display = "block";
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}


function LoadClearCloseActivityFilter(ClientID, CompanyId) {

    NotespageNummberIndexCL == 0;
    LoadClearClose_ActivityFilter(ClientID, CompanyId, NotespageNummberIndexCL);
}

function LoadClearClose_ActivityFilter(ClientID, CompanyId, NotespageNummber) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadMoreCloseActivity",
        data: GetInputLoad_CAClerFilter(ClientID, CompanyId, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindMoreCloseActivityClerFilter,
        error: ServiceFailed
    });
}

function GetInputLoad_CAClerFilter(ClientID, CompanyId, NotespageNummber) {

    var FinalString = ' { "ClientID" : "' + ClientID + '" , "CompanyId" : "' + CompanyId + '", "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}


function BindMoreCloseActivityClerFilter(data) {

    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    var dataRows = data.d;

    if (dataRows.length == 0) {
        lblcloseActivity.innerHTML = "";
        return;
    }

    lblcloseActivity.innerHTML = "";
    for (var i = 0; i < dataRows.length; i++) {

        lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
    }
    document.getElementById("div_btnClearprocess").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Client_btnClear").style.display = "block";
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function ShowPrintMoreActions(btnid) {
    document.getElementById("ctl00_ContentPlaceHolder1_Client_DivPrintOptions").style.display = "block";
}

function HidePrintMoreActions() {
    document.getElementById("ctl00_ContentPlaceHolder1_Client_DivPrintOptions").style.display = "none";
}

function addnote() {

    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");
    clearNoteValue();
    var txt = lnkNotebtn;
    var p = GetScreenCordinatesForNotewindow(txt);
    document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.display = "none";
    document.getElementById("DivOpenActiDetails").style.display = "none";
    document.getElementById("divallnotesbckfade").style.display = "none";
    document.getElementById("DivAddNotePopup").style.left = p.x;
    document.getElementById("DivAddNotePopup").style.top = p.y;
    document.getElementById("ctl00_ContentPlaceHolder1_Client_lblAddNoteTitle").innerHTML = "Add Follow-Up Note";
    document.getElementById("DivAddNotePopup").style.display = "block";

    document.getElementById('rgarrow').style.display = "none";
    document.getElementById('lftarrow').style.display = "block";

    document.getElementById('DivCloseBrowseFile').style.display = "block";
    document.getElementById('ctl00_ContentPlaceHolder1_Client_file_upload').value = "";
    $('#addfileDiv').show();
}

//===============================================================================================================================================================================//

function Close_Popup_FromHeader() {
    document.getElementById('divalertcontant').style.display = 'block';
    document.getElementById("divallnotesbckfade").style.display = "none";
    document.getElementById("DivtaskEditSecond_FromHeader").style.display = "none";
    document.getElementById("DivEventsSubject_FromHeader").style.display = "none";
    document.getElementById("DivEventPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
    document.getElementById("DivCallPopup_FromHeader").style.display = "none";
    document.getElementById("span_EditCallStartdate_FromHeader").style.display = "none";
    document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
    document.getElementById("DivEditCallTimer_FromHeader").style.display = "none";
    document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
    document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
    document.getElementById("DivtaskEdit_FromHeader").style.display = "none";
    document.getElementById("DivNotesPopup_FromHeader").style.display = "none";
    document.getElementById("DivAddNotePopup_FromHeader").style.display = "none";
}

function Close_TaskPopup_FromHeader() {
    document.getElementById('divalertcontant').style.display = 'block';
    document.getElementById("divallnotesbckfade").style.display = "none";
    document.getElementById("DivtaskEditSecond_FromHeader").style.display = "none";
    document.getElementById("DivEventsSubject_FromHeader").style.display = "none";
    document.getElementById("DivEventPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
    document.getElementById("DivNotesPopup_FromHeader").style.display = "none";
    document.getElementById("span_EditCallStartdate_FromHeader").style.display = "none";
    document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
    document.getElementById("DivEditCallTimer_FromHeader").style.display = "none";
    document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
    document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
    document.getElementById("DivtaskEdit_FromHeader").style.display = "none";
}

function Close_CallPopup_FromHeader() {
    document.getElementById('divalertcontant').style.display = 'block';
    document.getElementById("divallnotesbckfade").style.display = "none";
    document.getElementById("DivtaskEditSecond_FromHeader").style.display = "none";
    document.getElementById("DivEventsSubject_FromHeader").style.display = "none";
    document.getElementById("DivEventPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
    document.getElementById("DivCallPopup_FromHeader").style.display = "none";
    document.getElementById("span_EditCallStartdate_FromHeader").style.display = "none";
    document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
    document.getElementById("DivEditCallTimer_FromHeader").style.display = "none";
    document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
    document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
    document.getElementById("DivtaskEdit_FromHeader").style.display = "none";
}

function GetScreenCordinatesForDetails_FromHeader(obj) {
    var p = {};
    p.y = obj.offsetTop;
    while (obj.offsetParent) {
        p.y = obj.offsetParent.offsetTop;
        if (obj == document.getElementsByTagName("body")[1]) {
            break;
        }
        else {
            obj = obj.offsetParent;
        }
    }
    return p;
}

function ClientTimeSelected(sender, args) {
    isTimeSelected = true;
}
//----------------------------------------- Open TaskCall details FromHeader ------------------------------------//

function Open_AddTask_PopUp_FromHeader() {

    //added loading img for ticket 13607 
    document.getElementById('ctl00_header1_btnsavetasks_FromHeader').style.display = 'block';
    document.getElementById('div_loading_btnsavetasks_FromHeader').style.display = 'none';

    document.getElementById("ctl00_header1_hdn_Type").value = "task";
    document.getElementById("ctl00_header1_lbl_AddTask_FromHeader").innerHTML = "Add Task";
    document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
    document.getElementById("DivEditTaskSubject_FromHeader").style.display = "none";
    document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivEventsSubject_FromHeader").style.display = "none";
    document.getElementById("DivEventPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivCallPopup_FromHeader").style.display = "none";
    document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
    document.getElementById("DivNotesPopup_FromHeader").style.display = "block";
    document.getElementById("DivTaskMain_FromHeader").style.display = "block";
    document.getElementById("DivTaskMainSecond_FromHeader").style.display = "none";
    document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
    document.getElementById('ctl00_header1_ddlTaskassigneto_FromHeader').focus();
    document.getElementById('ctl00_header1_ddlstatus_FromHeader').selectedIndex = 4;
    document.getElementById('ctl00_header1_ddlAddTaskpriority').selectedIndex = 3;
    var txtduedate = document.getElementById('ctl00_header1_txtduedate_FromHeader');

    txtduedate.value = TodDate;
    $find('ctl00_header1_RadTimePicker_FromHeader').get_dateInput().set_value("10:00 AM");
    document.getElementById('ctl00_header1_ddlhour_FromHeader').selectedIndex = 1;
    document.getElementById('ctl00_header1_ddlminute_FromHeader').selectedIndex = 0;
    document.getElementById('ctl00_header1_txtNotesDesc_FromHeader').value = '';
    document.getElementById('spn_ddlAddTasksubject_FromHeader').style.display = "none";
    document.getElementById('spn_ddlTaskCustomer_FromHeader').style.display = "none";
    document.getElementById('spn_ddlTaskassigneto_FromHeader').style.display = "none";
    document.getElementById('Span_ddlstatus_FromHeader').style.display = "none";
    document.getElementById('Span_ddlAddTaskpriority').style.display = "none";
    document.getElementById('Span_txtduedate_FromHeader').style.display = "none";
    document.getElementById('Span_txtduedate1_FromHeader').style.display = "none";
    document.getElementById('ctl00_header1_Img_ClearSubject_FromHeader').style.display = "none";
    document.getElementById('ctl00_header1_img_Clearcontacts_FromHeader').style.display = "none";
    document.getElementById("divallnotesbckfade").style.display = "block";
    document.getElementById("divalertcontant").style.zIndex = "555";
    document.getElementById("ctl00_header1_txt_TaskCustomers_FromHeader").value = '';
    BindAssigento(CompanyID, UserID, document.getElementById("ctl00_header1_hdnClientID_FromHeader").value);
    BindTaskSbject(CompanyID);
    load_TaskStatusDDl(CompanyID);
    while (document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader").options.length > 0) {
        document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader").options.remove(0);
    }
    var option = document.createElement("option");
    option.text = "--Select--";
    option.value = 0;
    document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader").options.add(option);
    document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader").options.selectedIndex = 0;
    document.getElementById("ctl00_header1_txt_Task_ContactPhone").value = '';
    document.getElementById("ctl00_header1_txt_Task_ContactMobile").value = '';
    document.getElementById("ctl00_header1_txt_Task_DeptPhone").value = '';
    document.getElementById("ctl00_header1_txt_Task_ContactPhone").disabled = false;
    document.getElementById("ctl00_header1_txt_Task_ContactMobile").disabled = false;
    document.getElementById("ctl00_header1_txt_Task_DeptPhone").disabled = false;

    if (Browser().toLocaleLowerCase().trim() == "firefox") {
        document.getElementById("ctl00_header1_RadTimePicker_FromHeader_timeView_tdl").style.marginLeft = "209px";
        document.getElementById("ctl00_header1_RadTimePicker_FromHeader_timeView_tdl").style.marginTop = "142px";
        document.getElementById("fc").style.marginLeft = "-30px";
        document.getElementById("fc").style.marginTop = "-15px";
        $find("ctl00_header1_RadTimePicker_FromHeader").get_dateInput().style.paddingTop = "4px";
    } else if (Browser().toLocaleLowerCase() == "safari") {
        document.getElementById("DivNotesPopup_FromHeader").style.top = "25%";
        document.getElementById("DivNotesPopup_FromHeader").style.left = "30%";
        document.getElementById("ctl00_header1_RadTimePicker_FromHeader_timeView_tdl").style.marginLeft = "43px";
        document.getElementById("ctl00_header1_RadTimePicker_FromHeader_timeView_tdl").style.marginTop = "23px";
        document.getElementById("fc").style.marginLeft = "-54px";
        document.getElementById("fc").style.marginTop = "23px";
        document.getElementById("ctl00_header1_txtduedate_FromHeader").style.marginTop = "3px";
    } else {
        document.getElementById("ctl00_header1_RadTimePicker_FromHeader_timeView_tdl").style.marginLeft = "210px";
        document.getElementById("ctl00_header1_RadTimePicker_FromHeader_timeView_tdl").style.marginTop = "140px";
        document.getElementById("fc").style.marginLeft = "-30px";
        document.getElementById("fc").style.marginTop = "-6px";
        document.getElementById("ctl00_header1_txtduedate_FromHeader").style.marginTop = "3px";
    }

    var ddlTaskCustomers_FromHeader = document.getElementById("ctl00_header1_txt_TaskCustomers_FromHeader");
    var ddlTaskContact = document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader");
    if (window.location.href.toLocaleLowerCase().indexOf('estimate_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('job_summary_reeng') > -1
        || window.location.href.toLocaleLowerCase().indexOf('invoice_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('order_summary') > -1
        || window.location.href.toLocaleLowerCase().indexOf('job_order_summary') > -1 || window.location.href.toLocaleLowerCase().indexOf('invoice_order_summary') > -1
        || window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
        if (window.location.href.toLocaleLowerCase().indexOf('invoice_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('invoice_order_summary') > -1) {
            EstimateID = 0;
        }
        if (ddlTaskCustomers_FromHeader != null && ddlTaskCustomers_FromHeader != undefined) {
            if (window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
                SelectedClientID_FromHeader.value = document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value;
                load_CustomerName_FromHeader(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value);
                if (ddlTaskCustomers_FromHeader.value != null && ddlTaskCustomers_FromHeader.value != undefined && SelectedClientID_FromHeader.value != 0) {
                    Load_Summury_Contactlist(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value);
                }
            } else {
                SelectedClientID_FromHeader.value = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value;
                load_CustomerName_FromHeader(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value);
                if (ddlTaskCustomers_FromHeader.value != null && ddlTaskCustomers_FromHeader.value != undefined && SelectedClientID_FromHeader.value != 0) {
                    Load_Summury_Contactlist(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value);
                }
            }
        }
    } else if (window.location.href.toLocaleLowerCase().indexOf('client/client_detail') > -1) {
        if (ddlTaskCustomers_FromHeader != null && ddlTaskCustomers_FromHeader != undefined) {
            if (CompanyType.toLowerCase() != null && CompanyType.toLowerCase() != undefined) {
                SelectedClientID_FromHeader.value = document.getElementById("ctl00_ContentPlaceHolder1_Client_hid_ClientID").value;
                load_CustomerName_FromHeader(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_Client_hid_ClientID").value);

            } else {
                SelectedClientID_FromHeader.value = 0;
            }
            if (ddlTaskCustomers_FromHeader.value != null && ddlTaskCustomers_FromHeader.value != undefined && SelectedClientID_FromHeader.value != 0) {
                Load_Client_Contactlist(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_Client_hdn_ContactIDs").value);
            }
        }
    }
    //if (ddlTaskCustomers_FromHeader.value == null || ddlTaskCustomers_FromHeader.value == undefined || ddlTaskCustomers_FromHeader.value == "") {
    //    SelectedClientID_FromHeader.value = 0;
    //}

    var ddlAddTasksubject_FromHeader = document.getElementById("ctl00_header1_ddlAddTasksubject_FromHeader");
    if (document.getElementById("ctl00_header1_hdn_DefaultTaskSubjectID_FromHeader").value != 0) {
        if (ddlAddTasksubject_FromHeader != null && ddlAddTasksubject_FromHeader != undefined) {
            ddlAddTasksubject_FromHeader.value = document.getElementById("ctl00_header1_hdn_DefaultTaskSubjectID_FromHeader").value;
        }
    } else {
        if (ddlAddTasksubject_FromHeader != null && ddlAddTasksubject_FromHeader != undefined) {
            ddlAddTasksubject_FromHeader.value = 0;
            ddlAddTasksubject_FromHeader.selectedIndex = 0;
        }
    }
}
var ContactData = '';
function Load_Client_Contactlist(CompanyID, ClientID) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/BindContactList",
        data: Get_Client_Contact(CompanyID, ClientID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var dataRows = data.d;
            if (document.getElementById("ctl00_header1_hdn_Type").value == "task") {
                var ddlTaskContacts_FromHeader = document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader");
                if (ddlTaskContacts_FromHeader != null && ddlTaskContacts_FromHeader != undefined) {
                    AddOption(ddlTaskContacts_FromHeader, dataRows);
                    ContactData = dataRows;
                    ddlTaskContacts_FromHeader.onchange = SelectedContact;
                }
                for (var i = 0; i < dataRows.length; i++) {
                    if (dataRows[i].DefaultContact.toLowerCase() == "true") {
                        if (dataRows[i].ContactPhone != '') {
                            document.getElementById("ctl00_header1_txt_Task_ContactPhone").value = dataRows[i].ContactPhone;
                            document.getElementById("ctl00_header1_txt_Task_ContactPhone").disabled = true;
                        }
                        else {
                            document.getElementById("ctl00_header1_txt_Task_ContactPhone").disabled = false;
                        }
                        if (dataRows[i].ContactMobile != '') {
                            document.getElementById("ctl00_header1_txt_Task_ContactMobile").value = dataRows[i].ContactMobile;
                            document.getElementById("ctl00_header1_txt_Task_ContactMobile").disabled = true;
                        }
                        else {
                            document.getElementById("ctl00_header1_txt_Task_ContactMobile").disabled = false;
                        }
                        if (dataRows[i].DepartmentPhone != '') {
                            document.getElementById("ctl00_header1_txt_Task_DeptPhone").value = dataRows[i].DepartmentPhone;
                            document.getElementById("ctl00_header1_txt_Task_DeptPhone").disabled = true;
                        }
                        else {
                            document.getElementById("ctl00_header1_txt_Task_DeptPhone").disabled = false;
                        }
                    }
                }
            } else if (document.getElementById("ctl00_header1_hdn_Type").value == "call") {
                var ddlCallContacts = document.getElementById("ctl00_header1_ddlCallContacts");
                if (ddlCallContacts != null && ddlCallContacts != undefined) {
                    AddOption(ddlCallContacts, dataRows);
                }
                ContactData = dataRows;
                ddlCallContacts.onchange = SelectedContact;
                for (var i = 0; i < dataRows.length; i++) {
                    if (dataRows[i].DefaultContact.toLowerCase() == "true") {
                        if (dataRows[i].ContactPhone != '') {
                            document.getElementById("ctl00_header1_txt_Call_ContactPhone").value = dataRows[i].ContactPhone;
                            document.getElementById("ctl00_header1_txt_Call_ContactPhone").disabled = true;
                        }
                        else {
                            document.getElementById("ctl00_header1_txt_Call_ContactPhone").disabled = false;
                        }
                        if (dataRows[i].ContactMobile != '') {
                            document.getElementById("ctl00_header1_txt_Call_ContactMobile").value = dataRows[i].ContactMobile;
                            document.getElementById("ctl00_header1_txt_Call_ContactMobile").disabled = true;
                        }
                        else {
                            document.getElementById("ctl00_header1_txt_Call_ContactMobile").disabled = false;
                        }
                        if (dataRows[i].DepartmentPhone != '') {
                            document.getElementById("ctl00_header1_txt_Call_DeptPhone").value = dataRows[i].DepartmentPhone;
                            document.getElementById("ctl00_header1_txt_Call_DeptPhone").disabled = true;
                        }
                        else {
                            document.getElementById("ctl00_header1_txt_Call_DeptPhone").disabled = false;
                        }
                    }
                }
            } else if (document.getElementById("ctl00_header1_hdn_Type").value == "notes") {
                var ddl_Notes_specificTo = document.getElementById("ctl00_header1_ddl_Notes_specificTo");
                if (ddl_Notes_specificTo != null && ddl_Notes_specificTo != undefined) {
                    AddOption(ddl_Notes_specificTo, dataRows);
                }
            }
        },
        error: function (data) { }
    });
}

function Get_Client_Contact() {
    var FinalString = ' {  "CompanyID" : "' + CompanyID + '", "ClientID" : "' + document.getElementById("ctl00_ContentPlaceHolder1_Client_hid_ClientID").value + '"} ';
    return FinalString;
}

function Load_Summury_Contactlist(CompanyID, ClientID) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/BindContactList",
        data: Get_Summury_Contact(CompanyID, ClientID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            ContactData = '';
            var dataRows = data.d;
            ContactData = dataRows;
            if (document.getElementById("ctl00_header1_hdn_Type").value == "task") {
                var ddlTaskContacts_FromHeader = document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader");
                if (ddlTaskContacts_FromHeader != null && ddlTaskContacts_FromHeader != undefined) {
                    while (ddlTaskContacts_FromHeader.options.length > 0) {
                        ddlTaskContacts_FromHeader.options.remove(0);
                    }

                    var option = document.createElement("option");
                    option.text = "--Select--";
                    option.value = 0;
                    ddlTaskContacts_FromHeader.options.add(option);
                    ddlTaskContacts_FromHeader.onchange = SelectedContact;

                    if (dataRows.length == 0) {
                        return;
                    }

                    for (var i = 0; i < dataRows.length; i++) {
                        var optionvalues = document.createElement("option");
                        optionvalues.text = dataRows[i].ContactName;
                        optionvalues.value = dataRows[i].ContactID;
                        ddlTaskContacts_FromHeader.options.add(optionvalues);

                        if (dataRows[i].DefaultContact.toLowerCase() == "true") {
                            if (dataRows[i].ContactPhone != '') {
                                document.getElementById("ctl00_header1_txt_Task_ContactPhone").value = dataRows[i].ContactPhone;
                                document.getElementById("ctl00_header1_txt_Task_ContactPhone").disabled = true;
                            }
                            else {
                                document.getElementById("ctl00_header1_txt_Task_ContactPhone").disabled = false;
                                document.getElementById("ctl00_header1_txt_Task_ContactPhone").value = dataRows[i].ContactPhone;
                            }
                            if (dataRows[i].ContactMobile != '') {
                                document.getElementById("ctl00_header1_txt_Task_ContactMobile").value = dataRows[i].ContactMobile;
                                document.getElementById("ctl00_header1_txt_Task_ContactMobile").disabled = true;
                            }
                            else {
                                document.getElementById("ctl00_header1_txt_Task_ContactMobile").disabled = false;
                                document.getElementById("ctl00_header1_txt_Task_ContactMobile").value = dataRows[i].ContactMobile;
                            }
                            if (dataRows[i].DepartmentPhone != '') {
                                document.getElementById("ctl00_header1_txt_Task_DeptPhone").value = dataRows[i].DepartmentPhone;
                                document.getElementById("ctl00_header1_txt_Task_DeptPhone").disabled = true;
                            }
                            else {
                                document.getElementById("ctl00_header1_txt_Task_DeptPhone").disabled = false;
                                document.getElementById("ctl00_header1_txt_Task_DeptPhone").value = dataRows[i].DepartmentPhone;
                            }
                        }
                    }
                    if (window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
                        var DeliveryContact = document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_ContactID").value;
                        ddlTaskContacts_FromHeader.value = DeliveryContact;
                    }
                    else {
                        ddlTaskContacts_FromHeader.value = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ContactID").value;
                    }

                }
            } else if (document.getElementById("ctl00_header1_hdn_Type").value == "call") {
                var ddlCallContacts = document.getElementById("ctl00_header1_ddlCallContacts");
                if (ddlCallContacts != null && ddlCallContacts != undefined) {
                    while (ddlCallContacts.options.length > 0) {
                        ddlCallContacts.options.remove(0);
                    }
                    var option = document.createElement("option");
                    option.text = "--Select--";
                    option.value = 0;
                    ddlCallContacts.options.add(option);

                    if (dataRows.length == 0) {
                        return;
                    }

                    for (var i = 0; i < dataRows.length; i++) {
                        var optionvalues = document.createElement("option");
                        optionvalues.text = dataRows[i].ContactName;
                        optionvalues.value = dataRows[i].ContactID;
                        ddlCallContacts.options.add(optionvalues);
                        if (dataRows[i].DefaultContact.toLowerCase() == "true") {
                            if (dataRows[i].ContactPhone != '') {
                                document.getElementById("ctl00_header1_txt_Call_ContactPhone").value = dataRows[i].ContactPhone;
                                document.getElementById("ctl00_header1_txt_Call_ContactPhone").disabled = true;
                            }
                            else {
                                document.getElementById("ctl00_header1_txt_Call_ContactPhone").disabled = false;
                                document.getElementById("ctl00_header1_txt_Call_ContactPhone").value = dataRows[i].ContactPhone;
                            }
                            if (dataRows[i].ContactMobile != '') {
                                document.getElementById("ctl00_header1_txt_Call_ContactMobile").value = dataRows[i].ContactMobile;
                                document.getElementById("ctl00_header1_txt_Call_ContactMobile").disabled = true;
                            }
                            else {
                                document.getElementById("ctl00_header1_txt_Call_ContactMobile").disabled = false;
                                document.getElementById("ctl00_header1_txt_Call_ContactMobile").value = dataRows[i].ContactMobile;
                            }
                            if (dataRows[i].DepartmentPhone != '') {
                                document.getElementById("ctl00_header1_txt_Call_DeptPhone").value = dataRows[i].DepartmentPhone;
                                document.getElementById("ctl00_header1_txt_Call_DeptPhone").disabled = true;
                            }
                            else {
                                document.getElementById("ctl00_header1_txt_Call_DeptPhone").disabled = false;
                                document.getElementById("ctl00_header1_txt_Call_DeptPhone").value = dataRows[i].DepartmentPhone;
                            }
                        }
                    }
                    ddlCallContacts.onchange = SelectedContact;
                    if (window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
                        var DeliveryContact = document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_ContactID").value;
                        ddlCallContacts.value = DeliveryContact;
                    }
                    else {
                        ddlCallContacts.value = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ContactID").value;
                        SelectedContact();
                    }

                }
            } else if (document.getElementById("ctl00_header1_hdn_Type").value == "notes") {
                var ddl_Notes_specificTo = document.getElementById("ctl00_header1_ddl_Notes_specificTo");
                if (ddl_Notes_specificTo != null && ddl_Notes_specificTo != undefined) {
                    while (ddl_Notes_specificTo.options.length > 0) {
                        ddl_Notes_specificTo.options.remove(0);
                    }

                    var option = document.createElement("option");
                    option.text = "--Select--";
                    option.value = 0;
                    ddl_Notes_specificTo.options.add(option);

                    if (dataRows.length == 0) {
                        return;
                    }

                    for (var i = 0; i < dataRows.length; i++) {
                        var optionvalues = document.createElement("option");
                        optionvalues.text = dataRows[i].ContactName;
                        optionvalues.value = dataRows[i].ContactID;
                        ddl_Notes_specificTo.options.add(optionvalues);
                    }
                    if (window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
                        var DeliveryContact = document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_ContactID").value;
                        ddl_Notes_specificTo.value = DeliveryContact;
                    }
                    else {
                        ddl_Notes_specificTo.value = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ContactID").value;
                    }

                }
            }
        },
        error: function (data) { }
    });
}

function Get_Summury_Contact() {
    if (window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
        var FinalString = ' {  "CompanyID" : "' + CompanyID + '", "ClientID" : "' + document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value + '"} ';
    }
    else {
        var FinalString = ' {  "CompanyID" : "' + CompanyID + '", "ClientID" : "' + document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value + '"} ';
    }
    return FinalString;
}

function Open_Activity_details_FromHeader(id, SectionName, btnID) {
    var AttID = document.getElementById("ctl00_header1_AttID");
    AttID.value = id;
    var txt = document.getElementById(btnID);
    var hdnCommanID_FromHeader = document.getElementById("ctl00_header1_hdnCommanID_FromHeader");
    var hdnSectionName_FromHeader = document.getElementById("ctl00_header1_hdnSectionName_FromHeader");
    var hdnbuttonid_FromHeader = document.getElementById("ctl00_header1_hdnbuttonid_FromHeader");

    hdnCommanID_FromHeader.value = id;
    hdnSectionName_FromHeader.value = SectionName;
    hdnbuttonid_FromHeader.value = btnID;
    if (SectionName != "") {
        if (SectionName.toLowerCase() == "task") {
            document.getElementById("ctl00_header1_lbl_Detail_FromHeader").innerHTML = "Task Detail";
            document.getElementById("DivOpenActiDetails_FromHeader").style.display = "block";
            document.getElementById("DivOpenActiDetails_FromHeader").style.zIndex = "555555555555";
            document.getElementById("div_Popupfieldes_FromHeader").style.display = "block";
            document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
            document.getElementById("DivtaskEditSecond_FromHeader").style.display = "none";
            document.getElementById("DivEventsSubject_FromHeader").style.display = "none";
            document.getElementById("DivEventPopUpEdit_FromHeader").style.display = "none";
            document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
            document.getElementById("DivCallPopup_FromHeader").style.display = "none";
            document.getElementById("DivNotesPopup_FromHeader").style.display = "none";
            document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
            document.getElementById("DivtaskEdit_FromHeader").style.display = "none";
            document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
            document.getElementById("ctl00_header1_btn_FollowTask_FromHeader").style.display = "block";
            document.getElementById("ctl00_header1_btn_FollowCall_FromHeader").style.display = "block";
            document.getElementById("ctl00_header1_btn_EditDetails_FromHeader").style.display = "block";
            document.getElementById("ctl00_header1_btn_DeleteDetails_FromHeader").style.marginLeft = "0px";
            document.getElementById("divallnotesbckfade").style.display = "block";

            document.getElementById("ctl00_header1_txt_EditTask_ConatctPhone").value = '';
            document.getElementById("ctl00_header1_txt_Edit_ContactMobile").value = '';
            document.getElementById("ctl00_header1_txt_EditTask_DeptPhone").value = '';
            Call_EditTaskMethod_FromHeader(id);
            if (Browser().toLocaleLowerCase().trim() == "firefox") {
                document.getElementById("ctl00_header1_RadTimePicker1_FromHeader_timeView_tdl").style.marginLeft = "205px";
                document.getElementById("ctl00_header1_RadTimePicker1_FromHeader_timeView_tdl").style.marginTop = "166px";
                document.getElementById("fc").style.marginLeft = "-30px";
                document.getElementById("fc").style.marginTop = "9px";
            } else if (Browser().toLocaleLowerCase() == "safari") {
                document.getElementById("DivOpenActiDetails_FromHeader").style.top = "25%";
                document.getElementById("DivOpenActiDetails_FromHeader").style.left = "30%";
                document.getElementById("ctl00_header1_RadTimePicker1_FromHeader_timeView_tdl").style.marginLeft = "43px";
                document.getElementById("ctl00_header1_RadTimePicker1_FromHeader_timeView_tdl").style.marginTop = "23px";
                document.getElementById("fc").style.marginLeft = "-51px";
                document.getElementById("fc").style.marginTop = "23px";
            } else {
                document.getElementById("ctl00_header1_RadTimePicker1_FromHeader_timeView_tdl").style.marginLeft = "205px";
                document.getElementById("ctl00_header1_RadTimePicker1_FromHeader_timeView_tdl").style.marginTop = "153px";
                document.getElementById("fc").style.marginLeft = "-30px";
                document.getElementById("fc").style.marginTop = "8px";
            }
            return false;
        }
        else if (SectionName.toLowerCase() == "call") {
            document.getElementById("ctl00_header1_lbl_Detail_FromHeader").innerHTML = "Call Detail";
            document.getElementById("DivOpenActiDetails_FromHeader").style.display = "block";
            document.getElementById("div_Popupfieldes_FromHeader").style.display = "block";
            document.getElementById("DivEditCallTimerSecond").style.display = "none";
            document.getElementById("DivEditTaskSubject_FromHeader").style.display = "none";
            document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
            document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
            document.getElementById("DivNotesPopup_FromHeader").style.display = "none";
            document.getElementById("span_EditCallStartdate_FromHeader").style.display = "none";
            document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
            document.getElementById("DivEditCallTimer_FromHeader").style.display = "none";
            document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
            document.getElementById("ctl00_header1_btn_FollowTask_FromHeader").style.display = "block";
            document.getElementById("ctl00_header1_btn_FollowCall_FromHeader").style.display = "block";
            document.getElementById("ctl00_header1_btn_EditDetails_FromHeader").style.display = "block";
            document.getElementById("ctl00_header1_btn_DeleteDetails_FromHeader").style.marginLeft = "0px";
            document.getElementById("divallnotesbckfade").style.display = "block";

            document.getElementById("ctl00_header1_txt_EditCall_ContactPhone").value = '';
            document.getElementById("ctl00_header1_txt_EditCall_ContactMobile").value = '';
            document.getElementById("ctl00_header1_txt_EditCall_DeptPhone").value = '';

            Call_EditCallMethod_FromHeader(id);
            if (Browser().toLocaleLowerCase().trim() == "firefox") {
                document.getElementById("ctl00_header1_RadTimePicker6_FromHeader_timeView_tdl").style.marginLeft = "211px";
                document.getElementById("ctl00_header1_RadTimePicker6_FromHeader_timeView_tdl").style.marginTop = "168px";
                document.getElementById("fc").style.marginLeft = "-25px";
                document.getElementById("fc").style.marginTop = "13px";
            } else if (Browser().toLocaleLowerCase() == "safari") {
                document.getElementById("DivOpenActiDetails_FromHeader").style.top = "25%";
                document.getElementById("DivOpenActiDetails_FromHeader").style.left = "30%";
                document.getElementById("ctl00_header1_RadTimePicker6_FromHeader_timeView_tdl").style.marginLeft = "49px";
                document.getElementById("ctl00_header1_RadTimePicker6_FromHeader_timeView_tdl").style.marginTop = "29px";
                document.getElementById("fc").style.marginLeft = "-45px";
                document.getElementById("fc").style.marginTop = "30px";
            } else {
                document.getElementById("ctl00_header1_RadTimePicker6_FromHeader_timeView_tdl").style.marginLeft = "211px";
                document.getElementById("ctl00_header1_RadTimePicker6_FromHeader_timeView_tdl").style.marginTop = "160px";
                document.getElementById("fc").style.marginLeft = "-25px";
                document.getElementById("fc").style.marginTop = "17px";
            }
            return false;
        }
    }
}

//----------------------------------------- From Header View,Edit,Update,Add Task ------------------------------------//

function Edit_TaskCallDetails_FromHeader(btnids) {
    document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
    var hdnbuttonid_FromHeader = document.getElementById("ctl00_header1_hdnbuttonid_FromHeader");
    var hdnCommanID_FromHeader = document.getElementById("ctl00_header1_hdnCommanID_FromHeader");
    var hdnSectionName_FromHeader = document.getElementById("ctl00_header1_hdnSectionName_FromHeader");

    if (hdnSectionName_FromHeader.value != "") {
        if (hdnSectionName_FromHeader.value.toLowerCase() == "task") {
            document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
            document.getElementById("span_EditMinuteSecond").style.display = "none";
            document.getElementById("span_EditMinuteSecond").style.display = "none";
            document.getElementById("Span_ddlEditsubject_FromHeader").style.display = "none";
            document.getElementById("Span_ddlEditassignto_FromHeader").style.display = "none";
            document.getElementById("span_ddlEditStataus_FromHeader").style.display = "none";
            document.getElementById("span_ddlTaskEditPriority_FromHeader").style.display = "none";
            document.getElementById("span_txtEditDueDate_FromHeader").style.display = "none";
            document.getElementById("span_txtEditDueDate1_FromHeader").style.display = "none";
            document.getElementById("DivtaskEditSecond_FromHeader").style.display = "none";
            document.getElementById("DivEventsSubject_FromHeader").style.display = "none";
            document.getElementById("DivEventPopUpEdit_FromHeader").style.display = "none";
            document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
            document.getElementById("DivCallPopup_FromHeader").style.display = "none";
            document.getElementById("DivNotesPopup_FromHeader").style.display = "none";
            document.getElementById("DivtaskPopUpEdit_FromHeader").style.zIndex = "555555";
            document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "block";
            document.getElementById("DivtaskEdit_FromHeader").style.display = "block";
            document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "block";
            document.getElementById("divalertcontant").style.zIndex = "555";
            BindAssigento(CompanyID, UserID, document.getElementById("ctl00_header1_hdnClientID_FromHeader").value);
            BindTaskSbject(CompanyID);
            load_TaskStatusDDl(CompanyID);
            Call_EditTaskMethod_FromHeader(hdnCommanID_FromHeader.value);
            if (Browser().toLocaleLowerCase() == "safari") {
                document.getElementById("DivtaskPopUpEdit_FromHeader").style.top = "25%";
                document.getElementById("DivtaskPopUpEdit_FromHeader").style.left = "30%";
            }
            return false;
        }
        else if (hdnSectionName_FromHeader.value.toLowerCase() == "call") {
            document.getElementById("DivEditCallTimerSecond").style.display = "none";
            document.getElementById("DivEditTaskSubject_FromHeader").style.display = "none";
            document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
            document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
            document.getElementById("DivCallPopup_FromHeader").style.display = "none";
            document.getElementById("DivNotesPopup_FromHeader").style.display = "none";
            document.getElementById("span_EditCallSubject").style.display = "none";
            document.getElementById("span_EditCallStartdate_FromHeader").style.display = "none";
            document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
            document.getElementById("DivEditCallTimer_FromHeader").style.display = "block";
            document.getElementById("DivEditCallPopup_FromHeader").style.zIndex = "555555";
            document.getElementById("ctl00_header1_LinkButton18").style.display = "none";
            document.getElementById("DivEditCallPopup_FromHeader").style.display = "block";
            document.getElementById("divallnotesbckfade").style.display = "block";
            document.getElementById("divalertcontant").style.zIndex = "555";
            BindCallSbject(CompanyID);
            BindAssigento(CompanyID, UserID, document.getElementById("ctl00_header1_hdnClientID_FromHeader").value);
            Call_EditCallMethod_FromHeader(hdnCommanID_FromHeader.value);
            if (Browser().toLocaleLowerCase() == "safari") {
                document.getElementById("DivEditCallPopup_FromHeader").style.top = "25%";
                document.getElementById("DivEditCallPopup_FromHeader").style.left = "30%";
            }
            return false;
        }
    }
}

function Call_EditTaskMethod_FromHeader(id) {

    CRM_Edit_Task_FromHeader(id);
}

function CRM_Edit_Task_FromHeader(id) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_Edit_Task",
        data: GetTask_Editdata_FromHeader(id),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTask_AfterEdit_FromHeader,
        error: ServiceFailed
    });
}

function GetTask_Editdata_FromHeader(id) {

    var FinalStringofEditNote = ' { "id" : "' + id + '" } '
    return FinalStringofEditNote;
}

//var EditContactData = '';
function BindTask_AfterEdit_FromHeader(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    //EditContactData = data.d;
    var ddlEditsubject_FromHeader = document.getElementById("ctl00_header1_ddlEditsubject_FromHeader");
    var ddlEditassignto_FromHeader = document.getElementById("ctl00_header1_ddlEditassignto_FromHeader");
    var ddlEditStataus_FromHeader = document.getElementById("ctl00_header1_ddlEditStataus_FromHeader");
    var ddlTaskEditPriority_FromHeader = document.getElementById("ctl00_header1_ddlTaskEditPriority_FromHeader");
    var ddlEditContact_FromHeader = document.getElementById("ctl00_header1_ddlEditContact_FromHeader");
    var txtEditDueDate_FromHeader = document.getElementById("ctl00_header1_txtEditDueDate_FromHeader");
    var txtEditTaskDesc_FromHeader = document.getElementById("ctl00_header1_txtEditTaskDesc_FromHeader");
    var dateInput_text = $find("ctl00_header1_RadTimePicker1_FromHeader").get_dateInput();
    var txt_EditTask_ConatctPhone = document.getElementById("ctl00_header1_txt_EditTask_ConatctPhone");
    var txt_EditTask_ContactMobile = document.getElementById("ctl00_header1_txt_Edit_ContactMobile");
    var txt_EditTask_DeptPhone = document.getElementById("ctl00_header1_txt_EditTask_DeptPhone");

    for (i = 0; i < ddlEditsubject_FromHeader.length; i++) {
        if (ddlEditsubject_FromHeader.options[i].text == dataRows[0].Subject) {
            ddlEditsubject_FromHeader.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditassignto_FromHeader.length; i++) {
        if (ddlEditassignto_FromHeader.options[i].value == dataRows[0].AssignToUserId) {
            ddlEditassignto_FromHeader.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditStataus_FromHeader.length; i++) {
        if (ddlEditStataus_FromHeader.options[i].text == dataRows[0].TaskStatus) {
            ddlEditStataus_FromHeader.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlTaskEditPriority_FromHeader.length; i++) {
        if (ddlTaskEditPriority_FromHeader.options[i].text == dataRows[0].Priority) {
            ddlTaskEditPriority_FromHeader.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditContact_FromHeader.length; i++) {
        if (ddlEditContact_FromHeader.options[i].value == dataRows[0].ContactId) {
            ddlEditContact_FromHeader.selectedIndex = i;
        }
    }

    txtEditDueDate_FromHeader.value = dataRows[0].DueDate;
    dateInput_text.set_value(dataRows[0].TaskTime);
    txtEditTaskDesc_FromHeader.innerHTML = dataRows[0].Description;
    txtEditTaskDesc_FromHeader.value = dataRows[0].Description;
    if (dataRows[0].Contactphone != '') {
        txt_EditTask_ConatctPhone.value = dataRows[0].Contactphone;
        txt_EditTask_ConatctPhone.disabled = true;
    }
    else {
        txt_EditTask_ConatctPhone.value = dataRows[0].Contactphone;
        txt_EditTask_ConatctPhone.disabled = false;
    }
    if (dataRows[0].ContactMobile != '') {
        txt_EditTask_ContactMobile.value = dataRows[0].ContactMobile;
        txt_EditTask_ContactMobile.disabled = true;
    }
    else {
        txt_EditTask_ContactMobile.value = dataRows[0].ContactMobile;
        txt_EditTask_ContactMobile.disabled = false;
    }
    if (dataRows[0].DepartmentPhone != '') {
        txt_EditTask_DeptPhone.value = dataRows[0].DepartmentPhone;
        txt_EditTask_DeptPhone.disabled = true;
    }
    else {
        txt_EditTask_DeptPhone.value = dataRows[0].DepartmentPhone;
        txt_EditTask_DeptPhone.disabled = false;
    }

    //..........................For details........................

    var lbldetStatus_FromHeader = document.getElementById("ctl00_header1_lbldetStatus_FromHeader");
    var lblDetSubject_FromHeader = document.getElementById("ctl00_header1_lblDetSubject_FromHeader");
    var lbldetType_FromHeader = document.getElementById("ctl00_header1_lbldetType_FromHeader");
    var lbldetDueDate_FromHeader = document.getElementById("ctl00_header1_lbldetDueDate_FromHeader");
    var lbldetContactName_FromHeader = document.getElementById("ctl00_header1_lbldetContactName_FromHeader");
    var lbldetContactMobile_FromHeader = document.getElementById("ctl00_header1_lbldetContactMobile_FromHeader");
    var lbldetContactPhone_FromHeader = document.getElementById("ctl00_header1_lbldetContactPhone_FromHeader");
    var lbldetAssignTo_FromHeader = document.getElementById("ctl00_header1_lbldetAssignTo_FromHeader");
    var lbldetDescription_FromHeader = document.getElementById("ctl00_header1_lbldetDescription_FromHeader");
    var lbldeptPhone_FromHeader = document.getElementById("ctl00_header1_lbldeptPhone_FromHeader");
    var lblClientName_FromHeader = document.getElementById("ctl00_header1_lblClientName_FromHeader");

    var lbldetCompanyName = document.getElementById("ctl00_header1_lbldetCompanyName_FromHeader");
    lbldetCompanyName.innerHTML = dataRows[0].clientName;

    lbldetStatus_FromHeader.innerHTML = dataRows[0].TaskStatus;
    lblDetSubject_FromHeader.innerHTML = dataRows[0].Subject;
    lbldetType_FromHeader.innerHTML = "Task";
    lbldetDueDate_FromHeader.innerHTML = dataRows[0].DueDate + " " + dataRows[0].TaskTime;
    lbldetContactName_FromHeader.innerHTML = dataRows[0].ContactName;
    lbldetContactMobile_FromHeader.innerHTML = dataRows[0].ContactMobile;
    lbldetContactPhone_FromHeader.innerHTML = dataRows[0].Contactphone;
    lbldetAssignTo_FromHeader.innerHTML = dataRows[0].AssignTo;
    lbldetDescription_FromHeader.innerHTML = dataRows[0].Description;
    lbldetDescription_FromHeader.title = dataRows[0].Description;
    lbldeptPhone_FromHeader.innerHTML = dataRows[0].DepartmentPhone;
    lbldeptPhone_FromHeader.title = dataRows[0].DepartmentPhone;
    lblClientName_FromHeader.innerHTML = dataRows[0].clientName;
    lblClientName_FromHeader.setAttribute("href", dataRows[0].areff);
}


function addnote_FromHeader() {
    //added loading image for ticket 13607
    document.getElementById('ctl00_header1_BtnNotesSave_FromHeader').style.display = 'block';
    document.getElementById('div_loading_BtnNotesSave_FromHeader').style.display = 'none';

    Close_CallPopup_FromHeader();

    Close_TaskPopup_FromHeader();
    document.getElementById("ctl00_header1_hdn_Type").value = "notes";
    document.getElementById("taskborderright").style.color = "#000000";
    document.getElementById("Callborderright").style.color = "#000000";

    clearNoteValue_FromHeader();
    document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
    document.getElementById("divalertcontant").style.display = "Block";

    document.getElementById("div_Popupfieldes_FromHeader").style.display = "none";
    document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
    document.getElementById("DivCallPopup_FromHeader").style.display = "none";
    document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
    document.getElementById("DivEditCallTimer_FromHeader").style.display = "none";
    document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
    document.getElementById("DivEditTaskSubject_FromHeader").style.display = "none";
    document.getElementById("DivEventsSubject_FromHeader").style.display = "none";
    document.getElementById("DivEventPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("MainDivCallTimer_FromHeader").style.display = "block";
    document.getElementById("MainDivCallTimerSecond_FromHeader").style.display = "none";
    document.getElementById("spn_ddlCallsubject").style.display = "none";
    document.getElementById("spn_ddlCallCustomers").style.display = "none";
    document.getElementById("Span_MinuteSecond_FromHeader").style.display = "none";
    document.getElementById("DurationStar_FromHeader").style.display = "none";
    document.getElementById("DivNotesPopup_FromHeader").style.display = "none";
    document.getElementById("DivTaskMain_FromHeader").style.display = "block";
    document.getElementById("DivTaskMainSecond_FromHeader").style.display = "none";
    document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
    document.getElementById('spn_ddlAddTasksubject_FromHeader').style.display = "none";
    document.getElementById('spn_ddlTaskCustomer_FromHeader').style.display = "none";
    document.getElementById('spn_ddlTaskassigneto_FromHeader').style.display = "none";
    document.getElementById('Span_ddlstatus_FromHeader').style.display = "none";
    document.getElementById('Span_ddlAddTaskpriority').style.display = "none";
    document.getElementById('Span_txtduedate_FromHeader').style.display = "none";
    document.getElementById('Span_txtduedate1_FromHeader').style.display = "none";
    document.getElementById('ctl00_header1_Img_ClearSubject_FromHeader').style.display = "none";
    document.getElementById('ctl00_header1_img_Clearcontacts_FromHeader').style.display = "none";
    document.getElementById("divnotescontentvalidate_FromHeader").style.display = "none";
    document.getElementById("spn_ddlNotesCustomers").style.display = "none";
    document.getElementById("DivAddNotePopup_FromHeader").style.display = "block";
    document.getElementById("divallnotesbckfade").style.display = "block";
    document.getElementById("divalertcontant").style.zIndex = "555";
    //document.getElementById("ctl00_header1_ddl_NotesCustomers").value = '';
    document.getElementById("ctl00_header1_ddl_Notes_specificTo").selectedIndex = 0;

    var ddl_NotesCustomers = document.getElementById("ctl00_header1_txt_NoteCustomers_FromHeader");
    var ddl_Notes_specificTo = document.getElementById("ctl00_header1_ddl_Notes_specificTo");
    if (window.location.href.toLocaleLowerCase().indexOf('estimate_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('job_summary_reeng') > -1
        || window.location.href.toLocaleLowerCase().indexOf('invoice_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('order_summary') > -1
        || window.location.href.toLocaleLowerCase().indexOf('job_order_summary') > -1 || window.location.href.toLocaleLowerCase().indexOf('invoice_order_summary') > -1
        || window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
        if (window.location.href.toLocaleLowerCase().indexOf('invoice_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('invoice_order_summary') > -1) {
            EstimateID = 0;
        }
        if (ddl_NotesCustomers != null && ddl_NotesCustomers != undefined) {
            if (window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
                SelectedClientID_FromHeader.value = document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value;
                load_CustomerName_FromHeader(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value);
                if (ddl_NotesCustomers.value != null && ddl_NotesCustomers.value != undefined && SelectedClientID_FromHeader.value != 0) {
                    Load_Summury_Contactlist(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value);
                }
            } else {
                SelectedClientID_FromHeader.value = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value;
                load_CustomerName_FromHeader(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value);
                if (ddl_NotesCustomers.value != null && ddl_NotesCustomers.value != undefined && SelectedClientID_FromHeader.value != 0) {
                    Load_Summury_Contactlist(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value);
                }
            }
        }
    } else if (window.location.href.toLocaleLowerCase().indexOf('client/client_detail') > -1) {
        if (ddl_NotesCustomers != null && ddl_NotesCustomers != undefined) {
            if (CompanyType.toLowerCase() != null && CompanyType.toLowerCase() != undefined) {
                SelectedClientID_FromHeader.value = document.getElementById("ctl00_ContentPlaceHolder1_Client_hid_ClientID").value;
                load_CustomerName_FromHeader(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_Client_hid_ClientID").value);
            } else {
                ddl_NotesCustomers.value = 0;
            }
            if (ddl_NotesCustomers.value != null && ddl_NotesCustomers.value != undefined && SelectedClientID_FromHeader.value != 0) {
                Load_Client_Contactlist(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_Client_hdn_ContactIDs").value);
            }
        }
    }
}

function clearNoteValue_FromHeader() {
    document.getElementById('ctl00_header1_txtnoteTitle_FromHeader').value = "";
    document.getElementById('ctl00_header1_txtNoteDesc_FromHeader').value = "";
}

function Close_Edit_OpenActivities_FromHeader() {
    document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivtaskEdit_FromHeader").style.display = "none";
    document.getElementById("divallnotesbckfade").style.display = "none";
}


//......................................................... Loading all DropdownList FromHeader .............................................//
var TypeFromCRM;
function Load_AllDropdownlist(CompanyID, ClientID, Type) {
    TypeFromCRM = Type;
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/BindAllPopupDropDownList",
        data: Get_LoadDDL(CompanyID, ClientID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: GetResult_ContactsList,
        error: ServiceFailed
    });
}

function Get_LoadDDL() {
    var FinalString = ' {  "CompanyID" : "' + CompanyID + '", "ClientID" : "' + ClientID + '"} '
    return FinalString;
}

var EditContactData = '';
function GetResult_ContactsList(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    EditContactData = data.d;
    var ddlspecificToNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");
    var ddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var ddlCallAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");
    var ddlEditCallContact = document.getElementById("ctl00_header1_ddlEditCallContact");
    var ddlEditContact_FromHeader = document.getElementById("ctl00_header1_ddlEditContact_FromHeader");
    var ddlEditContact = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditContact");
    var Type = document.getElementById("ctl00_header1_hdnSectionName_FromHeader").value;

    if (Type.toLowerCase() == "task") {
        ContactId = document.getElementById("ctl00_header1_ddlEditContact_FromHeader");
        EditConatctPhone = document.getElementById("ctl00_header1_txt_EditTask_ConatctPhone");
        EditContactMobile = document.getElementById("ctl00_header1_txt_Edit_ContactMobile");
        EditDeptPhone = document.getElementById("ctl00_header1_txt_EditTask_DeptPhone");
    }
    if (Type.toLowerCase() == "call") {
        ContactId = document.getElementById("ctl00_header1_ddlEditCallContact");
        EditConatctPhone = document.getElementById("ctl00_header1_txt_EditCall_ContactPhone");
        EditContactMobile = document.getElementById("ctl00_header1_txt_EditCall_ContactMobile");
        EditDeptPhone = document.getElementById("ctl00_header1_txt_EditCall_DeptPhone");
    }
    if (TypeFromCRM != undefined) {
        if (TypeFromCRM.toLowerCase() == "task") {  //This will be used fill the ContactPhone,ContactMobile and DepartmentPhone for task and calls from CRM Page
            ContactId = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
            EditConatctPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactPhone");
            EditContactMobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactMobile");
            EditDeptPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskDepartmentPhone");

            for (var i = 0; i < dataRows.length; i++) {
                if (dataRows[i].DefaultContact.toLocaleLowerCase() == "true") {
                    if (dataRows[i].ContactPhone != "") {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactPhone").value = dataRows[i].ContactPhone;
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactPhone").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactPhone").disabled = false;
                    }
                    if (dataRows[i].ContactMobile != "") {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactMobile").value = dataRows[i].ContactMobile;
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactMobile").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskContactMobile").disabled = false;
                    }
                    if (dataRows[i].DepartmentPhone != "") {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskDepartmentPhone").value = dataRows[i].DepartmentPhone;
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskDepartmentPhone").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_TaskDepartmentPhone").disabled = false;
                    }
                    break;
                }
            }
        }
        if (TypeFromCRM.toLowerCase() == "call") {  //This will be used fill the ContactPhone,ContactMobile and DepartmentPhone for task and calls from CRM Page
            ContactId = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");
            EditConatctPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactPhone");
            EditContactMobile = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactMobile");
            EditDeptPhone = document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallDepartmentPhone");

            for (var i = 0; i < dataRows.length; i++) {
                if (dataRows[i].DefaultContact.toLocaleLowerCase() == "true") {
                    if (dataRows[i].ContactPhone != "") {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactPhone").value = dataRows[i].ContactPhone;
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactPhone").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactPhone").disabled = false;
                    }
                    if (dataRows[i].ContactMobile != "") {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactMobile").value = dataRows[i].ContactMobile;
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactMobile").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallContactMobile").disabled = false;
                    }
                    if (dataRows[i].DepartmentPhone != "") {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallDepartmentPhone").value = dataRows[i].DepartmentPhone;
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallDepartmentPhone").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_Client_txt_CallDepartmentPhone").disabled = false;
                    }
                    break;
                }
            }
        }
    }


    var ddlEditEventContact = document.getElementById("ctl00_header1_ddlEditEventContact");
    var ddlspecificTo = document.getElementById("ctl00_header1_ddlspecificTo");
    ddlEditContact_FromHeader.onchange = EditSelectContact;
    ddlEditCallContact.onchange = EditSelectContact;
    ddlTaskContacts.onchange = EditSelectContact;
    ddlCallAssignTo.onchange = EditSelectContact;
    ddlEditContact.onchange = EditSelectContact;
    AddOption(ddlEditCallContact, dataRows);
    AddOption(ddlEditContact_FromHeader, dataRows);
    AddOption(ddlTaskContacts, dataRows);
    AddOption(ddlCallAssignTo, dataRows);
    AddOption(ddlspecificToNotes, dataRows);
}

function AddOption(ddl, dataRows) {

    while (ddl.options.length > 0) {
        ddl.options.remove(0);
    }

    var option = document.createElement("option");
    option.text = "--Select--";
    option.value = 0;
    ddl.options.add(option);

    if (dataRows.length == 0) {
        return;
    }

    for (var i = 0; i < dataRows.length; i++) {
        var optionvalues = document.createElement("option");
        optionvalues.text = dataRows[i].ContactName;
        optionvalues.value = dataRows[i].ContactID;
        ddl.options.add(optionvalues);

        if (dataRows[i].DefaultContact.toLowerCase() == "true") {
            ddl.value = dataRows[i].ContactID;
        }
    }
}

function load_ddlCustomers(CompanyID) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadCustomerList",
        data: Get_LoadddlCustomers(CompanyID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var ddlTaskCustomers_FromHeader = document.getElementById("ctl00_header1_txt_TaskCustomers_FromHeader");
            var ddlCallCustomers = document.getElementById("ctl00_header1_txt_CallCustomers_FromHeader");
            var ddl_NotesCustomers = document.getElementById("ctl00_header1_txt_NoteCustomers_FromHeader");
            BindResult_Customerlist(ddlTaskCustomers_FromHeader, data);
            BindResult_Customerlist(ddlCallCustomers, data);
            BindResult_Customerlist(ddl_NotesCustomers, data);
        },
        error: function (data) { }
    });
}

function Get_LoadddlCustomers() {

    var FinalString = ' {  "CompanyID" : "' + CompanyID + '"} '
    return FinalString;
}

function BindResult_Customerlist(ddl, result) {
    var dataRows = result.d;

    while (ddl.options.length > 0) {
        ddl.options.remove(0);
    }

    var option = document.createElement("option");
    option.text = "--Select--";
    option.value = 0;
    ddl.options.add(option);
    for (var i = 0; i < dataRows.length; i++) {
        var optionvalues = document.createElement("option");
        optionvalues.text = dataRows[i].ClientName;
        optionvalues.value = dataRows[i].ClientID;
        ddl.options.add(optionvalues);
    }
}

function Bind_Task_CustomerContact() {
    var ddlTaskCustomers_FromHeader = document.getElementById("ctl00_header1_txt_TaskCustomers_FromHeader");
    var ddlTaskContacts_FromHeader = document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader");
    var hdn_SelectedClientID = document.getElementById("ctl00_header1_hdn_SelectedClientID");

    if (document.getElementById("DivNotesPopup_FromHeader").style.display == "block") {
        if (ddlTaskCustomers_FromHeader != null && ddlTaskCustomers_FromHeader != undefined) {
            hdn_SelectedClientID.value = ddlTaskCustomers_FromHeader.options[ddlTaskCustomers_FromHeader.selectedIndex].value;
            document.getElementById("ctl00_header1_hdn_Type").value = "task";
        }
    } else {
        hdn_SelectedClientID.value = 0;
    }
    Load_Contactlist(CompanyID, hdn_SelectedClientID.value);
}

function Bind_Call_CustomerContact() {
    var ddlCallCustomers = document.getElementById("ctl00_header1_txt_CallCustomers_FromHeader");
    var ddlCallContacts = document.getElementById("ctl00_header1_ddlCallContacts");
    var hdn_SelectedClientID = document.getElementById("ctl00_header1_hdn_SelectedClientID");

    if (document.getElementById("DivCallPopup_FromHeader").style.display == "block") {
        if (ddlCallCustomers != null && ddlCallCustomers != undefined) {
            hdn_SelectedClientID.value = SelectedClientID_FromHeader.value;
            document.getElementById("ctl00_header1_hdn_Type").value = "call";
        }
    } else {
        hdn_SelectedClientID.value = 0;
    }
    Load_Contactlist(CompanyID, hdn_SelectedClientID.value);
}

function Bind_Notes_CustomerContact() {
    var ddl_NotesCustomers = document.getElementById("ctl00_header1_ddl_NotesCustomers");
    var ddl_Notes_specificTo = document.getElementById("ctl00_header1_ddl_Notes_specificTo");
    var hdn_SelectedClientID = document.getElementById("ctl00_header1_hdn_SelectedClientID");

    if (document.getElementById("DivAddNotePopup_FromHeader").style.display == "block") {
        if (ddl_NotesCustomers != null && ddl_NotesCustomers != undefined) {
            hdn_SelectedClientID.value = SelectedClientID_FromHeader.value;
            document.getElementById("ctl00_header1_hdn_Type").value = "notes";
        }
    } else {
        hdn_SelectedClientID.value = 0;
    }
    Load_Contactlist(CompanyID, hdn_SelectedClientID.value);
}

function Load_Contactlist(CompanyID, ClientID) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/BindContactList",
        data: Get_LoadContactDDL(CompanyID, ClientID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var dataRows = data.d;

            var hdn_ContactID = document.getElementById("ctl00_header1_hdn_ContactID");
            if (document.getElementById("ctl00_header1_hdn_Type").value == "task") {
                var ddlTaskContacts_FromHeader = document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader");
                if (ddlTaskContacts_FromHeader != null && ddlTaskContacts_FromHeader != undefined) {
                    AddOption(ddlTaskContacts_FromHeader, dataRows);
                }
            } else if (document.getElementById("ctl00_header1_hdn_Type").value == "call") {
                var ddlCallContacts = document.getElementById("ctl00_header1_ddlCallContacts");
                if (ddlCallContacts != null && ddlCallContacts != undefined) {
                    AddOption(ddlCallContacts, dataRows);
                }
            } else if (document.getElementById("ctl00_header1_hdn_Type").value == "notes") {
                var ddl_Notes_specificTo = document.getElementById("ctl00_header1_ddl_Notes_specificTo");
                if (ddl_Notes_specificTo != null && ddl_Notes_specificTo != undefined) {
                    AddOption(ddl_Notes_specificTo, dataRows);
                }
            }
        },
        error: function (data) { }
    });
}

function Get_LoadContactDDL() {
    var FinalString = ' {  "CompanyID" : "' + CompanyID + '", "ClientID" : "' + document.getElementById("ctl00_header1_hdn_SelectedClientID").value + '"} '
    return FinalString;
}

function load_TaskStatusDDl(CompanyID) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadTaskStatus",
        data: Get_LoadddlCustomers(CompanyID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var ddlAddTaskStatus = document.getElementById("ctl00_header1_ddlstatus_FromHeader");
            if (ddlAddTaskStatus != null && ddlAddTaskStatus != undefined) {
                BindTaskStatusDDL(ddlAddTaskStatus, data);
            }
            var ddlEditTaskStatus = document.getElementById("ctl00_header1_ddlEditStataus_FromHeader");
            if (ddlEditTaskStatus != null && ddlEditTaskStatus != undefined) {
                BindTaskStatusDDL(ddlEditTaskStatus, data);
            }
        },
        error: function (data) { }
    });
}

function BindTaskStatusDDL(ddl, data) {
    var dataRows = data.d;
    while (ddl.options.length > 0) {
        ddl.options.remove(0);
    }

    var option = document.createElement("option");
    option.text = "--Select--";
    option.value = 0;
    ddl.options.add(option);

    if (dataRows.length == 0) {
        return;
    }

    for (var i = 0; i < dataRows.length; i++) {
        var optionvalues = document.createElement("option");
        optionvalues.text = dataRows[i].taskStatus;
        optionvalues.value = dataRows[i].tastStatusID;
        ddl.options.add(optionvalues);
    }
    ddl.selectedIndex = 4;
}

//......................................................... Task Update FromHeader .............................................//

function OpenEditSubjectDiv_FromHeader() {
    document.getElementById("DivtaskPopUpEdit_FromHeader").style.zIndex = "555";
    document.getElementById("DivEditTaskSubject_FromHeader").style.display = "block";
    document.getElementById("DivEditTaskSubject_FromHeader").style.zIndex = "5555";
    document.getElementById("ctl00_header1_txtEditSubject").value = '';
    document.getElementById("ctl00_header1_txtEditSubject").focus();
    return false;
}

function CloseEditTaskPopupAddSubject_FromHeader() {

    document.getElementById("DivEditTaskSubject_FromHeader").style.display = "none";
    document.getElementById("DivEditSubjectAddValidations_FromHeader").style.display = "none";
    document.getElementById("DivtaskPopUpEdit_FromHeader").style.zIndex = "5555";
}

function ValidateUpdateTask_FromHeader() {

    var ClientIDTask = document.getElementById("ctl00_header1_hdnClientID_FromHeader").value;
    var hdnTaskID = "";
    hdnTaskID = document.getElementById("ctl00_header1_hdnTaskID").value;
    if (hdnTaskID == "") {
        var hdnCommanID_FromHeader = document.getElementById("ctl00_header1_hdnCommanID_FromHeader");
        hdnTaskID = hdnCommanID_FromHeader.value;
    }
    var ddlEditsubject_FromHeader = document.getElementById("ctl00_header1_ddlEditsubject_FromHeader");
    var ddlEditassignto_FromHeader = document.getElementById("ctl00_header1_ddlEditassignto_FromHeader");
    var ddlEditStataus_FromHeader = document.getElementById("ctl00_header1_ddlEditStataus_FromHeader");
    var ddlTaskEditPriority_FromHeader = document.getElementById("ctl00_header1_ddlTaskEditPriority_FromHeader");
    var txtEditDueDate_FromHeader = document.getElementById("ctl00_header1_txtEditDueDate_FromHeader");
    var ddlEdithour = document.getElementById("ctl00_header1_ddlEdithour");
    var ddlEditminute = document.getElementById("ctl00_header1_ddlEditminute");
    var txtEditTaskDesc_FromHeader = document.getElementById("ctl00_header1_txtEditTaskDesc_FromHeader");
    var TxtHM = $find("ctl00_header1_RadTimePicker1_FromHeader").get_dateInput();
    var ddlTaskCustomers_FromHeader = document.getElementById("ctl00_header1_txt_TaskCustomers_FromHeader");

    var Contact_Phone = document.getElementById("ctl00_header1_txt_EditTask_ConatctPhone").value;
    var Contact_Mobile = document.getElementById("ctl00_header1_txt_Edit_ContactMobile").value;
    var Department_Phone = document.getElementById("ctl00_header1_txt_EditTask_DeptPhone").value;

    if (ddlEditsubject_FromHeader.selectedIndex == 0) {
        document.getElementById("Span_ddlEditsubject_FromHeader").style.display = "block";
    }
    if (ddlEditStataus_FromHeader.selectedIndex == 0) {
        document.getElementById("span_ddlEditStataus_FromHeader").style.display = "block";
    }
    if (ddlTaskEditPriority_FromHeader.selectedIndex == 0) {
        document.getElementById("span_ddlTaskEditPriority_FromHeader").style.display = "block";
    }
    if (SelectedClientID_FromHeader.value == 0) {
        document.getElementById("spn_ddlTaskCustomer_FromHeader").style.display = "block";
    }
    if (txtEditDueDate_FromHeader.value == '') {
        document.getElementById("span_txtEditDueDate_FromHeader").style.display = "block";
    }
    else {

        if (ValidateForm(txtEditDueDate_FromHeader, 'span_txtEditDueDate1_FromHeader', DateFormatforValidate) == false) {
            return true;
        }
    }

    if (ddlEditsubject_FromHeader.selectedIndex != 0 && ddlEditStataus_FromHeader.selectedIndex != 0 && ddlTaskEditPriority_FromHeader.selectedIndex != 0 && txtEditDueDate_FromHeader.value != '') {
        document.getElementById("divallnotesbckfade").style.display = "none";
        document.getElementById('DivtaskPopUpEdit_FromHeader').style.display = "none";

        CallUpdate_TaskMethod_FromHeader(hdnTaskID, CompanyID, '', '', '', '', '', '', '', 'client', ClientIDTask, '', '', UserID, Createddate, '', Contact_Phone, Contact_Mobile, Department_Phone); return false;
    }
}

function CallUpdate_TaskMethod_FromHeader(taskID, CompanyID, subject, taskStatus, dueDate, taskTime, contactId, contactType, priority, type, typeId, description, assignToUserId, modifyUserId, modifiedDate, NotespageNummber, Contact_Phone, Contact_Mobile, Department_Phone) {

    NotespageNummberIndex = 1;

    var ddlEditsubject_FromHeader = document.getElementById("ctl00_header1_ddlEditsubject_FromHeader");
    ddlEditsubject_FromHeader.options[ddlEditsubject_FromHeader.selectedIndex].text;
    var finalSubject = ddlEditsubject_FromHeader.options[ddlEditsubject_FromHeader.selectedIndex].text;
    var ddlEditStataus_FromHeader = document.getElementById("ctl00_header1_ddlEditStataus_FromHeader");
    ddlEditStataus_FromHeader.options[ddlEditStataus_FromHeader.selectedIndex].text;
    var finaltaskStatus = ddlEditStataus_FromHeader.options[ddlEditStataus_FromHeader.selectedIndex].text;

    var dueDate = document.getElementById("ctl00_header1_txtEditDueDate_FromHeader");

    var finalhoursMinute = "";
    var HoursMinute = $find("ctl00_header1_RadTimePicker1_FromHeader").get_dateInput();
    finalhoursMinute = HoursMinute.get_value();

    var ddlTaskEditPriority_FromHeader = document.getElementById("ctl00_header1_ddlTaskEditPriority_FromHeader");
    ddlTaskEditPriority_FromHeader.options[ddlTaskEditPriority_FromHeader.selectedIndex].text;
    var finalPriority = ddlTaskEditPriority_FromHeader.options[ddlTaskEditPriority_FromHeader.selectedIndex].text;

    var TaskDesc = document.getElementById("ctl00_header1_txtEditTaskDesc_FromHeader");

    var ddlEditassignto_FromHeader = document.getElementById("ctl00_header1_ddlEditassignto_FromHeader");
    ddlEditassignto_FromHeader.options[ddlEditassignto_FromHeader.selectedIndex].text;
    var finalAssignto = ddlEditassignto_FromHeader.options[ddlEditassignto_FromHeader.selectedIndex].value;
    EditTaskAssignTo = finalAssignto;
    var ddlEditContact_FromHeader = document.getElementById("ctl00_header1_ddlEditContact_FromHeader");

    contactId = 0;

    if (ddlEditContact_FromHeader.options.length == 0) {
        contactId = 0;
    }
    else {

        ddlEditContact_FromHeader.options[ddlEditContact_FromHeader.selectedIndex].text;
        contactId = ddlEditContact_FromHeader.options[ddlEditContact_FromHeader.selectedIndex].value;
    }
    EditTaskContact = contactId;

    CRM_Update_task_FromHeader(taskID, CompanyID, SpecialEncode(finalSubject), finaltaskStatus, dueDate.value, finalhoursMinute, contactId, contactType, finalPriority, type, typeId, TaskDesc.value, finalAssignto, modifyUserId, modifiedDate, NotespageNummberIndex, Contact_Phone, Contact_Mobile, Department_Phone);
}

function CRM_Update_task_FromHeader(taskID, CompanyID, subject, taskStatus, dueDate, taskTime, contactId, contactType, priority, type, typeId, description, assignToUserId, modifyUserId, modifiedDate, NotespageNummber, Contact_Phone, Contact_Mobile, Department_Phone) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/CrmTaskUpdate",
        data: GetInput_Updatetask(taskID, CompanyID, subject, taskStatus, dueDate, taskTime, contactId, contactType, priority, type, typeId, description, assignToUserId, modifyUserId, modifiedDate, NotespageNummber, Contact_Phone, Contact_Mobile, Department_Phone),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTask_Update_FromHeader,
        error: ServiceFailed
    });
}

function BindTask_Update_FromHeader(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var lbldetStatus_FromHeader = document.getElementById("ctl00_header1_lbldetStatus_FromHeader");
    var lblDetSubject_FromHeader = document.getElementById("ctl00_header1_lblDetSubject_FromHeader");
    var lbldetType_FromHeader = document.getElementById("ctl00_header1_lbldetType_FromHeader");
    var lbldetDueDate_FromHeader = document.getElementById("ctl00_header1_lbldetDueDate_FromHeader");
    var lbldetContactName_FromHeader = document.getElementById("ctl00_header1_lbldetContactName_FromHeader");
    var lbldetContactMobile_FromHeader = document.getElementById("ctl00_header1_lbldetContactMobile_FromHeader");
    var lbldetContactPhone_FromHeader = document.getElementById("ctl00_header1_lbldetContactPhone_FromHeader");
    var lbldetAssignTo_FromHeader = document.getElementById("ctl00_header1_lbldetAssignTo_FromHeader");
    var lbldetDescription_FromHeader = document.getElementById("ctl00_header1_lbldetDescription_FromHeader");
    var lbldetCompanyName = document.getElementById("ctl00_header1_lbldetCompanyName_FromHeader");
 
    if (dataRows.length != 0) {
        lbldetStatus_FromHeader.innerHTML = dataRows[0].Status;
        lblDetSubject_FromHeader.innerHTML = dataRows[0].Subject;
        lbldetType_FromHeader.innerHTML = dataRows[0].Type;
        lbldetDueDate_FromHeader.innerHTML = dataRows[0].DueDate + " " + dataRows[0].taskTime;
        lbldetContactName_FromHeader.innerHTML = dataRows[0].ContactName;
        lbldetContactMobile_FromHeader.innerHTML = dataRows[0].ContactMobile;
        lbldetContactPhone_FromHeader.innerHTML = dataRows[0].ContactPhone;
        lbldetAssignTo_FromHeader.innerHTML = dataRows[0].AssignTo;
        lbldetDescription_FromHeader.innerHTML = dataRows[0].Description;
        lbldetDescription_FromHeader.title = dataRows[0].Description;
        lbldetCompanyName.innerHTML = dataRows[0].clientName;
    }
    AutoFill.GetAlertNotification(onResponseAlert);
    AutoFill.GetNotificationCount(onResponseCount);
}

//------------------------------------------------------ Inset New Task FromHeader --------------------------------------------------------------//


function OpenSubjectDiv_FromHeader() {
    document.getElementById("DivOpenSubject_FromHeader").style.display = "block";
    document.getElementById("DivNotesPopup_FromHeader").style.zIndex = "555";
    document.getElementById("ctl00_header1_txtSubject").value = '';
    document.getElementById("ctl00_header1_txtSubject").focus();
}

function CloseTaskPopupAddSubject_FromHeader() {
    document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
    document.getElementById("span_callsubj_FromHeader").style.display = "none";
    document.getElementById("DivNotesPopup_FromHeader").style.zIndex = "5555";
}

function ValidateAddSubject_FromHeader() {                                        //....... Inserting task subject FromHeader.........
    var txtSubject = document.getElementById("ctl00_header1_txtSubject");

    if (txtSubject.value == '') {
        document.getElementById("DivSubjectAddValidations_FromHeader").style.display = "block";
    }

    if (txtSubject.value != '') {
        document.getElementById("DivSubjectAddValidations_FromHeader").style.display = "none";
        CallInsert_NotesSubjectMethod_FromHeader('', CompanyID, '');
        return false;
    }
}

function CallInsert_NotesSubjectMethod_FromHeader(Subject, CompanyID, Language) {

    var NotesSub = document.getElementById("ctl00_header1_txtSubject");

    CRM_Insert_Notes_Subject_FromHeader(SpecialEncode(NotesSub.value), CompanyID, Language);
    NotesSub.value = "";
}

function CRM_Insert_Notes_Subject_FromHeader(Subject, CompanyID, Language) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_subject_Insert",
        data: GetInputNotesSubject(Subject, CompanyID, Language),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindNotes_Subject_FromHeader,
        error: ServiceFailed
    });
}

function BindNotes_Subject_FromHeader(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {

        alert("Subject already exist, choose another subject");
        document.getElementById("DivOpenSubject_FromHeader").style.display = "block";
        document.getElementById("ctl00_header1_txtSubject").focus();
        return;
    }
    for (var i = 0; i < dataRows.length; i++) {

        if (dataRows[i].sampleSubject != "") {

            document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
            var opt = document.createElement("option");
            var ddlAddTasksubject_FromHeader = document.getElementById("ctl00_header1_ddlAddTasksubject_FromHeader");

            ddlAddTasksubject_FromHeader.options.add(opt);
            opt.text = dataRows[i].sampleSubject;
            opt.value = dataRows[i].sampleSubject;
            ddlAddTasksubject_FromHeader.selectedIndex = ddlAddTasksubject_FromHeader.length - 1;
            var actualvalue = ddlAddTasksubject_FromHeader.options[ddlAddTasksubject_FromHeader.selectedIndex].value;
            document.getElementById("DivNotesPopup_FromHeader").style.zIndex = "5555";
        }
    }
}


function Validatesavenotes_FromHeader() {

    var ddlAddTasksubject_FromHeader = document.getElementById("ctl00_header1_ddlAddTasksubject_FromHeader");
    var ddlTaskassigneto = document.getElementById("ctl00_header1_ddlTaskassigneto");
    var ddlstatus_FromHeader = document.getElementById("ctl00_header1_ddlstatus_FromHeader");
    var ddlAddTaskpriority = document.getElementById("ctl00_header1_ddlAddTaskpriority");
    var txtduedate = document.getElementById("ctl00_header1_txtduedate_FromHeader");
    var TxtHM = $find("ctl00_header1_RadTimePicker_FromHeader").get_dateInput();
    var ddlTaskCustomers_FromHeader = document.getElementById("ctl00_header1_txt_TaskCustomers_FromHeader");
    var ClientIDTask = SelectedClientID_FromHeader.value;

    var Contact_Phone = document.getElementById("ctl00_header1_txt_Task_ContactPhone").value;
    var Contact_Mobile = document.getElementById("ctl00_header1_txt_Task_ContactMobile").value;
    var Department_Phone = document.getElementById("ctl00_header1_txt_Task_DeptPhone").value;

    document.getElementById("spn_ddlAddTasksubject_FromHeader").style.display = "none";
    document.getElementById("Span_ddlstatus_FromHeader").style.display = "none";
    document.getElementById("Span_ddlAddTaskpriority").style.display = "none";
    document.getElementById("spn_ddlTaskCustomer_FromHeader").style.display = "none";
    document.getElementById("Span_txtduedate_FromHeader").style.display = "none";


    if (ddlAddTasksubject_FromHeader.selectedIndex == 0) {
        document.getElementById("spn_ddlAddTasksubject_FromHeader").style.display = "block";
    }
    if (SelectedClientID_FromHeader.value == 0 || ddlTaskCustomers_FromHeader.value == "") {
        document.getElementById("spn_ddlTaskCustomer_FromHeader").style.display = "block";
    }
    if (ddlstatus_FromHeader.selectedIndex == 0) {
        document.getElementById("Span_ddlstatus_FromHeader").style.display = "block";
    }
    if (ddlAddTaskpriority.selectedIndex == 0) {
        document.getElementById("Span_ddlAddTaskpriority").style.display = "block";
    }
    if (txtduedate.value == '') {
        document.getElementById("Span_txtduedate_FromHeader").style.display = "block";
    }
    else {
        if (ValidateForm(txtduedate, 'Span_txtduedate1_FromHeader', DateFormatforValidate) == false) {

        }
    }
    if (TxtHM.get_value() == '') {
        document.getElementById("Span_txtduedate_FromHeader").style.display = "block";
    }


    var ModulID = 0;
    var ModuleName = '';
    if (window.location.href.toLocaleLowerCase().indexOf('estimate_summary_reeng') > -1) {
        ModulID = document.getElementById("ctl00_header1_hdn_ModuleID_FromHeader").value = EstimateID;
        ModuleName = document.getElementById("ctl00_header1_hdn_ModuleName_FromHeader").value = 'Estimate';
    }
    else if (window.location.href.toLocaleLowerCase().indexOf('job_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('job_order_summary') > -1) {
        ModulID = document.getElementById("ctl00_header1_hdn_ModuleID_FromHeader").value = jobID;
        ModuleName = document.getElementById("ctl00_header1_hdn_ModuleName_FromHeader").value = 'Job';
    }
    else if (window.location.href.toLocaleLowerCase().indexOf('invoice_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('invoice_order_summary') > -1) {
        ModulID = document.getElementById("ctl00_header1_hdn_ModuleID_FromHeader").value = InvoiceID;
        ModuleName = document.getElementById("ctl00_header1_hdn_ModuleName_FromHeader").value = 'Invoice';
    }
    else if (window.location.href.toLocaleLowerCase().indexOf('order_summary') > -1) {
        ModulID = document.getElementById("ctl00_header1_hdn_ModuleID_FromHeader").value = EstimateID;
        ModuleName = document.getElementById("ctl00_header1_hdn_ModuleName_FromHeader").value = 'Order';
    }

    if (ddlAddTasksubject_FromHeader.selectedIndex != 0 && ddlstatus_FromHeader.selectedIndex != 0 && ddlAddTaskpriority.selectedIndex != 0 && SelectedClientID_FromHeader.value != 0 && txtduedate.value != '' && TxtHM.get_value() != '' && ValidateDateTime(txtduedate.value, TxtHM.get_value()) == true && ddlTaskCustomers_FromHeader.value != "") {
        //added loading image for ticket 13607 
        document.getElementById('ctl00_header1_btnsavetasks_FromHeader').style.display = 'none';
        document.getElementById('div_loading_btnsavetasks_FromHeader').style.display = 'block';
        CallInsert_TaskMethod_FromHeader(CompanyID, '', '', '', '', '', 0, '', 'client', ClientIDTask, '', 0, '', UserID, UserID, Createddate, Createddate, '', 0, '', '', 0, ModulID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone);
        return false;
    }
}

function CallInsert_TaskMethod_FromHeader(companyId, subject, taskTitle, taskStatus, dueDate, taskTime, contactId, priority, type, typeid, description, isSample, assignToUserId, createUserId, modifyUserId, createDate, modifiedDate, contactType, isDelete, NotespageNummber, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone) {
    NotespageNummberIndex = 1;
    var Subject = document.getElementById("ctl00_header1_ddlAddTasksubject_FromHeader");
    Subject.options[Subject.selectedIndex].text;
    var finalSubject = Subject.options[Subject.selectedIndex].text;

    var Status = document.getElementById("ctl00_header1_ddlstatus_FromHeader");
    Status.options[Status.selectedIndex].text;
    var finalStatus = Status.options[Status.selectedIndex].text;

    var Duedate = document.getElementById("ctl00_header1_txtduedate_FromHeader");

    var finalhoursMinute = "";
    var HoursMinute = $find("ctl00_header1_RadTimePicker_FromHeader").get_dateInput();
    finalhoursMinute = HoursMinute.get_value();

    var Priority = document.getElementById("ctl00_header1_ddlAddTaskpriority");
    Priority.options[Priority.selectedIndex].text;
    var finalPriority = Priority.options[Priority.selectedIndex].text;

    var desc = document.getElementById("ctl00_header1_txtNotesDesc_FromHeader");

    var ddlTaskassigneto_FromHeader = document.getElementById("ctl00_header1_ddlTaskassigneto_FromHeader");
    ddlTaskassigneto_FromHeader.options[ddlTaskassigneto_FromHeader.selectedIndex].text;
    var finalAssignto = ddlTaskassigneto_FromHeader.options[ddlTaskassigneto_FromHeader.selectedIndex].value;

    TaskAssignTo = finalAssignto;

    var ddlTaskContacts_FromHeader = document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader");

    var contactId = 0;
    if (ddlTaskContacts_FromHeader.options.length == 0) {
        contactId = 0;
    }
    else {
        ddlTaskContacts_FromHeader.options[ddlTaskContacts_FromHeader.selectedIndex].text;
        contactId = ddlTaskContacts_FromHeader.options[ddlTaskContacts_FromHeader.selectedIndex].value;
    }
    TaskContact = contactId;
    CRM_Insert_task_FromHeader(CompanyID, SpecialEncode(finalSubject), '', finalStatus, Duedate.value, finalhoursMinute, contactId, finalPriority, 'client', typeid, desc.value, 0, finalAssignto, UserID, UserID, Createddate, Createddate, '', 0, NotespageNummberIndex, 0, 0, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone);

}

var TaskAssignTo;
var TaskContact;

function CRM_Insert_task_FromHeader(companyId, subject, taskTitle, taskStatus, dueDate, taskTime, contactId, priority, type, typeid, description, isSample, assignToUserId, createUserId, modifyUserId, createDate, modifiedDate, contactType, isDelete, NotespageNummber, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/CrmTaskInsert",
        data: GetInput_task(companyId, subject, taskTitle, taskStatus, dueDate, taskTime, contactId, priority, type, typeid, description, isSample, assignToUserId, createUserId, modifyUserId, createDate, modifiedDate, contactType, isDelete, NotespageNummber, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTask_FromHeader,
        error: ServiceFailed
    });
}

function BindTask_FromHeader(data) {
    document.getElementById("divallnotesbckfade").style.display = "none";
    document.getElementById('DivNotesPopup_FromHeader').style.display = "none";
    document.getElementById("ctl00_header1_hdn_SelectedClientID").value = 0;
    AutoFill.GetAlertNotification(onResponseAlert);
    AutoFill.GetNotificationCount(onResponseCount);

    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var AddNewTaskBtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkAddTask");
    var lnkEventbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkEvent");
    var lnkcallbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkcall");
    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");

    document.getElementById('DivNotesPopup').style.display = "none";
    var hdnTaskFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentID_FromHeader");
    var hdnTaskFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentType_FromHeader");
    var hdnCallFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentID_FromHeader");
    var hdnCallFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentType_FromHeader");
    var ddlassigneto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlassigneto");
    var ddlowner = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlowner");
    var ddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var ddlCallAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");
    var ddlNoteContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");

    var ddlTaskCustomers_FromHeader = document.getElementById("ctl00_header1_txt_TaskCustomers_FromHeader");
    var hdn_SelectedClientID = document.getElementById("ctl00_header1_hdn_SelectedClientID");
    hdn_SelectedClientID.value = ddlTaskCustomers_FromHeader.value;

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    if (hdn_SelectedClientID.value == ClientID) {
        lblOpenActivities.innerHTML = "";
    }

    if (hdn_SelectedClientID.value == ClientID) {
        for (var i = 0; i < dataRows.length; i++) {
            lblOpenActivities.innerHTML = dataRows[i].Alltask;
        }
    }
}

function BindTaskSbject(CompanyID) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadTaskSubject",
        data: Get_LoadddlCustomers(CompanyID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var ddlEditSubject_FromHeader = document.getElementById("ctl00_header1_ddlEditsubject_FromHeader");
            if (ddlEditSubject_FromHeader != null && ddlEditSubject_FromHeader != undefined) {
                BindTaskSubjectDDL(ddlEditSubject_FromHeader, data);
            }
            var ddlAddTasksubject_FromHeader = document.getElementById("ctl00_header1_ddlAddTasksubject_FromHeader");
            if (ddlAddTasksubject_FromHeader != null && ddlAddTasksubject_FromHeader != undefined) {
                BindTaskSubjectDDL(ddlAddTasksubject_FromHeader, data);
            }
        },
        error: function (data) { }
    });
}

function BindTaskSubjectDDL(ddl, data) {
    var dataRows = data.d;

    while (ddl.options.length > 0) {
        ddl.options.remove(0);
    }

    var option = document.createElement("option");
    option.text = "--Select--";
    option.value = 0;
    ddl.options.add(option);

    if (dataRows.length == 0) {
        return;
    }

    for (var i = 0; i < dataRows.length; i++) {
        var optionvalues = document.createElement("option");
        optionvalues.text = dataRows[i].sampleSubject;
        optionvalues.value = dataRows[i].sampleSubjectId;
        ddl.options.add(optionvalues);

        if (dataRows[i].IsDefault.toLowerCase() == "true") {
            ddl.value = dataRows[i].sampleSubjectId;
            document.getElementById("ctl00_header1_hdn_DefaultTaskSubjectID_FromHeader").value = dataRows[i].sampleSubjectId;
        }
    }
}

function OpenCallSubjectDiv_FromHeader(btnid) {
    document.getElementById("DivCallSubjects_FromHeader").style.display = "block";
    document.getElementById("ctl00_header1_txtCallSubjects").value = '';
    document.getElementById("ctl00_header1_txtCallSubjects").focus();
    document.getElementById("DivCallPopup_FromHeader").style.zIndex = "555";
    document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
}

function CallChkvalidate_FromHeader() {
    var ddlCallSubject = document.getElementById("ctl00_header1_ddlCallSubject_FromHeader");
    var RdoCurrentCall = document.getElementById("ctl00_header1_RdoCurrentCall");
    var RdoCompletedCall = document.getElementById("ctl00_header1_RdoCompletedCall");
    var RdoScheduledCall = document.getElementById("ctl00_header1_RdoScheduledCall");
    var txtcallstartdate_FromHeader = document.getElementById("ctl00_header1_txtcallstartdate_FromHeader");
    var ddlcalltime = document.getElementById("ctl00_header1_ddlcalltime");

    var Contact_Phone = document.getElementById("ctl00_header1_txt_Call_ContactPhone").value;
    var Contact_Mobile = document.getElementById("ctl00_header1_txt_Call_ContactMobile").value;
    var Department_Phone = document.getElementById("ctl00_header1_txt_Call_DeptPhone").value;

    var ddlCallDetailsType123 = document.getElementById("ctl00_header1_ddlCallDetailsType");
    ddlCallDetailsType123.options[ddlCallDetailsType123.selectedIndex].text;
    var CallDetailsType123 = ddlCallDetailsType123.options[ddlCallDetailsType123.selectedIndex].value;
    var txtcallMinute = document.getElementById("ctl00_header1_txtcallMinute");
    var txtcallSecond = document.getElementById("ctl00_header1_txtcallSecond");
    var ddlassignto = document.getElementById("ctl00_header1_ddlowner");
    var TxtHM = $find("ctl00_header1_RadTimePicker4_FromHeader").get_dateInput();
    var ddlCallCustomers = document.getElementById("ctl00_header1_txt_CallCustomers_FromHeader");
    var SelectedClientID = SelectedClientID_FromHeader.value;
    if (SelectedClientID == 0) {
        SelectedClientID = FinalClientID;
    }
    document.getElementById("spn_ddlCallsubject").style.display = "none";
    document.getElementById("span_txtcallstartdate_FromHeader").style.display = "none";
    document.getElementById("span_txtcallstartdate_FromHeader").style.display = "none";
    document.getElementById("diverrorCallAssignTo_FromHeader").style.display = "none";
    document.getElementById("spn_ddlCallCustomers").style.display = "none";
    document.getElementById("diverrorCallAssignTo_FromHeader").style.display = "none";


    if (ddlassignto.options.length == 0) {
        document.getElementById("diverrorCallAssignTo_FromHeader").style.display = "block";
    }
    if (ddlCallSubject.selectedIndex == 0) {
        document.getElementById("spn_ddlCallsubject").style.display = "block";
    }
    if (ddlCallCustomers.value == '') {
        document.getElementById("spn_ddlCallCustomers").style.display = "block";
    }
    if (CallDetailsType123 == "2") {
        if (TxtHM.get_value() == '') {
            document.getElementById("span_txtcallstartdate_FromHeader").style.display = "block";
        }
        if (txtcallstartdate_FromHeader.value == '') {
            document.getElementById("span_txtcallstartdate_FromHeader").style.display = "block";
        }
    }
    else if (CallDetailsType123 == "3") {
        if (TxtHM.get_value() == '') {
            document.getElementById("span_txtcallstartdate_FromHeader").style.display = "block";
        }
        if (txtcallstartdate_FromHeader.value == '') {
            document.getElementById("span_txtcallstartdate_FromHeader").style.display = "block";
        }
    }


    var ModulID = 0;
    var ModuleName = '';
    if (window.location.href.toLocaleLowerCase().indexOf('estimate_summary_reeng') > -1) {
        ModulID = document.getElementById("ctl00_header1_hdn_ModuleID_FromHeader").value = EstimateID;
        ModuleName = document.getElementById("ctl00_header1_hdn_ModuleName_FromHeader").value = 'Estimate';
    }
    else if (window.location.href.toLocaleLowerCase().indexOf('job_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('job_order_summary') > -1) {
        ModulID = document.getElementById("ctl00_header1_hdn_ModuleID_FromHeader").value = jobID;
        ModuleName = document.getElementById("ctl00_header1_hdn_ModuleName_FromHeader").value = 'Job';
    }
    else if (window.location.href.toLocaleLowerCase().indexOf('invoice_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('invoice_order_summary') > -1) {
        ModulID = document.getElementById("ctl00_header1_hdn_ModuleID_FromHeader").value = InvoiceID;
        ModuleName = document.getElementById("ctl00_header1_hdn_ModuleName_FromHeader").value = 'Invoice';
    }
    else if (window.location.href.toLocaleLowerCase().indexOf('order_summary') > -1) {
        ModulID = document.getElementById("ctl00_header1_hdn_ModuleID_FromHeader").value = EstimateID;
        ModuleName = document.getElementById("ctl00_header1_hdn_ModuleName_FromHeader").value = 'Order';
    }

    if (ddlCallSubject.selectedIndex != 0 && ddlCallCustomers.value != '' && TxtHM.get_value() != '' && txtcallstartdate_FromHeader.value != '' && ValidateDateTime(txtcallstartdate_FromHeader.value, TxtHM.get_value()) == true) {
        //added loading image for ticket 13607
        document.getElementById('ctl00_header1_btnSaveCall_fromheader').style.display = 'none';
        document.getElementById('div_loading_btnSaveCall_fromheader').style.display = 'block';
        Insert_Call_FromHeader(CompanyID, SelectedClientID, '', '', '', '', '', '', '', '', '', '', '', '', '', UserID, '', '', '', 0, ModulID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone);
        return false;
    }
}

var CallAssignTo;
var CallContact;

function Insert_Call_FromHeader(CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, CreatedBy, NotespageNummber, CallEndDate, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone) {

    NotespageNummberIndex = 1;

    var ddlCallSubject = document.getElementById("ctl00_header1_ddlCallSubject_FromHeader");
    var ddlCallType = document.getElementById("ctl00_header1_ddlCallType");
    var ddlCallPurpose = document.getElementById("ctl00_header1_ddlCallPurpose");
    var ddlCallContacts = document.getElementById("ctl00_header1_ddlCallContacts");
    var RdoCurrentCall = document.getElementById("ctl00_header1_RdoCurrentCall");
    var RdoCompletedCall = document.getElementById("ctl00_header1_RdoCompletedCall");
    var RdoScheduledCall = document.getElementById("ctl00_header1_RdoScheduledCall");
    var txtcallstartdate_FromHeader = document.getElementById("ctl00_header1_txtcallstartdate_FromHeader");

    var txtcallMinute = document.getElementById("ctl00_header1_txtcallMinute");
    var txtcallSecond = document.getElementById("ctl00_header1_txtcallSecond");
    var txtcallresult = document.getElementById("ctl00_header1_txtcallresult");
    var ddlowner = document.getElementById("ctl00_header1_ddlowner");
    var txtCallDesc = document.getElementById("ctl00_header1_txtCallDesc");
    var ChkBillable = document.getElementById("ctl00_header1_ChkBillable");

    ddlCallType.options[ddlCallType.selectedIndex].text;
    var finalCallType = ddlCallType.options[ddlCallType.selectedIndex].text;

    ddlCallPurpose.options[ddlCallPurpose.selectedIndex].text;
    var finalCallPurpose = ddlCallPurpose.options[ddlCallPurpose.selectedIndex].value;

    var ddlCallDetailsType = document.getElementById("ctl00_header1_ddlCallDetailsType");
    ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].text;
    var CallDetailsType = ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].value;

    var CallDetail = "";

    if (CallDetailsType == "2") {
        CallDetail = "completed";
    }
    if (CallDetailsType == "3") {
        CallDetail = "scheduled";
    }

    var finalContactID = 0;

    if (ddlCallContacts.options.length == 0) {
        finalContactID = 0;
    }
    else {
        ddlCallContacts.options[ddlCallContacts.selectedIndex].text;
        finalContactID = ddlCallContacts.options[ddlCallContacts.selectedIndex].value;
    }
    CallContact = finalContactID;
    var FinalCallMinSec = "";
    var CallMinSec = $find("ctl00_header1_RadTimePicker4_FromHeader").get_dateInput();
    FinalCallMinSec = CallMinSec.get_value();

    ddlowner.options[ddlowner.selectedIndex].text;
    var finalowner = ddlowner.options[ddlowner.selectedIndex].value;

    CallAssignTo = finalowner;

    var billable = false;
    if (ChkBillable.checked == true) {
        billable = true;
    }
    else {
        billable = false;
    }

    ddlCallSubject.options[ddlCallSubject.selectedIndex].text;
    var finalCallSubject = ddlCallSubject.options[ddlCallSubject.selectedIndex].text;
    CRM_Insert_Call_FromHeader(CompanyID, ClientID, SpecialEncode(finalCallSubject), finalCallType, finalCallPurpose, CallDetail, finalContactID, txtcallstartdate_FromHeader.value, FinalCallMinSec, txtcallMinute.value, txtcallSecond.value, txtcallresult.value, finalowner, txtCallDesc.value, billable, CreatedBy, NotespageNummberIndex, CallEndDate, '', 0, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone);
}

function CRM_Insert_Call_FromHeader(CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, CreatedBy, NotespageNummber, CallEndDate, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/CrmCallInsert",
        data: GetCrmCall(CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, CreatedBy, NotespageNummber, CallEndDate, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCalls_FromHeader,
        error: ServiceFailed
    });
}

function BindCalls_FromHeader(data) {
    document.getElementById("divallnotesbckfade").style.display = "none";
    document.getElementById('DivCallPopup_FromHeader').style.display = "none";
    document.getElementById("ctl00_header1_hdn_SelectedClientID").value = 0;
    AutoFill.GetAlertNotification(onResponseAlert);
    AutoFill.GetNotificationCount(onResponseCount);
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }

    var AddNewTaskBtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkAddTask");
    var lnkEventbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkEvent");
    var lnkcallbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkcall");

    document.getElementById("DivCallPopup").style.display = "none";
    var hdnTaskFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentID_FromHeader");
    var hdnTaskFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentType_FromHeader");
    var hdnCallFollowParentID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentID_FromHeader");
    var hdnCallFollowParentType = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentType_FromHeader");

    var ddlassigneto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlassigneto");
    var ddlowner = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlowner");
    var ddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var ddlCallAssignTo = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");

    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");
    var ddlCallAssignTo1 = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");

    var ddlCallCustomers = document.getElementById("ctl00_header1_txt_CallCustomers_FromHeader");
    var hdn_SelectedClientID = document.getElementById("ctl00_header1_hdn_SelectedClientID");
    hdn_SelectedClientID.value = SelectedClientID_FromHeader.value;

    var lblOpenActivities = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities");
    if (hdn_SelectedClientID.value == ClientID) {
        lblOpenActivities.innerHTML = "";
    }

    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var hdnprintNotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnprintNotesValue");

    var lblcloseActivity = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity");
    if (hdn_SelectedClientID.value == ClientID) {
        lblcloseActivity.innerHTML = "";
    }

    if (hdn_SelectedClientID.value == ClientID) {
        for (var i = 0; i < dataRows.length; i++) {
            lblOpenActivities.innerHTML = dataRows[i].AllCalls;
            lblcloseActivity.innerHTML = dataRows[i].AllCloseActivity;
        }
    }
}

//----------------------------------------------------------------------------------------------------------------------------------------------------------------//

function ShowEditCallDetailType_FromHeader() {
    var ddlEditCallDetails_FromHeader = document.getElementById("ctl00_header1_ddlEditCallDetails_FromHeader");

    ddlEditCallDetails_FromHeader.options[ddlEditCallDetails_FromHeader.selectedIndex].text;
    var finalCallDetailType_FromHeader = ddlEditCallDetails_FromHeader.options[ddlEditCallDetails_FromHeader.selectedIndex].value;

    if (finalCallDetailType_FromHeader == "1") {
        document.getElementById("EditDurationStar_FromHeader").style.display = "none";
    }
    if (finalCallDetailType_FromHeader == "2") {
        document.getElementById("EditDurationStar_FromHeader").style.display = "block";
    }
    if (finalCallDetailType_FromHeader == "3") {
        document.getElementById("EditDurationStar_FromHeader").style.display = "none";
    }
}

function Complete_TaskCallDetails_FromHeader() {

    var hdnCommanID_FromHeader = document.getElementById("ctl00_header1_hdnCommanID_FromHeader");
    var hdnSectionName_FromHeader = document.getElementById("ctl00_header1_hdnSectionName_FromHeader");
    if (hdnSectionName_FromHeader.value.toLowerCase() == "task") {
        if (window.confirm('Are you sure you want to complete this task?')) {
            document.getElementById("divallnotesbckfade").style.display = "none";
            document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
            document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
            CallDelete_OpenActivitiesMethod_FromHeader(hdnCommanID_FromHeader.value, CompanyID, ClientID, hdnSectionName_FromHeader.value, '');
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if (window.confirm('Are you sure you want to complete this call?')) {
            document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
            document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "none";
            CallComplete_Method_FromHeader(hdnCommanID_FromHeader.value, CompanyID, ClientID, hdnSectionName_FromHeader.value, '');
            AutoFill.GetAlertNotification(onResponseAlert);
            AutoFill.GetNotificationCount(onResponseCount);
            return true;
        }
        else {
            return false;
        }
    }
}

function CallComplete_Method_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummber) {
    NotespageNummberIndex = 1;

    CRM_Complete_Call_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummberIndex);
}

function CRM_Complete_Call_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientCallCompleted",
        data: GetInput_Complete_Call(id, CompanyId, Clientid, SectionName, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) { },
        error: ServiceFailed
    });
}


function CallDelete_OpenActivitiesMethod_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummber) {
    NotespageNummberIndex = 1;

    CRM_Delete_OpenActivities_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummberIndex);
}

function CRM_Delete_OpenActivities_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientDeleteOpenActivities",
        data: GetInput_task_Delete(id, CompanyId, Clientid, SectionName, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            AutoFill.GetAlertNotification(onResponseAlert);
            AutoFill.GetNotificationCount(onResponseCount);
        },
        error: ServiceFailed
    });
}



//......................................................... Inserting TaskEdit subject FromHeader .............................................//

function ValidateEditAddSubject_FromHeader() {
    var txtEditSubject = document.getElementById("ctl00_header1_txtEditSubject");

    if (txtEditSubject.value == '') {
        document.getElementById("DivEditSubjectAddValidations_FromHeader").style.display = "block";
    }
    if (txtEditSubject.value != '') {
        document.getElementById("DivEditSubjectAddValidations_FromHeader").style.display = "none";
        CallInsert_taskEditSubjectMethod_FromHeader('', CompanyID, ''); return false;
    }
}

function CallInsert_taskEditSubjectMethod_FromHeader(Subject, CompanyID, Language) {

    var txtEditSubject = document.getElementById("ctl00_header1_txtEditSubject");

    CRM_Insert_taskEdit_Subject_FromHeader(SpecialEncode(txtEditSubject.value), CompanyID, Language);
    txtEditSubject.value = "";
}

function CRM_Insert_taskEdit_Subject_FromHeader(Subject, CompanyID, Language) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_subject_Insert",
        data: GetInputEditTaskSubject(Subject, CompanyID, Language),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindEditask_Subject_FromHeader,
        error: ServiceFailed
    });
}

function BindEditask_Subject_FromHeader(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {
        document.getElementById("divallnotesbckfade").style.display = "block";
        document.getElementById("DivtaskPopUpEdit_FromHeader").style.zIndex = "555";
        alert("Subject already exist, choose another subject");
        document.getElementById("DivEditTaskSubject_FromHeader").style.display = "block";
        document.getElementById("ctl00_header1_txtEditSubject").focus();
        return;
    }
    for (var i = 0; i < dataRows.length; i++) {

        if (dataRows[i].sampleSubject != "") {

            document.getElementById("DivEditTaskSubject_FromHeader").style.display = "none";

            var opt = document.createElement("option");
            var ddlEditsubject_FromHeader = document.getElementById("ctl00_header1_ddlEditsubject_FromHeader");

            ddlEditsubject_FromHeader.options.add(opt);
            opt.text = dataRows[i].sampleSubject;
            opt.value = dataRows[i].sampleSubject;
            ddlEditsubject_FromHeader.selectedIndex = ddlEditsubject_FromHeader.length - 1;
            var actualvalue = ddlEditsubject_FromHeader.options[ddlEditsubject_FromHeader.selectedIndex].value;
            document.getElementById("DivtaskPopUpEdit_FromHeader").style.zIndex = "5555";
        }
    }
}

//......................................................... Inserting Notes FromHeader .............................................//

function ValidateNotesFields_FromHeader() {
    var FileName = ''; // NotesFileUpload.value;
    var txtNoteDesc = document.getElementById("ctl00_header1_txtNoteDesc_FromHeader");
    var Notestitle = document.getElementById("ctl00_header1_txtnoteTitle_FromHeader");
    var divnotescontentvalidate = document.getElementById("divnotescontentvalidate_FromHeader");
    divnotescontentvalidate.style.display = 'none';
    var SectionName_FromHeader = "Client";
    var SectionID_FromHeader = document.getElementById("ctl00_header1_hdnSectionID_FromHeader").value;
    var ddl_Notes_Customer = document.getElementById("ctl00_header1_txt_NoteCustomers_FromHeader");
    var Notes_Customer = SelectedClientID_FromHeader.value;
    document.getElementById("spn_ddlNotesCustomers").style.display = "none";
    if (Notestitle.value == '') {
        divnotescontentvalidate.style.display = 'block';
    }
    if (ddl_Notes_Customer.value == '') {
        document.getElementById("spn_ddlNotesCustomers").style.display = "block";
    }
    if (Notestitle.value != '' && ddl_Notes_Customer.value != '') {
        //added loading image for ticket 13607
        document.getElementById('ctl00_header1_BtnNotesSave_FromHeader').style.display = 'none';
        document.getElementById('div_loading_BtnNotesSave_FromHeader').style.display = 'block';
        CallInsert_NotesMethod_FromHeader(CompanyID, SectionName_FromHeader, SectionID_FromHeader, FileName, '', UserID, '', '', '', 0, 0);
        return false;
    } else {
        return false;
    }
}

function CallInsert_NotesMethod_FromHeader(CompanyID, SectionName_FromHeader, SectionID_FromHeader, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID, SpecificTo) {

    NotespageNummberIndex = 1;
    var NotesDesc = document.getElementById("ctl00_header1_txtNoteDesc_FromHeader");
    var Notestitle = document.getElementById("ctl00_header1_txtnoteTitle_FromHeader");
    var ddl_Notes_specificTo = document.getElementById("ctl00_header1_ddl_Notes_specificTo");
    var ddl_Notes_Contact = ddl_Notes_specificTo.options[ddl_Notes_specificTo.selectedIndex].value;
    NotesContact_FromHeader = ddl_Notes_Contact;
    var ddl_Notes_Customer = document.getElementById("ctl00_header1_txt_NoteCustomers_FromHeader");
    var Notes_Customer = SelectedClientID_FromHeader.value;

    CRM_Insert_Notes_FromHeader(CompanyID, SectionName_FromHeader, Notes_Customer, FileName, FileSize, CreateUserID, NotesDesc.value, Notestitle.value, NotespageNummberIndex, ContactID, ddl_Notes_Contact);

    NotesDesc.value = "";
    Notestitle.value = "";
    Close_Popup_FromHeader();

}

function CRM_Insert_Notes_FromHeader(CompanyID, SectionName, SectionID_FromHeader, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID, SpecificTo) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientNotesAdd",
        data: GetInput(CompanyID, SectionName, SectionID_FromHeader, FileName, FileSize, CreateUserID, Subject, Title, NotespageNummber, ContactID, SpecificTo),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindNotes_FromHeader1,
        error: ServiceFailed
    });
}
function BindNotes_FromHeader1(data) {
    var notestitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
    var SelectedClietIdfromheader = document.getElementById("ctl00_header1_hdn_SelectedClientID").value;
    var ClientidFromnotes = document.getElementById("ctl00_ContentPlaceHolder1_Client_hid_ClientID").value; //Client Id of defaultdropdown from header notes
    var dataRows = data.d;
    if (dataRows.length == 0) {
        notestitle.innerHTML = "";
        return;
    }
    if (SelectedClietIdfromheader == ClientID) {
        notestitle.innerHTML = "";
    }
    else if (SelectedClietIdfromheader == "0" && ClientidFromnotes == ClientID) {
        notestitle.innerHTML = "";
    }
    notestitle.innerHTML = "";
    var selected = $("#hdnFileselected").val();
    var selected = 'yes';

    var fileInput = $('#ctl00_ContentPlaceHolder1_Client_file_upload');
    //var fileData = fileInput.prop("files")[0];   // Getting the properties of file from file field
    var fileData;
    if (fileInput.prop != null && fileInput.prop != undefined) {
        fileData = fileInput.prop("files")[0];
    }

    if (fileData != null) {
        //        $("#file_upload").fileUploadSettings('script', '../Upload.ashx?fnrename=' + document.getElementById('txtfilename').value + '&Cid="' + CompanyID + '"&Aid= "' + dataRows[0].attachmentID + '"');
        //        $('#file_upload').fileUploadStart();
        var formData = new window.FormData();                  // Creating object of FormData class
        formData.append("file", fileData); // Appending parameter named file with properties of file_field to form_data
        // formData.append("user_email", email);
        $.ajax(
        {
            url: '../Upload.ashx?' + document.getElementById('txtfilename').value + '&Cid="' + CompanyID + '"&Aid= "' + dataRows[0].attachmentID + '"',
            data: formData,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                //var obj = $.parseJSON(data);
                //  alert(data);
                //                if (obj.StatusCode == "OK") {
                //                    alert(obj.Message);

                //                } else if (obj.StatusCode == "ERROR") {
                //                    alert(obj.Message);
                //                } 
            },
            error: function (errorData) {
                // alert('hi');
                //$('.result-message').html("there was a problem uploading the file.").show();
            }
        });


        if (SelectedClietIdfromheader == ClientID) {
            BindAttachments(dataRows);
        }
        else if (SelectedClietIdfromheader == "0" && ClientidFromnotes == ClientID) {
            BindAttachments(dataRows);
        }
        document.getElementById("ShowAttachIcon").style.display = "block";
        //  document.getElementById("DivUserName").style.marginLeft = "1px";
    }
    else {
        // document.getElementById("ShowAttachIcon").style.display = "none";
        if (SelectedClietIdfromheader == ClientID) {
            BindAttachments(dataRows);
        }
        else if (SelectedClietIdfromheader == "0" && ClientidFromnotes == ClientID) {
            BindAttachments(dataRows);
        }
    }


    var AddNewTaskBtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkAddTask");
    var lnkcallbtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkcall");
    var lnkNotebtn = document.getElementById("ctl00_ContentPlaceHolder1_Client_AddMewNote");

    var ddlTaskContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlTaskContacts");
    var ddlCallContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallAssignTo");
    var ddlNoteContacts = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlspecificTo");

    document.getElementById('ctl00_ContentPlaceHolder1_Client_file_upload').value = "";
}

function BindNotes_FromHeader(data) {
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var selected_FromHeader = $("#hdnFileselected").val();
    var selected_FromHeader = 'yes';

    var fileInput_FromHeader = $('#ctl00_header1_file_upload_FromHeader');
    var fileData_FromHeader;
    if (fileInput_FromHeader.prop != null && fileInput_FromHeader.prop != undefined) {
        fileData_FromHeader = fileInput_FromHeader.prop("files")[0];
    }

    if (fileData_FromHeader != null) {
        var formData_FromHeader = new window.FormData();                  // Creating object of FormData class
        formData_FromHeader.append("file", fileData_FromHeader); // Appending parameter named file with properties of file_field to form_data
        // formData.append("user_email", email);
        $.ajax(
        {
            url: '../Upload.ashx?' + document.getElementById('txtfilename_FromHeader').value + '&Cid="' + CompanyID + '"&Aid= "' + dataRows[0].attachmentID + '"',
            data: formData_FromHeader,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
            },
            error: function (errorData) {
            }
        });
    }
    document.getElementById('ctl00_header1_file_upload_FromHeader').value = "";
}

//----------------------------------------------------------- Open ADD Call Popup Fromheader -------------------------------------------------//

function Open_AddCallPopup_FromHeader(btnid) {

    //added loading image for ticket 13607
    document.getElementById('ctl00_header1_btnSaveCall_fromheader').style.display = 'block';
    document.getElementById('div_loading_btnSaveCall_fromheader').style.display = 'none';

    document.getElementById("ctl00_header1_hdn_Type").value = "call";
    document.getElementById("ctl00_header1_Label118").innerHTML = "Add Call";
    document.getElementById("ctl00_header1_ddlCallDetailsType").selectedIndex = 1;
    $find("ctl00_header1_RadTimePicker4_FromHeader").get_dateInput().set_value("10:00 AM");
    document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
    document.getElementById("DivEditTaskSubject_FromHeader").style.display = "none";
    document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivEventsSubject_FromHeader").style.display = "none";
    document.getElementById("DivEventPopUpEdit_FromHeader").style.display = "none";
    document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
    document.getElementById("DivNotesPopup_FromHeader").style.display = "none";
    document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
    document.getElementById("DivCallPopup_FromHeader").style.display = "block";
    document.getElementById("MainDivCallTimer_FromHeader").style.display = "block";
    document.getElementById("MainDivCallTimerSecond_FromHeader").style.display = "none";
    document.getElementById("spn_ddlCallsubject").style.display = "none";
    document.getElementById("spn_ddlCallCustomers").style.display = "none";
    document.getElementById("Span_MinuteSecond_FromHeader").style.display = "none";
    document.getElementById("DurationStar_FromHeader").style.display = "none";
    document.getElementById("ctl00_header1_ddlCallSubject_FromHeader").focus();
    ddlCallType = document.getElementById("ctl00_header1_ddlCallType").selectedIndex = 1;
    RdoCurrentCall = document.getElementById("ctl00_header1_RdoCurrentCall").checked = true;
    RdoCompletedCall = document.getElementById("ctl00_header1_RdoCompletedCall").checked = false;
    RdoScheduledCall = document.getElementById("ctl00_header1_RdoScheduledCall").checked = false;
    var txtcallstartdate_FromHeader = document.getElementById("ctl00_header1_txtcallstartdate_FromHeader");

    document.getElementById("ctl00_header1_txt_Call_ContactPhone").value = '';
    document.getElementById("ctl00_header1_txt_Call_ContactMobile").value = '';
    document.getElementById("ctl00_header1_txt_Call_DeptPhone").value = '';
    document.getElementById("ctl00_header1_txt_Call_ContactPhone").disabled = false;
    document.getElementById("ctl00_header1_txt_Call_ContactMobile").disabled = false;
    document.getElementById("ctl00_header1_txt_Call_DeptPhone").disabled = false;

    txtcallstartdate_FromHeader.value = TodDate;

    document.getElementById("ctl00_header1_ddlcallHours").selectedIndex = 10;
    document.getElementById("ctl00_header1_ddlcallMinute").selectedIndex = 0;

    txtcallMinute = document.getElementById("ctl00_header1_txtcallMinute").value = '';
    txtcallSecond = document.getElementById("ctl00_header1_txtcallSecond").value = '';
    txtcallresult = document.getElementById("ctl00_header1_txtcallresult").value = '';
    txtCallDesc = document.getElementById("ctl00_header1_txtCallDesc").value = '';
    ChkBillable = document.getElementById("ctl00_header1_ChkBillable").checked = false;
    document.getElementById("DivCallTimer_FromHeader").style.display = "none";
    document.getElementById("DivCallStartTime_FromHeader").style.display = "block";
    document.getElementById("DivCallStartTime1_FromHeader").style.display = "block";
    document.getElementById("DivCallDuration_FromHeader").style.display = "block";
    document.getElementById("DivCallDuration1_FromHeader").style.display = "block";
    document.getElementById("divallnotesbckfade").style.display = "block";
    document.getElementById("divalertcontant").style.zIndex = "555";
    document.getElementById("ctl00_header1_txt_CallCustomers_FromHeader").value = '';

    BindCallSbject(CompanyID);
    BindAssigento(CompanyID, UserID, document.getElementById("ctl00_header1_hdnClientID_FromHeader").value);

    while (document.getElementById("ctl00_header1_ddlCallContacts").options.length > 0) {
        document.getElementById("ctl00_header1_ddlCallContacts").options.remove(0);
    }
    var option = document.createElement("option");
    option.text = "--Select--";
    option.value = 0;
    document.getElementById("ctl00_header1_ddlCallContacts").options.add(option);
    document.getElementById("ctl00_header1_ddlCallContacts").options.selectedIndex = 0;

    if (Browser().toLocaleLowerCase().trim() == "firefox") {
        document.getElementById("ctl00_header1_RadTimePicker4_FromHeader_timeView_tdl").style.marginLeft = "214px";
        document.getElementById("ctl00_header1_RadTimePicker4_FromHeader_timeView_tdl").style.marginTop = "145px";
        document.getElementById("fc").style.marginLeft = "-30px";
        document.getElementById("fc").style.marginTop = "-9px";
    } else if (Browser().toLocaleLowerCase() == "safari") {
        document.getElementById("DivCallPopup_FromHeader").style.top = "25%";
        document.getElementById("DivCallPopup_FromHeader").style.left = "30%";
        document.getElementById("ctl00_header1_RadTimePicker4_FromHeader_timeView_tdl").style.marginLeft = "52px";
        document.getElementById("ctl00_header1_RadTimePicker4_FromHeader_timeView_tdl").style.marginTop = "22px";
        document.getElementById("fc").style.marginLeft = "-51px";
        document.getElementById("fc").style.marginTop = "25px";
    } else {
        document.getElementById("ctl00_header1_RadTimePicker4_FromHeader_timeView_tdl").style.marginLeft = "214px";
        document.getElementById("ctl00_header1_RadTimePicker4_FromHeader_timeView_tdl").style.marginTop = "140px";
        document.getElementById("fc").style.marginLeft = "-30px";
        document.getElementById("fc").style.marginTop = "-2px";
    }

    var ddlCallCustomers = document.getElementById("ctl00_header1_txt_CallCustomers_FromHeader");
    var ddlCallContact = document.getElementById("ctl00_header1_ddlCallContacts");
    if (window.location.href.toLocaleLowerCase().indexOf('estimates/estimate_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('jobs/job_summary_reeng') > -1
        || window.location.href.toLocaleLowerCase().indexOf('invoice/invoice_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('orders/order_summary') > -1
        || window.location.href.toLocaleLowerCase().indexOf('jobs/job_order_summary') > -1 || window.location.href.toLocaleLowerCase().indexOf('invoice/invoice_order_summary') > -1
        || window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
        if (window.location.href.toLocaleLowerCase().indexOf('invoice_summary_reeng') > -1 || window.location.href.toLocaleLowerCase().indexOf('invoice_order_summary') > -1) {
            EstimateID = 0;
        }
        if (ddlCallCustomers != null && ddlCallCustomers != undefined) {
            if (window.location.href.toLocaleLowerCase().indexOf('delivery/delivery_add.aspx?type=edit') > -1) {
                //ddlCallCustomers.value = document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value;
                load_CustomerName_FromHeader(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value);
                if (document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value != null && document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value != undefined && document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value != '') {
                    Load_Summury_Contactlist(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCDeliveryNote_hid_DeliveryToClientID").value);
                }
            } else {
                //ddlCallCustomers.value = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value;
                SelectedClientID_FromHeader.value = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value;
                load_CustomerName_FromHeader(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value);
                if (document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value != null && document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value != undefined && document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value != '') {
                    Load_Summury_Contactlist(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummaryMain_UcCustomerDetail_" + EstimateID + "_hdn_Summurypage_ClientID").value);
                }
            }
        }
    } else if (window.location.href.toLocaleLowerCase().indexOf('client/client_detail') > -1) {
        if (ddlCallCustomers != null && ddlCallCustomers != undefined) {
            if (CompanyType.toLowerCase() != null && CompanyType.toLowerCase() != undefined) {
                SelectedClientID_FromHeader.value = document.getElementById("ctl00_ContentPlaceHolder1_Client_hid_ClientID").value;
                load_CustomerName_FromHeader(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_Client_hid_ClientID").value);

            } else {
                SelectedClientID_FromHeader.value = 0;
            }
            if (ddlCallCustomers.value != null && ddlCallCustomers.value != undefined && SelectedClientID_FromHeader.value != 0) {
                Load_Client_Contactlist(CompanyID, document.getElementById("ctl00_ContentPlaceHolder1_Client_hdn_ContactIDs").value);
            }
        }
    }
    //if (ddlCallCustomers.value == null || ddlCallCustomers.value == undefined || ddlCallCustomers.value == "") {
    //    SelectedClientID_FromHeader.value = 0;
    //}
    
    var ddlAddCallSubject = document.getElementById("ctl00_header1_ddlCallSubject_FromHeader");
    if (document.getElementById("ctl00_header1_hdn_DefaultCallSubjectID_FromHeader").value != 0) {
        if (ddlAddCallSubject != null && ddlAddCallSubject != undefined) {
            ddlAddCallSubject.value = document.getElementById("ctl00_header1_hdn_DefaultCallSubjectID_FromHeader").value;
        }
    } else {
        if (ddlAddCallSubject != null && ddlAddCallSubject != undefined) {
            ddlAddCallSubject.value = 0;
            ddlAddCallSubject.selectedIndex = 0;
        }
    } 
}

function BindCallSbject(CompanyID) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadCallStatusList",
        data: Get_LoadddlCustomers(CompanyID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var ddlEditCallSubject = document.getElementById("ctl00_header1_ddlCallSubjectEdit");
            if (ddlEditCallSubject != null && ddlEditCallSubject != undefined) {
                BindCallSubjectDDL(ddlEditCallSubject, data);
            }
            var ddlAddCallSubject = document.getElementById("ctl00_header1_ddlCallSubject_FromHeader");
            if (ddlAddCallSubject != null && ddlAddCallSubject != undefined) {
                BindCallSubjectDDL(ddlAddCallSubject, data);
            }
        },
        error: function (data) { }
    });
}

function BindCallSubjectDDL(ddl, data) {
    var dataRows = data.d;

    while (ddl.options.length > 0) {
        ddl.options.remove(0);
    }

    var option = document.createElement("option");
    option.text = "--Select--";
    option.value = 0;
    ddl.options.add(option);

    if (dataRows.length == 0) {
        return;
    }

    for (var i = 0; i < dataRows.length; i++) {
        var optionvalues = document.createElement("option");
        optionvalues.text = dataRows[i].StatusTitle;
        optionvalues.value = dataRows[i].StatusID;
        ddl.options.add(optionvalues);

        if (dataRows[i].IsDefault.toLowerCase() == "true") {
            ddl.value = dataRows[i].StatusID;
            document.getElementById("ctl00_header1_hdn_DefaultCallSubjectID_FromHeader").value == dataRows[i].StatusID;
        }
    }
}

function BindAssigento(CompanyID, UserID, ClientID) {
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadAssignedTODDL",
        data: Get_LoadddlAssignedto(CompanyID, UserID, ClientID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (document.getElementById("DivEditCallPopup_FromHeader").style.display == "block") {
                var ddlEditowner = document.getElementById("ctl00_header1_ddlEditowner");
                if (ddlEditowner != null && ddlEditowner != undefined) {
                    BindAssigentoDDL(ddlEditowner, data);
                }
            }
            if (document.getElementById("DivCallPopup_FromHeader").style.display == "block") {
                var ddlowner = document.getElementById("ctl00_header1_ddlowner");
                if (ddlowner != null && ddlowner != undefined) {
                    BindAssigentoDDL(ddlowner, data);
                }
            }
            if (document.getElementById("DivNotesPopup_FromHeader").style.display == "block") {
                var ddlTaskassigneto_FromHeader = document.getElementById("ctl00_header1_ddlTaskassigneto_FromHeader");
                if (ddlTaskassigneto_FromHeader != null && ddlTaskassigneto_FromHeader != undefined) {
                    BindAssigentoDDL(ddlTaskassigneto_FromHeader, data);
                }
            }
            if (document.getElementById("DivtaskPopUpEdit_FromHeader").style.display == "block") {
                var ddlEditassignto_FromHeader = document.getElementById("ctl00_header1_ddlEditassignto_FromHeader");
                if (ddlEditassignto_FromHeader != null && ddlEditassignto_FromHeader != undefined) {
                    BindAssigentoDDL(ddlEditassignto_FromHeader, data);
                }
            }
        },
        error: function (data) { }
    });
}

function Get_LoadddlAssignedto() {
    var FinalString = ' {  "CompanyID" : "' + CompanyID + '","UserID" : "' + UserID + '","ClientID" : "' + document.getElementById("ctl00_header1_hdnClientID_FromHeader").value + '"} ';
    return FinalString;
}

function BindAssigentoDDL(ddl, data) {
    var dataRows = data.d;

    while (ddl.options.length > 0) {
        ddl.options.remove(0);
    }

    if (dataRows.length == 0) {
        return;
    }

    for (var i = 0; i < dataRows.length; i++) {
        var optionvalues = document.createElement("option");
        optionvalues.text = dataRows[i].Name;
        optionvalues.value = dataRows[i].UserID;
        ddl.options.add(optionvalues);

        if (dataRows[i].UserID == UserID) {
            ddl.value = dataRows[i].UserID;
        }
    }
}

//----------------------------------------------------------- Open EditCall Popup Fromheader -------------------------------------------------//

function Call_EditCallMethod_FromHeader(id) {

    CRM_Edit_CallMet_FromHeader(id);
}

function CRM_Edit_CallMet_FromHeader(id) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_Edit_Call",
        data: GetCall_Editdatas(id),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCall_Edit_FromHeader,
        error: ServiceFailed
    });
}

function BindCall_Edit_FromHeader(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        alert('no more data to load');
        return;
    }

    var ddlCallSubjectEdit = document.getElementById("ctl00_header1_ddlCallSubjectEdit");

    var ddlEditCallType = document.getElementById("ctl00_header1_ddlEditCallType");
    var ddleditCallPurpose = document.getElementById("ctl00_header1_ddleditCallPurpose");
    var ddlEditCallContact = document.getElementById("ctl00_header1_ddlEditCallContact");
    var ddlEditCallDetails_FromHeader = document.getElementById("ctl00_header1_ddlEditCallDetails_FromHeader");
    var txtEditCallStartdate_FromHeader = document.getElementById("ctl00_header1_txtEditCallStartdate_FromHeader");
    var txtEditCallMin = document.getElementById("ctl00_header1_txtEditCallMin");
    var txtEditCallSec = document.getElementById("ctl00_header1_txtEditCallSec");
    var txtEditcallressult = document.getElementById("ctl00_header1_txtEditcallressult");
    var ddlEditowner = document.getElementById("ctl00_header1_ddlEditowner");
    var txtEditCallDesc = document.getElementById("ctl00_header1_txtEditCallDesc");
    var ChkEditBillable = document.getElementById("ctl00_header1_ChkEditBillable");

    var txt_EditCall_ConatctPhone = document.getElementById("ctl00_header1_txt_EditCall_ContactPhone");
    var txt_EditCall_ContactMobile = document.getElementById("ctl00_header1_txt_EditCall_ContactMobile");
    var txt_EditCall_DeptPhone = document.getElementById("ctl00_header1_txt_EditCall_DeptPhone");

    for (i = 0; i < ddlCallSubjectEdit.length; i++) {
        if (ddlCallSubjectEdit.options[i].text == dataRows[0].Subject) {
            ddlCallSubjectEdit.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditCallType.length; i++) {
        if (ddlEditCallType.options[i].text == dataRows[0].CallType) {
            ddlEditCallType.selectedIndex = i;
        }
    }

    for (i = 0; i < ddleditCallPurpose.length; i++) {
        if (ddleditCallPurpose.options[i].value == dataRows[0].CallPurpose) {
            ddleditCallPurpose.selectedIndex = i;
        }
    }

    for (i = 0; i < ddlEditCallContact.length; i++) {
        if (ddlEditCallContact.options[i].value == dataRows[0].ContactID) {
            ddlEditCallContact.selectedIndex = i;
        }
    }

    if (dataRows[0].CallDetails == "Completed") {
        ddlEditCallDetails_FromHeader.value = 2;
        document.getElementById("EditDurationStar_FromHeader").style.display = "none";
    }
    if (dataRows[0].CallDetails == "Scheduled") {
        ddlEditCallDetails_FromHeader.value = 3;
        document.getElementById("EditDurationStar_FromHeader").style.display = "none";
    }

    txtEditCallStartdate_FromHeader.value = dataRows[0].CallStartdate;

    var EditCallHoMin = $find("ctl00_header1_RadTimePicker6_FromHeader").get_dateInput();

    EditCallHoMin.set_value(dataRows[0].CallStartTime);

    if (dataRows[0].CallDurationMinutes == 0) {
        txtEditCallMin.value = "";
        txtEditCallSec.value = "";
    }
    else {
        txtEditCallMin.value = dataRows[0].CallDurationMinutes;
        txtEditCallSec.value = dataRows[0].CallDurationSeconds;
    }

    txtEditcallressult.value = dataRows[0].CallResult;

    for (i = 0; i < ddlEditowner.length; i++) {
        if (ddlEditowner.options[i].value == dataRows[0].AssignedTo) {
            ddlEditowner.selectedIndex = i;
        }
    }

    txtEditCallDesc.innerHTML = dataRows[0].Description;
    txtEditCallDesc.value = dataRows[0].Description;

    if (dataRows[0].isBillabel == "True") {
        ChkEditBillable.checked = true;
    }
    else {
        ChkEditBillable.checked = false;
    }
    if (dataRows[0].Contactphone != '') {
        txt_EditCall_ConatctPhone.value = dataRows[0].Contactphone;
        txt_EditCall_ConatctPhone.disabled = true;
    }
    else {
        txt_EditCall_ConatctPhone.value = dataRows[0].Contactphone;
        txt_EditCall_ConatctPhone.disabled = false;
    }

    if (dataRows[0].ContactMobile != '') {
        txt_EditCall_ContactMobile.value = dataRows[0].ContactMobile;
        txt_EditCall_ContactMobile.disabled = true;
    }
    else {
        txt_EditCall_ContactMobile.value = dataRows[0].ContactMobile;
        txt_EditCall_ContactMobile.disabled = false;
    }

    if (dataRows[0].DepartmentPhone != '') {
        txt_EditCall_DeptPhone.value = dataRows[0].DepartmentPhone;
        txt_EditCall_DeptPhone.disabled = true;
    }
    else {
        txt_EditCall_DeptPhone.value = dataRows[0].DepartmentPhone;
        txt_EditCall_DeptPhone.disabled = false;
    }

    //..........................For details........................

    var lbldetStatus_FromHeader = document.getElementById("ctl00_header1_lbldetStatus_FromHeader");
    var lblDetSubject_FromHeader = document.getElementById("ctl00_header1_lblDetSubject_FromHeader");
    var lbldetType_FromHeader = document.getElementById("ctl00_header1_lbldetType_FromHeader");
    var lbldetDueDate_FromHeader = document.getElementById("ctl00_header1_lbldetDueDate_FromHeader");
    var lbldetContactName_FromHeader = document.getElementById("ctl00_header1_lbldetContactName_FromHeader");
    var lbldetContactMobile_FromHeader = document.getElementById("ctl00_header1_lbldetContactMobile_FromHeader");
    var lbldetContactPhone_FromHeader = document.getElementById("ctl00_header1_lbldetContactPhone_FromHeader");
    var lbldetAssignTo_FromHeader = document.getElementById("ctl00_header1_lbldetAssignTo_FromHeader");
    var lbldetDescription_FromHeader = document.getElementById("ctl00_header1_lbldetDescription_FromHeader");
    var lbldeptPhone_FromHeader = document.getElementById("ctl00_header1_lbldeptPhone_FromHeader");
    var lblClientName_FromHeader = document.getElementById("ctl00_header1_lblClientName_FromHeader");

    var lbldetCompanyName = document.getElementById("ctl00_header1_lbldetCompanyName_FromHeader");
  

    lbldetStatus_FromHeader.innerHTML = dataRows[0].CallDetails;
    lblDetSubject_FromHeader.innerHTML = dataRows[0].Subject;
    lbldetType_FromHeader.innerHTML = "Call";
    lbldetDueDate_FromHeader.innerHTML = dataRows[0].CallStartdate + " " + dataRows[0].CallStartTime;
    lbldetContactName_FromHeader.innerHTML = dataRows[0].ContactName;
    lbldetContactMobile_FromHeader.innerHTML = dataRows[0].ContactMobile;
    lbldetContactPhone_FromHeader.innerHTML = dataRows[0].Contactphone;
    lbldetAssignTo_FromHeader.innerHTML = dataRows[0].AssignTo;
    lbldetDescription_FromHeader.innerHTML = dataRows[0].Description;
    lbldetDescription_FromHeader.title = dataRows[0].Description;
    lbldeptPhone_FromHeader.innerHTML = dataRows[0].DepartmentPhone;
    lbldeptPhone_FromHeader.title = dataRows[0].DepartmentPhone;
    lblClientName_FromHeader.innerHTML = dataRows[0].clientName;
    lbldetCompanyName.innerHTML = dataRows[0].clientName;
    lblClientName_FromHeader.setAttribute("href", dataRows[0].areff);
}

function OpenEditCallSubjectDiv_FromHeader(btnid) {
    document.getElementById("DivCallSubjects_FromHeader").style.display = "block";
    document.getElementById("ctl00_header1_txtCallSubjects").value = '';
    document.getElementById("ctl00_header1_txtCallSubjects").focus();
    document.getElementById("DivOpenSubject_FromHeader").style.display = "none";
    document.getElementById("DivEditCallPopup_FromHeader").style.zIndex = "555";
}

function CloseCallPopupAddSubject_FromHeader() {
    document.getElementById("DivCallSubjects_FromHeader").style.display = "none";
    document.getElementById("span_callsubj_FromHeader").style.display = "none";
    document.getElementById("DivEditCallPopup_FromHeader").style.zIndex = "5555";
    document.getElementById("DivCallPopup_FromHeader").style.zIndex = "5555";
}

function ValidateAddCallSubject_FromHeader() {
    var txtCallSubjects = document.getElementById("ctl00_header1_txtCallSubjects");

    if (txtCallSubjects.value == '') {
        document.getElementById("span_callsubj_FromHeader").style.display = "block";
    }
    else {
        document.getElementById("span_callsubj_FromHeader").style.display = "none";
        CallInsert_CallSubjectMethod_FromHeader(CompanyID, '', 'False', UserID);
        return false;
    }
}

function CallInsert_CallSubjectMethod_FromHeader(CompanyID, CallSubject, Default, UserID) {

    var CallSub = document.getElementById("ctl00_header1_txtCallSubjects");
    CRM_Insert_Call_Subject_FromHeader(CompanyID, SpecialEncode(CallSub.value), 'False', UserID);
    CallSub.value = "";
}

function CRM_Insert_Call_Subject_FromHeader(CompanyID, CallSubject, Default, UserID) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/Crm_Callsubjec_Insert",
        data: GetInputCallSubject(CompanyID, CallSubject, Default, UserID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCall_Subject_FromHeader,
        error: ServiceFailed
    });
}

function BindCall_Subject_FromHeader(data) {

    var dataRows = data.d;
    if (dataRows.length == 0) {
        document.getElementById("divallnotesbckfade").style.display = "block";
        document.getElementById("DivEditCallPopup_FromHeader").style.zIndex = "555";
        document.getElementById("DivCallPopup_FromHeader").style.zIndex = "555";
        alert("Subject already exist, choose another subject");
        document.getElementById("DivCallSubjects_FromHeader").style.display = "block";
        document.getElementById("ctl00_header1_txtCallSubjects").focus();
        return;
    }
    for (var i = 0; i < dataRows.length; i++) {

        if (dataRows[i].StatusTitle != "") {

            document.getElementById("DivCallSubjects_FromHeader").style.display = "none";

            var opt = document.createElement("option");
            var ddlCallSubject = document.getElementById("ctl00_header1_ddlCallSubject_FromHeader");
            ddlCallSubject.options.add(opt);

            opt.text = dataRows[i].StatusTitle;
            opt.value = dataRows[i].StatusTitle;
            ddlCallSubject.selectedIndex = ddlCallSubject.length - 1;
            var actualvalue = ddlCallSubject.options[ddlCallSubject.selectedIndex].value;


            var opt = document.createElement("option");
            var ddlCallSubjectEdit = document.getElementById("ctl00_header1_ddlCallSubjectEdit");
            ddlCallSubjectEdit.options.add(opt);

            opt.text = dataRows[i].StatusTitle;
            opt.value = dataRows[i].StatusTitle;
            ddlCallSubjectEdit.selectedIndex = ddlCallSubjectEdit.length - 1;
            var actualvalue = ddlCallSubjectEdit.options[ddlCallSubjectEdit.selectedIndex].value;
            document.getElementById("DivEditCallPopup_FromHeader").style.zIndex = "5555";
            document.getElementById("DivCallPopup_FromHeader").style.zIndex = "5555";
        }
    }
}

function GetScreenCordinatesForEditCallSubject_FromHeader(obj) {
    var p = {};
    p.x = obj.offsetLeft;
    p.y = obj.offsetTop;
    while (obj.offsetParent) {
        p.x = p.x + obj.offsetParent.offsetLeft - 23.8;
        p.y = p.y + obj.offsetParent.offsetTop - 14.5;
        if (obj == document.getElementsByTagName("body")[0]) {
            break;
        }
        else {
            obj = obj.offsetParent;
        }
    }
    return p;
}

//----------------------------------------------------------- Update and Complete Call ----------------------------------------------------//

var EditCallAssignTo_FromHeader;
var EditCallContact_FromHeader;

function UpdateCallValidations_FromHeader() {
    var AttID = document.getElementById("ctl00_header1_AttID");
    var hdnCallID1 = document.getElementById("ctl00_header1_hdnTaskID").value;

    if (hdnCallID1 == "") {
        hdnCallID = AttID.value;
    }
    else {
        var hdnCallID = document.getElementById("ctl00_header1_hdnTaskID").value;
    }
    var ddlCallSubjectEdit = document.getElementById("ctl00_header1_ddlCallSubjectEdit");
    var txtEditCallStartdate_FromHeader = document.getElementById("ctl00_header1_txtEditCallStartdate_FromHeader");
    var txtcallMinute = document.getElementById("ctl00_header1_txtEditCallMin");
    var txtcallSecond = document.getElementById("ctl00_header1_txtEditCallSec");
    var TxtHM = $find("ctl00_header1_RadTimePicker6_FromHeader").get_dateInput();
    var ddlEditCallDetails_FromHeader = document.getElementById("ctl00_header1_ddlEditCallDetails_FromHeader");
    ddlEditCallDetails_FromHeader.options[ddlEditCallDetails_FromHeader.selectedIndex].text;
    var ddlEditCallDetailsNew_FromHeader = ddlEditCallDetails_FromHeader.options[ddlEditCallDetails_FromHeader.selectedIndex].value;
    var ddlEditowners = document.getElementById("ctl00_header1_ddlEditowner");

    var Contact_Phone = document.getElementById("ctl00_header1_txt_EditCall_ContactPhone").value;
    var Contact_Mobile = document.getElementById("ctl00_header1_txt_EditCall_ContactMobile").value;
    var Department_Phone = document.getElementById("ctl00_header1_txt_EditCall_DeptPhone").value;

    if (ddlEditCallDetailsNew_FromHeader == "2") {

    }
    else if (ddlEditCallDetailsNew_FromHeader == "3") {
        if (txtEditCallStartdate_FromHeader.value == '') {
            document.getElementById("span_txtcallstartdate_FromHeader").style.display = "block";
            return true;
        }
    }

    if (ddlCallSubjectEdit.selectedIndex == 0) {
        document.getElementById("span_EditCallSubject").style.display = "block";
        return true;
    }
    if (TxtHM.get_value() == '') {
        document.getElementById("span_EditCallStartdate_FromHeader").style.display = "block";
        return true;
    }
    if (txtEditCallStartdate_FromHeader.value == '') {
        document.getElementById("span_EditCallStartdate_FromHeader").style.display = "block";
        return true;
    }
    else {

        if (ValidateForm(txtEditCallStartdate_FromHeader, 'span_EditCallStartdate1_FromHeader', DateFormatforValidate) == false) {
            return true;
        }
    }
    if (ddlEditowners.options.length == 0) {
        document.getElementById("dicEditAssigntoCall").style.display = "block";
        return true;
    }
    document.getElementById("divallnotesbckfade").style.display = "none";
    document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
    Update_Call_FromHeader(hdnCallID, CompanyID, SectionID, '', '', '', '', '', '', '', '', '', '', '', '', '', UserID, '', '', Contact_Phone, Contact_Mobile, Department_Phone); return false;
}

function Update_Call_FromHeader(CallID, CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes,
    CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, LastUpdatedBy, NotespageNummber, CallEnddate, Contact_Phone, Contact_Mobile, Department_Phone) {
    NotespageNummberIndex = 1;

    var ddlCallSubjectEdit = document.getElementById("ctl00_header1_ddlCallSubjectEdit");

    var ddlEditCallType = document.getElementById("ctl00_header1_ddlEditCallType");
    var ddleditCallPurpose = document.getElementById("ctl00_header1_ddleditCallPurpose");
    var ddlEditCallContact = document.getElementById("ctl00_header1_ddlEditCallContact");
    var ddlEditCallDetails_FromHeader = document.getElementById("ctl00_header1_ddlEditCallDetails_FromHeader");
    var txtEditCallStartdate_FromHeader = document.getElementById("ctl00_header1_txtEditCallStartdate_FromHeader");
    var ddlEditCallTime = document.getElementById("ctl00_header1_ddlEditCallTime");
    var txtEditCallMin = document.getElementById("ctl00_header1_txtEditCallMin");
    var txtEditCallSec = document.getElementById("ctl00_header1_txtEditCallSec");
    var txtEditcallressult = document.getElementById("ctl00_header1_txtEditcallressult");
    var ddlEditowner = document.getElementById("ctl00_header1_ddlEditowner");
    var txtEditCallDesc = document.getElementById("ctl00_header1_txtEditCallDesc");
    var ChkEditBillable = document.getElementById("ctl00_header1_ChkEditBillable");

    ddlCallSubjectEdit.options[ddlCallSubjectEdit.selectedIndex].text;
    var finalddlCallSubjectEdit = ddlCallSubjectEdit.options[ddlCallSubjectEdit.selectedIndex].text;

    ddlEditCallType.options[ddlEditCallType.selectedIndex].text;
    var finalddlEditCallType = ddlEditCallType.options[ddlEditCallType.selectedIndex].text;

    ddleditCallPurpose.options[ddleditCallPurpose.selectedIndex].text;
    var finaleditCallPurpose = ddleditCallPurpose.options[ddleditCallPurpose.selectedIndex].value;

    ddlEditCallDetails_FromHeader.options[ddlEditCallDetails_FromHeader.selectedIndex].text;
    var CallEditDetailsType = ddlEditCallDetails_FromHeader.options[ddlEditCallDetails_FromHeader.selectedIndex].value;

    var EditCallDetail = "";

    if (CallEditDetailsType == "2") {
        EditCallDetail = "completed";
    }
    if (CallEditDetailsType == "3") {
        EditCallDetail = "scheduled";
    }

    var finalEditContactID = 0;
    if (ddlEditCallContact.options.length == 0) {
        finalEditContactID = 0;
    }
    else {
        ddlEditCallContact.options[ddlEditCallContact.selectedIndex].text;
        finalEditContactID = ddlEditCallContact.options[ddlEditCallContact.selectedIndex].value;
    }
    EditCallContact_FromHeader = finalEditContactID;

    var ddleditCallHours = document.getElementById("ctl00_header1_ddleditCallHours");
    var ddleditCallSecond = document.getElementById("ctl00_header1_ddleditCallSecond");

    var EditFinalCallMinSec = "";
    var EditCallHoMin = $find("ctl00_header1_RadTimePicker6_FromHeader").get_dateInput();
    EditFinalCallMinSec = EditCallHoMin.get_value();

    ddlEditowner.options[ddlEditowner.selectedIndex].text;
    var finalEditowner = ddlEditowner.options[ddlEditowner.selectedIndex].value;
    EditCallAssignTo_FromHeader = finalEditowner;

    var Editbillable = false;
    if (ChkEditBillable.checked == true) {
        Editbillable = true;
    }
    else {
        Editbillable = false;
    }

    CRM_Update_Call_FromHeader(CallID, CompanyID, ClientID, SpecialEncode(finalddlCallSubjectEdit), finalddlEditCallType, finaleditCallPurpose, EditCallDetail, finalEditContactID,
        txtEditCallStartdate_FromHeader.value, EditFinalCallMinSec, txtEditCallMin.value, txtEditCallSec.value, txtEditcallressult.value, finalEditowner, txtEditCallDesc.value,
        Editbillable, LastUpdatedBy, NotespageNummberIndex, CallEnddate, Contact_Phone, Contact_Mobile, Department_Phone);
}

function CRM_Update_Call_FromHeader(CallID, CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime,
    CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, LastUpdatedBy, NotespageNummber, CallEnddate, Contact_Phone, Contact_Mobile, Department_Phone) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/CrmCallUpdate",
        data: GetCrmCallUpdate(CallID, CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes,
            CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, LastUpdatedBy, NotespageNummber, CallEnddate, Contact_Phone, Contact_Mobile, Department_Phone),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindCallsUpdated_FromHeader,
        error: ServiceFailed
    });
}

function BindCallsUpdated_FromHeader(data) {
    debugger;
    var dataRows = data.d;
    if (dataRows.length == 0) {
        return;
    }
    var lbldetStatus_FromHeader = document.getElementById("ctl00_header1_lbldetStatus_FromHeader");
    var lblDetSubject_FromHeader = document.getElementById("ctl00_header1_lblDetSubject_FromHeader");
    var lbldetType_FromHeader = document.getElementById("ctl00_header1_lbldetType_FromHeader");
    var lbldetDueDate_FromHeader = document.getElementById("ctl00_header1_lbldetDueDate_FromHeader");
    var lbldetContactName_FromHeader = document.getElementById("ctl00_header1_lbldetContactName_FromHeader");
    var lbldetContactMobile_FromHeader = document.getElementById("ctl00_header1_lbldetContactMobile_FromHeader");
    var lbldetContactPhone_FromHeader = document.getElementById("ctl00_header1_lbldetContactPhone_FromHeader");
    var lbldetAssignTo_FromHeader = document.getElementById("ctl00_header1_lbldetAssignTo_FromHeader");
    var lbldetDescription_FromHeader = document.getElementById("ctl00_header1_lbldetDescription_FromHeader");

    var lbldetCompanyName = document.getElementById("ctl00_header1_lbldetCompanyName_FromHeader");
    if (dataRows.length == 0) {
        lbldetStatus_FromHeader.innerHTML = dataRows[0].Status;
        lblDetSubject_FromHeader.innerHTML = dataRows[0].Subject;
        lbldetType_FromHeader.innerHTML = dataRows[0].Type;
        lbldetDueDate_FromHeader.innerHTML = dataRows[0].DueDate + " " + dataRows[0].taskTime;
        lbldetContactName_FromHeader.innerHTML = dataRows[0].ContactName;
        lbldetContactMobile_FromHeader.innerHTML = dataRows[0].ContacMobile;
        lbldetContactPhone_FromHeader.innerHTML = dataRows[0].ContactPhone;
        lbldetAssignTo_FromHeader.innerHTML = dataRows[0].AssignTo;
        lbldetDescription_FromHeader.innerHTML = dataRows[0].Description;
        lbldetDescription_FromHeader.title = dataRows[0].Description;
        lbldetCompanyName.innerHTML = dataRows[0].clientName;
    }
    AutoFill.GetAlertNotification(onResponseAlert);
    AutoFill.GetNotificationCount(onResponseCount);
}

function Displayclearbutton_FromHeader() {

    var deleteimage = document.getElementById("ctl00_header1_Img_ClearSubject_FromHeader");
    var ddlAddTasksubject_FromHeader = document.getElementById("ctl00_header1_ddlAddTasksubject_FromHeader");

    if (ddlAddTasksubject_FromHeader.selectedIndex != 0) {
        deleteimage.style.display = "none";
    }
    else {
        deleteimage.style.display = "none";
    }
}


function Browser() {
    var nVer = navigator.appVersion;
    var nAgt = navigator.userAgent;
    var browserName = navigator.appName;
    var fullVersion = '' + parseFloat(navigator.appVersion);
    var majorVersion = parseInt(navigator.appVersion, 10);
    var nameOffset, verOffset, ix;

    // In Opera 15+, the true version is after "OPR/" 
    if ((verOffset = nAgt.indexOf("OPR/")) != -1) {
        browserName = "Opera";
        fullVersion = nAgt.substring(verOffset + 4);
    }
        // In older Opera, the true version is after "Opera" or after "Version"
    else if ((verOffset = nAgt.indexOf("Opera")) != -1) {
        browserName = "Opera";
        fullVersion = nAgt.substring(verOffset + 6);
        if ((verOffset = nAgt.indexOf("Version")) != -1)
            fullVersion = nAgt.substring(verOffset + 8);
    }
        // In MSIE, the true version is after "MSIE" in userAgent
    else if ((verOffset = nAgt.indexOf("MSIE")) != -1) {
        browserName = "Microsoft Internet Explorer";
        fullVersion = nAgt.substring(verOffset + 5);
    }
        // In Chrome, the true version is after "Chrome" 
    else if ((verOffset = nAgt.indexOf("Chrome")) != -1) {
        browserName = "Chrome";
        fullVersion = nAgt.substring(verOffset + 7);
    }
        // In Safari, the true version is after "Safari" or after "Version" 
    else if ((verOffset = nAgt.indexOf("Safari")) != -1) {
        browserName = "Safari";
        fullVersion = nAgt.substring(verOffset + 7);
        if ((verOffset = nAgt.indexOf("Version")) != -1)
            fullVersion = nAgt.substring(verOffset + 8);
    }
        // In Firefox, the true version is after "Firefox" 
    else if ((verOffset = nAgt.indexOf("Firefox")) != -1) {
        browserName = "Firefox";
        fullVersion = nAgt.substring(verOffset + 8);
    }
        // In most other browsers, "name/version" is at the end of userAgent 
    else if ((nameOffset = nAgt.lastIndexOf(' ') + 1) <
              (verOffset = nAgt.lastIndexOf('/'))) {
        browserName = nAgt.substring(nameOffset, verOffset);
        fullVersion = nAgt.substring(verOffset + 1);
        if (browserName.toLowerCase() == browserName.toUpperCase()) {
            browserName = navigator.appName;
        }
    }
    // trim the fullVersion string at semicolon/space if present
    if ((ix = fullVersion.indexOf(";")) != -1)
        fullVersion = fullVersion.substring(0, ix);
    if ((ix = fullVersion.indexOf(" ")) != -1)
        fullVersion = fullVersion.substring(0, ix);

    majorVersion = parseInt('' + fullVersion, 10);
    if (isNaN(majorVersion)) {
        fullVersion = '' + parseFloat(navigator.appVersion);
        majorVersion = parseInt(navigator.appVersion, 10);
    }
    return browserName;
}

function ValidateDateTime(Date, Time) { //here date may be Call start date or Due date
    var TodayDate = document.getElementById("ctl00_header1_hdn_SystemDateTime").value;
    var Tdate = new Array();
    Tdate = TodayDate.split(' ');
    var TdateDMY = Tdate[0].split('/');
    var TdateD = parseInt(TdateDMY[0]);
    var TdateM = parseInt(TdateDMY[1]);
    var TdateY = parseInt(TdateDMY[2]);
    var TdateHMS = Tdate[1].split(':');
    var TdateH = parseInt(TdateHMS[0]);
    var TdateMin = parseInt(TdateHMS[1]);
    var TdateS = parseInt(TdateHMS[2]);
    var DateDMY = Date;
    var DateDMYSeperate = new Array();
    var DateDMYSeperate = Date.split('/');
    var DateD = parseInt(DateDMYSeperate[0]);
    var DateM = parseInt(DateDMYSeperate[1]);
    var DateY = parseInt(DateDMYSeperate[2]);

    var TimeHMS = Time;
    if (TimeHMS != '') {
        var TimeHMSdivide = new Array();
        TimeHMSdivide = Time.split(' ');
        var TimeHM = TimeHMSdivide[0].split(':');
        var TimeH = parseInt(TimeHM[0]);
        var TimeM = parseInt(TimeHM[1]);

        if (TimeHMSdivide[1] == "PM" && (TimeH != 12)) {
            TimeH = parseInt(TimeH) + 12;
        }
        else if (TimeHMSdivide[1] == "AM" && (TimeH == 12)) {
            TimeH = 00;
        }
    }
    else {
        TimeH = 00;
        TimeM = 00;
    }

    if (DateY < TdateY) {
        alert("Please select a date and time in the future.");
        return false;
    }
    else if (DateY > TdateY) {
        return true;
    }
    else if (DateY == TdateY && DateFormatforValidate == "dd/mm/yyyy") {
        if (DateM > TdateM) {
            return true;
        }
        else if (TdateM > DateM) {
            alert("Please select a date and time in the future.");
            return false;
        }
        else if (TdateD > DateD && TdateM == DateM) {
            alert("Please select a date and time in the future.");
            return false;
        }
        else if (TdateD < DateD && TdateM == DateM) {
            return true;
        }

        else if (TdateH > TimeH && TdateD == DateD) {
            alert("Please select a date and time in the future.");
            return false;
        }
        else if (TdateH < TimeH && TdateD == DateD) {
            return true;
        }
        else if (TdateMin > TimeM && TdateH == TimeH) {
            alert("Please select a date and time in the future.");
            return false;
        }
        return true;
    }
    else if (DateY == TdateY && DateFormatforValidate == "mm/dd/yyyy") {   //here date format is mm/dd/yyyy
        if (DateD > TdateD) {
            return true;
        }
        else if (TdateD > DateD) {
            alert("Please select a date and time in the future.");
            return false;
        }
            //here date will be month and month will be date
        else if (TdateD == DateD && TdateM > DateM) {
            alert("Please select a date and time in the future.");
            return false;
        }
        else if (TdateD == DateD && TdateM < DateM) {
            return true;
        }
            //here date will be month and month will be date
        else if (TdateH > TimeH && TdateM == DateM) {
            alert("Please select a date and time in the future.");
            return false;
        }
        else if (TdateH < TimeH && TdateM == DateM) {
            return true;
        }
        else if (TdateMin > TimeM && TdateH == TimeH) {
            alert("Please select a date and time in the future.");
            return false;
        }
        return true;
    }
}


//------------------------------------------------------- Deleting task and Call ----------------------------------------------------------//

function delete_TaskCallDetails_FromHeader() {
    var hdnCommanID_FromHeader = document.getElementById("ctl00_header1_hdnCommanID_FromHeader");
    var hdnSectionName_FromHeader = document.getElementById("ctl00_header1_hdnSectionName_FromHeader");
    if (hdnSectionName_FromHeader.value.toLowerCase() == "task") {
        if (window.confirm('Are you sure you want to delete?')) {
            document.getElementById("divallnotesbckfade").style.display = "none";
            document.getElementById("DivtaskPopUpEdit_FromHeader").style.display = "none";
            document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
            delete_CallandTask_FromHeader(hdnCommanID_FromHeader.value, CompanyID, ClientID, hdnSectionName_FromHeader.value, '');
            AutoFill.GetAlertNotification(onResponseAlert);
            AutoFill.GetNotificationCount(onResponseCount);
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if (window.confirm('Are you sure you want to delete?')) {
            document.getElementById("divallnotesbckfade").style.display = "none";
            document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
            document.getElementById("DivOpenActiDetails_FromHeader").style.display = "none";
            delete_CallandTask_FromHeader(hdnCommanID_FromHeader.value, CompanyID, ClientID, hdnSectionName_FromHeader.value, '');
            AutoFill.GetAlertNotification(onResponseAlert);
            AutoFill.GetNotificationCount(onResponseCount);
            return true;
        }
        else {
            return false;
        }
    }
}

function delete_CallandTask_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummber) {


    NotespageNummberIndex = 1;
    CRM_Delete_Call_Task_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummberIndex);
}

function CRM_Delete_Call_Task_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummber) {

    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/ClientDeleteTask",
        data: GetInput_fro_delete_Call_Task_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummber),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: BindTaskActivity_FromHeader,
        error: ServiceFailed
    });
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function GetInput_fro_delete_Call_Task_FromHeader(id, CompanyId, Clientid, SectionName, NotespageNummber) {
    var FinalString = ' { "id" : "' + id + '" , "CompanyId" : "' + CompanyId + '" , "Clientid" : "' + Clientid + '" , "SectionName" : "' + SectionName + '" , "NotespageNummber" : "' + NotespageNummber + '" } '
    return FinalString;
}

function BindTaskActivity_FromHeader(data) {

}

//--------------------------------------------------------- Notes Add -------------------------------------------------------------------//

function opennotesdiv() {
    Close_CallPopup_FromHeader();

    Close_TaskPopup_FromHeader();

    document.getElementById("taskborderright").style.color = "#000000";
    document.getElementById("Callborderright").style.color = "#000000";
}


//------------------------------------------------------Auto fill Customer ---------------------------------------------------------------
var Customer_offsetTop_FromHeader = 0; 	// Offset - Customer placement - You probably have to modify this value if you're not using a strict doctype
var Customer_offsetLeft_FromHeader = 0; // Offset - Customer placement - You probably have to modify this value if you're not using a strict doctype
var ClickEvent_FromHeader = false;
var txt_Customers_FromHeader = '';
var Div_ID = '';
var DDLContact = '';
function BindCustomers_FromHeader(txt_FromHeader, companytype, CompanyID, Width, e, isDisplaySupplier, type) {
    var txt_TaskCustomers_FromHeader = document.getElementById("ctl00_header1_txt_TaskCustomers_FromHeader");
    var txt_CallCustomers_FromHeader = document.getElementById("ctl00_header1_txt_CallCustomers_FromHeader");
    var txt_NoteCustomers_FromHeader = document.getElementById("ctl00_header1_txt_NoteCustomers_FromHeader");

    var TaskContactPhone = document.getElementById("ctl00_header1_txt_Task_ContactPhone");
    var TaskContactMobile = document.getElementById("ctl00_header1_txt_Task_ContactMobile");
    var TaskDepartmentPhone = document.getElementById("ctl00_header1_txt_Task_DeptPhone");

    var CallContactPhone = document.getElementById("ctl00_header1_txt_Call_ContactPhone");
    var CallContactMobile = document.getElementById("ctl00_header1_txt_Call_ContactMobile");
    var CallDepartmentPhone = document.getElementById("ctl00_header1_txt_Call_DeptPhone");

    var ddlTaskContacts_FromHeader = document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader");
    var ddlCallContacts = document.getElementById("ctl00_header1_ddlCallContacts");
    var ddl_Notes_specificTo = document.getElementById("ctl00_header1_ddl_Notes_specificTo");

    var Task_CustomerDiv_FromHeader = document.getElementById("Div_BindTaskCustomers_FromHeader");
    var Call_CustomerDiv_FromHeader = document.getElementById("Div_BindCallCustomers_FromHeader");
    var Note_CustomerDiv_FromHeader = document.getElementById("Div_BindNoteCustomers_FromHeader");

    if (type == 'task') {
        Div_ID = Task_CustomerDiv_FromHeader;
        txt_Customers_FromHeader = txt_TaskCustomers_FromHeader
        DDLContact = ddlTaskContacts_FromHeader
        ContactPhone = TaskContactPhone;
        ContactMobile = TaskContactMobile;
        DepartmentPhone = TaskDepartmentPhone;
    } else if (type == 'call') {
        Div_ID = Call_CustomerDiv_FromHeader;
        txt_Customers_FromHeader = txt_CallCustomers_FromHeader
        DDLContact = ddlCallContacts
        ContactPhone = CallContactPhone;
        ContactMobile = CallContactMobile;
        DepartmentPhone = CallDepartmentPhone;
    } else if (type == 'note') {
        Div_ID = Note_CustomerDiv_FromHeader;
        txt_Customers_FromHeader = txt_NoteCustomers_FromHeader
        DDLContact = ddl_Notes_specificTo
    }

    Customer_offsetLeft = 1;
    Customer_offsetTop_FromHeader = 1;
    Customer_offsetLeft_FromHeader = 1;
    var ac = this;
    this.textbox = document.getElementById(txt_FromHeader.id);
    var innertextbox_FromHeader = document.getElementById(txt_FromHeader.id);
    if (Div_ID != false && Div_ID != undefined) {
        this.div = document.getElementById(Div_ID.id);
        this.list = this.div.getElementsByTagName('li');
    }
    if (e != undefined) {

        e = e || window.event;
        switch (e.keyCode) {
            case 38: //up 
                {
                    ac.selectDiv(-1);
                    break;
                }
            case 40: //down
                {
                    ac.selectDiv(1);
                    break;
                }
            case 13: //enter
                {

                    Div_ID.style.visibility = 'hidden';
                    this.pointer = 0;
                    break;
                }
            default:
                {
                    this.pointer = 0;

                    //if (buttonObj.value.length > 2) {

                    ClickEvent = txt_FromHeader.id;
                    initCustomer_FromHeader(Div_ID, txt_FromHeader, type);
                    Div_ID.innerHTML = '';
                    setTimeout(function () {
                        AutoFill.BindCustomers_ForHeader(CompanyID, txt_FromHeader.value, isDisplaySupplier, onResponse_BindCustomer_FromHeader, onTimeout, onError);
                    }, 1500);
                    Div_ID.style.visibility = 'visible';
                }
        }
    }
    else {
        this.pointer = 0;

        //if (buttonObj.value.length > 2) {

        ClickEvent = txt_FromHeader.id;
        initCustomer_FromHeader(Div_ID, txt_FromHeader, type);
        Div_ID.innerHTML = '';
        setTimeout(function () { AutoFill.BindCustomers_ForHeader(CompanyID, SearchParameter, isDisplaySupplier, onResponse_BindCustomer_FromHeader, onTimeout, onError); }, 10000);
        Div_ID.style.visibility = 'visible';
    }
}

function initCustomer_FromHeader(Div_ID, ID, type) {
    Div_ID.style.position = 'fixed';
    Div_ID.style.zIndex = 100000000;
    Div_ID.style.backgroundcolor = 'Gray';
    Div_ID.style.width = ID.style.width;
    Div_ID.style.display = "inline";
    Div_ID.style.display = "inline";
    Div_ID.styletransform = " translate(-50%, -50%)";
    if (type == 'task') {
        Div_ID.style.left = '4%';
        Div_ID.style.top = '46%';
        Div_ID.style.marginLeft = '-3px';
    } else if (type == 'call') {
        Div_ID.style.left = '4.6%';
        //Div_ID.style.top = '54.5%';
        Div_ID.style.marginLeft = '-3px';
    } else if (type == 'note') {
        Div_ID.style.left = '5%';
        Div_ID.style.top = '75%';
        Div_ID.style.marginLeft = '-3px';
    }
}

function onResponse_BindCustomer_FromHeader(ListofCustomer) {
    Div_ID.innerHTML = '';
    Div_ID.innerHTML = ListofCustomer;
    Div_ID.style.display = 'block';
}

var str_con1 = '';
function BindResultCustomer_FromHeader(ClientID, ClientName, Contacts) {

    txt_Customers_FromHeader.value = decodeURI(ClientName);
    hdn_SelectedClientID_FromHeader = ClientID;
    SelectedClientID_FromHeader.value = ClientID;
    while (DDLContact.options.length > 0) {
        DDLContact.options.remove(0);
    }
    var option = document.createElement("option");
    option.text = "--Select--";
    option.value = 0;
    DDLContact.options.add(option);

    str_con1 = decodeURI(Contacts).split('^');
    for (var k = 0; k < str_con1.length; k++) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            ContactName = trim12(ContactIDName[1]);
            DDLContact.options.add(new Option(ContactName, ContactID, k));

            if (ContactIDName[2] == 1) {
                document.getElementById(ContactPhone.id).value = ContactIDName[3];
                document.getElementById(ContactMobile.id).value = ContactIDName[4];
                document.getElementById(DepartmentPhone.id).value = ContactIDName[5];
                if (ContactIDName[3] != '') {
                    document.getElementById(ContactPhone.id).disabled = true;
                }
                if (ContactIDName[4] != '') {
                    document.getElementById(ContactMobile.id).disabled = true;
                }
                if (ContactIDName[5] != '') {
                    document.getElementById(DepartmentPhone.id).disabled = true;
                }
                DDLContact.selectedIndex = k + 1;
            }
        }
    }
    DDLContact.onchange = ContactsChange;

    document.onclick = function (e) {
        var evt = (e) ? e : event;

        var theElem = (evt.srcElement) ? evt.srcElement : evt.target;
        while (theElem != null) {
            try {

                if ((theElem.id == Div_ID.id || theElem.id == ClickEvent) && document.getElementById(Div_ID.id).style.display == 'none') {
                    document.getElementById(Div_ID.id).style.display = 'block';
                    return true;
                }
            }
            catch (err) {
            }
            theElem = theElem.offsetParent;
        }

        try {
            document.getElementById(Div_ID.id).style.display = 'none';
        }
        catch (err) {
        }

    }
}
var FinalClientID = ''
function load_CustomerName_FromHeader(CompanyID, ClientID) {
    FinalClientID = ClientID;
    $.ajax({
        type: "POST",
        url: sitePath + "client/client_detail.aspx/LoadCustomerNameOnSummary",
        data: Get_LoadddlCustomers_FromHeader(CompanyID, ClientID),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var dataRows = data.d;
            document.getElementById("ctl00_header1_txt_TaskCustomers_FromHeader").value = SpecialDecode(dataRows[0].ClientName);
            document.getElementById("ctl00_header1_txt_CallCustomers_FromHeader").value = SpecialDecode(dataRows[0].ClientName);
            document.getElementById("ctl00_header1_txt_NoteCustomers_FromHeader").value = SpecialDecode(dataRows[0].ClientName);

        },
        error: function (data) {
        }
    });
}
function Get_LoadddlCustomers_FromHeader() {
    var FinalString = ' {  "CompanyID" : "' + CompanyID + '", "ClientID" : "' + FinalClientID + '"} '
    return FinalString;
}

function ContactsChange() {
    var Contacts = document.getElementById(DDLContact.id);
    //var ClientID = hdn_SelectedClientID_FromHeader;

    var SelectedCntId = Contacts.options[Contacts.selectedIndex].value;
    for (var i = 0; i < str_con1.length; i++) {
        var ContactsData = str_con1[i].split('±');
        if (parseInt(SelectedCntId) == parseInt(ContactsData[0])) {
            document.getElementById(ContactPhone.id).value = ContactsData[3];
            document.getElementById(ContactMobile.id).value = ContactsData[4];
            document.getElementById(DepartmentPhone.id).value = ContactsData[5];
            if (ContactsData[3] != '') {
                document.getElementById(ContactPhone.id).disabled = true;
            }
            else {
                document.getElementById(ContactPhone.id).disabled = false;
            }
            if (ContactsData[4] != '') {
                document.getElementById(ContactMobile.id).disabled = true;
            }
            else {
                document.getElementById(ContactMobile.id).disabled = false;
            }
            if (ContactsData[5] != '') {
                document.getElementById(DepartmentPhone.id).disabled = true;
            }
            else {
                document.getElementById(DepartmentPhone.id).disabled = false;
            }
        }
    }
}
function SelectedContact() {
    var dataRows = ContactData;
    if (document.getElementById("ctl00_header1_hdn_Type").value == "task") {
        var TaskSelectedContact = document.getElementById("ctl00_header1_ddlTaskContacts_FromHeader");
        var SelectedCntId = TaskSelectedContact.options[TaskSelectedContact.selectedIndex].value;
    }
    if (document.getElementById("ctl00_header1_hdn_Type").value == "call") {
        var TaskSelectedContact = document.getElementById("ctl00_header1_ddlCallContacts");
        var SelectedCntId = TaskSelectedContact.options[TaskSelectedContact.selectedIndex].value;
    }
    if (SelectedCntId != "0") {
        for (var i = 0; i < dataRows.length; i++) {
            if (document.getElementById("ctl00_header1_hdn_Type").value == "task") {
                if (parseInt(dataRows[i].ContactID) == parseInt(SelectedCntId)) {
                    if (dataRows[i].ContactPhone != '') {
                        document.getElementById("ctl00_header1_txt_Task_ContactPhone").value = dataRows[i].ContactPhone;
                        document.getElementById("ctl00_header1_txt_Task_ContactPhone").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_header1_txt_Task_ContactPhone").disabled = false;
                        document.getElementById("ctl00_header1_txt_Task_ContactPhone").value = dataRows[i].ContactPhone;
                    }
                    if (dataRows[i].ContactMobile != '') {
                        document.getElementById("ctl00_header1_txt_Task_ContactMobile").value = dataRows[i].ContactMobile;
                        document.getElementById("ctl00_header1_txt_Task_ContactMobile").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_header1_txt_Task_ContactMobile").disabled = false;
                        document.getElementById("ctl00_header1_txt_Task_ContactMobile").value = dataRows[i].ContactMobile;
                    }
                    if (dataRows[i].DepartmentPhone != '') {
                        document.getElementById("ctl00_header1_txt_Task_DeptPhone").value = dataRows[i].DepartmentPhone;
                        document.getElementById("ctl00_header1_txt_Task_DeptPhone").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_header1_txt_Task_DeptPhone").disabled = false;
                        document.getElementById("ctl00_header1_txt_Task_DeptPhone").value = dataRows[i].DepartmentPhone;
                    }
                    break;
                }
            }
            else if (document.getElementById("ctl00_header1_hdn_Type").value == "call") {
                if (parseInt(dataRows[i].ContactID) == parseInt(SelectedCntId)) {
                    if (dataRows[i].ContactPhone != '') {
                        document.getElementById("ctl00_header1_txt_Call_ContactPhone").value = dataRows[i].ContactPhone;
                        document.getElementById("ctl00_header1_txt_Call_ContactPhone").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_header1_txt_Call_ContactPhone").disabled = false;
                        document.getElementById("ctl00_header1_txt_Call_ContactPhone").value = dataRows[i].ContactPhone;
                    }
                    if (dataRows[i].ContactMobile != '') {
                        document.getElementById("ctl00_header1_txt_Call_ContactMobile").value = dataRows[i].ContactMobile;
                        document.getElementById("ctl00_header1_txt_Call_ContactMobile").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_header1_txt_Call_ContactMobile").disabled = false;
                        document.getElementById("ctl00_header1_txt_Call_ContactMobile").value = dataRows[i].ContactMobile;
                    }
                    if (dataRows[i].DepartmentPhone != '') {
                        document.getElementById("ctl00_header1_txt_Call_DeptPhone").value = dataRows[i].DepartmentPhone;
                        document.getElementById("ctl00_header1_txt_Call_DeptPhone").disabled = true;
                    }
                    else {
                        document.getElementById("ctl00_header1_txt_Call_DeptPhone").disabled = false;
                        document.getElementById("ctl00_header1_txt_Call_DeptPhone").value = dataRows[i].DepartmentPhone;
                    }
                    break;
                }
            }
        }
    }
    else {
        if (document.getElementById("ctl00_header1_hdn_Type").value == "call") {
            document.getElementById("ctl00_header1_txt_Call_ContactPhone").value = '';
            document.getElementById("ctl00_header1_txt_Call_ContactMobile").value = '';
            document.getElementById("ctl00_header1_txt_Call_DeptPhone").value = '';

            document.getElementById("ctl00_header1_txt_Call_ContactPhone").disabled = false;
            document.getElementById("ctl00_header1_txt_Call_ContactMobile").disabled = false;
            document.getElementById("ctl00_header1_txt_Call_DeptPhone").disabled = false;
        }
        if (document.getElementById("ctl00_header1_hdn_Type").value == "task") {
            document.getElementById("ctl00_header1_txt_Task_ContactPhone").value = '';
            document.getElementById("ctl00_header1_txt_Task_ContactMobile").value = '';
            document.getElementById("ctl00_header1_txt_Task_DeptPhone").value = '';

            document.getElementById("ctl00_header1_txt_Task_ContactPhone").disabled = false;
            document.getElementById("ctl00_header1_txt_Task_ContactMobile").disabled = false;
            document.getElementById("ctl00_header1_txt_Task_DeptPhone").disabled = false;
        }
    }
}


function EditSelectContact() {

    var SelectedContact = document.getElementById(ContactId.id);
    var SelectedCntId = SelectedContact.options[SelectedContact.selectedIndex].value;

    var dataRows = EditContactData;
    if (SelectedCntId != "0") {
        for (var i = 0; i < dataRows.length; i++) {
            if (parseInt(dataRows[i].ContactID) == parseInt(SelectedCntId)) {
                if (dataRows[i].ContactPhone != '') {
                    document.getElementById(EditConatctPhone.id).value = dataRows[i].ContactPhone;
                    document.getElementById(EditConatctPhone.id).disabled = true;
                }
                else {
                    document.getElementById(EditConatctPhone.id).disabled = false;
                    document.getElementById(EditConatctPhone.id).value = dataRows[i].ContactPhone;
                }
                if (dataRows[i].ContactMobile != '') {
                    document.getElementById(EditContactMobile.id).value = dataRows[i].ContactMobile;
                    document.getElementById(EditContactMobile.id).disabled = true;
                }
                else {
                    document.getElementById(EditContactMobile.id).disabled = false;
                    document.getElementById(EditContactMobile.id).value = dataRows[i].ContactMobile;
                }
                if (dataRows[i].DepartmentPhone != '') {
                    document.getElementById(EditDeptPhone.id).value = dataRows[i].DepartmentPhone;
                    document.getElementById(EditDeptPhone.id).disabled = true;
                }
                else {
                    document.getElementById(EditDeptPhone.id).disabled = false;
                    document.getElementById(EditDeptPhone.id).value = dataRows[i].DepartmentPhone;
                }
                break;
            }
        }
    }
    else {
        document.getElementById(EditConatctPhone.id).value = '';
        document.getElementById(EditContactMobile.id).value = '';
        document.getElementById(EditDeptPhone.id).value = '';

        document.getElementById(EditConatctPhone.id).disabled = false;
        document.getElementById(EditContactMobile.id).disabled = false;
        document.getElementById(EditDeptPhone.id).disabled = false;
    }
}

