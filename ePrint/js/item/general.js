

// JScript File


function changeStyle(xobj, xStyle, xbgColor, xColor) {
    xobj.className = xStyle;
    xobj.style.backgroundColor = xbgColor;
    xobj.style.color = xColor;
}

function roundNumber(rnum, rlength) {
    //    if (rnum != 0 && rnum > 0) {
    //        rnum = Number(rnum) + Number(0.0000000000001);
    //    }
    //    var newnumber = parseInt(rnum * Math.pow(10, rlength)) / Math.pow(10, rlength);
    //    newnumber = parseFloat(newnumber).toFixed(2);
    return rnum;
    /*
    var newnumber = Math.round(rnum*Math.pow(10,rlength))/Math.pow(10,rlength);
    newnumber = parseFloat(newnumber).toFixed(2);
    return newnumber; */
}
function MakePrice2Decimal(txtObj, txtValue) {
    txtObj.value = txtValue;
}
function MakePrice2Decimal(txtObj) {
    if (!isNaN(txtObj.value)) {
        txtObj.value = txtObj.value;
    }
}
function IsIntegerParameter(s, spanid) {
    var i;
    s = s.toString();
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (isNaN(c)) {
            if (spanid != '') {
                document.getElementById(spanid).style.display = "block";
            }
            return false;
        }
    }
    if (spanid != '') {
        document.getElementById(spanid).style.display = "none";
    }
    return true;
}
///to validate integer value// BY SWETHA
function isInteger(spanid, s) {
    if (trim12(s) == "") {
        document.getElementById(spanid).style.display = "block";
    }
    var i;
    s = s.toString();
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (isNaN(c)) {
            // alert("Given value is not a number");
            document.getElementById(spanid).style.display = "block";
            return false;
        }
        else {
            document.getElementById(spanid).style.display = "none";
        }
    }
    return true;
}

///to validate decimal value// BY SWETHA
function checkDecimals(spanid, fieldName, fieldValue) {
    decallowed = 10;
    //var errmsg1 = "Please enter decimal value";
    var errmsg2 = "Enter a number with up to " + decallowed + " decimal places";

    if (isNaN(fieldValue))//|| fieldValue == ""
    {
        //alert("Not a valid number.try again.");
        document.getElementById(spanid).style.display = "block";
        //document.getElementById(spanid).innerHTML = errmsg1;
        return false;
    }
    else {
        if (fieldValue.indexOf('.') == -1) fieldValue += ".";
        dectext = fieldValue.substring(fieldValue.indexOf('.') + 1, fieldValue.length);

        if (dectext.length > decallowed) {
            //alert ("Enter a number with up to " + decallowed + "decimal places. try again.");
            document.getElementById(spanid).style.display = "block";
            document.getElementById(spanid).innerHTML = errmsg2;
            return false;
        }
        else {
            //alert ("Number validated successfully.");
            document.getElementById(spanid).style.display = "none";
        }
    }
    return true;
}

function CallonChange(val, spanid) {
    if (trim12(val) != "0") {
        document.getElementById(spanid).style.display = "none";
        return false;
    }
    else {
        document.getElementById(spanid).style.display = "block";
        return true;
    }
}
function CallonBlur(val, spanid) {
    if (trim12(val) != '') {
        document.getElementById(spanid).style.display = "none";
    }
    else {
        document.getElementById(spanid).style.display = "block";
    }
}


function trim12(str) {
    var str = str.replace(/^\s\s*/, ''),
		ws = /\s/,
		i = str.length;
    while (ws.test(str.charAt(--i)));
    return str.slice(0, i + 1);
}
function ToInteger(obj, val) {
    if (val.substring(val.length - 1, val.length) == ".") {
        obj.value = val.toString().replace('.', '');
    }
    else {
        obj.value = val;
    }
}
function CheckStringMandatory(val, spanid) {
    if (trim12(val) != '') {
        document.getElementById(spanid).style.display = "none";
        return false;
    }
    else {
        document.getElementById(spanid).style.display = "block";
        return true;
    }
}
//FOR INTEGER MANDATORY FIELDS
function CheckReqCompare(txtValue, span1, span2) {
    if (span1 != '') {
        document.getElementById(span1).style.display = 'none';
    }
    if (span2 != '') {
        document.getElementById(span2).style.display = 'none';
    }
    if (trim12(txtValue) == '') {
        document.getElementById(span1).style.display = 'block';
        return true;
    }
    else {
        if (!IsIntegerParameter(txtValue, span2)) {
            return true;
        }
    }
}

//FOR DECIMAL MANDATORY FIELDS
function CheckReqDecimal(txtValue, span1, span2) {
    if (txtValue == '') {
        document.getElementById(span1).style.display = 'block';
        return false;
    }
    else {
        if (!IsDecimalValue(txtValue, span2)) {
            return false;
        }
    }
    return true;
}
///to validate decimal value// BY VINAY
function IsDecimalValue(fieldValue, spanid) {
    decallowed = 20;
    var errmsg1 = "Please enter decimal value";
    var errmsg2 = "Enter a number with up to " + decallowed + " decimal places";


    if (fieldValue.indexOf('.') == -1) fieldValue += ".";
    dectext = fieldValue.substring(fieldValue.indexOf('.') + 1, fieldValue.length);


    if (dectext.length > decallowed) {
        //alert ("Enter a number with up to " + decallowed + "decimal places. try again.");
        document.getElementById(spanid).style.display = "block";
        //document.getElementById(spanid).innerHTML = errmsg2;
        return false;
    }
    else {
        //alert ("Number validated successfully.");
        document.getElementById(spanid).style.display = "none";
    }

    return true;
}

function OnlyDecimal(fieldValue, spanid) {
    if (trim12(fieldValue) != '') {
        return CheckDecimalPlus(fieldValue, spanid);
    }
    else {
        document.getElementById(spanid).style.display = "none";
        return true;
    }
}

function CheckDecimalPlus(fieldValue, spanid1, spanid2, IsRequired) {

    if (spanid1 != '') {
        document.getElementById(spanid1).style.display = "none";
    }
    if (spanid2 != '') {
        document.getElementById(spanid2).style.display = "none";
    }
    if (trim12(fieldValue) == '') {
        if (IsRequired == "yes") {
            document.getElementById(spanid1).style.display = "block";
            return false;
        }
        else {
            return true;
        }
    }
    else {
        if (!isNaN(fieldValue)) {
            decallowed = 10;
            if (fieldValue.indexOf('.') == -1) fieldValue += ".";
            dectext = fieldValue.substring(fieldValue.indexOf('.') + 1, fieldValue.length);
            if (dectext.length > decallowed) {
                document.getElementById(spanid2).style.display = "block";
                return false;
            }
            else {
                document.getElementById(spanid2).style.display = "none";
                return true;
            }
        }
        else {
            document.getElementById(spanid2).style.display = "block";
            return false;
        }
    }
}


//to limit description textbox to 3000 characters //BY YOGESH
var desccount = "3000";
function sizelimit(txtdesc, spanid) {
    txtdesc = txtdesc.id;
    var desctext;
    desctext = document.getElementById(txtdesc).value;
    var len = desctext.length;
    document.getElementById(spanid).style.display = 'none';
    if (len > desccount) {
        desctext = desctext.substring(0, desccount);
        document.getElementById(txtdesc).value = desctext;
        document.getElementById(spanid).style.display = 'block';
        return false;
    }

}
//Function limit textarea/multiline textbox text length//
function limitText(limitField, limitNum) {
    if (limitField.value.length > limitNum) {
        limitField.value = limitField.value.substring(0, limitNum);
    } else {
        return false;
        //limitCount.value = limitNum - limitField.value.length;
    }
}
//END Function limit textarea/multiline textbox text length//
function AllowNumber(obj, val) {
    debugger
    val = val.replace(/,/g, '');
    if (val.substring(1, 0) != "-")//for NEGATIVE Values
    {

        if (!isNaN(val)) {
            //alert(val);
            return true;
        }
        else {
            obj.value = '';
            obj.focus();
            return false;
        }
    }
    else {
        obj.value = '';
        obj.focus();
        return false;
    }
}

//END Function limit textarea/multiline textbox text length//
function AllowNumber_WithDefault(obj, objval, defaultval) {
    if (trim12(objval) != '') {
        if (objval.substring(1, 0) != "-")//for NEGATIVE Values
        {
            if (!isNaN(objval)) {
                objval = objval;
                return true;
            }
            else {
                obj.value = defaultval;
                return false;
            }
        }
        else {
            obj.value = defaultval;
            return false;
        }
    }
    else {
        obj.value = defaultval;
        return false;
    }
}

