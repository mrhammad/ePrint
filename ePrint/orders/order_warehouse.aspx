<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_warehouse.aspx.cs" Inherits="ePrint.orders.order_warehouse" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" title="Add Estimate" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UCWare" TagName="Warehouse" Src="~/usercontrol/Item/warehouse_listNew.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divMainContent" style="padding: 4">
        <div id="content">
            <div id="div_stock_only" align="left" style="width: 100%;">
                <asp:PlaceHolder ID="plhWareshouse" runat="server"></asp:PlaceHolder>
                <UCWare:Warehouse ID="UCWare" runat="server" />
                <div class="only5px">
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
        </div>
    </div>
    <div id="div_ware_edit" style="display: none; position: absolute; z-index: 1000;
        width: 40%" align="center">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="2" class="popup-top-leftcorner">
                    &nbsp;
                </td>
                <td class="popup-top-middlebg">
                    <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                        padding-left: 1px">
                        <b>Quantity</b>
                        <asp:Label ID="Label1" runat="server"></asp:Label></div>
                    <div style="float: right; padding-top: 6px; padding-right: 10px">
                        <div class="CancelButtonDiv">
                            <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                runat="server" CausesValidation="false" OnClientClick="ShowWarehouseEdit('close');return false;" />
                        </div>
                    </div>
                </td>
                <td colspan="2" class="popup-top-rightcorner">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="popup-middle-leftcorner">
                    &nbsp;
                </td>
                <td style="width: 15px; background-color: #ffffff">
                    &nbsp;
                </td>
                <td class="popup-middlebg" align="center">
                    <div style="padding: 10px 5px 10px 0px; width: 98%">
                        <div class="" style="width: 100%">
                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                <tr>
                                    <td valign="top">
                                        <div style="width: 100%; padding-left: 3px;">
                                            <div class="bglabel">
                                                <asp:Label ID="Label30" runat="server" Text="Quantity Required"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <input id="txtWareQty" type="text" class="textboxnew" onblur="AllowNumber(this,this.value);"
                                                    onfocus="this.select();" onclick="this.select();" maxlength="8" style="width: 150px;" />
                                                <span id="Span1" class="spanerrorMsg" style="width: 175px; display: none;">Please enter
                                                    Quantity</span> <span id="Span2" class="spanerrorMsg" style="width: 175px; display: none;">
                                                        Please enter numeric value</span>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="float: right; padding-right: 90px;">
                                            <asp:Button ID="Button17" CssClass="button" Text="Add" Width="65px" runat="server"
                                                OnClientClick="javascript:ShowWarehouseEdit('update');return false;" />
                                            <input type="hidden" value="" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
                <td style="width: 10px; background-color: #ffffff">
                    &nbsp;
                </td>
                <td align="right" class="popup-middle-rightcorner">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" class="popup-bottom-leftcorner">
                    &nbsp;
                </td>
                <td class="popup-bottom-middlebg">
                    &nbsp;
                </td>
                <td colspan="2" class="popup-bottom-rightcorner">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
