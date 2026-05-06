<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="templates_view1.aspx.cs" Inherits="ePrint.Estimates.templates_view1" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" ValidateRequest="false" %>

<%@ Register TagName="templates" TagPrefix="UC" Src="~/usercontrol/templates_view1.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:templates runat="Server" ID="UCtemplate1"></UC:templates>
    
</asp:Content>