function Allow_Integer_Only(obj, AllowNegative, spn) {
    var val = obj.value;
    if (trim12(val) != '') {
        if (!isNaN(val)) {
            if (AllowNegative) {
                //Nothing
            }
            else {
                if (val.substring(1, 0) == "-") {
                    return false;
                }
            }
            var s_len = val.length;
            var s_charcode = 0;
            for (var s_i = 0; s_i < s_len; s_i++) {
                s_charcode = val.charCodeAt(s_i);
                if (!((s_charcode >= 48 && s_charcode <= 57))) {
                    return false;
                }
            }
            return true;
        }
        else {
            return false;
        }
        return true;
    }
    else {
        return false;
    }
}
function Check_spn_display(spnID, type) {
    if (document.getElementById("" + spnID + "") != null) {
        if (type == "show") {
            document.getElementById("" + spnID + "").style.display = "block";
        }
        else {
            document.getElementById("" + spnID + "").style.display = "none";
        }
    }
}
//***** Function to CHECK FOR NUMERIC AND SET DEFAULT=0 *****//
function SetNumber(obj, val) {
    if (trim12(val) != '') {
        if (val.substring(1, 0) != "-")//for NEGATIVE Values
        {
            if (!isNaN(val)) {
                val = val;
                return true;
            }
            else {
                obj.value = '0';
                return false;
            }
        }
        else {
            obj.value = '0';
            return false;
        }
    }
    else {
        obj.value = '0';
        return false;
    }
}
//***** END of Function to CHECK FOR NUMERIC AND SET DEFAULT=0 *****//
//***** Function to CHECK FOR NUMERIC AND SET DEFAULT=0 *****//
function SetNumberWithMinus(obj, val) {
    if (trim12(val) != '') {
        if (!isNaN(val)) {
            val = val;
            return true;
        }
        else {
            obj.value = '0';
            return false;
        }
    }
    else {
        obj.value = '0';
        return false;
    }
}
//***** END of Function to CHECK FOR NUMERIC AND SET DEFAULT=0 *****//

//*** FUNCN TO ROUNDOFF VALUE TO 2 DECIMAL PLACES *****///
function CallRoundValue(objX, val) {
    //rounding to 2 decimals//
    val = val;
    var result = roundNumber(val, 2);
    objX.value = result;
}
//*** END OF FUNCN TO ROUNDOFF VALUE TO 2 DECIMAL PLACES *****///

// FOR DATE VALIDATION

/**
* DHTML date validation script. Courtesy of SmartWebby.com (http://www.smartwebby.com/dhtml/)
*/
// Declaring valid date character, minimum year and maximum year
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
     //var daysInMonth = DaysArray(12)
    var daysInMonth = [];

    for (var i = 1; i <= 12; i++) {
        daysInMonth[i] = 31
        if (i == 4 || i == 6 || i == 9 || i == 11) { daysInMonth[i] = 30 }
        if (i == 2) { daysInMonth[i] = 29 }
    }
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
        if (dt.type != "hidden" && dt.style.display != "none" && !dt.disabled) //Checking this Condition while focus, Nataraj on 09.09.2011
        {
            dt.focus();
        }
        return false;
    }
    return true
}

function NumberToDecimal(obj, val) {
    var finalValue = val; //parseFloat(val).toFixed(2);
    if (isNaN(finalValue)) {
        document.getElementById(obj).value = "";
    }
    else {
        document.getElementById(obj).value = finalValue;
    }
}
function PopupCenter(pageURL, w, h) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    var targetWin = window.open(pageURL, '', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

}


var ScrollWidth = 15;
function getScrollBarWidth() {
    var inner = document.createElement('p');
    inner.style.width = '100%';
    inner.style.height = '200px';

    var outer = document.createElement('div');
    outer.style.position = 'absolute';
    outer.style.top = '0px';
    outer.style.left = '0px';
    outer.style.visibility = 'hidden';
    outer.style.width = '200px';
    outer.style.height = '150px';
    outer.style.overflow = 'hidden';
    outer.appendChild(inner);

    document.body.appendChild(outer);
    var w1 = inner.offsetWidth;
    outer.style.overflow = 'scroll';
    var w2 = inner.offsetWidth;
    if (w1 == w2)
        w2 = outer.clientWidth;

    document.body.removeChild(outer);
    var ww = Number(w2);
    var ww2 = Number(w1);
    ScrollWidth = Number(ww2 - ww);
}
function SetWidth(divObj) {
    try {
        var aWidth = divObj.offsetWidth;
        if (navigator.appName == "Microsoft Internet Explorer") {
            divObj.style.width = Number(aWidth) - 15 + "px";
            //ScrollWidth = Number(ScrollWidth)+2; //for testing
        }
        else {
            divObj.style.width = Number(aWidth) - 9 + "px";
            //ScrollWidth = Number(ScrollWidth); //for testing
        }

        //divObj.style.width = Number(aWidth) - Number(ScrollWidth)+"px"; //for testing by vinay
    } catch (err) {

    }
}

function MakeDivMiddle(DivObj) {
    try {
        var divWidth = Number(DivObj.style.width.replace('px', ''));
        var divHeight = Number(DivObj.style.height.replace('px', ''));

        var availWidth = Number(window.screen.availWidth);
        var availHeight = Number(window.screen.availHeight);

        var NewLeft = Number(availWidth - divWidth) / 2;  //2
        var NewTop = Number(availHeight - divHeight) / 3; //3

        DivObj.style.left = NewLeft + "px";
        DivObj.style.top = NewTop + "px";
    }
    catch (err) {
    }
}

/*SCROLLABLE GRID*/
function start(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID) {
    if (GridID != '') {
        OuterDivID.style.display = "none";
        var t = GridID;
        if (t != null) {
            var t2 = t.cloneNode(true)
            for (i = t2.rows.length - 1; i > 0; i--)
                t2.deleteRow(i)
            t.deleteRow(0)
            div_HeaderID.appendChild(t2);

            if (t.rows.length < 19) {
                div_BodyID.style.overflowY = "auto";
                DivTotalRecID.style.paddingRight = "5px";
            }
            else {
                DivTotalRecID.style.paddingRight = "28px";
                var divObj = div_HeaderID;
                var aWidth = divObj.offsetWidth;
                //SetWidth(divObj);
                div = t.parentNode;
                if (div.tagName == "DIV") {
                    div.className = "WrapperDiv";
                    div.style.overflowY = "scroll";

                    OuterDivID.style.display = "block";
                    var OuterDivWidth = OuterDivID.offsetWidth;
                    var InnerDivWidth = InnerDivID.offsetWidth;
                    //alert("Number(OneDiv)"+document.getElementById("div_test_1").offsetHeight);
                    var MinusThisWidth = Number(OuterDivWidth) - Number(InnerDivWidth);

                    if (aWidth != '') {
                        div_HeaderID.style.width = Number(aWidth) - Number(MinusThisWidth - 1) + "px";
                        div_BodyID.style.width = Number(aWidth - 1) + "px";
                    }
                    OuterDivID.style.display = "none";
                }

                //            if(navigator.appName=="Microsoft Internet Explorer")
                //            {
                //              //document.getElementById("a").style.width="100%";
                //              document.getElementById("a").style.width = (div.offsetWidth) - 14 + "px" ;
                //            }
                //            else
                //            {
                //              //document.getElementById("a").style.width=Number(aWidth)-14+"px";
                //              document.getElementById("a").style.width = (div.offsetWidth) - 14 + "px" ;
                //            }
                //            document.getElementById("div_Grid").style.overflowY="scroll";             
            }
            div_BodyID.style.display = "block";
        }
    }
}
/*SCROLLABLE GRID*/
/*SCROLLABLE GRID Settings*/
function startset(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID) {
    if (GridID != '') {
        OuterDivID.style.display = "none";
        var t = GridID;
        var t2 = t.cloneNode(true)
        for (i = t2.rows.length - 1; i > 0; i--)
            t2.deleteRow(i)
        t.deleteRow(0)
        div_HeaderID.appendChild(t2);

        if (t.rows.length < 20) {
            OuterDivID.style.display = "none";
            div_BodyID.style.overflowY = "auto";
            DivTotalRecID.style.paddingRight = "5px";
        }
        else {
            var divObj = div_HeaderID;
            var aWidth = divObj.offsetWidth;
            //SetWidth(divObj);

            div = t.parentNode;
            if (div.tagName == "DIV") {
                div.className = "WrapperDiv";
                div.style.overflowY = "scroll";

                OuterDivID.style.display = "block";
                var OuterDivWidth = OuterDivID.offsetWidth;
                var InnerDivWidth = InnerDivID.offsetWidth;
                //alert("Number(OneDiv)"+document.getElementById("div_test_1").offsetHeight);
                var MinusThisWidth = Number(OuterDivWidth) - Number(InnerDivWidth);
                DivTotalRecID.style.paddingRight = Number(MinusThisWidth) + "px";

                if (aWidth != '') {
                    if (navigator.appName == "Microsoft Internet Explorer") {
                        div_HeaderID.style.width = Number(aWidth) + "px";
                    }
                    else {
                        div_HeaderID.style.width = Number(aWidth) - Number(MinusThisWidth - 1) + "px";
                        div_BodyID.style.width = Number(aWidth) + "px";
                    }
                }
                OuterDivID.style.display = "none";
            }

            //            if(navigator.appName=="Microsoft Internet Explorer")
            //            {
            //              //document.getElementById("a").style.width="100%";
            //              document.getElementById("a").style.width = (div.offsetWidth) - 14 + "px" ;
            //            }
            //            else
            //            {
            //              //document.getElementById("a").style.width=Number(aWidth)-14+"px";
            //              document.getElementById("a").style.width = (div.offsetWidth) - 14 + "px" ;
            //            }
            //            document.getElementById("div_Grid").style.overflowY="scroll";             
        }
        div_BodyID.style.display = "block";
    }
}
//** Func to make grid overflow hidden when In the Update Panel **//  
function CheckGridOverflow() {
    clsTimeID = setInterval("CheckForDataOverflow()", 2000);
}
function CheckForDataOverflow() {

    if (hidGridCount.value != '') {
        clearInterval(clsTimeID);
        CallOverflow();
    }

    if (TakeTimaeCount > 20) {
        clearInterval(clsTimeID);
        CallOverflow();
    }
    TakeTimaeCount++;
}

