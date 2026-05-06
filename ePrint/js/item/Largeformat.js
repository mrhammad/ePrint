// JScript File

/*******************************************************************************************************/
//The below js functions are used for large format

function getvalue() {
    
    var values = "";
    var ids = "";
    var whiteinkIds = "";
    var whiteinvalues = "";

    for (var i = 1; i <= len.value; i++) {
        var quote = new Array();
        var span = document.getElementById("spn" + i + "");

        if (span != null && span != undefined) {
            quote = span.innerHTML.split('&');
            var spnval = quote[0];
            if (spnval != "") {
                values += spnval + "^";
                ids += document.getElementById("hdn" + i + "").value + "^";
            }
        }
    }

    for (var i = 1; i <= whitelen.value; i++) {
        var whiteinkquote = new Array();
        var spanforwhiteink = document.getElementById("spnwhiteInk" + i + "");
        if (spanforwhiteink != null && spanforwhiteink != undefined) {
            whiteinkquote = spanforwhiteink.innerHTML.split('&');
            var spnval = whiteinkquote[0];
            if (spnval != "") {
                whiteinvalues += spnval + "^";
                whiteinkIds += document.getElementById("hdnwhiteInk" + i + "").value + "^";
            }
        }
    }

    val.value = values;
    ide.value = ids;

    idsforwhiteink.value = whiteinkIds;
    whiteinkval.value = whiteinvalues;
}


function clear_ink(val, name) {
    var spn = val.replace('img', 'spn');
    if (window.confirm("Are you sure, you want to clear '" + SpecialDecode(name) + "'?")) {
        document.getElementById(spn).innerHTML = "";
    }
}

function clear_paper(val, name, id) {

    var spn = val.replace('img', 'spnpaper');
    var hdn = val.replace('img', 'hdnpaper');
    if (window.confirm("Are you sure, you want to clear '" + SpecialDecode(name) + "'?")) {
        if (id == '2') {
            spnpaper2.innerHTML = "";
            hdnpaper2.value = "0";
        }
        if (id == '3') {
            spnpaper3.innerHTML = "";
            hdnpaper3.value = "0";
        }
        if (id == '4') {
            spnpaper4.innerHTML = "";
            hdnpaper4.value = "0";
        }
        if (id == '5') {
            spnpaper5.innerHTML = "";
            hdnpaper5.value = "0";
        }
    }
}

