<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editableproduct.aspx.cs" Inherits="HTML5TemplateEditor.editableproduct" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Editable Product</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <link href="StyleSheets/common.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <link rel="stylesheet" href="StyleSheets/jquery-ui.css" />
    <script src="js/Jquery-1.11.1.js" type="text/javascript"></script>

    
<%--    <script>document.write("<script type='text/javascript' src='js/jquery-3.0.0.js?v=" + Date.now() + "'><\/script>");</script>      
    <script>document.write("<script type='text/javascript' src='js/jquery-migrate-3.0.0.min.js?v=" + Date.now() + "'><\/script>")</script>--%>

    <script src="js/Jquery-ui-1.11.0.js" type="text/javascript"></script>
    <script src="js/jquery.ui.touch-punch.min.js"></script>
    <%--<script src="js/common.js" type="text/javascript"></script>
    <script src="js/LeftPanelChange.js" type="text/javascript"></script>
    <script src="js/LoadPage.js" type="text/javascript"></script>--%>
    <script src="js/TemplateEditor.js?4" type="text/javascript"></script>
    <link href="StyleSheets/jquery.colorpicker.css" rel="stylesheet" />
    <script src="js/jquery.colorpicker.js" type="text/javascript"></script>
</head>
<body>
    <%--Progress Bar--%>
    <div id="loading">
        <img src="StyleSheets/Images/loading_new.gif" alt="Loading..." />
    </div>
    <div class="loading_new loadingNewMask">
    </div>
    <div class="QuickAdjustloadingNewMask QuickAdjustloadingNew">
    </div>
    <div class="MangaeGrouploadingNewMask MangaeGrouploadingNew">
    </div>
    <div class="MessagesPopuploadingNewMask MessagesPopuploadingNew">
    </div>
    <div class="ErrorMsgloadingNewMask ErrorMsgloadingNew">
    </div>
    <div class="loading_new loadingNew">
        <img src="StyleSheets/Images/loading_new.gif" alt="Loading..." />
    </div>
    <%--Progress Bar End--%>
    <%--Main Template--%>
    <div id="template">
        <label class="productName" id="lblProductName">
        </label>
        <input type="button" value="button" id="btncheck" style="display: none;" />
        <table id="Table1" class="MainDesigncanvas" border="1">
            <tr>
                <td class="lefpaneltd">
                    <div class="lefpaneltddiv">
                        <%--Left Panel Buttons--%>
                        <div class="paddingleft10pxright10pxbottom1px">
                            <span class="LeftPannelbutton paddingright7px " title="Add Single Line Text" onclick="Javascript:AddText();"
                                id="btnAddText">
                                <img src="StyleSheets/Images/insert-text.png" class="LeftPannelmenuimg addtextimg"
                                    alt="Add Text" />
                                <span class="buttonText">Add Text</span> </span><span class="LeftPannelbutton paddingright3px "
                                    title="Add Image" onclick="Javascript:AddImage();" id="btnAddImg">
                                    <img src="StyleSheets/Images/addimg.jpg" class="LeftPannelmenuimg" alt="Add Image" />
                                    <span class="buttonText">Add Image</span> </span><span class="LeftPannelbutton paddingright3px"
                                        title="Add Paragraph" onclick="Javascript:AddPara();" id="btnAddPara">
                                        <img src="StyleSheets/Images/paragraph.png" class="LeftPannelmenuimg" alt="Add Paragraph" />
                                        <span class="buttonText" style="padding-left: 0px;">Add Paragraph</span>
                                    </span>
                        </div>
                        <div class="paddingleft10pxright10pxbottom1px">
                            <span class="LeftPannelbutton paddingright3px " title="Add Date" onclick="Javascript:AddDate();"
                                id="btnAddDate">
                                <img src="StyleSheets/Images/calender-text.png" class="LeftPannelmenuimg"
                                    alt="Add Date" />
                                <span class="buttonText">Add Date</span> </span>
                            <span runat="server" class="LeftPannelbutton paddingright4px" title="Quick Adjust"
                                id="btnQuickAdjust" onclick="Javascript:openQuickAdjust();">
                                <img src="StyleSheets/Images/quickadjust.png" class="LeftPannelmenuimg" alt="Quick Adjust" />
                                <span class="buttonText">Quick Adjust</span> </span><span runat="server" class="LeftPannelbutton paddingright4px "
                                    title="Manage Group" id="btnManageGroup" onclick="Javascript:openManageGroup();">
                                    <img src="StyleSheets/Images/stock_group.png" class="LeftPannelmenuimg" alt="Manage Group" />
                                    <span class="buttonText">Manage Group</span> </span>
                        </div>
                        <%--Left Panel Buttons End--%>
                        <%--Accordion--%>
                        <div id="accordion">
                            <h3 class="TextBlock">TEXTBLOCK</h3>
                            <div style="margin: 0px; padding: 0px; border-width: 0px;">
                            </div>
                            <h3 class="ImagePanel">IMAGE</h3>
                            <div style="margin: 0px; padding: 0px; border-width: 0px;">
                            </div>
                            <h3 class="ParaGraph">PARAGARAPH</h3>
                            <div style="margin: 0px; padding: 0px; border-width: 0px;">
                            </div>
                            <h3 class="InformationPanel">INFORMATION</h3>
                            <div style="margin: 0px; padding: 0px;" class="content contentInformationPanel ">
                                <div class="Information">
                                    <div class="marginbottom10px">
                                        <span class="displayblock padding2px">Field Name</span>
                                        <input type="text" class="TextBoxWidth200" id="txtFieldName" />
                                    </div>
                                    <div class="marginbottom10px">
                                        <span class="displayblock padding2px">Friendly Name</span>
                                        <input type="text" class="TextBoxWidth200" id="txtFriendly" />
                                    </div>
                                    <div class="marginbottom10px">
                                        <span class="displayblock padding2px">Help Text</span>
                                        <input type="text" class="TextBoxWidth200" id="txtHelpText" />
                                    </div>
                                    <div class="checkboxes">
                                        <span class="displayblock"><span class="displayinlineblock width100px">
                                            <input type="checkbox" id="chkMandatory" />
                                            <label for="chkMandatory" class="verticalMiddle">
                                                Mandatory</label>
                                        </span>
                                            <input type="checkbox" id="chkNonEditable" />
                                            <label for="chkNonEditable" class="verticalMiddle">
                                                Non Editable</label>
                                        </span><span class="displayblock paddingtop4px"><span class="displayinlineblock width100px"></span>
                                            <input type="checkbox" id="chkHideFromuser" />
                                            <label for="chkHideFromuser" class="verticalMiddle">
                                                Hide from the end user</label>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <h3 class="PropertiesPanel">PROPERTIES</h3>
                            <div style="margin: 0px; padding: 0px;" class="content contentProperties">
                                <div class="Properties">
                                    <div class="paddingbottom5px">
                                        <span class="displayinlineblock width120px">
                                            <label class="displayblock padding1px floatleft">
                                                Position X-from left</label>
                                            <input type="text" class="TextBoxWidth50 floatleft" id="txtImagePostionX" onkeyup='return validateQty(event);'
                                                oninput='vaild(event);' />
                                            <span class="floatleft paddingleft2pxtop3px">mm</span> </span><span class="displayinlineblock width120px">
                                                <label class="displayblock padding1px floatleft">
                                                    Y-from bottom</label>
                                                <input type="text" class="TextBoxWidth50 floatleft" id="txtImagePostionY" onkeyup='return validateQty(event);'
                                                    oninput='vaild(event);' />
                                                <span class="floatleft paddingleft2pxtop3px">mm</span> </span>
                                    </div>
                                    <div class="paddingbottom5px">
                                        <input type="checkbox" id="chkImageLockPosition" />
                                        <label for="chkImageLockPosition">
                                            Lock positions for the end user</label>
                                    </div>
                                    <div class="paddingbottom8px">
                                        <span class="displayinlineblock width120px">
                                            <label class="displayblock padding1px floatleft">
                                                Image Height</label>
                                            <input type="text" class="TextBoxWidth50 floatleft" id="txtMaxImageHeight" onkeyup='return validateQty(event);'
                                                oninput='vaild(event);' />
                                            <span class="floatleft paddingleft2pxtop3px">mm</span> </span><span class="displayinlineblock width120px">
                                                <label class="displayblock padding1px floatleft">
                                                    Image Width</label>
                                                <input type="text" class="TextBoxWidth50 floatleft" id="txtMaxImageWidth" onkeyup='return validateQty(event);'
                                                    oninput='vaild(event);' />
                                                <span class="paddingleft2pxtop3px floatleft">mm</span>
                                                <img class="floatRight" src="StyleSheets/Images/info.png" width="18" height="18"
                                                    title="Image will resize to these dimensions" />
                                            </span>
                                    </div>
                                    <div class="paddingbottom10px">
                                        <label class="displayblock padding2px">
                                            Image Source:</label>
                                        <span class="displayblock paddingbottom5px">
                                            <input type="checkbox" id="chkImageFromGallery" />
                                            <span class="imageSouceLink" id="lnkAddFromGallery">Add image from gallery.</span>
                                        </span><span class="displayblock paddingbottom5px">
                                            <input type="checkbox" id="chkImagefromHardDrive" />
                                            <span class="imageSouceLink" id="lnkAddFromHardDrive">Add image from user's hard drive.</span>
                                        </span>
                                        <span class="displayblock paddingbottom5px">
                                            <input type="checkbox" id="chkImageFromDropDown" /><label for="chkImageFromDropDown" class="paddingleft5px verticalMiddle">Add Image From:</label>
                                            <select class="SelectWidth150  width100px" id="drpImageFrom">
                                                <option value="None">Select</option>
                                                <option value="Contact">Contact</option>
                                                <option value="Department">Department</option>
                                            </select>
                                        </span>
                                        <span class="displayblock paddingbottom5px">
                                            <input type="checkbox" id="ChkAllowUserEdit" /><label for="ChkAllowUserEdit" class="paddingleft5px verticalMiddle">Allow User to Edit Image</label>
                                        </span>
                                        <span class="displayblock paddingbottom5px">
                                            <input type="checkbox" id="chkBackground" /><label for="chkBackground" class="paddingleft5px verticalMiddle">Set
                                                as background</label>
                                        </span>
                                        <%--<span class="displayblock">
                                            <input type="checkbox" id="chkImageQuality" /><label for="chkImageQuality" class="paddingleft5px verticalMiddle">Image Quality</label>
                                        </span>
                                        <div class="displayblock" id="DPI_Panel">
                                            <label >Min DPI: </label><input type="text" id="txtDPI" class="TextBoxWidth50" style="width: 40px;" onkeyup='return validateQty(event);' oninput='vaild(event);'  />
                                        </div>--%>

                                        <div class="paddingbottom5px">
                                            <input type="checkbox" id="chkImageIsDisplayOnPDF" />
                                            <label for="chkImageIsDisplayOnPDF">
                                                Hide image from the Final PDF</label>
                                        </div>
                                    </div>
                                    <div class="paddingbottom10px">
                                        <label class="displayblock padding2px">
                                            Cordinates aligned to:</label>
                                        <select class="SelectWidth150 displayblock width100px" id="drpImageLocation">
                                            <option value="TL" id="TL">Top Left</option>
                                            <option value="TC" id="TC">Top Center</option>
                                            <option value="TR" id="TR">Top Right</option>
                                            <option value="C" id="C">Center</option>
                                            <option value="CR" id="CR">Center Right</option>
                                            <option value="CL" id="CL">Center Left</option>
                                            <option value="BL" id="BL">Bottom Left</option>
                                            <option value="BC" id="BC">Bottom Center</option>
                                            <option value="BR" id="BR">Bottom Right</option>
                                        </select>
                                    </div>
                                    <div class="radibuttons width225px margintop3px">
                                        <label class="displayblock padding2px">
                                            On exceeding width and height</label>
                                        <span class="displayblock paddingtop2pxbottom2px">
                                            <input type="radio" name="OnexeedingImage" checked="checked" class="x" id="rdoImagePropotional" />
                                            <label for="rdoImagePropotional">
                                                Retain Aspect Ratio</label>
                                            <img style="float: right;" height="18" width="18" src="StyleSheets/Images/info.png"
                                                title="The image will be resized in proportion to fit the image box retaining the aspect ratio, so it may not fit the box exactly." />
                                        </span><span class="displayblock paddingtop2pxbottom2pxleft27px">
                                            <input type="checkbox" id="ChkCropfromtop" />
                                            <label for="ChkCropfromtop">
                                                Auto crop from top</label>
                                            <img style="float: right;" height="18" width="18" src="StyleSheets/Images/info.png"
                                                title="This function only applies when using the proportional to image control setting. The image will be resized to fit the box and retain its aspect ratio. Any excess height of the image will be cropped to enable the image to fit the set image area on the product." />
                                        </span><span class="displayblock paddingtop2pxbottom2px">
                                            <input type="radio" name="OnexeedingImage" id="rdoImageScaleToFit" />
                                            <label for="rdoImageScaleToFit">
                                                Scale to fit</label>
                                            <img style="float: right;" height="18" width="18" src="StyleSheets/Images/info.png"
                                                title="The image will be sized to fit the image box and may lose its aspect ratio." />
                                        </span><span class="displayblock paddingtop2pxbottom2px">
                                            <input type="radio" name="OnexeedingImage" class="x" id="rdoImageDoNothing" />
                                            <label for="rdoImageDoNothing">
                                                Do Nothing</label>
                                            <img style="float: right;" height="18" width="18" src="StyleSheets/Images/info.png"
                                                title="The image will be used in the product at its original size." />
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <h3 class="LayoutPanel">LAYOUT</h3>
                            <div style="margin: 0px; padding: 0px;" class="content contentLayout">
                                <div class="Layout">
                                    <div class="paddingbottom5px">
                                        <span class="displayinlineblock width120px">
                                            <label class="displayblock padding1px floatleft">
                                                Position X-from left</label>
                                            <input type="text" class="TextBoxWidth50 floatleft" id="txtPostionX" onkeyup='return validateQty(event);'
                                                oninput='vaild(event);' />
                                            <span class="paddingleft2pxtop3px floatleft">mm</span> </span><span class="displayinlineblock width120px">
                                                <label class="displayblock padding1px floatleft">
                                                    Y-from bottom</label>
                                                <input type="text" class="TextBoxWidth50 floatleft" id="txtPostionY" onkeyup='return validateQty(event);'
                                                    oninput='vaild(event);' />
                                                <span class="paddingleft2pxtop3px floatleft">mm</span> </span>
                                    </div>
                                    <div class="checkboxes paddingbottom6px">
                                        <input type="checkbox" id="chkLockPosition" />
                                        <label for="chkLockPosition">
                                            Lock positions for the end user</label>
                                    </div>
                                    <div class="paddingbottom10px">
                                        <span class="displayinlineblock width120px">
                                            <label class="displayblock padding1px floatleft">
                                                Max Width</label>
                                            <input type="text" class="TextBoxWidth50 floatleft" id="txtMaxWidth" onkeyup='return validateQty(event);'
                                                oninput='vaild(event);' />
                                            <span class="paddingleft2pxtop3px floatleft">mm</span> </span><span class="displayinlineblock input paraLayoutExtra width120px">
                                                <label class="displayblock padding1px floatleft">
                                                    Max Height</label>
                                                <input type="text" class="TextBoxWidth50 floatleft" id="txtMaxHeight" onkeyup='return validateQty(event);'
                                                    oninput='vaild(event);' />
                                                <span class="paddingleft2pxtop3px floatleft">mm</span> </span><span class="displayinlineblock input textLayoutExtra width120px">
                                                    <label class="displayblock padding1px floatleft">
                                                        Rotate Angle</label>
                                                    <input type="text" class="TextBoxWidth50 txtRotateX floatleft" onkeyup='return validateQty(event);'
                                                        oninput='vaild(event);' />
                                                    <span class="paddingleft2pxtop3px floatleft" style="font-size: 14px;">°</span>
                                                </span>
                                    </div>
                                    <div class="paraLayoutExtra paddingbottom6px">
                                        <span class="displayinlineblock input width120px">
                                            <label class="displayblock padding1px floatleft">
                                                Rotate Angle</label>
                                            <input type="text" class="TextBoxWidth50 txtRotateX floatleft" onkeyup='return validateQty(event);'
                                                oninput='vaild(event);' />
                                            <span class="paddingleft2pxtop3px floatleft" style="font-size: 14px;">°</span>
                                        </span><span class="displayinlineblock input width120px">
                                            <label class="displayblock padding1px floatleft">
                                                Line Spacing</label>
                                            <input type="text" class="TextBoxWidth50 floatleft" id="txtLineSpacing" onkeyup='return validateQty(event);'
                                                oninput='vaild(event);' />
                                            <span class="paddingleft2pxtop3px floatleft">mm</span> </span>
                                    </div>
                                    <div class="LayoutText">
                                        <label class="displayblock padding1px">
                                            On exceeding width</label>
                                        <span class="displayblock paddingleft10px">
                                            <input type="radio" checked="checked" name="Onexeeding" id="rdtextDonothing" />
                                            <label for="rdtextDonothing">
                                                Do Nothing</label>
                                        </span><span class="displayblock paddingleft10px">
                                            <input type="radio" name="Onexeeding" id="rdtextSideWays" />
                                            <label for="rdtextSideWays">
                                                Auto expand side ways</label>
                                        </span><span class="displayblock paddingleft10px">
                                            <input type="radio" name="Onexeeding" id="rdtextShrink" />
                                            <label for="rdtextShrink">
                                                Shrink text to fit field size</label>
                                        </span><span class="displayblock paddingleft10px">
                                            <input type="radio" name="Onexeeding" id="rdtextTrscking" />
                                            <label for="rdtextTrscking">
                                                Adjust tracking to fit field size</label>
                                        </span><span class="displayblock" style="padding-left: 27px; padding-top: 3px;">
                                            <input type="text" class="TextBoxWidth50" style="width: 40px;" id="txttextTrscking"
                                                value="1" onkeyup="this.value = minmaxtrack(this.value, 1, 100)" />
                                            <span>%</span> </span>
                                    </div>
                                    <div class="LayoutPara paddingtop5px">
                                        <div class="radibuttons">
                                            <span class="displayblock" id="onexeedingpara">
                                                <img src="StyleSheets/Images/up-arrow-icon.png" height="20" width="20" style="cursor: pointer;" />
                                                <span>On exceeding Height</span> </span><span class="displayblock" id="onexeedingparadiv">
                                                    <span class="displayblock">
                                                        <input type="radio" name="Onexeeding" id="rdparaDonothing" />
                                                        <label for="rdparaDonothing">
                                                            Do Nothing</label>
                                                    </span><span class="displayblock">
                                                        <input type="radio" name="Onexeeding" id="rdparaSideWays" />
                                                        <label for="rdparaSideWays">
                                                            Auto expand downwards</label>
                                                    </span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <h3 class="FontPanel">FONT</h3>
                            <div style="margin: 0px; padding: 0px;" class="content  contentFontPanel">
                                <div class="FontPanel">
                                    <div class="chooseStyle paddingbottom6px">
                                        <span class="displayblock padding1px">Choose Style</span>
                                        <select class="dropdown width150px" id="drpFontStyle">
                                            <option value="0" id="drpFontStyleID0">--Select--</option>
                                        </select>
                                    </div>
                                    <div class="FontStyle paddingbottom6px">
                                        <label class="displayblock padding1px">
                                            Font Style</label>
                                        <input type="text" class="TextBoxWidth200" id="txtFontStyle" />
                                    </div>
                                    <div class="paddingbottom8px">
                                        <span class="Font displayinlineblock width115px">
                                            <label class="displayblock padding1px floatleft">
                                                Font</label>
                                            <select style="width: 110px;" id="drpApplyFont" class="smallselect floatleft">
                                            </select>
                                        </span><span class="Size displayinlineblock width65px">
                                            <label class="displayblock padding1px floatleft">
                                                Size</label>
                                            <input type="text" class="TextBoxWidth50 width40px floatleft" id="txtFontSize" onkeyup='return validateQty(event);'
                                                oninput='vaild(event);' />
                                            <span class="floatleft paddingleft1pxtop3px">pt</span> </span><span class="Indent displayinlineblock width70px">
                                                <label class="displayblock padding1px floatleft">
                                                    Indent</label>
                                                <input type="text" class="TextBoxWidth50 width40px floatleft" id="txtFontIndent"
                                                    onkeyup='return validateQty(event);' oninput='vaild(event);' />
                                                <span class="floatleft paddingleft1pxtop3px">mm</span> </span>
                                    </div>
                                    <div class="paddingbottom3px">
                                        <span class="ManualTracking displayinlineblock width185px">
                                            <label class="displayblock padding1px">
                                                Manual Tracking</label>
                                            <select id="drpManualTrackSign" class="smallselect width45px" style="margin-right: 2px;">
                                                <option value="+" id="drpManualTrackSign1">+</option>
                                                <option value="-" id="drpManualTrackSign2">-</option>
                                            </select>
                                            <input type="text" class="TextBoxWidth50 width50px" id="txtManulTracking" onkeyup='return validateQty(event);'
                                                oninput='vaild(event);' style="margin-right: 2px;" />
                                            <select id="drpManualTrackDimension" class="smallselect width60px">
                                                <option value="pt" id="drpManualTrackDimensionpt">pt</option>
                                                <option value="mm" id="drpManualTrackDimensionmm">mm</option>
                                            </select>
                                        </span><span class="datatype displayinlineblock width75px">
                                            <label class="displayblock padding1px">
                                                DataType</label>
                                            <select id="drpDataType" class="smallselect width90px">
                                                <option value="Text" id="drpDataTypeText">Text</option>
                                                <option value="Number" id="drpDataTypeNumber">Number</option>
                                            </select>
                                        </span>
                                    </div>
                                    <div class="paddingbottom3px">
                                        <input type="checkbox" id="chkParagraphJustify" />
                                        <label for="chkParagraphJustify">
                                            Use paragraph justification</label>
                                    </div>
                                    <div class="paddingbottom2px">
                                        <div class="radibuttons displayinlineblock width90px" id="justify">
                                            <img src="StyleSheets/Images/up-arrow-icon.png" height="20" width="20" style="cursor: pointer;" />
                                            <label for="justify">
                                                Justify</label>
                                        </div>
                                        <div class="displayinlineblock radibuttons" id="capitilization">
                                            <img src="StyleSheets/Images/up-arrow-icon.png" height="20" width="20" style="cursor: pointer;" />
                                            <label for="capitilization">
                                                Capitalization</label>
                                        </div>
                                        <div style="display: none;" class="toggle">
                                            <div class="displayinlineblock width90px">
                                                <div class="displayblock" id="justifydiv">
                                                    <input type="radio" name="justify" id="rdLeftJustify" /><label for="rdLeftJustify">Left</label><br />
                                                    <input type="radio" name="justify" id="rdCenterJustify" /><label for="rdCenterJustify">Center</label><br />
                                                    <input type="radio" name="justify" id="rdRightJustify" /><label for="rdRightJustify">Right</label>
                                                </div>
                                            </div>
                                            <div class="displayinlineblock">
                                                <div class="displayblock" id="capitilizationdiv">
                                                    <span class="displayblock">
                                                        <input type="radio" name="Capitilization" id="rdUserInput" />
                                                        <label for="rdUserInput">
                                                            As per user input</label>
                                                    </span><span class="displayblock">
                                                        <input type="radio" name="Capitilization" id="rdAllUpper" />
                                                        <label for="rdAllUpper">
                                                            All upper case</label>
                                                    </span><span class="displayblock">
                                                        <input type="radio" name="Capitilization" id="rdFirstLetterCapsDontAllowCaps" style="vertical-align: middle;" />
                                                        <label for="rdFirstLetterCapsDontAllowCaps">
                                                            First word first letter caps <span style="padding-left: 18px; display: block;">- do
                                                                not allow other caps</span>
                                                        </label>
                                                    </span><span class="displayblock">
                                                        <input type="radio" name="Capitilization" id="rdFirstLetterCapsAllowCaps" style="vertical-align: middle;" />
                                                        <label for="rdFirstLetterCapsAllowCaps">
                                                            First word first letter caps<span style="padding-left: 18px; display: block;">- allow
                                                                other caps</span></label>
                                                    </span><span class="displayblock">
                                                        <input type="radio" name="Capitilization" id="rdAllWordFirstCapsDontAllowCaps" style="vertical-align: middle;" />
                                                        <label for="rdAllWordFirstCapsDontAllowCaps">
                                                            All word first letter caps <span style="padding-left: 18px; display: block;">- do not
                                                                allow other caps</span>
                                                        </label>
                                                    </span><span class="displayblock">
                                                        <input type="radio" name="Capitilization" id="rdAllWordFirstCapsAllowCaps" style="vertical-align: middle;" />
                                                        <label for="rdAllWordFirstCapsAllowCaps">
                                                            All word first letter caps<span style="padding-left: 18px; display: block;">- allow
                                                                other caps</span></label>
                                                    </span><span class="displayblock">
                                                        <input type="radio" name="Capitilization" id="rdAllLower" />
                                                        <label for="rdAllLower">
                                                            All lower case</label>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <h3 class="ColorPanel">COLOUR</h3>
                            <div style="margin: 0px; padding: 0px;" class="content contentColorPanel">
                                <div class="color">
                                    <div class="chooseStyle" style="padding-bottom: 5px;">
                                        <label class="displayblock padding2px">
                                            Choose Style</label>
                                        <select class="dropdown" id="drpColorStyle" style="width: 175px;">
                                            <option value="0" id="drpColorStyleID0">--Select--</option>
                                        </select>
                                        <span id="colorStleRextangle"></span>
                                    </div>
                                    <div style="padding-bottom: 5px;">
                                        <label class="displayblock padding2px">
                                            Colour Style</label>
                                        <input type="text" class="TextBoxWidth200" id="txtColorStyle" style="width: 150px;" />
                                    </div>
                                    <div style="padding-bottom: 5px;">
                                        <input type="checkbox" id="chkSpotColor" style="margin: 5px 0px 5px 0px;" />
                                        <label for="chkSpotColor">
                                            Use Spot Color</label>
                                        <label class="displayblock padding2px">
                                            Spot Colour Ref: (Pantone or other name)</label>
                                        <input type="text" class="TextBoxWidth200" id="txtSpotColor" style="width: 150px;" />
                                    </div>
                                    <div>
                                        <label style="font-weight: bold;">
                                            CMYK Colour Code</label>
                                    </div>
                                    <div class="colorcode">
                                        <span class="cp-128"></span>
                                    </div>
                                </div>
                            </div>
                            <h3 class="DefaultContentPanel">DEFAULT CONTENT</h3>
                            <div style="margin: 0px; padding: 0px;" class="content contentDefaultContentPanel">
                                <div class="DefaultContent">
                                    <div class="defaultcontenttext paddingbottom10px">
                                        <span class="displayblock">
                                            <input type="radio" name="DefaultContent" id="defaultcontenttext" checked="checked" />
                                            <label for="defaultcontenttext">
                                                Enter your default content text</label>
                                        </span><span class="displayblock paddingleft15pxtop3px">
                                            <input type="text" class="TextBoxWidth200" id="txtDefaultContent" />
                                            <textarea id="txtParaDefaultContent"></textarea>
                                        </span>
                                    </div>
                                    <div class="selectcontent paddingbottom10px">
                                        <span class="displayblock">
                                            <input type="radio" name="DefaultContent" id="selectcontent" />
                                            <label for="selectcontent">
                                                Select content from database</label>
                                        </span><span class="displayblock paddingleft15pxtop3px">
                                            <input type="text" class="TextBoxWidth200" id="txtDatabaseContent" />
                                        </span><span class="displayblock paddingleft15pxtop6px">
                                            <select class="dropdown" id="drpContactFields">
                                                <option id="drpContactFields0">Contact Fields</option>
                                            </select>
                                        </span><span class="displayblock paddingleft15pxtop6px">
                                            <select class="dropdown" id="drpDepartmentFields">
                                                <option id="drpDepartmentFields0">Department Fields</option>
                                            </select>
                                        </span>
                                    </div>
                                    <div class="selectDropdowns paddingbottom10px">
                                        <span class="displayblock">
                                            <input type="radio" name="DefaultContent" id="selectDropdowns" />
                                            <label for="selectDropdowns">
                                                Select dropdowns</label>
                                        </span><span class="displayblock paddingleft15pxtop1px">
                                            <input type="radio" name="selectDropdowns" class="Dropdowns" id="rdContactdrp" />
                                            <label for="rdContactdrp">
                                                Contact Name</label>
                                        </span><span class="displayblock paddingleft15px">
                                            <input type="radio" name="selectDropdowns" class="Dropdowns" id="rdDepatmentdrp" />
                                            <label for="rdDepatmentdrp">
                                                Department Name</label>
                                        </span><span class="displayblock paddingleft15px">
                                            <input type="radio" name="selectDropdowns" class="Dropdowns" id="rdAddressdrp" />
                                            <label for="rdAddressdrp">
                                                Address Book</label>
                                        </span><span class="displayblock paddingleft15px">
                                            <input type="radio" name="selectDropdowns" id="rdPhrasedrp" />
                                            <label for="rdPhrasedrp">
                                                Phrase</label>
                                        </span><span class="displayblock paddingleft30px"><span>Select Option Title</span>
                                        </span><span class="displayblock paddingleft30pxtop3px">
                                            <select style="width: 190px;" id="drpPhraseCustomFields">
                                                <option value="0/" id="drpop_0">--Select--</option>
                                            </select>
                                        </span>
                                    </div>
                                    <div class="EditDropdown paddingbottom10px">
                                        <span class="displayblock">
                                            <input type="checkbox" id="Chk_EditDropdown" disabled="disabled"  />
                                            <label for="Chk_EditDropdown">Enable this drop down to be edited by the end user</label>
                                        </span>
                                    </div>
                                    <div class="BindJobName paddingbottom10px">
                                        <span class="displayblock">
                                            <input type="checkbox" id="chkJobNameField" />
                                            <label for="chkJobNameField">Map this field to the job name field</label>
                                        </span>
                                    </div>
                                    <div class="paddingbottom10px div_PhoneFormat">
                                        <span class="displayblock">
                                            <input type="checkbox" id="chkPhoneFormat" />
                                            <label for="chkPhoneFormat">Use Phone Number Format</label>
                                        </span>
                                        <span class="displayblock paddingleft30pxtop3px">
                                            <select style="width: 190px;" id="drpPhoneFormat" disabled>
                                                <option value="0" id="Option1">--Select--</option>
                                                <option value="##########" id="PhoneFormat2">##########</option>
                                                <option value="#### ### ###" id="PhoneFormat3">#### ### ###</option>
                                                <option value="#### ### ####" id="PhoneFormat4">#### ### ####</option>
                                                <option value="### ### ####" id="PhoneFormat5">### ### ####</option>
                                                <option value="### ### ## ##" id="PhoneFormat6">### ### ## ##</option>

                                                <option value="(###) ### ####" id="PhoneFormat7">(###) ### ####</option>
                                                <option value="(##) #### ####" id="PhoneFormat8">(##) #### ####</option>

                                                <option value="(+##) ### ### ####" id="PhoneFormat9">(+##) ### ### ####</option>
                                                <option value="(+##) ### ### ## ##" id="PhoneFormat10">(+##) ### ### ## ##</option>
                                                
                                                <option value="+## # #### ####" id="PhoneFormat11">+## # #### ####</option>
                                                <option value="+## ### ### ###" id="PhoneFormat12">+## ### ### ###</option>
                                                <option value="## #### ####" id="PhoneFormat13">## #### ####</option>
                                                 <option value="###.####.####" id="PhoneFormat14">###.####.####</option>
                                                <option value="+## ## ### ####" id="PhoneFormat15">+## ## ### ####</option>

                                                <option value="(#####) ### ###" id="PhoneFormat16">(#####) ### ###</option>
                                                <option value="##### ### ###" id="PhoneFormat17">##### ### ###</option>
                                                <option value="#### #### ###" id="PhoneFormat18">#### #### ### </option>
                                                <option value="+## ### #### ###" id="PhoneFormat19">+## ### #### ###</option>

                                                <option value="+## ### ### ####" id="PhoneFormat20">+## ### ### ####</option>
                                                <option value="###.###.####" id="PhoneFormat21">###.###.####</option>
                                                <option value="+## (#) #### ####" id="PhoneFormat22">+## (#) #### ####</option>
                                                <option value="+## # ### ####" id="PhoneFormat23">+## # ### ####</option>

                                                <%-- start  --%>
                                                <option value="+## ### ## ## ##" id="PhoneFormat24">+## ### ## ## ##</option>
                                                <option value="## ### ####" id="PhoneFormat25">## ### ####</option>
                                                <option value="+##.###.###.###" id="PhoneFormat26">+##.###.###.###</option>
                                                <option value="+##.#.####.####" id="PhoneFormat27">+##.#.####.####</option>

                                                <option value="#### ## ## ##" id="PhoneFormat28">#### ## ## ##</option>
                                                <option value="+## ## ### ###" id="PhoneFormat29">+## ## ### ###</option>
                                                <option value="#### ######" id="PhoneFormat30">#### ######</option>
                                                <option value="(###) ###-####" id="PhoneFormat31">(###) ###-####</option>
                                                <option value="+### #### ####" id="PhoneFormat32">+### #### ####</option>

                                                 <option value="+## (#)#### ### ###" id="PhoneFormat33">+## (#)#### ### ###</option>
                                                <option value="+## (#) #### ### ###" id="PhoneFormat34">+## (#) #### ### ###</option>
                                                <option value="+## (#)#### ######" id="PhoneFormat35">+## (#)#### ######</option>
                                                <option value="+### ### ### ###" id="PhoneFormat36">+### ### ### ###</option>
                                                <option value="+### ### ### ##" id="PhoneFormat37">+### ### ### ##</option>
                                                <option value="##### ### ###" id="PhoneFormat38">##### ### ###</option>
                                                <option value="##### ######" id="PhoneFormat39">##### ######</option>
                                                <option value="#.###.###.####" id="PhoneFormat40">#.###.###.####</option>
                                                <option value="###-###-####" id="PhoneFormat41">###-###-####</option>
                                                <option value="+## (#)# #### ####" id="PhoneFormat42">+## (#)# #### ####</option>
                                                <option value="+## (#)## #### ####" id="PhoneFormat43">+## (#)## #### ####</option>

                                            </select>
                                        </span>
                                    </div>

                                    <div class="paddingbottom10px div_CurrencyFormat" style="display: none">
                                        <span class="displayblock">
                                            <input type="checkbox" id="chkCurrencyFormat" />
                                            <label for="chkCurrencyFormat">Use Currency Format</label>
                                        </span>
                                        <span class="displayblock paddingleft30pxtop3px">
                                            <select style="width: 190px;" id="drpCurrencyFormat" disabled>
                                                <option value="0" id="Option9">--Select--</option>
                                                <option value="Thousands separator , Cent separator ." id="Currency1">Thousands separator , Cent separator .</option>
                                                <option value="Thousands separator . Cent separator ," id="Currency2">Thousands separator . Cent separator ,</option>
                                                <option value="Cent separator ," id="Currency3">Cent separator ,</option>
                                                <option value="Cent separator ." id="Currency4">Cent separator .</option>
                                            </select>
                                        </span>
                                    </div>


                                </div>
                            </div>
                            <h3 class="LabelPanel">LABEL</h3>
                            <div style="margin: 0px; padding: 0px;" class="content contentLabelPanel">
                                <div class="Label">
                                    <span class="none displayblock">
                                        <input type="radio" name="Label" id="rdLabelnone" checked="checked" />
                                        <label for="rdLabelnone">
                                            None</label>
                                    </span><span class="displayblock">
                                        <input type="radio" name="Label" id="rdUseLabel" />
                                        <label for="rdUseLabel">
                                            Use Labels</label>
                                    </span>
                                    <div class="UseLabel">
                                        <div class="UseLabelDefault">
                                            <span class="displayblock paddingtop4pxleft18px">
                                                <label class="displayblock padding2px">
                                                    Value</label>
                                                <input type="text" class="lblcommon" id="txtLabel" />
                                            </span><span class="displayblock paddingtop8pxleft18px">
                                                <label class="displayblock padding2px">
                                                    Font Style</label>
                                                <select class="lblcommon" id="drplabelFontStyle">
                                                    <option value="0" id="drpLabelFontStyleID0">--Select--</option>
                                                </select>
                                            </span><span class="displayblock paddingtop8pxleft18px">
                                                <label class="displayblock padding2px">
                                                    Color Style</label>
                                                <select class="lblcommon" id="drplabelColorStyle">
                                                    <option value="0" id="drpLabelColorStyleID0">--Select--</option>
                                                </select>
                                            </span><span class="displayblock paddingtop10pxleft18px">
                                                <label class="displayblock padding2px">
                                                    Position</label>
                                            </span><span class="displayblock paddingleft18px">
                                                <input type="radio" name="Position" class="position" id="rdAttached" />
                                                <label for="rdAttached">
                                                    Attached to the left of the field</label>
                                                </span><span class="displayblock paddingleft18px">
                                                <input type="radio" name="Position" class="position" id="rdRightAttached" />
                                                <label for="rdRightAttached">
                                                    Attached to the right of the field</label>
                                            </span><span class="displayblock paddingleft18px">
                                                <input type="radio" name="Position" id="rdCustomPostioning" />
                                                <label for="rdCustomPostioning">
                                                    Custom Positioning</label>
                                            </span>
                                        </div>
                                        <div>
                                            <span class="displayblock paddingleft28pxtop3px">
                                                <input type="radio" name="alignObject" class="alignObject" id="rdleftofobject" />
                                                <input type="text" style="width: 50px;" class="TextBoxWidth50 leftofobject alignObjectText"
                                                    onkeyup='return validateQty(event);' oninput='vaild(event);' />
                                                <label for="rdleftofobject">
                                                    mm left of the object</label>
                                            </span><span class="displayblock paddingleft28pxtop3px">
                                                <input type="radio" name="alignObject" class="alignObject" id="rdaboveobject" />
                                                <input type="text" style="width: 50px;" class="TextBoxWidth50 aboveobject alignObjectText"
                                                    onkeyup='return validateQty(event);' oninput='vaild(event);' />
                                                <label for="rdaboveobject">
                                                    mm above the object</label>
                                            </span>
                                        </div>
                                        <div>
                                            <%--  <span class="displayblock paddingleft18px">
                                                <input type="checkbox" id="chklabelLeft" disabled />
                                                <label for="chklabelLeft">
                                                    Show Label on Left
                                                </label>
                                            </span>--%>

                                            <span class="displayblock paddingleft28pxtop3px">
                                                <input type="radio" name="alignObject" class="alignObject" id="rdrightofobject" />
                                                <input type="text" style="width: 50px;" class="TextBoxWidth50 rightofobject alignObjectText"
                                                    onkeyup='return validateQty(event);' oninput='vaild(event);' />
                                                <label for="rdrightofobject">
                                                    mm right of the object</label>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <h3 class="ReviewFieldsPanel">CHANGE FIELD ORDER</h3>
                            <div style="margin: 0px; padding: 3px 0px 3px 0px; height: 200px;" class="content">
                                <ul id="sortable">
                                </ul>
                            </div>
                            <h3 class="SaveTemplatePanel">SAVE TEMPLATE</h3>
                            <div style="margin: 0px; padding: 0px;" class="content">
                                <div class="SavedTemplate">
                                    <span class="displayblock">
                                        <label>
                                            Template Name:</label>
                                    </span><span class="displayblock paddingtop4px">
                                        <input type="text" class="TextBoxWidth200" id="txtTemplateName" />
                                    </span><span class="displayblock paddingtop7px">
                                        <label>
                                            Description:</label>
                                    </span><span class="displayblock paddingtop4px">
                                        <textarea id="txtDescription"></textarea>
                                    </span><span class="displayblock paddingtop7px">
                                        <input type="checkbox" id="chkAllowTextBlock" />
                                        <label for="chkAllowTextBlock">
                                            Allow the user to add a new textblock</label>
                                    </span><span class="displayblock">
                                        <input type="checkbox" id="chkAllowParagraph" />
                                        <label for="chkAllowParagraph">
                                            Allow the user to add a new paragraph</label>
                                    </span><span class="displayblock">
                                        <input type="checkbox" id="chkAllowImage" />
                                        <label for="chkAllowImage">
                                            Allow the user to add a new image</label>
                                    </span><span class="displayblock">
                                        <input type="checkbox" id="chkShowEditor" />
                                        <label for="chkShowEditor">
                                            Show editor functions in customer view</label>
                                    </span><span class="displayblock">
                                        <input type="checkbox" id="chkShoweditablePages" />
                                        <label for="chkShoweditablePages">
                                            Show only editable pages</label>
                                    </span><%--<span class="displayblock">
                                        <input type="checkbox" id="chkGroupConsider" />
                                        <label for="chkGroupConsider">
                                            Consider group with label position</label>
                                    </span>--%><span class="displayblock"><span class="verticalAlignTop displayinlineblock">
                                        <input type="checkbox" id="chkSendAttachments" style="vertical-align: middle;" />
                                    </span><span class="displayinlineblock width200px">
                                        <label for="chkSendAttachments">
                                            Send images as attachments with Order & Admin Email</label>
                                    </span></span><span class="displayblock paddingtop7px">
                                        <input type="button" value="Save" id="btnSave" class="btnnPopup" />
                                        <input type="button" value="Save and Close" id="btnSaveandClose" class="btnnPopup" />
                                    </span>
                                </div>
                            </div>
                        </div>
                        <%--Accordion End--%>
                    </div>
                </td>
                <td id="Td1" class="menubartd" runat="server">
                    <table class="menubartdtable" border="1">
                        <tr>
                            <%--Menubar--%>
                            <td id="Menubar">
                                <table class="paddingtop4pxbottom4px">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="paddingright5px">
                                                        <div class="menubutton" title="Copy" id="btnCopy">
                                                            <img src="StyleSheets/Images/copy.png" class="menuimg" alt="Copy" />
                                                        </div>
                                                    </td>
                                                    <td class="paddingright5px">
                                                        <div class="menubutton" title="Paste" id="btnPaste">
                                                            <img src="StyleSheets/Images/pastespecial.png" class="menuimg" alt="Paste" />
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="menubutton" title="Cut" id="btnCut">
                                                            <img src="StyleSheets/Images/cut.png" class="menuimg" alt="Cut" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="paddingright5pxtop5px">
                                                        <div class="menubutton" title="Delete all fields and start from scratch" id="btnClearAllControlls">
                                                            <img src="StyleSheets/Images/reset.png" class="menuimg" alt="Reset" />
                                                        </div>
                                                    </td>
                                                    <td colspan="2" class="paddingtop5px">
                                                        <div class="menubutton" title="Delete" id="btnDeleteControl">
                                                            <img src="StyleSheets/Images/delete_icon.png" class="menuimg" alt="Delete" />
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
                                                    <td class="paddingright5px">
                                                        <div class="menubutton" title="Left Justify" id="btnLeftAlign">
                                                            <img src="StyleSheets/Images/alignleft.png" class="menuimg" alt="Left Justify" />
                                                        </div>
                                                    </td>
                                                    <td class="paddingright5px">
                                                        <div class="menubutton" title="Center Justify" id="btnCenterAlign">
                                                            <img src="StyleSheets/Images/aligncenter.png" class="menuimg" alt="Center Justify" />
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="menubutton" title="Right Justify" id="btnRightAlign">
                                                            <img src="StyleSheets/Images/alignright.png" class="menuimg" alt="Right Justify" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="paddingright5pxtop5px">
                                                        <div class="menubutton" title="Bold" id="btnBold">
                                                            <img src="StyleSheets/Images/bold.png" class="menuimg" alt="Bold" />
                                                        </div>
                                                    </td>
                                                    <td colspan="2" class="paddingtop5px">
                                                        <div class="menubutton" title="Italic" id="btnItalic">
                                                            <img src="StyleSheets/Images/italic.png" class="menuimg" alt="Italic" />
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
                                                    <td class="paddingright5px">
                                                        <div class="menubutton" title="Left align" id="btnLeftAlignCntrl">
                                                            <img src="StyleSheets/Images/Cleft.png" class="menuimg" alt="Left Align Control" />
                                                        </div>
                                                    </td>
                                                    <td class="paddingright5px">
                                                        <div class="menubutton" title="Center align" id="btnCenterAlignCntrl">
                                                            <img src="StyleSheets/Images/Ccenter.png" class="menuimg" alt="Center Align Control" />
                                                        </div>
                                                    </td>
                                                    <td class="paddingright5px">
                                                        <table>
                                                            <tr>
                                                                <td class="paddingright5px">
                                                                    <div class="menubutton" title="Right align" id="btnRightAlignCntrl">
                                                                        <img src="StyleSheets/Images/Cright.png" class="menuimg" alt="Right Align Control" />
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <input type="text" class="TextBoxWidth200 txtCopy" id="txtCopy_" placeholder="Enter Existing Template Name" style="padding-right: 20px;" />
                                                                    <div id="copyDiv">
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div id="btncopyTemplate" class="menubuttonCopy" title="Copy Selected Template">
                                                                        <label class="copy">
                                                                            Copy</label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="paddingright5px">
                                                        <div class="menubutton" title="Zoom In" id="btnZoomIn">
                                                            <img src="StyleSheets/Images/zoom_in.png" class="menuimg" alt="Zoom In" />
                                                        </div>
                                                    </td>
                                                    <td class="paddingright5px">
                                                        <div class="menubutton" title="Zoom Out" id="btnZoomOut">
                                                            <img src="StyleSheets/Images/zoom_out.png" class="menuimg" alt="Zoom Out" />
                                                        </div>
                                                    </td>
                                                    <td class="paddingright5px">
                                                        <table>
                                                            <tr>
                                                                <td style="padding-right: 10px;">
                                                                    <input type="text" class="TextBoxWidth50" title="Zoom" value="100" id="txtZoom" onkeyup="this.value = minmax(this.value, 0, 1600)" /><span
                                                                        style="font-size: 11px; font-family: Verdana; margin-left: 2px;">%</span>
                                                                </td>
                                                                <%--Commented on 16/11/2015 by Shahabaz--%>
                                                                <%--     <td style="padding-right: 5px;"> 
                                                                     <div class="menubutton" title="Rotate" id="btnRotate">
                                                                        <img src="StyleSheets/Images/rotate.png" class="menuimg" alt="Rotate" />
                                                                    </div>
                                                                </td>--%>
                                                                <td style="padding-right: 10px;">
                                                                    <input type="text" class="TextBoxWidth50" title="Rotate Object" id="txtRotate" onkeyup='return validateQty(event);'
                                                                        oninput='vaild(event);' />
                                                                </td>
                                                                <td>
                                                                    <select style="width: 50px;" id="drpPageSelect" class="smallselect">
                                                                        <option value="1" selected>1</option>
                                                                    </select>
                                                                    <label id="lblpage">
                                                                        Page</label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
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

                                <div id="LayoutCanvas">
                                    <div id="Maincanvas">
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
        </table>
        <div>
        </div>
        <%--Popups--%>
        <div id="fontColor" style="text-align: center; display: none">
            <div style="width: 100%; height: 25px; background-image: url('/StyleSheets/Images/popup.png')">
                <span id="colortitle">Foreground Colour</span> <span id="colorclose" title="Close"
                    style="font-size: 16px !important;">x</span>
            </div>
            <div style="padding: 10px;">
                <span class="cp_128"></span>
            </div>
        </div>

        <div id="Message" title="Information" style="display: none;">
            <div id="msg">
            </div>
        </div>
        <div id="SaveMessage" title="Information" style="display: none;">
            <div id="savemsg">
            </div>
        </div>
        <div id="ErrorMsg" title="Information" style="display: none;">
            <div id="error">
            </div>
        </div>

        <div id="CreateCategory" title="Create New Category">
            <div id="CreateCategoryDiv">
                <span class="size12 width100cent floatleft">Category <span class="colorRed">*</span>
                    <span class="colorRed floatRight displayNone" id="errCategory">Please enter category</span>
                </span>
                <input class="popupTextBox width100cent" id="txtNewCategoryName" />
                <span class="size12 width100cent">Parent Category</span>
                <select class="popupSelect width100cent" id="drpForCreateCategory">
                </select>
                <span class="btnnPopup size12" id="btnSaveCategory">Save</span>
            </div>
        </div>
        <div id="EditCategory" class="displayNone" title="Edit Category">
            <div id="EditCategoryDiv">
                <span class="size12 width100cent floatleft">Category </span>
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
                    <img style="vertical-align: middle" src="StyleSheets/Images/radimg1.gif" /></span><span class="btnnPopup" id="btnCancelImage">Cancel</span>
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
        <div id="ManageGroupExistingGroup" title="Existing Groups" class="displayNone">
            <div class="ExistingGroupouterDiv">
                <div class="width100cent" style="padding-top: 10px; padding-bottom: 5px;">
                    <span class="btnnPopup btnAddGroup floatRight" id="addGropFromExistingGroup">Add New</span>
                </div>
                <div style="padding-top: 5px;">
                    <table id="ManageGroupExistingGroupTable" border="0">
                    </table>
                </div>
            </div>

            <%--            <div style="padding: 10px;">
                <div class="size11" style="font-weight: bold;">
                    Please Note:
                </div>
                <div class="size11">
                    When fields are used in a group the X and Y co-ordinates that are used in the group override the co-ordinates in the individual fields.
                </div>
                <div class="size11">
                    In the editable product settings screen you still see the fields in the position that their individual X and Y co-ordinates placed them in.
                </div>
                <div class="size11">
                    In the eStore customer view you see the fields positioned using the X and Y co-ordinates from the group.
                </div>
            </div>--%>
        </div>
        <div id="ManageGroupNogroup" title="Manage Group" class="ManageGroup displayNone">
            <div id="NoGroup">
                <div>
                    No groups have been created for this template.
                </div>
                <div style="margin: 5px auto 15px auto;">
                    If you want to create a new group for this template click on the 'Add Group' button
                    below.
                </div>
                <span class="btnnPopup btnAddGroup" id="addGropFromNoGroup">Add Group</span>
            </div>
        </div>
        <div id="ManageGroupAddGroup" title="Manage Group" class="displayNone">
            <div id="AddGroup">
                <table class="width100cent">
                    <tr>
                        <td class="width100cent" colspan="3">
                            <table class="width100cent">
                                <tr>
                                    <td class="verticalAlignTop" style="width: 50px;">
                                        <span class="size12">Group Name</span>
                                        <input type="text" id="txtGropuName" class="popupTextBox" />
                                    </td>
                                    <td class="verticalBottom" style="padding-left: 30px; width: 100px;">
                                        <span class="size12">Page Number</span>
                                        <select class="popupSelect" id="drpManageGroupPage">
                                            <option value="1">1</option>
                                        </select>
                                    </td>
                                    <td id="td_chkPara" class="verticalBottom" style="">
                                        <input type="checkbox" class="verticalMiddle" id="chkparaGroup" /><label class="size12" for="chkparaGroup">Paragraph Group</label>
                                    </td>
                                    <td class="verticalBottom">
                                        <img src="StyleSheets/Images/arrow-left.png" id="lnkGoback" title="Go Back" width="20"
                                            class="displayNone" style="float: right;" height="20" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px;">
                            <span class="size12" style="padding-left: 2px;">Available Fields</span>
                            <div class="fieldArea" id="availbaleFields">
                            </div>
                        </td>
                        <td class="verticalBottom" style="padding: 0px 10px 0px 10px; width: 150px;">
                            <div class="btnnPopup size12 functionButton" id="btnMoveUp" style="margin-bottom: 5px;">
                                Move Up
                            </div>
                            <div class="btnnPopup size12 functionButton" id="btnMoveDown">
                                Move Down
                            </div>

                            <div class="btnnPopup size12 functionButton" id="btnAddToGroup" style="margin-bottom: 5px;">
                                Add
                            </div>
                            <div class="btnnPopup size12 functionButton" id="btnRemoveFromGroup">
                                Remove
                            </div>
                        </td>
                        <td style="padding-top: 10px;">
                            <span class="size12" style="padding-left: 2px;">Grouped Fields</span>
                            <div class="fieldArea" id="groupFields">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px;">
                            <table>
                                <tr>
                                    <td style="padding-bottom: 5px;">
                                        <span class="size14" style="font-weight: bold;">Group Option</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="verticalAlignTop">
                                        <div class="manageAddGroupTdPadding">
                                            <span class="size12">Position (X-left,Y-bottom)</span>
                                        </div>
                                    </td>
                                    <td style="padding-left: 10px;">
                                        <input type="text" class="samllbox popupTextBox" id="txtGroupPostionX" value="0"
                                            onkeyup='return validateQty(event);' oninput='vaild(event);' />
                                        <span class="size12">mm</span>
                                    </td>
                                    <td>
                                        <input type="text" class=" samllbox popupTextBox" id="txtGroupPostionY" value="0"
                                            onkeyup='return validateQty(event);' oninput='vaild(event);' />
                                        <span class="size12">mm</span>
                                    </td>
                                </tr>
                                <tr class="manageAddGroupTdPadding">
                                    <td class="verticalAlignTop">
                                        <div style="padding: 2px 0px 2px 0px;">
                                            <span class="size12">Spacing between Fields</span>
                                        </div>
                                    </td>
                                    <td style="padding-left: 10px;">
                                        <input type="text" class="samllbox popupTextBox" id="txtrSpacingBtwnFields" value="0"
                                            onkeyup='return validateQty(event);' oninput='vaild(event);' />
                                        <span class="size12">mm</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="verticalAlignTop">
                                        <div class="manageAddGroupTdPadding">
                                            <span class="size12">Alignment</span>
                                        </div>
                                    </td>
                                    <td colspan="2" style="padding: 0px 0px 0px 10px;">
                                        <input type="radio" name="alignment" id="rdGroupLeftAlign" checked class="verticalMiddle" />
                                        <label for="rdGroupLeftAlign" class="size12">
                                            Left</label>
                                        <input type="radio" name="alignment" id="rdGroupCentertAlign" class="verticalMiddle" />
                                        <label for="rdGroupCentertAlign" class="size12">
                                            Center</label>
                                        <input type="radio" name="alignment" id="rdGroupRightAlign" class="verticalMiddle" />
                                        <label for="rdGroupRightAlign" class="size12">
                                            Right</label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                        <td style="padding-top: 10px;">
                            <table>
                                <tr>
                                    <td style="padding-bottom: 5px;">
                                        <span class="size14" style="font-weight: bold;">Movement Option</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px;" class="verticalAlignTop">
                                        <div class="manageAddGroupTdPadding">
                                            <span class="size12">Oreintation * </span>
                                        </div>
                                    </td>
                                    <td colspan="3">
                                        <input type="radio" name="Orientation" class="verticalMiddle" id="rdOreintationHorizontal" />
                                        <label for="rdOreintationHorizontal" class="size12">
                                            Horizontal</label>
                                        <input type="radio" name="Orientation" class="verticalMiddle" id="rdOreintationVertical"
                                            checked />
                                        <label for="rdOreintationVertical" class="size12">
                                            Vertical</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="verticalAlignTop">
                                        <div class="manageAddGroupTdPadding">
                                            <span class="size12">Field Movement Options</span>
                                        </div>
                                    </td>
                                    <td>
                                        <select class="popupSelect" id="drpFieldMovement">
                                        </select>
                                        <img style="vertical-align: middle; margin-left: 10px;" width="16" height="16" src="StyleSheets/Images/Help-icon.png"
                                            title="Select which direction to move the fields in this group." />
                                    </td>
                                </tr>
                                <tr class="manageAddGroupTdPadding">
                                    <td class="verticalAlignTop">
                                        <div class="manageAddGroupTdPadding">
                                            <span class="size12">Group Movement Option</span>
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        <select class="popupSelect" id="drpGroupOption">
                                        </select>
                                        <img style="vertical-align: middle; margin-left: 10px;" width="16" height="16" src="StyleSheets/Images/Help-icon.png"
                                            title="Select which direction to move the entire group." />
                                    </td>
                                </tr>
                                 <tr class="manageAddGroupTdPadding">
                                    
                                    <td colspan="2">
                                        <input type="checkbox" class="verticalMiddle" id="chkRelativeGroupOption" /><label class="size12" for="chkRelativeGroupOption">Relative group movement</label>
                                       
                                        <img style="vertical-align: middle; margin-left: 10px;" width="16" height="16" src="StyleSheets/Images/Help-icon.png"
                                            title="When ticked this will move the group relative to the current position instead of snapping it to the next groups position." />
                                    </td>
                                </tr>
                                 <tr class="manageAddGroupTdPadding">
                                    <td class="verticalAlignTop">
                                        <div class="manageAddGroupTdPadding">
                                            <span class="size12">Group Movement Value</span>
                                        </div>
                                    </td>
                                    <td colspan="2">
                                       <input type="text" class=" samllbox popupTextBox" id="txtGroupMovementValue" value="0"
                                             />
                                        <span class="size12">mm</span>
                                        <img style="vertical-align: middle; margin-left: 10px;" width="16" height="16" src="StyleSheets/Images/Help-icon.png"
                                            title="The Group Movement will set how much the text moves relative to the height of the field that has been removed in the product being edited.
For example if you set the setting to be 0mm and if a field is removed and that field has text that is 2mm high the other fields will move by 2mm.
If you set the setting to be 1mm and the removed text was 2mm high the remaining text will move by 3mm." />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="checkbox" class="verticalMiddle" id="chkConsiderGroup" /><label class="size12" for="chkConsiderGroup">Consider group control position with Labels</label>
                            <%--  <img style="vertical-align: middle; margin-left: 10px;" width="16" height="16" src="StyleSheets/Images/Help-icon.png"
                                            title="Control having label will position " />--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="manageAddGroupSavetd" colspan="3">
                            <span class="btnnPopup size12 SaveandStayGroup" style="padding-left: 10px;">Save And
                                Stay</span> <span class="btnnPopup size12 SaveandCloseGroup" style="margin-left: 10px;">Save And Close</span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="QuickAdjustDialog" title="Quick Adjust" class="quickadjust displayNone">
            <div id="loadingquickadjust">
                <img src="StyleSheets/Images/loading_new.gif" alt="Loading..." />
            </div>
            <div class="quickadjust_Overflowdiv">
                <table id="QuickAdjustDialogTable">
                </table>
            </div>
        </div>
        <div id="Imageeditor" title="Edit Image" class="displayNone" style="overflow: no-display;">
            <div id="ImageeditorDiv1">
                <form id="form2" runat="server">
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
                            PopupLoad = false;
                            Edited = "true";
                            if (args.get_commandName()) {
                                waitForCommand(imageEditor, args.get_commandName(), function (widget) {
                                    if (typeof widget._constraintBtn != 'undefined')
                                        widget._constraintBtn.set_checked(false); //stop the aspect ration constraint
                                    if (typeof widget.set_width != 'undefined')
                                        widget.set_width(orgWidthCrop);
                                    if (typeof widget.set_height != 'undefined')
                                        widget.set_height(orgHeightCrop);
                                    if (typeof widget._widthTxt != 'undefined')
                                        widget._widthTxt.disabled = false;
                                    if (typeof widget._heightTxt != 'undefined')
                                        widget._heightTxt.disabled = false;
                                    if (typeof widget._updateCropBoxFromControls != 'undefined')
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

                        function OnClientImageChanged() {
                            if (PopupLoad)
                                Edited = 'false'
                            else
                                Edited = 'true';
                            //  Edited = 'true';                          
                        }

                        function IsImageSaved(args) {
                            debugger;
                            saved = true;
                            FitTheEditedImageToControl(originalFilename);//Added By shahbaz
                        }

                    </script>

                    <telerik:RadImageEditor ID="RadImageEditor1" OnImageSaving="RadImgEdt_ImageSaving"
                        OnClientDialogLoaded="OnClientDialogLoaded" runat="server" Height="400" CssClass="imageEditor"
                        OnClientCommandExecuted="modifyCommand" ToolsLoadPanelType="AjaxPanel" ShowAjaxLoadingPanel="true" EnableResize="false" OnClientImageChanged="OnClientImageChanged" OnClientSaved="IsImageSaved">
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
                        <EditableImageSettings MaxJsonLength="2147483640" />
                    </telerik:RadImageEditor>
                </form>
            </div>
        </div>
        <div id="ImageFromGallery" title="Image Gallery" class="displayNone">
            <div class="loading_gallery loading_galleryMask">
            </div>
            <div class="MaskForGalleryPopUp">
            </div>
            <div class="loading_gallery loading_galleryImage">
                <img src="StyleSheets/Images/loading_new.gif" alt="Loading..." />
            </div>
            <div id="thumbnailButtons">
                <div class="floatRight">
                    <span class="btnnPopup displayNone" id="btnUnSelectAll" style="display: none;">Unselect
                        All</span> <span class="btnnPopup" id="btnSelectAll">Select All</span> <span class="btnnPopup"
                            id="btnDeletetAll">Delete Selected</span> <span class="popupTextBox_Span">
                                <input type="text" class="size12 txtSearchText popupTextBox" placeholder="Enter Search Text" />
                            </span><span class="ClearSearchText_Span">
                                <img src="StyleSheets/Images/delete_icon1.png" width="16" height="16" class="btnClearSearchText"
                                    title="Clear Search Text" />
                            </span>
                </div>
            </div>
            <div id="tabs">
                <ul>
                    <li><a href="#Gallery" id="galleryLink">Gallery</a> </li>
                    <li><a href="#FileUplaod" id="fileUploadLink">File Upload</a> </li>
                </ul>
                <div id="Gallery">
                    <div id="thumNail">
                    </div>
                    <span class="btnnPopup btnBack" style="margin-left: 20px;">Back</span> <span class="btnnPopup"
                        style="margin-left: 20px;" id="btnSaveImage">Save & Close</span>
                    <%--<span class="btnnPopup" style="margin-left: 10px;" id="btnShowMore">Show More</span>--%>
                    <span class="link btnClearDefault">Clear Default</span>
                </div>
                <div id="FileUplaod">
                    <div id="fileUploadDiv1">
                        <div id="fileUploadDiv">
                            <span class="size12 categoryText">Category</span>
                            <select class="verticalMiddle popupSelect" id="drpSelectCategory">
                            </select>
                            <span class="btnnPopup" title="Create new category" id="btnNewCategoryPopUp">Add New
                                Category</span>
                            <div class="uploaddiv">
                                <div class="size12 selctFilesText">
                                    Select files to upload
                                </div>
                                <div id="fileList">
                                </div>
                                <div id="TotalDiv">
                                    <div id="totalContainer">
                                        Total<span id="Total"></span>
                                    </div>
                                </div>
                                <div class="browseBtnDiv">
                                    <span class="btnnPopupBrowse size12" id="btnSelectFiles"><span id="btnUploadText">Browse</span>
                                        <input id="multipleFileUpload" name="multipleFileUpload" accept="image/png,image/jpeg,application/pdf,application/vnd"
                                            type="file" multiple />
                                    </span>

                                </div>
                            </div>
                            <div>
                                <input type="button" id="btnUpload" class="btnnPopup " value="Upload" />
                            </div>
                            <div style="padding-top: 5px;">
                                <div class="size11" style="font-weight: bold;">
                                    Image guidelines
                                </div>
                                <div class="size11">
                                    You can upload these file types into an editable product: Jpeg, Png, PDF.
                                </div>
                                <div class="size11">
                                    When uploading a PDF only single page files can be used.
                                </div>
                                <div class="size11">
                                    PDF files will not be able to be cropped or rotated by the end user in the editable product.
                                </div>
                                <div class="size11">
                                    PDF files will be uploaded in the background and it will take upto 15 minutes to load.
                                </div>
                                <%-- <div class="size11">
                                    Please upload JPEG or PNG file wherever possible as this will lead to faster screen response time.
                                </div>--%>
                            </div>
                        </div>
                        <div id="FilePropertiesDiv" class="displayNone" style="overflow-y: auto;">
                        </div>
                        <div id="FilePropertiesButtonDiv">
                            <span class="btnnPopup" id="btnImageSaveCancel">Cancel</span> <span style="margin-left: 10px;"
                                class="btnnPopup" id="btnImageSaveChanges">Save Changes</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--Popups End--%>
    </div>
</body>
</html>