//** Func to make grid scroll when In the Update Panel **//  
/*SCROLLABLE GRID Settings*/

//** Func to make grid scroll when In the Update Panel **//  
function CheckGrid() {
    clsTimeID = setInterval("CheckFor1min()", 800);
}
function CheckFor1min() {
    if (hidGridCount.value != '') {
        ///alert('CheckFor1min');
        clearInterval(clsTimeID);
        CallScroll();
    }
    TakeTimaeCount++;

    if (TakeTimaeCount > 20) {
        clearInterval(clsTimeID);
    }
}
//** Func to make grid scroll when In the Update Panel **//  
/*SCROLLABLE GRID Settings*/


function AmountTo2Decimal(obj, val) {
    if (val.substring(1, 0) != "-")//for NEGATIVE Values
    {
        if (!isNaN(val)) {
            obj.value = val;
            return true;
        }
        else {
            obj.value = '';
            obj.focus();
            return false;
        }
    }
    else {
        obj.value = '';
        obj.focus();
        return false;
    }
}

function TextArea_Increase(val) {
    Decrease(val);
    grow(val);
}
function grow(ID) {
    var textareaa = document.getElementById(ID);
    while (textareaa.scrollHeight > textareaa.clientHeight && !window.opera) {
        //textareaa.style.height='100%';  
        textareaa.rows += 1;
    }
}
function Decrease(val) {
    var textareaa = document.getElementById(val);
    while (textareaa.rows > 3) {
        textareaa.rows -= 1;
    }
    if (textareaa.rows == 1) {
        //textareaa.style.height='15px';
    }
}

function PaceInCenter(divID, divWidth, divHeight, type) {
    var centerWidth = (screen.width / 2) - (divWidth / 2);
    var centerHeight = (screen.height / 2) - (divHeight / 2);

    var DivObj = document.getElementById(divID);
    DivObj.style.top = centerHeight + "px";
    DivObj.style.left = centerWidth + "px";

    if (type == "open") {
        DivObj.style.display = "block";
    }
    else {
        DivObj.style.display = "none";
    }
}

/* function to overflow hidden in grid*/
function SetGridOverflow(gridID) {

    //alert("Hello");
    //gridID.style.tableLayout = "fixed";
    //document.getElementById('myTable').cellPadding = "15";
    //gridID.setAttribute("cellPadding","5px");
    //    try
    //    {
    if (gridID != null) {                                  // IE, on 28.09.2011
        var ths = gridID.getElementsByTagName("th");
        for (y = 0; y < ths.length; y++) {

            var th = ths.item(y);
            //var len = ths.item(y).width;

            th.className = "GridOverflowHidden";
        }

        var tds = gridID.getElementsByTagName("td");
        for (x = 0; x < tds.length; x++) {
            var td = tds.item(x);
            //            var divv = document.createElement("div");
            //            divv.style.float = "left";
            //            divv.style.paddingRight = "4px";
            //            divv.innerHTML = td.innerHTML;
            //            td.innerHTML = "";
            //            td.appendChild(divv);

            td.className = "GridOverflowHidden";
            //td.style.paddingRight = "3px";
            //td.style.border = "1px solid red";
        }
        // }
        //    catch(grError)
        //    {        
        //    }
    }


}

function SetGridOverflow1(gridID) {
    //alert(gridID +"DDD");

    //gridID.style.tableLayout = "fixed";
    //document.getElementById('myTable').cellPadding = "15";
    //gridID.setAttribute("cellPadding","5px");
    var ths = gridID.getElementsByTagName("th");

    for (y = 0; y < ths.length; y++) {

        var th = ths.item(y);
        //var len = ths.item(y).width;

        th.className = "GridOverflowHeader";

    }
    var tds = gridID.getElementsByTagName("td");
    for (x = 0; x < tds.length; x++) {
        var td = tds.item(x);
        //            var divv = document.createElement("div");
        //            divv.style.float = "left";
        //            divv.style.paddingRight = "4px";
        //            divv.innerHTML = td.innerHTML;
        //            td.innerHTML = "";
        //            td.appendChild(divv);

        td.className = "GridOverflowHidden";
        //td.style.paddingRight = "3px";
        //td.style.border = "1px solid red";
    }
}

//==Common Cancel btn event from settings ==//
function cancelClick(url) {
    window.location.href = url;
    return false;
}

//====================================================================
//====================================================================
//  VALID EMAIL START
//====================================================================
//====================================================================
/**
* DHTML email validation script. Courtesy of SmartWebby.com (http://www.smartwebby.com/dhtml/)
*/

function echeck(str) {
    //    var EmailExn = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    //var EmailExn = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var EmailExn = /^([a-zA-Z0-9_\.\-\&\!\#\$\%\*\+\=\-\/\?\`\~\{\|\}\;\'])+\@(([a-zA-Z0-9_\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
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
    //        //alert("Invalid E-mail ID")
    //        return false
    //    }

    //    if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
    //        //alert("Invalid E-mail ID")
    //        return false
    //    }

    //    if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
    //        //alert("Invalid E-mail ID")
    //        return false
    //    }

    //    if (str.indexOf(at, (lat + 1)) != -1) {
    //        //alert("Invalid E-mail ID")
    //        return false
    //    }

    //    if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
    //        //alert("Invalid E-mail ID")
    //        return false
    //    }

    //    if (str.indexOf(dot, (lat + 2)) == -1) {
    //        //alert("Invalid E-mail ID")
    //        return false
    //    }

    //    if (str.indexOf(" ") != -1) {
    //        //alert("Invalid E-mail ID")
    //        return false
    //    }

    //   return true
}

function ValidateEmail(txtVal, spnID, IsMandatory) {
    document.getElementById(spnID).style.display = "none";
    if (IsMandatory == "yes") {
        if ((txtVal == null) || (txtVal == "")) {
            alert("Please Enter your Email ID");
            document.getElementById(spnID).style.display = "block";
            //emailID.focus()
            return false
        }
    }
    if (echeck(txtVal) == false) {
        document.getElementById(spnID).innerHTML = EmailInvalidFormat;
        document.getElementById(spnID).style.display = "block";
        return false
    }
    return true
}

function showWaitMessage() {
    var IW = window.innerWidth ? window.innerWidth : document.body.clientWidth;
    var IH = self.outerheight;
    self.scrollTo(0, 0);
    if (document.all) {

        document.all.waitmessage.style.left = (IW - 300) / 2;
        //document.all.waitmessage.style.top=IH-100;//(IH-100)/2;\n" +
        document.all.waitmessage.style.visibility = 'visible';
        document.all.waitmessage.style.zIndex = 99;
    }
    else if (document.getElementById) {
        document.getElementById('waitmessage').style.visibility = 'visible';
        document.getElementById('waitmessage').style.zIndex = 99;

        var width = document.getElementById('waitmessage').style.width;
        var height = document.getElementById('waitmessage').style.height;
        width = width.replace('px', '');
        height = height.replace('px', '');

        document.getElementById('waitmessage').style.left = ((document.body.clientWidth - width) / 2) + "px";
        var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;

        document.getElementById('waitmessage').style.top = (top + (document.body.clientHeight - height) / 2) + "px";
        //alert(document.getElementById('waitmessage').style.top);
        var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
        var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight
        var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth


    }
    else {
        document.waitmessage.left = (IW - 300) / 2;
        document.waitmessage.visibility = 'show';
        document.waitmessage.zIndex = 99;
    }
}

//====================================================================
//====================================================================
//  VALID EMAIL  END
//====================================================================
//====================================================================

//Function to make Div Center.

function setLoadingPositionOfDivMove(divisionloading) {

    var width = divisionloading.style.width;
    var height = divisionloading.style.height;
    width = width.replace('px', '');
    height = height.replace('px', '');

    //document.getElementById("ds00").style.display = "none";

    divisionloading.style.left = ((document.body.clientWidth - width) / 2) + "px";

    var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;
    divisionloading.style.top = (top + (document.body.clientHeight - height) / 2) + "px";
    divisionloading.style.display = 'block';
    //divisionloading.style.top = (top + 200) + "px";


    var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
    var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight
    var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth


}


function setTaskPopUpCenter(divisionloading) {
    var width = divisionloading.style.width;
    var height = divisionloading.style.minHeight;

    width = width.replace('px', '');
    height = height.replace('px', '');

    divisionloading.style.left = ((document.body.clientWidth - width) / 2) + "px";

    var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;
    divisionloading.style.top = (top + (document.body.clientHeight - height) / 2) + "px";

    //divisionloading.style.top = (top + 200) + "px";
    var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
    var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight
    var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth


}



function Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Amount, Scale, CalculationUnit, IsQuantity, isAddDecimalPlacesToQty, isView) {
    if (CalculationUnit == "ForBooklet") {
        var strNoOfSignature = Amount.toString();
        var realpart = '';
        var abc = "undefined";
        var requiredvalue = '';
        if (strNoOfSignature != Infinity && strNoOfSignature != isNaN) {
            realpart = strNoOfSignature.split('.');
            if (realpart[1] != null || realpart[1] != abc) {
                if (Number(realpart[1]) > 0 && realpart[1] != isNaN) {
                    //requiredvalue = strNoOfSignature.substring(0, strNoOfSignature.indexOf('.') + 2);

                    requiredvalue = roundNumber_new(strNoOfSignature, Scale);
                }
                else {
                    requiredvalue = realpart[0];
                }
            }
        }
        else if (strNoOfSignature == isNaN) {
            requiredvalue = strNoOfSignature;
        }
        else {
            requiredvalue = 0;
        }
        return requiredvalue;
    }
    else {
        var settingScale = roundoff;
        if (Scale > 0) {
            settingScale = Scale;
        }
        if (IsQuantity && !isAddDecimalPlacesToQty) {
            return roundNumber_new(Amount, 0);
        }
        return roundNumber_new(Amount, settingScale);
    }
}


