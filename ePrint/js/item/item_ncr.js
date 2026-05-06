//validataion

var check = true;
function Litho_Validation(txtpartspersetNew) {
    txtpartsperset = txtpartspersetNew;
    check = true;
    hidpartsperset.value = txtpartsperset.value;
    hidquantityvalue1.value = txtQuantity.value;
    hidquantityvalue2.value = txtQuantity_2.value;
    hidquantityvalue3.value = txtQuantity_3.value;
    hidquantityvalue4.value = txtQuantity_4.value;
    if (txtItemTitle.value == '') {
        spn_txtItemTitle.style.display = "block";
        check = false;
    }
    document.getElementById("spn_txtSectionRef").style.display = "none";

    if (trim12(txtSectionRef.value) == "") {
        document.getElementById("spn_txtSectionRef").style.display = "block";
        IsCorrect = false;
    }
    if (txtpartsperset.value == '') {
        sp_txtpartsperset.style.display = "block";
        check = false;
    }
    if (txtsetsperpad.value == '') {
        sp_txtsetsperpad.style.display = "block";
        check = false;
    }
    //
    else {
        sp_txtsetsperpad.style.display = "none";
    }
    if (txtItemTitle.value == '') {
        spn_txtItemTitle.style.display = "block";
        check = false;
    }
    if (txtQuantity.value == '') {
        spn_txtQuantity.style.display = "block";
        check = false;
    }
    else {
        spn_txtQuantity.style.display = "none";
    }
    if (ddlPress.selectedIndex == 0) {
        spn_ddlPress.style.display = "block";
        check = false;
    }
    //
    if (ddlPress.selectedIndex > 0) {
        spn_ddlPress.style.display = "none";
    }
    if (lblDefaultPaper.innerHTML == '') {
        spn_lblDefaultPaper.style.display = "block";
        check = false;
    }
    //
    else {
        spn_lblDefaultPaper.style.display = "none";
    }
    if (txtSetupSpoilage.value == '') {
        spn_txtSetupSpoilage.style.display = "block";
        check = false;
    }
    if (txtRunningSpoilage.value == '') {
        spn_txtRunningSpoilage.style.display = "block";
        check = false;
    }
    if (txtSectionRef.value == '') {
        spn_txtSectionRef.style.display = "block";
        check = false;
    }
    else
    {
        spn_txtSectionRef.style.display = "none";
    }
    if (!chkPrintSheet.checked) {
        if (ddlPrintSheetSize.selectedIndex == 0) {
            spn_ddlPrintSheetSize.style.display = "block";
            check = false;
        }
    }
    if (!ChkJobFlatCustom.checked) {
        if (ddlJobItemSize.selectedIndex == 0) {
            spn_ddlJobItemSize.style.display = "block";
            check = false;
        }
    }
    if (lblDefaultPlates.innerHTML == "") {
        spn_lblDefaultPlates.style.display = "block";
        check = false;
    }
    //
    else {
        spn_lblDefaultPlates.style.display = "none";
    }

    hdn_PortraitValue.value = txtportrait.value;
    hdn_LandscapeValue.value = txtlandscape.value;
    hdnManual.value = txtManual.value;

    if (ddlBookletFormat.selectedIndex == 0 && parseFloat(txtportrait.value) <= 0 && chkPortrait.checked == true) {
        spn_Printlayout.style.display = "block";
        check = false;
    }
    //
    else {
        spn_Printlayout.style.display = "none";
    }
    if (ddlBookletFormat.selectedIndex == 1 && parseFloat(txtlandscape.value) <= 0 && chkLandscape.checked == true) {
        spn_Printlayout.style.display = "block";
        check = false;
    }
    //
    else {
        spn_Printlayout.style.display = "none";
    }
    if (chkManual.checked == true) {
        if (parseFloat(txtManual.value) <= 0) {
            spn_Printlayout.style.display = "block";
            check = false;

        }
    }
    if (check == false) {
        return false;
    }
    else {
        return true;
    }
}
//end validation

var ncrArray = new Array();
function ItemClass() {
    this.Title;
    this.Quantity1;
    this.Quantity2;
    this.Quantity3;
    this.Quantity4;
    this.Partsperset;
    this.Setsperpad;
    this.Sectionreference;
    this.Assignedpress;
    this.PaperID;
    this.PaperName;
    this.PriceForWhaolePack;
    this.PaperSupplied;
    this.Setupspoilage;
    this.Runningspoilage;
    this.Noofsidesprinted;
    this.Side1color;
    this.Side2color;
    this.Checkturn;
    this.Checktumble;
    this.Platename;
    this.PlateID;
    this.Plate;
    this.Makeready;
    this.Washup;
    this.PrintSheetSizeID;
    this.IsPrintCustom;
    this.PrintSheetHeight;
    this.PrintSheetWidth;
    this.JobFlatSizeID;
    this.IsJobCustom;
    this.JobFlatSizeHeight;
    this.JobFlatSizeWidth;
    this.IsIncludeGutters;
    this.GutterHorizontal;
    this.GutterVertical;
    this.IsPressRestrictions;
    this.GuilotineID;
    this.GuilotineName;
    this.IsFirstTrim;
    this.IsSecondTrim;
    this.PrintLayout;
    this.Portraitvalue;
    this.Landscapevalue;
    this.Ncrcommonuncommon;
    this.Ncrcommonfrom;
    this.MakeReadyPerPlateCheck;
    this.WashupChargePerColourCheck;
    this.EstimateLithoNCRItemID
    this.EstimateCalculationID;
    this.NCRside1inkvalue;
    this.NCRside2inkvalue;
    this.CheckPerfecting;
    this.PaperWeight;
    this.ManualValue;
    //commonfrom
}

function storedata(thisvalue, totalno) {
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    hid_previous_add.value = thisvalue;
    hid_partperset.value = thisvalue;
    var ncritem = new ItemClass();
    ncritem.Title = txtItemTitle.value;
    ncritem.Quantity1 = txtQuantity.value;
    ncritem.Quantity2 = txtQuantity_2.value;
    ncritem.Quantity3 = txtQuantity_3.value;
    ncritem.Quantity4 = txtQuantity_4.value;
    ncritem.Partsperset = txtpartsperset.value;
    ncritem.Setsperpad = txtsetsperpad.value;

    var partnumber = "Part 1";
    if (thisvalue == 0) {
        partnumber = "Part 1";
    }
    if (thisvalue == 1) {
        partnumber = "Part 1";
    }
    if (thisvalue == 2) {
        partnumber = "Part 2";
    }
    if (thisvalue == 3) {
        partnumber = "Part 3";
    }
    if (thisvalue == 4) {
        partnumber = "Part 4";
    }
    if (thisvalue == 5) {
        partnumber = "Part 5";
    }
    if (thisvalue == 6) {
        partnumber = "Part 6";
    }
    if (thisvalue == 7) {
        partnumber = "Part 7";
    }
    if (thisvalue == 8) {
        partnumber = "Part 8";
    }
    if (thisvalue == 9) {
        partnumber = "Part 9";
    }

    if (hid_incrementvalue.value == '0') {
        ncritem.Sectionreference = partnumber;
    }
    else {
        ncritem.Sectionreference = txtSectionRef.value;
    }

    //by kumar on 20 jan 2011
    ncritem.Assignedpress = Number(hdn_PressID.value); //ddlPress.value;
    ncritem.PaperID = hdnpaperID.value;
    ncritem.PaperName = lblDefaultPaper.innerHTML;
    ncritem.PaperWeight = lblPaperWeight.innerHTML;
    ncritem.PriceForWhaolePack = ChkPriceForWholePack.checked;
    ncritem.PaperSupplied = ChkPaperSupplied.checked;
    ncritem.Setupspoilage = txtSetupSpoilage.value;
    ncritem.Runningspoilage = txtRunningSpoilage.value;
    ncritem.Noofsidesprinted = ddlNoOfSide.options[ddlNoOfSide.selectedIndex].text;
    ncritem.Side1color = ddlSide1Color.options[ddlSide1Color.selectedIndex].text;
    ncritem.Side2color = ddlSide2Color.options[ddlSide2Color.selectedIndex].text;
    ncritem.Checkturn = chkTurn.checked;
    ncritem.Checktumble = chkTumble.checked;
    ncritem.Platename = lblDefaultPlates.innerHTML;
    ncritem.PlateID = hdnplateID.value;
    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
    ncritem.Plate = txtNoOfPlates.value;
    ncritem.Makeready = txtNoOfMakeReady.value;
    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121 

    ncritem.Washup = ddlWashUp.value;
    ncritem.PrintSheetSizeID = ddlPrintSheetSize.value;
    ncritem.IsPrintCustom = chkPrintSheet.checked;
    ncritem.PrintSheetHeight = txtsectionheight.value;
    ncritem.PrintSheetWidth = txtsectionwidth.value;
    ncritem.JobFlatSizeID = ddlJobItemSize.value;
    ncritem.IsJobCustom = ChkJobFlatCustom.checked;
    ncritem.JobFlatSizeHeight = txtitemheight.value;
    ncritem.JobFlatSizeWidth = txtitemwidth.value;
    ncritem.IsIncludeGutters = chkGutters.checked;
    ncritem.GutterHorizontal = txtGutterHorizontal.value;
    ncritem.GutterVertical = txtGutterVertical.value;
    ncritem.IsPressRestrictions = ChkPressRestrictions.checked;
    ncritem.GuilotineID = hid_GuillotineID.value;
    ncritem.GuilotineName = lblGuillotine.innerHTML;
    ncritem.IsFirstTrim = chkFirstTrim.checked;
    ncritem.IsSecondTrim = chkSecondTrim.checked;
    ncritem.PrintLayout = ddlBookletFormat.value;
    ncritem.Portraitvalue = hdn_Protrait.value;
    ncritem.Landscapevalue = hdn_Landscale.value;
    ncritem.ManualValue = hdnManual.value;

    if (radiocommon.checked == true) {
        ncritem.Ncrcommonuncommon = "common";
        ncritem.Ncrcommonfrom = ddlcommonfrom.options[ddlcommonfrom.selectedIndex].text;
    }
    else if (radiouncommon.checked == true) {
        ncritem.Ncrcommonuncommon = "uncommon";
        ncritem.Ncrcommonfrom = 'Top Section';
    }
    else {
        ncritem.Ncrcommonuncommon = 'uncommon';
    }
    ncritem.CheckPerfecting = chkPerfecting.checked;

    ncritem.MakeReadyPerPlateCheck = hid_makeready.value;
    ncritem.WashupChargePerColourCheck = hid_washup.value;

    ncritem.EstimateLithoNCRItemID = NcrEditID;

    ncritem.NCRside1inkvalue = hid_FinalInkSave1.value;
    ncritem.NCRside2inkvalue = hid_FinalInkSave2.value;

    if (QueryType == "add" || QueryType == "edit") {
        if (thisvalue == '0') {
            ncrArray.splice(0, 1, ncritem);
        }
        else if (thisvalue == '1') {
            ncrArray.splice(0, 1, ncritem);
        }
        else if (thisvalue == '2') {
            ncrArray.splice(1, 1, ncritem);
        }
        else if (thisvalue == '3') {
            ncrArray.splice(2, 1, ncritem);
        }
        else if (thisvalue == '4') {
            ncrArray.splice(3, 1, ncritem);
        }
        else if (thisvalue == '5') {
            ncrArray.splice(4, 1, ncritem);
        }
        else if (thisvalue == '6') {
            ncrArray.splice(5, 1, ncritem);
        }
        else if (thisvalue == '7') {
            ncrArray.splice(6, 1, ncritem);
        }
        else if (thisvalue == '8') {
            ncrArray.splice(7, 1, ncritem);
        }
        else if (thisvalue == '9') {
            ncrArray.splice(8, 1, ncritem);
        }
    }
}

