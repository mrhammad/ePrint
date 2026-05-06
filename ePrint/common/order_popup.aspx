<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_popup.aspx.cs" MasterPageFile="~/Templates/popUpMasterPage.master" Inherits="ePrint.common.order_popup" %>

<%@ Register Src="~/usercontrol/Orders/order_cost_view.ascx" TagName="orderCostView"
    TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <UC:orderCostView ID="usrCallclass" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
