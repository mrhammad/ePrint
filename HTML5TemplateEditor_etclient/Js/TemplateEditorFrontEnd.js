/**********************************
Global Variables(Craeted By: Infomaze)
***********************************/

var textCanvasHeight;
var textCanvasWidth;
var SitePhysicalPath, SitePath, FontPath, BackgroundImagesPath, WebMethodsPath, mainSitePath, DBKey, ImageUploadPath, FrontEndImagePath, B2BSitePath, PublicSitePath, CType, AccountID;
var SecurePath;
var mmConvertionConstant = 3.779527559;
var ptConvertionConstant = 0.75;
var selectedControllID, selectedObjectID = "";
var TemplateDetails, ControllDetails, PageViewed = [];
var CropMarkHeight = 0, CropMarkWidth = 0;
var ImagePath, FocusID = "";
var DropDownContactList, DropDownDepartmentList, DropDownAddressList, DropDownPhraseList;
var TemplateID, SesionID, UserID, CartitemID, CompanyID, ServicePath, ProductName, PriceCatalogId;
var VerticalGroupingData = null, HorizontalGroupingData = null;
var Textheight = 4, ImageHeight = 26.45833, ParaHeight = 13.23, filelist = "", totalSize = 0, FrontEndDocumentPath, FrontEndUploadPath, PDFAPIPath, imagecount = 0, imageloadedcount = 0;
var ListForMoveUp = [], ListForMoveDown = [], ListForKeepLeft = [], ListForKeepRight = [], OriginalGroupPositionByGroupID = [], GroupControls = [], File = [];
var DateFormat = "dd/mm/yyyy";
var span;
var tabIndex = 1;
/**********************************
Page Load Events(Craeted By: Infomaze)
***********************************/

/*Function that executes first when document is ready*/
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

                SecurePath = SitePaths.d.SecurePath;

                if (CType == "public" || CType.indexOf("public") > -1) {
                    B2BSitePath = PublicSitePath;
                }

                PDFAPIPath = SitePaths.d.PDFAPIPath;

                loadAccountDetails();
                loadHorizontalGroupingData();
                loadVerticalGroupingData();
                loadPopups();
                loadPage();
                
                setTimeout(function () {
                    $("#ruler").css({ 'height': $("#LayoutCanvas").innerHeight() + 15 + 'px', 'width': $("#LayoutCanvas").innerWidth() + 'px', 'overflow': 'hidden', 'z-index': '1' });
                    $('#ruler').ruler({
                        arrowStyle: "line"
                    });
                    $('#ruler').hide();
                }, 500);
                

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

        BindMenuBarEvents();
        
    }
});
function setTabIndex()
{
    $(".customBtnDiv").each(function () {
        var element = $(this);
        if (element.is(":visible"))
        {
            element.attr("tabindex", tabIndex++);
        }
    });
    
}

//function pageLoadCompleteEvents() {

  //  debugger
    //if ($("#loading").is(":visible")) {
      //  setTimeout(function () { pageLoadCompleteEvents(); }, 100);
    //} else {
      //  $("table#LeftPanelControl select").change();
    //}
//}
//$(document).ajaxStop(function () {
    // place code to be executed on completion of last outstanding ajax call here

  //  pageLoadCompleteEvents();

//});

/*Load Jquery Ui popups*/
function loadPopups() {
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
                if (FocusID != "") {
                    $("#" + FocusID).focus();
                }
                $(this).dialog("close");
                $(".QuickAdjustloadingNewMask").hide();
                $(".ui-front").hide();
                // $(this).dialog('destroy').detach();//added By shahbaz for hiding dailog overlay as its not hiding on close
            }
        },
        close: function () {

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
        },
        close: function () {
            $(".UploadFileloadingNewMask").css('z-index', '104').hide();
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
        open: function () {
            File = [];
            ParentCategoryIDs = [];
            $('#multipleFileUpload').val("");
            $("#btnuploadtxt").html("Browse");
            $("#btnSelectFiles").css({ 'width': '45px', 'margin-left': '275px' });
        },
        close: function () {
            File = [];
            ParentCategoryIDs = [];
            $("#btnuploadtxt").html("Browse");
            $("#btnSelectFiles").css({ 'width': '45px', 'margin-left': '275px' });
            $("#multipleFileUpload").val("");
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
            //$(".loadingNewMask").hide();
            $(".QuickAdjustloadingNewMask").css('z-index', '102').hide();
            $(".btnUpdateImageloading").hide();
            $(".btnUpdateImage").show();
        }

    });

    $("#ImageDetails").dialog({
        autoOpen: false,
        height: 400,
        resizable: false,
        width: 650,
        modal: true,
        close: function () {
            $(".loadingNewMask").css('z-index', '102').hide();
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



    //$("#Imageeditor1").dialog({
    //    effect: "clip",
    //    autoOpen: false,
    //    resizable: false,
    //    height: 575,
    //    width: 870,
    //    modal: true,
    //        buttons: {
    //            "Save & Close": function () {



    ////                var Control;
    ////                ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    ////                originalFilename = Control.OrignalImageName;


    ////                var obj = GetEditor();

    ////                $(".loading_new").show();

    ////                var filecounter = 0;


    ////                var array = originalFilename.split('.');
    ////                var GUID = Guid();
    ////                originalFilename = array[0] + "-" + GUID.substr(0, 3) + "." + array[1];

    ////                var arry = originalFilename.split('.');
    ////               
    ////                obj.saveImageOnServer(originalFilename, true);
    ////                
    ////                
    ////                $(this).dialog("close");
    ////                setTimeout(function () { FitTheEditedImageToControl(originalFilename) }, 5000);

    //            },
    //            "Save as New & Close": function () {
    ////                var Control;
    ////                ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    ////                originalFilename = Control.OrignalImageName;



    ////                var obj = GetEditor();
    ////                $(".loading_new").show();

    ////                var filecounter = 0;

    ////                var tmpImg = new Image();
    ////                var array = originalFilename.split('.');
    ////                var GUID = Guid();
    ////                originalFilename = array[0] + "-" + GUID.substr(0, 3) + "." + array[1];

    ////                obj.saveImageOnServer(originalFilename, true);
    ////                $(this).dialog("close");
    ////                setTimeout(function () { FitTheEditedImageToControl(originalFilename) }, 5000);
    //            }
    //        }

    //});








    designMessageBox();

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
}

/*Loading the page details*/
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

            $("#canvasLoading").css({ 'height': $("#editor").outerHeight() + "px", 'width': $("#editor").outerWidth() + 10 + "px" });
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
                if (TemplateDetails.PreviewType.toString().toLowerCase() == "img") {
                    $("#btnpreview").html("Image Preview");
                } else {
                    $("#btnpreview").html("PDF Preview");
                }
            }

            var zoomTemp = TemplateDetails.ZoomPercent / 100;

            if (CType == "public" || CType.indexOf("public") > -1) {
                //   $("#Menubar").css('width', '715px');



                //             alert(TemplateDetails.PageWidth);
                //             alert(TemplateDetails.PageHeight);
                //             alert(TemplateDetails.ZoomPercent);

                if (TemplateDetails.ZoomPercent > 200) {
                    zoomTemp = 150.00 / 100.00;
                }
                else {
                    if (TemplateDetails.PageWidth > 700 || TemplateDetails.PageHeight > 800) {
                        zoomTemp = zoomTemp / 2.0;
                    }
                }

               // zoomTemp = 1;// By gaj on request of Gordon
                //Commented By Amin for ticket # 10342
                // Added by Ved


                $("#lblEdit").css({ 'padding': '10px 0px 10px 14px' });
                $("#LeftPanelControl").css({ 'padding': '5px 18px 10px 12px', 'width': '210px' });
                $("#menutabletdpostionXYtd").css({ 'width': '183px' });
                $("#vline").css({ 'margin-left': '0px', 'margin-right': '0px' });
                $("#MainDesigncanvas").css({ 'margin-top': '-7px' });
                $("#LeftPanel").css({ 'Padding': '15px 0px' });
                $("#Menubar").css({ 'height': '102px' });
                $("#Menubar").css({ 'margin-left': '0px', 'margin-right': '0px' });
                $("#Maincanvas").css({ 'margin-left': '-4px', 'margin-top': '-4px' });




                if (TemplateDetails.ShowEdiotr == true) {
                    $("#menubartdtable").css({ 'margin-left': '-1px', 'width': '821px' });
                    $("#LayoutCanvas").css({ 'margin-left': '-1px' });
                }
                else {
                    $("#menubartdtable").css({ 'margin-left': '-1px', 'width': '650px' });
                    $("#LayoutCanvas").css({ 'margin-left': '-1px', 'padding': '3px 0px 3px 0px' });
                }


                //Need to do on main site
                // ctl00_ContentPlaceHolder1_div_expandBtn    margin-right: -20px;
                // .editableProduct_Iframe   padding: 0px 0px;

                // End Ved





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

                textCanvasHeight = TemplateDetails.PageHeight - (2 * CropMarkHeight * mmConvertionConstant);
                textCanvasWidth = TemplateDetails.PageWidth - (2 * CropMarkWidth * mmConvertionConstant);

                //textCanvasHeight = (TemplateDetails.ZoomY / zoomTemp) - ((TemplateDetails.ZoomY / 100) * CropMarkHeight) + CropMarkHeight / 4;
                // textCanvasWidth = (TemplateDetails.ZoomX / zoomTemp) - ((TemplateDetails.ZoomX / 100) * CropMarkWidth) + CropMarkWidth / 2;
            }
            else {
                textCanvasHeight = TemplateDetails.PageHeight;
                textCanvasWidth = TemplateDetails.PageWidth;
            }

            $("#textCanvas").css('width', textCanvasWidth + "px");
            $("#textCanvas").css('height', textCanvasHeight + "px");
            var imagepath = BackgroundImagesPath + TemplateDetails.ImageName;

            if (TemplateDetails.CropedImageName != "") {
                imagepath = BackgroundImagesPath + TemplateDetails.CropedImageName;
            }

            ImagePath = imagepath;
            $("#textCanvas").css('background-image', "url('" + imagepath + "')")
            $("#textCanvas").css('overflow', "hidden");

            var mainCanWidth = textCanvasWidth * zoomTemp;
            var maincanheight = textCanvasHeight * zoomTemp;
            $("#Maincanvas").css('width', mainCanWidth + 'px');
            $("#Maincanvas").css('height', maincanheight + 'px');
            var ZoomIn = zoomTemp;
            zoomTextCanvas(ZoomIn, true);
            $("#lbltotalpages").html(TemplateDetails.Totalpage);
            $("#lblcurrentpage").html('1');
            loadFontStyeDropDowns();

            var bbb = decodeURIComponent(document.referrer.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent("OrderId").replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));


            if (bbb != "") {
                $("#divMainButtons").hide();
                $("#divSaveAndApprove").show();
            } else {
               
            }

            
            for (var i = 0; i < TemplateDetails.Totalpage; i++) {
                var prop = JSON.parse(JSON.stringify({
                    "PageNumber": i + 1,
                    "IsViewed": false
                }));
                PageViewed.push(prop);
            }

        },
        error: function (xhr, status, error) {

            //alert(status);
        }
    });
}

/*Loading the font and color style list for dropdowns*/
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

                LoadColorStyleDropDown();
            };
            $.ajax(loadFont);
        }
    };
    $.ajax(loadFontStyle);
}

function LoadColorStyleDropDown() {
    var loadColorStyle = {};
    loadColorStyle.url = ServicePath + "GetColorStyleDetailProperties";
    loadColorStyle.type = "POST";
    loadColorStyle.data = JSON.stringify({ companyid: CompanyID, _key: DBKey });
    loadColorStyle.dataType = "json";
    loadColorStyle.processData = false;
    loadColorStyle.contentType = "application/json; charset=utf-8";
    loadColorStyle.success = function (ColorStyle) {
        ColorStyleDetails = JSON.parse(JSON.stringify(ColorStyle.d));
        loadFontDropDowns();
    };
    $.ajax(loadColorStyle);
}

/*Loading the controlls on the canvas on page load*/
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
        //21/03/2016 Update
        //postionControlsGroupWise();
        getGroupControl();
        var ChangePage = false;
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

            PageViewed.map(function (proj) { if (proj.PageNumber == 1) proj.IsViewed = true; });
        }
        else {
            ChangePage = true;
        }
        setTimeout(function () {
            listOfPositionForMoveUp();
            listOfPositionForMoveDown();
            listOfPositionForKeepRight();
            listOfPositionForKeepLeft();

            if (ChangePage) {
                changeThePageFromNavigation(2, true);
                ChangePage = false;
            }
            postionControlsGroupWise(true);
            $("#loading").hide();
            $(".loading_new").css('height', $("body").css('height'));

            //21/03/2016 Update
            ////For Loading Other page Content on pageload
            //
            //var ControllDetailsByPage = [];
            //if (TemplateDetails.Totalpage >= 2) {
            //    for (var i = 2; i <= TemplateDetails.Totalpage; i++) {
            //        ControllDetails.map(function (proj) { if (proj.PageNumber == i) ControllDetailsByPage.push(proj) });
            //        if (ControllDetailsByPage.length > 0 && TemplateDetails.ShowEditablePages == false) {
            //            setTimeout(function () { changeThePageFromNavigation(i, false); }, 1000);
            //            if (i == TemplateDetails.Totalpage) {
            //                setTimeout(function () {
            //                    changeThePageFromNavigation(1, false);
            //                    postionControlsGroupWise();
            //                    $("#loading").hide();
            //                    $(".loading_new").css('height', $("body").css('height'));
            //                }, 2000);
            //            }
            //        }
            //    }
            //}
            //else {
            //    postionControlsGroupWise();
            //    $("#loading").hide();
            //    $(".loading_new").css('height', $("body").css('height'));
            //}
        }, 2000);
        //}
        //else {
        //    loadPage();
        //}
      
    },
    loadControlls.complete = function(){
        setTabIndex();
    };
    $.ajax(loadControlls);
 
}

/*Loading the list for other dropdowns*/
function loadFontDropDowns() {
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
            loadContactDataDropDown();
        }
    });
}

function loadContactDataDropDown() {

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
            loadDepartmentDataDropDown();
        }
    });

}

function loadDepartmentDataDropDown() {

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
            loadAddressDataDropDown();
        }
    });
}

function loadAddressDataDropDown() {

    $.ajax({
        url: ServicePath + "LoadDataBaseContentsAddress",
        type: "POST",
        data: JSON.stringify({ userid: UserID, cartitemid: CartitemID, type: "Address", _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (address) {
            DropDownAddressList = JSON.parse(JSON.stringify(address.d));
            loadPhraseDataDropDown();
        }
    });
}

function loadPhraseDataDropDown() {
    $.ajax({
        url: ServicePath + "LoadDataBasePhraseTextForDropDowns",
        type: "POST",
        data: JSON.stringify({ Companyid: CompanyID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (phrase) {
            DropDownPhraseList = JSON.parse(JSON.stringify(phrase.d));
            loadcategoryList("");
            loadcontrolls();
        }
    });

}

/*Binding the font dropdown*/
function loadFontDropdown(fontName, fontFilePath, FontID, ActualFontName, id, selcted) {
    if (selcted == "none") {
        $(id).append("<option value='" + fontFilePath + "~" + FontID + "~" + ActualFontName + "~" + fontName + "' id='drpFontID" + FontID + "' >" + fontName + "</option>");
    }
}

/*Loading the category list for dropdown*/
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

/*Binding the Image Category Dropdowns*/
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

/*Load the Horizontal Grouping Data List*/
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

/*Load the Vertical Grouping Data List*/
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

function loadAccountDetails() {
    $.ajax({
        url: ServicePath + "LoadUserAccountDetails",
        type: "POST",
        data: JSON.stringify({ CompanyID: CompanyID, AccountID: AccountID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (_DateFormat) {

            if (_DateFormat.d != null && _DateFormat.d != "")
                DateFormat = _DateFormat.d;
        }
    });

}
/**********************************
Common Methods(Craeted By: Infomaze)
***********************************/
/*Bind Events For Controls*/
function functionalities(PositionLock, objectID, text) {
    //added by shahbaz to hide scroll if canvas height n Width is less than editor height n Width
    if ($("#Maincanvas").height() < $("#editor").height() && $("#Maincanvas").width() < $("#editor").innerWidth())
        $("#LayoutCanvas").css("overflow", 'hidden')
    if (PositionLock == false) {
        $(function () {
            $("#" + objectID).draggable({
                drag: function (evt, ui) {
                    ui.position.top = ui.position.top / zoom;
                    ui.position.left = ui.position.left / zoom;

                    //Added BY shahbaz if control is Rotated
                    if ($(this).hasClass("Text")) {
                        var RotateDegree = parseInt($("#txtRotate").val());
                        if (RotateDegree > 0 && RotateDegree < 360) {
                            var TextWidth = ui.helper[0].offsetWidth, TextHeight = ui.helper[0].offsetHeight
                            var PositionX = getWidthOfRotatedTextParaControl(RotateDegree, TextWidth, TextHeight);
                            var PositionY = getHeightOfRotatedTextParaControl(RotateDegree, TextHeight, TextWidth, this);
                            if (RotateDegree < 95) {
                                ui.position.top = ui.position.top + PositionY;
                                ui.position.left = ui.position.left + PositionX;
                            }
                            else if (RotateDegree <= 180) {

                                ui.position.top = ui.position.top + PositionY;
                                if (RotateDegree == 180)
                                    ui.position.top = ui.position.top + PositionY - TextHeight;
                                if (RotateDegree <= 110)
                                    ui.position.left = ui.position.left + TextHeight + PositionX;
                                else
                                    ui.position.left = ui.position.left + PositionX;
                            }
                            else if (RotateDegree <= 270) {
                                ui.position.top = ui.position.top - TextHeight;
                                if (RotateDegree <= 210)
                                    ui.position.left = ui.position.left + TextWidth - PositionX;
                                else if (RotateDegree <= 265)
                                    ui.position.left = ui.position.left + PositionX;
                                else
                                    ui.position.left = ui.position.left;
                            }
                            else if (RotateDegree <= 340) {
                                ui.position.top = ui.position.top - (TextHeight - PositionY);
                            }

                            //if (RotateDegree < 70) {
                            //    var x = getHeightofRotatedDiv(RotateDegree, ui.helper[0].offsetWidth);
                            //    ui.position.top = (ui.position.top + x * mmConvertionConstant)
                            //}
                            //else if (RotateDegree >= 70 && RotateDegree <= 85) {
                            //    RotateDegree = 60
                            //    var x = getHeightofRotatedDiv(RotateDegree, ui.helper[0].offsetWidth);
                            //    ui.position.top = (ui.position.top + x * mmConvertionConstant)
                            //}
                            //else if (RotateDegree == 90) {
                            //    ui.position.top = (ui.position.top + ui.helper[0].offsetWidth)
                            //}
                            //else {
                            //    var y = getWidthofRotatedDiv(RotateDegree, ui.helper[0].offsetWidth);
                            //    var x = getHeightofRotatedDiv(RotateDegree, ui.helper[0].offsetWidth, y * mmConvertionConstant);
                            //    if (RotateDegree <= 180) {
                            //        ui.position.top = (ui.position.top + x * mmConvertionConstant);
                            //        ui.position.left = (ui.position.left + y * mmConvertionConstant);
                            //    }
                            //    else if (RotateDegree <= 270) {
                            //        deg = RotateDegree - 180;
                            //        if (RotateDegree > 220)
                            //            ui.position.top = (ui.position.top - (ui.helper[0].offsetWidth - x * mmConvertionConstant));
                            //        else
                            //            ui.position.top = (ui.position.top - deg);
                            //        ui.position.left = (ui.position.left + y * mmConvertionConstant);
                            //    }
                            //}
                        }
                    }


                    if ($(this).hasClass("Para")) {
                        var RotateDegree = parseInt($("#txtRotate").val());
                        if (RotateDegree > 0 && RotateDegree < 360) {
                            var ParaWidth = ui.helper[0].offsetWidth, ParaHeight = ui.helper[0].offsetHeight
                            var PositionX = getWidthOfRotatedTextParaControl(RotateDegree, ParaWidth, ParaHeight);
                            var PositionY = getHeightOfRotatedTextParaControl(RotateDegree, ParaHeight, ParaWidth, this);
                            if (RotateDegree < 95) {
                                ui.position.top = ui.position.top + PositionY;
                                ui.position.left = ui.position.left + PositionX;
                            }
                            else if (RotateDegree <= 180) {

                                ui.position.top = ui.position.top + PositionY;
                                if (RotateDegree == 180)
                                    ui.position.top = ui.position.top + PositionY - ParaHeight;
                                if (RotateDegree <= 110)
                                    ui.position.left = ui.position.left + ParaHeight + PositionX;
                                else
                                    ui.position.left = ui.position.left + PositionX;
                            }
                            else if (RotateDegree <= 270) {
                                ui.position.top = ui.position.top - ParaHeight;
                                if (RotateDegree <= 210)
                                    ui.position.left = ui.position.left + ParaWidth - PositionX;
                                else if (RotateDegree <= 265)
                                    ui.position.left = ui.position.left + PositionX;
                                else
                                    ui.position.left = ui.position.left;
                            }
                            else if (RotateDegree <= 340) {
                                ui.position.top = ui.position.top - (ParaHeight - PositionY);
                            }

                        }
                    }


                    if ($(this).hasClass("Image")) {
                        var RotateDegree = parseInt($("#txtRotate").val());
                        if (RotateDegree > 0 && RotateDegree < 360) {
                            //var ActualPosition = getActaulHeightOfRotatedControl(this, RotateDegree);

                            var PositionX = getWidthOfRotatedRectangularDiv(RotateDegree, ui.helper[0].offsetWidth, ui.helper[0].offsetHeight);
                            var PositionY = getHeightofRotatedRectangularDiv(RotateDegree, ui.helper[0].offsetWidth, PositionX, ui.helper[0].offsetHeight, this)

                            // var newWidth = ActualPosition[0];
                            // var newHeight = ActualPosition[1];

                            if (RotateDegree < 90) {
                                ui.position.top = ui.position.top + PositionY;
                                ui.position.left = ui.position.left + PositionX;
                            }
                            else if (RotateDegree == 90) {
                                ui.position.top = ui.position.top + PositionY;
                                ui.position.left = ui.position.left + ui.helper[0].offsetHeight;
                            }
                            else if (RotateDegree <= 110) {
                                ui.position.top = ui.position.top + PositionY;
                                ui.position.left = ui.position.left + (ui.helper[0].offsetHeight + PositionX);
                            }
                            else if (RotateDegree <= 180) {
                                if (RotateDegree <= 135)
                                    ui.position.top = ui.position.top + PositionY;
                                else
                                    ui.position.top = ui.position.top + PositionY;
                                ui.position.left = ui.position.left + PositionX//(ui.helper[0].offsetHeight + PositionX);
                            }
                            else if (RotateDegree <= 270) {
                                ui.position.top = ui.position.top - ui.helper[0].offsetWidth;
                                if (RotateDegree < 240)
                                    ui.position.left = ui.position.left + (ui.helper[0].offsetHeight);
                                    //else if (RotateDegree <= 240)
                                    //    ui.position.left = ui.position.left - PositionX;
                                else if (RotateDegree <= 250)
                                    ui.position.left = ui.position.left - (ui.helper[0].offsetHeight - PositionX);
                                else
                                    ui.position.left = ui.position.left;
                            }
                            else if (RotateDegree <= 310) {
                                ui.position.top = ui.position.top - (ui.helper[0].offsetHeight + PositionY);
                                //ui.position.left = ui.position.left + (ui.helper[0].offsetHeight);
                            }
                        }
                    }



                    getPosition();
                    //$("#" + selectedObjectID).css({ 'height': controlheight + "px" });
                },
                stop: function (evt, ui) {
                    getPosition();
                },
                scroll: true,
                cursor: "move",
                containment: "#Maincanvas",
                scrollSensitivity: 100
            });

            /*Added By Shahbaz*/
            if ($("#" + objectID).hasClass('Text')) {
                $("#" + objectID).resizable({
                    handles: 'e,w',
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
                    },
                    minWidth: 30,
                });
            } else {
                //$("#" + objectID).resizable({
                //    handles: 'e,w,n,s',
                //    resize: function (evt, ui) {
                //        var changeWidth = ui.size.width - ui.originalSize.width;
                //        var changeHeight = ui.size.height - ui.originalSize.height;

                //        var newWidth = ui.originalSize.width + changeWidth / zoom;
                //        var newHeight = ui.originalSize.height + changeHeight / zoom;

                //        ui.originalElement.width(newWidth);
                //        ui.originalElement.height(newHeight);

                //        if ($(this).hasClass('Para') || $(this).hasClass('Text')) {
                //            resizeTextPara();
                //        }
                //        else if ($(this).hasClass('Image')) {
                //            resizeImage(); 
                //        }
                //    },

                // });
            }


            $("#" + objectID).mousedown(function () {
                deSelect();
                $(this).css('border', '1px dashed #808080');
                $(this).css('cursor', 'pointer');
                changeSelectedControllID();
            })

            var Actualtop = 0;
            var init = false;

            if ($("#" + objectID).hasClass('Image')) {
                $("#" + objectID).resizable({
                    handles: 'e,w,n,s',
                    resize: function (evt, ui) {
                        if (ui.originalPosition.top == 0 && init) {
                            $(this).css('top', Actualtop);
                            ui.originalPosition.top = Actualtop;
                        }

                        var changeWidth = 0, changeHeight = 0
                        if (ui.position.left == ui.originalPosition.left) {
                            changeWidth = ui.size.width - ui.originalSize.width;
                            var newWidth = ui.originalSize.width + changeWidth / zoom;
                            ui.originalElement.width(newWidth);
                        }

                        if (ui.position.top == ui.originalPosition.top) {
                            changeHeight = ui.size.height - ui.originalSize.height;
                            var newHeight = ui.originalSize.height + changeHeight / zoom;
                            ui.originalElement.height(newHeight);
                        } else {
                            if (ui.size.height < ui.originalSize.height) {
                                changeHeight = ui.originalSize.height - ui.size.height;
                                var newHeight = ui.originalSize.height - changeHeight;
                                ui.originalElement.height(newHeight);
                            }
                        }

                        if ($(this).hasClass('Para')) {
                            resizeTextPara();
                        }
                        else if ($(this).hasClass('Image')) {
                            resizeImage();
                        }
                        alignsingleImage($(this).attr('id'));
                        init = false;
                    },
                    start: function (evt, ui) {
                        $(this).css('top', ui.element[0].offsetTop);
                        Actualtop = ui.element[0].offsetTop;
                    },
                    containment: "#textCanvas",
                });
            }


            if ($("#" + objectID).hasClass('Para')) {
                $("#" + objectID + " .paraText").css("width", '100%')
                $("#" + objectID).resizable({
                    handles: 'e,w,n,s',
                    resize: function (evt, ui) {
                        if (ui.originalPosition.top == 0 && init) {
                            $(this).css('top', Actualtop);
                            ui.originalPosition.top = Actualtop;
                        }

                        var changeWidth = 0, changeHeight = 0
                        if (ui.position.left == ui.originalPosition.left) {
                            changeWidth = ui.size.width - ui.originalSize.width;
                            var newWidth = ui.originalSize.width + changeWidth / zoom;
                            ui.originalElement.width(newWidth);
                        }

                        if (ui.position.top == ui.originalPosition.top) {
                            changeHeight = ui.size.height - ui.originalSize.height;
                            var newHeight = ui.originalSize.height + changeHeight / zoom;
                            ui.originalElement.height(newHeight);
                        } else {
                            if (ui.size.height < ui.originalSize.height) {
                                changeHeight = ui.originalSize.height - ui.size.height;
                                var newHeight = ui.originalSize.height - changeHeight;
                                ui.originalElement.height(newHeight);
                            }
                        }

                        if ($(this).hasClass('Para')) {
                            resizeTextPara();
                        }
                        else if ($(this).hasClass('Image')) {
                            resizeImage();
                        }
                        alignsingleImage($(this).attr('id'));
                        init = false;
                    },
                    start: function (evt, ui) {
                        $(this).css('top', ui.element[0].offsetTop);
                        Actualtop = ui.element[0].offsetTop;
                    },
                    containment: "#textCanvas",
                    minWidth: 30,
                    minHeight: 15
                });
            }


        });
    }
    $(document).ready(function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == objectID) Control = proj });

        $(".Image").unbind('dblclick').bind('dblclick', function () {
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
            // if (Control.IsFromPdf == false) {
            if (Control.Edit == true) {
                if (!Control.AllowImageEdit) {
                    //Do nothings
                }
                else if (Control.IsFromPdf == false) {
                    var userImagePath = "", systemImagePath = "", noImagePath = "";

                    var image = Control.OrignalImageName, ImagePath;
                    //if (Control.EditedImageName != "")
                    //    image = Control.EditedImageName;
                    //Control.OrignalImageName = image;
                    //var image = Control.ImgUrl, ImagePath;  // To Show last cropped image by Gaj

                    systemImagePath = BackgroundImagesPath + "Gallery/OriginalImages/" + image;
                    if (image == "noimage.png" || image == "noimage.jpg" || image == "") {
                        noImagePath = SiteImages + "noimage.jpg";
                    }

                    if (Control.IsFromBackEnd == false) {
                        userImagePath = FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + image;
                    }
                    orgWidthCrop = parseInt(Control.Width * mmConvertionConstant);
                    orgHeightCrop = parseInt(Control.Height * mmConvertionConstant);

                    $("#Imageeditor1").css({ 'overflow-x': 'hidden' });
                    checkForOriginalFile(userImagePath, systemImagePath, noImagePath, image);
                }
            }
        });

        //For Dragging and resizing control- changed & added by shahbaz
        $(".Text").mousedown(function () {

            if ($(this).hasClass('ui-draggable')) {
                deSelect();
                // var id = $(this).parent().attr('id');
                var id = $(this).attr('id');
                var posXValue = (($("#" + id + " .labelText").position().left) - 2) / mmConvertionConstant;
                $(this).css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });

                var leftPanelid = "#" + id + "_txt";
                $(leftPanelid).css('background-color', 'rgba(233, 245, 248,255)');
                changeSelectedControllID();
                bindMenuBar(selectedObjectID);
                //  setTimeout(function () { $(leftPanelid).focus() }, 100); commented by shahabaz
            }
        });

        $(".Para").mousedown(function () {
            debugger;
            if ($(this).hasClass('ui-draggable')) {
                deSelect();
                ///  var id = $(this).parent().attr('id');
                var id = $(this).attr('id');
                $(this).css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });

                var leftPanelid = "#" + id + "_txt";
                $(leftPanelid).css('background-color', 'rgba(233, 245, 248,255)');
                changeSelectedControllID();
                bindMenuBar(selectedObjectID);
                // setTimeout(function () { $(leftPanelid).focus() }, 100); commented by shahabaz
            }

        });

        $(".Image").mousedown(function () {
            deSelect();
            $(this).css('border', '1px solid #B2B2B2');
            $(this).css('cursor', 'pointer');
            changeSelectedControllID();
            bindMenuBar(selectedObjectID);
        });

        $(".Text .labelText").mousedown(function () {
            if (!$(this).parent().hasClass('ui-draggable')) {
                deSelect();
                // var id = $(this).parent().attr('id');
                var id = $(this).parent().attr('id');
                //var posXValue = (($("#" + id + " .labelText").position().left) - 2) / mmConvertionConstant;
                $(this).css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });

                var leftPanelid = "#" + id + "_txt";
                $(leftPanelid).css('background-color', 'rgba(233, 245, 248,255)');
                $("#dropdownTxt_" + id).css('background-color', 'rgba(233, 245, 248,255)');
                changeSelectedControllID();
                bindMenuBar(selectedObjectID);
                //  setTimeout(function () { $(leftPanelid).focus() }, 100); commented by shahabaz
            }
        });

        $(".Para pre").mousedown(function () {
            if (!$(this).parent().hasClass('ui-draggable')) {
                deSelect();
                ///  var id = $(this).parent().attr('id');
                var id = $(this).parent().attr('id');
                $(this).css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });

                var leftPanelid = "#" + id + "_txt";
                $(leftPanelid).css('background-color', 'rgba(233, 245, 248,255)');
                $("#dropdownTxt_" + id).css('background-color', 'rgba(233, 245, 248,255)');
                changeSelectedControllID();
                bindMenuBar(selectedObjectID);
                // setTimeout(function () { $(leftPanelid).focus() }, 100); commented by shahabaz
            }
        });

        $(".Image").mousedown(function () {
            deSelect();
            $(this).css('border', '1px solid #B2B2B2');
            $(this).css('cursor', 'pointer');
            changeSelectedControllID();
            bindMenuBar(selectedObjectID);
        });

        $(".Text").unbind('mouseenter').bind('mouseenter', function () {
            if ($(this).hasClass('ui-draggable')) {
                var id = $(this).attr("id");
                if ($("#" + id + "_txt").val() != "") {
                    if ($(this).css('border-right-color') == "transparent") {
                        $(this).css('border', '1px dashed rgb(128, 128, 129)');
                    }
                    if ($(this).css('border-right-color') == "rgba(0, 0, 0, 0)") {
                        $(this).css('border', '1px dashed rgb(128, 128, 129)');
                    }
                }
            } else {
                $(this).css('cursor', 'default')
            }


        });

        $(".Text .labelText").unbind('mouseenter').bind('mouseenter', function () {
            if (!$(this).parent().hasClass('ui-draggable')) {
                if ($(this).css('border-right-color') == "transparent") {
                    $(this).css('border', '1px dashed rgb(128, 128, 129)');
                }
                if ($(this).css('border-right-color') == "rgba(0, 0, 0, 0)") {
                    $(this).css('border', '1px dashed rgb(128, 128, 129)');
                }
                $(this).css('cursor', 'pointer')
            } else {
                $(this).css('cursor', 'pointer')
            }


        });

        $(".Para").unbind('mouseenter').bind('mouseenter', function () {
            if ($(this).hasClass('ui-draggable')) {
                if ($(this).css('border-right-color') == "transparent") {
                    $(this).css('border', '1px dashed rgb(128, 128, 129)');
                }
                if ($(this).css('border-right-color') == "rgba(0, 0, 0, 0)") {
                    $(this).css('border', '1px dashed rgb(128, 128, 129)');
                }
            }
            else {
                $(this).css('cursor', 'default')
            }

        });

        $(".Para pre").unbind('mouseenter').bind('mouseenter', function () {
            if (!$(this).parent().hasClass('ui-draggable')) {
                if ($(this).css('border-right-color') == "transparent") {
                    $(this).css('border', '1px dashed rgb(128, 128, 129)');
                }
                if ($(this).css('border-right-color') == "rgba(0, 0, 0, 0)") {
                    $(this).css('border', '1px dashed rgb(128, 128, 129)');
                }
                $(this).css('cursor', 'pointer')
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

        $(".Text").unbind('mouseleave').bind('mouseleave', function () {

            if ($(this).hasClass('ui-draggable')) {
                if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).css('border', '1px dashed transparent');
                }
                if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).css('border', '1px dashed rgba(0, 0, 0, 0)');
                }
            } else {
                if ($(this).children().css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).children().css('border', '1px dashed transparent');
                }
                if ($(this).children().css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).children().css('border', '1px dashed transparent');
                }
            }

        });

        $(".Para").unbind('mouseleave').bind('mouseleave', function () {
            if ($(this).hasClass('ui-draggable')) {
                if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).css('border', '1px dashed transparent');
                }
                if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).css('border', '1px dashed rgba(0, 0, 0, 0)');
                }
            }
        });

        $(".Text .labelText").unbind('mouseleave').bind('mouseleave', function () {
            if (!$(this).parent().hasClass('ui-draggable')) {
                if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).css('border', '1px dashed transparent');
                }
                if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).css('border', '1px dashed rgba(0, 0, 0, 0)');
                }
            }
        });

        $(".Para pre").unbind('mouseleave').bind('mouseleave', function () {
            if (!$(this).parent().hasClass('ui-draggable')) {
                if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).css('border', '1px dashed transparent');
                }
                if ($(this).css('border-right-color') == "rgb(128, 128, 129)") {
                    $(this).css('border', '1px dashed rgba(0, 0, 0, 0)');
                }
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

        $("img").unbind('error').bind('error', function () {
            var id = $($(this).parent()).attr("id");
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
            if (Control != null) {
                if (Control.BackgroundImage != "") {
                    $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                    Control.BackgroundImage = "noimage.jpg";
                }
                else
                    $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'position': 'absolute', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });

                Control.OriginalImageName = "noimage.jpg";
                Control.ImgUrl = "noimage.jpg";
                Control.IsFromPdf = false;
                Control.EditedImageName = "";
                Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight() / mmConvertionConstant);
                Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth() / mmConvertionConstant);
                $("#" + Control.ObjectID + " img").attr('src', SiteImages + "noimage.jpg");
                alignsingleImage(Control.ObjectID);
                $(".loading_new").hide();
                $("#canvasLoading").hide();
            }
        });

        $("#chkShowGrid").unbind('click').bind('click', function () {
            if ($(this).prop('checked')) {
                //For Dispalying Major and Minor line on graph
                $("#ruler .stage").html("");
                var topDiv = $("#ruler .top ").find("div")
                var leftDiv = $("#ruler .left").find("div")
                var margin = 10;
                $("#ruler .stage").css({ 'width': $("#ruler").innerWidth(), 'height': $("#ruler").innerHeight() })
                for (var i = 0; i < topDiv.length; i++) {
                    if ($(topDiv[i]).hasClass("major")) {
                        $("#ruler .stage").append("<div style='height:100%;width:1px;background-color:#DCDCDC;margin-left:" + $(topDiv[i]).css('left') + ";position:absolute'></div>")
                    }
                    if ($(topDiv[i]).hasClass("minor")) {
                        $("#ruler .stage").append("<div style='height:100%;width:1px;background-color:#DCDCDC;margin-left:" + $(topDiv[i]).css('left') + ";position:absolute'></div>")
                    }
                }
                $("#ruler .stage div").last().remove();
                for (var i = 0; i < leftDiv.length; i++) {
                    if ($(leftDiv[i]).hasClass("major")) {
                        $("#ruler .stage").append("<div style='height:1px;width:100%;background-color:#DCDCDC;margin-top:" + $(leftDiv[i]).css('top') + ";position:absolute'></div>")
                    }
                    if ($(leftDiv[i]).hasClass("minor")) {
                        $("#ruler .stage").append("<div style='height:1px;width:100%;background-color:#DCDCDC;margin-top:" + $(leftDiv[i]).css('top') + ";position:absolute'></div>")
                    }
                }
                $("#ruler .stage div").last().remove();
                //End

                $("#ruler").show();
            } else
                $("#ruler").hide();
        });
    });
}

