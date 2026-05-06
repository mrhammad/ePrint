var mmConvertionConstant = 3.779527559;
var ptConvertionConstant = 0.75;
var selectedControllID, selectedObjectID, controlheight;
var TemplateDetails, ControllDetails, ImagePath, FontList, HorizontalGroupingData, VerticalGroupingData, ColorStyleDetails, FontStyleDetails;
var ImageHeight, ImageWidth;
var cutID, cutCopy, copyID, totalSize = 0, filelist = "", filelistSingle = "", AssignedFilesAndFolders, copy = false;


function AddText() {

    clearAccordin();
    var numItems = $('.controll').length;
    var GUID = Guid();
    numItems = 1 + numItems;
    var jsonStringFotText;
    var defaulttop = 10;
    //var PostionY = (parseFloat($("#textCanvas").innerHeight()) / mmConvertionConstant) - Textheight;
    var PostionY = (parseFloat($("#textCanvas").innerHeight()) / mmConvertionConstant) - defaulttop;
    var PostionX = (parseFloat($("#textCanvas").innerWidth()) / mmConvertionConstant) / 2;

    var page = parseInt($("#drpPageSelect").val());
    jsonStringFotText = JSON.parse(JSON.stringify({
        "__type": "EditorTemplate.TemplateFieldProperties",
        "IsJustify": false,
        "OrignalImageName": "",
        "LabelFontStyle": "",
        "FontID": 78,
        "LabelFontID": 0,
        "PhraseType": "",
        "PhraseBookID": 0,
        "FontSyleID": 0,
        "ParaLineSpace": 0,
        "ActualFontName": "Arial",
        "LabelFontSize": 0,
        "FontExtension": "Arial.ttf",
        "LabelFontExtension": "Arial.ttf",
        "LabelActualFontName": "Arial",
        "UserFontSyleName": "",
        "ColorID": 0,
        "UserColorStyleName": "",
        "ManualTrackSign": "+",
        "ManualTrackDimension": "pt",
        "ImageLocation": "",
        "KeepOption": "None",
        "GroupOrientation": "None",
        "ImageSource": "",
        "ImageGallery": "",
        "R": 0,
        "OrderNumber": numItems,
        "G": 0,
        "B": 0,
        "A": 255,
        "ExceedHeight": "",
        "MaxHeight": Textheight - 1,
        "UnderlineText": false,
        "BackgroundImage": "",
        "BackgroundColor": "",
        "ExceedImage": "",
        "CustomRight": 0,
        "ObjectID": GUID,
        "FieldName": "Field" + numItems,
        "FriendlyName": "Field" + numItems,
        "HelpText": "",
        "ExceedWidth": "Do Nothing",
        "FontStyle": "Normal",
        "Font": "",
        "TextAlign": "Left",
        "Capitalize": "User Input",
        "DataType": "Text",
        "Format": "Normal",
        "ColorStyle": "",
        "Color": "#FF000000",
        "C": "0",
        "M": "0",
        "Y": "0",
        "K": "1",
        "SpotColorRef": "",
        "DefaultContent": "Field" + numItems,
        "DatabaseContent": "",
        "Dropdowns": "None",
        "Labels": "None",
        "ObjValue": "",
        "LabelStyle": "Arial",
        "LabelColor": "",
        "LabelPosition": "Attached",
        "Mandatory": false,
        "Edit": true,
        "Visibility": true,
        "HideVisibility": false,
        "Lock": true,
        "SpotColor": false,
        "PageNumber": page,
        "PositionX": PostionX,
        "PositionY": PostionY,
        "MaxWidth": 49.9983,
        "ManualTracking": 0,
        "MaxShrink": 0,
        "RotateAngle": 0,
        "FontSize": 10,
        "OriginalFontSize": 10,
        "Indent": 0,
        "Tint": 100,
        "CustomLeft": 0,
        "CustomTop": 0,
        "Copy": false,
        "PositionOffset": 20,
        "CoordsX": 20,
        "CoordsY": 194.667,
        "ObjTag": "",
        "GroupID": 0,
        "ImgUrl": "",
        "Align": "Left",
        "Top": PostionY,
        "Left": PostionX,
        "Width": 49.9983,
        "Height": Textheight,
        "FontFamily": "Arial",
        "FontWeight": "Normal",
        "OffsetWidth": "9.41122909",
        "OffsetHeight": "4.05694461",
        "OffsetTop": PostionY,
        "OffsetLeft": PostionX,
        "PixelWidth": "20",
        "PixelHeight": "3.1935200000",
        "Type": "TextBlock",
        "CanMove": true,
        "CanChangeFontColor": true,
        "CanChangeFontSize": true,
        "CanChangeFont": true,
        "ObjType": "",
        "Tag": "",
        "Label": "",
        "ActualField": "",
        "ContentType": "",
        "ZIndexValue": numItems,
        "IsCropFromTop": false,
        "IsFromBackEnd": false,
        "EditedImageName": "",
        "FontStyleName": "",
        "LabelValue": ""
    }))
    deSelect();
    ControllDetails.push(jsonStringFotText);
    AddTextDynamically(jsonStringFotText, true);
    var value = false;
    if ($(".contentProperties").css('display') == 'block') {
        $(".PropertiesPanel").trigger('click');
        $(".PropertiesPanel").hide();
        value = true;
    }
    showTextAccordion();
    if (value) {
        $(".InformationPanel").trigger('click');
    }
    $(".TextBlock").show();
    $(".ParaGraph").hide();
    $(".ImagePanel").hide();

}

/*Common Functions*****************************************************************/

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    else {
        return true;
    }
}


function changeSelectedControllID() {
    $("#textCanvas > .controll").each(function () {
        if ($(this).css('border-left-color') == 'rgb(128, 128, 128)' || $(this).css('border-left-color') == 'rgb(178, 178, 178)') {
            selectedControllID = "#" + $(this).attr('id');
            selectedObjectID = $(this).attr('id');
        }
    });
}

function showImageAccordion() {

    $(".LayoutPanel").hide();
    $(".FontPanel").hide();
    $(".ColorPanel").hide();
    $(".DefaultContentPanel").hide();
    $(".LabelPanel").hide();
    $(".PropertiesPanel").show();
    $(".InformationPanel").show();
}

function showTextAccordion() {
    $(".LayoutPanel").show();
    $(".FontPanel").show();
    $(".ColorPanel").show();
    $(".DefaultContentPanel").show();
    $(".LabelPanel").show();
    $(".PropertiesPanel").hide();
    $(".InformationPanel").show();
    $(".LayoutText").show();
    $(".LayoutPara").hide();
}

function showParaAccordion() {
    $(".LayoutPanel").show();
    $(".FontPanel").show();
    $(".ColorPanel").show();
    $(".DefaultContentPanel").show();
    $(".LabelPanel").hide();
    $(".PropertiesPanel").hide();
    $(".InformationPanel").show();
    $(".LayoutText").hide();
    $(".LayoutPara").show();
}

function deSelect() {
    $(".Para,.Image").css({ 'border': '0', 'border': 'none', 'border-style': 'none', '-webkit-border-image': 'none', 'border-image-source': 'none' });
    $(".Text").css('border', '1px dashed transparent');
    $(".Para").css('border', '1px dashed transparent');
    $(".Image").css('border', '1px solid transparent');
    $(".Text").css('cursor', 'pointer');
    $(".Para").css('cursor', 'pointer');
    $(".Image").css('cursor', 'pointer');
    $(".reiewFields").css('background-color', 'transparent');
}

function zoomvalue() {
    var tempZoom;
    var mzZoom = $('#textCanvas').css('-ms-transform');
    var webkitZoom = $('#textCanvas').css('-webkit-transform');
    var mozZoom = $('#textCanvas').css('-moz-transform');

    if (typeof (webkitZoom) != 'undefined') {
        tempZoom = webkitZoom.substr(7, webkitZoom.length - 1);
    }
    if (typeof (mozZoom) != 'undefined') {
        tempZoom = mozZoom.substr(7, mozZoom.length - 1);

    }
    if (typeof (mzZoom) != 'undefined') {
        tempZoom = mzZoom.substr(7, mzZoom.length - 1);
    }

    var index = tempZoom.indexOf(",");
    zoom = parseFloat(tempZoom.substr(0, index));

    return zoom;
}

function getRotationDegrees(obj) {
    var matrix = obj.css("-webkit-transform") ||
    obj.css("-moz-transform") ||
    obj.css("-ms-transform") ||
    obj.css("-o-transform") ||
    obj.css("transform");
    if (matrix !== 'none') {
        var values = matrix.split('(')[1].split(')')[0].split(',');
        var a = values[0];
        var b = values[1];
        var angle = Math.round(Math.atan2(b, a) * (180 / Math.PI));
    } else { var angle = 0; }
    return (angle < 0) ? angle += 360 : angle;
}

function clearAccordin() {
    $("#accordion > .content").each(function () {
        if ($(this).css('display') == 'block') {
            $(this).prev().trigger('click');
            $(this).hide();
        }
    });
}



/*END********************************************************************************/

/*Menubar***************************************************************************/

function changeThePageFromDropDown(Page) {

    $(".invalid").hide();
    $(".TextBlock").hide();
    $(".ParaGraph").hide();
    $(".ImagePanel").hide();
    $(".InformationPanel").hide();
    $(".LayoutPanel").hide();
    $(".FontPanel").hide();
    $(".ColorPanel").hide();
    $(".DefaultContentPanel").hide();
    $(".LabelPanel").hide();
    $(".PropertiesPanel").hide();
    clearAccordin();
    $(".SaveTemplatePanel").trigger('click');



    var ImageUrl = $("#textCanvas").css('background-image');

    if (TemplateDetails.Totalpage != 1) {
        var pagenumber = parseInt(Page) - 1;
        var dotIndex = ImagePath.lastIndexOf('.');
        var lastchar = ImagePath.split('.')[0][dotIndex - 2];
        var temp = 2;
        //while (ImagePath.split('.')[0][dotIndex - temp] != '-') {
        //    temp = temp + 1;
        //}
        var Image = ImagePath.substr(0, dotIndex - 1) + pagenumber + '.png';
        $("#textCanvas").css('background-image', "url('" + Image + "')");
    }


    $("#textCanvas").empty();
    $("#sortable").empty();
    curentPageNumber = parseInt($("#drpPageSelect").val());
    for (var i = 0; i < ControllDetails.length; i++) {
        if (parseInt(ControllDetails[i].PageNumber) == parseInt($("#drpPageSelect").val())) {

            var isdeleted = ControllDetails[i].Visibility;
            var controll = ControllDetails[i].Type;
            if (isdeleted == true) {
                if (controll == "TextBlock") {
                    AddTextDynamically(ControllDetails[i], false);
                }
                else if (controll == "Image") {

                    AddImageDynamically(ControllDetails[i], false);
                }
                else if (controll == "Paragraph") {
                    AddParaDynamically(ControllDetails[i], false);
                }
            }
        }
        //if (ControllDetails[i].Type == "Image") {
        //    if (parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerWidth()) > parseFloat(ControllDetails[i].MaxWidth) * mmConvertionConstant) {
        //        $("#" + ControllDetails[i].ObjectID + " img").css({ 'width': parseFloat(ControllDetails[i].MaxWidth) * mmConvertionConstant + 'px' });

        //    }
        //    if (parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerHeight()) > parseFloat(ControllDetails[i].MaxHeight) * mmConvertionConstant) {
        //        $("#" + ControllDetails[i].ObjectID + " img").css({ 'height': parseFloat(ControllDetails[i].MaxHeight) * mmConvertionConstant + 'px' });

        //    }
        //}
    }
}


function ChangeBoldItalic(BoldItalic) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if (BoldItalic == "bold") {
            if (Control.FontWeight == "Normal") {
                if ($("#" + Control.ObjectID).hasClass('Text')) {
                    $("#" + Control.ObjectID + " .labelText").css('font-weight', 'bold');
                }
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " p").css('font-weight', 'bold');
                }
                $("#btnBold").addClass('menubuttonSelected');
                Control.FontWeight = "Bold";
            }
            else {
                if ($("#" + Control.ObjectID).hasClass('Text')) {
                    $("#" + Control.ObjectID + " .labelText").css('font-weight', 'normal');
                }
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " p").css('font-weight', 'normal');
                }
                $("#btnBold").removeClass('menubuttonSelected');
                Control.FontWeight = "Normal";
            }
        }
        else if (BoldItalic == "italic") {
            if (Control.FontStyle == "Normal") {
                if ($("#" + Control.ObjectID).hasClass('Text')) {
                    $("#" + Control.ObjectID + " .labelText").css('font-style', 'italic');
                }
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " p").css('font-style', 'italic');
                }
                $("#btnItalic").addClass('menubuttonSelected');
                Control.FontStyle = "Italic";
            }
            else {
                if ($("#" + Control.ObjectID).hasClass('Text')) {
                    $("#" + Control.ObjectID + " .labelText").css('font-style', 'normal');
                }
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " p").css('font-style', 'normal');
                }
                $("#btnItalic").removeClass('menubuttonSelected');
                Control.FontStyle = "Normal";
            }

        }

        if ($("#" + Control.ObjectID).hasClass('Text')) {
            $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('line-height'));
            $("#" + Control.ObjectID).css('line-height', $("#" + Control.ObjectID + " .labelText").css('line-height'));
            Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant;
            Control.Height = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant;
        }
    }
}


function alignControllTothePage(align) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


    if (align == "left") {
        var positionx;
        if (Control.TextAlign == "Left" || Control.TextAlign == "") {
            positionx = 0;
        }
        else if (Control.TextAlign == "Right") {
            positionx = 0 + Control.MaxWidth;
        }
        else if (Control.TextAlign == "Center") {
            positionx = 0 + (Control.MaxWidth / 2);
        }
        fixPostionOfControll(Control.ObjectID, positionx, Control.PositionY, Control.TextAlign);
        getPosition();

    }
    else if (align == "right") {
        var positionx;
        if (Control.TextAlign == "Left" || Control.TextAlign == "") {
            positionx = (textCanvasWidth / mmConvertionConstant) - Control.MaxWidth;
        }
        else if (Control.TextAlign == "Right") {
            positionx = ((textCanvasWidth / mmConvertionConstant) - Control.MaxWidth) + Control.MaxWidth;
        }
        else if (Control.TextAlign == "Center") {
            positionx = ((textCanvasWidth / mmConvertionConstant) - Control.MaxWidth) + (Control.MaxWidth / 2);
        }
        fixPostionOfControll(Control.ObjectID, positionx, Control.PositionY, Control.TextAlign);
        getPosition();

    }
    else if (align == "center") {
        var positionx;
        if (Control.TextAlign == "Left" || Control.TextAlign == "") {
            positionx = ((textCanvasWidth / mmConvertionConstant) - Control.MaxWidth) / 2;
        }
        else if (Control.TextAlign == "Right") {
            positionx = (((textCanvasWidth / mmConvertionConstant) - Control.MaxWidth) / 2) + Control.MaxWidth;
        }
        else if (Control.TextAlign == "Center") {
            positionx = (((textCanvasWidth / mmConvertionConstant) - Control.MaxWidth) / 2) + (Control.MaxWidth / 2);
        }
        fixPostionOfControll(Control.ObjectID, positionx, Control.PositionY, Control.TextAlign);
        getPosition();
    }

}

function changeAlignment(align) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if (align.toLowerCase() == "left") {

            if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, "Left")) {
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " p").css('text-align', 'left');
                }
                if (Control.LabelPosition == "customTop") {
                    $("#" + Control.ObjectID + " .label").css({ 'float': 'left', 'margin-left': '0px' });
                    $("#" + Control.ObjectID + " .labelText").css({ 'float': 'left' });
                }
                Control.TextAlign = "Left";
                $("#" + Control.ObjectID).css({ 'text-align': Control.TextAlign });
                alignsingleLineText(Control.ObjectID);
                $("#rdLeftJustify").prop('checked', true);
                $("#btnLeftAlign").addClass('menubuttonSelected');
                $("#btnCenterAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
            }
        }
        else if (align.toLowerCase() == "center") {
            if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, "Center")) {
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " p").css('text-align', 'center');
                }
                Control.TextAlign = "Center";
                $("#" + Control.ObjectID).css({ 'text-align': Control.TextAlign });
                alignsingleLineText(Control.ObjectID);
                if (Control.LabelPosition == "customTop") {
                    var mar = (Control.Width * mmConvertionConstant / 2) - ((parseFloat($("#" + Control.ObjectID + " .label").innerWidth())) / 2);
                    $("#" + Control.ObjectID + " .label").css({ 'float': 'left', 'margin-left': mar + 'px' });
                    $("#" + Control.ObjectID + " .labelText").css({ 'float': 'left' });
                }
                $("#rdCenterJustify").prop('checked', true);
                $("#btnCenterAlign").addClass('menubuttonSelected');
                $("#btnLeftAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
            }
        }
        else if (align.toLowerCase() == "right") {
            if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, "Right")) {
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " p").css('text-align', 'right');
                }
                Control.TextAlign = "Right";
                $("#" + Control.ObjectID).css({ 'text-align': Control.TextAlign });
                alignsingleLineText(Control.ObjectID);
                if (Control.LabelPosition == "customTop") {
                    $("#" + Control.ObjectID + " .label").css({ 'float': 'right', 'margin-left': '0px' });
                    $("#" + Control.ObjectID + " .labelText").css({ 'float': 'right' });
                }
                $("#rdRightJustify").prop('checked', true);
                $("#btnRightAlign").addClass('menubuttonSelected');
                $("#btnLeftAlign").removeClass('menubuttonSelected');
                $("#btnCenterAlign").removeClass('menubuttonSelected');
            }
        }
    }
    return true;

}

function zoomTextCanvas(zoomCanvas) {
    var CanvasWidth = $("#LayoutCanvas").width();
    $("#textCanvas").css({
        '-ms-transform': 'scale(' + zoomCanvas + ')',
        '-moz-transform': 'scale(' + zoomCanvas + ')',
        '-webkit-transform': 'scale(' + zoomCanvas + ')',
        '-ms-transform-origin': 'left top',
        '-moz-transform-origin': 'left top',
        '-webkit-transform-origin': 'left top'
    });

    var zoomText = Math.round(zoomCanvas * 100.00);
    $("#txtZoom").attr('value', zoomText);

    var mainCanWidth = textCanvasWidth * zoomCanvas;
    var maincanheight = textCanvasHeight * zoomCanvas;
    $("#Maincanvas").css('width', mainCanWidth + 'px');
    $("#Maincanvas").css('height', maincanheight + 'px');

    $("#LayoutCanvas").css('width', CanvasWidth + "px");
    if ((parseFloat($("#textCanvas").innerWidth()) * (zoomCanvas + .05)) > (parseFloat($("#LayoutCanvas").innerWidth()))) {
        $("#helper").hide();
    }
    else {
        $("#helper").show();
    }
}

function deleteTheControll() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    $("#" + Control.ObjectID).remove();
    $("#R_" + Control.ObjectID).remove();
    Control.Visibility = false;

    $(".invalid").hide();
    $(".TextBlock").hide();
    $(".ParaGraph").hide();
    $(".ImagePanel").hide();
    $(".InformationPanel").hide();
    $(".LayoutPanel").hide();
    $(".FontPanel").hide();
    $(".ColorPanel").hide();
    $(".DefaultContentPanel").hide();
    $(".LabelPanel").hide();
    $(".PropertiesPanel").hide();
    clearAccordin();
    $(".SaveTemplatePanel").trigger('click');

}

function clearAllControlls() {
    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].PageNumber == parseInt($("#drpPageSelect").val())) {
            ControllDetails[i].Visibility = false;
        }
    }
    $("#textCanvas").empty();
    $("#sortable").empty();
}

function cutCotroll() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    $("#R_" + Control.ObjectID).remove();
    $("#" + Control.ObjectID).remove();
    Control.Visibility = false;
    cutID = Control.ObjectID;
    cutCopy = "cut";

    $(".InformationPanel").hide();
    $(".LayoutPanel").hide();
    $(".FontPanel").hide();
    $(".ColorPanel").hide();
    $(".DefaultContentPanel").hide();
    $(".LabelPanel").hide();
    $(".PropertiesPanel").hide();
    clearAccordin();
    $(".SaveTemplatePanel").trigger('click');
}

function copyControll() {

    copyID = selectedObjectID;
    cutCopy = "copy";
}

function pasteControll() {

    if (cutCopy == "cut") {
        var type = "";
        var _pagenumber = parseInt($("#drpPageSelect").val());
        deSelect();
        var posXValue, posYValue, alignment;

        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == cutID) Control = proj });

        Control.Visibility = true;
        Control.PageNumber = _pagenumber;
        type = Control.Type;
        posXValue = (Control.PositionX);
        posYValue = (Control.PositionY);
        alignment = Control.TextAlign;
        selectedObjectID = Control.ObjectID;
        selectedControllID = "#" + Control.ObjectID;

        changeThePageFromDropDown(_pagenumber + "");
        fixPostionOfControll(cutID, posXValue, posYValue, alignment);
        if (type != "Image") {
            $("#" + cutID).css('border', '1px dashed  #B2B2B2');
        }
        else if (type == "Image") {
            $("#" + cutID).css('border', '1px solid #B2B2B2');
        }
        $("#" + cutID).css('cursor', 'pointer');
        changeSelectedControllID();
        bindLeftPannel(cutID);
        cutID = "";
        cutCopy = "";

    }
    else if (cutCopy == "copy") {

        var type = "";
        deSelect();

        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == copyID) Control = proj });

        object = JSON.stringify(Control);

        var GUID = Guid();
        object = JSON.parse(object);
        object.ObjectID = GUID;
        ControllDetails.push(object);

        var _pagenumber = parseInt($("#drpPageSelect").val());
        var _totalctrls = ControllDetails.length;
        ControllDetails[_totalctrls - 1].ObjectID = GUID;

        ControllDetails.map(function (proj) { if (proj.ObjectID == GUID) Control = proj });

        Control.PageNumber = _pagenumber;
        Control.ZIndexValue = _totalctrls;
        Control.OrderNumber = _totalctrls;

        type = Control.Type;
        posXValue = (Control.PositionX);
        posYValue = (Control.PositionY);
        alignment = Control.TextAlign;

        selectedControllID = "#" + GUID;
        selectedObjectID = GUID;

        ControllDetails.map(function (proj) { if (proj.ObjectID == GUID) Control = proj });


        if (parseInt(Control.PageNumber) == _pagenumber) {

            if (Control.Type == "TextBlock") {
                AddTextDynamically(Control, true);
            }
            else if (Control.Type == "Image") {

                AddImageDynamically(Control, true);

            }
            else if (Control.Type == "Paragraph") {
                AddParaDynamically(controlist, true);
            }

            var _getctrlscount = $('.controll').length;

            ControllDetails.map(function (proj) { if (proj.ObjectID == GUID) Control = proj });

            Control.ZIndexValue = _getctrlscount;
            Control.OrderNumber = _getctrlscount;
        }
    }
}


/*END*******************************************************************************/

/*Information Panel*****************************************************************/

function changeFieldName(Text, fromTextBox) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var UserEnterdText = Text;


    if (Control.FieldName == Control.DefaultContent) {
        if (fromTextBox == true) {
            changeDefaultContent(Text, false, false, true);
        }
        else {
            changeDefaultContent(Text, false, false);
        }

    }
    else if (Control.DefaultContent == "") {
        if (fromTextBox == true) {
            Text = changeDefaultContent(Text, false, false, true);
        }
        else {
            Text = changeDefaultContent(Text, false, false);
        }
    }
    else {
        Control.FieldName = UserEnterdText;
        Control.FriendlyName = UserEnterdText;
        $("#" + Control.ObjectID).attr('name', UserEnterdText);
        $("#txtFriendly").val(Text.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">"));
    }
}

function changeFriendlyName(Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.FriendlyName = Text;
}

function changeHelpText(Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.HelpText = Text;
    $("#" + Control.ObjectID).attr('title', Text);
}