function SaveData(txtpartspersetNew) {
    txtpartsperset = txtpartspersetNew;
    var StoreNcr = '';
    for (var i = 0; i < ncrArray.length; i++) {

        StoreNcr += "Title»" + txtItemTitle.value + '±';
        StoreNcr += "Quantity1»" + txtQuantity.value + '±';
        StoreNcr += "Quantity2»" + txtQuantity_2.value + '±';
        StoreNcr += "Quantity3»" + txtQuantity_3.value + '±';
        StoreNcr += "Quantity4»" + txtQuantity_4.value + '±';
        StoreNcr += "Partsperset»" + txtpartsperset.value + '±';
        StoreNcr += "Setsperpad»" + txtsetsperpad.value + '±';
        StoreNcr += "Sectionreference»" + ncrArray[i].Sectionreference + '±';
        StoreNcr += "Assignedpress»" + ncrArray[i].Assignedpress + '±';
        StoreNcr += "PaperID»" + ncrArray[i].PaperID + '±';
        StoreNcr += "PaperName»" + ncrArray[i].PaperName + '±';
        StoreNcr += "PriceForWhaolePack»" + ncrArray[i].PriceForWhaolePack + '±';
        StoreNcr += "PaperSupplied»" + ncrArray[i].PaperSupplied + '±';
        StoreNcr += "Setupspoilage»" + ncrArray[i].Setupspoilage + '±';
        StoreNcr += "Runningspoilage»" + ncrArray[i].Runningspoilage + '±';
        StoreNcr += "Noofsidesprinted»" + ncrArray[i].Noofsidesprinted + '±';
        StoreNcr += "Side1color»" + ncrArray[i].Side1color + '±';
        StoreNcr += "Side2color»" + ncrArray[i].Side2color + '±';
        StoreNcr += "Checkturn»" + ncrArray[i].Checkturn + '±';
        StoreNcr += "Checktumble»" + ncrArray[i].Checktumble + '±';
        StoreNcr += "Platename»" + ncrArray[i].Platename + '±';
        StoreNcr += "PlateID»" + ncrArray[i].PlateID + '±';
        StoreNcr += "Plate»" + ncrArray[i].Plate + '±';
        StoreNcr += "Makeready»" + ncrArray[i].Makeready + '±';
        StoreNcr += "Washup»" + ncrArray[i].Washup + '±';
        //print sheet recuiremnt 
        StoreNcr += "PrintSheetSizeID »" + ncrArray[i].PrintSheetSizeID + '±';
        StoreNcr += "IsPrintCustom »" + chkPrintSheet.checked + '±';
        //        StoreNcr += "PrintSheetHeight »" + ncrArray[i].PrintSheetHeight + '±';
        //        StoreNcr += "PrintSheetWidth »" + ncrArray[i].PrintSheetWidth + '±';

        StoreNcr += "PrintSheetHeight »" + txtsectionheight.value + '±';
        StoreNcr += "PrintSheetWidth »" + txtsectionwidth.value + '±';

        //job sheet recuirement
        StoreNcr += "JobFlatSizeID »" + ncrArray[i].JobFlatSizeID + '±';
        StoreNcr += "IsJobCustom »" + ChkJobFlatCustom.checked + '±';
        //        StoreNcr += "JobFlatSizeHeight »" + ncrArray[i].JobFlatSizeHeight + '±';
        //        StoreNcr += "JobFlatSizeWidth »" + ncrArray[i].JobFlatSizeWidth + '±';

        StoreNcr += "JobFlatSizeHeight »" + txtitemheight.value + '±';
        StoreNcr += "JobFlatSizeWidth »" + txtitemwidth.value + '±';
        //gutter
        StoreNcr += "IsIncludeGutters »" + chkGutters.checked + '±';
        StoreNcr += "GutterHorizontal »" + ncrArray[i].GutterHorizontal + '±';
        StoreNcr += "GutterVertical »" + ncrArray[i].GutterVertical + '±';
        //press restriction
        StoreNcr += "IsPressRestrictions »" + ncrArray[i].IsPressRestrictions + '±';
        //guillotine
        StoreNcr += "GuilotineID »" + ncrArray[i].GuilotineID + '±';
        StoreNcr += "GuilotineName »" + ncrArray[i].GuilotineName + '±';
        //firstand second trim
        StoreNcr += "IsFirstTrim »" + ncrArray[i].IsFirstTrim + '±';
        StoreNcr += "IsSecondTrim »" + ncrArray[i].IsSecondTrim + '±';
        //print layout
        var PrintLayout1 = "L";
        //if (document.getElementById("ctl00_ContentPlaceHolder1_UCNCRItem_chkPortrait").checked) {
        //    PrintLayout1 = "P";
        //}
        if (chkManual.checked) {
            PrintLayout1 = "M";
        } else if (chkLandscape.checked) {
            PrintLayout1 = "L";
        } else {
            PrintLayout1 = "P";
        }
        StoreNcr += "PrintLayout »" + PrintLayout1 + '±';
        StoreNcr += "Portraitvalue »" + hdn_Protrait.value + '±';  //ncrArray[i].Portraitvalue
        StoreNcr += "Landscapevalue »" + hdn_Landscale.value + '±'; //ncrArray[i].Landscapevalue 

        StoreNcr += "ManualValue »" + hdnManual.value + '±'; 

        StoreNcr += "Ncrcommonuncommon »" + ncrArray[i].Ncrcommonuncommon + '±';
        StoreNcr += "Ncrcommonfrom »" + ncrArray[i].Ncrcommonfrom + '±';

        StoreNcr += "NCRside1inkvalue »" + ncrArray[i].NCRside1inkvalue + '±';
        StoreNcr += "NCRside2inkvalue »" + ncrArray[i].NCRside2inkvalue + '±';
        StoreNcr += "CheckPerfecting »" + ncrArray[i].CheckPerfecting + '±';

        StoreNcr += "EstimateLithoNCRItemID »" + ncrArray[i].EstimateLithoNCRItemID + '±';
        StoreNcr += "µ";
    }
    hid_ncrdata.value = StoreNcr;
}

function GenerateSection() {
    var str = '';
    var txtval = ncrArray.length;
    for (var i = 1; i <= ncrArray.length; i++) {
        str += "<div style='float:left;clear:right;'>";
        if (i == '1') {
            str += "<div style='float:left; padding-right: 4px;'><input type='button' style='padding-bottom: 5px;' onclick=LoadData(" + i + ",'edit'," + i + "); id=btn" + i + " class='booklet_section_active' value=Part" + '&nbsp;' + "" + (i) + " ></div>";
        }
        else if (i != '1') {
            str += "<div style='float:left; padding-right: 4px;'><input type='button' style='padding-bottom: 5px;'  onclick=LoadData(" + i + ",'edit'," + i + ");  id=btn" + i + " class='button' value=Part" + '&nbsp;' + "" + (i) + " ></div>";
        }
        str += "</div>";
    }
    document.getElementById("div_NCRbtn").innerHTML = str;
    document.getElementById("div_NCRbtn").style.width = '105%';
}


function LoadToSheetCustom(ddlValue) {
    if (ddlValue == "0") {
        txtsectionheight.value = '';
        txtsectionwidth.value = '';
        chkPrintSheet.checked = false;
        PrintSheetCustom(chkPrintSheet.id);
    }
    else {
        var arr1 = hid_ddlPrintSheetSize.value.split('µ');

        for (var i = 0; i < arr1.length; i++) {
            var arr2 = arr1[i].split('±');
            if (ddlValue == arr2[0]) {
                txtsectionheight.value = arr2[2];
                txtsectionwidth.value = arr2[3];
            }
        }
    }
}

function LoadToItemCustom(ddlValue) {
    if (ddlValue == "0") {
        txtitemheight.value = '';
        txtitemwidth.value = '';

        ChkJobFlatCustom.checked = false;
        JobItemCustom(ChkJobFlatCustom.id);
    }
    else {
        var arr1 = hid_ddlPrintSheetSize.value.split('µ');
        for (var i = 0; i < arr1.length; i++) {
            var arr2 = arr1[i].split('±');
            if (ddlValue == arr2[0]) {
                txtitemheight.value = arr2[2];
                txtitemwidth.value = arr2[3];
            }
        }
    }
}

function PrintSheetCustom(chID) {
    document.getElementById("div_ddlPrintSheetSize").style.display = "none";
    document.getElementById("div_PrintSheetCustomSize").style.display = "none";
    var chCheck = document.getElementById(chID).checked;
    if (chCheck) {
        document.getElementById("div_PrintSheetCustomSize").style.display = "block";
    }
    else {
        document.getElementById("div_ddlPrintSheetSize").style.display = "block";
    }
}

