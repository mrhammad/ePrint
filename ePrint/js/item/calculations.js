//function Calculations() {

//    //  CalculateInventorySheet('a', 450, 640);

//    CalculateLandscape('a');
//    CalculatePortrait('A');


//}


function G_CalculateInventorySheet(ModuleType, InvPaperHeight, InvPaperWidth) {



    var PrintSheetHeight = SH;
    var PrintSheetWidth = SW;

    var SheetHeight = Number(PrintSheetHeight.value);
    var SheetWidth = Number(PrintSheetWidth.value);



    //    alert(InvPaperHeight);
    //    alert(InvPaperWidth);

    //    alert(SheetHeight);
    //    alert(SheetWidth);


    var NoOfPrintSheets = 0;
    var NoOfPrintSheets1 = 0;
    var NoOfPrintSheets2 = 0;


    var PRow = 0;
    var PCol = 0;
    var LRow = 0;
    var LCol = 0;
    //if (String.Compare(PrintLayout, "P", true) == 0)
    //{
    if (SheetWidth > 0) {
        PRow = Math.floor(InvPaperWidth / SmallInTwo(SheetWidth, SheetHeight));
    }
    if (SheetHeight > 0) {
        PCol = Math.floor(InvPaperHeight / LargeInTwo(SheetWidth, SheetHeight));
    }
    NoOfPrintSheets1 = PRow * PCol;

    //}
    //else if (String.Compare(PrintLayout, "L", true) == 0)
    //{
    if (SheetHeight > 0) {
        LRow = Math.floor(InvPaperWidth / LargeInTwo(SheetWidth, SheetHeight));
    }
    if (SheetWidth > 0) {
        LCol = Math.floor(InvPaperHeight / SmallInTwo(SheetWidth, SheetHeight));
    }
    NoOfPrintSheets2 = LRow * LCol;


    //}
    if (NoOfPrintSheets1 >= NoOfPrintSheets2) {

        NoOfPrintSheets = NoOfPrintSheets1;

    }
    else if (NoOfPrintSheets2 >= NoOfPrintSheets1) {
        NoOfPrintSheets = NoOfPrintSheets2;

    }
    //    alert(NoOfPrintSheets);
    return NoOfPrintSheets;


}



function LargeInTwo(First, Second) {
    if (First >= Second) {
        return First;
    }
    else {
        return Second;
    }
}


function SmallInTwo(First, Second) {
    if (First >= Second) {
        return Second;
    }
    else {
        return First;
    }
}