/*To Resize Para*/
function resizeTextPara() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var width = parseFloat($("#" + Control.ObjectID).outerWidth()) / mmConvertionConstant;
    var height = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;

    if (Control.Type == "Paragraph")
        $("#" + Control.ObjectID).css({ "min-width": '30px', 'min-height': '15px' })
    else
        $("#" + Control.ObjectID).css({ "min-width": '30px' })
    Control.Height = parseFloat(height).toFixed(4);
    Control.Width = parseFloat(width).toFixed(4);
    Control.MaxHeight = parseFloat(height).toFixed(4);
    Control.MaxWidth = parseFloat(width).toFixed(4);
    $("#" + Control.ObjectID + " .paraText").css("max-width", parseFloat(Control.Width) * mmConvertionConstant + "px")
    $("#txtMaxHeight").val(parseFloat(Control.Height).toFixed(4));
    $("#txtMaxWidth").val(parseFloat(Control.Width).toFixed(4));
    getPosition();
}

/*To Resize Image*/
function resizeImage(Function) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var width = parseFloat($("#" + Control.ObjectID).innerWidth()) / mmConvertionConstant;
    var height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;

    Control.Height = parseFloat(height).toFixed(4);
    Control.Width = parseFloat(width).toFixed(4);

    $("#" + Control.ObjectID).css({ 'line-height': ((parseFloat(Control.Height) * mmConvertionConstant) - 3) + 'px' });

    if (Control.ExceedImage == "P") {
        $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'inherit' });
        if ($("#" + Control.ObjectID).innerHeight() <= ($("#" + Control.ObjectID + " img").outerHeight())) {
            $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
            $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant)) + 'px' });
        }
        if ($("#" + Control.ObjectID).innerWidth() <= ($("#" + Control.ObjectID + " img").outerWidth())) {
            $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
            $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant)) + 'px' });
        }
    }
    if (Control.ExceedImage == "S") {
        $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant)) + 'px' });
        $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant)) + 'px' });
    }
    if (Control.ExceedImage == "D") {
        $("#" + Control.ObjectID + " img").css({ 'height': ((parseFloat(Control.Height) * mmConvertionConstant)) + 'px' });
        $("#" + Control.ObjectID + " img").css({ 'width': ((parseFloat(Control.Width) * mmConvertionConstant)) + 'px' });
    }
    Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
    Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
    getPosition();
    alignsingleImage(Control.ObjectID);
}

