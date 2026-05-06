<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" autoeventwireup="true" CodeBehind="templates_view1.aspx.cs" Inherits="ePrint.Delivery.templates_view1"  enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="templates" TagPrefix="UC" Src="~/usercontrol/templates_view1.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:templates runat="Server" ID="UCtemplate1"></UC:templates>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
