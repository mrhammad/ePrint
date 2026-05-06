
function zoomTextCanvas(zoomCanvas, pageload) {
    var CanvasWidth = $("#LayoutCanvas").width();

    if (CType == "public" && pageload == true) {
        CanvasWidth = "690px";
    }

    $("#textCanvas").css({
        '-ms-transform': 'scale(' + zoomCanvas + ')',
        '-moz-transform': 'scale(' + zoomCanvas + ')',
        '-webkit-transform': 'scale(' + zoomCanvas + ')',
        '-ms-transform-origin': 'left top',
        '-moz-transform-origin': 'left top',
        '-webkit-transform-origin': 'left top'
    });
    var zoomText = Math.round(zoomCanvas * 100.00);
    $("#lblZoom").html(zoomText + "%");
    $("#rngslidesetzoom").val(zoomText);

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

function applyonexceedwidth(id) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

    var width = $("#" + Control.ObjectID).innerWidth();
    var width = $("#" + Control.ObjectID).outerWidth();
    var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
    width = width - LabelWidth;
    var TextWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth;

    defaultContent = Control.DefaultContent;

    defaultContent = capitalizeTheText(defaultContent, Control.Capitalize);
    
    if (Control.Type == "TextBlock") {
        if (Control.ExceedWidth == "Do Nothing") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                    defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);

                    $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "));
                    Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
                }
                fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
                alignsingleLineText(Control.ObjectID);
            }
            else {
                fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
                alignsingleLineText(Control.ObjectID);
                Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
            }
        }
        else if (Control.ExceedWidth == "Expand side") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
                Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
                Control.Width = Control.MaxWidth;
                fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
            }
            fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
            Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
        }
        else if (Control.ExceedWidth == "Shrink") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                var fontsize = Fontsize - 0.05;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth()) > width) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                    Control.FontSize = font * ptConvertionConstant;

                    if (LabelWidth == null) {
                        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                    }
                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                    Control.Height = Control.MaxHeight;
                    fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
                    fontsize = fontsize - 0.05;
                }

            }
            fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
            Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");

        }
        else if (Control.ExceedWidth == "Tracking") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth()) > width && parseFloat($("#txttextTrscking").val())) {
                if (Control.MaxShrink > 0) {
                    var spacing;
                    var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                    var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                    Control.MaxShrink = parseFloat($("#txttextTrscking").val()) / 100;
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
                }
                else {

                    while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                        defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);

                        $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "));
                        Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
                    }
                    fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
                    alignsingleLineText(Control.ObjectID);
                }

            }
            fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
            Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
        }
    }
}

/*completed*/
function changeThePageFromNavigation(PageNumber, Next) {

    if (TemplateDetails.ShowEditablePages == true && Next != "currentpage") {
        var PagesWithContols = pagesWithControlsList();
        var PageHasNoControl = true;
        for (var k = 0; k < PagesWithContols.length; k++) {
            if (PagesWithContols[k] == PageNumber) {
                PageHasNoControl = false;
                break;
            }
        }

        if (PageHasNoControl) {
            var nextPage = 0;
            if (Next) {
                for (var k = 0; k < PagesWithContols.length; k++) {
                    if (PagesWithContols[k] > PageNumber) {
                        nextPage = PagesWithContols[k];
                        break;
                    }
                }
            }
            else {
                for (var k = PagesWithContols.length - 1; k >= 0; k--) {
                    if (PagesWithContols[k] < PageNumber) {
                        nextPage = PagesWithContols[k];
                        break;
                    }
                }
            }
            if (nextPage != 0) {
                PageNumber = nextPage;
            }
            else {
                return null;
            }
        }
    }

    var ControllDetailsByPage = [];
    ControllDetails.map(function (proj) { if (proj.PageNumber == PageNumber) ControllDetailsByPage.push(proj) });



    //if (TemplateDetails.ShowEditablePages == true && ControllDetailsByPage.length == 0) {
    //    var Page = nextPageWithControls(PageNumber, Next);
    //    if (Page != "end" && Page != "start") {
    //        PageNumber = Page;
    //        ControllDetailsByPage = [];
    //        ControllDetails.map(function (proj) { if (proj.PageNumber == PageNumber) ControllDetailsByPage.push(proj) });
    //    }
    //}



    //var ImageUrl = $("#textCanvas").css('background-image');
    //var dotIndex = ImagePath.lastIndexOf('.');
    //var pagenumber = parseInt(PageNumber) - 1;
    //var Image = ImagePath.substr(0, dotIndex - 1) + pagenumber + '.png';
    //$("#textCanvas").css('background-image', "url('" + Image + "')");
    if (TemplateDetails.Totalpage != 1) {
        var pagenumber = parseInt(PageNumber) - 1;
        var dotIndex = ImagePath.lastIndexOf('.');
        var lastchar = ImagePath.split('.')[0][dotIndex - 2];
        var temp = 2;
        //while (ImagePath.split('.')[0][dotIndex - temp] != '-') {
        //    temp = temp + 1;
        //}
        var Image = ImagePath.substr(0, dotIndex - 1) + pagenumber + '.png';
        $("#textCanvas").css('background-image', "url('" + Image + "')");
    }
    $("#lblcurrentpage").html(PageNumber);
    $("#textCanvas").empty();
    $("#LeftPanelControl").empty();
    unbindMenuBar();

    for (var i = 0; i < ControllDetails.length; i++) {
        if (parseInt(ControllDetails[i].PageNumber) == PageNumber) {

            if (ControllDetails[i].TextAlign == "Center") {
                ControllDetails[i].PositionX = ControllDetails[i].OffsetLeft;
            }
            if (ControllDetails[i].TextAlign == "Right") {
                ControllDetails[i].PositionX = ControllDetails[i].OffsetLeft;
            }
            if (ControllDetails[i].TextAlign == "Left") {
                ControllDetails[i].PositionX = ControllDetails[i].OffsetLeft;
            }
            if (ControllDetails[i].TextAlign == "Justify") {
                ControllDetails[i].PositionX = ControllDetails[i].OffsetLeft;
            }

            if (ControllDetails[i].Labels == "Use Labels" && ControllDetails[i].GroupID == 0 && ControllDetails[i].CustomLeft > 0 && ControllDetails[i].TextAlign == "Left") {
                ControllDetails[i].PositionX = ControllDetails[i].OffsetLeft;
            }
        }
    }



    var ControllDetailsByorderNumber = JSON.parse(JSON.stringify(sortJSON(ControllDetailsByPage, "OrderNumber", "ASC")));

    for (var i = 0; i < ControllDetailsByorderNumber.length; i++) {
        if (parseInt(ControllDetailsByorderNumber[i].PageNumber) == PageNumber) {
            if (ControllDetailsByorderNumber[i].Type == "TextBlock") {
                LoadLeftPanelForText(ControllDetailsByorderNumber[i]);
                AddTextDynamically(ControllDetailsByorderNumber[i]);
            }
            else if (ControllDetailsByorderNumber[i].Type == "Image") {
                LoadLeftPanelForImage(ControllDetailsByorderNumber[i]);
                AddImageDynamically(ControllDetailsByorderNumber[i]);
            }
            else if (ControllDetailsByorderNumber[i].Type == "Paragraph") {
                LoadLeftPanelForPara(ControllDetailsByorderNumber[i]);
                AddParaDynamically(ControllDetailsByorderNumber[i]);
            }
        }
    }
    postionControlsGroupWise();
}

function fixPostionOfControll(Control, posXValue, posYValue, Alignment, pageLoad, movementOption) {



    var zoom = zoomvalue();
    var elementHeight = parseFloat($("#" + Control.ObjectID).innerHeight());
    var elementWidth = getControlWidth(Control) * mmConvertionConstant;

    var textcanvas = textCanvasHeight;

    var bottom = (posYValue * mmConvertionConstant);
    var left = posXValue * mmConvertionConstant;


    if (Alignment == "Right") {
        right = (textCanvasWidth - left);
        left = left - elementWidth;
        if (left < 0 && pageLoad != true && movementOption != true) {

            $("#Message").dialog("open");
            $("#msg").html("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            designMessageBox();
            getPosition();
            //alert("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            return false;
        }
        else {
            if (Control.Type == "TextBlock") {
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                posXValue = posXValue - Control.Width;

                //posXValue += (($("#" + Control.ObjectID + " .labelText").offset().left) - ($("#" + Control.ObjectID).offset().left)) / mmConvertionConstant;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
            }
            else {
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
            }

            $("#" + Control.ObjectID).css({ 'left': 'auto', 'right': right + "px", 'top': 'auto', 'bottom': bottom + "px" });
            //$(ID).css({ 'left': left, 'bottom': bottom });
            return true;
        }
    }
    else if (Alignment == "Center" && pageLoad != true && movementOption != true) {
        left = left - (parseFloat($("#" + Control.ObjectID).innerWidth() + 2) / 2);

        if (left < 0) {
            //alert("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            $("#Message").dialog("open");
            $("#msg").html("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            designMessageBox();
            getPosition();
            return false;
        }
        else {
            if (Control.Type == "TextBlock") {
                var width = getControlWidth(Control);
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                posXValue = posXValue - (parseFloat(Control.Width) / 2);

                //posXValue += (($("#" + Control.ObjectID + " .labelText").offset().left) - ($("#" + Control.ObjectID).offset().left)) / mmConvertionConstant;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
            }
            else {
                var width = getControlWidth(Control);
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
            }

            if (Control.Type == "Image") {
                left = left - 1;
                bottom = bottom - 1;
            }

            $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" });
            //$(ID).css({ 'left': left, 'top': top });
            return true;
        }
    }
    else {
        Control.PositionX = posXValue;
        Control.PositionY = posYValue;
        Control.OffsetLeft = posXValue;
        Control.OffsetTop = posYValue;

        if (Control.Labels == "Use Labels" && Control.LabelPosition == "customLeft") {
            left = left - Control.CustomLeft * mmConvertionConstant;
        }

        if (Control.Type == "Image") {
            left = left - 1;
            bottom = bottom - 1;
        }


        //$(ID).css({ 'left': left, 'top': top });
        $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" });
        return true;
    }
}


function functionalities(PositionLock, objectID, text) {
    if (PositionLock == false) {
    $(function () {
        $("#" + objectID).draggable({
            drag: function (evt, ui) {
                ui.position.top = ui.position.top / zoom;
                ui.position.left = ui.position.left / zoom;
                getPosition();
                //$("#" + selectedObjectID).css({ 'height': controlheight + "px" });
            },
            stop: function (evt, ui) {
                getPosition();
            },
            scroll: true,
            cursor: "move",
            scrollSensitivity: 100
        });


    });
    }


    $(document).ready(function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == objectID) Control = proj });

        if (Control.Edit == true) {
            $(".Image").unbind('dblclick').bind('dblclick', function () {
                var Control;
                ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
                var userImagePath = "", systemImagePath = "", noImagePath = "";

                var image = Control.OrignalImageName, ImagePath;

                systemImagePath = BackgroundImagesPath + "Gallery/OriginalImages/" + image;
                if (image == "noimage.png" || image == "noimage.jpg" || image == "") {
                    noImagePath = SiteImages + "noimage.jpg";
                }

                if (Control.IsFromBackEnd == false) {
                    userImagePath = FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + image;
                }
                 
                orgWidthCrop=parseInt(Control.Width * mmConvertionConstant);
                orgHeightCrop=  parseInt(Control.Height * mmConvertionConstant);
              

                checkForOriginalFile(userImagePath, systemImagePath, noImagePath, image);

            });
        }

        $(".Text .labelText").mousedown(function () {

            deSelect();
            var id = $(this).parent().attr('id');
            var posXValue = (($("#" + id + " .labelText").position().left) - 2) / mmConvertionConstant;
            $(this).css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });

            var leftPanelid = "#" + id + "_txt";
            $(leftPanelid).css('background-color', 'rgba(233, 245, 248,255)');
            changeSelectedControllID();
            bindMenuBar(selectedObjectID);
            setTimeout(function () { $(leftPanelid).focus() }, 100);
        });
        $(".Para p").mousedown(function () {
            deSelect();
            var id = $(this).parent().attr('id');
            $(this).css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });

            var leftPanelid = "#" + id + "_txt";
            $(leftPanelid).css('background-color', 'rgba(233, 245, 248,255)');
            changeSelectedControllID();
            bindMenuBar(selectedObjectID);
            setTimeout(function () { $(leftPanelid).focus() }, 100);
        });
        $(".Image").mousedown(function () {
            deSelect();
            $(this).css('border', '1px solid #B2B2B2');
            $(this).css('cursor', 'pointer');
            changeSelectedControllID();
            bindMenuBar(selectedObjectID);
        });


        $(".Text .labelText").unbind('mouseenter').bind('mouseenter', function () {

            if ($(this).css('border-right-color') == "transparent") {
                $(this).css('border', '1px dashed rgb(128, 128, 129)');
            }
            if ($(this).css('border-right-color') == "rgba(0, 0, 0, 0)") {
                $(this).css('border', '1px dashed rgb(128, 128, 129)');
            }

        });
        $(".Para p").unbind('mouseenter').bind('mouseenter', function () {

            if ($(this).css('border-right-color') == "transparent") {
                $(this).css('border', '1px dashed rgb(128, 128, 129)');
            }
            if ($(this).css('border-right-color') == "rgba(0, 0, 0, 0)") {
                $(this).css('border', '1px dashed rgb(128, 128, 129)');
            }
        });
        $(".Image").unbind('mouseenter').bind('mouseenter', function () {
            if ($(this).css('border-left-color') == "transparent") {
                $(this).css('border', '1px solid rgb(178, 178, 179)');
            }
            if ($(this).css('border-left-color') == "rgba(0, 0, 0, 0)") {
                $(this).css('border', '1px solid rgb(178, 178, 179)');
            }
        });
        $(".Text .labelText").unbind('mouseleave').bind('mouseleave', function () {
            if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                $(this).css('border', '1px dashed transparent');
            }
            if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                $(this).css('border', '1px dashed rgba(0, 0, 0, 0)');
            }
        });
        $(".Para p").unbind('mouseleave').bind('mouseleave', function () {
            if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                $(this).css('border', '1px dashed transparent');
            }
            if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                $(this).css('border', '1px dashed rgba(0, 0, 0, 0)');
            }
        });
        $(".Image").unbind('mouseleave').bind('mouseleave', function () {
            if ($(this).css('border-left-color') == "rgb(178, 178, 179)") {
                $(this).css('border', '1px solid transparent');
            }
            if ($(this).css('border-left-color') == "rgb(178, 178, 179)") {
                $(this).css('border', '1px solid rgba(0, 0, 0, 0)');
            }
        });
    });
}

function deSelect() {
    $(".Text .labelText").css('border', '1px dashed transparent');
    $(".Para p").css('border', '1px dashed transparent');
    $(".Image").css('border', '1px solid transparent');
    $(".Text").css('cursor', 'pointer');
    $(".Para").css('cursor', 'pointer');
    $(".Image").css('cursor', 'pointer');
    $(".textbox").css('background-color', 'white');
    $(".TxtArea").css('background-color', 'white');
}

function LoadDefaultContent(Text, id) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

    var UserText = Text;

    if (Control.ExceedWidth != "Do Nothing") {
        Control.DefaultContent = UserText;
    }

    var defaultContent = capitalizeTheText(Text, Control.Capitalize);
    debugger;
    var width = $("#" + Control.ObjectID).width();

    if ($("#" + Control.ObjectID).hasClass('Text')) {

        if (defaultContent == "") {
            $("#" + Control.ObjectID + " .label").css({ 'display': 'none' });
        }
        else {
            $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block' });
        }

        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        width = width + 2 - LabelWidth;
        var TextWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth;

        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);


        if (Control.ExceedWidth == "Do Nothing") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                    defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                    UserText = UserText.substr(0, UserText.length - 1);
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "));
                }
            }
            fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
            Control.DefaultContent = UserText;
        }
        else if (Control.ExceedWidth == "Expand side") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
                Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
                Control.Width = Control.MaxWidth;
            }
            fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
        else if (Control.ExceedWidth == "Shrink") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
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

                    fontsize = fontsize - 0.05;
                }
            }
            else if (Control.FontSize < Control.OriginalFontSize) {
                var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                var fontsize = Fontsize + 0.05;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth()) < width && Control.FontSize < Control.OriginalFontSize) {
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
                    fontsize = fontsize + 0.05;
                }
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
                    fontsize = fontsize - 0.05;
                }
            }
            ;
            fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
        else if (Control.ExceedWidth == "Tracking") {
            if (Control.MaxShrink == 0) {
                if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                    while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                        defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                        UserText = UserText.substr(0, UserText.length - 1);
                        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                        $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "));
                    }
                }
                fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
                alignsingleLineText(Control.ObjectID);
                Control.DefaultContent = UserText;
            }
            else if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                var spacing;
                var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                var letterSpacing = LetterSpacing - Control.MaxShrink;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                    $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                    letterSpacing = letterSpacing - Control.MaxShrink;
                    Control.ManualTrackSign = spacing[0];
                    Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                    Control.ManualTrackDimension = "pt";
                }

            }
            else if (parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing')) < parseFloat(Control.ManualTrackingOriginal)) {

                var spacing;
                var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                var letterSpacing = LetterSpacing + Control.MaxShrink;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) < width && parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing')) < parseFloat(Control.ManualTrackingOriginal)) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                    $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                    letterSpacing = letterSpacing + Control.MaxShrink;
                    Control.ManualTrackSign = spacing[0];
                    Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                    Control.ManualTrackDimension = "pt";
                }
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                    $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                    letterSpacing = letterSpacing - Control.MaxShrink;
                    Control.ManualTrackSign = spacing[0];
                    Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                    Control.ManualTrackDimension = "pt";
                }
            }
            fixPostionOfControll(Control.ObjectID, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);

        }
        if (Control.GroupID == 0) {
            if (Control.DefaultContent != "") {
                var KeepotionList;
                if (Control.KeepOptions == "None") {

                }
                else {
                    KeepOptionPositioning(Control.ObjectID, Control.KeepOptions);
                }
            }
        }
        else {
            //countGroupCntrl(Control.ObjectID, Control.GroupID, false);
            if (Control.GroupOrientation == "Vertical") {
                if (Control.DefaultContent != "") {
                    var Group;
                    VerticalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });
                    if (Group.GroupOption == "None" || Group.GroupOption == "") {
                        VerticalGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
                    }
                    else {
                        KeepOptionPositioning(Control.ObjectID, Group.GroupOption);
                    }
                }
            }
            else if (Control.GroupOrientation == "Horizontal") {
                if (Control.DefaultContent != "") {
                    var Group;
                    HorizontalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });
                    if (Group.GroupOption == "None" || Group.GroupOption == "") {
                        HorizontalGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
                    }
                    else {
                        KeepOptionPositioning(Control.ObjectID, Group.GroupOption);
                    }
                }
            }
        }
    }
    if ($("#" + Control.ObjectID).hasClass('Para')) {

        if (Control.ExceedHeight != "Do Nothing") {
            Control.DefaultContent = UserText;
        }


        defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>");
        var Text = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">").replace(/<br>/g, "\n");
        $("#" + Control.ObjectID + " .paraText").html(defaultContent.replace(/&nbsp;/g, " "));

        if (Control.ExceedHeight == "Do Nothing") {
            if (($("#" + Control.ObjectID + " .paraText").outerHeight() - 2) > ($("#" + Control.ObjectID).outerHeight() + 2)) {
                while (($("#" + Control.ObjectID + " .paraText").outerHeight() - 2) > ($("#" + Control.ObjectID).outerHeight() + 2)) {
                    Text = Text.substr(0, Text.length - 1);
                    $("#" + Control.ObjectID + " .paraText").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>").replace(/&nbsp;/g, " "));
                }
            }
            Control.DefaultContent = Text;
            $("#" + Control.ObjectID + "_txt").val(Text);
        }
        else if (Control.ExceedHeight == "Expand Height") {
            if (($("#" + Control.ObjectID + " .paraText").outerHeight() - 2) > ($("#" + Control.ObjectID).outerHeight() + 2)) {
                $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .paraText").outerHeight());
                Control.Height = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
            }
        }

        if (Control.GroupID == 0) {
            var KeepotionList;
            if (Control.GroupOrientation == "Vertical") {
                KeepotionList = getKeepOptionControlsByObjectIDForVertical(Control.GroupOrientation, Control.KeepOptions);
            }
            else {
                //KeepotionList = getKeepOptionControlsByObjectIDForHorizontal(Control.GroupOrientation, Control.KeepOptions);
            }
            //if (KeepotionList.length >= 2) {
            //    KeepOptionPositioning(Control.ObjectID, Control.KeepOptions);
            //}
            //else {
            //    if (fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign)) {
            //        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
            //        if ($("#" + Control.ObjectID).hasClass('Para')) {
            //            $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
            //        }
            //    }
            //}
        }
        else {
            if (Control.GroupOrientation == "Vertical") {
                if (Control.DefaultContent != "") {

                    var Group;
                    VerticalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });
                    if (Group.GroupOption == "None" || Group.GroupOption == "") {
                        VerticalGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
                    }
                    else {
                        KeepOptionPositioning(Control.ObjectID, Group.GroupOption);
                    }
                }
            }
            else if (Control.GroupOrientation == "Horizontal") {
                if (Control.DefaultContent != "") {
                    var Group;
                    HorizontalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });
                    if (Group.GroupOption == "None" || Group.GroupOption == "") {
                        HorizontalGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
                    }
                    else {
                        KeepOptionPositioning(Control.ObjectID, Group.GroupOption);
                    }
                }
            }
        }
    }
}