function BindMenuBarEvents() {
    $("#btnsavetodraftPopup").click(function () {
        $("#SaveDraftPopUp").dialog("close");
        $.ajax({
            url: ServicePath + "UpdateDesignName",
            type: "POST",
            data: JSON.stringify({ CartItemId: CartitemID, designname: $("#txtProductName").val(), _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (resultFromSevice) {

                $.ajax({
                    url: ServicePath + "UpdateSaveStatus",
                    type: "POST",
                    data: JSON.stringify({ CartItemId: CartitemID, PreviewType: TemplateDetails.PreviewType, _key: DBKey }),
                    dataType: "json",
                    processData: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (resultFromSevice) {
                        if (resultFromSevice.d) {
                            $(".loading_new").show();
                            $.ajax({
                                url: PDFAPIPath + "DetailsForPDF",
                                type: "POST",
                                data: JSON.stringify({ _accountid: AccountID, _cartitemid: CartitemID, _companyid: CompanyID, _pricecatid: PriceCatalogId, _templateid: TemplateID, _systemname: "", _hostname: "", dbkey: DBKey }),
                                //data: JSON.stringify({ _accountid: AccountID, _cartitemid: CartitemID, _companyid: CompanyID, _pricecatid: PriceCatalogId, _templateid: TemplateID, _systemname: "SystemName", _hostname: "HostName", dbkey: DBKey }),
                                dataType: "jsonp",
                                processData: false,
                                contentType: "application/json; charset=utf-8",
                                success: function (resultFromSevice) {

                                    //if (resultFromSevice.d) {
                                    //    var url = B2BSitePath + "my_design.aspx";
                                    //    window.top.location.href = url;
                                    //    $(".loading_new").hide();
                                    //}
                                },
                                async: true

                            });
                            setTimeout(function () {
                                var url = B2BSitePath + "my_design.aspx";
                                window.top.location.href = url;
                                $(".loading_new").hide();
                            }, 2000);

                        }
                    }
                });
            }
        });
    });
   
    $("#txtC,#txtM,#txtY,#txtK").unbind('keyup').bind('keyup', function () {
        changeColorByInputText();
    });
    $("#txtC,#txtM,#txtY,#txtK").unbind('change').bind('change', function () {
        changeColorByInputText();
    });

    $("#btnFontColor").unbind('click').bind('click', function () {
        if ($("#" + selectedObjectID).hasClass("Text") || $("#" + selectedObjectID).hasClass("Para")) {
            if ($("#fontColor").css('display') == "none") {
                $("#fontColor").show();
            }
            else {
                $("#fontColor").hide();
            }
        }
        else {
            $("#fontColor").hide();
        }
    });

    //$("body").click(function () {
    //    $("#fontColor").hide();
    //});

    $("#colorclose").click(function () {
        $("#fontColor").hide();
    });

    $("#chkSetImgAsBckgrnd").unbind('change').bind('change', function () {

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

    $("#rngslidesetzoom").change(function () {
        $(this).attr('title', $(this).val());
        var ZoomInPerCent = parseFloat($(this).val());
        var Zoom = ZoomInPerCent / 100.00;
        zoomTextCanvas(Zoom);
    });
    $("#txtZoom").keyup(function () {
        var ZoomInPerCent = parseFloat(isNaN($(this).val()) ? "0" : $(this).val());
        var Zoom = ZoomInPerCent / 100.00;
        zoomTextCanvas(Zoom);
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

    $("#btnfirstpage").unbind('click').bind('click', function () {
        var currentPage = parseInt($("#lblcurrentpage").html());
        if (currentPage != 1) {
            tabIndex = 1;
            changeThePageFromNavigation(1, true);
            setTabIndex();
            PageViewed.map(function (proj) { if (proj.PageNumber == 1) proj.IsViewed = true; });
        }
    });
    $("#btnnextpage").unbind('click').bind('click', function () {
        var currentPage = parseInt($("#lblcurrentpage").html());
        if (currentPage != TemplateDetails.Totalpage) {
            var Page = currentPage + 1;
            tabIndex = 1;
            changeThePageFromNavigation(Page, true);
            setTabIndex();
            PageViewed.map(function (proj) { if (proj.PageNumber == Page) proj.IsViewed = true; });
        }
    });
    $("#btnprevspage").unbind('click').bind('click', function () {
        var currentPage = parseInt($("#lblcurrentpage").html());
        if (currentPage != 1) {
            tabIndex = 1;
            var Page = currentPage - 1;
            changeThePageFromNavigation(Page, false);
            setTabIndex();
            PageViewed.map(function (proj) { if (proj.PageNumber == Page) proj.IsViewed = true; });

        }
    });
    $("#btnlastpage").unbind('click').bind('click', function () {
        var currentPage = parseInt($("#lblcurrentpage").html());
        if (currentPage != TemplateDetails.Totalpage) {
            tabIndex = 1;
            changeThePageFromNavigation(TemplateDetails.Totalpage, false);

            setTabIndex();
            PageViewed.map(function (proj) { if (proj.PageNumber == currentPage) proj.IsViewed = true; });
        }
    });

    $(".saveButton").unbind('click').bind('click', function () {

       
        if ($(this).attr('id') != "btnPrevious") {
            debugger;
            var mand = true;
            var valid = true;

            for (i = 0; i < ControllDetails.length; i++) {
                if (ControllDetails[i].Visibility == true && ControllDetails[i].Mandatory == true) {
                    mand = false;
                    if (ControllDetails[i].Type == "TextBlock" || ControllDetails[i].Type == "Paragraph") {
                        if (ControllDetails[i].DefaultContent.trim() == "" || (ControllDetails[i].ObjTag.trim() == "" && ControllDetails[i].PhraseType.trim() != "" && (ControllDetails[i].Dropdowns != 'None' && ControllDetails[i].Dropdowns != undefined))) {
                            valid = false;
                            $("#MandatoryMessage").dialog("open");
                            if (ControllDetails[i].Dropdowns != "None" && ControllDetails[i].DatabaseContent == "") {
                                $("#mandatorymsg").html("Please select <b>" + ControllDetails[i].FriendlyName + "</b>");
                            }
                            else if (ControllDetails[i].CustomFieldType.toLowerCase() == "date") {
                                $("#mandatorymsg").html("Please select <b>" + ControllDetails[i].FriendlyName + "</b>");
                            }
                            else {
                                $("#mandatorymsg").html("Please enter <b>" + ControllDetails[i].FriendlyName + "</b>");
                            }
                            $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
                            break;
                        }
                    }
                    else if (ControllDetails[i].Type == "Image") {
                        if (ControllDetails[i].ImgUrl == "noimage.png" || ControllDetails[i].ImgUrl == "noimage.jpg") {
                            valid = false;
                            $("#MandatoryMessage").dialog("open");
                            $("#mandatorymsg").html("Please add <b>" + ControllDetails[i].FriendlyName + "</b>");
                            $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
                            break;
                        }
                    }
                }
            }

            //$("#LeftPanelControl").find(".Mandatory").each(function () {s
            //    
            //    mand = false;
            //    var Tag = $(this).tagName;
            //    var arry = $(this).attr('id').split('_');
            //    if (Tag = "INPUT") {
            //        if ($(this).val() == "") {
            //            valid = false;
            //            $(".loading_new").hide();
            //            $("#MandatoryMessage").dialog("open");
            //            var FieldName;
            //            for (var i = 0; i < ControllDetails.length; i++) {
            //                if (ControllDetails[i].ObjectID == arry[0]) {
            //                    FieldName = ControllDetails[i].FriendlyName;
            //                    FocusID = $(this).attr('id');
            //                    break;
            //                }
            //            }
            //            //$("#mandatorymsg").html("Please enter <b>" + FieldName + "</b> Mandatory Control");
            //            $("#mandatorymsg").html("Please enter <b>" + FieldName + "</b>");
            //            designMessageBox();
            //        }
            //    }
            //    else if (Tag = "SELECT") {
            //        if ($(this).val() == "0") {
            //            valid = false;
            //            $(".loading_new").hide();
            //            $("#MandatoryMessage").dialog("open");
            //            var FieldName;
            //            for (var i = 0; i < ControllDetails.length; i++) {
            //                if (ControllDetails[i].ObjectID == arry[0]) {
            //                    FieldName = ControllDetails[i].FriendlyName;
            //                    FocusID = ControllDetails[i].ObjectID;
            //                    break;
            //                }
            //            }
            //            $("#mandatorymsg").html("Please select <b>" + FieldName + "</b>");
            //            designMessageBox();
            //        }
            //    }
            //    else if (Tag = "A") {
            //        for (var i = 0; i < ControllDetails.length; i++) {
            //            if (ControllDetails[i].ObjectID == arry[0]) {
            //                if (ControllDetails[i].ImgUrl == "noimage.png" || ControllDetails[i].ImgUrl == "noimage.jpg") {
            //                    valid = false;
            //                    $(".loading_new").hide();
            //                    $("#MandatoryMessage").dialog("open");
            //                    var FieldName;

            //                    FieldName = ControllDetails[i].FriendlyName;
            //                    FocusID = "";

            //                    $("#mandatorymsg").html("Please select <b>" + FieldName + "</b>");
            //                    designMessageBox();
            //                }
            //            }
            //        }
            //    }
            //});

            if ($(this).attr('id') == "btnAddtoCart") {

                if (TemplateDetails.isPDFPreviewMandatory == true) {

                    $("#MandatoryMessage").dialog("open");
                    $("#mandatorymsg").html("Please Preview the PDF File to Proceed.");
                    designMessageBox();
                    $(".loading_new").hide();
                    valid = false;
                    return false;
                }
            }

            if (!chkOtherPageGroup()) {
                $("#Message").dialog("open");
                $("#msg").html("Please review all pages before you add this PDF to cart.");
                designMessageBox();
                $("div[aria-describedby=Message]").css('z-index', '114');
                $(".loadingNewMask").show();
                $(".loading_new").hide();
                return false;
            }

            if (mand) {
                $(".loading_new").show();
                saveTemplate($(this).attr('id'));
            }
            else if (valid) {
                $(".loading_new").show();
                saveTemplate($(this).attr('id'));
            }
            else {
            }
        }
        else {
            $(".loading_new").show();
            saveTemplate($(this).attr('id'));
        }
    });

    /* Added By salim*/
    $("#btnRotate").unbind('click').bind('click', function () {
        var rotation = $("#txtRotate").val();
        rotateSelectedControll(rotation);
    });

    $("#btnDeleteControl").unbind('click').bind('click', function () {
        deleteTheControll();
    });

    $("#btnClearAllControlls").unbind('click').bind('click', function () {
        if (confirm("Are you sure, you want to reset all the controls, this cannot be undone and it will delete all the controls from the template which is saved previously.")) {
            clearAllControlls();
        }
    });

    $("#btnBold").unbind('click').bind('click', function () {

        ChangeBoldItalic("bold");
    });
    $("#btnItalic").unbind('click').bind('click', function () {

        ChangeBoldItalic("italic");
    });

    $("#btnLeftAlign").unbind('click').bind('click', function () {

        changeAlignment("left");
    });

    $("#btnCenterAlign").unbind('click').bind('click', function () {

        changeAlignment("center");
    });

    $("#btnRightAlign").unbind('click').bind('click', function () {

        changeAlignment("right");
    });

    $("#drpFont").change(function () {

        applyFontToSelectedText($(this).val());
    });

    $("#txtFontSize").keyup(function () {
        applyFontSizeToSelectedText();
    });

    $("#txtPostionY,#txtPostionX").keyup(function () {
        var posXValue = parseFloat($("#txtPostionX").val());
        var posYValue = parseFloat($("#txtPostionY").val());
        changePositioXY(posXValue, posYValue);
    });

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
            if ($("#" + id).hasClass('ui-draggable'))
                applyBorderForControl(id, "TextBlock");
        });

        //$(".removeDate").unbind('click').bind('click', function () {
        //    $("#" + $(this)[0].id.split('_')[0] + "_txt").val("");
        //    LoadDefaultContent("", $(this)[0].id.split('_')[0])
        //    $("#" + $(this)[0].id.split('_')[0] + "_txt").trigger('focusout')
        //    $(this).hide();

        //});

        $(".dropdown").unbind('change').bind('change', function () {
            var id = $(this).attr('id').split('_')[0];
            deSelect();
            var text = $(this).val();
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
            //if (text != "") {
            //    applyBorderForControl(id, Control.Type);
            //}
            //changeSelectedControllID();
            //selectedControllID = "#" + id;
            //selectedObjectID = id;
            //LoadDefaultContent(text, id);           
            //bindMenuBar(id);
            //if (text != "") {
            //    applyBorderForControl(id, Control.Type);
            //}            

            Control.ObjTag = text;
            if (Control.EditDropdown) {
                $("#dropdownTxt_" + Control.ObjectID).val(text);
                $("#dropdownTxt_" + Control.ObjectID).trigger('change');
            }
            else {
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



        $(".dropdownText").unbind('keyup').bind('keyup', function () {
            var id = $(this).attr('id').split('_')[1];
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
        $(".dropdownText").unbind('change').bind('change', function () {
            var id = $(this).attr('id').split('_')[1];
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

        $(".dropdownText").unbind('focusout').bind('focusout', function () {

            var id = $(this).attr('id').split('_');
            var text = $(this).val();
            onfocusoutgroupCntorll();
        });

        $(".dropdownText").unbind('focusin').bind('focusin', function () {

            var id = $(this).attr('id').split('_')[1];
            var text = $(this).val();
            deSelect();
            ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
            $(this).css('background-color', 'rgba(233, 245, 248,255)');
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            onfocusingroupCntorll(id);
            bindMenuBar(id);
            if (text != "") {
                applyBorderForControl(id, Control.Type);
            }
        });




        $(".TxtArea").unbind('keyup').bind('keyup', function () {
            var id = $(this).attr('id').split('_')[0];
            //$("#" + id[0] + " .labelText").html($(this).val());   
            //  $("#" + id + " pre").css('border', '1px dashed rgb(128, 128, 128)');

            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            var text = $(this).val();
            LoadDefaultContent(text, id);
            //changeDefaultContent(text,true,false,true)
            bindMenuBar(id);
        });

        $(".TxtArea").unbind('change').bind('change', function () {
            var id = $(this).attr('id').split('_')[0];
            //$("#" + id[0] + " .labelText").html($(this).val());   
            //$("#" + id + " pre").css('border', '1px dashed rgb(128, 128, 128)');

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
            if ($("#" + id).hasClass('ui-draggable'))
                $("#" + id).css('border', '1px dashed rgb(128, 128, 128)');
            else
                $("#" + id + " pre").css('border', '1px dashed rgb(128, 128, 128)');
            $(this).css('background-color', 'rgba(233, 245, 248,255)');
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;
            bindMenuBar(id);
            // document.getElementById(id).scrollIntoView();
        });

        //Added by shahbaz
        $(".TxtArea").unbind('focusout').bind('focusout', function () {
            var id = $(this).attr('id').split('_');
            var text = $(this).val();
            onfocusoutgroupCntorll();
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



        //22/03/2016 Update
        $(".editimagelink").unbind('click').bind('click', function () {
            var Control;

            var id = $(this).attr('id').split('_')[0];
            changeSelectedControllID();
            selectedControllID = "#" + id;
            selectedObjectID = id;


            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

            //Commneted By shahbaz 22.03.2016
            //var userImagePath = "", systemImagePath = "", noImagePath = "";
            ////alert(Control.OrignalImageName);
            ////alert(Control.ImgUrl);
            //// var image = Control.OrignalImageName, ImagePath;    
            //var image = Control.OrignalImageName, ImagePath;  // To Show last cropped image by Gaj
            //systemImagePath = BackgroundImagesPath + "Gallery/OriginalImages/" + image;
            //if (image == "noimage.png" || image == "noimage.jpg" || image == "") {
            //    noImagePath = SiteImages + "noimage.jpg";
            //}
            //if (Control.IsFromBackEnd == false) {
            //    userImagePath = FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + image;
            //}
            //orgWidthCrop = parseInt(Control.Width * mmConvertionConstant);
            //orgHeightCrop = parseInt(Control.Height * mmConvertionConstant);
            //checkForOriginalFile(userImagePath, systemImagePath, noImagePath, image);

            if (Control.IsFromPdf == false) {
                var userImagePath = "", systemImagePath = "", noImagePath = "";

                var image = Control.OrignalImageName, ImagePath;

                systemImagePath = BackgroundImagesPath + "Gallery/OriginalImages/" + image;
                if (image == "noimage.png" || image == "noimage.jpg" || image == "") {
                    noImagePath = SiteImages + "noimage.jpg";
                }

                if (Control.IsFromBackEnd == false) {
                    userImagePath = FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + image;
                }
                orgWidthCrop = parseInt(Control.Width * mmConvertionConstant);
                orgHeightCrop = parseInt(Control.Height * mmConvertionConstant);
                $("#Imageeditor1").css({ 'overflow-x': 'hidden' });
                checkForOriginalFile(userImagePath, systemImagePath, noImagePath, image);
            }
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


        $(".showCalender").unbind('click').bind('click', function () {
            if (selectedObjectID != "" && typeof selectedObjectID != 'undefined')
                deSelect()
            var id = $(this)[0].id.split('_')[0];
            selectedObjectID = id;
            applyBorderForControl(id, "TextBlock");
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
            ShowCalender($("#" + Control.ObjectID + "_txt")[0], DateFormat);//Calling showCalender function in calender.js
        })

        var Phone_maskText = $(".Phone_maskText");
        for (var i = 0; i < Phone_maskText.length; i++) {

            var id = $(Phone_maskText[i]).attr('id').split('_')[0];
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
            if (Control.PhoneFormat != "") { // Code changed by Amin    
                Format = Control.PhoneFormat.replace(/#/g, "0");
                $(Phone_maskText[i]).mask(Format);
                /////////////Code added by Amin for telephone format on load//////////////////////////
                var id = $(Phone_maskText[i]).attr('id').split('_')[0];
                var text = $(Phone_maskText[i]).val();
                attachLabelTosinglelineControl(id, text);
                ///////////// End Code added by Amin for telephone format on load//////////////////////////
            }

            //$(Phone_maskText[i]).trigger("change");
            //removeBorderForControl(id, "TextBlock");
        }

        //var Currency_maskText = $(".Currency_maskText");
        //for (var i = 0; i < Currency_maskText.length; i++) {
        //    
        //    var id = $(Currency_maskText[i]).attr('id').split('_')[0];
        //    var Control;
        //    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
        //    Format = Control.CurrencyFormat.replace("Thousands separator ", "").replace(" Cent separator ", "").replace("Cent separator ", "");
        //    var thousandsSeparator = '';
        //    var centSeparator = '';
        //    if (Format.length > 1) {
        //        thousandsSeparator = Format[0];
        //        centSeparator = Format[1];
        //    }
        //    else {
        //        centSeparator = Format;
        //    }
        //    $(Currency_maskText[i]).priceFormat({
        //        prefix: '',
        //        thousandsSeparator: thousandsSeparator,
        //        centsSeparator: centSeparator,
        //    });
        //    $(Currency_maskText[i]).trigger("change");
        //    removeBorderForControl(id, "TextBlock");
        //}

    });
}

/*Sort Json*/
function sortJSON(data, key, sortorder) {
    return data.sort(function (a, b) {
        //var x = a[key];
        //var y = b[key];
        //if (sortorder == "ASC") {
        //    return ((x < y) ? -1 : ((x > y) ? 1 : 0));
        //}
        //else if (sortorder == "DESC") {
        //    return ((x < y) ? ((x > y) ? 0 : 1) : -1);
        //}
        cmp = function (x, y) {
            return x > y ? 1 : x < y ? -1 : 0;
        };
        if (sortorder == "ASC") {
            return cmp(
          [cmp(a[key], b[key])],
          [cmp(b[key], a[key])]
      );
        } else if (sortorder == "DESC") {
            return cmp(
          [-cmp(a[key], b[key])],
          [-cmp(b[key], a[key])]
      );
        }
    });
}

/*Sort Json Based on Multiple Field*/
function SortJsonMultiple(data, key1, key2, sortorder) {
    cmp = function (x, y) {
        return x > y ? 1 : x < y ? -1 : 0;
    };

    return data.sort(function (a, b) {
        if (sortorder == "ASC") {
            return cmp(
          [cmp(a[key1], b[key1]), cmp(a[key2], b[key2])],
          [cmp(b[key1], a[key1]), cmp(b[key2], a[key2])]
      );
        } else if (sortorder == "DESC") {
            return cmp(
          [-cmp(a[key1], b[key1]), -cmp(a[key2], b[key2])],
          [-cmp(b[key1], a[key1]), -cmp(b[key2], a[key2])]
      );
        }
    });
}

/*Adding Text control to canvas dynamically*/
function AddTextDynamically(controllDetails, AddNew) {
    var isDropDown = false;
    var fontLoaded = false;
    var defaultContent = capitalizeTheText(controllDetails.DefaultContent, controllDetails.Capitalize);
    if (controllDetails.PhoneFormat != "" && controllDetails.PhoneFormat != "None" && controllDetails.DefaultContent != "") {
        controllDetails.DefaultContent = applyMask(controllDetails.DefaultContent, controllDetails.PhoneFormat);
    }
    //Commented by Amin for 48963
    if (controllDetails.Dropdowns != "None" && controllDetails.DatabaseContent == "") {
     //   defaultContent = "";
        isDropDown = true;
        var control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == controllDetails.ObjectID) control = proj });
        controllDetails.DatabaseContent = defaultContent;
    }

    //for date text field if have any default content and dropdowns default content
    if (controllDetails.CustomFieldType == "Date") {
        controllDetails.Dropdowns = "None";
        _defaultContent = controllDetails.DefaultContent;
        if (DateFormat == "dd/mm/yyyy") {
            if (controllDetails.DefaultContent != "") {
                var splitedDate = controllDetails.DefaultContent.split('/');
                if (splitedDate.length > 1)
                    _defaultContent = splitedDate[1] + "/" + splitedDate[0] + "/" + splitedDate[2];
            }
        }
        if (isNaN(Date.parse(_defaultContent))) {
            controllDetails.DefaultContent = "";
            defaultContent = "";
        }
    }

    //For Getting Line Height
    //var lineHeight = getTextLineHeight(controllDetails.FontSize / ptConvertionConstant, controllDetails.Width * mmConvertionConstant);
    var helptext = controllDetails.HelpText.toString().replace(/'/g, '&#39').replace(/"/g, '&#34');
    var TextHtml = "<div class='Text controll'";
    TextHtml += "id='" + controllDetails.ObjectID + "'";
    TextHtml += "name='" + controllDetails.FieldName + "'";
    TextHtml += "title='" + helptext + "'";
    TextHtml += "style='position:absolute;background-color:transparent;cursor:pointer;white-space:nowrap;";
    TextHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    TextHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
    //TextHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    TextHtml += "line-height:1;"
    TextHtml += "vertical-align:bottom;";
    TextHtml += "text-align:" + controllDetails.TextAlign + ";";
    TextHtml += "'>";
    var Controluniquefontname = "";
    if (controllDetails.Labels == "Use Labels") {
       
        TextHtml += "<div class='labelText' style='position:absolute;bottom:-1px;padding:0px;margin:0px;vertical-align:baseline;line-height:0.7;border:1px dashed transparent;";
        TextHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
        if (controllDetails.ManualTrackDimension == "pt") {
            TextHtml += (controllDetails.ManualTracking / ptConvertionConstant).toFixed(4) + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            TextHtml += (controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
        }
        TextHtml += "color:rgba(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ", " + controllDetails.A + ");";
        //TextHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
        TextHtml += "font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;";
        TextHtml += "padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;";
        Controluniquefontname = getuniquefontname();
        var Font = null;
        FontList.map(function (proj) { if (proj.DisplayFontName == controllDetails.FontFamily) Font = proj });
        if (Font != null) {
            $("head").append("<style>@font-face { font-family:" + Controluniquefontname + "; src: url('" + FontPath + Font.FontFilePath + "'); }</style>");
            TextHtml += "font-family:" + Controluniquefontname + ";";
        }
        else {
            TextHtml += "font-family:arial;";
        }
        TextHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        TextHtml += "font-weight:" + controllDetails.FontWeight + ";";
        TextHtml += "font-style:" + controllDetails.FontStyle + ";'>";

        if (controllDetails.LabelFontSize == 0)//Added if Label Font Size is 0 (5/11/2015)
            controllDetails.LabelFontSize = controllDetails.FontSize;

        TextHtml += "<span style='font-size:" + controllDetails.LabelFontSize / ptConvertionConstant + "px;text-align:left;vertical-align:baseline;display:inline-block;border-width:0px !important;line-height:0.7;bottom:0px;";
        if (controllDetails.DefaultContent == "" && controllDetails.Dropdowns == "None") { //modification
            TextHtml += "display:none;";
        }
        if (controllDetails.Dropdowns != "None" && controllDetails.DatabaseContent == "") {
            TextHtml += "display:none;";
        }


        if (controllDetails.LabelPosition == "customRight") {
            var customRight = controllDetails.CustomRight * mmConvertionConstant;
            TextHtml += "position:absolute;right:" + customRight + "px;width:auto;";
        } else {
            TextHtml += "position:relative;";
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
                    controllDetails.LabelFontExtension = Font.FontFilePath;
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
            
            TextHtml += "font-family:arial;font-weight:normal;font-style:normal;letter-spacing:0;";
        }
        defaContent = defaContent.toString().replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>");
        TextHtml += "' class='label'>" + defaContent + "</span>" + defaultContent.replace(/ /g, "&nbsp;") + "</div>";
    }
    else if (controllDetails.Labels == "None" || controllDetails.Labels == "") {
       
        TextHtml += "<div class='labelText' style='bottom:-1px;position:absolute;padding:0px;margin:0px;vertical-align:baseline;line-height:0.7;border:1px dashed transparent;";
        TextHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
        if (controllDetails.ManualTrackDimension == "pt") {
            TextHtml += (controllDetails.ManualTracking / ptConvertionConstant).toFixed(4) + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            TextHtml += (controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
        }
        TextHtml += "color:rgba(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ", " + controllDetails.A + ");";
        //TextHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
        TextHtml += "font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;";
        TextHtml += "padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;";
        Controluniquefontname = getuniquefontname();

        var Font = null;
        FontList.map(function (proj) { if (proj.DisplayFontName == controllDetails.FontFamily) Font = proj });

        if (Font != null) {
            $("head").append("<style>@font-face { font-family:" + Controluniquefontname + "; src: url('" + FontPath + Font.FontFilePath + "'); }</style>");
            TextHtml += "font-family:" + Controluniquefontname + ";";
        } else {
            TextHtml += "font-family:arial;";
        }

        TextHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        TextHtml += "font-weight:" + controllDetails.FontWeight + ";";
        TextHtml += "font-style:" + controllDetails.FontStyle + ";";
        TextHtml += "'>" + defaultContent.replace(/ /g, "&nbsp;").replace(/®/g, '<sup>&reg;</sup>').replace(/©/g, '<sup>&copy;</sup>') + "</div></div>";
    }
    $("#textCanvas").append(TextHtml);
    if (controllDetails.Dropdowns != "None" && controllDetails.DatabaseContent == "") {
        span = $("#" + controllDetails.ObjectID + " .labelText").html().split('</span>')[0];
    }
    //Added By shahbaz to Determine pageLoad 
    var pageLoad = false;
    if (AddNew == false || typeof AddNew == 'undefined')
        pageLoad = true;
    else
        pageLoad = false;
    if (Controluniquefontname != "") {
        WebFont.load({
            custom: {
                families: [Controluniquefontname],
            },
            active: function () {

                if (IsNavigate) {
                    postionControlsGroupWise(pageLoad);
                }
            },
            inactive: function () {

                AddTextDynamicallyContinued(TextHtml, controllDetails, pageLoad, AddNew);
                if (IsNavigate) {
                    postionControlsGroupWise(pageLoad);
                }
            },
            fontactive: function (arial, fvd) {
                AddTextDynamicallyContinued(TextHtml, controllDetails, pageLoad, AddNew);
            },
            async: false
        });
    }
    else {

        AddTextDynamicallyContinued(TextHtml, controllDetails, pageLoad, AddNew);
        if (IsNavigate) {

            postionControlsGroupWise(pageLoad);
        }
    }

    if (controllDetails.Dropdowns != "None" && isDropDown) {

        var control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == controllDetails.ObjectID) control = proj });
        controllDetails.DatabaseContent = "";
    }
}

function getTextLineHeight(fontsize, Width) {
    return fontsize * (1 - (Width / (fontsize * fontsize)));
}

function AddTextDynamicallyContinued(TextHtml, controllDetails, pageLoad, AddNew) {

    //if (controllDetails.Dropdowns != "None" && controllDetails.DatabaseContent == "") {
    //    $("#" + controllDetails.ObjectID + " .labelText").html(span);
    //}
    alignsingleLineText(controllDetails.ObjectID);

    if (controllDetails.LabelPosition == "customTop" && controllDetails.Labels == "Use Labels") {

        // $("#" + controllDetails.ObjectID + " .label").css({ 'vertical-align': 'top', 'margin-bottom': parseFloat(controllDetails.CustomTop * mmConvertionConstant) + 'px' });

        $("#" + controllDetails.ObjectID + " .labelText").css({ 'bottom': 'auto', 'display': 'inline-table' });
        $("#" + controllDetails.ObjectID + " .label").css({ 'width': 'auto', 'display': 'block', 'height': (controllDetails.CustomTop * mmConvertionConstant) + parseFloat($("#" + controllDetails.ObjectID + " .labelText").css('line-height')) + 2 + 'px' });
        $("#" + controllDetails.ObjectID).css({ 'height': $("#" + controllDetails.ObjectID + " .labelText").height() + "px" });
        if (controllDetails.TextAlign.toLowerCase() == "left") {
            $("#" + controllDetails.ObjectID + " .labelText").css({ 'right': 'auto', 'left': -1 + 'px', 'text-align': 'left' });
            $("#" + controllDetails.ObjectID + " .label").css({ 'margin': '0px', 'width': 'auto', 'text-align': 'left' });
        }
        else if (controllDetails.TextAlign.toLowerCase() == "center") {
            var mar = (controllDetails.Width * mmConvertionConstant / 2) - ((parseFloat($("#" + controllDetails.ObjectID + " .labelText").width())) / 2);
            $("#" + controllDetails.ObjectID + " .labelText").css({ 'right': 'auto', 'left': mar - 1 + 'px', 'text-align': 'center' });
        }
        else if (controllDetails.TextAlign.toLowerCase() == "right") {
            $("#" + controllDetails.ObjectID + " .labelText").css({ 'left': 'auto', 'right': '0px', 'text-align': 'right' });

        }
        $("#" + controllDetails.ObjectID).css({ 'height': $("#" + controllDetails.ObjectID + " .labelText").height() + "px" });

        var divHeight = parseFloat($("#" + controllDetails.ObjectID).height());
        $("#" + controllDetails.ObjectID).css({ 'height': divHeight + "px" });
    }


    if (controllDetails.DefaultContent != "")// Added By Shahbaz 0n Aug/1/15
        $("#" + controllDetails.ObjectID + " .label").show();
    else
        $("#" + controllDetails.ObjectID + " .label").hide();

    //fixPostionOfControll(controllDetails, controllDetails.PositionX - CropMarkWidth, controllDetails.PositionY - CropMarkHeight, controllDetails.TextAlign, pageLoad);// Commented By shahbaz
    fixPostionOfControll(controllDetails, controllDetails.PositionX, controllDetails.PositionY, controllDetails.TextAlign, pageLoad);

    var left = 0;
    if (controllDetails.Type == "TextBlock" || controllDetails.Type == "Paragraph") {
        switch (controllDetails.TextAlign.toLowerCase()) {
            case "center":
                left = (controllDetails.MaxWidth * mmConvertionConstant) / 2;
                break;
            case "right":
                left = controllDetails.MaxWidth * mmConvertionConstant;
                break;
            default:
                left = 0;
        }
    }

    $("#" + controllDetails.ObjectID).css({
        'transformOrigin': left + 'px bottom',
        '-webkit-transform-origin': left + "px bottom",
        '-moz-transform-origin': left + "px bottom",
        '-mz-transform-origin': left + "px bottom",
        '-webkit-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-moz-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-ms-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        'transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)'
    });



    applyonexceedwidth(controllDetails.ObjectID, pageLoad);


    //applyonexceedwidth(controllDetails.ObjectID, pageLoad);    
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

    if (controllDetails.LabelPosition == "customTop" && controllDetails.Labels == "Use Labels" && controllDetails.DefaultContent == "")//Added By shahbaz for control whose default content is null
        $("#" + controllDetails.ObjectID).css({ 'height': parseFloat(controllDetails.MaxHeight * mmConvertionConstant) + "px" });

    if (controllDetails.GroupID == 0) {
        controllDetails.MaxHeight = $("#" + controllDetails.ObjectID).outerHeight() / mmConvertionConstant;
        controllDetails.Height = $("#" + controllDetails.ObjectID).outerHeight() / mmConvertionConstant;
    }

    
}

/*Adding Paragraph control to canvas dynamically*/
function AddParaDynamically(controllDetails, AddNew) {
    debugger;

    var defaultContent = capitalizeTheText(controllDetails.DefaultContent, controllDetails.Capitalize);

    if (controllDetails.Dropdowns != "None" && controllDetails.DatabaseContent == "") {
        // defaultContent = "";
        //var control;
        //ControllDetails.map(function (proj) { if (proj.ObjectID == controllDetails.ObjectID) control = proj });
        //  controllDetails.DefaultContent = "";
    }



    defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>").replace(/&nbsp;/g, " ").replace(/ /g, "&nbsp;").replace(/®/g, '<sup>&reg;</sup>').replace(/©/g, '<sup>&copy;</sup>');;
    defaultContent = defaultContent.replace(/&nbsp;/g, " "); //modification by bilal ticket # 8076
    var helptext = controllDetails.HelpText.toString().replace(/'/g, '&#39');
    var ParaHtml = "<div class='Para controll'";
    ParaHtml += "id='" + controllDetails.ObjectID + "'";
    ParaHtml += "name='" + controllDetails.FieldName + "'";
    ParaHtml += "title='" + helptext + "'";
    ParaHtml += "style='position:absolute;background-color:transparent;";
    //ParaHtml += "width:" + (parseFloat(controllDetails.Width) * mmConvertionConstant + 4) + "px;";
    ParaHtml += "width:" + (parseFloat(controllDetails.Width) * mmConvertionConstant) + "px;";
    ParaHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    ParaHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
    
    if (controllDetails.ManualTrackDimension == "pt") {
        ParaHtml += parseFloat(controllDetails.ManualTracking / ptConvertionConstant).toFixed(4) + "px;";
    }
    else if (controllDetails.ManualTrackDimension == "mm") {
        ParaHtml += parseFloat(controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
    }
    //ParaHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";

    ParaHtml += "color:rgb(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ");";
    ParaHtml += "font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;";
    ParaHtml += "padding:0px;margin:0px;vertical-align:top;";
    var uniquefontname = getuniquefontname();

    ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    //ParaHtml += "z-index:-1;";
    var ParaTextAlign = controllDetails.TextAlign;
    var whitespace = "pre-wrap";
    if (ParaTextAlign == "Justify") {
        ParaTextAlign = "Justify";
        whitespace = "initial";
    }

    ParaHtml += "text-align:" + ParaTextAlign + ";";

    if (controllDetails.DefaultContent == "") {
        ParaHtml += "'><pre style='font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;color:rgb(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ");margin:0px;word-wrap:break-word;white-space:" + whitespace + ";text-align:" + ParaTextAlign + ";line-height:100%;display:inline-block;width:initial;max-width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;border:1px dashed transparent;";
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
            ParaHtml += parseFloat(controllDetails.ManualTracking / ptConvertionConstant).toFixed(4) + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            ParaHtml += parseFloat(controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
        }
        ParaHtml += "padding:0px;margin:0px;padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;vertical-align:top;";
        ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";' class='paraText'>" + defaultContent + "</pre></div>";
    }
    else {
        ParaHtml += "'><pre style='font-size:" + parseFloat(controllDetails.FontSize) / ptConvertionConstant + "px;color:rgb(" + controllDetails.R + ", " + controllDetails.G + ", " + controllDetails.B + ");margin:0px;word-wrap:break-word;white-space:" + whitespace + ";text-align:" + ParaTextAlign + ";line-height:100%;display:inline-block;width:initail;border:1px dashed transparent;max-width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";//
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
            ParaHtml += parseFloat(controllDetails.ManualTracking / ptConvertionConstant).toFixed(4) + "px;";
        }
        else if (controllDetails.ManualTrackDimension == "mm") {
            ParaHtml += parseFloat(controllDetails.ManualTracking * mmConvertionConstant).toFixed(4) + "px;";
        }
        ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        ParaHtml += "font-weight:" + controllDetails.FontWeight + ";";
        ParaHtml += "font-style:" + controllDetails.FontStyle + ";>";
        ParaHtml += "padding:0px;margin:0px;padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;vertical-align:top;' class='paraText'>" + defaultContent + "</pre></div>";
    }


    $("#textCanvas").append(ParaHtml);

    var left = 0;
    if (controllDetails.Type == "TextBlock" || controllDetails.Type == "Paragraph") {
        switch (controllDetails.TextAlign.toLowerCase()) {
            case "center":
                left = (controllDetails.MaxWidth * mmConvertionConstant) / 2;
                break;
            case "right":
                left = controllDetails.MaxWidth * mmConvertionConstant;
                break;
            default:
                left = 0;
        }
    }

    $("#" + controllDetails.ObjectID).css({
        'transformOrigin': left + 'px bottom',
        '-webkit-transform-origin': left + "px bottom",
        '-moz-transform-origin': left + "px bottom",
        '-mz-transform-origin': left + "px bottom",
        '-webkit-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-moz-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        '-ms-transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)',
        'transform': 'rotate(' + (0 - controllDetails.RotateAngle) + 'deg)'
    });
    if (controllDetails.ParaLineSpace > 0) {
        var presentlineheight = $("#" + controllDetails.ObjectID + " pre").css('line-height');
        //var lineleight = (parseFloat(presentlineheight) * ptConvertionConstant) + controllDetails.ParaLineSpace;
        var lineleight = (parseFloat(controllDetails.ParaLineSpace * ptConvertionConstant) * mmConvertionConstant);
        // $("#" + controllDetails.ObjectID + " pre").css('line-height', lineleight + "pt");

        $("#" + controllDetails.ObjectID + " pre").css('line-height', "");
        $("#" + controllDetails.ObjectID).css('line-height', lineleight + "pt");

        //lnHgt = (lineleight / 2) - controllDetails.FontSize / 2;
        lnHgt = parseFloat(lineleight - controllDetails.FontSize * ptConvertionConstant) / 2;
        $("#" + controllDetails.ObjectID + " pre").css('margin-top', -(lnHgt - 1) + "pt");
    }

    //Added By shahbaz to Determine pageLoad 
    var pageLoad = false;
    if (AddNew == false && typeof AddNew == 'undefined')
        pageLoad = true;
    else
        pageLoad = false

    setTimeout(function () { applyonparaexceedwidth(controllDetails, pageLoad); }, 200);
    //applyonparaexceedwidth(controllDetails, pageLoad);
    fixPostionOfControll(controllDetails, controllDetails.PositionX, controllDetails.PositionY, controllDetails.TextAlign, pageLoad);

    functionalities(controllDetails.Lock, controllDetails.ObjectID, true);
    if (AddNew) {
        applyBorderForControl(controllDetails.ObjectID, controllDetails.Type);
        changeSelectedControllID();
        for (var i = 0; i < ControllDetails.length; i++) {
            if (ControllDetails[i].ObjectID == selectedObjectID) {
                ControllDetails[i].MaxHeight = parseFloat($("#" + selectedObjectID).innerHeight() / mmConvertionConstant);
                ControllDetails[i].Height = parseFloat($("#" + selectedObjectID).innerHeight() / mmConvertionConstant);
                ControllDetails.ExceedHeight = "Do Nothing";
                $("#" + selectedObjectID + " .paraText").css('width', '100%')
            }
        }
        bindMenuBar(controllDetails.ObjectID);
    }

    //Added By Shahbaz if Page Loaded with some paragraph Control then assing top position if ExceedHeight Mention 
    setTimeout(function () {
        if (controllDetails.ExceedHeight == "Expand Height") {
            if (controllDetails.RotateAngle > 0) {
                var ActualHeight = getActaulHeightOfRotatedControl($("#" + controllDetails.ObjectID), controllDetails.RotateAngle)

                if (controllDetails.RotateAngle < 135) {
                    ActualHeight = ActualHeight[1]
                    $("#" + controllDetails.ObjectID).css('top', ($("#" + controllDetails.ObjectID).position().top / zoomvalue()) + (ActualHeight - controllDetails.MaxHeight * mmConvertionConstant));
                }
                else if (controllDetails.RotateAngle <= 180) {
                    ActualHeight = ActualHeight[1] - controllDetails.MaxHeight * mmConvertionConstant

                    if (controllDetails.RotateAngle == 180)
                        ActualHeight = -controllDetails.MaxHeight * mmConvertionConstant
                    $("#" + controllDetails.ObjectID).css('top', ($("#" + controllDetails.ObjectID).position().top / zoomvalue()) + ActualHeight);
                }
                else if (controllDetails.RotateAngle <= 270) {
                    ActualHeight = ActualHeight[1] - controllDetails.MaxHeight * mmConvertionConstant
                    $("#" + controllDetails.ObjectID).css('top', ($("#" + controllDetails.ObjectID).position().top / zoomvalue()) - controllDetails.MaxHeight * mmConvertionConstant);
                }
                else if (controllDetails.RotateAngle > 270 && controllDetails.RotateAngle <= 330)
                    ActualHeight = controllDetails.MaxHeight * mmConvertionConstant - ActualHeight[0];
            } else {
                $("#" + controllDetails.ObjectID).css('top', $("#" + controllDetails.ObjectID).position().top / zoomvalue());
            }
        }
    }, 200);
}

/*Adding Image control to canvas dynamically*/
function AddImageDynamically(controllDetails, AddNew) {
    var imagepath = "";
    var ImageHtml = "<div class='Image controll'";
    ImageHtml += "id='" + controllDetails.ObjectID + "'";
    ImageHtml += "name='" + controllDetails.FieldName + "'";
    if (controllDetails.HelpText != "") {
        var helptext = controllDetails.HelpText.toString().replace(/'/g, '&#39');
        ImageHtml += "title='" + helptext + "'";
    }
    else {
        if (controllDetails.AllowImageEdit)
            ImageHtml += "title='Double click to edit'";
    }

    ImageHtml += "style='position:absolute;background-color:transparent;cursor:pointer;";
    ImageHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
    ImageHtml += "height:" + parseFloat(controllDetails.Height) * mmConvertionConstant + "px;";
    ImageHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    // ImageHtml += "border:1px dashed transparent;' >";

    // -- Ticket #6674, added by shehzad on 27-11-2017 to hide noImage.jpg if contact has not uploaded any image file
    if (controllDetails.DefaultImageFrom == 'Contact' && (controllDetails.ImgUrl == 'noimage.png' || controllDetails.ImgUrl == 'noimage.jpg')) {
        ImageHtml += "border:1px dashed transparent; display:none;' >";
    }
    else {
        ImageHtml += "border:1px dashed transparent;' >";
    }

    // end check here to hide noImage.jpg by shehzad on 27-11-2017
  
    if (controllDetails.BackgroundImage != "") {
        if (controllDetails.BackgroundImage == "noimage.png" || controllDetails.BackgroundImage == "noimage.jpg") {

            if (controllDetails.DefaultImageFrom.toLowerCase() == "none") {
                ImageHtml += "<img  src='" + SiteImages + "noimage.jpg";
                imagepath = SiteImages + "noimage.jpg";
            }
            else {
                ImageHtml += "<img  src='" + BackgroundImagesPath + controllDetails.ImgUrl + "'";
                imagepath = BackgroundImagesPath + controllDetails.ImgUrl;
                controllDetails.BackgroundImage = controllDetails.ImgUrl;
            }
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
                    //ImageHtml += "<img  src='" + BackgroundImagesPath + controllDetails.OrignalImageName; commented By shahbaz
                    //imagepath = BackgroundImagesPath + controllDetails.OrignalImageName;commented By shahbaz
                    ImageHtml += "<img  src='" + BackgroundImagesPath + controllDetails.ImgUrl; // Added By shahbaz
                    imagepath = BackgroundImagesPath + controllDetails.ImgUrl; // Added By shahbaz
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


    //if (controllDetails.IsFromPdf == true) {
    //    controllDetails.Edit = false;
    //}


    if (controllDetails.BackgroundImage != "") {
        fixPostionOfControll(controllDetails, 0, 0, controllDetails.TextAlign);
    }
    else {
        fixPostionOfControll(controllDetails, controllDetails.PositionX, controllDetails.PositionY, controllDetails.TextAlign);
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
    //loading Default Image on auto crop from top
    if (controllDetails.IsCropFromTop) {
        if (controllDetails.ImgUrl != "noimage.png" && controllDetails.ImgUrl != "noimage.jpg") {
            selectedObjectID = controllDetails.ObjectID;
            FitTheEditedImageToControl(controllDetails.ImgUrl, true);
        }
    }

    var tmpImg = new Image();
    tmpImg.src = imagepath;
    $(tmpImg).on('load', function () {
        imageloadedcount = imageloadedcount + 1;
        if (imagecount == imageloadedcount) {
            $("#canvasLoading").hide();
            imageloadedcount = 0;
            imagecount = 0;
        }

        //Added by shahbaz to Fit Image to Control on Page Load
        if (controllDetails.DefaultImageFrom.toLowerCase() != "none") {
            //selectedObjectID = controllDetails.ObjectID;
            //FitTheEditedImageToControl(controllDetails.ImgUrl);
            controllDetails.EditedImageName = "";
            exceedimage = controllDetails.ExceedImage;

            if (exceedimage == "P") {
                $("#" + controllDetails.ObjectID + " img").css({ 'height': controllDetails.MaxHeight * mmConvertionConstant, 'width': controllDetails.MaxWidth * mmConvertionConstant })
                controllDetails.MaxHeight = parseFloat($("#" + controllDetails.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                controllDetails.MaxWidth = parseFloat($("#" + controllDetails.ObjectID + " img").innerWidth()) / mmConvertionConstant;
            }
        }

        alignsingleImage(controllDetails.ObjectID);

    });
}

/*Loading Textblock to left panel*/
function LoadLeftPanelForText(controlDetails) {

    if (controlDetails.PhoneFormat != "" && controlDetails.PhoneFormat != "None" && controlDetails.DefaultContent !="") {
        controlDetails.DefaultContent = applyMask(controlDetails.DefaultContent, controlDetails.PhoneFormat);
    }
    if (controlDetails.HideVisibility == false) {
        var TextHtml = "";
        TextHtml += "<tr id='" + controlDetails.ObjectID + "_row'><td style='padding:3px 0px 3px 0px;width:250px;'>";
        TextHtml += "<div style='font-family:Calibri;font-size:13px;font-weight:bold;padding-bottom:2px;'>" + controlDetails.FriendlyName;
        if (controlDetails.Mandatory == true) {
            TextHtml += "<sapn style='font-family:Calibri;font-size:13px;font-weight:bold;color:red;'> *</span>";
        }
        if (controlDetails.HelpText != "") {
            var helptext = controlDetails.HelpText.toString().replace(/'/g, '&#39');
            TextHtml += "<img  src='StyleSheets/Images/Help-icon.png' width='15' height='15' style='float:right;padding-bottom:2px;'  title='" + helptext + "' />";
        }
        TextHtml += "</div>";
        /*Added By salim*/

        var dropdowns = false;
        var count = 0;
        if (controlDetails.Dropdowns != "None" && controlDetails.DatabaseContent == "") {
            //if (controlDetails.ObjTag.trim() == "") {
            //    controlDetails.ObjTag = controlDetails.DefaultContent;
            //}
            dropdowns = true;
            TextHtml += "<select class='dropdown'" + " tabindex='" + tabIndex++  +"'" ;
            TextHtml += " id='" + controlDetails.ObjectID + "_dll' style='width:101%;height:20px;padding-left:3px;border:1px solid #888888;border-radius:4px;font-family:Calibri;font-size:13px;background: -moz-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -webkit-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -o-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -ms-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -ms-linear-gradient( #FFFFFF,#FFFFFF,#D0D6DA);-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";

            TextHtml += '<option value="" >-- Select --</option>';
            if (controlDetails.Dropdowns == "Department") {
                for (var c = 0; c < DropDownDepartmentList.length; c++) {
                    if ((controlDetails.DefaultContent != "" || controlDetails.ObjTag.trim() != "" ) && DropDownDepartmentList[c].trim() == controlDetails.ObjTag.trim()) {
                        TextHtml += "<option value='" + DropDownDepartmentList[c].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + "' selected>" + DropDownDepartmentList[c].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + "</option>";
                        //selectedObjectID = controlDetails.ObjectID;
                        //LoadDefaultContent(DropDownDepartmentList[c], controlDetails.ObjectID);
                        //selectedObjectID = '';
                        count++;
                    }
                    else {
                        TextHtml += '<option value="' + DropDownDepartmentList[c].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + DropDownDepartmentList[c].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                    }
                }
                if (count == 0) {
                    if (!controlDetails.EditDropdown) {
                        $("#" + controlDetails.ObjectID + " .paraText").html("");
                        controlDetails.DefaultContent = "";
                    }
                    //else {
                    //    var defaultcontent = capitalizeTheText($("#dropdownTxt_" + controlDetails.ObjectID).val());
                    //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                    //    controlDetails.DefaultContent = defaultcontent;
                    //}
                }
                loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
            }
            else if (controlDetails.Dropdowns == "Contact") {
                for (var c = 0; c < DropDownContactList.length; c++) {
                    // DropDownContactList[c].trim().indexOf(controlDetails.DefaultContent) != -1
                    if ( (controlDetails.DefaultContent != "" || controlDetails.ObjTag.trim() != "") && DropDownContactList[c].trim() == controlDetails.ObjTag.trim()) {
                        TextHtml += "<option value='" + DropDownContactList[c].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + "' selected>" + DropDownContactList[c].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + "</option>";
                        //selectedObjectID = controlDetails.ObjectID;
                        //LoadDefaultContent(DropDownContactList[c], controlDetails.ObjectID);
                        //selectedObjectID = '';
                        count++;
                    }
                    else {
                        TextHtml += '<option value="' + DropDownContactList[c].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + DropDownContactList[c].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                    }
                }
                if (count == 0) {
                    if (!controlDetails.EditDropdown) {
                        $("#" + controlDetails.ObjectID + " .labelText").html("");
                        controlDetails.DefaultContent = "";
                    }
                    //else {
                    //    var defaultcontent = capitalizeTheText($("#dropdownTxt_" + controlDetails.ObjectID).val());
                    //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                    //    controlDetails.DefaultContent = defaultcontent;
                    //}
                }
                loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
            }
            else if (controlDetails.Dropdowns == "Address") {
                for (var c = 0; c < DropDownAddressList.length; c++) {
                    if ((controlDetails.DefaultContent != "" || controlDetails.ObjTag.trim() != "") && DropDownAddressList[c].Address.trim().replace(/\r\n/g, '') == controlDetails.ObjTag.trim().replace(/\n/g, '').replace(/<br>/g, '')) {
                        TextHtml += "<option value='" + DropDownAddressList[c].Address.replace(/'/g, '&#39').replace(/"/g, '&#34') + "' selected>" + DropDownAddressList[c].Label.replace(/'/g, '&#39').replace(/"/g, '&#34') + "</option>";
                        //selectedObjectID = controlDetails.ObjectID;
                        //LoadDefaultContent(DropDownAddressList[c].Address, controlDetails.ObjectID);
                        //selectedObjectID = '';
                        count++;
                    }
                    else {
                        TextHtml += '<option value="' + DropDownAddressList[c].Address.replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + DropDownAddressList[c].Label.replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                    }
                }
                if (count == 0) {
                    if (!controlDetails.EditDropdown) {
                        $("#" + controlDetails.ObjectID + " .labelText").html("");
                        controlDetails.DefaultContent = "";
                    }
                    //else {
                    //    var defaultcontent = capitalizeTheText($("#dropdownTxt_" + controlDetails.ObjectID).val());
                    //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                    //    controlDetails.DefaultContent = defaultcontent;
                    //}
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
                        var _labelSeparator = getProperties[0].LabelSeparator.trim();
                        //if (_text.length == 1) {
                        //    _text = getProperties[0].PhrasText.split(_seperator) + _seperator;
                        //}

                        if (_type == "Fixed") {
                            for (var a = 0; a < _text.length; a++) {
                                var _value = _text[a] + '';
                                _value = _value.trim();
                                var SelectedValue = _value;
                                if (_labelSeparator != "" && _value.indexOf(_labelSeparator) > -1) {
                                    SelectedValue = _value.split(_labelSeparator)[1].trim();
                                }
                                if ((controlDetails.DefaultContent != "" || controlDetails.ObjTag.trim() != "" )&& SelectedValue.trim() == controlDetails.ObjTag.trim()) {

                                    if (_labelSeparator != "" && _value.indexOf(_labelSeparator) > -1) {
                                        _value = _value.split(_labelSeparator);
                                        TextHtml += '<option value="' + _value[1].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '" selected>' + _value[0].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                        _value = _value[1].trim();
                                    }
                                    else
                                        TextHtml += "<option value='" + _value.replace(/'/g, '&#39').replace(/"/g, '&#34') + "' selected>" + _value.replace(/'/g, '&#39').replace(/"/g, '&#34') + "</option>";


                                    //selectedObjectID = controlDetails.ObjectID;
                                    //LoadDefaultContent(_value, controlDetails.ObjectID);
                                    //selectedObjectID = '';
                                    count++;
                                }
                                else {
                                    if (_labelSeparator != "" && _value.indexOf(_labelSeparator) > -1) {
                                        _value = _value.split(_labelSeparator);
                                        TextHtml += '<option value="' + _value[1].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + _value[0].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                    }
                                    else
                                        TextHtml += "<option value='" + _value.replace(/'/g, '&#39').replace(/"/g, '&#34') + "'>" + _value.replace(/'/g, '&#39').replace(/"/g, '&#34') + "</option>";
                                }
                            }
                            if (count == 0) {
                                if (!controlDetails.EditDropdown) {
                                    $("#" + controlDetails.ObjectID + " .labelText").html("");
                                    controlDetails.DefaultContent = "";
                                }
                                //else {
                                //    var defaultcontent = ControllDetails.DefaultContent;
                                //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                                //    controlDetails.DefaultContent = defaultcontent;
                                //}
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
                                        for (var k = 0; k < PhraseDatBaseList.length ; k++) {
                                            var value = PhraseDatBaseList[k] + '';
                                            var SelectedValue = value;
                                            if (_labelSeparator != "" && value.indexOf(_labelSeparator) > -1) {
                                                SelectedValue = value.split(_labelSeparator)[1].trim();
                                            }
                                            if ((controlDetails.DefaultContent != "" || controlDetails.ObjTag.trim() != "") && SelectedValue.trim() == controlDetails.ObjTag.trim()) {
                                                if (_labelSeparator != "" && value.indexOf(_labelSeparator) > -1) {
                                                    value = value.split(_labelSeparator);
                                                    TextHtml += '<option value="' + value[1].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '" selected>' + value[0].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                                    value = value[1].trim();
                                                }
                                                else
                                                    TextHtml += '<option value="' + value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '" selected>' + value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                                //selectedObjectID = controlDetails.ObjectID;//added By shahbaz
                                                //LoadDefaultContent(value, controlDetails.ObjectID);
                                                //selectedObjectID = '';
                                                count++;
                                            }
                                            else {
                                                if (_labelSeparator != "" && value.indexOf(_labelSeparator) > -1) {
                                                    value = value.split(_labelSeparator);
                                                    TextHtml += '<option value="' + value[1].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + value[0].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                                }
                                                else
                                                    TextHtml += '<option value="' + value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '" >' + value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                            }
                                        }
                                    }
                                    if (count == 0) {
                                        if (!controlDetails.EditDropdown) {
                                            $("#" + controlDetails.ObjectID + " .labelText").html("");
                                            controlDetails.DefaultContent = "";
                                        }
                                        //else {                                        
                                        //    var defaultcontent = capitalizeTheText($("#dropdownTxt_" + controlDetails.ObjectID).val());
                                        //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                                        //    controlDetails.DefaultContent = defaultcontent;
                                        //}
                                    }
                                    loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails);
                                },
                                error: function (xhr) {
                                    console.log(xhr);
                                },
                                async: false
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
function applyMask(inputString,mask) {
    // Remove all non-numeric characters from the input string
    const numericString = inputString.replace(/\D/g, '');

    // Define the mask pattern
    const maskPattern = mask;

    let maskedString = '';
    let j = 0; // Pointer for the numericString

    // Iterate over the mask pattern and replace '#' with numeric characters
    for (let i = 0; i < maskPattern.length; i++) {
        if (maskPattern[i] === '#') {
            maskedString += numericString[j] || ''; // Append a numeric character or an empty string if there are no more numeric characters
            j++; // Move the pointer to the next numeric character
        } else {
            maskedString += maskPattern[i]; // Append the non-numeric character from the mask pattern
        }
    }

    return maskedString;

}

/*Loading Textblock to left panel after checking for default content*/
function loadLeftPanelTextContinued(TextHtml, dropdowns, controlDetails) {
    
    if (dropdowns) {
        TextHtml += '</select>';
        if (controlDetails.EditDropdown) {
            TextHtml += '<input type="Text" class="dropdownText" tabindex="' + tabIndex++  +'" '
                +' id="dropdownTxt_' + controlDetails.ObjectID + '" style="width: 100%; height: 20px; border: 1px solid rgb(119, 139, 156); border-radius: 1px; padding-left: 3px; font-family: Calibri; font-size: 16px;margin-top:5px; padding-top: 2px; padding-bottom: 2px;"/>';
        }
    }
    else {

        TextHtml += "<div><input tabindex='" + tabIndex++ +"' class='textbox";

        if (controlDetails.Mandatory == true) {
            TextHtml += " Mandatory";
        }

        if (controlDetails.PhoneFormat.toLowerCase() != "none") {

            TextHtml += " Phone_maskText";
        }

        //if (controlDetails.CurrencyFormat.toLowerCase() != "none") {
        //    debugger
        //    TextHtml += " Currency_maskText";
        //}

        TextHtml += "' id='" + controlDetails.ObjectID + "_txt' type='text' style='"
        if (controlDetails.CustomFieldType.toLowerCase() == "date")
            TextHtml += "width:87%;"
        else
            TextHtml += "width:100%;"
        TextHtml += "height:20px;border:1px solid #778B9C;border-radius:1px;padding-left:3px;font-family:Calibri;font-size:16px;padding-top:2px;padding-bottom:2px;' value='" + controlDetails.DefaultContent.replace("'", '&#39;') + "' ";

        if (controlDetails.DataType == "Number") {
            TextHtml += " onkeypress='return validateQty(event);' oninput='vaild(event)' ";
        }
        TextHtml += " />";
        if (controlDetails.CustomFieldType.toLowerCase() == "date") {
            //TextHtml += "<span title='Remopve Date' id='" + controlDetails.ObjectID + "_deletetxt' class='removeDate' style='margin-left:-5%;font-family:Calibri;font-size:13px;font-weight:bold;cursor:pointer;color:red;display:inline;width:35px;display:none;'>X</span>"
            //TextHtml += "<span  style='margin-left:-5%'><img class='removeDate' title='Remove Date' id='" + controlDetails.ObjectID + "_deletetxt' src='stylesheets/Images/delete.png' style='height:10px;width:10px;display:none;cursor:pointer' /></span>"
            if (CType == "public" || CType.indexOf("public") > -1) {
                TextHtml += "<div id='" + controlDetails.ObjectID + "_calender' style='margin:-15% auto auto 92%;' title='Calender' class='menubutton showCalender calender'><img src='StyleSheets/Images/calender-text.png' class='menuimg calender' alt='Calender'/></div>";
            } else {
                TextHtml += "<div id='" + controlDetails.ObjectID + "_calender' style='margin:-10% auto auto 91%;' title='Calender' class='menubutton showCalender calender'><img src='StyleSheets/Images/calender-text.png' class='menuimg calender' alt='Calender'/></div>";
            }
        }
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

    if (controlDetails.CustomFieldType.toLowerCase() == "date") {
        $("#" + controlDetails.ObjectID + "_txt").val(controlDetails.DefaultContent)
        $("#" + controlDetails.ObjectID + "_txt").prop('disabled', true);
        $("#" + controlDetails.ObjectID + "_txt").css('background-color', 'white');
    }
    loadOnchange();
}

/*Loading Paragraph to left panel*/
function LoadLeftPanelForPara(controlDetails) {

    if (controlDetails.HideVisibility == false) {
        var TextHtml = "";
        TextHtml += "<tr id='" + controlDetails.ObjectID + "_row' ><td  style='padding:3px 0px 3px 0px;width:250px;'>";
        TextHtml += "<div style='font-family:Calibri;font-size:13px;font-weight:bold;padding-bottom:2px;'>" + controlDetails.FriendlyName;
        if (controlDetails.Mandatory == true) {
            TextHtml += "<sapn style='font-family:Calibri;font-size:13px;font-weight:bold;color:red;'> *</span>";
        }
        if (controlDetails.HelpText != "") {
            var helptext = controlDetails.HelpText.toString().replace(/'/g, '&#39');
            TextHtml += "<img  src='StyleSheets/Images/Help-icon.png' width='15' height='15' style='float:right;padding-bottom:2px;'  title='" + helptext + "' />";
        }
        TextHtml += "</div>";

        var dropdowns = false;
        var count = 0;
        if (controlDetails.Dropdowns != "None" && controlDetails.DatabaseContent == "") {
            //if (controlDetails.ObjTag.trim() == "") {
            //    controlDetails.ObjTag = controlDetails.DefaultContent;
            //}
            dropdowns = true;
            TextHtml += "<select class='dropdown'" + " tabindex='" + tabIndex++ +"' ";
            TextHtml += " id='" + controlDetails.ObjectID + "_dll' style='width:101%;height:20px;padding-left:3px;border:1px solid #888888;border-radius:4px;font-family:Calibri;font-size:13px;background: -moz-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -webkit-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -o-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);background: -ms-linear-gradient( #FFFFFF,#F1F3F4,#D0D6DA);-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";

            TextHtml += '<option value="" >-- Select --</option>';
            if (controlDetails.Dropdowns == "Department") {
                for (var c = 0; c < DropDownDepartmentList.length; c++) {
                    if ((controlDetails.DefaultContent != "" || controlDetails.ObjTag.trim() != "") && DropDownDepartmentList[c].trim() == controlDetails.ObjTag.trim()) {
                        TextHtml += "<option value='" + DropDownDepartmentList[c].replace(/'/g, '&#39').replace(/"/g, '&#34') + "' selected>" + DropDownDepartmentList[c].replace(/'/g, '&#39').replace(/"/g, '&#34') + "</option>";
                        //selectedObjectID = controlDetails.ObjectID;//added By shahbaz
                        //LoadDefaultContent(DropDownDepartmentList[c], controlDetails.ObjectID);
                        //selectedObjectID = '';
                        count++;
                    }
                    else {
                        TextHtml += '<option value="' + DropDownDepartmentList[c].replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + DropDownDepartmentList[c].replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                    }
                }
                if (count == 0) {
                    //selectedObjectID = controlDetails.ObjectID;
                    //LoadDefaultContent("", controlDetails.ObjectID);
                    //selectedObjectID = '';
                    if (!controlDetails.EditDropdown) {
                        $("#" + controlDetails.ObjectID + " .paraText").html("");
                        controlDetails.DefaultContent = "";
                    }
                    //else {
                    //    var defaultcontent = capitalizeTheText($("#dropdownTxt_" + controlDetails.ObjectID).val());
                    //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                    //    controlDetails.DefaultContent = defaultcontent;
                    //}
                }
                loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails);
            }
            else if (controlDetails.Dropdowns == "Contact") {
                for (var c = 0; c < DropDownContactList.length; c++) {
                    if ((controlDetails.DefaultContent != "" || controlDetails.ObjTag.trim() != "") && DropDownContactList[c].trim() == controlDetails.ObjTag.trim()) {
                        TextHtml += "<option value='" + DropDownContactList[c].replace(/'/g, '&#39').replace(/"/g, '&#34') + "' selected>" + DropDownContactList[c].replace(/'/g, '&#39').replace(/"/g, '&#34') + "</option>";
                        //selectedObjectID = controlDetails.ObjectID;//added By shahbaz
                        //LoadDefaultContent(DropDownContactList[c], controlDetails.ObjectID);
                        //selectedObjectID = '';
                        count++;
                    }
                    else {
                        TextHtml += '<option value="' + DropDownContactList[c].replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + DropDownContactList[c].replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                    }
                }
                if (count == 0) {
                    if (!controlDetails.EditDropdown) {
                        $("#" + controlDetails.ObjectID + " .paraText").html("");
                        controlDetails.DefaultContent = "";
                    }
                    //else {
                    //    var defaultcontent = capitalizeTheText($("#dropdownTxt_" + controlDetails.ObjectID).val());
                    //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                    //    controlDetails.DefaultContent = defaultcontent;
                    //}
                }

                loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails);
            }
            else if (controlDetails.Dropdowns == "Address") {
                for (var c = 0; c < DropDownAddressList.length; c++) {
                    if ((controlDetails.DefaultContent != "" || controlDetails.ObjTag.trim() != "") && DropDownAddressList[c].Address.trim().replace(/\r\n/g, '') == controlDetails.ObjTag.trim().replace(/\n/g, '').replace(/<br>/g, '')) {
                        TextHtml += "<option value='" + DropDownAddressList[c].Address.replace(/'/g, '&#39').replace(/"/g, '&#34') + "' selected>" + DropDownAddressList[c].Label.replace(/'/g, '&#39').replace(/"/g, '&#34') + "</option>";
                        //selectedObjectID = controlDetails.ObjectID;//added By shahbaz
                        //LoadDefaultContent(DropDownAddressList[c].Address, controlDetails.ObjectID);
                        //selectedObjectID = '';
                        count++;
                    }
                    else {
                        TextHtml += '<option value="' + DropDownAddressList[c].Address.replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + DropDownAddressList[c].Label.replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                    }
                }
                if (count == 0) {
                    if (!controlDetails.EditDropdown) {
                        $("#" + controlDetails.ObjectID + " .paraText").html("");
                        controlDetails.DefaultContent = "";
                    }
                    //else {
                    //    var defaultcontent = capitalizeTheText($("#dropdownTxt_" + controlDetails.ObjectID).val());
                    //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                    //    controlDetails.DefaultContent = defaultcontent;
                    //}
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
                        var _labelSeparator = getProperties[0].LabelSeparator.trim();
                        //if (_text.length == 1) {
                        //    _text = getProperties[0].PhrasText.split(_seperator);
                        //}

                        if (_type == "Fixed") {
                            for (var a = 0; a < _text.length; a++) {

                                var _value = _text[a] + '';
                                _value = _value.trim();
                                var SelectedValue = _value;
                                if (_labelSeparator != "" && _value.indexOf(_labelSeparator) > -1) {
                                    SelectedValue = _value.split(_labelSeparator)[1].trim();
                                }
                                if (controlDetails.DefaultContent != "" && controlDetails.ObjTag.trim() != "" && SelectedValue.trim() == controlDetails.ObjTag.trim()) {
                                    if (_labelSeparator != "" && _value.indexOf(_labelSeparator) > -1) {
                                        _value = _value.split(_labelSeparator);
                                        TextHtml += '<option value="' + _value[1].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '" selected>' + _value[0].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                        _value = _value[1].trim();
                                    }
                                    else
                                        TextHtml += "<option value='" + _value.replace(/'/g, '&#39').replace(/"/g, '&#34') + "' selected>" + _value.replace(/'/g, '&#39').replace(/"/g, '&#34') + "</option>";
                                    //selectedObjectID = controlDetails.ObjectID;//added By shahbaz
                                    //LoadDefaultContent(_value, controlDetails.ObjectID);
                                    //selectedObjectID = '';
                                    count++;
                                }
                                else {
                                    if (_labelSeparator != "" && _value.indexOf(_labelSeparator) > -1) {
                                        _value = _value.split(_labelSeparator);
                                        TextHtml += '<option value="' + _value[1].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + _value[0].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                    }
                                    else
                                        TextHtml += '<option value="' + _value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + _value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                }
                            }
                            if (count == 0) {
                                if (!controlDetails.EditDropdown) {
                                    $("#" + controlDetails.ObjectID + " .paraText").html("");
                                    controlDetails.DefaultContent = "";
                                }
                                //else {
                                //    var defaultcontent = capitalizeTheText($("#dropdownTxt_" + controlDetails.ObjectID).val());
                                //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                                //    controlDetails.DefaultContent = defaultcontent;
                                //}
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
                                            var SelectedValue = value;
                                            if (_labelSeparator.trim() != "" && value.indexOf(_labelSeparator) > -1) {
                                                SelectedValue = value.split(_labelSeparator)[1].trim();
                                            }
                                            if ((controlDetails.DefaultContent != "" || controlDetails.ObjTag.trim() != "") && SelectedValue.trim() == controlDetails.ObjTag.trim()) {
                                                // value = value.toString().replace(/'/g, '&#39');//for replacing apostrophe or single quote
                                                if (_labelSeparator != "" && value.indexOf(_labelSeparator) > -1) {
                                                    value = value.split(_labelSeparator);
                                                    TextHtml += '<option value="' + value[1].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '" selected>' + value[0].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                                    value = value[1].trim();
                                                }
                                                else
                                                    TextHtml += '<option value="' + value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '" selected>' + value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                                //selectedObjectID = controlDetails.ObjectID;//added By shahbaz
                                                //LoadDefaultContent(value, controlDetails.ObjectID);
                                                //selectedObjectID = '';
                                                count++;
                                            }
                                            else {
                                                // value = value.toString().replace(/'/g, '&#39');//for replacing apostrophe or single quote
                                                if (_labelSeparator != "" && value.indexOf(_labelSeparator) > -1) {
                                                    value = value.split(_labelSeparator);
                                                    TextHtml += '<option value="' + value[1].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + value[0].trim().replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                                }
                                                else TextHtml += '<option value="' + value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '">' + value.replace(/'/g, '&#39').replace(/"/g, '&#34') + '</option>';
                                            }
                                        }
                                    }
                                    if (count == 0) {
                                        if (!controlDetails.EditDropdown) {
                                            $("#" + controlDetails.ObjectID + " .paraText").html("");
                                            controlDetails.DefaultContent = "";
                                        }
                                        //else {
                                        //    var defaultcontent = capitalizeTheText($("#dropdownTxt_" + controlDetails.ObjectID).val());
                                        //    $("#" + controlDetails.ObjectID + " .paraText").html(defaultcontent);
                                        //    controlDetails.DefaultContent = defaultcontent;
                                        //}
                                    }
                                    loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails);
                                },
                                async: false

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

/*Loading Paragraph to left panel after checking for default content*/
function loadLeftPanelParaContinued(TextHtml, dropdowns, controlDetails) {
    var defaultContent = capitalizeTheText(controlDetails.DefaultContent, controlDetails.Capitalize)
    if (dropdowns) {
        TextHtml += '</select>';
        if (controlDetails.EditDropdown) {
            TextHtml += '<textarea class="dropdownText" id="dropdownTxt_' + controlDetails.ObjectID + '" tabIndex="' + tabIndex++ + '"' +
                ' style="width: 100%; height: 70px; border: 1px solid rgb(119, 139, 156); border-radius: 1px; margin-top: 5px; padding-left: 3px; font-family: Calibri; font-size: 16px; resize: none;">' + defaultContent.replace("'", "&#39;") + '</textarea>';
        }
    }
    else {
        TextHtml += "<textarea " + " tabIndex='" + tabIndex++   +  "' class='TxtArea";
        if (controlDetails.Mandatory == true) {
            TextHtml += " Mandatory";
        }
        TextHtml += "' id='" + controlDetails.ObjectID + "_txt'  style='width:100%;height:70px;border:1px solid #778B9C;border-radius:1px;padding-left:3px;font-family:Calibri;font-size:16px;resize:none'";
        if (controlDetails.DataType == "Number") {
            TextHtml += "' onkeypress='return validateQty(event);' oninput='vaild(event)' ";
        }
        TextHtml += " >" + defaultContent.replace("'", "&#39;") + "</textarea>";
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

/*Loading Image to left panel*/
function LoadLeftPanelForImage(controlDetails) {
    var ImageHtml = "";
    if (controlDetails.HideVisibility == false) {
        ImageHtml += "<tr id='" + controlDetails.ObjectID + "_row' ><td style='padding:3px 0px 3px 0px;width:250px;'>";
        ImageHtml += "<div style='font-family:Calibri;font-size:13px;font-weight:bold;padding-bottom:0px;'>" + controlDetails.FriendlyName;
        if (controlDetails.Mandatory == true) {
            ImageHtml += " <sapn style='font-family:Calibri;font-size:13px;font-weight:bold;color:red;'>*</span>";
        }
        if (controlDetails.HelpText != "") {
            var helptext = controlDetails.HelpText.toString().replace(/'/g, '&#39');
            ImageHtml += "<img  src='StyleSheets/Images/Help-icon.png' width='15' height='15' style='float:right;padding-bottom:2px;'  title='" + helptext + "' />";
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

            ImageHtml += "<span title='Select Image' class='changeimagelink'  id='" + controlDetails.ObjectID + "_chg'" + " tabindex='" + tabIndex++ + "' " + "style='font-family:Calibri;font-size:13px;cursor:pointer;font-weight:bold;color:#3296FF;display:inline;width:110px;'>Select Image</span>";
            ImageHtml += "<span  style='font-family:Calibri;font-size:13px;font-weight:bold;cursor:default;display:inline;width:10px;'";
            ImageHtml += " >";
            if (!controlDetails.AllowImageEdit) {
                //do nothing
            } else {
                ImageHtml += "<span id='horizontalbar_" + controlDetails.ObjectID + "'>&nbsp;|&nbsp;</span></span>";
                ImageHtml += "<span title='Edit Image' class='editimagelink'  id='" + controlDetails.ObjectID + "_edit' style='font-family:Calibri;font-size:13px;cursor:pointer;font-weight:bold;color:#3296FF;display:inline;width:110px;'>Edit Image</span>";
            }
        }

        ImageHtml += "</td></tr>";
        $("#LeftPanelControl").append(ImageHtml);

        if (controlDetails.IsFromPdf == true) {
            $("#" + controlDetails.ObjectID + "_edit").hide();
            $("#horizontalbar_" + controlDetails.ObjectID).hide();
        }
    }
    loadOnchange();
}

/*Function To cahnge or load the Page*/
var IsNavigate = false;
function changeThePageFromNavigation(PageNumber, Next) {

    IsNavigate = true;
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

    PageViewed.map(function (proj) { if (proj.PageNumber == PageNumber) proj.IsViewed = true; });

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
    var lastTextboxControl = 0
    for (var i = 0; i < ControllDetailsByorderNumber.length; i++) {
        if (parseInt(ControllDetailsByorderNumber[i].PageNumber) == PageNumber) {
            if (ControllDetailsByorderNumber[i].Visibility) {// Added By Shahbaz for Hiding deleted control
                if (ControllDetailsByorderNumber[i].Type == "TextBlock") {
                    AddTextDynamically(ControllDetailsByorderNumber[i]);
                    LoadLeftPanelForText(ControllDetailsByorderNumber[i]);
                    lastTextboxControl = ControllDetailsByorderNumber[i].ObjectID;
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

    //
    //while ($("#" + ControllDetailsByorderNumber[lastTextboxControl]).length) {
    //    postionControlsGroupWise();
    //}

    //setTimeout(function () {
    //    //for (var i = 0; i < ControllDetails.length; i++) {
    //    //selectedObjectID = ControllDetails[i].ObjectID;
    //    //LoadDefaultContent(ControllDetails[i].DefaultContent, ControllDetails[i].ObjectID);
    //    //$("#" + ControllDetails[i].ObjectID + "_txt").trigger("focusin");
    //    //$("#" + ControllDetails[i].ObjectID + "_txt").trigger("focusout");
    //    debugger
    //    listOfPositionForMoveUp();
    //    listOfPositionForMoveDown();
    //    listOfPositionForKeepRight();
    //    listOfPositionForKeepLeft();

    //    //}

    //}, 50);
    //selectedObjectID = "";
    //postionControlsGroupWise();//21/03/2016 Update


}

/*Function To unload menubar*/
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

/*To generate GUID*/
function Guid() {
    var d = new Date().getTime();
    var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = (d + Math.random() * 16) % 16 | 0;
        d = Math.floor(d / 16);
        return (c == 'x' ? r : (r & 0x7 | 0x8)).toString(16);
    });

    return uuid.substring(0, 10);
}

/*Load the Edited image to the control*/
function FitTheEditedImageToControl(fileName, DefaultImageLoad) {
    var zoom = parseInt(parseFloat(zoomvalue()) * 100);
    var width;
    var height;
    var objectid = selectedObjectID;
    var exxceeimage = "";
    var Control;

    var strIsFromBackEnd;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    width = parseInt(Control.Width * mmConvertionConstant);
    height = parseInt(Control.Height * mmConvertionConstant);
    width = parseInt($("#" + Control.ObjectID).innerWidth());
    height = parseInt($("#" + Control.ObjectID).innerHeight());
    exxceeimage = Control.ExceedImage;
    strIsFromBackEnd = Control.IsFromBackEnd;
    var Edited = "true";
    if (DefaultImageLoad) {
        Edited = "false";
    }
    //if (Control.DefaultImageFrom != "None")
    //    Edited = "false";

    //if (Control.IsImageQuality) {
    //    $.ajax({
    //        url: WebMethodsPath + "checkImageForDPI",
    //        type: "POST",
    //        data: JSON.stringify({ OriginalImageName: Control.OrignalImageName, isEdited: "true", ischecked: "false", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI }),
    //        dataType: "json",
    //        processData: false,
    //        contentType: "application/json; charset=utf-8",
    //        success: function (DPIResult) {
    //            if (DPIResult.d == "success") {
    //                LoadImage();
    //            }
    //            else {
    //                $("#SaveMessage").dialog("open");
    //                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
    //                designMessageBox();
    //                $("div[aria-describedby=SaveMessage]").css('z-index', '114');
    //                $(".loadingNewMask").show();
    //                $(".loading_new").hide();
    //            }
    //        }
    //    });
    //}
    //else {
    //    LoadImage();
    //}

    //function LoadImage() {



    if (exxceeimage == "P") {
        var FitImageToContoll = {};
        FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
        FitImageToContoll.type = "POST";
        FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: Edited, ischecked: "false", isfrombackend: strIsFromBackEnd, TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop });
        FitImageToContoll.dataType = "json";
        FitImageToContoll.processData = false;
        FitImageToContoll.contentType = "application/json; charset=utf-8";

        FitImageToContoll.error = function ServiceFailed(xhr, status, error) {
            console.log('Some error in saving the image.');
            //   alert('Service call failed: ' + result.status + ' ' + result.statusText); 
            //  alert(xhr.responseText);
            //    var err = eval("(" + xhr.responseText + ")"); 
            // alert(err.Message)
            // alert('haha');        
        };



        FitImageToContoll.success = function (ImageName) {
            var arry = ImageName.d.split('~');
            if (arry[0].toLowerCase() != "dpierror") {
                ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });


                Control.ImgUrl = arry[0];
                if (!DefaultImageLoad) {
                    Control.IsFromBackEnd = false;
                    Control.EditedImageName = arry[0];
                }
                Control.MaxHeight = parseFloat(arry[3] / mmConvertionConstant);
                Control.MaxWidth = parseFloat(arry[4] / mmConvertionConstant);
                Control.IsCropped = Boolean(arry[5]);

                if (Control.DefaultImageFrom.toLowerCase() != "none" && Control.IsFromPdf == false)
                    Control.DefaultImageFrom = "None";

                // alert(Control.IsCropped);
                if (Control.BackgroundImage != "") {
                    $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                    Control.BackgroundImage = arry[0];
                }
                else
                    $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'position': 'absolute', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });

                Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight() / mmConvertionConstant);
                Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth() / mmConvertionConstant);
                $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + arry[0]);


                var tmpImg = new Image();
                tmpImg.src = FrontEndDocumentPath + TemplateID + "/Images/" + arry[0];
                $(tmpImg).on('load', function () {
                    $(".loading_new").hide();
                });
            }
            else {
                $("#SaveMessage").dialog("open");
                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
                designMessageBox();
                $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                $(".loadingNewMask").show();
                //$(".loading_new").hide();
            }
            alignsingleImage(Control.ObjectID)
        };
        $.ajax(FitImageToContoll);
    }
    else if (exxceeimage == "S") {
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.EditedImageName = fileName;
        Control.ImgUrl = fileName;
        Control.IsFromBackEnd = false;
        if (Control.BackgroundImage != "")//6-04-2016
            Control.BackgroundImage = fileName;

        //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
        $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + fileName);
        $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
        //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + Control.ImgUrl);
        $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
        Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
        if (fixPostionOfControll(Control, Control.PositionX, Control.PositionY, Control.TextAlign)) {
            $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
            if ($("#" + Control.ObjectID).hasClass('Para')) {
                $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
            }
        }

        var tmpImg = new Image();
        tmpImg.src = FrontEndDocumentPath + TemplateID + "/Images/" + fileName;
        $(tmpImg).on('load', function () {
            $(".loading_new").hide();
        });

    }
    else if (exxceeimage == "D") {
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.EditedImageName = fileName;
        Control.ImgUrl = fileName;
        Control.IsFromBackEnd = false;
        //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
        if (Control.BackgroundImage != "")
            Control.BackgroundImage = fileName;
        var tmpImg = new Image();
        tmpImg.src = FrontEndDocumentPath + TemplateID + "/Images/" + fileName;
        $(tmpImg).on('load', function () {
            //var orgWidth = this.width;
            //var orgHeight = this.height;

            var orgWidth = Control.MaxWidth * mmConvertionConstant;
            var orgHeight = Control.MaxHeight * mmConvertionConstant;

            $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + fileName);
            $("#" + Control.ObjectID).css({ 'width': orgWidth + 'px', 'height': orgHeight + 'px' });
            $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
            $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
            Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
            Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
            Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
            Control.Width = parseFloat($("#" + Control.ObjectID).innerWidth()) / mmConvertionConstant;
            if (fixPostionOfControll(Control, Control.PositionX, Control.PositionY, Control.TextAlign)) {
                $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
                }
            }
            $(".loading_new").hide();
        });

    }
    //}

}

/*Desgning the message Box dynamically*/
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

/*To Change Font color from RGB to CMYK*/
function changeColorByInputText() {
    chnageFontColorCMYKtoRGB();
}

/*To Change Font color from CMYK to RGB*/
function chnageFontColorCMYKtoRGB() {
    var c = 0.00, m = 0.00, k = 0.00, y = 0.00, r = 0.00, g = 0.00, b = 0.00, tint = 0.00;
    c = $("#txtC").val();
    m = $("#txtM").val();
    y = $("#txtY").val();
    k = $("#txtK").val();
    //tint = $("#txtT").val();//Commnetd By shahbaz  on 11/1/2016 

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    if (Control != undefined) {
        var labeelColor = $("#" + Control.ObjectID + " .label").css('color');

        c = parseFloat(c / 100);
        m = parseFloat(m / 100);
        y = parseFloat(y / 100);
        k = parseFloat(k / 100);

        Control.C = c;
        Control.M = m;
        Control.Y = y;
        Control.K = k;
        //Control.Tint = tint;//Commnetd By shahbaz  on 11/1/2016 

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
                $("#" + Control.ObjectID + " pre").css('color', 'rgb(' + r + ',' + g + ',' + b + ')');
            }
        }
        $("#" + Control.ObjectID + " .label").css('color', labeelColor);
    }
}

/*Capitalize the text*/
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
        var content = "";
        var Words = DefaultContent.split(' ');
        for (var i = 0; i < Words.length; i++) {
            if (Words[i] != "") {
                var firstLetter = Words[i][0].toUpperCase();
                var remaingString = Words[i].substr(1, Words[i].length - 1).toLowerCase();
                if (i != Words.length - 1) {
                    content += firstLetter + remaingString + " ";
                }
                else {
                    content += firstLetter + remaingString;
                }
            } else {
                content += "";
            }
        }

        /*Checking new line in Default Content   (Added By Shahbaz)*/
        var NewLine = content.split(/\r\n|\r|\n/g);
        if (NewLine.length > 1) {
            content = NewLine[0] + "\n";
            for (var i = 1; i < NewLine.length; i++) {
                NewLine[i] = NewLine[i];
                if (NewLine[i] != "") {
                    var firstLetter = NewLine[i][0].toUpperCase();
                    var remaingString = NewLine[i].substr(1, NewLine[i].length - 1);
                    if (i != NewLine.length - 1) {
                        content += firstLetter + remaingString + "\n";
                    }
                    else {
                        content += firstLetter + remaingString;
                    }
                }
            }
        }
        defaultContent = content;

    }
    else if (Capitalize == "FirstCapAllowCaps") {
        var content = "";
        var Words = DefaultContent.split(' ');
        for (var i = 0; i < Words.length; i++) {
            if (Words[i] != "") {
                var firstLetter = Words[i][0].toUpperCase();
                var remaingString = Words[i].substr(1, Words[i].length - 1);
                if (i != Words.length - 1) {
                    content += firstLetter + remaingString + " ";
                }
                else {
                    content += firstLetter + remaingString;
                }
            } else {
                content += " ";
            }
        }

        /*Checking new line in Default Content   (Added By Shahbaz)*/
        var NewLine = content.split(/\r\n|\r|\n/g);
        if (NewLine.length > 1) {
            content = NewLine[0] + "\n";
            for (var i = 1; i < NewLine.length; i++) {
                NewLine[i] = NewLine[i];
                if (NewLine[i] != "") {
                    var firstLetter = NewLine[i][0].toUpperCase();
                    var remaingString = NewLine[i].substr(1, NewLine[i].length - 1);
                    if (i != NewLine.length - 1) {
                        content += firstLetter + remaingString + "\n";
                    }
                    else {
                        content += firstLetter + remaingString;
                    }
                }
            }
        }
        defaultContent = content;
    }
    else {
        defaultContent = DefaultContent.toLowerCase();
    }

    //defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"); commented by shahbaz

    return defaultContent;
}

/*Get Unique Font name*/
function getuniquefontname() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    for (var i = 0; i < 10; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));
    return text;
}

/*zooming the canvas*/
function zoomTextCanvas(zoomCanvas, pageload) {
    var CanvasWidth = $("#LayoutCanvas").width();

    if ((CType == "public" || CType.indexOf("public") > -1) && pageload == true) {
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

/*Get zoom value of the canvas*/
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

/*Onexceed width events for text and para contorl on page load*/
function applyonexceedwidth(id, pageload) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

    //var width = parseFloat($("#" + Control.ObjectID).outerWidth());
    //if (Control.Lock) {
    //    if (Control.ExceedWidth == "Shrink") {
    //        //Added By shahbaz for reduce text from Textblock if enter text width cross Canvas Width          
    //        if (Control.TextAlign == "Left") {
    //            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > textCanvasWidth - (Control.Left * mmConvertionConstant)) {
    //                $("#" + Control.ObjectID).css('max-width', textCanvasWidth - (Control.Left * mmConvertionConstant));
    //            }
    //        }
    //        else if (Control.TextAlign == "Center") {
    //            ExtraWidth = ((Control.Width * mmConvertionConstant + Control.Left * mmConvertionConstant) - textCanvasWidth) / mmConvertionConstant;
    //            if (Control.Left * mmConvertionConstant + parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() / 2) > textCanvasWidth) {
    //                $("#" + Control.ObjectID).css('max-width', textCanvasWidth - (Control.Left * mmConvertionConstant) + parseFloat((Control.Width - ExtraWidth) * mmConvertionConstant));
    //            }
    //        }
    //    }
    //}
    var width = $("#" + Control.ObjectID).outerWidth();
    var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
    if (Control.LabelPosition == "customTop") {
        LabelWidth = 0;
    }
    if (LabelWidth < width)
        width = width - LabelWidth;
    var TextWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth;

    var widthonlabelLeft = 0;
    if (Control.LabelPosition == "customRight") {
        var widthonlabelLeft = parseFloat($("#" + Control.ObjectID + " .label").width());
        // widthonlabelLeft = (Control.Width - RightlabelWidth) * mmConvertionConstant;
    }
    debugger;
    defaultContent = Control.DefaultContent;

    defaultContent = capitalizeTheText(defaultContent, Control.Capitalize);

    if (Control.Type == "TextBlock") {
        if (Control.ExceedWidth == "Do Nothing") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() + LabelWidth + widthonlabelLeft) > width + 2) {
                while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth + widthonlabelLeft) > width + 2) {
                    defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);

                    $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "));
                    $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));
                    Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
                }
                fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign, pageload);
                alignsingleLineText(Control.ObjectID);
            }
            else {
                fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign, pageload);
                alignsingleLineText(Control.ObjectID);
                Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
                $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));
            }
        }
        else if (Control.ExceedWidth == "Expand side") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth) > width + 2) {
                $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
                Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
                Control.Width = Control.MaxWidth;
                fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign, pageload);
            }
            fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign, pageload);
            alignsingleLineText(Control.ObjectID);
            Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
            $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));
        }
        else if (Control.ExceedWidth == "Shrink") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth - widthonlabelLeft) > width + 2) {
                var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                var fontsize = Fontsize - 0.05;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth - widthonlabelLeft) > width && fontsize > 0) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                    Control.FontSize = font * ptConvertionConstant;

                    if (LabelWidth == null) {
                        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                    }
                    if (parseFloat($("#" + Control.ObjectID).outerHeight()) != 0) {
                        Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                        Control.Height = Control.MaxHeight;
                    }
                    else {
                        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .labelText").outerHeight() + 1) / mmConvertionConstant;
                        Control.Height = Control.MaxHeight;
                    }

                    fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign, pageload);
                    fontsize = fontsize - 0.05;
                }

            }
            fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign, pageload);
            alignsingleLineText(Control.ObjectID);
            Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
            $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));

        }
        else if (Control.ExceedWidth == "Tracking" || Control.ExceedWidth == "Track") {
           
            if (Control.MaxShrink > 1)
                Control.MaxShrink = Control.MaxShrink / 10;
            // if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth()) > width && parseFloat($("#txttextTrscking").val())) { commented By shahbaz 
            if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth + widthonlabelLeft) > width + 2) { //Added By shahbaz               
                if (Control.MaxShrink > 0) {
                    var spacing;
                    var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                    var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                    var letterSpacing = LetterSpacing - Control.MaxShrink;

                    while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth + widthonlabelLeft) > width + 2) {
                        $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                        spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                        $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                        letterSpacing = letterSpacing - Control.MaxShrink;

                        /*Commented By shahbaz*/
                        //Control.ManualTrackSign = spacing[0];
                        //Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                        //Control.ManualTrackDimension = "pt";

                        /*Added By shahbaz*/
                        if (spacing.indexOf("-") > -1) {
                            Control.ManualTrackSign = spacing[0];
                            Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                            Control.ManualTrackDimension = "pt";
                        } else {
                            Control.ManualTrackSign = '+';
                            Control.ManualTracking = parseFloat(spacing.substr(0, spacing.length)) * ptConvertionConstant;
                            Control.ManualTrackDimension = "pt";
                        }
                    }
                }
                else {

                    while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth + widthonlabelLeft) > width + 2) {
                        defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);

                        $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "));
                        $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));
                        Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
                    }
                    fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign, pageload);
                    alignsingleLineText(Control.ObjectID);
                }


            }
            else if (parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing')) < parseFloat(Control.ManualTracking)) {
               
                var spacing;
                var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                var letterSpacing = LetterSpacing + Control.MaxShrink;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) < width && parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing')) < parseFloat(Control.ManualTracking)) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                    $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                    letterSpacing = letterSpacing + Control.MaxShrink;
                    if (spacing.indexOf("-") > -1) {
                        Control.ManualTrackSign = spacing[0];
                        Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    } else {
                        Control.ManualTrackSign = '+';
                        Control.ManualTracking = parseFloat(spacing.substr(0, spacing.length)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    }
                }
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                    
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                    $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                    letterSpacing = letterSpacing - Control.MaxShrink;
                    if (spacing.indexOf("-") > -1) {
                        Control.ManualTrackSign = spacing[0];
                        Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    } else {
                        Control.ManualTrackSign = '+';
                        Control.ManualTracking = parseFloat(spacing.substr(0, spacing.length)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    }
                }

                fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign);
                alignsingleLineText(Control.ObjectID);
                changeAlignment(Control.TextAlign);
            }
            else {
                $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': "0px" });
                //Control.MaxShrink = 0;
                
            }
            fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign, pageload);
            alignsingleLineText(Control.ObjectID);
            Control.DefaultContent = defaultContent.replace(/&nbsp;/g, " ");
            $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));
        }
    }
}

