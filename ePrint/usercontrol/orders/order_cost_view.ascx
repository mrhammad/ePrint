<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="order_cost_view.ascx.cs" Inherits="ePrint.usercontrol.orders.order_cost_view" %>
<div align="left" style="width: 100%;" id="div_Complete">
    <div align="left">
        <%--<div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblCostViewTitle" runat="server">Item Cost View</asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
        <div >  <%--class="divBorderItem"--%>
            <div align="left" style="width: 100%;">
                <div align="left">
                    <div align="left" style="border: 1px solid white; padding-left: 10px;">
                        <asp:PlaceHolder ID="plhItemCostView" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>