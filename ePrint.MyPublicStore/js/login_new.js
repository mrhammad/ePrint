var IsfromPage;
var ProductID;
var pname;

function ShowLogin() {
    $("#divLogInNew").fadeIn();
    $("#loginoverlay").show();
    $("#logindialog").fadeIn(1000);
    $("#divSignUp").fadeOut();
    $("#divForgotPassword").fadeOut();
    $("#signInemail").focus();
    debugger
    IsfromPage = 'login';
    document.getElementById("login-error").style.visibility = "hidden";
    document.getElementById("forgot-error").style.visibility = "hidden";
    document.getElementById("signUp-error").style.visibility = "hidden";
    document.getElementById("agent-error").style.visibility = "hidden";

    document.getElementById("forgot-error").innerHTML = 'Please enter your email address';

    document.getElementById("signInemail").value = '';
    document.getElementById("signIn-pass").value = '';
    document.getElementById("txtEmail").value = '';
    document.getElementById("txtuname").value = '';
    document.getElementById("txtlname").value = '';
    document.getElementById("txtsignupEmail").value = '';
    document.getElementById("txtupass").value = '';
    document.getElementById("txtcpass").value = '';

    document.getElementById("signInemail").className = 'txtvalidemail';
    document.getElementById("signIn-pass").className = 'txtvalidemail';
    document.getElementById("txtEmail").className = 'txtvalidemail';

    document.getElementById("txtcpass").className = 'txtvalidLCP';
    document.getElementById("txtupass").className = 'txtvalidFLPCCN';
    document.getElementById("txtsignupEmail").className = 'txtvalidemail';
    document.getElementById("txtuname").className = 'txtvalidFLPCCN';
    document.getElementById("txtlname").className = 'txtvalidLCP';
    return false;
}

function ShowForgotPasswordDialog() {
    $("#loginoverlay").show();
    $("#divForgotPassword").fadeIn(1000);
    $("#logindialog").fadeOut();

    document.getElementById("login-error").style.visibility = "hidden";
    document.getElementById("forgot-error").style.visibility = "hidden";
    document.getElementById("signUp-error").style.visibility = "hidden";
    document.getElementById("agent-error").style.visibility = "hidden";
    document.getElementById("forgot-error").innerHTML = 'Please enter your email address';

    document.getElementById("signInemail").value = '';
    document.getElementById("signIn-pass").value = '';
    document.getElementById("txtEmail").value = '';

    document.getElementById("txtuname").value = '';
    document.getElementById("txtlname").value = '';
    document.getElementById("txtsignupEmail").value = '';
    document.getElementById("txtupass").value = '';
    document.getElementById("txtcpass").value = '';

    document.getElementById("signInemail").className = 'txtvalidemail';
    document.getElementById("signIn-pass").className = 'txtvalidemail';
    document.getElementById("txtEmail").className = 'txtvalidemail';

    document.getElementById("txtcpass").className = 'txtvalidLCP';
    document.getElementById("txtupass").className = 'txtvalidFLPCCN';
    document.getElementById("txtsignupEmail").className = 'txtvalidemail';
    document.getElementById("txtuname").className = 'txtvalidFLPCCN';
    document.getElementById("txtlname").className = 'txtvalidLCP';
}

