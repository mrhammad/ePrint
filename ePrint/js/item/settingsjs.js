
function checkDescription() {
    if (navigator.appName.toLowerCase() == "microsoft internet explorer") {
        if (txtDescription.value == '') {
            txtDescription.rows = 2;
        }
    }
}

function CheckLength(id) {
    document.getElementById(id).style.display = 'none';
}

function viewPaper() {
    document.getElementById(lblDefaultPaper).title = document.getElementById(lblDefaultPaper).innerHTML;
    document.getElementById(lblDefaultPaper).style.cursor = "pointer";
    if (document.getElementById(lblDefaultPaper).innerHTML.length > 25) {
        document.getElementById(lblDefaultPaper).innerHTML = document.getElementById(lblDefaultPaper).innerHTML.substring(0, 25) + "...";
    }
}

var chakWhat = true;
function DigiNext() {

    var txtDigitalPressName = document.getElementById("ctl00_ContentPlaceHolder1_txtDigitalPressName");
    chakWhat = true;
    if (CheckStringMandatory(txtDigitalPressName.value, 'spn_txtDigitalPressName')) {
        chakWhat = false;
    }

    if (!IsDecimalValue(txtMaxImgHeight.value, 'spn_MaximumImageArea_number')) {
        chakWhat = false;
    }
    if (txtMaxImgHeight.value == "") {
        document.getElementById("spn_MaximumImageArea").style.display = "block";
        chakWhat = false;
    }
    if (!IsDecimalValue(txtMaxImgWidth.value, 'spn_MaximumImageArea_number')) {
        chakWhat = false;
    }
    if (txtMaxImgWidth.value == "") {
        document.getElementById("spn_MaximumImageArea").style.display = "block";
        chakWhat = false;
    }

    if (!IsDecimalValue(txtMaxSheetWeight.value, 'spn_txtMaxSheetWeight_number')) {
        chakWhat = false;
    }

    if (txtMaxSheetWeight.value == "") {
        document.getElementById("spn_txtMaxSheetWeight").style.display = "block";
        chakWhat = false;
    }

    //    var txtGripDepth=document.getElementById("<%=txtGripDepth.ClientID %>").value;
    //    if(CheckReqCompare(txtGripDepth,'spn_txtGripDepth','spn_txtGripDepth_number'))
    //    {
    //        chakWhat=false;
    //    }

    if (!IsDecimalValue(txtGutterDepthHeight.value, 'spn_GutterDepth_number')) {
        chakWhat = false;
    }

    if (txtGutterDepthHeight.value == "") {
        document.getElementById("spn_DefaultGutters").style.display = "block";
        chakWhat = false;
    }

    if (!IsDecimalValue(txtGutterDepthWidtht.value, 'spn_GutterDepth_number')) {
        chakWhat = false;
    }

    if (txtGutterDepthWidtht.value == "") {
        document.getElementById("spn_DefaultGutters").style.display = "block";
        chakWhat = false;
    }

    if (!IsDecimalValue(txtGutterHorizontal.value, 'spn_DefaultGuttersNumber')) {
        chakWhat = false;
    }

    if (txtGutterHorizontal.value == "") {
        document.getElementById("spn_GutterDepth").style.display = "block";
        chakWhat = false;
    }

    if (!IsDecimalValue(txtGutterVertical.value, 'spn_DefaultGuttersNumber')) {
        chakWhat = false;
    }

    if (txtGutterVertical.value == "") {
        document.getElementById("spn_GutterDepth").style.display = "block";
        chakWhat = false;
    }

    if (!IsDecimalValue(txtSpoilageSheets.value, 'spn_txtSpoilageSheets_number')) {
        chakWhat = false;
    }

    if (txtSpoilageSheets.value == "") {
        document.getElementById("spn_txtSpoilageSheets").style.display = "block";
        chakWhat = false;
    }

    if (!IsDecimalValue(txtRunningSpoilage.value, 'spn_txtRunningSpoilage_number')) {
        chakWhat = false;
    }

    if (txtRunningSpoilage.value == "") {
        document.getElementById("spn_txtRunningSpoilage").style.display = "block";
        chakWhat = false;
    }
    if (CallonChange(ddlPrintSheetSize.value, 'spn_ddlPrintSheetSize')) {
        chakWhat = false;
    }
    if (CallonChange(ddlJobSize.value, 'spn_ddlJobSize')) {
        chakWhat = false;
    }
    //    if (CallonChange(ddlGuillotine.value, 'spn_ddlGuillotine')) {
    //        chakWhat = false;
    //    }
    if (!IsDecimalValue(txtSetupCharge.value, 'spn_txtSetupCharge_number')) {
        chakWhat = false;
    }
    if (!IsDecimalValue(txtMinRunningCharge.value, 'spn_txtMinRunningCharge_number')) {
        chakWhat = false;
    }
    //    if (!IsDecimalValue(txtMarkUp.value, 'spn_txtMarkUp_number')) {
    //        chakWhat = false;
    //    }    
    if (trim12(txtUnitOfMeasure.value) != "" && UnitOfMeasure) {
        if (!SetNumber_OfUnit(txtUnitOfMeasure, txtUnitOfMeasure.value)) {
            spn_UnitOfMeasure.style.display = "block";
            chakWhat = false;
        }
    }
    if (IsDuplicate) {
        chakWhat = false;
        txtDigitalPressName.focus();
    }

    if (chakWhat) {
        setTimeout(function () { NewCheckDigitalPress() }, 500);
    }
}