function loadimage() {
    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].Type == "Image" && ControllDetails[i].ExceedWidth == "P") {
            var width = parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerWidth());
            var height = parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerHeight());
            var proptionality = width / height;
            while (parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerHeight()) >= parseFloat(ControllDetails[i].MaxHeight) * mmConvertionConstant && parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerWidth()) >= parseFloat(ControllDetails[i].MaxWidth) * mmConvertionConstant) {
                if (parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerHeight()) >= parseFloat(ControllDetails[i].MaxHeight) * mmConvertionConstant) {
                    $("#" + ControllDetails[i].ObjectID + " img").css({ 'height': parseFloat(ControllDetails[i].MaxHeight) * mmConvertionConstant + 'px' });
                }
                if (parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerWidth()) >= parseFloat(ControllDetails[i].MaxWidth) * mmConvertionConstant) {
                    $("#" + ControllDetails[i].ObjectID + " img").css({ 'width': parseFloat(ControllDetails[i].MaxWidth) * mmConvertionConstant + 'px' });
                }
            }
        }
    }
}

function saveTemplate(Button) {
    var error = false;
    $.ajax({
        url: ServicePath + "DeleteWsTemplateProperties",
        type: "POST",
        data: JSON.stringify({ templateid: TemplateID, cartitemid: CartitemID, companyid: CompanyID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (resultFromSevice) {
            if (resultFromSevice.d == false) {
                error = true;
            }

            SaveTemplateProperties(Button, error);
        },
        error: function (error, et) {
            error = true;
            showSavedPopup(Button, error);
        }
    });
}

function SaveTemplateProperties(Button, error) {
    if (ControllDetails.length > 0) {
        for (var i = 0; i < ControllDetails.length; i++) {
            var control = JSON.stringify(ControllDetails[i]);
            $.ajax({
                url: ServicePath + "InsertTemplateProperties",
                type: "POST",
                data: JSON.stringify({ PropertiesDetail: control, templateid: TemplateID, sessionid: SesionID, userid: UserID, companyid: CompanyID, cartitemid: CartitemID, _key: DBKey, lastone: (i == ControllDetails.length - 1) }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (resultFromSevice) {
                    if (resultFromSevice.d.split(',')[0].toLowerCase() == "false") {
                        error = true;
                    }
                    if (resultFromSevice.d.split(',')[1].toLowerCase() == "true") {

                        showSavedPopup(Button, error);

                    }
                },
                error: function (error, et) {
                    error = true;
                }
            });
        }
    }
    else {
        showSavedPopup(Button, error);
    }

}

function showSavedPopup(Button, error) {

    if (!error) {

        if (Button != btnPrevious && TemplateDetails.SendAttachment == true) {
            $.ajax({
                url: ServicePath + "CreateImageForAttachment",
                type: "POST",
                data: JSON.stringify({ templateid: TemplateID, cartitemid: CartitemID, companyid: CompanyID, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (resultFromSevice) {
                }
            });
        }
        if (Button == "btnSavetodraft") {
            $(".loading_new").hide();

            $("#SaveDraftPopUp").dialog("open");
            $("#txtProductName").val(ProductName.trim());
            designMessageBox();

        }
        if (Button == "btnpreview" || Button == "btnPreviewAndAddCart") {
            debugger;
            $.ajax({
                url: ServicePath + "UpdatePreviewStatus",
                type: "POST",
                data: JSON.stringify({ CartItemId: CartitemID, PDFname: "", _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (resultFromSevice) {
                    if (resultFromSevice.d) {
                        var url = B2BSitePath + "preview_HTML5.aspx?ID=" + PriceCatalogId + "&CartItemID=" + CartitemID + "&TemplateID=" + TemplateID + "&CompanyID=" + CompanyID;
                        window.top.location.href = url;
                        //$(".loading_new").hide();
                        //var url = "http://localhost:52468/PDFSamples/ServerDataTest.aspx?TemplateID=" + TemplateID + "&SessionID=" + SesionID + "&CompanyID=" + CompanyID;
                        //window.open(url, '_blank', 'toolbar=0,location=0,menubar=0');
                    }
                }
            });
        }
        if (Button == "btnPrevious") {
            var url = "";
            if (CType == "public") {
                url = B2BSitePath + "products/~" + PriceCatalogId + "~" + CartitemID + ".aspx";
            }
            else {
                url = B2BSitePath + "products/productdetails.aspx?ID=" + PriceCatalogId + "&CartItemID=" + CartitemID;
            }
            window.top.location.href = url;
        }
        if (Button == "btnAddtoCart") {

            $.ajax({
                url: ServicePath + "UpdateAddCartStatus",
                type: "POST",
                data: JSON.stringify({ CartItemId: CartitemID, PDFname: "", _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (resultFromSevice) {
                    if (resultFromSevice.d) {
                        var url = B2BSitePath + "BlanckPageForCart.aspx?ID=" + PriceCatalogId + "&CartItemID=" + CartitemID + "&TemplateID=" + TemplateID + "&CompanyID=" + CompanyID;
                        window.top.location.href = url;
                    }
                }
            });
        }

    }
    else {
        $("#SaveMessage").dialog("open");
        $("#savemsg").html("Error occured, please reload the browser.");
        designMessageBox();
        $("div[aria-describedby=SaveMessage]").css('z-index', '114');
        $(".loadingNewMask").show();
    }
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
}

/*completed*/
function designMessageBox() {

    $("div[aria-describedby=MandatoryMessage] .ui-widget-header img").remove();
    $("div[aria-describedby=MandatoryMessage] .ui-widget-header").prepend("<img src='StyleSheets/Images/info.png' width='20' height='20' style='float:left;margin-left:5px;margin-right:10px;' />");
    $("div[aria-describedby=Message] .ui-widget-header img").remove();
    $("div[aria-describedby=MandatoryMessage] .ui-dialog-title").css('width', '200px');
    $("div[aria-describedby=Message] .ui-widget-header").prepend("<img src='StyleSheets/Images/info.png' width='20' height='20' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });

    $("#msg").css({ 'font-family': 'arial', 'font-size': '14px' });
    $(".ui-widget-header").css({ 'border-bottom': '1px solid white' });
    $("#SaveDraftPopUp").css({ 'margin-bottom': '5px', 'border-bottom-width': '1px', 'padding': '10px 0px 0px 0px' });
    $(".ui-dialog-titlebar-close").css({ 'background': 'none', 'background': ' transparent', 'border-color': 'transparent' });
    $("#Message").css({ 'height': 'auto' });
    $("#ImageFromGallery,#CreateCategory,#EditCategory,#UploadImage,#ImageDetails").css({ 'margin-bottom': '5px', 'border-bottom-width': '1px', 'padding': '10px 0px 0px 0px' });
    $('div[aria-describedby=MandatoryMessage] .ui-dialog-buttonset .ui-button').css({ 'height': '22px', 'width': '75px', 'margin': '0px 20px 0px 10px', 'border': '1px solid #a3a3a3', 'background': 'none', 'background': ' linear-gradient(#E8E8E8,  #F9F8F8)', 'font-family': ' Verdana', 'font-size': '11px', 'color': '#000000', 'border-radius': '5px', 'cursor': 'pointer', 'text-shadow': '0 1px 1px rgba(0,0,0,.3)', 'box-shadow': '0 1px 2px rgba(0,0,0,.2)' });
    $('div[aria-describedby=Message] .ui-dialog-buttonset .ui-button').css({ 'height': '22px', 'width': '75px', 'margin': '0px 20px 0px 10px', 'border': '1px solid #a3a3a3', 'background': 'none', 'background': ' linear-gradient(#E8E8E8,  #F9F8F8)', 'font-family': ' Verdana', 'font-size': '11px', 'color': '#000000', 'border-radius': '5px', 'cursor': 'pointer', 'text-shadow': '0 1px 1px rgba(0,0,0,.3)', 'box-shadow': '0 1px 2px rgba(0,0,0,.2)' });
    $("div[aria-describedby=SaveMessage] .ui-dialog-buttonset").css({ 'margin-bottom': '10px' });
    $("div[aria-describedby=MandatoryMessage] .ui-dialog-buttonset").css({ 'margin-bottom': '10px' });
    $("div[aria-describedby=Message] .ui-dialog-buttonset").css({ 'margin-bottom': '10px' });
    $("#SaveMessage").css({ 'height': 'auto !important', 'white-space': 'nowrap !important' });
}

/*Control delete Function*/
function deleteTheControll() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


    $("#" + Control.ObjectID).remove();
    $("#" + Control.ObjectID + "_row").remove();
    Control.Visibility = false;

    unbindMenuBar();
}
/*End of  delete Function*/


/*Clear all Control Function*/
function clearAllControlls() {

    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].PageNumber == parseInt($("#lblcurrentpage").html())) {
            ControllDetails[i].Visibility = false;
        }
    }
    $("#LeftPanelControl").empty();
    $("#textCanvas").empty();
    unbindMenuBar();
}
/*End of  Clear Function*/

function changeSelectedControllID() {
    $("#textCanvas > .controll").each(function () {

        var id = $(this).attr('id');
        if ($("#" + id + " .labelText").css('border-right-color') == 'rgb(128, 128, 128)' || $("#" + id + " p").css('border-right-color') == 'rgb(128, 128, 128)' || $(this).css('border-left-color') == 'rgb(178, 178, 178)') {
            selectedControllID = "#" + id;
            selectedObjectID = id;
        }
    });
}

function applyFontToSelectedText(FontNameandFontid) {
    debugger;
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
            $("#" + Control.ObjectID + " p").css('font-family', uniquefontname);
        }

        Control.FontFamily = fontname;
        Control.ActualFontName = ActualfontName;
        Control.FontID = parseFloat(fontid);
        Control.FontExtension = fontpathName;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        alignsingleLineText(Control.ObjectID);
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
        $("#" + Control.ObjectID + " p").css('font-size', ((parseFloat(Control.FontSize)) / ptConvertionConstant) + "px");
    }
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

/*Adding New contol to the List and the canvas Function whne Admin allow user to add New Control*/
function AddNewText() {

    var numItems = $('.controll').length;

    var GUID = Guid();
    numItems = 1 + numItems;
    var jsonStringFotText;
    var defaulttop = 10;
    var PostionY = ((parseFloat($("#textCanvas").innerHeight()) / mmConvertionConstant) + (2 * CropMarkHeight)) - defaulttop;
    var PostionX = (parseFloat($("#textCanvas").innerWidth()) / mmConvertionConstant) / 2;
    var page = parseInt($("#lblcurrentpage").html());
    jsonStringFotText = JSON.parse(JSON.stringify({
        "__type": "TemplateEditorFrontEnd.TemplateFieldProperties",
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
        "UserFontSyleName": null,
        "ColorID": 0,
        "UserColorStyleName": null,
        "ManualTrackSign": "+",
        "ManualTrackDimension": "pt",
        "CopyTemplateName": null,
        "CopyTemplateID": 0,
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
        "BackgroundColor": "",
        "ExceedImage": "",
        "CustomRight": 0,
        "ObjectID": GUID,
        "FieldName": "Text" + numItems,
        "FriendlyName": "Textblock" + numItems,
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
        "DefaultContent": "Text" + numItems,
        "DatabaseContent": "",
        "Dropdowns": "None",
        "Labels": "None",
        "ObjValue": "",
        "LabelValue": "",
        "LabelStyle": "Arial",
        "LabelColor": "",
        "LabelPosition": "Attached",
        "Mandatory": false,
        "Edit": true,
        "Visibility": true,
        "HideVisibility": false,
        "Lock": false,
        "SpotColor": false,
        "PageNumber": page,
        "PositionX": PostionX,
        "PositionY": PostionY,
        "MaxWidth": 49.9983,
        "ManualTracking": 0,
        "MaxShrink": 0,
        "RotateAngle": 0,
        "FontSize": 10,
        "Indent": 0,
        "Tint": 100,
        "CustomLeft": 0,
        "CustomTop": 0,
        "Copy": false,
        "PositionOffset": 20,
        "OffsetLeft": 20,
        "OffsetTop": 194.667,
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
        "TextDecoration": null,
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
        "ObjType": null,
        "Tag": null,
        "Label": null,
        "ActualField": null,
        "ContentType": null,
        "ZIndexValue": numItems,
        "IsCropFromTop": false,
        "IsFromBackEnd": false,
        "EditedImageName": "",
        "FontStyleName": "",
        "BackgroundImage": "",
        "FontStyleName": "",
        "KeepOptions": "None",
        "IsCropped": false,
        "IsImageQuality": false,
        "MinDPI": 0,
        "isDisplayonPDf": false
    }))
    deSelect();
    ControllDetails.push(jsonStringFotText);

    LoadLeftPanelForText(jsonStringFotText);
    AddTextDynamically(jsonStringFotText, true);
}

function AddNewImage() {

    var numItems = $('.controll').length;
    var GUID = Guid();
    numItems = 1 + numItems;
    var jsonStringFotText;
    var _defaultparapos = 35;
    var PostionY = ((parseFloat($("#textCanvas").innerHeight()) / mmConvertionConstant) + (2 * CropMarkHeight)) - _defaultparapos;
    var PostionX = (parseFloat($("#textCanvas").innerWidth()) / mmConvertionConstant) / 2;

    var page = parseInt($("#lblcurrentpage").html());
    jsonStringFotText = JSON.parse(JSON.stringify({
        "__type": "TemplateEditorFrontEnd.TemplateFieldProperties",
        "IsJustify": false,
        "OrignalImageName": "noimage.png",
        "LabelFontStyle": "",
        "FontID": 0,
        "LabelFontID": 0,
        "PhraseType": "",
        "PhraseBookID": 0,
        "FontSyleID": 0,
        "ParaLineSpace": 0,
        "ActualFontName": "",
        "LabelFontSize": 0,
        "FontExtension": "",
        "LabelFontExtension": "",
        "LabelActualFontName": "",
        "UserFontSyleName": null,
        "ColorID": 0,
        "UserColorStyleName": null,
        "ManualTrackSign": "+",
        "ManualTrackDimension": "pt",
        "CopyTemplateName": null,
        "CopyTemplateID": 0,
        "ImageLocation": "TL",
        "KeepOption": "None",
        "GroupOrientation": "None",
        "ImageSource": "h",
        "ImageGallery": "",
        "LabelValue": "",
        "R": 0,
        "OrderNumber": numItems,
        "G": 0,
        "B": 0,
        "A": 0,
        "ExceedHeight": "",
        "MaxHeight": ImageHeight,
        "UnderlineText": false,
        "BackgroundColor": "",
        "ExceedImage": "P",
        "CustomRight": 0,
        "ObjectID": GUID,
        "FieldName": "Image" + numItems,
        "FriendlyName": "Image" + numItems,
        "HelpText": "",
        "ExceedWidth": "",
        "FontStyle": "",
        "Font": "",
        "TextAlign": "",
        "Capitalize": "",
        "DataType": "",
        "Format": "",
        "ColorStyle": "",
        "Color": "",
        "C": "",
        "M": "",
        "Y": "",
        "K": "",
        "SpotColorRef": "",
        "DefaultContent": "",
        "DatabaseContent": "",
        "Dropdowns": "",
        "Labels": "",
        "ObjValue": "",
        "LabelStyle": "",
        "LabelColor": "",
        "LabelPosition": "",
        "Mandatory": false,
        "Edit": true,
        "Visibility": true,
        "HideVisibility": false,
        "Lock": false,
        "SpotColor": false,
        "PageNumber": page,
        "PositionX": PostionX,
        "PositionY": PostionY,
        "MaxWidth": ImageHeight,
        "ManualTracking": 0,
        "MaxShrink": 0,
        "RotateAngle": 0,
        "FontSize": 0,
        "Indent": 0,
        "Tint": 0,
        "CustomLeft": 0,
        "CustomTop": 0,
        "Copy": false,
        "PositionOffset": 116.821,
        "OffsetLeft": PostionX,
        "OffsetTop": PostionY,
        "ObjTag": "",
        "GroupID": 0,
        "ImgUrl": "noimage.png",
        "Align": "Left",
        "Top": PostionY,
        "Left": PostionX,
        "Width": ImageHeight,
        "Height": ImageHeight,
        "FontFamily": "",
        "FontWeight": "",
        "TextDecoration": null,
        "OffsetWidth": "",
        "OffsetHeight": "",
        "PixelWidth": "",
        "PixelHeight": "18.6751700000",
        "Type": "Image",
        "CanMove": true,
        "CanChangeFontColor": false,
        "CanChangeFontSize": false,
        "CanChangeFont": false,
        "ObjType": null,
        "Tag": null,
        "Label": null,
        "ActualField": null,
        "ContentType": null,
        "ZIndexValue": numItems,
        "IsCropFromTop": false,
        "IsFromBackEnd": false,
        "EditedImageName": "",
        "FontStyleName": "",
        "BackgroundImage": "",
        "FontStyleName": "",
        "KeepOptions": "None",
        "IsCropped": false,
        "IsImageQuality": false,
        "MinDPI": 0,       
        "isDisplayonPDf": false
    }))
    deSelect();
    ControllDetails.push(jsonStringFotText);
    LoadLeftPanelForImage(jsonStringFotText);
    AddImageDynamically(jsonStringFotText, true);
}

function AddNewPara() {

    var numItems = $('.controll').length;
    var GUID = Guid();
    numItems = 1 + numItems;
    var jsonStringFotText;
    var _defaultparapos = 35;
    var PostionY = (parseFloat($("#textCanvas").innerHeight()) / mmConvertionConstant) - _defaultparapos;
    var PostionX = (parseFloat($("#textCanvas").innerWidth()) / mmConvertionConstant) / 2;
    var page = parseInt($("#lblcurrentpage").html());
    jsonStringFotText = JSON.parse(JSON.stringify({
        "__type": "TemplateEditorFrontEnd.TemplateFieldProperties",
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
        "UserFontSyleName": null,
        "ColorID": 0,
        "UserColorStyleName": null,
        "ManualTrackSign": "+",
        "ManualTrackDimension": "pt",
        "CopyTemplateName": null,
        "CopyTemplateID": 0,
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
        "MaxHeight": ParaHeight,
        "UnderlineText": false,
        "BackgroundColor": "",
        "ExceedImage": "",
        "CustomRight": 0,
        "ObjectID": GUID,
        "FieldName": "Paragraph" + numItems,
        "FriendlyName": "Paragraph" + numItems,
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
        "DefaultContent": "Paragraph" + numItems,
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
        "Lock": false,
        "SpotColor": false,
        "PageNumber": page,
        "PositionX": PostionX,
        "PositionY": PostionY,
        "MaxWidth": 49.9983,
        "ManualTracking": 0,
        "MaxShrink": 0,
        "RotateAngle": 0,
        "FontSize": 10,
        "Indent": 0,
        "Tint": 100,
        "CustomLeft": 0,
        "CustomTop": 0,
        "Copy": false,
        "PositionOffset": 20,
        "OffsetLeft": 20,
        "OffsetTop": 194.667,
        "ObjTag": "",
        "GroupID": 0,
        "ImgUrl": "",
        "Align": "Left",
        "Top": PostionY,
        "Left": PostionX,
        "Width": 49.9983,
        "Height": ParaHeight,
        "FontFamily": "Arial",
        "FontWeight": "Normal",
        "TextDecoration": null,
        "OffsetWidth": "9.41122909",
        "OffsetHeight": "4.05694461",
        "OffsetTop": PostionY,
        "OffsetLeft": PostionX,
        "PixelWidth": "20",
        "PixelHeight": "3.1935200000",
        "Type": "Paragraph",
        "CanMove": true,
        "CanChangeFontColor": true,
        "CanChangeFontSize": true,
        "CanChangeFont": true,
        "ObjType": null,
        "Tag": null,
        "Label": null,
        "LabelValue": "",
        "ActualField": null,
        "ContentType": null,
        "ZIndexValue": numItems,
        "IsCropFromTop": false,
        "IsFromBackEnd": false,
        "EditedImageName": "",
        "FontStyleName": "",
        "BackgroundImage": "",
        "FontStyleName": "",
        "KeepOptions": "None",
        "IsCropped": false,
        "IsImageQuality": false,
        "MinDPI": 0,
        "isDisplayonPDf": false
    }))
    deSelect();
    ControllDetails.push(jsonStringFotText);

    LoadLeftPanelForPara(jsonStringFotText);
    AddParaDynamically(jsonStringFotText, true);
}

function changePositioXY(posXValue, posYValue) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.OffsetLeft = $('#txtPostionX').val();
    Control.OffsetTop = $('#txtPostionY').val();

    if (fixPostionOfControll(Control, posXValue + CropMarkWidth, posYValue + CropMarkHeight, Control.TextAlign)) {
        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
        if ($("#" + Control.ObjectID).hasClass('Para')) {
            $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
        }
    }
}

/*completed*/
function capitalizeTheText(DefaultContent, Capitalize) {
    debugger;
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
    else if (Capitalize == "InitCapAllowCaps") {

        var firstLetter = DefaultContent.substr(0, 1).toUpperCase();
        var remaingString = DefaultContent.substr(1, DefaultContent.length - 1);
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
    else if (Capitalize == "FirstCapAllowCaps") {

        var Words = DefaultContent.split(" ");
        for (var i = 0; i < Words.length; i++) {
            if (Words[i] != "") {
                var firstLetter = Words[i][0].toUpperCase();
                var remaingString = Words[i].substr(1, Words[i].length - 1);
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

    return defaultContent;
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

function getPosition() {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var zoom = zoomvalue();
    var elementHeight = parseFloat($("#" + Control.ObjectID).outerHeight());
    var elementWidth = parseFloat($("#" + Control.ObjectID).outerWidth());

    var Position = $("#" + Control.ObjectID).position();


    var top = (($("#textCanvas").outerHeight()) * zoom) - (parseFloat(Position.top) + (elementHeight * zoom));
    var topFinal = (top / zoom) / mmConvertionConstant;
    var leftFinal = parseFloat(Position.left) / mmConvertionConstant;



    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        Control.PositionX = parseFloat(leftFinal) / zoom;
        Control.PositionY = parseFloat(topFinal) / zoom;

        if (Control.TextAlign == "Left") {
            leftFinal = leftFinal;
            if (Control.Labels == "Use Labels" && Control.LabelPosition == "customLeft") {
                leftFinal = parseFloat(leftFinal + Control.CustomLeft);
            }
        }
        else if (Control.TextAlign == "Center") {
            leftFinal = parseFloat(leftFinal + ((elementWidth) / 2));
        }
        else if (Control.TextAlign == "Right") {
            leftFinal = parseFloat(leftFinal + (elementWidth));
        }

        $("#txtPostionX").val(((parseFloat(leftFinal) / zoom)).toFixed(2));
        $("#txtPostionY").val(((parseFloat(topFinal) / zoom)).toFixed(2));

        Control.OffsetLeft = parseFloat(leftFinal) / zoom;
        Control.OffsetTop = parseFloat(topFinal) / zoom;

    }
    else if ($("#" + Control.ObjectID).hasClass('Image')) {
        Control.PositionX = parseFloat(leftFinal) / zoom;
        Control.PositionY = parseFloat(topFinal) / zoom;
        $("#txtPostionX").val(((parseFloat(leftFinal) / zoom)).toFixed(2));
        $("#txtPostionY").val(((parseFloat(topFinal) / zoom)).toFixed(2));
        Control.OffsetLeft = parseFloat(leftFinal) / zoom;
        Control.OffsetTop = parseFloat(topFinal) / zoom;
    }


}

/*completed*/
function unbindMenuBar() {
    $("#btnRightAlign").removeClass('menubuttonSelected');
    $("#btnLeftAlign").removeClass('menubuttonSelected');
    $("#btnCenterAlign").removeClass('menubuttonSelected');
    $("#btnBold").removeClass('menubuttonSelected');
    $("#btnItalic").removeClass('menubuttonSelected');
    $("#drpFontID" + 0).prop('selected', true);
    $("#drpFont").prop('disabled', true);
    $("#txtPostionX").prop("disabled", true);
    $("#txtPostionY").prop("disabled", true);
    $("#txtFontSize").prop("disabled", true);
    $("#txtRotate").prop("disabled", true);
    $("#txtPostionX").val("");
    $("#txtPostionY").val("");
    $("#txtFontSize").val("");
    $("#txtRotate").val("");
}

function bindMenuBar(ObjectID) {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == ObjectID) Control = proj });


    $("#txtPostionX").prop("disabled", false);
    $("#txtPostionY").prop("disabled", false);
    $("#txtFontSize").prop("disabled", false);
    $("#txtRotate").prop("disabled", false);

    if (Control.Lock == true) {

        $("#txtPostionX").prop("disabled", true);
        $("#txtPostionY").prop("disabled", true);
    }
    else {
        $("#txtPostionX").prop("disabled", false);
        $("#txtPostionY").prop("disabled", false);
    }

    $("#txtPostionX").val(parseFloat(Control.OffsetLeft - CropMarkWidth).toFixed(2));
    $("#txtPostionY").val(parseFloat(Control.OffsetTop - CropMarkHeight).toFixed(2));

    if (Control.Type.toLowerCase() == "textblock" || Control.Type.toLowerCase() == "paragraph") {
        $("#chkSetImgAsBckgrnd").prop("disabled", true);
        if (Control.FontWeight == "Normal") {
            $("#btnBold").removeClass('menubuttonSelected');
        }
        else {
            $("#btnBold").addClass('menubuttonSelected');
        }
        if (Control.FontStyle == "Normal") {
            $("#btnItalic").removeClass('menubuttonSelected');
        }
        else {
            $("#btnItalic").addClass('menubuttonSelected');
        }
        if (Control.TextAlign == 'Left') {
            $("#btnLeftAlign").addClass('menubuttonSelected');
            $("#btnCenterAlign").removeClass('menubuttonSelected');
            $("#btnRightAlign").removeClass('menubuttonSelected');
        }
        else if (Control.TextAlign == 'Center') {
            $("#btnCenterAlign").addClass('menubuttonSelected');
            $("#btnLeftAlign").removeClass('menubuttonSelected');
            $("#btnRightAlign").removeClass('menubuttonSelected');
        }
        else if (Control.TextAlign == 'Right') {
            $("#btnRightAlign").addClass('menubuttonSelected');
            $("#btnLeftAlign").removeClass('menubuttonSelected');
            $("#btnCenterAlign").removeClass('menubuttonSelected');
        }

        $("#drpFont").prop('disabled', false);
        for (var l = 0; l < FontList.length; l++) {
            if (FontList[l].DisplayFontName == Control.FontFamily) {
                $("#drpFontID" + FontList[l].FontID).prop('selected', true);
                break;
            }
        }

        $("#txtFontSize").val(Control.FontSize.toFixed(2));

        $("#txtC").val(parseFloat(Control.C * 100).toFixed(2));
        $("#txtM").val(parseFloat(Control.M * 100).toFixed(2));
        $("#txtY").val(parseFloat(Control.Y * 100).toFixed(2));
        $("#txtK").val(parseFloat(Control.K * 100).toFixed(2));
        $("#txtT").val(parseFloat(Control.Tint).toFixed(2));
        $("#txtC").trigger('change');
        $("#txtM").trigger('change');
        $("#txtY").trigger('change');
        $("#txtK").trigger('change');
        $("#btnColorStrip").css({ 'background-color': $("#" + Control.ObjectID).css('color') });
    }
    else if (Control.Type.toLowerCase() == "image") {
        if (Control.Lock == true) {
            $("#chkSetImgAsBckgrnd").prop("disabled", true);
        }
        else {
            $("#chkSetImgAsBckgrnd").prop("disabled", false);
        }
        $("#btnRightAlign").removeClass('menubuttonSelected');
        $("#btnLeftAlign").removeClass('menubuttonSelected');
        $("#btnCenterAlign").removeClass('menubuttonSelected');
        $("#btnBold").removeClass('menubuttonSelected');
        $("#btnItalic").removeClass('menubuttonSelected');
        $("#drpFontID" + 0).prop('selected', true);
        $("#drpFont").prop('disabled', true);
        $("#txtFontSize").prop("disabled", true);
        $("#txtFontSize").val("");
        $("#fontColor").hide();
    }
    $("#txtRotate").val(Control.RotateAngle);
}

//Added by salim
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
    }
    if ($("#" + Control.ObjectID).hasClass('Text')) {
        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('line-height'));
        $("#" + Control.ObjectID).css('line-height', $("#" + Control.ObjectID + " .labelText").css('line-height'));
        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant;
        Control.Height = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant;
    }

}

function changeAlignment(align) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if (align == "left") {
            if (fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, "Left")) {
                $(selectedControllID).css('text-align', 'left');
                if (Control.LabelPosition == "customTop") {
                    $(selectedControllID + " .label").css({ 'float': 'left', 'margin-left': '0px' });
                    $(selectedControllID + " .labelText").css({ 'float': 'left' });
                }
                Control.TextAlign = "Left";
                alignsingleLineText(Control.ObjectID);
                $("#btnLeftAlign").addClass('menubuttonSelected');
                $("#btnCenterAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
            }
        }
        else if (align == "center") {
            if (fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, "Center")) {
                $(selectedControllID).css('text-align', 'center');
                Control.TextAlign = "Center";
                alignsingleLineText(Control.ObjectID);
                if (Control.LabelPosition == "customTop") {
                    var mar = (Control.Width * mmConvertionConstant / 2) - ((parseFloat($("#" + Control.ObjectID + " .label").innerWidth())) / 2);
                    $(selectedControllID + " .label").css({ 'float': 'left', 'margin-left': mar + 'px' });
                    $(selectedControllID + " .labelText").css({ 'float': 'left' });
                }

                $("#btnCenterAlign").addClass('menubuttonSelected');
                $("#btnLeftAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
            }
        }
        else if (align == "right") {
            if (fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, "Right")) {
                $(selectedControllID).css('text-align', 'right');
                Control.TextAlign = "Right";
                alignsingleLineText(Control.ObjectID);
                if (Control.LabelPosition == "customTop") {
                    $(selectedControllID + " .label").css({ 'float': 'right', 'margin-left': '0px' });
                    $(selectedControllID + " .labelText").css({ 'float': 'right' });
                }

                $("#btnRightAlign").addClass('menubuttonSelected');
                $("#btnLeftAlign").removeClass('menubuttonSelected');
                $("#btnCenterAlign").removeClass('menubuttonSelected');
            }
        }
    }
    return true;
}

