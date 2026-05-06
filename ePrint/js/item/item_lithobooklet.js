function LithoBookletItemClass() {
    this.Title;
    this.EstimateTyp;
    this.SectionRef;
    this.Quantity;
    this.PressID;
    this.PaperName;
    this.PressType;
    this.PaperID;
    this.PaperName;
    this.PriceForWhaolePack;
    this.PaperSupplied;
    this.SetupSpoilage;
    this.RunningSpoilage;
    this.NoOfPagesRequired;
    this.PagesPerSection;
    this.Color;
    this.IsDoubleSided; this.PrintSheetSizeID;
    this.IsPrintCustom; this.PrintSheetHeight;
    this.PrintSheetWidth; this.JobFlatSizeID;
    this.IsJobCustom; this.JobFlatSizeHeight;
    this.JobFlatSizeWidth; this.IsIncludeGutters;
    this.GutterHorizontal; this.GutterVertical;
    this.IsPressRestrictions;
    this.NonImageHeight;
    this.NonImageWidth;
    this.GuilotineID;
    this.GuilotineName; this.IsFirstTrim;
    this.IsSecondTrim;
    //booklet new changes

    this.BookletType;
    this.NoOfPagesInSection;
    this.PagesPerSignature;
    this.NoOfSignatures;
    this.BookletFormat;
    //Print Layout          
    this.PrintLayout;
    this.LandscapeValue; this.PortraitValue;
    this.QtyList;
    this.Qty1; this.Qty2;
    this.Qty3; this.Qty4;
    this.QuantityType;
    this.SideColor;
    this.QuantityList = [];
    this.EstimateLithoBookletItemID;
    this.IsDeletedID;

    //for
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

    this.MakeReadyPerPlateCheck;
    this.WashupChargePerColourCheck;

    this.NCRside1inkvalue;
    this.NCRside2inkvalue;
    this.isCeilPrintSheetPerSection;
    this.CheckPerfecting;
    this.ManualValue;

}

function SendPaperIDandName(id, values, papertype) {
    lblDefaultPaper.title = values;
    lblDefaultPaper.innerHTML = trim12(values);
    lblDefaultPaper.style.cursor = "pointer";
    hdnpaperID.value = id;

    Paper_AssignToSummary();

    PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
}

function GetPaperValue(result) {
    hdn_PaperProperties.value = result;
    var papertype = document.getElementById("spnPaperType").innerHTML;
    if (trim12(papertype) == "sheet(s)") {

    }
    else {
        var str2 = result.split('µ');
        var PaperSizeID = str2[0];
        var Height = str2[1];
        var Width = str2[2];
        //        txtsectionheight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Height, 0, '', false, false, false);
        //        txtsectionwidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Width, 0, '', false, false, false);
        //Calculations(); //1

    }
}
function Calculations() {
    //if (!chkPrintSheet.checked) {
    //    LoadToSheetCustom();
    //}

    //if (!ChkJobFlatCustom.checked) {
    //    LoadToJobCustom();
    //}
}
function setwidth() {
    var is_ie = (/msie/i.test(navigator.userAgent) && !/opera/i.test(navigator.userAgent));
    if (is_ie) {
        document.getElementById("div_GuttersCustomSize").style.width = "220px";
    }
    else {
        document.getElementById("div_GuttersCustomSize").style.width = "230px";
    }
}
setwidth();

var Previous = '';
function QtyFromStage1() {
    tempEstimateType = 'printbroker';
    ShowPrintBroker();
    ArrangePrintBroker(hid_QtyType.value);
    Use_add_more();
}

function Validate_Before_Outwork() {
    if (productType == "singleitem" || productType == "booklet" || productType == "pads") {
        if (CreateItemValidation()) {
            if (ValidatePaper_HeightWidth()) {
                QtyFromStage1();
            }
        }
    }
    else if (estimateType == 'largeformat') {
        if (CreateItemValidation()) {
            if (ValidatePaper_HeightWidth()) {
                QtyFromStage1();
            }
        }
    }
}

function GuillotineSelect() {
    // PopupCenter(strSitepath + "common/common_popup.aspx?type=moreplant&pg=estimate", '800', '400')
    window.radopen(strSitepath + "common/common_popup.aspx?type=moreplant&pg=estimate", '800', '400');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}

function LoadToItemTitle(txtValue) {
    var txt1 = txtSummaryItemTitle;
    var txt2 = txtItemTitle;
    var txt3 = txtPadItemTitle;
    var txt4 = txtLargeItemTitle;

    txt1.value = txtValue;
    txt2.value = txtValue;
    txt3.value = txtValue;
    txt4.value = txtValue;
}

var tempEstimateType = '';
function popup_phrasebook(type) {
    // PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
    window.radopen(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400');
    SetRadWindow('divrad', 'divBackGroundNew', '200');
}

function HighlightTab(isscost) {
    document.getElementById(isscost).className = "booklet_section_active";
    for (var i = 0; i < rowcount; i++) {
        var dd = "spncost_" + i;
        if (dd != '') {
            if (dd != isscost) {
                if (document.getElementById("spncost_" + i) != null) {
                    document.getElementById("spncost_" + i).style.color = "black";
                }
            }
        }
    }
    var type = '';
    if (estimateType == "othercost") {
        type = 'm'; //other cost as main item from add page
    }
    else if (estimateType == "othercosttab") {
        type = 'u'; //other cost as main item from summary page
    }
    else {
        type = 's'; //other cost as sub item from add page
    }
    BindOtherCost(document.getElementById(isscost).id, type);
}

function SectionsData(JCount, SCount) {



    var data = ''
    data += " <div id='div_Sec_" + TakeCount + "' align='left'> ";
    data += " <div style='float: left;'>";
    data += " <input id='btn_" + SCount + "' type='button' class='button' onclick=LoadSectionValues(" + TakeCount + ")  value='" + SCount + "' />";
    data += " </div>";
    data += " <div style='float:left;width:10px'>&nbsp;</div>";
    data += " </div>";
    document.getElementById("div_btn_booklet_sections").innerHTML += data;
    ClaerSectionData();

}

var IsAnyOutWork = false;
var IsAnyWarehouse = false;
var IsAnyOtherCost = false;

function validatethis(val) {
    if (val != '') {
        document.getElementById("spn_txtQuantity").style.display = "none";
    }
}

function LoadToSheetCustom(ddlValue) {
    const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
    const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;
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
                txtsectionheight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[2], decimalPlaces, '', false, false, false);
                txtsectionwidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[3], decimalPlaces, '', false, false, false);
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
        var arr1 = dpaperhw.split('»'); //hid_ddlPrintSheetSize.value.split('µ');
        for (var i = 0; i < arr1.length; i++) {
            var arr2 = arr1[i].split('±');
            if (ddlValue == arr2[0]) {
                txtitemheight.value = arr2[1];
                txtitemwidth.value = arr2[2];
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

        txtsectionheight.focus();
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
        txtitemheight.focus();
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
        txtGutterHorizontal.focus();
    }
    else {
        document.getElementById("div_GuttersCustomSize").style.display = "none";
    }
}

function PrintLayout(chkLayout, chkLayoutID) {

    if (chkLayout == "landscape") {
        chkPortrait.checked = false;
        chkManual.checked = false;
    }
    else if (chkManual == "portrait") {
        chkLandscape.checked = false;
        chkManual.checked = false;
    } else {
        chkLandscape.checked = false;
        chkPortrait.checked = false;
    }
    var chCheck = document.getElementById(chkLayoutID).checked;
    if (!chCheck) {
        document.getElementById(chkLayoutID).checked = true;
    }
}

function CollectQuantity() {
    QType = hid_QtyType.value;
    if (QType == "S") {
        hid_Q1.value = txtQuantity.value;
    }
    else if (QType == "R") {
        hid_Q1.value = txtQuantity.value;
        hid_Q2.value = txtRunOnQty.value;
    }
    else if (QType == "M") {
        hid_Q1.value = txtQuantity.value;
        hid_Q2.value = txtQuantity_2.value;
        hid_Q3.value = txtQuantity_3.value;
        hid_Q4.value = txtQuantity_4.value;
    }
}

function StoreStage1_Data() {
    hid_Stage1_values.value = stage1_values;
}

function TakeQtyValues(ObjArray) {
    var ListOfQuantity = '';
    for (var q = 0; q < ObjArray.length; q++) {
        var Qtype = ObjArray[0].QtyType;
        if (Qtype == "S") {
            ListOfQuantity = ObjArray[0].Quantity1;
        }
        else if (Qtype == "R") {
            ListOfQuantity = ObjArray[0].Quantity1 + "-" + ObjArray[0].Quantity2;
        }
        else if (Qtype == "M") {
            ListOfQuantity = ObjArray[0].Quantity1 + "-" + ObjArray[0].Quantity2 + "-" + ObjArray[0].Quantity3 + "-" + ObjArray[0].Quantity4;
        }
    }

    return ListOfQuantity;
}

function SaveData() {

    //CollectQuantity(); //FOR BOOKLET see TakeQtyValues(bookArr[0].QuantityList);

    var StoreBooklet = '';
    for (var i = 0; i < bookArr.length; i++) {
        StoreBooklet += "Title»" + bookArr[i].Title + '±';
        StoreBooklet += "EstimateTyp»" + bookArr[i].EstimateTyp + '±';
        StoreBooklet += "SectionRef»" + bookArr[i].SectionRef + '±';
        StoreBooklet += "Quantity»" + bookArr[i].Quantity + '±';
        StoreBooklet += "PressID»" + bookArr[i].PressID + '±';
        StoreBooklet += "PressType»" + bookArr[i].PressType + '±';
        StoreBooklet += "PaperID»" + bookArr[i].PaperID + '±';
        StoreBooklet += "PriceForWhaolePack»" + bookArr[i].PriceForWhaolePack + '±';
        StoreBooklet += "PaperSupplied»" + bookArr[i].PaperSupplied + '±';
        StoreBooklet += "SetupSpoilage»" + bookArr[i].SetupSpoilage + '±';
        StoreBooklet += "RunningSpoilage»" + bookArr[i].RunningSpoilage + '±';

        //StoreBooklet += "NoOfPagesRequired»" + bookArr[i].NoOfPagesRequired +'±';
        //StoreBooklet += "PagesPerSection»" + bookArr[i].PagesPerSection +'±';
        StoreBooklet += "BookletType»" + bookArr[i].BookletType + '±';
        StoreBooklet += "NoOfPagesInSection»" + bookArr[i].NoOfPagesInSection + '±';
        StoreBooklet += "PagesPerSignature»" + bookArr[i].PagesPerSignature + '±';
        StoreBooklet += "NoOfSignatures»" + bookArr[i].NoOfSignatures + '±';

        StoreBooklet += "PrintSheetSizeID »" + bookArr[i].PrintSheetSizeID + '±';
        StoreBooklet += "IsPrintCustom »" + bookArr[i].IsPrintCustom + '±';
        StoreBooklet += "PrintSheetHeight »" + bookArr[i].PrintSheetHeight + '±';
        StoreBooklet += "PrintSheetWidth »" + bookArr[i].PrintSheetWidth + '±';

        StoreBooklet += "JobFlatSizeID »" + bookArr[i].JobFlatSizeID + '±';
        StoreBooklet += "IsJobCustom »" + bookArr[i].IsJobCustom + '±';
        StoreBooklet += "JobFlatSizeHeight »" + bookArr[i].JobFlatSizeHeight + '±';
        StoreBooklet += "JobFlatSizeWidth »" + bookArr[i].JobFlatSizeWidth + '±';

        StoreBooklet += "IsIncludeGutters »" + bookArr[i].IsIncludeGutters + '±';
        StoreBooklet += "GutterHorizontal »" + bookArr[i].GutterHorizontal + '±';
        StoreBooklet += "GutterVertical »" + bookArr[i].GutterVertical + '±';
        StoreBooklet += "IsPressRestrictions »" + bookArr[i].IsPressRestrictions + '±';
        StoreBooklet += "NonImageHeight »" + bookArr[i].NonImageHeight + '±';
        StoreBooklet += "NonImageWidth »" + bookArr[i].NonImageWidth + '±';

        StoreBooklet += "PrintLayout»" + bookArr[i].PrintLayout + '±';
        StoreBooklet += "PortraitValue»" + bookArr[i].PortraitValue + '±';
        StoreBooklet += "LandscapeValue»" + bookArr[i].LandscapeValue + '±';

        StoreBooklet += "ManualValue»" + bookArr[i].ManualValue + '±';

        StoreBooklet += "GuilotineID »" + bookArr[i].GuilotineID + '±';
        StoreBooklet += "IsFirstTrim »" + bookArr[i].IsFirstTrim + '±';
        StoreBooklet += "IsSecondTrim »" + bookArr[i].IsSecondTrim + '±';

        StoreBooklet += "EstimateLithoBookletItemID »" + bookArr[i].EstimateLithoBookletItemID + '±';
        StoreBooklet += "IsDeleted »" + bookArr[i].IsDeleted + '±';

        StoreBooklet += "BookletFormat »" + bookArr[i].BookletFormat + '±';

        StoreBooklet += "Noofsidesprinted»" + bookArr[i].Noofsidesprinted + '±';
        StoreBooklet += "Side1color»" + bookArr[i].Side1color + '±';
        StoreBooklet += "Side2color»" + bookArr[i].Side2color + '±';
        StoreBooklet += "Checkturn»" + bookArr[i].Checkturn + '±';
        StoreBooklet += "Checktumble»" + bookArr[i].Checktumble + '±';
        StoreBooklet += "ChkSheetWork»" + bookArr[i].ChkSheetWork + '±';
        StoreBooklet += "Platename»" + bookArr[i].Platename + '±';
        StoreBooklet += "PlateID»" + bookArr[i].PlateID + '±';
        StoreBooklet += "Plate»" + bookArr[i].Plate + '±';
        StoreBooklet += "Makeready»" + bookArr[i].Makeready + '±';
        StoreBooklet += "Washup»" + bookArr[i].Washup + '±';

        StoreBooklet += "NCRside1inkvalue »" + bookArr[i].NCRside1inkvalue + '±';
        StoreBooklet += "NCRside2inkvalue »" + bookArr[i].NCRside2inkvalue + '±';
        StoreBooklet += "isCeilPrintSheetPerSection»" + bookArr[i].isCeilPrintSheetPerSection + '±';
        StoreBooklet += "CheckPerfecting»" + bookArr[i].CheckPerfecting + '±';
        StoreBooklet += "QtyList»" + TakeQtyValues(bookArr[i].QuantityList) + "";
        // Move to the another function
        StoreBooklet += "µ";
    }

    hid_booklet_save.value = StoreBooklet;
    return true;
}