function ShowSignUpDialog() {
    debugger;
    var _url = window.location.href;
    var _web = 'smartdisplays';
    if (_url.includes(_web)) {
        window.open(" https://smartdisplays.com.au/create-an-account/");
    } else {

        $("#divLogInNew").fadeIn();
        $("#loginoverlay").show();
        $("#divSignUp").fadeIn(1000);
        $("#logindialog").fadeOut();
        $("#txtcompanyname").focus();

        if (document.getElementById("ctl00_divcompanyname").style.display == "none" && document.getElementById("ctl00_divsubscribe").style.display == "none") {
            //$("#divSignUp").height(260);
        }
        else if (document.getElementById("ctl00_divsubscribe").style.display == "none" || document.getElementById("ctl00_divcompanyname").style.display == "none") {
            //$("#divSignUp").height(300);
        }
        else {
            //$("#divSignUp").height(340);
        }

        document.getElementById("login-error").style.visibility = "hidden";
        document.getElementById("forgot-error").style.visibility = "hidden";
        document.getElementById("signUp-error").style.visibility = "hidden";
        document.getElementById("agent-error").style.visibility = "hidden";
        document.getElementById("forgot-error").innerHTML = 'Please enter your email address';

        document.getElementById("signInemail").value = '';
        document.getElementById("signIn-pass").value = '';
        document.getElementById("txtEmail").value = '';

        document.getElementById("txtuname").value = '';
        document.getElementById("txtlname").value = '';
        document.getElementById("txtsignupEmail").value = '';
        document.getElementById("txtupass").value = '';
        document.getElementById("txtcpass").value = '';

        document.getElementById("signInemail").className = 'txtvalidemail';
        document.getElementById("signIn-pass").className = 'txtvalidemail';
        document.getElementById("txtEmail").className = 'txtvalidemail';

        document.getElementById("txtcpass").className = 'txtvalidLCP';
        document.getElementById("txtupass").className = 'txtvalidFLPCCN';
        document.getElementById("txtsignupEmail").className = 'txtvalidemail';
        document.getElementById("txtuname").className = 'txtvalidFLPCCN';
        document.getElementById("txtlname").className = 'txtvalidLCP';
    }
}

function closePops() {

    $("#loginoverlay").hide();
    $("#logindialog").fadeOut(100);
    $("#divForgotPassword").fadeOut(100);
    $("#divSignUp").fadeOut(100);

    document.getElementById("login-error").style.visibility = "hidden";
    document.getElementById("forgot-error").style.visibility = "hidden";
    document.getElementById("signUp-error").style.visibility = "hidden";
    document.getElementById("agent-error").style.visibility = "hidden";

    document.getElementById("signInemail").value = '';
    document.getElementById("signIn-pass").value = '';
    document.getElementById("txtEmail").value = '';

    document.getElementById("txtuname").value = '';
    document.getElementById("txtlname").value = '';
    document.getElementById("txtsignupEmail").value = '';
    document.getElementById("txtupass").value = '';
    document.getElementById("txtcpass").value = '';

    document.getElementById("signInemail").className = 'txtvalidemail';
    document.getElementById("signIn-pass").className = 'txtvalidemail';
    document.getElementById("txtEmail").className = 'txtvalidemail';

    document.getElementById("txtcpass").className = 'txtvalidLCP';
    document.getElementById("txtupass").className = 'txtvalidFLPCCN';
    document.getElementById("txtsignupEmail").className = 'txtvalidemail';
    document.getElementById("txtuname").className = 'txtvalidFLPCCN';
    document.getElementById("txtlname").className = 'txtvalidLCP';

    document.getElementById("forgot-error").innerHTML = 'Please enter your email address';
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

function CheckLogin(txtEmail, txtPwd, accid, AccountType) {
    $.ajax({
        type: "POST",
        url: strSitePath + "LoginMethods.aspx/Login",
        data: header_GetInput_task(txtEmail, txtPwd, accid, AccountType),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: MainBindCalls,
        error: ServiceFailed
    });
}

function header_GetInput_task(txtEmail, txtPwd, accid, AccountType) {
    var FinalString = ' { "txtEmail" : "' + txtEmail + '" , "txtPwd" : "' + txtPwd + '" , "accid" : "' + accid + '" , "AccountType" : "' + AccountType + '"} '
    return FinalString;
}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + ' ' + result.statusText);
}

