<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_large_item.aspx.cs" Inherits="ePrint.orders.order_large_item" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" enableviewstatemac="false" enableEventValidation="false" theme="Theme1"  %>

<%@ Register TagPrefix="UC" TagName="LargeItem" Src="~/usercontrol/Item/large_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:LargeItem ID="UcLargeItem" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>