function G_CalculateLandscape(ModuleType) {
    var Sides = 1;

    if (ModuleType.toLowerCase() == 'k') {
        if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
            Sides = 2;
        }
        else {
            Sides = 1;
        }
    }

    if (ModuleType.toLowerCase() == 'b') {
        if (chkDoubleSided.checked) {
            Sides = 2;
        }
        else {
            Sides = 1;
        }
    }
    //    var chkGutters = document.getElementById("chkGutters");
    //    var chkRestrictions = document.getElementById("chkRestrictions");

    var hdnselected = document.getElementById("hdnselected");
    var PrintSheetHeight = SH;
    var PrintSheetWidth = SW;
    var JobSheetHeight = IH;
    var JobSheetWidth = IW;

    //    var HrzGutter = HrzGutter;
    //    var VtGutter = VtGutter;

    var requestType = funreqtype();
    //in case of edit large format, press restrictions was not being applied
    try {
        if (requestType == 'edit' && ModuleType == 'l') {
            var arr1 = hid_LargeFormatPress.value.split('µ');
            for (var i = 0; i < arr1.length; i++) {
                if (arr1[i] != '') {
                    var arr2 = arr1[i].split('±');
                    var Arr3 = arr2[0].split('»');
                    if (ddlPress.options[ddlPress.selectedIndex].value == Arr3[1]) {
                        NonHeight = arr2[25].split('»')[1];
                        NonWeight = arr2[26].split('»')[1];
                    }
                }
            }
        }
    } catch (err) {
    }

    var NonPrintingAreaHeight = NonHeight;
    var NonPrintingAreaWidth = NonWeight;

    var row_land = document.getElementById("hdnrow_land");
    var col_land = document.getElementById("hdncol_land");

    var hdnvertical = document.getElementById("hdnvertical");
    var hdnhorizontal = document.getElementById("hdnhorizontal");


    var PressRestrictionWidth = 0.00;
    var PressRestrictionHeight = 0.00;

    var GutterHeight = 0.00;
    var GutterWidth = 0.00;

    if ((chkGutters.checked) && (chkRestrictions.checked)) {

        hdnselected.value = "both";

        PressRestrictionWidth = Number(NonPrintingAreaWidth);
        PressRestrictionHeight = Number(NonPrintingAreaHeight);

        GutterHeight = Number(HrzGutter.value);
        GutterWidth = Number(VtGutter.value);

        //from other pages
        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

    }
    else if (chkGutters.checked) {
        hdnselected.value = "gutters";

        GutterHeight = Number(HrzGutter.value);
        GutterWidth = Number(VtGutter.value);



        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;
    }
    else if (chkRestrictions.checked) {
        hdnselected.value = "restriction";
        PressRestrictionWidth = Number(NonPrintingAreaWidth);
        PressRestrictionHeight = Number(NonPrintingAreaHeight);


        hdnvertical.value = "0";
        hdnhorizontal.value = "0";
    }
    else {
        hdnselected.value = "none";
        hdnvertical.value = "0";
        hdnhorizontal.value = "0";
    }

    var ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2);
    var ROWDown = SmallInTwo(Number(JobSheetWidth.value), Number(JobSheetHeight.value));

    var row = 0;
    if (ROWDown > 0) {
        row = Math.floor(ROWUP / ROWDown);
    }
    var loopRowLength = row;
    var RowDownOutPut = 0;

    if (row > 1) {

        ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2); //- (row - 1) * GutterWidth;

        for (var i = 0; i < loopRowLength; i++) {
            if (i != loopRowLength - 1) {
                if ((RowDownOutPut + ROWDown + GutterWidth) <= ROWUP) {
                    RowDownOutPut = RowDownOutPut + ROWDown + GutterWidth;
                    row = i + 1;
                }
                else {
                    break;
                }
            }
            else {
                if (RowDownOutPut + ROWDown <= ROWUP) {
                    row = i + 1;
                }

            }
        }
    }



    var COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);
    var COLDown = LargeInTwo(Number(JobSheetWidth.value), Number(JobSheetHeight.value));
    var col = 0;
    if (COLDown > 0) {
        col = Math.floor(COLUP / COLDown);
    }
    var loopcolLength = col;
    var COLDownOutPut = 0;

    if (col > 1) {
        COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);  //- (col - 1) * GutterHeight;
        for (var i = 0; i < loopcolLength; i++) {
            if (i != loopcolLength - 1) {
                if ((COLDownOutPut + COLDown + GutterHeight) <= COLUP) {
                    COLDownOutPut = COLDownOutPut + COLDown + GutterHeight;
                    col = i + 1;
                }
                else {
                    break;
                }
            }
            else {
                if (COLDownOutPut + COLDown <= COLUP) {
                    col = i + 1;
                }

            }
        }
    }




    row_land.value = row;
    col_land.value = col;

    var Result = 0;
    if (row > 0 && col > 0) {
        Result = row * col;
    }
    else {
        Result = 0;
    }

    //Result = Result * Sides;

    if (isNaN(Result)) {
        result_land.value = "0";
        hdn_Landscale.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Result, 0, '', true, false, false);
    }
    else {
        if (ModuleType.toLowerCase() == 'k' || ModuleType.toLowerCase() == 'n' || ModuleType.toLowerCase() == 'f' || ModuleType.toLowerCase() == 'd') {
            Result = GetPagesPerSignature(Result);
        }
        result_land.value = Result;

        hdn_Landscale.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Result, 0, '', true, false, false);
    }
}