function JobItemCustom(chID) {
    document.getElementById("div_ddlJobItemSize").style.display = "none";
    document.getElementById("div_JobItemCustomSize").style.display = "none";
    var chCheck = document.getElementById(chID).checked;
    if (chCheck) {
        document.getElementById("div_JobItemCustomSize").style.display = "block";
    }
    else {
        document.getElementById("div_ddlJobItemSize").style.display = "block";
    }
}

function GuttersCustom(chID) {
    document.getElementById("div_GuttersCustomSize").style.display = "none";
    var chCheck = document.getElementById(chID).checked;
    if (chCheck) {
        document.getElementById("div_GuttersCustomSize").style.display = "block";
    }
    else {
        document.getElementById("div_GuttersCustomSize").style.display = "none";
    }
}


function Gethideoneditcase(txtvaaal) {
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    if (txtvaaal.length > 1) {
        txtvaaal = txtvaaal.substring(txtvaaal.length - 1, txtvaaal.length);
    }
    if (txtvaaal == '1') {
        txtsetsperpad.disabled = false;
        txtQuantity.disabled = false;
        txtQuantity_2.disabled = false;
        txtQuantity_3.disabled = false;
        txtQuantity_4.disabled = false;

        if (QueryType == 'add') {
            txtpartsperset.disabled = false;
        }
        else if (QueryType == 'edit') {
            txtpartsperset.disabled = false;
        }
        ddlPress.disabled = false;
        txtRunningSpoilage.disabled = false;
        txtSetupSpoilage.disabled = false;
        ddlPrintSheetSize.disabled = false;
        ddlJobItemSize.disabled = false;
        ddlBookletFormat.disabled = false;
        txtGutterHorizontal.disabled = false;
        txtGutterVertical.disabled = false;
        chkGutters.disabled = false;
        ChkPressRestrictions.disabled = false;
        chkFirstTrim.disabled = false;
        chkSecondTrim.disabled = false;
        chkPrintSheet.disabled = false;
        txtsectionheight.disabled = false;
        txtsectionwidth.disabled = false;
        ChkJobFlatCustom.disabled = false;
        txtitemheight.disabled = false;
        txtitemwidth.disabled = false;
        divimagetype.style.display = "none";

        chkLandscape.disabled = false;
        chkPortrait.disabled = false;
        txtportrait.disabled = false;
        chkManual.disabled = false;
        txtlandscape.disabled = false;

        if (radiocommon.checked == true) {
            ddlPlates.disabled = false;
            ddlWashUp.disabled = false;
            ddlMakeReady.disabled = false;

            //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
            txtNoOfPlates.disabled = false;
            txtNoOfMakeReady.disabled = false;
            //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
        }
        //hid_incrementvalue.value = "1";
        divguillotineplusimg.style.display = "block";
    }
    if (txtvaaal == '2') {
        txtQuantity.disabled = true;
        txtQuantity_2.disabled = true;
        txtQuantity_3.disabled = true;
        txtQuantity_4.disabled = true;
        txtpartsperset.disabled = true;
        txtsetsperpad.disabled = true;
    }

    if (txtvaaal == '3') {
        txtpartsperset.disabled = true;
        txtsetsperpad.disabled = true;
        txtQuantity.disabled = true;
        txtQuantity_2.disabled = true;
        txtQuantity_3.disabled = true;
        txtQuantity_4.disabled = true;
    }

    if (txtvaaal != '1') {
        txtQuantity.disabled = true;
        txtQuantity_2.disabled = true;
        txtQuantity_3.disabled = true;
        txtQuantity_4.disabled = true;
        txtpartsperset.disabled = true;
        txtsetsperpad.disabled = true;
        ddlPress.disabled = true;
        txtRunningSpoilage.disabled = true;
        txtSetupSpoilage.disabled = true;

        ddlPrintSheetSize.disabled = true;
        ddlJobItemSize.disabled = true;
        ddlBookletFormat.disabled = true;
        txtGutterHorizontal.disabled = true;
        txtGutterVertical.disabled = true;

        chkGutters.disabled = true;
        ChkPressRestrictions.disabled = true;
        chkFirstTrim.disabled = true;
        chkSecondTrim.disabled = true;
        chkPrintSheet.disabled = true;
        txtsectionheight.disabled = true;
        txtsectionwidth.disabled = true;
        ChkJobFlatCustom.disabled = true;
        txtitemheight.disabled = true;
        txtitemwidth.disabled = true;
        divimagetype.style.display = "block";

        chkLandscape.disabled = true;
        chkPortrait.disabled = true;
        txtportrait.disabled = true;
        chkManual.disabled = true;
        txtlandscape.disabled = true;
        if (radiocommon.checked == true) {
            ddlPlates.disabled = true;
            ddlWashUp.disabled = true;
            ddlMakeReady.disabled = true;

            //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
            txtNoOfPlates.disabled = true;
            txtNoOfMakeReady.disabled = true;
            //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
        }
        //changes added for on rerun case if user click other than part1 . guillotine selection shd not visible
        divguillotineplusimg.style.display = "none";
    }

    var totalno = 9;
    for (var i = 1; i <= totalno; i++) {
        if (i == 1) {
            document.getElementById("btn1").className = "booklet_section_active";
            document.getElementById("btn1").style = "padding-bottom: 5px;";
        }
        else if (document.getElementById("btn" + i + "") != null && document.getElementById("btn" + i + "") != undefined) {
            document.getElementById("btn" + i + "").className = "button";
        }
    }

    for (var j = 1; j <= ncrArray.length; j++) {
        if (j == txtvaaal) {
            if (txtvaaal == 1) {

                commonfrom.style.display = "none";
            }
            else if (txtvaaal == ncrArray.length) {

                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                for (var m = 1; m < ncrArray.length; m++) {
                    if (m == '1') {
                        ddlcommonfrom.options.add(new Option("Part 1", 1));
                    }
                    if (m == '2') {
                        ddlcommonfrom.options.add(new Option("Part 2", 2));
                    }
                    if (m == '3') {
                        ddlcommonfrom.options.add(new Option("Part 3", 3));
                    }
                    if (m == '4') {
                        ddlcommonfrom.options.add(new Option("Part 4", 4));
                    }
                    if (m == '5') {
                        ddlcommonfrom.options.add(new Option("Part 5", 5));
                    }
                    if (m == '6') {
                        ddlcommonfrom.options.add(new Option("Part 6", 6));
                    }
                    if (m == '7') {
                        ddlcommonfrom.options.add(new Option("Part 7", 7));
                    }
                    if (m == '8') {
                        ddlcommonfrom.options.add(new Option("Part 8", 8));
                    }
                }
            }
            else if (txtvaaal == '2') {

                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
            }
            else if (txtvaaal == '3') {
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
            }
            else if (txtvaaal == '4') {
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
            }
            else if (txtvaaal == '5') {

                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
                ddlcommonfrom.options.add(new Option("Part 4", 4));
            }
            else if (txtvaaal == '6') {

                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
                ddlcommonfrom.options.add(new Option("Part 4", 4));
                ddlcommonfrom.options.add(new Option("Part 5", 5));
            }
            else if (txtvaaal == '7') {

                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
                ddlcommonfrom.options.add(new Option("Part 4", 4));
                ddlcommonfrom.options.add(new Option("Part 5", 5));
                ddlcommonfrom.options.add(new Option("Part 6", 6));
            }
            else if (txtvaaal == '8') {
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
                ddlcommonfrom.options.add(new Option("Part 4", 4));
                ddlcommonfrom.options.add(new Option("Part 5", 5));
                ddlcommonfrom.options.add(new Option("Part 6", 6));
                ddlcommonfrom.options.add(new Option("Part 7", 7));
            }
        }
    }

    if (radiouncommon.checked == true) {
        ddlPlates.disabled = false;
        ddlWashUp.disabled = false;
        ddlMakeReady.disabled = false;
        divcommonfrom.style.display = "none";

        //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
        txtNoOfPlates.disabled = false;
        txtNoOfMakeReady.disabled = false;
        //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
    }

}

function ClaerSectionData() {
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    txtQuantity.value = "";
    txtQuantity_2.value = "";
    txtQuantity_3.value = "";
    txtQuantity_4.value = "";
    txtpartsperset.value = "";
    txtsetsperpad.value = "";
    txtSectionRef.value = "";
    ChkPriceForWholePack.checked = false;
    ddlPress.selectedIndex = 0;
    txtSetupSpoilage.value = "";
    txtRunningSpoilage.value = "";
    lblDefaultPaper.innerHTML = "";
    ChkPriceForWholePack.checked = false;
}

