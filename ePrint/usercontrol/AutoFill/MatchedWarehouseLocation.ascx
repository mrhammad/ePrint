<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchedWarehouseLocation.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MatchedWarehouseLocation" %>

<asp:Panel runat="server" ID="pnlLocation">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 250px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden;">
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu">
            <ul class="categoryitems">
                <asp:Repeater runat="server" ID="uc" OnItemDataBound="Repeater_OnItemDataBound">
                    <ItemTemplate>
                        <asp:Label ID="hdnLocationID" runat="server" Text='<%#Eval("LocationId")%>' Visible="false"></asp:Label>
                        <asp:Label ID="hdnLocationName" runat="server" Text='<%#Eval("LocationName")%>' Visible="false"></asp:Label>
                        <li><a id="LocationName" runat="server" class="AutoFill">
                            <%#Eval("LocationName")%></a>  <%--onclick="BindResultWarehouseLocation('<%#Eval("LocationId")%>','<%#Eval("LocationName")%>');"--%>
                            </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>
