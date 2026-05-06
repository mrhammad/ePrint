<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" CodeBehind="order_litho_booklet_item.aspx.cs" Inherits="ePrint.orders.order_litho_booklet_item"  enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="booklet" Src="~/usercontrol/Item/litho_booklet_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:booklet ID="UcBooklet" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