function changeDefaultContent(Text, direct, autoexpand, fromTextBox) {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var UserEnterdText = Text;


    if (direct == false) {

        if (Control.FieldName == Control.FriendlyName) {
            $("#txtFriendly").val(UserEnterdText);
            Control.FriendlyName = UserEnterdText;
        }
        Control.FieldName = UserEnterdText;
        if (fromTextBox != true) {
            $("#txtFieldName").val(UserEnterdText);
        }

        if (Control.DefaultContent != "") {
            Control.DefaultContent = UserEnterdText;
            if (Control.Type == "TextBlock") {
                $("#txtDefaultContent").val(UserEnterdText);
            }
            else if (Control.Type == "Paragraph") {
                $("#txtParaDefaultContent").val(UserEnterdText);
            }
        }
    }
    else if (autoexpand == true || Control.ExceedWidth != "Do Nothing") {
        Control.DefaultContent = UserEnterdText;
        if (Control.Type == "TextBlock") {
            if (fromTextBox != true) {
                $("#txtDefaultContent").val(UserEnterdText);
            }
        }
        else if (Control.Type == "Paragraph") {
            if (fromTextBox != true) {
                $("#txtParaDefaultContent").val(UserEnterdText);
            }
        }
    }

    var defaultContent = capitalizeTheText(Text, Control.Capitalize);
    var width = $("#" + Control.ObjectID).outerWidth();
    if ($("#" + Control.ObjectID).hasClass('Text')) {

        if (defaultContent == "") {
            $("#" + Control.ObjectID + " .label").css({ 'display': 'none' });
        }
        else {
            $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block' });
        }

        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        width = width - LabelWidth;
        var TextWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth;


        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
        //$("#" + Control.ObjectID + " .labelText").html(defaultContent);

        if (autoexpand) {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
                Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
                Control.Width = Control.MaxWidth;
            }
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
        else if (Control.ExceedWidth == "Do Nothing") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
                    defaultContent = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">");
                    defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                    UserEnterdText = defaultContent.substr(0, UserEnterdText.length - 1);
                    defaultContent = capitalizeTheText(defaultContent, Control.Capitalize);
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    defaultContent = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">");
                }
            }
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);

            if (direct == false) {
                if (Control.FieldName == Control.FriendlyName) {
                    $("#txtFriendly").val(UserEnterdText);
                    Control.FriendlyName = UserEnterdText;
                }
                Control.FieldName = UserEnterdText;
                if (fromTextBox != true) {
                    $("#txtFieldName").val(UserEnterdText);
                }
                if (Control.DefaultContent != "") {
                    Control.DefaultContent = UserEnterdText;
                    if (Control.Type == "TextBlock") {
                        $("#txtDefaultContent").val(UserEnterdText);
                    }
                    else if (Control.Type == "Paragraph") {
                        $("#txtParaDefaultContent").val(UserEnterdText);
                    }
                }
            }
            else {

                Control.DefaultContent = UserEnterdText;
                if (Control.Type == "TextBlock") {
                    if (fromTextBox != true) {
                        $("#txtDefaultContent").val(UserEnterdText);
                    }
                }
                else if (Control.Type == "Paragraph") {
                    if (fromTextBox != true) {
                        $("#txtParaDefaultContent").val(UserEnterdText);
                    }
                }
            }

        }
        else if (Control.ExceedWidth == "Expand side") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
                Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
                Control.Width = Control.MaxWidth;
            }
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
        else if (Control.ExceedWidth == "Shrink") {

            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                var fontsize = Fontsize - 0.05;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) >= width) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                    Control.FontSize = font * ptConvertionConstant;
                    $("#txtFontSize").val(font * ptConvertionConstant);
                    if (LabelWidth == null) {
                        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                    }
                    fontsize = fontsize - 0.05;
                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                    Control.Height = Control.MaxHeight;
                }
            }
            else if (Control.FontSize < Control.OriginalFontSize) {
                var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                var fontsize = Fontsize + 0.05;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) < width && Control.FontSize < Control.OriginalFontSize) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                    Control.FontSize = font * ptConvertionConstant;
                    $("#txtFontSize").val(font * ptConvertionConstant);


                    if (LabelWidth == null) {
                        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                    }
                    fontsize = fontsize + 0.05;
                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                    Control.Height = Control.MaxHeight;
                }

                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > width) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                    Control.FontSize = font * ptConvertionConstant;
                    $("#txtFontSize").val(font * ptConvertionConstant);
                    if (LabelWidth == null) {
                        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                    }
                    fontsize = fontsize - 0.05;
                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                    Control.Height = Control.MaxHeight;
                }
            }

            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
        else if (Control.ExceedWidth == "Tracking") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                if (Control.MaxShrink > 0) {
                    var spacing;
                    var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                    var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                    var letterSpacing = LetterSpacing - Control.MaxShrink;
                    while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                        $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                        spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                        letterSpacing = letterSpacing - Control.MaxShrink
                    }
                    $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                    Control.ManualTrackSign = spacing[0];
                    Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                    Control.ManualTrackDimension = "pt";
                    if (Control.ManualTrackSign == "+") {
                        $("#drpManualTrackSign1").prop('selected', true);
                    }
                    else if (Control.ManualTrackSign == "-") {
                        $("#drpManualTrackSign2").prop('selected', true);
                    }
                    $("#txtManulTracking").val(Control.ManualTracking);
                    $("#drpManualTrackDimension" + Control.ManualTrackDimension).prop('selected', true);
                }
                else {
                    while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
                        defaultContent = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">");
                        defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                        UserEnterdText = defaultContent.substr(0, UserEnterdText.length - 1);
                        defaultContent = capitalizeTheText(defaultContent, Control.Capitalize);
                        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                        defaultContent = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">");
                    }
                    
                    if (direct == false) {
                        if (Control.FieldName == Control.FriendlyName) {
                            $("#txtFriendly").val(UserEnterdText);
                            Control.FriendlyName = UserEnterdText;
                        }
                        Control.FieldName = UserEnterdText;
                        $("#txtFieldName").val(UserEnterdText);
                        if (Control.DefaultContent != "") {
                            Control.DefaultContent = UserEnterdText;
                            if (Control.Type == "TextBlock") {
                                $("#txtDefaultContent").val(UserEnterdText);
                            }
                            else if (Control.Type == "Paragraph") {
                                $("#txtParaDefaultContent").val(UserEnterdText);
                            }
                        }
                    }
                    else {
                        Control.DefaultContent = UserEnterdText;
                        if (Control.Type == "TextBlock") {
                            $("#txtDefaultContent").val(UserEnterdText);
                        }
                        else if (Control.Type == "Paragraph") {
                            $("#txtParaDefaultContent").val(UserEnterdText);
                        }
                    }
                }
            }
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
        else {
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
    }
    if ($("#" + Control.ObjectID).hasClass('Para')) {
        defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>");
        var Text = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">").replace(/<br>/g, "\n");
        $("#" + Control.ObjectID + " .paraText").html(defaultContent);

        if (autoexpand) {
            if ($("#" + Control.ObjectID + " .paraText").outerHeight() > $("#" + Control.ObjectID).outerHeight()) {
                $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .paraText").outerHeight());
                Control.Height = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
            }
        }
        else if (Control.ExceedHeight == "Do Nothing") {
            if ($("#" + Control.ObjectID + " .paraText").outerHeight() > $("#" + Control.ObjectID).outerHeight()) {
                while ($("#" + Control.ObjectID + " .paraText").outerHeight() > $("#" + Control.ObjectID).outerHeight()) {
                    Text = Text.substr(0, Text.length - 1);
                    $("#" + Control.ObjectID + " .paraText").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>"));
                }
            }
            Control.DefaultContent = Text;
            $("#txtParaDefaultContent").val(Text);
        }
        else if (Control.ExceedHeight == "Expand Height") {
            if ($("#" + Control.ObjectID + " .paraText").outerHeight() > $("#" + Control.ObjectID).outerHeight()) {
                $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .paraText").outerHeight());
                Control.Height = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
            }
        }
    }
}

function changeMandatory(status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.Mandatory = status;
}

function changeNonEditable(Status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.Edit = !Status;
}

function changeHideFromuser(Status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.HideVisibility = Status;
}

/*END*******************************************************************************/

/*LayOut and Properties Panel********************************************************/

function resizeTextPara() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var width = parseFloat($("#" + Control.ObjectID).outerWidth()) / mmConvertionConstant;
    var height = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;

    Control.Height = parseFloat(height).toFixed(4);
    Control.Width = parseFloat(width).toFixed(4);
    Control.MaxHeight = parseFloat(height).toFixed(4);
    Control.MaxWidth = parseFloat(width).toFixed(4);
    $("#txtMaxHeight").val(parseFloat(Control.Height).toFixed(4));
    $("#txtMaxWidth").val(parseFloat(Control.Width).toFixed(4));
    getPosition();

}

function resizeImage(Function) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var width = parseFloat($("#" + Control.ObjectID).outerWidth()) / mmConvertionConstant;
    var height = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;

    Control.Height = parseFloat(height).toFixed(4);
    Control.Width = parseFloat(width).toFixed(4);

    $("#" + Control.ObjectID).css({ 'line-height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });

    if (Control.ExceedImage == "P") {
        $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
        if ($("#" + Control.ObjectID).outerHeight() <= ($("#" + Control.ObjectID + " img").outerHeight())) {
            $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
            $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });
        }
        if ($("#" + Control.ObjectID).outerWidth() <= ($("#" + Control.ObjectID + " img").outerWidth())) {
            $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
            $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant) - 2) + 'px' });
        }
    }
    if (Control.ExceedImage == "S") {
        $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });
        $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant) - 2) + 'px' });
    }
    if (Control.ExceedImage == "D") {
        $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });
        $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant) - 2) + 'px' });
    }
    Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").outerHeight()) / mmConvertionConstant;
    Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").outerWidth()) / mmConvertionConstant;
    $("#txtMaxImageHeight").val((Control.Height));
    $("#txtMaxImageWidth").val((Control.Width));
    getPosition();
    alignsingleImage(Control.ObjectID);
}

function getPositionData(el) {
    return $.extend({
        width: el.outerWidth(false),
        height: el.outerHeight(false)
    }, el.offset());
}

function transformedDimensions(el, angle) {
    var dimensions = getPositionData(el);
    return {
        width: dimensions.width + Math.ceil(dimensions.width * Math.cos(angle)),
        height: dimensions.height + Math.ceil(dimensions.height * Math.cos(angle))
    };
}

function getPosition() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var zoom = zoomvalue();
    var elementHeight = parseFloat($("#" + Control.ObjectID).outerHeight());
    var elementWidth = parseFloat($("#" + Control.ObjectID).outerWidth());

    var Position = $("#" + Control.ObjectID).position();

    var top = (textCanvasHeight * zoom) - (parseFloat(Position.top) + (elementHeight * zoom));
    var topFinal = (top / zoom) / mmConvertionConstant;
    var leftFinal = parseFloat(Position.left / zoom) / mmConvertionConstant;

    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if (Control.TextAlign == "Left") {
            leftFinal = leftFinal;
            if (Control.Labels == "Use Labels" && Control.LabelPosition == "customLeft") {
                leftFinal = parseFloat(leftFinal + Control.CustomLeft);
            }
        }
        else if (Control.TextAlign == "Center") {
            leftFinal = parseFloat(leftFinal + ((elementWidth / mmConvertionConstant) / 2));
        }
        else if (Control.TextAlign == "Right") {
            leftFinal = parseFloat(leftFinal + (elementWidth / mmConvertionConstant));
        }

        $("#txtPostionX").val(parseFloat(leftFinal).toFixed(4));
        $("#txtPostionY").val(parseFloat(topFinal).toFixed(4));
        Control.PositionX = parseFloat(leftFinal).toFixed(4);
        Control.PositionY = parseFloat(topFinal).toFixed(4);
        Control.CoordsX = parseFloat(leftFinal).toFixed(4);
        Control.CoordsY = parseFloat(topFinal).toFixed(4);
        Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
        Control.OffsetTop = parseFloat(topFinal).toFixed(4);
        Control.Left = parseFloat(leftFinal).toFixed(4);
        Control.Top = parseFloat(topFinal).toFixed(4);

    }
    else if ($("#" + Control.ObjectID).hasClass('Image')) {
        $("#txtImagePostionX").val(parseFloat(leftFinal).toFixed(4));
        $("#txtImagePostionY").val(parseFloat(topFinal).toFixed(4));
        Control.PositionX = parseFloat(leftFinal).toFixed(4);
        Control.PositionY = parseFloat(topFinal).toFixed(4);
        Control.CoordsX = parseFloat(leftFinal).toFixed(4);
        Control.CoordsY = parseFloat(topFinal).toFixed(4);
        Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
        Control.OffsetTop = parseFloat(topFinal).toFixed(4);
        Control.Left = parseFloat(leftFinal).toFixed(4);
        Control.Top = parseFloat(topFinal).toFixed(4);
    }
}

function rotateSelectedControll(rotation) {
    var rotationx = 0 - rotation;
    $(selectedControllID).css({
        'transform-origin': 'left bottom',
        '-webkit-transform-origin': 'left bottom',
        '-moz-transform-origin': 'left bottom',
        '-mz-transform-origin': 'left bottom',
        '-webkit-transform': 'rotate(' + rotationx + 'deg)',
        '-moz-transform': 'rotate(' + rotationx + 'deg)',
        '-ms-transform': 'rotate(' + rotationx + 'deg)',
        'transform': 'rotate(' + rotationx + 'deg)'
    });
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.RotateAngle = rotation;


    $(".txtRotateX,#txtRotate").val(Control.RotateAngle);
}

function changePositioX(posXValue) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    fixPostionOfControll(Control.ObjectID, parseFloat(posXValue), Control.PositionY, Control.TextAlign);
}

function changePositioY(posYValue) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    fixPostionOfControll(Control.ObjectID, Control.PositionX, parseFloat(posYValue), Control.TextAlign);
}

function fixPostionOfControll(ID, posXValue, posYValue, Alignment) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == ID) Control = proj });

    var zoom = zoomvalue();

    var elementHeight = parseFloat($("#" + Control.ObjectID).outerHeight());
    var elementWidth = parseFloat($("#" + Control.ObjectID).outerWidth());

    //elementWidth = Control.MaxWidth * mmConvertionConstant;

    var textcanvas = textCanvasHeight;
    var left = posXValue * mmConvertionConstant;
    var bottom = posYValue * mmConvertionConstant;

    if (Alignment.toLowerCase() == "right") {

        var right = textCanvasWidth - left;
        left = left - elementWidth;

        if (left < 0) {
            $("#Message").dialog("open");
            $("#msg").html("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            msgBoxDesign();
            //getPosition();
            return false;
        }
        else {
            Control.PositionX = posXValue;
            Control.PositionY = posYValue;
            Control.CoordsX = posXValue;
            Control.CoordsY = posYValue;
            Control.OffsetLeft = posXValue;
            Control.OffsetTop = posYValue;
            Control.Left = posXValue;
            Control.Top = posYValue;

            //$("#" + Control.ObjectID).css({ 'left': left, 'top': top });
            //$("#" + Control.ObjectID).css({ 'left': 'auto', 'right': right + "px", 'top': 'auto', 'bottom': bottom + "px" });
            if (Control.RotateAngle > 0) {
                $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" });
            }
            else {
                $("#" + Control.ObjectID).css({ 'left': 'auto', 'right': right + "px", 'top': 'auto', 'bottom': bottom + "px" });
            }
            return true;
        }

    }
    else if (Alignment.toLowerCase() == "center") {
        var right = (textCanvasWidth - left) - (elementWidth / 2);
        left = left - (elementWidth / 2);

        if (left < 0) {
            $("#Message").dialog("open");
            $("#msg").html("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            msgBoxDesign();
            //getPosition();
            return false;
        }
        else {
            Control.PositionX = posXValue;
            Control.PositionY = posYValue;
            Control.CoordsX = posXValue;
            Control.CoordsY = posYValue;
            Control.OffsetLeft = posXValue;
            Control.OffsetTop = posYValue;
            Control.Left = posXValue;
            Control.Top = posYValue;



            //$("#" + Control.ObjectID).css({ 'left': left, 'top': top });
            if (Control.RotateAngle > 0) {
                $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" });
            }
            else {
                $("#" + Control.ObjectID).css({ 'left': 'auto', 'right': right + "px", 'top': 'auto', 'bottom': bottom + "px" });
            }
            return true;
        }

    }
    else {

        if (Control.Labels == "Use Labels" && Control.LabelPosition == "customLeft") {
            left = left - Control.CustomLeft * mmConvertionConstant;
        }

        Control.PositionX = posXValue;
        Control.PositionY = posYValue;
        Control.CoordsX = posXValue;
        Control.CoordsY = posYValue;
        Control.OffsetLeft = posXValue;
        Control.OffsetTop = posYValue;
        Control.Left = posXValue;
        Control.Top = posYValue;

        if (Control.Type == "Image") {
            left = left - 1;
            bottom = bottom - 1;
        }

        //$("#" + Control.ObjectID).css({ 'left': left, 'top': top });
        $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" });
        return true;
    }
}

function changeMaxWidth(textWidth) {
    var Control;

    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (Control.Type == "Image") {

        Control.Width = textWidth;
        Control.MaxWidth = textWidth;

        $("#" + Control.ObjectID).css('width', (parseFloat(Control.Width) * mmConvertionConstant) + "px");

        $("#" + Control.ObjectID).css({ 'line-height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });

        if (Control.ExceedImage == "P") {
            $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
            $("#" + Control.ObjectID + " img").css({ 'height': (parseFloat(Control.Height) * mmConvertionConstant) + 'px' });
            if ($("#" + Control.ObjectID).outerWidth() <= ($("#" + Control.ObjectID + " img").outerWidth())) {
                $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
                $("#" + Control.ObjectID + " img").css({ 'width': (parseFloat(Control.Width) * mmConvertionConstant) + 'px' });
            }
        }
        if (Control.ExceedImage == "S") {
            $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });
            $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant) - 2) + 'px' });
        }
        if (Control.ExceedImage == "D") {
            $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });
            $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant) - 2) + 'px' });
        }
        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").outerHeight()) / mmConvertionConstant;
        Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").outerWidth()) / mmConvertionConstant;
        getPosition();
        alignsingleImage(Control.ObjectID);

    }


    if (Control.Type == "Paragraph" || Control.Type == "TextBlock") {

        $("#" + Control.ObjectID).css('width', textWidth * mmConvertionConstant + "px");
        Control.Width = textWidth;
        Control.MaxWidth = textWidth;
        $("#" + Control.ObjectID).css({ 'width': (textWidth * mmConvertionConstant) + "px" });
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        alignsingleLineText(Control.ObjectID);
    }

}

function changeMaxHeight(textHeight) {
    var Control;

    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });



    if (Control.Type == "Image") {

        Control.MaxHeight = textHeight;
        Control.Height = textHeight;

        $("#" + Control.ObjectID).css('height', (parseFloat(Control.Height) * mmConvertionConstant) + "px");

        $("#" + Control.ObjectID).css({ 'line-height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });

        if (Control.ExceedImage == "P") {
            $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
            $("#" + Control.ObjectID + " img").css({ 'width': (parseFloat(Control.Width) * mmConvertionConstant) + 'px' });
            if ($("#" + Control.ObjectID).outerHeight() <= ($("#" + Control.ObjectID + " img").outerHeight())) {
                $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
                $("#" + Control.ObjectID + " img").css({ 'height': parseFloat(Control.Height) * mmConvertionConstant + 'px' });
            }
        }
        if (Control.ExceedImage == "S") {
            $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });
            $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant) - 2) + 'px' });
        }
        if (Control.ExceedImage == "D") {
            $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant) - 2) + 'px' });
            $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant) - 2) + 'px' });
        }
        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").outerHeight()) / mmConvertionConstant;
        Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").outerWidth()) / mmConvertionConstant;
        getPosition();
        alignsingleImage(Control.ObjectID);

    }

    if (Control.Type == "Paragraph") {
        Control.MaxHeight = textHeight;
        Control.Height = textHeight;
        $("#" + Control.ObjectID).css({ 'height': (textHeight * mmConvertionConstant) + "px", 'line-height': (textHeight * mmConvertionConstant) - 2 + "px" });
        var posXValue = null, posYValue = null;
        posXValue = parseFloat($("#txtPostionX").val());
        posYValue = parseFloat($("#txtPostionY").val());

        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }

}

function changeLockPosition(Status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.Lock = Status;
}

function changeOnexceedTexBlock(onexceed) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.ExceedWidth = onexceed;
}

function changeMaxShrinkTexBlock(Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.MaxShrink = parseInt(Text) / 100;
}

function showHardDriveForImage(status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    if (status) {
        Control.ImageSource = "h";
    }
    else {
        Control.ImageSource = "";
    }
}

function showGalleryForImage(status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (status) {
        Control.ImageGallery = "g";
    }
    else {
        Control.ImageGallery = "";
    }
}

function changeImageLocation(loaction) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.ImageLocation = loaction;
    alignsingleImage(Control.ObjectID);
}

function changeExeedWidth(exceedImage) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.ExceedImage = exceedImage;
    if (exceedImage == "S") {
        $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
        //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + Control.ImgUrl);
        $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
        Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.Align);
    }
    else if (exceedImage == "D") {
        var arry = Control.ImgUrl.split('.');
        var imageanme = arry[0].split('-');
        //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + imageanme[0] + "." + arry[1]);
        checkforImage(imageanme[0] + "." + arry[1]);
    }
    else if (exceedImage == "P") {
        if (Control.Height > Control.width) { }
        $("#" + Control.ObjectID + " img").css({ 'width': Control.MaxWidth * mmConvertionConstant + 'px', 'height': Control.MaxHeight * mmConvertionConstant + 'px' });
        $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + Control.ImgUrl);
        $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.Align);
        CreateProportionalImage();
    }
}

function CreateProportionalImage() {

    var zoom = parseInt(parseFloat(zoomvalue()) * 100);
    var width;
    var height;
    var fileName = "";
    var objectid = selectedObjectID;

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    width = parseInt(Control.Width * mmConvertionConstant);
    height = parseInt(Control.Height * mmConvertionConstant);
    fileName = Control.OrignalImageName;

    var FitImageToContoll = {};
    FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
    FitImageToContoll.type = "POST";
    FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: objectid, isEdited: "false", ImageUploadPath: ImageUploadPath, CompanyID: CompanyID });
    FitImageToContoll.dataType = "json";
    FitImageToContoll.processData = false;
    FitImageToContoll.contentType = "application/json; charset=utf-8";
    FitImageToContoll.success = function (ImageName) {

        var arry = ImageName.d.split('~');
        var exceedimage = "";

        ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

        Control.ImgUrl = arry[0];
        Control.OrignalImageName = arry[2];
        Control.IsFromBackEnd = true;
        Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
        Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
        exceedimage = Control.ExceedImage;

        if (exceedimage == "P") {
            $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
            $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);
            Control.MaxHeight = parseFloat($("#" + selectedObjectID + " img").innerHeight()) / mmConvertionConstant;
            Control.MaxWidth = parseFloat($("#" + selectedObjectID + " img").innerWidth()) / mmConvertionConstant;
            alignsingleImage(Control.ObjectID);
        }
        if (exceedimage == "S") {
            $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
            $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.Align);
            alignsingleImage(Control.ObjectID);
        }
        if (exceedimage == "D") {
            var arry = Control.ImgUrl.split('.');
            var imageanme = arry[0].split('-');
            checkforImage(imageanme[0] + "." + arry[1]);
        }

        filelist = "";
        $("#fileList").empty();
        $("#multipleFileUpload").val("");
        $("#galleryLink").trigger('click');
        loadFolderAndFilesBycategory(false, $("#drpSelectCategory").val());
        alignsingleImage(Control.ObjectID);
    };
    $.ajax(FitImageToContoll);

}


function SetImageAsBackgroud(height, width) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.MaxHeight = parseFloat(height);
    Control.Height = parseFloat(height);
    Control.MaxWidth = parseFloat(width);
    Control.Width = parseFloat(width);
    Control.PositionX = 0;
    Control.PositionY = 0;
    Control.CoordsX = 0;
    Control.CoordsY = 0;
    Control.OffsetLeft = 0;
    Control.OffsetTop = 0;
    Control.Left = 0;
    Control.Top = 0;
    Control.ZIndexValue = -1;

    if (Control.EditedImageName == "") {
        Control.BackgroundImage = Control.OrignalImageName;
    }
    else {
        Control.BackgroundImage = Control.EditedImageName;
    }
    changeThePageFromDropDown($("#drpPageSelect").val());



    //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + "Gallery/OriginalImages/" + Control.BackgroundImage);
    bindLeftPannel(Control.ObjectID);
    $("#" + Control.ObjectID).css('border', '1px solid #B2B2B2');
    $("#" + Control.ObjectID).css('cursor', 'pointer');
}

function RemoveImageAsBackgroud(height, width, PosX, PosY) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var numItems = $('.controll').length;
    var GUID = Guid();
    numItems = 1 + numItems;
    Control.ZIndexValue = numItems;
    Control.MaxHeight = parseFloat(height);
    Control.Height = parseFloat(height);
    Control.MaxWidth = parseFloat(width);
    Control.Width = parseFloat(width);
    Control.PositionX = PosX;
    Control.PositionY = PosY;
    Control.CoordsX = PosX;
    Control.CoordsY = PosY;
    Control.OffsetLeft = PosX;
    Control.OffsetTop = PosY;
    Control.Left = PosX;
    Control.Top = PosY;
    Control.BackgroundImage = "";
    changeThePageFromDropDown($("#drpPageSelect").val());

    Control.BackgroundImage = "";
    bindLeftPannel(Control.ObjectID);
    $("#" + Control.ObjectID).css('border', '1px solid #B2B2B2');
    $("#" + Control.ObjectID).css('cursor', 'pointer');
}

function RemoveImageEvents() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    $("#" + Control.ObjectID).css({ 'z-index': "-1" });
}


function changeExceedHeight(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.ExceedHeight = value;
}

function IsCropFromTopImage(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.IsCropFromTop = value;
}

function ChangeImageQuality(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.IsImageQuality = value;
    if (value) {
        Control.MinDPI = 300;
        $("#txtDPI").val(300);
    }
    else {
        Control.MinDPI = 0;
        $("#txtDPI").val(0);
    }
}

function changeMinDPI(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.MinDPI = value;
}

/*END*******************************************************************************/


/*Font Panel************************************************************************/


function applyFontToSelectedText(FontNameandFontid) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        var arry = FontNameandFontid.split('~');
        var fontpathName = arry[0];
        var fontid = arry[1];
        var ActualfontName = arry[2];
        var fontname = arry[3];
        var uniquefontname = getuniquefontname();
        var path = FontPath + fontpathName;


        $("head").prepend("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + path + "'); }</style>");

        if ($("#" + Control.ObjectID).hasClass('Text')) {

            var labelfontfamily = $("#" + Control.ObjectID + " .label").css('font-family');

            $("#" + Control.ObjectID + " .labelText").css('font-family', "'" + uniquefontname + "'");

            $("#" + Control.ObjectID + " .label").css('font-family', labelfontfamily);

            if ($("#" + Control.ObjectID + " .label").outerHeight() > $("#" + Control.ObjectID + " .labelText").outerHeight()) {
                $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .label").outerHeight() + "px" });
            }
            else {
                $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .labelText").outerHeight() + "px" });
            }
            Control.MaxHeight = $("#" + Control.ObjectID).outerHeight() / mmConvertionConstant;
            Control.Height = $("#" + Control.ObjectID).outerHeight() / mmConvertionConstant;
        }
        if ($("#" + Control.ObjectID).hasClass('Para')) {
            $("#" + Control.ObjectID).css('font-family', uniquefontname);
        }

        Control.FontFamily = fontname;
        Control.ActualFontName = ActualfontName;
        Control.FontID = parseFloat(fontid);
        Control.FontExtension = fontpathName;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        alignsingleLineText(Control.ObjectID);
    }

}

function applyIndentToSelecedText(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if (value == 0 || value == "") {
            if ($("#" + Control.ObjectID).hasClass('Text')) {
                $("#" + Control.ObjectID + " .labelText").css('padding-left', "0px");
            }
            else {
                $("#" + Control.ObjectID + " p").css('padding-left', "0px");
            }
            Control.Indent = 0;
            $("#txtFontIndent").val(0);
        }
        else {
            if ($("#" + Control.ObjectID).hasClass('Text')) {
                $("#" + Control.ObjectID + " .labelText").css('padding-left', value * mmConvertionConstant + "px");
                if ((($("#" + Control.ObjectID).outerWidth() - 2) >= $("#" + Control.ObjectID + " .labelText").outerWidth())) {
                    Control.Indent = value;
                }
                else {
                    $("#savemsg").html("Value is more then the object width.");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("#" + Control.ObjectID + " .labelText").css('padding-left', Control.Indent * mmConvertionConstant + "px");
                    $("#txtFontIndent").val(Control.Indent);
                }

            }
            if ($("#" + Control.ObjectID).hasClass('Para')) {
                $("#" + Control.ObjectID + " p").css('padding-left', value * mmConvertionConstant + "px");
                if ((($("#" + Control.ObjectID).outerWidth() - 2) >= (parseFloat($("#" + Control.ObjectID + "  p").css('padding-left')) + 2))) {
                    Control.Indent = value;
                }
                else {
                    $("#savemsg").html("Value is more then the object width.");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("#" + Control.ObjectID + " p").css('padding-left', Control.Indent * mmConvertionConstant + "px");
                    $("#txtFontIndent").val(Control.Indent);
                }
            }
        }
    }


}

