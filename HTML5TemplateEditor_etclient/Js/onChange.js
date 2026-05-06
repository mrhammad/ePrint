









/*Completed*/
function FitTheEditedImageToControl(fileName) {
    var zoom = parseInt(parseFloat(zoomvalue()) * 100);
    var width;
    var height;
    var objectid = selectedObjectID;
    var exxceeimage = "";
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    width = parseInt(Control.Width * mmConvertionConstant);
    height = parseInt(Control.Height * mmConvertionConstant);
    exxceeimage = Control.ExceedImage;

    if (Control.IsImageQuality) {
        $.ajax({
            url: WebMethodsPath + "checkImageForDPI",
            type: "POST",
            data: JSON.stringify({ OriginalImageName: Control.OrignalImageName, isEdited: "true", ischecked: "false", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI }),
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
        if (exxceeimage == "P") {
            var FitImageToContoll = {};
            FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
            FitImageToContoll.type = "POST";
            FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "true", ischecked: "false", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop });
            FitImageToContoll.dataType = "json";
            FitImageToContoll.processData = false;
            FitImageToContoll.contentType = "application/json; charset=utf-8";
            FitImageToContoll.success = function (ImageName) {

                var arry = ImageName.d.split('~');
                if (arry[0].toLowerCase() != "dpierror") {
                    ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });


                    Control.ImgUrl = arry[0];
                    Control.IsFromBackEnd = false;
                    Control.EditedImageName = arry[0];
                    Control.MaxHeight = parseFloat(arry[3] / mmConvertionConstant);
                    Control.MaxWidth = parseFloat(arry[4] / mmConvertionConstant);
                    Control.IsCropped = Boolean(arry[5]);
                    $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });

                    $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + arry[0]);
                    $(".loading_new").hide();
                }
                else {
                    $("#SaveMessage").dialog("open");
                    $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
                    designMessageBox();
                    $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                    $(".loadingNewMask").show();
                }
            };
            $.ajax(FitImageToContoll);
        }
        else if (exxceeimage == "S") {
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

            Control.EditedImageName = fileName;
            Control.ImgUrl = fileName;
            Control.IsFromBackEnd = false;
            //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
            $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + fileName);
            $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
            //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + Control.ImgUrl);
            $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
            Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
            Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
            if (fixPostionOfControll(Control, Control.PositionX - CropMarkWidth, Control.PositionY - CropMarkHeight, Control.TextAlign)) {
                $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                }
            }
            $(".loading_new").hide();

        }
        else if (exxceeimage == "D") {
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

            Control.EditedImageName = fileName;
            Control.ImgUrl = fileName;
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
                if (fixPostionOfControll(Control, Control.PositionX - CropMarkWidth, Control.PositionY - CropMarkHeight, Control.TextAlign)) {
                    $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                    if ($("#" + Control.ObjectID).hasClass('Para')) {
                        $("#" + Control.ObjectID + " p").css('text-align', Control.TextAlign);
                    }
                }
                $(".loading_new").hide();
            });

        }
    }

}


/*Completed*/
$(function () {
    $('.cp-128').colorpicker({
        parts: ['map', 'bar', 'cmyk'],
        colorFormat: ['cp,mp,yp,kp'],
        layout: {
            map: [0, 0, 1, 1], // Left, Top, Width, Height (in table cells).
            bar: [1, 0, 1, 1],
            cmyk: [2, 0, 1, 1]
        },
        part: {
            map: { size: 128 },
            bar: { size: 128 }
        },
        select: function (event, color) {
            changeColorByInputText();
        }
    });
    $(".ui-colorpicker,.ui-colorpicker table").css({ 'padding-left': '0px', 'padding-right': '0px', 'border-width': '0px' });
    $(".ui-colorpicker-number").css({ 'width': '50px', 'height': '18px', 'margin-left': '8px', 'margin-bottom': '3px' });
    $(".ui-colorpicker-cmyk-container label").css({ 'font-weight': 'bold', 'padding-left': '10px' });
    $(".ui-colorpicker-cmyk-c input").attr('id', 'txtC');
    $(".ui-colorpicker-cmyk-m input").attr('id', 'txtM');
    $(".ui-colorpicker-cmyk-y input").attr('id', 'txtY');
    $(".ui-colorpicker-cmyk-k input").attr('id', 'txtK');
    $(".colorcode table").css({ 'margin-bottom': '0px', 'padding-bottom': '0px', 'padding-top': '0px' });
    $(".colorcode div").css({ 'margin-bottom': '0px', 'padding-bottom': '0px', 'padding-top': '0px' });
    $("#txtC").attr('type', 'text');
    $("#txtM").attr('type', 'text');
    $("#txtY").attr('type', 'text');
    $("#txtK").attr('type', 'text');
    $("#txtT").attr('type', 'text');
    $("#fontColor input[type=text]").css('text-align', 'left');
    $("#fontColor input[type=text]").attr('onkeypress', 'return validateQty(event)');
    $("#fontColor input[type=text]").attr('oninput', 'vaild(event)');
    $("#color").css({ 'margin-bottom': '0px', 'padding-bottom': '0px', 'padding-top': '0px' });
    $("#txtC,#txtM,#txtY,#txtK,#txtT").css({ 'width': '40px', 'height': '20px', 'font-family': 'verdana', 'font-size': '11px', 'margin': '5px 1px 5px 5px' });
    $(".ui-colorpicker-cmyk label").css({ 'font-family': 'verdana', 'font-size': '12px', 'padding-left': '0px' });
    $(".ui-colorpicker-unit").css({ 'font-family': 'verdana', 'font-size': '11px' });
});

