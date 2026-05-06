<%@ page title="eStore Phrasebook " language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="Phrase_Book.aspx.cs" Inherits="ePrint.StoreSettings.Phrase_Book" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="phrasebook" TagPrefix="uc" Src="~/usercontrol/StoreSettings/phrase_book.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/approvalsystem.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <div  style="float:left;" class="estore_settingBox">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <UC:phrasebook ID="ucPhraseBook" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>