function applyonparaexceedwidth(Control, pageload) {

    var defaultContent = capitalizeTheText(Control.DefaultContent, Control.Capitalize);

    //if (Control.Dropdowns != "None" && Control.DatabaseContent == "") {
    //    if (defaultContent == controllDetails.Dropdowns) defaultContent = "";
    //}    
    defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>");
    var Text = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">").replace(/<br>/g, "\n");
    // $("#" + Control.ObjectID + " .paraText").html(defaultContent.replace(/&nbsp;/g, " "));

    if (Control.ExceedHeight == "Do Nothing") {
        if (($("#" + Control.ObjectID + " .paraText").outerHeight() - 2) > ($("#" + Control.ObjectID).outerHeight() + 2)) {
            while (($("#" + Control.ObjectID + " .paraText").outerHeight() - 2) > ($("#" + Control.ObjectID).outerHeight() + 2)) {
                Text = Text.substr(0, Text.length - 1);
                $("#" + Control.ObjectID + " .paraText").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>").replace(/&nbsp;/g, " "));
            }
        }
        while ($("#" + Control.ObjectID + " .paraText").outerHeight() - 2 > $("#" + Control.ObjectID).outerHeight()) {
            Text = Text.substr(0, Text.length - 1);
            $("#" + Control.ObjectID + " .paraText").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>"));
            $("#" + Control.ObjectID + "_txt").val(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>"));
            $("#dropdownTxt_" + Control.ObjectID).val(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>"));
        }

        Control.DefaultContent = Text;
        $("#" + Control.ObjectID + "_txt").val(Text);
        $("#dropdownTxt_" + Control.ObjectID).val(Text);
    }
}

/*Fix the position ofthe control on the canvas*/
function fixPostionOfControll(Control, posXValue, posYValue, Alignment, pageLoad, movementOption) {
    var zoom = zoomvalue();
    var elementHeight = parseFloat($("#" + Control.ObjectID).innerHeight());
    var elementWidth = getControlWidth(Control) * mmConvertionConstant;

    var textcanvas = textCanvasHeight;


    var bottom = (posYValue * mmConvertionConstant) - (CropMarkHeight * mmConvertionConstant);
    var left = (posXValue * mmConvertionConstant) - (CropMarkWidth * mmConvertionConstant);


    if (Alignment == "Right") {
        var right = textCanvasWidth - left;
        left = Math.round(left) - elementWidth;
        //right = (textCanvasWidth - left);
        //left = left - elementWidth;
        if (left < 0 && pageLoad != true && movementOption != true) {
            $("#Message").dialog("open");
            $("#msg").html("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            designMessageBox();
            //getPosition(); Commented by shahbaz as here no need to align control
            //alert("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            return false;
        }
        else {
            if (Control.Type == "TextBlock") {
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                posXValue = posXValue;

                //posXValue += (($("#" + Control.ObjectID + " .labelText").offset().left) - ($("#" + Control.ObjectID).offset().left)) / mmConvertionConstant;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
                if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                    Control.Left = posXValue;
                    Control.Top = posYValue;
                }
            }
            else {
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
                if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                    Control.Left = posXValue;
                    Control.Top = posYValue;
                }
            }
            var letterspacing = 0;
            $("#" + Control.ObjectID).css({ 'left': 'auto', 'right': right + "px", 'top': 'auto', 'bottom': bottom + "px" });
            //$(ID).css({ 'left': left, 'bottom': bottom });
            return true;
        }
    }
    else if (Alignment == "Center") {
        pleft = Math.round(left) - (elementWidth / 2);
        left = left - (parseFloat($("#" + Control.ObjectID).innerWidth() + 2) / 2);//21/03/2016 Update 
        if (pleft < 0 && pageLoad != true && movementOption != true) {
            //alert("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            $("#Message").dialog("open");
            $("#msg").html("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            designMessageBox();
            //  getPosition();Commented by shahbaz as here no need to align control
            return false;
        }
        else {
            if (Control.Type == "TextBlock") {
                var width = getControlWidth(Control);
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                posXValue = posXValue;

                //posXValue += (($("#" + Control.ObjectID + " .labelText").offset().left) - ($("#" + Control.ObjectID).offset().left)) / mmConvertionConstant;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
                if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                    Control.Left = posXValue;
                    Control.Top = posYValue;
                }
            }
            else {
                var width = getControlWidth(Control);
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
                if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                    Control.Left = posXValue;
                    Control.Top = posYValue;
                }
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
        if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
            Control.Left = posXValue;
            Control.Top = posYValue;
        }
        if (Control.Labels == "Use Labels" && Control.LabelPosition == "customLeft") {
            left = left - Control.CustomLeft * mmConvertionConstant;
        }

        if (Control.Type == "Image") {
            left = left - 1;
            bottom = bottom - 1;
        }

        if (Control.Type == "Paragraph") {
            left = left - 1;
            bottom = bottom - 1;
        }

        $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" });
        //$(ID).css({ 'left': left, 'top': top });
        // $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" })

        return true;
    }
}


function fixPostionOfParaGroupControll(Control, posXValue, posYValue, Alignment, pageLoad, movementOption) {
    var zoom = zoomvalue();
    var elementHeight = parseFloat($("#" + Control.ObjectID).innerHeight());
    var elementWidth = getControlWidth(Control) * mmConvertionConstant;

    var textcanvas = textCanvasHeight;

    var bottom = (posYValue * mmConvertionConstant) - (CropMarkHeight * mmConvertionConstant);
    var left = (posXValue * mmConvertionConstant) - (CropMarkWidth * mmConvertionConstant);


    //var top = textCanvasHeight - bottom - elementHeight

    if (Alignment == "Right") {
        var right = textCanvasWidth - left;
        left = Math.round(left) - elementWidth;
        //right = (textCanvasWidth - left);
        //left = left - elementWidth;
        if (left < 0 && pageLoad != true && movementOption != true) {
            $("#Message").dialog("open");
            $("#msg").html("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            designMessageBox();
            //getPosition(); Commented by shahbaz as here no need to align control
            //alert("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            return false;
        }
        else {
            if (Control.Type == "TextBlock") {
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                posXValue = posXValue;

                //posXValue += (($("#" + Control.ObjectID + " .labelText").offset().left) - ($("#" + Control.ObjectID).offset().left)) / mmConvertionConstant;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
                if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                    Control.Left = posXValue;
                    Control.Top = posYValue;
                }
            }
            else {
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
                if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                    Control.Left = posXValue;
                    Control.Top = posYValue;
                }
            }

            $("#" + Control.ObjectID).css({ 'left': 'auto', 'right': right + "px", 'top': 'auto', 'bottom': bottom + "px" });
            //$(ID).css({ 'left': left, 'bottom': bottom });
            return true;
        }
    }
    else if (Alignment == "Center") {
        left = left - (parseFloat($("#" + Control.ObjectID).innerWidth() + 2) / 2);//21/03/2016 Update
        var right = (textCanvasWidth - left) - (elementWidth / 2);
        // left = Math.round(left) - (elementWidth / 2);
        if (left < 0 && pageLoad != true && movementOption != true) {
            //alert("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            $("#Message").dialog("open");
            $("#msg").html("The change you made will position all or some of the field off the product canvas. Position the field away from the edge or make the field much narrower to enable you to justify correctly.");
            designMessageBox();
            //  getPosition();Commented by shahbaz as here no need to align control
            return false;
        }
        else {
            if (Control.Type == "TextBlock") {
                var width = getControlWidth(Control);
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                posXValue = posXValue;

                //posXValue += (($("#" + Control.ObjectID + " .labelText").offset().left) - ($("#" + Control.ObjectID).offset().left)) / mmConvertionConstant;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
                if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                    Control.Left = posXValue;
                    Control.Top = posYValue;
                }
            }
            else {
                var width = getControlWidth(Control);
                Control.OffsetLeft = posXValue;
                Control.OffsetTop = posYValue;
                Control.PositionX = posXValue;
                Control.PositionY = posYValue;
                if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                    Control.Left = posXValue;
                    Control.Top = posYValue;
                }
            }

            if (Control.Type == "Image") {
                left = left - 1;
                bottom = bottom - 1;
            }


            $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" });
            //$(ID).css({ 'left': left, 'top': top });          
        }
    }
    else {
        Control.PositionX = posXValue;
        Control.PositionY = posYValue;
        Control.OffsetLeft = posXValue;
        Control.OffsetTop = posYValue;
        if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
            Control.Left = posXValue;
            Control.Top = posYValue;
        }
        if (Control.Labels == "Use Labels" && Control.LabelPosition == "customLeft") {
            left = left - Control.CustomLeft * mmConvertionConstant;
        }

        if (Control.Type == "Image") {
            left = left - 1;
            bottom = bottom - 1;
        }

        if (Control.Type == "Paragraph") {
            left = left - 1;
        }
        $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" });
        return true;
    }
    //$("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .paraText").outerHeight() });
    //Control.Height = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight()) / mmConvertionConstant;
    //Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight()) / mmConvertionConstant;   
}