/* Return currency in $ 223,000.00 formate (thousands separator) */
function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' +
num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + '$' + num + '.' + cents);
}
/* Return currency in $ 223,000.00 formate (thousands separator) */

//alert(formatCurrency('724565.5688'));


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

//function roundNumber_new(number, decimals) {
//    var newString; // The new rounded number
//    decimals = Number(decimals);
//    if (decimals < 1) {
//        newString = (Math.round(number)).toString();
//    } else {
//        var numString = number.toString();
//        if (numString.lastIndexOf(".") == -1) {// If there is no decimal point
//            numString += "."; // give it one at the end
//        }
//        var cutoff = numString.lastIndexOf(".") + decimals; // The point at which to truncate the number
//        var d1 = Number(numString.substring(cutoff, cutoff + 1)); // The value of the last decimal place that we'll end up with
//        var d2 = Number(numString.substring(cutoff + 1, cutoff + 2)); // The next decimal, after the last one we want
//        if (d2 >= 5) {// Do we need to round up at all? If not, the string will just be truncated
//            if (d1 == 9 && cutoff > 0) {// If the last digit is 9, find a new cutoff point
//                while (cutoff > 0 && (d1 == 9 || isNaN(d1))) {
//                    if (d1 != ".") {
//                        cutoff -= 1;
//                        d1 = Number(numString.substring(cutoff, cutoff + 1));
//                    } else {
//                        cutoff -= 1;
//                    }
//                }
//            }
//            d1 += 1;
//        }
//        if (d1 == 10) {
//            numString = numString.substring(0, numString.lastIndexOf("."));
//            var roundedNum = Number(numString) + 1;
//            newString = roundedNum.toString() + '.';
//        } else {
//            newString = numString.substring(0, cutoff) + d1.toString();
//        }
//    }
//    if (newString.lastIndexOf(".") == -1) {// Do this again, to the new string
//        newString += ".";
//    }
//    var decs = (newString.substring(newString.lastIndexOf(".") + 1)).length;
//    for (var i = 0; i < decimals - decs; i++) newString += "0";
//    //var newNumber = Number(newString);// make it a number if you like
//    //document.roundform.roundedfield.value = newString; // Output the result to the form field (change for your purposes)


//    //alert(newString.lastIndexOf("."));
//    //alert(newString.length);
//    if (newString.lastIndexOf(".") == newString.length - 1) {
//        newString = newString.substring(0, newString.lastIndexOf("."));
//    }

//    return newString;
//}
function todecimal_function(txtobj) {
    debugger;
    var value = RemoveDollorAndComma(txtobj.value); // Changed by Pradeep -- called RemoveDollorAndComma()
    if (!isNaN(value) && Number(value)) {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, value, 0, '', false, false, false);
    }
    else {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 0, '', false, false, false);
    }
    //  alert('value = ' + txtobj.value);
}

function todecimal_functionNew(txtobj, Value, DeciNumber) {
    debugger;
    var value = txtobj.value;
    var DecNumber = Number(DeciNumber);
    txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtobj.value, DecNumber, '', false, false, false);
}

function Eprint_GetminimumCost_ComparedtoCostwithMarkup(costprice, markup, minimumcost, customcol1, customcol2, SetupCharge) {
    var totalcost = 0;
    var returncost = 0;
    totalcost = Number(costprice) + ((Number(costprice) * Number(markup)) / 100) + Number(SetupCharge);
    if (Number(minimumcost) >= Number(totalcost)) {
        returncost = Number(minimumcost);
    }
    else {
        returncost = Number(totalcost);
    }
    return returncost;
}

// For OtherCost if MinimunCost 0 (Zero) as  not Considering 
function Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(costprice, markup, minimumcost, customcol1, customcol2, SetupCharge) {
    var totalcost = 0;
    var returncost = 0;
    totalcost = Number(costprice) + ((Number(costprice) * Number(markup)) / 100) + Number(SetupCharge);
    if (minimumcost != 0) {
        if (Number(minimumcost) >= Number(totalcost)) {
            returncost = Number(minimumcost);
        }
        else {
            returncost = Number(totalcost);
        }
    } else {
        returncost = Number(totalcost);
    }
    return returncost;
}
//for New telerik popup(activity history) from summary page
function setLoadingPositionOfDivCenter() {
    if (objdivision) {
        var divisionloading = document.getElementById(objdivision);
        divisionloading.style.left = ((document.body.clientWidth - divisionloading.offsetWidth) / 1.97) + "px";
        var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;

        divisionloading.style.top = (top + divFromTopPos) + "px";

        //new
        //divisionloading.style.top = (divFromTopPos)+(document.body.clientHeight / 30) + "px";
        //divisionloading.style.left = (document.body.clientWidth / 3) + "px";

        var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
        var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight// standardbody.clientHeight;
        var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth// standardbody.clientWidth;
        var DivBack = document.getElementById("divBackGroundNew");
        DivBack.style.left = "0px"
        DivBack.style.width = docwidthcomplete + "px";
        DivBack.style.height = docheightcomplete + "px";
        DivBack.style.top = "0px";
    }
}

function showDivPopupCenter(divId, divHeight) {
    var centerHeight = screen.height / 2.1;
    divFromTopPos = centerHeight - divHeight;
    var objCategoryDiv = document.getElementById(divId);
    objdivision = divId;
    objCategoryDiv.style.display = "block";
    document.getElementById("divBackGroundNew").style.display = "block";
    addFunction(window, 'scroll', setLoadingPositionOfDivCenter);
    setLoadingPositionOfDivCenter();
}

function Show_accountListDiv() {
    showDivPopupCenter('div_accountsList', '200');
    ShowPopUp();
    RadWinClose();
}
function Show_EmailaccountListDiv() {
    var Counter = 0;
    var frm = document.forms[0];
    var IDs = '';
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
            if (e.checked) {
                Counter = Number(Counter) + 1;
                IDs = IDs + e.value + ",";
            }
        }
    }
    if (Number(Counter) == 0) {
        alert("Please check at least one row to allocate");
        return false;
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_hid_Allocate_IDs").value = IDs;
        showDivPopupCenter_Cart('div_CopyAccounts', '220');
        ShowPopUpShoppingCart();
        RadWindowclose();
    }
}

function showDivPopupCenter_Cart(divId, divHeight) {
    var centerHeight = screen.height / 2.1;
    divFromTopPos = centerHeight - divHeight;
    var objCategoryDiv = document.getElementById(divId);
    objdivision = divId;
    objCategoryDiv.style.display = "block";
    //document.getElementById("ctl00_ContentPlaceHolder1_ctl01_Div1").style.display = "block"; 
    document.getElementById("ctl00_ContentPlaceHolder1_ctl01_RadWindowShoppingCart_C_Div1").style.display = "block";
    document.getElementById("div_CustomerList").style.display = "block";
    document.getElementById("divBackGroundNew").style.display = "block";
    addFunction(window, 'scroll', setLoadingPositionOfDivCenter);
    setLoadingPositionOfDivCenter();
}

function showDivPopupCenterWithoutBlur(divId, divHeight) {
    var centerHeight = screen.height / 2.1;
    divFromTopPos = centerHeight - divHeight;
    var objCategoryDiv = document.getElementById(divId);
    objdivision = divId;
    objCategoryDiv.style.display = "block";
    addFunction(window, 'scroll', setLoadingPositionOfDivCenter);
    setLoadingPositionOfDivCenter();
}

function addFunction(eventObject, eventFiresOn, eventFunction) {
    if (eventObject.addEventListener) eventObject.addEventListener(eventFiresOn, eventFunction, false); else if (eventObject.attachEvent) eventObject.attachEvent('on' + eventFiresOn, eventFunction);
}


// Popup Version-2 Masking for AccountCode, by Natraj...
function setLoadingPositionOfDivCenter_Ver2() {
    var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
    var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight// standardbody.clientHeight;
    var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth// standardbody.clientWidth;
    var DivBack = document.getElementById("divBackGroundNew");
    DivBack.style.left = "0px"
    DivBack.style.width = docwidthcomplete + "px";
    DivBack.style.height = docheightcomplete + "px";
    DivBack.style.top = "0px";
}
function showDivPopupCenter_Ver2(divId, divHeight) {
    var centerHeight = screen.height / 2.1;
    divFromTopPos = centerHeight - divHeight;
    var objCategoryDiv = document.getElementById(divId);
    objdivision = divId;
    objCategoryDiv.style.display = "block";
    document.getElementById("divBackGroundNew").style.display = "block";
    addFunction(window, 'scroll', setLoadingPositionOfDivCenter_Ver2);
    setLoadingPositionOfDivCenter_Ver2();
}
//end



function showDivPopupCenter_ForOthercost(divId, divHeight) {
    var centerHeight = screen.height / 2.1;
    divFromTopPos = centerHeight - divHeight;
    var objCategoryDiv = document.getElementById(divId);
    objdivision = divId;
    objCategoryDiv.style.display = "block";
    document.getElementById("divBackGroundNew").style.display = "block";
    addFunction(window, 'scroll', setLoadingPositionOfDivCenter_ForOthercost);
    setLoadingPositionOfDivCenter_ForOthercost();
}

