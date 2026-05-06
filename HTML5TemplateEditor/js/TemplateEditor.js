/**********************************
Global Variables(Craeted By: Infomaze)
***********************************/

var textCanvasHeight, textCanvasWidth, curentPageNumber;
var Textheight = 4, ImageHeight = 26.15, ParaHeight = 13.23;
var Labelstyle, SitePhysicalPath, SitePath, FontPath, BackgroundImagesPath, WebMethodsPath, ImageUploadPath, DBKey, mainSitePath, SaveAndClose, saveAndExit;
var TemplateID, CompanyID, UserID, PriceCatalogId, ServicePath, ProductName, CategoryBindingList, FontList, imagecount = 0, imageloadedcount = 0;
var DepartmentCustomField, ContactCustomField;
var mmConvertionConstant = 3.779527559, ptConvertionConstant = 0.75;
var selectedControllID, selectedObjectID, controlheight;
var TemplateDetails, ControllDetails, ImagePath, FontList, HorizontalGroupingData, VerticalGroupingData, ColorStyleDetails, FontStyleDetails;
var ImageWidth;
var cutID, cutCopy, copyID, totalSize = 0, filelist = "", filelistSingle = "", AssignedFilesAndFolders, Edited = 'false', PopupLoad = true, saved = false, copy = false, isFromQuickAdjustSaveNStay = false, isFromQuickAdjustSaveNclose = false, isFromManageGroupSaveNStay = false;

/**********************************
Page Load Events(Craeted By: Infomaze)
***********************************/

/*Function that executes first when document is ready*/ 
$(function () {
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

                loadHorizontalGroupingData();
                loadVerticalGroupingData();
                loadPopups();
                loadPage();

                loadEventsForMenuBar();
                LoadInformationPanelEvents();
                LoadLayoutAndPropertiesPanelEvents();
                LoadGalleryFileUploadEvents();
                LoadFontPanelEvents();
                LoadColorPanelEvents();
                LoadDefaultContentPanelEvents();
                LoadLabelPanelEvents();
                LoadSaveTemplatePanelEvents();

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
                            $("#lblProductName").html(ProductName);
                        }
                    });
                }

            }
        });
    }

});

/*Load Jquery Ui popups*/
function loadPopups() {
    $("#accordion").accordion({
        collapsible: true,
        heightStyle: "content",
        beforeActivate: function (event, ui) {
            if ($("#capitilizationdiv").css('display') == 'block')
                $("#capitilization").trigger('click');
            if ($("#justifydiv").css('display') == 'block')
                $("#justify").trigger('click');
        }
    });

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
        height: 450,
        width: 1125,
        modal: true,
        close: function () {
            $("#groupWinFooter").remove();
        }
    });

    $("#ManageGroupAddGroup").dialog({
        effect: "clip",
        autoOpen: false,
        height: 590,
        resizable: false,
        width: 900,
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
                if (Edited == 'true') {
                    originalFilename = array[0] + "-" + GUID.substr(0, 3) + "." + array[1];
                    obj.saveImageOnServer(originalFilename, true);
                } else {
                    FitTheEditedImageToControl(originalFilename);
                }
                $(this).dialog("close");
                //setTimeout(function () {//Commented by Shahbaz             
                //    // FitTheEditedImageToControl(originalFilename);
                //}, 5000);

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
                if (Edited == 'true') {
                    originalFilename = array[0] + "-" + GUID.substr(0, 3) + "." + array[1];
                }
                obj.saveImageOnServer(originalFilename, true);
                $(this).dialog("close");
                setTimeout(function () {
                    // FitTheEditedImageToControl(originalFilename);
                    if (Control.BackgroundImage != "")
                        $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' })
                }, 1000);

                //for Adding Image on gallery after save as new clicked
                filelist += "" + "~" + originalFilename + "~" + parseInt(620888) + ",";
                $.ajax({
                    url: ServicePath + "InsertImageGallery",
                    type: "POST",
                    data: JSON.stringify({ companyid: CompanyID, templateid: TemplateID, categoryid: 0, userid: UserID, usertype: "admin", fileList: filelist, description: "", metatags: "", _key: DBKey }),
                    dataType: "json",
                    processData: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (imageList) {

                        var typeid = imageList.d.split(',')[0];
                        $.ajax({
                            url: ServicePath + "Insert_ImageGalleryAssignment_Onclick",
                            type: "POST",
                            data: JSON.stringify({ objectid: selectedObjectID, companyid: CompanyID, templateid: TemplateID, userid: UserID, type: "f", typeid: typeid, isdefault: true, _key: DBKey }),
                            dataType: "json",
                            processData: false,
                            contentType: "application/json; charset=utf-8",
                            success: function () {

                                var exceedimage = "";

                                //ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

                                //Control.ImgUrl = arry[0];
                                //Control.OrignalImageName = arry[2];
                                //Control.IsFromBackEnd = true;
                                //Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                                //Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
                                //$("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
                                //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);

                                //alignsingleImage(Control.ObjectID);
                            }
                        });
                    }
                });
            }
        },
        open: function () {
            $("#RadImageEditor1_ToolsPanel").removeClass("imageEditorPopUp");
            $("#RadImageEditor1_ToolsPanel").addClass("imageEditorPopUp");
            var obj = GetEditor();
            PopupLoad = true;
            obj.changeImageOpacity(100, true)
        },
        close: function () {
            var obj = GetEditor();
            obj.closeToolsPanel();
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
        my: 'center',
        buttons: {
            OK: function () {

                if (saveAndExit == true) {

                    window.close();
                }
                $(this).dialog("close");
                $(".loadingNewMask").css('z-index', '110').hide();
                //  $(".QuickAdjustloadingNewMask").hide()
                $(".MessagesPopuploadingNewMask").hide()

                if (isFromQuickAdjustSaveNclose)
                    $("#QuickAdjustDialog").dialog('close');
            }
        },
        close: function () {
            $(".loadingNewMask").css('z-index', '110').hide();
            $(".MangaeGrouploadingNewMask").css('z-index', '102').hide();
            $(".MessagesPopuploadingNewMask").hide();
            //$(".QuickAdjustloadingNewMask").hide()            
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
            $(".MangaeGrouploadingNewMask").css('z-index', '102').hide();
        }
    });



    $("#ErrorMsg").dialog({
        effect: "clip",
        autoOpen: false,
        resizable: false,
        modal: true,
        width: 'auto',
        height: 125,
        at: 'center',
        my: 'center',
        buttons: {
            OK: function () {
                $(this).dialog("close")
                $(".ErrorMsgloadingNewMask").hide();
            },
        },
        close: function () {
            $(".ErrorMsgloadingNewMask").hide();
        }
    });

    $("#ImageFromGallery").dialog({
        effect: "clip",
        autoOpen: false,
        width: 690,
        resizable: false,
        height: 505,
        modal: true,
        open: function () {
            File = [];
            $("#btnUploadText").html("Browse");
            $("#btnSelectFiles").css({ 'width': '46px', 'margin-left': '315px' });
        },
        close: function () {
            $('#multipleFileUpload').val("");
            $("#fileList").empty();
            filelist = "";
            File = [];
            $("#btnUploadText").html("Browse");
            $("#btnSelectFiles").css({ 'width': '46px', 'margin-left': '315px' });
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
            //$(".loadingNewMask").hide();
            $(".QuickAdjustloadingNewMask").css('z-index', '102').hide();
            $(".btnUpdateImageloading").hide();
            $(".btnUpdateImage").show();
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
                $("#fontColor").hide();

                if ($("#tbdy_QuickAdjustControl").html() == "") {
                    $("#savemsg").html("No item available!");
                    $("#SaveMessage").dialog("open");
                    var z_index = parseInt($("div[aria-describedby=QuickAdjustDialog]").css('z-index'));
                    $(".MessagesPopuploadingNewMask").css('z-index', z_index + 1).show()
                }
                else {
                    isFromQuickAdjustSaveNStay = true;
                    isFromQuickAdjustSaveNclose = false;

                    //Added By shahbaz if Color is changed from Quick Adjust Dailog
                    for (var i = 0; i < ControllDetails.length; i++) {
                        if (ControllDetails[i].IsTempColor) {
                            ControllDetails[i].C = ControllDetails[i].TempC;
                            ControllDetails[i].M = ControllDetails[i].TempM;
                            ControllDetails[i].Y = ControllDetails[i].TempY;
                            ControllDetails[i].Y = ControllDetails[i].TempY;
                            ControllDetails[i].K = ControllDetails[i].TempK;


                            ControllDetails[i].R = ControllDetails[i].TempR;
                            ControllDetails[i].G = ControllDetails[i].TempG;
                            ControllDetails[i].B = ControllDetails[i].TempB;
                        }

                    }

                    SaveQuickAdjustDetails();
                }

            },
            "Save & Close": function () {

                if ($("#tbdy_QuickAdjustControl").html() == "") {
                    $("#savemsg").html("No item available!");
                    $("#SaveMessage").dialog("open");
                    var z_index = parseInt($("div[aria-describedby=QuickAdjustDialog]").css('z-index'));
                    $(".MessagesPopuploadingNewMask").css('z-index', z_index + 1).show();
                    isFromQuickAdjustSaveNStay = false;
                    isFromQuickAdjustSaveNclose = true;
                } else {
                    //Added By shahbaz if Color is changed from Quick Adjust Dailog
                    for (var i = 0; i < ControllDetails.length; i++) {
                        if (ControllDetails[i].IsTempColor) {
                            ControllDetails[i].C = ControllDetails[i].TempC;
                            ControllDetails[i].M = ControllDetails[i].TempM;
                            ControllDetails[i].Y = ControllDetails[i].TempY;
                            ControllDetails[i].Y = ControllDetails[i].TempY;
                            ControllDetails[i].K = ControllDetails[i].TempK;


                            ControllDetails[i].R = ControllDetails[i].TempR;
                            ControllDetails[i].G = ControllDetails[i].TempG;
                            ControllDetails[i].B = ControllDetails[i].TempB;
                        }

                    }

                    SaveQuickAdjustDetails();
                    $("#fontColor").hide();
                    isFromQuickAdjustSaveNStay = false;
                    isFromQuickAdjustSaveNclose = true;
                    //$(this).dialog("close");
                }
            }
        },
        close: function () {
            isFromQuickAdjustSaveNclose = false;
            isFromQuickAdjustSaveNStay = false;
            $("#fontColor").hide();
            for (var i = 0; i < ControllDetails.length; i++) {
                ControllDetails[i].IsTempColor = false;
            }
        }

    });

    designPoups();

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
        },
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

    designPoups();
}

/*Loading the page details*/
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

            $("#textCanvas").css('width', textCanvasWidth + "px");
            $("#textCanvas").css('height', textCanvasHeight + "px");
            var imagepath = BackgroundImagesPath + TemplateDetails.ImageName;
            ImagePath = imagepath;
            $("#textCanvas").css({ 'background-image': "url('" + imagepath + "')", 'background-repeat': 'no-repeat' });
            var mainCanWidth = textCanvasWidth * zoomTemp;
            var maincanheight = textCanvasHeight * zoomTemp;
            //$("#Maincanvas").css('width', mainCanWidth + 'px');
            $("#Maincanvas").css('height', maincanheight + 'px');

            $("#chkAllowTextBlock").prop('checked', TemplateDetails.AddNewTextBlock);
            $("#chkAllowParagraph").prop('checked', TemplateDetails.AddNewParagraph);
            $("#chkAllowImage").prop('checked', TemplateDetails.AddNewImage);
            $("#chkShowEditor").prop('checked', TemplateDetails.ShowEdiotr);
            $("#chkShoweditablePages").prop('checked', TemplateDetails.ShowEditablePages);
            $("#chkSendAttachments").prop('checked', TemplateDetails.SendAttachment);
            $("#chkGroupConsider").prop('checked', TemplateDetails.IsGroupConsiderLabel);
            getCustomFields();
            //$("#Menubar select").css({ 'background': '#FFFFFF url(' + SiteImages + 'arrow-down.png) no-repeat 100% center', '-webkit-appearance': 'none', '-moz-appearance': ' none' });
            loadFontStyeDropDowns();
            var ZoomIn = zoomTemp;
            zoomTextCanvas(ZoomIn);

        }
    });
}

/*Getting defalut Custom Field to Bind contact and dept Dropdwon*/
function getCustomFields() {
    $.ajax({
        url: ServicePath + "LoadDefaultDeptCustomFields",
        type: "POST",
        data: JSON.stringify({ companyid: CompanyID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (DatabaseContent) {
            DepartmentCustomField = DatabaseContent.d;
        }
    });

    $.ajax({
        url: ServicePath + "LoadDefaultContactCustomFields",
        type: "POST",
        data: JSON.stringify({ companyid: CompanyID, _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (DatabaseContent) {
            ContactCustomField = DatabaseContent.d;
        }
    });
}

/*Loading the font and color style list for dropdowns*/
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
                        LoadColorStyleDropDowns();
                    }
                });
            }
        }
    });

}

function LoadColorStyleDropDowns() {
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
            LoadFontDropDowns();
        }
    });
}

/*Loading the controlls on the canvas on page load*/
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

/*Loading the list for other dropdowns*/
function LoadFontDropDowns() {
    debugger;
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
            LoadDataBaseContent();

        }
    });

}

function LoadDataBaseContent() {
    $.ajax({
        url: ServicePath + "LoadDataBaseContents",
        type: "POST",
        data: JSON.stringify({ _key: DBKey }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (DatabaseContent) {
            for (var i = 0; i < DatabaseContent.d.length; i++) {
                loadDatabaseContentFieldsDropDown(DatabaseContent.d[i].Label, DatabaseContent.d[i].ContentType, DatabaseContent.d[i].Tag, DatabaseContent.d[i].ActualField);
            }
            LoadPhraseDropDown();
        }
    });
}

function LoadPhraseDropDown() {

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
        LoadTemplateCopyDropDown();
    };

    $.ajax(loadPhraseDropdown);

}

function LoadTemplateCopyDropDown() {
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
            loadControlls();

            //Added for make Template name text field blank if Product Template name already exist(by shahbaz)
            //for (var k = 0; k < TemplateIDandNameList.length; k++) {
            //    var arry = TemplateIDandNameList[k].split('~');
            //    if (arry[1].toLowerCase() == ($('#txtTemplateName').val().toLowerCase())) {
            //        $('#txtTemplateName').val("");
            //        break;
            //    }
            //}
        }
    });

}

/*Loading the category list for dropdown*/
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

/*Binding the font dropdown*/
function loadFontDropdown(fontName, fontFilePath, FontID, ActualFontName, id, selcted) {
    if (selcted == "none") {
        $(id).append("<option value='" + fontFilePath + "~" + FontID + "~" + ActualFontName + "~" + fontName + "' id='drpFontID" + FontID + "' >" + fontName + "</option>");
    }
}

/*Binding the font style dropdowns*/
function loadFontStyleDropdown(fontStyleName, fontStyleID) {
    $("#drpFontStyle").append("<option value='" + fontStyleID + '~' + fontStyleName + "' id='drpFontStyleID" + fontStyleName.replace(/ /g, "") + "' >" + fontStyleName + "</option>");
    $("#drplabelFontStyle").append("<option value='" + fontStyleID + '~' + fontStyleName + "' id='drpLabelFontStyleID" + fontStyleName.replace(/ /g, "") + "' >" + fontStyleName + "</option>");
}

/*Binding the color style dropdowns*/
function loadColorStyleDropdown(colorStyleName, colorStyleID) {
    $("#drpColorStyle").append("<option value='" + colorStyleName + "' id='drpColorStyleID" + colorStyleName.replace(/ /g, "") + "'>" + colorStyleName + "</option>");
    $("#drplabelColorStyle").append("<option value='" + colorStyleName + "' id='drpLabelColorStyleID" + colorStyleName.replace(/ /g, "") + "'>" + colorStyleName + "</option>");

}

/*Binding the copy template dropdowns*/
function loadTempleteForCopyDropDown(TemplateID, TemplateName) {

    $("#dtlstcopy").append("<option id='" + TemplateID + "'>" + TemplateName + "</option>");
    // $("#drpTemplteForCopy").append("<option value='" + TemplateID + "' >" + TemplateName + "</option>");    
}

/*Binding the database fields dropdowns*/
function loadDatabaseContentFieldsDropDown(Label, Type, Tag, Actual) {
    var Exist = false;
    if (Type == "Contact") {
        if (ContactCustomField.length > 0) {
            for (var i = 0; i < ContactCustomField.length; i++) {
                if (ContactCustomField[i].FieldNameKey == Actual) {
                    Tag = ContactCustomField[i].FieldName;
                    Label = ContactCustomField[i].ScreenName;
                    break;
                }
            }
        }

        $("#drpContactFields").append("<option value='" + Tag + "~" + Type + "' >" + Label + "</option>");
    }
    else if (Type == "Department") {
        if (DepartmentCustomField.length > 0) {
            for (var i = 0; i < DepartmentCustomField.length; i++) {
                if (DepartmentCustomField[i].FieldNameKey == Actual) {
                    Tag = DepartmentCustomField[i].FieldName;
                    Label = DepartmentCustomField[i].ScreenName;
                    break;
                }
            }
        }
        $("#drpDepartmentFields").append("<option value='" + Tag + "~" + Type + "' >" + Label + "</option>");
    }
}

/*Binding the phrase text fields dropdowns*/
function loadPhraseDefaultCotentDropDown(Title, PhraseID) {

    $("#drpPhraseCustomFields").append("<option value='" + PhraseID + "' id='drpop_" + PhraseID.split('/')[0] + "' >" + Title + "</option>");
}

/*Binding the page dropdown*/
function bindPageDropdown() {
    pageNumber = parseInt(TemplateDetails.Totalpage);
    $("#lbltotalpage").html("/" + pageNumber);
    if (pageNumber > 1) {
        for (var i = 2; i <= pageNumber; i++) {
            $("#drpPageSelect").append("<option value='" + i + "'>" + i + "</option>");
        }
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

/**********************************
Left Panel Main Buttons(Craeted By: Infomaze)
***********************************/

/*Adding Text Control on the Canvas when Add Text button Click*/
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
        "LabelValue": "",
        "IsImageQuality": false,
        "MinDPI": 0,
        "isDisplayonPDf": false,
        "DefaultImageFrom": "None",
        "CustomFieldType": "",
        "UsedImageID": "0",
        "IsFromPdf": false,
        "IsLabelOnLeft": false,
        "AllowImageEdit": false,
        "IsJobNameField": false,
        "PhoneFormat": "None",
        "CurrencyFormat":"None",
        "EditDropdown": false
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

/*Adding Image Control on the Canvas when Add Text button Click*/
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
        "FontStyleName": "",
        "IsImageQuality": false,
        "MinDPI": 0,
        "isDisplayonPDf": false,
        "DefaultImageFrom": "None",
        "CustomFieldType": "",
        "UsedImageID": "0",
        "IsFromPdf": false,
        "IsLabelOnLeft": false,
        "AllowImageEdit": false,
        "IsJobNameField": false,
        "PhoneFormat": "None",
        "CurrencyFormat": "None",
        "EditDropdown": false
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

/*Adding ParaGraph Control on the Canvas when Add Text button Click*/
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
        "LabelValue": "",
        "IsImageQuality": false,
        "MinDPI": 0,
        "isDisplayonPDf": false,
        "DefaultImageFrom": "None",
        "CustomFieldType": "",
        "UsedImageID": "0",
        "IsFromPdf": false,
        "IsLabelOnLeft": false,
        "AllowImageEdit": false,
        "IsJobNameField": false,
        "PhoneFormat": "None",
        "CurrencyFormat": "None",
        "EditDropdown": false
    }))
    deSelect();
    ControllDetails.push(jsonStringFotText);
    AddParaDynamically(jsonStringFotText, true);
    if ($(".contentProperties").css('display') == 'block') {
        $(".PropertiesPanel").trigger('click');
        $(".PropertiesPanel").hide();
    }
}