function rotateSelectedControll(rotation) {
    var rotationx = 0 - rotation;
    $(selectedControllID).css({
        'transformOrigin': 'left bottom',
        '-webkit-transform': 'rotate(' + rotationx + 'deg)',
        '-moz-transform': 'rotate(' + rotationx + 'deg)',
        '-ms-transform': 'rotate(' + rotationx + 'deg)',
        'transform': 'rotate(' + rotationx + 'deg)'
    });
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.RotateAngle = rotation;
}

/*completed*/
function Guid() {
    var d = new Date().getTime();
    var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = (d + Math.random() * 16) % 16 | 0;
        d = Math.floor(d / 16);
        return (c == 'x' ? r : (r & 0x7 | 0x8)).toString(16);
    });

    return uuid.substring(0, 10);
}

function createFolderStructureForSytemGallery(FolderAndFiles, CategoryID, ParentID, Search) {

    var thumnailHtml = "";
    var editcategory = false;

    $("#thumNail").empty();
    if (Search) {
        var count = true;
        for (var i = 0; i < FolderAndFiles.length; i++) {
            //ParentID = FolderAndFiles.ImageGallery[i].CategoryID;
            count = false;
            thumnailHtml += "<span style='margin:15px 20px 25px 15px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;' >";
            thumnailHtml += "<div title='Click to assign' id='file_" + FolderAndFiles[i].ImageID + "' class='file HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
            thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;' src='" + BackgroundImagesPath + "Gallery/ThumbnailImages/t_" + FolderAndFiles[i].FileName + "' /></div>";
            thumnailHtml += "<pre style='margin:0px;float:left;'><span style='font-size:12px;font-family:arial;padding-top:5px;padding-left:5px;' title='" + FolderAndFiles[i].OriginalFileName + "'>";
            var FileName = FolderAndFiles[i].OriginalFileName;
            if (FolderAndFiles[i].OriginalFileName.length > 12) {
                FileName = FileName.substr(0, 12) + "...";
            }
            thumnailHtml += FileName + "</span></pre></div></span>";

        }
        if (count) {
            thumnailHtml = "<span style='font-family:arial;font-size:12px;font-weight:bold;'>There is No Images in this Gallery</span>";
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
        }
    }
    else if (FolderAndFiles.ImageCategories.length == 0 && FolderAndFiles.ImageGallery.length == 0) {
        thumnailHtml = "<span style='font-family:arial;font-size:12px;font-weight:bold;'>There is No Images in this Gallery</span>";
        $("#btnSelectAll").hide();
        $("#btnDeletetAll").hide();
        $("#btnSaveImage").hide();
        $("#btnSaveImage").after("<span class='helper'>&nbsp;</span>");
    }
    else {
        var count = true;
        $("#Gallery").css({ 'padding-bottom': '10px' });
        for (var i = 0; i < FolderAndFiles.ImageCategories.length; i++) {
            if (FolderAndFiles.ImageCategories[i].ParentID == parseInt(CategoryID)) {
                //ParentID = FolderAndFiles.ImageCategories[i].ParentID;
                count = false;
                thumnailHtml += "<span style='margin:15px 20px 25px 15px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;' >";
                thumnailHtml += "<div  id='cat_" + FolderAndFiles.ImageCategories[i].CategoryID + "' class='folder HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
                thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;' src='" + SiteImages + "folder_imgnew5.png' /></div>";
                thumnailHtml += "<pre style='margin:0px;float:left;'><span style='font-size:12px;font-family:arial;padding-top:5px;padding-left:5px;' title='" + FolderAndFiles.ImageCategories[i].CategoryName + "'>";
                var FolderName = FolderAndFiles.ImageCategories[i].CategoryName;
                if (FolderAndFiles.ImageCategories[i].CategoryName.length > 14) {
                    FolderName = FolderName.substr(0, 14) + "...";
                }
                thumnailHtml += FolderName + "</span></pre></div></span>";
            }
        }
        for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {
            if (FolderAndFiles.ImageGallery[i].CategoryID == parseInt(CategoryID)) {
                //ParentID = FolderAndFiles.ImageGallery[i].CategoryID;
                count = false;
                thumnailHtml += "<span style='margin:15px 20px 25px 15px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;'>";
                thumnailHtml += "<div title='Click to assign' id='file_" + FolderAndFiles.ImageGallery[i].ImageID + "' class='file HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
                thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;' src='" + BackgroundImagesPath + "Gallery/ThumbnailImages/t_" + FolderAndFiles.ImageGallery[i].FileName + "' /></div>";
                thumnailHtml += "<pre style='margin:0px;float:left;'><span style='font-size:12px;font-family:arial;padding-top:5px;padding-left:5px;' title='" + FolderAndFiles.ImageGallery[i].OriginalFileName + "'>";
                var FileName = FolderAndFiles.ImageGallery[i].OriginalFileName;
                if (FolderAndFiles.ImageGallery[i].OriginalFileName.length > 14) {
                    FileName = FileName.substr(0, 14) + "...";
                }
                thumnailHtml += FileName + "</span></pre></div></span>";
            }
        }
        if (count) {
            thumnailHtml = "<span style='font-family:arial;font-size:12px;font-weight:bold;'>There is No Images in this Gallery</span>";
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
        }

    }
    $("#thumNail").html(thumnailHtml);
    $("#Gallery").css({ 'padding': '0px 0px 10px 0px' });
    $(".loading_gallery").hide();

    if (parseInt(ParentID) == -1) {
        $('#btnShowMore').show();
        $(".btnBack").hide();
        $('#btnSaveImage').css({ 'margin-left': '405px' });
        $(".txtSearchText").attr('id', 'SystemGallery_0');
    }
    else {
        $('#btnShowMore').hide();
        $('#btnSaveImage').css({ 'margin-left': '450px' });
        $(".btnBack").css({ 'margin-top': '5px' });
        $(".btnBack").show();
        $(".btnBack").attr('id', 'brnBack_' + ParentID);
        $(".txtSearchText").attr('id', 'SystemGallery_' + CategoryID);
    }
    $("#btnSelectAll").hide();
    $("#btnDeletetAll").hide();
    $(".txtSearchText").keyup(function (e) {

        if (e.which == 13) {
            if ($(".txtSearchText").val() == "") {
                loadSyatemFilesAndFolders($(".txtSearchText").attr('id').split('_')[1]);
            }
            else {
                searchByText($(this).val(), $(this).attr('id').split('_')[1], $(this).attr('id').split('_')[0]);
            }
        }
    });
    $('.folder').unbind('click').bind('click', function () {
        $(".loading_gallery").show();
        var catid = $(this).attr('id').split('_')[1];
        loadSystemFilesAndFolders(catid);
    });

    $(".btnBack").one('click', function () {
        $(".loading_gallery").show();
        var catid = $(this).attr('id').split('_')[1];
        loadSystemFilesAndFolders(catid);
    });

    $('.file').unbind('click').bind('click', function () {
        $(".loading_gallery").show();
        var imageid = $(this).attr('id').split('_')[1];
        if (Search) {
            for (var i = 0; i < FolderAndFiles.length; i++) {
                if (FolderAndFiles[i].ImageID == parseInt(imageid)) {
                    assignImage(FolderAndFiles[i].FileName, "system");
                    break;
                }
            }
        }
        else {
            for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {
                if (FolderAndFiles.ImageGallery[i].ImageID == parseInt(imageid)) {
                    assignImage(FolderAndFiles.ImageGallery[i].FileName, "system");
                    break;
                }
            }
        }

    });

    $(".btnClearSearchText").unbind('click').bind('click', function () {
        $(".loading_gallery").show();
        loadSystemFilesAndFolders($(".txtSearchText").attr('id').split('_')[1]);
        $(".txtSearchText").val("");
    });
}

