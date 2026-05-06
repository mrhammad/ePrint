
function validateNumberOnly(evt) {    
    var charCode = (evt.which) ? evt.which : window.event.keyCode;

    if (charCode <= 13) {
        return true;
    }
    else {
        var keyChar = String.fromCharCode(charCode);
        var re = /[0-9 ||.]/
        return re.test(keyChar);
    }
}

function roundNumber_new(number, digits) {
    var multiple = Math.pow(10, digits);
    var rndedNum = Math.round(number * multiple) / multiple;
    return rndedNum.toFixed(digits);
}

function roundUp(id, Value, RoundOff) {
    var txt = document.getElementById(id);
    if (isNaN(Value)) {
        Value = "0.00";
    }
    txt.value = roundNumber_new(Value, RoundOff);
}

function calculateTarget() {    
    var txtTarget1 = document.getElementById("ctl00_ContentPlaceHolder1_txtTarget1")
    var txtTarget2 = document.getElementById("ctl00_ContentPlaceHolder1_txtTarget2")
    var txtTarget3 = document.getElementById("ctl00_ContentPlaceHolder1_txtTarget3")
    var lbltargettotal = document.getElementById("ctl00_ContentPlaceHolder1_lbltargettotal")
    var result = "0.00";
    if (txtTarget1.value != "") {
        result = Number(txtTarget1.value);
    }
    if (txtTarget2.value != "") {
        result = Number(result) + Number(txtTarget2.value);
    }
    if (txtTarget3.value != "") {
        result = Number(result) + Number(txtTarget3.value);
    }
    if (isNaN(result)) {
        lbltargettotal.innerHTML = roundNumber_new(0, RoundOff);
    }
    else {
        lbltargettotal.innerHTML = roundNumber_new(result, RoundOff);
    }
}

function calculateCommit() {    
    var txtcommit1 = document.getElementById("ctl00_ContentPlaceHolder1_txtcommit1")
    var txtcommit2 = document.getElementById("ctl00_ContentPlaceHolder1_txtcommit2")
    var txtcommit3 = document.getElementById("ctl00_ContentPlaceHolder1_txtcommit3")
    var lblminimumtargettotal = document.getElementById("ctl00_ContentPlaceHolder1_lblminimumtargettotal")

    var resultcommit = "0.00";
    if (txtcommit1.value != "") {
        resultcommit = Number(txtcommit1.value);
    }
    if (txtcommit2.value != "") {
        resultcommit = Number(resultcommit) + Number(txtcommit2.value);
    }
    if (txtcommit3.value != "") {
        resultcommit = Number(resultcommit) + Number(txtcommit3.value);
    }
    if (isNaN(resultcommit)) {
        lblminimumtargettotal.innerHTML = roundNumber_new(0, RoundOff);
    }
    else {
        lblminimumtargettotal.innerHTML = roundNumber_new(resultcommit, RoundOff);
    }
}

function calculateBestCase() {

    var txtbestcase1 = document.getElementById("ctl00_ContentPlaceHolder1_txtbestcase1")
    var txtbestcase2 = document.getElementById("ctl00_ContentPlaceHolder1_txtbestcase2")
    var txtbestcase3 = document.getElementById("ctl00_ContentPlaceHolder1_txtbestcase3")
    var lblbestcasetotal = document.getElementById("ctl00_ContentPlaceHolder1_lblbestcasetotal")

    var resultbest = "0.00";
    if (txtbestcase1.value != "") {
        resultbest = Number(txtbestcase1.value);
    }
    if (txtbestcase2.value != "") {
        resultbest = Number(resultbest) + Number(txtbestcase2.value);
    }
    if (txtbestcase3.value != "") {
        resultbest = Number(resultbest) + Number(txtbestcase3.value);
    }
    if (isNaN(resultbest)) {
        lblbestcasetotal.innerHTML = roundNumber_new(0, RoundOff);
    }
    else {
        lblbestcasetotal.innerHTML = roundNumber_new(resultbest, RoundOff);
    }
}

function openspsale() {
    var spsale = document.getElementById("ctl00_ContentPlaceHolder1_chkspecifictosalesperson");
    var allsale = document.getElementById("ctl00_ContentPlaceHolder1_chkAllsalesperson");
    var LISTBOX = document.getElementById("ctl00_ContentPlaceHolder1_lstsaleperson");

    if (spsale.checked) {
        document.getElementById("ctl00_ContentPlaceHolder1_divsalesperson").style.display = 'block';
        allsale.checked = false
        LISTBOX.selectedIndex = 1;
    }
    else if (spsale.checked == false) {
        try {
            document.getElementById("ctl00_ContentPlaceHolder1_divsalesperson").style.display = 'none';

        }
        catch (err) {
        }
    }
}

function openallsale() {
    var spsale = document.getElementById("ctl00_ContentPlaceHolder1_chkspecifictosalesperson");
    var allsale = document.getElementById("ctl00_ContentPlaceHolder1_chkAllsalesperson");

    if (allsale.checked) {
        spsale.checked = false
        document.getElementById("ctl00_ContentPlaceHolder1_divsalesperson").style.display = 'none';
    }
}

function displayloading(id) {
    loadingimage(id, 'div_btngoprocess');
}

function Printdisplayloading(id) {
    var loaded = false;
    loadingimage(id, 'divbtnprintablepro');

    if (loaded == false) {
        setInterval(function () {
            document.getElementById("divbtnprintablepro").style.display = "none";
            document.getElementById("divbtnprintable1").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_btnprintable").style.display = "block";
            loaded = true;
        }, 1000);
    }
}

function Printdisplayloading1(id) {
    var loaded1 = false;
    loadingimage(id, 'divbtnPrintpro');

    if (loaded1 == false) {
        setInterval(function () {
            document.getElementById("divbtnPrintpro").style.display = "none";
            document.getElementById("divbtnPrint1").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_btnPrint").style.display = "block";
            loaded1 = true;
        }, 1000);
    }
}

function DeleteForecast(id) {
    if (window.confirm('Are you sure you want to delete?')) {
        loadingimage(id, 'divbtndeletepro');
        return true;
    }
    else {
        return false;
    }
}   