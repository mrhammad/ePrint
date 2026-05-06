<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Splitdelivery.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.Splitdelivery" %>

<asp:Panel runat="server" ID="pnlLocation" Style="display: block">
    <%-- <div id="divText11" style="float: left; border: solid 1px #868485; width: 270px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden">
        <div style="clear: both">
        </div>
        <div style="overflow:hidden" >
            <ul >
                <asp:Repeater runat="server" ID="uca">
                    <ItemTemplate>
                        <li><a href="#" onclick="Getsplit('<%#Eval("Address")%>')">
                            <%#Eval("Address")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
    
    --%>
   
    <asp:Repeater runat="server" ID="uca">
        <ItemTemplate>
            <li style="color: Red"><a href="#" onclick="Getsplit('<%#Eval("Address")%>')">
                <%#Eval("Address")%></a></li>
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>