function CalculateBookletSection() {
    if (txtNoOfPagesInSection.value != '') {

        if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {



            if (Number(txtNoOfPagesInSection.value) % 4 != 0 || Number(txtNoOfPagesInSection.value) == 0) {
                document.getElementById("spn_txtNoOfPagesInSection_divide").style.width = "185px";
                document.getElementById("spn_txtNoOfPagesInSection_divide").innerHTML = "Section must be divisible by 4. e.g 4, 8, 12 etc";
                document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "block";

                document.getElementById("spn_txtNoOfPagesInSection").style.display = "none";

                return false;
            }
        }
        else if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'perfectbound') {



            if (Number(txtNoOfPagesInSection.value) % 2 != 0 || Number(txtNoOfPagesInSection.value) == 0) {
                document.getElementById("spn_txtNoOfPagesInSection_divide").style.width = "185px";
                document.getElementById("spn_txtNoOfPagesInSection_divide").innerHTML = "Section must be divisible by 2. e.g 2, 4, 6 etc";
                document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "block";

                document.getElementById("spn_txtNoOfPagesInSection").style.display = "none";

                return false;
            }

        }


        document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "none";

        var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value);
        if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity" || NoOfSignature == "-Infinity") {
            //            txtNoOfSignatures.value = "0";
            //            txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);

            txtNoOfSignatures.value = GetNoOfSignatures("0");

            //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 0, 'ForBooklet', false, false, false);
        }
        else {
            //            if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
            //                txtNoOfSignatures.value = "1";
            //                txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);
            //                //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 0, 'ForBooklet', false, false, false);
            //            }
            //            else {
            //txtNoOfSignatures.value = parseInt(Math.ceil(NoOfSignature), 0); // this is commented on 4/18/2011 as per confirmation from phil and vikash sir -- By smitha
            //            txtNoOfSignatures.value = NoOfSignature;
            //            txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 2, 'ForBooklet', false, false, false);

            txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);

            //}
        }
        BindPlatesMakeready();
        return true;

    }
}

function SetPerfectbound_vs_Saddlestiched() {
    if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
        document.getElementById("div_PrintLayout").style.display = "block";
        document.getElementById("div_Booklet_itemSize").style.display = "block";
        document.getElementById("div_Booklet_Format").style.display = "block";
        if (txtNoOfPagesInSection.value == "2") {
            txtNoOfPagesInSection.value = "4";
        }
    }
    else if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'perfectbound') {
        document.getElementById("div_PrintLayout").style.display = "block";
        document.getElementById("div_Booklet_itemSize").style.display = "none";
        document.getElementById("div_Booklet_Format").style.display = "none";

        if (txtNoOfPagesInSection.value == "4") {
            txtNoOfPagesInSection.value = "2";
        }
    }
}

function CalculateBookletPages() {
    if (IsIntegerParameter(txtPagesPerSignature.value, 'spn_txtPagesPerSignatureNumber')) {
        if (Number(txtPagesPerSignature.value) % 2 != 0 || Number(txtPagesPerSignature.value) == 2 || Number(txtPagesPerSignature.value) == 0) {
            if (window.confirm('Selected layout is not valid for booklet\n Do you want to continue?')) {
                alert('Pages per print sheet must be divisible by 4.\n e.g 4,8,12 etc');
                txtPagesPerSignature.value = GetPagesPerSignature("4");
                var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value)
                if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity" || NoOfSignature == "-Infinity") {
                    //                    txtNoOfSignatures.value = "0";
                    //                    txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);


                    txtNoOfSignatures.value = GetNoOfSignatures("0");

                    //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 0, 'ForBooklet', false, false, false);
                }
                else {
                    //                    if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
                    //                        txtNoOfSignatures.value = "1";
                    //                        txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);
                    //                        //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 0, 'ForBooklet', false, false, false);
                    //                    }
                    //                    else {
                    //  txtNoOfSignatures.value = parseInt(NoOfSignature, 0); // this is commented on 4/18/2011 as per confirmation from phil and vikash sir -- By smitha
                    //                    txtNoOfSignatures.value = NoOfSignature;
                    //                    txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 2, 'ForBooklet', false, false, false);

                    txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);

                    //}
                }
            }
            return false;
        }
        else {
            var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value)
            if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity" || NoOfSignature == "-Infinity") {
                //                txtNoOfSignatures.value = "0";
                //                txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);

                txtNoOfSignatures.value = GetNoOfSignatures("0");

                //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 0, 'ForBooklet', false, false, false);
            }
            else {
                //                if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
                //                    txtNoOfSignatures.value = "1";
                //                    txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);
                //                    //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 0, 'ForBooklet', false, false, false);
                //                }
                //                else {
                //  txtNoOfSignatures.value = parseInt(NoOfSignature, 0); // this is commented on 4/18/2011 as per confirmation from phil and vikash sir -- By smitha
                //                txtNoOfSignatures.value = NoOfSignature;
                //                txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 2, 'ForBooklet', false, false, false);

                txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);

                //}
            }
            return true;
        }
    }
}

function PricePrevious() {
    document.getElementById("div_stage_2").style.display = "block";
    div_price_catalogue.style.display = "none";
}

function PriceNext() {
    if (Price_Array.length > 0) {
        document.getElementById("div_price_valid").style.display = "none";
        div_price_catalogue.style.display = "none";
        div_pricecatalogue_summary.style.display = "block";
        document.getElementById("div_stage_4").style.display = "block";
        BindCatalogueDesc();
    }
    else {
        document.getElementById("div_price_valid").style.display = "block";
    }

}

function PricePreviousStage4() {
    div_pricecatalogue_summary.style.display = "none";
    document.getElementById("div_stage_4").style.display = "none";
    div_price_catalogue.style.display = "block";
}

function Booklet_Click_Next() {
    var IsItOk = true;


    IsItOk = CreateItemValidation();
    var IsBookletValid = true;


    if (IsItOk) {
        if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
            if (Number(txtNoOfPagesInSection.value) % 4 != 0 || Number(txtNoOfPagesInSection.value) == 0) {
                IsBookletValid = false;
                CalculateBookletSection();
            }
        }
        if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'perfectbound') {
            if (Number(txtNoOfPagesInSection.value) % 2 != 0 || Number(txtNoOfPagesInSection.value) == 0) {
                IsBookletValid = false;
                CalculateBookletSection();
            }
        }


        if (IsItOk && IsBookletValid) {
            if (ValidatePaper_HeightWidth()) {
                var SectionRef = txtSectionRef.value;
                var NoS = bookArr.length;


                StoreSections();
                GenerateSection();
                for (var i = 0; i < bookArr.length; i++) {
                    if (SectionRef == bookArr[i].SectionRef) {
                        if (document.getElementById("btn_" + i + "") != null) {
                            document.getElementById("btn_" + i + "").className = "booklet_section_active";
                            PresentSectionID = i;
                        }
                    }
                }

                if (modulename != 'invoice') {
                    InnventoryPrompt();
                    return SaveData();
                }
                else if (modulename == 'invoice') {
                    SaveData();
                    return InnventoryPrompt();
                }
            }
        }
    }
    else {
        return false;
    }
    return false;
}

var IsPriceLoaded = false;
function ForSummary(obj) {

}

function ddlColors_Change(objValue) {
    var ColorValue = '';
    if (objValue == "color") {
        ColorValue = "Colour";
    }
    else {
        ColorValue = "Black & White";
    }
    if (estimateType == 'digital') {
        if (productType == 'singleitem') {
            txtSummaryColor.value = ColorValue;
        }
        else if (productType == 'booklet') {
            txtbookletColor.value = ColorValue;
        }
        else if (productType == 'pads') {
            txtPadColor.value = ColorValue;
        }
    }
    else if (estimateType == 'largeformat') {
        txtLargeColor.value = ColorValue;
    }
}

////BY VINAY On 23 / 02 / 2010
function Side2_block() {
    document.getElementById("spnSide1").style.display = "block";
    document.getElementById("div_side2").style.display = "block";
    ddlColors.style.width = "120px";
}

function Side2_none() {
    document.getElementById("spnSide1").style.display = "none";
    document.getElementById("div_side2").style.display = "none";
    ddlColors.style.width = "175px";
}

function showSides(IsChecked) {
    if (IsChecked) {
        Side2_block();
    }
    else {
        Side2_none();
    }
}

function Color_AssignToSummary() {

}

function CheckDDLValues(values) {
    if (values == "color") {
        return "Colour";
    }
    else {
        return "Black & White";
    }
}

function ItemSize_AssignToSummary(Parameter) {


}

function Paper_AssignToSummary() {

}

function MadeProductDefault() {
}

function moreQty(para1) {
    try {
        txtQuantity.focus();
        if (navigator.appName == "Microsoft Internet Explorer") {
            if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
                var ieversion = new Number(RegExp.$1)
                if (ieversion >= 6) {
                    document.getElementById("div_RunOnQty").className = "absolutepos";
                    //document.getElementById("div_Addmore").className="absolutepos";
                }
                if (ieversion >= 7) {
                    document.getElementById("div_RunOnQty").className = "absolutepos7";
                    //document.getElementById("div_Addmore").className="absolutepos7";
                }
            }
        }
        else {
            if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)) {
                var ffversion = new Number(RegExp.$1);

                if (ffversion == 3) {
                    document.getElementById("div_RunOnQty").className = "absolutepos1ff";
                    //document.getElementById("div_Addmore").className="absolutepos1ff";
                }
                if (ffversion >= 3.5) {
                    document.getElementById("div_RunOnQty").className = "absolutepos1";
                    //document.getElementById("div_Addmore").className="absolutepos1";
                }
            }
        }
        if (IsQtyDisabled == false) {
            if (para1 == "single") {
                document.getElementById(div_Qty2to4).style.display = "none";
                document.getElementById("div_Addmore").style.display = "none";
                hid_QtyType.value = "S";

                document.getElementById("hrefQtyMore").style.display = "block";
                document.getElementById("hrefQtySingle").style.display = "none";
            }
            else if (para1 == "more") {
                document.getElementById(div_Qty2to4).style.display = "block";
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("div_qty_3to4").className = "bglabelEmpty";
                }
                else {
                    document.getElementById("div_qty_3to4").className = "bglabelEmpty1";
                }
                document.getElementById("div_Addmore").style.display = "block"

                hid_QtyType.value = "M";
                document.getElementById("hrefQtyMore").style.display = "none";
                document.getElementById("hrefQtySingle").style.display = "block";

                document.getElementById("div_RunOnQty").style.display = "none";
                chkRunOnQty.checked = false;
            }
            else if (para1 == "runonqty") {
                document.getElementById(div_Qty2to4).style.display = "none"
                document.getElementById("div_Addmore").style.display = "none";
                if (chkRunOnQty.checked) {
                    document.getElementById("div_RunOnQty").style.display = "block";
                    hid_QtyType.value = "R";
                }
                else {
                    document.getElementById("div_RunOnQty").style.display = "none";
                    hid_QtyType.value = "S";
                }
            }
        }
        else {
            if (chkRunOnQty.checked) {
                chkRunOnQty.checked = false;
            }
        }
    }
    catch (err) {
    }
}

function AllSummaryNone() {
    document.getElementById(div_SingleItemSummary).style.display = "none";
    document.getElementById(div_BookletSummary).style.display = "none";
    document.getElementById(div_PadSummary).style.display = "none";
    document.getElementById(div_PrintBrokerSummary).style.display = "none";
    document.getElementById(div_OtherCostSummary).style.display = "none";
    document.getElementById(div_WarehouseSummary).style.display = "none";
    document.getElementById(div_LargeFormatSummary).style.display = "none";
    document.getElementById(div_PriceCatalogueSummary).style.display = "none";
}

function whenPageLoad() {
    //When Page Loads
    document.getElementById(div_Product_Type).style.display = "none";
    document.getElementById(div_only_digitalsleft).style.display = "none";
    document.getElementById(div_only_digitalsright).style.display = "none";

}

function WhenProductTypeEmpty() {
    ////Please select Estimate Type
    document.getElementById("div_none").style.display = "block";
    document.getElementById("span_none").innerHTML = "Please select Product Type";
}

