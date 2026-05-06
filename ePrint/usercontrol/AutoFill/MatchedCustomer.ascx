<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchedCustomer.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MatchedCustomer" %>

<asp:Panel runat="server" ID="pnlLocation" Style="display: block">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 270px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden;">
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
                        <asp:Label ID="hdnDepartmentName" runat="server" Text='<%#Eval("DepartmentName")%>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="hdnDepartmentID" runat="server" Text='<%#Eval("DepartmentID")%>' Visible="false"></asp:Label>
                        <asp:Label ID="hdnInvoiceAddressID" runat="server" Text='<%#Eval("InvoiceAddressID")%>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="hdnInvoiceAddress" runat="server" Text='<%#Eval("InvoiceAddress")%>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="hdnContactAddress" runat="server" Text='<%#Eval("ContactAddress")%>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="hdnContactAddressID" runat="server" Text='<%#Eval("ContactAddressID")%>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="hdnStatusTitle" runat="server" Text='<%#Eval("StatusTitle")%>' Visible="false"></asp:Label>
                        <li><a id="ClientName" runat="server" class="AutoFill">
                            <%--onclick="BindResultCustomer('<%#Eval("ClientID")%>','<%#Eval("ClientName")%>','<%#Eval("Contacts")%>','<%#Eval("AccountNumber")%>','<%#Eval("ConcatDelAddress")%>','<%#Eval("DepartmentName")%>','<%#Eval("DepartmentID")%>', '<%#Eval("InvoiceAddressID")%>','<%#Eval("InvoiceAddress")%>','<%#Eval("ContactAddress")%>','<%#Eval("ContactAddressID")%>' );"--%>
                            <%#Eval("ClientName")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>

