// if check box CHANGE PASSWORD
function changepassword() {
    if (chk_changePwd.checked) {
        chk_changePwd.checked = true;
        changePassword_header.style.display = "block";
        changePassword_currentPwd.style.display = "block";
        changePassword_newPwd.style.display = "block";

        changePassword_div_top.style.display = "block";
        changePassword_div_middle.style.display = "block";
        confirmNewPwd.style.display = "block";
    }
    else {
        chk_changePwd.checked = false;
        changePassword_header.style.display = "none";
        changePassword_currentPwd.style.display = "none";
        changePassword_newPwd.style.display = "none";

        changePassword_div_top.style.display = "none";
        changePassword_div_middle.style.display = "none";
        confirmNewPwd.style.display = "none";
    }
}

//if type=p
if (type == "p") {
    chk_changePwd.checked = true;
    changePassword_header.style.display = "block";
    changePassword_currentPwd.style.display = "block";
    changePassword_newPwd.style.display = "block";

    changePassword_div_top.style.display = "block";
    changePassword_div_middle.style.display = "block";
    confirmNewPwd.style.display = "block";
}
else {
    chk_changePwd.checked = false;
    changePassword_header.style.display = "none";
    changePassword_currentPwd.style.display = "none";
    changePassword_newPwd.style.display = "none";

    changePassword_div_top.style.display = "none";
    changePassword_div_middle.style.display = "none";
    confirmNewPwd.style.display = "none";
}

function validate_accountmailid(email) {
    var result = 0;
    var reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;    
    if (!reg.test(email)) {
        result = 1;
    }
    return result;
}

//var CheckDuplicate = false;
function CheckDuplicate_email(value) {
    debugger;
    var result = 0;
    if (txt_email.value != '') {
        result = validate_accountmailid(txt_email.value);
    }

    if (result == 0) {
        AutoFill.Check_EmailID_Duplicacy(StoreUserID, txt_email.value, AccountID, GetResult, onTimeout, onError);
    }
    else {
        spn_email.innerHTML = "Please enter a valid EmailID";
        spn_email.style.display = "block";
    }
}

function GetResult(result) {
    debugger;
    if (result == -1) {
        spn_email.innerHTML = "EmailID already exists.";
        spn_email.style.display = "block";
        CheckDuplicate = true;
    }
    else {
        spn_email.style.display = "none";
        CheckDuplicate = false;
    }
}

function onTimeout(request, context) {
    //            alert(request + " request");
    //            alert(context + " context");
}
function onError(objError) {
    //            alert(objError + " objError");

}


 function Validate() {
    debugger;
    var flag = false;
    if ((txt_firstName.value == "") || (txt_firstName.value.trim() == "")) {
        spn_firstName.style.display = "block";
        flag = true;
    }

    if ((txt_lastName.value == "") || (txt_lastName.value.trim() == "")) {
        spn_lastName.style.display = "block";
        flag = true;
    }

    if (txt_email.value == "") {
        spn_email.style.display = "block";
        flag = true;
    }
    var hdnValidation = document.getElementById("ctl00_ContentPlaceHolder1_hdnValidation");
    var DivApproverEmail = document.getElementById("ctl00_ContentPlaceHolder1_DivApproverEmail");
    if (hdnValidation.value == "True") {
        if (DivApproverEmail.style.display == "block") {
            if (txtApproverEmail.value == "") {
                SpnApproverEmailan.style.display = "block";
                flag = true;
            }
            else if (txtApproverEmail.value != "") {
                document.getElementById("SpnApproverEmailan").style.display = "none";
                re = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
                if (!re.test(txtApproverEmail.value)) {
                    document.getElementById("RegularExpressionValidator1").style.display = "block";
                    flag = true;
                }
                else {
                    document.getElementById("RegularExpressionValidator1").style.display = "none";
                }
            }
        }
    }
    else {
        if (validEmail(txt_email.value) == false) {
            spn_email.style.display = "block";
            //spn_email.innerHTML = "Invalid email format";
            spn_email.innerHTML = Invalid_email_format;
            flag = true;
        }
        else {
            var CheckDuplicate = false;
            //CheckDuplicate_email(txt_email.value);
            var dataValue = { "StoreUserID": StoreUserID, "val": txt_email.value, "AccountID": AccountID };
            $.ajax({
                type: "POST",
                url: "/AutoFill.asmx/Check_EmailID_Duplicacy",
                data: JSON.stringify(dataValue),
                async: false,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    debugger;
                    if (result.d == -1) {
                        spn_email.innerHTML = "EmailID already exists.";
                        spn_email.style.display = "block";
                        CheckDuplicate = true;
                    }
                    else {
                        spn_email.style.display = "none";
                        CheckDuplicate = false;
                    }
                    if (CheckDuplicate) {
                        spn_email.style.display = "block";
                        spn_email.innerHTML = EmailID_already_exists;
                        flag = true;
                    }
                }
            });
         
        }
    }

    if (chk_changePwd.checked) {
        if (txt_currentPwd.value == "") {
            spn_changePwd.style.display = "block";
            flag = true;
        }

        if (txt_newPwd.value.trim() == "") {
            spn_newPwd.style.display = "block";
            flag = true;
        }

        if (txt_confirmPwd.value.trim() == "") {
            spn_confirmPwd.style.display = "block";
            flag = true;
        }
        else if (txt_confirmPwd.value != txt_newPwd.value) {
            spn_confirmPwd.style.display = "block";
            //spn_confirmPwd.innerHTML = "Please make sure your passwords match.";
            spn_confirmPwd.innerHTML = Please_make_sure_your_passwords_match;
            flag = true;
        }
    }

    if (flag) {
        return false;
    }
    else {
        if (CheckDuplicate) {
            return false;
        }
        else {
            loadingimg('div_btnsave', 'div_btnsaveprocess');
            return true;
        }
    }
}



