<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeliveryNo_ListShow.ascx.cs" Inherits="ePrint.usercontrol.StoreSettings.DeliveryNo_ListShow" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<telerik:RadScriptManager ID="rdmanager" runat="server">
</telerik:RadScriptManager>--%>
<telerik:RadAjaxManager ID="RAM_Attch" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadGrid_Customer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid_Customer" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" SkinID="Windows7">
</telerik:RadAjaxLoadingPanel>
<%--<div class="navigatorpanel">
    <div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" style="float: left;" nowrap="nowrap">
                        <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel" Text="Customer Name"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="onlyempty">
    </div>
</div>--%>
<div >  <%--class="borderwithouttop"--%>
    <div id="padding">
        <div align="left" id="Div_customer" runat="server" style="width: 100%; height: auto;"
            visible="true">
            <asp:UpdatePanel ID="update" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <telerik:RadGrid ID="RadGrid_Customer" runat="server" ShowHeader="true" Width="100%"
                        AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" ShowStatusBar="true"
                        AllowSorting="true" PagerStyle-AlwaysVisible="true" AllowFilteringByColumn="true"
                        Visible="true" EnableEmbeddedBaseStylesheet="true" EnableEmbeddedSkins="true"
                        ItemStyle-Height="15px" EnableEmbeddedScripts="true" EnableTheming="true" AllowPaging="true"
                        PageSize="50" GridLines="None" OnItemDataBound="RadGrid_Customer_OnItemDataBound">
                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                        <MasterTableView AllowFilteringByColumn="true" OverrideDataSourceControlSorting="true">
                            <Columns>
                                <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="Delivery Note No." HeaderStyle-Width="45%"
                                    ItemStyle-Width="50%" CurrentFilterFunction="Contains" DataField="DeliveryNumber"
                                    SortExpression="DeliveryNumber" UniqueName="DeliveryNumber" FilterControlWidth="18%" AutoPostBackOnFilter="true">
                                    <ItemTemplate>
                                        <div style="float: left; width: 98%; padding-left: 10px; max-height: 18px; height: 18px;">
                                            <asp:HyperLink ID="lblDeliveryNo" runat="server" Text='<%# Eval("DeliveryNumber") %>' OnClick='<%# "javascript:lblDeliveryNo_Click(\"" + DataBinder.Eval(Container.DataItem, "DeliveryID") + "\");" %>'></asp:HyperLink>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        
                         <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                            AllowDragToGroup="false" Scrolling-AllowScroll="true">
                            <Scrolling UseStaticHeaders="true" ScrollHeight="160" />
                        </ClientSettings>
                        
                    </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
 <script type="text/javascript" language="javascript">
     function lblDeliveryNo_Click(ID) {
         debugger

         window.open("<%=nmsCommon.global.sitePath()%>Delivery/delivery_add.aspx?type=edit&id=" + ID, '_blank');
     }
    </script>