function Is_Maximum_Booklet_Section() {
    //BY VINAY
    if (bookArr.length > 10) {
        alert('Maximum section in booklet is 10 only');
        return true;
    }
    else {
        return false;
    }
}

var bookArr = new Array();
var TakeCount = 0;
var CountSection = 1;

function MoveNextSection() {
    var IsItOk = true;
    IsItOk = CreateItemValidation();


    if (IsItOk) {

        var IsBookletValid = true;

        if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
            if (Number(txtNoOfPagesInSection.value) % 4 != 0 || Number(txtNoOfPagesInSection.value) == 0) {
                IsBookletValid = false;
                CalculateBookletSection();
            }
        }
        else if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'perfectbound') {
            if (Number(txtNoOfPagesInSection.value) % 2 != 0 || Number(txtNoOfPagesInSection.value) == 0) {
                IsBookletValid = false;
                CalculateBookletSection();
            }
        }


        if (IsItOk && IsBookletValid) {
            if (ValidatePaper_HeightWidth()) {
                document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "none";
                var NoS = bookArr.length;



                StoreSections();
                txtSectionRef.value = "Section 1";
                GenerateSection();
                if (QueryType == 'add') {
                    PressOnChange();
                    txtNoOfPagesInSection.value = '';
                    txtPagesPerSignature.value = GetPagesPerSignature("0");
                    //                txtNoOfSignatures.value = 0;
                    //                txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);


                    txtNoOfSignatures.value = GetNoOfSignatures("0");

                    //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 0, 'ForBooklet', false, false, false);
                }
                else {
                    //ClaerSectionData();
                    txtNoOfPagesInSection.value = '';
                    txtPagesPerSignature.value = GetPagesPerSignature("0");
                    //                txtNoOfSignatures.value = 0;
                    //                //txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);
                    //                txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 2, 'ForBooklet', false, false, false);

                    txtNoOfSignatures.value = GetNoOfSignatures("0");

                }
            }
            return true;
        }


    }
    else {
        return false;
    }

}

//Booklet Only
function CallRecalculateFun() {
    if (bookArr.length == 0) {
        hdn_PortraitValue.value = txtNoOfSignatures.value;
        ReCalculateVariableQty(); //to recalculate othercost variable hrsorqty
        //getOtherCostval();//to get othercost values
    }
}

function NewSection() {
    txtSectionRef.value = "Section 1";
    CopyToNewSection("0");
    hid_SectionCount.value = Number(hid_SectionCount.value) + 1; //to get section count
    hid_value.value = hid_SectionCount.value;
    hid_PresntSection.value = hid_SectionCount.value;

    if (ddlPress.options[ddlPress.selectedIndex].value != 0) {
        __doPostBack('ctl00$ContentPlaceHolder1$UcBooklet$lnkNewSection', '');
    }
}

function GenerateSection() {


    var data = '';
    for (var i = 0; i < bookArr.length; i++) {
        //data += " <div align='left'> ";
        data += " <div style='float: left;'>";
        data += " <input id='btn_" + i + "' onclick=LoadSectionValues(" + i + "); value='" + Number(i + 1) + "' type='button' class='button' />";
        data += " </div>";
        data += " <div style='float:left;width:10px'>&nbsp;</div>";
        //data += " </div>";
        if (Number(i + 1) % 5 == 0) {
            data += "<div class='only5px'></div>";
        }
    }
    document.getElementById("div_btn_booklet_sections").innerHTML = data;
    //BY VINAY MakeDisable('yes');
}

//Delete Sections one by one
var PresentSectionID;
function SectionDelete() {
    if (bookArr.length == 1) {
        alert('This Estimate type has only one section,You cant able to delete')
    }
    else {
        if (bookArr.length > 0) {
            if (window.confirm(Delete_Confirmation)) {

                document.getElementById(hid_DeletedID_id).value = EditID;
                bookArr.splice(PresentSectionID, 1);
                ClaerSectionData();
                GenerateSection();
                if (bookArr.length == 0) {
                    MakeDisable('no');
                }

                PresentSectionID = null;

                //to get no of sections value on section delete
                hid_SectionCount.value = Number(hid_SectionCount.value) - 1;


                //            // by Gaj
                //            if (bookArr.length == 1) {
                //                document.getElementById("ctl00_ContentPlaceHolder1_UcBooklet_Button16").style.display = 'none';
                //            }
                LoadSectionValues(0);
                return true;
            }
            else {
                return false;
            }
        }
        else {
            alert('Please select one section');
            return false;
        } return false;
    }
}

var IsQtyDisabled = false;
function MakeDisable(type) {
    if (type == 'yes') {
        txtItemTitle.disabled = true;
        ddlEsti.disabled = true;
        ddlProd.disabled = true;
        txtQuantity.disabled = true;
        txtRunOnQty.disabled = true;
        txtQuantity_2.disabled = true;
        txtQuantity_3.disabled = true;
        txtQuantity_4.disabled = true;
        IsQtyDisabled = false; //// IsQtyDisabled=true;
    }
    else {
        txtItemTitle.disabled = false;
        ddlEsti.disabled = false;
        ddlProd.disabled = false;
        txtQuantity.disabled = false;
        txtRunOnQty.disabled = false;
        txtQuantity_2.disabled = false;
        txtQuantity_3.disabled = false;
        txtQuantity_4.disabled = false;
        IsQtyDisabled = false;
    }
}

