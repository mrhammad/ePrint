

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
    var EmailExn = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!EmailExn.test(str)) {
        return false
    }
    return true

    
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
        //emailID.value = ""
        //emailID.focus()
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
function todecimal_function(txtobj) {
    var value = txtobj.value;
    if (!isNaN(txtobj.value) && Number(txtobj.value)) {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, txtobj.value, 0, '', false, false, false);
    }
    else {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, 0, 0, '', false, false, false);
    }
    //alert(txtobj.value);
}

function todecimal_functionNew(txtobj, Value, DeciNumber) {
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

    window.open(strSitepath + "document/store/" + AccountID + "/Pdf/" + FileName, '_blank');
}

function PrintReady_Open(FileName, CompanyID) {

    window.open(strSitepath + "document/" + CompanyID + "/" + FileName, '_blank');
}
