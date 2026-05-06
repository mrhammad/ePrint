
var div_litho_stage1 = document.getElementById("div_litho_stage1");
var div_litho_stage2 = document.getElementById("div_litho_stage2");
function LithoPrevious() {

    div_litho_stage1.style.display = "block";
    div_litho_stage2.style.display = "none";
}

var chakWhat = true;
function LithoNext() {
    var chakWhat = true;
    var div_litho_stage1 = document.getElementById("div_litho_stage1");
    var div_litho_stage2 = document.getElementById("div_litho_stage2");
    if (hdnpaperID.value == 0) {
        document.getElementById("spn_lblDefaultPaper").style.display = "none";
        chakWhat = true;
    }
    if (hdnplateID.value == 0) {
        document.getElementById("spn_lblDefaultPlates").style.display = "block";
        chakWhat = false;
    }
    if (document.getElementById("spn_txtPlantPressCheck").style.display == "block") {
        chakWhat = false;
    }
    if (CheckStringMandatory(txtLithoPressName.value, 'spn_txtLithoPressName')) {
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

    if (!IsDecimalValue(txtGutterDepthHeight.value, 'spn_GutterDepth_number')) {
        chakWhat = false;
    }

    if (txtGutterDepthHeight.value == "") {
        document.getElementById("spn_GutterDepth").style.display = "block";
        chakWhat = false;
    }

    if (!IsDecimalValue(txtGutterDepthWidtht.value, 'spn_GutterDepth_number')) {
        chakWhat = false;
    }

    if (txtGutterDepthWidtht.value == "") {
        document.getElementById("spn_GutterDepth").style.display = "block";
        chakWhat = false;
    }
    if (!IsDecimalValue(txtGutterHorizontal.value, 'spn_DefaultGuttersNumber')) {
        chakWhat = false;
    }

    if (txtGutterHorizontal.value == "") {
        document.getElementById("spn_DefaultGutters").style.display = "block";
        chakWhat = false;
    }
    if (!IsDecimalValue(txtGutterVertical.value, 'spn_DefaultGuttersNumber')) {
        chakWhat = false;
    }

    if (txtGutterVertical.value == "") {
        document.getElementById("spn_DefaultGutters").style.display = "block";
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
    //    if(hid_GuillotineID.value == 0)
    //    {
    //      document.getElementById("spn_ddlGuillotine").style.display="block";
    //      chakWhat = false;
    //    }
    if (!IsDecimalValue(txtSetupCharge.value, 'spn_txtSetupCharge_number')) {
        chakWhat = false;
    }
    if (!IsDecimalValue(txtMinRunningCharge.value, 'spn_txtMinRunningCharge_number')) {
        chakWhat = false;
    }
    if (!IsDecimalValue(txtMarkUp.value, 'spn_txtMarkUp_number')) {
        chakWhat = false;
    }

    if (trim12(txtUnitOfMeasure.value) != "" && UnitOfMeasure) {
        if (!SetNumber_OfUnit(txtUnitOfMeasure, txtUnitOfMeasure.value)) {
            spn_UnitOfMeasure.style.display = "block";
            chakWhat = false;
        }
    }


    if (chakWhat) {


        div_litho_stage1.style.display = "none";
        div_litho_stage2.style.display = "block";
        ddlMethod.focus();
    }
}



function checkfloat(obj, value) {
    if (value = value.toString().replace(".", "")) {
        obj.value = value;
        obj.focus();
        return value;
    }
    else {
        return obj.value;
    }
}

function valuecheckisnum(obj, val) {
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
function AmountRange_litho(obj, val) {
    if (val.substring(1, 0) != "-")//for NEGATIVE Values
    {
        if (!isNaN(val)) {
            val = val.substring(0, val.indexOf('.') + 1);
            val = val.replace(GetCurrencyinRequiredFormate("", true), '');
            if (trim12(val) > 1000 && trim12(val) < 2500) {
                document.getElementById("spn_txtHourlyCharge_range").style.display = "none";
                return true;
            }
            else {
                document.getElementById("spn_txtHourlyCharge_range").style.display = "block";
                return false;
            }
        }
    }
    else {
        obj.value = '';
        obj.focus();
        return false;
    }
}

function AmountTo2Decimal_litho(obj, val) {
    if (val.substring(1, 0) != "-")//for NEGATIVE Values
    {
        if (!isNaN(val)) {
            obj.value = Math.round(val * 1000) / 1000;
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