function LoadSectionValues(nos) {
    hid_value.value = Number(nos) + 1;
    hid_PresntSection.value = Number(nos) + 1; //to get no of count
    MoveNextSection();
    for (var i = 0; i < bookArr.length; i++) {
        if (document.getElementById("btn_" + i + "") != null) {

            if (nos == i) {
                document.getElementById("btn_" + i + "").className = "booklet_section_active";
            }
            else {
                document.getElementById("btn_" + i + "").className = "button";
                document.getElementById("btn_" + i + "").className = "button";
            }
        }
    }

    PresentSectionID = nos;
    if (nos == 0) {
        //BY VINAY MakeDisable('no');
    }
    else {
        //BY VINAY MakeDisable('yes');
    }
    EditID = bookArr[nos].EstimateLithoBookletItemID;
    BookletPrintLayout = bookArr[nos].PrintLayout;
    //BY VINAY For Booklet Separate Qty
    LoadBackQty(bookArr[nos].QuantityList);

    txtItemTitle.value = bookArr[nos].Title;
    //bookArr[nos].EstimateTyp = productType;
    txtSectionRef.value = bookArr[nos].SectionRef;
    txtQuantity.value = bookArr[nos].Quantity;
    var ddlPress = document.getElementById("ctl00_ContentPlaceHolder1_UcBooklet_ddlPress");

    for (var i = 0; i < ddlPress.length; i++) {
        if (bookArr[nos].PressID == ddlPress[i].value) {
            ddlPress.selectedIndex = i;
        }
    }
    //alert(ddlPress.options[ddlPress.selectedIndex].value);    

    hdnpaperID.value = bookArr[nos].PaperID;
    try {
        PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
    }
    catch (errrorrr) {
    }
    lblDefaultPaper.innerHTML = bookArr[nos].PaperName;
    ChkPriceForWholePack.checked = bookArr[nos].PriceForWhaolePack;
    ChkPaperSupplied.checked = bookArr[nos].PaperSupplied;
    txtSetupSpoilage.value = bookArr[nos].SetupSpoilage;
    txtRunningSpoilage.value = bookArr[nos].RunningSpoilage;
    txtNoOfPagesRequired.value = bookArr[nos].NoOfPagesRequired;
    txtPagesPerSection.value = bookArr[nos].PagesPerSection;
    ///var ddlColor = document.getElementById("<%=ddlColors.ClientID %>");//.value = bookArr[nos].Color;//DDL

    for (var i = 0; i < ddlColors.length; i++) {
        if (bookArr[nos].Color == ddlColors[i].value) {
            ddlColors.selectedIndex = i;
        }
    }

    chkDoubleSided.checked = bookArr[nos].IsDoubleSided;

    if (chkDoubleSided.checked) {
        for (var i = 0; i < ddlColors_2.length; i++) {
            if (bookArr[nos].SideColor == ddlColors_2[i].value) {
                ddlColors_2.selectedIndex = i;
            }
        }
        Side2_block();        
    }
    else {
        Side2_none();
    }
    // show checkboxes
    if (bookArr[nos].Noofsidesprinted == "Double")
    {
        document.getElementById("div_work").style.display = "block";
    }
    else if (bookArr[nos].Noofsidesprinted == "Single")
    {
        document.getElementById("div_work").style.display = "none";
    }
    //var ddlPrintSheetSize = document.getElementById("<%=ddlPrintSheetSize.ClientID %>");//.value = bookArr[nos].PrintSheetSizeID;

    for (var i = 0; i < ddlPrintSheetSize.length; i++) {
        if (bookArr[nos].PrintSheetSizeID == ddlPrintSheetSize[i].value) {
            ddlPrintSheetSize.selectedIndex = i;
        }
    }
    chkPrintSheet.checked = bookArr[nos].IsPrintCustom;
    PrintSheetCustom(chkPrintSheet.id); //FUNCTION
    txtsectionheight.value = bookArr[nos].PrintSheetHeight;
    txtsectionwidth.value = bookArr[nos].PrintSheetWidth;

    ////var ddlJobItemSize = document.getElementById("<%=ddlJobItemSize.ClientID %>");//.value = bookArr[nos].JobFlatSizeID; ///DDL

    for (var i = 0; i < ddlJobItemSize.length; i++) {
        if (ddlJobItemSize[i].value == bookArr[nos].JobFlatSizeID) {
            ddlJobItemSize.selectedIndex = i;
        }
    }

    ChkJobFlatCustom.checked = bookArr[nos].IsJobCustom;
    JobItemCustom(ChkJobFlatCustom.id); //FUNCTION 
    txtitemheight.value = bookArr[nos].JobFlatSizeHeight;
    txtitemwidth.value = bookArr[nos].JobFlatSizeWidth;

    chkGutters.checked = bookArr[nos].IsIncludeGutters;
    GuttersCustom(chkGutters.id); //FUNCTION 
    txtGutterHorizontal.value = bookArr[nos].GutterHorizontal;
    txtGutterVertical.value = bookArr[nos].GutterVertical;
    lblDefaultPaper.title = SpecialDecode(bookArr[nos].PaperName);
    lblPaperWeight.innerHTML = bookArr[nos].PaperWeight;
    ChkPressRestrictions.checked = bookArr[nos].IsPressRestrictions;
    NonHeight = bookArr[nos].NonImageHeight;
    NonWeight = bookArr[nos].NonImageWidth;
    lblGuillotine.title = SpecialDecode(bookArr[nos].GuilotineName);
    hid_GuillotineID.value = bookArr[nos].GuilotineID;
    lblGuillotine.innerHTML = bookArr[nos].GuilotineName;
    ////new Development
    chkFirstTrim.checked = bookArr[nos].IsFirstTrim;
    chkSecondTrim.checked = bookArr[nos].IsSecondTrim;

    chkIsSilling.checked = bookArr[nos].isCeilPrintSheetPerSection == "1" ? true : false;
    //booklet changes

    //--------------------------------------


    if (bookArr[nos].PrintLayout == "P") {
        chkPortrait.checked = true;
        chkLandscape.checked = false;
        chkManual.checked = false;
    }
    else if (bookArr[nos].PrintLayout == "L") {
        chkLandscape.checked = true;
        chkManual.checked = false;
        chkPortrait.checked = false;
    } else {
        chkManual.checked = true;
        chkLandscape.checked = false;
        chkPortrait.checked = false;
    }

    txtlandscape.value = bookArr[nos].LandscapeValue;
    txtportrait.value = bookArr[nos].PortraitValue;
    txtManual.value = bookArr[nos].ManualValue;




    //--------------------------------------

    for (var i = 0; i < ddlBookletType.length; i++) {
        if (ddlBookletType[i].value == bookArr[nos].BookletType) {
            ddlBookletType.selectedIndex = i;
        }
    }

    txtNoOfPagesInSection.value = bookArr[nos].NoOfPagesInSection;
    txtPagesPerSignature.value = GetPagesPerSignature(bookArr[nos].PagesPerSignature);
    txtNoOfSignatures.value = bookArr[nos].NoOfSignatures;

    lblDefaultPlates.innerHTML = bookArr[nos].Platename;
    hdnplateID.value = bookArr[nos].PlateID;

    //by Swetha M.S on 12/4/2011 -- Ref BUGID:121
    txtNoOfPlates.value = bookArr[nos].Plate;
    txtNoOfMakeReady.value = bookArr[nos].Makeready;
    //by Swetha M.S on 12/4/2011 -- Ref BUGID:121

    for (var i = 0; i < ddlPlates.length; i++) {
        if (bookArr[nos].Plate == ddlPlates[i].value) {
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
        if (bookArr[nos].Makeready == ddlMakeReady[i].value) {
            ddlMakeReady.selectedIndex = i;
        }
    }

    for (var i = 0; i < ddlWashUp.length; i++) {
        if (bookArr[nos].Washup == ddlWashUp[i].value) {
            ddlWashUp.selectedIndex = i;
        }
    }

    for (var j = 0; j < ddlNoOfSide.length; j++) {
        if (ddlNoOfSide.options[j].text == bookArr[nos].Noofsidesprinted) {
            ddlNoOfSide.selectedIndex = j;
        }
    }

    if (bookArr[nos].Noofsidesprinted == 'Single') {
        for (var j = 0; j < ddlSide1Color.length; j++) {
            if (ddlSide1Color.options[j].text == bookArr[nos].Side1color) {
                ddlSide1Color.selectedIndex = j;
            }
        }
        document.getElementById("div_side2_colour").style.display = "none";
    }
    else if (bookArr[nos].Noofsidesprinted == 'Double') {
        document.getElementById("div_side2_colour").style.display = "block";
        for (var j = 0; j < ddlSide1Color.length; j++) {
            if (ddlSide1Color.options[j].text == bookArr[nos].Side1color) {
                ddlSide1Color.selectedIndex = j;
            }
        }

        for (var j = 0; j < ddlSide2Color.length; j++) {
            if (ddlSide2Color.options[j].text == bookArr[nos].Side2color) {
                ddlSide2Color.selectedIndex = j;
            }
        }

        chkTurn.checked = bookArr[nos].Checkturn == "1" ? true : false;
        chkTumble.checked = bookArr[nos].Checktumble == "1" ? true : false;
        chkPerfecting.checked = bookArr[nos].CheckPerfecting == "1" ? true : false;
        //        chkSecondTrim.checked = bookArr[nos].Checkturn == "1" ? true : false;
        //        chkSecondTrim.checked = bookArr[nos].Checktumble == "1" ? true : false;


        //        alert(chkTumble.checked);
        //        alert(chkTurn.checked);
        //        alert(chkSheetWork.checked);

        if (hid_isPressPerfect.value == 1 || hid_isPressPerfect.value == 'True') {
            document.getElementById("Div_PerfectChk").style.display = "block";
        }
        else {
            document.getElementById("Div_PerfectChk").style.display = "none";
        }
        if (!chkTumble.checked && !chkTurn.checked && !chkPerfecting.checked) {
            chkSheetWork.checked = true;
        }
        else {
            chkSheetWork.checked = false;
        }

    }


    for (var i = 0; i < ddlBookletFormat.length; i++) {
        if (ddlBookletFormat[i].value == bookArr[nos].BookletFormat) {
            ddlBookletFormat.selectedIndex = i;
        }
    }

    CreateItemValidation(); //BY VINAY
    document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "none";

    QtyFor_jobabdInvoice();
    //changetext();


    try {
        PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
    }
    catch (err) { }
}

function CopyToNewSection(sectionNo) {
    var indx = sectionNo;
    if (bookArr[indx] != null) {
        txtItemTitle.value = bookArr[indx].Title;
        //bookArr[indx].EstimateTyp = productType;
        // txtSectionRef.value = "New Section"; //bookArr[indx].SectionRef;
        txtSectionRef.value = "Section " + Number(bookArr.length + 1); // added By Pradeep        
        txtQuantity.value = bookArr[indx].Quantity;

        LoadBackQty(bookArr[indx].QuantityList);

        for (var i = 0; i < ddlPress.length; i++) {
            if (bookArr[indx].PressID == ddlPress[i].value) {
                ddlPress.selectedIndex = i;
                //PressOnChange(ddlPress);
            }
        }

        hdnpaperID.value = bookArr[indx].PaperID;
        try {
            PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
        }
        catch (err) { }
        lblDefaultPaper.innerHTML = bookArr[indx].PaperName;
        lblPaperWeight.innerHTML = bookArr[indx].PaperWeight;
        ChkPriceForWholePack.checked = bookArr[indx].PriceForWhaolePack;
        ChkPaperSupplied.checked = bookArr[indx].PaperSupplied;
        txtSetupSpoilage.value = bookArr[indx].SetupSpoilage;
        txtRunningSpoilage.value = bookArr[indx].RunningSpoilage;
        txtNoOfPagesRequired.value = bookArr[indx].NoOfPagesRequired;
        txtPagesPerSection.value = bookArr[indx].PagesPerSection;

        for (var i = 0; i < ddlColors.length; i++) {
            if (bookArr[indx].Color == ddlColors[i].value) {
                ddlColors.selectedIndex = i;
            }
        }

        chkDoubleSided.checked = bookArr[indx].IsDoubleSided;

        if (chkDoubleSided.checked) {
            for (var i = 0; i < ddlColors_2.length; i++) {
                if (bookArr[indx].SideColor == ddlColors_2[i].value) {
                    ddlColors_2.selectedIndex = i;
                }
            }
            Side2_block();
        }
        else {
            Side2_none();
        }

        for (var i = 0; i < ddlPrintSheetSize.length; i++) {
            if (bookArr[indx].PrintSheetSizeID == ddlPrintSheetSize[i].value) {
                ddlPrintSheetSize.selectedIndex = i;
            }
        }
        chkPrintSheet.checked = bookArr[indx].IsPrintCustom;
        PrintSheetCustom(chkPrintSheet.id); //FUNCTION
        txtsectionheight.value = bookArr[indx].PrintSheetHeight;
        txtsectionwidth.value = bookArr[indx].PrintSheetWidth;

        for (var i = 0; i < ddlJobItemSize.length; i++) {
            if (ddlJobItemSize[i].value == bookArr[indx].JobFlatSizeID) {
                ddlJobItemSize.selectedIndex = i;
            }
        }

        ChkJobFlatCustom.checked = bookArr[indx].IsJobCustom;
        JobItemCustom(ChkJobFlatCustom.id); //FUNCTION 
        txtitemheight.value = bookArr[indx].JobFlatSizeHeight;
        txtitemwidth.value = bookArr[indx].JobFlatSizeWidth;

        chkGutters.checked = bookArr[indx].IsIncludeGutters;
        GuttersCustom(chkGutters.id); //FUNCTION 
        txtGutterHorizontal.value = bookArr[indx].GutterHorizontal;
        txtGutterVertical.value = bookArr[indx].GutterVertical;

        ChkPressRestrictions.checked = bookArr[indx].IsPressRestrictions;
        NonHeight = bookArr[indx].NonImageHeight;
        NonWeight = bookArr[indx].NonImageWidth;

        hid_GuillotineID.value = bookArr[indx].GuilotineID;
        lblGuillotine.innerHTML = bookArr[indx].GuilotineName;
        ////new Development
        chkFirstTrim.checked = bookArr[indx].IsFirstTrim;
        chkSecondTrim.checked = bookArr[indx].IsSecondTrim;

        chkIsSilling.checked = bookArr[indx].isCeilPrintSheetPerSection;

        //booklet changes
        txtNoOfPagesInSection.value = bookArr[indx].NoOfPagesInSection;

        for (var i = 0; i < ddlBookletType.length; i++) {
            if (ddlBookletType[i].value == bookArr[indx].BookletType) {
                ddlBookletType.selectedIndex = i;
            }
        }


        txtPagesPerSignature.value = GetPagesPerSignature(bookArr[indx].PagesPerSignature);
        txtNoOfSignatures.value = bookArr[indx].NoOfSignatures;

        lblDefaultPlates.innerHTML = bookArr[indx].Platename;
        hdnplateID.value = bookArr[indx].PlateID;

        //by Swetha M.S on 12/4/2011 -- Ref BUGID:121
        txtNoOfPlates.value = bookArr[indx].Plate;
        txtNoOfMakeReady.value = bookArr[indx].Makeready;
        //by Swetha M.S on 12/4/2011 -- Ref BUGID:121


        //------------------------------------------------

        //Print layout
        if (bookArr[indx].PrintLayout == "P") {
            chkPortrait.checked = true;
            chkLandscape.checked = false;
            chkManual.checked = false;
        }
        else if (bookArr[indx].PrintLayout == "L") {
            chkLandscape.checked = true;
            chkPortrait.checked = false;
            chkManual.checked = false;
        } else {
            chkManual.checked = true;
            chkPortrait.checked = false;
            chkLandscape.checked = false;
        }

        txtlandscape.value = bookArr[indx].LandscapeValue;
        txtportrait.value = bookArr[indx].PortraitValue;
        txtManual.value = bookArr[indx].ManualValue;


        //------------------------------------------------



        for (var i = 0; i < ddlPlates.length; i++) {
            if (bookArr[indx].Plate == ddlPlates[i].value) {
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
            if (bookArr[indx].Makeready == ddlMakeReady[i].value) {
                ddlMakeReady.selectedIndex = i;
            }
        }

        for (var i = 0; i < ddlWashUp.length; i++) {
            if (bookArr[indx].Washup == ddlWashUp[i].value) {
                ddlWashUp.selectedIndex = i;
            }
        }

        for (var j = 0; j < ddlNoOfSide.length; j++) {
            if (ddlNoOfSide.options[j].text == bookArr[indx].Noofsidesprinted) {
                ddlNoOfSide.selectedIndex = j;
            }
        }

        if (bookArr[indx].Noofsidesprinted == 'Single') {
            for (var j = 0; j < ddlSide1Color.length; j++) {
                if (ddlSide1Color.options[j].text == bookArr[indx].Side1color) {
                    ddlSide1Color.selectedIndex = j;
                }
            }
            document.getElementById("div_side2_colour").style.display = "none";
        }
        else if (bookArr[indx].Noofsidesprinted == 'Double') {
            document.getElementById("div_side2_colour").style.display = "block";
            for (var j = 0; j < ddlSide1Color.length; j++) {
                if (ddlSide1Color.options[j].text == bookArr[indx].Side1color) {
                    ddlSide1Color.selectedIndex = j;
                }
            }

            for (var j = 0; j < ddlSide2Color.length; j++) {
                if (ddlSide2Color.options[j].text == bookArr[indx].Side2color) {
                    ddlSide2Color.selectedIndex = j;
                }
            }
            //chkSecondTrim.checked = bookArr[indx].Checkturn == "1" ? true : false;
            //chkSecondTrim.checked = bookArr[indx].Checktumble == "1" ? true : false;
        }


        for (var i = 0; i < ddlBookletFormat.length; i++) {
            if (ddlBookletFormat[i].value == bookArr[indx].BookletFormat) {
                ddlBookletFormat.selectedIndex = i;
            }
        }
        chkTurn.checked = bookArr[indx].Checkturn == "1" ? true : false;
        chkTumble.checked = bookArr[indx].Checktumble == "1" ? true : false;
        chkPerfecting.checked = bookArr[indx].CheckPerfecting == "1" ? true : false;
        if (!chkTumble.checked && !chkTurn.checked && !chkPerfecting.checked) {
            chkSheetWork.checked = true;
        }
        else {
            chkSheetWork.checked = false;
        }
    }
}

function QuantityClass() {
    this.Quantity1 = '';
    this.Quantity2 = '';
    this.Quantity3 = '';
    this.Quantity4 = '';
    this.QtyType;
    this.EstBookletQty;
    this.EstBookletSectionID;
}

function LoadBackQty(obj) {
    var ObjArray = obj;
    for (var i = 0; i < ObjArray.length; i++) {
        var Qtype = hid_QtyType.value = ObjArray[0].QtyType;
        txtQuantity.value = ObjArray[0].Quantity1;
        txtQuantity_2.value = ObjArray[0].Quantity2 == null ? "" : ObjArray[0].Quantity2;
        txtQuantity_3.value = ObjArray[0].Quantity3 == null ? "" : ObjArray[0].Quantity3;
        txtQuantity_4.value = ObjArray[0].Quantity4 == null ? "" : ObjArray[0].Quantity4;
    }


    var checkCnt = 0;
    if (txtQuantity.value != "") {
        checkCnt++;
    }
    if (txtQuantity_2.value != "") {
        checkCnt++;
    }
    if (txtQuantity_3.value != "") {
        checkCnt++;
    }
    if (txtQuantity_4.value != "") {
        checkCnt++;
    }

    if (document.getElementById(div_Qty2to4).style.display == "block") {
        moreQty('more');
    }
    else {
        if (checkCnt > 1) {
            moreQty('more');
        }
        else {
            moreQty('single');
        }
    }
}

function SaveQtyToArray() {
    var qtyItem = new QuantityClass();
    var QType = qtyItem.QtyType = hid_QtyType.value;
    if (QType == "S") {
        qtyItem.Quantity1 = txtQuantity.value;
    }
    else if (QType == "R") {
        qtyItem.Quantity1 = txtQuantity.value;
        qtyItem.Quantity2 = txtRunOnQty.value;
    }
    else if (QType == "M") {
        qtyItem.Quantity1 = txtQuantity.value == "undefined" ? "" : txtQuantity.value;
        qtyItem.Quantity2 = txtQuantity_2.value == "undefined" ? "" : txtQuantity_2.value;
        qtyItem.Quantity3 = txtQuantity_3.value == "undefined" ? "" : txtQuantity_3.value;
        qtyItem.Quantity4 = txtQuantity_4.value == "undefined" ? "" : txtQuantity_4.value;
    }
    return qtyItem;
}

function OnlyForBooklet() {
    const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
    const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;
    var GotoNextSection = false;
    var arr_0 = hid_bookletData.value.split('µ');
    for (var b = 0; b < arr_0.length; b++) {
        if (arr_0[b] != '') {
            var arr_1 = arr_0[b].split('±');
            for (var i = 0; i < arr_1.length; i++) {
                var arr_2 = arr_1[i].split('»');

                if (arr_2[0] == "Qty") {
                    var qty_1 = arr_2[1].split('#');

                    for (var j = 0; j < qty_1.length; j++) {
                        var qty_2 = qty_1[j].split('$');
                        if (qty_2[0] == "M") {
                            div_Qty_2to4.style.display = "block";
                            div_Addmore.style.display = "block";
                            if (navigator.appName == "Microsoft Internet Explorer") {
                                document.getElementById("div_qty_3to4").className = "bglabelEmpty";
                            }
                            else {
                                document.getElementById("div_qty_3to4").className = "bglabelEmpty1";
                            }
                            hid_QtyType.value = "M";

                            if (qty_2[1] == "2") {
                                txtQuantity_2.value = qty_2[2];
                            }
                        }
                        else if (qty_2[0] == "R") {
                            div_RunOnQty.style.display = "block";
                            if (navigator.appName == "Microsoft Internet Explorer") {
                                if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
                                    var ieversion = new Number(RegExp.$1)
                                    if (ieversion >= 6) {
                                        div_RunOnQty.className = "absolutepos";
                                    }
                                    if (ieversion >= 7) {
                                        div_RunOnQty.className = "absolutepos7";
                                    }
                                }
                            }
                            else {
                                if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)) {
                                    var ffversion = new Number(RegExp.$1);
                                    if (ffversion == 3) {
                                        div_RunOnQty.className = "absolutepos1ff";
                                    }
                                    if (ffversion >= 3.5) {
                                        div_RunOnQty.className = "absolutepos1";
                                    }
                                }
                            }
                            chkRunOnQty.checked = true;
                            hid_QtyType.value = "R";

                            if (qty_2[1] == "2") {
                                txtRunOnQty.value = qty_2[2];
                            }
                        }
                        else if (qty_2[0] == "S") {
                            hid_QtyType.value = "S";
                        }


                        if (qty_2[1] == "1") {
                            txtQuantity.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, qty_2[2], 0, '', false, false, false);
                        }
                        if (qty_2[1] == "3") {
                            txtQuantity_3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, qty_2[2], 0, '', false, false, false);
                        }
                        if (qty_2[1] == "4") {
                            txtQuantity_4.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, qty_2[2], 0, '', false, false, false);
                        }
                    }
                    //div_RunOnQty  
                }
                else if (arr_2[0] == "Press") {
                    for (j = 0; j < ddlPress.length; j++) {
                        if (ddlPress.options[j].value == arr_2[1]) {
                            ddlPress.selectedIndex = j;
                        }
                    }
                }
                else if (arr_2[0] == "Paper") {
                    hdnpaperID.value = arr_2[1];
                    lblDefaultPaper.innerHTML = arr_2[2];
                    lblDefaultPaper.title = arr_2[2];
                    ChkPriceForWholePack.checked = arr_2[3] == "True" ? true : false;
                    ChkPaperSupplied.checked = arr_2[4] == "True" ? true : false;
                    try {
                        PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
                    }
                    catch (errrorrr) {
                    }
                }
                else if (arr_2[0] == "PaperWeight") {
                    lblPaperWeight.innerHTML = arr_2[1];
                }
                else if (arr_2[0] == "SetupSpoilage") {
                    txtSetupSpoilage.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, '', true, false, false);
                }
                else if (arr_2[0] == "RunningSpoilage") {
                    txtRunningSpoilage.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, '', false, false, false);
                }
                else if (arr_2[0] == "QuantityList") {

                    var StrQtyData = arr_2[1].split('-');
                    clearQty();
                    for (var q = 0; q < StrQtyData.length - 1; q++) {
                        if (q == 0) {
                            txtQuantity.value = StrQtyData[q] == "" ? "" : StrQtyData[q];
                            moreQty('single');
                        }
                        else if (q == 1) {
                            txtQuantity_2.value = StrQtyData[q] == "" ? "" : StrQtyData[q];
                            moreQty('more');
                        }
                        else if (q == 2) {
                            txtQuantity_3.value = StrQtyData[q] == "" ? "" : StrQtyData[q];
                            moreQty('more');
                        }
                        else if (q == 3) {
                            txtQuantity_4.value = StrQtyData[q] == "" ? "" : StrQtyData[q];
                            moreQty('more');
                        }
                    }

                    if (txtQuantity.value == "undefined") {
                        txtQuantity.value = "";
                    }
                    if (txtQuantity_2.value == "undefined") {
                        txtQuantity_2.value = "";
                    }
                    if (txtQuantity_3.value == "undefined") {
                        txtQuantity_3.value = "";
                    }
                    if (txtQuantity_4.value == "undefined") {
                        txtQuantity_4.value = "";
                    }
                }
                else if (arr_2[0] == "SheetSize") {
                    for (j = 0; j < ddlPrintSheetSize.length; j++) {
                        if (ddlPrintSheetSize.options[j].value == arr_2[1]) {
                            ddlPrintSheetSize.selectedIndex = j;
                        }
                    }
                    LoadToSheetCustom(arr_2[1]);
                    chkPrintSheet.checked = arr_2[2] == "True" ? true : false;
                    txtsectionheight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[3], decimalPlaces, '', false, false, false);
                    txtsectionwidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[4], decimalPlaces, '', false, false, false);
                }
                else if (arr_2[0] == "ItemSize") {
                    for (j = 0; j < ddlJobItemSize.length; j++) {
                        if (ddlJobItemSize.options[j].value == arr_2[1]) {
                            ddlJobItemSize.selectedIndex = j;
                        }
                    }
                    LoadToItemCustom(arr_2[1]);
                    ChkJobFlatCustom.checked = arr_2[2] == "True" ? true : false;
                    txtitemheight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[3], decimalPlaces, '', false, false, false);
                    txtitemwidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[4], decimalPlaces, '', false, false, false);
                }
                else if (arr_2[0] == "Gutters") {
                    chkGutters.checked = arr_2[1] == "True" ? true : false;
                    txtGutterHorizontal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[2], 0, '', false, false, false);
                    txtGutterVertical.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[3], 0, '', false, false, false);
                }
                else if (arr_2[0] == "PressRestrictions") {
                    ChkPressRestrictions.checked = arr_2[1] == "True" ? true : false;
                    NonHeight = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[2], 0, '', false, false, false);
                    NonWeight = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[3], 0, '', false, false, false);
                }
                else if (arr_2[0] == "PrintLayout") {
                    chkPortrait.checked = arr_2[1] == "P" ? true : false;
                    chkLandscape.checked = arr_2[1] == "L" ? true : false;
                    chkManual.checked = arr_2[1] == "M" ? true : false;
                    BookletPrintLayout = arr_2[1];
                    txtportrait.value = arr_2[2];
                    txtlandscape.value = arr_2[3];
                    txtManual.value = arr_2[4];
                    hdn_PortraitValue.value = arr_2[2];
                    hdn_LandscapeValue.value = arr_2[3];
                    hdnManual.value = arr_2[4];
                }
                else if (arr_2[0] == "Guillotine") {
                    hid_GuillotineID.value = arr_2[1];
                    lblGuillotine.innerHTML = arr_2[2].length > 25 ? arr_2[2].substring(0, 23) + "..." : arr_2[2];
                    lblGuillotine.title = arr_2[2];
                    div_Trim.style.display = hid_GuillotineID.value != "0" ? "block" : "none";
                }
                else if (arr_2[0] == "IsFirstTrim") {
                    chkFirstTrim.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "IsSecondTrim") {
                    chkSecondTrim.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "isCeilPrintSheetPerSection") {

                    chkIsSilling.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "IsAnyWarehouse") {
                    if (arr_2[1] == "Y") {
                        IsAnyWarehouse = true;
                    }
                }
                else if (arr_2[0] == "IsAnyOutwork") {
                    if (arr_2[1] == "Y") {
                        href_ShowOutwork.style.display = "block";
                        IsAnyOutWork = true;
                    }
                }
                else if (arr_2[0] == "IsAnyOtherCost") {
                    if (arr_2[1] == "Y") {
                        IsAnyOtherCost = true;
                    }
                }
                else if (arr_2[0] == "NoOfPagesInSection") {
                    txtNoOfPagesInSection.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, '', true, false, false);
                }
                else if (arr_2[0] == "BookletType") {




                    for (var u = 0; u < ddlBookletType.length; u++) {
                        if (ddlBookletType[u].value == arr_2[1]) {
                            ddlBookletType.selectedIndex = u;
                        }
                    }


                }
                else if (arr_2[0] == "PagesPerSignature") {
                    txtPagesPerSignature.value = GetPagesPerSignature(arr_2[1]);
                }
                else if (arr_2[0] == "NoOfSignatures") {
                    // txtNoOfSignatures.value = Math.ceil(arr_2[1], 0);
                    // txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 2, 'ForBooklet', false, false, false);

                    txtNoOfSignatures.value = GetNoOfSignatures(arr_2[1]);

                    // hdn_PortraitValue.value = Math.ceil(arr_2[1], 0); //Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, '', true, false, false);
                    hdn_PortraitValue.value = arr_2[1]; //Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, '', true, false, false);
                }
                else if (arr_2[0] == "SectionReference") {
                    txtSectionRef.value = arr_2[1];
                }
                else if (arr_2[0] == "BookletFormat") {
                    ddlBookletFormat.value = arr_2[1] == "P" ? "P" : "L";
                }
                else if (arr_2[0] == "RowCount") {
                    GotoNextSection = arr_2[1] > 1 ? true : false;
                }
                else if (arr_2[0] == "EstimateLithoBookletItemID") {
                    EditID = arr_2[1];

                }
                if (arr_2[0] == "Plates") {
                    hdnplateID.value = arr_2[1];
                    lblDefaultPlates.innerHTML = arr_2[2];
                    lblDefaultPlates.title = arr_2[2];
                }
                if (arr_2[0] == "NoofPlate") {
                    for (var k = 0; k < ddlPlates.length; k++) {
                        if (ddlPlates.options[k].value == arr_2[1]) {
                            ddlPlates.selectedIndex = k;
                        }
                    }
                    txtNoOfPlates.value = arr_2[1];  //by Swetha M.S on 12/4/2011 -- Ref BUGID:121
                }
                if (arr_2[0] == "Makeready") {
                    for (var k = 0; k < ddlMakeReady.length; k++) {
                        if (ddlMakeReady.options[k].value == arr_2[1]) {
                            ddlMakeReady.selectedIndex = k;
                        }
                    }
                    txtNoOfMakeReady.value = arr_2[1];   //by Swetha M.S on 12/4/2011 -- Ref BUGID:121        
                }
                if (arr_2[0] == "NoofWashup") {
                    for (var k = 0; k < ddlWashUp.length; k++) {
                        if (ddlWashUp.options[k].value == arr_2[1]) {
                            ddlWashUp.selectedIndex = k;
                        }
                    }
                }
                if (arr_2[0] == "MakeReadyPerPlateCheck") {
                    if (arr_2[1] == 'True') {
                        hid_makeready.value = "yes";
                    }
                }
                if (arr_2[0] == "WashupChargePerColourCheck") {
                    if (arr_2[1] == 'True') {
                        hid_washup.value = "yes";
                    }
                }

                if (arr_2[0] == "InkType") {
                    hdn_InkType.value = arr_2[1];
                }

                if (arr_2[0] == "isPressPerfect") {
                    hid_isPressPerfect.value = arr_2[1];

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

                    }
                    else if (arr_2[1] == 'Double') {
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
                        if (arr_2[4] == 'True') {
                            chkTurn.checked = true;
                            chkSheetWork.checked = false;
                            chkTumble.checked = false;
                            chkPerfecting.checked = false;
                        }
                        else {
                            chkTurn.checked = false;


                        }
                        if (arr_2[5] == 'True') {
                            chkTumble.checked = true;
                            chkSheetWork.checked = false;
                            chkTurn.checked = false;
                            chkPerfecting.checked = false;
                        }
                        else {
                            chkTumble.checked = false;
                        }
                        if (arr_2[6] == 'True') {
                            chkTumble.checked = false;
                            chkSheetWork.checked = false;
                            chkTurn.checked = false;
                            chkPerfecting.checked = true;
                        }
                        else {
                            chkPerfecting.checked = false;
                        }
                    }
                }
            }

            MoveNextSection();
        }
    }
    LoadSectionValues("0");
    if (hid_isPressPerfect.value == 'True' || hid_isPressPerfect.value == 1) {
        document.getElementById("Div_PerfectChk").style.display = "block";
    }
    else {
        document.getElementById("Div_PerfectChk").style.display = "none";
    }
}

