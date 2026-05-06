<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_NCR_item.aspx.cs" Inherits="ePrint.orders.order_NCR_item" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" %>


<%@ Register TagPrefix="UC" TagName="NCRItem" Src="~/usercontrol/Item/NCR_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" style="width: 100%;">
        <UC:NCRItem ID="UCNCRItem" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>