function MainBindCalls(data) {
    var DataRows = data.d;
    if (DataRows.length == 0) {
        return;
    }

    var Result = DataRows[0].Result;

    if (Result == "accountdeactivated") {
        document.getElementById("login-error").style.visibility = "visible";
        document.getElementById("login-error").innerHTML = "Your account is deactivated";
        //loadinglogimg('divlgimg', 'divlogin');
        return false;
    }
    else if (Result == "invaliddetails") {
        document.getElementById("login-error").style.visibility = "visible";
        document.getElementById("login-error").innerHTML = "Invalid login or password";
        // loadinglogimg('divlgimg', 'divlogin');
        return false;
    }
    else {
        document.getElementById("ctl00_hdnIsfromPage").value = IsfromPage;
        document.getElementById("ctl00_hdnloginproductID").value = ProductID;
        document.getElementById("ctl00_hdnloginproductname").value = pname;

        document.getElementById("ctl00_btnloginsave").click();
        //  loadinglogimg('divlogin', 'divlgimg');
        return true;
    }
    //else {

    //    if (Result == '0') {
    //        IsfromPage = 'carticon';
    //    }
    //    else if (Result == '0' && ID == '0') {
    //        IsfromPage = 'main';
    //    }
    //    else if (Result == '1') {
    //        IsfromPage = 'sitemap';
    //    }
    //    else {
    //        IsfromPage = 'product';
    //    }
    //    ProductID = 0;
    //    pname = Result;

    //    document.getElementById("ctl00_hdnIsfromPage").value = IsfromPage;
    //    document.getElementById("ctl00_hdnloginproductID").value = ProductID;
    //    document.getElementById("ctl00_hdnloginproductname").value = pname;
    //    //document.getElementById("ctl00_btnloginsave").onclick();
    //    var signin_email = $('#signInemail').val();
    //    var signin_password = $('#signIn-pass').val();

    //    $.ajax({
    //        type: "POST",
    //        url: strSitePath + "LoginMethods.aspx/btnlogin_Click",
    //        data: ' { "hdnIsfromPage" : "' + IsfromPage + '" , "hdnloginproductID" : "' + ProductID + '" , "hdnloginproductname" : "' + pname + '","signin_email":"' + signin_email + '","signin_password":"' + signin_password + '"} ',
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (data) {
    //            window.location = data.d
    //        },
    //        error: ServiceFailed
    //    });
    //    //  loadinglogimg('divlogin', 'divlgimg');
    //    return true;
    //}
}

function validateForgotPassword() {
    var txtEmail = document.getElementById("txtEmail");

    if (txtEmail.value.length == 0) {
        document.getElementById("forgot-error").style.visibility = "visible";
        txtEmail.className = 'txtEmail';
        return false;
    }
    else if (txtEmail.value.length > 0 && echeck(txtEmail.value) == false) {
        document.getElementById("forgot-error").style.visibility = "visible";
        document.getElementById("forgot-error").innerHTML = "Please enter a valid email";
        txtEmail.className = 'txtEmail';
        return false;
    }

    txtEmail.className = 'txtvalidemail';

    document.getElementById("forgot-error").style.visibility = "hidden";
    document.getElementById("signUp-error").style.visibility = "hidden";
    document.getElementById("login-error").style.visibility = "hidden";
    document.getElementById("agent-error").style.visibility = "hidden";

    SendEmail(txtEmail.value, accid, AccountType);
    loadinglogimg('divfp', 'divfpimg');
    return false;
    //return true;
}

function SendEmail(txtEmail, accid, AccountType) {
    $.ajax({
        type: "POST",
        url: strSitePath + "LoginMethods.aspx/ForgotPassword",
        data: ForgotPwd(txtEmail, accid, AccountType),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: ForgotDetailsBind,
        error: ServiceFailed
    });
}

function ForgotPwd(txtEmail, accid, AccountType) {
    var FinalString = ' { "txtEmail" : "' + txtEmail + '" , "accid" : "' + accid + '" , "AccountType" : "' + AccountType + '" } '
    return FinalString;
}

function ForgotDetailsBind(data) {
    var DataRows = data.d;
    if (DataRows.length == 0) {
        return;
    }
    var Result = DataRows[0].Result;

    if (Result == "success") {
        document.getElementById("forgot-error").style.visibility = "visible";
        document.getElementById("forgot-error").innerHTML = "The password has been send to your email";
        document.getElementById("txtEmail").value = '';
        document.getElementById("txtEmail").className = 'txtvalidemail';
        loadinglogimg('divfpimg', 'divfp');
        return false;
    }
    else if (Result == "not exists") {
        document.getElementById("forgot-error").style.visibility = "visible";
        document.getElementById("forgot-error").innerHTML = "The email which you have entered doesnot exist in our system. Please retry or create a new account";
        document.getElementById("txtEmail").className = 'txtEmail';
        loadinglogimg('divfpimg', 'divfp');
        return false;
    }
}

function echeck(str) {
    var EmailExn = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9_\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!EmailExn.test(str)) {
        return false;
    }
    return true;
}

