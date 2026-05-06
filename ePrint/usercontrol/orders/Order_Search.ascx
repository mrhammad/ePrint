<%@ control language="C#" autoeventwireup="true" CodeBehind="Order_Search.ascx.cs" Inherits="ePrint.usercontrol.orders.Order_Search" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<telerik:RadAjaxManagerProxy ID="RADMgrOrder" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grvOrderSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvOrderSearch" LoadingPanelID="RadAjaxLoadingPanelOrder" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvOrderSearch" LoadingPanelID="RadAjaxLoadingPanelOrder" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvOrderSearch" LoadingPanelID="RadAjaxLoadingPanelOrder" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanelOrder" SkinID="Windows7" runat="server" />
<div id="ds00" style="display: none;">
</div>
<script>
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
</script>
<div id="divContentOrder" class="panelContentOrder" runat="server">
    <div>
        <div id="padding">
            <div>
                <div style="float: left; padding-left: 5px">
                    <asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline; cursor: pointer;
                        display: none" runat="server" Text="Clear all Filters" />
                </div>
                <div style="border: 0px solid red; float: right; display: none">
                    <div style="float: left">
                        <span class="HeaderText" style="color: #787878">Current View:</span>
                    </div>
                    <div class="Only5pxWidth">
                        &nbsp;</div>
                    <div id="div_lblView" style="float: left; display: block">
                        <asp:Label ID="lblView" runat="server"></asp:Label>
                    </div>
                    <div class="Only5pxWidth">
                        &nbsp;</div>
                    <div style="float: left">
                        <a id="spn_change" style="text-decoration: underline; cursor: pointer">Change</a>
                    </div>
                    <div class="Only5pxWidth">
                        &nbsp;</div>
                </div>
            </div>
            <div align="left" style="width: 100%; margin-left: -11px; margin-top: -8px;">
                <div style="width: 100%;">
                    <asp:HiddenField ID="hdnAlphabet" runat="server" />
                    <div align="left" style="padding-top: 5px; width: 100%;">
                        <div id="div_Main" runat="server">
                            <div id="div_Grid">
                                <telerik:RadGrid ID="grvOrderSearch" AllowSorting="true" OnItemDataBound="OnRowDataBound_grvOrderSearch"
                                    ShowGroupPanel="true" AllowFilteringByColumn="false" ShowStatusBar="true" runat="server"
                                    AutoGenerateColumns="false" AllowPaging="true" OnColumnCreated="grvOrderSearch_ColumnCreated"
                                    OnNeedDataSource="grvOrderSearch_NeedDataSource" GroupingEnabled="false" OnSortCommand="grvOrderSearch_SortCommand"
                                    OnItemCommand="grvOrderSearch_ItemCommand" Skin="RadGrid_Eprint_Skin" AllowCustomPaging="true"
                                    EnableEmbeddedSkins="false" Width="100.5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="false"
                                    FilterItemStyle-Wrap="true" CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                    OnItemCreated="grvOrderSearch_ItemCreated">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <HeaderStyle Width="120px" />
                                    <MasterTableView OverrideDataSourceControlSorting="true">
                                        <Columns>
                                            <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                            <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="left">
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;</div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:PlaceHolder ID="plh_attach" runat="server"></asp:PlaceHolder>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" AllowFiltering="false"
                                                ItemStyle-Wrap="false">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;</div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="margin-left: -10px;">
                                                        <asp:PlaceHolder ID="plhConvertJob" runat="server"></asp:PlaceHolder>
                                                    </div>                                                   
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" AllowFiltering="false"
                                                ItemStyle-Wrap="false">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;</div>
                                                </HeaderTemplate>
                                                <ItemTemplate>                                                   
                                                    <div style="margin-left: -10px;">
                                                        <asp:PlaceHolder ID="plh_customerstatus" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </div>
                        <asp:HiddenField runat="server" ID="hdnOrderID" Value="0" />
                    </div>
                    <div style="clear: both">
                        &nbsp;</div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
        <asp:HiddenField ID="hdnOrderIds" runat="server" Value="0" />
    </div>
</div>
<script>
    document.getElementById("ds00").style.display = "none";
</script>