function NewCheckDigitalPress() {
    if (IsDuplicate) {
        txtDigitalPressName.focus();
    }
    else if (IsDuplicate == false) {
        divFeedRestriction.style.display = "none";
        divPlantCalculation.style.display = "block";
        lblheader.innerHTML = "Settings: Digital Press - Plant Calculation";
        if (ddlMethod.value == "clickchargelookup") {
            txtBlackChargeableSheets.focus();
        }
        else if (ddlMethod.value == "speedweightlookup") {
            txtHourlyCharge.focus();
        }
        else if (ddlMethod.value == "clickchargezonelookup") {
            txtBlackTo1.focus();
        }
        else {
            ddlMethod.focus();
        }
    }
}


function ShowOnCalculation(ddlID) {
    divClickChargeLookup.style.display = "none";
    divSpeedWeightLookup.style.display = "none";
    divClickZonesLookup.style.display = "none";
    var ddlText = ddlID.options[ddlID.selectedIndex].text.toLowerCase();
    var ddlValue = ddlID.options[ddlID.selectedIndex].value.toLowerCase();

    if (ddlValue != '') {
        if (ddlValue == 'clickchargelookup') {
            divClickChargeLookup.style.display = "block";
        }
        else if (ddlValue == 'speedweightlookup') {
            divSpeedWeightLookup.style.display = "block";
            hid_ddlMethodSelected.value = "SpeedWeightLookup";
        }
        else if (ddlValue == 'clickchargezonelookup') {
            divClickZonesLookup.style.display = "block";
        }
        else {
            divClickChargeLookup.style.display = "none";
            divSpeedWeightLookup.style.display = "none";
            divClickZonesLookup.style.display = "none";
        }
    }
}



/*  function checkNextCharge(txtValue,ROW,type)
{
var TextBoxTo;
var LabelFrom;
var txtFrom;
if(type=='black')
{
TextBoxTo="txtBlackTo";
LabelFrom="spnBlackFrom";
txtFrom="txtBlackFrom";
}
else if(type=='color')
{                                                                    
TextBoxTo="txtColorTo";
LabelFrom="spnColorFrom";
txtFrom="txtColorFrom"; 
}
var ConcatID=GetID+TextBoxTo;//Ct00_ccc
LabelFrom=GetID+LabelFrom;//Ct00_ccc
txtFrom=GetID+txtFrom;//Ct00_ccc
var start=Number(ROW+1);
        
if(!isNaN(txtValue))
{
var IsCorrect=true;
var First=document.getElementById(ConcatID+Number(ROW-1));
var Second=document.getElementById(ConcatID+Number(ROW));

if(Number(ROW)>1)
{
IsCorrect=(Number(Second.value) > Number(First.value));
}
if(IsCorrect)
{
document.getElementById(LabelFrom+""+start).innerHTML=Number(txtValue)+Number(1);
document.getElementById(txtFrom+""+start).value=Number(txtValue)+Number(1);
if(ROW==7)
{
document.getElementById(LabelFrom+"8").innerHTML="";
document.getElementById(LabelFrom+"8").innerHTML=Number(txtValue)+Number(1);
document.getElementById(LabelFrom+"8").innerHTML="+"+document.getElementById(LabelFrom+"8").innerHTML;
document.getElementById(txtFrom+"8").value=Number(txtValue)+Number(1);
}
}
}
}
function CheckingZones()
{
CheckZone=false;
}
    
function panel()
{
     
}*/