function LoadonEdit() {
    debugger;
    const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
    const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    var str = hid_ncreditdata.value.split('µ');
    for (var i = 0; i < str.length - 1; i++) {
        var ncritem = new ItemClass();
        if (str[i] != '') {
            var arr_1 = str[i].split('±');
            for (var j = 0; j < arr_1.length; j++) {
                var arr_2 = arr_1[j].split('»');

                if (arr_2[0] == "ItemTitle") {
                    txtItemTitle.value = arr_2[1];
                    ncritem.Title = arr_2[1];
                }
                if (arr_2[0] == "Qty1") {
                    if (arr_2[1] != 0) {
                        txtQuantity.value = arr_2[1];
                    }
                    else {
                        txtQuantity.value = '';
                    }
                    ncritem.Quantity1 = arr_2[1];
                }
                if (arr_2[0] == "Qty2") {
                    if (arr_2[1] != 0) {
                        txtQuantity_2.value = arr_2[1];
                    } else {
                        txtQuantity_2.value = '';
                    }
                    ncritem.Quantity2 = arr_2[1];
                }
                if (arr_2[0] == "Qty3") {
                    if (arr_2[1] != 0) {
                        txtQuantity_3.value = arr_2[1];
                    } else {
                        txtQuantity_3.value = '';

                    }
                    ncritem.Quantity3 = arr_2[1];
                }
                if (arr_2[0] == "Qty4") {
                    if (arr_2[1] != 0) {
                        txtQuantity_4.value = arr_2[1];
                    } else {
                        txtQuantity_4.value = '';
                    }
                    ncritem.Quantity4 = arr_2[1];
                }
                if (arr_2[0] == "PartsPerSet") {
                    txtpartsperset.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, '', true, false, false);
                    ncritem.Partsperset = arr_2[1];
                }
                if (arr_2[0] == "Setsperpad") {
                    txtsetsperpad.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, '', true, false, false);
                    ncritem.Setsperpad = arr_2[1];
                }
                if (arr_2[0] == "Sectionreference") {
                    txtSectionRef.value = arr_2[1];
                    ncritem.Sectionreference = arr_2[1];
                }

                if (arr_2[0] == "Assignedpress") {
                    for (var k = 0; k < ddlPress.length; k++) {
                        if (ddlPress.options[k].value == arr_2[1]) {
                            ddlPress.selectedIndex = k;
                        }
                    }
                    ncritem.Assignedpress = arr_2[1];
                }

                if (arr_2[0] == "Paper") {

                    hdnpaperID.value = arr_2[1];
                    lblDefaultPaper.innerHTML = arr_2[2];
                    lblDefaultPaper.title = arr_2[2];

                    if (arr_2[3] == 'True') {
                        ChkPriceForWholePack.checked = true;
                    }
                    else {
                        ChkPriceForWholePack.checked = false;
                    }

                    if (arr_2[4] == 'True') {
                        ChkPaperSupplied.checked = true;
                    }
                    else {
                        ChkPaperSupplied.checked = false;
                    }
                    ncritem.PaperID = arr_2[1];
                    ncritem.PaperName = arr_2[2];
                    ncritem.PriceForWhaolePack = ChkPriceForWholePack.checked;
                    ncritem.PaperSupplied = ChkPaperSupplied.checked;

                    try {
                        PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
                    }
                    catch (error) { }
                }
                if (arr_2[0] == "SetupSpoilage") {

                    txtSetupSpoilage.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, '', true, false, false);
                    ncritem.Setupspoilage = arr_2[1];
                }
                if (arr_2[0] == "InkType") {
                    hdn_InkType.value = arr_2[1];
                }

                if (arr_2[0] == "isPressPerfect") {
                    hid_isPressPerfect.value = arr_2[1];
                }
                if (arr_2[0] == "PaperWeight") {
                    lblPaperWeight.innerHTML = arr_2[1];
                    ncritem.PaperWeight = arr_2[1];
                }


                if (arr_2[0] == "RunningSpoilage") {
                    txtRunningSpoilage.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, '', false, false, false);
                    ncritem.Runningspoilage = arr_2[1];
                }
                if (arr_2[0] == "Plates") {

                    hdnplateID.value = arr_2[1];
                    lblDefaultPlates.innerHTML = arr_2[2];
                    ncritem.PlateID = arr_2[1];
                    ncritem.Platename = arr_2[2];
                }
                if (arr_2[0] == "NoofPlate") {
                    for (var k = 0; k < ddlPlates.length; k++) {
                        if (ddlPlates.options[k].value == arr_2[1]) {
                            ddlPlates.selectedIndex = k;
                        }
                    }

                    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
                    txtNoOfPlates.value = arr_2[1];
                    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121

                    ncritem.Plate = arr_2[1];

                }
                if (arr_2[0] == "Makeready") {
                    for (var k = 0; k < ddlMakeReady.length; k++) {
                        if (ddlMakeReady.options[k].value == arr_2[1]) {
                            ddlMakeReady.selectedIndex = k;
                        }
                    }

                    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
                    txtNoOfMakeReady.value = arr_2[1];
                    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121

                    ncritem.Makeready = arr_2[1];

                }
                if (arr_2[0] == "NoofWashup") {
                    for (var k = 0; k < ddlWashUp.length; k++) {
                        if (ddlWashUp.options[k].value == arr_2[1]) {
                            ddlWashUp.selectedIndex = k;
                        }
                    }
                    ncritem.Washup = arr_2[1];
                }

                if (arr_2[0] == "SheetSize") {
                    for (var k = 0; k < ddlPrintSheetSize.length; k++) {
                        if (ddlPrintSheetSize.options[k].value == arr_2[1]) {
                            ddlPrintSheetSize.selectedIndex = k;
                        }
                    }

                    LoadToSheetCustom(arr_2[1]);

                    if (arr_2[2] == 'True') {
                        chkPrintSheet.checked = true;
                        PrintSheetCustom(chkPrintSheet.id);
                    }
                    else {
                        chkPrintSheet.checked = false;
                    }

                    txtsectionheight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[3], decimalPlaces, '', false, false, false);
                    txtsectionwidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[4], decimalPlaces, '', false, false, false);

                    ncritem.PrintSheetSizeID = arr_2[1];
                    ncritem.IsPrintCustom = chkPrintSheet.checked;
                    ncritem.PrintSheetHeight = arr_2[3];
                    ncritem.PrintSheetWidth = arr_2[4];
                }
                if (arr_2[0] == "ItemSize") {
                    for (var k = 0; k < ddlJobItemSize.length; k++) {
                        if (ddlJobItemSize.options[k].value == arr_2[1]) {
                            ddlJobItemSize.selectedIndex = k;
                        }
                    }
                    LoadToItemCustom(arr_2[1]);
                    if (arr_2[2] == 'True') {
                        ChkJobFlatCustom.checked = true;
                        JobItemCustom(ChkJobFlatCustom.id);
                    }
                    else {
                        ChkJobFlatCustom.checked = false;
                    }
                    txtitemheight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[3], decimalPlaces, '', false, false, false);
                    txtitemwidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[4], decimalPlaces, '', false, false, false);

                    ncritem.JobFlatSizeID = arr_2[1];
                    ncritem.IsJobCustom = ChkJobFlatCustom.checked;
                    ncritem.JobFlatSizeHeight = arr_2[3];
                    ncritem.JobFlatSizeWidth = arr_2[4];

                }
                if (arr_2[0] == "Gutters") {
                    if (arr_2[1] == 'True') {
                        chkGutters.checked = true;
                    }
                    else {
                        chkGutters.checked = false;
                    }
                    txtGutterHorizontal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[2], 0, '', true, false, false);
                    txtGutterVertical.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[3], 0, '', true, false, false);

                    ncritem.IsIncludeGutters = chkGutters.checked;
                    ncritem.GutterHorizontal = arr_2[2];
                    ncritem.GutterVertical = arr_2[3];

                }
                if (arr_2[0] == "PressRestrictions") {
                    if (arr_2[1] == 'True') {
                        ChkPressRestrictions.checked = true;
                    }
                    else {
                        ChkPressRestrictions.checked = false;
                    }

                    ncritem.IsPressRestrictions = ChkPressRestrictions.checked;

                }
                if (arr_2[0] == "PrintLayout") {
                    var NcrPadFomat = "P";
                    if (arr_2[4].toString().toLowerCase() == "landscape") {
                        NcrPadFomat = "L";
                    }

                    for (var k = 0; k < ddlBookletFormat.length; k++) {
                        if (ddlBookletFormat.options[k].value == NcrPadFomat) {
                            ddlBookletFormat.selectedIndex = k;
                        }
                    }
                    chkPortrait.checked = arr_2[1] == "P" ? true : false;
                    chkLandscape.checked = arr_2[1] == "L" ? true : false;
                    chkManual.checked = arr_2[1] == "M" ? true : false;
                    hdn_Protrait.value.value = arr_2[2];
                    hdn_Landscale.value = arr_2[3];
                    hdnManual.value = arr_2[5];
                    txtportrait.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[2], 0, '', true, false, false);
                    txtlandscape.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[3], 0, '', true, false, false);
                    txtManual.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[5], 0, '', true, false, false);

                    ncritem.PrintLayout = arr_2[1];
                    ncritem.Portraitvalue = arr_2[2];
                    ncritem.Landscapevalue = arr_2[3];
                    ncritem.ManualValue = arr_2[5];

                }
                if (arr_2[0] == "Guillotine") {
                    hid_GuillotineID.value = arr_2[1];
                    lblGuillotine.innerHTML = arr_2[2].length > 25 ? arr_2[2].substring(0, 23) + "..." : arr_2[2];
                    lblGuillotine.title = arr_2[2];
                    div_Trim.style.display = hid_GuillotineID.value != "0" ? "block" : "none";

                    ncritem.GuilotineID = arr_2[1];
                    ncritem.GuilotineName = arr_2[2];
                }
                if (arr_2[0] == "IsFirstTrim") {

                    if (arr_2[1] == 'True') {
                        chkFirstTrim.checked = true;
                    }
                    else {
                        chkFirstTrim.checked = false;
                    }
                    ncritem.IsFirstTrim = chkFirstTrim.checked;

                }
                if (arr_2[0] == "IsSecondTrim") {

                    if (arr_2[1] == 'True') {
                        chkSecondTrim.checked = true;
                    }
                    else {
                        chkSecondTrim.checked = false;
                    }
                    ncritem.IsSecondTrim = chkSecondTrim.checked;
                }
                if (arr_2[0] == "MakeReadyPerPlateCheck") {
                    if (arr_2[1] == 'True') {
                        hid_makeready.value = "yes";
                        ncritem.MakeReadyPerPlateCheck = hid_makeready.value;
                    }
                }
                if (arr_2[0] == "WashupChargePerColourCheck") {
                    if (arr_2[1] == 'True') {
                        hid_washup.value = "yes";
                        ncritem.WashupChargePerColourCheck = hid_washup.value;
                    }
                }
                if (arr_2[0] == "ImageType") {
                    if (arr_2[1] == 'common') {
                        radiocommon.checked = true;
                        radiouncommon.checked = false;
                        commonfrom.style.display = "block";
                        ncritem.Ncrcommonuncommon = "common";
                    }
                    else if (arr_2[1] == 'uncommon') {
                        radiouncommon.checked = true;
                        radiocommon.checked = false;
                        commonfrom.style.display = "none";
                        ncritem.Ncrcommonuncommon = "uncommon";
                    }
                }
                if (arr_2[0] == "CommonFrom") {
                    for (var k = 0; k < ddlcommonfrom.length; k++) {
                        if (ddlcommonfrom.options[k].text == arr_2[1]) {
                            ddlcommonfrom.selectedIndex = k;
                        }
                    }
                    ncritem.Ncrcommonfrom = arr_2[1];
                }
                if (arr_2[0] == "EstimateLithoNcrItemID") {
                    ncritem.EstimateLithoNCRItemID = arr_2[1];
                    NcrEditID = arr_2[1];
                }
                if (arr_2[0] == "EstimateCalculationID") {
                    ncritem.EstimateCalculationID = arr_2[1];
                    hid_calculationid.value = arr_2[1];
                }
                if (arr_2[0] == "Colour") {
                    if (arr_2[1] == 'Single') {
                        for (var k = 0; k < ddlNoOfSide.length; k++) {
                            if (ddlNoOfSide.options[k].text == arr_2[1]) {
                                ddlNoOfSide.selectedIndex = k;
                            }
                        }

                        for (var k = 0; k < ddlSide1Color.length; k++) {
                            if (ddlSide1Color.options[k].text == arr_2[2]) {
                                ddlSide1Color.selectedIndex = k;
                            }
                        }
                        ncritem.Noofsidesprinted = arr_2[1];
                        ncritem.Side1color = arr_2[2];
                        document.getElementById("div_work").style.display = "none";
                    }
                    else if (arr_2[1] == 'Double') {
                        document.getElementById("Div_PerfectChk").style.display = "block";
                        for (var k = 0; k < ddlNoOfSide.length; k++) {
                            if (ddlNoOfSide.options[k].text == arr_2[1]) {
                                ddlNoOfSide.selectedIndex = k;
                            }
                        }
                        for (var k = 0; k < ddlSide1Color.length; k++) {
                            if (ddlSide1Color.options[k].text == arr_2[2]) {
                                ddlSide1Color.selectedIndex = k;
                            }
                        }
                        for (var k = 0; k < ddlSide2Color.length; k++) {
                            if (ddlSide2Color.options[k].text == arr_2[3]) {
                                ddlSide2Color.selectedIndex = k;
                            }
                        }
                        document.getElementById("div_work").style.display = "none";
                        if (arr_2[4] == 'True') {
                            chkTurn.checked = true;
                            chkSheetWork.checked = false;
                            chkTumble.checked = false;
                            chkPerfecting.checked = false;
                            ncritem.Checkturn = true;
                        }
                        else {
                            chkTurn.checked = false;
                            ncritem.Checkturn = false;
                        }

                        if (arr_2[5] == 'True') {
                            chkTumble.checked = true;
                            chkSheetWork.checked = false;
                            chkTurn.checked = false;
                            chkPerfecting.checked = false;
                            ncritem.Checktumble = true;
                        }
                        else {
                            chkTumble.checked = false;
                            ncritem.Checktumble = false;
                        }
                        if (arr_2[6] == 'True') {
                            chkTumble.checked = false;
                            chkSheetWork.checked = false;
                            chkTurn.checked = false;
                            chkPerfecting.checked = true;
                            ncritem.CheckPerfecting = true;
                        }
                        else {
                            chkPerfecting.checked = false;
                            ncritem.CheckPerfecting = false;
                        }

                        if (arr_2[4] == 'False' && arr_2[5] == 'False' && arr_2[6] == 'False') {
                            chkSheetWork.checked = true;
                        }
                        ncritem.Noofsidesprinted = arr_2[1];
                        ncritem.Side1color = arr_2[2];
                        ncritem.Side2color = arr_2[3];
                    }
                }
            }
        }
        ncrArray.push(ncritem);
    }

    GenerateSection();
    LoadData(1, 'load', 1);
    GuttersCustom('ctl00_ContentPlaceHolder1_UCNCRItem_chkGutters');
}

