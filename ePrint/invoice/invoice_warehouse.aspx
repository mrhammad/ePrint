<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" autoeventwireup="true" Inherits="ePrint.invoice.invoice_warehouse" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ register tagprefix="UCWare" tagname="Warehouse" src="~/usercontrol/Item/warehouse_listNew.ascx" %>
    <div id="divMainContent" style="padding: 4">
       <%-- <div class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" nowrap="nowrap">
                                <span class="navigatorpanel" id="lblheader">Create Item: Warehouse Item</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
        <div id="content" class="div_spacing3">
           <%-- <div class="borderWithoutTop">--%>
                <div class="onlyEmpty">
                </div>
                <div id="div_stock_only" align="left" style="width: 100%;">
                    <asp:PlaceHolder ID="plhWareshouse" runat="server"></asp:PlaceHolder>
                    <UCWare:Warehouse ID="UCWare" runat="server" />
                    <div class="only5px">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            <%--</div>--%>
        </div>
    </div>
    <div align="left" id="div_ware_edit" class="CenterDiv" style="float: left; position: absolute;
        display: none; height: 100px; width: 440px; padding: 0px; left: 35%; top: 35%;">
        <div class="onlyEmpty">
        </div>
        <div class="removeTrancy">
            <div align="center" class="bgcustomize" style="width: 100%; padding: 3px 0px 3px 0px;">
                <div style="float: left; width: 95%; border: 0px solid">
                    <span class="navigatorpanel" style="vertical-align: middle">Quantity</span></div>
                <div style="float: right; border: 0px solid">
                    <a href="#" onclick="javascript:ShowWarehouseEdit('close');return false;">
                        <img src="<%=strImagepath%>close1.jpg" border="0" width="11px" height="11px" title="Close" /></a></div>
                <div style="clear: both">
                </div>
            </div>
            <div align="left" class="CenterDivTopBorder">
                <div class="only5px">
                </div>
                <div style="width: 100%; padding-left: 3px;">
                    <div class="bglabel">
                        <asp:Label ID="Label30" runat="server" Text="Quantity Required"></asp:Label>
                    </div>
                    <div class="box">
                        <input id="txtWareQty" type="text" class="textboxnew" onblur="AllowNumber(this,this.value);"
                            maxlength="8" style="width: 150px;" onfocus="this.select();" onclick="this.select();" />
                        <span id="Span1" class="spanerrorMsg" style="width: 175px; display: none;">Please enter
                            Quantity</span> <span id="Span2" class="spanerrorMsg" style="width: 175px; display: none;">
                                Please enter numeric value</span>
                    </div>
                </div>
                <div class="only5px">
                </div>
                <div align="left">
                    <div class="bglabelEmpty">
                        &nbsp;</div>
                    <div style="float: left;">
                        <asp:Button ID="Button17" CssClass="button" Text="Add" Width="65px" runat="server"
                            OnClientClick="javascript:ShowWarehouseEdit('update');return false;" />
                        <input type="hidden" value="" />
                    </div>
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