function GetResult(result) {
    var NewResult = result;
    if (!isNaN(NewResult)) {
        if (NewResult == "account deactivated") {
            document.getElementById("login-error").innerHTML = "Your account is deactivated";
            return false;
        }
        else {
            document.getElementById("login-error").innerHTML = "Invalid login or password";
            return false;
        }
    }
    else {
        document.getElementById("hdnstoreUserID").value = result;
        return true;
    }
}

function ShowLoginonProduct(ID, Name) {

    if (Name == '0') {
        IsfromPage = 'carticon';
    }
    else if (Name == '0' && ID == '0') {
        IsfromPage = 'main';
    }
    else if (Name == '1') {
        IsfromPage = 'sitemap';
    }
    else {
        IsfromPage = 'product';
    }
    ProductID = ID;
    pname = Name;
    debugger;
    $("#divLogInNew").fadeIn();
    $("#loginoverlay").show();
    $("#logindialog").fadeIn(1000);
    $("#divSignUp").fadeOut();
    $("#divForgotPassword").fadeOut();

    document.getElementById("login-error").style.visibility = "hidden";
    document.getElementById("forgot-error").style.visibility = "hidden";
    document.getElementById("signUp-error").style.visibility = "hidden";
    document.getElementById("agent-error").style.visibility = "hidden";

    document.getElementById("forgot-error").innerHTML = 'Please enter your email address';

    document.getElementById("signInemail").value = '';
    document.getElementById("signIn-pass").value = '';
    document.getElementById("txtEmail").value = '';

    document.getElementById("txtuname").value = '';
    document.getElementById("txtlname").value = '';
    document.getElementById("txtsignupEmail").value = '';
    document.getElementById("txtupass").value = '';
    document.getElementById("txtcpass").value = '';

    document.getElementById("signInemail").className = 'txtvalidemail';
    document.getElementById("signIn-pass").className = 'txtvalidemail';
    document.getElementById("txtEmail").className = 'txtvalidemail';

    return false;
}

function onTimeout(request, context) { }
function onError(objError) { }


function validateaccount() {
    var txtuname = document.getElementById("txtuname");
    var txtlname = document.getElementById("txtlname");
    var txtsignupEmail = document.getElementById("txtsignupEmail");
    var txtupass = document.getElementById("txtupass");
    var txtcpass = document.getElementById("txtcpass");
    var txtcompanyname = document.getElementById("txtcompanyname");

    var txtPhone = document.getElementById("txtPhoneNo");
    var txtMobilePhone = document.getElementById("txtMobile_Phone");


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
    ////////////Added by Amin for captcha
    //if (txtcaptcha.value.replace(/\s/g, '') !== txtcaptchaInput.value.replace(/\s/g, '')) {
    //    document.getElementById("signUp-error").style.visibility = "visible";
    //    document.getElementById("signUp-error").innerHTML = "Please enter valid captcha words";
    //    txtEmail.className = 'txtEmail';
    //    return false;
    //}
    document.getElementById("forgot-error").style.visibility = "hidden";
    document.getElementById("login-error").style.visibility = "hidden";
    document.getElementById("signUp-error").style.visibility = "hidden";
    document.getElementById("agent-error").style.visibility = "hidden";

    var chk = document.getElementById("ctl00_chkAddEmilDmc");
    var AddEmilToDmc;
    if (chk.checked) {
        AddEmilToDmc = 'true';
    }
    else {
        AddEmilToDmc = 'false';
    }

    var AG = IsValidAgentCode;
    var LoginAgentCode = LoginOrgAgentCode;
    var agentcode = '';
    if (AG.toLowerCase() == 'true') {
        agentcode = LoginAgentCode;
    }
    debugger;
    Accountcreate(AddEmilToDmc, txtcompanyname.value, txtsignupEmail.value, txtuname.value, txtlname.value, txtupass.value, agentcode, txtPhone.value, txtMobilePhone.value);
    loadinglogimg('divsu', 'divsuimg');
    return false;
}