function G_CalculatePortrait(ModuleType) {
    var Sides = 1;
    if (ModuleType.toLowerCase() == 'k') {
        if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
            Sides = 2;
        }
        else {
            Sides = 1;
        }
    }

    if (ModuleType.toLowerCase() == 'b') {
        if (chkDoubleSided.checked) {
            Sides = 2;
        }
        else {
            Sides = 1;
        }
    }




    var hdnselected = document.getElementById("hdnselected");
    var PrintSheetHeight = SH;
    var PrintSheetWidth = SW;
    var JobSheetHeight = IH;
    var JobSheetWidth = IW;

    //    var HrzGutter = HrzGutter;
    //    var VtGutter = VtGutter;

    var requestType = funreqtype();
    //in case of edit large format, press restrictions was not being applied
    try {
        if (requestType == 'edit' && ModuleType == 'l') {
            var arr1 = hid_LargeFormatPress.value.split('µ');
            for (var i = 0; i < arr1.length; i++) {
                if (arr1[i] != '') {
                    var arr2 = arr1[i].split('±');
                    var Arr3 = arr2[0].split('»');
                    if (ddlPress.options[ddlPress.selectedIndex].value == Arr3[1]) {
                        NonHeight = arr2[25].split('»')[1];
                        NonWeight = arr2[26].split('»')[1];
                    }
                }
            }
        }
    } catch (err) {
    }

    var NonPrintingAreaHeight = NonHeight;
    var NonPrintingAreaWidth = NonWeight;

    //    var result_land = document.getElementById("result_land");
    //    var result_port = document.getElementById("result_port");


    debugger
    var row_port = document.getElementById("hdnrow_port");
    var col_port = document.getElementById("hdncol_port");

    var hdnvertical = document.getElementById("hdnvertical");
    var hdnhorizontal = document.getElementById("hdnhorizontal");

    var PressRestrictionWidth = 0.00;
    var PressRestrictionHeight = 0.00;

    var GutterHeight = 0.00;
    var GutterWidth = 0.00;

    if ((chkGutters.checked) && (chkRestrictions.checked)) {

        hdnselected.value = "both";

        PressRestrictionWidth = Number(NonPrintingAreaWidth);
        PressRestrictionHeight = Number(NonPrintingAreaHeight);

        GutterHeight = Number(HrzGutter.value);
        GutterWidth = Number(VtGutter.value);

        //from other pages
        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

    }
    else if (chkGutters.checked) {
        hdnselected.value = "gutters";

        GutterHeight = Number(HrzGutter.value);
        GutterWidth = Number(VtGutter.value);



        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;
    }
    else if (chkRestrictions.checked) {
        hdnselected.value = "restriction";
        PressRestrictionWidth = Number(NonPrintingAreaWidth);
        PressRestrictionHeight = Number(NonPrintingAreaHeight);


        hdnvertical.value = "0";
        hdnhorizontal.value = "0";
    }
    else {
        hdnselected.value = "none";
        hdnvertical.value = "0";
        hdnhorizontal.value = "0";
    }






    var ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2);
    var ROWDown = LargeInTwo(Number(JobSheetWidth.value), Number(JobSheetHeight.value));
    var row = 0;
    if (ROWDown > 0) {
        row = Math.floor(ROWUP / ROWDown);
    }
    var loopRowLength = row;
    var RowDownOutPut = 0;

    if (row > 1) {
        ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2); //- (row - 1) * GutterWidth;
        for (var i = 0; i < loopRowLength; i++) {
            if (i != loopRowLength - 1) {
                if ((RowDownOutPut + ROWDown + GutterWidth) <= ROWUP) {
                    RowDownOutPut = RowDownOutPut + ROWDown + GutterWidth;
                    row = i + 1;
                }
                else {
                    break;
                }
            }
            else {
                if (RowDownOutPut + ROWDown <= ROWUP) {
                    row = i + 1;
                }

            }
        }
        // row = Math.floor(ROWUP / ROWDown);
    }




    var COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);
    var COLDown = SmallInTwo(Number(JobSheetWidth.value), Number(JobSheetHeight.value));

    var col = 0;
    if (COLDown > 0) {
        col = Math.floor(COLUP / COLDown);
    }
    var loopcolLength = col;
    var COLDownOutPut = 0;

    if (col > 1) {
        COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);  //- (col - 1) * GutterHeight;
        for (var i = 0; i < loopcolLength; i++) {
            if (i != loopcolLength - 1) {
                if ((COLDownOutPut + COLDown + GutterHeight) <= COLUP) {
                    COLDownOutPut = COLDownOutPut + COLDown + GutterHeight;
                    col = i + 1;
                }
                else {
                    break;
                }
            }
            else {
                if (COLDownOutPut + COLDown <= COLUP) {
                    col = i + 1;
                }
            }
        }
        //col = Math.floor(COLUP / COLDown);
    }





    row_port.value = row;
    col_port.value = col;


    var Result = 0;
    if (row > 0 && col > 0) {
        Result = row * col;
    }
    else {
        Result = 0;
    }

    //  Result = Result * Sides;


    if (isNaN(Result)) {
        result_port.value = "0";
        hdn_Protrait.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 0, '', true, false, false);
    }
    else {
        if (ModuleType.toLowerCase() == 'k' || ModuleType.toLowerCase() == 'n' || ModuleType.toLowerCase() == 'f' || ModuleType.toLowerCase() == 'd') {
            Result = GetPagesPerSignature(Result);
        }
        result_port.value = Result;
        hdn_Protrait.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Result, 0, '', true, false, false);
    }



}
//function LargeFormat_CalculatePortrait(ModuleType) {
//    var Sides = 1;
//    if (ModuleType.toLowerCase() == 'k') {
//        if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
//            Sides = 2;
//        }
//        else {
//            Sides = 1;
//        }
//    }

