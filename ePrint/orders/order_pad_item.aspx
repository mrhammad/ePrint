<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" CodeBehind="order_pad_item.aspx.cs" Inherits="ePrint.orders.order_pad_item" theme="Theme1" enableviewstatemac="false" enableEventValidation="false" %>

<%@ Register TagPrefix="UC" TagName="PadItem" Src="~/usercontrol/Item/pad_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" style="width: 100%;">
        <UC:PadItem ID="UCPadItem" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