/*Adding Date Control on the canvas when Add Date btn Click*/
function AddDate() {
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
        "DefaultContent": "",
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
        "LabelValue": "",
        "IsImageQuality": false,
        "MinDPI": 0,
        "isDisplayonPDf": false,
        "DefaultImageFrom": "None",
        "CustomFieldType": "Date",
        "UsedImageID": "0",
        "IsFromPdf": false,
        "IsLabelOnLeft": false,
        "AllowImageEdit": false,
        "IsJobNameField": false,
        "PhoneFormat": "None",
        "CurrencyFormat": "None",
        "EditDropdown": false
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

/*********************************
Manage Group Popup(Craeted By: Infomaze)
*********************************/
/*Open Manage Group Popup when Manage Group button click*/
function openManageGroup() {
    if (VerticalGroupingData.length > 0 || HorizontalGroupingData.length > 0) {
        loadManageExistingGroup();
    }
    else {
        loadNoGroup();
    }
    $(".btnAddGroup").click(function () {

        var atleastOneVisible = false;
        //Added by shahbaz for given alert if no contol available on canvas
        if (ControllDetails.length > 0) {
            for (var i = 0; i < ControllDetails.length; i++) {
                if (ControllDetails[i].Visibility && ControllDetails[i].GroupID == 0 && ControllDetails[i].Type != "Image")
                    atleastOneVisible = true;
            }
            if (atleastOneVisible)
                loadEditGroup("AddGroup");
            else {
                $("#savemsg").html("No Fileds available to create group, Please add controls");
                $("#SaveMessage").dialog("open");
                $(".MangaeGrouploadingNewMask").css('z-index', '102').show();
            }
        }
        else {
            $("#savemsg").html("No Fileds available to create group, Please add controls");
            $("#SaveMessage").dialog("open");
            $(".MangaeGrouploadingNewMask").css('z-index', '102').show();

        }

        if ($(this).attr('id') == "addGropFromExistingGroup" && atleastOneVisible) {
            $("#ManageGroupExistingGroup").dialog("close");
        }
        else {
            $("#ManageGroupNogroup").dialog("close");
        }

    });
}

/*Open Quick Adjust Popup when Quick Adjust button click*/
function openQuickAdjust() {

    loadQuickAdjust();
}

/*Open load Manage Existing group popup*/
function loadManageExistingGroup() {

    $("#ManageGroupExistingGroup").dialog("open");
    var ExistingGroupsHtml = "<tr style='background-color:#D8D8D8;' class='Heading'><td ><span style='margin-left:5px;'>Type</span></td><td>Control Name</td><td>Page</td><td>X-Position</td><td>Y-Position</td><td>Field Movement Options</td><td>Font Style</td><td>Color</td><td style='text-align:center;' class='actions'>Actions</td></tr>";
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
            //ExistingGroupsHtml += "<td><div style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
            ExistingGroupsHtml += "<td class=''><div class='txtColorDisabled' style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:45px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:5px;Color:#b2b2b2;height: 12px'>A</div><div style='width: 15px;height: 5px;margin-left: 3px;background-color:rgba(0, 0, 0, 255);opacity:.6'></div></div></td>";
            ExistingGroupsHtml += "<td style='text-align:center;' class='actions'><img class='image EditGroup exist Vertical' title='Edit Group' src='StyleSheets/Images/edit-icon.png'  id='btnEditGroup_" + VerticalGroupingData[i].GID + "' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:1px solid transparent;border-radius: 10px;padding:1px;' /><img class='image DeleteGroup exist Vertical' id='btnDeleteGrp_" + VerticalGroupingData[i].GID + "' title='Delete Group' src='StyleSheets/Images/cross.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:2px solid transparent;border-radius: 10px;padding:1px;' /></td>";
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
            //ExistingGroupsHtml += "<td><div style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
            ExistingGroupsHtml += "<td class=''><div class='txtColorDisabled' style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:45px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:5px;Color:#b2b2b2;height: 12px'>A</div><div style='width: 15px;height: 5px;margin-left: 3px;background-color:rgba(0, 0, 0, 255);opacity:.6'></div></div></td>";
            ExistingGroupsHtml += "<td style='text-align:center;' class='actions'><img class='image EditGroup exist Horizontal' title='Edit Group' src='StyleSheets/Images/edit-icon.png' id='btnEditGroup_" + HorizontalGroupingData[i].GID + "' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:1px solid transparent;border-radius: 10px;padding:1px;' /><img id='btnDeleteGrp_" + HorizontalGroupingData[i].GID + "' class='image exist DeleteGroup Horizontal' title='Delete Group' src='StyleSheets/Images/cross.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:2px solid transparent;border-radius: 10px;padding:1px;' /></tr>";
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
    $("#ManageGroupExistingGroupTable select").css({ 'background-color': '#EBEBE4', 'background-image': 'url(none)', 'border': '1px solid #BDBDB9' });

    $("#ManageGroupExistingGroupTable .image").unbind('mouseenter').bind('mouseenter', function () {
        $(this).css({ 'border': '1px solid #000000' });
    });
    $("#ManageGroupExistingGroupTable .image").unbind('mouseleave').bind('mouseleave', function () {
        $(this).css({ 'border': '1px solid transparent' });
    });
    $(".GroupcontentTr td").css({ 'padding-right': '35px' });//Change padding-right from 40 to 35(20/11/2015)
    $("td.actions").css({ 'padding-right': '5px' });
    $(".ui-dialog-buttonset").css({ 'width': 'auto' });



    var footerDiv = "";
    footerDiv += '  <div id="groupWinFooter" style="padding: 10px;"><div class="size11" style="font-weight: bold;">Please Note:</div><div class="size11">';
    footerDiv += ' When fields are used in a group the X and Y co-ordinates that are used in the group override the co-ordinates in the individual fields.'
    footerDiv += ' </div><div class="size11">In the editable product settings screen you still see the fields in the position that their individual X and Y co-ordinates placed them in.';
    footerDiv += '</div><div class="size11">In the eStore customer view you see the fields positioned using the X and Y co-ordinates from the group.</div></div>';
    if ($("#groupWinFooter").length == 0)
        $("div[aria-describedby=ManageGroupExistingGroup]").append(footerDiv)

    deleteAndEditGroupFuction();
}

/*Open No group popup*/
function loadNoGroup() {
    $("#ManageGroupNogroup").dialog("open");
    $("div[aria-describedby=ManageGroupNogroup] .ui-widget-header img").remove();
    $("div[aria-describedby=ManageGroupNogroup] .ui-widget-header").prepend("<img src='StyleSheets/Images/stock_group.png' width='15' height='15' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
    $('.ui-widget-overlay').css({ 'background': '#6D6368', 'opacity': '.6' });

    $("#rdOreintationHorizontal").unbind('click').bind('click', function () {
        if ($(this).prop('checked')) {
            $("#drpFieldMovement").prop('disabled', true);
            $("#chkConsiderGroup").prop('disabled', true);
            $("#chkparaGroup").prop('disabled', true);
        }
    });
    $("#rdOreintationVertical").unbind('click').bind('click', function () {
        if ($(this).prop('checked')) {
            $("#drpFieldMovement").prop('disabled', false);
            $("#chkConsiderGroup").prop('disabled', false);
            $("#chkparaGroup").prop('disabled', false);
        }
    });
}

/*Delete and Edit Existing Group events */
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

/*Load edit and add Group Popup*/
function loadEditGroup(Function, ID, oreintation, GoBack) {
    ControllDetails = sortJSON(ControllDetails, "OrderNumber", "ASC");
    $("#ManageGroupAddGroup").dialog("open");
    var GroupPage, postionX, postionY, spacingBtwnFields, groupAlignMent, groupName, isParaGroup, isConsiderLabel, GroupMoveRelative, GroupMovementValue;;
    if (Function == "EditGroup") {
        if (oreintation == "Vertical") {
            $("#rdOreintationVertical").prop('checked', true);
            $("#rdOreintationHorizontal").prop('disabled', true);
            $("#drpFieldMovement").prop('disabled', false);
            $("#rdOreintationVertical").prop('disabled', false);
            $("#chkConsiderGroup").prop('disabled', false);
            $("#chkparaGroup").prop('disabled', false);
            for (var i = 0; i < VerticalGroupingData.length; i++) {
                if (VerticalGroupingData[i].GID == ID) {
                    GroupPage = VerticalGroupingData[i].PageNumber;
                    postionX = VerticalGroupingData[i].PositionX;
                    postionY = VerticalGroupingData[i].PositionY;
                    spacingBtwnFields = VerticalGroupingData[i].ControlSpace;
                    groupAlignMent = VerticalGroupingData[i].Alignment;
                    groupName = VerticalGroupingData[i].GroupName;
                    isParaGroup = VerticalGroupingData[i].IsParaGroup;
                    isConsiderLabel = VerticalGroupingData[i].IsConsiderLabel;
                    GroupMoveRelative = VerticalGroupingData[i].GroupMoveRelative;
                    GroupMovementValue = VerticalGroupingData[i].GroupMovementValue;
                    if (isConsiderLabel)
                        $("#chkConsiderGroup").prop('checked', true);
                    else
                        $("#chkConsiderGroup").prop('checked', false);
                    LoadVerticalkeepoption(VerticalGroupingData[i].GrpKeepOption);
                    LoadGroupOption(VerticalGroupingData[i].GroupOption);
                    break;
                }
            }

            if (isParaGroup) {
                $("#chkparaGroup").prop('checked', true);
                $("#chkConsiderGroup").prop('disabled', true);
            } else {
                $("#chkparaGroup").prop('checked', false);
                $("#chkConsiderGroup").prop('disabled', false);
            }
            $("#chkparaGroup").unbind("change").bind('change', function () {
                if (this.checked) {
                    $("#chkConsiderGroup").prop('checked', false);
                    $("#chkConsiderGroup").prop('disabled', true);
                } else {
                    $("#chkConsiderGroup").prop('checked', false);
                    $("#chkConsiderGroup").prop('disabled', false);
                }
            });
        }
        else {
            $("#rdOreintationHorizontal").prop('disabled', false);
            $("#rdOreintationHorizontal").prop('checked', true);
            $("#rdOreintationVertical").prop('disabled', true);
            $("#drpFieldMovement").prop('disabled', true);
            $("#chkConsiderGroup").prop('disabled', true);
            $("#chkConsiderGroup").prop('checked', false);
            $("#chkparaGroup").prop('checked', false);
            $("#chkparaGroup").prop('disabled', true);
            for (var i = 0; i < HorizontalGroupingData.length; i++) {
                if (HorizontalGroupingData[i].GID == ID) {
                    GroupPage = HorizontalGroupingData[i].PageNumber;
                    postionX = HorizontalGroupingData[i].PositionX;
                    postionY = HorizontalGroupingData[i].PositionY;
                    spacingBtwnFields = HorizontalGroupingData[i].ControlSpace;
                    groupAlignMent = HorizontalGroupingData[i].Alignment;
                    groupName = HorizontalGroupingData[i].GroupName;
                    GroupMoveRelative = HorizontalGroupingData[i].GroupMoveRelative;
                    GroupMovementValue = HorizontalGroupingData[i].GroupMovementValue;
                    isParaGroup = false;
                    LoadHorizontalkeepoption(HorizontalGroupingData[i].GrpKeepOption);
                    LoadGroupOption(HorizontalGroupingData[i].GroupOption);
                    break;
                }
            }
        }
    }
    if (Function == "AddGroup") {
        $("#rdOreintationVertical").prop('disabled', false);
        $("#rdOreintationHorizontal").prop('disabled', false);
        $("#chkConsiderGroup").prop('disabled', false);
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
        $("#drpFieldMovement").prop('disabled', false);
        $("#rdOreintationVertical").prop('disabled', false);
        $("#chkparaGroup").prop('checked', false);
        $("#chkparaGroup").prop('disabled', false);

        $("#chkConsiderGroup").prop('checked', false);
        $("#chkConsiderGroup").prop('disabled', false);
        $(".SaveandStayGroup").attr('id', 'btnSaveandStay_' + 0);
        $(".SaveandCloseGroup").attr('id', 'btnSaveandClose_' + 0);

        $("div[aria-describedby=ManageGroupAddGroup] .ui-dialog-title").html("Manage Group");
        $("div[aria-describedby=ManageGroupAddGroup] .ui-widget-header img").remove();
        $("div[aria-describedby=ManageGroupAddGroup] .ui-widget-header").prepend("<img id='ImgGrpTitle' src='StyleSheets/Images/stock_group.png' width='15' height='15' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");

        $("#chkparaGroup").unbind('change').bind('change', function () {
            if (this.checked) {
                $("#rdOreintationVertical").prop('checked', true);
                $("#drpFieldMovement").prop('disabled', false);
                $("#rdOreintationVertical").prop('disabled', false);
                $("#rdOreintationHorizontal").prop('disabled', true);
                $("#chkConsiderGroup").prop('checked', false);
                $("#chkConsiderGroup").prop('disabled', true);
            } else {
                $("#rdOreintationVertical").prop('checked', true);
                $("#drpFieldMovement").prop('disabled', false);
                $("#rdOreintationVertical").prop('disabled', false);
                $("#rdOreintationHorizontal").prop('disabled', false);
                $("#chkConsiderGroup").prop('checked', false);
                $("#chkConsiderGroup").prop('disabled', false);
            }
        });
    }
    else if (Function == "EditGroup") {
        $("#txtGropuName").val(groupName);
        $("#txtGroupPostionX").val(postionX);
        $("#txtGroupPostionY").val(postionY);
        $("#txtrSpacingBtwnFields").val(spacingBtwnFields);
        $("#chkRelativeGroupOption").prop('checked', GroupMoveRelative);
        $("#txtGroupMovementValue").val(GroupMovementValue);
        if (groupAlignMent.toLowerCase() == "left") {
            $("#rdGroupLeftAlign").prop('checked', true);
        }
        else if (groupAlignMent.toLowerCase() == "center") {
            $("#rdGroupCentertAlign").prop('checked', true);
        }
        else if (groupAlignMent.toLowerCase() == "right") {
            $("#rdGroupRightAlign").prop('checked', true);
        }



        $("div[aria-describedby=ManageGroupAddGroup] .ui-dialog-title").html("Edit Group");
        //  $("div[aria-describedby=ManageGroupAddGroup] .ui-widget-header  img").src("StyleSheets/Images/editgrp.png")
        $("div[aria-describedby=ManageGroupAddGroup] .ui-widget-header img").remove();
        $("div[aria-describedby=ManageGroupAddGroup] .ui-widget-header").prepend("<img id='ImgGrpTitle' src='StyleSheets/Images/editgrp.png' width='20' height='20' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
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


    $("#chkConsiderGroup").unbind('change').bind('change', function () {
        if (ID != 0) {
            var group;
            VerticalGroupingData.map(function (proj) { if (proj.GID == ID) group = proj });
            if ($(this).prop('checked') == true) {
                group.IsConsiderLabel = true;
            }
            else {
                group.IsConsiderLabel = false;
            }
        }
    });

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
        var isparagroupchecked = $("#chkparaGroup").prop("checked");
        var RelativeGroupOption = $("#chkRelativeGroupOption").prop("checked");
        var GroupMovementValue = $("#txtGroupMovementValue").val();
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
        var noparacontrol = false;
        $("#groupFields").find('div').each(function () {
            controllIds += $(this).attr('id').split('_')[1] + "~";
            if (isparagroupchecked) {
                if ($("#" + $(this).attr('id').split('_')[1]).hasClass("Text")) {
                    noparacontrol = true;
                }
            }
        });


        var arry = controllIds.split('~');
        if (arry.length < 3) {
            $("#Message").dialog('open');
            $("#msg").html("Please select minimum of two controls to create group");
            msgBoxDesign();
            var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
            $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
            return false;
        }

        if (noparacontrol) {
            $("#Message").dialog('open');
            $("#msg").html("Please select only paragraph controls to create paragraph group");
            msgBoxDesign();
            var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
            $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
            return false;
        }

        $(".loading_new").show();
        var groupid = id[1];

        //added by shahbaz for Order Field in Group
        //for (var i = 0; i < $("#groupFields").children().length; i++) {
        //    var Control = ''
        //    ControllDetails.map(function (proj) {
        //        var CurrentGroupField = $("#groupFields").children()[i]
        //        if (proj.FieldName == $(CurrentGroupField).html()) Control = proj
        //    });
        //    Control.GroupOrder = i;
        //}
        var ParaGroup = false;
        if ($("#chkparaGroup").is(":checked")) {
            ParaGroup = true
        }
        var isConsiderlabel = false;
        if ($("#chkConsiderGroup").is(":checked")) {
            isConsiderlabel = true
        }

        $.ajax({
            url: ServicePath + "insertGroup",
            type: "POST",
            data: JSON.stringify({ orentation: oreint, groupname: groupNamee, templateid: TemplateID, companyid: CompanyID, groupid: groupid, keepoption: groupKeepOption, controlspace: controllSpace, positionx: groupPositionX, positiony: groupPositionY, align: groupAlign, pagenumber: pageNumberr, grpOption: groupOption, IsParaGroup: ParaGroup, IsConsiderLabel: isConsiderlabel, GroupMoveRelative: RelativeGroupOption, GroupMovementValue: GroupMovementValue, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (GID) {
                isFromManageGroupSaveNStay = true;
                loadGropDataAfterSave(oreint, groupNamee, id[1], groupKeepOption, controllSpace, groupPositionX, groupPositionY, groupAlign, pageNumberr, groupOption, controllIds, GID, true, ParaGroup, isConsiderlabel, RelativeGroupOption, GroupMovementValue);

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
        var isparagroupchecked = $("#chkparaGroup").prop("checked");
        var RelativeGroupOption = $("#chkRelativeGroupOption").prop("checked");
        var GroupMovementValue = $("#txtGroupMovementValue").val();
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
        var noparacontrol = false;
        $("#groupFields").find('div').each(function () {
            controllIds += $(this).attr('id').split('_')[1] + "~";
            if (isparagroupchecked) {
                if ($("#" + $(this).attr('id').split('_')[1]).hasClass("Text")) {
                    noparacontrol = true;
                }
            }
        });


        var arry = controllIds.split('~');
        if (arry.length < 3) {
            $("#Message").dialog('open');
            $("#msg").html("Please select minimum of two controls to create group");
            msgBoxDesign();
            var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
            $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
            return false;
        }

        if (noparacontrol) {
            $("#Message").dialog('open');
            $("#msg").html("Please select only paragraph controls to create paragraph group");
            msgBoxDesign();
            var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
            $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
            return false;
        }

        $("#ManageGroupAddGroup").dialog("close");
        $(".loading_new").show();
        var groupid = id[1];


        //for (var i = 0; i < $("#groupFields").children().length; i++) {
        //    var Control = ''
        //    ControllDetails.map(function (proj) {
        //        var CurrentGroupField = $("#groupFields").children()[i]
        //        if (proj.FieldName == $(CurrentGroupField).html()) Control = proj
        //    });
        //    Control.GroupOrder = i;
        //}

        var ParaGroup = false;
        if ($("#chkparaGroup").is(":checked")) {
            ParaGroup = true
        }

        var isConsiderlabel = false;
        if ($("#chkConsiderGroup").is(":checked")) {
            isConsiderlabel = true
        }

        $.ajax({
            url: ServicePath + "insertGroup",
            type: "POST",
            data: JSON.stringify({ orentation: oreint, groupname: groupNamee, templateid: TemplateID, companyid: CompanyID, groupid: groupid, keepoption: groupKeepOption, controlspace: controllSpace, positionx: groupPositionX, positiony: groupPositionY, align: groupAlign, pagenumber: pageNumberr, grpOption: groupOption, IsParaGroup: ParaGroup, IsConsiderLabel: isConsiderlabel, GroupMoveRelative: RelativeGroupOption, GroupMovementValue: GroupMovementValue, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (GID) {

                loadGropDataAfterSave(oreint, groupNamee, id[1], groupKeepOption, controllSpace, groupPositionX, groupPositionY, groupAlign, pageNumberr, groupOption, controllIds, GID, false, ParaGroup, isConsiderlabel, RelativeGroupOption, GroupMovementValue);

            }
        });
    });

    AvailblaFieldFunction();
    GroupFieldsFunction();
    $("#rdOreintationHorizontal").unbind('click').bind('click', function () {
        //LoadHorizontalkeepoption("None");
        LoadVerticalkeepoption("None");
        $("#drpFieldMovement").prop('disabled', true);
        $("#chkConsiderGroup").prop('disabled', true);
        $("#chkparaGroup").prop('disabled', true);
    });
    $("#rdOreintationVertical").unbind('click').bind('click', function () {
        $("#drpFieldMovement").prop('disabled', false);
        $("#chkConsiderGroup").prop('disabled', false);
        $("#chkparaGroup").prop('disabled', false);
        LoadVerticalkeepoption($("#drpFieldMovement").val());

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

    //Changed by shahbaz for given alert if no item available or selected in in Available field
    $("#btnAddToGroup").unbind('click').bind('click', function () {
        var isparagroupchecked = $("#chkparaGroup").prop("checked")

        if ($("#availbaleFields").html() != '') {
            if (selectedAddID != "") {
                var GroupFieldHtml = "";
                $(".AvailbaleFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
                $(".GroupFields").css({ 'border': '1px solid transparent', 'background-color': 'transparent' });
                for (var i = 0; i < ControllDetails.length; i++) {
                    if (ControllDetails[i].ObjectID == selectedAddID) {
                        //
                        if (isparagroupchecked) {
                            if (ControllDetails[i].Type != "Paragraph") {
                                GroupFieldHtml = "";
                                $("#savemsg").html("Please select Paragraph control to create paragraph group.");
                                $("#SaveMessage").dialog("open");
                                var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
                                $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show();
                                break;
                            } else {
                                $("#avl_" + selectedAddID).remove();
                                GroupFieldHtml += "<div class='GroupFields' id='grp_" + ControllDetails[i].ObjectID + "' style='width:97%;margin:1px 0px 1px 1px;font-family:Segoe UI, Tahoma, Arial;font-size:12px;padding:3px 0px 3px 5px;border:1px solid #808080;background-color:#CBE6EF;cursor:pointer;border-radius:3px;'>" + ControllDetails[i].FieldName + "</div>";
                            }
                        }
                        else {
                            $("#avl_" + selectedAddID).remove();
                            GroupFieldHtml += "<div class='GroupFields' id='grp_" + ControllDetails[i].ObjectID + "' style='width:97%;margin:1px 0px 1px 1px;font-family:Segoe UI, Tahoma, Arial;font-size:12px;padding:3px 0px 3px 5px;border:1px solid #808080;background-color:#CBE6EF;cursor:pointer;border-radius:3px;'>" + ControllDetails[i].FieldName + "</div>";
                        }
                        selectedRemoveID = ControllDetails[i].ObjectID;
                        selectedAddID = "";
                    }
                }
                $("#groupFields").append(GroupFieldHtml);

                //Added By Shahbaz for Group ordering
                //for (var i = 0; i < $("#groupFields").children().length; i++) {
                //    var Control = ''
                //    ControllDetails.map(function (proj) {
                //        var CurrentGroupField = $("#groupFields").children()[i]
                //        if (proj.FieldName == $(CurrentGroupField).html()) Control = proj
                //    });
                //    Control.GroupOrder = i;
                //}
                GroupFieldsFunction();
            }
            else {
                $("#savemsg").html("Please select atleast one item from available Fields");
                $("#SaveMessage").dialog("open");
                var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
                $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
            }
        }
        else {
            $("#savemsg").html("No available Fields to add");
            $("#SaveMessage").dialog("open");
            var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
            $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
        }

    });

    //Changed by shahbaz for given alert if no item available or selected in in grouped field
    $("#btnRemoveFromGroup").unbind('click').bind('click', function () {
        if ($("#groupFields").html() != '') {
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
            }
            else {
                $("#savemsg").html("Please select atleast one item from grouped Fields");
                $("#SaveMessage").dialog("open");
                var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
                $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
            }
        }
        else {
            $("#savemsg").html("No grouped Fields to remove");
            $("#SaveMessage").dialog("open");
            var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
            $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
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

    //changed by shahbaz for given alert if no item to process in Grouped Field
    $("#btnMoveDown").unbind('click').bind('click', function () {

        if (selectedRemoveID != "") {
            if ($("#grp_" + selectedRemoveID).next().get(0).nodeName == 'DIV') {
                var id = $("#grp_" + selectedRemoveID).next().get(0).id;
                swapElements($("#grp_" + selectedRemoveID)[0], $("#" + id)[0]);
            }
        } else {
            $("#savemsg").html("Please select atleast one item to process");
            $("#SaveMessage").dialog("open");
            var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
            $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
        }
    });

    //Changed by shahbaz for given alert if no item to process in Grouped Field
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
            var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
            $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
        }
    });
    //$("div[aria-describedby=ManageGroupAddGroup] .ui-widget-header img").remove();
    //$("div[aria-describedby=ManageGroupAddGroup] .ui-widget-header").prepend("<img id='ImgGrpTitle' src='StyleSheets/Images/stock_group.png' width='15' height='15' style='vertical-align:middle;float:left;margin-left:5px;margin-right:10px;' />");
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

/*Delete group event*/
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
                //UpadteTemplteDetails(false, false);//Commented By shahbaz
                if (GoBack == "Existing") {
                    $("#ManageGroupExistingGroup").dialog('close');
                    if (VerticalGroupingData.length > 0 || HorizontalGroupingData.length > 0) {
                        loadManageExistingGroup();
                        $(".loading_new").hide();
                        $("#savemsg").html("Group deleted successfully");
                        $("#SaveMessage").dialog("open");
                        var z_index = parseInt($("div[aria-describedby=ManageGroupExistingGroup]").css('z-index'));
                        $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
                    } else {
                        $(".loading_new").hide();
                        $("#savemsg").html("Group deleted successfully");
                        $("#SaveMessage").dialog("open");
                        // var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
                        //$(".MangaeGrouploadingNewMask").css('z-index', '100').show()
                    }
                }
                else {
                    //$("#QuickAdjustDialog").dialog('close');
                    loadQuickAdjust();
                    $(".loading_new").hide();
                    $("#savemsg").html("Group deleted successfully");
                    $("#SaveMessage").dialog("open");
                    var z_index = parseInt($("div[aria-describedby=QuickAdjustDialog]").css('z-index'));
                    $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
                    //$(".MangaeGrouploadingNewMask").css({ 'z-index': '100' }).show();
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
                //UpadteTemplteDetails(false, false);
                if (GoBack == "Existing") {
                    $("#ManageGroupExistingGroup").dialog('close');
                    if (VerticalGroupingData.length > 0 || HorizontalGroupingData.length > 0) {
                        loadManageExistingGroup();
                        $(".loading_new").hide();
                        $("#savemsg").html("Group deleted successfully");
                        $("#SaveMessage").dialog("open");
                        var z_index = parseInt($("div[aria-describedby=ManageGroupExistingGroup]").css('z-index'));
                        $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
                    } else {
                        $(".loading_new").hide();
                        $("#savemsg").html("Group deleted successfully");
                        $("#SaveMessage").dialog("open");
                        // var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
                        // $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
                        // $(".MangaeGrouploadingNewMask").css({ 'z-index': '102' }).show();
                    }
                }
                else {
                    $("#QuickAdjustDialog").dialog('close');
                    loadQuickAdjust();
                    $(".loading_new").hide();
                    $("#savemsg").html("Group deleted successfully");
                    $("#SaveMessage").dialog("open");
                    var z_index = parseInt($("div[aria-describedby=QuickAdjustDialog]").css('z-index'));
                    $(".MangaeGrouploadingNewMask").css('z-index', z_index + 1).show()
                    //$(".MangaeGrouploadingNewMask").css({ 'z-index': '102' }).show();
                }
            }
        });
    }
}

/*Laod group dataa after group Save*/
function loadGropDataAfterSave(oreint, groupName, groupid, groupKeepOption, controllSpace, groupPositionX, groupPositionY, groupAlign, pageNumberr, groupOption, controllIds, GID, saveAdndStay, IsParaGroup, IsConsiderLabel, GroupMoveRelative, GroupMovementValue) {


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
            "GroupOption": groupOption,
            "IsParaGroup": IsParaGroup,
            "IsConsiderLabel": IsConsiderLabel,
            "GroupMoveRelative": GroupMoveRelative,
            "GroupMovementValue": GroupMovementValue
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
                    VerticalGroupingData[i].IsParaGroup = IsParaGroup;
                    VerticalGroupingData[i].IsConsiderLabel = IsConsiderLabel;
                    VerticalGroupingData[i].GroupMoveRelative = GroupMoveRelative;
                    VerticalGroupingData[i].GroupMovementValue = GroupMovementValue;
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
                    HorizontalGroupingData[i].GroupMoveRelative = GroupMoveRelative;
                    HorizontalGroupingData[i].GroupMovementValue = GroupMovementValue;
                    break;
                }
            }
        }
    }
    if (saveAdndStay) {
        $(".SaveandStayGroup").attr('id', 'btnSaveandStay_' + GID.d);
        $(".SaveandCloseGroup").attr('id', 'btnSaveandClose_' + GID.d);
    }
    changeThePageFromDropDown($("#drpPageSelect").val());
}

/*Swap Elements*/
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

/*********************************
Quick Adjust Popup(Craeted By: Infomaze)
*********************************/
/*Laod Quick adjust popup*/
function loadQuickAdjust() {
    $("#QuickAdjustDialog").dialog("open");
    $("#QuickAdjustDialogTable").empty();


    //for colorpicker in Quick adjust added By shahbaz
    $('.cp_128').colorpicker({
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
            chnageFontColorCMYKtoRGB_QuickAdjust();
        },
    });
    $("#fontColor").find(".ui-colorpicker,.ui-colorpicker table").css({ 'padding-left': '0px', 'padding-right': '0px', 'border-width': '0px' });
    $("#fontColor").find(".ui-colorpicker-number").css({ 'width': '50px', 'height': '18px', 'margin-left': '8px', 'margin-bottom': '3px' });
    $("#fontColor").find(".ui-colorpicker-cmyk-container label").css({ 'font-weight': 'bold', 'padding-left': '10px' });
    $("#fontColor").find(".ui-colorpicker-cmyk-c input").attr('id', 'txtC2');
    $("#fontColor").find(".ui-colorpicker-cmyk-m input").attr('id', 'txtM2');
    $("#fontColor").find(".ui-colorpicker-cmyk-y input").attr('id', 'txtY2');
    $("#fontColor").find(".ui-colorpicker-cmyk-k input").attr('id', 'txtK2');
    //$(".colorcode table").css({ 'margin-bottom': '0px', 'padding-bottom': '0px', 'padding-top': '0px' });
    $("#fontColor").find(".colorcode div").css({ 'margin-bottom': '0px', 'padding-bottom': '0px', 'padding-top': '0px' });
    $("#txtC2").attr('type', 'text');
    $("#txtM2").attr('type', 'text');
    $("#txtY2").attr('type', 'text');
    $("#txtK2").attr('type', 'text');
    $("#txtT2").attr('type', 'text');
    $("#fontColor input[type=text]").css('text-align', 'left');
    $("#fontColor input[type=text]").attr('onkeypress', 'return validateQty(event)');
    $("#fontColor input[type=text]").attr('oninput', 'vaild(event)');
    $("#color").css({ 'margin-bottom': '0px', 'padding-bottom': '0px', 'padding-top': '0px' });
    $("#fontColor").find("#txtC2,#txtM2,#txtY2,#txtK2,#txtT2").css({ 'width': '40px', 'height': '20px', 'font-family': 'verdana', 'font-size': '11px', 'margin': '5px 1px 5px 5px' });
    $("#fontColor").find(".ui-colorpicker-cmyk label").css({ 'font-family': 'verdana', 'font-size': '12px', 'padding-left': '0px' });
    $("#fontColor").find(".ui-colorpicker-unit").css({ 'font-family': 'verdana', 'font-size': '11px' });
    $("#fontColor").find(".ui-colorpicker-cmyk-t").css('display', 'none');

    //$("#txtC2,#txtM2,#txtY2,#txtK2,#txtT2").unbind("change").bind("change", function () {
    //    chnageFontColorCMYKtoRGB_QuickAdjust
    //});

    $("#txtC2,#txtM2,#txtY2,#txtK2,#txtT2").unbind("keyup").bind("keyup", function () {
        $("#txtC2,#txtM2,#txtY2,#txtK2,#txtT2").trigger('change')
        chnageFontColorCMYKtoRGB_QuickAdjust();
    });

    loadDynamicQuickAdjust();
}

/*Laod Quick adjust popup*/
function loadDynamicQuickAdjust() {

    $("#loadingquickadjust").show();
    var QuickAdjustHtml = "";

    //QuickAdjustHtml += "<tbody><tr style='background-color: #D8D8D8;table-layout: fixed;' class='Heading'><td style='width:120px'>Type</td><td style='width:130px'>Field Name</td><td style='width:90px'>Page</td><td style='width:90px'>X-Position</td><td style='width:90px'>Y-Position</td><td style='width:90px'>Width</td>";
    //QuickAdjustHtml += "<td style='width:130px'>Font Name</td><td style='width:50px'>Color</td><td style='width:130px'>Orientation</td><td style='width:180px'>Field Movement Options</td><td style='text-align:right;width:60px;' class='actions'>Action</td></tr></tbody>";

    QuickAdjustHtml += "<thead style='padding-bottom:5px'><tr style='background-color: #D8D8D8;table-layout: fixed;' class='Heading'><td style='padding-left:5px'>Type</td><td>Field Name</td><td >Page</td><td>X-Position</td><td>Y-Position</td><td >Width</td>";
    QuickAdjustHtml += "<td>Font Name</td><td>Color</td><td>Orientation</td><td class='FldMovementOptions'>Field Movement Options</td><td style='text-align:center;' class='actions'>Action</td></tr></thead>";


    QuickAdjustHtml += "<tbody id='tbdy_QuickAdjustControl'>";

    for (var i = 1; i <= TemplateDetails.Totalpage; i++) {
        QuickAdjustHtml = bindQuickAdjust(QuickAdjustHtml, i);
    }

    QuickAdjustHtml += "</tbody></table>";

    $("#QuickAdjustDialogTable").html(QuickAdjustHtml);

    //for colorpicker in Quick adjust added By shahbaz
    var PreviouslySelected = "";
    $(".color").unbind('click').bind('click', function () {
        var div = $(this.closest('div'));
        var Position = $("#" + div[0].id).offset();
        $("#fontColor").css({ 'left': Position.left - 120, 'top': Position.top + 20 });
        selectedObjectID = div[0].id.split('_')[1];
        if ($("#fontColor").css('display') == "none" || PreviouslySelected != selectedObjectID) {
            $("#fontColor").show();
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
            if (Control.IsTempColor) {
                $("#txtC2").val(parseFloat(Control.TempC * 100).toFixed(2));
                $("#txtM2").val(parseFloat(Control.TempM * 100).toFixed(2));
                $("#txtY2").val(parseFloat(Control.TempY * 100).toFixed(2));
                $("#txtK2").val(parseFloat(Control.TempK * 100).toFixed(2));
            } else {
                $("#txtC2").val(parseFloat(Control.C * 100).toFixed(2));
                $("#txtM2").val(parseFloat(Control.M * 100).toFixed(2));
                $("#txtY2").val(parseFloat(Control.Y * 100).toFixed(2));
                $("#txtK2").val(parseFloat(Control.K * 100).toFixed(2));
            }

            $("#txtC2").trigger('change');
            $("#txtM2").trigger('change');
            $("#txtY2").trigger('change');
            $("#txtK2").trigger('change');

            PreviouslySelected = selectedObjectID;
        }
        else {
            $("#fontColor").hide();
        }
    });


    $("#colorclose").click(function () {
        $("#fontColor").hide();
    });

    deleteAndEditGroupFuction();
    loadDesignogQuickAdjust();
    loadFontDropDownOfQuickAdjust();
    designPoups();

    //Added By shahbaz to make table body scrollable 
    var table = $("#QuickAdjustDialogTable");
    var bodyCells = table.find('tbody tr:first').children();
    var colWidth = bodyCells.map(function () {
        return $(this).width();
    }).get();
    // Set the width of thead columns
    table.find('thead tr').children().each(function (i, v) {
        $(v).width(colWidth[i]);
    });

    if ($("#tbdy_QuickAdjustControl tr").length == 0) {
        $("#QuickAdjustDialogTable thead td").css('width', "150px")
        $(".FldMovementOptions").css('width', "196px")
    }
    //else
    //    $("#QuickAdjustDialogTable tbody td,thead td").css('width', "3.3%")

    $("#loadingquickadjust").hide();
}

/*Desging Of Quick Adjust*/
function loadDesignogQuickAdjust() {
    $("#QuickAdjustDialog").css('overflow', 'hidden');
    //$(".quickadjust_Overflowdiv").css('height', $("#QuickAdjustDialogTable").css('height'));
    //$("#QuickAdjustDialog select").css({ 'background': '#FFFFFF url(' + SiteImages + 'arrow-down.png) no-repeat 100% center', '-webkit-appearance': 'none', '-moz-appearance': ' none' });
    $(".ui-dialog-buttonset").css({ 'width': 'auto' });
    $(".Heading td").css({ 'margin': '0px', 'font-size': '11px', 'font-family': 'Verdana' });//'padding': '5px 0px 5px 5px',
    $(".color").css({ 'margin-left': '8px' });
    $(".QuickTextBox").css({ 'width': '65px', 'font-size': '11px', 'margin': '0px auto 0px auto', 'height': '20px', 'border': '1px solid #8D8091', 'border-radius': '1px', 'padding-left': '2px' });
    $(".QuickSelect").css({ 'width': '65px', 'font-size': '11px', 'margin': '0px auto 0px auto', 'height': '24px', 'border': '1px solid #8D8091', 'border-radius': '1px', 'padding-left': '2px' });
    $(".drpqfont").css({ 'width': '100px', 'margin-left': 'auto' });
    $(".drpfieldMovement").css({ 'width': '120px', 'margin-left': '5px' });
    $(".drpOrientation").css({ 'width': '100px', 'margin-left': '5px' });
    $(".txtqfieldName").css({ 'width': '100px' });
    //$(".contentTd").css({ 'padding': '1px 5px 1px 5px' });


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
    //$(".contentTr td").css({ 'padding-right': '10px' });
    //$("td.actions").css({ 'padding-right': '5px' });

    $("div[aria-describedby=QuickAdjustDialog] .ui-dialog-buttonpane").css({ 'margin-right': '20px', 'margin-top': '0px', 'margin-left': '20px', 'border': '2px solid white', 'border-top': '0px', 'padding-top': '10px', 'padding-bottom': '5px', 'background-color': '#F6F6F6', 'margin-bottom': ' 15px' });
    $("div[aria-describedby=QuickAdjustDialog] .ui-dialog-buttonpane .ui-button").css('margin', '5px 10px 5px 10px');
    $("div[aria-describedby=QuickAdjustDialog] .ui-dialog-buttonpane .ui-button span").css({ 'font-size': '11px' });
}

/*Laod Quick adjust Dropdowns*/
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
                if (ControllDetails[i].FontFamily == FontList[z].DisplayFontName) {
                    $("#fontdrp_" + ControllDetails[i].ObjectID).append("<option value='" + FontList[z].FontFilePath + "~" + FontList[z].FontID + "~" + FontList[z].ActualFontName + "~" + FontList[z].DisplayFontName + "' id='drpQAFontID" + z + "" + FontList[z].FontID + "' selected >" + FontList[z].DisplayFontName + "</option>");
                }
                else {
                    $("#fontdrp_" + ControllDetails[i].ObjectID).append("<option value='" + FontList[z].FontFilePath + "~" + FontList[z].FontID + "~" + FontList[z].ActualFontName + "~" + FontList[z].DisplayFontName + "' id='drpQAFontID" + z + "" + FontList[z].FontID + "' >" + FontList[z].DisplayFontName + "</option>");
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

/*Bind Quick adjust popup*/
function bindQuickAdjust(QuickAdjustHtml, pageNumber) {

    ControllDetails = sortJSON(ControllDetails, "OrderNumber", "ASC");
    var CountForControl = 0;
    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].GroupID == 0 && ControllDetails[i].Visibility == true && ControllDetails[i].PageNumber == pageNumber) {
            CountForControl++;
            QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;background-color: #F6F6F6'>";
            QuickAdjustHtml += "<td class='contentTd'><div style='font-family:verdana;font-size:11px;padding-left:5px'>" + ControllDetails[i].Type + "<div></td>";
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
                //QuickAdjustHtml += "<td><div class='color' id='color_" + ControllDetails[i].ObjectID + "' style='border:1px solid black;width:20px;padding-left:5px;font-size:11px;font-weight:bold;cursor:pointer'><div style='padding-left:2px;'>A</div><div id='colorpicker_" + ControllDetails[i].ObjectID + "' style='width:15px;height:5px;margin-bottom:3px;background-color:rgba(" + ControllDetails[i].R + ", " + ControllDetails[i].G + ", " + ControllDetails[i].B + ", " + ControllDetails[i].A + ");'></div></div></td>";
                QuickAdjustHtml += "<td><div class='color txtColor' id='color_" + ControllDetails[i].ObjectID + "' style='border: 1px solid black; width: 45px; padding-left: 5px; font-size: 11px; font-weight: bold; margin-left: 8px;height: 20px;'><div style='padding-left:5px;height: 60%;'>A</div><div id='colorpicker_" + ControllDetails[i].ObjectID + "' style='width: 15px;height: 5px;margin-left: 3px;background-color:rgba(" + ControllDetails[i].R + ", " + ControllDetails[i].G + ", " + ControllDetails[i].B + ", " + ControllDetails[i].A + ");'></div></div></td>"
            }
            else {
                //QuickAdjustHtml += "<td class='contentTd'><div style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
                QuickAdjustHtml += "<td class='contentTd'><div class='txtColorDisabled' style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:45px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:5px;Color:#b2b2b2;height: 60%;'>A</div><div style='width: 15px;height: 5px;margin-left: 3px;background-color:rgba(0, 0, 0, 255);opacity:.6'></div></div></td>";
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
                    if (CountForControl > 0)
                        QuickAdjustHtml += "<tr><td style='padding-top:10px;'>";
                    QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;'>";
                    QuickAdjustHtml += "<td class='contentTd excesspadding'><div style='font-family:verdana;font-size:11px;padding-left:5px' >Vertical Group<div></td>";
                    QuickAdjustHtml += "<td class='contentTd excesspadding'><input disabled type='text' calss='QuickTextBox txtGroupName GroupDisable' style='width:100px;font-family:verdana;font-size:11px;height:20px;' value='" + VerticalGroupingData[i].GroupName + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'>";
                    QuickAdjustHtml += "<select class='QuickSelect txtGroupPage GroupDisable mediumSelect' style='font-family:verdana;font-size:11px;width:50px;height:24px;'>";
                    QuickAdjustHtml += "<option selected>" + VerticalGroupingData[i].PageNumber + "</option>";
                    QuickAdjustHtml += "</select></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox txtGropuPositionX GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:25px;' type='text' value='" + parseFloat(VerticalGroupingData[i].PositionX).toFixed(4) + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox txtGropuPositionY GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:25px;' type='text' value='" + parseFloat(VerticalGroupingData[i].PositionY).toFixed(4) + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:25px;' type='text' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><select class='GroupDisable' style='width:100px;height:24px;font-family:verdana;font-size:11px;border: 1px solid #8D8091;'></select></td>";
                    //QuickAdjustHtml += "<td class='contentTd'><div style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
                    QuickAdjustHtml += "<td class='contentTd'><div class='txtColorDisabled' style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:45px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:5px;Color:#b2b2b2;height: 60%;'>A</div><div style='width: 15px;height: 5px;margin-left: 3px;background-color:rgba(0, 0, 0, 255);opacity:.6'></div></div></td>";
                    QuickAdjustHtml += "<td><select class='GroupDisable' style='margin-left:5px;font-family:verdana;font-size:11px;width:100px;height:24px;border: 1px solid #8D8091;'>";
                    QuickAdjustHtml += "<option selected>Vertical</option></select></td>";
                    QuickAdjustHtml += "<td><select class='GroupDisable' style='margin-left:5px;font-family:verdana;font-size:11px;width:120px;height:24px;border: 1px solid #8D8091;'>";
                    QuickAdjustHtml += "<option selected>" + VerticalGroupingData[i].GrpKeepOption + "</option></select></td>";
                    QuickAdjustHtml += "<td class='contentTd excess' style='text-align:center;'><img class='image EditGroup Vertical' Title='Edit Group' id='btnEditGrp_" + VerticalGroupingData[i].GID + "' src='StyleSheets/Images/edit-icon.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:1px solid transparent;border-radius: 10px;padding:2px;' /><img id='btnDeleteGrp_" + VerticalGroupingData[i].GID + "' class='image DeleteGroup Vertical' Title='Delete Group' src='StyleSheets/Images/cross.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:2px solid transparent;border-radius: 10px;padding:2px;' /></td></tr>";
                    for (var k = 0; k < ControllDetails.length; k++) {

                        if (ControllDetails[k].GroupID == VerticalGroupingData[i].GID && ControllDetails[k].Visibility == true) { // changed by shahbaz
                            QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;'>";
                            QuickAdjustHtml += "<td class='contentTd'><div style='font-family:verdana;font-size:11px;padding-left:20px;'>" + ControllDetails[k].Type + "<div></td>";
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
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqwidth GroupDisable' disabled onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);'  id='width_" + ControllDetails[k].ObjectID + "' value='" + parseFloat(ControllDetails[k].Width).toFixed(4) + "' /></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect drpqfont Controlls' id='fontdrp_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "</select></td>";
                            // QuickAdjustHtml += "<td><div class='color' id='color_" + ControllDetails[k].ObjectID + "' style='border:1px solid black;width:20px;padding-left:5px;font-size:11px;font-weight:bold;cursor:pointer'><div style='padding-left:2px;'>A</div><div id='colorpicker_" + ControllDetails[k].ObjectID + "' style='width:15px;height:5px;margin-bottom:3px;background-color:rgba(" + ControllDetails[k].R + ", " + ControllDetails[k].G + ", " + ControllDetails[k].B + ", " + ControllDetails[k].A + ");'></div></div></td>";
                            QuickAdjustHtml += "<td><div class='color txtColor' id='color_" + ControllDetails[k].ObjectID + "' style='border: 1px solid black; width: 45px; padding-left: 5px; font-size: 11px; font-weight: bold; margin-left: 8px;height: 20px;'><div style='padding-left:5px;height: 60%;'>A</div><div id='colorpicker_" + ControllDetails[k].ObjectID + "' style='width: 15px;height: 5px;margin-left: 3px;background-color:rgba(" + ControllDetails[k].R + ", " + ControllDetails[k].G + ", " + ControllDetails[k].B + ", " + ControllDetails[k].A + ");'></div></div></td>"
                            QuickAdjustHtml += "<td><select class='QuickSelect drpOrientation GroupDisable' id='ornt_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "<option value='Vertical'>Vertical</option>";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect drpfieldMovement GroupDisable' id='fldmnt_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "<option value='down'>" + ControllDetails[k].KeepOption + "</option>";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td style='text-align:center;' class='actions'></td></tr>";
                        }
                        CountForControl++;
                    }
                    QuickAdjustHtml += "</td><tr>";
                }
            }
        }
        if (HorizontalGroupingData.length > 0) {
            for (var i = 0; i < HorizontalGroupingData.length; i++) {
                if (HorizontalGroupingData[i].PageNumber == pageNumber) {
                    if (CountForControl > 0)
                        QuickAdjustHtml += "<tr><td style='padding-top:10px;'>";
                    //QuickAdjustHtml += "<tr><td style='padding-top:10px;'>";
                    QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;'>";
                    QuickAdjustHtml += "<td class='contentTd excesspadding' ><div style='font-family:verdana;font-size:11px;padding-left:5px' >Horizontal Group<div></td>";
                    QuickAdjustHtml += "<td class='contentTd excesspadding'><input disabled type='text' calss='QuickTextBox txtGroupName GroupDisable' style='width:100px;font-family:verdana;font-size:11px;height:20px;' value='" + HorizontalGroupingData[i].GroupName + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'>";
                    QuickAdjustHtml += "<select class='QuickSelect txtGroupPage GroupDisable mediumSelect' style='font-family:verdana;font-size:11px;width:50px;height:24px;'>";
                    QuickAdjustHtml += "<option selected>" + HorizontalGroupingData[i].PageNumber + "</option>";
                    QuickAdjustHtml += "</select></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox txtGropuPositionX GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:20px;' type='text' value='" + parseFloat(HorizontalGroupingData[i].PositionX).toFixed(4) + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox txtGropuPositionY GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:20px;' type='text' value='" + parseFloat(HorizontalGroupingData[i].PositionY).toFixed(4) + "' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><input disabled calss='QuickTextBox GroupDisable' style='font-family:verdana;font-size:11px;width:65px;height:20px;' type='text' /></td>";
                    QuickAdjustHtml += "<td class='contentTd'><select class='GroupDisable' style='width:100px;height:24px;font-family:verdana;font-size:11px;border: 1px solid #8D8091;'></select></td>";
                    //QuickAdjustHtml += "<td class='contentTd'><div  style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:20px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:2px;Color:#b2b2b2;'>A</div></div></td>";
                    QuickAdjustHtml += "<td class='contentTd'><div class='txtColorDisabled' style='background-color:#EBEBE4;margin-left:5px;border:1px solid #b2b2b2;width:45px;padding-left:5px;font-size:11px;font-weight:bold;height:20px;'><div style='padding-left:5px;Color:#b2b2b2;height: 60%;'>A</div><div style='width: 15px;height: 5px;margin-left: 3px;background-color:rgba(0, 0, 0, 255);opacity:.6'></div></div></td>";
                    QuickAdjustHtml += "<td><select class='GroupDisable' style='margin-left:5px;font-family:verdana;font-size:11px;width:100px;height:24px;border: 1px solid #8D8091;'>";
                    QuickAdjustHtml += "<option selected>Horizontal</option></select></td>";
                    QuickAdjustHtml += "<td><select class='GroupDisable' style='margin-left:5px;font-family:verdana;font-size:11px;width:120px;height:24px;border: 1px solid #8D8091;'>";
                    QuickAdjustHtml += "<option selected>" + HorizontalGroupingData[i].GrpKeepOption + "</option></select></td>";
                    QuickAdjustHtml += "<td class='contentTd excess actions' style='text-align:center;'><img class='image EditGroup Horizontal' Title='Edit Group' id='btnEditGrp_" + HorizontalGroupingData[i].GID + "' src='StyleSheets/Images/edit-icon.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:1px solid transparent;border-radius: 10px;padding:2px;' /><img id='btnDeleteGrp_" + HorizontalGroupingData[i].GID + "' Title='Delete Group' class='image DeleteGroup Horizontal' src='StyleSheets/Images/cross.png' height='13' width='13' style='vertical-align:middle;margin:0px 0px 0px 0px;cursor:pointer;border:2px solid transparent;border-radius: 10px;padding:2px;' /></td></tr>";
                    for (var k = 0; k < ControllDetails.length; k++) {
                        if (ControllDetails[k].GroupID == HorizontalGroupingData[i].GID && ControllDetails[k].Visibility == true) { // changed by shahbaz
                            QuickAdjustHtml += "<tr class='contentTr' style='border:1px solid transparent;'>";
                            QuickAdjustHtml += "<td class='contentTd'><div style='font-family:verdana;font-size:11px;padding-left:20px;'>" + ControllDetails[k].Type + "<div></td>";
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqfieldName' id='fldname_" + ControllDetails[k].ObjectID + "' value='" + ControllDetails[k].FieldName + "' /></td>";
                            QuickAdjustHtml += "<td class='contentTd'>";
                            QuickAdjustHtml += "<select class='QuickSelect drpqpageNumber mediumSelect GroupDisable' id='pgnum_" + ControllDetails[k].ObjectID + "'>";
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
                            QuickAdjustHtml += "<td class='contentTd'><input type='text' class='QuickTextBox txtqwidth GroupDisable' onkeyup='return validateQty(event);' oninput='vaild(event)'onkeyup='valid(event);'  id='width_" + ControllDetails[k].ObjectID + "' value='" + parseFloat(ControllDetails[k].Width).toFixed(4) + "' /></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect drpqfont Controlls' id='fontdrp_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "</select></td>";
                            // QuickAdjustHtml += "<td><div class='color' id='color_" + ControllDetails[k].ObjectID + "' style='border:1px solid black;width:20px;padding-left:5px;font-size:11px;font-weight:bold;cursor:pointer'><div style='padding-left:2px;'>A</div><div id='colorpicker_" + ControllDetails[k].ObjectID + "' style='width:15px;height:5px;margin-bottom:3px;background-color:rgba(" + ControllDetails[k].R + ", " + ControllDetails[k].G + ", " + ControllDetails[k].B + ", " + ControllDetails[k].A + ");'></div></div></td>";
                            QuickAdjustHtml += "<td><div class='color txtColor' id='color_" + ControllDetails[k].ObjectID + "' style='border: 1px solid black; width: 45px; padding-left: 5px; font-size: 11px; font-weight: bold; margin-left: 8px;height: 20px;'><div style='padding-left:5px;height: 60%;'>A</div><div id='colorpicker_" + ControllDetails[k].ObjectID + "' style='width: 15px;height: 5px;margin-left: 3px;background-color:rgba(" + ControllDetails[k].R + ", " + ControllDetails[k].G + ", " + ControllDetails[k].B + ", " + ControllDetails[k].A + ");'></div></div></td>"
                            QuickAdjustHtml += "<td><select class='QuickSelect GroupDisable drpOrientation' id='ornt_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "<option value='Horizontal'>Horizontal</option>";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td><select class='QuickSelect drpfieldMovement GroupDisable' id='fldmnt_" + ControllDetails[k].ObjectID + "' >";
                            QuickAdjustHtml += "<option value='down'>" + ControllDetails[k].KeepOption + "</option>";
                            QuickAdjustHtml += "</select></td>";
                            QuickAdjustHtml += "<td style='text-align:center;' class='actions'></td></tr>";
                        }
                    }
                    QuickAdjustHtml += "</td></tr>";
                }
            }
        }
    }

    return QuickAdjustHtml;
}