function CheckNext() {

    //var CheckWhat = true;
    var chakWhat = true;
    //                if(trim12(txtLargeFormatName.value)=='')
    //                {
    //                    spntxtLargeFormatName.style.display="block";
    //                    CheckWhat=false;
    //                }
    //                if(CheckReqCompare(txtMinimumWebWidth.value,'spn_txtMinimumWebWidth','spn_txtMinWebWidth_number'))
    //                {
    //                    CheckWhat=false;
    //                }

    if (txtMinimumWebWidth.value == "") {
        document.getElementById("spn_txtMinimumWebWidth").style.display = "block";
        chakWhat = false;
    }


    if (!CheckDecimalPlus(txtMinimumWebWidth.value, 'spn_txtMinimumWebWidth', 'spn_txtMinWebWidth_number', 'yes')) {
        chakWhat = false;
    }

    if (txtMaximumWebWidth.value == "") {
        document.getElementById("spn_txtMaximumWebWidth").style.display = "block";
        chakWhat = false;
    }

    if (!CheckDecimalPlus(txtMaximumWebWidth.value, 'spn_txtMaximumWebWidth', 'spn_txtMaxWidth_number', 'yes')) {
        chakWhat = false;
    }

    if (txtMaximumSheetWeight.value == "") {
        document.getElementById("spn_txtMaximumSheetWeight").style.display = "block";
        chakWhat = false;
    }

    if (!CheckDecimalPlus(txtMaximumSheetWeight.value, 'spn_txtMaximumSheetWeight', 'spn_txtMaxSheetWeight_number', 'yes')) {
        chakWhat = false;
    }

    if (txtGripDepth.value == "") {
        document.getElementById("spn_txtGripDepth").style.display = "block";
        chakWhat = false;
    }

    if (!CheckDecimalPlus(txtGripDepth.value, 'spn_txtGripDepth', 'spn_txtGripDepth_number', 'yes')) {
        chakWhat = false;
    }


    if (txtSideGutterDepth.value == "") {
        document.getElementById("spn_txtSideGutterDepth").style.display = "block";
        chakWhat = false;
    }

    if (!CheckDecimalPlus(txtSideGutterDepth.value, 'spn_txtSideGutterDepth', 'spn_txtSideGutterDepth_number', 'yes')) {
        chakWhat = false;
    }

    if (txtGutterHorizontal.value == "") {
        document.getElementById("spn_DefaultGutters").style.display = "block";
        chakWhat = false;
    }

    if (!CheckDecimalPlus(txtGutterHorizontal.value, 'spn_DefaultGutters', 'spn_DefaultGuttersNumber', 'yes')) {
        chakWhat = false;
    }

    if (txtGutterVertical.value == "") {
        document.getElementById("spn_DefaultGutters").style.display = "block";
        chakWhat = false;
    }

    if (!CheckDecimalPlus(txtGutterVertical.value, 'spn_DefaultGutters', 'spn_DefaultGuttersNumber', 'yes')) {
        chakWhat = false;
    }
    //                if(ddlPrintSheetSize.value=='0')
    //                {
    //                 spnPrintSheetSize.style.display="block";
    //                  CheckWhat=false;
    //                } 
    //                if (ddlJobSize.value == '0') {
    //                    spnJobSize.style.display = "block";
    //                    chakWhat = false;
    //                }
    //                if(ddlGuillotine.value=='0')
    //                {
    //                  spnGuillotine.style.display="block";
    //                  CheckWhat=false;
    //                }

    //    if (trim12(spnpaper1.innerHTML) == '') {
    //        spndefaultpaper1.style.display = "block";
    //        chakWhat = false;
    //    }
    if (!CheckDecimalPlus(txtSpoilage.value, 'spn_txtSpoilage', 'spn_txtSpoilage_number', 'yes')) {
        chakWhat = false;
    }
    if (!CheckDecimalPlus(txtRunningSpoilage.value, 'spn_RunningSpoilage', 'spn_RunningSpoilage_number', 'yes')) {
        chakWhat = false;
    }

    if (trim12(txtUnitOfMeasure.value) != "" && UnitOfMeasure) {
        if (!SetNumber_OfUnit(txtUnitOfMeasure, txtUnitOfMeasure.value)) {
            spn_UnitOfMeasure.style.display = "block";
            chakWhat = false;
        }
    }


    if (chakWhat) {
        if (IsDuplicate == false) {
            changeCss('spn_4');
            divPlantProperties.style.display = "block";
            txtSetupCharge.focus();
        }
    }
}


