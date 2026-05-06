<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_single_item.aspx.cs" Inherits="ePrint.orders.order_single_item" MasterPageFile="~/Templates/innerMasterPage_withoutPanel.master" EnableEventValidation="false"  %>

<%@ Register TagPrefix="UC" TagName="SingleItem" Src="~/usercontrol/Item/single_item.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" style="width: 100%;">
        <UC:SingleItem ID="UCSingleItem" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>