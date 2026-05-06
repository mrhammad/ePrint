<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="customviewinv.aspx.cs" Inherits="ePrint.warehouse.customviewinv" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="CustomViewInv" TagPrefix="uc" Src="~/usercontrol/Views/CustomViewInv.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:CustomViewInv runat="server" ID="ucCustomViewInv" />
</asp:Content>