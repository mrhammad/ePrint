<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editabletemplate.aspx.cs" Inherits="HTML5TemplateEditor_etclient.editabletemplate" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html >
<html>
<head runat="server">
    <title>Edit Product</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <link href="StyleSheets/common.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="StyleSheets/jquery-ui.css" />
    <link href="Js/jqueryui-ruler/css/jquery.ui.ruler.css" rel="stylesheet" />
    <link href="StyleSheets/jquery.colorpicker.css" rel="stylesheet" />
    <script src="Js/Jquery-1.11.1.js"></script>
    <script src="Js/Jquery-ui-1.11.0.js"></script>
    <script src="Js/jquery.ui.touch-punch.min.js"></script>
    <%--<script src="Js/LoadPage.js"></script>
    <script src="Js/Common.js"></script>
    <script src="Js/onChange.js"></script>--%>
    <script src="Js/TemplateEditorFrontEnd.js"></script>
    <script src="js/jquery.colorpicker.js" type="text/javascript"></script>
    <link href="StyleSheets/croppic.css" rel="stylesheet" />
    <script src="js/croppic.js?1" type="text/javascript"></script>
    <script src="Js/calender.js" type="text/javascript"></script>
    <script src="Js/jqueryui-ruler/js/jquery.ui.ruler.js"></script>
    <script src="Js/webfont.js"></script>
    <script src="Js/jquery.mask.min.js"></script>
    <script src="Js/jquery.price_format.2.0.min.js"></script>