function setLoadingPositionOfDivCenter_ForOthercost() {
    var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
    var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight// standardbody.clientHeight;
    var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth// standardbody.clientWidth;
    var DivBack = document.getElementById("divBackGroundNew");
    DivBack.style.left = "0px"
    DivBack.style.width = docwidthcomplete + "px";
    DivBack.style.height = docheightcomplete + "px";
    DivBack.style.top = "0px";
}

//function hidemask(divmaskid, divbackgroundid) {

//    var divrad = document.getelementbyid(divmaskid);
//    var divbackgroundnew = document.getelementbyid(divbackgroundid);

//    // document.getelementbyid("ds00").style.display = "none";
//    divrad.style.display = "none";
//    divbackgroundnew.style.display = "none";
//}
function RadWinClose() {
    document.getElementById("divrad").style.display = "none";
    document.getElementById("divBackGroundNew").style.display = "none";
}


function SetRadWindow(divMaskID, divBackgroundID, divHeight) {
    var divrad = document.getElementById(divMaskID);
    var divBackGroundNew = document.getElementById(divBackgroundID);

    if (document.getElementById(divMaskID).style.display == "none") {
        if (navigator.appName != "Microsoft Internet Explorer") {     //IE on 26.09.2011
            setLoadingPositionOfDivMove(divrad);
        }
        showDivPopupCenter(divMaskID, '200');
    }
    else {
        document.getElementById(divMaskID).style.display = "none";
        divBackGroundNew.style.display = "none";
    }
}



//-- Donot Modify SetNumber_OfUnit() Used for Unit Of Measure --//
function SetNumber_OfUnit(obj, val) {
    if (trim12(val) != '') {
        if (val.substring(1, 0) != "-")//for NEGATIVE Values
        {
            if (!isNaN(val)) {
                if (val > 0) {
                    val = val;
                }
                else {
                    obj.value = '1000';
                }
                return true;
            }
            else {
                obj.value = '1000';
                return false;
            }
        }
        else {
            obj.value = '1000';
            return false;
        }
    }
    else {
        obj.value = '1000';
        return false;
    }
}
//-- Donot Modify SetNumber_OfUnit() Used for Unit Of Measure --//

//-- Press Enter Trigger Event for Search on 31-01-2012 by Shivappa --//

function KeyDownHandler(e, btn) {
    var eventInstance = e || window.event;

    if (window.event) // IE
    {
        if (eventInstance.keyCode == 13) {

            eventInstance.returnValue = false;
            eventInstance.cancel = true;
            var obj = document.getElementById(btn);
            obj.click();
            return false;
        }
    }
    else if (eventInstance.which) // Netscape/Firefox/Opera
    {
        if (eventInstance.which == 13) {

            eventInstance.returnValue = false;
            eventInstance.preventDefault();
            eventInstance.cancelBubble = true;
            var obj = document.getElementById(btn);
            obj.click();
            return false;
        }
    }
}
//--End of Press Enter Trigger Event for Search on 31-01-2012 by Shivappa //--


function RemoveDollorAndComma(Values_data) {
    //var val = Values_data.replace('$', '');

    var val1 = GetCurrencyinRequiredFormate("", true);
    var val = Values_data.replace(val1, '');
    val = val.replace(/,/, '').replace(/,/, '');
    val = val.replace(/,/, '').replace(/,/, '');

    return val;
}

// for UK client


function GetCurrencyinRequiredFormate(Amount, isSignRequired) {
    return jsCurrencySymbol + Amount;
}
function GetCurrencyFromRequiredFormatetoBack(Amount) {
    return Amount.replace(jsCurrencySymbol, '');
}




// Return current window's FCKEditor's ID
function GetEditorID_Parent() {

    var formXYZ = document.getElementById("aspnetForm");
    var EditorID = '';
    var filedsinthosform = '';

    if (formXYZ == null) {
        formXYZ = document.getElementById("form1");
    }

    filedsinthosform = formXYZ.getElementsByTagName('input');

    for (var i = 0; i < filedsinthosform.length; i++) {
        if (filedsinthosform[i].type == 'hidden' && filedsinthosform[i].id.indexOf('___Config') != -1) {
            EditorID = filedsinthosform[i].id.replace('___Config', '');
        }
    }

    return EditorID;
}

// Return parent window's FCKEditor's ID
function GetEditorID_Popup() {
    var pw = window.opener.parent;
    var formXYZ = pw.document.getElementById("aspnetForm");
    var EditorID = '';
    var filedsinthosform = '';

    if (formXYZ == null) {
        formXYZ = window.opener.parent.document.getElementById("form1");
    }
    if (formXYZ == null) {
        formXYZ = window.parent.document.getElementById("form1");
    }

    filedsinthosform = formXYZ.getElementsByTagName('input');

    for (var i = 0; i < filedsinthosform.length; i++) {
        if (filedsinthosform[i].type == 'hidden' && filedsinthosform[i].id.indexOf('___Config') != -1) {
            EditorID = filedsinthosform[i].id.replace('___Config', '');
        }
    }

    return EditorID;
}
function LargeInTwoNumbers(a, b) {

    if (a >= b) {
        return a;
    }
    else {
        return b;
    }
}
function SmallInTwoNumbers(a, b) {

    if (a <= b) {
        return a;
    }
    else {
        return b;
    }
}

function Pdf_Open(FileName, AccountID) {
    //window.open(strSitepath + "document/store/" + AccountID + "/Pdf/" + FileName, '_blank');
    window.open(strSecuresitepath + ServerName + "/store/" + AccountID + "/Pdf/" + FileName, '_blank');
}

function PrintReady_Open(FileName, CompanyID) {
    // window.open(strSitepath + "document/" + CompanyID + "/" + FileName, '_blank');
    window.open(strSecuresitepath + ServerName + "/" + CompanyID + "/Product/PrintReady/" + FileName, '_blank');
}

//Created On 10-05-2013 by Pradeep : To Replace single and Double Quotes
function SpecialEncode(OriginalString) {
    OriginalString = OriginalString.split("'").join('%27');
    OriginalString = OriginalString.split('"').join('%22');
    return OriginalString;
}
function SpecialDecode(OriginalString) {
    if (typeof OriginalString !== 'undefined' && OriginalString !== null)
    {
        OriginalString = OriginalString.split('%27').join("'");
        OriginalString = OriginalString.split('%22').join('"');
    }    
    return OriginalString;
}
//end By pradeep

function todecimal_functionwithfourdecimal(txtobj) {
    debugger;

    // Step 1: Get and clean the input value (remove commas)
    var value = txtobj.value.replace(/,/g, '').trim();

    // Step 2: Check if it's a valid number
    if (!isNaN(value) && value !== '') {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, value, 4, '', false, false, false);
    } else {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 4, '', false, false, false);
    }
}


function Emailvalidate() {
    var accEmail = 0;
    for (i = 0; i < lst_EmailaccountsList.options.length; i++) {
        if (lst_EmailaccountsList.options[i].selected) {
            if (hdn_lst_EmailaccountsList.value == 0) {
                hdn_lst_EmailaccountsList.value = lst_EmailaccountsList.options[i].value;
            } else {
                hdn_lst_EmailaccountsList.value += ',' + lst_EmailaccountsList.options[i].value;
            }
            accEmail++;
        }
    }

    if (accEmail == 0 || Number(hdn_lst_EmailaccountsList.value) == 0 || hdn_lst_EmailaccountsList.value=='') {
        alert('Please select at least one from Private/Public account');
        return false;
    }
    else {
        setTimeout("LoadingImgStart()", 0);
        setTimeout("LoadingImgEnd()", 2000);
        document.cookie = "ProductCatagory=Yes";
        return true;
    }
}
var CheckFinal = false;
function Validate() {
    var StoreUserID = '<%=StoreUserID %>';
    var action = '<%=action %>';
    txt_ContactEmail.value = document.getElementById("ctl00_ContentPlaceHolder1_UCContact_txt_ContactEmail").value;
    //CheckFinal = false;
    if (txtFirstName.value == "" || txtFirstName.value.trim() == "") {
        document.getElementById("spnFirstName").style.display = "block";
        //CheckFinal = true;
        return false;
    }

    if (hdnClientID.value == "") {
        alert('Please select any company name');
        document.getElementById("<%=txtCompanyName.ClientID %>").focus();
        //CheckFinal = true;
    }
    if (txt_ContactEmail.value != "") {
        if (!ValidateEmail(txt_ContactEmail.value, 'spn_txtEmailExp', 'no')) {
            return false;
        }
    }


    if (chkB2bLogin.checked || chkB2bLoginChngPass.checked) {

        if (div_PasswordArea.style.display != 'none') {
            if (txtPassword.value == "") {
                document.getElementById("spnPassword").style.display = "block";
                document.getElementById("spnConfirmPassword").style.display = "none";
                document.getElementById("spnValidPassword").style.display = "none";
                // CheckFinal = true;
                return false;
            }
            if (txtPassword.value != "" && txtConfirmPassword.value == "") {
                document.getElementById("spnPassword").style.display = "none";
                document.getElementById("spnConfirmPassword").style.display = "block";
                document.getElementById("spnValidPassword").style.display = "none";
                return false;
            }
            if (txtPassword.value != txtConfirmPassword.value) {

                document.getElementById("spnValidPassword").style.display = "block";
                document.getElementById("spnConfirmPassword").style.display = "none";
                //CheckFinal = true;
                return false;
            }

        }

        if (txt_ContactEmail.value == "") {
            //CheckFinal = true;
            document.getElementById("spn_txtEmail").style.display = "block";
        }
        else {
            if (!ValidateEmail(txt_ContactEmail.value, 'spn_txtEmailExp', 'no')) {
                return false;
            }
            checkEmilDuplicacynew(txt_ContactEmail.value);
            if (ChkEmailDuplicacy) {
                //CheckFinal = true;
            }
        }
    }
    if (txt_ContactEmail.value != "") {
        checkEmilDuplicacynew(txt_ContactEmail.value);
        if (!ChkEmailDuplicacy) {
            //CheckFinal = false;
            return true;
        }
        else {
            //CheckFinal = true;
            return false;
        }
    }

    if (StoreUserID != 0) {
        if (txt_ContactEmail.value == "") {
            checkEmilDuplicacynew(txt_ContactEmail.value);
            if (ChkEmailDuplicacy) {
                //CheckFinal = true;
            }
        }
    }
    if (CheckFinal) {
        return false;
    }
    else {
        document.getElementById("divOverLayer").style.display = "block";
        return true;
    }

}