/*Quick adjust popup events on save*/
function changeFiledNameQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

    Control.FieldName = Text;
}

/*Quick adjust popup events on save*/
function changePositionXQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.PositionX = parseFloat(Text);
}

/*Quick adjust popup events on save*/
function changePositionYQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.PositionY = parseFloat(Text);

}

/*Quick adjust popup events on save*/
function changePageQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.PageNumber = parseInt(Text);

}

/*Quick adjust popup events on save*/
function changeGroupOrientationQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.GroupOrientation = Text;

}

/*Quick adjust popup events on save*/
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

/*Quick adjust popup events on save*/
function changeGroupKeepOptionQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.KeepOption = Text;

}

/*Quick adjust popup events on save*/
function changeWidthQuickAdjust(id, Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.Width = parseFloat(Text);

}

/*Quick adjust popup events on save*/
function deleteContolQuickAdjust(id) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });
    Control.Visibility = false;

    loadDynamicQuickAdjust();
    changeThePageFromDropDown($("#drpPageSelect").val());

}

/*Save Quick Adjust Values*/
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

/**********************************
Common Methods(Craeted By: Infomaze)
***********************************/

/*Adding Text control to canvas dynamically*/
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
    var helptext = controllDetails.HelpText.toString().replace(/'/g, '&#39');
    var TextHtml = "<div class='Text controll'";
    TextHtml += "id='" + controllDetails.ObjectID + "'";
    TextHtml += "name='" + controllDetails.FieldName + "'";
    TextHtml += "title='" + helptext + "'";
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
            TextHtml += parseFloat(controllDetails.ManualTracking / ptConvertionConstant).toFixed(4) + "px;";
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
        try {
            FontList.map(function (proj) { if (proj.DisplayFontName == controllDetails.FontFamily) Font = proj });
        }
        catch (e) {
            console.log('Error while dispatching the event.');
        }

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

        if (controllDetails.LabelFontSize == 0)//Added if Label Font Size is 0 (5/11/2015)
            controllDetails.LabelFontSize = controllDetails.FontSize;

        TextHtml += "<span style='font-size:" + controllDetails.LabelFontSize / ptConvertionConstant + "px;text-align:left;display:inline-block;vertical-align:baseline;bottom:0px;line-height:.7;";

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
                    controllDetails.LabelFontExtension = Font.FontFilePath;
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
            TextHtml += "font-family:arial;font-weight:normal;font-style:normal;letter-spacing:0;";
        }
        TextHtml += "' class='label'>" + defaContent + "</span>" + defaultContent + "</div>";

    }
    else if (controllDetails.Labels == "None" || controllDetails.Labels == "") {
        TextHtml += "<div class='labelText' style='bottom:0px;position:absolute;padding:0px;margin:0px;vertical-align:baseline;line-height:.7;";
        TextHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
        if (controllDetails.ManualTrackDimension == "pt") {
            TextHtml += parseFloat(controllDetails.ManualTracking / ptConvertionConstant).toFixed(4) + "px;";
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
    fixPostionOfControll(controllDetails.ObjectID, controllDetails.PositionX, controllDetails.PositionY, controllDetails.TextAlign);

    //  applyonexceedwidth(controllDetails.ObjectID);
    setTimeout(function () { applyonexceedwidth(controllDetails.ObjectID); }, 1000)
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

/*Adding Paragraph control to canvas dynamically*/
function AddParaDynamically(controllDetails, AddNew) {
    debugger;
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

    defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>").replace(/&nbsp;/g, " ");
    var helptext = controllDetails.HelpText.toString().replace(/'/g, '&#39');
    var ParaHtml = "<div class='Para controll'";
    ParaHtml += "id='" + controllDetails.ObjectID + "'";
    ParaHtml += "name='" + controllDetails.FieldName + "'";
    ParaHtml += "title='" + helptext + "'";
    ParaHtml += "style='position:absolute;background-color:transparent;cursor:pointer;";
    ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    ParaHtml += "width:" + parseFloat(controllDetails.Width) * mmConvertionConstant + "px;";
    ParaHtml += "letter-spacing:" + controllDetails.ManualTrackSign;
    if (controllDetails.ManualTrackDimension == "pt") {
        ParaHtml += parseFloat(controllDetails.ManualTracking / ptConvertionConstant).toFixed(4) + "px;";
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
    //ParaHtml += "border:1px dashed transparent;"
    ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
    //ParaHtml += "font-family:" + controllDetails.FontFamily + ";";


    var ParaTextAlign = controllDetails.TextAlign;
    var whitespace = "pre-wrap";
    if (ParaTextAlign == "Justify") {
        ParaTextAlign = "Justify";
        whitespace = "initial";
    }

    if (controllDetails.DefaultContent == "") {
        ParaHtml += "'><pre style='margin:0px;word-wrap:break-word;white-space:" + whitespace + ";vertical-align:top;text-align:" + ParaTextAlign + ";line-height:100%;padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;border:1px dashed transparent;";
        ParaHtml += "font-family:" + uniquefontname + ";";
        ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        ParaHtml += "font-weight:" + controllDetails.FontWeight + ";";
        ParaHtml += "font-style:" + controllDetails.FontStyle + ";>";
        ParaHtml += "' class='paraText'>" + defaultContent + "</pre></div>";
    }
    else {
        ParaHtml += "'><pre style='margin:0px;word-wrap:break-word;white-space:" + whitespace + ";vertical-align:top;text-align:" + ParaTextAlign + ";line-height:100%;padding-left:" + parseFloat(controllDetails.Indent) * mmConvertionConstant + "px;border:1px dashed transparent;";
        ParaHtml += "font-family:" + uniquefontname + ";";
        ParaHtml += "z-index:" + controllDetails.ZIndexValue + ";";
        ParaHtml += "font-weight:" + controllDetails.FontWeight + ";";
        ParaHtml += "font-style:" + controllDetails.FontStyle + ";>";
        ParaHtml += "' class='paraText'>" + defaultContent + "</pre></div>";
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
        // var lineleight = (parseFloat(presentlineheight) * ptConvertionConstant) + controllDetails.ParaLineSpace;
        var lineleight = (parseFloat(controllDetails.ParaLineSpace * ptConvertionConstant) * mmConvertionConstant);
        $("#" + controllDetails.ObjectID + " pre").css('line-height', lineleight + "pt");

        lnHgt = (parseFloat(controllDetails.ParaLineSpace * ptConvertionConstant) * mmConvertionConstant - controllDetails.FontSize * ptConvertionConstant) / 2;
        $("#" + controllDetails.ObjectID + " pre").css('margin-top', -(lnHgt) + "pt");
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

    //Added By Shahbaz if Page Loaded with some paragraph Control then assing top position if ExceedHeight Mention
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

/*Adding Image control to canvas dynamically*/
function AddImageDynamically(controllDetails, AddNew) {
    //console.log(controllDetails.FieldName.replace(/^\D+/g, ''));       
    var imagepath = "";
    $("#sortable").append("<li class='ui-state-default reiewFields' title='Drag object for rearrange' id='R_" + controllDetails.ObjectID + "'>" + controllDetails.FieldName + "</li>");
    loadFuctionForReview();
    var ImageHtml = "<div class='Image controll'";
    ImageHtml += "id='" + controllDetails.ObjectID + "'";
    ImageHtml += "name='" + controllDetails.FieldName + "'";
    if (controllDetails.HelpText != "") {
        var helptext = controllDetails.HelpText.toString().replace(/'/g, '&#39');
        ImageHtml += "title='" + helptext + "'";
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
            if (!controllDetails.Edit) {
                ImageHtml += "<img  src='" + BackgroundImagesPath + "Gallery/OriginalImages/" + controllDetails.BackgroundImage;
                imagepath = BackgroundImagesPath + "Gallery/OriginalImages/" + controllDetails.BackgroundImage;
            }
            else {

                ImageHtml += "<img  src='" + BackgroundImagesPath + controllDetails.BackgroundImage;
                imagepath = BackgroundImagesPath + controllDetails.BackgroundImage;
            }
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
                ImageHtml += "' style='height:" + controllDetails.Height * mmConvertionConstant + "px;" + ";width:" + controllDetails.Width * mmConvertionConstant + "px;position:absolute;";// changed Height to MaxHeight for Height attribute shahbaz
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
    if (controllDetails.BackgroundImage != "")
        $("#" + controllDetails.ObjectID).draggable({ disabled: true });


    if (AddNew) {
        $("#" + controllDetails.ObjectID).css('border', '1px solid #B2B2B2');
        $("#" + controllDetails.ObjectID).css('cursor', 'pointer');
        changeSelectedControllID();

        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.MaxHeight = parseFloat($("#" + selectedObjectID).innerHeight() / mmConvertionConstant);
        Control.Height = parseFloat($("#" + selectedObjectID).innerHeight() / mmConvertionConstant);

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


/*Adding text control to canvas dynamically*/
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

            if (Control.PositionX < 0) { $("#txtPostionX").val(0); } else { $("#txtPostionX").val(parseFloat(Control.PositionX).toFixed(4)); }
            if (Control.PositionY < 0) { $("#txtPostionY").val(0); } else { $("#txtPostionY").val(parseFloat(Control.PositionY).toFixed(4)); }

            //$("#txtPostionX").val(parseFloat(Control.PositionX).toFixed(4));
            //$("#txtPostionY").val(parseFloat(Control.PositionY).toFixed(4));
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
                        //$("#drpFontStyleID" + FontStyleDetails[j].FontStyleName.replace(/ /g, "")).prop('selected', true);
                        $(document.getElementById("drpFontStyleID" + FontStyleDetails[j].FontStyleName.replace(/ /g, ""))).prop("selected", true);
                        $("#txtFontStyle").val(FontStyleDetails[j].FontStyleName);
                    }
                }
            }
            else {
                $("#drpFontStyleID" + 0).prop('selected', true);
                $("#txtFontStyle").val("");
            }

            $("#txtFontSize").val(parseFloat(Control.OriginalFontSize).toFixed(4));
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
                        //$("#drpColorStyleID" + ColorStyleDetails[j].ColorStyleName.replace(/ /g, "")).prop('selected', true);//Commented For Ticket ID 13039                       
                        $(document.getElementById("drpColorStyleID" + ColorStyleDetails[j].ColorStyleName.replace(/ /g, ""))).prop('selected', true);//Added to fix Ticket ID 13039
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
                $("#rdFirstLetterCapsDontAllowCaps").prop('checked', true);
            }
            else if (Control.Capitalize == "InitCapAllowCaps") {
                $("#rdFirstLetterCapsAllowCaps").prop('checked', true);
            }
            else if (Control.Capitalize == "First Cap") {
                $("#rdAllWordFirstCapsDontAllowCaps").prop('checked', true);
            }
            else if (Control.Capitalize == "FirstCapAllowCaps") {
                $("#rdAllWordFirstCapsAllowCaps").prop('checked', true);
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

                $("#Chk_EditDropdown").prop('disabled', true);
                $("#Chk_EditDropdown").prop('checked', false);

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

                if (Control.EditDropdown == true) {
                    $("#Chk_EditDropdown").prop('disabled', false);
                    $("#Chk_EditDropdown").prop('checked', true);
                } else {
                    $("#Chk_EditDropdown").prop('disabled', false);
                    $("#Chk_EditDropdown").prop('checked', false);
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
                $("#Chk_EditDropdown").prop('disabled', true);
                $("#Chk_EditDropdown").prop('checked', false);
            }




            for (var l = 0; l < FontList.length; l++) {
                if (FontList[l].DisplayFontName == Control.FontFamily) {
                    //$("#drpFontID" + FontList[l].FontID).prop('selected', true);
                    $(document.getElementById("drpFontID" + FontList[l].FontID)).prop("selected", true);
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
                $(".BindJobName").show();
                if (Control.CustomFieldType.toLowerCase() == "date")
                    $(".BindJobName").hide();

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
                    $("#txttextTrscking").prop('disabled', true)
                    $("#txttextTrscking").val(1);
                }
                else if (Control.ExceedWidth == "Expand side") {
                    $("#rdtextSideWays").prop('checked', true);
                    $("#txttextTrscking").val(1);
                }
                else if (Control.ExceedWidth == "Shrink") {
                    $("#rdtextShrink").prop('checked', true);
                    $("#txttextTrscking").val(1);
                }
                else {
                    $("#rdtextTrscking").prop('checked', true);
                    $("#txttextTrscking").prop('disabled', false);
                    $("#txttextTrscking").val(1);

                    $("#txttextTrscking").val(Control.MaxShrink * 100);
                    $("#txttextTrscking").trigger("keyup")
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
                    $(".leftofobject").val("");
                    $(".leftofobject").prop('disabled', true);
                    $(".aboveobject").val("");
                    $(".aboveobject").prop('disabled', true);
                    $("#rdrightofobject").prop('checked', false);
                    $("#rdrightofobject").prop('disabled', true);
                    $(".rightofobject").val("");
                    $(".rightofobject").prop('disabled', true);
                }
                else if (Control.Labels == "Use Labels") {
                    $("#rdUseLabel").prop('checked', true);

                    $("#txtLabel").prop('disabled', false);
                    $("#txtLabel").val(Control.LabelValue);

                    $("#drplabelFontStyle").prop('disabled', false);
                    $("#drplabelColorStyle").prop('disabled', false);

                    //Changed By Shahbaz
                    if (Control.LabelFontStyle != "") {
                        // $("#drpLabelFontStyleID" + Control.LabelFontStyle.replace(/ /g, "")).prop('selected', true);
                        $(document.getElementById("drpLabelFontStyleID" + Control.LabelFontStyle.replace(/ /g, ""))).prop('selected', true);
                    }
                    else
                        $("#drpLabelFontStyleID" + 0).prop('selected', true);

                    if (Control.LabelColor != "") {
                        for (var j = 0; j < ColorStyleDetails.length; j++) {
                            if (ColorStyleDetails[j].ColorStyleName == Control.LabelColor) {
                                $(document.getElementById("drpLabelColorStyleID" + ColorStyleDetails[j].ColorStyleName.replace(/ /g, ""))).prop('selected', true);
                                //$("#drpLabelColorStyleID" + ColorStyleDetails[j].ColorStyleName.replace(/ /g, "")).prop('selected', true);
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
                        $("#rdrightofobject").prop('disabled', true);
                        $(".leftofobject").prop('disabled', true);
                        $(".aboveobject").prop('disabled', true);
                        $(".rightofobject").prop('disabled', true);
                        $(".leftofobject").val("");
                        $(".aboveobject").val("");
                        $(".rightofobject").val("");
                        $("#rdaboveobject").prop('checked', false);
                        $("#rdleftofobject").prop('checked', false);
                        $("#rdrightofobject").prop('checked', false);
                    }
                    else if (Control.LabelPosition == "RightAttached") {
                        $("#rdAttached").prop('checked', true);
                        $("#rdleftofobject").prop('diasbled', true);
                        $("#rdaboveobject").prop('diasbled', true);
                        $("#rdrightofobject").prop('disabled', true);
                        $(".leftofobject").prop('disabled', true);
                        $(".aboveobject").prop('disabled', true);
                        $(".rightofobject").prop('disabled', true);
                        $(".leftofobject").val("");
                        $(".aboveobject").val("");
                        $(".rightofobject").val("");
                        $("#rdaboveobject").prop('checked', false);
                        $("#rdleftofobject").prop('checked', false);
                        $("#rdrightofobject").prop('checked', false);
                    }
                    else if (Control.LabelPosition == "customLeft") {
                        $("#rdCustomPostioning").prop('checked', true);
                        $("#rdleftofobject").prop('checked', true);
                        $(".leftofobject").prop('disabled', false);
                        $("#rdleftofobject").prop('disabled', false);
                        $("#rdaboveobject").prop('disabled', false);
                        $("#rdrightofobject").prop('disabled', false);
                        $(".aboveobject").prop('disabled', true);
                        $(".rightofobject").prop('disabled', true);
                        $(".leftofobject").val(Control.CustomLeft);
                        $(".aboveobject").val("");
                        $(".rightofobject").val("");
                    }
                    else if (Control.LabelPosition == "customTop") {
                        $("#rdCustomPostioning").prop('checked', true);
                        $("#rdaboveobject").prop('checked', true);
                        $(".aboveobject").prop('disabled', false);
                        $("#rdaboveobject").prop('disabled', false);
                        $("#rdleftofobject").prop('disabled', false);
                        $(".leftofobject").prop('disabled', true);
                        $(".leftofobject").val("");
                        $(".rightofobject").val("");
                        $(".aboveobject").val(Control.CustomTop);
                    } else if (Control.LabelPosition == "customRight") {
                        $("#rdCustomPostioning").prop('checked', true);
                        $("#rdrightofobject").prop('checked', true);
                        $(".aboveobject").prop('disabled', true);
                        $("#rdaboveobject").prop('disabled', false);
                        $("#rdleftofobject").prop('disabled', false);
                        $(".leftofobject").prop('disabled', true);
                        $(".leftofobject").val("");
                        $(".aboveobject").val("");
                        $(".rightofobject").prop('disabled', false);
                        $(".rightofobject").val(Control.CustomRight);
                    }

                    if (Control.TextAlign.toLowerCase() == "left" || Control.TextAlign.toLowerCase() == "center") {
                        $(".rightofobject").val("");
                        $("#rdrightofobject").prop('disabled', true);
                    } else {
                        $("#rdrightofobject").prop('disabled', false);
                    }
                }

                var TextBoxControls = [];
                var checkedCount = 0;
                var checkedObjectId = '';
                ControllDetails.map(function (proj) { if (proj.Type == "TextBlock") TextBoxControls.push(proj); });
                for (var j = 0; j < TextBoxControls.length; j++) {
                    if (TextBoxControls[j].IsJobNameField) {
                        checkedCount = 1;
                        checkedObjectId = TextBoxControls[j].ObjectID;
                    }
                }

                if (checkedCount > 0) {
                    if (Control.ObjectID == checkedObjectId) {
                        $("#chkJobNameField").prop("checked", true);
                        $("#chkJobNameField").prop("disabled", false);
                    } else {
                        $("#chkJobNameField").prop("checked", false);
                        $("#chkJobNameField").prop("disabled", true);
                    }
                } else {
                    $("#chkJobNameField").prop("checked", false);
                    $("#chkJobNameField").prop("disabled", false);
                }

                $(".div_PhoneFormat").show();
                if (Control.PhoneFormat.toLowerCase() != "none") {
                    $("#drpPhoneFormat").prop("disabled", false);
                    $("#chkPhoneFormat").prop("checked", true);
                    $("#drpPhoneFormat").val(Control.PhoneFormat);
                } else {
                    $("#drpPhoneFormat").prop("disabled", true);
                    $("#chkPhoneFormat").prop("checked", false);
                    $("#drpPhoneFormat").val(0);
                }
            }


            if (Control.Type == "Paragraph") {
                $(".TextBlock").hide();
                $(".ParaGraph").show();
                $(".ImagePanel").hide();
                $(".BindJobName").hide();
                $(".div_PhoneFormat").hide();
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
                $("#txtLineSpacing").val(Control.ParaLineSpace);
            }
        }

    }
    if (Control.Type == "Image") {

        $(".TextBlock").hide();
        $(".ParaGraph").hide();
        $(".ImagePanel").show();
        $(".BindJobName").hide();
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

        if (Control.PositionX < 0) { $("#txtImagePostionX").val(0); } else { $("#txtImagePostionX").val(parseFloat(Control.PositionX).toFixed(4)); }
        if (Control.PositionY < 0) { $("#txtImagePostionY").val(0); } else { $("#txtImagePostionY").val(parseFloat(Control.PositionY).toFixed(4)); }


        //$("#txtImagePostionX").val(parseFloat(Control.PositionX).toFixed(4));
        //$("#txtImagePostionY").val(parseFloat(Control.PositionY).toFixed(4));

        if (Control.Lock) {
            $("#chkImageLockPosition").prop('checked', true);
        }
        else {
            $("#chkImageLockPosition").prop('checked', false);
        }
        // alert(Control.isDisplayonPDf);

        if (Control.isDisplayonPDf) {
            $("#chkImageIsDisplayOnPDF").prop('checked', true);
        }
        else {
            $("#chkImageIsDisplayOnPDF").prop('checked', false);
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

        if (Control.DefaultImageFrom.toLowerCase() != "none" && Control.DefaultImageFrom != "" && Control.DefaultImageFrom != null) {
            $("#chkImageFromDropDown").prop('checked', true);
            // $("#drpImageFrom").prop('disabled', false);
            $("#drpImageFrom").val(Control.DefaultImageFrom);
        } else {
            $("#chkImageFromDropDown").prop('checked', false);
            $("#drpImageFrom").val(Control.DefaultImageFrom);
            $("#drpImageFrom").prop('disabled', true);
        }

        if (Control.BackgroundImage != "") {
            $("#chkBackground").prop('checked', true);
            $("#txtMaxImageHeight").prop({ 'disabled': true });
            $("#txtMaxImageWidth").prop({ 'disabled': true });
        }
        else {
            $("#chkBackground").prop('checked', false);
            $("#txtMaxImageHeight").prop({ 'disabled': false });
            $("#txtMaxImageWidth").prop({ 'disabled': false });
        }

        if (Control.IsImageQuality) {
            $("#DPI_Panel").show();
            $("#txtDPI").val(Control.MinDPI);
            $("#chkImageQuality").prop('checked', true);
        }
        else {
            $("#DPI_Panel").hide();
            $("#txtDPI").val(Control.MinDPI);
            $("#chkImageQuality").prop('checked', false);
        }

        if (Control.AllowImageEdit) {
            $("#ChkAllowUserEdit").prop('checked', true);
        }
        else {
            $("#ChkAllowUserEdit").prop('checked', false);
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

/*Load events and functionalities for the controls on canvas*/
var orgWidthCrop = 0;
var orgHeightCrop = 0;
function functionalities() {
    debugger;
    //added by shahbaz to hide scroll if canvas height n Width is less than editor height n Width
    if ($("#Maincanvas").height() < $("#editor").height() && $("#Maincanvas").width() < $("#editor").innerWidth())
        $("#LayoutCanvas").css("overflow", 'hidden')
    $("#LayoutCanvas").css("overflow-x", 'hidden')
    $(function () {
        var changeInTop = 0;
        $(".Image,.Para,.Text").draggable({
            drag: function (evt, ui) {
                ui.position.top = ui.position.top / zoom;
                ui.position.left = ui.position.left / zoom;
                debugger;
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
                        //    var x = getHeightofRotatedTextBlock(RotateDegree, ui.helper[0].offsetWidth);
                        //    ui.position.top = (ui.position.top + x * mmConvertionConstant)
                        //}
                        //else if (RotateDegree >= 70 && RotateDegree <= 85) {
                        //    RotateDegree = 60
                        //    var x = getHeightofRotatedTextBlock(RotateDegree, ui.helper[0].offsetWidth);
                        //    ui.position.top = (ui.position.top + x * mmConvertionConstant)
                        //}
                        //else if (RotateDegree == 90) {
                        //    ui.position.top = (ui.position.top + ui.helper[0].offsetWidth)
                        //}
                        //else {
                        //    var y = getWidthofRotatedTextBlock(RotateDegree, ui.helper[0].offsetWidth);
                        //    var x = getHeightofRotatedTextBlock(RotateDegree, ui.helper[0].offsetWidth, y * mmConvertionConstant);
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

                        var PositionX = getWidthOfRotatedImageControl(RotateDegree, ui.helper[0].offsetWidth, ui.helper[0].offsetHeight, this);
                        //var PositionY = getHeightofRotatedImageControl(RotateDegree, ui.helper[0].offsetWidth, PositionX, ui.helper[0].offsetHeight, this)

                        var element = document.getElementById(this.id);
                        var PositionY = element.getBoundingClientRect().height / zoomvalue() - ui.helper[0].offsetHeight;

                        if (RotateDegree < 90) {
                            ui.position.top = ui.position.top + PositionY;
                            ui.position.left = ui.position.left + PositionX;
                        }
                        else if (RotateDegree == 90) {
                            ui.position.top = ui.position.top + PositionY;
                            ui.position.left = ui.position.left + ui.helper[0].offsetHeight;
                        }
                        else if (RotateDegree <= 110) {
                            ui.position.top = ui.position.top;
                            ui.position.left = ui.position.left + (ui.helper[0].offsetHeight + PositionX);
                        }
                        else if (RotateDegree <= 180) {

                            if (RotateDegree > 135) {

                                deg = 180 - RotateDegree;
                                h = Math.sin(deg * Math.PI / 180) * PositionX;
                                h = ui.helper[0].offsetHeight - h
                                PositionY = h
                            }
                            if (RotateDegree <= 135)
                                ui.position.top = ui.position.top - (ui.helper[0].offsetWidth - ui.helper[0].offsetHeight);
                            else
                                ui.position.top = ui.position.top - PositionY;
                            ui.position.left = ui.position.left + PositionX;
                        }
                        else if (RotateDegree <= 270) {
                            ui.position.top = ui.position.top - ui.helper[0].offsetWidth;
                            if (RotateDegree < 240)
                                ui.position.left = ui.position.left + (ui.helper[0].offsetHeight);
                            else if (RotateDegree <= 250)
                                ui.position.left = ui.position.left - (ui.helper[0].offsetHeight - PositionX);
                            else
                                ui.position.left = ui.position.left;
                        }
                        else if (RotateDegree <= 310) {
                            if (RotateDegree < 300)
                                ui.position.top = ui.position.top - ui.helper[0].offsetHeight + PositionY;
                            else
                                ui.position.top = ui.position.top - PositionY
                        }
                    }
                }
                getPosition();
            },
            stop: function (evt, ui) {
                getPosition();
            },
            start: function (evt, ui) {

            },
            containment: "#Maincanvas",
            scroll: false,
            cursor: "move",
            scrollSensitivity: 100,
        });

        $(".Text").resizable({
            handles: 'e, w',
            resize: function (evt, ui) {0
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
            maxWidth: textCanvasWidth,
            maxHeight: textCanvasHeight
        });
        var Actualtop = 0;
        var init = true;
        $(".Image").resizable({
            handles: 'e,w,n,s,ne,nw,sw,se',
            resize: function (evt, ui) {
                if (ui.originalPosition.top == 0 && init) {
                    $(this).css('top', Actualtop);
                    ui.originalPosition.top = Actualtop;
                }
                var changeWidth = 0, changeHeight = 0
                //changeWidth = ui.size.width - ui.originalSize.width;
                //changeHeight = ui.size.height - ui.originalSize.height;
                //var newWidth = ui.originalSize.width + changeWidth / zoom;
                //ui.originalElement.width(newWidth);

                //var newHeight = ui.originalSize.height + changeHeight / zoom;
                //ui.originalElement.height(newHeight);

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

                //$(this).css({'top':})

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
            //containment: "#textCanvas",
            //maxWidth: textCanvasWidth,
            //maxHeight: textCanvasHeight
        });


        $(".Para").resizable({
            handles: 'e,w,n,s',
            resize: function (evt, ui) {
                var changeWidth = 0, changeHeight = 0

                if (ui.originalPosition.top == 0 && init) {
                    $(this).css('top', Actualtop);
                    ui.originalPosition.top = Actualtop;
                }

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




                //$(this).css({'top':})

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
            minHeight: 15,
            maxWidth: textCanvasWidth,
            maxHeight: textCanvasHeight
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
            $(this).css({ 'border': '1px dashed rgb(128, 128, 128)', 'cursor': 'pointer' });
            //$(this).css({ 'border': '1px dashed #808080' });
            //$(this).css({ 'border': '1px solid #b2b2b2', '-moz-border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', '-webkit-border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', '-o-border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', 'border-image': 'url(/StyleSheets/Images/bordera.png) 10 11 11 9 round', 'border-image-slice': '10 11 11 9 ', 'border-image-repeat': 'repeat', 'border-width': '5px', 'border-image-outset': '0px 0px 0px 0px' });
            //$(this).css({ 'border': '1px solid #b2b2b2', '-webkit-border-image': 'url(/StyleSheets/Images/bodera.png) 30 30 stretch', '-o-border-image': ' url(/StyleSheets/Images/bodera.png) 30 30 stretch', 'border-image': 'url(/StyleSheets/Images/bodera.png) 30 30 stretch' });
            //$(this).css('cursor', 'pointer');
            //var id = $(this)[0].id;
            //var Control;
            //ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });           
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
            if (Control.IsFromPdf == false) {
                var image = Control.OrignalImageName;
                var imagepath = BackgroundImagesPath + image;
                if (image == "noimage.png" || image == "noimage.jpg" || image == "") {
                    imagepath = SiteImages + "noimage.jpg";
                }

                $("div[aria-describedby=Imageeditor] .ui-dialog-buttonpane").css('margin-right', '30px');
                $("div[aria-describedby=Imageeditor] .ui-dialog-buttonpane .ui-button").css('margin', '5px');
                $("div[aria-describedby=Imageeditor] .ui-dialog-buttonpane .ui-button span").css({ 'font-size': '11px' });
                $("#RadImageEditor1_canvas").css('float', 'left');
                $("#RadImageEditor1").css({ 'width': '770px', 'position': 'absolute', 'left': '0px', 'margin-right': '50px', 'margin-left': '50px' });
                $("#Imageeditor").css('overflow', 'visible');
                var tmpImg = new Image();
                tmpImg.src = imagepath;
                $(tmpImg).on('load', function () {

                    $("#RadImageEditor1_canvas").attr('height', tmpImg.height);
                    $("#RadImageEditor1_canvas").attr('width', tmpImg.width);
                    $("#RadImageEditor1_canvas").css({ 'height': tmpImg.height, 'width': tmpImg.width })
                    orgWidthCrop = parseInt(Control.Width * mmConvertionConstant);
                    orgHeightCrop = parseInt(Control.Height * mmConvertionConstant);

                    $("#Imageeditor").dialog("open");
                    var x = GetEditor();

                    GetEditor().insertImage(0, 0, imagepath, "");

                    if (orgHeightCrop > 400 || orgWidthCrop > 750) {
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
        $("img").unbind("error").bind("error", function (e) {
            imageloadedcount = imageloadedcount + 1;
            if ($(this).attr("src") != "noimage.jpg") {
                var id = $($(this).parent()).attr("id");
                $(this).attr("src", SiteImages + "noimage.jpg");
                selectedObjectID = id;
                FitTheEditedImageToControl("noimage.jpg");
                setTimeout(function () { $("#canvasLoading").hide(); selectedObjectID = "" }, 100)
            }
        })
    });
}

/*Load events and functionalities for the review fields*/
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

/*Hide or clear accordion content*/
function clearAccordin() {
    $("#accordion > .content").each(function () {
        if ($(this).css('display') == 'block') {
            $(this).prev().trigger('click');
            $(this).hide();
        }
    });
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

/*Change Selected Control ID*/
function changeSelectedControllID() {
    $("#textCanvas > .controll").each(function () {
        if ($(this).css('border-left-color') == 'rgb(128, 128, 128)' || $(this).css('border-left-color') == 'rgb(178, 178, 178)') {
            selectedControllID = "#" + $(this).attr('id');
            selectedObjectID = $(this).attr('id');
        }
    });
}

/*Show accordion for Image Contorl*/
function showImageAccordion() {

    $(".LayoutPanel").hide();
    $(".FontPanel").hide();
    $(".ColorPanel").hide();
    $(".DefaultContentPanel").hide();
    $(".LabelPanel").hide();
    $(".PropertiesPanel").show();
    $(".InformationPanel").show();
}

/*Show accordion for Text Contorl*/
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

/*Show accordion for Paragraph Contorl*/
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

/*Deselect all controlls*/
function deSelect() {
    debugger;
    $(".Para,.Image").css({ 'border': '0', 'border': 'none', 'border-style': 'none', '-webkit-border-image': 'none', 'border-image-source': 'none' });
    $(".Text").css('border', '1px dashed transparent');
    //$(".Para").css('border', '1px dashed transparent');
    $(".Image").css('border', '1px solid transparent');
    $(".Text").css('cursor', 'pointer');
    $(".Para").css('cursor', 'pointer');
    $(".Image").css('cursor', 'pointer');
    $(".reiewFields").css('background-color', 'transparent');
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

/*Get the rotated angle in dgress of the object*/
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

/*zooming the canvas*/
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
    //$("#Maincanvas").css('width', mainCanWidth + 'px');
    $("#Maincanvas").css('height', maincanheight + 'px');

    $/*("#LayoutCanvas").css('width', CanvasWidth + "px");*/
        ("#LayoutCanvas").css('width', 1000 + "px");
    if ((parseFloat($("#textCanvas").innerWidth()) * (zoomCanvas + .05)) > (parseFloat($("#LayoutCanvas").innerWidth()))) {
        $("#helper").hide();
    }
    else {
        $("#helper").show();
    }
}

/*Get Unique Font name*/
function getuniquefontname() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    for (var i = 0; i < 10; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
}

/*Capitalize the text*/
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
    else if (Capitalize == "InitCapAllowCaps") {
        var firstLetter = DefaultContent.substr(0, 1).toUpperCase();
        var remaingString = DefaultContent.substr(1, DefaultContent.length - 1);
        defaultContent = firstLetter + remaingString;
    }
    else if (Capitalize == "First Cap") {
        var content = "";
        var Words = DefaultContent.split(" ");

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
            }
        }

        /*Checking new line in Default Content   (Added By Shahbaz)*/
        var NewLine = content.split(/\r\n|\r|\n/g);
        if (NewLine.length > 1) {
            content = NewLine[0] + "\n"
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
        var Words = DefaultContent.split(" ");
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
            }
        }

        /*Checking new line in Default Content   (Added By Shahbaz)*/
        var NewLine = content.split(/\r\n|\r|\n/g);
        if (NewLine.length > 1) {
            content = NewLine[0] + "\n"
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

    defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt");
    defaultContent = defaultContent;
    defaultContent = defaultContent;
    return defaultContent;
}

/*Align the text to with in the control*/
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

/*Align the image to its image location with in the control*/
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

/*Attach Label to single line control*/
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

/*Sort Json*/
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

/*Fix the position ofthe control on the canvas*/
function fixPostionOfControll(ID, posXValue, posYValue, Alignment) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == ID) Control = proj });

    var zoom = zoomvalue();

    var elementHeight = parseFloat($("#" + Control.ObjectID).innerHeight());
    var elementWidth = parseFloat($("#" + Control.ObjectID).innerWidth());

    //elementWidth = Control.MaxWidth * mmConvertionConstant;

    if (posYValue.toString() == 'NaN')
        posYValue = Control.PositionY;

    if (posXValue.toString() == 'NaN')
        posXValue = Control.PositionX;

    var textcanvas = textCanvasHeight;
    //var left = posXValue * mmConvertionConstant;
    //var bottom = posYValue * mmConvertionConstant;
    var CropMarkHeight = TemplateDetails.CropMarkHeight;
    var CropMarkWidth = TemplateDetails.CropMarkWidth;
    var bottom = (posYValue * mmConvertionConstant) - (CropMarkHeight * mmConvertionConstant);
    var left = (posXValue * mmConvertionConstant) - (CropMarkWidth * mmConvertionConstant);

    if (Alignment.toLowerCase() == "right") {
        var right = textCanvasWidth - left;
        elementWidth = parseFloat($("#" + Control.ObjectID).innerWidth());
        left = Math.round(left) - elementWidth;

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
        elementWidth = parseFloat($("#" + Control.ObjectID).innerWidth());
        left = Math.round(left) - (elementWidth / 2);

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

        if (Control.Type == "Paragraph") {
            left = left - 1;
            bottom = bottom - 1;
        }

        //$("#" + Control.ObjectID).css({ 'left': left, 'top': top });
        $("#" + Control.ObjectID).css({ 'right': 'auto', 'left': left + "px", 'top': 'auto', 'bottom': bottom + "px" });
        return true;
    }
}

/*design jqueri Ui popups*/
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

/*Onexceed width events for text and para contorl on page load*/
function applyonexceedwidth(id) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == id) Control = proj });

    var width = $("#" + Control.ObjectID).innerWidth();
    var width = $("#" + Control.ObjectID).outerWidth();
    var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();

    if (Control.LabelPosition == "customTop") {
        LabelWidth = 0;
    }

    if (width > LabelWidth)
        width = width - LabelWidth;

    var widthonlabelLeft = 0;
    if (Control.LabelPosition == "customRight") {
        var widthonlabelLeft = parseFloat($("#" + Control.ObjectID + " .label").width());
        //widthonlabelLeft = (Control.Width - RightlabelWidth) * mmConvertionConstant;
    }

    var TextWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth;

    var defaultContent = "";
    if (Control.DefaultContent != "") {
        defaultContent = Control.DefaultContent;
    }
    else {
        defaultContent = Control.FieldName;
    }
    if (Control.ExceedWidth == "Do Nothing") {
        if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() + LabelWidth + widthonlabelLeft) > width) {
            while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
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
            while (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth() - LabelWidth) > width && fontsize > 0) {
                $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                Control.FontSize = font * ptConvertionConstant;
                //$("#txtFontSize").val(font * ptConvertionConstant);

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
    else if (Control.ExceedWidth == "Tracking" || Control.ExceedWidth == "Track") {
        if (Control.MaxShrink > 1)
            Control.MaxShrink = Control.MaxShrink / 10;
        if (Control.MaxShrink == 0) {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                    defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                    //  UserText = UserText.substr(0, UserText.length - 1);
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    $("#txtDefaultContent").val(defaultContent.replace(/&nbsp;/g, " "));
                }
            }

            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            // alignsingleLineText(Control.ObjectID);
            Control.DefaultContent = defaultContent;
            // changeAlignment(Control.TextAlign);
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
                $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': letterSpacing + "px" });
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
                $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': letterSpacing + "px" });
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

        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
        // changeAlignment(Control.TextAlign);

    }
    //else if (Control.ExceedWidth == "Tracking") {

    //    if (parseFloat($("#" + Control.ObjectID + " .labelText").innerWidth()) > width) {
    //        if (Control.MaxShrink > 0) {
    //            
    //            var spacing;
    //            var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
    //            var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
    //            var letterSpacing = LetterSpacing - Control.MaxShrink;
    //            while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
    //                $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });

    //                attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
    //                spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
    //                letterSpacing = letterSpacing - Control.MaxShrink
    //            }
    //            $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': LabelLetterSpacing + "px" });
    //            Control.ManualTrackSign = spacing[0];
    //            Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
    //            Control.ManualTrackDimension = "pt";
    //        }
    //        else {
    //            while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) >= width) {
    //                defaultContent = defaultContent.substr(0, defaultContent.length - 1);
    //                attachLabelTosinglelineControl(Control.ObjectID, defaultContent);


    //                Control.DefaultContent = defaultContent;
    //            }
    //        }
    //    }
    //    else {


    //        $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': 0 + 'px' });
    //        if (Control.DefaultContent != "") {
    //            Control.DefaultContent = defaultContent;
    //        }
    //        else {
    //            Control.FieldName = defaultContent;
    //        }
    //    }
    //}
}

/*Cahnge color by input text*/
function changeColorByInputText() {
    chnageFontColorCMYKtoRGB();
}

/*Cahnge color from CMYK to RGB*/
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

/*Function not to allow alpahbets*/
function validateQty(event) {

    var value = $("#" + event.target.id).val();

    //if ($(event.target).hasClass("txtRotateX") || event.target.id == "txtRotate") {
    //    if(value=='')

    //}
   
    var key = window.event ? event.keyCode : event.which;
    if ( event.keyCode == 46
     || event.keyCode == 37 || event.keyCode == 39) {
        return true;
    }
    else if (key < 48 || key > 57) {
        return false;
    }
}

/*Function not to allow alpahbets*/
function vaild(event) {

    var value = $(event.target).val();

    if (event.target.id == "txtC" || event.target.id == "txtC2" || event.target.id == "txtM" || event.target.id == "txtM2" || event.target.id == "txtY" || event.target.id == "txtY2" || event.target.id == "txtK" || event.target.id == "txtK2" || event.target.id == "txtT" || event.target.id == "txtT2") {
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
        //if (value >= 0) {

        //}
        //else {
        //    bindPreviosValue(event);
        //}
    }

}

/*Function not to allow alpahbets*/
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
        $("#txtFontSize").val(parseFloat(Control.OriginalFontSize).toFixed(4));
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
    else if (event.target.id == "txtDPI") {
        $("#txtDPI").val(Control.MinDPI);
    }
    else {
        $(event.target).val("0");
    }
}

/*Applying control height according to the font size*/
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

/*Desgning the message Box dynamically*/
function msgBoxDesign() {

    $(".ui-dialog-title").css({ 'width': 'auto' });
    $(".ui-dialog-buttonset").css({ 'margin-right': '0px auto 0px auto', 'width': 'auto' });
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

/*Loading the current position of the controls dynamically*/
function getPosition() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    //Taking Previous position of Control 
    PreviousLeftPos = Control.PositionX;
    PreviousTopPos = Control.PositionY;

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


        //for avoiding negative  x and y position

        Control.PositionX = parseFloat(leftFinal).toFixed(4);
        Control.PositionY = parseFloat(topFinal).toFixed(4);
        Control.CoordsX = parseFloat(leftFinal).toFixed(4);
        Control.CoordsY = parseFloat(topFinal).toFixed(4);
        Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
        Control.OffsetTop = parseFloat(topFinal).toFixed(4);
        Control.Left = parseFloat(leftFinal).toFixed(4);
        Control.Top = parseFloat(topFinal).toFixed(4);
        if (leftFinal < 0)
            leftFinal = 0
        if (topFinal < 0)
            topFinal = 0;


        $("#txtPostionX").val(parseFloat(leftFinal).toFixed(4));
        $("#txtPostionY").val(parseFloat(topFinal).toFixed(4));
    }
    else if ($("#" + Control.ObjectID).hasClass('Image')) {

        //if (leftFinal * mmConvertionConstant + Control.Width * mmConvertionConstant > textCanvasWidth + 2) {
        //    leftFinal = PreviousLeftPos;
        //    $("#txtImagePostionX").val(parseFloat(PreviousLeftPos).toFixed(4));
        //    $("#txtImagePostionX").trigger('keyup');
        //}
        //if (topFinal * mmConvertionConstant < -1) {
        //    topFinal = PreviousTopPos;
        //    $("#txtImagePostionY").val(parseFloat(PreviousTopPos).toFixed(4));
        //    $("#txtImagePostionY").trigger('keyup');
        //}


        Control.PositionX = parseFloat(leftFinal).toFixed(4);
        Control.PositionY = parseFloat(topFinal).toFixed(4);
        Control.CoordsX = parseFloat(leftFinal).toFixed(4);
        Control.CoordsY = parseFloat(topFinal).toFixed(4);
        Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
        Control.OffsetTop = parseFloat(topFinal).toFixed(4);
        Control.Left = parseFloat(leftFinal).toFixed(4);
        Control.Top = parseFloat(topFinal).toFixed(4);
        //for avoiding negative  x and y  position
        if (leftFinal < 0)
            leftFinal = 0
        if (topFinal < 0)
            topFinal = 0;


        $("#txtImagePostionX").val(parseFloat(leftFinal).toFixed(4));
        $("#txtImagePostionY").val(parseFloat(topFinal).toFixed(4));
    }

    //Added By Shahbaz For Rotated Control
    if (Control.RotateAngle > 0) {
        var RotateDegree = Control.RotateAngle;
        if ($("#" + Control.ObjectID).hasClass("Text")) {

            //var XPosition = getWidthofRotatedTextBlock(Control.RotateAngle, Control.Width * mmConvertionConstant);
            //var YPosition = getHeightofRotatedTextBlock(Control.RotateAngle, Control.Width * mmConvertionConstant);

            var PositionX = getWidthOfRotatedTextParaControl(RotateDegree, Control.Width * mmConvertionConstant, Control.Height * mmConvertionConstant);
            var PositionY = getHeightOfRotatedTextParaControl(RotateDegree, Control.Height * mmConvertionConstant, Control.Width * mmConvertionConstant, $("#" + Control.ObjectID));


            if (RotateDegree < 95) {
                topFinal = topFinal - (PositionY / mmConvertionConstant);
                leftFinal = leftFinal + (PositionX / mmConvertionConstant);
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

            //if (RotateDegree < 70) {
            //    var x = getHeightofRotatedTextBlock(RotateDegree, Control.Width * mmConvertionConstant);
            //    topFinal = (topFinal - x)
            //}
            //else if (RotateDegree >= 70 && RotateDegree <= 85) {
            //    RotateDegree = 60
            //    var x = getHeightofRotatedTextBlock(RotateDegree, Control.Width * mmConvertionConstant);
            //    topFinal = (topFinal - x)
            //}
            //else if (RotateDegree == 90) {
            //    topFinal = (topFinal - Control.Width)
            //}
            //else {
            //    var y = getWidthofRotatedTextBlock(RotateDegree, Control.Width * mmConvertionConstant);
            //    var x = getHeightofRotatedTextBlock(RotateDegree, Control.Width * mmConvertionConstant, y * mmConvertionConstant);
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
            Control.Top = parseFloat(topFinal).toFixed(4);

            Control.PositionX = parseFloat(leftFinal).toFixed(4);
            Control.CoordsX = parseFloat(leftFinal).toFixed(4);
            Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
            Control.Left = parseFloat(leftFinal).toFixed(4);

            $("#txtPostionX").val(parseFloat(leftFinal).toFixed(4));
            $("#txtPostionY").val(parseFloat(topFinal).toFixed(4));
        }


        if ($("#" + Control.ObjectID).hasClass("Para")) {
            if (RotateDegree > 0 && RotateDegree < 360) {
                var PositionX = getWidthOfRotatedTextParaControl(RotateDegree, Control.Width * mmConvertionConstant, Control.Height * mmConvertionConstant);
                var PositionY = getHeightOfRotatedTextParaControl(RotateDegree, Control.Height * mmConvertionConstant, Control.Width * mmConvertionConstant, $("#" + Control.ObjectID));


                if (RotateDegree < 95) {
                    topFinal = topFinal - (PositionY / mmConvertionConstant);
                    leftFinal = leftFinal + (PositionX / mmConvertionConstant);
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

            //var ActualSize = getActaulHeightOfRotatedControl($("#" + Control.ObjectID), RotateDegree);
            //if (Control.TextAlign == "Center") {
            //    if (RotateDegree < 90) {
            //        topFinal = parseFloat(topFinal - ((ActualSize[1] / mmConvertionConstant) / 2))
            //        leftFinal = leftFinal - ((ActualSize[1] / mmConvertionConstant));
            //    }
            //    else if (RotateDegree > 90) {
            //        topFinal = parseFloat(topFinal + ((ActualSize[1] / mmConvertionConstant) / 2))
            //        leftFinal = leftFinal - ((ActualSize[0] / mmConvertionConstant));
            //    }
            //}


            Control.PositionY = parseFloat(topFinal).toFixed(4);
            Control.CoordsY = parseFloat(topFinal).toFixed(4);
            Control.OffsetTop = parseFloat(topFinal).toFixed(4);
            Control.Top = parseFloat(topFinal).toFixed(4);

            Control.PositionX = parseFloat(leftFinal).toFixed(4);
            Control.CoordsX = parseFloat(leftFinal).toFixed(4);
            Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
            Control.Left = parseFloat(leftFinal).toFixed(4);

            $("#txtPostionX").val(parseFloat(leftFinal).toFixed(4));
            $("#txtPostionY").val(parseFloat(topFinal).toFixed(4));

        }


        if ($("#" + Control.ObjectID).hasClass("Image")) {
            var RotateDegree = parseInt($("#txtRotate").val());

            var controlHeight = parseFloat(Control.Height);
            var controlWidth = parseFloat(Control.Width)
            if (RotateDegree > 0 && RotateDegree < 360) {

                var PositionX = getWidthOfRotatedImageControl(RotateDegree, controlWidth * mmConvertionConstant + 2, controlHeight * mmConvertionConstant + 2, $("#" + Control.ObjectID));
                //var PositionY = getHeightofRotatedImageControl(RotateDegree, Control.Width * mmConvertionConstant, PositionX, Control.Height * mmConvertionConstant, $("#" + Control.ObjectID))

                var element = document.getElementById(Control.ObjectID);
                var PositionY = element.getBoundingClientRect().height / zoomvalue() - $("#" + Control.ObjectID).outerHeight();

                controlHeight = (controlHeight * mmConvertionConstant + 2) / mmConvertionConstant;
                controlWidth = (controlWidth * mmConvertionConstant + 2) / mmConvertionConstant;


                if (RotateDegree < 90) {
                    topFinal = topFinal - PositionY / mmConvertionConstant;
                    leftFinal = leftFinal + PositionX / mmConvertionConstant;
                }
                else if (RotateDegree == 90) {
                    topFinal = topFinal - PositionY / mmConvertionConstant;
                    leftFinal = leftFinal + controlHeight;
                }
                else if (RotateDegree <= 110) {
                    topFinal = topFinal;
                    leftFinal = leftFinal + (controlHeight + PositionX / mmConvertionConstant);

                }
                else if (RotateDegree <= 180) {

                    if (RotateDegree > 135) {

                        deg = 180 - RotateDegree;
                        h = Math.sin(deg * Math.PI / 180) * PositionX;
                        h = controlHeight * mmConvertionConstant - h
                        PositionY = h
                    }

                    if (RotateDegree <= 135)
                        topFinal = topFinal + (controlWidth - controlHeight);
                    else
                        topFinal = topFinal + PositionY / mmConvertionConstant;
                    leftFinal = leftFinal + PositionX / mmConvertionConstant;
                }
                else if (RotateDegree <= 270) {
                    topFinal = topFinal + controlWidth;
                    if (RotateDegree < 240)
                        leftFinal = leftFinal + controlHeight;
                    else if (RotateDegree <= 250)
                        leftFinal = leftFinal - (controlHeight - PositionX / mmConvertionConstant);
                    else
                        leftFinal = leftFinal;

                }
                else if (RotateDegree <= 310) {
                    if (RotateDegree < 300)
                        topFinal = topFinal + controlHeight;
                    else
                        topFinal = topFinal + PositionY / mmConvertionConstant
                }


                Control.PositionX = parseFloat(leftFinal).toFixed(4);
                Control.CoordsX = parseFloat(leftFinal).toFixed(4);
                Control.OffsetLeft = parseFloat(leftFinal).toFixed(4);
                Control.Left = parseFloat(leftFinal).toFixed(4);


                Control.PositionY = parseFloat(topFinal).toFixed(4);
                Control.CoordsY = parseFloat(topFinal).toFixed(4);
                Control.OffsetTop = parseFloat(topFinal).toFixed(4);
                Control.Top = parseFloat(topFinal).toFixed(4);

                $("#txtImagePostionX").val(parseFloat(leftFinal).toFixed(4));
                $("#txtImagePostionY").val(parseFloat(topFinal).toFixed(4));
            }
        }
    }
}
/*To Change Default Content*/
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
            if (Control.LabelPosition != "customTop") {
                $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block' });
            }
        }

        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        if (Control.LabelPosition == "customTop") {
            LabelWidth = 0;
        }
        if (width > LabelWidth)
            width = width - LabelWidth;
        var TextWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth;

        var widthonlabelLeft = 0;
        if (Control.LabelPosition == "customRight") {
            var widthonlabelLeft = parseFloat($("#" + Control.ObjectID + " .label").width());
            //widthonlabelLeft = (Control.Width - RightlabelWidth) * mmConvertionConstant;
            //widthonlabelLeft = (Control.Width - Control.CustomRight) * mmConvertionConstant;
        }
        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
        //$("#" + Control.ObjectID + " .labelText").html(defaultContent);       
        if (autoexpand) {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) + widthonlabelLeft > width - 2) {
                $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth() + 5);
                Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() + 5 - LabelWidth) / mmConvertionConstant;
                Control.Width = Control.MaxWidth;
            }
            changeAlignment(Control.TextAlign);
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
        else if (Control.ExceedWidth == "Do Nothing") {
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() + LabelWidth) + widthonlabelLeft > width) {
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth) + widthonlabelLeft > width) {
                    defaultContent = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">");
                    defaultContent = defaultContent.substr(0, defaultContent.length - 1);
                    UserEnterdText = UserEnterdText.substr(0, UserEnterdText.length - 1);
                    defaultContent = capitalizeTheText(defaultContent, Control.Capitalize);
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    defaultContent = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">");
                }
            }
            changeAlignment(Control.TextAlign);
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
            if (direct == false) {
                if (Control.FieldName == Control.FriendlyName) {
                    $("#txtFriendly").val(UserEnterdText);
                    Control.FriendlyName = UserEnterdText;
                }
                Control.FieldName = UserEnterdText;

                //if (fromTextBox == true) { Commented By shahbaz
                //    $("#txtFieldName").val(UserEnterdText);
                //}
                if (Control.DefaultContent != "") {
                    Control.DefaultContent = UserEnterdText;
                    if (Control.Type == "TextBlock") {
                        $("#txtDefaultContent").val(UserEnterdText);
                        //$("#txtDatabaseContent").val(UserEnterdText);
                    }
                    else if (Control.Type == "Paragraph") {
                        $("#txtParaDefaultContent").val(UserEnterdText);
                        //$("#txtDatabaseContent").val(UserEnterdText);
                    }
                }
            }
            else {

                Control.DefaultContent = UserEnterdText;
                $("#txtDefaultContent").val(UserEnterdText);
                // $("#txtDatabaseContent").val(UserEnterdText);
                if (Control.Type == "TextBlock") {
                    if (fromTextBox != true) {
                        $("#txtDefaultContent").val(UserEnterdText);
                        //$("#txtDatabaseContent").val(UserEnterdText);
                    }
                }
                else if (Control.Type == "Paragraph") {
                    if (fromTextBox != true) {
                        $("#txtParaDefaultContent").val(UserEnterdText);
                        //$("#txtDatabaseContent").val(UserEnterdText);
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
            changeAlignment(Control.TextAlign);
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
        else if (Control.ExceedWidth == "Shrink") {          
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                var fontsize = Fontsize - 0.05;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width && fontsize > 0) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                    Control.FontSize = font * ptConvertionConstant;
                    //$("#txtFontSize").val(font * ptConvertionConstant);
                    if (LabelWidth == null) {
                        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                    }
                    fontsize = fontsize - 0.05;
                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                    Control.Height = Control.MaxHeight;
                    if (fontsize < 0)
                        fontsize = 0;
                }
            }
            else if (Control.FontSize < Control.OriginalFontSize) {
                var Fontsize = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));
                var fontsize = Fontsize + 0.05;
                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) < width && Control.FontSize < Control.OriginalFontSize) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                    Control.FontSize = font * ptConvertionConstant;
                    //$("#txtFontSize").val(font * ptConvertionConstant);


                    if (LabelWidth == null) {
                        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                    }
                    fontsize = fontsize + 0.05;
                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                    Control.Height = Control.MaxHeight;
                }

                while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                    $("#" + Control.ObjectID + " .labelText").css({ 'font-size': fontsize + 'px' });
                    attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                    var font = parseFloat($("#" + Control.ObjectID + " .labelText").css('font-size'));

                    Control.FontSize = font * ptConvertionConstant;
                    // $("#txtFontSize").val(font * ptConvertionConstant);
                    if (LabelWidth == null) {
                        $("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('height'));
                    }
                    fontsize = fontsize - 0.05;
                    Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                    Control.Height = Control.MaxHeight;
                }
            }
            changeAlignment(Control.TextAlign);
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
        else if (Control.ExceedWidth == "Tracking" || Control.ExceedWidth == "Track") {
            if (Control.MaxShrink > 1)
                Control.MaxShrink = Control.MaxShrink / 10;
            if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                if (Control.MaxShrink > 0) {
                    var spacing;
                    var LetterSpacing = parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing'));
                    var LabelLetterSpacing = parseFloat($("#" + Control.ObjectID + " .label").css('letter-spacing'));
                    var letterSpacing = LetterSpacing - Control.MaxShrink;
                    while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
                        $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': letterSpacing + 'px' });
                        attachLabelTosinglelineControl(Control.ObjectID, defaultContent);
                        spacing = $("#" + Control.ObjectID + " .labelText").css('letter-spacing');
                        letterSpacing = letterSpacing - Control.MaxShrink
                    }

                    //$("#" + Control.ObjectID + " .label").css({ 'letter-spacing': letterSpacing + "px" });
                    if (spacing.indexOf("-") > -1) {
                        Control.ManualTrackSign = spacing[0];
                        Control.ManualTracking = parseFloat(spacing.substr(1, spacing.length - 2)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    } else {
                        Control.ManualTrackSign = '+';
                        Control.ManualTracking = parseFloat(spacing.substr(0, spacing.length)) * ptConvertionConstant;
                        Control.ManualTrackDimension = "pt";
                    }
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
                    while (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth + widthonlabelLeft) > width) {
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
                                // $("#txtDatabaseContent").val(UserEnterdText);
                            }
                            else if (Control.Type == "Paragraph") {
                                $("#txtParaDefaultContent").val(UserEnterdText);
                                // $("#txtDatabaseContent").val(UserEnterdText);
                            }
                        }
                    }
                    else {
                        Control.DefaultContent = UserEnterdText;
                        if (Control.Type == "TextBlock") {
                            $("#txtDefaultContent").val(UserEnterdText);
                            //$("#txtDatabaseContent").val(UserEnterdText);
                        }
                        else if (Control.Type == "Paragraph") {
                            $("#txtParaDefaultContent").val(UserEnterdText);
                            //$("#txtDatabaseContent").val(UserEnterdText);
                        }
                    }
                }
            } else if (parseFloat($("#" + Control.ObjectID + " .labelText").css('letter-spacing')) < parseFloat(Control.ManualTracking)) {

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
                    //$("#" + Control.ObjectID + " .label").css({ 'letter-spacing': letterSpacing + "px" });
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
                   // $("#" + Control.ObjectID + " .label").css({ 'letter-spacing': letterSpacing + "px" });
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
                changeAlignment(Control.TextAlign);
                fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
                alignsingleLineText(Control.ObjectID);
            }
        }
        else {
            changeAlignment(Control.TextAlign);
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            alignsingleLineText(Control.ObjectID);
        }
    }
    if ($("#" + Control.ObjectID).hasClass('Para')) {
        defaultContent = defaultContent.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>");
        var Text = defaultContent.replace(/&nbsp;/g, " ").replace(/&lt/g, "<").replace(/&gt/g, ">").replace(/<br>/g, "\n");
        $("#" + Control.ObjectID + " .paraText").html(defaultContent.replace(/&nbsp;/g, " "));
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
                    $("#" + Control.ObjectID + " .paraText").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>").replace(/&nbsp;/g, " "));
                    $("#txtParaDefaultContent").val(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>"));
                    //$("#txtDatabaseContent").val(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt").replace(/\n/g, "<br>"));
                    UserEnterdText = UserEnterdText.substr(0, UserEnterdText.length - 1);
                }
            }
            Control.DefaultContent = UserEnterdText;
            $("#txtParaDefaultContent").val(UserEnterdText);
        }
        else if (Control.ExceedHeight == "Expand Height") {
            if ($("#" + Control.ObjectID + " .paraText").outerHeight() > $("#" + Control.ObjectID).outerHeight()) {
                $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .paraText").outerHeight() });
                Control.Height = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                Control.MaxHeight = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;
                getPosition();//Added By Shahbaz
            }
            Control.DefaultContent = UserEnterdText;
            $("#txtParaDefaultContent").val(UserEnterdText);
            //  $("#txtDatabaseContent").val(UserEnterdText);
        }
    }
    //debugger;
    //if (Control.Dropdowns != "None" && Control.Dropdowns != undefined)
    //    Control.DefaultContent = "";
}