function applyFontSizeToSelectedText() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


    Control.FontSize = (parseFloat($("#txtFontSize").val()));
    Control.OriginalFontSize = (parseFloat($("#txtFontSize").val()));
    var height;
    if ($("#" + Control.ObjectID).hasClass('Text')) {

        var labelfontsize = $("#" + Control.ObjectID + " .label").css('font-size');

        $("#" + Control.ObjectID + " .labelText").css('font-size', ((parseFloat(Control.FontSize)) / ptConvertionConstant) + "px");

        $("#" + Control.ObjectID + " .label").css('font-size', labelfontsize);

        if (parseFloat($("#" + Control.ObjectID + " .labelText").css('height')) > parseFloat($("#" + Control.ObjectID).css('height'))) {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").css('height')) >= parseFloat($("#" + Control.ObjectID + " .label").css('height'))) {
                $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .labelText").css('height') });
            }
            else {
                $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .labelText").css('height') });
            }
            Control.Height = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
            Control.MaxHeight = Control.Height;
        }

        var width = $("#" + Control.ObjectID).outerWidth();
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        width = width - LabelWidth;

        if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
            $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
            Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
            Control.Width = Control.MaxWidth;
        }

        if ($("#" + Control.ObjectID + " .label").outerHeight() > $("#" + Control.ObjectID + " .labelText").outerHeight()) {
            $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .label").outerHeight() + "px" });
        }
        else {
            $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .labelText").outerHeight() + "px" });
        }
        Control.MaxHeight = $("#" + Control.ObjectID).outerHeight() / mmConvertionConstant;
        Control.Height = $("#" + Control.ObjectID).outerHeight() / mmConvertionConstant;

        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        alignsingleLineText(Control.ObjectID);
        //applyContolHeightAccordingToFont(Control);
    }
    if ($("#" + Control.ObjectID).hasClass('Para')) {
        $("#" + Control.ObjectID).css('font-size', ((parseFloat(Control.FontSize)) / ptConvertionConstant) + "px");
        changeDefaultContent(Control.DefaultContent, false, true);
    }
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
}

function changeManualTraking(Property, value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    var labelletterspacing = $("#" + Control.ObjectID + " .label").css('letter-spacing');

    var val, sign;
    if (Property == "Dimention") {
        if (value == "pt") {
            val = Control.ManualTracking * ptConvertionConstant;
        }
        else if (value == "mm") {
            val = Control.ManualTracking * mmConvertionConstant;
        }
    }
    else {
        if (Property == "Text") {
            if (Control.ManualTrackDimension == "pt") {
                val = parseFloat(value) * ptConvertionConstant;
            }
            else if (Control.ManualTrackDimension == "mm") {
                val = parseFloat(value) * mmConvertionConstant;
            }
        }
        else {
            if (Control.ManualTrackDimension == "pt") {
                val = Control.ManualTracking * ptConvertionConstant;
            }
            else if (Control.ManualTrackDimension == "mm") {
                val = Control.ManualTracking * mmConvertionConstant;
            }
        }
    }

    if (Property == "Sign") {
        sign = value;
    }
    else {
        sign = Control.ManualTrackSign;
    }

    if (Control.Type == "TextBlock") {
        $("#" + Control.ObjectID + " .labelText").css('letter-spacing', sign + val + "px");
        $("#" + Control.ObjectID + " .label").css('letter-spacing', labelletterspacing + "px");
    }
    if (Control.Type == 'Paragraph') {
        $("#" + Control.ObjectID).css({ 'letter-spacing': sign + val + "px", 'overflow': 'hidden' });
        if (Property == "Sign") {
            Control.ManualTrackSign = value;
        }
        if (Property == "Dimention") {
            Control.ManualTrackDimension = value;
        }
        if (Property == "Text") {
            Control.ManualTracking = value;
        }
    }


    if (Control.Type == "TextBlock") {
        if (($("#" + Control.ObjectID).outerWidth()) >= ($("#" + Control.ObjectID + " .labelText").outerWidth())) {
            if (Property == "Sign") {
                Control.ManualTrackSign = value;
            }
            if (Property == "Dimention") {
                Control.ManualTrackDimension = value;
            }
            if (Property == "Text") {
                Control.ManualTracking = value;
            }
        }
        else {
            $("#savemsg").html("Value is more then the object width.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
            var vall;
            if (Control.ManualTrackDimension == "pt") {
                vall = Control.ManualTracking * ptConvertionConstant;
            }
            else if (Control.ManualTrackDimension == "mm") {
                vall = Control.ManualTracking * mmConvertionConstant;
            }
            $("#" + Control.ObjectID + " .labelText").css('letter-spacing', Control.ManualTrackSign + vall + "px");
            $("#" + Control.ObjectID + " .label").css('letter-spacing', labelletterspacing + "px");
            if (Control.ManualTrackSign == "+") {
                $("#drpManualTrackSign1").prop('selected', true);
            }
            else if (Control.ManualTrackSign == "-") {
                $("#drpManualTrackSign2").prop('selected', true);
            }
            $("#txtManulTracking").val(Control.ManualTracking);
            $("#drpManualTrackDimension" + Control.ManualTrackDimension).prop('selected', true);
        }
    }

}

function changeFontStyle(FontStyleName) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (FontStyleName != "") {
        for (var j = 0; j < FontStyleDetails.length; j++) {
            if (FontStyleDetails[j].FontStyleName == FontStyleName) {

                Control.FontSyleID = FontStyleDetails[j].FontID;
                Control.FontStyleName = FontStyleDetails[j].FontStyleName;
                Control.FontFamily = FontStyleDetails[j].FontFamily;
                Control.Capitalize = FontStyleDetails[j].Capitalize;
                Control.DataType = FontStyleDetails[j].DataType;
                Control.FontSize = FontStyleDetails[j].FontSize;
                Control.OriginalFontSize = FontStyleDetails[j].FontSize;
                Control.Indent = FontStyleDetails[j].Indent;
                Control.ManualTracking = FontStyleDetails[j].ManualTracking;
                Control.ManualTrackDimension = FontStyleDetails[j].TrackPoint;
                Control.ManualTrackSign = FontStyleDetails[j].TrackOffSet;
                for (k = 0; k < FontList.length; k++) {
                    if (FontList[k].FontFamily == Control.FontFamily) {
                        Control.FontID = FontList[k].FontID;
                        break;
                    }
                }


                $("#drpFontStyleID" + Control.FontSyleID).prop('selected', true);
                if (Control.FontSyleID != 0) {
                    $("#txtFontStyle").val(FontStyleDetails[j].FontStyleName);
                }
                else {
                    $("#txtFontStyle").val("");
                }
                $("#drpFontID" + Control.FontID).prop('selected', true);
                $("#txtFontSize").val(Control.FontSize);
                $("#txtFontIndent").val(Control.Indent);
                if (Control.ManualTrackSign == "+") {
                    $("#drpManualTrackSign1").prop('selected', true);
                }
                else if (Control.ManualTrackSign == "-") {
                    $("#drpManualTrackSign2").prop('selected', true);
                }
                $("#txtManulTracking").val(Control.ManualTracking);
                $("#drpManualTrackDimension" + Control.ManualTrackDimension).prop('selected', true);
                $("#drpDataType" + Control.DataType).prop('selected', true);
                $("#chkParagraphJustify").prop('checked', Control.IsJustify);
                if (FontStyleDetails[j].TextAlign == 'Left') {
                    if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, FontStyleDetails[j].TextAlign)) {
                        $(selectedControllID).css('text-align', 'left');
                        Control.TextAlign = "Left";
                        $("#rdLeftJustify").prop('checked', true);
                        $("#btnLeftAlign").addClass('menubuttonSelected');
                        $("#btnCenterAlign").removeClass('menubuttonSelected');
                        $("#btnRightAlign").removeClass('menubuttonSelected');
                    }
                }
                else if (FontStyleDetails[j].TextAlign == 'Center') {
                    if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, FontStyleDetails[j].TextAlign)) {
                        $(selectedControllID).css('text-align', 'center');
                        Control.TextAlign = "Center";
                        $("#rdLeftJustify").prop('checked', true);
                        $("#btnLeftAlign").removeClass('menubuttonSelected');
                        $("#btnCenterAlign").addClass('menubuttonSelected');
                        $("#btnRightAlign").removeClass('menubuttonSelected');
                    }
                }
                else if (FontStyleDetails[j].TextAlign == 'Right') {
                    if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, FontStyleDetails[j].TextAlign)) {
                        $(selectedControllID).css('text-align', 'right');
                        Control.TextAlign = "Right";
                        $("#rdLeftJustify").prop('checked', true);
                        $("#btnLeftAlign").removeClass('menubuttonSelected');
                        $("#btnCenterAlign").removeClass('menubuttonSelected');
                        $("#btnRightAlign").addClass('menubuttonSelected');
                    }
                }

                if (Control.Capitalize == "User Input") {
                    $("#rdUserInput").prop('checked', true);
                    changeCapitalize("User Input");
                }
                else if (Control.Capitalize == "All Caps") {
                    $("#rdAllUpper").prop('checked', true);
                    changeCapitalize("All Caps");
                }
                else if (Control.Capitalize == "InitCap") {
                    $("#rdFirstLetterCaps").prop('checked', true);
                    changeCapitalize("InitCap");
                }
                else if (Control.Capitalize == "First Cap") {
                    $("#rdAllWordFirstCaps").prop('checked', true);
                    changeCapitalize("First Cap");
                }
                else {
                    $("#rdAllLower").prop('checked', true);
                    changeCapitalize("All Lower");
                }

                applyFontToSelectedText($("#drpApplyFont").val());
                applyIndentToSelecedText();
                applyFontSizeToSelectedText();
                changeManualTraking("Sign", $("#drpManualTrackSign").val());
                changeManualTraking("Dimention", $("#drpManualTrackDimension").val());
                changeManualTraking("Text", $("#txtManulTracking").val());
                alignsingleLineText(Control.ObjectID);
                break;
            }
        }
    }
    else {
        Control.FontSyleID = 0;
        Control.FontStyleName = "";
        Control.FontFamily = "Arial";
        Control.ActualFontName = "Arial";
        Control.FontExtension = "Arial.ttf";
        Control.Capitalize = "User Input";
        Control.DataType = "Text";
        Control.FontSize = 10;
        Control.Indent = 0;
        Control.ManualTracking = 0;
        Control.ManualTrackDimension = "mm";
        Control.ManualTrackSign = "+";
        $("#" + Control.ObjectID).remove();
        if (Control.Type == "TextBlock") {
            AddTextDynamically(Control, true);
        }
        else if (Control.Type == "Paragraph") {
            AddParaDynamically(Control, true);
        }
        alignsingleLineText(Control.ObjectID);
    }
}


function changeCapitalize(Capitalize) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Capitalize = Capitalize;
    if ($("#" + Control.ObjectID).hasClass('Text')) {
        if (Control.DefaultContent == Control.FieldName) {
            changeDefaultContent($("#txtDefaultContent").val(), false, false);
        }
        else {
            changeDefaultContent($("#txtDefaultContent").val(), true, false);
        }
    }
    else if ($("#" + Control.ObjectID).hasClass('Para')) {

        if (Control.DefaultContent == Control.FieldName) {
            changeDefaultContent($("#txtParaDefaultContent").val(), false, false);
        }
        else {
            changeDefaultContent($("#txtParaDefaultContent").val(), true, false);
        }
    }

}

function changeParagraphJustificationValue(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (value == "Justify") {
        Control.TextAlign = value;
        $("#" + Control.ObjectID + " .paraText").css('text-align', value);
    }
    else {
        Control.TextAlign = "Left";
        $("#" + Control.ObjectID + " .paraText").css('text-align', 'Left');
    }

}


function changeDataType(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.DataType = value;
}

/*END*******************************************************************************/

/*Color Panel************************************************************************/

function chnageFontColorRGBtoCMKY(color) {

    var rgb = color.replace(/^(rgb|rgba)\(/, '').replace(/\)$/, '').replace(/\s/g, '').split(',');
    r = rgb[0];
    g = rgb[1];
    b = rgb[2];

    r = r / 255;
    g = g / 255;
    b = b / 255;

    k = Math.min(1 - r, 1 - g, 1 - b);
    c = (1 - r - k) / (1 - k);
    m = (1 - g - k) / (1 - k);
    y = (1 - b - k) / (1 - k);

    c = Math.round(c * 100);
    m = Math.round(m * 100);
    y = Math.round(y * 100);
    k = Math.round(k * 100);

    if (isNaN(c)) {
        c = 0;
    }
    if (isNaN(m)) {
        m = 0;
    }
    if (isNaN(y)) {
        y = 0;
    }
    if (isNaN(k)) {
        k = 0;
    }

    $("#txtC").attr('value', c + '.00');
    $("#txtM").attr('value', m + '.00');
    $("#txtY").attr('value', y + '.00');
    $("#txtK").attr('value', k + '.00');

    $("#rngC").val(c);
    $("#rngM").val(m);
    $("#rngY").val(y);
    $("#rngK").val(k);


}

function chnageFontColorCMYKtoRGB() {

    var c = 0.00, m = 0.00, k = 0.00, y = 0.00, r = 0.00, g = 0.00, b = 0.00, tint = 0.00;
    c = $("#txtC").val();
    m = $("#txtM").val();
    y = $("#txtY").val();
    k = $("#txtK").val();
    tint = $("#txtT").val();

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var labeelColor = $("#" + Control.ObjectID + " .label").css('color');



    c = parseFloat(c / 100);
    m = parseFloat(m / 100);
    y = parseFloat(y / 100);
    k = parseFloat(k / 100);

    Control.C = c;
    Control.M = m;
    Control.Y = y;
    Control.K = k;
    Control.Tint = tint;

    r = 1 - parseFloat((1, c * (1 - k) + k));
    g = 1 - parseFloat((1, m * (1 - k) + k));
    b = 1 - parseFloat((1, y * (1 - k) + k));

    //r = tint * r + (1 - tint) * 255;
    //g = tint * g + (1 - tint) * 255;
    //b = tint * b + (1 - tint) * 255;

    r = Math.round(r * 255);
    g = Math.round(g * 255);
    b = Math.round(b * 255);

    Control.R = r;
    Control.G = g;
    Control.B = b;

    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if ($("#" + Control.ObjectID).hasClass('Text')) {
            $("#" + Control.ObjectID + " .labelText").css('color', 'rgb(' + r + ',' + g + ',' + b + ')');
        }
        if ($("#" + Control.ObjectID).hasClass('Para')) {
            $("#" + Control.ObjectID).css('color', 'rgb(' + r + ',' + g + ',' + b + ')');
        }
    }
    $("#" + Control.ObjectID + " .label").css('color', labeelColor);
}

function changeColorByInputText() {
    chnageFontColorCMYKtoRGB();
}

function chengeColorStyle(Name) {
    if (Name != "0") {
        for (var j = 0; j < ColorStyleDetails.length; j++) {
            if (ColorStyleDetails[j].ColorStyleName == Name) {
                $("#txtC").val(ColorStyleDetails[j].C);
                $("#txtM").val(ColorStyleDetails[j].M);
                $("#txtY").val(ColorStyleDetails[j].Y);
                $("#txtK").val(ColorStyleDetails[j].K);
                $("#txtT").val(ColorStyleDetails[j].Tint);
                var Control;
                ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                Control.ColorStyle = ColorStyleDetails[j].ColorStyleName;
                Control.SpotColor = ColorStyleDetails[j].SpotColor;
                Control.SpotColorRef = ColorStyleDetails[j].SpotColorRef;
                if (ColorStyleDetails[j].SpotColor) {
                    $("#chkSpotColor").prop('checked', true);
                    $("#txtSpotColor").prop('disabled', false);
                    $("#txtSpotColor").val(ColorStyleDetails[j].SpotColorRef);
                }
                else {
                    $("#chkSpotColor").prop('checked', false);
                    $("#txtSpotColor").prop('disabled', true);
                    $("#txtSpotColor").val("");
                }
                $("#txtColorStyle").val(ColorStyleDetails[j].ColorStyleName);

                chnageFontColorCMYKtoRGB();
                $("#txtC").trigger('change');

                $("#colorStleRextangle").css({ 'background-color': $("#" + Control.ObjectID + " .labelText").css('color'), 'border-color': '#b2b2b2' });
            }
        }
    }
    else {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        $("#txtC").val(0.00);
        $("#txtM").val(0.00);
        $("#txtY").val(0.00);
        $("#txtK").val(100.00);
        $("#txtT").val(Control.Tint);
        chnageFontColorCMYKtoRGB();
        $("#txtC").trigger('change');
        Control.ColorStyle = "";
        Control.SpotColor = false;
        Control.SpotColorRef = "";
        $("#chkSpotColor").prop('checked', false);
        $("#txtSpotColor").prop('disabled', true);
        $("#txtSpotColor,#txtColorStyle").val("");

        $("#colorStleRextangle").css({ 'background-color': 'transparent', 'border-color': 'transparent' });
    }
}

function minmax(value, min, max) {
    if (parseInt(value) < min || isNaN(value))
        return min;
    else if (parseInt(value) > max)
        return max;
    else return value;
}

function minmaxtrack(value, min, max) {

    if (parseInt(value) < min || isNaN(value))
        return min.toFixed(0)
    else if (parseInt(value) > max)
        return max.toFixed(0);

    else return value.split('.')[0];
}

function changeSpotColor(spotColorRef, spotColor) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (spotColor) {
        Control.SpotColor = spotColor;
        Control.SpotColorRef = spotColorRef;
    }
    else {
        Control.SpotColor = spotColor;
        Control.SpotColorRef = "";
        $("#txtSpotColor").val("");
    }
}

function getRGBFromCMYK(c, m, y, k) {

    c = parseFloat(c / 100);
    m = parseFloat(m / 100);
    y = parseFloat(y / 100);
    k = parseFloat(k / 100);

    r = 1 - parseFloat((1, c * (1 - k) + k));
    g = 1 - parseFloat((1, m * (1 - k) + k));
    b = 1 - parseFloat((1, y * (1 - k) + k));

    //r = tint * r + (1 - tint) * 255;
    //g = tint * g + (1 - tint) * 255;
    //b = tint * b + (1 - tint) * 255;

    r = Math.round(r * 255);
    g = Math.round(g * 255);
    b = Math.round(b * 255);

    return r + "~" + g + "~" + b;
}

/*END*******************************************************************************/

/*Save Template Panel*******************************************************************************/

function changeAllowTextBlock(Status) {
    TemplateDetails.AddNewTextBlock = Status;
}

function changeAllowParagraph(Status) {
    TemplateDetails.AddNewParagraph = Status;
}

function changeAllowImage(Status) {
    TemplateDetails.AddNewImage = Status;
}

function changeShowEditor(Status) {
    TemplateDetails.ShowEdiotr = Status;
}

function changeShoweditablePages(Status) {
    TemplateDetails.ShowEditablePages = Status;
}

function changeSendAttachments(Status) {

    TemplateDetails.SendAttachment = Status;
}

function changeTemplateName(Text) {

    TemplateDetails.TemplateName = Text;
}

function changeTemplateDescription(Text) {

    TemplateDetails.TemplateDescription = Text;
}

function UpadteTemplteDetails(FromSaveButton, Saveandclose) {
    $(".loading_new").show();

    var result = true;

    $.ajax({
        url: ServicePath + "UpadteTemplateDetails",
        type: "POST",
        data: JSON.stringify({ TemplateDetail: JSON.stringify(TemplateDetails), templateID: TemplateID, userid: UserID, companyid: CompanyID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (resultFromSevice) {
            if (resultFromSevice.d == false) {
                result = false;
            }

            SaveTemplateProperties(FromSaveButton, Saveandclose, result);
        },
        error: function (error, et) {
            error = false;
            showSavedPopup(FromSaveButton, Saveandclose, result);
        }
    });
}
function SaveTemplateProperties(FromSaveButton, Saveandclose, result) {
    if (ControllDetails.length > 0 && result == true) {
        for (var i = 0; i < ControllDetails.length; i++) {
            var control = JSON.stringify(ControllDetails[i]);
            $.ajax({
                url: ServicePath + "UpdateTemplateProperties",
                type: "POST",
                data: JSON.stringify({ ControlDetail: control, templateID: TemplateID, userid: UserID, companyid: CompanyID, _key: DBKey, lastone: (i == ControllDetails.length - 1) }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (resultFromSevice) {
                    if (resultFromSevice.d.split(',')[0].toLowerCase() == "false") {
                        result = false;
                    }
                    showSavedPopup(FromSaveButton, Saveandclose, result);
                },
                error: function (error, et) {
                    result = false;
                    showSavedPopup(FromSaveButton, Saveandclose, result);
                }
            });
        }
    }
    else {
        showSavedPopup(FromSaveButton, Saveandclose, result);
    }
}


function showSavedPopup(FromSaveButton, Saveandclose, result) {
    $(".loading_new").hide();
    if (FromSaveButton == true) {
        if (result) {
            $("#savemsg").html("Template Saved Successfully.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }
        else {
            $("#savemsg").html("Error occured, please reload the browser.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }
    }
    else {
        if (Saveandclose == true) {
            if (result) {
                var win = window.open('', '_self', '');
                win.close();
            }
            else {
                $("#savemsg").html("Error occured, please reload the browser.");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
            }
        }
    }
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
}

/*END*********************************************************************************************/
/*Label Panel*********************************************************************************************/

function AddLabel() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    Control.LabelActualFontName = "Arial";
    Control.LabelFontExtension = "Arial.ttf";
    Control.LabelFontStyle = "";
    Control.LabelFontID = 0;
    Control.LabelPosition = "Attached";
    Control.LabelFontSize = Control.FontSize;
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    Control.CustomLeft = 0;
    Control.CustomRight = 0;
    var labelHtml = "<span style='font-size:" + Control.FontSize / ptConvertionConstant + "px;text-align:left;display:inline-block;position:relative;font-family:arial;text-align:left;color:black;font-weight:normal;' class='label'>" + Control.LabelValue.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt") + "</span>";

    attachLabelTosinglelineControl(Control.ObjectID, labelHtml + ((Control.DefaultContent == "") ? Control.FieldName : Control.DefaultContent));
    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    $("#" + Control.ObjectID + " label").css({ 'color': 'black', 'font-family': 'arial' });
}

function ChangeLabelText(Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.LabelValue = $("#txtLabel").val();
    $("#" + Control.ObjectID + " .label").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "Attached") {
        $("#" + Control.ObjectID + " .label").css({ 'width': 'auto' });
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID + " .label").css({ 'width': LabelWidth + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'marigin-left': LabelWidth + 'px' });
    }
    else if (Control.LabelPosition == "customLeft") {
        $("#" + Control.ObjectID + " .label").css({ 'width': (Control.CustomLeft * mmConvertionConstant) + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'marigin-left': (Control.CustomLeft * mmConvertionConstant) + 'px' });
    }

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');

    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

    if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
        Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
        Control.Width = Control.MaxWidth;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }
    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize });
}

function RemoveLabel() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "None";
    Control.LabelActualFontName = "Arial";
    Control.LabelFontExtension = "Arial.ttf";
    Control.LabelFontStyle = "";
    Control.LabelFontID = 0;
    Control.LabelStyle = "";
    Control.LabelColor = "";
    Control.LabelPosition = "Attached";
    Control.Label = null;
    Control.LabelValue = "";
    Control.CustomLeft = 0;
    Control.CustomRight = 0;
    $("#" + Control.ObjectID + " .label").remove();
    $("#" + Control.ObjectID + " .labelText").css({ 'margin-left': '0px' });
    $("#txtLabel").val("");

    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
}

function AddLabelAttached() {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    Control.LabelActualFontName = "Arial";
    Control.LabelFontExtension = "Arial.ttf";
    Control.LabelFontStyle = "";
    Control.LabelFontID = 0;
    Control.LabelPosition = "Attached";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    Control.CustomLeft = 0;
    Control.CustomRight = 0;

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');

    $("#" + Control.ObjectID + " .label").html(Control.LabelValue.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "Attached") {
        $("#" + Control.ObjectID + " .label").css({ 'width': 'auto' });
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID + " .label").css({ 'width': LabelWidth + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'marigin-left': LabelWidth + 'px' });
    }

    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

    if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
        Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
        Control.Width = Control.MaxWidth;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }

    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize });

    $(".leftofobject").val("");
    $(".aboveobject").val("");

}

function AddRightLabelAttached() {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    Control.LabelActualFontName = "Arial";
    Control.LabelFontExtension = "Arial.ttf";
    Control.LabelFontStyle = "";
    Control.LabelFontID = 0;
    Control.LabelPosition = "RightAttached";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    Control.CustomLeft = 0;
    Control.CustomRight = 0;

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');

    $("#" + Control.ObjectID + " .label").html(Control.LabelValue.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "RightAttached") {
        $("#" + Control.ObjectID + " .label").css({ 'width': 'auto' });
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID + " .label").css({ 'width': LabelWidth + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'marigin-right': LabelWidth + 'px' });
    }

    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

    if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
        Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
        Control.Width = Control.MaxWidth;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }

    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize });

    $(".leftofobject").val("");
    $(".aboveobject").val("");

}

function AddCustomPositioning() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    Control.LabelActualFontName = "Arial";
    Control.LabelFontExtension = "Arial.ttf";
    Control.LabelFontStyle = "";
    Control.LabelFontID = 0;
    Control.LabelPosition = "customLeft";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    Control.CustomLeft = isNaN(parseFloat($(".leftofobject").val())) ? 0 : parseFloat($(".leftofobject").val());

    $("#" + Control.ObjectID + " .label").html(Control.LabelValue.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "customLeft") {
        $("#" + Control.ObjectID + " .label").css({ 'width': (Control.CustomLeft * mmConvertionConstant) + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'marigin-left': (Control.CustomLeft * mmConvertionConstant) + 'px' });
    }

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');

    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize });

    if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
        Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
        Control.Width = Control.MaxWidth;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }


}

function AddCustomPositioningToLeft() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    Control.LabelActualFontName = "Arial";
    Control.LabelFontExtension = "Arial.ttf";
    Control.LabelFontStyle = "";
    Control.LabelFontID = 0;
    Control.LabelPosition = "customLeft";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    $("#" + Control.ObjectID + " br").remove();
    Control.CustomLeft = isNaN(parseFloat($(".leftofobject").val())) ? 0 : parseFloat($(".leftofobject").val());

    $("#" + Control.ObjectID + " .label").html(Control.LabelValue.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "customLeft") {
        $("#" + Control.ObjectID + " .label").css({ 'width': (Control.CustomLeft * mmConvertionConstant) + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'marigin-left': (Control.CustomLeft * mmConvertionConstant) + 'px' });
    }

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');


    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize });

    if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
        Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
        Control.Width = Control.MaxWidth;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }


}


