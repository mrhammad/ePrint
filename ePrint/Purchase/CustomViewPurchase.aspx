<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" CodeBehind="CustomViewPurchase.aspx.cs" Inherits="ePrint.Purchase.CustomViewPurchase" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="CustomViewPurchase" TagPrefix="uc" Src="~/usercontrol/Views/CustomViewPurchase.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:CustomViewPurchase runat="server" ID="ucCustomViewPurchase" />
</asp:Content>
