<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Common_inventory_popup.aspx.cs" Inherits="ePrint.common.Common_inventory_popup" masterpagefile="~/Templates/popUpMasterPage.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/warehouse/Inventory_popup.ascx" TagName="InvItem"
    TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitePath%>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <div>
        <asp:PlaceHolder ID="plhDiv" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
