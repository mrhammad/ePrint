<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EstimateInvoiceAndJobMenu.ascx.cs" Inherits="ePrint.usercontrol.Item.EstimateInvoiceAndJobMenu" %>



 


<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script src="<%=strSitepath %>js/item/crm.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
    rel="stylesheet" />
<script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/demo.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/jquery.timer.js?VN='<%=VersionNumber%>'"></script>
<%--New--%>
<script type="text/javascript" src="<%=strSitepath %>js/changeStyle.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/CRM_json.js?VN='<%=VersionNumber%>'"></script>
<link href="<%=strSitepath %>jquery_alerts/jquery.alerts.css"
    type="text/css" rel="stylesheet" />
<link href="/jquery_alerts/jquery.alerts.css" rel="stylesheet" type="text/css" />
<script src="<%=strSitepath %>jquery_alerts/jquery.alerts.js"
    type="text/javascript"></script>
<script src="<%=strSitepath %>uploader_include/jslibs/jquery.uploadify.js?VN='<%=VersionNumber%>'"
    type="text/javascript"></script>
<link type="text/css" href="<%=strSitepath %>uploader_include/css/uploadify.css"
    rel="stylesheet" />
<link rel="Stylesheet" type="text/css" href="/uploader_include/CSS/uploadify.css" />
<script type="text/javascript" src="/uploader_include/jslibs/jquery.uploadify.js"></script>
<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
<div id="ds00" style="display: block;">
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<script type="text/javascript">
    // var Add_Follow_Up_Task_Msg = '<%=objLanguage.GetLanguageConversion("Add_Task") %>';
    $(function () {
        $("#radio").buttonset();
    });
</script>
<style type="text/css">
    .AddBtn
    {
        background-image: url('../Grid1/sprite.gif');
        margin-right: 3px;
        background-position: 0 -1650px;
        width: 200px;
        background-repeat: no-repeat;
        padding-left: 23px;
    }
    #ContentPlaceHolder1_Client_RadGridContact_ctl03_ctl01_ChangePageSizeLabel, #ContentPlaceHolder1_Client_RadGridContact_ctl03_ctl01_PageSizeComboBox
    {
        display: none;
    }
    div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td
    {
        border-style: solid;
        border-color: #C9C9C9;
        border-width: 0 0 1px 0px;
    }
    .RadGrid .rgHeader, .RadGrid th.rgResizeCol
    {
        padding-top: 5px;
        text-align: left;
        font-weight: normal;
    }
    .RadGrid .rgFilterRow td
    {
        padding-top: 4px;
        padding-bottom: 4px;
    }
    .RowMouseOver td
    {
        background-color: #D8D8D8 !important;
        height: auto;
    }
    .RowMouseOut
    {
        background: #ffffff;
        height: auto;
    }
    
    .RadGrid .rgSelectedRow
    {
        background-color: #8F8F8F !important;
        background-image: none !important;
        height: auto;
    }
    
    .RadGrid_Default .rgCommandCell
    {
        border-right: 0px solid rgb(242, 242, 242);
        border-width: 0px 0px 0px;
        border-style: inherit;
        -moz-border-top-colors: none;
        -moz-border-right-colors: none;
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        border-image: none;
        border-color: rgb(153, 153, 153) rgb(242, 242, 242);
        padding: 0px;
        border: 0px solid red;
    }
    .RadGrid_Default .rgCommandTable
    {
        border-right: 0px none;
        border-left: 0px none;
        -moz-border-top-colors: none;
        -moz-border-right-colors: none;
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        border-image: none;
        border-width: 0px 0px;
        border-style: solid none;
        border-color: rgb(253, 253, 253) -moz-use-text-color rgb(231, 231, 231);
    }
    .RadGrid .rgClipCells .rgHeader, .RadGrid .rgClipCells .rgFilterRow > td, .RadGrid .rgClipCells .rgRow > td, .RadGrid .rgClipCells .rgAltRow > td, .RadGrid .rgClipCells .rgEditRow > td, .RadGrid .rgClipCells .rgFooter > td
    {
        overflow: visible;
    }
    .RadGrid_Default .rgEditForm
    {
        border-bottom: 1px solid rgb(130, 130, 130);
        background-color: White;
    }
    .upload-wrap
    {
        background-image: url('../images/Upload_Image.png');
        width: 224px;
        height: 25px;
        margin-top: -5px;
        margin-left: -4px;
    }
    .MinimumWidth
    {
        min-width: 73.4px;
    }
    .DialogueBackgroundSurveyView
    {
        background-color: White;
        filter: alpha(opacity=50);
        opacity: 0.50;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        display: block;
        z-index: 5055;
    }
    .AllnotesbckFade
    {
        background-color: White;
        filter: alpha(opacity=50);
        opacity: 0.50;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        display: block;
        z-index: 5055;
    }
    .detalilslayer
    {
        background-color: #D2D2D2;
        filter: alpha(opacity=50);
        opacity: 0.50;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        display: block;
        z-index: 50;
    }
    .DialogueBackgroundRdWindow
    {
        background-color: #D2D2D2;
        filter: alpha(opacity=50);
        opacity: 0.50;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        display: block;
        z-index: 50;
    }
    .RadGrid_Default .rgCommandRow
    {
        background: url("");
        color: rgb(0, 0, 0);
    }
    
    .RadGrid_Default .rgHeaderDiv
    {
        background: url("");
    }
    .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol
    {
        border-style: none none none;
        border-color: -moz-use-text-color -moz-use-text-color rgb(130, 130, 130);
        -moz-border-top-colors: none;
        -moz-border-right-colors: none;
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        border-image: none;
        background: url("../images/topbar11.png");
    }
    .RadGrid_Default .rgFilterRow
    {
        background: none;
    }
    div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td
    {
        border-style: solid;
        border-color: rgb(201, 201, 201);
        border-width: 0px 0px 1px;
    }
    .rgHeaderDiv
    {
        width: 100% !important;
        padding-right: 0px;
    }
    .moreaction
    {
        font-size: 12px;
        color: Gray;
    }
</style>
<asp:ScriptManagerProxy ID="smproxy" runat="server">
    <Services>
        <asp:ServiceReference Path="~/AutoFill.asmx" />
    </Services>
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <ContentTemplate>
       <%-- <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Contact">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Contact" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Department">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Department" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Address">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Address" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="div3">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="CheckOne_new_Address" />
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Address" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Products">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Products" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Email">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Email" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Estimates">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Estimates" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_eStore">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_eStore" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Jobs">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Jobs" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Invoices">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Invoices" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="grdcostcentre">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="grdcostcentre" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGridContact">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGridContact" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>--%>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server"
            Skin="Default" />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="upProgress" runat="server">
    <ProgressTemplate>
        <div id="div_Load" class="loading_new" style="display: block; z-index: 99999">
            <table cellpadding="0" cellspacing="10">
                <tr>
                    <td>
                        <div id="DivBigLoadingImg" style="float: left">
                            <img src="<%=ImgPath %>loading_new.gif" border="0" /></div>
                    </td>
                </tr>
            </table>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<div id="divLoadingImageCus" runat="server" style="display: none;">
    <div id="DivLayer" class="DialogueBackgroundSurveyView">
    </div>
    <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 40%;">
        <img src="<%=ImgPath %>loading_new.gif" border="0" style="border-radius: 2px;" />
    </div>
</div>
<div id="divallnotesbckfade" class="AllnotesbckFade" style="display: none;">
</div>
<div id="Divshowallnotes" style="min-height: 212px; height: 412px; width: 980px;
    left: 10%; position: absolute; top: 18%; z-index: 5555555; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton26" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseAllnotesPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: -12px;">
        <tr>
            <td style="width: 400px;">
                <div>
                    <asp:Label ID="lblti" runat="server" Text="Account Notes" CssClass='NotesSumm' Style='font-weight: bold;'>
                    <%=objLangClass.GetLanguageConversion("Account_Notes")%>
                    </asp:Label>
                    <asp:Label ID="lblnotecount" runat="server" Text="" Style='font-weight: bold; font-size: 12px;'>                    
                    </asp:Label>
                </div>
            </td>
            <td>
                <div align="center" id="DivAllNotesMessage" style="margin-bottom: 0px; display: none;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="DivAllNoteImgMsg" class="msg_success123">
                                </div>
                            </td>
                            <td>
                                <div id="Div16" style="margin-bottom: 4px;">
                                    <asp:Label ID="lblAllnotessucmsg" runat="server" Text="Note Deleted Successfully"
                                        Style="color: #FD8404; font-weight: bold; font-size: 11px;" CssClass="lblSuccMesgCl"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table style='border: 0px solid red; width: 100%; margin-top: 7px;' cellpadding='0'
        cellspacing='0'>
        <tr>           
            <td class='bgcustomizeNew' style='width: 17%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold; margin-left:5px;'>
                        <%=objLangClass.GetLanguageConversion("Note_Title")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 20%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Note_Content")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Specific_to_Contact")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Created_By")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Date")%></span>
                </div>
            </td>
             <td class='bgcustomizeNew' style='width: 6%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; margin-left: 3px; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Action")%></span>
                </div>
            </td>
        </tr>
    </table>
    <div id="divscroll" style="height: 377px; width: 100%; overflow: auto; overflow-x: hidden;
        margin-top: 0px;">
        <asp:Label ID="lblAllNotes" runat="server"></asp:Label>
    </div>
</div>
<div id="DicShowAllCl" style="min-height: 212px; height: 412px; width: 980px; left: 10%;
    position: absolute; top: 18%; z-index: 5555555; opacity: 1; display: none;" class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton29" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseAllClPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: -12px;">
        <tr>
            <td style="width: 400px;">
                <div>
                    <asp:Label ID="lblclosetask" runat="server" Text="Close Tasks & Calls" CssClass='NotesSumm'
                        Style='font-weight: bold;'>
                        
                    </asp:Label>
                    <asp:Label ID="lblClCounts" runat="server" Text="" Style='font-weight: bold; font-size: 12px;'>
                    </asp:Label>
                </div>
            </td>
            <td>
                <div align="center" id="DivAllClMsg" style="margin-bottom: 0px; display: none;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="Div20" class="msg_success123">
                                </div>
                            </td>
                            <td>
                                <div id="Div21" style="margin-bottom: 4px;">
                                    <asp:Label ID="lblAllClMsg" runat="server" Text="Note Deleted Successfully" Style="color: #FD8404;
                                        font-weight: bold; font-size: 11px;" CssClass="lblSuccMesgCl"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table id='Table2' style='border: 0px solid red; margin-top: 7px; width: 100%' cellpadding='0'
        cellspacing='0'>
        <tr>
            <td class='bgcustomizeNew' style='width: 6%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; margin-left: 5px; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Action")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 9%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Status")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 17%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Subject")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 5%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Type")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Due_Date")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Name")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 10%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Phone")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Assigned_To")%></span>
                </div>
            </td>
        </tr>
    </table>
    <div id="div22" style="height: 382px; width: 100%; overflow: auto; overflow-x: hidden;
        margin-top: 0px;">
        <asp:Label ID="lblAllCl" runat="server"></asp:Label>
    </div>
</div>
<div id="DicShowAllOpenActivities" style="min-height: 212px; height: 412px; width: 980px;
    left: 10%; position: absolute; top: 18%; z-index: 5555555; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton28" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseAllOAPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: -12px;">
        <tr>
            <td style="width: 400px;">
                <div>
                    <asp:Label ID="lblopentask" runat="server" Text="Open Tasks & Calls" CssClass='NotesSumm'
                        Style='font-weight: bold;'>                        
                    </asp:Label>
                    <asp:Label ID="lblopenActivityCount" runat="server" Text="" Style='font-weight: bold;
                        font-size: 12px;'>
                    </asp:Label>
                </div>
            </td>
            <td>
                <div align="center" id="DivdeleteAllOA" style="margin-bottom: 0px; display: none;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="Div17" class="msg_success123">
                                </div>
                            </td>
                            <td>
                                <div id="Div18" style="margin-bottom: 4px;">
                                    <asp:Label ID="Label145" runat="server" Text="Note Deleted Successfully" Style="color: #FD8404;
                                        font-weight: bold; font-size: 11px;" CssClass="lblSuccMesgCl"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table id='tbOpenActivities' style='border: 0px solid red; margin-top: 7px; width: 100%'
        cellpadding='0' cellspacing='0'>
        <tr>
           
            <td class='bgcustomizeNew' style='width: 9%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold; margin-left:5px;'>
                        <%=objLangClass.GetLanguageConversion("Status")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 17%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Subject")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 5%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Type")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Due_Date")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Name")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 10%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Phone")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Assigned_To")%></span>
                </div>
            </td>
             <td class='bgcustomizeNew' style='width: 7%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; margin-left: 5px; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Action")%></span>
                </div>
            </td>
        </tr>
    </table>
    <div id="div19" style="height: 382px; width: 100%; overflow: auto; overflow-x: hidden;
        margin-top: 0px;">
        <asp:Label ID="lblAllOA" runat="server"></asp:Label>
    </div>