var CheckWhat = true;
function CheckSave() {
    
    CheckWhat = true;
    if (!CheckDecimalPlus(txtSetupCharge.value, 'spn_SetupCharge', 'spn_SetupCharge_number', 'yes')) {
        CheckWhat = false;
    }
    if (!CheckDecimalPlus(txtMinimumRunningCharge.value, 'spn_MinRunningCharge', 'spn_MinRunningCharge_number', 'yes')) {
        CheckWhat = false;
    }
    if (!CheckDecimalPlus(txtMarkup.value, 'spn_Markup', 'spn_Markup_number', 'yes')) {
        CheckWhat = false;
    }

    if (!CheckDecimalPlus(txtPrintPerHourLow.value, 'spn_PrintPerHour', 'spn_PrintPerHour_number', 'yes')
                    || !CheckDecimalPlus(txtPrintPerHourMedium.value, 'spn_PrintPerHour', 'spn_PrintPerHour_number', 'yes')
                    || !CheckDecimalPlus(txtPrintPerHourHigh.value, 'spn_PrintPerHour', 'spn_PrintPerHour_number', 'yes')) {
        CheckWhat = false;
    }
    if (txtPrintPerHourLow.value == "" || txtPrintPerHourMedium.value == "" || txtPrintPerHourHigh.value == "") {
        document.getElementById("spn_PrintPerHour").style.display = "block";
        CheckWhat = false;
    }

    if (!CheckDecimalPlus(txtPressHourlyCharge.value, 'spn_txtPressHourlyCharge', 'spn_txtPressHourlyCharge_number', 'yes')) {
        CheckWhat = false;
    }
    if (!CheckDecimalPlus(txtInkCoverageSide1.value, 'spn_InkCoverageSide1', 'spn_InkCoverageSide1_number', 'yes')) {
        CheckWhat = false;
    }
    if (!CheckDecimalPlus(txtInkCoverageSide2.value, 'spn_InkCoverageSide2', 'spn_InkCoverageSide2_number', 'yes')) {
        CheckWhat = false;
    }

    if (!CheckDecimalPlus(txtInkCoverageSide1.value, 'span_whiteinkcoverageside1', 'span_WhiteInkcoverageside1number', 'yes')) {
        CheckWhat = false;
    }
    if (!CheckDecimalPlus(txtInkCoverageSide2.value, 'spn_whiteinkcoverageside2', 'spn_whiteinkcoverageside2number', 'yes')) {
        CheckWhat = false;
    }

    var spn1 = document.getElementById("spn1").innerHTML;
    if (trim12(spn1) == '') {
        document.getElementById('spn_ink').style.display = "block";
        CheckWhat = false;
    }

    //var spnwhiteInk = document.getElementById("spnwhiteInk1").innerHTML;
    //if (trim12(spnwhiteInk) == '') {
    //    document.getElementById('spn_whiteInk').style.display = "block";
    //    CheckWhat = false;
    //}


    //start



    for (var i = 1; i <= ItemsCounter; i++) {

        if (document.getElementById("txtBlackFrom" + i) != null && document.getElementById("txtBlackFrom" + i) != undefined) {
            var val = document.getElementById("txtBlackFrom" + i).value;
            var val1 = document.getElementById("txtBlackTo" + i).value;
            var val2 = "00005";
            var val3 = document.getElementById("txtBlackCost" + i).value;
            var val4 = document.getElementById("txtBlackChargableRate" + i).value;
            var val5 = document.getElementById("txtBlackMarkup" + i).value;
            var val6 = document.getElementById("hid_BlackClickChargeZoneLookupID_" + i).value;
            if (trim12(val1) == '' || trim12(val2) == '' || trim12(val3) == '' || trim12(val4) == '') {
                document.getElementById("spn_Black_" + i + "").style.display = "block";
                CheckWhat = false;
                break;
            }
            else {
                document.getElementById("spn_Black_" + i + "").style.display = "none";
            }
            //if (hdn_ClickChargeZoneLookupBlack.value == '') {
            //    hdn_ClickChargeZoneLookupBlack.value = val + "~" + val1 +  "~" + val3 + "~" + val4 + "~" + val5 + "~" + val6 + "";
            //} else {
            //    hdn_ClickChargeZoneLookupBlack.value = hdn_ClickChargeZoneLookupBlack.value + "$" + val + "~" + val1 + "~" + val2 + "~" + val3 + "~" + val4 + "~" + val5 + "~" + val6 + "";
            //}
            hdn_ClickChargeZoneLookupBlack.value = hdn_ClickChargeZoneLookupBlack.value + "$" + val + "~" + val1 + "~" + val2 + "~" + val3 + "~" + val4 + "~" + val5 + "~" + val6 + "";
        }
    }
    //hid_ddlMethodSelected.value = "ClickChargeZoneLookup";


    //end




    if (CheckWhat) {
        getvalue();
        hdnAccountCode.value = ddlAccountCode.value;
        return true;
    }
    else {
        return false;
    }


   
}


var CheckCount = 1;
var action = "<%=Action %>";
function showdivs() {
   
    for (var i = 0; i < 5; i++) {
        AddMoreInk('default');
    }
}

if (action == 'add') {
    
    showdivs();
}
else {
   
    var hdnid2 = document.getElementById("ctl00_ContentPlaceHolder1_hdneditid");
    var ids = new Array();
    ids = hdnid2.value.split('^');
    if (ids.length <= 5) {
        showdivs();
    }
    else {
        for (var i = 0; i < ids.length - 1; i++) {
            AddMoreInk('default');
        }
    }
}