function clearQty() {
    txtQuantity.value = "";
    txtQuantity_2.value = "";
    txtQuantity_3.value = "";
    txtQuantity_4.value = "";
}

function StoreSections() {
    var bklItem = new LithoBookletItemClass();

    bklItem.EstimateLithoBookletItemID = EditID;
    EditID = 0;


    //By VINAY Booklet Separate Qty
    bklItem.QuantityList[0] = SaveQtyToArray();

    bklItem.Title = txtItemTitle.value;
    bklItem.EstimateTyp = productType;
    bklItem.SectionRef = txtSectionRef.value;
    bklItem.Quantity = txtQuantity.value;

    var ddlPress = document.getElementById("ctl00_ContentPlaceHolder1_UcBooklet_ddlPress");

    bklItem.PressID = ddlPress.value;

    if (estimateType == "digital") {
        bklItem.PressType = "D";
    }
    else if (estimateType == "largeformat") {
        bklItem.PressType = "L";
    }

    bklItem.PaperID = hdnpaperID.value;
    bklItem.PaperName = lblDefaultPaper.innerHTML;
    bklItem.PriceForWhaolePack = ChkPriceForWholePack.checked;
    bklItem.PaperSupplied = ChkPaperSupplied.checked;
    bklItem.SetupSpoilage = txtSetupSpoilage.value;
    bklItem.RunningSpoilage = txtRunningSpoilage.value;
    bklItem.NoOfPagesRequired = txtNoOfPagesRequired.value;
    bklItem.PagesPerSection = txtPagesPerSection.value;
    bklItem.Color = ddlColors.value;
    bklItem.IsDoubleSided = chkDoubleSided.checked;
    bklItem.SideColor = chkDoubleSided.checked == true ? ddlColors_2.value : "";
    bklItem.PaperWeight = lblPaperWeight.innerHTML;

    bklItem.PrintSheetSizeID = ddlPrintSheetSize.value;
    bklItem.IsPrintCustom = chkPrintSheet.checked;
    bklItem.PrintSheetHeight = txtsectionheight.value;
    bklItem.PrintSheetWidth = txtsectionwidth.value;

    bklItem.JobFlatSizeID = ddlJobItemSize.value;
    bklItem.IsJobCustom = ChkJobFlatCustom.checked;
    bklItem.JobFlatSizeHeight = txtitemheight.value;
    bklItem.JobFlatSizeWidth = txtitemwidth.value;

    bklItem.IsIncludeGutters = chkGutters.checked;
    bklItem.GutterHorizontal = txtGutterHorizontal.value;
    bklItem.GutterVertical = txtGutterVertical.value;

    bklItem.IsPressRestrictions = ChkPressRestrictions.checked;
    bklItem.NonImageHeight = NonHeight;
    bklItem.NonImageWidth = NonWeight;
    bklItem.GuilotineID = hid_GuillotineID.value;
    bklItem.GuilotineName = lblGuillotine.innerHTML;
    //new development
    bklItem.IsFirstTrim = chkFirstTrim.checked;
    bklItem.IsSecondTrim = chkSecondTrim.checked;
    bklItem.isCeilPrintSheetPerSection = chkIsSilling.checked;

    //booklet changes
    bklItem.BookletType = ddlBookletType.options[ddlBookletType.selectedIndex].value;
    bklItem.NoOfPagesInSection = txtNoOfPagesInSection.value;
    bklItem.PagesPerSignature = txtPagesPerSignature.value;
    bklItem.NoOfSignatures = txtNoOfSignatures.value;
    bklItem.BookletFormat = ddlBookletFormat.value;

    //hdn_LandscapeValue.value = bklItem.NoOfSignatures;            

    //Print layout
    //    if (ddlBookletFormat.value=='P') {
    //        bklItem.PrintLayout = 'P';
    //    }
    //    else {
    //        bklItem.PrintLayout = 'L';
    //    }

    



    if (chkPortrait.checked) {
        bklItem.PrintLayout = "P";
    }
    else if (chkManual.checked) {
        bklItem.PrintLayout = "M";
    } else {
        bklItem.PrintLayout = "L";
    }
    BookletPrintLayout = '';
    //bklItem.PrintLayout = ddlBookletFormat.value;

    bklItem.LandscapeValue = txtlandscape.value;
    bklItem.PortraitValue = txtportrait.value;
    hdn_LandscapeValue.value = bklItem.LandscapeValue;
    hdn_PortraitValue.value = bklItem.PortraitValue;

    bklItem.ManualValue = txtManual.value;
    hdnManual.value = bklItem.ManualValue;

    bklItem.Noofsidesprinted = ddlNoOfSide.options[ddlNoOfSide.selectedIndex].text;
    bklItem.Side1color = ddlSide1Color.options[ddlSide1Color.selectedIndex].text;
    bklItem.Side2color = ddlSide2Color.options[ddlSide2Color.selectedIndex].text;
    bklItem.Checkturn = chkTurn.checked;
    bklItem.Checktumble = chkTumble.checked;
    bklItem.CheckPerfecting = chkPerfecting.checked;
    bklItem.ChkSheetWork = chkSheetWork.checked;
    bklItem.Platename = lblDefaultPlates.innerHTML;
    bklItem.PlateID = hdnplateID.value;
    bklItem.Plate = txtNoOfPlates.value; //ddlPlates.value;    //by Swetha M.S on 12/4/2011 -- Ref BUGID:121
    bklItem.Makeready = txtNoOfMakeReady.value; //ddlMakeReady.value;  //by Swetha M.S on 12/4/2011 -- Ref BUGID:121
    bklItem.Washup = ddlWashUp.value;

    bklItem.MakeReadyPerPlateCheck = hid_makeready.value;
    bklItem.WashupChargePerColourCheck = hid_washup.value;

    bklItem.NCRside1inkvalue = hid_FinalInkSave1.value;
    bklItem.NCRside2inkvalue = hid_FinalInkSave2.value;
    //by vinay new deveolpment                        
    if (PresentSectionID != null) {
        bookArr.splice(PresentSectionID, 1, bklItem);
        PresentSectionID = null;
    }
    else {
        bookArr.push(bklItem);
    }
}