//===================For auot job alert====================================
function hidetype() {
    // email('block');
    //document.getElementById("Td71").style.background = '#F3F3F3';
    // document.getElementById("Td81").style.background = '#F3F3F3';
}
function desableAfterLoad() {
    window.document.getElementById("div_Load").style.display = "none";
}
function displayAddNew() {
    document.getElementById('tdaddnew').style.display = 'block';
}

function pageScroll() {
    window.scrollBy(0, 600); // horizontal and vertical scroll increments
}

function addnew(type) {
    debugger;
    document.getElementById('div_Load').style.display = 'block';
    pageScroll();
    setTimeout("displayAddNew()", 3000);
    setTimeout("desableAfterLoad()", 4000);


    var txtSubject = document.getElementById("ctl00_header1_txtSubject");
    var ddlSignature = document.getElementById("ctl00_ContentPlaceHolder1_ddlSignature");
    var txt_cc = document.getElementById("ctl00_ContentPlaceHolder1_txt_cc");
    var txt_bcc = document.getElementById("ctl00_ContentPlaceHolder1_txt_bcc");
    //var ddlStatus = document.getElementById("<%=ddlStatus.ClientID %>");
    var ddlStatus = document.getElementById("ctl00_ContentPlaceHolder1_ddlStatus")
   // BindSignature();
    var Radeditor = document.getElementById("ctl00_ContentPlaceHolder1_RadEditor1");
    var chkEnabled = document.getElementById("ctl00_ContentPlaceHolder1_chkEnabled");
    ddlStatus.focus();
    document.getElementById("ctl00_ContentPlaceHolder1_hdntypesave").value = type;
    if (type == 'add') {
        txtSubject.value = "";
        ddlSignature.selectedIndex = "0";
        ddlStatus.selectedIndex = "0";
        txt_cc.value = "";
        txt_bcc.value = "";
        chkEnabled.checked = false;
        var editor = document.getElementById("ctl00_ContentPlaceHolder1_RadEditor1");
        editor.set_html("");
        //changefck("");

    }
    else {
        return true;
    }

}
function CallDelete() {
    var ret = CheckOne();
    if (ret) {
        CheckGrid();
        return true;
    }
    else {
        return false;
    }
}
function checkAll_new_emailrecords(checkAllBox_emailbody) {
    var frm = document.forms[0];
    var ChkState = checkAllBox_emailbody.checked;

    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('chkEmailBodyId1') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
    }
}
function show() {
    img_actionsHide.style.display = "block";
    img_actionsShow.style.display = "none";

    div_chk.style.border = "inset 1px";
    div_chk.style.background = "#CBCBCB";

    div_popupAction.style.display = "block";
}
function hide() {
    img_actionsHide.style.display = "none";
    img_actionsShow.style.display = "block";

    div_chk.style.border = "outset 1px";
    div_chk.style.background = "";

    div_popupAction.style.display = "none";
}
function CheckOne_new_emailbody() {
    var frm = document.forms[0];
    var IDs = '';
    if (window.confirm("Are you sur you want to delete this items?") == false) {
        return false;
    }
    else {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkEmailBodyId1') != -1) {
                if (!e.disabled) {
                    if (e.checked) {
                        //Counter_costcenter = Number(Counter_Address) + 1;
                        IDs = IDs + frm[i].value + ",";
                    }
                }
            }
        }
        document.getElementById("ctl00_ContentPlaceHolder1_hdnEmailIdMultiple").value = IDs;

    }
}

function ImgButtonErase_ClientClick(GridID, ImageButtonID) {
    if (confirm("Delete this Auto Job Alert?")) {

        return true;
    }
    else {
        return false;
    }
}
function ValidateMultiEmail(value, spnid) {

    document.getElementById(spnid).style.display = "none";
    if (value == '') {
        if (spnid == 'Spn_ErrMsgCC') {
            document.getElementById(spnid).innerHTML = "Please enter email address";
            document.getElementById(spnid).style.display = "block";
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
            var email = result[i].trim().replace(',', '');
            if (!validateEmail(email)) {
                document.getElementById(spnid).innerHTML = "Please enter valid email address";
                document.getElementById(spnid).style.display = "block";
                chkvalidate = 'false';
            }
            else {
                chkvalidate = 'true';
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

function paletteOpen(fieldName) {
    document.forms[0]['hiddenid'].value = fieldName;
    var paletteField;
    paletteField = fieldName;
    palette = window.open("", "paletteWindow", "toolbar=0,location=0,menubar=0,scrollbars=0,resizable=0,width=300,height=200,top=300,left=500");
    palette.location.href = strSitepath + "settings/color_picker.html";
    palette.focus();
    return false;
}

function colorFieldFill(color) {
    var hid = document.forms[0]['hiddenid'].value;
    eval("document.getElementById('ctl00_ContentPlaceHolder1_" + hid + "').value='" + color + "'");
    document.getElementById(hid + "_div").style.background = color;
}

function IntergerValidation(evt) {
    var charCode = (evt.which) ? evt.which : window.event.keyCode;

    if (charCode <= 13) {
        return true;
    }
    else {
        var keyChar = String.fromCharCode(charCode);
        //var re = /[a-zA-Z0-9@#$%&*!~^_()?,.{}<>]/
        var re = /[0-9.]/
        return re.test(keyChar);
    }
}
//For Call and task event report
function EnableCallDateOption() {
    var chkDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkDateOption");
    var rdlDateArray = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
    var txtFrom = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtFrom");
    var txtTo = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtTo");
    if (chkDateOption.checked) {
        for (var i = 0; i < rdlDateArray.length; i++) {
            rdlDateArray.disabled = false;
        }
    }
    else {
        for (var i = 0; i < rdlDateArray.length; i++) {
            rdlDateArray.disabled = true;
            txtFrom.disabled = true;
            txtTo.disabled = true;
        }
    }
}

function GetCallDropdownBind() {

    var txtFrom = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtFrom");
    var txtTo = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtTo");
    var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_daily");

    var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_yest");
    var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month");
    var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_quarter");
    var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastque");
    var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek");
    var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth");
    var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear");
    var spndlDate_AnnualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spndlDate_AnnualYear");




    var ddlCallCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
    var divcalldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divcalldate");
    var ddlvalue = ddlCallCreated.options[ddlCallCreated.selectedIndex].value;

    if (ddlvalue == "thisannualyear") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";

        divcalldate.style.display = "none";
        spndlDate_AnnualYear.style.display = "block";
        txtFrom.disabled = true;
        txtTo.disabled = true;
    }
    else if (ddlvalue == "daily") {
        spn_1.style.display = "block";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spndlDate_AnnualYear.style.display = "none";

        divcalldate.style.display = "none";
        txtFrom.disabled = true;
        txtTo.disabled = true;
    }
    else if (ddlvalue == "daterange") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        divcalldate.style.display = "block";
        spndlDate_AnnualYear.style.display = "none";
        txtFrom.disabled = false;
        txtTo.disabled = false;
    }
    else if (ddlvalue == "yesterday") {
        spn_1.style.display = "none";
        spn_2.style.display = "block";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spndlDate_AnnualYear.style.display = "none";

        divcalldate.style.display = "none";
        txtFrom.disabled = true;
        txtTo.disabled = true;
    }
    else if (ddlvalue == "thismonth") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "block";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spndlDate_AnnualYear.style.display = "none";

        divcalldate.style.display = "none";
        txtFrom.disabled = true;
        txtTo.disabled = true;
    }
    else if (ddlvalue == "thisquarter") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "block";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spndlDate_AnnualYear.style.display = "none";

        divcalldate.style.display = "none";
        txtFrom.disabled = true;
        txtTo.disabled = true;
    }
    else if (ddlvalue == "lastquater") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "block";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spndlDate_AnnualYear.style.display = "none";

        divcalldate.style.display = "none";
        txtFrom.disabled = true;
        txtTo.disabled = true;
    }
    else if (ddlvalue == "lastweek") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "block";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spndlDate_AnnualYear.style.display = "none";

        divcalldate.style.display = "none";
        txtFrom.disabled = true;
        txtTo.disabled = true;
    }
    else if (ddlvalue == "lastmonth") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "block";
        spn_8.style.display = "none";
        spndlDate_AnnualYear.style.display = "none";

        divcalldate.style.display = "none";
        txtFrom.disabled = true;
        txtTo.disabled = true;
    }
    else if (ddlvalue == "lastyear") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "block";
        spndlDate_AnnualYear.style.display = "none";

        divcalldate.style.display = "none";
        txtFrom.disabled = true;
        txtTo.disabled = true;
    }
}
function OnCallCheckShow() {
    var txtFrom = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtFrom");
    var txtTo = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtTo");
    var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_daily");

    var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_yest");
    var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month");
    var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_quarter");
    var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastque");
    var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek");
    var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth");
    var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear");


    var chkDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkDateOption");
    var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
    var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;
    if (chkDateOption.checked) {
        if (ddlvalue == "daily") {
            spn_1.style.display = "block";
        }
        else if (ddlvalue == "daterange") {
            txtFrom.disabled = false;
            txtTo.disabled = false;
        }

        else if (ddlvalue == "yesterday") {
            spn_1.style.display = "none";
            spn_2.style.display = "block";
            spn_3.style.display = "none";
            spn_4.style.display = "none";
            spn_5.style.display = "none";
            spn_6.style.display = "none";
            spn_7.style.display = "none";
            spn_8.style.display = "none";


            txtFrom.disabled = true;
            txtTo.disabled = true;
        }
        else if (ddlvalue == "thismonth") {
            spn_1.style.display = "none";
            spn_2.style.display = "none";
            spn_3.style.display = "block";
            spn_4.style.display = "none";
            spn_5.style.display = "none";
            spn_6.style.display = "none";
            spn_7.style.display = "none";
            spn_8.style.display = "none";

            txtFrom.disabled = true;
            txtTo.disabled = true;
        }
        else if (ddlvalue == "thisquarter") {
            spn_1.style.display = "none";
            spn_2.style.display = "none";
            spn_3.style.display = "none";
            spn_4.style.display = "block";
            spn_5.style.display = "none";
            spn_6.style.display = "none";
            spn_7.style.display = "none";
            spn_8.style.display = "none";

            txtFrom.disabled = true;
            txtTo.disabled = true;
        }
        else if (ddlvalue == "lastquater") {
            spn_1.style.display = "none";
            spn_2.style.display = "none";
            spn_3.style.display = "none";
            spn_4.style.display = "none";
            spn_5.style.display = "block";
            spn_6.style.display = "none";
            spn_7.style.display = "none";
            spn_8.style.display = "none";


            txtFrom.disabled = true;
            txtTo.disabled = true;
        }
        else if (ddlvalue == "lastweek") {
            spn_1.style.display = "none";
            spn_2.style.display = "none";
            spn_3.style.display = "none";
            spn_4.style.display = "none";
            spn_5.style.display = "none";
            spn_6.style.display = "block";
            spn_7.style.display = "none";
            spn_8.style.display = "none";


            txtFrom.disabled = true;
            txtTo.disabled = true;
        }
        else if (ddlvalue == "lastmonth") {
            spn_1.style.display = "none";
            spn_2.style.display = "none";
            spn_3.style.display = "none";
            spn_4.style.display = "none";
            spn_5.style.display = "none";
            spn_6.style.display = "none";
            spn_7.style.display = "block";
            spn_8.style.display = "none";


            txtFrom.disabled = true;
            txtTo.disabled = true;
        }
        else if (ddlvalue == "lastyear") {
            spn_1.style.display = "none";
            spn_2.style.display = "none";
            spn_3.style.display = "none";
            spn_4.style.display = "none";
            spn_5.style.display = "none";
            spn_6.style.display = "none";
            spn_7.style.display = "none";
            spn_8.style.display = "block";


            txtFrom.disabled = true;
            txtTo.disabled = true;
        }
    }

        
    else {
    spn_1.style.display = "none";
    spn_2.style.display = "none";
    spn_3.style.display = "none";
    spn_4.style.display = "none";
    spn_5.style.display = "none";
    spn_6.style.display = "none";
    spn_7.style.display = "none";
    spn_8.style.display = "none";
    }

}

