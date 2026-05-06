<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" CodeBehind="CustomViewCRM.aspx.cs" Inherits="ePrint.client.CustomViewCRM" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="CustomViewCRM" TagPrefix="uc" Src="~/usercontrol/Views/CustomViewCRM.ascx" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <uc:CustomViewCRM runat="server" ID="ucCustomViewCRM" />
</asp:content>