function ClaerSectionData() {

    //    txtQuantity.value = '';
    //    txtQuantity_2.value = '';
    //    txtQuantity_3.value = ''; 
    //    txtQuantity_4.value = '';

    ddlPress.selectedIndex = 0;
    //PressOnChange();

    ChkPriceForWholePack.checked = false;
    ChkPaperSupplied.checked = false;
    txtSetupSpoilage.value = '';
    txtRunningSpoilage.value = '';
    txtNoOfPagesRequired.value = '';
    txtPagesPerSection.value = '';
    ddlColors.selectedIndex = 0;
    chkDoubleSided.checked = false;
    Side2_none();

    chkGutters.checked = false;
    GuttersCustom(chkGutters.id);
    txtGutterHorizontal.value = '';
    txtGutterVertical.value = '';
    ChkPressRestrictions.checked = true;
    hid_GuillotineID.value = '';
    lblGuillotine.value = '';
    chkFirstTrim.checked = true;
    chkSecondTrim.checked = true;
    chkIsSilling.checked = false;
    //booklet changes
    txtNoOfPagesInSection.value = '';
    txtPagesPerSignature.value = '';
    txtNoOfSignatures.value = '';
    ddlBookletFormat.selectedIndex = 0;
    chkPortrait.checked = false;
    chkLandscape.checked = false;
    txtportrait.value = '';
    txtlandscape.value = '';
    chkManual.checked = false;
    txtManual.value = '';
}

function CreateItemValidation() {
    var IsCorrect = true;
    document.getElementById("spn_txtItemTitle").style.display = "none";

    if (trim12(txtItemTitle.value) == "") {
        document.getElementById("spn_txtItemTitle").style.display = "block";
        IsCorrect = false;
    }

    document.getElementById("spn_txtSectionRef").style.display = "none";

    if (trim12(txtSectionRef.value) == "") {
        document.getElementById("spn_txtSectionRef").style.display = "block";
        IsCorrect = false;
    }

    if (Number(ValidateSaddleStiched()) == 0) {
        //alert('Selected Print Layout Format is not suitable for Saddle Stiched Booklet Type');
        alert(Booklet_PrintLayout_Format_Validation);
        IsCorrect = false;


    }



    if (CheckReqCompare(txtQuantity.value, 'spn_txtQuantity', 'spn_txtQuantity_number')) {
        IsCorrect = false;
    }

    if (CallonChange(ddlPress.value, 'spn_ddlPress')) {
        IsCorrect = false;
    }

    //    if (ChkPaperSupplied.checked == true)// for enhancement id : 2605
    //    {
    //        document.getElementById("spn_lblDefaultPaper").style.display = "none";
    //    }
    //    else 

    if (CheckStringMandatory(lblDefaultPaper.innerHTML, 'spn_lblDefaultPaper')) {
        IsCorrect = false;
    }

    if (CheckReqCompareforLitho(txtSetupSpoilage.value, 'spn_txtSetupSpoilage', 'spn_txtSetupSpoilage_number')) {
        IsCorrect = false;
    }
    if (CheckReqCompareforLitho(txtRunningSpoilage.value, 'spn_txtRunningSpoilage', 'spn_txtRunningSpoilage_number')) {
        IsCorrect = false;
    }

    if (CheckReqCompare(txtNoOfPagesInSection.value, 'spn_txtNoOfPagesInSection', 'spn_txtNoOfPagesInSection_number')) {
        document.getElementById("spn_txtNoOfPagesInSection_divide").style.display = "none";
        IsCorrect = false;
    }
    if (CallonChange(ddlColors.value, 'spn_ddlColors')) {
        IsCorrect = false;
    }
    if (!chkPrintSheet.checked) {
        if (CallonChange(ddlPrintSheetSize.value, 'spn_ddlPrintSheetSize')) {
            IsCorrect = false;
        }
    }
    if (!ChkJobFlatCustom.checked) {
        if (CallonChange(ddlJobItemSize.value, 'spn_ddlJobItemSize')) {
            IsCorrect = false;
        }
    }

    //  if (!CheckDecimalPlus(txtGutterHorizontal.value, 'spn_txtGutterHorizontal', 'spn_txtGutterHorizontal_number', 'yes')
    //  || !CheckDecimalPlus(txtGutterVertical.value, 'spn_txtGutterHorizontal', 'spn_txtGutterHorizontal_number', 'yes')) {
    // IsCorrect = false;
    //}

    //    if (CheckReqCompare(lblDefaultPlates.innerHTML, 'spn_lblDefaultPlates', 'spn_lblDefaultPlates')) {
    //        IsCorrect = false;
    //    }

    if (lblDefaultPlates.innerHTML == "") {
        spn_lblDefaultPlates.style.display = "block";
        IsCorrect = false;
    }
    else {
        spn_lblDefaultPlates.style.display = "none";
    }

    if (ddlBookletFormat.selectedIndex == 0 && parseFloat(txtportrait.value) <= 0) {
        if (chkPortrait.checked) {
            spn_Printlayout.style.display = "block";
            IsCorrect = false;
        }
        else if (chkLandscape.checked && parseFloat(txtlandscape.value) <= 0) {
            spn_Printlayout.style.display = "block";
            IsCorrect = false;
        }
        else {
            spn_Printlayout.style.display = "none";
        }
    }
    if (ddlBookletFormat.selectedIndex == 0 && parseFloat(txtportrait.value) > 0 && chkPortrait.checked) {
        spn_Printlayout.style.display = "none";
    }
    if (ddlBookletFormat.selectedIndex == 1 && parseFloat(txtlandscape.value) <= 0) {
        if (chkLandscape.checked) {
            spn_Printlayout.style.display = "block";
            IsCorrect = false;
        }
        else if (chkPortrait.checked && parseFloat(txtportrait.value) <= 0) {
            spn_Printlayout.style.display = "block";
            IsCorrect = false;
        } else if (chkManual.checked && parseFloat(txtManual.value) <= 0) {
            spn_Printlayout.style.display = "block";
            IsCorrect = false;
        }
        else {
            spn_Printlayout.style.display = "none";
        }
    }
    if (ddlBookletFormat.selectedIndex == 1 && parseFloat(txtlandscape.value) > 0 && chkLandscape.checked) {
        spn_Printlayout.style.display = "none";
    }

    if (IsCorrect) {
        return true;
    }
    else {
        return false;
    }
}

function CheckReqCompareforLitho(txtValue, span1, span2) {
    if (span1 != '') {
        document.getElementById(span1).style.display = 'none';
    }
    if (span2 != '') {
        document.getElementById(span2).style.display = 'none';
    }
    if (txtValue == '') {
        document.getElementById(span1).style.display = 'block';
        return true;
    }
    //    else {
    //        if (!IsIntegerParameter(txtValue, span2)) {
    //            return true;
    //        }
    //    }
}

function ShowCreateItemStage() {
    document.getElementById("divStage1").style.display = "none";
    document.getElementById("divStage2").style.display = "block";
    document.getElementById("div_stage_2").style.display = "block";
    document.getElementById("lblheader").innerHTML = "Create Item";
}

function ShowOtherCostItems(itemtype) {
    if (itemtype == 's') {
        document.getElementById("div_OtherCostSubItems").style.display = "block";
    }
    else if (itemtype == 'm') {
        document.getElementById("div_OtherCostItems").style.display = "block";
    }
    else if (itemtype == 'u') {
        document.getElementById("div_OtherCostMainItems").style.display = "block";
    }
}

function CloseOtherCostItems(itemtype) {
    if (itemtype == 's') {
        document.getElementById("div_OtherCostSubItems").style.display = "none";
    }
    else if (itemtype == 'm') {
        document.getElementById("div_OtherCostItems").style.display = "none";
    }
    else if (itemtype == 'u') {
        document.getElementById("div_OtherCostMainItems").style.display = "none";
    }
}

