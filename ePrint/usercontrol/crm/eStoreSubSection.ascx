<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="eStoreSubSection.ascx.cs" Inherits="ePrint.usercontrol.crm.eStoreSubSection" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath %>js/changeStyle.js?VN='<%=VersionNumber%>'"></script>
<style type="text/css">
    
</style>
<asp:LinkButton ID="lnk_ClearFilter_eStorerecords" CausesValidation="false" runat="server" OnClick="clrFilterseStore_Click"></asp:LinkButton>
<div id="div_eStoreMain" runat="server" style="border-top: solid 0px silver; display: block;">
    <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid">
        <div style="width: 60%; margin: 5px 0px 0px 5px">
            <asp:UpdatePanel ID="UpdatePanel5" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhEstimates" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="div_eStore" style="padding: 0px 2px 25px 0px; display: block; margin-left: -1px;">
        <telerik:RadGrid ID="RadGrid_eStore" runat="server" OnNeedDataSource="RadGrid_eStore_OnNeedDataSource"
            OnItemDataBound="RadGrid_eStore_OnRowDataBound" OnItemCommand="RadGrid_eStore_ItemCommand"
            AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true"
            GroupingEnabled="false" PageSize="50" Width="100%" ShowGroupPanel="true" ShowStatusBar="true"
            HeaderStyle-Font-Bold="true" AllowFilteringByColumn="true" GridLines="none" CssClass="AddBorders"
            EnableEmbeddedSkins="true" HeaderStyle-ForeColor="#333333" HeaderStyle-BorderStyle="Double"
            BorderColor="White" FilterItemStyle-HorizontalAlign="Justify" Skin="Default"
            Style="outline: none;" GroupingSettings-CaseSensitive="false">
            <AlternatingItemStyle BackColor="White" />
            <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" Position="Bottom" />
            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
            <MasterTableView DataKeyNames="OrderNo" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                CommandItemDisplay="Top" Width="100%">
                <CommandItemTemplate>
                    <%--<table class="rgCommandTable" border="0" style="width: 100%; margin-top: -6px; overflow: visible;">
                        <tr>
                            <td align="left" style="width: 49%;">
                                <b>
                                    <asp:Label ID="lbl_eStoreDetails" runat="server" Text=""></asp:Label></b>
                            </td>
                            <td align="right" style="width: 49%;">
                                <div style="margin-right: -8px; overflow: visible; z-index: 55555555;">
                                    <asp:LinkButton ID="btnclrFilters_eStore" runat="server" Style="text-decoration: underline;
                                        color: #10357F; cursor: pointer" Text="" OnClick="clrFilterseStore_Click"><%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                </div>
                            </td>
                        </tr>
                    </table>--%>
                    <div style="border-bottom: 1px solid #C9C9C9; margin-top: 0px;">
                    </div>
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridTemplateColumn DataField="OrderNo" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" FilterControlWidth="100" CurrentFilterFunction="Contains"
                        AutoPostBackOnFilter="true" HeaderStyle-Width="20%" HeaderText="Order Number"
                        ItemStyle-Width="20%" SortExpression="OrderNo" UniqueName="OrderNo" Visible="true"
                        DataType="System.String">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','4','no','<%# DataBinder.Eval(Container, "DataItem.OrderID", "{0}") %>','<%=isView%>');">
                                <div style="float: left; width: 99%; overflow: hidden; height: 19px;">
                                    <asp:Label ID="lbl_EstimateNumber_sStore" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderNo", "{0}")) %>'
                                        ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderNo", "{0}")) %>'></asp:Label>
                                    <asp:HiddenField ID="hdn_EstimateID_eStore" runat="server" Value='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderNo", "{0}")) %>' />
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="OrderTitle" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" AllowFiltering="true" FilterControlWidth="100"
                        HeaderStyle-Width="30%" HeaderText="Order Title" CurrentFilterFunction="Contains"
                        AutoPostBackOnFilter="true" ItemStyle-Width="30%" SortExpression="OrderTitle"
                        UniqueName="OrderTitle" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','4','no','<%# DataBinder.Eval(Container, "DataItem.OrderID", "{0}") %>','<%=isView%>');">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_EstimateTitle_eStore" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderTitle", "{0}")) %>'
                                        ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderTitle", "{0}")) %>'></asp:Label>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="OrderDate" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" AllowFiltering="true" FilterControlWidth="100"
                        HeaderStyle-Width="20%" HeaderText="Order Date" CurrentFilterFunction="Contains"
                        AutoPostBackOnFilter="true" ItemStyle-Width="20%" SortExpression="OrderDate"
                        UniqueName="OrderDate" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','4','no','<%# DataBinder.Eval(Container, "DataItem.OrderID", "{0}")  %>','<%=isView%>');">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_EstimateDate_eStore" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OrderDate", "{0}") %>'></asp:Label>
                                    <asp:HiddenField ID="hdn_EstimateDate_eStore" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.OrderDate", "{0}") %>'>
                                    </asp:HiddenField>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="StatusTitle" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" AllowFiltering="true" FilterControlWidth="100"
                        HeaderStyle-Width="20%" HeaderText="Order Status" CurrentFilterFunction="Contains"
                        AutoPostBackOnFilter="true" ItemStyle-Width="20%" SortExpression="StatusTitle"
                        UniqueName="StatusTitle" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','4','no','<%# DataBinder.Eval(Container, "DataItem.OrderID", "{0}") %>','<%=isView%>');">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_EstimateStatus_eStore" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.StatusTitle", "{0}")) %>'
                                        ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.StatusTitle", "{0}")) %>'></asp:Label>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="OrderValue" HeaderStyle-HorizontalAlign="Right"
                        ItemStyle-HorizontalAlign="Right" AllowFiltering="true" FilterControlWidth="90"
                        HeaderStyle-Width="12%" HeaderText="Order Value" CurrentFilterFunction="EqualTo"
                        AutoPostBackOnFilter="true" ItemStyle-Width="12%" SortExpression="OrderValue"
                        UniqueName="OrderValue" Visible="true" DataType="System.Decimal">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','4','no','<%# DataBinder.Eval(Container, "DataItem.OrderID", "{0}")  %>','<%=isView%>');">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_EstimateValue_eStore" runat="server" Style="margin: 0px 2px 0px 0px"></asp:Label>
                                    <asp:HiddenField ID="hdn_EstimateValue_eStore" runat="server" Value='<%#DataBinder.Eval(Container, "DataItem.OrderValue", "{0}") %>'>
                                    </asp:HiddenField>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <NoRecordsTemplate>
                    <div style="padding: 0px 0px 0px 10px">
                        <%=objLangClass.GetLanguageConversion("No_records_Found") %>
                    </div>
                </NoRecordsTemplate>
            </MasterTableView>
            <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                AllowDragToGroup="false" Scrolling-AllowScroll="true">
                <Selecting AllowRowSelect="True" />
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                <Scrolling UseStaticHeaders="true" ScrollHeight="340" SaveScrollPosition="true" />
                <ClientEvents OnRowMouseOver="RowMouseOver" OnRowMouseOut="RowMouseOut" OnFilterMenuShowing="filterMenuShowing" />
            </ClientSettings>
            <FilterMenu OnClientShown="MenuShowing" />
        </telerik:RadGrid>
    </div>
    <div style="clear: both">
    </div>
