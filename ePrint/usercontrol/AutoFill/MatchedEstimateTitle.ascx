<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchedEstimateTitle.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MatchedEstimateTitle" %>


<asp:Panel runat="server" ID="pnlEstimateTitle">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 180px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden; ">
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu">
            <ul class="categoryitems">
                <asp:Repeater runat="server" ID="uc">
                    <ItemTemplate>
                        <li><a href="#" onclick="BindResultEstimateTitle('<%#Eval("PhraseBookID")%>','<%# obj.SpecialEncode((string)Eval("PhraseText"))%>');">
                            <%#Eval("PhraseText")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>
