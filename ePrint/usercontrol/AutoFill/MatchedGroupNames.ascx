<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchedGroupNames.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MatchedGroupNames" %>
<asp:Panel runat="server" ID="pnlLocation" Style="display: block">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 270px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden;">
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu">
            <ul class="categoryitems">
                <asp:Repeater runat="server" ID="uc" OnItemDataBound="Repeater_OnItemDataBound">
                    <ItemTemplate>
                        <asp:Label ID="hdnGroupID" runat="server" Text='<%#Eval("PricatalogueGroupID")%>' Visible="false"></asp:Label>
                        <asp:Label ID="hdnGroupName" runat="server" Text='<%#Eval("GroupName")%>' Visible="false"></asp:Label>
                       
                        <li><a id="GroupName" runat="server" class="AutoFill">
                            <%--onclick="BindResultCustomer('<%#Eval("ClientID")%>','<%#Eval("ClientName")%>','<%#Eval("Contacts")%>','<%#Eval("AccountNumber")%>','<%#Eval("ConcatDelAddress")%>','<%#Eval("DepartmentName")%>','<%#Eval("DepartmentID")%>', '<%#Eval("InvoiceAddressID")%>','<%#Eval("InvoiceAddress")%>','<%#Eval("ContactAddress")%>','<%#Eval("ContactAddressID")%>' );"--%>
                            <%#Eval("GroupName")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>