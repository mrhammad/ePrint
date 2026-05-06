<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="account_left_banner2.ascx.cs" Inherits="ePrint.WebStore.usercontrol.account_left_banner2" %>

<asp:Panel runat="server" ID="pnlaccount" Visible="true">
    <script src="../js/default.js" type="text/javascript"></script>
    <div class="account_leftBanner" id="account_leftBanner" runat="server">
        <asp:PlaceHolder ID="plhLeftBanner" runat="server"></asp:PlaceHolder>
    </div>
    <script type="text/javascript" language="javascript">
        var strSitepath = '<%=strSitepath %>';
    </script>
</asp:Panel>