function AddMoreInk(type) {
   
    var div_Content = document.getElementById("divContent");
    var hdnlength = document.getElementById("ctl00_ContentPlaceHolder1_hdnlength");
    hdnlength.value = CheckCount;
    var divconetent = '';
    divconetent = "<div align='left'>";
    divconetent = divconetent + "<div class='bglabel'>";
    divconetent = divconetent + "<div style='float: left'>";
    if (CheckCount == '1') {
        divconetent = divconetent + "<span class='normaltext'>" + Ink + " " + CheckCount + "</span>" +
                 " <span style='color: red'>*</span> </div>";
    }
    else {
        divconetent = divconetent + "<span class='normaltext'>" + Ink + " " + CheckCount + "</span></div>";
    }

    divconetent = divconetent + "<div style='float: right;'>";
    divconetent = divconetent + "<img id='" + CheckCount + "' style='cursor:pointer' src='" + strImagepathjs + "plus.gif' onclick='openpopup(this.id)' /></div>";
    divconetent = divconetent + "</div>";
    divconetent = divconetent + "<div class='box' nowrap='nowrap'>";
    divconetent = divconetent + "<span class='graytext' id='spn" + CheckCount + "'></span>&nbsp;<input type='hidden' id='hdn" + CheckCount + "' />";
    divconetent = divconetent + "</div>";

    divconetent = divconetent + "</div>";

    if (CheckCount == '1') {
        //divconetent = divconetent + "<br/></br></div><div align='left' style='float: left'><span id='spn_ink' class='spanerrorMsg' style='display: none; position:static; width: 175px;'>Please select Ink</span></div>";
        divconetent = divconetent + "<br/></br></div><div align='left' style='float: left'><span id='spn_ink' class='spanerrorMsg' style='display: none; position:static; width: auto;padding-left:4px;padding-right:4px'>" + InkToPress_Validation + "</span></div>";

    }

    if (CheckCount < 21) {
        div_Content.innerHTML = div_Content.innerHTML + divconetent;
        CheckCount = CheckCount + 1;
    }
    return false;
}


function DeleteMoreInk() {
    var ctrl;
    ctrl = document.getElementById('divContent');
    if (CheckCount > 6) {
        if (navigator.appName == 'Microsoft Internet Explorer') {
            if (CheckCount != 0) {
                ctrl.removeChild(ctrl.lastChild); //new changes by swetha
                CheckCount = CheckCount - 1;
            }
        }
        else {
            if (CheckCount != 0) {
                ctrl.removeChild(ctrl.lastChild); //new changes by swetha                       
                CheckCount = CheckCount - 1;
            }
        }
    }
}

