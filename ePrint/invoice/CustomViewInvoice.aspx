<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" CodeBehind="CustomViewInvoice.aspx.cs" Inherits="ePrint.invoice.CustomViewInvoice" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register TagName="CustomViewInvoice" TagPrefix="uc" Src="~/usercontrol/Views/CustomViewInvoice.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:CustomViewInvoice runat="server" ID="ucCustomViewInvoice" />
</asp:Content>