function spnchkbox_FlattenClick_OnClick() {
    if (chkFlatten.checked) {
        chkFlatten.checked = false;
    }
    else {
        chkFlatten.checked = true;
    }
}


function spnchkbox_SumClick_OnClick() {
    if (chkSum.checked) {
        chkSum.checked = false;
    }
    else {
        chkSum.checked = true;
    }
}


function FinalSave() {
    var CheckWhat = true;
    spn_ddlMethod.style.display = "none";
    if (ddlMethod.value == "clickchargelookup") {
        if (!CheckReqDecimal(txtBlackChargeableSheets.value, 'spn_txtBlackChargeableSheets', 'spn_txtBlackChargeableSheets_number')) {
            CheckWhat = false;
        }
        if (!CheckReqDecimal(txtColourChargeableSheets.value, 'spn_txtColourChargeableSheets', 'spn_txtColourChargeableSheets_number')) {
            CheckWhat = false;
        }
        if (!CheckReqDecimal(txtNoChargeableSheets.value, 'spn_txtNoChargeableSheets', 'spn_txtNoChargeableSheets_number')) {
            CheckWhat = false;
        }
        if (!IsDecimalValue(txtMarkUp.value, 'spn_txtMarkUp_number')) {
            CheckWhat = false;
        }
        hid_ddlMethodSelected.value = "ClickChargeLookup";
    }
    else if (ddlMethod.value == "speedweightlookup") {
        if (!CheckDecimalPlus(txtBlackGSM1.value, 'spn_txtBlackGSM1', 'spn_txtBlackGSM1_number', 'yes')) {
            CheckWhat = false;
        }

        if (!CheckDecimalPlus(txtBlackPagesPerMinute1.value, 'spn_txtBlackPagesPerMinute1', 'spn_txtBlackPagesPerMinute1_number', 'yes')) {
            CheckWhat = false;
        }
        if (!CheckDecimalPlus(txtColorGSM1.value, 'spn_txtColorGSM1', 'spn_txtColorGSM1_number', 'yes')) {
            CheckWhat = false;
        }
        if (!CheckDecimalPlus(txtColorPagesPerMinute1.value, 'spn_txtColorPagesPerMinute1', 'spn_txtColorPagesPerMinute1_number', 'yes')) {
            CheckWhat = false;
        }
        if (!CheckDecimalPlus(txtHourlyCharge.value, 'spn_txtHourlyCharge', 'spn_txtHourlyCharge_number', 'yes')) {
            CheckWhat = false;
        }
        if (!IsDecimalValue(txtspeedMarkup.value, 'spn_txtspeedMarkup')) {
            CheckWhat = false;
        }

        //second row

        if (!IsDecimalValue(txtBlackGSM2.value, 'spn_txtBlackGSM2_number')) {
            CheckWhat = false;
        }
        if (!IsDecimalValue(txtBlackPagesPerMinute2.value, 'spn_txtBlackPagesPerMinute2_number')) {
            CheckWhat = false;
        }
        if (!IsDecimalValue(txtColorGSM2.value, 'spn_txtColorGSM2_number')) {
            CheckWhat = false;
        }
        if (!IsDecimalValue(txtColorPagesPerMinute2.value, 'spn_txtColorPagesPerMinute2_number')) {
            CheckWhat = false;
        }
        //third row 
        if (!IsDecimalValue(txtBlackGSM3.value, 'spn_txtBlackGSM3_number')) {
            CheckWhat = false;
        }
        if (!IsDecimalValue(txtBlackPagesPerMinute3.value, 'spn_txtBlackPagesPerMinute3_number')) {
            CheckWhat = false;
        }
        if (!IsDecimalValue(txtColorGSM3.value, 'spn_txtColorGSM3_number')) {
            CheckWhat = false;
        }
        if (!IsDecimalValue(txtColorPagesPerMinute3.value, 'spn_txtColorPagesPerMinute3_number')) {
            CheckWhat = false;
        }
        hid_ddlMethodSelected.value = "SpeedWeightLookup";

    }
    else if (ddlMethod.value == "clickchargezonelookup") {
        for (var i = 1; i <= ItemsCounter; i++) {

            if (document.getElementById("txtBlackFrom" + i) != null && document.getElementById("txtBlackFrom" + i) != undefined &&
                document.getElementById("txtColorFrom" + i) != null && document.getElementById("txtColorFrom" + i) != undefined) {
                var val = document.getElementById("txtBlackFrom" + i).value;
                var val1 = document.getElementById("txtBlackTo" + i).value;
                var val2 = document.getElementById("txtBlackChargableSheets" + i).value;
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
                if (hdn_ClickChargeZoneLookupBlack.value == '') {
                    hdn_ClickChargeZoneLookupBlack.value = val + "~" + val1 + "~" + val2 + "~" + val3 + "~" + val4 + "~" + val5 + "~" + val6 + "";
                } else {
                    hdn_ClickChargeZoneLookupBlack.value = hdn_ClickChargeZoneLookupBlack.value + "$" + val + "~" + val1 + "~" + val2 + "~" + val3 + "~" + val4 + "~" + val5 + "~" + val6 + "";
                }

                var Color = document.getElementById("txtColorFrom" + i).value;
                var Color1 = document.getElementById("txtColorTo" + i).value;
                var Color2 = document.getElementById("txtColorChargableSheets" + i).value;
                var Color3 = document.getElementById("txtColorCost" + i).value;
                var Color4 = document.getElementById("txtColorChargableRate" + i).value;
                var Color5 = document.getElementById("txtColorMarkup" + i).value;
                var Color6 = document.getElementById("hid_ColorClickChargeZoneLookupID_" + i).value;
                if (trim12(Color1) == '' || trim12(Color2) == '' || trim12(Color3) == '' || trim12(Color4) == '') {
                    document.getElementById("spn_Color_" + i + "").style.display = "block";
                    CheckWhat = false;
                    break;
                }
                else {
                    document.getElementById("spn_Color_" + i + "").style.display = "none";
                }

                if (hdn_ClickChargeZoneLookupColour.value == '') {
                    hdn_ClickChargeZoneLookupColour.value = Color + "~" + Color1 + "~" + Color2 + "~" + Color3 + "~" + Color4 + "~" + Color5 + "~" + Color6 + "";
                } else {
                    hdn_ClickChargeZoneLookupColour.value = hdn_ClickChargeZoneLookupColour.value + "$" + Color + "~" + Color1 + "~" + Color2 + "~" + Color3 + "~" + Color4 + "~" + Color5 + "~" + Color6 + "";
                }
            }
        }
        hid_ddlMethodSelected.value = "ClickChargeZoneLookup";
    }
    else {
        spn_ddlMethod.style.display = "block";
        CheckWhat = false;
    }
    if (CheckWhat == false) {
        return false;
    }
    else {
        //Duplicay
        if (IsDuplicate == false) {
            return true;
        }
    }
}