function createFolderStructureForUserGallery(FolderAndFiles, CategoryID, Search) {

    var thumnailHtml = "";
    var editcategory = false;
    var editFile = false;
    $("#userthamnail").empty();
    $(".loading_gallery").hide();
    $("#btnSelectAll").show();
    $("#btnDeletetAll").show();
    if (Search) {
        var count = true;
        for (var i = 0; i < FolderAndFiles.length; i++) {
            count = false;
            thumnailHtml += "<span style='margin:15px 20px 25px 15px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;'><div title='Click to assign' id='file_" + FolderAndFiles[i].ImageID + "' class='file HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
            thumnailHtml += "<input type='checkbox' id='chkFileSelect_" + FolderAndFiles[i].ImageID + "'  class='FileSelectChk' style='margin-bottom:0px;position:absolute;top:0px;right:0px;' title='Delete' />";

            thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;' src='";

            if (FolderAndFiles[i].FileName.split('.')[1].toLowerCase() == "pdf") {
                thumnailHtml += SiteImages + "/processing.png'";
            }
            else {
                thumnailHtml += FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/ThumbnailImages/t_" + FolderAndFiles[i].FileName + "'";
            }
            thumnailHtml += "/></div>";
            thumnailHtml += "<div id='editdelete_" + FolderAndFiles[i].ImageID + "' style='position:absolute;bottom:0px;left:0px;width:100%;height:20px;cursor:default;padding-top:1px;background-color:#797979;border-bottom-left-radius:1px;border-bottom-right-radius:1px;display:none;'><span class='EditDeleteFileFolder EditFile' id='editFile_" + FolderAndFiles[i].ImageID + "' style='float:left;margin-left:10px;margin-top:2px;' title='Edit'>Edit</span><span title='Delete' class='EditDeleteFileFolder DeleteFile' style='float:right;margin-right:10px;margin-top:2px;' id='deleteFile_" + FolderAndFiles[i].ImageID + "'>Delete</span></div></div>";
            thumnailHtml += "<pre style='margin:0px;padding:0px;'><span style='font-size:12px;font-family:arial;padding-top:5px;padding-left:10px;' title='" + FolderAndFiles[i].OriginalFileName + "'>";
            var FileName = FolderAndFiles[i].OriginalFileName;
            if (FolderAndFiles[i].OriginalFileName.length > 14) {
                FileName = FileName.substr(0, 14) + "...";
            }

            thumnailHtml += FileName + "</span></pre><div></span>";
        }
        if (count) {
            thumnailHtml = "<span style='font-family:arial;font-size:12px;font-weight:bold;'>There is No Images in this Gallery</span>";
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
        }
    }
    else if (FolderAndFiles.ImageCategories.length == 0 && FolderAndFiles.ImageGallery.length == 0) {
        thumnailHtml += "<span style='font-family:arial;font-size:12px;font-weight:bold;'>There is No Images in this Gallery</span>";
        $("#btnSelectAll").hide();
        $("#btnDeletetAll").hide();
        $("#btnSaveUserAndClose").hide();
        $('#btnUserShowMore').hide();
        $("#btnSaveUserAndClose").after("<span class='helper'>&nbsp;</span>");
    }
    else {
        $("#btnSelectAll").show();
        $("#btnDeletetAll").show();
        $("#btnSaveUserAndClose").show();
        $('#btnUserShowMore').show();
        $(".helper").remove();
        $("#UserGallery").css({ 'padding-bottom': '10px' });
        for (var i = 0; i < FolderAndFiles.ImageCategories.length; i++) {
            thumnailHtml += "<span style='margin:15px 20px 25px 15px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;' ><div id='cat_" + FolderAndFiles.ImageCategories[i].CategoryID + "' class='folder HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
            thumnailHtml += "<input type='checkbox' title='Delete' id='chkFolderSelect_" + FolderAndFiles.ImageCategories[i].CategoryID + "' class='FolderSelectChk' style='margin-bottom:0px;position:absolute;top:0px;right:0px;' />";
            thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;' src='" + SiteImages + "folder_imgnew5.png' /></div>";
            thumnailHtml += "<div id='editdelete_" + FolderAndFiles.ImageCategories[i].CategoryID + "' style='position:absolute;bottom:0px;left:0px;width:100%;height:20px;cursor:default;padding-top:1px;background-color:#797979;border-bottom-left-radius:1px;border-bottom-right-radius:1px;display:none;'><span class='EditCategory EditDeleteFileFolder' id='editCat_" + FolderAndFiles.ImageCategories[i].CategoryID + "' style='float:left;margin-left:10px;margin-top:2px;' title='Edit' >Edit</span><span title='Delete' class='EditDeleteFileFolder DeleteCategory' id='deleteCategory_" + FolderAndFiles.ImageCategories[i].CategoryID + "' style='float:right;margin-right:10px;margin-top:2px;'>Delete</span></div></div>";
            thumnailHtml += "<pre style='margin:0px;padding:0px;'><span style='font-size:12px;font-family:arial;padding-top:5px;padding-left:10px;' title='" + FolderAndFiles.ImageCategories[i].CategoryName + "'>";
            var FolderName = FolderAndFiles.ImageCategories[i].CategoryName;
            if (FolderAndFiles.ImageCategories[i].CategoryName.length > 14) {
                FolderName = FolderName.substr(0, 14) + "...";
            }
            thumnailHtml += FolderName + "</span></pre></div></span>";
        }
        for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {

            thumnailHtml += "<span style='margin:15px 20px 25px 15px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;'><div title='Click to assign' id='file_" + FolderAndFiles.ImageGallery[i].ImageID + "' class='file HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
            thumnailHtml += "<input title='Delete' type='checkbox' id='chkFileSelect_" + FolderAndFiles.ImageGallery[i].ImageID + "' class='FileSelectChk' style='margin-bottom:0px;position:absolute;top:0px;right:0px;'  />";


            thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;' src='";

            if (FolderAndFiles.ImageGallery[i].FileName.split('.')[1].toLowerCase() == "pdf") {
                thumnailHtml += SiteImages + "/processing.png'";
            }
            else {
                thumnailHtml += FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/ThumbnailImages/t_" + FolderAndFiles.ImageGallery[i].FileName + "'";
            }
            thumnailHtml += "/></div>";
            thumnailHtml += "<div id='editdelete_" + FolderAndFiles.ImageGallery[i].ImageID + "' style='position:absolute;bottom:0px;left:0px;width:100%;height:20px;cursor:default;padding-top:1px;background-color:#797979;border-bottom-left-radius:1px;border-bottom-right-radius:1px;display:none;'  ><span class='EditDeleteFileFolder EditFile' title='Edit' id='editFile_" + FolderAndFiles.ImageGallery[i].ImageID + "' style='float:left;margin-left:10px;margin-top:2px;'>Edit</span><span title='Edit' class='EditDeleteFileFolder DeleteFile' style='float:right;margin-right:10px;margin-top:2px;' id='deleteFile_" + FolderAndFiles.ImageGallery[i].ImageID + "'>Delete</span></div></div>";
            thumnailHtml += "<pre style='margin:0px;padding:0px;'><span style='font-size:12px;font-family:arial;padding-top:5px;padding-left:10px;' title='" + FolderAndFiles.ImageGallery[i].OriginalFileName + "'>";
            var FileName = FolderAndFiles.ImageGallery[i].OriginalFileName;
            if (FolderAndFiles.ImageGallery[i].OriginalFileName.length > 14) {
                FileName = FileName.substr(0, 14) + "...";
            }

            thumnailHtml += FileName + "</span></pre></div></span>";
        }
    }
    $("#userthamnail").html(thumnailHtml);
    $("#UserGallery").css({ 'padding': '0px 0px 10px 0px' });
    if (FolderAndFiles.ParentID == -1) {
        $('#btnUserShowMore').show();
        $(".btnUserBack").hide();
        $('#btnSaveUserAndClose').css({ 'margin-left': '405px' });
        $(".txtSearchText").attr('id', 'UserGallery_0');
    }
    else {
        $('#btnUserShowMore').hide();
        $('#btnSaveUserAndClose').css({ 'margin-left': '450px' });
        $(".btnUserBack").show();
        $(".btnUserBack").css({ 'margin-top': '5px' });
        $(".btnUserBack").attr('id', 'brnBack_' + FolderAndFiles.ParentID);
        $(".txtSearchText").attr('id', 'UserGallery_' + CategoryID);
    }
    if (Search) {
        $('#btnUserShowMore').show();
        $(".btnUserBack").hide();
        $('#btnSaveUserAndClose').css({ 'margin-left': '405px' });
        $(".txtSearchText").attr('id', 'UserGallery_0');
    }

    $(".loading_gallery").hide();


    $(".HoverFunction").mouseenter(function () {
        $("#editdelete_" + $(this).attr('id').split('_')[1]).show();
    });
    $(".HoverFunction").mouseleave(function () {
        $("#editdelete_" + $(this).attr('id').split('_')[1]).hide();
    });

    $(".DeleteCategory").unbind('click').bind('click', function () {
        editcategory = true;
        if (confirm("Are you sure you want to delete category? \r\n This action cannot be undone.")) {
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
                        $("#Message").dialog("open");
                        $("#msg").html("<span>You can not delete the category, it is assigned to object in system.</span>");
                        designMessageBox();
                        $(".loading_gallery").hide();
                        return false;
                    }
                    else {
                        loadUserFilesAndFolders($(".txtSearchText").attr('id').split('_')[1]);
                    }
                }
            });
        }
    });

    $(".FileSelectChk").click(function () {
        editFile = true;
    });

    $(".DeleteFile").unbind('click').bind('click', function () {
        editFile = true;
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
                        $("#Message").dialog("open");
                        $("#msg").html("<span>You can not delete this image, it is assigned to object in system.</span>");
                        designMessageBox();
                        $(".loading_gallery").hide();
                        return false;
                    }
                    else {
                        loadUserFilesAndFolders($(".txtSearchText").attr('id').split('_')[1]);
                    }
                }
            });
        }
    });

    $(".folder").unbind('click').bind('click', function () {
        if (editcategory == false) {
            $(".loading_gallery").show();
            loadUserFilesAndFolders($(this).attr('id').split('_')[1]);
            $(".btnSearch").attr('id', 'btnSearch_' + $(this).attr('id').split('_')[1]);
        }
        else {
            editcategory = false;
        }
    });

    $('.file').click(function () {
        if (editFile == false) {
            $(".loading_gallery").show();
            var imageid = $(this).attr('id').split('_')[1];
            if (Search) {
                for (var i = 0; i < FolderAndFiles.length; i++) {
                    if (FolderAndFiles[i].ImageID == parseInt(imageid)) {
                        assignImage(FolderAndFiles[i].FileName, "user");
                        break;
                    }
                }
            }
            else {
                for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {
                    if (FolderAndFiles.ImageGallery[i].ImageID == parseInt(imageid)) {
                        assignImage(FolderAndFiles.ImageGallery[i].FileName, "user");
                        break;
                    }
                }
            }
        }
        else {
            editFile = false;
        }

    });

    $(".txtSearchText").unbind('keyup').bind('keyup', function (e) {

        if (e.which == 13) {
            if ($(".txtSearchText").val() == "") {
                loadUserFilesAndFolders($(".txtSearchText").attr('id').split('_')[1]);
            }
            else {
                searchByText($(this).val(), $(this).attr('id').split('_')[1], $(this).attr('id').split('_')[0]);
            }
        }
    });

    $(".btnClearSearchText").unbind('click').bind('click', function () {
        $(".loading_gallery").show();

        loadUserFilesAndFolders($(".txtSearchText").attr('id').split('_')[1]);
        $(".txtSearchText").val("");
    });

    $(".btnUserBack").unbind('click').bind('click', function () {
        $(".loading_gallery").show();
        loadUserFilesAndFolders($(this).attr('id').split('_')[1]);
        $(".btnSearch").attr('id', 'btnSearch_' + $(this).attr('id').split('_')[1]);
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
        editFile = true;

        $("#ImageDetails").dialog('open');
        $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
        var imageid = $(this).attr('id').split('_')[1];
        editImageDetails(FolderAndFiles, imageid);

        $("#divImage").mouseenter(function () {

            $("#changeimageshow").show();
        });

        $("#divImage").mouseleave(function () {
            $("#changeimageshow").hide();
        });
        $(".btnupdateimagedetails").unbind('click').bind('click', function () {
            var imgid = $(this).attr('id').split('_')[1];
            var FileName = $("#txtImageName").val();
            if ($("#txtImageName").val() == "") {
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
                    loadUserFilesAndFolders($("#drpCategoryForImage").val());
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

            $(function () {
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
                        $("#SaveMessage").dialog("open");
                        $("#savemsg").html("Please select file to upload");
                        designMessageBox();
                        $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                        $(".loadingNewMask").show();
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
    });

    $(".FolderSelectChk").unbind('click').bind('click', function () {
        editcategory = true;
    });

    $("#btnDeletetAll").one('click', function () {
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
            $("#SaveMessage").dialog("open");
            $("#savemsg").html("Please select files or folders to delete");
            designMessageBox();
            $("div[aria-describedby=SaveMessage]").css('z-index', '114');
            $(".loadingNewMask").show();
            return false;
        }
        else {
            if (confirm("Are you sure you want to delete? \r\n This action cannot be undone.")) {
                $(".loading_gallery").show();
                $.ajax({
                    //var DeleteMultiple = {};
                    url: ServicePath + "DeleteMultipleFilesFolders",
                    type: "POST",
                    data: JSON.stringify({ categoryids: deletecategoryids, imageids: deleteimageids, templateid: TemplateID, companyid: CompanyID, objectid: selectedObjectID, _key: DBKey }),
                    dataType: "json",
                    processData: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {

                        if (result.d.indexOf("-1") != -1) {
                            $("#Message").dialog("open");
                            $("#msg").html("<span>You can not delete, it is assigned to object in system.</span>");
                            designMessageBox();
                            $(".loading_gallery").hide();
                            return false;
                        }
                        else {
                            loadFolderAndFilesBycategory("", $(".txtSearchText").attr('id').split('_')[1]);
                        }
                    }
                });
            }
            else {
            }
        }
    });

    $("#btnSaveImage").unbind('click').bind('click', function () {
        $("#ImageFromGallery").dialog('close');
        $(".loading_new").show();
        var Typeids = "", Types = "", defaultid = 0;
        $("#thumNail").find(".FolderAssginChk").each(function () {
            if ($(this).prop('checked') == true) {
                Typeids += $(this).attr('id').split('_')[1] + ",";
                Types += 'c' + ",";
            }
        });
        $("#thumNail").find(".FileAssginChk").each(function () {
            if ($(this).prop('checked') == true) {
                Typeids += $(this).attr('id').split('_')[1] + ",";
                Types += 'f' + ",";
            }
        });
        $("#thumNail").find(".SetAsDefault").each(function () {
            if ($(this).prop('checked') == true) {

                Typeids += $(this).attr('id').split('_')[1] + ",";
                Types += 'f' + ",";
                defaultid = $(this).attr('id').split('_')[1];
            }
        });
        Typeids = Typeids.substr(0, Typeids.length - 1);
        Types = Types.substr(0, Types.length - 1);
        $.ajax({
            url: ServicePath + "Insert_ImageGalleryAssignment",
            type: "POST",
            data: JSON.stringify({ objectid: selectedObjectID, companyid: CompanyID, templateid: TemplateID, userid: UserID, types: Types, typeids: Typeids, defaultid: defaultid, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function () {

                if (defaultid != "") {
                    var zoom = parseInt(parseFloat(zoomvalue()) * 100);
                    var width;
                    var height, fileName;
                    var objectid = selectedObjectID;

                    var Control;
                    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                    width = parseInt(Control.Width * mmConvertionConstant);
                    height = parseInt(Control.Height * mmConvertionConstant);


                    for (var k = 0; k < FolderAndFiles.ImageGallery.length; k++) {
                        if (FolderAndFiles.ImageGallery[k].ImageID == parseInt(defaultid)) {
                            fileName = FolderAndFiles.ImageGallery[k].FileName;
                        }
                    }

                    if (Control.IsImageQuality) {
                        $.ajax({
                            url: WebMethodsPath + "checkImageForDPI",
                            type: "POST",
                            data: JSON.stringify({ OriginalImageName: Control.OrignalImageName, isEdited: "false", ischecked: "false", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI }),
                            dataType: "json",
                            processData: false,
                            contentType: "application/json; charset=utf-8",
                            success: function (DPIResult) {
                                if (DPIResult.d == "success") {
                                    LoadImage();
                                }
                                else {
                                    $("#SaveMessage").dialog("open");
                                    $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
                                    designMessageBox();
                                    $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                                    $(".loadingNewMask").show();
                                    $(".loading_new").hide();
                                }
                            }
                        });
                    }
                    else {
                        LoadImage();
                    }

                    function LoadImage() {
                        $.ajax({
                            url: WebMethodsPath + "fitTheImageTocontroll",
                            type: "POST",
                            data: JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "false", ischecked: "false", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop }),
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
                                Control.IsCropped = Boolean(arry[5]);
                                exceedimage = Control.ExceedImage;


                                if (exceedimage == "P") {
                                    $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
                                    $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);
                                }
                                if (exceedimage == "S") {
                                    $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                                    //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + Control.ImgUrl);
                                    $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                                    if (fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.Align)) {
                                        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                                        if ($("#" + Control.ObjectID).hasClass('Para')) {
                                            $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                                        }
                                    }
                                }
                                if (exceedimage == "D") {
                                    var arry = Control.ImgUrl.split('.');
                                    var imageanme = arry[0].split('-');
                                    //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + imageanme[0] + "." + arry[1]);
                                    checkforImage(imageanme[0] + "." + arry[1]);
                                }

                                $("#fileList").empty();
                                $("#multipleFileUpload").val("");
                                $("#galleryLink").trigger('click');
                                loadFolderAndFilesBycategory(false, $("#drpSelectCategory").val());

                                alignsingleImage(Control.ObjectID);

                            }

                        });
                    }
                }
                else {
                    $(".loading_new").hide();
                }
            }
        });
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

        $(".btnEditSave").unbind('click').bind('click', function () {
            if ($("#txtEditCategoryName").val() == "") {
                $("#errEditCategory").show();
                $("#txtEditCategoryName").css({ 'border': '1px solid red' });
                return false;
            }
            else {
                $.ajax({
                    url: ServicePath + "UpdateImageCategory",
                    type: "POST",
                    data: JSON.stringify({ companyid: CompanyID, categoryid: $(this).attr('id').split('_')[1], categoryname: $("#txtEditCategoryName").val(), userid: UserID, description: "", parentid: $("#drpforEditCategory").val(), categoryimage: "", _key: DBKey }),
                    dataType: "json",
                    processData: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (categoryID) {
                        var CategoryID = categoryID.d;

                        if (CategoryID == -1) {
                            $("#SaveMessage").dialog("open");
                            $("#savemsg").html("Category name already exists.");
                            designMessageBox();
                            $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                            $(".loadingNewMask").show();
                            return false;
                        }
                        else {
                            $("#EditCategory").dialog('close');
                            loadUserFilesAndFolders($("#drpforEditCategory").val());
                        }

                    }
                });
            }
        });
        $("#txtEditCategoryName").focusin(function () {
            $("#errEditCategory").hide();
            $("#txtEditCategoryName").css({ 'border': '1px solid #b2b2b2' });
        });
    });
}

