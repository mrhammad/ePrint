<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="CustomViewOrder.aspx.cs" Inherits="ePrint.orders.CustomViewOrder" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="CustomView" TagPrefix="uc" Src="~/usercontrol/Views/CustomViewOrder.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:CustomView runat="server" ID="ucCustomView" />
</asp:Content>