/*Load the Edited image to the control*/
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
    height = $("#" + Control.ObjectID).innerHeight();
    width = $("#" + Control.ObjectID).innerWidth();
    //if (Control.IsImageQuality) {
    //    $.ajax({
    //        url: WebMethodsPath + "checkImageForDPI",
    //        type: "POST",
    //        data: JSON.stringify({ OriginalImageName: fileName, isEdited: "true", ImageUploadPath: ImageUploadPath, CompanyID: CompanyID, minDPI: Control.MinDPI }),
    //        dataType: "json",
    //        processData: false,
    //        contentType: "application/json; charset=utf-8",
    //        success: function (DPIResult) {
    //            if (DPIResult.d == "success") {
    //                LoadImage();
    //            }
    //            else {
    //                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
    //                $("#SaveMessage").dialog("open");
    //                msgBoxDesign();
    //                $("div[aria-describedby=SaveMessage]").css('z-index', '111');
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
        var tmpImg = new Image();

        if (fileName == "noimage.png" || fileName == "noimage.jpg")
            tmpImg.src = SiteImages + fileName;
        else
            tmpImg.src = BackgroundImagesPath + fileName;
        $(tmpImg).on('load', function () {

            var FitImageToContoll = {};
            FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
            FitImageToContoll.type = "POST";
            FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: objectid, isEdited: Edited, ImageUploadPath: ImageUploadPath, CompanyID: CompanyID, _isCropFromTop: "false" });
            FitImageToContoll.dataType = "json";
            FitImageToContoll.processData = false;
            FitImageToContoll.contentType = "application/json; charset=utf-8";
            FitImageToContoll.success = function (ImageName) {
                var arry = ImageName.d.split('~');
                var exceedimage = "";
                var Control;
                ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });
                //if (Control.IsCropFromTop) {
                //    Control.ImgUrl = arry[0];
                //    Control.OrignalImageName = arry[2];
                //}
                //else {
                //    Control.ImgUrl = fileName;
                //    Control.OrignalImageName = arry[2];
                //}

                Control.ImgUrl = fileName;
                Control.EditedImageName = fileName;
                Control.IsFromBackEnd = true;

                Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
                if (Control.BackgroundImage != "") {
                    $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                    Control.BackgroundImage = fileName;
                }
                else {
                    $("#" + Control.ObjectID + " img").css({ 'width': Control.MaxWidth * mmConvertionConstant + 'px', 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'position': 'absolute' });

                    //Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight() / mmConvertionConstant);
                    //Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth() / mmConvertionConstant);
                }

                //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);

                if (Control.IsCropFromTop) {
                    FitAutoCroppedImageToControl(fileName, Edited);
                } else {
                    $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + fileName);
                    Edited = 'false';
                    $(".loading_new").hide();
                }
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

                        //var orgWidth = Control.MaxWidth * mmConvertionConstant;
                        //var orgHeight = Control.MaxHeight * mmConvertionConstant;

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
    //}

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