function ApplyToClor(obj) {
    ApplyFromBlackValueToColor();
    alert(Copied_Black_N_White_2_Color_Msg);
}

function ApplyFromBlackValueToColor() {
    for (var i = 1; i <= ItemsCounter; i++) {

        if (document.getElementById("txtBlackFrom" + i) != null && document.getElementById("txtBlackFrom" + i) != undefined &&
                document.getElementById("txtColorFrom" + i) != null && document.getElementById("txtColorFrom" + i) != undefined) {

            var val1 = document.getElementById(BlackTo + i).value;
            var val2 = document.getElementById(BlackChargableSheets + i).value;
            var val3 = document.getElementById(BlackCost + i).value;
            var val4 = document.getElementById(BlackChargableRate + i).value;
            var val5 = document.getElementById(spnBlackFrom + i).innerHTML;
            var val6 = document.getElementById(BlackMarkup + i).value;
            if (i != ItemsCounter) {
                document.getElementById(ColorFrom + i).value = val5;
            }
            document.getElementById(spnColorFrom + i).innerHTML = val5;
            document.getElementById(ColorTo + i).value = val1;
            document.getElementById(ColorChargableSheets + i).value = val2;
            document.getElementById(ColorCost + i).value = val3;
            document.getElementById(ColorChargableRate + i).value = val4;
            document.getElementById(ColorMarkup + i).value = val6;
        }
    }
}

function DigiPrevious() {
    divFeedRestriction.style.display = "block";
    divPlantCalculation.style.display = "none";
    lblheader.innerHTML = "Settings: Digital Press - Press Restrictions";
}

