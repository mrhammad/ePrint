<%@ page language="C#" masterpagefile="~/Templates/popUpMasterPage.master" autoeventwireup="true" CodeBehind="common_popup.aspx.cs" Inherits="ePrint.common.common_popup" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/Item/item_reportsList.ascx" TagName="Reports_List"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/jobs/jobcard_edit.ascx" TagName="JobCard_edit" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Item/item_costcenter_ink.ascx" TagName="moreink"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Item/item_stockonly_po.ascx" TagName="stockonly"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/settings/Guillotine_Selector.ascx" TagName="moreplant"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/warehouse/inventory_add.ascx" TagName="Inventory"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Item/address_selector.ascx" TagName="Address" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/contacts_add.ascx" TagName="Contacts" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Item/item_costcenter_view.ascx" TagName="ItemForm"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/warehouse/inventory_store_customer_view.ascx" TagName="Warehouse"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Settings/settings_markup.ascx" TagName="Markup" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/warehouse/inventory_item_selector.ascx" TagName="InvItemSelector"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/purchase/warehouse_list.ascx" TagName="PurWarehouseList"
    TagPrefix="UC" %>
<%--<%@ Register Src="~/usercontrol/Item/attachments.ascx" TagName="Attachments" TagPrefix="UC" %>--%>
<%@ Register Src="~/usercontrol/Item/prof_attachment_selection.ascx" TagName="Attachments" TagPrefix="UC" %>

<%@ Register Src="~/usercontrol/Item/item_usercostcentres.ascx" TagName="OtherCostsTabs"
    TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/CallClass.ascx" TagName="callClass" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <div>
        <UC:callClass ID="usrCallclass" runat="server" />
    </div>
    <div>
        <asp:PlaceHolder ID="plhDiv" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