/**********************************
Menu Bar Events(Craeted By: Infomaze)
***********************************/

/*Bind Events for menu bar*/
function loadEventsForMenuBar() {
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
        //changeAlignment("Left");
        alignControllTothePage("left");
    });

    $("#btnCenterAlign").unbind('click').bind('click', function () {

        //changeAlignment("Center");
        alignControllTothePage("center");
    });

    $("#btnRightAlign").unbind('click').bind('click', function () {
        //changeAlignment("Right");
        alignControllTothePage("right");
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
        changeFrontEditorZoom($(this).val());
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
            $("#SaveMessage").dialog("open");
            $("#savemsg").html("Please select existing template name to copy.");
            msgBoxDesign();
            return false;
        }

    });

    $(".txtCopy").unbind('mousedown').bind("mousedown", function () {
        if ($("#copyDiv").css('display') == 'none' && $("#copyDiv").html() != "")
            $("#copyDiv").show();
        else
            $("#copyDiv").hide();
    });

    $(".txtCopy").focusin(function () {
        var copyhtml = "";
        for (var i = 0; i < TemplateIDandNameList.length; i++) {
            copyhtml += "<div class='sapnCopy copyCombobox' id='copyid_" + TemplateIDandNameList[i].split('~')[0] + "' >" + TemplateIDandNameList[i].split('~')[1] + "</div>";
        }
        $("#copyDiv").html(copyhtml);
        copyClick();
        if (copyhtml == "") {
            $("#copyDiv").hide()
        }
        else {
            $("#copyDiv").show();
        }
    });

    $(".txtCopy").unbind('keyup').bind('keyup', function (event) {
        $("#copyDiv").show();
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

            if (copyhtml == "") {
                $("#copyDiv").hide()
            }
            else {
                $("#copyDiv").show();
            }

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
}

/*Function To cahnge or load the Page*/
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

/*Function to add Bold and Italic to text and paragraph control*/
function ChangeBoldItalic(BoldItalic) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if (BoldItalic == "bold") {
            if (Control.FontWeight == "Normal") {
                if ($("#" + Control.ObjectID).hasClass('Text')) {
                    $("#" + Control.ObjectID + " .labelText").css('font-weight', 'bold');
                    $("#" + Control.ObjectID + " .label").css('font-weight', 'bold');
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
                    $("#" + Control.ObjectID + " .label").css('font-weight', 'normal');
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
                    $("#" + Control.ObjectID + " .label").css('font-style', 'italic');
                }
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " pre").css('font-style', 'italic');
                }
                $("#btnItalic").addClass('menubuttonSelected');
                Control.FontStyle = "Italic";
                Control.LabelFontStyle = "Italic";
            }
            else {
                if ($("#" + Control.ObjectID).hasClass('Text')) {
                    $("#" + Control.ObjectID + " .labelText").css('font-style', 'normal');
                    $("#" + Control.ObjectID + " .label").css('font-style', 'normal');
                }
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " pre").css('font-style', 'normal');
                }
                $("#btnItalic").removeClass('menubuttonSelected');
                Control.FontStyle = "Normal";
                Control.LabelFontStyle = "Normal";
            }

        }

        if ($("#" + Control.ObjectID).hasClass('Text')) {
            //commented By shahabz
            //$("#" + Control.ObjectID).css('height', $("#" + Control.ObjectID + " .labelText").css('line-height'));
            //$("#" + Control.ObjectID).css('line-height', $("#" + Control.ObjectID + " .labelText").css('line-height'));
            //Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant;
            //Control.Height = parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) / mmConvertionConstant;
        }
    }
}

/*Function To align the text and paragraph control to the page*/
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

/*Function To align the text and paragraph control*/
function changeAlignment(align) {
    debugger;
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if (align.toLowerCase() == "left") {

            if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, "Left")) {
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " pre").css('text-align', 'left');
                }
                if (Control.LabelPosition == "customTop") {
                    $("#" + Control.ObjectID + " .labelText").css({ 'right': 'auto', 'left': -1 + 'px', 'text-align': 'left' });
                    $("#" + Control.ObjectID + " .label").css({ 'margin': '0px', 'width': 'auto', 'text-align': 'left' });
                }
                Control.TextAlign = "Left";
                $("#" + Control.ObjectID).css({ 'text-align': Control.TextAlign });
                alignsingleLineText(Control.ObjectID);
                $("#rdLeftJustify").prop('checked', true);
                $("#btnLeftAlign").addClass('menubuttonSelected');
                $("#btnCenterAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
                if (Control.Labels == "Use Labels" && $("#rdCustomPostioning").prop("checked")) {
                    $("#rdrightofobject").prop('disabled', true);
                    $(".rightofobject").prop('disabled', true).val("");
                    if (Control.LabelPosition == "customRight") {
                        $("#rdleftofobject").prop('checked', true);
                        $(".leftofobject").prop('disabled', false).val("0");
                        Control.CustomLeft = 0;
                        $("#rdleftofobject").trigger('click');
                    }
                }

            }
        }
        else if (align.toLowerCase() == "center") {
            if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, "Center")) {
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " pre").css('text-align', 'center');
                }
                Control.TextAlign = "Center";
                $("#" + Control.ObjectID).css({ 'text-align': Control.TextAlign });
                alignsingleLineText(Control.ObjectID);
                if (Control.LabelPosition == "customTop") {
                    var mar = (Control.Width * mmConvertionConstant / 2) - ((parseFloat($("#" + Control.ObjectID + " .labelText").width())) / 2);
                    $("#" + Control.ObjectID + " .labelText").css({ 'right': 'auto', 'left': mar - 1 + 'px', 'text-align': 'center' });
                }
                $("#rdCenterJustify").prop('checked', true);
                $("#btnCenterAlign").addClass('menubuttonSelected');
                $("#btnLeftAlign").removeClass('menubuttonSelected');
                $("#btnRightAlign").removeClass('menubuttonSelected');
                if (Control.Labels == "Use Labels" && $("#rdCustomPostioning").prop("checked")) {
                    $("#rdrightofobject").prop('disabled', true);
                    $(".rightofobject").prop('disabled', true).val("");
                    if (Control.LabelPosition == "customRight") {
                        $("#rdleftofobject").prop('checked', true);
                        $(".leftofobject").prop('disabled', false).val("0");
                        Control.CustomLeft = 0;
                        $("#rdleftofobject").trigger('click');
                    }
                }
            }
        }
        else if (align.toLowerCase() == "right") {
            if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, "Right")) {
                if ($("#" + Control.ObjectID).hasClass('Para')) {
                    $("#" + Control.ObjectID + " pre").css('text-align', 'right');
                }
                Control.TextAlign = "Right";
                $("#" + Control.ObjectID).css({ 'text-align': Control.TextAlign });
                alignsingleLineText(Control.ObjectID);
                if (Control.LabelPosition == "customTop") {
                    $("#" + Control.ObjectID + " .labelText").css({ 'left': 'auto', 'right': '0px', 'text-align': 'right' });
                }
                $("#rdRightJustify").prop('checked', true);
                $("#btnRightAlign").addClass('menubuttonSelected');
                $("#btnLeftAlign").removeClass('menubuttonSelected');
                $("#btnCenterAlign").removeClass('menubuttonSelected');
                if (Control.Labels == "Use Labels" && $("#rdCustomPostioning").prop("checked")) {
                    $("#rdrightofobject").prop('disabled', false);
                }
            }
        }
    }
    return true;

}

/*Function To delete the control from canvas*/
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

/*Function To delete all the controls from canvas*/
function clearAllControlls() {
    for (var i = 0; i < ControllDetails.length; i++) {
        if (ControllDetails[i].PageNumber == parseInt($("#drpPageSelect").val())) {
            ControllDetails[i].Visibility = false;
        }
    }
    $("#textCanvas").empty();
    $("#sortable").empty();
}

/*Function To cut the control from canvas*/
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

/*Function To copy the control from canvas*/
function copyControll() {

    copyID = selectedObjectID;
    cutCopy = "copy";
}

/*Function To paste the control on the canvas*/
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
                AddImageDynamically(Control, false);
            }
            else if (Control.Type == "Paragraph") {
                AddParaDynamically(Control, true);
            }

            var _getctrlscount = $('.controll').length;

            ControllDetails.map(function (proj) { if (proj.ObjectID == GUID) Control = proj });

            Control.ZIndexValue = _getctrlscount;
            Control.OrderNumber = _getctrlscount;
        }
    }
}

/*Added By salim*/
/*Function To copy existing template to*/
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
/*Function To rotate the control on the canvas*/
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

/*Template copy button click*/
function copyClick() {
    $(".copyCombobox").unbind('click').bind('click', function () {
        var val = $(this).html().toString();
        if (val.length > 28) {
            $('.txtCopy').val($(this).html().toString().slice(0, 28));
        } else
            $('.txtCopy').val($(this).html());
        $('.txtCopy').attr('id', 'txtCopy_' + $(this).attr('id').split('_')[1]);
        $("#copyDiv").hide();
        $("#copyDiv").empty();
    });
}

/*Copy Template drop Down select function*/
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

/**********************************
Left Panel Accordion Events(Craeted By: Infomaze)
***********************************/

/**********************************
Information Panel Events(Craeted By: Infomaze)
***********************************/

/*Bind Events for information panel*/
function LoadInformationPanelEvents() {
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
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
            if (value != Control.DefaultContent)
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
}

/*To Change Field Name*/
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

/*Reload the review fields After changing the field name*/
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

/*To Change Friendly Name*/
function changeFriendlyName(Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.FriendlyName = Text;
}

/*To Change Help Text Name*/
function changeHelpText(Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.HelpText = Text;
    $("#" + Control.ObjectID).attr('title', Text);
}

/*To Change Mandatory Status*/
function changeMandatory(status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.Mandatory = status;
}

/*To Change Editable Status*/
function changeNonEditable(Status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.Edit = !Status;
}

/*To Change Hide Status*/
function changeHideFromuser(Status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.HideVisibility = Status;
}


/**********************************
Layout and Properties panel Events(Craeted By: Infomaze)
***********************************/

/*Bind Events for Layout and Properties panel*/
function LoadLayoutAndPropertiesPanelEvents() {
    $(".txtRotateX").unbind('keyup').bind('keyup', function () {
        var rotation = $(this).val();
        if (rotation == '')
            rotation = 0
        rotateSelectedControll(rotation);
    });

    //Added By shahbaz
    $("#txtRotate").unbind('keyup').bind('keyup', function () {
        var rotation = $(this).val();
        if (rotation == '')
            rotation = 0
        rotateSelectedControll(rotation);
    });

    $("#txtLineSpacing").unbind('keyup').bind('keyup', function () {
        changeLineSpacing($(this).val());
    });

    $("#txtPostionX").unbind('keyup').bind('keyup', function () {
        if ($("#txtPostionX").val() != "") {
            var posXValue = parseFloat($("#txtPostionX").val());
            changePositioX(posXValue);
        }

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
        if ($("#txtImagePostionX").val() != "") {
            var posXValue = parseFloat($("#txtImagePostionX").val());
            changePositioX(posXValue);
        }
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

    $("#chkImageIsDisplayOnPDF").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeShowImageOnPDF(true);
        }
        else {
            changeShowImageOnPDF(false);
        }
    });


    $("#rdtextDonothing").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeOnexceedTexBlock("Do Nothing");
            $("#txttextTrscking").val(1);
            $("#txttextTrscking").prop('disabled', true);
            $("#" + selectedObjectID + " .labelText").css("letter-spacing", '0px');
            $("#txtDefaultContent").trigger('keyup')
        }
    });

    $("#rdtextSideWays").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeOnexceedTexBlock("Expand side");
            $("#txttextTrscking").val(1);
            $("#txttextTrscking").prop('disabled', true);
            $("#" + selectedObjectID + " .labelText").css("letter-spacing", '0px');
            $("#txtDefaultContent").trigger('keyup')
        }
    });

    $("#rdtextShrink").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeOnexceedTexBlock("Shrink");
            $("#txttextTrscking").val(1);
            $("#txttextTrscking").prop('disabled', true);
            $("#" + selectedObjectID + " .labelText").css("letter-spacing", '0px');
            $("#txtDefaultContent").trigger('keyup')
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
        if (parseInt(Text) == 'NaN') {
            $("#txttextTrscking").val(1);
            Text = 1;
        }
        if (Text == "") {
            Text = 1;
        }
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
        $("#chkImageFromDropDown").prop('checked', false);
        $("#chkImageFromDropDown").trigger("change");
        loadFolderAndFilesBycategory("fromlink", 0);
    });

    $("#chkImageFromDropDown").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            $("#drpImageFrom").prop('disabled', false);
        }
        else {
            $("#drpImageFrom").prop('disabled', true);
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
            Control.DefaultImageFrom = "None";
            $("#drpImageFrom").val("None")
        }
    });

    $("#ChkAllowUserEdit").unbind("change").bind("change", function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if ($(this).prop('checked') == true) {
            Control.AllowImageEdit = true;
        } else {
            Control.AllowImageEdit = false;
        }
    });

    $("#drpImageFrom").unbind('change').bind('change', function () {

        $("#chkImagefromHardDrive").prop('checked', true);
        $("#chkImageFromGallery").prop('checked', false);
        $("#chkImageFromGallery").trigger("change");
        $("#chkImagefromHardDrive").trigger("change");
        ClearDefaultImagesforSelectedControl();
        showImageFromContactDeptartment($(this).val());
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

            var ImgLocation = $("#drpImageLocation").val();
            changeImageLocation("TL");
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
            Control.ImageLocation = ImgLocation;

            changeExeedWidth("S");
        }
    });

    $("#rdoImageDoNothing").click(function () {
        if ($(this).prop('checked') == true) {
            $("#ChkCropfromtop").prop('disabled', true);
            $("#ChkCropfromtop").prop('checked', false);

            var ImgLocation = $("#drpImageLocation").val();
            changeImageLocation("TL");
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
            Control.ImageLocation = ImgLocation;

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

    $("#onexeedingpara").unbind('click').bind('click', function () {
        var rotateAngle = getRotationDegrees($("#onexeedingpara img"));
        if (rotateAngle == 0) {
            rotateAngle = 180;
        }
        else {
            rotateAngle = 0;
        }
        $("#onexeedingpara img").css({
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

    $("#chkImageQuality").click(function () {
        ChangeImageQuality($(this).prop('checked'));
        $("#DPI_Panel").slideToggle();
    });

    $("#txtDPI").unbind('keyup').bind('keyup', function () {
        changeMinDPI($(this).val());
    });
}

/*To Rotate Selected Control*/
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


    $("#txtRotate").val(Control.RotateAngle);
    getPosition();
}

/*To Change Line Spacing*/
function changeLineSpacing(Space) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (Control.Type == "Paragraph") {
        if (Space == "" || Space == 0) {
            $("#" + Control.ObjectID + " pre").css('line-height', "100%");
            Control.ParaLineSpace = 0;
            $("#txtLineSpacing").val(0);
            $("#" + Control.ObjectID + " pre").css('margin-top', "0px");
            $("#" + Control.ObjectID + " pre").css('margin-bottom', "0px");
        }
        else {
            var ActualLineSpace = Control.ParaLineSpace;
            var ActualHeight = $("#" + Control.ObjectID).css('height');
            $("#" + Control.ObjectID + " pre").css('line-height', (parseFloat(Space * ptConvertionConstant) * mmConvertionConstant) + "pt");
            Control.ParaLineSpace = parseFloat(Space);

            if (Control.ExceedHeight == "Do Nothing") {
                if (parseFloat($("#" + Control.ObjectID + " pre").innerHeight()) > parseFloat($("#" + Control.ObjectID).innerHeight())) {
                    $("#txtLineSpacing").val(Control.ParaLineSpace);
                    // changeLineSpacing(Control.ParaLineSpace);commented By shahbaz
                }

                //Added By shahbaz for paragraph Line spacing if enter value more than control height
                if (parseFloat($("#" + Control.ObjectID + " pre").innerHeight()) > parseFloat($("#" + Control.ObjectID).innerHeight())) {
                    $("#savemsg").html("Value is more then the object height.");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("#txtParaDefaultContent").val(Control.DefaultContent)
                    $("#" + Control.ObjectID).css('height', parseFloat(ActualHeight));
                    $("#" + Control.ObjectID + " pre").css('line-height', '100%');
                    $("#txtLineSpacing").val(0);
                    Control.ParaLineSpace = 0;
                    Control.Height = parseFloat(parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant).toFixed(4);
                    $("#txtMaxHeight").val(parseFloat(Control.Height).toFixed(4))

                    $("#" + Control.ObjectID + " pre").css('margin-top', "0pt");
                    $("#" + Control.ObjectID + " pre").css('margin-bottom', "0pt");
                } else {
                    lnHgt = (parseFloat(Space * ptConvertionConstant) * mmConvertionConstant - (Control.FontSize * ptConvertionConstant)) / 2;
                    $("#" + Control.ObjectID + " pre").css('margin-top', -(lnHgt) + "pt");
                }
            }
            else if (Control.ExceedHeight == "Expand Height") {
                if (parseFloat($("#" + Control.ObjectID + " pre").innerHeight()) > parseFloat($("#" + Control.ObjectID).innerHeight())) {
                    $("#" + Control.ObjectID).css('height', parseFloat($("#" + Control.ObjectID + " pre").innerHeight()) + 2 + 'px');
                    Control.Height = parseFloat(parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant).toFixed(4);
                    $("#txtMaxHeight").val(parseFloat(Control.Height).toFixed(4));
                    //fixPostionOfControll(Control, Control.OffsetLeft - CropMarkWidth, Control.OffsetTop - CropMarkHeight);//Commented By Shahbaz
                    getPosition();//Added By shahbaz
                }

                //Added By shahbaz  for paragraph Line spacing if enter value more than canvas height
                if ($("#" + Control.ObjectID).height() > textCanvasHeight - ($("#" + Control.ObjectID).position().top / mmConvertionConstant)) {
                    $("#savemsg").html("Value is more then the Canvas height.");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();

                    $("#" + Control.ObjectID).css('height', parseFloat(ActualHeight));
                    $("#" + Control.ObjectID + " pre").css('line-height', '100%');
                    $("#txtLineSpacing").val(0);
                    Control.ParaLineSpace = 0;
                    Control.Height = parseFloat(parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant).toFixed(4);
                    $("#txtMaxHeight").val(parseFloat(Control.Height).toFixed(4));


                    $("#" + Control.ObjectID + " pre").css('margin-top', "0pt");
                    $("#" + Control.ObjectID + " pre").css('margin-bottom', "0pt");
                }
                else {
                    lnHgt = (parseFloat(Space * ptConvertionConstant) * mmConvertionConstant - (Control.FontSize * ptConvertionConstant)) / 2;
                    $("#" + Control.ObjectID + " pre").css('margin-top', -(lnHgt) + "pt");
                }
            }

        }
    }
}

/*To Change position-x value for controls*/
function changePositioX(posXValue) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    previousPosX = Control.PositionX

    //fixPostionOfControll(Control.ObjectID, parseFloat(posXValue), Control.PositionY, Control.TextAlign);
    ////Added if control left position croses canvas width 
    //if (Control.PositionX * mmConvertionConstant + Control.Width * mmConvertionConstant > textCanvasWidth) {
    //    posXValue = previousPosX;
    //    fixPostionOfControll(Control.ObjectID, parseFloat(posXValue), Control.PositionY, Control.TextAlign);
    //}


    //Added if control  position crosses canvas width 
    if (Control.TextAlign.toLowerCase() == "left") {
        if (posXValue * mmConvertionConstant + Control.Width * mmConvertionConstant <= textCanvasWidth) {
            fixPostionOfControll(Control.ObjectID, parseFloat(posXValue), Control.PositionY, Control.TextAlign);
        } else {
            fixPostionOfControll(Control.ObjectID, parseFloat(previousPosX), Control.PositionY, Control.TextAlign);
            $("#txtPostionX").val(parseFloat(previousPosX).toFixed(4));
            $("#savemsg").html("Coordinate is greater than measurement of the product");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }
    }
    else if (Control.TextAlign.toLowerCase() == "right") {
        if (posXValue <= textCanvasWidth / mmConvertionConstant) {
            var left = posXValue * mmConvertionConstant - Control.Width * mmConvertionConstant;

            if (left <= 0) {
                if (posXValue < Control.Width) {
                    pos = posXValue - Control.Width
                    posXValue = Control.Width - pos;
                }
                else
                    posXValue = textCanvasWidth / mmConvertionConstant - posXValue;
            }

            fixPostionOfControll(Control.ObjectID, parseFloat(posXValue), Control.PositionY, Control.TextAlign);
        }
        else {
            fixPostionOfControll(Control.ObjectID, parseFloat(previousPosX), Control.PositionY, Control.TextAlign);
            $("#txtPostionX").val(parseFloat(previousPosX).toFixed(4));
            $("#savemsg").html("Coordinate is greater than measurement of the product");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }
    }
    else if (Control.TextAlign.toLowerCase() == "center") {
        if (posXValue <= textCanvasWidth / mmConvertionConstant) {
            var left = posXValue * mmConvertionConstant - Control.Width * mmConvertionConstant / 2;
            if (left <= 0)
                posXValue = Control.Width - posXValue;
            fixPostionOfControll(Control.ObjectID, parseFloat(posXValue), Control.PositionY, Control.TextAlign);
        }
        else {
            fixPostionOfControll(Control.ObjectID, parseFloat(previousPosX), Control.PositionY, Control.TextAlign);
            $("#txtPostionX").val(parseFloat(previousPosX).toFixed(4));
            $("#savemsg").html("Coordinate is greater than measurement of the product");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }
    } else {

        if (posXValue * mmConvertionConstant + Control.Width * mmConvertionConstant <= textCanvasWidth) {
            fixPostionOfControll(Control.ObjectID, parseFloat(posXValue), Control.PositionY, Control.TextAlign);
        } else {
            fixPostionOfControll(Control.ObjectID, parseFloat(previousPosX), Control.PositionY, Control.TextAlign);
            $("#txtPostionX").val(parseFloat(previousPosX).toFixed(4));
            $("#savemsg").html("Coordinate is greater than measurement of the product");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }
    }
}

/*To Change position-y value for controls*/
function changePositioY(posYValue) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    previousPosY = Control.PositionY
    fixPostionOfControll(Control.ObjectID, Control.PositionX, parseFloat(posYValue), Control.TextAlign);

    //Added if control top position croses canvas height 
    if (Control.PositionY * mmConvertionConstant + Control.Height * mmConvertionConstant > textCanvasHeight) {
        posYValue = previousPosY;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, parseFloat(posYValue), Control.TextAlign);
    }
}

/*To Change Max width value for controls*/
function changeMaxWidth(textWidth) {

    var Control;

    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    var PreviousWidth = Control.Width;
    if (textWidth == "")
        textWidth = Control.Width

    if (Control.Type == "Image") {

        if ((textWidth - 1) * mmConvertionConstant > textCanvasWidth) {
            $("#Message").dialog("open");
            $("#msg").html("The size of image box can't be larger than the Product. <br/>Pleaase check control width and height to ensure they dont't exceed those of product.");
            msgBoxDesign();
            $("#txtMaxImageWidth").val((Control.Width));
            return;
        }

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

        if (textWidth == "")
            textWidth = Control.Width

        if (Control.TextAlign.toLowerCase() == "left") {
            if (textWidth * mmConvertionConstant > textCanvasWidth) {
                $("#savemsg").html("Field width is greater than product width");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
                $("#txtMaxWidth").val(PreviousWidth);
                return;
            }
            $("#" + Control.ObjectID).css({ 'width': (textWidth * mmConvertionConstant) + "px" });
        }
        else if (Control.TextAlign.toLowerCase() == "center") {
            if (textWidth > textCanvasWidth / mmConvertionConstant) {
                $("#savemsg").html("Field width is greater than product width");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
                $("#txtMaxWidth").val(PreviousWidth);
                return;
            }
            $("#" + Control.ObjectID).css("text-align", 'left');
            $("#" + Control.ObjectID).css({ 'width': (textWidth * mmConvertionConstant) + "px" });
            //$("#" + Control.ObjectID).css("text-align", 'center');
        }
        else if (Control.TextAlign.toLowerCase() == "right") {
            if (textWidth > textCanvasWidth / mmConvertionConstant) {
                $("#savemsg").html("Field width is greater than product width");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
                $("#txtMaxWidth").val(PreviousWidth);
                return;
            }
            $("#" + Control.ObjectID).css("text-align", 'left');
            $("#" + Control.ObjectID).css({ 'width': (textWidth * mmConvertionConstant) + "px" });
            $("#" + Control.ObjectID).css("text-align", 'right');
        }


        //$("#" + Control.ObjectID).css('width', textWidth * mmConvertionConstant + "px");

        //if ($("#" + Control.ObjectID).position().left < 0) {
        //    $("#savemsg").html("Field width is greater than product width");
        //    $("#SaveMessage").dialog("open");
        //    // $("#msg").html("Field width is greater than product width");
        //    $("#" + Control.ObjectID).css('width', PreviousWidth * mmConvertionConstant + "px");
        //    Control.Width = PreviousWidth
        //    msgBoxDesign();
        //    $("#txtMaxWidth").val(PreviousWidth);
        //    return;
        //}

        Control.Width = textWidth;
        Control.MaxWidth = textWidth;
        //$("#" + Control.ObjectID).css({ 'width': (textWidth * mmConvertionConstant) + "px" });
        //fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        alignsingleLineText(Control.ObjectID);
    }

}

/*To Change Max height value for controls*/
function changeMaxHeight(textHeight) {
    var Control;

    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (textHeight == "")
        textHeight = Control.Height


    if (Control.Type == "Image") {

        if (textHeight * mmConvertionConstant > textCanvasHeight) {
            $("#Message").dialog("open");
            $("#msg").html("The size of image box can't be larger than the Product. <br/>Pleaase check contol width and height to ensure they dont't exceed those of product.");
            msgBoxDesign();
            $("#txtMaxImageHeight").val((Control.Height));
            return;
        }

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

        if (textHeight * mmConvertionConstant > textCanvasHeight) {
            $("#txtMaxHeight").val((Control.Height));
            return;
        }

        Control.MaxHeight = textHeight;
        Control.Height = textHeight;
        $("#" + Control.ObjectID).css({ 'height': (textHeight * mmConvertionConstant) + "px", 'line-height': (textHeight * mmConvertionConstant) - 2 + "px" });
        var posXValue = null, posYValue = null;
        posXValue = parseFloat($("#txtPostionX").val());
        posYValue = parseFloat($("#txtPostionY").val());

        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }

}

/*To Change Lock position status*/
function changeLockPosition(Status) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.Lock = Status;
}


