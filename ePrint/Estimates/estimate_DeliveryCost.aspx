<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" autoeventwireup="true" CodeBehind="estimate_DeliveryCost.aspx.cs" Inherits="ePrint.Estimates.estimate_DeliveryCost" title="DeliveryCost" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="DeliveryCost" Src="~/usercontrol/Item/DeliveryCost_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:DeliveryCost ID="UcDeliveryCost" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
