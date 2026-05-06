<%@ page title="Print Management Software : Estimate Summary"  language="C#" CodeBehind="estimate_summary_reeng.aspx.cs" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" Inherits="ePrint.Estimates.estimate_summary_reeng" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="UcItemSummaryMain" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_main.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:UcItemSummaryMain ID="UCItemSummaryMain" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
