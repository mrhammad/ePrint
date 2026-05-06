
<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" autoeventwireup="true" CodeBehind="job_DeliveryCost.aspx.cs" Inherits="ePrint.Jobs.job_DeliveryCost" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="DeliveryCost" Src="~/usercontrol/Item/DeliveryCost_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<UC:DeliveryCost ID="UcDeliveryCost" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