function TakeValuesFromDB() {
    const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
    const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;

    var arr_0 = hid_singleData.value.split('µ');
    for (var b = 0; b < arr_0.length; b++) {
        if (arr_0[b] != '') {
            var arr_1 = arr_0[b].split('±');
            for (var i = 0; i < arr_1.length; i++) {
                var arr_2 = arr_1[i].split('»');
                if (arr_2[0] == "EstimateType") {
                    for (j = 0; j < ddlEsti.length; j++) {
                        if (ddlEsti.options[j].value == arr_2[1]) {
                            ddlEsti.selectedIndex = j;
                            ShowEstimate(arr_2[1]);
                            ddlEsti.disabled = true;
                        }
                    }
                }
                else if (arr_2[0] == "ProductType") {
                    for (j = 0; j < ddlProd.length; j++) {
                        if (ddlProd.options[j].value == arr_2[1]) {
                            ddlProd.selectedIndex = j;
                            ProductTypeShow(arr_2[1])
                            ddlProd.disabled = true;
                        }
                    }
                }
                else if (arr_2[0] == "Qty") {
                    var qty_1 = arr_2[1].split('#');
                    for (var j = 0; j < qty_1.length; j++) {
                        var qty_2 = qty_1[j].split('$');
                        if (qty_2[0] == "M") {
                            div_Qty_2to4.style.display = "block";
                            div_Addmore.style.display = "block";
                            if (navigator.appName == "Microsoft Internet Explorer") {
                                document.getElementById("div_qty_3to4").className = "bglabelEmpty";

                            }
                            else {

                                document.getElementById("div_qty_3to4").className = "bglabelEmpty1";

                            }
                            hid_QtyType.value = "M";

                            if (qty_2[1] == "2") {
                                txtQuantity_2.value = qty_2[2];
                            }
                        }
                        else if (qty_2[0] == "R") {
                            div_RunOnQty.style.display = "block";
                            if (navigator.appName == "Microsoft Internet Explorer") {
                                if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
                                    var ieversion = new Number(RegExp.$1)
                                    if (ieversion >= 6) {
                                        div_RunOnQty.className = "absolutepos";
                                    }
                                    if (ieversion >= 7) {
                                        div_RunOnQty.className = "absolutepos7";
                                    }
                                }
                            }
                            else {
                                if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)) {
                                    var ffversion = new Number(RegExp.$1);
                                    if (ffversion == 3) {
                                        div_RunOnQty.className = "absolutepos1ff";
                                    }
                                    if (ffversion >= 3.5) {
                                        div_RunOnQty.className = "absolutepos1";
                                    }
                                }
                            }
                            chkRunOnQty.checked = true;
                            hid_QtyType.value = "R";

                            if (qty_2[1] == "2") {
                                txtRunOnQty.value = qty_2[2];
                            }
                        }
                        else if (qty_2[0] == "S") {
                            hid_QtyType.value = "S";
                        }
                        if (qty_2[1] == "1") {
                            txtQuantity.value = qty_2[2];
                        }
                        if (qty_2[1] == "3") {
                            txtQuantity_3.value = qty_2[2];
                        }
                        if (qty_2[1] == "4") {
                            txtQuantity_4.value = qty_2[2];
                        }

                    }
                    //div_RunOnQty  
                }
                else if (arr_2[0] == "Press") {
                    for (j = 0; j < ddlPress.length; j++) {
                        if (ddlPress.options[j].value == arr_2[1]) {
                            ddlPress.selectedIndex = j;
                        }
                    }
                }
                else if (arr_2[0] == "Paper") {
                    hdnpaperID.value = arr_2[1];
                    lblDefaultPaper.innerHTML = arr_2[2];
                    lblDefaultPaper.title = arr_2[2];
                    ChkPriceForWholePack.checked = arr_2[3] == "True" ? true : false;
                    ChkPaperSupplied.checked = arr_2[4] == "True" ? true : false;
                }
                else if (arr_2[0] == "SetupSpoilage") {
                    txtSetupSpoilage.value = arr_2[1];
                }
                else if (arr_2[0] == "RunningSpoilage") {
                    txtRunningSpoilage.value = arr_2[1];
                }
                else if (arr_2[0] == "Colour") {
                    for (j = 0; j < ddlColors.length; j++) {
                        if (ddlColors.options[j].value == arr_2[1]) {
                            ddlColors.selectedIndex = j;
                        }
                    }
                    chkDoubleSided.checked = arr_2[2] == "True" ? true : false;
                }
                else if (arr_2[0] == "SheetSize") {
                    for (j = 0; j < ddlPrintSheetSize.length; j++) {
                        if (ddlPrintSheetSize.options[j].value == arr_2[1]) {
                            ddlPrintSheetSize.selectedIndex = j;
                        }
                    }
                    LoadToSheetCustom(arr_2[1]);
                    chkPrintSheet.checked = arr_2[2] == "True" ? true : false;
                    txtsectionheight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[3], decimalPlaces, '', false, false, false);
                    txtsectionwidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[4], decimalPlaces, '', false, false, false);
                    PrintSheetCustom(chkPrintSheet.id);
                }
                else if (arr_2[0] == "ItemSize") {
                    for (j = 0; j < ddlJobItemSize.length; j++) {
                        if (ddlJobItemSize.options[j].value == arr_2[1]) {
                            ddlJobItemSize.selectedIndex = j;
                        }
                    }
                    LoadToItemCustom(arr_2[1]);
                    ChkJobFlatCustom.checked = arr_2[2] == "True" ? true : false;
                    txtitemheight.value = arr_2[3];
                    txtitemwidth.value = arr_2[4];
                    JobItemCustom(ChkJobFlatCustom.id);
                }
                else if (arr_2[0] == "Gutters") {
                    chkGutters.checked = arr_2[1] == "True" ? true : false;
                    txtGutterHorizontal.value = arr_2[2];
                    txtGutterVertical.value = arr_2[3];
                    GuttersCustom(chkGutters.id);
                }
                else if (arr_2[0] == "PressRestrictions") {
                    ChkPressRestrictions.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "PrintLayout") {
                    chkPortrait.checked = arr_2[1] == "P" ? true : false;
                    chkLandscape.checked = arr_2[1] == "L" ? true : false;
                    chkManual.checked = arr_2[1] == "M" ? true : false;
                    txtportrait.value = arr_2[2];
                    txtlandscape.value = arr_2[3];
                    txtManual.value = arr_2[4];
                    hdn_PortraitValue.value = arr_2[2];
                    hdn_LandscapeValue.value = arr_2[3];
                    hdnManual.value = arr_2[4];
                }
                else if (arr_2[0] == "Guillotine") {
                    hid_GuillotineID.value = arr_2[1];
                    lblGuillotine.innerHTML = arr_2[2].length > 25 ? arr_2[2].substring(0, 23) + "..." : arr_2[2];
                }
                else if (arr_2[0] == "IsFirstTrim") {
                    chkFirstTrim.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "IsSecondTrim") {
                    chkSecondTrim.checked = arr_2[1] == "True" ? true : false;
                }
                else if (arr_2[0] == "isCeilPrintSheetPerSection") {
                    chkIsSilling.checked = arr_2[1] == "True" ? true : false;
                }

                else if (arr_2[0] == "SideColor") {
                    for (j = 0; j < ddlColors_2.length; j++) {
                        if (ddlColors_2.options[j].value == arr_2[1]) {
                            ddlColors_2.selectedIndex = j;
                            Side2_block();
                        }
                    }
                }
                else if (arr_2[0] == "IsAnyWarehouse") {
                    if (arr_2[1] == "Y") {
                        //href_ShowOutwork.style.display="block";
                        IsAnyWarehouse = true;
                    }
                }
                else if (arr_2[0] == "IsAnyOutwork") {
                    if (arr_2[1] == "Y") {
                        href_ShowOutwork.style.display = "block";
                        IsAnyOutWork = true;
                    }
                }
                else if (arr_2[0] == "IsAnyOtherCost") {
                    if (arr_2[1] == "Y") {
                        href_ShowOtherCostSubItem.style.display = "block";
                        IsAnyOtherCost = true;
                    }
                }
                else if (arr_2[0] == "NoOfPagesInSection") {
                    txtNoOfPagesInSection.value = arr_2[1];
                }

                else if (arr_2[0] == "BookletType") {




                    for (var u = 0; u < ddlBookletType.length; u++) {
                        if (ddlBookletType[u].value == arr_2[1]) {
                            ddlBookletType.selectedIndex = u;
                        }
                    }

                }

                else if (arr_2[0] == "PagesPerSignature") {
                    txtPagesPerSignature.value = GetPagesPerSignature(arr_2[1]);
                }
                else if (arr_2[0] == "NoOfSignatures") {
                    // txtNoOfSignatures.value = Math.ceil(arr_2[1], 0); //Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 0, 'ForBooklet', false, false, false);

                    txtNoOfSignatures.value = GetNoOfSignatures(arr_2[1]);
                    //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr_2[1], 2, 'ForBooklet', false, false, false);
                    hdn_PortraitValue.value = arr_2[1]; // Math.ceil(arr_2[1], 0);
                }
                else if (arr_2[0] == "SectionReference") {
                    txtSectionRef.value = arr_2[1];
                }
                else if (arr_2[0] == "PaperType") {
                    if (arr_2[1] == "web printing") {
                        ForWebPrinting("yes");
                    }
                }
                else if (arr_2[0] == "PressPaperType") {
                    if (arr_2[1] == "meters") {
                        spnPaperType.innerHTML = "meter(s)";
                    }
                    else {
                        spnPaperType.innerHTML = "sheet(s)";
                    }
                }

            }
        }
    }

}

function checkchanged() {
    if (ChkPriceForWholePack.checked) {
        ChkPaperSupplied.checked = false;
    }
    else {
        ChkPriceForWholePack.checked = false;
    }
}

function checkchanged1() {
    if (ChkPaperSupplied.checked) {
        ChkPriceForWholePack.checked = false;
    }
    else {
        ChkPaperSupplied.checked = false;
    }
}

function SendGuillotineIDandName(id, values) {
    lblGuillotine.title = values;
    lblGuillotine.innerHTML = values;
    lblGuillotine.style.cursor = "default";
    hid_GuillotineID.value = id;
    div_Trim.style.display = hid_GuillotineID.value != "0" ? "block" : "none";
}

function QtyFor_jobabdInvoice() {
    if (modulename == "invoice" || modulename == "jobs" || modulename == "orders") {
        if (QtyNo == "1") {
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
            document.getElementById("div_qty4").style.display = "none";
        }
        else if (QtyNo == "2") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
            document.getElementById("div_qty4").style.display = "none";
        }
        else if (QtyNo == "3") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty4").style.display = "none";
        }
        else if (QtyNo == "4") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
        }
    }
}

// By Gajendra

function GetNoOfSignatures(NoOfSignature) {





    if (chkIsSilling.checked) {
        return Math.ceil(NoOfSignature);
    }
    else {
        return Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, NoOfSignature, 2, 'ForBooklet', false, false, false);
    }


}

function GetPagesPerSignature(PagesPerSignature) {
    //return PagesPerSignature;




    var Finalvalue = 0.00;

    Finalvalue = Math.floor(PagesPerSignature);


    if (Finalvalue == 1) {
        return Finalvalue;
    }

    if (chkTurn.checked) {
        if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {

            if (Finalvalue == 1) {
                return Finalvalue;
            }

            if (Finalvalue % 2 != 0) {
                Finalvalue = (Finalvalue - 1);
            }
            else {
                Finalvalue = Finalvalue;
            }
        }
    }

    //    //by gaj for sks
    //    if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
    //        Finalvalue = Finalvalue * 2;
    //    }
    //    //by gaj for sks



    return Math.floor(Finalvalue);
}

// For Saddle Stiched

function ValidateSaddleStiched() {
    //    var BookletType = ddlBookletType.selectedIndex;
    //    if (BookletType == 0) {
    //        var FormatIndex = ddlBookletFormat.selectedIndex;
    //        if (FormatIndex == 0) {
    //            return CalculateSaddleStichedPortrait();
    //        }
    //        else {
    //            return CalculateSaddleStichedLandscape();
    //        }
    //    }
    return 1;
}

function CalculateSaddleStichedLandscape() {
    var NewJobSheetHight = 0;
    var NewJobSheetWidth = 0;

    if (Number(IH.value) > Number(IW.value)) {
        NewJobSheetHight = Number(IH.value) * 2;
        NewJobSheetWidth = Number(IW.value);
    }
    else {
        NewJobSheetWidth = Number(IW.value) * 2;
        NewJobSheetHight = Number(IH.value);
    }





    var Sides = 2;
    if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
        Sides = 2;
    }
    else {
        Sides = 1;
    }



    if ((chkGutters.checked) && (chkRestrictions.checked)) {


        ASH = Number(SH.value) - (Number(NonHeight) * Sides);
        ASW = Number(SW.value) - Number(NonWeight) * Sides;
        A = Number(ASH) - Number(HrzGutter.value);
        B = Number(A) / Number(Number(NewJobSheetHight) + Number(HrzGutter.value));
        C = parseInt(B);

        row = C;

        D = Number(ASW) - Number(VtGutter.value);
        E = Number(D) / Number(Number(NewJobSheetWidth) + Number(VtGutter.value));

        F = parseInt(E);
        col = F;
        Result = C * F;
        Result = (C * F) * Sides;


    }
    else if (chkGutters.checked) {

        A = Number(SH.value) - Number(VtGutter.value);
        B = Number(A) / Number(Number(NewJobSheetHight) + Number(VtGutter.value));
        C = parseInt(B);
        row = C;
        var Z;

        D = Number(SW.value) - Number(HrzGutter.value);
        E = Number(D) / Number(Number(NewJobSheetWidth) + Number(HrzGutter.value));
        F = parseInt(E);
        col = F;
        Result = C * F;
        Result = (C * F) * Sides;


    }
    else if (chkRestrictions.checked) {


        ASH = Number(SH.value) - Number(NonHeight);
        ASW = Number(SW.value) - Number(NonWeight);
        A = Number(ASH) / Number(NewJobSheetHight);
        B = Number(ASW) / Number(NewJobSheetWidth);
        row = parseInt(A);
        col = parseInt(B);
        Result = col * row;
        Result = (col * row) * Sides;

    }
    else {


        A = Number(SH.value) / Number(NewJobSheetHight);
        B = Number(SW.value) / Number(NewJobSheetWidth);

        C = parseInt(A); //Math.round(col_land)
        D = parseInt(B); //Math.round(row_land)

        row = C;
        col = D;

        Result = col * row;



        Result = (col * row) * Sides;

    }


    if (isNaN(Result)) {
        return 0;
    }
    else {

        return Result;
    }
}

