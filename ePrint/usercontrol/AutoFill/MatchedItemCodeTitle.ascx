<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchedItemCodeTitle.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MatchedItemCodeTitle" %>

<asp:Panel runat="server" ID="pnlitem">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 250px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden; ">
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu">
            <ul class="categoryitems">
                <asp:Repeater runat="server" ID="uc">
                    <ItemTemplate>
                        <li><a href="#" onclick="BindResultItemCodeTitle('<%#Eval("PriceCatalogueID")%>','<%#Eval("ItemCode")%>','<%# obj.SpecialEncode((string)Eval("ItemTitle"))%>');">
                            <%#Eval("ItemCode")%> - <%# obj.SpecialDecode((string)Eval("ItemTitle"))%> </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>