function MoreStock(stocktype) {
    if (stocktype == 'paper') {
        //window.open(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Paper", '', 'width=950px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');            
        // PopupCenter(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Paper", '950', '430');
        var wnd = window.radopen(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Paper&papertype=sheet", '950', '430');
        wnd.setSize(1275, 500);
        wnd.center();
        var x = wnd.getWindowBounds().x;
        var y = wnd.getWindowBounds().y;
        if (y < 0) {
            wnd.moveTo(x, 57);
        }
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }
    else if (stocktype == 'film') {
        //window.open(commonpath + "common/common_popup.aspx?type=morefilm&pg=setting", '', 'width=950px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');       
        // PopupCenter(commonpath + "common/common_popup.aspx?type=morefilm&pg=setting", '950', '430');
        window.radopen(commonpath + "common/common_popup.aspx?type=morefilm&pg=setting", '950', '430');
        SetRadWindow('divrad', 'divBackGroundNew', '200');

    }
    else if (stocktype == 'plates') {
        //window.open(commonpath + "common/common_popup.aspx?type=moreplate&pg=setting", '', 'width=950px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');        
        //PopupCenter(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=plates", '950', '430');
        window.radopen(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=plates", '950', '430');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }

    return false;
}
function MorePaper() {
    //window.open(commonpath+"common/common_popup.aspx?type=morepaper&pg=setting", '', 'width=900px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
    //PopupCenter(commonpath + "common/common_popup.aspx?type=morepaper&pg=setting", '900', '400');
    window.radopen(commonpath + "common/common_popup.aspx?type=morepaper&pg=setting", '900', '400');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
    return false;
}

/* Item Description Section */
function ShowItemDescDiv(iss) {
    iss = issvalue;
    document.getElementById(iss).style.color = "orange";
    for (var i = 1; i <= 10; i++) {
        var dd = "item_" + i;
        if (dd != iss) {
            if (document.getElementById("item_" + i) != null) {
                document.getElementById("item_" + i).style.color = "black";
                var ff = "div_" + i;
                ff = ff + i;
            }
        }
        else {
            var ff = "div_" + i;
            ff = ff + i;
        }
    }
    document.getElementById("spn_txtItemTitle").style.display = "none";
    document.getElementById("spn_txtDescription").style.display = "none";
    document.getElementById("spn_txtArtwork").style.display = "none";
    document.getElementById("spn_txtColour").style.display = "none";
    document.getElementById("spn_txtSize").style.display = "none";
    document.getElementById("spn_txtMaterial").style.display = "none";
    document.getElementById("spn_txtDelivery").style.display = "none";
    document.getElementById("spn_txtFinishing").style.display = "none";
    document.getElementById("spn_txtProofs").style.display = "none";
    document.getElementById("spn_txtPacking").style.display = "none";
    document.getElementById("spn_txtNotes").style.display = "none";
    document.getElementById("spn_txtInstructions").style.display = "none";

    document.getElementById("div_itemtitle").style.height = "25px";
    document.getElementById("div_Description").style.height = "25px";
    document.getElementById("div_Artwork").style.height = "25px";
    document.getElementById("div_Colour").style.height = "25px";
    document.getElementById("div_Size").style.height = "25px";
    document.getElementById("div_Material").style.height = "25px";
    document.getElementById("div_Delivery").style.height = "25px";
    document.getElementById("div_Finishing").style.height = "25px";
    document.getElementById("div_Proofs").style.height = "25px";
    document.getElementById("div_Packing").style.height = "25px";
    document.getElementById("div_Notes").style.height = "25px";
    document.getElementById("div_Terms").style.height = "25px";

    if (document.getElementById(iss).id == "item_1") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "S";
        ShowItemDescOnType("S");
    }
    if (document.getElementById(iss).id == "item_2") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "B";
        ShowItemDescOnType("B");
    }
    if (document.getElementById(iss).id == "item_3") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "P";
        ShowItemDescOnType("P");
    }
    if (document.getElementById(iss).id == "item_4") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "L";
        ShowItemDescOnType("L");
    }
    if (document.getElementById(iss).id == "item_5") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "W";
        ShowItemDescOnType("W");
    }
    if (document.getElementById(iss).id == "item_6") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "O";
        ShowItemDescOnType("O");
    }
    if (document.getElementById(iss).id == "item_7") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "U";
        ShowItemDescOnType("U");
    }
    if (document.getElementById(iss).id == "item_8") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "C";
        ShowItemDescOnType("C");
    }
    if (document.getElementById(iss).id == "item_9") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "F";
        ShowItemDescOnType("F");
    }
    if (document.getElementById(iss).id == "item_10") {
        document.getElementById("div_SheetFed").style.display = "block";
        hdn_EstimateType.value = "Q";
        ShowItemDescOnType("Q");
    }
    document.getElementById("div_Loading").style.display = "none";
}