function CalculateSaddleStichedPortrait() {

    var NewJobSheetHight = 0;
    var NewJobSheetWidth = 0;

    if (Number(IH.value) > Number(IW.value)) {
        NewJobSheetWidth = Number(IW.value) * 2;
        NewJobSheetHight = Number(IH.value);
    }
    else {
        NewJobSheetHight = Number(IH.value) * 2;
        NewJobSheetWidth = Number(IW.value);
    }

    var Sides = 2;
    if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
        Sides = 2;
    }
    else {
        Sides = 1;
    }

    var FormatIndex = ddlFormat.selectedIndex;
    if ((chkGutters.checked) && (chkRestrictions.checked)) {


        // ROW Calculation
        var Row_A1 = Number(SH.value) - Number(NonHeight);
        Row_A1 = Number(Row_A1) - Number(HrzGutter.value);
        var Row_A2 = Number(NewJobSheetWidth) + Number(HrzGutter.value);
        var Row_A = Number(Row_A1) / Number(Row_A2);
        Row_A = parseInt(Row_A);

        //COLUMN Calculation
        var Col_B1 = Number(SW.value) - Number(NonWeight);
        Col_B1 = Number(Col_B1) - Number(VtGutter.value);
        var Col_B2 = Number(NewJobSheetHight) + Number(VtGutter.value);
        var Col_B = Number(Col_B1) / Number(Col_B2);
        Col_B = parseInt(Col_B);

        Result = Row_A * Col_B;
        Result = (Row_A * Col_B) * Sides;

    }
    else if (chkGutters.checked) {


        // ROW Calculation
        var Row_A1 = Number(SH.value) - Number(HrzGutter.value);
        var Row_A2 = Number(NewJobSheetWidth) + Number(HrzGutter.value);
        var Row_A = Number(Row_A1) / Number(Row_A2);
        Row_A = parseInt(Row_A);

        //COLUMN Calculation
        var Col_B1 = Number(SW.value) - Number(VtGutter.value);
        var Col_B2 = Number(NewJobSheetHight) + Number(VtGutter.value);
        var Col_B = Number(Col_B1) / Number(Col_B2);
        Col_B = parseInt(Col_B);

        Result = Row_A * Col_B;
        Result = (Row_A * Col_B) * Sides;

    }
    else if (chkRestrictions.checked) {

        // ROW Calculation
        var Row_A1 = Number(SH.value) - Number(NonHeight);
        var Row_A2 = Number(NewJobSheetWidth);
        var Row_A = Number(Row_A1) / Number(Row_A2);
        Row_A = parseInt(Row_A);

        //COLUMN Calculation
        var Col_B1 = Number(SW.value) - Number(NonWeight);
        var Col_B2 = Number(NewJobSheetHight);
        var Col_B = Number(Col_B1) / Number(Col_B2);
        Col_B = parseInt(Col_B);

        Result = Row_A * Col_B;

        Result = (Row_A * Col_B) * Sides;




    }
    else {

        A = Number(SH.value) / Number(NewJobSheetWidth);
        B = Number(SW.value) / Number(NewJobSheetHight);


        C = parseInt(A); //Math.round(col_port)
        D = parseInt(B); //Math.round(row_port)


        row = C;
        col = D;

        Result = row * col;
        Result = (row * col) * Sides;

    }


    if (isNaN(Result)) {
        return 0;
    }
    else {

        return Result;
    }
}

// For Saddle Stiched
// By Gaj
function CalculateSaddleStichedLandscapeForSKS() {
    var NewJobSheetHight = 0;
    var NewJobSheetWidth = 0;

    if (Number(IH.value) > Number(IW.value)) {
        NewJobSheetHight = Number(IH.value) * 2;
        NewJobSheetWidth = Number(IW.value);
    }
    else {
        NewJobSheetWidth = Number(IW.value) * 2;
        NewJobSheetHight = Number(IH.value);
    }


    txtFlatbookletitemsizeHeight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, NewJobSheetHight, 0, '', false, false, false);
    txtFlatbookletitemsizeWidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, NewJobSheetWidth, 0, '', false, false, false);


    var Sides = 2;
    if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
        Sides = 2;
    }
    else {
        Sides = 1;
    }



    if ((chkGutters.checked) && (chkRestrictions.checked)) {

        hdnselected.value = "both";
        ASH = Number(SH.value) - (Number(NonHeight) * Sides);
        ASW = Number(SW.value) - Number(NonWeight) * Sides;
        A = Number(ASH) - Number(HrzGutter.value);
        B = Number(A) / Number(Number(NewJobSheetHight) + Number(HrzGutter.value));
        C = parseInt(B);

        row = C;

        D = Number(ASW) - Number(VtGutter.value);
        E = Number(D) / Number(Number(NewJobSheetWidth) + Number(VtGutter.value));

        F = parseInt(E);
        col = F;
        Result = C * F;
        Result = (C * F) * Sides;
        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

    }
    else if (chkGutters.checked) {
        hdnselected.value = "gutters";
        A = Number(SH.value) - Number(VtGutter.value);
        B = Number(A) / Number(Number(NewJobSheetHight) + Number(VtGutter.value));
        C = parseInt(B);
        row = C;
        var Z;

        D = Number(SW.value) - Number(HrzGutter.value);
        E = Number(D) / Number(Number(NewJobSheetWidth) + Number(HrzGutter.value));
        F = parseInt(E);
        col = F;
        Result = C * F;
        Result = (C * F) * Sides;
        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

    }
    else if (chkRestrictions.checked) {

        hdnselected.value = "restriction";
        ASH = Number(SH.value) - Number(NonHeight);
        ASW = Number(SW.value) - Number(NonWeight);
        A = Number(ASH) / Number(NewJobSheetHight);
        B = Number(ASW) / Number(NewJobSheetWidth);
        row = parseInt(A);
        col = parseInt(B);
        Result = col * row;
        Result = (col * row) * Sides;
        hdnhorizontal.value = "0";
        hdnvertical.value = "0";
    }
    else {

        hdnselected.value = "none";
        A = Number(SH.value) / Number(NewJobSheetHight);
        B = Number(SW.value) / Number(NewJobSheetWidth);

        C = parseInt(A); //Math.round(col_land)
        D = parseInt(B); //Math.round(row_land)

        row = C;
        col = D;

        Result = col * row;



        Result = (col * row) * Sides;
        hdnhorizontal.value = "0";
        hdnvertical.value = "0";
    }




    row_land.value = row;

    col_land.value = col;


    if (isNaN(Result)) {
        Result = 0;
    }
    else {

        Result = Result * 2;
    }



    if (ddlBookletFormat.value == "L") {
        if (isNaN(Result)) {
            txtPagesPerSignature.value = "0";
            result_land.value = "0";
            //  txtNoOfSignatures.value = "0";
            // txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);
            // txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 2, 'ForBooklet', false, false, false);
            txtNoOfSignatures.value = GetNoOfSignatures("0");
        }
        else {
            txtPagesPerSignature.value = Result;
            txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
            result_land.value = Result;
            var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(Result);
            if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                // txtNoOfSignatures.value = "0";
                //txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);
                // txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 0, 'ForBooklet', false, false, false);
                txtNoOfSignatures.value = GetNoOfSignatures("0");
            }
            else {
                //                    if (Number(NoOfSignature) > 0 && Number(NoOfSignature) < 1) {
                //                        txtNoOfSignatures.value = "1";
                //                        txtNoOfSignatures.value = Math.ceil(txtNoOfSignatures.value, 0);
                //                        //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfSignatures.value, 0, 'ForBooklet', false, false, false);
                //                    }
                //                    else {
                //txtNoOfSignatures.value = Math.ceil(NoOfSignature, 0);
                txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
                //txtNoOfSignatures.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, NoOfSignature, 2, 'ForBooklet', false, false, false);
                //}
            }
        }
    }
    else if (isNaN(Result)) {
        result_land.value = "0";
    }
    else {
        result_land.value = Result;
        hdn_Landscale.value = Result;
    }



}

function CalculateSaddleStichedPortraitForSKS() {
    var NewJobSheetHight = 0;
    var NewJobSheetWidth = 0;

    if (Number(IH.value) > Number(IW.value)) {
        NewJobSheetWidth = Number(IW.value) * 2;
        NewJobSheetHight = Number(IH.value);
    }
    else {
        NewJobSheetHight = Number(IH.value) * 2;
        NewJobSheetWidth = Number(IW.value);
    }

    txtFlatbookletitemsizeHeight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, NewJobSheetHight, 0, '', false, false, false);
    txtFlatbookletitemsizeWidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, NewJobSheetWidth, 0, '', false, false, false);


    var Sides = 2;
    if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
        Sides = 2;
    }
    else {
        Sides = 1;
    }

    var FormatIndex = ddlFormat.selectedIndex;
    if ((chkGutters.checked) && (chkRestrictions.checked)) {
        hdnselected.value = "both";

        // ROW Calculation
        var Row_A1 = Number(SH.value) - Number(NonHeight);
        Row_A1 = Number(Row_A1) - Number(HrzGutter.value);
        var Row_A2 = Number(NewJobSheetWidth) + Number(HrzGutter.value);
        var Row_A = Number(Row_A1) / Number(Row_A2);
        Row_A = parseInt(Row_A);

        //COLUMN Calculation
        var Col_B1 = Number(SW.value) - Number(NonWeight);
        Col_B1 = Number(Col_B1) - Number(VtGutter.value);
        var Col_B2 = Number(NewJobSheetHight) + Number(VtGutter.value);
        var Col_B = Number(Col_B1) / Number(Col_B2);
        Col_B = parseInt(Col_B);

        Result = Row_A * Col_B;
        Result = (Row_A * Col_B) * Sides;
        row = Row_A;
        col = Col_B;
    }
    else if (chkGutters.checked) {
        hdnselected.value = "gutters";

        // ROW Calculation
        var Row_A1 = Number(SH.value) - Number(HrzGutter.value);
        var Row_A2 = Number(NewJobSheetWidth) + Number(HrzGutter.value);
        var Row_A = Number(Row_A1) / Number(Row_A2);
        Row_A = parseInt(Row_A);

        //COLUMN Calculation
        var Col_B1 = Number(SW.value) - Number(VtGutter.value);
        var Col_B2 = Number(NewJobSheetHight) + Number(VtGutter.value);
        var Col_B = Number(Col_B1) / Number(Col_B2);
        Col_B = parseInt(Col_B);

        Result = Row_A * Col_B;
        Result = (Row_A * Col_B) * Sides;

        row = Row_A;
        col = Col_B;

        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

    }
    else if (chkRestrictions.checked) {
        hdnselected.value = "restriction";
        // ROW Calculation
        var Row_A1 = Number(SH.value) - Number(NonHeight);
        var Row_A2 = Number(NewJobSheetWidth);
        var Row_A = Number(Row_A1) / Number(Row_A2);
        Row_A = parseInt(Row_A);

        //COLUMN Calculation
        var Col_B1 = Number(SW.value) - Number(NonWeight);
        var Col_B2 = Number(NewJobSheetHight);
        var Col_B = Number(Col_B1) / Number(Col_B2);
        Col_B = parseInt(Col_B);

        Result = Row_A * Col_B;

        Result = (Row_A * Col_B) * Sides;

        row = Row_A;
        col = Col_B;

        hdnhorizontal.value = "0";
        hdnvertical.value = "0";
    }
    else {
        hdnselected.value = "none";
        A = Number(SH.value) / Number(NewJobSheetWidth);
        B = Number(SW.value) / Number(NewJobSheetHight);

        C = parseInt(A); //Math.round(col_port)
        D = parseInt(B); //Math.round(row_port)

        row = C;
        col = D;

        Result = row * col;
        Result = (row * col) * Sides;

        hdnhorizontal.value = "0";
        hdnvertical.value = "0";
    }

    if (isNaN(Result)) {
        Result = 0;
    }
    else {
        Result = Result * 2;
    }

    row_port.value = row;
    col_port.value = col;

    if (ddlBookletFormat.value == "P") {
        if (isNaN(Result)) {
            txtPagesPerSignature.value = "0";
            result_port.value = "0";
            txtNoOfSignatures.value = GetNoOfSignatures("0");
        }
        else {
            txtPagesPerSignature.value = Result;
            txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
            result_port.value = Result;

            var NoOfSignature = Number(txtNoOfPagesInSection.value) / Result;
            if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                txtNoOfSignatures.value = GetNoOfSignatures("0");
            }
            else {
                txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
            }
        }
    }

    else if (isNaN(Result)) {
        result_port.value = "0";
    }
    else {
        result_port.value = Result;
        hdn_Protrait.value = Result;
    }
}