function AddCustomPositioningToTopIntial() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    Control.LabelActualFontName = "Arial";
    Control.LabelFontExtension = "Arial.ttf";
    Control.LabelFontStyle = "";
    Control.LabelFontID = 0;
    Control.LabelPosition = "customTop";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    Control.CustomTop = isNaN(parseFloat($(".aboveobject").val())) ? 0 : parseFloat($(".aboveobject").val());
    $("#" + Control.ObjectID + " .label").css({ 'vertical-align': 'top', 'margin-bottom': parseFloat(Control.CustomTop * mmConvertionConstant) + 'px' });
    if (Control.LabelValue == "") {
        $("#" + Control.ObjectID + " .label").html("&nbsp;");
    }
    else {
        $("#" + Control.ObjectID + " .label").html(Control.LabelValue.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));
    }

    if (Control.TextAlign != "Center") {
        $("#" + Control.ObjectID + " .label").css({ 'float': Control.TextAlign, 'margin-left': '0px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'float': Control.TextAlign });
    }
    else {
        var mar = (Control.Width * mmConvertionConstant / 2) - ((parseFloat($("#" + Control.ObjectID + " .label").innerWidth())) / 2);
        $("#" + Control.ObjectID + " .label").css({ 'float': 'left', 'margin-left': mar + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'float': 'left', 'text-align': 'center' });
    }
    $("#" + Control.ObjectID + " .labelText").css({ 'margin-left': '0px', 'vertical-align': 'baseline' });


    var divHeight = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + parseFloat(Control.CustomTop * mmConvertionConstant) + parseFloat($("#" + Control.ObjectID + " .label").css('line-height'));
    $("#" + Control.ObjectID).css({ 'height': divHeight + "px", 'line-height': divHeight + "px" });
    Control.Height = divHeight / mmConvertionConstant;
    Control.MaxHeight = divHeight / mmConvertionConstant;
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

}

function AddCustomPositioningToTop() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    Control.LabelActualFontName = "Arial";
    Control.LabelFontExtension = "Arial.ttf";
    Control.LabelFontStyle = "";
    Control.LabelFontID = 0;
    Control.LabelPosition = "customTop";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    Control.CustomTop = isNaN(parseFloat($(".aboveobject").val())) ? 0 : parseFloat($(".aboveobject").val());

    $("#" + Control.ObjectID + " .label").css({ 'vertical-align': 'top', 'margin-bottom': parseFloat(Control.CustomTop * mmConvertionConstant) + 'px' });

    if (Control.TextAlign != "Center") {
        $("#" + Control.ObjectID + " .label").css({ 'float': Control.TextAlign, 'margin-left': '0px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'float': Control.TextAlign });
    }
    else {
        var mar = (Control.Width * mmConvertionConstant / 2) - ((parseFloat($("#" + Control.ObjectID + " .label").innerWidth())) / 2);
        $(selectedControllID + " .label").css({ 'float': 'left', 'margin-left': mar + 'px' });
        $(selectedControllID + " .labelText").css({ 'float': 'left', 'text-align': 'center' });
    }
    $("#" + Control.ObjectID + " .labelText").css({ 'margin-left': '0px', 'vertical-align': 'baseline' });

    var divHeight = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + parseFloat(Control.CustomTop * mmConvertionConstant) + parseFloat($("#" + Control.ObjectID + " .label").css('line-height'));
    $("#" + Control.ObjectID).css({ 'height': divHeight + "px", 'line-height': divHeight + "px" });
    Control.Height = divHeight / mmConvertionConstant;
    Control.MaxHeight = divHeight / mmConvertionConstant;
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

}

function changeLabelFontStyle(FontStyleName) {
    if (FontStyleName != "") {
        for (var j = 0; j < FontStyleDetails.length; j++) {
            if (FontStyleDetails[j].FontStyleName == FontStyleName) {
                var Control;
                ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                Control.LabelFontID = FontStyleDetails[j].FontID;
                Control.LabelFontSize = FontStyleDetails[j].FontSize;
                Control.LabelFontStyle = FontStyleDetails[j].FontStyleName;
                for (var k = 0; k < FontList.length; k++) {
                    if (FontList[k].DisplayFontName == FontStyleDetails[j].FontFamily) {

                        Control.LabelActualFontName = FontList[k].ActualFontName;
                        Control.LabelFontExtension = FontList[k].FontFilePath;
                        break;
                    }
                }
                var val;
                if (FontStyleDetails[j].TrackPoint == "pt") {
                    val = FontStyleDetails[j].ManualTracking * ptConvertionConstant;
                }
                else if (FontStyleDetails[j].TrackPoint == "mm") {
                    val = FontStyleDetails[j].ManualTracking * mmConvertionConstant;
                }
                var uniquefontname = getuniquefontname();
                $("head").append("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + FontPath + Control.LabelFontExtension + "'); }</style>");
                $("#" + selectedObjectID + " .label").css({ 'font-family': uniquefontname, 'letter-spacing': FontStyleDetails[j].TrackOffSet + val + 'px', 'font-size': FontStyleDetails[j].FontSize / ptConvertionConstant + 'px' });
                var Text = Control.LabelValue;
                var defaultContent = capitalizeTheText(Text, FontStyleDetails[j].Capitalize);

                $("#" + selectedObjectID + " .label").html(defaultContent);

                if (parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) >= parseFloat($("#" + Control.ObjectID + " .label").css('line-height'))) {
                    $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .labelText").css('line-height') });
                    $("#" + Control.ObjectID + " .label").css({ 'height': $("#" + Control.ObjectID + " .labelText").css('line-height') });
                }
                else {
                    $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .label").css('line-height') });
                    $("#" + Control.ObjectID + " .labelText").css({ 'height': $("#" + Control.ObjectID + " .label").css('line-height') });
                }
                Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
                Control.MaxHeight = Control.Height;
                //applyContolHeightAccordingToFont(Control);

                //var widthOflabel = parseFloat($("#" + Control.ObjectID + " .label").innerWidth());
                //var mar = (Control.CustomLeft * mmConvertionConstant) - widthOflabel;
                //$("#" + Control.ObjectID + " .labelText").css({ 'margin-left': mar + 'px', 'display': 'inline' });

                fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
                $("#" + selectedObjectID + " .labelText").css({ 'bottom': 'auto' });
            }
        }
    }
    else {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.LabelFontID = 0;
        Control.LabelFontSize = parseFloat($("#" + selectedObjectID + " .labelText").css('font-size')) * ptConvertionConstant;
        Control.LabelStyle = "";
        Control.LabelActualFontName = "Arial";
        Control.LabelFontExtension = "Arial.ttf";

        $("#" + selectedObjectID + " .label").css({ 'font-family': 'arial', 'font-weight': 'normal', 'font-style': 'normal', 'letter-spacing': 'normal', 'font-size': $("#" + selectedObjectID + " .labelText").css('font-size') });
        $("#" + selectedObjectID + " .labelText").css({ 'bottom': 'auto' });
    }
}



function changeLabelColorStyle(Name) {

    if (Name != "0") {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        var ColorStyleDetail = null;
        ColorStyleDetails.map(function (proj) { if (proj.ColorStyleName == Name) ColorStyleDetail = proj });
        if (ColorStyleDetail != null) {
            Control.LabelColor = ColorStyleDetail.ColorStyleName;
            $("#" + Control.ObjectID + " .label").css('color', 'rgb( ' + ColorStyleDetail.R + ', ' + ColorStyleDetail.G + ', ' + ColorStyleDetail.B + ')');
        }
    }
    else {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.LabelColor = "";
        $("#" + selectedObjectID + " .label").css({ 'color': 'black' });
        $("#" + selectedObjectID + " .labelText").css({ 'bottom': 'auto' });

    }
}



/*END*********************************************************************************************/

/*Review Fields*********************************************************************************************/

function loadFuctionForReview() {

    $(".reiewFields").mouseenter(function () {

        if ($(this).css('background-color') == "rgb(255, 255, 255)") {
            $(this).css('background-color', 'rgb(230, 243, 247)');
        }
        if ($(this).css('background-color') == "rgba(0, 0, 0, 0)") {
            $(this).css('background-color', 'rgb(230, 243, 247)');
        }

    });

    $(".reiewFields").mouseleave(function () {
        if ($(this).css('background-color') == "rgb(230, 243, 247)") {
            $(this).css('background-color', 'rgb(255, 255, 255)');
        }
    });

    $(".reiewFields").mousedown(function () {
        deSelect();

        $(this).css('background-color', 'rgb(203, 230, 239)');
        var id = $(this).attr('id').split('_');
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == id[1]) Control = proj });

        if (Control.Type == "Image") {
            $("#" + Control.ObjectID).css('border', '1px solid #B2B2B2');
            $("#" + Control.ObjectID).css('cursor', 'pointer');
        }
        else {
            $("#" + Control.ObjectID).css('border', '1px dashed #808080');
            $("#" + Control.ObjectID).css('cursor', 'pointer');
        }

        changeSelectedControllID();
        bindLeftPannel(Control.ObjectID);
    });
}

/*END*********************************************************************************************/

/*Quick Adjust Popup*********************************************************************************************/

function loadDesignogQuickAdjust() {
    $("#QuickAdjustDialog").css('overflow', 'hidden');
    //$(".quickadjust_Overflowdiv").css('height', $("#QuickAdjustDialogTable").css('height'));
    //$("#QuickAdjustDialog select").css({ 'background': '#FFFFFF url(' + SiteImages + 'arrow-down.png) no-repeat 100% center', '-webkit-appearance': 'none', '-moz-appearance': ' none' });
    $(".ui-dialog-buttonset").css({ 'width': 'auto' });
    $(".Heading td").css({ 'padding': '5px 0px 5px 5px', 'margin': '0px', 'font-size': '11px', 'font-family': 'Verdana' });
    $(".color").css({ 'margin-left': '8px' });
    $(".QuickTextBox").css({ 'width': '65px', 'font-size': '11px', 'margin': '0px auto 0px auto', 'height': '20px', 'border': '1px solid #8D8091', 'border-radius': '1px', 'padding-left': '2px' });
    $(".QuickSelect").css({ 'width': '65px', 'font-size': '11px', 'margin': '0px auto 0px auto', 'height': '24px', 'border': '1px solid #8D8091', 'border-radius': '1px', 'padding-left': '2px' });
    $(".drpqfont").css({ 'width': '100px', 'margin-left': '5px' });
    $(".drpfieldMovement").css({ 'width': '120px', 'margin-left': '5px' });
    $(".drpOrientation").css({ 'width': '100px', 'margin-left': '5px' });
    $(".txtqfieldName").css({ 'width': '100px' });
    $(".contentTd").css({ 'padding': '1px 5px 1px 5px' });


    //$(".actions").css({ 'padding': '3px 20px 3px 20px' });
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
    $("#QuickAdjustDialogTable .image").unbind('mouseenter').bind('mouseenter', function () {
        $(this).css({ 'border': '1pt solid #000000' });
    });
    $("#QuickAdjustDialogTable .image").unbind('mouseleave').bind('mouseleave', function () {
        $(this).css({ 'border': '1pt solid transparent' });
    });
    $("select.GroupDisable").prop('disabled', true);
    $("select.GroupDisable").css({ 'background-color': '#EBEBE4', 'background-image': 'url(none)' });
    $("Input.GroupDisable").attr('disabled', 'disabled');
    $(".contentTr td").css({ 'padding-right': '10px' });
    $("td.actions").css({ 'padding-right': '5px' });

    $("div[aria-describedby=QuickAdjustDialog] .ui-dialog-buttonpane").css({ 'margin-right': '20px', 'margin-top': '0px', 'margin-left': '20px', 'border': '2px solid white', 'border-top': '0px', 'padding-top': '10px', 'padding-bottom': '5px', 'background-color': '#F6F6F6', 'margin-bottom': ' 15px' });
    $("div[aria-describedby=QuickAdjustDialog] .ui-dialog-buttonpane .ui-button").css('margin', '5px 10px 5px 10px');
    $("div[aria-describedby=QuickAdjustDialog] .ui-dialog-buttonpane .ui-button span").css({ 'font-size': '11px' });
}

function loadFontDropDownOfQuickAdjust() {

    $(".DeleteControll").click(function () {
        if (confirm("Are you sure you want to delete control? \nThis action cannot be undone.")) {
            var id = $(this).attr('id').split('_')[1];
            deleteContolQuickAdjust(id);
        }
    });
    $(".drpOrientation").change(function () {
        var objectid = $(this).attr('id').split('_')[1];
        if ($(this).val() == "Vertical") {
            $("#fldmnt_" + objectid).empty();
            $("#fldmnt_" + objectid).append("<option val='None' slected>None</option><option val='Move Field Up' >Move Field Up</option><option val='Move Field Down' >Move Field Down</option>");
        }
        else if ($(this).val() == "Horizontal") {
            $("#fldmnt_" + objectid).empty();
            $("#fldmnt_" + objectid).append("<option val='None' slected>None</option><option val='Move Field Left' >Move Field Left</option><option val='Move Field Right' >Move Field Right</option>");
        }
        else if ($(this).val() == "None") {
            $("#fldmnt_" + objectid).empty();
            $("#fldmnt_" + objectid).append("<option val='None' slected>None</option>");
        }
    });
    for (var i = 0; i < ControllDetails.length; i++) {
        for (var z = 0; z < FontList.length; z++) {

            if (ControllDetails[i].Type != "Image") {

                if (ControllDetails[i].FontID == FontList[z].FontID) {
                    $("#fontdrp_" + ControllDetails[i].ObjectID).append("<option value='" + FontList[z].FontFilePath + "~" + FontList[z].FontID + "~" + FontList[z].ActualFontName + "~" + FontList[z].DisplayFontName + "' id='drpFontID" + z + "" + FontList[z].FontID + "' selected >" + FontList[z].DisplayFontName + "</option>");
                }
                else {
                    $("#fontdrp_" + ControllDetails[i].ObjectID).append("<option value='" + FontList[z].FontFilePath + "~" + FontList[z].FontID + "~" + FontList[z].ActualFontName + "~" + FontList[z].DisplayFontName + "' id='drpFontID" + z + "" + FontList[z].FontID + "' >" + FontList[z].DisplayFontName + "</option>");
                }
            }
            else {
                $("#fontdrp_" + ControllDetails[i].ObjectID).prop('disabled', true);
                $("#fldmnt_" + ControllDetails[i].ObjectID).prop('disabled', true);
                $("#ornt_" + ControllDetails[i].ObjectID).prop('disabled', true);
                $("#ornt_" + ControllDetails[i].ObjectID).css({ 'background-color': '#EBEBE4', 'background-image': 'url(none)' });
                $("#fldmnt_" + ControllDetails[i].ObjectID).css({ 'background-color': '#EBEBE4', 'background-image': 'url(none)' });
                $("#fontdrp_" + ControllDetails[i].ObjectID).css({ 'background-color': '#EBEBE4', 'background-image': 'url(none)' });
            }
        }
    }
}


function SaveQuickAdjustDetails() {
    $('#QuickAdjustDialogTable').find('input.Controlls').each(function () {
        if ($(this).prop('disabled') == false) {
            var TextBoxId = $(this).attr('id');
            var Text = $(this).val();
            var arry = TextBoxId.split('_');
            var property = arry[0];
            var objectid = arry[1];

            if (property == "fldname") {
                changeFiledNameQuickAdjust(objectid, Text);
            }
            else if (property == 'posx') {
                changePositionXQuickAdjust(objectid, Text);
            }
            else if (property == 'posy') {
                changePositionYQuickAdjust(objectid, Text);
            }
            else if (property == 'width') {
                changeWidthQuickAdjust(objectid, Text);
            }
        }

    });
    $('#QuickAdjustDialogTable').find('select.Controlls').each(function () {
        if ($(this).prop('disabled') == false) {
            var SelectID = $(this).attr('id');
            var Value = $(this).val();
            var arry = SelectID.split('_');
            var property = arry[0];
            var objectid = arry[1];

            if (property == "pgnum") {
                changePageQuickAdjust(objectid, Value);
            }
            else if (property == "ornt") {
                changeGroupOrientationQuickAdjust(objectid, Value);
            }
            else if (property == "fldmnt") {
                changeGroupKeepOptionQuickAdjust(objectid, Value);
            }
            else if (property == "fontdrp") {
                changeFontQuickAdjust(objectid, Value);
            }

        }
    });

    UpadteTemplteDetails(false, false);
    changeThePageFromDropDown($("#drpPageSelect").val());
}


function openGallery(FilesAndFolders, CategoryID) {
    $("#ImageFromGallery").dialog("open");
    $(function () {
        $("#tabs").tabs();
    });
    $(".loading_gallery").show();
    $("#FileUplaod").css({ 'padding-bottom': '10px' });
    //$('.ui-tabs-nav').css({ 'margin-bottom': '0px', 'height': '30px', 'padding': '0px', 'background': 'none', 'background-color': 'transparent', 'border': '0px', 'border-radius': '0px', 'background': 'transparent' });
    //$(".ui-tabs-nav .ui-state-default a").css({ 'font-size': '14px', 'font-family': 'verdana', 'font-weight': 'bold' });
    //$(".ui-tabs-nav .ui-state-default").css({ 'height': '28px', 'z-index': '11', 'background': 'none', 'background-color': 'white', 'border': '0px solid #a9a9a9' });
    $(".ui-tabs-nav .ui-tabs-active").css({ 'margin': '0px', 'height': '24px', 'z-index': '11', 'background': 'none', 'background-color': '#F2F4F5', 'border': '1px solid #a9a9a9', 'border-bottom-width': '0px' });

    $("#galleryLink").css({ 'font-size': '11px', 'font-family': 'Verdana', 'font-weight': 'bold' });
    $("#fileUploadLink").css({ 'font-size': '11px', 'font-family': 'Verdana', 'font-weight': 'bold' });
    $(".ui-tabs-nav .ui-state-default").unbind('click').bind('click', function () {

        if ($(this).attr('aria-controls') == "FileUplaod") {
            $("#thumbnailButtons").hide();
        }
        else {
            $("#thumbnailButtons").show();
        }
        $(".ui-tabs-nav .ui-state-default").css({ 'border-width': '0px' });
        $(this).css({ 'border-width': '1px', 'border-bottom-width': '0px' });
    });
    //$("#ImageFromGallery select").css({ 'font-weight': 'normal', 'padding-right': '10px', 'background': '#FFFFFF url(' + SiteImages + 'arrow-down.png) no-repeat 100% center', '-webkit-appearance': 'none', '-moz-appearance': ' none' });
    $('.ui-tabs').css({ 'border': '0px', 'margin': '0px 10px 0px 10px', 'background': 'none', 'background-color': 'transparent' });
    $(".ui-tabs-panel").css({ 'border': '0px', 'border': '1px solid #B2B2B2', 'border-radius': '3px' });
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
    $('div[aria-describedby=ImageFromGallery] .ui-dialog-buttonset .ui-button').css({ 'height': '25px', 'width': '75px', 'margin': '0px auto 0px auto', 'border': '1px solid #808080', 'background': 'none', 'background': ' linear-gradient(#F1F1F1, #F1F1F1,#E1E1E1,#DDDDDD)', 'font-family': ' Verdana, Arial, Helvetica, sans-serif', 'font-size': '11px', 'color': '#450000', 'border-radius': '5px', 'cursor': 'pointer' });

    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
    createFolderStructure(FilesAndFolders, CategoryID);
}


/*END*********************************************************************************************/

function checkforImage(name) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
    $("#" + Control.ObjectID).css({ 'width': parseFloat($("#" + Control.ObjectID + " img").innerWidth()) + 'px', 'height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px', 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
    Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
    Control.Width = parseFloat($("#" + Control.ObjectID).innerWidth()) / mmConvertionConstant;
    Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
    Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.Align);
}


function checkforFile(name) {
    $.ajax({
        url: BackgroundImagesPath + name,
        type: 'HEAD',
        error: function () {
            return false;
        },
        success: function () {
            return true;
        }
    })
}

function swapElements(elm1, elm2) {
    var parent1, next1,
        parent2, next2;

    parent1 = elm1.parentNode;
    next1 = elm1.nextSibling;
    parent2 = elm2.parentNode;
    next2 = elm2.nextSibling;

    parent1.insertBefore(elm2, next1);
    parent2.insertBefore(elm1, next2);
}

