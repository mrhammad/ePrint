<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobsSubSection.ascx.cs" Inherits="ePrint.usercontrol.crm.JobsSubSection" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath %>js/changeStyle.js?VN='<%=VersionNumber%>'"></script>
<asp:LinkButton ID="lnk_ClearFilter_JObrecords" CausesValidation="false" runat="server" OnClick="clrFiltersJobs_Click"></asp:LinkButton>
<div id="div_JobsMain" runat="server" style="border-top: solid 0px silver; display: block;">
    <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid">
        <div style="width: 60%; margin: 5px 0px 0px 5px">
            <asp:UpdatePanel ID="UpdatePanel6" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="PlaceHolder_Jobs" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="div_Jobs" style="padding: 0px 2px 25px 0px; display: block; margin-left: -1px;">
        <telerik:RadGrid ID="RadGrid_Jobs" runat="server" OnNeedDataSource="RadGrid_Jobs_OnNeedDataSource"
            AllowFilteringByColumn="true" OnItemDataBound="RadGridJobs_OnRowDataBound" OnItemCommand="RadGrid_Jobs_ItemCommand"
            AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true"
            GroupingEnabled="false" PageSize="50" Width="100%" ShowGroupPanel="true" ShowStatusBar="true"
            HeaderStyle-Font-Bold="true" GridLines="none" CssClass="AddBorders" EnableEmbeddedSkins="true"
            HeaderStyle-ForeColor="#333333" HeaderStyle-BorderStyle="Double" BorderColor="White"
            FilterItemStyle-HorizontalAlign="Justify" Skin="Default" Style="outline: none;" GroupingSettings-CaseSensitive="false">
            <AlternatingItemStyle BackColor="White" />
            <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" Position="Bottom" />
            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
            <MasterTableView DataKeyNames="EstimateID" OverrideDataSourceControlSorting="true"
                AllowFilteringByColumn="true" CommandItemDisplay="Top" Width="100%">
                <CommandItemTemplate>
                    <%--<table class="rgCommandTable" border="0" style="width: 100%; margin-top: -6px; overflow: visible;">
                        <tr>
                            <td align="left" style="width: 49%;">
                                <b>
                                    <asp:Label ID="lbl_JobsDetails" runat="server" Text=""></asp:Label></b>
                            </td>
                            <td align="right" style="width: 49%;">
                                <div style="margin-right: -8px; overflow: visible; z-index: 55555555;">
                                    <asp:LinkButton ID="btnclrFilters_Jobs" runat="server" Style="text-decoration: underline;
                                        color: #10357F; cursor: pointer" Text="" OnClick="clrFiltersJobs_Click"><%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                </div>
                            </td>
                        </tr>
                    </table>--%>
                    <div style="border-bottom: 1px solid #C9C9C9; margin-top: 0px;">
                    </div>
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridTemplateColumn DataField="JobNumber" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" FilterControlWidth="100" CurrentFilterFunction="Contains"
                        AutoPostBackOnFilter="true" HeaderStyle-Width="20%" HeaderText="" ItemStyle-Width="20%"
                        SortExpression="JobNumber" UniqueName="JobNumber" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);">
                                <div style="float: left; width: 99%; overflow: hidden; height: 19px;">
                                    <asp:Label ID="lbl_EstimateNumber_Jobs" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.JobNumber", "{0}")) %>'
                                        ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.JobNumber", "{0}")) %>'
                                        Width="100%"></asp:Label>
                                    <asp:HiddenField ID="hdn_EstimateID_Jobs" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>' />
                                    <asp:HiddenField ID="hdn_OrderID_Jobs" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.OrderID", "{0}") %>' />
                                    <asp:HiddenField ID="hdn_EstimateType" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Estimatetype", "{0}") %>' />
                                    <asp:HiddenField ID="hdn_JobID_Jobs" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.JobID", "{0}") %>' />
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="JobTitle" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" AllowFiltering="true" FilterControlWidth="100"
                        HeaderStyle-Width="30%" HeaderText="" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                        ItemStyle-Width="30%" SortExpression="JobTitle" UniqueName="JobTitle" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_EstimateTitle_Jobs" Width="100%" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.JobTitle", "{0}")) %>'
                                        ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.JobTitle", "{0}")) %>'></asp:Label>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="ConvertedDate" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" AllowFiltering="true" FilterControlWidth="100"
                        HeaderStyle-Width="20%" HeaderText="" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true"
                        ItemStyle-Width="20%" SortExpression="ConvertedDate" UniqueName="ConvertedDate"
                        Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_EstimateDate_Jobs" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ConvertedDate", "{0}") %>'
                                        runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdn_EstimateDate_Jobs" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.ConvertedDate", "{0}") %>'>
                                    </asp:HiddenField>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="StatusTitle" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" AllowFiltering="true" FilterControlWidth="100"
                        HeaderStyle-Width="20%" HeaderText="" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                        ItemStyle-Width="20%" SortExpression="StatusTitle" UniqueName="StatusTitle" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_StatusTitle_Jobs" Width="100%" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.StatusTitle", "{0}")) %>'
                                        ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.StatusTitle", "{0}")) %>'></asp:Label>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="EstimateValue" HeaderStyle-HorizontalAlign="Right"
                        ItemStyle-HorizontalAlign="Right" AllowFiltering="true" FilterControlWidth="100"
                        HeaderStyle-Width="18%" HeaderText="" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                        ItemStyle-Width="18%" SortExpression="EstimateValue" UniqueName="EstimateValue"
                        Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_EstimateValue_Jobs" Width="100%" runat="server" Style="margin: 0px 2px 0px 0px"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.EstimateValue", "{0}") %>'></asp:Label>
                                    <asp:HiddenField ID="hdn_EstimateValue_Jobs" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EstimateValue", "{0}") %>'>
                                    </asp:HiddenField>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <NoRecordsTemplate>
                    <div style="padding: 0px 0px 0px 10px">
                        <%=objLangClass.GetLanguageConversion("No_Records_Found") %>
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

    function LoadingImageJob() {
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

