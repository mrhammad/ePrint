<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="message_display.ascx.cs" Inherits="ePrint.usercontrol.message_display" %>

    <div align="left" style="width: 20%">
    <div align="left" style="width: 100%">
        <asp:Timer ID="TimerMessage" OnTick="TimerMessage_OnTick" runat="server">
        </asp:Timer>
        <asp:Panel ID="pnlMessage" HorizontalAlign="Left" Width="99%" runat="server">
            <asp:Label ID="lblMessage" runat="server" Style="white-space: nowrap;"></asp:Label>
        </asp:Panel>
        <div>
            <%--<img src="../images/nil.gif" width="20%" height="1px" />--%>
        </div>
    </div>
</div>