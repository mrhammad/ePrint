<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master"  CodeBehind="templates_view1.aspx.cs" Inherits="ePrint.Proofs.templates_view1" %>

<%--<%@ Register TagName="templates" TagPrefix="UC" Src="~/usercontrol/templates_view1.ascx" %>--%>
<%@ Register TagName="templates" TagPrefix="UC" Src="~/usercontrol/Item/Proof_Template.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:templates runat="Server" ID="UCtemplate1"></UC:templates>
    
</asp:Content>