</div>
<div id="DivOpenActiDetails" style="min-height: 220px; height: auto; width: 505px;
    left: 30%; position: absolute; top: 18%; z-index: 5555555; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton22" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseOADetails(); return false;"></asp:LinkButton>
    </div>
    <div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label126" runat="server" Text="Status" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Status")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetStatus" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label128" runat="server" Text="Subject" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Subject")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lblDetSubject" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label127" runat="server" Text="Type" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Type")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetType" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label129" runat="server" Text="Due Date" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Due_Date")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetDueDate" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label130" runat="server" Text="Contact Name" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Contact_Name")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetContactName" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label131" runat="server" Text="Contact Phone" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Contact_Phone")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetContactPhone" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label133" runat="server" Text="Assigned To" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Assigned_To")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetAssignTo" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label141" runat="server" Text="Notes" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Notes")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetDescription" runat="server" Width="322px" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div style="float: left; margin-top: 20px; width: 100%;">
            <table border="0" cellpadding="0" cellspacing="0" style="float: left;">
                <tr>
                    <td>
                        <asp:Button ID="btnDelEdit" runat="server" CssClass="button" Text="Edit" OnClientClick="javascript:Edit_TaskCallDetails(this.id); return false;">
                        </asp:Button>
                    </td>
                    <td>
                        <div style="margin-left: 7px;">
                            <asp:Button ID="btnDelDelete" runat="server" CssClass="button" Text="Delete" CausesValidation="False"
                                Visible="true" OnClientClick="javascript:delete_TaskCallDetails();return false;">
                            </asp:Button>
                        </div>
                    </td>
                    <td id="divbtncomplete">
                        <div style="margin-left: 7px;">
                            <asp:Button ID="btndetComplete" runat="server" CssClass="button" Text="Complete"
                                CausesValidation="False" Visible="true" OnClientClick="javascript:Complete_TaskCallDetails();return false;">
                            </asp:Button>
                        </div>
                    </td>
                    <td>
                        <div style="margin-left: 7px;">
                            <asp:Button ID="btndelFollowTask" runat="server" CssClass="button" Text="Create follow up Task"
                                OnClientClick="javascript:CreateFollowUptask(this.id); return false;"></asp:Button>
                        </div>
                    </td>
                    <td>
                        <div id="divbtndelFollowCall" runat="server" style="margin-left: 7px;">
                            <asp:Button ID="btndelFollowCall" runat="server" CssClass="button" Text="Create follow up Call"
                                OnClientClick="javascript:CreateFollowUpCall(this.id); return false;"></asp:Button>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div id="DivNoteDetails" style="min-height: 160px; height: auto; width: 505px; left: 30%;
    position: absolute; top: 18%; z-index: 5555555; opacity: 1; display: none;" class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton27" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseNoteDetails(); return false;"></asp:LinkButton>
    </div>
    <div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label142" runat="server" Text="Note Title" CssClass="normalText">
                  <%=objLangClass.GetLanguageConversion("Note_Title")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetNoteTitle" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label146" runat="server" Text="Specific to Contact" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Specific_to_Contact")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetSpecifictoContact" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label148" runat="server" Text="Added By" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Created_By")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetAddedBy" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label150" runat="server" Text="Date" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Date")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetDate" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label144" runat="server" Text="Note Content" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Note_Content")%>
                </asp:Label>
            </div>
            <div class="box">
                <asp:Label ID="lbldetNoteContent" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div style="float: left; margin-top: 20px; width: 100%;">
            <table border="0" cellpadding="0" cellspacing="0" style="float: left;">
                <tr>
                    <td>
                        <asp:Button ID="btnDetailsEdit" runat="server" CssClass="button" Text="Edit" OnClientClick="javascript:Edit_DetailsNotes(); return false;">
                        </asp:Button>
                    </td>
                    <td>
                        <div style="margin-left: 7px;">
                            <asp:Button ID="btndeleteDetNotes" runat="server" CssClass="button" Text="Delete"
                                CausesValidation="False" Visible="true" OnClientClick="javascript:delete_Detailsnote();return false;">
                            </asp:Button>
                        </div>
                    </td>
                    <td id="Td1">
                        <div style="margin-left: 7px;">
                            <asp:Button ID="btnviewdetattachedfile" runat="server" CssClass="button" Text="View Attached File"
                                CausesValidation="False" Visible="true" OnClientClick="javascript:ShowNoteAttachedFiles();return false;">
                            </asp:Button>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div id="DivNotesPopup" style="min-height: 270px; height: auto; width: 450px; position: absolute;
    z-index: 9999; opacity: 1; display: none;" class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LnkCloseTaskPopup" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseTaskPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <div style="margin-top: 19px; float: right; margin-right: -34px;">
        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CssClass="TaskRightArrow"></asp:LinkButton>
    </div>
    <div id="DivTaskMain">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: -8px; width: 480px;">
            <tr>
                <td colspan="2">
                    <div align="left" style="margin-top: -11px; margin-bottom: 11px;">
                        <asp:Label ID="Label113" runat="server" Text="" CssClass="normalText" Style="font-size: 15px;">
                         <%=objLangClass.GetLanguageConversion("Add_Task")%>
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="margin-top: -5px; border-bottom: 1px dashed gray; margin-bottom: 13px;
                        width: 460px;">
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top"style="width:239px;" >
                    <table border="0" cellpadding="0" cellspacing="0" style=" width:239px;">
                        <tr>
                            <td>
                                <div style="margin-top: 0px;">
                                    <asp:Label ID="Label56" runat="server" Text="Assigned to" Style="color: #383838;">  <%=objLangClass.GetLanguageConversion("Assigned_To")%></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px; float: left;">
                                    <asp:DropDownList runat="server" ID="ddlassigneto" CssClass="simpledropdownPopup"
                                        Width="200px" TabIndex="501">
                                    </asp:DropDownList>
                                </div>
                                <div id="DivSpan_ddlassigneto" style="display: none; width: 16px; float: left; margin-left: 5px;
                                    margin-top: 5px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="LblSubject" runat="server" Text="Subject" CssClass="normalText" Style="color: #383838;">
                                         <%=objLangClass.GetLanguageConversion("Subject")%>
                                    </asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                                <div style="float: left; margin-left: 6px; margin-top: 7px;">
                                    <asp:ImageButton ID="ImageButton9" OnClientClick="javascript:OpenSubjectDiv();return false;"
                                        runat="server" ToolTip="Add new subject" CausesValidation="False" ImageUrl="~/images/plus.gif">
                                    </asp:ImageButton>
                                </div>
                                <div style="float: left; margin-left: 6px; margin-top: 7px;">
                                    <asp:ImageButton ID="ImgClearSubject" OnClientClick="javascript:ClearSubjectDrop();return false;"
                                        runat="server" ToolTip="Clear subject" CausesValidation="False" ImageUrl="~/images/Clear_sub.png"
                                        Style="height: 15px; width: 16px; display: none;"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlsubject" CssClass="simpledropdownPopup" Width="200px"
                                        onchange="javascript:Displayclearbutton(); return false;" TabIndex="503">
                                    </asp:DropDownList>
                                </div>
                                <div id="spn_ddlsubject" style="display: none; width: 16px; float: left; margin-left: 5px;
                                    margin-top: 4px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px; float: left;">
                                    <asp:Label ID="Label59" runat="server" Text="Contact" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Contact")%></asp:Label>
                                </div>
                                <div style="float: left; margin-left: 5px; margin-top: 7px; display: none;">
                                    <asp:ImageButton ID="ImageButton2" OnClientClick="javascript:OpenShowContactDiv();return false;"
                                        runat="server" ToolTip="Select Contact" CausesValidation="False" ImageUrl="~/images/plus.gif">
                                    </asp:ImageButton>
                                </div>
                                <div style="float: left; margin-left: 6px; margin-top: 7px;">
                                    <asp:ImageButton ID="imgClearcontacts" OnClientClick="javascript:ClearContacts();return false;"
                                        runat="server" ToolTip="Clear contact" CausesValidation="False" ImageUrl="~/images/Clear_sub.png"
                                        Style="height: 15px; width: 16px; display: none;"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlTaskContacts" CssClass="simpledropdownPopup"
                                        Width="200px" TabIndex="505">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label102" runat="server" Text="Create Follow Up" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Create_Follow_Up")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddltaskFollow" CssClass="simpledropdownPopup"
                                        Width="205px" TabIndex="508">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top"  style="width:239px;">
                    <table>
                        <tr>
                            <td>
                                <div style="margin-top: -2px;">
                                    <asp:Label ID="Label57" runat="server" Text="Status" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Status")%></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: -1px; float: left;">
                                    <asp:DropDownList runat="server" ID="ddlstatus" CssClass="simpledropdownPopup" Width="200px"
                                        TabIndex="502">
                                    </asp:DropDownList>
                                </div>
                                <div id="Span_ddlstatus" style="display: none; width: 16px; float: left; margin-left: 5px;
                                    margin-top: -1px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 3px;">
                                    <asp:Label ID="Label58" runat="server" Text="Priority" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Priority")%></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 2px; float: left;">
                                    <asp:DropDownList runat="server" ID="ddlpriority" CssClass="simpledropdownPopup"
                                        Width="200px" TabIndex="504">
                                    </asp:DropDownList>
                                </div>
                                <div id="Span_ddlpriority" style="display: none; width: 16px; float: left; margin-left: 5px;
                                    margin-top: 1px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 3px;">
                                    <asp:Label ID="Label60" runat="server" Text="Due Date" Style="color: #383838;"></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                    <asp:Label ID="Label149" runat="server" Text="Time (hh:mm)" Style="color: #383838;
                                        margin-left: 25px;"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: -2px; float: left;">
                                    <div style="display: none;">
                                        &nbsp;&nbsp;<asp:DropDownList ID="ddlhour" runat="server" CssClass="normaltext" Width="50px"
                                            ToolTip="Hour(s)">
                                        </asp:DropDownList>
                                        :
                                        <asp:DropDownList ID="ddlminute" runat="server" CssClass="normaltext" Width="48px"
                                            ToolTip="Minute(s)">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:TextBox ID="txtduedate" runat="server" SkinID="textPad" CssClass="txtbox" Width="82px"
                                        TabIndex="506"> </asp:TextBox>&nbsp;&nbsp;
                                    <telerik:RadTimePicker ID="RadTimePicker" runat="server" SkinID="textPad" Height="19px"
                                        ZIndex="30001" inputmode="TimePicker" CssClass="normaltext" TabIndex="507">
                                        <DateInput ID="DateInput1" runat="server" DateFormat="hh:mm tt" DisplayDateFormat="hh:mm tt">
                                        </DateInput>
                                        <ClientEvents OnDateSelected="DateSelected" />
                                        <TimeView ID="TimeView1" runat="server" TimeFormat="hh:mm tt" Columns="3" OnClientTimeSelected="ClientTimeSelected"
                                            Interval="0:30:0" TimeOverStyle-CssClass="rcHover">
                                        </TimeView>
                                        <Calendar ID="Calendar1" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x" >
                                        </Calendar>
                                    </telerik:RadTimePicker>
                                </div>
                                <div id="Span_txtduedate" style="display: none; width: 16px; float: left; margin-left: 2px;
                                    margin-top: -1px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="Span_txtduedate1" style="display: none; width: 196px; float: left; margin-left: 0px;
                                    margin-top: 4px; color: Red;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px"></span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>
                                <div style="margin-top: 13px;">
                                    <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="TextBox1" runat="server" SkinID="textPad" Width="205px"><%=objLangClass.GetLanguageConversion("More_Fields")%> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkSlideRight" runat="server" CssClass="MorefieldRighrImg" ToolTip="Slide Right"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <div style="margin-top: 7px;">
                                    <asp:Label ID="Label61" runat="server" Text="Description" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Description")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px; width: 100%;">
                                    <asp:TextBox ID="txtNotesDesc" runat="server" SkinID="textPad" CssClass="txtbox"
                                        TextMode="MultiLine" Width="442px" Style="max-width: 442px; max-height: 230px;"
                                        TabIndex="509"> </asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 5px;">
                                    <div style="float: left; margin-top: 10px; display: none;">
                                        <asp:Button ID="Button5" runat="server" CssClass="button" Text="Close" OnClientClick="javascript:CloseTaskPopup(); return false;">
                                        </asp:Button>
                                    </div>
                                    <div style="float: left; margin-left: 0px; margin-top: 10px;">
                                        <asp:Button ID="btnsavenotes" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                            Visible="true" OnClientClick="javascript:Validatesavenotes();return false;">
                                        </asp:Button>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="DivTaskMainSecond" style="position: absolute; width: 99%; right: 0px; display: none;">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 15px;">
            <tr>
                <td>
                    <div style="margin-top: 0px;">
                        <asp:Label ID="Label62" runat="server" Text="More Fields" Style="font-size: 16px;"> <%=objLangClass.GetLanguageConversion("More_Fields")%> </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 10px; border-bottom: 1px dashed gray; width: 220px; margin-bottom: 10px;">
                        <asp:Label ID="Label63" runat="server" Text="" Style="font-size: 16px;"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-top: 15px;">
                        <asp:Button ID="Button6" runat="server" CssClass="button" Text="Back" CausesValidation="False"
                            Visible="true"></asp:Button>
                    </div>
                    <div style="float: left; margin-left: 7px; margin-top: 15px;">
                        <asp:Button ID="btnsavenotes1" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                            Visible="true" OnClientClick="javascript:ValiSaveTasks();return false;"></asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="DivOpenSubject" style="height: 85px; width: 313px; left: -38%; position: absolute;
        top: -1%; z-index: 9999; opacity: 1; display: none;" class="Popupnotes">
        <div style="margin-top: -32px; float: right; margin-right: -30px;">
            <asp:LinkButton ID="lblAddSubject" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
                OnClientClick="javascript:CloseTaskPopupAddSubject(); return false;"></asp:LinkButton>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1" style="margin-top: -10px;">
            <tr>
                <td>
                    <asp:Label ID="Label92" runat="server" SkinID="textPad" Width="302px"><%=objLangClass.GetLanguageConversion("Add_New_Subjects")%></asp:Label>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 7px;">
            <tr>
                <td>
                    <div class="bglabel" style="margin-top: 12px; width: 100px;">
                        <asp:Label ID="Label64" runat="server" Text="Subject" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Subject")%></asp:Label>
                        <span class="redver7" style="margin-left: -1px; margin-top: -2px;">*</span>
                    </div>
                </td>
                <td>
                    <div style="margin-top: 10px; margin-left: 4px; float: left;">
                        <div style="float: left;">
                            <asp:TextBox ID="txtSubject" runat="server" SkinID="textPad" CssClass="txtbox" Width="178px"
                                Height="21px"> </asp:TextBox>
                        </div>
                        <div id="DivSubjectAddValidations" style="display: none; width: 16px; float: left;
                            margin-left: 5px;">
                            <div class="RFV_Message" style="border-radius: 2px; float: left;">
                                <span style="float: left; padding-left: 4px">*</span>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="float: left; margin-top: 10px; margin-left: 115px;">
                        <asp:Button ID="lnkSaveSubject" runat="server" CssClass="button" Text="Save" Visible="true"
                            CausesValidation="false" OnClientClick="javascript:ValidateAddSubject();return false;">
                        </asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="DivAddNewEvents" style="min-height: 395px; width: 210px; position: absolute;
    z-index: 9999; opacity: 1; display: none;" class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px; display: none;">
        <asp:LinkButton ID="lnkCloseEvents" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseEventsPopup(); return false;"></asp:LinkButton>
    </div>
    <div style="margin-top: 19px; float: right; margin-right: -34px;">
        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" CssClass="TaskRightArrow"></asp:LinkButton>
    </div>
    <div id="DivEventsmain">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: -8px;">
            <tr>
                <td>
                    <div align="left" style="margin-top: -11px; margin-bottom: 11px;">
                        <asp:Label ID="Label117" runat="server" Text="Add Event" CssClass="normalText" Style="font-size: 15px;">
                        <%=objLangClass.GetLanguageConversion("Add_Event")%>
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: -5px; border-bottom: 1px dashed gray; width: 220px; margin-bottom: 13px;">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left;">
                        <asp:Label ID="Label65" runat="server" Text="Subject" Style="color: #383838;" CssClass="normalText"><%=objLangClass.GetLanguageConversion("Subject")%></asp:Label>
                        <span class="redver7" style="margin-left: -1px;">*</span>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:ImageButton ID="ImageButton3" OnClientClick="javascript:OpenEventSubjectDiv();return false;"
                            runat="server" ToolTip="Add new subject" CausesValidation="False" ImageUrl="~/images/plus.gif">
                        </asp:ImageButton>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 4px; float: left;">
                        <asp:DropDownList runat="server" ID="ddlEventsSubject" CssClass="simpledropdownPopup"
                            Width="200px">
                        </asp:DropDownList>
                    </div>
                    <div id="Span_ddlEventsSubject" style="display: none; width: 16px; float: left; margin-left: 5px;
                        margin-top: 3px;">
                        <div class="RFV_Message" style="border-radius: 2px;">
                            <span style="float: left; padding-left: 4px">*</span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 7px;">
                        <asp:Label ID="Label66" runat="server" Text="Assigned to" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Assigned_To")%></asp:Label>
                        <span class="redver7" style="margin-left: -1px;">*</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 4px; float: left;">
                        <asp:DropDownList runat="server" ID="ddlEventsAssignTo" CssClass="simpledropdownPopup"
                            Width="200px">
                        </asp:DropDownList>
                    </div>
                    <div id="Span_ddlEventsAssignTo" style="display: none; width: 16px; float: left;
                        margin-left: 5px; margin-top: 3px;">
                        <div class="RFV_Message" style="border-radius: 2px;">
                            <span style="float: left; padding-left: 4px">*</span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 7px;">
                        <asp:Label ID="Label67" runat="server" Text="Location" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Location")%></asp:Label>
                        <span class="redver7" style="margin-left: -1px;">*</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 4px; float: left;">
                        <asp:TextBox ID="txtLocationEvent" runat="server" SkinID="textPad" CssClass="txtbox"
                            Width="200px"> </asp:TextBox>
                    </div>
                    <div id="span_textPad" style="display: none; width: 16px; float: left; margin-left: 5px;
                        margin-top: 3px;">
                        <div class="RFV_Message" style="border-radius: 2px;">
                            <span style="float: left; padding-left: 4px">*</span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 7px;">
                        <asp:Label ID="Label68" runat="server" Text="Due Date" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Due_Date")%></asp:Label>
                        <span class="redver7" style="margin-left: -1px;">*</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 4px; float: left;">
                        <asp:TextBox ID="TxtDueDateEvent" runat="server" SkinID="textPad" CssClass="txtbox"
                            Width="200px"> </asp:TextBox>
                    </div>
                    <div id="Span_TxtDueDateEvent" style="display: none; width: 16px; float: left; margin-left: 5px;
                        margin-top: 3px;">
                        <div class="RFV_Message" style="border-radius: 2px;">
                            <span style="float: left; padding-left: 4px">*</span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="Span_TxtDueDateEvent1" style="display: none; width: 196px; float: left;
                        margin-left: 0px; margin-top: 4px; color: Red;">
                        <div class="RFV_Message" style="border-radius: 2px;">
                            <span style="float: left; padding-left: 4px"></span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 7px; float: left;">
                        <asp:Label ID="Label69" runat="server" Text="Contact" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Contact")%></asp:Label>
                    </div>
                    <div style="float: left; margin-left: 5px; margin-top: 7px; display: none;">
                        <asp:ImageButton ID="ImgOpemEventContact" OnClientClick="javascript:OpenShowEventContactDiv();return false;"
                            runat="server" ToolTip="Select Contact" CausesValidation="False" ImageUrl="~/images/plus.gif">
                        </asp:ImageButton>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 4px;">
                        <asp:DropDownList runat="server" ID="ddlEventContact" CssClass="simpledropdownPopup"
                            Width="200px">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 7px;">
                        <asp:Label ID="Label70" runat="server" Text="Time & Duration" Style="color: #383838;"> <%=objLangClass.GetLanguageConversion("Time_And_Duration")%></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 4px;">
                        <div style="float: left; display: none;">
                            <asp:DropDownList ID="ddlEventHours" runat="server" CssClass="normaltext" Width="41px">
                            </asp:DropDownList>
                            :
                            <asp:DropDownList ID="ddlEventmin" runat="server" CssClass="normaltext" Width="41px">
                            </asp:DropDownList>
                        </div>
                        <div style="float: left;">
                            <telerik:RadTimePicker ID="RadTimePicker2" runat="server" SkinID="textPad" Height="19px"
                                Width="95px" ZIndex="30001" inputmode="TimePicker" CssClass="normaltext">
                                <DateInput ID="DateInput3" runat="server" DateFormat="hh:mm tt" DisplayDateFormat="hh:mm tt">
                                </DateInput>
                                <ClientEvents OnDateSelected="DateSelected" />
                                <TimeView ID="TimeView3" runat="server" TimeFormat="hh:mm tt" Columns="3" OnClientTimeSelected="ClientTimeSelected"
                                    Interval="0:30:0" TimeOverStyle-CssClass="rcHover">
                                </TimeView>
                                <Calendar ID="Calendar3" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                    UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                            </telerik:RadTimePicker>
                        </div>
                        <span style="float: left; padding-left: 0px; margin-top: 3px;">|</span>
                        <div style="float: left; padding-left: 5px; margin-top: 2px;">
                            <asp:DropDownList ID="ddlEventHours1" CssClass="normaltext" runat="server" Width="41px">
                            </asp:DropDownList>
                            :
                            <asp:DropDownList ID="ddlEventmin1" CssClass="normaltext" runat="server" Width="41px">
                            </asp:DropDownList>
                        </div>
                        <div id="DivEventMinVali" style="display: none; width: 16px; float: left; margin-left: 5px;
                            margin-top: 1px;">
                            <div class="RFV_Message" style="border-radius: 2px;">
                                <span style="float: left; padding-left: 4px">*</span>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-top: 10px;">
                        <asp:Label ID="Label101" runat="server" Text="Create Follow Up" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Create_Follow_Up")%>
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-top: 4px;">
                        <asp:DropDownList runat="server" ID="ddlEventCreateFollow" CssClass="simpledropdownPopup"
                            Width="203px">
                            <asp:ListItem Text="--None--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Call" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Task" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 13px;">
                        <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1">
                            <tr>
                                <td>
                                    <asp:Label ID="Label71" runat="server" SkinID="textPad" Width="203px"> <%=objLangClass.GetLanguageConversion("More_Fields")%> </asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="MorefieldRighrImg" ToolTip="Slide Right"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-top: 10px;">
                        <asp:Button ID="Button9" runat="server" CssClass="button" Text="Close" OnClientClick="javascript:CloseEventsPopup(); return false;">
                        </asp:Button>
                    </div>
                    <div style="float: left; margin-left: 7px; margin-top: 10px;">
                        <asp:Button ID="lnkEventSave" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                            Visible="true" OnClientClick="javascript:InsertEventtoValidate();return false;">
                        </asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="DivEventsmainSecond" style="display: none;">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: -8px;">
            <tr>
                <td>
                    <div style="margin-top: 0px;">
                        <asp:Label ID="Label72" runat="server" Text="More Fields" Style="font-size: 16px;"><%=objLangClass.GetLanguageConversion("More_Fields")%></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 10px; border-bottom: 1px dashed gray; width: 220px; margin-bottom: 10px;">
                        <asp:Label ID="Label73" runat="server" Text="" Style="font-size: 16px;"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 8px;">
                        <asp:Label ID="Label74" runat="server" Text="Description" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Description")%></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 4px;">
                        <asp:TextBox ID="txtEventsDesc" runat="server" SkinID="textPad" CssClass="txtbox"
                            TextMode="MultiLine" Width="225px" Style="max-width: 225px; max-height: 220px;"> </asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-top: 15px;">
                        <asp:Button ID="Button10" runat="server" CssClass="button" Text="Back" CausesValidation="False"
                            Visible="true"></asp:Button>
                    </div>
                    <div style="float: left; margin-left: 7px; margin-top: 15px;">
                        <asp:Button ID="lnkEventSave1" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                            Visible="true" OnClientClick="javascript:InsertEventtoValidateNew();return false;">
                        </asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="DivOpenEventSubject" style="height: 85px; width: 313px; left: -37%; position: absolute;
        top: -4%; z-index: 9999; opacity: 1; display: none;" class="Popupnotes">
        <div style="margin-top: -32px; float: right; margin-right: -30px;">
            <asp:LinkButton ID="LinkButton10" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
                OnClientClick="javascript:CloseEventPopupAddSubject(); return false;"></asp:LinkButton>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1" style="margin-top: -10px;">
            <tr>
                <td>
                    <asp:Label ID="Label94" runat="server" SkinID="textPad" Width="302px"><%=objLangClass.GetLanguageConversion("Add_New_Subjects")%></asp:Label>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 7px;">
            <tr>
                <td>
                    <div class="bglabel" style="margin-top: 12px; width: 100px;">
                        <asp:Label ID="Label95" runat="server" Text="Subject" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Subject")%></asp:Label>
                        <span class="redver7" style="margin-left: -1px; margin-top: -2px;">*</span>
                    </div>
                </td>
                <td>
                    <div style="margin-top: 10px; margin-left: 4px; float: left;">
                        <div style="float: left;">
                            <asp:TextBox ID="txtEventSubject" runat="server" SkinID="textPad" CssClass="txtbox"
                                Width="178px" Height="21px"> </asp:TextBox>
                        </div>
                        <div id="Div_EventSubject_Validations" style="display: none; width: 16px; float: left;
                            margin-left: 5px;">
                            <div class="RFV_Message" style="border-radius: 2px; float: left;">
                                <span style="float: left; padding-left: 4px">*</span>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="float: left; margin-top: 10px; margin-left: 115px;">
                        <asp:Button ID="Button13" runat="server" CssClass="button" Text="Save" Visible="true"
                            CausesValidation="false" OnClientClick="javascript:ValidateEventsAddSubject();return false;">
                        </asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="DivMoreAction" runat="server" class="ddM3" style="display: none; margin-top: 30px;"
    onmouseover="javascript:OpenMoreActions(); return false;" onmouseout="javascript:ClosedMoreActions(); return false;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="moreactionpanel" style="width: 180px;">
                <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                    <asp:LinkButton ID="LnkSummary" runat="server" Text="Print/Email" OnClientClick="javascript:OpenClientDetailsDiv(); return false;"
                        Style="color: #000000;" CssClass="moreaction"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td class="moreactionpanel" style="width: 180px;">
                <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                    <asp:LinkButton ID="lnkDepartment" runat="server" Text="Add Item" OnClientClick="javascript:OpenDepartmentDiv(); return false;"
                        Style="color: #000000;" CssClass="moreaction"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td class="moreactionpanel" style="width: 180px;">
                <div id="DivlnlCostCentre" runat="server" style="margin-left: 6px; margin-top: 5px;
                    margin-bottom: 6px; display: none;">
                    <asp:LinkButton ID="lnlCostCentre" runat="server" Text="Progress To Job" OnClientClick="javascript:OpenCostCentreDiv(); return false;"
                        Style="color: #000000;" CssClass="moreaction"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td class="moreactionpanel" style="width: 180px;">
                <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                    <asp:LinkButton ID="lnkContact" runat="server" Text="Attachments" OnClientClick="javascript:OpenContactDiv(); return false;"
                        Style="color: #000000;" CssClass="moreaction"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td class="moreactionpanel" style="width: 180px;">
                <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                    <asp:LinkButton ID="lnkAddressBook" runat="server" Text="Copy Estimate" OnClientClick="javascript:OpenAddressBookDiv(); return false;"
                        Style="color: #000000;" CssClass="moreaction"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td class="moreactionpanel" style="width: 180px;">
                <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                    <asp:LinkButton ID="LinkButton1" runat="server" Text=" Re-Run Customer Details" OnClientClick="javascript:OpenAddressBookDiv(); return false;"
                        Style="color: #000000;" CssClass="moreaction"></asp:LinkButton>
                </div>
            </td>
        </tr>
    
       
      
       
    </table>
