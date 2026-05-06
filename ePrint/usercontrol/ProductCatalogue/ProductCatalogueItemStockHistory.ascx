<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCatalogueItemStockHistory.ascx.cs" Inherits="ePrint.usercontrol.ProductCatalogue.ProductCatalogueItemStockHistory" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="../../js/item/pricecatalogfeatures.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../../js/item/AutoFill.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<div id="divBackGroundNew" style="display: none; left: 0px; width: 100%; height: 100%; top: 0px; opacity: 0.5px; z-index: 10; position: fixed;">
</div>
<div id="div_ProductCatalogueItemStockHistory" runat="server" align="left" style="width: 100%; height: auto; margin-top: -14px; right: 0px; position: absolute;">
    <asp:Button ID="imgback_ProductCatalogueItemStockHistory" runat="server" CssClass="button" Style="margin-left: 7px; display:none;"
        Text="Back" ToolTip="Back to Stock Management" OnClientClick="javascript:backtoproducthistory();return false;" />
    <div style="height: 10px;" class="onlyEmpty">
    </div>
    <div id="div_grdProductCatalogueItemStockHistory">
        <asp:UpdatePanel ID="pnlgridProductCatalogueUItemStockHistory" runat="server">
            <ContentTemplate>
                <telerik:RadGrid ID="grdProductCatalogueItemStockHistory" runat="server" AutoGenerateColumns="false"
                    AllowSorting="false" PagerStyle-AlwaysVisible="true" AllowPaging="true" AllowCustomPaging="true"
                    OnNeedDataSource="grdProductCatalogueItemStockHistory_NeedDataSource" OnItemDataBound="grdProductCatalogueItemStockHistory_ItemDataBound"
                    OnItemCommand="grdProductCatalogueItemStockHistory_ItemCommand"
                    OnPageIndexChanged="grdProductCatalogueItemStockHistory_PageIndexChanged"
                    GridLines="None" HeaderStyle-Font-Bold="true" AllowFilteringByColumn="true" ClientSettings-EnableRowHoverStyle="true" PageSize="20"
                    Width="100%">
                    <MasterTableView CommandItemDisplay="Top">
                        <CommandItemTemplate>
                            <div id="DivExport_ProductCatalogueItemStockHistory" style="height: 30px">
                                <%--<a id="a1export_ProductCatalogueItemStockHistory" href="#" onclick="getrecord();" style="margin-left: 8px;">
                                    <asp:Label ID="lblimgexprot_ProductCatalogueItemStockHistory" ToolTip="Export" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/export-icon1.jpg"  />
                                    </asp:Label>
                                </a>--%>
                                <asp:LinkButton ID="btnclrFilters_ProductCatalogueItemStockHistory" Style="text-decoration: underline; float: right; cursor: pointer; margin: 6px 4px 0px 0px"
                                    runat="server" OnClick="btnclrFilters_ProductCatalogueItemStockHistory_Click"
                                    Text="Clear All Filters"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                            </div>
                        </CommandItemTemplate>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Job Date" ItemStyle-Width="10%" HeaderStyle-Width="10%" UniqueName="JobDate"
                                CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataField="JobDate"
                                SortExpression="JobDate" FilterControlToolTip="JobDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" ToolTip='<%#Eval("JobDate")%>' Text='<%#Eval("JobDate")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Order Number" CurrentFilterFunction="Contains" UniqueName="OrderNumber"
                                AutoPostBackOnFilter="true" DataField="OrderNumber" SortExpression="OrderNumber" ItemStyle-Width="10%"
                                HeaderStyle-Width="10%" FilterControlToolTip="OrderNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderNumber" runat="server" ToolTip='<%#Eval("OrderNumber")%>' Text='<%#Eval("OrderNumber")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>

                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Job Number" CurrentFilterFunction="Contains" UniqueName="JobNumber"
                                AutoPostBackOnFilter="true" DataField="JobNumber" SortExpression="JobNumber" ItemStyle-Width="10%"
                                HeaderStyle-Width="10%" FilterControlToolTip="JobNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblJobNumber" runat="server" ToolTip='<%#Eval("JobNumber")%>' Text='<%#Eval("JobNumber")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Customer Name" SortExpression="ClientName"  UniqueName="ClientName"
                                AutoPostBackOnFilter="true" DataField="ClientName" CurrentFilterFunction="Contains"
                                ItemStyle-Width="20%" HeaderStyle-Width="20%" FilterControlWidth="40%" FilterControlToolTip="ClientName">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerName" runat="server" ToolTip='<%#Eval("ClientName")%>' Text='<%#Eval("ClientName")%>'></asp:Label></br>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Ordered By" DataField="OrderedBy" HeaderStyle-HorizontalAlign="Left"
                                AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ItemStyle-HorizontalAlign="Left"  UniqueName="OrderedBy"
                                SortExpression="OrderedBy" ItemStyle-Width="10%" HeaderStyle-Width="10%" FilterControlToolTip="OrderedBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderedBy" runat="server" ToolTip='<%#Eval("OrderedBy")%>' Text='<%#Eval("OrderedBy")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Ordered Quantity" DataField="OrderedQuantity"
                                CurrentFilterFunction="Contains" AllowFiltering="false" AutoPostBackOnFilter="true"
                                ItemStyle-Width="7%" HeaderStyle-Width="7%" HeaderStyle-HorizontalAlign="Right"
                                ItemStyle-HorizontalAlign="Right" SortExpression="OrderedQuantity" FilterControlToolTip="OrderedQuantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderedQuantity" runat="server" ToolTip='<%#Eval("OrderedQuantity")%>' Text='<%#Eval("OrderedQuantity")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridTemplateColumn DataField="AllocatedQuantity" HeaderStyle-HorizontalAlign="Right"
                                AllowFiltering="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                ItemStyle-Width="7%" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="Right"
                                SortExpression="AllocatedQuantity" HeaderText="Allocated Quantity" FilterControlToolTip="AllocatedQuantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblAllocatedQuantity" runat="server" ToolTip='<%#Eval("AllocatedQty")%>' Text='<%#Eval("AllocatedQty")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Dispatched Quantity" DataField="DispatchedQuantity"
                                CurrentFilterFunction="Contains" AllowFiltering="false" AutoPostBackOnFilter="true"
                                ItemStyle-Width="7%" HeaderStyle-Width="7%" HeaderStyle-HorizontalAlign="Right"
                                ItemStyle-HorizontalAlign="Right" SortExpression="DispatchedQuantity" FilterControlToolTip="DispatchedQuantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblDispatchedQuantity" runat="server" ToolTip='<%#Eval("ReleasedQty")%>' Text='<%#Eval("ReleasedQty")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        </MasterTableView>
                </telerik:RadGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="upProgress" runat="server">
            <ProgressTemplate>
                <div id="div_Load" class="loading_new" style="display: block">
                    <table cellpadding="0" cellspacing="10">
                        <tr>
                            <td>
                                <div style="float: left">
                                    <img src="<%=strImagepath%>loading_new.gif" border="0" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</div>
<script type="text/javascript" lang="javascript">
    var CustomerDiv = false;
    var Pgtype = 'job';
    var CompanyID = <%=CompanyID%>;
    var UserID = <%=UserID%>;
    var indexvalue = 0;
    var type = '';
    var ProductCatalogueID = "<%=ProductCatalogueID %>";

    function backtoproducthistory() {
        document.location.href = "<%=strSitepath %>" + "common/common_popup.aspx?type=stockedit&action=edit&id=" + ProductCatalogueID, '1330', '520';
    }
</script>