//    if (ModuleType.toLowerCase() == 'b') {
//        if (chkDoubleSided.checked) {
//            Sides = 2;
//        }
//        else {
//            Sides = 1;
//        }
//    }




//    var hdnselected = document.getElementById("hdnselected");
//    var PrintSheetHeight = SH;
//    var PrintSheetWidth = SW;
//    var JobSheetHeight = IH;
//    var JobSheetWidth = IW;

//    //    var HrzGutter = HrzGutter;
//    //    var VtGutter = VtGutter;

//    var requestType = funreqtype();
//    //in case of edit large format, press restrictions was not being applied
//    try {
//        if (requestType == 'edit' && ModuleType == 'l') {
//            var arr1 = hid_LargeFormatPress.value.split('µ');
//            for (var i = 0; i < arr1.length; i++) {
//                if (arr1[i] != '') {
//                    var arr2 = arr1[i].split('±');
//                    var Arr3 = arr2[0].split('»');
//                    if (ddlPress.options[ddlPress.selectedIndex].value == Arr3[1]) {
//                        NonHeight = arr2[24].split('»')[1];
//                        NonWeight = arr2[25].split('»')[1];
//                    }
//                }
//            }
//        }
//    } catch (err) {
//    }

//    var NonPrintingAreaHeight = NonHeight;
//    var NonPrintingAreaWidth = NonWeight;

//    //    var result_land = document.getElementById("result_land");
//    //    var result_port = document.getElementById("result_port");



//    var row_port = document.getElementById("hdnrow_port");
//    var col_port = document.getElementById("hdncol_port");

//    var hdnvertical = document.getElementById("hdnvertical");
//    var hdnhorizontal = document.getElementById("hdnhorizontal");

//    var PressRestrictionWidth = 0.00;
//    var PressRestrictionHeight = 0.00;

//    var GutterHeight = 0.00;
//    var GutterWidth = 0.00;

//    if ((chkGutters.checked) && (chkRestrictions.checked)) {

//        hdnselected.value = "both";

//        PressRestrictionWidth = Number(NonPrintingAreaWidth);
//        PressRestrictionHeight = Number(NonPrintingAreaHeight);

//        GutterHeight = Number(HrzGutter.value);
//        GutterWidth = Number(VtGutter.value);

//        //from other pages
//        hdnvertical.value = VtGutter.value;
//        hdnhorizontal.value = HrzGutter.value;

//    }
//    else if (chkGutters.checked) {
//        hdnselected.value = "gutters";

//        GutterHeight = Number(HrzGutter.value);
//        GutterWidth = Number(VtGutter.value);



//        hdnvertical.value = VtGutter.value;
//        hdnhorizontal.value = HrzGutter.value;
//    }
//    else if (chkRestrictions.checked) {
//        hdnselected.value = "restriction";
//        PressRestrictionWidth = Number(NonPrintingAreaWidth);
//        PressRestrictionHeight = Number(NonPrintingAreaHeight);


