<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCatalogueItemStockPO.ascx.cs" Inherits="ePrint.usercontrol.ProductCatalogue.ProductCatalogueItemStockPO" %>
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
                            <telerik:GridTemplateColumn HeaderText="PO Date" ItemStyle-Width="10%" HeaderStyle-Width="10%" UniqueName="PODate"
                                CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataField="PODate"
                                SortExpression="PODate" FilterControlToolTip="PODate">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" ToolTip='<%#Eval("PODate")%>' Text='<%#Eval("PODate")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="PO Number" CurrentFilterFunction="Contains" UniqueName="PONumber"
                                AutoPostBackOnFilter="true" DataField="PONumber" SortExpression="PONumber" ItemStyle-Width="10%"
                                HeaderStyle-Width="7%" FilterControlToolTip="PONumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblPONumber" runat="server" ToolTip='<%#Eval("PONumber")%>' Text='<%#Eval("PONumber")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>

                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="PO Quantity" DataField="POQuantity"
                                CurrentFilterFunction="Contains" AllowFiltering="false" AutoPostBackOnFilter="true"
                                ItemStyle-Width="7%" HeaderStyle-Width="7%" HeaderStyle-HorizontalAlign="Right"
                                ItemStyle-HorizontalAlign="Right" SortExpression="POQuantity" FilterControlToolTip="POQuantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOQuantity" runat="server" ToolTip='<%#Eval("POQuantity")%>' Text='<%#Eval("POQuantity")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>

                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="PO Received" DataField="POReceived"
                                CurrentFilterFunction="Contains" AllowFiltering="false" AutoPostBackOnFilter="true"
                                ItemStyle-Width="7%" HeaderStyle-Width="7%" HeaderStyle-HorizontalAlign="Right"
                                ItemStyle-HorizontalAlign="Right" SortExpression="POReceived" FilterControlToolTip="POReceived">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOReceived" runat="server" ToolTip='<%#Eval("POReceived")%>' Text='<%#Eval("POReceived")%>'></asp:Label>
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