function GetCallSelect() {
    var RB1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
    var radio = RB1.getElementsByTagName("input");
    var CHK1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns");
    var chk = CHK1.getElementsByTagName("input");
    var txtFrom = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtFrom");
    var txtTo = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtTo");
    var x = 0, y = 0;
    for (var i = 0; i < chk.length; i++) {
        if (chk[i].checked == true) {
            x++;
        }
    }

    if (x == chk.length) {
        lnkSelectAll.innerHTML = 'Select None';
    }
    else {
        lnkSelectAll.innerHTML = 'Select All';
    }

    for (var i = 0; i < radio.length; i++) {
        if (radio[i].checked) {
            if (radio[i].value == "daterange") {
                txtFrom.disabled = false;
                txtTo.disabled = false;
            }
            else {
                txtFrom.disabled = true;
                txtTo.disabled = true;
            }
        }
    }
    GetCallDropdownBind();
    EnableCallDateOption();
}

function OnEditCallReport() {

    GetCallDropdownBind();
    EnableCallDateOption();
}

var Check = false;
function Activity_ValidateSave() {
    Check = true;
    var count = 0;
    for (var j = 0; j < chkColumns.length; j++) {
        if (chkColumns[j].checked) {
            count++;
        }
    }
    if (count == 0) {
        Check = false;
    }
    var estno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
    if (estno.checked == false) {
        alert('Please check Company name to generate report');
        return false;
    }

    if (txtSaveReports.value == '') {
        alert('Please Enter Report Name');
        txtSaveReports.focus();
        Check = false;
    }

    if (Check) {
        return true;
    }
    else {
        return false;
    }
}

function ActivityValidateCaller() {
    if (!Activity_ValidateSave()) {
        return false;
    } else {
        document.getElementById("ds00").style.display = "block";
        document.getElementById("div_Load").style.display = "block";
        return true;
    }
    showWaitMessage();
}
function Activity_Runvalidate() {
    var estno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
    if (estno.checked == false) {
        alert('Please check Company name to generate report');
        return false;
    }
}

var txtSaveReports = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i3_txtSaveReports");
var div_showfilters = document.getElementById("ctl00_ContentPlaceHolder1_div_showfilters");
var divusrReportsave = document.getElementById("ctl00_ContentPlaceHolder1_divusrReportsave");

function Activity_Call_Report(liID) {
    if (document.getElementById(liID) != null) {
        document.getElementById(liID).style.color = "orange";
        for (var i = 1; i <= 2; i++) {
            var dd = "spn_" + i;
            if (dd != liID) {

                if (document.getElementById("spn_" + i) != null) {
                    document.getElementById("spn_" + i).style.color = "black";
                }
            }
            else {
            }
        }
        if (liID == 'spn_2' || liID == 'A2') {
            //divusrReportsave.style.display = 'none';
            //div_showfilters.style.display = 'block';
            document.getElementById("ctl00_ContentPlaceHolder1_divusrReportsave").style.display = 'none';
            document.getElementById("ctl00_ContentPlaceHolder1_div_showfilters").style.display = 'block';
        }
        else if (liID == "spn_1" || liID == 'A1') {
            //divusrReportsave.style.display = 'block';
            //div_showfilters.style.display = 'none';
            document.getElementById("ctl00_ContentPlaceHolder1_divusrReportsave").style.display = 'block';
            document.getElementById("ctl00_ContentPlaceHolder1_div_showfilters").style.display = 'none';
        }
    }
}
function Activity_getInnerHtml() {
    var element = document.getElementById("divexport1");
    document.getElementById('ctl00_ContentPlaceHolder1_hdnInnerHtml').value = element.innerHTML;
}

function GetJobDateBind_ddl() {

    var txtFromDate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtjobFrom");
    var txtToDate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtJobTo");
    var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjob_t");
    var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjob_y");
    var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjob_m");
    var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjob_cq");
    var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjob_lq");
    var tilldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_tilldate");
    var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divdate_job");
    var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjob_year");
    var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjob_hy");
    var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek_t");
    var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth_t");
    var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear_t");
    var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlJobdate");
    var spn_ddlJobdate_annualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_ddlJobdate_annualYear");
                                                             ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_ddlJobdate_annualYear
    var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;

    if (ddlvalue == "thisannualyear") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "block";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }else if (ddlvalue == "daily") {
        spn_1.style.display = "block";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "yesterday") {
        spn_1.style.display = "none";
        spn_2.style.display = "block";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "thismonth") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "block";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "thisquarter") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "block";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "thisyear") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "block";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "tilldate") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "daterange") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "block";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = false;
        txtToDate.disabled = false;
    }
    else if (ddlvalue == "lastquater") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "block";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "halfyear") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "block";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "lastweek") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "block";
        spn_10.style.display = "none";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "lastmonth") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "block";
        spn_11.style.display = "none";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
    else if (ddlvalue == "lastyear") {
        spn_1.style.display = "none";
        spn_2.style.display = "none";
        spn_3.style.display = "none";
        spn_4.style.display = "none";
        spn_5.style.display = "none";
        spn_6.style.display = "none";
        spn_7.style.display = "none";
        spn_8.style.display = "none";
        spn_9.style.display = "none";
        spn_10.style.display = "none";
        spn_11.style.display = "block";
        spn_ddlJobdate_annualYear.style.display = "none";
        txtFromDate.disabled = true;
        txtToDate.disabled = true;
    }
}

function EnableJob_DateOption() {
    var rdlDateArray = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlJobdate");
    var chkDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkJobDate");
    var txtFromDate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtjobFrom");
    var txtToDate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtJobTo");
    if (chkDateOption.checked) {
        for (var i = 0; i < rdlDateArray.length; i++) {
            rdlDateArray.disabled = false;
        }
    }
    else {
        for (var i = 0; i < rdlDateArray.length; i++) {
            rdlDateArray.disabled = true;
            txtFromDate.disabled = true;
            txtToDate.disabled = true;
        }
    }
}

