<%@ page language="C#" autoeventwireup="true" CodeBehind="UploadAndCrop.aspx.cs" Inherits="ePrint.UploadAndCrop" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=objLanguage.GetLanguageConversion("Image_Upload_and_Crop") %></title>
    <script src="js/jquery-1.7.2.min.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <!-- jQuery-Ui -->
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="css/sh_style.css" rel="stylesheet" type="text/css" />
    <!-- CropImage - jQuery Resize And Crop -->
    <link href="css/style.jrac.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-ui.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <!-- CropImage - Syntax Highlighting for JavaScript -->
    <script src="js/sh_main.min.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () { sh_highlightDocument(); });
    </script>
    <script src="js/jquery.jrac.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">

        function test(imgtype) {
            if (imgtype == "thumbnail") {
                var cpwidth = "200";
                var cpheight = "150";
                var resize = false;
            }
            else if (imgtype == "largesize") {
                var pagetype = document.getElementById("<%#hdnPagetype.ClientID%>").value;
                    if (pagetype == "user_add") {
                        var cpwidth = "100";
                        var cpheight = "100";
                        var resize = false;
                    }
                    else {
                        var cpwidth = "300";
                        var cpheight = "300";
                        var resize = true;
                    }
                }
                else if (imgtype == "thumbproptional") {
                    if (hdnthumbheight.value != "" && hdnthumbwidth.value != "") {
                        var cpwidth = hdnthumbwidth.value;
                        var cpheight = hdnthumbheight.value;
                    }

                }
            $(document).ready(function () {
                // Apply jrac on some image.
                $('#imgCrop').jrac({
                    'crop_width': cpwidth,
                    'crop_height': cpheight,
                    'crop_x': 15,
                    'crop_y': 10,
                    'crop_resize': resize,
                    'image_width': 700,
                    'viewport_onload': function () {

                        var $viewport = this;
                        var inputs = $viewport.$container.parent('.pane').find('.coords input:text');
                        var events = ['crop_x', 'crop_y', 'crop_width', 'crop_height', 'image_width', 'image_height'];
                        for (var i = 0; i < events.length; i++) {
                            var event_name = events[i];
                            // Register an event with an element.
                            $viewport.observator.register(event_name, inputs.eq(i));
                            // Attach a handler to that event for the element.
                            inputs.eq(i).bind(event_name, function (event, $viewport, value) {
                                $(this).val(value);
                            })
                            // Attach a handler for the built-in jQuery change event, handler
                            // which read user input and apply it to relevent viewport object.
              .change(event_name, function (event) {
                  var event_name = event.data;
                  //  $viewport.$image.scale_proportion_locked = $viewport.$container.parent('.pane').find('.coords input:checkbox').is(':checked');
                  //$viewport.observator.set_property(event_name, $(this).val());
              });
                        }
                        $viewport.$container.append('<div>Original Image Resolution is: '
              + $viewport.$image.originalWidth + ' x '
              + $viewport.$image.originalHeight + ' in pixels</div>')
                    }
                })
                // React on all viewport events.
        .bind('viewport_events', function (event, $viewport) {
            var inputs = $(this).parents('.pane').find('.coords input');
            inputs.css('background-color', ($viewport.observator.crop_consistent()) ? 'chartreuse' : 'red');
        });
            });
        }

        function ValidateSelected() {
            var errorcolor = document.getElementById("x1").style.backgroundColor;
            if (errorcolor == 'red') {
                alert("Crop handler outside the image. Please set the slider and again crop");
                return false;
            }



        }

        //--><!]]>
    </script>
    <script src="js/item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <style type="text/css">
        .imgsize
        {
            max-width: 498px;
            max-height: 398px;
        }
        .hidethediv
        {
            display: none;
        }
        .lnkcroptext
        {
            font-weight: 600;
        }
        
        .showdiv
        {
            display: block;
        }
        .imgborder
        {
            border: 0px solid red;
        }
        #div_upload
        {
            padding-left: 10px;
        }
        
        div.RadUploadProgressArea_Default .ruProgress
        {
            background-image: none;
        }
        
        div.RadUploadProgressArea_Default li.ruProgressHeader
        {
            margin: 15px 18px -7px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptmngr" runat="server">
    </asp:ScriptManager>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <asp:HiddenField ID="hdnthumbwidth" runat="server" Value="0" />
    <asp:HiddenField ID="hdnthumbheight" runat="server" Value="0" />
    <asp:HiddenField ID="hdnthumbcroptype" runat="server" Value="0" />
    <%--<%=strSitepath %>/js/popup.js--%>
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
        width: 100%" align="center">
        <telerik:RadProgressManager ID="Radprogressmanager1" runat="server"></telerik:RadProgressManager>
        <br />
        <telerik:RadProgressArea ID="RadProgressArea1" runat="server" ProgressIndicators="FilesCountBar,SelectedFilesCount, CurrentFileName,TimeElapsed,TimeEstimated"
            Style="">
        </telerik:RadProgressArea>
    </div>
    <%-- <fieldset style="border: 0px solid black;">
        <legend class="HeaderText" style="max-width: 820px; min-width: 370px; margin-top: 1%;">
        </legend>--%>
    <div style="height: 100%; width: 100%; margin: 0 0% 1% 0%;">
        <h3>
            <asp:Label ID="lbluploadmsg" runat="server" Text="Upload Image" Style="color: Gray;
                padding-left: 10px;" Visible="false"><%=objLanguage.GetLanguageConversion("Upload_Image") %></asp:Label>
        </h3>
        <div style="margin-left: 2%;">
            <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <div id="divUploadMsg" runat="server" class="errorMsg" style="display: none;">
                        <asp:PlaceHolder ID="plhMessage_upload" runat="server"></asp:PlaceHolder>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Panel ID="pnlUpload" runat="server">
            <table>
                <tr>
                    <td>
                        <div id="div_upload" runat="server">
                            <asp:FileUpload ID="Upload" runat="server" size="52" CssClass="textboxnew" /><br />
                            <%-- <asp:Label ID="lbl_msg" runat="server" Text="(Uploaded image size will be resized to 300px/300px)"
                                Style="clear: both;" CssClass="smallerfontgrey"></asp:Label>--%>
                            <asp:HiddenField ID="hdnUploadfilename" runat="server" />
                            <asp:HiddenField ID="hdnUpImagename" runat="server" />
                            <asp:HiddenField ID="hdnPagetype" runat="server" />
                            <br />
                            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload"
                                OnClientClick="SetRadWindow('divrad', 'divBackGroundNew', '200');" Style="margin-top: 5px;"
                                CssClass="button" />
                            <br />
                        </div>
                        <asp:Label ID="lblError" runat="server" Visible="false" Style="width: auto; padding-left: 4px;
                            padding-right: 4px" />
                    </td>
                    <td>
                        <div id="divPreview" runat="server">
                            <table style="float: left; margin-top: 3px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Thumb nail (200*150)px" Style="clear: both;
                                            font-size: 10px; font-weight: 500; padding-top: 0px;">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="imgthumbnail" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lnkbtnCrop" runat="server" Text="Crop" CssClass="lnkcroptext"
                                                        ToolTip="Click here to crop thumb nail(200*150)px" OnClick="lnkbtnCrop_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="div_preview300" class="hidethediv" runat="server" style="float: right;">
                                <table cellpadding="0px" style="padding-left: 20%;">
                                    <tr>
                                        <td>
                                            <%--<hr style="margin-bottom: 2px;" />--%>
                                            <table style="border-left: 1px solid grey; padding-left: 25px; display: block;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbltextforimg300" runat="server" Style="clear: both; font-size: 10px;
                                                            font-weight: 500; padding-top: 0px;"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="img300preview" runat="server" Style="padding-top: 2px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnkbtnCroplarge" runat="server" CssClass="lnkcroptext" Text="Crop"
                                                            ToolTip="Click here to crop product image" OnClick="lnkbtnCroplarge_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="div_previewuserimg" class="hidethediv" runat="server">
                            <%--<hr style="margin-bottom: 2px;" />--%>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbltextdimension" runat="server" Style="clear: both; font-size: 10px;
                                            font-weight: 500; padding-top: 0px;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="imgUserimage" runat="server" Style="padding-top: 2px;" />
                                        <asp:Image ID="imgUserimagethumnail" runat="server" CssClass="show_hide" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lnkcropuserimg" runat="server" CssClass="lnkcroptext" Text="Crop"
                                            ToolTip="Click here to crop product image" OnClick="lnkbtnCroplarge_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlCrop" runat="server" Visible="false" Style="padding-bottom: 50px;
            margin-left: 20px;">
            <br />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />
            <asp:Button ID="btnCrop" runat="server" Text="Crop" OnClick="btnCrop_Click" OnClientClick="return ValidateSelected();"
                Visible="false" Style="margin-bottom: 10px;" CssClass="button" />
            <asp:Button ID="btnlargeCrop" runat="server" Text="Crop" OnClientClick="return ValidateSelected();"
                Visible="false" OnClick="btnlargeCrop_Click" Style="margin-bottom: 10px;" CssClass="button" />
            <div class="pane clearfix">
                <asp:Image ID="imgCrop" runat="server" CssClass="button" OnClientClick="return ValidateSelected();" />
                <div style="display: none;">
                    <table class="coords">
                        <tr>
                            <td>
                                crop x
                            </td>
                            <td>
                                <input type="text" size="4" id="x1" name="x1" class="coor" readonly="readonly" visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                crop y
                            </td>
                            <td>
                                <input type="text" size="4" id="y1" name="y1" class="coor" readonly="readonly" visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                crop width
                            </td>
                            <td>
                                <input type="text" size="4" id="x2" name="x2" class="coor" readonly="readonly" visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                crop height
                            </td>
                            <td>
                                <input type="text" size="4" id="y2" name="y2" class="coor" readonly="readonly" visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                image width
                            </td>
                            <td>
                                <input type="text" size="4" id="wth" name="wth" class="coor" readonly="readonly"
                                    visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                image height
                            </td>
                            <td>
                                <input type="text" size="4" id="hgt" name="hgt" class="coor" readonly="readonly"
                                    visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                lock proportion
                            </td>
                            <td>
                                <input type="checkbox" checked="checked" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <br />
            <asp:LinkButton ID="lnkcrpproptional" Visible="false" runat="server" CssClass="lnkcroptext"
                ToolTip="Click here to proportional crop" OnClick="lnkcrpproptional_Click" Text="Crop proptional"></asp:LinkButton>
            <asp:Label ID="lblcropthumbprop" Visible="false" runat="server" CssClass="smallfontgrey"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="pnlCropped" runat="server" Visible="false" Style="margin-left: 6px;">
            <%--   <asp:Label ID="Label2" runat="server" Text="Crop Preview (resized to 300px/300px) "
                Style="clear: both;" CssClass="smallerfontgrey"></asp:Label><br />
            <asp:Image ID="imgCropped" runat="server" />--%>
        </asp:Panel>
        <asp:Panel ID="pnlBeforeCrop" runat="server" Visible="true">
            <%--    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                Enabled="false">
                <asp:ListItem Selected="True">Auto Crop</asp:ListItem>
                <asp:ListItem>Mannual crop</asp:ListItem>
            </asp:RadioButtonList>--%>
        </asp:Panel>
        <div id="divsave_crop" runat="server" style="padding: 2% 0px 0px 5px;">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnsaveimg" runat="server" CssClass="button" Text="Confirm & Save"
                            OnClick="btnsaveimg_Click" />
                    </td>
                    <td>
                        <%--  <asp:Button ID="btnMannualcrop" runat="server" CssClass="button" Text="Mannual Crop"
                            OnClick="btnMannualcrop_Click" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <%--</fieldset>--%>
    <script type="text/javascript">
        function Close() {

            var oWindow = GetRadWindow();
            //oWindow.argument = "hai";
            oWindow.close();
            return false;
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }
        var hdnthumbwidth = document.getElementById('hdnthumbwidth');
        var hdnthumbheight = document.getElementById('hdnthumbheight');

    </script>
    </form>
</body>
</html>