function Accountcreate(AddEmilToDmc, txtcompanyname, txtsignupEmail, txtuname, txtlname, txtupass, agentcode, txtPhone, txtMobilePhone) {
    $.ajax({
        type: "POST",
        url: strSitePath + "LoginMethods.aspx/accountcreate",
        data: accountvalue(AddEmilToDmc, txtcompanyname, txtsignupEmail, txtuname, txtlname, txtupass, agentcode, txtPhone, txtMobilePhone),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: details,
        error: ServiceFailed
    });
}

function accountvalue(AddEmilToDmc, txtcompanyname, txtsignupEmail, txtuname, txtlname, txtupass, agentcode, txtPhone, txtMobilePhone) {
    var FinalString = ' { "AddEmilToDmc" : "' + AddEmilToDmc + '" , "txtcompanyname" : "' + txtcompanyname + '" , "txtsignupEmail" : "' + txtsignupEmail + '" , "txtuname" : "' + txtuname + '" , "txtlname" : "' + txtlname + '" , "txtupass" : "' + txtupass + '" , "agentcode" : "' + agentcode + '", "Phone" : "' + txtPhone + '", "mobilePhone" : "' + txtMobilePhone + '"} '
    return FinalString;
}

function details(data) {
    var DataRows = data.d;
    if (DataRows.length == 0) {
        return;
    }

    var Result = DataRows[0].Result;

    if (Result == "exists") {
        document.getElementById("signUp-error").style.visibility = "visible";
        document.getElementById("signUp-error").innerHTML = "Email already exists";
        document.getElementById("txtsignupEmail").className = 'txtEmail';
        loadinglogimg('divsuimg', 'divsu');
        return false;
    }
    else {
        if (Result == '0' || AccountType.toLowerCase() != "public") {
            if (LoginRewritemodule.toLowerCase() == 'on') {
                window.location = strSitePath + "account/account" + LoginFileExtension;
            }
            else {
                window.location = strSitePath + "account/account.aspx";
            }
        }
        if (Result == 'phoneink') {
            if (LoginRewritemodule.toLowerCase() == 'on') {
                window.location = strSitePath + "products" + LoginKeySeparator + 0 + LoginFileExtension;
            }
            else {
                window.location = strSitePath + "products/product.aspx?ID=0";
            }
        }
        else {
            if (LoginRewritemodule.toLowerCase() == 'on') {
                if (window.location.href.indexOf("shoppingcart") > -1) {
                    window.location = strSitePath + "shoppingcart" + LoginKeySeparator + "0" + LoginKeySeparator + "0" + LoginFileExtension;
                }
                else {
                    window.location = strSitePath + "products" + LoginKeySeparator + 0 + LoginFileExtension;
                }
            }
            else {
                var url = window.location.href;
                window.open(url, '_self');
            }
        }
    }
}

function loadinglogimg(div1, div2) {
    document.getElementById(div1).style.display = "none";
    document.getElementById(div2).style.display = "block";
}

function ShowAgentCode() {
    $("#divagentcode").fadeIn();
    $("#agentcodeoverlay").show();
    $("#agentdialog").fadeIn(1000);

    document.getElementById("agentcode").value = '';
    document.getElementById("agentcode").className = 'txtvalidagentcode';
    document.getElementById("agent-error").style.visibility = "hidden";
    return false;
}

function closeagentcode() {
    $("#agentcodeoverlay").hide();
    $("#agentdialog").fadeOut(100);
    document.getElementById("agent-error").style.visibility = "hidden";
}


