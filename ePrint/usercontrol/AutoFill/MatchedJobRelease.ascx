<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchedJobRelease.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MatchedJobRelease" %>

<asp:Panel runat="server" ID="pnlitem">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 250px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden; ">
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu">
            <ul class="categoryitems">
                <asp:Repeater runat="server" ID="uc">
                    <ItemTemplate>
                        <li><a href="#" onclick="BindResultProductJobList('<%#Eval("JobId")%>','<%#Eval("estimateid")%>','<%#Eval("JobNumber")%>','<%#Eval("Quantity")%>');">
                            <%#Eval("JobNumber")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>