function LoadData(thisvalue, type, val) {
    hid_value.value = val;
    hid_partvalue.value = thisvalue;
    if (thisvalue.length > 1) {
        thisvalue = thisvalue.substring(thisvalue.length - 1, thisvalue.length);
    }
    hid_buttonvalue.value = thisvalue;

    if (type == 'edit' || type == 'load') {
        Gethideoneditcase(thisvalue);
    }
    if (type == 'edit') {
        for (var i = 1; i <= ncrArray.length; i++) {
            if (i == thisvalue) {
                document.getElementById("btn" + i + "").className = "booklet_section_active";
            }
            else {
                document.getElementById("btn" + i + "").className = "button";
            }
        }
    }

    //highlighting the buttons on edit case

    //To update on edit case//
    if (type == 'edit') {
        updateNCRSections();
    }
    //END to update on edit case
    var arrindx;

    if (type == 'loadoninsert') {
        updateNCRSections();
    }
    arrindx = Number(thisvalue) - 1;

    hid_current.value = thisvalue;

    if (ncrArray[arrindx] == null) {
        arrindx = 0;
        hid_current.value = 1;
    }

    if (type == 'load' || type == 'edit') {
        for (var i = 0; i < ddlPress.length; i++) {
            if (ncrArray[arrindx].Assignedpress == ddlPress[i].value) {
                ddlPress.selectedIndex = i;
            }
        }
    } //end of tload and edit
    hdnpaperID.value = ncrArray[arrindx].PaperID;
    try {
        PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
    }
    catch (error) { }
    lblDefaultPaper.innerHTML = ncrArray[arrindx].PaperName;
    lblDefaultPaper.title = ncrArray[arrindx].PaperName;
    if (ncrArray[arrindx].PaperID == '0') {
        hdnpaperID.value = ncrArray[0].PaperID;
        lblDefaultPaper.innerHTML = ncrArray[0].PaperName;
        lblDefaultPaper.title = ncrArray[0].Platename;
    }

    ChkPriceForWholePack.checked = ncrArray[arrindx].PriceForWhaolePack;
    ChkPaperSupplied.checked = ncrArray[arrindx].PaperSupplied;
    lblDefaultPlates.innerHTML = ncrArray[arrindx].Platename;
    lblPaperWeight.innerHTML = ncrArray[arrindx].PaperWeight;
    hdnplateID.value = ncrArray[arrindx].PlateID;

    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
    txtNoOfPlates.value = ncrArray[arrindx].Plate;
    txtNoOfMakeReady.value = ncrArray[arrindx].Makeready;
    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121

    for (var i = 0; i < ddlPlates.length; i++) {
        if (ncrArray[arrindx].Plate == ddlPlates[i].value) {
            ddlPlates.selectedIndex = i;
        }
    }
    if (hid_makeready.value == 'yes') {
        document.getElementById("divMakeReady").style.display = "block";
    }

    if (hid_washup.value == 'yes') {
        document.getElementById("divWashUp").style.display = "block";
    }

    for (var i = 0; i < ddlMakeReady.length; i++) {
        if (ncrArray[arrindx].Makeready == ddlMakeReady[i].value) {
            ddlMakeReady.selectedIndex = i;
        }
    }

    for (var i = 0; i < ddlWashUp.length; i++) {
        if (ncrArray[arrindx].Washup == ddlWashUp[i].value) {
            ddlWashUp.selectedIndex = i;
        }
    }

    for (var j = 0; j < ddlNoOfSide.length; j++) {
        if (ddlNoOfSide.options[j].text == ncrArray[arrindx].Noofsidesprinted) {
            ddlNoOfSide.selectedIndex = j;
        }
    }
    if (ncrArray[arrindx].Noofsidesprinted == 'Single') {
        for (var j = 0; j < ddlSide1Color.length; j++) {
            if (ddlSide1Color.options[j].text == ncrArray[arrindx].Side1color) {
                ddlSide1Color.selectedIndex = j;
            }
        }

        document.getElementById("div_side2_colour").style.display = "none";
        document.getElementById("div_work").style.display = "none";
    }
    else if (ncrArray[arrindx].Noofsidesprinted == 'Double') {
        document.getElementById("div_side2_colour").style.display = "block";
        document.getElementById("div_work").style.display = "block";

        for (var j = 0; j < ddlSide1Color.length; j++) {
            if (ddlSide1Color.options[j].text == ncrArray[arrindx].Side1color) {
                ddlSide1Color.selectedIndex = j;
            }
        }

        for (var j = 0; j < ddlSide2Color.length; j++) {
            if (ddlSide2Color.options[j].text == ncrArray[arrindx].Side2color) {
                ddlSide2Color.selectedIndex = j;
            }
        }

        chkTurn.checked = ncrArray[arrindx].Checkturn.toString().toLowerCase() == 'true' ? true : false;
        chkTumble.checked = ncrArray[arrindx].Checktumble.toString().toLowerCase() == 'true' ? true : false;
        chkPerfecting.checked = ncrArray[arrindx].CheckPerfecting.toString().toLowerCase() == 'true' ? true : false;

        if (chkTurn.checked == false && chkTumble.checked == false || chkPerfecting.checked == false) {
            chkSheetWork.Checked = true;
        }
    }

    if (ncrArray[arrindx].Ncrcommonuncommon == 'common') {
        radiocommon.checked = true;
        commonfrom.style.display = "block";
        for (var j = 0; j < ddlcommonfrom.length; j++) {
            if (ncrArray[arrindx].Ncrcommonfrom == ddlcommonfrom.options[j].text) {
                ddlcommonfrom.selectedIndex = j;
            }
        }
    }
    else if (ncrArray[arrindx].Ncrcommonuncommon == 'uncommon') {
        radiouncommon.checked = true;
        commonfrom.style.display = "none";
    }

    NcrEditID = ncrArray[arrindx].EstimateLithoNCRItemID;
    hid_lithoncritemid.value = NcrEditID;

    txtSectionRef.value = ncrArray[arrindx].Sectionreference;

    hid_calculationid.value = ncrArray[arrindx].EstimateCalculationID;
    //by kumar
    //To load data


    if (type == 'loadoninsert' || type == 'edit') {
        if (radiocommon.checked == true) {
            if (radiocommon.checked == true && ddlcommonfrom.selectedIndex == '0') {
                commonfromonchange(1);
            }
            if (radiocommon.checked == true && ddlcommonfrom.selectedIndex == '1') {
                commonfromonchange(2);
            }
            if (radiocommon.checked == true && ddlcommonfrom.selectedIndex == '2') {
                commonfromonchange(3);
            }
            if (radiocommon.checked == true && ddlcommonfrom.selectedIndex == '3') {
                commonfromonchange(4);
            }
            if (radiocommon.checked == true && ddlcommonfrom.selectedIndex == '4') {
                commonfromonchange(5);
            }
            if (radiocommon.checked == true && ddlcommonfrom.selectedIndex == '5') {
                commonfromonchange(6);
            }
            ddlPlates.disabled = true;
            ddlMakeReady.disabled = true;
            ddlWashUp.disabled = true;

            //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
            txtNoOfPlates.disabled = true;
            txtNoOfMakeReady.disabled = true;
            //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
        }
        else {
            ddlPlates.disabled = false;
            ddlMakeReady.disabled = false;
            ddlWashUp.disabled = false;

            //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
            txtNoOfPlates.disabled = false;
            txtNoOfMakeReady.disabled = false;
            //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
        }
    }
}