function openGallery(fromgallery, fromharddisk) {

    $("#ImageFromGallery").dialog("open");
    $(function () {
        $("#tabs").tabs();
    });
    $(".loading_gallery").show();
    $("#FileUplaod").css({ 'padding-bottom': '10px' });
    //$('.ui-tabs-nav').css({ 'margin-bottom': '0px', 'height': '30px', 'padding': '0px', 'background': 'none', 'background-color': 'transparent', 'border': '0px', 'border-radius': '0px', 'background': 'transparent' });
    //$(".ui-tabs-nav .ui-state-default a").css({ 'font-size': '14px', 'font-family': 'arial', 'font-weight': 'bold' });
    //$(".ui-tabs-nav .ui-state-default").css({ 'height': '28px', 'z-index': '11', 'background': 'none', 'background-color': 'white', 'border': '0px solid #a9a9a9' });
    $(".ui-tabs-nav .ui-tabs-active").css({ 'height': '20px', 'z-index': '11', 'background': 'none', 'background-color': '#F3F6F7', 'border': '1px solid #a9a9a9', 'border-bottom-width': '0px' });
    $(".ui-tabs-nav li").css({ 'height': '20px', 'margin-top': '4px' });
    $("#fileUploadLink,#galleryLink,#usergallerylink").css({ 'font-size': '11px', 'font-family': 'Arial', 'font-weight': 'bold', 'padding': '3px 5px 3px 5px' });
    $("li[aria-controls=Gallery]").css('margin-right:0px;');
    $(".ui-tabs-nav .ui-state-default").unbind('click').bind('click', function () {

        if ($(this).attr('aria-controls') == "FileUplaod") {
            $("#thumbnailButtons").hide();
        }
        else {
            $("#thumbnailButtons").show();
        }
        $(".ui-tabs-nav .ui-state-default").css({ 'border-width': '0px', });
        $(this).css({ 'border-width': '1px', 'border-bottom-width': '0px' });
    });
    $("#ImageFromGallery select").css({ 'font-weight': 'normal', 'padding-right': '10px', 'background': '#FFFFFF url(' + SiteImages + 'arrow-down.png) no-repeat 100% center', '-webkit-appearance': 'none', '-moz-appearance': ' none' });
    $('.ui-tabs').css({ 'border': '0px', 'margin': '0px 10px 0px 10px', 'background': 'none', 'background-color': 'transparent' });
    $(".ui-tabs-panel").css({ 'border': '0px', 'border': '1px solid #B2B2B2', 'border-radius': '3px' });
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
    $('div[aria-describedby=ImageFromGallery] .ui-dialog-buttonset .ui-button').css({ 'height': '25px', 'width': '75px', 'margin': '0px auto 0px auto', 'border': '1px solid #808080', 'background': 'none', 'background': ' linear-gradient(#F1F1F1, #F1F1F1,#E1E1E1,#DDDDDD)', 'font-family': ' Verdana, Arial, Helvetica, sans-serif', 'font-size': '12px', 'color': '#450000', 'border-radius': '5px', 'cursor': 'pointer' });
    $("#ImageFromGallery").css({ 'overflow': 'visible !important' });

    if (fromgallery == "g") {
        $("#galleryLink").show();
        $(".loading_gallery").show();
        loadSystemFilesAndFolders(0);
    }
    else {
        $("#galleryLink").hide();
        $(".loading_gallery").show();
        $("#usergallerylink").trigger('click');
        loadUserFilesAndFolders(0, -1);
    }
    if (fromharddisk == "h") {
        $("#fileUploadLink").show();
    }
    else {
        $("#fileUploadLink").hide();
    }

    $("#usergallerylink").show();

    $("#galleryLink").click(function () {
        $(".loading_gallery").show();
        loadSystemFilesAndFolders(0);
    });
    $("#usergallerylink").click(function () {
        $(".loading_gallery").show();
        loadUserFilesAndFolders(0, -1);
    });

    $("#btnNewCategoryPopUp").unbind('click').bind('click', function () {

        $("#CreateCategory").dialog('open');
        $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });

        $(document).ready(function () {
            $("#txtNewCategoryName").focusin(function () {
                $("#errCategory").hide();
                $("#txtNewCategoryName").css({ 'border': '1px solid #b2b2b2' });
            });
            $("#btnSaveCategory").unbind('click').bind('click', function () {

                if ($("#txtNewCategoryName").val() == "") {
                    $("#errCategory").show();
                    $("#txtNewCategoryName").css({ 'border': '1px solid red' });
                    return false;
                }
                else {
                    var insertCategory = {};
                    insertCategory.url = ServicePath + "InsertImageCategory";
                    insertCategory.type = "POST";
                    insertCategory.data = JSON.stringify({ companyid: CompanyID, categoryname: $("#txtNewCategoryName").val(), createdby: UserID, description: "", parentid: $("#drpForCreateCategory").val(), categoryimage: "", _key: DBKey });
                    insertCategory.dataType = "json";
                    insertCategory.processData = false;
                    insertCategory.contentType = "application/json; charset=utf-8";
                    insertCategory.success = function (categoryID) {
                        var CategoryID = categoryID.d;

                        if (CategoryID == -1) {
                            $("#SaveMessage").dialog("open");
                            $("#savemsg").html("Category name already exists.");
                            designMessageBox();
                            $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                            $(".loadingNewMask").show();
                            return false;
                        }
                        else {
                            loadcategoryList(CategoryID);

                        }
                    };
                    $.ajax(insertCategory);
                }
            });
        });
    });


    $("#chkSvaeImagetomyGallery").unbind('change').bind('change', function () {
        if ($(this).prop('checked')) {
            $("#selectCat").show();
        }
        else {
            $("#selectCat").hide();
        }
    });

    $("#btnSelectFiles").unbind('click').bind('click', function () {
        $("#multipleFileUpload").trigger('click');
    });

    $("#multipleFileUpload").unbind('change').bind('change', function () {
        totalSize = 0;
        var files = $('#multipleFileUpload').prop("files");
        var filerdr = new FileReader();
        var names = $.map(files, function (val) { return val.name; });
        var size = $.map(files, function (val) { return val.size; });
        $("#fileList").empty();
        filelist = "";
        for (var i = 0; i < names.length; i++) {
            var sizeInKB = parseFloat(parseInt(size[i]) / 1024).toFixed(2);
            var ext = names[i].split('.')[1].toLowerCase();
            if (ext == "pdf" || ext == "png" || ext == "jpeg" || ext == "jpg") {
                var GUID = Guid().substr(0, 5);
                filelist += GUID + "~" + names[i] + "~" + parseInt(size[i]) + ",";
                $("#fileList").append("<div id='div_" + i + "' class='Filestoupload'>" + names[i] + "<img src='" + SiteImages + "close-gray1.png' width='14px' height='14px' title='Remove the image' class='delefile' id='" + i + ":" + sizeInKB + ":" + names[i] + "' /><span style='float:right;margin-right:10px;'>" + sizeInKB + " KB</span></div>");

                totalSize += parseFloat(sizeInKB);
            }

        }
        filelist = filelist.substr(0, filelist.length - 1);
        changetotalSize(totalSize);
        $(".delefile").unbind('click').bind('click', function () {

            var filelistarry = filelist.split(',');
            var minus = parseFloat($(this).attr('id').split(':')[1]);
            $("#div_" + $(this).attr('id').split(':')[0]).remove();
            totalSize = totalSize - minus;
            changetotalSize(Math.abs(totalSize));
            filelist = "";
            for (var j = 0; j < filelistarry.length; j++) {
                if (filelistarry[j].split('~')[1] != $(this).attr('id').split(':')[2]) {
                    filelist += filelistarry[j] + ",";
                }
            }
            filelist = filelist.substr(0, filelist.length - 1);
        });

        function changetotalSize(totalSize) {
            totalSizex = (totalSize).toFixed(2);
            if (totalSizex > 1024) {
                $("#Total").html((totalSizex / 1024).toFixed(2) + " MB");
            }
            else {
                $("#Total").html(totalSizex + " KB");
            }
            $("#totalContainer").show();
        }

    });


    $("#btnUpload").unbind('click').bind('click', function () {
        if (filelist == "") {
            $("#SaveMessage").dialog("open");
            $("#savemsg").html("Please select files to upload");
            designMessageBox();
            $("div[aria-describedby=SaveMessage]").css('z-index', '114');
            $(".loadingNewMask").show();
            return false;
        }
        if ($("#chkSvaeImagetomyGallery").prop('checked')) {
            $(".loading_gallery").show();
            //we include a random number just to make sure it is unique and not cache.
            var randomnumber = Math.floor(Math.random() * 10001);

            //we use the FormData object to build the file uploads
            var form_data = new FormData();
            var objFiles = $("input#multipleFileUpload").prop("files");
            var names = $.map(objFiles, function (val) { return val.name; });
            var value = false;

            jQuery.each($('#multipleFileUpload')[0].files, function (i, file) {
                form_data.append('file-' + i, file);
            });
            var zoom = zoomvalue();
            var getImageList = {};
            getImageList.url = ServicePath + "InsertUserImageGallery";
            getImageList.type = "POST";
            getImageList.data = JSON.stringify({ companyid: CompanyID, templateid: TemplateID, categoryid: $("#drpSelectCategory").val(), userid: UserID, usertype: "user", fileList: filelist, description: "", metatags: "", _key: DBKey });
            getImageList.dataType = "json";
            getImageList.processData = false;
            getImageList.contentType = "application/json; charset=utf-8";
            getImageList.success = function (imageList) {

                $.ajax({
                    url: mainSitePath + "UploadHandler.ashx/ProcessRequest?Zoom=" + zoom + "&ImageUploadPath=" + FrontEndUploadPath + "&UploadFileNames=" + filelist + "&TemplateID=" + TemplateID + "&CompanyID=" + CompanyID + "&UserID=" + UserID + "&isChecked=true&Dbkey=" + DBKey,
                    cache: false,
                    contentType: false,
                    processData: false,
                    data: form_data,
                    type: 'post',
                    success: function () {
                        loadUserFilesAndFolders($("#drpSelectCategory").val());
                        $("#usergallerylink").trigger('click');
                    }
                });
            };
            $.ajax(getImageList);

        }
        else {
            var zoom = parseInt(parseFloat(zoomvalue()) * 100);

            $(".loading_gallery").show();
            var form_data = new FormData();
            jQuery.each($('#multipleFileUpload')[0].files, function (i, file) {
                form_data.append('file-' + i, file);
            });
            $.ajax({
                url: mainSitePath + "uploadhandler.ashx/ProcessRequest?Zoom=" + zoom + "&ImageUploadPath=" + FrontEndUploadPath + "&UploadFileName=" + filelist.split(',')[0] + "&TemplateID=" + TemplateID + "&CompanyID=" + CompanyID + "&UserID=" + UserID + "&isChecked=false&Dbkey=" + DBKey,
                cache: false,
                contentType: false,
                processData: false,
                data: form_data,
                type: 'post',
                success: function () {
                    var arry = filelist.split(',')[0].split('~');
                    zoom = parseInt(parseFloat(zoomvalue()) * 100);
                    var width;
                    var height;
                    var objectid = selectedObjectID;
                    var exxceeimage = "";
                    var Control;
                    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                    width = parseInt(Control.Width * mmConvertionConstant);
                    height = parseInt(Control.Height * mmConvertionConstant);
                    exxceeimage = Control.ExceedImage;

                    var fileName = arry[0] + "_" + arry[1];

                    if (Control.IsImageQuality) {
                        $.ajax({
                            url: WebMethodsPath + "checkImageForDPI",
                            type: "POST",
                            data: JSON.stringify({ OriginalImageName: fileName, isEdited: "false", ischecked: "false", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI }),
                            dataType: "json",
                            processData: false,
                            contentType: "application/json; charset=utf-8",
                            success: function (DPIResult) {
                                if (DPIResult.d == "success") {
                                    LoadImage();
                                }
                                else {
                                    $("#SaveMessage").dialog("open");
                                    $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
                                    designMessageBox();
                                    $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                                    $(".loadingNewMask").show();
                                    $(".loading_gallery").hide();
                                }
                            }
                        });
                    }
                    else {
                        LoadImage();
                    }

                    function LoadImage() {
                        if (exxceeimage == "P") {
                            var FitImageToContoll = {};
                            FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
                            FitImageToContoll.type = "POST";
                            FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "false", ischecked: "false", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop });
                            FitImageToContoll.dataType = "json";
                            FitImageToContoll.processData = false;
                            FitImageToContoll.contentType = "application/json; charset=utf-8";
                            FitImageToContoll.success = function (ImageName) {

                                var arry = ImageName.d.split('~');
                                ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });


                                Control.ImgUrl = arry[0];
                                Control.OrignalImageName = arry[2];
                                Control.IsFromBackEnd = false;
                                Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                                Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
                                Control.IsCropped = Boolean(arry[5]);
                                $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });

                                $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + arry[0]);
                                alignsingleImage(Control.ObjectID);
                                $("#ImageFromGallery").dialog("close");
                                $(".loading_gallery").hide();
                                $(".loading_new").show();
                                var tmpImg = new Image();
                                tmpImg.src = FrontEndDocumentPath + TemplateID + "/Images/" + arry[0];
                                $(tmpImg).on('load', function () {
                                    $(".loading_new").hide();
                                });


                            };
                            $.ajax(FitImageToContoll);
                        }
                        else if (exxceeimage == "S") {
                            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


                            Control.ImgUrl = fileName;
                            Control.OrignalImageName = fileName;
                            Control.IsFromBackEnd = false;
                            //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
                            $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + fileName);
                            $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                            //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + Control.ImgUrl);
                            $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                            Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                            Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                            if (fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign)) {
                                $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                                if ($("#" + Control.ObjectID).hasClass('Para')) {
                                    $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                                }
                            }
                            alignsingleImage(Control.ObjectID);
                            $("#ImageFromGallery").dialog("close");
                            $(".loading_gallery").hide();
                            $(".loading_new").show();
                            var tmpImg = new Image();
                            tmpImg.src = FrontEndDocumentPath + TemplateID + "/Images/" + fileName;
                            $(tmpImg).on('load', function () {
                                $(".loading_new").hide();
                            });

                        }
                        else if (exxceeimage == "D") {
                            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                            Control.ImgUrl = fileName;
                            Control.OrignalImageName = fileName;
                            Control.IsFromBackEnd = false;
                            //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });

                            var tmpImg = new Image();
                            tmpImg.src = FrontEndDocumentPath + TemplateID + "/Images/" + fileName;
                            $(tmpImg).on('load', function () {
                                var orgWidth = tmpImg.width;
                                var orgHeight = tmpImg.height;
                                $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + fileName);
                                $("#" + Control.ObjectID).css({ 'width': orgWidth + 'px', 'height': orgHeight + 'px' });
                                $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                                $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                                Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                                Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                                Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
                                Control.Width = parseFloat($("#" + Control.ObjectID).innerWidth()) / mmConvertionConstant;
                                if (fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign)) {
                                    $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                                    if ($("#" + Control.ObjectID).hasClass('Para')) {
                                        $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                                    }
                                }
                                alignsingleImage(Control.ObjectID);
                                $("#ImageFromGallery").dialog("close");
                                $(".loading_gallery").hide();
                                var tmpImg = new Image();
                                tmpImg.src = FrontEndDocumentPath + TemplateID + "/Images/" + fileName;
                                $(tmpImg).on('load', function () {
                                    $(".loading_new").hide();
                                });
                            });

                        }
                        filelist = "";
                        $("#fileList").empty();
                        $("#multipleFileUpload").val("");
                        $("#usergallerylink").trigger('click');
                        $("#galleryLink").trigger('click');
                    }
                }
            });

        }

    });
}

