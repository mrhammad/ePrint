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

var CheckDuplicate = false;
function CheckDuplicate_email(value) {
    AutoFill.Check_EmailID_Duplicacy(StoreUserID, txt_email.value, AccountID, GetResult, onTimeout, onError);
}

function GetResult(result) {
    if (result == -1) {
        spn_email.innerHTML = "EmailID already exists.";
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
    else {
     
        if (validEmail(txt_email.value) == false) {
            spn_email.style.display = "block";
            //spn_email.innerHTML = "Invalid email format";
            spn_email.innerHTML = Invalid_email_format;
            flag = true;
        }
        else {
            CheckDuplicate_email(txt_email.value);
            if (CheckDuplicate) {
                spn_email.style.display = "block";
                spn_email.innerHTML = EmailID_already_exists;
                //spn_email.innerHTML = "EmailID already exists";
                flag = true;
            }
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
            return true;
        }
    }
}



