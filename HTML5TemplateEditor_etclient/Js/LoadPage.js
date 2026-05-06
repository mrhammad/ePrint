var textCanvasHeight;
var textCanvasWidth;
var SitePhysicalPath, SitePath, FontPath, BackgroundImagesPath, WebMethodsPath, mainSitePath, DBKey, ImageUploadPath, FrontEndImagePath, B2BSitePath, PublicSitePath, CType, AccountID;
var mmConvertionConstant = 3.779527559;
var ptConvertionConstant = 0.75;
var selectedControllID, selectedObjectID;
var TemplateDetails, ControllDetails;
var CropMarkHeight = 0, CropMarkWidth = 0;
var ImagePath, FocusID = "";
var DropDownContactList, DropDownDepartmentList, DropDownAddressList, DropDownPhraseList;
var TemplateID, SesionID, UserID, CartitemID, CompanyID, ServicePath, ProductName, PriceCatalogId;
var VerticalGroupingData = null, HorizontalGroupingData = null;
var Textheight = 4, ImageHeight = 26.45833, ParaHeight = 19, filelist = "", totalSize = 0, FrontEndDocumentPath, FrontEndUploadPath, PDFAPIPath,imagecount = 0, imageloadedcount = 0;
var ListForMoveUp = [], ListForMoveDown = [], ListForKeepLeft = [], ListForKeepRight = [], OriginalGroupPositionByGroupID = [];

/*Completed*/
$(function () {
    var companyid = "";

    var path = $(location).attr('href').split('?');

    var querystring = path[1];
    var dataOnload = JSON.stringify({ Querystring: querystring });

    $(".loading_new").hide();

    $("#loading").css('height', $("body").css('height'));
    $("#loading").show();

    if (companyid != "" || querystring != "") {
        $.ajax({
            url: path[0] + "/LoadSitePath",
            type: "POST",
            data: dataOnload,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (SitePaths) {
                FontPath = SitePaths.d.FontPath;
                BackgroundImagesPath = SitePaths.d.BackgroundImagesPath;
                FrontEndImagePath = SitePaths.d.FrontEndImagePath;
                WebMethodsPath = SitePaths.d.WebMethodsPath;
                FrontEndUploadPath = SitePaths.d.FrontEndUploadPath;
                FrontEndDocumentPath = SitePaths.d.FrontEndDocumentPath;

                mainSitePath = SitePaths.d.FrontEndImagePath;
                SiteImages = SitePaths.d.SiteImages;
                DBKey = SitePaths.d.DBkey;
                ImageUploadPath = SitePaths.d.ImageUploadPath;
                TemplateID = SitePaths.d.TemplateID;
                SesionID = SitePaths.d.SesionID;
                CartitemID = SitePaths.d.CartitemID;
                
                UserID = SitePaths.d.UserID;
                CompanyID = SitePaths.d.CompanyID;
                ServicePath = SitePaths.d.ServicePath;
                PriceCatalogId = SitePaths.d.PriceCatalogId;
                B2BSitePath = SitePaths.d.B2BSitePath;
                PublicSitePath = SitePaths.d.PublicSitePath;
                CType = SitePaths.d.CType;
                AccountID = SitePaths.d.AccountID;

                PDFAPIPath = SitePaths.d.PDFAPIPath;

                loadPage();
                loadHorizontalGroupingData();
                loadVerticalGroupingData();
                if (DBKey != "") {
                    var loadProductname = {};
                    loadProductname.url = ServicePath + "GetProductName";
                    loadProductname.type = "POST";
                    loadProductname.data = JSON.stringify({ priceCatalogueID: PriceCatalogId, _key: DBKey });
                    loadProductname.dataType = "json";
                    loadProductname.processData = false;
                    loadProductname.contentType = "application/json; charset=utf-8";
                    loadProductname.success = function (Productname) {
                        ProductName = Productname.d;
                    };
                    $.ajax(loadProductname);
                }
            }
        });
    }
});