</head>
<body>
    <div id="loading">
        <img src="StyleSheets/Images/loading_new.gif" alt="Loading..." />
    </div>
    <div class="loading_new loadingNewMask">
    </div>
    <div class="loading_new loadingNew">
        <img src="StyleSheets/Images/loading_new.gif" alt="Loading..." />
    </div>
    <div class="QuickAdjustloadingNewMask QuickAdjustloadingNew">
    </div>

    <div class="UploadFileloadingNewMask UploadFileloadingNew">
    </div>

    <table id="MainDesigncanvas" class="MainDesigncanvas">
        <tr>
            <td id="LeftPanel" rowspan="2">
                <label id="lblEdit" class="lblEdit">
                    Edit Your Fields</label>
                <div id="LeftPanelDiv">
                    <table id="LeftPanelControl">
                    </table>
                </div>
            </td>
            <td id="MainCanvasArea">
                <table id="menubartdtable" class="menubartdtable">
                    <tr>
                        <%--Menubar--%>
                        <td>
                            <div id="Menubar">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Left Justify" id="btnLeftAlign">
                                                            <img src="StyleSheets/Images/alignleft.png" class="menuimg" alt="Left Justify" />
                                                        </div>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Center Justify" id="btnCenterAlign">
                                                            <img src="StyleSheets/Images/aligncenter.png" class="menuimg" alt="Center Justify" />
                                                        </div>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Right Justify" id="btnRightAlign">
                                                            <img src="StyleSheets/Images/alignright.png" class="menuimg" alt="Right Justify" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Bold" id="btnBold">
                                                            <img src="StyleSheets/Images/bold.png" class="menuimg" alt="Bold" />
                                                        </div>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Italic" id="btnItalic">
                                                            <img src="StyleSheets/Images/italic.png" class="menuimg" alt="Italic" />
                                                        </div>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Delete" id="btnDeleteControl">
                                                            <img src="StyleSheets/Images/delete_icon1.png" class="menuimg" alt="Delete" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="menutablevline">
                                            <div id="vline" class="vline" style="height: 50px;" />
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Reset" id="btnClearAllControlls">
                                                            <img src="StyleSheets/Images/reset.png" class="menuimg" alt="Reset" />
                                                        </div>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Rotate Objects" id="btnRotate">
                                                            <img src="StyleSheets/Images/rotate.png" class="menuimg" alt="Rotate" />
                                                        </div>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <input type="text" style="width: 40px; height: 20px;" id="txtRotate" onkeyup="this.value = minmax(this.value, 0, 360)" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="menutabletd" style="height: 25px;">
                                                        <div class="menubutton" title="Add Textblock" id="btnAddText" onclick="Javascript:AddNewText();"
                                                            style="display: none;">
                                                            <img src="StyleSheets/Images/insert-text.png" class="menuimg addtextField" alt="Add Text" />
                                                        </div>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Add Paragraph" id="btnAddParagraph" onclick="Javascript:AddNewPara();"
                                                            style="display: none;">
                                                            <img src="StyleSheets/Images/paragraph.png" class="menuimg" alt="Add Paragraph" />
                                                        </div>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Add Image" id="btnAddImage" onclick="Javascript:AddNewImage();"
                                                            style="display: none;">
                                                            <img src="StyleSheets/Images/addimg.jpg" class="menuimg" alt="Add Image" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="menutablevline">
                                            <div class="vline" style="height: 50px;" />
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="menutabletd" colspan="3">
                                                        <select style="width: 130px" id="drpFont" title="Apply font family for the selected field">
                                                        </select>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="menutabletd">
                                                        <div class="menubutton" title="Apply foreground colour" id="btnFontColor">
                                                            <img src="StyleSheets/Images/color_line.png" class="menuimg" alt="Rotate" />
                                                            <div class='color' style='font-size: 16px; font-weight: bold; font-family: "Times New Roman"; display: none;'>
                                                                <div id="btnColorText" style="display: none;">
                                                                    A
                                                                </div>
                                                                <div id="btnColorStrip" style="display: none;">
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div id="fontColor" style="text-align: center;">
                                                            <div style="width: 100%; height: 25px; background-image: url('/StyleSheets/Images/popup.png')">
                                                                <span id="colortitle">Foreground Colour</span> <span id="colorclose" title="Close"
                                                                    style="font-size: 16px !important;">x</span>
                                                            </div>
                                                            <div style="padding: 10px;">
                                                                <span class="cp-128"></span>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <label title="Font Size" class="menubarfonttext">
                                                            Font</label>
                                                    </td>
                                                    <td class="menutabletd">
                                                        <input type="text" id="txtFontSize" title="Font Size" style="height: 20px;" onkeyup='return validateQty(event);'
                                                            oninput='vaild(event);' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="menutablevline">
                                            <div class="vline" style="height: 50px;" />
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td id="menutabletdpostionXYtd" class="menutabletd postionXYtd" colspan="3" style="width: 300px;">
                                                        <div style="width: 180px">
                                                            <span title="Font Size">Select Field Position(X,Y)</span>
                                                            <input type="text" id="txtPostionX" style="height: 20px;" title="" onkeyup='return validateQty(event);'
                                                                oninput='vaild(event);' />
                                                            <span title="">mm</span>
                                                            <input type="text" id="txtPostionY" style="height: 20px;" title="" onkeyup='return validateQty(event);'
                                                                oninput='vaild(event);' />
                                                            <span title="">mm</span>
                                                        </div>
                                                        <input type="checkbox" id="chkSetImgAsBckgrnd" style="" disabled="disabled" title="Selected image can be applied as background for the current template, if field is unlocked" />
                                                        <label for="chkSetImgAsBckgrnd" title="Selected image can be applied as background for the current template, if field is unlocked"
                                                            style="vertical-align: middle;">
                                                            Set image as background</label>
                                                        <input type="checkbox" id="chkShowGrid" style="vertical-align: middle;" />
                                                        <label for="chkShowGrid" title="Show Grid" style="vertical-align: middle;">
                                                            Show grid</label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <%--Menubar End--%>
                    </tr>
                    <tr>
                        <%--Canvas--%>
                        <td id="editor" runat="server">

                            <div id="canvasLoading" style="display: none;">
                                <img src="StyleSheets/Images/loading_new.gif" alt="Loading..." />
                            </div>
                            <!--This canvas is used only  for zooming -->
                            <div id="ruler" style="position: absolute; margin-left: -18px; margin-top: -15px">
                            </div>
                            <div id="LayoutCanvas">
                                <div id="Maincanvas" style="margin-top: 5px">
                                    <div id="textCanvas">
                                    </div>

                                </div>
                                <span id="helper"></span>
                            </div>

                        </td>
                        <%--Canvas End--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td id="allowoption " class="verticalMiddle" style="height: 40px;">
                <div id="allowoptiontable " class="verticalMiddle" style="padding-left: 5px; height: 40px;">
                    <div class="displayinlineblock" id="divMainButtons">
                        <div class="btnPrevious displayinlineblock customBtnDiv" >
                            <span class="btnn saveButton" id="btnPrevious" title="Previous">Previous </span>
                        </div>
                        <div class="btnSavetodraft displayinlineblock customBtnDiv" >
                            <span id="btnSavetodraft" class="btnn saveButton" title="Save To Draft">Save to draft
                            </span>
                        </div>
                        <div class="btnpreview displayinlineblock customBtnDiv">
                            <span id="btnpreview" class="btnn saveButton" title="PDF Preview">PDF preview </span>
                        </div>
                        <div class="btnAddtoCart displayinlineblock customBtnDiv">
                            <span id="btnAddtoCart" class="btnn saveButton" title="Add To Cart">Add to cart
                            </span>
                        </div>
                        <div class="btnPreviewAndAddCart displayinlineblock customBtnDiv" style="display: none;">
                            <span id="btnPreviewAndAddCart" class="btnn saveButton" title="Preview And Add To Cart"
                                style="width: 150px;">Preview and add to cart </span>
                        </div>
                        
                    </div>
                    <div id="divSaveAndApprove" class="displayinlineblock" style="display: none;">
                        <div class="btnSaveAndApprove displayinlineblock customBtnDiv" >
                            <span id="btnSaveAndApprove" class="btnn saveButton" title="Save"
                                style="width: 150px;">Save</span>
                        </div>
                    </div>
                    <div class="displayinlineblock customBtnDiv" style="margin: 0px 1px 0px 10px; vertical-align: middle; padding-top: 5px;">
                        <span id="btnprevspage" class="btncircle" title="Previous page">
                            <img src="StyleSheets/Images/arrow-left.png" alt="Previous Page" class="pageNavigation"
                                title="Previous Page" style="vertical-align: middle; margin-left: 6px; margin-top: 6px; display: block;"
                                height="16" width="16" />
                        </span>
                    </div>
                    <div class="displayinlineblock customBtnDiv" style="margin: 0px 10px 0px 0px;">
                        <span id="btnfirstpage" title="View First page" style="font-family: verdana; font-size: 11px;">First </span>
                    </div>
                    <div class="displayinlineblock customBtnDiv" style="margin: 0px 1px 0px 0px;">
                        <span id="btnlastpage" style="font-family: verdana; font-size: 11px;" title="View Last page">Last </span>
                    </div>
                    <div class="displayinlineblock customBtnDiv" style="margin: 0px 10px 0px 0px; vertical-align: middle; padding-top: 5px;">
                        <span id="btnnextpage" class="btncircle" title="Next page">
                            <img src="StyleSheets/Images/arrow-right.png" alt="Next Page" class="pageNavigation"
                                title="Next Page" style="vertical-align: middle; margin-left: 6px; margin-top: 6px; display: block;"
                                height="16" width="16" />
                        </span>
                    </div>
                    <div class="displayinlineblock">
                        <label style="font-family: verdana; font-size: 11px; color: #9D9090;">
                            Page Side:</label>
                        <label style="font-family: verdana; font-size: 11px; font-weight: bold;" id="lblcurrentpage"
                            title="Current Page">
                        </label>
                        <label style="font-family: verdana; font-size: 11px; color: #9D9090; font-weight: bold;">
                            of
                        </label>
                        <label style="font-family: verdana; font-size: 11px; color: #9D9090; font-weight: bold;"
                            id="lbltotalpages" title="Total Pages">
                        </label>
                    </div>
                    <div class="zoomTd displayinlineblock verticalMiddle">
                        <span class="zoomText " style="font-family: verdana; font-size: 11px; color: #9D9090;">Zoom:</span> <span class="btnsmallcircle displayinlineblock" id="btnZoomOut">
                            <img src="StyleSheets/Images/Minus.png" alt="Zoom Out" class="zoom" title="Zoom Out"
                                height="14" width="14" style="display: block;" />
                        </span>
                        <input id="rngslidesetzoom" type="range" step="1" min="0" max="1600" />
                        <span class="btnsmallcircle displayinlineblock" id="btnZoomIn">
                            <img src="StyleSheets/Images/Plus.png" alt="Zoom In" class="zoom" title="Zoom In"
                                height="14" width="14" style="display: block;" />
                        </span><span style="font-family: verdana; font-size: 11px; color: #9D9090; vertical-align: top; margin-top: 5.5px; display: inline-block;"
                            id="lblZoom">%</span>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <div id="Message" title="Information">
        <div id="msg">
        </div>
    </div>
    <div id="MandatoryMessage" title="Information">
        <div id="mandatorymsg">
        </div>
    </div>
    <div id="SaveMessage" title="Information">
        <div id="savemsg">
        </div>
    </div>
    <div id="SaveDraftPopUp" title="Design Name">
        <div>
            <div>
                Please enter design name
            </div>
            <div>
                <input type="text" id="txtProductName" placeholder="Enter Product Name" />
            </div>
            <div class="saveDarftdiv" style="padding-top: 10px">
                <span class="btnn" id="btnsavetodraftPopup" style="margin-left: 0px; padding: 5px 20px 5px 20px;">Save</span>
            </div>
        </div>
    </div>
    <div id="CreateCategory" title="Create New Category">
        <div id="CreateCategoryDiv">
            <span class="size12 width100cent floatleft">Category <span class="colorRed">*</span>
                <span class="colorRed floatRight displayNone" id="errCategory">Please enter category</span>
            </span>
            <input class="width100cent popupTextBox" id="txtNewCategoryName" />
            <span class="size12" style="width: 100%;">Parent Category</span>
            <select class="width100cent popupSelect" id="drpForCreateCategory">
            </select>
            <span class="btnnPopup size12" id="btnSaveCategory">Save</span>
        </div>
    </div>
    <div id="EditCategory" class="displayNone" title="Edit Category">
        <div id="EditCategoryDiv">
            <span class="size12 width100cent floatleft">Category <span class="colorRed">*</span>
                <span class="colorRed floatRight displayNone" id="errEditCategory">Please enter category</span>
            </span>
            <input class="popupTextBox width100cent" id="txtEditCategoryName" />
            <span class="size12 width100cent">Nested In</span>
            <select class="popupSelect width100cent" id="drpforEditCategory">
            </select>
            <span class="btnnPopup size12 btnEditSave">Save</span>
        </div>
    </div>
    <div id="UploadImage" class="displayNone" title="Uplaod Image">
        <div>
            <input type="file" accept="image/png,image/jpeg,application/pdf,application/vnd"
                id="UpadeInputfile" />
            <br />
            <br />
            <span class="btnnPopup btnUpdateImage">Update</span>  <span class="btnnPopup btnUpdateImageloading">
                <img style="vertical-align: middle" src="StyleSheets/Images/radimg1.gif" /></span> <span class="btnnPopup" id="btnCancelImage">Cancel</span>
        </div>
    </div>
    <div id="ImageDetails" class="displayNone" title="Image Details">
        <table id="ImageDetailsTables" class="width80">
            <tr>
                <td class="verticalAlignTop">
                    <div class="size12" id="ImageDetailsTitleDiv">
                        Title
                    </div>
                </td>
                <td class="verticalAlignTop">
                    <input id="txtImageName" class="popupTextBox ImageDetailsTextBox" type="text" />
                </td>
                <td class="verticalAlignTop" rowspan="6" style="padding-left: 40px;">
                    <div id="divImage">
                        <div id="changeimageshow" class="displayNone">
                            <span class="changeImage lnkchangeImage">Change Image</span>
                        </div>
                        <img src="StyleSheets/Images/noimage.jpg" width="250" height="200" id="imgEditImage" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="size12 width80">
                        Category
                    </div>
                </td>
                <td class="verticalAlignTop">
                    <select id="drpCategoryForImage" class="popupSelect">
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="size12 width80">
                        Meta Tags
                    </div>
                </td>
                <td class="verticalAlignTop">
                    <input id="txtMetaTags" type="text" class="popupTextBox ImageDetailsTextBox" />
                </td>
            </tr>
            <tr>
                <td class="verticalAlignTop">
                    <div class="size12 width80">
                        Description
                    </div>
                </td>
                <td class="verticalAlignTop">
                    <textarea id="txtEditDescription" class="popupTextarea"></textarea>
                </td>
            </tr>
            <tr>
                <td style="width: 75px;" class="verticalAlignTop">
                    <span class="size12"></span>
                </td>
                <td style="width: 250px;" class="verticalAlignTop">
                    <span class="btnnPopup btnupdateimagedetails" style="margin-right: 20px;">Update</span>
                    <span class="btnnPopup" id="btnCancelImageDetails">Cancel</span>
                </td>
            </tr>
        </table>
    </div>
    <div align="center" id="Imageeditor1" title="Image Editing Options" class="displayNone" style="width: 100%; z-index: 900; color: #45494A; font-size: 16px; font-weight: bold; font-style: normal;">
        <div id="divCropMain1" class="cropControlsTop cropControlsCrop"><i class="cropControlTitle">Drag image to crop</i></div>

        <div id="divCropMain2" class="cropControls cropControlsCrop" style="clear: both; left: 209.5px; top: 23px;">

            <i class="cropControlZoomMuchIn"></i>
            <i class="cropControlZoomIn"></i>
            <i class="cropControlZoomOut"></i>
            <i class="cropControlZoomMuchOut"></i>
            <i class="cropControlRotateLeft"></i>
            <i class="cropControlRotateRight"></i>

        </div>
        <div id="divCropMain3" class="cropControlsBelow cropControlsCrop" style="clear: both;">


            <i class="cropControlReset"></i>
            <i class="cropControlCrop"></i>

        </div>



        <div align="center" id="cropContainerModal" style="width: 100%; margin-top: 192px;">
        </div>
    </div>

    <div id="Imageeditor" title="Edit Image" class="displayNone" style="overflow: no-display;">
        <div id="ImageeditorDiv1">
            <form id="form" runat="server">
                <asp:ScriptManager runat="server" ID="RadScriptManager1">
                </asp:ScriptManager>
                <script type="text/javascript">
                    function GetEditor() {
                        var imEditor = $find("<%=RadImageEditor1.ClientID %>");
                        return imEditor;
                    }
                    function OnClientDialogLoaded(sender, eventArgs) {
                        $("#RadImageEditor1_ToolsPanel").removeClass("imageEditorPopUp");
                        $("#RadImageEditor1_ToolsPanel").addClass("imageEditorPopUp");
                    }


                    function modifyCommand(imageEditor, args) {

                        if (args.get_commandName()) {
                            waitForCommand(imageEditor, args.get_commandName(), function (widget) {
                                widget._constraintBtn.set_checked(false); //stop the aspect ration constraint
                                widget.set_width(orgWidthCrop);
                                widget.set_height(orgHeightCrop);
                                widget._widthTxt.disabled = false;
                                widget._heightTxt.disabled = false;
                                widget._updateCropBoxFromControls();
                            });
                        }
                    }

                    function waitForCommand(imageEditor, commandName, callback) {
                        var timer = setInterval(function () {
                            var widget = imageEditor.get_currentToolWidget();
                            if (widget && widget.get_name() == commandName) {
                                clearInterval(timer);
                                callback(widget);
                            }
                        }, 100);
                    }
                </script>
                <telerik:RadImageEditor ID="RadImageEditor1" OnImageSaving="RadImgEdt_ImageSaving"
                    OnClientDialogLoaded="OnClientDialogLoaded" runat="server" Height="400" CssClass="imageEditor"
                    ImageManager-MaxUploadFileSize="10240000" OnClientCommandExecuted="modifyCommand">
                    <Tools>
                        <telerik:ImageEditorToolGroup>
                            <telerik:ImageEditorToolStrip Text="Undo" CommandName="Undo" />
                            <telerik:ImageEditorToolStrip Text="Redo" CommandName="Redo" />
                            <telerik:ImageEditorTool Text="Reset" CommandName="Reset" />
                        </telerik:ImageEditorToolGroup>
                        <telerik:ImageEditorToolGroup>
                            <telerik:ImageEditorTool Text="Crop" CommandName="Crop" IsToggleButton="true" />
                            <telerik:ImageEditorTool Text="Resize" CommandName="Resize" IsToggleButton="true" />
                            <telerik:ImageEditorTool Text="Zoom" CommandName="Zoom" />
                            <telerik:ImageEditorTool Text="ZoomIn" CommandName="ZoomIn" />
                            <telerik:ImageEditorTool Text="ZoomOut" CommandName="ZoomOut" />
                            <telerik:ImageEditorTool Text="Opacity" CommandName="Opacity" IsToggleButton="true" />
                            <telerik:ImageEditorTool Text="Rotate" CommandName="Rotate" IsToggleButton="true" />
                            <telerik:ImageEditorTool Text="Rotate Right" CommandName="RotateRight" />
                            <telerik:ImageEditorTool Text="Rotate Left" CommandName="RotateLeft" />
                            <telerik:ImageEditorTool Text="Flip" CommandName="Flip" IsToggleButton="true" />
                            <telerik:ImageEditorTool Text="Flip Vertical" CommandName="FlipVertical" />
                            <telerik:ImageEditorTool Text="Flip Horizontal" CommandName="FlipHorizontal" />
                            <telerik:ImageEditorTool Text="Add Text" CommandName="AddText" IsToggleButton="true" />
                        </telerik:ImageEditorToolGroup>
                        <telerik:ImageEditorToolGroup>
                            <telerik:ImageEditorTool Text="Brightness Contrast" CommandName="BrightnessContrast"
                                IsToggleButton="true" />
                            <telerik:ImageEditorTool Text="Invert Color" CommandName="InvertColor" />
                            <telerik:ImageEditorTool Text="Sepia" CommandName="Sepia" />
                            <telerik:ImageEditorTool Text="Greyscale" CommandName="Greyscale" />
                            <telerik:ImageEditorTool Text="Hue Saturation" CommandName="HueSaturation" IsToggleButton="true" />
                        </telerik:ImageEditorToolGroup>
                        <telerik:ImageEditorToolGroup>
                            <telerik:ImageEditorTool Text="Pencil" CommandName="Pencil" IsToggleButton="true" />
                            <telerik:ImageEditorTool Text="Draw Circle" CommandName="DrawCircle" IsToggleButton="true" />
                            <telerik:ImageEditorTool Text="Draw Rectangle" CommandName="DrawRectangle" IsToggleButton="true" />
                            <telerik:ImageEditorTool Text="Line" CommandName="Line" IsToggleButton="true" />
                        </telerik:ImageEditorToolGroup>
                    </Tools>
                </telerik:RadImageEditor>
            </form>
        </div>
    </div>
    <div id="ImageFromGallery" title="Image Gallery">
        <div class="loading_gallery loading_galleryMask">
        </div>
        <div class="loading_gallery loading_galleryImage">
            <img src="StyleSheets/Images/loading_new.gif" alt="Loading..." />
        </div>
        <div id="thumbnailButtons">
            <div class="floatRight">
                <span class="btnnPopup displayNone" id="btnUnSelectAll">Unselect All</span> <span
                    class="btnnPopup" id="btnSelectAll">Select All</span> <span class="btnnPopup" id="btnDeletetAll">Delete Selected</span> <span class="popupTextBox_Span">
                        <input type="text" class="size12 txtSearchText" placeholder="Enter Search Text" />
                    </span><span class="ClearSearchText_Span">
                        <img src="StyleSheets/Images/delete_icon1.png" width="16" height="16" class="btnClearSearchText"
                            title="Clear Search Text" />
                    </span>
            </div>
        </div>
        <div id="tabs">
            <ul>
                <li><a href="#Gallery" id="galleryLink">System Gallery</a></li>
                <li><a href="#UserGallery" id="usergallerylink">User Gallery</a></li>
                <li><a href="#FileUplaod" id="fileUploadLink">File Upload</a></li>
            </ul>
            <div id="Gallery">
                <div id="thumNail">
                </div>
                <div class="Gallery_backButton">
                    <span class="btnnPopup btnBack" style="display: none; margin-left: 20px;">Back</span>
                </div>
            </div>
            <div id="UserGallery">
                <div id="userthamnail">
                </div>
                <div class="UserGallery_backButton">
                    <span class="btnnPopup btnUserBack" style="display: none; margin-left: 20px;">Back</span>
                </div>
                <%--<span class="btnnPopup" style="display: none; margin-left: 20px;" id="btnUserShowMore">Show More</span>--%>
            </div>
            <div id="FileUplaod">
                <div id="fileUploadDiv1">
                    <div id="fileUploadDiv">
                        <div class="filesuploadpanel">
                            <div class="size12 selectfilestext">
                                Select files to upload
                            </div>
                            <div id="fileList">
                            </div>
                            <div id="TotalDiv">
                                <div id="totalContainer">
                                    Total<span id="Total"></span>
                                </div>
                            </div>
                            <div style="width: 350px; height: 37px; background: linear-gradient( #FFFFFF,#F8F8F8,#F0F0F0);">
                                <%-- <input id="multipleFileUpload" name="multipleFileUpload" accept="image/png,image/jpeg,application/pdf,application/vnd"
                                    type="file" multiple class="custom-file-input" style="height: 30px; padding: 5px 5px 5px 5px; width: 75px; float: left; display: none;" />
                                <span class="btnnPopupBrowse size12" style="margin-left: 275px; padding: 5px 10px 5px 10px; margin-top: 5px; margin-right: 10px;"
                                    id="btnSelectFiles"><span id="btnuploadtxt">Browse</span></span>--%>
                                <span class="btnnPopupBrowse size12" id="btnSelectFiles" style="height: 14px; width: 40px; margin-left: 275px; padding: 5px 10px 5px 10px; margin-top: 5px; margin-right: 10px;">
                                    <span id="btnuploadtxt">Browse</span>
                                    <input id="multipleFileUpload" name="multipleFileUpload" accept="image/png,image/jpeg,application/pdf,application/vnd"
                                        type="file" multiple class="custom-file-input" style="padding: 5px 5px 5px 5px; float: left;" />
                                </span>

                                <%--<span class="btnnPopup size12"
                                    style="padding: 6px 10px 6px 10px; margin-top: 14px; margin-right: 10px; float: right;"
                                    id="btnClearmultipleFileUpload">Clear All</span>--%>
                            </div>
                        </div>
                        <div style="display: block; padding-top: 5px;">
                            <input type="checkbox" id="chkSvaeImagetomyGallery" style="vertical-align: middle;" /><label
                                class="size12" for="chkSvaeImagetomyGallery">Save Images to My gallery</label>
                        </div>
                        <div id="selectCat" style="display: none; padding: 5px;">
                            <span class="size12" style="padding-right: 10px;">Select Category</span>
                            <select id="drpSelectCategory">
                            </select>
                            <span class="btnnPopup" id="btnNewCategoryPopUp" title="Create New Category">Add New
                                Category</span>
                        </div>
                        <input type="button" id="btnUpload" class="btnnPopup " value="Save" />
                        <div style="padding-top: 10px;">
                            <div class="size11" style="font-weight: bold;">
                                Image guidelines
                            </div>
                            <div class="size11">
                                You can upload these file types into an editable product: Jpeg, Png, PDF
                            </div>
                            <div class="size11">
                                When uploading a PDF only single page files can be used.
                            </div>
                            <div class="size11">
                                PDF files will not be able to be cropped or rotated by the end user in the editable product.
                            </div>
                            <div class="size11">
                                PDF files over 2MB will be uploaded in the background and it will take upto 15 minutes
                                to load.
                            </div>
                            <%-- <div class="size11">
                                Please upload JPEG or PNG file wherever possible as this will lead to faster screen response time.
                            </div>--%>
                        </div>
                    </div>
                    <div id="FilePropertiesDiv" style="display: none; overflow-y: auto; border: 1px solid #A9A9A9;">
                    </div>
                    <div id="FilePropertiesButtonDiv">
                        <span class="btnnPopup" id="btnImageSaveCancel" style="margin-left: 425px;">Cancel</span>
                        <span style="margin-left: 10px;" class="btnnPopup" id="btnImageSaveChanges">Save Changes</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
