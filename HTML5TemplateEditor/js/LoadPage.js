var textCanvasHeight;
var textCanvasWidth;
var curentPageNumber;
var Textheight = 4, ImageHeight = 26.45833, ParaHeight = 13.23;
var Labelstyle, SitePhysicalPath, SitePath, FontPath, BackgroundImagesPath, WebMethodsPath, ImageUploadPath, DBKey, mainSitePath, SaveAndClose, saveAndExit;
var TemplateID, CompanyID, UserID, PriceCatalogId, ServicePath, ProductName, CategoryBindingList, FontList, imagecount = 0, imageloadedcount = 0;

$(document).ready(function () {
    $("#loading").css('height', $("body").css('height'));
    $("#loading").show();
    var comppanyid = "";
    //var templateid = getUrlEncodedKey("templateid", false);
    //var comppanyid = getUrlEncodedKey("companyid", false);
    //var userid = getUrlEncodedKey("userid", false);
    //var pricecatelogueid = getUrlEncodedKey("pricecatalogid", false);
    //var dbkey = getUrlEncodedKey("dbkey", false);
    //var dataOnload = JSON.stringify({ TemplateID: templateid, CompanyID: comppanyid, UserID: userid, PriceCatalogId: pricecatelogueid, _key: dbkey });

    var path = $(location).attr('href').split('?');

    var querystring = path[1];
    var dataOnload = JSON.stringify({ Querystring: querystring });

    if (comppanyid != "" || querystring != "") {
        $.ajax({
            url: path[0] + "/LoadSitePath",
            type: "POST",
            data: dataOnload,
            dataType: "json",
            contentType: "application/json",
            success: function (SitePaths) {
                FontPath = SitePaths.d.FontPath;
                BackgroundImagesPath = SitePaths.d.BackgroundImagesPath;
                WebMethodsPath = SitePaths.d.WebMethodsPath + "editableproduct.aspx/";
                mainSitePath = SitePaths.d.WebMethodsPath;
                SiteImages = SitePaths.d.SiteImages;
                DBKey = SitePaths.d.DBkey;
                ImageUploadPath = SitePaths.d.ImageUploadPath;
                TemplateID = SitePaths.d.TemplateID;
                CompanyID = SitePaths.d.CompanyID;
                UserID = SitePaths.d.UserID;
                PriceCatalogId = SitePaths.d.PriceCatalogId;
                ServicePath = SitePaths.d.ServicePath;
                if (DBKey != "") {
                    $.ajax({
                        url: ServicePath + "GetProductName",
                        type: "POST",
                        data: JSON.stringify({ priceCatalogueID: PriceCatalogId, _key: DBKey }),
                        dataType: "json",
                        processData: false,
                        contentType: "application/json; charset=utf-8",
                        success: function (Productname) {
                            ProductName = Productname.d;
                            loadHorizontalGroupingData();
                            loadVerticalGroupingData();
                            loadPage();
                        }
                    });
                }
            }
        });
    }
});

