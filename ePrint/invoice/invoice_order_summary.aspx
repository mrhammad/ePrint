<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invoice_order_summary.aspx.cs" Inherits="ePrint.invoice.invoice_order_summary" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" enableviewstatemac="false" enableEventValidation="false" theme="Theme1"  %>

<%@ Register TagName="UcItemSummaryMain" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_main.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:UcItemSummaryMain ID="UCItemSummaryMain" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
   
</asp:Content>