</div>
<script type="text/javascript" language="javascript">

    function LoadingImageeStore() {
        parent.window.document.getElementById("DivBigLoadingImg").style.display = "none";
    }
    parent.window.document.getElementById("DivBigLoadingImg").style.display = "none";

    var column = null;
    function MenuShowing(sender, args) {
        if (column == null) return;
        var menu = sender; var items = menu.get_items();
        if (column.get_dataType() == "System.DateTime") {
            var i = 0;
            while (i < items.get_count()) {
                if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'EqualTo': '', 'GreaterThan': '', 'LessThan': '' })) {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(false);
                }
                else {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(true);
                } i++;
            }
        }

        if (column.get_dataType() == "System.String") {
            var i = 0;
            while (i < items.get_count()) {
                if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'Contains': '', 'DoesNotContain': '', 'StartsWith': '', 'EndsWith': '', 'EqualTo': '' })) {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(false);
                }
                else {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(true);
                } i++;
            }
        }

        if (column.get_dataType() == "System.Decimal" || column.get_dataType() == "System.Int32") {
            var i = 0;
            while (i < items.get_count()) {
                if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'EqualTo': '' })) {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(false);
                }
                else {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(true);
                } i++;
            }
        }
        column = null;
        menu.repaint();
    }
    function filterMenuShowing(sender, eventArgs) {
        column = eventArgs.get_column();
    }

</script>
