

// JScript File
function validatesubject(obj) {
    var txtid = obj.id;
    var spnsubject = txtid.replace('txtsubject', 'spn_subject');

    if (obj.value == '') {
        document.getElementById(spnsubject).style.display = "block";
    }
    else {
        document.getElementById(spnsubject).style.display = "none";
    }
}

function validateEmail(field) {
    //var regex = /\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b/i;
    // var regex = /^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?), ?)*^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    //var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return (regex.test(field)) ? true : false;
}

function validateMultipleEmailsCommaSeparated(obj, value, spnidd, IsOnBlur) {
    spnid = obj.id;
    var chkid = '';
    if (spnidd == "spn_To") {
        spnid = spnid.replace('txtfirstname', 'spn_To');
        chkid = spnid.replace('spn_To', 'chkEmail');
    }
    if (spnidd == "spn_cc") {
        spnid = spnid.replace('txtcc', 'spn_cc');
        chkid = spnid.replace('spn_cc', 'chkEmail');
    }
    if (spnidd == "spn_bcc") {
        spnid = spnid.replace('txtbcc', 'spn_bcc');
        chkid = spnid.replace('spn_bcc', 'chkEmail');
    }
    spnid = document.getElementById(spnid);

    if (IsOnBlur != null) {
        if (IsOnBlur) {

            var chkObj = document.getElementById(chkid);
            if (chkObj.checked == false) {
                return false;
            }
        }
    }
    spnid.style.display = "none";

    if (value == '') {
        if (spnidd == "spn_To") {
            spnid.innerHTML = "Please enter email address";
            spnid.style.display = "block";
            return false;
        }
        else {
            return true;
        }
    }
    else {
        var result = value.split(",");
        var chkvalidate = 'false';
        for (var i = 0; i < result.length; i++) {
            if (result[i] != "") {
                var email = result[i].trim().replace(',', '');
                if (!validateEmail(email)) {
                    spnid.innerHTML = "Please enter valid email address";
                    spnid.style.display = "block";
                    chkvalidate = 'false';
                }
                else {
                    chkvalidate = 'true';
                }
            }
        }
        if (chkvalidate == 'false') {
            return false;
        }
        else {
            return true;
        }
    }
}

var Isvalided = true;
function checkvalidaetion11() {

    var Isvalided = true;
    for (var i = 1; i <= SupplierCount; i++) {
        var strto = txtfirstname.id;
        var strcc = txtcc.id;
        var strbcc = txtbcc.id;
        var strsubject = txtsubject.id;

        var spnto = spn_To.id;
        var spncc = spn_CC.id;
        var spnbcc = spn_BCC.id;
        var spnsubject = spn_subject.id;
        var chkEmailid = chkEmail.id;

        strto = strto.replace('uc' + SupplierCount + '', 'uc' + i + '');
        strcc = strcc.replace('uc' + SupplierCount + '', 'uc' + i + '');
        strbcc = strbcc.replace('uc' + SupplierCount + '', 'uc' + i + '');
        strsubject = strsubject.replace('uc' + SupplierCount + '', 'uc' + i + '');

        spnto = spnto.replace('uc' + SupplierCount + '', 'uc' + i + '');
        spncc = spncc.replace('uc' + SupplierCount + '', 'uc' + i + '');
        spnbcc = spnbcc.replace('uc' + SupplierCount + '', 'uc' + i + '');
        spnsubject = spnsubject.replace('uc' + SupplierCount + '', 'uc' + i + '');
        chkEmailid = chkEmailid.replace('uc' + SupplierCount + '', 'uc' + i + '');

        strto = document.getElementById(strto);
        strcc = document.getElementById(strcc);
        strbcc = document.getElementById(strbcc);
        strsubject = document.getElementById(strsubject);
        chkEmailid = document.getElementById(chkEmailid);

        if (chkEmailid.checked) {
            if (strto.value == "") {
                document.getElementById(spnto).style.display = "block";
                Isvalided = false;
            }
            else {
                if (!validateMultipleEmailsCommaSeparated(txtfirstname, strto.value, 'spn_To')) {
                    Isvalided = false;
                }
            }

            if (strcc.value != "") {
                if (!validateMultipleEmailsCommaSeparated(txtcc, strcc.value, 'spn_cc')) {
                    Isvalided = false;
                }
            }

            if (strbcc.value != "") {
                if (!validateMultipleEmailsCommaSeparated(txtbcc, strbcc.value, 'spn_bcc')) {
                    Isvalided = false;
                }
            }

            if (txtsubject.value == "") {
                document.getElementById(spnsubject).style.display = "block";
                Isvalided = false;
            }
        }
        else {

            Isvalided = true;
        }
    }
    if (Isvalided) {
        Checked_SuplierAttach();
        parent.document.getElementById("ds00").style.height = window.screen.availHeight + (window.screen.availHeight / 2) + "px";
        parent.document.getElementById("div_Load").style.display = "block";
        parent.document.getElementById("ds00").style.display = "block";
        return true;
    }
    else {
        return false;
    }
}

function BindContact_EmailIDS(to, cc, bcc) {
    txtfirstname = document.getElementById(imgID.replace('imgselectleadmain', 'txtfirstname'));
    txtcc = document.getElementById(imgID.replace('imgselectleadmain', 'txtcc'));
    txtbcc = document.getElementById(imgID.replace('imgselectleadmain', 'txtbcc'));

    txtfirstname.value = to;
    txtcc.value = cc;
    txtbcc.value = bcc;
}

function forRedirect(RedirectPath) {
    window.parent.location = RedirectPath;
}