function changeCssItemDesc(iss) {
    txtItemTitle.focus();
    setLoadingPositionOfDivMove(document.getElementById("div_Loading"));
    document.getElementById("div_Loading").style.display = "block";
    issvalue = iss;
    setTimeout("ShowItemDescDiv()", 2000);
}


var checkwhat = false;
function checkBlank() {
    checkwhat = true;

    if (trim12(txtItemTitleID.value) == "") {
        document.getElementById("div_itemtitle").style.height = "43px";
        document.getElementById("spn_txtItemTitle").style.display = "block";
        checkwhat = false;
    }
    if (chkDescriptionID.checked == true) {
        if (trim12(txtDescriptionID.value) == "") {
            document.getElementById("div_Description").style.height = "43px";
            document.getElementById("spn_txtDescription").style.display = "block";
            checkwhat = false;
        }
    }
    if (chkArtworkID.checked == true) {
        if (trim12(txtArtworkID.value) == "") {
            document.getElementById("div_Artwork").style.height = "43px";
            document.getElementById("spn_txtArtwork").style.display = "block";
            checkwhat = false;
        }
    }
    if (chkColourID.checked == true) {
        if (trim12(txtColourID.value) == "") {
            document.getElementById("div_Colour").style.height = "43px";
            document.getElementById("spn_txtColour").style.display = "block";
            checkwhat = false;
        }
    }
    if (chkSizeID.checked == true) {
        if (trim12(txtSizeID.value) == "") {
            document.getElementById("div_Size").style.height = "43px";
            document.getElementById("spn_txtSize").style.display = "block";
            checkwhat = false;
        }
    }
    if (chkMaterialID.checked == true) {
        if (trim12(txtMaterialID.value) == "") {
            document.getElementById("div_Material").style.height = "43px";
            document.getElementById("spn_txtMaterial").style.display = "block";
            checkwhat = false;
        }
    }
    if (chkDeliveryID.checked == true) {
        if (trim12(txtDeliveryID.value) == "") {
            document.getElementById("div_Delivery").style.height = "43px";
            document.getElementById("spn_txtDelivery").style.display = "block";
            checkwhat = false;
        }
    }

    if (chkFinishingID.checked == true) {
        if (trim12(txtFinishingID.value) == "") {
            document.getElementById("div_Finishing").style.height = "43px";
            document.getElementById("spn_txtFinishing").style.display = "block";
            checkwhat = false;
        }
    }

    if (chkProofsID.checked == true) {
        if (trim12(txtProofsID.value) == "") {
            document.getElementById("div_Proofs").style.height = "43px";
            document.getElementById("spn_txtProofs").style.display = "block";
            checkwhat = false;
        }
    }

    if (chkPackingID.checked == true) {
        if (trim12(txtPackingID.value) == "") {
            document.getElementById("div_Packing").style.height = "43px";
            document.getElementById("spn_txtPacking").style.display = "block";
            checkwhat = false;
        }
    }
    if (chkNotesID.checked == true) {
        if (trim12(txtNotesID.value) == "") {
            document.getElementById("div_Notes").style.height = "43px";
            document.getElementById("spn_txtNotes").style.display = "block";
            checkwhat = false;
        }
    }
    if (chkInstructionsID.checked == true) {
        if (trim12(txtInstructionsID.value) == "") {
            document.getElementById("div_Terms").style.height = "43px";
            document.getElementById("spn_txtInstructions").style.display = "block";
            checkwhat = false;
        }
    }
    if (checkwhat) {
        return true;
    }
    else {
        return false;
    }
}



/* End of Item Description Section */