/*Deselect all controlls*/
function deSelect() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    if (selectedObjectID != "" && $("#" + selectedObjectID).hasClass("ui-draggable")) {
        $("#" + selectedObjectID).css('border', '1px dashed transparent');
        //$(".Para").css('border', '1px dashed transparent');
        //$(".Image").css('border', '1px solid transparent');
        $(".Text").css('cursor', 'pointer');
        $(".Para").css('cursor', 'pointer');
        $(".Image").css('cursor', 'pointer');
        $(".textbox").css('background-color', 'white');
        $(".TxtArea").css('background-color', 'white');
        $(".dropdownText").css('background-color', 'white');
    }
    else {
        $(".Text .labelText").css('border', '1px dashed transparent');
        $(".Para pre").css('border', '1px dashed transparent');
        $(".Image").css('border', '1px solid transparent');
        $(".Text .labelText").css('cursor', 'pointer');
        $(".Para pre").css('cursor', 'pointer');
        $(".Image").css('cursor', 'pointer');
        $(".textbox").css('background-color', 'white');
        $(".TxtArea").css('background-color', 'white');
        $(".dropdownText").css('background-color', 'white');
    }
}

//Added for Expand Height Issue (Ticket Id:12960)
function SetParaPositionForExpand(controllDetails) {
    if (controllDetails.ExceedHeight == "Expand Height") {
        if (controllDetails.RotateAngle > 0) {
            var ActualHeight = getActaulHeightOfRotatedControl($("#" + controllDetails.ObjectID), controllDetails.RotateAngle)

            if (controllDetails.RotateAngle < 135) {
                ActualHeight = ActualHeight[1]
                $("#" + controllDetails.ObjectID).css('top', ($("#" + controllDetails.ObjectID).position().top / zoomvalue()) + (ActualHeight - controllDetails.MaxHeight * mmConvertionConstant));
            }
            else if (controllDetails.RotateAngle <= 180) {
                ActualHeight = ActualHeight[1] - controllDetails.MaxHeight * mmConvertionConstant

                if (controllDetails.RotateAngle == 180)
                    ActualHeight = -controllDetails.MaxHeight * mmConvertionConstant
                $("#" + controllDetails.ObjectID).css('top', ($("#" + controllDetails.ObjectID).position().top / zoomvalue()) + ActualHeight);
            }
            else if (controllDetails.RotateAngle <= 270) {
                ActualHeight = ActualHeight[1] - controllDetails.MaxHeight * mmConvertionConstant
                $("#" + controllDetails.ObjectID).css('top', ($("#" + controllDetails.ObjectID).position().top / zoomvalue()) - controllDetails.MaxHeight * mmConvertionConstant);
            }
            else if (controllDetails.RotateAngle > 270 && controllDetails.RotateAngle <= 330)
                ActualHeight = controllDetails.MaxHeight * mmConvertionConstant - ActualHeight[0];

        } else {
            $("#" + controllDetails.ObjectID).css('top', $("#" + controllDetails.ObjectID).position().top / zoomvalue());
        }
    }
}

function LoadDefaultContent(Text, id) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    debugger;

    var UserText = Text;


    if (Control.ExceedWidth != "Do Nothing") {
        Control.DefaultContent = UserText;
    }

    var defaultContent = capitalizeTheText(Text, Control.Capitalize);
    //Control.ObjTag = Text;
    var width = $("#" + Control.ObjectID).outerWidth();

    if ($("#" + Control.ObjectID).hasClass('Text')) {

        // $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .labelText").height() + "px" });//Added By Shahbaz on Aug/1/15
        if (defaultContent == "") {
            $("#" + Control.ObjectID + " .label").css({ 'display': 'none' });
        }
        else {
            if (Control.LabelPosition != "customTop") {
                $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block' });
            }
            else {//else added by shahbaz
                $("#" + Control.ObjectID + " .label").css({ 'display': 'block' });
            }
        }

        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        if (Control.LabelPosition == "customTop") {
            LabelWidth = 0;
        }

        if (width > LabelWidth)
            width = width + 2 - LabelWidth;
        var TextWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth;

        var widthonlabelLeft = 0;
        if (Control.LabelPosition == "customRight") {
            var widthonlabelLeft = parseFloat($("#" + Control.ObjectID + " .label").width());
            //widthonlabelLeft = (Control.Width - RightlabelWidth) * mmConvertionConstant;
        }

        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);


        if (Control.ExceedWidth == "Do Nothing") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() + LabelWidth + widthonlabelLeft) > width) {
                while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth + widthonlabelLeft) > width) {
                    defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                    UserText = UserText.substr(0, UserText.length - 1);
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "));
                    $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));
                }
            }

            //Added By shahbaz for reduce text from Textblock if enter text width cross Canvas Width
            //if (Control.Lock) {
            //    if (Control.TextAlign == "Left") {
            //        while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > textCanvasWidth - ((parseFloat(Control.OffsetLeft) - CropMarkWidth) * mmConvertionConstant)) {
            //            defaultContent = defaultContent.substr(0, defaultContent.length - 1);
            //            UserText = UserText.substr(0, UserText.length - 1);
            //            attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
            //            $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "))
            //            $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));
            //        }
            //        // $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "))
            //    }
            //    else if (Control.TextAlign == "Center") {
            //        while (Control.Left * mmConvertionConstant + parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() / 2) > textCanvasWidth) {
            //            defaultContent = defaultContent.substr(0, defaultContent.length - 1);
            //            UserText = UserText.substr(0, UserText.length - 1);
            //            attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
            //            $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "))
            //            $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));
            //        }

            //        //  $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "))
            //    }
            //}

            alignsingleLineText(Control.ObjectID);
            Control.DefaultContent = UserText;
            // changeAlignment(Control.TextAlign);
        }
        else if (Control.ExceedWidth == "Expand side") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) > width) {
                $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
                Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
                Control.Width = Control.MaxWidth;
            }

            //Added By shahbaz for reduce text from Textblock if enter text width cross Canvas Width
            //if (Control.Lock) {
            //    if (Control.TextAlign == "Left") {
            //        while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > textCanvasWidth - (Control.Left * mmConvertionConstant)) {
            //            defaultContent = defaultContent.substr(0, defaultContent.length - 1);
            //            UserText = UserText.substr(0, UserText.length - 1);
            //            attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
            //            $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "))
            //        }
            //    }
            //    else if (Control.TextAlign == "Center") {
            //        while ((Control.Left * mmConvertionConstant) / 2 + parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > textCanvasWidth) {
            //            defaultContent = defaultContent.substr(0, defaultContent.length - 1);
            //            UserText = UserText.substr(0, UserText.length - 1);
            //            attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
            //            $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "))
            //        }
            //    }
            //}
            alignsingleLineText(Control.ObjectID);
            changeAlignment(Control.TextAlign);

        }
        else if (Control.ExceedWidth == "Shrink") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                var fontsize = Fontsize - 0.05;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth + widthonlabelLeft) > width && fontsize > 0) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                    Control.FontSize = font * ptConvertionConstant;
                    $("#txtFontSize").val(font * ptConvertionConstant);


                    if (LabelWidth == null) {
                        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                    }

                    if (parseFloat($("#" + Control.ObjectID).outerHeight()) != 0) {
                        Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                        Control.Height = Control.MaxHeight;
                    }
                    else {
                        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .labelText").outerHeight() + 1) / mmConvertionConstant;
                        Control.Height = Control.MaxHeight;
                    }

                    fontsize = fontsize - 0.05;
                }
            }
            else if (Control.FontSize < Control.OriginalFontSize) {
                var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                var fontsize = Fontsize + 0.05;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth + widthonlabelLeft) < width && Control.FontSize < Control.OriginalFontSize) {
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
                while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth + widthonlabelLeft) > width) {
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

            //Added By shahbaz for reduce text from Textblock if enter text width cross Canvas Width     
            //if (Control.Lock) {
            //    if (Control.TextAlign == "Left") {
            //        if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > textCanvasWidth - (Control.Left * mmConvertionConstant)) {
            //            $("#" + Control.ObjectID).css('max-width', textCanvasWidth - (Control.Left * mmConvertionConstant));
            //        }
            //    }
            //    else if (Control.TextAlign == "Center") {
            //        if (Control.Left * mmConvertionConstant + parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() / 2) > textCanvasWidth) {
            //            $("#" + Control.ObjectID).css('max-width', textCanvasWidth - (Control.Left * mmConvertionConstant) + parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() / 2));
            //        }
            //    }
            //}
            //if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) >= textCanvasWidth - (Control.Left * mmConvertionConstant)) {
            //$("#" + Control.ObjectID).css('max-width', textCanvasWidth - (Control.Left * mmConvertionConstant) - 5);
            //}

            fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
            changeAlignment(Control.TextAlign);
        }
        else if (Control.ExceedWidth == "Tracking" || Control.ExceedWidth == "Track") {
            
            if (Control.MaxShrink > 1)
                Control.MaxShrink = Control.MaxShrink / 10;
            if (Control.MaxShrink == 0) {
                if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                    while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                        defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                        UserText = UserText.substr(0, UserText.length - 1);
                        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                        $("#" + Control.ObjectID + "_txt").val(defaultContent.replace(/&nbsp;/g, " "));
                        $("#dropdownTxt_" + Control.ObjectID).val(defaultContent.replace(/&nbsp;/g, " "));
                    }
                }
                fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign);
                alignsingleLineText(Control.ObjectID);
                Control.DefaultContent = UserText;
                changeAlignment(Control.TextAlign);
            }
            else if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                
                var spacing;
                var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                var letterSpacing = LetterSpacing - Control.MaxShrink;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                    $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                    letterSpacing = letterSpacing - Control.MaxShrink;
                    if (spacing.indexOf("-") > -1) {
                        Control.ManualTrackSign = spacing[0];
                        Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    } else {
                        Control.ManualTrackSign = '+';
                        Control.ManualTracking = parseFloat(spacing.substr(0, spacing.length)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    }
                }
            }
            else if (parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing')) < parseFloat(Control.ManualTracking)) {
                
                var spacing;
                var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                var letterSpacing = LetterSpacing + Control.MaxShrink;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) < width && parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing')) < parseFloat(Control.ManualTracking)) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                    $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                    letterSpacing = letterSpacing + Control.MaxShrink;
                    if (spacing.indexOf("-") > -1) {
                        Control.ManualTrackSign = spacing[0];
                        Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    } else {
                        Control.ManualTrackSign = '+';
                        Control.ManualTracking = parseFloat(spacing.substr(0, spacing.length)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    }
                }
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                    
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                    $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
                    letterSpacing = letterSpacing - Control.MaxShrink;
                    if (spacing.indexOf("-") > -1) {
                        Control.ManualTrackSign = spacing[0];
                        Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    } else {
                        Control.ManualTrackSign = '+';
                        Control.ManualTracking = parseFloat(spacing.substr(0, spacing.length)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    }
                }

                fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign);
                alignsingleLineText(Control.ObjectID);
                changeAlignment(Control.TextAlign);
            }

            fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
            changeAlignment(Control.TextAlign);
        }
        if (Control.GroupID == 0) {
            if (Control.DefaultContent != "") {
                var KeepotionList;
                if (Control.KeepOptions == "None") {

                }
                else {
                    KeepOptionPositioning(Control.ObjectID, Control.KeepOptions);
                }
            } else {
                removeBorderForControl(Control.ObjectID, "TextBlock")
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
        //$("#" + Control.ObjectID + " .paraText").html(defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>").replace(/&nbsp;/g, " "));
        $("#" + Control.ObjectID + " .paraText").html(defaultContent.replace(/&nbsp;/g, " ").replace(/®/g, '<sup>&reg;</sup>').replace(/©/g, '<sup>&copy;</sup>'));
        var Group;
        VerticalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });

        if (typeof Group != 'undefined') {
            if (Group.IsParaGroup && Control.ExceedHeight == "Do Nothing") {
                $("#" + Control.ObjectID).css({ 'height': Control.MaxHeight * mmConvertionConstant });
            }
        }

        if (Control.ExceedHeight == "Do Nothing") {
            if (($("#" + Control.ObjectID + " .paraText").outerHeight() - 2) > ($("#" + Control.ObjectID).outerHeight() + 2)) {
                while (($("#" + Control.ObjectID + " .paraText").outerHeight() - 2) > ($("#" + Control.ObjectID).outerHeight() + 2)) {
                    Text = Text.substr(0, Text.length - 1);
                    $("#" + Control.ObjectID + " .paraText").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>").replace(/&nbsp;/g, " "));
                }
            }
            while ($("#" + Control.ObjectID + " .paraText").outerHeight() - 2 > $("#" + Control.ObjectID).outerHeight()) {
                Text = Text.substr(0, Text.length - 1);
                $("#" + Control.ObjectID + " .paraText").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>").replace(/&nbsp;/g, " "));
                $("#" + Control.ObjectID + "_txt").val(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>"));
                $("#dropdownTxt_" + Control.ObjectID).val(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>"));
            }
            debugger
            Control.DefaultContent = Text;
            $("#" + Control.ObjectID + "_txt").val(Text);
            $("#dropdownTxt_" + Control.ObjectID).val(Text);
        }
        else if (Control.ExceedHeight == "Expand Height" && Control.GroupID == 0 && (Control.KeepOption == "None" || Control.KeepOption == undefined)) {
            SetParaPositionForExpand(Control);
            if (($("#" + Control.ObjectID + " .paraText").outerHeight()) > ($("#" + Control.ObjectID).outerHeight())) {
                var oldHeight = Control.Height;
                $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .paraText").outerHeight() });//changed by shahbaz
                Control.Height = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight()) / mmConvertionConstant;
                Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight()) / mmConvertionConstant;
                getPosition(true);//Added By Shahbaz;             
            }
        }
        if (Control.GroupID == 0) {
            var KeepotionList;
            if (Control.DefaultContent != "") {
                if (Control.KeepOptions != "none") {
                    // KeepotionList = getKeepOptionControlsByObjectIDForVertical(Control.GroupOrientation, Control.KeepOptions); Commented By Shahbaz
                    KeepotionList = KeepOptionPositioning('', Control.KeepOptions); //Added by shahbaz
                }
                else {
                    //KeepotionList = getKeepOptionControlsByObjectIDForHorizontal(Control.GroupOrientation, Control.KeepOptions);
                    // KeepotionList = KeepOptionPositioning(Control.GroupdrpFontOrientation, Control.KeepOptions); //Added by shahbaz
                }
                //if (KeepotionList.length >= 2) {
                //    KeepOptionPositioning(Control.ObjectID, Control.KeepOptions);
                //}
                //else {
                //    if (fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight, Control.TextAlign)) {
                //        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                //        if ($("#" + Control.ObjectID).hasClass('Para')) {
                //            $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
                //        }
                //    }
                //}
            }
            else {
                removeBorderForControl(Control.ObjectID, "Paragraph")
            }
        }
        else {
            if (Control.GroupOrientation == "Vertical") {
                if (Control.DefaultContent != "") {

                    var Group;
                    VerticalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });
                    if (Group.GroupOption == "None" || Group.GroupOption == "") {
                        if (!Group.IsParaGroup)
                            VerticalGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
                        else
                            VerticalParaGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
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
            while (parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerHeight()) > parseFloat(ControllDetails[i].MaxHeight) * mmConvertionConstant && parseFloat($("#" + ControllDetails[i].ObjectID + " img").innerWidth()) > parseFloat(ControllDetails[i].MaxWidth) * mmConvertionConstant) {
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
        if (Button != "btnSavetodraft") {
            if (!chkOtherPageGroup()) {
                $("#Message").dialog("open");
                $("#msg").html("Please review all pages before you add this PDF to cart.");
                designMessageBox();
                $("div[aria-describedby=Message]").css('z-index', '114');
                $(".loadingNewMask").show();
                $(".loading_new").hide();
                return;
            }
        }
        for (var i = 0; i < ControllDetails.length; i++) {
            var control = JSON.stringify(ControllDetails[i]);
            debugger;
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
                },
                async: false
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

            
            $.ajax({
                url: ServicePath + "UpdatePreviewStatus",
                type: "POST",
                data: JSON.stringify({ CartItemId: CartitemID, PDFname: "", _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (resultFromSevice) {
                    if (resultFromSevice.d) {
                        // var url = B2BSitePath + "preview_HTML5.aspx?ID=" + PriceCatalogId + "&CartItemID=" + CartitemID + "&TemplateID=" + TemplateID + "&CompanyID=" + CompanyID;
                        var url = B2BSitePath + "preview_HTML5_V2.aspx?ID=" + PriceCatalogId + "&CartItemID=" + CartitemID + "&TemplateID=" + TemplateID + "&CompanyID=" + CompanyID + "&PreviewType=" + TemplateDetails.PreviewType;
                        window.top.location.href = url;
                        $(".loading_new").hide();
                        //                        var url = "http://localhost:50698/PDFSamples/ServerDataTest.aspx?TemplateID=" + TemplateID + "&SessionID=" + SesionID + "&CompanyID=" + CompanyID;
                        //                        window.open(url, '_blank', 'toolbar=0,location=0,menubar=0');
                    }
                }
            });
        }
        if (Button == "btnPrevious") {
            var url = "";
            if (CType == "public" || CType.indexOf("public") > -1) {
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
                        var url = B2BSitePath + "BlanckPageForCart_HTML5_V2.aspx?ID=" + PriceCatalogId + "&CartItemID=" + CartitemID + "&TemplateID=" + TemplateID + "&CompanyID=" + CompanyID + "&PreviewType=" + TemplateDetails.PreviewType + "&directToCart=true";
                        window.top.location.href = url;
                    }
                }
            });
        }

        if (Button == "btnSaveAndApprove") {


            var OrderID = decodeURIComponent(document.referrer.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent("OrderId").replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));

           
            var url = B2BSitePath + "preview_HTML5_V2.aspx?ID=" + PriceCatalogId + "&CartItemID=" + CartitemID + "&TemplateID=" + TemplateID + "&CompanyID=" + CompanyID + "&PreviewType=" + TemplateDetails.PreviewType + "&UserId=" + UserID + "&OrderID=" + OrderID;
            window.top.location.href = url;
            $(".loading_new").hide();

            //window.top.location.href = B2BSitePath + "order.aspx?OrderID=" + OrderID + "&UserID=" + UserID;

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


function chkOtherPageGroup() {
    var IsViewed = false;

    for (var k = 0; k < PageViewed.length; k++) {
        IsViewed = PageViewed[k].IsViewed;
        if (!IsViewed && PageViewed[k].PageNumber != parseInt($("#lblcurrentpage").html())) {
            var count = 0;
            HorizontalGroupingData.map(function (proj) { if (proj.PageNumber == PageViewed[k].PageNumber) count++; });
            VerticalGroupingData.map(function (proj) { if (proj.PageNumber == PageViewed[k].PageNumber) count++; });
            if (count > 0)
                return IsViewed
            else
                IsViewed = true;
        }
    }
    return IsViewed;
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

function changeSelectedControllID() {
    $("#textCanvas > .controll").each(function () {

        var id = $(this).attr('id');
        if ($("#" + id + ' .paraText').css('border-right-color') == 'rgb(128, 128, 128)' || $("#" + id + ' .labelText').css('border-right-color') == 'rgb(128, 128, 128)' || $("#" + id).css('border-right-color') == 'rgb(128, 128, 128)' || $("#" + id).css('border-right-color') == 'rgb(128, 128, 128)' || $(this).css('border-left-color') == 'rgb(178, 178, 178)') {
            selectedControllID = "#" + id;
            selectedObjectID = id;
        }
    });
}

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
            $("#" + Control.ObjectID + " pre").css('font-family', uniquefontname);
        }
        Control.FontFamily = fontname;
        Control.ActualFontName = ActualfontName;
        Control.FontID = parseFloat(fontid);
        Control.FontExtension = fontpathName;
        //fixPostionOfControll(Control, Control.PositionX, Control.PositionY, Control.TextAlign);//Commented by shahbaz 11/11/2015
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

        fixPostionOfControll(Control, Control.PositionX, Control.PositionY, Control.TextAlign);
        alignsingleLineText(Control.ObjectID);
        //applyContolHeightAccordingToFont(Control);
    }
    if ($("#" + Control.ObjectID).hasClass('Para')) {
        $("#" + Control.ObjectID + " pre").css('font-size', ((parseFloat(Control.FontSize)) / ptConvertionConstant) + "px");
    }
    fixPostionOfControll(Control, Control.PositionX, Control.PositionY, Control.TextAlign);
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
        "isDisplayonPDf": false,
        "DefaultImageFrom": "None",
        "CustomFieldType": "",
        "UsedImageId": "0",
        "IsFromPdf": false,
        "AllowImageEdit": false,
        "IsJobNameField": false,
        "PhoneFormat": "None",
        "CurrencyFormat": "None",
        "EditDropdown": false
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
        "isDisplayonPDf": false,
        "DefaultImageFrom": "None",
        "CustomFieldType": "",
        "UsedImageId": "0",
        "IsFromPdf": false,
        "AllowImageEdit": true,
        "IsJobNameField": false,
        "PhoneFormat": "None",
        "CurrencyFormat": "None",
        "EditDropdown": false
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
        "ExceedHeight": "Do Nothing",
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
        "isDisplayonPDf": false,
        "DefaultImageFrom": "None",
        "CustomFieldType": "",
        "UsedImageId": "0",
        "IsFromPdf": false,
        "AllowImageEdit": false,
        "IsJobNameField": false,
        "PhoneFormat": "None",
        "CurrencyFormat": "None",
        "EditDropdown": false
    }))
    deSelect();
    ControllDetails.push(jsonStringFotText);

    LoadLeftPanelForPara(jsonStringFotText);
    AddParaDynamically(jsonStringFotText, true);
}

function changePositioXY(posXValue, posYValue) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (posXValue.toString() == "NaN")
        posXValue = Control.OffsetLeft
    if (posYValue.toString() == "NaN")
        posYValue = Control.OffsetTop

    //Control.OffsetLeft = $('#txtPostionX').val();
    //Control.OffsetTop = $('#txtPostionY').val();

    Control.OffsetLeft = posXValue;
    Control.OffsetTop = posYValue;

    if (fixPostionOfControll(Control, posXValue, posYValue, Control.TextAlign)) {
        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
        if ($("#" + Control.ObjectID).hasClass('Para')) {
            $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
        }
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

function getPosition(IsParaGroup) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var zoom = zoomvalue();
    var elementHeight = parseFloat($("#" + Control.ObjectID).outerHeight());
    var elementWidth = parseFloat($("#" + Control.ObjectID).outerWidth());

    var Position = $("#" + Control.ObjectID).position();


    var top = (($("#textCanvas").outerHeight()) * zoom) - (parseFloat(Position.top) + (elementHeight * zoom)) + CropMarkHeight * mmConvertionConstant * zoom;
    if (IsParaGroup) {
        if (Control.Type == "Paragraph") {
            top = (($("#textCanvas").outerHeight()) * zoom) - (parseFloat(Position.top) + (Control.MaxHeight * mmConvertionConstant * zoom)) + CropMarkHeight * mmConvertionConstant * zoom;
        }
    }
    var topFinal = (top / zoom) / mmConvertionConstant;
    var leftFinal = parseFloat((Position.left + CropMarkWidth * mmConvertionConstant * zoom) / zoom) / mmConvertionConstant;
    if (Control.Type == "Paragraph") {
        leftFinal = parseFloat((Position.left + 1 * zoom + CropMarkWidth * mmConvertionConstant * zoom) / zoom) / mmConvertionConstant;
    }

    //if (CropMarkWidth > 0)
    //    leftFinal = leftFinal + (CropMarkWidth / zoom)

    //Changed By shahbaz

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

        $("#txtPostionX").val(parseFloat(leftFinal).toFixed(2));
        $("#txtPostionY").val(parseFloat(topFinal).toFixed(2));
        Control.PositionX = parseFloat(leftFinal).toFixed(2);
        Control.PositionY = parseFloat(topFinal).toFixed(2);
        Control.CoordsX = parseFloat(leftFinal).toFixed(2);
        Control.CoordsY = parseFloat(topFinal).toFixed(2);
        Control.OffsetLeft = parseFloat(leftFinal).toFixed(2);
        Control.OffsetTop = parseFloat(topFinal).toFixed(2);


        if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
            Control.Left = parseFloat(leftFinal).toFixed(2);
            Control.Top = parseFloat(topFinal).toFixed(2);
        }


    }
    else if ($("#" + Control.ObjectID).hasClass('Image')) {
        $("#txtPostionX").val(parseFloat(leftFinal).toFixed(2));
        $("#txtPostionY").val(parseFloat(topFinal).toFixed(2));
        Control.PositionX = parseFloat(leftFinal).toFixed(2);
        Control.PositionY = parseFloat(topFinal).toFixed(2);
        Control.CoordsX = parseFloat(leftFinal).toFixed(2);
        Control.CoordsY = parseFloat(topFinal).toFixed(2);
        Control.OffsetLeft = parseFloat(leftFinal).toFixed(2);
        Control.OffsetTop = parseFloat(topFinal).toFixed(2);
        if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
            Control.Left = parseFloat(leftFinal).toFixed(2);
            Control.Top = parseFloat(topFinal).toFixed(2);
        }
        //Control.Left = parseFloat(leftFinal).toFixed(2);
        //Control.Top = parseFloat(topFinal).toFixed(2);
    }


    //Added By shahbaz for set actual position for Control if they rotated
    if (Control.RotateAngle > 0) {
        var RotateDegree = Control.RotateAngle;
        if ($("#" + Control.ObjectID).hasClass("Text")) {
            var PositionX = getWidthOfRotatedTextParaControl(RotateDegree, Control.Width * mmConvertionConstant, Control.Height * mmConvertionConstant);
            var PositionY = getHeightOfRotatedTextParaControl(RotateDegree, Control.Height * mmConvertionConstant, Control.Width * mmConvertionConstant, $("#" + Control.ObjectID));
            if (RotateDegree < 95) {
                topFinal = topFinal - (PositionY / mmConvertionConstant);
                leftFinal = leftFinal + PositionX / mmConvertionConstant;
            }
            else if (RotateDegree <= 180) {

                topFinal = topFinal - (PositionY / mmConvertionConstant);
                if (RotateDegree == 180)
                    topFinal = topFinal - (PositionY / mmConvertionConstant) + Control.Height;

                if (RotateDegree <= 110)
                    leftFinal = leftFinal + Control.Height + (PositionX / mmConvertionConstant);
                else
                    leftFinal = leftFinal + (PositionX / mmConvertionConstant);
            }
            else if (RotateDegree <= 270) {
                topFinal = topFinal + Control.Height;
                if (RotateDegree <= 210)
                    leftFinal = leftFinal + Control.Width - (PositionX / mmConvertionConstant);
                else if (RotateDegree <= 265)
                    leftFinal = leftFinal + PositionX / mmConvertionConstant;
                else
                    leftFinal = leftFinal;
            }
            else if (RotateDegree <= 340) {
                topFinal = topFinal + (Control.Height - (PositionY / mmConvertionConstant));
            }
            //var XPosition = getWidthofRotatedDiv(Control.RotateAngle, Control.Width * mmConvertionConstant);
            //var YPosition = getHeightofRotatedDiv(Control.RotateAngle, Control.Width * mmConvertionConstant);

            //if (RotateDegree < 70) {
            //    var x = getHeightofRotatedDiv(RotateDegree, Control.Width * mmConvertionConstant);
            //    topFinal = (topFinal - x)
            //}
            //else if (RotateDegree >= 70 && RotateDegree <= 85) {
            //    RotateDegree = 60
            //    var x = getHeightofRotatedDiv(RotateDegree, Control.Width * mmConvertionConstant);
            //    topFinal = (topFinal - x)
            //}
            //else if (RotateDegree == 90) {
            //    topFinal = (topFinal - Control.Width)
            //}
            //else {
            //    var y = getWidthofRotatedDiv(RotateDegree, Control.Width * mmConvertionConstant);
            //    var x = getHeightofRotatedDiv(RotateDegree, Control.Width * mmConvertionConstant, y * mmConvertionConstant);
            //    if (RotateDegree <= 180) {
            //        topFinal = (topFinal - x);
            //        leftFinal = (leftFinal + y);
            //    }
            //    else if (RotateDegree <= 270) {
            //        deg = RotateDegree - 180;
            //        if (RotateDegree > 220)
            //            topFinal = (topFinal + (Control.Width - x));
            //        else
            //            topFinal = (topFinal + deg / mmConvertionConstant);
            //        leftFinal = (leftFinal + y);
            //    }
            //}


            Control.PositionY = parseFloat(topFinal).toFixed(4);
            Control.CoordsY = parseFloat(topFinal).toFixed(4);
            Control.OffsetTop = parseFloat(topFinal).toFixed(4);
            //Control.Top = parseFloat(topFinal).toFixed(4);

            Control.PositionX = parseFloat(leftFinal).toFixed(4);
            Control.CoordsX = parseFloat(leftFinal).toFixed(4);
            Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
            //Control.Left = parseFloat(leftFinal).toFixed(4);

            if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                Control.Left = parseFloat(leftFinal).toFixed(4);
                Control.Top = parseFloat(topFinal).toFixed(4);
            }


            $("#txtPostionX").val(parseFloat(leftFinal).toFixed(2));
            $("#txtPostionY").val(parseFloat(topFinal).toFixed(2));
        }


        if ($("#" + Control.ObjectID).hasClass("Para")) {
            if (RotateDegree > 0 && RotateDegree < 360) {
                var PositionX = getWidthOfRotatedTextParaControl(RotateDegree, Control.Width * mmConvertionConstant, Control.Height * mmConvertionConstant);
                var PositionY = getHeightOfRotatedTextParaControl(RotateDegree, Control.Height * mmConvertionConstant, Control.Width * mmConvertionConstant, $("#" + Control.ObjectID));
                if (RotateDegree < 95) {
                    topFinal = topFinal - (PositionY / mmConvertionConstant);
                    leftFinal = leftFinal + PositionX / mmConvertionConstant;
                }
                else if (RotateDegree <= 180) {

                    topFinal = topFinal - (PositionY / mmConvertionConstant);
                    if (RotateDegree == 180)
                        topFinal = topFinal - (PositionY / mmConvertionConstant) + Control.Height;

                    if (RotateDegree <= 110)
                        leftFinal = leftFinal + Control.Height + (PositionX / mmConvertionConstant);
                    else
                        leftFinal = leftFinal + (PositionX / mmConvertionConstant);
                }
                else if (RotateDegree <= 270) {
                    topFinal = topFinal + Control.Height;
                    if (RotateDegree <= 210)
                        leftFinal = leftFinal + Control.Width - (PositionX / mmConvertionConstant);
                    else if (RotateDegree <= 265)
                        leftFinal = leftFinal + PositionX / mmConvertionConstant;
                    else
                        leftFinal = leftFinal;
                }
                else if (RotateDegree <= 340) {
                    topFinal = topFinal + (Control.Height - (PositionY / mmConvertionConstant));
                }

            }

            Control.PositionY = parseFloat(topFinal).toFixed(4);
            Control.CoordsY = parseFloat(topFinal).toFixed(4);
            Control.OffsetTop = parseFloat(topFinal).toFixed(4);
            // Control.Top = parseFloat(topFinal).toFixed(4);

            Control.PositionX = parseFloat(leftFinal).toFixed(4);
            Control.CoordsX = parseFloat(leftFinal).toFixed(4);
            Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
            //Control.Left = parseFloat(leftFinal).toFixed(4);

            if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                Control.Left = parseFloat(leftFinal).toFixed(4);
                Control.Top = parseFloat(topFinal).toFixed(4);
            }

            $("#txtPostionX").val(parseFloat(leftFinal).toFixed(4));
            $("#txtPostionY").val(parseFloat(topFinal).toFixed(4));

        }

        if ($("#" + Control.ObjectID).hasClass("Image")) {
            var RotateDegree = parseInt($("#txtRotate").val());

            if (RotateDegree > 0 && RotateDegree < 360) {
                var PositionX = getWidthOfRotatedRectangularDiv(RotateDegree, Control.Width * mmConvertionConstant, Control.Height * mmConvertionConstant);
                var PositionY = getHeightofRotatedRectangularDiv(RotateDegree, Control.Width * mmConvertionConstant, PositionX, Control.Height * mmConvertionConstant, $("#" + Control.ObjectID))


                if (RotateDegree < 90) {
                    topFinal = topFinal - PositionY / mmConvertionConstant;
                    leftFinal = leftFinal + PositionX / mmConvertionConstant;
                }
                else if (RotateDegree == 90) {
                    topFinal = topFinal - PositionY / mmConvertionConstant;
                    leftFinal = leftFinal + Control.Height;
                }
                else if (RotateDegree <= 110) {
                    topFinal = topFinal - PositionY / mmConvertionConstant;
                    leftFinal = leftFinal + (Control.Height + PositionX / mmConvertionConstant);
                }
                else if (RotateDegree <= 180) {
                    if (RotateDegree <= 135)
                        topFinal = topFinal - PositionY / mmConvertionConstant;
                    else
                        topFinal = topFinal - PositionY / mmConvertionConstant;
                    leftFinal = leftFinal + PositionX / mmConvertionConstant;
                }
                else if (RotateDegree <= 270) {
                    topFinal = topFinal + Control.Width;
                    if (RotateDegree < 240)
                        leftFinal = leftFinal + Control.Height;
                    else if (RotateDegree <= 250)
                        leftFinal = leftFinal - (Control.Height - PositionX / mmConvertionConstant);
                    else
                        leftFinal = leftFinal;
                }
                else if (RotateDegree <= 310) {
                    topFinal = topFinal - (Control.Height - PositionY / mmConvertionConstant);
                }
            }


            Control.PositionX = parseFloat(leftFinal).toFixed(4);
            Control.CoordsX = parseFloat(leftFinal).toFixed(4);
            Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
            //Control.Left = parseFloat(leftFinal).toFixed(4);


            Control.PositionY = parseFloat(topFinal).toFixed(4);
            Control.CoordsY = parseFloat(topFinal).toFixed(4);
            Control.OffsetTop = parseFloat(topFinal).toFixed(4);
            //Control.Top = parseFloat(topFinal).toFixed(4);
            if ($("#" + Control.ObjectID).hasClass('ui-draggable')) {
                Control.Left = parseFloat(leftFinal).toFixed(4);
                Control.Top = parseFloat(topFinal).toFixed(4);
            }

            $("#txtImagePostionX").val(parseFloat(leftFinal).toFixed(4));
            $("#txtImagePostionY").val(parseFloat(topFinal).toFixed(4));
        }


    }


    //if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
    //    Control.PositionX = parseFloat(leftFinal) / zoom;
    //    Control.PositionY = parseFloat(topFinal) / zoom;

    //    if (Control.TextAlign == "Left") {
    //        leftFinal = leftFinal;
    //        if (Control.Labels == "Use Labels" && Control.LabelPosition == "customLeft") {
    //            leftFinal = parseFloat(leftFinal + Control.CustomLeft);
    //        }
    //    }
    //    else if (Control.TextAlign == "Center") {
    //        leftFinal = parseFloat(leftFinal + ((elementWidth) / 2));
    //    }
    //    else if (Control.TextAlign == "Right") {
    //        leftFinal = parseFloat(leftFinal + (elementWidth));
    //    }

    //    $("#txtPostionX").val(((parseFloat(leftFinal) / zoom)).toFixed(2));
    //    $("#txtPostionY").val(((parseFloat(topFinal) / zoom)).toFixed(2));

    //    Control.OffsetLeft = parseFloat(leftFinal) / zoom;
    //    Control.OffsetTop = parseFloat(topFinal) / zoom;

    //}
    //else if ($("#" + Control.ObjectID).hasClass('Image')) {
    //    Control.PositionX = parseFloat(leftFinal) / zoom;
    //    Control.PositionY = parseFloat(topFinal) / zoom;
    //    $("#txtPostionX").val(((parseFloat(leftFinal) / zoom)).toFixed(2));
    //    $("#txtPostionY").val(((parseFloat(topFinal) / zoom)).toFixed(2));
    //    Control.OffsetLeft = parseFloat(leftFinal) / zoom;
    //    Control.OffsetTop = parseFloat(topFinal) / zoom;
    //}


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
                    $("#" + Control.ObjectID + " pre").css('font-weight', 'bold');
                }
                $("#btnBold").addClass('menubuttonSelected');
                Control.FontWeight = "Bold";
            }
            else {
                if ($("#" + Control.ObjectID).hasClass('Text')) {
                    $("#" + Control.ObjectID + " .labelText").css('font-weight', 'normal');
                }
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " pre").css('font-weight', 'normal');
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
                    $("#" + Control.ObjectID + " pre").css('font-style', 'italic');
                }
                $("#btnItalic").addClass('menubuttonSelected');
                Control.FontStyle = "Italic";
            }
            else {
                if ($("#" + Control.ObjectID).hasClass('Text')) {
                    $("#" + Control.ObjectID + " .labelText").css('font-style', 'normal');
                }
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " pre").css('font-style', 'normal');
                }
                $("#btnItalic").removeClass('menubuttonSelected');
                Control.FontStyle = "Normal";
            }

        }
    }
    if ($("#" + Control.ObjectID).hasClass('Text')) {
        //Commented By Shahbazs
        //$("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('line-height'));
        //$("#" + Control.ObjectID).css('line-height', $("#" + Control.ObjectID + " .labelText").css('line-height'));
        //Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant;
        //Control.Height = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant;
    }

}