function msgBoxDesign() {

    $(".ui-dialog-title").css({ 'width': 'auto' });
    $(".ui-dialog-buttonset").css({ 'margin-right': '0px auto 0px auto', 'width': '100%' });
    $("div[aria-describedby=Message] .ui-widget-header img").remove();
    $("div[aria-describedby=SaveMessage] .ui-widget-header img").remove();
    $("div#SaveMessage").css({ 'text-align': 'center' });

    $("div#SaveMessage div#savemsg").css({ 'margin-left': 'auto', 'margin-right': 'auto', 'margin-top': '0px' });
    $("div[aria-describedby=SaveMessage] .ui-dialog-buttonpane").css({ 'margin-top': '0px', 'padding-bottom': '10px' });
    $("div[aria-describedby=Message] .ui-widget-header").prepend("<img src='StyleSheets/Images/info.png' width='15' height='15' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
    $("div[aria-describedby=SaveMessage] .ui-widget-header").prepend("<img src='StyleSheets/Images/info.png' width='15' height='15' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
    $('.ui-dialog-buttonset .ui-button').css({ 'border': '1px solid #8D8091', 'height': '25px', 'margin': '0px 10px 0px 10px', 'background': 'none', 'background': ' linear-gradient(#FEFEFE, #E6E6E6)', 'font-family': ' Verdana, Arial, Helvetica, sans-serif', 'font-size': '11px', 'color': '#450000', 'border-radius': '5px', 'cursor': 'pointer', 'background-image': 'none' });
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
    $('div[aria-describedby=Message] .ui-dialog-buttonset .ui-button').css({ 'height': '22px', 'width': '75px', 'margin': '0px 20px 0px 10px', 'border': '1px solid #a3a3a3', 'background': 'none', 'background': ' linear-gradient(#E8E8E8,  #F9F8F8)', 'font-family': ' Verdana', 'font-size': '11px', 'color': '#000000', 'border-radius': '5px', 'cursor': 'pointer', 'text-shadow': '0 1px 1px rgba(0,0,0,.3)', 'box-shadow': '0 1px 2px rgba(0,0,0,.2)' });
    $('.ui-dialog-buttonset .ui-button span').css({ 'padding-top': '2px' });
    $('.ui-dialog-buttonset .ui-button').unbind('mouseenter').bind('mouseenter', function () {
        $(this).css({ 'background': ' linear-gradient(#A7D9F5, #EAF6FD)', 'border': '1px #3C7FB1 solid' });
    });
    $('.ui-dialog-buttonset .ui-button').unbind('mouseleave').bind('mouseleave', function () {
        $(this).css({ 'background': ' linear-gradient(#E8E8E8,  #F9F8F8)', 'border': '1px solid #a3a3a3' });
    });

    $("div#SaveMessage").css({ 'height': 'auto', 'min-height': '20px', 'padding-bottom': '20px' });
    $("div[aria-describedby=Message] .ui-dialog-buttonset").css({ 'margin-bottom': '10px' });
}

function loadHorizontalGroupingData() {
    $.ajax({
        url: ServicePath + "HorizontalGroupDetails",
        type: "POST",
        data: JSON.stringify({ Companyid: CompanyID, templateid: TemplateID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (ListHorizontalGroup) {

            HorizontalGroupingData = JSON.parse(JSON.stringify(ListHorizontalGroup.d));
        }
    });
}

function loadVerticalGroupingData() {
    $.ajax({
        url: ServicePath + "VerticalGroupDetails",
        type: "POST",
        data: JSON.stringify({ Companyid: CompanyID, templateid: TemplateID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (ListVerticalGroup) {

            VerticalGroupingData = JSON.parse(JSON.stringify(ListVerticalGroup.d));
        }
    });
}

function deleteAndEditGroupFuction() {
    
    $(".EditGroup").unbind('click').bind('click', function () {
        if ($(this).hasClass('exist')) {
            $("#ManageGroupExistingGroup").dialog('close');
            var arry = $(this).attr('id').split('_');
            if ($(this).hasClass('Vertical')) {
                loadEditGroup("EditGroup", arry[1], "Vertical", "Existing");
            }
            else {
                loadEditGroup("EditGroup", arry[1], "Horizontal", "Existing");
            }
        }
        else {
            $("#QuickAdjustDialog").dialog('close');
            var arry = $(this).attr('id').split('_');
            if ($(this).hasClass('Vertical')) {
                loadEditGroup("EditGroup", arry[1], "Vertical", "QuickAdjst");
            }
            else {
                loadEditGroup("EditGroup", arry[1], "Horizontal", "QuickAdjst");
            }
        }
    });

    $(".DeleteGroup").unbind('click').bind('click', function () {

        if (confirm("Are you sure you want to delete the group? \nThis action cannot be undone.")) {
            if ($(this).hasClass('exist')) {
                $(".loading_new").show();
                var arry = $(this).attr('id').split('_');
                if ($(this).hasClass('Vertical')) {
                    deleteGroup(arry[1], "Vertical", "Existing");
                }
                else {
                    deleteGroup(arry[1], "Horizontal", "Existing");
                }
            }
            else {
                $(".loading_new").show();
                var arry = $(this).attr('id').split('_');
                if ($(this).hasClass('Vertical')) {
                    deleteGroup(arry[1], "Vertical", "QuickAdjst");
                }
                else {
                    deleteGroup(arry[1], "Horizontal", "QuickAdjst");
                }
            }
        }
    });
}

function loadEditGroup(Function, ID, oreintation, GoBack) {
    
    $("#ManageGroupAddGroup").dialog("open");
    var GroupPage, postionX, postionY, spacingBtwnFields, groupAlignMent, groupName;
    if (Function == "EditGroup") {
        $("#ManageGroupAddGroup").dialog({ title: "Edit Group" });
        if (oreintation == "Vertical") {
            $("#rdOreintationVertical").prop('checked', true);
            $("#rdOreintationHorizontal").prop('disabled', true);
            $("#drpFieldMovement").prop('disabled', false);
            $("#rdOreintationVertical").prop('disabled', false);
            for (var i = 0; i < VerticalGroupingData.length; i++) {
                if (VerticalGroupingData[i].GID == ID) {
                    GroupPage = VerticalGroupingData[i].PageNumber;
                    postionX = VerticalGroupingData[i].PositionX;
                    postionY = VerticalGroupingData[i].PositionY;
                    spacingBtwnFields = VerticalGroupingData[i].ControlSpace;
                    groupAlignMent = VerticalGroupingData[i].Alignment;
                    groupName = VerticalGroupingData[i].GroupName;
                    LoadVerticalkeepoption(VerticalGroupingData[i].GrpKeepOption);
                    LoadGroupOption(VerticalGroupingData[i].GroupOption);
                    break;
                }
            }
        }
        else {
           
            $("#rdOreintationHorizontal").prop('disabled', false);
            $("#rdOreintationHorizontal").prop('checked', true);
            $("#rdOreintationVertical").prop('disabled', true);
            $("#drpFieldMovement").prop('disabled', true);
            for (var i = 0; i < HorizontalGroupingData.length; i++) {
                if (HorizontalGroupingData[i].GID == ID) {
                    GroupPage = HorizontalGroupingData[i].PageNumber;
                    postionX = HorizontalGroupingData[i].PositionX;
                    postionY = HorizontalGroupingData[i].PositionY;
                    spacingBtwnFields = HorizontalGroupingData[i].ControlSpace;
                    groupAlignMent = HorizontalGroupingData[i].Alignment;
                    groupName = HorizontalGroupingData[i].GroupName;
                    LoadHorizontalkeepoption(HorizontalGroupingData[i].GrpKeepOption);
                    LoadGroupOption(HorizontalGroupingData[i].GroupOption);
                    break;
                }
            }
        }
    }
    if (Function == "AddGroup") {
        $("#ManageGroupAddGroup").dialog({ title: "Manage Group" });
        $("#rdOreintationVertical").prop('disabled', false);
        $("#rdOreintationHorizontal").prop('disabled', false);
        var count = HorizontalGroupingData.length + VerticalGroupingData.length + 1;
        groupName = "Group" + count;
        GroupPage = parseInt($("#drpPageSelect").val());
        $("#txtGropuName").val(groupName);
        LoadVerticalkeepoption("None");
        LoadGroupOption("None");
        $("#lnkGoback").hide();
        $("#lnkGoback").removeClass();
        $("#txtGroupPostionX").val("0");
        $("#txtGroupPostionY").val("0");
        $("#txtrSpacingBtwnFields").val("0");
        $("#rdGroupLeftAlign").prop('checked', true);
        $("#rdOreintationVertical").prop('checked', true);
        $(".SaveandStayGroup").attr('id', 'btnSaveandStay_' + 0);
        $(".SaveandCloseGroup").attr('id', 'btnSaveandClose_' + 0);
    }
    else if (Function == "EditGroup") {
        $("#txtGropuName").val(groupName);
        $("#txtGroupPostionX").val(postionX);
        $("#txtGroupPostionY").val(postionY);
        $("#txtrSpacingBtwnFields").val(spacingBtwnFields);

        if (groupAlignMent.toLowerCase() == "left") {
            $("#rdGroupLeftAlign").prop('checked', true);
        }
        else if (groupAlignMent.toLowerCase() == "center") {
            $("#rdGroupCentertAlign").prop('checked', true);
        }
        else if (groupAlignMent.toLowerCase() == "right") {
            $("#rdGroupRightAlign").prop('checked', true);
        }

        $(".SaveandStayGroup").attr('id', 'btnSaveandStay_' + ID);
        $(".SaveandCloseGroup").attr('id', 'btnSaveandClose_' + ID);
    }



    var selectedAddID = ""; selectedRemoveID = "";

    pageNumber = parseInt(TemplateDetails.Totalpage);

    $("#drpManageGroupPage").empty();
    for (var i = 1; i <= pageNumber; i++) {
        if (GroupPage == i) {
            $("#drpManageGroupPage").append("<option value='" + i + "' selected>" + i + "</option>");
        }
        else {
            $("#drpManageGroupPage").append("<option value='" + i + "'>" + i + "</option>");
        }
    }

    ControllDetails = sortJSON(ControllDetails, "OrderNumber", "ASC");

    var AvailbaleFieldHtml = "";
    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].Type != "Image" && ControllDetails[i].Lock == true && ControllDetails[i].GroupID == 0 && ControllDetails[i].PageNumber == parseInt($("#drpManageGroupPage").val()) && ControllDetails[i].Visibility == true) {
            AvailbaleFieldHtml += "<div class='AvailbaleFields' id='avl_" + ControllDetails[i].ObjectID + "' style='width:97%;margin:1px 0px 1px 1px;font-family:Segoe UI, Tahoma, Arial;font-size:12px;padding:3px 0px 3px 5px;border:1px solid transparent;cursor:pointer;border-radius:3px;'>" + ControllDetails[i].FieldName + "</div>";
        }
    }
    $("#availbaleFields").html(AvailbaleFieldHtml);
    $("#groupFields").empty();

    if (Function == "EditGroup") {

        if (GoBack != "") {
            $("#lnkGoback").show();
            $("#lnkGoback").removeClass();
            $("#lnkGoback").addClass(GoBack);
        }
        var GroupFieldHtml = "";
        for (var i = 0; i < ControllDetails.length; i++) {
            if (ControllDetails[i].Type != "Image" && ControllDetails[i].Lock == true && ControllDetails[i].GroupID == ID && ControllDetails[i].PageNumber == parseInt($("#drpManageGroupPage").val()) && ControllDetails[i].Visibility == true) {
                GroupFieldHtml += "<div class='GroupFields' id='grp_" + ControllDetails[i].ObjectID + "' style='width:97%;margin:1px 0px 1px 1px;font-family:Segoe UI, Tahoma, Arial;font-size:12px;padding:3px 0px 3px 5px;border:1px solid transparent;background-color:transparent;cursor:pointer;border-radius:3px;'>" + ControllDetails[i].FieldName + "</div>";
            }
        }
        $("#groupFields").append(GroupFieldHtml);
    }




    //$("#ManageGroupAddGroup select").css({ 'background': '#FFFFFF url(' + SiteImages + 'arrow-down.png) no-repeat 100% center', '-webkit-appearance': 'none', '-moz-appearance': ' none' });

    $("#drpManageGroupPage").unbind('change').bind('change', function () {
        var AvailbaleFieldHtmlx = "";
        for (var i = 0; i < ControllDetails.length; i++) {
            if (ControllDetails[i].Type != "Image" && ControllDetails[i].Lock == true && ControllDetails[i].GroupID == 0 && ControllDetails[i].PageNumber == parseInt($("#drpManageGroupPage").val()) && ControllDetails[i].Visibility == true) {
                AvailbaleFieldHtmlx += "<div class='AvailbaleFields' id='avl_" + ControllDetails[i].ObjectID + "' style='width:97%;margin:1px 0px 1px 1px;font-family:Segoe UI, Tahoma, Arial;font-size:12px;padding:3px 0px 3px 5px;border:1px solid transparent;cursor:pointer;border-radius:3px;'>" + ControllDetails[i].FieldName + "</div>";
            }
        }
        $("#availbaleFields").html(AvailbaleFieldHtmlx);
        if (Function == "EditGroup") {
            var GroupFieldHtmlx = "";
            for (var i = 0; i < ControllDetails.length; i++) {
                if (ControllDetails[i].Type != "Image" && ControllDetails[i].Lock == true && ControllDetails[i].GroupID == ID && ControllDetails[i].PageNumber == parseInt($("#drpManageGroupPage").val()) && ControllDetails[i].Visibility == true) {
                    GroupFieldHtmlx += "<div class='GroupFields' id='grp_" + ControllDetails[i].ObjectID + "' style='width:97%;margin:1px 0px 1px 1px;font-family:Segoe UI, Tahoma, Arial;font-size:12px;padding:3px 0px 3px 5px;border:1px solid transparent;background-color:transparent;cursor:pointer;border-radius:3px;'>" + ControllDetails[i].FieldName + "</div>";
                }
            }
            $("#groupFields").html(GroupFieldHtmlx);
        }
        else {
            $("#groupFields").empty();
        }
        AvailblaFieldFunction();
        GroupFieldsFunction();
    });


    $(".SaveandStayGroup").unbind('click').bind('click', function () {
        var id = $(this).attr('id').split('_');
        var groupNamee = $("#txtGropuName").val();
        var groupPositionX = $("#txtGroupPostionX").val();
        var groupPositionY = $("#txtGroupPostionY").val();
        var controllSpace = $("#txtrSpacingBtwnFields").val();
        var groupKeepOption = $("#drpFieldMovement").val();
        var groupOption = $("#drpGroupOption").val();
        var pageNumberr = $("#drpManageGroupPage").val();
        if (groupNamee == "") {
            groupName = groupName;
        }
        if (groupPositionX == "") {
            groupPositionX = 0;
        }
        if (groupPositionY == "") {
            groupPositionY = 0;
        }
        if (controllSpace == "") {
            controllSpace = 0;
        }
        var groupAlign;
        if ($("#rdGroupLeftAlign").prop('checked')) {
            groupAlign = "Left";
        }
        else if ($("#rdGroupCentertAlign").prop('checked')) {
            groupAlign = "Center";
        }
        else if ($("#rdGroupRightAlign").prop('checked')) {
            groupAlign = "Right";
        }

        var oreint;
        if ($("#rdOreintationVertical").prop('checked')) {
            oreint = "Vertical";
        }
        else if ($("#rdOreintationHorizontal").prop('checked')) {
            oreint = "Horizontal";
            groupKeepOption = "None";
        }
        var controllIds = "";
        $("#groupFields").find('div').each(function () {
            controllIds += $(this).attr('id').split('_')[1] + "~";
        });

        var arry = controllIds.split('~');
        if (arry.length < 3) {
            $("#savemsg").html("Please select minimum of two controls to create group");
            $("#SaveMessage").dialog('open');
            msgBoxDesign();
            $("div[aria-describedby=SaveMessage]").css('z-index', '111');
            $(".loadingNewMask").show();
            return false;
        }
        $(".loading_new").show();
        var groupid = id[1];


        $.ajax({
            url: ServicePath + "insertGroup",
            type: "POST",
            data: JSON.stringify({ orentation: oreint, groupname: groupNamee, templateid: TemplateID, companyid: CompanyID, groupid: groupid, keepoption: groupKeepOption, controlspace: controllSpace, positionx: groupPositionX, positiony: groupPositionY, align: groupAlign, pagenumber: pageNumberr, grpOption: groupOption, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (GID) {

                loadGropDataAfterSave(oreint, groupNamee, id[1], groupKeepOption, controllSpace, groupPositionX, groupPositionY, groupAlign, pageNumberr, groupOption, controllIds, GID, true);

            }
        });
    });

    $(".SaveandCloseGroup").unbind('click').bind('click', function () {

        if ($("#txtGroupPostionX").val() == "")
            $(".loading_new").show();
        var id = $(this).attr('id').split('_');
        var groupNamee = $("#txtGropuName").val();
        var groupPositionX = $("#txtGroupPostionX").val();
        var groupPositionY = $("#txtGroupPostionY").val();
        var controllSpace = $("#txtrSpacingBtwnFields").val();
        var groupKeepOption = $("#drpFieldMovement").val();
        var groupOption = $("#drpGroupOption").val();
        var pageNumberr = $("#drpManageGroupPage").val();
        if (groupNamee == "") {
            groupName = groupName;
        }
        if (groupPositionX == "") {
            groupPositionX = 0;
        }
        if (groupPositionY == "") {
            groupPositionY = 0;
        }
        if (controllSpace == "") {
            controllSpace = 0;
        }
        var groupAlign;
        if ($("#rdGroupLeftAlign").prop('checked')) {
            groupAlign = "Left";
        }
        else if ($("#rdGroupCentertAlign").prop('checked')) {
            groupAlign = "Center";
        }
        else if ($("#rdGroupRightAlign").prop('checked')) {
            groupAlign = "Right";
        }

        var oreint;
        if ($("#rdOreintationVertical").prop('checked')) {
            oreint = "Vertical";
        }
        else if ($("#rdOreintationHorizontal").prop('checked')) {
            oreint = "Horizontal";
            groupKeepOption = "None";
        }

        var controllIds = "";
        $("#groupFields").find('div').each(function () {
            controllIds += $(this).attr('id').split('_')[1] + "~";
        });

        var arry = controllIds.split('~');
        if (arry.length < 3) {
            $("#savemsg").html("Please select minimum of two controls to create group");
            $("#SaveMessage").dialog('open');
            msgBoxDesign();
            $("div[aria-describedby=SaveMessage]").css('z-index', '111');
            $(".loadingNewMask").show();
            return false;
        }
        $("#ManageGroupAddGroup").dialog("close");
        $(".loading_new").show();
        var groupid = id[1];

        $.ajax({
            url: ServicePath + "insertGroup",
            type: "POST",
            data: JSON.stringify({ orentation: oreint, groupname: groupNamee, templateid: TemplateID, companyid: CompanyID, groupid: groupid, keepoption: groupKeepOption, controlspace: controllSpace, positionx: groupPositionX, positiony: groupPositionY, align: groupAlign, pagenumber: pageNumberr, grpOption: groupOption, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (GID) {

                loadGropDataAfterSave(oreint, groupNamee, id[1], groupKeepOption, controllSpace, groupPositionX, groupPositionY, groupAlign, pageNumberr, groupOption, controllIds, GID, false);

            }
        });
    });

    AvailblaFieldFunction();
    GroupFieldsFunction();
    $("#rdOreintationHorizontal").unbind('click').bind('click', function () {
        //LoadHorizontalkeepoption("None");
        $("#drpFieldMovement").prop('disabled', true);
    });
    $("#rdOreintationVertical").unbind('click').bind('click', function () {
        $("#drpFieldMovement").prop('disabled', false);
        LoadVerticalkeepoption("None");

    });

    $("#lnkGoback").unbind('click').bind('click', function () {

        $("#ManageGroupAddGroup").dialog("close");
        if ($(this).hasClass('QuickAdjst')) {
            loadQuickAdjust();
        }
        else if ($(this).hasClass('Existing')) {
            loadManageExistingGroup();
        }
    });

    $("#btnAddToGroup").unbind('click').bind('click', function () {

        if (selectedAddID != "") {
            $("#avl_" + selectedAddID).remove();
            var GroupFieldHtml = "";
            $(".AvailbaleFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
            $(".GroupFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
            for (var i = 0; i < ControllDetails.length; i++) {
                if (ControllDetails[i].ObjectID == selectedAddID) {
                    GroupFieldHtml += "<div class='GroupFields' id='grp_" + ControllDetails[i].ObjectID + "' style='width:97%;margin:1px 0px 1px 1px;font-family:Segoe UI, Tahoma, Arial;font-size:12px;padding:3px 0px 3px 5px;border:1px solid #808080;background-color:#CBE6EF;cursor:pointer;border-radius:3px;'>" + ControllDetails[i].FieldName + "</div>";
                    selectedRemoveID = ControllDetails[i].ObjectID;
                    selectedAddID = "";
                }
            }
            $("#groupFields").append(GroupFieldHtml);
            
            GroupFieldsFunction();
            document.getElementById("grp_" + selectedRemoveID).scrollIntoView();
        }
        else {
            
            if ($("#availbaleFields").html() == "") {
                $("#savemsg").html("No available Fields to add");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
                $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                $(".loadingNewMask").show();
                return false;
            }
            else {
                $("#savemsg").html("Please select atleast one item from available Fields");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
                $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                $(".loadingNewMask").show();
                return false;
            }
        }
    });

    $("#btnRemoveFromGroup").unbind('click').bind('click', function () {
        if (selectedRemoveID != "") {
            $("#grp_" + selectedRemoveID).remove();
            var AvailabelFieldHtml = "";
            $(".AvailbaleFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
            $(".GroupFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
            for (var i = 0; i < ControllDetails.length; i++) {
                if (ControllDetails[i].ObjectID == selectedRemoveID) {
                    AvailabelFieldHtml += "<div class='AvailbaleFields' id='avl_" + ControllDetails[i].ObjectID + "' style='width:97%;margin:1px 0px 1px 1px;font-family:Segoe UI, Tahoma, Arial;font-size:12px;padding:3px 0px 3px 5px;border:1px solid #808080;background-color:#CBE6EF;cursor:pointer;border-radius:3px;'>" + ControllDetails[i].FieldName + "</div>";
                    selectedRemoveID = "";
                    selectedAddID = ControllDetails[i].ObjectID;
                }
            }
            $("#availbaleFields").append(AvailabelFieldHtml);
            AvailblaFieldFunction();
            document.getElementById("avl_" + selectedAddID).scrollIntoView();
        }
        else {
            
            if ($("#groupFields").html() == "") {
                $("#savemsg").html("No groped Fields to remove");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
                $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                $(".loadingNewMask").show();
                return false;
            }
            else {
                $("#savemsg").html("Please select atleast one item from grouped Fields");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
                $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                $(".loadingNewMask").show();
                return false;
            }
        }
    });

    function LoadHorizontalkeepoption(selected) {
        var drpFieldmovementHtml = "";

        drpFieldmovementHtml += "<option value='None'";
        if (selected == "None") {
            drpFieldmovementHtml += " selected";
        }
        drpFieldmovementHtml += " >None</option>";
        drpFieldmovementHtml += "<option value='Move Field Left'";
        if (selected == "Move Field Left") {
            drpFieldmovementHtml += " selected";
        }
        drpFieldmovementHtml += " >Move Field Left</option>";
        drpFieldmovementHtml += "<option value='Move Field Right'";
        if (selected == "Move Field Right") {
            drpFieldmovementHtml += " selected";
        }
        drpFieldmovementHtml += " >Move Field Right</option>";

        $("#drpFieldMovement").html(drpFieldmovementHtml);
    }

    function LoadGroupOption(selected) {
        var drpFieldmovementHtml = "";

        drpFieldmovementHtml += "<option value='None'";
        if (selected == "None") {
            drpFieldmovementHtml += " selected";
        }
        drpFieldmovementHtml += " >None</option>";
        drpFieldmovementHtml += "<option value='Move Up'";
        if (selected == "Move Up") {
            drpFieldmovementHtml += " selected";
        }
        drpFieldmovementHtml += " >Move Up</option>";
        drpFieldmovementHtml += "<option value='Move Down'";
        if (selected == "Move Down") {
            drpFieldmovementHtml += " selected";
        }
        drpFieldmovementHtml += " >Move Down</option>";

        $("#drpGroupOption").html(drpFieldmovementHtml);
    }

    function LoadVerticalkeepoption(selected) {
        var drpFieldmovementHtml = "";

        drpFieldmovementHtml += "<option value='None'";
        if (selected == "None") {
            drpFieldmovementHtml += " selected";
        }
        drpFieldmovementHtml += " >None</option>";
        drpFieldmovementHtml += "<option value='Move Field Up'";
        if (selected == "Move Field Up") {
            drpFieldmovementHtml += " selected";
        }
        drpFieldmovementHtml += " >Move Field Up</option>";
        drpFieldmovementHtml += "<option value='Move Field Down'";
        if (selected == "Move Field Down") {
            drpFieldmovementHtml += " selected";
        }
        drpFieldmovementHtml += " >Move Field Down</option>";

        $("#drpFieldMovement").html(drpFieldmovementHtml);
    }

    $("#btnMoveDown").unbind('click').bind('click', function () {

        if (selectedRemoveID != "") {
            if ($("#grp_" + selectedRemoveID).next().get(0).nodeName == 'DIV') {
                var id = $("#grp_" + selectedRemoveID).next().get(0).id;
                swapElements($("#grp_" + selectedRemoveID)[0], $("#" + id)[0]);
            }
        }
        else {
            $("#savemsg").html("Please select atleast one item to process");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
            $("div[aria-describedby=SaveMessage]").css('z-index', '111');
            $(".loadingNewMask").show();
            return false;
        }
    });
    $("#btnMoveUp").unbind('click').bind('click', function () {

        if (selectedRemoveID != "") {
            if ($("#grp_" + selectedRemoveID).prev().get(0).nodeName == 'DIV') {
                var id = $("#grp_" + selectedRemoveID).prev().get(0).id;
                swapElements($("#grp_" + selectedRemoveID)[0], $("#" + id)[0]);
            }
        }
        else {
            $("#savemsg").html("Please select atleast one item to process");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
            $("div[aria-describedby=SaveMessage]").css('z-index', '111');
            $(".loadingNewMask").show();
            return false;
        }
    });
    $("div[aria-describedby=ManageGroupAddGroup] .ui-widget-header img").remove();
    $("div[aria-describedby=ManageGroupAddGroup] .ui-widget-header").prepend("<img src='StyleSheets/Images/stock_group.png' width='15' height='15' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });


    function AvailblaFieldFunction() {
        $(".AvailbaleFields").unbind('mouseenter').bind('mouseenter', function () {
            if ($(this).css('border-left-color') == "transparent") {
                $(this).css({ 'background-color': '#CBE6EF' });
            }
            if ($(this).css('borderColor') == "rgba(0, 0, 0, 0)") {
                $(this).css({ 'background-color': '#CBE6EF' });
            }
        });
        $(".AvailbaleFields").unbind('mouseleave').bind('mouseleave', function () {
            if ($(this).css('border-left-color') == "transparent") {
                $(this).css({ 'background-color': 'transparent' });
            }
            if ($(this).css('borderColor') == "rgba(0, 0, 0, 0)") {
                $(this).css({ 'background-color': 'transparent' });
            }
        });
        $(".AvailbaleFields").unbind('click').bind('click', function () {
            $(".AvailbaleFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
            $(".GroupFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
            $(this).css({ 'border': '1px solid #808080', 'background-color': '#CBE6EF' });
            var arry = $(this).attr('id').split('_');

            selectedAddID = arry[1];
            selectedRemoveID = "";
        });
    }

    function GroupFieldsFunction() {
        $(".GroupFields").unbind('mouseenter').bind('mouseenter', function () {
            if ($(this).css('border-left-color') == "transparent") {
                $(this).css({ 'background-color': '#CBE6EF' });
            }
            if ($(this).css('borderColor') == "rgba(0, 0, 0, 0)") {
                $(this).css({ 'background-color': '#CBE6EF' });
            }
        });
        $(".GroupFields").unbind('mouseleave').bind('mouseleave', function () {
            if ($(this).css('border-left-color') == "transparent") {
                $(this).css({ 'background-color': 'transparent' });
            }
            if ($(this).css('borderColor') == "rgba(0, 0, 0, 0)") {
                $(this).css({ 'background-color': 'transparent' });
            }
        });
        $(".GroupFields").unbind('click').bind('click', function () {

            $(".AvailbaleFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
            $(".GroupFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
            $(this).css({ 'border': '1px solid #808080', 'background-color': '#CBE6EF' });
            var arry = $(this).attr('id').split('_');
            selectedRemoveID = arry[1];
            selectedAddID = "";
        });
    }
}

function loadQuickAdjust() {
    $("#QuickAdjustDialog").dialog("open");
    $("#QuickAdjustDialogTable").empty();
    loadDynamicQuickAdjust();
}
function loadDynamicQuickAdjust() {
    $("#loadingquickadjust").show();
    var QuickAdjustHtml = "";

    QuickAdjustHtml += "<tr style='background-color: #D8D8D8;table-layout: fixed;' class='Heading'><td>Type</td><td>Field Name</td><td>Page</td><td>X-Position</td><td>Y-Position</td><td>Width</td>";
    QuickAdjustHtml += "<td>Font Name</td><td>Color</td><td>Orientation</td><td >Field Movement Options</td><td style='text-align:center;' class='actions'>Action</td></tr>";

    QuickAdjustHtml += "<tr><td style='padding-top:10px;'>";

    for (var i = 1; i <= TemplateDetails.Totalpage; i++) {
        QuickAdjustHtml = bindQuickAdjust(QuickAdjustHtml, i);
    }

    QuickAdjustHtml += "</td ></tr></table>";

    $("#QuickAdjustDialogTable").html(QuickAdjustHtml);
    deleteAndEditGroupFuction();
    loadDesignogQuickAdjust();
    loadFontDropDownOfQuickAdjust();
    designPoups();
    $("#loadingquickadjust").hide();
}

function designPoups() {
    $(".ui-dialog-titlebar-close").css({ 'background': 'none', 'background-color': 'transparent', 'border-color': 'transparent' });
    $(".ui-dialog-titlebar-close span").css({ 'position': 'absolute' });
    $("div[aria-describedby=QuickAdjustDialog] .ui-widget-header img").remove();
    $("div[aria-describedby=QuickAdjustDialog] .ui-widget-header").prepend("<img src='StyleSheets/Images/quickadjust.png' class='popupicon' />");
    $("div[aria-describedby=Imageeditor] .ui-widget-header img").remove();
    $("div[aria-describedby=Imageeditor] .ui-widget-header").prepend("<img src='StyleSheets/Images/addimg.jpg' class='popupicon' />");
    $("div[aria-describedby=Message] .ui-widget-header img").remove();
    $("div[aria-describedby=Message] .ui-widget-header").prepend("<img src='StyleSheets/Images/info.png' class='popupicon' />");
    $(".ui-widget-header").css({ 'border-bottom': '1px solid white' });
    $("#ImageFromGallery,#ManageGroupAddGroup,#ManageGroupNogroup,#ManageGroupExistingGroup,#CreateCategory,#EditCategory,#ImageDetails,#UploadImage").css({ 'margin-bottom': '5px', 'border-bottom-width': '1px', 'padding': '10px 0px 0px 0px' });
    $("div[aria-describedby=QuickAdjustDialog] .ui-dialog-buttonpane").css({ 'text-align': 'center' });
    $("div[aria-describedby=QuickAdjustDialog] .ui-dialog-buttonpane").css({ 'text-align': 'center' });
}

function loadManageExistingGroup() {

    $("#ManageGroupExistingGroup").dialog("open");
    var ExistingGroupsHtml = "<tr style='background-color:#D8D8D8;font-size: 11px; font-family: Verdana;' class='Heading'><td ><span style='margin-left:5px;'>Type</span></td><td>Control Name</td><td>Page</td><td>X-Position</td><td>Y-Position</td><td>Field Movement Options</td><td>Font Style</td><td>Color</td><td style='text-align:center;' class='actions'>Action</td></tr>";
    if (VerticalGroupingData.length > 0) {

        for (var i = 0; i < VerticalGroupingData.length; i++) {
            ExistingGroupsHtml += "<tr class='GroupcontentTr' style='border:1px solid transparent;'>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'><div style='padding:10px 0px 0px 5px;font-family:verdana;font-size:11px;height:20px;'>Vertical Group<div></td>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'><div style='font-family:verdana;font-size:11px;height:20px;padding:10px 0px 0px 0px;'>" + VerticalGroupingData[i].GroupName + "</div></td>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'>";
            ExistingGroupsHtml += "<select style='font-family:verdana;font-size:11px;width:50px;height:20px;'>";
            ExistingGroupsHtml += "<option selected>" + VerticalGroupingData[i].PageNumber + "</option>";
            ExistingGroupsHtml += "</select></td>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'><input style='font-family:verdana;font-size:11px;width:75px;' type='text' value='" + VerticalGroupingData[i].PositionX + "' /></td>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'><input style='font-family:verdana;font-size:11px;width:75px;' type='text' value='" + VerticalGroupingData[i].PositionY + "' /></td>";
            ExistingGroupsHtml += "<td><select style='font-family:verdana;font-size:11px;width:150px;height:20px;'>";
            ExistingGroupsHtml += "<option selected>" + VerticalGroupingData[i].GrpKeepOption + "</option>";
            ExistingGroupsHtml += "</select></td>";
            ExistingGroupsHtml += "<td><select style='width:125px;height:20px;font-family:verdana;font-size:11px;'>";
            ExistingGroupsHtml += "</select></td>";
            ExistingGroupsHtml += "<td><div style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
            ExistingGroupsHtml += "<td style='text-align:center;' class='actions'><img class='image EditGroup exist Vertical' title='Edit Group' src='StyleSheets/Images/edit-icon.png'  id='btnEditGroup_" + VerticalGroupingData[i].GID + "' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:1px solid transparent;border-radius: 10px;padding:2px;' /><img class='image DeleteGroup exist Vertical' id='btnDeleteGrp_" + VerticalGroupingData[i].GID + "' title='Delete Group' src='StyleSheets/Images/cross.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:2px solid transparent;border-radius: 10px;padding:2px;' /></td>";
        }
    }
    if (HorizontalGroupingData.length > 0) {
        for (var i = 0; i < HorizontalGroupingData.length; i++) {

            ExistingGroupsHtml += "<tr class='GroupcontentTr' style='border:1px solid transparent;'>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'><div style='font-family:verdana;font-size:11px;padding:10px 0px 0px 5px;height:20px;'>Horizontal Group<div></td>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'><div style='font-family:verdana;font-size:11px;height:20px;padding:10px 0px 0px 0px;'>" + HorizontalGroupingData[i].GroupName + "</div></td>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'>";
            ExistingGroupsHtml += "<select style='font-family:verdana;font-size:11px;height:20px;width:50px;height:20px;'>";
            ExistingGroupsHtml += "<option selected>" + HorizontalGroupingData[i].PageNumber + "</option>";
            ExistingGroupsHtml += "</select></td>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'><input type='text' style='font-family:verdana;font-size:11px;height:15px;width:75px;' value='" + HorizontalGroupingData[i].PositionX + "' /></td>";
            ExistingGroupsHtml += "<td class='GroupcontentTd'><input type='text' style='font-family:verdana;font-size:11px;height:15px;width:75px;' value='" + HorizontalGroupingData[i].PositionY + "' /></td>";
            ExistingGroupsHtml += "<td><select style='width:150px;height:20px;font-family:verdana;font-size:11px;'>";
            ExistingGroupsHtml += "<option selected>" + HorizontalGroupingData[i].GrpKeepOption + "</option>";
            ExistingGroupsHtml += "</select></td>";
            ExistingGroupsHtml += "<td><select style='width:125px;height:20px;font-family:verdana;font-size:11px;'>";
            ExistingGroupsHtml += "</select></td>";
            ExistingGroupsHtml += "<td><div style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
            ExistingGroupsHtml += "<td style='text-align:center;' class='actions'><img class='image EditGroup exist Horizontal' title='Edit Group' src='StyleSheets/Images/edit-icon.png' id='btnEditGroup_" + HorizontalGroupingData[i].GID + "' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:1px solid transparent;border-radius: 10px;padding:2px;' /><img id='btnDeleteGrp_" + HorizontalGroupingData[i].GID + "' class='image exist DeleteGroup Horizontal' title='Delete Group' src='StyleSheets/Images/cross.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:2px solid transparent;border-radius: 10px;padding:2px;' /></tr>";
        }
    }
    $("#ManageGroupExistingGroupTable").html(ExistingGroupsHtml);
    $("div[aria-describedby=ManageGroupExistingGroup] .ui-widget-header img").remove();
    $("div[aria-describedby=ManageGroupExistingGroup] .ui-widget-header").prepend("<img src='StyleSheets/Images/stock_group.png' width='15' height='15' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
    $(".Heading td").css({ 'padding': '3px 10px 3px 1px', 'margin': '0px 0px 0px 0px', 'font-size': '11px', 'font-family': 'verdana', 'border': '0px solid transparent', 'padding-right': '40px' });
    $("#ManageGroupExistingGroupTable input").prop('disabled', true);

    $("#ManageGroupExistingGroupTable select").prop('disabled', true);
    //$("#ManageGroupExistingGroup select").css({ 'background': '#FFFFFF url(' + SiteImages + 'arrow-down.png) no-repeat 100% center', '-webkit-appearance': 'none', '-moz-appearance': ' none' });
    //$("#ManageGroupExistingGroupTable select").css({ 'background-color': '#EBEBE4', 'background-image': 'url(none)' });
    $("#ManageGroupExistingGroupTable .image").unbind('mouseenter').bind('mouseenter', function () {
        $(this).css({ 'border': '1px solid #000000' });
    });
    $("#ManageGroupExistingGroupTable .image").unbind('mouseleave').bind('mouseleave', function () {
        $(this).css({ 'border': '1px solid transparent' });
    });
    $(".GroupcontentTr td").css({ 'padding-right': '40px' });
    $("td.actions").css({ 'padding-right': '5px' });
    $(".ui-dialog-buttonset").css({ 'width': 'auto' });

    deleteAndEditGroupFuction();
}

function loadNoGroup() {
    $("#ManageGroupNogroup").dialog("open");
    $("div[aria-describedby=ManageGroupNogroup] .ui-widget-header img").remove();
    $("div[aria-describedby=ManageGroupNogroup] .ui-widget-header").prepend("<img src='StyleSheets/Images/stock_group.png' width='15' height='15' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });

    $("#rdOreintationHorizontal").unbind('click').bind('click', function () {
        if ($(this).prop('checked')) {
            $("#drpFieldMovement").prop('disabled', true);
        }
    });
    $("#rdOreintationVertical").unbind('click').bind('click', function () {
        if ($(this).prop('checked')) {
            $("#drpFieldMovement").prop('disabled', false);
        }
    });
}



/*Added By salim*/
function CopyExistingTemplate(selectedtid) {
    $.ajax({
        url: ServicePath + "CopyTemplateWithProperties",
        type: "POST",
        data: JSON.stringify({ copiedtemplateid: selectedtid, currenttemplateid: TemplateID, userid: UserID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (ID) {

            GetIDforNewProd = JSON.stringify(ID.d);
            location.reload();
        }
    });
}

/*Added By salim*/
function ResetAllControls(PageNumber) {
    $.ajax({
        url: ServicePath + "ResetAllControls",
        type: "POST",
        data: JSON.stringify({ templateid: TemplateID, companyid: CompanyID, _pagenumber: PageNumber, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            resetall = JSON.stringify(result.d);

            $(".invalid").hide();
            $(".TextBlock").hide();
            $(".ParaGraph").hide();
            $(".ImagePanel").hide();
            $(".InformationPanel").hide();
            $(".LayoutPanel").hide();
            $(".FontPanel").hide();
            $(".ColorPanel").hide();
            $(".DefaultContentPanel").hide();
            $(".LabelPanel").hide();
            $(".PropertiesPanel").hide();
            clearAccordin();
            $(".SaveTemplatePanel").trigger('click');

            loadVerticalGroupingData();
            loadHorizontalGroupingData();

        }
    });
}

function capitalizeTheText(DefaultContent, Capitalize) {
    var defaultContent = "";
    if (Capitalize == "User Input") {
        defaultContent = DefaultContent;
    }
    else if (Capitalize == "All Caps") {
        defaultContent = DefaultContent.toUpperCase();
    }
    else if (Capitalize == "InitCap") {
        var firstLetter = DefaultContent.substr(0, 1).toUpperCase();
        var remaingString = DefaultContent.substr(1, DefaultContent.length - 1).toLowerCase();
        defaultContent = firstLetter + remaingString;
    }
    else if (Capitalize == "First Cap") {
        var Words = DefaultContent.split(" ");
        for (var i = 0; i < Words.length; i++) {
            if (Words[i] != "") {
                var firstLetter = Words[i][0].toUpperCase();
                var remaingString = Words[i].substr(1, Words[i].length - 1).toLowerCase();
                if (i != Words.length - 1) {
                    defaultContent += firstLetter + remaingString + " ";
                }
                else {
                    defaultContent += firstLetter + remaingString;
                }
            }
        }
    }
    else {
        defaultContent = DefaultContent.toLowerCase();
    }

    defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt");
    defaultContent = defaultContent;
    defaultContent = defaultContent;
    return defaultContent;
}



function Guid() {
    var d = new Date().getTime();
    var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = (d + Math.random() * 16) % 16 | 0;
        d = Math.floor(d / 16);
        return (c == 'x' ? r : (r & 0x7 | 0x8)).toString(16);
    });

    return uuid.substring(0, 10);
}

function deleteGroup(ID, oreintation, GoBack) {
    
    if (oreintation == "Vertical") {
        $.ajax({
            url: ServicePath + "DeleteVerticalGroup",
            type: "POST",
            data: JSON.stringify({ templateid: TemplateID, grpid: ID, companyid: CompanyID, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (VerticalGroupDetails) {
                VerticalGroupingData = JSON.parse(JSON.stringify(VerticalGroupDetails.d));
                for (var i = 0; i < ControllDetails.length; i++) {
                    if (ControllDetails[i].GroupID == parseInt(ID)) {
                        ControllDetails[i].GroupID = 0;
                        ControllDetails[i].KeepOption = "None";
                        ControllDetails[i].GroupOrientation = "None";
                    }
                }
                UpadteTemplteDetails(false, false);
                if (GoBack == "Existing") {
                    $("#ManageGroupExistingGroup").dialog('close');
                    if (VerticalGroupingData.length > 0 || HorizontalGroupingData.length > 0) {
                        loadManageExistingGroup();
                    }
                    else {
                        loadNoGroup();
                    }
                    $(".loading_new").hide();

                    $("#savemsg").html("Group succesfully deleted!");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                    $(".loadingNewMask").show();
                }
                else {
                    $("#QuickAdjustDialog").dialog('close');
                    loadQuickAdjust();
                    $(".loading_new").hide();

                    $("#savemsg").html("Group succesfully deleted!");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                    $(".loadingNewMask").show();
                }
            }
        });
    }
    else {
        $.ajax({
            url: ServicePath + "DeleteHorizontalGroup",
            type: "POST",
            data: JSON.stringify({ templateid: TemplateID, grpid: ID, companyid: CompanyID, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (HorizontalGroupDetails) {
                HorizontalGroupingData = JSON.parse(JSON.stringify(HorizontalGroupDetails.d));
                for (var i = 0; i < ControllDetails.length; i++) {
                    if (ControllDetails[i].GroupID == parseInt(ID)) {
                        ControllDetails[i].GroupID = 0;
                        ControllDetails[i].KeepOption = "None";
                        ControllDetails[i].GroupOrientation = "None";
                    }
                }
                UpadteTemplteDetails(false, false);
                if (GoBack == "Existing") {
                    $("#ManageGroupExistingGroup").dialog('close');
                    if (VerticalGroupingData.length > 0 || HorizontalGroupingData.length > 0) {
                        loadManageExistingGroup();
                    }
                    else {
                        loadNoGroup();
                    }
                    $(".loading_new").hide();

                    $("#savemsg").html("Group succesfully deleted!");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                    $(".loadingNewMask").show();
                }
                else {
                    $("#QuickAdjustDialog").dialog('close');
                    loadQuickAdjust();
                    $(".loading_new").hide();

                    $("#savemsg").html("Group succesfully deleted!");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                    $(".loadingNewMask").show();
                }
            }
        });
    }
}

function loadGropDataAfterSave(oreint, groupName, groupid, groupKeepOption, controllSpace, groupPositionX, groupPositionY, groupAlign, pageNumberr, groupOption, controllIds, GID, saveAdndStay) {


    var arry = controllIds.split('~');
    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].GroupID == parseInt(GID.d)) {
            var notfound = true;
            for (var j = 0; j < arry.length - 1; j++) {
                if (ControllDetails[i].ObjectID == arry[j]) {
                    notfound = true;
                    break;
                }
            }
            if (notfound) {
                ControllDetails[i].GroupID = parseInt(0);
                ControllDetails[i].KeepOption = "None";
                ControllDetails[i].GroupOrientation = "None";
            }
        }
    }
    for (var i = 0; i < ControllDetails.length; i++) {
        for (var j = 0; j < arry.length - 1; j++) {
            if (ControllDetails[i].ObjectID == arry[j]) {
                if (groupid != "0") {
                    ControllDetails[i].GroupID = parseInt(groupid);
                }
                else {
                    ControllDetails[i].GroupID = parseInt(GID.d);
                }
                ControllDetails[i].KeepOption = groupKeepOption;
                ControllDetails[i].GroupOrientation = oreint;
                ControllDetails[i].PageNumber = pageNumberr;
            }
        }
    }


    UpadteTemplteDetails(false, false);

    if (groupid != GID.d) {
        var jsonString = JSON.parse(JSON.stringify({
            "GID": parseInt(GID.d),
            "TemplateID": TemplateDetails.TemplateID,
            "CompanyID": TemplateDetails.CompanyID,
            "GroupName": groupName,
            "GrpKeepOption": groupKeepOption,
            "Alignment": groupAlign,
            "ControlSpace": parseFloat(controllSpace),
            "PositionX": parseFloat(groupPositionX),
            "PositionY": parseFloat(groupPositionY),
            "PageNumber": parseInt(pageNumberr),
            "GroupOption": groupOption
        }));
        if (oreint == "Vertical") {
            VerticalGroupingData.push(jsonString);
        }
        else {
            HorizontalGroupingData.push(jsonString);
        }

    }
    else {
        if (oreint == "Vertical") {
            for (i = 0; i < VerticalGroupingData.length; i++) {
                if (VerticalGroupingData[i].GID == parseInt(GID.d)) {
                    VerticalGroupingData[i].GroupName = groupName;
                    VerticalGroupingData[i].GrpKeepOption = groupKeepOption;
                    VerticalGroupingData[i].Alignment = groupAlign;
                    VerticalGroupingData[i].ControlSpace = parseFloat(controllSpace);
                    VerticalGroupingData[i].PositionX = parseFloat(groupPositionX);
                    VerticalGroupingData[i].PositionY = parseFloat(groupPositionY);
                    VerticalGroupingData[i].PageNumber = parseInt(pageNumberr);
                    VerticalGroupingData[i].GroupOption = groupOption;
                    break;
                }
            }
        }
        else if (oreint == "Horizontal") {
            for (i = 0; i < HorizontalGroupingData.length; i++) {
                if (HorizontalGroupingData[i].GID == parseInt(GID.d)) {
                    HorizontalGroupingData[i].GroupName = groupName;
                    HorizontalGroupingData[i].GrpKeepOption = groupKeepOption;
                    HorizontalGroupingData[i].Alignment = groupAlign;
                    HorizontalGroupingData[i].ControlSpace = parseFloat(controllSpace);
                    HorizontalGroupingData[i].PositionX = parseFloat(groupPositionX);
                    HorizontalGroupingData[i].PositionY = parseFloat(groupPositionY);
                    HorizontalGroupingData[i].PageNumber = parseInt(pageNumberr);
                    HorizontalGroupingData[i].GroupOption = groupOption;
                    break;
                }
            }
        }
    }
    if (saveAdndStay) {
        $(".SaveandStayGroup").attr('id', 'btnSaveandStay_' + GID.d);
        $(".SaveandCloseGroup").attr('id', 'btnSaveandClose_' + GID.d);

        $("#savemsg").html("Changes saved!");
        $("#SaveMessage").dialog("open");
        msgBoxDesign();
        $("div[aria-describedby=SaveMessage]").css('z-index', '111');
        $(".loadingNewMask").show();
    }
    changeThePageFromDropDown($("#drpPageSelect").val());
}

function loadCategorydropdowns(categoryID) {
    $("#drpSelectCategory").empty();
    $("#drpForCreateCategory").empty();
    for (var i = 0; i < CategoryBindingList.length; i++) {
        if (categoryID == CategoryBindingList[i].CategoryID) {
            $("#drpSelectCategory").append("<option value='" + CategoryBindingList[i].CategoryID + "' id='drpSelectCate" + CategoryBindingList[i].CategoryID + "' selected>" + CategoryBindingList[i].MultiLevelCategory + "</option>");
        }
        else {
            $("#drpSelectCategory").append("<option value='" + CategoryBindingList[i].CategoryID + "' id='drpSelectCate" + CategoryBindingList[i].CategoryID + "'>" + CategoryBindingList[i].MultiLevelCategory + "</option>");
        }
        $("#drpForCreateCategory").append("<option value='" + CategoryBindingList[i].CategoryID + "' id='drpSelectCate" + CategoryBindingList[i].CategoryID + "'>" + CategoryBindingList[i].MultiLevelCategory + "</option>");
    }
}

function loadCategorydropdownsforEdit(categoryID) {
    $("#drpCategoryForImage").empty();
    for (var i = 0; i < CategoryBindingList.length; i++) {
        if (categoryID == CategoryBindingList[i].CategoryID) {
            $("#drpCategoryForImage").append("<option value='" + CategoryBindingList[i].CategoryID + "' id='drpSelectCate" + CategoryBindingList[i].CategoryID + "' selected>" + CategoryBindingList[i].MultiLevelCategory + "</option>");
        }
        else {
            $("#drpCategoryForImage").append("<option value='" + CategoryBindingList[i].CategoryID + "' id='drpSelectCate" + CategoryBindingList[i].CategoryID + "'>" + CategoryBindingList[i].MultiLevelCategory + "</option>");
        }
    }
}

function loadFolderAndFilesBycategory(path, CategoryID, id) {
    $.ajax({
        url: ServicePath + "GetSystemGalleryFoldersandFiles",
        type: "POST",
        data: JSON.stringify({ companyid: CompanyID, categoryid: CategoryID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (folderAndFiles) {

            var FolderAndFiles = JSON.parse(JSON.stringify(folderAndFiles.d));

            $.ajax({
                url: ServicePath + "GetImageGalleryAssignment",
                type: "POST",
                data: JSON.stringify({ companyid: CompanyID, templateid: TemplateID, objectid: selectedObjectID, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (assignedFilesAndFolders) {
                    AssignedFilesAndFolders = JSON.parse(JSON.stringify(assignedFilesAndFolders.d));
                    if (path == "fromlink") {
                        openGallery(FolderAndFiles, CategoryID);
                    }
                    else if (path == "editimage") {
                        editImageDetails(FolderAndFiles, id);
                    }
                    else {
                        createFolderStructure(FolderAndFiles, CategoryID);
                    }
                }
            });
        }
    });
}

function createFolderStructure(FolderAndFiles, catid) {

    var thumnailHtml = "";
    var editcategory = false;
    $("#thumNail").empty();
    $(".loading_gallery").hide();
    if (FolderAndFiles.ImageCategories.length == 0 && FolderAndFiles.ImageGallery.length == 0) {
        thumnailHtml += "<span style='font-family:verdana;font-size:11px;font-weight:bold;'>There is No Images in this Gallery</span>";
        $("#btnSelectAll").hide();
        $("#btnDeletetAll").hide();
        $("#btnSaveImage").hide();
        $("#btnSaveImage").after("<span class='helper'>&nbsp;</span>");
    }
    else {
        $("#btnSelectAll").show();
        $("#btnDeletetAll").show();
        $("#btnSaveImage").show();
        $(".helper").remove();
        $("#Gallery").css({ 'padding-bottom': '10px' });

        for (var i = 0; i < FolderAndFiles.ImageCategories.length; i++) {

            thumnailHtml += "<span style='margin:10px 20px 8px 15px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;' ><div id='cat_" + FolderAndFiles.ImageCategories[i].CategoryID + "' class='folder HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
            thumnailHtml += "<input type='checkbox' title='Delete' id='chkFolderSelect_" + FolderAndFiles.ImageCategories[i].CategoryID + "' class='FolderSelectChk' style='margin-bottom:0px;position:absolute;top:0px;left:0px;' />";
            thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;'   src='" + SiteImages + "folder_imgnew5.png' /></div>";
            thumnailHtml += "<div id='editdelete_" + FolderAndFiles.ImageCategories[i].CategoryID + "' style='position:absolute;bottom:0px;left:0px;width:100%;height:20px;cursor:default;padding-top:1px;background-color:#797979;border-bottom-left-radius:1px;border-bottom-right-radius:1px;display:none;'><span class='EditCategory EditDeleteFileFolder' id='editCat_" + FolderAndFiles.ImageCategories[i].CategoryID + "' style='float:left;margin-left:10px;margin-top:2px;'>Edit</span><span class='EditDeleteFileFolder DeleteCategory' id='deleteCategory_" + FolderAndFiles.ImageCategories[i].CategoryID + "' style='float:right;margin-right:10px;margin-top:2px;'>Delete</span></div></div>";
            thumnailHtml += "<div><pre style='margin:0px;float:left;'><input style='margin-top:1px;margin-bottom:3px;vertical-align:middle;' type='checkbox' id='chkFolderAssgin_" + FolderAndFiles.ImageCategories[i].CategoryID + "' class='FolderAssginChk' title='Assign'";

            for (var k = 0; k < AssignedFilesAndFolders.length; k++) {
                if (AssignedFilesAndFolders[k].Type == "c" && AssignedFilesAndFolders[k].TypeID == FolderAndFiles.ImageCategories[i].CategoryID) {
                    thumnailHtml += " checked='checked' ";
                }
            }
            for (var k = 0; k < AssignedFilesAndFolders.length; k++) {
                if (AssignedFilesAndFolders[k].Type == "c" && AssignedFilesAndFolders[k].TypeID == parseInt(catid)) {
                    thumnailHtml += " checked='checked' disabled='disabled'";

                }
            }

            thumnailHtml += "/><label for='chkFolderAssgin_" + FolderAndFiles.ImageCategories[i].CategoryID + "' style='font-size:11px;font-family:verdana;padding-top:5px;' title='" + FolderAndFiles.ImageCategories[i].CategoryName + "'>";
            var FolderName = FolderAndFiles.ImageCategories[i].CategoryName;
            if (FolderAndFiles.ImageCategories[i].CategoryName.length > 12) {
                FolderName = FolderName.substr(0, 12) + "...";
            }
            thumnailHtml += FolderName + "</label></pre></div><div style='width:120px;height:20px;'></div></div></span>";
        }
        for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {
            thumnailHtml += "<span style='margin:10px 20px 8px 15px;display:inline-block;width:120px;vertical-align:top;Position:relative;'><div id='file_" + FolderAndFiles.ImageGallery[i].ImageID + "' class='file HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
            thumnailHtml += "<input type='checkbox' title='Delete' id='chkFileSelect_" + FolderAndFiles.ImageGallery[i].ImageID + "' class='FileSelectChk' style='margin-bottom:0px;position:absolute;top:0px;left:0px;'  />";
            thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;' src='";
            if (FolderAndFiles.ImageGallery[i].FileName.split('.')[1].toLowerCase() == "pdf") {
                thumnailHtml += SiteImages + "/processing.png'";
            }
            else {
                thumnailHtml += BackgroundImagesPath + "Gallery/ThumbnailImages/t_" + FolderAndFiles.ImageGallery[i].FileName + "'";
            }
            thumnailHtml += "/></div>";
            thumnailHtml += "<div id='editdelete_" + FolderAndFiles.ImageGallery[i].ImageID + "' style='position:absolute;width:100%;bottom:0px;left:0px;height:20px;cursor:default;padding-top:1px;background-color:#797979;border-bottom-left-radius:1px;border-bottom-right-radius:1px;display:none;'><span class='EditDeleteFileFolder EditFile' id='editFile_" + FolderAndFiles.ImageGallery[i].ImageID + "' style='float:left;margin-left:10px;margin-top:2px;'>Edit</span><span class='EditDeleteFileFolder DeleteFile' style='float:right;margin-right:10px;margin-top:2px;' id='deleteFile_" + FolderAndFiles.ImageGallery[i].ImageID + "'>Delete</span></div></div>";
            thumnailHtml += "<div><pre style='margin:0px;float:left;'><input style='margin-top:1px;margin-bottom:3px;vertical-align:middle;' type='checkbox' id='chkFileAssgin_" + FolderAndFiles.ImageGallery[i].ImageID + "' class='FileAssginChk' title='Assign'"
            for (var k = 0; k < AssignedFilesAndFolders.length; k++) {

                if (AssignedFilesAndFolders[k].Type == "f" && AssignedFilesAndFolders[k].TypeID == FolderAndFiles.ImageGallery[i].ImageID) {
                    thumnailHtml += " checked='checked' ";
                }
            }
            for (var k = 0; k < AssignedFilesAndFolders.length; k++) {
                if (AssignedFilesAndFolders[k].Type == "c" && AssignedFilesAndFolders[k].TypeID == parseInt(catid)) {
                    thumnailHtml += " checked='checked' disabled='disabled'";
                }
            }
            thumnailHtml += "/><label for='chkFileAssgin_" + FolderAndFiles.ImageGallery[i].ImageID + "' style='font-size:11px;font-family:verdana;padding-top:5px;' title='" + FolderAndFiles.ImageGallery[i].OriginalFileName + "'>";
            var FileName = FolderAndFiles.ImageGallery[i].OriginalFileName;
            if (FolderAndFiles.ImageGallery[i].OriginalFileName.length > 12) {
                FileName = FileName.substr(0, 12) + "...";
            }
            thumnailHtml += FileName + "</label></pre></div><br><pre style='margin:0px;float:left;'><input style='margin-top:0px;margin-bottom:3px;vertical-align:middle;' type='radio' name='setAsDefault' title='Set as default' id='rdSetDefault_" + FolderAndFiles.ImageGallery[i].ImageID + "' class='SetAsDefault'";
            for (var k = 0; k < AssignedFilesAndFolders.length; k++) {
                if (AssignedFilesAndFolders[k].Type == "f" && AssignedFilesAndFolders[k].TypeID == FolderAndFiles.ImageGallery[i].ImageID && AssignedFilesAndFolders[k].IsDefault == true) {
                    thumnailHtml += " checked ";
                }
            }
            thumnailHtml += "/><label style='font-size:11px;font-family:verdana;' for='rdSetDefault_" + FolderAndFiles.ImageGallery[i].ImageID + "'>Set As Default</label></pre></div></span>";
        }
    }
    $("#Gallery").css({ 'padding': '0px 0px 10px 0px' });
    $("#thumNail").html(thumnailHtml);
    if (FolderAndFiles.ParentID == -1) {
        $('#btnShowMore').show();
        $(".btnBack").hide();
        $(".txtSearchText").attr('id', 'SearchText_0');
    }
    else {
        $('#btnShowMore').hide();
        $(".btnBack").show();
        $(".btnBack").attr('id', 'brnBack_' + FolderAndFiles.ParentID);
        $(".txtSearchText").attr('id', 'SearchText_' + catid);
    }

    $(".loading_gallery").hide();
    $(".HoverFunction").unbind('mouseenter').bind('mouseenter', function () {
        $("#editdelete_" + $(this).attr('id').split('_')[1]).show();
    });
    $(".HoverFunction").unbind('mouseleave').bind('mouseleave', function () {
        $("#editdelete_" + $(this).attr('id').split('_')[1]).hide();
    });


    $(".SetAsDefault").click(function () {
        if ($(this).prop('checked')) {
            var id = $(this).attr('id').split('_')[1];
            $("#chkFileAssgin_" + id).prop('checked', true);
            $.ajax({
                url: ServicePath + "Insert_ImageGalleryAssignment_Onclick",
                type: "POST",
                data: JSON.stringify({ objectid: selectedObjectID, companyid: CompanyID, templateid: TemplateID, userid: UserID, type: "f", typeid: id, isdefault: true, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function () {
                    var zoom = parseInt(parseFloat(zoomvalue()) * 100);
                    var width;
                    var height, fileName;
                    var objectid = selectedObjectID;

                    var Control;
                    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


                    width = parseInt(Control.Width * mmConvertionConstant);
                    height = parseInt(Control.Height * mmConvertionConstant);


                    for (var k = 0; k < FolderAndFiles.ImageGallery.length; k++) {
                        if (FolderAndFiles.ImageGallery[k].ImageID == parseInt(id)) {
                            fileName = FolderAndFiles.ImageGallery[k].FileName;
                        }
                    }
                    var exxceeimage = "";
                    exxceeimage = Control.ExceedImage;


                    if (exxceeimage == "P") {
                        $.ajax({
                            url: WebMethodsPath + "fitTheImageTocontroll",
                            type: "POST",
                            data: JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "false", ImageUploadPath: ImageUploadPath, CompanyID: CompanyID }),
                            dataType: "json",
                            processData: false,
                            contentType: "application/json; charset=utf-8",
                            success: function (ImageName) {

                                var arry = ImageName.d.split('~');
                                var exceedimage = "";

                                ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

                                Control.ImgUrl = arry[0];
                                Control.OrignalImageName = arry[2];
                                Control.IsFromBackEnd = true;
                                Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                                Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
                                $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
                                $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);

                                alignsingleImage(Control.ObjectID);
                            }
                        });
                    }

                    else {
                        $.ajax({
                            url: WebMethodsPath + "assignToTemplateFolrder",
                            type: "POST",
                            data: JSON.stringify({ originalFilename: fileName, sourcepath: ImageUploadPath + CompanyID + "\\Images\\Gallery\\OriginalImages\\", savepath: ImageUploadPath + CompanyID + "\\Images\\" }),
                            dataType: "json",
                            processData: false,
                            contentType: "application/json; charset=utf-8",
                            success: function (imageName) {
                                var ImageName = imageName.d;
                                if (exxceeimage == "S") {
                                    var Control;
                                    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                                    Control.ImgUrl = ImageName;
                                    Control.OrignalImageName = ImageName;
                                    Control.IsFromBackEnd = true;

                                    $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + ImageName);
                                    $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                                    $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                                    Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                                    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.Align);
                                    alignsingleImage(Control.ObjectID);
                                }
                                else if (exxceeimage == "D") {
                                    var Control;
                                    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                                    Control.ImgUrl = ImageName;
                                    Control.OrignalImageName = ImageName;
                                    Control.IsFromBackEnd = true;

                                    var tmpImg = new Image();
                                    tmpImg.src = BackgroundImagesPath + ImageName;
                                    $(tmpImg).on('load', function () {
                                        var orgWidth = tmpImg.width;
                                        var orgHeight = tmpImg.height;
                                        $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + ImageName);
                                        $("#" + Control.ObjectID).css({ 'width': orgWidth + 'px', 'height': orgHeight + 'px' });
                                        $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                                        $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                                        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                                        Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                                        Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
                                        Control.Width = parseFloat($("#" + Control.ObjectID).innerWidth()) / mmConvertionConstant;
                                        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.Align);
                                        alignsingleImage(Control.ObjectID);
                                    });
                                }
                            }
                        });
                    }

                }
            });
        }
    });

    $(".FolderAssginChk").click(function () {
        if ($(this).prop('checked')) {
            var id = $(this).attr('id').split('_')[1];
            $.ajax({
                url: ServicePath + "Insert_ImageGalleryAssignment_Onclick",
                type: "POST",
                data: JSON.stringify({ objectid: selectedObjectID, companyid: CompanyID, templateid: TemplateID, userid: UserID, type: "c", typeid: id, isdefault: false, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function () {
                    $.ajax({
                        url: ServicePath + "GetSystemGalleryFoldersandFiles",
                        type: "POST",
                        data: JSON.stringify({ companyid: CompanyID, categoryid: id, _key: DBKey }),
                        dataType: "json",
                        processData: false,
                        contentType: "application/json; charset=utf-8",
                        success: function (folderAndFiles) {

                            var FolderAndfiles = JSON.parse(JSON.stringify(folderAndFiles.d));
                            for (var i = 0; i < FolderAndfiles.ImageCategories.length; i++) {
                                $.ajax({
                                    url: ServicePath + "Insert_ImageGalleryAssignment_Onclick",
                                    type: "POST",
                                    data: JSON.stringify({ objectid: selectedObjectID, companyid: CompanyID, templateid: TemplateID, userid: UserID, type: "c", typeid: FolderAndfiles.ImageCategories[i].CategoryID, isdefault: false, _key: DBKey }),
                                    dataType: "json",
                                    processData: false,
                                    contentType: "application/json; charset=utf-8",
                                    success: function () {
                                    }
                                });
                            }
                        }
                    });
                }
            });
        }
        else {

            var id = $(this).attr('id').split('_')[1];
            $.ajax({
                url: ServicePath + "ImageGalleryAssignment_Delete",
                type: "POST",
                data: JSON.stringify({ compnayid: CompanyID, templateid: TemplateID, objectid: selectedObjectID, type: "c", typeid: id, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function () {
                    $.ajax({
                        url: ServicePath + "GetSystemGalleryFoldersandFiles",
                        type: "POST",
                        data: JSON.stringify({ companyid: CompanyID, categoryid: id, _key: DBKey }),
                        dataType: "json",
                        processData: false,
                        contentType: "application/json; charset=utf-8",
                        success: function (folderAndFiles) {

                            var FolderAndfiles = JSON.parse(JSON.stringify(folderAndFiles.d));
                            for (var i = 0; i < FolderAndfiles.ImageCategories.length; i++) {
                                $.ajax({
                                    url: ServicePath + "ImageGalleryAssignment_Delete",
                                    type: "POST",
                                    data: JSON.stringify({ compnayid: CompanyID, templateid: TemplateID, objectid: selectedObjectID, type: "c", typeid: FolderAndfiles.ImageCategories[i].CategoryID, _key: DBKey }),
                                    dataType: "json",
                                    processData: false,
                                    contentType: "application/json; charset=utf-8",
                                    success: function () {
                                    }
                                });
                            }
                        }
                    });
                }
            });
        }
    });

    $(".FileAssginChk").click(function () {
        if ($(this).prop('checked')) {
            var id = $(this).attr('id').split('_')[1];
            $.ajax({
                url: ServicePath + "Insert_ImageGalleryAssignment_Onclick",
                type: "POST",
                data: JSON.stringify({ objectid: selectedObjectID, companyid: CompanyID, templateid: TemplateID, userid: UserID, type: "f", typeid: id, isdefault: false, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function () {

                }
            });
        }
        else {
            var id = $(this).attr('id').split('_')[1];
            $.ajax({
                url: ServicePath + "ImageGalleryAssignment_Delete",
                type: "POST",
                data: JSON.stringify({ companyid: CompanyID, templateid: TemplateID, objectid: selectedObjectID, type: "f", typeid: id, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function () {

                }
            });
        }
    });

    $(".DeleteCategory").unbind('click').bind('click', function () {
        editcategory = true;
        if (confirm("Are you sure you want to delete category? \nThis action cannot be undone.")) {
            $(".loading_gallery").show();
            var catid = $(this).attr('id').split('_')[1];
            $.ajax({
                url: ServicePath + "DeleteImageCategory",
                type: "POST",
                data: JSON.stringify({ categoryid: catid, templateid: TemplateID, objectid: selectedObjectID, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    if (result.d == -1) {
                        $("#savemsg").html("You can not delete the category, it is assigned to object in system");
                        $("#SaveMessage").dialog("open");
                        msgBoxDesign();
                        $(".loading_gallery").hide();
                        return false;
                    }
                    else {
                        loadFolderAndFilesBycategory("", $(".txtSearchText").attr('id').split('_')[1]);
                    }
                }
            });
        }
        loadcategoryList("");
    });


    $(".DeleteFile").unbind('click').bind('click', function () {

        if (confirm("Are you sure you want to delete image?")) {
            $(".loading_gallery").show();
            var imageid = $(this).attr('id').split('_')[1];
            $.ajax({
                url: ServicePath + "DeleteGalleryImages",
                type: "POST",
                data: JSON.stringify({ imageid: imageid, templateid: TemplateID, objectid: selectedObjectID, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    if (result.d == -1) {
                        $("#savemsg").html("<span>You can not delete this image, it is assigned to object in system.</span>");
                        $("#SaveMessage").dialog("open");
                        msgBoxDesign();
                        $(".loading_gallery").hide();
                        return false;
                    }

                    else {
                        loadFolderAndFilesBycategory("", $(".txtSearchText").attr('id').split('_')[1]);
                    }
                }
            });
        }
    });

    $(".folder").unbind('click').bind('click', function () {
        if (editcategory == false) {
            $(".loading_gallery").show();
            loadFolderAndFilesBycategory(false, $(this).attr('id').split('_')[1]);
            $(".btnSearch").attr('id', 'btnSearch_' + $(this).attr('id').split('_')[1]);
        }
        else {
            editcategory = false;
        }
    });
    $(".txtSearchText").unbind('keyup').bind('keyup', function (e) {
        if (e.which == 13) {
            if ($(".txtSearchText").val() == "") {
                $(".loading_gallery").show();
                loadFolderAndFilesBycategory(false, "0");
            }
            else {
                $(".loading_gallery").show();
                var catid = $(this).attr('id').split('_')[1];
                $.ajax({
                    url: ServicePath + "GetImageGallerySearch",
                    type: "POST",
                    data: JSON.stringify({ companyid: CompanyID, categoryid: catid, userid: UserID, searchtext: $(".txtSearchText").val(), _key: DBKey }),
                    dataType: "json",
                    processData: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (folderAndFiles) {

                        var FolderAndFiles = JSON.parse(JSON.stringify(folderAndFiles.d));
                        createFolderStructure(FolderAndFiles, catid);
                        $(".txtSearchText").attr('id', 'SearchText_' + catid);

                    }
                });
            }
        }
    });
    $(".btnClearSearchText").unbind('click').bind('click', function () {
        $(".loading_gallery").show();

        var id = $(".txtSearchText").attr('id').split('_')[1];
        loadFolderAndFilesBycategory(false, id);
        $(".txtSearchText").val("");
    });

    $(".btnBack").unbind('click').bind('click', function () {
        $(".loading_gallery").show();
        loadFolderAndFilesBycategory(false, $(this).attr('id').split('_')[1]);
    });

    $("#btnSelectAll").unbind('click').bind('click', function () {
        $("#btnSelectAll").hide();
        $("#btnUnSelectAll").show();
        $(".FolderSelectChk").prop('checked', true);
        $(".FileSelectChk").prop('checked', true);
    });
    $("#btnUnSelectAll").unbind('click').bind('click', function () {
        $("#btnUnSelectAll").hide();
        $("#btnSelectAll").show();
        $(".FolderSelectChk").prop('checked', false);
        $(".FileSelectChk").prop('checked', false);
    });

    $(".EditFile").unbind('click').bind('click', function () {

        $("#ImageDetails").dialog('open');
        $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
        $("div[aria-describedby=ImageDetails]").css('z-index', '111');
        $(".loadingNewMask").show();

        var imageid = $(this).attr('id').split('_')[1];
        editImageDetails(FolderAndFiles, imageid);
        $("#divImage").unbind('mouseenter').bind('mouseenter', function () {
            $("#changeimageshow").show();
        });

        $("#divImage").unbind('mouseleave').bind('mouseleave', function () {
            $("#changeimageshow").hide();
        });
        $(".btnupdateimagedetails").unbind('click').bind('click', function () {
            $(".loadingNewMask").hide();
            var imgid = $(this).attr('id').split('_')[1];
            var FileName = $("#txtImageName").val();
            if (FileName == "") {
                for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {
                    if (FolderAndFiles.ImageGallery[i].ImageID == parseInt(imgid)) {
                        FileName = FolderAndFiles.ImageGallery[i].OriginalFileName;
                    }
                }
            }
            $.ajax({
                url: ServicePath + "UpdateImageDetails",
                type: "POST",
                data: JSON.stringify({ imageid: imgid, companyid: CompanyID, categoryid: $("#drpCategoryForImage").val(), filename: FileName, description: $("#txtEditDescription").val(), metatags: $("#txtMetaTags").val(), userid: UserID, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function () {

                    $("#ImageDetails").dialog('close');
                    loadFolderAndFilesBycategory("", $("#drpCategoryForImage").val());
                }
            });
        });

        $("#btnCancelImageDetails").unbind('click').bind('click', function () {
            $("#ImageDetails").dialog('close');
            loadFolderAndFilesBycategory("", $("#drpCategoryForImage").val());
        });
        $(".lnkchangeImage").unbind('click').bind('click', function () {
            $("#UploadImage").dialog('open');
            filelistSingle = "";
            $('#UpadeInputfile').val("");
            $("#filenamespan").empty();
            var imageid = $(this).attr('id').split('_')[1];
            $(".btnUpdateImage").attr('id', "uploadimage_" + imageid);
            $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
            $("#btnCancelImage").unbind('click').bind('click', function () {
                $("#UploadImage").dialog('close');
            });
            //$("#btnSelectFile").unbind('click').bind('click',function () {
            //    $("#UpadeInputfile").trigger('click');
            //});
            $("#UpadeInputfile").unbind('change').bind('change', function () {
                if (ext == "pdf" || ext == "png" || ext == "jpeg" || ext == "jpg") {
                    var file = $('#UpadeInputfile').prop("files");
                    $("#filenamespan").html(file[0].name);
                    var ext = file[0].name.split('.')[1].toLowerCase();
                    var GUID = Guid().substr(0, 5);
                    filelistSingle += GUID + "~" + file[0].name + "~" + parseInt(file[0].size);
                }
                else {
                    $('#UpadeInputfile').val("");
                }
            });
            $(".btnUpdateImage").unbind('click').bind('click', function () {
                if (filelistSingle == "") {
                    $("#savemsg").html("Please select file to upload.");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    return false;
                }
                else {

                    var form_data = new FormData();

                    var objFiles = $("input#UpadeInputfile").prop("files");

                    jQuery.each($('#UpadeInputfile')[0].files, function (i, file) {
                        form_data.append('file-' + i, file);
                    });
                    $.ajax({
                        url: mainSitePath + "uploadhandler.ashx/ProcessRequest?Zoom=" + zoom + "&CompanyID=" + CompanyID + "&Dbkey=" + DBKey + "&ImageUploadPath=" + ImageUploadPath + "&UploadFileNames=" + filelistSingle + "," + "&CategoryID=" + $("#drpSelectCategory").val() + "&TemplateID=" + TemplateID + "&UserID=" + UserID,
                        cache: false,
                        contentType: false,
                        processData: false,
                        data: form_data,
                        type: 'post',
                        success: function () {

                            var arry = filelistSingle.split('~');
                            var filename = arry[0] + "_" + arry[1];
                            var originalfilename = arry[1];
                            var filesize = arry[2];

                            $.ajax({
                                url: ServicePath + "UploadImageDetails",
                                type: "POST",
                                data: JSON.stringify({ imageid: imageid, companyid: CompanyID, orgfilename: originalfilename, filename: filename, filesize: filesize, userid: UserID, _key: DBKey }),
                                dataType: "json",
                                processData: false,
                                contentType: "application/json; charset=utf-8",
                                success: function () {

                                    $("#UploadImage").dialog('close');
                                    loadFolderAndFilesBycategory("editimage", $("#drpCategoryForImage").val(), imageid);
                                }
                            });
                        }
                    });
                }
            });

        });
    });

    $(".FolderSelectChk").unbind('click').bind('click', function () {
        editcategory = true;
    });

    $("#btnDeletetAll").unbind('click').bind('click', function () {

        var deletecategoryids = "", deleteimageids = "";
        $("#thumNail").find(".FolderSelectChk").each(function () {
            if ($(this).prop('checked') == true) {
                deletecategoryids += $(this).attr('id').split('_')[1] + ",";
            }
        });
        $("#thumNail").find(".FileSelectChk").each(function () {
            if ($(this).prop('checked') == true) {
                deleteimageids += $(this).attr('id').split('_')[1] + ",";
            }
        });
        if (deleteimageids == "" && deletecategoryids == "") {
            
            $("#savemsg").html("Please select files or folders to delete.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
            $("div[aria-describedby=SaveMessage]").css('z-index', '111');
            $(".loadingNewMask").show();
            return false;
        }
        else {
            $(".loading_gallery").show();
            $.ajax({
                //var DeleteMultiple = {};
                url: ServicePath + "IsDeleteMultipleFilesFoldersAssigned",
                type: "POST",
                data: JSON.stringify({ categoryids: deletecategoryids, imageids: deleteimageids, templateid: TemplateID, companyid: CompanyID, objectid: selectedObjectID, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    if (result.d.indexOf("-1") != -1) {
                        if (confirm("Are you sure you want to delete selected files or folders? \r\nIt will be removed from any products that it is currently allocated to.")) {
                            $.ajax({
                                //var DeleteMultiple = {};
                                url: ServicePath + "DeleteMultipleFilesFolders",
                                type: "POST",
                                data: JSON.stringify({ categoryids: deletecategoryids, imageids: deleteimageids, userid: UserID, companyid: CompanyID, _key: DBKey }),
                                dataType: "json",
                                processData: false,
                                contentType: "application/json; charset=utf-8",
                                success: function (result) {
                                    loadFolderAndFilesBycategory("", $(".txtSearchText").attr('id').split('_')[1]);
                                }
                            });
                        }

                    }
                    else {
                        if (confirm("Are you sure you want to delete? \r\n This action cannot be undone.")) {
                            $.ajax({
                                //var DeleteMultiple = {};
                                url: ServicePath + "DeleteMultipleFilesFolders",
                                type: "POST",
                                data: JSON.stringify({ categoryids: deletecategoryids, imageids: deleteimageids, userid: UserID, companyid: CompanyID, _key: DBKey }),
                                dataType: "json",
                                processData: false,
                                contentType: "application/json; charset=utf-8",
                                success: function (result) {
                                    loadFolderAndFilesBycategory("", $(".txtSearchText").attr('id').split('_')[1]);
                                }
                            });
                        }
                    }
                }
            });

        }
        loadcategoryList("");
    });

    $("#btnSaveImage").unbind('click').bind('click', function () {
        $("#ImageFromGallery").dialog('close');
    });

    $(".EditCategory").unbind('click').bind('click', function () {

        $("#EditCategory").dialog('open');
        editcategory = true;
        for (var i = 0; i < FolderAndFiles.ImageCategories.length; i++) {
            if (FolderAndFiles.ImageCategories[i].CategoryID == parseInt($(this).attr('id').split('_')[1])) {
                $("#txtEditCategoryName").val(FolderAndFiles.ImageCategories[i].CategoryName);
                $(".btnEditSave").attr('id', "btnEditSave_" + $(this).attr('id').split('_')[1]);
                for (var j = 0; j < CategoryBindingList.length; j++) {
                    if (CategoryBindingList[j].CategoryID == FolderAndFiles.ImageCategories[i].ParentID) {
                        $("#drpforEditCategory").append("<option value='" + FolderAndFiles.ImageCategories[i].ParentID + "'>" + CategoryBindingList[j].MultiLevelCategory + "</option>");
                        $("#drpforEditCategory").prop('disabled', true);
                    }
                }
                break;
            }
        }
        $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
        $("div[aria-describedby=EditCategory]").css('z-index', '111');
        $(".loadingNewMask").show();

        $(".btnEditSave").unbind('click').bind('click', function () {
            $(".loadingNewMask").hide();
            var catName = $("#txtEditCategoryName").val();
            if ($("#txtEditCategoryName").val() == "") {
                for (var i = 0; i < FolderAndFiles.ImageCategories.length; i++) {
                    if (FolderAndFiles.ImageCategories[i].CategoryID == parseInt($(this).attr('id').split('_')[1])) {
                        catName = FolderAndFiles.ImageCategories[i].CategoryName;
                    }
                }
            }
            else {

                $.ajax({
                    url: ServicePath + "UpdateImageCategory",
                    type: "POST",
                    data: JSON.stringify({ companyid: CompanyID, categoryid: $(this).attr('id').split('_')[1], categoryname: catName, userid: UserID, description: "", parentid: $("#drpforEditCategory").val(), categoryimage: "", _key: DBKey }),
                    dataType: "json",
                    processData: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (categoryID) {
                        var CategoryID = categoryID.d;

                        if (CategoryID == -1) {
                            $("#savemsg").html("Category name already exists.");
                            $("#SaveMessage").dialog("open");
                            msgBoxDesign();
                            return false;
                        }
                        else {

                            $("#EditCategory").dialog('close');
                            loadFolderAndFilesBycategory(false, $("#drpforEditCategory").val());
                        }
                    }
                });
            }
        });
    });
}

function editImageDetails(FolderAndFiles, id) {
    for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {
        if (FolderAndFiles.ImageGallery[i].ImageID == parseInt(id)) {

            $("#txtImageName").val(FolderAndFiles.ImageGallery[i].OriginalFileName);
            $("#txtMetaTags").val(FolderAndFiles.ImageGallery[i].MetaTags);
            $("#txtEditDescription").val(FolderAndFiles.ImageGallery[i].Description);
            $("#imgEditImage").attr('src', BackgroundImagesPath + "Gallery/OriginalImages/" + FolderAndFiles.ImageGallery[i].FileName);
            loadCategorydropdownsforEdit(FolderAndFiles.ImageGallery[i].CategoryID);
            $(".btnupdateimagedetails").attr('id', 'updateimagedetails_' + id);
            $(".lnkchangeImage").attr('id', 'chageimage_' + id);
        }
    }
}
function getUrlEncodedKey(key, query) {
    if (!query) {
        query = window.location.search;
    }
    var re = new RegExp("[?|&]" + key + "=(.*?)&");
    var matches = re.exec(query + "&");
    if (!matches || matches.length < 2) {
        return "";
    }
    else {
        return decodeURIComponent(matches[1].replace("+", " "));
    }
}

function copyClick() {
    $(".copyCombobox").unbind('click').bind('click', function () {
        $('.txtCopy').val($(this).html());
        $('.txtCopy').attr('id', 'txtCopy_' + $(this).attr('id').split('_')[1]);
        $("#copyDiv").hide();
        $("#copyDiv").empty();
    });
}

function selectTheTemplateName(Key) {
    var i = 0, selected = 0, selectedid = "";
    $("#copyDiv").find(".copyCombobox").each(function () {
        i++;

        if ($(this).css('background-color') == "rgb(230, 230, 230)") {
            selected = i;
            selectedid = $(this).attr('id').split('_')[1];
        }
    });
    if (Key == 40) {
        selected = selected + 1;
    }
    else if (Key == 38) {
        selected = selected - 1;
    }

    if (Key == 13) {
        if (selected > 0 && selected <= i) {
            var count = 0;
            $("#copyDiv").find(".copyCombobox").each(function () {
                count++;
                if (count == selected) {
                    $('.txtCopy').val($(this).html());
                    $('.txtCopy').attr('id', 'txtCopy_' + $(this).attr('id').split('_')[1]);
                    $("#copyDiv").hide();
                    $("#copyDiv").empty();
                }

            });
        }
    }
    else {
        if (selected > 0 && selected <= i) {
            var count = 0;
            $("#copyDiv").find(".copyCombobox").each(function () {
                count++;
                if (count == selected) {
                    $(this).css({ 'background-color': 'rgb(230, 230, 230)' });
                    document.getElementById($(this).attr('id')).scrollIntoView();
                }
                else {
                    $(this).css({ 'background-color': 'rgba(0, 0, 0, 0)' });
                }
            });
        }
    }

}



function ReloadReviewFields() {

    $("#sortable").empty();
    var pagenum = parseInt($("#drpPageSelect").val());
    for (var i = 0; i < ControllDetails.length; i++) {

        if (ControllDetails[i].Visibility == true && ControllDetails[i].PageNumber == pagenum) {
            $("#sortable").append("<li class='ui-state-default reiewFields' title='Drag object for rearrange' id='R_" + ControllDetails[i].ObjectID + "'>" + ControllDetails[i].FieldName + "</li>");
            loadFuctionForReview();
        }
    }
}


function changeLineSpacing(Space) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (Control.Type == "Paragraph") {

        if (Space == "" || Space == 0) {
            $("#" + Control.ObjectID + " p").css('line-height', "normal");
            Control.ParaLineSpace = 0;
            $("#txtLineSpacing").val(0);
        }
        else {
            $("#" + Control.ObjectID + " p").css('line-height', (parseFloat(Space) * mmConvertionConstant) + "px");
            Control.ParaLineSpace = parseFloat(Space);

            if (Control.ExceedHeight == "Do Nothing") {
                if (parseFloat($("#" + Control.ObjectID + " p").innerHeight()) > parseFloat($("#" + Control.ObjectID).innerHeight())) {
                    $("#txtLineSpacing").val(parseFloat(Control.ParaLineSpace).toFixed(0));
                    changeLineSpacing(Control.ParaLineSpace);
                }
            }
            else if (Control.ExceedHeight == "Expand Height") {
                if (parseFloat($("#" + Control.ObjectID + " p").innerHeight()) > parseFloat($("#" + Control.ObjectID).innerHeight())) {
                    $("#" + Control.ObjectID).css('height', parseFloat($("#" + Control.ObjectID + " p").innerHeight()) + 2 + 'px');
                }
            }
        }
    }
}

function changeFiledNameQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

    Control.FieldName = Text;
}

function changePositionXQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.PositionX = parseFloat(Text);
}

function changePositionYQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.PositionY = parseFloat(Text);

}

function changePageQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.PageNumber = parseInt(Text);

}

function changeGroupOrientationQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.GroupOrientation = Text;

}

function changeFontQuickAdjust(id, Text) {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    var arry = Text.split('~');
    var fontpathName = arry[0];
    var fontid = arry[1];
    var ActualfontName = arry[2];
    var fontname = arry[3];
    Control.FontFamily = fontname;
    Control.ActualFontName = ActualfontName;
    Control.FontID = fontid;
    Control.FontExtension = fontpathName;

}

function changeGroupKeepOptionQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.KeepOption = Text;

}

function changeWidthQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.Width = parseFloat(Text);

}

function deleteContolQuickAdjust(id) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.Visibility = false;

    loadDynamicQuickAdjust();
    changeThePageFromDropDown($("#drpPageSelect").val());

}

function applyonexceedwidth(id) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

    var width = $("#" + Control.ObjectID).innerWidth();
    var width = $("#" + Control.ObjectID).outerWidth();
    var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
    width = width - LabelWidth;
    var TextWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth;

    var defaultContent = "";
    if (Control.DefaultContent != "") {
        defaultContent = Control.DefaultContent;
    }
    else {
        defaultContent = Control.FieldName;
    }

    if (Control.ExceedWidth == "Do Nothing") {


        if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
            while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
                defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                attachLabelTosinglelineControl(Control.ObjectID, defaultContent);


                Control.DefaultContent = defaultContent;
            }
        }
        else {
            if (Control.DefaultContent != "") {
                Control.DefaultContent = defaultContent;
            }
            else {
                Control.FieldName = defaultContent;
            }
        }
    }
    else if (Control.ExceedWidth == "Expand side") {
        if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
            $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
            Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
            Control.Width = Control.MaxWidth;
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        }
        else {
            if (Control.DefaultContent != "") {
                Control.DefaultContent = defaultContent;
            }
            else {
                Control.FieldName = defaultContent;
            }
        }
    }
    else if (Control.ExceedWidth == "Shrink") {

        if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth()) > width) {

            var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
            var fontsize = Fontsize - 0.05;
            while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth()) > width) {
                $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                Control.FontSize = font * ptConvertionConstant;
                $("#txtFontSize").val(font * ptConvertionConstant);

                if (LabelWidth == null) {
                    $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                }

                Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                Control.Height = Control.MaxHeight;
                fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
                fontsize = fontsize - 0.05;
            }

        }
        else {
            if (Control.DefaultContent != "") {
                Control.DefaultContent = defaultContent;
            }
            else {
                Control.FieldName = defaultContent;
            }
        }
    }
    else if (Control.ExceedWidth == "Tracking") {

        if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth()) > width) {
            if (Control.MaxShrink > 0) {
                var spacing;
                var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                var letterSpacing = LetterSpacing - Control.MaxShrink;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });

                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                    letterSpacing = letterSpacing - Control.MaxShrink
                }
                $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                Control.ManualTrackSign = spacing[0];
                Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                Control.ManualTrackDimension = "pt";
            }
            else {
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
                    defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);


                    Control.DefaultContent = defaultContent;
                }
            }
        }
        else {
            if (Control.DefaultContent != "") {
                Control.DefaultContent = defaultContent;
            }
            else {
                Control.FieldName = defaultContent;
            }
        }
    }

}


function applyContolHeightAccordingToFont(Control) {

    var fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
    var baselinevar = (parseFloat($("#" + Control.ObjectID + " .labelText").innerHeight()) - fontsize);

    $("#" + Control.ObjectID).css('line-height', parseFloat($("#" + Control.ObjectID + " .labelText").innerHeight()) + "px");
    $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").innerHeight());

    if (parseFloat($("#" + Control.ObjectID + " .labelText").innerHeight()) < parseFloat($("#" + Control.ObjectID + " .label").innerHeight())) {
        fontsize = parseFloat($("#" + Control.ObjectID + " .label").css('font-size'));
        baselinevar = (parseFloat($("#" + Control.ObjectID + " .label").innerHeight()) - fontsize);

        $("#" + Control.ObjectID).css('line-height', parseFloat($("#" + Control.ObjectID + " .label").innerHeight()) + baselinevar + "px");
        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .label").innerHeight());
    }

    Control.MaxHeight = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
    Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;

    if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth()) >= $("#" + Control.ObjectID).innerWidth()) {
        $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").innerWidth());
        Control.MaxWidth = $("#" + Control.ObjectID).innerWidth() / mmConvertionConstant;
        Control.Width = $("#" + Control.ObjectID).innerWidth() / mmConvertionConstant;
    }
    else {
        if (Control.DefaultContent != "") {
            Control.DefaultContent = $("#" + Control.ObjectID + " .labelText").html();
        }
        else {
            Control.FieldName = $("#" + Control.ObjectID + " .labelText").html();
        }
    }

    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
}


function getuniquefontname() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    for (var i = 0; i < 10; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
}

function alignsingleLineText(controllID) {

    var controllDetails;
    ControllDetails.map(function (proj) { if (proj.ObjectID == controllID) controllDetails = proj });
    if (controllDetails.Type == "TextBlock") {
        switch (controllDetails.TextAlign) {
            case "Left":
                $("#" + controllDetails.ObjectID + " .labelText").css({ 'right': 'auto', 'left': -1 + 'px' });
                break;
            case "Right":
                $("#" + controllDetails.ObjectID + " .labelText").css({ 'left': 'auto', 'right': -1 + 'px' });
                break;
            case "Center":
                $("#" + controllDetails.ObjectID + " .labelText").css({ 'right': 'auto', 'left': ((($("#" + controllDetails.ObjectID).outerWidth() / 2) - ($("#" + controllDetails.ObjectID + " .labelText").outerWidth() / 2)) - 1) + 'px' });
                break;
        }
    }
}


function alignsingleImage(controllID) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == controllID) Control = proj });

    var imageWidth = $("#" + Control.ObjectID + " img").outerWidth();
    var imageHeight = $("#" + Control.ObjectID + " img").outerHeight();
    var controlWidth = $("#" + Control.ObjectID).outerWidth() - 2;
    var controlHeight = $("#" + Control.ObjectID).outerHeight() - 2;

    if (Control.Type == "Image") {

        if (Control.ExceedImage == "P") {
            if (Control.ImageLocation == "TL" || Control.ImageLocation == "SELECT") {
                $("#" + Control.ObjectID + " img").css({ 'right': 'auto', 'bottom': 'auto', 'top': '0px', 'left': '0px' });
            }
            else if (Control.ImageLocation == "TC") {
                $("#" + Control.ObjectID + " img").css({ 'right': 'auto', 'bottom': 'auto', 'top': '0px', 'left': ((controlWidth / 2) - (imageWidth / 2)) + "px" });
            }
            else if (Control.ImageLocation == "TR") {
                $("#" + Control.ObjectID + " img").css({ 'left': 'auto', 'bottom': 'auto', 'top': '0px', 'right': '0px' });
            }
            else if (Control.ImageLocation == "CL") {
                $("#" + Control.ObjectID + " img").css({ 'right': 'auto', 'bottom': 'auto', 'top': ((controlHeight / 2) - (imageHeight / 2)) + "px", 'left': '0px' });
            }
            else if (Control.ImageLocation == "C") {
                $("#" + Control.ObjectID + " img").css({ 'right': 'auto', 'bottom': 'auto', 'top': ((controlHeight / 2) - (imageHeight / 2)) + "px", 'left': ((controlWidth / 2) - (imageWidth / 2)) + "px" });
            }
            else if (Control.ImageLocation == "CR") {
                $("#" + Control.ObjectID + " img").css({ 'left': 'auto', 'bottom': 'auto', 'top': ((controlHeight / 2) - (imageHeight / 2)) + "px", 'right': '0px' });
            }
            else if (Control.ImageLocation == "BL") {
                $("#" + Control.ObjectID + " img").css({ 'right': 'auto', 'top': 'auto', 'bottom': '0px', 'left': '0px' });
            }
            else if (Control.ImageLocation == "BC") {
                $("#" + Control.ObjectID + " img").css({ 'right': 'auto', 'top': 'auto', 'bottom': '0px', 'left': ((controlWidth / 2) - (imageWidth / 2)) + "px" });
            }
            else if (Control.ImageLocation == "BR") {
                $("#" + Control.ObjectID + " img").css({ 'left': 'auto', 'top': 'auto', 'bottom': '0px', 'right': '0px' });
            }
        }
        else {
            $("#" + Control.ObjectID + " img").css({ 'right': 'auto', 'bottom': 'auto', 'top': '0px', 'left': '0px' });
        }
    }
}

function attachLabelTosinglelineControl(controllID, Text) {

    var controllDetails;
    ControllDetails.map(function (proj) { if (proj.ObjectID == controllID) controllDetails = proj });
    var LabelWidth = $("#" + controllDetails.ObjectID + " .label").outerWidth();
    if (LabelWidth != null) {
        var LabelHtml = $("#" + controllDetails.ObjectID + " .labelText").html().split('</span>')[0];

        $("#" + controllDetails.ObjectID + " .labelText").html(LabelHtml + "</span>" + Text);
    }
    else {
        $("#" + controllDetails.ObjectID + " .labelText").html(Text);
    }

}

function sortJSON(data, key, sortorder) {
    return data.sort(function (a, b) {
        var x = a[key];
        var y = b[key];
        if (sortorder == "ASC") {
            return ((x < y) ? -1 : ((x > y) ? 1 : 0));
        }
        else if (sortorder == "DESC") {
            return ((x < y) ? ((x > y) ? 0 : 1) : -1);
        }
    });
}


function bindQuickAdjust(QuickAdjustHtml, pageNumber) {
    ControllDetails = sortJSON(ControllDetails, "OrderNumber", "ASC");
    for (var i = 0; i < ControllDetails.length; i++) {

        if (ControllDetails[i].GroupID == 0 && ControllDetails[i].Visibility == true && ControllDetails[i].PageNumber == pageNumber) {

            QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;background-color: #F6F6F6'>";
            QuickAdjustHtml += "<td class='contentTd'><div style='font-family:verdana;font-size:11px;'>" + ControllDetails[i].Type + "<div></td>";
            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqfieldName Controlls' id='fldname_" + ControllDetails[i].ObjectID + "' value='" + ControllDetails[i].FieldName + "' /></td>";
            QuickAdjustHtml += "<td class='contentTd'>";
            QuickAdjustHtml += "<select class='QuickSelect drpqpageNumber mediumSelect Controlls' id='pgnum_" + ControllDetails[i].ObjectID + "'>";
            for (var j = 1; j <= TemplateDetails.Totalpage; j++) {
                if (ControllDetails[i].PageNumber == j) {
                    QuickAdjustHtml += "<option value='" + j + "' selected>" + j + "</option>";
                }
                else {
                    QuickAdjustHtml += "<option value='" + j + "'>" + j + "</option>";
                }
            }
            QuickAdjustHtml += "</select></td>";
            QuickAdjustHtml += "<td class='contentTd'><input type='text'  class='QuickTextBox txtqpositionX Controlls' onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);'  id='posx_" + ControllDetails[i].ObjectID + "' value='" + parseFloat(ControllDetails[i].PositionX).toFixed(4) + "' /></td>";
            QuickAdjustHtml += "<td class='contentTd'><input type='text'  class='QuickTextBox txtqpositionX Controlls'  onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);' id='posy_" + ControllDetails[i].ObjectID + "' value='" + parseFloat(ControllDetails[i].PositionY).toFixed(4) + "' /></td>";
            QuickAdjustHtml += "<td class='contentTd'><input type='text'  class='QuickTextBox txtqwidth Controlls' onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);'  id='width_" + ControllDetails[i].ObjectID + "' value='" + parseFloat(ControllDetails[i].Width).toFixed(4) + "' /></td>";
            QuickAdjustHtml += "<td><select class='QuickSelect drpqfont Controlls' id='fontdrp_" + ControllDetails[i].ObjectID + "' >";
            QuickAdjustHtml += "</select></td>";
            if (ControllDetails[i].Type != "Image") {
                QuickAdjustHtml += "<td><div class='color' style='border:1px solid black;width:20px;padding-left:5px;font-size:11px;font-weight:bold;'><div style='padding-left:2px;'>A</div><div style='width:15px;height:5px;margin-bottom:3px;background-color:rgba(" + ControllDetails[i].R + ", " + ControllDetails[i].G + ", " + ControllDetails[i].B + ", " + ControllDetails[i].A + ");'></div></div></td>";
            }
            else {
                QuickAdjustHtml += "<td class='contentTd'><div style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
            }
            QuickAdjustHtml += "<td><select class='QuickSelect drpOrientation Controlls' id='ornt_" + ControllDetails[i].ObjectID + "' >";
            switch (ControllDetails[i].GroupOrientation) {
                case "Horizontal":
                    QuickAdjustHtml += "<option value='None' >None</option><option value='Horizontal' selected>Horizontal</option><option value='Vertical'>Vertical</option>";
                    break;
                case "Vertical":
                    QuickAdjustHtml += "<option value='None' >None</option><option value='Horizontal' >Horizontal</option><option value='Vertical' selected>Vertical</option>";
                    break;
                default:
                    QuickAdjustHtml += "<option value='None' selected>None</option><option value='Horizontal' >Horizontal</option><option value='Vertical' >Vertical</option>";
                    break;
            }
            QuickAdjustHtml += "</select></td>";
            QuickAdjustHtml += "<td><select class='QuickSelect drpfieldMovement Controlls' id='fldmnt_" + ControllDetails[i].ObjectID + "' >";

            switch (ControllDetails[i].GroupOrientation) {
                case "Horizontal":

                    switch (ControllDetails[i].KeepOption) {
                        case "Move Field Left":
                            QuickAdjustHtml += "<option val='None' >None</option><option val='Move Field Left' selected>Move Field Left</option><option val='Move Field Right' >Move Field Right</option>";
                            break;
                        case "Move Field Right":
                            QuickAdjustHtml += "<option val='None' >None</option><option val='Move Field Left' >Move Field Left</option><option val='Move Field Right' selected>Move Field Right</option>";
                            break;
                        default:
                            QuickAdjustHtml += "<option val='None' selected>None</option><option val='Move Field Left' >Move Field Left</option><option val='Move Field Right' >Move Field Right</option>";
                            break;
                    }
                    break;
                case "Vertical":

                    switch (ControllDetails[i].KeepOption) {
                        case "Move Field Up":
                            QuickAdjustHtml += "<option val='None'>None</option><option val='Move Field Up' selected>Move Field Up</option><option val='Move Field Down' >Move Field Down</option>";
                            break;
                        case "Move Field Down":
                            QuickAdjustHtml += "<option val='None'>None</option><option val='Move Field Up' >Move Field Up</option><option val='Move Field Down' selected>Move Field Down</option>";
                            break;
                        default:
                            QuickAdjustHtml += "<option val='None' selected>None</option><option val='Move Field Up' >Move Field Up</option><option val='Move Field Down'>Move Field Down</option>";
                            break;
                    }
                    break;
                default:
                    QuickAdjustHtml += "<option val='None' selected>None</option>";
                    break;
            }
            QuickAdjustHtml += "</select></td>";
            QuickAdjustHtml += "<td style='text-align:center;' class='actions'><img class='image DeleteControll' Title='Delete Control' id='deleteCtrl_" + ControllDetails[i].ObjectID + "' src='StyleSheets/Images/cross.png' height='13' width='13' style='vertical-align:middle;margin:0px auto 0px auto;cursor:pointer;border:2px solid transparent;border-radius: 10px;padding:1px;' /></td>";
        }
    }
    if (VerticalGroupingData.length > 0 || HorizontalGroupingData.length > 0) {

        if (VerticalGroupingData.length > 0) {

            for (var i = 0; i < VerticalGroupingData.length; i++) {
                if (VerticalGroupingData[i].PageNumber == pageNumber) {
                    QuickAdjustHtml += "<tr><td style='padding-top:10px;'>";
                    QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;'>";
                    QuickAdjustHtml += "<td class='contentTd excesspadding'><div style='font-family:verdana;font-size:11px;' >Vertical Group<div></td>";
                    QuickAdjustHtml += "<td class='contentTd excesspadding'><input disabled type='text' calss='QuickTextBox txtGroupName GroupDisable' style='width:100px;font-family:verdana;font-size:11px;height:20px;border: 1px solid #8D8091;border-radius: 1px;padding-left: 2px;' value='" + VerticalGroupingData[i].GroupName + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'>";
                    QuickAdjustHtml += "<select class='QuickSelect txtGroupPage GroupDisable mediumSelect' style='font-family:verdana;font-size:11px;width:50px;height:24px;border: 1px solid #8D8091;border-radius: 1px;'>";
                    QuickAdjustHtml += "<option selected>" + VerticalGroupingData[i].PageNumber + "</option>";
                    QuickAdjustHtml += "</select></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox txtGropuPositionX GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:20px;border: 1px solid #8D8091;border-radius: 1px;padding-left: 2px;' type='text' value='" + parseFloat(VerticalGroupingData[i].PositionX).toFixed(4) + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox txtGropuPositionY GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:20px;border: 1px solid #8D8091;border-radius: 1px;padding-left: 2px;' type='text' value='" + parseFloat(VerticalGroupingData[i].PositionY).toFixed(4) + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:20px;border: 1px solid #8D8091;border-radius: 1px;padding-left: 2px;' type='text' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><select class='GroupDisable' style='width:100px;height:24px;font-family:verdana;font-size:11px;border: 1px solid #8D8091;border-radius: 1px;'></select></td>";
                    QuickAdjustHtml += "<td class='contentTd'><div style='background-color:#EBEBE4;margin-left:1px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
                    QuickAdjustHtml += "<td><select class='GroupDisable' style='margin-left:5px;font-family:verdana;font-size:11px;width:100px;height:24px;border: 1px solid #8D8091;border-radius: 1px;'>";
                    QuickAdjustHtml += "<option selected>Vertical</option></select></td>";
                    QuickAdjustHtml += "<td><select class='GroupDisable' style='margin-left:5px;font-family:verdana;font-size:11px;width:120px;height:24px;border: 1px solid #8D8091;border-radius: 1px;'>";
                    QuickAdjustHtml += "<option selected>" + VerticalGroupingData[i].GrpKeepOption + "</option></select></td>";
                    QuickAdjustHtml += "<td class='contentTd excess' style='text-align:center;'><img class='image EditGroup Vertical' Title='Edit Group' id='btnEditGrp_" + VerticalGroupingData[i].GID + "' src='StyleSheets/Images/edit-icon.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:1px solid transparent;border-radius: 10px;padding:2px;' /><img id='btnDeleteGrp_" + VerticalGroupingData[i].GID + "' class='image DeleteGroup Vertical' Title='Delete Group' src='StyleSheets/Images/cross.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:2px solid transparent;border-radius: 10px;padding:2px;' /></td></tr>";
                    for (var k = 0; k < ControllDetails.length; k++) {

                        if (ControllDetails[k].GroupID == VerticalGroupingData[i].GID && ControllDetails[i].Visibility == true) {
                            QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;'>";
                            QuickAdjustHtml += "<td class='contentTd'><div style='font-family:verdana;font-size:11px;padding-left:10px;'>" + ControllDetails[k].Type + "<div></td>";
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqfieldName Controlls' id='fldname_" + ControllDetails[k].ObjectID + "' value='" + ControllDetails[k].FieldName + "' /></td>";
                            QuickAdjustHtml += "<td class='contentTd'>";
                            QuickAdjustHtml += "<select class='QuickSelect drpqpageNumber mediumSelect GroupDisable ' id='pgnum_" + ControllDetails[k].ObjectID + "'>";
                            for (var j = 1; j <= TemplateDetails.Totalpage; j++) {
                                if (ControllDetails[k].PageNumber == j) {
                                    QuickAdjustHtml += "<option value='" + j + "' selected>" + j + "</option>";
                                }
                                else {
                                    QuickAdjustHtml += "<option value='" + j + "'>" + j + "</option>";
                                }
                            }
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqpositionX GroupDisable' onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);'  id='posx_" + ControllDetails[k].ObjectID + "' value='" + parseFloat(ControllDetails[k].PositionX).toFixed(4) + "' /></td>";
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqpositionX GroupDisable'  onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);' id='posy_" + ControllDetails[k].ObjectID + "' value='" + parseFloat(ControllDetails[k].PositionY).toFixed(4) + "' /></td>";
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqwidth' onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);'  id='width_" + ControllDetails[k].ObjectID + "' value='" + parseFloat(ControllDetails[k].Width).toFixed(4) + "' /></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect drpqfont Controlls' id='fontdrp_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td><div class='color' style='border:1px solid black;width:20px;padding-left:5px;font-size:11px;font-weight:bold;'><div style='padding-left:2px;'>A</div><div style='width:15px;height:5px;margin-bottom:3px;background-color:rgba(" + ControllDetails[k].R + ", " + ControllDetails[k].G + ", " + ControllDetails[k].B + ", " + ControllDetails[k].A + ");'></div></div></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect drpOrientation GroupDisable' id='ornt_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "<option value='Vertical'>Vertical</option>";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect drpfieldMovement GroupDisable' id='fldmnt_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "<option value='down'>" + ControllDetails[k].KeepOption + "</option>";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td style='text-align:center;' class='actions'></td></tr>";
                        }
                    }
                    QuickAdjustHtml += "</td><tr>";
                }
            }
        }
        if (HorizontalGroupingData.length > 0) {
            for (var i = 0; i < HorizontalGroupingData.length; i++) {
                if (HorizontalGroupingData[i].PageNumber == pageNumber) {
                    QuickAdjustHtml += "<tr><td style='padding-top:10px;'>";
                    QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;'>";
                    QuickAdjustHtml += "<td class='contentTd excesspadding' ><div style='font-family:verdana;font-size:11px;' >Horizontal Group<div></td>";
                    QuickAdjustHtml += "<td class='contentTd excesspadding'><input disabled type='text' calss='QuickTextBox txtGroupName GroupDisable' style='width:100px;font-family:verdana;font-size:11px;height:20px;border: 1px solid #8D8091;border-radius: 1px;padding-left: 2px;' value='" + HorizontalGroupingData[i].GroupName + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'>";
                    QuickAdjustHtml += "<select class='QuickSelect txtGroupPage GroupDisable mediumSelect' style='font-family:verdana;font-size:11px;width:50px;height:24px;'>";
                    QuickAdjustHtml += "<option selected>" + HorizontalGroupingData[i].PageNumber + "</option>";
                    QuickAdjustHtml += "</select></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox txtGropuPositionX GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:20px;border: 1px solid #8D8091;border-radius: 1px;padding-left: 2px;' type='text' value='" + parseFloat(HorizontalGroupingData[i].PositionX).toFixed(4) + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox txtGropuPositionY GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:20px;border: 1px solid #8D8091;border-radius: 1px;padding-left: 2px;' type='text' value='" + parseFloat(HorizontalGroupingData[i].PositionY).toFixed(4) + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:20px;border: 1px solid #8D8091;border-radius: 1px;padding-left: 2px;' type='text' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><select class='GroupDisable' style='width:100px;height:24px;font-family:verdana;font-size:11px;border: 1px solid #8D8091;border-radius: 1px;'></select></td>";
                    QuickAdjustHtml += "<td class='contentTd'><div  style='background-color:#EBEBE4;margin-left:1px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
                    QuickAdjustHtml += "<td><select class='GroupDisable' style='margin-left:5px;font-family:verdana;font-size:11px;width:100px;height:24px;border: 1px solid #8D8091;border-radius: 1px;'>";
                    QuickAdjustHtml += "<option selected>Horizontal</option></select></td>";
                    QuickAdjustHtml += "<td><select class='GroupDisable' style='margin-left:5px;font-family:verdana;font-size:11px;width:120px;height:24px;border: 1px solid #8D8091;border-radius: 1px;'>";
                    QuickAdjustHtml += "<option selected>" + HorizontalGroupingData[i].GrpKeepOption + "</option></select></td>";
                    QuickAdjustHtml += "<td class='contentTd excess actions' style='text-align:center;'><img class='image EditGroup Horizontal' Title='Edit Group' id='btnEditGrp_" + HorizontalGroupingData[i].GID + "' src='StyleSheets/Images/edit-icon.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:1px solid transparent;border-radius: 10px;padding:2px;' /><img id='btnDeleteGrp_" + HorizontalGroupingData[i].GID + "' Title='Delete Group' class='image DeleteGroup Horizontal' src='StyleSheets/Images/cross.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:2px solid transparent;border-radius: 10px;padding:2px;' /></td></tr>";
                    for (var k = 0; k < ControllDetails.length; k++) {
                        if (ControllDetails[k].GroupID == HorizontalGroupingData[i].GID && ControllDetails[i].Visibility == true) {
                            QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;'>";
                            QuickAdjustHtml += "<td class='contentTd'><div style='font-family:verdana;font-size:11px;padding-left:15px;'>" + ControllDetails[k].Type + "<div></td>";
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqfieldName GroupDisable' id='fldname_" + ControllDetails[k].ObjectID + "' value='" + ControllDetails[k].FieldName + "' /></td>";
                            QuickAdjustHtml += "<td class='contentTd'>";
                            QuickAdjustHtml += "<select class='QuickSelect drpqpageNumber mediumSelect' id='pgnum_" + ControllDetails[k].ObjectID + "'>";
                            for (var j = 1; j <= TemplateDetails.Totalpage; j++) {
                                if (ControllDetails[k].PageNumber == j) {
                                    QuickAdjustHtml += "<option value='" + j + "' selected>" + j + "</option>";
                                }
                                else {
                                    QuickAdjustHtml += "<option value='" + j + "'>" + j + "</option>";
                                }
                            }
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqpositionX GroupDisable' onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);'  id='posx_" + ControllDetails[k].ObjectID + "' value='" + parseFloat(ControllDetails[k].PositionX).toFixed(4) + "' /></td>";
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqpositionX GroupDisable'  onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);' id='posy_" + ControllDetails[k].ObjectID + "' value='" + parseFloat(ControllDetails[k].PositionY).toFixed(4) + "' /></td>";
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqwidth' onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);'  id='width_" + ControllDetails[k].ObjectID + "' value='" + parseFloat(ControllDetails[k].Width).toFixed(4) + "' /></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect drpqfont Controlls' id='fontdrp_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td><div class='color' style='border:1px solid black;width:20px;padding-left:5px;font-size:11px;font-weight:bold;'><div style='padding-left:2px;'>A</div><div style='width:15px;height:5px;margin-bottom:3px;background-color:rgba(" + ControllDetails[k].R + ", " + ControllDetails[k].G + ", " + ControllDetails[k].B + ", " + ControllDetails[k].A + ");'></div></div></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect GroupDisable drpOrientation' id='ornt_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "<option value='Horizontal'>Horizontal</option>";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect drpfieldMovement GroupDisable' id='fldmnt_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "<option value='down'>" + ControllDetails[k].KeepOption + "</option>";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td style='text-align:center;' class='actions'></td></tr>";
                        }
                    }
                    QuickAdjustHtml += "</td><tr>";
                }
            }
        }
    }

    return QuickAdjustHtml;
}

function validateQty(event) {

    var value = $("#" + event.target.id).val();

    var key = window.event ? event.keyCode : event.which;
    if (event.keyCode == 8 || event.keyCode == 46
     || event.keyCode == 37 || event.keyCode == 39) {
        return true;
    }
    else if (key < 48 || key > 57) {
        return false;
    }
}

function vaild(event) {

    var value = $(event.target).val();

    if (event.target.id == "txtC" || event.target.id == "txtM" || event.target.id == "txtY" || event.target.id == "txtK" || event.target.id == "txtT") {
        if (value >= 0 && value <= 100) {

        }
        else {
            bindPreviosValue(event);
        }
    }
    else if ($(event.target).hasClass("txtRotateX") || event.target.id == "txtRotate") {
        if (value >= 0 && value <= 360) {

        }
        else {
            bindPreviosValue(event);
        }
    }
    else {
        if (value >= 0) {

        }
        else {
            bindPreviosValue(event);
        }
    }

}

function bindPreviosValue(event) {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (event.target.id == "txtPostionX") {
        $("#txtPostionX").val(parseFloat(Control.PositionX).toFixed(4));
    }
    else if (event.target.id == "txtImagePostionX") {
        $("#txtImagePostionX").val(parseFloat(Control.PositionX).toFixed(4));
    }
    else if (event.target.id == "txtPostionY") {
        $("#txtPostionY").val(parseFloat(Control.PositionY).toFixed(4));
    }
    else if (event.target.id == "txtImagePostionY") {
        $("#txtImagePostionY").val(parseFloat(Control.PositionY).toFixed(4));
    }
    else if (event.target.id == "txtMaxWidth") {
        $("#txtMaxWidth").val(parseFloat(Control.Width).toFixed(4));
    }
    else if (event.target.id == "txtMaxImageWidth") {
        $("#txtMaxImageWidth").val(parseFloat(Control.Height).toFixed(4));
    }
    else if (event.target.id == "txtMaxImageHeight") {
        $("#txtMaxImageHeight").val(parseFloat(Control.Height).toFixed(4));
    }
    else if ($(event.target).hasClass("txtRotateX") || event.target.id == "txtRotate") {
        $(event.target).val(parseFloat(Control.RotateAngle));
    }
    else if (event.target.id == "txtFontSize") {
        $("#txtFontSize").val(parseFloat(Control.FontSize).toFixed(4));
    }
    else if (event.target.id == "txtFontIndent") {
        $("#txtFontIndent").val(parseFloat(Control.Indent));
    }
    else if (event.target.id == "txtManulTracking") {
        $("#txtManulTracking").val(parseFloat(Control.ManualTracking));
    }
    else if (event.target.id == "txtC") {
        $("#txtC").val((parseFloat(Control.C) * 100).toFixed(2));
    }
    else if (event.target.id == "txtM") {
        $("#txtM").val((parseFloat(Control.M) * 100).toFixed(2));
    }
    else if (event.target.id == "txtY") {
        $("#txtY").val((parseFloat(Control.Y) * 100).toFixed(2));
    }
    else if (event.target.id == "txtK") {
        $("#txtK").val((parseFloat(Control.K) * 100).toFixed(2));
    }
    else if (event.target.id == "txtT") {
        $("#txtT").val((parseFloat(Control.Tint)).toFixed(2));
    }
    else {
        $(event.target).val("0");
    }
}