function CreateCookieforagentCode() {

    var agentcode = document.getElementById("agentcode");
    agentcode.className = 'txtvalidagentcode';

    if (agentcode.value.length == 0) {
        document.getElementById("agent-error").style.visibility = "visible";
        document.getElementById("agent-error").innerHTML = "Please enter agent code";
        agentcode.className = 'txtscrtcode';
        return false;
    }

    GetAgentCode(agentcode.value);
    loadinglogimg('divag', 'divagimg');
    return false;
}

function GetAgentCode(AgentCode) {
    $.ajax({
        type: "POST",
        url: strSitePath + "LoginMethods.aspx/GetCLientIDbyAgentcode",
        data: Code(AgentCode),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: agentdetails,
        error: ServiceFailed
    });
}

function Code(AgentCode) {
    var FinalString = ' { "AgentCode" : "' + AgentCode + '"} '
    return FinalString;
}

function agentdetails(data) {

    var DataRows = data.d;
    if (DataRows.length == 0) {
        return;
    }

    var Result = DataRows[0].Result;

    if (Result == '0') {
        document.getElementById("agent-error").style.visibility = "visible";
        document.getElementById("agent-error").innerHTML = "Code does not exist! Please contact administrator";
        document.getElementById("agentcode").className = 'txtscrtcode';
        loadinglogimg('divagimg', 'divag');
        return false;
    }
    else {
        var CookieDate = new Date;
        CookieDate.setFullYear(CookieDate.getFullYear() + 1);
        document.cookie = 'agentcode=' + agentcode.value + '; expires=' + CookieDate.toGMTString() + ';';
        document.cookie = 'clientidforagentcode=' + Result + '; expires=' + CookieDate.toGMTString() + ';';
        document.getElementById("ctl00_btnagentsubmit").click();
        return true;
    }
}

function ValidateSecretCode() {
    var txtSecret = document.getElementById("txtSecret");

    txtSecret.className = 'txtvalidagentcode';

    if (txtSecret.value.length == 0) {
        document.getElementById("secret-error").style.visibility = "visible";
        document.getElementById("secret-error").innerHTML = "Please enter secret code";
        txtSecret.className = 'txtscrtcode';
        return false;
    }

    GetSrtCode(txtSecret.value);
    // document.getElementById("ctl00_ContentPlaceHolder1_hdnsecretcode").value = txtSecret.value;
    loadingimg('divsubmit', 'divimg');
    return false;
}


function GetSrtCode(SecretCode) {
    $.ajax({
        type: "POST",
        url: strSitePath + "LoginMethods.aspx/GetSecretCode",
        data: SrtCode(SecretCode),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Srtdetails,
        error: ServiceFailed
    });
}

function SrtCode(SecretCode) {
    var FinalString = ' { "SecretCode" : "' + SecretCode + '"} '
    return FinalString;
}

function Srtdetails(data) {

    var DataRows = data.d;
    if (DataRows.length == 0) {
        return;
    }

    var Result = DataRows[0].Result;

    if (Result == '0') {
        document.getElementById("secret-error").style.visibility = "visible";
        document.getElementById("secret-error").innerHTML = "Code does not exist! Please contact administrator";
        document.getElementById("txtSecret").className = 'txtscrtcode';
        loadingimg('divimg', 'divsubmit');
        return false;
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_hdnsecretcode").value = txtSecret.value;
        document.getElementById("ctl00_ContentPlaceHolder1_btnOrderonsubmit").click();
        return true;
    }
}

function closesecretcode() {
    $("#secreatcodeoverlay").hide();
    $("#secretcodedialog").fadeOut(100);
    document.getElementById("secret-error").style.visibility = "hidden";
}

function ShowSecretCode() {
    $("#divsecreatcode").fadeIn();
    $("#secreatcodeoverlay").show();
    $("#secretcodedialog").fadeIn(1000);

    document.getElementById("txtSecret").value = '';
    document.getElementById("txtSecret").className = 'txtvalidagentcode';
    document.getElementById("secret-error").style.visibility = "hidden";
    return false;
}