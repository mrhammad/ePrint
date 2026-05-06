
function remember() {
    document.getElementById('password').value = document.getElementById('hdnpassword').value
}

function showPassword() {
    var showPasswordCheckBox = document.getElementById("chkshowpassword");
    if (showPasswordCheckBox.checked) {
        document.getElementById("password").type = "TEXT";
    } else {
        document.getElementById("password").type = "PASSWORD";
    }
}