<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachedProductStockCustomField_Select.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MachedProductStockCustomField_Select" %>

<asp:Panel runat="server" ID="pnlLocation">
    <div id="divText" style="float: left; border: solid 1px #868485; width: 200px; height: 150px;
        background-color: White; overflow-y: scroll; overflow-x: hidden;">
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu">
            <ul class="categoryitems">
                <asp:Repeater runat="server" ID="uc">
                    <ItemTemplate>
                        <li><a id="LocationName"  class="AutoFill"  href="#"  onclick="BindResultProductCustomField('<%#Eval("CustomField")%>');" >
                            <%#Eval("CustomField")%></a>  <%--onclick="BindResultWarehouseLocation('<%#Eval("LocationId")%>','<%#Eval("LocationName")%>');"--%>
                            </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>