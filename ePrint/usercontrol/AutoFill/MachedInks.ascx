<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachedInks.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MachedInks" %>
 
 <asp:Panel runat="server" ID="pnlLocation">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 250px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden; position:fixed">
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu">
            <ul class="categoryitems">
                <asp:Repeater runat="server" ID="uc">
                    <ItemTemplate>
                        <li><a href="#" onclick="BindResultInks('<%#Eval("InventoryID")%>','<%#Eval("InventoryCode")%>','<%#Eval("InventoryName")%>','<%#Eval("InkInventoryName")%>');">
                            <%#Eval("InkInventoryName")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>