/*To SHow Image on PDF*/
function changeShowImageOnPDF(Status) {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.isDisplayonPDf = Status;


}

/*To Change On exceed width for textblock*/
function changeOnexceedTexBlock(onexceed) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    if (Control.ExceedWidth == "Shrink" && onexceed != "Shrink") {
        Control.FontSize = Control.OriginalFontSize;
        applyFontSizeToSelectedText();
    }
    Control.ExceedWidth = onexceed;
}

/*To Change Max shrink value for controls*/
function changeMaxShrinkTexBlock(Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.MaxShrink = parseInt(Text) / 100;
}

/*To Change hard Drive Image Status For Images*/
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

/*To Change Gallery Image Status For Images*/
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

/**/
function showImageFromContactDeptartment(location) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.DefaultImageFrom = location;
    Control.IsFromBackEnd = true;
}

/*To Change Image Location within the control*/
function changeImageLocation(loaction) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.ImageLocation = loaction;
    alignsingleImage(Control.ObjectID);
}

/*To Change On exceed width for Images*/
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

/*Set image control as background Image*/
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
    $("#" + Control.ObjectID).draggable({ disabled: true });
    $("#" + Control.ObjectID).resizable({ disabled: true });

    $("#txtMaxImageHeight").prop({ 'disabled': true });
    $("#txtMaxImageWidth").prop({ 'disabled': true });
}

/*Remove image control as background Image*/
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
    $("#" + Control.ObjectID).draggable("enable");
    $("#" + Control.ObjectID).resizable("enable");
}

/*Remove image Events*/
function RemoveImageEvents() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    $("#" + Control.ObjectID).css({ 'z-index': "-1" });
}

/*To Change On exceed height for Images and para*/
function changeExceedHeight(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.ExceedHeight = value;

    //Added By shahbaz for Expand Height Issue (Expanding Upward)
    if (Control.ExceedHeight == "Expand Height") {
        if (Control.RotateAngle > 0) {
            var ActualHeight = getActaulHeightOfRotatedControl($("#" + Control.ObjectID), Control.RotateAngle)

            if (Control.RotateAngle < 135) {
                ActualHeight = ActualHeight[1]
                $("#" + Control.ObjectID).css('top', ($("#" + Control.ObjectID).position().top / zoomvalue()) + (ActualHeight - Control.MaxHeight * mmConvertionConstant));
            }
            else if (Control.RotateAngle <= 180) {
                ActualHeight = ActualHeight[1] - Control.MaxHeight * mmConvertionConstant

                if (Control.RotateAngle == 180)
                    ActualHeight = -Control.MaxHeight * mmConvertionConstant
                $("#" + Control.ObjectID).css('top', ($("#" + Control.ObjectID).position().top / zoomvalue()) + ActualHeight);
            }
            else if (Control.RotateAngle <= 270) {
                ActualHeight = ActualHeight[1] - Control.MaxHeight * mmConvertionConstant
                $("#" + Control.ObjectID).css('top', ($("#" + Control.ObjectID).position().top / zoomvalue()) - Control.MaxHeight * mmConvertionConstant);
            }
            else if (Control.RotateAngle > 270 && Control.RotateAngle <= 330)
                ActualHeight = Control.MaxHeight * mmConvertionConstant - ActualHeight[0];

        } else {
            $("#" + Control.ObjectID).css('top', $("#" + Control.ObjectID).position().top / zoomvalue());
        }
    }

}

/*To change Is Crop From top for Images*/
function IsCropFromTopImage(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    Control.IsCropFromTop = value;
    //CreateProportionalImage();

    if (Control.EditedImageName != "")
        FitAutoCroppedImageToControl(Control.EditedImageName, "true");
    else
        FitAutoCroppedImageToControl(Control.OrignalImageName, "false");
}


function FitAutoCroppedImageToControl(fileName, isedited) {
    var width;
    var height;
    var objectid = selectedObjectID;
    var exxceeimage = "";

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    width = parseInt(Control.Width * mmConvertionConstant);
    height = parseInt(Control.Height * mmConvertionConstant);
    exxceeimage = Control.ExceedImage;
    height = $("#" + Control.ObjectID).innerHeight();
    width = $("#" + Control.ObjectID).innerWidth();
    var tmpImg = new Image();
    tmpImg.src = BackgroundImagesPath + fileName;


    $(tmpImg).on('load', function () {

        var FitImageToContoll = {};
        FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
        FitImageToContoll.type = "POST";
        FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: objectid, isEdited: isedited, ImageUploadPath: ImageUploadPath, CompanyID: CompanyID, _isCropFromTop: Control.IsCropFromTop });
        FitImageToContoll.dataType = "json";
        FitImageToContoll.processData = false;
        FitImageToContoll.contentType = "application/json; charset=utf-8";
        FitImageToContoll.success = function (ImageName) {
            var arry = ImageName.d.split('~');
            var exceedimage = "";

            if (Control.IsCropFromTop)
                Control.ImgUrl = arry[0];
            else
                Control.ImgUrl = fileName;
            fileName = Control.ImgUrl
            Control.IsFromBackEnd = true;

            Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
            Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);


            if (Control.BackgroundImage != "") {
                $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                Control.BackgroundImage = fileName;
            }
            else {
                $("#" + Control.ObjectID + " img").css({ 'width': Control.MaxWidth * mmConvertionConstant + 'px', 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'position': 'absolute' });

                //Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight() / mmConvertionConstant);
                //Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth() / mmConvertionConstant);
            }
            //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);
            $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + fileName);
            $(".loading_new").hide();
            Edited = 'false';
            alignsingleImage(Control.ObjectID);
        };
        $.ajax(FitImageToContoll);
    });

}

/*To Create propotional image for canvas*/
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

    height = $("#" + Control.ObjectID).innerHeight();
    width = $("#" + Control.ObjectID).innerWidth();
    var isEdited = "false";
    if (Control.EditedImageName != "") {
        fileName = Control.EditedImageName;
    }
    else
        fileName = Control.OrignalImageName;
    //if (Control.IsImageQuality) {
    //    $.ajax({
    //        url: WebMethodsPath + "checkImageForDPI",
    //        type: "POST",
    //        data: JSON.stringify({ OriginalImageName: fileName, isEdited: "false", ImageUploadPath: ImageUploadPath, CompanyID: CompanyID, minDPI: Control.MinDPI }),
    //        dataType: "json",
    //        processData: false,
    //        contentType: "application/json; charset=utf-8",
    //        success: function (DPIResult) {
    //            if (DPIResult.d == "success") {
    //                LoadImage();
    //            }
    //            else {
    //                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
    //                $("#SaveMessage").dialog("open");
    //                msgBoxDesign();
    //                $("div[aria-describedby=SaveMessage]").css('z-index', '111');
    //                $(".loadingNewMask").show();
    //            }
    //        }
    //    });
    //}
    //else {
    //    LoadImage();
    //}
    //function LoadImage() {
    var FitImageToContoll = {};
    FitImageToContoll.url = WebMethodsPath + "fitTheImageTocontroll";
    FitImageToContoll.type = "POST";
    FitImageToContoll.data = JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: objectid, isEdited: isEdited, ImageUploadPath: ImageUploadPath, CompanyID: CompanyID, _isCropFromTop: Control.IsCropFromTop });
    FitImageToContoll.dataType = "json";
    FitImageToContoll.processData = false;
    FitImageToContoll.contentType = "application/json; charset=utf-8";
    FitImageToContoll.success = function (ImageName) {
        var arry = ImageName.d.split('~');
        var exceedimage = "";

        ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

        //Control.ImgUrl = arry[0];
        Control.ImgUrl = fileName;

        if (Control.EditedImageName != "") {
            Control.OrignalImageName = Control.OrignalImageName;
        } else {
            Control.OrignalImageName = arry[2];
        }
        Control.IsFromBackEnd = true;
        Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
        Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);
        exceedimage = Control.ExceedImage;

        if (Control.IsCropFromTop) {
            Control.ImgUrl = arry[0];
            //Control.OrignalImageName = arry[2];
            fileName = arry[0];
        }

        if (exceedimage == "P") {
            $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });
            //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);
            $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + fileName);
            //Control.MaxHeight = parseFloat($("#" + selectedObjectID + " img").innerHeight()) / mmConvertionConstant;
            // Control.MaxWidth = parseFloat($("#" + selectedObjectID + " img").innerWidth()) / mmConvertionConstant;
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
            var imageanme = fileName.split('-');
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
    //}

}

/*To Resize Para*/
function resizeTextPara() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var width = parseFloat($("#" + Control.ObjectID).outerWidth()) / mmConvertionConstant;
    var height = parseFloat($("#" + Control.ObjectID).outerHeight()) / mmConvertionConstant;

    //Added By shahabz for M in Width of Control if Resize
    //if (Control.Type == "Paragraph")
    //    $("#" + Control.ObjectID).css({ "min-width": '30px', 'min-height': '15px' })
    //else
    //    $("#" + Control.ObjectID).css({ "min-width": '30px' })

    Control.Height = parseFloat(height).toFixed(4);
    Control.Width = parseFloat(width).toFixed(4);
    Control.MaxHeight = parseFloat(height).toFixed(4);
    Control.MaxWidth = parseFloat(width).toFixed(4);
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

/*To Check For Image Existance*/
function checkforImage(name) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (Control.ImgUrl != "noimage.png" && Control.ImgUrl != "noimage.jpg") {
        $("#" + Control.ObjectID + " img").css({ 'width': 'auto', 'height': 'auto' });
        $("#" + Control.ObjectID).css({ 'width': parseFloat($("#" + Control.ObjectID + " img").innerWidth()) + 'px', 'height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px', 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
        Control.Height = parseFloat($("#" + Control.ObjectID).innerHeight()) / mmConvertionConstant;
        Control.Width = parseFloat($("#" + Control.ObjectID).innerWidth()) / mmConvertionConstant;
        Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
        Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.Align);

    }

}

/*To Check For File Existance*/
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

/**********************************
Load Gallery (Craeted By: Infomaze)
***********************************/
/*Load Files and Folders for the image gallery*/
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