/*Compelted*/
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

/*Compelted*/
function loadcategoryList(CategoryID) {
    $.ajax({
        url: ServicePath + "GetImageCategoryByFrontendUser",
        type: "POST",
        data: JSON.stringify({ companyid: CompanyID, userid: UserID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (categoryBindingList) {
            CategoryBindingList = JSON.parse(JSON.stringify(categoryBindingList.d));
            loadCategorydropdowns(CategoryID);
            if (CategoryID != "") {
                $("#CreateCategory").dialog('close');
            }
        }
    });
}

function loadSystemFilesAndFolders(CategoryID) {
    if (CategoryID == 0) {
        $.ajax({
            url: ServicePath + "GetSystemGalleryFoldersandFiles",
            type: "POST",
            data: JSON.stringify({ companyid: CompanyID, categoryid: CategoryID, templateid: TemplateID, objectid: selectedObjectID, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (folderAndFiles) {
                var FolderAndFiles = JSON.parse(JSON.stringify(folderAndFiles.d));
                createFolderStructureForSytemGallery(FolderAndFiles, 0, -1);
            }
        });
    }
    else {
        $.ajax({
            url: ServicePath + "GetSystemGallerySubFoldersandFiles",
            type: "POST",
            data: JSON.stringify({ companyid: CompanyID, categoryid: CategoryID, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (folderAndFiles) {
                var FolderAndFiles = JSON.parse(JSON.stringify(folderAndFiles.d));
                createFolderStructureForSytemGallery(FolderAndFiles, CategoryID, FolderAndFiles.ParentID);
            }
        });
    }
}
function loadUserFilesAndFolders(CategoryID) {
    $.ajax({
        url: ServicePath + "GetFrontendUserImageGallery",
        type: "POST",
        data: JSON.stringify({ companyid: CompanyID, categoryid: CategoryID, userid: UserID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (folderAndFiles) {
            var FolderAndFiles = JSON.parse(JSON.stringify(folderAndFiles.d));
            $(".loading_gallery").show();
            createFolderStructureForUserGallery(FolderAndFiles, CategoryID);
        }
    });
}

function editImageDetails(FolderAndFiles, id) {
    for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {
        if (FolderAndFiles.ImageGallery[i].ImageID == parseInt(id)) {

            $("#txtImageName").val(FolderAndFiles.ImageGallery[i].OriginalFileName);
            $("#txtMetaTags").val(FolderAndFiles.ImageGallery[i].MetaTags);
            $("#txtEditDescription").val(FolderAndFiles.ImageGallery[i].Description);
            if (FolderAndFiles.ImageGallery[i].FileName.split('.')[1].toLowerCase() == "pdf") {
                $("#imgEditImage").attr('src', SiteImages + "/processing.png");
            }
            else {
                $("#imgEditImage").attr('src', FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + FolderAndFiles.ImageGallery[i].FileName);
            }

            loadCategorydropdownsforEdit(FolderAndFiles.ImageGallery[i].CategoryID);
            $(".btnupdateimagedetails").attr('id', 'updateimagedetails_' + id);
            $(".lnkchangeImage").attr('id', 'chageimage_' + id);
        }
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

function assignImage(fileName, gallery) {



    var zoom = parseInt(parseFloat(zoomvalue()) * 100);
    var width;
    var height;
    var objectid = selectedObjectID;

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


    width = parseInt(Control.Width * mmConvertionConstant);
    height = parseInt(Control.Height * mmConvertionConstant);


    var exxceeimage = "";

    exxceeimage = Control.ExceedImage;

    if (Control.IsImageQuality) {
        var Data;
        if (gallery == "system") {
            Data = JSON.stringify({ OriginalImageName: fileName, isEdited: "false", ischecked: "true", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI });
        }
        else if (gallery == "user") {
            Data = JSON.stringify({ OriginalImageName: fileName, isEdited: "false", ischecked: "true", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI });
        }
        $.ajax({
            url: WebMethodsPath + "checkImageForDPI",
            type: "POST",
            data: Data,
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (DPIResult) {
                if (DPIResult.d == "success") {
                    LoadImage();
                }
                else {
                    $("#SaveMessage").dialog("open");
                    $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
                    designMessageBox();
                    $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                    $(".loadingNewMask").show();
                }
            }
        });
    }
    else {
        LoadImage();
    }

    function LoadImage() {
        if (exxceeimage == "P") {
            var FitImageToContoll = {};
            FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
            FitImageToContoll.type = "POST";
            if (gallery == "system") {
                FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "false", ischecked: "true", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop });
            }
            else if (gallery == "user") {
                FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "false", ischecked: "true", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop });
            }
            FitImageToContoll.dataType = "json";
            FitImageToContoll.processData = false;
            FitImageToContoll.contentType = "application/json; charset=utf-8";
            FitImageToContoll.success = function (ImageName) {


                var arry = ImageName.d.split('~');
                ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

                Control.ImgUrl = arry[0];
                Control.OrignalImageName = arry[2];
                Control.IsFromBackEnd = false;
                Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
                Control.IsCropped = Boolean(arry[5]);
                $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });

                $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + arry[0]);
                $(".loading_gallery").hide();
                $("#ImageFromGallery").dialog("close");
                $(".loading_new").show();
                var tmpImg = new Image();
                tmpImg.src = FrontEndDocumentPath + TemplateID + "/Images/" + arry[0];
                $(tmpImg).on('load', function () {
                    $(".loading_new").hide();
                });
                alignsingleImage(Control.ObjectID);

            };
            $.ajax(FitImageToContoll);
        }
        else {
            var parameters = "";
            if (gallery == "system") {
                parameters = JSON.stringify({ originalFilename: fileName, sourcepath: ImageUploadPath + CompanyID + "\\Images\\Gallery\\OriginalImages\\", savepath: FrontEndUploadPath + TemplateID + "\\Images\\" });
            }
            else if (gallery == "user") {
                parameters = JSON.stringify({ originalFilename: fileName, sourcepath: FrontEndUploadPath + "UsersImages\\" + UserID + "\\Gallery\\OriginalImages\\", savepath: FrontEndUploadPath + TemplateID + "\\Images\\" });
            }
            $.ajax({
                url: WebMethodsPath + "assignToTemplateFolrder",
                type: "POST",
                data: parameters,
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (imageName) {
                    var ImageName = imageName.d;
                    if (exxceeimage == "S") {

                        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                        Control.ImgUrl = ImageName;
                        Control.OrignalImageName = ImageName;
                        Control.IsFromBackEnd = false;
                        var imagepath = FrontEndDocumentPath + TemplateID + "/Images/" + ImageName;
                        $("#" + Control.ObjectID + " img").attr('src', imagepath);
                        $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                        //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + Control.ImgUrl);
                        $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                        Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                        if (fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign)) {
                            $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                            if ($("#" + Control.ObjectID).hasClass('Para')) {
                                $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                            }
                        }

                        $(".loading_gallery").hide();
                        $("#ImageFromGallery").dialog("close");
                        $(".loading_new").show();
                        var tmpImg = new Image();
                        tmpImg.src = imagepath;
                        $(tmpImg).on('load', function () {
                            $(".loading_new").hide();
                        });
                        alignsingleImage(Control.ObjectID);

                    }
                    else if (exxceeimage == "D") {
                        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                        Control.ImgUrl = ImageName;
                        Control.OrignalImageName = ImageName;
                        Control.IsFromBackEnd = false;
                        //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
                        var imagepath = FrontEndDocumentPath + TemplateID + "/Images/" + ImageName;
                        var tmpImg = new Image();
                        tmpImg.src = imagepath;
                        $(tmpImg).on('load', function () {
                            var orgWidth = tmpImg.width;
                            var orgHeight = tmpImg.height;
                            $("#" + Control.ObjectID + " img").attr('src', imagepath);
                            $("#" + Control.ObjectID).css({ 'width': orgWidth + 'px', 'height': orgHeight + 'px' });
                            $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                            $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                            Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                            Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                            Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
                            Control.Width = parseFloat($("#" + Control.ObjectID).innerWidth()) / mmConvertionConstant;
                            if (fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign)) {
                                $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                                if ($("#" + Control.ObjectID).hasClass('Para')) {
                                    $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                                }
                            }
                            $(".loading_gallery").hide();
                            $("#ImageFromGallery").dialog("close");
                            $(".loading_new").show();
                            var tmpImg = new Image();
                            tmpImg.src = imagepath;
                            $(tmpImg).on('load', function () {
                                $(".loading_new").hide();
                            });
                            alignsingleImage(Control.ObjectID);
                        });

                    }
                }
            });
        }
    }
}


function searchByText(SearchText, CategoryID, Gallery) {
    if (Gallery == "UserGallery") {
        $(".loading_gallery").show();
        $.ajax({
            url: ServicePath + "GetUserGallerySearch",
            type: "POST",
            data: JSON.stringify({ companyid: CompanyID, categoryid: CategoryID, userid: UserID, searchtext: SearchText, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (folderAndFiles) {
                $(".loading_gallery").show();
                var FolderAndFiles = JSON.parse(JSON.stringify(folderAndFiles.d));
                createFolderStructureForUserGallery(FolderAndFiles, -1, true);
            }
        });
    }
    else if (Gallery == "SystemGallery") {
        $(".loading_gallery").show();
        $.ajax({
            url: ServicePath + "GetSystemGallerySearch",
            type: "POST",
            data: JSON.stringify({ companyid: CompanyID, categoryid: CategoryID, templateid: TemplateID, objectid: selectedObjectID, searchtext: SearchText, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (folderAndFiles) {
                $(".loading_gallery").show();
                var FolderAndFiles = JSON.parse(JSON.stringify(folderAndFiles.d));
                createFolderStructureForSytemGallery(FolderAndFiles, CategoryID, -1, true);
            }
        });
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

/*completed*/
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

/*completed*/
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

function VerticalGroupText(objectid, groupid) {
    var count = 0;

    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].GroupID == groupid) {
            if (ControllDetails[i].ObjectID == objectid) {
                break;
            }
            count++;
        }
    }

    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].ObjectID == objectid) {
            for (var j = 0; j < VerticalGroupingData.length; j++) {
                if (ControllDetails[i].GroupID == VerticalGroupingData[j].GID) {
                    var positiony = (((parseFloat($("#" + ControllDetails[i].ObjectID).innerHeight()) / mmConvertionConstant) + VerticalGroupingData[j].ControlSpace) * (count)) + VerticalGroupingData[j].PositionY;
                    if (fixPostionOfControll(ControllDetails[i], VerticalGroupingData[j].PositionX - CropMarkWidth, positiony - CropMarkHeight, VerticalGroupingData[j].Alignment)) {
                        $("#" + ControllDetails[i].ObjectID).css('text-align', ControllDetails[i].TextAlign);
                        if ($("#" + ControllDetails[i].ObjectID).hasClass('Para')) {
                            $("#" + ControllDetails[i].ObjectID + " p").css('text-align', ControllDetails[i].TextAlign);
                        }
                    }
                }
            }
        }
    }
}

function minmax(value, min, max) {
    if (parseInt(value) < min || isNaN(value))
        return min;
    else if (parseInt(value) > max)
        return max;
    else return value;
}


function onfocusoutgroupCntorll() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (Control.GroupID != 0) {
        if (Control.GroupOrientation == "Vertical") {
            var Group;
            VerticalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });
            if (Group.GroupOption == "None" || Group.GroupOption == "") {
                VerticalGroupPostioning(Group, "", Group.PositionX, Group.PositionY);
            }
            KeepOptionPositioning("", Group.GroupOption);
        }
        else if (Control.GroupOrientation == "Horizontal") {
            var Group;
            HorizontalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });
            if (Group.GroupOption == "None" || Group.GroupOption == "") {
                HorizontalGroupPostioning(Group, "", Group.PositionX, Group.PositionY);
            }
            KeepOptionPositioning("", Group.GroupOption);
        }
    }
    else {
        KeepOptionPositioning("", Control.KeepOptions);
    }
}

function onfocusingroupCntorll(id) {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

    if (Control.GroupID != 0) {
        if (Control.GroupOrientation == "Vertical") {
            var Group;
            VerticalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });
            if (Group.GroupOption == "None" || Group.GroupOption == "") {
                VerticalGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
            }
            else {
                KeepOptionPositioning(Control.ObjectID, Group.GroupOption);
            }
        }
        else if (Control.GroupOrientation == "Horizontal") {
            var Group;

            HorizontalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });

            if (Group.GroupOption == "None" || Group.GroupOption == "") {
                HorizontalGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
            }
            else {
                KeepOptionPositioning(Control.ObjectID, Group.GroupOption);
            }
        }

    }
    else {
        KeepOptionPositioning(Control.ObjectID, Control.KeepOptions);
    }
}

/*Completed*/
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

function getControlNumber(objectID) {
    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].ObjectID == objectID) {
            return ControllDetails[i].OrderNumber;
        }
    }

}

function getGroupControlsByGroupID(GroupID) {
    var ControlsIngroup = [];
    ControllDetails.map(function (proj) { if (proj.GroupID == GroupID) ControlsIngroup.push(proj) });
    return ControlsIngroup;
}

function getVerticalGroupDetailsByGroupID(GroupID) {
    var Group;
    VerticalGroupingData.map(function (proj) { if (proj.GID == GroupID) Group = proj });
    return Group;
}

function getHorizontalGroupDetailsByGroupID(GroupID) {
    var Group;
    HorizontalGroupingData.map(function (proj) { if (proj.GID == GroupID) Group = proj });
    return Group;
}





function VerticalGroupPostioning(Group, infocusobjectid, PositionStartX, PostionStartY, Pageload) {

    var ControlsIngroup = getGroupControlsByGroupID(Group.GID);
    var numberOfControlsinGroup = ControlsIngroup.length;

    var originalGroupPositionUpdateList = originalGropPositionUpdateGroupID(Group.GID, PositionStartX, PostionStartY);

    var positionIndex = -1;
    for (var i = 0; i < originalGroupPositionUpdateList.length; i++) {
        if (originalGroupPositionUpdateList[i].PageNumber == parseInt($("#lblcurrentpage").html())) {

            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == originalGroupPositionUpdateList[i].ObjectID) Control = proj });
            if (Control.DefaultContent != "") {
                var positionx = originalGroupPositionUpdateList[i].PositionX, positiony = originalGroupPositionUpdateList[i].PositionY;
                if (positionIndex >= 0) {
                    positionx = originalGroupPositionUpdateList[positionIndex].PositionX;
                    positiony = originalGroupPositionUpdateList[positionIndex].PositionY;
                    positionIndex = positionIndex + 1;
                }
                if (fixPostionOfControll(Control, positionx - CropMarkWidth, positiony - CropMarkHeight, Group.Alignment, true, true)) {
                    Control.TextAlign = Group.Alignment;
                    alignsingleLineText(Control.ObjectID);
                    $("#" + Control.ObjectID).css('text-align', Group.Alignment);
                    if ($("#" + Control.ObjectID).hasClass('Para')) {
                        $("#" + Control.ObjectID + " p").css('text-align', Group.Alignment);
                    }
                }

                $("#" + Control.ObjectID + " .label").show();

            }
            else {
                $("#" + Control.ObjectID + " .label").hide();
                if (Control.ObjectID == infocusobjectid) {
                    var positionx = originalGroupPositionUpdateList[i].PositionX, positiony = originalGroupPositionUpdateList[i].PositionY;
                    if (positionIndex >= 0) {
                        positionx = originalGroupPositionUpdateList[positionIndex].PositionX;
                        positiony = originalGroupPositionUpdateList[positionIndex].PositionY;
                        positionIndex = positionIndex + 1;
                    }
                    if (fixPostionOfControll(Control, positionx - CropMarkWidth, positiony - CropMarkHeight, Group.Alignment, pageLoad, true)) {
                        Control.TextAlign = Group.Alignment;
                        alignsingleLineText(Control.ObjectID);
                        $("#" + Control.ObjectID).css('text-align', Group.Alignment);
                        if ($("#" + Control.ObjectID).hasClass('Para')) {
                            $("#" + Control.ObjectID + " p").css('text-align', Group.Alignment);
                        }
                    }
                    if (Control.DefaultContent != "") {
                        applyBorderForControl(Control.ObjectID, Control.Type);
                    }
                    else {
                        removeBorderForControl(Control.ObjectID, Control.Type);
                    }
                }
                else {
                    removeBorderForControl(Control.ObjectID, Control.Type);
                    if (positionIndex == -1) {
                        positionIndex = i;
                    }
                }
            }
        }
    }
}