//Test end

function updateNCRSections() {
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    //update
    var updindx = 0;
    updindx = Number(hid_current.value) - 1;
    ncrArray[updindx].Quantity1 = txtQuantity.value;
    //by kumar          
    ncrArray[updindx].Quantity2 = txtQuantity_2.value;
    ncrArray[updindx].Quantity3 = txtQuantity_3.value;
    ncrArray[updindx].Quantity4 = txtQuantity_4.value;
    ncrArray[updindx].Partsperset = txtpartsperset.value;
    ncrArray[updindx].Setsperpad = txtsetsperpad.value;
    if (txtSectionRef.value == '') {
        var cnt = updindx + 1;
        ncrArray[updindx].Sectionreference = "Part " + cnt;
    }
    else {
        ncrArray[updindx].Sectionreference = txtSectionRef.value;
    }
    ncrArray[updindx].Assignedpress = ddlPress.value;
    ncrArray[updindx].PaperID = hdnpaperID.value;
    ncrArray[updindx].PaperName = lblDefaultPaper.innerHTML;
    ncrArray[updindx].PriceForWhaolePack = ChkPriceForWholePack.checked;
    ncrArray[updindx].PaperSupplied = ChkPaperSupplied.checked;
    ncrArray[updindx].Setupspoilage = txtSetupSpoilage.value;
    ncrArray[updindx].Runningspoilage = txtRunningSpoilage.value;
    ncrArray[updindx].Noofsidesprinted = ddlNoOfSide.options[ddlNoOfSide.selectedIndex].text;
    ncrArray[updindx].Side1color = ddlSide1Color.options[ddlSide1Color.selectedIndex].text;
    ncrArray[updindx].Side2color = ddlSide2Color.options[ddlSide2Color.selectedIndex].text;
    ncrArray[updindx].Checkturn = chkTurn.checked;
    ncrArray[updindx].Checktumble = chkTumble.checked;
    ncrArray[updindx].Platename = lblDefaultPlates.innerHTML;
    ncrArray[updindx].PlateID = hdnplateID.value;
    ncrArray[updindx].Plate = ddlPlates.value;
    ncrArray[updindx].Washup = ddlWashUp.value;
    ncrArray[updindx].PaperWeight = lblPaperWeight.innerHTML;

    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
    ncrArray[updindx].Makeready = txtNoOfMakeReady.value;
    ncrArray[updindx].Plate = txtNoOfPlates.value;
    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121

    ncrArray[updindx].PrintSheetSizeID = ddlPrintSheetSize.value;
    ncrArray[updindx].IsPrintCustom = chkPrintSheet.checked;
    ncrArray[updindx].PrintSheetHeight = txtsectionheight.value;
    ncrArray[updindx].PrintSheetWidth = txtsectionwidth.value;
    ncrArray[updindx].JobFlatSizeID = ddlJobItemSize.value;
    ncrArray[updindx].IsJobCustom = ChkJobFlatCustom.checked;
    ncrArray[updindx].JobFlatSizeHeight = txtitemheight.value;
    ncrArray[updindx].JobFlatSizeWidth = txtitemwidth.value;
    ncrArray[updindx].IsIncludeGutters = chkGutters.checked;
    ncrArray[updindx].GutterHorizontal = txtGutterHorizontal.value;
    ncrArray[updindx].GutterVertical = txtGutterVertical.value;
    ncrArray[updindx].IsPressRestrictions = ChkPressRestrictions.checked;
    ncrArray[updindx].GuilotineID = hid_GuillotineID.value;
    ncrArray[updindx].GuilotineName = lblGuillotine.innerHTML;
    ncrArray[updindx].IsFirstTrim = chkFirstTrim.checked;
    ncrArray[updindx].IsSecondTrim = chkSecondTrim.checked;
    ncrArray[updindx].PrintLayout = ddlBookletFormat.value;
    ncrArray[updindx].Portraitvalue = hdn_Protrait.value;
    ncrArray[updindx].Landscapevalue = hdn_Landscale.value;
    ncrArray[updindx].ManualValue = hdnManual.value;
    if (radiocommon.checked == true) {
        ncrArray[updindx].Ncrcommonuncommon = "common";

    }
    if (radiouncommon.checked == true) {
        ncrArray[updindx].Ncrcommonuncommon = "uncommon";
    }
    ncrArray[updindx].MakeReadyPerPlateCheck = hid_makeready.value;
    ncrArray[updindx].WashupChargePerColourCheck = hid_washup.value;
    ncrArray[updindx].EstimateCalculationID = hid_calculationid.value;
    ncrArray[updindx].CheckPerfecting = chkPerfecting.checked;
    //by kumar
    if (ncrArray[hid_previous.value] != null) {
        hid_previous.value = Number(hid_current.value) - 1;
        hid_current.value = 0;
    }
    //to update    
}

// Main Next click
function NCR_Click_Next() {
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    //this is check whether user click on part button or next button//
    hid_checknextorload.value = 1;
    //this is check whether user click on part button or next button//
    var IsItOk = true;
    IsItOk = Litho_Validation(txtpartsperset);
    if (IsItOk) {
        if (ValidatePaper_HeightWidth()) {
            if (QueryType == "add" && hid_incrementvalue.value == "0") {
                for (var u = 0; u <= Number(hid_thisvalue.value); u++) {
                    storedata(u, hid_previous_add.value);
                }
            }
            else if (QueryType == 'add' && hid_incrementvalue.value != "0") {
                storedata(Number(hid_value.value), hid_previous_add.value); //if any problem pls uncomment this
            }
            else if (QueryType == "edit") {
                LoadData(Number(hid_previous.value) + 1, 'edit', 1);
            }
            G_CalculateLandscape("n");
            G_CalculatePortrait("n"); // changed By Pradeep
            //txtManual.value = 0;
            SaveData(txtpartsperset);
            return InnventoryPrompt();
            //return true;
        }
    }
    return false;
}

function commonfromonchange(ddlvalue) {
    if (QueryType == 'edit') {
        LoadDataOncommonfromchange(hid_buttonvalue.value, ddlvalue, 'load');
    }
    if (QueryType == 'add') {
        LoadDataOncommonfromchange(hid_buttonvalue.value, ddlvalue, 'load');
    }
}

