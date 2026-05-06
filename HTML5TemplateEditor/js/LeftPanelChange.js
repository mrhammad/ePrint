$(function () {

    $("#btncheck").unbind('click').bind('click', function () {
        $.ajax({
            url: ServicePath + "checkmaxupload",
            type: "POST",
            data: JSON.stringify({ ControlDetail: JSON.stringify(ControllDetails), templateID: TemplateID, userid: UserID, companyid: CompanyID, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (resultFromSevice) {
                alert(resultFromSevice.d);
            },
            error: function (error, et) {
                alert("error");
            }
        });
    });

    $(".btnSearch").unbind('mouseenter').bind('mouseenter', function () {
        $(this).attr('src', 'StyleSheets/Images/search.png');
    });
    $(".btnSearch").unbind('mouseleave').bind('mouseleave', function () {
        $(this).attr('src', 'StyleSheets/Images/search_icon.png');
    });

    



    $("#txtC").attr('type', 'text');
    $("#txtM").attr('type', 'text');
    $("#txtY").attr('type', 'text');
    $("#txtK").attr('type', 'text');
    $("#txtT").attr('type', 'text');
    /************************Menubar******************************************/

    $("#btnCut").click(function () {
        cutCotroll();
    });

    $("#btnPaste").click(function () {
        pasteControll();
    });

    $("#btnCopy").unbind('click').bind('click', function () {
        copyControll();
    });

    $("#drpPageSelect").unbind('change').bind('change', function () {
        curentPageNumber = parseInt($("#drpPageSelect").val());
        changeThePageFromDropDown($(this).val());
    });

    $("#btnRotate").unbind('click').bind('click', function () {
        var rotation = $("#txtRotate").val();
        rotateSelectedControll(rotation);
    });

    $("#btnDeleteControl").unbind('click').bind('click', function () {
        deleteTheControll();
    });

    $("#btnBold").unbind('click').bind('click', function () {

        ChangeBoldItalic("bold");
    });
    $("#btnItalic").unbind('click').bind('click', function () {
        ChangeBoldItalic("italic");
    });

    $("#btnLeftAlign").unbind('click').bind('click', function () {
        changeAlignment("Left");
    });

    $("#btnCenterAlign").unbind('click').bind('click', function () {

        changeAlignment("Center");
    });

    $("#btnRightAlign").unbind('click').bind('click', function () {
        changeAlignment("Right");
    });

    $("#btnZoomIn").unbind('click').bind('click', function () {
        var zoom = zoomvalue();
        var ZoomIn = 0.05 + zoom;
        zoomTextCanvas(ZoomIn);
    });
    $("#btnZoomOut").unbind('click').bind('click', function () {
        var zoom = zoomvalue();
        var ZoomOut = zoom - 0.05;
        zoomTextCanvas(ZoomOut);
    });

    $("#txtZoom").unbind('keyup').bind('keyup', function () {
        var ZoomInPerCent = parseFloat($(this).val());
        var Zoom = ZoomInPerCent / 100.00;
        zoomTextCanvas(Zoom);
    });

    $("#btnLeftAlignCntrl").unbind('click').bind('click', function () {
        alignControllTothePage("left");
    });
    $("#btnCenterAlignCntrl").unbind('click').bind('click', function () {
        alignControllTothePage("center");
    });
    $("#btnRightAlignCntrl").unbind('click').bind('click', function () {
        alignControllTothePage("right");
    });

    /*Added By salim*/
    $("#btnClearAllControlls").unbind('click').bind('click', function () {

        var Control = [];
        var pagenum = parseInt($("#drpPageSelect").val());
        ControllDetails.map(function (proj) { if (proj.PageNumber == pagenum && proj.Visibility == true) Control.push(proj) });
        if (Control.length > 0) {

            if (confirm("Are you sure, you want to reset all the controls, this cannot be undone and it will delete all the controls from the template which is saved previously.")) {
                $(".loading_new").show();

                clearAllControlls(pagenum);

                ResetAllControls(pagenum);
                $(".loading_new").hide();
            }
        }
    });

    /*Added By salim*/
    $("#btncopyTemplate").unbind('click').bind('click', function () {

        var seleectedid = $(".txtCopy").attr('id').split('_')[1];

        if (seleectedid != "") {
            if (confirm("Are you sure you want to copy this Template, if you select OK you may loose the current settings")) {
                CopyExistingTemplate(seleectedid);
            }
        }
        else {           
            $("#savemsg").html("Please select existing template name to copy.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
            return false;
        }

    });

    $(".txtCopy").focusin(function () {
        var copyhtml = "";
        for (var i = 0; i < TemplateIDandNameList.length; i++) {
            copyhtml += "<div class='sapnCopy copyCombobox' id='copyid_" + TemplateIDandNameList[i].split('~')[0] + "' >" + TemplateIDandNameList[i].split('~')[1] + "</div>";
        }
        $("#copyDiv").html(copyhtml);
        copyClick();
        $("#copyDiv").show();
    });

    $(".txtCopy").unbind('keyup').bind('keyup', function (event) {

        if (event.which == 40 || event.which == 38 || event.which == 13) {
            selectTheTemplateName(event.which);
        }
        else {
            $("#copyDiv").empty();
            var copyhtml = "";
            for (var i = 0; i < TemplateIDandNameList.length; i++) {
                if (TemplateIDandNameList[i].split('~')[1].toLowerCase().indexOf($(this).val()) != -1) {
                    copyhtml += "<div class='sapnCopy copyCombobox' id='copyid_" + TemplateIDandNameList[i].split('~')[0] + "' >" + TemplateIDandNameList[i].split('~')[1] + "</div>";
                }
            }
            $("#copyDiv").html(copyhtml);
            copyClick();
        }
    });
    $(".txtCopy").click(function () {
        copy = true;
    });

    $("body").click(function () {
        if (copy == false) {
            $("#copyDiv").hide();
            $("#copyDiv").empty();
        }
        else {
            copy = false;
        }
    });

    /*****************************************END***************************************/

    /************************Information Panel******************************************/
    $("#txtFieldName").unbind('keyup').bind('keyup', function () {
        var value = $(this).val();

        changeFieldName(value, true);
        ReloadReviewFields();
        alignsingleLineText(selectedObjectID);
    });
    $("#txtFriendly").unbind('keyup').bind('keyup', function () {
        changeFriendlyName($(this).val());
    });
    $("#txtHelpText").unbind('keyup').bind('keyup', function () {
        changeHelpText($(this).val());
    });
    $("#txtDefaultContent,#txtParaDefaultContent").unbind('keyup').bind('keyup', function (e) {
        var value = $(this).val();

        if (value == "") {
            var fieldnmae = $("#txtFieldName").val();
            changeDefaultContent(fieldnmae, true, false);

            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

            Control.DefaultContent = "";
            $("#txtDefaultContent,#txtParaDefaultContent").val("");
        }
        else {
            changeDefaultContent(value, true, false, true);
        }
        alignsingleLineText(selectedObjectID);
    });

    $("#chkMandatory").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeMandatory(true);
        }
        else {
            changeMandatory(false);
        }

    });
    $("#chkNonEditable").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeNonEditable(true);
        }
        else {
            changeNonEditable(false);
            changeHideFromuser(false);
            $("#chkHideFromuser").prop('checked', false);
        }
    });
    $("#chkHideFromuser").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeHideFromuser(true);
            changeNonEditable(true);
            $("#chkNonEditable").prop('checked', true);
        }
        else {
            changeHideFromuser(false);
        }
    });
    /*****************************************END***************************************/
    /********************************LayOut and Properties Panel*************************/

    $(".txtRotateX").unbind('keyup').bind('keyup', function () {
        var rotation = $(this).val();
        rotateSelectedControll(rotation);
    });

    $("#txtLineSpacing").unbind('keyup').bind('keyup', function () {
        changeLineSpacing($(this).val());
    });

    $("#txtPostionX").unbind('keyup').bind('keyup', function () {
        var posXValue = parseFloat($("#txtPostionX").val());
        changePositioX(posXValue);
    });

    $("#txtPostionY").unbind('keyup').bind('keyup', function () {
        var posYValue = parseFloat($("#txtPostionY").val());
        changePositioY(posYValue);
    });

    $("#txtMaxWidth,#txtMaxImageWidth").unbind('keyup').bind('keyup', function () {
        var textWidth = $(this).val();
        changeMaxWidth(textWidth);
    });


    $("#txtMaxHeight,#txtMaxImageHeight").unbind('keyup').bind('keyup', function () {
        var textHeight = $(this).val();

        changeMaxHeight(textHeight)
    });


    $("#txtImagePostionX").unbind('keyup').bind('keyup', function () {
        var posXValue = parseFloat($("#txtImagePostionX").val());
        changePositioX(posXValue);
    });

    $("#txtImagePostionY").unbind('keyup').bind('keyup', function () {
        var posYValue = parseFloat($("#txtImagePostionY").val());
        changePositioY(posYValue);
    });


    $("#chkLockPosition,#chkImageLockPosition").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeLockPosition(true);
        }
        else {
            changeLockPosition(false);
        }
    });

    $("#rdtextDonothing").click(function () {
        if ($(this).prop('checked') == true) {
            changeOnexceedTexBlock("Do Nothing");
            $("#txttextTrscking").prop('disabled', true);
        }
    });

    $("#rdtextSideWays").click(function () {
        if ($(this).prop('checked') == true) {
            changeOnexceedTexBlock("Expand side");
            $("#txttextTrscking").prop('disabled', true);
        }
    });

    $("#rdtextShrink").click(function () {
        if ($(this).prop('checked') == true) {
            changeOnexceedTexBlock("Shrink");
            $("#txttextTrscking").prop('disabled', true);
        }
    });

    $("#rdtextTrscking").click(function () {
        if ($(this).prop('checked') == true) {
            changeOnexceedTexBlock("Tracking");
            $("#txttextTrscking").prop('disabled', false);
        }
    });

    $("#txttextTrscking").unbind('keyup').bind('keyup', function () {
        var Text = $(this).val();
        changeMaxShrinkTexBlock(Text);
    });

    $("#chkImagefromHardDrive").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            showHardDriveForImage(true);
        }
        else {
            showHardDriveForImage(false);
        }
    });
    $("#chkImageFromGallery").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            showGalleryForImage(true);
        }
        else {
            showGalleryForImage(false);
        }
    });

    $("#lnkAddFromGallery,#lnkAddFromHardDrive").unbind('click').bind('click', function () {
        if ($(this).attr('id') == "lnkAddFromGallery") {
            showGalleryForImage(true);
            $("#chkImageFromGallery").prop('checked', true);
        }
        else {
            showHardDriveForImage(true);
            $("#chkImagefromHardDrive").prop('checked', true);
        }
        loadFolderAndFilesBycategory("fromlink", 0);
    });


    $("#drpImageLocation").unbind('change').bind('change', function () {
        changeImageLocation($(this).val());
    });

    $("#rdoImagePropotional").click(function () {
        if ($(this).prop('checked') == true) {
            changeExeedWidth("P");
            $("#ChkCropfromtop").prop('disabled', false);
        }
    });

    $("#ChkCropfromtop").unbind('change').bind('change', function () {
        if (this.checked) {
            IsCropFromTopImage(true);
        }
        else { IsCropFromTopImage(false); }
    });

    $("#rdoImageScaleToFit").click(function () {
        if ($(this).prop('checked') == true) {
            $("#ChkCropfromtop").prop('disabled', true);
            $("#ChkCropfromtop").prop('checked', false);

            changeExeedWidth("S");
        }
    });
    $("#rdoImageDoNothing").click(function () {
        if ($(this).prop('checked') == true) {
            $("#ChkCropfromtop").prop('disabled', true);
            $("#ChkCropfromtop").prop('checked', false);
            changeExeedWidth("D");
        }
    });

    $("#chkBackground").unbind('change').bind('change', function () {

        //if ($("#chkBackground").is(':checked'))
        if (this.checked) {

            var _ctrlH = textCanvasHeight / mmConvertionConstant;
            var _ctrlW = textCanvasWidth / mmConvertionConstant;

            SetImageAsBackgroud(_ctrlH, _ctrlW);
        }
        else {
            var _ctrlH = 26.45833;
            var _ctrlW = 26.45833;
            var _defaultpos = 35;
            var _PosY = (textCanvasHeight / mmConvertionConstant) - _defaultpos;
            var _PosX = (textCanvasWidth / mmConvertionConstant) / 2;

            RemoveImageAsBackgroud(_ctrlW, _ctrlH, _PosX, _PosY);
        }
    });


    $("#rdparaSideWays").click(function () {
        if ($(this).prop('checked') == true) {
            changeExceedHeight("Expand Height");
        }
    });

    $("#rdparaDonothing").click(function () {
        if ($(this).prop('checked') == true) {
            changeExceedHeight("Do Nothing");
        }
    });

    $("#chkImageQuality").click(function () {
        if ($(this).prop('checked')) {
            ChangeImageQuality($(this).prop('checked'));
        }
        $("#DPI_Panel").slideToggle();
    });

    $("#txtDPI").unbind('keyup').bind('keyup', function () {
        changeMinDPI($(this).val());
    });


    /*****************************************END***************************************/


    /*****************************************Font Panel********************************/
    $("#txtFontStyle").prop('disabled', true);
    $("#drpApplyFont").unbind('change').bind('change', function () {
        applyFontToSelectedText($(this).val());
    });

    $("#txtFontIndent").unbind('keyup').bind('keyup', function () {
        if ($(this).val() != '') {
            applyIndentToSelecedText($(this).val());
        }
        else {
            applyIndentToSelecedText(0);
        }

        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        if (Control.FieldName == Control.DefaultContent) {
            changeDefaultContent(Control.DefaultContent, false, false);
        }
        else {
            changeDefaultContent(Control.DefaultContent, true, false);
        }
    });


    $("#txtFontSize").unbind('keyup').bind('keyup', function () {
        applyFontSizeToSelectedText();
    });


    $("#drpManualTrackSign").unbind('change').bind('change', function () {
        changeManualTraking("Sign", $(this).val());
    });

    $("#drpManualTrackDimension").unbind('change').bind('change', function () {
        changeManualTraking("Dimention", $(this).val());
    });

    $("#txtManulTracking").unbind('keyup').bind('keyup', function () {
        changeManualTraking("Text", $(this).val());
    });


    $("#drpFontStyle").unbind('change').bind('change', function () {
        var name = $(this).val().split('~')[1];

        if ($(this).val() != "0") {
            changeFontStyle(name);
        }
        else {
            changeFontStyle("");
        }
    });

    $("#rdCenterJustify").click(function () {
        if ($(this).prop('checked') == true) {
            changeAlignment("center");
        }
    });
    $("#rdRightJustify").click(function () {
        if ($(this).prop('checked') == true) {
            changeAlignment("right");
        }
    });
    $("#rdLeftJustify").click(function () {
        if ($(this).prop('checked') == true) {
            changeAlignment("left");
        }
    });

    $("#rdUserInput").click(function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("User Input");
        }
    });
    $("#rdAllUpper").click(function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("All Caps");
        }
    });
    $("#rdFirstLetterCaps").click(function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("InitCap");
        }
    });
    $("#rdAllWordFirstCaps").click(function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("First Cap");
        }
    });
    $("#rdAllLower").click(function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("All Lower");
        }
    });

    $("#chkParagraphJustify").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true == true) {
            changeParagraphJustificationValue("Justify");
        }
        else {
            changeParagraphJustificationValue("");
        }
    });

    $("#drpDataType").change(function () {

        changeDataType($(this).val());
    });

    /*****************************************END***************************************/

    /*****************************************Color Panel********************************/


    $("#txtC,#txtM,#txtY,#txtK").keyup(function (event) {

        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        var key = window.event ? event.keyCode : event.which;
        if (event.keyCode == 8 || event.keyCode == 46
         || event.keyCode == 37 || event.keyCode == 39) {
            changeColorByInputText();
        }
        else if (key < 48 || key > 57) {
            if (event.target.id = "txtC") {
                $("#txtC").val(parseFloat(Control.C));
            }
            if (event.target.id = "txtM") {
                $("#txtM").val(parseFloat(Control.M));
            }
            if (event.target.id = "txtY") {
                $("#txtY").val(parseFloat(Control.Y));
            }
            if (event.target.id = "txtK") {
                $("#txtK").val(parseFloat(Control.K));
            }
        }

    });
    $("#txtC,#txtM,#txtY,#txtK").unbind('change').bind('change', function () {
        changeColorByInputText();
    });

    $("#drpColorStyle").unbind('change').bind('change', function () {
        var id = $(this).attr('id');

        chengeColorStyle($(this).val());

    });

    $("#txtColorStyle").prop('disabled', true);
    $("#txtSpotColor").prop('disabled', true);

    $("#chkSpotColor").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            $("#txtSpotColor").prop('disabled', false);
            changeSpotColor(("#txtSpotColor").va(), true);
        }
        else {
            $("#txtSpotColor").prop('disabled', true);
            changeSpotColor("", false);
        }
    });
    $("#txtSpotColor").unbind('keyup').bind('keyup', function () {
        changeSpotColor($(this).val(), true);
    });


    /*****************************************END***************************************/

    /*****************************************Save Template Panel********************************/

    $("#chkAllowTextBlock").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeAllowTextBlock(true);
            $("#chkShowEditor").prop('checked', true);
            changeShowEditor(true);
        }
        else {
            changeAllowTextBlock(false);
        }
    });

    $("#chkAllowParagraph").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeAllowParagraph(true);
            $("#chkShowEditor").prop('checked', true);
            changeShowEditor(true);
        }
        else {
            changeAllowParagraph(false);
        }
    });

    $("#chkAllowImage").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeAllowImage(true);
            $("#chkShowEditor").prop('checked', true);
            changeShowEditor(true);
        }
        else {
            changeAllowImage(false);
        }
    });

    $("#chkShowEditor").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeShowEditor(true);
        }
        else {
            changeShowEditor(false);
            $("#chkAllowTextBlock").prop('checked', false);
            $("#chkAllowParagraph").prop('checked', false);
            $("#chkAllowImage").prop('checked', false);
            changeAllowTextBlock(false);
            changeAllowParagraph(false);
            changeAllowImage(false);
        }
    });

    $("#chkShoweditablePages").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeShoweditablePages(true);
        }
        else {
            changeShoweditablePages(false);
        }
    });

    $("#chkSendAttachments").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeSendAttachments(true);
        }
        else {
            changeSendAttachments(false);
        }
    });

    $("#txtTemplateName").unbind('keyup').bind('keyup', function () {
        changeTemplateName($(this).val());
    });

    $("#txtDescription").unbind('keyup').bind('keyup', function () {
        changeTemplateDescription($(this).val());
    });

    $("#btnSave").unbind('click').bind('click', function () {
        if (TemplateDetails.TemplateName != "") {
            var _istemplatesame = false;
            for (var i = 0; i < TemplateIDandNameList.length; i++) {
                var arry = TemplateIDandNameList[i].split('~');
                if (arry[1].toLowerCase() == ($('#txtTemplateName').val().toLowerCase())) {
                    _istemplatesame = true;
                    break;
                }
                else {
                    _istemplatesame = false;
                }
            }

            if (_istemplatesame == false) {
                $(".loading_new").show();
                UpadteTemplteDetails(true, false);
            }
            else {                
                $("#savemsg").html("Template name already exists.");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
            }
        }
        else {            
            $("#savemsg").html("Please enter template name.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }

    });

    $("#btnSaveandClose").unbind('click').bind('click', function () {
        if (TemplateDetails.TemplateName != "") {
            var _istemplatesame = false;
            for (var i = 0; i < TemplateIDandNameList.length; i++) {
                var arry = TemplateIDandNameList[i].split('~');
                if (arry[1].toLowerCase() == ($('#txtTemplateName').val().toLowerCase())) {
                    _istemplatesame = true;
                    break;
                }
                else {
                    _istemplatesame = false;
                }
            }
            if (_istemplatesame == false) {
                $(".loading_new").show();
                saveAndExit = true;
                UpadteTemplteDetails(false, true);

            }
            else {                
                $("#savemsg").html("Template name already exists.");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
            }
        }
        else {            
            $("#savemsg").html("Please enter template name.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }
    });

    /*****************************************END***************************************/


    /*****************************************Label Paenel***************************************/

    $("#rdUseLabel").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            AddLabel();
        }
        $("#txtLabel").prop('disabled', false);
        $("#drpLabelFontStyleID0").prop('selected', true);
        $("#drplabelFontStyle").prop('disabled', false);
        $("#drpLabelColorStyleID0").prop('selected', true);
        $("#drplabelColorStyle").prop('disabled', false);
        $("#rdAttached").prop('checked', true);
        $("#rdAttached").prop('disabled', false);
        $("#rdRightAttached").prop('checked', true);
        $("#rdRightAttached").prop('disabled', false);
        $("#rdCustomPostioning").prop('checked', false);
        $("#rdCustomPostioning").prop('disabled', false);
        $("#rdleftofobject").prop('checked', false);
        $("#rdleftofobject").prop('disabled', true);
        $("#rdaboveobject").prop('checked', false);
        $("#rdaboveobject").prop('disabled', true);
        $("#rdrightofobject").prop('checked', false);
        $("#rdrightofobject").prop('disabled', true);
        $(".leftofobject").val("");
        $(".leftofobject").prop('disabled', true);
        $(".aboveobject").val("");
        $(".aboveobject").prop('disabled', true);
    });

    $("#txtLabel").unbind('keyup').bind('keyup', function () {
        ChangeLabelText($(this).val());
    });

    $("#rdLabelnone").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            RemoveLabel();
        }

        $("#txtLabel").val("");
        $("#txtLabel").prop('disabled', true);
        $("#drpLabelFontStyleID0").prop('selected', true);
        $("#drplabelFontStyle").prop('disabled', true);
        $("#drpLabelColorStyleID0").prop('selected', true);
        $("#drplabelColorStyle").prop('disabled', true);
        $("#rdAttached").prop('checked', false);
        $("#rdAttached").prop('disabled', true);
        $("#rdRightAttached").prop('checked', false);
        $("#rdRightAttached").prop('disabled', true);
        $("#rdCustomPostioning").prop('checked', false);
        $("#rdCustomPostioning").prop('disabled', true);
        $("#rdleftofobject").prop('checked', false);
        $("#rdleftofobject").prop('disabled', true);
        $("#rdaboveobject").prop('checked', false);
        $("#rdaboveobject").prop('disabled', true);
        $("#rdrightofobject").prop('checked', false);
        $("#rdrightofobject").prop('disabled', true);
        $(".leftofobject").val("");
        $(".leftofobject").prop('disabled', true);
        $(".aboveobject").val("");
        $(".aboveobject").prop('disabled', true);
    });


    $("#rdCustomPostioning").unbind('change').bind('change', function () {

        if ($(this).prop('checked') == true) {
            AddCustomPositioning();
        }
        else if ($("#rdUseLabel").prop('checked') == true) {
            AddLabelAttached();
        }
    });

    $("#rdAttached").unbind('change').bind('change', function () {

        if ($(this).prop('checked') == true) {
            AddLabelAttached();
            $(".alignObject").prop('disabled', true);
            $(".alignObjectText").prop('disabled', true);
            $("#rdleftofobject").prop('checked', false);
            $("#rdaboveobject").prop('checked', false);
            $("#rdrightofobject").prop('checked', false);
        }
        else if ($("#rdUseLabel").prop('checked') == true) {
            AddCustomPositioning();
        }
    });

    $("#rdRightAttached").unbind('change').bind('change', function () {

        if ($(this).prop('checked') == true) {
            AddRightLabelAttached();
            $(".alignObject").prop('disabled', true);
            $(".alignObjectText").prop('disabled', true);
            $("#rdleftofobject").prop('checked', false);
            $("#rdaboveobject").prop('checked', false);
            $("#rdrightofobject").prop('checked', false);
        }
        else if ($("#rdUseLabel").prop('checked') == true) {
            AddCustomPositioning();
        }
    });

    $("#rdleftofobject").unbind('click').bind('click', function () {
        $(".aboveobject").val("");
        if ($(this).prop('checked') == true) {
            AddCustomPositioningToLeft();
        }
    });

    $(".leftofobject").unbind('keyup').bind('keyup', function () {
        AddCustomPositioningToLeft();
    });

    $("#rdaboveobject").unbind('click').bind('click', function () {
        $(".leftofobject").val("");
        if ($(this).prop('checked') == true) {
            AddCustomPositioningToTopIntial();
        }
    });

    $(".aboveobject").unbind('keyup').bind('keyup', function () {
        AddCustomPositioningToTop();
    });

    $("#rdrightofobject").unbind('click').bind('click', function () {
        $(".rightofobject").val("");
        if ($(this).prop('checked') == true) {
            AddCustomPositioningToTopIntial();
        }
    });

    $(".rightofobject").unbind('keyup').bind('keyup', function () {
        AddCustomPositioningToTop();
    });

    $("#drplabelFontStyle").unbind('change').bind('change', function () {
        var name = $(this).val().split('~')[1];
        if ($(this).val() != "0") {
            changeLabelFontStyle(name);
        }
        else {
            changeLabelFontStyle("");
        }
    });

    $("#drplabelColorStyle").unbind('change').bind('change', function () {
        var id = $(this).attr('id');
        changeLabelColorStyle($(this).val());
    });
    /*****************************************END************************************************/

    /*****************************************Default Content Panel************************************************/

    $("#defaultcontenttext").unbind('click').bind('click', function () {

        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });



        if (Control.DefaultContent == Control.DatabaseContent || Control.Dropdowns != "None") {
            Control.DefaultContent = Control.FieldName;
            changeDefaultContent(Control.FieldName, true, false);
        }

        Control.DatabaseContent = "";
        Control.Dropdowns = "None";
        Control.PhraseBookID = 0;
        Control.PhraseType = "";


        $("#txtDefaultContent").prop('disabled', false);
        $("#txtParaDefaultContent").prop('disabled', false);

        $("#txtDatabaseContent").val("");
        $("#txtDatabaseContent").prop('disabled', true);
        $("#drpContactFields0").prop('selected', true);
        $("#drpDepartmentFields0").prop('selected', true);
        $("#drpContactFields").prop('disabled', true);
        $("#drpDepartmentFields").prop('disabled', true);

        $("#rdContactdrp").prop('checked', false);
        $("#rdAddressdrp").prop('checked', false);
        $("#rdDepatmentdrp").prop('checked', false);
        $("#rdPhrasedrp").prop('checked', false);
        $("#drpop_0").prop('selected', true);
        $("#rdContactdrp").prop('disabled', true);
        $("#rdAddressdrp").prop('disabled', true);
        $("#rdDepatmentdrp").prop('disabled', true);
        $("#rdPhrasedrp").prop('disabled', true);
        $("#drpPhraseCustomFields").prop('disabled', true);

    });

    $("#selectcontent").unbind('click').bind('click', function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        if (Control.Dropdowns != "None") {
            Control.DefaultContent = Control.FieldName;
            changeDefaultContent(Control.FieldName, true, false);
        }

        Control.DatabaseContent = $("#txtDatabaseContent").val();
        Control.Dropdowns = "None";
        Control.PhraseBookID = 0;
        Control.PhraseType = "";

        $("#txtDefaultContent").prop('disabled', true);
        $("#txtParaDefaultContent").prop('disabled', true);

        $("#txtDatabaseContent").prop('disabled', false);
        $("#drpContactFields").prop('disabled', false);
        $("#drpDepartmentFields").prop('disabled', false);

        $("#rdContactdrp").prop('checked', false);
        $("#rdAddressdrp").prop('checked', false);
        $("#rdDepatmentdrp").prop('checked', false);
        $("#rdPhrasedrp").prop('checked', false);
        $("#drpop_0").prop('selected', true);
        $("#rdContactdrp").prop('disabled', true);
        $("#rdAddressdrp").prop('disabled', true);
        $("#rdDepatmentdrp").prop('disabled', true);
        $("#rdPhrasedrp").prop('disabled', true);
        $("#drpPhraseCustomFields").prop('disabled', true);

    });

    $("#selectDropdowns").unbind('click').bind('click', function () {
        if ($("#rdPhrasedrp").prop('checked') == true) {
            $("#drpPhraseCustomFields").prop('disabled', false);
        }
        else {
            $("#drpPhraseCustomFields").prop('disabled', true);
        }
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.DatabaseContent = "";
        Control.DeafaultContent = "";
        changeDefaultContent("", true, false);

        $("#txtDefaultContent").val("");
        $("#txtDefaultContent").prop('disabled', true);

        $("#txtDatabaseContent").val("");
        $("#txtDatabaseContent").prop('disabled', true);
        $("#drpContactFields0").prop('selected', true);
        $("#drpDepartmentFields0").prop('selected', true);
        $("#drpContactFields").prop('disabled', true);
        $("#drpDepartmentFields").prop('disabled', true);

        $("#rdContactdrp").prop('checked', false);
        $("#rdAddressdrp").prop('checked', false);
        $("#rdDepatmentdrp").prop('checked', false);
        $("#rdPhrasedrp").prop('checked', false);
        $("#drpop_0").prop('selected', true);

        $("#rdContactdrp").prop('disabled', false);
        $("#rdAddressdrp").prop('disabled', false);
        $("#rdDepatmentdrp").prop('disabled', false);
        $("#rdPhrasedrp").prop('disabled', false);
        $("#drpPhraseCustomFields").prop('disabled', true);

    });
    $("#rdPhrasedrp").click(function () {
        if ($(this).prop('checked') == true) {
            $("#CustomFields").prop('disabled', false);
            $("#drpPhraseCustomFields").prop('disabled', false);
        }
    });
    $(".Dropdowns").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            $("#CustomFields").prop('disabled', true);
            $("#drpPhraseCustomFields").prop('disabled', true);
            $("#drpop_0").prop('selected', true);
        }
    });


    $("#txtDatabaseContent").unbind('keyup').bind('keyup', function (e) {

        var linebyline = $(this).val().split('\n');

        var text = linebyline[0];
        for (var i = 1; i < linebyline.length; i++) {
            text = text + '</br>' + linebyline[i];
        }
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        $("#txtDefaultContent").val(text);

        if ($(this).val() == "") {
            $("#txtDefaultContent").val($("#txtFieldName").val());
            //$("#txtDatabaseContent").val($("#txtFieldName").val());
            text = $("#txtFieldName").val();
            Control.Dropdowns = "None";
            $("#drpContactFields").prop('disabled', false);
            $("#drpDepartmentFields").prop('disabled', false);
        }
        Control.DatabaseContent = text;
        Control.DefaultContent = text;

        changeDefaultContent(text, true, true);

    });

    /*Added By salim*/
    $("#drpContactFields").unbind('change').bind('change', function () {

        if ($(this).val() != "Contact Fields") {
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

            _drpdwn = Control.Dropdowns;

            if (_drpdwn == "None" || _drpdwn == "Contact") {

                $("#drpDepartmentFields").prop('disabled', true);

                var _deptindex = $("#drpDepartmentFields").prop("selectedIndex");
                var drpvalue = $(this).val();
                var txtvalue = $("#txtDatabaseContent").val();
                var DropDown = "Contact";
                var arry = drpvalue.split('~');

                if (txtvalue == "") {
                    $("#txtDatabaseContent").val(txtvalue + arry[0]);
                    $("#txtDefaultContent").val(txtvalue + arry[0]);
                    Control.DatabaseContent = txtvalue + arry[0];
                    Control.DefaultContent = txtvalue + arry[0];
                    changeDefaultContent(txtvalue + arry[0], true, true);
                    Control.Dropdowns = DropDown;
                }
                else {
                    $("#txtDatabaseContent").val(txtvalue + " " + arry[0]);
                    $("#txtDefaultContent").val(txtvalue + " " + arry[0]);
                    Control.DatabaseContent = txtvalue + " " + arry[0];
                    Control.DefaultContent = txtvalue + " " + arry[0];
                    changeDefaultContent(txtvalue + " " + arry[0], true, true);
                    Control.Dropdowns = DropDown;
                }

                Control.Dropdowns = DropDown;
            }
        }
    });

    /*Added By salim*/
    $("#drpDepartmentFields").unbind('change').bind('change', function () {
        if ($(this).val() != "Department Fields") {

            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
            _drpdwn = Control.Dropdowns;

            if (_drpdwn == "None" || _drpdwn == "Department") {

                $("#drpContactFields").prop('disabled', true);

                var _contseletedindex = $("#drpContactFields").prop("selectedIndex");

                var drpvalue = $(this).val();
                var txtvalue = $("#txtDatabaseContent").val();
                var DropDown = "Department";
                var arry = drpvalue.split('~');
                $("#txtDatabaseContent").val(txtvalue + arry[0] + " ");
                $("#txtDefaultContent").val(txtvalue + arry[0] + " ");

                if (txtvalue == "") {
                    $("#txtDatabaseContent").val(txtvalue + arry[0]);
                    $("#txtDefaultContent").val(txtvalue + arry[0]);
                    Control.DatabaseContent = txtvalue + arry[0];
                    Control.DefaultContent = txtvalue + arry[0];
                    changeDefaultContent(txtvalue + arry[0], true, true);
                    Control.Dropdowns = DropDown;
                }
                else {
                    $("#txtDatabaseContent").val(txtvalue + " " + arry[0]);
                    $("#txtDefaultContent").val(txtvalue + " " + arry[0]);
                    Control.DatabaseContent = txtvalue + " " + arry[0];
                    Control.DefaultContent = txtvalue + " " + arry[0];
                    changeDefaultContent(txtvalue + " " + arry[0], true, true);
                    Control.Dropdowns = DropDown;
                }
            }
        }
    });
    $("#rdContactdrp").click(function () {
        if ($(this).prop('checked') == true) {
            var value = "Contact";
            var DropDown = "Contact";

            $("#txtDefaultContent").val(value);
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
            Control.DatabaseContent = "";
            Control.Dropdowns = DropDown;
            Control.DefaultContent = value;

            changeDefaultContent(value, true, true);
            $("#drpop_0").prop('selected', true);
        }
    });

    $("#rdAddressdrp").click(function () {
        if ($(this).prop('checked') == true) {
            var value = "Address";
            var DropDown = "Address";

            $("#txtDefaultContent").val(value);
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

            Control.DatabaseContent = "";
            Control.Dropdowns = DropDown;
            Control.DefaultContent = value;

            changeDefaultContent(value, true, true);
            $("#drpop_0").prop('selected', true);
        }
    });

    $("#rdDepatmentdrp").click(function () {
        if ($(this).prop('checked') == true) {
            var value = "Department";
            var DropDown = "Department";

            $("#txtDefaultContent").val(value);
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

            Control.DatabaseContent = "";
            Control.Dropdowns = DropDown;
            Control.DefaultContent = value;

            changeDefaultContent(value, true, true);
            $("#drpop_0").prop('selected', true);
        }
    });

    $("#rdPhrasedrp").click(function () {
        if ($(this).prop('checked') == true) {
            var value = "Phrase Text";
            var DropDown = "Phrase";

            $("#txtDefaultContent").val(value);
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

            Control.DatabaseContent = "";
            Control.Dropdowns = DropDown;
            Control.DefaultContent = value;

            changeDefaultContent(value, true, true);
        }
    });

    $("#drpPhraseCustomFields").unbind('change').bind('change', function () {
        var drpvalue = $(this).val();
        var DropDown = "Phrase";
        var arry = drpvalue.split('/');
        var phraseid = arry[0];
        var type = arry[1];
        var value = $("#drpPhraseCustomFields :selected").text();

        if (phraseid == "0") {
            value = "Phrase Text";
        }
        $("#txtDefaultContent").val(value);
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.DatabaseContent = "";
        Control.Dropdowns = DropDown;
        Control.PhraseBookID = parseInt(phraseid);
        Control.PhraseType = type;
        Control.DefaultContent = value;

        changeDefaultContent(value, true, true);
    });

    /*****************************************END******************************************************************/

    $("#txttextTrscking").prop('disabled', true);
    $("#onexeedingpara").unbind('click').bind('click', function () {
        var rotateAngle = getRotationDegrees($("#onexeedingpara"));
        if (rotateAngle == 0) {
            rotateAngle = 180;
        }
        else {
            rotateAngle = 0;
        }
        $("#onexeedingpara").css({
            '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
            '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
            '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
            'transform': 'rotate(' + rotateAngle + 'deg)',
            '-webkit-transition': '-webkit-transform 1s',
            '-moz-transition': '-moz-transform 1s',
            ' -ms-transition': '-ms-transform 1s',
            'transition': 'transform 1s'
        });

        $("#onexeedingparadiv").slideToggle();
    });
    //$("#justify").rotate({
    //    bind: {
    //        click: function () {
    //            $(this).rotate({
    //                angle: 0,
    //                animateTo: 180
    //            })
    //        }
    //    }
    //});
    $("#justify").unbind('click').bind('click', function () {


        var rotateAngle = getRotationDegrees($("#justify"));
        if (rotateAngle == 0) {
            rotateAngle = 180;
            $(".toggle").show();
        }
        else {
            rotateAngle = 0;
            $(".toggle").hide();
        }
        $("#justify").css({
            '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
            '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
            '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
            '-o-transform': 'rotate(' + rotateAngle + 'deg)',
            'transform': 'rotate(' + rotateAngle + 'deg)',
            '-webkit-transition': '-webkit-transform 1s',
            '-moz-transition': '-moz-transform 1s',
            ' -ms-transition': '-ms-transform 1s',
            'transition': 'transform 1s'
        });
        $("#capitilization").css({
            '-webkit-transform': 'rotate(' + 0 + 'deg)',
            '-moz-transform': 'rotate(' + 0 + 'deg)',
            '-ms-transform': 'rotate(' + 0 + 'deg)',
            'transform': 'rotate(' + 0 + 'deg)',
            '-webkit-transition': '-webkit-transform 1s',
            '-moz-transition': '-moz-transform 1s',
            ' -ms-transition': '-ms-transform 1s',
            'transition': 'transform 1s'
        });
        $("#justifydiv").slideToggle();
        $("#capitilizationdiv").hide();
    });

    $("#capitilization").unbind('click').bind('click', function () {

        var rotateAngle = getRotationDegrees($("#capitilization"));
        if (rotateAngle == 0) {
            rotateAngle = 180;
            $(".toggle").show();
        }
        else {
            rotateAngle = 0;
            $(".toggle").hide();
        }
        $("#capitilization").css({
            '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
            '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
            '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
            'transform': 'rotate(' + rotateAngle + 'deg)',
            '-webkit-transition': '-webkit-transform 1s',
            '-moz-transition': '-moz-transform 1s',
            ' -ms-transition': '-ms-transform 1s',
            'transition': 'transform 1s'
        });
        $("#justify").css({
            '-webkit-transform': 'rotate(' + 0 + 'deg)',
            '-moz-transform': 'rotate(' + 0 + 'deg)',
            '-ms-transform': 'rotate(' + 0 + 'deg)',
            'transform': 'rotate(' + 0 + 'deg)',
            '-webkit-transition': '-webkit-transform 1s',
            '-moz-transition': '-moz-transform 1s',
            ' -ms-transition': '-ms-transform 1s',
            'transition': 'transform 1s'
        });
        $("#justifydiv").hide();
        $("#capitilizationdiv").slideToggle();
    });
    $('.selectcontent > input[type=text]').each(function () {
        $(this).prop('disabled', true);
    });
    $('.selectcontent > select').each(function () {
        $(this).prop('disabled', true);
    });
    $('.selectDropdowns > input[type=radio]').each(function () {
        if ($(this).attr('id') != 'selectDropdowns') {
            $(this).prop('disabled', true);
        }
    });
    $("#CustomFields").prop('disabled', true);
    $('.UseLabel > input').each(function () {
        $(this).prop('disabled', true);
    });
    $('.UseLabel > select').each(function () {
        $(this).prop('disabled', true);
    });
    $('.UseLabelDefault > input').each(function () {
        $(this).prop('disabled', true);
    });
    $('.UseLabelDefault > select').each(function () {
        $(this).prop('disabled', true);
    });

    $("#rdLabelnone").click(function () {
        if ($(this).prop('checked') == true) {
            $('.UseLabel > select').each(function () {
                $(this).prop('disabled', true);
            });
            $('.UseLabelDefault > input').each(function () {
                $(this).prop('disabled', true);
            });
            $('.UseLabelDefault > select').each(function () {
                $(this).prop('disabled', true);
            });
            $('.UseLabel > input').each(function () {
                $(this).prop('disabled', true);
            });
            $(".leftofobject").val("");
            $(".aboveobject").val("");
            $("#rdAttached").prop('checked', false);
            $("#rdRightAttached").prop('checked', false);
            $("#rdaboveobject").prop('checked', false);
            $("#rdleftofobject").prop('checked', false);
            $("#rdrightofobject").prop('checked', false);
        }
    });

    $("#rdleftofobject").click(function () {
        if ($(this).prop('checked') == true) {
            $(".leftofobject").prop('disabled', false);
            $(".aboveobject").prop('disabled', true);
            $(".rightofobject").prop('disabled', true);
        }
    });
    $("#rdaboveobject").click(function () {
        if ($(this).prop('checked') == true) {
            $(".aboveobject").prop('disabled', false);
            $(".leftofobject").prop('disabled', true);
            $(".rightofobject").prop('disabled', true);
        }
    });
    $("#rdrightofobject").click(function () {
        if ($(this).prop('checked') == true) {
            $(".aboveobject").prop('disabled', true);
            $(".leftofobject").prop('disabled', true);
            $(".rightofobject").prop('disabled', false);
        }
    });
    $("#rdCustomPostioning").click(function () {
        if ($(this).prop('checked') == true) {
            $(".alignObject").prop('disabled', false);
            $("#rdleftofobject").prop('checked', true);
            $(".leftofobject").prop('disabled', false);
        }
    });

    $("#rdUseLabel").click(function () {
        if ($(this).prop('checked') == true) {
            $('.UseLabelDefault > input').each(function () {
                $(this).prop('disabled', false);
            });
            $('.UseLabelDefault > select').each(function () {
                $(this).prop('disabled', false);
            });
            $("#rdAttached").prop('checked', true);
        }
    });


    /*****************************************/
    $("#btnSelectFiles").click(function () {

        // $('#multipleFileUpload').trigger('click');
        $("#multipleFileUpload")[0].click();
    });

    $("#multipleFileUpload").change(function () {
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
    $("#btnNewCategoryPopUp").unbind('click').bind('click', function () {
        
        $("#CreateCategory").dialog('open');
        

        msgBoxDesign();
        $("#txtNewCategoryName").val("");
        $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
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
                insertCategory.data = JSON.stringify({ companyid: CompanyID, categoryname: $("#txtNewCategoryName").val(), userid: UserID, description: "", parentid: $("#drpForCreateCategory").val(), categoryimage: "", _key: DBKey });
                insertCategory.dataType = "json";
                insertCategory.processData = false;
                insertCategory.contentType = "application/json; charset=utf-8";
                insertCategory.success = function (categoryID) {
                    var CategoryID = categoryID.d;

                    if (CategoryID == -1) {                        
                        $("#savemsg").html("Category name already exists.");
                        $("#SaveMessage").dialog("open");
                        msgBoxDesign();
                        return false;
                    }
                    else {
                        $(".loadingNewMask").hide();
                        loadcategoryList(CategoryID);
                        loadFolderAndFilesBycategory("", 0);
                    }
                };
                $.ajax(insertCategory);
            }
        });

        
        $("div[aria-describedby=CreateCategory]").css('z-index', '111');
        $(".loadingNewMask").show();
    });

    $("#btnUpload").unbind('click').bind('click', function () {
        if (filelist == "") {            
            $("#savemsg").html("Please select files to upload.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
            $("div[aria-describedby=SaveMessage]").css('z-index', '111');
            $(".loadingNewMask").show();
            return false;
        }
        else {
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

            $.ajax({
                url: mainSitePath + "uploadhandler.ashx/ProcessRequest?Zoom=" + zoom + "&CompanyID=" + CompanyID + "&Dbkey=" + DBKey + "&ImageUploadPath=" + ImageUploadPath + "&UploadFileNames=" + filelist + "&CategoryID=" + $("#drpSelectCategory").val() + "&TemplateID=" + TemplateID + "&UserID=" + UserID,
                cache: false,
                contentType: false,
                processData: false,
                data: form_data,
                type: 'post',
                success: function () {

                    var getImageList = {};
                    getImageList.url = ServicePath + "InsertImageGallery";
                    getImageList.type = "POST";
                    getImageList.data = JSON.stringify({ companyid: CompanyID, templateid: TemplateID, categoryid: $("#drpSelectCategory").val(), userid: UserID, usertype: "admin", fileList: filelist, description: "", metatags: "", _key: DBKey });
                    getImageList.dataType = "json";
                    getImageList.processData = false;
                    getImageList.contentType = "application/json; charset=utf-8";
                    getImageList.success = function (imageList) {

                        var loadImageList = {};
                        loadImageList.url = ServicePath + "ImageListAfterUpload";
                        loadImageList.type = "POST";
                        loadImageList.data = JSON.stringify({ ImageIDList: imageList.d, _key: DBKey });
                        loadImageList.dataType = "json";
                        loadImageList.processData = false;
                        loadImageList.contentType = "application/json; charset=utf-8";
                        loadImageList.success = function (ImageList) {

                            $('#multipleFileUpload').val("");
                            $("#fileList").empty();
                            $("#fileUploadDiv").hide();
                            $("#FilePropertiesDiv").show();
                            $("#FilePropertiesButtonDiv").show();
                            var imagelist = JSON.parse(JSON.stringify(ImageList.d));

                            var ImageDetailsHtml = "";

                            for (var i = 0; i < imagelist.length; i++) {
                                if (i % 2 == 0) {
                                    ImageDetailsHtml += "<div style='background-color:#F0F0F0;width:100%;padding:5px 0px 5px 0px;'>";
                                }
                                else {
                                    ImageDetailsHtml += "<div style='background-color:#F9F9F9;width:100%;padding:5px 0px 5px 0px;'>";
                                }
                                ImageDetailsHtml += "<table style='width:100%;'><tr><td rowspan='3' style='vertical-align:top;'><span style='font-family: Verdana;  font-size: 11px;padding:0px 0px 0px 5px;'>" + parseInt(i + 1) + ".</span></td><td style='vertical-align:top;'><span style='font-family: Verdana;  font-size: 11px;padding:0px 5px 0px 5px;'>Name</span></td>";
                                ImageDetailsHtml += "<td style='vertical-align:top;'><input type='text' style='width:200px;height:20px;font-family: Verdana; font-size: 11px;border:1px solid #b2b2b2;padding-left:2px;' id='nme_" + imagelist[i].ImageID + "' class='NameTextbox' value='" + imagelist[i].OriginalFileName + "' /></td>";
                                ImageDetailsHtml += "<td rowspan='3' style='vertical-align:top;padding-right:5px;'><table style='width:100%;'><tr><td style='width:100%;'><div style='width:100px;height:100px;float:right;'><img src='";
                                if (imagelist[i].FileName.split('.')[1].toLowerCase() == "pdf") {
                                    ImageDetailsHtml += SiteImages + "/processing.png'";
                                }
                                else {
                                    ImageDetailsHtml += BackgroundImagesPath + "Gallery/ThumbnailImages/t_" + imagelist[i].FileName + "'";
                                }
                                ImageDetailsHtml += "style='float:right;border:1px solid #808080;' /></div></td></tr>";
                                ImageDetailsHtml += "<tr><td style='width:100%;'><div style='float:right;'><input type='radio' name='defaultImage' class='defaultImage' id='def_" + imagelist[i].ImageID + "' title='" + imagelist[i].FileName + "' style='vertical-align:middle;margin-left:0px;' /><label for='def_" + imagelist[i].ImageID + "' style='font-family: Verdana; font-size: 11px;'>Default Image</span></div></td></tr></table></td></tr>";
                                ImageDetailsHtml += "<tr><td style='vertical-align:top;'><span style='font-family: Verdana;  font-size: 11px;padding:0px 5px 0px 5px;'>MetaTag</span></td>";
                                ImageDetailsHtml += "<td style='vertical-align:top;'><input type='text' style='width:200px;height:20px;font-family: Verdana; font-size: 11px;border:1px solid #b2b2b2;padding-left:2px;' id='tag_" + imagelist[i].ImageID + "' class='MetatagTextbox' value='" + imagelist[i].MetaTags + "' /></td></tr>";
                                ImageDetailsHtml += "<tr><td style='vertical-align:top;'><span style='font-family: Verdana;  font-size: 11px;padding:0px 5px 0px 5px;'>Description</span></td>";
                                ImageDetailsHtml += "<td style='vertical-align:top;'><textarea style='width:200px;height:60px;font-family: Verdana; font-size: 11px;border:1px solid #b2b2b2;padding-left:2px;' id='dsc_" + imagelist[i].ImageID + "' class='DescriptionTexarea' >" + imagelist[i].Description + "</textarea></td></tr></table></div>";
                            }

                            $("#FilePropertiesDiv").html(ImageDetailsHtml);

                            $(".loading_gallery").hide();

                            $(".defaultImage").click(function () {
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



                                            for (var k = 0; k < imagelist.length; k++) {
                                                if (imagelist[k].ImageID == parseInt(id)) {
                                                    fileName = imagelist[k].FileName;
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

                            $("#btnImageSaveChanges").unbind('click').bind('click', function () {
                                $(".loading_gallery").show();
                                var fileOriginalNames = "", ImageIDs = "", descriptions = "", metatags = "", objectid = "", DefaultImageName = "";
                                $("#FilePropertiesDiv").find(".NameTextbox").each(function () {
                                    fileOriginalNames += $(this).val() + "~";
                                    var id = $(this).attr('id').split('_');
                                    ImageIDs += id[1] + ",";
                                });
                                $("#FilePropertiesDiv").find(".MetatagTextbox").each(function () {
                                    metatags += $(this).val() + "~";
                                });
                                $("#FilePropertiesDiv").find(".DescriptionTexarea").each(function () {
                                    descriptions += $(this).val() + "~";
                                });

                                objectid = selectedObjectID;

                                var updateImageGallery = {};
                                updateImageGallery.url = ServicePath + "UpdateImageGallery";
                                updateImageGallery.type = "POST";
                                updateImageGallery.data = JSON.stringify({ ObjectID: objectid, ImageIDs: ImageIDs, Descriptions: descriptions, OriginalNames: fileOriginalNames, MetaTags: metatags, DefaultImageName: DefaultImageName, CompanyID: CompanyID, _key: DBKey, TemplateID: TemplateID, UserID: UserID });
                                updateImageGallery.dataType = "json";
                                updateImageGallery.processData = false;
                                updateImageGallery.contentType = "application/json; charset=utf-8";
                                updateImageGallery.success = function (ImageName) {

                                    filelist = "";
                                    $("#fileList").empty();
                                    $("#totalContainer").hide();
                                    $("#multipleFileUpload").val("");
                                    $("#galleryLink").trigger('click');
                                    $("#FilePropertiesDiv").hide();
                                    $("#FilePropertiesButtonDiv").hide();
                                    $("#fileUploadDiv").show();

                                    loadFolderAndFilesBycategory("", $("#drpSelectCategory").val());
                                    $(".loading_new").hide();
                                };
                                $.ajax(updateImageGallery);

                            });

                            $("#btnImageSaveCancel").click(function () {
                                filelist = "";
                                $("#fileList").empty();
                                $("#totalContainer").hide();
                                $("#multipleFileUpload").val("");
                                $("#galleryLink").trigger('click');
                                $("#FilePropertiesDiv").hide();
                                $("#FilePropertiesButtonDiv").hide();
                                $("#fileUploadDiv").show();

                                loadFolderAndFilesBycategory("", $("#drpSelectCategory").val());
                                $(".loading_new").hide();
                            });
                        };
                        $.ajax(loadImageList);
                    };
                    $.ajax(getImageList);
                }
            });
        }

    });
    //we set the status saying the site is currently uploading the file. Note: you can remove the image ajax animated loading if you do not have it and just leave the text information base only. Make sure you set the URL for the generic handler path correctly.


});

$(function () {
    $("#accordion").accordion({ collapsible: true, heightStyle: "content" });

    //$("#sortable").sortable();
    $("#sortable").sortable({
        containment: "parent",
        start: function () {
        },
        stop: function (event, ui) {
            var j = 0;
            $("#sortable").find("li").each(function () {
                j++;
                var arry = $(this).attr('id').split('_');
                var Control;
                ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

                Control.OrderNumber = j;
            });
        }
    });


    $("#ManageGroupNogroup").dialog({
        efect: 'clip',
        autoOpen: false,
        resizable: false,
        height: 145,
        width: 700,
        modal: true
    });

    $("#ManageGroupExistingGroup").dialog({
        effect: "clip",
        autoOpen: false,
        resizable: false,
        height: 550,
        width: 1125,
        modal: true
    });

    $("#ManageGroupAddGroup").dialog({
        effect: "clip",
        autoOpen: false,
        height: 580,
        resizable: false,
        width: 930,
        modal: true
    });

    $("#Imageeditor").dialog({
        effect: "clip",
        autoOpen: false,
        height: 575,
        width: 870,
        resizable: false,
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

    $("#SaveMessage").dialog({
        effect: "clip",
        autoOpen: false,
        resizable: false,       
        modal: true,
        width: 'auto',
        height: 'auto',
        at: 'center',
        my:'center',
        buttons: {
            OK: function () {
                if (saveAndExit == true) {

                    window.close();
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
        effect: "clip",
        autoOpen: false,
        resizable: false,
        width: 475, height: 160,
        modal: true,
        buttons: {
            OK: function () {
                if (saveAndExit == true) {

                    window.close();
                }
                $(this).dialog("close");
                $(".loadingNewMask").hide();
            }
        },
        close: function () {
            $(".loadingNewMask").hide();
        }
    });

    $("#ImageFromGallery").dialog({
        effect: "clip",
        autoOpen: false,
        width: 690,
        resizable: false,
        height: 505,
        modal: true,
        close: function () {
            $('#multipleFileUpload').val("");
            $("#fileList").empty();
            filelist = "";
            $("#FilePropertiesDiv").hide();
            $("#FilePropertiesButtonDiv").hide();
            $("#fileUploadDiv").show();
            $("#totalContainer").hide();
            $("#galleryLink").trigger("click");
            $("#btnUnSelectAll").hide();
        }
    });
    $("#CreateCategory").dialog({
        effect: "clip",
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
        effect: "clip",
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
        effect: "clip",
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
        effect: "clip",
        autoOpen: false,
        height: 400,
        resizable: false,
        width: 650,
        modal: true,
        close: function () {
            $(".loadingNewMask").hide();
        }
    });

    $("#QuickAdjustDialog").dialog({
        autoOpen: false,
        height: 560,
        resizable: false,
        width: 1250,
        modal: true,
        buttons: {
            "Save & Stay": function () {
                SaveQuickAdjustDetails();
            },
            "Save & Close": function () {
                SaveQuickAdjustDetails();
                $(this).dialog("close");
            }
        }

    });

    $("#btnManageGroup").click(function () {

        if (VerticalGroupingData.length > 0 || HorizontalGroupingData.length > 0) {
            loadManageExistingGroup();
        }
        else {
            loadNoGroup();
        }
        $(".btnAddGroup").click(function () {
            
            var openAddGroup = false;
            for (var i = 0; i < ControllDetails.length; i++) {
                if (ControllDetails[i].Type != "Image" && ControllDetails[i].Lock == true && ControllDetails[i].GroupID == 0 && ControllDetails[i].PageNumber == parseInt($("#drpManageGroupPage").val()) && ControllDetails[i].Visibility == true) {
                    openAddGroup = true;
                    break;
                }
            }

            if (openAddGroup) {
                if ($(this).attr('id') == "addGropFromExistingGroup") {
                    $("#ManageGroupExistingGroup").dialog("close");
                }
                else {
                    $("#ManageGroupNogroup").dialog("close");
                }
                loadEditGroup("AddGroup");
            }
            else {                
                $("#savemsg").html("No fields are availble to create group, please add controls");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
                $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                $(".loadingNewMask").show();
                return false;
            }
        });


    });

    $("#btnQuickAdjust").click(function () {

        loadQuickAdjust();
    });
    designPoups();

});

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
    $(".ui-colorpicker-cmyk").append("<div class='ui-colorpicker-cmyk-t'><span style='font-weight: bold;padding-left:5px;padding-top:5px;'>Tint</span><input class='ui-colorpicker-number' type='text' onkeyup='return validateQty(event);' oninput='vaild(event);' id='txtT' style='width: 50px; height: 20px;margin-left:5px;'><span class='ui-colorpicker-unit'>%</span></div>")
    $(".colorcode table").css({ 'margin-bottom': '0px', 'padding-bottom': '0px', 'padding-top': '0px' });
    $(".colorcode div").css({ 'margin-bottom': '0px', 'padding-bottom': '0px', 'padding-top': '0px' });
    $("#txtC").attr('type', 'text');
    $("#txtM").attr('type', 'text');
    $("#txtY").attr('type', 'text');
    $("#txtK").attr('type', 'text');
    $("#txtT").attr('type', 'text');
    $(".colorcode input[type=text]").css('text-align', 'left');
    $(".colorcode input[type=text]").attr('onkeypress', 'return validateQty(event)');
    $(".colorcode input[type=text]").attr('oninput', 'vaild(event)');
    $(".color").css({ 'margin-bottom': '0px', 'padding-bottom': '0px', 'padding-top': '0px' });
});

function AddImage() {

    var numItems = $('.controll').length;
    var GUID = Guid();
    numItems = 1 + numItems;
    var jsonStringFotText;
    var _defaultpos = 35;
    var PostionY = (parseFloat($("#textCanvas").innerHeight()) / mmConvertionConstant) - _defaultpos;
    var PostionX = (parseFloat($("#textCanvas").innerWidth()) / mmConvertionConstant) / 2;

    var page = parseInt($("#drpPageSelect").val());
    jsonStringFotText = JSON.parse(JSON.stringify({
        "__type": "EditorTemplate.TemplateFieldProperties",
        "IsJustify": false,
        "OrignalImageName": "noimage.jpg",
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
        "UserFontSyleName": "",
        "ColorID": 0,
        "UserColorStyleName": "",
        "ManualTrackSign": "+",
        "ManualTrackDimension": "pt",
        "ImageLocation": "TL",
        "KeepOption": "None",
        "GroupOrientation": "None",
        "ImageSource": "h",
        "ImageGallery": "",
        "R": 0,
        "OrderNumber": numItems,
        "G": 0,
        "B": 0,
        "A": 0,
        "ExceedHeight": "",
        "MaxHeight": ImageHeight,
        "BackgroundImage": "",
        "BackgroundColor": "",
        "ExceedImage": "P",
        "CustomRight": 0,
        "ObjectID": GUID,
        "FieldName": "ImageField" + numItems,
        "FriendlyName": "ImageField" + numItems,
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
        "Lock": true,
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
        "CoordsX": PostionX,
        "CoordsY": PostionY,
        "ObjTag": "",
        "GroupID": 0,
        "ImgUrl": "noimage.jpg",
        "Align": "Left",
        "Top": PostionY,
        "Left": PostionX,
        "Width": ImageHeight,
        "Height": ImageHeight,
        "FontFamily": "",
        "FontWeight": "",
        "OffsetWidth": "",
        "OffsetHeight": "",
        "OffsetTop": "",
        "OffsetLeft": "",
        "PixelWidth": "",
        "PixelHeight": "18.6751700000",
        "Type": "Image",
        "CanMove": true,
        "CanChangeFontColor": false,
        "CanChangeFontSize": false,
        "CanChangeFont": false,
        "ObjType": "",
        "Tag": "",
        "Label": "",
        "ActualField": "",
        "ContentType": "",
        "ZIndexValue": numItems,
        "IsCropFromTop": false,
        "IsFromBackEnd": false,
        "EditedImageName": "",
        "LabelValue": "",
        "FontStyleName": ""
    }))
    deSelect();
    ControllDetails.push(jsonStringFotText);
    AddImageDynamically(jsonStringFotText, true);
    if ($(".contentLayout").css('display') == 'block') {
        $(".LayoutPanel").trigger('click');
        $(".LayoutPanel").hide();
    }
    if ($(".contentFontPanel").css('display') == 'block') {
        $(".FontPanel").trigger('click');
        $(".FontPanel").hide();
    }
    if ($(".contentColorPanel").css('display') == 'block') {
        $(".ColorPanel").trigger('click');
        $(".ColorPanel").hide();
    }
    if ($(".contentDefaultContentPanel").css('display') == 'block') {
        $(".DefaultContentPanel").trigger('click');
        $(".DefaultContentPanel").hide();
    }
    if ($(".contentLabelPanel").css('display') == 'block') {
        $(".LabelPanel").trigger('click');
        $(".LabelPanel").hide();
    }

    showImageAccordion();
    $(".TextBlock").hide();
    $(".ParaGraph").hide();
    $(".ImagePanel").show();
}

function FitTheEditedImageToControl(fileName) {
    var zoom = parseFloat($("#" + "txtZoom").val());
    var width;
    var height;
    var objectid = selectedObjectID;
    var exxceeimage = "";

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    width = parseInt(Control.Width * mmConvertionConstant);
    height = parseInt(Control.Height * mmConvertionConstant);
    exxceeimage = Control.ExceedImage;

    if (exxceeimage == "P") {
        var tmpImg = new Image();
        tmpImg.src = BackgroundImagesPath + fileName;
        $(tmpImg).on('load', function () {
            var FitImageToContoll = {};
            FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
            FitImageToContoll.type = "POST";
            FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: objectid, isEdited: "true", ImageUploadPath: ImageUploadPath, CompanyID: CompanyID });
            FitImageToContoll.dataType = "json";
            FitImageToContoll.processData = false;
            FitImageToContoll.contentType = "application/json; charset=utf-8";
            FitImageToContoll.success = function (ImageName) {

                var arry = ImageName.d.split('~');
                var exceedimage = "";
                var Control;
                ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

                Control.ImgUrl = arry[0];
                Control.IsFromBackEnd = true;
                Control.EditedImageName = arry[0];
                Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);

                $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
                $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);

                $(".loading_new").hide();
                alignsingleImage(Control.ObjectID);

            };
            $.ajax(FitImageToContoll);
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
                    Control.IsFromBackEnd = true;
                    Control.EditedImageName = ImageName;
                    $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + ImageName);
                    $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                    $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                    Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.Align);
                    $(".loading_new").hide();
                    alignsingleImage(Control.ObjectID);
                }
                else if (exxceeimage == "D") {
                    var Control;
                    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

                    Control.ImgUrl = ImageName;
                    Control.IsFromBackEnd = true;
                    Control.EditedImageName = ImageName;

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
                        $(".loading_new").hide();
                        alignsingleImage(Control.ObjectID);
                    });
                }
            }
        });
    }

}





