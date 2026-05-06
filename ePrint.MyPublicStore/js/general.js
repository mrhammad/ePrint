
function PopupCenter(pageURL, w, h) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    var targetWin = window.open(pageURL, '', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

}

function Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Amount, Scale, CalculationUnit, IsQuantity, isAddDecimalPlacesToQty, isView) {

    var settingScale = roundoff;

    if (Scale > 0) {
        settingScale = Scale;
    }

    if (IsQuantity && !isAddDecimalPlacesToQty) {
        return roundNumber_new(Amount, 0);
    }
    return roundNumber_new(Amount, settingScale);


}
function roundNumber_new(number, digits) {
    var multiple = Math.pow(10, digits);
    var rndedNum = Math.round(number * multiple) / multiple;
    return rndedNum.toFixed(digits);
}

function RemoveIllegalChars(S) {
    if (S != "") {
        S = S.replace("%27", "");
        S = S.replace("%22", "\"");
        S = S.replace("@", "-");
        S = S.replace("/", "-");
        S = S.replace("|", "-");
        S = S.replace(":", "-");
        S = S.replace("*", "-");
        S = S.replace("?", "-");
        S = S.replace("<", "-");
        S = S.replace(">", "-");
        S = S.replace("&", "");
        S = S.replace(".htm", "?htm");
        S = S.replace(".", "");
        S = S.replace("?htm", ".htm");
        S = S.replace("(", "_");
        S = S.replace(")", "_");
        S = S.replace("%", "");
        S = S.replace("\"", "-");
        S = S.replace(" ", "-");
        S = S.replace("#", "");
        S = S.replace("+", "-");
        S = S.replace("\r\n", "-");
        S = S.replace("---", "-");
        S = S.replace("--", "-");
    }
    return S.toLowerCase();
}

function validEmail(str) {
    //    var EmailExn = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var EmailExn = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!EmailExn.test(str)) {
        return false
    }
    return true

    //    var at = "@"
    //    var dot = "."
    //    var lat = str.indexOf(at)
    //    var lstr = str.length
    //    var ldot = str.indexOf(dot)
    //    if (str.indexOf(at) == -1) {
    //        return false
    //    }

    //    if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
    //        return false
    //    }

    //    if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
    //        return false
    //    }

    //    if (str.indexOf(at, (lat + 1)) != -1) {
    //        return false
    //    }

    //    if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
    //        return false
    //    }

    //    if (str.indexOf(dot, (lat + 2)) == -1) {
    //        return false
    //    }

    //    if (str.indexOf(" ") != -1) {
    //        return false;
    //    }

    // return true;
}

//Start of validating date formate
var dtCh = "/";
var minYear = 1900;
var maxYear = 2100;

function isIntegerDate(s) {
    var i;
    for (i = 0; i < s.length; i++) {
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

function stripCharsInBag(s, bag) {
    var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function daysInFebruary(year) {
    // February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
}
function DaysArray(n) {
    for (var i = 1; i <= n; i++) {
        this[i] = 31
        if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
        if (i == 2) { this[i] = 29 }
    }
    return this
}


function isDate(dtStr, spnid, dateformat) {
    var daysInMonth = DaysArray(12)
    var pos1 = ''
    var pos2 = ''

    var strMonth = ''
    var strDay = ''
    var strYear = ''

    if (dateformat == "dd/mm/yyyy") {
        //alert('date');
        pos1 = dtStr.indexOf(dtCh)
        pos2 = dtStr.indexOf(dtCh, pos1 + 1)
        strDay = dtStr.substring(0, pos1)
        strMonth = dtStr.substring(pos1 + 1, pos2)
        strYear = dtStr.substring(pos2 + 1)
    }
    else if (dateformat == "mm/dd/yyyy") {
        //alert('month');
        pos1 = dtStr.indexOf(dtCh)
        pos2 = dtStr.indexOf(dtCh, pos1 + 1)
        strDay = dtStr.substring(pos1 + 1, pos2)//0,pos1)
        strMonth = dtStr.substring(0, pos1)//pos1+1,pos2)
        strYear = dtStr.substring(pos2 + 1)
        //alert("year="+dtStr.substring(pos1+1));
    }
    strYr = strYear
    if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
    if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
    for (var i = 1; i <= 3; i++) {
        if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
    }
    month = parseInt(strMonth)

    day = parseInt(strDay)
    year = parseInt(strYr)
    if (spnid != "") {
        document.getElementById(spnid).style.display = "none"
    }

    if (pos1 == -1 || pos2 == -1) {
        //alert("The date format should be : dd/mm/yyyy")
        if (spnid != "") {

            document.getElementById(spnid).style.display = "block"
            document.getElementById(spnid).innerHTML = "Invalid date format"; //"The date format should be : "+dateformat
        }
        return false
    }

    if (strMonth.length < 1 || month < 1 || month > 12) {

        if (spnid != "") {

            document.getElementById(spnid).style.display = "block"
            document.getElementById(spnid).innerHTML = "Please enter a valid month"
        }
        return false
    }
    if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
        //alert("Please enter a valid day")
        if (spnid != "") {
            document.getElementById(spnid).style.display = "block"
            document.getElementById(spnid).innerHTML = "Please enter a valid day"
        }
        return false
    }
    if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
        //alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
        if (spnid != "") {
            document.getElementById(spnid).style.display = "block"
            document.getElementById(spnid).innerHTML = "Please enter a valid year"
        }
        return false
    }
    if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isIntegerDate(stripCharsInBag(dtStr, dtCh)) == false) {
        //alert("Please enter a valid date")
        if (spnid != "") {
            document.getElementById(spnid).style.display = "block"
            document.getElementById(spnid).innerHTML = "Please enter a valid date"
        }
        return false
    }
    return true
}



function ValidateForm(txtObj, spnid, dateformat) {
    var dt = txtObj;
    if (isDate(dt.value, spnid, dateformat) == false) {
        if (dt.type != "hidden" && dt.style.display != "none" && !dt.disabled) {
            dt.focus();
        }
        return false;
    }
    return true
}
//End of validating date formate

// for UK client
function GetCurrencyinRequiredFormate(Amount, isSignRequired) {
    return jsCurrencySymbol + Amount;
}
function GetCurrencyFromRequiredFormatetoBack(Amount) {
    return Amount.replace(jsCurrencySymbol, '');
}

//Created On 04-06-2013 by kruti : To Replace single and Double Quotes
function SpecialEncode(OriginalString) {
    OriginalString = OriginalString.split("'").join('%27');
    OriginalString = OriginalString.split('"').join('%22');
    return OriginalString;
}
function SpecialDecode(OriginalString) {
    OriginalString = OriginalString.split('%27').join("'");
    OriginalString = OriginalString.split('%22').join('"');
    return OriginalString;
}
//end By kruti


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

function roundUp(id, Value, RoundOff) {
    var txt = document.getElementById(id);
    if (isNaN(Value)) {
        Value = "0.00";
    }
    txt.value = roundNumber_new(Value, RoundOff);
}