/* Mark Up */
function ForDecimal() {
    for (var j = 1; j <= ItemsCounter; j++) {
        var txtBlckMarkup = document.getElementById(BlackMarkup + j);
        var txtBlckCost = document.getElementById(BlackCost + j);
        var txtBlckChargableRate = document.getElementById(BlackChargableRate + j);

        todecimal_function(txtBlckMarkup, txtBlckMarkup.value);
        txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckCost.value, 4, '', false, false, false);
        txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckChargableRate.value, 4, '', false, false, false);

        if (Number(txtBlckChargableRate.value) != 0 && Number(txtBlckCost.value) != 0) {
            var MarkupValue = (Number(txtBlckChargableRate.value) - Number(txtBlckCost.value)) / Number(txtBlckCost.value);
            MarkupValue = Number(MarkupValue) * 100;
            txtBlckMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
        }

        var txtColorCost = document.getElementById(ColorCost + j);
        var txtColorMarkup = document.getElementById(ColorMarkup + j)
        var txtColorChargableRate = document.getElementById(ColorChargableRate + j);

        todecimal_function(txtColorMarkup, txtColorMarkup.value);
        txtColorCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorCost.value, 4, '', false, false, false);
        txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorChargableRate.value, 4, '', false, false, false);

        if (Number(txtColorChargableRate.value) != 0 && Number(txtColorCost.value) != 0) {
            var MarkupValue1 = (Number(txtColorChargableRate.value) - Number(txtColorCost.value)) / Number(txtColorCost.value);
            MarkupValue1 = Number(MarkupValue1) * 100;
            txtColorMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue1, 0, '', false, false, false);

        }
    }
}

function SetBlackMarkupToAll(obj) {

    for (var i = 1; i <= ItemsCounter; i++) {
        if (document.getElementById("txtBlackFrom" + i) != null && document.getElementById("txtBlackFrom" + i) != undefined) {

            var txtBlckMarkup = document.getElementById(BlackMarkup + i);
            var txtBlckCost = document.getElementById(BlackCost + i);
            var txtBlckChargableRate = document.getElementById(BlackChargableRate + i);

            txtBlckMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);
            if (!isNaN(obj.value)) {
                if (!isNaN(txtBlckCost.value)) {
                    var MarkupValue = (obj.value * txtBlckCost.value) / 100;
                    var chargableRate = Number(MarkupValue) + Number(txtBlckCost.value);
                    txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, chargableRate, 4, '', false, false, false);
                }
                else {
                    txtBlckChargableRate.value = "0.00";
                }
            }
            else {
                obj.value = "0.00";
            }
            txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckCost.value, 4, '', false, false, false);
            txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckChargableRate.value, 4, '', false, false, false);
        }
    }
}

function Calculate_BlackMarkup(objval, index) {
    var txtBlckMarkup = document.getElementById(BlackMarkup + index);
    var txtBlckCost = document.getElementById(BlackCost + index);
    var txtBlckChargableRate = document.getElementById(BlackChargableRate + index);

    if (Number(objval) != 0 && Number(txtBlckCost.value) != 0) {
        var MarkupValue = (Number(objval) - Number(txtBlckCost.value)) / Number(txtBlckCost.value);
        MarkupValue = Number(MarkupValue) * 100;
        txtBlckMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
        txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckCost.value, 4, '', false, false, false);
        txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
    }
    else if (Number(objval) != 0 || Number(txtBlckCost.value) != 0) {
        txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
        txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
    }
}


function Calculate_BlackChargeableRate(objval, index, type) {
    if (type == 'cost') {
        var txtBlckMarkup = document.getElementById(BlackMarkup + index);
        var txtBlckCost = document.getElementById(BlackCost + index);
        var txtBlckChargableRate = document.getElementById(BlackChargableRate + index);
        if (Number(objval) != 0) {
            var MarkupValue = (objval * txtBlckMarkup.value) / 100;
            var BlckChargableRate = Number(MarkupValue) + Number(objval);
            txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, BlckChargableRate, 4, '', false, false, false);
        }
        else {
            objval = "0.00";
            txtBlckChargableRate.value = "0.00";
        }
        txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
        txtBlckMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckMarkup.value, 0, '', false, false, false);
        txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckChargableRate.value, 4, '', false, false, false);
    }
    else {
        var txtBlckCost = document.getElementById(BlackCost + index);
        var txtBlckChargableRate = document.getElementById(BlackChargableRate + index);
        var txtBlckMarkup = document.getElementById(BlackMarkup + index);

        if (!isNaN(objval)) {
            if (Number(objval) != 0) {
                var MarkupValue = (objval * txtBlckCost.value) / 100;
                var BlckChargableRate = Number(MarkupValue) + Number(txtBlckCost.value);
                txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, BlckChargableRate, 4, '', false, false, false);
                //txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckChargableRate.value, 4, '', false, false, false);
            }
        }
        else {
            txtBlckChargableRate.value = txtBlckCost.value;
        }
        txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckCost.value, 4, '', false, false, false);
        txtBlckMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 0, '', false, false, false);
        txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckChargableRate.value, 4, '', false, false, false);
    }
}