function LoadDataOncommonfromchange(buttonvalue, ddlvalue, type) {
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    var arrindx;
    //update
    var updindx = 0;
    updindx = Number(hid_current.value) - 1;
    ncrArray[updindx].Quantity1 = txtQuantity.value;
    //by kumar          
    ncrArray[updindx].Quantity2 = txtQuantity_2.value;
    ncrArray[updindx].Quantity3 = txtQuantity_3.value;
    ncrArray[updindx].Quantity4 = txtQuantity_4.value;
    ncrArray[updindx].Partsperset = txtpartsperset.value;
    ncrArray[updindx].Setsperpad = txtsetsperpad.value;
    ncrArray[updindx].Sectionreference = txtSectionRef.value;
    ncrArray[updindx].Assignedpress = ddlPress.value;
    ncrArray[updindx].PriceForWhaolePack = ChkPriceForWholePack.checked;
    ncrArray[updindx].PaperSupplied = ChkPaperSupplied.checked;
    ncrArray[updindx].Setupspoilage = txtSetupSpoilage.value;
    ncrArray[updindx].Runningspoilage = txtRunningSpoilage.value;
    ncrArray[updindx].Noofsidesprinted = ddlNoOfSide.options[ddlNoOfSide.selectedIndex].text;
    ncrArray[updindx].Side1color = ddlSide1Color.options[ddlSide1Color.selectedIndex].text;
    ncrArray[updindx].Side2color = ddlSide2Color.options[ddlSide2Color.selectedIndex].text;
    ncrArray[updindx].Checkturn = chkTurn.checked;
    ncrArray[updindx].Checktumble = chkTumble.checked;
    ncrArray[updindx].CheckPerfecting = chkPerfecting.checked;
    ncrArray[updindx].Platename = lblDefaultPlates.innerHTML;
    ncrArray[updindx].PlateID = hdnplateID.value;
    ncrArray[updindx].Plate = ddlPlates.value;
    //ncrArray[updindx].Makeready = ddlMakeReady.value;
    //ncrArray[updindx].Washup = ddlWashUp.value;

    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
    ncrArray[updindx].Makeready = txtNoOfMakeReady.value;
    ncrArray[updindx].Plate = txtNoOfPlates.value;
    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121

    ncrArray[updindx].PrintSheetSizeID = ddlPrintSheetSize.value;
    ncrArray[updindx].IsPrintCustom = chkPrintSheet.checked;
    ncrArray[updindx].PrintSheetHeight = txtsectionheight.value;
    ncrArray[updindx].PrintSheetWidth = txtsectionwidth.value;

    ncrArray[updindx].JobFlatSizeID = ddlJobItemSize.value;
    ncrArray[updindx].IsJobCustom = ChkJobFlatCustom.checked;
    ncrArray[updindx].JobFlatSizeHeight = txtitemheight.value;
    ncrArray[updindx].JobFlatSizeWidth = txtitemwidth.value;


    ncrArray[updindx].IsIncludeGutters = chkGutters.checked;
    ncrArray[updindx].GutterHorizontal = txtGutterHorizontal.value;
    ncrArray[updindx].GutterVertical = txtGutterVertical.value;

    ncrArray[updindx].IsPressRestrictions = ChkPressRestrictions.checked;

    ncrArray[updindx].GuilotineID = hid_GuillotineID.value;
    ncrArray[updindx].GuilotineName = lblGuillotine.innerHTML;

    ncrArray[updindx].IsFirstTrim = chkFirstTrim.checked;
    ncrArray[updindx].IsSecondTrim = chkSecondTrim.checked;

    ncrArray[updindx].PrintLayout = ddlBookletFormat.value;
    ncrArray[updindx].Portraitvalue = hdn_Protrait.value;
    ncrArray[updindx].Landscapevalue = hdn_Landscale.value;
    ncrArray[updindx].ManualValue = hdnManual.value;
    ncrArray[updindx].PaperID = hdnpaperID.value;


    if (radiocommon.checked == true) {
        ncrArray[updindx].Ncrcommonuncommon = "common";
        ncrArray[updindx].Ncrcommonfrom = ddlcommonfrom.options[ddlcommonfrom.selectedIndex].text;

    }
    if (radiouncommon.checked == true) {
        ncrArray[updindx].Ncrcommonuncommon = "uncommon";
    }

    ncrArray[updindx].MakeReadyPerPlateCheck = hid_makeready.value;
    ncrArray[updindx].WashupChargePerColourCheck = hid_washup.value;
    ncrArray[updindx].EstimateCalculationID = hid_calculationid.value;

    //by kumar

    if (ncrArray[hid_previous.value] != null) {
        hid_previous.value = Number(hid_current.value) - 1;
        hid_current.value = 0;
    }

    //edit    
    arrindx = Number(ddlvalue) - 1;
    hid_current.value = buttonvalue;
    txtQuantity.value = ncrArray[arrindx].Quantity1;
    //by kumar
    txtQuantity_2.value = ncrArray[arrindx].Quantity2;
    txtQuantity_3.value = ncrArray[arrindx].Quantity3;
    txtQuantity_4.value = ncrArray[arrindx].Quantity4;

    txtsetsperpad.value = ncrArray[arrindx].Setsperpad;
    for (var i = 0; i < ddlPress.length; i++) {
        if (ncrArray[arrindx].Assignedpress == ddlPress[i].value) {
            ddlPress.selectedIndex = i;
        }
    }
    txtSetupSpoilage.value = ncrArray[arrindx].Setupspoilage;
    txtRunningSpoilage.value = ncrArray[arrindx].Runningspoilage;
    chkPrintSheet.checked = ncrArray[arrindx].IsPrintCustom;
    PrintSheetCustom(chkPrintSheet.id); //FUNCTION
    txtsectionheight.value = ncrArray[arrindx].PrintSheetHeight;
    txtsectionwidth.value = ncrArray[arrindx].PrintSheetWidth;

    for (var i = 0; i < ddlJobItemSize.length; i++) {
        if (ddlJobItemSize[i].value == ncrArray[arrindx].JobFlatSizeID) {
            ddlJobItemSize.selectedIndex = i;
        }
    }

    ChkJobFlatCustom.checked = ncrArray[arrindx].IsJobCustom;
    JobItemCustom(ChkJobFlatCustom.id); //FUNCTION 
    txtitemheight.value = ncrArray[arrindx].JobFlatSizeHeight;
    txtitemwidth.value = ncrArray[arrindx].JobFlatSizeWidth;

    chkGutters.checked = ncrArray[arrindx].IsIncludeGutters;
    GuttersCustom(chkGutters.id); //FUNCTION 
    txtGutterHorizontal.value = ncrArray[arrindx].GutterHorizontal;
    txtGutterVertical.value = ncrArray[arrindx].GutterVertical;
    ChkPressRestrictions.checked = ncrArray[arrindx].IsPressRestrictions;
    hid_GuillotineID.value = ncrArray[arrindx].GuilotineID;
    lblGuillotine.innerHTML = ncrArray[arrindx].GuilotineName;
    ////new Development
    chkFirstTrim.checked = ncrArray[arrindx].IsFirstTrim;
    chkSecondTrim.checked = ncrArray[arrindx].IsSecondTrim;

    for (var j = 0; j < ddlBookletFormat.length; j++) {
        if (ddlBookletFormat.options[j].value == ncrArray[arrindx].PrintLayout) {
            ddlBookletFormat.selectedIndex = j;
        }
    }
    hdn_Protrait.value = ncrArray[arrindx].Portraitvalue;
    hdn_Landscale.value = ncrArray[arrindx].Landscapevalue;
    hdnManual.value = ncrArray[arrindx].ManualValue;
    ChkPriceForWholePack.checked = ncrArray[arrindx].PriceForWhaolePack;
    ChkPaperSupplied.checked = ncrArray[arrindx].PaperSupplied;

    lblDefaultPlates.innerHTML = ncrArray[arrindx].Platename;
    hdnplateID.value = ncrArray[arrindx].PlateID;

    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
    txtNoOfPlates.value = ncrArray[arrindx].Plate;
    txtNoOfMakeReady.value = ncrArray[arrindx].Makeready;
    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121

    for (var i = 0; i < ddlPlates.length; i++) {
        if (ncrArray[arrindx].Plate == ddlPlates[i].value) {
            ddlPlates.selectedIndex = i;
        }
    }
    if (hid_makeready.value == 'yes') {
        document.getElementById("divMakeReady").style.display = "block";
    }

    if (hid_washup.value == 'yes') {
        document.getElementById("divWashUp").style.display = "block";
    }

    for (var i = 0; i < ddlMakeReady.length; i++) {
        if (ncrArray[arrindx].Makeready == ddlMakeReady[i].value) {
            ddlMakeReady.selectedIndex = i;
        }
    }

    for (var i = 0; i < ddlWashUp.length; i++) {
        if (ncrArray[arrindx].Washup == ddlWashUp[i].value) {
            ddlWashUp.selectedIndex = i;
        }
    }


    for (var i = 0; i < ddlPrintSheetSize.length; i++) {
        if (ncrArray[arrindx].PrintSheetSizeID == ddlPrintSheetSize[i].value) {
            ddlPrintSheetSize.selectedIndex = i;
        }
    }

    for (var j = 0; j < ddlNoOfSide.length; j++) {
        if (ddlNoOfSide.options[j].text == ncrArray[arrindx].Noofsidesprinted) {
            ddlNoOfSide.selectedIndex = j;
        }
    }

    if (ncrArray[arrindx].Noofsidesprinted == 'Single') {
        for (var j = 0; j < ddlSide1Color.length; j++) {
            if (ddlSide1Color.options[j].text == ncrArray[arrindx].Side1color) {
                ddlSide1Color.selectedIndex = j;
            }
        }

        document.getElementById("div_side2_colour").style.display = "none";
        document.getElementById("div_work").style.display = "none";
    }
    else if (ncrArray[arrindx].Noofsidesprinted == 'Double') {
        document.getElementById("div_side2_colour").style.display = "block";
        document.getElementById("div_work").style.display = "block";

        for (var j = 0; j < ddlSide1Color.length; j++) {
            if (ddlSide1Color.options[j].text == ncrArray[arrindx].Side1color) {
                ddlSide1Color.selectedIndex = j;
            }
        }

        for (var j = 0; j < ddlSide2Color.length; j++) {
            if (ddlSide2Color.options[j].text == ncrArray[arrindx].Side2color) {
                ddlSide2Color.selectedIndex = j;
            }
        }
        chkTurn.checked = ncrArray[arrindx].Checkturn.toString().toLowerCase() == 'true' ? true : false;
        chkTumble.checked = ncrArray[arrindx].Checktumble.toString().toLowerCase() == 'true' ? true : false;
        chkPerfecting.checked = ncrArray[arrindx].CheckPerfecting.toString().toLowerCase() == 'true' ? true : false;


    }

    if (!chkTumble.Checked && !chkTurn.Checked && !chkPerfecting.checked) {
        chkSheetWork.Checked = true;
    }
    else {
        chkSheetWork.Checked = false;
    }
    NcrEditID = ncrArray[arrindx].EstimateLithoNCRItemID;
    hid_calculationid.value = ncrArray[arrindx].EstimateCalculationID;

}

function gethideoncommonfromchange(txtvaaal) {
    for (var j = 1; j <= ncrArray.length; j++) {
        if (j == txtvaaal) {
            if (txtvaaal == 1) {
                txtSectionRef.value = "Part 1";
                commonfrom.style.display = "none";
            }
            else if (txtvaaal == ncrArray.length) {
                txtSectionRef.value = "Part" + txtvaaal + "";
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                for (var m = 1; m < ncrArray.length; m++) {
                    if (m == '1') {
                        ddlcommonfrom.options.add(new Option("Part 1", 1));
                    }
                    if (m == '2') {
                        ddlcommonfrom.options.add(new Option("Part 2", 2));
                    }
                    if (m == '3') {
                        ddlcommonfrom.options.add(new Option("Part 3", 3));
                    }
                    if (m == '4') {
                        ddlcommonfrom.options.add(new Option("Part 4", 4));
                    }
                    if (m == '5') {
                        ddlcommonfrom.options.add(new Option("Part 5", 5));
                    }
                    if (m == '6') {
                        ddlcommonfrom.options.add(new Option("Part 6", 6));
                    }
                    if (m == '7') {
                        ddlcommonfrom.options.add(new Option("Part 7", 7));
                    }
                    if (m == '8') {
                        ddlcommonfrom.options.add(new Option("Part 8", 8));
                    }
                }
            }
            else if (txtvaaal == '2') {
                txtSectionRef.value = "Part 2";
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
            }
            else if (txtvaaal == '3') {
                txtSectionRef.value = "Part 3";
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
            }
            else if (txtvaaal == '4') {
                txtSectionRef.value = "Part 4";
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
            }
            else if (txtvaaal == '5') {
                txtSectionRef.value = "Part 5";
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
                ddlcommonfrom.options.add(new Option("Part 4", 4));
            }
            else if (txtvaaal == '6') {
                txtSectionRef.value = "Part 6";
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
                ddlcommonfrom.options.add(new Option("Part 4", 4));
                ddlcommonfrom.options.add(new Option("Part 5", 5));
            }
            else if (txtvaaal == '7') {
                txtSectionRef.value = "Part 7";
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
                ddlcommonfrom.options.add(new Option("Part 4", 4));
                ddlcommonfrom.options.add(new Option("Part 5", 5));
                ddlcommonfrom.options.add(new Option("Part 6", 6));
            }
            else if (txtvaaal == '8') {
                txtSectionRef.value = "Part 8";
                commonfrom.style.display = "block";
                ddlclear(ddlcommonfrom, ddlcommonfrom.length);
                ddlcommonfrom.options.add(new Option("Part 1", 1));
                ddlcommonfrom.options.add(new Option("Part 2", 2));
                ddlcommonfrom.options.add(new Option("Part 3", 3));
                ddlcommonfrom.options.add(new Option("Part 4", 4));
                ddlcommonfrom.options.add(new Option("Part 5", 5));
                ddlcommonfrom.options.add(new Option("Part 6", 6));
                ddlcommonfrom.options.add(new Option("Part 7", 7));
            }
        }
    }
}


