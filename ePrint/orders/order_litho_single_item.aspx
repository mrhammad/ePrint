<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_litho_single_item.aspx.cs" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" Inherits="ePrint.orders.order_litho_single_item" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="LithoSingle" Src="~/usercontrol/Item/litho_single_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:LithoSingle ID="UCLithoSingle" runat="server"></UC:LithoSingle>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
