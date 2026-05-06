<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" CodeBehind="estimate_pad_item.aspx.cs" Inherits="ePrint.Estimates.estimate_pad_item" autoeventwireup="true" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="PadItem" Src="~/usercontrol/Item/pad_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" style="width: 100%;">
        <UC:PadItem ID="UCPadItem" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