function HorizontalGroupPostioning(Group, infocusobjectid, PositionStartX, PostionStartY, pageLoad) {
    debugger;
    var ControlsIngroup = getGroupControlsByGroupID(Group.GID);
    var numberOfControlsinGroup = ControlsIngroup.length;
    var count = 0, width = 0;
    ;
    if (Group.Alignment.toLowerCase() == "left") {
        ControlsIngroup = sortJSON(ControlsIngroup, "Left", "ASC");
        for (var i = 0; i < ControlsIngroup.length; i++) {
            if (ControlsIngroup[i].DefaultContent != "") {
                var ContorlsWidthandCount = getWidthOfcontrollsLeftInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, "Left", ControlsIngroup).split(',');
                fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], "", PositionStartX, PostionStartY, pageLoad);
                $("#" + ControlsIngroup[i].ObjectID + " .label").show();
            }
            else {
                $("#" + ControlsIngroup[i].ObjectID + " .label").hide();
                if (ControlsIngroup[i].ObjectID == infocusobjectid) {
                    var ContorlsWidthandCount = getWidthOfcontrollsLeftInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, "Left").split(',');
                    fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], "", PositionStartX, PostionStartY, pageLoad);
                    if (ControlsIngroup[i].DefaultContent != "") {
                        applyBorderForControl(ControlsIngroup[i].ObjectID, ControlsIngroup[i].Type);
                    }
                    else {
                        removeBorderForControl(ControlsIngroup[i].ObjectID, ControlsIngroup[i].Type);
                    }

                }
                else {
                    removeBorderForControl(ControlsIngroup[i].ObjectID, ControlsIngroup[i].Type);
                }
            }
        }
    }
    else if (Group.Alignment.toLowerCase() == "right") {
        ControlsIngroup = sortJSON(ControlsIngroup, "Left", "ASC");
        for (var i = 0; i < ControlsIngroup.length; i++) {
            if (ControlsIngroup[i].DefaultContent != "") {
                var ContorlsWidthandCount = getWidthOfcontrollsRightInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, ControlsIngroup).split(',');
                fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], "", PositionStartX, PostionStartY, pageLoad);
                $("#" + ControlsIngroup[i].ObjectID + " .label").show();
            }
            else {
                $("#" + ControlsIngroup[i].ObjectID + " .label").hide();
                if (ControlsIngroup[i].ObjectID == infocusobjectid) {
                    var ContorlsWidthandCount = getWidthOfcontrollsRightInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid).split(',');
                    fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], "", PositionStartX, PostionStartY, pageLoad);
                    if (ControlsIngroup[i].DefaultContent != "") {
                        applyBorderForControl(ControlsIngroup[i].ObjectID, ControlsIngroup[i].Type);
                    }
                    else {
                        removeBorderForControl(ControlsIngroup[i].ObjectID, ControlsIngroup[i].Type);
                    }
                }
                else {
                    removeBorderForControl(ControlsIngroup[i].ObjectID, ControlsIngroup[i].Type);
                }
            }
        }
    }
    else if (Group.Alignment.toLowerCase() == "center") {
        for (var i = 0; i < ControlsIngroup.length; i++) {
            if (ControlsIngroup[i].DefaultContent != "") {
                var widthForCenter = parseFloat(getWidthOfAllControlSForCenter(ControlsIngroup[i].GroupID, infocusobjectid));
                var ContorlsWidthandCount = getWidthOfcontrollsLeftInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, "Center", ControlsIngroup).split(',');
                fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], widthForCenter, PositionStartX, PostionStartY, pageLoad);
                $("#" + ControlsIngroup[i].ObjectID + " .label").show();
            }
            else {
                $("#" + ControlsIngroup[i].ObjectID + " .label").hide();
                if (ControlsIngroup[i].ObjectID == infocusobjectid) {
                    var widthForCenter = parseFloat(getWidthOfAllControlSForCenter(ControlsIngroup[i].GroupID, infocusobjectid));
                    var ContorlsWidthandCount = getWidthOfcontrollsLeftInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, "Center", ControlsIngroup).split(',');
                    fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], widthForCenter, PositionStartX, PostionStartY, pageLoad);
                    if (ControlsIngroup[i].DefaultContent != "") {
                        applyBorderForControl(ControlsIngroup[i].ObjectID, ControlsIngroup[i].Type);
                    }
                    else {
                        removeBorderForControl(ControlsIngroup[i].ObjectID, ControlsIngroup[i].Type);
                    }
                }
                else {
                    removeBorderForControl(ControlsIngroup[i].ObjectID, ControlsIngroup[i].Type);
                }
            }
        }
    }
}

function fixPostionOfHoriZontalGroupControll(ObjectID, Group, allContorlsWidth, Count, widthForCenter, PositionStartX, PostionStartY, pageLoad) {
    var ControlsIngroup = getGroupControlsByGroupID(Group.GID);
    var numberOfControlsinGroup = ControlsIngroup.length;

    var Control, i = 0, index = null;
    ControlsIngroup.map(function (proj) { if (proj.ObjectID == ObjectID) { Control = proj; index = i } else { i++; } });


    var labelwidth = 0, positionx = 0, TextWidth = 0, Alignment;

    if (Group.Alignment.toLowerCase() == "left") {
        if (Control.LabelPosition == "customLeft" && index != 0) {
            labelwidth = parseFloat(Control.CustomLeft);
        }
        positionx = parseFloat(allContorlsWidth) + (Group.ControlSpace * parseFloat(Count)) + labelwidth + parseFloat(PositionStartX);
        Alignment = "Left";
    }
    else if (Group.Alignment.toLowerCase() == "right") {
        positionx = parseFloat(PositionStartX) - (parseFloat(allContorlsWidth) + (Group.ControlSpace * parseFloat(Count)));
        Alignment = "Right";
    }
    else if (Group.Alignment.toLowerCase() == "center") {
        if (Control.LabelPosition == "customLeft") {
            labelwidth = parseFloat(Control.CustomLeft);
        }
        positionx = (parseFloat(PositionStartX) + (parseFloat(allContorlsWidth) + (Group.ControlSpace * parseFloat(Count)))) + labelwidth - widthForCenter;
        Alignment = "Left";
    }

    if (fixPostionOfControll(Control, positionx - CropMarkWidth, parseFloat(PostionStartY) - CropMarkHeight, Alignment, pageLoad, true)) {
        Control.TextAlign = Alignment;
        alignsingleLineText(Control.ObjectID);
        $("#" + Control.ObjectID).css('text-align', Alignment);
        if ($("#" + Control.ObjectID).hasClass('Para')) {
            $("#" + Control.ObjectID + " p").css('text-align', Alignment);
        }
    }
}

function getWidthOfcontrollsLeftInGroup(groupid, objectid, focusedObjectid, alignment, ControlsIngroup) {
    var numberOfControlsinGroup = ControlsIngroup.length;
    var width = 0, count = 0;

    for (var i = 0; i < ControlsIngroup.length; i++) {
        if (ControlsIngroup[i].ObjectID == objectid) {
            break;
        }
        else {
            if (ControlsIngroup[i].DefaultContent != "") {
                width += getControlWidth(ControlsIngroup[i]);
                count++;
                if (i == 0 && alignment == "Left") {
                    if (ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
                        width -= ControlsIngroup[i].CustomLeft;
                    }
                }
            }
            else if (ControlsIngroup[i].ObjectID == focusedObjectid) {
                width += getControlWidth(ControlsIngroup[i]);
                count++;
                if (i == 0 && alignment == "Left") {
                    if (ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
                        width -= ControlsIngroup[i].CustomLeft;
                    }
                }
            }
        }
    }
    return width + "," + count;
}

function getWidthOfcontrollsRightInGroup(groupid, objectid, focusedObjectid, ControlsIngroup) {
    var width = 0, count = 0;

    for (var i = ControlsIngroup.length - 1; i >= 0; i--) {
        if (ControlsIngroup[i].ObjectID == objectid) {
            break;
        }
        else {
            if (ControlsIngroup[i].DefaultContent != "") {
                width += getControlWidth(ControlsIngroup[i]);
                count++;
            }
            else if (ControlsIngroup[i].ObjectID == focusedObjectid) {
                width += getControlWidth(ControlsIngroup[i]);
                count++;
            }
        }
    }
    return width + "," + count;
}

function getWidthOfAllControlSForCenter(groupID, focusedObjectid) {

    var ControlsIngroup = getGroupControlsByGroupID(groupID);
    var Group = null;
    HorizontalGroupingData.map(function (proj) { if (proj.GID == groupID) Group = proj });
    var width = 0, count = 0;

    for (var i = 0; i < ControlsIngroup.length; i++) {
        if (ControlsIngroup[i].DefaultContent != "") {
            width += getControlWidth(ControlsIngroup[i]);
            width += Group.ControlSpace;
            count++;
        }
        else {
            if (ControlsIngroup[i].ObjectID == focusedObjectid) {
                width += getControlWidth(ControlsIngroup[i]);
                width += Group.ControlSpace;
                count++;
            }
        }
    }
    width -= Group.ControlSpace;
    return width / 2;
}

function getControlWidth(ControlsIngroup) {
    var width = 0;
    if ($("#" + ControlsIngroup.ObjectID).hasClass("Para")) {
        width += $("#" + ControlsIngroup.ObjectID + " p").outerWidth() / mmConvertionConstant;
    }
    else {
        width += ($("#" + ControlsIngroup.ObjectID + " .labelText").outerWidth()) / mmConvertionConstant;
    }
    return width;
}


function applyBorderForControl(id, ControlType) {
    if (ControlType == "TextBlock") {
        $("#" + id + " .labelText").css('border', '1px dashed rgb(128, 128, 128)');
    }
    else if (ControlType == "Paragraph") {
        $("#" + id + " p").css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });
    }
}
function removeBorderForControl(id, ControlType) {
    if (ControlType == "TextBlock") {
        $("#" + id + " .labelText").css({ 'border': '1px dashed rgba(0, 0, 0, 0)', 'border': '1px dashed transparent' });
        $("#" + id + " .label").css({ 'border': '1px dashed rgba(0, 0, 0, 0)', 'border': '1px dashed transparent' });
    }
    else if (ControlType == "Paragraph") {
        $("#" + id + " p").css({ 'border': '1px dashed rgba(0, 0, 0, 0)', 'border': '1px dashed transparent' });
    }
}



function checkForEmptyGroup(focusdObject, GroupID) {
    var Group = null;
    VerticalGroupingData.map(function (proj) { if (proj.GID == GroupID) Group = proj });
    if (Group == null) {
        HorizontalGroupingData.map(function (proj) { if (proj.GID == GroupID) Group = proj });
    }

    var empty = true;
    for (var j = 0; j < ControllDetails.length; j++) {
        if (ControllDetails[j].GroupID == Group.GID) {
            if (ControllDetails[j].DefaultContent != "") {
                empty = false;
            }
            else if (ControllDetails[j].ObjectID == focusdObject) {
                empty = false;
            }
        }
    }

    return empty;
}





function KeepOptionPositioning(objectid, keepoption, pageLoad) {

    var ListForKeepOption = [];
    if (keepoption == "Move Up" || keepoption == "Move Field Up") {
        ListForKeepOption = ListForMoveUp;
    }
    else if (keepoption == "Move Down" || keepoption == "Move Field Down") {
        ListForKeepOption = ListForMoveDown;
    }
    else if (keepoption == "Move Field Left") {
        ListForKeepOption = ListForKeepLeft;
    }
    else if (keepoption == "Move Field Right") {
        ListForKeepOption = ListForKeepRight;
    }

    var positionIndex = -1;
    for (var i = 0; i < ListForKeepOption.length; i++) {
        if (ListForKeepOption[i].PageNumber == parseInt($("#lblcurrentpage").html())) {
            var GroupOrControlInBtween = false, nextposition = -1;

            nextposition = i + 1;
            var PositionxVariedForHorizontalKeepOption = false, PositionxVariedForVerticalKeepOption = false;
            if (0 <= nextposition && nextposition < ListForKeepOption.length) {
                GroupOrControlInBtween = checkForAnyOtherGroupOrControlInBtween(keepoption, ListForKeepOption[nextposition].PositionY, ListForKeepOption[i].PositionY);
                if (keepoption == "Move Field Left" || keepoption == "Move Field Right") {
                    if (ListForKeepOption[nextposition].PositionY != ListForKeepOption[i].PositionY) {
                        PositionxVariedForHorizontalKeepOption = true;
                    }
                }
                //if (keepoption == "Move Down" || keepoption == "Move Field Down" || keepoption == "Move Up" || keepoption == "Move Field Up") {
                //    if (ListForKeepOption[nextposition].PositionX != ListForKeepOption[i].PositionX) {
                //        PositionxVariedForVerticalKeepOption = true;
                //    }
                //}
            }

            if (GroupOrControlInBtween == false) {
                if (ListForKeepOption[i].Type == "Control") {
                    var Control;
                    ControllDetails.map(function (proj) { if (proj.ObjectID == ListForKeepOption[i].ObjectID) Control = proj });
                    if (Control.DefaultContent != "") {
                        var positionx = ListForKeepOption[i].PositionX, positiony = ListForKeepOption[i].PositionY;
                        if (positionIndex >= 0) {
                            positionx = ListForKeepOption[positionIndex].PositionX;
                            positiony = ListForKeepOption[positionIndex].PositionY;
                            positionIndex = positionIndex + 1;
                        }
                        if (fixPostionOfControll(Control, positionx - CropMarkWidth, positiony - CropMarkHeight, Control.TextAlign, pageLoad)) {
                            $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                            alignsingleLineText(Control.ObjectID);
                            if ($("#" + Control.ObjectID).hasClass('Para')) {
                                $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                            }
                        }
                        $("#" + Control.ObjectID + " .label").show();
                    }
                    else {
                        $("#" + Control.ObjectID + " .label").hide();
                        if (Control.ObjectID == objectid) {
                            var positionx = ListForKeepOption[i].PositionX, positiony = ListForKeepOption[i].PositionY;
                            if (positionIndex >= 0) {
                                positionx = ListForKeepOption[positionIndex].PositionX;
                                positiony = ListForKeepOption[positionIndex].PositionY;
                                positionIndex = positionIndex + 1;
                            }
                            if (fixPostionOfControll(Control, positionx - CropMarkWidth, positiony - CropMarkHeight, Control.TextAlign, pageLoad)) {
                                $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                                alignsingleLineText(Control.ObjectID);
                                if ($("#" + Control.ObjectID).hasClass('Para')) {
                                    $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                                }
                            }
                            if (Control.DefaultContent != "") {
                                applyBorderForControl(Control.ObjectID, Control.Type);
                            }
                            else {
                                removeBorderForControl(Control.ObjectID, Control.Type);
                            }
                        }
                        else {
                            removeBorderForControl(Control.ObjectID, Control.Type);
                            if (positionIndex == -1) {
                                positionIndex = i;
                            }
                        }
                    }
                }
                else if (ListForKeepOption[i].Type == "VerticalGroup" || ListForKeepOption[i].Type == "HorizontalGroup") {
                    var EmptyGroup = checkForEmptyGroup(objectid, parseInt(ListForKeepOption[i].GroupID));


                    if (!EmptyGroup) {
                        var positionx = ListForKeepOption[i].PositionX, positiony = ListForKeepOption[i].PositionY;
                        if (positionIndex >= 0) {
                            positionx = ListForKeepOption[positionIndex].PositionX;
                            positiony = ListForKeepOption[positionIndex].PositionY;
                            positionIndex = positionIndex + 1;
                        }
                        if (ListForKeepOption[i].Type == "VerticalGroup") {
                            var Group;
                            VerticalGroupingData.map(function (proj) { if (proj.GID == ListForKeepOption[i].GroupID) Group = proj });
                            Group.CurrentPositionY = positiony;
                            Group.CurrentPositionX = positionx;
                            VerticalGroupPostioning(Group, objectid, positionx, positiony, pageLoad);
                        }
                        else {
                            var Group;
                            HorizontalGroupingData.map(function (proj) { if (proj.GID == ListForKeepOption[i].GroupID) Group = proj });
                            Group.CurrentPositionY = positiony;
                            Group.CurrentPositionX = positionx;
                            HorizontalGroupPostioning(Group, objectid, positionx, positiony, pageLoad);
                        }
                    }
                    else {
                        if (positionIndex == -1) {
                            positionIndex = i;
                        }
                    }
                }
            }
            else {
                if (ListForKeepOption[i].Type == "Control") {
                    var Control;
                    ControllDetails.map(function (proj) { if (proj.ObjectID == ListForKeepOption[i].ObjectID) Control = proj });

                    var positionx = ListForKeepOption[i].PositionX, positiony = ListForKeepOption[i].PositionY;
                    if (positionIndex >= 0) {
                        positionx = ListForKeepOption[positionIndex].PositionX;
                        positiony = ListForKeepOption[positionIndex].PositionY;
                        positionIndex = -1;
                    }

                    if (fixPostionOfControll(Control, positionx - CropMarkWidth, positiony - CropMarkHeight, Control.TextAlign, pageLoad)) {
                        alignsingleLineText(Control.ObjectID);
                        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                        if ($("#" + Control.ObjectID).hasClass('Para')) {
                            $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                        }
                    }
                }
                else if (ListForKeepOption[i].Type == "VerticalGroup" || ListForKeepOption[i].Type == "HorizontalGroup") {
                    var positionx = ListForKeepOption[i].PositionX, positiony = ListForKeepOption[i].PositionY;
                    if (positionIndex >= 0) {
                        positionx = ListForKeepOption[positionIndex].PositionX;
                        positiony = ListForKeepOption[positionIndex].PositionY;
                        positionIndex = -1;
                    }
                    if (ListForKeepOption[i].Type == "VerticalGroup") {
                        var Group;
                        VerticalGroupingData.map(function (proj) { if (proj.GID == ListForKeepOption[i].GroupID) Group = proj });
                        Group.CurrentPositionY = positiony;
                        Group.CurrentPositionX = positionx;
                        VerticalGroupPostioning(Group, objectid, positionx, positiony, pageLoad);
                    }
                    else {
                        var Group;
                        HorizontalGroupingData.map(function (proj) { if (proj.GID == ListForKeepOption[i].GroupID) Group = proj });
                        Group.CurrentPositionY = positiony;
                        Group.CurrentPositionX = positionx;
                        HorizontalGroupPostioning(Group, objectid, positionx, positiony, pageLoad);
                    }
                }
            }

            if (PositionxVariedForHorizontalKeepOption == true) {
                positionIndex = -1;
            }
        }
    }
}



function listOfPositionForMoveUp() {



    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].GroupID == 0 && ControllDetails[i].KeepOptions == "Move Field Up") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": ControllDetails[i].Left, "PositionY": ControllDetails[i].Top, "Type": "Control", "ObjectID": ControllDetails[i].ObjectID, "PageNumber": ControllDetails[i].PageNumber }));
            ListForMoveUp.push(posXposY);
        }
    }
    for (var i = 0; i < VerticalGroupingData.length; i++) {
        if (VerticalGroupingData[i].GroupOption == "Move Up") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": VerticalGroupingData[i].PositionX, "PositionY": VerticalGroupingData[i].PositionY, "Type": "VerticalGroup", "GroupID": VerticalGroupingData[i].GID, "PageNumber": VerticalGroupingData[i].PageNumber }));
            ListForMoveUp.push(posXposY);
        }
    }

    for (var i = 0; i < HorizontalGroupingData.length; i++) {
        if (HorizontalGroupingData[i].GroupOption == "Move Up") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": HorizontalGroupingData[i].PositionX, "PositionY": HorizontalGroupingData[i].PositionY, "Type": "HorizontalGroup", "GroupID": HorizontalGroupingData[i].GID, "PageNumber": HorizontalGroupingData[i].PageNumber }));
            ListForMoveUp.push(posXposY);
        }
    }


    if (ListForMoveUp.length > 0) {
        ListForMoveUp = sortJSON(ListForMoveUp, "PositionY", "DESC");
        ListForMoveUp = sortJSON(ListForMoveUp, "PositionX", "DESC");
    }

}