function inserttoarray(thisvalue)  //this is the function is called on onblur of No of parts per set textbox.
{
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    var diffvalue;
    if (QueryType == 'add') {
        for (var j = 0; j <= thisvalue; j++) {
            storedata(j, thisvalue);
        }
        LoadData(1, 'load', 1);
    }
    else if (QueryType == 'edit') {
        diffvalue = parseFloat(thisvalue) - parseFloat(ncrArray.length); //on edit case already there is items on array,need to insert the differnece value to the array,suppose array length have 0,1,2,3 ie partsperset value is 4, now the parts per set value is changed to 6,then need to retain the 0,1,2,3 then need to insert 4,5 th position to array                           

        if (diffvalue.toString().substring(0, 1) == "-") {
            diffvalue = thisvalue; //diffvalue.toString().replace('-', '');
            ncrArray.splice(0, Number(ncrArray.length) - 1);
        }
        NcrEditID = 0;
        txtSectionRef.value = "Parts";
        txtpartsperset.value = thisvalue;
        hid_FinalInkSave1.Value = "";
        hid_FinalInkSave2.Value = "";
        for (var j = 1; j <= diffvalue; j++) {
            storedata(thisvalue - (diffvalue - j), thisvalue); //it should in desc order only 0,1,2,3,4,5,6,7,8,9.....
        }
        LoadData(1, 'load', 1);
    }
}

function partsperset_onblur(thisvalue) {
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    if (thisvalue == 0) {
        txtpartsperset.value = 1;
        thisvalue = 1;
    }

    if (QueryType == 'add') {
        //        //added by gajendra
        //        for (var s = 0; s < ncrArray.length; s++) {
        //            if (ncrArray[s].Quantity1 == '' || ncrArray[s].Quantity1 == 0) {
        //                ncrArray.splice(s, 1);
        //                storedata_onblur(s, thisvalue);
        //            }
        //        }
        //        //added by gajendra

        //        if (thisvalue >= 2) {
        //            for (var m = 2; m < thisvalue; m++) {
        //                ncrArray.splice(m, 1);
        //            }
        //            for (var j = 2; j < thisvalue; j++) {
        //                storedata_onblur(j, thisvalue);
        //            }
        //        }
        //        else {
        //            for (var m = 0; m < thisvalue; m++) {
        //                ncrArray.splice(m, 1);
        //            }
        //            for (var j = 0; j < thisvalue; j++) {
        //                storedata_onblur(j, thisvalue);
        //            }
        //        }

        var lnt = ncrArray.length - 1;
        for (var s = lnt; s > -1; s--) {
            ncrArray.splice(s, 1);
        }
        for (var j = 0; j < thisvalue; j++) {
            storedata_onblur(j, thisvalue);
        }

        updateNCRSections();
        LoadData(1, 'load', 1);
    }

    if (QueryType == 'edit') {
        //PartspersetFromdatabase = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PartspersetFromdatabase, 0, '', true, false, false);
        PartspersetFromdatabase = Number(hid_partperset.value) + 1;

        diffvalue = parseFloat(thisvalue) - parseFloat(PartspersetFromdatabase); //on edit case already there is items on array,need to insert the differnece value to the array,suppose array length have 0,1,2,3 ie partsperset value is 4, now the parts per set value is changed to 6,then need to retain the 0,1,2,3 then need to insert 4,5 th position to array                           
        if (diffvalue.toString().substring(0, 1) == "-") {
            diffvalue = diffvalue.toString().replace('-', '');
            ncrArray.splice(thisvalue, diffvalue);
            hid_partperset.value = Number(hid_partperset.value) - diffvalue;
        }
        NcrEditID = 0;
        txtpartsperset.value = thisvalue;
        hid_FinalInkSave1.Value = "";
        hid_FinalInkSave2.Value = "";

        for (var j = PartspersetFromdatabase; j < thisvalue; j++) {
            storedata_onblur(j, thisvalue); //it should in desc order only 0,1,2,3,4,5,6,7,8,9.....
        }
        updateNCRSections();
        LoadData(1, 'load', 1);
    }

    var ddlPress = document.getElementById("ctl00_ContentPlaceHolder1_UCNCRItem_ddlPress");
    if (ddlPress.options[ddlPress.selectedIndex].value != 0) {
        __doPostBack('ctl00$ContentPlaceHolder1$UCNCRItem$lnkNewSection', '');
    }
}



function storedata_onblur(thisvalue, totalno) {
    var cntrls = UpdatePanel1.getElementsByTagName("input");
    for (i = 0; i < cntrls.length; i++) {
        if (cntrls[i].type == "text") {
            txtpartsperset = cntrls[i];
            break;
        }
    }
    hid_previous_add.value = thisvalue;
    hid_partperset.value = thisvalue;
    var ncritem = new ItemClass();
    ncritem.Title = txtItemTitle.value;
    ncritem.Quantity1 = txtQuantity.value;
    ncritem.Quantity2 = txtQuantity_2.value;
    ncritem.Quantity3 = txtQuantity_3.value;
    ncritem.Quantity4 = txtQuantity_4.value;
    ncritem.Partsperset = txtpartsperset.value;
    ncritem.Setsperpad = txtsetsperpad.value;

    //by kumar on 20 jan 2011
    ncritem.Assignedpress = ddlPress.value;
    ncritem.PaperID = hdnpaperID.value;
    ncritem.PaperName = lblDefaultPaper.innerHTML;
    ncritem.PriceForWhaolePack = ChkPriceForWholePack.checked;
    ncritem.PaperSupplied = ChkPaperSupplied.checked;
    ncritem.Setupspoilage = txtSetupSpoilage.value;
    ncritem.Runningspoilage = txtRunningSpoilage.value;
    ncritem.Noofsidesprinted = ddlNoOfSide.options[ddlNoOfSide.selectedIndex].text;
    ncritem.Side1color = ddlSide1Color.options[ddlSide1Color.selectedIndex].text;
    ncritem.Side2color = ddlSide2Color.options[ddlSide2Color.selectedIndex].text;
    ncritem.Checkturn = chkTurn.checked;
    ncritem.Checktumble = chkTumble.checked;
    ncritem.Platename = lblDefaultPlates.innerHTML;
    ncritem.PlateID = hdnplateID.value;
    ncritem.Washup = ddlWashUp.value;
    ncritem.PaperWeight = lblPaperWeight.innerHTML;

    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121
    ncritem.Makeready = txtNoOfMakeReady.value;
    ncritem.Plate = txtNoOfPlates.value;
    //by swetha M.S on 20/4/2011 -- Ref BUGID: 121

    ncritem.PrintSheetSizeID = ddlPrintSheetSize.value;
    ncritem.IsPrintCustom = chkPrintSheet.checked;
    ncritem.PrintSheetHeight = txtsectionheight.value;
    ncritem.PrintSheetWidth = txtsectionwidth.value;

    ncritem.JobFlatSizeID = ddlJobItemSize.value;
    ncritem.IsJobCustom = ChkJobFlatCustom.checked;
    ncritem.JobFlatSizeHeight = txtitemheight.value;
    ncritem.JobFlatSizeWidth = txtitemwidth.value;


    ncritem.IsIncludeGutters = chkGutters.checked;
    ncritem.GutterHorizontal = txtGutterHorizontal.value;
    ncritem.GutterVertical = txtGutterVertical.value;

    ncritem.IsPressRestrictions = ChkPressRestrictions.checked;

    ncritem.GuilotineID = hid_GuillotineID.value;
    ncritem.GuilotineName = lblGuillotine.innerHTML;

    ncritem.IsFirstTrim = chkFirstTrim.checked;
    ncritem.IsSecondTrim = chkSecondTrim.checked;

    ncritem.PrintLayout = ddlBookletFormat.value;
    ncritem.Portraitvalue = hdn_Protrait.value;
    ncritem.ManualValue = hdnManual.value;
    ncritem.Landscapevalue = hdn_Landscale.value;
    ncritem.CheckPerfecting = chkPerfecting.checked;
    if (radiocommon.checked == true) {
        ncritem.Ncrcommonuncommon = "common";
        ncritem.Ncrcommonfrom = ddlcommonfrom.options[ddlcommonfrom.selectedIndex].text;
    }
    else if (radiouncommon.checked == true) {
        ncritem.Ncrcommonuncommon = "uncommon";
        ncritem.Ncrcommonfrom = 'Top Section';
    }
    else {
        ncritem.Ncrcommonuncommon = 'uncommon';
    }


    ncritem.MakeReadyPerPlateCheck = hid_makeready.value;
    ncritem.WashupChargePerColourCheck = hid_washup.value;

    ncritem.EstimateLithoNCRItemID = NcrEditID;

    ncritem.NCRside1inkvalue = hid_FinalInkSave1.value;
    ncritem.NCRside2inkvalue = hid_FinalInkSave2.value;

    var partnumber = "Part 1";
    if (thisvalue == 0) {
        partnumber = "Part 1";
    }
    if (thisvalue == 1) {
        partnumber = "Part 2";
    }
    if (thisvalue == 2) {
        partnumber = "Part 3";
    }
    if (thisvalue == 3) {
        partnumber = "Part 4";
    }
    if (thisvalue == 4) {
        partnumber = "Part 5";
    }
    if (thisvalue == 5) {
        partnumber = "Part 6";
    }
    if (thisvalue == 6) {
        partnumber = "Part 7";
    }
    if (thisvalue == 7) {
        partnumber = "Part 8";
    }
    if (thisvalue == 8) {
        partnumber = "Part 9";
    }
    if (thisvalue == 9) {
        partnumber = "Part 9";
    }

    //    if (hid_incrementvalue.value == '0') {
    ncritem.Sectionreference = partnumber;
    //    }
    //    else {
    //        ncritem.Sectionreference = txtSectionRef.value;
    //    }

    if (QueryType == "add" || QueryType == "edit") {
        ncrArray.push(ncritem);
    }

}