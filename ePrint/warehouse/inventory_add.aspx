<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true"  CodeBehind="inventory_add.aspx.cs" Inherits="ePrint.warehouse.inventory_add" title="Inventory Form" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Register Src="~/usercontrol/warehouse/inventory_add.ascx" TagName="InventoryAdd"
    TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:InventoryAdd ID="inventoryadd" runat="server" />
</asp:Content>

