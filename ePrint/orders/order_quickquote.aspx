<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_quickquote.aspx.cs" Inherits="ePrint.orders.order_quickquote" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="quickquote" Src="~/usercontrol/Item/qucikquote_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:quickquote ID="Ucquickquote" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>