function MorePaper() {
    //PopupCenter(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Paper&id=0", '950', '450');
    window.radopen(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Paper&id=0", '950', '450');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    return false;
}
function showhide(showid, hideid) {
    document.getElementById(showid).style.display = 'block';
    document.getElementById(hideid).style.display = 'none';
}

function changeCss(iss) {
    document.getElementById(iss).style.color = "orange";
    if (document.getElementById(iss).id == "spn_1") {
        div_Feed_restriction.style.display = "block";
        div_Paper_Settings.style.display = "none";
        div_Plant_Properties.style.display = "none";
        div_Plant_Calculation.style.display = "none";
        div_Plant_Charges.style.display = "none";
        div_Ink_Order.style.display = "none";
        lblheader.innerHTML = "Settings: Large Format - Press,Paper & Plant Properties";
    }
    else if (document.getElementById(iss).id == "spn_2") {
        div_Feed_restriction.style.display = "none";
        div_Paper_Settings.style.display = "block";
        div_Plant_Properties.style.display = "none";
        div_Plant_Calculation.style.display = "none";
        div_Plant_Charges.style.display = "none";
        div_Ink_Order.style.display = "none";
    }
    else if (document.getElementById(iss).id == "spn_3") {
        div_Feed_restriction.style.display = "none";
        div_Paper_Settings.style.display = "none";
        div_Plant_Properties.style.display = "block";
        div_Plant_Calculation.style.display = "none";
        div_Plant_Charges.style.display = "none";
        div_Ink_Order.style.display = "none";
    }
    else if (document.getElementById(iss).id == "spn_4") {
        div_Feed_restriction.style.display = "none";
        div_Paper_Settings.style.display = "none";
        div_Plant_Properties.style.display = "none";
        div_Plant_Calculation.style.display = "block";
        div_Plant_Charges.style.display = "none";
        div_Ink_Order.style.display = "none";
        lblheader.innerHTML = "Settings: Large Format - Plant Calculation & Ink order";
    }

    else if (document.getElementById(iss).id == "spn_5") {
        div_Feed_restriction.style.display = "none";
        div_Paper_Settings.style.display = "none";
        div_Plant_Properties.style.display = "none";
        div_Plant_Calculation.style.display = "none";
        div_Plant_Charges.style.display = "block";
        div_Ink_Order.style.display = "none";
    }
    else if (document.getElementById(iss).id == "spn_6") {
        div_Feed_restriction.style.display = "none";
        div_Paper_Settings.style.display = "none";
        div_Plant_Properties.style.display = "none";
        div_Plant_Calculation.style.display = "none";
        div_Plant_Charges.style.display = "none";
        div_Ink_Order.style.display = "block";
        lblheader.innerHTML = "Settings: Large Format - Ink Order";
    }

    for (var i = 0; i < 7; i++) {
        var dd = "spn_" + i;

        if (dd != iss) {
            if (document.getElementById("spn_" + i) != null) {
                document.getElementById("spn_" + i).style.color = "black";
                var ff = "div_" + i;
                ff = ff + i;
            }
        }
        else {
            var ff = "div_" + i;
            ff = ff + i;
        }
    }
}
function showDiv(chkid, showid, hideid) {
    if (document.getElementById(chkid).checked) {
        document.getElementById(showid).style.display = "block";
        document.getElementById(hideid).style.display = "none";
    }
    else {
        document.getElementById(showid).style.display = "none";
        document.getElementById(hideid).style.display = "none";
    }
}



function showSpoilageType(ddlvalue) {
    div_nonprintimage.style.display = "none";
    div_DefaultPrintSheet.style.display = "none";
    if (ddlvalue == 'roll') {
        spnSpoilage.innerHTML = "mm";
    }
    else if (ddlvalue == 'sheet') {
        spnSpoilage.innerHTML = "Sheets";
        div_nonprintimage.style.display = "block";
        div_DefaultPrintSheet.style.display = "block";
    }
}



function openpopup(spnid) {
    //PopupCenter(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Ink&InkType=Y&id=" + spnid + "", '950', '450');
    window.radopen(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Ink&inkcolor=color&InkType=Y&id=" + spnid + "", '950', '450');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}


function selectInk() {

    var names = new Array();
    var ids = new Array();
    names = hdnval.value.split('^');
    ids = hdnid.value.split('^');

    for (var i = 0; i < ids.length - 1; i++) {
        var j = i + 1;
        var spn = "spn" + j;
        var hdn = "hdn" + j;

        document.getElementById(spn).innerHTML = SpecialDecode(names[i]) + "&nbsp;<img  id='img" + j + "' style='cursor:pointer' alt='Clear this ink' src='" + strImagepathjs + "close.gif' onclick=\"javascript:clear_ink(this.id,'" + names[i] + "');\" />";
        document.getElementById(hdn).value = ids[i];

    }
}

//function selectWhiteInk() {
//    var names = new Array();
//    var ids = new Array();
//    names = hdnval.value.split('^');
//    ids = hdnid.value.split('^');
//    for (var i = 0; i < ids.length - 1; i++) {
//        var j = i + 1;
//        var spn = "spn" + j;
//        var hdn = "hdn" + j;

//        document.getElementById(spn).innerHTML = SpecialDecode(names[i]) + "&nbsp;<img  id='img" + j + "' style='cursor:pointer' alt='Clear this ink' src='" + strImagepathjs + "close.gif' onclick=\"javascript:clear_ink(this.id,'" + names[i] + "');\" />";
//        document.getElementById(hdn).value = ids[i];

//    }
//}


function CheckLength(id) {
    document.getElementById(id).style.display = 'none';
}
//function to select paper pop up only rolls



function OpenPaperRollsPopUp(Type, id) {

    // By Jagat On 16/July/2012

    //    var papertype = '';
    //    if (Type == 'paper') {
    //        papertype = "roll";

    //    }    
    //var e = document.getElementById("ctl00_ContentPlaceHolder1_ddlPaperType");
    var rollvalue = 'sheet';


    //End

    //Width and height changed //By Rajeev
    //PopupCenter(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=paper&papertype=" + papertype + "", '950', '430')
    window.radopen(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=paper&papertype=" + rollvalue + "&IsLargeMaterial=1&MaterialNo=" + id, '950', '430');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    return false;
}


var CheckCountForWhiteInk = 1;
var action = "<%=Action %>";
function showdivsforwhiteink() {
    for (var i = 0; i < 1; i++) {
        AddMoreWhiteInk('default');
    }
}

if (action == 'add') {
    showdivsforwhiteink();
}
else {
    var hdnid2 = document.getElementById("ctl00_ContentPlaceHolder1_hdneditidforwhiteink");
    var ids = new Array();
    ids = hdnid2.value.split('^');
    if (ids.length <= 1) {
        showdivsforwhiteink();
    }
    else {
        for (var i = 0; i < ids.length - 1; i++) {
            AddMoreWhiteInk('default');
        }
    }
}

function AddMoreWhiteInk(type) {
    var div_Content = document.getElementById("divContentforwhiteink");
    var hdnlength = document.getElementById("ctl00_ContentPlaceHolder1_hdnlengthforwhiteink");
    hdnlength.value = CheckCountForWhiteInk;
    var divconetent = '';
    divconetent = "<div align='left'>";
    divconetent = divconetent + "<div class='bglabel'>";
    divconetent = divconetent + "<div style='float: left'>";
    //if (CheckCountForWhiteInk == '1') {
    //    divconetent = divconetent + "<span class='normaltext'>" + White_Ink + " " + CheckCountForWhiteInk + "</span>" +
    //        "  <span style='color: red'>*</span> </div>";  Commented by Amin  ticket#33528


    //}
    //else {
        divconetent = divconetent + "<span class='normaltext'>" + White_Ink + " " + CheckCountForWhiteInk + "</span></div>";
    //}

    divconetent = divconetent + "<div style='float: right;'>";
    divconetent = divconetent + "<img id='" + CheckCountForWhiteInk + "' style='cursor:pointer' src='" + strImagepathjs + "plus.gif' onclick='openpopupforwhite(this.id)' /></div>";
    divconetent = divconetent + "</div>";
    divconetent = divconetent + "<div class='box' nowrap='nowrap'>";
    divconetent = divconetent + "<span class='graytext' id='spnwhiteInk" + CheckCountForWhiteInk + "'></span>&nbsp;<input type='hidden' id='hdnwhiteInk" + CheckCountForWhiteInk + "' />";
    divconetent = divconetent + "</div>";

    divconetent = divconetent + "</div>";

    if (CheckCountForWhiteInk == '1') {
        //divconetent = divconetent + "<br/></br></div><div align='left' style='float: left'><span id='spn_ink' class='spanerrorMsg' style='display: none; position:static; width: 175px;'>Please select Ink</span></div>";
        divconetent = divconetent + "<br/></br></div><div align='left' style='float: left'><span id='spn_whiteInk' class='spanerrorMsg' style='display: none; position:static; width: auto;padding-left:4px;padding-right:4px'>" + WhiteInkToPress_Validation + "</span></div>";
    }

    if (CheckCountForWhiteInk < 21) {
        div_Content.innerHTML = div_Content.innerHTML + divconetent;
        CheckCountForWhiteInk = CheckCountForWhiteInk + 1;
    }
    return false;
}

function DeleteMoreWhiteInk() {
    var ctrl;
    ctrl = document.getElementById('divContentforwhiteink');
    if (CheckCountForWhiteInk > 6) {
        if (navigator.appName == 'Microsoft Internet Explorer') {
            if (CheckCountForWhiteInk != 0) {
                ctrl.removeChild(ctrl.lastChild); //new changes by swetha
                CheckCountForWhiteInk = CheckCountForWhiteInk - 1;
            }
        }
        else {
            if (CheckCountForWhiteInk != 0) {
                ctrl.removeChild(ctrl.lastChild); //new changes by swetha                       
                CheckCountForWhiteInk = CheckCountForWhiteInk - 1;
            }
        }
    }
}

function openpopupforwhite(spnid) {
    //PopupCenter(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Ink&InkType=Y&id=" + spnid + "", '950', '450');
    window.radopen(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Ink&inkcolor=white&InkType=Y&id=" + spnid + "", '950', '450');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}

function selectWhiteInk() {
    var names = new Array();
    var ids = new Array();
    names = hdneditvalueforwhiteink.value.split('^');
    ids = hdneditidforwhiteink.value.split('^');

    for (var i = 0; i < ids.length - 1; i++) {
        var j = i + 1;
        var spn = "spnwhiteInk" + j;
        var hdn = "hdnwhiteInk" + j;

        document.getElementById(spn).innerHTML = SpecialDecode(names[i]) + "&nbsp;<img  id='imgwhiteInk" + j + "' style='cursor:pointer' alt='Clear this ink' src='" + strImagepathjs + "close.gif' onclick=\"javascript:clear_ink(this.id,'" + names[i] + "');\" />";
        document.getElementById(hdn).value = ids[i];

    }
}