//        hdnvertical.value = "0";
//        hdnhorizontal.value = "0";
//    }
//    else {
//        hdnselected.value = "none";
//        hdnvertical.value = "0";
//        hdnhorizontal.value = "0";
//    }






//    var ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2);
//    var ROWDown = LargeInTwo(Number(JobSheetWidth.value), Number(JobSheetHeight.value));
//    var row = 0;
//    if (ROWDown > 0) {
//        //    row = Math.floor(ROWUP / ROWDown);
//        row = (ROWUP / ROWDown).toFixed(4);
//    }
//    var loopRowLength = row;
//    var RowDownOutPut = 0;

//    if (row > 1) {
//        ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2); //- (row - 1) * GutterWidth;
//        for (var i = 0; i < loopRowLength; i++) {
//            if (i != loopRowLength - 1) {
//                RowDownOutPut = RowDownOutPut + ROWDown + GutterWidth;
//                row = i + 1;
//            }
//            else {
//                if (RowDownOutPut + ROWDown <= ROWUP) {
//                    row = i + 1;
//                }

//            }
//        }
//        // row = Math.floor(ROWUP / ROWDown);
//    }




//    var COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);
//    var COLDown = SmallInTwo(Number(JobSheetWidth.value), Number(JobSheetHeight.value));

//    var col = 0;
//    if (COLDown > 0) {
//        col = (COLUP / COLDown).toFixed(4);
//    }
//    var loopcolLength = col;
//    var COLDownOutPut = 0;

//    if (col > 1) {
//        COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);  //- (col - 1) * GutterHeight;
//        for (var i = 0; i < loopcolLength; i++) {
//            if (i != loopcolLength - 1) {
//                COLDownOutPut = COLDownOutPut + COLDown + GutterHeight;
//                col = i + 1;
//            }
//            else {
//                if (COLDownOutPut + COLDown <= COLUP) {
//                    col = i + 1;
//                }
//            }
//        }
//        //col = Math.floor(COLUP / COLDown);
//    }





//    row_port.value = Math.floor(row);
//    col_port.value = Math.floor(col);


//    var Result = 0;
//    if (row > 0 && col > 0) {
//        Result = row * col;
//    }
//    else {
//        Result = 0;
//    }

//    //  Result = Result * Sides;


//    if (isNaN(Result)) {
//        result_port.value = "0";
//        hdn_Protrait.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 0, '', true, false, false);
//    }
//    else {
//        if (ModuleType.toLowerCase() == 'k' || ModuleType.toLowerCase() == 'n' || ModuleType.toLowerCase() == 'f' || ModuleType.toLowerCase() == 'd') {
//            Result = GetPagesPerSignature(Result);
//        }
//        result_port.value = Result;
//        hdn_Protrait.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Result, 0, '', true, false, false);
//    }
//}







