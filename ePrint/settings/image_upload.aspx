<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="image_upload.aspx.cs" Inherits="ePrint.settings.image_upload" %>--%>

<%@ page language="C#" autoeventwireup="true" CodeBehind="image_upload.aspx.cs" inherits="ePrint.settings.image_upload" theme="Theme1" enableviewstatemac="false" enableEventValidation="false" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/CallClass.ascx" TagName="Style" TagPrefix="UC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Image Upload</title>
    <link href="../App_Themes/Theme1/cropper.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <UC:Style ID="CallClass" runat="server" />
    <script src="../js/item/prototype.js" type="text/javascript"></script>
    <script src="../js/item/scriptaculous.js?load=builder,dragdrop" type="text/javascript"></script>
    <script src="../js/cropper.js" type="text/javascript"></script>
    <script type="text/javascript">
        /**
        * A little manager that allows us to swap the image dynamically
        *
        */
        var CropImageManager = {
            /**
            * Holds the current Cropper.Img object
            * @var obj
            */
            curCrop: null,
            /**
            * Initialises the cropImageManager
            *
            * @access public
            * @return void
            */
            init: function () {
                this.attachCropper();

            },

            /**
            * Handles the changing of the select to change the image, the option value
            * is a pipe seperated list of imgSrc|width|height
            * 
            * @access public
            * @param obj event
            * @return void
            */
            onChange: function (e) {
                var vals = $F(Event.element(e)).split('|');
                this.setImage(vals[0], vals[1], vals[2]);
            },
            /**
            * Sets the image within the element & attaches/resets the image cropper
            *
            * @access private
            * @param string Source path of new image
            * @param int Width of new image in pixels
            * @param int Height of new image in pixels
            * @return void
            */
            setImage: function (imgSrc, w, h) {
                $('imgPhoto').src = imgSrc;
                $('imgPhoto').width = w;
                $('imgPhoto').height = h;
                this.attachCropper();
            },
            /** 
            * Attaches/resets the image cropper
            *
            * @access private
            * @return void
            */
            attachCropper: function () {
                if (this.curCrop == null) this.curCrop = new Cropper.Img('imgPhoto', { onEndCrop: onEndCrop });
                else this.curCrop.reset();
            },
            /**
            * Removes the cropper
            *
            * @access public
            * @return void
            */
            removeCropper: function () {
                if (this.curCrop != null) {
                    this.curCrop.remove();
                }
            },

            /**
            * Resets the cropper, either re-setting or re-applying
            *
            * @access public
            * @return void
            */
            resetCropper: function () {
                this.attachCropper();
                document.getElementById("div_btnApplyCrop").style.display = "none";
            }
        };
        // setup the callback function
        function onEndCrop(coords, dimensions) {
            $('x1').value = coords.x1;
            $('y1').value = coords.y1;

            $('width').value = dimensions.width;
            $('height').value = dimensions.height;

            document.getElementById("div_btnApplyCrop").style.display = "block";
        }
        // basic example
        Event.observe(
			window,
			'load',
			function () {
			    CropImageManager.init();
			    Event.observe($('removeCropper'), 'click', CropImageManager.removeCropper.bindAsEventListener(CropImageManager), false);
			    Event.observe($('resetCropper'), 'click', CropImageManager.resetCropper.bindAsEventListener(CropImageManager), false);
			    Event.observe($('lnkCrop'), 'click', CropImageManager.resetCropper.bindAsEventListener(CropImageManager), false);

			}
		); 		
    </script>
    <div id="padding">
        <div id="div_Upload" runat="server" align="left" style="width: 100%;">
            <div align="left" style="width: 100%">
                <div style="float: left; width: 100%">
                    <asp:FileUpload ID="File1" runat="server" /></div>
                <div class="box">
                    &nbsp; <span id="spn_Error" class="spanerrorMsg" style="display: none; width: 200px;">
                        Please select an image to upload </span><span id="spn_ErrorExt" class="spanerrorMsg"
                            style="display: none; width: 200px;">Please enter valid image format </span>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div align="left" style="width: 100%;">
                <asp:RadioButtonList ID="rdllstimgAction" runat="server">
                    <asp:ListItem Text="Retain original size" Value="retain" Selected="true">Retain original size</asp:ListItem>
                    <asp:ListItem Text="Resize automatically (to 300px X 100px)" Value="resize"></asp:ListItem>
                    <asp:ListItem Text="Allow to crop" Value="crop"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="only10px">
            </div>
            <div align="left" style="width: 100%">
                <asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Upload" OnClientClick="javascript:return ValidateFile();"
                    OnClick="btnUpload_OnClick" />
            </div>
        </div>
        <div id="div_img" align="left" runat="server" style="width: 100%; display: none">
            <div align="left" class="graytext">
                <div align="left">
                    <h2>
                        Crop this picture</h2>
                </div>
                <div align="left">
                    1.First select the area to crop
                    <br />
                    2. Drag the box to select the crop area, and use the handle to resize it.</div>
            </div>
            <div class="only5px">
            </div>
            <div align="left">
                <img src="<%=CropImgPath %>" id="imgPhoto" runat="server" /></div>
            <div align="left" id="div_Crop" style="display: none">
                <div class="only10px">
                </div>
                <a href="javascript://" onclick="ShowCropToo();" id="lnkCrop" class="small">StartCrop</a><asp:Image
                    runat="server" ID="resetCropper" ToolTip="Start croppeer" ImageUrl="../images/crop.jpg" />
            </div>
            <div align="left" id="div_RemoveCrop">
                <div class="only10px">
                </div>
                <a href="javascript://" onclick="ShowCrop('d');" id="removeCropper" class="small">RemoveCrop
                </a>
            </div>
            <div class="only10px">
            </div>
            <div align="left">
                <div id="div_btnApplyCrop" style="float: left; display: none">
                    <asp:Button ID="btnSaveCropImg" runat="server" CssClass="button" Text="Apply Changes"
                        OnClick="btnSaveCropImg_OnClick" /></div>
                <div style="float: left; width: 10px;">
                    &nbsp;</div>
                <div style="float: left;">
                    <asp:Button ID="btnCropCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCropCancel_OnClick" /></div>
            </div>
        </div>
    </div>
    <div id="divLowResolution" style="display: none; position: absolute; vertical-align: middle;
        z-index: 100; width: 35%" align="center">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="2" class="popup-top-leftcorner">
                    &nbsp;
                </td>
                <td class="popup-top-middlebg">
                    <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                        padding-left: 1px">
                        <b>Image Upload </b>
                        <asp:Label ID="Label10" runat="server"></asp:Label></div>
                    <div style="float: right; padding-top: 6px; padding-right: 10px">
                        <div class="CancelButtonDiv">
                            <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                runat="server" CausesValidation="false" OnClientClick="javascript:CloseRes('close');return false;" />
                        </div>
                    </div>
                </td>
                <td colspan="2" class="popup-top-rightcorner">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="popup-middle-leftcorner">
                    &nbsp;
                </td>
                <td style="width: 15px; background-color: #ffffff">
                    &nbsp;
                </td>
                <td class="popup-middlebg" align="center">
                    <div style="padding: 10px 5px 10px 0px; width: 98%">
                        <div class="" style="width: 100%">
                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                <tr>
                                    <td valign="top">
                                        <div align="left" style="width: 100%;">
                                            <div align="left" class="normalText">
                                                The image you uploaded is of low resolution and might not appear clearly in the
                                                templates
                                                <br />
                                                <br />
                                                Do you want to upload a high resolution image (300dpi is preferrable)?
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="only10px">
                                        </div>
                                        <div align="left">
                                            <div class="bglabelEmpty" style="width: 20%">
                                                &nbsp;</div>
                                            <div style="float: left">
                                                <asp:Button ID="btnReupload" runat="server" Text="ReUpload" CssClass="button" Width="65px"
                                                    OnClientClick="javascript:CloseRes('reup');return false;" />
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;</div>
                                            <div style="float: left">
                                                <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass="button" Width="65px"
                                                    OnClick="btnContinue_OnClick" />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
                <td style="width: 10px; background-color: #ffffff">
                    &nbsp;
                </td>
                <td align="right" class="popup-middle-rightcorner">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" class="popup-bottom-leftcorner">
                    &nbsp;
                </td>
                <td class="popup-bottom-middlebg">
                    &nbsp;
                </td>
                <td colspan="2" class="popup-bottom-rightcorner">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input type="hidden" runat="server" name="x1" id="x1" />
    <input type="hidden" runat="server" name="y1" id="y1" />
    <input type="hidden" runat="server" name="width" id="width" />
    <input type="hidden" runat="server" name="height" id="height" />
    <asp:HiddenField ID="hid_FileName" runat="server" Value="" />
    <asp:HiddenField ID="hid_UpType" runat="server" Value="1" />
    <script>
        var file = document.getElementById("<%=File1.ClientID %>");
        var hid_FileName = document.getElementById("<%=hid_FileName.ClientID %>");
        var div_img = document.getElementById("<%=div_img.ClientID %>");
        var imgPhoto = document.getElementById("<%=imgPhoto.ClientID %>");

        var CheckFinal = false;
        function ValidateFile() {
            CheckFinal = true;
            if (file.value != '') {
                var spn_Error = document.getElementById("spn_ErrorExt");
                var imagePath = file;
                var pathLength = imagePath.value.length;
                if (pathLength > 0) {
                    var lastDot = imagePath.value.lastIndexOf(".");

                    var fileType = imagePath.value.substring(lastDot, pathLength);

                    if ((fileType.toLowerCase() == ".jpg") || (fileType.toLowerCase() == ".jpeg") || (fileType.toLowerCase() == ".png")
                     || (fileType.toLowerCase() == ".gif") || (fileType.toLowerCase() == ".jpe") || (fileType.toLowerCase() == ".jfif")
                     || (fileType.toLowerCase() == ".tif") || (fileType.toLowerCase() == ".bmp")) {
                        spn_Error.style.display = "none";
                        CheckFinal = true;
                    }
                    else {
                        spn_Error.style.display = "block";
                        CheckFinal = false;
                    }


                }
            }
            else {
                document.getElementById("spn_Error").style.display = "block";
                CheckFinal = false;
            }
            if (CheckFinal) {
                return true;
            }
            else {
                return false;
            }
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
            return oWindow;
        }


        function CloseOnReload() {
            GetRadWindow().Close();
        }
        
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js"></script>
    <asp:Panel ID="pnlWinClose" runat="server" Visible="false">
        <script type="text/javascript">
            var imgWidth = '<%=FinalWidth %>';
            var imgHeight = '<%=FinalHeight %>';
            var mode = '<%=Mode %>';

            window.parent.BindImg(hid_FileName.value, imgWidth, imgHeight, mode); //IE,Changes made on 29.09.2011
            CloseOnReload();
        </script>
    </asp:Panel>
    <script type="text/javascript">
        var hid_UpType = document.getElementById("<%=hid_UpType.ClientID %>");
        function CheckResolution() {
            document.getElementById("divLowResolution").style.display = "block";
        }

        function CloseRes(type) {
            document.getElementById("divLowResolution").style.display = "none";

            if (type == "close") {
                hid_UpType.value = 0;
            }
            else if (type == "reup") {
                hid_UpType.value = 1;
            }
            else if (type == "cont") {
                hid_UpType.value = 0;
            }
        }
    </script>
    <script>
        function ShowCrop(val) {
            document.getElementById("div_Crop").style.display = "block";
            document.getElementById("div_RemoveCrop").style.display = "none";
            document.getElementById("div_btnApplyCrop").style.display = "none";
        }
        function ShowCropToo() {
            document.getElementById("div_Crop").style.display = "none";
            document.getElementById("div_RemoveCrop").style.display = "block";
            document.getElementById("div_btnApplyCrop").style.display = "none";
        }       

    </script>
    </form>
</body>
</html>

