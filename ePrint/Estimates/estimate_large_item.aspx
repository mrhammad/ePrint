<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" CodeBehind="estimate_large_item.aspx.cs" autoeventwireup="true" Inherits="ePrint.Estimates.estimate_large_item" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="LargeItem" Src="~/usercontrol/Item/large_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:LargeItem ID="UcLargeItem" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>