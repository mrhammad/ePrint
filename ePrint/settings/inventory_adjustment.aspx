<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="inventory_adjustment.aspx.cs" Inherits="ePrint.settings.inventory_adjustment" title="Settings: Inventory Adjustment" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="InvAdjustment" TagPrefix="UC" Src="~/usercontrol/warehouse/mass_adjustment.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <UC:InvAdjustment ID="InvAdjustmentID" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>