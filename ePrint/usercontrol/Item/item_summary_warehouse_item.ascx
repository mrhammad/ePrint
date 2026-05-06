<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_summary_warehouse_item.ascx.cs" Inherits="ePrint.usercontrol.Item.item_summary_warehouse_item" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table id="tblWarehouseItem" width="97%" cellpadding="0" cellspacing="0" border="0">
    <%--    <tr>
        <td valign="top" align="right">
            <asp:PlaceHolder ID="plhSummaryBtns" runat="server"></asp:PlaceHolder>
        </td>
    </tr>--%>
    <tr id="trQuantity">
        <td>
            <asp:PlaceHolder ID="plhWarehouseItem" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
</table>
<%--<div id="Div_RadSplit" runat="server">
    <telerik:RadButton ID="SplitButton" runat="server" AutoPostBack="false" EnableSplitButton="true"
        Text="Add Sub Item" Skin="Vista" OnClientClicked="OnClientClicked" Visible="false">
    </telerik:RadButton>
    <telerik:RadContextMenu ID="RadContextMenu1" runat="server">
        <Items>
            <telerik:RadMenuItem Text="Sheed Fed Digital">
                <Items>
                    <telerik:RadMenuItem Text="Single Item" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="Pads" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem Text="Sheed Fed Offset">
                <Items>
                    <telerik:RadMenuItem Text="Single Item" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="Pads" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem Text="" Style="cursor: pointer;">
                <Items>
                    <telerik:RadMenuItem Text="" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem Text="Product Catalogue" Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Outwork " Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Other Cost" Style="cursor: pointer;" />
        </Items>
    </telerik:RadContextMenu>
</div>
<div id="Div_AdvancedOptions" runat="server">
    <telerik:RadButton ID="Radbtn_Options" runat="server" AutoPostBack="false" EnableSplitButton="true"
        Text="Action" Skin="Vista" OnClientClicked="OnClientClicked_Option" Visible="false">
    </telerik:RadButton>
    <telerik:RadContextMenu ID="RCM_Options" runat="server">
        <Items>
            <telerik:RadMenuItem Text="Re-Run Item" Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Copy Item" Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Delete Item " Visible="true" Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Edit Job Card" Style="cursor: pointer;" Visible="false" />
        </Items>
    </telerik:RadContextMenu>
</div>--%>