function G_CalculateLandscape_saddlestiched(ModuleType, FinishedBookletHeight, FinishedBookletWidth) {
    //    var chkGutters = document.getElementById("chkGutters");
    //    var chkRestrictions = document.getElementById("chkRestrictions");

    var hdnselected = document.getElementById("hdnselected");
    var PrintSheetHeight = SH;
    var PrintSheetWidth = SW;
    //    var JobSheetHeight = IH;
    //    var JobSheetWidth = IW;

    //    var HrzGutter = HrzGutter;
    //    var VtGutter = VtGutter;

    var NonPrintingAreaHeight = NonHeight;
    var NonPrintingAreaWidth = NonWeight;




    var row_land = document.getElementById("hdnrow_land");
    var col_land = document.getElementById("hdncol_land");

    var hdnvertical = document.getElementById("hdnvertical");
    var hdnhorizontal = document.getElementById("hdnhorizontal");


    var PressRestrictionWidth = 0.00;
    var PressRestrictionHeight = 0.00;

    var GutterHeight = 0.00;
    var GutterWidth = 0.00;

    if ((chkGutters.checked) && (chkRestrictions.checked)) {

        hdnselected.value = "both";

        PressRestrictionWidth = Number(NonPrintingAreaWidth);
        PressRestrictionHeight = Number(NonPrintingAreaHeight);

        GutterHeight = Number(HrzGutter.value);
        GutterWidth = Number(VtGutter.value);

        //from other pages
        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

    }
    else if (chkGutters.checked) {
        hdnselected.value = "gutters";

        GutterHeight = Number(HrzGutter.value);
        GutterWidth = Number(VtGutter.value);



        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;
    }
    else if (chkRestrictions.checked) {
        hdnselected.value = "restriction";
        PressRestrictionWidth = Number(NonPrintingAreaWidth);
        PressRestrictionHeight = Number(NonPrintingAreaHeight);


        hdnvertical.value = "0";
        hdnhorizontal.value = "0";
    }
    else {
        hdnselected.value = "none";
        hdnvertical.value = "0";
        hdnhorizontal.value = "0";
    }

    var ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2);

    var ROWDown = SmallInTwo(Number(FinishedBookletWidth), Number(FinishedBookletHeight));
    var row = 0;
    if (ROWDown > 0) {
        row = Math.floor(ROWUP / ROWDown);
    }

    var loopRowLength = row;
    var RowDownOutPut = 0;

    if (row > 1) {
        ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2); //- (row - 1) * GutterWidth;
        for (var i = 0; i < loopRowLength; i++) {
            if (i != loopRowLength - 1) {
                if ((RowDownOutPut + ROWDown + GutterWidth) <= ROWUP) {
                    RowDownOutPut = RowDownOutPut + ROWDown + GutterWidth;
                    row = i + 1;
                }
                else {
                    break;
                }
            }
            else {
                if (RowDownOutPut + ROWDown <= ROWUP) {
                    row = i + 1;
                }

            }
        }
        // row = Math.floor(ROWUP / ROWDown);
    }



    var COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);
    var COLDown = LargeInTwo(Number(FinishedBookletWidth), Number(FinishedBookletHeight));
    var col = 0;
    if (COLDown > 0) {
        col = Math.floor(COLUP / COLDown);
    }
    var loopcolLength = col;
    var COLDownOutPut = 0;
    if (col > 1) {

        COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);  //- (col - 1) * GutterHeight;
        for (var i = 0; i < loopcolLength; i++) {
            if (i != loopcolLength - 1) {
                if ((COLDownOutPut + COLDown + GutterHeight) <= COLUP) {
                    COLDownOutPut = COLDownOutPut + COLDown + GutterHeight;
                    col = i + 1;
                }
                else {
                    break;
                }
            }
            else {
                if (COLDownOutPut + COLDown <= COLUP) {
                    col = i + 1;
                }

            }
        }
        // col = Math.floor(COLUP / COLDown);
    }
    row_land.value = row;
    col_land.value = col;

    var Result = 0;
    if (row > 0 && col > 0) {
        Result = row * col;
    }
    else {
        Result = 0;
    }

    if (isNaN(Result)) {
        result_land.value = "0";
    }
    else {
        if (ModuleType.toLowerCase() == 'k' || ModuleType.toLowerCase() == 'n' || ModuleType.toLowerCase() == 'f' || ModuleType.toLowerCase() == 'd') {
            Result = GetPagesPerSignature(Result);
        }
        result_land.value = Result;
    }


}



