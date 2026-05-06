<%@ Page Title="" Language="C#" MasterPageFile="~/innerMasterPage_withoutLeftTD.Master" AutoEventWireup="true" CodeBehind="estimate_item_quickquote.aspx.cs" Inherits="ePrint.Estimates.estimate_item_quickquote" %>
 <%@ Register TagPrefix="UC" TagName="quickquote" Src="~/usercontrol/Item/quickquote_items_subitem.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:quickquote ID="Ucquickquote" runat="server" />
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>--%>
