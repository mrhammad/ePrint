<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" CodeBehind="CustomViewJob.aspx.cs" Inherits="ePrint.Jobs.CustomViewJob" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="CustomViewJob" TagPrefix="uc" Src="~/usercontrol/Views/CustomViewJob.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:CustomViewJob runat="server" ID="ucCustomViewJob" />
</asp:Content>