function G_CalculatePortrait_saddlestiched(ModuleType, FinishedBookletHeight, FinishedBookletWidth) {
    //    var chkGutters = document.getElementById("chkGutters");
    //    var chkRestrictions = document.getElementById("chkRestrictions");


    var hdnselected = document.getElementById("hdnselected");
    var PrintSheetHeight = SH;
    var PrintSheetWidth = SW;
    //    var JobSheetHeight = IH;
    //    var JobSheetWidth = IW;

    //    var HrzGutter = HrzGutter;
    //    var VtGutter = VtGutter;

    var NonPrintingAreaHeight = NonHeight;
    var NonPrintingAreaWidth = NonWeight;

    //    var result_land = document.getElementById("result_land");
    //    var result_port = document.getElementById("result_port");


    debugger
    var row_port = document.getElementById("hdnrow_port");
    var col_port = document.getElementById("hdncol_port");

    var hdnvertical = document.getElementById("hdnvertical");
    var hdnhorizontal = document.getElementById("hdnhorizontal");

    var PressRestrictionWidth = 0.00;
    var PressRestrictionHeight = 0.00;

    var GutterHeight = 0.00;
    var GutterWidth = 0.00;

    if ((chkGutters.checked) && (chkRestrictions.checked)) {

        hdnselected.value = "both";

        PressRestrictionWidth = Number(NonPrintingAreaWidth);
        PressRestrictionHeight = Number(NonPrintingAreaHeight);

        GutterHeight = Number(HrzGutter.value);
        GutterWidth = Number(VtGutter.value);

        //from other pages
        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;

    }
    else if (chkGutters.checked) {
        hdnselected.value = "gutters";

        GutterHeight = Number(HrzGutter.value);
        GutterWidth = Number(VtGutter.value);



        hdnvertical.value = VtGutter.value;
        hdnhorizontal.value = HrzGutter.value;
    }
    else if (chkRestrictions.checked) {
        hdnselected.value = "restriction";
        PressRestrictionWidth = Number(NonPrintingAreaWidth);
        PressRestrictionHeight = Number(NonPrintingAreaHeight);


        hdnvertical.value = "0";
        hdnhorizontal.value = "0";
    }
    else {
        hdnselected.value = "none";
        hdnvertical.value = "0";
        hdnhorizontal.value = "0";
    }
    var ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2);
    var ROWDown = LargeInTwo(Number(FinishedBookletWidth), Number(FinishedBookletHeight));

    var row = 0;
    if (ROWDown > 0) {
        row = Math.floor(ROWUP / ROWDown);
    }
    var loopRowLength = row;
    var RowDownOutPut = 0;
    if (row > 1) {
        ROWUP = Number(PrintSheetHeight.value) - (PressRestrictionHeight * 2); //- (row - 1) * GutterWidth;
        for (var i = 0; i < loopRowLength; i++) {
            if (i != loopRowLength - 1) {
                if ((RowDownOutPut + ROWDown + GutterWidth) <= ROWUP) {
                    RowDownOutPut = RowDownOutPut + ROWDown + GutterWidth;
                    row = i + 1;
                }
                else {
                    break;
                }
            }
            else {
                if (RowDownOutPut + ROWDown <= ROWUP) {
                    row = i + 1;
                }

            }
        }
        // row = Math.floor(ROWUP / ROWDown);
    }




    var COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);
    var COLDown = SmallInTwo(Number(FinishedBookletWidth), Number(FinishedBookletHeight));

    var col = 0;
    if (COLDown > 0) {
        col = Math.floor(COLUP / COLDown);
    }
    var loopcolLength = col;
    var COLDownOutPut = 0;
    if (col > 1) {
        COLUP = Number(PrintSheetWidth.value) - (PressRestrictionWidth * 2);  //- (col - 1) * GutterHeight;
        for (var i = 0; i < loopcolLength; i++) {
            if (i != loopcolLength - 1) {
                if ((COLDownOutPut + COLDown + GutterHeight) <= COLUP) {
                    COLDownOutPut = COLDownOutPut + COLDown + GutterHeight;
                    col = i + 1;
                }
                else {
                    break;
                }
            }
            else {
                if (COLDownOutPut + COLDown <= COLUP) {
                    col = i + 1;
                }
            }
        }
        //col = Math.floor(COLUP / COLDown);
    }

    row_port.value = row;
    col_port.value = col;

    var Result = 0;
    if (row > 0 && col > 0) {
        Result = row * col;
    }
    else {
        Result = 0;
    }

    if (isNaN(Result)) {
        result_port.value = "0";
    }
    else {
        if (ModuleType.toLowerCase() == 'k' || ModuleType.toLowerCase() == 'n' || ModuleType.toLowerCase() == 'f' || ModuleType.toLowerCase() == 'd') {
            Result = GetPagesPerSignature(Result);
        }
        result_port.value = Result;
    }
}

function roundTo3or2DecimalPlaces(txtobj) {
    debugger;
    const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
    const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;
    var value = RemoveDollorAndComma(txtobj.value); 
    if (!isNaN(value) && Number(value)) {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, value, decimalPlaces, '', false, false, false);
    }
    else {
        txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, decimalPlaces, '', false, false, false);
    }
}