function changeAlignment(align) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if (align.toLowerCase() == "left") {
            if (fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, "Left")) {
                $(selectedControllID).css('text-align', 'left');
                $(selectedControllID + " .paraText").css('text-align', 'left');
                if (Control.LabelPosition == "customTop") {
                    $("#" + Control.ObjectID + " .labelText").css({ 'right': 'auto', 'left': -1 + 'px', 'text-align': 'left' });
                    $("#" + Control.ObjectID + " .label").css({ 'margin': '0px', 'width': 'auto', 'text-align': 'left' });
                }
                Control.TextAlign = "Left";
                alignsingleLineText(Control.ObjectID);
                $("#btnLeftAlign").addClass('menubuttonSelected');
                $("#btnCenterAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
            }
        }
        else if (align.toLowerCase() == "center") {
            if (fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, "Center")) {
                $(selectedControllID).css('text-align', 'center');
                $(selectedControllID + " .paraText").css('text-align', 'center');
                Control.TextAlign = "Center";
                alignsingleLineText(Control.ObjectID);
                if (Control.LabelPosition == "customTop") {
                    var mar = (Control.Width * mmConvertionConstant / 2) - ((parseFloat($("#" + Control.ObjectID + " .labelText").width())) / 2);
                    $("#" + Control.ObjectID + " .labelText").css({ 'right': 'auto', 'left': mar - 1 + 'px', 'text-align': 'center' });
                }

                $("#btnCenterAlign").addClass('menubuttonSelected');
                $("#btnLeftAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
            }
        }
        else if (align.toLowerCase() == "right") {
            if (fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, "Right")) {
                $(selectedControllID).css('text-align', 'right');
                $(selectedControllID + " .paraText").css('text-align', 'right');
                Control.TextAlign = "Right";
                alignsingleLineText(Control.ObjectID);
                if (Control.LabelPosition == "customTop") {
                    $("#" + Control.ObjectID + " .labelText").css({ 'left': 'auto', 'right': '0px', 'text-align': 'right' });
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

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    var left = 0;
    if (Control.Type == "TextBlock" || Control.Type == "Paragraph") {
        switch (Control.TextAlign.toLowerCase()) {
            case "center":
                left = (Control.MaxWidth * mmConvertionConstant) / 2;
                break;
            case "right":
                left = Control.MaxWidth * mmConvertionConstant;
                break;
            default:
                left = 0;
        }
    }

    var rotationx = 0 - rotation;
    $(selectedControllID).css({
        'transform-origin': left + "px bottom",
        '-webkit-transform-origin': left + "px bottom",
        '-moz-transform-origin': left + "px bottom",
        '-mz-transform-origin': left + "px bottom",
        '-webkit-transform': 'rotate(' + rotationx + 'deg)',
        '-moz-transform': 'rotate(' + rotationx + 'deg)',
        '-ms-transform': 'rotate(' + rotationx + 'deg)',
        'transform': 'rotate(' + rotationx + 'deg)'
    });
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.RotateAngle = rotation;
}

var ParentCategoryIDs = [];
function createFolderStructureForSytemGallery(FolderAndFiles, CategoryID, ParentID, Search) {
    var thumnailHtml = "";
    var editcategory = false;
    $("#thumNail").empty();
    if (Search) {
        var count = true;
        for (var i = 0; i < FolderAndFiles.length; i++) {
            //ParentID = FolderAndFiles.ImageGallery[i].CategoryID;
            count = false;
            thumnailHtml += "<span style='margin:15px 20px 25px 0px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;' >";
            thumnailHtml += "<div title='Click to assign' id='file_" + FolderAndFiles[i].ImageID + "' class='file HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
            thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;' src='";
            if (FolderAndFiles[i].FileName.split('.')[1].toLowerCase() == "pdf") {
                thumnailHtml += SiteImages + "/processing.png'";
            }
            else {
                thumnailHtml += BackgroundImagesPath + "Gallery/ThumbnailImages/t_" + FolderAndFiles[i].FileName + "'";
            }
            thumnailHtml += "' /></div>";
            thumnailHtml += "<pre style='margin:0px;float:left;'><span style='font-size:12px;font-family:arial;padding-top:5px;padding-left:5px;' title='" + FolderAndFiles[i].OriginalFileName + "'>";
            var FileName = FolderAndFiles[i].OriginalFileName;
            if (FolderAndFiles[i].OriginalFileName.length > 12) {
                FileName = FileName.substr(0, 12) + "...";
            }
            thumnailHtml += FileName + "</span></pre></div></span>";
        }
        if (count) {
            thumnailHtml = "<span style='font-family:arial;font-size:12px;'>No Images to display</span>";
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
        thumnailHtml = "<span style='font-family:arial;font-size:12px;'>There are no images in this gallery</span>";
        $(".txtSearchText").val("");
        $("#btnSelectAll").hide();
        $("#btnDeletetAll").hide();
        $("#btnSaveImage").hide();
        $("#btnSaveImage").after("<span class='helper'>&nbsp;</span>");
    }
    else {
        $(".txtSearchText").val("");
        var count = true;
        $("#Gallery").css({ 'padding-bottom': '10px' });
        var ParentCategory = [];
        FolderAndFiles.ImageCategories.map(function (proj) { if (ParentCategoryIDs.indexOf(proj.CategoryID) < 0) ParentCategoryIDs.push(proj.CategoryID); });
        FolderAndFiles.ImageCategories.map(function (proj) { ParentCategory.push(proj.CategoryID); });
        for (var i = 0; i < FolderAndFiles.ImageCategories.length; i++) {
            //if (FolderAndFiles.ImageCategories[i].ParentID == parseInt(CategoryID)) {
            if (ParentCategory.indexOf(FolderAndFiles.ImageCategories[i].ParentID) < 0) {
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
            FolderAndFiles.ImageGallery.map(function (proj) { if (ParentCategoryIDs.indexOf(proj.CategoryID) < 0) ParentCategoryIDs.push(proj.CategoryID); });
            var CategoryDoesNotExits = true;
            FolderAndFiles.ImageCategories.map(function (proj) { if (proj.CategoryID == FolderAndFiles.ImageGallery[i].CategoryID) CategoryDoesNotExits = false });
            if (FolderAndFiles.ImageGallery[i].CategoryID == parseInt(CategoryID) || CategoryDoesNotExits) {
                //ParentID = FolderAndFiles.ImageGallery[i].CategoryID;
                count = false;
                thumnailHtml += "<span style='margin:15px 20px 25px 15px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;'>";
                thumnailHtml += "<div title='Click to assign' id='file_" + FolderAndFiles.ImageGallery[i].ImageID + "' class='file HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
                thumnailHtml += "<div style='width:100%;text-align:center;height:100%;vertical-align:middle;'><span style='width:0px;height:100%;display:inline-block;vertical-align:middle;'></span><img style='max-height:100px;max-width:100px;vertical-align:middle;' src='";
                if (FolderAndFiles.ImageGallery[i].FileName.split('.')[1].toLowerCase() == "pdf") {
                    thumnailHtml += SiteImages + "/processing.png'";
                }
                else {
                    thumnailHtml += BackgroundImagesPath + "Gallery/ThumbnailImages/t_" + FolderAndFiles.ImageGallery[i].FileName + "'";
                }

                thumnailHtml += "' /></div>";
                thumnailHtml += "<pre style='margin:0px;float:left;'><span style='font-size:12px;font-family:arial;padding-top:5px;padding-left:5px;' title='" + FolderAndFiles.ImageGallery[i].OriginalFileName + "'>";
                var FileName = FolderAndFiles.ImageGallery[i].OriginalFileName;
                if (FolderAndFiles.ImageGallery[i].OriginalFileName.length > 14) {
                    FileName = FileName.substr(0, 14) + "...";
                }
                thumnailHtml += FileName + "</span></pre></div></span>";
            }
        }
        if (count) {
            thumnailHtml = "<span style='font-family:arial;font-size:12px;'>There are no images in this gallery</span>";
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
        $(".btnBack").attr('data-id', CategoryID);
        $(".txtSearchText").attr('id', 'SystemGallery_' + CategoryID);
    }
    $("#btnSelectAll").hide();
    $("#btnUnSelectAll").hide();
    $("#btnDeletetAll").hide();
    $(".txtSearchText").unbind("keyup").bind("keyup", function (e) {
        if (e.which == 13) {
            if ($(".txtSearchText").val() == "") {
                loadSystemFilesAndFolders($(".txtSearchText").attr('id').split('_')[1]);
            }
            else {
                var CategoryIds = "0,";
                if (typeof ParentCategoryIDs != 'undefined') {
                    for (var i = 0; i < ParentCategoryIDs.length; i++) {
                        CategoryIds += ParentCategoryIDs[i] + ",";
                    }
                    searchByText($(this).val(), CategoryIds.substring(0, CategoryIds.length - 1), $(this).attr('id').split('_')[0]);
                } else {

                    searchByText($(this).val(), $(this).attr('id').split('_')[1], $(this).attr('id').split('_')[0]);
                }
            }
        }
        else {
            e.stopPropagation();
            e.preventDefault();
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
        var folderCatID = parseInt($(this).attr('data-id'));
        if (AssignedFolderAndImageList.indexOf(folderCatID) > -1) {
            loadSystemFilesAndFolders(0);
        }
        else
            loadSystemFilesAndFolders(catid);
    });

    $('.file').unbind('click').bind('click', function () {
        $(".loading_gallery").show();
        var imageid = $(this).attr('id').split('_')[1];
        if (Search) {
            for (var i = 0; i < FolderAndFiles.length; i++) {
                if (FolderAndFiles[i].ImageID == parseInt(imageid)) {
                    assignImage(FolderAndFiles[i].FileName, "system", imageid, FolderAndFiles[i].IsPdfImage);
                    break;
                }
            }
        }
        else {
            for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {
                if (FolderAndFiles.ImageGallery[i].ImageID == parseInt(imageid)) {
                    assignImage(FolderAndFiles.ImageGallery[i].FileName, "system", imageid, FolderAndFiles.ImageGallery[i].IsPdfImage);
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
    $("#btnUnSelectAll").hide();
    $("#btnDeletetAll").show();
    if (Search) {
        var count = true;
        for (var i = 0; i < FolderAndFiles.length; i++) {
            count = false;
            thumnailHtml += "<span style='margin:15px 20px 25px 0px;display:inline-block;width:120px;vertical-align:top;cursor:pointer;Position:relative;'><div title='Click to assign' id='file_" + FolderAndFiles[i].ImageID + "' class='file HoverFunction' style='width:120px;height:110px;border:1px solid #A2ADB8;border-radius:2px;background:linear-gradient(#FFFFFF,#CCD3D8);Position:relative;-webkit-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);-moz-box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);box-shadow: inset 0px 0px 0px 1px rgba(255,255,255,1);'>";
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
            thumnailHtml = "<span style='font-family:arial;font-size:12px;'>No images to display</span>";
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
        thumnailHtml += "<span style='font-family:arial;font-size:12px;'>There are no images in this gallery</span>";
        $(".txtSearchText").val("");
        $("#btnSelectAll").hide();
        $("#btnDeletetAll").hide();
        $("#btnSaveUserAndClose").hide();
        $('#btnUserShowMore').hide();
        $("#btnSaveUserAndClose").after("<span class='helper'>&nbsp;</span>");
    }
    else {
        $(".txtSearchText").val("");
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
            thumnailHtml += "<div id='editdelete_" + FolderAndFiles.ImageGallery[i].ImageID + "' style='position:absolute;bottom:0px;left:0px;width:100%;height:20px;cursor:default;padding-top:1px;background-color:#797979;border-bottom-left-radius:1px;border-bottom-right-radius:1px;display:none;'  ><span class='EditDeleteFileFolder EditFile' title='Edit' id='editFile_" + FolderAndFiles.ImageGallery[i].ImageID + "' style='float:left;margin-left:10px;margin-top:2px;'>Edit</span><span title='Delete' class='EditDeleteFileFolder DeleteFile' style='float:right;margin-right:10px;margin-top:2px;' id='deleteFile_" + FolderAndFiles.ImageGallery[i].ImageID + "'>Delete</span></div></div>";
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
                        assignImage(FolderAndFiles[i].FileName, "user", imageid, FolderAndFiles[i].IsPdfImage);
                        break;
                    }
                }
            }
            else {
                for (var i = 0; i < FolderAndFiles.ImageGallery.length; i++) {
                    if (FolderAndFiles.ImageGallery[i].ImageID == parseInt(imageid)) {
                        assignImage(FolderAndFiles.ImageGallery[i].FileName, "user", imageid, FolderAndFiles.ImageGallery[i].IsPdfImage);
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
        $(".loadingNewMask").css('z-index', '102').show();
        // $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });
        var imageid = $(this).attr('id').split('_')[1];
        editImageDetails(FolderAndFiles, imageid, Search);

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
            //loadFolderAndFilesBycategory("", $("#drpCategoryForImage").val());
        });
        $(".lnkchangeImage").unbind('click').bind('click', function () {
            $("#UploadImage").dialog('open');
            $(".QuickAdjustloadingNewMask").css('z-index', '103').show();
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

                    var file = $('#UpadeInputfile').prop("files");
                    $("#filenamespan").html(file[0].name);
                    var ext = file[0].name.split('.')[1].toLowerCase();
                    if (ext == "pdf" || ext == "png" || ext == "jpeg" || ext == "jpg") {
                        var GUID = Guid().substr(0, 5);
                        filelistSingle += GUID + "~" + file[0].name + "~" + parseInt(file[0].size);
                    }
                    else {
                        $('#UpadeInputfile').val("");
                    }
                });
                $(".btnUpdateImage").unbind('click').bind('click', function () {

                    if (filelistSingle == "") {
                        $("#MandatoryMessage").dialog("open");
                        $("#mandatorymsg").html("Please select file to upload");
                        designMessageBox();
                        // $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                        $(".UploadFileloadingNewMask").css('z-index', '104').show();
                        return false;
                    }
                    else {
                        $(".btnUpdateImageloading").css('display', 'inline-block');
                        $(".btnUpdateImage").hide();
                        var form_data = new FormData();

                        var objFiles = $("input#UpadeInputfile").prop("files");

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
                                jQuery.each($('#UpadeInputfile')[0].files, function (i, file) {
                                    form_data.append('file-' + i, file);
                                });
                                $.ajax({
                                    url: mainSitePath + "uploadhandler.ashx/ProcessRequest?Zoom=" + zoom + "&CompanyID=" + CompanyID + "&Dbkey=" + DBKey + "&ImageUploadPath=" + FrontEndUploadPath + "&UploadFileNames=" + filelistSingle + "," + "&CategoryID=" + $("#drpSelectCategory").val() + "&TemplateID=" + TemplateID + "&UserID=" + UserID + "&isChecked=true",
                                    cache: false,
                                    contentType: false,
                                    processData: false,
                                    data: form_data,
                                    type: 'post',
                                    success: function () {
                                        filename = filename.replace(".pdf", ".png").replace(".PDF", ".png");
                                        originalfilename = originalfilename.replace(".pdf", "");

                                        $(".btnUpdateImageloading").hide();
                                        $(".btnUpdateImage").show();
                                        $("#UploadImage").dialog('close');
                                        //loadFolderAndFilesBycategory("editimage", $("#drpCategoryForImage").val(), imageid);Commented By shahabz
                                        /*Added By shahbaz*/
                                        $("#txtImageName").val(originalfilename);
                                        $("#imgEditImage").attr('src', FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + filename);
                                        loadUserFilesAndFolders($("#drpCategoryForImage").val());
                                        $("#usergallerylink").trigger('click');

                                    },
                                    error: function () {
                                        if (parseFloat(filesize) > 2097152.00) {

                                            filename = filename;
                                            originalfilename = originalfilename.replace(".pdf", "").replace(".PDF", "");
                                            $("#txtImageName").val(originalfilename);
                                            $("#imgEditImage").attr('src', "StyleSheets/Images//processing.png");
                                            $(".btnUpdateImageloading").hide();
                                            $(".btnUpdateImage").show();
                                            $("#UploadImage").dialog('close');
                                        }
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

    $("#btnDeletetAll").unbind('click').bind('click', function () {
        var deletecategoryids = "", deleteimageids = "";
        $("#userthamnail").find(".FolderSelectChk").each(function () {
            if ($(this).prop('checked') == true) {
                deletecategoryids += $(this).attr('id').split('_')[1] + ",";
            }
        });
        $("#userthamnail").find(".FileSelectChk").each(function () {
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
                    data: JSON.stringify({ categoryids: deletecategoryids, imageids: deleteimageids, templateid: parseInt(TemplateID), companyid: parseInt(CompanyID), objectid: selectedObjectID, _key: DBKey }),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        //if (result.d == 0) {
                        //    $("#Message").dialog("open");
                        //    $("#msg").html("<span>You can not delete, it is assigned to object in system.</span>");
                        //    designMessageBox();
                        //    $(".loading_gallery").hide();
                        //    $(".QuickAdjustloadingNewMask").show();
                        //    return false;
                        //}
                        //else {
                        //loadUserFilesAndFolders(0, -1);
                        loadUserFilesAndFolders($(".txtSearchText").attr('id').split('_')[1]);
                        //}
                    },
                });
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

                    width = parseInt($("#" + Control.ObjectID).outerWidth());
                    height = parseInt($("#" + Control.ObjectID).outerHeight());


                    for (var k = 0; k < FolderAndFiles.ImageGallery.length; k++) {
                        if (FolderAndFiles.ImageGallery[k].ImageID == parseInt(defaultid)) {
                            fileName = FolderAndFiles.ImageGallery[k].FileName;
                        }
                    }

                    //if (Control.IsImageQuality) {
                    //    $.ajax({
                    //        url: WebMethodsPath + "checkImageForDPI",
                    //        type: "POST",
                    //        data: JSON.stringify({ OriginalImageName: Control.OrignalImageName, isEdited: "false", ischecked: "false", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI }),
                    //        dataType: "json",
                    //        processData: false,
                    //        contentType: "application/json; charset=utf-8",
                    //        success: function (DPIResult) {
                    //            if (DPIResult.d == "success") {
                    //                LoadImage();
                    //            }
                    //            else {
                    //                $("#SaveMessage").dialog("open");
                    //                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
                    //                designMessageBox();
                    //                $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                    //                $(".loadingNewMask").show();
                    //                $(".loading_new").hide();
                    //            }
                    //        }
                    //    });
                    //}
                    //else {
                    //    LoadImage();
                    //}

                    //function LoadImage() {

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
                            // alert(Control.IsCropped);
                            exceedimage = Control.ExceedImage;
                            if (Control.DefaultImageFrom.toLowerCase() != "none")
                                Control.DefaultImageFrom = "None";
                            if (Control.BackgroundImage != "") {
                                $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                                Control.BackgroundImage = arry[0];
                            } else {

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
                                            $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
                                        }
                                    }
                                }
                                if (exceedimage == "D") {
                                    var arry = Control.ImgUrl.split('.');
                                    var imageanme = arry[0].split('-');
                                    //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + imageanme[0] + "." + arry[1]);
                                    checkforImage(imageanme[0] + "." + arry[1]);
                                }
                            }


                            $("#fileList").empty();
                            $("#multipleFileUpload").val("");
                            $("#galleryLink").trigger('click');
                            //loadFolderAndFilesBycategory(false, $("#drpSelectCategory").val());

                            alignsingleImage(Control.ObjectID);

                        }

                    });
                    //}
                }
                else {
                    $(".loading_new").hide();
                }
            }
        });
    });

    $(".EditCategory").unbind('click').bind('click', function () {

        $("#EditCategory").dialog('open');
        $(".loadingNewMask").css('z-index', '102').show();
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
        // $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });

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
    $("#tabs .ui-widget-header").css({ 'background': 'none', 'background-image': 'none', 'border': '0px', 'background-color': 'inherit' });//Added By Shahbaz
    $("li[aria-labelledby=fileUploadLink]").css({ 'background': 'none', 'background-color': '#F2F4F5' });//Added By Shahbaz
    $("li[aria-labelledby=galleryLink]").css({ 'background': 'none', 'background-color': '#F2F4F5' });//Added By Shahbaz
    $("li[aria-labelledby=usergallerylink]").css({ 'background': 'none', 'background-color': '#F2F4F5' });//Added By Shahbaz
    //$('.ui-tabs-nav').css({ 'margin-bottom': '0px', 'height': '30px', 'padding': '0px', 'background': 'none', 'background-color': 'transparent', 'border': '0px', 'border-radius': '0px', 'background': 'transparent' });
    //$(".ui-tabs-nav .ui-state-default a").css({ 'font-size': '14px', 'font-family': 'arial', 'font-weight': 'bold' });
    //$(".ui-tabs-nav .ui-state-default").css({ 'height': '28px', 'z-index': '11', 'background': 'none', 'background-color': 'white', 'border': '0px solid #a9a9a9' });
    $(".ui-tabs-nav .ui-tabs-active").css({ 'height': '20px', 'z-index': '11', 'background': 'none', 'background-color': '#F3F6F7', 'border': '1px solid #a9a9a9', 'border-bottom-width': '0px' });
    $(".ui-tabs-nav li").css({ 'height': '20px', 'margin-top': '4px', 'z-index': '11' });
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
        $("#usergallerylink").show();
    }
    else {
        $("li[aria-labelledby=usergallerylink]").hide();
        //$("#fileUploadLink").hide();
        $("li[aria-labelledby=fileUploadLink]").hide();
        // $("#usergallerylink").hide();
    }

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
        $("#txtNewCategoryName").val("");
        $(".loadingNewMask").css('z-index', '102').show();
        // $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });

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
                    insertCategory.data = JSON.stringify({ companyid: CompanyID, categoryname: $("#txtNewCategoryName").val(), description: "", parentid: $("#drpForCreateCategory").val(), categoryimage: "", createdby: UserID, _key: DBKey });
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
            $("#selectCat").css('padding', '3px');
            $("#selectCat").show();
        }
        else {
            $("#selectCat").css('padding', '5px');
            $("#selectCat").hide();
        }
    });

    $("#btnSelectFiles").unbind('click').bind('click', function () {
        //$("#multipleFileUpload").trigger('click');
        $("#multipleFileUpload")[0].click();
    });

    $("#multipleFileUpload").unbind('change').bind('change', function () {

        totalSize = 0;
        var files = $('#multipleFileUpload').prop("files");

        //Adding selected file to an array
        for (var i = 0; i < files.length; i++) {
            File.push(files[i]);
        }

        //var filerdr = new FileReader();
        var names = $.map(File, function (val) { return val.name; });
        var size = $.map(File, function (val) { return val.size; });
        $("#fileList").empty();
        filelist = "";
        for (var i = 0; i < names.length; i++) {
            var sizeInKB = parseFloat(parseInt(size[i]) / 1024).toFixed(2);
            var ext = names[i].split('.')[names[i].split('.').length - 1].toLowerCase().replace(/'.'/, "");
            if (ext == "pdf" || ext == "png" || ext == "jpeg" || ext == "jpg") {
                var GUID = Guid().substr(0, 5);
                if (names[i].split('.').length > 2) {
                    names[i] = names[i].split('.')[0] + "." + names[i].split('.')[names[i].split('.').length - 1];
                }
                filelist += GUID + "~" + names[i] + "~" + parseInt(size[i]) + ",";
                $("#fileList").append("<div id='div_" + i + "' class='Filestoupload'><img src='" + SiteImages + "close-gray1.png' width='14px' height='14px' title='Remove the image' class='delefile' id='" + i + ":" + sizeInKB + ":" + names[i] + "' /><span style='float:right;margin-right:10px;'>" + sizeInKB + " KB</span><label class='lblOverflow' title='" + names[i] + "'>" + names[i] + "</label></div>");

                totalSize += parseFloat(sizeInKB);
            }

        }
        filelist = filelist.substr(0, filelist.length - 1);
        changetotalSize(totalSize);

        if (filelist.length > 0) {
            $("#btnuploadtxt").html("Add more files");
            $("#btnSelectFiles").css({ 'width': '80px', 'margin-left': '243px' });
        }
        else {
            $("#btnuploadtxt").html("Browse");
            $("#btnSelectFiles").css({ 'width': '45px', 'margin-left': '275px' });
        }

        $(".delefile").unbind('click').bind('click', function () {
            var filelistarry = filelist.split(',');
            var minus = parseFloat($(this).attr('id').split(':')[1]);
            $("#div_" + $(this).attr('id').split(':')[0]).remove();
            totalSize = totalSize - minus;
            changetotalSize(Math.abs(totalSize));


            var deletedFileName = $(this).attr('id').split(':')[2];
            var deleted = false;
            for (var k = 0; k < File.length; k++) {
                if (File[k].name == deletedFileName && deleted == false) {
                    File.splice(File.indexOf(File[k]), 1);
                    break;
                }
            }

            filelist = "";
            for (var j = 0; j < filelistarry.length; j++) {
                if (filelistarry[j].split('~')[1] != $(this).attr('id').split(':')[2]) {
                    filelist += filelistarry[j] + ",";
                }
            }
            filelist = filelist.substr(0, filelist.length - 1);


            if (filelist.length == 0) {
                $("#btnuploadtxt").html("Browse");
                $("#totalContainer").hide();
                $("#btnSelectFiles").css({ 'width': '45px', 'margin-left': '275px' });
                $("input#multipleFileUpload").val("");
                File = [];
            }
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

            //jQuery.each($('#multipleFileUpload')[0].files, function (i, file) {
            //    form_data.append('file-' + i, file);
            //});

            for (var k = 0; k < File.length; k++) {
                form_data.append('file-' + k, File[k]);
            }
            File = [];
            $("input#multipleFileUpload").val("");
            $("#btnuploadtxt").html("Browse");
            $("#btnSelectFiles").css({ 'width': '45px', 'margin-left': '275px' });

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
                        $("#fileList").empty();
                        filelist = "";
                        $('#multipleFileUpload').val("");
                        $("#chkSvaeImagetomyGallery").prop('checked', false);
                        $("#selectCat").hide();
                        $("#totalContainer").hide();
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
            //jQuery.each($('#multipleFileUpload')[0].files, function (i, file) {
            //    form_data.append('file-' + i, file);
            //});

            for (var k = 0; k < File.length; k++) {
                form_data.append('file-' + k, File[k]);
            }
            File = [];
            $("input#multipleFileUpload").val("");
            $("#btnuploadtxt").html("Browse");
            $("#btnSelectFiles").css({ 'width': '45px', 'margin-left': '275px' });


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
                    if (arry[1].indexOf(".pdf") > -1) {
                        Control.IsFromPdf = true;
                        Control.DefaultImageFrom = "FromPdf";
                    }
                    else {
                        Control.IsFromPdf = false;
                        Control.DefaultImageFrom = "";
                    }
                    width = parseInt(Control.Width * mmConvertionConstant);
                    height = parseInt(Control.Height * mmConvertionConstant);

                    width = parseInt($("#" + Control.ObjectID).outerWidth());
                    height = parseInt($("#" + Control.ObjectID).outerHeight());

                    exxceeimage = Control.ExceedImage;

                    var fileName = arry[0] + "_" + arry[1];

                    //if (Control.IsImageQuality) {
                    //    $.ajax({
                    //        url: WebMethodsPath + "checkImageForDPI",
                    //        type: "POST",
                    //        data: JSON.stringify({ OriginalImageName: fileName, isEdited: "false", ischecked: "false", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI }),
                    //        dataType: "json",
                    //        processData: false,
                    //        contentType: "application/json; charset=utf-8",
                    //        success: function (DPIResult) {
                    //            if (DPIResult.d == "success") {
                    //                LoadImage();
                    //            }
                    //            else {
                    //                $("#SaveMessage").dialog("open");
                    //                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
                    //                designMessageBox();
                    //                $("div[aria-describedby=SaveMessage]").css('z-index', '114');
                    //                $(".loadingNewMask").show();
                    //                $(".loading_gallery").hide();
                    //            }
                    //        }
                    //    });
                    //}
                    //else {
                    //    LoadImage();
                    //}

                    //function LoadImage() {

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
                            Control.EditedImageName = "";
                            Control.UsedImageId = 0;
                            Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                            Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
                            Control.IsCropped = Boolean(arry[5]);
                            //if (Control.DefaultImageFrom != "None")
                            //    Control.DefaultImageFrom = "None"

                            //  alert(Control.IsCropped);
                            if (Control.BackgroundImage != "") {
                                $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                                Control.BackgroundImage = arry[0];
                            }
                            else
                                $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'position': 'absolute', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });

                            Control.MaxWidth = parseInt($("#" + Control.ObjectID + " img").innerWidth() / mmConvertionConstant);
                            Control.MaxHeight = parseInt($("#" + Control.ObjectID + " img").innerHeight() / mmConvertionConstant);
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
                        Control.EditedImageName = "";
                        Control.UsedImageId = 0;
                        //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
                        $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + fileName);
                        $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                        //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + Control.ImgUrl);
                        $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                        Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                        if (fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign)) {
                            $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                            if ($("#" + Control.ObjectID).hasClass('Para')) {
                                $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
                            }
                        }

                        if (Control.BackgroundImage != "") {
                            var _ctrlH = textCanvasHeight / mmConvertionConstant;
                            var _ctrlW = textCanvasWidth / mmConvertionConstant;

                            SetImageAsBackgroud(_ctrlH, _ctrlW);
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
                        Control.EditedImageName = "";
                        Control.UsedImageId = 0;
                        //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });


                        var tmpImgDoNothing = new Image();
                        tmpImgDoNothing.src = FrontEndDocumentPath + TemplateID + "/Images/" + fileName;
                        $(tmpImgDoNothing).on('load', function () {
                            var orgWidth = this.width;
                            var orgHeight = this.height;
                            $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + fileName);
                            $("#" + Control.ObjectID).css({ 'width': orgWidth + 'px', 'height': orgHeight + 'px' });
                            $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                            $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                            Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                            Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                            Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
                            Control.Width = parseFloat($("#" + Control.ObjectID).innerWidth()) / mmConvertionConstant;
                            if (fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign)) {
                                $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                                if ($("#" + Control.ObjectID).hasClass('Para')) {
                                    $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
                                }
                            }

                            if (Control.BackgroundImage != "") {
                                var _ctrlH = textCanvasHeight / mmConvertionConstant;
                                var _ctrlW = textCanvasWidth / mmConvertionConstant;

                                SetImageAsBackgroud(_ctrlH, _ctrlW);
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
                    //}
                }
            });

        }

    });
}

var AssignedFolderAndImageList = [];

