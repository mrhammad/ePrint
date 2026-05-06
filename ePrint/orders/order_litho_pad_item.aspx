<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_litho_pad_item.aspx.cs" Inherits="ePrint.orders.order_litho_pad_item" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="PadItem" Src="~/usercontrol/Item/litho_pad_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" style="width: 100%;">
        <UC:PadItem ID="UCPadItem" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
