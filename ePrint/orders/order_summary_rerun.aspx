<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_summary_rerun.aspx.cs" Inherits="ePrint.orders.order_summary_rerun" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="orderrerun" Src="~/usercontrol/Orders/order_rerun.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<UC:orderrerun ID="orderrerun" runat="server"  BaseSection="estimate"></UC:orderrerun>
</asp:Content>
