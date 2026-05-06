<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EstimateSubSection.ascx.cs" Inherits="ePrint.usercontrol.crm.EstimateSubSection" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath %>js/changeStyle.js?VN='<%=VersionNumber%>'"></script> 
<asp:LinkButton ID="lnk_ClearFilter_Estimate" runat="server" CausesValidation="false" OnClick="clrFiltersEstimates_Click"></asp:LinkButton>
<div id="div_EstimateMain" runat="server" style="border-top: solid 0px silver; display: block;">
    <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid">
        <div style="width: 60%; margin: 5px 0px 0px 5px">
            <asp:UpdatePanel ID="UpdatePanel5" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhEstimates" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="div_Estimates" style="padding: 0px 2px 25px 0px; display: block; margin-left: -1px;
        margin-top: -10px;">
        <telerik:RadGrid ID="RadGrid_Estimates" runat="server" OnNeedDataSource="RadGrid_Estimates_OnNeedDataSource"
            OnItemDataBound="RadGridEstimates_OnRowDataBound" OnItemCommand="RadGrid_Estimates_ItemCommand"
            AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true"
            GroupingEnabled="false" PageSize="50" Width="100%" ShowGroupPanel="true" ShowStatusBar="true"
            HeaderStyle-Font-Bold="true" AllowFilteringByColumn="true" GridLines="none" CssClass="AddBorders"
            EnableEmbeddedSkins="true" HeaderStyle-ForeColor="#333333" HeaderStyle-BorderStyle="Double"
            BorderColor="White" FilterItemStyle-HorizontalAlign="Justify" Skin="Default"
            Style="outline: none;" GroupingSettings-CaseSensitive="false">
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
                                    <asp:Label ID="lbl_EstimateDetails" runat="server" Text=""></asp:Label></b>
                            </td>
                         <td align="right" style="width: 49%;">
                                <div style="margin-right: -8px; overflow: visible; z-index: 55555555;">                                    
                                        <asp:Button ID="btnclrFilters_Estimates" runat="server" Text="Clear all filters" OnClick="clrFiltersEstimates_Click" CssClass="headerbutton white" />
                                </div>
                            </td>
                        </tr>
                    </table>--%>
                    <div style="border-bottom: 1px solid #C9C9C9; margin-top: 0px;">
                    </div>
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridTemplateColumn DataField="EstimateNumber" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" FilterControlWidth="100" CurrentFilterFunction="Contains"
                        AutoPostBackOnFilter="true" HeaderStyle-Width="15%" HeaderText="" ItemStyle-Width="15%"
                        SortExpression="EstimateNumber" UniqueName="EstimateNumber" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','1','','','<%=isView%>'); return false">
                                <div style="float: left; width: 99%; overflow: hidden; height: 19px;">
                                    <asp:Label ID="lbl_EstimateNumber_Estimates" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.EstimateNumber", "{0}")) %>'
                                        ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.EstimateNumber", "{0}")) %>'></asp:Label>
                                    <asp:HiddenField ID="hdn_EstimateID_Estimates" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>' />
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="EstimateTitle" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" AllowFiltering="true" FilterControlWidth="100"
                        HeaderStyle-Width="25%" HeaderText="" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                        ItemStyle-Width="25%" SortExpression="EstimateTitle" UniqueName="EstimateTitle"
                        Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','1','','','<%=isView%>'); return false">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px; margin-left: 2px;">
                                    <asp:Label ID="lbl_EstimateTitle_Estimates" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.EstimateTitle", "{0}")) %>'
                                        ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.EstimateTitle", "{0}")) %>'></asp:Label>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="EstimateDate" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-HorizontalAlign="Left" AllowFiltering="true" FilterControlWidth="100"
                        HeaderStyle-Width="20%" HeaderText="" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true"
                        ItemStyle-Width="20%" SortExpression="EstimateDate" UniqueName="EstimateDate"
                        Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','1','','','<%=isView%>'); return false">
                                <div style="float: left; width: 99%; margin-left: 8px; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_EstimateDate_Estimates" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EstimateDate", "{0}") %>'></asp:Label>
                                    <asp:HiddenField ID="hdn_EstimateDate_Estimates" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EstimateDate", "{0}") %>'>
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
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','1','','','<%=isView%>'); return false">
                                <div style="float: left; width: 99%; margin-left: 12px; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_StatusTitle_Estimates" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.StatusTitle", "{0}")) %>'
                                        ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.StatusTitle", "{0}")) %>'></asp:Label>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="EstimateValue" HeaderStyle-HorizontalAlign="Right"
                        ItemStyle-HorizontalAlign="Right" AllowFiltering="true" FilterControlWidth="112"
                        HeaderStyle-Width="13%" HeaderText="" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true"
                        ItemStyle-Width="13%" SortExpression="EstimateValue" UniqueName="EstimateValue"
                        Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="javascript:DisplaySummaryPopUp('<%# DataBinder.Eval(Container, "DataItem.EstimateID", "{0}") %>','1','','','<%=isView%>'); return false">
                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_EstimateValue_Estimates" runat="server" Style="margin: 0px 2px 0px 0px"></asp:Label>
                                    <asp:HiddenField ID="hdn_EstimateValue_Estimates" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EstimateValue", "{0}") %>'>
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
<%--<script type="text/javascript">
    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";
</script>--%>
<script type="text/javascript" language="javascript">

    function LoadingImageEstimate() {
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

