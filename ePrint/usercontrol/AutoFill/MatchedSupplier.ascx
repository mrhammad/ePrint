<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchedSupplier.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MatchedSupplier" %>

<asp:Panel runat="server" ID="pnlLocation">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 400px; height: 165px;
        background-color: #EEEEEE;">
        <div style="float: left; border-bottom: 1px solid #DADADA; width: 100%">
            <ul>
                <table width="90%" style="table-layout: fixed">
                    <tr>
                        <td align="left" style="width: 24%; font-size: 10.5; font-weight: bold">
                            <asp:Label ID="lblsupplierheader" Style="margin-left: -20px"><%=objLanguage.GetLanguageConversion("Supplier")%> </asp:Label>
                        </td>
                        <td align="left" style="width: 24%; font-size: 10.5px; font-weight: bold">
                            <asp:Label ID="lbltypeheader" Style="margin-left: -20px"><%=objLanguage.GetLanguageConversion("Type")%></asp:Label>
                        </td>
                    </tr>
                </table>
            </ul>
        </div>
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu" style="float: left; overflow-y: scroll; overflow-x: hidden;
            height: 144px; width: 400px; background-color: White;">
            <ul>
                <asp:Repeater runat="server" ID="uc" OnItemDataBound="Repeater_OnItemDataBound">
                    <ItemTemplate>
                        <asp:Label ID="hdnClientID" runat="server" Width="0px" Height="0px" Text='<%#Eval("ClientID")%>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="hdnClientName" runat="server" Width="0px" Height="0px" Text='<%#Eval("ClientName")%>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="hdnContacts" runat="server" Width="0px" Height="0px" Text='<%#Eval("Contacts")%>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="hdnAccountNo" runat="server" Width="0px" Height="0px" Text='<%#Eval("AccountNumber")%>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="hdnContactDelAddress" Width="0px" Height="0px" runat="server" Text='<%#Eval("ConcatDelAddress")%>'
                            Visible="false"></asp:Label>
                        <li><a id="ClientName" runat="server" style="color: #10357F">
                            <table width="100%" style="table-layout: fixed; cursor: pointer">
                                <tr>
                                    <td align="left" class="AutoFill" style="width: 20%;">
                                        <%#Eval("ClientName")%>
                                    </td>
                                    <td align="left" class="AutoFill" style="width: 25%; color: #10357F;">
                                        <%#Eval("ClientType")%>
                                    </td>
                                </tr>
                            </table>
                        </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>
<%--<asp:Panel runat="server" ID="pnlLocation">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 270px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden; position: absolute">
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu">
            <ul class="categoryitems">
                <asp:Repeater runat="server" ID="uc" OnItemDataBound="Repeater_OnItemDataBound">
                    <ItemTemplate>
                        <asp:Label ID="hdnClientID" runat="server" Text='<%#Eval("ClientID")%>' Visible="false"></asp:Label>
                        <asp:Label ID="hdnClientName" runat="server" Text='<%#Eval("ClientName")%>' Visible="false"></asp:Label>
                        <asp:Label ID="hdnContacts" runat="server" Text='<%#Eval("Contacts")%>' Visible="false"></asp:Label>
                        <asp:Label ID="hdnAccountNo" runat="server" Text='<%#Eval("AccountNumber")%>' Visible="false"></asp:Label>
                        <asp:Label ID="hdnContactDelAddress" runat="server" Text='<%#Eval("ConcatDelAddress")%>'
                            Visible="false"></asp:Label>
                        <li><a id="ClientName" runat="server" class="AutoFill">
                            <%#Eval("ClientName")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>--%>

