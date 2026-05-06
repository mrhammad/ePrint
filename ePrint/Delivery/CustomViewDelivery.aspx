<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master"  CodeBehind="CustomViewDelivery.aspx.cs" Inherits="ePrint.Delivery.CustomViewDelivery" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="CustomViewDelivery" TagPrefix="uc" Src="~/usercontrol/Views/CustomViewDelivery.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:CustomViewDelivery runat="server" ID="ucCustomViewDelivery" />
</asp:Content>