function OnCheckShow_jobMonth() {

    var txtFromDate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtjobFrom");
    var txtToDate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtJobTo");
    var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjob_m");
    var chkDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkJobDate");

    var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlJobdate");
    var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;
    if (chkDateOption.checked) {
        if (ddlvalue == "thismonth") {
            spn_3.style.display = "block";
        }
        else if (ddlvalue == "daterange") {
            txtFromDate.disabled = false;
            txtToDate.disabled = false;
        }
    }
    else {
        spn_3.style.display = "none";
    }
}

function SelectAll() {
    var Count = 0;
    var lnkSelectAll = document.getElementById("lnkSelectAll");
    var CHK1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns");
    var chk = CHK1.getElementsByTagName("input");
    if (lnkSelectAll.innerHTML.trim() == 'Select All Columns') {
        for (var i = 0; i < chk.length; i++) {

            chk[i].checked = true;


        }
        lnkSelectAll.innerHTML = 'Select None';
    }
    else {
        for (var i = 0; i < chk.length; i++) {
            if (i == 0) {
                chk[i].checked = true;
            }
            else {
                chk[i].checked = false;
            }

        }
        lnkSelectAll.innerHTML = 'Select All Columns';
    }
}


//..................................Alert Notifications...............................................................//
var issettingimgclick;
var isimgclick;
function StayonDiv() {
    issettingimgclick = true;
}

function StayonLogoutDiv() {
    isimgclick = true;
}

var isAlertImgclick;
function StayonAlertDiv() {
    isAlertImgclick = true;
}

function OnClientLoad(editor) {
    setTimeout(function () {
        var tool = editor.getToolByName("RealFontSize");
        tool.set_value("14px");
        var tool = editor.getToolByName("FontName");
        tool.set_value("Arial");
    }, 0);
}
function GetSelectedClientID(ID) {
    var ddlClientID = document.getElementById(ID);
    var ddlvalue = ddlClientID.options[ddlClientID.selectedIndex].value;
    var hdnClientID = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdnClientID");
    if (ddlvalue != "0") {
        hdnClientID.value = ddlvalue;
    }
    else {
        hdnClientID.value = "0";
    }
}

function GetRadWindow2() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
    return oWindow;
}
function Close_wind() {
    var oWindow = GetRadWindow2();
    oWindow.argument = null;
    oWindow.close();
    return false;
}
function GetParticularSelectedClientID(ID) {
    var ddlClientID = document.getElementById(ID);
    var ddlvalue = ddlClientID.options[ddlClientID.selectedIndex].value;
    var hdnParticluarClientID = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdnParticluarClientID");
    if (ddlvalue != "0") {
        hdnParticluarClientID.value = ddlvalue;
    }
    else {
        hdnParticluarClientID.value = "0";
    }
}
function GetParticularJobSelectedClientID(ID) {
    var ddlClientID = document.getElementById(ID);
    var ddlvalue = ddlClientID.options[ddlClientID.selectedIndex].value;
    var hdnJobSelectedClientID = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdnJobSelectedClientID");
    if (ddlvalue != "0") {
        hdnJobSelectedClientID.value = ddlvalue;
    }
    else {
        hdnJobSelectedClientID.value = "0";
    }
}

function todecimal_functionForThreeDecimalplace(txtobj) {
    var value = RemoveDollorAndComma(txtobj.value); // Changed by Pradeep -- called RemoveDollorAndComma()
    if (!isNaN(value) && Number(value)) {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, value, 3, '', false, false, false);
    }
    else {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 3, '', false, false, false);
    }
}

function Validate_CRM() {
    //var systemname = document.getElementById("ctl00_ContentPlaceHolder1_UCContact_hdnsystemname").value;//kr
    var systemname = $("#ctl00_ContentPlaceHolder1_UCContact_hdnsystemname").value;//kr
    var StoreUserID = '<%=StoreUserID %>';
    var action = '<%=action %>';
    txt_ContactEmail.value = document.getElementById("ctl00_ContentPlaceHolder1_UCContact_txt_ContactEmail").value;
    if (txtFirstName.value == "" || txtFirstName.value.trim() == "") {
        document.getElementById("spnFirstName").style.display = "block";
        return false;
    }
    else {
        document.getElementById("spnFirstName").style.display = "none";
    }
    //For only fsg system. 
    if (systemname == "fsg") {
        if (txtLastName.value == "" || txtLastName.value.trim() == "") {
            document.getElementById("spnLastName").style.display = "block";
            return false;
        }
        else {
            document.getElementById("spnLastName").style.display = "none";
        }
        if (txtJobTitle.value == "" || txtJobTitle.value.trim() == "") {
            document.getElementById("spnJobTitle").style.display = "block";
            return false;
        }
        else {
            document.getElementById("spnJobTitle").style.display = "none";
        }
        if (txtJobTitle2.value == "" || txtJobTitle2.value.trim() == "") {
            document.getElementById("spnJobTitle2").style.display = "block";
            return false;
        }
        else {
            document.getElementById("spnJobTitle2").style.display = "none";
        }
        if (txtHomePhone.value == "" || txtHomePhone.value.trim() == "") {
            document.getElementById("spnHomePhone").style.display = "block";
            return false;
        }
        else {
            document.getElementById("spnHomePhone").style.display = "none";
        }
        if (txtTitle.value == "" || txtTitle.value.trim() == "") {
            document.getElementById("spnTitle").style.display = "block";
            return false;
        }
        else {
            document.getElementById("spnTitle").style.display = "none";
        }
        if (txt_ContactEmail.value == "") {
            document.getElementById("spn_txtEmail").style.display = "block";
            return false;
        }
        else {
            document.getElementById("spn_txtEmail").style.display = "none";
        }
    } //ends here.

    if (hdnClientID.value == "") {
        alert('Please select any company name');
        document.getElementById("<%=txtCompanyName.ClientID %>").focus();

    }

    if (txt_ContactEmail.value != "") {
        if (!ValidateEmail_CRM(txt_ContactEmail.value, 'spn_txtEmailExp', 'no')) {
            return false;
        }
    }

    if (chkB2bLogin.checked || chkB2bLoginChngPass.checked) {

        if (div_PasswordArea.style.display != 'none') {
            if (txtPassword.value == "") {
                document.getElementById("spnPassword").style.display = "block";
                document.getElementById("spnConfirmPassword").style.display = "none";
                document.getElementById("spnValidPassword").style.display = "none";
                return false;
            }
            if (txtPassword.value != "" && txtConfirmPassword.value == "") {
                document.getElementById("spnPassword").style.display = "none";
                document.getElementById("spnConfirmPassword").style.display = "block";
                document.getElementById("spnValidPassword").style.display = "none";
                return false;
            }
            if (txtPassword.value != txtConfirmPassword.value) {

                document.getElementById("spnValidPassword").style.display = "block";
                document.getElementById("spnConfirmPassword").style.display = "none";
                return false;
            }

        }

        if (txt_ContactEmail.value == "") {
            document.getElementById("spn_txtEmail").style.display = "block";
        }
        else {
            if (!ValidateEmail_CRM(txt_ContactEmail.value, 'spn_txtEmailExp', 'no')) {
                return false;
            }
            checkEmilDuplicacynew(txt_ContactEmail.value);
            if (ChkEmailDuplicacy) {
            }
        }
    }

    if (txt_ContactEmail.value != "") {
        checkEmilDuplicacynew(txt_ContactEmail.value);
        if (!ChkEmailDuplicacy) {
            return true;
        }
        else {
            return false;
        }
    }

    if (StoreUserID != 0) {
        if (txt_ContactEmail.value == "") {
            checkEmilDuplicacynew(txt_ContactEmail.value);
            if (ChkEmailDuplicacy) {
            }
        }
    }
    if (CheckFinal) {
        return false;
    }
    else {
        document.getElementById("divOverLayer").style.display = "block";
        return true;
    }
}


function ValidateEmail_CRM(txtVal, spnID, IsMandatory) {
    debugger
    document.getElementById(spnID).style.display = "none";
    if (IsMandatory == "yes") {
        if ((txtVal == null) || (txtVal == "")) {
            alert("Please Enter your Email ID");
            document.getElementById(spnID).style.display = "block";
            //emailID.focus()
            return false
        }
    }
    if (echeckCRM(txtVal) == false) {
        document.getElementById(spnID).innerHTML = EmailInvalidFormat;
        document.getElementById(spnID).style.display = "block";
        return false
    }
    return true
}

function echeckCRM(str) {
    debugger
    //var EmailExn = /^([a-zA-Z0-9_\.\-\&\'])+\@(([a-zA-Z0-9_\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var EmailExn = /^([a-zA-Z0-9_\.\-\&\!\#\$\%\*\+\=\-\/\?\`\~\{\|\}\;\'])+\@(([a-zA-Z0-9_\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!EmailExn.test(str)) {
        return false
    }
    return true
}

function pricetodecimal(obj, index) {

    if (!isNaN(obj.value)) {
        obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 6, '', false, false, false);
    }
    else {
        obj.value = "0.00";
    }
}

function checkforInteger(txtadjust, s) {
    var i;
    s = s.toString();
    if (s == '') {
        document.getElementById(txtadjust).value = 0;
    }
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (isNaN(c)) {
            document.getElementById(txtadjust).value = 0;
            return false;
        }
    }
}