$(function () {
    $("#SaveMessage").dialog({
        autoOpen: false,
        resizable: false,
        modal: true,
        buttons: {
            OK: function () {
                if (FocusID != "") {
                    $("#" + FocusID).focus();
                }
                $(this).dialog("close");
                $(".loadingNewMask").hide();
            }
        },
        close: function () {
            $(".loadingNewMask").hide();
        }
    });

    $("#Message").dialog({
        autoOpen: false,
        resizable: false,
        width: 450,
        height: 185,
        modal: true,
        buttons: {
            OK: function () {
                $(this).dialog("close");
            }
        }
    });

    $("#MandatoryMessage").dialog({
        autoOpen: false,
        resizable: false,
        width: 350,
        height: 150,
        modal: true,
        buttons: {
            OK: function () {
                if (FocusID != "") {
                    $("#" + FocusID).focus();
                }
                $(this).dialog("close");
            }
        }
    });

    $("#SaveDraftPopUp").dialog({
        autoOpen: false,
        resizable: false,
        width: 300,
        height: 175,
        modal: true
    });

    $("#ImageFromGallery").dialog({
        autoOpen: false,
        width: 700,
        resizable: false,
        height: 500,
        modal: true,
        close: function () {

            $('#multipleFileUpload').val("");
            $("#fileList").empty();
            filelist = "";
            $("#chkSvaeImagetomyGallery").prop('checked', false);
            $("#selectCat").hide();
            $("#totalContainer").hide();

            $("#usergallerylink").trigger("click");
            $("#galleryLink").trigger("click");

            $("#btnUnSelectAll").hide();
        }
    });

    $("#CreateCategory").dialog({
        autoOpen: false,
        height: 225,
        resizable: false,
        width: 350,
        modal: true,
        close: function () {
            $(".loadingNewMask").hide();
        }

    });
    $("#EditCategory").dialog({
        autoOpen: false,
        height: 225,
        resizable: false,
        width: 350,
        modal: true,
        close: function () {
            $(".loadingNewMask").hide();
        }

    });

    $("#UploadImage").dialog({
        autoOpen: false,
        height: 150,
        resizable: false,
        width: 300,
        modal: true,
        close: function () {
            $(".loadingNewMask").hide();
        }

    });

    $("#ImageDetails").dialog({
        autoOpen: false,
        height: 400,
        resizable: false,
        width: 650,
        modal: true,
        close: function () {
            $(".loadingNewMask").hide();
        }
    });

    $("#Imageeditor").dialog({
        effect: "clip",
        autoOpen: false,
        resizable: false,
        height: 575,
        width: 870,
        modal: true,
        buttons: {
            "Save & Close": function () {



                var Control;
                ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
                originalFilename = Control.OrignalImageName;


                var obj = GetEditor();

                $(".loading_new").show();

                var filecounter = 0;


                var array = originalFilename.split('.');
                var GUID = Guid();
                originalFilename = array[0] + "-" + GUID.substr(0, 3) + "." + array[1];

                var arry = originalFilename.split('.');
                alert(originalFilename);
                obj.saveImageOnServer(originalFilename, true);

                $(this).dialog("close");
                setTimeout(function () { FitTheEditedImageToControl(originalFilename) }, 5000);

            },
            "Save as New & Close": function () {
                var Control;
                ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
                originalFilename = Control.OrignalImageName;



                var obj = GetEditor();
                $(".loading_new").show();

                var filecounter = 0;

                var tmpImg = new Image();
                var array = originalFilename.split('.');
                var GUID = Guid();
                originalFilename = array[0] + "-" + GUID.substr(0, 3) + "." + array[1];

                obj.saveImageOnServer(originalFilename, true);
                $(this).dialog("close");
                setTimeout(function () { FitTheEditedImageToControl(originalFilename) }, 5000);
            }
        }

    });

    designMessageBox();
});

/*Completed*/








