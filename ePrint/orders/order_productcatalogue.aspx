<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_productcatalogue.aspx.cs" MasterPageFile="~/Templates/innerMasterPage_withoutPanel.Master" Inherits="ePrint.orders.order_productcatalogue" %>


<%@ Register TagName="ProductCatalogue" TagPrefix="UC" Src="~/usercontrol/Orders/item_product_catalogue.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="navigatorpanel show_hide">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel">
                                <asp:Label runat="server" ID="lblheaderr"></asp:Label></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="content">
       <%-- <div class="borderWithoutTop">--%>
            <div class="onlyEmpty">
            </div>
            <div id="div_price_catalogue" class="div_order_margin">
                <div id="div_price_valid" style="display: none;" align="center">
                    <div align="center" style="width: 50%; padding: 3px;">
                        <span id="span_none" class="spanerrorMsg" style="width: 100%">Please select Price Catalogue</span>
                    </div>
                </div>
                <div align="left" style="padding-top: 5px; width: 95%;">
                    <UC:ProductCatalogue ID="ProductCatalogue" runat="server" />
                    <div class="onlyEmpty">
                        &nbsp;
                    </div>
                </div>
            </div>
            <div class="only5px">
            </div>
        <%--</div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