function loadSystemFilesAndFolders(CategoryID, objectid) {
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
                if (AssignedFolderAndImageList.length == 0) {
                    FolderAndFiles.ImageCategories = sortJSON(FolderAndFiles.ImageCategories, "CategoryID", "ASC");
                    for (var i = 0; i < FolderAndFiles.ImageCategories.length; i++) {
                        if (AssignedFolderAndImageList.length > 0 && AssignedFolderAndImageList.indexOf(FolderAndFiles.ImageCategories[i].ParentID) > -1) {
                            //do nothing
                        }
                        else {
                            AssignedFolderAndImageList.push(FolderAndFiles.ImageCategories[i].CategoryID);
                        }
                    }
                }
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

function editImageDetails(FolderAndFiles, id, Search) {
    if (typeof Search == 'undefined' || Search == false)
        FolderAndFiles = FolderAndFiles.ImageGallery;
    for (var i = 0; i < FolderAndFiles.length; i++) {
        if (FolderAndFiles[i].ImageID == parseInt(id)) {

            $("#txtImageName").val(FolderAndFiles[i].OriginalFileName);
            $("#txtMetaTags").val(FolderAndFiles[i].MetaTags);
            $("#txtEditDescription").val(FolderAndFiles[i].Description);
            if (FolderAndFiles[i].FileName.split('.')[1].toLowerCase() == "pdf") {
                $("#imgEditImage").attr('src', SiteImages + "/processing.png");
            }
            else {
                $("#imgEditImage").attr('src', FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + FolderAndFiles[i].FileName);
            }

            loadCategorydropdownsforEdit(FolderAndFiles[i].CategoryID);
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

function assignImage(fileName, gallery, imageid, ispdf) {
    var zoom = parseInt(parseFloat(zoomvalue()) * 100);
    var width;
    var height;
    var objectid = selectedObjectID;

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.IsFromPdf = false;

    width = parseInt(Control.Width * mmConvertionConstant);
    height = parseInt(Control.Height * mmConvertionConstant);

    //width = parseInt($("#" + Control.ObjectID).innerWidth());
    //height = parseInt($("#" + Control.ObjectID).innerHeight());

    var exxceeimage = "";

    exxceeimage = Control.ExceedImage;
    Control.UsedImageId = imageid;
    if (ispdf) {
        Control.IsFromPdf = true;
    }

    //if (Control.IsImageQuality) {
    //    var Data;
    //    if (gallery == "system") {
    //        Data = JSON.stringify({ OriginalImageName: fileName, isEdited: "false", ischecked: "true", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI });
    //    }
    //    else if (gallery == "user") {
    //        Data = JSON.stringify({ OriginalImageName: fileName, isEdited: "false", ischecked: "true", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI });
    //    }
    //    $.ajax({
    //        url: WebMethodsPath + "checkImageForDPI",
    //        type: "POST",
    //        data: Data,
    //        dataType: "json",
    //        processData: false,
    //        contentType: "application/json; charset=utf-8",
    //        success: function (DPIResult) {
    //            if (DPIResult.d == "success") {
    //                LoadImage();
    //            }
    //            else {
    //                $("#SaveMessage").dialog("open");
    //                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
    //                designMessageBox();
    //                $("div[aria-describedby=SaveMessage]").css('z-index', '114');
    //                $(".loadingNewMask").show();
    //            }
    //        }
    //    });
    //}
    //else {
    //    LoadImage();
    //}

    //function LoadImage() {

    if (exxceeimage == "P") {
        var FitImageToContoll = {};
        FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
        FitImageToContoll.type = "POST";
        if (gallery == "system") {
            FitImageToContoll.data = JSON.stringify({
                OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "false", ischecked: "true", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop,
                dbKey: DBKey, securePath: SecurePath, priceCatalogId: PriceCatalogId
});
        }
        else if (gallery == "user") {
            debugger;
            FitImageToContoll.data = JSON.stringify({
                OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "false", ischecked: "true", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID,
                iscropfromtop: Control.IsCropFromTop, dbKey: DBKey, securePath: SecurePath, priceCatalogId: PriceCatalogId
            });
        }
        FitImageToContoll.dataType = "json";
        FitImageToContoll.processData = false;
        FitImageToContoll.contentType = "application/json; charset=utf-8";
        FitImageToContoll.success = function (ImageName) {


            var arry = ImageName.d.split('~');
            ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

            Control.ImgUrl = arry[0];
            Control.OrignalImageName = arry[2];
            Control.EditedImageName = "";
            Control.IsFromBackEnd = false;
            Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
            Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
            Control.IsCropped = Boolean(arry[5]);
            if (Control.DefaultImageFrom.toLowerCase() != "none")
                Control.DefaultImageFrom = "None";
            // alert(Control.IsCropped);

            if (Control.IsFromPdf)
                Control.DefaultImageFrom = "FromPdf";

            if (Control.BackgroundImage != "") {
                $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                Control.BackgroundImage = arry[0];
            }
            else
                $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'position': 'absolute', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });


            Control.MaxHeight = parseFloat((parseFloat($("#" + Control.ObjectID + " img").innerHeight())) / mmConvertionConstant);
            Control.MaxWidth = parseFloat((parseFloat($("#" + Control.ObjectID + " img").innerWidth())) / mmConvertionConstant);
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
                    Control.EditedImageName = "";
                    Control.IsFromBackEnd = false;
                    if (Control.DefaultImageFrom.toLowerCase() != "none")
                        Control.DefaultImageFrom = "None";

                    if (Control.IsFromPdf)
                        Control.DefaultImageFrom = "FromPdf";

                    if (Control.BackgroundImage != "") {
                        Control.BackgroundImage = ImageName;
                    }

                    var imagepath = FrontEndDocumentPath + TemplateID + "/Images/" + ImageName;
                    $("#" + Control.ObjectID + " img").attr('src', imagepath);
                    $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                    //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + Control.ImgUrl);
                    $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                    Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                    if (fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign)) {
                        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                        if ($("#" + Control.ObjectID).hasClass('Para')) {
                            $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
                        }
                    }

                    if (Control.BackgroundImage != "") {
                        var _ctrlH = textCanvasHeight / mmConvertionConstant;
                        var _ctrlW = textCanvasWidth / mmConvertionConstant;

                        SetImageAsBackgroud(_ctrlH, _ctrlW);
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
                    Control.EditedImageName = "";
                    Control.IsFromBackEnd = false;
                    if (Control.DefaultImageFrom.toLowerCase() != "none")
                        Control.DefaultImageFrom = "None";

                    if (Control.BackgroundImage != "") {
                        Control.BackgroundImage = ImageName;
                    }
                    //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
                    var imagepath = FrontEndDocumentPath + TemplateID + "/Images/" + ImageName;
                    var tmpImg = new Image();
                    tmpImg.src = imagepath;
                    $(tmpImg).on('load', function () {
                        var orgWidth = this.width;
                        var orgHeight = this.height;
                        //var orgWidth = Control.MaxWidth * mmConvertionConstant;
                        //var orgHeight = Control.MaxHeight * mmConvertionConstant;

                        $("#" + Control.ObjectID + " img").attr('src', imagepath);
                        $("#" + Control.ObjectID).css({ 'width': orgWidth + 'px', 'height': orgHeight + 'px' });
                        $("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                        $("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                        Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                        Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
                        Control.Width = parseFloat($("#" + Control.ObjectID).innerWidth()) / mmConvertionConstant;
                        if (fixPostionOfControll(Control, Control.OffsetLeft, Control.OffsetTop, Control.TextAlign)) {
                            $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                            if ($("#" + Control.ObjectID).hasClass('Para')) {
                                $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
                            }
                        }



                        if (Control.BackgroundImage != "") {
                            var _ctrlH = textCanvasHeight / mmConvertionConstant;
                            var _ctrlW = textCanvasWidth / mmConvertionConstant;

                            SetImageAsBackgroud(_ctrlH, _ctrlW);
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

    if (Control.IsFromPdf == true) {
        $("#" + Control.ObjectID + "_edit").hide();
        $("#horizontalbar_" + Control.ObjectID).hide();
    } else {
        $("#" + Control.ObjectID + "_edit").show();
        $("#horizontalbar_" + Control.ObjectID).show();
    }

    //}
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
                    if (fixPostionOfControll(ControllDetails[i], VerticalGroupingData[j].PositionX - CropMarkWidth, positiony, VerticalGroupingData[j].Alignment)) {
                        $("#" + ControllDetails[i].ObjectID).css('text-align', ControllDetails[i].TextAlign);
                        if ($("#" + ControllDetails[i].ObjectID).hasClass('Para')) {
                            $("#" + ControllDetails[i].ObjectID + " pre").css('text-align', ControllDetails[i].TextAlign);
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
                if (!Group.IsParaGroup)
                    VerticalGroupPostioning(Group, "", Group.PositionX, Group.PositionY);
                else
                    VerticalParaGroupPostioning(Group, "", Group.PositionX, Group.PositionY);
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

    //Added for Rearranging Group on focusout 
    //KeepOptionPositioning("", "Move Field Up", true);

    //KeepOptionPositioning("", "Move Field Down", true);

    //KeepOptionPositioning("", "Move Field Left", true);

    //KeepOptionPositioning("", "Move Field Right", true);
}

function onfocusingroupCntorll(id) {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

    if (Control.GroupID != 0) {
        if (Control.GroupOrientation == "Vertical") {
            var Group;
            VerticalGroupingData.map(function (proj) { if (proj.GID == Control.GroupID) Group = proj });
            if (Group.GroupOption == "None" || Group.GroupOption == "") {
                if (!Group.IsParaGroup)
                    VerticalGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
                else
                    VerticalParaGroupPostioning(Group, Control.ObjectID, Group.PositionX, Group.PositionY);
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
    //theOriginalPositionofControlsByGroupID(Group.GID);
    var originalGroupPositionUpdateList = originalGropPositionUpdateGroupID(Group.GID, PositionStartX, PostionStartY, Group.GrpKeepOption);

    var positionIndex = -1;
    //if (Pageload || Group.GrpKeepOption.toLowerCase() != "none") {
    for (var i = 0; i < originalGroupPositionUpdateList.length; i++) {
        if (originalGroupPositionUpdateList[i].PageNumber == parseInt($("#lblcurrentpage").html())) {

            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == originalGroupPositionUpdateList[i].ObjectID) Control = proj });
            if (Control.DefaultContent != "") {
                var positionx = originalGroupPositionUpdateList[i].PositionX, positiony = originalGroupPositionUpdateList[i].PositionY;

                if (positionIndex >= 0 && Group.GrpKeepOption != "None") {
                    positionx = originalGroupPositionUpdateList[positionIndex].PositionX;
                    positiony = originalGroupPositionUpdateList[positionIndex].PositionY;
                    if (Group.IsConsiderLabel) {
                        var prevempty_Control;
                        ControllDetails.map(function (proj) { if (proj.ObjectID == originalGroupPositionUpdateList[positionIndex].ObjectID) prevempty_Control = proj });
                        if (prevempty_Control.Labels != "None" && Control.Labels == "None") {
                            if (prevempty_Control.Labels == "Use Labels" && prevempty_Control.LabelPosition == "customLeft") {
                                positionx = positionx - prevempty_Control.CustomLeft;
                            }
                        }

                        if (prevempty_Control.Labels == "None" && Control.Labels != "None") {
                            if (Control.Labels == "Use Labels" && Control.LabelPosition == "customLeft") {
                                positionx = positionx + Control.CustomLeft;
                            }
                        }

                        if (prevempty_Control.Labels != "None" && Control.Labels != "None") {
                            if (Control.Labels == "Use Labels" && Control.LabelPosition == "customLeft") {
                                positionx = positionx + Control.CustomLeft - prevempty_Control.CustomLeft;
                            } else if (Control.Labels == "Use Labels" && Control.LabelPosition == "Attached") {
                                positionx = positionx + Control.CustomLeft - prevempty_Control.CustomLeft;
                            }
                        }
                    }

                    positionIndex = positionIndex + 1;
                }

                //if (Control.ExceedHeight == "Expand Height") {
                //    Control.MaxHeight = ParaHeight;
                //    Control.Height = ParaHeight;
                //    $("#" + Control.ObjectID).css({ 'height': ParaHeight * mmConvertionConstant });
                //}

                if (Group.Alignment == "Left") {
                    //if (Control.TextAlign == "Center") {
                    //    positionx = positionx - (Control.Width / 2);
                    //}
                    //if (Control.TextAlign == "Right") {
                    //    positionx = positionx - Control.Width;
                    //}
                }
                else if (Group.Alignment == "Center") {
                    if (Control.TextAlign == "Center") { }
                    if (Control.TextAlign == "Left") { }
                } else if (Group.Alignment == "Right") {
                    if (Control.TextAlign == "Left") { }
                    if (Control.TextAlign == "Center") { }
                }

                if (fixPostionOfControll(Control, positionx, positiony, Control.TextAlign, true, true)) {
                    //Control.TextAlign = Group.Alignment;
                    alignsingleLineText(Control.ObjectID);
                    $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                    if ($("#" + Control.ObjectID).hasClass('Para')) {
                        $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
                        //if (Control.ExceedHeight == "Expand Height") {
                        //    if (($("#" + Control.ObjectID + " .paraText").innerHeight()) > Control.MaxHeight * mmConvertionConstant) {
                        //        Control.Height = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight() + 3) / mmConvertionConstant;
                        //        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight() + 3) / mmConvertionConstant;
                        //        var manualselectid = false;
                        //        if (selectedObjectID == "") {
                        //            manualselectid = true;
                        //            selectedObjectID = Control.ObjectID;
                        //        }
                        //        getPosition(true);
                        //        if (manualselectid) {
                        //            selectedObjectID = "";
                        //            manualselectid = false;
                        //        }
                        //    }
                        //}
                    }
                }

                $("#" + Control.ObjectID + " .label").show();
            }
            else {
                $("#" + Control.ObjectID + " .label").hide();
                if (Control.ObjectID == infocusobjectid) {
                    var positionx = originalGroupPositionUpdateList[i].PositionX, positiony = originalGroupPositionUpdateList[i].PositionY;
                    if (positionIndex >= 0 && Group.GrpKeepOption != "None") {
                        positionx = originalGroupPositionUpdateList[positionIndex].PositionX;
                        positiony = originalGroupPositionUpdateList[positionIndex].PositionY;
                        positionIndex = positionIndex + 1;
                    }

                    if (fixPostionOfControll(Control, positionx, positiony, Control.TextAlign, true, true)) {
                        //Control.TextAlign = Group.Alignment;
                        alignsingleLineText(Control.ObjectID);
                        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                        if ($("#" + Control.ObjectID).hasClass('Para')) {
                            $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
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
    //  }
}

function VerticalParaGroupPostioning(Group, infocusobjectid, PositionStartX, PostionStartY, Pageload) {
    var ControlsIngroup = getGroupControlsByGroupID(Group.GID);
    var numberOfControlsinGroup = ControlsIngroup.length;
    theOriginalPositionofControlsByGroupID(Group.GID)
    var originalGroupPositionUpdateList = originalGropPositionUpdateGroupID(Group.GID, PositionStartX, PostionStartY, Group.GrpKeepOption, true);

    var positionIndex = -1;
    //if (Pageload || Group.GrpKeepOption.toLowerCase() != "none") {
    for (var i = 0; i < originalGroupPositionUpdateList.length; i++) {
        if (originalGroupPositionUpdateList[i].PageNumber == parseInt($("#lblcurrentpage").html())) {

            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == originalGroupPositionUpdateList[i].ObjectID) Control = proj });
            if (Control.DefaultContent != "") {
                var positionx = originalGroupPositionUpdateList[i].PositionX, positiony = originalGroupPositionUpdateList[i].PositionY;
                //if (positionIndex >= 0 && Group.GrpKeepOption != "None") {
                //    positionx = originalGroupPositionUpdateList[positionIndex].PositionX;
                //    positiony = originalGroupPositionUpdateList[positionIndex].PositionY;
                //    positionIndex = positionIndex + 1;
                //}          

                SetParaPositionForExpand(Control);
                if (Control.ExceedHeight == "Expand Height") {
                    Control.MaxHeight = ParaHeight;
                    Control.Height = ParaHeight;
                    //if (Control.MaxHeight * mmConvertionConstant < ParaHeight * mmConvertionConstant) {
                    //    $("#" + Control.ObjectID).css({ 'height': ParaHeight * mmConvertionConstant });

                    //}
                    //else {
                    //    $("#" + Control.ObjectID).css({ 'height': Control.MaxHeight * mmConvertionConstant });                    
                    //}

                }
                $("#" + Control.ObjectID).css({ 'height': ParaHeight * mmConvertionConstant });
                if (fixPostionOfParaGroupControll(Control, positionx, positiony, Group.Alignment, true, true)) {

                    alignsingleLineText(Control.ObjectID);
                    if (Control.TextAlign == "Justify") {
                        Control.TextAlign = Control.TextAlign;
                        $("#" + Control.ObjectID).css('text-align', "Justify");
                        if ($("#" + Control.ObjectID).hasClass('Para')) {
                            $("#" + Control.ObjectID + " pre").css('text-align', "Justify");
                        }
                    } else {
                        Control.TextAlign = Group.Alignment;
                        $("#" + Control.ObjectID).css('text-align', Group.Alignment);
                        if ($("#" + Control.ObjectID).hasClass('Para')) {
                            $("#" + Control.ObjectID + " pre").css('text-align', Group.Alignment);
                        }
                    }
                    SetParaPositionForExpand(Control);

                    if (($("#" + Control.ObjectID + " .paraText").innerHeight()) > Control.MaxHeight * mmConvertionConstant) {
                        //$("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .paraText").outerHeight() });//changed by shahbaz
                        //  if (Control.ExceedHeight == "Expand Height") {
                        Control.Height = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight() + 3) / mmConvertionConstant;
                        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight() + 3) / mmConvertionConstant;
                        //}
                        var manualselectid = false;
                        //if (selectedObjectID == "") {
                        manualselectid = true;
                        selectedObjectID = Control.ObjectID;
                        //  }
                        getPosition(true);
                        if (manualselectid) {
                            selectedObjectID = "";
                            manualselectid = false;
                        }
                    }
                    var manualselectid = false;
                    if (selectedObjectID == "") {
                        manualselectid = true;
                        selectedObjectID = Control.ObjectID;
                    }
                    getPosition(true);
                    if (manualselectid) {
                        selectedObjectID = "";
                        manualselectid = false;
                    }
                    //if (Control.ExceedHeight != "Expand Height") {
                    //    Control.Height = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight() + 2) / mmConvertionConstant;
                    //    Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight() + 2) / mmConvertionConstant;
                    //    selectedObjectID = Control.ObjectID;
                    //    getPosition(true);
                    //}
                }
                $("#" + Control.ObjectID + " .label").show();

            }
            else {
                $("#" + Control.ObjectID + " .label").hide();
                if (Control.ObjectID == infocusobjectid) {
                    var positionx = originalGroupPositionUpdateList[i].PositionX, positiony = originalGroupPositionUpdateList[i].PositionY;
                    if (positionIndex >= 0 && Group.GrpKeepOption != "None") {
                        positionx = originalGroupPositionUpdateList[positionIndex].PositionX;
                        positiony = originalGroupPositionUpdateList[positionIndex].PositionY;
                        positionIndex = positionIndex + 1;
                    }
                    if (fixPostionOfParaGroupControll(Control, positionx, positiony, Group.Alignment, true, true)) {
                        Control.TextAlign = Group.Alignment;
                        alignsingleLineText(Control.ObjectID);
                        $("#" + Control.ObjectID).css('text-align', Group.Alignment);
                        if ($("#" + Control.ObjectID).hasClass('Para')) {
                            $("#" + Control.ObjectID + " pre").css('text-align', Group.Alignment);
                        }
                        if (Pageload)
                            $("#" + Control.ObjectID).css('top', $("#" + Control.ObjectID).position().top / zoomvalue());
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
    ControlsIngroup = getGroupControlsByGroupID(Group.GID);
    var numberOfControlsinGroup = ControlsIngroup.length;
    var count = 0, width = 0;

    if (Group.Alignment.toLowerCase() == "left") {
        //Changed By Shahbaz
        if (typeof pageLoad != 'undefined') {
            if (pageLoad)
                //    ControlsIngroup = sortJSON(ControlsIngroup, "OffsetLeft", "ASC");
                //else
                ControlsIngroup = sortJSON(ControlsIngroup, "Left", "ASC");
        }
        else {
            ControlsIngroup = sortJSON(ControlsIngroup, "Left", "ASC");
        }




        for (var i = 0; i < ControlsIngroup.length; i++) {

            if (pageLoad && typeof ControlsIngroup[i].OriginalOffsetLeft == 'undefined')
                ControlsIngroup[i].OriginalOffsetLeft = ControlsIngroup[i].OffsetLeft;

            var extraWidth = 0;
            if (ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
                extraWidth = ControlsIngroup[i].CustomLeft;
            }

            if (ControlsIngroup[i].TextAlign == "Right") {
                extraWidth = getControlWidth(ControlsIngroup[i]);
                //if (i > 0 && ControlsIngroup[i - 1].LabelPosition == "customLeft" && ControlsIngroup[i - 1].Labels == "Use Labels") {
                //    extraWidth -= ControlsIngroup[i - 1].CustomLeft;
                //}
                if (ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
                    extraWidth -= ControlsIngroup[i].CustomLeft;
                }
            }

            if (ControlsIngroup[i].TextAlign == "Center") {
                if (i < ControlsIngroup.length - 1) {
                    extraWidth = getControlWidth(ControlsIngroup[i]) / 2;
                    if (i > 0 && ControlsIngroup[i - 1].LabelPosition == "customLeft" && ControlsIngroup[i - 1].Labels == "Use Labels") {
                        extraWidth -= ControlsIngroup[i - 1].CustomLeft;
                    }
                } else {
                    extraWidth = getControlWidth(ControlsIngroup[i]) / 2;
                    if (i > 0 && ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
                        extraWidth -= ControlsIngroup[i].CustomLeft;
                    }
                }
            }

            if (ControlsIngroup[i].DefaultContent != "") {
                var ContorlsWidthandCount = getWidthOfcontrollsLeftInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, "Left", ControlsIngroup).split(',');

                fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], "", PositionStartX + extraWidth, PostionStartY, pageLoad);
                $("#" + ControlsIngroup[i].ObjectID + " .label").show();
            }
            else {
                $("#" + ControlsIngroup[i].ObjectID + " .label").hide();
                if (ControlsIngroup[i].ObjectID == infocusobjectid) {
                    var ContorlsWidthandCount = getWidthOfcontrollsLeftInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, "Left", ControlsIngroup).split(',');// Changed By Shahbaz                    
                    fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], "", PositionStartX + extraWidth, PostionStartY, pageLoad);
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
        ControlsIngroup = sortJSON(ControlsIngroup, "Left", "DESC");
        for (var i = 0; i < ControlsIngroup.length; i++) {
            var extraWidth = 0;
            //if (i == 0 && ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
            //    extraWidth += ControlsIngroup[i].CustomLeft;
            //}

            //if (i > 0) {
            //    if (ControlsIngroup[i].TextAlign.toLowerCase() == "left") {
            //        extraWidth += -getControlWidth(ControlsIngroup[i])
            //    }

            //    if (ControlsIngroup[i].TextAlign.toLowerCase() == "center") {
            //        extraWidth += -getControlWidth(ControlsIngroup[i]) / 2;
            //    }
            //}

            if (ControlsIngroup[i].DefaultContent != "") {
                var ContorlsWidthandCount = getWidthOfcontrollsRightInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, ControlsIngroup).split(',');
                fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], "", PositionStartX + extraWidth, PostionStartY, pageLoad);
                $("#" + ControlsIngroup[i].ObjectID + " .label").show();
            }
            else {
                $("#" + ControlsIngroup[i].ObjectID + " .label").hide();
                if (ControlsIngroup[i].ObjectID == infocusobjectid) {
                    var ContorlsWidthandCount = getWidthOfcontrollsRightInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, ControlsIngroup).split(',');
                    fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], "", PositionStartX + extraWidth, PostionStartY, pageLoad);
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
            //Added By Shahbaz for Storing Original Left position when Control Loaded First Time
            if (pageLoad)
                ControlsIngroup[i].OriginalOffsetLeft = ControlsIngroup[i].OffsetLeft;
        }
    }
    else if (Group.Alignment.toLowerCase() == "center") {

        ControlsIngroup = sortJSON(ControlsIngroup, "Left", "ASC");
        for (var i = 0; i < ControlsIngroup.length; i++) {
            var extraWidth = 0;

            //if (ControlsIngroup[i].TextAlign == "Right") {
            //    extraWidth = -getControlWidth(ControlsIngroup[i]) / 2;
            //}            

            if (ControlsIngroup[i].TextAlign == "Right") {
                if (i > 0) {
                    extraWidth = getControlWidth(ControlsIngroup[i]);
                    if (i > 0 && ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
                        extraWidth -= ControlsIngroup[i].CustomLeft;
                    }
                } else {
                    extraWidth = getControlWidth(ControlsIngroup[i]);
                    if (ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
                        extraWidth -= ControlsIngroup[i].CustomLeft;
                    }
                }
            }

            if (ControlsIngroup[i].TextAlign == "Center") {
                if (i > 0) {
                    extraWidth = getControlWidth(ControlsIngroup[i]) / 2;
                    if (i > 0 && ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
                        extraWidth -= ControlsIngroup[i].CustomLeft;
                    }
                } else {
                    extraWidth = getControlWidth(ControlsIngroup[i]) / 2;
                    if (ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels") {
                        extraWidth -= ControlsIngroup[i].CustomLeft;
                    }
                }

            }


            if (ControlsIngroup[i].DefaultContent != "") {
                var widthForCenter = parseFloat(getWidthOfAllControlSForCenter(ControlsIngroup[i].GroupID, infocusobjectid));
                // widthForCenter = widthForCenter - extraWidth;
                var ContorlsWidthandCount = getWidthOfcontrollsLeftInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, "Center", ControlsIngroup).split(',');
                fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], widthForCenter, PositionStartX + extraWidth, PostionStartY, pageLoad);
                $("#" + ControlsIngroup[i].ObjectID + " .label").show();
            }
            else {
                $("#" + ControlsIngroup[i].ObjectID + " .label").hide();
                if (ControlsIngroup[i].ObjectID == infocusobjectid) {
                    var widthForCenter = parseFloat(getWidthOfAllControlSForCenter(ControlsIngroup[i].GroupID, infocusobjectid));
                    // widthForCenter = widthForCenter - extraWidth;
                    var ContorlsWidthandCount = getWidthOfcontrollsLeftInGroup(ControlsIngroup[i].GroupID, ControlsIngroup[i].ObjectID, infocusobjectid, "Center", ControlsIngroup).split(',');
                    fixPostionOfHoriZontalGroupControll(ControlsIngroup[i].ObjectID, Group, ContorlsWidthandCount[0], ContorlsWidthandCount[1], widthForCenter, PositionStartX + extraWidth, PostionStartY, pageLoad);
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
            //Added By Shahbaz for Storing Original Left position when Control Loaded First Time
            if (pageLoad)
                ControlsIngroup[i].OriginalOffsetLeft = ControlsIngroup[i].OffsetLeft;
        }
    }
}

function fixPostionOfHoriZontalGroupControll(ObjectID, Group, allContorlsWidth, Count, widthForCenter, PositionStartX, PostionStartY, pageLoad) {

    var ControlsIngroup = getGroupControlsByGroupID(Group.GID);
    var numberOfControlsinGroup = ControlsIngroup.length;

    if (typeof pageLoad != 'undefined') {
        if (pageLoad)
            ControlsIngroup = sortJSON(ControlsIngroup, "OffsetLeft", "ASC");
        else
            ControlsIngroup = sortJSON(ControlsIngroup, "Left", "ASC");
    }
    else {
        ControlsIngroup = sortJSON(ControlsIngroup, "Left", "ASC");
    }

    var Control, i = 0, index = null;
    ControlsIngroup.map(function (proj) { if (proj.ObjectID == ObjectID) { Control = proj; index = i } else { i++; } });


    var labelwidth = 0, positionx = 0, TextWidth = 0, Alignment;

    if (Group.Alignment.toLowerCase() == "left") {
        //if (Control.LabelPosition == "customLeft" && index != 0) {
        //    labelwidth = parseFloat(Control.CustomLeft);
        //}
        positionx = parseFloat(allContorlsWidth) + (Group.ControlSpace * parseFloat(Count)) + labelwidth + parseFloat(PositionStartX);
        Alignment = "Left";
    }
    else if (Group.Alignment.toLowerCase() == "right") {
        positionx = parseFloat(PositionStartX) - (parseFloat(allContorlsWidth) + (Group.ControlSpace * parseFloat(Count)));
        Alignment = "Right";
        if (Control.TextAlign == "Left" || Control.TextAlign == "Center") { Control.TextAlign = Alignment; }

    }
    else if (Group.Alignment.toLowerCase() == "center") {
        if (Control.LabelPosition == "customLeft") {
            labelwidth = parseFloat(Control.CustomLeft);
        }
        positionx = (parseFloat(PositionStartX) + (parseFloat(allContorlsWidth) + (Group.ControlSpace * parseFloat(Count)))) + labelwidth - widthForCenter;
        Alignment = "Left";
    }

    if (fixPostionOfControll(Control, positionx, parseFloat(PostionStartY), Control.TextAlign, pageLoad, true)) {
        Control.TextAlign = Control.TextAlign;
        alignsingleLineText(Control.ObjectID);
        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
        if ($("#" + Control.ObjectID).hasClass('Para')) {
            $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
        }
    }
    //console.log("i m " + index + "but label is " + labelwidth + " i m excexuted" + countRun + " times");
    countRun++;
}
var countRun = 0;
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
                //if (i == 0 && alignment == "Left") {
                //    if (ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels" && ControlsIngroup[i].TextAlign.toLowerCase() != "left") {
                //        width -= ControlsIngroup[i].CustomLeft;
                //    }
                //}

                //if (typeof ControlsIngroup[i + 1] != 'undefined' && i > 0) {
                //    if (ControlsIngroup[i].TextAlign == "Right") {
                //        width -= getControlWidth(ControlsIngroup[i + 1]);
                //    }
                //}
            }
            else if (ControlsIngroup[i].ObjectID == focusedObjectid) {
                width += getControlWidth(ControlsIngroup[i]);
                count++;
                //if (i == 0 && alignment == "Left") {
                //    if (ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels" && ControlsIngroup[i].DefaultContent != "" && ControlsIngroup[i].TextAlign.toLowerCase() != "left") {
                //        width -= ControlsIngroup[i].CustomLeft;
                //    }
                //}
            }
            // else {

            //if (i == 0 && ControlsIngroup[i].LabelPosition == "customLeft" && ControlsIngroup[i].Labels == "Use Labels" && ControlsIngroup[i].TextAlign.toLowerCase() != "left") {
            //    width -= ControlsIngroup[i].CustomLeft;
            //}
            //}
        }
    }
    return width + "," + count;
}

function getWidthOfcontrollsRightInGroup(groupid, objectid, focusedObjectid, ControlsIngroup) {

    var width = 0, count = 0;
    //for (var i = ControlsIngroup.length - 1; i >= 0; i--) {
    for (var i = 0; i < ControlsIngroup.length; i++) {
        if (ControlsIngroup[i].ObjectID == objectid) {
            break;
        }
        else {
            if (ControlsIngroup[i].DefaultContent != "") {
                width += getControlWidth(ControlsIngroup[i]);

                //if (i == 0 && ControlsIngroup[i].TextAlign.toLowerCase() == "left") {
                //    width -= getControlWidth(ControlsIngroup[i]);
                //}

                //if (i == 0 && ControlsIngroup[i].TextAlign.toLowerCase() == "center") {
                //    width -= getControlWidth(ControlsIngroup[i]) / 2;
                //}
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
        width += $("#" + ControlsIngroup.ObjectID + " pre").innerWidth() / mmConvertionConstant;
    }
    else {
        if (ControlsIngroup.LabelPosition == "customRight" && ControlsIngroup.Labels == "Use Labels") {
            width += ControlsIngroup.CustomRight + ($("#" + ControlsIngroup.ObjectID + " .label").innerWidth()) / mmConvertionConstant;
        }
        else
            width += ($("#" + ControlsIngroup.ObjectID + " .labelText").innerWidth()) / mmConvertionConstant;
    }


    return width;
}

function applyBorderForControl(id, ControlType) {

    if (ControlType == "TextBlock") {
        if ($("#" + id).hasClass('ui-draggable'))
            $("#" + id).css('border', '1px dashed rgb(128, 128, 128)');
        else
            $("#" + id + " .labelText").css('border', '1px dashed rgb(128, 128, 128)');
    }
    else if (ControlType == "Paragraph") {
        if ($("#" + id).hasClass('ui-draggable'))
            $("#" + id).css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });
        else
            $("#" + id + " .paraText").css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });
    }
}

function removeBorderForControl(id, ControlType) {
    if (ControlType == "TextBlock") {
        if ($("#" + id).hasClass('ui-draggable'))
            $("#" + id).css({ 'border': '1px dashed rgba(0, 0, 0, 0)', 'border': '1px dashed transparent' });

        $("#" + id + " .labelText").css({ 'border': '1px dashed rgba(0, 0, 0, 0)', 'border': '1px dashed transparent' });
        // $("#" + id + " .label").css({ 'border': '1px dashed rgba(0, 0, 0, 0)', 'border': '1px dashed transparent' });//commented By shahbaz for Ticked 12870 on 2/12/2015
    }
    else if (ControlType == "Paragraph") {
        if ($("#" + id).hasClass('ui-draggable'))
            $("#" + id).css({ 'border': '1px dashed rgba(0, 0, 0, 0)', 'border': '1px dashed transparent' });
        $("#" + id + " pre").css({ 'border': '1px dashed rgba(0, 0, 0, 0)', 'border': '1px dashed transparent' });
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

    var EmptyTextPositionX = -1;
    var EmptyTextPositionY = -1;
    var EmptyGroupPositionX = -1;
    var type = '';
    var CountForEmptyContent = 0;
    var CountEmptyGroup = 0;
    var ListForKeepOption = [];

    var ControlPositionIndex = -1, positionIndex = -1;
    var ControlKeepOption = [];
    var currentpage = parseInt($("#lblcurrentpage").html());

    //if (typeof page != 'undefined') {
    //    if (page != "")
    //        currentpage = page
    //} 
    if (keepoption == "Move Up" || keepoption == "Move Field Up") {
        for (var i = 0; i < ListForMoveUp.length; i++) {
            if (ListForMoveUp[i].PageNumber == currentpage)
                ListForKeepOption.push(ListForMoveUp[i]);
        }
        //ListForKeepOption = ListForMoveUp;
    }
    else if (keepoption == "Move Down" || keepoption == "Move Field Down") {
        for (var i = 0; i < ListForMoveDown.length; i++) {
            if (ListForMoveDown[i].PageNumber == currentpage)
                ListForKeepOption.push(ListForMoveDown[i]);
        }
        //ListForKeepOption = ListForMoveDown;
    }
    else if (keepoption == "Move Field Left") {
        for (var i = 0; i < ListForKeepLeft.length; i++) {
            if (ListForKeepLeft[i].PageNumber == currentpage)
                ListForKeepOption.push(ListForKeepLeft[i]);
        }
        ///ListForKeepOption = ListForKeepLeft;
    }
    else if (keepoption == "Move Field Right") {
        for (var i = 0; i < ListForKeepRight.length; i++) {
            if (ListForKeepRight[i].PageNumber == currentpage)
                ListForKeepOption.push(ListForKeepRight[i]);
        }
        //ListForKeepOption = ListForKeepRight;
    }

    //for Positioning Controls separately from Group Controls
    for (var k = 0; k < ListForKeepOption.length; k++) {
        if (ListForKeepOption[k].Type == "Control") {
            ControlKeepOption.push(ListForKeepOption[k])
        }
    }
    var HaveDiffenetPosition = CheckForPositioninList(ControlKeepOption);
    for (var j = 0; j < ControlKeepOption.length; j++) {
        if (ControlKeepOption[j].Type == "Control") {
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == ControlKeepOption[j].ObjectID) Control = proj });
            if (Control.Lock) {
                if (Control.DefaultContent != "") {
                    var positionx = ControlKeepOption[j].PositionX, positiony = ControlKeepOption[j].PositionY;

                    if ((keepoption == "Move Down" || keepoption == "Move Field Down" || keepoption == "Move Up" || keepoption == "Move Field Up") && HaveDiffenetPosition) {
                        if (ControlPositionIndex >= 0 && positionx == EmptyTextPositionX) {
                            positionx = ControlKeepOption[ControlPositionIndex].PositionX;
                            positiony = ControlKeepOption[ControlPositionIndex].PositionY;
                            ControlPositionIndex = ControlPositionIndex + 1;
                        }
                    }
                    else {
                        if (keepoption == "Move Down" || keepoption == "Move Field Down" || keepoption == "Move Up" || keepoption == "Move Field Up") {
                            if (ControlPositionIndex >= 0) {
                                positionx = ControlKeepOption[ControlPositionIndex].PositionX;
                                positiony = ControlKeepOption[ControlPositionIndex].PositionY;
                                ControlPositionIndex = ControlPositionIndex + 1;
                            }
                        }
                        else {
                            if (ControlPositionIndex >= 0 && positiony == EmptyTextPositionY) {
                                positionx = ControlKeepOption[ControlPositionIndex].PositionX;
                                positiony = ControlKeepOption[ControlPositionIndex].PositionY;
                                ControlPositionIndex = ControlPositionIndex + 1;

                            }
                        }
                    }

                    if (Control.ExceedHeight == "Expand Height") {
                        Control.MaxHeight = ParaHeight;
                        Control.Height = ParaHeight;
                        $("#" + Control.ObjectID).css({ 'height': ParaHeight * mmConvertionConstant });
                    }

                    if (fixPostionOfControll(Control, positionx, positiony, Control.TextAlign, pageLoad)) {
                        $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                        alignsingleLineText(Control.ObjectID);
                        if ($("#" + Control.ObjectID).hasClass('Para')) {
                            $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
                            if (Control.ExceedHeight == "Expand Height") {
                                if (($("#" + Control.ObjectID + " .paraText").innerHeight()) > Control.MaxHeight * mmConvertionConstant) {
                                    Control.Height = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight() + 3) / mmConvertionConstant;
                                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .paraText").outerHeight() + 3) / mmConvertionConstant;
                                    //$("#" + Control.ObjectID).css({ 'height': Control.MaxHeight * mmConvertionConstant });
                                    var manualselectid = false;
                                    if (selectedObjectID == "") {
                                        manualselectid = true;
                                        selectedObjectID = Control.ObjectID;
                                    }
                                    getPosition(true);
                                    if (manualselectid) {
                                        selectedObjectID = "";
                                        manualselectid = false;
                                    }
                                }
                            }
                        }
                    }
                    $("#" + Control.ObjectID + " .label").show();
                }
                else {
                    $("#" + Control.ObjectID + " .label").hide();
                    var positionx = ControlKeepOption[j].PositionX, positiony = ControlKeepOption[j].PositionY;
                    CountForEmptyContent++;
                    //Added By Shahbaz for Group movement if PositionX is different for control
                    if ((keepoption == "Move Down" || keepoption == "Move Field Down" || keepoption == "Move Up" || keepoption == "Move Field Up") && HaveDiffenetPosition) {
                        if (positionx == EmptyTextPositionX && CountForEmptyContent > 1) {

                        }
                        else if (positionx == EmptyTextPositionX) {
                            ControlPositionIndex = j - 1;
                        }
                        else {
                            ControlPositionIndex = j;
                        }

                        EmptyTextPositionX = positionx;
                    } else {
                        if (keepoption == "Move Down" || keepoption == "Move Field Down" || keepoption == "Move Up" || keepoption == "Move Field Up") {
                            if (positionx == EmptyTextPositionX && CountForEmptyContent > 1) {

                            }
                            else if (positionx == EmptyTextPositionX) {
                                ControlPositionIndex = j - 1;
                            }
                            else {
                                ControlPositionIndex = j;
                            }

                            EmptyTextPositionX = positionx;
                        }
                        else {
                            if (positiony == EmptyTextPositionY && CountForEmptyContent > 1) {

                            }
                            else if (positiony == EmptyTextPositionY) {
                                ControlPositionIndex = j - 1;
                            } else {
                                ControlPositionIndex = j;
                            }

                            EmptyTextPositionY = positiony;
                        }
                    }


                    if (Control.ObjectID == objectid) {
                        if (ControlPositionIndex >= 0) {
                            positionx = ControlKeepOption[ControlPositionIndex].PositionX;
                            positiony = ControlKeepOption[ControlPositionIndex].PositionY;
                            ControlPositionIndex = ControlPositionIndex + 1;
                        }
                        if (fixPostionOfControll(Control, positionx, positiony, Control.TextAlign, pageLoad)) {
                            $("#" + Control.ObjectID).css('text-align', Control.TextAlign);
                            alignsingleLineText(Control.ObjectID);
                            if ($("#" + Control.ObjectID).hasClass('Para')) {
                                $("#" + Control.ObjectID + " pre").css('text-align', Control.TextAlign);
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
                        if (ControlPositionIndex == -1) {
                            ControlPositionIndex = j;
                        }
                    }
                }
            }

        }
        //if (pageLoad) {
        //    KeepOptionPositioning(objectid, keepoption, false, 2);
        //}
    }

    var ListForMovedGroup = [];
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
            }

            if (GroupOrControlInBtween == false) {
                if (ListForKeepOption[i].Type == "VerticalGroup" || ListForKeepOption[i].Type == "HorizontalGroup") {

                    var EmptyGroup = checkForEmptyGroup(null, parseInt(ListForKeepOption[i].GroupID));
                    if (!EmptyGroup) {
                        CountEmptyGroup = 0;
                        var positionx = ListForKeepOption[i].PositionX, positiony = ListForKeepOption[i].PositionY;
                        if (positionIndex >= 0 && EmptyGroupPositionX == positionx) {

                            var result = 0;
                            var aboveResult = 0;
                            if (ListForKeepOption[i].GroupMoveRelative == true) {


                                for (var m = 0; m < ListForMovedGroup.length; m++) {
                                    if (keepoption == "Move Field Down") {
                                        result = parseFloat(result) - parseFloat(checkForEmptyGroupControlsHeight(parseInt(ListForMovedGroup[m].GroupID))) - parseFloat(ListForMovedGroup[m].GroupMovementValue);
                                    }
                                    else {
                                        result = parseFloat(result) + parseFloat(checkForEmptyGroupControlsHeight(parseInt(ListForMovedGroup[m].GroupID))) + parseFloat(ListForMovedGroup[m].GroupMovementValue);
                                    }

                                }

                                positiony = parseFloat(ListForKeepOption[i].PositionY) + parseFloat(result);
                            }
                            else {
                               
                                    positiony = ListForKeepOption[positionIndex].PositionY 
                               
                            }
                            positionx = ListForKeepOption[positionIndex].PositionX;

                            // positiony = ListForKeepOption[positionIndex].PositionY ;
                            positionIndex = positionIndex + 1;

                        }

                        if (ListForKeepOption[i].Type == "VerticalGroup") {
                            var Group;
                            VerticalGroupingData.map(function (proj) { if (proj.GID == ListForKeepOption[i].GroupID) Group = proj });
                            Group.CurrentPositionY = positiony;
                            Group.CurrentPositionX = positionx;
                            if (!Group.IsParaGroup)
                                VerticalGroupPostioning(Group, objectid, positionx, positiony, pageLoad);
                            else
                                VerticalParaGroupPostioning(Group, objectid, positionx, positiony, pageLoad);
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

                        ListForMovedGroup.push(ListForKeepOption[i]);
                        CountEmptyGroup++;
                        var EmptyGroup;
                        VerticalGroupingData.map(function (proj) { if (proj.GID == ListForKeepOption[i].GroupID) EmptyGroup = proj });

                        if (i > 0 && EmptyGroupPositionX == ListForKeepOption[i].PositionX && CountEmptyGroup > 1) {

                        }
                        else if (i > 0 && EmptyGroupPositionX == ListForKeepOption[i].PositionX)
                            positionIndex = i - 1
                        //if (positionIndex == -1) {
                        else
                            positionIndex = i;
                        //}
                        EmptyGroupPositionX = ListForKeepOption[i].PositionX;
                    }
                }
            }
            else {
                if (ListForKeepOption[i].Type == "VerticalGroup" || ListForKeepOption[i].Type == "HorizontalGroup") {
                    var EmptyGroup = checkForEmptyGroup(objectid, parseInt(ListForKeepOption[i].GroupID));
                    if (!EmptyGroup) {
                        var positionx = ListForKeepOption[i].PositionX, positiony = ListForKeepOption[i].PositionY;
                        if (positionIndex >= 0 && EmptyGroupPositionX == positionx) {
                            var result = 0;
                            if (ListForKeepOption[i].GroupMoveRelative == true) {   //Changed By Amin


                                for (var m = 0; m < ListForMovedGroup.length; m++) {
                                    if (keepoption == "Move Field Down") {
                                        result = parseFloat(result) - parseFloat(checkForEmptyGroupControlsHeight(parseInt(ListForMovedGroup[m].GroupID))) - parseFloat(ListForMovedGroup[m].GroupMovementValue);
                                    }
                                    else {
                                        result = parseFloat(result) + parseFloat(checkForEmptyGroupControlsHeight(parseInt(ListForMovedGroup[m].GroupID))) + parseFloat(ListForMovedGroup[m].GroupMovementValue);
                                    }

                                }

                                positiony = parseFloat(ListForKeepOption[i].PositionY) + parseFloat(result);
                            }
                            else {
                               
                                positiony = ListForKeepOption[positionIndex].PositionY;
                            }
                            positionx = ListForKeepOption[positionIndex].PositionX;
                            //positiony = ListForKeepOption[positionIndex].PositionY;       
                            //positiony = parseInt(ListForKeepOption[i].PositionY) + parseInt(result);
                            positionIndex = positionIndex + 1;
                        }
                        if (ListForKeepOption[i].Type == "VerticalGroup") {
                            var Group;
                            VerticalGroupingData.map(function (proj) { if (proj.GID == ListForKeepOption[i].GroupID) Group = proj });
                            Group.CurrentPositionY = positiony;
                            Group.CurrentPositionX = positionx;
                            if (!Group.IsParaGroup)
                                VerticalGroupPostioning(Group, objectid, positionx, positiony, pageLoad);
                            else
                                VerticalParaGroupPostioning(Group, objectid, positionx, positiony, pageLoad);
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
                        ListForMovedGroup.push(ListForKeepOption[i]);
                        if (i > 0 && EmptyGroupPositionX == ListForKeepOption[i].PositionX)
                            positionIndex = i - 1
                        //if (positionIndex == -1) {
                        else
                            positionIndex = i;
                        //}
                        EmptyGroupPositionX = ListForKeepOption[i].PositionX
                        type = ListForKeepOption[i].Type
                    }
                }
            }

            if (PositionxVariedForHorizontalKeepOption == true) {
                positionIndex = -1;
            }
        }
    }
}
function checkForEmptyGroupControlsHeight(GroupID) {
    var Group = null;
    VerticalGroupingData.map(function (proj) { if (proj.GID == GroupID) Group = proj });
    if (Group == null) {
        HorizontalGroupingData.map(function (proj) { if (proj.GID == GroupID) Group = proj });
    }

    var empty = 0;
    for (var j = 0; j < ControllDetails.length; j++) {
        if (ControllDetails[j].GroupID == Group.GID) {
            if (ControllDetails[j].DefaultContent == "") {
                empty = ControllDetails[j].Height;
                // empty = ControllDetails[j].OffsetHeight;
                break;
            }

        }
    }

    return empty;
}
function listOfPositionForMoveUp() {

    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].GroupID == 0 && ControllDetails[i].KeepOptions == "Move Field Up") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": ControllDetails[i].Left, "PositionY": ControllDetails[i].Top, "Type": "Control", "ObjectID": ControllDetails[i].ObjectID, "PageNumber": ControllDetails[i].PageNumber, GroupMoveRelative: ControllDetails[i].GroupMoveRelative, GroupMovementValue: ControllDetails[i].GroupMovementValue }));
            ListForMoveUp.push(posXposY);
        }
    }
    for (var i = 0; i < VerticalGroupingData.length; i++) {
        if (VerticalGroupingData[i].GroupOption == "Move Up") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": VerticalGroupingData[i].PositionX, "PositionY": VerticalGroupingData[i].PositionY, "Type": "VerticalGroup", "GroupID": VerticalGroupingData[i].GID, "PageNumber": VerticalGroupingData[i].PageNumber, GroupMoveRelative: VerticalGroupingData[i].GroupMoveRelative, GroupMovementValue: VerticalGroupingData[i].GroupMovementValue }));
            ListForMoveUp.push(posXposY);
        }
    }

    for (var i = 0; i < HorizontalGroupingData.length; i++) {
        if (HorizontalGroupingData[i].GroupOption == "Move Up") {
            var posXposY = JSON.parse(JSON.stringify({ "PositionX": HorizontalGroupingData[i].PositionX, "PositionY": HorizontalGroupingData[i].PositionY, "Type": "HorizontalGroup", "GroupID": HorizontalGroupingData[i].GID, "PageNumber": HorizontalGroupingData[i].PageNumber, GroupMoveRelative: HorizontalGroupingData[i].GroupMoveRelative, GroupMovementValue: HorizontalGroupingData[i].GroupMovementValue }));
            ListForMoveUp.push(posXposY);
        }
    }


    if (ListForMoveUp.length > 0) {
        // ListForMoveUp = SortJsonMultiple(ListForMoveUp, "PositionY", "DESC");commented By shahbaz
        // ListForMoveUp = SortJsonMultiple(ListForMoveUp, "PositionX", "DESC");
        ListForMoveUp = SortJsonMultiple(ListForMoveUp, "PositionX", "PositionY", "DESC");
        //  console.log(ListForMoveUp)
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
        //ListForMoveDown = sortJSON(ListForMoveDown, "PositionY", "ASC");commented By shahbaz 
        //ListForMoveDown = sortJSON(ListForMoveDown, "PositionX", "ASC");        
        ListForMoveDown = SortJsonMultiple(ListForMoveDown, "PositionX", "PositionY", "ASC");

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
        // ListForKeepLeft = SortJsonMultiple(ListForKeepLeft, "PositionX", "PositionY", "ASC");
        ListForKeepLeft = sortJSON(ListForKeepLeft, "PositionX", "ASC");//Commented By shahbaz
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
        //ListForKeepRight = SortJsonMultiple(ListForKeepRight, "PositionX", "PositionY", "DESC");
        ListForKeepRight = sortJSON(ListForKeepRight, "PositionX", "DESC");
        ListForKeepRight = sortJSON(ListForKeepRight, "PositionY", "DESC");
    }

}