function listOfPositionForMoveDown() {
    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].GroupID == 0 && ControllDetails[i].KeepOptions == "Move Field Down") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": ControllDetails[i].Left, "PositionY": ControllDetails[i].Top, "Type": "Control", "ObjectID": ControllDetails[i].ObjectID, "PageNumber": ControllDetails[i].PageNumber }));
            ListForMoveDown.push(posXposY);
        }
    }
    for (var i = 0; i < VerticalGroupingData.length; i++) {
        if (VerticalGroupingData[i].GroupOption == "Move Down") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": VerticalGroupingData[i].PositionX, "PositionY": VerticalGroupingData[i].PositionY, "Type": "VerticalGroup", "GroupID": VerticalGroupingData[i].GID, "PageNumber": VerticalGroupingData[i].PageNumber }));
            ListForMoveDown.push(posXposY);
        }
    }

    for (var i = 0; i < HorizontalGroupingData.length; i++) {
        if (HorizontalGroupingData[i].GroupOption == "Move Down") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": HorizontalGroupingData[i].PositionX, "PositionY": HorizontalGroupingData[i].PositionY, "Type": "HorizontalGroup", "GroupID": HorizontalGroupingData[i].GID, "PageNumber": HorizontalGroupingData[i].PageNumber }));
            ListForMoveDown.push(posXposY);
        }
    }
    if (ListForMoveDown.length > 0) {
        ListForMoveDown = sortJSON(ListForMoveDown, "PositionY", "ASC");
        ListForMoveDown = sortJSON(ListForMoveDown, "PositionX", "ASC");
    }

}

function listOfPositionForKeepLeft() {

    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].GroupID == 0 && ControllDetails[i].KeepOptions == "Move Field Left") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": ControllDetails[i].Left, "PositionY": ControllDetails[i].Top, "Type": "Control", "ObjectID": ControllDetails[i].ObjectID, "PageNumber": ControllDetails[i].PageNumber }));
            ListForKeepLeft.push(posXposY);
        }
    }
    if (ListForKeepLeft.length > 0) {
        ListForKeepLeft = sortJSON(ListForKeepLeft, "PositionX", "ASC");
        ListForKeepLeft = sortJSON(ListForKeepLeft, "PositionY", "ASC");
    }


}

function listOfPositionForKeepRight() {

    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].GroupID == 0 && ControllDetails[i].KeepOptions == "Move Field Right") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": ControllDetails[i].Left, "PositionY": ControllDetails[i].Top, "Type": "Control", "ObjectID": ControllDetails[i].ObjectID, "PageNumber": ControllDetails[i].PageNumber }));
            ListForKeepRight.push(posXposY);
        }
    }
    if (ListForKeepRight.length > 0) {
        ListForKeepRight = sortJSON(ListForKeepRight, "PositionX", "DESC");
        ListForKeepRight = sortJSON(ListForKeepRight, "PositionY", "DESC");
    }

}

function checkForOriginalFile(userGalleryPath, systemGalleryPath, noImagePath, Filename) {
    debugger;
    var systemGallery = false;
    if (noImagePath == "") {
        if (userGalleryPath != "") {
            $.ajax({
                url: userGalleryPath,
                type: 'HEAD',
                error: function () {
                    loadImageEditor(userImagePath = FrontEndDocumentPath + TemplateID + "/Images/" + Filename);
                },
                success: function () {
                    loadImageEditor(userGalleryPath);
                }
            });
        }
        else {
            systemGallery = true;
        }
    }
    else {
        loadImageEditor(noImagePath);
    }

    if (systemGallery) {
        $.ajax({
            url: WebMethodsPath + "assignToTemplateFolrder",
            type: "POST",
            data: JSON.stringify({ originalFilename: Filename, sourcepath: ImageUploadPath + CompanyID + "\\Images\\", savepath: FrontEndUploadPath + "\\UsersImages\\" + UserID + "\\Gallery\\OriginalImages\\" }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (imageName) {
                var ImageName = imageName.d;
                loadImageEditor(FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + ImageName);
            }
        });
    }
}

function loadImageEditor(ImagePath) {
    $("div[aria-describedby=Imageeditor] .ui-dialog-buttonpane").css('margin-right', '30px');
    $("div[aria-describedby=Imageeditor] .ui-dialog-buttonpane .ui-button").css('margin', '5px');
    $("div[aria-describedby=Imageeditor] .ui-dialog-buttonpane .ui-button span").css({ 'font-size': '11px' });
    $("#RadImageEditor1_canvas").css('float', 'left');
    $("#RadImageEditor1").css({ 'width': '768px', 'position': 'absolute', 'left': '0px', 'margin-right': '50px', 'margin-left': '50px' });
    $("#Imageeditor").css('overflow', 'visible');


    var tmpImg = new Image();
    tmpImg.src = ImagePath;
    $(tmpImg).on('load', function () {
        var orgWidth = tmpImg.width;
        var orgHeight = tmpImg.height;
        $("#RadImageEditor1_canvas").attr('height', orgHeight);
        $("#RadImageEditor1_canvas").attr('width', orgWidth);
        $("#Imageeditor").dialog("open");
        GetEditor().insertImage(0, 0, ImagePath, "");
        if (orgHeight > 400 || orgWidth > 750) {
            GetEditor().zoomBestFit();
        }
        else {
            GetEditor().zoomImage(100, true);
        }

        $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
        $("div[aria-describedby=Imageeditor] .ui-widget-header img").remove();
        $("div[aria-describedby=Imageeditor] .ui-widget-header").prepend("<img src='StyleSheets/Images/edit_picture.png' width='20' height='20' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
    });
}



function theOriginalPositionofControlsByGroupID(GroupID) {
    var Group = null, oreintation = "Vertical";
    VerticalGroupingData.map(function (proj) { if (proj.GID == GroupID) Group = proj });

    if (Group == null) {
        HorizontalGroupingData.map(function (proj) { if (proj.GID == GroupID) Group = proj });
        oreintation = "Horizontal";
    }

    var ControlsIngroup = [];
    ControllDetails.map(function (proj) { if (proj.GroupID == GroupID) ControlsIngroup.push(proj) });

    var temp = [];

    if (oreintation == "Vertical") {
        if (Group.GrpKeepOption == "Move Field Up" || Group.GrpKeepOption == "Move Field Down") {
            ControlsIngroup = sortJSON(ControlsIngroup, "Top", "ASC");
            var PosY = 0, ControlSpace = 0;
            for (var i = 0; i < ControlsIngroup.length; i++) {
                var tempp = JSON.parse(JSON.stringify({ "ObjectID": ControlsIngroup[i].ObjectID, "PositionX": 0, "PositionY": PosY + ControlSpace, "Oreintation": oreintation, "PageNumber": ControlsIngroup[i].PageNumber }));
                temp.push(tempp);

                if ($("#" + ControlsIngroup[i].ObjectID).outerHeight() > 2) {
                    PosY += parseFloat($("#" + ControlsIngroup[i].ObjectID).outerHeight()) / mmConvertionConstant;
                }
                else {
                    PosY += ControlsIngroup[i].Height;
                }
                ControlSpace += Group.ControlSpace;
            }
        }
    }
    else if (oreintation == "Horizontal") {

        if (Group.Alignment == "Right") {
            ControlsIngroup = sortJSON(ControlsIngroup, "Left", "DESC");
            var PosX = 0, ControlSpace = 0;
            for (var i = 0; i < ControlsIngroup.length; i++) {
                var tempp = JSON.parse(JSON.stringify({ "ObjectID": ControlsIngroup[i].ObjectID, "PositionX": PosX - ControlSpace, "PositionY": 0, "Oreintation": oreintation, "PageNumber": ControlsIngroup[i].PageNumber }));
                temp.push(tempp);
                PosX -= parseFloat($("#" + ControlsIngroup[i].ObjectID).outerWidth()) / mmConvertionConstant;
                ControlSpace -= Group.ControlSpace;
            }
        }
        else if (Group.Alignment == "Left") {
            ControlsIngroup = sortJSON(ControlsIngroup, "Left", "ASC");
            var PosX = 0, ControlSpace = 0;
            for (var i = 0; i < ControlsIngroup.length; i++) {
                var tempp = JSON.parse(JSON.stringify({ "ObjectID": ControlsIngroup[i].ObjectID, "PositionX": PosX + ControlSpace, "PositionY": 0, "Oreintation": oreintation, "PageNumber": ControlsIngroup[i].PageNumber }));
                temp.push(tempp);
                PosX += parseFloat($("#" + ControlsIngroup[i].ObjectID).outerWidth()) / mmConvertionConstant;
                ControlSpace += Group.ControlSpace;
            }
        }
    }

    if (Group.GrpKeepOption == "Move Field Up") {
        temp = sortJSON(temp, "PositionY", "DESC")
    }
    else if (Group.GrpKeepOption == "Move Field Down") {
        temp = sortJSON(temp, "PositionY", "ASC");
    }

    OriginalGroupPositionByGroupID.push(JSON.parse(JSON.stringify({ "GroupID": GroupID, "Oreintation": oreintation, "Objects": temp })));
}

function originalGropPositionUpdateGroupID(GroupID, PositionStartX, PostionStartY) {
    var control;
    OriginalGroupPositionByGroupID.map(function (proj) { if (proj.GroupID == GroupID) control = proj.Objects });

    var controls = JSON.parse(JSON.stringify(control));

    for (var i = 0; i < controls.length; i++) {
        controls[i].PositionX += PositionStartX;
        controls[i].PositionY += PostionStartY;
    }
    return controls;
}

function postionControlsGroupWise() {

    if (VerticalGroupingData != null) {
        if (VerticalGroupingData.length > 0) {
            for (var i = 0; i < VerticalGroupingData.length; i++) {
                theOriginalPositionofControlsByGroupID(VerticalGroupingData[i].GID);
                if (VerticalGroupingData[i].GroupOption == "None" || VerticalGroupingData[i].GroupOption == "") {
                    VerticalGroupPostioning(VerticalGroupingData[i], "", VerticalGroupingData[i].PositionX, VerticalGroupingData[i].PositionY, true);
                }
            }
        }
    }
    if (HorizontalGroupingData != null) {
        if (HorizontalGroupingData.length > 0) {
            for (var i = 0; i < HorizontalGroupingData.length; i++) {
                theOriginalPositionofControlsByGroupID(HorizontalGroupingData[i].GID);
                if (HorizontalGroupingData[i].GroupOption == "None" || HorizontalGroupingData[i].GroupOption == "") {
                    HorizontalGroupPostioning(HorizontalGroupingData[i], "", HorizontalGroupingData[i].PositionX, HorizontalGroupingData[i].PositionY, true);
                }
            }
        }
    }

    KeepOptionPositioning("", "Move Field Up", true);

    KeepOptionPositioning("", "Move Field Down", true);

    KeepOptionPositioning("", "Move Field Left", true);

    KeepOptionPositioning("", "Move Field Right", true);

}

/*completed*/
function getuniquefontname() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    for (var i = 0; i < 10; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));
    return text;
}

/*completed*/
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

function nextPageWithControls(Page, Next) {
    if (Next == true) {
        if (Page < TemplateDetails.Totalpage) {
            Page = Page + 1;

            var ControllDetailsByPage = [];
            ControllDetails.map(function (proj) { if (proj.PageNumber == Page) ControllDetailsByPage.push(proj) });

            if (ControllDetailsByPage.length > 0) {
                return Page;
            }
            else {
                nextPageWithControls(Page, true);
            }
        }
        else {
            return "end";
        }
    }
    else {
        if (Page > 1) {
            Page = Page - 1;

            var ControllDetailsByPage = [];
            ControllDetails.map(function (proj) { if (proj.PageNumber == Page) ControllDetailsByPage.push(proj) });

            if (ControllDetailsByPage.length > 0) {
                return Page;
            }
            else {
                nextPageWithControls(Page, false);
            }
        }
        else {
            return "start";
        }
    }
}

function pagesWithControlsList() {
    var pagesWithControls = [];
    for (var i = 1; i <= TemplateDetails.Totalpage; i++) {
        var ControllDetailsByPage = [];
        ControllDetails.map(function (proj) { if (proj.PageNumber == i) ControllDetailsByPage.push(proj) });
        if (ControllDetailsByPage.length > 0) {
            pagesWithControls.push(i);
        }
    }
    return pagesWithControls;
}


function fitIscropFromTopImage(objectID) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == objectID) Control = proj });
    if (Control.BackgroundImage != "noimage.png" && Control.BackgroundImage != "noimage.jpg") {
        var zoom = parseInt(parseFloat(zoomvalue()) * 100);
        var width;
        var height;
        var objectid = selectedObjectID;




        width = parseInt(Control.Width * mmConvertionConstant);
        height = parseInt(Control.Height * mmConvertionConstant);


        var exxceeimage = "", gallery = "";
        exxceeimage = Control.ExceedImage;
        if (Control.IsFromBackEnd == true) {
            gallery = "system";
        }
        else {
            gallery = "user";
        }

        if (Control.IsImageQuality) {
            var Data;
            if (gallery == "system") {
                Data = JSON.stringify({ OriginalImageName: Control.OrignalImageName, isEdited: "false", ischecked: "false", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI });
            }
            else if (gallery == "user") {
                Data = JSON.stringify({ OriginalImageName: Control.OrignalImageName, isEdited: "false", ischecked: "false", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI });
            }
            $.ajax({
                url: WebMethodsPath + "checkImageForDPI",
                type: "POST",
                data: Data,
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (DPIResult) {
                    if (DPIResult.d == "success") {
                        LoadImage();
                    }
                    else {
                        $("#SaveMessage").dialog("open");
                        $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
                        designMessageBox();
                        $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                        $(".loadingNewMask").show();
                    }
                }
            });
        }
        else {
            LoadImage();
        }

        function LoadImage() {
            if (exxceeimage == "P") {
                var FitImageToContoll = {};
                FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
                FitImageToContoll.type = "POST";
                if (gallery == "system") {
                    FitImageToContoll.data = JSON.stringify({ OriginalImageName: Control.OrignalImageName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: objectID, isEdited: "false", ischecked: "false", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop });
                }
                else if (gallery == "user") {
                    FitImageToContoll.data = JSON.stringify({ OriginalImageName: Control.OrignalImageName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: objectID, isEdited: "false", ischecked: "false", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop });
                }
                FitImageToContoll.dataType = "json";
                FitImageToContoll.processData = false;
                FitImageToContoll.contentType = "application/json; charset=utf-8";
                FitImageToContoll.success = function (ImageName) {

                    var arry = ImageName.d.split('~');
                    ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

                    Control.ImgUrl = arry[0];
                    Control.OrignalImageName = arry[2];
                    Control.IsFromBackEnd = false;
                    Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                    Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
                    Control.IsCropped = Boolean(arry[5]);
                    $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 2 + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 2 + 'px' });

                    $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + arry[0]);
                    $("#ImageFromGallery").dialog("close");
                    alignsingleImage(Control.ObjectID);

                };
                $.ajax(FitImageToContoll);
            }
        }
    }
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
    changeThePageFromNavigation(parseInt($("#lblcurrentpage").html()), "currentpage");



    //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + "Gallery/OriginalImages/" + Control.BackgroundImage);
    bindMenuBar(Control.ObjectID);
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
    changeThePageFromNavigation(parseInt($("#lblcurrentpage").html()), "currentpage");

    Control.BackgroundImage = "";
    bindMenuBar(Control.ObjectID);
    $("#" + Control.ObjectID).css('border', '1px solid #B2B2B2');
    $("#" + Control.ObjectID).css('cursor', 'pointer');
}

/*completed*/
function changeColorByInputText() {
    chnageFontColorCMYKtoRGB();
}

/*completed*/
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
            $("#" + Control.ObjectID + " p").css('color', 'rgb(' + r + ',' + g + ',' + b + ')');
        }
    }
    $("#" + Control.ObjectID + " .label").css('color', labeelColor);
}


function checkForAnyOtherGroupOrControlInBtween(KeepOption, StartPosition, EndPosition) {

    if (KeepOption == "Move Field Up" || KeepOption == "Move Up") {
        KeepOption == "Move Field Up";
    }
    else if (KeepOption == "Move Field Down" || KeepOption == "Move Down") {
        KeepOption == "Move Field Down";
    }

    for (var i = 0; i < ControllDetails.length; i++) {
        if (StartPosition < EndPosition) {
            if (ControllDetails[i].GroupID == 0 && ControllDetails[i].KeepOptions != KeepOption && StartPosition < ControllDetails[i].OffsetTop && ControllDetails[i].OffsetTop < EndPosition) {
                return true;
            }
        }
        else {
            if (ControllDetails[i].GroupID == 0 && ControllDetails[i].KeepOptions != KeepOption && EndPosition < ControllDetails[i].OffsetTop && ControllDetails[i].OffsetTop < StartPosition) {
                return true;
            }
        }
    }

    if (KeepOption == "Move Field Up" || KeepOption == "Move Up") {
        KeepOption == "Move Up";
    }
    else if (KeepOption == "Move Field Down" || KeepOption == "Move Down") {
        KeepOption == "Move Down";
    }

    for (var i = 0; i < VerticalGroupingData.length; i++) {
        if (StartPosition < EndPosition) {
            if (VerticalGroupingData[i].GroupOption != KeepOption && StartPosition < VerticalGroupingData[i].CurrentPositionY && VerticalGroupingData[i].CurrentPositionY < EndPosition) {
                return true;
            }
        }
        else {
            if (VerticalGroupingData[i].GroupOption != KeepOption && EndPosition < VerticalGroupingData[i].CurrentPositionY && VerticalGroupingData[i].CurrentPositionY < StartPosition) {
                return true;
            }
        }

    }

    for (var i = 0; i < HorizontalGroupingData.length; i++) {
        if (StartPosition < EndPosition) {
            if (HorizontalGroupingData[i].GroupOption != KeepOption && StartPosition < HorizontalGroupingData[i].CurrentPositionY && HorizontalGroupingData[i].CurrentPositionY < EndPosition) {
                return true;
            }
        }
        else {
            if (HorizontalGroupingData[i].GroupOption != KeepOption && EndPosition < HorizontalGroupingData[i].CurrentPositionY && HorizontalGroupingData[i].CurrentPositionY < StartPosition) {
                return true;
            }
        }

    }
    return false;
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

    else if (event.target.id == "txtPostionY") {
        $("#txtPostionY").val(parseFloat(Control.PositionY).toFixed(4));
    }
    else if (event.target.id == "txtFontSize") {
        $("#txtFontSize").val(parseFloat(Control.FontSize).toFixed(4));
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
        $(e.target).val("0");
    }
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