function loadPage() {
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
    $("#accordion h3.TextBlock span").css('display', 'none');
    $("#accordion h3.ImagePanel span").css('display', 'none');
    $("#accordion h3.ParaGraph span").css('display', 'none');
    $("#accordion h3.TextBlock").off("click");
    $("#accordion h3.ImagePanel").off("click");
    $("#accordion h3.ParaGraph").off("click");
    $("#accordion h3.TextBlock").off();
    $("#accordion h3.ImagePanel").off("hover");
    $("#accordion h3.ParaGraph").off("hover");


    $.ajax({
        url: ServicePath + "LoadTemplate",
        type: "POST",
        data: JSON.stringify({ templateid: TemplateID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (templateDetails, data) {

            TemplateDetails = JSON.parse(JSON.stringify(templateDetails.d));
            CompanyID = CompanyID;
            var zoomTemp = TemplateDetails.ZoomPercent / 100;
            textCanvasHeight = TemplateDetails.PageHeight;
            textCanvasWidth = TemplateDetails.PageWidth;
            $("#txtTemplateName").val(TemplateDetails.TemplateName);
            $("#txtDescription").val(TemplateDetails.TemplateDescription);
            $("#lblProductName").html(ProductName);
            $("#textCanvas").css('width', textCanvasWidth + "px");
            $("#textCanvas").css('height', textCanvasHeight + "px");
            var imagepath = BackgroundImagesPath + TemplateDetails.ImageName;
            ImagePath = imagepath;
            $("#textCanvas").css('background-image', "url('" + imagepath + "')");
            var mainCanWidth = textCanvasWidth * zoomTemp;
            var maincanheight = textCanvasHeight * zoomTemp;
            $("#Maincanvas").css('width', mainCanWidth + 'px');
            $("#Maincanvas").css('height', maincanheight + 'px');

            $("#chkAllowTextBlock").prop('checked', TemplateDetails.AddNewTextBlock);
            $("#chkAllowParagraph").prop('checked', TemplateDetails.AddNewParagraph);
            $("#chkAllowImage").prop('checked', TemplateDetails.AddNewImage);
            $("#chkShowEditor").prop('checked', TemplateDetails.ShowEdiotr);
            $("#chkShoweditablePages").prop('checked', TemplateDetails.ShowEditablePages);
            $("#chkSendAttachments").prop('checked', TemplateDetails.SendAttachment);

            //$("#Menubar select").css({ 'background': '#FFFFFF url(' + SiteImages + 'arrow-down.png) no-repeat 100% center', '-webkit-appearance': 'none', '-moz-appearance': ' none' });
            loadFontStyeDropDowns();
            var ZoomIn = zoomTemp;
            zoomTextCanvas(ZoomIn);
            LoadDropDowns();
        }
    });
}

function loadFontStyeDropDowns() {

    $.ajax({
        url: ServicePath + "LoadFontStyle",
        type: "POST",
        data: JSON.stringify({ companyid: CompanyID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (FontStyle) {
            if (FontStyle.d.length > 0) {
                
                $.ajax({
                    url: ServicePath + "GetFontStyle",
                    type: "POST",
                    data: JSON.stringify({ FontStyle: FontStyle.d[0].UserFontSyleName, companyid: CompanyID, _key: DBKey }),
                    dataType: "json",
                    processData: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (Font) {
                        
                        FontStyleDetails = JSON.parse(JSON.stringify(Font.d));
                        for (var i = 0; i < FontStyle.d.length; i++) {
                            loadFontStyleDropdown(FontStyleDetails[i].FontStyleName, FontStyleDetails[i].FontID);
                        }
                    }
                });
            }
        }
    });

    $.ajax({
        url: ServicePath + "GetColorStyleDetailProperties",
        type: "POST",
        data: JSON.stringify({ companyid: CompanyID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (ColorStyle) {
            ColorStyleDetails = JSON.parse(JSON.stringify(ColorStyle.d));

            for (var i = 0; i < ColorStyle.d.length; i++) {
                loadColorStyleDropdown(ColorStyleDetails[i].ColorStyleName, ColorStyleDetails[i].ColorID);
            }

            loadControlls();
        }
    });
}

function loadControlls() {

    $.ajax({
        url: ServicePath + "LoadTemplateControlls",
        type: "POST",
        data: JSON.stringify({ templateid: TemplateID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (controllDetails, data) {

            ControllDetails = JSON.parse(JSON.stringify(controllDetails.d));

            //if (parseFloat($("#textCanvas").innerHeight()) > 0) {
                bindPageDropdown();

                for (var i = 0; i < ControllDetails.length; i++) {

                    if (parseInt(ControllDetails[i].PageNumber) == 1) {
                        curentPageNumber = 1;
                        var controll = ControllDetails[i].Type;

                        if (controll == "TextBlock") {
                            AddTextDynamically(ControllDetails[i]);
                        }
                        else if (controll == "Image") {
                            AddImageDynamically(ControllDetails[i]);
                        }
                        else if (controll == "Paragraph") {
                            AddParaDynamically(ControllDetails[i]);
                        }
                    }
                    loadFuctionForReview();
                }
                setTimeout(function () {
                    $("#loading").hide();
                    $(".loading_new").css('height', $("body").css('height'));
                });
            //}
            //else {
            //    loadPage();
            //}
        }
    });
}

function LoadDropDowns() {

    $.ajax({
        url: ServicePath + "LoadFonts",
        type: "POST",
        data: JSON.stringify({ companyid: CompanyID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (Font) {

            FontList = JSON.parse(JSON.stringify(Font.d));
            for (var i = 0; i < Font.d.length; i++) {
                loadFontDropdown(Font.d[i].DisplayFontName, Font.d[i].FontFilePath, Font.d[i].FontID, Font.d[i].ActualFontName, "#drpApplyFont", 'none');
            }
            //for (var i = 0; i < ControllDetails.length; i++) {
            //    if (ControllDetails[i].Type == "Image" && ControllDetails[i].ExceedWidth == "P") {
            //        var width = parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerWidth());
            //        var height = parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerHeight());
            //        var proptionality = width / height;
            //        while (parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerHeight()) >= parseFloat(ControllDetails[i].MaxHeight) * mmConvertionConstant && parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerWidth()) >= parseFloat(ControllDetails[i].MaxWidth) * mmConvertionConstant) {
            //            if (parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerHeight()) >= parseFloat(ControllDetails[i].MaxHeight) * mmConvertionConstant) {
            //                $("#" + ControllDetails[i].ObjectID + " img").css({ 'height': parseFloat(ControllDetails[i].MaxHeight) * mmConvertionConstant + 'px' });
            //            }
            //            if (parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerWidth()) >= parseFloat(ControllDetails[i].MaxWidth) * mmConvertionConstant) {
            //                $("#" + ControllDetails[i].ObjectID + " img").css({ 'width': parseFloat(ControllDetails[i].MaxWidth) * mmConvertionConstant + 'px' });
            //            }
            //        }
            //    }
            //}

        }
    });

    $.ajax({
        url: ServicePath + "LoadDataBaseContents",
        type: "POST",
        data: JSON.stringify({ _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (DatabaseContent) {

            for (var i = 0; i < DatabaseContent.d.length; i++) {
                loadDatabaseContentFieldsDropDown(DatabaseContent.d[i].Label, DatabaseContent.d[i].ContentType, DatabaseContent.d[i].Tag);
            }
        }
    });

    var loadPhraseDropdown = {};
    loadPhraseDropdown.url = ServicePath + "LoadPhraseTitles";
    loadPhraseDropdown.type = "POST";
    loadPhraseDropdown.data = JSON.stringify({ companyid: CompanyID, _key: DBKey });
    loadPhraseDropdown.dataType = "json";
    loadPhraseDropdown.processData = false;
    loadPhraseDropdown.contentType = "application/json; charset=utf-8";
    loadPhraseDropdown.success = function (PhraseDefaultContent) {

        for (var i = 0; i < PhraseDefaultContent.d.length; i++) {
            loadPhraseDefaultCotentDropDown(PhraseDefaultContent.d[i].Title, PhraseDefaultContent.d[i].PhraseID);
        }
    };

    $.ajax(loadPhraseDropdown);

    $.ajax({
        url: ServicePath + "SelectAllTemplateForCopyDropDown",
        type: "POST",
        data: JSON.stringify({ companyid: CompanyID, templateid: TemplateID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (templateIDandNameList) {
            TemplateIDandNameList = JSON.parse(JSON.stringify(templateIDandNameList.d));
            for (var i = 0; i < TemplateIDandNameList.length; i++) {
                var arry = TemplateIDandNameList[i].split('~');
                loadTempleteForCopyDropDown(arry[0], arry[1]);
            }

            loadcategoryList("");
            //loadimage();

        }
    });
}

function loadcategoryList(CategoryID) {
    $.ajax({
        url: ServicePath + "GetImageCategoryByCompany",
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

function loadFontDropdown(fontName, fontFilePath, FontID, ActualFontName, id, selcted) {
    if (selcted == "none") {
        $(id).append("<option value='" + fontFilePath + "~" + FontID + "~" + ActualFontName + "~" + fontName + "' id='drpFontID" + FontID + "' >" + fontName + "</option>");
    }
}

function loadFontStyleDropdown(fontStyleName, fontStyleID) {
    $("#drpFontStyle").append("<option value='" + fontStyleID + '~' + fontStyleName + "' id='drpFontStyleID" + fontStyleName.replace(/ /g, "") + "' >" + fontStyleName + "</option>");
    $("#drplabelFontStyle").append("<option value='" + fontStyleID + '~' + fontStyleName + "' id='drpLabelFontStyleID" + fontStyleName.replace(/ /g, "") + "' >" + fontStyleName + "</option>");
}

function loadColorStyleDropdown(colorStyleName, colorStyleID) {
    $("#drpColorStyle").append("<option value='" + colorStyleName + "' id='drpColorStyleID" + colorStyleName.replace(/ /g, "") + "'>" + colorStyleName + "</option>");
    $("#drplabelColorStyle").append("<option value='" + colorStyleName + "' id='drpLabelColorStyleID" + colorStyleName.replace(/ /g, "") + "'>" + colorStyleName + "</option>");

}

function loadTempleteForCopyDropDown(TemplateID, TemplateName) {

    $("#dtlstcopy").append("<option id='" + TemplateID + "'>" + TemplateName + "</option>");
    // $("#drpTemplteForCopy").append("<option value='" + TemplateID + "' >" + TemplateName + "</option>");    
}

function loadDatabaseContentFieldsDropDown(Label, Type, Tag) {
    if (Type == "Contact") {
        $("#drpContactFields").append("<option value='" + Tag + "~" + Type + "' >" + Label + "</option>");
    }
    else if (Type == "Department") {
        $("#drpDepartmentFields").append("<option value='" + Tag + "~" + Type + "' >" + Label + "</option>");
    }
}

function loadPhraseDefaultCotentDropDown(Title, PhraseID) {

    $("#drpPhraseCustomFields").append("<option value='" + PhraseID + "' id='drpop_" + PhraseID.split('/')[0] + "' >" + Title + "</option>");
}

function bindPageDropdown() {
    pageNumber = parseInt(TemplateDetails.Totalpage);
    $("#lbltotalpage").html("/" + pageNumber);
    if (pageNumber > 1) {
        for (var i = 2; i <= pageNumber; i++) {
            $("#drpPageSelect").append("<option value='" + i + "'>" + i + "</option>");
        }
    }
}

function AddTextDynamically(controllDetails, AddNew) {
    var uniquefontname = "";
    $("#sortable").append("<li class='ui-state-default reiewFields' title='Drag object for rearrange' id='R_" + controllDetails.ObjectID + "'>" + controllDetails.FieldName + "</li>");
    loadFuctionForReview();
    var defaultContent;
    if (controllDetails.DefaultContent != "") {
        defaultContent = capitalizeTheText(controllDetails.DefaultContent, controllDetails.Capitalize);
    }
    else {
        defaultContent = capitalizeTheText(controllDetails.FieldName, controllDetails.Capitalize);
    }

    var TextHtml = "<div class='Text controll'";
    TextHtml += "id='" + controllDetails.ObjectID + "'";
    TextHtml += "name='" + controllDetails.FieldName + "'";
    TextHtml += "title='" + controllDetails.HelpText + "'";
    TextHtml += "style='position:absolute;background-color:transparent;cursor:pointer;white-space:nowrap;";
    TextHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    TextHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
    TextHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    TextHtml += "line-height:1;";
    TextHtml += "border:1px dashed transparent;"
    TextHtml += "vertical-align:bottom;";
    TextHtml += "'>";

    if (controllDetails.Labels == "Use Labels") {

        TextHtml += "<div class='labelText' style='white-space:pre;position:absolute;bottom:0px;padding:0px;margin:0px;vertical-align:baseline;line-height:.7;";
        TextHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
        if (controllDetails.ManualTrackDimension == "pt") {
            TextHtml += parseFloat(controllDetails.ManualTracking * ptConvertionConstant).toFixed(4) + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            TextHtml += parseFloat(controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
        }
        TextHtml += "color:rgba(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ", " + controllDetails.A + ");";
        //TextHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
        TextHtml += "font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;";
        TextHtml += "padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;";
        uniquefontname = getuniquefontname();

        var Font = null;
        FontList.map(function (proj) { if (proj.DisplayFontName == controllDetails.FontFamily) Font = proj });
        if (Font != null) {
            $("head").append("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + FontPath + Font.FontFilePath + "'); }</style>");

            TextHtml += "font-family:" + uniquefontname + ";";
        }
        else {
            TextHtml += "font-family: arial;";
        }
        TextHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        TextHtml += "font-weight:" + controllDetails.FontWeight + ";";
        TextHtml += "font-style:" + controllDetails.FontStyle + ";'>";

        TextHtml += "<span style='font-size:" + controllDetails.LabelFontSize / ptConvertionConstant + "px;text-align:left;display:inline-block;position:relative;vertical-align:baseline;bottom:0px;line-height:.7;";


        if (controllDetails.LabelPosition == "customLeft") {
            //TextHtml += "<div style='margin:0px;font-size:" + controllDetails.LabelFontSize / ptConvertionConstant + "px;";
            TextHtml += "width:" + (controllDetails.CustomLeft * mmConvertionConstant) + "px;";
        }



        var defaContent = capitalizeTheText(controllDetails.LabelValue, "User Input");

        if (controllDetails.LabelColor != "") {
            var ColorStyleDetail = null;
            ColorStyleDetails.map(function (proj) { if (proj.ColorStyleName == controllDetails.LabelColor) ColorStyleDetail = proj });
            if (ColorStyleDetail != null) {
                TextHtml += "color:rgb(" + ColorStyleDetail.R + ", " + ColorStyleDetail.G + ", " + ColorStyleDetail.B + ");";
            }
        }
        else {
            TextHtml += "color:black;";
        }
        if (controllDetails.LabelFontStyle != "") {

            var FontStyleDetail = null;
            FontStyleDetails.map(function (proj) { if (proj.FontStyleName == controllDetails.LabelFontStyle) FontStyleDetail = proj });
            if (FontStyleDetail != null) {
                var val;
                if (FontStyleDetail.TrackPoint == "pt") {
                    val = FontStyleDetail.ManualTracking * ptConvertionConstant;
                }
                else if (FontStyleDetail.TrackPoint == "mm") {
                    val = FontStyleDetail.ManualTracking * mmConvertionConstant;
                }
                var uniquefontname = getuniquefontname();
                var Font = null;
                FontList.map(function (proj) { if (proj.DisplayFontName == FontStyleDetail.FontFamily) Font = proj });
                if (Font != null) {
                    $("head").append("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + FontPath + Font.FontFilePath + "'); }</style>");
                    TextHtml += "font-family:" + uniquefontname + ";";
                }
                else {
                    TextHtml += "font-family:arial;";
                }

                TextHtml += "letter-spacing:" + FontStyleDetail.TrackOffSet + val + "px;";
                TextHtml += "font-size:" + FontStyleDetail.FontSize / ptConvertionConstant + "px;";
                defaContent = capitalizeTheText(controllDetails.LabelValue, FontStyleDetail.Capitalize);
            }
        }
        else {
            TextHtml += "font-family:arial;font-weight:normal;font-style:normal;";
        }
        TextHtml += "' class='label'>" + defaContent + "</span>" + defaultContent + "</div>";

    }
    else if (controllDetails.Labels == "None" || controllDetails.Labels == "") {
        TextHtml += "<div class='labelText' style='bottom:0px;position:absolute;padding:0px;margin:0px;vertical-align:baseline;line-height:.7;";
        TextHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
        if (controllDetails.ManualTrackDimension == "pt") {
            TextHtml += parseFloat(controllDetails.ManualTracking * ptConvertionConstant).toFixed(4) + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            TextHtml += parseFloat(controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
        }
        TextHtml += "color:rgba(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ", " + controllDetails.A + ");";
        //TextHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
        TextHtml += "font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;";
        TextHtml += "padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;";
        uniquefontname = getuniquefontname();

        var Font = null;
        FontList.map(function (proj) { if (proj.DisplayFontName == controllDetails.FontFamily) Font = proj });
        if (Font != null) {
            $("head").append("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + FontPath + Font.FontFilePath + "'); }</style>");
            TextHtml += "font-family:" + uniquefontname + ";";
        }
        else {
            TextHtml += "font-family:arial;";
        }
        TextHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        TextHtml += "font-weight:" + controllDetails.FontWeight + ";";
        TextHtml += "font-style:" + controllDetails.FontStyle + ";";
        TextHtml += "'>" + defaultContent + "</div></div>";
    }

    $("#textCanvas").append(TextHtml);



    //if (controllDetails.LabelPosition == "Attached" && controllDetails.Labels == "Use Labels") {
    //    //var widthOflabel = parseFloat($("#" + controllDetails.ObjectID + " .label").outerWidth());
    //    //$("#" + controllDetails.ObjectID + " .label").css({ 'width': widthOflabel + 'px' });
    //    //$("#" + controllDetails.ObjectID + " .labelText").css({ 'margin-left': widthOflabel + 'px','position':'relative' });

    //}

    alignsingleLineText(controllDetails.ObjectID);
    if (controllDetails.LabelPosition == "customTop" && controllDetails.Labels == "Use Labels") {

        $("#" + controllDetails.ObjectID + " .label").css({ 'vertical-align': 'top', 'margin-bottom': parseFloat(controllDetails.CustomTop * mmConvertionConstant) + 'px' });

        if (controllDetails.TextAlign != "Center") {
            $("#" + controllDetails.ObjectID + " .label").css({ 'float': controllDetails.TextAlign, 'margin-left': '0px' });
            $("#" + controllDetails.ObjectID + " .labelText").css({ 'float': controllDetails.TextAlign });
        }
        else {

            var mar = (controllDetails.Width * mmConvertionConstant / 2) - ((parseFloat($("#" + controllDetails.ObjectID + " .label").innerWidth())) / 2);
            $(selectedControllID + " .label").css({ 'float': 'left', 'margin-left': mar + 'px' });
            $(selectedControllID + " .labelText").css({ 'float': 'left', 'text-align': 'center' });
        }
        $("#" + controllDetails.ObjectID + " .labelText").css({ 'margin-left': '0px', 'vertical-align': 'baseline' });
        var divHeight = parseFloat($("#" + controllDetails.ObjectID + " .labelText").css('line-height')) + parseFloat(controllDetails.CustomTop * mmConvertionConstant) + parseFloat($("#" + controllDetails.ObjectID + " .label").css('line-height'));
        $("#" + controllDetails.ObjectID).css({ 'height': divHeight + "px", 'line-height': divHeight + "px" });
    }
    $("#" + controllDetails.ObjectID).css({
        'transformOrigin': 'left bottom',
        '-webkit-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-moz-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-ms-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        'transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)'
    });
    fixPostionOfControll(controllDetails.ObjectID, controllDetails.PositionX, controllDetails.PositionY, controllDetails.TextAlign);

    applyonexceedwidth(controllDetails.ObjectID);
    functionalities();
    if (AddNew) {
        $("#" + controllDetails.ObjectID).css('border', '1px dashed #808080');
        $("#" + controllDetails.ObjectID).css('cursor', 'pointer');
        changeSelectedControllID();

        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.MaxHeight = (parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant);
        Control.Height = (parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant);

        bindLeftPannel(Control.ObjectID);

    }
    //applyContolHeightAccordingToFont(controllDetails);


    if ($("#" + controllDetails.ObjectID + " .label").outerHeight() > $("#" + controllDetails.ObjectID + " .labelText").outerHeight()) {
        $("#" + controllDetails.ObjectID).css({ 'height': $("#" + controllDetails.ObjectID + " .label").outerHeight() + "px" });
    }
    else {
        $("#" + controllDetails.ObjectID).css({ 'height': $("#" + controllDetails.ObjectID + " .labelText").outerHeight() + "px" });
    }
    controllDetails.MaxHeight = $("#" + controllDetails.ObjectID).outerHeight() / mmConvertionConstant;
    controllDetails.Height = $("#" + controllDetails.ObjectID).outerHeight() / mmConvertionConstant;

}

function AddParaDynamically(controllDetails, AddNew) {

    var _giud = Guid();
    $("#sortable").append("<li class='ui-state-default reiewFields' title='Drag object for rearrange' id='R_" + controllDetails.ObjectID + "'>" + controllDetails.FieldName + "</li>");
    loadFuctionForReview();

    var defaultContent = "";

    if (controllDetails.DefaultContent != "") {
        defaultContent = capitalizeTheText(controllDetails.DefaultContent, controllDetails.Capitalize);
    }
    else {
        defaultContent = capitalizeTheText(controllDetails.FieldName, controllDetails.Capitalize);
    }

    defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>");

    var ParaHtml = "<div class='Para controll'";
    ParaHtml += "id='" + controllDetails.ObjectID + "'";
    ParaHtml += "name='" + controllDetails.FieldName + "'";
    ParaHtml += "title='" + controllDetails.HelpText + "'";
    ParaHtml += "style='position:absolute;background-color:transparent;cursor:pointer;";
    ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    ParaHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
    ParaHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
    if (controllDetails.ManualTrackDimension == "pt") {
        ParaHtml += parseFloat(controllDetails.ManualTracking * ptConvertionConstant).toFixed(4) + "px;";
    }
    else if (controllDetails.ManualTrackDimension == "mm") {
        ParaHtml += parseFloat(controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
    }
    ParaHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    ParaHtml += "color:rgba(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ", " + controllDetails.A + ");";
    ParaHtml += "font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;";
    ParaHtml += "padding:0px;margin:0px;vertical-align:top;";
    var uniquefontname = getuniquefontname();

    var Font = null;
    FontList.map(function (proj) { if (proj.DisplayFontName == controllDetails.FontFamily) Font = proj });
    if (Font != null) {
        $("head").append("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + FontPath + Font.FontFilePath + "'); }</style>");
        ParaHtml += "font-family:" + uniquefontname + ";";
    }
    else {
        ParaHtml += "font-family: arial;";
    }
    ParaHtml += "border:1px dashed transparent;"
    ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    //ParaHtml += "font-family:" + controllDetails.FontFamily + ";";

    if (controllDetails.DefaultContent == "") {
        ParaHtml += "'><p style='margin:0px;word-wrap:break-word;vertical-align:top;text-align:" + controllDetails.TextAlign + ";line-height:100%;padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;";
        ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        ParaHtml += "font-weight:" + controllDetails.FontWeight + ";";
        ParaHtml += "font-style:" + controllDetails.FontStyle + ";>";
        ParaHtml += "' class='paraText'>" + defaultContent + "</p></div>";
    }
    else {
        ParaHtml += "'><p style='margin:0px;word-wrap:break-word;vertical-align:top;text-align:" + controllDetails.TextAlign + ";line-height:100%;padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;";
        ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        ParaHtml += "font-weight:" + controllDetails.FontWeight + ";";
        ParaHtml += "font-style:" + controllDetails.FontStyle + ";>";
        ParaHtml += "' class='paraText'>" + defaultContent + "</p></div>";
    }

    $("#textCanvas").append(ParaHtml);
    $("#" + controllDetails.ObjectID).css({
        'transformOrigin': 'left bottom',
        '-webkit-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-moz-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-ms-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        'transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)'
    });
    if (controllDetails.ParaLineSpace > 0) {

        var presentlineheight = $("#" + controllDetails.ObjectID + " p").css('line-height');
        var lineleight = (parseFloat(presentlineheight) * ptConvertionConstant) + controllDetails.ParaLineSpace;
        $("#" + controllDetails.ObjectID + " p").css('line-height', lineleight + "pt");
    }
    fixPostionOfControll(controllDetails.ObjectID, controllDetails.PositionX, controllDetails.PositionY, controllDetails.TextAlign);
    functionalities();
    if (AddNew) {
        $("#" + controllDetails.ObjectID).css('border', '1px dashed #808080');
        $("#" + controllDetails.ObjectID).css('cursor', 'pointer');
        changeSelectedControllID();

        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.MaxHeight = parseFloat($("#" + Control.ObjectID).innerHeight() / mmConvertionConstant);
        Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight() / mmConvertionConstant);

        bindLeftPannel(Control.ObjectID);
    }
}

function AddImageDynamically(controllDetails, AddNew) {
    var imagepath = "";
    $("#sortable").append("<li class='ui-state-default reiewFields' title='Drag object for rearrange' id='R_" + controllDetails.ObjectID + "'>" + controllDetails.FieldName + "</li>");
    loadFuctionForReview();
    var ImageHtml = "<div class='Image controll'";
    ImageHtml += "id='" + controllDetails.ObjectID + "'";
    ImageHtml += "name='" + controllDetails.FieldName + "'";
    if (controllDetails.HelpText != "") {
        ImageHtml += "title='" + controllDetails.HelpText + "'";
    }
    else {
        ImageHtml += "title='Double click to edit'";
    }
    ImageHtml += "style='position:absolute;background-color:transparent;cursor:pointer;";
    ImageHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    ImageHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
    ImageHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    if (controllDetails.BackgroundImage == "") {
        ImageHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    }
    else {
        ImageHtml += "z-index:-1;";
    }
    ImageHtml += "border:1px dashed transparent;' >";


    if (controllDetails.BackgroundImage != "") {
        if (controllDetails.BackgroundImage == "noimage.png" || controllDetails.BackgroundImage == "noimage.jpg") {
            ImageHtml += "<img  src='" + SiteImages + "noimage.jpg";
            imagepath = SiteImages + "noimage.jpg";
        }
        else {
            ImageHtml += "<img  src='" + BackgroundImagesPath + "Gallery/OriginalImages/" + controllDetails.BackgroundImage;
            imagepath = BackgroundImagesPath + "Gallery/OriginalImages/" + controllDetails.BackgroundImage;
        }
    }
    else {
        if (controllDetails.ImgUrl == "noimage.png" || controllDetails.ImgUrl == "noimage.jpg") {
            ImageHtml += "<img  src='" + SiteImages + "noimage.jpg";
            imagepath = SiteImages + "noimage.jpg";
        }
        else {
            ImageHtml += "<img  src='" + BackgroundImagesPath + controllDetails.ImgUrl;
            imagepath = BackgroundImagesPath + controllDetails.ImgUrl;
        }
    }


    if (controllDetails.ExceedImage == "P") {
        if (controllDetails.BackgroundImage != "") {
            ImageHtml += "' style='height:100%;width:100%;position:absolute;";
        }
        else {
            if (AddNew) {
                ImageHtml += "' style='height:" + controllDetails.Height * mmConvertionConstant + "px;" + ";width:" + controllDetails.Width * mmConvertionConstant + "px;position:absolute;";
            }
            else {
                if (controllDetails.Height < controllDetails.Width) {
                    ImageHtml += "' style='height:" + controllDetails.MaxHeight * mmConvertionConstant + "px;" + "width:auto;position:absolute;";
                }
                else {
                    ImageHtml += "' style='width:" + controllDetails.MaxWidth * mmConvertionConstant + "px;" + "height:auto;position:absolute;";
                }
            }
        }
    }
    else {
        ImageHtml += "' style='height:100%;width:100%;position:absolute;";
    }


    ImageHtml += "' /></div>";

    $("#textCanvas").append(ImageHtml);

    $("#" + controllDetails.ObjectID).css({
        'transformOrigin': 'left bottom',
        '-webkit-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-moz-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-ms-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        'transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)'
    });
    fixPostionOfControll(controllDetails.ObjectID, controllDetails.PositionX, controllDetails.PositionY, controllDetails.TextAlign);
    functionalities();

    if (AddNew) {
        $("#" + controllDetails.ObjectID).css('border', '1px solid #B2B2B2');
        $("#" + controllDetails.ObjectID).css('cursor', 'pointer');
        changeSelectedControllID();

        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.MaxHeight = parseFloat($("#" + Control.ObjectID).innerHeight() / mmConvertionConstant);
        Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight() / mmConvertionConstant);

        bindLeftPannel(Control.ObjectID);
    }

    if ($("#" + controllDetails.ObjectID).outerHeight() < ($("#" + controllDetails.ObjectID + " img").outerHeight())) {
        $("#" + controllDetails.ObjectID + " img").css({ 'height': parseFloat(controllDetails.MaxHeight) * mmConvertionConstant + 'px' });
        controllDetails.MaxHeight = parseFloat($("#" + controllDetails.ObjectID + " img").outerHeight() / mmConvertionConstant);
    }
    if ($("#" + controllDetails.ObjectID).outerWidth() < ($("#" + controllDetails.ObjectID + " img").outerWidth())) {
        $("#" + controllDetails.ObjectID + " img").css({ 'width': parseFloat(controllDetails.MaxWidth) * mmConvertionConstant + 'px' });
        controllDetails.MaxWidth = parseFloat($("#" + controllDetails.ObjectID + " img").outerWidth() / mmConvertionConstant);
    }
    imagecount = imagecount + 1;
    $("#canvasLoading").show();
    var tmpImg = new Image();
    tmpImg.src = imagepath;
    $(tmpImg).on('load', function () {
        imageloadedcount = imageloadedcount + 1;
        if (imagecount == imageloadedcount) {
            $("#canvasLoading").hide();
            imageloadedcount = 0;
            imagecount = 0;
        }
        alignsingleImage(controllDetails.ObjectID);
    });
}

function bindLeftPannel(ObjectID) {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == ObjectID) Control = proj });

    if (Control.ObjectID == ObjectID) {
        $("#txtFieldName").val(Control.FieldName);
        $("#txtFriendly").val(Control.FriendlyName);
        $("#txtHelpText").val(Control.HelpText);
        if (Control.Mandatory) {
            $("#chkMandatory").prop('checked', true);
        }
        else {
            $("#chkMandatory").prop('checked', false);
        }
        if (Control.Edit) {
            $("#chkNonEditable").prop('checked', false);
        }
        else {
            $("#chkNonEditable").prop('checked', true);
        }
        if (Control.HideVisibility) {
            $("#chkHideFromuser").prop('checked', true);
        }
        else {
            $("#chkHideFromuser").prop('checked', false);
        }

        $("#txtRotate").val(Control.RotateAngle);


        if (Control.Type == "TextBlock" || Control.Type == "Paragraph") {

            $(".txtRotateX").val(Control.RotateAngle);

            $("#txtPostionX").val(parseFloat(Control.PositionX).toFixed(4));
            $("#txtPostionY").val(parseFloat(Control.PositionY).toFixed(4));
            if (Control.Lock) {
                $("#chkLockPosition").prop('checked', true);
            }
            else {
                $("#chkLockPosition").prop('checked', false);
            }

            $("#txtMaxWidth").val(parseFloat(Control.Width).toFixed(4));

            if (Control.FontStyleName != "") {
                for (var j = 0; j < FontStyleDetails.length; j++) {
                    if (FontStyleDetails[j].FontStyleName == Control.FontStyleName) {
                        $("#drpFontStyleID" + FontStyleDetails[j].FontStyleName.replace(/ /g, "")).prop('selected', true);
                        $("#txtFontStyle").val(FontStyleDetails[j].FontStyleName);
                    }
                }
            }
            else {
                $("#drpFontStyleID" + 0).prop('selected', true);
                $("#txtFontStyle").val("");
            }

            $("#txtFontSize").val(parseFloat(Control.FontSize).toFixed(4));
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


            if (Control.ColorStyle != "") {
                for (var j = 0; j < ColorStyleDetails.length; j++) {
                    if (ColorStyleDetails[j].ColorStyleName == Control.ColorStyle) {
                        $("#drpColorStyleID" + ColorStyleDetails[j].ColorStyleName.replace(/ /g, "")).prop('selected', true);
                        $("#txtColorStyle").val(Control.ColorStyle);
                        $("#colorStleRextangle").css({ 'background-color': $("#" + Control.ObjectID + " .labelText").css('color'), 'border-color': '#b2b2b2' });
                    }
                }
            }
            else {
                $("#drpColorStyleID" + 0).prop('selected', true);
                $("#txtColorStyle").val("");
                $("#colorStleRextangle").css({ 'background-color': 'white', 'border-color': 'white' });
            }



            if (Control.SpotColor) {
                $("#chkSpotColor").prop('checked', true);
            }
            else {
                $("#chkSpotColor").prop('checked', false);
                $("txtSpotColor").prop('disabled', true);
            }

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
                $("#rdLeftJustify").prop('checked', true);
                $("#btnLeftAlign").addClass('menubuttonSelected');
                $("#btnCenterAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
            }
            else if (Control.TextAlign == 'Center') {
                $("#rdCenterJustify").prop('checked', true);
                $("#btnCenterAlign").addClass('menubuttonSelected');
                $("#btnLeftAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
            }
            else if (Control.TextAlign == 'Right') {
                $("#rdRightJustify").prop('checked', true);
                $("#btnRightAlign").addClass('menubuttonSelected');
                $("#btnLeftAlign").removeClass('menubuttonSelected');
                $("#btnCenterAlign").removeClass('menubuttonSelected');
            }

            if (Control.Capitalize == "User Input") {
                $("#rdUserInput").prop('checked', true);
            }
            else if (Control.Capitalize == "All Caps") {
                $("#rdAllUpper").prop('checked', true);
            }
            else if (Control.Capitalize == "InitCap") {
                $("#rdFirstLetterCaps").prop('checked', true);
            }
            else if (Control.Capitalize == "First Cap") {
                $("#rdAllWordFirstCaps").prop('checked', true);
            }
            else {
                $("#rdAllLower").prop('checked', true);
            }

            $("txtSpotColor").val(Control.SpotColorRef);
            $(".ui-colorpicker-preview-current").css('background-color', "rgba(" + Control.R + ", " + Control.G + ", " + Control.B + ", " + Control.A + ")");
            $("#txtC").val(parseFloat(Control.C * 100).toFixed(2));
            $("#txtM").val(parseFloat(Control.M * 100).toFixed(2));
            $("#txtY").val(parseFloat(Control.Y * 100).toFixed(2));
            $("#txtK").val(parseFloat(Control.K * 100).toFixed(2));
            $("#txtT").val(parseFloat(Control.Tint).toFixed(2));
            $("#txtC").trigger('change');
            $("#txtM").trigger('change');
            $("#txtY").trigger('change');
            $("#txtK").trigger('change');


            if (Control.DatabaseContent != "") {

                $("#selectcontent").prop('checked', true);

                $("#txtDefaultContent").val(Control.DatabaseContent);
                $("#txtDefaultContent").prop('disabled', true);

                $("#txtDatabaseContent").val(Control.DatabaseContent);
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

                $("#drpContactFields").prop('disabled', false);
                $("#drpDepartmentFields").prop('disabled', false);

                if (Control.Dropdowns == "Contact") {
                    $("#drpContactFields").prop('disabled', false);
                    $("#drpDepartmentFields").prop('disabled', true);
                }
                else if (Control.Dropdowns == "Department") {
                    $("#drpContactFields").prop('disabled', true);
                    $("#drpDepartmentFields").prop('disabled', false);
                }
                else if (Control.Dropdowns == "None") {
                    $("#drpContactFields").prop('disabled', false);
                    $("#drpDepartmentFields").prop('disabled', false);
                }
            }
            else if (Control.Dropdowns != "None") {
                $("#selectDropdowns").prop('checked', true);

                $("#txtDefaultContent").val(Control.DefaultContent);
                $("#txtDefaultContent").prop('disabled', true);

                $("#txtDatabaseContent").val("");
                $("#txtDatabaseContent").prop('disabled', true);
                $("#drpContactFields0").prop('selected', true);
                $("#drpDepartmentFields0").prop('selected', true);
                $("#drpContactFields").prop('disabled', true);
                $("#drpDepartmentFields").prop('disabled', true);

                if (Control.Dropdowns == "Contact") {
                    $("#rdContactdrp").prop('checked', true);
                    $("#drpPhraseCustomFields").prop('disabled', true);
                    $("#drpop_0").prop('selected', true);
                }
                else if (Control.Dropdowns == "Address") {
                    $("#rdAddressdrp").prop('checked', true);
                    $("#drpPhraseCustomFields").prop('disabled', true);
                    $("#drpop_0").prop('selected', true);
                }
                else if (Control.Dropdowns == "Department") {
                    $("#rdDepatmentdrp").prop('checked', true);
                    $("#drpPhraseCustomFields").prop('disabled', true);
                    $("#drpop_0").prop('selected', true);
                }
                else if (Control.Dropdowns == "Phrase") {
                    $("#rdPhrasedrp").prop('checked', true);
                    $("#drpPhraseCustomFields").prop('disabled', false);

                    $("#drpop_" + Control.PhraseBookID).prop('selected', true);
                }
                else {
                    $("#drpPhraseCustomFields").prop('disabled', true);
                    $("#drpop_0").prop('selected', true);
                }
            }
            else {
                $("#defaultcontenttext").prop('checked', true);

                $("#txtDefaultContent").val(Control.DefaultContent);
                $("#txtDefaultContent").prop('disabled', false);

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
            }




            for (var l = 0; l < FontList.length; l++) {
                if (FontList[l].DisplayFontName == Control.FontFamily) {
                    $("#drpFontID" + FontList[l].FontID).prop('selected', true);
                    break;
                }
            }

            $("#txtColorStyle").val(Control.ColorStyle);
            if (Control.SpotColor) {
                $("#chkSpotColor").prop('checked', true);
                $("#txtSpotColor").prop('disabled', false);
                $("#txtSpotColor").val(Control.SpotColorRef);
            }
            else {
                $("#chkSpotColor").prop('checked', false);
                $("#txtSpotColor").prop('disabled', true);
                $("#txtSpotColor").val("");
            }

            if (Control.Type == "TextBlock") {
                $(".TextBlock").show();
                $(".ParaGraph").hide();
                $(".ImagePanel").hide();
                var value = false;

                $("#txtDefaultContent").val(Control.DefaultContent);

                $("#txtParaDefaultContent").hide();
                $("#txtDefaultContent").show();
                if ($(".contentProperties").css('display') == 'block') {
                    $(".PropertiesPanel").trigger('click');
                    $(".PropertiesPanel").hide();
                    value = true;
                }
                showTextAccordion();

                $(".paraLayoutExtra").hide();
                $(".textLayoutExtra").show();

                if (value) {
                    $(".InformationPanel").trigger('click');
                }

                $("#chkParagraphJustify").prop('disabled', true);

                $(".paraLayoutExtra").hide();
                if (Control.ExceedWidth == "Do Nothing") {
                    $("#rdtextDonothing").prop('checked', true);
                    $("#txttextTrscking").val(0);
                }
                else if (Control.ExceedWidth == "Expand side") {
                    $("#rdtextSideWays").prop('checked', true);
                    $("#txttextTrscking").val(0);
                }
                else if (Control.ExceedWidth == "Shrink") {
                    $("#rdtextShrink").prop('checked', true);
                    $("#txttextTrscking").val(0);
                }
                else {
                    $("#rdtextTrscking").prop('checked', true);
                    $("#txttextTrscking").prop('disabled', false);
                    $("#txttextTrscking").val(0);

                    $("#txttextTrscking").val(Control.MaxShrink * 100);
                }
                $("#chkParagraphJustify").prop('disabled', true);

                if (Control.Labels == "None") {
                    $("#rdLabelnone").prop('checked', true);
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
                    $(".rightofobject").val("");
                    $(".rightofobject").prop('disabled', true);
                }
                else if (Control.Labels == "Use Labels") {
                    $("#rdUseLabel").prop('checked', true);

                    $("#txtLabel").prop('disabled', false);
                    $("#txtLabel").val(Control.LabelValue);

                    $("#drplabelFontStyle").prop('disabled', false);
                    $("#drplabelColorStyle").prop('disabled', false);

                    $("#drpLabelFontStyleID" + Control.LabelFontStyle.replace(/ /g, "")).prop('selected', true);

                    if (Control.LabelColor != "") {
                        for (var j = 0; j < ColorStyleDetails.length; j++) {
                            if (ColorStyleDetails[j].ColorStyleName == Control.LabelColor) {
                                $("#drpLabelColorStyleID" + ColorStyleDetails[j].ColorStyleName.replace(/ /g, "")).prop('selected', true);
                            }
                        }
                    }
                    else {
                        $("#drpLabelColorStyleID" + 0).prop('selected', true);
                    }

                    $("#rdAttached").prop('disabled', false);
                    $("#rdRightAttached").prop('disabled', false);
                    $("#rdCustomPostioning").prop('disabled', false);

                    if (Control.LabelPosition == "Attached") {
                        $("#rdAttached").prop('checked', true);
                        $("#rdleftofobject").prop('diasbled', true);
                        $("#rdaboveobject").prop('diasbled', true);
                        $("#rdrightofobject").prop('diasbled', true);
                        $(".leftofobject").prop('disabled', true);
                        $(".aboveobject").prop('disabled', true);
                        $(".rightofobject").prop('disabled', true);
                        $(".leftofobject").val("");
                        $(".aboveobject").val("");
                        $(".rightofobject").val("");
                        $("#rdaboveobject").prop('checked', false);
                        $("#rdleftofobject").prop('checked', false);
                        $("#rdrighttofobject").prop('checked', false);
                    }
                    else if (Control.LabelPosition == "RightAttached") {
                        $("#rdRightAttached").prop('checked', true);
                        $("#rdleftofobject").prop('diasbled', true);
                        $("#rdaboveobject").prop('diasbled', true);
                        $("#rdrightofobject").prop('diasbled', true);
                        $(".leftofobject").prop('disabled', true);
                        $(".aboveobject").prop('disabled', true);
                        $(".rightofobject").prop('disabled', true);
                        $(".leftofobject").val("");
                        $(".aboveobject").val("");
                        $(".rightofobject").val("");
                        $("#rdaboveobject").prop('checked', false);
                        $("#rdleftofobject").prop('checked', false);
                        $("#rdrighttofobject").prop('checked', false);
                    }
                    else if (Control.LabelPosition == "customLeft") {
                        $("#rdCustomPostioning").prop('checked', true);
                        $("#rdleftofobject").prop('checked', true);
                        $("#rdleftofobject").prop('checked', true);
                        $(".leftofobject").prop('disabled', false);
                        $("#rdleftofobject").prop('disabled', false);
                        $("#rdaboveobject").prop('disabled', false);
                        $(".aboveobject").prop('disabled', true);
                        $(".leftofobject").val(Control.CustomLeft);
                    }
                    else if (Control.LabelPosition == "customTop") {
                        $("#rdCustomPostioning").prop('checked', true);
                        $("#rdaboveobject").prop('checked', true);
                        $(".aboveobject").prop('disabled', false);
                        $("#rdaboveobject").prop('disabled', false);
                        $("#rdleftofobject").prop('disabled', false);
                        $(".leftofobject").prop('disabled', true);
                        $(".aboveobject").val(Control.CustomTop);
                    }

                }
            }


            if (Control.Type == "Paragraph") {
                $(".TextBlock").hide();
                $(".ParaGraph").show();
                $(".ImagePanel").hide();
                var value = false;
                if ($(".contentProperties").css('display') == 'block') {
                    $(".PropertiesPanel").trigger('click');
                    $(".PropertiesPanel").hide();
                    value = true;
                }
                if ($(".contentLabelPanel").css('display') == 'block') {
                    $(".LabelPanel").trigger('click');
                    $(".LabelPanel").hide();
                    value = true;
                }
                showParaAccordion();

                if (value) {
                    $(".InformationPanel").trigger('click');
                }
                if (Control.ExceedHeight == "Do Nothing") {
                    $("#rdparaDonothing").prop('checked', true);
                }
                else {
                    $("#rdparaSideWays").prop('checked', true);
                }

                $("#chkParagraphJustify").prop('disabled', false);

                $("#txtParaDefaultContent").val(Control.DefaultContent);
                $("#txtParaDefaultContent").show();
                $("#txtDefaultContent").hide();
                $(".paraLayoutExtra").show();
                $(".textLayoutExtra").hide();


                if (Control.TextAlign == "Justify") {
                    $("#chkParagraphJustify").prop('checked', true);
                }
                else {
                    $("#chkParagraphJustify").prop('checked', false);
                }

                if (Control.ExceedHeight == "Do Nothing") {
                    $("#rdparaDonothing").prop('checked', true);
                }
                else {
                    $("#rdparaSideWays").prop('checked', true);
                }
                $("#txtMaxHeight").val(parseFloat(Control.Height).toFixed(4));
                $("#txtLineSpacing").val(parseFloat(Control.ParaLineSpace).toFixed(4));
            }

        }

    }
    if (Control.Type == "Image") {

        $(".TextBlock").hide();
        $(".ParaGraph").hide();
        $(".ImagePanel").show();
        var value = false;
        if ($(".contentLayout").css('display') == 'block') {
            $(".LayoutPanel").trigger('click');
            $(".LayoutPanel").hide();
            value = true;
        }
        if ($(".contentFontPanel").css('display') == 'block') {
            $(".FontPanel").trigger('click');
            $(".FontPanel").hide();
            value = true;
        }
        if ($(".contentColorPanel").css('display') == 'block') {
            $(".ColorPanel").trigger('click');
            $(".ColorPanel").hide();
            value = true;
        }
        if ($(".contentDefaultContentPanel").css('display') == 'block') {
            $(".DefaultContentPanel").trigger('click');
            $(".DefaultContentPanel").hide();
            value = true;
        }
        if ($(".contentLabelPanel").css('display') == 'block') {
            $(".LabelPanel").trigger('click');
            $(".LabelPanel").hide();
            value = true;
        }

        showImageAccordion();

        $("#" + Control.ImageLocation).prop('selected', true);

        if (value) {
            $(".InformationPanel").trigger('click');
        }
        $("#txtImagePostionX").val(parseFloat(Control.PositionX).toFixed(4));
        $("#txtImagePostionY").val(parseFloat(Control.PositionY).toFixed(4));

        if (Control.Lock) {
            $("#chkImageLockPosition").prop('checked', true);
        }
        else {
            $("#chkImageLockPosition").prop('checked', false);
        }
        if (Control.ImageLocation == "SELECT") {
            $("#" + "TL").prop('selected', true);
        }
        else {
            $("#" + Control.ImageLocation).prop('selected', true);
        }
        $("#txtMaxImageHeight").val(parseFloat(Control.Height).toFixed(4));
        $("#txtMaxImageWidth").val(parseFloat(Control.Width).toFixed(4));
        if (Control.ExceedImage == "P") {
            $("#rdoImagePropotional").prop('checked', true);

            $("#txtParaDefaultContent").val(Control.DefaultContent);
            $("#txtParaDefaultContent").show();
            $("#txtDefaultContent").hide();


            if (Control.IsCropFromTop == true) {
                $("#ChkCropfromtop").prop('checked', true);
                $("#ChkCropfromtop").prop('disabled', false);

            }
            else {
                $("#ChkCropfromtop").prop('checked', false);
                $("#ChkCropfromtop").prop('disabled', false);
            }
        }
        else if (Control.ExceedImage == "S") {
            $("#rdoImageScaleToFit").prop('checked', true);
            $("#ChkCropfromtop").prop('disabled', true);
        }
        else if (Control.ExceedImage == "D") {
            $("#rdoImageDoNothing").prop('checked', true);
            $("#ChkCropfromtop").prop('disabled', true);
        }

        if (Control.ImageSource == "h") {
            $("#chkImagefromHardDrive").prop('checked', true);
        }
        else {
            $("#chkImagefromHardDrive").prop('checked', false);
        }
        if (Control.ImageGallery == "g") {
            $("#chkImageFromGallery").prop('checked', true);
        }
        else {
            $("#chkImageFromGallery").prop('checked', false);
        }

        if (Control.BackgroundImage != "") {
            $("#chkBackground").prop('checked', true);
        }
        else {
            $("#chkBackground").prop('checked', false);
        }

        if (Control.IsImageQuality) {
            $("#DPI_Panel").show();
            $("#txtDPI").val(Control.MinDPI);
        }
        else {
            $("#DPI_Panel").hide();
            $("#txtDPI").val(Control.MinDPI);
        }
    }


    var x = true;
    $("#accordion > .content").each(function () {
        if ($(this).css('display') == 'block') {
            x = false;
        }
    });
    if (x) {
        if ($(".contentInformationPanel").css('display') != 'block') {
            $(".InformationPanel").trigger('click');
        }
    }
}

function AddPara() {
    clearAccordin();
    var numItems = $('.controll').length;
    var GUID = Guid();
    numItems = 1 + numItems;
    var jsonStringFotText;
    var _defaultparapos = 35;
    var PostionY = (parseFloat($("#textCanvas").innerHeight()) / mmConvertionConstant) - _defaultparapos;
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
        "ExceedHeight": "Do Nothing",
        "MaxHeight": 13.23,
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
        "Height": 13.23,
        "FontFamily": "Arial",
        "FontWeight": "Normal",
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
    AddParaDynamically(jsonStringFotText, true);
    if ($(".contentProperties").css('display') == 'block') {
        $(".PropertiesPanel").trigger('click');
        $(".PropertiesPanel").hide();
    }
}

function functionalities() {
    $(function () {
        $(".Image,.Para,.Text").draggable({

            drag: function (evt, ui) {
                ui.position.top = ui.position.top / zoom;
                ui.position.left = ui.position.left / zoom;
                getPosition();
                //$("#" + selectedObjectID).css({ 'height': controlheight + "px" });
            },
            stop: function (evt, ui) {
                getPosition();
            },
            containment: "#LayoutCanvas",
            scroll: true,
            cursor: "move",
            scrollSensitivity: 100
        });
        $(".Text").resizable({
            handles: 'e, w',
            resize: function (evt, ui) {
                var changeWidth = ui.size.width - ui.originalSize.width;
                var changeHeight = ui.size.height - ui.originalSize.height;

                var newWidth = ui.originalSize.width + changeWidth / zoom;
                var newHeight = ui.originalSize.height + changeHeight / zoom;

                ui.originalElement.width(newWidth);
                ui.originalElement.height(newHeight);

                resizeTextPara();
            },
            stop: function (evt, ui) {
                alignsingleLineText($(this).attr('id'));
            }
        });
        $(".Image,.Para").resizable({
            handles: 'e,w,n,s',
            resize: function (evt, ui) {
                var changeWidth = ui.size.width - ui.originalSize.width;
                var changeHeight = ui.size.height - ui.originalSize.height;

                var newWidth = ui.originalSize.width + changeWidth / zoom;
                var newHeight = ui.originalSize.height + changeHeight / zoom;

                ui.originalElement.width(newWidth);
                ui.originalElement.height(newHeight);
                if ($(this).hasClass('Para')) {
                    resizeTextPara();
                }
                else if ($(this).hasClass('Image')) {
                    resizeImage();
                }
                alignsingleImage($(this).attr('id'));
            }
        });
    });
    $(function () {
        $(".Text").mousedown(function () {
            deSelect();
            $(this).css('border', '1px dashed #808080');
            $(this).css('cursor', 'pointer');
            changeSelectedControllID();
            bindLeftPannel(selectedObjectID);
        });
        $(".Para").mousedown(function () {
            deSelect();
            $(this).css({ 'border': '1px dashed #808080' });
            //$(this).css({ 'border': '1px solid #b2b2b2', '-moz-border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', '-webkit-border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', '-o-border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', 'border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', 'border-image-slice': '10 11 11 9 ', 'border-image-repeat': 'repeat', 'border-width': '5px', 'border-image-outset': '0px 0px 0px 0px' });
            //$(this).css({ 'border': '1px solid #b2b2b2', '-webkit-border-image': 'url(/StyleSheets/Images/bodera.png) 30 30 stretch', '-o-border-image': ' url(/StyleSheets/Images/bodera.png) 30 30 stretch', 'border-image': 'url(/StyleSheets/Images/bodera.png) 30 30 stretch' });
            $(this).css('cursor', 'pointer');
            changeSelectedControllID();
            bindLeftPannel(selectedObjectID);
        });
        $(".Image").mousedown(function () {

            deSelect();
            $(this).css({ 'border': '1px solid #b2b2b2' });
            //$(this).css({ 'border': '1px solid #b2b2b2', '-moz-border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', '-webkit-border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', '-o-border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', 'border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', 'border-image-slice': '16 17 17 15 ', 'border-image-repeat': 'repeat', 'border-width': '5px', 'border-image-outset': '0px 0px 0px 0px' });
            //$(this).css({ 'border': '1px solid #b2b2b2',  '-webkit-border-image': 'url(/StyleSheets/Images/bodera.png) 30 30 stretch', '-o-border-image': ' url(/StyleSheets/Images/bodera.png) 30 30 stretch', 'border-image': 'url(/StyleSheets/Images/bodera.png) 30 30 stretch' });

            $(this).css('cursor', 'pointer');
            changeSelectedControllID();
            bindLeftPannel(selectedObjectID);
        });
        $(".Image").unbind('dblclick').bind('dblclick', function () {
           

            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

            var image = Control.OrignalImageName;
            var imagepath = BackgroundImagesPath + image;
            if (image == "noimage.png" || image == "noimage.jpg") {
                imagepath = SiteImages + "noimage.jpg";
            }

            $("div[aria-describedby=Imageeditor] .ui-dialog-buttonpane").css('margin-right', '30px');
            $("div[aria-describedby=Imageeditor] .ui-dialog-buttonpane .ui-button").css('margin', '5px');
            $("div[aria-describedby=Imageeditor] .ui-dialog-buttonpane .ui-button span").css({ 'font-size': '11px' });
            $("#RadImageEditor1_canvas").css('float', 'left');
            $("#RadImageEditor1").css({ 'width': '768px', 'position': 'absolute', 'left': '0px', 'margin-right': '50px', 'margin-left': '50px' });
            $("#Imageeditor").css('overflow', 'visible');
            var tmpImg = new Image();
            tmpImg.src = imagepath;
            $(tmpImg).on('load', function () {
                var orgWidth = tmpImg.width;
                var orgHeight = tmpImg.height;
                $("#RadImageEditor1_canvas").attr('height', orgHeight);
                $("#RadImageEditor1_canvas").attr('width', orgWidth);
                $("#Imageeditor").dialog("open");
                var x = GetEditor();

                GetEditor().insertImage(0, 0, imagepath, "");

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



            //GetEditor().set_serverImageUrl(BackgroundImagesPath + image);
            //GetEditor().set_clientImageUrl(BackgroundImagesPath + image);
            //GetEditor().flipVertical();
            //GetEditor().applyChangesOnServer();
        });
        //$(".controll").unbind('click').bind('click',function () {             
        //    deSelect();
        //    $(this).css('border', '1px dashed black');
        //    $(this).css('cursor', 'pointer');
        //    changeSelectedControllID();            
        //    bindLeftPannel(selectedObjectID);
        //});
        $(".Para,.Text").unbind('mouseenter').bind('mouseenter', function () {
            if ($(this).css('border-left-color') == "transparent") {
                $(this).css('border', '1px dashed rgb(128, 128, 129)');
            }
            if ($(this).css('borderColor') == "rgba(0, 0, 0, 0)") {
                $(this).css('border', '1px dashed rgb(128, 128, 129)');
            }
        });
        $(".Image").unbind('mouseenter').bind('mouseenter', function () {
            if ($(this).css('border-left-color') == "transparent") {
                $(this).css('border', '1px solid rgb(178, 178, 179)');
            }
            if ($(this).css('borderColor') == "rgba(0, 0, 0, 0)") {
                $(this).css('border', '1px solid rgb(178, 178, 179)');
            }
        });
        $(".Para,.Text").unbind('mouseleave').bind('mouseleave', function () {
            if ($(this).css('border-left-color') == "rgb(128, 128, 129)") {
                $(this).css('border', '1px dashed transparent');
            }
            if ($(this).css('borderColor') == "rgb(128, 128, 129)") {
                $(this).css('border', '1px dashed rgba(0, 0, 0, 0)');
            }
        });
        $(".Image").unbind('mouseleave').bind('mouseleave', function () {
            if ($(this).css('border-left-color') == "rgb(178, 178, 179)") {
                $(this).css('border', '1px solid transparent');
            }
            if ($(this).css('borderColor') == "rgba(0, 0, 0, 0)") {
                $(this).css('border', '1px solid rgba(0, 0, 0, 0)');
            }
        });
    });
}