/*Open Gallery Which is loaded*/
function openGallery(FilesAndFolders, CategoryID) {
    debugger;
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

/*To Craete Files and folders Stucture in Gallery*/
function createFolderStructure(FolderAndFiles, catid) {

    var thumnailHtml = "";
    var editcategory = false;
    $("#thumNail").empty();
    $(".loading_gallery").hide();
    if (FolderAndFiles.ImageCategories.length == 0 && FolderAndFiles.ImageGallery.length == 0) {
        thumnailHtml += "<span style='font-family:verdana;font-size:11px;'>There are no images in this gallery</span>";
        $("#btnSelectAll").hide();
        $("#btnUnSelectAll").hide();
        $("#btnDeletetAll").hide();
        $("#btnSaveImage").hide();
        $("#btnSaveImage").after("<span class='helper'>&nbsp;</span>");
    }
    else {
        $("#btnSelectAll").show();
        $("#btnUnSelectAll").hide();
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

                if (AssignedFilesAndFolders[k].Type == "f" && AssignedFilesAndFolders[k].TypeID == FolderAndFiles.ImageGallery[i].ImageID && AssignedFilesAndFolders[k].IsDefault) {
                    thumnailHtml += " checked='checked' ";
                }

                if (AssignedFilesAndFolders[k].Type == "f" && AssignedFilesAndFolders[k].TypeID == FolderAndFiles.ImageGallery[i].ImageID && AssignedFilesAndFolders[k].ObjectID == selectedObjectID) {
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

    //Added By shahbaz for clear default Image Checked in Image gallery
    var AtleastOneImageChecked = false;
    $(".SetAsDefault").each(function (i, obj) {
        if ($(obj).prop('checked')) {
            AtleastOneImageChecked = true;
        }
    })
    if (AtleastOneImageChecked)
        $(".btnClearDefault").show();
    else
        $(".btnClearDefault").hide();

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


    $(".SetAsDefault").unbind('click').click(function () {
        if ($(this).prop('checked')) {
            var id = $(this).attr('id').split('_')[1];
            var SetAsdefaultID = $(this).attr('id');
            var zoom = parseInt(parseFloat(zoomvalue()) * 100);
            var width;
            var height, fileName, isPdf = false;
            var objectid = selectedObjectID;

            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


            width = parseInt(Control.Width * mmConvertionConstant);
            height = parseInt(Control.Height * mmConvertionConstant);

            //height = $("#" + Control.ObjectID).outerHeight();
            //width = $("#" + Control.ObjectID).outerWidth();

            height = $("#" + Control.ObjectID).innerHeight() - 1;
            width = $("#" + Control.ObjectID).innerWidth();
            for (var k = 0; k < FolderAndFiles.ImageGallery.length; k++) {
                if (FolderAndFiles.ImageGallery[k].ImageID == parseInt(id)) {
                    fileName = FolderAndFiles.ImageGallery[k].FileName;
                    isPdf = FolderAndFiles.ImageGallery[k].IsPdf;
                }
            }
            var exxceeimage = "";
            exxceeimage = Control.ExceedImage;
            Control.DefaultImageFrom = "None";
            Control.EditedImageName = "";
            Control.UsedImageID = parseInt(id);
            $(".FileAssginChk").each(function () {
                $(this).prop('checked', false)
            });

            $("#chkFileAssgin_" + id).prop('checked', true);
            $(".btnClearDefault").show();
            //if (Control.IsImageQuality) {
            //    $.ajax({
            //        url: WebMethodsPath + "checkImageForDPI",
            //        type: "POST",
            //        data: JSON.stringify({ OriginalImageName: fileName, isEdited: "false", ImageUploadPath: ImageUploadPath, CompanyID: CompanyID, minDPI: Control.MinDPI }),
            //        dataType: "json",
            //        processData: false,
            //        contentType: "application/json; charset=utf-8",
            //        success: function (DPIResult) {
            //            if (DPIResult.d == "success") {
            //                LoadImage();
            //            }
            //            else {
            //                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
            //                $("#SaveMessage").dialog("open");
            //                msgBoxDesign();
            //                $("div[aria-describedby=SaveMessage]").css('z-index', '111');
            //                $(".loadingNewMask").show();
            //                $("#" + SetAsdefaultID).prop('checked', false);
            //            }
            //        }
            //    });
            //}
            //else {
            //    LoadImage();
            //}

            //function LoadImage() {           

            if (exxceeimage == "P") {
                var tmpImg = new Image();

                if (fileName == "noimage.png" || fileName == "noimage.jpg")
                    tmpImg.src = SiteImages + fileName;
                else
                    //tmpImg.src = BackgroundImagesPath + fileName;
                    tmpImg.src = SiteImages + "noimage.jpg";
                $(tmpImg).on('load', function () {

                    $.ajax({
                        url: WebMethodsPath + "fitTheImageTocontroll",
                        type: "POST",
                        data: JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "false", ImageUploadPath: ImageUploadPath, CompanyID: CompanyID, _isCropFromTop: Control.IsCropFromTop }),
                        dataType: "json",
                        processData: false,
                        contentType: "application/json; charset=utf-8",
                        success: function (ImageName) {

                            var arry = ImageName.d.split('~');


                            var exceedimage = "";
                            //var Control;
                            ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

                            // Control.ImgUrl = arry[0];
                            Control.ImgUrl = fileName;
                            Control.OrignalImageName = arry[2];
                            Control.IsFromBackEnd = true;
                            Control.IsFromPdf = isPdf;
                            Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                            Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);

                            if (Control.IsCropFromTop) {
                                Control.ImgUrl = arry[0];
                                Control.OrignalImageName = arry[2];
                                fileName = arry[0];
                            }


                            if (Control.BackgroundImage != "") {
                                $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                                Control.BackgroundImage = fileName;
                            }
                            else {
                                $("#" + Control.ObjectID + " img").css({ 'width': Control.MaxWidth * mmConvertionConstant + 'px', 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'position': 'absolute' });

                                //Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight() / mmConvertionConstant);
                                // Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth() / mmConvertionConstant);
                            }

                            //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);
                            $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + fileName);
                            alignsingleImage(Control.ObjectID);
                        }
                    });
                })
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
                            Control.IsFromPdf = isPdf;

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
                            Control.IsFromPdf = isPdf;
                            var tmpImg = new Image();
                            tmpImg.src = BackgroundImagesPath + ImageName;
                            $(tmpImg).on('load', function () {
                                var orgWidth = tmpImg.width;
                                var orgHeight = tmpImg.height;

                                //var orgWidth = Control.MaxWidth * mmConvertionConstant;
                                //var orgHeight = Control.MaxHeight * mmConvertionConstant;

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

            //for gallery assignment 
            $.ajax({
                url: ServicePath + "Insert_ImageGalleryAssignment_Onclick",
                type: "POST",
                data: JSON.stringify({ objectid: selectedObjectID, companyid: CompanyID, templateid: TemplateID, userid: UserID, type: "f", typeid: id, isdefault: true, _key: DBKey }),
                dataType: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function () {

                }
            });
        }

        //}
    });

    //Added By shahbaz for Clear Defalut Image from Gallery
    $(".btnClearDefault").unbind('click').bind('click', function () {
        ClearDefaultImagesforSelectedControl();
    })

    $(".FolderAssginChk").unbind('click').bind('click', function () {
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

    $(".FileAssginChk").unbind('click').bind('click', function () {
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
                data: JSON.stringify({ compnayid: CompanyID, templateid: TemplateID, objectid: selectedObjectID, type: "f", typeid: id, _key: DBKey }),
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
            $(".QuickAdjustloadingNewMask").css('z-index', '112').show();
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
                var file = $('input#UpadeInputfile').prop("files");
                var ext = file[0].name.split('.')[1].toLowerCase();

                if (ext == "pdf" || ext == "png" || ext == "jpeg" || ext == "jpg") {

                    $("#filenamespan").html(file[0].name);

                    var GUID = Guid().substr(0, 5);
                    filelistSingle += GUID + "~" + file[0].name + "~" + parseInt(file[0].size);

                }
                else {
                    $('#UpadeInputfile').val("");
                }
            });
            $(".btnUpdateImage").unbind('click').bind('click', function () {
                if (filelistSingle == "") {

                    $("#error").html("Please select file to upload.");
                    var Zindex = parseInt($("div[aria-describedby=UploadImage]").css('z-index'));
                    $("#ErrorMsg").dialog("open");
                    $(".ErrorMsgloadingNew").css("z-index", Zindex + 1).show();
                    $(".ErrorMsgloadingNew").show();
                    msgBoxDesign();
                    return false;
                }
                else {
                    $(".btnUpdateImageloading").css('display', 'inline-block');
                    $(".btnUpdateImage").hide();
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
                                    $(".btnUpdateImageloading").hide();
                                    $(".btnUpdateImage").show();
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
                            $(".loading_gallery").show();
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
                                    if (deletecategoryids != "") {
                                        loadcategoryList("");
                                    }
                                }
                            });
                        }
                    }
                    else {
                        if (confirm("Are you sure you want to delete? \r\n This action cannot be undone.")) {
                            $(".loading_gallery").show();
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
            // $(".loadingNewMask").hide();
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

                            $("#error").html("Category name already exists.");
                            var Zindex = parseInt($("div[aria-describedby=EditCategory]").css('z-index'));
                            $("#ErrorMsg").dialog("open");
                            $(".ErrorMsgloadingNew").css("z-index", Zindex + 1).show();
                            $(".ErrorMsgloadingNew").show();
                            //$("#savemsg").html("Category name already exists.");
                            //$("#SaveMessage").dialog("open");
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

/*For Clear Defalut Image from Gallery*/
function ClearDefaultImagesforSelectedControl() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var id = "";
    $(".SetAsDefault").each(function (i, obj) {
        if ($(obj).prop('checked')) {
            id = $(obj)[0].id.toString().split('_')[1];
        }
    });

    if (id.length > 0) {
        $.ajax({
            url: ServicePath + "Insert_ImageGalleryAssignment_Onclick",
            type: "POST",
            data: JSON.stringify({ objectid: selectedObjectID, companyid: CompanyID, templateid: TemplateID, userid: UserID, type: "f", typeid: id, isdefault: false, _key: DBKey }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function () {
                $("#rdSetDefault_" + id).prop('checked', false)
                $("#chkFileAssgin_" + id).prop('checked', false);

                Control.ImgUrl = "noimage.jpg";
                Control.OrignalImageName = "noimage.jpg";
                Control.EditedImageName = "";
                Control.IsFromBackEnd = true;
                Control.UsedImageID = '0';
                Control.IsFromPdf = false;
                $("#" + Control.ObjectID + " img").attr('src', SiteImages + "noimage.jpg");
                //$("#" + Control.ObjectID + " img").css({ 'width': '100%', 'height': '100%' });
                //$("#" + Control.ObjectID + " img").css({ 'line-height': parseFloat($("#" + Control.ObjectID + " img").innerHeight()) + 'px' });
                changeMaxWidth("");
                Control.MaxHeight = parseFloat($("#" + Control.ObjectID + " img").innerHeight()) / mmConvertionConstant;
                Control.MaxWidth = parseFloat($("#" + Control.ObjectID + " img").innerWidth()) / mmConvertionConstant;
                fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.Align);
                alignsingleImage(Control.ObjectID);
            }
        });
    } else {
        Control.ImgUrl = "noimage.jpg";
        Control.OrignalImageName = "noimage.jpg";
        Control.EditedImageName = "";
        Control.IsFromBackEnd = true;
        Control.UsedImageID = '0';
        Control.IsFromPdf = false;
        $("#" + Control.ObjectID + " img").attr('src', SiteImages + "noimage.jpg");
    }
}

/*Get Edit Image details*/
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

/*Bind Image Gallery file upload events*/
var File = [];
function LoadGalleryFileUploadEvents() {
    $("#btnSelectFiles").click(function () {

        //$('#multipleFileUpload').trigger('click');
        $("#multipleFileUpload")[0].click();
    });

    $("#multipleFileUpload").change(function (evt) {

        totalSize = 0;
        var files = $('#multipleFileUpload').prop("files");

        //Adding selected file in  an array
        for (var i = 0; i < files.length; i++) {
            // files[i].newname = files[i].name
            File.push(files[i]);
        }


        //for changing duplicate file name
        //var count = 0;
        //for (var i = 0; i < File.length; i++) {
        //    for (var j = 0; j < File.length; j++) {
        //        if (File[j].name == File[i].name) {
        //            if (count > 0)
        //                File[j].newname = File[i].name.toString().split('.')[0] + count + "." + File[i].name.toString().split('.')[1];
        //            count++;
        //        }
        //    }
        //    count = 0;
        //}

        //var filerdr = new FileReader();
        var names = $.map(File, function (val) { return val.name; });
        var size = $.map(File, function (val) { return val.size; });
        $("#fileList").empty();
        filelist = "";
        for (var i = 0; i < names.length; i++) {
            var sizeInKB = parseFloat(parseInt(size[i]) / 1024).toFixed(2);
            var ext = names[i].split('.')[1].toLowerCase();
            if (ext == "pdf" || ext == "png" || ext == "jpeg" || ext == "jpg") {
                var GUID = Guid().substr(0, 5);
                filelist += GUID + "~" + names[i] + "~" + parseInt(size[i]) + ",";
                $("#fileList").append("<div id='div_" + i + "' class='Filestoupload'><img src='" + SiteImages + "close-gray1.png' width='14px' height='14px' title='Remove the image' class='delefile' id='" + i + ":" + sizeInKB + ":" + names[i] + "' /><span style='float:right;margin-right:10px;'>" + sizeInKB + " KB</span><label class='lblOverflow' title='" + names[i] + "'>" + names[i] + "</label></div>");

                totalSize += parseFloat(sizeInKB);
            }

        }
        filelist = filelist.substr(0, filelist.length - 1);

        if (filelist.length > 0) {
            $("#btnUploadText").html("Add more files");
            $("#btnSelectFiles").css({ 'width': '87px', 'margin-left': '272px' });
        }
        else {
            $("#btnUploadText").html("Browse");
            $("#btnSelectFiles").css({ 'width': '46px', 'margin-left': '315px' });
        }
        changetotalSize(totalSize);
        $(".delefile").unbind('click').bind('click', function () {

            var filelistarry = filelist.split(',');
            var minus = parseFloat($(this).attr('id').split(':')[1]);
            $("#div_" + $(this).attr('id').split(':')[0]).remove();
            totalSize = totalSize - minus;
            changetotalSize(Math.abs(totalSize));

            var deletedFileName = $(this).attr('id').split(':')[2];
            var deleted = false;
            //File.map(function (proj) {
            //    if (proj.name == deletedFileName && deleted == false) {
            //        File.splice(File.indexOf(proj), 1);
            //        deleted = true;
            //    }
            //});


            for (var k = 0; k < File.length; k++) {

                if (File[k].name == deletedFileName && deleted == false) {
                    File.splice(File.indexOf(File[k]), 1);
                    break;
                }
            }


            filelist = "";
            deleted = false;
            for (var j = 0; j < filelistarry.length; j++) {
                if (filelistarry[j].split('~')[1] == $(this).attr('id').split(':')[2] && deleted == false) {
                    deleted = true
                }
                else {
                    filelist += filelistarry[j] + ",";
                }
            }
            filelist = filelist.substr(0, filelist.length - 1);




            if (filelist.length == 0) {
                $("#btnUploadText").html("Browse");
                $("#totalContainer").hide();
                $("#btnSelectFiles").css({ 'width': '46px', 'margin-left': '315px' });
                $("input#multipleFileUpload").val("");
                File = [];
            }
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
                insertCategory.data = JSON.stringify({ companyid: CompanyID, categoryname: $("#txtNewCategoryName").val(), description: "", parentid: $("#drpForCreateCategory").val(), categoryimage: "", createdby: UserID, _key: DBKey });
                insertCategory.dataType = "json";
                insertCategory.processData = false;
                insertCategory.contentType = "application/json; charset=utf-8";
                insertCategory.success = function (categoryID) {
                    var CategoryID = categoryID.d;

                    if (CategoryID == -1) {
                        $("#error").html("Category name already exists.");
                        var Zindex = parseInt($("div[aria-describedby=CreateCategory]").css('z-index'));
                        $(".ErrorMsgloadingNew").css("z-index", Zindex + 1).show();
                        $(".ErrorMsgloadingNew").show();
                        $("#ErrorMsg").dialog("open");
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

            //jQuery.each($('#multipleFileUpload')[0].files, function (i, file) {
            //    form_data.append('file-' + i, file);
            //});

            //jQuery.each(File, function (i, file) {
            //    form_data.append('file-' + i, file);
            //});

            for (var k = 0; k < File.length; k++) {

                form_data.append('file-' + k, File[k]);
            }


            File = [];
            $("input#multipleFileUpload").val("");
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
                            var UploadImageIds = "";
                            var UploadImageCategory = "";
                            var defaultImageID = "";
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
                                ImageDetailsHtml += "style='float:right;border:1px solid #808080;width:100%;height:100%;' /></div></td></tr>";
                                ImageDetailsHtml += "<tr><td style='width:100%;'><div style='float:right;'><input type='radio' name='defaultImage' class='defaultImage' id='def_" + imagelist[i].ImageID + "' title='" + imagelist[i].FileName + "' style='vertical-align:middle;margin-left:0px;' /><label for='def_" + imagelist[i].ImageID + "' style='font-family: Verdana; font-size: 11px;'>Default Image</span></div></td></tr></table></td></tr>";
                                ImageDetailsHtml += "<tr><td style='vertical-align:top;'><span style='font-family: Verdana;  font-size: 11px;padding:0px 5px 0px 5px;'>MetaTag</span></td>";
                                ImageDetailsHtml += "<td style='vertical-align:top;'><input type='text' style='width:200px;height:20px;font-family: Verdana; font-size: 11px;border:1px solid #b2b2b2;padding-left:2px;' id='tag_" + imagelist[i].ImageID + "' class='MetatagTextbox' value='" + imagelist[i].MetaTags + "' /></td></tr>";
                                ImageDetailsHtml += "<tr><td style='vertical-align:top;'><span style='font-family: Verdana;  font-size: 11px;padding:0px 5px 0px 5px;'>Description</span></td>";
                                ImageDetailsHtml += "<td style='vertical-align:top;'><textarea style='width:200px;height:60px;font-family: Verdana; font-size: 11px;border:1px solid #b2b2b2;padding-left:2px;' id='dsc_" + imagelist[i].ImageID + "' class='DescriptionTexarea' >" + imagelist[i].Description + "</textarea></td></tr></table></div>";

                                //Use for remove image if cancel btn click while uploading(shahbaz)
                                UploadImageIds += imagelist[i].ImageID + ",";
                                UploadImageCategory += imagelist[i].CategoryID + ",";

                                $("#btnUploadText").html("Browse");
                                $("#btnSelectFiles").css({ 'width': '46px', 'margin-left': '315px' });

                            }

                            $("#FilePropertiesDiv").html(ImageDetailsHtml);

                            $(".loading_gallery").hide();

                            $(".defaultImage").unbind('click').bind('click', function () {
                                if ($(this).prop('checked')) {
                                    var id = $(this).attr('id').split('_')[1];
                                    defaultImageID = id;
                                    var SetAsdefaultID = $(this).attr('id');

                                    //}
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

                                //if set as default clicked then on saving assign default Image to control(shahbaz)
                                if (defaultImageID != "") {
                                    var id = defaultImageID;
                                    var zoom = parseInt(parseFloat(zoomvalue()) * 100);
                                    var width;
                                    var height, fileName, isPdf = false;
                                    var objectid = selectedObjectID;

                                    var Control;
                                    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


                                    width = parseInt(Control.Width * mmConvertionConstant);
                                    height = parseInt(Control.Height * mmConvertionConstant);

                                    height = $("#" + Control.ObjectID).innerHeight();
                                    width = $("#" + Control.ObjectID).innerWidth();

                                    for (var k = 0; k < imagelist.length; k++) {
                                        if (imagelist[k].ImageID == parseInt(id)) {
                                            fileName = imagelist[k].FileName;
                                            isPdf = imagelist[k].IsPdf;
                                        }
                                    }
                                    var exxceeimage = "";
                                    exxceeimage = Control.ExceedImage;

                                    //if (Control.IsImageQuality) {
                                    //    $.ajax({
                                    //        url: WebMethodsPath + "checkImageForDPI",
                                    //        type: "POST",
                                    //        data: JSON.stringify({ OriginalImageName: fileName, isEdited: "false", ImageUploadPath: ImageUploadPath, CompanyID: CompanyID, minDPI: Control.MinDPI }),
                                    //        dataType: "json",
                                    //        processData: false,
                                    //        contentType: "application/json; charset=utf-8",
                                    //        success: function (DPIResult) {
                                    //            if (DPIResult.d == "success") {
                                    //                LoadImage();
                                    //            }
                                    //            else {
                                    //                $("#savemsg").html("Please use images with DPI greater than " + Control.MinDPI + ".");
                                    //                $("#SaveMessage").dialog("open");
                                    //                msgBoxDesign();
                                    //                $("div[aria-describedby=SaveMessage]").css('z-index', '111');
                                    //                $(".loadingNewMask").show();
                                    //                $("#" + SetAsdefaultID).prop('checked', false);
                                    //            }
                                    //        }
                                    //    });
                                    //}
                                    //else {
                                    //    LoadImage();
                                    //}

                                    //function LoadImage() {

                                    if (exxceeimage == "P") {
                                        $.ajax({
                                            url: WebMethodsPath + "fitTheImageTocontroll",
                                            type: "POST",
                                            data: JSON.stringify({ OriginalImageName: fileName, widthOfControll: width, HeightOfControll: height, zoom: zoom, objcetID: selectedObjectID, isEdited: "false", ImageUploadPath: ImageUploadPath, CompanyID: CompanyID, _isCropFromTop: Control.IsCropFromTop }),
                                            dataType: "json",
                                            processData: false,
                                            contentType: "application/json; charset=utf-8",
                                            success: function (ImageName) {

                                                var arry = ImageName.d.split('~');
                                                $("#chkFileAssgin_" + id).prop('checked', true);
                                                $.ajax({
                                                    url: ServicePath + "Insert_ImageGalleryAssignment_Onclick",
                                                    type: "POST",
                                                    data: JSON.stringify({ objectid: selectedObjectID, companyid: CompanyID, templateid: TemplateID, userid: UserID, type: "f", typeid: id, isdefault: true, _key: DBKey }),
                                                    dataType: "json",
                                                    processData: false,
                                                    contentType: "application/json; charset=utf-8",
                                                    success: function () {
                                                        var exceedimage = "";

                                                        ControllDetails.map(function (proj) { if (proj.ObjectID == arry[1]) Control = proj });

                                                        // Control.ImgUrl = arry[0];
                                                        Control.ImgUrl = fileName;
                                                        Control.OrignalImageName = arry[2];
                                                        Control.IsFromBackEnd = true;
                                                        Control.IsFromPdf = isPdf;
                                                        Control.MaxHeight = parseFloat((parseFloat(arry[3])) / mmConvertionConstant);
                                                        Control.MaxWidth = parseFloat((parseFloat(arry[4])) / mmConvertionConstant);


                                                        if (Control.IsCropFromTop) {
                                                            Control.ImgUrl = arry[0];
                                                            Control.OrignalImageName = arry[2];
                                                            fileName = arry[0];
                                                        }

                                                        if (Control.BackgroundImage != "") {
                                                            $("#" + Control.ObjectID + " img").css({ 'height': '100%', 'width': '100%', 'position': 'absolute' });
                                                            Control.BackgroundImage = fileName;
                                                        }
                                                        else
                                                            $("#" + Control.ObjectID + " img").css({ 'height': Control.MaxHeight * mmConvertionConstant + 'px', 'width': Control.MaxWidth * mmConvertionConstant + 'px' });

                                                        //$("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + arry[0]);
                                                        $("#" + Control.ObjectID + " img").attr('src', BackgroundImagesPath + fileName);

                                                        alignsingleImage(Control.ObjectID);
                                                    }
                                                });

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
                                                    Control.IsFromPdf = isPdf;
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
                                                    Control.IsFromPdf = isPdf;
                                                    var tmpImg = new Image();
                                                    tmpImg.src = BackgroundImagesPath + ImageName;
                                                    $(tmpImg).on('load', function () {

                                                        var orgWidth = tmpImg.width;
                                                        var orgHeight = tmpImg.height;

                                                        //var orgWidth = Control.MaxWidth * mmConvertionConstant;
                                                        //var orgHeight = Control.MaxHeight * mmConvertionConstant;
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

                            $("#btnImageSaveCancel").click(function () {
                                filelist = "";
                                $("#fileList").empty();
                                $("#totalContainer").hide();
                                $("#multipleFileUpload").val("");
                                $("#galleryLink").trigger('click');
                                $("#FilePropertiesDiv").hide();
                                $("#FilePropertiesButtonDiv").hide();
                                $("#fileUploadDiv").show();

                                //For removing image from gallery to be upload
                                //$.ajax({
                                //    //var DeleteMultiple = {};
                                //    url: ServicePath + "DeleteMultipleFilesFolders",
                                //    type: "POST",
                                //    data: JSON.stringify({ categoryids: UploadImageCategory, imageids: UploadImageIds, userid: UserID, companyid: CompanyID, _key: DBKey }),
                                //    dataType: "json",
                                //    processData: false,
                                //    contentType: "application/json; charset=utf-8",
                                //    success: function (result) {
                                //        //loadFolderAndFilesBycategory("", $("#drpSelectCategory").val());
                                //    }
                                //});
                                defaultImageID = "";
                                $("#fileUploadLink").trigger('click');
                                $(".loading_new").hide();
                            });
                        };
                        $.ajax(loadImageList);
                    };
                    $.ajax(getImageList);
                },
                error: function (xhr) {
                    console.log(xhr);
                }
            });
        }

    });
}

/*Bind Category dropdown for edit Image*/
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

/**********************************
Font Panel Events(Craeted By: Infomaze)
***********************************/

/*Bind Font Panel Events*/
function LoadFontPanelEvents() {
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

    $("#rdCenterJustify").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeAlignment("center");
        }
    });

    $("#rdRightJustify").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeAlignment("right");
        }
    });

    $("#rdLeftJustify").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeAlignment("left");
        }
    });

    $("#rdUserInput").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("User Input");
        }
    });

    $("#rdAllUpper").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("All Caps");
        }
    });

    $("#rdFirstLetterCapsDontAllowCaps").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("InitCap");
        }
    });

    $("#rdFirstLetterCapsAllowCaps").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("InitCapAllowCaps");
        }
    });

    $("#rdAllWordFirstCapsDontAllowCaps").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("First Cap");
        }
    });

    $("#rdAllWordFirstCapsAllowCaps").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("FirstCapAllowCaps");
        }
    });

    $("#rdAllLower").unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            changeCapitalize("All Lower");
        }
    });

    $("#chkParagraphJustify").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            changeParagraphJustificationValue("Justify");
            $("#rdLeftJustify").prop("checked", true);
            //$("#rdLeftJustify").trigger("click")
        }
        else {
            changeParagraphJustificationValue("");
            $("#rdLeftJustify").prop("checked", true);
            $("#rdLeftJustify").trigger("click")
        }
    });

    $("#drpDataType").unbind('change').bind('change', function () {

        changeDataType($(this).val());
    });

    $("#justify").unbind('click').bind('click', function () {


        var rotateAngle = getRotationDegrees($("#justify img"));
        if (rotateAngle == 0) {
            rotateAngle = 180;
            $(".toggle").show();
        }
        else {
            rotateAngle = 0;
            $(".toggle").hide();
        }
        $("#justify img").css({
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
        $("#capitilization img").css({
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

        var rotateAngle = getRotationDegrees($("#capitilization img"));
        if (rotateAngle == 0) {
            rotateAngle = 180;
            $(".toggle").show();
        }
        else {
            rotateAngle = 0;
            $(".toggle").hide();
        }
        $("#capitilization img").css({
            '-webkit-transform': 'rotate(' + rotateAngle + 'deg)',
            '-moz-transform': 'rotate(' + rotateAngle + 'deg)',
            '-ms-transform': 'rotate(' + rotateAngle + 'deg)',
            'transform': 'rotate(' + rotateAngle + 'deg)',
            '-webkit-transition': '-webkit-transform 1s',
            '-moz-transition': '-moz-transform 1s',
            ' -ms-transition': '-ms-transform 1s',
            'transition': 'transform 1s'
        });
        $("#justify img").css({
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

}

/*Apply Font To Selected Control*/
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
            $("#" + Control.ObjectID + " pre").css('font-family', uniquefontname);
        }

        Control.FontFamily = fontname;
        Control.ActualFontName = ActualfontName;
        Control.FontID = parseFloat(fontid);
        Control.FontExtension = fontpathName;
        //fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        alignsingleLineText(Control.ObjectID);
    }

}

/*Apply Indent to Selected Control*/
function applyIndentToSelecedText(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
        if (value == 0 || value == "") {
            if ($("#" + Control.ObjectID).hasClass('Text')) {
                $("#" + Control.ObjectID + " .labelText").css('padding-left', "0px");
            }
            else {
                $("#" + Control.ObjectID + " pre").css('padding-left', "0px");
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
                $("#" + Control.ObjectID + " pre").css('padding-left', value * mmConvertionConstant + "px");
                if ((($("#" + Control.ObjectID).outerWidth() - 2) >= (parseFloat($("#" + Control.ObjectID + "  pre").css('padding-left')) + 2))) {
                    Control.Indent = value;
                }
                else {
                    $("#savemsg").html("Value is more then the object width.");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("#" + Control.ObjectID + " pre").css('padding-left', Control.Indent * mmConvertionConstant + "px");
                    $("#txtFontIndent").val(Control.Indent);
                }
            }
        }
    }


}

/*Apply Font Size to Selected Control*/
function applyFontSizeToSelectedText() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if ($("#txtFontSize").val() !== "") {
        Control.FontSize = (parseFloat($("#txtFontSize").val()));
        Control.OriginalFontSize = (parseFloat($("#txtFontSize").val()));
    }

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
        changeDefaultContent(Control.DefaultContent, false, false);//3rd parameter value as false - For Ticket 16079
    }
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
}

/*Change Manual Tracking For Selected Control*/
function changeManualTraking(Property, value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    var labelletterspacing = $("#" + Control.ObjectID + " .label").css('letter-spacing');

    var val, sign;
    var InitailManualTracking = 0;
    if (Property == "Dimention") {
        if (value == "pt") {
            val = Control.ManualTracking * ptConvertionConstant;
            InitailManualTracking = Control.ManualTracking / ptConvertionConstant
        }
        else if (value == "mm") {
            val = Control.ManualTracking * mmConvertionConstant;
            InitailManualTracking = Control.ManualTracking * mmConvertionConstant
        }
    }
    else {
        if (Property == "Text") {
            if (value == '')
                value = 0;
            if (Control.ManualTrackDimension == "pt") {
                val = parseFloat(value) / ptConvertionConstant;
            }
            else if (Control.ManualTrackDimension == "mm") {
                val = parseFloat(value) * mmConvertionConstant;
            }
        }
        else {
            if (Control.ManualTrackDimension == "pt") {
                val = Control.ManualTracking / ptConvertionConstant;
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

    if (val == 0)
        sign = "+";

    if (Control.Type == "TextBlock") {
        $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': sign + val + "px" });
        //$("#" + Control.ObjectID + " .label").css({ 'letter-spacing': labelletterspacing + "px" });
    }
    if (Control.Type == 'Paragraph') {
        if ($("#" + Control.ObjectID + " .paraText").outerWidth() > 0 && $("#" + Control.ObjectID + " .paraText").outerWidth() <= $("#" + Control.ObjectID).outerWidth()) {

            if (Property == "Sign") {
                Control.ManualTrackSign = value;
            }
            if (Property == "Dimention") {
                Control.ManualTrackDimension = value;
            }
            if (Property == "Text") {
                Control.ManualTracking = value;
            }
            $("#" + Control.ObjectID).css({ 'letter-spacing': sign + val + "px" });
            if ($("#" + Control.ObjectID + " .paraText").outerHeight() > $("#" + Control.ObjectID).outerHeight()) {
                $("#savemsg").html("Value is more then the object Height.");
                $("#SaveMessage").dialog("open");
                msgBoxDesign();
                $("#" + Control.ObjectID).css({ 'letter-spacing': sign + InitailManualTracking + "px" });
                if (Control.ManualTrackDimension == "pt")
                    Control.ManualTracking = InitailManualTracking / ptConvertionConstant;
                else
                    Control.ManualTracking = InitailManualTracking / mmConvertionConstant;
                $("#txtManulTracking").val(Control.ManualTracking);
            }
            if (sign == '-')
                if (val / ptConvertionConstant > 8) {
                    $("#savemsg").html("Value is more then the object Width.");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("#" + Control.ObjectID).css({ 'letter-spacing': sign + 0 + "px" });
                    Control.ManualTracking = 0;
                    $("#txtManulTracking").val(Control.ManualTracking);
                }

        } else {
            //alert("exceed")
        }
    }

    if (Control.Type == "TextBlock") {

        //if (($("#" + Control.ObjectID).outerWidth()) >= ($("#" + Control.ObjectID + " .labelText").outerWidth())) { commented by shahbaz
        var labelWidth = $("#" + Control.ObjectID + " .label").innerWidth();
        if (Control.LabelPosition == "customTop") {
            labelWidth = 0;
        }
        if (val < Control.Width && ($("#" + Control.ObjectID + " .labelText").outerWidth()) > 0 && ($("#" + Control.ObjectID + " .labelText").innerWidth() + labelWidth) <= ($("#" + Control.ObjectID).width() + labelWidth)) {
            if (Property == "Sign") {
                Control.ManualTrackSign = value;
            }
            if (Property == "Dimention") {
                Control.ManualTrackDimension = value;
            }
            if (Property == "Text") {
                Control.ManualTracking = value;
            }

            if (sign == '-') {

                if (val / mmConvertionConstant > 2 && Control.ManualTrackDimension == "mm") {
                    $("#savemsg").html("Value is more then the object Width.");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': sign + 0 + "px" });
                    Control.ManualTracking = 0;
                    $("#txtManulTracking").val(Control.ManualTracking);
                }
                if (val / ptConvertionConstant > 8 && Control.ManualTrackDimension == "pt") {
                    $("#savemsg").html("Value is more then the object Width.");
                    $("#SaveMessage").dialog("open");
                    msgBoxDesign();
                    $("#" + Control.ObjectID + " .labelText").css({ 'letter-spacing': sign + 0 + "px" });
                    Control.ManualTracking = 0;
                    $("#txtManulTracking").val(Control.ManualTracking);
                }
            }
        }
        else {
            $("#savemsg").html("Value is more then the object width.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
            var vall;
            if (Control.ManualTrackDimension == "pt") {
                vall = Control.ManualTracking / ptConvertionConstant;
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

/*Change Font Style For Selected Control*/
function changeFontStyle(FontStyleName) {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (FontStyleName != "") {

        var FontStyle;
        FontStyleDetails.map(function (proj) { if (proj.FontStyleName == FontStyleName) FontStyle = proj });

        if (FontStyle != null) {
            Control.FontSyleID = FontStyle.FontID;
            Control.FontStyleName = FontStyle.FontStyleName;
            Control.FontFamily = FontStyle.FontFamily;
            Control.Capitalize = FontStyle.Capitalize;
            Control.DataType = FontStyle.DataType;
            Control.FontSize = FontStyle.FontSize;
            Control.OriginalFontSize = FontStyle.FontSize;
            Control.Indent = FontStyle.Indent;
            Control.ManualTracking = FontStyle.ManualTracking;
            Control.ManualTrackDimension = FontStyle.TrackPoint;
            Control.ManualTrackSign = FontStyle.TrackOffSet;

            var Font;
            FontList.map(function (proj) { if (proj.DisplayFontName == Control.FontFamily) Font = proj });
            if (Font != null) {
                Control.FontID = Font.FontID;
                $("#drpFontID" + Font.FontID).prop('selected', true);
                applyFontToSelectedText($("#drpApplyFont").val());
            }

            $("#txtFontStyle").val(FontStyle.FontStyleName);
            $("#txtFontSize").val(Control.OriginalFontSize);
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
            if (FontStyle.TextAlign == 'Left') {
                if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, FontStyle.TextAlign)) {
                    $(selectedControllID).css('text-align', 'left');
                    Control.TextAlign = "Left";
                    $("#rdLeftJustify").prop('checked', true);
                    $("#btnLeftAlign").addClass('menubuttonSelected');
                    $("#btnCenterAlign").removeClass('menubuttonSelected');
                    $("#btnRightAlign").removeClass('menubuttonSelected');
                }
            }
            else if (FontStyle.TextAlign == 'Center') {
                if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, FontStyle.TextAlign)) {
                    $(selectedControllID).css('text-align', 'center');
                    Control.TextAlign = "Center";
                    $("#rdLeftJustify").prop('checked', true);
                    $("#btnLeftAlign").removeClass('menubuttonSelected');
                    $("#btnCenterAlign").addClass('menubuttonSelected');
                    $("#btnRightAlign").removeClass('menubuttonSelected');
                }
            }
            else if (FontStyle.TextAlign == 'Right') {
                if (fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, FontStyle.TextAlign)) {
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
                $("#rdFirstLetterCapsDontAllowCaps").prop('checked', true);
                changeCapitalize("InitCap");
            }
            else if (Control.Capitalize == "InitCapAllowCaps") {
                $("#rdFirstLetterCapsAllowCaps").prop('checked', true);
                changeCapitalize("InitCapAllowCaps");
            }
            else if (Control.Capitalize == "First Cap") {
                $("#rdAllWordFirstCapsDontAllowCaps").prop('checked', true);
                changeCapitalize("First Cap");
            }
            else if (Control.Capitalize == "FirstCapAllowCaps") {
                $("#rdAllWordFirstCapsAllowCaps").prop('checked', true);
                changeCapitalize("FirstCapAllowCaps");
            }
            else {
                $("#rdAllLower").prop('checked', true);
                changeCapitalize("All Lower");
            }

            applyIndentToSelecedText();
            applyFontSizeToSelectedText();
            changeManualTraking("Sign", $("#drpManualTrackSign").val());
            changeManualTraking("Dimention", $("#drpManualTrackDimension").val());
            changeManualTraking("Text", $("#txtManulTracking").val());
            alignsingleLineText(Control.ObjectID);
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

/*Change Capitlization For Selected Control*/
function changeCapitalize(Capitalize) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Capitalize = Capitalize;
    if ($("#" + Control.ObjectID).hasClass('Text')) {
        if (Control.DefaultContent == Control.FieldName) {
            changeDefaultContent(Control.DefaultContent, false, false);
        }
        else {
            changeDefaultContent($("#txtDefaultContent").val(), true, false);
        }
    }
    else if ($("#" + Control.ObjectID).hasClass('Para')) {

        if (Control.DefaultContent == Control.FieldName) {
            changeDefaultContent(Control.DefaultContent, false, false);
        }
        else {
            changeDefaultContent($("#txtParaDefaultContent").val(), true, false);
        }
    }

}

/*Change Paragraph Justification*/
function changeParagraphJustificationValue(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (value == "Justify") {
        Control.TextAlign = value;
        $("#" + Control.ObjectID + " .paraText").css({ 'text-align': "Justify", 'white-space': 'initial' });
    }
    else {
        Control.TextAlign = "Left";
        $("#" + Control.ObjectID + " .paraText").css({ 'text-align': 'Left' });
    }

}

/*Change Data type For selected control*/
function changeDataType(value) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.DataType = value;
}

/**********************************
Color Panel Events(Craeted By: Infomaze)
***********************************/

/*Bind Color Panel Events*/
function LoadColorPanelEvents() {

    $("#txtC,#txtM,#txtY,#txtK").keyup(function (event) {
        changeColorByInputText();
        //var Control;
        //ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        //var key = window.event ? event.keyCode : event.which;
        //if (event.keyCode == 8 || event.keyCode == 46
        // || event.keyCode == 37 || event.keyCode == 39) {
        //    changeColorByInputText();
        //}
        //else if (key < 48 || key > 57) {
        //    if (event.target.id = "txtC") {
        //        $("#txtC").val(parseFloat(Control.C));
        //    }
        //    if (event.target.id = "txtM") {
        //        $("#txtM").val(parseFloat(Control.M));
        //    }
        //    if (event.target.id = "txtY") {
        //        $("#txtY").val(parseFloat(Control.Y));
        //    }
        //    if (event.target.id = "txtK") {
        //        $("#txtK").val(parseFloat(Control.K));
        //    }
        //}

    });

    //$("#txtC,#txtM,#txtY,#txtK").unbind('change').bind('change', function () {// Commented By shahbaz
    //    changeColorByInputText();
    //});

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

}

/*To Change Font color from RGB to CMYK*/
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

/*To Change Font color from CMYK to RGB*/
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
    $("#colorpicker_" + Control.ObjectID).css('background-color', "rgba(" + r + ", " + g + ", " + b + ")");
}

/*To Cahnge Color By Input Text*/
function changeColorByInputText() {
    chnageFontColorCMYKtoRGB();
}

/*To Cahnge Color By Input Text in QuickAdjust*/
function chnageFontColorCMYKtoRGB_QuickAdjust() {

    var c = 0.00, m = 0.00, k = 0.00, y = 0.00, r = 0.00, g = 0.00, b = 0.00, tint = 0.00;
    c = $("#txtC2").val();
    m = $("#txtM2").val();
    y = $("#txtY2").val();
    k = $("#txtK2").val();
    tint = $("#txtT2").val();

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    var labeelColor = $("#" + Control.ObjectID + " .label").css('color');



    c = parseFloat(c / 100);
    m = parseFloat(m / 100);
    y = parseFloat(y / 100);
    k = parseFloat(k / 100);


    //Storing Selected CMYK color in temporary variable
    Control.TempC = c;
    Control.TempM = m;
    Control.TempY = y;
    Control.TempK = k;
    Control.TempTint = tint;

    Control.IsTempColor = true; // added for differntialte controls if color is changes from Quick Adjust dailog 
    r = 1 - parseFloat((1, c * (1 - k) + k));
    g = 1 - parseFloat((1, m * (1 - k) + k));
    b = 1 - parseFloat((1, y * (1 - k) + k));

    //r = tint * r + (1 - tint) * 255;
    //g = tint * g + (1 - tint) * 255;
    //b = tint * b + (1 - tint) * 255;

    r = Math.round(r * 255);
    g = Math.round(g * 255);
    b = Math.round(b * 255);

    //Storing Selected RGB color in temporary variable
    Control.TempR = r;
    Control.TempG = g;
    Control.TempB = b;



    //if ($("#" + Control.ObjectID).hasClass('Para') || $("#" + Control.ObjectID).hasClass('Text')) {
    //    if ($("#" + Control.ObjectID).hasClass('Text')) {
    //        $("#" + Control.ObjectID + " .labelText").css('color', 'rgb(' + r + ',' + g + ',' + b + ')');
    //    }
    //    if ($("#" + Control.ObjectID).hasClass('Para')) {
    //        $("#" + Control.ObjectID).css('color', 'rgb(' + r + ',' + g + ',' + b + ')');
    //    }
    //}
    // $("#" + Control.ObjectID + " .label").css('color', labeelColor);
    $("#colorpicker_" + Control.ObjectID).css('background-color', "rgba(" + r + ", " + g + ", " + b + ")");
}

/*To Change color Style*/
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

/*Change Spot color Reference*/
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

/*Get RGB From CMYK*/
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

/**********************************
Default Content Panel Events(Craeted By: Infomaze)
***********************************/

/*Bind Default Content Panel Events*/
function LoadDefaultContentPanelEvents() {
    $("#defaultcontenttext").unbind('click').bind('click', function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });


        //Changed By shahbaz added Control.CustomFieldType != "Date" 
        if ((Control.DefaultContent == Control.DatabaseContent || Control.Dropdowns != "None") && Control.CustomFieldType != "Date") {
            Control.DefaultContent = Control.FieldName;
            changeDefaultContent(Control.FieldName, true, false);
        }

        Control.DatabaseContent = "";
        Control.Dropdowns = "None";
        Control.PhraseBookID = 0;
        Control.PhraseType = "";
        Control.EditDropdown = false;


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
        $("#Chk_EditDropdown").prop('disabled', true);
        $("#Chk_EditDropdown").prop('checked', false);

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
        Control.EditDropdown = false;

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
        $("#Chk_EditDropdown").prop('disabled', true);
        $("#Chk_EditDropdown").prop('checked', false);

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
        //Control.DeafaultContent = "";
        // changeDefaultContent(Control.DeafaultContent, true, false);

        //$("#txtDefaultContent").val("");
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

        $("#Chk_EditDropdown").prop('disabled', false);

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

        changeDefaultContent(text, true, false);//3rd parameter value as false - For Ticket 16079

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
                    changeDefaultContent(txtvalue + arry[0], true, false);//3rd parameter value as false - For Ticket 16079
                    Control.Dropdowns = DropDown;
                }
                else {
                    $("#txtDatabaseContent").val(txtvalue + " " + arry[0]);
                    $("#txtDefaultContent").val(txtvalue + " " + arry[0]);
                    Control.DatabaseContent = txtvalue + " " + arry[0];
                    Control.DefaultContent = txtvalue + " " + arry[0];
                    changeDefaultContent(txtvalue + " " + arry[0], true, false);//3rd parameter value as false - For Ticket 16079
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
                    changeDefaultContent(txtvalue + arry[0], true, false);//3rd parameter value as false - For Ticket 16079
                    Control.Dropdowns = DropDown;
                }
                else {
                    $("#txtDatabaseContent").val(txtvalue + " " + arry[0]);
                    $("#txtDefaultContent").val(txtvalue + " " + arry[0]);
                    Control.DatabaseContent = txtvalue + " " + arry[0];
                    Control.DefaultContent = txtvalue + " " + arry[0];
                    changeDefaultContent(txtvalue + " " + arry[0], true, false);//3rd parameter value as false - For Ticket 16079
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

            changeDefaultContent(value, true, false);//3rd parameter value as false - For Ticket 16079
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

            changeDefaultContent(value, true, false);//3rd parameter value as false - For Ticket 16079
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

            changeDefaultContent(value, true, false);//3rd parameter value as false - For Ticket 16079
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

            changeDefaultContent(value, true, false);//3rd parameter value as false - For Ticket 16079
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
        changeDefaultContent(value, true, false);//3rd parameter value as false - For Ticket 16079
    });

    $("#chkJobNameField").unbind('change').bind('change', function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if (this.checked)
            Control.IsJobNameField = true;
        else
            Control.IsJobNameField = false;
    });

    $("#chkPhoneFormat").unbind("change").bind("change", function () {

        if (this.checked) {
            $("#drpPhoneFormat").prop("disabled", false);
        }
        else {
            $("#drpPhoneFormat").prop("disabled", true);
            $("#drpPhoneFormat").val("0");
            var Control;
            ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
            Control.PhoneFormat = "None";
        }

    });

    $("#drpPhoneFormat").unbind('change').bind('change', function () {
        var value = $("#drpPhoneFormat :selected").text();
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if (value != "0")
            Control.PhoneFormat = value;
        else
            Control.PhoneFormat = "None";
    });

    $("#Chk_EditDropdown").unbind('change').bind('change', function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        if (this.checked) {
            Control.EditDropdown = true;
        }
        else {
            Control.EditDropdown = false;
        }
    });

}


/**********************************
Label Panel Events(Craeted By: Infomaze)
***********************************/

/*Bind Label Panel Events*/
function LoadLabelPanelEvents() {
    $("#rdUseLabel").unbind('click').bind('click', function () {
        isLabelAdded = false;
        if ($(this).prop('checked') == true) {
            isLabelAdded = AddLabel();
        }
        if (isLabelAdded) {
            $("#txtLabel").prop('disabled', false);
            $("#drpLabelFontStyleID0").prop('selected', true);
            $("#drplabelFontStyle").prop('disabled', false);
            $("#drpLabelColorStyleID0").prop('selected', true);
            $("#drplabelColorStyle").prop('disabled', false);
            $("#rdAttached").prop('checked', true);
            $("#rdAttached").prop('disabled', false);
            $("#rdRightAttached").prop('checked', false);
            $("#rdRightAttached").prop('disabled', false);
            $("#rdCustomPostioning").prop('checked', false);
            $("#rdCustomPostioning").prop('disabled', false);
            $("#rdleftofobject").prop('checked', false);
            $("#rdleftofobject").prop('disabled', true);
            $("#rdaboveobject").prop('checked', false);
            $("#rdaboveobject").prop('disabled', true);
            $(".leftofobject").val("");
            $(".leftofobject").prop('disabled', true);
            $(".aboveobject").val("");
            $(".aboveobject").prop('disabled', true);

            $(".rightofobject").val("");
            $(".rightofobject").prop('disabled', true);
            $("#rdrightofobject").prop('disabled', true);
        }
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
        $(".leftofobject").val("");
        $(".leftofobject").prop('disabled', true);
        $(".aboveobject").val("");
        $(".aboveobject").prop('disabled', true);
        //$("#chklabelLeft").prop('checked', false);
        //$("#chklabelLeft").prop('disabled', true);
        $(".rightofobject").val("");
        $(".rightofobject").prop('disabled', true);
        $("#rdrightofobject").prop('checked', false);
        $("#rdrightofobject").prop('disabled', true);
        AddLabelpostionRightToControl(false);
    });

    $("#rdCustomPostioning").unbind('change').bind('change', function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if ($(this).prop('checked') == true) {
            AddCustomPositioning();
            $(".alignObject").prop('disabled', false);
            $("#rdleftofobject").prop('checked', true);
            $(".leftofobject").prop('disabled', false);
            $(".rightofobject").prop('disabled', true);


            if (Control.TextAlign.toLowerCase() == "left" || Control.TextAlign.toLowerCase() == "center") {
                $(".rightofobject").val("");
                $("#rdrightofobject").prop('disabled', false);
            } else {
                $("#rdrightofobject").prop('disabled', false);
            }
        }
        else if ($("#rdUseLabel").prop('checked') == true) {
            AddLabelAttached();
        }
    });

    $("#rdAttached").unbind('change').bind('change', function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if ($("#" + Control.ObjectID + " .label").length > 0)
            $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block', 'position': 'relative', 'right': 'auto' });
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
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if ($("#" + Control.ObjectID + " .label").length > 0)
            $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block', 'position': 'relative', 'left': 'auto' });
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
        $(".rightofobject").val("");
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if ($("#" + Control.ObjectID + " .label").length > 0)
            $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block', 'position': 'relative', 'right': 'auto' });
        if ($(this).prop('checked') == true) {
            AddCustomPositioningToLeft();
            $(".aboveobject").prop('disabled', true);
            $(".leftofobject").prop('disabled', false);
            $(".rightofobject").prop('disabled', true);
        }
    });

    $(".leftofobject").unbind('keyup').bind('keyup', function () {
        AddCustomPositioningToLeft();
    });

    $("#rdaboveobject").unbind('click').bind('click', function () {
        $(".leftofobject").val("");
        $(".rightofobject").val("");
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if ($("#" + Control.ObjectID + " .label").length > 0)
            $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block', 'position': 'relative', 'right': 'auto' });
        if ($(this).prop('checked') == true) {
            AddCustomPositioningToTop();
            $(".aboveobject").prop('disabled', false);
            $(".rightofobject").prop('disabled', true);
            $(".leftofobject").prop('disabled', true);
        }
    });

    $(".aboveobject").unbind('keyup').bind('keyup', function () {
        AddCustomPositioningToTop();
    });

    $("#rdrightofobject").unbind('click').bind('click', function () {
        $(".aboveobject").val("");
        $(".leftofobject").val("");
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if ($("#" + Control.ObjectID + " .label").length > 0)
            $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block', 'position': 'relative', 'right': 'auto' });
        if ($(this).prop('checked') == true) {
            AddCustomPositioningToLeft();
            $(".aboveobject").prop('disabled', true);
            $(".leftofobject").prop('disabled', true);
            $(".rightofobject").prop('disabled', false);
        }
    });

    $(".rightofobject").unbind('keyup').bind('keyup', function () {
        AddCustomPositioningToLeft();
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

    $("#rdrightofobject").unbind("click").bind("click", function () {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
        if (Control.TextAlign.toLowerCase() == "right") {
            $(".leftofobject").val("");
            $(".aboveobject").val("");
            $(".rightofobject").val("");
            if ($(this).prop("checked")) {
                $(".aboveobject").prop('disabled', true);
                $(".leftofobject").prop('disabled', true);
                $(".rightofobject").prop('disabled', false);
                AddLabelpostionRightToControl();
                AdjustLabelpostionRightToControl();
            }
        }
    });

    $(".rightofobject").unbind('keyup').bind('keyup', function () {
        AdjustLabelpostionRightToControl();
    });
}

/*Change Label Position on left */
function AddLabelpostionRightToControl(IsOnLeft) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (Control.TextAlign.toLowerCase() == "right") {
        var labeltext = $("#" + Control.ObjectID + " .label").html();
        //RemoveLabel();
        $("#txtLabel").val(labeltext.replace(/&nbsp;/g, " "));//.replace(/</g, "&lt").replace(/>/g, "&gt"));
        Control.Labels = "Use Labels";
        Control.LabelPosition = "customRight";
        Control.Label = null;
        Control.LabelValue = $("#txtLabel").val();
        $("#" + Control.ObjectID + " br").remove();
        Control.CustomTop = 0;
        Control.CustomLeft = 0;
        Control.CustomRight = isNaN(parseFloat($(".rightofobject").val())) ? 0 : parseFloat($(".rightofobject").val());
        //AddLabel();
        //var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        //var controlWidth = Control.Width * mmConvertionConstant - ($("#" + Control.ObjectID + " .labelText").outerWidth() - LabelWidth);
        //$("#" + Control.ObjectID + " .label").css({ 'margin-right': controlWidth + 'px' });
        //$("#" + Control.ObjectID + " .labelText").css({ 'marigin-left': controlWidth + 'px' });
    }

}

