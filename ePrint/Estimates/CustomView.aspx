<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="CustomView.aspx.cs" Inherits="ePrint.Estimates.CustomView" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="CustomView" TagPrefix="uc" Src="~/usercontrol/Views/CustomView.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:CustomView runat="server" ID="ucCustomView" />
</asp:Content>