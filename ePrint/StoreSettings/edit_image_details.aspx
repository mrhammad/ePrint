<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_image_details.aspx.cs" Inherits="ePrint.StoreSettings.edit_image_details" %>

<script type="text/javascript" src="../js/jquery.min.js?VN='<%#VersionNumber%>'"></script>
<script type="text/javascript" src="../js/jquery.popup.js?VN='<%#VersionNumber%>'"></script>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" language="javascript" src="../js/commonloading.js?VN='<%#VersionNumber%>'"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" href="../App_Themes/Theme1/item.css" rel="stylesheet" />
    <title></title>
</head>
<script type="text/javascript">
    var _imagpath = '<%=_imagpath %>';
    var FileName = '<%=FileName %>';
    var Description = '<%=Description %>';
    var MetaTags = '<%=MetaTags %>';

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    function LaodImageGallery(CategoryID) {
        var ldimgwnd = window.parent;
        ldimgwnd.OnCategoryClick(CategoryID);
    } 
           
</script>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"
        EnablePageMethods="true">
    </telerik:RadScriptManager>
    <div id="divEditContents" runat="server">
        <div align="left" style="margin: 20px 0px 0px 10px;" class="div_floatleft">
            <div class="bglabel" style="width: 100px;">
                <asp:Label ID="lblTitle" runat="server" CssClass="normaltext"> <%=objLanguage.GetLanguageConversion("Title")%> </asp:Label>
            </div>
            <div class="box">
                <asp:TextBox ID="txtTitle" runat="server" Text='<%=FileName %>' SkinID="textPad"
                    MaxLength="200" Width="200px" TabIndex="2"></asp:TextBox>
                <asp:HiddenField ID="hdntitle" runat="server" Value="" />
            </div>
            <div class="bglabel" style="width: 100px;">
                <asp:Label ID="lblCategory" runat="server" CssClass="normaltext"> <%=objLanguage.GetLanguageConversion("Category")%> </asp:Label>
            </div>
            <div class="box">
                <telerik:RadComboBox ID="cboCategory" runat="server" Width="200">
                </telerik:RadComboBox>
                <asp:HiddenField ID="hdncategory" runat="server" Value="" />
            </div>
            <div class="bglabel" style="width: 100px;">
                <asp:Label ID="Label1" runat="server" CssClass="normaltext"> <%=objLanguage.GetLanguageConversion("Meta_Tags")%> </asp:Label>
            </div>
            <div class="box">
                <asp:TextBox ID="txtTag" runat="server" Text='<%=MetaTags %>' SkinID="textPad" MaxLength="200"
                    Width="200px" TabIndex="3"></asp:TextBox>
                <asp:HiddenField ID="hdntags" runat="server" Value="" />
            </div>
            <div class="bglabel" style="width: 100px;">
                <asp:Label ID="lblDesc" runat="server" CssClass="normaltext"> <%=objLanguage.GetLanguageConversion("Description")%> </asp:Label>
            </div>
            <div class="box">
                <asp:TextBox ID="txtDesc" runat="server" Text='<%=Description %>' SkinID="textPad"
                    TextMode="MultiLine" Width="200px" TabIndex="4"></asp:TextBox>
                <asp:HiddenField ID="hdnDesc" runat="server" Value="" />
            </div>
            <div>
                <div style="padding: 10px 0px 0px 110px;" class="div_floatleft">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="Update" OnClick="btnUpdate_onclick"
                        TabIndex="5" OnClientClick="javascript:Update();"></asp:Button>
                </div>
                <div id="div_btnCancel" style="padding: 10px 0px 0px 10px;" class="div_floatleft">
                    <div id="div_btncnl" style="display: block">
                        <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Cancel" CausesValidation="False"
                            TabIndex="6" OnClientClick="javascript:CloseWindow();" OnClick="btncancel_onclick">
                        </asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <div style="float: left; margin: 20px 0px 0px 0px; width: 45%">
            <div style="float: left; height: 200px" onmouseover="javascript:showchange();" onmouseout="javascript:HideChange();">
                <div id="divChangeImg" runat="server" class="divChangeImg">
                    <a href="#" id="imgchange" runat="server" onclick="javascript:loadradwindow();"><span
                        style="color: White; margin-left: 110px;">
                        <%=objLanguage.GetLanguageConversion("Change")%>
                    </span></a>
                </div>
                <div class="ImgGal">
                    <img id="imgGal" runat="server" width="280" height="200" alt="Image" src="" /></div>
            </div>
        </div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" VisibleTitlebar="true"
                    VisibleStatusbar="false" Modal="true" ShowContentDuringLoad="false" Behaviors="Close,Move">
                    <ContentTemplate>
                        <div id="dialog">
                            <div style="float: left;">
                                <div class="bglabel" style="margin: 10px 0px 0px 20px; width: 130px;">
                                    <asp:Label ID="lblSelectfile" runat="server" CssClass="normaltext"> <%=objLanguage.GetLanguageConversion("Select_File")%> </asp:Label>
                                </div>
                                <div class="fileUpload">
                                    <telerik:RadUpload ID="flImageUpload" runat="server" ControlObjectsVisibility="All"
                                        AllowedFileExtensions="jpg,jpeg,png,gif,pdf" TargetFolder='<%# _imagpath %>'
                                        BorderWidth="0" MaxFileInputsCount="1">
                                    </telerik:RadUpload>
                                </div>
                            </div>
                            <div style="padding-left: 192px; float: left;">
                                <asp:Button ID="btnUplaod" runat="server" Text="Upload" OnClick="btnUpload_Click"
                                    OnClientClick="javascript:return closeredwindow()" class="button" Style="width: 65px;">
                                </asp:Button>
                                <asp:HiddenField ID="hdnNewfileName" runat="server" Value="" />
                            </div>
                        </div>
                    </ContentTemplate>
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    <div id="divNoImage" style="display: none;" runat="server">
        <table style="background-color: #FFFFFF" frame="border" width="600" border="0" cellspacing="0"
            cellpadding="0" align="center">
            <tr valign="top">
                <td>
                    <table width="600" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF">
                        <tr>
                            <td align="left" style="width: 138px" class="toptext1">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <table width="76%" border="0" cellspacing="0" cellpadding="0" align="right">
                                    <tr>
                                        <td align="left" class="normaltext">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 9">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <%--<img src="images_home/header.gif" width="400" height="193">--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table cellpadding="0" cellspacing="0" align="center" style="width: 100%; height: 99%;
                                    margin-top: 15%">
                                    <tr>
                                        <td align="center">
                                            <div class="messageboxSessionLogoutNew" style="padding: 6px 0px 5px 0px">
                                                <div>
                                                    <div>
                                                        This Image already deleted from the Gallery</div>
                                                    <div class="only5px">
                                                    </div>
                                                    <div>
                                                        <%-- <asp:Button ID="btnBack" runat="server" CssClass="button" Width="65px" Text="Back"
                                                            Style="padding: 3px 2px 5px;" OnClick="btnBack_OnClick" />--%>
                                                        <%-- <asp:Label ID="lblBack" runat="server" Style="color: #193D7E; cursor: pointer;" Text="Please click here to go back"></asp:Label>--%>
                                                        <asp:LinkButton ID="btnBack" runat="server" Text="Please click here to go back" OnClientClick="javascript:ClosePopUp();  return false;"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        function showchange() {
            document.getElementById("<%=divChangeImg.ClientID %>").style.display = "block";
        }
        function HideChange() {
            document.getElementById("<%=divChangeImg.ClientID %>").style.display = "none";
        }
        function loadradwindow() {
            var RadPopupwin;
            RadPopupwin = $find("<%= RadWindow1.ClientID %>");
            RadPopupwin.setSize(500, 150);
            RadPopupwin.show();
        }

        function closeredwindow() {
            var valid = true;
            var upload = $find("<%= flImageUpload.ClientID %>");
            var inputs = upload.getFileInputs();
            RadPopupwin = $find("<%= RadWindow1.ClientID %>");
            if (inputs[0].value == "") {
                alert('Please select file to upload');
                valid = false;
            }
            else {
                var fileExtention = inputs[0].files[0].name.substring(inputs[0].files[0].name.lastIndexOf('.') + 1, inputs[0].files[0].name.length);
                if (upload._allowedFileExtensions.indexOf(fileExtention.toLowerCase()) == -1) {
                    alert('Please select valid file(allowed files: jpg,jpeg,png,gif,pdf)');
                    valid = false;
                }
            }
            if (valid == true) {
                RadPopupwin.close();
            }
            else {
                RadPopupwin.show();
            }
            return valid;
        }

        function Update() {
            var title = document.getElementById("<%=txtTitle.ClientID %>");
            var tags = document.getElementById("<%=txtTag.ClientID %>");
            var desc = document.getElementById("<%=txtDesc.ClientID %>");
            var catID = document.getElementById("<%=cboCategory.ClientID %>");
            document.getElementById("<%=hdntitle.ClientID %>").value = title.value;
            document.getElementById("<%=hdntags.ClientID %>").value = tags.value;
            document.getElementById("<%=hdnDesc.ClientID %>").value = desc.value;
            document.getElementById("<%=hdncategory.ClientID %>").value = catID.control._value;
        }

        function CloseWindow() {
            GetRadWindow().close();
        }

        function ClosePopUp() {
            GetRadWindow().close();
            var pw = window.parent;
            pw.location.reload();
        }
    </script>
    <style type="text/css">
        #RadWindow1_C_flImageUploadcheckbox0
        {
            display: none;
        }
        #RadWindow1_C_flImageUploadclear0
        {
            display: none;
        }
        #RadWindow1_C_flImageUploadremove0
        {
            display: none;
        }
        #RadWindow1_C_flImageUploadAddButton
        {
            display: none;
        }
        #RadWindow1_C_flImageUploadDeleteButton
        {
            display: none;
        }
        #RadWindow1_C_flImageUpload
        {
            width: 200px !important;
        }
    </style>
</body>
</html>