function AdjustLabelpostionRightToControl() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    var PreviousCustomRight = Control.CustomRight;
    if ($(".rightofobject").val() == "")
        Control.CustomRight = 0;
    else
        Control.CustomRight = parseFloat($(".rightofobject").val());
    $("#" + Control.ObjectID + " .label").css("right", Control.CustomRight * mmConvertionConstant + "px")

    Control.Labels = "Use Labels";
    var Text = $("#txtLabel").val();
    if ($("#drplabelFontStyle").val() != "0") {
        var name = $("#drplabelFontStyle").val().split('~')[1];
        var FontStyle;
        FontStyleDetails.map(function (proj) { if (proj.FontStyleName == name) FontStyle = proj });
        if (FontStyle != null) {
            Text = capitalizeTheText(Text, FontStyle.Capitalize);
        }
    }

    $("#" + Control.ObjectID + " .label").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "customRight") {
        $("#" + Control.ObjectID + " .label").css({ 'width': 'auto', 'display': 'inline-block', 'position': 'absolute', 'height': parseFloat($("#" + Control.ObjectID + " .label").css('line-height')) + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });
        $("#" + Control.ObjectID).css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });

        //if ($("#" + Control.ObjectID + " .labelText").outerWidth() > $("#" + Control.ObjectID).outerWidth()) {
        //    $("#savemsg").html("The combined width of the label and the text box exceeds the total width of the control... Kindly change");
        //    $("#SaveMessage").dialog("open");
        //    msgBoxDesign();
        //    Control.CustomRight = PreviousCustomRight;
        //    $(".leftofobject").val(PreviousCustomRight);
        //    $("#" + Control.ObjectID + " .label").css("right", PreviousCustomRight * mmConvertionConstant + "px")
        //    $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block', 'position': 'absolute', 'height': parseFloat($("#" + Control.ObjectID + " .label").css('line-height')) + 'px' });
        //    $("#" + Control.ObjectID + " .labelText").css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });
        //    $("#" + Control.ObjectID).css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });
        //}

        var labelColor = $("#" + Control.ObjectID + " label").css('color');
        var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
        var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');


        alignsingleLineText(Control.ObjectID);
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

        $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize, 'font-style': 'normal' });

        if (parseFloat(Control.CustomRight * mmConvertionConstant) + parseFloat($("#" + Control.ObjectID + " .label").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
            //var diff = parseFloat($("#" + Control.ObjectID).css("right")) - parseFloat($("#" + Control.ObjectID + " .label").css("right"));
            //var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
            //$("#" + Control.ObjectID).css('width', Control.CustomRight * mmConvertionConstant + parseFloat($("#" + Control.ObjectID + " .label").outerWidth()) + "px");
            //Control.MaxWidth = Control.CustomRight + (parseFloat($("#" + Control.ObjectID + " .label").outerWidth()) / mmConvertionConstant);
            //Control.Width = Control.MaxWidth;
            //fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

            $("#savemsg").html("The combined width of the label and the text box exceeds the total width of the control... Kindly change");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
            Control.CustomRight = PreviousCustomRight;
            $(".rightofobject").val(PreviousCustomRight);
            $("#" + Control.ObjectID + " .label").css("right", PreviousCustomRight * mmConvertionConstant + "px")
            $("#" + Control.ObjectID + " .label").css({ 'display': 'inline-block', 'position': 'absolute', 'height': parseFloat($("#" + Control.ObjectID + " .label").css('line-height')) + 'px' });
            $("#" + Control.ObjectID + " .labelText").css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });
            $("#" + Control.ObjectID).css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });
        }
    }
}


/*Add Label For Textblock*/
function AddLabel() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });
    if (Control.Labels == "None") {
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
        var labelHtml = "<span style='font-size:" + Control.FontSize / ptConvertionConstant + "px;text-align:left;display:inline-block;position:relative;font-family:arial;font-style:" + Control.FontStyle + ";text-align:left;color:black;font-weight:" + Control.FontWeight + ";letter-spacing:0;' class='label'>" + Control.LabelValue.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt") + "</span>";

        attachLabelTosinglelineControl(Control.ObjectID, labelHtml + ((Control.DefaultContent == "") ? Control.FieldName : Control.DefaultContent));
        alignsingleLineText(Control.ObjectID);
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        $("#" + Control.ObjectID + " label").css({ 'color': 'black', 'font-family': 'arial', 'font-style': 'normal' });
        return true;
    } else {
        return false;
    }
}

/*Change Label Text For Textblock*/
function ChangeLabelText(Text) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.LabelValue = $("#txtLabel").val();
    if ($("#drplabelFontStyle").val() != "0") {
        var name = $("#drplabelFontStyle").val().split('~')[1];
        var FontStyle;
        FontStyleDetails.map(function (proj) { if (proj.FontStyleName == name) FontStyle = proj });
        if (FontStyle != null) {
            Text = capitalizeTheText(Text, FontStyle.Capitalize);
        }
    }
    $("#" + Control.ObjectID + " .label").html('');
    $("#" + Control.ObjectID + " .label").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    //if (Control.CustomTop == "") {
    //    var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
    //    var LabeltextWidth = $("#" + Control.ObjectID + " .labelText").outerWidth();
    //    var ObjectWidth = $("#" + Control.ObjectID).outerWidth();

    //    var width = ObjectWidth - LabeltextWidth;

    //    if ($("#" + Control.ObjectID + " .label").outerWidth() > width) {
    //        while ($("#" + Control.ObjectID + " .label").outerWidth() > width) {
    //            defaultContent = Control.LabelValue.substr(0, Control.LabelValue.length - 1);
    //            Text = defaultContent;
    //            Control.LabelValue = Text;
    //            $("#" + Control.ObjectID + " .label").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));
    //        }
    //    }

    //}


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
    else if (Control.LabelPosition == "customRight") {
        if (parseFloat(Control.CustomRight * mmConvertionConstant) + parseFloat($("#" + Control.ObjectID + " .label").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
            var diff = parseFloat($("#" + Control.ObjectID).css("right")) - parseFloat($("#" + Control.ObjectID + " .label").css("right"));
            var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
            $("#" + Control.ObjectID).css('width', Control.CustomRight * mmConvertionConstant + parseFloat($("#" + Control.ObjectID + " .label").outerWidth()) + "px");
            Control.MaxWidth = Control.CustomRight + (parseFloat($("#" + Control.ObjectID + " .label").outerWidth()) / mmConvertionConstant);
            Control.Width = Control.MaxWidth;
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
        }
    }

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');

    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

    if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
        //Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
        Control.MaxWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() / mmConvertionConstant;
        Control.Width = Control.MaxWidth;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }
    //else if (parseFloat($("#" + Control.ObjectID).outerWidth() / mmConvertionConstant) > 50 && parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) < parseFloat($("#" + Control.ObjectID).outerWidth())) {
    //    $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
    //    //if ($("#" + Control.ObjectID + " .labelText").outerWidth() < 50)
    //    //    Control.MaxWidth = "49.9983";
    //    //else
    //    Control.MaxWidth = $("#" + Control.ObjectID + " .labelText").outerWidth() / mmConvertionConstant;
    //    Control.Width = Control.MaxWidth;
    //    $("#" + Control.ObjectID).css('width', Control.Width * mmConvertionConstant);
    //    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    //}
    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize, 'font-style': 'normal' });
}

/*Remove Label For Textblock*/
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
    $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + ' .labelText').height() + 'px' });
    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
}

/*Add Attached Label For Textblock*/
function AddLabelAttached() {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    //Control.LabelActualFontName = "Arial";
    //Control.LabelFontExtension = "Arial.ttf";
    //Control.LabelFontStyle = "";
    //Control.LabelFontID = 0;
    Control.LabelPosition = "Attached";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    var Text = $("#txtLabel").val();
    Control.CustomLeft = 0;
    Control.CustomRight = 0;

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');

    if ($("#drplabelFontStyle").val() != "0") {
        var name = $("#drplabelFontStyle").val().split('~')[1];
        var FontStyle;
        FontStyleDetails.map(function (proj) { if (proj.FontStyleName == name) FontStyle = proj });
        if (FontStyle != null) {
            Text = capitalizeTheText(Text, FontStyle.Capitalize);
        }
    }

    $("#" + Control.ObjectID + " .label").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "Attached") {
        $("#" + Control.ObjectID + " .label").css({ 'width': 'auto' });
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID + " .label").css({ 'width': 'auto', 'display': 'inline-block', 'height': parseFloat($("#" + Control.ObjectID + " .label").css('line-height')) + 'px' });
        $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + ' .labelText').height() + 'px' });
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

    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize, 'font-style': 'normal' });

    $(".leftofobject").val("");
    $(".aboveobject").val("");
    $(".rightofobject").val("");

}

function AddRightLabelAttached() {

    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    //Control.LabelActualFontName = "Arial";
    //Control.LabelFontExtension = "Arial.ttf";
    //Control.LabelFontStyle = "";
    //Control.LabelFontID = 0;
    Control.LabelPosition = "RightAttached";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    var Text = $("#txtLabel").val();
    Control.CustomLeft = 0;
    Control.CustomRight = 0;

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');

    if ($("#drplabelFontStyle").val() != "0") {
        var name = $("#drplabelFontStyle").val().split('~')[1];
        var FontStyle;
        FontStyleDetails.map(function (proj) { if (proj.FontStyleName == name) FontStyle = proj });
        if (FontStyle != null) {
            Text = capitalizeTheText(Text, FontStyle.Capitalize);
        }
    }

    $("#" + Control.ObjectID + " .label").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "RightAttached") {
        $("#" + Control.ObjectID + " .label").css({ 'width': 'auto' });
        $("#" + Control.ObjectID + " .label").css({ 'float': 'right', 'clear': 'right', 'margin-left': LabelWidth + 'px' });
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID + " .label").css({ 'width': 'auto', 'display': 'inline-block', 'height': parseFloat($("#" + Control.ObjectID + " .label").css('line-height')) + 'px' });
        $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + ' .labelText').height() + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'margin-right': LabelWidth + 'px' });
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

    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize, 'font-style': 'normal' });

    $(".leftofobject").val("");
    $(".aboveobject").val("");
    $(".rightofobject").val("");

}


/*Add Custom Position Label For Textblock*/
function AddCustomPositioning() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    Control.Labels = "Use Labels";
    //Control.LabelActualFontName = "Arial";
    //Control.LabelFontExtension = "Arial.ttf";
    //Control.LabelFontStyle = "";
    //Control.LabelFontID = 0;
    Control.LabelPosition = "customLeft";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    Control.CustomLeft = isNaN(parseFloat($(".leftofobject").val())) ? 0 : parseFloat($(".leftofobject").val());
    var Text = $("#txtLabel").val();
    if ($("#drplabelFontStyle").val() != "0") {
        var name = $("#drplabelFontStyle").val().split('~')[1];
        var FontStyle;
        FontStyleDetails.map(function (proj) { if (proj.FontStyleName == name) FontStyle = proj });
        if (FontStyle != null) {
            Text = capitalizeTheText(Text, FontStyle.Capitalize);
        }
    }


    $("#" + Control.ObjectID + " .label").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "customLeft") {
        $("#" + Control.ObjectID + " .label").css({ 'width': (Control.CustomLeft * mmConvertionConstant) + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'marigin-left': (Control.CustomLeft * mmConvertionConstant) + 'px' });
    }

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');

    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize, 'font-style': 'normal' });

    if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
        Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
        Control.Width = Control.MaxWidth;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }


}

/*Add Custom Position Left Label For Textblock*/
function AddCustomPositioningToLeft() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    //Commented by Shahbaz
    Control.Labels = "Use Labels";
    //Control.LabelActualFontName = "Arial";
    //Control.LabelFontExtension = "Arial.ttf";
    //Control.LabelFontStyle = "";
    //Control.LabelFontID = 0;
    var PreviousCustomLeft = Control.CustomLeft;
    Control.LabelPosition = "customLeft";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    $("#" + Control.ObjectID + " br").remove();
    Control.CustomTop = 0;
    Control.CustomLeft = isNaN(parseFloat($(".leftofobject").val())) ? 0 : parseFloat($(".leftofobject").val());

    var Text = $("#txtLabel").val();
    if ($("#drplabelFontStyle").val() != "0") {
        var name = $("#drplabelFontStyle").val().split('~')[1];
        var FontStyle;
        FontStyleDetails.map(function (proj) { if (proj.FontStyleName == name) FontStyle = proj });
        if (FontStyle != null) {
            Text = capitalizeTheText(Text, FontStyle.Capitalize);
        }
    }

    $("#" + Control.ObjectID + " .label").html(Text.replace(/ /g, "&nbsp;").replace(/</g, "&lt").replace(/>/g, "&gt"));

    if (Control.LabelPosition == "customLeft") {
        $("#" + Control.ObjectID + " .label").css({ 'width': (Control.CustomLeft * mmConvertionConstant) + 'px', 'display': 'inline-block', 'height': parseFloat($("#" + Control.ObjectID + " .label").css('line-height')) + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });
        $("#" + Control.ObjectID).css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });
    }

    if ($("#" + Control.ObjectID + " .labelText").outerWidth() > $("#" + Control.ObjectID).outerWidth()) {
        $("#savemsg").html("The combined width of the label and the text box exceeds the total width of the control... Kindly change");
        $("#SaveMessage").dialog("open");
        msgBoxDesign();
        Control.CustomLeft = PreviousCustomLeft;
        $(".leftofobject").val(PreviousCustomLeft);
        $("#" + Control.ObjectID + " .label").css({ 'width': (PreviousCustomLeft * mmConvertionConstant) + 'px', 'display': 'inline-block', 'height': parseFloat($("#" + Control.ObjectID + " .label").css('line-height')) + 'px' });
        $("#" + Control.ObjectID + " .labelText").css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });
        $("#" + Control.ObjectID).css({ 'height': parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 'px' });
    }

    var labelColor = $("#" + Control.ObjectID + " label").css('color');
    var labelFontFamily = $("#" + Control.ObjectID + " label").css('font-family');
    var labelFontSize = $("#" + Control.ObjectID + " label").css('font-size');


    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

    $("#" + Control.ObjectID + " label").css({ 'color': labelColor, 'font-family': labelFontFamily, 'font-size': labelFontSize, 'font-style': 'normal' });

    if (parseFloat($("#" + Control.ObjectID + " .labelText").outerWidth()) > parseFloat($("#" + Control.ObjectID).outerWidth())) {
        var LabelWidth = $("#" + Control.ObjectID + " .label").outerWidth();
        $("#" + Control.ObjectID).css('width', $("#" + Control.ObjectID + " .labelText").outerWidth());
        Control.MaxWidth = ($("#" + Control.ObjectID).outerWidth() - LabelWidth) / mmConvertionConstant;
        Control.Width = Control.MaxWidth;
        fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
    }
}

/*Add Custom Position Top Label For Textblock*/
function AddCustomPositioningToTop() {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    //Commented By Shahbaz
    Control.Labels = "Use Labels";
    //Control.LabelActualFontName = "Arial";
    //Control.LabelFontExtension = "Arial.ttf";
    //Control.LabelFontStyle = "";
    //Control.LabelFontID = 0;
    Control.LabelPosition = "customTop";
    Control.Label = null;
    Control.LabelValue = $("#txtLabel").val();
    Control.CustomLeft = 0;
    Control.CustomTop = isNaN(parseFloat($(".aboveobject").val())) ? 0 : parseFloat($(".aboveobject").val());

    $("#" + Control.ObjectID + " .labelText").css({ 'bottom': 'auto', 'display': 'inline-table' });
    $("#" + Control.ObjectID + " .label").css({ 'width': 'auto', 'display': 'block', 'height': (Control.CustomTop * mmConvertionConstant) + parseFloat($("#" + Control.ObjectID + " .labelText").css('line-height')) + 2 + 'px' });
    $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .labelText").height() + "px" });
    if (Control.TextAlign.toLowerCase() == "left") {
        $("#" + Control.ObjectID + " .labelText").css({ 'right': 'auto', 'left': -1 + 'px', 'text-align': 'left' });
        $("#" + Control.ObjectID + " .label").css({ 'margin': '0px', 'width': $("#" + Control.ObjectID + " .label").width(), 'text-align': 'left' });
    }
    else if (Control.TextAlign.toLowerCase() == "center") {
        var mar = (Control.Width * mmConvertionConstant / 2) - ((parseFloat($("#" + Control.ObjectID + " .labelText").width())) / 2);
        $("#" + Control.ObjectID + " .labelText").css({ 'right': 'auto', 'left': mar - 1 + 'px', 'text-align': 'center' });
    }
    else if (Control.TextAlign.toLowerCase() == "right") {
        $("#" + Control.ObjectID + " .labelText").css({ 'left': 'auto', 'right': '0px', 'text-align': 'right' });
    }
    $("#" + Control.ObjectID).css({ 'height': $("#" + Control.ObjectID + " .labelText").height() + "px" });

    var divHeight = parseFloat($("#" + Control.ObjectID).height());
    //$("#" + Control.ObjectID).css({ 'height': divHeight + "px", 'line-height': divHeight + "px" });
    Control.Height = divHeight / mmConvertionConstant;
    Control.MaxHeight = divHeight / mmConvertionConstant;
    alignsingleLineText(Control.ObjectID);
    fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);

}

/*Change The label font Style For Label*/
function changeLabelFontStyle(FontStyleName) {
    var Control;
    ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

    if (FontStyleName != "") {
        var FontStyle;
        FontStyleDetails.map(function (proj) { if (proj.FontStyleName == FontStyleName) FontStyle = proj });
        if (FontStyle != null) {
            Control.LabelFontID = FontStyle.FontID;
            Control.LabelFontSize = FontStyle.FontSize;
            Control.LabelFontStyle = FontStyle.FontStyleName;

            var Font;
            FontList.map(function (proj) { if (proj.DisplayFontName == FontStyle.FontFamily) Font = proj });
            if (Font != null) {
                Control.LabelActualFontName = Font.ActualFontName;
                Control.LabelFontExtension = Font.FontFilePath;
            }

            var val;
            if (FontStyle.TrackPoint == "pt") {
                val = FontStyle.ManualTracking * ptConvertionConstant;
            }
            else if (FontStyle.TrackPoint == "mm") {
                val = FontStyle.ManualTracking * mmConvertionConstant;
            }
            var uniquefontname = getuniquefontname();
            $("head").append("<style>@font-face { font-family:" + uniquefontname + "; src: url('" + FontPath + Control.LabelFontExtension + "'); }</style>");
            $("#" + selectedObjectID + " .label").css({ 'font-family': uniquefontname, 'letter-spacing': FontStyle.TrackOffSet + val + 'px', 'font-size': FontStyle.FontSize / ptConvertionConstant + 'px', 'font-style': Control.FontStyle, 'font-weight': Control.FontWeight });
            var Text = Control.LabelValue;
            var defaultContent = capitalizeTheText(Text, FontStyle.Capitalize);

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

            $("#" + Control.ObjectID + " .label").css({ 'width': 'auto' });
            alignsingleLineText(Control.ObjectID);
            fixPostionOfControll(Control.ObjectID, Control.PositionX, Control.PositionY, Control.TextAlign);
            $("#" + selectedObjectID + " .labelText").css({ 'bottom': 'auto' });

        }
    }
    else {
        var Control;
        ControllDetails.map(function (proj) { if (proj.ObjectID == selectedObjectID) Control = proj });

        Control.LabelFontID = 0;
        Control.LabelFontSize = parseFloat($("#" + selectedObjectID + " .labelText").css('font-size')) * ptConvertionConstant;
        Control.LabelFontStyle = "";
        Control.LabelActualFontName = "Arial";
        Control.LabelFontExtension = "Arial.ttf";

        $("#" + selectedObjectID + " .label").css({ 'font-family': 'arial', 'font-weight': Control.FontWeight, 'font-style': Control.FontStyle, 'letter-spacing': 'normal', 'font-size': $("#" + selectedObjectID + " .labelText").css('font-size') });
        $("#" + selectedObjectID + " .labelText").css({ 'bottom': 'auto' });
    }

    if ($("#rdleftofobject").prop('checked'))
        AddCustomPositioningToLeft();
    else if ($("#rdaboveobject").prop('checked'))
        AddCustomPositioningToTop();
}

/*Change The label Color Style For Label*/
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

/**********************************
Save Template Panel Events(Craeted By: Infomaze)
***********************************/

/*Bind Save template Panel Events*/
function LoadSaveTemplatePanelEvents() {
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

    $("#chkGroupConsider").unbind('change').bind('change', function () {
        if ($(this).prop('checked') == true) {
            TemplateDetails.IsGroupConsiderLabel = true;
        }
        else {
            TemplateDetails.IsGroupConsiderLabel = false;
        }
    });

    $("#txtTemplateName").unbind('keyup').bind('keyup', function () {
        changeTemplateName($(this).val());
    });



    
    $("#txtDescription").unbind('keyup').bind('keyup', function () {
        changeTemplateDescription($(this).val());
    });

    $("#btnSave").unbind('click').bind('click', function () {
        if ($('#txtTemplateName').val() != "") {
            //var _istemplatesame = false;
            //for (var i = 0; i < TemplateIDandNameList.length; i++) {
            //    var arry = TemplateIDandNameList[i].split('~');
            //    if (arry[1].toLowerCase() == ($('#txtTemplateName').val().toLowerCase())) {
            //        _istemplatesame = true;
            //        break;
            //    }
            //    else {
            //        _istemplatesame = false;
            //    }
            //}

            //if (_istemplatesame == false) {
            //    $(".loading_new").show();
            //    UpadteTemplteDetails(true, false);
            //}
            //else {
            //    $("#savemsg").html("Template name already exists.");
            //    $("#SaveMessage").dialog("open");
            //    msgBoxDesign();
            //}

            $(".loading_new").show();
            UpadteTemplteDetails(true, false);
        }
        else {
            $("#savemsg").html("Please enter template name.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }

    });

    $("#btnSaveandClose").unbind('click').bind('click', function () {
        if ($('#txtTemplateName').val() != "") {
            //var _istemplatesame = false;
            //for (var i = 0; i < TemplateIDandNameList.length; i++) {
            //    var arry = TemplateIDandNameList[i].split('~');
            //    if (arry[1].toLowerCase() == ($('#txtTemplateName').val().toLowerCase())) {
            //        _istemplatesame = true;
            //        break;
            //    }
            //    else {
            //        _istemplatesame = false;
            //    }
            //}
            //if (_istemplatesame == false) {
            //    $(".loading_new").show();
            //    saveAndExit = true;
            //    UpadteTemplteDetails(false, true);

            //}
            //else {
            //    $("#savemsg").html("Template name already exists.");
            //    $("#SaveMessage").dialog("open");
            //    msgBoxDesign();
            //}


            $(".loading_new").show();
            saveAndExit = true;
            UpadteTemplteDetails(false, true);
        }
        else {
            $("#savemsg").html("Please enter template name.");
            $("#SaveMessage").dialog("open");
            msgBoxDesign();
        }
    });
}

/*To Allow Add text Block In front End*/
function changeAllowTextBlock(Status) {
    TemplateDetails.AddNewTextBlock = Status;
}

/*to Allow Add Paragraph In front End*/
function changeAllowParagraph(Status) {
    TemplateDetails.AddNewParagraph = Status;
}

/*To Allow Add Image In front End*/
function changeAllowImage(Status) {
    TemplateDetails.AddNewImage = Status;
}

/*To Show Editor In front End*/
function changeShowEditor(Status) {
    TemplateDetails.ShowEdiotr = Status;
}

/*To Show Only Editable Pages front End*/
function changeShoweditablePages(Status) {
    TemplateDetails.ShowEditablePages = Status;
}

/*To Send Image as Attachemt*/
function changeSendAttachments(Status) {
    TemplateDetails.SendAttachment = Status;
}

/*To Change Template Name*/
function changeTemplateName(Text) {
    TemplateDetails.TemplateName = Text;
}

/*To Change Template Name*/
function changeFrontEditorZoom(Text) {
    TemplateDetails.ZoomPercent = Text;
}

/*To Change Template Description*/
function changeTemplateDescription(Text) {
    TemplateDetails.TemplateDescription = Text;
}

/*To Save Template Details*/
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

/*To Save template Properties*/
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
                    if (resultFromSevice.d.split(',')[1].toLowerCase() == "true")//Added By shahbaz
                        showSavedPopup(FromSaveButton, Saveandclose, result);
                },
                error: function (error, et) {
                    result = false;
                    //showSavedPopup(FromSaveButton, Saveandclose, result);//Commented By shahbaz
                },
            });

            if (result == false) {//Added By shahbaz
                showSavedPopup(FromSaveButton, Saveandclose, result);
                break;
            }
        }
    }
    else {
        showSavedPopup(FromSaveButton, Saveandclose, result);
    }
}

/*Show Popup After Save*/
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

        }
        return;
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


    //if ($("#tbdy_QuickAdjustControl").html() == "" && FromSaveButton == false && SaveAndClose == false) {
    //    $("#savemsg").html("No item available!");
    //    $("#SaveMessage").dialog("open");
    //    $(".MessagesPopuploadingNewMask").show();
    //    isFromQuickAdjustSaveNStay = false;
    //} else {
    if (isFromQuickAdjustSaveNStay && result) {
        $("#savemsg").html("Changes saved!");
        $("#SaveMessage").dialog("open");
        var z_index = parseInt($("div[aria-describedby=QuickAdjustDialog]").css('z-index'));
        $(".MessagesPopuploadingNewMask").css('z-index', z_index + 1).show()
        //isFromQuickAdjustSaveNStay = false;
    }
    else if (isFromQuickAdjustSaveNStay && !result) {
        $("#savemsg").html("Error occured, please reload the browser.");
        $("#SaveMessage").dialog("open");
        var z_index = parseInt($("div[aria-describedby=QuickAdjustDialog]").css('z-index'));
        $(".MessagesPopuploadingNewMask").css('z-index', z_index + 1).show()
        // isFromQuickAdjustSaveNStay = false;
    }
    else {
        $("#QuickAdjustDialog").dialog("close");
        isFromQuickAdjustSaveNclose = false;
    }

    if (isFromManageGroupSaveNStay && $("#groupFields").html() == "") {
        $("#savemsg").html("No item available!");
        $("#SaveMessage").dialog("open");
        var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
        $(".MessagesPopuploadingNewMask").css('z-index', z_index + 1).show()
        isFromManageGroupSaveNStay = false;
    } else {
        if (isFromManageGroupSaveNStay && result) {
            $("#savemsg").html("Changes saved!");
            $("#SaveMessage").dialog("open");
            var z_index = parseInt($("div[aria-describedby=ManageGroupAddGroup]").css('z-index'));
            $(".MessagesPopuploadingNewMask").css('z-index', z_index + 1).show()
            isFromManageGroupSaveNStay = false;
        }
        else if (isFromManageGroupSaveNStay && !result) {
            $("#savemsg").html("Error occured, please reload the browser.");
            $("#SaveMessage").dialog("open");
            //$(".QuickAdjustloadingNewMask").show()
            isFromManageGroupSaveNStay = false;
        }
        //}
    }

}

//Added By Shahbaz for get Height and Width of Rotated Div
function getHeightofRotatedTextBlock(degree, Width, base) {

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

function getWidthofRotatedTextBlock(degree, Width) {
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

function getWidthOfRotatedImageControl(degree, width, height, control) {

    var x = 0;

    if (degree < 95) {
        var deg = (90 - degree);
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
        x = x + y;
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

function getHeightofRotatedImageControl(degree, Width, base, Height, control) {

    //var x = 0;
    //var deg = 0;
    //if (degree <= 35) {
    //    deg = (90 - degree);
    //    base = deg * Width / 60
    //}
    //else if (degree < 90) {
    //    deg = 180 - (90 + degree);
    //    base = deg * Height / 60
    //}
    //else if (degree >= 120) {
    //    var deg = (180 - degree);
    //    deg = 180 - (90 + deg);
    //    base = deg * Width / 60
    //}



    //if (base > Width)
    //    base = base - (base - Width);

    ////x = Math.sqrt(Width * Width - base * base);
    ////x = 0;
    ////if (x == 0) {
    //if (degree < 45) {
    //    x = Math.sin(degree * Math.PI / 180) * Width;
    //}
    //else if (degree < 90) {
    //    deg = 180 - (90 + degree);
    //    x = Math.sin(deg * Math.PI / 180) * Width;
    //}
    //else if (degree > 180 && degree <= 270) {
    //    deg = degree - 180;
    //    deg = 180 - (90 + deg);
    //    x = Math.sin(deg * Math.PI / 180) * Width;
    //}
    //else if (degree > 270 && degree <= 360) {
    //    deg = degree - 270;
    //    deg = 180 - (90 + deg);
    //    x = Math.sin(deg * Math.PI / 180) * Width;
    //    x = Math.sqrt(Width * Width - x * x)
    //    x = x - (Math.sin(deg * Math.PI / 180) * Height);
    //}
    //// }

    var Actualsize = getActaulHeightOfRotatedControl(control, degree)
    x = parseInt(Actualsize[1] - Height);

    if (degree > 135) {

        deg = 180 - degree;
        h = Math.sin(deg * Math.PI / 180) * base;
        h = Height - h
        x = h
    }

    if (degree > 270 && degree <= 330) {
        deg = degree - 270;
        x = Math.cos((90 - deg) * Math.PI / 180) * Height;
        // x = Actualsize[1] - Height;
    }
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