/*Completed*/
function loadPage() {

    $.ajax({
        url: WebMethodsPath + "LoadTemplateToPage",
        type: "POST",
        data: JSON.stringify({ templateid: TemplateID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (templateDetails) {
            
            TemplateDetails = JSON.parse(JSON.stringify(templateDetails.d));
            if (TemplateDetails.ShowEdiotr == false) {
                $("#Menubar").hide();
                $("#LeftPanelDiv").css('height', '600px');
                $(".MainDesigncanvas").css('border-spacing', '0px');
            }
            else if (TemplateDetails.ShowEdiotr == true) {
                $("#LeftPanelDiv").css('height', '600px');
                $("#editor").css('height', '530px');
                $(".MainDesigncanvas").css('border-spacing', '0px');
                $("#Menubar").show();
                $("#Menubar").css({ 'margin-left': '2px', 'margin-right': '3px' });
                var allowAdditem = false;
                if (TemplateDetails.AddNewTextBlock == false) {
                    $(".allowNewItem").hide();
                    $("#btnAddText").hide();
                }
                else if (TemplateDetails.AddNewTextBlock == true) {
                    allowAdditem = true;
                    $("#btnAddText").show();
                }
                if (TemplateDetails.AddNewParagraph == false) {
                    $("#btnAddParagraph").hide();
                }
                else if (TemplateDetails.AddNewParagraph == true) {
                    allowAdditem = true;
                    $("#btnAddParagraph").show();
                }
                if (TemplateDetails.AddNewImage == false) {
                    $("#btnAddImage").hide();
                }
                else if (TemplateDetails.AddNewImage == true) {
                    allowAdditem = true;
                    $("#btnAddImage").show();
                }
                if (allowAdditem) {
                    $(".allowNewItem").show();
                }
                else {
                    $(".allowNewItem").hide();
                }


            }

            $("#canvasLoading").css({ 'height': $("#editor").outerHeight() + "px", 'width': $("#editor").outerWidth()+10 + "px" });
            if (TemplateDetails.isPDFPreviewMandatory == true) {
                $("div.btnpreview").hide();
                $("div.btnAddtoCart").hide();
                $("div.btnPreviewAndAddCart").show();
            }
            else {
                $("div.btnPreviewAndAddCart").hide();
                if (TemplateDetails.IsAllowPDFPreviews == false) {
                    $("div.btnpreview").hide();
                }
            }

            var zoomTemp = TemplateDetails.ZoomPercent / 100;

            if (CType == "public") {
                $("#Menubar").css('width', '715px');
                if (TemplateDetails.ZoomPercent > 200) {
                    zoomTemp = 150.00 / 100.00;
                }
                else {
                    if (TemplateDetails.PageWidth > 700 || TemplateDetails.PageHeight > 800) {
                        zoomTemp = zoomTemp / 2.0;
                    }
                }
                $("#allowoptiontable td").css({ 'padding': '0px 2px 0px 2px' });
                $(".btnn").css({ 'padding': '3px 5px 3px 5px', 'width': '70px' });
                $(".btnSavetodraft").hide();
                $(".btnPrevious").hide();
                $("#LeftPanelDiv").css('height', '550px');
                $("#editor").css({ 'height': '500px' });
                $("#btnPreviewAndAddCart").css('width', '150px');
                $("#rngslidesetzoom").css('width', '50px');
            }


            if (TemplateDetails.CropedImageName != "") {
                CropMarkHeight = TemplateDetails.CropMarkHeight;
                CropMarkWidth = TemplateDetails.CropMarkWidth;
                textCanvasHeight = TemplateDetails.PageHeight - (2 * CropMarkHeight);
                textCanvasWidth = TemplateDetails.PageWidth - (2 * CropMarkWidth);
            }
            else {
                textCanvasHeight = TemplateDetails.PageHeight;
                textCanvasWidth = TemplateDetails.PageWidth;
            }

            $("#textCanvas").css('width', textCanvasWidth + "px");
            $("#textCanvas").css('height', textCanvasHeight + "px");
            var imagepath = BackgroundImagesPath + TemplateDetails.ImageName;
            ImagePath = imagepath;
            if (TemplateDetails.CropedImageName != "") {
                imagepath = BackgroundImagesPath + TemplateDetails.CropedImageName;
            }
            $("#textCanvas").css('background-image', "url('" + imagepath + "')");
            var mainCanWidth = textCanvasWidth * zoomTemp;
            var maincanheight = textCanvasHeight * zoomTemp;
            $("#Maincanvas").css('width', mainCanWidth + 'px');
            $("#Maincanvas").css('height', maincanheight + 'px');
            var ZoomIn = zoomTemp;
            zoomTextCanvas(ZoomIn, true);
            $("#lbltotalpages").html(TemplateDetails.Totalpage);
            $("#lblcurrentpage").html('1');
            loadDropDowns();
        }
    });
}

/*Completed*/
function loadcontrolls() {
    
    var loadControlls = {};
    loadControlls.url = ServicePath + "LoadTemplateControlls";
    loadControlls.type = "POST";
    loadControlls.data = JSON.stringify({ cartitemid: CartitemID, templateid: TemplateID, userid: UserID, companyid: CompanyID, _key: DBKey });
    loadControlls.dataType = "json";
    loadControlls.processData = false;
    loadControlls.contentType = "application/json; charset=utf-8";
    loadControlls.success = function (controllDetails, data) {
        ControllDetails = JSON.parse(JSON.stringify(controllDetails.d));

        //if (parseFloat($("#textCanvas").innerHeight()) > 0) {


            var ControllDetailsByPage = [];
            ControllDetails.map(function (proj) { if (proj.PageNumber == 1) ControllDetailsByPage.push(proj) });

            var ControllDetailsByorderNumber = sortJSON(ControllDetailsByPage, "OrderNumber", "ASC");

            if (ControllDetailsByPage.length > 0 || TemplateDetails.ShowEditablePages == false) {

                for (var i = 0; i < ControllDetailsByorderNumber.length; i++) {
                    if (parseInt(ControllDetailsByorderNumber[i].PageNumber) == 1) {
                        if (ControllDetailsByorderNumber[i].Type == "TextBlock") {
                            AddTextDynamically(ControllDetailsByorderNumber[i]);
                            LoadLeftPanelForText(ControllDetailsByorderNumber[i]);

                        }
                        else if (ControllDetailsByorderNumber[i].Type == "Image") {
                            AddImageDynamically(ControllDetailsByorderNumber[i]);
                            LoadLeftPanelForImage(ControllDetailsByorderNumber[i]);
                        }
                        else if (ControllDetailsByorderNumber[i].Type == "Paragraph") {
                            AddParaDynamically(ControllDetailsByorderNumber[i]);
                            LoadLeftPanelForPara(ControllDetailsByorderNumber[i]);
                        }
                    }
                }
            }
            else {
                changeThePageFromNavigation(2, true);
            }
            unbindMenuBar();
            setTimeout(function () {
                
                listOfPositionForMoveUp();
                listOfPositionForMoveDown();
                listOfPositionForKeepRight();
                listOfPositionForKeepLeft();
                postionControlsGroupWise();
                $("#loading").hide();
                $(".loading_new").css('height', $("body").css('height'));
            }, 2000);

        //}
        //else {
        //    loadPage();
        //}
    };
    $.ajax(loadControlls);

}

/*Completed*/
function loadFontStyeDropDowns() {
    var loadFontStyle = {};
    loadFontStyle.url = ServicePath + "LoadFontStyle";
    loadFontStyle.type = "POST";
    loadFontStyle.data = JSON.stringify({ companyid: CompanyID, _key: DBKey });
    loadFontStyle.dataType = "json";
    loadFontStyle.processData = false;
    loadFontStyle.contentType = "application/json; charset=utf-8";
    loadFontStyle.success = function (FontStyle) {
        if (FontStyle.d.length > 0) {
            var loadFont = {};
            loadFont.url = ServicePath + "GetFontStyle";
            loadFont.type = "POST";
            loadFont.data = JSON.stringify({ FontStyle: FontStyle.d[0].UserFontSyleName, companyid: CompanyID, _key: DBKey });
            loadFont.dataType = "json";
            loadFont.processData = false;
            loadFont.contentType = "application/json; charset=utf-8";
            loadFont.success = function (Font) {
                FontStyleDetails = JSON.parse(JSON.stringify(Font.d));
                debugger;
            };
            $.ajax(loadFont);
        }
    };
    $.ajax(loadFontStyle);

    var loadColorStyle = {};
    loadColorStyle.url = ServicePath + "GetColorStyleDetailProperties";
    loadColorStyle.type = "POST";
    loadColorStyle.data = JSON.stringify({ companyid: CompanyID, _key: DBKey });
    loadColorStyle.dataType = "json";
    loadColorStyle.processData = false;
    loadColorStyle.contentType = "application/json; charset=utf-8";
    loadColorStyle.success = function (ColorStyle) {
        ColorStyleDetails = JSON.parse(JSON.stringify(ColorStyle.d));
        loadcontrolls();
    };
    $.ajax(loadColorStyle);
}

/*Completed*/
function loadDropDowns() {
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
                loadFontDropdown(Font.d[i].DisplayFontName, Font.d[i].FontFilePath, Font.d[i].FontID, Font.d[i].ActualFontName, "#drpFont", 'none');
            }

        }
    });



    /*Added By Salim*/
    $.ajax({
        url: ServicePath + "LoadDataForDropDownsContact",
        type: "POST",
        data: JSON.stringify({ StoreuserID: UserID, Type: "Contact", _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (Contact) {
            DropDownContactList = JSON.parse(JSON.stringify(Contact.d));
        }
    });



    /*Added By Salim*/
    $.ajax({
        url: ServicePath + "LoadDataForDropDownDepartment",
        type: "POST",
        data: JSON.stringify({ cartitemid: CartitemID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (dept) {
            DropDownDepartmentList = JSON.parse(JSON.stringify(dept.d));
            loadFontStyeDropDowns();

            loadcategoryList("");
        }
    });

    $.ajax({
        url: ServicePath + "LoadDataBaseContentsAddress",
        type: "POST",
        data: JSON.stringify({ userid: UserID, cartitemid: CartitemID, type: "Address", _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (address) {
            DropDownAddressList = JSON.parse(JSON.stringify(address.d));
        }
    });

    $.ajax({
        url: ServicePath + "LoadDataBasePhraseTextForDropDowns",
        type: "POST",
        data: JSON.stringify({ Companyid: CompanyID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (phrase) {
            DropDownPhraseList = JSON.parse(JSON.stringify(phrase.d));
        }
    });

}

/*completed*/
function loadFontDropdown(fontName, fontFilePath, FontID, ActualFontName, id, selcted) {
    if (selcted == "none") {
        $(id).append("<option value='" + fontFilePath + "~" + FontID + "~" + ActualFontName + "~" + fontName + "' id='drpFontID" + FontID + "' >" + fontName + "</option>");
    }

}

/*completed*/
function AddTextDynamically(controllDetails, AddNew) {
    
    var defaultContent = capitalizeTheText(controllDetails.DefaultContent, controllDetails.Capitalize);
    if (controllDetails.Dropdowns != "None" && controllDetails.DatabaseContent == "") {
        defaultContent = "";
        //var control;
        //ControllDetails.map(function (proj) { if (proj.ObjectID == controllDetails.ObjectID) control = proj });
        //control.DefaultContent = "";
    }

    var TextHtml = "<div class='Text controll'";
    TextHtml += "id='" + controllDetails.ObjectID + "'";
    TextHtml += "name='" + controllDetails.FieldName + "'";
    TextHtml += "title='" + controllDetails.HelpText + "'";
    TextHtml += "style='position:absolute;background-color:transparent;cursor:pointer;white-space:nowrap;";
    TextHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    TextHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
    //TextHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    TextHtml += "line-height:1;";
    TextHtml += "vertical-align:bottom;";
    TextHtml += "'>";

    if (controllDetails.Labels == "Use Labels") {

        TextHtml += "<div class='labelText' style='position:absolute;bottom:-1px;padding:0px;margin:0px;vertical-align:baseline;line-height:.7;border:1px dashed transparent;";
        TextHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
        if (controllDetails.ManualTrackDimension == "pt") {
            TextHtml += (controllDetails.ManualTracking * ptConvertionConstant).toFixed(4) + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            TextHtml += (controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
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
        TextHtml += "font-style:" + controllDetails.FontStyle + ";'>";

        TextHtml += "<span style='font-size:" + controllDetails.LabelFontSize / ptConvertionConstant + "px;text-align:left;vertical-align:baseline;display:inline-block;position:relative;border-width:0px !important;line-height:.7;bottom:0px;";
        if (controllDetails.DefaultContent == "") {
            TextHtml += "display:none;";
        }
        if (controllDetails.Dropdowns != "None" && controllDetails.DatabaseContent == "") {
            TextHtml += "display:none;";
        }

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
            debugger;
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
            ;
        TextHtml += "<div class='labelText' style='bottom:-1px;position:absolute;padding:0px;margin:0px;vertical-align:baseline;line-height:.7;border:1px dashed transparent;";
        TextHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
        if (controllDetails.ManualTrackDimension == "pt") {
            TextHtml += (controllDetails.ManualTracking * ptConvertionConstant).toFixed(4) + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            TextHtml += (controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
        }
        TextHtml += "color:rgba(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ", " + controllDetails.A + ");";
        //TextHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
        TextHtml += "font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;";
        TextHtml += "padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;";
        uniquefontname = getuniquefontname();

        var Font = null;
        FontList.map(function (proj) { if (proj.DisplayFontName == controllDetails.FontFamily) Font = proj });
        $("head").append("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + FontPath + Font.FontFilePath + "'); }</style>");

        TextHtml += "font-family:" + uniquefontname + ";";
        TextHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        TextHtml += "font-weight:" + controllDetails.FontWeight + ";";
        TextHtml += "font-style:" + controllDetails.FontStyle + ";";
        TextHtml += "'>" + defaultContent + "</div></div>";
    }

    $("#textCanvas").append(TextHtml);
    
    alignsingleLineText(controllDetails.ObjectID);
    applyonexceedwidth(controllDetails.ObjectID);
    fixPostionOfControll(controllDetails, controllDetails.PositionX - CropMarkWidth, controllDetails.PositionY - CropMarkHeight, controllDetails.TextAlign);

    
    $("#" + controllDetails.ObjectID).css({
        'transformOrigin': 'left bottom',
        '-webkit-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-moz-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-ms-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        'transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)'
    });

    functionalities(controllDetails.Lock, controllDetails.ObjectID, true);
    if (AddNew) {
        applyBorderForControl(controllDetails.ObjectID, controllDetails.Type);
        changeSelectedControllID();
        for (var i = 0; i < ControllDetails.length; i++) {
            if (ControllDetails[i].ObjectID == selectedObjectID) {
                ControllDetails[i].MaxHeight = (parseFloat($("#" + selectedObjectID + " .labelText").css('line-height')) / mmConvertionConstant);
                ControllDetails[i].Height = (parseFloat($("#" + selectedObjectID + " .labelText").css('line-height')) / mmConvertionConstant);
            }
        }
        bindMenuBar(controllDetails.ObjectID);
    }
    if (controllDetails.LabelColor != "") {
        for (var j = 0; j < ColorStyleDetails.length; j++) {
            if (ColorStyleDetails[j].ColorStyleName == controllDetails.LabelColor) {
                var arry = getRGBFromCMYK(ColorStyleDetails[j].C, ColorStyleDetails[j].M, ColorStyleDetails[j].Y, ColorStyleDetails[j].K).split('~');
                $("#" + controllDetails.ObjectID).css({ 'color': 'rgb(' + arry[0] + ', ' + arry[1] + ', ' + arry[2] + ')' });
                break;
            }
        }
    }


    if ($("#" + controllDetails.ObjectID + " .label").outerHeight() > $("#" + controllDetails.ObjectID + " .labelText").outerHeight()) {
        $("#" + controllDetails.ObjectID).css({ 'height': $("#" + controllDetails.ObjectID + " .label").outerHeight() + "px" });
    }
    else {
        $("#" + controllDetails.ObjectID).css({ 'height': $("#" + controllDetails.ObjectID + " .labelText").outerHeight() + "px" });
    }
    if (controllDetails.GroupID == 0) {
        controllDetails.MaxHeight = $("#" + controllDetails.ObjectID).outerHeight() / mmConvertionConstant;
        controllDetails.Height = $("#" + controllDetails.ObjectID).outerHeight() / mmConvertionConstant;
    }

}

/*completed*/
function AddParaDynamically(controllDetails, AddNew) {
    

    var defaultContent = capitalizeTheText(controllDetails.DefaultContent, controllDetails.Capitalize);

    if (controllDetails.Dropdowns != "None" && controllDetails.DatabaseContent == "") {
        defaultContent = "";
        var control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == controllDetails.ObjectID) control = proj });
        control.DefaultContent = "";
    }

    defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>").replace(/&nbsp;/g, " ");
    var ParaHtml = "<div class='Para controll'";
    ParaHtml += "id='" + controllDetails.ObjectID + "'";
    ParaHtml += "name='" + controllDetails.FieldName + "'";
    ParaHtml += "title='" + controllDetails.HelpText + "'";
    ParaHtml += "style='position:absolute;background-color:transparent;";
    ParaHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
    ParaHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    ParaHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
    if (controllDetails.ManualTrackDimension == "pt") {
        ParaHtml += (controllDetails.ManualTracking * ptConvertionConstant).toFixed() + "px;";
    }
    else if (controllDetails.ManualTrackDimension == "mm") {
        ParaHtml += (controllDetails.ManualTracking * mmConvertionConstant).toFixed() + "px;";
    }
    //ParaHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    
    ParaHtml += "color:rgb(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ");";
    ParaHtml += "font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;";
    ParaHtml += "padding:0px;margin:0px;vertical-align:top;";
    var uniquefontname = getuniquefontname();



    ParaHtml += "z-index:-1;";

    ParaHtml += "text-align:" + controllDetails.TextAlign + ";";
    
    if (controllDetails.DefaultContent == "") {
        ParaHtml += "'><p style='font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;color:rgb(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ");margin:0px;word-wrap:break-word;white-space: pre-line;text-align:" + controllDetails.TextAlign + ";line-height:100%;display:inline-block;max-width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;border:1px dashed transparent;";
        if (controllDetails.TextAlign == "Justify") {
            ParaHtml += "text-justify:distribute;";
        }
        var Font = null;
        FontList.map(function (proj) { if (proj.DisplayFontName == controllDetails.FontFamily) Font = proj });
        if (Font != null) {
            $("head").append("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + FontPath + Font.FontFilePath + "'); }</style>");
            ParaHtml += "font-family:" + uniquefontname + ";";
        }
        else {
            ParaHtml += "font-family:arial;";
        }
        ParaHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
        if (controllDetails.ManualTrackDimension == "pt") {
            ParaHtml += (controllDetails.ManualTracking * ptConvertionConstant).toFixed() + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            ParaHtml += (controllDetails.ManualTracking * mmConvertionConstant).toFixed() + "px;";
        }
        ParaHtml += "padding:0px;margin:0px;padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;vertical-align:top;";
        ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";' class='paraText'>" + defaultContent + "</p></div>";
    }
    else {
        ParaHtml += "'><p style='font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;color:rgb(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ");margin:0px;word-wrap:break-word;white-space: pre-line;text-align:" + controllDetails.TextAlign + ";line-height:100%;display:inline-block;max-width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;border:1px dashed transparent;";
        var Font = null;
        FontList.map(function (proj) { if (proj.DisplayFontName == controllDetails.FontFamily) Font = proj });
        if (Font != null) {
            $("head").append("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + FontPath + Font.FontFilePath + "'); }</style>");
            ParaHtml += "font-family:" + uniquefontname + ";";
        }
        else {
            ParaHtml += "font-family:arial;";
        }
        if (controllDetails.TextAlign == "Justify") {
            ParaHtml += "text-justify:distribute;";

        }
        ParaHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
        if (controllDetails.ManualTrackDimension == "pt") {
            ParaHtml += (controllDetails.ManualTracking * ptConvertionConstant).toFixed() + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            ParaHtml += (controllDetails.ManualTracking * mmConvertionConstant).toFixed() + "px;";
        }
        ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        ParaHtml += "font-weight:" + controllDetails.FontWeight + ";";
        ParaHtml += "font-style:" + controllDetails.FontStyle + ";>";
        ParaHtml += "padding:0px;margin:0px;padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;vertical-align:top;' class='paraText'>" + defaultContent + "</p></div>";
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
    fixPostionOfControll(controllDetails, controllDetails.PositionX - CropMarkWidth, controllDetails.PositionY - CropMarkHeight, controllDetails.TextAlign);

    functionalities(controllDetails.Lock, controllDetails.ObjectID, true);
    if (AddNew) {
        applyBorderForControl(controllDetails.ObjectID, controllDetails.Type);
        changeSelectedControllID();
        for (var i = 0; i < ControllDetails.length; i++) {
            if (ControllDetails[i].ObjectID == selectedObjectID) {
                ControllDetails[i].MaxHeight = parseFloat($("#" + selectedObjectID).innerHeight() / mmConvertionConstant);
                ControllDetails[i].Height = parseFloat($("#" + selectedObjectID).innerHeight() / mmConvertionConstant);
            }
        }
        bindMenuBar(controllDetails.ObjectID);
    }

}

/*completed*/
function AddImageDynamically(controllDetails, AddNew) {
    var imagepath = "";
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
    ImageHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
    ImageHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    ImageHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    ImageHtml += "border:1px dashed transparent;' >";

    if (controllDetails.BackgroundImage != "") {
        if (controllDetails.BackgroundImage == "noimage.png" || controllDetails.BackgroundImage == "noimage.jpg") {
            ImageHtml += "<img  src='" + SiteImages + "noimage.jpg";
            imagepath = SiteImages + "noimage.jpg";
        }
        else {
            if (controllDetails.IsFromBackEnd == true) {
                ImageHtml += "<img  src='" + BackgroundImagesPath + controllDetails.BackgroundImage;
                imagepath = BackgroundImagesPath + controllDetails.BackgroundImage;
            }
            else {
                ImageHtml += "<img  src='" + FrontEndDocumentPath + TemplateID + "/Images/" + controllDetails.BackgroundImage;
                imagepath = FrontEndDocumentPath + TemplateID + "/Images/" + controllDetails.BackgroundImage;
            }
        }
    }
    else {
        if (controllDetails.ImgUrl == "noimage.png" || controllDetails.ImgUrl == "noimage.jpg") {
            ImageHtml += "<img  src='" + SiteImages + "noimage.jpg";
            imagepath = SiteImages + "noimage.jpg";
        }
        else {
            if (controllDetails.IsFromBackEnd == true) {
                if (controllDetails.ExceedImage == "S" || controllDetails.ExceedImage == "D") {
                    ImageHtml += "<img  src='" + BackgroundImagesPath + controllDetails.OrignalImageName;
                    imagepath = BackgroundImagesPath + controllDetails.OrignalImageName;
                }
                else {
                    ImageHtml += "<img  src='" + BackgroundImagesPath + controllDetails.ImgUrl;
                    imagepath = BackgroundImagesPath + controllDetails.ImgUrl;
                }
            }
            else {
                ImageHtml += "<img  src='" + FrontEndDocumentPath + TemplateID + "/Images/" + controllDetails.ImgUrl;
                imagepath = FrontEndDocumentPath + TemplateID + "/Images/" + controllDetails.ImgUrl;
            }
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




    if (controllDetails.BackgroundImage != "") {
        fixPostionOfControll(controllDetails, 0, 0, controllDetails.TextAlign);
    }
    else {
        fixPostionOfControll(controllDetails, controllDetails.PositionX - CropMarkWidth, controllDetails.PositionY - CropMarkHeight, controllDetails.TextAlign);
    }
    functionalities(controllDetails.Lock, controllDetails.ObjectID, false);
    if (AddNew) {
        $("#" + controllDetails.ObjectID).css('border', '1px solid #B2B2B2');
        $("#" + controllDetails.ObjectID).css('cursor', 'pointer');
        changeSelectedControllID();
        for (var i = 0; i < ControllDetails.length; i++) {
            if (ControllDetails[i].ObjectID == selectedObjectID) {
                ControllDetails[i].MaxHeight = parseFloat($("#" + selectedObjectID).innerHeight() / mmConvertionConstant);
                ControllDetails[i].Height = parseFloat($("#" + selectedObjectID).innerHeight() / mmConvertionConstant);
            }
        }
        bindMenuBar(controllDetails.ObjectID);
    }

    if ($("#" + controllDetails.ObjectID).outerHeight() < ($("#" + controllDetails.ObjectID + " img").outerHeight())) {
        $("#" + controllDetails.ObjectID + " img").css({ 'height': parseFloat(controllDetails.MaxHeight) * mmConvertionConstant + 'px' });
    }
    if ($("#" + controllDetails.ObjectID).outerWidth() < ($("#" + controllDetails.ObjectID + " img").outerWidth())) {
        $("#" + controllDetails.ObjectID + " img").css({ 'width': parseFloat(controllDetails.MaxWidth) * mmConvertionConstant + 'px' });
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
/*completed*/
function LoadLeftPanelForText(controlDetails) {

    if (controlDetails.HideVisibility == false) {
        var TextHtml = "";
        TextHtml += "<tr id='" + controlDetails.ObjectID + "_row'><td style='padding:3px 0px 3px 0px;width:250px;'>";
        TextHtml += "<div style='font-family:Calibri;font-size:13px;font-weight:bold;padding-bottom:2px;'>" + controlDetails.FriendlyName;
        if (controlDetails.Mandatory == true) {
            TextHtml += "<sapn style='font-family:Calibri;font-size:13px;font-weight:bold;color:red;'> *</span>";
        }
        if (controlDetails.HelpText != "") {
            TextHtml += "<img  src='StyleSheets/Images/Help-icon.png' width='15' height='15' style='float:right;padding-bottom:2px;'  title='" + controlDetails.HelpText + "' />";
        }
        TextHtml += "</div>";
        /*Added By salim*/

        var dropdowns = false;

        if (controlDetails.Dropdowns != "None" && controlDetails.DatabaseContent == "") {
            dropdowns = true;
            TextHtml += "<select class='dropdown'";
            TextHtml += " id='" + controlDetails.ObjectID + "_dll' style='width:101%;height:20px;padding-left:3px;border:1px solid #888888;border-radius:4px;font-family:Calibri;font-size:13px;background: -moz-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -webkit-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -o-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -ms-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -ms-linear-gradient( #FFFFFF,#FFFFFF,#D0D6DA);-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
            
            TextHtml += '<option value="" >-- Select --</option>';
            if (controlDetails.Dropdowns == "Department") {
                for (var c = 0; c < DropDownDepartmentList.length; c++) {
                    if (controlDetails.DefaultContent != "" && controlDetails.DefaultContent == DropDownDepartmentList[c]) {
                        TextHtml += "<option value='" + DropDownDepartmentList[c] + "' selected>" + DropDownDepartmentList[c] + "</option>";
                        LoadDefaultContent(DropDownDepartmentList[c], controlDetails.ObjectID);
                    }
                    else {
                        TextHtml += '<option value="' + DropDownDepartmentList[c] + '">' + DropDownDepartmentList[c] + '</option>';
                    }

                }
                loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
            }
            else if (controlDetails.Dropdowns == "Contact") {
                for (var c = 0; c < DropDownContactList.length; c++) {
                    if (controlDetails.DefaultContent != "" && controlDetails.DefaultContent == DropDownContactList[c]) {
                        TextHtml += "<option value='" + DropDownContactList[c] + "' selected>" + DropDownContactList[c] + "</option>";
                        LoadDefaultContent(DropDownContactList[c], controlDetails.ObjectID);
                    }
                    else {
                        TextHtml += '<option value="' + DropDownContactList[c] + '">' + DropDownContactList[c] + '</option>';
                    }
                }
                loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
            }
            else if (controlDetails.Dropdowns == "Address") {
                for (var c = 0; c < DropDownAddressList.length; c++) {
                    if (controlDetails.DefaultContent != "" && controlDetails.DefaultContent == DropDownAddressList[c]) {
                        TextHtml += "<option value='" + DropDownAddressList[c] + "' selected>" + DropDownAddressList[c] + "</option>";
                        LoadDefaultContent(DropDownAddressList[c], controlDetails.ObjectID);
                    }
                    else {
                        TextHtml += '<option value="' + DropDownAddressList[c] + '">' + DropDownAddressList[c] + '</option>';
                    }
                }
                loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails)
            }
            else if (controlDetails.Dropdowns == "Phrase") {
                if (controlDetails.PhraseBookID > 0) {
                    var getProperties = [];
                    DropDownPhraseList.map(function (proj) { if (proj.PhraseID == controlDetails.PhraseBookID) getProperties.push(proj) });

                    if (getProperties.length > 0) {
                        var _type = getProperties[0].Type;
                        var _seperator = getProperties[0].Seperator + '';
                        var _text = getProperties[0].PhrasText.split(_seperator);

                        if (_text.length == 1) {
                            _text = getProperties[0].PhrasText.split(_seperator);
                        }

                        if (_type == "Fixed") {
                            for (var a = 0; a < _text.length; a++) {
                                var _value = _text[a] + '';
                                _value = _value.trim();
                                if (controlDetails.DefaultContent != "" && _value.indexOf(controlDetails.DefaultContent) != -1) {
                                    TextHtml += "<option value='" + _value + "' selected>" + _value + "</option>";
                                    LoadDefaultContent(_value, controlDetails.ObjectID);
                                }
                                else {
                                    TextHtml += "<option value='" + _value + "'>" + _value + "</option>";
                                }
                            }
                            loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
                        }
                        else {
                            $.ajax({
                                url: ServicePath + "LoadDataBasePhrasstextBasedOnType",
                                type: "POST",
                                data: JSON.stringify({ userid: UserID, cartitemid: CartitemID, phraseid: controlDetails.PhraseBookID, templateid: TemplateID, type: _type, _key: DBKey }),
                                dataType: "json",
                                processData: false,
                                contentType: "application/json; charset=utf-8",
                                success: function (Phrase) {
                                    var PhraseDatBaseList = JSON.parse(JSON.stringify(Phrase.d));

                                    if (PhraseDatBaseList.length > 0) {
                                        for (var k = 0; k < PhraseDatBaseList.length; k++) {
                                            var value = PhraseDatBaseList[k] + '';
                                            if (controlDetails.DefaultContent != "" && value.indexOf(controlDetails.DefaultContent) != -1) {
                                                TextHtml += "<option value='" + value + "' selected>" + value + "</option>";
                                                LoadDefaultContent(value, controlDetails.ObjectID);
                                            }
                                            else {
                                                TextHtml += "<option value='" + value + "' >" + value + "</option>";
                                            }
                                        }
                                    }
                                    loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
                                },
                                error: function () {

                                    alert("v");
                                }
                            });
                        }
                    }
                }
                else {
                    loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
                }
            }

        }
        else {
            loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
        }
    }
}
/*completed*/
function loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails) {
    if (dropdowns) {
        TextHtml += '</select>';

    }
    else {
        TextHtml += "<input class='textbox";
        if (controlDetails.Mandatory == true) {
            TextHtml += " Mandatory";
        }
        TextHtml += "' id='" + controlDetails.ObjectID + "_txt' type='text' style='width:100%;height:20px;border:1px solid #778B9C;border-radius:1px;padding-left:3px;font-family:Calibri;font-size:16px;padding-top:2px;padding-bottom:2px;' value='" + controlDetails.DefaultContent+"' ";
        
        if (controlDetails.DataType == "Number") {
            TextHtml += " onkeypress='return validateQty(event);' oninput='vaild(event)' ";
        }
        TextHtml += " />";
    }

    /*End*/

    TextHtml += "</td></tr>";
    $("#LeftPanelControl").append(TextHtml);
    
    if (controlDetails.Edit == false) {
        $("#" + controlDetails.ObjectID + "_txt").prop('disabled', true);
        if (controlDetails.Dropdowns != "None" && controlDetails.DatabaseContent == "") {
            $("#" + controlDetails.ObjectID + "_ddl").prop('disabled', true);
        }
    }
    loadOnchange();
}
/*completed*/
function LoadLeftPanelForPara(controlDetails) {
    
    if (controlDetails.HideVisibility == false) {
        var TextHtml = "";
        TextHtml += "<tr id='" + controlDetails.ObjectID + "_row' ><td style='padding:3px 0px 3px 0px;width:250px;'>";
        TextHtml += "<div style='font-family:Calibri;font-size:13px;font-weight:bold;padding-bottom:2px;'>" + controlDetails.FriendlyName;
        if (controlDetails.Mandatory == true) {
            TextHtml += "<sapn style='font-family:Calibri;font-size:13px;font-weight:bold;color:red;'> *</span>";
        }
        if (controlDetails.HelpText != "") {
            TextHtml += "<img  src='StyleSheets/Images/Help-icon.png' width='15' height='15' style='float:right;padding-bottom:2px;'  title='" + controlDetails.HelpText + "' />";
        }
        TextHtml += "</div>";

        var dropdowns = false;

        if (controlDetails.Dropdowns != "None" && controlDetails.DatabaseContent == "") {
            dropdowns = true;
            TextHtml += "<select class='dropdown";
            TextHtml += "' id='" + controlDetails.ObjectID + "_dll' style='width:101%;height:20px;padding-left:3px;border:1px solid #888888;border-radius:4px;font-family:Calibri;font-size:13px;background: -moz-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -webkit-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -o-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -ms-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";

            TextHtml += '<option value="" >-- Select --</option>';
            if (controlDetails.Dropdowns == "Department") {
                for (var c = 0; c < DropDownDepartmentList.length; c++) {
                    if (controlDetails.DefaultContent != "" && controlDetails.DefaultContent == DropDownDepartmentList[c]) {
                        TextHtml += "<option value='" + DropDownDepartmentList[c] + "' selected>" + DropDownDepartmentList[c] + "</option>";
                        LoadDefaultContent(DropDownDepartmentList[c], controlDetails.ObjectID);
                    }
                    else {
                        TextHtml += '<option value="' + DropDownDepartmentList[c] + '">' + DropDownDepartmentList[c] + '</option>';
                    }
                }
                loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails);
            }
            else if (controlDetails.Dropdowns == "Contact") {
                for (var c = 0; c < DropDownContactList.length; c++) {
                    if (controlDetails.DefaultContent != "" && controlDetails.DefaultContent == DropDownContactList[c]) {
                        TextHtml += "<option value='" + DropDownContactList[c] + "' selected>" + DropDownContactList[c] + "</option>";
                        LoadDefaultContent(DropDownContactList[c], controlDetails.ObjectID);
                    }
                    else {
                        TextHtml += '<option value="' + DropDownContactList[c] + '">' + DropDownContactList[c] + '</option>';
                    }
                }
                loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails);
            }
            else if (controlDetails.Dropdowns == "Address") {
                for (var c = 0; c < DropDownAddressList.length; c++) {
                    if (controlDetails.DefaultContent != "" && controlDetails.DefaultContent == DropDownAddressList[c]) {
                        TextHtml += "<option value='" + DropDownAddressList[c] + "' selected>" + DropDownAddressList[c] + "</option>";
                        LoadDefaultContent(DropDownAddressList[c], controlDetails.ObjectID);
                    }
                    else {
                        TextHtml += '<option value="' + DropDownAddressList[c] + '">' + DropDownAddressList[c] + '</option>';
                    }
                }
                loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails)
            }
            else if (controlDetails.Dropdowns == "Phrase") {
                if (controlDetails.PhraseBookID > 0) {
                    var getProperties = [];
                    DropDownPhraseList.map(function (proj) { if (proj.PhraseID == controlDetails.PhraseBookID) getProperties.push(proj) });

                    if (getProperties.length > 0) {
                        var _type = getProperties[0].Type;
                        var _seperator = getProperties[0].Seperator + '';
                        var _text = getProperties[0].PhrasText.split(_seperator);

                        if (_text.length == 1) {
                            _text = getProperties[0].PhrasText.split(_seperator);
                        }

                        if (_type == "Fixed") {
                            for (var a = 0; a < _text.length; a++) {
                                var _value = _text[a] + '';
                                _value = _value.trim();
                                if (controlDetails.DefaultContent != "" && _value.indexOf(controlDetails.DefaultContent) != -1) {
                                    TextHtml += '<option value="' + _value + '" selected>' + _value + '</option>';
                                    LoadDefaultContent(_value, controlDetails.ObjectID);
                                }
                                else {
                                    TextHtml += '<option value="' + _value + '">' + _value + '</option>';
                                }
                            }
                            loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails);
                        }
                        else {
                            $.ajax({
                                url: ServicePath + "LoadDataBasePhrasstextBasedOnType",
                                type: "POST",
                                data: JSON.stringify({ userid: UserID, cartitemid: CartitemID, phraseid: controlDetails.PhraseBookID, templateid: TemplateID, type: _type, _key: DBKey }),
                                dataType: "json",
                                processData: false,
                                contentType: "application/json; charset=utf-8",
                                success: function (Phrase) {
                                    var PhraseDatBaseList = JSON.parse(JSON.stringify(Phrase.d));

                                    if (PhraseDatBaseList.length > 0) {
                                        for (var k = 0; k < PhraseDatBaseList.length; k++) {
                                            var value = PhraseDatBaseList[k] + '';
                                            if (controlDetails.DefaultContent != "" && value.indexOf(controlDetails.DefaultContent) != -1) {
                                                TextHtml += '<option value="' + value + '" selected>' + value + '</option>';
                                                LoadDefaultContent(value, controlDetails.ObjectID);
                                            }
                                            else {
                                                TextHtml += '<option value="' + value + '">' + value + '</option>';
                                            }
                                        }
                                    }
                                    loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails);
                                }
                            });
                        }
                    }
                }
                else {
                    loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
                }
            }
            else {
                loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
            }
        }
        else {
            loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails);
        }


    }
}
/*completed*/
function loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails) {
    if (dropdowns) {
        TextHtml += '</select>';
    }
    else {
        TextHtml += "<textarea class='TxtArea";
        if (controlDetails.Mandatory == true) {
            TextHtml += " Mandatory";
        }
        TextHtml += "' id='" + controlDetails.ObjectID + "_txt'  style='width:100%;height:70px;border:1px solid #778B9C;border-radius:1px;padding-left:3px;font-family:Calibri;font-size:16px;'";
        if (controlDetails.DataType == "Number") {
            TextHtml += "' onkeypress='return validateQty(event);' oninput='vaild(event)' ";
        }
        TextHtml += " >" + controlDetails.DefaultContent + "</textarea>";
    }
    TextHtml += "</td></tr>";
    $("#LeftPanelControl").append(TextHtml);
    
    if (controlDetails.Edit == false) {
        $("#" + controlDetails.ObjectID + "_txt").prop('disabled', true);
        if (controlDetails.Dropdowns != "None" && controlDetails.DatabaseContent == "") {
            $("#" + controlDetails.ObjectID + "_ddl").prop('disabled', true);
        }
    }
    loadOnchange();
}
/*completed*/
function LoadLeftPanelForImage(controlDetails) {
    var ImageHtml = "";
    if (controlDetails.HideVisibility == false) {
        ImageHtml += "<tr id='" + controlDetails.ObjectID + "_row' ><td style='padding:3px 0px 3px 0px;width:250px;'>";
        ImageHtml += "<div style='font-family:Calibri;font-size:13px;font-weight:bold;padding-bottom:0px;'>" + controlDetails.FriendlyName;
        if (controlDetails.Mandatory == true) {
            ImageHtml += " <sapn style='font-family:Calibri;font-size:13px;font-weight:bold;color:red;'>*</span>";
        }
        if (controlDetails.HelpText != "") {
            ImageHtml += "<img  src='StyleSheets/Images/Help-icon.png' width='15' height='15' style='float:right;padding-bottom:2px;'  title='" + controlDetails.HelpText + "' />";
        }
        ImageHtml += "</div>";
        if (controlDetails.Edit == true) {
            ImageHtml += "<span title='Delete Image' id='" + controlDetails.ObjectID + "_dlt' class='imagedlt'  style='margin-left:5px;font-family:Calibri;font-size:13px;font-weight:bold;cursor:pointer;color:red;display:inline;width:35px;' ";
            if (controlDetails.Mandatory == true) {
                ImageHtml += "class='Mandatory'";
            }
            ImageHtml += " >X</span>";
            ImageHtml += "<span  style='font-family:Calibri;font-size:13px;font-weight:bold;cursor:default;display:inline;width:10px;'";
            ImageHtml += " >&nbsp;|&nbsp;</span>";
        }
        ImageHtml += "<span title='Change Image' class='changeimagelink'  id='" + controlDetails.ObjectID + "_chg' style='font-family:Calibri;font-size:13px;cursor:pointer;font-weight:bold;color:#3296FF;display:inline;width:110px;'>Change Image</span></td></tr>";
        $("#LeftPanelControl").append(ImageHtml);
    }
    loadOnchange();
}

function loadOnchange() {
    $(document).ready(function () {
        $(".textbox").unbind('keyup').bind('keyup', function () {
            var id = $(this).attr('id').split('_')[0];
            var text = $(this).val();
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            var text = $(this).val();
            LoadDefaultContent(text, id);

            bindMenuBar(id);
            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
        });
        $(".textbox").unbind('change').bind('change', function () {
            var id = $(this).attr('id').split('_')[0];
            var text = $(this).val();
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            var text = $(this).val();
            LoadDefaultContent(text, id);
            bindMenuBar(id);
            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
        });

        $(".textbox").unbind('focusout').bind('focusout', function () {
            var id = $(this).attr('id').split('_');
            var text = $(this).val();
            onfocusoutgroupCntorll();
        });

        $(".dropdown").unbind('change').bind('change', function () {

            var id = $(this).attr('id').split('_')[0];
            deSelect();
            var text = $(this).val();
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            LoadDefaultContent(text, id);

            bindMenuBar(id);
            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
        });

        $(".dropdown").unbind('focusout').bind('focusout', function () {

            var id = $(this).attr('id').split('_');
            var text = $(this).val();
            onfocusoutgroupCntorll();
        });

        $(".dropdown").unbind('focusin').bind('focusin', function () {

            var id = $(this).attr('id').split('_')[0];
            var text = $(this).val();
            deSelect();
            ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            onfocusingroupCntorll(id);
            bindMenuBar(id);
            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
        });

        $(".textbox").unbind('focusin').bind('focusin', function () {
            var id = $(this).attr('id').split('_')[0];
            var text = $(this).val();
            deSelect();

            if (text != "") {
                applyBorderForControl(id, "TextBlock");
            }
            $(this).css('background-color', 'rgba(233, 245, 248,255)');
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            onfocusingroupCntorll(id);
            bindMenuBar(id);
            if (text != "") {
                applyBorderForControl(id, "TextBlock");
            }
        });

        $(".TxtArea").unbind('keyup').bind('keyup', function () {
            var id = $(this).attr('id').split('_')[0];
            //$("#" + id[0] + " .labelText").html($(this).val());   
            $("#" + id + " p").css('border', '1px dashed rgb(128, 128, 128)');

            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            var text = $(this).val();

            LoadDefaultContent(text, id);
            bindMenuBar(id);
        });

        $(".TxtArea").unbind('change').bind('change', function () {
            var id = $(this).attr('id').split('_')[0];
            //$("#" + id[0] + " .labelText").html($(this).val());   
            $("#" + id + " p").css('border', '1px dashed rgb(128, 128, 128)');

            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            var text = $(this).val();

            LoadDefaultContent(text, id);
            bindMenuBar(id);
        });

        $(".TxtArea").unbind('focusin').bind('focusin', function () {

            var id = $(this).attr('id').split('_')[0];
            deSelect();
            $("#" + id + " p").css('border', '1px dashed rgb(128, 128, 128)');
            $(this).css('background-color', 'rgba(233, 245, 248,255)');
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            bindMenuBar(id);
            document.getElementById(id).scrollIntoView();
        });

        $(".changeimagelink").unbind('click').bind('click', function () {

            var id = $(this).attr('id').split('_')[0];
            deSelect();
            $("#" + id).css('border', '1px solid #B2B2B2');
            //$(this).css('background-color', 'rgb(255, 233, 248)');
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            var fromgallery = "";
            var fromharddisk = "";
            for (var i = 0; i < ControllDetails.length; i++) {
                if (ControllDetails[i].ObjectID == selectedObjectID) {
                    fromharddisk = ControllDetails[i].ImageSource;
                    fromgallery = ControllDetails[i].ImageGallery;
                    break;
                }
            }
            openGallery(fromgallery, fromharddisk);
            bindMenuBar(id);
            document.getElementById(id).scrollIntoView();
        });

        $(".imagedlt").unbind('click').bind('click', function () {
            var id = $(this).attr('id').split('_')[0];
            deSelect();
            for (var i = 0; i < ControllDetails.length; i++) {
                if (ControllDetails[i].ObjectID == id) {
                    $("#" + ControllDetails[i].ObjectID).remove();
                    $("#" + ControllDetails[i].ObjectID + "_row").remove();
                    ControllDetails[i].Visibility = false;
                    break;
                }
            }
        });
    });
}