function SetColorMarkupToAll(obj) {
    for (var j = 1; j <= ItemsCounter; j++) {
        var txtColorMarkup = document.getElementById(ColorMarkup + j);
        var txtColorCost = document.getElementById(ColorCost + j);
        var txtColorChargableRate = document.getElementById(ColorChargableRate + j);

        txtColorMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);
        if (!isNaN(obj.value)) {
            if (!isNaN(txtColorCost.value)) {
                var MarkupValue = (obj.value * txtColorCost.value) / 100;
                txtColorChargableRate.value = Number(MarkupValue) + Number(txtColorCost.value);
            }
            else {
                txtColorChargableRate.value = "0.00";
            }
        }
        else {
            obj.value = "0.00";
        }

        txtColorCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorCost.value, 4, '', false, false, false);
        txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorChargableRate.value, 4, '', false, false, false);
    }
}

function Calculate_ColorMarkup(objval, index) {
    var txtColorMarkup = document.getElementById(ColorMarkup + index);
    var txtColorCost = document.getElementById(ColorCost + index);
    var txtColorChargableRate = document.getElementById(ColorChargableRate + index);

    if (Number(objval) != 0 && Number(txtColorCost.value) != 0) {
        var MarkupValue = (Number(objval) - Number(txtColorCost.value)) / Number(txtColorCost.value);
        MarkupValue = Number(MarkupValue) * 100;
        txtColorMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
        txtColorCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorCost.value, 4, '', false, false, false);
        txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
    }
    else if (Number(objval) != 0 || Number(txtColorCost.value) != 0) {
        txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
        txtColorCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
    }
}


function Calculate_ColorChargeableRate(objval, index, type) {

    var txtColorChargableRate = document.getElementById(ColorChargableRate + index);
    var txtColorMarkup = document.getElementById(ColorMarkup + index);
    var txtColorCost = document.getElementById(ColorCost + index);
    if (type == 'cost') {
        if (Number(objval) != 0) {
            var MarkupValue = (objval * txtColorMarkup.value) / 100;
            txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(objval), 4, '', false, false, false);
            txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorChargableRate.value, 4, '', false, false, false);
        }
        else {
            objval = "0.00";
            txtColorChargableRate.value = "0.00";
        }
        txtColorCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
        txtColorMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorMarkup.value, 0, '', false, false, false);
        txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorChargableRate.value, 4, '', false, false, false);
    }
    else {
        if (!isNaN(objval)) {
            if (Number(objval) != 0) {
                var MarkupValue = (objval * txtColorCost.value) / 100;
                txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(txtColorCost.value), 4, '', false, false, false);
                txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorChargableRate.value, 4, '', false, false, false);
            }
            else {
                txtColorChargableRate.value = txtColorCost.value;
            }
        }
        txtColorCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorCost.value, 4, '', false, false, false);
        txtColorMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 0, '', false, false, false);
        txtColorChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtColorChargableRate.value, 4, '', false, false, false);
    }
}

function DefaultLanding() {
    document.getElementById("div_ddlPrintSheetSize").style.display = "none";
    document.getElementById("div_ddlJobItemSize").style.display = "none";
    chkSheetSize.checked = true;
    chkJobSize.checked = true;
    document.getElementById("div_PrintSheetCustomSize").style.display = "block";
    txtsectionheight.focus();
    document.getElementById("div_JobItemCustomSize").style.display = "block";
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

function checkAll(checkAllBox) {
    var frm = document.forms[0];
    var ChkState = checkAllBox.checked;
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
        if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
            if (!e.disabled) {
                e.checked = ChkState;
            }
        }
    }
}

function imgbtnDelete_ClientClick() {
    return confirm(deleteconfirmation);
}

function CallDelete() {
    var ret = CheckOne_new();

    if (ret) {

        return true;

    }
    else {

        return false;
    }
}

function CheckOne_new() {
    var Counter = 0;
    var frm = document.forms[0];
    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
            if (!e.disabled) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
    }

    if (Number(Counter) == 0) {
        alert(selectrow);
        return false;
    }
    else {
        return window.confirm(deletealert);

    }
}


function setAsDefault(ID, val) {
    return true;
}

function Message() {
    div_message.style.display = "block";
    div_message_hide();
}

function div_message_hide() {
    window.setTimeout("closeDiv();", 3000);
}

function closeDiv() {
    div_message.style.display = "none";
}