function getGroupControl() {
    ControllDetails.map(function (proj) { if (proj.GroupID > 0) GroupControls.push(proj) });
}

function checkForOriginalFile(userGalleryPath, systemGalleryPath, noImagePath, Filename) {
    var systemGallery = false;

    if (noImagePath == "") {
        if (userGalleryPath != "") {
            $.ajax({
                url: userGalleryPath,
                type: 'HEAD',
                error: function () {
                    loadImageEditor_Gaj(userImagePath = FrontEndDocumentPath + TemplateID + "/Images/" + Filename);
                    // loadImageEditor(userImagePath = FrontEndDocumentPath + TemplateID + "/Images/" + Filename);
                },
                success: function () {

                    loadImageEditor_Gaj(userGalleryPath);
                    //   loadImageEditor(userGalleryPath);
                }
            });
        }
        else {
            systemGallery = true;
        }
    }
    else {
        //loadImageEditor(noImagePath);Commented By shahbaz for not to opening RadEditor Poup
        loadImageEditor_Gaj(noImagePath);//Addded by shahabaz tO Open Cropic Editor
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
                loadImageEditor_Gaj(FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + ImageName);
                //loadImageEditor(FrontEndDocumentPath + "UsersImages/" + UserID + "/Gallery/OriginalImages/" + ImageName);
            }
        });
    }
}
var orgWidthCrop = 0;
var orgHeightCrop = 0;


var croppicContainerPreloadOptions = {
    uploadUrl: 'img_save_to_file.php',//not using
    cropUrl: 'CropHandler.ashx',
    enableMousescroll: true,
    loaderHtml: '<div class="loader bubblingG"><span id="bubblingG_1"></span><span id="bubblingG_2"></span><span id="bubblingG_3"></span></div> '
}


function loadImageEditor_Gaj(ImagePath) {
    croppicContainerPreloadOptions.loadPicture = ImagePath;
    //console.log(orgWidthCrop + "  :  " + orgHeightCrop);
    $("#cropContainerModal").width(orgWidthCrop).height(orgHeightCrop);
    $("#cropContainerModal").css('text-align', 'center');
    var tmpImg = new Image();
    tmpImg.src = ImagePath;
    $(tmpImg).on('load', function () {
        $("#cropContainerModal").html("");
        //For creatring cropbox as per Editor popup height and width proportional to Control.
        var imageWidth = this.width;
        var imageHeight = this.height;
        var scaledHeight = 500 / orgHeightCrop; //scaling height using popup height
        var scaledWidth = 700 / orgWidthCrop;
        var aspect = Math.min(scaledHeight, scaledWidth);//scaling width using popup width
        var newwidth =
        $("#cropContainerModal").width(orgWidthCrop * aspect).height(orgHeightCrop * aspect);
        //        $("#Imageeditor1").css('text-align', 'center');      
        //6-04-2016
        $("#Imageeditor1").dialog({
            effect: "clip",
            autoOpen: false,
            resizable: false,
            height: 575,
            width: 870,
            modal: true,
            open: function () {

            },
            close: function () {
                $(this).dialog("destroy");
            },
        });

        $("#Imageeditor1").dialog("open");
        var cropContainerPreload = new Croppic('cropContainerModal', croppicContainerPreloadOptions);

    });
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
        //orgWidthCrop = tmpImg.width;
        //orgHeightCrop = tmpImg.height;
        $("#RadImageEditor1_canvas").attr('height', tmpImg.height);
        $("#RadImageEditor1_canvas").attr('width', tmpImg.width);
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
        if (Group.GrpKeepOption == "Move Field Up" || Group.GrpKeepOption == "Move Field Down" || Group.GrpKeepOption == "None") {
            if (!Group.IsParaGroup)
                ControlsIngroup = sortJSON(ControlsIngroup, "Top", "ASC");
            else
                ControlsIngroup = sortJSON(ControlsIngroup, "Top", "DESC");
            var PosY = 0, ControlSpace = 0;
            for (var i = 0; i < ControlsIngroup.length; i++) {
                var tempp = JSON.parse(JSON.stringify({ "ObjectID": ControlsIngroup[i].ObjectID, "PositionX": 0, "PositionY": PosY + ControlSpace, "Oreintation": oreintation, "PageNumber": ControlsIngroup[i].PageNumber }));
                temp.push(tempp);
                //if ($("#" + ControlsIngroup[i].ObjectID).outerHeight() > 2) { //Commented By shahbaz
                //    //if ($("#" + ControlsIngroup[i].ObjectID).outerHeight() / mmConvertionConstant > 2) {
                //    PosY += parseFloat($("#" + ControlsIngroup[i].ObjectID).outerHeight()) / mmConvertionConstant;
                //}
                //else {
                //ParaGroup
                if (Group.IsParaGroup)
                    PosY += ($("#" + ControlsIngroup[i].ObjectID + " .paraText").innerHeight()) / mmConvertionConstant;
                else {
                    // if (ControlsIngroup[i].Height < 4) {
                    // PosY += 4;
                    // } else {
                    PosY += ControlsIngroup[i].Height;
                    // }
                }
                //}
                ControlSpace += Group.ControlSpace;
            }
        }
    }
    else if (oreintation == "Horizontal") {

        if (Group.Alignment == "Right") {
            ControlsIngroup = sortJSON(ControlsIngroup, "OffsetLeft", "DESC");
            var PosX = 0, ControlSpace = 0;
            for (var i = 0; i < ControlsIngroup.length; i++) {
                var tempp = JSON.parse(JSON.stringify({ "ObjectID": ControlsIngroup[i].ObjectID, "PositionX": PosX - ControlSpace, "PositionY": 0, "Oreintation": oreintation, "PageNumber": ControlsIngroup[i].PageNumber }));
                temp.push(tempp);
                PosX -= parseFloat($("#" + ControlsIngroup[i].ObjectID).innerWidth()) / mmConvertionConstant;
                ControlSpace -= Group.ControlSpace;
            }
        }
        else if (Group.Alignment == "Left") {
            ControlsIngroup = sortJSON(ControlsIngroup, "OffsetLeft", "ASC");
            var PosX = 0, ControlSpace = 0;
            for (var i = 0; i < ControlsIngroup.length; i++) {
                var tempp = JSON.parse(JSON.stringify({ "ObjectID": ControlsIngroup[i].ObjectID, "PositionX": PosX + ControlSpace, "PositionY": 0, "Oreintation": oreintation, "PageNumber": ControlsIngroup[i].PageNumber }));
                temp.push(tempp);
                PosX += parseFloat($("#" + ControlsIngroup[i].ObjectID).innerWidth()) / mmConvertionConstant;
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

function originalGropPositionUpdateGroupID(GroupID, PositionStartX, PostionStartY, keepOptions, IsParaGroup) {
    var control;
    var IsEmptyOriginalGroupPositionByGroupID = false;
    if (OriginalGroupPositionByGroupID.length == 0) {
        theOriginalPositionofControlsByGroupID(GroupID);
        IsEmptyOriginalGroupPositionByGroupID = true;
    }
    OriginalGroupPositionByGroupID.map(function (proj) { if (proj.GroupID == GroupID) control = proj.Objects });
    var controls = JSON.parse(JSON.stringify(control));
    controls = sortJSON(controls, "PositionY", "ASC");

    //commented By shahbaz
    //for (var i = 0; i < controls.length; i++) {
    //    controls[i].PositionX += PositionStartX;
    //    controls[i].PositionY += PostionStartY;
    //}
    if (IsEmptyOriginalGroupPositionByGroupID) {
        OriginalGroupPositionByGroupID = [];
    }

    var Group;
    VerticalGroupingData.map(function (proj) { if (proj.GID == GroupID) Group = proj });
    //Added By Shahbaz 
    var PrevoiusYPosition = 0;

    for (var i = 0; i < controls.length; i++) {
        var current_control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == controls[i].ObjectID) current_control = proj });
        if (i == 0) {
            PrevoiusYPosition = controls[i].PositionY
            controls[i].PositionX = PositionStartX;
            controls[i].PositionY = PostionStartY;
            if (Group.IsConsiderLabel) {
                if (current_control.Labels != "None") {
                    if (current_control.Labels == "Use Labels" && current_control.LabelPosition == "customLeft") {
                        controls[i].PositionX = PositionStartX + current_control.CustomLeft;
                    }
                }
            }

        } else {
            controls[i].PositionX = PositionStartX;
            DifferentInYPosition = controls[i].PositionY - PrevoiusYPosition;
            PrevoiusYPosition = controls[i].PositionY;
            if (IsParaGroup)
                controls[i].PositionY = controls[i - 1].PositionY - DifferentInYPosition;
            else {
                if (Group.IsConsiderLabel) {
                    if (current_control.Labels != "None") {
                        if (current_control.Labels == "Use Labels" && current_control.LabelPosition == "customLeft") {
                            controls[i].PositionX = PositionStartX + current_control.CustomLeft;
                        }
                    }
                }
                controls[i].PositionY = controls[i - 1].PositionY + DifferentInYPosition;
            }
        }
    }

    if (keepOptions.toLowerCase() == "move field up")
        controls = sortJSON(controls, "PositionY", "DESC");

    if (IsParaGroup)
        if (keepOptions.toLowerCase() == "move field down")
            controls = sortJSON(controls, "PositionY", "ASC");
    return controls;
}

function postionControlsGroupWise(pageLoad) {
    var currentPage = parseInt($("#lblcurrentpage").html());
    if (VerticalGroupingData != null) {
        if (VerticalGroupingData.length > 0) {
            for (var i = 0; i < VerticalGroupingData.length; i++) {
                theOriginalPositionofControlsByGroupID(VerticalGroupingData[i].GID);
                if ((VerticalGroupingData[i].GroupOption == "None" || VerticalGroupingData[i].GroupOption == "") && VerticalGroupingData[i].PageNumber == currentPage) {
                    if (!VerticalGroupingData[i].IsParaGroup)
                        VerticalGroupPostioning(VerticalGroupingData[i], "", VerticalGroupingData[i].PositionX, VerticalGroupingData[i].PositionY, pageLoad);
                    else
                        VerticalParaGroupPostioning(VerticalGroupingData[i], "", VerticalGroupingData[i].PositionX, VerticalGroupingData[i].PositionY, pageLoad);
                }
            }
        }
    }
    if (HorizontalGroupingData != null) {
        if (HorizontalGroupingData.length > 0) {
            for (var i = 0; i < HorizontalGroupingData.length; i++) {
                theOriginalPositionofControlsByGroupID(HorizontalGroupingData[i].GID);
                if ((HorizontalGroupingData[i].GroupOption == "None" || HorizontalGroupingData[i].GroupOption == "") && HorizontalGroupingData[i].PageNumber == currentPage) {
                    HorizontalGroupPostioning(HorizontalGroupingData[i], "", HorizontalGroupingData[i].PositionX, HorizontalGroupingData[i].PositionY, pageLoad);
                }
            }
        }
    }

    KeepOptionPositioning("", "Move Field Up", pageLoad);

    KeepOptionPositioning("", "Move Field Down", pageLoad);

    KeepOptionPositioning("", "Move Field Left", pageLoad);

    KeepOptionPositioning("", "Move Field Right", pageLoad);

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
                var letterspacing = 0;
                //if (parseFloat($("#" + controllDetails.ObjectID + " .labelText").css('letter-spacing')) > 0)
                //    letterspacing = parseFloat($("#" + controllDetails.ObjectID + " .labelText").css('letter-spacing'));
                $("#" + controllDetails.ObjectID + " .labelText").css({ 'right': 'auto', 'left': ((($("#" + controllDetails.ObjectID).outerWidth() / 2) - ($("#" + controllDetails.ObjectID + " .labelText").outerWidth() / 2)) - 1) - letterspacing + 'px' });
                break;
        }
    }
}

function attachLabelTosinglelineControl(controllID, Text) {
    
    Text = Text.replace(/ /g, "&nbsp;").replace(/®/g, '<sup>&reg;</sup>').replace(/©/g, '<sup>&copy;</sup>');
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

        //if (Control.IsImageQuality) {
        //    var Data;
        //    if (gallery == "system") {
        //        Data = JSON.stringify({ OriginalImageName: Control.OrignalImageName, isEdited: "false", ischecked: "false", isfrombackend: 'true', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI });
        //    }
        //    else if (gallery == "user") {
        //        Data = JSON.stringify({ OriginalImageName: Control.OrignalImageName, isEdited: "false", ischecked: "false", isfrombackend: 'false', TemplateID: TemplateID, BackEndPath: ImageUploadPath, ImageUploadPath: FrontEndUploadPath, UserID: UserID, CompanyID: CompanyID, iscropfromtop: Control.IsCropFromTop, minDPI: Control.MinDPI });
        //    }
        //    $.ajax({
        //        url: WebMethodsPath + "checkImageForDPI",
        //        type: "POST",
        //        data: Data,
        //        dataType: "json",
        //        processData: false,
        //        contentType: "application/json; charset=utf-8",
        //        success: function (DPIResult) {
        //            if (DPIResult.d == "success") {
        //                LoadImage();
        //            }
        //            else {
        //                $("#SaveMessage").dialog("open");
        //                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
        //                designMessageBox();
        //                $("div[aria-describedby=SaveMessage]").css('z-index', '114');
        //                $(".loadingNewMask").show();
        //            }
        //        }
        //    });
        //}
        //else {
        //    LoadImage();
        //}

        //function LoadImage() {

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
                if (Control.DefaultImageFrom.toLowerCase() != "none" && Control.IsFromPdf == false)
                    Control.DefaultImageFrom = "None";

                //   alert(Control.IsCropped);
                if (Control.BackgroundImage != "") {
                    $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                    Control.BackgroundImage = arry[0];
                }
                else
                    $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 2 + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 2 + 'px' });

                $("#" + Control.ObjectID + " img").attr('src', FrontEndDocumentPath + TemplateID + "/Images/" + arry[0]);
                $("#ImageFromGallery").dialog("close");
                alignsingleImage(Control.ObjectID);

            };
            $.ajax(FitImageToContoll);
        }
        //}
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
    changeThePageFromNavigation(parseInt($("#lblcurrentpage").html()), "currentpage")



    //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + "Gallery/OriginalImages/" + Control.BackgroundImage);
    bindMenuBar(Control.ObjectID);
    $("#" + Control.ObjectID).css('border', '1px solid #B2B2B2');
    $("#" + Control.ObjectID).css('cursor', 'pointer');
    $("#" + Control.ObjectID).draggable({ disabled: true });
    $("#" + Control.ObjectID).resizable({ disabled: true });
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
    $("#" + Control.ObjectID).draggable("enable");
    $("#" + Control.ObjectID).resizable("enable");
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
        $("#btnColorStrip").val((parseFloat(Control.C) * 100).toFixed(2));
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

//Added by shahbaz for field movement checking list have or not different Position X Value
function CheckForPositioninList(List) {
    var haveDifferent = false;
    for (var i = 0; i < List.length; i++) {
        var next = i + 1;
        if (next <= List.length - 1) {
            if (List[i].PositionX != List[next].PositionX)
                haveDifferent = true;
        }
    }
    return haveDifferent;
}

//Added By Shahbaz for get Height and Width of Rotated Div
function getHeightofRotatedDiv(degree, Width, base) {

    degree = parseInt(degree);
    Width = parseFloat(Width)
    base = parseFloat(base)
    var x = 0;
    x = (degree * Width) / 60
    if (degree > 35 && degree <= 90) {
        var oppAngle = 180 - (90 + degree);

        base = (oppAngle * Width) / 60;
        x = Math.sqrt(Width * Width - base * base)
    }



    if (degree > 90) {
        // x = Math.sin(180 - degree) * Width;
        //deg = 180 - degree;
        //x = (deg * Width) / 60

        x = Math.sqrt(Width * Width - base * base)

    }
    if (x < 0)
        x = -x;
    return parseFloat(x / mmConvertionConstant);
}

function getWidthofRotatedDiv(degree, Width) {
    degree = parseInt(degree);
    Width = parseFloat(Width)
    var x = 0;
    var deg = 0;
    //var x = Math.cos(deg) * Width;

    if (degree > 90 && degree <= 180) {
        //x = Math.sin(180 - degree) * Width;
        deg = 180 - degree;
        deg = 180 - (90 + deg);
        if (deg < 60) {
            x = (deg * Width) / 60
        }
        else
            x = Width;
    }

    if (degree > 180 && degree <= 270) {
        // deg = 270 - degree;
        deg = degree - 180;
        if (deg > 40) {
            deg = 180 - (90 + deg);
            x = (deg * Width) / 60
        }
        else
            x = Width;

    }

    if (x < 0)
        x = -x;
    return parseFloat(x / mmConvertionConstant);
}

function getActaulHeightOfRotatedControl(div, Angle) {

    var theta = Angle * Math.PI / 180;

    // Find the middle rotating point
    var midX = $(div).position().left + $(div).width();
    var midY = $(div).position().top + $(div).height();

    // Find all the corners relative to the center
    var cornersX = [$(div).position().left - midX, $(div).position().left - midX, $(div).position().left + $(div).width() - midX, $(div).position().left + $(div).width() - midX];
    var cornersY = [$(div).position().top - midY, $(div).position().top + $(div).height() - midY, midY - $(div).position().top, $(div).position().top + $(div).height() - midY];

    // Find new the minimum corner X and Y by taking the minimum of the bounding box
    var newX = 1e10;
    var newY = 1e10;
    for (var i = 0; i < 4; i = i + 1) {
        newX = Math.min(newX, cornersX[i] * Math.cos(theta) - cornersY[i] * Math.sin(theta) + midX);
        newY = Math.min(newY, cornersX[i] * Math.sin(theta) + cornersY[i] * Math.cos(theta) + midY);
    }

    // new width and height

    newWidth = midX - newX;
    newHeight = midY - newY;

    return [newWidth, newHeight];
}

function getWidthOfRotatedRectangularDiv(degree, width, height) {

    var x = 0;

    if (degree < 95) {
        var deg = (90 - degree);
        // deg = 180 - (90 + deg);
        //x = deg * width / 60
        x = Math.cos(deg * Math.PI / 180) * height;
    }
    else if (degree <= 110) {
        var deg = 180 - degree;
        x = Math.cos(deg * Math.PI / 180) * height;
    } else if (degree <= 180) {
        deg = 180 - degree
        x = Math.cos(deg * Math.PI / 180) * height;
        deg = 180 - (90 + deg)
        y = Math.cos(deg * Math.PI / 180) * width;
        x = x + y

    }

    if (degree > 180) {
        deg = 270 - degree;
        deg = 180 - (90 + deg);
        x = deg * width / 60
    }

    if (degree >= 220 && degree < 240) {
        deg = 180 - degree;
        deg = 180 - (90 + deg);
        x = Math.cos(deg * Math.PI / 180) * height
    }
    return x;
}

function getHeightofRotatedRectangularDiv(degree, Width, base, Height, control) {

    var x = 0;
    var deg = 0;
    if (degree <= 35) {
        deg = (90 - degree);
        base = deg * Width / 60
    }
    else if (degree < 90) {
        deg = 180 - (90 + degree);
        base = deg * Height / 60
    }
    else if (degree >= 120) {
        var deg = (180 - degree);
        deg = 180 - (90 + deg);
        base = deg * Width / 60
    }



    if (base > Width)
        base = base - (base - Width);

    //x = Math.sqrt(Width * Width - base * base);
    //x = 0;
    //if (x == 0) {
    if (degree < 45) {
        x = Math.sin(degree * Math.PI / 180) * Width;
    }
    else if (degree < 90) {
        deg = 180 - (90 + degree);
        x = Math.sin(deg * Math.PI / 180) * Width;
    }
    else if (degree > 180 && degree <= 270) {
        deg = degree - 180;
        deg = 180 - (90 + deg);
        x = Math.sin(deg * Math.PI / 180) * Width;
    }
    else if (degree > 270 && degree <= 360) {
        deg = degree - 270;
        deg = 180 - (90 + deg);
        x = Math.sin(deg * Math.PI / 180) * Width;
        x = Math.sqrt(Width * Width - x * x)
        x = x - (Math.sin(deg * Math.PI / 180) * Height);
    }
    // }

    var Actualsize = getActaulHeightOfRotatedControl(control, degree)

    x = Actualsize[1] - Height;

    if (degree > 135)
        x = Actualsize[0] - Height
    if (degree > 270 && degree <= 330)
        x = Height - Actualsize[0];
    return x;
}

function getHeightOfRotatedTextParaControl(degree, height, width, control) {
    var Actualsize = getActaulHeightOfRotatedControl(control, degree)
    var x = Actualsize[1] - height;
    if (degree > 270) {
        deg = degree - 270;
        x = Math.sin(deg * Math.PI / 180) * height;
    }
    return x;
}

function getWidthOfRotatedTextParaControl(degree, width, height) {
    var x = 0;

    if (degree < 95) {
        var deg = (90 - degree);
        x = Math.cos(deg * Math.PI / 180) * height;
    }
    else if (degree <= 110) {
        var deg = 180 - degree;
        x = Math.cos(deg * Math.PI / 180) * width;
    } else if (degree <= 180) {
        deg = 180 - degree
        x = Math.cos(deg * Math.PI / 180) * width;
        deg = 180 - (90 + deg)
        y = Math.cos(deg * Math.PI / 180) * height;
        x = x + y

    }

    if (degree > 180) {
        deg = 270 - degree;
        deg = 180 - (90 + deg);
        x = deg * height / 60
    }

    if (degree >= 220 && degree < 270) {
        deg = 270 - degree;
        deg = 180 - (90 + deg);
        x = Math.cos(deg * Math.PI / 180) * width
    }
    return x;
}