</div>
   <div style="float: left; margin-left: 7px; margin-top: 5px;">
                            <asp:Button ID="BtnMoreAction" runat="server" Text="Estimate OPtions" CssClass="moreoptions white" style="width:160px;background: url(../images/down_arrow.png) 95% no-repeat;
                font-size: 12px; padding-top: 2px; text-align: left;"
                                onmouseover="javascript:OpenMoreActions(); return false;" onmouseout="javascript:ClosedMoreActions(); return false;"
                                Width="120px" OnClientClick="javascript:return false;"></asp:Button>
                        </div>
    <asp:Label ID="lblNavigations" runat="server" Visible="false"></asp:Label>
    <asp:HiddenField ID="hdntodaydate" runat="server" />
    <asp:HiddenField ID="hdnCommanID" runat="server" />
    <asp:HiddenField ID="hdnSectionName" runat="server" />
    <asp:HiddenField ID="hdnbuttonid" runat="server" />
    <asp:HiddenField ID="hdnTaskFollowParentID" runat="server" />
    <asp:HiddenField ID="hdnTaskFollowParentType" runat="server" />
    <asp:HiddenField ID="hdnCallFollowParentID" runat="server" />
    <asp:HiddenField ID="hdnCallFollowParentType" runat="server" />
    <asp:HiddenField ID="hdnTaskFollowParentIDDet" runat="server" />
    <asp:HiddenField ID="hdnTaskFollowParentTypeDet" runat="server" />
    <asp:HiddenField ID="hdnCallFollowParentIDDet" runat="server" />
    <asp:HiddenField ID="hdnCallFollowParentTypeDet" runat="server" />
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
        width: 50%" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <asp:HiddenField runat="server" Value="" ID="hdnprintNotesValue" />
    <asp:HiddenField runat="server" Value="" ID="hdnPrintCusDetailsWithAddress" />
    <asp:HiddenField runat="server" Value="" ID="hdnPrintCusDetailsWithAllNotes" />
    <asp:HiddenField runat="server" Value="" ID="hdnPrintCusDetailsWithDeptInfo" />
    <asp:HiddenField runat="server" Value="" ID="AttID" />
    <script type="text/javascript" language="javascript">

        function ShowNoteAttachedFiles() {
            var AttID = document.getElementById("ContentPlaceHolder1_Client_AttID");
            var iframeAttachedFile = document.getElementById("ContentPlaceHolder1_Client_Ifattachedfiles");
            iframeAttachedFile.setAttribute("src", "../crm_view_attached_files.aspx?&AID=" + AttID.value + "&CID=" + CompanyID + "");
        }

        function delete_Detailsnote() {
            var AttID = document.getElementById("ContentPlaceHolder1_Client_AttID");
            Closepopups();
            if (window.confirm('Are you sure you want to delete?')) {
                document.getElementById("DivNoteDetails").style.display = "none";
                document.getElementById("divallnotesbckfade").style.display = "none";
                document.getElementById("DivAddNotePopup").style.position = "absolute";
                CallDelete_NotesMethod(CompanyID, SectionID, AttID.value, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }

        function Edit_DetailsNotes() {
            Closepopups();
            var AttID = document.getElementById("ContentPlaceHolder1_Client_AttID");

            document.getElementById("DivBtnNotesSave").style.marginTop = "0px";
            document.getElementById("DivBtnUpdateNotes").style.marginTop = "0px";
            document.getElementById("DivAddNotePopup").style.zIndex = "5555555555555";
            document.getElementById("DivAddNotePopup").style.position = "fixed";
            document.getElementById("DivAddNotePopup").style.left = "35%";
            document.getElementById("DivAddNotePopup").style.top = "10%";
            document.getElementById("DivAddNotePopup").style.display = "block";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";
            document.getElementById("DivCallSubjects").style.display = "none";
            document.getElementById("DivNotesPopup").style.display = "none";
            document.getElementById("DivTaskMain").style.display = "none";
            document.getElementById("DivTaskMainSecond").style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').focus();
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').value = "";
            document.getElementById('ContentPlaceHolder1_Client_txtNoteDesc').value = "";
            document.getElementById('divnotescontentvalidate').style.display = "none";
            document.getElementById('addfileDiv').style.display = "none";
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("DivShowNote").style.display = "none";
            document.getElementById("AddNote").style.display = "block";
            document.getElementById("divNoteTitle").style.display = "block";
            document.getElementById("DivFileUpload1").style.display = "none";
            document.getElementById("DivBtnNotesSave").style.display = "none";
            document.getElementById("DivBtnUpdateNotes").style.display = "none";
            document.getElementById("DivBtnUpdateAllNotes").style.display = "block";
            document.getElementById("DivCloseNoteTitle").style.display = "block";
            document.getElementById('rgarrow').style.display = "none";
            document.getElementById('lftarrow').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lblAddNoteTitle').innerHTML = "Edit Note";
            document.getElementById("DivBtnNotesSave").style.display = "none";

            CallEdit_NotesMethod(AttID.value); return false;
        }

        function CloseNoteDetails() {
            document.getElementById("DivNoteDetails").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "none";
        }
        function Notes_details(attachID) {

            Closepopups();
            var AttID = document.getElementById("ContentPlaceHolder1_Client_AttID");
            AttID.value = attachID;
            document.getElementById("divallnotesbckfade").style.display = "block";
            document.getElementById("DivNoteDetails").style.display = "block";
            document.getElementById("DivNoteDetails").style.zIndex = "5555555555555";
            document.getElementById("DivNoteDetails").style.position = "fixed";
            document.getElementById("DivNoteDetails").style.left = "30%";
            document.getElementById("DivAddNotePopup").style.display = "none";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";
            document.getElementById("DivCallSubjects").style.display = "none";
            document.getElementById("DivNotesPopup").style.display = "none";
            document.getElementById("DivTaskMain").style.display = "none";
            document.getElementById("DivTaskMainSecond").style.display = "none";
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("DivShowNote").style.display = "none";
            document.getElementById("AddNote").style.display = "block";
            document.getElementById("divNoteTitle").style.display = "block";
            document.getElementById("DivFileUpload1").style.display = "none";
            document.getElementById("DivBtnNotesSave").style.display = "none";
            document.getElementById("DivBtnUpdateNotes").style.display = "none";
            document.getElementById("DivCloseNoteTitle").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_btnviewdetattachedfile").style.display = "block";

            CallEdit_NotesMethod(attachID); return false;
        }


        function Notes_detailsWithOutFile(attachID) {

            Closepopups();
            var AttID = document.getElementById("ContentPlaceHolder1_Client_AttID");
            AttID.value = attachID;
            document.getElementById("divallnotesbckfade").style.display = "block";
            document.getElementById("DivNoteDetails").style.display = "block";
            document.getElementById("DivNoteDetails").style.zIndex = "5555555555555";
            document.getElementById("DivNoteDetails").style.position = "fixed";
            document.getElementById("DivNoteDetails").style.left = "30%";
            document.getElementById("DivAddNotePopup").style.display = "none";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";
            document.getElementById("DivCallSubjects").style.display = "none";
            document.getElementById("DivNotesPopup").style.display = "none";
            document.getElementById("DivTaskMain").style.display = "none";
            document.getElementById("DivTaskMainSecond").style.display = "none";
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("DivShowNote").style.display = "none";
            document.getElementById("AddNote").style.display = "block";
            document.getElementById("divNoteTitle").style.display = "block";
            document.getElementById("DivFileUpload1").style.display = "none";
            document.getElementById("DivBtnNotesSave").style.display = "none";
            document.getElementById("DivBtnUpdateNotes").style.display = "none";
            document.getElementById("DivCloseNoteTitle").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_btnviewdetattachedfile").style.display = "none";

            CallEdit_NotesMethod(attachID); return false;
        }


        function GetScreenCordinatesAllEditNotes(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft + 4.3;
                p.y = p.y + obj.offsetParent.offsetTop - 8;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function Edit_Allnotes(attachID, btnid) {

            Closepopups();
            document.getElementById("DivAddNotePopup").style.zIndex = "5555555555555";

            document.getElementById("DivBtnNotesSave").style.marginTop = "0px";
            document.getElementById("DivBtnUpdateNotes").style.marginTop = "0px";
            var txt = document.getElementById(btnid);
            var p = GetScreenCordinatesAllEditNotes(txt);

            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";
            document.getElementById("DivCallSubjects").style.display = "none";
            document.getElementById("DivNotesPopup").style.display = "none";
            document.getElementById("DivTaskMain").style.display = "none";
            document.getElementById("DivTaskMainSecond").style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').focus();
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').value = "";
            document.getElementById('ContentPlaceHolder1_Client_txtNoteDesc').value = "";
            document.getElementById('divnotescontentvalidate').style.display = "none";
            document.getElementById('addfileDiv').style.display = "none";
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("DivShowNote").style.display = "none";
            document.getElementById("AddNote").style.display = "block";
            document.getElementById("divNoteTitle").style.display = "block";
            document.getElementById("DivFileUpload1").style.display = "none";
            document.getElementById("DivBtnNotesSave").style.display = "none";
            document.getElementById("DivBtnUpdateNotes").style.display = "none";
            document.getElementById("DivCloseNoteTitle").style.display = "block";
            document.getElementById("DivBtnUpdateAllNotes").style.display = "block";
            document.getElementById('rgarrow').style.display = "none";
            document.getElementById('lftarrow').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lblAddNoteTitle').innerHTML = "Edit Note";
            document.getElementById("DivBtnNotesSave").style.display = "none";
            document.getElementById("DivAddNotePopup").style.position = "fixed";
            document.getElementById("DivAddNotePopup").style.left = "40%";
            document.getElementById("DivAddNotePopup").style.display = "block";
            document.getElementById("lftarrow").style.display = "none";
            var AttechMenID = document.getElementById("ContentPlaceHolder1_Client_ddnAttachID");
            AttechMenID.value = attachID;
            CallEdit_NotesMethod(attachID); return false;
        }
    </script>
    <script type="text/javascript" language="javascript">

        function CallSearchMethod() {
            Call_NotesSearchMethod(CompanyID, ClientID, '', '', '', '', '');
            Call_OASearchMethod(CompanyID, ClientID, '', '', '', '', '');
            Call_CASearchMethod(CompanyID, ClientID, '', '', '', '', '');
            DisplayNoneAllContant();
        }

        function GetScreenCordinatesNotePopups(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 20;
                p.y = p.y + obj.offsetParent.offsetTop - 2.7;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function OpenAddNotePopup(btnid) {
            document.getElementById("DivBtnNotesSave").style.marginTop = "0px";
            document.getElementById("DivEditCallPopup").style.position = "inherit";
            document.getElementById("DivAddNotePopup").style.display = "block";
            document.getElementById("DivAddNotePopup").style.position = "absolute";

            var txt = document.getElementById(btnid);
            var p = GetScreenCordinatesNotePopups(txt);
            document.getElementById('ContentPlaceHolder1_Client_ddlNoteCreateFollowUp').selectedIndex = 0;
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";
            document.getElementById("DivCallSubjects").style.display = "none";

            document.getElementById("DivNotesPopup").style.display = "none";
            document.getElementById("DivTaskMain").style.display = "none";
            document.getElementById("DivAddNotePopup").style.left = p.x;
            document.getElementById("DivAddNotePopup").style.top = p.y;

            document.getElementById("DivTaskMainSecond").style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').focus();
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').value = "";
            document.getElementById('ContentPlaceHolder1_Client_txtNoteDesc').value = "";
            document.getElementById('divnotescontentvalidate').style.display = "none";
            document.getElementById('addfileDiv').style.display = "none";
            document.getElementById('DivOldFile').style.display = "none";
            document.getElementById('DivUploFile').style.display = "block";
            document.getElementById('rgarrow').style.display = "block";
            document.getElementById('lftarrow').style.display = "none";
            document.getElementById('DivBtnNotesSave').style.display = "block";
            document.getElementById('DivBtnUpdateNotes').style.display = "none";
            document.getElementById('DivBtnUpdateAllNotes').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lblAddNoteTitle').innerHTML = "Add Note";
            $('body,html').animate({ scrollTop: (p.y - 20) }, 800);
        }

        function CloseAddNotePopup() {
            document.getElementById("DivAddNotePopup").style.display = "none";
        }
    </script>
    <script type="text/javascript" language="javascript">

        function CloseOADetails() {
            document.getElementById("DivOpenActiDetails").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "none";
        }

        function ShowRecActiType() {
            var RecentType = document.getElementById("ContentPlaceHolder1_Client_ddlrecActivityType");
            RecentType.options[RecentType.selectedIndex].value;
            var finalRecentType = RecentType.options[RecentType.selectedIndex].value;

            if (finalRecentType == "1") {
                document.getElementById("DivTopOrder").style.display = "block";
                document.getElementById("DivEstimate").style.display = "none";
                document.getElementById("JobTable").style.display = "none";
                document.getElementById("DivInvoiceDetails").style.display = "none";
            }
            if (finalRecentType == "2") {
                document.getElementById("DivTopOrder").style.display = "none";
                document.getElementById("DivEstimate").style.display = "block";
                document.getElementById("JobTable").style.display = "none";
                document.getElementById("DivInvoiceDetails").style.display = "none";

            }
            if (finalRecentType == "3") {
                document.getElementById("DivTopOrder").style.display = "none";
                document.getElementById("DivEstimate").style.display = "none";
                document.getElementById("JobTable").style.display = "block";
                document.getElementById("DivInvoiceDetails").style.display = "none";
            }
            if (finalRecentType == "4") {
                document.getElementById("DivTopOrder").style.display = "none";
                document.getElementById("DivEstimate").style.display = "none";
                document.getElementById("JobTable").style.display = "none";
                document.getElementById("DivInvoiceDetails").style.display = "block";
            }
        }

    </script>
    <script type="text/javascript" language="javascript">

        function PrintCustomerInfoandAddress() {
            ePrint.AutoFill.ReturnCustomerInfoWithMainContact(CompanyID, SectionID, CompanyType, onResponseMainCon);
        }
        function PrintCustomerInfowithDepartment() {
            ePrint.AutoFill.ReturnCustomerInfoWithDeptInfo(CompanyID, SectionID, CompanyType, onResponseadd);
        }
        function PrintCustomerNamwithLocationMap() {
            var PageURL = sitePath + "MapWithDirections.aspx?clientid=" + SectionID + "&clna=" + CompanyCusName + "";
            var left = ((document.body.clientWidth) / 0) + "px";
            var top = ((document.body.clientHeight) / 0) + "px";
            window.open(PageURL, null, 'height=530, width=1100,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no, left=' + left + ' , top = ' + top + ' ');
        }
        function CustomerInfowithallNotes() {
            ePrint.AutoFill.ReturnCustomerInfoWithAllNotes(CompanyID, SectionID, CompanyType, onResponsenotes);
        }

        function PrintCusnamewithlocationMap() {

            var PageURL = sitePath + "MapWithDirections.aspx?clientid=" + SectionID + "&clna=" + CompanyCusName + "";
            var left = ((document.body.clientWidth) / 0) + "px";
            var top = ((document.body.clientHeight) / 0) + "px";
            window.open(PageURL, null, 'height=530, width=1100,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no, left=' + left + ' , top = ' + top + ' ');
        }

        function PrintCusDetailsWithDeptInfo(my_DIV) {
            ePrint.AutoFill.ReturnCustomerInfoWithMainContact(CompanyID, SectionID, CompanyType, onResponseMainCon);
        }

        function onResponseMainCon(result) {

            var hdnPrintCusDetailsWithDeptInfo = document.getElementById("<%=hdnPrintCusDetailsWithDeptInfo.ClientID%>");
            hdnPrintCusDetailsWithDeptInfo.value = result;

            var ddnprintNote = document.getElementById("<%=hdnPrintCusDetailsWithDeptInfo.ClientID%>");

            var sStart = "<html><head>";

            var w = window.open('about:blank', 'printWin', 'width=1050,height=440,scrollbars=yes');
            var wdoc = w.document;
            wdoc.open();
            wdoc.writeln("<html><head><link href=\"../App_Themes/Theme1/item.css\" type=\"text/css\" rel=\"stylesheet\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            wdoc.writeln("</head><body style=\"background-image:none;background-color:white;\">");

            wdoc.writeln("<div style=\"direction: " + d + "; margin: 10px\">");
            wdoc.writeln("<p>");
            wdoc.writeln(ddnprintNote.value);
            wdoc.writeln("</p>");
            wdoc.writeln("</div>");
            wdoc.writeln("</body></html>");
            wdoc.close();
            w.print();
        }

        function PrintCusDetailsWithAllNotes(my_DIV) {

            ePrint.AutoFill.ReturnCustomerInfoWithAllNotes(CompanyID, SectionID, CompanyType, onResponsenotes);
        }

        function onResponsenotes(result) {

            var hdnPrintCusDetailsWithAllNotes = document.getElementById("<%=hdnPrintCusDetailsWithAllNotes.ClientID%>");
            hdnPrintCusDetailsWithAllNotes.value = result;
            var ddnprintNote = document.getElementById("<%=hdnPrintCusDetailsWithAllNotes.ClientID%>");
            var sStart = "<html><head>";

            var w = window.open('about:blank', 'printWin', 'width=1050,height=440,scrollbars=yes');
            var wdoc = w.document;
            wdoc.open();
            wdoc.writeln("<html><head><link href=\"../App_Themes/Theme1/item.css\" type=\"text/css\" rel=\"stylesheet\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            wdoc.writeln("</head><body style=\"background-image:none;background-color:white;\">");

            wdoc.writeln("<div style=\"direction: " + d + "; margin: 10px\">");
            wdoc.writeln("<p>");
            wdoc.writeln(ddnprintNote.value);
            wdoc.writeln("</p>");
            wdoc.writeln("</div>");
            wdoc.writeln("</body></html>");
            wdoc.close();
            w.print();
        }

        function PrintCusDetailsWithAddress(my_DIV) {
            ePrint.AutoFill.ReturnCustomerInfoWithDeptInfo(CompanyID, SectionID, CompanyType, onResponseadd);
        }
        function onResponseadd(result) {

            var hdnPrintCusDetailsWithAddress = document.getElementById("<%=hdnPrintCusDetailsWithAddress.ClientID%>");
            hdnPrintCusDetailsWithAddress.value = result;

            var ddnprintNote = document.getElementById("<%=hdnPrintCusDetailsWithAddress.ClientID%>");
            var sStart = "<html><head>";
            var w = window.open('about:blank', 'printWin', 'width=1050,height=440,scrollbars=yes');
            var wdoc = w.document;
            wdoc.open();
            wdoc.writeln("<html><head><link href=\"../App_Themes/Theme1/item.css\" type=\"text/css\" rel=\"stylesheet\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            wdoc.writeln("</head><body style=\"background-image:none;background-color:white;\">");

            wdoc.writeln("<div style=\"direction: " + d + "; margin: 10px\">");
            wdoc.writeln("<p>");
            wdoc.writeln(ddnprintNote.value);
            wdoc.writeln("</p>");
            wdoc.writeln("</div>");
            wdoc.writeln("</body></html>");
            wdoc.close();
            w.print();
        }

    </script>
    <script type="text/javascript">

        function NextPreviousAlert() {
            alert("No more data to load");
        }

    </script>
    <script type="text/javascript">

        function SetContentWidth() {
            document.getElementById('ContentPlaceHolder1_Client_DivLeftPanel').style.width = '90%';
            document.getElementById("ContentPlaceHolder1_Client_DivLeftPanel").style.minWidth = "90%";
            document.getElementById("DivclosedActivityTable").style.display = "none";
        }


        function HideQuickActions() {

            document.getElementById("ContentPlaceHolder1_Client_DivRightPanel").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_lnkRightArrow").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_lnkLeftArrow").style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_DivLeftPanel').style.width = '100%';
        }

        function ShowQuickActions() {

            document.getElementById("ContentPlaceHolder1_Client_DivRightPanel").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_lnkRightArrow").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_lnkLeftArrow").style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_DivLeftPanel').style.width = '90%';
            document.getElementById("ContentPlaceHolder1_Client_DivLeftPanel").style.minWidth = "90%";
        }

    </script>
    <script type="text/javascript" language="javascript">
        var isTimeSelected = false;
        function DateSelected(sender, args) {

        }
        function ClientTimeSelected(sender, args) {
            isTimeSelected = true;
        }

        function showclosedtaskandcall() {
            document.getElementById("DivclosedActivityTable").style.display = "block";
            document.getElementById("hideclosedactivity").style.display = "block";
            document.getElementById("Showclosedactivity").style.display = "none";
        }

        function Hideclosedtaskandcall() {
            document.getElementById("DivclosedActivityTable").style.display = "none";
            document.getElementById("hideclosedactivity").style.display = "none";
            document.getElementById("Showclosedactivity").style.display = "block";
        }

    </script>
    <script type="text/javascript">
        function printNotes(my_DIV) {
            var ddnprintNote = document.getElementById("<%=hdnprintNotesValue.ClientID%>");

            var sStart = "<html><head>";

            var w = window.open('about:blank', 'printWin', 'width=1000,height=540,scrollbars=yes');
            var wdoc = w.document;
            wdoc.open();
            wdoc.writeln("<html><head><link href=\"../App_Themes/Theme1/item.css\" type=\"text/css\" rel=\"stylesheet\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            wdoc.writeln("</head><body style=\"background-image:none;background-color:white;\">");

            wdoc.writeln("<div style=\"direction: " + d + "; margin: 10px\">");
            wdoc.writeln("<p>");
            wdoc.writeln(ddnprintNote.value);
            wdoc.writeln("</p>");
            wdoc.writeln("</div>");
            wdoc.writeln("</body></html>");
            wdoc.close();
            w.print();
        }

        var SearchNotespageNummberIndex = 1;
        var SearchOApageNummberIndex = 1;
        var SearchCLpageNummberIndex = 1;
        function LoadMoreSearchNotesByJson() {
            LoadMoreSearchedNotes(CompanyID, SectionID, '', '', '', '', ''); return false;
        }

        function HideMoreSearchNotesByJson() {

            HideMoreSearchNotesByJs(CompanyID, SectionID, '', '', '', '', ''); return false;
        }

        function LoadAllSearchedNotesByJson() {

            document.getElementById("Divshowallnotes").style.position = "fixed";
            document.getElementById("Divshowallnotes").style.left = "12%";
            document.getElementById("Divshowallnotes").style.top = "10%";
            document.getElementById("Divshowallnotes").style.display = "block";

            document.getElementById("divallnotesbckfade").style.display = "block";
            LoadAll_SearchedNotes(CompanyID, SectionID, '', '', '', ''); return false;
        }

        function LoadMoreSearchedOpenActivityByJson() {
            LoadMoreSearched_OpenActivityByJson(SectionID, CompanyID, '', '', '', '', ''); return false;
        }

        function HideMoreSearchedOAByJson() {
            HideMoreSearched_OAByJson(SectionID, CompanyID, '', '', '', '', ''); return false;
        }

        function LoadAllSearchedOAByJsn() {

            document.getElementById("DicShowAllOpenActivities").style.position = "fixed";
            document.getElementById("DicShowAllOpenActivities").style.left = "12%";
            document.getElementById("DicShowAllOpenActivities").style.top = "10%";
            document.getElementById("DicShowAllOpenActivities").style.display = "block";
            document.getElementById("divallnotesbckfade").style.display = "block";
            LoadAllSearched_OAByJsn(SectionID, CompanyID, '', '', '', ''); return false;
        }

        function LoadMoreSearchedCloseActivityByJson() {
            LoadMoreSearched_CloseActivityByJson(SectionID, CompanyID, '', '', '', '', ''); return false;
        }

        function LoadHideSearchedCloseActivityByJson() {
            LoadHideSearched_CloseActivityByJson(SectionID, CompanyID, '', '', '', '', ''); return false;
        }

        function LoadMoreClSearchedbyJson() {

            document.getElementById("DicShowAllCl").style.position = "fixed";
            document.getElementById("DicShowAllCl").style.left = "12%";
            document.getElementById("DicShowAllCl").style.top = "10%";
            document.getElementById("DicShowAllCl").style.display = "block";
            document.getElementById("divallnotesbckfade").style.display = "block";

            LoadMoreClSearched_byJson(SectionID, CompanyID, '', '', '', ''); return false;
        }

        function Clearsearchfilter() {
            document.getElementById("ContentPlaceHolder1_Client_txtallsearchcontant").value = "";
            document.getElementById("ContentPlaceHolder1_Client_ddlSearchWithin").selectedIndex = 0;
            document.getElementById("ContentPlaceHolder1_Client_txtsearchstartdate").value = "";
            document.getElementById("ContentPlaceHolder1_Client_txtsearchenddate").value = "";
            document.getElementById("ContentPlaceHolder1_Client_txtallsearchcontant").focus();

            LoadClearNotesFilter(CompanyID, SectionID);
            LoadClearpenActivityFilter(SectionID, CompanyID);
            LoadClearCloseActivityFilter(SectionID, CompanyID);

        }

        var NotespageNummberIndex = 1;
        var NotespageNummberIndexOA = 1;
        var NotespageNummberIndexCL = 1;
        var NotespageNummberIndexCon = 1;
        function LoadMoreNotesByJson() {
            LoadMoreNotes(CompanyID, SectionID); return false;
        }

        function LoadMoreOpenActivityByJson() {
            LoadMoreOpenActivity(SectionID, CompanyID); return false;
        }

        function LoadMoreCloseActivityByJson() {
            LoadMoreCloseActivity(SectionID, CompanyID); return false;
        }

        function LoadMoreContactByJson() {
            LoadMoreContacts(SectionID, ''); return false;
        }

        function HideMoreNotesByJson() {
            HideMoreNotesByJs(CompanyID, SectionID); return false;
        }

        function HideMoreOAByJson() {
            HideMoreOAByJs(SectionID, CompanyID); return false;
        }

        function LoadHideCloseActivityByJson() {
            LoadHideCloseActivity(SectionID, CompanyID); return false;
        }

        function LoadHideContactByJson() {
            LoadHideContacts(SectionID, ''); return false;
        }

        function GetScreenCordinatesAllNotes(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 20;
                p.y = p.y + obj.offsetParent.offsetTop - 8;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function LoadAllNotesByJson(btnid, Count) {

            var txt = document.getElementById(btnid);
            var p = GetScreenCordinatesAllNotes(txt);

            document.getElementById("Divshowallnotes").style.position = "fixed";
            document.getElementById("Divshowallnotes").style.left = "12%";
            document.getElementById("Divshowallnotes").style.top = "10%";
            document.getElementById("Divshowallnotes").style.display = "block";
            document.getElementById("divallnotesbckfade").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_lblnotecount").innerHTML = "(" + Count + ")";
            LoadAllNotes(CompanyID, ClientID); return false;
        }

        function LoadAllCAByJson(totalcount) {

            var lblClCounts = document.getElementById("ContentPlaceHolder1_Client_lblClCounts");
            lblClCounts.innerHTML = "(" + totalcount + ")";

            document.getElementById("DicShowAllCl").style.position = "fixed";
            document.getElementById("DicShowAllCl").style.left = "12%";
            document.getElementById("DicShowAllCl").style.top = "10%";
            document.getElementById("DicShowAllCl").style.display = "block";

            document.getElementById("divallnotesbckfade").style.display = "block";
            LoadAllClosedActivity(SectionID, CompanyID); return false;
        }

        function CloseAllClPopup() {
            document.getElementById("DicShowAllCl").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "none";
        }

        function CloseAllnotesPopup() {
            document.getElementById("Divshowallnotes").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "none";
        }

        function LoadAllOpenActiviesbyJsonss(totalcount) {

            var labelcount = document.getElementById("ContentPlaceHolder1_Client_lblopenActivityCount");
            labelcount.innerHTML = "(" + totalcount + ")";

            document.getElementById("DicShowAllOpenActivities").style.position = "fixed";
            document.getElementById("DicShowAllOpenActivities").style.left = "12%";
            document.getElementById("DicShowAllOpenActivities").style.top = "10%";
            document.getElementById("DicShowAllOpenActivities").style.display = "block";

            document.getElementById("divallnotesbckfade").style.display = "block";
            LoadAllOpenActivity(SectionID, CompanyID); return false;
        }

        function CloseAllOAPopup() {
            document.getElementById("DicShowAllOpenActivities").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "none";
        }

        function UpdateCallValidationsNew() {

            var hdnCallID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID").value;
            var txtCallSubject = document.getElementById("ContentPlaceHolder1_Client_txtEditCallSubject");
            var txtcallstartdate = document.getElementById("ContentPlaceHolder1_Client_txtEditCallStartdate");
            var txtcallMinute = document.getElementById("ContentPlaceHolder1_Client_txtEditCallMin");
            var txtcallSecond = document.getElementById("ContentPlaceHolder1_Client_txtEditCallSec");
            var TxtHM = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker5_dateInput_text");
            var ddlEditCallDetails = document.getElementById("ContentPlaceHolder1_Client_ddlEditCallDetails");
            ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].text;
            var ddlEditCallDetailsNew = ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].value;

            if (ddlEditCallDetailsNew == "2") {

            }
            else if (ddlEditCallDetailsNew == "3") {
                if (txtcallstartdate.value == '') {
                    document.getElementById("span_txtcallstartdate").style.display = "block";
                }
            }

            if (txtCallSubject.value == '') {
                document.getElementById("span_EditCallSubject").style.display = "block";
            }
            if (TxtHM.value == '') {
                document.getElementById("span_EditCallStartdate").style.display = "block";
                return true;
            }
            if (txtcallstartdate.value == '') {
                document.getElementById("span_EditCallStartdate").style.display = "block";
            }
            else {

                if (ValidateForm(txtcallstartdate, 'span_EditCallStartdate1', DateFormat) == false) {

                }
            }
            if (txtCallSubject.value != '' && txtcallstartdate.value != '') {
                Update_Call(hdnCallID, CompanyID, SectionID, '', '', '', '', '', '', '', '', '', '', '', '', '', UserIDN, '', ''); return false;
            }
            else {
                SlideRightEditCallDiv();
            }
        }

        function UpdateCallValidations() {

            var AttID = document.getElementById("ContentPlaceHolder1_Client_AttID");
            var hdnCallID1 = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID").value;

            if (hdnCallID1 == "") {
                hdnCallID = AttID.value;
            }
            else {
                var hdnCallID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID").value;
            }
            var ddlCallSubjectEdit = document.getElementById("ContentPlaceHolder1_Client_ddlCallSubjectEdit");
            var txtcallstartdate = document.getElementById("ContentPlaceHolder1_Client_txtEditCallStartdate");
            var txtcallMinute = document.getElementById("ContentPlaceHolder1_Client_txtEditCallMin");
            var txtcallSecond = document.getElementById("ContentPlaceHolder1_Client_txtEditCallSec");
            var TxtHM = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker5_dateInput_text");
            var ddlEditCallDetails = document.getElementById("ContentPlaceHolder1_Client_ddlEditCallDetails");
            ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].text;
            var ddlEditCallDetailsNew = ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].value;
            var ddlEditowners = document.getElementById("ContentPlaceHolder1_Client_ddlEditowner");

            if (ddlEditCallDetailsNew == "2") {

            }
            else if (ddlEditCallDetailsNew == "3") {
                if (txtcallstartdate.value == '') {
                    document.getElementById("span_txtcallstartdate").style.display = "block";
                    return true;
                }
            }

            if (ddlCallSubjectEdit.selectedIndex == -1) {
                document.getElementById("span_EditCallSubject").style.display = "block";
                return true;
            }
            if (TxtHM.value == '') {
                document.getElementById("span_EditCallStartdate").style.display = "block";
                return true;
            }
            if (txtcallstartdate.value == '') {
                document.getElementById("span_EditCallStartdate").style.display = "block";
                return true;
            }
            else {

                if (ValidateForm(txtcallstartdate, 'span_EditCallStartdate1', DateFormat) == false) {
                    return true;
                }
            }
            if (ddlEditowners.options.length == 0) {
                document.getElementById("dicEditAssigntoCall").style.display = "block";
                return true;
            }
            Update_Call(hdnCallID, CompanyID, SectionID, '', '', '', '', '', '', '', '', '', '', '', '', '', UserIDN, '', ''); return false;
        }

        function ShowEditCallDetailType() {
            var ddlEditCallDetails = document.getElementById("ContentPlaceHolder1_Client_ddlEditCallDetails");

            ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].text;
            var finalCallDetailType = ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].value;

            if (finalCallDetailType == "1") {
                document.getElementById("EditDurationStar").style.display = "none";
            }
            if (finalCallDetailType == "2") {
                document.getElementById("EditDurationStar").style.display = "block";
            }
            if (finalCallDetailType == "3") {
                document.getElementById("EditDurationStar").style.display = "none";
            }
        }


        function ShowCallDetailType() {
            var ddlCallDetailsType = document.getElementById("ContentPlaceHolder1_Client_ddlCallDetailsType");

            ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].text;
            var finalCallType = ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].value;

            if (finalCallType == "1") {
                document.getElementById("DurationStar").style.display = "none";
                document.getElementById("DivCallTimer").style.display = "none";
                document.getElementById("DivCallStartTime").style.display = "block";
                document.getElementById("DivCallStartTime1").style.display = "block";
                document.getElementById("DivCallDuration").style.display = "block";
                document.getElementById("DivCallDuration1").style.display = "block";
                document.getElementById("Span_MinuteSecond").style.display = "none";
            }
            if (finalCallType == "2") {
                document.getElementById("DurationStar").style.display = "none";
                document.getElementById("DivCallTimer").style.display = "none";
                document.getElementById("DivCallStartTime").style.display = "block";
                document.getElementById("DivCallStartTime1").style.display = "block";
                document.getElementById("DivCallDuration").style.display = "block";
                document.getElementById("DivCallDuration1").style.display = "block";
                document.getElementById("Span_MinuteSecond").style.display = "none";
            }
        }
        function ShowOrder() {
            document.getElementById("DivTopOrder").style.display = "block";
            document.getElementById("DivEstimate").style.display = "none";
            document.getElementById("JobTable").style.display = "none";
            document.getElementById("DivInvoiceDetails").style.display = "none";
        }
        function ShowJob() {
            document.getElementById("DivTopOrder").style.display = "none";
            document.getElementById("DivEstimate").style.display = "none";
            document.getElementById("JobTable").style.display = "block";
            document.getElementById("DivInvoiceDetails").style.display = "none";
        }
        function ShowEstimate() {
            document.getElementById("DivTopOrder").style.display = "none";
            document.getElementById("DivEstimate").style.display = "block";
            document.getElementById("JobTable").style.display = "none";
            document.getElementById("DivInvoiceDetails").style.display = "none";
        }
        function ShowInvoice() {
            document.getElementById("DivTopOrder").style.display = "none";
            document.getElementById("DivEstimate").style.display = "none";
            document.getElementById("JobTable").style.display = "none";
            document.getElementById("DivInvoiceDetails").style.display = "block";
        }

    </script>
    <script type="text/javascript">

        function GetScreenCordinatesNew1(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 27;
                p.y = p.y + obj.offsetParent.offsetTop - 2.5;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function GetScreenCordinates(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft + 1.5;
                p.y = p.y + obj.offsetParent.offsetTop - 2.7;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function Edit_OpenActivities(id, SectionName, btnid) {

            var txt = document.getElementById(btnid);
            var p = GetScreenCordinatesNew1(txt);
            //alert("X:" + p.x + " Y:" + p.y);
            var hdnTaskID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID");
            hdnTaskID.value = id;
            document.getElementById("ContentPlaceHolder1_Client_ddlEditCreateFollowUpTask").selectedIndex = 0;
            document.getElementById('DivAddNotePopup').style.display = "none";

            if (SectionName != "") {
                if (SectionName == "Task") {
                    //document.getElementById("ContentPlaceHolder1_Client_Label119").innerHTML = '<%=objLanguage.GetLanguageConversion("Add_Task") %>';
                    document.getElementById("ContentPlaceHolder1_Client_Label119").innerHTML = "Edit Task";
                    document.getElementById("DivEditCallPopup").style.display = "none";
                    document.getElementById("span_EditMinuteSecond").style.display = "none";
                    document.getElementById("span_EditMinuteSecond").style.display = "none";
                    document.getElementById("Span_ddlEditsubject").style.display = "none";
                    document.getElementById("Span_ddlEditassignto").style.display = "none";
                    document.getElementById("span_ddlEditStataus").style.display = "none";
                    document.getElementById("span_ddlEditPriority").style.display = "none";
                    document.getElementById("span_txtEditDueDate").style.display = "none";
                    document.getElementById("span_txtEditDueDate1").style.display = "none";
                    document.getElementById("DivtaskEditSecond").style.display = "none";
                    document.getElementById("DivEventsSubject").style.display = "none";
                    document.getElementById("DivEventPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.display = "block";
                    document.getElementById("DivtaskPopUpEdit").style.position = "absolute";
                    document.getElementById("ContentPlaceHolder1_Client_LinkButton12").style.display = "block";
                    document.getElementById("DivtaskEdit").style.display = "block";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.left = p.x;
                    document.getElementById("DivtaskPopUpEdit").style.top = p.y;
                    $('body,html').animate({ scrollTop: (p.y) }, 800);
                    CallEdit_TaskMethod(id); return false;
                }
                else if (SectionName == "Event") {

                    document.getElementById("DivEditEventMinSec").style.display = "none";
                    document.getElementById("DivEditCallPopup").style.display = "none";
                    document.getElementById("span_ddlEditEventSubject").style.display = "none";
                    document.getElementById("Span_ddlEditEventAssignTo").style.display = "none";
                    document.getElementById("span_txtEditEventDueDate").style.display = "none";
                    document.getElementById("span_txtEditEventDueDate1").style.display = "none";
                    document.getElementById("Span_txtEditEventLocations").style.display = "none";
                    document.getElementById("DivEventEditSecond").style.display = "none";
                    document.getElementById("DivEditTaskSubject").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("DivEventPopUpEdit").style.display = "block";
                    document.getElementById("DivEventEdit").style.display = "block";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    document.getElementById("DivEventPopUpEdit").style.left = p.x;
                    document.getElementById("DivEventPopUpEdit").style.top = p.y;
                    $('body,html').animate({ scrollTop: (p.y) }, 800);
                    CallEdit_EventMethod(id); return false;
                }
                else if (SectionName == "Call") {

                    document.getElementById("ContentPlaceHolder1_Client_Label120").innerHTML = "Edit Call";
                    document.getElementById("DivEditCallTimerSecond").style.display = "none";
                    document.getElementById("DivEventEditSecond").style.display = "none";
                    document.getElementById("DivEditTaskSubject").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("span_EditCallSubject").style.display = "none";
                    document.getElementById("span_EditCallStartdate").style.display = "none";
                    document.getElementById("DivEditCallPopup").style.display = "block";
                    document.getElementById("DivEditCallTimer").style.display = "block";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    document.getElementById("DivEditCallPopup").style.left = p.x;
                    document.getElementById("DivEditCallPopup").style.top = p.y;
                    $('body,html').animate({ scrollTop: (p.y) }, 800);
                    Edit_CallMethod(id); return false;
                }
            }
        }


        function Edit_AllOpenActivities(id, SectionName) {

            var hdnTaskID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID");
            hdnTaskID.value = id;
            document.getElementById("ContentPlaceHolder1_Client_ddlEditCreateFollowUpTask").selectedIndex = 0;
            document.getElementById('DivAddNotePopup').style.display = "none";

            if (SectionName != "") {
                if (SectionName == "Task") {

                    document.getElementById("ContentPlaceHolder1_Client_LinkButton12").style.display = "none";
                    document.getElementById("DivEditCallPopup").style.display = "none";
                    document.getElementById("span_EditMinuteSecond").style.display = "none";
                    document.getElementById("span_EditMinuteSecond").style.display = "none";
                    document.getElementById("Span_ddlEditsubject").style.display = "none";
                    document.getElementById("Span_ddlEditassignto").style.display = "none";
                    document.getElementById("span_ddlEditStataus").style.display = "none";
                    document.getElementById("span_ddlEditPriority").style.display = "none";
                    document.getElementById("span_txtEditDueDate").style.display = "none";
                    document.getElementById("span_txtEditDueDate1").style.display = "none";
                    document.getElementById("DivtaskEditSecond").style.display = "none";
                    document.getElementById("DivEventsSubject").style.display = "none";
                    document.getElementById("DivEventPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.position = "fixed";
                    document.getElementById("DivtaskPopUpEdit").style.left = "32%";
                    document.getElementById("DivtaskPopUpEdit").style.top = "5%";
                    document.getElementById("DivtaskPopUpEdit").style.zIndex = "5555555555555";
                    document.getElementById("DivtaskPopUpEdit").style.display = "block";
                    document.getElementById("DivtaskEdit").style.display = "block";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    CallEdit_TaskMethod(id); return false;
                }
                else if (SectionName == "Call") {

                    document.getElementById("DivEditCallTimerSecond").style.display = "none";
                    document.getElementById("DivEventEditSecond").style.display = "none";
                    document.getElementById("DivEditTaskSubject").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("span_EditCallSubject").style.display = "none";
                    document.getElementById("span_EditCallStartdate").style.display = "none";
                    document.getElementById("DivEditCallPopup").style.position = "fixed";
                    document.getElementById("DivEditCallPopup").style.left = "32%";
                    document.getElementById("DivEditCallPopup").style.top = "5%";
                    document.getElementById("DivEditCallPopup").style.zIndex = "5555555555555";
                    document.getElementById("ContentPlaceHolder1_Client_LinkButton18").style.display = "none";
                    document.getElementById("DivEditCallPopup").style.display = "block";
                    document.getElementById("DivEditCallTimer").style.display = "block";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    Edit_CallMethod(id); return false;
                }
            }
        }

        function GetScreenCordinatesForDetails(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft + 9;
                p.y = p.y + obj.offsetParent.offsetTop - 18;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function Closed_Activity_details(id, SectionName, btnID) {

            var AttID = document.getElementById("ContentPlaceHolder1_Client_AttID");
            AttID.value = id;
            var txt = document.getElementById(btnID);
            var p = GetScreenCordinatesForDetails(txt);

            var hdnCommanID = document.getElementById("ContentPlaceHolder1_Client_hdnCommanID");
            var hdnSectionName = document.getElementById("ContentPlaceHolder1_Client_hdnSectionName");
            var hdnbuttonid = document.getElementById("ContentPlaceHolder1_Client_hdnbuttonid");
            document.getElementById("divallnotesbckfade").style.display = "block";

            hdnCommanID.value = id;
            hdnSectionName.value = SectionName;
            hdnbuttonid.value = btnID;

            var btnIDs = btnID.split('_');
            if (btnIDs[0] == "btnclosedetails") {

                document.getElementById("divbtncomplete").style.display = "none";
            }
            else {
                document.getElementById("divbtncomplete").style.display = "block";
            }

            var hdnTaskFollowParentIDDet = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentIDDet");
            var hdnTaskFollowParentTypeDet = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentTypeDet");
            hdnTaskFollowParentIDDet.value = id;
            hdnTaskFollowParentTypeDet.value = SectionName;

            var hdnCallFollowParentIDDet = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentIDDet");
            var hdnCallFollowParentTypeDet = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentTypeDet");
            hdnCallFollowParentIDDet.value = id;
            hdnCallFollowParentTypeDet.value = SectionName;

            if (SectionName != "") {
                if (SectionName == "Task") {

                    document.getElementById("DivOpenActiDetails").style.display = "block";
                    document.getElementById("DivOpenActiDetails").style.position = "fixed";
                    document.getElementById("DivOpenActiDetails").style.left = "30%";
                    document.getElementById("DivOpenActiDetails").style.top = "14%";
                    document.getElementById("DivOpenActiDetails").style.zIndex = "555555555555";

                    document.getElementById("DivEditCallPopup").style.display = "none";
                    document.getElementById("DivtaskEditSecond").style.display = "none";
                    document.getElementById("DivEventsSubject").style.display = "none";
                    document.getElementById("DivEventPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.display = "none";
                    document.getElementById("DivtaskEdit").style.display = "none";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btndelFollowTask").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btndelFollowCall").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btnDelEdit").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btnDelDelete").style.marginLeft = "190px";

                    CallEdit_TaskMethod(id); return false;
                }
                else if (SectionName == "Call") {

                    document.getElementById("DivOpenActiDetails").style.position = "fixed";
                    document.getElementById("DivOpenActiDetails").style.left = "30%";
                    document.getElementById("DivOpenActiDetails").style.top = "14%";
                    document.getElementById("DivOpenActiDetails").style.zIndex = "555555555555";
                    document.getElementById("DivOpenActiDetails").style.display = "block";
                    document.getElementById("DivEditCallTimerSecond").style.display = "none";
                    document.getElementById("DivEventEditSecond").style.display = "none";
                    document.getElementById("DivEditTaskSubject").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("span_EditCallStartdate").style.display = "none";
                    document.getElementById("DivEditCallPopup").style.display = "none";
                    document.getElementById("DivEditCallTimer").style.display = "none";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btndelFollowTask").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btndelFollowCall").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btnDelEdit").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btnDelDelete").style.marginLeft = "190px";
                    Edit_CallMethod(id); return false;
                }
            }
        }

        function Open_Activity_details(id, SectionName, btnID) {
            var AttID = document.getElementById("ContentPlaceHolder1_Client_AttID");
            AttID.value = id;
            var txt = document.getElementById(btnID);
            var p = GetScreenCordinatesForDetails(txt);

            var hdnCommanID = document.getElementById("ContentPlaceHolder1_Client_hdnCommanID");
            var hdnSectionName = document.getElementById("ContentPlaceHolder1_Client_hdnSectionName");
            var hdnbuttonid = document.getElementById("ContentPlaceHolder1_Client_hdnbuttonid");
            document.getElementById("divallnotesbckfade").style.display = "block";

            hdnCommanID.value = id;
            hdnSectionName.value = SectionName;
            hdnbuttonid.value = btnID;

            var btnIDs = btnID.split('_');
            if (btnIDs[0] == "btnclosedetails") {

                document.getElementById("divbtncomplete").style.display = "none";
            }
            else {
                document.getElementById("divbtncomplete").style.display = "block";
            }

            var hdnTaskFollowParentIDDet = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentIDDet");
            var hdnTaskFollowParentTypeDet = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentTypeDet");
            hdnTaskFollowParentIDDet.value = id;
            hdnTaskFollowParentTypeDet.value = SectionName;

            var hdnCallFollowParentIDDet = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentIDDet");
            var hdnCallFollowParentTypeDet = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentTypeDet");
            hdnCallFollowParentIDDet.value = id;
            hdnCallFollowParentTypeDet.value = SectionName;

            if (SectionName != "") {
                if (SectionName == "Task") {

                    document.getElementById("DivOpenActiDetails").style.display = "block";
                    document.getElementById("DivOpenActiDetails").style.position = "fixed";
                    document.getElementById("DivOpenActiDetails").style.left = "30%";
                    document.getElementById("DivOpenActiDetails").style.top = "14%";
                    document.getElementById("DivOpenActiDetails").style.zIndex = "555555555555";
                    document.getElementById("DivEditCallPopup").style.display = "none";
                    document.getElementById("DivtaskEditSecond").style.display = "none";
                    document.getElementById("DivEventsSubject").style.display = "none";
                    document.getElementById("DivEventPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.display = "none";
                    document.getElementById("DivtaskEdit").style.display = "none";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btndelFollowTask").style.display = "block";
                    document.getElementById("ContentPlaceHolder1_Client_btndelFollowCall").style.display = "block";
                    document.getElementById("ContentPlaceHolder1_Client_btnDelEdit").style.display = "block";
                    document.getElementById("ContentPlaceHolder1_Client_btnDelDelete").style.marginLeft = "0px";
                    CallEdit_TaskMethod(id); return false;
                }
                else if (SectionName == "Call") {

                    document.getElementById("DivOpenActiDetails").style.position = "fixed";
                    document.getElementById("DivOpenActiDetails").style.left = "30%";
                    document.getElementById("DivOpenActiDetails").style.top = "14%";
                    document.getElementById("DivOpenActiDetails").style.zIndex = "555555555555";

                    document.getElementById("DivOpenActiDetails").style.display = "block";
                    document.getElementById("DivEditCallTimerSecond").style.display = "none";
                    document.getElementById("DivEventEditSecond").style.display = "none";
                    document.getElementById("DivEditTaskSubject").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("span_EditCallStartdate").style.display = "none";
                    document.getElementById("DivEditCallPopup").style.display = "none";
                    document.getElementById("DivEditCallTimer").style.display = "none";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    document.getElementById("ContentPlaceHolder1_Client_btndelFollowTask").style.display = "block";
                    document.getElementById("ContentPlaceHolder1_Client_btndelFollowCall").style.display = "block";
                    document.getElementById("ContentPlaceHolder1_Client_btnDelEdit").style.display = "block";
                    document.getElementById("ContentPlaceHolder1_Client_btnDelDelete").style.marginLeft = "0px";
                    Edit_CallMethod(id); return false;
                }
            }
        }

        function ValidateUpdateEventNew() {

            var hdnTaskID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID").value;

            var ddlEditEventSubject = document.getElementById("ContentPlaceHolder1_Client_ddlEditEventSubject");
            var ddlEditEventAssignTo = document.getElementById("ContentPlaceHolder1_Client_ddlEditEventAssignTo");
            var txtEditEventLocations = document.getElementById("ContentPlaceHolder1_Client_txtEditEventLocations");
            var txtEditEventDueDate = document.getElementById("ContentPlaceHolder1_Client_txtEditEventDueDate");
            var MinSec = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker3_dateInput_text");

            if (ddlEditEventSubject.selectedIndex == 0) {
                document.getElementById("span_ddlEditEventSubject").style.display = "block";
            }
            if (txtEditEventLocations.value == '') {
                document.getElementById("Span_txtEditEventLocations").style.display = "block";
            }
            if (txtEditEventDueDate.value == '') {
                document.getElementById("span_txtEditEventDueDate").style.display = "block";
            }
            else {

                if (ValidateForm(txtEditEventDueDate, 'span_txtEditEventDueDate1', DateFormat) == false) {

                }
            }

            if (ddlEditEventSubject.selectedIndex != 0 && txtEditEventLocations.value != '' && txtEditEventDueDate.value != '') {

                CallUpdate_EventMethod(hdnTaskID, CompanyID, '', '', '', '', '', 'client', ClientIDTask, '', '', '', '', UserIDN, CreateddateN, ''); return false;
            }
            else {
                SlideRightDivEventsEdit();
            }
        }

        function ValidateUpdateEvent() {

            var hdnTaskID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID").value;

            var ddlEditEventSubject = document.getElementById("ContentPlaceHolder1_Client_ddlEditEventSubject");
            var ddlEditEventAssignTo = document.getElementById("ContentPlaceHolder1_Client_ddlEditEventAssignTo");
            var txtEditEventLocations = document.getElementById("ContentPlaceHolder1_Client_txtEditEventLocations");
            var txtEditEventDueDate = document.getElementById("ContentPlaceHolder1_Client_txtEditEventDueDate");

            var MinSec = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker3_dateInput_text");

            if (ddlEditEventSubject.selectedIndex == 0) {
                document.getElementById("span_ddlEditEventSubject").style.display = "block";
            }
            if (txtEditEventLocations.value == '') {
                document.getElementById("Span_txtEditEventLocations").style.display = "block";
            }
            if (txtEditEventDueDate.value == '') {
                document.getElementById("span_txtEditEventDueDate").style.display = "block";
            }
            else {

                if (ValidateForm(txtEditEventDueDate, 'span_txtEditEventDueDate1', DateFormat) == false) {

                }
            }

            if (ddlEditEventSubject.selectedIndex != 0 && txtEditEventLocations.value != '' && txtEditEventDueDate.value != '') {

                CallUpdate_EventMethod(hdnTaskID, CompanyID, '', '', '', '', '', 'client', ClientIDTask, '', '', '', '', UserIDN, CreateddateN, ''); return false;
            }
        }

        function ValidateUpdateTaskNew() {

            var hdnTaskID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID").value;
            var ddlEditsubject = document.getElementById("ContentPlaceHolder1_Client_ddlEditsubject");
            var ddlEditassignto = document.getElementById("ContentPlaceHolder1_Client_ddlEditassignto");
            var ddlEditStataus = document.getElementById("ContentPlaceHolder1_Client_ddlEditStataus");
            var ddlEditPriority = document.getElementById("ContentPlaceHolder1_Client_ddlEditPriority");
            var txtEditDueDate = document.getElementById("ContentPlaceHolder1_Client_txtEditDueDate");
            var ddlEdithour = document.getElementById("ContentPlaceHolder1_Client_ddlEdithour");
            var ddlEditminute = document.getElementById("ContentPlaceHolder1_Client_ddlEditminute");
            var txtEditTaskDesc = document.getElementById("ContentPlaceHolder1_Client_txtEditTaskDesc");
            var TxtHM = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker1_dateInput_text");

            if (ddlEditsubject.selectedIndex == 0) {
                document.getElementById("Span_ddlEditsubject").style.display = "block";
            }

            if (ddlEditStataus.selectedIndex == 0) {
                document.getElementById("span_ddlEditStataus").style.display = "block";
            }

            if (ddlEditPriority.selectedIndex == 0) {
                document.getElementById("span_ddlEditPriority").style.display = "block";
            }

            if (txtEditDueDate.value == '') {
                document.getElementById("span_txtEditDueDate").style.display = "block";
            }
            else {

                if (ValidateForm(txtEditDueDate, 'span_txtEditDueDate1', DateFormat) == false) {
                }
            }

            if (ddlEditsubject.selectedIndex != 0 && ddlEditStataus.selectedIndex != 0 && ddlEditPriority.selectedIndex != 0 && txtEditDueDate.value != '') {

                CallUpdate_TaskMethod(hdnTaskID, CompanyID, '', '', '', '', '', '', '', 'client', ClientIDTask, '', '', UserIDN, CreateddateN, ''); return false;
            }
            else {
                SlideEditRightDivTask();
            }
        }

        function ValidateUpdateTask() {

            var hdnTaskID = "";
            hdnTaskID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID").value;
            if (hdnTaskID == "") {
                var hdnCommanID = document.getElementById("ContentPlaceHolder1_Client_hdnCommanID");
                hdnTaskID = hdnCommanID.value;
            }

            var ddlEditsubject = document.getElementById("ContentPlaceHolder1_Client_ddlEditsubject");
            var ddlEditassignto = document.getElementById("ContentPlaceHolder1_Client_ddlEditassignto");
            var ddlEditStataus = document.getElementById("ContentPlaceHolder1_Client_ddlEditStataus");
            var ddlEditPriority = document.getElementById("ContentPlaceHolder1_Client_ddlEditPriority");
            var txtEditDueDate = document.getElementById("ContentPlaceHolder1_Client_txtEditDueDate");
            var ddlEdithour = document.getElementById("ContentPlaceHolder1_Client_ddlEdithour");
            var ddlEditminute = document.getElementById("ContentPlaceHolder1_Client_ddlEditminute");
            var txtEditTaskDesc = document.getElementById("ContentPlaceHolder1_Client_txtEditTaskDesc");
            var TxtHM = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker1_dateInput_text");

            if (ddlEditsubject.selectedIndex == 0) {
                document.getElementById("Span_ddlEditsubject").style.display = "block";
            }

            if (ddlEditStataus.selectedIndex == 0) {
                document.getElementById("span_ddlEditStataus").style.display = "block";
            }

            if (ddlEditPriority.selectedIndex == 0) {
                document.getElementById("span_ddlEditPriority").style.display = "block";
            }

            if (txtEditDueDate.value == '') {
                document.getElementById("span_txtEditDueDate").style.display = "block";
            }
            else {

                if (ValidateForm(txtEditDueDate, 'span_txtEditDueDate1', DateFormat) == false) {
                    return true;
                }
            }

            if (ddlEditsubject.selectedIndex != 0 && ddlEditStataus.selectedIndex != 0 && ddlEditPriority.selectedIndex != 0 && txtEditDueDate.value != '') {

                CallUpdate_TaskMethod(hdnTaskID, CompanyID, '', '', '', '', '', '', '', 'client', ClientIDTask, '', '', UserIDN, CreateddateN, ''); return false;
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        var CompanyID = "<%=CompanyID %>";
        var SectionName = "<%=SectionName %>";
        var SectionID = "<%=SectionID %>";
        var UserIDN = "<%=UserIDN %>";
        var attachID = "<%=attachID %>";
        var CreateddateN = "<%=CreateddateN %>";
        var ClientIDTask = "<%=ClientIDTask %>";
        var DateFormat = "<%=DateFormat %>";
        var TodDate = "<%=TodDate %>";
        var CompanyType = "<%=CompanyType %>";
        var CompanyCusName = "<%=CompanyCusName %>";
    </script>
    <script type="text/javascript">
        function SelectContact(sub, hid) {
            document.getElementById("DivOpenContact").style.display = "none";

            document.getElementById("ContentPlaceHolder1_Client_imgClearcontacts").style.display = "none";
            eval("document.forms[0][\'ContentPlaceHolder1_Client_RadGridContact_ctl04_hdnContactID'].value='" + hid + "'");
        }
    </script>
    <script type="text/javascript">

        function OnClickCall() {

        }

        function ShowAddFiles() {
            document.getElementById('DivCloseBrowseFile').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_file_upload').value = "";

            $('#addfileDiv').show();
        }

        function DeleteOldFile() {
            var Test = document.getElementById("ContentPlaceHolder1_Client_lblOldFile").innerHTML = "";
            document.getElementById('DivOldFile').style.display = "none";
            document.getElementById('addfileDiv').style.display = "block";

            document.getElementById("DivUploFile").style.display = "block";
            document.getElementById("DivCloseBrowseFile").style.display = "block";
        }

        function ValidateEventsAddSubject() {

            var txtEventSubject = document.getElementById("ContentPlaceHolder1_Client_txtEventSubject");

            if (txtEventSubject.value == '') {
                document.getElementById("Div_EventSubject_Validations").style.display = "block";
            }

            if (txtEventSubject.value != '') {
                document.getElementById("Div_EventSubject_Validations").style.display = "none";
                CallInsert_taskSubjectMethod('', CompanyID, ''); return false;
            }
        }

        function ValidateEditEventsAddSubject() {

            var txtEventSubject = document.getElementById("ContentPlaceHolder1_Client_txtEditEventSubject");

            if (txtEventSubject.value == '') {
                document.getElementById("Span_EditEventSubject").style.display = "block";
            }

            if (txtEventSubject.value != '') {
                document.getElementById("Span_EditEventSubject").style.display = "none";

                CallInsert_EventSubjectMethod('', CompanyID, ''); return false;
            }
        }
        function InsertEventtoValidateNew() {
            var ddlEventsSubject = document.getElementById("ContentPlaceHolder1_Client_ddlEventsSubject");
            var ddlEventsAssignTo = document.getElementById("ContentPlaceHolder1_Client_ddlEventsAssignTo");
            var txtLocationEvent = document.getElementById("ContentPlaceHolder1_Client_txtLocationEvent");
            var TxtDueDateEvent = document.getElementById("ContentPlaceHolder1_Client_TxtDueDateEvent");
            var ddlEventHours = document.getElementById("ContentPlaceHolder1_Client_ddlEventHours");
            var ddlEventmin = document.getElementById("ContentPlaceHolder1_Client_ddlEventmin");
            var ddlEventHours1 = document.getElementById("ContentPlaceHolder1_Client_ddlEventHours1");
            var ddlEventmin1 = document.getElementById("ContentPlaceHolder1_Client_ddlEventmin1");
            var txtEventsDesc = document.getElementById("ContentPlaceHolder1_Client_txtEventsDesc");

            var TxtHM = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker2_dateInput_text");

            if (ddlEventsSubject.selectedIndex == 0) {
                document.getElementById("Span_ddlEventsSubject").style.display = "block";
            }
            if (txtLocationEvent.value == '') {
                document.getElementById("span_textPad").style.display = "block";
            }

            if (TxtDueDateEvent.value == '') {
                document.getElementById("Span_TxtDueDateEvent").style.display = "block";
            }
            else {

                if (ValidateForm(TxtDueDateEvent, 'Span_TxtDueDateEvent1', DateFormat) == false) {

                }
            }

            if (ddlEventsSubject.selectedIndex != 0 && txtLocationEvent.value != '' && TxtDueDateEvent.value != '') {
                DisplayNoneAllContant();
                CallInsert_EventMethod(CompanyID, '', '', '', '', '', 'client', ClientIDTask, '', '', 0, '', 0, '', UserIDN, CreateddateN, ''); return false;
            }
            else {
                EventRightDivSlideToLeft();
            }
        }
        function InsertEventtoValidate() {

            var ddlEventsSubject = document.getElementById("ContentPlaceHolder1_Client_ddlEventsSubject");
            var ddlEventsAssignTo = document.getElementById("ContentPlaceHolder1_Client_ddlEventsAssignTo");
            var txtLocationEvent = document.getElementById("ContentPlaceHolder1_Client_txtLocationEvent");
            var TxtDueDateEvent = document.getElementById("ContentPlaceHolder1_Client_TxtDueDateEvent");
            var ddlEventHours = document.getElementById("ContentPlaceHolder1_Client_ddlEventHours");
            var ddlEventmin = document.getElementById("ContentPlaceHolder1_Client_ddlEventmin");
            var ddlEventHours1 = document.getElementById("ContentPlaceHolder1_Client_ddlEventHours1");
            var ddlEventmin1 = document.getElementById("ContentPlaceHolder1_Client_ddlEventmin1");
            var txtEventsDesc = document.getElementById("ContentPlaceHolder1_Client_txtEventsDesc");

            var TxtHM = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker2_dateInput_text");

            if (ddlEventsSubject.selectedIndex == 0) {
                document.getElementById("Span_ddlEventsSubject").style.display = "block";
            }
            if (txtLocationEvent.value == '') {
                document.getElementById("span_textPad").style.display = "block";
            }

            if (TxtDueDateEvent.value == '') {
                document.getElementById("Span_TxtDueDateEvent").style.display = "block";
            }
            else {

                if (ValidateForm(TxtDueDateEvent, 'Span_TxtDueDateEvent1', DateFormat) == false) {

                }
            }
            if (ddlEventsSubject.selectedIndex != 0 && txtLocationEvent.value != '' && TxtDueDateEvent.value != '') {
                DisplayNoneAllContant();
                CallInsert_EventMethod(CompanyID, '', '', '', '', '', 'client', ClientIDTask, '', '', 0, '', 0, '', UserIDN, CreateddateN, ''); return false;
            }
        }

        function ValidateNotesFields() {
            var NotesFileUpload = document.getElementById("ContentPlaceHolder1_Client_NotesFileUpload");
            var FileName = NotesFileUpload.value;
            var txtNoteDesc = document.getElementById("ContentPlaceHolder1_Client_txtNoteDesc");
            var divnotescontentvalidate = document.getElementById("divnotescontentvalidate");
            var diverrorNotesFileUpload = document.getElementById("diverrorNotesFileUpload");
            var SapnNotesFileUpload = document.getElementById("SapnNotesFileUpload");

            if (txtNoteDesc.value.length > 0) {
                divnotescontentvalidate.style.display = 'none';
                CallInsert_NotesMethod(CompanyID, SectionName, SectionID, FileName, '', UserIDN, '', '', '', 0, 0); return false;
            }
            else {

                divnotescontentvalidate.style.display = 'block';
                return false;
            }
        }

        function UpdateValidateAllNotesFields() {
            var AttID = document.getElementById("ContentPlaceHolder1_Client_AttID");
            var AttechMenID = document.getElementById("ContentPlaceHolder1_Client_ddnAttachID");
            if (AttechMenID.value == "") {
                attachID = AttID.value;
            }
            else {
                attachID = AttechMenID.value;
            }

            var NotesFileUpload = document.getElementById("ContentPlaceHolder1_Client_lblOldFile");
            var FileName = NotesFileUpload.innerHTML;
            var lblOldFileSize = document.getElementById("ContentPlaceHolder1_Client_lblOldFileSize");
            var FileSize = lblOldFileSize.innerHTML;
            var txtNoteDesc = document.getElementById("ContentPlaceHolder1_Client_txtNoteDesc");
            var divnotescontentvalidate = document.getElementById("divnotescontentvalidate");
            var diverrorNotesFileUpload = document.getElementById("diverrorNotesFileUpload");
            var SapnNotesFileUpload = document.getElementById("SapnNotesFileUpload");
            document.getElementById("DivOldFile").style.display = "none";
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("AddNote").style.display = "none";
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("DivShowNote").style.display = "block";
            document.getElementById("DivAddNotePopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.position = "absolute";

            if (txtNoteDesc.value.length > 0) {

                divnotescontentvalidate.style.display = 'none';
                if (FileName == "") {
                    Call_UpdateAllNoteMethod(attachID, CompanyID, SectionName, SectionID, FileName, '', UserIDN, '', '', '', 0); return false;
                }
                else {
                    Call_UpdateAllNoteMethod(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, UserIDN, '', '', '', 0); return false;
                }
            }
            else {
                divnotescontentvalidate.style.display = 'block';
                return false;
            }
        }

        function UpdateValidateNotesFields() {
            debugger;
            var AttechMenID = document.getElementById("ContentPlaceHolder1_Client_ddnAttachID");
            attachID = AttechMenID.value;
            var NotesFileUpload = document.getElementById("ContentPlaceHolder1_Client_lblOldFile");
            var FileName = NotesFileUpload.innerHTML;
            var lblOldFileSize = document.getElementById("ContentPlaceHolder1_Client_lblOldFileSize");
            var FileSize = lblOldFileSize.innerHTML;
            var txtNoteDesc = document.getElementById("ContentPlaceHolder1_Client_txtNoteDesc");
            var divnotescontentvalidate = document.getElementById("divnotescontentvalidate");
            var diverrorNotesFileUpload = document.getElementById("diverrorNotesFileUpload");
            var SapnNotesFileUpload = document.getElementById("SapnNotesFileUpload");

            document.getElementById("DivOldFile").style.display = "none";
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("AddNote").style.display = "none";
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("DivShowNote").style.display = "block";
            document.getElementById("DivAddNotePopup").style.display = "none";

            if (txtNoteDesc.value.length > 0) {

                divnotescontentvalidate.style.display = 'none';
                if (FileName == "") {
                    Call_UpdateMethod(attachID, CompanyID, SectionName, SectionID, FileName, '', UserIDN, '', '', '', 0); return false;
                }
                else {
                    Call_UpdateMethod(attachID, CompanyID, SectionName, SectionID, FileName, FileSize, UserIDN, '', '', '', 0); return false;
                }
            }
            else {
                divnotescontentvalidate.style.display = 'block';
                document.getElementById("DivAddNotePopup").style.display = "block";
                return false;
            }
        }


        function ClearContacts() {
            document.getElementById("ContentPlaceHolder1_Client_imgClearcontacts").style.display = "none";
        }

        function Displayclearbutton() {

            var deleteimage = document.getElementById("ContentPlaceHolder1_Client_ImgClearSubject");
            var ddlsubject = document.getElementById("ContentPlaceHolder1_Client_ddlsubject");

            if (ddlsubject.selectedIndex != 0) {
                deleteimage.style.display = "none";
            }
            else {
                deleteimage.style.display = "none";
            }
        }

        function ClearSubjectDrop() {
            document.getElementById("ContentPlaceHolder1_Client_ImgClearSubject").style.display = "none";
            var ddlsubject = document.getElementById("ContentPlaceHolder1_Client_ddlsubject");
            ddlsubject.selectedIndex = 0;
        }

        function GetScreenCordinatesEditNotes(obj) {

            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 16.2;
                p.y = p.y + obj.offsetParent.offsetTop - 2.1;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function Edit_notes(attachID, btnid) {
            var txt = document.getElementById(btnid);
            var p = GetScreenCordinatesEditNotes(txt);

            Closepopups();
            document.getElementById("DivBtnNotesSave").style.marginTop = "0px";
            document.getElementById("DivBtnUpdateNotes").style.marginTop = "0px";
            document.getElementById("DivAddNotePopup").style.left = p.x;
            document.getElementById("DivAddNotePopup").style.top = p.y;
            document.getElementById("DivAddNotePopup").style.position = "absolute";
            document.getElementById("DivAddNotePopup").style.display = "block";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";
            document.getElementById("DivCallSubjects").style.display = "none";
            document.getElementById("DivNotesPopup").style.display = "none";
            document.getElementById("DivTaskMain").style.display = "none";
            document.getElementById("DivTaskMainSecond").style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').focus();
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').value = "";
            document.getElementById('ContentPlaceHolder1_Client_txtNoteDesc').value = "";
            document.getElementById('divnotescontentvalidate').style.display = "none";
            document.getElementById('addfileDiv').style.display = "none";
            $('body,html').animate({ scrollTop: (p.y - 20) }, 800);
            document.getElementById("addfileDiv").style.display = "none";
            document.getElementById("DivShowNote").style.display = "none";
            document.getElementById("AddNote").style.display = "block";
            document.getElementById("divNoteTitle").style.display = "block";
            document.getElementById("DivFileUpload1").style.display = "none";
            document.getElementById("DivBtnNotesSave").style.display = "none";
            document.getElementById("DivBtnUpdateNotes").style.display = "block";
            document.getElementById("DivCloseNoteTitle").style.display = "block";
            document.getElementById('rgarrow').style.display = "block";
            document.getElementById('lftarrow').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lblAddNoteTitle').innerHTML = "Edit Note";
            document.getElementById("DivBtnNotesSave").style.display = "none";
            document.getElementById('DivBtnUpdateAllNotes').style.display = "none";

            var AttechMenID = document.getElementById("ContentPlaceHolder1_Client_ddnAttachID");
            AttechMenID.value = attachID;
            CallEdit_NotesMethod(attachID); return false;
        }

        function ShowMoreNotes() {

            document.getElementById("DivlblNotesTitleHide").style.display = "block";
            document.getElementById("DivlblNotesTitle").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_lnkHidemoreNotes").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_lnkShowmoreNotes").style.display = "none";
        }

        function HideMoreNotes() {

            document.getElementById("DivlblNotesTitleHide").style.display = "none";
            document.getElementById("DivlblNotesTitle").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_lnkShowmoreNotes").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_lnkHidemoreNotes").style.display = "none";
        }

        function delete_note(attachID) {
            Closepopups();
            if (window.confirm('Are you sure you want to delete?')) {

                document.getElementById("DivBtnNotesSave").style.display = "block";
                document.getElementById("DivBtnUpdateNotes").style.display = "none";
                document.getElementById("DivOldFile").style.display = "none";
                document.getElementById("DivUploFile").style.display = "block";
                CallDelete_NotesMethod(CompanyID, SectionID, attachID, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }

        function deleteAll_Note(attachID) {
            Closepopups();
            if (window.confirm('Are you sure you want to delete?')) {

                document.getElementById("DivBtnNotesSave").style.display = "block";
                document.getElementById("DivBtnUpdateNotes").style.display = "none";
                document.getElementById("DivOldFile").style.display = "none";
                document.getElementById("DivUploFile").style.display = "block";
                CallAllDelete_NotesMethod(CompanyID, SectionID, attachID, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }

        function CompleteCall(id, CompanyId, Clientid, SectionName) {

            if (window.confirm('Are you sure you want to Complete this Call?')) {
                var hdnTaskID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID");
                document.getElementById("DivEditCallPopup").style.display = "none";

                CallComplete_Method(hdnTaskID.value, CompanyID, ClientID, 'Call', ''); return false;
                return true;
            }
            else {
                return false;
            }
        }

        function CompleteTask() {

            if (window.confirm('Are you sure you want to complete this task?')) {

                var taskSuccessMsg = document.getElementById('ContentPlaceHolder1_Client_lblSuccMesg');
                document.getElementById('DivlblSuccMesg').style.display = "block";
                taskSuccessMsg.innerHTML = "Task completed Successfully";
                HideOpenActivityMessage();

                var hdnTaskID = "";
                hdnTaskID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskID").value;
                if (hdnTaskID == "") {
                    var hdnCommanID = document.getElementById("ContentPlaceHolder1_Client_hdnCommanID");
                    hdnTaskID = hdnCommanID.value;
                }

                document.getElementById("DivtaskPopUpEdit").style.display = "none";
                document.getElementById("DivtaskEdit").style.display = "none";

                CallDelete_OpenActivitiesMethod(hdnTaskID, CompanyID, ClientID, 'Task', ''); return false;
                return true;
            }
            else {
                return false;
            }
        }

        function delete_OpenActivities(id, CompanyId, Clientid, SectionName) {
            if (SectionName == "Task") {

                if (window.confirm('Are you sure you want to close this task?')) {
                    var taskSuccessMsg = document.getElementById('ContentPlaceHolder1_Client_lblSuccMesg');
                    document.getElementById('DivlblSuccMesg').style.display = "block";
                    taskSuccessMsg.innerHTML = "Task closed Successfully";

                    var lblAllOAmsg = document.getElementById('ContentPlaceHolder1_Client_Label145');
                    document.getElementById('DivdeleteAllOA').style.display = "block";
                    lblAllOAmsg.innerHTML = "Task closed Successfully";

                    HideAllOAMessage();
                    CallDelete_OpenActivitiesMethod(id, CompanyId, Clientid, SectionName, ''); return false;
                    return true;
                }
                else {
                    return false;
                }
            }
            else {

                if (window.confirm('Are you sure you want to delete?')) {
                    var taskSuccessMsg = document.getElementById('ContentPlaceHolder1_Client_lblSuccMesg');
                    document.getElementById('DivlblSuccMesg').style.display = "block";
                    taskSuccessMsg.innerHTML = "Record deleted Successfully";
                    HideOpenActivityMessage();

                    var lblAllOAmsg = document.getElementById('ContentPlaceHolder1_Client_Label145');
                    document.getElementById('DivdeleteAllOA').style.display = "block";
                    lblAllOAmsg.innerHTML = "Call deleted Successfully";

                    HideAllOAMessage();
                    CallDelete_OpenActivitiesMethod(id, CompanyId, Clientid, SectionName, ''); return false;
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        function Complete_Call(id, CompanyId, Clientid, SectionName) {
            if (window.confirm('Are you sure you want to Complete this Call?')) {
                CallComplete_Method(id, CompanyId, Clientid, SectionName, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }

        function delete_CloseActivities(id, CompanyId, Clientid, SectionName) {

            if (window.confirm('Are you sure you want to delete?')) {
                CallDelete_CloseActivitiesMethod(id, CompanyId, Clientid, SectionName, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }

        function CreateFollowUpCall() {
            var txt = document.getElementById("ContentPlaceHolder1_Client_lnkcall");
            var p = GetScreenCordinatesCall(txt);
            document.getElementById("divallnotesbckfade").style.display = "none";
            document.getElementById("DivOpenActiDetails").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_ddlCallDetailsType").selectedIndex = 1;
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivOpenSubject").style.display = "none";
            document.getElementById("DivOpenContact").style.display = "none";
            document.getElementById("DivOpenEventSubject").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";
            document.getElementById("DivNotesPopup").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallSubjects").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "block";
            document.getElementById("MainDivCallTimer").style.display = "block";
            document.getElementById("DivCallPopup").style.left = p.x;
            document.getElementById("DivCallPopup").style.top = p.y;

            document.getElementById("MainDivCallTimerSecond").style.display = "none";
            document.getElementById("DivCallSubject_Validate").style.display = "none";
            document.getElementById("Span_MinuteSecond").style.display = "none";
            document.getElementById("DurationStar").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_ddlCallSubject").focus();
            ddlCallType = document.getElementById("ContentPlaceHolder1_Client_ddlCallType").selectedIndex = 1;
            RdoCurrentCall = document.getElementById("ContentPlaceHolder1_Client_RdoCurrentCall").checked = true;
            RdoCompletedCall = document.getElementById("ContentPlaceHolder1_Client_RdoCompletedCall").checked = false;
            RdoScheduledCall = document.getElementById("ContentPlaceHolder1_Client_RdoScheduledCall").checked = false;
            var txtcallstartdate = document.getElementById("ContentPlaceHolder1_Client_txtcallstartdate");

            txtcallstartdate.value = TodDate;

            document.getElementById("ContentPlaceHolder1_Client_ddlcallHours").selectedIndex = 10;
            document.getElementById("ContentPlaceHolder1_Client_ddlcallMinute").selectedIndex = 0;
            document.getElementById("ContentPlaceHolder1_Client_RadTimePicker4_dateInput_text").value = '';

            txtcallMinute = document.getElementById("ContentPlaceHolder1_Client_txtcallMinute").value = '';
            txtcallSecond = document.getElementById("ContentPlaceHolder1_Client_txtcallSecond").value = '';
            txtcallresult = document.getElementById("ContentPlaceHolder1_Client_txtcallresult").value = '';
            txtCallDesc = document.getElementById("ContentPlaceHolder1_Client_txtCallDesc").value = '';
            ChkBillable = document.getElementById("ContentPlaceHolder1_Client_ChkBillable").checked = false;
            ddlcalltime = document.getElementById("ContentPlaceHolder1_Client_ddlCallCreateFollow").selectedIndex = 0;
            document.getElementById("DivCallTimer").style.display = "none";
            document.getElementById("DivCallStartTime").style.display = "block";
            document.getElementById("DivCallStartTime1").style.display = "block";
            document.getElementById("DivCallDuration").style.display = "block";
            document.getElementById("DivCallDuration1").style.display = "block";
            document.getElementById('DicShowAllOpenActivities').style.display = "none";
            $('body,html').animate({ scrollTop: (p.y - 20) }, 800);

            var hdnTaskFollowParentID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentID");
            var hdnTaskFollowParentType = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentType");
            var hdnCallFollowParentID = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentID");
            var hdnCallFollowParentType = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentType");

            var hdnTaskFollowParentIDDet = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentIDDet");
            var hdnTaskFollowParentTypeDet = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentTypeDet");
            var hdnCallFollowParentIDDet = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentIDDet");
            var hdnCallFollowParentTypeDet = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentTypeDet");

            hdnCallFollowParentID.value = hdnCallFollowParentIDDet.value;
            hdnCallFollowParentType.value = hdnCallFollowParentTypeDet.value;
            hdnTaskFollowParentID.value = hdnTaskFollowParentIDDet.value;
            hdnTaskFollowParentType.value = hdnTaskFollowParentTypeDet.value;
        }

        function CreateFollowUptask(btnid) {
            var txt = document.getElementById("ContentPlaceHolder1_Client_lnkAddTask");
            var p = GetScreenCordinatesNew(txt);
            document.getElementById("divallnotesbckfade").style.display = "none";
            document.getElementById("DivOpenActiDetails").style.display = "none";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";
            document.getElementById("DivCallSubjects").style.display = "none";
            document.getElementById("DivNotesPopup").style.display = "block";
            document.getElementById("DivTaskMain").style.display = "block";
            document.getElementById("DivNotesPopup").style.left = p.x;
            document.getElementById("DivNotesPopup").style.top = p.y;
            document.getElementById("DivTaskMainSecond").style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_ddlassigneto').focus();
            document.getElementById('ContentPlaceHolder1_Client_ddlsubject').selectedIndex = 0;
            document.getElementById('ContentPlaceHolder1_Client_ddlstatus').selectedIndex = 4;
            document.getElementById('ContentPlaceHolder1_Client_ddlpriority').selectedIndex = 3;
            var txtduedate = document.getElementById('ContentPlaceHolder1_Client_txtduedate');

            txtduedate.value = TodDate;
            document.getElementById('ContentPlaceHolder1_Client_RadTimePicker_dateInput_text').value = "";
            document.getElementById('ContentPlaceHolder1_Client_ddlhour').selectedIndex = 1;
            document.getElementById('ContentPlaceHolder1_Client_ddlminute').selectedIndex = 0;
            document.getElementById('ContentPlaceHolder1_Client_txtNotesDesc').value = '';
            document.getElementById('ContentPlaceHolder1_Client_ddltaskFollow').selectedIndex = 0;
            document.getElementById('spn_ddlsubject').style.display = "none";
            document.getElementById('DivSpan_ddlassigneto').style.display = "none";
            document.getElementById('Span_ddlstatus').style.display = "none";
            document.getElementById('Span_ddlpriority').style.display = "none";
            document.getElementById('Span_txtduedate').style.display = "none";
            document.getElementById('Span_txtduedate1').style.display = "none";
            document.getElementById('DicShowAllOpenActivities').style.display = "none";

            document.getElementById('ContentPlaceHolder1_Client_ImgClearSubject').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_imgClearcontacts').style.display = "none";
            $('body,html').animate({ scrollTop: (p.y - 20) }, 800);


            var hdnTaskFollowParentID = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentID");
            var hdnTaskFollowParentType = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentType");
            var hdnCallFollowParentID = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentID");
            var hdnCallFollowParentType = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentType");

            var hdnTaskFollowParentIDDet = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentIDDet");
            var hdnTaskFollowParentTypeDet = document.getElementById("ContentPlaceHolder1_Client_hdnTaskFollowParentTypeDet");

            var hdnCallFollowParentIDDet = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentIDDet");
            var hdnCallFollowParentTypeDet = document.getElementById("ContentPlaceHolder1_Client_hdnCallFollowParentTypeDet");

            hdnTaskFollowParentID.value = hdnTaskFollowParentIDDet.value;
            hdnTaskFollowParentType.value = hdnTaskFollowParentTypeDet.value;
            hdnCallFollowParentID.value = hdnTaskFollowParentIDDet.value;
            hdnCallFollowParentType.value = hdnCallFollowParentTypeDet.value;
        }

        function GetScreenCordinatesEditDetails(obj) {

            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 89.5;
                p.y = p.y + obj.offsetParent.offsetTop + 18.4;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function Edit_TaskCallDetails(btnids) {

            var hdnbuttonid = document.getElementById("ContentPlaceHolder1_Client_hdnbuttonid");
            var hdnCommanID = document.getElementById("ContentPlaceHolder1_Client_hdnCommanID");
            var hdnSectionName = document.getElementById("ContentPlaceHolder1_Client_hdnSectionName");

            if (hdnSectionName.value != "") {
                if (hdnSectionName.value == "Task") {
                    document.getElementById("DivEditCallPopup").style.display = "none";
                    document.getElementById("span_EditMinuteSecond").style.display = "none";
                    document.getElementById("span_EditMinuteSecond").style.display = "none";
                    document.getElementById("Span_ddlEditsubject").style.display = "none";
                    document.getElementById("Span_ddlEditassignto").style.display = "none";
                    document.getElementById("span_ddlEditStataus").style.display = "none";
                    document.getElementById("span_ddlEditPriority").style.display = "none";
                    document.getElementById("span_txtEditDueDate").style.display = "none";
                    document.getElementById("span_txtEditDueDate1").style.display = "none";
                    document.getElementById("DivtaskEditSecond").style.display = "none";
                    document.getElementById("DivEventsSubject").style.display = "none";
                    document.getElementById("DivEventPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";

                    document.getElementById("DivtaskPopUpEdit").style.position = "fixed";
                    document.getElementById("DivtaskPopUpEdit").style.left = "32%";
                    document.getElementById("DivtaskPopUpEdit").style.top = "5%";
                    document.getElementById("DivtaskPopUpEdit").style.zIndex = "5555555555555";
                    document.getElementById("ContentPlaceHolder1_Client_LinkButton12").style.display = "none";

                    document.getElementById("DivtaskPopUpEdit").style.display = "block";
                    document.getElementById("DivtaskEdit").style.display = "block";
                    document.getElementById("DivCallSubjects").style.display = "none";
                    CallEdit_TaskMethod(hdnCommanID.value); return false;
                }
                else if (hdnSectionName.value == "Call") {
                    document.getElementById("DivEditCallTimerSecond").style.display = "none";
                    document.getElementById("DivEventEditSecond").style.display = "none";
                    document.getElementById("DivEditTaskSubject").style.display = "none";
                    document.getElementById("DivtaskPopUpEdit").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenSubject").style.display = "none";
                    document.getElementById("DivOpenContact").style.display = "none";
                    document.getElementById("DivOpenEventSubject").style.display = "none";
                    document.getElementById("DivCallPopup").style.display = "none";
                    document.getElementById("DivNotesPopup").style.display = "none";
                    document.getElementById("DivAddNewEvents").style.display = "none";
                    document.getElementById("span_EditCallSubject").style.display = "none";
                    document.getElementById("span_EditCallStartdate").style.display = "none";
                    document.getElementById("DivEditCallPopup").style.display = "block";
                    document.getElementById("DivEditCallTimer").style.display = "block";
                    document.getElementById("DivCallSubjects").style.display = "none";

                    document.getElementById("DivEditCallPopup").style.position = "fixed";
                    document.getElementById("DivEditCallPopup").style.left = "32%";
                    document.getElementById("DivEditCallPopup").style.top = "5%";
                    document.getElementById("DivEditCallPopup").style.zIndex = "5555555555555";
                    document.getElementById("ContentPlaceHolder1_Client_LinkButton18").style.display = "none";
                    Edit_CallMethod(hdnCommanID.value); return false;
                }
            }
        }

        function Complete_TaskCallDetails() {

            var hdnCommanID = document.getElementById("ContentPlaceHolder1_Client_hdnCommanID");
            var hdnSectionName = document.getElementById("ContentPlaceHolder1_Client_hdnSectionName");

            if (hdnSectionName.value == "Task") {

                if (window.confirm('Are you sure you want to close this task?')) {
                    var taskSuccessMsg = document.getElementById('ContentPlaceHolder1_Client_lblSuccMesg');
                    document.getElementById('DivlblSuccMesg').style.display = "block";
                    taskSuccessMsg.innerHTML = "Task closed Successfully";
                    HideOpenActivityMessage();
                    document.getElementById("DivOpenActiDetails").style.display = "none";
                    document.getElementById("divallnotesbckfade").style.display = "none";
                    CallDelete_OpenActivitiesMethod(hdnCommanID.value, CompanyID, ClientID, hdnSectionName.value, ''); return false;
                    return true;
                }
                else {
                    return false;
                }
            }
            else {

                if (window.confirm('Are you sure you want to complete this call?')) {
                    document.getElementById("DivOpenActiDetails").style.display = "none";
                    document.getElementById("divallnotesbckfade").style.display = "none";
                    CallComplete_Method(hdnCommanID.value, CompanyID, ClientID, hdnSectionName.value, ''); return false;
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        function delete_TaskCallDetails() {
            var hdnCommanID = document.getElementById("ContentPlaceHolder1_Client_hdnCommanID");
            var hdnSectionName = document.getElementById("ContentPlaceHolder1_Client_hdnSectionName");

            if (hdnSectionName.value == "Task") {
                if (window.confirm('Are you sure you want to delete?')) {
                    document.getElementById("DivOpenActiDetails").style.display = "none";
                    document.getElementById("divallnotesbckfade").style.display = "none";
                    delete_TaskMethod(hdnCommanID.value, CompanyID, ClientID, hdnSectionName.value, ''); return false;

                    return true;
                }
                else {
                    return false;
                }
            }
            else {

                if (window.confirm('Are you sure you want to delete?')) {
                    var taskSuccessMsg = document.getElementById('ContentPlaceHolder1_Client_lblSuccMesg');
                    document.getElementById('DivlblSuccMesg').style.display = "block";
                    taskSuccessMsg.innerHTML = "Record deleted Successfully";
                    HideOpenActivityMessage();
                    document.getElementById("DivOpenActiDetails").style.display = "none";
                    document.getElementById("divallnotesbckfade").style.display = "none";
                    CallDelete_OpenActivitiesMethod(hdnCommanID.value, CompanyID, ClientID, hdnSectionName.value, ''); return false;
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        function delete_Task(id, CompanyId, Clientid, SectionName) {

            if (window.confirm('Are you sure you want to delete?')) {
                delete_TaskMethod(id, CompanyId, Clientid, SectionName, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }

        function ViewAttachedFiles(attachID, CompanyID) {
            var iframeAttachedFile = document.getElementById("ContentPlaceHolder1_Client_Ifattachedfiles");
            iframeAttachedFile.setAttribute("src", "../crm_view_attached_files.aspx?&AID=" + attachID + "&CID=" + CompanyID + "");
        }

        function DeleteNotes() {
            jConfirm('Are you sure you want to delete?', 'Confirm', function (r) {
                if (r == true) {

                }
            });
            return false;
        }

        function OpeneRecordsDiv() {
            document.getElementById("ContentPlaceHolder1_Client_divLoadingImageCus").style.display = "block";
            document.cookie = "CRMTabName" + ClientID + "=activities";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.display = "none";

        }

        function OpeneEmailDiv() {
            document.getElementById("ContentPlaceHolder1_Client_divLoadingImageCus").style.display = "block";
            document.cookie = "CRMTabName" + ClientID + "=emails";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.display = "none";
        }

        function OpeneProductsDiv() {
            document.getElementById("ContentPlaceHolder1_Client_divLoadingImageCus").style.display = "block";
            document.cookie = "CRMTabName" + ClientID + "=products";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.display = "none";
        }
        function OpeneStoreDiv() {
            document.getElementById("ContentPlaceHolder1_Client_divLoadingImageCus").style.display = "block";
            document.cookie = "CRMTabName" + ClientID + "=b2b";
            //            document.getElementById("ContentPlaceHolder1_Client_divbtnedit").style.display = "none";
            //            document.getElementById("ContentPlaceHolder1_Client_divbtndelete").style.display = "none";
            //            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "-122px";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.display = "none";
        }

        function OpenAddressBookDiv() {
            var OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx' class='subnavigatorblack' style='text-decoration:underline'>Customer View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Customer Details > Address Book</b></span>";
            document.getElementById("header2_lblsitepath").innerHTML = OldSitePath;

            document.cookie = "CRMTabName" + ClientID + "=address";
            document.getElementById("ContentPlaceHolder1_Client_divbtnedit").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_divbtndelete").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ActivitiesMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_AddressMain").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_div_ContactMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_CostcentreMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ClientMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_DepartmentMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_b2bMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ProductsMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_EmailMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_DivAnotherDesign").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.display = "none";
            //document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "12px";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "-122px";

            if (document.getElementById("SearchPanel").style.display == "block") {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "122px";
                // document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "122px";
            }
            else {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "55px";
                //document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "55px";
            }
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.display = "none";
        }

        function OpenContactDiv() {
            var OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx' class='subnavigatorblack' style='text-decoration:underline'>Customer View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Customer Details > Contact</b></span>";
            document.getElementById("header2_lblsitepath").innerHTML = OldSitePath;

            document.cookie = "CRMTabName" + ClientID + "=contacts";
            document.getElementById("ContentPlaceHolder1_Client_divbtnedit").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_divbtndelete").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ActivitiesMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ContactMain").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_div_CostcentreMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ClientMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_DepartmentMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_AddressMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_b2bMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ProductsMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_EmailMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_DivAnotherDesign").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.display = "none";
            // document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "12px";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "-122px";

            if (document.getElementById("SearchPanel").style.display == "block") {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "122px";
                // document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "122px";
            }
            else {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "55px";
                // document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "55px";
            }
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.display = "none";
        }
        function OpenCostCentreDiv() {
            var OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx' class='subnavigatorblack' style='text-decoration:underline'>Customer View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Customer Details > Cost Centre</b></span>";
            document.getElementById("header2_lblsitepath").innerHTML = OldSitePath;

            document.cookie = "CRMTabName" + ClientID + "=costcentre";
            document.getElementById("ContentPlaceHolder1_Client_divbtnedit").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_divbtndelete").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ActivitiesMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_CostcentreMain").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_div_ClientMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_DepartmentMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ContactMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_AddressMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_b2bMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ProductsMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_EmailMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_DivAnotherDesign").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.display = "none";
            // document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "12px";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "-122px";

            if (document.getElementById("SearchPanel").style.display == "block") {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "122px";
                //   document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "122px";
            }
            else {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "55px";
                //  document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "55px";
            }
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.display = "none";
        }

        function OpenClientDetailsDiv() {
            var OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx' class='subnavigatorblack' style='text-decoration:underline'>Customer View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Customer Details > Summary Information</b></span>";
            document.getElementById("header2_lblsitepath").innerHTML = OldSitePath;

            document.cookie = "CRMTabName" + ClientID + "=client";

            //            document.getElementById("ContentPlaceHolder1_Client_btnEdit").style.display = "block";
            //            document.getElementById("ContentPlaceHolder1_Client_btnDelete").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_divbtnedit").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_divbtndelete").style.display = "block";

            document.getElementById("ContentPlaceHolder1_Client_div_ActivitiesMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ClientMain").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_div_DepartmentMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_CostcentreMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ContactMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_AddressMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_b2bMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ProductsMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_EmailMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_DivAnotherDesign").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "12px";

            if (document.getElementById("SearchPanel").style.display == "block") {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "122px";
                //  document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "122px";
            }
            else {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "55px";
                //   document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "55px";
            }
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.display = "none";
        }

        function OpenDepartmentDiv() {
            var OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx' class='subnavigatorblack' style='text-decoration:underline'>Customer View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Customer Details > Department</b></span>";
            document.getElementById("header2_lblsitepath").innerHTML = OldSitePath;

            document.cookie = "CRMTabName" + ClientID + "=dept";
            document.getElementById("ContentPlaceHolder1_Client_divbtnedit").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_divbtndelete").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ActivitiesMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_DepartmentMain").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_div_ClientMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_CostcentreMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ContactMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_AddressMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_b2bMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_ProductsMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_div_EmailMain").style.display = "none";
            document.getElementById("ContentPlaceHolder1_Client_DivAnotherDesign").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.display = "none";
            //            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "12px";
            document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.left = "-122px";
            if (document.getElementById("SearchPanel").style.display == "block") {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "122px";
                //document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "122px";
            }
            else {
                document.getElementById("ContentPlaceHolder1_Client_DivMoreAction").style.marginTop = "55px";
                //  document.getElementById("ContentPlaceHolder1_Client_DivPrintOptions").style.marginTop = "55px";
            }
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivAddNotePopup").style.display = "none";
        }

        function OpenMoreActions() {
            document.getElementById("ContentPlaceHolder1_UCItemSummaryMain_ctl00_DivMoreAction").style.display = "block";
            if (document.getElementById("ContentPlaceHolder1_UCItemSummaryMain_ctl00_DivMoreAction").style.display == "block") {
                document.getElementById("ContentPlaceHolder1_UCItemSummaryMain_ctl00_DivMoreAction").style.left = "80px";
            }
           
        }

        function ClosedMoreActions() {
            document.getElementById("ContentPlaceHolder1_UCItemSummaryMain_ctl00_DivMoreAction").style.display = "none";
        }

        function CloseCallPopup() {
            document.getElementById("DivCallPopup").style.display = "none";
        }
        function OpenCallPopup(btnid) {

            var txt = document.getElementById(btnid);
            var p = GetScreenCordinatesCall(txt);
            document.getElementById("ContentPlaceHolder1_Client_Label118").innerHTML = "Add Call";
            document.getElementById("ContentPlaceHolder1_Client_ddlCallDetailsType").selectedIndex = 1;

            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivOpenSubject").style.display = "none";
            document.getElementById("DivOpenContact").style.display = "none";
            document.getElementById("DivOpenEventSubject").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";
            document.getElementById("DivNotesPopup").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallSubjects").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "block";
            document.getElementById("MainDivCallTimer").style.display = "block";
            document.getElementById("DivCallPopup").style.left = p.x;
            document.getElementById("DivCallPopup").style.top = p.y;

            document.getElementById("MainDivCallTimerSecond").style.display = "none";
            document.getElementById("DivCallSubject_Validate").style.display = "none";
            document.getElementById("Span_MinuteSecond").style.display = "none";
            document.getElementById("DurationStar").style.display = "none";

            document.getElementById("ContentPlaceHolder1_Client_ddlCallSubject").focus();
            ddlCallType = document.getElementById("ContentPlaceHolder1_Client_ddlCallType").selectedIndex = 1;
            RdoCurrentCall = document.getElementById("ContentPlaceHolder1_Client_RdoCurrentCall").checked = true;
            RdoCompletedCall = document.getElementById("ContentPlaceHolder1_Client_RdoCompletedCall").checked = false;
            RdoScheduledCall = document.getElementById("ContentPlaceHolder1_Client_RdoScheduledCall").checked = false;
            var txtcallstartdate = document.getElementById("ContentPlaceHolder1_Client_txtcallstartdate");

            txtcallstartdate.value = TodDate;

            document.getElementById("ContentPlaceHolder1_Client_ddlcallHours").selectedIndex = 10;
            document.getElementById("ContentPlaceHolder1_Client_ddlcallMinute").selectedIndex = 0;
            document.getElementById("ContentPlaceHolder1_Client_RadTimePicker4_dateInput_text").value = '';

            txtcallMinute = document.getElementById("ContentPlaceHolder1_Client_txtcallMinute").value = '';
            txtcallSecond = document.getElementById("ContentPlaceHolder1_Client_txtcallSecond").value = '';
            txtcallresult = document.getElementById("ContentPlaceHolder1_Client_txtcallresult").value = '';
            txtCallDesc = document.getElementById("ContentPlaceHolder1_Client_txtCallDesc").value = '';
            ChkBillable = document.getElementById("ContentPlaceHolder1_Client_ChkBillable").checked = false;
            ddlcalltime = document.getElementById("ContentPlaceHolder1_Client_ddlCallCreateFollow").selectedIndex = 0;
            document.getElementById("DivCallTimer").style.display = "none";
            document.getElementById("DivCallStartTime").style.display = "block";
            document.getElementById("DivCallStartTime1").style.display = "block";
            document.getElementById("DivCallDuration").style.display = "block";
            document.getElementById("DivCallDuration1").style.display = "block";
            document.getElementById('DivAddNotePopup').style.display = "none";
            $('body,html').animate({ scrollTop: (p.y - 20) }, 800);
        }

        function CloseEventsPopup() {
            document.getElementById("DivAddNewEvents").style.display = "none";
        }

        function ValidateAddSubject() {

            var txtSubject = document.getElementById("ContentPlaceHolder1_Client_txtSubject");

            if (txtSubject.value == '') {
                document.getElementById("DivSubjectAddValidations").style.display = "block";
            }

            if (txtSubject.value != '') {
                document.getElementById("DivSubjectAddValidations").style.display = "none";
                CallInsert_NotesSubjectMethod('', CompanyID, ''); return false;
            }
        }

        function ValidateAddCallSubject() {

            var txtCallSubjects = document.getElementById("ContentPlaceHolder1_Client_txtCallSubjects");

            if (txtCallSubjects.value == '') {
                document.getElementById("span_callsubj").style.display = "block";
            }
            else {

                document.getElementById("span_callsubj").style.display = "none";
                CallInsert_CallSubjectMethod(CompanyID, '', 'False', UserIDN); return false;
            }
        }

        function ValidateEditAddSubject() {

            var txtEditSubject = document.getElementById("ContentPlaceHolder1_Client_txtEditSubject");

            if (txtEditSubject.value == '') {
                document.getElementById("DivEditSubjectAddValidations").style.display = "block";
            }

            if (txtEditSubject.value != '') {
                document.getElementById("DivEditSubjectAddValidations").style.display = "none";
                CallInsert_taskEditSubjectMethod('', CompanyID, ''); return false;
            }
        }

        function CallChkvalidate() {

            var ddlCallSubject = document.getElementById("ContentPlaceHolder1_Client_ddlCallSubject");
            var RdoCurrentCall = document.getElementById("ContentPlaceHolder1_Client_RdoCurrentCall");
            var RdoCompletedCall = document.getElementById("ContentPlaceHolder1_Client_RdoCompletedCall");
            var RdoScheduledCall = document.getElementById("ContentPlaceHolder1_Client_RdoScheduledCall");
            var txtcallstartdate = document.getElementById("ContentPlaceHolder1_Client_txtcallstartdate");
            var ddlcalltime = document.getElementById("ContentPlaceHolder1_Client_ddlcalltime");

            var ddlCallDetailsType123 = document.getElementById("ContentPlaceHolder1_Client_ddlCallDetailsType");
            ddlCallDetailsType123.options[ddlCallDetailsType123.selectedIndex].text;
            var CallDetailsType123 = ddlCallDetailsType123.options[ddlCallDetailsType123.selectedIndex].value;
            var txtcallMinute = document.getElementById("ContentPlaceHolder1_Client_txtcallMinute");
            var txtcallSecond = document.getElementById("ContentPlaceHolder1_Client_txtcallSecond");

            var ddlassignto = document.getElementById("ContentPlaceHolder1_Client_ddlowner");

            var TxtHM = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker4_dateInput_text");

            if (ddlCallSubject.selectedIndex == -1) {
                document.getElementById("DivCallSubject_Validate").style.display = "block";
                return true;
            }
            if (CallDetailsType123 == "2") {
                if (TxtHM.value == '') {
                    document.getElementById("span_txtcallstartdate").style.display = "block";
                    return true;
                }
                if (txtcallstartdate.value == '') {
                    document.getElementById("span_txtcallstartdate").style.display = "block";
                    return true;
                }
            }
            else if (CallDetailsType123 == "3") {
                if (TxtHM.value == '') {
                    document.getElementById("span_txtcallstartdate").style.display = "block";
                    return true;
                }
                if (txtcallstartdate.value == '') {
                    document.getElementById("span_txtcallstartdate").style.display = "block";
                    return true;
                }
            }
            if (ddlassignto.options.length == 0) {

                document.getElementById("diverrorCallAssignTo").style.display = "block";
                return true;
            }

            DisplayNoneAllContant();
            Insert_Call(CompanyID, SectionID, '', '', '', '', '', '', '', '', '', '', '', '', '', UserIDN, '', '', '', 0); return false;
        }

        function ValidateEventsControl() {

            var ddlEventsSubject = document.getElementById("<%=ddlEventsSubject.ClientID%>");
            var ddlEventsAssignTo = document.getElementById("<%=ddlEventsAssignTo.ClientID%>");
            var txtLocationEvent = document.getElementById("<%=txtLocationEvent.ClientID%>");
            var TxtDueDateEvent = document.getElementById("<%=TxtDueDateEvent.ClientID%>");

            if (ddlEventsSubject.selectedIndex == 0) {
                document.getElementById("Span_ddlEventsSubject").style.display = "block";
            }
            if (ddlEventsAssignTo.selectedIndex == 0) {
                document.getElementById("Span_ddlEventsAssignTo").style.display = "block";
            }
            if (txtLocationEvent.value == '') {
                document.getElementById("span_textPad").style.display = "block";
            }
            if (txtLocationEvent.value == '') {
                document.getElementById("Span_TxtDueDateEvent").style.display = "block";
            }
        }

        function ValiSaveTasks() {

            var ddlsubject = document.getElementById("<%=ddlsubject.ClientID%>");
            var ddlassigneto = document.getElementById("<%=ddlassigneto.ClientID%>");
            var ddlstatus = document.getElementById("<%=ddlstatus.ClientID%>");
            var ddlpriority = document.getElementById("<%=ddlpriority.ClientID%>");
            var txtduedate = document.getElementById("<%=txtduedate.ClientID%>");

            var TxtHM = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker_dateInput_text");

            if (ddlsubject.selectedIndex == 0) {
                document.getElementById("spn_ddlsubject").style.display = "block";
            }

            if (ddlstatus.selectedIndex == 0) {
                document.getElementById("Span_ddlstatus").style.display = "block";
            }
            if (ddlpriority.selectedIndex == 0) {
                document.getElementById("Span_ddlpriority").style.display = "block";
            }
            if (txtduedate.value == '') {
                document.getElementById("Span_txtduedate").style.display = "block";
            }
            else {

                if (ValidateForm(txtduedate, 'Span_txtduedate1', DateFormat) == false) {

                }
            }

            if (ddlsubject.selectedIndex != 0 && ddlstatus.selectedIndex != 0 && ddlpriority.selectedIndex != 0 && txtduedate.value != '') {
                DisplayNoneAllContant();
                CallInsert_TaskMethod(CompanyID, '', '', '', '', '', 0, '', 'client', ClientIDTask, '', 0, '', UserIDN, UserIDN, CreateddateN, CreateddateN, '', 0, ''); return false;
            }
            else {
                taskRightDivSlideToleft();
            }
        }

        function Validatesavenotes() {
            var ddlsubject = document.getElementById("<%=ddlsubject.ClientID%>");
            var ddlassigneto = document.getElementById("<%=ddlassigneto.ClientID%>");
            var ddlstatus = document.getElementById("<%=ddlstatus.ClientID%>");
            var ddlpriority = document.getElementById("<%=ddlpriority.ClientID%>");
            var txtduedate = document.getElementById("<%=txtduedate.ClientID%>");

            var TxtHM = document.getElementById("ContentPlaceHolder1_Client_RadTimePicker_dateInput_text");

            if (ddlsubject.selectedIndex == 0) {
                document.getElementById("spn_ddlsubject").style.display = "block";
            }
            if (ddlstatus.selectedIndex == 0) {
                document.getElementById("Span_ddlstatus").style.display = "block";
            }
            if (ddlpriority.selectedIndex == 0) {
                document.getElementById("Span_ddlpriority").style.display = "block";
            }
            if (txtduedate.value == '') {
                document.getElementById("Span_txtduedate").style.display = "block";
            }
            else {

                if (ValidateForm(txtduedate, 'Span_txtduedate1', DateFormat) == false) {

                }
            }

            if (ddlsubject.selectedIndex != 0 && ddlstatus.selectedIndex != 0 && ddlpriority.selectedIndex != 0 && txtduedate.value != '') {
                DisplayNoneAllContant();
                CallInsert_TaskMethod(CompanyID, '', '', '', '', '', 0, '', 'client', ClientIDTask, '', 0, '', UserIDN, UserIDN, CreateddateN, CreateddateN, '', 0, '', '', 0); return false;
            }
        }

        function SetDefaultContact(CompanyID, clientID, ContactID) {

            CallUpdate_Contact(CompanyID, clientID, ContactID, ''); return false;
        }
    </script>
    <script type="text/javascript">

        function OpenShowEventContactDiv() {
            document.getElementById("DivOpenContact").style.display = "block";
        }

        function CloseEventsPopup() {
            document.getElementById("DivAddNewEvents").style.display = "none";
        }

        function CloseContactPopup() {
            document.getElementById("DivOpenContact").style.display = "none";
        }

        function OpenShowContactDiv() {
            document.getElementById("DivOpenSubject").style.display = "none";
            document.getElementById("DivOpenContact").style.display = "block";
        }

        function OpenSubjectDiv() {
            document.getElementById("DivOpenSubject").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_txtSubject").value = '';
            document.getElementById("ContentPlaceHolder1_Client_txtSubject").focus();
            document.getElementById("DivOpenEventSubject").style.display = "none";
        }

        function GetScreenCordinatesForAddCallSubject(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 42;
                p.y = p.y + obj.offsetParent.offsetTop - 10;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function OpenCallSubjectDiv(btnid) {

            var txt = document.getElementById(btnid);
            var p = GetScreenCordinatesForAddCallSubject(txt);

            document.getElementById("DivCallSubjects").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_txtCallSubjects").value = '';
            document.getElementById("ContentPlaceHolder1_Client_txtCallSubjects").focus();
            document.getElementById("DivOpenEventSubject").style.display = "none";
            document.getElementById("DivOpenSubject").style.display = "none";
            document.getElementById("DivCallSubjects").style.left = p.x;
            document.getElementById("DivCallSubjects").style.top = p.y;
        }

        function GetScreenCordinatesForEditCallSubject(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 23.8;
                p.y = p.y + obj.offsetParent.offsetTop - 14.5;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function OpenEditCallSubjectDiv(btnid) {

            var txt = document.getElementById(btnid);
            var p = GetScreenCordinatesForEditCallSubject(txt);

            document.getElementById("DivCallSubjects").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_txtCallSubjects").value = '';
            document.getElementById("ContentPlaceHolder1_Client_txtCallSubjects").focus();
            document.getElementById("DivOpenEventSubject").style.display = "none";
            document.getElementById("DivOpenSubject").style.display = "none";
            document.getElementById("DivCallSubjects").style.left = p.x;
            document.getElementById("DivCallSubjects").style.top = p.y;
        }

        function OpenEventSubjectDiv() {
            document.getElementById("DivOpenSubject").style.display = "none";
            document.getElementById("DivOpenEventSubject").style.display = "block";
            document.getElementById("ContentPlaceHolder1_Client_txtEventSubject").value = '';
            document.getElementById("ContentPlaceHolder1_Client_txtEventSubject").focus();
        }

        function CloseEventPopupAddSubject() {
            document.getElementById("DivOpenEventSubject").style.display = "none";
            document.getElementById("Div_EventSubject_Validations").style.display = "none";
        }

        function CloseTaskPopupAddSubject() {
            document.getElementById("DivOpenSubject").style.display = "none";
            document.getElementById("span_callsubj").style.display = "none";
        }

        function CloseCallPopupAddSubject() {
            document.getElementById("DivCallSubjects").style.display = "none";
            document.getElementById("span_callsubj").style.display = "none";
        }

        function CloseTaskPopup() {
            document.getElementById("DivNotesPopup").style.display = "none";
        }

        function GetScreenCordinatesNew(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 30;
                p.y = p.y + obj.offsetParent.offsetTop - 2.7;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function GetScreenCordinatesCall(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 30;
                p.y = p.y + obj.offsetParent.offsetTop - 2.7;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function OpenPopUp(btnid) {

            var txt = document.getElementById(btnid);
            var p = GetScreenCordinatesNew(txt);
            document.getElementById("ContentPlaceHolder1_Client_Label113").innerHTML = "Add Task";
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("DivEditTaskSubject").style.display = "none";
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivEventsSubject").style.display = "none";
            document.getElementById("DivEventPopUpEdit").style.display = "none";
            document.getElementById("DivAddNewEvents").style.display = "none";
            document.getElementById("DivCallPopup").style.display = "none";

            document.getElementById("DivCallSubjects").style.display = "none";

            document.getElementById("DivNotesPopup").style.display = "block";
            document.getElementById("DivTaskMain").style.display = "block";
            document.getElementById("DivNotesPopup").style.left = p.x;
            document.getElementById("DivNotesPopup").style.top = p.y;

            document.getElementById("DivTaskMainSecond").style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_ddlassigneto').focus();
            document.getElementById('ContentPlaceHolder1_Client_ddlsubject').selectedIndex = 0;
            document.getElementById('ContentPlaceHolder1_Client_ddlstatus').selectedIndex = 4;
            document.getElementById('ContentPlaceHolder1_Client_ddlpriority').selectedIndex = 3;
            var txtduedate = document.getElementById('ContentPlaceHolder1_Client_txtduedate');

            txtduedate.value = TodDate;
            document.getElementById('ContentPlaceHolder1_Client_RadTimePicker_dateInput_text').value = "";
            document.getElementById('ContentPlaceHolder1_Client_ddlhour').selectedIndex = 1;
            document.getElementById('ContentPlaceHolder1_Client_ddlminute').selectedIndex = 0;
            document.getElementById('ContentPlaceHolder1_Client_txtNotesDesc').value = '';
            document.getElementById('ContentPlaceHolder1_Client_ddltaskFollow').selectedIndex = 0;
            document.getElementById('spn_ddlsubject').style.display = "none";
            document.getElementById('DivSpan_ddlassigneto').style.display = "none";
            document.getElementById('Span_ddlstatus').style.display = "none";
            document.getElementById('Span_ddlpriority').style.display = "none";
            document.getElementById('Span_txtduedate').style.display = "none";
            document.getElementById('Span_txtduedate1').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_ImgClearSubject').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_imgClearcontacts').style.display = "none";
            document.getElementById('DivAddNotePopup').style.display = "none";

            $('body,html').animate({ scrollTop: (p.y - 20) }, 800);
        }

    </script>
    <script type="text/javascript">
        $(function () {
            $(window).scroll(function () {
                if ($(this).scrollTop() != 0) {
                    $('#toTop').fadeIn();
                } else {
                    $('#toTop').fadeOut();
                }
            });

            $('#toTop').click(function () {
                $('body,html').animate({ scrollTop: 0 }, 800);
            });
        });
    </script>
    <script type="text/javascript">

        function EditNotes() {
            document.getElementById("DivShowNote").style.display = 'none';
            document.getElementById("DivCloseNoteTitle").style.display = 'none';
            document.getElementById("DivCloseBrowseFile").style.display = 'none';
            document.getElementById("DivBtnUpdateNotes").style.display = 'block';
            document.getElementById("DivBtnNotesSave").style.display = 'none';
            document.getElementById("AddNote").style.display = 'block';
            document.getElementById("divNoteTitle").style.display = 'block';

            var NitesTitle = document.getElementById("ContentPlaceHolder1_Client_lblNotesTitle");
            var NitesDesc = document.getElementById("ContentPlaceHolder1_Client_lblNotesDescripitions");
            var txtnoteTitle = document.getElementById("ContentPlaceHolder1_Client_txtnoteTitle");
            var txtNoteDesc = document.getElementById("ContentPlaceHolder1_Client_txtNoteDesc");
            txtnoteTitle.value = NitesTitle.innerHTML;
            txtNoteDesc.value = NitesDesc.innerHTML;
        }

        function HideEditDeleteButton(imgCounter) {
            document.getElementById("DeleteNotes_" + imgCounter).style.display = "none";
            document.getElementById("Seprator_" + imgCounter).style.display = "none";
            document.getElementById("EditNotes_" + imgCounter).style.display = "none";
        }
        function ShowEditDeleteButton(imgCounter) {
            document.getElementById("DeleteNotes_" + imgCounter).style.display = "block";
            document.getElementById("Seprator_" + imgCounter).style.display = "block";
            document.getElementById("EditNotes_" + imgCounter).style.display = "block";
        }

        function HideEditDeleteButton1(imgCounter1) {

            document.getElementById("DeleteNotes1_" + imgCounter1).style.display = "none";
            document.getElementById("Seprator1_" + imgCounter1).style.display = "none";
            document.getElementById("EditNotes1_" + imgCounter1).style.display = "none";
        }
        function ShowEditDeleteButton1(imgCounter1) {
            document.getElementById("DeleteNotes1_" + imgCounter1).style.display = "block";
            document.getElementById("Seprator1_" + imgCounter1).style.display = "block";
            document.getElementById("EditNotes1_" + imgCounter1).style.display = "block";
        }

        function HideEditDeleteButton2(imgCounter2) {
            document.getElementById("DeleteNotes2_" + imgCounter2).style.display = "none";
            document.getElementById("Seprator2_" + imgCounter2).style.display = "none";
            document.getElementById("EditNotes2_" + imgCounter2).style.display = "none";
        }
        function ShowEditDeleteButton2(imgCounter2) {
            document.getElementById("DeleteNotes2_" + imgCounter2).style.display = "block";
            document.getElementById("Seprator2_" + imgCounter2).style.display = "block";
            document.getElementById("EditNotes2_" + imgCounter2).style.display = "block";
        }

        function HideEditDeleteButton3(imgCounter3) {
            document.getElementById("DeleteNotes3_" + imgCounter3).style.display = "none";
            document.getElementById("Seprator3_" + imgCounter3).style.display = "none";
            document.getElementById("EditNotes3_" + imgCounter3).style.display = "none";
        }
        function ShowEditDeleteButton3(imgCounter3) {
            document.getElementById("DeleteNotes3_" + imgCounter3).style.display = "block";
            document.getElementById("Seprator3_" + imgCounter3).style.display = "block";
            document.getElementById("EditNotes3_" + imgCounter3).style.display = "block";
        }

        function OpenBrowseFile() {
            document.getElementById('DivFileUpload1').style.display = "block";
            document.getElementById('DivCloseBrowseFile').style.display = "block";
            document.getElementById("DivOldFile").style.display = "none";
        }

        function CloseBrowseFile() {
            document.getElementById('addfileDiv').style.display = "none";
            document.getElementById('DivCloseBrowseFile').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_txtNoteDesc').focus();
            document.getElementById("diverrorNotesFileUpload").style.display = 'none';
            document.getElementById("ContentPlaceHolder1_Client_NotesFileUpload").value = '';
        }

        function OpenNoteTitle() {
            document.getElementById('divNoteTitle').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').focus();
            document.getElementById('DivCloseNoteTitle').style.display = "block";
        }

        function CloseNoteTitle() {
            document.getElementById('DivCloseNoteTitle').style.display = "none";
            document.getElementById('divNoteTitle').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_txtNoteDesc').focus();
        }

        function OpenAddnotesDetails() {

            document.getElementById('AddNote').style.display = "block";
            document.getElementById('DivShowNote').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_txtNoteDesc').focus();
            document.getElementById('ContentPlaceHolder1_Client_txtNoteDesc').value = '';
            document.getElementById('ContentPlaceHolder1_Client_txtnoteTitle').value = '';
            document.getElementById("ContentPlaceHolder1_Client_NotesFileUpload").value = '';
            document.getElementById('divNoteTitle').style.display = "block";
            document.getElementById('DivFileUpload1').style.display = "none";
            document.getElementById('DivCloseNoteTitle').style.display = "none";
            document.getElementById('DivCloseBrowseFile').style.display = "none";
            document.getElementById("DivBtnUpdateNotes").style.display = 'none';
            document.getElementById("DivBtnNotesSave").style.display = 'block';
            document.getElementById("divnotescontentvalidate").style.display = 'none';
            document.getElementById("diverrorNotesFileUpload").style.display = 'none';
            document.getElementById("ContentPlaceHolder1_Client_NotesFileUpload").value = '';
            document.getElementById("DivUploFile").style.display = 'block';

        }

        function HideAddnotesDetails() {
            document.getElementById('AddNote').style.display = "none";
            document.getElementById('addfileDiv').style.display = "none";
            document.getElementById('DivShowNote').style.display = "block";
            document.getElementById("DivOldFile").style.display = "none";
        }

        function ShowPersentageDetails() {

            document.getElementById('DivConversion').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkCoversionHide').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkCoversionShow').style.display = "none";
        }
        function HidePersentageDetails() {
            document.getElementById('DivConversion').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkCoversionHide').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkCoversionShow').style.display = "block";
        }

        function ShowInvoiceDetails() {

            document.getElementById('DivInvoiceDetails').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkInvoiceDown').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkInvoiceUp').style.display = "block";
        }

        function HideInvoiceDetails() {

            document.getElementById('DivInvoiceDetails').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkInvoiceDown').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkInvoiceUp').style.display = "none";
        }

        function ShowEstimateDetails() {

            document.getElementById('DivEstimate').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkEstimateDown').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkEstimateUp').style.display = "block";
        }

        function HideEstimateDetails() {

            document.getElementById('DivEstimate').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkEstimateDown').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkEstimateUp').style.display = "none";
        }

        function HidejobDetails() {

            document.getElementById('JobTable').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkjobDown').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkjobup').style.display = "none";
        }

        function ShowjobDetails() {

            document.getElementById('JobTable').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkjobDown').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkjobup').style.display = "block";
        }

        function ShowDetails() {

            document.getElementById('ShowDivLeft').style.display = "block";
            document.getElementById('ShowDivRight').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkShowdetail').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkHideDetails').style.display = "block";
        }

        function HideDetails() {

            document.getElementById('ShowDivLeft').style.display = "none";
            document.getElementById('ShowDivRight').style.display = "none";
            document.getElementById('ContentPlaceHolder1_Client_lnkShowdetail').style.display = "block";
            document.getElementById('ContentPlaceHolder1_Client_lnkHideDetails').style.display = "none";
        }

    </script>
    <script type="text/javascript" language="javascript">

        var CompanyID = '<%=CompanyID%>';
        var UserID = '<%=UserID%>';
        var CompanyType = '<%=CompanyType %>';
        var sitePath = '<%=nmsCommon.global.sitePath()%>';
        var ClientID = '<%=ClientID%>';
        var redirectFrom = '';
        var AccountID = '<%=AccountID %>';
        var WebStorePathB2B = '<%=WebStorePathB2B %>';
        var WebStorePathB2C = '<%=WebStorePathB2C %>';

        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
        var div_popupAction = document.getElementById("div_popupAction");
        var RadListBox_Contact = document.getElementById("ContentPlaceHolder1_Client_ctl16_RadListBox_Contact");

        var img_actionsShow_Dept = document.getElementById("img_actionsShow_Dept");
        var img_actionsHide_Dept = document.getElementById("img_actionsHide_Dept");
      

        var img_actionsShow_Address = document.getElementById("img_actionsShow_Address");
        var img_actionsHide_Address = document.getElementById("img_actionsHide_Address");
        var div_popupActionAddress = document.getElementById("div_popupActionAddress");
      

       

        var div_ClientTabs = document.getElementById("div_ClientTabs");
        var div_ContactsTabs = document.getElementById("div_ContactsTabs");
        var div_DeptsTabs = document.getElementById("div_DeptsTabs");

        var div_DepartmentDelete = document.getElementById("div_DepartmentDelete");
      


     

        function SetTabs(val, isfrompopup) {
            getMainTabs(val, isfrompopup);
        }

        function TakeOut() {
            window.close();
        }

        if (redirectFrom != '') {
            getMainTabs(redirectFrom);
        }

        var img_actionsHide_Notes = document.getElementById("img_actionsHide_Notes");
        var img_actionsShow_Notes = document.getElementById("img_actionsShow_Notes");

        var div_chk_Notes = document.getElementById("div_chk_Notes");
        var div_popupActionNotes = document.getElementById("div_popupActionNotes");

        var lbl_Subject = document.getElementById("ContentPlaceHolder1_Client_NotesSubSection_dlist_Notes_lbl_Subject");

        function incHeight(lnkid) {

            var lnk = document.getElementById(lnkid);
            var div = document.getElementById(lnkid.replace('lnkMore', 'div_Notes_Subject'));

            if (lnk.innerHTML.indexOf('More') != -1) {
                lnk.innerHTML = "Less...";
            }
            else {
                lnk.innerHTML = "More...";
            }

            if (div.style.height == 'auto') {
                div.style.height = "60px";

            }
            else {
                div.style.height = 'auto';
            }
            div.focus();
            return false;
        }

    </script>
    <asp:Panel ID="pnl_MoreThan1Selected" runat="server" Visible="false">
        <script type="text/javascript" language="javascript">

            function Defaultcontact_click() {
                alert("Please check only one 'row' to set as default contact");
                return false;
            }
            Defaultcontact_click();

        </script>
    </asp:Panel>
    <asp:Panel ID="pnl_MoreThan1Selected_Dept" runat="server" Visible="false">
        <script type="text/javascript" language="javascript">

            function Defaultcontact_click() {
                alert("Please check only one 'row' to set as default contact");
                return false;
            }
            Defaultcontact_click();

        </script>
    </asp:Panel>
    <asp:Panel ID="pnl_MoreThan1Selected_Address" runat="server" Visible="false">
        <script type="text/javascript" language="javascript">

            function Defaultcontact_click() {
                alert("Please check only one 'row' to set as post box address");
                return false;
            }
            Defaultcontact_click();

        </script>
    </asp:Panel>
    <script type="text/javascript" language="javascript">

        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";

        function changeSortDirection() {
            document.getElementById("div_Load").style.display = "none";
            __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_SortDirection', '')
            document.getElementById("div_Load").style.display = "block";
        }

       

        function ReadWindowClose(windowid) {
            var oWnd = GetRadWindowManager().GetWindowByName(windowid);
            if (oWnd != null && oWnd != undefined) {
                oWnd.Close();
            }
        }

        function callDept() {
            document.getElementById("div_DepartmentDelete").style.display = "none";
            document.getElementById("ds00").style.display = "none";
            document.getElementById("div_Load").style.display = "block";
            document.getElementById("divBackGroundNew").style.display = "none";
            getDeptID();
        }

    </script>
    <script language="javascript" type="text/javascript">
        function CheckChanged_Dept() {
            var frm = document.forms[0];
            var boolAllChecked;
            boolAllChecked = true;

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Department') != -1)
                    if (e.checked == false && (!e.disabled)) {
                        boolAllChecked = false;
                        break;
                    }
            }

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkAll_Dept') != -1) {
                    if (boolAllChecked == false) {
                        e.checked = false;
                    }
                    else
                        e.checked = true;
                    break;
                }
            }
        }

        function CheckChanged_Contact() {
            var frm = document.forms[0];
            var boolAllChecked;
            boolAllChecked = true;

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Contact') != -1)
                    if (e.checked == false && (!e.disabled)) {
                        boolAllChecked = false;
                        break;
                    }
            }

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkAll') != -1) {
                    if (boolAllChecked == false) {
                        e.checked = false;
                    }
                    else
                        e.checked = true;
                    break;
                }
            }
        }

        function CheckChanged_Address() {
            var frm = document.forms[0];
            var boolAllChecked;
            boolAllChecked = true;

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Address') != -1)
                    if (e.checked == false && (!e.disabled)) {
                        boolAllChecked = false;
                        break;
                    }
            }

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkAll_Address') != -1) {
                    if (boolAllChecked == false) {
                        e.checked = false;
                    }
                    else
                        e.checked = true;
                    break;
                }
            }
        }
        function hideDiv(val) {
            document.getElementById(val).style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
            return false;
        }

        function chkcostdefault(chkapply, chkdefault) {
            var chkapply = document.getElementById(chkapply);
            var chkdefault = document.getElementById(chkdefault);
            if (chkapply.checked == true) {
                chkdefault.checked = true;
            }
        }

    </script>
    <script type="text/javascript">
        function pageLoad() {
            $(document).ready(function () {


                $(function () {

                    $("#accordion").accordion({
                        header: "h3", collapsible: true, autoHeight: false, autoWidth: false
                    });

                    $("#accordion span").click(function (event) {
                        event.stopImmediatePropagation();
                        event.preventDefault();
                    });
                });

            });
        }
    </script>
