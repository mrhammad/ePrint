<%@ Control Language="C#" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI.Widgets" TagPrefix="widgets" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI.Dialogs" TagPrefix="dialogs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    Type.registerNamespace("Telerik.Web.UI.Editor.DialogControls");

    Telerik.Web.UI.Editor.DialogControls.FileBrowser = function (element) {
        Telerik.Web.UI.Editor.DialogControls.FileBrowser.initializeBase(this, [element]);
    }

    Telerik.Web.UI.Editor.DialogControls.FileBrowser.prototype = {
        initialize: function () {
            this.set_insertButton($get("InsertButton"));
            this.set_cancelButton($get("CancelButton"));

            var previewer = this.get_previewerType();
            var previewerType = eval("Telerik.Web.UI.Widgets." + previewer);
            $create(previewerType, { "browser": this }, null, null, $get(previewer));
            this.set_filePreviewer($find(previewer));
            this.set_fileBrowser($find("RadFileExplorer1"));

            Telerik.Web.UI.Editor.DialogControls.FileBrowser.callBaseMethod(this, 'initialize');
        },

        dispose: function () {
            Telerik.Web.UI.Editor.DialogControls.FileBrowser.callBaseMethod(this, 'dispose');
            this._insertButton = null;
            this._cancelButton = null;
        }
    }

    Telerik.Web.UI.Editor.DialogControls.FileBrowser.registerClass('Telerik.Web.UI.Editor.DialogControls.FileBrowser', Telerik.Web.UI.Widgets.FileManager);
</script>
<style type="text/css">
    .RadFileExplorer .RadGrid .rgPager .rgWrap
    {
        float: none;
    }
    .RadFileExplorer .RadGrid .rgPager .RadSlider
    {
        float: none;
    }
    .RadFileExplorer .RadGrid .rgPager .rgSliderLabel
    {
        float: left;
    }
    .RadFileExplorer .RadGrid .rgPager .rgInfoPart
    {
        text-align: right;
    }
</style>
<style type="text/css">
     /* added by Naveen*/
    #RadWindowWrapper_RadFileExplorer1_windowManagerfileExplorerUpload
    {
        width: 460px !important;
    }
    #RadFileExplorer1_uploadContainer .rfeUploadContainer
    {
        height: 350px !important;
        margin: 0 0 0 2px !important;
        overflow-y: auto;
        overflow-x: hidden !important;
    }
    .RadFileExplorer .RadGrid .rgPager .rgWrap
    {
        float: none;
    }
    .RadFileExplorer .RadGrid .rgPager .RadSlider
    {
        float: none;
    }
    .RadFileExplorer .RadGrid .rgPager .rgSliderLabel
    {
        float: left;
    }
    .RadFileExplorer .RadGrid .rgPager .rgInfoPart
    {
        text-align: right;
    }
    /* added by ramakrishna*/
    .RadForm.rfdTextbox input.rfeAddressBox[type="text"]
    {
        padding: 0;
        visibility: hidden;
        display: none;
    }
    .RadSplitter .rspPane, .RadSplitter .rspPaneHorizontal
    {
        padding: 0;
        height: 422px;
    }
    .RadGrid_Default td.rgPagerCell
    {
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        -moz-border-right-colors: none;
        -moz-border-top-colors: none;
        border-color: #828282 #EEEEEE #EEEEEE;
        border-image: none;
        border-style: solid;
        border-width: 1px 0 1px 1px;
        display: none;
    }
    .Default.RadEditor .reContentCell
    {
        border: 1px solid #DADADA;
    }
    
    .button
    {
        display: inline-block;
        outline: none;
        cursor: pointer;
        text-align: center;
        text-decoration: none;
        font: 11px "Verdana" , Verdana, Arial, Helvetica, sans-serif;
        padding-left: 8px;
        padding-top: 3px;
        padding-bottom: 5px;
        padding-right: 8px;
        text-shadow: 0 1px 1px rgba(0,0,0,.3);
        -webkit-border-radius: .5em;
        -moz-border-radius: .5em;
        border-radius: .5em;
        -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);
        -moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
        box-shadow: 0 1px 2px rgba(0,0,0,.2);
        color: #2C2B2B;
        border: solid 1px #a3a3a3;
        background: #EEEEEE;
        background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));
        background: -moz-linear-gradient(top,  #E8E8E8,  #F9F8F8);
        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#E8E8E8', endColorstr='#F9F8F8');
    }
    .button:hover
    {
        text-decoration: none;
        background: #C9C9C9;
        border: 1px #3C7FB1 solid;
        background: -webkit-gradient(linear, left top, left bottom, from(#A7D9F5), to(#EAF6FD));
        background: -moz-linear-gradient(top,  #A7D9F5,  #EAF6FD);
        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#A7D9F5', endColorstr='#EAF6FD');
    }
</style>
<table class="reDialog ManagerDialog NoMarginDialog" border="0" cellpadding="0" cellspacing="0"
    style="width: 100%;">
    <tr id="listRow">
        <td rowspan="2" class="FileExplorerPlaceholder">
            <telerik:RadFileExplorer ID="RadFileExplorer1" Height="450px" Width="400px" TreePaneWidth="150px"
                runat="Server" EnableOpenFile="false" AllowPaging="false" PageSize="200" />
        </td>
        <td rowspan="2" class="DialogSeparator">
            &nbsp;
        </td>
        <td style="width: 100%; vertical-align: top; padding: 0; height: 412px;">
            <asp:PlaceHolder ID="PreviewerPlaceHolder" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="reBottomcell" style="display: none;">
            <table border="0" cellpadding="0" cellspacing="0" class="reConfirmCancelButtonsTbl">
                <tr>
                    <td>
                        <button type="button" class="button" id="InsertButton">
                            <script type="text/javascript">                                setInnerHtml("InsertButton", localization["Insert"]);</script>
                        </button>
                    </td>
                    <td class="reRightMostCell">
                        <button type="button" class="button" id="CancelButton">
                            <script type="text/javascript">                                setInnerHtml("CancelButton", localization["Cancel"]);</script>
                        </button>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

