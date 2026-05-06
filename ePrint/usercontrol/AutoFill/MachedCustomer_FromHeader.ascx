<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachedCustomer_FromHeader.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MachedCustomer_FromHeader" %>
<asp:Panel ID="pnlLocationBindCustomers_FromHeader" runat="server" style="display:block">
    <div id="divText_FromHeader" style="float: left; border: solid 1px #868485; width: 270px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden;">
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu">
            <ul class="categoryitems">
                <asp:Repeater runat="server" ID="Repeater_FromHeader" OnItemDataBound="Repeater_FromHeader_ItemDataBound">
                    <ItemTemplate>
                        <asp:Label ID="Repeater_hdnClientID_FromHeader" runat="server" Text='<%#Eval("ClientID")%>' Visible="false"></asp:Label>
                        <asp:Label ID="Repeater_hdnClientNam_FromHeadere" runat="server" Text='<%#Eval("ClientName")%>' Visible="false"></asp:Label>
                        <asp:Label ID="Repeater_hdnContacts_FromHeader" runat="server" Text='<%#Eval("Contacts")%>' Visible="false"></asp:Label>
                        <li><a id="Repeater_ClientName_FromHeader" runat="server" class="AutoFill">
                            <%#Eval("ClientName")%></a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>